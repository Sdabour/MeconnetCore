using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionCacheWithdrawDb : TransactionDb
    {
        #region Private Data
        protected int _Account;
        protected double _Value;
        protected int _CurrencyID;
        protected double _CurrencyValue;
        #endregion

        #region Constructors
        public TransactionCacheWithdrawDb()
        { 

        }
        public TransactionCacheWithdrawDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _Account = int.Parse(objDR["TransactionAccount"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _CurrencyID = int.Parse(objDR["TransactionCurrencyID"].ToString());
            _CurrencyValue = double.Parse(objDR["TransactionCurrencyValue"].ToString());


        }
        public TransactionCacheWithdrawDb(DataRow objDR):base(objDR)
        {
            _Account = int.Parse(objDR["TransactionAccount"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _CurrencyID = int.Parse(objDR["TransactionCurrencyID"].ToString());
            _CurrencyValue = double.Parse(objDR["TransactionCurrencyValue"].ToString());
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
        public int CurrencyID
        {
            set
            {
                _CurrencyID = value;
            }
            get
            {
                return _CurrencyID;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _CurrencyValue = Value;
            }
            get
            {
                return _CurrencyValue;
            }
        }
        public  string SearchStr
        {
            get
            {
                string Returned = " SELECT     TransactionID, TransactionAccount, TransactionValue,TransactionCurrencyID,TransactionCurrencyValue, TranActionTable.* FROM    GLTransactionCacheWithdraw" +
                                    " INNER JOIN (" + base.SearchStr + ") AS TranActionTable ON  GLTransactionCacheWithdraw.TransActionID = TransActionTable.TransActionID";
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
            string strSql = " INSERT INTO GLTransactionCacheWithdraw" +
                           " (TransactionID, TransactionAccount, TransactionValue,TransactionCurrencyID,TransactionCurrencyValue)" +
                           " VALUES     (" + _ID + "," + _Account + "," + _Value + ","+_CurrencyID+","+_CurrencyValue+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();
            string strSql = " UPDATE    GLTransactionCacheWithdraw" +
                           " SET  TransactionAccount =" + _Account + "" +
                           " , TransactionValue =" + _Value + " " +
                           " , TransactionCurrencyID = " + _CurrencyID + "" +
                           " , TransactionCurrencyValue = " + _CurrencyValue + "" +
                           " Where TransactionID =" + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            base.Delete();

            string strSql = " DELETE FROM GLTransactionCacheWithdraw WHERE     (TransactionID = " + _ID + ") ";
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
