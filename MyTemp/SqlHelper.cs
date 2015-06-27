/*
 * Created by SharpDevelop.
 * User: I301354
 * Date: 2013/12/11
 * Time: 23:33
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

namespace MyTemp
{
	/// <summary>
	/// Description of SqlHelper.
	/// </summary>
	public class SqlHelper
	{
		OleDbConnection con= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ Application.StartupPath+"\\DB\\PSA.mdb");
    	OleDbDataAdapter oledbAdapter;
    	DataSet ds;
    	OleDbCommandBuilder cmb1 = new OleDbCommandBuilder();
		public SqlHelper()
		{
		}
		
		/// <summary>
		/// ComboList
		/// </summary>
		public void addComboWithDB(string selectKey,DataGridView dgV, ComboBox cbx, string fillItem)
		{
		if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
       	oledbAdapter = new OleDbDataAdapter();
       	
       	ds= new DataSet();
       	try
       	{

       		oledbAdapter.SelectCommand= new OleDbCommand(selectKey, con);

			dgV.DataSource= null;
       		oledbAdapter.Fill(ds);
       		oledbAdapter.Dispose();
       		for(int i =0 ; i<ds.Tables[0].Rows.Count; i++)
       		{
       			cbx.Items.Add(ds.Tables[0].Rows[i][fillItem].ToString());
       		}
       	

       		
       	}
       	catch(Exception ex)
       	{
       		MessageBox.Show(ex.ToString());
       	}
       	if(con.State.ToString().Equals("Open"))
       	{
       		con.Close();
       	}			
			
		}
		
		public void sqlConClose()
		{
			if(this.con.State.ToString().Equals("Open"))
			{
				this.con.Close();
			}
	
		}
		
		public void sqlConOpen()
		{
		if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
		}
		
		
		public void DatasetFill(string selectKey, string dsName, DataGridView dgv)
		{
			sqlConOpen();
			oledbAdapter = new OleDbDataAdapter(selectKey,con);
			ds = new DataSet();
			oledbAdapter.Fill(ds, dsName);
			dgv.DataSource = ds.Tables[0];
		}
		
		

		
		
		
		public void selectAllWithKey(string selectKey, DataGridView dgV)
		{
if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
       	oledbAdapter = new OleDbDataAdapter();
       	
       	ds= new DataSet();
       	try
       	{

       		oledbAdapter.SelectCommand= new OleDbCommand(selectKey, con);

			dgV.DataSource= null;
       		oledbAdapter.Fill(ds);
       		oledbAdapter.Dispose();
       		dgV.DataSource= ds.Tables[0];
       	}
       	catch(Exception ex)
       	{
       		MessageBox.Show(ex.ToString());
       	}
       	if(con.State.ToString().Equals("Open"))
       	{
       		con.Close();
       	}			
			
		}
		


	
		
		

		public DataSet dataSetSelect(string selectKey)
		{
if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
       	oledbAdapter = new OleDbDataAdapter();
       	
       	ds= new DataSet();
       	try
       	{
       	

       		oledbAdapter.SelectCommand= new OleDbCommand(selectKey, con);
       		
       		oledbAdapter.Fill(ds);
       		oledbAdapter.Dispose();
       		return ds;
       	}
       	catch(Exception ex)
       	{
       		MessageBox.Show(ex.ToString());
       		return null;
       	}
       	if(con.State.ToString().Equals("Open"))
       	{
       		con.Close();
       	}			
			
		}
		
		
		
		
		
		public void selectAllWithKeyForCombo(string selectKey, ComboBox cbox)
		{
if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
       	oledbAdapter = new OleDbDataAdapter();
       	
       	ds= new DataSet();
       	try
       	{

       		oledbAdapter.SelectCommand= new OleDbCommand(selectKey, con);

			cbox.DataSource= null;
       		oledbAdapter.Fill(ds);
       		oledbAdapter.Dispose();
       		for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
       		{
       			cbox.Items.Add(ds.Tables[0].Rows[i][0].ToString());
       			
       		}
       		
       	}
       	catch(Exception ex)
       	{
       		MessageBox.Show(ex.ToString());
       	}
       	if(con.State.ToString().Equals("Open"))
       	{
       		con.Close();
       	}			
			
		}

		
		
		public void sqlMailClip(string selectKey,DataGridView dgV,string fieldName)
		{
			
if(con.State.ToString().Equals("Closed"))
       	{
       		con.Open();
       	}
       	oledbAdapter = new OleDbDataAdapter();
       	ds= new DataSet();
       	try
       	{
       		oledbAdapter.SelectCommand= new OleDbCommand(selectKey, con);

			dgV.DataSource= null;
       		oledbAdapter.Fill(ds);
       		oledbAdapter.Dispose();
       		dgV.DataSource= ds.Tables[0];	
        	StringBuilder sbEmail= new StringBuilder();
        	for(int i = 0 ; i<ds.Tables[0].Rows.Count;i++)
        	{
        		sbEmail.Append(ds.Tables[0].Rows[i][fieldName].ToString()+";");
        	}
        	Clipboard.SetText(sbEmail.ToString());
       		
       	}
       	catch(Exception ex)
       	{
       		MessageBox.Show(ex.ToString());
       	}
       	if(con.State.ToString().Equals("Open"))
       	{
       		con.Close();
       	}			
			
		}
		
		public void searchDBByID(TextBox txtBox,string whereKey, DataGridView dgV,string inputField)
		{
			string tempText = txtBox.Text.Trim().Replace("\r\n", "|");
        	string[] crmText = tempText.Split('|');
        	con.Open();
        	oledbAdapter = new OleDbDataAdapter();
        	ds= new DataSet();
        	dgV.DataSource= null;
        	foreach(string newstring in crmText)
        	{
        	oledbAdapter.SelectCommand = new OleDbCommand("SELECT  Xls_Contact.Partner,Xls_Contact.[CRM ID], Xls_Contact.[Partner ID],Xls_Contact.[Relationship With] as [SAP Partner Manager], Xls_Contact.[E-Mail Address] as [SAP Partner Manager Email], Xls_Contact.[Contact Name] as [Partner Name], Xls_Contact.[Contact E-Mail] as [Partner Email], Xls_Contact.[Contact Partner Function] as [Partner Function] FROM Xls_Contact where "+whereKey+ "like '%"+newstring+"%'",con);
        	oledbAdapter.Fill(ds);
        	oledbAdapter.Dispose();
        	
        	 	
        	}
        	dgV.DataSource= ds.Tables[0];	
        	StringBuilder sbEmail= new StringBuilder();
        	for(int i = 0 ; i<ds.Tables[0].Rows.Count;i++)
        	{
        		sbEmail.Append(ds.Tables[0].Rows[i][inputField].ToString()+";");
        	}
        	Clipboard.SetText(sbEmail.ToString());
       		con.Close();
			
		}
		
		
		
	}
}
