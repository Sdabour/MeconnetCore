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
    public class RecursiveTransactionDb
    {
        #region Private Data
        protected int _ID;
    
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected string _Code;
        protected int _Type;
        protected int _SpecificID;
        protected int _Currency;
        protected int _BaseCurrency;
        protected string _BaseCurrencyName;
        protected string _BaseCurrencyCode;
        protected int _Company;
        protected double _CurrencyValue;
      
        protected string _Desc;
        protected double _Value;

        int _AccountFrom;
        string _AccountFromCode;
        string _AccountFromNameA;
       
        int _AccountTo;
        string _AccountToCode;
        string _AccountToNameA;
     

        DataTable _ElementTable;
        string _IDsStr;
        #region Private Data For Search
        protected string _LikeCode;
        bool _StartDateStatus;
        DateTime _StartSearchDate;
        DateTime _EndSearchDate;
        double _StartValue;
        double _EndValue;
        int _PeriodID;
   
        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        #endregion
        #endregion
        #region Constructors
        public RecursiveTransactionDb()
        {
        }
        public RecursiveTransactionDb(DataRow objDR)
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
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
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
        public int Company
        {
            set
            {
                _Company = value;
            }
            get
            {
                return _Company;
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
        public bool DateStatus
        {
            set
            {
                _StartDateStatus = value;
            }
        }
        public DateTime StartSearchDate
        {
            set
            {
                _StartSearchDate = value;
            }
        }
        public DateTime EndSearchDate
        {
            set
            {
                _EndSearchDate = value;
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
      
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public int PeriodID
        {
            set
            {
                _PeriodID = value;
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
        public string SearchStr
        {
            get
            {

                string strTransactionElement = "SELECT ElementTransaction, MAX(CASE WHEN ElementDirection = 1 THEN ElementID ELSE 0 END) AS MaxDebitElement, " +
                      " MIN(CASE WHEN ElementDirection = 1 THEN ElementID ELSE square(square(1000)) END) AS MinDebitElement,  " +
                      "MAX(CASE WHEN ElementDirection = 0 THEN ElementID ELSE 0 END) AS MaxCreditElement, " +
                      "MIN(CASE WHEN ElementDirection = 0 THEN ElementID ELSE square(square(1000)) END) AS MinCreditElement, " +
                      "SUM(CASE WHEN ElementDirection = 1 THEN ElementValue ELSE 0 END) AS DebitValue, SUM(CASE WHEN ElementDirection = 0 THEN ElementValue ELSE 0 END) " +
                      " AS CreditValue, SUM(CASE WHEN ElementDirection = 1 THEN 1 ELSE 0 END) AS DebitCount, SUM(CASE WHEN ElementDirection = 0 THEN 1 ELSE 0 END) " +
                      " AS CreditCount " +
                      " FROM   dbo.GLRecursiveTransactionElement " +
                      " GROUP BY ElementTransaction ";
                //if(_AccountID == 0)
                string strAccount = "SELECT   AccountID , AccountCode , AccountNameA , AccountParentID, " +
                  " AccountFamilyID  " +
                  " FROM         dbo.GLAccount ";

                strTransactionElement = "select ElementTable.ElementTransaction,ElementTable.CreditValue,ElementTable.DebitValue " +
                    ", case " +
                    "when ElementTable.DebitCount = 1 then MaxDebitAccountTable.AccountCode  " +
                    "when ElementTable.DebitCount = 2 then MinDebitAccountTable.AccountCode +'&'+ MaxDebitAccountTable.AccountCode  " +
                     "when ElementTable.DebitCount > 2 then MinDebitAccountTable.AccountCode +'&..&'+ MaxDebitAccountTable.AccountCode  " +
                     " else '' end as DebitAccountCode " +
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
                    " from (" + strTransactionElement + ") as ElementTable " +
                    " inner join GLRecursiveTransactionElement as MaxDebitElementTable " +
                    " on ElementTable.MaxDebitElement = MaxDebitElementTable.ElementID  " +
                      " inner join GLRecursiveTransactionElement as MinDebitElementTable " +
                    " on ElementTable.MinDebitElement = MinDebitElementTable.ElementID  " +
                      " inner join GLRecursiveTransactionElement as MaxCreditElementTable " +
                    " on ElementTable.MaxCreditElement = MaxCreditElementTable.ElementID  " +
                      " inner join GLRecursiveTransactionElement as MinCreditElementTable " +
                    " on ElementTable.MinCreditElement = MinCreditElementTable.ElementID  " +
                    " left outer join (" + strAccount + ") as MaxDebitAccountTable  " +
                    " on MaxDebitElementTable.ElementAccount = MaxDebitAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MinDebitAccountTable  " +
                    " on MinDebitElementTable.ElementAccount = MinDebitAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MaxCreditAccountTable  " +
                    " on MaxCreditElementTable.ElementAccount = MaxCreditAccountTable.AccountID " +
                     " left outer join (" + strAccount + ") as MinCreditAccountTable  " +
                    " on MinCreditElementTable.ElementAccount = MinCreditAccountTable.AccountID "; 
           
                string strBaseCurrency = "SELECT  CurrencyID AS BaseCurrencyID, CurrencyCode AS BaseCurrencyCode" +
                    ", CurrencyNameA AS BaseCurrencyName " +
                    " FROM         dbo.COMMONCurrency ";
            
                string Returned = " SELECT dbo.GLRecursiveTransaction.TransactionID, dbo.GLRecursiveTransaction.TransactionCompany, dbo.GLRecursiveTransaction.TransactionStartDate, "+
                      " dbo.GLRecursiveTransaction.TransactionEndDate, dbo.GLRecursiveTransaction.TransactionCode, dbo.GLRecursiveTransaction.TransactionType, "+
                      " dbo.GLRecursiveTransaction.TransactionCurrency, dbo.GLRecursiveTransaction.TransactionBaseCurrency, dbo.GLRecursiveTransaction.TransactionCurrencyValue, "+
                      " dbo.GLRecursiveTransaction.TransactionDesc "+
                       ",JournalTypeTable.*,CurrencyTable.*" +

                            ",ElementTable.*,BaseCurrencyTable.*,CompanyTable.*,SpecificTable.* " +
                              " FROM  GLRecursiveTransaction INNER JOIN (" + JournalTypeDb.SearchStr + ") as JournalTypeTable " +
                              " ON GLRecursiveTransaction.TransactionType = JournalTypeTable.JournalTypeID " +
                              " inner join (" + CurrencyDb.SearchStr + ") as CurrencyTable " +
                              " on GLRecursiveTransaction.TransactionCurrency = CurrencyTable.CurrencyID  " +
                              " inner join (" + strTransactionElement + ") as ElementTable " +
                              " on GLRecursiveTransaction.TransactionID = ElementTable.ElementTransaction " +
                              " left outer join (" + strBaseCurrency + ") as BaseCurrencyTable " +
                              " on GLRecursiveTransaction.TransactionBaseCurrency = BaseCurrencyTable.BaseCurrencyID "+
                              " left outer join ("+ CompanyDB.SearchStr  +") as CompanyTable "+
                              " on dbo.GLRecursiveTransaction.TransactionCompany = CompanyTable.CompanyID  "+
                              " left outer join (" + SpecificDB.SearchStr + ")  as SpecificTable " +
                              " on GLRecursiveTransaction.TransactionSpecific = SpecificTable.SpecificID ";

                if (_PeriodID != 0)
                {
                    string strPeriod = "SELECT  PeriodStartDate, PeriodEndDate,YearCompany " +
                      " FROM         dbo.GLFinancialPeriod " +
                      " inner join GLFinancialYear " +
                      " on   dbo.GLFinancialPeriod.PeriodYear = dbo.GLFinancialYear.YearID "+
                      " WHERE     (PeriodID = " + _PeriodID + ") ";
                    Returned += " inner  join (" + strPeriod + ") as PeriodTable "+
                        " on dbo.GLRecursiveTransaction.TransactionCompany = PeriodTable.YearCompany ";
                    Returned += " where  ("+
                        " (dbo.GLRecursiveTransaction.TransactionStartDate <= PeriodTable.PeriodEndDate AND "+
                        " dbo.GLRecursiveTransaction.TransactionStartDate >= PeriodTable.PeriodStartDate) "+
                        " or ( dbo.GLRecursiveTransaction.TransactionEndDate <= PeriodTable.PeriodEndDate AND "+
                        " dbo.GLRecursiveTransaction.TransactionEndDate >= PeriodTable.PeriodStartDate)"+
                        /////////
                        " or (dbo.GLRecursiveTransaction.TransactionStartDate <= PeriodTable.PeriodStartDate AND "+
                        " dbo.GLRecursiveTransaction.TransactionEndDate >= PeriodTable.PeriodStartDate) " +
                        " or ( dbo.GLRecursiveTransaction.TransactionStartDate <= PeriodTable.PeriodEndDate AND "+
                        " dbo.GLRecursiveTransaction.TransactionEndDate >= PeriodTable.PeriodEndDate)" +
                        ")";
                }
                else
                {
                    Returned += "  where (1=1) ";
                }
                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {
                string Returned = SearchStr;
              
                if (_ID != 0)
                    Returned = Returned + " and  GLRecursiveTransaction.TransactionID = " + _ID + " ";
                if (_Code != null && _Code != "")
                    Returned = Returned + " and  TransactionCode = '" + _Code + "'";
                if (_LikeCode != null && _LikeCode != "")
                    Returned = Returned + " and  TransactionCode like '%" + _LikeCode + "%'";
                if (_Currency != 0)
                    Returned = Returned + " and TransactionCurrency = " + _Currency + " ";
                if (_Type != 0)
                    Returned = Returned + " and  TransactionType = " + _Type + "";
            
                double dblStart = 0;
                double dblEnd = 0;
                if (_StartDateStatus)
                {

                    dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEnd = SysUtility.Approximate(_EndSearchDate.ToOADate() - 2, 1, ApproximateType.Up);

                    Returned += " and TransactionDate >= " + dblStart + " and TransactionDate < " + dblEnd;


                }
                if (_EndValue > _StartValue)
                {

                    Returned += " and TransactionValue >=" + _StartValue +
                        " and TransactionValue <= " + _EndValue;

                }
           
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
              
                string Returned = " INSERT INTO GLRecursiveTransaction" +
                                " ( TransactionSpecific,TransactionCompany,TransactionStartDate,TransactionEndDate, TransactionCode, TransactionType" +
                                ", TransactionCurrency, TransactionBaseCurrency, TransactionCurrencyValue, " +
                               " TransactionDesc, UsrIns, TimIns " +
                               ")" +
                                " VALUES     (" + _SpecificID + ","  + _Company + "," + dblStartDate + "," + dblEndDate + ",'" + _Code + "'," + _Type + "," +
                                _Currency + "," + _BaseCurrency + "," + _CurrencyValue +
                                ",'" + _Desc  + "',"
                                + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string Returned = " UPDATE    GLRecursiveTransaction" +
                                " SET TransactionStartDate =" + dblStartDate + "" +
                                ",TransactionEndDate=" + dblEndDate +
                                ",TransactionCompany=" + _Company +
                                ",TransactionSpecific="+ _SpecificID +
                                " ,TransactionCode = '" + _Code + "'" +
                                " ,TransactionType =" + _Type + "" +
                                " ,TransactionCurrency = " + _Currency + "" +
                                ",TransactionBaseCurrency=" + _BaseCurrency +
                                " ,TransactionCurrencyValue = " + _CurrencyValue + "" +
                                ", TransactionDesc =" + _Desc + "" +
                                ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                                ", TimUpd = GetDate()" +
                                " WHERE     GLRecursiveTransactionID = " + _ID + " ";
                return Returned;
            }
        }
        public string[] JoinElementStatment
        {
            get
            {
                string[] arrStr;
                if (_ElementTable == null)
                    return new string[0];
                arrStr = new string[_ElementTable.Rows.Count + 1];
                arrStr[0] = " DELETE FROM GLRecursiveTransactionElement  WHERE     (ElementTransaction = " + _ID + ")";
                int intIndex = 1;
                RecursiveTransactionElementDb objDb;
                foreach (DataRow objDr in _ElementTable.Rows)
                {

                    objDb = new RecursiveTransactionElementDb(objDr);
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
            _StartDate = DateTime.Parse(objDR["TransactionStartDate"].ToString());
            _EndDate = DateTime.Parse(objDR["TransactionEndDate"].ToString());
            _Code = objDR["TransactionCode"].ToString();
            _Type = int.Parse(objDR["TransactionType"].ToString());
            
            _Currency = int.Parse(objDR["TransactionCurrency"].ToString());
            _CurrencyValue = double.Parse(objDR["TransactionCurrencyValue"].ToString());
            if (objDR["BaseCurrencyID"].ToString() != "")
                _BaseCurrency = int.Parse(objDR["BaseCurrencyID"].ToString());
            _BaseCurrencyCode = objDR["BaseCurrencyCode"].ToString();
            _BaseCurrencyName = objDR["BaseCurrencyName"].ToString();
            _Desc = objDR["TransactionDesc"].ToString();
            if(objDR["CompanyID"].ToString()!= "")
              _Company = int.Parse(objDR["CompanyID"].ToString());
          if (objDR["SpecificID"].ToString() != "")
              _SpecificID = int.Parse(objDR["SpecificID"].ToString());
            //if(objDR["TransactionValue"].ToString()!= "")
            _Value = double.Parse(objDR["DebitValue"].ToString());
          
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




        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {

            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);

            SysData.SharpVisionBaseDb.ExecuteNonQuery(JoinElementStatment);

        }
        public virtual void Edit()
        {
         string strSql = EditStr;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(JoinElementStatment);
        }
        public virtual void Delete()
        {
            string strSql = " DELETE FROM GLRecursiveTransaction WHERE     (GLRecursiveTransactionID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
      
        public DataTable Search()
        {
            string strSql = StrSearch;
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
                    strSql += " and GLRecursiveTransaction.TransactionID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and GLRecursiveTransaction.TransactionID<" + _MinID;
                }
            }
            strSql = "select distinct top 1000 * from (" + strSql + ") as NativeTable " +
                        " ORDER BY  TransactionID ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            return Returned;
        }
        #endregion
    }
}