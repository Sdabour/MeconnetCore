using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLBusiness
{
    public class AccountCostCenterBiz
    {
        #region Private Data
        AccountBiz _AccountBiz;
        CostCenterBiz _CostCenterBiz;
        AccountCostCenterDb _AccountCostCenterDb;
        TransactionElementCol _ElementCol;
        double _DebitBalance;
        double _DebitElementBalance;
        double _CreditBalance;
        double _CreditElementBalance;
        double _TotalDebitBalance;
        double _TotalCreditBalance;
        double _DebitValue;
        double _CreditValue;
        double _Balance;
        #endregion
        #region Constructors
        public AccountCostCenterBiz()
        {
            _AccountCostCenterDb = new AccountCostCenterDb();
        }
        public AccountCostCenterBiz(DataRow objDr)
        {
            _AccountCostCenterDb = new AccountCostCenterDb(objDr);
            _AccountBiz = new AccountBiz(objDr);
           // _CostCenterBiz = new CostCenterBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AccountCostCenterDb.ID = value;
            }
            get
            {
                return _AccountCostCenterDb.ID;
            }
        }
        public bool IsStopped        {
            set
            {
                _AccountCostCenterDb.IsStopped = value;
            }
            get
            {
                return _AccountCostCenterDb.IsStopped;
            }
        }
        public double Debit
        {
            set
            {
                _AccountCostCenterDb.Debit = value;
            }
            get 
            {
                return _AccountCostCenterDb.Debit;
            }
        }
        public double Credit
        {
            set
            {
                _AccountCostCenterDb.Credit = value;
            }
            get
            {
                return _AccountCostCenterDb.Credit;
            }
        }
        public string BalanceDesc
        {
            set
            {
                _AccountCostCenterDb.BalanceDesc = value;
            }
            get
            {
                return _AccountCostCenterDb.BalanceDesc;
            }
        }
        public AccountBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBiz();
                return _AccountBiz;
            }
        }
        public CostCenterBiz CostCenterBiz
        {
            set
            {
                _CostCenterBiz = value;
            }
            get
            {
                if (_CostCenterBiz == null)
                    _CostCenterBiz = new CostCenterBiz();
                return _CostCenterBiz;
            }
        }
        public int CostCenterID
        {
            set
            {
                _AccountCostCenterDb.CostCenter = value;
            }
            get
            {
                return _AccountCostCenterDb.CostCenter;
            }
        }
        public int CostCenterLevel
        {
            get
            {
                return _AccountCostCenterDb.CostCenterLevel;
            }
        }
        public TransactionElementCol ElementCol
        {
            set
            {
                _ElementCol =value;
            }
            get 
            {
                if (_ElementCol == null)
                    _ElementCol = new TransactionElementCol(true);
                return _ElementCol;
            }
        }
        public double DebitBalance
        {
            set
            {
                _DebitBalance = value;
            }
            get
            {
                return _DebitBalance;
            }
        }
        public double DebitElementBalance
        {
            set
            {
                _DebitElementBalance = value;
            }
            get
            {
                return _DebitElementBalance;
            }
        }
        public double CreditBalance
        {
            set
            {
                _CreditBalance = value;
            }
            get
            {
                return _CreditBalance;
            }
        }
        public double CreditElementBalance
        {
            set
            {
                _CreditElementBalance = value;
            }
            get
            {
                return _CreditElementBalance;
            }
        }
        public double TotalDebitBalance
        {
            //set
            //{
            //    _TotalDebitBalance = value;
 
            //}
            get
            {
                return DebitBalance + DebitElementBalance ;
            }
        }
        public double TotalCreditBalance
        {
            //set
            //{
            //    _TotalCreditBalance = value;
            //}
            get
            {
                return CreditBalance  + CreditElementBalance;
            }
        }
        public double Balance
        {
            set
            {
                _Balance = value;
            }
            get
            {
                return _Balance;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
