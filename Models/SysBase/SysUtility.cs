using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Net;
namespace SharpVision.SystemBase
{
     

    public enum ApproximateType
    {
        Default,
        Up,
        Down
    }
    public static class SysUtility
    {
        #region Private Data
        private static string[] ahad = { "", "Ê«Õœ", "≈À‰Ì‰", "À·«À…", "√—»⁄…", "Œ„”…", "” …", "”»⁄…", " À„«‰Ì…", "  ”⁄…", " ⁄‘—…", " √Õœ", " «À‰Ï" };
        private static string[] ahad2 = { "", "Ê«Õœ", "≈À‰Ì‰", "À·«À…", "√—»⁄…", "Œ„”…", "” …", "”»⁄…", "À„«‰Ì…", " ”⁄…", " ⁄‘—", " √Õœ", " «À‰Ï" };
        private static string[] asharat = { "", "Ê«Õœ", "⁄‘—Ê‰", "À·«ÀÊ‰", "√—»⁄Ê‰", "Œ„”Ê‰", "” Ê‰", "”»⁄Ê‰", "À„«‰Ê‰", " ”⁄Ê‰" };
        private static string[] meat = { "", "„«∆…", "„«∆ Ì‰", "À·«À„«∆…", "√—»⁄„«∆…", "Œ„”„«∆…", "” „«∆…", "”»⁄„«∆…", "À„«‰„«∆…", " ”⁄„«∆…" };
        private static string[] melion = { "", " „·ÌÊ‰", " „·ÌÊ‰«‰", " „·«ÌÌ‰" };
        private static string[] alf = { "", " √·›", " √·›Ì‰", " ¬·«›" };
        //private static string[] bcur = { " Ã‰ÌÂ", " Ã‰ÌÂ«‰", " Ã‰ÌÂ« " };
        private static string[] bcur = { " Ã‰ÌÂ „’—Ï", " Ã‰ÌÂ«‰", " Ã‰ÌÂ« " };
        #endregion

