using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public class TransactionCheckPaymentCol : BaseCol
    {

        public TransactionCheckPaymentCol(bool blIsEmpty)
        {
 
        }
        public TransactionCheckPaymentCol(int intID)
        {
            TransactionCheckPaymentDb objDb = new TransactionCheckPaymentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TransactionCheckPaymentBiz(objDr));
            }
        }


        public TransactionCheckPaymentBiz this[int intIndex]
        {

            get
            {
                return (TransactionCheckPaymentBiz)List[intIndex];
            }
        }

        public void Add(TransactionCheckPaymentBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
