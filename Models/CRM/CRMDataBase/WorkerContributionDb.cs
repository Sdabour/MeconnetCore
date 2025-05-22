using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.HR.HRDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class WorkerContributionDb
    {
        #region Private Data

        protected int _ReservationID;
        protected int _ApplicantID;
        protected double _ContributionPerc;
        protected double _ContributionValue;
        protected double _PaidValue;
        protected bool _Finished;
        string _ReservationIDs;
        #endregion

        #region Constructors
        public WorkerContributionDb()
        { 

        }
        
        public WorkerContributionDb(DataRow objDR)
        {
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
             
             int.TryParse(objDR["ApplicantID"].ToString(),out _ApplicantID);
             double.TryParse(objDR["PaidValue"].ToString(),out _PaidValue);
             double.TryParse(objDR["ContributionPerc"].ToString(),out _ContributionPerc);
            double.TryParse(objDR["ContributionValue"].ToString(), out _ContributionValue);
             bool.TryParse(objDR["Finished"].ToString(),out _Finished);

        }

        #endregion

        #region Public Properties
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
        public double ContributionPerc
        {
            set
            {
                _ContributionPerc = value;
            }
            get
            {
                return _ContributionPerc;
            }

        }
        public double ContributionValue
        {
            set
            {
                _ContributionValue = value;
            }
            get
            {
                return _ContributionValue;
            }

        }
        public double PaidValue
        {
            set
            {
                _PaidValue = value;
            }
            get
            {
                return _PaidValue;
            }

        }
        public bool Finished
        {
            set
            {
                _Finished = value;
            }
            get
            {
                return _Finished;
            }

        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   distinct  ReservationID, ContributionPerc, ContributionValue, PaidValue, Finished,WorkerTable.* "+
                                  " FROM    CRMReservationWorkerContribution inner join (" + SalesManDb.SearchStr + ") as WorkerTable on"+
                                  " CRMReservationWorkerContribution.WorkerID = WorkerTable.ApplicantID ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public DataTable Search()
        {
            string strSql = "";
            strSql = strSql + SearchStr;
            strSql = strSql + "Where (1=1)";
            if (_ReservationID != 0)
                strSql = strSql + "And ReservationID = "+_ReservationID+"";
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + "And ReservationID in (" + _ReservationIDs + ") ";
            if (_ApplicantID != 0)
                strSql = strSql + "And ApplicantID = "+_ApplicantID+"";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
