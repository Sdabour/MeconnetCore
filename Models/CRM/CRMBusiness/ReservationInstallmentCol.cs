using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
using System.Linq;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationInstallmentCol : BaseCol
    {
        public ReservationInstallmentCol(bool blIsempty)
        {

        }
        public ReservationInstallmentCol(int intID)
        {
            ReservationInstallmentDb objDb = new ReservationInstallmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationInstallmentBiz(objDr));
            }
        }

        public ReservationInstallmentBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (ReservationInstallmentBiz)List[intIndex];
            }
        }
        public double Value
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.InstallmentValue;
                }
                return Returned;
            }
        }
        public double PaidValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.PaidValue;
                }
                return Returned;
            }
        }
        public double DeservedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.DeservedCheckValue;
                }
                return Returned;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.TotalCheckValue;
                }
                return Returned;
            }
        }
        public double TotalCollectedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.TotalCollectedCheckValue;
                }
                return Returned;
            }
        }
        public double NonDeservedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.NonDeservedCheckValue;
                }
                return Returned;
            }
        }
        public double DeservedValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                     
                    Returned += objBiz.DeservedValue;
                }
                return Returned;
            }
        }
        public double RemainingValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {

                    Returned += objBiz.RemainingValue;
                }
                return Returned;
            }
        }
        public ReservationInstallmentBiz DeliveryInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    if (objBiz.Type.MainType == InstallmentMainType.DeliveryPayment)
                    {
                        return objBiz;
                    }
                }
                return Returned;
            }
        }
        public ReservationInstallmentBiz  MaxDueInstallment
        {
            get
            {
                 ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                if(Count>0 )
                    Returned = this[0];
                 foreach (ReservationInstallmentBiz objBiz in this)
                 {
                     if (Returned.InstallmentDueDate < objBiz.InstallmentDueDate)
                         Returned = objBiz;
                 }
                 return Returned;
            }
        }
        public ReservationInstallmentBiz MaxPaidInstallment 
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz(); 
                
                if (Count > 0 && this[0].PaidValue>0)
                    Returned = this[0];
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    if (objBiz.PaidValue>0 && (objBiz.PaymentDate>Returned.PaymentDate||Returned.ID==0))
                        Returned = objBiz;
                }
                return Returned;
            }
        }
        public ReservationInstallmentBiz MinDueInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                if (Count > 0)
                    Returned = this[0];
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    if (Returned.InstallmentDueDate > objBiz.InstallmentDueDate)
                        Returned = objBiz;
                }
                return Returned;
            }
        }

        public ReservationInstallmentBiz DeservedInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz() ;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    if (objBiz.PaymentCol.Value < objBiz.InstallmentValue && objBiz.InstallmentStatus == InstallmentStatus.Created)
                    {
                        Returned = objBiz;
                        break;
                    }

 
                }
              
                return Returned;
            }
        }
        public double Discountvalue
        {
            get 
            {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned += objBiz.DiscountValue;
                }
                return Returned;
            }
        }
        public void Add(ReservationInstallmentBiz objBiz)
        {
            if (objBiz == null)
                return;
            List.Add(objBiz);

        }
        public void Add(ReservationInstallmentCol objCol)
        {
            if (objCol == null)
                return;
            foreach (ReservationInstallmentBiz objBiz in objCol)
            {
                List.Add(objBiz);
            }

        }
        
        internal DataTable GetTable(string strName)
        {
            DataTable dtReturned = new DataTable(strName);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("InstallmentID"), new DataColumn("ReservationID"), 
                new DataColumn("InstallmentType"), new DataColumn("InstallmentNo"), new DataColumn("InstallmentStatus"), 
                new DataColumn("InstallmentGroup"),
                new DataColumn("InstallmentDueDate"), new DataColumn("InstallmentValue"), new DataColumn("InstallmentDesc") });
            DataRow objDr;
            foreach (ReservationInstallmentBiz  objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["InstallmentID"] = objBiz.ID;
                objDr["ReservationID"] = 0;//objBiz.Reservation.ID;
                objDr["InstallmentType"] = objBiz.Type.ID;
                objDr["InstallmentNo"] = objBiz.InstallmentNo;
                objDr["InstallmentStatus"] = (int)objBiz.InstallmentStatus;
                objDr["InstallmentGroup"] = objBiz.Group;
                objDr["InstallmentDueDate"] = objBiz.InstallmentDueDate;
                objDr["InstallmentValue"] = objBiz.InstallmentValue;
                objDr["InstallmentDesc"] = objBiz.Desc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        public DataTable GetTable()
        {
            return GetTable("Installment");
        }
        public ReservationInstallmentCol GetNonPaidCopy()
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            foreach (ReservationInstallmentBiz objBiz in this)
            {
                if (objBiz.RemainingValue > 0)
                {
                    Returned.Add(objBiz.GetNonPaidCopy());
                }
            }
            return Returned;
        }


        public double GetPaidAfterTimeValue(DateTime dtTime)
        {
                double Returned = 0;
                foreach (ReservationInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.PaymentCol.GetPaidAfterTimeValue(dtTime);
                }
                return Returned;
            
        }

        public double GetDiscountAfterTimeValue(DateTime dtTime)
        {
            double Returned = 0;
            foreach (ReservationInstallmentBiz objBiz in this)
            {
                Returned = Returned + objBiz.InstallmentDiscountCol.GetDiscountAfterTimeValue(dtTime);
            }
            return Returned;
        }

        public ReservationInstallmentCol AdjustNonPaidDueInstallment()//ReservationBiz objReservationBiz)
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            InstallmentPaymentBiz objTempPayment;
            Hashtable hsTemp = new Hashtable();

            DateTime dtVirtual = DateTime.Now;//objReservationBiz. DateTime.Now;
            double dblPaidValue = 0;
            double dblRemainingValue = 0;// objReservationBiz.VirtualRemainingValue;
            double dblTotalValue = 0;// objReservationBiz.Value;
            foreach (ReservationInstallmentBiz objBiz in this)
            {

                if (objBiz.InstallmentStatus == InstallmentStatus.Created &&
                    (((TimeSpan)DateTime.Now.Subtract(objBiz.InstallmentDueDate)).Days >0))
                    //||
                    //(dblRemainingValue-dblPaidValue)/dblTotalValue >0.5))
                {

                    if (objBiz.RemainingValue > 0 &&
                        objBiz.TotalCheckValue > 0)
                    {
                        foreach (InstallmentPaymentBiz objPaymentBiz in objBiz.PaymentCol)
                        {
                            objPaymentBiz.IsCollected = true;
                            objPaymentBiz.CollectingDate = DateTime.Now;

                            dblPaidValue += objPaymentBiz.Value;
                            
                        }
                    }
                    else
                    {
                        objTempPayment = new InstallmentPaymentBiz();
                        objTempPayment.Date = DateTime.Now;
                        objTempPayment.Currency = 1;
                        objTempPayment.CurrencyValue = 1;
                        objTempPayment.Value = objBiz.RemainingValue;
                        objTempPayment.Type = SharpVision.GL.GLBusiness.PaymentType.Cash;
                        dblPaidValue += objTempPayment.Value;
                        objBiz.PaymentCol.Add(objTempPayment);

 
                    }
                    objBiz.InstallmentStatus = InstallmentStatus.Paid;

                }

                Returned.Add(objBiz);
                hsTemp.Add(objBiz.ID.ToString(), objBiz);
            }
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] { 
                new DataColumn("InstallmentID"),
                new DataColumn("InstallmentStatus",Type.GetType("System.Int32")),
                new DataColumn("InstallmentDueDate",Type.GetType("System.DateTime")),
            new DataColumn("InstallmentGroup",Type.GetType("System.Int32"))});

            DataRow objDr;
            foreach (ReservationInstallmentBiz objBiz in Returned)
            {
                objDr = dtTemp.NewRow();
                objDr["InstallmentID"] = objBiz.ID;
                objDr["InstallmentStatus"] = (int)objBiz.InstallmentStatus;
                objDr["InstallmentDueDate"] = objBiz.InstallmentDueDate;
                objDr["InstallmentGroup"] = objBiz.Group;

                dtTemp.Rows.Add(objDr);
            }
            //InstallmentStatus,
            DataRow[] arrDr = dtTemp.Select("", "InstallmentDueDate,InstallmentGroup");
            Returned = new ReservationInstallmentCol(true);
            ReservationInstallmentBiz objInstallment;
            foreach (DataRow objTempDr in arrDr)
            {
                objInstallment = (ReservationInstallmentBiz)hsTemp[objTempDr["InstallmentID"].ToString()];
                Returned.Add(objInstallment);
            }
            return Returned;
        }
        public void MixCheckCol(ReservationCheckCol objCheckCol)
        {
            InstallmentPaymentBiz objPaymentBiz = new InstallmentPaymentBiz();
            List<ReservationCheckBiz> lstCheck;
            Hashtable hsCheck = new Hashtable();
            foreach (ReservationInstallmentBiz objInstallment in this)
            {
                objPaymentBiz = new InstallmentPaymentBiz() { InstallmentBiz = objInstallment, InstallmentID = objInstallment.ID, Value = objInstallment.VirtualRemainingValue, Type = PaymentType.Check, Currency = 1, EmployeeID = SysData.CurrentUser.EmployeeBiz.ID, Date = DateTime.Now };
                lstCheck = (from vrCheck in objCheckCol.Cast<ReservationCheckBiz>()
                            where vrCheck.DueDate.Date == objInstallment.InstallmentDueDate.Date && vrCheck.CheckPayment(objPaymentBiz) && hsCheck[vrCheck.ID.ToString()] == null
                            select vrCheck).ToList();
                if (lstCheck.Count > 0)
                {
                    if (hsCheck[lstCheck[0].ID.ToString()] == null)
                    {
                        hsCheck.Add(lstCheck[0].ID.ToString(), "");
                        objPaymentBiz.CheckBiz = lstCheck[0];

                        objPaymentBiz.Add();
                    }
                }
            }
        }
    }
}
