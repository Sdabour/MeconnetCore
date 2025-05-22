using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;

using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public enum ReceiptContent
    {
        Project =0,
        Tower=1,
        Unit=2,
        Value=3,
        Desc=4,
        Editor=5,
        Branch=6,
        Date=7,
        Customer=8,
        PrintDate=9,
        VersionNo=10,
        Serial=11,
        CopyVersion=12,
        InstallmentDate=13,
        CheckSerial=14,
        FullDesc=15,
        PaymentEffect=16,
        PaymentMean=17,
        Discount=18,
        Note=19,
        CheckDueDate=20 ,
        WireTransfereDate=21,
        WireTransfereBank =22,
        ManualSerial = 23,
        IP=24
    }
    public enum ReceiptVersionType
    {
        Original,
        Copy

    }
    public enum ReceiptStatus
    {
        Created=0,
        Canceled=1,
        PaymentCanceld=2


    }
    public enum ReceiptType
    {
        Payment =0 ,
        Check=1
    }
    public class ReceiptBiz
    {
        #region Private Data
        protected ReceiptDb _ReceiptDb;
        protected ReceiptModelBiz _ModelBiz;
        protected ReceiptBookBiz _BookBiz;
        protected EmployeeBiz _EditorBiz;
        protected ReceiptVersionType _VersionType;
        static List<string> _LstKeys;
        #endregion
        #region Constructors
        public ReceiptBiz() 
        {
            _ReceiptDb = new ReceiptDb();
        }
        public ReceiptBiz(DataRow objDr)
        {
            _ReceiptDb = new ReceiptDb(objDr);
            if (_ReceiptDb.Model != 0)
                _ModelBiz = ReceiptModelCol.AllModelCol.GetReceiptModelByID(_ReceiptDb.Model);
            else if (ReceiptModelCol.ActiveModelCol.Count > 0)
                _ModelBiz = ReceiptModelCol.ActiveModelCol[0];
            
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ReceiptDb.ID = value;
            }
            get
            {
                return _ReceiptDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _ReceiptDb.Desc = value;
            }
            get
            {
                return _ReceiptDb.Desc;
            }
        }
     
        public double Value
        {
            set
            {
                _ReceiptDb.Value = value;
            }
            get
            {
                return _ReceiptDb.Value;
            }
        }
        public string Beneficiary
        {
            set
            {
                _ReceiptDb.Beneficiary = value;
            }
            get
            {
                return _ReceiptDb.Beneficiary;
            }
        }
        public string Unit
        {
            set
            {
                _ReceiptDb.Unit = value;
            }
            get
            {
                return _ReceiptDb.Unit;
            }
        }
        public string Tower
        {
            set
            {
                _ReceiptDb.Tower = value;
            }
            get
            {
                return _ReceiptDb.Tower;
            }
        }
        public string Project
        {
            set
            {
                _ReceiptDb.Project = value;
            }
            get
            {
                return _ReceiptDb.Project;
            }
        }
        public string Serial
        {
            set
            {
                _ReceiptDb.Serial = value;
            }
            get
            {
                
                return _ReceiptDb.Serial;
            }
        }
        public string ManualSerial
        {
            set
            {
                _ReceiptDb.ManualSerial = value;
            }
            get
            {

                return _ReceiptDb.ManualSerial;
            }
        }
        public int SerialNum
        {
            set
            {
                _ReceiptDb.SerialNum = value;
            }
            get
            {
                return _ReceiptDb.SerialNum;
            }
        }
        public int Editor
        {
            set
            {
                _ReceiptDb.Editor = value;
            }
            get
            {
                return _ReceiptDb.Editor;
            }
        }
        public int Status
        {
            set
            {
                _ReceiptDb.Status = value;
            }
            get
            {
                return _ReceiptDb.Status;
            }
        }
        public DateTime Date
        {
            set
            {
                _ReceiptDb.Date = value;
            }
            get 
            {
                return _ReceiptDb.Date;
            }
        }
        public string InstallmentDueDate
        {
            set
            {
                _ReceiptDb.InstallmentDueDate = value;
            }
            get
            {
                return _ReceiptDb.InstallmentDueDate;
            }
        }
        public virtual string CheckSerial
        {
            set
            {
                _ReceiptDb.CheckSerial = value;
            }
            get
            {
                return _ReceiptDb.CheckSerial;
            }
        }
        public virtual string DisplayedCheckSerial
        {
            get
            {
                return CheckSerial;
            }
        }
        public string FullDesc
        {
            set
            {
                _ReceiptDb.FullDesc = value;
            }
            get
            {
                return _ReceiptDb.FullDesc;
            }
        }
        public string PaymentEffect
        {
            set
            {
                _ReceiptDb.PaymentEffect = value;
            }
            get
            {
                return _ReceiptDb.PaymentEffect;
            }
        }
        public string PaymentMean
        {
            set
            {
                _ReceiptDb.PaymentMean = value;
            }
            get
            {
                return _ReceiptDb.PaymentMean;
            }
        }
        public string DiscountStr
        {
            set
            {
                _ReceiptDb.DiscountStr = value;
            }
            get
            {
                return _ReceiptDb.DiscountStr;
            }
        }
        public int VersionNo
        {
            set
            {
                _ReceiptDb.VersionNo = value;
            }
            get
            {
                return _ReceiptDb.VersionNo;
            }
        }
        public string IP
        {
            set
            {
                _ReceiptDb.IP = value;
            }
            get
            {
                return _ReceiptDb.IP;
            }
        }
        public ReceiptType Type
        {
            set
            {
                _ReceiptDb.Type = (int)value;
            }
            get
            {
                return (ReceiptType)_ReceiptDb.Type;
            }
        }
        public ReceiptModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                if (_ModelBiz == null)
                    _ModelBiz = new ReceiptModelBiz();
                return _ModelBiz;
            }
        }
        public ReceiptBookBiz BookBiz
        {
            set
            {
                _BookBiz = value;
            }
            get
            {
                if (_BookBiz == null)
                    _BookBiz = new ReceiptBookBiz();
                return _BookBiz;
            }
        }
        public EmployeeBiz EditorBiz
        {
            set
            {
                _EditorBiz = value;
            }
            get
            {
                if (_EditorBiz == null)
                    _EditorBiz = new EmployeeBiz();
                return _EditorBiz;
            }
        }
        public string EditorName
        {
            set
            {
                _ReceiptDb.EditorName = value;
            }
            get
            {
                return _ReceiptDb.EditorName;
            }
        }
        public int BranchID
        {
            set
            {
                _ReceiptDb.Branch = value;
            }
            get
            {
                return _ReceiptDb.Branch;
            }
        }
        public string BranchName
        {
            set
            {
                _ReceiptDb.BranchName = value;
            }
            get
            {
                return _ReceiptDb.BranchName;
            }
        }
        public string Note
        {
            set
            {
                _ReceiptDb.Note = value;
            }
            get
            {
                return _ReceiptDb.Note;
            }
        }
        public DateTime CheckDueDate
        {
            set
            {
                _ReceiptDb.CheckDueDate = value;
            }
            get
            {
                return _ReceiptDb.CheckDueDate;
            }
        }
        public DateTime WireTranfereDate
        {
            set
            {
                _ReceiptDb.WireTranfereDate = value;
            }
            get
            {
                return _ReceiptDb.WireTranfereDate;
            }
        }
        public string WireTransfereBank
        {
            set
            {
                _ReceiptDb.WireTransfereBank = value;
            }
            get
            {
                return _ReceiptDb.WireTransfereBank;
            }
        }
        public string DisplayedWireTransfereBank
        {
            get
            {
                string Returned = "";
                Returned = " ÕÊÌ· ⁄·Ï »‰ﬂ :" + WireTransfereBank + " » «—ÌŒ " + WireTranfereDate.ToString("dd/MM/yyyy");
                return Returned;
            }
        }
        public ReceiptVersionType VersionType
        {
            set
            {
                _VersionType = value;
            }
            get
            {
                return _VersionType;
            }
        }
        public static List<string> LstKeys
        {
            get
            {
                if (_LstKeys == null)
                {
                    _LstKeys = new List<string>();
                    _LstKeys.Add("{«·„‘—Ê⁄}");//0
                    _LstKeys.Add("{«·»—Ã}");//1
                    _LstKeys.Add("{«·ÊÕœ…}");//2
                    _LstKeys.Add("{«·ﬁÌ„…}");//3
                    _LstKeys.Add("{«·Ê’›}");//4
                    _LstKeys.Add("{«·„Õ——}");//5
                    _LstKeys.Add("{«·›—⁄}");//6
                    _LstKeys.Add("{«· «—ÌŒ}");//7
                    _LstKeys.Add("{«”„ «·⁄„Ì·}");//8
                    _LstKeys.Add("{ «—ÌŒ «·ÿ»«⁄…}");//9
                    _LstKeys.Add("{—ﬁ„ «·‰”Œ…}");//10
                    _LstKeys.Add("{«·ﬂÊœ}");//11
                    _LstKeys.Add("{‰Ê⁄ «·‰”Œ…}");//12
        //              InstallmentDate=13,
                    _LstKeys.Add("{ «—ÌŒ «·ﬁ”ÿ}");//13
        //CheckSerial=14,
                    _LstKeys.Add("{«·‘Ìﬂ}");
        //FullDesc=15
                    _LstKeys.Add("{Ê’› ﬂ«„·}");
                    //16
                    _LstKeys.Add("{«· √ÀÌ—}");
                    _LstKeys.Add("{Ê”Ì·… «·œ›⁄}");
                    _LstKeys.Add("{Œ’„}");
                    _LstKeys.Add("{„·«ÕŸ…}");
                    _LstKeys.Add("{ «—ÌŒ «” Õﬁ«ﬁ «·‘Ìﬂ}");
                    _LstKeys.Add("{ «—ÌŒ «· ÕÊÌ·}");
                    _LstKeys.Add("{»‰ﬂ «· ÕÊÌ·}");
                    _LstKeys.Add("{—ﬁ„ «·œ› —}");
                    _LstKeys.Add("{«·ÃÂ«“}");
                }
                return _LstKeys;
            }
        }
        public static List<string> ReceiptStatusLst
        {
            get
            {
                List<string> Returned = new List<string>();
        //        Created=0,
                Returned.Add("›⁄«·");
        //Canceled=1,
                Returned.Add("„·€Ï");
        //PaymentCanceld=2
                Returned.Add("«·œ›⁄… „·€Ì…");
                return Returned;
            }
        }
      
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _ReceiptDb.Model = ModelBiz.ID;
            _ReceiptDb.Editor = EditorBiz.ID;
            _ReceiptDb.Direction = _ModelBiz.Direction;
            //_ReceiptDb.Branch = EditorBiz.BranchID;
            _ReceiptDb.Add();
        }
        public virtual void Edit()
        {
            _ReceiptDb.Model = ModelBiz.ID;
            _ReceiptDb.Direction = _ModelBiz.Direction;
            _ReceiptDb.Edit();
        }
        public void Delete()
        {
            _ReceiptDb.Delete();
        }

        public string GetValueString(ReceiptContent objContent)
        {
            if (objContent == ReceiptContent.Branch)
                return BranchName;
            else if (objContent == ReceiptContent.Customer)
                return Beneficiary;
            else if (objContent == ReceiptContent.Date)
                return Date.ToString("dd/MM/yyyy");
            else if (objContent == ReceiptContent.Desc)
                return Desc;
            else if (objContent == ReceiptContent.Editor)
                return EditorName;
            else if (objContent == ReceiptContent.PrintDate)
                return DateTime.Now.ToString("dd/MM/yyyy");
            else if (objContent == ReceiptContent.Project)
                return Project;
            else if (objContent == ReceiptContent.Tower)
                return Tower;
            else if (objContent == ReceiptContent.Unit)
                return Unit;
            else if (objContent == ReceiptContent.Value)
                return Value.ToString("0,0") + "-" + SystemBase.SysUtility.NumToStr(Value) + "";
            else if (objContent == ReceiptContent.VersionNo)
                return VersionNo.ToString();
            else if (objContent == ReceiptContent.Serial)
                return Serial;
            else if (objContent == ReceiptContent.CopyVersion)
            {
                if (_VersionType == ReceiptVersionType.Original)
                    return "√’·";
                else
                    return "’Ê—…";
            }

            else if (objContent == ReceiptContent.InstallmentDate)
                return InstallmentDueDate;
            else if (objContent == ReceiptContent.PaymentEffect)
                return PaymentEffect;
            else if (objContent == ReceiptContent.CheckSerial)
            {

                return DisplayedCheckSerial;
            }
            else if (objContent == ReceiptContent.FullDesc)
                return FullDesc;
            else if (objContent == ReceiptContent.PaymentMean)
                return PaymentMean;
            else if (objContent == ReceiptContent.Discount)
                return DiscountStr;
            else if (objContent == ReceiptContent.Note)
                return Note;
            else if (objContent == ReceiptContent.CheckDueDate)
                return CheckDueDate.ToString("dd/MM/yyyy");
            else if (objContent == ReceiptContent.WireTransfereDate)
                return WireTranfereDate.ToString("dd/MM/yyyy");
            else if (objContent == ReceiptContent.WireTransfereBank)
                return WireTransfereBank;
            else if (objContent == ReceiptContent.ManualSerial)
                return ManualSerial;
            else if (objContent == ReceiptContent.IP)
                return IP;
            else
                return "";


        }
        #endregion
    }
}
