using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;

using System.Data;
namespace SharpVision.UMS.UMSBusiness
{
    public class EmployeeDepartmentBiz
    {
        #region Private Data
        EmployeeDepartmentDb _EmployeeDepartmentDb;
        EmployeeBiz _EmployeeBiz;
        DepartmentBiz _DepartmentBiz;
        #endregion
        #region Constructors
        public EmployeeDepartmentBiz()
        {
            _EmployeeBiz = new EmployeeBiz();
            _DepartmentBiz = new DepartmentBiz();
        }
        public EmployeeDepartmentBiz(DataRow objDr)
        {
            _EmployeeDepartmentDb = new EmployeeDepartmentDb(objDr);
            _EmployeeBiz = new EmployeeBiz();
            _DepartmentBiz = new DepartmentBiz(_EmployeeDepartmentDb.DepartmentID);
        }
        #endregion
        #region Public Properties
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
        public DepartmentBiz DepartmentBiz
        {
            set
            {
                _DepartmentBiz = value;
            }
            get
            {
                if (_DepartmentBiz == null)
                    _DepartmentBiz = new DepartmentBiz();
                return _DepartmentBiz;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
