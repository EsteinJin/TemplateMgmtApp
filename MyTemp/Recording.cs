using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WMEncoderLib;



namespace MyTemp
{
	/// <summary>
	/// Description of Recording.
	/// </summary>
	public class Recording
	{
		private System.ComponentModel.Container components = null;
		SqlHelper sqlhelper= new SqlHelper();
		public Recording()
		{
			
		}
		
			

		WMEncoder Encoder =null;
		string outputPath ="";
		string strFolderPath="";
		
		public void stopCapture()
		{
			Encoder.Stop();
			
		}
		
		public void PauseCapture()
		{
			Encoder.Pause();
			
		}
		
		public void CaptureScreen() 
		{ 
            Encoder = new WMEncoder();
    
			
			outputPath= @strFolderPath+@"C:\MyData\Captures\MyCaptures.wmv";
			IWMEncSourceGroup2 SrcGrp; 
			IWMEncSourceGroupCollection SrcGrpColl; 
			SrcGrpColl = Encoder.SourceGroupCollection; 
			SrcGrp = (IWMEncSourceGroup2)SrcGrpColl.Add ("SG_1"); 
			IWMEncVideoSource2 SrcVid; 
			//IWMEncAudioSource SrcAud; 
			IWMEncSource SrcAud;
			SrcVid = (IWMEncVideoSource2)SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO); 
			SrcAud = (IWMEncSource) SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO); 
			SrcVid.SetInput("ScreenCapture1","ScreenCap",""); 
			SrcAud.SetInput("Default_Audio_Device","Device", ""); 
			
			
			IWMEncProfileCollection ProColl; 
			IWMEncProfile Pro; 
			int i; 
			long lLength; 
			ProColl = Encoder.ProfileCollection; 
			lLength = ProColl.Count; 
			  for( i = 0 ; i < lLength - 1; i++)
            Console.WriteLine (ProColl.Item(i).Name);
        

			for (i = 0; i <= lLength - 1; i++) 
			{ 
				Pro = ProColl.Item(i); 
				if (Pro.Name == "Screen Video/Audio High (CBR)") 
				{ 
					SrcGrp.set_Profile((IWMEncProfile) Pro); 
					break; 
				} 
			} 
			IWMEncDisplayInfo Descr; 
			Descr = Encoder.DisplayInfo; 
			Descr.Author = "Stein.Jin"; 
			Descr.Copyright = "Copyright information"; 
			Descr.Description = "Text description of encoded content"; 
			Descr.Rating = "Rating information"; 
			Descr.Title = "Title of encoded content"; 
			IWMEncAttributes Attr; 
			Attr = Encoder.Attributes; 
			Attr.Add("URL", "www.google.com"); 
			IWMEncFile File; 
			File = Encoder.File; 
			File.LocalFileName = outputPath; 
			SrcVid.CroppingBottomMargin = 2; 
			SrcVid.CroppingTopMargin = 2; 
			SrcVid.CroppingLeftMargin = 2; 
			SrcVid.CroppingRightMargin = 2; 
            Encoder.PrepareToEncode(true);
			Encoder.Start(); 
		}
		
	}
}
