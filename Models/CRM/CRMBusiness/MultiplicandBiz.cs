using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;


namespace SharpVision.CRM.CRMBusiness
{
    public abstract class MultiplicandBiz
    {
        #region Private Data
        protected MultiplicandDb _MultiplicandDb;
        #endregion

        #region Constructors
        
        #endregion

        #region Public Properties
        public int PeriodAmount
        {
            set
            {
                _MultiplicandDb.PeriodAmount = value;
            }
            get
            {
                return _MultiplicandDb.PeriodAmount;
            }

        }
        public int Period
        {
            get
            {
                return _MultiplicandDb.Period;
            }
            set
            {
                _MultiplicandDb.Period = value;
            }

        }
        public double YearlyToMonthly
        {
            get
            {
                return _MultiplicandDb.YearlyToMonthly;
            }
            set
            {
                _MultiplicandDb.YearlyToMonthly = value;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        
        #endregion
    }
}
