using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class MulctPaymentDb : PaymentDb
    {
        #region Private Data
        protected int _Reservation;
        string _ReservationIDs;

        #endregion
        #region Constructors
        public MulctPaymentDb()
        { 

        }
        public MulctPaymentDb(DataRow objDR) : base(objDR)
        {
            
            _Reservation = int.Parse(objDR["PaymentReservation"].ToString());
            if(objDR.Table.Columns["MulctPaymentSubDesc"] != null && objDR["MulctPaymentSubDesc"].ToString()!= "")
            _Desc = objDR["MulctPaymentSubDesc"].ToString();
        }
        #endregion
        #region Public Properties
       
        public int Reservation
        {
            set 
            {
                _Reservation = value;
            }
            get 
            { 
                return _Reservation; 
            }
        }

        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public override string AddStr
        {
            get
            {
                string Returned = base.AddStr + " INSERT INTO CRMReservationMulctPayment" +
                            " (PaymentID,PaymentReservation,PaymentDesc)" +
                            " VALUES     (@PaymentID," + _Reservation + ",'" + _SubDesc + "') ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  PaymentReservation,CRMReservationMulctPayment.PaymentDesc as MulctPaymentSubDesc , PaymentTable.*" +
                                  " FROM  CRMReservationMulctPayment INNER Join (" + new PaymentDb().SearchStr +
                                  ") AS PaymentTable ON CRMReservationMulctPayment.PaymentID = PaymentTable.PaymentID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        //public override void Add()
        //{
        //    base.Add();
        //    string strSql = " INSERT INTO CRMReservationMulctPayment"+
        //                    " (PaymentID,PaymentReservation,PaymentDesc)" +
        //                    " VALUES     ("+_ID+","+_Reservation+ ",'" + _SubDesc + "') ";
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}

        public override void Edit()
        {
            base.Edit();
            string strSql = " update CRMReservationMulctPayment" +
                           " set PaymentDesc ='" + _SubDesc + "'" +
                           " where PaymentID =" + _ID + " and PaymentReservation=" + _Reservation ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        

        }
        public override void Delete()
        {
            base.Delete();
            string strSql = " DELETE FROM CRMReservationMulctPayment Where PaymentReservation = " +
                _Reservation + " and PaymentID=" + _ID +
                " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO CRMReservationMulctPayment ( PaymentID, PaymentReservation, PaymentDesc, UsrIns, TimIns) " +
                               "SELECT dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.CRMReservationMulctPayment.PaymentReservation, dbo.CRMReservationMulctPayment.PaymentDesc, " +
                               " " + SysData.CurrentUser.ID + " AS UsrIns1, GETDATE() AS TimIns1 " +
                                " FROM         dbo.CRMReservationMulctPayment INNER JOIN " +
                                " dbo.GLPayment ON dbo.CRMReservationMulctPayment.PaymentID = dbo.GLPayment.PaymentID " +
                                " WHERE     (dbo.CRMReservationMulctPayment.PaymentReservation =" + _Reservation + ")" +
                               " and  (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1 = 1)";
            if (_Reservation != 0)
                strSql = strSql + " And PaymentReservation = " + _Reservation + "";
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " And PaymentReservation in  (" + _ReservationIDs  + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"MulctPaymentTable");
        }
        #endregion
    }
}
