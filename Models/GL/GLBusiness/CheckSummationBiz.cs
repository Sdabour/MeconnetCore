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
    public class CheckSummationBiz
    {
        #region Private Data

        CheckSummationDb _CheckSummationDb;
        BankBiz _BankBiz;

        #endregion
        #region Constructors
        public CheckSummationBiz()
        {
            _CheckSummationDb = new CheckSummationDb();
        }
        public CheckSummationBiz(DataRow objDR)
        {
            _CheckSummationDb = new CheckSummationDb(objDR);
        }

        #endregion
        #region Public Properties

        public string BankName
        {
            set
            {
                _CheckSummationDb.BankName = value;
            }
            get
            {
                return _CheckSummationDb.BankName;
            }
        }

        public double NotSpecified
        {
            set
            {
                _CheckSummationDb.NotSpecified = value;
            }
            get
            {
                return _CheckSummationDb.NotSpecified;
            }
        }
        public double DuePostponeded
        {
            set
            {
                _CheckSummationDb.DuePostponeded = value;
            }
            get
            {
                return _CheckSummationDb.DuePostponeded;
            }
        }
        public double NotDuePostponeded
        {
            set
            {
                _CheckSummationDb.NotDuePostponeded = value;
            }
            get
            {
                return _CheckSummationDb.NotDuePostponeded;
            }
        }
        public double Collected
        {
            set
            {
                _CheckSummationDb.Collected = value;
            }
            get
            {
                return _CheckSummationDb.Collected;
            }
        }
        public double Rejected
        {
            set
            {
                _CheckSummationDb.Rejected = value;
            }
            get
            {
                return _CheckSummationDb.Rejected;
            }
        }
        public double Reclaimed
        {
            set
            {
                _CheckSummationDb.Reclaimed = value;
            }
            get
            {
                return _CheckSummationDb.Reclaimed;
            }
        }
        public double Submitted
        {
            set
            {
                _CheckSummationDb.Submitted = value;
            }
            get
            {
                return _CheckSummationDb.Submitted;
            }
        }

        public bool IsDateRange
        {
            set
            {
                _CheckSummationDb.IsDateRange = value;
            }
            get
            {
                return _CheckSummationDb.IsDateRange;
            }
        }
        public string DateStr
        {
            get
            {
                return _CheckSummationDb.DateStr;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _CheckSummationDb.DateFrom = value;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _CheckSummationDb.DateTo = value;
            }
        }
        public BankBiz Bank
        {
            set
            {
                _BankBiz = value;
            }
            get
            {
                if (_BankBiz == null)
                    _BankBiz = new BankBiz();
                return _BankBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion


    }
}
