using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpVision.UMS.UMSBusiness
{
    static class UMSData
    {
        #region Static CommonFunction
        public static string ReplaceStringComp(string strName)
        {
            string Str = "";
            try
            {
                Str = strName;
                Str = Str.Trim();
                Str = Str.Replace("أ", "ا");
                Str = Str.Replace("إ", "ا");
                Str = Str.Replace("آ", "ا");
                Str = Str.Replace("ة", "ه");
                Str = Str.Replace("ى", "ي");
                Str = Str.Replace("ابو ", "ابو");
                Str = Str.Replace("عبد ", "عبد");
                Str = Str.Replace("ابي ", "ابي");
                Str = Str.Replace("ابا ", "ابا");
                Str = Str.Replace("ابن ", "ابن");
                Str = Str.Replace("بن ", "بن");
                Str = Str.Replace("بنت ", "بنت");
                Str = Str.Replace("بو ", "بو");
                Str = Str.Replace("عبيد ", "عبيد");
                //Str = Str.Replace(Chr(13), " ");
                //Str = Str.Replace(Chr(10), "");
                Str = Str.Replace("  ", " ");
                Str = Str.Replace(" ", "");
                //Str = Str.Replace(vbTab, " ");

            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
            return Str;
        }
        public static bool CheckUmsStr(this string strMain, string strSub)
        {
            bool Returned = true;
            string[] arrStr = strSub.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (string strTemp in arrStr)
            {
                if (ReplaceStringComp(strMain.ToLower()).IndexOf(ReplaceStringComp(strTemp.ToLower())) == -1)
                    blIsFound = false;
            }
            if (!blIsFound)
                Returned = false;
            return blIsFound;
        }
        #endregion
    
}
}
