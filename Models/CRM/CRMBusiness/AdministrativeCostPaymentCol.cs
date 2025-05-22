using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class AdministrativeCostPaymentCol : BaseCol
    {
        public AdministrativeCostPaymentCol(bool blIsempty)
        {

        }


        public AdministrativeCostPaymentBiz this[int intIndex]
        {

            get
            {
                return (AdministrativeCostPaymentBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (AdministrativeCostPaymentBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        
        public void Add(AdministrativeCostPaymentBiz objBiz)
        {
            List.Add(objBiz);

        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("TempPayment");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("PaymentID"), new DataColumn("ReservationID"),new DataColumn("CostType"), new DataColumn("PaymentDesc"), new DataColumn("PaymentDate"),
                new DataColumn("PaymentValue"), new DataColumn("Scheduled"), new DataColumn("PaymentType"), 
                new DataColumn("GLTransaction"), new DataColumn("PaymentCurrency"), new DataColumn("PaymentCurrencyValue"),
                new DataColumn("PaymentApplicantID"),new DataColumn("PaymentBranchID"),new DataColumn("PaymentCofferID")  });
            DataRow objDr;
            foreach (AdministrativeCostPaymentBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();
                objBiz.GetData();
                objDr["PaymentID"] = objBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["PaymentDesc"] = objBiz.Desc;
                objDr["PaymentDate"] = objBiz.Date;
                objDr["PaymentValue"] = objBiz.Value;
                objDr["PaymentType"] = (int)objBiz.Type;
                
                objDr["GLTransaction"] = objBiz.GLTransaction;
                objDr["PaymentCurrency"] = objBiz.Currency;
                objDr["PaymentCurrencyValue"] = objBiz.CurrencyValue;
                objDr["CostType"] = objBiz.TypeBiz.ID;
                objDr["PaymentApplicantID"] = objBiz.EmployeeID;
                objDr["PaymentBranchID"] = objBiz.BranchID;
                objDr["PaymentCofferID"] = objBiz.CofferBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
    }
}