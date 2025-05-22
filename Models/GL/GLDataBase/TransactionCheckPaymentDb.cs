using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class TransactionCheckPaymentDb : TransactionDb
    {
        #region Private data
        //CheckDb _CheckDb;
        protected int _CheckID;
        protected double _Value;
        #endregion

        #region Constractors
        public TransactionCheckPaymentDb()
        { 

        }
        public TransactionCheckPaymentDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
            _CheckID = int.Parse(objDR["CheckID"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());

        }
        public TransactionCheckPaymentDb(DataRow objDR)
            : base(objDR)
        {
            _CheckID = int.Parse(objDR["CheckID"].ToString());
            _Value = double.Parse(objDR["TransactionValue"].ToString());
        }
        #endregion

        #region Public Accessorice
        public int CheckID
        {
            set
            {
                _CheckID = value;
            }
            get
            {
                return _CheckID;
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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     TransactionID, TransactionValue, CheckID"+
                                  " FROM         GLTransactionCheckPayment ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {

            _ID = int.Parse(objDR["TransactionID"].ToString());
            _Type = int.Parse(objDR["TransactionType"].ToString());
            _Date = DateTime.Parse(objDR["TransactionDate"].ToString());
            _Desc = objDR["TransactionDesc"].ToString();
            _PostStatus = int.Parse(objDR["TransactionStatus"].ToString());


        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            base.Add();
            string strSql = " INSERT INTO GLTransactionCheckPayment"+
                            " (TransactionID, TransactionValue, CheckID)"+
                            " VALUES     ("+_ID+","+_Value+","+_CheckID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();
            string strSql = " UPDATE    GLTransactionCheckPayment"+
                            " SET    TransactionID ="+_ID+""+
                            " , TransactionValue ="+_Value+""+
                            " , CheckID = "+_CheckID+""+
                            " Where TransactionID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
    }
}