        public static string[] GetRelativeStrings(string strTemp)
        {
            if (strTemp == null || strTemp == "")
                return new string[0];
            string[] Returned;
            string[] arrTemp;
            arrTemp = strTemp.Split(' ');
            Returned = new string[arrTemp.Length];
            string strReturned = "";
            for (int intIndex = Returned.Length - 1; intIndex >= 0; intIndex--)
            {
                if(strReturned != "")
                    strReturned = strReturned + " ";
                strReturned = strReturned + arrTemp[Returned.Length -1 - intIndex];
                Returned[intIndex] = strReturned;
 
            }
            return Returned;

        }
        public static bool CheckForArabicAndNumeric(int intAscii)
        {
            if (intAscii < 128 && intAscii != 32 && intAscii != 8 && !(intAscii <= 57 && intAscii >= 48))
            {
                return false;
            }
             return true;
        }
        public static bool CheckForEnglishAndNumeric(int intAscii)
        {
            if (intAscii > 128 && intAscii != 32 && intAscii != 8 && !(intAscii <= 57 && intAscii >= 48))
            {
                return false;
            }
            return true;
        }
        public static bool CheckForNumeric(int intAscii)
        {
            if (intAscii != 8 && intAscii != 46 && !(intAscii <= 57 && intAscii >= 48))
            {
                return false;
            }
            return true;
        }
        public static bool CheckForNumeric(int intAscii,string strText)
        {
            if (intAscii != 8 && intAscii != 46 && !(intAscii <= 57 && intAscii >= 48) && intAscii != 45)
            {
                return false;
            }
            if (intAscii == 46 && strText.IndexOf(".") >= 0)
                return false;
            if (intAscii == 45 && strText.IndexOf("-") >= 0)
                return false;
            return true;
        }
        public static double Approximate(double dblValue, double dblApprox)
        {
            double Returned = dblValue;
            if (dblApprox != 0)
            {
                Returned = dblValue % dblApprox;
                if (dblApprox - Returned > Returned)
                    Returned = dblValue - Returned;
                else
                    Returned = dblValue - Returned + dblApprox;
            }
            return Returned;
        }
        public static double Approximate(double dblValue, double dblApprox,ApproximateType objApproximateType)
        {
            double Returned = dblValue;
            if (dblApprox != 0)
            {
                Returned = dblValue % dblApprox;
                if (objApproximateType == ApproximateType.Default)
                {
                    if (dblApprox - Returned > Returned)
                        Returned = dblValue - Returned;
                    else
                        Returned = dblValue - Returned + dblApprox;
                }
                else
                {
                    if (objApproximateType == ApproximateType.Down)
                        Returned = dblValue - Returned;
                    else
                        Returned = dblValue - Returned + dblApprox;
                }
            }
            return Returned;
        }
        public static string ReplaceStringComp(string strName)
        {
            if (strName == null)
                strName = "";
            string Str = "";
            try
            {
                Str = strName;
                Str = Str.Trim();
                Str = Str.Replace("√", "«");
                Str = Str.Replace("≈", "«");
                Str = Str.Replace("¬", "«");
                Str = Str.Replace("…", "Â");
                Str = Str.Replace("Ï", "Ì");
                Str = Str.Replace("«»Ê ", "«»Ê");
                Str = Str.Replace("⁄»œ ", "⁄»œ");
                Str = Str.Replace("«»Ì ", "«»Ì");
                Str = Str.Replace("«»« ", "«»«");
                Str = Str.Replace("«»‰ ", "«»‰");
                Str = Str.Replace("»‰ ", "»‰");
                Str = Str.Replace("»‰  ", "»‰ ");
                Str = Str.Replace("»Ê ", "»Ê");
                Str = Str.Replace("⁄»Ìœ ", "⁄»Ìœ");
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
        public static string ReplaceStringEComp(string strName)
        {
            string Str = "";
            try
            {
                Str = strName;
                Str = Str.Trim();                
                Str = Str.Replace("  ", " ");
                Str = Str.Replace(" ", "");                
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
            return Str;
        }
        public static List<string> GetStringArr(System.Data.DataTable dtTemp,string strFieldName,int intCount)
        {

            List<string> Returned = new List<string>();
            int intIndex = 0;
           
            Returned.Add("");
        
             DataRow[] arrDr = dtTemp.Select("", strFieldName);
            string strSelected = "";
            foreach (DataRow objDr in arrDr)
            {
                if (strSelected != objDr[strFieldName].ToString() &&
                    objDr[strFieldName].ToString() != "" && objDr[strFieldName].ToString()!= "0")
                {
                    strSelected = objDr[strFieldName].ToString();
                    intIndex++;
                    if (Returned[Returned.Count - 1] != "")
                        Returned[Returned.Count - 1] += ",";
                    Returned[Returned.Count - 1] += objDr[strFieldName].ToString();
                    if (intIndex > intCount)
                    {
                        Returned.Add("");
                        intIndex = 0;

                    }
                }


            }
            if (Returned.Count > 0 && Returned[Returned.Count - 1] == "")
                Returned.RemoveAt(Returned.Count - 1);

            return Returned;
 
        }
        public static List<string> GetStringArr(string strNative,char chrSeparator, int intCount)
        {

            List<string> Returned = new List<string>();
            if (strNative == null || strNative == "")
                return Returned;

            int intIndex = 0;


            Returned.Add("");
            string[] arrStr = strNative.Split(chrSeparator);

            string strSelected = "";
            foreach (string strTemp in arrStr)
            {
                if (strSelected != strTemp &&
                   strTemp != "" &&strTemp != "0")
                {
                    strSelected =strTemp;
                    intIndex++;
                    if (Returned[Returned.Count - 1] != "")
                        Returned[Returned.Count - 1] += ",";
                    Returned[Returned.Count - 1] +=strTemp;
                    if (intIndex > intCount)
                    {
                        Returned.Add("");
                        intIndex = 0;

                    }
                }


            }
            if (Returned.Count > 0 && Returned[Returned.Count - 1] == "")
                Returned.RemoveAt(Returned.Count - 1);

            return Returned;

        }
        public static List<string> GetStringArrForMultiple(System.Data.DataTable dtTemp, string strFieldName, int intCount)
        {
            System.Collections.Hashtable hsTemp = new System.Collections.Hashtable();
            List<string> Returned = new List<string>();
            if (dtTemp == null || strFieldName==null || strFieldName == "" )
                return Returned ;
            int intIndex = 0;

            Returned.Add("");
            string [] arrFeild = strFieldName.Split(",".ToCharArray());
           DataRow[] arrDr ;//= dtTemp.Select("", strFieldName);
            string strSelected = "";
      
               // arrDr = dtTemp.Select("", strTempField);
                strSelected = "";
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    foreach (string strTempField in arrFeild)
                    {
                        if (objDr[strTempField].ToString() == "")
                            continue;
                        if (hsTemp[objDr[strTempField].ToString()]==null)
                        {
                            hsTemp.Add(objDr[strTempField].ToString(), objDr[strTempField].ToString());
                         //   strSelected = objDr[strFieldName].ToString();
                            intIndex++;

                            if (Returned[Returned.Count - 1] != "")
                                Returned[Returned.Count - 1] += ",";
                            Returned[Returned.Count - 1] += objDr[strTempField].ToString();
                            if (intIndex > intCount)
                            {
                                Returned.Add("");
                                intIndex = 0;

                            }
                        }
                    }


                }
         
            if (Returned.Count > 0 && Returned[Returned.Count - 1] == "")
                Returned.RemoveAt(Returned.Count - 1);

            return Returned;

        }
        public static List<string> GetStringArr(DataRow[] arrDr, string strFieldName, int intCount)
        {

            List<string> Returned = new List<string>();
            if (arrDr == null || arrDr.Length == 0)
                return Returned;
            int intIndex = 0;

            Returned.Add("");

            //DataRow[] arrDr = dtTemp.Select("", strFieldName);
            string strSelected = "";
            foreach (DataRow objDr in arrDr)
            {
                if (strSelected != objDr[strFieldName].ToString() &&
                    objDr[strFieldName].ToString() != "" && objDr[strFieldName].ToString() != "0")
                {
                    strSelected = objDr[strFieldName].ToString();
                    intIndex++;
                    if (Returned[Returned.Count - 1] != "")
                        Returned[Returned.Count - 1] += ",";
                    Returned[Returned.Count - 1] += objDr[strFieldName].ToString();
                    if (intIndex > intCount)
                    {
                        Returned.Add("");
                        intIndex = 0;

                    }
                }


            }
            if (Returned.Count > 0 && Returned[Returned.Count - 1] == "")
                Returned.RemoveAt(Returned.Count - 1);

            return Returned;

        }
        public static void CopyTableIntoTable(System.Data.DataTable dtSource, ref System.Data.DataTable dtDist)
        {
            if (dtSource.Columns.Count != dtDist.Columns.Count)
                return;
            DataRow objNewRow;
            foreach (DataRow objDr in dtSource.Rows)
            {
                objNewRow = dtDist.NewRow();
                for (int intIndex = 0; intIndex < objDr.Table.Columns.Count; intIndex++)
                {
                    objNewRow[intIndex] = objDr[intIndex];
                }
                dtDist.Rows.Add(objNewRow);
            }


        }
        public static int GetStringIndex(string strParent, string strChild, char chrSeparetor)
        {
            char [] arrChr = new char[1];
            arrChr[0] = chrSeparetor;
            string[] arrStr = strParent.Split(arrChr);
            for (int intIndex = 0; intIndex < arrStr.Length; intIndex++)
            {
                if (arrStr[intIndex] == strChild)
                    return intIndex;
            }
            return -1;

        }
        public static string  RemoveSubString(string strParent, string strChild, char chrSeparetor)
        {
            string Returned = "";
            char[] arrChr = new char[1];
            arrChr[0] = chrSeparetor;
            string[] arrStr = strParent.Split(arrChr);
            for (int intIndex = 0; intIndex < arrStr.Length; intIndex++)
            {
                if (arrStr[intIndex] != strChild)
                {

                    if (Returned != "")
                        Returned += chrSeparetor.ToString();
                    Returned += arrStr[intIndex];
                }
            }
            return Returned;

        }
        public static System.Data.DataTable GetDataTableFromString(string strData, int intMaxLength, string strColumnName, string strTableName)
        {
            string strTemp = "";
            System.Data.DataTable dtTemp = new System.Data.DataTable(strTableName);
            dtTemp.Columns.Add(new DataColumn(strColumnName));
             strTemp = strData;
            string strSubString = "";
            int intIndex = 0;
            int intLen = intMaxLength;

            double dblArrLen = (double)strData.Length / (double)intMaxLength;
            int intArrLen =(int) Approximate(dblArrLen, 1, ApproximateType.Up);

            string[] arrStr = new string[intArrLen];
            while (strTemp != "")
            {
                if (strTemp.Length < intMaxLength)
                    intMaxLength = strTemp.Length;
                strSubString = strTemp.Substring(0, intMaxLength);
                arrStr[intIndex] = strSubString;
                strTemp = strTemp.Remove(0, intMaxLength);
                intIndex++;


            }
            DataRow objDr = dtTemp.NewRow();

            foreach (string strTemp1  in arrStr)
            {
                objDr = dtTemp.NewRow();
                objDr[strColumnName] = strTemp1;
                dtTemp.Rows.Add(objDr);
            }
            return dtTemp;

        }


        public static string NumToStr(double P_Num)
        {
            double rv;
            string accum = "";
            //«·„·«ÌÌ‰
            rv = (int)(P_Num / 1000000);

            if (rv > 2)
                accum = NumToStr1(rv, accum);

            if (rv >= 3 && rv < 10)
                accum = accum + melion[3];
            else if (rv == 2)
                accum = accum + melion[2];
            else if ((rv == 1) || (rv >= 10 && rv <= 999))
                accum = accum + melion[1];
            //«·¬·«›
            rv = P_Num - (int)(P_Num / 1000000) * 1000000;
            rv = (int)(rv / 1000);
            if ((P_Num != ((int)(P_Num / 1000000)) * 1000000) && (P_Num > 1000000))
                accum = accum + " Ê";
            if (rv > 2)
                accum = NumToStr1(rv, accum);
            if (rv >= 3 && rv < 10)
                accum = accum + alf[3];
            else if (rv == 2)
                accum = accum + alf[2];
            else if ((rv == 1) || (rv >= 10 && rv <= 999))
                accum = accum + alf[1];
            //«·»«ﬁÌ
            rv = P_Num - ((int)(P_Num / 1000)) * 1000;
            rv = (int)(rv + 0.0001);

            if ((P_Num != ((int)(P_Num / 1000)) * 1000) && (P_Num > 1000) && (rv != 0))
                accum = accum + " Ê ";

            if ((rv >= 2) && (P_Num != 2))
                accum = NumToStr1(rv, accum);

            if (P_Num > 0.999)
            {
                if ((P_Num < 11) && (rv > 2))
                    accum = accum + bcur[2];
                else if (P_Num == 2)
                    accum = accum + bcur[1];
                else
                    accum = accum + bcur[0];
            }

            //«·ﬁ—Ê‘        
            rv = P_Num - ((int)(P_Num + 0.0001)) + 0.0001;
            rv = (int)(rv * 1000);
            rv = rv / 10;

            if ((rv >= 1) && (P_Num > 0.99))
                accum = accum + " Ê";

            if (rv > 2.9)
                accum = NumToStr1(rv, accum);

            if (rv >= 1)
            {
                if ((rv == 2))
                    accum = accum + " ﬁ—‘Ì‰";
                else if ((rv < 11) && (rv > 2.9))
                    accum = accum + " ﬁ—Ê‘";
                else
                    accum = accum + " ﬁ—‘";
            }
            return accum + " ›ﬁÿ ·« €Ì— ";
        }

        private static string NumToStr1(double rv, string accum)
        {
            int b, c;
            if (rv >= 100)
            {
                b = (int)(rv / 100);
                accum = accum + meat[b];
            }

            b = (int)(rv - ((int)(rv / 100) * 100));
            if ((b != 0) && (rv > 99))
                accum = accum + " Ê";

            c = b - ((int)(b / 10) * 10);
            if ((b < 13) && (b != 0))
                accum = accum + ahad[b];

            if ((b > 12) && (c != 0))
                accum = accum + ahad2[c];
            if ((b > 10) && (b < 20))
                accum = accum + ahad2[10];

            if (b > 19)
            {
                if (c != 0)
                    accum = accum + " Ê";
                accum = accum + asharat[b / 10];
            }
            return accum;
        }
        public static string SetPadLeft(string strNo, int intLength)
        {
            string Returned = strNo;
            if (Returned.Length > intLength)
                Returned = Returned.Substring(0, intLength);
            else
            {
                int intStart = Returned.Length;
                for (int intIndex = intStart; intIndex < intLength; intIndex++)
                {
                    Returned = "0" + Returned ;
                }
            }
            return Returned;
        }
        public static string SetPadRight(string strNo, int intLength)
        {
            string Returned = strNo ;
            if (Returned.Length > intLength)
                Returned = Returned.Substring(0, intLength);
            else
            {
                int intStart = Returned.Length;
                for (int intIndex = intStart; intIndex < intLength; intIndex++)
                {
                    Returned += "0" ;
                }
            }
            return Returned;
        }
        public static string ReverseString(string strCode,char chrSplitor)
        {
            string Returned = "";

            string[] arrChr = strCode.Split(chrSplitor);
      
            for (int intIndex = arrChr.Length - 1; intIndex >= 0; intIndex--)
            {
                if (Returned != "")
                    Returned += chrSplitor.ToString();
                Returned += arrChr[intIndex] ;
            }

           
           // Returned = strCode;
            return Returned;
        }
        public static string GetSiteMap(List<string> arrURL)
        {
            string Returned = @"<?xml version='1.0' encoding='UTF-8'?>" +
               "<urlset" +
               "xmlns='http://www.sitemaps.org/schemas/sitemap/0.9'" +
               "xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
               "xsi:schemaLocation='http://www.sitemaps.org/schemas/sitemap/0.9 " +
                " http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd'>";
            foreach (string strUrl in arrURL)
            {
                Returned += GetSiteMapElement(strUrl);
            }
            Returned += " </urlset>";
            return Returned;
        }
        public static string GetHTMLStr(string strURL, string strSubTitle)
        {
            string Returned = "";
            StreamWriter objSW;
            FileStream objFs = new FileStream("Path", FileMode.Create, FileAccess.Write);
            objSW = new StreamWriter(objFs);

            string strComment = "<!--RedirectToASPX-->";

            //HttpRequest objRequest = new HttpRequest(@"E:\Work\SharpvisionLastVersion\Templates\Algorithmat\Algorithmat\Algorithmat",
            string[] arrSub = strSubTitle.Split(@"/".ToCharArray());
            int intSubLen = arrSub.Length;
            string strSubReplace = "";
            for (int intSubIndex = 0; intSubIndex < intSubLen - 1; intSubIndex++)
            {
                strSubReplace += "../";
            }

            string strRedirect = "<meta http-equiv='refresh'" +
                   " content='0; url=" + strURL + "'>";
            WebRequest objRequest = WebRequest.Create(strURL);
            objRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse objResponse = objRequest.GetResponse();
            //Stream dataStream = response.GetResponseStream();  
            Stream objStream = objResponse.GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string strResponse = objReader.ReadToEnd();
            objResponse.Close();
            objFs.Close();
            objReader.Close();

            // strResponse = strResponse.Replace(strComment, strRedirect);
            strResponse = strResponse.Replace("js/", strSubReplace + "js/");
            strResponse = strResponse.Replace("css/", strSubReplace + "css/");
            strResponse = strResponse.Replace("images/", strSubReplace + "images/");
            strResponse = strResponse.Replace(@"images\", strSubReplace + "images/");
            strResponse = strResponse.Replace("files/", strSubReplace + "files/");
            strResponse = strResponse.Replace(strSubTitle, @"/");
            Returned = strResponse;
            return Returned;
        }
        public static string GetHTMLTableFromDataTable(DataTable dtTemp)
        {
            string Returned = "";
            Returned = "<table  class='table'  style='font-size:10px;' dir='rtl'>";
            Returned += "<tbody>";
            //  Returned += "<thead style='font-size:10px;'>";
            Returned += "<tr>";
            foreach (DataColumn objColumn in dtTemp.Columns)
            {
                Returned += "<td style='white-space:nowrap;text-align:center'>" + objColumn.ColumnName + "</td>";
            }
            Returned += "</tr>";
            //Returned += "</thead>";

          //  Returned += "<tbody>";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Returned += "<tr>";
                foreach (DataColumn objColumn in dtTemp.Columns)
                {
                    Returned += "<td tyle='text-align:center'>" + objDr[objColumn.ColumnName].ToString() + "</td>";
                }
                Returned += "</tr>";
            }
            Returned += "</tbody>";
            Returned += "</table>";
            return Returned;
        }
        public static string GetSiteMapElement(string strURL)
        {
            string Returned = "<url>" +
             "<loc>" + strURL + "</loc>" +
              "</url>";
            return Returned;
        }
        public static bool CheckStr(this string strMain,string strSub)
        {
            bool Returned = true;
            string[] arrStr = strSub.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (string strTemp in arrStr)
            {
                if (ReplaceStringComp( strMain.ToLower()).IndexOf(ReplaceStringComp( strTemp.ToLower())) == -1)
                    blIsFound = false;
            }
            if (!blIsFound)
                Returned = false;
            return blIsFound;
        }
        public static DataTable GetEmptyTempForignTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PrimaryID"), new DataColumn("ForignID"), new DataColumn("UserID"), new DataColumn("TypeDsc") });
            return Returned;
        }
        public static void AddForignMultipleRow(string strTypeDesc, ref DataTable dtForign, int intForignID, List<int> lstPrimary)
        {
            DataRow objDr;
            foreach (int intPrimary in lstPrimary)
            {
                objDr = dtForign.NewRow();
                objDr["TypeDsc"] = strTypeDesc;
                objDr["PrimaryID"] = intPrimary;
                objDr["ForignID"] = intForignID;
                objDr["UserID"] = SysData.CurrentUser.ID;
                dtForign.Rows.Add(objDr);
            }
        }
        public static void SaveTempForignTable(string strTypeDesc, DataTable dtTemp)
        {
            System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "COMMONTempForign";
            SysData.SharpVisionBaseDb.ExecuteNonQuery("delete from COMMONTempForign where UserID=" + SysData.CurrentUser.ID + " and TypeDesc='" + strTypeDesc + "' ");
            objCopy.WriteToServer(dtTemp);

        }

    }
}
