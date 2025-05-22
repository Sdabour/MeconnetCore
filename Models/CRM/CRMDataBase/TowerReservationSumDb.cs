using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.CRM.CRMDataBase
{
    public class TowerReservationSumDb
    {
        #region PrivateData
        protected string _TowerNo;
        protected double _TotalValue;
        protected double _TotalTempPayment;
        protected double _TotalInstallmentValue;
        protected double _TotalInstallmentPaymentSum;
        protected int _FreeCount;
        protected int _ClosedCount;
        #endregion

        #region Private Data For Search
        protected bool _IsDateRange;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        protected bool _IsContractingDateRange;
        protected DateTime _ContractingDateFrom;
        protected DateTime _ContractingDateTo;

        protected int _ID;
        protected int _CellID;
        #endregion


        #region Constractors
        public TowerReservationSumDb()
        {

        }
        public TowerReservationSumDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice

        #region Public Accessorice For Search
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public bool IsDateRange
        {
            set
            {
                 _IsDateRange = value;
            }
            get
            {
                return _IsDateRange;
            }
        }
        
        public DateTime DateFrom 
        {
            set
            {
                 _DateFrom = value;
            }
        }
        public DateTime DateTo
        {
            set
            {
                 _DateTo =value;
            }
        }


        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
            }
            get
            {
                return _IsContractingDateRange;
            }
        }
        public DateTime ContractingDateFrom
        {
            set
            {
                _ContractingDateFrom = value;
            }

        }
        public DateTime ContractingDateTo
        {
            set
            {
                _ContractingDateTo = value;
            }

        }


        public int CellID
        {
            set
            {
                 _CellID = value;
            }
        }
        #endregion

        public string TowerNo
        {
            set
            {
                _TowerNo = value;
            }
            get
            {
                return _TowerNo;
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
        public double TotalTempPayment
        {
            set
            {
                _TotalTempPayment = value;
            }
            get
            {
                return _TotalTempPayment;
            }
        }
        public double TotalInstallmentValue
        {
            set
            {
                _TotalInstallmentValue = value;
            }
            get
            {
                return _TotalInstallmentValue;
            }
        }
        public double TotalInstallmentPaymentSum
        {
            set
            {
                _TotalInstallmentPaymentSum = value;
            }
            get
            {
                return _TotalInstallmentPaymentSum;
            }
        }
        public int FreeCount
        {
            set
            {
                _FreeCount = value;
            }
            get
            {
                return _FreeCount;
            }
        }
        public int ClosedCount
        {
            set
            {
                _ClosedCount = value;
            }
            get
            {
                return _ClosedCount;
            }
        }

        public  string SearchStr
        {
            get
            {
               
                #region CRMReservation_V


                double dblDateFrom = _DateFrom.ToOADate() - 2;
                int TempStartDate = (int) dblDateFrom;
                double dblDateTimeto = _DateTo.ToOADate() - 2;
                int TempEndDate = (int) dblDateTimeto;
                string strUnitTower = "SELECT DISTINCT " +
                      " dbo.CRMUnit.UnitID,CRMUnit.UnitClosedPermanent, RPCell_1.CellID AS TowerID,RPCell_1.CellOrder, dbo.CRMUnit.CurrentReservation," +
                      " RPCell_2.CellNameA AS ProjectName, " +
                      " CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                      " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END AS TowerName " +
                      " FROM         dbo.CRMUnitCell INNER JOIN " +
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
                      " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN " +
                      " dbo.RPCell RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                      " dbo.RPCell RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID where (1=1)";
                if (_CellID != 0)
                    strUnitTower += " and  RPCell_1.CellFamilyID =" + _CellID;
               // strUnitTower += " order by RPCell_1.CellOrder ";//",CASE WHEN RPCell_1.CellAlterName IS NULL OR "+
                //                 " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END ";
                string strReservationTower = "select distinct TowerID,CurrentReservation from (" + strUnitTower + ") as TowerTable ";
                string strTempPayment = "SELECT TowerTable.TowerID, SUM(CASE WHEN dbo.GLPayment.PaymentValue IS NULL THEN 0 ELSE dbo.GLPayment.PaymentValue END) "+
                       " AS TotalTempPayment "+
                       " FROM  (" + strReservationTower + ") as TowerTable left outer join "+
                       " dbo.CRMTempReservationPayment on TowerTable.CurrentReservation = CRMTempReservationPayment.ReservationID left outer JOIN " +
                       " dbo.GLPayment ON dbo.CRMTempReservationPayment.PaymentID = dbo.GLPayment.PaymentID "+
                       " GROUP BY  TowerTable.TowerID ";

                string strTempInstallment = "SELECT     TowerTable.TowerID, SUM(CASE WHEN dbo.CRMReservationInstallment.InstallmentValue IS NULL "+
                       " THEN 0 ELSE CRMReservationInstallment.InstallmentValue END) AS InstallmentSum  "+
                       " FROM  (" + strReservationTower + ") as TowerTable left outer join " +
                       " CRMReservationInstallment on TowerTable.CurrentReservation = CRMReservationInstallment.ReservationID "+
                       " GROUP BY TowerTable.TowerID ";
                string strInstallmentPayment = "SELECT TowerTable.TowerID, SUM(case when dbo.GLPayment.PaymentValue is null then 0 else GLPayment.PaymentValue end) AS TotalInstallmentPayment " +
                      " FROM     (" + strReservationTower+ ") as TowerTable left outer join   dbo.CRMReservationInstallment "+
                      " on TowerTable.CurrentReservation = CRMReservationInstallment.ReservationID  left outer JOIN "+
                      " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN "+
                      " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID left outer JOIN "+
                      " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID left outer JOIN "+
                      " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID "+ 
                      " WHERE     (dbo.GLCheck.CheckID IS NULL) OR "+
                      " (dbo.GLCheck.CheckCurrentStatus = 2) OR "+
                      " (dbo.GLCheckPayment.PaymentIsCollected = 1)"+
                      " GROUP BY TowerTable.TowerID ";

               #region OldRegion
                //string strSql1 = "SELECT TOP 100 PERCENT dbo.CRMUnit.UnitFullName, dbo.CRMUnit.UnitNameA, SUBSTRING(dbo.CRMUnit.UnitFullName, 0, "+ 
                //                 " LEN(dbo.CRMUnit.UnitFullName) - LEN(dbo.CRMUnit.UnitNameA) + 1) AS TowerNo, dbo.CRMReservation.ReservationValue,  "+
                //                 " SUM(dbo.GLPayment.PaymentValue) AS TempPaymentSum, dbo.CRMReservation.ReservationID, "+
                //                 " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationBranch, dbo.CRMReservation.ReservationDate, "+
                //                 " dbo.CRMReservation.ReservationContractingDate, dbo.CRMReservation.TimIns "+
                //                 " FROM         dbo.CRMUnit INNER JOIN "+
                //                 " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                //                 " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID LEFT OUTER JOIN "+
                //                 " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID LEFT OUTER JOIN "+
                //                 " dbo.CRMTempReservationPayment ON dbo.CRMReservation.ReservationID = dbo.CRMTempReservationPayment.ReservationID "+
                //                 " inner join GLPayment on GLPayment.PaymentID = dbo.CRMTempReservationPayment.PaymentID " +
                //                 "Where 1 = 1 ";
                //                 if(_CellID != 0)
                //                 {
                //                    strSql1 += " And  (dbo.RPCell.CellFamilyID = "+_CellID+") ";
                //                 }
                                 

                //                 if(IsDateRange)
                //                 {
                //                     //strSql1 += " And (dbo.CRMReservation.TimIns Between "+dblDateFrom+" and "+dblDateTimeto+") ";
                //                     strSql1 += " and Convert(float,dbo.CRMReservation.ReservationDate) >= " + TempStartDate + " and Convert(float,dbo.CRMReservation.ReservationDate) < " + TempEndDate + "";
                //                 }
                //                 if (IsContractingDateRange)
                //                 {
                //                     dblDateFrom = _ContractingDateFrom.ToOADate() - 2;
                //                     TempStartDate = (int)dblDateFrom;
                //                     dblDateTimeto = _ContractingDateTo.ToOADate() - 2;
                //                     TempEndDate = (int)dblDateTimeto;
                //                     strSql1 += " and Convert(float,dbo.CRMReservation.ReservationContractingDate) >= " + TempStartDate + " and Convert(float,dbo.CRMReservation.ReservationContractingDate) < " + TempEndDate + "";
                //                 }
                //                 strSql1 += " GROUP BY dbo.CRMUnit.UnitFullName, dbo.CRMUnit.UnitNameA, SUBSTRING(dbo.CRMUnit.UnitFullName, 0, LEN(dbo.CRMUnit.UnitFullName) "+
                //                 " - LEN(dbo.CRMUnit.UnitNameA) + 1), dbo.CRMReservation.ReservationValue, dbo.CRMReservation.ReservationID, "+
                //                 " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationBranch, dbo.CRMReservation.ReservationDate, "+
                //                 " dbo.CRMReservation.ReservationContractingDate, dbo.CRMReservation.TimIns";

                //                 //strSql2 is CRMReservationInstallment_V
                //                 #region CRMReservationInstallment_V
                //                 string strSql2 = "SELECT  CRMReservation.ReservationID,SUM(case when CRMReservationInstallment.InstallmentValue is null then 0 else CRMReservationInstallment.InstallmentValue end) " +
                //                                  " AS InstallmentSum " +
                //                                  " FROM  CRMReservation left outer join CRMReservationInstallment " +
                //                                  " on CRMReservation.ReservationID = CRMReservationInstallment.ReservationID  " +
                //                                  " group by CRMReservation.ReservationID ";

                //                 #endregion

                //                 #region CRMReservationInstallment_Payment
                //                 string strSql3 = "SELECT CRMReservation.ReservationID,SUM(case when GLPayment.PaymentValue is null then 0 else GLPayment.PaymentValue end) AS InstallmentPaymentSum " +
                //                                  " FROM  CRMReservation left outer join " +
                //                                  " CRMReservationInstallment ON CRMReservation.ReservationID = CRMReservationInstallment.ReservationID LEFT OUTER JOIN " +
                //                                  " CRMInstallmentPayment ON CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                //                                  " left outer join GLPayment on CRMInstallmentPayment.PaymentID = GLPayment.PaymentID " +
                //                                  " GROUP by CRMReservation.ReservationID ";

                //                 #endregion
                #endregion
                            
                #endregion
             


                    
                // Returned is CRMTowerReservationSum_V
                string Returned = "";
                strUnitTower = "select  UnitTable.TowerID,UnitTable.CellOrder,UnitTable.TowerName as TowerNo"+
                          ",Sum(case when UnitTable.CurrentReservation= 0 and UnitTable.UnitClosedPermanent=0 then 1 else 0 end) as FreeCount, " +
                          "Sum(case when UnitTable.CurrentReservation= 0 and UnitTable.UnitClosedPermanent=1 then 1 else 0 end) as ClosedCount  " +
                          " from  (" + strUnitTower + ") as UnitTable ";
                strUnitTower += " group by UnitTable.CellOrder,UnitTable.TowerID,UnitTable.TowerName  ";
                      Returned = "select  UnitTable.TowerID,UnitTable.CellOrder,UnitTable.TowerNo,TempPaymentTable.TotalTempPayment As TotalTempPayment"+
                          ",InstallmentTable.InstallmentSum AS TotalInstallmentValue,"+
                          "InstallmentPaymentTable.TotalInstallmentPayment as TotalInstallmentPaymentSum " +
                          ",UnitTable.FreeCount, "+
                          "UnitTable.ClosedCount  "+
                          " from  (" + strUnitTower + ") as UnitTable inner join (" + strTempPayment + ") TempPaymentTable on UnitTable.TowerID = TempPaymentTable.TowerID " +
                          " inner join (" + strTempInstallment + ") as InstallmentTable on UnitTable.TowerID =InstallmentTable.TowerID " +
                          " inner join (" + strInstallmentPayment + ") as InstallmentPaymentTable on UnitTable.TowerID = InstallmentPaymentTable.TowerID ";
                      //Returned += " group by UnitTable.CellOrder,UnitTable.TowerID,UnitTable.TowerNo  ";
                      Returned += " order by unitTable.CellOrder,UnitTable.TowerNo";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _TowerNo = objDR["TowerNo"].ToString();
            //if(objDR["TotalValue"].ToString() != "")
            //{
            //    _TotalValue = double.Parse(objDR["TotalValue"].ToString());
            //}
            //else
            //{
            //    _TotalValue = 0;
            //}
            
            if(objDR["TotalTempPayment"].ToString() != "")
            {
                _TotalTempPayment = double.Parse(objDR["TotalTempPayment"].ToString());
            }
            else
            {
                _TotalTempPayment = 0;
            }
            
            if(objDR["TotalInstallmentValue"].ToString() != "")
            {
            
            _TotalInstallmentValue = double.Parse(objDR["TotalInstallmentValue"].ToString());
            }
            else
            {
                _TotalInstallmentValue = 0;
            }
            _TotalValue = _TotalTempPayment + _TotalInstallmentValue;
            if(objDR["TotalInstallmentPaymentSum"].ToString() != "")
            {
            _TotalInstallmentPaymentSum = double.Parse(objDR["TotalInstallmentPaymentSum"].ToString());
            }
            _FreeCount = int.Parse(objDR["FreeCount"].ToString());
            _ClosedCount = int.Parse(objDR["ClosedCount"].ToString());
        }
        #endregion

        #region Public Methods
        public DataTable Search()
        {
            return SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
        }
        #endregion
    }
}
