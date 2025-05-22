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
    public class TransactionCacheDepositCol : BaseCol
    {
        public TransactionCacheDepositCol(bool blIsempty)
        {

        }
        public TransactionCacheDepositCol(int intID)
        {
            TransactionCacheDepositDb objDb = new TransactionCacheDepositDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCacheDepositBiz(objDr));
            }
        }

        public TransactionCacheDepositBiz this[int intIndex]
        {

            get
            {
                return (TransactionCacheDepositBiz)List[intIndex];
            }
        }

        public void Add(TransactionCacheDepositBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
