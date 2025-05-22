using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class AdministrativeCostPaymentDb : PaymentDb
    {
        #region Private Data
        protected int _ReservationID;
        int _Type;
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
        public AdministrativeCostPaymentDb()
        {

        }
        public AdministrativeCostPaymentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            if (objDR.Table.Columns["CostType"]!= null && objDR["CostType"].ToString() != "")
                _Type = int.Parse(objDR["CostType"].ToString());
            if (objDR.Table.Columns["CostTypeID"] != null && objDR["CostTypeID"].ToString() != "")
                _Type = int.Parse(objDR["CostTypeID"].ToString());


        }
        public AdministrativeCostPaymentDb(DataRow objDR)
            : base(objDR)
        {

            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            
            if (objDR["CostType"].ToString() != "")
                _Type = int.Parse(objDR["CostType"].ToString());
            if (objDR.Table.Columns["CostTypeID"]!= null && objDR["CostTypeID"].ToString() != "")
                _Type = int.Parse(objDR["CostTypeID"].ToString());
            _SubDesc = _Desc;
            if (objDR.Table.Columns["CostPaymentSubDesc"]!= null && objDR["CostPaymentSubDesc"].ToString() != "")
            _Desc = objDR["CostPaymentSubDesc"].ToString();
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


        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
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
              
                double Date = _Date.ToOADate() - 2;
                string Returned = base.AddStr + " INSERT INTO CRMAdministrativeCostPayment" +
                                " ( ReservationID, PaymentID,CostType,PaymentDesc)" +
                                " VALUES     (" + _ReservationID + ",@PaymentID," + _Type + ",'" + _SubDesc + "') ";
                return Returned;
            }
        }

        public string EditStr
        {
            get
            {
                
                double Date = _Date.ToOADate() - 2;
                string Returned = " UPDATE    CRMAdministrativeCostPayment" +
                                " SET  ReservationID =" + _ReservationID + "" +
                                " , PaymentID =" + _ID + "" +
                                " , CostType= " + _Type + "" +
                                ",PaymentDesc='"+ _SubDesc +"'"+
                                " WHERE    (PaymentID = " + _ID + ") ";
                return Returned;
            }
        }

        public override string DeleteStr
        {
            get
            {

                string Returned = base.DeleteStr ;// " DELETE FROM CRMAdministrativeCostPayment  WHERE    ReservationID=" + _ReservationID + " and  (PaymentID = " + _ID + ") ";
                Returned += " DELETE FROM CRMAdministrativeCostPayment Where ReservationID = " +
                _ReservationID + " and PaymentID=" + _ID +
                " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO CRMAdministrativeCostPayment ( PaymentID, ReservationID, PaymentDesc, CostType, UsrIns, TimIns) " +
                               "SELECT  dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.CRMAdministrativeCostPayment.ReservationID, dbo.CRMAdministrativeCostPayment.PaymentDesc, " +
                               " dbo.CRMAdministrativeCostPayment.CostType, " + SysData.CurrentUser.ID + " AS UsrIns1, GETDATE() AS TimIns1 " +
                               " FROM   dbo.GLPayment INNER JOIN " +
                               " dbo.CRMAdministrativeCostPayment ON dbo.GLPayment.PaymentID = dbo.CRMAdministrativeCostPayment.PaymentID " +
                               " WHERE     (dbo.CRMAdministrativeCostPayment.ReservationID = " + _ReservationID + ")" +
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
                string Returned = " SELECT CostType,CRMAdministrativeCostPayment.PaymentDesc as CostPaymentSubDesc,ReservationTable.* ,PaymentTable.*,CostTypeTable.* " +
                    " FROM  CRMAdministrativeCostPayment inner join (" + objTemp.SearchStr + ") as ReservationTable " +
                    " on CRMAdministrativeCostPayment.ReservationID = ReservationTable.ReservationID INNER JOIN (" + new PaymentDb().SearchStr + ") AS PaymentTable " +
                    " ON CRMAdministrativeCostPayment.PaymentID = PaymentTable.PaymentID "+
                    " left outer join (" + AdministrativeCostTypeDb.SearchStr + ") as CostTypeTable  "+
                    " on CRMAdministrativeCostPayment.CostType = CostTypeTable.CostTypeID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
   
        public override void Edit()
        {

            base.Edit();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);

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
        public override void Delete()
        {
            
            //base.Delete();
            string strSql = " DELETE FROM CRMAdministrativeCostPayment Where ReservationID = " +
                _ReservationID + " and PaymentID=" + _ID +
                " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO CRMAdministrativeCostPayment ( PaymentID, ReservationID, PaymentDesc, CostType, UsrIns, TimIns) " +
                               "SELECT  dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.CRMAdministrativeCostPayment.ReservationID, dbo.CRMAdministrativeCostPayment.PaymentDesc, " +
                               " dbo.CRMAdministrativeCostPayment.CostType, " + SysData.CurrentUser.ID + " AS UsrIns1, GETDATE() AS TimIns1 " +
                               " FROM   dbo.GLPayment INNER JOIN " +
                               " dbo.CRMAdministrativeCostPayment ON dbo.GLPayment.PaymentID = dbo.CRMAdministrativeCostPayment.PaymentID " +
                               " WHERE     (dbo.CRMAdministrativeCostPayment.ReservationID = " + _ReservationID + ")" +
                               " and  (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and PaymentID = " + _ID.ToString();
            if (_ReservationID != 0)
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
                strSql += " and CRMAdministrativeCostPayment.PaymentDate >=" + intStartDate +
                    " and CRMAdministrativeCostPayment.PaymentDate <" + intEnddate;

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
