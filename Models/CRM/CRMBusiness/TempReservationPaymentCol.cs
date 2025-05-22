using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class TempReservationPaymentCol : BaseCol
    {
        public TempReservationPaymentCol(bool blIsempty)
        {

        }
       

        public TempReservationPaymentBiz this[int intIndex]
        {
           
            get
            {
                return (TempReservationPaymentBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (TempReservationPaymentBiz objBiz in this)
                {
                     Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double PreContractingTotalValue
        {
            get
            {
                double Returned = 0;
                foreach (TempReservationPaymentBiz objBiz in this)
                {
                    if(!objBiz.ReservationBiz.IsContracted || objBiz.Date <= objBiz.ReservationBiz.ContractingDate.AddDays(20))
                    Returned += objBiz.Value;

                }
                return Returned;
            }
        }
        public double AfterContractingTotalValue
        {
            get
            {
                double Returned = 0;
                foreach (TempReservationPaymentBiz objBiz in this)
                {
                    
                    if (objBiz.ReservationBiz.IsContracted && objBiz.Date > objBiz.ReservationBiz.ContractingDate.AddDays(20))
                        Returned += objBiz.Value;

                }
                return Returned;
            }
        }
        public TempReservationPaymentBiz  LastPaymentBiz
        {
            get
            {
                TempReservationPaymentBiz Returned = new TempReservationPaymentBiz();
                foreach (TempReservationPaymentBiz objBiz in this)
                {
                    if (Returned.ID == 0 || Returned.Date < objBiz.Date)
                    {
                        Returned = objBiz;
                    }
                }
                return Returned;
            }
    }
        public void Scheduled()
        {
            foreach (TempReservationPaymentBiz objBiz in this)
            {
                if (!objBiz.Scheduled)
                    objBiz.Schedul();
            }
        }
        public void Add(TempReservationPaymentBiz objBiz)
        {
            List.Add(objBiz);
 
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("TempPayment");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("PaymentID"), new DataColumn("ReservationID"), new DataColumn("PaymentDesc"), 
                new DataColumn("PaymentDate"), new DataColumn("TempPaymentSubDesc"),
                new DataColumn("PaymentValue"), new DataColumn("Scheduled"), new DataColumn("PaymentType"), 
                new DataColumn("GLTransaction"), new DataColumn("PaymentCurrency"), new DataColumn("PaymentCurrencyValue"),
                new DataColumn("PaymentApplicantID"),new DataColumn("PaymentBranchID"),new DataColumn("PaymentCofferID") });
            DataRow objDr;
            foreach (TempReservationPaymentBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();
                objBiz.GetData();
                objDr["PaymentID"] = objBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["PaymentDesc"] = objBiz.Desc;
                objDr["TempPaymentSubDesc"] = objBiz.SubDesc;
                objDr["PaymentDate"] = objBiz.Date;
                objDr["PaymentValue"] = objBiz.Value;
                objDr["PaymentType"] = (int)objBiz.Type;
                objDr["Scheduled"] = objBiz.Scheduled;
                objDr["GLTransaction"] = objBiz.GLTransaction;
                objDr["PaymentCurrency"] = objBiz.Currency;
                objDr["PaymentCurrencyValue"] = objBiz.CurrencyValue;
                objDr["PaymentApplicantID"] = objBiz.EmployeeID;
                objDr["PaymentBranchID"] = objBiz.BranchID;
                objDr["PaymentCofferID"] = objBiz.CofferBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
    }
}