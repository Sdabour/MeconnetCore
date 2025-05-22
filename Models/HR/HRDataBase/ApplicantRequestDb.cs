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
    public class ApplicantRequestDb
    {
        #region Private Data
        protected int _ApplicantRequestID;
        protected int _ApplicantID;
        protected int _RequestID;
        protected int _Accepted; 
        protected DateTime _ApplyDate;
        bool _StatusDelete;

        protected string _ApplicantName;
        protected string _ApplicantFamousName;
        protected string _ApplicantCode;
        protected string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantRequestDb()
        {
           
        }
        public ApplicantRequestDb(DataRow objDR)
        {
            SetData(objDR);
        }
        public ApplicantRequestDb(int intApplicantID, int intRequestID)
        {
            _ApplicantID = intApplicantID;
            _RequestID = intRequestID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            SetData(objDR);
        }
        public ApplicantRequestDb(DataRow objDR, bool DrBelongStatus)
        {
            _ApplicantRequestID = int.Parse(objDR["ApplicantRequestID"].ToString());
            _RequestID = int.Parse(objDR["RequestID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _ApplyDate = DateTime.Parse(objDR["ApplyDate"].ToString());
            _Accepted = int.Parse(objDR["Accepted"].ToString());
            //_StatusDelete = bool.Parse(objDR["StatusDelete"].ToString());
        }        
#endregion
        #region Public Properties
        public int ApplicantRequestID
        {
            set { _ApplicantRequestID = value; }
            get { return _ApplicantRequestID; }
        }
        public int ApplicantID
        {
            set { _ApplicantID = value; }
            get { return _ApplicantID; }           
        }

        public int RequestID
        {
            set { _RequestID = value; }
            get { return _RequestID; }           
        }

        public int Accepted
        {
            set { _Accepted = value; }
            get { return _Accepted; }
        }

        public DateTime ApplyDate
        {
            set { _ApplyDate = value; }
            get { return _ApplyDate; }            
        }

        public bool StatusDelete
        {
            get { return _StatusDelete; }
            set { _StatusDelete = value; }
        }

        public string ApplicantName
        {
            set
            {
                _ApplicantName = value;
            }
        }
        public string ApplicantFamousName
        {
            set
            {
                _ApplicantFamousName = value;
            }
        }
        public string ApplicantCode
        {
            set
            {
                _ApplicantCode = value;
            }
        }

        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     HRApplicantRequest.ApplicantRequestID,HRApplicantRequest.Applicant, HRApplicantRequest.ApplyDate, HRApplicantRequest.Accepted ,RequestTable.*,ApplicantTable.*" +
                                   " FROM         HRApplicantRequest INNER JOIN"+
                                   " (" + JobRequestDb.SearchStr + ")as RequestTable On RequestTable.RequestID=HRApplicantRequest.RequestID INNER JOIN" +
                                   " (" + ApplicantDb.SearchStr + ")as ApplicantTable On ApplicantTable.ApplicantID=HRApplicantRequest.Applicant";
                return strReturn;
            }
        }

        public  string AddStr
        {
            get
            {
                string ApplyDateStr = "";
                double d = _ApplyDate.ToOADate() - 2;
                ApplyDateStr = d.ToString();
                string strReturn = " INSERT INTO HRApplicantRequest " +
                                   " (Applicant, RequestID, ApplyDate, Accepted) " +
                                   " VALUES     (" + _ApplicantID + "," + _RequestID + "," + ApplyDateStr + "," + _Accepted + ")";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {               
                string strReturn = " UPDATE    HRApplicantRequest "+
                                   " SET  Accepted = "+ _Accepted +""+
                                   " WHERE (Applicant = " + _ApplicantID + ") AND (RequestID = " + _RequestID + ")";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " delete from HRApplicantRequest where Applicant = " + _ApplicantID + " ";
                if (_RequestID != 0)
                {
                    strReturn  =strReturn + " and RequestID =" + _RequestID + "";
                }
                
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
            _ApplicantRequestID = int.Parse(objDR["ApplicantRequestID"].ToString());
            _RequestID = int.Parse(objDR["RequestID"].ToString());
            _ApplicantID = int.Parse(objDR["Applicant"].ToString());
            _ApplyDate = DateTime.Parse(objDR["ApplyDate"].ToString());
            _Accepted = int.Parse(objDR["Accepted"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            _ApplicantRequestID=SysData.SharpVisionBaseDb.InsertIdentityTable(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_RequestID != 0)
                strSql = strSql + " and HRApplicantRequest.RequestID = " + _RequestID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantRequest.Applicant = " + _ApplicantID;
            if (_ApplicantName != "" && _ApplicantName != null)
                strSql = strSql + " AND (ApplicantNameComp Like '%" + SysUtility.ReplaceStringComp(_ApplicantName) + "%')";
            if (_ApplicantFamousName != "" && _ApplicantFamousName != null)
                strSql = strSql + " AND (ApplicantFamousName Like '%" + _ApplicantFamousName + "%')";
            if (_ApplicantCode != "" && _ApplicantCode != null)
                strSql = strSql + " AND (ApplicantCode Like '%" + _ApplicantCode + "%')";
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and Applicant in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantRequest");
        }
        #endregion
    }
}
