using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class PaymentStartegyInstallmentCol  : BaseCol
    {
        public PaymentStartegyInstallmentCol(bool blIsempty)
        {

        }
        public PaymentStartegyInstallmentCol(int intStrategyID)
        {
            PaymentStartegyInstallmentDb objDb = new PaymentStartegyInstallmentDb();
            objDb.StrategyID = intStrategyID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new PaymentStartegyInstallmentBiz(objDr));
            }
        }

        public PaymentStartegyInstallmentBiz this[int intIndex]
        {
           
            get
            {
                return (PaymentStartegyInstallmentBiz)List[intIndex];
            }
        }

        public void Add(PaymentStartegyInstallmentBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
