using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.UMS.UMSDataBase
{
    public class EmployeeDb
    {
        #region Private Data
        protected int _ID;
        protected string _Code;
        protected string _Name;
        protected int _UserID;
        protected string _FamousName;
        protected string _ShortName;
        DateTime _StartDate;
        public DateTime StartDate
        { set => _StartDate = value; get => _StartDate; }
        protected int _Status;
        protected int _BranchID;
        protected string _BranchName;
        protected int _CofferID;
        protected string _CofferName;
        protected string _CofferCode;
        protected DateTime _EndDate;
        protected bool _IsEnded;
        protected int _WorkingStatus;
        protected string _DepartmentIDs;
        protected string _IDs;
        string _CodeLike;
        int _DepartmentID;
        int _WorkGroupID;
        #endregion
        #region Constructors
        public EmployeeDb()
        { 

        }
        public EmployeeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
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
        public string FamousName
        {
            set
            {
                _FamousName = value;
            }
            get
            {
                if (_FamousName == null)
                    _FamousName = "";
                return _FamousName;
            }
        }
        public string ShortName
        {
            set
            {
                _ShortName = value;
            }
            get
            {
                if (_ShortName == null)
                    _ShortName = "";
                return _ShortName;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
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
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public string BranchName
        {
            set
            {
                _BranchName = value;
            }
            get
            {
                return _BranchName;
            }
        }
        public int DepartmentID
        {
            set
            {
                _DepartmentID = value;
            }
            get
            {
                return _DepartmentID;
            }
        }
        public int WorkGroupID
        {
            set
            {
                _WorkGroupID = value;
            }
            get
            {
                return _WorkGroupID;
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
        public string CofferName
        {
            set
            {
                _CofferName = value;
            }
            get
            {
                return _CofferName;
            }
        }
        public string CofferCode
        {
            set
            {
                _CofferCode = value;
            }
            get
            {
                return _CofferCode;
            }
        }
        public string DepartmentIDs
        {
            set
            {
                _DepartmentIDs = value;
            }

        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public int WorkingStatus
        {
            set
            {
                _WorkingStatus = value;
            }
        }
        public string CodeLike
        {
            set
            {
                _CodeLike = value;
            }
        }
        public bool IsEnded
        {
            get
            {
                return _IsEnded;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "";

                return Returned;
            }

        }
        int _SectorID;
        public int SectorID { set => _SectorID = value; }

        #region SubSector
        int _SubSectorID;
        public int SubSectorID
        {
            set => _SubSectorID = value;
            get => _SubSectorID;
        }
        int _JobTitleID;
        public int JobTitleID
        {
            set => _JobTitleID = value;
            get => _JobTitleID;
        }
        int _JobID;
        public int JobID
        {
            set => _JobID = value;
            get => _JobID;
        }
        int _JobNatureID;
        public int JobNatureID
        {
            set => _JobNatureID = value;
            get => _JobNatureID;
        }
        string _Description;
        public string Description
        {
            set => _Description = value;
            get => _Description;
        }
        DateTime _FromDate;
        public DateTime FromDate
        {
            set => _FromDate = value;
            get => _FromDate;
        }
        public string AddCurrentSubsectorStr
        {
            get
            {
                string strID = _ID == 0 ? "@ID" : _ID.ToString();
                string Returned = @" insert into HRApplicantWorkerCurrentSubSector (ApplicantID,SubSectorID,JobTitleID,JobID,JobNatureID,Description) 
  select  "+ strID  + " as ID1," + SubSectorID + " as SubSector1," + JobTitleID + " as JobTitle1," + JobID + " as JobID1," + JobNatureID + " as JobNatureID1,'" + Description +@"' as Desc1 
   FROM     dbo.HRApplicant LEFT OUTER JOIN
                  dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID
WHERE  (dbo.HRApplicant.ApplicantID = "+strID+@") AND (dbo.HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID IS NULL) ";
                if(ID!=0)
                Returned += @"  update dbo.HRApplicantWorkerCurrentSubSector
 set SubSectorID="+_SubSectorID+@", JobTitleID="+_JobTitleID+@", JobID="+_JobID+@", JobNatureID="+_JobNatureID+@", Description='"+_Description+@"' WHERE(ApplicantID = "+ID+") ";
                return Returned;
            }
        }
        void SetCurrentSubSectorData(DataRow objDr)
        {

            if (objDr.Table.Columns["SubSectorID"] != null)
                int.TryParse(objDr["SubSectorID"].ToString(), out _SubSectorID);

            if (objDr.Table.Columns["JobTitleID"] != null)
                int.TryParse(objDr["JobTitleID"].ToString(), out _JobTitleID);

            if (objDr.Table.Columns["JobID"] != null)
                int.TryParse(objDr["JobID"].ToString(), out _JobID);

            if (objDr.Table.Columns["JobNatureID"] != null)
                int.TryParse(objDr["JobNatureID"].ToString(), out _JobNatureID);

            if (objDr.Table.Columns["Description"] != null)
                _Description = objDr["Description"].ToString();

            if (objDr.Table.Columns["FromDate"] != null)
                DateTime.TryParse(objDr["FromDate"].ToString(), out _FromDate);
        }
        #endregion
        public string SectorSearchStr
        {
            get
            {
                string Returned = @"WITH SectorTable(SectorID, SectorNameA, SectorParentID, SLevel) AS (SELECT        SectorID, SectorNameA, SectorParentID, 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector
                                                                                                                                                           WHERE        (SectorID IN (" + _SectorID + @"))
                                                                                                                                                           UNION ALL
                                                                                                                                                           SELECT        HRSector_1.SectorID, HRSector_1.SectorNameA, HRSector_1.SectorParentID, SectorTable_2.SLevel + 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector AS HRSector_1 INNER JOIN
                                                                                                                                                                                    SectorTable AS SectorTable_2 ON HRSector_1.SectorParentID = SectorTable_2.SectorID)  select SectorTable.* from SectorTable ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strSales = "SELECT   distinct dbo.CRMSalesMan.ApplicantID AS SalesManID, dbo.HRBranch.BranchID AS SalesBranchID, dbo.HRBranch.BranchNameA AS SalesBranchName "+
                    " FROM   dbo.CRMSalesMan INNER JOIN "+
                    " dbo.HRBranch ON dbo.CRMSalesMan.BranchID = dbo.HRBranch.BranchID ";
                //strSales = "";
                string strCurrentBranch = "SELECT     CurrentTAble.ApplicantID CurrentApplicant, dbo.HRBranch.BranchID AS ApplicantBranchID"+
                    ", dbo.HRBranch.BranchNameA AS ApplicantBranchName,dbo.HRSubSector.SectorID as DepartmentID " +
                   " FROM         (SELECT     ApplicantID, MAX(SubSectorID) AS ApplicantSubSector "+
                      " FROM         dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 "+
                      "  GROUP BY ApplicantID) AS CurrentTAble "+
                      " INNER JOIN  dbo.HRSubSector "+
                      " ON CurrentTAble.ApplicantSubSector = dbo.HRSubSector.SubSectorID "+
                      " INNER JOIN  dbo.HRSubSectorBranch  ON dbo.HRSubSector.SubSectorID = dbo.HRSubSectorBranch.SubSectorID INNER JOIN "+
                      " dbo.HRBranch ON dbo.HRSubSectorBranch.BranchID = dbo.HRBranch.BranchID ";
                string strWorkGroup = "SELECT derivedtbl_1.WorkGroupApplicant, dbo.HRWorkGroupApplicant.WorkGroupID "+
                        " FROM   dbo.HRWorkGroupApplicant INNER JOIN "+
                        " (SELECT     WorkGroupApplicant, MAX(WorkGroupApplicantID) AS MaxWorkGroupApplicant "+
                         " FROM         dbo.HRWorkGroupApplicant AS HRWorkGroupApplicant_1 "+
                         " GROUP BY WorkGroupApplicant) AS derivedtbl_1 ON dbo.HRWorkGroupApplicant.WorkGroupApplicantID = derivedtbl_1.MaxWorkGroupApplicant AND  "+
                         " dbo.HRWorkGroupApplicant.WorkGroupApplicant = derivedtbl_1.WorkGroupApplicant "; 
               
                string Returned = "SELECT  dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode"+
                    ", dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicant.ApplicantFamousName,dbo.HRApplicant.ApplicantShortName " +
                      ", dbo.HRApplicant.ApplicantNameComp, dbo.HRApplicantWorker.ApplicantUser, dbo.HRApplicantWorker.ApplicantStatusID "+
                      ",dbo.HRApplicantWorker.ApplicantEndDate,SalesManTable.*"+
                      ",CurrentBranchTable.*,WorkGroupTable.WorkGroupID  " +
                      " FROM   dbo.HRApplicant INNER JOIN "+
                      " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID"+
                      " left outer join (" + strSales + ") as SalesManTable on  dbo.HRApplicant.ApplicantID = SalesManTable.SalesManID "+
                      " left outer join (" + strCurrentBranch + ") as CurrentBranchTable "+
                      " on dbo.HRApplicant.ApplicantID = CurrentBranchTable.CurrentApplicant  "+
                      " left outer join (" + strWorkGroup + ") as WorkGroupTable "+
                      " on  dbo.HRApplicant.ApplicantID = WorkGroupTable.WorkGroupApplicant ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ApplicantID"].ToString()); 
            _Code = objDr["ApplicantCode"].ToString();
            _Name = objDr["ApplicantFirstName"].ToString();
            _FamousName = objDr["ApplicantFamousName"].ToString();
            _ShortName = objDr["ApplicantShortName"].ToString();
            if(objDr["ApplicantUser"].ToString()!= "")
            _UserID = int.Parse( objDr["ApplicantUser"].ToString());
             int.TryParse(objDr["ApplicantStatusID"].ToString(),out _Status);
            if (objDr["SalesBranchID"].ToString() != "")
            {
                _BranchID = int.Parse(objDr["SalesBranchID"].ToString());
                _BranchName = objDr["SalesBranchName"].ToString();
            }
            else if (objDr["CurrentApplicant"].ToString() != "")
            {
                _BranchID = int.Parse(objDr["ApplicantBranchID"].ToString());
                _BranchName = objDr["ApplicantBranchName"].ToString();
            }
            _IsEnded = false;
            if (objDr["ApplicantEndDate"].ToString() != "")
            {
               _EndDate = DateTime.Parse(objDr["ApplicantEndDate"].ToString());
               _IsEnded = true;

            }
            if (objDr.Table.Columns["DepartmentID"] != null && objDr["DepartmentID"].ToString() != "")
                _DepartmentID = int.Parse(objDr["DepartmentID"].ToString());
            if (objDr.Table.Columns["WorkGroupID"] != null && objDr["WorkGroupID"].ToString() != "")
                _WorkGroupID = int.Parse(objDr["WorkGroupID"].ToString());
 
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            string strSql = @"insert into HRApplicant (ApplicantFirstName,ApplicantFamousName,ApplicantShortName,ApplicantNameComp) values ('" + _Name + "','" + _FamousName + "','" + ShortName +"','"+BaseDb.ReplaceStringComp(_Name) + "') ";
            strSql += @" declare @ID int;
     set @ID = (select @@IDENTITY as NewID) ;
    insert into HRApplicantWorker(ApplicantID,ApplicantCode,ApplicantUser,ApplicantStatusID)
     values (@ID,'" + _Code +"',"+ _UserID +",1)";
            strSql += AddCurrentSubsectorStr;
             BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual void Edit()
        {
 
        }
        public virtual void Delete()
        {
            if (_ID == 0)
                return;
            string strSql = "update HRApplicantWorker set Dis=GetDate() where ApplicantID ="+_ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
       
        public void EditUserID()
        {
            if (_ID == 0)
                return;
            string strSql = "update HRApplicantWorker set ApplicantUser =" + _UserID +
                   " WHERE     (ApplicantID = " + _ID + ")";
            strSql += " update HRApplicantWorker set ApplicantUser =0 "  +
                   " WHERE     (ApplicantID <> " + _ID + ") and ApplicantUser ="+ _UserID +" ";
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);

        }

        public virtual DataTable Search()
        {
            string strSql = SearchStr + " where (HRApplicantWorker.Dis is null)  ";
            if (_ID != 0)
                strSql += " and HRApplicant.ApplicantID=" + _ID;
            if (_IDs != null && _IDs != "")
                strSql += " and HRApplicant.ApplicantID in(" + _IDs + ")";
            if (_Code != null && _Code != "") 
                strSql += " and HRApplicantWorker.ApplicantCode like '%" + _Code + "%' ";
            if (_Name != null && _Name != "")
                strSql += " and (dbo.ReplaceStringComp(HRApplicant.ApplicantFirstName) like '%" + BaseDb.ReplaceStringComp(_Name) +
                    "%' or dbo.ReplaceStringComp(ApplicantFamousName) like '%" + BaseDb.ReplaceStringComp(_Name) + "%' ) ";

            if (_SectorID != 0)
            {
                DataTable dtSector = BaseDb.UMSBaseDb.ReturnDatatable(SectorSearchStr);
                string strSectoRIDs = "";
                foreach (DataRow objDr in dtSector.Rows)
                {
                    if (strSectoRIDs != "")
                        strSectoRIDs += ",";
                    strSectoRIDs += objDr["SectorID"].ToString();
                }

                strSql += " and DepartmentID in (" + strSectoRIDs + ")";
            }
            if (_UserID != 0)
            {
                strSql += " and dbo.HRApplicantWorker.ApplicantUser = " + _UserID;
            }
            if (_WorkingStatus != 0)
            {
                if (_WorkingStatus == 1)
                    strSql += " and HRApplicantWorker.ApplicantStatusID=1 ";
                else
                    strSql += " and HRApplicantWorker.ApplicantStatusID<>1 ";
            }
            if (_DepartmentIDs != null && _DepartmentIDs != "")
            {
                string strDepartment = "SELECT   distinct  dbo.HRApplicantWorkerCurrentSubSector.ApplicantID "+
                    " FROM   dbo.HRApplicantWorkerCurrentSubSector INNER JOIN " +
                    " dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID ";
                strDepartment += " where dbo.HRSubSector.SectorID in (" + _DepartmentIDs  + ")";
                strSql = "select EmployeeTable.* from ("+ strSql +
                    ") as EmployeeTable inner join ("+ strDepartment +") as DepartmentTable on EmployeeTable.ApplicantID= DepartmentTable.ApplicantID ";
            }
        
              
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
