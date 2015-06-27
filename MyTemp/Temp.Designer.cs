/*
 * Created by SharpDevelop.
 * User: Estein
 * Date: 25/04/2015
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyTemp
{
	partial class Temp
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnUpdateTemp;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Button btnUpdateTemplate;
		private System.Windows.Forms.TextBox textBox1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Templist");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Temp));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnTempView = new System.Windows.Forms.Button();
			this.btnUpdateTemp = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnView = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnUpdateTemplate = new System.Windows.Forms.Button();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabControl1.Location = new System.Drawing.Point(0, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(824, 233);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.btnClose);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.treeView1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(816, 207);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Template";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(508, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "HookStart";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(617, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "HookerPause";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(735, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 25);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "XClose";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.NavajoWhite;
			this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(3, 1);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(139, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(148, 1);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(285, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// treeView1
			// 
			this.treeView1.BackColor = System.Drawing.Color.LemonChiffon;
			this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeView1.ForeColor = System.Drawing.Color.Black;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(3, 27);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Templist";
			treeNode1.Text = "Templist";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
			treeNode1});
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowNodeToolTips = true;
			this.treeView1.Size = new System.Drawing.Size(807, 175);
			this.treeView1.TabIndex = 5;
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView1MouseDown);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "rtx.ico");
			this.imageList1.Images.SetKeyName(1, "Number_010.png");
			this.imageList1.Images.SetKeyName(2, "Number_001.png");
			this.imageList1.Images.SetKeyName(3, "Number_002.png");
			this.imageList1.Images.SetKeyName(4, "Number_003.png");
			this.imageList1.Images.SetKeyName(5, "Number_004.png");
			this.imageList1.Images.SetKeyName(6, "Number_005.png");
			this.imageList1.Images.SetKeyName(7, "Number_006.png");
			this.imageList1.Images.SetKeyName(8, "Number_007.png");
			this.imageList1.Images.SetKeyName(9, "Number_008.png");
			this.imageList1.Images.SetKeyName(10, "Number_009.png");
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnTempView);
			this.tabPage2.Controls.Add(this.btnUpdateTemp);
			this.tabPage2.Controls.Add(this.dataGridView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(816, 205);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Instant";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnTempView
			// 
			this.btnTempView.Location = new System.Drawing.Point(736, 39);
			this.btnTempView.Name = "btnTempView";
			this.btnTempView.Size = new System.Drawing.Size(75, 25);
			this.btnTempView.TabIndex = 2;
			this.btnTempView.Text = "BeforeUp";
			this.btnTempView.UseVisualStyleBackColor = true;
			this.btnTempView.Click += new System.EventHandler(this.BtnTempViewClick);
			// 
			// btnUpdateTemp
			// 
			this.btnUpdateTemp.Location = new System.Drawing.Point(735, 7);
			this.btnUpdateTemp.Name = "btnUpdateTemp";
			this.btnUpdateTemp.Size = new System.Drawing.Size(75, 25);
			this.btnUpdateTemp.TabIndex = 1;
			this.btnUpdateTemp.Text = "Update";
			this.btnUpdateTemp.UseVisualStyleBackColor = true;
			this.btnUpdateTemp.Click += new System.EventHandler(this.BtnUpdateTempClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(726, 193);
			this.dataGridView1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnView);
			this.tabPage3.Controls.Add(this.textBox1);
			this.tabPage3.Controls.Add(this.btnUpdateTemplate);
			this.tabPage3.Controls.Add(this.txtFileName);
			this.tabPage3.Controls.Add(this.btnUpdate);
			this.tabPage3.Controls.Add(this.btnLoad);
			this.tabPage3.Controls.Add(this.btnSave);
			this.tabPage3.Controls.Add(this.comboBox2);
			this.tabPage3.Controls.Add(this.dataGridView2);
			this.tabPage3.Controls.Add(this.richTextBox1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(816, 205);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Featured";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(583, 3);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 25);
			this.btnView.TabIndex = 9;
			this.btnView.Text = "GridView";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.BtnViewClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(267, 30);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(40, 20);
			this.textBox1.TabIndex = 8;
			// 
			// btnUpdateTemplate
			// 
			this.btnUpdateTemplate.Location = new System.Drawing.Point(478, 2);
			this.btnUpdateTemplate.Name = "btnUpdateTemplate";
			this.btnUpdateTemplate.Size = new System.Drawing.Size(75, 25);
			this.btnUpdateTemplate.TabIndex = 7;
			this.btnUpdateTemplate.Text = "UpdateTemplate";
			this.btnUpdateTemplate.UseVisualStyleBackColor = true;
			this.btnUpdateTemplate.Click += new System.EventHandler(this.BtnUpdateTemplateClick);
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(3, 30);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(257, 20);
			this.txtFileName.TabIndex = 6;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(714, 2);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(99, 25);
			this.btnUpdate.TabIndex = 5;
			this.btnUpdate.Text = "UpdateRecord";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(397, 3);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 25);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(316, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 25);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(3, 2);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(307, 21);
			this.comboBox2.TabIndex = 2;
			// 
			// dataGridView2
			// 
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(313, 30);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.Size = new System.Drawing.Size(500, 169);
			this.dataGridView2.TabIndex = 1;
			this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2CellClick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(3, 56);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(307, 143);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button4);
			this.tabPage4.Controls.Add(this.button3);
			this.tabPage4.Controls.Add(this.dataGridView3);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(816, 205);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Config";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(273, 50);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 2;
			this.button4.Text = "Update";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(273, 7);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "GridView";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// dataGridView3
			// 
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Location = new System.Drawing.Point(3, 3);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(240, 199);
			this.dataGridView3.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// MainMenu
			// 
			this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.MainMenu.Size = new System.Drawing.Size(824, 24);
			this.MainMenu.TabIndex = 4;
			this.MainMenu.Text = "menuStrip1";
			// 
			// skinEngine1
			// 
			this.skinEngine1.@__DrawButtonFocusRectangle = true;
			this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
			this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
			this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.skinEngine1.SerialNumber = "";
			this.skinEngine1.SkinFile = null;
			// 
			// Temp
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(824, 260);
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Temp";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Temp";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.TempLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button btnTempView;
		private System.Windows.Forms.Button btnView;
		private Sunisoft.IrisSkin.SkinEngine skinEngine1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGridView dataGridView3;
	}
}
