using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class ReceiptModelDb
    {
        #region Private Data
        int _ID;
        string _Desc;
        int _AttachmentID;
        bool _IsStopped;
        int _StoppedStatus;
        bool _Direction;
        int _Branch;
        string _BranchName;
        int _ProjectID;
        string _ProjectName;
        #endregion
        #region Constructors
        public ReceiptModelDb()
        { 
        }
        public ReceiptModelDb(DataRow objDr)
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
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }
        }
        public bool IsStopped
        {
            set
            {
                _IsStopped = value;
            }
            get
            {
                return _IsStopped;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int Branch
        {
            set
            {
                _Branch = value;
            }
            get
            {
                return _Branch;
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
        public int ProjectID
        {
            set
            {
                _ProjectID = value;
            }
            get
            {
                return _ProjectID;
            }
        }
        public string ProjectName
        {
            set
            {
                _ProjectName = value;
            }
            get
            {
                return _ProjectName;
            }
        }
        public int StoppedStatus
        {
            set
            {
                _StoppedStatus = value;
            }
        }
        public  string AddStr
        {
            get
            {
                int intIsStopped = _IsStopped ? 1 : 0;
                int intDirection = _Direction ? 1 : 0;
                string Returned = " insert into GLReceiptModel "+
                    " (ModelDirection,ModelBranch,ModelDesc, ModelAttachmentID,ModelProject, ModelIsStopped, UsrIns, TimIns) " +
                    " values ("+intDirection + "," + _Branch +",'"+ _Desc + "',"+ _AttachmentID + "," +
                    _ProjectID + "," +
                    intIsStopped + "," +
                    SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intIsStopped = _IsStopped ? 1 : 0;
                int intDirection = _Direction ? 1 : 0;
                string Returned = " update GLReceiptModel " +
                    " set ModelDirection = " + intDirection +
                    ",ModelBranch=" + _Branch +
                    ",ModelDesc='" + _Desc + "'" +
                    ",ModelProject=" + _ProjectID+
                    ", ModelAttachmentID="+ _AttachmentID +
                    ", ModelIsStopped="+intIsStopped+
                    ", UsrIns="+ SysData.CurrentUser.ID +
                    ", TimIns=GetDate() " +
                    " where ModelID="+ _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strBranch = "SELECT   BranchID AS ModelBranchID, BranchNameA AS ModelBranchName "+
                       " FROM    dbo.HRBranch ";
                string strProject = "SELECT  CellID AS ProjectID, CellNameA AS ProjectName "+
                       " FROM   dbo.RPCell ";
                string Returned = "SELECT  dbo.GLReceiptModel.ModelID, dbo.GLReceiptModel.ModelDesc"+
                    ", dbo.GLReceiptModel.ModelAttachmentID, dbo.GLReceiptModel.ModelIsStopped,dbo.GLReceiptModel.ModelDirection,BranchTable.* " +
                    ",ProjectTable.* " + 
                    " FROM    dbo.GLReceiptModel "+
                      " left outer join ("+ strBranch +") as BranchTable "+
                      " on  dbo.GLReceiptModel.ModelBranch = BranchTable.ModelBranchID "+
                      " left outer join (" + strProject + ") as ProjectTable "+
                      " on dbo.GLReceiptModel.ModelProject = ProjectID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ModelID"].ToString());
            _Desc = objDr["ModelDesc"].ToString();
            _AttachmentID = int.Parse(objDr["ModelAttachmentID"].ToString());
            _IsStopped = bool.Parse(objDr["ModelIsStopped"].ToString());
            _Direction = bool.Parse(objDr["ModelDirection"].ToString());
            if(objDr["ModelBranchID"].ToString()!= "")
                _Branch = int.Parse(objDr["ModelBranchID"].ToString());
            _BranchName = objDr["ModelBranchName"].ToString();
            if (objDr["ProjectID"].ToString() != "")
                _ProjectID = int.Parse(objDr["ProjectID"].ToString());
            _ProjectName = objDr["ProjectName"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "update dbo.GLReceiptModel set Dis = GetDate() where ModelID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if(_StoppedStatus == 2)
                strSql += " and dbo.GLReceiptModel.ModelIsStopped = 0 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetModelProject()
        {
            string strSql = "SELECT   ModelID, ProjectID "+
                  " FROM            dbo.GLReceiptModelProject  where ModelID = "+_ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
