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
    public class ReservationBranchStatisticDb
    {
        #region PrivateData
        protected string _BranchName;
        protected int _TotalCount;
        protected int _ContractCount;
        protected int _DeservedCount;
        protected int _TempDeserved;
        protected int _EndingCount;
        protected int _CanselationCount;
        protected int _CessionCount;
        
        
        #region PrivateData For Search
        protected int _CellID;
        protected int _BranchID;
        protected bool _IsDateRange;
        protected DateTime _dtFrom;
        protected DateTime _dtTo;

        protected bool _IsContractingDateRange;
        protected DateTime _ContractingDateFrom;
        protected DateTime _ContractingDateTo;

        #endregion
        #endregion
        #region Constractors
        public ReservationBranchStatisticDb()
        {

        }
        public ReservationBranchStatisticDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string BranchName
        {
            set { _BranchName = value; }
            get { return _BranchName; }
        }
        public int ContractCount
        {
            set { _ContractCount = value; }
            get { return _ContractCount; }
            
        }
        public int DeservedCount
        {
            set { _DeservedCount = value; }
            get { return _DeservedCount; }
            
        }
        public int EndingCount
        {
            set { _EndingCount = value; }
            get { return _EndingCount; }
            
        }
        public int CanselationCount
        {
            set { _CanselationCount = value; }
            get { return _CanselationCount; }
            
        }
        public int CessionCount
        {
            set { _CessionCount = value; }
            get { return _CessionCount; }
            
        }
        public int TotalValue
        {
            set { _TotalCount = value; }
            get { return _TotalCount; }

        }
        public int TempDeserved
        {
            set
            {
                _TempDeserved = value;
            }
            get
            {
                return _TempDeserved;
            }
        }
        #region Accessorice For Search
        public int CellID
        {
            set { _CellID = value; }
            
        }
        public int BranchID
        {
            set
            {
                _BranchID = value; 
            }
        }
        public DateTime DtFrom
        {
            set
            {
                _dtFrom = value; 
            }
        }
        public DateTime DtTo
        {
            set 
            {
                _dtTo = value; 
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

        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
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
        


        #endregion
        #region Set Only Accessorice
        public  string SearchStr
        {
            get
            {
                double dblDateFrom = _dtFrom.ToOADate() - 2;
                dblDateFrom = SysUtility.Approximate(dblDateFrom, 1, ApproximateType.Down);
                int intTempStartDate = (int)dblDateFrom;
                double dblDateTimeto = _dtTo.ToOADate() - 2;
                dblDateTimeto = SysUtility.Approximate(dblDateTimeto, 1, ApproximateType.Up);
                int intTempEndDate = (int)dblDateTimeto;
               

                string Returned = " SELECT     dbo.HRBranch.BranchNameA, COUNT(dbo.CRMReservation.ReservationID) AS TotalCount, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 1 THEN 1 ELSE 0 END) AS TempDeserved, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 2 THEN 1 ELSE 0 END) AS Deserved, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 3 THEN 1 ELSE 0 END) AS Contracting, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 4 THEN 1 ELSE 0 END) AS Ending, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 5 THEN 1 ELSE 0 END) AS Cession, "+
                      " SUM(CASE WHEN dbo.CRMReservation.ReservationStatus = 6 THEN 1 ELSE 0 END) AS Canselation"+
                      " FROM        dbo.CRMUnit   INNER JOIN CRMReservationUnit on CRMUnit.UnitID = CRMReservationUnit.UnitID "+
                      "  INNER JOIN"+
                      " dbo.CRMReservation ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservation.ReservationID LEFT OUTER JOIN"+
                      " dbo.HRBranch ON dbo.CRMReservation.ReservationBranch = dbo.HRBranch.BranchID Where 1 = 1 ";
                string strUnitCell = " select CRMUnitCell.UnitID from CRMUnitCell inner join RPCell on CRMUnitCell.CellID = RPCell.CellID where (1=1)";      
                if(_CellID != 0)
                      {
                          strUnitCell += " and RPCell.CellFamilyID=" + _CellID;
                        Returned += " and     (CRMUnit.UnitID in ( "+strUnitCell+"))";
                      }
                      if(_BranchID != 0)
                      {
                          Returned += " and dbo.HRBranch.BranchID = "+_BranchID+"";
                      }
                      //if (_IsDateRange)
                      //{
                         
                      //    Returned += " and Convert(float,dbo.CRMReservation.ReservationDate) >= " + intTempStartDate + " and Convert(float,dbo.CRMReservation.ReservationDate) < " + intTempEndDate + "";
                      //}
                      //if (_IsContractingDateRange)
                      //{
                      //    dblDateFrom = _ContractingDateFrom.ToOADate() - 2;
                      //    intTempStartDate = (int)SysUtility.Approximate(dblDateFrom, 1, ApproximateType.Down);
                      //    dblDateTimeto = _ContractingDateTo.ToOADate() - 2;
                      //    intTempEndDate = (int)SysUtility.Approximate(dblDateTimeto, 1, ApproximateType.Up);
                      //    Returned += " and Convert(float,dbo.CRMReservation.ReservationContractingDate) >= " + intTempStartDate + " and Convert(float,dbo.CRMReservation.ReservationContractingDate) < " + intTempEndDate + "";
                      //}

                      #region 
                      if (_IsDateRange || _IsContractingDateRange)
                      {
                          string strSearchDate = "";
                          if (_IsDateRange)
                          {
                              double dblStart = _dtFrom.ToOADate() - 2;
                              dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                              double dblEnd = _dtTo.ToOADate() - 2;

                              dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);



                              strSearchDate = "  (ReservationDate >= " + dblStart + " and ReservationDate <" + dblEnd + ") ";

                          }
                          if (_IsContractingDateRange)
                          {

                              double dblStart = _ContractingDateFrom.ToOADate() - 2;
                              dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                              double dblEnd = _ContractingDateTo.ToOADate() - 2;
                              dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                              if (strSearchDate != "")
                                  strSearchDate += " or ";
                              strSearchDate += "(ReservationContractingDate >=" + dblStart +
                                  " and ReservationContractingDate < " + dblEnd + ") ";

                          }
                          if (strSearchDate != "")
                              Returned += " and " + strSearchDate;
                      }

                      #endregion





                      Returned += " GROUP BY  dbo.HRBranch.BranchNameA, dbo.HRBranch.BranchNameA ";
                return Returned;
            }

        }
        #endregion
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _BranchName = objDR["BranchNameA"].ToString();
            _TempDeserved = int.Parse(objDR["TempDeserved"].ToString());
            _DeservedCount = int.Parse(objDR["Deserved"].ToString());
            _ContractCount = int.Parse(objDR["Contracting"].ToString());
            _EndingCount = int.Parse(objDR["Ending"].ToString());
            _CanselationCount = int.Parse(objDR["Canselation"].ToString());
            _CessionCount = int.Parse(objDR["Cession"].ToString());
            _TotalCount = int.Parse(objDR["TotalCount"].ToString());
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
