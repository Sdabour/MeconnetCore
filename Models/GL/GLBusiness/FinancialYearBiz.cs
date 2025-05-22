using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public class FinancialYearBiz
    {
        #region Private Methods
        protected FinancialYearDb _FinancialYearDb;
        protected CompanyBiz _CompanyBiz;
        FinancialPeriodBiz _LastPeriodBiz;
        FinancialPeriodCol _PeriodCol;
        #endregion

        #region Constractors
        public FinancialYearBiz()
        {
            _FinancialYearDb = new FinancialYearDb();
            //_LastPeriodBiz = new FinancialPeriodBiz();
        }
        public FinancialYearBiz(DataRow objDR)
        {
            _FinancialYearDb = new FinancialYearDb(objDR);
            _CompanyBiz = new CompanyBiz();
            if (_FinancialYearDb.Company != 0)
            {
                _CompanyBiz.ID = _FinancialYearDb.Company;
                _CompanyBiz.NameA = _FinancialYearDb.CompanyName;
            }
            _LastPeriodBiz = new FinancialPeriodBiz();
            if (_FinancialYearDb.LastPeriodID != 0)
            {
                _LastPeriodBiz.ID = _FinancialYearDb.LastPeriodID;
                _LastPeriodBiz.Desc = _FinancialYearDb.LastPeriodDesc;
                _LastPeriodBiz.StartDate = _FinancialYearDb.LastPeriodStartDate;
                _LastPeriodBiz.EndDate = _FinancialYearDb.LastPeriodEndDate;
                _LastPeriodBiz.YearBiz = this;
            }
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _FinancialYearDb.ID = value;
            }
            get
            {
                return _FinancialYearDb.ID;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _FinancialYearDb.StartDate = value;
            }
            get
            {
                return _FinancialYearDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _FinancialYearDb.EndDate = value;
            }
            get
            {
                return _FinancialYearDb.EndDate;
            }
        }
        public DateTime CloseDate
        {
            set
            {
                _FinancialYearDb.CloseDate = value;
            }
            get
            {
                return _FinancialYearDb.CloseDate;
            }
        }
        public bool IsClosed
        {
            set
            {
                _FinancialYearDb.IsClosed = value;
            }
            get
            {
                return _FinancialYearDb.IsClosed;
            }
        }
        public string Desc
        {
            set
            {
                _FinancialYearDb.Desc = value;
            }
            get
            {
                return _FinancialYearDb.Desc;
            }
        }
        public FinancialPeriodBiz LastPeriodBiz
        {
            set
            {
                _LastPeriodBiz = value;
            }
            get
            {
                if (_LastPeriodBiz == null)
                    _LastPeriodBiz = new FinancialPeriodBiz();
                return _LastPeriodBiz;
            }
        }
        public CompanyBiz CompanyBiz
        {
            set
            {
                _CompanyBiz = value;
            }
            get
            {
                if (_CompanyBiz == null)
                    _CompanyBiz = new CompanyBiz();
                return _CompanyBiz;
            }
        }
        public FinancialPeriodCol PeriodCol
        {
            set
            {
                _PeriodCol = value;
            }
            get
            {
                if (_PeriodCol == null)
                    _PeriodCol = new FinancialPeriodCol(true);
                return _PeriodCol;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _FinancialYearDb.Company = CompanyBiz.ID;
            _FinancialYearDb.Add();
        }
        public void Edit()
        {
            _FinancialYearDb.Company = CompanyBiz.ID;
            _FinancialYearDb.Edit();
        }
        public void Delete()
        {
            _FinancialYearDb.Delete();
        }

        public void EditCurrentPerioed()
        {
            _FinancialYearDb.EditCurrentPerioed();
        }
        #endregion
    }
}
