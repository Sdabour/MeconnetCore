

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionCacheTransfereDb : TransactionDb
    {
        #region Private Data
        protected int _SrcAccount;
        protected int _DestAccount;
        protected double _Value;
        #endregion

        #region Constructors
        public TransactionCacheTransfereDb()
        { 

        }
        public TransactionCacheTransfereDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _SrcAccount = int.Parse(objDR["TransactionSrcAcount"].ToString());
            _DestAccount = int.Parse(objDR["TransactionDestAccount"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());

        }
        public TransactionCacheTransfereDb(DataRow objDR):base(objDR)
        {
            _SrcAccount = int.Parse(objDR["TransactionSrcAcount"].ToString());
            _DestAccount = int.Parse(objDR["TransactionDestAccount"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());
        }
        #endregion

        #region Public Properties
        public int SrcAccount
        {
            set
            {
                _SrcAccount = value;
            }
            get
            {
                return _SrcAccount;
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
        public int DestAccount
        {
            set
            {
                _DestAccount = value;
            }
            get
            {
                return _DestAccount;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " SELECT     TransactionID, TransactionSrcAcount, TransactionDestAccount, TransactionValue , TranActionTable.*" +
                                  " FROM    GLTransactionCacheTransfere INNER JOIN (" + base.SearchStr + ") AS TranActionTable ON  GLTransactionCacheTransfere.TransActionID = TransActionTable.TransActionID ";
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
            string strSql = " INSERT INTO GLTransactionCacheTransfere" +
                           " (TransactionID, TransactionSrcAccount,TransactionDestAccount, TransactionValue)" +
                           " VALUES     (" + _ID + "," + _SrcAccount + ","+_DestAccount+"," + _Value + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();

            string strSql = " UPDATE    GLTransactionCacheTransfere" +
                           " SET  TransactionSrcAccount =" + _SrcAccount + "" +
                           " ,TransactionDestAccount = "+_DestAccount+""+
                           " , TransactionValue =" + _Value + " " +
                           " Where TransactionID =" + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            base.Delete();

            string strSql = " DELETE FROM GLTransactionCacheTransfere WHERE     (TransactionID = " + _ID + ") ";
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
