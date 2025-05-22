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
    public class TransactionCheckDepositCol : BaseCol
    {
         public TransactionCheckDepositCol(bool blIsempty)
        {

        }
        public TransactionCheckDepositCol(int intID)
        {
            TransactionCheckDepositDb objDb = new TransactionCheckDepositDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCheckDepositBiz(objDr));
            }
        }

        public TransactionCheckDepositBiz this[int intIndex]
        {

            get
            {
                return (TransactionCheckDepositBiz)List[intIndex];
            }
        }

        public void Add(TransactionCheckDepositBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
