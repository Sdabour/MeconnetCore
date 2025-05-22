using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentPeriodStatisticDb
    {
        #region Private Data
        int _PeriodNo;
        string _Project;
        double _Value;
        string _PeriodName;
        #endregion
        #region Constructors
        public InstallmentPeriodStatisticDb()
        {
        }
        public InstallmentPeriodStatisticDb(DataRow objDr)
        {
            SetData(objDr);

        }
        #endregion
        #region Public Properties
        public int PeriodNo
        {
            get
            {
                return _PeriodNo;
            }
        }
        public string PeriodName
        {
            get
            {
                return _PeriodName;
            }
        }
        public string Project
        {
            get
            {
                return _Project;
            }
        }
        public double Value
        {
            get
            {
                return _Value;
            }
        }
    
       
        public string SearchStr
        {
            get
            {
                string Returned = "";
                string strInstallmentCell ="SELECT DISTINCT "+
                      " RPCell_1.CellID,RPCell_1.CellOrder, RPCell_1.CellNameA, dbo.CRMReservationInstallment.InstallmentID, dbo.CRMReservationInstallment.InstallmentDueDate, " +
                      " dbo.CRMReservationInstallment.InstallmentValue "+
                      " FROM         dbo.CRMReservationInstallment INNER JOIN "+
                      " dbo.CRMUnit INNER JOIN "+
                      " dbo.RPCell INNER JOIN "+
                      " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.RPCell.CellID = dbo.CRMUnitCell.CellID ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID ON "+
                      " dbo.CRMReservationInstallment.ReservationID = dbo.CRMUnit.CurrentReservation  "; 
                string strInstallmentDiscount = "SELECT dbo.CRMReservationInstallment.InstallmentID,"+
                    " SUM(case when dbo.CRMReservationInstallmentDiscount.DiscountValue is null then 0 else dbo.CRMReservationInstallmentDiscount.DiscountValue end) AS TotalInstallmentDiscount" +
                      " FROM   dbo.CRMReservationInstallment left outer join "+
                      " dbo.CRMReservationInstallmentDiscount ON  "+
                      " dbo.CRMReservationInstallment.InstallmentID = dbo.CRMReservationInstallmentDiscount.InstallmentID "+
                     " GROUP BY dbo.CRMReservationInstallment.InstallmentID";
             
                string strInstallmentPayment = "SELECT     dbo.CRMReservationInstallment.InstallmentID, SUM(CASE WHEN dbo.GLPayment.PaymentValue IS NULL " +
                               " THEN 0 ELSE dbo.GLPayment.PaymentValue END) AS TotalPaidValue " +
                          " FROM         dbo.GLPayment LEFT OUTER JOIN " +
                           " dbo.GLCheckPayment LEFT OUTER JOIN " +
                          " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID ON  " +
                      " dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID RIGHT OUTER JOIN " +
                      " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                      " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                     " WHERE    (CRMInstallmentPayment.InstallmentID is null) or (dbo.GLCheckPayment.CheckID IS NULL) OR " +
                      " (dbo.GLCheckPayment.PaymentIsCollected = 1) OR " +
                      " (dbo.GLCheck.CheckCurrentStatus IN (2, 4)) " +
                      "GROUP BY dbo.CRMReservationInstallment.InstallmentID";
                Returned = "select InstallmentTable.CellID, InstallmentTable.CellOrder,InstallmentTable.CellNameA,InstallmentTable.InstallmentID,InstallmentTable.InstallmentDueDate, " +
                      " (InstallmentTable.InstallmentValue - DiscountTable.TotalInstallmentDiscount - case when PaymentTable.TotalPaidValue is null then 0 else PaymentTable.TotalPaidValue end) RemainingValue " +
                      "from ("+ strInstallmentCell +") as InstallmentTable inner join ("+ strInstallmentDiscount +") as DiscountTable on InstallmentTable.InstallmentID = DiscountTable.InstallmentID "+
                      " left outer join ("+ strInstallmentPayment +") as PaymentTable on InstallmentTable.InstallmentID=PaymentTable.InstallmentID ";
                Returned = "SELECT   TOP 100 PERCENT CRMInstallmentPeriodReport.InstallmentPeriodID, CRMInstallmentPeriodReport.InstallmentPeriodName, SUM(case when InstallmentTable.RemainingValue is null then 0 else InstallmentTable.RemainingValue end) " +
                                " AS TotalValue, InstallmentTable.CellNameA,InstallmentTable.CellOrder " +
                                " FROM         CRMInstallmentPeriodReport INNER JOIN " +
                                "(" + Returned + ") as InstallmentTable ON "+
                                " (CRMInstallmentPeriodReport.InstallmentPeriodStartDate <= InstallmentTable.InstallmentDueDate AND " +
                                " CRMInstallmentPeriodReport.InstallmentPeriodEndDate > InstallmentTable.InstallmentDueDate) OR " +
                                " (CRMInstallmentPeriodReport.InstallmentPeriodStartDate <= InstallmentTable.InstallmentDueDate AND CRMInstallmentPeriodReport.InstallmentPeriodEndDate IS NULL) OR " +
                                "( CRMInstallmentPeriodReport.InstallmentPeriodEndDate > InstallmentTable.InstallmentDueDate AND CRMInstallmentPeriodReport.InstallmentPeriodStartDate IS NULL) " +
                                " GROUP BY InstallmentTable.CellOrder,CRMInstallmentPeriodReport.InstallmentPeriodID, CRMInstallmentPeriodReport.InstallmentPeriodName, InstallmentTable.CellNameA " +
                                " ORDER  BY InstallmentTable.CellOrder,CRMInstallmentPeriodReport.InstallmentPeriodID";
              
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _PeriodNo = int.Parse(objDr["InstallmentPeriodID"].ToString());

            _Project = objDr["CellNameA"].ToString();
            if (_Project == "")
                _Project = "€Ì— „Õœœ";
            _Value = double.Parse(objDr["Totalvalue"].ToString());
            _PeriodName = objDr["InstallmentPeriodName"].ToString();
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
