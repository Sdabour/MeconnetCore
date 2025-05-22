using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class CheckPrintBiz
    {
        #region Private Data
        CheckPrintDb _PrintDb;
        CheckBiz _CheckBiz;
        EmployeeBiz _EmployeeBiz;
        #endregion
        #region Constructors
        public CheckPrintBiz()
        {
            _PrintDb = new CheckPrintDb();

        }
        public CheckPrintBiz(DataRow objDr)
        {
            _PrintDb = new CheckPrintDb(objDr);
            if (_PrintDb.Employee != 0)
            {
                _EmployeeBiz = new EmployeeBiz();
                _EmployeeBiz.ID = _PrintDb.Employee;
                _EmployeeBiz.Name = _PrintDb.EmployeeName;
            }

        }
        #endregion
        #region Public Properties
        public CheckBiz CheckBiz
        {
            set
            {
                _CheckBiz = value;
            }
            get
            {
                if (_CheckBiz == null)
                    _CheckBiz = new CheckBiz();
                return _CheckBiz;
            }
        }

        public int Model
        {
            set
            {
                _PrintDb.Model = value;
            }
            get
            {
                return _PrintDb.Model;
            }
        }

        public DateTime Date
        {
            set
            {
                _PrintDb.Date = value;
            }
            get
            {
                return _PrintDb.Date;
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
        public int Status
        {
            set
            {
                _PrintDb.Status = value;
            }
            get
            {
                return _PrintDb.Status;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
