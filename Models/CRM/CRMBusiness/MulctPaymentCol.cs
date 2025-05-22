using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class MulctPaymentCol :BaseCol
    {

        public MulctPaymentCol(bool blIsempty)
        {
          
            //MulctPaymentDb objDb = new MulctPaymentDb();
            //DataTable dtTemp = objDb.Search();
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    Add(new MulctPaymentBiz(objDr));
            //}
        }
        public MulctPaymentCol(int intID)
        {
            MulctPaymentDb objDb = new MulctPaymentDb();
            objDb.Reservation = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new MulctPaymentBiz(objDr));
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (MulctPaymentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.Value;

                }
                return Returned;
            }
        }
        public MulctPaymentBiz this[int intIndex]
        {

            get
            {
                return (MulctPaymentBiz)List[intIndex];
            }
        }

        public void Add(MulctPaymentBiz objBiz)
        {
            List.Add(objBiz);

        }

    }
}
