using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class EmployeeAssignedCofferBiz
    {
        #region Private Data
        EmployeeBiz _EmployeeBiz;
        CofferBiz _CofferBiz;
        EmployeeAssignedCofferDb _AssignedCofferDb;
        #endregion
        #region Constructors
        public EmployeeAssignedCofferBiz()
        {
            _AssignedCofferDb = new EmployeeAssignedCofferDb();
        }
        public EmployeeAssignedCofferBiz(DataRow objDr)
        {
            _AssignedCofferDb = new EmployeeAssignedCofferDb(objDr);
            _EmployeeBiz = new EmployeeBiz(objDr);
            _CofferBiz = new CofferBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int UserID
        {
            set
            {
                _AssignedCofferDb.UserID = value;
            }
            get
            {
                return _AssignedCofferDb.UserID;
            }
        }
        public bool IsPermanent
        {
            set
            {
                _AssignedCofferDb.IsPermanent = value;
            }
            get
            {
                return _AssignedCofferDb.IsPermanent;
            }

        }
        public DateTime StartDate
        {
            set
            {
                _AssignedCofferDb.StartDate = value;
            }
            get
            {
                return _AssignedCofferDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _AssignedCofferDb.EndDate = value;
            }
            get
            {
                return _AssignedCofferDb.EndDate;
            }
        }
        public EmployeeBiz EmployeeBiz
        {
            set
            {
                _EmployeeBiz = value;
            }
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
        }
        public CofferBiz CofferBiz
        {
            set
            {
                _CofferBiz = value;
            }
            get
            {
                if (_CofferBiz == null)
                    _CofferBiz = new CofferBiz();
                return _CofferBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
