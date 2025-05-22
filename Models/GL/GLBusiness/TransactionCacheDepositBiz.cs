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
    public class TransactionCacheDepositBiz : TransactionBiz
    {
        #region PrivateData
        CurrencyBiz _CurrencyBiz;
        TransactionCacheDepositDb _TransactionCacheDepositDb;
        #endregion

        #region Constractors
        public TransactionCacheDepositBiz()
        {
            _TransactionDb = new TransactionCacheDepositDb();
        }
        public TransactionCacheDepositBiz(int intID)
        {
            _TransactionDb = new TransactionCacheDepositDb(intID);

        }
        public TransactionCacheDepositBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCacheDepositDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Account
        {
            set
            {
                ((TransactionCacheDepositDb)_TransactionDb).Account = value;
            }
            get
            {
                return ((TransactionCacheDepositDb)_TransactionDb).Account;
            }
        }
        public double Value
        {
            set
            {
                ((TransactionCacheDepositDb)_TransactionDb).Value = value;
            }
            get
            {
                return ((TransactionCacheDepositDb)_TransactionDb).Value;
            }
        }
        public int CurrencyID
        {
            set
            {
                ((TransactionCacheDepositDb)_TransactionDb).CurrencyID = value;
            }
            get
            {
                return ((TransactionCacheDepositDb)_TransactionDb).CurrencyID;
            }
        }
        public double CurrencyValue
        {
            set
            {
                ((TransactionCacheDepositDb)_TransactionDb).CurrencyValue = Value;
            }
            get
            {
                return ((TransactionCacheDepositDb)_TransactionDb).CurrencyValue;
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
            _TransactionCacheDepositDb.CurrencyID = _CurrencyBiz.ID;
            _TransactionCacheDepositDb.CurrencyValue = _CurrencyBiz.Value;
            base.Add();
        }
        public override void Edit()
        {
            _TransactionCacheDepositDb.CurrencyID = _CurrencyBiz.ID;
            _TransactionCacheDepositDb.CurrencyValue = _CurrencyBiz.Value;
            base.Edit();
        }
        public override void Delete()
        {
            base.Delete();
        }
        #endregion

    }
}
