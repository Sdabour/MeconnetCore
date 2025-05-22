using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
//using SharpVision.Base.BaseBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class StrategyInstallmentCol  : CollectionBase
    {
        public StrategyInstallmentCol(bool blIsempty)
        {

        }
        public StrategyInstallmentCol(int intStrategyID)
        {
           StrategyInstallmentDb objDb = new StrategyInstallmentDb();
            objDb.StrategyID = intStrategyID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new StrategyInstallmentBiz(objDr));
            }
        }

        public StrategyInstallmentBiz this[int intIndex]
        {
           
            get
            {
                return (StrategyInstallmentBiz)List[intIndex];
            }
        }
        public double Value
        {
            get
            {
                double Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.InstallmentValue ;
                }
                return Returned;
            }
        }
        public double SumInstallmentValue
        {
            get
            {
                double Returned = 0;
                
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    if (objBiz.InstallmentCol == null)
                        objBiz.InstallmentCol = new ReservationInstallmentCol(true);
                    Returned = Returned + objBiz.InstallmentCol.Value;
                }
                return Returned;
            }
        }
        public ReservationInstallmentBiz MaxDueInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                if (Count > 0)
                    Returned = this[0].InstallmentCol.MaxDueInstallment;
                foreach (StrategyInstallmentBiz  objBiz in this)
                {
                    if (Returned.InstallmentDueDate < objBiz.InstallmentCol.MaxDueInstallment.InstallmentDueDate)
                        Returned = objBiz.InstallmentCol.MaxDueInstallment;
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
                    Returned = this[0].InstallmentCol.MaxDueInstallment;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    if (Returned.InstallmentDueDate >objBiz.InstallmentCol.MinDueInstallment.InstallmentDueDate)
                        Returned = objBiz.InstallmentCol.MinDueInstallment;
                }
                return Returned;
            }
        }
        public double TotalInstallmentValue
        {
            get
            {
                double Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.InstallmentCol.Value;
                }
                return Returned;
            }
 
        }
        public double TotalPaidValue
        {
            get
            {
                double Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.PaidValue;
                }
                return Returned;
            }

        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
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
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.TotalCollectedCheckValue;
                }
                return Returned;
            }

        }
        public double TotalDiscountValue
        {
            get
            {
                double Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned += objBiz.InstallmentCol.Discountvalue;
                }
                return Returned;
            }
        }
        public int InstallmentCount
        {
            get
            {
                int Returned = 0;
                foreach (StrategyInstallmentBiz objBiz in this)
                {
                    Returned += objBiz.InstallmentCol.Count;
                }
                return Returned;
            }
        }
        public void Add(StrategyInstallmentBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public ReservationInstallmentCol DeservedInstallmentCol(DateTime dtDate)
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            foreach (StrategyInstallmentBiz objBiz in this)
            {

                Returned.Add(objBiz.DeservedInstallmentCol(dtDate));
            }
            return Returned;
 
        }
        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("No"), new DataColumn("Type"), 
                new DataColumn("Value"), new DataColumn("Period"), new DataColumn("PeriodAmount") });
            DataRow objDr;
            foreach (StrategyInstallmentBiz  objBiz in this)
            {
                objDr = dtReturned.NewRow();

                objDr["No"] = objBiz.InstallmentNo;
                objDr["Type"] = objBiz.TypeBiz.ID;
                objDr["Value"] = objBiz.InstallmentValue;
                objDr["Period"] = objBiz.InstallmentPeriod;
                objDr["PeriodAmount"] = objBiz.PeriodAmount;
                
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;
        }
        public StrategyInstallmentCol GetNonPaidCopy()
        {
            StrategyInstallmentCol Returned = new StrategyInstallmentCol(true);
            StrategyInstallmentBiz objTemp ;
            ReservationInstallmentCol objNonPaidCol ;
            foreach (StrategyInstallmentBiz objBiz in this)
            {
                objNonPaidCol = objBiz.InstallmentCol.GetNonPaidCopy();
                if (objNonPaidCol.Count > 0)
                {
                    objTemp = new StrategyInstallmentBiz();
                    objTemp.TypeBiz = objBiz.TypeBiz;
                    objTemp.InstallmentCol = objNonPaidCol;
                    Returned.Add(objTemp);

                }
            }
            return Returned;
        }
    }
}
