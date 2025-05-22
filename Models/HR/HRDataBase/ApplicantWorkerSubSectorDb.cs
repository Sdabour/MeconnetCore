using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerSubSectorDb
    {
        #region PrivateData
        protected int _ApplicantWorkerID;
        protected int _SubSectorID;
        protected int _JobID;
        protected int _JobTitleID;
        protected int _JobNatureID;
        protected int _JobCategoryEstimation;
        protected int _SubOrdinationID;
        protected string _Description;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;
        protected bool _StatusToDate;
        protected string _ApplicantIDs;


        protected DateTime _FromDateSearch;
        protected DateTime _ToDateSearchFrom;
        private bool _StatusFromDateSearch;
        protected bool _StatusToDateSearch;
        protected DateTime _ToDateSearchTo;
        #endregion
        #region Constractors

        public ApplicantWorkerSubSectorDb()
        {
        }

        public ApplicantWorkerSubSectorDb(int intWorkerID, int intSubSectorID)
        {
            _ApplicantWorkerID = intWorkerID;
            _SubSectorID = intSubSectorID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            SetData(objDR);


        }

        public ApplicantWorkerSubSectorDb(DataRow objDR)
        {
            SetData(objDR);
        }

        public ApplicantWorkerSubSectorDb(DataRow objDR, bool DrBelongStatus)
        {
            _ApplicantWorkerID = int.Parse(objDR["ApplicantID"].ToString());
            _SubSectorID = int.Parse(objDR["SubSectorID"].ToString());
            _SubOrdinationID = int.Parse(objDR["SubOrdinationID"].ToString());
            if (objDR["JobID"].ToString() != "")
                _JobID = int.Parse(objDR["JobID"].ToString());
            if (objDR["JobTitleID"].ToString() != "")
                _JobTitleID = int.Parse(objDR["JobTitleID"].ToString());
            if (objDR["JobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDR["JobNatureID"].ToString());
            _Description = objDR["Description"].ToString();
            if (bool.Parse(objDR["StatusFromDate"].ToString()) == false)
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if (bool.Parse(objDR["StatusToDate"].ToString()) == false)
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }


        }

        #endregion
        #region PublicAccessories
        public int ApplicantWorkerID
        {
            set
            {
                _ApplicantWorkerID = value;
            }
            get
            {
                return _ApplicantWorkerID;
            }

        }
        public int SubSectorID
        {
            set
            {
                _SubSectorID = value;
            }
            get
            {
                return _SubSectorID;
            }

        }
        public int SubOrdinationID
        {
            set
            {
                _SubOrdinationID = value;
            }
            get
            {
                return _SubOrdinationID;
            }

        }
        public int JobID
        {
            set
            {
                _JobID = value;
            }
            get
            {
                return _JobID;
            }

        }
        public int JobTitleID
        {
            set
            {
                _JobTitleID = value;
            }
            get
            {
                return _JobTitleID;
            }

        }
        public int JobNatureID
        {
            set
            {
                _JobNatureID = value;
            }
            get
            {
                return _JobNatureID;
            }

        }
        public int JobCategoryEstimation
        {
            set
            {
                _JobCategoryEstimation = value;
            }
            get
            {
                return _JobCategoryEstimation;
            }

        }
        public string Description
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }
        public DateTime FromDate
        {
            set { _FromDate = value; }
            get { return _FromDate; }
        }
        public DateTime ToDate
        {
            set { _ToDate = value; }
            get { return _ToDate; }
        }
        public bool StatusFromDate
        {
            set
            {
                _StatusFromDate = value;
            }
            get
            {
                return _StatusFromDate;
            }
        }
        public bool StatusToDate
        {
            set
            {
                _StatusToDate = value;
            }
            get
            {
                return _StatusToDate;
            }
        }

        public DateTime FromDateSearch
        {
            set { _FromDateSearch = value; }           
        }
        public DateTime ToDateSearchFrom
        {
            set { _ToDateSearchFrom = value; }            
        }
        public DateTime ToDateSearchTo
        {
            set { _ToDateSearchTo = value; }
        }
        public bool StatusFromDateSearch
        {
            set
            {
                _StatusFromDateSearch = value;
            }            
        }
        public bool StatusToDateSearch
        {
            set
            {
                _StatusToDateSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {                
                string Returned = " SELECT     HRApplicantWorkerSubSector.ApplicantID as Applicant,  HRApplicantWorkerSubSector.SubOrdinationID," +
                                  " HRApplicantWorkerSubSector.Description, HRApplicantWorkerSubSector.FromDate, HRApplicantWorkerSubSector.ToDate," +
                                  " JobTypeTable.*, TempSubSectorTable .*,JobTitleTypeTable.* ,JobNatureTypeTable.* ,ApplicantWorkerTable.*" +
                                  " ,HRApplicantWorkerSubSector.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                                  " FROM HRApplicantWorkerSubSector  " +
                                  " lEFT OUTER JOIN (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable ON HRApplicantWorkerSubSector.ApplicantID = ApplicantWorkerTable.ApplicantID " +
                                  " lEFT OUTER JOIN (" + SubSectorDb.SearchStr + ") as TempSubSectorTable ON HRApplicantWorkerSubSector.SubSectorID = TempSubSectorTable.SubSectorID " +
                                  " lEFT OUTER JOIN (" + JobTypeDb.SearchStr + ") as JobTypeTable ON HRApplicantWorkerSubSector.JobID = JobTypeTable.JobID " +
                                  " lEFT OUTER JOIN (" + JobTitleTypeDb.SearchStr + ") as JobTitleTypeTable ON HRApplicantWorkerSubSector.JobTitleID = JobTitleTypeTable.JobTitleID " +
                                  " lEFT OUTER JOIN (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable ON HRApplicantWorkerSubSector.JobNatureID = JobNatureTypeTable.JobNatureID "+
                                  " lEFT OUTER JOIN (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable ON HRApplicantWorkerSubSector.JobCategoryEstimation = JobCategoryEstimationTable.JobCategoryEstimationID ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string strFromDate = "";
                string strToDate = "";
                if (StatusFromDate == true)
                {
                    double FromDate = _FromDate.ToOADate() - 2;
                    strFromDate = FromDate.ToString();
                }
                else
                {
                    strFromDate = "Null";
                }

                if (StatusToDate == true)
                {
                    double ToDate = _ToDate.ToOADate() - 2;
                    strToDate = ToDate.ToString();
                }
                else
                {
                    strToDate = "Null";
                }
                string strReturn = " INSERT INTO HRApplicantWorkerSubSector " +
                            " (ApplicantID, SubSectorID,SubOrdinationID,JobID,JobTitleID,JobNatureID, Description, FromDate, ToDate,JobCategoryEstimation,UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantWorkerID + "," + _SubSectorID + "," + _SubOrdinationID + "," + _JobID + ","+
                            " " + _JobTitleID + "," + _JobNatureID + ",'" + _Description + "'," + strFromDate + "," + strToDate + ","+
                            " " + _JobCategoryEstimation + "," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["Applicant"].ToString() != "")
                _ApplicantWorkerID = int.Parse(objDR["Applicant"].ToString());
            if (objDR["SubSectorID"].ToString() != "")
                _SubSectorID = int.Parse(objDR["SubSectorID"].ToString());
            if (objDR["SubOrdinationID"].ToString() != "")
                _SubOrdinationID = int.Parse(objDR["SubOrdinationID"].ToString());
            if (objDR["JobID"].ToString() != "")
                _JobID = int.Parse(objDR["JobID"].ToString());
            if (objDR["JobTitleID"].ToString() != "")
                _JobTitleID = int.Parse(objDR["JobTitleID"].ToString());
            if (objDR["JobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDR["JobNatureID"].ToString());
            if (objDR["JobCategoryEstimation"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDR["JobCategoryEstimation"].ToString());
            _Description = objDR["Description"].ToString();
            
            if ((objDR["FromDate"].ToString() == "") || (objDR["FromDate"].ToString() == null))
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
                _FromDate = new DateTime(_FromDate.Year, _FromDate.Month, _FromDate.Day);
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
                _ToDate = new DateTime(_ToDate.Year, _ToDate.Month, _ToDate.Day);
            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_SubSectorID != 0)
                strSql = strSql + " and HRApplicantWorkerSubSector.SubSectorID = " + _SubSectorID;
            if (_ApplicantWorkerID != 0)
                strSql = strSql + " and HRApplicantWorkerSubSector.ApplicantID = " + _ApplicantWorkerID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantWorkerSubSector.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            if (_StatusFromDateSearch == true)
            {
                double d = _FromDateSearch.ToOADate() - 2;
                int intFrom = (int)d;
                intFrom = intFrom > d ? intFrom - 1 : intFrom;
                strSql = strSql + " and HRApplicantWorkerSubSector.FromDate >= " + intFrom;
            }
            if (_StatusToDateSearch  == true)
            {

                double d = _ToDateSearchFrom.ToOADate() - 2;
                int intFrom = (int)d;
                intFrom = intFrom > d ? intFrom - 1 : intFrom;


                double dd = _ToDateSearchTo.ToOADate() - 2;
                int intTo = (int)dd;
                intTo = intTo < dd ? intTo + 1 : intTo;
                strSql = strSql + " and HRApplicantWorkerSubSector.ToDate between " + intFrom +" And "+ intTo +"";
            }
            ApplicantWorkerDb.SetCashTable();
            ApplicantWorkerDb.ApplicantIDs = "select ApplicantID from (" + strSql + ") as NativeTable ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void Delete()
        {
            string strSql = "delete from HRApplicantWorkerSubSector where ApplicantID = " + _ApplicantWorkerID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
