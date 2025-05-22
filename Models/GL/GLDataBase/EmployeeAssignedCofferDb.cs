using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.GL.GLDataBase
{
    public class EmployeeAssignedCofferDb
    {
        #region Private Data
        int _EmployeeID;
        int _CofferID;
        int _UserID;
        bool _IsPermanent;
        DateTime _StartDate;
        DateTime _EndDate;
        DataTable _AssignedCofferTable;
        #endregion
        #region Constructors
        public EmployeeAssignedCofferDb()
        { 
        }
        public EmployeeAssignedCofferDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get
            {
                return _EmployeeID;
            }
        }
        public int CofferID
        {
            set
            {
                _CofferID = value;
            }
            get
            {
                return _CofferID;
            }
        }
        public int UserID
        {
            set
            {
                _UserID = value;
            }
            get
            {
                return _UserID;
            }
        }
        public bool IsPermanent
        {
            set
            {
                _IsPermanent = value;
            }
            get
            {
                return _IsPermanent;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        public DataTable AssignedCofferTable
        {
            set
            {
                _AssignedCofferTable = value;
            }
        }
        public string AddStr
        {
            get 
            {

                string strStartDate = _IsPermanent ? "null" : SysUtility.Approximate(_StartDate.ToOADate()-2,1,ApproximateType.Down).ToString();
                string strEndDate =  _IsPermanent ? "null" : SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down).ToString();
                int intIsPermanent = _IsPermanent ? 1 : 0;
                string Returned = "insert into HRApplicantWorkerAssignedCoffer ( ApplicantID, CofferID, UserID, IsPermanent, StartDate, EndDate"+
                    ", UsrIns, TimIns)" +
                    " values (" + _EmployeeID + "," + _CofferID + "," + _UserID + "," + intIsPermanent + "," + strStartDate + 
                    "," + strEndDate + "," + SysData.CurrentUser.ID +  ",GetDate()) ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT      UserID, IsPermanent, StartDate, EndDate,EmployeeTable.*,CofferTable.* " +
                      " FROM   dbo.HRApplicantWorkerAssignedCoffer "+
                      " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable "+
                      " on HRApplicantWorkerAssignedCoffer.ApplicantID = EmployeeTable.ApplicantID  "+
                      " inner join (" + CofferDB.SearchStr +  ") as CofferTable "+
                      " on  HRApplicantWorkerAssignedCoffer.CofferID = CofferTable.CofferID "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if(objDr["ApplicantID"].ToString()!= "")
              _EmployeeID = int.Parse(objDr["ApplicantID"].ToString());
            _CofferID = int.Parse(objDr["CofferID"].ToString());
            _UserID = int.Parse(objDr["UserID"].ToString());
            _IsPermanent = bool.Parse(objDr["IsPermanent"].ToString());
            if (!_IsPermanent)
            {
                _StartDate = DateTime.Parse(objDr["StartDate"].ToString());
                _EndDate = DateTime.Parse(objDr["EndDate"].ToString());
            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinEmployeeCoffer()
        {
            if (_AssignedCofferTable == null)
                return;
            string[] arrStr = new string[_AssignedCofferTable.Rows.Count + 1];
            arrStr[0] = "delete FROM  dbo.HRApplicantWorkerAssignedCoffer "+
                " WHERE     (ApplicantID = " + _EmployeeID + ") ";
            EmployeeAssignedCofferDb objDb;
            int intIndex = 1;
            foreach (DataRow objDr in _AssignedCofferTable.Rows)
            {
                objDb = new EmployeeAssignedCofferDb(objDr);
                objDb.EmployeeID = _EmployeeID;
                arrStr[intIndex] = objDb.AddStr;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
