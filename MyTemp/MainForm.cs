/*
 * Created by SharpDevelop.
 * User: Estein
 * Date: 25/04/2015
 * Time: 11:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WMEncoderLib;
using WMPREVIEWLib;

namespace MyTemp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private NotifyIcon ni;
		private KeyboardHook kh;
		private Temp mytp;
		Recording rc = new Recording();
		string eKey ="";
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//w
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		

		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
		this.ni = new NotifyIcon();
        this.ni.Visible = true;

	
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
			notifyIcon1.Visible =true;
			this.kh = new KeyboardHook();
			this.kh.BeginHook();
			this.kh.OnKeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(this.kh_OnkeyIntercepted);
		}
		
		
		
		private void kh_OnkeyIntercepted(string e)
        {
			eKey += e;
			if(
			MessageBox.Show(eKey);
			
		 	if ((Control.ModifierKeys & Keys.Control) !=0 && (Control.ModifierKeys & Keys.Shift ) != 0 )
		 	{
		 		this.kh.BeginHook();
		 		this.mytp = new Temp();
		 		this.mytp.Show();
		 		
		 	}
		 	
		 	
            
        }
		
		
		
		void RecordToolStripMenuItemClick(object sender, EventArgs e)
		{
			rc.CaptureScreen();
		}
		
		void StopToolStripMenuItemClick(object sender, EventArgs e)
		{
			rc.stopCapture();
		}
	}
}
