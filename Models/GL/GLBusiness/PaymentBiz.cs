using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public enum PaymentType
    {
        Cash,
        Check,
        BankingTransfering,
        Visa

    }
    public enum PaymentCacheType
    {
        Cash,

        BankingTransfering,
        Visa

    }
    public enum PaymentDirection
    {
        Output = 0,
        Input = 1
    }

    public class PaymentBiz
    {
        #region Private Data
        protected PaymentDb _PaymentDb;
        protected CurrencyBiz _Currency;
        protected CheckBiz _CheckBiz;
        protected WireTransfereBiz _WireTransfereBiz;
        protected CofferBiz _CofferBiz;
        protected CofferBiz _CollectingCofferBiz;
        // protected EmployeeBiz  
        #endregion

        #region Constructors
        public PaymentBiz()
        {
            _Currency = new CurrencyBiz();
            _PaymentDb = new PaymentDb();
        }
        public PaymentBiz(int intID)
        {
            _PaymentDb = new PaymentDb(intID);
            _Currency = new CurrencyBiz();
        }
        public PaymentBiz(DataRow objDR)
        {
            _PaymentDb = new PaymentDb(objDR);
            _Currency = new CurrencyBiz(objDR);
            if (_PaymentDb.CofferID != 0)
            {
                _CofferBiz = new CofferBiz();
                _CofferBiz.ID = _PaymentDb.CofferID;
                _CofferBiz.NameA = _PaymentDb.CofferName;
                _CofferBiz.Code = _PaymentDb.CofferCode;
            }
            if (_PaymentDb.CollectingCofferID != 0)
            {
                _CollectingCofferBiz = new CofferBiz();
                _CollectingCofferBiz.ID = _PaymentDb.CollectingCofferID;
                _CollectingCofferBiz.NameA = _PaymentDb.CollectingCofferName;
                _CollectingCofferBiz.Code = _PaymentDb.CollectingCofferCode;
            }
            if (_PaymentDb.CheckID != 0)
                _CheckBiz = new CheckBiz(objDR);
            if (_PaymentDb.WireTransafere != 0)
                _WireTransfereBiz = new WireTransfereBiz(objDR);
        }
        public PaymentBiz(DataRow objDR, bool blOnlyPaymentData)
        {
            _PaymentDb = new PaymentDb(objDR);

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _PaymentDb.ID = value;
            }
            get
            {
                return _PaymentDb.ID;
            }
        }
        public virtual string Desc
        {
            set
            {
                _PaymentDb.Desc = value;
            }
            get
            {
                return _PaymentDb.Desc;
            }
        }
        public virtual string SubDesc
        {
            set
            {
                _PaymentDb.SubDesc = value;
            }
            get
            {
                return _PaymentDb.SubDesc;
            }
        }
        public virtual PaymentType Type
        {
            set
            {
                _PaymentDb.Type = (int)value;
            }
            get
            {
                return (PaymentType)_PaymentDb.Type;
            }
        }
        public DateTime Date
        {
            set
            {
                _PaymentDb.Date = value;
            }
            get
            {
                return _PaymentDb.Date;
            }
        }
        public double Value
        {
            set
            {
                _PaymentDb.Value = value;
            }
            get
            {
                return _PaymentDb.Value;
            }
        }
        public int Currency
        {
            set
            {
                _PaymentDb.Currency = value;
            }
            get
            {
                return _PaymentDb.Currency;
            }
        }
        public DateTime CollectingDate
        {
            set
            {
                _PaymentDb.CollectingDate = value;
            }
            get
            {
                return _PaymentDb.CollectingDate;
            }

        }

        public double CurrencyValue
        {
            set
            {
                _PaymentDb.CurrencyValue = Value;
            }
            get
            {
                return _PaymentDb.CurrencyValue;
            }
        }
        public int GLTransaction
        {
            set
            {
                _PaymentDb.GLTransaction = value;
            }
            get
            {
                return _PaymentDb.GLTransaction;
            }
        }
        public CheckBiz CheckBiz
        {
            set
            {
                _CheckBiz = value;
            }
            get
            {
                if (_CheckBiz == null)
                    _CheckBiz = new CheckBiz();
                return _CheckBiz;
            }
        }
        public int CheckID
        {
            get
            {
                return _PaymentDb.CheckID;
            }
        }
        public WireTransfereBiz WireTransfereBiz
        {
            set
            {
                _WireTransfereBiz = value;
            }
            get
            {
                if (_WireTransfereBiz == null)
                    _WireTransfereBiz = new WireTransfereBiz();
                return _WireTransfereBiz;

            }
        }
        public int EmployeeID
        {
            set
            {
                _PaymentDb.EmployeeID = value;
            }
            get
            {
                return _PaymentDb.EmployeeID;
            }
        }
        public int VisitID
        {
            set
            {
                _PaymentDb.VisitID = value;
            }
            get
            {
                return _PaymentDb.VisitID;
            }

        }
        public string EmployeeName
        {

            get
            {
                return _PaymentDb.EmployeeName;
            }
        }
        public int BranchID
        {
            set
            {
                _PaymentDb.BranchID = value;
            }
            get
            {
                return _PaymentDb.BranchID;
            }
        }
        public string BranchName
        {

            get
            {
                return _PaymentDb.BranchName;
            }
        }
        public CofferBiz CofferBiz
        {
            set
            {
                _CofferBiz = value;
            }
            get
            {
                if (_CofferBiz == null)
                    _CofferBiz = new CofferBiz();
                return _CofferBiz;
            }
        }
        public int CollectingEmployeeID
        {
            set
            {
                _PaymentDb.CollectingEmployeeID = value;
            }
            get
            {
                return _PaymentDb.CollectingEmployeeID;
            }
        }
        public string CollectingEmployeeName
        {

            get
            {
                return _PaymentDb.CollectingEmployeeName;
            }
        }
        public int CollectingBranchID
        {
            set
            {
                _PaymentDb.CollectingBranchID = value;
            }
            get
            {
                return _PaymentDb.CollectingBranchID;
            }
        }
        public string CollectingBranchName
        {

            get
            {
                return _PaymentDb.CollectingBranchName;
            }
        }
        public CofferBiz CollectingCofferBiz
        {
            set
            {
                _CollectingCofferBiz = value;
            }
            get
            {
                if (_CollectingCofferBiz == null)
                    _CollectingCofferBiz = new CofferBiz();
                return _CollectingCofferBiz;
            }
        }
        public bool IsCollected
        {
            set
            {
                _PaymentDb.IsCollected = value;
            }
            get
            {
                return _PaymentDb.IsCollected;
            }
        }
        public int OldPaymentID
        {
            get { return _PaymentDb.OldPaymentID; }
            set { _PaymentDb.OldPaymentID = value; }
        }


        public double OldPaymentValue
        {
            get { return _PaymentDb.OldPaymentValue; }
            set { _PaymentDb.OldPaymentValue = value; }
        }
        public PaymentDirection Direction
        {
            set
            {
                _PaymentDb.Direction = ((PaymentDirection)value) == PaymentDirection.Input ? true : false;
            }
            get
            {
                return _PaymentDb.Direction ? PaymentDirection.Input : PaymentDirection.Output;
            }
        }
        public static List<string> TypeStrLst
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("‰ﬁœÌ…");
                Returned.Add("‘Ìﬂ");
                Returned.Add(" ÕÊÌ· »‰ﬂÏ");
                Returned.Add("›Ì“«");
                return Returned;
            }
        }
        public static List<string> TypeCacheStrLst
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("‰ﬁœÌ…");

                Returned.Add(" ÕÊÌ· »‰ﬂÏ");
                Returned.Add("›Ì“«");
                return Returned;
            }
        }
        public static List<int> TypeCacheIntLst
        {
            get
            {
                List<int> Returned = new List<int>();
                Returned.Add(0);

                Returned.Add(2);
                Returned.Add(3);
                return Returned;
            }
        }
        public virtual string TypeStr
        {
            get
            {
                string Returned = "";
                //if (Type == PaymentType.Cash)
                //    Returned = "”œ«œ ›Ê—Ï";
                //else if (Type == PaymentType.Check)
                //{

                //    Returned = " ”œ«œ »‘Ìﬂ ";
                //    if (_CheckBiz != null && _CheckBiz.ID != 0)
                //    {
                //        Returned += " : " + _CheckBiz.Code + " (" + _CheckBiz.StatusStr + ")";
                //    }
                //}
                //else
                //    Returned = "ÕÊ«·…";
                Returned = TypeStrLst[(int)Type];

                return Returned;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                //if (Type == PaymentType.Cash)
                //    Returned = "”œ«œ ›Ê—Ï";
                //else if (Type == PaymentType.Check)
                //{

                //    Returned = " ”œ«œ »‘Ìﬂ ";
                //    if (_CheckBiz != null && _CheckBiz.ID != 0)
                //    {
                //        Returned += " : " + _CheckBiz.Code + " (" + _CheckBiz.StatusStr + ")";
                //    }
                //}
                //else
                //    Returned = "ÕÊ«·…";
                Returned = TypeStrLst[(int)Type];
                if (CheckBiz != null && CheckBiz.ID != 0 && !IsCollected)
                    Returned += " —ﬁ„ «·‘Ìﬂ" + "-" + CheckBiz.Code + "-";
                if (Type == PaymentType.Check && IsCollected)
                    Returned = "„Õ’·";
                return Returned;
            }
        }
        public static List<string> DirectionStrLst
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("„’—Ê›« ");
                Returned.Add("„ﬁ»Ê÷« ");
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            // _PaymentDb.Currency = 1;
            _PaymentDb.CheckID = CheckBiz.ID;
            _PaymentDb.WireTransafere = WireTransfereBiz.ID;
            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
            _PaymentDb.Add();
        }
        public virtual void Edit()
        {
            //_PaymentDb.Currency = 1;
            _PaymentDb.CheckID = CheckBiz.ID;
            _PaymentDb.WireTransafere = WireTransfereBiz.ID;
            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
            _PaymentDb.Edit();
        }
        public virtual void Delete()
        {
            _PaymentDb.Delete();
        }
        public void CollectPayment(DateTime dtCollectingDate, bool blIsCollected,
            int intEmployeeID, int intBranchID, int intCofferID, PaymentCacheType objPaymentType)
        {
            if (_CheckBiz == null || _CheckBiz.ID == 0)
                return;
            _PaymentDb.CheckID = _CheckBiz.ID;
            _PaymentDb.IsCollected = blIsCollected;
            _PaymentDb.CollectingDate = dtCollectingDate;
            _PaymentDb.CollectingEmployeeID = blIsCollected ? intEmployeeID : 0;
            _PaymentDb.CollectingBranchID = blIsCollected ? intBranchID : 0;
            _PaymentDb.CollectingCofferID = blIsCollected ? intCofferID : 0;
            // _PaymentDb.Type = blIsCollected ? (objPaymentType == PaymentCacheType.BankingTransfering ? (int)PaymentType.BankingTransfering : (objPaymentType == PaymentCacheType.Visa ? (int) PaymentType.Visa : (int)PaymentType.Cash)) : (int)PaymentType.Check;
            _PaymentDb.Type = blIsCollected ? (int)objPaymentType : (int)PaymentType.Check;
            _PaymentDb.CollectCheckPayment();

        }

        public static PaymentDirection GetDirection(string strDirection)
        {
            if (strDirection == null)
                strDirection = "";
            List<string> arrStr = DirectionStrLst;
            for (int intIndex = 0; intIndex < arrStr.Count; intIndex++)
            {
                if (arrStr[intIndex] == strDirection)
                    return (PaymentDirection)intIndex;

            }
            return PaymentDirection.Input;
        }
        public static PaymentType GetType(string strType)
        {
            if (strType == null)
                strType = "";
            List<string> arrStr = TypeStrLst;
            for (int intIndex = 0; intIndex < arrStr.Count; intIndex++)
            {
                if (arrStr[intIndex] == strType)
                    return (PaymentType)intIndex;

            }
            return PaymentType.Cash;
        }
        #endregion
    }
}
