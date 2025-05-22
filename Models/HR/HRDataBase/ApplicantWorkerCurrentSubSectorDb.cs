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
    public class ApplicantWorkerCurrentSubSectorDb 
    {
        #region PrivateData
        protected int _ApplicantWorkerID;
        protected int _SubSectorID;

        protected int _JobID;
        protected int _JobNatureID;
        protected int _JobTitleID;
        protected int _JobCategoryEstimation;
        protected int _SubOrdinationID;
        protected string _Description;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;     
        protected bool _StatusToDate;
        string _ApplicantIDs;
        #endregion
        #region Constractors

        public ApplicantWorkerCurrentSubSectorDb()
        {
        }

        public ApplicantWorkerCurrentSubSectorDb(int intWorkerID, int intSubSectorID)
        {
            _ApplicantWorkerID = intWorkerID;
            _SubSectorID = intSubSectorID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            SetData(objDR);                   
        }

        public ApplicantWorkerCurrentSubSectorDb(DataRow objDR)
        {            
            SetData(objDR);               
        }

        public ApplicantWorkerCurrentSubSectorDb(DataRow objDR, bool DrBelongStatus)
        {
            _ApplicantWorkerID = int.Parse(objDR["ApplicantWorkerID"].ToString());
            _SubSectorID = int.Parse(objDR["SubSectorID"].ToString());
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
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT      HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID ,HRApplicantWorkerCurrentSubSector.ApplicantID,  HRApplicantWorkerCurrentSubSector.SubOrdinationID," +
                      " HRApplicantWorkerCurrentSubSector.Description, HRApplicantWorkerCurrentSubSector.FromDate, HRApplicantWorkerCurrentSubSector.ToDate," +
                      " JobTypeTable.*, SubSectorTable.*,JobTitleTypeTable.* ,JobNatureTypeTable.* "+
                      " ,HRApplicantWorkerCurrentSubSector.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                      " FROM HRApplicantWorkerCurrentSubSector INNER JOIN " +
                      "(" + SubSectorDb.SearchStr + ") as SubSectorTable ON HRApplicantWorkerCurrentSubSector.SubSectorID = SubSectorTable.SubSectorID " +
                      " lEFT OUTER JOIN (" + JobTypeDb.SearchStr + ") as JobTypeTable ON HRApplicantWorkerCurrentSubSector.JobID = JobTypeTable.JobID " +
                      " lEFT OUTER JOIN (" + JobTitleTypeDb.SearchStr + ") as JobTitleTypeTable ON HRApplicantWorkerCurrentSubSector.JobTitleID = JobTitleTypeTable.JobTitleID " +
                      " lEFT OUTER JOIN (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable ON HRApplicantWorkerCurrentSubSector.JobNatureID = JobNatureTypeTable.JobNatureID "+
                      " lEFT OUTER JOIN (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable ON HRApplicantWorkerCurrentSubSector.JobCategoryEstimation = JobCategoryEstimationTable.JobCategoryEstimationID ";
                return Returned;
            }
        }
        public static string SimpleSearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerCurrentSubSector.ApplicantID," +
                      " JobTable.*, SubSectorTable.* " +
                      " FROM HRApplicantWorkerCurrentSubSector INNER JOIN " +
                      " (" + JobDb.SearchStr + ") as JobTable ON HRApplicantWorkerCurrentSubSector.JobID = JobTable.JobID INNER JOIN" +
                      "(" + SubSectorDb.SearchStr + ") as SubSectorTable ON HRApplicantWorkerCurrentSubSector.SubSectorID = SubSectorTable.SubSectorID";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {                              
                string strFromDate = "";
                string strToDate="";
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
                string strReturn = " INSERT INTO HRApplicantWorkerCurrentSubSector " +
                            " (ApplicantID, SubSectorID,SubOrdinationID,JobID,JobTitleID,JobNatureID, Description, FromDate, ToDate,JobCategoryEstimation,UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantWorkerID + "," + _SubSectorID + "," + _SubOrdinationID + "," + _JobID + ","+ _JobTitleID +","+ _JobNatureID +",'" + _Description + "',"+
                            " " + strFromDate + "," + strToDate + ","+ _JobCategoryEstimation +"," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ApplicantID"].ToString() != "")
                _ApplicantWorkerID = int.Parse(objDR["ApplicantID"].ToString());
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
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
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
        #region Public Methods
        public  void Add()
        {                      
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public  void Edit()
        {
            
        }
        public  DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_SubSectorID != 0)
                strSql = strSql + " and HRApplicantWorkerCurrentSubSector.SubSectorID = " + _SubSectorID;
            if (_ApplicantWorkerID != 0)
                strSql = strSql + " and HRApplicantWorkerCurrentSubSector.ApplicantID = " + _ApplicantWorkerID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql = strSql + " and HRApplicantWorkerCurrentSubSector.ApplicantID  in (" + _ApplicantIDs + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantWorkerCurrentSubSector where ApplicantID = " + _ApplicantWorkerID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        public void EditJobCategoryEstimation(int intApplicantID,int intJobCategoryEstimationID)
        {
            string strSql = "Update HRApplicantWorkerCurrentSubSector Set JobCategoryEstimation = " + intJobCategoryEstimationID + " where ApplicantID = " + intApplicantID +"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion


    }
}
