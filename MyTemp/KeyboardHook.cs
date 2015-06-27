using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyTemp
{
    //键盘记录类,用于记录键盘操作
    //注意:非本程序上的键盘记录,是开机后所有的键盘敲击记录,需获取系统所有的键盘敲击
    //用到API调用

    public class KeyboardHook:IDisposable
    {
        //定义托管类型
        public delegate IntPtr HookHandlerDelegate(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
        public delegate void KeyboardHookEventHandler(string e);
        public delegate bool KeyFilterHandle(string KeysArray,IntPtr wParam, KBDLLHOOKSTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(HookType idHook, HookHandlerDelegate lpfn, IntPtr hMod, uint dwThreadId);
        /*
        idHook：
        这个数字决定了要建立的钩子的类型。例如,SetWindowsHookEx可以被用于钩住鼠标事件（当然还有其它事件）。
        在本文情况下,我们仅对13有兴趣,这是键盘钩子的id。为了使代码更易读些,我们把它赋值给一个常数WH_KEYBOARD_LL。
        Lpfn：
        这是一个指向函数的长指针,该函数将负责处理键盘事件。在C#中,"指针"是通过传递一个代理类型的实例而获得的,
        从而使之引用一个适当的方法。这是我们在每次使用钩子时所调用的方法。
        这里值得注意的是,这个代理实例需要被存储于这个类的一个成员变量中。这是为了防止一旦第一个方法调用结束它会被作为垃圾回收。
        hMod：
        建立钩子的应用程序的一个实例句柄。我找到的绝大多数实例仅把它设置为IntPtr.Zero,
        理由是不大可能存在该应用程序的多个实例。然而,这部分代码使用了来自于kernel32.dll的GetModuleHandle来标识准确的实例
        从而使这个类更具灵活性。
        dwThreadId：
        当前进程的id。把它设置为0可以使这个钩子成为全局构子,这是相应于一个低级键盘钩子的正确设置。
        SetWindowsHookEx返回一个钩子id,这个id将被用于当应用程序结束时从钩子链中脱钩,因此它需要存储在一个成员变量中以备将来使用。
         */

        //把击键传递到下一个应用程序
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        //移去钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        //获取当前进程的句柄
        [DllImport("kernel32.dll")]
        private static extern int GetModuleHandle(string lpModuleName);

        //获取指定按键当前的状态
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        #region 变量成员

        //private NetworkStream Stream;
        
        //指示是否启动钩子
        public bool IsHooked;

        //按键过滤器
        public string Filters;

        private HookHandlerDelegate proc;//用于存储代理
        private IntPtr hookID = IntPtr.Zero;//钩子应用程序的一个实例句柄

        //指示钩子的类型
        public enum HookType
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,//表示键盘钩子
            WH_MOUSE_LL = 14,
            WH_MSGFILTER = -1,
        }

        //指示键盘事件
        public enum KeyboardEvents
        {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SystemKeyDown = 0x0104,
            SystemKeyUp = 0x0105
        } 

        //存储精确击键信息的结构,例如被按键的代码
        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;//表示一个在1到254间的虚似键盘码
            public int scanCode;//表示硬件扫描码
            public int flags;//表示是否这是一个扩展键（例如，Windows Start键）或是否同时按下了Alt键
            public int time;
            public int dwExtraInfo;
        }

        //定义一个键盘事件
        public event KeyboardHookEventHandler OnKeyIntercepted;

        #endregion

        #region 属性

        #endregion

        #region 构造函数

        public KeyboardHook()
        {
            //this.Stream = stream;
            proc = new HookHandlerDelegate(HookCallback);
            IsHooked = false;
        }

        #endregion

        #region 成员函数

        public void BeginHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    hookID = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, proc, (IntPtr)GetModuleHandle(curModule.ModuleName), 0);
                    IsHooked = true;
                }
            }
        }

        //用来处理键盘事件的回调函数
        private IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            //仅为KeyDown事件过滤wParam,否则该代码将再次执行-对于每一次击键（也就是,相应于KeyDown和KeyUp）
            //WM_SYSKEYDOWN是捕获Alt相关组合键所必需的
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)KeyboardEvents.KeyDown || wParam == (IntPtr)KeyboardEvents.SystemKeyDown)
                {
                    //激发事件
                    OnKeyIntercepted(lParam.vkCode.ToString() + "," + ((Keys)lParam.vkCode).ToString() + "," + lParam.flags.ToString());
                }
                
                //根据过滤器过滤相应的按键事件
                string[] filter = Filters.Split('&');
                KeyFilterHandle[] proc = new KeyFilterHandle[filter.Length];
                for (int i = 0; i < filter.Length; i++)
                {
                    proc[i] = new KeyFilterHandle(FilterKeys);
                    if (proc[i].Invoke(filter[i], wParam, lParam))
                    {
                        return (IntPtr)1;
                    }
                }
                
            }
            return CallNextHookEx(hookID, nCode, wParam, ref lParam);
        }

        #region IDisposable Members

        public void Dispose()
        {
            UnhookWindowsHookEx(hookID);
            IsHooked = false;
        }

        //返回值标识是否返回"哑"值,还是传递到下个钩子,真则返回"哑"值,假则传递
        private bool FilterKeys(string keyarray, IntPtr wParam, KBDLLHOOKSTRUCT lParam)
        {
            string[] k = keyarray.Split('+');
            Keys[] key = new Keys[k.Length];
            for (int i = 0; i < k.Length; i++)
            {
                key[i] = (Keys)(int.Parse(k[i].Trim()));
            }

            switch (k.Length)
            {
                case 1:
                    if ((Keys)lParam.vkCode == key[0])
                    {
                        if (wParam == (IntPtr)KeyboardEvents.KeyDown || wParam == (IntPtr)KeyboardEvents.SystemKeyDown)
                        {
                            //&& ((lParam.flags == 32) && (Keys)lParam.vkCode == Keys.Tab)
                            //激发事件
                            OnKeyIntercepted(key[0].ToString());
                        }

                        //返回一个"哑"值以捕获击键
                        return true;
                    }
                    break;
                case 2:
                    if (key[0] != Keys.Alt)
                    {
                        bool IsKeyDown = false;
                        if (GetAsyncKeyState((int)key[0]) >> ((sizeof(short) * 8) - 1) != 0)
                        {
                            IsKeyDown = true;
                        }
                        if (IsKeyDown && (Keys)lParam.vkCode == key[1])
                        {
                            if (wParam == (IntPtr)KeyboardEvents.KeyDown || wParam == (IntPtr)KeyboardEvents.SystemKeyDown)
                            {
                                //&& ((lParam.flags == 32) && (Keys)lParam.vkCode == Keys.Tab)
                                //激发事件
                                OnKeyIntercepted(key[0].ToString() + " + " + key[1].ToString());
                            }

                            //返回一个"哑"值以捕获击键
                            return true;
                        }
                    }
                    else
                    {
                        if ((lParam.flags == 32) && (Keys)lParam.vkCode == key[1])
                        {
                            if (wParam == (IntPtr)KeyboardEvents.KeyDown || wParam == (IntPtr)KeyboardEvents.SystemKeyDown)
                            {
                                //激发事件
                                OnKeyIntercepted(key[0].ToString() + " + " + key[1].ToString());
                            }

                            //返回一个"哑"值以捕获击键
                            return true;
                        }
                    }
                    break;

                case 3:
                    bool IsKey1Down = false;
                    bool IsKey2Down = false;
                    //判断前两个键是否按下
                    if (GetAsyncKeyState((int)key[0]) >> ((sizeof(short) * 8) - 1) != 0)
                    {
                        IsKey1Down = true;
                    }
                    if (GetAsyncKeyState((int)key[1]) >> ((sizeof(short) * 8) - 1) != 0)
                    {
                        IsKey2Down = true;
                    }
                    if (IsKey1Down && IsKey2Down && (Keys)lParam.vkCode == key[2])
                    {
                        if (wParam == (IntPtr)KeyboardEvents.KeyDown || wParam == (IntPtr)KeyboardEvents.SystemKeyDown)
                        {
                            //&& ((lParam.flags == 32) && (Keys)lParam.vkCode == Keys.Tab)
                            //激发事件
                            OnKeyIntercepted(key[0].ToString() + " + " + key[1].ToString() + " + " + key[2].ToString());
                        }

                        //返回一个"哑"值以捕获击键
                        return true;
                    }

                    break;
                default:
                    break;
            }
            
            return false;
        }

        #endregion

        #endregion
    }
}