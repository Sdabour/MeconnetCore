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
    public class TransactionCacheWithdrawCol : BaseCol
    {
        public TransactionCacheWithdrawCol(bool blIsempty)
        {

        }
        public TransactionCacheWithdrawCol(int intID)
        {
            TransactionCacheWithdrawDb objDb = new TransactionCacheWithdrawDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCacheWithdrawBiz(objDr));
            }
        }

        public TransactionCacheWithdrawBiz this[int intIndex]
        {

            get
            {
                return (TransactionCacheWithdrawBiz)List[intIndex];
            }
        }

        public void Add(TransactionCacheWithdrawBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
