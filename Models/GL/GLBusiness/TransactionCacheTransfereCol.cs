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
    public class TransactionCacheTransfereCol : BaseCol
    {
        public TransactionCacheTransfereCol(bool blIsempty)
        {

        }
        public TransactionCacheTransfereCol(int intID)
        {
            TransactionCacheTransfereDb objDb = new TransactionCacheTransfereDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCacheTransfereBiz(objDr));
            }
        }

        public TransactionCacheTransfereBiz this[int intIndex]
        {

            get
            {
                return (TransactionCacheTransfereBiz)List[intIndex];
            }
        }

        public void Add(TransactionCacheTransfereBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
