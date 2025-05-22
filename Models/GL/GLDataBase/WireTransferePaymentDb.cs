using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;


namespace SharpVision.GL.GLDataBase
{
    public class WireTransferePaymentDb
    {
        #region Private Data
        protected int _WireTransfereID;
        protected int _PaymentID;
        

        #endregion

        #region Constractors
        public WireTransferePaymentDb()
        {

        }
        public WireTransferePaymentDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int WireTransfereID
        {
            set
            {
                _WireTransfereID = value;
            }
            get
            {
                return _WireTransfereID;
            }
        }
        public int PaymentID
        {
            set
            {
                _PaymentID = value;
            }
            get
            {
                return _PaymentID;
            }
        }
        public string AddStr
        {
            get
            {
                string strPaymentID = _PaymentID == 0 ? "@PaymentID" : _PaymentID.ToString();
                string strSql = " INSERT INTO GLWireTransferePayment " +
                           " (WireTransfereID, PaymentID, UsrIns, TimIns)" +
                           " VALUES     (" + _WireTransfereID + "," + strPaymentID + "," +
                           SysData.CurrentUser.ID + ",GetDate())";
                return strSql;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT GLBankWireTransferePayment.WireTransfereID as PaymentWireTransfere, PaymentID TransferePayment" +
                    ",WireTransfereTable.*  " +
                    " FROM GLBankWireTransferePayment inner join (" + WireTransfereDb.SearchStr + ") as WireTransfereTable on " +
                    " GLBankWireTransferePayment.WireTransfereID = WireTransfereTable.WireTransfereID  ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _WireTransfereID = int.Parse(objDR["WireTransfereID"].ToString());
            _PaymentID = int.Parse(objDR["PaymentID"].ToString());
       
        }
        #endregion

        #region Public Methods
        public void Add()
        {
          
          
            //string strSql = " INSERT INTO GLWireTransferePayment " +
            //                " (WireTransfereID, PaymentID, UsrIns, TimIns)" +
            //                " VALUES     (" + _WireTransfereID + "," + _PaymentID + "," +
            //                SysData.CurrentUser.ID + ",GetDate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }


        public void Delete()
        {
            string strSql = "delete from GLWireTransferePayment where PaymentID=" + _PaymentID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + "Where 1 =1";
            if (_WireTransfereID != 0)
                strSql = strSql + " and  WireTransfereID = " + _WireTransfereID + "";
            if (_PaymentID != 0)
                strSql = strSql + " and  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
