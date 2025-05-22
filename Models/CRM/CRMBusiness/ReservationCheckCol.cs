using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCheckCol : CheckCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationCheckCol(bool blISEmpty)
        { }
        public ReservationCheckCol(int intReservation,bool blCheckDirection)
        {
            CheckDb objDb = new CheckDb() { ReservationID = intReservation,Direction=blCheckDirection };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationCheckBiz(objDr));

            }
        }
        public ReservationCheckCol()
        { }
        public ReservationCheckCol(string strStatus, string strEditorName, string strCode, string strNote, bool blIssueRange, DateTime dtStartIssueDate,
          DateTime dtEndIssueDate, bool blDueRange, DateTime dtStartDueDate, DateTime dtEndDueDate,
          bool blStatusDateRange, DateTime dtStartStatusDate, DateTime dtEndStatusDate,
          BankBiz objBankBiz, CurrencyBiz objCurrencyBiz, CheckStatus objStatus, CofferCol objCofferCol, CofferBiz objOldCofferBiz, int intCollectingPaymentStatus,
          CheckType objType, bool blStatusVal, double dblFromVal, double dblToVal, bool blMaxDateLimited, DateTime dtMaxlimitDate, bool blIsSubmissionRange,
          DateTime dtStartSubmissionDate, DateTime dtEndSubmissionDate, AccountBankBiz objBankAccountBiz, int intOrientedStatus,
          bool blDirection, int intCellFamilyID, string strCellIDs, int intCampaignID, int intResubmissionID, int intHasPaymentStatus,
            bool blPaymentRange, DateTime dtStartPaymentDate,
            DateTime dtEndPaymentDate, ReservationBiz objReservationBiz
            , InstallmentTypeCol objInstallmentTypeCol, bool blIgnoreType, string strCheckIDs,
            int intCheckMultipleInstallment, int intCheckMultipleReservation)
        {
            if (objInstallmentTypeCol == null)
                objInstallmentTypeCol = new InstallmentTypeCol(true);
            CheckDb objCheckDb = new CheckDb();
            SetDataInitially(strStatus, strEditorName, strCode, strNote, blIssueRange, dtStartIssueDate,
             dtEndIssueDate, blDueRange, dtStartDueDate, dtEndDueDate,
              blStatusDateRange, dtStartStatusDate, dtEndStatusDate,
              objBankBiz, objCurrencyBiz, objStatus, objCofferCol, objOldCofferBiz, intCollectingPaymentStatus, objType, blStatusVal,
              dblFromVal, dblToVal, blMaxDateLimited, dtMaxlimitDate, blIsSubmissionRange, dtStartSubmissionDate, dtEndSubmissionDate, objBankAccountBiz,
              intOrientedStatus, blDirection, intCellFamilyID, strCellIDs, intCampaignID, intResubmissionID, intHasPaymentStatus
              , blPaymentRange, dtStartPaymentDate, dtEndPaymentDate, blIgnoreType
              , objInstallmentTypeCol.IDsStr, strCheckIDs, intCheckMultipleInstallment, intCheckMultipleReservation);

            GetSearchData(ref objCheckDb);

            //  objCheckDb.HasPaymentStatus = 1;
            if (objReservationBiz == null)
                objReservationBiz = new ReservationBiz();
            objCheckDb.ReservationID = objReservationBiz.ID;
            DataTable dtTemp = objCheckDb.Search();
            _ResultCount = objCheckDb.ResultCount;
            _ResultValue = objCheckDb.ResultValue;
            ReservationCheckBiz objCheckBiz;
            DataRow[] arrMainDr = dtTemp.Select("", "CheckEditorName,CheckDueDate");
            foreach (DataRow objDr in arrMainDr)
            {
                objCheckBiz = new ReservationCheckBiz(objDr);
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
        #endregion
        #region Public Properties
        public ReservationCheckBiz this[int intIndex]
        {
            get
            {
                return (ReservationCheckBiz)List[intIndex];
            }
        }
        public List<string> IDLst
        {
            get
            {
                List<string> Returned = new List<string>();
                foreach (ReservationCheckBiz objBiz in this)
                {
                    Returned.Add(objBiz.ID.ToString());
                }
                return Returned;
            }
        }
        ReservationPaymentCol _PaymentCol;

        public ReservationPaymentCol PaymentCol
        {
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new ReservationPaymentCol(true);
                    ReservationPaymentDb objDb = new ReservationPaymentDb();
                    objDb.LinearCheckIDs = IDsStr;
                    objDb.AllCollectedOrNotCollected = true;
                    objDb.IncludeAdministrativePayment = true;
                    objDb.IncludeDirectPayment = true;
                    objDb.IncludeInstallmentPayment = true;
                    objDb.IncludeInsurancePayment = true;
                    objDb.IncludeMulctPayment = true;
                    objDb.IncludePayBackPayment = true;
                    objDb.IncludeTempPayment = true;

                    DataTable dtTemp = objDb.Search();

                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _PaymentCol.Add(new ReservationPaymentBiz(objDr));

                    }
                }
                return _PaymentCol;
            }
            set { _PaymentCol = value; }
        }
        #endregion
        #region Private Methods
        protected override void GetSearchData(ref CheckDb objCheckDb)
        {
            base.GetSearchData(ref objCheckDb);
            objCheckDb.IgnoreInstallmentType = _IgnoreInstallmentType;
            objCheckDb.InstallmentTypeIDs = _InstallmentTypeIDs;
            objCheckDb.MultipleInstallmentStatus = _CheckMultipleInstallment;
            objCheckDb.MultipleReservationStatus = _CheckMultipleReservation;

        }
        protected void SetDataInitially(string strStatus, string strEditorName, string strCode, string strNote, bool blIssueRange, DateTime dtStartIssueDate,
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
         bool blIgnoreInstallmentType, string strInstallmentType
            , string strIDs, int intCheckMultipleInstallment, int intCheckMultipleReservation)
        {
            SetDataInitially(strStatus, strEditorName, strCode, strNote, blIssueRange, dtStartIssueDate,
          dtEndIssueDate, blDueRange, dtStartDueDate, dtEndDueDate,
          blStatusRange, dtStartStatusDate, dtEndStatusDate,
          objBankBiz, objCurrencyBiz,
          objStatus, objCofferCol, objOldCofferBiz, intCollectingPaymentStatus,
          objType, blStatusValue, dblFromCheckVal, dblToCheckVal,
          blMaxLimitStatus, dtMaxLimitDate, blIsSubmissionRange,
          dtStartSubmissionDate, dtEndSubmissionDate, objBankAccountBiz, intOrientedStatus,
          blDirection, intCellFamilyID, strCellIDs, intCampaignID,
         intResubmissionID, intHasPaymentStatus, blIsPaymentRange,
         dtStartPaymentDate, dtEndPaymentDate,
         blIgnoreInstallmentType, strInstallmentType
            , strIDs, 0);
            _CheckMultipleInstallment = intCheckMultipleInstallment;
            _CheckMultipleReservation = intCheckMultipleReservation;


        }
        #endregion
        #region Public Methods
        public void Add(ReservationCheckBiz objBiz)
        {
            if (objBiz.ID == 0 || _CheckHs[objBiz.ID.ToString()] == null)
            {
                List.Add(objBiz);
                if (objBiz.ID > 0)
                    _CheckHs.Add(objBiz.ID.ToString(), objBiz);
            }

        }
        public void AddCol(ReservationCheckCol objCol)
        {
            foreach (ReservationCheckBiz objCheckBiz in objCol)
            {
                Add(objCheckBiz);
            }
        }
        public DataTable GetCheckTable1()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("كود الشيك"),new DataColumn("المستفيد"),
                new DataColumn("البنك"),
                new DataColumn("تاريخ استحقاق"),new DataColumn("قيمة الشيك"),new DataColumn("حالة الشيك"),
                new DataColumn("العملة"),new DataColumn("القيمة المدفوعة"),new DataColumn( "وصف "),
                new DataColumn("مكان الشيك"),new DataColumn("المشروع"),new DataColumn("البرج"),new DataColumn("الوحدة"),new DataColumn("العميل")});
            DataRow objDr;
            foreach (ReservationCheckBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr[0] = objBiz.Code;
                objDr[1] = objBiz.EditorName;
                objDr[2] = objBiz.BankBiz.Name;
                objDr[3] = objBiz.DueDate.ToString("yyyy-MM-dd");
                objDr[4] = objBiz.Value.ToString();
                objDr[5] = objBiz.StatusStr;
                objDr[6] = objBiz.CurrencyBiz.Name;
                objDr[7] = objBiz.TotalPayment.ToString("0.0");

                objDr[9] = objBiz.PlaceBiz.Name;
                if (objBiz.ReservationPaymentCol.Count > 0)
                {
                    objDr[8] = objBiz.ReservationPaymentCol[0].PaymentDesc;
                    objDr[10] = objBiz.ReservationPaymentCol[0].ProjectName;
                    objDr[11] = objBiz.ReservationPaymentCol[0].TowerName;
                    objDr[12] = objBiz.ReservationPaymentCol[0].UnitStr;
                    objDr[13] = objBiz.ReservationPaymentCol[0].CustomerStr;
                }
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }

        public DataTable GetCheckTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("رقم"), new DataColumn("كود الشيك"),new DataColumn("المحرر"),new DataColumn("المستفيد"),
                new DataColumn("البنك"),
                new DataColumn("تاريخ استحقاق"),new DataColumn("قيمة الشيك"),new DataColumn("حالة الشيك"),
                new DataColumn("العملة"),new DataColumn("القيمة المستحقة"),
                new DataColumn( "القيمة المحصلة "),
                new DataColumn("مكان الشيك"),new DataColumn("المشروع"),new DataColumn("البرج"),new DataColumn("تم تسليم البرج"),new DataColumn("الوحدة"),
                new DataColumn("العميل"),new DataColumn("التسليم"),
              new DataColumn("MaxInstallmentDueDate"),new DataColumn("MinInstallmentDueDate")
              ,new DataColumn("CheckInstallmentCount"),new DataColumn("CheckReservationCount")
              ,new DataColumn("TotalMonthCount")});
            DataRow objDr;
            Hashtable hsTemp = new Hashtable();
            string strTemp = "";
            bool blIsNewRow = false;
            double dblTemp = 0;
            foreach (ReservationCheckBiz objBiz in this)
            {

                foreach (ReservationPaymentBiz objPaymentBiz in objBiz.ReservationPaymentCol)
                {
                    strTemp = objBiz.ID.ToString() + objPaymentBiz.ReservationID.ToString();
                    if (hsTemp[strTemp] == null)
                    {
                        objDr = Returned.NewRow();
                        blIsNewRow = true;
                    }
                    else
                    {
                        blIsNewRow = false;
                        objDr = (DataRow)hsTemp[strTemp];
                    }
                    objDr[0] = objBiz.ID.ToString();
                    objDr[1] = "#" + objBiz.Code + "#";
                    objDr[2] = objBiz.EditorName;
                    objDr[3] = objBiz.BeneficialName;
                    objDr[4] = objBiz.BankBiz.Name;
                    objDr[5] = objBiz.DueDate.ToString("yyyy-MM-dd");
                    objDr[6] = objBiz.Value.ToString();
                    objDr[7] = objBiz.StatusStr;
                    objDr[8] = objBiz.CurrencyBiz.Name;
                    dblTemp = 0;
                    if (!blIsNewRow)
                        double.TryParse(objDr[9].ToString(), out dblTemp);
                    objDr[9] = (objPaymentBiz.PaymentValue + dblTemp).ToString("0.0");
                    dblTemp = 0;
                    if (!blIsNewRow)
                        double.TryParse(objDr[10].ToString(), out dblTemp);

                    objDr[10] = ((objPaymentBiz.CheckIsCollected ? objPaymentBiz.PaymentValue : 0) + dblTemp).ToString("0.0");
                    objDr[11] = objBiz.PlaceBiz.Name;
                    //if (objBiz.ReservationPaymentCol.Count > 0)
                    //{
                    // objDr[8] = objPaymentBiz.PaymentDesc;
                    objDr[12] = objPaymentBiz.ProjectName;
                    objDr[13] = objPaymentBiz.TowerName;
                    objDr[14] = objPaymentBiz.TowerIsDelivered ? objPaymentBiz.TowerDeliveryDate.ToString("yyyy-MM-dd") : "";
                    objDr[15] = objPaymentBiz.UnitStr;
                    objDr[16] = objPaymentBiz.CustomerStr;
                    objDr[17] = objPaymentBiz.UnitIsDelivered ? "تم التسليم" : "لم يتم التسليم";
                    //}
                    objDr["MaxInstallmentDueDate"] = objBiz.CheckInstallmentCount == 0 ? "" : objBiz.MaxInstallmentDueDate.ToString("yyyy-MM-dd");
                    objDr["MinInstallmentDueDate"] = objBiz.CheckInstallmentCount == 0 ? "" : objBiz.MinInstallmentDueDate.ToString("yyyy-MM-dd");
                    objDr["CheckInstallmentCount"] = objBiz.CheckInstallmentCount.ToString();
                    objDr["CheckReservationCount"] = objBiz.CheckReservationCount.ToString();
                    objDr["TotalMonthCount"] = objBiz.TotalMonthCount.ToString();


                    if (blIsNewRow)
                    {
                        Returned.Rows.Add(objDr);
                        hsTemp.Add(strTemp, objDr);
                    }
                }

            }
            hsTemp.Clear();
            //Returned = Returned.Select("","1,2,3").
            return Returned;
        }
        public void SetPaymentData()
        {
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            objDb.CheckIDs = IDsStr;
            string strTempCheck = " SELECT  CheckID " +
              " FROM            dbo.GLCheck " +
               " WHERE        (CheckID IN (" + IDsStr + "))";
            objDb.CheckIDs = strTempCheck;
            // objDb.CheckIDs = CheckDb.CheckIDTable;
            objDb.AllCollectedOrNotCollected = true;
            objDb.IncludeAdministrativePayment = true;
            objDb.IncludeDirectPayment = true;
            objDb.IncludeInstallmentPayment = true;
            objDb.IncludeInsurancePayment = true;
            objDb.IncludeMulctPayment = true;
            objDb.IncludeTempPayment = true;
            objDb.MaxID = -1;
            objDb.ContainsNonCollectedCheck = true;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach (ReservationCheckBiz objBiz in this)
            {
                arrDr = dtTemp.Select("CheckID=" + objBiz.ID);
                objBiz.ReservationPaymentCol = new ReservationPaymentCol(true);
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.ReservationPaymentCol.Add(new ReservationPaymentBiz(objDr));
                }
            }

        }
        public override void MoveNext()
        {

            Clear();
            CheckDb objCheckDb = new CheckDb();
            GetSearchData(ref objCheckDb);
            objCheckDb.MaxID = _MaxID;
            objCheckDb.MinID = 0;
            DataTable dtTemp = objCheckDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ReservationCheckBiz(objDr));
            _EnableNext = false;
            _EnablePrevious = false;
            if (Count > 0)
            {
                if (Count < 9999)
                {
                }
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
        public override void MovePrevious()
        {


            Clear();
            CheckDb objCheckDb = new CheckDb();
            GetSearchData(ref objCheckDb);
            objCheckDb.MinID = _MinID;
            DataTable dtTemp = objCheckDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ReservationCheckBiz(objDr));
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
        public static ReservationCheckCol GetCheckByIDs(string strIDs)
        {
            ReservationCheckCol Returned = new ReservationCheckCol(true);
            CheckDb objDb = new CheckDb() { IDs = strIDs };
            if (strIDs != null && strIDs != "")
            {
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new ReservationCheckBiz(objDr));
                }
            }

            return Returned;
        }
        #endregion
    }
}
