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
    public class WireTransfereBiz
    {
        #region Private Data
        WireTransfereDb _TransfereDb;
        BankBiz _BankBiz;
        BankAccountTransactionBiz _TransactionBiz;
        AccountBankBiz _AccountBiz;
        CurrencyBiz _CurrencyBiz;
        PaymentCol _PaymentCol;
        #endregion
        #region Constructors
        public WireTransfereBiz()
        {
            _TransfereDb = new WireTransfereDb();
        }
        public WireTransfereBiz(int intID)
        {
            WireTransfereDb objDb = new WireTransfereDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                _TransfereDb = new WireTransfereDb(objDr);
                _CurrencyBiz = new CurrencyBiz(_TransfereDb.Currency);
                _AccountBiz = new AccountBankBiz();
                _AccountBiz.ID = _TransfereDb.AccountID;
                _AccountBiz.OwnerName = _TransfereDb.AccountOwnerName;
                _AccountBiz.Code = _TransfereDb.AccountCode;
                _AccountBiz.Desc = _TransfereDb.AccountDesc;
                _AccountBiz.BankBiz = new BankBiz(_TransfereDb.AccountBank);
                _TransactionBiz = new BankAccountTransactionBiz();
                _TransactionBiz.AccountBiz = _AccountBiz;
                _TransactionBiz.TransfereBiz = this;
                _TransactionBiz.Value = Value;
                _TransactionBiz.Direction = true;
            }
            else
            {
                _TransfereDb = new WireTransfereDb();
            }
 
        }
        public WireTransfereBiz(DataRow objDr)
        {
            _TransfereDb = new WireTransfereDb(objDr);
            _CurrencyBiz = new CurrencyBiz(_TransfereDb.Currency);
            _AccountBiz = new AccountBankBiz();
            _AccountBiz.ID = _TransfereDb.AccountID;
            _AccountBiz.OwnerName = _TransfereDb.AccountOwnerName;
            _AccountBiz.Code = _TransfereDb.AccountCode;
            _AccountBiz.Desc = _TransfereDb.AccountDesc;
            _AccountBiz.BankBiz = new BankBiz(_TransfereDb.AccountBank);
            _TransactionBiz = new BankAccountTransactionBiz();
            _TransactionBiz.AccountBiz = _AccountBiz;
            _TransactionBiz.TransfereBiz = this;
            _TransactionBiz.Value = Value;
            _TransactionBiz.Direction = true;


        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _TransfereDb.ID = value;
            }
            get
            {
                if (_TransfereDb == null)
                    _TransfereDb = new WireTransfereDb();
                return _TransfereDb.ID;
            }

        }
        public string Desc
        {
            set 
            {
                _TransfereDb.Desc = value;
            }
            get
            {
                return _TransfereDb.Desc;
            }

        }
        public string CustomerName
        {
            set
            {
                _TransfereDb.CustomerName = value;
            }
            get
            {
                return _TransfereDb.CustomerName;
            }
        }
        public BankBiz BankBiz
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
        public bool HasReceiptDate
        {
            set
            {
                _TransfereDb.HasReceiptDate = value;
            }
            get
            {
                return _TransfereDb.HasReceiptDate;
            }
        }
        public string ReceiptNo
        {
            set
            {
                _TransfereDb.ReceiptNo = value;
            }
            get 
            {
                return _TransfereDb.ReceiptNo;
            }
        }
        public DateTime ReceiptDate
        {
            set
            {
                _TransfereDb.ReceiptDate = value;
            }
            get
            {
                return _TransfereDb.ReceiptDate;
            }
        }
        public double Value
        {
            get
            {
                return _TransfereDb.Value;
            }
        }
        public DateTime Date
        {
            get
            {
                return _TransfereDb.Date;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            get
            {
                if (_CurrencyBiz == null)
                    _CurrencyBiz = new CurrencyBiz(_TransfereDb.Currency);
                return _CurrencyBiz;
            }
        }
        public double CurrencyValue
        {
            get
            {
                return _TransfereDb.CurrencyValue;
            }
        }
        public AccountBankBiz AccountBiz
        {
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBankBiz();
                return _AccountBiz;
            }
        }
        public PaymentCol PaymentCol
        {
            set
            {
                _PaymentCol = value;
            }
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new PaymentCol(true);
                    if (ID != 0)
                    {
                        PaymentDb objDb = new PaymentDb();
                        objDb.WireTransafere = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _PaymentCol.Add(new PaymentBiz(objDr));
                        }
                    }
                }
                return _PaymentCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _TransfereDb.Add();
        }
        public void Edit()
        {
            _TransfereDb.Edit();
        }
        public void Delete()
        {
            _TransfereDb.Delete();
        }
        public bool CheckPayment(PaymentBiz objPaymentBiz)
        {
            double dblPaymentValue = PaymentCol.TotalValue;
            int intIndex = PaymentCol.GetIndex(objPaymentBiz.ID);
            if (intIndex != -1)
            {
                dblPaymentValue -= PaymentCol[intIndex].Value;



            }
            dblPaymentValue += objPaymentBiz.Value;
            if (dblPaymentValue > Value)
                return false;
            return true;
        }
        #endregion
    }
}
