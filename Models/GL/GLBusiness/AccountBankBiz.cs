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
    public enum BankAccountType
    {
        NotSpecefied,//غير محدد
        Running,//جارى
        Saving,//توفير
        Deposit,//ودائع
        CreditFacilities,//تسهيلات ائتمانية
        Loan//قرض

    }
    public class AccountBankBiz
    {
        #region Private Data
        AccountBankDb _AccountBankDb;
        BankBiz _Bank;
        CurrencyBiz _Currency;
        double _Credit;
        double _CheckCredit;
        AccountBiz _AccountBiz;
        #endregion
        #region Constructors
        public AccountBankBiz()
        {
            _AccountBankDb = new AccountBankDb();
        }
        public AccountBankBiz(int intID)
        {
            _AccountBankDb = new AccountBankDb(intID);
            if (_AccountBankDb.GLAccount != 0)
            {
                _AccountBiz = new AccountBiz();
                _AccountBiz.ID = _AccountBankDb.GLAccount;
                _AccountBiz.Code = _AccountBankDb.GLAccountCode;
                _AccountBiz.NameA = _AccountBankDb.GLAccountName;
            }
        }
        public AccountBankBiz(DataRow objDR)
        {
            _AccountBankDb = new AccountBankDb(objDR);
            _Bank = new BankBiz(objDR);
            _Currency = new CurrencyBiz(_AccountBankDb.Currency);
            if (_AccountBankDb.GLAccount != 0)
            {
                _AccountBiz = new AccountBiz();
                _AccountBiz.ID = _AccountBankDb.GLAccount;
                _AccountBiz.Code = _AccountBankDb.GLAccountCode;
                _AccountBiz.NameA = _AccountBankDb.GLAccountName;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AccountBankDb.ID = value;
            }
            get
            {
                return _AccountBankDb.ID;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            set
            {
                _Currency = value;
            }
            get
            {
                if (_Currency == null)
                    _Currency = new CurrencyBiz();
                return _Currency;
            }
        }
        public BankBiz BankBiz
        {
            set
            {
                _Bank = value;
            }
            get
            {
                if (_Bank == null)
                    _Bank = new BankBiz();
                return _Bank;
            }
        }
        public BankAccountType Type
        {
            set
            {
                _AccountBankDb.Type = (int)value;
            }
            get
            {
                return (BankAccountType)_AccountBankDb.Type;
            }
        }
        public string Desc
        {
            set
            {
                _AccountBankDb.Desc = value;
            }
            get
            {
                return _AccountBankDb.Desc;
            }
        }
        public string Code
        {
            set
            {
                _AccountBankDb.Code= value;
            }
            get
            {
                if (_AccountBankDb.Code == null)
                    return "";
                return _AccountBankDb.Code;
            }
        }
        public string OwnerName
        {
            set
            {
                _AccountBankDb.OwnerName = value;
            }
            get
            {
                return _AccountBankDb.OwnerName;
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
                return _Credit;
            }
        }
        public double CheckCredit
        {
            set
            {
                _CheckCredit = value;
            }
            get
            {
                return _CheckCredit;
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
        public string TypeStr
        {
            get
            {
                string Returned = "";

                switch (Type)
                {
                    case BankAccountType.CreditFacilities: Returned = "تسهيلات ائتمانية"; break;
                    case BankAccountType.Deposit: Returned = "ودائع"; break;
                    case BankAccountType.Loan: Returned = "قرض"; break;
                    case BankAccountType.Running: Returned = "جارى"; break;
                    case BankAccountType.Saving: Returned = "توفير"; break;
                    default: Returned = "غير محدد"; break;
                }


                
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
           
            _AccountBankDb.Bank = BankBiz.ID;
            _AccountBankDb.Currency = CurrencyBiz.ID;
            _AccountBankDb.GLAccount = AccountBiz.ID;
            _AccountBankDb.Add();

        }
        public void Edit()
        {
            
            _AccountBankDb.Bank = BankBiz.ID;
            _AccountBankDb.Currency = CurrencyBiz.ID;
            _AccountBankDb.GLAccount = AccountBiz.ID;
            _AccountBankDb.Edit();

        }
        public void Delete()
        {
            _AccountBankDb.Delete();
        }
        #endregion
    }
}
