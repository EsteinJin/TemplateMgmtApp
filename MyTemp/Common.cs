/*
 * Created by SharpDevelop.
 * User: I301354
 * Date: 2013/12/19
 * Time: 18:27
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
	/// Description of Common.
	/// </summary>
	public class Common
	{
		
		public Common()
		{
		}
		string strURL;
    	string strFolderPath;
    	string strTransPath;
    	string strPW;
    	SqlHelper sqlhelper= new SqlHelper();
   
    	public string keyToWords(string e)
		{
			switch (e) {
			case "81,Q,0" :
					return "Q";
					break;
			case "87,W,0" :
					return "W";
					break;

			case "69,E,0" :
					return "E";
					break;					
					

			case "82,R,0" :
					return "R";
					break;					

			case "84,T,0" :
					return "T";
					break;					
			
			case "89,Y,0" :
					return "Y";
					break;					

			case "85,U,0" :
					return "U";
					break;					
					
			case "73,I,0" :
					return "I";
					break;					

			case "79,O,0" :
					return "O";
					break;					
					
			case "80,P,0" :
					return "P";
					break;					
					
			case "65,A,0" :
					return "A";
					break;					

			case "83,S,0" :
					return "S";
					break;					
					
			case "68,D,0" :
					return "D";
					break;					

			case "70,F,0" :
					return "F";
					break;					

			case "71,G,0" :
					return "G";
					break;					

			case "72,H,0" :
					return "H";
					break;					


			case "74,J,0" :
					return "J";
					break;					

			case "75,K,0" :
					return "K";
					break;					


			case "76,L,0" :
					return "L";
					break;					


			case "90,Z,0" :
					return "Z";
					break;					

					
			case "88,X,0" :
					return "X";
					break;					
					

			case "67,C,0" :
					return "C";
					break;					


			case "86,V,0" :
					return "V";
					break;					

			case "66,B,0" :
					return "B";
					break;					


			case "78,N,0" :
					return "N";
					break;					


			case "77,M,0" :
					return "M";
					break;					


			case "49,D1,0" :
					return "1";
					break;					


			case "50,D2,0" :
					return "2";
					break;					


			case "51,D3,0" :
					return "3";
					break;					


			case "52,D4,0" :
					return "4";
					break;					


			case "53,D5,0" :
					return "5";
					break;					


			case "54,D6,0" :
					return "6";
					break;					


			case "55,D7,0" :
					return "7";
					break;					


			case "56,D8,0" :
					return "8";
					break;					

			case "57,D9,0" :
					return "9";
					break;					


			case "48,D0,0" :
					return "0";
					break;					

			case "8,Back,0" :
					return "Back";
					break;					
					
//			case "162,LControlKey,0" :
//					return "LControlKey";
//					break;					
//
//			case "160,LShiftKey,0" :
//					return "LShiftKey";
//					break;	
//
//
//			case "37,Left,1" :
//					return "LeftKey";
//					break;	
					
					
				default:
					return "Back";
					break;
			}
		}
	

		
		

			
			
		
	}
}
