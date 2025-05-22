using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class PaymentDb
    {

        #region Private Data

        protected int _ID;
        protected double _Value;
        protected DateTime _Date;
        protected int _Currency;
        protected double _CurrencyValue;
        protected int _Type;
        protected string _Desc;
        protected string _SubDesc;
        protected bool _Direction = true;
        protected int _GLTransaction;
        protected int _CheckID;
        protected int _WireTransfere;
        protected bool _IsCollected;
        protected DateTime _CollectingDate;
        protected int _CollectingEmployeeID;
        protected string _CollectingEmployeeName;
        protected string _CollectingEmployeeCode;
        protected int _CollectingBranchID;
        protected string _CollectingBranchName;
        protected int _CollectingCofferID;
        protected string _CollectingCofferCode;
        protected string _CollectingCofferName;
        protected double _CheckPreviousTotalPayment;
        protected bool _EditSucceeded;
        protected string _CheckIDs;
        protected int _EmployeeID;
        protected string _EmployeeName;
        protected string _EmployeeCode;
        protected int _BranchID;
        protected bool _HasReceipt;
        protected string _BranchName;
        protected int _CofferID;
        protected string _CofferName;
        protected string _CofferCode;
        protected int _MaxReceiptID;
        protected int _MaxReceiptNo;
        protected int _PaymentSourceID;
        protected int _PaymentReverseID;
        protected int _PaymentCollectingID;
        protected bool _IsDateRange;
        protected bool _IncludeNonCanceledPayment;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected string _ChildCondition = "";
        DataTable _TransactionTable;
        DataTable _TRansactionElementTable;
        DataTable _PaymentTransactionTable;
        #endregion

        static int _UMSChangePaymentDate = 1203;
        static bool _UMSChangePaymentDateAuthorisedSet = false;
        static bool _UMSChangePaymentDateAuthorised;
        public static bool UMSChangePaymentDateAuthorised
        {
            get
            {
                if (!_UMSChangePaymentDateAuthorisedSet)
                {
                    _UMSChangePaymentDateAuthorisedSet = true;
                    _UMSChangePaymentDateAuthorised = SysData.SysID != 6 ||
                        SysData.CurrentUser.UserFunctionInstantCol.GetIndex(_UMSChangePaymentDate) != -1;
                }
                return _UMSChangePaymentDateAuthorised;
            }
        }
        int _VisitID;
        public int VisitID
        {
            set => _VisitID = value;
            get => _VisitID;
        }
        #region Constructors

        public PaymentDb()
        {

        }
        public PaymentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
        }

        public PaymentDb(DataRow objDR)
        {
            SetData(objDR);

        }

        #endregion

        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
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
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
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
        public int Currency
        {
            set
            {
                _Currency = value;
            }
            get
            {
                return _Currency;
            }
        }
        public bool IsCollected
        {
            set
            {
                _IsCollected = value;
            }
            get
            {
                return _IsCollected;
            }
        }
        public DateTime CollectingDate
        {
            set
            {
                _CollectingDate = value;
            }
            get
            {
                return _CollectingDate;
            }
        }
        public int CollectingEmployeeID
        {
            set
            {
                _CollectingEmployeeID = value;
            }
            get
            {
                return _CollectingEmployeeID;
            }
        }
        public string CollectingEmployeeName
        {
            get
            {
                return _CollectingEmployeeName;
            }
        }
        public string CollectingEmployeeCode
        {
            get
            {
                return _CollectingEmployeeCode;
            }
        }
        public int CollectingBranchID
        {
            set
            {
                _CollectingBranchID = value;
            }
            get
            {
                return _CollectingBranchID;
            }
        }
        public string CollectingBranchName
        {
            get
            {
                return _CollectingBranchName;
            }
        }
        public int CollectingCofferID
        {
            set
            {
                _CollectingCofferID = value;
            }
            get
            {
                return _CollectingCofferID;
            }
        }
        public string CollectingCofferCode
        {
            get
            {
                return _CollectingCofferCode;
            }
        }
        public string CollectingCofferName
        {
            get
            {
                return _CollectingCofferName;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _CurrencyValue = Value;
            }
            get
            {
                return _CurrencyValue;
            }
        }
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
        public int WireTransafere
        {
            set
            {
                _WireTransfere = value;
            }
            get
            {
                return _WireTransfere;
            }
        }
        public double CheckPreviousTotalPayment
        {
            set
            {
                _CheckPreviousTotalPayment = value;
            }
            get
            {
                return _CheckPreviousTotalPayment;
            }
        }
        public int GLTransaction
        {
            set
            {
                _GLTransaction = value;
            }
            get
            {
                return _GLTransaction;
            }
        }
        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get
            {
                return _EmployeeID;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
        }
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public int CofferID
        {
            set
            {
                _CofferID = value;
            }
            get
            {
                return _CofferID;
            }
        }
        public string SubDesc
        {
            set
            {
                _SubDesc = value;
            }
            get
            {
                return _SubDesc;
            }
        }
        //public bool IsDateRange
        //{
        //    set
        //    {
        //        _IsDateRange = value;
        //    }
        //}
        //public DateTime StartDate
        //{
        //    set
        //    {
        //        _StartDate = value;
        //    }
        //}
        //public DateTime EndDate
        //{
        //    set
        //    {
        //        _EndDate = value;
        //    }
        //}
        int _OldPaymentID;

        public int OldPaymentID
        {
            get { return _OldPaymentID; }
            set { _OldPaymentID = value; }
        }
        double _OldPaymentValue;

        public double OldPaymentValue
        {
            get { return _OldPaymentValue; }
            set { _OldPaymentValue = value; }
        }
        public bool HasReceipt
        {
            get
            {
                return _HasReceipt;
            }
        }
        public string BranchName
        {
            get
            {
                return _BranchName;
            }
        }
        public string CofferName
        {
            get
            {
                return _CofferName;
            }
        }
        public string CofferCode
        {
            get
            {
                return _CofferCode;
            }
        }
        public int MaxReceiptID
        {
            get
            {
                return _MaxReceiptID;
            }
        }
        public int MaxReceiptNo
        {
            get
            {
                return _MaxReceiptNo;
            }
        }
        public string CheckIDs
        {
            set
            {
                _CheckIDs = value;
            }
        }
        string _CheckIDTable;

        public string CheckIDTable
        {
            get { return _CheckIDTable; }
            set { _CheckIDTable = value; }
        }
        public DataTable TransactionTable
        {
            set
            {
                _TransactionTable = value;
            }
        }
        public DataTable TRansactionElementTable
        {
            set
            {
                _TRansactionElementTable = value;
            }
        }
        public DataTable PaymentTransactionTable
        {
            set
            {
                _PaymentTransactionTable = value;
            }
        }
        public bool IncludeNonCanceledPayment
        {
            set
            {
                _IncludeNonCanceledPayment = value;
            }
        }
        public int PaymentSourceID
        {
            get
            {
                return _PaymentSourceID;
            }
        }
        public int PaymentReverseID
        {
            get
            {
                return _PaymentReverseID;
            }
        }
        public int PaymentCollectingID
        {
            get
            {
                return _PaymentCollectingID;
            }
        }
        public string BaseAddStr
        {
            get
            {
                _Currency = 1;
                _CurrencyValue = 1;

                double dblDate = _Date.ToOADate() - 2;
                string strDate = dblDate.ToString();

                if (!UMSChangePaymentDateAuthorised)
                {
                    strDate = "GetDate()";

                }
                string strCollecting1 = UMSChangePaymentDateAuthorised ? (_CollectingDate.ToOADate() - 2).ToString() : "GetDate()";
                string strCollectingDate = _IsCollected ? strCollecting1 : "null";
                int intIsCollected = _IsCollected ? 1 : 0;
                int intDirection = _Direction ? 1 : 0;

                string strSql = " INSERT INTO GLPayment" +
                               " ( PaymentValue, PaymentDate,PaymentCurrency,PaymentCurrencyValue, PaymentType, PaymentDesc" +
                               ",PaymentDirection,PaymentEmployee,PaymentBranch,PaymentCoffer,UsrIns,TimIns)" +
                               " VALUES     (" + _Value + "," + strDate + "," + _Currency + "," +
                               _CurrencyValue + "," + _Type + ",'" + _Desc + "'," + intDirection + "," + _EmployeeID + "," + _BranchID +
                              "," + _CofferID + "," + SysData.CurrentUser.ID + ",GetDate()) ";
                strSql += " declare @PaymentID  int " +
                    " set @PaymentID = (select @@IDENTITY as NewID) ";
                if (_VisitID != 0)
                {
                    strSql += " insert into CRMVisitPayment ( VisitID, PaymentID) values (" + _VisitID + ",@PaymentID) ";
                }
                CheckPaymentDb objDb = new CheckPaymentDb();
                //objDb.PaymentID = _ID;
                if (_CheckID != 0)
                {

                    objDb.CheckID = _CheckID;
                    objDb.IsCollected = _IsCollected;
                    objDb.CollectingDate = _CollectingDate;
                    objDb.EmployeeID = _CollectingEmployeeID;
                    objDb.BranchID = _CollectingBranchID;
                    objDb.CofferID = _CollectingCofferID;

                    //objDb.Add();
                    strSql += objDb.AddStr;
                }
                else if (_WireTransfere != 0)
                {
                    WireTransferePaymentDb objWirePaymentDb = new WireTransferePaymentDb();
                    //objWirePaymentDb.PaymentID = _ID;
                    objWirePaymentDb.WireTransfereID = _WireTransfere;
                    objDb.IsCollected = _IsCollected;
                    objDb.CollectingDate = _CollectingDate;
                    strSql += objWirePaymentDb.AddStr;
                }
                if (_OldPaymentID > 0)
                    strSql += CollectPaymentStr;
                return strSql;
            }
        }
        public virtual string AddStr
        {
            get
            {


                string strSql = BaseAddStr + " select @PaymentID as NewPaymentID  ";

                return strSql;
            }

        }
        public virtual string EditStr
        {
            get
            {
                _Currency = 1;
                _CurrencyValue = 1;
                double dblDate = _Date.ToOADate() - 2;

                string Returned = " UPDATE    GLPayment" +
                                " SET  PaymentValue =" + _Value + " " +
                                //" , PaymentDate = " + dblDate + "" +
                                " , PaymentCurrency = " + _Currency + "" +
                                " , PaymentCurrencyValue = " + _CurrencyValue + "" +
                                " , PaymentType = " + _Type + "" +
                                " , PaymentDesc = '" + _Desc + "'" +
                                ",PaymentEmployee=" + _EmployeeID.ToString() +
                                ",PaymentBranch=" + _BranchID.ToString() +
                                ",PaymentCoffer=" + _CofferID.ToString() +
                                ",UsrUpd=" + SysData.CurrentUser.ID +
                                ",TimUpd=GetDate() " +
                                " from GLPayment  " +
                                " left outer join dbo.GLPaymentTransaction " +
                                " ON dbo.GLPayment.PaymentID = dbo.GLPaymentTransaction.PaymentID " +
                                " LEFT OUTER JOIN dbo.GLReceiptPayment " +
                                " ON dbo.GLPayment.PaymentID = dbo.GLReceiptPayment.PaymentID " +
                                " Where dbo.GLPayment.PaymentID =" + _ID + "" +
                                " and dbo.GLPaymentTransaction.PaymentID is null " +
                                " and  dbo.GLReceiptPayment.PaymentID is null " + _ChildCondition;
                Returned += " delete from GLCheckPayment where PaymentID = " + _ID + " " + _ChildCondition;
                Returned += " delete from dbo.GLBankWireTransferePayment where  PaymentID=" + _ID + " " + _ChildCondition;
                // SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                if (_CheckID != 0)
                {

                    CheckPaymentDb objDb = new CheckPaymentDb();
                    objDb.PaymentID = _ID;
                    objDb.CheckID = _CheckID;
                    objDb.IsCollected = _IsCollected;
                    objDb.CollectingDate = _CollectingDate;
                    objDb.EmployeeID = _CollectingEmployeeID;
                    objDb.BranchID = _CollectingBranchID;
                    objDb.CofferID = _CollectingCofferID;
                    Returned += objDb.AddStr;
                }
                else if (_WireTransfere != 0)
                {
                    WireTransferePaymentDb objWirePaymentDb = new WireTransferePaymentDb();
                    objWirePaymentDb.PaymentID = _ID;
                    objWirePaymentDb.WireTransfereID = _WireTransfere;
                    Returned += objWirePaymentDb.AddStr;
                }
                return Returned;
            }
        }
        public virtual string InverseStr
        {
            get
            {
                string strMaxReceipt = "SELECT  PaymentID, MAX(ReceiptID) AS MaxReceiptID " +
                       " FROM   dbo.GLReceiptPayment " +
                       " GROUP BY PaymentID ";
                int intHasReceipt = _HasReceipt ? 1 : 0;
                string Returned = "SELECT  dbo.GLPayment.PaymentValue, GETDATE() AS PaymentDate1, dbo.GLPayment.PaymentCurrency, dbo.GLPayment.PaymentCurrencyValue, " +
                    "  dbo.GLPayment.PaymentType, '" + _Desc + "' +dbo.GLPayment.PaymentDesc, CONVERT(bit, CASE WHEN PaymentDirection = 1 THEN 0 ELSE 1 END) AS PaymentDirection1, " +
                      "dbo.GLPayment.PaymentEmployee, dbo.GLPayment.PaymentBranch, dbo.GLPayment.PaymentCoffer" +
                      ",case when 0=" + intHasReceipt + " then 0 " +
                      "   when MaxReceiptTable.PaymentID is null then 1 else 0  end as HasReceipt1 " +
                      ", 0 AS PaymentReceipt1, " +
                      " dbo.GLPayment.PaymentID AS PaymentSource1, 0 AS PaymentReverseID1, 0 AS GLTransaction1," + SysData.CurrentUser.ID.ToString() + " as  UsrIns1,GetDate() as TimIns1 " +
                      " FROM   dbo.GLPayment  " +
                      " LEFT OUTER JOIN (" + strMaxReceipt + ") as MaxReceiptTable " +
                      " on GLPayment.PaymentID = MaxReceiptTable.PaymentID " +
                      //" left outer join dbo.GLReceiptPayment "+
                      //" ON dbo.GLPayment.PaymentID = dbo.GLReceiptPayment.PaymentID  "+
                      " LEFT OUTER JOIN dbo.GLPaymentTransaction " +
                      " ON dbo.GLPayment.PaymentID = dbo.GLPaymentTransaction.PaymentID " +
                      " WHERE     ((dbo.GLPayment.PaymentID = " + _ID + ") AND (MaxReceiptTable.MaxReceiptID IS NOT NULL)) OR " +
                      " ((dbo.GLPayment.PaymentID = " + _ID + ") AND (dbo.GLPaymentTransaction.TransactionID IS NOT NULL)) ";
                Returned = "insert into GLPayment (PaymentValue, PaymentDate, PaymentCurrency, PaymentCurrencyValue, PaymentType, PaymentDesc, PaymentDirection, PaymentEmployee, PaymentBranch, " +
                      "PaymentCoffer,PaymentHasReceipt, PaymentReceipt, PaymentSourceID, PaymentReverseID, GLTransaction, UsrIns, TimIns " +
                      ") " +
                      " " + Returned;
                Returned += " declare @InversedPaymentID numeric  " +
                    " set @InversedPaymentID = (select @@IDENTITY as ID) " +
                    " update GLPayment set PaymentReverseID = case when @InversedPaymentID = null then 0 else @InversedPaymentID end  " +
                    " where PaymentID = " + _ID;
                Returned += " insert into GLCheckPayment (CheckID, PaymentID, PaymentIsCollected, PaymentCollectingDate, PaymentCollectingUsr, PaymentCollectingEmployee, PaymentCollectingBranch, " +
                      " PaymentCollectingCoffer, PaymentCollectingRealDate, PaymentCollectingID, UsrIns, TimIns " +
                      " ) " +
                      "  SELECT  dbo.GLCheckPayment.CheckID, dbo.GLPayment.PaymentReverseID AS PaymentID1, dbo.GLCheckPayment.PaymentIsCollected, " +
                      " dbo.GLCheckPayment.PaymentCollectingDate, dbo.GLCheckPayment.PaymentCollectingUsr, dbo.GLCheckPayment.PaymentCollectingEmployee, " +
                      " dbo.GLCheckPayment.PaymentCollectingBranch, dbo.GLCheckPayment.PaymentCollectingCoffer, dbo.GLCheckPayment.PaymentCollectingRealDate,  " +
                      " dbo.GLCheckPayment.PaymentCollectingID, " + SysData.CurrentUser.ID.ToString() + " as UsrIns1,GetDate() as TimIns1 " +
                      " FROM  dbo.GLCheckPayment INNER JOIN " +
                      " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID " +
                      " WHERE     (dbo.GLCheckPayment.PaymentID = " + _ID + ") AND (dbo.GLPayment.PaymentReverseID > 0) ";
                Returned += "insert into GLBankWireTransferePayment (WireTransfereID, PaymentID, UsrIns, TimIns)  " +
                    "SELECT dbo.GLBankWireTransferePayment.WireTransfereID, dbo.GLPayment.PaymentReverseID AS PaymentID1, " + SysData.CurrentUser.ID.ToString() + " as  UsrIns1, " +
                      " GetDate() TimIns1 " +
                      " FROM    dbo.GLBankWireTransferePayment INNER JOIN " +
                      " dbo.GLPayment ON dbo.GLBankWireTransferePayment.PaymentID = dbo.GLPayment.PaymentID " +
                      " WHERE     (dbo.GLPayment.PaymentReverseID > 0) AND (dbo.GLBankWireTransferePayment.PaymentID = " + _ID + ")";

                return Returned;
            }
        }
        public virtual string DeleteStr
        {
            get
            {
                // _Desc = "إلغاء-";
                //_HasReceipt = true;
                string Returned = InverseStr;
                //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                Returned = "  DELETE FROM GLPayment WHERE     (PaymentID = " + _ID + ") and PaymentReverseID = 0 ";

                Returned += " delete from GLCheckPayment where PaymentID = " + _ID +
                "  and not exists (select PaymentID from GLPayment where PaymentID =" + _ID + " and PaymentReverseID>0) ";
                Returned += " delete from dbo.GLBankWireTransferePayment where  PaymentID=" + _ID +
                     "  and not exists (select PaymentID from GLPayment where PaymentID =" + _ID + " and PaymentReverseID>0) ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strPaymentApplicant = "SELECT dbo.HRApplicant.ApplicantID AS PaymentApplicantID, dbo.HRApplicant.ApplicantFirstName AS PaymentApplicantName, " +
                      " dbo.HRApplicantWorker.ApplicantCode AS PaymentApplicantCode" +
                      " FROM     dbo.HRApplicantWorker INNER JOIN " +
                      " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";
                string strPaymentBranch = "SELECT   BranchID AS PaymentBranchID, BranchNameA AS PaymentBranchName " +
                      " FROM   dbo.HRBranch ";
                string strPaymentCoffer = "SELECT  CofferID AS PaymentCofferID, CofferCode AS PaymentCofferCode, CofferNameA AS PaymentCofferName " +
                       " FROM         dbo.GLCoffer ";

                string Returned = " SELECT     GLPayment.PaymentID, PaymentValue, PaymentDate, PaymentCurrency, PaymentCurrencyValue, " +
                    "PaymentType, PaymentDesc, GLTransaction,CurrencyTable.*,CheckPaymentTable.*" +
                    ",TransferePaymentTable.*,PaymentApplicantTable.*,PaymentBranchTable.*,PaymentCofferTable.*  " +
                                  " FROM  GLPayment INNER JOIN (" + CurrencyDb.SearchStr + ") as CurrencyTable ON GLPayment.PaymentCurrency = CurrencyTable.CurrencyID ";
                if (_CheckIDs != null && _CheckIDs != "")
                    Returned += " inner join (" + CheckPaymentDb.SearchStr + ") as CheckPaymentTable ";
                else
                    Returned += " left outer join (" + CheckPaymentDb.SearchStr + ") as CheckPaymentTable ";
                Returned += "on GLPayment.PaymentID = CheckPaymentTable.Payment " +
                              " left outer join (" + WireTransferePaymentDb.SearchStr + ") as TransferePaymentTable on GLPayment.PaymentID = TransferePaymentTable.TransferePayment" +
                              " left outer join (" + strPaymentApplicant + ") as PaymentApplicantTable " +
                              " on  dbo.GLPayment.PaymentEmployee = PaymentApplicantTable.PaymentApplicantID " +
                              " left outer join(" + strPaymentBranch + ") as PaymentBranchTable " +
                              " on GLPayment.PaymentBranch = PaymentBranchTable.PaymentBranchID   " +
                                 " left outer join(" + strPaymentCoffer + ") as PaymentCofferTable " +
                              " on GLPayment.PaymentCoffer = PaymentCofferTable.PaymentCofferID   " +
                              " left outer join GLPaymentTransaction " +
                              " on  GLPayment.PaymentID = GLPaymentTransaction.PaymentID ";

                if (_CheckIDTable != null && _CheckIDTable != "")
                {
                    string strCheckPayment = @"SELECT        dbo.GLCheckPayment.PaymentID
FROM            (" + _CheckIDTable + @") AS derivedtbl_1 INNER JOIN
                         dbo.GLCheckPayment ON derivedtbl_1.CheckID = dbo.GLCheckPayment.CheckID";
                    Returned += " inner join (" + strCheckPayment + ") as SelectedCheckTable " +
                        " on  GLPayment.PaymentID = SelectedCheckTable.PaymentID ";


                }
                Returned += " where (1=1) " +
                    "  ";
                if (!_IncludeNonCanceledPayment)
                    Returned += " and  dbo.GLPayment.PaymentReverseID =0  and  dbo.GLPayment.PaymentSourceID =0 ";
                return Returned;
            }
        }
        public string CollectPaymentStr
        {
            get
            {
                int intIsCollected = _IsCollected ? 1 : 0;
                double dblCollectingDate = _CollectingDate.ToOADate() - 2;
                int intCollectingDate = (int)dblCollectingDate;
                intCollectingDate = intCollectingDate > dblCollectingDate ? intCollectingDate - 1 : intCollectingDate;
                string strCollectingDate = _IsCollected ? dblCollectingDate.ToString() : "null";
                string strID = _ID == 0 ? "@PaymentID" : _ID.ToString();
                string Returned = "";
                //for old check 
                if (_OldPaymentID != 0)
                    Returned += "  update GLPayment set PaymentType = 1 ,PaymentValue= PaymentValue -  " + _Value + " where  PaymentID = " + _OldPaymentID;
                Returned += " update GLPayment set PaymentType = " + _Type + " where PaymentID = " + strID +
                    " update GLCheckPayment set  PaymentIsCollected=" + intIsCollected +
                    ", PaymentCollectingDate=" + strCollectingDate +
                    ", PaymentCollectingUsr=" + SysData.CurrentUser.ID.ToString() +
                    ",PaymentCollectingEmployee=" + _CollectingEmployeeID.ToString() +
                    ",PaymentCollectingBranch=" + _CollectingBranchID.ToString() +
                    ",PaymentCollectingCoffer=" + _CollectingCofferID.ToString() +
                    ",PaymentCollectingRealDate=GetDate() " +
                    " where CheckID=" + _CheckID + " and PaymentID=" + strID;
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        protected void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["PaymentID"] != null && objDR["PaymentID"].ToString() != "")
                _ID = int.Parse(objDR["PaymentID"].ToString());
            if (objDR.Table.Columns["PaymentValue"] != null && objDR["PaymentValue"].ToString() != "")
                _Value = double.Parse(objDR["PaymentValue"].ToString());
            if (objDR.Table.Columns["PaymentType"] != null && objDR["PaymentType"].ToString() != "")
                _Type = int.Parse(objDR["PaymentType"].ToString());
            if (objDR.Table.Columns["PaymentDate"] != null && objDR["PaymentDate"].ToString() != "")
                _Date = DateTime.Parse(objDR["PaymentDate"].ToString());
            if (objDR.Table.Columns["PaymentDesc"] != null && objDR["PaymentDesc"].ToString() != "")
                _Desc = objDR["PaymentDesc"].ToString();
            if (objDR.Table.Columns["GLTransaction"] != null && objDR["GLTransaction"].ToString() != "")
                _GLTransaction = int.Parse(objDR["GLTransaction"].ToString());
            if (objDR.Table.Columns["PaymentCurrency"] != null && objDR["PaymentCurrency"].ToString() != "")
                _Currency = int.Parse(objDR["PaymentCurrency"].ToString());
            if (objDR.Table.Columns["PaymentCurrencyValue"] != null && objDR["PaymentCurrencyValue"].ToString() != "")
                _CurrencyValue = double.Parse(objDR["PaymentCurrencyValue"].ToString());

            if (objDR.Table.Columns["PaymentWireTransfere"] != null && objDR["PaymentWireTransfere"].ToString() != "")
                _WireTransfere = int.Parse(objDR["PaymentWireTransfere"].ToString());
            if (objDR.Table.Columns["PaymentApplicantID"] != null && objDR["PaymentApplicantID"].ToString() != "")
                _EmployeeID = int.Parse(objDR["PaymentApplicantID"].ToString());
            if (objDR.Table.Columns["PaymentApplicantName"] != null)
                _EmployeeName = objDR["PaymentApplicantName"].ToString();
            if (objDR.Table.Columns["PaymentApplicantCode"] != null)
                _EmployeeCode = objDR["PaymentApplicantCode"].ToString();
            if (objDR.Table.Columns["PaymentBranchID"] != null && objDR["PaymentBranchID"].ToString() != "")
                _BranchID = int.Parse(objDR["PaymentBranchID"].ToString());
            if (objDR.Table.Columns["PaymentBranchName"] != null)
                _BranchName = objDR["PaymentBranchName"].ToString();
            if (objDR.Table.Columns["PaymentCofferID"] != null && objDR["PaymentCofferID"].ToString() != "")
                _CofferID = int.Parse(objDR["PaymentCofferID"].ToString());
            if (objDR.Table.Columns["PaymentCofferCode"] != null)
                _CofferCode = objDR["PaymentCofferCode"].ToString();
            if (objDR.Table.Columns["PaymentCofferName"] != null)
                _CofferName = objDR["PaymentCofferName"].ToString();


            try
            {
                if (objDR.Table.Columns["PaymentCheck"] != null && objDR["PaymentCheck"].ToString() != "")
                {
                    _CheckID = int.Parse(objDR["PaymentCheck"].ToString());
                    _IsCollected = bool.Parse(objDR["PaymentIsCollected"].ToString());
                    if (objDR["PaymentCollectingDate"].ToString() != "")
                        _CollectingDate = DateTime.Parse(objDR["PaymentCollectingDate"].ToString());
                    if (_IsCollected && objDR["CollectingApplicantID"].ToString() != "")
                        _CollectingEmployeeID = int.Parse(objDR["CollectingApplicantID"].ToString());
                    _CollectingEmployeeName = objDR["CollectingApplicantName"].ToString();
                    _CollectingEmployeeCode = objDR["CollectingApplicantCode"].ToString();
                    if (objDR["CollectingBranchID"].ToString() != "")
                        _CollectingBranchID = int.Parse(objDR["CollectingBranchID"].ToString());
                    _CollectingBranchName = objDR["CollectingBranchName"].ToString();
                    if (objDR["CollectingCofferID"].ToString() != "")
                        _CollectingCofferID = int.Parse(objDR["CollectingCofferID"].ToString());
                    _CollectingCofferCode = objDR["CollectingCofferCode"].ToString();
                    _CollectingCofferName = objDR["CollectingCofferName"].ToString();

                }
                else
                    _CheckID = 0;
            }
            catch
            { }
        }

        #endregion

        #region Public Methods
        public virtual void Add()
        {
            //_Currency = 1;
            //_CurrencyValue = 1;
            //double dblDate = _Date.ToOADate() - 2;
            //string strCollectingDate = _IsCollected ? (_CollectingDate.ToOADate() - 2).ToString() : "null";
            //int intIsCollected = _IsCollected ? 1 : 0;
            //int intDirection = _Direction ? 1 : 0;
            //string strSql = " INSERT INTO GLPayment" +
            //               " ( PaymentValue, PaymentDate,PaymentCurrency,PaymentCurrencyValue, PaymentType, PaymentDesc"+
            //               ",PaymentDirection,PaymentEmployee,PaymentBranch,PaymentCoffer,UsrIns,TimIns)" +
            //               " VALUES     (" + _Value + "," + dblDate + "," + _Currency + "," + 
            //               _CurrencyValue + "," + _Type + ",'" + _Desc + "',"+ intDirection + "," + _EmployeeID + "," + _BranchID  +
            //              "," + _CofferID + ","+ SysData.CurrentUser.ID +",GetDate()) ";
            //_ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            // CheckPaymentDb objDb = new CheckPaymentDb();
            //    objDb.PaymentID = _ID;
            //if (_CheckID != 0)
            //{

            //    objDb.CheckID = _CheckID;
            //    objDb.IsCollected = _IsCollected;
            //    objDb.CollectingDate = _CollectingDate;
            //    objDb.EmployeeID = _CollectingEmployeeID;
            //    objDb.BranchID = _CollectingBranchID;
            //    objDb.CofferID = _CollectingCofferID;

            //    objDb.Add();
            //}
            //else if (_WireTransfere != 0)
            //{
            //    WireTransferePaymentDb objWirePaymentDb = new WireTransferePaymentDb();
            //    objWirePaymentDb.PaymentID = _ID;
            //    objWirePaymentDb.WireTransfereID = _WireTransfere;
            //    objDb.IsCollected = _IsCollected;
            //    objDb.CollectingDate = _CollectingDate;
            //    objWirePaymentDb.Add();
            //}
            //_ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            _ID = (int)SysData.SharpVisionBaseDb.ReturnScalar(AddStr);
        }
        public virtual void Edit()
        {
            // _Currency = 1;
            // _CurrencyValue = 1;
            // double dblDate = _Date.ToOADate() - 2;
            // string strSql = " UPDATE    GLPayment" +
            //                 " SET  PaymentValue =" + _Value + " " +
            //                 " , PaymentDate = " + dblDate + "" +
            //                 " , PaymentCurrency = " + _Currency + "" +
            //                 " , PaymentCurrencyValue = " + _CurrencyValue + "" +
            //                 " , PaymentType = " + _Type + "" +
            //                 " , PaymentDesc = '" + _Desc + "'" +
            //                 ",PaymentEmployee="+_EmployeeID.ToString() +
            //                 ",PaymentBranch="+_BranchID.ToString() + 
            //                 ",PaymentCoffer="+ _CofferID.ToString() +
            //                 ",UsrUpd="+SysData.CurrentUser.ID+
            //                 ",TimUpd=GetDate() "+
            //                 " from GLPayment  " +
            //                 " left outer join dbo.GLPaymentTransaction "+
            //                 " ON dbo.GLPayment.PaymentID = dbo.GLPaymentTransaction.PaymentID "+
            //                 " LEFT OUTER JOIN dbo.GLReceiptPayment "+
            //                 " ON dbo.GLPayment.PaymentID = dbo.GLReceiptPayment.PaymentID "+
            //                 " Where dbo.GLPayment.PaymentID =" + _ID + "" +
            //                 " and dbo.GLPaymentTransaction.PaymentID is null "+
            //                 " and  dbo.GLReceiptPayment.PaymentID is null";
            // strSql += " delete from GLCheckPayment where PaymentID = " + _ID;
            // strSql += " delete from dbo.GLBankWireTransferePayment where  PaymentID="+_ID;
            //// SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            // if (_CheckID != 0)
            // {

            //     CheckPaymentDb objDb = new CheckPaymentDb();
            //     objDb.PaymentID = _ID;
            //     objDb.CheckID = _CheckID;
            //     objDb.IsCollected = _IsCollected;
            //     objDb.CollectingDate = _CollectingDate;
            //     objDb.EmployeeID = _CollectingEmployeeID;
            //     objDb.BranchID = _CollectingBranchID;
            //     objDb.CofferID = _CollectingCofferID;
            //    // objDb.Add();
            // }
            // else if (_WireTransfere != 0)
            // {
            //     WireTransferePaymentDb objWirePaymentDb = new WireTransferePaymentDb();
            //     objWirePaymentDb.PaymentID = _ID;
            //     objWirePaymentDb.WireTransfereID = _WireTransfere;
            //   //  objWirePaymentDb.Add();
            // }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public virtual void Delete()
        {


            //string strSql = InverseStr;
            ////SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //strSql ="  DELETE FROM GLPayment WHERE     (PaymentID = " + _ID + ") and PaymentReverseID = 0 ";

            //strSql += " delete from GLCheckPayment where PaymentID = " + _ID +
            //"  and not exists (select PaymentID from GLPayment where PaymentID =" + _ID + " and PaymentReverseID>0) ";
            //strSql += " delete from dbo.GLBankWireTransferePayment where  PaymentID=" + _ID +
            //     "  and not exists (select PaymentID from GLPayment where PaymentID =" + _ID + " and PaymentReverseID>0) ";
            _HasReceipt = true;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public virtual DataTable Search()
        {
            string strSql = SearchStr;
            if (_ID != 0)
                strSql = strSql + " and PaymentID = " + _ID.ToString();
            if (_CheckID != 0)
                strSql += " and PaymentCheck=" + _CheckID;
            else if (_CheckIDs != null && _CheckIDs != "")
                strSql += " and PaymentCheck in (" + _CheckIDs + ")";
            if (_WireTransfere != 0)
                strSql += " and PaymentWireTransfere = " + _WireTransfere;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void CollectCheckPayment()
        {
            int intIsCollected = _IsCollected ? 1 : 0;
            double dblCollectingDate = _CollectingDate.ToOADate() - 2;
            int intCollectingDate = (int)dblCollectingDate;
            intCollectingDate = intCollectingDate > dblCollectingDate ? intCollectingDate - 1 : intCollectingDate;
            string strCollectingDate = _IsCollected ?
                (PaymentDb.UMSChangePaymentDateAuthorised ? dblCollectingDate.ToString() : "GetDate()") : "null";
            string strSql = " update GLPayment set PaymentType = " + _Type + " where PaymentID = " + _ID +
                " update GLCheckPayment set  PaymentIsCollected=" + intIsCollected +
                ", PaymentCollectingDate=" + strCollectingDate +
                ", PaymentCollectingUsr=" + SysData.CurrentUser.ID.ToString() +
                ",PaymentCollectingEmployee=" + _CollectingEmployeeID.ToString() +
                ",PaymentCollectingBranch=" + _CollectingBranchID.ToString() +
                ",PaymentCollectingCoffer=" + _CollectingCofferID.ToString() +
                ",PaymentCollectingRealDate=GetDate() " +
                " where CheckID=" + _CheckID + " and PaymentID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void CollectCheckPayment1()
        {

            _HasReceipt = false;
            string strSql = DeleteStr;
            _Date = _CollectingDate;
            _CofferID = _CollectingCofferID;
            _BranchID = _CollectingBranchID;
            _EmployeeID = _CollectingEmployeeID;
            int intOldID = _ID;
            strSql += " " + AddStr;
            string strOldMaxReceipt = "SELECT  PaymentID, MAX(ReceiptID) AS MaxReceiptID " +
                   " FROM         dbo.GLReceiptPayment " +
                   " GROUP BY PaymentID " +
                   " HAVING      (PaymentID = " + intOldID + ")";
            strSql += " update GLPayment set PaymentHasReceipt = case when not exists (" + strOldMaxReceipt + ") then 1 else 0 end " +
                " where PaymentID = @PaymentID ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public bool InsertTransaction()
        {
            if (_TransactionTable == null || _TransactionTable.Rows.Count == 0)
                return false;
            DataRow[] arrDr;
            string[] arrStr;
            TransactionDb objTRansactionDb;
            TransactionElementDb objTransactionElementDb;
            int intIndex = 0;
            List<string[]> lstTransArray = new List<string[]>();
            string strInvoice = "";
            foreach (DataRow objDr in _TransactionTable.Rows)
            {
                objTRansactionDb = new TransactionDb(objDr);
                arrDr = _TRansactionElementTable.Select("GeneratedID=" + objTRansactionDb.GeneratedID);
                arrStr = new string[arrDr.Length + 2];
                arrStr[0] = objTRansactionDb.AddStr;

                intIndex = 1;

                foreach (DataRow objElementDr in arrDr)
                {
                    arrStr[intIndex] = "declare @TransactionID numeric(18,0) ;";
                    arrStr[intIndex] += "set @TransactionID= (select Max(TransactionID) as MaxID from GLTransaction ) ";
                    objTransactionElementDb = new TransactionElementDb(objElementDr);

                    arrStr[intIndex] += objTransactionElementDb.AddStr;
                    intIndex++;
                }
                arrDr = _PaymentTransactionTable.Select("GeneratedID=" + objTRansactionDb.GeneratedID.ToString());
                if (arrDr.Length > 0)
                {
                    arrStr[intIndex] = "declare @TransactionID numeric(18,0) ;";
                    arrStr[intIndex] += "set @TransactionID= (select Max(TransactionID) as MaxID from GLTransaction ) ";
                    arrStr[intIndex] += " update GLPayment set GLTransaction = @TransactionID  " +
                        " where PaymentID in (" + arrDr[0]["IDs"].ToString() + ")";
                }
                lstTransArray.Add(arrStr);

            }
            foreach (string[] arrTemp in lstTransArray)
            {
                SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrTemp);
            }
            return true;
        }
        #endregion
    }
}
