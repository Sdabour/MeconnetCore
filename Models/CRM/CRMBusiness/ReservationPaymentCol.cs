using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationPaymentCol : CollectionBase
    {
        #region Private Data
        int _MaxCount = 1000;
        int _ResultCount = 0;
        double _ResultValue;
        double _ResultDiscountValue;
        int _TheMinID;
        int _MaxID;
        int _MinID;
        int _CurrentIndex;
        bool _EnableNext;
        bool _EnablePrevious;
        #region Private Data for Search
        bool _IsPaymentDateStatus;
        DateTime _StartPaymentDate;
        DateTime _EndPaymentDate;
        bool _IsDueDateStatus;
        DateTime _StartDueDate;
        DateTime _EndDueDate;
        bool _RegisterationDateRange;
        DateTime _StartRegestrationDate;
        DateTime _EndRegisterationDate;
        bool _IncludeInstallmentPayment;
        bool _IncludeTempPayment;
        bool _IncludeAdministrativePayment;
        bool _IncludeMulctPayment;
        bool _IncludePayBackPayment;
        bool _IncludeDirectPayment;

        bool _IncludeInsurancePayment;
        bool _IncludeMaintainancePayment;
        int _OnlyHasCheckStatus;
        int _ReservationStatus;
        int _GLTransactionStatus;
        CellBiz _CellBiz;
        string _InstallmentTypeIDs;
        string _UnitCode;
        bool _ContainNonCollectedCheck;
        int _EmployeeID;
        int _BranchID;
        int _ReservationID;
        int _CustomerID;
        int _ReceiptStatus;
        int _ReceiptID;
        string _ReceiptCode;
        int _DeleteStatus;
        #endregion
        #endregion
        #region Constructors
        public ReservationPaymentCol(bool blIsEmpty)
        {

        }
        public ReservationPaymentCol(ReservationBiz objBiz)
        {
            if (objBiz == null)
                objBiz = new ReservationBiz();
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            objDb.ReservationID = objBiz.ID;
            objDb.IncludeAdministrativePayment = true;
            objDb.IncludeInstallmentPayment = true;
            objDb.IncludeMulctPayment = true;
            objDb.IncludePayBackPayment = true;
            objDb.IncludeInsurancePayment = true;
            objDb.IncludeTempPayment = true;
            objDb.AllCollectedOrNotCollected = true;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "PaymentTimIns");
            foreach (DataRow objDr in arrDr)
            {
                Add(new ReservationPaymentBiz(objDr));
            }
        }
        public ReservationPaymentCol(bool blIsPaymentDateStatus,
            DateTime dtStartPayment, DateTime dtEndPayment, bool blIsDueDate, DateTime dtStartDue, DateTime dtEndDue,
            bool blIncludeInstallmentPayment, bool blIncludeTempPayment, bool blIncludeMulctPayment,
            bool blIncludePaybackPayment, bool blIncludeAdministrativePayment, bool blIncludeDirectPayment, bool blIncludeInsurancePayment
            , bool blIncludeMaintainancePayment
            , int intOnlyHasCheckStatus, string strUnitCode, CellBiz objCellBiz,
            int intReservationStatus, int intGlTransactionStatus, bool blContainsNonCollectedCheck,
            InstallmentTypeCol objTypeCol, int intEmployeeID, int intBranchID,
            bool blRrgisterationDateRange, DateTime dtStartRegestrationDate,
            DateTime dtEndRegisterationDate, int intReservationID, int intCustmer, int intReceiptStatus,
            int intReceiptID, string strReceiptCode, int intDeleteStatus, ResubmissionTypeCol objResubmissionTypeCol
            , bool blResubmissionDateRange,
    DateTime dtResubmissionStart,
    DateTime dtResubmissionEnd,
    string strResubmissionSerial, bool blResubmissionAlertDateRange,
    DateTime dtResubmissionAlertStart,
    DateTime dtResubmissionAlertEnd)
        {
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            #region Resubmission
            if (objResubmissionTypeCol == null)
                objResubmissionTypeCol = new ResubmissionTypeCol(true);
            objDb.ResubmissionAlertDateRange = blResubmissionAlertDateRange;
            objDb.ResubmissionAlertEndDate = dtResubmissionAlertEnd;
            objDb.ResubmissionAlertStartDate = dtResubmissionAlertStart;
            objDb.ResubmissionDateRange = blResubmissionDateRange;
            objDb.ResubmissionEndDate = dtResubmissionEnd;
            objDb.ResubmissionIDs = objResubmissionTypeCol.IDs;
            objDb.ResubmissionSerial = strResubmissionSerial;
            objDb.ResubmissionStartDate = dtResubmissionStart;
            #endregion
            // objDb.
            SetInitiallyData(blIsPaymentDateStatus, dtStartPayment, dtEndPayment, blIsDueDate, dtStartDue, dtEndDue,
                blIncludeInstallmentPayment, blIncludeTempPayment, blIncludeMulctPayment,
                blIncludePaybackPayment, blIncludeAdministrativePayment, blIncludeDirectPayment, blIncludeInsurancePayment, blIncludeMaintainancePayment,
                intOnlyHasCheckStatus, strUnitCode, objCellBiz, intReservationStatus,
                intGlTransactionStatus, blContainsNonCollectedCheck, objTypeCol, intEmployeeID, intBranchID,
                 blRrgisterationDateRange, dtStartRegestrationDate,
                 dtEndRegisterationDate, intReservationID, intCustmer, intReceiptStatus, intReceiptID, strReceiptCode, intDeleteStatus);
            GetSearchData(ref objDb);
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "PaymentTimIns");
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            foreach (DataRow objDr in arrDr)
            {
                Add(new ReservationPaymentBiz(objDr));
            }
            if (Count > 0)
            {
                arrDr = dtTemp.Select("", "PaymentID");
                objDb = new ReservationPaymentDb(arrDr[Count - 1]);
                _MaxID = objDb.PaymentID;
                objDb = new ReservationPaymentDb(arrDr[0]);
                _MinID = objDb.PaymentID;
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
        public ReservationPaymentBiz this[int intIndex]
        {
            get
            {
                return (ReservationPaymentBiz)List[intIndex];
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
        public ReservationCheckCol CheckCol
        {
            get
            {
                Hashtable hsTemp = new Hashtable();
                ReservationCheckCol Returned = new ReservationCheckCol(true);
                ReservationCheckBiz objCheckBiz;
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID != 0)
                    {
                        if (hsTemp[objBiz.CheckBiz.ID.ToString()] == null)
                        {
                            objCheckBiz = objBiz.CheckBiz;
                            hsTemp.Add(objBiz.CheckBiz.ID.ToString(), objCheckBiz);
                            objCheckBiz.ReservationPaymentCol.Add(objBiz);
                            Returned.Add(objCheckBiz);
                        }
                        else
                        {
                            objCheckBiz = (ReservationCheckBiz)hsTemp[objBiz.CheckBiz.ID.ToString()];
                            objCheckBiz.ReservationPaymentCol.Add(objBiz);
                        }

                    }
                }
                return Returned;
            }
        }
        public string Project
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.ProjectName] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.ProjectName;
                    hsTemp.Add(objBiz.ProjectName, objBiz.ProjectName);
                }
                return Returned;
            }
        }
        public bool Direction
        {
            get
            {
                bool Returned = true;

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    return objBiz.PaymentDirection;
                }
                return Returned;
            }
        }
        public int ProjectID
        {
            get
            {
                int Returned = 0;

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    return objBiz.ProjectID;
                }
                return Returned;
            }
        }
        public string Tower
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.TowerName] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.TowerName;
                    hsTemp.Add(objBiz.TowerName, objBiz.TowerName);
                }
                return Returned;
            }
        }
        public string UnitCode
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.UnitStr] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.UnitStr;
                    hsTemp.Add(objBiz.UnitStr, objBiz.UnitStr);
                }
                return Returned;
            }
        }
        public string UnitName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.UnitNameStr] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.UnitNameStr;
                    hsTemp.Add(objBiz.UnitNameStr, objBiz.UnitNameStr);
                }
                return Returned;
            }
        }
        public string EmployeeName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.EmployeeName] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.EmployeeName;
                    hsTemp.Add(objBiz.EmployeeName, objBiz.EmployeeName);
                }
                return Returned;
            }
        }
        public string EmployeeShortName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.EmployeeName] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.EmployeeShortName;
                    hsTemp.Add(objBiz.EmployeeName, objBiz.EmployeeName);
                }
                return Returned;
            }
        }
        public int EmployeeID
        {
            get
            {
                int Returned = 0;

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.EmployeeID != 0)
                        return objBiz.EmployeeID;
                }
                return Returned;
            }
        }
        public int BranchID
        {
            get
            {
                int Returned = 0;

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.BranchID != 0)
                        return objBiz.BranchID;
                }
                return Returned;
            }
        }
        public string BranchName
        {
            get
            {
                string Returned = "";

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.BranchName != null && objBiz.BranchName != "")
                        return objBiz.BranchName;
                }
                return Returned;
            }
        }
        public double Value
        {
            get
            {
                double Returned = 0;


                foreach (ReservationPaymentBiz objBiz in this)
                {

                    Returned += objBiz.PaymentValue;

                }
                return Returned;
            }
        }
        public string Customer
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.CustomerStr] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.CustomerStr;
                    hsTemp.Add(objBiz.CustomerStr, objBiz.CustomerStr);
                }
                return Returned;
            }
        }
        public string Desc
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                string strTemp = "";
                double dblValue = 0;
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    strTemp = objBiz.PaymentDesc == null || objBiz.PaymentDesc == "" ?
                        objBiz.PaymentTypeStr : objBiz.PaymentDesc;
                    if (objBiz.Type == ReservationPaymentType.Installment)
                    {
                        strTemp = "";
                        dblValue = objBiz.InstallmentValue - objBiz.InstallmentDiscount;
                        if (dblValue > objBiz.PaymentValue + 1 &&
                            (objBiz.InstallmentRemainingValue > 1 || objBiz.InstallmentLastPaymentID != objBiz.PaymentID))
                            strTemp += "ÌÒÁ ãä ";
                        else if (dblValue > objBiz.PaymentValue + 1 &&
                            (objBiz.InstallmentRemainingValue <= 1 && objBiz.PaymentID == objBiz.InstallmentLastPaymentID))
                            strTemp += "ÈÇÞì ÞíãÉ ";
                        strTemp += objBiz.InstallmentTypeNameA + " ãÓÊÍÞ ÈÊÇÑíÎ " + objBiz.InstallmentDueDate.ToString("dd/MM/yyyy");
                    }
                    if (hsTemp[strTemp] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";

                    Returned += strTemp;
                    hsTemp.Add(strTemp, objBiz.PaymentDesc);
                }
                return Returned;
            }
        }
        public string PaymentMean
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                string strType = "";
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID != 0 && !objBiz.CheckIsCollected)
                        strType = PaymentBiz.TypeStrLst[(int)PaymentType.Check];
                    else if (objBiz.PaymentMean != PaymentType.Check)
                        strType = PaymentBiz.TypeStrLst[(int)objBiz.PaymentMean];
                    else if (objBiz.PaymentMean == PaymentType.Check && objBiz.CheckBiz.ID == 0)
                        strType = PaymentBiz.TypeStrLst[(int)PaymentType.Cash];


                    if (hsTemp[strType] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";

                    Returned += strType;

                    hsTemp.Add(strType, strType);
                }
                return Returned;
            }
        }
        public string InstallmentDueDate
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.InstallmentDueDate.ToString("dd/MM/yyyy")] == null)
                    {
                        hsTemp.Add(objBiz.InstallmentDueDate.ToString("dd/MM/yyyy"), objBiz.InstallmentDueDate);
                        if (Returned != "")
                            Returned += "-";
                        Returned += objBiz.InstallmentDueDate.ToString("dd/MM/yyyy");
                    }
                }
                return Returned;
            }
        }
        public string CheckCode
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();

                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID == 0 || objBiz.CheckBiz.Code == "")
                        continue;
                    if (hsTemp[objBiz.CheckBiz.Code] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    else
                        Returned += "Ôíß :";
                    Returned += objBiz.CheckBiz.Code + "-" + objBiz.CheckBiz.BankBiz.Name + "-" +
                        "ãÓÊÍÞ ÈÊÇÑíÎ:" + objBiz.CheckBiz.DueDate.ToString("dd/MM/yyyy"); ;

                    hsTemp.Add(objBiz.CheckBiz.Code, objBiz.CheckBiz.Code);
                }
                return Returned;
            }
        }
        public string PaymentEffect
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                string strNoEffect = "áÇ íÚÊÏ ÈåÐå ÇáÞÓíãÉ ÇáÇ ÈÚÏ ÊÍÕíá ÞíãÉ ÇáÔíß";
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID == 0 || objBiz.CheckBiz.Code == "" || objBiz.CheckBiz.Status != CheckStatus.Postponeded)
                        continue;
                    if (hsTemp[strNoEffect] != null)
                        continue;
                    if (Returned != "")
                        Returned += " - ";
                    Returned += strNoEffect;
                    hsTemp.Add(strNoEffect, strNoEffect);
                }
                return Returned;
            }
        }
        public string InstallmentDiscount
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                double dblDiscount = 0;
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.InstallmentDiscount > 0 && hsTemp[objBiz.InstallmentID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.InstallmentID.ToString(), objBiz.InstallmentID);
                        dblDiscount += objBiz.InstallmentDiscount;



                    }
                }
                if (dblDiscount > 0)
                    Returned = "ÎÕã ÈÞíãÉ :" +
                        dblDiscount.ToString() + "(" + SysUtility.NumToStr(dblDiscount) + ")";
                return Returned;
            }
        }
        public ReservationCol ReservationCol
        {
            get
            {
                ReservationCol Returned = new ReservationCol(true);
                Hashtable hsTemp = new Hashtable();
                ReservationBiz objReservationBiz = new ReservationBiz();
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (hsTemp[objBiz.ReservationID.ToString()] == null)
                    {
                        objReservationBiz = new ReservationBiz();
                        objReservationBiz.ID = objBiz.ReservationID;
                        objReservationBiz.FloorID = objBiz.CellID;
                        objReservationBiz.DirectCustomerStr = objBiz.CustomerStr;
                        objReservationBiz.DirectUnitNameStr = objBiz.UnitNameStr;
                        //objReservationBiz.DirectUnitSurveyStr =objBiz.units
                        Returned.Add(objReservationBiz);
                        hsTemp.Add(objBiz.ReservationID.ToString(), objReservationBiz);

                    }
                    else
                        objReservationBiz = (ReservationBiz)hsTemp[objBiz.ReservationID.ToString()];
                    objReservationBiz.ReservationPaymentCol.Add(objBiz);
                }
                return Returned;
            }
        }
        public TransactionCol TransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.TransactionBiz.ElementCol.Count > 0)
                        Returned.Add(objBiz.TransactionBiz);
                }
                return Returned;
            }
        }
        public ReservationPaymentCol NonReceiptedPaymentCol
        {
            get
            {
                ReservationPaymentCol Returned = new ReservationPaymentCol(true);
                foreach (ReservationPaymentBiz objBiz in this)
                {
                    if (objBiz.ReceiptBiz.ID == 0 && objBiz.HasReceipt)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetInitiallyData(bool blIsPaymentDateStatus,
            DateTime dtStartPayment, DateTime dtEndPayment, bool blIsDueDate, DateTime dtStartDue, DateTime dtEndDue,
            bool blIncludeInstallmentPayment, bool blIncludeTempPayment, bool blIncludeMulctPayment,
            bool blIncludePaybackPayment, bool blIncludeAdministrativePayment, bool blIncludeDirectPayment,
            bool blIncludeInsurancePayment, bool blIncludeMaintainancePayment, int intOnlyHasCheckStatus,
            string strUnitCode, CellBiz objCellBiz, int intReservationStatus, int intGlTransactionStatus,
            bool blContainsNonCollectedCheck, InstallmentTypeCol objTypeCol, int intEmployeeID, int intBranchID,
             bool blRrgisterationDateRange, DateTime dtStartRegestrationDate,
            DateTime dtEndRegisterationDate, int intReservationID, int intCustomerID,
            int intReceiptStatus, int intReceiptID, string strReceiptCode, int intDeleteStatus)
        {
            _IsPaymentDateStatus = blIsPaymentDateStatus;
            _StartPaymentDate = dtStartPayment;
            _EndPaymentDate = dtEndPayment;
            _IsDueDateStatus = blIsDueDate;
            _StartDueDate = dtStartDue;
            _EndDueDate = dtEndDue;
            _IncludeInstallmentPayment = blIncludeInstallmentPayment;
            _IncludeMulctPayment = blIncludeMulctPayment;
            _IncludePayBackPayment = blIncludePaybackPayment;
            _IncludeTempPayment = blIncludeTempPayment;
            _IncludeAdministrativePayment = blIncludeAdministrativePayment;
            _IncludeDirectPayment = blIncludeDirectPayment;
            _IncludeInsurancePayment = blIncludeInsurancePayment;
            _IncludeMaintainancePayment = blIncludeMaintainancePayment;
            _OnlyHasCheckStatus = intOnlyHasCheckStatus;
            _CellBiz = objCellBiz;
            _ReservationStatus = intReservationStatus;
            _GLTransactionStatus = intGlTransactionStatus;
            _UnitCode = strUnitCode;
            _ContainNonCollectedCheck = blContainsNonCollectedCheck;
            _EmployeeID = intEmployeeID;
            _BranchID = intBranchID;
            _RegisterationDateRange = blRrgisterationDateRange;
            _StartRegestrationDate = dtStartRegestrationDate;
            _EndRegisterationDate = dtEndRegisterationDate;
            if (objTypeCol == null)
                objTypeCol = new InstallmentTypeCol(true);
            _InstallmentTypeIDs = objTypeCol.IDsStr;
            _ReservationID = intReservationID;
            _CustomerID = intCustomerID;
            _ReceiptStatus = intReceiptStatus;
            _ReceiptID = intReceiptID;
            _ReceiptCode = strReceiptCode;
            _DeleteStatus = intDeleteStatus;

        }
        void GetSearchData(ref ReservationPaymentDb objDb)
        {
            objDb.IsPaymentDateStatus = _IsPaymentDateStatus;
            objDb.StartPaymentDate = _StartPaymentDate;
            objDb.EndPaymentDate = _EndPaymentDate;
            objDb.IsDueDateStatus = _IsDueDateStatus;
            objDb.StartDueDate = _StartDueDate;
            objDb.EndDueDate = _EndDueDate;
            objDb.IncludeInstallmentPayment = _IncludeInstallmentPayment;
            objDb.IncludeMulctPayment = _IncludeMulctPayment;
            objDb.IncludePayBackPayment = _IncludePayBackPayment;
            objDb.IncludeAdministrativePayment = _IncludeAdministrativePayment;
            objDb.IncludeTempPayment = _IncludeTempPayment;
            objDb.IncludeDirectPayment = _IncludeDirectPayment;
            objDb.IncludeInsurancePayment = _IncludeInsurancePayment;
            objDb.IncludeMaintainancePayment = _IncludeMaintainancePayment;
            objDb.OnlyHasCheckStatus = _OnlyHasCheckStatus;
            objDb.ReservationStatus = _ReservationStatus;
            objDb.GLTransactionStatus = _GLTransactionStatus;
            objDb.ContainsNonCollectedCheck = _ContainNonCollectedCheck;
            objDb.UnitCode = _UnitCode;
            objDb.EmployeeID = _EmployeeID;
            objDb.BranchID = _BranchID;
            objDb.InstallmentTypeIDs = _InstallmentTypeIDs;
            objDb.IsRegisterDateStatus = _RegisterationDateRange;
            objDb.StartRegisterDate = _StartRegestrationDate;
            objDb.EndRegisterDate = _EndRegisterationDate;
            if (_CellBiz == null)
                _CellBiz = new CellBiz();
            if (_CellBiz.ID == _CellBiz.FamilyID)
                objDb.CellFamilyID = _CellBiz.FamilyID;
            else
                objDb.CellIDs = _CellBiz.IDsStr;
            objDb.ReservationID = _ReservationID;
            objDb.CustomerID = _CustomerID;
            objDb.ReceiptStatus = _ReceiptStatus;
            objDb.ReceiptID = _ReceiptID;
            objDb.ReceiptCode = _ReceiptCode;
            objDb.DeleteStatus = _DeleteStatus;
        }

        #endregion
        #region Public Methods
        public void Add(ReservationPaymentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public void MoveNext()
        {

            Clear();
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            GetSearchData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();



            ReservationPaymentBiz ObjPaymentBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjPaymentBiz = new ReservationPaymentBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjPaymentBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "PaymentID");
                objDb = new ReservationPaymentDb(arrDr[Count - 1]);
                _MaxID = objDb.PaymentID;
                objDb = new ReservationPaymentDb(arrDr[0]);
                _MinID = objDb.PaymentID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (Count == _MaxCount)
            {
                _EnableNext = true;
            }
            else if (Count < _MaxCount)
                _EnableNext = false;


        }
        public void MovePrevious()
        {


            Clear();
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            GetSearchData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();



            ReservationPaymentBiz ObjPaymentBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjPaymentBiz = new ReservationPaymentBiz(objDr);

                this.Add(ObjPaymentBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "PaymentID");
                objDb = new ReservationPaymentDb(arrDr[Count - 1]);
                _MaxID = objDb.PaymentID;
                objDb = new ReservationPaymentDb(arrDr[0]);
                _MinID = objDb.PaymentID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("PaymentID"),new DataColumn("Date"),
                new DataColumn("Value"),new DataColumn("DueDate")
                , new DataColumn("Customer"),
                new DataColumn("Unit"),new DataColumn("Tower"),new DataColumn("Project"),
                new DataColumn("Desc"),new DataColumn("CheckCode"),new DataColumn("CheckValue"),
                new DataColumn("CheckDueDate"),new DataColumn("CheckStatus")
                ,new DataColumn("Employee"),new DataColumn("Branch") });
            DataRow objDr;
            foreach (ReservationPaymentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["Date"] = objBiz.PaymentDate.ToString("yyyy-MM-dd");
                objDr["DueDate"] = objBiz.InstallmentDueDate.ToString("yyyy-MM-dd");
                objDr["Value"] = objBiz.PaymentValue.ToString();
                objDr["Customer"] = objBiz.CustomerStr;
                objDr["Unit"] = objBiz.UnitStr;
                objDr["Tower"] = objBiz.TowerName;
                objDr["Project"] = objBiz.ProjectName;
                objDr["Desc"] = objBiz.FullDesc;

                if (objBiz.CheckBiz.ID != 0)
                {
                    objDr["CheckCode"] = "#" + objBiz.CheckBiz.Code + "#";
                    objDr["CheckValue"] = objBiz.CheckBiz.Value;
                    objDr["CheckDueDate"] = objBiz.CheckBiz.DueDate.ToString("yyyy-MM-dd");
                    objDr["CheckStatus"] = objBiz.CheckBiz.StatusStr;

                }
                objDr["PaymentID"] = objBiz.PaymentID;
                objDr["Employee"] = objBiz.EmployeeName;
                objDr["Branch"] = objBiz.BranchName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public DataTable GetTransactionTable()
        {
            DataTable Returned = ReservationCol.GetTransactionEmbtyTable();
            DataRow objDr;
            foreach (ReservationPaymentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PaymentID"] = objBiz.PaymentID;
                objDr["TransactionID"] = objBiz.TransactionBiz.ID;
                objDr["TransactionDate"] = objBiz.TransactionBiz.Date;
                objDr["TransactionCode"] = objBiz.TransactionBiz.Code;
                objDr["TransactionType"] = objBiz.TransactionBiz.TypeBiz.ID;
                objDr["TransactionValue"] = objBiz.TransactionBiz.Value;
                objDr["TransactionCurrency"] = objBiz.TransactionBiz.CurrencyBiz.ID;
                objDr["TransactionCurrencyValue"] = objBiz.TransactionBiz.CurrencyBiz.Value;
                objDr["TransactionDesc"] = objBiz.TransactionBiz.Desc;
                objDr["TransactionStatus"] = objBiz.TransactionBiz.Status;
                objDr["CurrentReservation"] = objBiz.TransactionBiz.ReservationID;
                objDr["FromAccountID"] = objBiz.TransactionBiz.AccountFromBiz.ID;
                objDr["ToAccountID"] = objBiz.TransactionBiz.AccountToBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void CreateTransaction()
        {
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            objDb.TransactionTable = GetTransactionTable();

            objDb.CreateTransaction();

        }
        public ReservationPaymentCol GetDatedPaymentCol(DateTime dtDate)
        {
            ReservationPaymentCol Returned = new ReservationPaymentCol(true);
            foreach (ReservationPaymentBiz objBiz in this)
            {
                if (SysUtility.Approximate(objBiz.PaymentTimIns.ToOADate() - 2, 1, ApproximateType.Down) ==
                    SysUtility.Approximate(dtDate.ToOADate() - 2, 1, ApproximateType.Down))
                    Returned.Add(objBiz);
            }
            return Returned;
        }

        public void SaveGLTransaction()
        {
            DataTable dtTransaction, dtTransactionElement, dtNative;

            PaymentDb objDb = new PaymentDb();
            dtTransaction = TransactionCol.GetTable(out dtTransactionElement, out dtNative);
            objDb.TransactionTable = dtTransaction;
            objDb.TRansactionElementTable = dtTransactionElement;
            objDb.PaymentTransactionTable = dtNative;
            objDb.InsertTransaction();


        }
        #endregion
    }
}
