using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;

using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public class ReceiptBookBiz
    {
        #region Private Data
        ReceiptBookDb _ReceiptBookDb;
        ReceiptModelBiz _ModelBiz;
        EmployeeBiz _EmployeeBiz;
        #endregion
        #region Constructors
        public ReceiptBookBiz()
        {
            _ReceiptBookDb = new ReceiptBookDb();
        }
        public ReceiptBookBiz(DataRow objDr)
        {
            _ReceiptBookDb = new ReceiptBookDb(objDr);
            _ModelBiz = new ReceiptModelBiz(objDr);
            if (_ReceiptBookDb.Employee != 0)
            {
                _EmployeeBiz = new EmployeeBiz();
                _EmployeeBiz.ID = _ReceiptBookDb.Employee;
                _EmployeeBiz.Name = _ReceiptBookDb.EmployeeName;
                _EmployeeBiz.Code = _ReceiptBookDb.EmployeeCode;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ReceiptBookDb.ID = value;
            }
            get
            {
                return _ReceiptBookDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _ReceiptBookDb.Desc = value;
            }
            get
            {
                return _ReceiptBookDb.Desc;
            }
        }
      
        public int StartSerial
        {
            set
            {
                _ReceiptBookDb.StartSerial = value;
            }
            get
            {
                return _ReceiptBookDb.StartSerial;
            }
        }
        public int EndSerial
        {
            set
            {
                _ReceiptBookDb.EndSerial = value;
            }
            get
            {
                return _ReceiptBookDb.EndSerial;
            }
        }
        public ReceiptModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                if (_ModelBiz == null)
                    _ModelBiz = new ReceiptModelBiz();
                return _ModelBiz;
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
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReceiptBookDb.Model = ModelBiz.ID;
            _ReceiptBookDb.Employee = EmployeeBiz.ID;
            _ReceiptBookDb.Add();
        }
        public void Edit()
        {
            _ReceiptBookDb.Model = ModelBiz.ID;
            _ReceiptBookDb.Employee = EmployeeBiz.ID;
            _ReceiptBookDb.Edit();
        }
        public void Delete()
        {
            _ReceiptBookDb.Delete();
        }

        #endregion
    }
}