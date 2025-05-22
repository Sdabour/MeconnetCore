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
    public class FinancialPeriodBiz
    {
        #region Private Methods
        protected FinancialPeriodDb _FinancialPeriodDb;
        FinancialYearBiz _YearBiz;

        #endregion

        #region Constractors
        public FinancialPeriodBiz()
        {
            _FinancialPeriodDb = new FinancialPeriodDb();
           // _YearBiz = new FinancialYearBiz();
        }
        public FinancialPeriodBiz(DataRow objDR)
        {
            _FinancialPeriodDb = new FinancialPeriodDb(objDR);
            _YearBiz = new FinancialYearBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _FinancialPeriodDb.ID = value;
            }
            get
            {
                return _FinancialPeriodDb.ID;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _FinancialPeriodDb.StartDate = value;
            }
            get
            {
                return _FinancialPeriodDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _FinancialPeriodDb.EndDate = value;
            }
            get
            {
                return _FinancialPeriodDb.EndDate;
            }
        }
        public string Desc
        {
            set 
            {
                _FinancialPeriodDb.Desc = value;
            }
            get
            {
                return _FinancialPeriodDb.Desc;
            }
        }
        public bool IsCurrent
        {
            set
            {
                _FinancialPeriodDb.IsCurrent = value;
            }
            get
            {
                return _FinancialPeriodDb.IsCurrent;
            }
        }
        public bool IsStopped
        {
            set
            {
                _FinancialPeriodDb.IsStopped = value;
            }
            get
            {
                return _FinancialPeriodDb.IsStopped;
            }
        }
        public FinancialYearBiz YearBiz
        {
            set
            {
                _YearBiz = value;
            }
            get
            {
                if (_YearBiz == null)
                    _YearBiz = new FinancialYearBiz();
                return _YearBiz;
            }
        }
        public DataTable RecursiveTransactionTable
        {
            get
            {
                RecursiveTransactionDb objDb = new RecursiveTransactionDb();
                objDb.ID = ID;
                DataTable Returned = objDb.Search();
                return Returned;
            }
        }
        public string DisplayDesc
        {
            get
            {
                string Returned = "";
                Returned = Desc + "-" + YearBiz.Desc;
                return Returned;
            }
        }
       
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _FinancialPeriodDb.Year = YearBiz.ID;
            _FinancialPeriodDb.Add();
            _FinancialPeriodDb.JoinRecursiveTransaction();
        }
        public void Edit()
        {
            _FinancialPeriodDb.Year = YearBiz.ID;
            _FinancialPeriodDb.Edit();
            _FinancialPeriodDb.JoinRecursiveTransaction();
        }
        public void Delete()
        {
            _FinancialPeriodDb.Delete();
        }

        public void EditCurrentPerioed()
        {
            _FinancialPeriodDb.EditCurrentPerioed();
        }
        #endregion
    }
}
