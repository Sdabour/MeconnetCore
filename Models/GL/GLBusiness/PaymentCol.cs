using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public class PaymentCol : BaseCol
    {
         public PaymentCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            PaymentDb objDb = new PaymentDb();
            //objDb.CheckID = IDataAdapter;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new PaymentBiz(objDr));
            }
        }
        public PaymentCol(int intID)
        {
            PaymentDb objDb = new PaymentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new PaymentBiz(objDr));
            }
        }
        public PaymentBiz this[int intIndex]
        {

            get
            {
                return (PaymentBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (PaymentBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalCollectedValue
        {
            get
            {
                double Returned = 0;
                foreach (PaymentBiz objBiz in this)
                {
                    if(objBiz.IsCollected)
                     Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public void Add(PaymentBiz objBiz)
        {
            List.Add(objBiz);

        }
        public int GetIndex(int intPaymentID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == intPaymentID)
                    return intIndex;
            }
            return -1;
        }
    }
}
