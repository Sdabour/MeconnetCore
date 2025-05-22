using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class AccountCostCenterDb
    {
        #region Private Data
        int _ID;
        int _Account;
        int _CostCenter;
        int _CostCenterLevel;
        bool _IsStopped;
        double _Debit;
        double _Credit;
        string _BalanceDesc;
        DataTable _AccountCostCenterTable;
        #endregion
        #region Constructors
        public AccountCostCenterDb() 
        {
        }
        public AccountCostCenterDb(DataRow objDr)
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
        public int CostCenterLevel
        {
            get
            {
                return _CostCenterLevel;
            }
        }
        public bool IsStopped
        {
            set
            {
                _IsStopped = value;
            }
            get
            {
                return _IsStopped;
            }
        }
        public double Debit
        {
            set
            {
                _Debit = value;
            }
            get
            {
                return _Debit;
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
        public string BalanceDesc
        {
            set
            {
                _BalanceDesc = value;
            }
            get
            {
                return _BalanceDesc;
            }
        }
        public DataTable AccountCostCenterTable
        {
            set
            {
                _AccountCostCenterTable = value;
            }
        }
        public string AddStr
        {
            get
            {
                int intIsStopped = _IsStopped ? 1 : 0;
                string Returned = "insert into GLAccountCostCenter ( Account, CostCenter"+
                    ", IsStopped, UsIns, TimIns) " +
                    " values ("+ _Account + "," + _CostCenter + "," + intIsStopped + "," + 
                    SysData.CurrentUser.ID +  ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intIsStopped = _IsStopped ? 1 : 0;
                string Returned = "update GLAccountCostCenter set   IsStopped = " + intIsStopped +
                    " where   AccountCostCenterID = " + _ID + " and Account= "+_Account; 
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                AccountDb objAccountDb = new AccountDb();
                string strCostCenterBlanace = "SELECT  BalanceAccount, BalanceCostCenter, MAX(BalanceID) AS MaxBalanceID "+
                       " FROM         dbo.GLAccountBalance "+
                       " GROUP BY BalanceCostCenter, BalanceAccount ";
                strCostCenterBlanace = "SELECT dbo.GLAccountBalance.BalanceAccount, dbo.GLAccountBalance.BalanceCostCenter"+
                    ", dbo.GLAccountBalance.BalanceDesc, dbo.GLAccountBalance.BalanceCredit, "+
                    " dbo.GLAccountBalance.BalanceDebit "+
                    " FROM         dbo.GLAccountBalance INNER JOIN "+
                    " ("+ strCostCenterBlanace +") AS MaxTable "+
                    " ON dbo.GLAccountBalance.BalanceID = MaxTable.MaxBalanceID AND  "+
                    " dbo.GLAccountBalance.BalanceAccount = MaxTable.BalanceAccount AND "+
                    " dbo.GLAccountBalance.BalanceCostCenter = MaxTable.BalanceCostCenter ";
                string Returned = "SELECT  AccountCostCenterID, Account, CostCenter, IsStopped "+
                   ",AccountTable.*,CostCenterTable.* "+
                   ",BalanceTable.BalanceDebit AccountCostCenterBlanceDebit,BalanceTable.BalanceCredit as AccountCostCenterBalanceCredit "+
                       " FROM         dbo.GLAccountCostCenter "+
                       " inner join ("+ objAccountDb.SearchStr +") as AccountTable "+
                       " on GLAccountCostCenter.Account = AccountTable.AccountID  "+
                       " inner join ("+ CostCenterDb.SearchStr +") CostCenterTable "+
                       " on GLAccountCostCenter.CostCenter = CostCenterTable.CostCenterID "+
                       " left outer join (" + strCostCenterBlanace + ") as BalanceTable "+
                       " on GLAccountCostCenter.Account = BalanceTable.BalanceAccount "+
                       " and GLAccountCostCenter.CostCenter = BalanceTable.BalanceCostCenter ";
                return Returned;
            }
        }
        public static string SearchNodeStr
        {
            get
            {
                string strCostCenterBlanace = "SELECT  BalanceAccount, BalanceCostCenter, MAX(BalanceID) AS MaxBalanceID " +
                     " FROM         dbo.GLAccountBalance " +
                     " GROUP BY BalanceCostCenter, BalanceAccount ";
                strCostCenterBlanace = "SELECT dbo.GLAccountBalance.BalanceAccount, dbo.GLAccountBalance.BalanceCostCenter" +
                    ", dbo.GLAccountBalance.BalanceDesc, dbo.GLAccountBalance.BalanceCredit, " +
                    " dbo.GLAccountBalance.BalanceDebit " +
                    " FROM         dbo.GLAccountBalance INNER JOIN " +
                    " (" + strCostCenterBlanace + ") AS MaxTable " +
                    " ON dbo.GLAccountBalance.BalanceID = MaxTable.MaxBalanceID AND  " +
                    " dbo.GLAccountBalance.BalanceAccount = MaxTable.BalanceAccount AND " +
                    " dbo.GLAccountBalance.BalanceCostCenter = MaxTable.BalanceCostCenter ";
                string strCostCenter = "SELECT  GLCostCenter_1.CostCenterID, dbo.GLAccountCostCenter.Account,GLAccountCostCenter.IsStopped " +
                       " FROM         dbo.GLAccountCostCenter INNER JOIN " +
                      " dbo.GLCostCenter ON dbo.GLAccountCostCenter.CostCenter = dbo.GLCostCenter.CostCenterID INNER JOIN "+
                      " dbo.GLCostCenter AS GLCostCenter_1 ON GLCostCenter_1.CostCenterID = dbo.GLCostCenter.CostCenterID "+
                      " WHERE     (dbo.GLAccountCostCenter.IsStopped = 0) ";
                AccountDb objAccountDb = new AccountDb();
                string Returned = "SELECT  0 as AccountCostCenterID, Account,0 as CostCenter, IsStopped " +
                   ",AccountTable.*,CostCenterTable.* " +
                   ",BalanceTable.BalanceDebit AccountCostCenterBlanceDebit,BalanceTable.BalanceCredit as AccountCostCenterBalanceCredit " +
                       " FROM        ("+ strCostCenter +") as AccountCostCenterTable " +
                       " inner join (" + objAccountDb.SearchStr + ") as AccountTable " +
                       " on AccountCostCenterTable.Account = AccountTable.AccountID  " +
                       " inner join (" + CostCenterDb.SearchStr + ") CostCenterTable " +
                       " on AccountCostCenterTable.CostCenterID = CostCenterTable.CostCenterID "+
                         " left outer join (" + strCostCenterBlanace + ") as BalanceTable " +
                       " on AccountTable.AccountID = BalanceTable.BalanceAccount " +
                       " and CostCenterTable.CostCenterID = BalanceTable.BalanceCostCenter "+
                       " ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["AccountCostCenterID"].ToString() != "")
                _ID = int.Parse(objDr["AccountCostCenterID"].ToString());
            if (objDr["AccountID"].ToString() != "")
                _Account = int.Parse(objDr["AccountID"].ToString());
            if (objDr["CostCenterID"].ToString() != "")
                _CostCenter = int.Parse(objDr["CostCenterID"].ToString());
            if (objDr["IsStopped"].ToString() != "")
                _IsStopped = bool.Parse(objDr["IsStopped"].ToString());
            if (objDr.Table.Columns["AccountCostCenterBlanceDebit"] != null &&
                objDr["AccountCostCenterBlanceDebit"].ToString() != "")
                _Debit = double.Parse(objDr["AccountCostCenterBlanceDebit"].ToString());
            if (objDr.Table.Columns["AccountCostCenterBalanceCredit"] != null &&
                objDr["AccountCostCenterBalanceCredit"].ToString() != "")
                _Credit = double.Parse(objDr["AccountCostCenterBalanceCredit"].ToString());
            if (objDr.Table.Columns["CostCenterLevel"] != null && objDr["CostCenterLevel"].ToString() != "")
                _CostCenterLevel = int.Parse(objDr["CostCenterLevel"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_Account != 0)
                strSql += " and AccountTable.AccountID=" + _Account;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetNodes()
        {
            string strSql = SearchNodeStr + " where (1=1) ";
            if (_Account != 0)
                strSql += " and AccountTable.AccountID=" + _Account;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditBalance()
        {
            if (_AccountCostCenterTable == null || _AccountCostCenterTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_AccountCostCenterTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _AccountCostCenterTable.Rows)
            {
                arrStr[intIndex] = "insert into GLAccountBalance (BalanceAccount,BalanceCostCenter, BalanceDesc, BalanceCredit, BalanceDebit, BalanceDate, UsrIns, TimIns)  " +
                    " values (" + objDr["AccountID"].ToString() + "," + objDr["CostCenterID"].ToString() + ",'" + objDr["BalanceDesc"].ToString() + "'," +
                    objDr["Credit"].ToString() + "," + objDr["Debit"].ToString() + ",GetDate()," + SysData.CurrentUser.ID + ",GetDate()) ";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
