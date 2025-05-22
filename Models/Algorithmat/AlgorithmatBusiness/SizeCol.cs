using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;



namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class SizeCol : BaseCol
    {
        public SizeCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            SizeBiz objBiz = new SizeBiz();
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            SizeDb objDb = new SizeDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SizeBiz(objDr));
            }
        }
        public SizeCol()
        {
            SizeDb objDb = new SizeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SizeBiz(objDr));
            }
        }

        public SizeBiz this[int intIndex]
        {

            get
            {
                return (SizeBiz)List[intIndex];
            }
        }
        public void Add(SizeBiz objBiz)
        {
            List.Add(objBiz);

        }
        public SizeCol GetCol(string strName)
        {
            SizeCol Returned = new SizeCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (SizeBiz objBiz in this)
            {
                blIsOk = true;
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
        public SizeCol Copy()
        {
            SizeCol Returned = new SizeCol(true);
            foreach (SizeBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
    }
}
