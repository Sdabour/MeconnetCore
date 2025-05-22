using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionCheckTransfereDb : TransactionDb
    {
        #region Private Data
        protected int _SrcAccount;
        protected int _DestAccount;
        protected double _Check;
        #endregion

        #region Constructors
        public TransactionCheckTransfereDb()
        { 

        }
        public TransactionCheckTransfereDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _SrcAccount = int.Parse(objDR["TransactionSrcAcount"].ToString());
            _DestAccount = int.Parse(objDR["TransactionDestAccount"].ToString());
            _Check = double.Parse(objDR["TransactionCheck"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());

        }
        public TransactionCheckTransfereDb(DataRow objDR):base(objDR)
        {
            _SrcAccount = int.Parse(objDR["TransactionSrcAcount"].ToString());
            _DestAccount = int.Parse(objDR["TransactionDestAccount"].ToString());
            _Check = double.Parse(objDR["TransactionCheck"].ToString());
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
        public  string SearchStr
        {
            get
            {
                string Returned = " SELECT     TransactionID, TransactionSrcAcount, TransactionDestAccount, TransactionCheck , TranActionTable.*" +
                                  " FROM    GLTransactionCheckTransfere INNER JOIN (" + base.SearchStr + ") AS TranActionTable ON  GLTransactionCheckTransfere.TransActionID = TransActionTable.TransActionID ";
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
            string strSql = " INSERT INTO GLTransactionCheckTransfere" +
                           " (TransactionID, TransactionSrcAccount,TransactionDestAccount, TransactionCheck)" +
                           " VALUES     (" + _ID + "," + _SrcAccount + ","+_DestAccount+"," + _Check + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();

            string strSql = " UPDATE    GLTransactionCheckTransfere" +
                           " SET  TransactionSrcAccount =" + _SrcAccount + "" +
                           " ,TransactionDestAccount = "+_DestAccount+""+
                           " , TransactionCheck =" + _Check + " " +
                           " Where TransactionID =" + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            base.Delete();

            string strSql = " DELETE FROM GLTransactionCheckTransfere WHERE     (TransactionID = " + _ID + ") ";
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
