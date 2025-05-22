
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;

namespace SharpVision.SystemBase
{
	/// <summary>
	/// Summary description for SysCryptography.
	/// </summary>
	public class SysCryptography
	{
		private static int[] _Codes  ;
		public SysCryptography()
		{
		}
		public static bool EncryptByteStream(byte[] InStream,byte[] OutStream)
		{
			return DecryptEncrypt(InStream,ref OutStream);
		}
		public static bool DecryptByteStream(byte[] InStream,ref byte[] OutStream)
		{
			return DecryptEncrypt(InStream,ref OutStream);
		}
		private  static bool DecryptEncrypt(byte[] InStream,ref byte[] OutStream)
		{
            if (OutStream == null)
                OutStream = new byte[InStream.Length];
			bool blReturned = false;
			try
			{
				if (_Codes == null || _Codes.Length ==0)
					SetCodes();
				int intCodesLength = _Codes.Length;
				int intArrIndex;
				for(int i = 0; i<InStream.Length;i++)
				{
					intArrIndex = i % intCodesLength;
					OutStream[i] = (byte)(InStream[i] ^ _Codes[intArrIndex]);
				}
				blReturned = true;
			}
			catch
			{
				blReturned = false;
			}
			return blReturned;
		}
	
        //public static bool ConvertImageToByteArray(string ImagePath,ref byte[] OutByte)
        //{
        //    bool blRerturned = false;
        //    try
        //    {
        //        Image tempImage = Image.FromFile(ImagePath);
        //        MemoryStream tempMs = new MemoryStream();
        //        tempImage.Save(tempMs,ImageFormat.Jpeg);
        //        OutByte = tempMs.ToArray();
        //        blRerturned = true;
        //    }
        //    catch
        //    {
				
        //    }
        //    return blRerturned;
            
        //}
        public static bool ConvertImageToByteArray(string ImagePath, ref byte[] OutByteArray)
        {
            bool blReterned = false;
            try
            {
                Image tempImage = Image.FromFile(ImagePath);
                MemoryStream tempMs = new MemoryStream();
                tempImage.Save(tempMs, ImageFormat.Jpeg);
                OutByteArray = tempMs.ToArray();
                blReterned = true;

            }
            catch
            { 

            }
            return blReterned;
        }

       	public static void SetCodes()
		{
			_Codes = new int[256];
			for(int i = 0;i<256;i++)
				_Codes[i] = i;
		}
		public static string EncryptDecryptStr(string strText)
		{
            if (strText == null || strText == "")
                return "";
			byte [] arrByte = System.Text.Encoding.ASCII.GetBytes(strText);
			DecryptEncrypt(arrByte,ref arrByte);
			string strReturned = System.Text.Encoding.UTF8.GetString(arrByte);
            return strReturned;

		}

}
}
