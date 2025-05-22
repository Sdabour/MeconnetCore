using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class BranchReservationCountDb
    {
        #region Private Data
        protected string _Name;
        protected double _TotalValue;
        protected double _TotalTempPayment;
        protected double _TotalInstallmentValue;
        protected double _InstallmentPaymentSum;
        protected int _ClosedCount;
        protected int _TotalCount;
        protected string _TowerName;
        protected int _Y;
        protected int _M;
        protected int _D;
        protected string _ProjectName;
        #region Private Data For Search
        protected bool _IsDateRange;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        protected bool _IsContractingDateRange;
        protected DateTime _ContractingDateFrom;
        protected DateTime _ContractingDateTo;
        protected int _IsReservedStatus;
        bool _StatusDateRange;
        DateTime _StatusStartDate;
        DateTime _StatusEndDate;

        protected int _ID;
        protected int _CellID;
        string _BranchIDs;
        #endregion
        #region Private Data for Grouping
        bool _IsBranchGroupping;
        bool _IsProjectGrouping;
        bool _IsTowerGroupping;
        bool _IsYearGrouping;
        bool _IsMonthGrouping;
        bool _IsDayGrouping;
        #endregion
        #endregion

        #region Constractors
        public BranchReservationCountDb()
        {
        }
        public BranchReservationCountDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region public Accessorice
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
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
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
        public double InstallmentPaymentSum
        {
            set
            {
                _InstallmentPaymentSum = value;
            }
            get
            {
                return _InstallmentPaymentSum;
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
        public int IsReservedStatus
        {
            set
            {
                _IsReservedStatus = value;
            }
        }
        public string BranchIDs
        {
            set
            {
                _BranchIDs = value;
            }
        }
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }

        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
        }
        public string TowerName
        {
            get
            {
                return _TowerName;
            }
        }
        public int Y
        {
            get
            {
                return _Y;
            }
        }
        public int M
        {
            get
            {
                return _M;
            }
        }
        public int D
        {
            get
            {
                return _D;
            }
        }
        public bool StatusDateRange
        {
            set
            {
                _StatusDateRange = value;
            }
        }
        public DateTime StatusStartDate
        {
            set
            {
                _StatusStartDate = value;
            }
        }
        public DateTime StatusEndDate
        {
            set
            {
                _StatusEndDate = value;
            }
        }

      
        public bool IsBranchGrouping
        {
            set
            {
                _IsBranchGroupping = value;
            }
        }
        public bool IsProjectGrouping
        {
            set
            {
                _IsProjectGrouping = value;
            }

        }
        public bool IsTowerGrouping
        {
            set
            {
                _IsTowerGroupping = value;
            }
        }
        public bool IsYearGrouping
        {
            set
            {
                _IsYearGrouping = value;
            }
        }
        public bool IsMonthGrouping
        {
            set
            {
                _IsMonthGrouping = value;
            }
        }
        public bool IsDayGrouping
        {
            set
            {
                _IsDayGrouping = value;
            }
        }

        public  string SearchStr1
        {
            get
            {
            

                // strSql1 is CRMReservation_V
                #region CRMReservation_V

                double dblDateFrom = _DateFrom.ToOADate() - 2;
                int TempStartDate = (int)SysUtility.Approximate( dblDateFrom,1,ApproximateType.Down);

                double dblDateTimeto = _DateTo.ToOADate() - 2;
                int TempEndDate = (int)SysUtility.Approximate(dblDateTimeto, 1, ApproximateType.Up) ;

                string strSql1 = "SELECT TOP 100 PERCENT dbo.CRMUnit.UnitFullName, dbo.CRMUnit.UnitNameA, SUBSTRING(dbo.CRMUnit.UnitFullName, 0, "+ 
                                 " LEN(dbo.CRMUnit.UnitFullName) - LEN(dbo.CRMUnit.UnitNameA) + 1) AS TowerNo, dbo.CRMReservation.ReservationValue,  "+
                                 " SUM(dbo.GLPayment.PaymentValue) AS TempPaymentSum, dbo.CRMReservation.ReservationID, "+
                                 " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationBranch, dbo.CRMReservation.ReservationDate, "+
                                 " dbo.CRMReservation.ReservationContractingDate, dbo.CRMReservation.TimIns "+
                                 " FROM   dbo.CRMUnit INNER JOIN "+
                                 " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                                 " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID LEFT OUTER JOIN "+
                                 " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID LEFT OUTER JOIN "+
                                 " dbo.CRMTempReservationPayment ON dbo.CRMReservation.ReservationID = dbo.CRMTempReservationPayment.ReservationID "+
                                 " inner join  GLPayment on CRMTempReservationPayment.PaymentID = GLPayment.PaymentID "+
                                 " Where 1 = 1 ";
                

                strSql1 = "SELECT DISTINCT dbo.CRMReservation.ReservationID,CRMReservation.ReservationBranch,CRMReservation.ReservationValue,0 as ClosedCount, dbo.HRBranch.BranchID, dbo.HRBranch.BranchNameA"+
                     " FROM         dbo.CRMUnitCell INNER JOIN "+
                     " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN "+
                     " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN "+
                     " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID INNER JOIN "+
                     " dbo.HRBranch ON dbo.CRMReservation.ReservationBranch = dbo.HRBranch.BranchID"; 
                                 if(_CellID != 0)
                                 {
                                    strSql1 += " And  (dbo.RPCell.CellFamilyID = "+_CellID+") ";
                                 }
                                 if(IsDateRange)
                                 {
                                     //strSql1 += " And (dbo.CRMReservation.TimIns Between "+dblDateFrom+" and "+dblDateTimeto+") ";
                                     strSql1 += " and Convert(float,dbo.CRMReservation.ReservationDate) >= " + TempStartDate + " and Convert(float,dbo.CRMReservation.ReservationDate) < " + TempEndDate + "";
                                 }
                                 if (IsContractingDateRange)
                                 {
                                     dblDateFrom = _ContractingDateFrom.ToOADate() - 2;
                                     TempStartDate = (int)SysUtility.Approximate(dblDateFrom, 1, ApproximateType.Down);
                                     dblDateTimeto = _ContractingDateTo.ToOADate() - 2;
                                     TempEndDate = (int)SysUtility.Approximate( dblDateTimeto,1,ApproximateType.Up);
                                     strSql1 += " and Convert(float,dbo.CRMReservation.ReservationContractingDate) >= " + TempStartDate + " and Convert(float,dbo.CRMReservation.ReservationContractingDate) < " + TempEndDate + "";
                                 }

                                 #region StatusDate Range
                                 if (_StatusDateRange)
                                 {
                                     double dblStartStatusDate = SysUtility.Approximate(_StatusStartDate.ToOADate() - 2, 1, ApproximateType.Down);

                                     double dblEndStatusDate = SysUtility.Approximate(_StatusEndDate.ToOADate() - 2, 1, ApproximateType.Up);

                                     string strStatusWhere = "(ReservationStatus=6 and  CanceledReservation is not null and  CancelationDate>= " +
                                         dblStartStatusDate + " and CancelationDate<" + dblEndStatusDate + ") or " +
                                        " ((ReservationStatus = 4 or ReservationStatus = 3) and  ReservationContractingDate>= " +
                                        dblStartStatusDate + " and ReservationContractingDate<" + dblEndStatusDate + ") or " +
                                        "((ReservationStatus = 1 or ReservationStatus = 2) and   ReservationDate>= " + dblStartStatusDate +
                                        " and ReservationDate < " + dblEndStatusDate + ")";
                                     strSql1 += " and (" + strStatusWhere + ")";
                                 }
                                 #endregion
                                 //strSql1 += " GROUP BY dbo.CRMUnit.UnitFullName, dbo.CRMUnit.UnitNameA, SUBSTRING(dbo.CRMUnit.UnitFullName, 0, LEN(dbo.CRMUnit.UnitFullName) "+
                                 //" - LEN(dbo.CRMUnit.UnitNameA) + 1), dbo.CRMReservation.ReservationValue, dbo.CRMReservation.ReservationID, "+
                                 //" dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationBranch, dbo.CRMReservation.ReservationDate, "+
                                 //" dbo.CRMReservation.ReservationContractingDate, dbo.CRMReservation.TimIns";
                #endregion
                                 #region TempPayment
                                 string strTempPayment = "SELECT  dbo.CRMReservation.ReservationID, SUM(CASE WHEN dbo.GLPayment.PaymentValue IS NULL THEN 0 ELSE dbo.GLPayment.PaymentValue END) "+
                                        " AS TempPaymentSum "+
                                        " FROM         dbo.GLPayment INNER JOIN "+
                                        " dbo.CRMTempReservationPayment ON dbo.GLPayment.PaymentID = dbo.CRMTempReservationPayment.PaymentID RIGHT OUTER JOIN "+
                                        " dbo.CRMReservation ON dbo.CRMTempReservationPayment.ReservationID = dbo.CRMReservation.ReservationID "+
                                       " GROUP BY dbo.CRMReservation.ReservationID";
                                 #endregion


                                 #region CRMReservationInstallment_V
                                 string strSql2 = "SELECT  CRMReservation.ReservationID,SUM(case when CRMReservationInstallment.InstallmentValue is null then 0 else CRMReservationInstallment.InstallmentValue end) " +
                                                  " AS InstallmentSum " +
                                                  " FROM  CRMReservation left outer join CRMReservationInstallment " +
                                                  " on CRMReservation.ReservationID = CRMReservationInstallment.ReservationID  " +
                                                  " group by CRMReservation.ReservationID ";

                                 #endregion

                                 #region CRMReservationInstallment_Payment
                                 string strSql3 = "SELECT CRMReservation.ReservationID,SUM(case when GLPayment.PaymentValue is null or "+
                                     "(GLCheck.CheckID is not null and (GLCheck.CheckCurrentStatus <> 2 and GLCheckPayment.PaymentIsCollected =0   ))  then 0 else GLPayment.PaymentValue end) AS InstallmentPaymentSum " +
                                                  " FROM  CRMReservation left outer join " +
                                                  " CRMReservationInstallment ON CRMReservation.ReservationID = CRMReservationInstallment.ReservationID LEFT OUTER JOIN " +
                                                  " CRMInstallmentPayment ON CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                                                  " left outer join GLPayment on CRMInstallmentPayment.PaymentID = GLPayment.PaymentID " +
                                                  " left outer join GLCheckPayment on GLPayment.PaymentID = GLCheckPayment.PaymentID  "+
                                                  " left outer join GLCheck on GLCheckPayment.CheckID = GLCheck.CheckID " +
                                                  " GROUP by CRMReservation.ReservationID ";

                                 #endregion

                //Returned is CRMBranchReservationStatistic_V
                #region CRMBranchReservationStatistic_V
                                 string Returned = "select ReservationTable.*,TempPaymentTable.TempPaymentSum,InstallmentTable.InstallmentSum,InstallmentPaymentTable.InstallmentPaymentSum " +
                                     ",TempPaymentTable.TempPaymentSum+InstallmentTable.InstallmentSum as WholeTotalValue"+
                                                   " from (" + strSql1 + ") as ReservationTable inner join (" + strSql2 + ") as InstallmentTable on ReservationTable.ReservationID= InstallmentTable.ReservationID " +
                                                   " inner join ("+ strTempPayment +") TempPaymentTable on ReservationTable.ReservationID = TempPaymentTable.ReservationID "+
                                                   " inner join (" + strSql3 + ") as InstallmentPaymentTable on InstallmentTable.ReservationID=InstallmentPaymentTable.ReservationID ";
                                 Returned = " SELECT  HRBranch.BranchNameA, HRBranch.BranchID,SUM(TempPaymentSum)+SUM(InstallmentSum) As TotalValue, SUM(TempPaymentSum) AS TotalTempPayment, " +
                                 " SUM(InstallmentSum) AS TotalInstallmentValue, SUM(case when InstallmentPaymentSum is null then 0 else InstallmentPaymentSum end ) AS TotalInstallmentPaymentSum " +
                                 ",sum(WholeTotalValue) as WholeTotalValue" +
                                 //" SUM(CASE WHEN ReservationID IS NULL THEN 1 ELSE 0 END) AS FreeCount, SUM(CASE WHEN ReservationStatus = 1 THEN 1 ELSE 0 END) "+
                                 //" AS ClosedCount "+
                                 " FROM         ("+ Returned +") as CRMReservationInstallment_V INNER JOIN "+
                                 " HRBranch ON HRBranch.BranchID = CRMReservationInstallment_V.ReservationBranch ";
                                 if(_ID != 0)
                                 {
                                     Returned +=  " WHERE     dbo.HRBranch.BranchID = "+_ID+"";
                                 }
                                Returned += " GROUP BY HRBranch.BranchNameA, HRBranch.BranchID ";
                #endregion
                return Returned;
            }
        }

        public string SearchStr
        {
            get
            {
                string Returned = "";
                ReservationDb objReservationDb = new ReservationDb();
                objReservationDb.BranchID = _ID;
                objReservationDb.ReservationDateRange = _IsDateRange;
                objReservationDb.ReservationStartDate = _DateFrom;
                objReservationDb.ReservationEndDate = _DateTo;
                objReservationDb.ContractingStartDate = _ContractingDateFrom;
                objReservationDb.ContractingEndDate = _ContractingDateTo;
                objReservationDb.ContractingDateRange = _IsContractingDateRange;
                objReservationDb.StatusStartDate = _StatusStartDate;
                objReservationDb.StatusEndDate = _StatusEndDate;
                objReservationDb.StatusDateRange = _StatusDateRange;
                objReservationDb.BranchIDs = _BranchIDs;
                objReservationDb.IsBranchGrouping = true;
                objReservationDb.IsProjectGrouping = _IsProjectGrouping;
                objReservationDb.IsTowerGrouping = _IsTowerGroupping;
                objReservationDb.IsYearGrouping = _IsYearGrouping;
                objReservationDb.IsMonthGrouping = _IsMonthGrouping;
                objReservationDb.IsDayGrouping = _IsDayGrouping;
                objReservationDb.IsReservedStatus = _IsReservedStatus;
                Returned = objReservationDb.SearchSumStr;
                return Returned;
            }
        }
     

        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {

            _ID = int.Parse(objDR["BranchID"].ToString());
            _Name = objDR["BranchNameA"].ToString();
            _TotalValue = double.Parse(objDR["TotalValue"].ToString());
            _TotalTempPayment = double.Parse(objDR["TotalTempPayment"].ToString());
            _TotalInstallmentValue = double.Parse(objDR["TotalInstallmentValue"].ToString());
            _InstallmentPaymentSum = double.Parse(objDR["TotalInstallmentPaymentSum"].ToString());
            _TotalValue = _TotalInstallmentValue + _TotalTempPayment;
            //_ClosedCount = int.Parse(objDR["ClosedCount"].ToString());
            _TotalCount = int.Parse(objDR["TotalCount"].ToString());
            if(objDR.Table.Columns["ProjectName"]!= null)
              _ProjectName = objDR["ProjectName"].ToString();
          if (objDR.Table.Columns["TowerName"] != null)
              _TowerName = objDR["TowerName"].ToString();
            if(objDR.Table.Columns["Y"]!= null && objDR["Y"].ToString()!= "")
                _Y = int.Parse(objDR["Y"].ToString());
            if (objDR.Table.Columns["M"] != null && objDR["M"].ToString() != "")
                _M = int.Parse(objDR["M"].ToString());
            if (objDR.Table.Columns["D"] != null && objDR["D"].ToString() != "")
                _D = int.Parse(objDR["D"].ToString());



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
