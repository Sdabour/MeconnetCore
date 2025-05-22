using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class WireTransfereDb
    {
        #region Private Data
        int _ID;
        string _Desc;
        int _Bank;

        string _BankName;
        string _CustomerName;
        string _ReceiptNo;
        DateTime _ReceiptDate;
        bool _HasReceiptDate;
        double _Value;
        DateTime _Date;
        int _Currency;
        double _CurrencyValue;
        int _AccountID;
        string _AccountCode;
        string _AccountOwnerName;
        string _AccountDesc;
        int _AccountBank;
        #endregion
        #region Constructors
        public WireTransfereDb()
        {
 
        }
        public WireTransfereDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }
        public string ReceiptNo
        {
            set
            {
                _ReceiptNo = value;
            }
            get
            {
                return _ReceiptNo;
            }
        }
        public DateTime ReceiptDate
        {
            set
            {
                _ReceiptDate = value;
            }
            get
            {
                return _ReceiptDate;
            }
        }
        public bool HasReceiptDate
        {
            set
            {
                _HasReceiptDate = value;
            }
            get
            {
                return _HasReceiptDate;
            }

        }
        public int Bank
        {
            set
            {
                _Bank = value;
            }
            get
            {
                return _Bank;
            }
        }
        public string BankName
        {
            get
            {
                return _BankName;
            }
        }

        public double Value
        {
            get
            {
                return _Value;
            }
        }
        public DateTime Date
        {
            get
            {
                return _Date;
            }
        }
        public int Currency
        {
            get
            {
                return _Currency;
            }
        }
        public double CurrencyValue
        {
            get 
            {
                return _CurrencyValue;
            }
        }
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
        }
        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
        }
        public string AccountOwnerName
        {
            get
            {
                return _AccountOwnerName;
            }
        }
        public string AccountDesc
        {
            get
            {
                return _AccountDesc;
            }
        }
        public int AccountBank
        {
            get
            {
                return _AccountBank;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strTransaction = "SELECT    dbo.GLBankAccountTransaction.TransactionWireTransfere as TransactionWireTransfere1, " +
                    " dbo.GLBankAccountTransaction.TransactionValue AS WireTransfereValue, dbo.GLBankAccountTransaction.TransactionDate AS WireTransfereDate, " +
                      " dbo.GLBankAccountTransaction.TransactionCurrency AS WireTransfereCurrency, "+
                      " dbo.GLBankAccountTransaction.TransactionCurrencyValue AS WireTransfereCurrencyValue, dbo.GLBankAccount.AccountID AS WireTransfereAccountID, "+
                      " dbo.GLBankAccount.AccountCode AS WireTransfereAccountCode, dbo.GLBankAccount.AccountOwnerName AS WireTransfereAccountOwnerName,  "+
                      " dbo.GLBankAccount.AccountDesc AS WireTransfereAccountDesc, dbo.GLBankAccount.AccountBank AS WireTransfereAccountBank "+
                      " FROM  dbo.GLBankAccountTransaction INNER JOIN "+
                      " dbo.GLBankAccount ON dbo.GLBankAccountTransaction.TransactionAccount = dbo.GLBankAccount.AccountID ";
                string Returned = "SELECT   dbo.GLBankWireTransfere.WireTransfereID,dbo.GLBankWireTransfere.WireTransfereCustomerName, dbo.GLBankWireTransfere.WireTransfereDesc, dbo.GLBankWireTransfere.WireTransfereBank " +
                    ",dbo.GLBankWireTransfere.WireTransfereReceiptNo,dbo.GLBankWireTransfere.WireTransfereReceiptDate" + 
                    " ,dbo.GLBank.BankID AS TransfereBankID, dbo.GLBank.BankNameA AS TransfereBankName "+
                      ",TransactionTable.* "+
                      " FROM  dbo.GLBankWireTransfere  "+
                      " inner join (" + strTransaction + ") as TransactionTable on  dbo.GLBankWireTransfere.WireTransfereID = TransactionTable.TransactionWireTransfere1 " +
                      " left outer JOIN "+
                      " dbo.GLBank ON dbo.GLBankWireTransfere.WireTransfereBank = dbo.GLBank.BankID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["WireTransfereID"].ToString());
            _Desc = objDr["WireTransfereDesc"].ToString();
            _Bank = int.Parse(objDr["WireTransfereBank"].ToString());
            _BankName = objDr["TransfereBankName"].ToString();
            _CustomerName = objDr["WireTransfereCustomerName"].ToString();
            _ReceiptNo = objDr["WireTransfereReceiptNo"].ToString();
            _HasReceiptDate = objDr["WireTransfereReceiptDate"].ToString() == "" ? false : true;
            _ReceiptDate = objDr["WireTransfereReceiptDate"].ToString() != "" ? 
                DateTime.Parse(objDr["WireTransfereReceiptDate"].ToString()) : DateTime.Now;
            _Value = double.Parse(objDr["WireTransfereValue"].ToString());
            _Date = DateTime.Parse(objDr["WireTransfereDate"].ToString());
            _Currency = int.Parse(objDr["WireTransfereCurrency"].ToString());
            _CurrencyValue = double.Parse(objDr["WireTransfereCurrencyValue"].ToString());
            _AccountID = int.Parse(objDr["WireTransfereAccountID"].ToString());
            _AccountCode = objDr["WireTransfereAccountCode"].ToString();
            _AccountOwnerName = objDr["WireTransfereAccountOwnerName"].ToString();
            _AccountDesc = objDr["WireTransfereAccountDesc"].ToString();
            _AccountBank = int.Parse(objDr["WireTransfereAccountBank"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strReceiptDate = _HasReceiptDate ? (_ReceiptDate.ToOADate() - 2).ToString() : "null";
            string strSql = "insert into GLBankWireTransfere (WireTransfereCustomerName, WireTransfereDesc, WireTransfereBank"+
                ",WireTransfereReceiptNo,WireTransfereReceiptDate ,UsrIns, TimIns) values ('" +
                _CustomerName + "','" + _Desc + "'," + _Bank + ",'" +_ReceiptNo + "'," + strReceiptDate + "," + SysData.CurrentUser.ID + ",GetDate())";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            string strReceiptDate = _HasReceiptDate ? (_ReceiptDate.ToOADate() - 2).ToString() : "null";
            string strSql = "update GLBankWireTransfere set WireTransfereCustomerName='" + _CustomerName + "'" +
                ", WireTransfereDesc='" + _Desc + "'" +
                ", WireTransfereBank=" + _Bank +
                ",WireTransfereReceiptNo='"+ _ReceiptNo +"'" +
                ",WireTransfereReceiptDate="+ strReceiptDate +
                  " ,UsrUpd=" + SysData.CurrentUser.ID + ", TimUpd=GetDate() "+
                  "  where WireTransfereID="+ _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "delete from GLBankWireTransfere where WireTransfereID="+ _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
