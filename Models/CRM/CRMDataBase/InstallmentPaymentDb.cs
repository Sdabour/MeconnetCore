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
    public class InstallmentPaymentDb : PaymentDb
    {
        #region Private Data

        protected int _InstallmentID;
        int _ResultCount;
        #region Private Data For Search
        string _InstallmentIDs;
        string _ReservationIDs;
        bool _OnlyNonTransaction;
        
        string _CellIDsStr;
        int _CellFamilyID;
        bool _PaymentDateStatus;
        DateTime _FromPaymentDate;
        DateTime _ToPaymentDate;
        int _InstallmentTypeID;
        bool _OnlyAcounts;
        DateTime _TimIns;
        #endregion
        #region Private Data for Transaction
        DataTable _TransactionTable;
        DataTable _TransactionElementTable;
        int _TopSelected;
        #endregion
        #endregion
        #region Constructors
        public InstallmentPaymentDb()
        { 

        }
        public InstallmentPaymentDb(DataRow objDR) : base(objDR)
        {
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            _TimIns = DateTime.Parse(objDR["PaymentTimIns"].ToString());
        }
        #endregion
        #region Public Properties
       
        public int InstallmentID
        {
            set
            {
                _InstallmentID = value;
            }
            get
            {
                return _InstallmentID;
            }

        }
        public string InstallmentIDs
        {
            set
            {
                _InstallmentIDs = value;
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
        public int InstallmentTypeID
        {
            set
            {
                _InstallmentTypeID = value;
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
        public int TopSelected
        {
            set
            {
                _TopSelected = value;
            }
        }
        public DateTime TimIns
        {
            get
            {
                return _TimIns;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        double _DiscountValue;

        public double DiscountValue
        {
            get { return _DiscountValue; }
            set { _DiscountValue = value; }
        }
        int _DiscountID;

        public int DiscountID
        {
            get { return _DiscountID; }
            set { _DiscountID = value; }
        }
        int _DiscountType;

        public int DiscountType
        {
            get { return _DiscountType; }
            set { _DiscountType = value; }
        }
        string _DiscountDesc;

        public string DiscountDesc
        {
            get { return _DiscountDesc; }
            set { _DiscountDesc = value; }
        }
        DateTime _DiscountDate;

        public DateTime DiscountDate
        {
            get { return _DiscountDate; }
            set { _DiscountDate = value; }
        }
        int _UserID;
        public int UserID
        {
            set => _UserID=value;
        }
        /// <summary>
        /// presents strng to add new discount and change paymentValue as payment related to check
        /// </summary>
        public string PaymentDiscountStr
        {
            get
            {
                double dblDiscountDate = SysUtility.Approximate(_DiscountDate.ToOADate() - 2, 1, ApproximateType.Down);
                string Returned = " begin transaction  Trans1;";
                Returned += " declare @ID int ;"+
                    " set @ID = (SELECT  COUNT(dbo.CRMInstallmentPayment.PaymentID) AS PaymentCount "+
                      " FROM            dbo.CRMInstallmentPayment INNER JOIN "+
                       " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID "+
                        " WHERE        (dbo.GLPayment.PaymentValue >= "+ _DiscountValue +") AND (dbo.CRMInstallmentPayment.PaymentID = "+ _ID +")) ";
                Returned += " if @ID = 0  goto rolLine; "+
                    " update dbo.GLPayment set PaymentValue = PaymentValue - "+ _DiscountValue + " where PaymentID = "+_ID ;

                Returned += " INSERT INTO CRMReservationInstallmentDiscount" +
                            " ( InstallmentID, DiscountValue, DiscountReason, DiscountDate,TypeID,UsrIns, TimIns)" +

                            " VALUES     (" + _InstallmentID + "," + _DiscountValue + ",'" + _DiscountDesc +
                            "'," + dblDiscountDate + "," + _DiscountType +
                            "," + _UserID + ",GetDate()) ";

                Returned += " commitline: commit transaction Trans1;select  @@IDENTITY as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string InstallmentPaymentDiscountStr
        {
            get
            {
                string strInstallmentPayment = " SELECT   dbo.CRMInstallmentPayment.InstallmentID, SUM(dbo.GLPayment.PaymentValue) AS TotalPayment " +
                  " FROM            dbo.CRMInstallmentPayment INNER JOIN " +
                  " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID " +
                 " where InstallmentID = " + _InstallmentID + 
                 " and (ISNULL(dbo.GLPayment.PaymentSourceID, 0) = 0) AND (ISNULL(dbo.GLPayment.PaymentReverseID, 0) = 0)" +
                  " GROUP BY dbo.CRMInstallmentPayment.InstallmentID ";
                string strInstallmentDiscount = "SELECT   InstallmentID, SUM(DiscountValue) AS TotalDiscount " +
                  " FROM            dbo.CRMReservationInstallmentDiscount " +
                   " WHERE    InstallmentID = " + _InstallmentID +
                   " and    (DiscountDirection = 1) " +
                    " and  (ISNULL(DiscountSourceID, 0) = 0) AND (ISNULL(DiscountReverseID, 0) = 0)" +
                   " GROUP BY InstallmentID";
                string strInstallment = " SELECT count(dbo.CRMReservationInstallment.InstallmentID) as InstallmentCount     " +
                      " FROM            dbo.CRMReservationInstallment " +
                      " left outer join (" + strInstallmentPayment + ") as PaymentTable " +
                      "  on  dbo.CRMReservationInstallment.InstallmentID = PaymentTable.InstallmentID " +
                      " left outer join (" + strInstallmentDiscount + ") as DiscountTable " +
                      "  on  dbo.CRMReservationInstallment.InstallmentID = DiscountTable.InstallmentID  " +
                      "  where   dbo.CRMReservationInstallment.InstallmentID =" + _InstallmentID +
                " and InstallmentValue < IsNull(TotalPayment,0) + IsNull(TotalDiscount,0)   ";
                return strInstallment;
            }
        }

        public override string AddStr
        {
            get
            {

                string strInstallment = InstallmentPaymentDiscountStr;
                string Returned =  " begin transaction  Trans1;" + base.BaseAddStr;
                Returned+= " INSERT INTO CRMInstallmentPayment ( InstallmentID, PaymentID,UsrIns,TimIns)"+
                    " VALUES     ("+_InstallmentID+",@PaymentID,"+
                             SysData.CurrentUser.ID +",GetDate())"+
                             " declare @InstallmentCount int  "+
                             " set @InstallmentCount = ("+ strInstallment +"); "+
                             " if @InstallmentCount >0  goto rolLine ; ";

                Returned += " commitline: commit transaction Trans1;select  @PaymentID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;

            }
        }
        public override string EditStr
        {
            get
            {

                string strInstallment = InstallmentPaymentDiscountStr;
                string Returned = " begin transaction  Trans1;" + base.EditStr ;
                Returned += " declare @InstallmentCount int  " +
                             " set @InstallmentCount = (" + strInstallment + "); " +
                             " if @InstallmentCount >0  goto rolLine ; ";

                Returned += " commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;

            }
        }
        public override string DeleteStr
        {
            get
            {
                string Returned = " begin transaction  Trans1;";
                Returned += base.DeleteStr;
                Returned += " delete from    CRMInstallmentPayment" +
                              " where PaymentID = " + _ID + " and InstallmentID =" + _InstallmentID +
                              " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                              ") and PaymentReverseID > 0)  " +
                              "  INSERT INTO CRMInstallmentPayment ( InstallmentID, PaymentID,UsrIns,TimIns) " +
                              " SELECT  dbo.CRMInstallmentPayment.InstallmentID,dbo.GLPayment.PaymentReverseID AS PaymentID1, " + SysData.CurrentUser.ID.ToString() + "  as UsrIns1,  " +
                              " GetDate() as TimIns1 " +
                              " FROM         dbo.CRMInstallmentPayment INNER JOIN " +
                              " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID " +
                              " WHERE   dbo.CRMInstallmentPayment.InstallmentID = " + _InstallmentID +
                              " and  (dbo.GLPayment.PaymentID = " + _ID +
                              ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
                Returned += " commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                ReservationInstallmentDb objTemp = new ReservationInstallmentDb();

                string Returned = " SELECT    " +
                    "CRMInstallmentPayment.TimIns as PaymentTimIns,InstallmentTable.*,PaymentTable.* " +
                    " FROM   CRMInstallmentPayment  inner join (" + objTemp.SearchStr + ") InstallmentTable " +
                    " on InstallmentTable.InstallmentID = CRMInstallmentPayment.InstallmentID  "+
                    " INNER JOIN (" + new PaymentDb().SearchStr + ") AS PaymentTable ON " +
                    " CRMInstallmentPayment.PaymentID = PaymentTable.PaymentID ";
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
        //    string strSql = " INSERT INTO CRMInstallmentPayment ( InstallmentID, PaymentID,UsrIns,TimIns)"+
        //                    " VALUES     ("+_InstallmentID+","+_ID+","+
        //                     SysData.CurrentUser.ID +",GetDate())";

        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}

        //public override void Edit()
        //{
        //    base.Edit();
         
        //}
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
                if (intTransID == 0)
                {
                    objTrans.Rollback();
                    return;
                }
                if (intTransID != 0)
                {
                    int intIndex = 0;
                    foreach (DataRow objDr in _TransactionElementTable.Rows)
                    {
                        objElementDb = new TransactionElementDb(objDr);
                        objElementDb.TRansaction = intTransID;
                        arrStr[intIndex] = objElementDb.AddStr;
                        intIndex++;

                    }
                    arrStr[intIndex] = " UPDATE    GLPayment " +
                                    "SET  GLTransaction =" + intTransID + "" +
                                    " where PaymentID = " + _ID + " ";
                    if (SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr, objCon, objTrans))
                    {
                        objTrans.Commit();
                        objCon.Close();
                        return;
                    }
                }
            }
            catch
            { }
            objTrans.Rollback();

              
        }
        //public override void Delete()
        //{
        //    base.Delete();
        //    string strSql = " delete from    CRMInstallmentPayment" +
        //                       " where PaymentID = " + _ID + " and InstallmentID =" + _InstallmentID+
        //                       " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID + 
        //                       ") and PaymentReverseID > 0)  "+
        //                       "  INSERT INTO CRMInstallmentPayment ( InstallmentID, PaymentID,UsrIns,TimIns) "+
        //                       " SELECT  dbo.CRMInstallmentPayment.InstallmentID,dbo.GLPayment.PaymentReverseID AS PaymentID1, " + SysData.CurrentUser.ID.ToString() + "  as UsrIns1,  " +
        //                       " GetDate() as TimIns1 "+
        //                       " FROM         dbo.CRMInstallmentPayment INNER JOIN "+
        //                       " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID "+
        //                       " WHERE   dbo.CRMInstallmentPayment.InstallmentID = "+ _InstallmentID +
        //                       " and  (dbo.GLPayment.PaymentID = " + _ID +
        //                       ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1 = 1)";
            if (_InstallmentID != 0)
                strSql = strSql + " and InstallmentTable.InstallmentID = " + _InstallmentID.ToString();
            if (_InstallmentIDs != null && _InstallmentIDs != "")
            {
                strSql = strSql + " and InstallmentTable.InstallmentID in (" + _InstallmentIDs + ") ";
            }
            if (_ReservationIDs != null && _ReservationIDs != "")
            {
                strSql = strSql + " and InstallmentTable.ReservationID in (" + _ReservationIDs + ") "; 
            }
            if (_CellFamilyID != 0 || (_CellIDsStr != null && _CellIDsStr != ""))
            {
                string strCellSql = "SELECT     dbo.CRMReservationUnit.ReservationID "+
                  " FROM         dbo.CRMReservationUnit INNER JOIN "+
                    " dbo.CRMUnitCell ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                   " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID ";
                if (_CellFamilyID != 0)
                    strCellSql += " where RPCell.CellFamilyID =" + _CellFamilyID;
                else
                    strCellSql+= " where RPCell.CellID in ("+ _CellIDsStr +")";
                strSql += " and InstallmentTable.ReservationID in(" + strCellSql + ")";
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
                strSql += " and GLPayment.PaymentDate >=" + intStartDate +
                    " and GLPayment.PaymentDate <" + intEnddate;

            }
            if (_OnlyAcounts)
                strSql += " and InstallmentTable.ReservationGLLeafAccount <>0 ";
            if (_OnlyNonTransaction)
                strSql += " and CRMInstallmentPayment.GLTransaction =0 ";
            if (_InstallmentTypeID != 0)
                strSql += " and InstallmentTable.InstallmentType = " + _InstallmentTypeID;
            string strCount = "select count(*) from ("+ strSql +") as NativeTable ";
            if((_ReservationIDs == null||_ReservationIDs == "" ) && _TopSelected != 0)
            _ResultCount = (int)SysData.SharpVisionBaseDb.ReturnScalar(strCount);
            string strTop = _TopSelected ==0? "" : " Top " + _TopSelected.ToString();                                                                                                        
            strSql = "select "+ strTop +" * from (" + strSql + ") as NativeTable ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"InstallmentPayment");
        }


        public void ApplyDiscount()
        {
            string strSql = PaymentDiscountStr;
            object objDiscountID = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objDiscountID != null)
                 int.TryParse(objDiscountID.ToString(), out _DiscountID);
 
        }
        #endregion
    }
}
