using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.Base.BaseDataBase
{
    public abstract class BaseSingleDb
    {
        #region Protected Data
        static int _Language;
        protected int _ID;
        protected string _NameA;
        protected string _NameE;
        protected string _Code;
        #endregion
        #region Public Properties
        public virtual int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public virtual string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        public virtual string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
            }
        }
        public virtual string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public virtual string Name
        {
            get
            {
                return _Language == 0 && _NameA != null && _NameA!= "" ? _NameA : 
                    ( _NameE != null && _NameE!= "" ? _NameE:_NameA);
            }
        }

        public static int Language
        {
            set
            {
                _Language = value;
            }
            get
            {
                return _Language;
            }
        }
        #endregion
        #region Pure Functions
        public abstract void Add();
        public abstract void Edit();
        public abstract void Delete();
        public abstract DataTable Search();
        public static List<string> GetStringArr(DataTable dtTemp, string strFieldName, int intCount)
        {

            List<string> Returned = new List<string>();
            int intIndex = 0;

            Returned.Add("");

            DataRow[] arrDr = dtTemp.Select("", strFieldName);
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
        #endregion

    }
}
