using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationPayBackDb:PaymentDb
    {
        #region Private Data
       
        protected int _ReservationID;
        #endregion
        #region Constructors
        public ReservationPayBackDb()
        {
            _Direction = false;
        }
        public ReservationPayBackDb(int intID)
        {
            _ID = intID ;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }

        public ReservationPayBackDb(DataRow objDr):base(objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }
        }
        string _ReservationIDs;

        public string ReservationIDs
        {
         
            set { _ReservationIDs = value; }
        }
        public override string AddStr
        {
            get
            {
                string Returned = base.AddStr + " INSERT INTO CRMReservationPayBack" +
                            "  (PaymentID,ReservationID,PaymentDesc)" +
                            " VALUES     (@PaymentID," + _ReservationID + ",'" + _SubDesc + "')";
                return Returned;
            }
        }
        #region Public Static Accessorice 
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT CRMReservationPayBack.ReservationID,CRMReservationPayBack.PaymentDesc as PayBackSubDesc,PaymentTable.* " +
                                  " FROM CRMReservationPayBack inner join (" + new PaymentDb().SearchStr +
                                  ") as PaymentTable on CRMReservationPayBack.PaymentID = PaymentTable.PaymentID "; 
                return Returned;
            }
        }
        #endregion

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _Direction = false;
            _ID = int.Parse(objDr["PaymentID"].ToString());
            _ReservationID = int.Parse(objDr["ReservationID"].ToString());
            _Value = double.Parse(objDr["PaymentValue"].ToString());
            _Date = DateTime.Parse(objDr["PaymentDate"].ToString());
            _Type = int.Parse(objDr["PaymentType"].ToString());
            if(objDr.Table.Columns["PayBackSubDesc"]!= null && objDr["PayBackSubDesc"].ToString()!= "")
            _Desc = objDr["PayBackSubDesc"].ToString();
        }
        #endregion
        #region Public Methods
        //public override void Add()
        //{
        //    base.Add();
        //    string strSql = " INSERT INTO CRMReservationPayBack"+
        //                    "  (PaymentID,ReservationID,PaymentDesc)" +
        //                    " VALUES     ("+   _ID +","  +_ReservationID+ ",'"+ _SubDesc +"')";
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        public override void Edit()
        {
            base.Edit();
            string strSql = " update CRMReservationPayBack" +
                               "  set PaymentDesc = '" + _SubDesc + "' " +
                               "  where PaymentID = " + _ID +" and ReservationID="  + _ReservationID ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            base.Delete();
            string strSql = " DELETE FROM CRMReservationPayBack Where PaymentID = "+_ID+""+
                  " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO CRMReservationPayBack (  PaymentID, ReservationID, PaymentType, PaymentDate, PaymentValue, PaymentDesc, UsrIns, TimIns) " +
                               "SELECT     dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.CRMReservationPayBack.ReservationID, dbo.CRMReservationPayBack.PaymentType, "+
                               " dbo.CRMReservationPayBack.PaymentDate, dbo.CRMReservationPayBack.PaymentValue, dbo.CRMReservationPayBack.PaymentDesc, " + SysData.CurrentUser.ID + " AS UsrIns1, GETDATE()  "+
                               " AS TimIns1 "+
                                " FROM    dbo.GLPayment INNER JOIN "+
                               " dbo.CRMReservationPayBack ON dbo.GLPayment.PaymentID = dbo.CRMReservationPayBack.PaymentID "+
                               " WHERE  (dbo.CRMReservationPayBack.ReservationID = "+ _ReservationID +")" +
                               " and  (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if(_ID != 0)
                strSql += " and  PaymentTable.PaymentID = "+_ID+"";
            if (_ReservationID != 0)
                strSql += " and CRMReservationPayBack.ReservationID=" + _ReservationID;
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql += " and CRMReservationPayBack.ReservationID in (" + _ReservationIDs + ") ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}

