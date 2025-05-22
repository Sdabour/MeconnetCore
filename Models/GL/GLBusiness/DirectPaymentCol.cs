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
    public class DirectPaymentCol : BaseCol
    {
        public DirectPaymentCol(bool blIsempty)
        {

        }
        public DirectPaymentCol(DirectPaymentTypeBiz objTypeBiz, int intBranchID, int intEmployeeID,
            bool blIsDateRange, DateTime dtStart, DateTime dtEnd)
        {
            if (objTypeBiz == null)
                objTypeBiz = new DirectPaymentTypeBiz();
            DirectPaymentDb objDb = new DirectPaymentDb();
            objDb.BranchID = intBranchID;
            objDb.EmployeeID = intEmployeeID;
            objDb.Type = objTypeBiz.ID;
            objDb.PaymentDateStatus = blIsDateRange;
            objDb.FromPaymentDate = dtStart;
            objDb.ToPaymentDate = dtEnd;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new DirectPaymentBiz(objDr));
            }

        }

        public DirectPaymentBiz this[int intIndex]
        {

            get
            {
                return (DirectPaymentBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (DirectPaymentBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }

        public void Add(DirectPaymentBiz objBiz)
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
            foreach (DirectPaymentBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();
                objBiz.GetData();
                objDr["PaymentID"] = objBiz.ID;
                //objDr["ReservationID"] = objBiz.ReservationBiz.ID;
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