using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.UMS.UMSDataBase
{
    public class UMSBranchDb
    {
        #region Private Data
        int _ID;
        string _Name;
        #endregion
        #region Constructor
        public UMSBranchDb()
        { 
        }
        public UMSBranchDb(DataRow objDr)
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
        int _StopStatus;

        public int StopStatus
        {
            get { return _StopStatus; }
            set { _StopStatus = value; }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT BranchID, CASE WHEN "+BaseSingleDb.Language+" = 0 THEN BranchNameA ELSE BranchNameE END AS BranchName "+
                       " FROM   dbo.HRBranch";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["BranchID"].ToString());
            _Name = objDr["BranchName"].ToString();
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr+ " where Dis is null and BranchIsStopped =0 ";
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
