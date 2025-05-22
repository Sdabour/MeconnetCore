using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class EmployeeSectorAssignmentDb
    {
        #region Private Data
     
       

        #endregion
        #region Constructors
        public EmployeeSectorAssignmentDb()
        {
 
        }
        public EmployeeSectorAssignmentDb(DataRow objDr)
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
        int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        int _SectorID;

        public int SectorID
        {
            get { return _SectorID; }
            set { _SectorID = value; }
        }
        bool _IsPermanent;

        public bool IsPermanent
        {
            get { return _IsPermanent; }
            set { _IsPermanent = value; }
        }
        DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        DataTable _SectorTable;

        public DataTable SectorTable
        {
            get { return _SectorTable; }
            set { _SectorTable = value; }
        }
        public string AddStr
        {
            get
            {
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string strEnd = dblEndDate > 0 ? dblEndDate.ToString() : "NULL";
                string strIsPermanent = _IsPermanent ? "1" : "0";
                string Returned = " insert into HREmployeeSectorAssignment (AssignmentEmployeeID, AssignmentSectorID, AssignmentIsPermanent"+
                    ", AssignmenEndDate, UsrIns, TimIns) "+
                    " values ("+ _EmployeeID + "," + _SectorID + "," +strIsPermanent + "," + strEnd + "," +
                    SysData.CurrentUser.ID  +",GetDate()) ";
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
                string Returned = "SELECT   AssignmentID, AssignmentEmployeeID, AssignmentSectorID, AssignmentIsPermanent"+
                    ", AssignmenEndDate,SectorTable.* "+
                       " FROM            dbo.HREmployeeSectorAssignment "+
                       " inner join ("+ SectorDb.SearchStr +") as SectorTable "+
                       " on HREmployeeSectorAssignment.AssignmentSectorID = SectorTable.SectorID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            //AssignmentIsPermanent, AssignmenEndDate,
            _ID = int.Parse(objDr["AssignmentID"].ToString());
            _EmployeeID = int.Parse(objDr["AssignmentEmployeeID"].ToString());
            if(objDr.Table.Columns["AssignmentSectorID"]!= null && objDr["AssignmentSectorID"].ToString()!="")
            _SectorID = int.Parse(objDr["AssignmentSectorID"].ToString());
            else if(objDr.Table.Columns["SectorID"]!= null)
                _SectorID = int.Parse(objDr["SectorID"].ToString());
            _IsPermanent = false;
            bool.TryParse(objDr["AssignmentIsPermanent"].ToString(), out _IsPermanent);
            _EndDate = DateTime.Now;
            DateTime.TryParse(objDr["AssignmenEndDate"].ToString(), out _EndDate);

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
            string strSql = SearchStr + "  where ( AssignmentIsPermanent = 1 or AssignmenEndDate > GetDate() )";
            if (_EmployeeID != 0)
                strSql += " and AssignmentEmployeeID = " + _EmployeeID ;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AssignSector()
        {
            if (_SectorTable == null || _EmployeeID==0)
                return;

            EmployeeSectorAssignmentDb objDb;
            List<string> arrStr = new List<string>();
            string strTemp = " delete FROM            dbo.HREmployeeSectorAssignment "+
                " WHERE        (AssignmentEmployeeID = "+ _EmployeeID +
                ") AND ( (AssignmentIsPermanent = 1)  or (AssignmenEndDate >= GETDATE()))";
            arrStr.Add(strTemp);
            foreach (DataRow objDr in _SectorTable.Rows)
            {
                objDb = new EmployeeSectorAssignmentDb(objDr);
                objDb.EmployeeID = _EmployeeID;
                arrStr.Add(objDb.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public DataTable GetAllAssignedSector()
        {
            DataTable Returned = new DataTable();
            if (_EmployeeID != 0)
            {
                string strSector = "WITH SectorTable (SectorID,SectorNameA) as "+
                    " ( "+
                    " SELECT AssignmentSectorID,dbo.HRSector.SectorNameA FROM dbo.HREmployeeSectorAssignment  "+
                     " INNER JOIN dbo.HRSector ON dbo.HREmployeeSectorAssignment.AssignmentSectorID = dbo.HRSector.SectorID "+
                     " where (dbo.HREmployeeSectorAssignment.AssignmentEmployeeID = "+ _EmployeeID + @") and (  (AssignmentIsPermanent = 1) OR
                         (AssignmenEndDate > GETDATE())) " +
                     " UNION ALL  "+
                     " SELECT dbo.HRSector.SectorID,dbo.HRSector.SectorNameA "+
                      " FROM dbo.HRSector INNER JOIN SectorTable ON dbo.HRSector.SectorParentID = SectorTable.SectorID and dbo.HRSector.SectorParentID!= HRSector.SectorID " +
                      " "+
                      " ) " +
                      " SELECT SectorTable1.* "+
                      " FROM SectorTable  inner join ("+ SectorDb.SearchStr +") as SectorTable1 "+
                      " on SectorTable.SectorID = SectorTable1.SectorID ";
                Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSector);

            }

            return Returned;
        }
        #endregion
    }
}
