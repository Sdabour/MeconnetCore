using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class VisitStatusDb
    {
        #region Private Data


        #endregion
        #region Constructors
        public VisitStatusDb()
        { }
        public VisitStatusDb(DataRow objDr)
        {
            if (objDr.Table.Columns["VisitStatusVisitID"] == null)
                return;
            if (objDr["VisitStatusVisitID"].ToString() == "")
                return;

            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ID;
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
        int _VisitID;

        public int VisitID
        {
            get { return _VisitID; }
            set { _VisitID = value; }
        }
        string _VisitIDs;

        public string VisitIDs
        {
            get { return _VisitIDs; }
            set { _VisitIDs = value; }
        }
        int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        int _FunctionalStatus;

        public int FunctionalStatus
        {
            get { return _FunctionalStatus; }
            set { _FunctionalStatus = value; }
        }

        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
       
        string _UsrName;

        public string UsrName
        {
            get { return _UsrName; }
            set { _UsrName = value; }
        }
       


        public string AddStr
        {
            get
            {
                string strVisit = _VisitID != 0 ? _VisitID.ToString() : "@ContactID";
             
                string Returned = "insert into CRMVisitStatus (VisitID,VisitStatus,VisitFunctionalStatus, VisitStatusComment"+
                    ", VisitStatusAplicant" +
                    ", UsrIns, TimIns)" +
                    " values (" + strVisit + "," + _Status + "," + _FunctionalStatus  + ",'" + _Desc + "'," + _EmployeeID + "," +
                   SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
   
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strEmployee = "SELECT        ApplicantID as EmployeeID, ApplicantFirstName as EmployeeName " +
                      " FROM            dbo.HRApplicant ";
                string Returned = "SELECT  StatusID,VisitID VisitStatusVisitID, VisitStatus,VisitFunctionalStatus" +
                    ", VisitStatusComment, VisitStatusAplicant, UsrIns as StatusUsrIns, TimIns as StatusTimIns " +
                    ",EmployeeTable.*,StatusUserTable.UN as ENStatusUN,'' as DEStatusUN " +
                       " FROM            dbo.CRMVisitStatus " +
                       " left outer join (" + strEmployee + ") as EmployeeTable " +
                       " on CRMVisitStatus.VisitStatusAplicant = EmployeeTable.EmployeeID  " +
                       " left outer join UMSUser as StatusUserTable  " +
                       " on CRMVisitStatus.UsrIns = StatusUserTable.UID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["VisitStatusVisitID"].ToString() == "")
                return;
            _VisitID = int.Parse(objDr["VisitStatusVisitID"].ToString());
            _ID = int.Parse(objDr["StatusID"].ToString());
            //StatusID,VisitID VisitStatusVisitID, VisitStatus"+
            //      ", VisitStatusComment, VisitStatusAplicant, UsrIns as StatusUsrIns, TimIns as StatusTimIns " +
            _Status = int.Parse(objDr["VisitStatus"].ToString());
            _Desc = objDr["VisitStatusComment"].ToString();
           int.TryParse(objDr["EmployeeID"].ToString(),out _EmployeeID);
            _EmployeeName = objDr["EmployeeName"].ToString();
            _Date = DateTime.Parse(objDr["StatusTimIns"].ToString());
            SharpVision.UMS.UMSDataBase.UserDb.SetUserDecrypted(ref objDr, "ENStatusUN", "DEStatusUN", "%");
            _UsrName = objDr["DEStatusUN"].ToString();
            


        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_VisitID != 0)
                strSql += " and VisitID =" + _VisitID;
            if (_VisitIDs != null && _VisitIDs != "")
                strSql += " and VisitID in (" + _VisitIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
