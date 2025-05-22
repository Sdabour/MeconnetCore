using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
namespace SharpVision.CRM.CRMBusiness
{
    public class VisitEmployeeLOGINBiz
    {
        #region Private Data
        VisitEmployeeLOGINDb _LoginDb;
        #endregion
        #region Constructors
        public VisitEmployeeLOGINBiz()
        {
            _LoginDb = new VisitEmployeeLOGINDb();
        }
        public VisitEmployeeLOGINBiz(DataRow objDr)
        {
            _LoginDb = new VisitEmployeeLOGINDb(objDr);
            _BranchBiz = new UMSBranchBiz();
            _BranchBiz.ID = _LoginDb.Branch;
            _BranchBiz.Name = _LoginDb.BranchName;

            _EmployeeBiz = new EmployeeBiz();
            _EmployeeBiz.ID = _LoginDb.Employee;
            _EmployeeBiz.Name = _LoginDb.EmployeeName;

            _GroupBiz = new WorkGroupBiz();
            _GroupBiz.ID = _LoginDb.WorkGroup;
            _GroupBiz.NameA = _LoginDb.WorkGroupName;

        }
        #endregion
        #region Public Properties
        UMSBranchBiz _BranchBiz;

        public UMSBranchBiz BranchBiz
        {
            get
            {
                if (_BranchBiz == null)
                    _BranchBiz = new UMSBranchBiz();
                return _BranchBiz;
            }
            set { _BranchBiz = value; }
        }
        EmployeeBiz _EmployeeBiz;

        public EmployeeBiz EmployeeBiz
        {
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
            set { _EmployeeBiz = value; }
        }
        WorkGroupBiz _GroupBiz;

        public WorkGroupBiz GroupBiz
        {
            get
            {
                if (_GroupBiz == null)
                    _GroupBiz = new WorkGroupBiz();
                return _GroupBiz;
            }
            set { _GroupBiz = value; }
        }
        public int ID
        {
            set
            {
                _LoginDb.ID = value;
            }
            get
            {
                return _LoginDb.ID;
            }
        }


        public int Day
        {
            get { return _LoginDb.Day; }
            set { _LoginDb.Day = value; }
        }
        public DateTime LastUpdate
        {
            get { return _LoginDb.LastUpdate; }
            set { _LoginDb.LastUpdate = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
