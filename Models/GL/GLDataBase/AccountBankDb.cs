using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class AccountBankDb
    {
        #region Private Data
        protected int _ID;
        protected int _Bank;
        protected int _Currency;
        protected string _Desc;
        protected string _Code;
        protected string _OwnerName;
        protected int _Type;
        protected int _GLAccount;
        protected string _GLAccountCode;
        protected string _GLAccountName;
        #region Private Date For Search
        bool _HasMaxDate;
        DateTime _StartDate;
        DateTime _EndDate;
        string _BankIDs;
        string _AccountIDs;
        #endregion
        #endregion

        #region Constructors
        public AccountBankDb()
        { 


        }
        public AccountBankDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _Type = int.Parse(objDR["AccountType"].ToString());
            _Bank = int.Parse(objDR["AccountBank"].ToString());
            _Currency = int.Parse(objDR["AccountCurrency"].ToString());
            
        }
        public AccountBankDb(DataRow objDR)
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
        public string OwnerName
        {
            set
            {
                _OwnerName = value;
            }
            get
            {
                return _OwnerName;
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
        public bool HasMaxDate
        {
            set
            {
                _HasMaxDate = value;
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
        public string GLAccountCode
        {
            get
            {
                return _GLAccountCode;
            }
        }
        public string GLAccountName
        {
            get
            {
                return _GLAccountName;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strAccount = "SELECT   AccountID AS GLAccountID, AccountCode AS GLAccountCode, AccountNameA AS GLAccountCodeName "+
                       " FROM  dbo.GLAccount ";
                string Returned = " SELECT     dbo.GLBankAccount.AccountID,dbo.GLBankAccount.AccountCode,dbo.GLBankAccount.AccountOwnerName"+
                    ",dbo.GLBankAccount.AccountDesc, dbo.GLBankAccount.AccountBank, dbo.GLBankAccount.AccountCurrency," +
                    " dbo.GLBankAccount.AccountType,BankTable.*,GLAccountTable.*  " +
                    "  FROM     GLBankAccount "+
                    " inner join ("+ BankDb.SearchStr +") as BankTable on "+
                    " GLBankAccount.AccountBank = BankTable.BankID  "+
                    " left outer join (" +strAccount + ") as GLAccountTable "+
                    "  ON dbo.GLBankAccount.AccountGLAccount = GLAccountTable.GLAccountID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["AccountID"].ToString());
            _Type = int.Parse(objDR["AccountType"].ToString());
            _Bank = int.Parse(objDR["AccountBank"].ToString());
            _Currency = int.Parse(objDR["AccountCurrency"].ToString());
            _Desc = objDR["AccountDesc"].ToString();
            _Code = objDR["AccountCode"].ToString();
            _OwnerName = objDR["AccountOwnerName"].ToString();
            if (objDR.Table.Columns["GLAccountID"] != null && objDR["GLAccountID"].ToString() != "")
                _GLAccount = int.Parse(objDR["GLAccountID"].ToString());
            if (objDR.Table.Columns["GLAccountCode"] != null )
                _GLAccountCode = objDR["GLAccountCode"].ToString();
            if (objDR.Table.Columns["GLAccountCodeName"] != null )
                _GLAccountName = objDR["GLAccountCodeName"].ToString();
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO GLBankAccount" +
                            " (AccountCode,AccountOwnerName,AccountDesc,AccountBank, AccountCurrency, AccountType,AccountGLAccount)" +
                            " VALUES     ('"+ _Code + "','" + _OwnerName + "','" + _Desc + "'," + _Bank + "," + 
                            _Currency + "," + _Type + "," + _GLAccount + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Edit()
        {
            string strSql = " UPDATE    GLBankAccount" +
                            " SET AccountCode='" + _Code + "'" +
                            ",AccountOwnerName='" + _OwnerName + "'" +
                            ",AccountDesc ='" + _Desc + "' " +
                            " ,AccountBank =" + _Bank + "" +
                            ", AccountCurrency =" + _Currency + "" +
                            ", AccountType = " + _Type + "" +
                            ",AccountGLAccount=" + _GLAccount+
                            " Where AccountID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = " Update GLBankAccount set Dis = GetDate() where AccountID="+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (GLBankAccount.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and AccountID = " + _ID.ToString();
            if(_AccountIDs != null && _AccountIDs != "")
                strSql = strSql + " and AccountID in (" + _AccountIDs + ")";
            if (_Bank != 0)
                strSql += " and AccountBank="+ _Bank;
            if(_BankIDs != null && _BankIDs != "")
                strSql += " and AccountBank in (" + _BankIDs + ")";
            if (_Type != 0)
                strSql += " and AccountType="+_Type;
            if (_Currency != 0)
                strSql += " and AccountCurrency=" + _Currency;
            if (_Desc != null && _Desc != "")
                strSql += " and AccountDesc like '%"+ _Desc +"%'";
            if (_Code != null && _Code != "")
                strSql += " and AccountCode like '%"+ _Code +"%'";
            if (_OwnerName != null && _OwnerName != "")
                strSql += " and AccountOwnerName like '%"+ _OwnerName +"%'";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetAccountCheckCredit()
        {
            string strSql = "SELECT  dbo.GLCheckOut.CheckBankAccount, SUM(dbo.GLCheck.CheckValue) AS TotalValue, " +
                      " SUM(CASE WHEN CheckDirection = 0 THEN dbo.GLCheck.CheckValue ELSE 0 END) AS TotalOutValue,  " +
                      " SUM(CASE WHEN CheckDirection = 1 THEN dbo.GLCheck.CheckValue ELSE 0 END) AS TotalInValue " +
                      " FROM    dbo.GLCheckOut INNER JOIN " +
                      " dbo.GLCheck ON dbo.GLCheckOut.CheckID = dbo.GLCheck.CheckID " +
                      " WHERE   (CheckIsBankOriented = 1) and (dbo.GLCheck.CheckCurrentStatus not in (2,4)) and   (dbo.GLCheck.TransactionID = 0) ";
            double dblEndDate =SysUtility.Approximate( _EndDate.ToOADate() - 2,1,ApproximateType.Up);
            if (_HasMaxDate)
            {

                strSql += " and CheckDueDate < " + dblEndDate;
            }
                      strSql+= " GROUP BY dbo.GLCheckOut.CheckBankAccount ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
