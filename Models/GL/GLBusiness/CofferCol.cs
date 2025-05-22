using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class CofferCol : BaseCol
    {
        public CofferCol(bool blIsempty,int intIsBankStatus)
        {
            if (blIsempty)
                return;
            CofferBiz objBiz = new CofferBiz();
            objBiz.NameA =  "€Ì— „Õœœ";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            CofferDB objDb = new CofferDB();
            objDb.IsBankStatus = intIsBankStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CofferBiz(objDr));
            }
        }
        public CofferCol()
        {
            CofferDB objDb = new CofferDB();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CofferBiz(objDr));
            }
        }
        public CofferCol(int intID)
        {
            CofferDB objDb = new CofferDB();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CofferBiz(objDr));
            }
        }
        public CofferBiz this[int intIndex]
        {

            get
            {
                return (CofferBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CofferBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();

                }
                return Returned;
            }
        }
        public CofferCol MainCofferCol
        {
            get
            {
                CofferCol Returned = new CofferCol(true,2);
                foreach (CofferBiz objBiz in this)
                {
                    if (objBiz.IsMain)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        static CofferCol _CacheCofferCol;
        public static CofferCol CacheCofferCol
        {
            get
            {
                if (_CacheCofferCol == null)
                    _CacheCofferCol = new CofferCol(false,0);
                return _CacheCofferCol;

            }
        }
        public void Add(CofferBiz objBiz)
        {
            List.Add(objBiz);

        }
        public CofferCol GetCol(string strName)
        {
            CofferCol Returned = new CofferCol(true, 0);
            string[] arrStr = strName.Split('%');
            bool blIsOk = true;
            foreach (CofferBiz objBiz in this)
            {
                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Name).
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.Code).
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1)
                    {
                        blIsOk = false;
                        break;
                    }

                }
                if (blIsOk)
                    Returned.Add(objBiz);
            }
            return Returned;

        }
        public CofferCol Copy()
        {
            CofferCol Returned = new CofferCol(true,0);
            foreach (CofferBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
