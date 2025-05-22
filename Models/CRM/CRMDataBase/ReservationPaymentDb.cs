using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationPaymentDb
    {
        #region Private Data
        int _PaymentID;
        int _ReservationID;
        int _CustomerID;
        DateTime _ReservationDate;
        bool _IsContracted;
        DateTime _ContractingDate;
        string _CustomerStr;
        string _UnitStr;
        string _UnitNameStr;
        int _TowerID;
        string _TowerName;
        bool _TowerIsDelivered;
        public bool TowerIsDelivered
        { get => _TowerIsDelivered; }
        DateTime _TowerDeliveryDate;
        public DateTime TowerDeliveryDate
        { get => _TowerDeliveryDate; }

        string _ProjectName;
        int _ProjectID;
        string _ProjectClass;
        double _PaymentValue;
        double _PaymentInValue;
        double _PaymentOutValue;
        double _InstallmentDiscount;
        int _InstallmentLastPaymentID;
        double _InstallmentRemainingValue;
        bool _PaymentDirection;
        bool _IsPaid;
        DateTime _PaymentDate;
        int _CheckID;
        //DateTime _CheckDueDate;
        string _CheckSerial;
        bool _CheckIsCollected;

        public bool CheckIsCollected
        {
            get { return _CheckIsCollected; }
            set { _CheckIsCollected = value; }
        }
        int _PaymentMean;
        int _InstallmentID;
        string _InstallmentTypeNameA;
        int _InstallmentNo;
        double _InstallmentValue;
        double _InstallmentPaymentValue;
        double _TempPaymentValue;
        double _MulctPaymentValue;
        double _AdministrativePaymentValue;
        double _PayBackPaymentValue;
        double _DirectPaymentInValue;
        double _DirectPaymentOutValue;
        double _InsuranceInValue;
        double _InsuranceOutValue;
        bool _HasReceipt;
        DateTime _InstallmentDueDate;
        DateTime _PaymentTimIns;
        string _PaymentTypeStr;
        string _PaymentDesc;
        string _PaymentSubDesc;
        int _PaymentType;
        int _EmployeeID;
        string _EmployeeName;
        string _EmployeeShortName;
        int _BranchID;
        string _BranchName;
        int _Y;
        int _M;
        int _D;
        int _ReceiptID;
        #region Private Data for Search
        bool _IsPaymentDateStatus;
        DateTime _StartPaymentDate;
        DateTime _EndPaymentDate;
        bool _IsDueDateStatus;
        DateTime _StartDueDate;
        DateTime _EndDueDueDate;
        bool _IsRegisterDateStatus;
        DateTime _StartRegisterDate;
        DateTime _EndRegisterDate;
        int _InTimeStatus;
        bool _IncludeInstallmentPayment;
        bool _IncludeTempPayment;
        bool _IncludeAdministrativePayment;
        bool _IncludeMulctPayment;
        bool _IncludePayBackPayment;
        bool _IncludeDirectPayment;
        bool _IncludeInsurancePayment;
        int _OnlyHasCheckStatus;/*
                                 * 0 dont care
                                 * 1 only has check
                                 * 2 only has no check
                                 */
        int _ReservationStatus;/*
                                * 0 dont Crare
                                * 1 Reserved Only 
                                * 2 Canceled Only
                                */
        int _GLTransactionStatus;/*
                                  * 0 dont care
                                  * 1 Only Has Transaction
                                  * 2 Only Has No Transaction
                                  */
        int _ReceiptStatus;/*
                            * 0 dont care
                            * 1 only has receipt
                            * 2 only doesnot have receipt
                            */
        string _ReceiptCode;
        int _DeletedStatus;
        int _CellID;
        bool _ContainsNonCollectedCheck;
        bool _AllCollectedOrNotCollected;
        int _CellFamilyID;
        string _CellIDs;
        string _UnitCode;
        bool _ContractDateRange;

        public bool ContractDateRange
        {
            get { return _ContractDateRange; }
            set { _ContractDateRange = value; }
        }
        DateTime _ContractStartDate;

        public DateTime ContractStartDate
        {
            get { return _ContractStartDate; }
            set { _ContractStartDate = value; }
        }
        DateTime _ContractEndDate;

        public DateTime ContractEndDate
        {
            get { return _ContractEndDate; }
            set { _ContractEndDate = value; }
        }
        string _InstallmentTypeIDs;
        string _CheckIDs;

        public string CheckIDs
        {
            get { return _CheckIDs; }
            set { _CheckIDs = value; }
        }
        string _LinearCheckIDs;

        public string LinearCheckIDs
        {
            get { return _LinearCheckIDs; }
            set { _LinearCheckIDs = value; }
        }
        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        DataTable _TransactionTable;
        #region SumSearch
        bool _IsTowerGroup;
        bool _IsProjectGroup;
        bool _IsYearGroup;
        bool _IsMonthGroup;
        bool _IsDayGroup;
        bool _IsTypeGroup;
        bool _IsCustomerGroup;
        bool _IsBranchGroup;
        bool _IsEmployeeGroup;
        bool _IsUnitGroup;
        bool _IsInstallmentTypeGroup;
        #endregion
        #endregion
        #endregion
        #region Constructors
        public ReservationPaymentDb()
        {

        }
        public ReservationPaymentDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int PaymentID
        {
            set
            {
                _PaymentID = value;
            }
            get
            {
                return _PaymentID;
            }
        }
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
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }
        }
        public DateTime ReservationDate
        {
            set
            {
                _ReservationDate = value;
            }
            get
            {
                return _ReservationDate;
            }
        }
        public bool IsContracted
        {
            set
            {
                _IsContracted = value;
            }
            get
            {
                return _IsContracted;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _ContractingDate = value;
            }
            get
            {
                return _ContractingDate;
            }
        }
        public string CustomerStr
        {
            set
            {
                _CustomerStr = value;
            }
            get
            {
                return _CustomerStr;
            }
        }
        public string UnitStr
        {
            set
            {
                _UnitStr = value;
            }
            get
            {
                return _UnitStr;
            }
        }
        public string UnitNameStr
        {
            set
            {
                _UnitNameStr = value;
            }
            get
            {
                return _UnitNameStr;
            }
        }
        public int TowerID
        {
            set
            {
                _TowerID = value;
            }
            get
            {
                return _TowerID;
            }
        }
        public string TowerName
        {
            set
            {
                _TowerName = value;
            }
            get
            {
                return _TowerName;
            }
        }
        public int ProjectID
        {
            set
            {
                _ProjectID = value;
            }
            get
            {
                return _ProjectID;
            }
        }
        public string ProjectName
        {
            set
            {
                _ProjectName = value;
            }
            get
            {
                return _ProjectName;
            }
        }
        public double PaymentValue
        {
            set
            {
                _PaymentValue = value;
            }
            get
            {
                return _PaymentValue;
            }
        }
        public bool PaymentDirection
        {
            set
            {
                _PaymentDirection = value;
            }
            get
            {
                return _PaymentDirection;
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
        //public DateTime CheckDueDate
        //{
        //    set
        //    {
        //        _CheckDueDate = value;
        //    }
        //    get
        //    {
        //        return _CheckDueDate;
        //    }
        //}
        public int InstallmentID
        {
            set
            {
                _InstallmentID = value;
            }
            get
            {
                return _InstallmentID;
            }
        }
        public string InstallmentTypeNameA
        {
            set
            {
                _InstallmentTypeNameA = value;
            }
            get
            {
                return _InstallmentTypeNameA;
            }
        }
        public int InstallmentNo
        {
            set
            {
                _InstallmentNo = value;
            }
            get
            {
                return _InstallmentNo;
            }
        }
        public double InstallmentValue
        {
            set
            {
                _InstallmentValue = value;
            }
            get
            {

                return _InstallmentValue;
            }
        }
        public DateTime InstallmentDueDate
        {
            set
            {
                _InstallmentDueDate = value;
            }
            get
            {
                return _InstallmentDueDate;
            }
        }
        public DateTime PaymentTimIns
        {
            set
            {
                _PaymentTimIns = value;
            }
            get
            {
                return _PaymentTimIns;
            }
        }
        public bool HasReceipt
        {
            set
            {
                _HasReceipt = value;
            }
            get
            {
                return _HasReceipt;
            }
        }
        public string PaymentTypeStr
        {
            set
            {
                _PaymentTypeStr = value;
            }
            get
            {
                return _PaymentTypeStr;
            }
        }
        public string PaymentDesc
        {
            set
            {
                _PaymentDesc = value;
            }
            get
            {
                return _PaymentDesc;
            }
        }
        public string PaymentSubDesc
        {
            set
            {
                _PaymentSubDesc = value;
            }
            get
            {
                return _PaymentSubDesc;
            }
        }
        public int PaymentType
        {
            set
            {
                _PaymentType = value;
            }
            get
            {
                return _PaymentType;
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
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public string EmployeeShortName
        {
            get
            {
                return _EmployeeShortName;
            }
        }
        public string ProjectClass
        {
            get
            {
                return _ProjectClass;
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
        public string BranchName
        {
            get
            {
                return _BranchName;
            }
        }
        public int ReceiptID
        {
            set
            {
                _ReceiptID = value;
            }
            get
            {
                return _ReceiptID;
            }
        }
        public string ReceiptCode
        {
            set
            {
                _ReceiptCode = value;
            }
            get
            {
                return _ReceiptCode;
            }
        }
        public int DeleteStatus
        {
            set
            {
                _DeletedStatus = value;
            }
        }
        public int ReceiptStatus
        {
            set
            {
                _ReceiptStatus = value;

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
        public bool IsPaymentDateStatus
        {
            set
            {
                _IsPaymentDateStatus = value;
            }
        }
        public string InstallmentTypeIDs
        {
            set
            {
                _InstallmentTypeIDs = value;
            }
        }
        public DateTime StartPaymentDate
        {

            set
            {
                _StartPaymentDate = value;
            }
        }
        public DateTime EndPaymentDate
        {
            set
            {
                _EndPaymentDate = value;
            }
        }
        public bool IsDueDateStatus
        {
            set
            {
                _IsDueDateStatus = value;
            }
        }
        public DateTime StartDueDate
        {
            set
            {
                _StartDueDate = value;
            }
        }
        public DateTime EndDueDate
        {
            set
            {
                _EndDueDueDate = value;
            }
        }
        public bool IsRegisterDateStatus
        {
            set
            {
                _IsRegisterDateStatus = value;
            }
        }
        public DateTime StartRegisterDate
        {
            set
            {
                _StartRegisterDate = value;
            }
        }
        public DateTime EndRegisterDate
        {
            set
            {
                _EndRegisterDate = value;
            }
        }
        public int InTimeStatus
        {
            set
            {
                _InTimeStatus = value;
            }
        }
        public bool IncludeInstallmentPayment
        {
            set
            {
                _IncludeInstallmentPayment = value;
            }
        }
        public bool IncludeTempPayment
        {
            set
            {
                _IncludeTempPayment = value;
            }
        }
        public bool IncludeAdministrativePayment
        {
            set
            {
                _IncludeAdministrativePayment = value;
            }
        }
        public bool IncludeMulctPayment
        {
            set
            {
                _IncludeMulctPayment = value;
            }
        }
        public bool IncludePayBackPayment
        {
            set
            {
                _IncludePayBackPayment = value;
            }
        }
        public bool IncludeDirectPayment
        {
            set
            {
                _IncludeDirectPayment = value;
            }
        }
        public bool IncludeInsurancePayment
        {
            set
            {
                _IncludeInsurancePayment = value;
            }
        }
        string _ResubmissionIDs;

        public string ResubmissionIDs
        {
            get { return _ResubmissionIDs; }
            set { _ResubmissionIDs = value; }
        }
        int _ResubmissionTypeID;

        public int ResubmissionTypeID
        {
            get { return _ResubmissionTypeID; }
            set { _ResubmissionTypeID = value; }
        }
        string _ResubmissionSerial;

        public string ResubmissionSerial
        {
            get { return _ResubmissionSerial; }
            set { _ResubmissionSerial = value; }
        }
        bool _ResubmissionDateRange;

        public bool ResubmissionDateRange
        {
            get { return _ResubmissionDateRange; }
            set { _ResubmissionDateRange = value; }
        }

        DateTime _ResubmissionStartDate;

        public DateTime ResubmissionStartDate
        {
            get { return _ResubmissionStartDate; }
            set { _ResubmissionStartDate = value; }
        }
        DateTime _ResubmissionEndDate;

        public DateTime ResubmissionEndDate
        {
            get { return _ResubmissionEndDate; }
            set { _ResubmissionEndDate = value; }
        }
        bool _ResubmissionAlertDateRange;
        public bool ResubmissionAlertDateRange
        {
            get { return _ResubmissionAlertDateRange; }
            set { _ResubmissionAlertDateRange = value; }
        }

        DateTime _ResubmissionAlertStartDate;

        public DateTime ResubmissionAlertStartDate
        {
            get { return _ResubmissionAlertStartDate; }
            set { _ResubmissionAlertStartDate = value; }
        }
        DateTime _ResubmissionAlertEndDate;

        public DateTime ResubmissionAlertEndDate
        {
            get { return _ResubmissionAlertEndDate; }
            set { _ResubmissionAlertEndDate = value; }
        }
        bool _IncludeMaintainancePayment;
        public bool IncludeMaintainancePayment { set => _IncludeMaintainancePayment = value; }
        public int OnlyHasCheckStatus
        {
            set
            {
                _OnlyHasCheckStatus = value;
            }
        }
        public bool AllCollectedOrNotCollected
        {
            set
            {
                _AllCollectedOrNotCollected = value;
            }
        }
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int GLTransactionStatus
        {
            set
            {
                _GLTransactionStatus = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
        }
        bool _UnitIsDelivered;

        public bool UnitIsDelivered
        {
            get { return _UnitIsDelivered; }
            set { _UnitIsDelivered = value; }
        }
        public bool ContainsNonCollectedCheck
        {
            set
            {
                _ContainsNonCollectedCheck = value;
            }
        }
        public DataTable TransactionTable
        {
            set
            {
                _TransactionTable = value;
            }
        }
        public bool IsPaid
        {
            get
            {
                return _IsPaid;
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
        public int Y
        {
            get
            {
                return _Y;
            }


        }
        public int M
        {
            get
            {
                return _M;
            }
        }
        public int D
        {
            get
            {
                return _D;
            }
        }
        public double InstallmentPaymentValue
        {
            get
            {
                return _InstallmentPaymentValue;
            }
        }
        public double InstallmentDiscount
        {
            get
            {
                return _InstallmentDiscount;
            }
        }
        public int InstallmentLastPaymentID
        {
            get
            {
                return _InstallmentLastPaymentID;
            }
        }
        public double InstallmentRemainingValue
        {
            get
            {
                return _InstallmentRemainingValue;
            }
        }
        public double TempPaymentValue
        {
            get
            {
                return _TempPaymentValue;
            }
        }
        public double MulctPaymentValue
        {
            get
            {
                return _MulctPaymentValue;
            }
        }
        public double AdministrativePaymentValue
        {
            get
            {
                return _AdministrativePaymentValue;
            }
        }
        public double PayBackPaymentValue
        {
            get
            {
                return _PayBackPaymentValue;
            }
        }
        public double DirectPaymentInValue
        {
            get
            {
                return _DirectPaymentInValue;
            }
        }
        public double DirectPaymentOutValue
        {
            get
            {
                return _DirectPaymentOutValue;
            }
        }
        public double InsuranceInValue
        {
            get
            {
                return _InsuranceInValue;
            }
        }
        public double InsuranceOutValue
        {
            get
            {
                return _InsuranceOutValue;
            }
        }
        public int PaymentMean
        {
            get
            {
                return _PaymentMean;
            }
        }
        #region Sum Search
        public bool IsTowerGroup
        {
            set
            {
                _IsTowerGroup = value;
            }
        }

        public bool IsProjectGroup
        {
            set
            {
                _IsProjectGroup = value;
            }
        }
        public bool IsYearGroup
        {
            set
            {
                _IsYearGroup = value;
            }
        }
        public bool IsMonthGroup
        {
            set
            {
                _IsMonthGroup = value;
            }
        }
        public bool IsDayGroup
        {
            set
            {
                _IsDayGroup = value;
            }
        }
        public bool IsTypeGroup
        {
            set
            {
                _IsTypeGroup = value;
            }
        }
        public bool IsCustomerGroup
        {
            set
            {
                _IsCustomerGroup = value;
            }
        }
        public bool IsBranchGroup
        {
            set
            {
                _IsBranchGroup = value;
            }
        }
        public bool IsEmployeeGroup
        {
            set
            {
                _IsEmployeeGroup = value;
            }
        }
        public bool IsUnitGroup
        {
            set
            {
                _IsUnitGroup = value;
            }
        }
        public bool IsInstallmentTypeGroup
        {
            set
            {
                _IsInstallmentTypeGroup = value;
            }
        }
        #endregion
        public string ReservationStr
        {
            get
            {
                string strUnitCell = "SELECT DISTINCT " +
                      " TOP (100) PERCENT CASE WHEN COUNT(UnitFullName) = 1 THEN MAX(dbo.CRMUnit.UnitFullName) WHEN COUNT(UnitFullName)  " +
                      " = 2 THEN MAX(UnitFullName) + '&' + MIN(UnitFullName) ELSE MAX(UnitFullName) + '&..&' + MIN(UnitFullName) END AS UnitFullName " +
                      ", CASE WHEN COUNT(UnitNameA) = 1 THEN MAX(dbo.CRMUnit.UnitNameA) WHEN COUNT(UnitNameA)  " +
                      " = 2 THEN MAX(UnitNameA) + '&' + MIN(UnitNameA) ELSE MAX(UnitNameA) + '&..&' + MIN(UnitNameA) END AS UnitName  " +
                     ", case when max(dbo.CRMUnit.UnitDeliveryDate)> convert(datetime,'1900-01-30')then 1 else 0 end  as UnitIsDelivered  " +
                      ", dbo.CRMReservation.ReservationID AS CurrentReservation, CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                      " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END AS TowerName,case when  RPCell_1.CellDeliverDate is not null then 1 else 0 end as TowerIsDelivered,RPCell_1.CellDeliverDate as TowerDeliveryDate" +
                      " ,case when RPCell_2.CellAlterName is null or RPCell_2.CellAlterName ='' then RPCell_2.CellNameA else RPCell_2.CellAlterName end AS ProjectName " +
                      ",RPCell_2.CellID as ProjectID " +
                      ", dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationDate" +
                      ", dbo.CRMReservation.ReservationContractingDate,max(dbo.RPCell.CellID) as ReservationCell " +
                      " FROM  dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
                      " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                      " dbo.RPCell AS RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID INNER JOIN " +
                      " dbo.CRMReservation ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservation.ReservationID " +
                      " where (1=1) ";

                if (_CellFamilyID != 0)
                    strUnitCell += " and RPCell.CellFamilyID=" + _CellFamilyID;
                else if (_CellIDs != null && _CellIDs != "")
                    strUnitCell += " and RPCell.CellID in (" + _CellIDs + ")";
                if (_ReservationStatus != 0)
                {
                    if (_ReservationStatus == 1)
                    {
                        strUnitCell += " and  dbo.CRMUnit.CurrentReservation = CRMReservation.ReservationID ";

                    }
                    else if (_ReservationStatus == 2)
                    {
                        strUnitCell += " and  dbo.CRMUnit.CurrentReservation <> CRMReservation.ReservationID ";
                    }
                }
                if (_UnitCode != null && _UnitCode != "")
                {
                    strUnitCell += " and CRMUnit.UnitFullName  like '%" + _UnitCode + "%' ";
                }
                double dblStartDate, dblEndDate;
                if (_ContractDateRange)
                {
                    dblStartDate = SysUtility.Approximate(_ContractStartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndDate = SysUtility.Approximate(_ContractEndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    strUnitCell += " and  dbo.CRMReservation.ReservationContractingDate>=" + dblStartDate + " and  dbo.CRMReservation.ReservationContractingDate < " + dblEndDate;
                }
                if (_ReservationID != 0)
                    strUnitCell += " and dbo.CRMReservationUnit.ReservationID =" + _ReservationID;

                strUnitCell += " GROUP BY RPCell_2.CellNameA, CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                      " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END,RPCell_1.CellDeliverDate, dbo.CRMReservation.ReservationID,  " +
                      " dbo.CRMReservation.ReservationStatus, dbo.CRMReservation.ReservationDate, " +
                      " dbo.CRMReservation.ReservationContractingDate,RPCell_2.CellAlterName ,RPCell_2.CellID ";

                //" ORDER BY CurrentReservation DESC ";

                string strReservationCustomer = "SELECT dbo.CRMReservationCustomer.ReservationID, CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName) " +
                      " WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName) " +
                      " ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName " +
                      " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                      " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID ";
                if (_CustomerID != 0)
                    strReservationCustomer += " where dbo.CRMReservationCustomer.CustomerID =" + _CustomerID;
                strReservationCustomer += " GROUP BY dbo.CRMReservationCustomer.ReservationID ";
                string Returned = "Select ReservationTable.*,CustomerTable.CustomerFullName " +
                    " from (" + strUnitCell + ") as ReservationTable " +
                    " inner join (" + strReservationCustomer + ") as CustomerTable " +
                    " on ReservationTable.CurrentReservation = CustomerTable.ReservationID ";

                return Returned;
            }
        }
        public string PaymentStr
        {
            get
            {
                string strMaxReceipt = "SELECT     PaymentID, MAX(ReceiptID) AS MaxReceipt " +
                        " FROM         dbo.GLReceiptPayment " +
                         " GROUP BY PaymentID ";

                string strPaymentApplicant = "SELECT dbo.HRApplicant.ApplicantID AS PaymentApplicantID" +
                    ", dbo.HRApplicant.ApplicantFirstName AS PaymentApplicantName, dbo.HRApplicant.ApplicantShortName AS PaymentApplicantShortName, " +
                  " dbo.HRApplicantWorker.ApplicantCode AS PaymentApplicantCode" +
                  " FROM     dbo.HRApplicantWorker INNER JOIN " +
                  " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";

                string strPaymentBranch = "SELECT   BranchID AS PaymentBranchID, BranchNameA AS PaymentBranchName " +
                      " FROM   dbo.HRBranch ";

                string strCollectingApplicant = "SELECT dbo.HRApplicant.ApplicantID AS CollectingApplicantID" +
                    ", dbo.HRApplicant.ApplicantFirstName AS CollectingApplicantName,dbo.HRApplicant.ApplicantShortName AS CollectingApplicantShortName, " +
                   "dbo.HRApplicantWorker.ApplicantCode AS CollectingApplicantCode " +
                   " FROM         dbo.HRApplicantWorker INNER JOIN " +
                   " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";

                string strCollectingBranch = "SELECT   BranchID AS CollectingBranchID, BranchNameA AS CollectingBranchName " +
                        " FROM    dbo.HRBranch ";
                ReceiptDb objReceiptDb = new ReceiptDb();
                objReceiptDb.Serial = _ReceiptCode;
                string strCheck = @"SELECT        CheckID, CheckDirection, CheckEditorName, CheckBeneficiaryName, CheckCode, CheckType, CheckValue, CheckIssueDate, CheckDueDate, CheckPaymentDate, CheckCurrentStatus, CheckCurrentStatusDate, 
                         CheckCurrentOldPlace, ChcekCurrentPlace, CheckCurrentStatusComment, CheckCollectingBank
FROM            dbo.GLCheck ";
                string Returned = "SELECT  dbo.GLPayment.PaymentID as NativePaymentID, dbo.GLPayment.PaymentValue" +
                    ", CASE WHEN CheckTable.CheckID IS NULL  " +//"and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN PaymentDate WHEN PaymentIsCollected = 1 THEN PaymentCollectingDate  WHEN CheckTable.CheckCurrentStatus = 2 THEN CheckTable.CheckCurrentStatusDate " +
                      " else PaymentDate END AS PaymentDate " +
                      ", CASE WHEN CheckTable.CheckID IS NULL or (PaymentIsCollected =0  and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN GLPayment.TimIns WHEN PaymentIsCollected = 1 THEN PaymentCollectingRealDate WHEN CheckTable.CheckCurrentStatus = 2 THEN CheckTable.CheckCurrentStatusDate " +
                      " END AS PaymentTimIns " +
                      ",GLPayment.GLTransaction,CheckTable.* " +
                      ",CASE WHEN CheckTable.CheckID IS NULL or (PaymentIsCollected =0) " +//" and  CheckTable.CheckCurrentStatus <> 2 )  " +
                      " THEN PaymentApplicantTable.PaymentApplicantID WHEN PaymentIsCollected = 1 THEN CollectingApplicantTable.CollectingApplicantID " +
                      " else 0 " +
                      " END AS PaymentApplicantID" +
                       ",CASE WHEN CheckTable.CheckID IS NULL or (PaymentIsCollected =0 )" +//" and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN PaymentApplicantTable.PaymentApplicantName WHEN PaymentIsCollected = 1 THEN CollectingApplicantTable.CollectingApplicantName " +
                      " else '' " +
                      " END AS PaymentApplicantName" +
                       ",CASE WHEN CheckTable.CheckID IS NULL  or (PaymentIsCollected =0 ) " +//"and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN PaymentApplicantTable.PaymentApplicantShortName WHEN PaymentIsCollected = 1 THEN CollectingApplicantTable.CollectingApplicantShortName " +
                      " else '' " +
                      " END AS PaymentApplicantShortName " +
                      ",CASE WHEN CheckTable.CheckID IS NULL or (PaymentIsCollected =0 ) " +//" and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN PaymentBranchTable.PaymentBranchID WHEN PaymentIsCollected = 1 THEN CollectingBranchTable.CollectingBranchID " +
                      " else 0 " +
                      " END AS PaymentBranchID " +
                       ",CASE WHEN CheckTable.CheckID IS NULL  or (PaymentIsCollected =0 ) " +//" and  CheckTable.CheckCurrentStatus <> 2 ) " +
                      " THEN PaymentBranchTable.PaymentBranchName WHEN PaymentIsCollected = 1 THEN CollectingBranchTable.CollectingBranchName " +
                      " else '' " +

                      " END AS PaymentBranchName,dbo.GLPayment.PaymentType AS PaymentMean,GLPayment.PaymentHasReceipt" +
                      ",ReceiptTable.*  " +
                       ",case when PaymentIsCollected is null or PaymentIsCollected = 0 then 0 else 1 end as CheckPaymentIsCollected " +
                      ",dbo.GLPaymentTransaction.TransactionID as PaymentTransaction " +
                      ",  dbo.GLPayment.PaymentDirection " +//",CheckTable.CheckDueDate  " +
                      " FROM  (" + strCheck + ") as CheckTable RIGHT OUTER JOIN " +
                      " dbo.GLCheckPayment ON CheckTable.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                      " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID " +
                       " left outer join (" + strPaymentApplicant + ") as PaymentApplicantTable " +
                                  " on  dbo.GLPayment.PaymentEmployee = PaymentApplicantTable.PaymentApplicantID " +
                                  " left outer join(" + strPaymentBranch + ") as PaymentBranchTable " +
                                  " on GLPayment.PaymentBranch = PaymentBranchTable.PaymentBranchID   " +
                                    " left outer join (" + strCollectingApplicant + ") as CollectingApplicantTable " +
                    " on   dbo.GLCheckPayment.PaymentCollectingEmployee = CollectingApplicantTable.CollectingApplicantID   " +
                    " left outer join (" + strCollectingBranch + ") as CollectingBranchTable " +
                    " on  dbo.GLCheckPayment.PaymentCollectingBranch = CollectingBranchTable.CollectingBranchID  " +
                    " left outer join (" + strMaxReceipt + ") as MaxReceiptTable " +
                    " on GLPayment.PaymentID = MaxReceiptTable.PaymentID " +
                    " left outer join (" + objReceiptDb.StrSearch + ") as ReceiptTable " +
                    " on MaxReceiptTable.MaxReceipt = ReceiptTable.ReceiptID  " +
                    " left outer join  dbo.GLPaymentTransaction " +
                    " on dbo.GLPayment.PaymentID = dbo.GLPaymentTransaction.PaymentID ";
                if (_CheckIDs != null && _CheckIDs != "")
                    Returned += " inner join (" + _CheckIDs + ") CeckConditionTable " +
                        " on CheckTable.CheckID = CeckConditionTable.CheckID ";

                Returned += " WHERE  (1=1)  ";
                if (_DeletedStatus == 2)
                {
                    Returned += " and  (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0)";
                }
                else if (_DeletedStatus == 1)
                {
                    Returned += " and  ((dbo.GLPayment.PaymentSourceID > 0) or (dbo.GLPayment.PaymentReverseID > 0))";
                }
                if (!_AllCollectedOrNotCollected)
                {
                    if (!_ContainsNonCollectedCheck)
                        Returned += " and ((CheckTable.CheckID IS NULL) OR " +
                           " (dbo.GLCheckPayment.PaymentIsCollected = 1) OR " +
                           " (CheckTable.CheckCurrentStatus = 2)) ";
                    else
                        Returned += " and ((CheckTable.CheckID IS not NULL) and " +
                                             " (dbo.GLCheckPayment.PaymentIsCollected <> 1) and " +
                                             " (CheckTable.CheckCurrentStatus <> 2)) ";
                }
                if (_LinearCheckIDs != null && _LinearCheckIDs != "")
                {
                    Returned += "  and CheckTable.CheckID in (" + _LinearCheckIDs + ") ";
                }

                Returned = "select * from (" + Returned + ") as NativePaymentTable where 1=1 ";
                double dblStart = 0;
                double dblEnd = 0;
                if (_IsPaymentDateStatus)
                {
                    dblStart = SysUtility.Approximate(_StartPaymentDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEnd = SysUtility.Approximate(_EndPaymentDate.ToOADate() - 2, 1, ApproximateType.Up);
                    //Returned += " and NativePaymentTable.PaymentDate >=" + dblStart +
                    //    " and NativePaymentTable.PaymentDate < " + dblEnd;
                    Returned += " and NativePaymentTable.PaymentDate between " + dblStart + " and " + dblEnd;
                }
                if (_IsRegisterDateStatus)
                {
                    dblStart = SysUtility.Approximate(_StartRegisterDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEnd = SysUtility.Approximate(_EndRegisterDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and NativePaymentTable.PaymentTimIns >=" + dblStart +
                        " and NativePaymentTable.PaymentTimIns < " + dblEnd;
                }
                if (_ReceiptStatus == 1)
                {

                }
                else if (_ReceiptStatus == 2)
                {

                }
                if (_ReceiptID != 0)
                {

                }
                if (_InTimeStatus == 2)
                {

                }
                if (_EmployeeID != 0)
                {
                    Returned += " and NativePaymentTable.PaymentApplicantID=" + _EmployeeID;
                }
                if (_BranchID != 0)
                    Returned += " and NativePaymentTable.PaymentBranchID=" + _BranchID;
                if (_OnlyHasCheckStatus != 0)
                {
                    if (_OnlyHasCheckStatus == 1)
                        Returned += " ( and PaymentMean in (0,1) and CheckID is not null and CheckID <> 0 and CheckPaymentIsCollected =0 and ( CheckTable.CheckCurrentStatus =2  or CheckTable.CheckCurrentStatus =4))  ";
                    else if (_OnlyHasCheckStatus == 2)
                        Returned += " and ( PaymentMean in (0,1) and( CheckID is  null or (CheckID <> 0 and CheckPaymentIsCollected = 1))) ";
                    else if (_OnlyHasCheckStatus == 3)
                        Returned += "  and PaymentMean in (2)  and ( CheckID is  null )";
                    else if (_OnlyHasCheckStatus == 4)
                        Returned += "  and PaymentMean in (3)  and ( CheckID is  null )";
                    else if (_OnlyHasCheckStatus == 5)
                        Returned += " and (  CheckID >0  and CheckPaymentIsCollected = 1) ";

                }
                if (_GLTransactionStatus != 0)
                {
                    if (_GLTransactionStatus == 1)
                        //Returned += " and GLTransaction <> 0 and GLTransaction is not null ";
                        Returned += " and (NativePaymentTable.PaymentTransaction  is not null ) ";
                    else
                        Returned += " and (NativePaymentTable.PaymentTransaction  is null ) ";


                }
                return Returned;
            }
        }
        public string InstallmentPaymentStr
        {
            get
            {
                string strTypeStr = "ÊÍÕíá ÇÞÓÇØ";
                string strPaymentDesc = "";
                string strPaymentType = " ,1 as PaymentType ";
                string strInstallmentDiscount = "SELECT  InstallmentID" +
                    ", SUM(case when  DiscountSourceID =0 and DiscountReverseID=0 and DiscountReceipt=0 then DiscountValue else 0 end) AS TotalDiscount " +
                       " FROM    dbo.CRMReservationInstallmentDiscount " +
                       " GROUP BY InstallmentID ";
                string strInstallment = new ReservationInstallmentDb().InstallmentPaymentStr;
                string Returned = "SELECT  dbo.CRMReservationInstallment.ReservationID, dbo.CRMReservationInstallment.InstallmentID, dbo.CRMInstallmentType.InstallmentTypeID, " +
                      "dbo.CRMInstallmentType.InstallmentTypeNameA, dbo.CRMReservationInstallment.InstallmentNo, " +
                      "dbo.CRMReservationInstallment.InstallmentValue, dbo.CRMReservationInstallment.InstallmentDueDate, " +
                      "dbo.CRMInstallmentPayment.PaymentID,'" + strTypeStr + "' as PaymentTypeStr" +//",1 as PaymentDirection "+
                      strPaymentType +
                      ",case when InstallmentTable.TotalNonReceiptedDiscount is null then 0 else InstallmentTable.TotalNonReceiptedDiscount end as TotalDiscount " +
                      ",dbo.CRMInstallmentType.InstallmentTypeNameA as PaymentDesc " +
                    ",InstallmentTable.LastPaymentID ,InstallmentTable.TotalRemainingValue  " +
                      " FROM   dbo.CRMReservationInstallment INNER JOIN " +
                      " (" + strInstallment + ") as InstallmentTable  " +
                      " on dbo.CRMReservationInstallment.InstallmentID = InstallmentTable.InstallmentID " +
                      " inner join dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                      " dbo.CRMInstallmentType ON dbo.CRMReservationInstallment.InstallmentType = dbo.CRMInstallmentType.InstallmentTypeID " +
                     " where (1=1) ";
                if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    Returned += "  and dbo.CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ")";
                if (_IsDueDateStatus)
                {
                    double dblStartDueDate = SysUtility.Approximate(_StartDueDate.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEndDueDate = SysUtility.Approximate(_EndDueDueDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and dbo.CRMReservationInstallment.InstallmentDueDate>=" + dblStartDueDate + " and dbo.CRMReservationInstallment.InstallmentDueDate < " + dblEndDueDate;
                }
                return Returned;
            }
        }
        public static string TempPaymentStr
        {
            get
            {
                string strPaymentType = " ,2 as PaymentType ";
                string strTypeStr = "ÍÌÒ æÊÚÇÞÏ";
                string strPaymentDesc = "ÍÌÒ æÊÚÇÞÏ";
                string Returned = "SELECT  ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, PaymentDesc AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, " +
                      " GETDATE() AS InstallmentDueDate, PaymentID ,'" + strTypeStr + "' as PaymentTypeStr" +//",1 as PaymentDirection "+
                      strPaymentType + ",0 as TotalDiscount,dbo.CRMTempReservationPayment.PaymentDesc as PaymentDesc " +
                      ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                      " FROM   dbo.CRMTempReservationPayment ";
                return Returned;
            }
        }
        public static string AdministrativePaymentStr
        {
            get
            {
                string strPaymentType = " ,4 as PaymentType ";
                string strTypeStr = "ãÕÇÑíÝ ÇÏÇÑíÉ";
                string strPaymentDesc = strTypeStr;
                string Returned = "SELECT  ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, PaymentDesc AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, " +
                      " GETDATE() AS InstallmentDueDate, PaymentID ,'" + strTypeStr + "' as PaymentTypeStr" +//",1 as PaymentDirection " +
                      strPaymentType + ",0 as TotalDiscount " +
                      ",case when  dbo.CRMAdministrativeCostPayment.PaymentDesc is null or dbo.CRMAdministrativeCostPayment.PaymentDesc = '' then dbo.CRMAdministrativeCostType.CostTypeNameA  else dbo.CRMAdministrativeCostPayment.PaymentDesc end PaymentDesc " +
                      ",0 as LastPaymentID ,0 as TotalRemainingValue " +
                      " FROM   dbo.CRMAdministrativeCostPayment " +
                      " left outer join dbo.CRMAdministrativeCostType   " +
                      " on  dbo.CRMAdministrativeCostPayment.CostType =   dbo.CRMAdministrativeCostType.CostTypeID ";
                return Returned;
            }
        }
        public static string MulctPaymentStr
        {
            get
            {
                string strPaymentType = " ,3 as PaymentType ";
                string strTypeStr = "ÛÑÇãÇÊ";
                string strPaymentDesc = strTypeStr;
                string Returned = "SELECT  PaymentReservation as ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, '' AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, GETDATE() " +
                      " AS InstallmentDueDate, PaymentID ,'" + strTypeStr + "' as PaymentTypeStr" +//",1 as PaymentDirection " +
                      strPaymentType + ",0 as TotalDiscount,CRMReservationMulctPayment.PaymentDesc as PaymentDesc " +
                      ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                      " FROM   dbo.CRMReservationMulctPayment ";
                return Returned;
            }
        }
        public static string PayBackStr
        {
            get
            {
                string strTypeStr = "ãÓÊÑÏÇÊ ÇáÇáÛÇÁ";
                string strPaymentDesc = strTypeStr;
                string strPaymentType = " ,5 as PaymentType ";
                string Returned = "SELECT ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, '' AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, GETDATE() " +
                      " AS InstallmentDueDate, PaymentID,'" + strTypeStr + "' as PaymentTypeStr" +//",0 as PaymentDirection  " +
                     strPaymentType + ",0 as TotalDiscount,dbo.CRMReservationPayBack.PaymentDesc  as PaymentDesc " +
                     ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                     " FROM  dbo.CRMReservationPayBack ";
                return Returned;
            }
        }
        public static string DirectPaymentStr
        {
            get
            {
                string strTypeStr = "ãÕÑæÝÇÊ ãÈÇÔÑÉ";
                string strPaymentDesc = strTypeStr;
                string strPaymentType = " ,6 as PaymentType ";
                string Returned = "SELECT 0 as ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, '' AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, GETDATE() " +
                      " AS InstallmentDueDate, PaymentID,'" + strTypeStr + "' as PaymentTypeStr" +//",0 as PaymentDirection  " +
                     strPaymentType + ",0 as TotalDiscount,dbo.GLDirectPaymentType.PaymentTypeNameA  as PaymentDesc " +
                     ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                     " FROM    dbo.GLDirectPayment INNER JOIN " +
                      " dbo.GLDirectPaymentType ON dbo.GLDirectPayment.PaymentType = dbo.GLDirectPaymentType.PaymentTypeID ";
                return Returned;
            }
        }
        public static string InsurancePaymentStr
        {
            get
            {
                string strTypeStr = "ÇáÊÃãíä";
                string strPaymentDesc = strTypeStr;
                string strPaymentType = " ,7 as PaymentType ";
                string Returned = "SELECT dbo.CRMInsurancePayment.ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, '' AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, GETDATE() " +
                      " AS InstallmentDueDate, PaymentID,'" + strTypeStr + "' as PaymentTypeStr" +//",0 as PaymentDirection  " +
                     strPaymentType + ",0 as TotalDiscount,dbo.CRMInsurancePayment.PaymentDesc  as PaymentDesc " +
                    ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                     " FROM    dbo.CRMInsurancePayment left outer JOIN " +
                      " dbo.CRMInsuranceType ON dbo.CRMInsurancePayment.InsuranceType = dbo.CRMInsuranceType.InsuranceTypeID ";
                return Returned;
            }
        }
        public static string MaintainancePaymentStr
        {
            get
            {
                string strTypeStr = "ÓÏÇÏ ãÕÑæÝÇÊ ÇáÕíÇäÉ";
                string strPaymentDesc = strTypeStr;
                string strPaymentType = " ,8 as PaymentType ";
                string Returned = @"SELECT dbo.MNRO.ROReservationID
  as ReservationID, 0 AS InstallmentID, 0 AS InstallmentTypeID, '' AS InstallmentTypeNameA, 0 AS InstallmentNo, 0 AS InstallmentValue, GETDATE() " +
                      " AS InstallmentDueDate, dbo.MNROCreditPayment.PaymentID,'" + strTypeStr + "' as PaymentTypeStr" +//",0 as PaymentDirection  " +
                     strPaymentType + @",0 as TotalDiscount,dbo.GLPayment.PaymentDesc  as PaymentDesc " +
                    ",0 as LastPaymentID ,0 as TotalRemainingValue  " +
                     @"  FROM     dbo.MNROCreditPayment INNER JOIN
                  dbo.MNRO ON dbo.MNROCreditPayment.CreditROID = dbo.MNRO.ROID INNER JOIN
                  dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {


                string strPayment = PaymentStr;

                #region InstaallmentPaymentStr
                string strInstallmentPayment = InstallmentPaymentStr;

                #endregion
                #region TempPaymentStr
                string strTempPayment = TempPaymentStr;

                #endregion
                #region Administrative Payment
                string strAdminstrativePayment = AdministrativePaymentStr;
                #endregion
                #region MulctPayment
                string strMulctPayment = MulctPaymentStr;
                #endregion
                #region PayBack
                string strPayBack = PayBackStr;
                #endregion
                string Returned = "";
                if (_IncludePayBackPayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += strPayBack;
                }
                if (_IncludeMulctPayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += strMulctPayment;
                }
                if (_IncludeInstallmentPayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += strInstallmentPayment;
                }
                if (_IncludeAdministrativePayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += strAdminstrativePayment;
                }
                if (_IncludeTempPayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += strTempPayment;
                }
                if (_IncludeDirectPayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += DirectPaymentStr;
                }
                if (_IncludeInsurancePayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += InsurancePaymentStr;
                }
                if (_IncludeMaintainancePayment)
                {
                    if (Returned != "")
                        Returned += " union ";
                    Returned += MaintainancePaymentStr;
                }
                #region Reservation Region
                string strReservation = ReservationStr;

                #endregion

                Returned = "select ParentPaymentTable.*,PaymentTable.* " +
                        " from (" + Returned + ") as PaymentTable inner join  " +
                        " (" + strPayment + ") as ParentPaymentTable on PaymentTable.PaymentID = ParentPaymentTable.NativePaymentID ";
                Returned = "select PaymentTable.*,ReservationTable.* " +
                    " from (" + Returned + ") as PaymentTable ";
                if (!_IncludeDirectPayment || _ContractDateRange || _ReservationID != 0 || (_UnitCode != null && _UnitCode != ""))
                    Returned += " inner join ";
                else
                    Returned += " left outer join ";
                Returned += " (" + strReservation + ") as ReservationTable " +
              " on PaymentTable.ReservationID = ReservationTable.CurrentReservation ";
                if (_ResubmissionIDs != null && _ResubmissionIDs != "")
                {
                    ReservationResubmissionDb objResubmission = new ReservationResubmissionDb();
                    objResubmission.ResubmissionStatus = 1;
                    objResubmission.ResubmissionTypeIDs = _ResubmissionIDs;
                    objResubmission.ResubmissionStartDateRange = _ResubmissionDateRange;
                    objResubmission.ResubmissionDateStart = _ResubmissionStartDate;
                    objResubmission.ResubmissionDateEnd = _ResubmissionEndDate;
                    objResubmission.ResubmissionAlertDateRange = _ResubmissionAlertDateRange;
                    objResubmission.ResubmissionAlertDateStart = _ResubmissionAlertStartDate;
                    objResubmission.ResubmissionAlertDateEnd = _ResubmissionAlertEndDate;
                    objResubmission.Serial = _ResubmissionSerial;
                    string strReservationResubmission = @" select distinct ResubmissionReservation from (" + objResubmission.StrSearch + @") as ResubmissionTable ";
                    Returned += " inner join (" + strReservationResubmission + @") ResubmissionReservationTable
    on ResubmissionReservationTable.ResubmissionReservation = ReservationTable.CurrentReservation  ";
                }
                return Returned;
            }
        }
        public string SumSearchStr
        {
            get
            {
                string Returned = "";
                string strSelect = "sum(case when PaymentDirection=1 then PaymentValue else -1*PaymentValue end) as PaymentValue ";
                strSelect += ",sum(case when PaymentDirection = 0 then -1 else 1 end * case when PaymentType = 1 then PaymentValue else 0 end) as InstallmentPaymentValue ";
                strSelect += ",sum(case when PaymentDirection = 0 then -1 else 1 end * case when PaymentType = 2 then PaymentValue else 0 end) as TempPaymentValue ";
                strSelect += ",sum(case when PaymentDirection = 0 then -1 else 1 end *case when PaymentType = 3 then PaymentValue else 0 end) as MulctPaymentValue ";
                strSelect += ",sum(case when PaymentDirection = 0 then -1 else 1 end *case when PaymentType = 4 then PaymentValue else 0 end) as AdministrativePaymentValue ";
                strSelect += ",sum(case when PaymentDirection = 0 then  1 else -1 end *case when PaymentType = 5 then PaymentValue else 0 end) as PayBackPaymentValue ";
                strSelect += ",sum(case when PaymentType = 6 and PaymentDirection = 1 then PaymentValue else 0 end) as DirectPaymentInValue ";
                strSelect += ",sum(case when PaymentType = 6 and PaymentDirection = 0 then PaymentValue else 0 end) as DirectPaymentOutValue ";
                string strGroup = "";
                string strOrder = "";
                if (_IsBranchGroup)
                {
                    strSelect += ",PaymentBranchName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PaymentBranchName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "PaymentBranchName";
                }
                if (_IsEmployeeGroup)
                {
                    strSelect += ",PaymentApplicantName,PaymentApplicantShortName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PaymentApplicantName,PaymentApplicantShortName ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "PaymentApplicantName";
                }


                if (_IsDayGroup)
                {
                    strSelect += ",year(PaymentDate) as Y,Month(PaymentDate) as M,Day(PaymentDate) as D ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(PaymentDate),Month(PaymentDate),Day(PaymentDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(PaymentDate),Month(PaymentDate),Day(PaymentDate) ";
                }
                else if (_IsMonthGroup)
                {
                    strSelect += ",year(PaymentDate) as Y,Month(PaymentDate) as M ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(PaymentDate),Month(PaymentDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(PaymentDate),Month(PaymentDate)";
                }
                else if (_IsYearGroup)
                {
                    strSelect += ",year(PaymentDate) as Y ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(PaymentDate) ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(PaymentDate) ";
                }

                if (_IsTowerGroup)
                {
                    strSelect += ",TowerName,ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "TowerName,ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName,TowerName";


                }
                else if (_IsProjectGroup)
                {
                    strSelect += ",ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName";
                }

                if (_IsTypeGroup)
                {
                    strSelect += ",PaymentTypeStr";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PaymentTypeStr";
                    //if (strOrder != "")
                    //    strOrder += ",";
                    //strOrder += "PaymentTypeStr";


                }
                if (_IsInstallmentTypeGroup)
                {
                    //InstallmentTypeNameA
                    strSelect += ",InstallmentTypeNameA";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentTypeNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "InstallmentTypeNameA";
                }

                if (_IsCustomerGroup)
                {
                    strSelect += ",CustomerFullName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CustomerFullName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CustomerFullName";
                }
                if (_IsUnitGroup)
                {
                    strSelect += ",UnitFullName,UnitName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "UnitFullName,UnitName ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "UnitFullName,UnitName ";
                }

                Returned = "select " + strSelect + " from (" + SearchStr + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["PaymentID"] != null)
                _PaymentID = int.Parse(objDr["PaymentID"].ToString());
            if (objDr.Table.Columns["ReservationID"] != null)
                _ReservationID = int.Parse(objDr["ReservationID"].ToString());
            if (objDr.Table.Columns["ReservationDate"] != null && objDr["ReservationDate"].ToString() != "")
                _ReservationDate = DateTime.Parse(objDr["ReservationDate"].ToString());
            _IsContracted = false;
            if (objDr.Table.Columns["ReservationContractingDate"] != null)
            {
                if (objDr["ReservationContractingDate"].ToString() != "")
                {
                    _IsContracted = true;
                    _ContractingDate = DateTime.Parse(objDr["ReservationContractingDate"].ToString());
                }
            }
            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerStr = objDr["CustomerFullName"].ToString();
            if (objDr.Table.Columns["UnitFullName"] != null)
                _UnitStr = objDr["UnitFullName"].ToString();
            if (objDr.Table.Columns["UnitName"] != null)
                _UnitNameStr = objDr["UnitName"].ToString();
            if (objDr.Table.Columns["TowerName"] != null)
                _TowerName = objDr["TowerName"].ToString();
            if (objDr.Table.Columns["TowerIsDelivered"] != null)
                _TowerIsDelivered = objDr["TowerIsDelivered"].ToString() == "1";
            if (objDr.Table.Columns["TowerDeliveryDate"] != null)
                DateTime.TryParse(objDr["TowerDeliveryDate"].ToString(), out _TowerDeliveryDate);

            if (objDr.Table.Columns["ProjectName"] != null)
                _ProjectName = objDr["ProjectName"].ToString();
            if (objDr.Table.Columns["ProjectID"] != null && objDr["ProjectID"].ToString() != "")
                _ProjectID = int.Parse(objDr["ProjectID"].ToString());
            if (objDr.Table.Columns["PaymentValue"] != null)
                _PaymentValue = double.Parse(objDr["PaymentValue"].ToString());
            if (objDr.Table.Columns["PaymentDirection"] != null)
                _PaymentDirection = objDr["PaymentDirection"].ToString() == "1";
            if (objDr.Table.Columns["PaymentHasReceipt"] != null && objDr["PaymentHasReceipt"].ToString() != "")
            {
                _HasReceipt = bool.Parse(objDr["PaymentHasReceipt"].ToString());
            }
            if (objDr.Table.Columns["PaymentDate"] != null)
            {
                if (objDr["PaymentDate"].ToString() != "")
                {
                    _IsPaid = true;
                    _PaymentDate = DateTime.Parse(objDr["PaymentDate"].ToString());
                }
                else
                    _IsPaid = false;
            }
            _CheckIsCollected = objDr.Table.Columns["CheckPaymentIsCollected"] != null && objDr["CheckPaymentIsCollected"].ToString() == "1";
            if (objDr.Table.Columns["CheckID"] != null)
            {
                if (objDr["CheckID"].ToString() != "")
                    _CheckID = int.Parse(objDr["CheckID"].ToString());
            }
            if (objDr.Table.Columns["InstallmentID"] != null)
            {
                if (objDr["InstallmentID"].ToString() != "")
                    _InstallmentID = int.Parse(objDr["InstallmentID"].ToString());
            }
            if (objDr.Table.Columns["InstallmentTypeNameA"] != null)
            {
                _InstallmentTypeNameA = objDr["InstallmentTypeNameA"].ToString();
            }
            if (objDr.Table.Columns["InstallmentNo"] != null)
                _InstallmentNo = int.Parse(objDr["InstallmentNo"].ToString());
            if (objDr.Table.Columns["InstallmentValue"] != null)
            {
                _InstallmentValue = double.Parse(objDr["InstallmentValue"].ToString());
            }
            if (objDr.Table.Columns["InstallmentDueDate"] != null)
                _InstallmentDueDate = DateTime.Parse(objDr["InstallmentDueDate"].ToString());
            if (objDr.Table.Columns["PaymentTypeStr"] != null)
                _PaymentTypeStr = objDr["PaymentTypeStr"].ToString();
            if (objDr.Table.Columns["Y"] != null && objDr["Y"].ToString() != "")
                _Y = int.Parse(objDr["Y"].ToString());
            if (objDr.Table.Columns["M"] != null && objDr["M"].ToString() != "")
                _M = int.Parse(objDr["M"].ToString());
            if (objDr.Table.Columns["D"] != null && objDr["D"].ToString() != "")
                _D = int.Parse(objDr["D"].ToString());
            if (objDr.Table.Columns["PaymentApplicantID"] != null && objDr["PaymentApplicantID"].ToString() != "")
                _EmployeeID = int.Parse(objDr["PaymentApplicantID"].ToString());
            if (objDr.Table.Columns["PaymentApplicantName"] != null)
                _EmployeeName = objDr["PaymentApplicantName"].ToString();
            if (objDr.Table.Columns["PaymentApplicantShortName"] != null)
                _EmployeeShortName = objDr["PaymentApplicantShortName"].ToString();
            if (objDr.Table.Columns["PaymentBranchID"] != null && objDr["PaymentBranchID"].ToString() != "")
                _BranchID = int.Parse(objDr["PaymentBranchID"].ToString());
            if (objDr.Table.Columns["PaymentBranchName"] != null)
                _BranchName = objDr["PaymentBranchName"].ToString();
            if (objDr.Table.Columns["InstallmentPaymentValue"] != null && objDr["InstallmentPaymentValue"].ToString() != "")
                _InstallmentPaymentValue = double.Parse(objDr["InstallmentPaymentValue"].ToString());
            if (objDr.Table.Columns["TempPaymentValue"] != null && objDr["TempPaymentValue"].ToString() != "")
                _TempPaymentValue = double.Parse(objDr["TempPaymentValue"].ToString());
            if (objDr.Table.Columns["MulctPaymentValue"] != null && objDr["MulctPaymentValue"].ToString() != "")
                _MulctPaymentValue = double.Parse(objDr["MulctPaymentValue"].ToString());
            if (objDr.Table.Columns["AdministrativePaymentValue"] != null && objDr["AdministrativePaymentValue"].ToString() != "")
                _AdministrativePaymentValue = double.Parse(objDr["AdministrativePaymentValue"].ToString());
            if (objDr.Table.Columns["PayBackPaymentValue"] != null && objDr["PayBackPaymentValue"].ToString() != "")
                _PayBackPaymentValue = double.Parse(objDr["PayBackPaymentValue"].ToString());
            if (objDr.Table.Columns["PaymentTimIns"] != null && objDr["PaymentTimIns"].ToString() != "")
                _PaymentTimIns = DateTime.Parse(objDr["PaymentTimIns"].ToString());
            else
                _PaymentTimIns = _PaymentDate;
            if (objDr.Table.Columns["PaymentType"] != null && objDr["PaymentType"].ToString() != "")
                _PaymentType = int.Parse(objDr["PaymentType"].ToString());
            if (objDr.Table.Columns["PaymentMean"] != null &&
                objDr["PaymentMean"].ToString() != "")
                _PaymentMean = int.Parse(objDr["PaymentMean"].ToString());
            if (objDr.Table.Columns["TotalDiscount"] != null && objDr["TotalDiscount"].ToString() != "")
                _InstallmentDiscount = double.Parse(objDr["TotalDiscount"].ToString());
            if (objDr.Table.Columns["ReceiptID"] != null && objDr["ReceiptID"].ToString() != "")
                _ReceiptID = int.Parse(objDr["ReceiptID"].ToString());
            if (objDr.Table.Columns["PaymentDesc"] != null)
                _PaymentDesc = objDr["PaymentDesc"].ToString();
            if (objDr.Table.Columns["DirectPaymentOutValue"] != null && objDr["DirectPaymentOutValue"].ToString() != "")
                _DirectPaymentOutValue = double.Parse(objDr["DirectPaymentOutValue"].ToString());

            if (objDr.Table.Columns["DirectPaymentInValue"] != null && objDr["DirectPaymentInValue"].ToString() != "")
                _DirectPaymentInValue = double.Parse(objDr["DirectPaymentInValue"].ToString());
            if (objDr.Table.Columns["ReservationCell"] != null && objDr["ReservationCell"].ToString() != "")
                _CellID = int.Parse(objDr["ReservationCell"].ToString());
            if (objDr.Table.Columns["PaymentDirection"] != null && objDr["PaymentDirection"].ToString() != "")
                _PaymentDirection = bool.Parse(objDr["PaymentDirection"].ToString());
            //if (objDr.Table.Columns["CheckDueDate"] != null && objDr["CheckDueDate"].ToString() != "")
            //    _CheckDueDate = DateTime.Parse(objDr["CheckDueDate"].ToString());
            if (objDr.Table.Columns["LastPaymentID"] != null && objDr["LastPaymentID"].ToString() != "")
                _InstallmentLastPaymentID = int.Parse(objDr["LastPaymentID"].ToString());
            if (objDr.Table.Columns["TotalRemainingValue"] != null && objDr["TotalRemainingValue"].ToString() != "")
                _InstallmentRemainingValue = int.Parse(objDr["TotalRemainingValue"].ToString());
            //if (objDr.Table.Columns["TotalDiscount"] != null && objDr["TotalDiscount"].ToString() != "")
            //    _InstallmentDiscount= int.Parse(objDr["TotalDiscount"].ToString());
            if (objDr.Table.Columns["UnitIsDelivered"] != null && objDr["UnitIsDelivered"].ToString() != "0")
                _UnitIsDelivered = true;

        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {

            string strSql = SearchStr;

            if (_MaxID == 0 && _MinID == 0)
            {
                string strCountSql = "select count(*) as ResultCount,sum(PaymentValue) as ResultValue from (" +
                    strSql + ")  AS NativeTable ";
                DataTable dtReultTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                if (dtReultTemp.Rows.Count > 0)
                {
                    _ResultCount = int.Parse(dtReultTemp.Rows[0]["ResultCount"].ToString());
                    if (dtReultTemp.Rows[0]["ResultValue"].ToString() != "")
                        _ResultValue = double.Parse(dtReultTemp.Rows[0]["ResultValue"].ToString());
                }


            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and PaymentTable.PaymentID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and PaymentTable.PaymentID<" + _MinID;
                }
            }
            strSql = "select distinct top 100000 * from (" + strSql + ") as NativeTable " +
                        " ORDER BY PaymentID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable SearchSum()
        {
            string strSql = SumSearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void CreateTransaction()
        {
            if (_TransactionTable == null || _TransactionTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TransactionTable.Rows.Count];
            string strTemp = "";
            int intIndex = 0;
            DataRow[] arrDr;

            foreach (DataRow objDr in _TransactionTable.Rows)
            {

                TransactionDb objTransactionDb = new TransactionDb(objDr);
                strTemp = objTransactionDb.AddStr;
                strTemp += " declare @TransactionID int; ";
                strTemp += " set @TransactionID = (select @@Identity as TransactionID); ";
                strTemp += "update GLPayment set  GLTransaction=@TransactionID " +
                    " where  PaymentID= " + objDr["PaymentID"].ToString();



                arrStr[intIndex] = strTemp;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
