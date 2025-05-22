using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class CheckCol : BaseCol
    {

        #region Private Data
        protected Hashtable _CheckHs = new Hashtable();
        #region Paging
        protected int _MaxCount = 20000;
        protected int _ResultCount = 0;
        protected double _ResultValue = 0;
        protected int _TheMinID;
        protected int _MaxID;
        protected int _MinID;
        protected bool _EnableNext;
        protected bool _EnablePrevious;
        #endregion

        string _StatusStr;
        string _EditorName;
        string _Code;
        string _IDs;
        string _Note;
        bool _IsIssueRange;
        DateTime _StartIssueDate;
        DateTime _EndIssueDate;
        bool _IsDueRange;
        DateTime _StartDueDate;
        DateTime _EndDueDate;
        bool _IsStatusRange;
        DateTime _StartStatusDate;
        DateTime _EndStatusDate;
        bool _IsPaymentRange;
        DateTime _StartPaymentDate;
        DateTime _EndPaymentDate;

        bool _IsSubmissionRange;
        DateTime _StartSubmissionDate;
        DateTime _EndSubmissionDate;
        BankBiz _BankBiz;
        AccountBankBiz _BankAccountBiz;
        CurrencyBiz _CurrencyBiz;
        CheckStatus _Status;
        CofferBiz _CofferBiz;
        CofferCol _CofferCol;
        CofferBiz _OldCofferBiz;
        AccountBankBiz _AccountBiz;
        int _CollectingPaymentStatus;

        int _HasPaymentStatus;
        int _Type;
        bool _MaxDateLimitStatus;
        bool _Direction;
        DateTime _MaxDateLimit;
        bool _StatsValue;
        double _CheckFromValue;
        double _CheckToValue;
        int _OrientedStatus;
        int _CellFamilyID;
        string _CellIDs;
        int _CampaignID;
        int _CustomerID;
        int _PersonID;
        int _PersonType;
        int _ResubmissionID;

        protected bool _IgnoreInstallmentType;
        protected string _InstallmentTypeIDs;
        protected int _CheckMultipleInstallment;
        protected int _CheckMultipleReservation;
        #endregion

        #region Constructor
        public CheckCol(bool blIsempty)
        {

        }
        public CheckCol()
        { }
        public CheckCol(string strStatus, string strEditorName, string strCode, string strNote, bool blIssueRange, DateTime dtStartIssueDate,
            DateTime dtEndIssueDate, bool blDueRange, DateTime dtStartDueDate, DateTime dtEndDueDate,
            bool blIsStatusDateRange, DateTime dtStartStatusDate, DateTime dtEndStatusDate,
            BankBiz objBankBiz, CurrencyBiz objCurrencyBiz
            , CheckStatus objStatus
            , CofferCol objCofferCol, CofferBiz objOldCofferBiz
            , int intCollectingPaymentStatus,
            CheckType objType, bool blStatusVal, double dblFromVal
            , double dblToVal, bool blMaxDateLimited, DateTime dtMaxlimitDate, bool blIsSubmissionRange,
            DateTime dtStartSubmissionDate
            , DateTime dtEndSubmissionDate
            , AccountBankBiz objBankAccountBiz
            , int intOrientedStatus,
            bool blDirection, int intCellFamilyID
            , string strCellIDs, int intCampaignID
            , int intResubmissionID, int intHasPaymentStatus
           , bool blIsPaymentRange, DateTime dtStartPaymentDate
            , DateTime dtEndPaymentDate, string strCheckIDs
            , int intCustomerID)
        {
            CheckDb objCheckDb = new CheckDb();
            SetDataInitially(strStatus, strEditorName, strCode, strNote, blIssueRange, dtStartIssueDate,
             dtEndIssueDate, blDueRange, dtStartDueDate, dtEndDueDate,
              blIsStatusDateRange, dtStartStatusDate, dtEndStatusDate,
              objBankBiz, objCurrencyBiz, objStatus, objCofferCol, objOldCofferBiz, intCollectingPaymentStatus, objType, blStatusVal,
              dblFromVal, dblToVal, blMaxDateLimited, dtMaxlimitDate, blIsSubmissionRange, dtStartSubmissionDate, dtEndSubmissionDate, objBankAccountBiz,
              intOrientedStatus, blDirection, intCellFamilyID, strCellIDs, intCampaignID, intResubmissionID, intHasPaymentStatus,
              blIsPaymentRange, dtStartPaymentDate, dtEndPaymentDate, true, "", strCheckIDs, intCustomerID);
            GetSearchData(ref objCheckDb);
            DataTable dtTemp = objCheckDb.Search();
            _ResultCount = objCheckDb.ResultCount;
            _ResultValue = objCheckDb.ResultValue;
            CheckBiz objCheckBiz;
            DataRow[] arrMainDr = dtTemp.Select("", "CheckEditorName,CheckDueDate");
            foreach (DataRow objDr in arrMainDr)
            {
                objCheckBiz = new CheckBiz(objDr);
                // objCheckBiz.TotalPayment = objCheckBiz.PaymentCol.TotalValue;
                Add(objCheckBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "CheckID");
                objCheckDb = new CheckDb(arrDr[Count - 1]);
                _MaxID = objCheckDb.ID;
                objCheckDb = new CheckDb(arrDr[0]);
                _MinID = objCheckDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public CheckCol(int intPersonID, int intPersonType)
        {
            CheckDb objDb = new CheckDb();
            objDb.PersonID = intPersonID;
            objDb.PersonType = intPersonType;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CheckBiz(objDr));
            }
        }
        #endregion
        #region Private Method
        protected virtual void SetDataInitially(string strStatus, string strEditorName, string strCode, string strNote, bool blIssueRange, DateTime dtStartIssueDate,
             DateTime dtEndIssueDate, bool blDueRange, DateTime dtStartDueDate, DateTime dtEndDueDate,
             bool blStatusRange, DateTime dtStartStatusDate, DateTime dtEndStatusDate,
             BankBiz objBankBiz, CurrencyBiz objCurrencyBiz,
             CheckStatus objStatus, CofferCol objCofferCol, CofferBiz objOldCofferBiz, int intCollectingPaymentStatus,
             CheckType objType, bool blStatusValue, double dblFromCheckVal, double dblToCheckVal,
             bool blMaxLimitStatus, DateTime dtMaxLimitDate, bool blIsSubmissionRange,
             DateTime dtStartSubmissionDate, DateTime dtEndSubmissionDate, AccountBankBiz objBankAccountBiz, int intOrientedStatus,
             bool blDirection, int intCellFamilyID, string strCellIDs, int intCampaignID,
            int intResubmissionID, int intHasPaymentStatus, bool blIsPaymentRange,
            DateTime dtStartPaymentDate, DateTime dtEndPaymentDate,
            bool blIgnoreInstallmentType, string strInstallmentType, string strIDs
            , int intCustomerID)
        {
            _StatusStr = strStatus;
            _EditorName = strEditorName;
            _Code = strCode;
            _IDs = strIDs;
            _Note = strNote;
            _IsIssueRange = blIssueRange;
            _StartIssueDate = dtStartIssueDate;
            _EndIssueDate = dtEndIssueDate;
            _IsDueRange = blDueRange;
            _StartDueDate = dtStartDueDate;
            _EndDueDate = dtEndDueDate;
            _IsStatusRange = blStatusRange;
            _StartStatusDate = dtStartStatusDate;
            _EndStatusDate = dtEndStatusDate;
            _IsPaymentRange = blIsPaymentRange;
            _StartPaymentDate = dtStartPaymentDate;
            _EndPaymentDate = dtEndPaymentDate;
            _BankBiz = objBankBiz;
            _CurrencyBiz = objCurrencyBiz;
            _Status = objStatus;
            _CofferCol = objCofferCol;
            _StatsValue = blStatusValue;
            _MaxDateLimitStatus = blMaxLimitStatus;
            _MaxDateLimit = dtMaxLimitDate;
            _CheckFromValue = dblFromCheckVal;
            _CheckToValue = dblToCheckVal;
            if (objOldCofferBiz == null)
                _OldCofferBiz = new CofferBiz();
            if (objBankAccountBiz == null)
                objBankAccountBiz = new AccountBankBiz();
            _BankAccountBiz = objBankAccountBiz;
            _OldCofferBiz = objOldCofferBiz;
            _CollectingPaymentStatus = intCollectingPaymentStatus;
            _Type = (int)objType;
            _Direction = blDirection;
            _IsSubmissionRange = blIsSubmissionRange;
            _StartSubmissionDate = dtStartSubmissionDate;
            _EndSubmissionDate = dtEndSubmissionDate;
            _OrientedStatus = intOrientedStatus;
            //_AccountBiz = objAccountBiz;
            _CellFamilyID = intCellFamilyID;
            _CellIDs = strCellIDs;
            _CampaignID = intCampaignID;
            _ResubmissionID = intResubmissionID;
            _HasPaymentStatus = intHasPaymentStatus;
            _IgnoreInstallmentType = blIgnoreInstallmentType;
            _InstallmentTypeIDs = strInstallmentType;
            _CustomerID = intCustomerID;
        }
        protected virtual void GetSearchData(ref CheckDb objCheckDb)
        {
            objCheckDb.StatusStr = _StatusStr;
            objCheckDb.EditorName = _EditorName;
            objCheckDb.Code = _Code;

            objCheckDb.CheckNote = _Note;
            objCheckDb.IsIssueRange = _IsIssueRange;
            objCheckDb.StartIssueDate = _StartIssueDate;
            objCheckDb.EndIssueDate = _EndIssueDate;
            objCheckDb.IsDueRange = _IsDueRange;
            objCheckDb.StartDueDate = _StartDueDate;
            objCheckDb.EndDueDate = _EndDueDate;
            objCheckDb.IsStatusDateRange = _IsStatusRange;
            objCheckDb.StartStatusDate = _StartStatusDate;
            objCheckDb.EndStatusDate = _EndStatusDate;
            if (_BankBiz == null)
                _BankBiz = new BankBiz();
            objCheckDb.Bank = _BankBiz.ID;
            objCheckDb.Currency = _CurrencyBiz.ID;
            objCheckDb.Status = (int)_Status;
            // objCheckDb.Place = _CofferBiz.ID;
            if (_CofferCol == null)
                _CofferCol = new CofferCol(true, 0);
            objCheckDb.PlaceIDs = _CofferCol.IDsStr;
            objCheckDb.OldPlace = _OldCofferBiz.ID;
            objCheckDb.CollectingPaymentStatus = _CollectingPaymentStatus;
            objCheckDb.Type = _Type;
            objCheckDb.MaxStatusDateLimited = _MaxDateLimitStatus;
            objCheckDb.MaxStatusDate = _MaxDateLimit;
            objCheckDb.StatusValue = _StatsValue;
            objCheckDb.ToCheckValue = _CheckToValue;
            objCheckDb.FromCheckValue = _CheckFromValue;
            objCheckDb.Direction = _Direction;
            objCheckDb.IsSubmissionRange = _IsSubmissionRange;
            objCheckDb.StartSubmissionDate = _StartSubmissionDate;
            objCheckDb.EndSubmissionDate = _EndSubmissionDate;
            objCheckDb.BankOrientedStatus = _OrientedStatus;
            objCheckDb.AccountID = _BankAccountBiz.ID;
            objCheckDb.CellFamilyID = _CellFamilyID;
            objCheckDb.CellIDs = _CellIDs;
            objCheckDb.CampaignID = _CampaignID;
            objCheckDb.ResubmissionID = _ResubmissionID;
            objCheckDb.HasPaymentStatus = _HasPaymentStatus;
            objCheckDb.IsPaymentRange = _IsPaymentRange;
            objCheckDb.StartPaymentDate = _StartPaymentDate;
            objCheckDb.EndPaymentDate = _EndPaymentDate;
            objCheckDb.IDs = _IDs;
            objCheckDb.CustomerID = _CustomerID;
        }

        #endregion

        #region Public Properties
        public CheckBiz this[int intIndex]
        {

            get
            {
                return (CheckBiz)List[intIndex];
            }
        }
        public CheckBiz this[string strID]
        {

            get
            {
                return _CheckHs[strID] == null ? new CheckBiz() : (CheckBiz)_CheckHs[strID];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CheckBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                        continue;
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
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
        public bool EnableNext
        {
            get
            {
                return _EnableNext;
            }
        }
        public bool EnablePrevious
        {
            get
            {
                return _EnablePrevious;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (CheckBiz objCheckBiz in this)
                {
                    Returned += objCheckBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalPaymentValue
        {
            get
            {
                double Returned = 0;
                foreach (CheckBiz objCheckBiz in this)
                {
                    Returned += objCheckBiz.TotalPayment;
                }
                return Returned;
            }
        }
        public double TotalCollectedValue
        {
            get
            {
                double Returned = 0;
                foreach (CheckBiz objCheckBiz in this)
                {
                    Returned += objCheckBiz.CollectedValue;
                }
                return Returned;
            }
        }
        static List<string> _IDsLst;

        public static List<string> IDsLst
        {
            get
            {
                if (_IDsLst == null)
                    _IDsLst = new List<string>();
                return CheckCol._IDsLst;
            }
            set { CheckCol._IDsLst = value; }
        }
        DataTable GetCheckUserTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UserID"), new DataColumn("ID") });
            DataRow objDr;
            foreach (CheckBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UserID"] = SysData.CurrentUser.ID;
                objDr["ID"] = objBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
        public void Add(CheckBiz objBiz)
        {
            if (objBiz.ID == 0 || _CheckHs[objBiz.ID.ToString()] == null)
            {
                List.Add(objBiz);
                if (objBiz.ID > 0)
                    _CheckHs.Add(objBiz.ID.ToString(), objBiz);
            }

        }
        public void AddCol(CheckCol objCol)
        {
            foreach (CheckBiz objCheckBiz in objCol)
            {
                Add(objCheckBiz);
            }
        }
        public void EditCurrentPlace(CofferBiz objCofferBiz, DateTime dtStatusDate)
        {
            CheckDb objCheckDb = new CheckDb();
            objCheckDb.Place = objCofferBiz.ID;
            objCheckDb.IDs = IDsStr;
            objCheckDb.StatusDate = dtStatusDate;
            objCheckDb.EditCurrentPlaceForMultiple();

        }
        public void EditCurrentStatus(CheckStatus objStatus, DateTime dtStatusDate
            , string strStatusComment, BankBiz objCollectingBank)
        {
            if (objCollectingBank == null || objStatus != CheckStatus.Collected)
                objCollectingBank = new BankBiz();
            CheckDb objCheckDb = new CheckDb();
            objCheckDb.Status = (int)objStatus;
            objCheckDb.IDs = IDsStr;
            objCheckDb.StatusDate = dtStatusDate;
            objCheckDb.StatusComment = strStatusComment;
            objCheckDb.CollectingBank = objCollectingBank.ID;
            objCheckDb.EditStatusForMultiple();

        }
        public virtual void MoveNext()
        {

            Clear();
            CheckDb objCheckDb = new CheckDb();
            GetSearchData(ref objCheckDb);
            objCheckDb.MaxID = _MaxID;
            objCheckDb.MinID = 0;
            DataTable dtTemp = objCheckDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new CheckBiz(objDr));
            _EnableNext = false;
            _EnablePrevious = false;
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "CheckID");
                objCheckDb = new CheckDb(arrDr[Count - 1]);
                _MaxID = objCheckDb.ID;
                objCheckDb = new CheckDb(arrDr[0]);
                _MinID = objCheckDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (Count == _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public virtual void MovePrevious()
        {


            Clear();
            CheckDb objCheckDb = new CheckDb();
            GetSearchData(ref objCheckDb);
            objCheckDb.MinID = _MinID;
            DataTable dtTemp = objCheckDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new CheckBiz(objDr));
            _EnableNext = false;
            _EnablePrevious = false;
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "CheckID");
                objCheckDb = new CheckDb(arrDr[Count - 1]);
                _MaxID = objCheckDb.ID;
                objCheckDb = new CheckDb(arrDr[0]);
                _MinID = objCheckDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public double GetValue(List<int> arrInt)
        {
            double Returned = 0;
            foreach (int intIndex in arrInt)
            {
                Returned += this[intIndex].Value;
            }
            return Returned;
        }
        public double GetCollectedValue(List<int> arrInt)
        {
            double Returned = 0;
            foreach (int intIndex in arrInt)
            {
                Returned += this[intIndex].CollectedValue;
            }
            return Returned;
        }
        public CheckCol GetFreeCol()
        {
            CheckCol Returned = new CheckCol(true);
            foreach (CheckBiz objBiz in this)
            {
                if (objBiz.Value - objBiz.TotalPayment > 0)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        public CheckCol GetCol(string strCode)
        {
            CheckCol Returned = new CheckCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blOk = true;
            foreach (CheckBiz objBiz in this)
            {
                blOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Code.IndexOf(strTemp) == -1)
                    {
                        blOk = false;
                        break;
                    }
                }
                if (blOk)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetCheckTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("CheckID"), new DataColumn("كود الشيك"),new DataColumn("المستفيد"),
                new DataColumn("البنك"),
                new DataColumn("تاريخ استحقاق"),new DataColumn("قيمة الشيك"),new DataColumn("حالة الشيك"),new DataColumn("تاريخ الحالة"),
                new DataColumn("العملة"),new DataColumn("القيمة المدفوعة"),new DataColumn( "وصف "),new DataColumn("مكان الشيك")});
            DataRow objDr;
            foreach (CheckBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr[0] = objBiz.ID.ToString();
                objDr[1] = objBiz.Code;
                objDr[2] = objBiz.EditorName;
                objDr[3] = objBiz.BankBiz.Name;
                objDr[4] = objBiz.DueDate.ToString("yyyy-MM-dd");
                objDr[5] = objBiz.Value.ToString();
                objDr[6] = objBiz.StatusStr;
                objDr[7] = objBiz.StatusDate.ToString("yyyy-MM-dd");
                objDr[8] = objBiz.CurrencyBiz.Name;
                objDr[9] = objBiz.TotalPayment.ToString("0.0");
                objDr[10] = objBiz.MaxPaymentDesc;
                objDr[11] = objBiz.PlaceBiz.Name;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CheckID"),new DataColumn("CheckBank"),
                new DataColumn("CheckCode"),
                new DataColumn("CheckNote")
            ,new DataColumn("CheckEditorName"),new DataColumn("CheckBeneficiaryName"),
                new DataColumn("AttachmentID"),new DataColumn("CheckCurrency"),
                new DataColumn("CheckValue")
            ,new DataColumn("CheckType"),new DataColumn("CheckDueDate"),new DataColumn("CheckIssueDate"),
                new DataColumn("CheckCurrentStatus"),new DataColumn("CheckCurrentStatusDate")
            ,new DataColumn("CheckTransactionID"),new DataColumn("CheckIsBankOriented",System.Type.GetType("System.Bool")),
                new DataColumn("CheckAccountID"),new DataColumn("ChcekCurrentPlace")
           ,new DataColumn("CheckParentID"),new DataColumn("BankSubmissionDate"),
                new DataColumn("CheckDirection")});
            DataRow objDr = Returned.NewRow();
            foreach (CheckBiz objBiz in this)
            {
                objDr["CheckID"] = objBiz.ID.ToString();
                objDr["CheckBank"] = objBiz.BankBiz.ID.ToString();
                objDr["CheckCode"] = objBiz.Code;
                objDr["CheckNote"] = objBiz.CheckNote;
                objDr["CheckEditorName"] = objBiz.EditorName;
                objDr["CheckBeneficiaryName"] = objBiz.BeneficialName;
                objDr["AttachmentID"] = objBiz.AttachmentBiz.ID;
                objDr["CheckCurrency"] = objBiz.CurrencyBiz.ID;
                objDr["CheckValue"] = objBiz.Value;
                objDr["CheckType"] = (int)objBiz.Type;
                objDr["CheckDueDate"] = objBiz.DueDate;
                objDr["CheckIssueDate"] = objBiz.IssueDate;
                objDr["CheckCurrentStatus"] = (int)objBiz.Status;
                objDr["CheckCurrentStatusDate"] = objBiz.StatusDate;
                objDr["CheckTransactionID"] = objBiz.TransactionID;
                objDr["CheckIsBankOriented"] = objBiz.IsBankOriented ? "1" : "0";
                objDr["CheckAccountID"] = objBiz.GLAccountBiz.ID;
                objDr["ChcekCurrentPlace"] = objBiz.PlaceBiz.ID;
                objDr["CheckParentID"] = objBiz.ParentID;
                objDr["BankSubmissionDate"] = objBiz.SubmissionDate;
                objDr["CheckDirection"] = objBiz.Direction ? "1" : "0";

                Returned.Rows.Add(objDr);
            }

            return Returned;
        }
        public void Save()
        {
            foreach (CheckBiz objBiz in this)
            {
                if (objBiz.ID == 0)
                    objBiz.Add();
                else
                    objBiz.Edit();
            }
        }
        public void Print(CheckModelBiz objModelBiz)
        {
            CheckDb objDb = new CheckDb();
            objDb.IDs = IDsStr;
            objDb.PrintModelID = objModelBiz.ID;
            objDb.Print();

            foreach (CheckBiz objBiz in this)
            {
                objBiz.LastPrintID = 1;
            }
        }
        public void SetPaymentData()
        {
            PaymentCol objCol;
            foreach (CheckBiz objBiz in this)
                objBiz.PaymentCol = new PaymentCol(true);
            CheckDb objCheckDb = new CheckDb();
            if (Count > 500)

            {
                objCheckDb.CheckIDTable = GetCheckUserTable();
                objCheckDb.SetCheckIDTableStr();
            }
            else
            {
                objCheckDb.CheckIDTable = null;

                CheckDb.CheckIDs = IDsStr;
            }

            DataTable dtTemp = CheckDb.CachePaymentTable;
            PaymentBiz objPayment;

            DataRow[] arrDR = dtTemp.Select("", "CheckID");
            CheckBiz objCheckBiz = new CheckBiz();

            foreach (DataRow objDr in arrDR)
            {
                objPayment = new PaymentBiz(objDr, false);
                if (objPayment.CheckID != objCheckBiz.ID)
                {
                    if (_CheckHs[objPayment.CheckID.ToString()] != null)
                    {

                        objCheckBiz = (CheckBiz)_CheckHs[objPayment.CheckID.ToString()];
                    }
                    else
                        continue;
                }
                objPayment.CheckBiz = objCheckBiz;
                objCheckBiz.AddPayment(objPayment);
            }
            //foreach (CheckBiz objBiz in this)
            //{
            //    objCol = objBiz.PaymentCol;
            //}
        }
        public void SetPresentToBank(bool blPresentToBank)
        {
            CheckDb objDb = new CheckDb();
            objDb.IsBankOrieneted = blPresentToBank;
            objDb.IDs = IDsStr;
            objDb.SetCheckIsbankOriented();

        }
        public static CheckCol GetCheckByIDs(string strIDs)
        {
            CheckCol Returned = new CheckCol(true);
            CheckDb objDb = new CheckDb() { IDs = strIDs };
            if(strIDs!= null&& strIDs!= "")
            {
                DataTable dtTemp = objDb.Search();
                foreach(DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new CheckBiz(objDr));
                }
            }
       
            return Returned;
        }
    }
}
