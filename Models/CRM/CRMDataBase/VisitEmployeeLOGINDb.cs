using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.CRM.CRMDataBase
{
    public class VisitEmployeeLOGINDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public VisitEmployeeLOGINDb()
        { }
        public VisitEmployeeLOGINDb(DataRow objDr)
        {
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
        int _Day;

        public int Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        int _Employee;

        public int Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        int _Branch;

        public int Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }
        string _BranchName;

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }
        int _WorkGroup;

        public int WorkGroup
        {
            get { return _WorkGroup; }
            set { _WorkGroup = value; }
        }
        string _WorkGroupName;

        public string WorkGroupName
        {
            get { return _WorkGroupName; }
            set { _WorkGroupName = value; }
        }
        int _WindowsNo;
        public int WindowsNo
        {
            set => _WindowsNo = value;
            get => _WindowsNo;
        }
        DateTime _LastUpdate;

        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }
        bool _IsCurrentDay;

        public bool IsCurrentDay
        {
            get { return _IsCurrentDay; }
            set { _IsCurrentDay = value; }
        }
        public static string CurrentDay
        {
            get
            {
                string Returned = "CONVERT(NUMERIC,REPLACE(CONVERT(varchar(20), GETDATE(), 102), '.', ''))";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMVisitEmployeeLOGIN (LOGINDay, LOGINEmployee, LOGINBranch, LOGINWorkGroup, LOGINLastUpdate) " +
                    "  SELECT   " + CurrentDay + " AS Day" +
                    ", " + _Employee + " AS Employee, " + _Branch + " AS Branch," + _WorkGroup + " AS WorkGroup" +
                    ", GETDATE() AS LastUpd " +
                    " WHERE NOT EXISTS " +
                    " (SELECT * FROM dbo.CRMVisitEmployeeLOGIN " +
                    " WHERE LOGINDay= " + CurrentDay + " " +
                      " AND LOGINBranch = " + _Branch + " AND LOGINEmployee = " + _Employee +
                      //"  AND LOGINWorkGroup ="+ _WorkGroup +
                      " ) ";
                Returned += "UPDATE dbo.CRMVisitEmployeeLOGIN SET LOGINLastUpdate = GETDATE(),LOGINWorkGroup=" + _WorkGroup +
                    ",LOGINWIndowsNo=" + _WindowsNo +
                     " WHERE LOGINDay= " + CurrentDay + " " +
                      " AND LOGINBranch = " + _Branch + " AND LOGINEmployee = " + _Employee;
                // "  AND LOGINWorkGroup =" + _WorkGroup;
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
                string Returned = "SELECT   dbo.CRMVisitEmployeeLOGIN.LOGINID, dbo.CRMVisitEmployeeLOGIN.LOGINDay, dbo.CRMVisitEmployeeLOGIN.LOGINEmployee, dbo.HRApplicant.ApplicantFirstName AS LOGINEmployeeName, " +
                         " dbo.CRMVisitEmployeeLOGIN.LOGINBranch, dbo.HRBranch.BranchNameA AS LOGINBranchName, dbo.CRMVisitEmployeeLOGIN.LOGINWorkGroup,  " +
                         " dbo.HRWorkGroup.WorkGroupNameA AS LOGINWorkGroupName, dbo.CRMVisitEmployeeLOGIN.LOGINWIndowsNo,dbo.CRMVisitEmployeeLOGIN.LOGINLastUpdate " +
                         " FROM            dbo.CRMVisitEmployeeLOGIN INNER JOIN " +
                          " dbo.HRApplicant ON dbo.CRMVisitEmployeeLOGIN.LOGINEmployee = dbo.HRApplicant.ApplicantID INNER JOIN " +
                         " dbo.HRBranch ON dbo.CRMVisitEmployeeLOGIN.LOGINBranch = dbo.HRBranch.BranchID INNER JOIN " +
                          " dbo.HRWorkGroup ON dbo.CRMVisitEmployeeLOGIN.LOGINWorkGroup = dbo.HRWorkGroup.WorkGroupID";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            int.TryParse(objDr["LOGINID"].ToString(), out _ID);
            int.TryParse(objDr["LOGINDay"].ToString(), out _Day);
            int.TryParse(objDr["LOGINEmployee"].ToString(), out _Employee);
            _EmployeeName = objDr["LOGINEmployeeName"].ToString();
            int.TryParse(objDr["LOGINBranch"].ToString(), out _Branch);
            _BranchName = objDr["LOGINBranchName"].ToString();
            int.TryParse(objDr["LOGINWorkGroup"].ToString(), out _WorkGroup);
            _WorkGroupName = objDr["LOGINWorkGroupName"].ToString();
            DateTime.TryParse(objDr["LOGINLastUpdate"].ToString(), out _LastUpdate);
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
            string strSql = SearchStr + " where LOGINDay = " + CurrentDay;
            if (_Branch != 0)
                strSql += " and LOGINBranch = " + _Branch;
            if (_WorkGroup != 0)
                strSql += " and LOGINWorkGroup=" + _WorkGroup;
            if (_Employee != 0)
                strSql += " and LOGINEmployee=" + _Employee;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
