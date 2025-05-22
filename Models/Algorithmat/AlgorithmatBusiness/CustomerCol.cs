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
    public class CustomerCol : BaseCol
    {
        public CustomerCol(bool blIsempty)
        {
            if (blIsempty)
                return;
          
        }
        public CustomerCol()
        {
            CustomerDb objDb = new CustomerDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CustomerBiz(objDr));
            }
        }

        public CustomerBiz this[int intIndex]
        {

            get
            {
                return (CustomerBiz)List[intIndex];
            }
        }
        public void Add(CustomerBiz objBiz)
        {
            List.Add(objBiz);

        }
        public CustomerCol GetCol(string strName)
        {
            CustomerCol Returned = new CustomerCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (CustomerBiz objBiz in this)
            {
                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Mail).
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1 )
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
        public CustomerCol Copy()
        {
            CustomerCol Returned = new CustomerCol(true);
            foreach (CustomerBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;

        }
    }
}
