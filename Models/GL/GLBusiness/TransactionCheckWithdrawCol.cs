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
    public class TransactionCheckWithdrawCol : BaseCol
    {
        public TransactionCheckWithdrawCol(bool blIsempty)
        {

        }
        public TransactionCheckWithdrawCol(int intID)
        {
            TransactionCheckWithdrawDb objDb = new TransactionCheckWithdrawDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCheckWithdrawBiz(objDr));
            }
        }

        public TransactionCheckWithdrawBiz this[int intIndex]
        {

            get
            {
                return (TransactionCheckWithdrawBiz)List[intIndex];
            }
        }

        public void Add(TransactionCheckWithdrawBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
