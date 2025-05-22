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
    public class TransactionCacheWithdrawBiz : TransactionBiz
    {
         #region PrivateData
        CurrencyBiz _CurrencyBiz;
        TransactionCacheWithdrawDb _TransactionCacheWithdrawDb;
        #endregion

        #region Constractors
        public TransactionCacheWithdrawBiz()
        {
            _TransactionDb = new TransactionCacheWithdrawDb();
        }
        public TransactionCacheWithdrawBiz(int intID)
        {
            _TransactionDb = new TransactionCacheWithdrawDb(intID);

        }
        public TransactionCacheWithdrawBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCacheWithdrawDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Account
        {
            set
            {
                ((TransactionCacheWithdrawDb)_TransactionDb).Account = value;
            }
            get
            {
                return ((TransactionCacheWithdrawDb)_TransactionDb).Account;
            }
        }
        public double Value
        {
            set
            {
                ((TransactionCacheWithdrawDb)_TransactionDb).Value = value;
            }
            get
            {
                return ((TransactionCacheWithdrawDb)_TransactionDb).Value;
            }
        }
        public int CurrencyID
        {
            set
            {
                ((TransactionCacheWithdrawDb)_TransactionDb).CurrencyID = value;
            }
            get
            {
                return ((TransactionCacheWithdrawDb)_TransactionDb).CurrencyID;
            }
        }
        public double CurrencyValue
        {
            set
            {
                ((TransactionCacheWithdrawDb)_TransactionDb).CurrencyValue = Value;
            }
            get
            {
                return ((TransactionCacheWithdrawDb)_TransactionDb).CurrencyValue;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            set
            {
                _CurrencyBiz = value;
            }
            get
            {
                return _CurrencyBiz;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        
        public override void  Add()
        {
            _TransactionCacheWithdrawDb.CurrencyID = _CurrencyBiz.ID;
            _TransactionCacheWithdrawDb.CurrencyValue = _CurrencyBiz.Value;
            base.Add();
        }
        public override void Edit()
        {
            _TransactionCacheWithdrawDb.CurrencyID = _CurrencyBiz.ID;
            _TransactionCacheWithdrawDb.CurrencyValue = _CurrencyBiz.Value;
            base.Edit();
        }
        public override void Delete()
        {
            base.Delete();
        }
        #endregion

    }
}
