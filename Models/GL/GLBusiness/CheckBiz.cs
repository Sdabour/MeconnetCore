using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public enum CheckStatus
    {
        NotSpecified, //0 غير محدد
        Postponeded,//مؤجل امامستحق او لم ياتى تاريخ استحقاقه1
        Collected,//محصل من البنك2
        Rejected,//مرفوض3
        Reclaimed,//4مسترد
        Submitted,//مقدم بالبنك 5
        NotPaid,//6 غير مسدد
        Paid,//7 مسدد
        PartiallyPaidNotReclaimed,//8 مسدد جزئيا وغير مسترد
        CompletelyNotPaid,//9
        PartIsPaid//10
        , Canceled//11
            , Required//12


    }

    public enum CheckPlace
    {
        NotSpecified, // غير محدد
        Bank, // مكان الشيك هو الخزينة
        Coffer // مكان الشيك هو البنك
    }
    public enum CheckType
    {
        NotSpecified,//غير محدد
        Check,//شيك بنكى
        TrustReceipt,// ايصال امانة
        Promissory//كمبيالة
    }
    public class CheckBiz
    {
        #region Private Data
        protected CheckDb _CheckDb;
        protected BankBiz _Bank;
        protected CurrencyBiz _Currency;
        protected AttachmentFileBiz _Attachment;
        protected string _Path;
        protected PaymentCol _PaymentCol;
        //protected CheckPaymentCol _PaymentCol;
        CofferBiz _PlaceBiz;
        AccountBankBiz _AccountBiz;//Is To be Used in case of out Checks
        AccountBiz _GLAccountBiz;
        #endregion

        #region Constructors
        public CheckBiz()
        {
            _CheckDb = new CheckDb();

        }
        public CheckBiz(int intID, string strStatus, bool blDirection)
        {
            // _CheckDb = new CheckDb(intID);
            if (intID == 0)
            {
                _CheckDb = new CheckDb();
                return;
            }

            CheckDb objDb = new CheckDb();
            objDb.ID = intID;
            objDb.StatusStr = strStatus;
            objDb.Direction = blDirection;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _CheckDb = new CheckDb(objDR);
                _Bank = new BankBiz(_CheckDb.Bank);
                _Currency = new CurrencyBiz(_CheckDb.Currency);
                if (_CheckDb.Place != 0)
                    _PlaceBiz = new CofferBiz(objDR);
                _AccountBiz = new AccountBankBiz();
                _CollectingBankBiz = new BankBiz();

                if (_CheckDb.CollectingBank != 0)
                {
                    _CollectingBankBiz.ID = _CheckDb.CollectingBank;
                    _CollectingBankBiz.NameA = _CheckDb.CollectingBankName;
                    _CollectingBankBiz.NameE = _CheckDb.CollectingBankName;
                }
                if (_CheckDb.AccountID != 0)
                {
                    _AccountBiz.ID = _CheckDb.AccountID;
                    _AccountBiz.Code = _CheckDb.AccountCode;
                    _AccountBiz.OwnerName = _CheckDb.AccountOwner;
                    _AccountBiz.Desc = _CheckDb.AccountDesc;

                }
                if (_CheckDb.GLAccountID != 0)
                {
                    _GLAccountBiz = new AccountBiz();
                    _GLAccountBiz.Code = _CheckDb.GLAccountCode;
                    _GLAccountBiz.NameA = _CheckDb.GLAccountName;
                }

            }
            else
            {
                _PlaceBiz = new CofferBiz();
                _CheckDb = new CheckDb();
            }
        }
        public CheckBiz(DataRow objDR)
        {
            _CheckDb = new CheckDb(objDR);
            if (BankCol.BankHS[_CheckDb.Bank.ToString()] != null)
                _Bank = (BankBiz)BankCol.BankHS[_CheckDb.Bank.ToString()];
            _Currency = new CurrencyBiz(_CheckDb.Currency);
            if (_CheckDb.Place != 0)
                _PlaceBiz = new CofferBiz(objDR);
            _AccountBiz = new AccountBankBiz();
            if (_CheckDb.AccountID != 0)
            {
                _AccountBiz.ID = _CheckDb.AccountID;
                _AccountBiz.Code = _CheckDb.AccountCode;
                _AccountBiz.OwnerName = _CheckDb.AccountOwner;
                _AccountBiz.Desc = _CheckDb.AccountDesc;

            }
            if (_CheckDb.CollectingBank != 0)
            {
                if (BankCol.BankHS[_CheckDb.CollectingBank.ToString()] != null)
                    _CollectingBankBiz = (BankBiz)BankCol.BankHS[_CheckDb.CollectingBank.ToString()];
            }
            //   _CollectingBankBiz = new BankBiz(_CheckDb.CollectingBank);
            //if (_CheckDb.CollectingBank != 0)
            //{
            //    _CollectingBankBiz.ID = _CheckDb.CollectingBank;
            //    _CollectingBankBiz.NameA = _CheckDb.CollectingBankName;
            //    _CollectingBankBiz.NameE = _CheckDb.CollectingBankName;
            //}
            if (_CheckDb.GLAccountID != 0)
            {
                _GLAccountBiz = new AccountBiz();
                _GLAccountBiz.Code = _CheckDb.GLAccountCode;
                _GLAccountBiz.NameA = _CheckDb.GLAccountName;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _CheckDb.ID = value;
            }
            get
            {
                return _CheckDb.ID;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            set
            {
                _Currency = value;
            }
            get
            {
                if (_Currency == null)
                    _Currency = new CurrencyBiz();
                return _Currency;
            }
        }
        public BankBiz BankBiz
        {
            set
            {
                _Bank = value;
            }
            get
            {
                if (_Bank == null)
                    _Bank = new BankBiz();
                return _Bank;
            }
        }
        public string Code
        {
            set
            {
                _CheckDb.Code = value;
            }
            get
            {
                if (_CheckDb.Code == null)
                    _CheckDb.Code = "";
                return _CheckDb.Code;
            }
        }
        public string EditorName
        {
            set
            {
                _CheckDb.EditorName = value;
            }
            get
            {
                return _CheckDb.EditorName;
            }
        }
        public string BeneficialName
        {
            set
            {
                _CheckDb.BeneficialName = value;
            }
            get
            {
                return _CheckDb.BeneficialName;
            }
        }
        public string PayeeName
        {
            get
            {
                return BeneficialName == null || BeneficialName == "" ? EditorName : BeneficialName;
            }
        }
        public string CheckNote
        {
            set
            {
                _CheckDb.CheckNote = value;
            }
            get
            {
                return _CheckDb.CheckNote;
            }
        }
        public CheckStatus Status
        {
            set
            {
                _CheckDb.Status = (int)value;
            }
            get
            {
                return (CheckStatus)_CheckDb.Status;
            }
        }
        public int CustomerID
        {
            set
            {
                _CheckDb.CustomerID = value;
            }
        }
        public string StatusComment
        {
            set
            {
                _CheckDb.StatusComment = value;
            }
            get
            {
                return _CheckDb.StatusComment;
            }
        }
        BankBiz _CollectingBankBiz;

        public BankBiz CollectingBankBiz
        {
            get
            {
                if (_CollectingBankBiz == null)
                    _CollectingBankBiz = new BankBiz();
                return _CollectingBankBiz;
            }
            set { _CollectingBankBiz = value; }
        }
        public int TransactionID
        {
            set
            {
                _CheckDb.TransactionID = value;
            }
            get
            {
                return _CheckDb.TransactionID;
            }
        }
        public DateTime StatusDate
        {
            set
            {
                _CheckDb.StatusDate = value;
            }
            get
            {
                return _CheckDb.StatusDate;
            }
        }
        public CheckType Type
        {
            set
            {
                _CheckDb.Type = (int)value;
            }
            get
            {
                return (CheckType)_CheckDb.Type;
            }
        }
        public bool Direction
        {
            set
            {
                _CheckDb.Direction = value;
            }
            get
            {
                return _CheckDb.Direction;
            }
        }
        public bool IsBankOriented
        {
            set
            {
                _CheckDb.IsBankOrieneted = value;
            }
            get
            {
                return _CheckDb.IsBankOrieneted;
            }
        }
        public bool IsSubmitted
        {
            set
            {
                _CheckDb.IsSubmitted = value;
            }
            get
            {
                return _CheckDb.IsSubmitted;
            }
        }
        public DateTime SubmissionDate
        {
            set
            {
                _CheckDb.SubmissionDate = value;
            }
            get
            {
                return _CheckDb.SubmissionDate;
            }
        }
        public string TypeStr
        {
            get
            {
                string Returned = "";
                if (Type == CheckType.NotSpecified)
                    Returned = "غير محدد";
                else if (Type == CheckType.Check)
                    Returned = "شيك بنكى";
                else if (Type == CheckType.Promissory)
                    Returned = "كمبيالة";
                else if (Type == CheckType.TrustReceipt)
                    Returned = "إيصال أمانة";
                return Returned;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                if (Status == CheckStatus.Collected || (TotalPayment > 0 && TotalPayment <= CollectedValue))
                {
                    Returned = "محصل";
                    if (CollectingBankBiz.ID != 0)
                        Returned += "-" + CollectingBankBiz.Name;
                }
                else if (Status == CheckStatus.NotSpecified)
                    Returned = "غير محدد";
                else if (Status == CheckStatus.Postponeded && DueDate > DateTime.Now)
                    Returned = "لم يستحق";
                else if (Status == CheckStatus.Postponeded && DueDate <= DateTime.Now)
                    Returned = "مستحق وغير محصل";
                else if (Status == CheckStatus.Reclaimed)
                    Returned = "مسترد";
                else if (Status == CheckStatus.Rejected)
                    Returned = "مرفوض";
                else if (Status == CheckStatus.Submitted)
                    Returned = "مقدم بالبنك";
                else if (Status == CheckStatus.Required)
                    Returned = "مطلوب من البنك";

                if (Status != CheckStatus.Collected && Status != CheckStatus.Reclaimed &&
                   TotalPayment > 0 && TotalPayment <= CollectedValue)
                {
                    Returned = "محصل بالكامل وغير مسترد";
                }
                if (StatusComment != null && StatusComment != "")
                    Returned += "-" + StatusComment;

                return Returned;
            }
        }
        public CofferBiz PlaceBiz
        {
            set
            {
                _PlaceBiz = value;
            }
            get
            {
                if (_PlaceBiz == null)
                    _PlaceBiz = new CofferBiz();
                return _PlaceBiz;
            }
        }
        public AccountBankBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBankBiz();
                return _AccountBiz;
            }
        }
        public AccountBiz GLAccountBiz
        {
            set
            {
                _GLAccountBiz = value;
            }
            get
            {
                if (_GLAccountBiz == null)
                    _GLAccountBiz = new AccountBiz();
                return _GLAccountBiz;
            }
        }
        public string PlaceStr
        {
            get
            {
                string Returned = "";
                if (Status == CheckStatus.Reclaimed)
                    Returned = "مسترد";
                else
                    Returned = PlaceBiz.Name;
                return Returned;
            }
        }
        public int ParentID
        {
            set
            {
                _CheckDb.ParentID = value;
            }
            get
            {
                return _CheckDb.ParentID;
            }
        }
        public AttachmentFileBiz AttachmentBiz
        {
            set
            {
                _Attachment = value;
            }
            get
            {
                if (_Attachment == null)
                {
                    if (_CheckDb.AttachmentID != 0)
                    {
                        _Attachment = new AttachmentFileBiz(_CheckDb.AttachmentID);
                    }
                    else
                        _Attachment = new AttachmentFileBiz();
                }
                return _Attachment;
            }
        }
        public double Value
        {
            set
            {
                _CheckDb.Value = value;
            }
            get
            {
                return _CheckDb.Value;
            }
        }
        public string ValueStr
        {
            get
            {
                return Value.ToString("0,0");
            }
        }
        public DateTime DueDate
        {
            set
            {
                _CheckDb.DueDate = value;
            }
            get
            {
                return _CheckDb.DueDate;
            }
        }
        public DateTime IssueDate
        {
            set
            {
                _CheckDb.IssueDate = value;
            }
            get
            {
                return _CheckDb.IssueDate;
            }
        }
        public string IssueDateStr
        {
            get
            {
                return IssueDate.ToString("yyyy-MM-dd");
            }
        }
        public DateTime PaymentDate
        {
            set
            {
                _CheckDb.PaymentDate = value;
            }
            get
            {
                return _CheckDb.PaymentDate;
            }
        }
        public double TotalPayment
        {
            set
            {
                _CheckDb.TotalPayment = value;
            }
            get
            {
                return _CheckDb.TotalPayment;
            }
        }
        public double CollectedValue
        {

            get
            {
                return _CheckDb.CollectedValue;
            }
        }


        public DateTime MaxInstallmentDueDate
        {
            set { _CheckDb.MaxInstallmentDueDate = value; }
            get { return _CheckDb.MaxInstallmentDueDate; }
        }
        public DateTime MinInstallmentDueDate
        {
            set { _CheckDb.MinInstallmentDueDate = value; }
            get { return _CheckDb.MinInstallmentDueDate; }
        }
        public int CheckInstallmentCount
        {
            set { _CheckDb.CheckInstallmentCount = value; }
            get { return _CheckDb.CheckInstallmentCount; }
        }
        public int CheckReservationCount
        {
            set { _CheckDb.CheckReservationCount = value; }
            get { return _CheckDb.CheckReservationCount; }
        }
        public int TotalMonthCount
        {
            set { _CheckDb.TotalMonthCount = value; }
            get { return _CheckDb.TotalMonthCount; }
        }
        public int HasInstallment
        {
            set { _CheckDb.HasInstallment = value; }
            get { return _CheckDb.HasInstallment; }
        }




        public string Path
        {
            set
            {
                _Path = value;
            }
            get
            {
                if (_Path == null || _Path == "")
                {
                    if (AttachmentBiz != null && AttachmentBiz.ID != 0)
                    {
                        _Path = AttachmentBiz.Path;
                    }
                    else
                        _Path = "";

                }

                return _Path;
            }
        }
        public bool IsPaid
        {
            set
            {
                _CheckDb.IsPaid = value;

            }
            get
            {
                return _CheckDb.IsPaid;
            }
        }
        public int LastPrintID
        {
            get
            {
                return _CheckDb.LastPrintID;
            }
            set
            {
                _CheckDb.LastPrintID = value;
            }
        }

        public PaymentCol PaymentCol
        {
            set
            {
                _PaymentCol = value;
            }
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new PaymentCol(true);
                    if (ID != 0)
                    {
                        if (CheckDb.CachePaymentTable != null)
                        {
                            DataRow[] arrDr = CheckDb.CachePaymentTable.Select("CheckID=" + ID);
                            //DataTable dtTemp = objDb.Search();
                            foreach (DataRow objDr in arrDr)
                            {
                                _PaymentCol.Add(new PaymentBiz(objDr));
                            }
                        }
                    }
                }
                return _PaymentCol;
            }
        }
        public void AddPayment(PaymentBiz objPayment)
        {
            if (_PaymentCol == null)
                _PaymentCol = new PaymentCol(true);
            _PaymentCol.Add(objPayment);
        }

        public double VirtualCollectedValue
        {
            get
            {
                double Returned = 0;
                if (Status == CheckStatus.Collected)
                    Returned = Value;
                else
                    Returned = PaymentCol.TotalCollectedValue;
                return Returned;
            }
        }
        public string MaxPaymentDesc
        {
            get
            {
                return _CheckDb.MaxPaymentDesc;
            }
        }


        public static List<string> CheckStatusSCol
        {
            get
            {
                List<string> Returned = new List<string>();

                Returned.Add("غير محدد");

                Returned.Add("مؤجل امامستحق او لم ياتى تاريخ استحقاقه");

                Returned.Add("محصل من البنك");

                Returned.Add("مرفوض");

                Returned.Add("مسترد");

                Returned.Add("مقدم بالبنك");

                Returned.Add("غير مسدد");

                Returned.Add("مسدد");

                Returned.Add(" مسدد جزئيا وغير مسترد");
                Returned.Add("لم يسدد اى جزء");
                Returned.Add("سدد جزء ولم يكتمل");
                Returned.Add("ملغى");
                Returned.Add("مطلوب");
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (_PlaceBiz == null)
                _PlaceBiz = new CofferBiz();
            _CheckDb.Place = _PlaceBiz.ID;
            _CheckDb.Bank = BankBiz.ID;
            _CheckDb.Currency = CurrencyBiz.ID;
            if (Path != "")
            {
                AttachmentBiz.FilePath = Path;
                AttachmentBiz.Add();
            }
            _CheckDb.AttachmentID = _Attachment.ID;
            if (!Direction)
                _CheckDb.AccountID = AccountBiz.ID;
            else
                _CheckDb.AccountID = 0;
            _CheckDb.CollectingBank = CollectingBankBiz.ID;
            _CheckDb.GLAccountID = GLAccountBiz.ID;


            _CheckDb.Add();

        }

        public void Edit()
        {
            if (AttachmentBiz.Path != Path)
            {
                AttachmentBiz.Bytes = null;
                AttachmentBiz.FilePath = Path;
                AttachmentBiz.Edit();
            }
            if (_PlaceBiz == null)
                _PlaceBiz = new CofferBiz();
            _CheckDb.Place = _PlaceBiz.ID;
            _CheckDb.Bank = BankBiz.ID;
            _CheckDb.Currency = CurrencyBiz.ID;
            _CheckDb.AttachmentID = _Attachment.ID;
            if (!Direction)
                _CheckDb.AccountID = AccountBiz.ID;
            else
                _CheckDb.AccountID = 0;

            _CheckDb.GLAccountID = GLAccountBiz.ID;
            _CheckDb.CollectingBank = CollectingBankBiz.ID;
            _CheckDb.Edit();


        }
        public void EditStatus()
        {
            _CheckDb.EditStatus();
        }
        public void EditCurrentPlace(CofferBiz objCofferBiz, DateTime dtStatusDate)
        {
            _PlaceBiz = objCofferBiz;
            _CheckDb.Place = _PlaceBiz.ID;
            _CheckDb.StatusDate = dtStatusDate;
            _CheckDb.EditCurrentPlace();

        }
        public void Delete()
        {
            AttachmentBiz.Delete(AttachmentBiz.ID);
            _CheckDb.Delete();
        }

        public bool CheckPayment(PaymentBiz objPaymentBiz)
        {
            double dblPaymentValue = PaymentCol.TotalValue;
            int intIndex = PaymentCol.GetIndex(objPaymentBiz.ID);
            if (intIndex != -1)
            {
                dblPaymentValue -= PaymentCol[intIndex].Value;



            }
            dblPaymentValue += objPaymentBiz.Value;
            if (dblPaymentValue > Value)
                return false;
            return true;
        }
        public CheckBiz GetNewCheckInstant()
        {
            CheckBiz objCheckBiz = this;
            objCheckBiz.AttachmentBiz.ID = 0;
            objCheckBiz.ID = 0;
            objCheckBiz.Code = "";
            objCheckBiz.PaymentCol = new PaymentCol(true);
            return objCheckBiz;


        }
        public CheckBiz Copy()
        {
            CheckBiz Returned = new CheckBiz();

            Returned.AccountBiz = AccountBiz;
            Returned.BankBiz = BankBiz;
            Returned.BeneficialName = BeneficialName;
            Returned.CheckNote = CheckNote;
            Returned.Code = Code;
            // Returned.CollectedValue 
            Returned.CurrencyBiz = CurrencyBiz;
            Returned.Direction = Direction;
            Returned.DueDate = DueDate;
            Returned.EditorName = EditorName;
            Returned.GLAccountBiz = GLAccountBiz;
            Returned.IsBankOriented = IsBankOriented;
            Returned.IsPaid = IsPaid;
            Returned.IsSubmitted = IsSubmitted;
            Returned.IssueDate = IssueDate;
            Returned.Path = Path;
            Returned.PlaceBiz = PlaceBiz;
            Returned.Status = Status;
            Returned.StatusDate = StatusDate;
            Returned.SubmissionDate = SubmissionDate;
            Returned.Type = Type;
            Returned.Value = Value;


            return Returned;
        }
        public CheckCol GetCheckCopyCol(Int64 intStartCode, Int64 intEndCode, int intDayNo)
        {
            CheckCol Returned = new CheckCol(true);
            CheckBiz objBiz;
            int intMonthNo = intDayNo / 30;

            for (Int64 intTemp = intStartCode; intTemp <= intEndCode; intTemp++)
            {
                objBiz = Copy();
                objBiz.Code = intTemp.ToString();

                Returned.Add(objBiz);
                DueDate = objBiz.DueDate.AddMonths(intMonthNo);
            }
            return Returned;
        }
        #endregion
    }
}
