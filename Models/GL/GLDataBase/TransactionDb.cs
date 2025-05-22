using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.GL.GLDataBase
{
    public  class TransactionDb
    {
        #region Private Data
        protected int _GeneratedID;
        protected int _ID;
        protected int _PeriodID;
        protected int _SpecificID;
        protected DateTime _Date;
        protected string _Code;
        protected int _Type;
        protected int _Currency;
        protected int _BaseCurrency;
        protected string _BaseCurrencyName;
        protected string _BaseCurrencyCode;
        int _ContractorID;
        protected int _SerialNo;
        protected double _CurrencyValue;
        int _ReversedID;
        protected string _Desc;
        protected double _Value;
        
        int _AccountFrom;
        string _AccountFromCode;
        string _AccountFromNameA;
         
        int _RecursivePeriod;
        int _AccountFromParentID;
        int _AccountFromFamilyID;
        int _AccountTo;
        string _AccountToCode;
        string _AccountToNameA;
        int _AccountToParentID;
        int _AccountToFamilyID;
        int _RecursiveTransactionID;
        int _UsrIns;
        DateTime _TimIns;
        int _UsrUpd;
        DateTime _TimUpd;
        #region Reservation Data
        int _ReservationID;
        DateTime _ReservationDate;
        bool _IsContracted;
        DateTime _ContractingDate;
        string _CustomerStr;
        string _UnitStr;
        int _TowerID;
        string _TowerName;
        string _ProjectName;
        int _CellID;
        int _SystemSource;
        int _SystemType;
        #endregion
        //int _ReservationID;

        protected int _PostStatus;//0 not Determined
                                         //1 Created
                                         //2 Posted
        protected int _EditStatus;

        DataTable _ElementTable;
        string _IDsStr;
        #region Private Data For Search
        protected string _LikeCode;
        bool _IsDateRange;
        bool _IsDateLimited;
        DateTime _StartDate;
        DateTime _EndDate;
        double _StartValue;
        double _EndValue;
        int _PostID;
        int _CellFamilyID;
        string _CellIDs;
        string _UnitCode;
        int _AccountID;
         
        int _CompanyID;
        int _YearID;
        string _AccountIDs;

        string _CostCenterIDs;

        int _HasReservationStatus;/*
                                   * 0 dont care
                                   * 1 only has reservation
                                   * 2 only dont have reservation
                                   */
        int _IsReversingStatus;/*
                                * 0 dont care 
                                * 1 is Reversing
                                * 2 is not Reversing 
                                */

        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        bool _StopElementDetails;
        #endregion
        #endregion
        #region Constructors
        public TransactionDb()
        { 
        }
        public TransactionDb(DataRow objDR)
        {
            SetData(objDR);
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
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
        public int PeriodID
        {
            set
            {
                _PeriodID = value;
            }
            get
            {
                return _PeriodID;
            }
        }
        public int SpecificID
        {
            set 
            {
                _SpecificID = value;
            }
            get
            {
                return _SpecificID;
            }
        }
        public int ReversedID
        {
            set
            {
                _ReversedID = value;
            }
            get
            {
                return _ReversedID;
            }
        }
        public int BaseCurrency
        {
            set
            {
                _BaseCurrency = value;
            }
            get
            {
                return _BaseCurrency;
            }
        }
        public string BaseCurrencyName
        {
            get
            {
                return _BaseCurrencyName;
            }
        }
        public string BaseCurrencyCode
        {
            get
            {
                return _BaseCurrencyCode;
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
        public int PostStatus
        {
            set
            {
                _PostStatus = value;
            }
            get
            {
                return _PostStatus;
            }
        }
        public int EditStatus
        {
            set
            {
                _EditStatus = value;
            }
            get
            {
                return _EditStatus;
            }
        }
        public int AccountFrom
        {
            set
            {
                _AccountFrom = value;
            }
            get
            {
                return _AccountFrom;
            }
        }
        public int AccountTo
        {
            set
            {
                _AccountTo = value;
            }
            get
            {
                return _AccountTo;
            }
        }
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }
        }
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public DataTable ElementTable
        {
            set
            {
                _ElementTable = value;
            }
            get
            {
                 
                return _ElementTable;
            }
        }
        public int RecursiveTransactionID
        {
            set
            {
                _RecursiveTransactionID = value;
            }
            get
            {
                return _RecursiveTransactionID;
            }
        }
        public int GeneratedID
        {
            set
            {
                _GeneratedID = value;
            }
            get
            {
                return _GeneratedID;
            }
        }
        public int SystemSource
        {
            set
            {
                _SystemSource = value;
            }
            get
            {
                return _SystemSource;
            }

        }
        public int SystemType
        {
            set
            {
                _SystemType = value;   
            }
            get
            {
                return _SystemType;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public bool IsDateLimited
        {
            set
            {
                _IsDateLimited = value;
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
        public int AccountID
        {
            set
            {
                _AccountID = value;
            }
        }
        public string AccountIDs
        {
            set
            {
                _AccountIDs = value;
            }
        }
        public string CostCenterIDs
        {
            set
            {
                _CostCenterIDs = value;
            }
        }
        public int CompanyID
        {
            set
            {
                _CompanyID = value;
            }
        }
        public int YearID
        {
            set
            {
                _YearID = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public int PostID
        {
            set
            {
                _PostID = value;
            }
        }
        public int HasReservationStatus
        {
            set
            {
                _HasReservationStatus = value;
            }
        }
        public int IsReversingStatus
        {
            set
            {
                _IsReversingStatus = value;
            }
        }
        public int SerialNo
        {
            get
            {
                return _SerialNo;
            }
        }
        public bool StopElementDetails
        {
            set
            {
                _StopElementDetails = value;
            }
        }
        public int ContractorID
        {
            set
            {
                _ContractorID = value;
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
        public int UsrIns
        {
            get
            {
                return _UsrIns;
            }
        }
        public DateTime TimIns
        {
            get
            {
                return _TimIns;
            }
        }
        public int UsrUpd
        {
            get
            {
                return _UsrUpd;
            }
        }
        public DateTime TimUpd
        {
            get
            {
                return _TimUpd;
            }
        }
        #region ReservationData
        public DateTime ReservationDate
        {
            set
            {
                _ReservationDate = value;
            }
            get
            {
                return _ReservationDate;
            }
        }
        public bool IsContracted
        {
            set
            {
                _IsContracted = value;
            }
            get
            {
                return _IsContracted;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _ContractingDate = value;
            }
            get
            {
                return _ContractingDate;
            }
        }
        public string CustomerStr
        {
            set
            {
                _CustomerStr = value;
            }
            get
            {
                return _CustomerStr;
            }
        }
        public string UnitStr
        {
            set
            {
                _UnitStr = value;
            }
            get
            {
                return _UnitStr;
            }
        }
        public int TowerID
        {
            set
            {
                _TowerID = value;
            }
            get
            {
                return _TowerID;
            }
        }
        public string TowerName
        {
            set
            {
                _TowerName = value;
            }
            get
            {
                return _TowerName;
            }
        }
        public string ProjectName
        {
            set
            {
                _ProjectName = value;
            }
            get
            {
                return _ProjectName;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        #endregion
        #region ToAccount
        public string AccountToCode
        {
            get
            {
                return _AccountToCode;
            }
        }
        public string AccountToNameA
        {
            get
            {
                return _AccountToNameA;
            }
        }
        public int AccountToParentID
        {
            get
            {
                return _AccountToParentID;
            }
        }
        public int AccountToFamilyID
        {
            get
            {
                return _AccountToFamilyID;
            }
        }
        #endregion
        #region FromAccount
        public string AccountFromCode
        {
            get
            {
                return _AccountFromCode;
            }
        }
        public string AccountFromNameA
        {
            get
            {
                return _AccountFromNameA;
            }
        }
        public int AccountFromParentID
        {
            get
            {
                return _AccountFromParentID;
            }
        }
        public int AccountFromFamilyID
        {
            get
            {
                return _AccountFromFamilyID;
            }
        }
        #endregion
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
        public string ReservationStr
        {
            get
            {
                 string strUnitCell = "SELECT DISTINCT " +
                      " TOP (100) PERCENT CASE WHEN COUNT(UnitFullName) = 1 THEN MAX(dbo.CRMUnit.UnitFullName) WHEN COUNT(UnitFullName)  " +
                      " = 2 THEN MAX(UnitFullName) + '&' + MIN(UnitFullName) ELSE MAX(UnitFullName) + '&..&' + MIN(UnitFullName) END AS UnitFullName, " +
                      " dbo.CRMReservation.ReservationID AS CurrentReservation, CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                      " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END AS TowerName, RPCell_2.CellNameA AS ProjectName, " +
                      " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationDate, dbo.CRMReservation.ReservationContractingDate " +
                      " FROM         dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
                      " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                      " dbo.RPCell AS RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID INNER JOIN " +
                      " dbo.CRMReservation ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservation.ReservationID ";
                if (_CellFamilyID != 0)
                    strUnitCell += " and RPCell.CellFamilyID=" + _CellFamilyID;
                else if (_CellIDs != null && _CellIDs != "")
                    strUnitCell += " and RPCell.CellID in (" + _CellIDs + ")";
                if (_UnitCode != null && _UnitCode != "")
                    strUnitCell += " and CRMUnit.UnitFullName like '%" + _UnitCode + "%' ";
                strUnitCell += " GROUP BY RPCell_2.CellNameA, CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                      " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END, dbo.CRMReservation.ReservationID,  " +
                      " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationDate, " +
                      " dbo.CRMReservation.ReservationContractingDate ";

                //" ORDER BY CurrentReservation DESC ";

                string strReservationCustomer = "SELECT dbo.CRMReservationCustomer.ReservationID, CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName) " +
                      " WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName) " +
                      " ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName " +
                      " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                      " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID " +
                      " GROUP BY dbo.CRMReservationCustomer.ReservationID ";
                string Returned = "Select ReservationTable.*,CustomerTable.CustomerFullName " +
                    " from (" + strUnitCell + ") as ReservationTable " +
                    " inner join (" + strReservationCustomer + ") as CustomerTable " +
                    " on ReservationTable.CurrentReservation = CustomerTable.ReservationID ";
                return Returned;
            }
        }
        public  string SearchStr
        {
            get
            {
                string strContractorTransaction = "SELECT DISTINCT TransactionID "+
                      " FROM         (SELECT     StatementGLTransaction AS TransactionID "+
                      "  FROM         dbo.RPContractorStatement "+
                      " WHERE     (StatementGLTransaction > 0) AND (ContractorID = "+ _ContractorID +") "+
                       " UNION "+
                        " SELECT DISTINCT dbo.RPContractorInvoice.InvoiceGLTransaction AS TransactionID "+
                        " FROM         dbo.RPContractorInvoice INNER JOIN "+
                        " dbo.RPContract ON dbo.RPContractorInvoice.ContractID = dbo.RPContract.ContractID "+
                        " WHERE     (dbo.RPContractorInvoice.InvoiceGLTransaction > 0) AND (dbo.RPContract.ContractorID = "+ _ContractorID +") "+
                        " UNION "+
                        " SELECT DISTINCT PaymentTransaction AS TransactionID "+
                        " FROM         dbo.RPContractorPayment "+
                        " WHERE     (PaymentTransaction > 0) AND (ContractorID = "+ _ContractorID +")) AS derivedtbl_1 ";
                string strTransactionElement = "SELECT ElementTransaction, MAX(CASE WHEN ElementDirection = 1 THEN ElementID ELSE 0 END) AS MaxDebitElement, "+
                      " MIN(CASE WHEN ElementDirection = 1 THEN ElementID ELSE square(square(1000)) END) AS MinDebitElement,  "+
                      "MAX(CASE WHEN ElementDirection = 0 THEN ElementID ELSE 0 END) AS MaxCreditElement, "+
                      "MIN(CASE WHEN ElementDirection = 0 THEN ElementID ELSE square(square(1000)) END) AS MinCreditElement, "+
                      "SUM(CASE WHEN ElementDirection = 1 THEN ElementValue ELSE 0 END) AS DebitValue, SUM(CASE WHEN ElementDirection = 0 THEN ElementValue ELSE 0 END) "+
                      " AS CreditValue, SUM(CASE WHEN ElementDirection = 1 THEN 1 ELSE 0 END) AS DebitCount, SUM(CASE WHEN ElementDirection = 0 THEN 1 ELSE 0 END) "+
                      " AS CreditCount "+
                      " FROM   dbo.GLTransactionElement "+
                      " GROUP BY ElementTransaction ";
                //if(_AccountID == 0)
                string strAccount = "SELECT dbo.GLAccount.AccountID, dbo.GLAccount.AccountCode, "+
                      " CASE WHEN dbo.GLAccount.AccountID = GLAccount_2.AccountID THEN GLAccount_2.AccountNameA WHEN GLAccount_1.AccountID = GLAccount_2.AccountID THEN GLAccount_2.AccountNameA "+
                       "+ '-' + dbo.GLAccount.AccountNameA ELSE GLAccount_2.AccountNameA + '-' + GLAccount_1.AccountNameA + '-' + GLAccount.AccountNameA END AS AccountNameA, "+
                      " dbo.GLAccount.AccountParentID, dbo.GLAccount.AccountFamilyID "+
                      " FROM         dbo.GLAccount INNER JOIN "+
                      " dbo.GLAccount AS GLAccount_1 ON dbo.GLAccount.AccountParentID = GLAccount_1.AccountID INNER JOIN "+
                      " dbo.GLAccount AS GLAccount_2 ON GLAccount_1.AccountFamilyID = GLAccount_2.AccountID"; 
               
                strTransactionElement = "select ElementTable.ElementTransaction,ElementTable.CreditValue,ElementTable.DebitValue " +
                    ", case "+
                    "when ElementTable.DebitCount = 1 then MaxDebitAccountTable.AccountCode  " +
                    "when ElementTable.DebitCount = 2 then MinDebitAccountTable.AccountCode +'&'+ MaxDebitAccountTable.AccountCode  " +
                     "when ElementTable.DebitCount > 2 then MinDebitAccountTable.AccountCode +'&..&'+ MaxDebitAccountTable.AccountCode  " +
                     " else '' end as DebitAccountCode "+
                      ", case " +
                    "when ElementTable.CreditCount = 1 then MaxCreditAccountTable.AccountCode  " +
                    "when ElementTable.CreditCount = 2 then MinCreditAccountTable.AccountCode +'&'+ MaxCreditAccountTable.AccountCode  " +
                     "when ElementTable.CreditCount > 2 then MinCreditAccountTable.AccountCode +'&..&'+ MaxCreditAccountTable.AccountCode  " +
                     " else '' end as CreditAccountCode " +
                       ", case " +
                    "when ElementTable.DebitCount = 1 then MaxDebitAccountTable.AccountNameA  " +
                    "when ElementTable.DebitCount = 2 then MinDebitAccountTable.AccountNameA +'&'+ MaxDebitAccountTable.AccountNameA  " +
                     "when ElementTable.DebitCount > 2 then MinDebitAccountTable.AccountNameA +'&..&'+ MaxDebitAccountTable.AccountNameA  " +
                     " else '' end as DebitAccountName " +
                      ", case " +
                    "when ElementTable.CreditCount = 1 then MaxCreditAccountTable.AccountNameA  " +
                    "when ElementTable.CreditCount = 2 then MinCreditAccountTable.AccountNameA +'&'+ MaxCreditAccountTable.AccountNameA  " +
                     "when ElementTable.CreditCount > 2 then MinCreditAccountTable.AccountNameA +'&..&'+ MaxCreditAccountTable.AccountNameA  " +
                     " else '' end as CreditAccountName " +
                    " from ("+ strTransactionElement + ") as ElementTable "+
                    " inner join GLTransactionElement as MaxDebitElementTable "+
                    " on ElementTable.MaxDebitElement = MaxDebitElementTable.ElementID  "+
                      " inner join GLTransactionElement as MinDebitElementTable " +
                    " on ElementTable.MinDebitElement = MinDebitElementTable.ElementID  " +
                      " inner join GLTransactionElement as MaxCreditElementTable " +
                    " on ElementTable.MaxCreditElement = MaxCreditElementTable.ElementID  " +
                      " inner join GLTransactionElement as MinCreditElementTable " +
                    " on ElementTable.MinCreditElement = MinCreditElementTable.ElementID  " +
                    " left outer join ("+ strAccount +") as MaxDebitAccountTable  "+
                    " on MaxDebitElementTable.ElementAccount = MaxDebitAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MinDebitAccountTable  " +
                    " on MinDebitElementTable.ElementAccount = MinDebitAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MaxCreditAccountTable  " +
                    " on MaxCreditElementTable.ElementAccount = MaxCreditAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MinCreditAccountTable  " +
                    " on MinCreditElementTable.ElementAccount = MinCreditAccountTable.AccountID ";
                string strReservation = ReservationStr;

                string strCurrentAccount = "SELECT DISTINCT ElementTransaction  " +
                       " FROM         dbo.GLTransactionElement " +
                       " WHERE   (1=1) ";
                if(_AccountIDs!= null && _AccountIDs!= "")
                      strCurrentAccount += " and (ElementAccount in  ("+ _AccountIDs +")) ";
                  if (_CostCenterIDs != null && _CostCenterIDs != "")
                      strCurrentAccount += " and (ElementCostCenter in (" + _CostCenterIDs +  ")) ";
                string strBaseCurrency = "SELECT  CurrencyID AS BaseCurrencyID, CurrencyCode AS BaseCurrencyCode"+
                    ", CurrencyNameA AS BaseCurrencyName "+
                    " FROM         dbo.COMMONCurrency ";
                string strReverseTransaction  = "SELECT  TransactionReversedID, MAX(TransactionID) AS MainTransactionID "+
                      " FROM  dbo.GLTransaction "+
                      " WHERE     (TransactionReversedID <> 0) "+
                      " GROUP BY TransactionReversedID ";
                string Returned = " SELECT     GLTransaction.TransactionID, GLTransaction.TransactionDate" +
                    ", GLTransaction.TransactionCode, GLTransaction.TransactionType,TransactionSerialNo, " +
                              " GLTransaction.TransactionCurrency, GLTransaction.TransactionCurrencyValue, GLTransaction.TransactionDesc, " +
                              " GLTransaction.TransactionStatus,GLTransaction.UsrIns as TransactionUsrIns"+
                              ",GLTransaction.TimIns as TransactionTimIns,GLTransaction.UsrUpd as TransactionUsrUpd,GLTransaction.TimUpd as TransactionTimUpd " +
                              ",JournalTypeTable.*,CurrencyTable.*" +
                    //",ReservationTable.* " +

                            ",PeriodTable.*,BaseCurrencyTable.* " +
                            ",dbo.GLTransaction.TransactionRecursiveTransactionID  " +
                            ",SpecificTable.* ";
                if(!_StopElementDetails)
                 Returned +=",ElementTable.*";
             Returned += " FROM  GLTransaction left outer JOIN (" + JournalTypeDb.SearchStr + ") as JournalTypeTable " +
             " ON GLTransaction.TransactionType = JournalTypeTable.JournalTypeID " +
             " left outer join (" + CurrencyDb.SearchStr + ") as CurrencyTable " +
             " on GLTransaction.TransactionCurrency = CurrencyTable.CurrencyID  " +

             " left outer join (" + strReverseTransaction + ") as ReversedTable  " +
             " on GLTransaction.TransactionID = ReversedTable.TransactionReversedID " +

             " inner join (" + FinancialPeriodDb.SearchStr + ") as PeriodTable " +
             " on GLTransaction.TransactionPeriod = PeriodTable.PeriodID " +
             " left outer join (" + strBaseCurrency + ") as BaseCurrencyTable " +
             " on GLTransaction.TransactionBaseCurrency = BaseCurrencyTable.BaseCurrencyID " +
             " left outer join (" + SpecificDB.SearchStr + ")  as SpecificTable " +
             " on GLTransaction.TransactionSpecific = SpecificTable.SpecificID ";
             //if ((_AccountIDs != null && _AccountIDs != "") || !_StopElementDetails)
             //    Returned += " inner join ("+ strCurrentAccount +") CurrentAccountTable " +
             //        " on GLTransaction.TransactionID = CurrentAccountTable.ElementTransaction ";
                if((_AccountIDs != null && _AccountIDs != "") || !_StopElementDetails)
                             Returned+= "  inner join (" + strCurrentAccount +") CurrentAccountTable "+
                              " on GLTransaction.TransactionID = CurrentAccountTable.ElementTransaction ";
                if(!_StopElementDetails)
                              Returned += " inner join (" + strTransactionElement + ") as ElementTable " +
                                            " on GLTransaction.TransactionID = ElementTable.ElementTransaction ";
                          if (_ContractorID != 0)
                              Returned += " inner join (" + strContractorTransaction + ") as ContractorTable "+
                                  " on GLTransaction.TransactionID = ContractorTable.TransactionID ";
                Returned += "  where (1=1) ";
                if ((_CellIDs != null && _CellIDs != "") ||
                    _CellFamilyID != 0 || (_UnitCode != null && _UnitCode != ""))
                    _HasReservationStatus = 1;
                if (_HasReservationStatus != 0 )
                {
                    if (_HasReservationStatus == 1)
                        Returned += " and ReservationTable.CurrentReservation is not null ";
                    else if(_HasReservationStatus == 2)
                        Returned += " and ReservationTable.CurrentReservation is null ";
                }
                if (_IsReversingStatus != 0)
                {
                    if (_IsReversingStatus == 1)
                        Returned += " and ((dbo.GLTransaction.TransactionReversedID is not null and dbo.GLTransaction.TransactionReversedID <> 0) or ReversedTable.TransactionReversedID is not null)";
                    else if (_IsReversingStatus == 2)
                        Returned += " and ((dbo.GLTransaction.TransactionReversedID is null or dbo.GLTransaction.TransactionReversedID = 0) and ReversedTable.TransactionReversedID is  null)";

                }
                if (_ID != 0)
                    Returned = Returned + " and  GLTransaction.TransactionID = " + _ID + " ";
                if (_Code != null && _Code != "")
                    Returned = Returned + " and  TransactionCode = '" + _Code + "'";
                if (_LikeCode != null && _LikeCode != "")
                    Returned = Returned + " and  TransactionCode like '%" + _LikeCode + "%'";
                if (_Currency != 0)
                    Returned = Returned + " and TransactionCurrency = " + _Currency + " ";
                if (_Type != 0)
                    Returned = Returned + " and  TransactionType = " + _Type + "";
                if (_PostStatus != 0)
                {
                    if(_PostStatus == 1)
                        Returned+= " and (TransactionPost is null or TransactionPost =0)  ";
                    else
                        Returned+= " and (TransactionPost is not null and TransactionPost <>0)  ";
                }
                if (_EditStatus != 0)
                {
                    if (_EditStatus == 1)
                        Returned += " and ((TransactionPost is null or TransactionPost =0) "+
                            " and (TransactionSystemSourceID is null or TransactionSystemSourceID =0) )  ";
                    else
                        Returned += " and ((TransactionPost is not null and TransactionPost <>0)  "+
                             " and (TransactionSystemSourceID is not null and TransactionSystemSourceID <>0) ) ";
                }
                double dblStart = 0;
                double dblEnd = 0;
                dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                dblEnd = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                if (_IsDateRange)
                {

                    Returned += " and TransactionDate >= " + dblStart + " and TransactionDate < " + dblEnd;


                }
                if (_IsDateLimited)
                {

                    Returned +=  " and TransactionDate < " + dblEnd;


                }
                if (_EndValue > _StartValue)
                {

                    Returned += " and TransactionValue >=" + _StartValue +
                        " and TransactionValue <= " + _EndValue;

                }
                if (_CompanyID != 0)
                    Returned += " and PeriodTable.YearCompanyID = " + _CompanyID;
                if (_YearID != 0)
                    Returned += " and PeriodTable.YearID="+_YearID;
                if (_PeriodID != 0)
                    Returned += " and PeriodTable.PeriodID ="+_PeriodID;
                if (_SpecificID != 0)
                    Returned += " and SpecificTable.SpecificID="+_SpecificID;
               // Returned = strTransactionElement;
                if (_SystemSource != 0 && _SystemType != 0)
                    Returned += " and GLTransaction.TransactionSyetemType =" + _SystemType +
                        " and dbo.GLTransaction.TransactionSystemSourceID = " + _SystemSource;
                return Returned;
            }
        }
        
        public  string AddStr
        {
        get
        {
            double dblDate = SysUtility.Approximate( _Date.ToOADate() - 2,1,ApproximateType.Down);
            _PostStatus = 1;
            string Returned = " INSERT INTO GLTransaction" +
                            " (TransactionPeriod,TransactionSpecific, TransactionDate, TransactionCode, TransactionType" +
                            ", TransactionCurrency, TransactionBaseCurrency, TransactionCurrencyValue, "+
                           " TransactionDesc, TransactionStatus, TransactionPost, TransactionReversedID,TransactionSystemSourceID,TransactionSyetemType"+ 
                           ", UsrIns, TimIns " +
                           ")" +
                            " VALUES     (" + _PeriodID + "," + _SpecificID + ","+ dblDate + ",'" + 
                            _Code + "'," + _Type +  "," +
                            _Currency + "," + _BaseCurrency  + "," + _CurrencyValue + 
                            ",'" + _Desc + "'," + _PostStatus + "," + _PostID + "," + _ReversedID + "," + _SystemSource + "," + _SystemType + ","+
                            + SysData.CurrentUser.ID + ",GetDate()) ";
            return Returned;
        }
        }
        public string EditStr
        {
            get
            {
                double dblDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                string Returned = " UPDATE    GLTransaction" +
                            " SET TransactionPeriod=" + _PeriodID +
                            ",TransactionSpecific="+_SpecificID +
                            ",TransactionDate =" + dblDate + "" +
                            " ,TransactionCode = '" + _Code + "'" +
                            " ,TransactionType =" + _Type + "" +
                            ", TransactionCurrency="+ _Currency +
                            ",TransactionBaseCurrency="+_BaseCurrency +
                            ",TransactionCurrencyValue=" + _CurrencyValue +
                            //" ,TransactionCurrency = " + _Currency + "" +
                            //" ,TransactionCurrencyValue = " + _CurrencyValue + "" +
                            ", TransactionDesc ='" + _Desc + "'" +
                            ",TransactionStatus=" + _PostStatus +
                            ",TransactionPost=" + _PostID +
                            ",TransactionReversedID=" + _ReversedID +
                    //", TransactionStatus = " + _Status + "" +
                            ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                            ", TimUpd = GetDate()" +
                            " WHERE     TransactionID = " + _ID + " ";
                return Returned;
            }
        }
        public string[] JoinElementStatment
        {
            get
            {
                string[] arrStr;
                if (_ElementTable == null)
                    return new string[0] ;
                arrStr = new string[_ElementTable.Rows.Count + 1];
                arrStr[0] = " DELETE FROM GLTransactionElement  WHERE     (ElementTransaction = " + _ID + ")";
                int intIndex = 1;
                TransactionElementDb objDb;
                foreach (DataRow objDr in _ElementTable.Rows)
                {
                  
                    objDb = new TransactionElementDb(objDr);
                    objDb.TRansaction = ID;
                    arrStr[intIndex] = objDb.AddStr;

                    intIndex++;

                }
                return arrStr;
            }
        }
        #region Public Accessorice Set Onley For Search
        public string LikeCode
        {
            set
            {
                _LikeCode = value;
            }
        }
        #endregion
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["TransactionID"] == null || objDR["TransactionID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["TransactionID"].ToString());
            if(objDR.Table.Columns["TransactionDate"]!= null&& objDR["TransactionDate"].ToString()!= "")
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
        if (objDR.Table.Columns["TransactionCode"] != null && objDR["TransactionCode"].ToString() != "")
            _Code = objDR["TransactionCode"].ToString();
        if (objDR.Table.Columns["TransactionType"] != null && objDR["TransactionType"].ToString() != "")
            _Type = int.Parse(objDR["TransactionType"].ToString());
        if (objDR.Table.Columns["TransactionCurrency"] != null && objDR["TransactionCurrency"].ToString() != "")
            _Currency = int.Parse(objDR["TransactionCurrency"].ToString());
        if (objDR.Table.Columns["PeriodID"] != null && objDR["PeriodID"].ToString() != "")
                _PeriodID = int.Parse(objDR["PeriodID"].ToString());
            if (objDR.Table.Columns["TransactionCurrencyValue"] != null && objDR["TransactionCurrencyValue"].ToString() != "")
            _CurrencyValue = double.Parse(objDR["TransactionCurrencyValue"].ToString());
        if (objDR.Table.Columns["BaseCurrencyID"] != null && objDR["BaseCurrencyID"].ToString() != "")
            _BaseCurrency = int.Parse(objDR["BaseCurrencyID"].ToString());
        if (objDR.Table.Columns["BaseCurrencyCode"] != null && objDR["BaseCurrencyCode"].ToString() != "")
            _BaseCurrencyCode = objDR["BaseCurrencyCode"].ToString();
        if (objDR.Table.Columns["BaseCurrencyName"] != null && objDR["BaseCurrencyName"].ToString() != "")
            _BaseCurrencyName = objDR["BaseCurrencyName"].ToString();
        if (objDR.Table.Columns["TransactionDesc"] != null && objDR["TransactionDate"].ToString() != "")
            _Desc = objDR["TransactionDesc"].ToString();
        if (objDR.Table.Columns["TransactionDate"] != null && objDR["TransactionDate"].ToString() != "")
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());
            //if(objDR["TransactionValue"].ToString()!= "")
            if(objDR.Table.Columns["DebitValue"]!= null && objDR["DebitValue"].ToString()!="")
               _Value = double.Parse(objDR["DebitValue"].ToString());
            if (objDR.Table.Columns["SpecificID"] != null&& objDR["SpecificID"].ToString() != "")
                _SpecificID = int.Parse(objDR["SpecificID"].ToString());
            if (objDR.Table.Columns["TransactionRecursiveTransactionID"] != null &&
                objDR["TransactionRecursiveTransactionID"].ToString() != "")
                _RecursiveTransactionID = int.Parse(objDR["TransactionRecursiveTransactionID"].ToString());
            if (objDR.Table.Columns["CurrentReservation"]!= null &&
                objDR["CurrentReservation"].ToString() != "")
            {
                _ReservationID = int.Parse(objDR["CurrentReservation"].ToString());
                if (objDR.Table.Columns["ReservationDate"] != null)
                {
                    _ReservationDate = DateTime.Parse(objDR["ReservationDate"].ToString());
                    _IsContracted = false;
                    if (objDR["ReservationContractingDate"].ToString() != "")
                    {
                        _ContractingDate = DateTime.Parse(objDR["ReservationContractingDate"].ToString());
                        _IsContracted = true;
                    }
                    _CustomerStr = objDR["CustomerFullName"].ToString();
                    _TowerName = objDR["TowerName"].ToString();
                    _UnitStr = objDR["UnitFullName"].ToString();
                    _ProjectName = objDR["ProjectName"].ToString();
                }
            }

                if (objDR.Table.Columns["CreditAccountCode"] != null)
                {
                    _AccountFromCode = objDR["CreditAccountCode"].ToString();
                    _AccountFromNameA = objDR["CreditAccountName"].ToString();
                 
                }




                if (objDR.Table.Columns["DebitAccountCode"] != null)
                {
                    _AccountToCode = objDR["DebitAccountCode"].ToString();
                    _AccountToNameA = objDR["DebitAccountName"].ToString();
                   
                }
                if (objDR.Table.Columns["TransactionUsrIns"] != null && objDR["TransactionUsrIns"].ToString() != "")
                    _UsrIns = int.Parse(objDR["TransactionUsrIns"].ToString());


                if (objDR.Table.Columns["TransactionUsrUpd"] != null && objDR["TransactionUsrUpd"].ToString() != "")
                    _UsrUpd = int.Parse(objDR["TransactionUsrUpd"].ToString());
                if (objDR.Table.Columns["TransactionTimIns"] != null && objDR["TransactionTimIns"].ToString() != "")
                    _TimIns =DateTime.Parse(objDR["TransactionTimIns"].ToString());
                if (objDR.Table.Columns["TransactionTimUpd"] != null && objDR["TransactionTimUpd"].ToString() != "")
                    _TimUpd = DateTime.Parse(objDR["TransactionTimUpd"].ToString());
                if (objDR.Table.Columns["TransactionSerialNo"] != null && objDR["TransactionSerialNo"].ToString() != "")
                _SerialNo = int.Parse(objDR["TransactionSerialNo"].ToString());
            if (objDR.Table.Columns["GeneratedID"] != null && objDR["GeneratedID"].ToString() != "")
                _GeneratedID = int.Parse(objDR["GeneratedID"].ToString());
            if (objDR.Table.Columns["TransactionSystemSourceID"] != null && objDR["TransactionSystemSourceID"].ToString() != "")
                _SystemSource = int.Parse(objDR["TransactionSystemSourceID"].ToString());
            if (objDR.Table.Columns["TransactionSyetemType"] != null && objDR["TransactionSyetemType"].ToString() != "")
                _SystemType = int.Parse(objDR["TransactionSyetemType"].ToString());

           
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
           
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            string strMaxSerial = " SELECT     MAX(TransactionSerialNo) AS MaxTransactionSerialNo " +
                " FROM         dbo.GLTransaction "+
                " GROUP BY TransactionPeriod, TransactionType "+
                " HAVING      (TransactionPeriod = "+ _PeriodID +") AND (TransactionType = "+_Type +") ";
            string strSetSerialNo = " update GLTransaction  set TransactionSerialNo = ("+ strMaxSerial +")+1 "+
                  " WHERE     (TransactionID = "+ _ID  +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSetSerialNo);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(JoinElementStatment);

        }
        public virtual void Edit()
        {
            double dblDate = Date.ToOADate() - 2;
            string strSql = EditStr;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(JoinElementStatment);
        }
        public virtual void Delete()
        {
            string strSql = " DELETE FROM GLTransaction WHERE     (GLTransactionID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void PostTransaction()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            PostTransactionDb objDb = new PostTransactionDb();
            objDb.Add();
            string[] arrStr = new string[2];
            string strSql = "Update GLTransaction Set TransactionPost =" + objDb.ID + 
                ",TransactionStatus=2 "+
                " where TransactionID in (" + _IDsStr + ") and (TransactionPost=0)"  ;
            arrStr[0] = strSql; 
            strSql = "UPDATE    GlAccount "+
              " SET              AccountDebitBalance = AccountDebitBalance + TransactionTable.Debit, AccountCreditBalance = AccountCreditBalance + TransactionTable.Credit "+
              " FROM         (SELECT     accountid, SUM((CASE WHEN elementdirection = 0 THEN ElementValue ELSE 0 END)) AS Debit,  "+
              " SUM(CASE WHEN elementdirection = 1 THEN ElementValue ELSE 0 END) AS Credit "+
               " FROM         dbo.GLAccount INNER JOIN "+
              " dbo.GLTransactionElement ON dbo.GLAccount.AccountID = dbo.GLTransactionElement.ElementAccount INNER JOIN "+
              " dbo.GLTransaction ON dbo.GLTransactionElement.ElementTransaction = dbo.GLTransaction.TransactionID "+
              " WHERE     GLTransaction.TransactionPost = "+ objDb.ID.ToString() +" "+
               " GROUP BY AccountID) AS TransactionTable INNER JOIN "+
               " GLAccount ON TransactionTable.AccountID = GLAccount.AccountID ";
            arrStr[1] = strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrStr);

        }
        public void UnPostTransaction()
        {
            if ((_IDsStr == null || _IDsStr == "") && _PostID == 0)
                return;
        
            string[] arrStr = new string[2];
            string strSql = "Update GLTransaction Set TransactionPost =0" +
                ",TransactionStatus=1 " +
                " where TransactionID in (" + _IDsStr + ") and (TransactionPost="+ _PostID +")";
            arrStr[0] = strSql;
            strSql = "UPDATE    GlAccount " +
              " SET              AccountDebitBalance = AccountDebitBalance - TransactionTable.Debit, AccountCreditBalance = AccountCreditBalance - TransactionTable.Credit " +
              " FROM         (SELECT     accountid, SUM((CASE WHEN elementdirection = 0 THEN ElementValue ELSE 0 END)) AS Debit,  " +
              " SUM(CASE WHEN elementdirection = 1 THEN ElementValue ELSE 0 END) AS Credit " +
               " FROM         dbo.GLAccount INNER JOIN " +
              " dbo.GLTransactionElement ON dbo.GLAccount.AccountID = dbo.GLTransactionElement.ElementAccount INNER JOIN " +
              " dbo.GLTransaction ON dbo.GLTransactionElement.ElementTransaction = dbo.GLTransaction.TransactionID " +
              " WHERE     GLTransaction.TransactionPost = " + _PostID+ " " +
               " GROUP BY AccountID) AS TransactionTable INNER JOIN " +
               " GLAccount ON TransactionTable.AccountID = GLAccount.AccountID ";
            arrStr[1] = strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrStr);

        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            if (_MaxID == 0 && _MinID == 0)
            {
                string strCountSql = "select count(*) as ResultCount,sum(CreditValue) as ResultValue from (" +
                    strSql + ")  AS NativeTable ";
                DataTable dtReultTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                if (dtReultTemp.Rows.Count > 0)
                {
                    _ResultCount = int.Parse(dtReultTemp.Rows[0]["ResultCount"].ToString());
                    if (dtReultTemp.Rows[0]["ResultValue"].ToString() != "")
                        _ResultValue = double.Parse(dtReultTemp.Rows[0]["ResultValue"].ToString());
                }


            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and GLTransaction.TransactionID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and GLTransaction.TransactionID<" + _MinID;
                }
            }
            int intCount = 1500;
            strSql = "select distinct top "+ intCount +" * from (" + strSql + ") as NativeTable " +
                        " ORDER BY  TransactionID "; 
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            if (Returned.Rows.Count > 0)
            {
                List<string> arrStr = SysUtility.GetStringArr(Returned, "TransactionID", intCount);
                if (arrStr.Count > 0)
                    TransactionElementDb.CacheTransactionIDs = arrStr[0];
                else
                    TransactionElementDb.CacheTransactionIDs = "";

            }
            else
                TransactionElementDb.CacheTransactionIDs = "";
            TransactionElementDb.CacheElementTable = null;
            return Returned;
        }
        public DataTable GetMaxPeriodJournalTypeTransaction()
        {
            string strSql = SearchStr;
            strSql += " and TransactionID in ("+
                "SELECT     MAX(TransactionID) AS MaxTransactionID "+
                " FROM         dbo.GLTransaction "+
                " GROUP BY TransactionPeriod, TransactionType "+
                " HAVING      (TransactionPeriod = "+ _PeriodID +") AND (TransactionType = "+_Type +") "+
                ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}