using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.UMS.UMSDataBase
{
    public class WorkGroupDb : BaseSingleDb
    {
        #region Private Data
        int _Type;
        DataTable _EmployeeTable;
        #endregion
        #region Constructors
        public WorkGroupDb()
        { }
        public WorkGroupDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        int _VisitRangeStart;
        public int VisitRangeStart
        {
            set => _VisitRangeStart = value;
            get => _VisitRangeStart;
        }
        int _VisitRangeEnd;
        public int VisitRangeEnd
        {
            set => _VisitRangeEnd = value;
            get => _VisitRangeEnd;
        }
        string _VisitTypeIDs;
        public string VisitTypeIDs
        { set => _VisitTypeIDs = value; }
        public DataTable EmployeeTble
        {
            set
            {
                _EmployeeTable = value;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "insert into HRWorkGroup (WorkGroupType,WorkGroupNameA, WorkGroupNameE) " +
                    " values (" + _Type + ",'" + _NameA + "','" + _NameE + "') ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "update HRWorkGroup set WorkGroupType = " + _Type +
                    ", WorkGroupNameA='" + _NameA + "'" +
                    ", WorkGroupNameE ='" + _NameE + "' " +
                    " where WorkGroupID= " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update HRWorkGroup set Dis = GetDate()" +
                     " where WorkGroupID= " + _ID;
                Returned += @" 
update            dbo.CRMVisitType
set VistTypeWorkGroup = 0
WHERE   (VistTypeWorkGroup = " + _ID + @")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   WorkGroupID,WorkGroupType, WorkGroupNameA, WorkGroupNameE " +
                      " FROM dbo.HRWorkGroup ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["WorkGroupID"].ToString());
            _NameA = objDr["WorkGroupNameA"].ToString();
            _NameE = objDr["WorkGroupNameE"].ToString();
            if (objDr["WorkGroupType"].ToString() != "")
                _Type = int.Parse(objDr["WorkGroupType"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = AddStr;
            _ID = BaseDb.UMSBaseDb.InsertIdentityTable(strSql);
            JoinVisitType();
            JoinEmployee();
        }
        public override void Edit()
        {
            string strSql = EditStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
            JoinVisitType();
            JoinEmployee();
        }
        public override void Delete()
        {
            string strSql = DeleteStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where (Dis is null) ";

            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        public void JoinEmployee()
        {
            if (_EmployeeTable == null)
                return;
            List<string> arrStr = new List<string>();
            string strSql = "delete  FROM dbo.HRWorkGroupApplicant WHERE (WorkGroupID = " + _ID + ")";
            arrStr.Add(strSql);
            foreach (DataRow objDr in _EmployeeTable.Rows)
            {

                strSql = "insert into HRWorkGroupApplicant (WorkGroupID, WorkGroupApplicant) values (" + _ID + "," +
                    objDr["EmployeeID"].ToString() + ") ";
                arrStr.Add(strSql);
            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);
        }

        public DataTable GetWorkGroupEmployee()
        {
            string strSql = "SELECT     dbo.HRWorkGroupApplicant.WorkGroupApplicantID, dbo.HRWorkGroupApplicant.WorkGroupID, " +
                " dbo.HRWorkGroupApplicant.WorkGroupApplicant,EmployeeTable.* " +
                 " FROM         dbo.HRWorkGroupApplicant  " +
                 " INNER JOIN (" + EmployeeDb.SearchStr + ") AS EmployeeTable  " +
                 " ON dbo.HRWorkGroupApplicant.WorkGroupApplicant = EmployeeTable.ApplicantID " +
                 " WHERE    (1=1)  ";
            strSql += " and (dbo.HRWorkGroupApplicant.WorkGroupID = " + _ID + ")";
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }

        public DataTable GetVisitType()
        {
            string strSql = @"SELECT      VisitTypeID, VisitTypeNameA, Dis
FROM dbo.CRMVisitType
  WHERE(Dis IS NULL)";
            if (_ID != 0)
                strSql += " and VistTypeWorkGroup = " + _ID;

            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        public void JoinVisitType()
        {
            if (_ID == 0)
                return;

            string strSql = @"update            dbo.CRMVisitType
set VistTypeWorkGroup = 0
WHERE        (Dis IS NULL) AND (VistTypeWorkGroup = " + _ID + @") AND (NOT (VisitTypeID IN (" + _VisitTypeIDs + ")))";
            strSql += @"
update            dbo.CRMVisitType
set VistTypeWorkGroup = " + _ID + @"
WHERE        (Dis IS NULL)  AND (VisitTypeID IN (" + _VisitTypeIDs + "))";
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
