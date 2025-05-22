using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UtilityPaymentDb : PaymentDb
    {
        #region Private Data
        protected int _UtilityID;
        #region Private Data For Search
        string _UtilityIDs;
         string _ReservationIDs;
        #endregion
        #endregion
        #region Constructors
        public UtilityPaymentDb()
        { 

        }
        public UtilityPaymentDb(DataRow objDR) : base(objDR)
        {
            _UtilityID = int.Parse(objDR["UtilityID"].ToString());
        }
        #endregion
        #region Public Properties
       
        public int UtilityID
        {
            set
            {
                _UtilityID = value;
            }
            get
            {
                return _UtilityID;
            }

        }
       
        public string UtilityIDs
        {
            set
            {
                _UtilityIDs = value;
            }
        }
        public  string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT    UtilityID,PaymentTable.* "+
                                  " FROM   CRMReservationUtilityPayment INNER Join (" + new PaymentDb().SearchStr + ") AS PaymentTable" +
                                  " ON CRMReservationUtilityPayment.PaymentID = PaymentTable.PaymentID";
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
            string strSql = " INSERT INTO CRMReservationUtilityPayment ( PaymentID,UtilityID)" +
                            " VALUES     (" + _ID + "," + _UtilityID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override void Edit()
        {
            base.Edit();
            string strSql = " UPDATE    CRMReservationUtilityPayment" +
                                "SET  PaymentID =" + _ID + "" +
                                ", UtilityID = " + _UtilityID + "" +
                                " where PaymentID = " + _ID +" and UtilityID =" + _UtilityID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {

        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1 = 1)";
            if (_UtilityID != 0)
                strSql = strSql + " and UtilityID = " + _UtilityID.ToString();
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " and UtilityID in (SELECT UtilityID  FROM   dbo.CRMReservationUtility where "+
                    " ReservationID in("+ _ReservationIDs +"))";
            if (_UtilityIDs != null && _UtilityIDs != "")
            {
                strSql = strSql + " and UtilityID in (" + _UtilityIDs + ") ";
            }
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"UtilityPaymentTable");
        }

       

        #endregion
    }
}
