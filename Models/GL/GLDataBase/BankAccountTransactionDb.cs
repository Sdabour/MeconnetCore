using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class BankAccountTransactionDb
    {
        #region Private Data
        int _ID;
        int _Account;
        int _GLAccount;
        string _Desc;
        double _Value;
        DateTime _Date;
        int _Type;
        int _Currency;
        double _CurrencyValue;
        bool _Direction;
        int _Check;
        int _WireTransfere;
        string _GLAccountName;
        string _GLAccountCode;
        #region Private Data for Search
        string _BankIDs;
        string _AccountIDs;
        bool _IsDateRange;
        bool _HasMaxDate;
        
        DateTime _StartDate;
        DateTime _EndDate;
        double _StartValue;
        double _EndValue;
        int _BankID;
        int _DirectionStatus;
        int _CachePaymentType;/*
                               * 0 dont care
                               * 1 cache
                               * 2 check
                               * 3 wire transfere
                               */
        int _ReceiptedStatus;/*
                              * 0 dont care
                              * 1 Receipted
                              * 2 not receipted
                              */
        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        int _ResultInCount;
        int _ResultOutCount;
        double _ResultInValue= 0;
        double _ResultOutValue = 0;
        double _CreditValue = 0;

        #endregion
        #endregion
        #region Constructors
        public BankAccountTransactionDb()
        {
 
        }
        public BankAccountTransactionDb(DataRow objDr)
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
        public int Account
        {
            set
            {
                _Account = value;
            }
            get
            {
                return _Account;
            }

        }
        public int GLAccount
        {
            set
            {
                _GLAccount = value;
            }
            get
            {
                return _GLAccount;
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
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        public int Currency
        {
            set
            {
                _Currency = value;
            }
            get
            {
                return _Currency;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _CurrencyValue = value;
            }
            get
            {
                return _CurrencyValue;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int Check
        {
            set
            {
                _Check = value;
            }
            get
            {
                return _Check;
            }
        }
        public int WireTransfere
        {
            set
            {
                _WireTransfere = value;
            }
            get
            {
                return _WireTransfere;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public bool HasMaxDate
        {
            set
            {
                _HasMaxDate = value; ;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }

        public double StartValue
        {
            set
            {
                _StartValue = value;
            }
        }
        public double EndValue
        {
            set
            {
                _EndValue = value;
            }
        }
        public int BankID
        {
            set
            {
                _BankID = value;
            }
        }
        public int DirectionStatus
        {
            set
            {
                _DirectionStatus = value;
            }
        }
        
        public int CachePaymentType
        {
            set
            {
                _CachePaymentType = value;
            }
        }
        public int ReceiptedStatus
        {
            set
            {
                _ReceiptedStatus = value;
            }
        }
        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }
        }
        public string BankIDs
        {
            set
            {
                _BankIDs = value;
            }
        }
        public string AccountIDs
        {
            set
            {
                _AccountIDs = value;
            }
        }
        public string GLAccountName
        {
            get
            {
                return _GLAccountName;
            }
        }
        public string GLAccountCode
        {
            get
            {
                return _GLAccountCode;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public double ResultValue
        {
            get
            {
                return _ResultValue;
            }
        }
        public double CreditValue
        {
            get
            {
                return _CreditValue;
            }
        }
        public int ResultInCount
        {
            get
            {
                return _ResultInCount;
            }
        }
        public double ResultInValue
        {
            get
            {
                return _ResultInValue;
            }
        }
        public int ResultOutCount
        {
            get
            {
                return _ResultOutCount;
            }
        }
        public double ResultOutValue
        {
            get
            {
                return _ResultOutValue;
            }
        }
        public DataTable Counting
        {
            get
            {
                string strSql = StrSearch;


                
                    string strCountSql = "select count(*) as ResultCount,sum(RealValue) as ResultValue " +
                         ",sum(case when TransactionDirection = 1 then 1 else 0 end) as ResultInCount " +
                        ",sum(case when TransactionDirection = 0 then 1 else 0 end) as ResultOutCount " +
                         ",sum(case when TransactionDirection = 0 then RealValue else 0 end) as ResultOutValue " +
                          ",sum(case when TransactionDirection = 1 then RealValue else 0 end) as ResultInValue " +
                          ",sum((case when TransactionDirection = 1 then 1 else -1 end)*RealValue) as CreditValue " +
                        " from (" + strSql +
                        ")  AS NativeTable ";
                    DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                    return Returned;
               
            }
        }
        public DataTable AccountCounting
        {
            get
            {
                string strSql = StrSearch;



                string strCountSql = "select  TransactionAccount,count(*) as ResultCount,sum(RealValue) as ResultValue " +
                     ",sum(case when TransactionDirection = 1 then 1 else 0 end) as ResultInCount " +
                    ",sum(case when TransactionDirection = 0 then 1 else 0 end) as ResultOutCount " +
                     ",sum(case when TransactionDirection = 0 then RealValue else 0 end) as ResultOutValue " +
                      ",sum(case when TransactionDirection = 1 then RealValue else 0 end) as ResultInValue " +
                      ",sum((case when TransactionDirection = 1 then 1 else -1 end)*RealValue) as CreditValue"+
                      ",max(TransactionDate) as MaxTransactionDate " +
                    " from (" + strSql +
                    ")  AS NativeTable "+
                    " group by  TransactionAccount ";
                strCountSql = "select CountingTable.* ,AccountTable.* from ("+ strCountSql +") as CountingTable inner join (" + 
                    AccountBankDb.SearchStr + 
                    ") as AccountTable on CountingTable.TransactionAccount=AccountTable.AccountID ";
                DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                return Returned;

            }
        }
        public string StrSearch
        {
            get
            {
                string Returned = SearchStr + " where (1=1)  ";
                if (_Type != 0)
                    Returned += " and GLBankAccountTransaction.TransactionType=" + _Type;
              
                if(_BankIDs != null && _BankIDs!= "")
                    Returned += " and AccountTable.BankID in (" + _BankIDs + ")";
                else if (_BankID != 0)
                {
                    Returned += " and AccountTable.BankID=" + _BankID;
                }
                if (_IsDateRange)
                {
                    double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and GLBankAccountTransaction.TransactionDate >=" + dblStartDate +
                        " and GLBankAccountTransaction.TransactionDate<" + dblEndDate;
                }
                else if (_HasMaxDate)
                {
                    
                    double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and GLBankAccountTransaction.TransactionDate<" + dblEndDate;
                }
                if (_EndValue > 0)
                {
                    Returned += " and (" +
                        "(CheckTable.CheckID is not null and CheckTable.CheckValue >=" + _StartValue + "  and CheckTable.CheckValue <= " + _EndValue + ")" +
                        " or (CheckTable.CheckID is null and TransactionValue  >=" + _StartValue + "  and TransactionValue  <= " + _EndValue + ") " +
                        ")";
                }
                if (_Type != 0)
                {
                    Returned += " and TransactionType=" + _Type;
                   
                }
                if (_DirectionStatus != 0)
                {
                    if (_DirectionStatus == 1)
                        Returned += " and TransactionDirection=1 ";
                    else if (_DirectionStatus == 2)
                        Returned += " and TransactionDirection=0 ";
                }
                if (_CachePaymentType != 0)
                {

                    if (_CachePaymentType == 1)
                        Returned += " and TransactionValue <>0 and CheckTable.CheckID is null and TransfereTable.WireTransfereID is null  ";
                    else if (_CachePaymentType == 2)
                        Returned += " and CheckTable.CheckID is not null ";
                    else if (_CachePaymentType == 3)
                    {
                        Returned += " and TransactionValue <>0  and CheckTable.CheckID is null and TransfereTable.WireTransfereID is not null  ";
                        if ( _ReceiptedStatus != 0)
                        {
                            if (_ReceiptedStatus == 1)
                                Returned += " and TransfereTable.WireTransfereReceiptNo is not null and TransfereTable.WireTransfereReceiptNo <> '' ";
                            else if (_ReceiptedStatus == 2)
                                Returned += " and (TransfereTable.WireTransfereReceiptNo is  null or TransfereTable.WireTransfereReceiptNo ='') ";
                        }
                    }
                }
                else
                    Returned += " and (CheckTable.CheckID is not null or TransactionValue <> 0) ";
                if (_AccountIDs != null && _AccountIDs != "")
                {
                    Returned += " and TransactionAccount in (" + _AccountIDs + ")";
                }
                else if (_Account != 0)
                {
                    Returned += " and TransactionAccount=" + _Account;
                }
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strGLAccount = "SELECT  AccountID AS GLAccountID, AccountCode AS GLAccountCode, AccountNameA AS GLAccountNameA "+
                       " FROM   dbo.GLAccount ";
                string Returned = "SELECT TransactionID, TransactionAccount, TransactionValue, TransactionDesc, TransactionDate, TransactionType, TransactionCurrency, "+
                      " TransactionCurrencyValue, TransactionDirection, TransactionCheck, TransactionWireTransfere,CheckTable.*,TransfereTable.* ,AccountTable.* "+
                      ",Case when CheckTable.CheckID is not null then CheckValue else TransactionValue end as RealValue "+
                      ",GLAccountTable.* "+
                      " FROM   dbo.GLBankAccountTransaction "+
                      " inner join ("+ AccountBankDb.SearchStr +") as AccountTable on "+
                      " GLBankAccountTransaction.TransactionAccount = AccountTable.AccountID "+
                      " left outer join ("+new  CheckDb().SearchStr +") as CheckTable on "+
                      " GLBankAccountTransaction.TransactionID = CheckTable.CheckTransactionID "+
                      " left outer join (" + WireTransfereDb.SearchStr + ") as TransfereTable on "+
                      " dbo.GLBankAccountTransaction.TransactionWireTransfere = TransfereTable.WireTransfereID "+
                      " left outer join (" + strGLAccount +
                      ") GLAccountTable on  dbo.GLBankAccountTransaction.TransactionGLAccount = GLAccountTable.GLAccountID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["TransactionID"].ToString());
            _Account = int.Parse(objDr["TransactionAccount"].ToString());
            _Desc = objDr["TransactionDesc"].ToString();
            _Value = double.Parse(objDr["TransactionValue"].ToString());
             _Date = DateTime.Parse(objDr["TransactionDate"].ToString());
             _Type = int.Parse(objDr["TransactionType"].ToString());
            _Currency = int.Parse(objDr["TransactionCurrency"].ToString());
            _CurrencyValue = double.Parse(objDr["TransactionCurrencyValue"].ToString());
            _Direction = bool.Parse(objDr["TransactionDirection"].ToString());
            if(objDr["CheckID"].ToString()!= "")
                _Check = int.Parse(objDr["CheckID"].ToString());
            if(objDr["WireTransfereID"].ToString()!= "")
             _WireTransfere = int.Parse(objDr["TransactionWireTransfere"].ToString());
         _GLAccount = objDr["GLAccountID"].ToString() == "" ? 0 : int.Parse(objDr["GLAccountID"].ToString());
         if (_GLAccount != 0)
         {
             _GLAccountName = objDr["GLAccountNameA"].ToString();
             _GLAccountCode = objDr["GLAccountCode"].ToString();
         }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intDirection = _Direction ? 1 : 0;
            if (_Check != 0)
                _Value = 0;
            string strSql = "insert into GLBankAccountTransaction (TransactionAccount, TransactionValue, TransactionDesc, TransactionDate, TransactionType, TransactionCurrency,"+
                      "TransactionCurrencyValue, TransactionDirection, TransactionCheck, TransactionWireTransfere "+
                      ",TransactionGLAccount,UsrIns,TimIns) values (" + _Account + "," + _Value + ",'" + _Desc + "'," + dblDate + "," + _Type + "," + 
                      _Currency + "," + _CurrencyValue + "," + intDirection + "," +
                      _Check + "," + _WireTransfere  + "," +  _GLAccount  +"," + SysData.CurrentUser.ID +",GetDate())";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            if (_Check != 0)
                _Value = 0;
            double dblDate = _Date.ToOADate() - 2;
            int intDirection = _Direction ? 1 : 0;
            string strSql = "update GLBankAccountTransaction set TransactionAccount=" + _Account +
                ", TransactionValue=" + _Value +
                ", TransactionDesc='" + _Desc + "'" +
                ", TransactionDate=" + dblDate +
                ", TransactionType=" + _Type +
                ", TransactionCurrency=" + _Currency +
                ",TransactionCurrencyValue=" + _CurrencyValue +
                ", TransactionDirection=" + intDirection +
                ", TransactionCheck=" + _Check +
                ", TransactionWireTransfere= " + _WireTransfere +
                ",TransactionGLAccount=" + _GLAccount +
                ",UsrUpd="+ SysData.CurrentUser.ID + ",TimUpd=GetDate() "+
                 " where TransactionID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "delete from dbo.GLBankAccountTransaction where TransactionID=" +_ID;
            strSql += " delete from GLBankWireTransfere where WireTransfereID="+ _WireTransfere;
            strSql += " update GLCheck set TransactionID=0 where TransactionID="+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void ResetCheckTransaction()
        {
            string strSql = "Update GLCheck set TransactionID = 0 where TransactionID="+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = StrSearch;

            #region Paging
            if (_MaxID == 0 && _MinID == 0)
            {
                
               
                DataTable dtTemp = Counting;
                if (dtTemp.Rows.Count > 0)
                {
                    DataRow objDr = dtTemp.Rows[0];
                    if (objDr["ResultCount"].ToString() != "")
                        _ResultCount = int.Parse(objDr["ResultCount"].ToString());//(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
                    if (objDr["ResultValue"].ToString() != "")
                        _ResultValue = double.Parse(objDr["ResultValue"].ToString());
                    if(objDr["ResultInCount"].ToString()!= "")
                    _ResultInCount = int.Parse(objDr["ResultInCount"].ToString());
                    if(objDr["ResultInValue"].ToString() != "")
                    _ResultInValue = double.Parse(objDr["ResultInValue"].ToString());
                    if(objDr["ResultOutCount"].ToString() != "")
                    _ResultOutCount = int.Parse(objDr["ResultOutCount"].ToString());
                    if(objDr["ResultOutValue"].ToString() != "")
                    _ResultOutValue = double.Parse(objDr["ResultOutValue"].ToString());
                if (objDr["CreditValue"].ToString() != "")
                    _CreditValue = double.Parse(objDr["CreditValue"].ToString());
                }
            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and GLCheck.CheckID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and GLCheck.CheckID<" + _MinID;
                }
            }
            #endregion

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
