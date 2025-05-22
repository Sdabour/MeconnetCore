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
    class TransactionCheckTransfereCol : BaseCol
    {
        public TransactionCheckTransfereCol(bool blIsempty)
        {

        }
        public TransactionCheckTransfereCol(int intID)
        {
            TransactionCheckTransfereDb objDb = new TransactionCheckTransfereDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCheckTransfereBiz(objDr));
            }
        }

        public TransactionCheckTransfereBiz this[int intIndex]
        {

            get
            {
                return (TransactionCheckTransfereBiz)List[intIndex];
            }
        }

        public void Add(TransactionCheckTransfereBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
