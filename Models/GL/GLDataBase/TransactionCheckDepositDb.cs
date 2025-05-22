using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionCheckDepositDb : TransactionDb
    {
        #region Private Data
        protected int _Account;
        protected double _Check;
        #endregion

        #region Constructors
        public TransactionCheckDepositDb()
        { 

        }
        public TransactionCheckDepositDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _Account = int.Parse(objDR["TransactionAccount"].ToString());
            _Check = double.Parse(objDR["TransactionCheck"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());


        }
        public TransactionCheckDepositDb(DataRow objDR):base(objDR)
        {
            _Account = int.Parse(objDR["TransactionAccount"].ToString());
            _Check = double.Parse(objDR["TransactionCheck"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());
        }
        #endregion

        #region Public Properties
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
        public double Check
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
        public  string SearchStr
        {
            get
            {
                string Returned = " SELECT     TransactionID, TransactionAccount, TransactionCheck, TranActionTable.* FROM    GLTransactionCheckDeposit"+
                                    " INNER JOIN (" + base.SearchStr + ") AS TranActionTable ON  GLTransactionCheckDeposit.TransActionID = TransActionTable.TransActionID";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public override void Add()
        {
            base.Add();
            string strSql = " INSERT INTO GLTransactionCheckDeposit" +
                           " (TransactionID, TransactionAccount, TransactionCheck)" +
                           " VALUES     (" + _ID + "," + _Account + "," + _Check + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();

            string strSql = " UPDATE    GLTransactionCheckDeposit" +
                           " SET  TransactionAccount =" + _Account + "" +
                           " , TransactionCheck =" + _Check + " " +
                           " Where TransactionID =" + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            base.Delete();

            string strSql = " DELETE FROM GLTransactionCheckDeposit WHERE     (TransactionID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (1 = 1)";
            if (_ID != 0)
                strSql = strSql + " and TransactionID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
