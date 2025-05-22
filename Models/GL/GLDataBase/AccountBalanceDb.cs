using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class AccountBalanceDb
    {
        #region Private Data
        protected int _ID;
        protected int _Account;
        protected string _Desc;
        protected double _Credit;
        protected double _Debit;
        protected double _ElementCredit;
        protected double _ElementDebit;
        protected DateTime _Date;
        protected DataTable _BalanceTable;
        #endregion

        #region Constractors
        public AccountBalanceDb()
        { 

        }
        public AccountBalanceDb(DataRow objDR)
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
        public double ElementCredit
        {
            set
            {
                _ElementCredit = value;

            }
            get
            {
                return _ElementCredit;
            }
        }
        public double ElementDebit
        {
            set
            {
                _ElementDebit = value;

            }
            get
            {
                return _ElementDebit;
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
        public DataTable BalanceTable
        {
            set
            {
                _BalanceTable = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     BalanceID, BalanceAccount, BalanceDesc, BalanceValue, BalanceDate" +
                                  " FROM         GLAccountBalance ";
                return Returned;
            }
        }
       
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["BalanceID"].ToString());
            _Account = int.Parse(objDR["BalanceAccount"].ToString());
            _Desc = objDR["BalanceDesc"].ToString();
          
            _Date = DateTime.Parse(objDR["BalanceDate"].ToString());
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO GLAccountBalance"+
                            " (BalanceAccount, BalanceDesc, BalanceValue, BalanceDate)"+
                            " VALUES     ("+_Account+",'"+_Desc+"',"+_Debit+","+dblDate+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " UPDATE    GLAccountBalance" +
                            " SET   BalanceAccount ="+_Account+"" +
                            " , BalanceDesc ='"+_Desc+"'" +
                            " , BalanceValue ="+_Debit+"" +
                            " , BalanceDate = "+dblDate+"" +
                            " Where BalanceID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLAccountBalance" +
                            " WHERE     (BalanceID = "+_ID+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and  BalanceID = " + _ID;
            if (_Account != 0)
                strSql = strSql + " and  BalanceAccount =" + _Account;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditBalance()
        {
            if (_BalanceTable == null || _BalanceTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_BalanceTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _BalanceTable.Rows)
            {
                arrStr[intIndex] = "insert into GLAccountBalance (BalanceAccount, BalanceDesc, BalanceCredit, BalanceDebit, BalanceDate, UsrIns, TimIns)  " +
                    " values (" + objDr["AccountID"].ToString() + ",'" + objDr["BalanceDesc"].ToString() + "'," +
                    objDr["BalanceCredit"].ToString() + "," + objDr["BalanceDebit"].ToString() + ",GetDate()," + SysData.CurrentUser.ID + ",GetDate()) ";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
