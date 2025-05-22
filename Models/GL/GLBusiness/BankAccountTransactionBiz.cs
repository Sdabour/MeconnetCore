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
    public class BankAccountTransactionBiz
    {
        #region Private Data
        BankAccountTransactionDb _TransactionDb;
        AccountBankBiz _AccountBiz;
        AccountBiz _GLAccountBiz;
        CurrencyBiz _CurrencyBiz;
        CheckBiz _CheckBiz;
        WireTransfereBiz _TransfereBiz;
        double _Credit;
        #endregion
        #region Constructors
        public BankAccountTransactionBiz()
        {
            _AccountBiz = new AccountBankBiz();
            _CheckBiz = new CheckBiz();
            _CurrencyBiz = new CurrencyBiz();
            _TransfereBiz = new WireTransfereBiz();
            _TransactionDb = new BankAccountTransactionDb();
        }
        public BankAccountTransactionBiz(DataRow objDr)
        {
            _TransactionDb = new BankAccountTransactionDb(objDr);
            _CurrencyBiz = new CurrencyBiz(_TransactionDb.Currency);
            _AccountBiz = new AccountBankBiz(objDr);
            if (_TransactionDb.Check != 0)
                _CheckBiz = new CheckBiz(objDr);
            else
            {
                _CheckBiz = new CheckBiz();
            }
            if (_TransactionDb.WireTransfere != 0)
                _TransfereBiz = new WireTransfereBiz(objDr);
            else
                _TransfereBiz = new WireTransfereBiz();
            if (_TransactionDb.GLAccount != 0)
            {
                _GLAccountBiz = new AccountBiz();
                _GLAccountBiz.ID = _TransactionDb.GLAccount;
                _GLAccountBiz.NameA = _TransactionDb.GLAccountName;
                _GLAccountBiz.Code = _TransactionDb.GLAccountCode;
            }


        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _TransactionDb.ID = value;
            }
            get
            {
                return _TransactionDb.ID;
            }
        }
        public AccountBankBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBankBiz();
                return _AccountBiz;
            }

        }
        public string Desc
        {
            set
            {
                _TransactionDb.Desc = value;
            }
            get
            {
                return _TransactionDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _TransactionDb.Value = value;
            }
            get
            {

                return _TransactionDb.Value;
            }
        }
        

        public DateTime Date
        {
            set
            {
                _TransactionDb.Date = value;
            }
            get
            {
                return _TransactionDb.Date;
            }
        }
        public int Type
        {
            set
            {
                _TransactionDb.Type = value;
            }
            get
            {
                return _TransactionDb.Type;
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
                if (_CurrencyBiz == null)
                    _CurrencyBiz = new CurrencyBiz();
                return _CurrencyBiz;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _TransactionDb.CurrencyValue = value;
            }
            get
            {
                return _TransactionDb.CurrencyValue;
            }
        }
        public bool Direction
        {
            set
            {
                _TransactionDb.Direction = value;
            }
            get
            {
                return _TransactionDb.Direction;
            }
        }
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
        public WireTransfereBiz TransfereBiz
        {
            set
            {
                _TransfereBiz = value;
            }
            get
            {
                if (_TransfereBiz == null)
                    _TransfereBiz = new WireTransfereBiz();
                return _TransfereBiz;
            }
        }
        public AccountBiz GLAccountBiz
        {
            set
            {
                _GLAccountBiz = value;
            }
            get
            {
                if (_GLAccountBiz == null)
                    _GLAccountBiz = new AccountBiz();
                return _GLAccountBiz;
            }
        }
        public double Credit
        {
            set
            {
                _Credit = value;
            }
            get
            {
                if (_Credit == 0)
                    _Credit = (Direction ? 1 : -1) * CurrentValue;
                return _Credit;
            }
        }
        public double CurrentCredit
        {
            get
            {
                
                return _Credit;
            }
        }
        public string PaymentCacheType
        {
            get
            {
                string Returned = "ﬂ«‘";
                if (CheckBiz.ID != 0)
                    Returned = "‘Ìﬂ ﬂÊœ :" + _CheckBiz.Code;
                else if (TransfereBiz.ID != 0)
                {
                    Returned = " ÕÊÌ· »‰ﬂÏ";
 
                }
                return Returned;
            }
        }
        public string DirectionStr
        {
            get
            {
                string Returned = "";
                if (Direction)
                    Returned = "≈÷«›…";
                else
                    Returned = "Œ’„";
                return Returned;
            }
        }
        public double CurrentValue
        {
            get
            {
                double Returned = Value;
                if (CheckBiz.ID != 0)
                    Returned = CheckBiz.Value;
                
                return Returned;
            }
        }
       #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
           
            if (CheckBiz.Value == 0 && _TransfereBiz != null )
                _TransfereBiz.Add();
            if (GLAccountBiz.ID != 0 && CheckBiz.Value != 0)
                CheckBiz.GLAccountBiz = GLAccountBiz;
            else if (_CheckBiz.Value != 0 && CheckBiz.GLAccountBiz.ID != 0)
                GLAccountBiz = CheckBiz.GLAccountBiz;



            _TransactionDb.Account = AccountBiz.ID;
            _TransactionDb.Currency = CurrencyBiz.ID;
            //_TransactionDb.Check = CheckBiz.ID;
            _TransactionDb.GLAccount = GLAccountBiz.ID;
            _TransactionDb.WireTransfere = TransfereBiz.ID;
            _TransactionDb.Add();
            if (_CheckBiz != null && _CheckBiz.Value != 0 )
            {
                _CheckBiz.CurrencyBiz = CurrencyBiz;
                _CheckBiz.Type = CheckType.Check;
                _CheckBiz.Status = CheckStatus.Collected;
                _CheckBiz.IsBankOriented = true;
                _CheckBiz.TransactionID = ID;
                if (_CheckBiz.ID == 0)
                    _CheckBiz.Add();
                else
                    _CheckBiz.Edit();
            }
        }
        public void Edit()
        {
            if (GLAccountBiz.ID != 0 && CheckBiz.Value != 0)
                CheckBiz.GLAccountBiz = GLAccountBiz;
            else if (_CheckBiz.Value != 0 && CheckBiz.GLAccountBiz.ID != 0)
                GLAccountBiz = CheckBiz.GLAccountBiz;
          
            _TransactionDb.Account = AccountBiz.ID;
            _TransactionDb.Currency = CurrencyBiz.ID;
           // _TransactionDb.Check = CheckBiz.ID;
            _TransactionDb.WireTransfere = TransfereBiz.ID;
            _TransactionDb.GLAccount = GLAccountBiz.ID;
            _TransactionDb.Edit();
            _TransactionDb.ResetCheckTransaction();
            if (CheckBiz.Value == 0 && _TransfereBiz != null)
                _TransfereBiz.Add();

            if (_CheckBiz != null && _CheckBiz.Value != 0 )
            {
                _CheckBiz.CurrencyBiz = CurrencyBiz;
                _CheckBiz.Type = CheckType.Check;
                _CheckBiz.Status = CheckStatus.Collected;
                _CheckBiz.IsBankOriented = true;
                _CheckBiz.TransactionID = ID;
                if (_CheckBiz.ID == 0)
                    _CheckBiz.Add();
                else
                    _CheckBiz.Edit();
            }


        }
        public void Delete()
        {
            _TransactionDb.Delete();
        
        }

        #endregion
    }
}
