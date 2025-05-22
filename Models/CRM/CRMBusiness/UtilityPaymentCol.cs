using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class UtilityPaymentCol : BaseCol
    {
        public UtilityPaymentCol(bool blIsempty)
        {

        }
        public UtilityPaymentCol(int intID)
        {
            UtilityPaymentDb objDb = new UtilityPaymentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UtilityPaymentBiz(objDr));
            }
        }
       

        public UtilityPaymentBiz this[int intIndex]
        {
           
            get
            {
                return (UtilityPaymentBiz)List[intIndex];
            }
        }
        public double Value
        {
            get
            {
                double Returned = 0;
                foreach (UtilityPaymentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public void Add(UtilityPaymentBiz objBiz)
        {
            List.Add(objBiz);
 
        }

       
    }
}
