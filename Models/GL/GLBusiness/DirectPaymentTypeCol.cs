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
    public class DirectPaymentTypeCol : BaseCol
    {
        public DirectPaymentTypeCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            DirectPaymentTypeBiz objBiz = new DirectPaymentTypeBiz();
            objBiz.NameA = "€Ì— „Õœœ";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            DirectPaymentTypeDB objDb = new DirectPaymentTypeDB();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new DirectPaymentTypeBiz(objDr));
            }
        }
        public DirectPaymentTypeCol()
        {
            DirectPaymentTypeDB objDb = new DirectPaymentTypeDB();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new DirectPaymentTypeBiz(objDr));
            }
        }

        public DirectPaymentTypeBiz this[int intIndex]
        {

            get
            {
                return (DirectPaymentTypeBiz)List[intIndex];
            }
        }
        public void Add(DirectPaymentTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
        public DirectPaymentTypeCol GetCol(string strName)
        {
            DirectPaymentTypeCol Returned = new DirectPaymentTypeCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (DirectPaymentTypeBiz objBiz in this)
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
        public DirectPaymentTypeBiz GetTypeByName(string strName)
        {
            DirectPaymentTypeBiz Returned = new DirectPaymentTypeBiz();
            foreach (DirectPaymentTypeBiz objBiz in this)
            {
                if (objBiz.Name == strName)
                    return objBiz;
            }
            return Returned;
        }
        public DirectPaymentTypeCol Copy()
        {
            DirectPaymentTypeCol Returned = new DirectPaymentTypeCol(true);
            foreach (DirectPaymentTypeBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
    }
}
