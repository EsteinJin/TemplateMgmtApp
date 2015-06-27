/*
 * Created by SharpDevelop.
 * User: Estein
 * Date: 25/04/2015
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;
using System.IO;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;


namespace MyTemp
{
	/// <summary>
	/// Description of Temp.
	/// </summary>
	public partial class Temp : Form
	{
		SqlHelper sqlhelper= new SqlHelper();
		private KeyboardHook kh;
		Common cm = new Common();
		OleDbCommandBuilder cmb1 = new OleDbCommandBuilder();
		OleDbDataAdapter adapter = new OleDbDataAdapter();
		
		DataSet ds = new DataSet();
		DataTable dt = new DataTable();
		OleDbConnection oleCon= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ Application.StartupPath+"\\DB\\PSA.mdb");
		string instertstr;
		
		
		
		
		 [DllImport("user32")]  
      private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);  
      //下面是可用的常量，根据不同的动画效果声明自己需要的  
      private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
      private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
      private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
      private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
      private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  
      private const int AW_HIDE = 0x10000;//隐藏窗口  
      private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
      private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略  
      private const int AW_BLEND = 0x80000;//使用淡入淡出效果  
      
		public Temp()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void LoadMenu()
		{
			myMenu menu = new myMenu();
			menu.LoadAllMenu(MainMenu);
			
		}
		void TempLoad(object sender, EventArgs e)
		{
			this.skinEngine1.SkinFile= Application.StartupPath + "\\Skins\\XPBlue.ssk";
			LoadMenu();
			
		 Clipboard.Clear();
          int x = Cursor.Position.X;
          int y= Cursor.Position.Y;
          this.Location = new Point(x, y);//设置窗体在屏幕右下角显示 
          AnimateWindow(this.Handle, 10, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE); 
          ComboDB();
          CategoryComboDB();
          	if(oleCon.State.ToString().Equals("Closed"))
       	{
       		oleCon.Open();
       	}
          adapter = new OleDbDataAdapter("select * from Xls_MyTemp",oleCon);
          ds = new DataSet();
          adapter.Fill(ds, "MyTemp");
          dataGridView1.DataSource = ds.Tables[0];
          
          
      
          
          
          kh= new KeyboardHook();
 		  kh.BeginHook();
 		  kh.OnKeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(this.kh_OnkeyIntercepted);
			
			
		}
		
			void BtnUpdateTempClick(object sender, EventArgs e)
		{
		
			
         cmb1 = new OleDbCommandBuilder(adapter);
				adapter.Update(ds, "MyTemp");
				MessageBox.Show("Updated!");
				

		}
			
			
		public 	void CategoryComboDB()
		{
		comboBox2.Items.Clear();
		sqlhelper.selectAllWithKeyForCombo("select distinct CategoryName from Category" ,comboBox2);
		
		}
	
		
		public void ComboDB()
		{
			comboBox1.Items.Clear();
		sqlhelper.selectAllWithKeyForCombo("select distinct TemName from Xls_MyTemp where TemName <>''",comboBox1);
		}
		private void kh_OnkeyIntercepted(string e)
		{
  	    if ((Control.ModifierKeys & Keys.Control) !=0 && (Control.ModifierKeys & Keys.Shift ) != 0 )
			{
  	    	this.sqlhelper.sqlConClose();
  	    	this.kh.Dispose();
  	    	base.Close();
			}
  	    else
  	    {
  	    	int a = 0;
			int i = 0;
			string keyBoards= cm.keyToWords(e);
			if(int.TryParse(keyBoards,out a ) ==false)
			{
			textBox2.Text+= keyBoards;
			}
			else 
			{
				i = int.Parse(keyBoards);
				IDataObject iData= new DataObject(treeView1.Nodes[0].Nodes[i].Text.ToString());
		 		Clipboard.SetDataObject(iData);	
		 		this.kh.Dispose();
		 		base.Close();
		 		
			}
			
			if(e=="8,Back,0" | keyBoards=="Back")
			{
				textBox2.Text="";
				
		
			}
  	    	
  	    }
		}
		
		

		void TreeView1MouseDown(object sender, MouseEventArgs e)
		{
			 if ((sender as TreeView) != null)
 		{
		kh.Dispose();
 		treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
 		IDataObject iData= new DataObject(treeView1.SelectedNode.Text.ToString());
 		Clipboard.SetDataObject(iData);
 		this.Hide();
		
		
		
 		}

		}

		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
		string txtBox = textBox2.Text.ToString();	
	    string TemCon;
		TemCon= comboBox1.SelectedItem.ToString();
 	    treeView1.Nodes[0].Nodes.Clear();	
		DataSet ds = sqlhelper.dataSetSelect("select * from Xls_MyTemp where TemContents  like '%"+txtBox+"%' and TemName like '%"+TemCon+"%' ");
		  for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
		  {//comboBox1.Items.Add(ds.Tables[0].Rows[i]["TemContents"].ToString());
		  	TreeNode nodes= treeView1.Nodes[0].Nodes.Add(ds.Tables[0].Rows[i]["TemContents"].ToString());
		  	nodes.SelectedImageIndex= i+1;
		  	nodes.ImageIndex=nodes.SelectedImageIndex;
		  	
		  }
		  treeView1.ExpandAll();
			
		}

		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
		  string txtBox = textBox2.Text.ToString();
		  string TemCon;

		  treeView1.Nodes[0].Nodes.Clear();	
		if ((comboBox1 != null) && (comboBox1.SelectedItem != null)) {
		  TemCon= comboBox1.SelectedItem.ToString();	
		}
		  else
		  {
		  	TemCon= "";
		  }
		  
		  DataSet ds = sqlhelper.dataSetSelect("select * from Xls_MyTemp where TemContents like '%"+txtBox+"%' and TemName like '%"+TemCon+"%' ");
		  for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
		  {//comboBox1.Items.Add(ds.Tables[0].Rows[i]["TemContents"].ToString());
		  	TreeNode nodes= treeView1.Nodes[0].Nodes.Add(ds.Tables[0].Rows[i]["TemContents"].ToString());
		  	nodes.SelectedImageIndex= i+1;
		  	nodes.ImageIndex=nodes.SelectedImageIndex;
		  	
		  	
		  }
		treeView1.ExpandAll();

 	}
		void BtnCloseClick(object sender, EventArgs e)
		{
			kh.Dispose();
			this.Hide();
		}
		void BtnSaveClick(object sender, EventArgs e)
		{
		if(oleCon.State.ToString().Equals("Closed"))
       	{
       		oleCon.Open();
       	}
		
		richTextBox1.SaveFile(@"C:\MyData\MyTemplate\"+txtFileName.Text.ToString()+".rtf",RichTextBoxStreamType.RichText);
		instertstr ="insert into Xls_Menu ([title],[Title3]) values ('"+ comboBox2.SelectedItem.ToString()+"','"+txtFileName.Text.ToString()+ "')";
		OleDbCommand insertcmd = new OleDbCommand(instertstr,oleCon);
		insertcmd.ExecuteNonQuery();
		MessageBox.Show("Template Saved Successfully!");
			
		}
		void BtnUpdateClick(object sender, EventArgs e)
		{
	            cmb1 = new OleDbCommandBuilder(adapter);
				adapter.Update(ds,"MyMenu");
				MessageBox.Show("Updated!");
		}
		void BtnLoadClick(object sender, EventArgs e)
		{
		richTextBox1.LoadFile(@"C:\MyData\MyTemplate\"+txtFileName.Text.ToString()+".rtf",RichTextBoxStreamType.RichText);
		
		}
		void BtnUpdateTemplateClick(object sender, EventArgs e)
		{
		if(oleCon.State.ToString().Equals("Closed"))
       	{
       		oleCon.Open();
       	}
		
		richTextBox1.SaveFile(@"C:\MyData\MyTemplate\"+txtFileName.Text.ToString()+".rtf",RichTextBoxStreamType.RichText);
		instertstr ="update Xls_Menu set [title] = '"+ comboBox2.SelectedItem.ToString()+"',[Title3]='"+txtFileName.Text.ToString()+"'where M_id ="+int.Parse(textBox1.Text.ToString());
		OleDbCommand insertcmd = new OleDbCommand(instertstr,oleCon);
		insertcmd.ExecuteNonQuery();
		MessageBox.Show("Template Saved Successfully!");
		}
		void DataGridView2CellClick(object sender, DataGridViewCellEventArgs e)
		{
			comboBox2.SelectedItem =  this.dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
			txtFileName.Text = this.dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
		    textBox1.Text = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
		    
		}


	
		
		
		
		void BtnViewClick(object sender, EventArgs e)
		{
		 adapter = new OleDbDataAdapter("select * from Xls_Menu",oleCon);
          ds = new DataSet();
          adapter.Fill(ds, "MyMenu");
         dataGridView2.DataSource = ds.Tables[0];
		}
		
		void BtnTempViewClick(object sender, EventArgs e)
		{
			adapter = new OleDbDataAdapter("select * from Xls_MyTemp",oleCon);
          ds = new DataSet();
          adapter.Fill(ds, "MyTemp");
          dataGridView1.DataSource = ds.Tables[0];
          
		}
		void Button1Click(object sender, EventArgs e)
		{
   	    kh.Dispose();
		}
		void Button2Click(object sender, EventArgs e)
		{
			kh.BeginHook();
		}
		void Button3Click(object sender, EventArgs e)
		{
	adapter = new OleDbDataAdapter("select * from Category",oleCon);
          ds = new DataSet();
          adapter.Fill(ds, "Category");
         dataGridView3.DataSource = ds.Tables[0];
		}
		void Button4Click(object sender, EventArgs e)
		{
	cmb1 = new OleDbCommandBuilder(adapter);
				adapter.Update(ds, "Category");
				MessageBox.Show("Updated!");
		}
	}
}
