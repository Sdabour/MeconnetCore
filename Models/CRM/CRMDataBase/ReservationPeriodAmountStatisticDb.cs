using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationPeriodAmountStatisticDb
    {
        #region Private Data
        protected int _TotalUnitCount;
        protected int _CellID;
        protected string _CellNameA;
        protected double _PeriodAmount;
        protected double _TotalValue;
        protected double _InstallmentDiscount;
        #endregion

        #region Constractors
        public ReservationPeriodAmountStatisticDb()
        { 

        }
        public ReservationPeriodAmountStatisticDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int TotalUnitCount
        {
            set
            {
                _TotalUnitCount = value;
            }
            get
            {
                return _TotalUnitCount;
            }
        }
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public string CellNameA
        {
            set
            {
                _CellNameA = value;
            }
            get
            {
                return _CellNameA;

            }
        }
        public double PeriodAmount
        {
            set
            {
                _PeriodAmount = value;
            }
            get
            {
                return _PeriodAmount;
            }
        }
        public double TotalValue
        {
            set
            {
                _TotalValue = value;
            }
            get
            {
                return _TotalValue;
            }
        }
        public double InstallmentDiscount
        {
            set
            {
                _InstallmentDiscount = value;
            }
            get
            {
                return _InstallmentDiscount;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strCell = "select Distinct CRMUnit.CurrentReservation as ReservationID,RPCell_1.CellNameA,RPCell_1.CellFamilyID "+
                    " from  CRMUnit inner join" +
                    " CRMUnitCell on CRMUnit.UnitID = CRMUnitCell.UnitID " +
                      " INNER JOIN" +
                      " RPCell ON CRMUnitCell.CellID = RPCell.CellID ";

                strCell += " INNER JOIN RPCell RPCell_1 ON RPCell.CellFamilyID = RPCell_1.CellID "+
                    " WHERE     (dbo.CRMUnit.CurrentReservation <> 0) ";
                string strInstallment = "SELECT CRMReservation.ReservationID, SUM(CASE WHEN CRMReservationInstallment.InstallmentValue IS NULL "+
                      " THEN 0 ELSE CRMReservationInstallment.InstallmentValue END) AS TotalInstallmentValue "+
                      " FROM         CRMReservation LEFT OUTER JOIN "+
                      " CRMReservationInstallment ON CRMReservation.ReservationID = CRMReservationInstallment.ReservationID "+
                       " GROUP BY CRMReservation.ReservationID ";
                string strTempPayment = "SELECT     CRMReservation.ReservationID, CASE WHEN TempPaymentTable.TotalPaymentValue IS NULL " +
                      " THEN 0 ELSE TempPaymentTable.TotalPaymentValue END AS TempPaymentValue " +
                      " FROM         CRMReservation LEFT OUTER JOIN " +
                      " (SELECT     CRMTempReservationPayment.ReservationID, SUM(GLPayment.PaymentValue) AS TotalPaymentValue " +
                      " FROM         CRMTempReservationPayment INNER JOIN " +
                      " GLPayment ON CRMTempReservationPayment.PaymentID = GLPayment.PaymentID " +
                      " GROUP BY CRMTempReservationPayment.ReservationID) TempPaymentTable ON  " +
                " TempPaymentTable.ReservationID = CRMReservation.ReservationID";
                string strInstallmentDiscount = "SELECT     dbo.CRMReservation.ReservationID, SUM(CASE WHEN dbo.CRMReservationInstallmentDiscount.DiscountValue IS NULL "+
                       " THEN 0 ELSE dbo.CRMReservationInstallmentDiscount.DiscountValue END) AS TotalDiscount "+
                      " FROM         dbo.CRMReservationInstallmentDiscount RIGHT OUTER JOIN "+
                      " dbo.CRMReservationInstallment ON  "+
                      " dbo.CRMReservationInstallmentDiscount.InstallmentID = dbo.CRMReservationInstallment.InstallmentID RIGHT OUTER JOIN "+
                      " dbo.CRMReservation ON dbo.CRMReservationInstallment.ReservationID = dbo.CRMReservation.ReservationID "+
                      " GROUP BY dbo.CRMReservation.ReservationID ";
                string Returned = "SELECT  TOP 100 PERCENT COUNT(CRMReservation.ReservationID) AS ReservationCount, CellTable.CellNameA,CellTable.CellFamilyID ," +
                          " CRMReservation.ReservationPeriodAmount ,sum(CRMReservation.ReservationValue) as TotalValue,sum(InstallmentTable.TotalInstallmentValue) as TotalInstallmentValue,sum(TempPaymentTable.TempPaymentValue) as TempPaymentValue,"+ 
                          " SUM(InstallmentTable.TotalInstallmentValue + TempPaymentTable.TempPaymentValue) AS commonTotalValue " +
                          ",sum(TotalDiscount) as TotalDiscount "+
                         " FROM     CRMReservation inner join (" + strInstallment + ") as InstallmentTable on CRMReservation.ReservationID = InstallmentTable.ReservationID " +
                         " inner join (" + strCell + ") as Celltable on CRMReservation.ReservationID = Celltable.ReservationID  " +
                         " left outer join (" + strTempPayment + ") as TempPaymentTable on CRMReservation.ReservationID = TempPaymentTable.ReservationID  "+
                         " inner join (" + strInstallmentDiscount + ") DiscountTable on CRMReservation.ReservationID = DiscountTable.ReservationID ";
                         //" group by CellTable.CellNameA,CellTable.CellFamilyID, CRMReservation.ReservationPeriodAmount  " +
                         //" order by CellTable.CellNameA ";

         
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        { 
            _TotalUnitCount = int.Parse(objDR["ReservationCount"].ToString());
            _CellID = int.Parse(objDR["CellFamilyID"].ToString());
            _CellNameA = objDR["CellNameA"].ToString();
            _PeriodAmount = double.Parse(objDR["ReservationPeriodAmount"].ToString());
            _TotalValue = double.Parse(objDR["commonTotalValue"].ToString());
            _InstallmentDiscount = double.Parse(objDR["TotalDiscount"].ToString());
        }
        #endregion

        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr + "where 1 = 1 ";
            if (_CellID != 0)
                strSql = strSql + " and CellTable.CellFamilyID = "+_CellID+" ";
            strSql += " group by CellTable.CellNameA,CellTable.CellFamilyID, CRMReservation.ReservationPeriodAmount  ";
                         strSql += " order by CellTable.CellNameA ";
                         return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
