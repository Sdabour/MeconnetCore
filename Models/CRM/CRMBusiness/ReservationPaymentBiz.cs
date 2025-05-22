using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
 
using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum ReservationPaymentType
    {
        NotSpecified,
        Installment = 1,
        Temp = 2,
        Mulct = 3,
        AdministrativeCost = 4,
        PayBack = 5

    }
    public class ReservationPaymentBiz
    {
        #region Private Data
        ReservationPaymentDb _ReservationPaymentDb;
        ReservationCheckBiz _CheckBiz;
        TransactionBiz _TransactionBiz;
        static AccountBiz _CofferAccountBiz;
        ReceiptBiz _ReceiptBiz;

        #endregion
        #region Constructors
        public ReservationPaymentBiz()
        {
            _ReservationPaymentDb = new ReservationPaymentDb();
            _CheckBiz = new ReservationCheckBiz();
        }
        public ReservationPaymentBiz(DataRow objDr)
        {
            _ReservationPaymentDb = new ReservationPaymentDb(objDr);
            if (_ReservationPaymentDb.CheckID != 0)
                _CheckBiz = new ReservationCheckBiz(objDr);
            if (_ReservationPaymentDb.ReceiptID != 0)
                _ReceiptBiz = new ReceiptBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int PaymentID
        {
            set
            {
                _ReservationPaymentDb.PaymentID = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentID;
            }
        }
        public int ReservationID
        {
            set
            {
                _ReservationPaymentDb.ReservationID = value;
            }
            get
            {
                return _ReservationPaymentDb.ReservationID;
            }
        }
        public DateTime ReservationDate
        {
            set
            {
                _ReservationPaymentDb.ReservationDate = value;
            }
            get
            {
                return _ReservationPaymentDb.ReservationDate;
            }
        }
        public bool IsContracted
        {
            set
            {
                _ReservationPaymentDb.IsContracted = value;
            }
            get
            {
                return _ReservationPaymentDb.IsContracted;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _ReservationPaymentDb.ContractingDate = value;
            }
            get
            {
                return _ReservationPaymentDb.ContractingDate;
            }
        }
        public string CustomerStr
        {
            set
            {
                _ReservationPaymentDb.CustomerStr = value;
            }
            get
            {
                return _ReservationPaymentDb.CustomerStr;
            }
        }
        public string UnitStr
        {
            set
            {
                _ReservationPaymentDb.UnitStr = value;
            }
            get
            {
                return _ReservationPaymentDb.UnitStr;
            }
        }
        public string UnitNameStr
        {
            set
            {
                _ReservationPaymentDb.UnitNameStr = value;
            }
            get
            {
                return _ReservationPaymentDb.UnitNameStr;
            }
        }
        public bool UnitIsDelivered
        {
            get { return _ReservationPaymentDb.UnitIsDelivered; }
            set { _ReservationPaymentDb.UnitIsDelivered = value; }
        }
        public string TowerName
        {
            set
            {
                _ReservationPaymentDb.TowerName = value;
            }
            get
            {
                return _ReservationPaymentDb.TowerName;
            }
        }
        public bool TowerIsDelivered
        {
            get => _ReservationPaymentDb.TowerIsDelivered;
        }
        public DateTime TowerDeliveryDate
        {
            get => _ReservationPaymentDb.TowerDeliveryDate;
        }
        public string ProjectName
        {
            set
            {
                _ReservationPaymentDb.ProjectName = value;
            }
            get
            {
                return _ReservationPaymentDb.ProjectName;
            }
        }
        public int ProjectID
        {
            set
            {
                _ReservationPaymentDb.ProjectID = value;
            }
            get
            {
                return _ReservationPaymentDb.ProjectID;
            }
        }
        public double PaymentValue
        {
            set
            {
                _ReservationPaymentDb.PaymentValue = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentValue;
            }
        }
        public bool PaymentDirection
        {
            set
            {
                _ReservationPaymentDb.PaymentDirection = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentDirection;
            }
        }
        public DateTime PaymentDate
        {
            set
            {
                _ReservationPaymentDb.PaymentDate = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentDate;
            }
        }

        public int CheckID
        {
            set
            {
                _ReservationPaymentDb.CheckID = value;
            }
            get
            {
                return _ReservationPaymentDb.CheckID;
            }
        }
        public bool CheckIsCollected
        {
            set
            {
                _ReservationPaymentDb.CheckIsCollected = value;
            }
            get
            {
                return _ReservationPaymentDb.CheckIsCollected;
            }

        }
        public int InstallmentID
        {
            set
            {
                _ReservationPaymentDb.InstallmentID = value;
            }
            get
            {
                return _ReservationPaymentDb.InstallmentID;
            }
        }
        public string InstallmentTypeNameA
        {
            set
            {
                _ReservationPaymentDb.InstallmentTypeNameA = value;
            }
            get
            {
                return _ReservationPaymentDb.InstallmentTypeNameA;
            }
        }
        public string PaymentDesc
        {
            set
            {
                _ReservationPaymentDb.PaymentDesc = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentDesc == null || _ReservationPaymentDb.PaymentDesc == "" ?
                    _ReservationPaymentDb.PaymentTypeStr : _ReservationPaymentDb.PaymentDesc;
            }
        }
        public int InstallmentNo
        {
            set
            {
                _ReservationPaymentDb.InstallmentNo = value;
            }
            get
            {
                return _ReservationPaymentDb.InstallmentNo;
            }
        }
        public double InstallmentValue
        {
            set
            {
                _ReservationPaymentDb.InstallmentValue = value;
            }
            get
            {

                return _ReservationPaymentDb.InstallmentValue;
            }
        }
        public bool HasReceipt
        {
            set
            {
                _ReservationPaymentDb.HasReceipt = value;
            }
            get
            {
                return _ReservationPaymentDb.HasReceipt;
            }
        }
        public int CellID
        {
            get
            {
                return _ReservationPaymentDb.CellID;
            }
        }
        public double InstallmentDiscount
        {

            get
            {

                return _ReservationPaymentDb.InstallmentDiscount;
            }
        }
        public int InstallmentLastPaymentID
        {
            get
            {
                return _ReservationPaymentDb.InstallmentLastPaymentID;
            }
        }
        public double InstallmentRemainingValue
        {
            get
            {
                return _ReservationPaymentDb.InstallmentRemainingValue;
            }
        }
        public DateTime InstallmentDueDate
        {
            set
            {
                _ReservationPaymentDb.InstallmentDueDate = value;
            }
            get
            {
                return _ReservationPaymentDb.InstallmentDueDate;
            }
        }
        public DateTime PaymentTimIns
        {
            set
            {
                _ReservationPaymentDb.PaymentTimIns = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentTimIns;
            }
        }
        public string PaymentTypeStr
        {
            set
            {
                _ReservationPaymentDb.PaymentTypeStr = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentTypeStr;
            }
        }
        public int EmployeeID
        {
            set
            {
                _ReservationPaymentDb.EmployeeID = value;
            }
            get
            {
                return _ReservationPaymentDb.EmployeeID;
            }
        }
        public string EmployeeName
        {

            get
            {
                return _ReservationPaymentDb.EmployeeName;
            }

        }
        public string EmployeeShortName
        {

            get
            {
                return _ReservationPaymentDb.EmployeeShortName;
            }

        }
        public int BranchID
        {
            set
            {
                _ReservationPaymentDb.BranchID = value;
            }
            get
            {
                return _ReservationPaymentDb.BranchID;
            }
        }

        public string BranchName
        {

            get
            {
                return _ReservationPaymentDb.BranchName;
            }

        }
        public ReservationPaymentType Type
        {
            get
            {
                return (ReservationPaymentType)_ReservationPaymentDb.PaymentType;
            }
        }
        public ReservationCheckBiz CheckBiz
        {
            set
            {
                _CheckBiz = value;
            }
            get
            {
                if (_CheckBiz == null)
                    _CheckBiz = new ReservationCheckBiz();
                return _CheckBiz;
            }
        }
        public ReceiptBiz ReceiptBiz
        {
            set
            {
                _ReceiptBiz = value;
            }
            get
            {
                if (_ReceiptBiz == null)
                    _ReceiptBiz = new ReceiptBiz();
                return _ReceiptBiz;
            }
        }
        public static AccountBiz CofferAccountBiz
        {
            set
            {
                _CofferAccountBiz = value;
            }
            get
            {
                if (_CofferAccountBiz == null)
                {
                    _CofferAccountBiz = new AccountBiz();
                    SupperCodeBiz objTemp = new SupperCodeBiz("CofferAccount");
                    if (objTemp.ID != 0)
                    {
                        try
                        {
                            _CofferAccountBiz = new AccountBiz(int.Parse(objTemp.Value));
                        }
                        catch
                        {

                        }
                    }
                }
                return _CofferAccountBiz;
            }
        }
        public string FullDesc
        {
            get
            {
                string Returned = "";

                string strTemp = "";
                double dblValue = 0;
                ReservationPaymentBiz objBiz = this;

                strTemp += PaymentDesc == null || PaymentDesc == "" ?
                    PaymentTypeStr : PaymentDesc;
                if (objBiz.Type == ReservationPaymentType.Installment)
                {
                    strTemp = "";
                    dblValue = InstallmentValue - objBiz.InstallmentDiscount;
                    if (dblValue > objBiz.PaymentValue + 1)
                        strTemp += "ÌÒÁ ãä ";
                    strTemp += InstallmentTypeNameA + " ãÓÊÍÞ ÈÊÇÑíÎ " + InstallmentDueDate.ToString("dd/MM/yyyy");
                }


                Returned += strTemp;


                return Returned;
            }
        }
        public TransactionBiz TransactionBiz
        {
            get
            {

                if (_TransactionBiz == null)
                {
                    _TransactionBiz = new TransactionBiz();
                    _TransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;
                    double dblTotalValue = PaymentValue;
                    string strTitle = FullDesc;

                    dblValue = PaymentValue;
                    if (
                    Math.Abs(dblValue) > 0)
                    {
                        objTransactionBiz = _TransactionBiz;
                        _TransactionBiz.SystemSource = 6;
                        _TransactionBiz.SystemType = (int)TransactionCRMSystemType.Contracting;
                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = PaymentDirection ? AccountBiz.CRMCofferAccountBiz : AccountBiz.CRMCustomerAccountBiz;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;

                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Payment;
                        objDebitElement.ReservationID = ReservationID;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.ReservationID = ReservationID;
                        objCreditElement.AccountBiz = PaymentDirection ? AccountBiz.CRMCustomerAccountBiz : AccountBiz.CRMCofferAccountBiz;

                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Payment;
                        _TransactionBiz.ElementCol.Add(objDebitElement);
                        _TransactionBiz.ElementCol.Add(objCreditElement);
                        _TransactionBiz.OtherModuleSrcIDs.Add(PaymentID.ToString());
                    }

                }
                return _TransactionBiz;
            }
        }
        public bool IsPaid
        {
            get
            {
                return _ReservationPaymentDb.IsPaid;
            }
        }
        public PaymentType PaymentMean
        {
            get
            {
                return (PaymentType)_ReservationPaymentDb.PaymentMean;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion

    }
}
