using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
   public  class TempReservationPaymentDb : PaymentDb
    {
        #region Private Data
       protected int _ReservationID;
       bool _Scheduled;
      // string _ReservationIDs;
       int _ResultCount;
       #region Private Data for search
       string _ReservationIDs;
       bool _OnlyNonTransaction;

       string _CellIDsStr;
       int _CellFamilyID;
       bool _PaymentDateStatus;
       DateTime _FromPaymentDate;
       DateTime _ToPaymentDate;
      
       bool _OnlyAcounts;
       #endregion
       #region Private Data for Transaction
       DataTable _TransactionTable;
       DataTable _TransactionElementTable;
       #endregion
        #endregion

        #region Constructors
        public TempReservationPaymentDb()
        { 

        }
        public TempReservationPaymentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
           
        }
        public TempReservationPaymentDb(DataRow objDR) : base(objDR)
        {
            
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            if (objDR.Table.Columns["TempPaymentSubDesc"] != null &&
                objDR["TempPaymentSubDesc"].ToString() != "")
            {
                //_Desc = objDR["TempPaymentSubDesc"].ToString();
                _SubDesc = objDR["TempPaymentSubDesc"].ToString();
            }
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

       
       public bool Scheduled
       {
           set
           {
               _Scheduled = value;
           }
           get
           {
               return _Scheduled;
           }

       }

       public string ReservationIDs
       {
           set
           {
               _ReservationIDs = value;
           }
       }
       public bool OnlyNonTransaction
       {
           set
           {
               _OnlyNonTransaction = value;
           }
       }
       public string CellIDsStr
       {
           set
           {
               _CellIDsStr = value;
           }
       }
       public int CellFamilyID
       {
           set
           {
               _CellFamilyID = value;
           }
       }
       public bool PaymentDateStatus
       {
           set
           {
               _PaymentDateStatus = value;
           }
       }
       public DateTime FromPaymentDate
       {
           set
           {
               _FromPaymentDate = value;
           }
       }
       public DateTime ToPaymentDate
       {
           set
           {
               _ToPaymentDate = value;
           }
       }
       public bool OnlyAccounts
       {
           set
           {
               _OnlyAcounts = value;
           }
       }
    
       public DataTable TransactionTable
       {
           set
           {
               _TransactionTable = value;
           }
       }
       public DataTable TransactionElementTable
       {
           set
           {
               _TransactionElementTable = value;
           }
       }
       public int ResultCount
       {
           get
           {
               return _ResultCount;
           }
       }

       public override string AddStr
       {
           get
           {
               int intScheduled = _Scheduled ? 1 : 0;
               double Date = _Date.ToOADate() - 2;
               string Returned = base.AddStr +  " INSERT INTO CRMTempReservationPayment" +
                               " ( ReservationID, PaymentID,Scheduled,PaymentDesc )" +
                               " VALUES     (" + _ReservationID + ",@PaymentID," + intScheduled + ",'" + _SubDesc + "') ";
               return Returned;
           }
       }

       public string EditStr
       {
           get
           {
               int intScheduled = _Scheduled ? 1 : 0;
               double Date = _Date.ToOADate() - 2;
               string Returned = " UPDATE    CRMTempReservationPayment" +
                               " SET  ReservationID =" + _ReservationID + "" +
                               " , PaymentID =" + _ID + "" +
                               " , Scheduled = " + intScheduled + "" +
                               ",PaymentDesc='"+ _SubDesc +"'"+
                               " WHERE     (PaymentID = " + _ID + ") ";
               return Returned;
           }
       }

       public override string DeleteStr
       {
           get
           {

               string Returned = base.DeleteStr + " DELETE FROM CRMTempReservationPayment  WHERE    ReservationID=" + _ReservationID +
                   " and  (PaymentID = " + _ID + ") "+
                    " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO CRMTempReservationPayment (PaymentID, ReservationID, PaymentDesc, Scheduled, UsrIns, TimIns) " +
                               "SELECT  dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.CRMTempReservationPayment.ReservationID, dbo.CRMTempReservationPayment.PaymentDesc, "+
                               " dbo.CRMTempReservationPayment.Scheduled, "+ SysData.CurrentUser.ID.ToString() +" AS UsrIns1, GETDATE() AS TimIns1 "+
                               " FROM    dbo.GLPayment INNER JOIN "+
                               " dbo.CRMTempReservationPayment ON dbo.GLPayment.PaymentID = dbo.CRMTempReservationPayment.PaymentID "+
                               " WHERE     (dbo.CRMTempReservationPayment.ReservationID = "+_ReservationID +")" +
                               " and  (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) "; 

               return Returned;
           }
       }

        public static string SearchStr
        {
            get
            {

                ReservationDb objTemp = new ReservationDb();
                string Returned = " SELECT Scheduled,CRMTempReservationPayment.PaymentDesc as TempPaymentSubDesc,ReservationTable.* ,PaymentTable.*" +
                    " FROM  CRMTempReservationPayment inner join (" + objTemp.SearchStr + ") as ReservationTable " +
                    " on CRMTempReservationPayment.ReservationID = ReservationTable.ReservationID INNER JOIN (" + new PaymentDb().SearchStr + ") AS PaymentTable " +
                    " ON CRMTempReservationPayment.PaymentID = PaymentTable.PaymentID ";
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
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);

        //}
        public override void Edit()
        {

            base.Edit();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);

        }
        public void Schedul()
       {
           int intSchedul = _Scheduled ? 1 : 0;
           string strSql = " UPDATE    CRMTempReservationPayment" +
                           " SET Scheduled =" + _Scheduled + "" +
                           " WHERE     (ReservationID = " + _ReservationID + ") AND (PaymentID = "+_ID+") ";
           SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

       }
        public void CreateTransaction()
       {
           if (_TransactionTable == null || _TransactionElementTable == null ||
               _TransactionTable.Rows.Count == 0 || _TransactionElementTable.Rows.Count == 0)
               return;
           TransactionDb objTransDb = new TransactionDb(_TransactionTable.Rows[0]);
           int intLen = _TransactionElementTable.Rows.Count + 1;
           string[] arrStr = new string[intLen];
           SqlConnection objCon = SysData.SharpVisionBaseDb.Connection;
           SqlTransaction objTrans = objCon.BeginTransaction();
           try
           {
               string strSql = objTransDb.AddStr;
               TransactionElementDb objElementDb;
               int intTransID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql, objCon, objTrans);
               if (intTransID != 0)
               {
                   int intIndex = 0;
                   foreach (DataRow objDr in _TransactionTable.Rows)
                   {
                       objElementDb = new TransactionElementDb(objDr);
                       arrStr[intIndex] = objElementDb.AddStr;
                       intIndex++;

                   }
                   arrStr[intIndex] = " UPDATE    GLPayment " +
                                   "SET  GLTransaction =" + objTransDb.ID + "" +
                                   " where PaymentID = " + _ID + " ";
                   SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr, objCon, objTrans);
                   objTrans.Commit();
                   objCon.Close();
                   return;
               }
           }
           catch
           { }
           objTrans.Rollback();


       }
       public void Delete()
       {
           base.Delete();
           SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
       }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and PaymentID = " + _ID.ToString();
            if(_ReservationID != 0)
                strSql = strSql + " and ReservationTable.ReservationID = " + _ReservationID.ToString();
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " and ReservationTable.ReservationID in (" + _ReservationIDs + ") ";
            if (_CellFamilyID != 0 || (_CellIDsStr != null && _CellIDsStr != ""))
            {
                string strCellSql = "SELECT     dbo.CRMReservationUnit.ReservationID " +
                  " FROM         dbo.CRMReservationUnit INNER JOIN " +
                    " dbo.CRMUnitCell ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                   " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID ";
                if (_CellFamilyID != 0)
                    strCellSql += " where RPCell.CellFamilyID =" + _CellFamilyID;
                else
                    strCellSql += " where RPCell.CellID in (" + _CellIDsStr + ")";
                strSql += " and ReservationTable.ReservationID in(" + strCellSql + ")";
            }

            if (_PaymentDateStatus)
            {
                int intStartDate, intEnddate;
                double dblTempDate = _FromPaymentDate.ToOADate() - 2;
                intStartDate = (int)dblTempDate;
                if (intStartDate > dblTempDate)
                    intStartDate -= 1;
                dblTempDate = _ToPaymentDate.ToOADate() - 2;
                intEnddate = (int)dblTempDate;
                if (intEnddate <= dblTempDate)
                    intEnddate += 1;
                strSql += " and CRMTempReservationPayment.PaymentDate >=" + intStartDate +
                    " and CRMTempReservationPayment.PaymentDate <" + intEnddate;

            }
            if (_OnlyAcounts)
                strSql += " and ReservationTable.ReservationGLAccount <>0 ";
       
            string strCount = "select count(*) from (" + strSql + ") as NativeTable ";
            _ResultCount = (int)SysData.SharpVisionBaseDb.ReturnScalar(strCount);
            strSql = "select top 1000 * from (" + strSql + ") as NativeTable ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "TempPayment");

        }
        #endregion
    }
}
