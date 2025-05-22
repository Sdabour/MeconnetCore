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
    public class SpecificCol : BaseCol
    {
        public SpecificCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            SpecificBiz objBiz = new SpecificBiz();
            objBiz.NameA = "€Ì— „Õœœ";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            SpecificDB objDb = new SpecificDB();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SpecificBiz(objDr));
            }
        }
        public SpecificCol()
        {
            SpecificDB objDb = new SpecificDB();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SpecificBiz(objDr));
            }
        }

        public SpecificBiz this[int intIndex]
        {

            get
            {
                return (SpecificBiz)List[intIndex];
            }
        }
        public void Add(SpecificBiz objBiz)
        {
            List.Add(objBiz);

        }
        public SpecificCol GetCol(string strName)
        {
            SpecificCol Returned = new SpecificCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (SpecificBiz objBiz in this)
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
        public SpecificCol Copy()
        {
            SpecificCol Returned = new SpecificCol(true);
            foreach (SpecificBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;
 
        }
    }
}
