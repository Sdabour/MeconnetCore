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
    public class CompanyCol : BaseCol
    {
        public CompanyCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            CompanyBiz objBiz = new CompanyBiz();
            objBiz.NameA =  "€Ì— „Õœœ";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            CompanyDB objDb = new CompanyDB();
          
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompanyBiz(objDr));
            }
        }
        public CompanyCol()
        {
            CompanyDB objDb = new CompanyDB();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompanyBiz(objDr));
            }
        }
       
        public CompanyBiz this[int intIndex]
        {

            get
            {
                return (CompanyBiz)List[intIndex];
            }
        }
        public void Add(CompanyBiz objBiz)
        {
            List.Add(objBiz);

        }
        public CompanyCol GetCol(string strName)
        {
            CompanyCol Returned = new CompanyCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (CompanyBiz objBiz in this)
            {

                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Name).
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1 &&
                        objBiz.Code.
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
    }
}
