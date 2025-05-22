using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
namespace SharpVision.UMS.UMSDataBase 
{
    class SysCryptography
    {
        private static int[] _Codes;
        public SysCryptography()
        {
        }
        internal static bool EncryptByteStream(byte[] InStream, byte[] OutStream)
        {
            return DecryptEncrypt(InStream, ref OutStream);
        }
        internal static bool DecryptByteStream(byte[] InStream, ref byte[] OutStream)
        {
            return DecryptEncrypt(InStream, ref OutStream);
        }
        private static bool DecryptEncrypt(byte[] InStream, ref byte[] OutStream)
        {
            bool blReturned = false;
            try
            {
                if (_Codes == null || _Codes.Length == 0)
                    SetCodes();
                int intCodesLength = _Codes.Length;
                int intArrIndex;
                for (int i = 0; i < InStream.Length; i++)
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

        

        internal static void SetCodes()
        {
            _Codes = new int[256];
            for (int i = 0; i < 256; i++)
                _Codes[i] = i;
        }
        internal static string EncryptDecryptStr(string strText)
        {

            byte[] arrByte = System.Text.Encoding.ASCII.GetBytes(strText);
            DecryptEncrypt(arrByte, ref arrByte);
            string strReturned = System.Text.Encoding.UTF8.GetString(arrByte);
            return strReturned;

        }

    }
}
