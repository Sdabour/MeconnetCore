using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionElementDb
    {
        #region Private Data
        protected int _ID;
        protected int _Transaction;
        protected int _Account;
        protected string _AccountCode;
        protected string _AccountName;
        protected bool _Direction;
        protected double _Value;
        protected int _Order;
        protected int _CostCenter;
        int _SystemSource;
        int _SystemType;
        int _ContractorID;
        protected string _CostCenterCode;
        protected string _CostCenterName;
        protected int _CellID;
        protected string _CellName;
        protected string _CellFamilyName;
        protected int _CellFamilyID;
        protected string _Desc;
        protected double _DebitBalance;
        protected double _CreditBalance;
        protected double _DebitElementBalance;
        protected double _CreditElementBalance;
        protected int _ReservationID;
        protected string _UnitStr;
        protected string _CustomerStr;
        protected string _ProjectStr;
        protected string _TowerStr;
        protected string _SurveyStr;
        #region Private Data for Search
        string _AccountIDs;
        string _CostCenterIDs;
        string _TransactionIDs;
        
        int _AccountLevel;
        protected bool _IsDateRange;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsDateLimited;
        protected int _PeriodID;
        protected int _SpecificID;
        //protected int _CompanyID;
        protected int _Currency;
        protected int _Type;
        protected int _CompanyID;
        protected int _YearID;
        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        #region Private Data for Grouping
        bool _IsCostCenterGrouping;
        bool _IsAccountGrouping;
        bool _IsDayGrouping;
        bool _IsMonthGrouping;
        bool _IsYearGrouping;
        bool _IsFinacialYearGrouping;
        bool _IsFinancialPeriodGrouping;
        bool _IsCompanyGrouping;
        string _PeriodStr;
        string _CompanyStr;
        string _FinacialPeriodStr;
        string _FinancialYearStr;
        string _TypeStr;
        int _Year;
        int _Month;
        int _Day;
        string _AccountStr;
        string _CostCenterStr;

        double _TotalCreditValue;
        double _TotalDebitValue;
        #endregion
        #region Private Data for Caching
        static DataTable _CacheElementTable;
        static string _CacheTransactionIDs;
        #endregion
        #endregion
        #endregion
        #region Constractors
        public TransactionElementDb()
        {

        }
        public TransactionElementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int TRansaction
        {
            set
            {
                _Transaction = value;
            }
            get
            {
                return _Transaction;
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
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
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
        public int AccountLevel
        {
            set
            {
                _AccountLevel = value;
            }
        }
        public string TransactionIDs
        {
            set
            {
                _TransactionIDs = value;
            }
        }
        public int Type
        {
            set
            {
                _Type = value;
            }
        }
        public int Currency
        {
            set
            {
                _Currency = value;
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
        public int SpecificID
        {
            set
            {
                _SpecificID = value;
            }
        }
        public int CompanyID
        {
            set
            {
                _CompanyID = value;
            }
        }
        public int PeriodID
        {
            set
            {
                _PeriodID = value;
            }
        }
        public int YearID
        {
            set
            {
                _YearID = value;
            }
        }
        public static string CacheTransactionIDs
        {
            set
            {
                _CacheElementTable = null;
                _CacheTransactionIDs = value;
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
        public bool IsCostCenterGrouping
        {
            set
            {
                _IsCostCenterGrouping = value;
            }
        }

        public bool IsAccountGrouping
        {
            set
            {
                _IsAccountGrouping = value;
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
        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
        }
        public string AccountName
        {
            get 
            {
                return _AccountName;
            }
        }
        public string CostCenterCode
        {
            get
            {
                return _CostCenterCode;
            }
        }
        public string CostCenterName
        {
            get
            {
                return _CostCenterName;
            }
        }
        public double TotalCreditValue
        {
            get
            {
                return _TotalCreditValue;
            }
        }
        public double TotalDebitValue
        {
            get
            {
                return _TotalDebitValue;
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
        public int ReservationID
        {
            set
            {
                _ReservationID= value;
            }
            get
            {
                return _ReservationID;
            }
        }
        public string UnitStr
        {
            get
            {
                return _UnitStr ;
            }
        }
        public string CustomerStr
        {
            get
            {
                return _CustomerStr;
            }
        }
        public string ProjectStr
        {
            get
            {
                return _ProjectStr;
            }
        }
        public string TowerStr
        {
            get
            {
                return _TowerStr;
            }
        }
        public string SurveyStr
        {
            get
            {
                return _SurveyStr;
            }
        }
        public string CellName
        {
            set
            {
                _CellName = value;
            }
            get
            {
                return _CellName;
            }
        }
        public string CellFamilyName
        {
            set
            {
                _CellFamilyName = value;
            }
            get
            {
                return _CellFamilyName;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
            get
            {
                return _CellFamilyID;
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
        public int ContractorID
        {
            set 
            {
                _ContractorID = value;
            }
        }
        public static DataTable CacheElementTable
        {
            set
            {
                _CacheElementTable = value;
            }
            get
            {
                if (_CacheElementTable == null && _CacheTransactionIDs != null && _CacheTransactionIDs != "")
                {
                    TransactionElementDb objDb = new TransactionElementDb();
                    objDb.TransactionIDs = _CacheTransactionIDs;

                    string strSql = objDb.SearchStr;
                    //objDb.TransactionIDs = _CacheTransactionIDs;
                    _CacheElementTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql); 
                }
                if (_CacheElementTable != null)
                    return _CacheElementTable;
                else
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("TransactionID"),new DataColumn("ElementOrder")});
                    return dtTemp;
                }
            }
        }
        public  virtual string SearchStr
        {
            get
            {
                TransactionDb objTransactionDb = new TransactionDb();
                objTransactionDb.StopElementDetails = true;
                objTransactionDb.IsDateLimited = _IsDateLimited;
                objTransactionDb.IsDateRange = _IsDateRange;
                objTransactionDb.StartDate = _StartDate;
                objTransactionDb.EndDate = _EndDate;
                objTransactionDb.SpecificID = _SpecificID;
                objTransactionDb.Type = _Type;
                objTransactionDb.PeriodID = _PeriodID;
                objTransactionDb.CompanyID = _CompanyID;
                objTransactionDb.YearID = _YearID;
                objTransactionDb.ContractorID = _ContractorID;
                string strTransaction = objTransactionDb.SearchStr;
                //strTransaction = "";
                string strCell = "SELECT RPCell_1.CellNameA AS ElementCellName, dbo.RPCell.CellID AS ElementCellFamilyID, dbo.RPCell.CellNameA AS ElementCellFamilyName" +
                    ", RPCell_1.CellID as ElementCellID "+
                       " FROM   dbo.RPCell INNER JOIN "+
                        " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellID = RPCell_1.CellFamilyID ";
                string strBalance = "SELECT     BalanceAccount,BalanceCostCenter, MAX(BalanceID) AS MaxBalanceID " +
                                   " FROM     dbo.GLAccountBalance  " +
                                    " GROUP BY BalanceAccount,BalanceCostCenter  ";
                strBalance = "SELECT     dbo.GLAccountBalance.BalanceAccount,dbo.GLAccountBalance.BalanceCostCenter, dbo.GLAccountBalance.BalanceDesc" +
                    ", dbo.GLAccountBalance.BalanceCredit," +
                    " dbo.GLAccountBalance.BalanceDebit,  " +
                    " dbo.GLAccountBalance.BlanceElementCredit, dbo.GLAccountBalance.BalanceElementDebit, dbo.GLAccountBalance.BalanceDate " +
                    " FROM         dbo.GLAccountBalance INNER JOIN " +
                    "(" + strBalance + ") AS MaxBalanceTable ON dbo.GLAccountBalance.BalanceID = MaxBalanceTable.MaxBalanceID AND  " +
                     " dbo.GLAccountBalance.BalanceAccount = MaxBalanceTable.BalanceAccount "+
                     " and dbo.GLAccountBalance.BalanceCostCenter = MaxBalanceTable.BalanceCostCenter ";
                AccountDb objAccountDb = new AccountDb();
                string Returned = " SELECT     GLTransactionElement.ElementID, GLTransactionElement.ElementTransaction,GLTransactionElement.ElementDesc, GLTransactionElement.ElementAccount, " +
                                  " GLTransactionElement.ElementValue, GLTransactionElement.ElementDirection,GLTransactionElement.ElementCell " +
                                  ",GLTransactionElement.ElementOrder,GLTransactionElement.ElementReservation" +
                                  ",AccountTable.*,CostCenterTable.*,TransactionTable.*,BalanceTable.* " +
                                  ",CellTable.* "+
                                  " FROM     GLTransactionElement INNER JOIN" +
                                  " (" + objAccountDb.SearchStr + ") as AccountTable "+
                                  " ON GLTransactionElement.ElementAccount = AccountTable.AccountID "+
                                  " left outer join (" + CostCenterDb.SearchStr +  ") as CostCenterTable "+
                                  " on  GLTransactionElement.ElementCostCenter = CostCenterTable.CostCenterID "+
                                  " inner join ("+ strTransaction +") as TransactionTable "+
                                  " on GLTransactionElement.ElementTransaction = TransactionTable.TransactionID "+
                                  " left outer join ("+ strBalance +") as BalanceTable "+
                                  " on  GLTransactionElement.ElementAccount = BalanceTable.BalanceAccount "+
                                  " and GLTransactionElement.ElementCostCenter = BalanceTable.BalanceCostCenter  " +
                                  " left outer join (" + strCell + ") as CellTable "+
                                  " on GLTransactionElement.ElementCell = CellTable.ElementCellID "+
                                  " where (1=1) ";
                if (_ID != 0)
                    Returned +=   " and  ElemntID = " + _ID + " ";
                if (_Transaction != 0)
                   Returned += " and  GLTransactionElement.ElementTransaction =" + _Transaction;
               if (_Account != 0)
                   Returned += " and GLTransactionElement.ElementAccount =" +_Account;
                if(_AccountIDs != null && _AccountIDs != "")
                    Returned += " and GLTransactionElement.ElementAccount in (" + _AccountIDs + ") ";
                if (_CostCenter != 0)
                    Returned += " and CostCenterTable.CostCenterID ="+ _CostCenter;
                if(_CostCenterIDs != null && _CostCenterIDs!= "")
                    Returned += " and CostCenterTable.CostCenterID in (" + _CostCenterIDs + ") ";
              
               if(_TransactionIDs!= null && _TransactionIDs!="")
                   Returned += " and  GLTransactionElement.ElementTransaction in (" + _TransactionIDs + ") ";
               if (_SystemSource != 0 && _SystemType != 0)
                   Returned += " and GLTransactionElement.ElementSystemSourceID= " + _SystemSource +
                       " and GLTransactionElement.ElementSyetemType=" + _SystemType;
                return Returned;
            }
        }
        public string SearchSumStr
        {
            get
            {
                 
                string Returned = "";
                string strSelect = "sum(case when ElementDirection = 0 then ElementValue else 0 end) as TotalCreditValue" +
                    ",sum(case when ElementDirection = 1 then ElementValue else 0 end) as TotalDebitValue ";
                string strGroup = "";
                string strOrder = "";
              
                if (_IsAccountGrouping)
                {
                    strSelect += ",AccountID as MainAccountID,AccountCode as MainAccountCode, AccountNameA as MainAccountName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "AccountID,AccountCode, AccountNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "AccountCode";
                }
                if (_IsCostCenterGrouping)
                {
                    strSelect += ",CostCenterID, CostCenterCode, CostCenterNameA,ElementCellName,ElementCellFamilyName,ElementCellID";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += " CostCenterID, CostCenterCode, CostCenterNameA,ElementCellName,ElementCellFamilyName,ElementCellID ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += " CostCenterCode,ElementCellFamilyName,ElementCellName ";
                }
                Returned = "select " + strSelect + " from (" + SearchStr + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
              
                if (_IsAccountGrouping)
                {
                    AccountDb objAccountDb = new AccountDb();
                    Returned = "select ElementTable.*,AccountTable.* " +
                        "  from (" + Returned + ") as ElementTable " +
                        " inner join (" + objAccountDb.SearchStr +") as AccountTable "+
                        " on ElementTable.MainAccountID = AccountTable.AccountID ";
                }
                if (strOrder != "")
                    Returned += " order by  " + strOrder;

                return Returned;
            
            }
        }
        public string AddStr
        {
            get
            {
                string strTransaction = _Transaction == 0 ? "@TransactionID" : _Transaction.ToString();
                int intDirection = _Direction ? 1 : 0;
                string Returned = " INSERT INTO GLTransactionElement " +
                                " (ElementTransaction,ElementDesc, ElementAccount, ElementDirection, ElementValue,ElementCostCenter" +
                                ",ElementOrder,ElementCell,ElementReservation,ElementSystemSourceID,ElementSyetemType)" +
                                " VALUES     (" + strTransaction + ",'" + _Desc + "'," + _Account + "," + intDirection + 
                                "," + _Value + "," + _CostCenter + "," + _Order +"," +  _CellID + "," +_ReservationID + "," +
                                _SystemSource + "," + _SystemType + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intDirection = _Direction ? 1 : 0;
                string Returned = " update  GLTransactionElement " +
                                " set  ElementAccount = " + _Account +
                                ", ElementDirection = " + intDirection +
                                ",ElementDesc='" + _Desc + "'"+
                                ", ElementValue = " + _Value +
                                ",ElementCostCenter="+_CostCenter+
                                ",ElementOrder=" + _Order +
                                ",ElementCell="+ _CellID +
                                ",ElementReservation="+_ReservationID +
                                ",ElementSystemSourceID=" +_SystemSource +
                                ",ElementSyetemType="+ _SystemType +
                                " where ElementTransaction =" + _Transaction +
                                " and ElemntID=" + _ID;
                                
                return Returned;
            }
        }
        public static DataTable EmptyTable
        {
            get
            {
                DataTable Returned =  new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ElemntID"), new DataColumn("ElementTransaction"), new DataColumn("ElementAccount"), new DataColumn("ElementDirection") 
            ,new DataColumn("ElementValue"),new DataColumn("ElementOrder")});
              return Returned;

            }
        }
      
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["ElementID"] == null && objDR.Table.Columns["TotalCreditValue"] != null)
            {
                SetSumData(objDR);
                return;
            }
            _ID = int.Parse(objDR["ElementID"].ToString());
            _Transaction = int.Parse(objDR["ElementTransaction"].ToString());
            _Desc = objDR["ElementDesc"].ToString();
            _Account = int.Parse(objDR["ElementAccount"].ToString());
            _Direction = bool.Parse(objDR["ElementDirection"].ToString());
            _Value = double.Parse(objDR["ElementValue"].ToString());
            if(objDR["ElementOrder"].ToString()!="")
            _Order = int.Parse(objDR["ElementOrder"].ToString());
        if (objDR.Table.Columns["CostCenterID"] != null && objDR["CostCenterID"].ToString() != "")
            _CostCenter = int.Parse(objDR["CostCenterID"].ToString());
        if (objDR.Table.Columns["ElementCostCenter"] != null && objDR["ElementCostCenter"].ToString() != "")
            _CostCenter = int.Parse(objDR["ElementCostCenter"].ToString());
        if (objDR.Table.Columns["BalanceCredit"]!=null && objDR["BalanceCredit"].ToString() != "")
            _CreditBalance = double.Parse(objDR["BalanceCredit"].ToString());
        if (objDR.Table.Columns["BalanceDebit"]!= null && objDR["BalanceDebit"].ToString() != "")
            _DebitBalance = double.Parse(objDR["BalanceDebit"].ToString());
        if (objDR.Table.Columns["ElementCell"] != null && objDR["ElementCell"].ToString() != "")
            _CellID = int.Parse(objDR["ElementCell"].ToString());
        if (objDR.Table.Columns["ElementCellName"] != null)
            _CellName = objDR["ElementCellName"].ToString();
        if (objDR.Table.Columns["ElementCellFamilyName"] != null)
            _CellFamilyName = objDR["ElementCellFamilyName"].ToString();
        if (objDR.Table.Columns["ElementCellFamilyID"] != null && objDR["ElementCellFamilyID"].ToString()!= "")
            _CellFamilyID = int.Parse(objDR["ElementCellFamilyID"].ToString());
        if (objDR.Table.Columns["ElementSystemSourceID"] != null && objDR["ElementSystemSourceID"].ToString() != "")
            _SystemSource = int.Parse(objDR["ElementSystemSourceID"].ToString());
        if (objDR.Table.Columns["ElementSyetemType"] != null && objDR["ElementSyetemType"].ToString() != "")
            _SystemType = int.Parse(objDR["ElementSyetemType"].ToString());
            if(objDR.Table.Columns["ElementReservation"]!= null&& objDR["ElementReservation"].ToString()!= "")
                _ReservationID = int.Parse(objDR["ElementReservation"].ToString());
        }
        void SetSumData(DataRow objDr)
        {
            if(objDr.Table.Columns["TotalCreditValue"]!= null && objDr["TotalCreditValue"].ToString()!= "")
            _TotalCreditValue = double.Parse(objDr["TotalCreditValue"].ToString());
            if(objDr.Table.Columns["TotalDebitValue"]!= null && objDr["TotalDebitValue"].ToString()!= "")
            _TotalDebitValue = double.Parse(objDr["TotalDebitValue"].ToString());
            if (objDr.Table.Columns["AccountID"] != null && objDr["AccountID"].ToString() != "")
                _Account = int.Parse(objDr["AccountID"].ToString());
            if (objDr.Table.Columns["AccountCode"] != null)
                _AccountCode = objDr["AccountCode"].ToString();
            if (objDr.Table.Columns["AccountNameA"] != null)
                _AccountName = objDr["AccountNameA"].ToString();
            if (objDr.Table.Columns["CostCenterID"] != null && objDr["CostCenterID"].ToString() != "")
                _CostCenter = int.Parse(objDr["CostCenterID"].ToString());
            if (objDr.Table.Columns["CostCenterNameA"] != null)
                _CostCenterName = objDr["CostCenterNameA"].ToString();
            if (objDr.Table.Columns["CostCenterCode"] != null)
                _CostCenterCode = objDr["CostCenterCode"].ToString();
            if (objDr.Table.Columns["BalanceCredit"] != null && objDr["BalanceCredit"].ToString() != "")
                _CreditBalance = double.Parse(objDr["BalanceCredit"].ToString());
            if (objDr.Table.Columns["BalanceDebit"] != null && objDr["BalanceDebit"].ToString() != "")
                _DebitBalance = double.Parse(objDr["BalanceDebit"].ToString());
            if (objDr.Table.Columns["ElementCell"] != null && objDr["ElementCell"].ToString() != "")
                _CellID = int.Parse(objDr["ElementCell"].ToString());
            if (objDr.Table.Columns["ElementCellName"] != null)
                _CellName = objDr["ElementCellName"].ToString();
            if (objDr.Table.Columns["ElementCellFamilyName"] != null)
                _CellFamilyName = objDr["ElementCellFamilyName"].ToString();

            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerStr = objDr["CustomerFullName"].ToString();
            if (objDr.Table.Columns["UnitFullName"] != null)
                _UnitStr = objDr["UnitFullName"].ToString();
            if (objDr.Table.Columns["ProjectName"] != null)
                _ProjectStr = objDr["ProjectName"].ToString();
            if (objDr.Table.Columns["TowerName"] != null)
                _TowerStr = objDr["TowerName"].ToString();
            if (objDr.Table.Columns["UnitSurvey"] != null)
                _SurveyStr = objDr["UnitSurvey"].ToString();

        }
        #endregion
        #region Public Methods
        public void Add()
        {
         
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            int intDirection = _Direction ? 1 : 0;
            string strSql = " UPDATE    GLTransactionElement"+
                            " SET   ElementTransaction ="+_Transaction+""+
                            " , ElementAccount =" + _Account + "" +
                            " , ElementDirection =" + intDirection + "" +
                            " , ElementValue ="+_Value+""+
                            " WHERE     (ElemntID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLTransactionElement "+
                            " WHERE    (ElemntID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + "";

            if (_MaxID == 0 && _MinID == 0)
            {
                string strCountSql = "select count(*) as ResultCount  from (" +
                    strSql + ")  AS NativeTable ";
                DataTable dtReultTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                if (dtReultTemp.Rows.Count > 0)
                {
                    _ResultCount = int.Parse(dtReultTemp.Rows[0]["ResultCount"].ToString());
                    //if (dtReultTemp.Rows[0]["ResultValue"].ToString() != "")
                    //    _ResultValue = double.Parse(dtReultTemp.Rows[0]["ResultValue"].ToString());
                }


            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and GLTransactionElement.TransactionElementID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and GLTransactionElement.TransactionElementID<" + _MinID;
                }
            }
            int intCount =150000;
            strSql = "select distinct top " + intCount + " * from (" + strSql + ") as NativeTable " +
                        " ORDER BY  ElementID ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        public DataTable SumSearch()
        {
            string strSql = SearchSumStr + "";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
