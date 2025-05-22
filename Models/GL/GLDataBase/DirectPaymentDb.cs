using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class DirectPaymentDb : PaymentDb
    {
        #region Private Data
        protected int _ReservationID;
        int _Type;
        // string _ReservationIDs;
        int _ResultCount;
        #region Private Data for search
        
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
        public DirectPaymentDb()
        {

        }
        public DirectPaymentDb(int intID)
        {
           


        }
        public DirectPaymentDb(DataRow objDR)
            : base(objDR)
        {

         

            if (objDR["PaymentType"].ToString() != "")
                _Type = int.Parse(objDR["PaymentType"].ToString());
            if (objDR.Table.Columns["PaymentTypeID"] != null && objDR["PaymentTypeID"].ToString() != "")
                _Type = int.Parse(objDR["PaymentTypeID"].ToString());
            _SubDesc = _Desc;
            
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
                string Returned = base.AddStr + " INSERT INTO GLDirectPayment" +
                                " ( PaymentID,PaymentType)" +
                                " VALUES     (" + (_ID == 0 ? "@PaymentID" : _ID.ToString()) + "," + _Type + ") ";
                return Returned;
            }
        }

        public string EditStr
        {
            get
            {

                double Date = _Date.ToOADate() - 2;
                string Returned = " UPDATE    GLDirectPayment " +
                                " SET   PaymentType= " + _Type + "" +
                                " WHERE    (PaymentID = " + _ID + ") ";
                return Returned;
            }
        }

        public override string DeleteStr
        {
            get
            {

                string Returned = base.DeleteStr;
                Returned += " DELETE FROM GLDirectPayment Where PaymentID = " + _ID + "" +
                  " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO GLDirectPayment ( PaymentID, PaymentType) " +
                               "SELECT     dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.GLDirectPayment.PaymentType " +
                               " FROM         dbo.GLPayment INNER JOIN " +
                               " dbo.GLDirectPayment ON dbo.GLPayment.PaymentID = dbo.GLDirectPayment.PaymentID " +
                               " where (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
                return Returned;
            }
        }

        public static string SearchStr
        {
            get
            {

               
                string Returned = " SELECT PaymentTable.*,PaymentTypeTable.* " +
                    " FROM  GLDirectPayment "+
                    " INNER JOIN (" + new PaymentDb().SearchStr + ") AS PaymentTable " +
                    " ON GLDirectPayment.PaymentID = PaymentTable.PaymentID " +
                    " left outer join (" + DirectPaymentTypeDB.SearchStr + ") as PaymentTypeTable  " +
                    " on GLDirectPayment.PaymentType = PaymentTypeTable.PaymentTypeID ";
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

   
        public  void Delete()
        {
            //base.Delete();
            string strSql = " DELETE FROM GLDirectPayment Where PaymentID = " + _ID + "" +
                  " and not exists (select PaymentID FROM GLPayment WHERE     (PaymentID = " + _ID +
                               ") and PaymentReverseID > 0)  " +
                               "  INSERT INTO GLDirectPayment ( PaymentID, PaymentType) " +
                               "SELECT     dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.GLDirectPayment.PaymentType "+
                               " FROM         dbo.GLPayment INNER JOIN "+
                               " dbo.GLDirectPayment ON dbo.GLPayment.PaymentID = dbo.GLDirectPayment.PaymentID " +
                               " where (dbo.GLPayment.PaymentID = " + _ID +
                               ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and PaymentID = " + _ID.ToString();
            if (_CellFamilyID != 0 || (_CellIDsStr != null && _CellIDsStr != ""))
            {
                
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
                strSql += " and PaymentTable.PaymentDate >=" + intStartDate +
                    " and PaymentTable.PaymentDate <" + intEnddate;

            }
          

            string strCount = "select count(*) from (" + strSql + ") as NativeTable ";
            _ResultCount = (int)SysData.SharpVisionBaseDb.ReturnScalar(strCount);
            strSql = "select top 1000 * from (" + strSql + ") as NativeTable ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "TempPayment");

        }
        #endregion
    }
}


