using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Data;








namespace MyTemp
{
	
	/// <summary>
	/// Description of myMenu.
	/// </summary>
	public class myMenu
	{
	
    SqlHelper sqlhelper= new SqlHelper();		
   	 private string _Path;
   	 public string Path
   	 {
   	 	get{return _Path;}
   	 	set{_Path= value;}
   	 }
   	 
   	 public bool FileExist()
   	 {
   	 	if(File.Exists(_Path))
   	 	{ return true;}
   	 	else return false;
   	 }

	
   	 
   	 public void LoadAllMenu(MenuStrip menuStrip)
   	 {
   	 	string id = "";
   	 	string title = "";
   	 	string newID="";
   	 	DataSet ds= new DataSet();
   	 	
   	 	ds= sqlhelper.dataSetSelect("SELECT distinct id, title  FROM Xls_Menu");
   	 	for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
   	 	{
   	 		
   	 		ToolStripMenuItem toolitem = new ToolStripMenuItem();
   	 		id= ds.Tables[0].Rows[i]["id"].ToString();
   	 		title=ds.Tables[0].Rows[i]["title"].ToString();
   	 		toolitem.Text= title;
   	 		toolitem.Name= "Item"+ id;
   	 		if(title!=null )
   	 		{
   	 			menuStrip.Items.Add(toolitem);
   	 			
   	 			DataSet newDs= new DataSet();
   	 			newDs= sqlhelper.dataSetSelect("select * from Xls_Menu where id='"+id+"'");
   	 
   	 			for (int j = 0; j < newDs.Tables[0].Rows.Count; j++) 
   	 			{
   	 				ToolStripMenuItem toolSubItem = new ToolStripMenuItem();
   	 		        toolSubItem.Name = "Item" + newID;
   	 				newID=newDs.Tables[0].Rows[j]["id2"].ToString();
	   	 		    toolSubItem.Text=newDs.Tables[0].Rows[j]["Title3"].ToString();
	   	 		    toolSubItem.ToolTipText= newDs.Tables[0].Rows[j]["Express"].ToString();
	   	 		    toolSubItem.Click+= new EventHandler(toolSubItem_MouseOver);
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)menuStrip.Items["Item" + newID.Substring(0, 2)];
                        //添加子菜单
                    toolStripMenuItem.DropDownItems.Add(toolSubItem);
                    

   	 			}
   	 		    	
   	 		 }
   	 			
   	     }
   	 		
	  }   	 	
   	 	


      

      public void toolSubItem_MouseOver(object sender, EventArgs e)
      {
          string myNewStrings = ((ToolStripMenuItem)sender).Text;
          DirectoryInfo directoryInfo= new DirectoryInfo(@"C:\MyData\MyTemplate\");
          string IOPath= directoryInfo.ToString()+myNewStrings+".rtf";
          
          string allText = string.Empty;
          Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
          string filename = IOPath;
          object file = filename;
          
          object nullobj = System.Reflection.Missing.Value;

          Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,

          ref nullobj, ref nullobj, ref nullobj,

          ref nullobj, ref nullobj, ref nullobj,

          ref nullobj, ref nullobj, ref nullobj,

          ref nullobj, ref nullobj, ref nullobj, ref nullobj);
          doc.ActiveWindow.Selection.WholeStory();
          IDataObject data = Clipboard.GetDataObject();
          Clipboard.Clear();
          doc.ActiveWindow.Selection.Copy();
          doc.Close(ref nullobj, ref nullobj, ref nullobj);
          wordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
          



      }

 
      
        
	}
	
}
