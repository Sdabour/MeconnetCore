using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public abstract class MultiplicandDb
    {
        #region Private Data
        protected int _PeriodAmount;
        protected int _Period;
        protected double _YearlyToMonthly;
        #endregion

        #region Constructors

        #endregion

        #region Public Properties
        public int PeriodAmount
        {
            set 
            {
                _PeriodAmount = value;
            }
            get 
            {
                return _PeriodAmount; 
            }

        }
        public int Period
        {
            get 
            
            { return _Period;
            }
            set 
            {
                _Period = value; 
            }

        }
        public double YearlyToMonthly
        {
            get 
            { 
                return _YearlyToMonthly;
            }
            set 
            {
                _YearlyToMonthly = value;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public abstract DataTable Search();
        public abstract void InsertCol();
        #endregion
    }
}
