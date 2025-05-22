using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.GL.GLDataBase
{
    public class CheckDb
    {
        #region Private Data
        protected int _ID;
        protected string _IDs;
        protected int _Bank;
        protected int _AccountID;
        protected int _GLAccountID;
        protected int _Type;
        protected string _Code;
        protected double _Value;
        protected int _Currency;
        protected DateTime _IssueDate;
        protected DateTime _DueDate;
        protected DateTime _PaymentDate;
        protected string _CheckNote;
        protected string _EditorName;
        protected bool _IsBankOriented;
        protected int _BankOrientedStatus;
        int _TransactionID;
        protected string _BeneficialName;
        protected int _AttachmentID;
        protected bool _IsPaid;
        protected DateTime _SubmissionDate;
        protected bool _IsSubmitted;
        bool _MaxStatusDateLimited;
        DateTime _MaxStatusDate;

        protected int _Status;
        protected DateTime _StatusDate;
        protected int _Place;
        protected int _OldPlace;
        protected int _ParentID;
        private int _PrintModelID;
        private int _PrintEmployeeID;

        int _MaxPaymentID;
        double _MaxPaymentValue;
        DateTime _MaxPaymentDate;
        bool _MaxPaymentIsCollected;
        DateTime _MaxPaymentCollectingDate;
        string _MaxPaymentDesc;
        int _MaxID;
        int _MinID;
        int _ResultCount;

        double _ResultValue;
        string _AccountCode;
        string _AccountOwner;
        string _AccountDesc;

        string _GLAccountCode;
        string _GLAccountName;
        string _StatusStr;
        static string _CheckIDs;
        static DataTable _CachePaymentTable;
        int _PersonID;
        int _PersonType;/*
                         * 1 Employee
                         * 2 Contractor
                         * 3 Suplier
                         * 4 Customer
                         */
        int _LastPrintID;
        int _PrintNo;


        #region Private data for search
        protected bool _IsDueRange;
        DateTime _StartDueDate;
        DateTime _EndDueDate;
        bool _IsIssueRange;
        DateTime _StartIssueDate;
        DateTime _EndIssueDate;
        bool _IsStatusDateRange;
        DateTime _StartStatusDate;
        DateTime _EndStatusDate;
        bool _IsSubmissionRange;
        DateTime _StartSubmissionDate;
        DateTime _EndSubmissionDate;

        double _TotalPayment;
        double _CollectedValue;
        string _CellIDs;
        int _CellFamilyID;
        int _CampaignID;
        // int _ReservationID;
        int _CustomerID;

        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        string _CustomerName;

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        bool _StatusValue;
        double _FromCheckValue;
        double _ToCheckValue;
        bool _Direction;/*
                         * True -> 1 Input
                         * False ->0 Output
                         */

        byte _PaymentStatus;//0 not Mentioned
        // 1 not paid
        // 2 paid
        int _SharedPaymentStatus;//0 dont care
                                 //1 Payment = 0
                                 //2 PaymentSum = value
        int _CollectingPaymentStatus;/*
                                      * 0 dont care
                                      * 1 TotallyCollected
                                      * 2 not totally collected
                                      * 3 partially collected but not completed
                                      * 4 Partially TotallyCollected
                                      */
        #endregion
        #endregion

        #region Constructors
        public CheckDb()
        {

        }
        public CheckDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);

        }
        public CheckDb(DataRow objDR)
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
        public string IDs
        {
            set
            {
                _IDs = value;
            }
            get
            {
                return _IDs;

            }
        }
        public int Bank
        {
            set
            {
                _Bank = value;
            }
            get
            {
                return _Bank;
            }
        }
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }
        }
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public string EditorName
        {
            set
            {
                _EditorName = value;
            }
            get
            {
                return _EditorName;
            }
        }
        public int TransactionID
        {
            set
            {
                _TransactionID = value;
            }
            get
            {
                return _TransactionID;
            }
        }
        public string BeneficialName
        {
            set
            {
                _BeneficialName = value;
            }
            get
            {
                return _BeneficialName;
            }
        }
        public string CheckNote
        {
            set
            {
                _CheckNote = value;
            }
            get
            {
                return _CheckNote;
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
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        string _StatusComment;

        public string StatusComment
        {
            get { return _StatusComment; }
            set { _StatusComment = value; }
        }
        int _CollectingBank;

        public int CollectingBank
        {
            get { return _CollectingBank; }
            set { _CollectingBank = value; }
        }
        string _CollectingBankName;

        public string CollectingBankName
        {
            get { return _CollectingBankName; }
            set { _CollectingBankName = value; }
        }

        public DateTime StatusDate
        {
            set
            {
                _StatusDate = value;
            }
            get
            {
                return _StatusDate;
            }
        }
        public int Place
        {
            set
            {
                _Place = value;
            }
            get
            {
                return _Place;
            }
        }
        string _PlaceIDs;

        public string PlaceIDs
        {
            get { return _PlaceIDs; }
            set { _PlaceIDs = value; }
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
        public bool IsBankOrieneted
        {
            set
            {
                _IsBankOriented = value;
            }
            get
            {
                return _IsBankOriented;
            }
        }

        public int ParentID
        {
            set
            {
                _ParentID = value;
            }
            get
            {
                return _ParentID;
            }
        }
        public double TotalPayment
        {
            set
            {
                _TotalPayment = value;
            }
            get
            {
                return _TotalPayment;
            }
        }

        public DateTime DueDate
        {
            set
            {
                _DueDate = value;
            }
            get
            {
                return _DueDate;
            }
        }
        public DateTime IssueDate
        {
            set
            {
                _IssueDate = value;
            }
            get
            {
                return _IssueDate;
            }
        }
        public DateTime PaymentDate
        {
            set
            {
                _PaymentDate = value;
            }
            get
            {
                return _PaymentDate;
            }
        }
        public bool IsPaid
        {
            set
            {
                _IsPaid = value;
            }
            get
            {
                return _IsPaid;
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
        public int AccountID
        {
            set
            {
                _AccountID = value;
            }
            get
            {
                return _AccountID;
            }
        }
        public int GLAccountID
        {
            set
            {
                _GLAccountID = value;
            }
            get
            {
                return _GLAccountID;
            }
        }
        public int OldPlace
        {
            set
            {
                _OldPlace = value;
            }
        }
        public int BankOrientedStatus
        {
            set
            {
                _BankOrientedStatus = value;
            }

        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int CampaignID
        {
            set
            {
                _CampaignID = value;
            }
        }
        int _ResubmissionID;

        public int ResubmissionID
        {

            set { _ResubmissionID = value; }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public int PersonID
        {
            set
            {
                _PersonID = value;
            }
        }
        public int PersonType
        {
            set
            {
                _PersonType = value;
            }
        }
        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }
        }
        public bool IsDueRange
        {
            set
            {
                _IsDueRange = value;
            }
        }
        public DateTime StartDueDate
        {
            set
            {
                _StartDueDate = value;
            }
        }
        public bool MaxStatusDateLimited
        {
            set
            {
                _MaxStatusDateLimited = value;
            }
        }
        public DateTime MaxStatusDate
        {
            set
            {
                _MaxStatusDate = value;
            }
        }

        public DateTime EndDueDate
        {
            set
            {
                _EndDueDate = value;
            }
        }
        public bool IsIssueRange
        {
            set
            {
                _IsIssueRange = value;
            }
        }
        public DateTime StartIssueDate
        {
            set
            {
                _StartIssueDate = value;
            }
        }
        public DateTime EndIssueDate
        {
            set
            {
                _EndIssueDate = value;
            }
        }
        public bool IsStatusDateRange
        {
            set
            {
                _IsStatusDateRange = value;
            }
        }
        public DateTime StartStatusDate
        {
            set
            {
                _StartStatusDate = value;
            }
        }
        public DateTime EndStatusDate
        {
            set
            {
                _EndStatusDate = value;
            }
        }
        public bool IsSubmissionRange
        {
            set
            {
                _IsSubmissionRange = value;
            }
        }
        public DateTime StartSubmissionDate
        {
            set
            {
                _StartSubmissionDate = value;
            }
        }
        public DateTime EndSubmissionDate
        {
            set
            {
                _EndSubmissionDate = value;
            }
        }
        public byte PaymentStatus
        {
            set
            {
                _PaymentStatus = value;
            }
        }
        public int SharedPaymentStatus
        {
            set
            {
                _SharedPaymentStatus = value;
            }
        }
        public int CollectingPaymentStatus
        {
            set
            {
                _CollectingPaymentStatus = value;
            }
        }
        public string StatusStr
        {
            set
            {
                _StatusStr = value;
            }
        }

        public double CollectedValue
        {
            get
            {
                return _CollectedValue;

            }
        }
        public string MaxPaymentDesc
        {
            get
            {
                return _MaxPaymentDesc;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public double ResultValue
        {
            get
            {
                return _ResultValue;
            }
        }
        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
        }
        public string AccountOwner
        {
            get
            {
                return _AccountOwner;
            }
        }
        public string AccountDesc
        {
            get
            {
                return _AccountDesc;
            }
        }
        public string GLAccountCode
        {
            get
            {
                return _GLAccountCode;
            }
        }

        public string GLAccountName
        {
            get
            {
                return _GLAccountName;
            }
        }
        public bool StatusValue
        {
            set
            {
                _StatusValue = value;
            }
        }
        public double FromCheckValue
        {
            set
            {
                _FromCheckValue = value;
            }
            get
            {
                return _FromCheckValue;
            }
        }
        public double ToCheckValue
        {
            set
            {
                _ToCheckValue = value;
            }
            get
            {
                return _ToCheckValue;
            }
        }
        public bool IsSubmitted
        {
            set
            {
                _IsSubmitted = value;
            }
            get
            {
                return _IsSubmitted;
            }
        }
        public DateTime SubmissionDate
        {
            set
            {
                _SubmissionDate = value;
            }
            get
            {
                return _SubmissionDate;
            }
        }
        public int PrintModelID
        {
            get
            {
                return _PrintModelID;
            }
            set
            {
                _PrintModelID = value;
            }
        }
        public int LastPrintID
        {
            get
            {
                return _LastPrintID;
            }
            set
            {
                _LastPrintID = value;
            }
        }



        public int PrintNo
        {
            get { return _PrintNo; }
            set { _PrintNo = value; }
        }
        int _HasPaymentStatus;

        public int HasPaymentStatus
        {
            get { return _HasPaymentStatus; }
            set { _HasPaymentStatus = value; }
        }
        bool _IsPaymentRange;

        public bool IsPaymentRange
        {
            get { return _IsPaymentRange; }
            set { _IsPaymentRange = value; }
        }
        DateTime _StartPaymentDate;

        public DateTime StartPaymentDate
        {
            get { return _StartPaymentDate; }
            set { _StartPaymentDate = value; }
        }
        DateTime _EndPaymentDate;

        public DateTime EndPaymentDate
        {
            get { return _EndPaymentDate; }
            set { _EndPaymentDate = value; }
        }
        static string _CheckIDTableStr;

        public static string CheckIDTableStr
        {
            get { return CheckDb._CheckIDTableStr; }
            set { CheckDb._CheckIDTableStr = value; }
        }
        DataTable _CheckIDTable;
        public DataTable CheckIDTable
        {
            set => _CheckIDTable = value;
        }
        int _ReservationID;

        public int ReservationID
        {
            get { return _ReservationID; }
            set { _ReservationID = value; }
        }
        string _ReservationIDs;
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }

        }

        bool _IgnoreInstallmentType;

        public bool IgnoreInstallmentType
        {

            set { _IgnoreInstallmentType = value; }
        }
        string _InstallmentTypeIDs;

        public string InstallmentTypeIDs
        {

            set { _InstallmentTypeIDs = value; }
        }
        int _MultipleInstallmentStatus;

        public int MultipleInstallmentStatus
        {
            get { return _MultipleInstallmentStatus; }
            set { _MultipleInstallmentStatus = value; }
        }
        int _MultipleReservationStatus;

        public int MultipleReservationStatus
        {
            get { return _MultipleReservationStatus; }
            set { _MultipleReservationStatus = value; }
        }
        DateTime _MaxInstallmentDueDate;
        public DateTime MaxInstallmentDueDate
        {
            set { _MaxInstallmentDueDate = value; }
            get { return _MaxInstallmentDueDate; }
        }
        DateTime _MinInstallmentDueDate;
        public DateTime MinInstallmentDueDate
        {
            set { _MinInstallmentDueDate = value; }
            get { return _MinInstallmentDueDate; }
        }
        int _CheckInstallmentCount;
        public int CheckInstallmentCount
        {
            set { _CheckInstallmentCount = value; }
            get { return _CheckInstallmentCount; }
        }
        int _CheckReservationCount;
        public int CheckReservationCount
        {
            set { _CheckReservationCount = value; }
            get { return _CheckReservationCount; }
        }
        int _TotalMonthCount;
        public int TotalMonthCount
        {
            set { _TotalMonthCount = value; }
            get { return _TotalMonthCount; }
        }
        int _HasInstallment;
        public int HasInstallment
        {
            set { _HasInstallment = value; }
            get { return _HasInstallment; }
        }
        public static string CheckIDs
        {
            set
            {
                _CheckIDs = value;
            }
        }
        public static DataTable CachePaymentTable
        {
            get
            {
                if (_CachePaymentTable == null && ((_CheckIDs != null && _CheckIDs != "") || (_CheckIDTableStr != null && _CheckIDTableStr != "")))
                {
                    //CheckPaymentDb
                    PaymentDb objDb = new PaymentDb();
                    if (_CheckIDs != null && _CheckIDs != "")
                    {
                        objDb.CheckIDs = _CheckIDs;
                        _CachePaymentTable = objDb.Search();
                    }
                    else
                    {
                        //string strPayment ="select CheckPaymentTable.* from ("+ objDb.SearchStr + ") as CheckPaymentTable "+
                        //    " inner join ("+ _CheckIDTable +") as SelectCheckTable"+
                        //    " on CheckPaymentTable.PaymentCheck = SelectCheckTable.CheckID ";
                        objDb.CheckIDTable = _CheckIDTableStr;
                        string strPayment = objDb.SearchStr;
                        _CachePaymentTable = SysData.SharpVisionBaseDb.ReturnDatatable(strPayment);
                    }
                }
                return _CachePaymentTable;
            }
        }
        string ReservationPaymentStr
        {
            get
            {
                string Returned = "";
                if (_HasPaymentStatus != 1)
                    return "";
                if (_CellFamilyID != 0 ||
                    (_CellIDs != null && _CellIDs != "") || _CampaignID != 0 || _ResubmissionID != 0
                    || (_InstallmentTypeIDs != null && _InstallmentTypeIDs != ""))
                {
                    Returned = "SELECT DISTINCT dbo.GLCheck.CheckID " +
                     " FROM    dbo.GLCheck INNER JOIN " +
                      " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID " +
                      " INNER JOIN " +
                      " dbo.CRMInstallmentPayment ON dbo.GLCheckPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID INNER JOIN " +
                      " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID INNER JOIN " +
                      " dbo.CRMReservation ON dbo.CRMReservationInstallment.ReservationID = dbo.CRMReservation.ReservationID INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMReservation.ReservationID = dbo.CRMReservationUnit.ReservationID INNER JOIN " +
                      " dbo.CRMUnitCell ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID " +
                      " inner join CRMReservationCustomer " +
                      " on dbo.CRMReservation.ReservationID = dbo.CRMReservationCustomer.ReservationID ";
                    if (_CampaignID != 0)
                        Returned += " inner join  dbo.CRMCampaignCustomer  " +
                            " on  dbo.CRMReservationCustomer.CustomerID = dbo.CRMCampaignCustomer.Customer ";
                    if (_ResubmissionID != 0)
                    {
                        #region Reservation Submission

                        string strResubmission = "SELECT     distinct   ResubmissionReservation " +
                               " FROM     dbo.CRMReservationResubmission " +
                                " WHERE        (ResubmissionType = " + _ResubmissionID + ") AND (ResubmissionEndDate IS NULL OR " +
                                " ResubmissionEndDate > dbo.GetApproximateDate(GETDATE()))";
                        Returned += " inner join   (" + strResubmission + ") as ResubmissionTable " +
                      " on  CRMReservation.ReservationID = ResubmissionTable.ResubmissionReservation ";


                        #endregion

                    }
                    Returned += " WHERE    (1=1) ";
                    if (_CellIDs != null && _CellIDs != "")
                        Returned += " and (dbo.RPCell.CellID IN (" + _CellIDs + ")) ";
                    if (_CellFamilyID != 0)
                        Returned += " AND (dbo.RPCell.CellFamilyID = " + _CellFamilyID + ")";
                    if (_CampaignID != 0)
                        Returned += " and  dbo.CRMCampaignCustomer.Campaign = " + _CampaignID;
                    if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    {
                        Returned += " and dbo.CRMReservationInstallment.InstallmentType ";
                        if (_IgnoreInstallmentType)
                            Returned += " not ";
                        Returned += " in (" + _InstallmentTypeIDs + ") ";


                    }
                }
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strPayment = "select CheckID,sum(PaymentValue) as TotalPayment,max(PaymentID) as MaxPaymentID " +
                    ",sum(case when PaymentIsCollected=1 then PaymentValue else 0 end) as CollectedPaymentValue " +
                    ",max(case when PaymentIsCollected=1 then PaymentCollectingDate else convert(datetime,'1900-01-01') end) as MaxCollectedPaymentDate " +
                    ",COUNT(DISTINCT CheckPaymentTable.InstallmentID) AS CheckInstallmentCount " +
                    ",COUNT(DISTINCT CheckPaymentTable.ReservationID)  AS CheckReservationCount " +
                    ",case when max(CheckPaymentTable.InstallmentDueDate) is null then 0 else 1 end as HasInstallment " +
                    ",max(CheckPaymentTable.InstallmentDueDate) as CheckMaxInstallmentDueDate,min(CheckPaymentTable.InstallmentDueDate) as CheckMinInstallmentDueDate " +
                    ",case when max(CheckPaymentTable.InstallmentDueDate) is null then 0  " +
                    " else  DATEDIFF(MONTH	,Min(CheckPaymentTable.InstallmentDueDate),MAX(CheckPaymentTable.InstallmentDueDate)) " +
                    " end as TotalMonthCount  " +
                    " from " +
                    " (SELECT     CheckID, GLPayment.PaymentID, PaymentValue,PaymentIsCollected,dbo.GLCheckPayment.PaymentCollectingDate  " +
                    ",dbo.CRMReservationInstallment.ReservationID,dbo.CRMInstallmentPayment.InstallmentID " +
                    ",   dbo.CRMReservationInstallment.InstallmentDueDate " +
                    " FROM         GLCheckPayment INNER JOIN " +
                    " GLPayment ON GLCheckPayment.PaymentID = GLPayment.PaymentID " +
                    " left outer join     dbo.CRMInstallmentPayment " +
                    " ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID " +
                    " left outer join CRMReservationInstallment  " +
                    " on dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID   " +
                     " where (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) " +
                    ") as CheckPaymentTable " +
                    " group by CheckID ";
                strPayment = "select PaymentTable.*,dbo.GLPayment.PaymentValue AS MaxPaymentValue, " +
                      " dbo.GLPayment.PaymentDate AS MaxPaymentDate, dbo.GLPayment.PaymentDesc AS MaxPaymentDesc,  " +
                      " dbo.GLCheckPayment.PaymentIsCollected AS MaxPaymentIsCollected, dbo.GLCheckPayment.PaymentCollectingDate AS MaxPaymentCollectedDate " +

                    " from (" + strPayment + ") as PaymentTable inner join GLPayment " +
                    " on PaymentTable.MaxPaymentID = GLPayment.PaymentID " +
                    " inner join GLCheckPayment " +
                    " on GLPayment.PaymentID = GLCheckPayment.PaymentID  ";
                string strGLAccount = "SELECT  AccountID AS CheckGLAccountID, AccountCode AS CheckGLAccountCode, AccountNameA AS CheckGLAccountNameA " +
                        " FROM         dbo.GLAccount ";
                string strOutCheck = "SELECT GLCheckOut.CheckID as CheckOutID,dbo.GLBankAccount.AccountID AS CheckAccountID, dbo.GLBankAccount.AccountCode AS CheckAccountCode, " +
                      " dbo.GLBankAccount.AccountOwnerName AS CheckAccountOwnerName, dbo.GLBankAccount.AccountDesc AS CheckAccountDesc " +
                      " FROM  dbo.GLCheckOut INNER JOIN " +
                      " dbo.GLBankAccount ON dbo.GLCheckOut.CheckBankAccount = dbo.GLBankAccount.AccountID";
                string strLastPrint = "SELECT  PrintCheckID, MAX(PrintID) AS LastPrintID " +
                       " FROM         dbo.GLCheckPrint " +
                      " GROUP BY PrintCheckID";
                strLastPrint = "select PrintTable.* " +
                    " from (" + CheckPrintDb.SearchStr + ") as PrintTable " +
                    " inner join (" + strLastPrint + ") LastPrintTable " +
                    " on  PrintTable.PrintCheckID = LastPrintTable.PrintCheckID  " +
                    " and PrintTable.PrintID = LastPrintTable.LastPrintID " +
                    "";
                string strCollectingBank = "SELECT  BankID AS CollectingBankID" +
                    ",CASE WHEN " + SysData.Language + "=0 or BankNameE is null or  BankNameE='' THEN BankNameA ELSE BankNameE END AS CollectingBankName " +
                    " FROM            dbo.GLBank";
                string strCheckCustomer = "SELECT  CustomerID AS CheckCustomerID, CustomerFullName AS CheckCustomerName " +
                     " FROM            dbo.CRMCustomer ";
                string Returned = " SELECT GLCheck.CheckID,GLCheck.CheckDirection,CheckEditorName,CheckBeneficiaryName,CheckBank, CheckCode,CheckType, CheckValue," +
                    " CheckCurrency, CheckIssueDate, CheckDueDate, CheckPaymentDate," +
                    " CheckNote, AttachmentID,CheckCurrentStatus, CheckCurrentStatusDate, ChcekCurrentPlace,CheckCurrentStatusComment, CheckParentID" +
                    ",GLCheck.TransactionID as CheckTransactionID,CheckIsBankOriented,GLCheck.BankSubmissionDate  " +
                    " ,case when CheckPaymentTable.TotalPayment is null then 0 else CheckPaymentTable.TotalPayment end as TotalPayment" +
                    " ,case when CheckPaymentTable.CollectedPaymentValue is null then 0 else CheckPaymentTable.CollectedPaymentValue end as TotalCollectedPayment" +
                    ",CheckPaymentTable.MaxPaymentID,CheckPaymentTable.MaxPaymentValue,CheckPaymentTable.MaxPaymentIsCollected" +
                    ",CheckPaymentTable.MaxPaymentCollectedDate,CheckPaymentTable.MaxPaymentDesc " +
                    // ",CheckPaymentTable.CheckInstallmentCount,CheckPaymentTable.CheckReservationCount " +
                    ",CheckPaymentTable.CheckMaxInstallmentDueDate,CheckPaymentTable.CheckMinInstallmentDueDate" +
                    ",CheckPaymentTable.CheckInstallmentCount " +
                    " ,CheckPaymentTable.CheckReservationCount,CheckPaymentTable.TotalMonthCount,CheckPaymentTable.HasInstallment " +
                    ",CofferTable.*,CheckInTable.*,CheckOutTable.*,GLAccountTable.*  " +
                   ",PrintTable.* " +
                   ",CollectingBankTable.* " +
                   ",CustomerTable.* " +
                    " FROM    GLCheck left outer join (" + CheckInDb.SearchStr + ") as CheckInTable " +
                    " on GLCheck.CHeckID=CheckInTable.CheckInID " +
                    " left outer join (" + strOutCheck + ") as CheckOutTable on GLCheck.CheckID= CheckOutTable.CheckOutID " +
                    " left outer join (" + CofferDB.SearchStr + ") CofferTable on CofferTable.CofferID = ChcekCurrentPlace " +
                    " left outer join (" + strCollectingBank + ") as CollectingBankTable " +
                    " on GLCheck.CheckCollectingBank =  CollectingBankTable.CollectingBankID " +
                    " left outer join (" + strCheckCustomer + ") as CustomerTable " +
                    " ON dbo.GLCheck.CheckCustomer = CustomerTable.CheckCustomerID ";
                //  if (_HasPaymentStatus == 1 || _IsPaymentRange)
                Returned += " inner join ";
                // else
                //Returned += " left outer join  ";
                //Returned+=" (" + strPayment + ") as CheckPaymentTable " +
                Returned += "  dbo.GLCheckPaymentData as CheckPaymentTable" +
                   " on GLCheck.CheckID = CheckPaymentTable.CheckID  " +
                 " left outer join (" + strGLAccount +
                 ") as GLAccountTable on GLCheck.CheckGLAccount = GLAccountTable.CheckGLAccountID " +
                 " left outer join (" + strLastPrint + ") as PrintTable " +
                 " on GLCheck.CheckID = PrintTable.PrintCheckID ";
                if (ReservationPaymentStr != "")
                    Returned += " inner join (" + ReservationPaymentStr + ") as ReservationTable " +
                        " on GLCheck.CheckID = ReservationTable.CheckID ";
                if (_HasPaymentStatus != 1
                    && (_ReservationID != 0 ||
                    (_ReservationIDs != null && _ReservationIDs != "")
                    || _CellFamilyID != 0
                    || (_CellIDs != null && _CellIDs != "")
                    || (_ResubmissionID != 0)
                    ))
                {
                    string strReservationCustomer = @"SELECT distinct   dbo.CRMReservationCustomer.CustomerID
FROM            dbo.RPCell INNER JOIN
                         dbo.CRMUnitCell ON dbo.RPCell.CellID = dbo.CRMUnitCell.CellID INNER JOIN
                         dbo.CRMReservationUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMReservationUnit.UnitID INNER JOIN
                         dbo.CRMReservationCustomer ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservationCustomer.ReservationID ";


                    string strResubmission = "";
                    if (_ResubmissionID != 0)
                    {
                        strResubmission = @"SELECT        dbo.CRMReservationCustomer.CustomerID as ResubmissionCustomer
FROM            dbo.CRMReservationResubmission INNER JOIN
                         dbo.CRMReservationCustomer ON dbo.CRMReservationResubmission.ResubmissionReservation = dbo.CRMReservationCustomer.ReservationID
WHERE        (dbo.CRMReservationResubmission.ResubmissionType = " + _ResubmissionID + @") AND (dbo.CRMReservationResubmission.ResubmissionEndDate IS NULL OR
                         dbo.CRMReservationResubmission.ResubmissionEndDate > GETDATE())
						 union all
						 SELECT        ResubmissionCustomer  
FROM            dbo.CRMCustomerResubmission
WHERE        (ResubmissionType = " + _ResubmissionID + @") AND (ResubmissionEndDate IS NULL OR
                         ResubmissionEndDate > GETDATE())";
                        strReservationCustomer += " inner join (" + strResubmission + ") as ResubmissionTable  " +
                            " on dbo.CRMReservationCustomer.CustomerID = ResubmissionTable.ResubmissionCustomer ";
                    }
                    strReservationCustomer += "WHERE (1=1)  ";
                    //"(dbo.RPCell.CellFamilyID = 1)";
                    if (_CellIDs != null && _CellIDs != "")
                        strReservationCustomer += " and  (dbo.RPCell.CellID in (" + _CellIDs + ")) ";
                    if (_CellFamilyID != 0)
                        strReservationCustomer += " and  (dbo.RPCell.CellFamilyID =" + _CellFamilyID + ") ";
                    if (_ReservationID != 0)
                        strReservationCustomer += "  AND (dbo.CRMReservationCustomer.ReservationID = " + _ReservationID + ")";
                    if (_ReservationIDs != null && _ReservationIDs != "")
                        strReservationCustomer += "  AND (dbo.CRMReservationCustomer.ReservationID in (" + _ReservationIDs + "))";


                    Returned += " inner join (" + strReservationCustomer + ") as ReservationCustomerTable " +
                        " on GLCheck.CheckCustomer =  ReservationCustomerTable.CustomerID ";
                }
                if (_EditorName != null && _EditorName != "")
                {
                    string strEditorName = @"SELECT DISTINCT CheckID
FROM            dbo.GLCheck_IPersonCMP
WHERE        (CheckPerson  LIKE  dbo.ReplaceStringComp('" + _EditorName + @"') + '%')";
                    Returned += " inner join (" + strEditorName +
                        ") as EditorNameTable " +
                        " on GLCheck.CheckID = EditorNameTable.CheckID ";
                }

                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {


                string Returned = SearchStr + " WHERE  (Dis is null)";

                if (_ID != 0)
                    Returned = Returned + " and GLCheck.CheckID = " + _ID.ToString();
                if (_HasPaymentStatus == 1)
                    Returned += " and CheckPaymentTable.TotalPayment> 0  ";
                if (_HasPaymentStatus == 2)
                    Returned += " and isnull(CheckPaymentTable.TotalPayment,0) = 0  ";
                int intDirection = _Direction ? 1 : 0;
                Returned += " and GLCheck.CheckDirection = " + intDirection;
                if (_IDs != null && _IDs != "")
                    Returned += " and GLCheck.CheckID in (" + _IDs + ")";
                if (_Code != null && _Code != "")
                    Returned += " and CheckCode ='" + _Code + "' ";
                if (_CheckNote != null && _CheckNote != "")
                    Returned += " and CheckNote like '%" + _CheckNote + "% ";
                if (_Bank != 0)
                    Returned += " and CheckBank = " + _Bank;
                if (_Currency != 0)
                    Returned += " and CheckCurrency =" + _Currency;
                if (_CustomerID != 0)
                    Returned += " and GLCheck.CheckCustomer  =  " + _CustomerID;
                if (_Place != 0 && !_MaxStatusDateLimited)
                {
                    Returned += " and ChcekCurrentPlace=" + _Place + " and CheckCurrentStatus not in (2,4,5) ";
                }
                if (_PlaceIDs != null && _PlaceIDs != "" && !_MaxStatusDateLimited)
                {
                    Returned += " and ChcekCurrentPlace in (" + _PlaceIDs + ") and CheckCurrentStatus not in (2,4,5) ";
                }
                if (_AccountID != 0)
                {
                    Returned += " and CheckAccountID=" + _AccountID;
                }
                if (_StatusValue)
                {
                    Returned += " and CheckValue >= " + _FromCheckValue + " and CheckValue <= " + _ToCheckValue + "";
                }
                if (_OldPlace != 0)
                    Returned += " and (CheckCurrentOldPlace=" + _OldPlace + " or (ChcekCurrentPlace=" + _OldPlace + "  and CheckCurrentStatus in (4,5) ) )";
                double dblStart, dblEnd;
                if (_IsDueRange)
                {
                    dblStart = _StartDueDate.ToOADate() - 2;
                    dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                    dblEnd = _EndDueDate.ToOADate() - 2;
                    //dblEnd += 1;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                    Returned += " and CheckDueDate >=" + dblStart +
                        " and CheckDueDate < " + dblEnd;
                }
                if (_IsIssueRange)
                {
                    dblStart = _StartIssueDate.ToOADate() - 2;
                    dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                    dblEnd = _EndIssueDate.ToOADate() - 2;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);

                    Returned += " and CheckIssueDate >=" + dblStart +
                        " and CheckIssueDate < " + dblEnd;

                }
                if (_IsStatusDateRange && !_MaxStatusDateLimited)
                {
                    dblStart = _StartStatusDate.ToOADate() - 2;
                    dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                    dblEnd = _EndStatusDate.ToOADate() - 2;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);

                    Returned += " and CheckCurrentStatusDate >=" + dblStart +
                        " and CheckCurrentStatusDate < " + dblEnd;
                }
                if (_IsSubmissionRange)
                {
                    dblStart = SysUtility.Approximate(_StartSubmissionDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEnd = SysUtility.Approximate(_EndSubmissionDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += "  and BankSubmissionDate >=" + dblStart + " and  BankSubmissionDate <" + dblEnd;
                }
                if (_IsPaymentRange)
                {
                    dblStart = (int)_StartPaymentDate.ToOADate() - 2;
                    dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                    dblEnd = _EndPaymentDate.ToOADate() - 2;
                    //dblEnd += 1;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                    Returned += " and MaxCollectedPaymentDate >=" + dblStart +
                        " and MaxCollectedPaymentDate < " + dblEnd;
                }
                if (_BankOrientedStatus != 0)
                {
                    if (_BankOrientedStatus == 1)
                    {
                        Returned += " and CheckIsBankOriented=1 ";
                    }
                    else
                        Returned += " and CheckIsBankOriented=0 ";
                }
                if (_PaymentStatus > 0)
                {
                    if (_PaymentStatus == 1)
                        Returned += " and ChackPaymentDate is null ";
                    else if (_PaymentStatus == 2)
                        Returned += " and CheckpaymentDate is not null ";
                }
                if (_Status != 0 && !_MaxStatusDateLimited)
                {
                    if (_Status == 1)
                        Returned = Returned + " and (CheckCurrentStatus =1 and  TotalPayment > CollectedPaymentValue )";
                    else if (_Status == 6)//not Paid
                    {
                        Returned = Returned + " and (CheckCurrentStatus <>2 and  TotalPayment > CollectedPaymentValue )";
                    }
                    else if (_Status == 7) //Paid
                    {
                        Returned = Returned + " and (CheckCurrentStatus =2 or (TotalPayment >0 and  TotalPayment <= CollectedPaymentValue ))";
                    }
                    else if (_Status == 8)//Partially Paid and not Reclalimed
                    {
                        Returned = Returned + " and (CheckCurrentStatus <>4 and  TotalPayment >0 and  TotalPayment <= CollectedPaymentValue )";
                    }
                    else if (_Status == 9) // not paid at all
                        Returned += " and  (CheckCurrentStatus <>2 and TotalPayment >0 and   CollectedPaymentValue = 0 ) ";
                    else if (_Status == 10) // Paid just part
                        Returned += " and (CheckCurrentStatus <>2 and  TotalPayment > CollectedPaymentValue and CollectedPaymentValue >0 ) ";
                    else
                        Returned += " and  CheckCurrentStatus = " + _Status + " ";
                }

                //strSql += " and ChcekCurrentPlace = " + _Place + " ";
                if (_EditorName != null && _EditorName != "")
                {
                    //string strEditorName = _EditorName.Replace(' ', '%');
                    //Returned += " and (dbo.ReplaceStringComp(CheckEditorName) like '%" +
                    //    SysUtility.ReplaceStringComp(strEditorName) +
                    //    "%' or  dbo.ReplaceStringComp(CheckBeneficiaryName) like '%" + SysUtility.ReplaceStringComp(strEditorName) + "%'  ) ";
                }
                if (_MultipleInstallmentStatus == 1)
                    Returned += " and CheckPaymentTable.CheckInstallmentCount  > 1 ";
                if (_MultipleInstallmentStatus == 2)
                    Returned += " and CheckPaymentTable.CheckInstallmentCount  = 1 ";
                if (_MultipleReservationStatus == 1)
                    Returned += " and CheckPaymentTable.CheckReservationCount >1 ";
                if (_StatusStr != null && _StatusStr != "" && _StatusStr != "0" && !_MaxStatusDateLimited)
                {
                    if (_StatusStr == "2")
                    {
                        Returned = Returned + " and (CheckCurrentStatus =2 or CheckValue <= CollectedPaymentValue )";
                    }
                    else
                        Returned = Returned + " and CheckCurrentStatus in(" + _StatusStr + ") ";
                }
                if (_Type != 0)
                {
                    Returned += " and CheckType =" + _Type;
                }
                if (_CollectingPaymentStatus != 0)
                {
                    if (_CollectingPaymentStatus == 1)
                    {
                        Returned += " and GLCheck.CheckID in (SELECT     GLCheck.CheckID " +
                              " FROM  GlCheck left outer join dbo.GLCheckPayment on " +
                              " GLCheck.CheckID = GLCheckPayment.CheckID " +
                              " WHERE  (GLCheckPayment.CheckID is null) or (PaymentIsCollected = 0))";
                    }
                    else if (_CollectingPaymentStatus == 2)
                    {
                        Returned += " and GLCheck.CheckID not in (SELECT  CheckID " +
                                                " FROM   dbo.GLCheckPayment " +
                                                " WHERE  (PaymentIsCollected = 0))";
                    }
                    else if (_CollectingPaymentStatus == 3)
                    {
                        Returned += " and CollectedPaymentValue is not null and CollectedPaymentValue > 0 " +
                            "  and TotalPayment > CollectedPaymentValue  ";
                    }
                    else if (_CollectingPaymentStatus == 4)
                    {
                        Returned += " and TotalPayment <= CollectedPaymentValue ";

                    }
                }


                string strCheckPayment = "SELECT     dbo.GLCheckPayment.CheckID, SUM(dbo.GLPayment.PaymentValue) AS TotalPayment " +
                          " FROM    dbo.GLCheckPayment INNER JOIN " +
                          " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID " +
                          " GROUP BY dbo.GLCheckPayment.CheckID ";
                if (_SharedPaymentStatus != 0)
                {

                    if (_SharedPaymentStatus == 1)
                    {
                        Returned += " and CheckID not in (SELECT CheckID FROM  dbo.GLCheckPayment)";
                    }
                    else if (_SharedPaymentStatus == 2)
                    {
                        Returned = "select CheckTable.* from (" + Returned +
                            ") CheckTable inner join (" + strCheckPayment + ") as CheckPaymentTable " +
                            " on  CheckTable.CheckID = CheckPaymentTable.CheckID  " +
                            " and CheckTable.CheckValue = CheckPaymentTable.TotalPayment ";
                    }
                }


                if (_MaxStatusDateLimited)
                {
                    dblEnd = _MaxStatusDate.ToOADate() - 2;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                    string strHistory = "SELECT   ChcekID  " +
                        ",Max(HistoryID) as MaxHistoryID " +
                   " FROM         dbo.GLChcekHistory " +
                   " WHERE     (CheckStatusDate <" + dblEnd + ")";


                    strHistory += " GROUP BY ChcekID";
                    strHistory = "SELECT     dbo.GLChcekHistory.ChcekID AS HistoricalCheckID, dbo.GLChcekHistory.CheckStatus as HistoryCheckStatus" +
                        ", dbo.GLChcekHistory.CheckStatusDate as HistoryCheckStatusDate, " +
                      " dbo.GLChcekHistory.ChcekPlace  HistoryCheckPlace " +
                      " FROM   dbo.GLChcekHistory inner join (" + strHistory +
                      ") MaxHistoryTable on  GLChcekHistory.ChcekID = MaxHistoryTable.ChcekID  " +
                      " and  GLChcekHistory.HistoryID = MaxHistoryTable.MaxHistoryID ";
                    if (_Place != 0)
                        strHistory += " and (GLChcekHistory.ChcekPlace=" + _Place + ") and GLChcekHistory.ChcekPlace not in (2,4,5)";
                    if (_Status != 0)
                        strHistory += " and (GLChcekHistory.CheckStatus=" + _Status + ") ";
                    Returned = "select CheckMainTable.*,CheckHistoryTable.* from " +
                        "(" + Returned + ") CheckMainTable inner join (" + strHistory + ") as CheckHistoryTable on CheckHistoryTable.HistoricalCheckID = CheckMainTable.CheckID ";
                }
                if (_PersonID != 0)
                {
                    Returned += " and CheckPerson =" + _PersonID;


                }
                if (_PersonType != 0)
                    Returned += " and CheckPersonType =" + _PersonType;
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["CheckID"] != null && objDR["CheckID"].ToString() != "")
                _ID = int.Parse(objDR["CheckID"].ToString());
            if (objDR.Table.Columns["CheckBank"] != null &&
                objDR["CheckBank"].ToString() != "")
                _Bank = int.Parse(objDR["CheckBank"].ToString());
            if (objDR.Table.Columns["CheckCode"] != null && objDR["CheckCode"].ToString() != "")
                _Code = objDR["CheckCode"].ToString();
            if (objDR.Table.Columns["CheckNote"] != null)
                _CheckNote = objDR["CheckNote"].ToString();
            if (objDR.Table.Columns["CheckEditorName"] != null)
                _EditorName = objDR["CheckEditorName"].ToString();
            if (objDR.Table.Columns["CheckBeneficiaryName"] != null)
                _BeneficialName = objDR["CheckBeneficiaryName"].ToString();
            if (objDR.Table.Columns["AttachmentID"] != null && objDR["AttachmentID"].ToString() != "")
                _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            if (objDR.Table.Columns["CheckCurrency"] != null)
                _Currency = int.Parse(objDR["CheckCurrency"].ToString());
            if (objDR.Table.Columns["CheckValue"] != null)
                _Value = double.Parse(objDR["CheckValue"].ToString());
            if (objDR.Table.Columns["CheckType"] != null)
                _Type = int.Parse(objDR["CheckType"].ToString());

            if (objDR.Table.Columns["CheckDueDate"] != null && objDR["CheckDueDate"].ToString() != "")
                _DueDate = DateTime.Parse(objDR["CheckDueDate"].ToString());
            if (objDR.Table.Columns["CheckIssueDate"] != null && objDR["CheckIssueDate"].ToString() != "")
                _IssueDate = DateTime.Parse(objDR["CheckIssueDate"].ToString());
            if (objDR.Table.Columns["TotalPayment"] != null)
                _TotalPayment = double.Parse(objDR["TotalPayment"].ToString());
            if (objDR.Table.Columns["TotalCollectedPayment"] != null && objDR["TotalCollectedPayment"].ToString() != "")
                _CollectedValue = double.Parse(objDR["TotalCollectedPayment"].ToString());
            if (objDR.Table.Columns["CheckCurrentStatus"] != null && objDR["CheckCurrentStatus"].ToString() != "")
                _Status = int.Parse(objDR["CheckCurrentStatus"].ToString());
            if (objDR.Table.Columns["CheckCurrentStatusDate"] != null && objDR["CheckCurrentStatusDate"].ToString() != "")
                _StatusDate = DateTime.Parse(objDR["CheckCurrentStatusDate"].ToString());
            if (objDR.Table.Columns["CheckTransactionID"] != null)
                _TransactionID = int.Parse(objDR["CheckTransactionID"].ToString());
            if (objDR.Table.Columns["CheckIsBankOriented"] != null)
                _IsBankOriented = bool.Parse(objDR["CheckIsBankOriented"].ToString());
            if (objDR.Table.Columns["MaxPaymentDesc"] != null)
                _MaxPaymentDesc = objDR["MaxPaymentDesc"].ToString();
            if (objDR.Table.Columns["CheckAccountID"] != null && objDR["CheckAccountID"].ToString() != "")
            {
                _AccountID = int.Parse(objDR["CheckAccountID"].ToString());
                _AccountCode = objDR["CheckAccountCode"].ToString();
                _AccountOwner = objDR["CheckAccountOwnerName"].ToString();
                _AccountDesc = objDR["CheckAccountDesc"].ToString();
            }
            if (objDR.Table.Columns["CheckGLAccountID"] != null && objDR["CheckGLAccountID"].ToString() != "")
            {
                _GLAccountID = int.Parse(objDR["CheckGLAccountID"].ToString());
                _GLAccountCode = objDR["CheckGLAccountCode"].ToString();
                _GLAccountName = objDR["CheckGLAccountNameA"].ToString();
            }

            if (objDR.Table.Columns["ChcekCurrentPlace"] != null && objDR["ChcekCurrentPlace"].ToString() != "")
            {

                _Place = int.Parse(objDR["ChcekCurrentPlace"].ToString());
                _OldPlace = _Place;
            }
            if (objDR.Table.Columns["CheckParentID"] != null && objDR["CheckParentID"].ToString() != "")
            {
                _ParentID = int.Parse(objDR["CheckParentID"].ToString());
            }
            else
            {
                _ParentID = 0;
            }

            if (objDR.Table.Columns["CheckPaymentDate"] != null && objDR["CheckPaymentDate"].ToString() != "")
            {
                _IsPaid = true;
                _PaymentDate = DateTime.Parse(objDR["CheckPaymentDate"].ToString());
            }
            else
                _IsPaid = false;
            _IsSubmitted = false;
            if (objDR.Table.Columns["BankSubmissionDate"] != null && objDR["BankSubmissionDate"].ToString() != "")
            {
                _IsSubmitted = true;
                _SubmissionDate = DateTime.Parse(objDR["BankSubmissionDate"].ToString());
            }
            if (objDR.Table.Columns["CheckDirection"] != null)
                _Direction = bool.Parse(objDR["CheckDirection"].ToString());
            if (objDR.Table.Columns["PrintID"] != null && objDR["PrintID"].ToString() != "")
                _LastPrintID = int.Parse(objDR["PrintID"].ToString());
            _StatusComment = objDR["CheckCurrentStatusComment"].ToString();
            if (objDR.Table.Columns["CollectingBankID"] != null && objDR["CollectingBankID"].ToString() != "")
            {
                int.TryParse(objDR["CollectingBankID"].ToString(), out _CollectingBank);
                _CollectingBankName = objDR["CollectingBankName"].ToString();
            }
            else if (objDR.Table.Columns["CheckCollectingBank"] != null && objDR["CheckCollectingBank"].ToString() != "")
            {
                int.TryParse(objDR["CheckCollectingBank"].ToString(), out _CollectingBank);
                // _CollectingBankName = objDR["CollectingBankName"].ToString();
            }
            if (objDR.Table.Columns["CheckCustomerID"] != null)
            {
                int.TryParse(objDR["CheckCustomerID"].ToString(), out _CustomerID);
                _CustomerName = objDR["CheckCustomerName"].ToString();
            }

            if (objDR.Table.Columns["CheckMaxInstallmentDueDate"] != null)
                DateTime.TryParse(objDR["CheckMaxInstallmentDueDate"].ToString(), out _MaxInstallmentDueDate);
            if (objDR.Table.Columns["CheckMinInstallmentDueDate"] != null)
                DateTime.TryParse(objDR["CheckMinInstallmentDueDate"].ToString(), out _MinInstallmentDueDate);
            if (objDR.Table.Columns["CheckInstallmentCount"] != null)
                int.TryParse(objDR["CheckInstallmentCount"].ToString(), out _CheckInstallmentCount);
            if (objDR.Table.Columns["CheckReservationCount"] != null)
                int.TryParse(objDR["CheckReservationCount"].ToString(), out _CheckReservationCount);
            if (objDR.Table.Columns["TotalMonthCount"] != null)
                int.TryParse(objDR["TotalMonthCount"].ToString(), out _TotalMonthCount);
            if (objDR.Table.Columns["HasInstallment"] != null)
                int.TryParse(objDR["HasInstallment"].ToString(), out _HasInstallment);

        }
        #endregion

        #region Public Methods
        public virtual void Add()
        {
            if (_StatusDate == null || _StatusDate < DateTime.Now.Date)
                _StatusDate = DateTime.Now;
            double dblIssueDate = _IssueDate.ToOADate() - 2;
            double dblDueDate = _DueDate.ToOADate() - 2;
            double dblPaymentDate = _PaymentDate.ToOADate() - 2;
            double dblStatusDate =
                PaymentDb.UMSChangePaymentDateAuthorised ? (_StatusDate.ToOADate() - 2) : (DateTime.Now.ToOADate() - 2);

            _SubmissionDate = !_IsSubmitted ? _StatusDate : _SubmissionDate;
            string strSubmissionDate = _Status == 5 || _IsSubmitted ? (_SubmissionDate.ToOADate() - 2).ToString() : "null";

            string strPaymentDate = "null";
            int intDirection = _Direction ? 1 : 0;
            int intIsBankOriented = _IsBankOriented ? 1 : 0;
            if (_IsPaid)
                strPaymentDate = dblPaymentDate.ToString();

            string strSql = " INSERT INTO GLCheck" +
                            " (CheckDirection,CheckEditorName,CheckBeneficiaryName,CheckBank, CheckCode,CheckType, CheckValue, " +
                            "CheckCurrency, CheckIssueDate, CheckDueDate, CheckPaymentDate, CheckNote, CheckCurrentStatus, CheckCurrentStatusDate," +
                            " ChcekCurrentPlace, CheckCurrentStatusComment, CheckCollectingBank, CheckParentID, AttachmentID,TransactionID," +
                            "CheckIsBankOriented,BankSubmissionDate,CheckGLAccount,CheckCustomer,UsrIns,TimIns)" +
                            " VALUES     (" + intDirection + ",'" + _EditorName + "','" + _BeneficialName + "'," + _Bank + ",'" + _Code + "'," + _Type +
                            "," + _Value + "," + _Currency + "," + dblIssueDate + "," + dblDueDate + "," + strPaymentDate + ",'" +
                            _CheckNote + "'," + _Status + "," + dblStatusDate + "," + _Place + ",'" + _StatusComment + "'," + _CollectingBank + "," + _ParentID + "," +
                            _AttachmentID + "," + _TransactionID + "," + intIsBankOriented + "," +
                            strSubmissionDate + "," + _GLAccountID + "," + _CustomerID + "," +
                            SysData.CurrentUser.ID + ",GetDate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            string strOut = "";
            if (!_Direction && _AccountID != 0)
            {
                strOut = "insert into GLCheckOut (CheckID,CheckBankAccount) values(" + _ID + "," + _AccountID + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strOut);
            }
            InsertStatusHistory();



        }
        public virtual void Edit()
        {
            double dblIssueDate = _IssueDate.ToOADate() - 2;
            double dblDueDate = _DueDate.ToOADate() - 2;
            double dblPaymentDate = _PaymentDate.ToOADate() - 2;
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            //double dblStatusDate =
            //  PaymentDb.UMSChangePaymentDateAuthorised ? (_StatusDate.ToOADate() - 2) : (DateTime.Now.ToOADate() - 2);
            int intBankOriented = _IsBankOriented ? 1 : 0;
            _SubmissionDate = !_IsSubmitted ? _StatusDate : _SubmissionDate;
            string strSubmissionDate = _Status == 5 || _IsSubmitted ? (_SubmissionDate.ToOADate() - 2).ToString() : "null";
            string strPaymentDate = "null";
            if (_IsPaid)
                strPaymentDate = dblPaymentDate.ToString();
            string strOldPlace = ",CheckCurrentOldPlace=Case when ChcekCurrentPlace=" + _Place +
            " then CheckCurrentOldPlace else ChcekCurrentPlace end ";
            string strSql = " UPDATE    GLCheck" +
                            " SET  CheckEditorName ='" + _EditorName + "'" +
                            ",CheckBeneficiaryName='" + _BeneficialName + "'" +
                            ",CheckBank =" + _Bank +
                            " , CheckCode ='" + _Code + "'" +
                            " , CheckType =" + _Type + "" +
                            " , CheckValue =" + _Value + "" +
                            " , CheckCurrency =" + _Currency + "" +
                            " , CheckIssueDate =" + dblIssueDate + "" +
                            " , CheckDueDate =" + dblDueDate + "" +
                            " , CheckPaymentDate =" + strPaymentDate + "" +
                            " , CheckNote ='" + _CheckNote + "'" +
                            " , CheckCurrentStatus=" + _Status + "" +
                            " , CheckCurrentStatusDate=" + dblStatusDate + "" +
                            " , ChcekCurrentPlace =" + _Place + strOldPlace +
                            ",CheckCurrentStatusComment='" + _StatusComment + "'" +
                              ",CheckCollectingBank=" + _CollectingBank +
                            " , CheckParentID=" + _ParentID + "" +
                            ", AttachmentID = " + _AttachmentID + "" +
                            ", TransactionID= " + _TransactionID + "" +
                            ",CheckIsBankOriented=" + intBankOriented +
                            ",BankSubmissionDate=" + strSubmissionDate + " " +
                            ",CheckGLAccount=" + _GLAccountID +

                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=Getdate() " +
                            " Where CheckID = " + _ID + "";

            strSql += " delete from GLCheckOut where CheckID=" + _ID;
            if (!_Direction && _AccountID != 0)
            {
                strSql += " insert into GLCheckOut (CheckID,CheckBankAccount) values(" + _ID + "," + _AccountID + ")";
                // SysData.SharpVisionBaseDb.ExecuteNonQuery(strOut);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertStatusHistory();


        }
        public void SetCheckIsbankOriented()
        {
            if (_IDs == null || _IDs == "")
                return;
            int intBankOriented = _IsBankOriented ? 1 : 0;
            string strSql = " UPDATE    GLCheck set CheckIsBankOriented =  " + intBankOriented +
                " where CheckID in (" + _IDs + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void InsertStatusHistory()
        {
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            dblStatusDate = SysUtility.Approximate(dblStatusDate, 1, ApproximateType.Down);
            string strSql = "INSERT INTO GLChcekHistory" +
                           " (ChcekID, CheckStatus, CheckStatusDate, ChcekPlace, " +
                           "CheckCurrentStatusComment, CheckCollectingBank, UsrIns, TimIns)" +
                           " VALUES     (" + _ID + "," + _Status + "," + dblStatusDate + "," + _Place +
                           ",'" + _StatusComment + "'," + _CollectingBank + "," + SysData.CurrentUser.ID + ",GetDate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void InsertStatusHistoryForMultiple()
        {
            if (_IDs == null || _IDs == "")
                return;
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            dblStatusDate = SysUtility.Approximate(dblStatusDate, 1, ApproximateType.Down);
            string strSql = "INSERT INTO GLChcekHistory" +
                           " (ChcekID, CheckStatus, CheckStatusDate, ChcekPlace,CheckCurrentStatusComment" +
                           ", CheckCollectingBank, UsrIns, TimIns)" +
                           " select CheckID,CheckCurrentStatus as CheckStatus," + dblStatusDate + " as StatusDate" +
                           "," + _Place + " as CheckPlace,'" + _StatusComment + "'," + _CollectingBank +
                           "," + SysData.CurrentUser.ID + " as CurrentUser " +
                           ",GetDate() as StatusDate from GLCheck where CheckID in (" + _IDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStatus()
        {
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            _SubmissionDate = !_IsSubmitted ? _StatusDate : _SubmissionDate;
            string strSubmissionDate = _Status == 5 || _IsSubmitted ? (_SubmissionDate.ToOADate() - 2).ToString() : "null";
            string strSql = " UPDATE    GLCheck" +
                            " SET  CheckCurrentStatus =" + _Status + "" +
                            " ,CheckCurrentStatusDate =" + dblStatusDate + "" +

                            ",BankSubmissionDate= " + strSubmissionDate + " " +
                            " WHERE     (CheckID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertStatusHistory();
        }
        public void EditStatusForMultiple()
        {
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            _SubmissionDate = !_IsSubmitted ? _StatusDate : _SubmissionDate;
            string strSubmissionDate = _Status == 5 || _IsSubmitted ? (_SubmissionDate.ToOADate() - 2).ToString() : "null";
            string strSql = " UPDATE    GLCheck" +
                            " SET  CheckCurrentStatus =" + _Status + "" +
                            " ,CheckCurrentStatusDate =" + dblStatusDate + "" +
                            ",BankSubmissionDate= " + strSubmissionDate + " " +
                            ",CheckCurrentStatusComment='" + _StatusComment + "'" +
                            ",CheckCollectingBank=" + _CollectingBank +
                            " WHERE     (CheckID in (" + _IDs + ")) ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertStatusHistory();
        }
        public void EditCurrentPlace()
        {
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            string strOldPlace = ",CheckCurrentOldPlace=Case when ChcekCurrentPlace=" + _Place +
             " then CheckCurrentOldPlace else ChcekCurrentPlace end ";
            dblStatusDate = SysUtility.Approximate(dblStatusDate, 1, ApproximateType.Down);
            string strSql = " UPDATE    GLCheck" +
                            " SET  ChcekCurrentPlace =" + _Place + "" +
                            strOldPlace +
                            " ,CheckCurrentStatusDate =" + dblStatusDate + "" +
                            " WHERE     (CheckID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertStatusHistory();
        }
        public void EditCurrentPlaceForMultiple()
        {
            if (_IDs == null || _IDs == "")
                return;
            string strOldPlace = ",CheckCurrentOldPlace=Case when ChcekCurrentPlace=" + _Place +
               " then CheckCurrentOldPlace else ChcekCurrentPlace end ";
            double dblStatusDate = _StatusDate.ToOADate() - 2;
            dblStatusDate = SysUtility.Approximate(dblStatusDate, 1, ApproximateType.Down);
            string strSql = " UPDATE    GLCheck" +
                            " SET  ChcekCurrentPlace =" + _Place + "" +
                            strOldPlace +
                            " ,CheckCurrentStatusDate =" + dblStatusDate + "" +
                            " WHERE     (CheckID in (" + _IDs + ")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertStatusHistoryForMultiple();
        }
        public virtual void Delete()
        {
            string strSql = " DELETE FROM GLCheck WHERE     (CheckID = " + _ID + ") " +
                " and not Exists (select CheckID from GLCheckPayment inner join GLPayment " +
                " on GLPayment.PaymentID = GLCheckPayment.PaymentID " +
                " where CheckID = " + _ID + " )";
            strSql += " delete from GLCheckOut where CheckID=" + _ID +
                " and not exists (select CheckID  from GLCheck where CheckID = " + _ID + ") ";
            strSql += "update GLCheck set Dis = GetDate() where CheckID =" + _ID +
                " and not exists (SELECT     dbo.GLPayment.PaymentSourceID, dbo.GLPayment.PaymentReverseID, dbo.GLCheckPayment.CheckID " +
                " FROM  dbo.GLPayment INNER JOIN " +
                " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID " +
                " WHERE  (dbo.GLCheckPayment.CheckID = " + _ID + ") AND (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0)) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual DataTable Search()
        {
            string strSql = StrSearch;
            DataTable dtTemp;

            if (_MaxID == 0 && _MinID == 0)
            {
                string strCountSql = "select count(*) as ResultCount,sum(CheckValue) as ResultValue from (" + strSql + ")  AS NativeTable ";
                dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                if (dtTemp.Rows.Count > 0)
                {
                    DataRow objDr = dtTemp.Rows[0];
                    if (objDr["ResultCount"].ToString() != "")
                        _ResultCount = int.Parse(objDr["ResultCount"].ToString());//(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
                    if (objDr["ResultValue"].ToString() != "")
                        _ResultValue = double.Parse(objDr["ResultValue"].ToString());
                }
            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and GLCheck.CheckID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and GLCheck.CheckID<" + _MinID;
                }
            }
            if (_MaxID == 0 && _MinID == 0 && _ResultCount <= 20000)
            {
            }
            else
                strSql = "select  top 20000 * from (" + strSql + ") as NativeTable order by CheckID ";

            _CheckIDTableStr = "select CheckID from (" + strSql + ") as Checktable1";
            _CachePaymentTable = null;

            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            //DataTable dtTempID = new DataTable();
            //dtTempID.Columns.AddRange(new DataColumn[]
            //{ new DataColumn("UserID"), new DataColumn("ID") });
            //DataRow objTempDr;
            //foreach (DataRow objDr in Returned.Rows)
            //{
            //    objTempDr = dtTempID.NewRow();
            //    objTempDr["UserID"] = SysData.CurrentUser.ID;
            //    objTempDr["ID"] = objDr["CheckID"];

            //    dtTempID.Rows.Add(objTempDr);

            //}
            //strSql = "delete from COMMONTempUserID where UserID =" +SysData.CurrentUser.ID.ToString();
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            //objCopy.DestinationTableName = "COMMONTempUserID";
            //objCopy.WriteToServer(dtTempID);

            //_CheckIDTable = "select ID as CheckID from COMMONTempUserID where UserID="+SysData.CurrentUser.ID.ToString();


            return Returned;
        }
        public void Print()
        {
            if (_IDs == null || _IDs == "")
                return;
            string strSql = "SELECT  CheckID, " + _PrintModelID + " AS CheckModel, GETDATE() AS PrintDate" +
                ", " + _PrintEmployeeID + " AS Employee, 1 AS PrintStatus " +
                "," + SysData.CurrentUser.ID + " AS UsrIns, GETDATE() AS TimIns " +
                " FROM         dbo.GLCheck " +
                " WHERE  (CheckID IN (" + _IDs + ")) ";
            strSql = " insert into GLCheckPrint (PrintCheckID, PrintCheckModel, PrintDate, PrintEmployee, PrintStatus, UsrIns, TimIns) " +
                "   " + strSql;


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void SetCheckIDTableStr()
        {
            if (_CheckIDTable == null || _CheckIDTable.Rows.Count == 0)
                return;

            string strSql = "delete from COMMONTempUserID where UserID =" + SysData.CurrentUser.ID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "COMMONTempUserID";
            objCopy.WriteToServer(_CheckIDTable);

            _CheckIDTableStr = "select ID as CheckID from COMMONTempUserID where UserID=" + SysData.CurrentUser.ID.ToString();
        }

        #endregion
    }
}
