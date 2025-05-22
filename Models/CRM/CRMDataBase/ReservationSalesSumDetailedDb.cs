using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.RP.RPDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationSalesSumDetailedDb
    {
        #region Private Data 
        protected string _BranchName;
        protected string _WorkerFirstName;
        protected string _UnitFullName;
        protected int _ReservationID;
        protected DateTime _ResevationDate;
        protected DateTime _ContractingDate;
        protected DateTime _DelevaryDate;
        protected DateTime _ContractingStartDate;
        protected DateTime _ContractingEndDate;
        protected double _CachPrice;
        protected double _ReservationValue;
        protected int _Status;
        protected string _CustomerFullName;

        #region Private Data For Search
        protected int _CellID;
        protected bool _IsDateRange;
        protected bool _IsContractingDateRange;
        protected DateTime _ReservationStartDate;
        protected DateTime _ReservationEndDate;
        protected int _ApplicantID;
        protected int _BranchID;
        #endregion

        #endregion

        #region Constractors
        public ReservationSalesSumDetailedDb()
        {

        }
        public ReservationSalesSumDetailedDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Pubplic Accessorice
        public DateTime ContractFromDate
        {
            set
            {
                _ContractingStartDate = value;
            }
            get
            {
                return _ContractingStartDate;
            }
        }
        public DateTime ContractEndDate
        {
            set
            {
                _ContractingEndDate = value;
            }
            get
            {
                return _ContractingEndDate;
            }
        }
        public string BranchName
        {
            set
            {
                _BranchName = value;
            }
            get
            {
                return _BranchName;
            }
        }
        public string WorkerFirstName
        {
            set
            {
                _WorkerFirstName = value;
            }
            get
            {
                return _WorkerFirstName;
            }
        }
        public string UnitFullName
        {
            set
            {
                _UnitFullName = value;
            }
            get
            {
                return _UnitFullName;
            }
        }
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }
        }
        public DateTime ResevationDate
        {
            set
            {
                _ResevationDate = value;
            }
            get
            {
                return _ResevationDate;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _ContractingDate = value;
            }
            get
            {
                return _ContractingDate;
            }
        }
        public DateTime DelevaryDate
        {
            set
            {
                _DelevaryDate = value;
            }
            get
            {
                return _DelevaryDate;
            }
        }
        public double CachPrice
        {
            set
            {
                _CachPrice = value;
            }
            get
            {
                return _CachPrice;
            }
        }
        public double ReservationValue
        {
            set
            {
                _ReservationValue = value;
            }
            get
            {
                return _ReservationValue;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public string CustomerFullName
        {
            set
            {
                _CustomerFullName = value;
            }
            get
            {
                return _CustomerFullName;
            }
        }

        #region Private Accessorice For Search
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
                _ReservationStartDate = value;
            }
            get
            {
                return _ReservationStartDate;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _ReservationEndDate = value;
            }
            get
            {
                return _ReservationEndDate;
            }
        }
        public int WorkerID 
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }
        }
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public bool IsContractingDate
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
        #endregion

        public  string SearchStr
        {
            get
            {
                double dblDateFrom = _ReservationStartDate.ToOADate() - 2;
                int intTempStartDate = (int) dblDateFrom;
                double dblDateTimeto = _ReservationEndDate.ToOADate() - 2;
                int intTempEndDate = (int) dblDateTimeto;

                double dblDateContractingFrom = _ContractingStartDate.ToOADate() - 2;
                int intTempContractingStartDate = (int) dblDateContractingFrom;
                double dblDateContractingTimeto = _ContractingEndDate.ToOADate() - 2;
                int intTempContractingEndDate = (int) dblDateContractingTimeto;
                string strCellQuery = "SELECT     dbo.CRMReservation.ReservationID " +
                   " FROM         dbo.CRMUnit INNER JOIN " +
                    " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                    " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID INNER JOIN " +
                    " dbo.CRMReservation ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservation.ReservationID INNER JOIN " +
                    " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID where 1=1 ";
                string strContribution = "SELECT  dbo.CRMReservation.ReservationID, CASE WHEN COUNT(HRApplicant.ApplicantID) " +
                       " > 0 THEN COUNT(distinct HRApplicant.ApplicantID) ELSE 1 END AS WorkerCount " +
                       " FROM         dbo.CRMReservation LEFT OUTER JOIN " +
                       " dbo.CRMReservationWorkerContribution ON dbo.CRMReservation.ReservationID = dbo.CRMReservationWorkerContribution.ReservationID " +
                       " left outer join  dbo.HRApplicant ON dbo.CRMReservationWorkerContribution.WorkerID = dbo.HRApplicant.ApplicantID " +
                       " GROUP BY dbo.CRMReservation.ReservationID ";

                string Returned = " SELECT     HRBranch.BranchNameA, HRApplicant.ApplicantFirstName, CRMUnit.UnitFullName, CRMCustomer.CustomerFullName, CRMReservation.ReservationID, "+
                      " CRMReservation.ReservationDate, CRMReservation.ReservationContractingDate,CRMReservation.ReservationDeliveryDate, CRMReservation.ReservationValue, "+
                      " CRMReservation.ReservationStatus"+
                      " FROM         HRBranch INNER JOIN"+
                      " CRMReservation INNER JOIN"+
                      " CRMReservationCustomer ON CRMReservation.ReservationID = CRMReservationCustomer.ReservationID ON "+
                      " HRBranch.BranchID = CRMReservation.ReservationBranch INNER JOIN"+
                      " CRMCustomer ON CRMReservationCustomer.CustomerID = CRMCustomer.CustomerID INNER JOIN"+
                      " CRMUnitCell INNER JOIN"+
                      " CRMUnit ON CRMUnitCell.UnitID = CRMUnit.UnitID INNER JOIN"+
                      " RPCell ON CRMUnitCell.CellID = RPCell.CellID ON CRMReservation.ReservationID = CRMUnit.CurrentReservation INNER JOIN"+
                      " CRMReservationWorkerContribution ON CRMReservation.ReservationID = CRMReservationWorkerContribution.ReservationID INNER JOIN"+
                      " HRApplicant ON CRMReservationWorkerContribution.WorkerID = HRApplicant.ApplicantID Where 1 = 1";
                      if(_CellID != 0)
                      {
                          Returned += " and (RPCell.CellFamilyID = "+_CellID+") ";
                      }
                      if(_BranchID != 0)
                      {
                          Returned += " and (HRBranch.BranchID = "+_BranchID+") ";
                      }
                      if(_ApplicantID != 0)
                      {
                          Returned += " and (HRApplicant.ApplicantID = "+_ApplicantID+") ";
                      }
                      if (_IsDateRange)
                      {
                          Returned += " and dbo.CRMReservation.ReservationDate >= " + intTempStartDate + " and dbo.CRMReservation.ReservationDate < " + intTempEndDate + "";
                      }
                      if (_IsContractingDateRange)
                      {

                          Returned += " and dbo.CRMReservation.ReservationContractingDate >= " + intTempContractingStartDate +
                              " and dbo.CRMReservation.ReservationContractingDate < " + intTempContractingEndDate + "";
                      }
                      if (_IsDateRange || _IsContractingDateRange)
                      {
                          string strSearchDate = "";
                          if (_IsDateRange)
                          {
                              double dblStart = _ReservationStartDate.ToOADate() - 2;
                              dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                              double dblEnd = _ReservationEndDate.ToOADate() - 2;

                              dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);



                              strSearchDate = "  (ReservationDate >= " + dblStart + " and ReservationDate <" + dblEnd + ") ";

                          }
                          if (_IsDateRange)
                          {

                              double dblStart = _ContractingStartDate.ToOADate() - 2;
                              dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                              double dblEnd = _ContractingStartDate.ToOADate() - 2;
                              dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                              if (strSearchDate != "")
                                  strSearchDate += " or ";
                              strSearchDate += "(ReservationContractingDate >=" + dblStart +
                                  " and ReservationContractingDate < " + dblEnd + ") ";

                          }
                          if (strSearchDate != "")
                              Returned += " and ( " + strSearchDate + ")";
                      }

                      Returned += " ORDER BY HRApplicant.ApplicantFirstName,CRMReservation.ReservationStatus "; 
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _BranchName = objDR["BranchNameA"].ToString();
            _WorkerFirstName = objDR["ApplicantFirstName"].ToString();
            _UnitFullName = objDR["UnitFullName"].ToString();
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _ResevationDate = DateTime.Parse(objDR["ReservationDate"].ToString());
            _ContractingDate = DateTime.Parse(objDR["ReservationContractingDate"].ToString());
            _ReservationValue = double.Parse(objDR["ReservationValue"].ToString());
            
            _Status = int.Parse(objDR["ReservationStatus"].ToString());
            _CustomerFullName = objDR["CustomerFullName"].ToString();
            _DelevaryDate = DateTime.Parse(objDR["ReservationDeliveryDate"].ToString());
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
