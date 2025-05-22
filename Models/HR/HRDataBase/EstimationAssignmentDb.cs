using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationAssignmentDb
    {

        #region Constructor
        public EstimationAssignmentDb()
        {
        }
        public EstimationAssignmentDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
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
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        string _Desc;
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        int _EstimationStatement;
        public int EstimationStatement
        {
            set
            {
                _EstimationStatement = value;
            }
            get
            {
                return _EstimationStatement;
            }
        }
        int _Job;
        public int Job
        {
            set
            {
                _Job = value;
            }
            get
            {
                return _Job;
            }
        }
        int _Sector;
        public int Sector
        {
            set
            {
                _Sector = value;
            }
            get
            {
                return _Sector;
            }
        }
        int _EstimationJobCategory;
        public int EstimationJobCategory
        {
            set
            {
                _EstimationJobCategory = value;
            }
            get
            {
                return _EstimationJobCategory;
            }
        }
        int _EstimationApplicant;
        public int EstimationApplicant
        {
            set
            {
                _EstimationApplicant = value;
            }
            get
            {
                return _EstimationApplicant;
            }
        }
        int _EstimationStatementID;
        public int EstimationStatementID
        {
            set
            {
                _EstimationStatementID = value;
            }
            get
            {
                return _EstimationStatementID;
            }
        }
        DateTime _EstimationStatementDate;
        public DateTime EstimationStatementDate
        {
            set
            {
                _EstimationStatementDate = value;
            }
            get
            {
                return _EstimationStatementDate;
            }
        }
        string _EstimationStatementDesc;
        public string EstimationStatementDesc
        {
            set
            {
                _EstimationStatementDesc = value;
            }
            get
            {
                return _EstimationStatementDesc;
            }
        }
        int _JobCategoryEstimationID;
        public int JobCategoryEstimationID
        {
            set
            {
                _JobCategoryEstimationID = value;
            }
            get
            {
                return _JobCategoryEstimationID;
            }
        }
        string _JobCategoryEstimationNameA;
        public string JobCategoryEstimationNameA
        {
            set
            {
                _JobCategoryEstimationNameA = value;
            }
            get
            {
                return _JobCategoryEstimationNameA;
            }
        }
        string _JobCategoryEstimationNameE;
        public string JobCategoryEstimationNameE
        {
            set
            {
                _JobCategoryEstimationNameE = value;
            }
            get
            {
                return _JobCategoryEstimationNameE;
            }
        }
        int _JobCategoryID;
        public int JobCategoryID
        {
            set
            {
                _JobCategoryID = value;
            }
            get
            {
                return _JobCategoryID;
            }
        }
        string _JobCategoryNameA;
        public string JobCategoryNameA
        {
            set
            {
                _JobCategoryNameA = value;
            }
            get
            {
                return _JobCategoryNameA;
            }
        }
        string _JobCategoryNameE;
        public string JobCategoryNameE
        {
            set
            {
                _JobCategoryNameE = value;
            }
            get
            {
                return _JobCategoryNameE;
            }
        }
        int _SectorID;
        public int SectorID
        {
            set
            {
                _SectorID = value;
            }
            get
            {
                return _SectorID;
            }
        }
        string _SectorNameA;
        public string SectorNameA
        {
            set
            {
                _SectorNameA = value;
            }
            get
            {
                return _SectorNameA;
            }
        }
        bool _IsEn;
        public bool IsEn { set => _IsEn = value; get => _IsEn; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HREstimationAssignment (AssignmentDate,AssignmentDesc,AssignmentEstimationStatement,AssignmentJob,AssignmentSector,AssignmentEstimationJobCategory,AssignmentEstimationApplicant,UsrIns,TimIns) values (" + (Date.ToOADate() - 2).ToString() + ",'" + Desc + "'," + EstimationStatement + "," + Job + "," + Sector + "," + EstimationJobCategory + "," + EstimationApplicant+ "," + SysData.CurrentUser.ID  + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HREstimationAssignment set AssignmentDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",AssignmentDesc='" + Desc + "'" +
           ",AssignmentEstimationStatement=" + EstimationStatement + "" +
           ",AssignmentJob=" + Job + "" +
           ",AssignmentSector=" + Sector + "" +
           ",AssignmentEstimationJobCategory=" + EstimationJobCategory + "" +
           ",AssignmentEstimationApplicant=" + EstimationApplicant + "" +
          ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where AssignmentID ="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HREstimationAssignment set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT        dbo.HREstimationAssignment.AssignmentID, dbo.HREstimationAssignment.AssignmentDate, dbo.HREstimationAssignment.AssignmentDesc, dbo.HREstimationAssignment.AssignmentEstimationStatement, 
                         dbo.HREstimationAssignment.AssignmentJob, dbo.HREstimationAssignment.AssignmentSector, dbo.HREstimationAssignment.AssignmentEstimationJobCategory, dbo.HREstimationAssignment.AssignmentEstimationApplicant,AssignmentEstimationIsEn, 
                         dbo.HREstimationStatement.EstimationStatementID, dbo.HREstimationStatement.EstimationStatementDate, dbo.HREstimationStatement.EstimationStatementDesc, dbo.HRJobCategoryEstimation.JobCategoryEstimationID, 
                         dbo.HRJobCategoryEstimation.JobCategoryEstimationNameA, dbo.HRJobCategoryEstimation.JobCategoryEstimationNameE, dbo.HRJobCategory.JobCategoryID, dbo.HRJobCategory.JobCategoryNameA, 
                         dbo.HRJobCategory.JobCategoryNameE, dbo.HRSector.SectorID, dbo.HRSector.SectorNameA
FROM            dbo.HREstimationAssignment LEFT OUTER JOIN
                         dbo.HRJobCategory ON dbo.HREstimationAssignment.AssignmentJob = dbo.HRJobCategory.JobCategoryID LEFT OUTER JOIN
                         dbo.HREstimationStatement ON dbo.HREstimationAssignment.AssignmentEstimationStatement = dbo.HREstimationStatement.EstimationStatementID LEFT OUTER JOIN
                         dbo.HRSector ON dbo.HREstimationAssignment.AssignmentSector = dbo.HRSector.SectorID LEFT OUTER JOIN
                         dbo.HRJobCategoryEstimation ON dbo.HREstimationAssignment.AssignmentEstimationJobCategory = dbo.HRJobCategoryEstimation.JobCategoryEstimationID ";
                return Returned;
            }
        }
        DataTable _GroupTable;
        public DataTable GroupTable { set => _GroupTable= value; }
        DataTable _ElementTable;
        public DataTable ElementTable { set => _ElementTable = value; }
        DataTable _JobNatureTable;
        public DataTable JobNatureTable
        { set => _JobNatureTable = value; }
        #region Search Criteria
        string _ApplicantJobCategoryIDs;
        public string ApplicantJobCategoryIDs
        { set => _ApplicantJobCategoryIDs = value; }
        string _ApplicantJobCategoryEstimationIDs;
        public string ApplicantJobCategoryEstimationIDs
        {
            set => _ApplicantJobCategoryEstimationIDs = value;
        }
        string _ApplicantSectorIDs;
        public string ApplicantSectorIDs
        { set => _ApplicantSectorIDs = value; }
        string _ApplicantJobNatureIDs;
        public string ApplicantJobNatureIDs
        { set => _ApplicantJobNatureIDs = value; }
        string _IDsStr;
        public string IDsStr
        { set => _IDsStr = value; }


        #endregion
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["AssignmentID"] != null)
                int.TryParse(objDr["AssignmentID"].ToString(), out _ID);

            if (objDr.Table.Columns["AssignmentDate"] != null)
                DateTime.TryParse(objDr["AssignmentDate"].ToString(), out _Date);

            if (objDr.Table.Columns["AssignmentDesc"] != null)
                _Desc = objDr["AssignmentDesc"].ToString();

            if (objDr.Table.Columns["AssignmentEstimationStatement"] != null)
                int.TryParse(objDr["AssignmentEstimationStatement"].ToString(), out _EstimationStatement);

            if (objDr.Table.Columns["AssignmentJob"] != null)
                int.TryParse(objDr["AssignmentJob"].ToString(), out _Job);

            if (objDr.Table.Columns["AssignmentSector"] != null)
                int.TryParse(objDr["AssignmentSector"].ToString(), out _Sector);

            if (objDr.Table.Columns["AssignmentEstimationJobCategory"] != null)
                int.TryParse(objDr["AssignmentEstimationJobCategory"].ToString(), out _EstimationJobCategory);

            if (objDr.Table.Columns["AssignmentEstimationApplicant"] != null)
                int.TryParse(objDr["AssignmentEstimationApplicant"].ToString(), out _EstimationApplicant);

            if (objDr.Table.Columns["EstimationStatementID"] != null)
                int.TryParse(objDr["EstimationStatementID"].ToString(), out _EstimationStatementID);

            if (objDr.Table.Columns["EstimationStatementDate"] != null)
                DateTime.TryParse(objDr["EstimationStatementDate"].ToString(), out _EstimationStatementDate);

            if (objDr.Table.Columns["EstimationStatementDesc"] != null)
                _EstimationStatementDesc = objDr["EstimationStatementDesc"].ToString();

            if (objDr.Table.Columns["JobCategoryEstimationID"] != null)
                int.TryParse(objDr["JobCategoryEstimationID"].ToString(), out _JobCategoryEstimationID);

            if (objDr.Table.Columns["JobCategoryEstimationNameA"] != null)
                _JobCategoryEstimationNameA = objDr["JobCategoryEstimationNameA"].ToString();

            if (objDr.Table.Columns["JobCategoryEstimationNameE"] != null)
                _JobCategoryEstimationNameE = objDr["JobCategoryEstimationNameE"].ToString();

            if (objDr.Table.Columns["JobCategoryID"] != null)
                int.TryParse(objDr["JobCategoryID"].ToString(), out _JobCategoryID);

            if (objDr.Table.Columns["JobCategoryNameA"] != null)
                _JobCategoryNameA = objDr["JobCategoryNameA"].ToString();

            if (objDr.Table.Columns["JobCategoryNameE"] != null)
                _JobCategoryNameE = objDr["JobCategoryNameE"].ToString();

            if (objDr.Table.Columns["SectorID"] != null)
                int.TryParse(objDr["SectorID"].ToString(), out _SectorID);

            if (objDr.Table.Columns["SectorNameA"] != null)
                _SectorNameA = objDr["SectorNameA"].ToString();
            if (objDr.Table.Columns["AssignmentEstimationIsEn"] != null)
                bool.TryParse(objDr["AssignmentEstimationIsEn"].ToString(), out _IsEn);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinGroup();
            JoinElement();
            JoinJobNature();
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinGroup();
            JoinElement();
            JoinJobNature();
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where dbo.HREstimationAssignment.Dis is null ";
            strSql += " order by AssignmentID desc ";
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinGroup()
        {
            if (_GroupTable == null || _GroupTable.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            string strSql = " delete from HREstimationAssignmentElement where AssignmentID="+_ID;
            strSql = "delete from  HREstimationAssignmentGroupElement where AssignmentID=" +_ID;
            arrStr.Add(strSql);
            EstimationAssignmentGroupDb objDb;
            foreach (DataRow objDr in _GroupTable.Rows)
            {
                objDb = new EstimationAssignmentGroupDb(objDr);
                objDb.AssignmentID = ID;
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void JoinElement()
        {
            if (_ElementTable == null || _ElementTable.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            string strSql = " delete from HREstimationAssignmentElement where AssignmentID=" + _ID;
            
            arrStr.Add(strSql);
            EstimationAssignmentElementDb objDb;
            foreach (DataRow objDr in _ElementTable.Rows)
            {
                objDb = new EstimationAssignmentElementDb(objDr);
                objDb.ID = ID;
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void JoinJobNature()
        {
            if (_JobNatureTable == null || _JobNatureTable.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            string strSql = " delete from HREstimationAssignmentJobNature where AssignmentID=" + _ID;

            arrStr.Add(strSql);
            
            foreach (DataRow objDr in _JobNatureTable.Rows)
            {
                strSql = "insert into HREstimationAssignmentJobNature (AssignmentID,AssignmentJobNature) values("+_ID +","+objDr["AssignmentJobNature"].ToString()+")";
                arrStr.Add(strSql);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetJobNature()
        {
            DataTable Returned = new DataTable();
            string strSql = @"select JobNatureTable.*,HREstimationAssignmentJobNature.AssignmentID from HREstimationAssignmentJobNature
 inner join (" + JobNatureTypeDb.SearchStr + @") JobNatureTable 
  on HREstimationAssignmentJobNature.AssignmentJobNature = JobNatureTable.JobNatureID ";
 
            if(_ID!= 0)
              strSql+=" where AssignmentID ="+_ID;
           if(_IDsStr!= null && _IDsStr!= "")
                strSql += " where AssignmentID in (" + _IDsStr+")";
            return Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            
        }
        #endregion
    }
}
