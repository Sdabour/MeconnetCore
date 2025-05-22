using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationDb 
    {
        #region Private Data
        protected int _ID;
        //protected int _OldReservationID;
        protected int _CustomerID;
        protected int _UnitID;
        protected int _FloorOrder;
        protected int _OldUnitID;
        protected int _Strategy;
        protected int _Status;
        protected int _GLAccount;
        protected int _ContractingTransactionID;
        protected int _DeliveryTransactionID;
        protected int _CancelationTransactionID;

        string _CustomerStr;
        string _UnitStr;
        int _TowerID;
        string _TowerName;
        string _ProjectName;
        int _FloorID;
        string _SalesMan;
        string _ModelName;
        protected DateTime _Date;
        protected DateTime _DeliveryDate;
        protected DateTime _RealDeliveryDate;
        protected bool _IsDelegated;
        protected bool _IsReservedAgain;
        protected int _IsReservedStatus;/*
                                         * 0 dont care
                                         * 1 Is Reserved Unit.CurrentReservation = ReservationID
                                         * 2 is not Reserved Unit.CurrentReservation != Reservationid
                                         */
        protected int _HasInstallmentStatus;
        protected DateTime _DelegationDate;
        protected double _Value;
        protected double _ContributionValue;
        protected double _ContributionPerc;
        protected double _UnitPrice;
        double _NativeUnitPrice;

        public double NativeUnitPrice
        {
            get { return _NativeUnitPrice; }
            set { _NativeUnitPrice = value; }
        }
        protected double _CachePrice;
        protected int _Finishing;
        protected bool _ProfitIsCompound;
        protected double _ProfitValue;
        protected int _ProfitPeriod;
        protected double _PeriodAmount;
        protected int _Period;
        protected int  _MaxID;
        protected int _MinID;
        protected bool _OnlyExpiredReservation;
        protected double _PreviousPaidValue;//presents the previous 
        protected bool _IsDelivered;
        protected bool _DataIsHidden;
        protected bool _IsFree;
        protected bool _IsNew;
        double _DiscountValue;
        double _BonusValue;
        double _InstallmentDiscountValue;
        double _InstallmentPaymentValue;
        double _InstallmentDeservedValue;
        double _MulctPaymentValue;
        string _InstallmentStartDate;
        string _InstallmentEndDate;
        protected int _FreeStatus;
        protected int _NewStatus;
        protected int _Parent;
        protected double _TempPayment;
        protected double _InsuranceInPayment;
        protected double _InsuranceOutPayment;
        protected double _AdministrativePaymentValue;
        protected double _RemainingValue;
        protected double _TotalPaidValue;
        protected double _TotalInstallmentPaidValue;
        protected int _CampaignID;
        protected double _DirectCancelationCost;
        double _UtilityValue;

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
        int _CancelationType;

        public int CancelationType
        {
            get { return _CancelationType; }
            set { _CancelationType = value; }
        }
        #region Cession
        int _NewReservationID;
        int _OldReservationID;
        string _OldReservationUnitFullName;
        string _OldReservationCustomerName;
        string _NewReservationUnitName;
        string _NewReservationCustomerName;
        double _CessionCost;
        double _OldReservationPreviousPaidValue;
        DateTime _CessionDate;
        #endregion
        #region GL
        int _LastTransactionType;
        double _LastTransactionValue;
        int _LastGLTransaction;
        #endregion
        protected bool _TowerIsDelivered;
        protected DateTime _TowerDeliveryDate;
        protected DateTime _StatusDate;
        //paid value in case of Cession
        #region Data To Stop Dealing
        protected string _StopReason;
        protected DateTime _OpenTime;
        protected bool _StopedPermanently;
        protected int _DealStatus;//0 Not Specified
                                                //1 Not Stoped
                                                //2 Stoped
        protected int _AttachmentStatus;
        protected int _GLLeafAccount;
        protected int _GLContractingTransaction;
        protected int _GLDeliveryTransaction;

        #endregion
        string _UnitIDs;
        string _CustomerIDs;
        string _ActiveReservationIDs;
        protected double _ProfitPeriodAmount;
        protected int _Allowance;
        protected  string _Note;
        protected DateTime _ContractingDate;
        protected bool _IsContracted;
        protected bool _IsComplete;

        protected DateTime _LimitDate;
        protected int _BranchID;
        protected string _BranchIDs;
        protected int _SalesManID;
        BranchDb _BranchDb;

        protected int _UserIns;
        protected int _UserUpd;

        protected DateTime _TimeIns;
        protected DateTime _TimeUpd;
        private int _TopSelect = 0;

      
        protected DataTable _CustomerTable;
        protected DataTable _WorkerContributionTable;
        StrategyDb _StrategyDb;
        CustomerDb _CustomerDb;
       // UnitDb _UnitDb;
        protected DataTable _InstallmentTable;
        protected DataTable _DiscountTable;
        protected DataTable _BonusTable;
        protected DataTable _TempPaymentTable;
        protected DataTable _AdministrativePaymentTable;
        protected DataTable _UtilityTable;
        protected DataTable _UnitTable;
        DataTable _TransactionTable;
        DataTable _TRansactionElementTable;
       // DataTable _ReservationTransactionTable;
        #region Deleted Table
        protected DataTable _DeletedUtilityTable;
        protected DataTable _DeletedDiscountTable;
        protected DataTable _DeletedInstallmentTable;
        protected DataTable _DeletedBonusTable;
        protected DataTable _DeletedAttachmentTable;
        protected DataTable _DeletedPaymentTable;
        protected DataTable _DeletedAdministrativePaymentTable;
        #endregion

        protected bool _EditSucceded;
       
        #region Private Data for Search
        bool _UseCustomer;
        bool _UseUnit;
        bool _ContractingDateRange;
        DateTime _ContractingStartDate;
        DateTime _ContractingEndDate;
        
        bool _ReservationDateRange;
        DateTime _ReservationStartDate;
        DateTime _ReservationEndDate;

        bool _StatusDateRange;
        DateTime _StatusStartDate;
        DateTime _StatusEndDate;

        bool _DelivaryDateRange;
        DateTime _DelivaryStartDate;
        DateTime _DelivaryEndDate;
        bool _RealDelivaryDateRange;
        DateTime _RealDelivaryStartDate;
        DateTime _RealDelivaryEndDate;
        bool _OnlyNonStoped;
        string _IDs;
        string _StatusStr;
        byte _DelivaryStatus;
        int _DelegateStatus;/*0 dontcare
                             1 only delegated 
                             2 only not delegated*/
        int _SoldStatus;/*0 dont care
                         1 only sold
                         2 only not sold*/
        #region Private Data For GL
        byte _LeafAccountStatus;//0 not mentioned
                                               //1 LeafAccount=0
                                              // 2 LeafAccount<>0
        byte _AccountStatus;
        byte _ContractingTransactionStatus;
        byte _DeliveryTransactionStatus;
        int _CancelationTransactionStatus;
        int _ReservationChangedStatus;
        DataTable _AccountTable;
        DataTable _ContractingTransactionTable;
        DataTable _ReservationTransactionTable;
        DataTable _ContractingTransactionElementTable;
        DataTable _DeliveryTransactionTable;
        DataTable _DeliveryTransactionElementTable;
        DataTable _CanceledTransactionTable;
        #endregion
        #region External Private Data For search
        string _CustomerName;
        string _CustomerNationality;

        int _ImportantPerson;
        int _JobID;
        int _NationalityID;
        string _CellIDs;
        int _CellFamilyID;
        string _UnitCode;
        string _UnitName;
        string _UnitSurvey;
        double _FromSurvey;
        double _ToSurvey;
        int _ResultCount;
        double _ResultVaue;
        double _ResultDiscountValue;
        double _ResultBonusValue;
        int _ParentStatus;
        int _UnitTypeID;
        #endregion
#region private data for financial search
        double _StartReservationValue;
        double _EndReservationValue;
        double _StartDueValue;
        double _EndDueValue;
        double _StartPaidValue;
        double _EndPaidValue;
        string _InstallmentTypeIDs;
#endregion
        #endregion
        #region Private Data Grouping
        bool _IsBranchGrouping;
        bool _IsSalesManGrouping;
        bool _IsProjectGrouping;
        bool _IsTowerGrouping;
        bool _IsYearGrouping;
        bool _IsMonthGrouping;
        bool _IsDayGrouping;
        #endregion
        #region Private Static Data for Caching
        static DataTable _CachUnitTable;
        static DataTable _CachReservationTable;
        static DataTable _CachChildReservation;
        static DataTable _CachInstallmentTable;
        static DataTable _CachInstallmentPaymentTable;
        static DataTable _CachWorkerTable;
        static DataTable _CachInstallmentMulctTable;
        static DataTable _CachMulctPaymentTable;
        static DataTable _CachAttachmentTable;
        static DataTable _CachDiscountTable;
        static DataTable _CachBonusTable;
        static DataTable _CachTempPaymentTable;
        static DataTable _CachAdministrativePaymentTable;
        static DataTable _CachInsurancePaymentTable;
        static DataTable _CachCustomerTable;
        static DataTable _CachCheckTable;
       // static DataTable _CachInstallmentPaymentTable;
        static DataTable _CachInstallmentDiscountTable;
        static DataTable _CachCellTable;
        static DataTable _CachUtilityTable;
        static DataTable _CachUtilityPaymentTable;
        static DataTable _CachOldReservationTable;
        static string _OldReservationIDs;
        static string _ReservationIDs;
        #endregion
        #endregion
        #region Constructors
        public ReservationDb()
        {
            

        }
        public ReservationDb(int intID)
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
        public ReservationDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Private Properties
        void CopyTempUnit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table CRMReservationUnitTemp");
            SqlBulkCopy objCopy =
                new SqlBulkCopy(SysData.SharpVisionBaseDb.Connection);
            objCopy.DestinationTableName = "CRMReservationUnitTemp";
            string strGUID = Guid.NewGuid().ToString() ;

            objCopy.WriteToServer(_UnitTable);
        }
        string NotAvailableUnit1
        {
            get
            {
                string strSql = "";
                if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                    return strSql;
                SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table CRMReservationUnitTemp");
                SqlBulkCopy objCopy =
                    new SqlBulkCopy(SysData.SharpVisionBaseDb.Connection);
                objCopy.DestinationTableName = "CRMReservationUnitTemp";
                objCopy.WriteToServer(_UnitTable);

                string strUnitID = SysUtility.GetStringArr(_UnitTable, "UnitID", 5000)[0];


                UnitDb objUnitDb = new UnitDb();
                objUnitDb.UnitIDs = strUnitID;
               
                if (_Parent == 0)
                {
               
                    strSql = @"select count(DISTINCT dbo.CRMUnit.UnitID)
from CRMUnit  LEFT OUTER JOIN
    dbo.CRMReservationTenancy 
ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservationTenancy.ReservationID  
where UnitID in(" + strUnitID + ") " +
                        " and( "+
                        " UnitClosedPermanent=1  "+
                        " or ( " +
                        "(CRMUnit.CurrentReservation <> 0 and ( dbo.CRMReservationTenancy.ReservationID is null or dbo.CRMReservationTenancy.ReservationTenancyEndDate > GetDate() )) " +
                        "and CRMUnit.CurrentReservation<>" + _ID + ")" +// " and CRMUnit.CurrentReservation <> " + _Parent + ") " +
                                " or (UnitUserClosed<>0 and UnitUserClosed<>" + SysData.CurrentUser.ID + " and UnitTimeOpen>GetDate()"+
                                " )"+
                                ")  ";
                }
                else
                {
                    strSql = @"select count(DISTINCT dbo.CRMUnit.UnitID) 
from CRMUnit   where UnitID in@(" + strUnitID + ") " +
                        " and ("+
                        " UnitClosedPermanent=1  or (CRMUnit.CurrentReservation <> 0 and CRMUnit.CurrentReservation<>" + _ID +" and CRMUnit.CurrentReservation <> " + _Parent + ") " +
                                " or (UnitUserClosed<>0 and UnitUserClosed<>" + SysData.CurrentUser.ID +
                                " and UnitTimeOpen>GetDate() ) "+
                                " )"; 
                }
                return strSql;
            }
        }
        string NotAvailableUnit
        {
            get
            {
                string strSql = "";
                if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                    return strSql;
                

                string strUnitID = SysUtility.GetStringArr(_UnitTable, "UnitID", 5000)[0];

                string strID = _ID == 0 ? "@ID" : _ID.ToString();
                UnitDb objUnitDb = new UnitDb();
                objUnitDb.UnitIDs = strUnitID;

                if (_Parent == 0)
                {

                    strSql = @"select count(DISTINCT dbo.CRMUnit.UnitID)
from CRMUnit  LEFT OUTER JOIN
    dbo.CRMReservationTenancy 
ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservationTenancy.ReservationID  
where UnitID in(" + strUnitID + ") " +
                        " and( " +
                        " UnitClosedPermanent=1  " +
                        " or ( " +
                        "(CRMUnit.CurrentReservation <> 0 " +
                        "and (" +
                        " dbo.CRMReservationTenancy.ReservationID is null " +
                        "or (dbo.CRMReservationTenancy.ReservationTenancyIsAutomaticCancelation = 0 or dbo.CRMReservationTenancy.ReservationTenancyEndDate > GetDate())" +
                        " )" +
                        ") " +
                        "and CRMUnit.CurrentReservation<>" + _ID + ")" +// " and CRMUnit.CurrentReservation <> " + _Parent + ") " +
                                " or (UnitUserClosed<>0 and UnitUserClosed<>" + SysData.CurrentUser.ID + " and UnitTimeOpen>GetDate()" +
                                " )" +
                                ")  ";
                }
                else
                {
                    strSql = @"select count(DISTINCT dbo.CRMUnit.UnitID) 
from CRMUnit   where UnitID in@(" + strUnitID + ") " +
                        " and (" +
                        " UnitClosedPermanent=1  or (CRMUnit.CurrentReservation <> 0 and CRMUnit.CurrentReservation<>" + _ID + " and CRMUnit.CurrentReservation <> " + _Parent + ") " +
                                " or (UnitUserClosed<>0 and UnitUserClosed<>" + SysData.CurrentUser.ID +
                                " and UnitTimeOpen>GetDate() ) " +
                                " )";
                }
                return strSql;
            }
        }
        #endregion
        #region Public Properties
        #region Dinamic Property

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
        public int CampaignID
        {
            set
            {
                _CampaignID = value;
            }
            get
            {
                return _CampaignID;
            }
        }
        public int UnitID
        {
            set
            {
                _UnitID = value;
            }
            get
            {
                return _UnitID;
            }
        }
        public int Strategy
        {
            set
            {
                _Strategy = value;
            }
            get
            {
                return _Strategy;
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
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        public bool IsDelivered
        {
            set
            {
                _IsDelivered = value;
            }
            get
            {
                return _IsDelivered;
            }
        }
        public bool DataIsHidden
        {
            set
            {
                _DataIsHidden = value;
            }
            get
            {
                return _DataIsHidden;
            }
        }

        public DateTime RealDeliveryDate
        {
            set
            {
                _RealDeliveryDate = value;
            }
            get
            {
                return _RealDeliveryDate;
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
        public double PreviousPaidValue
        {
            set
            {
                _PreviousPaidValue = value;
            }
            get
            {
                return _PreviousPaidValue;
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
        public int SalesManID
        {
            set
            {
                _SalesManID = value;
            }
            get
            {
                return _SalesManID;
            }
        }
       
        public int GLContractingTransaction
        {
            set
            {
                _GLContractingTransaction = value;
            }
            get
            {
                return _GLContractingTransaction;
            }
        }
        public int GLDeliveryTransaction
        {
            set
            {
                _GLDeliveryTransaction = value;
 
            }
            get
            {
                return _GLDeliveryTransaction;
            }
        }
       
        public bool IsDelegated
        {
            set
            {
                _IsDelegated = value;
            }
            get
            {
                return _IsDelegated;
            }
        
        }
        public DateTime DelegationDate
        {
            set
            {
                _DelegationDate = value;
            }
            get
            {
                return _DelegationDate;
            }
        }
        public bool IsReservedAgain
        {
            set
            {
                _IsReservedAgain = value;
            }
            get
            {
                return _IsReservedAgain;
            }
        }
        public bool IsNew
        {
            set
            {
                _IsNew = value;
            }
            get
            {
                return _IsNew;
            }
        }
        public int ContractingTransactionID
        {
            set 
            {
                _ContractingTransactionID = value;
            }
            get 
            {
                return _ContractingTransactionID;
            }
        }
        public int DeliveryTransactionID
        {
            set
            {
                _DeliveryTransactionID = value;
            }
            get
            {
                return _DeliveryTransactionID;
            }
        }
        public int CancelationTransactionID
        {
            set 
            {
                _CancelationTransactionID = value;
            }
            get
            {
                return _CancelationTransactionID;
            
            }
        }

        public string StatusStr
        {
            set
            {
                _StatusStr = value;
            }
        }
        public int DealStatus
        {
            set
            {
                _DealStatus = value;
            }
        }
        public int DelegateStatus
        {
            set
            {
                _DelegateStatus = value;
            }
        }
        public int SoldStatus
        {
            set
            {
                _SoldStatus = value;
            }
        }
        public int IsReservedStatus
        {
            set
            {
                _IsReservedStatus = value;
            }
        }
        public int HasInstallmentStatus
        {
            set
            {
                _HasInstallmentStatus = value;
            }
        }
        int _PaybackCompleteStatus;

        public int PaybackCompleteStatus
        {
            get { return _PaybackCompleteStatus; }
            set { _PaybackCompleteStatus = value; }
        }
        public int ParentStatus
        {
            set
            {
                _ParentStatus = value;
            }
        }
        public string BranchIDs
        {
            set
            {
                _BranchIDs = value;
            }
        }
        string _SalesMenIDs;

        public string SalesMenIDs
        {
          
            set { _SalesMenIDs = value; }
        }
        public int AttachmentStatus
        {
            set
            {
                _AttachmentStatus = value;
            }
        }
        public BranchDb BranchDb
        {
            get
            {
                return _BranchDb;
            }
        }
        public StrategyDb StrategyDb
        {
            get
            {
                return _StrategyDb;
            }
        }
      
      
        public DataTable WorkerContributionTable
        {
            set
            {
                _WorkerContributionTable = value;
            }
            get
            {
                return _WorkerContributionTable;
            }

        }
        public DataTable CustomerTable
        {
            set
            {
                _CustomerTable = value;
            }
        }
        public DataTable UnitTable
        {
            set
            {
                _UnitTable = value;
            }
        }

        public bool StatusDateRange
        {
            set
            {
                _StatusDateRange = value;
            }
        }
        public DateTime StatusStartDate
        {
            set
            {
                _StatusStartDate = value;
            }
        }
        public DateTime StatusEndDate
        {
            set
            {
                _StatusEndDate = value;
            }
        }



        public double ContributionValue
        {
            set 
            {
                _ContributionValue = value;
            }
            get 
            {
                return _ContributionValue; 
            }
            
        }
        public double ContributionPerc
        {
            set 
            {
                _ContributionPerc = value; 
            }
            get 
            { 
                return _ContributionPerc; 
            }
            
        }
        public double UnitPrice
        {
            set
            {
                _UnitPrice = value; 
            }
            get 
            {
                return _UnitPrice; 
            }
            
        }
        public double CachePrice
        {
            set
            {
                _CachePrice = value;
            }
            get
            {
                return _CachePrice;
            }
        }
        public int Finishing
        {
            set 
            { 
                _Finishing = value; 
            }
            get
            {
                return _Finishing; 
            }
            
        }
        public bool ProfitIsCompound
        {
            set
            {
                _ProfitIsCompound = value; 
            }
            get 
            {
                return _ProfitIsCompound;
            }
            
        }
        public double ProfitValue
        {
            set 
            {
                _ProfitValue = value; 
            }
            get 
            {
                return _ProfitValue; 
            }
            
        }
        public int ProfitPeriod
        {
            set
            {
                _ProfitPeriod = value;
            }
            get
            { 
                return _ProfitPeriod; 
            }
            
        }
        public double PeriodAmount
        {
            set 
            {
                _PeriodAmount = value; 
            }
            get 
            {
                return _PeriodAmount; 
            }
            
        }
        public int Period
        {
            set
            { 
                _Period = value;
            }
            get 
            {
                return _Period; 
            }
            
        }
        public string Note
        {
            set
            {
                _Note = value;
            }
            get
            {
                return _Note;
            }


        }
        public int Parent
        {
            set
            {
                _Parent = value;
            }
            get
            {
                return _Parent;
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
        public int Allowance
        {
            set
            {
                _Allowance = value;
            }
            get
            {
                return _Allowance;
            }

        }
        public double ProfitPeriodAmount
        {
            set
            {
                _ProfitPeriodAmount = value;
            }
            get
            {
                return _ProfitPeriodAmount;
            }

        }
        public DateTime LimitDate
        {
            set
            {
                _LimitDate = value;
            }
            get
            {
                return _LimitDate;
            }
        }
       
        public int GLAccount
        {
            set
            {
                _GLAccount = value;
            }
            get
            {
                return _GLAccount;
            }
        }
        public int GLLeafAccount
        {
            set
            {
                _GLLeafAccount = value;
            }
            get
            {
                return _GLLeafAccount;
            }
        }
   
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
        }
        public string ActiveReservationIDs
        {
            set
            {
                _ActiveReservationIDs = value;
            }
           
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public int TopSelect
        {

            set
            {
                _TopSelect = value;
            }
        }
        public bool UseCustomer
        {
            set
            {
               _UseCustomer = value;
            }
        }
        public bool UseUnit
        {
            set
            {
                _UseUnit = value;
            }
        }
        public byte DelivaryStatus
        {
            set
            {
                _DelivaryStatus = value;
            }
        }
        public byte LeafAccountStatus
        {
            set
            {
                _LeafAccountStatus = value;
            }
        }
        public byte AccountStatus
        {
            set
            {
                _AccountStatus = value;
            }
        }
        public byte ContractingTransactionStatus
        {
            set
            {
                _ContractingTransactionStatus = value;
            }
        }
        public byte DeliveryTransactionStatus
        {
            set
            {
                _DeliveryTransactionStatus = value;
            }
        }
        public int CancelationTransactionStatus
        {
            set
            {
                _CancelationTransactionStatus = value;
            }
        }
        public int ReservationChangedStatus
        {
            set
            {
                _ReservationChangedStatus = value;
            }
        }
        public bool ReservationDateRange
        {
            set
            {
                _ReservationDateRange = value;
            }
        }

        public int UserIns
        {
            set
            {
                _UserIns = value;
            }
            get
            {
                return _UserIns;
            }
        }
        public int UserUpd
        {
            set
            {
                _UserUpd = value;
            }
            get
            {
                return _UserUpd;
            }
        }
        public DateTime TimeIns
        {
            set
            {
                _TimeIns = value;
            }
            get
            {
                return _TimeIns;
            }
        }
        public DateTime TimeUpd
        {
            set
            {
                _TimeUpd = value;
            }
            get
            {
                return _TimeUpd;
            }
        }


        public DateTime ReservationStartDate
        {
            set
            {
                _ReservationStartDate = value;
            }
        }
        public double TempPayment
        {
            set
            {
                _TempPayment = value;
            }
            get
            {
                return _TempPayment;
            }
        }
        public double InsuranceInPayment
        {
            set
            {
                _InsuranceInPayment = value;
            }
            get
            {
                return _InsuranceInPayment;
            }
        }
        public double InsuranceOutPayment
        {
            set
            {
                _InsuranceOutPayment = value;
            }
            get
            {
                return _InsuranceOutPayment;
            }
        }
        public double AdministrativePaymentValue
        {
            set
            {
                _AdministrativePaymentValue = value;
            }
            get
            {
                return _AdministrativePaymentValue;
            }
        }
        public double RemainingValue
        {
            get
            {
                return _RemainingValue;
            }
        }
        public double TotalPaidValue
        {
            get
            {
                return _TotalPaidValue;
            }
        }
        public double TotalInstallmentPaidValue
        {
            get
            {
                return _TotalInstallmentPaidValue;
            }
        }
        public int LastTransactionType
        {
            get
            {
                return _LastTransactionType;
            }
        }
        public double LastTransactionValue
        {
            get
            {
                return _LastTransactionValue;
            }
        }
        public int LastGLTransaction
        {
            get
            {
                return _LastGLTransaction;
            }
        }
     
        #region Cession
        public int NewReservationID
        {
            set
            {
                _NewReservationID = value;
            }
            get
            {
                return _NewReservationID;
            }
        }
        public int OldReservationID
        {
            set
            {
                _OldReservationID = value;
            }
            get
            {
                return _OldReservationID;
            }
        }
        public string OldReservationUnitFullName
        {
            set
            {
                _OldReservationUnitFullName = value;
            }
            get
            {
                return _OldReservationUnitFullName;
            }
        }
        public string OldReservationCustomerName
        {
            set
            {
                _OldReservationCustomerName = value;
            }
            get
            {
                return _OldReservationCustomerName;
            }

        }
        public string NewReservationUnitName
        {
            set
            {
                _NewReservationUnitName = value;
            }
            get
            {
                return _NewReservationUnitName;
            }
        }
        public string NewReservationCustomerName
        {
            set
            {
                _NewReservationCustomerName = value;
            }
            get
            {
                return _NewReservationCustomerName;
            }
        }
        public double CessionCost
        {
            set
            {
                _CessionCost = value;
            }
            get
            {
                return _CessionCost;
            }
        }
        public double OldReservationPreviousPaidValue
        {
            set
            {
                _OldReservationPreviousPaidValue = value;
            }
            get
            {
                return _OldReservationPreviousPaidValue;
            }
        }
        public DateTime CessionDate
        {
            set
            {
                _CessionDate = value;
            }
            get
            {
                return _CessionDate;
            }
        }
        #endregion
        #region Tenant
        bool _IsTenancy;
        public bool IsTenancy
        { set => _IsTenancy = value; get => _IsTenancy; }
        /// <summary>
        /// Tenancy status 0 not specified
        /// 1 is tenancy 
        /// 2 is not tenancy
        /// 3 is expired tenancy
        /// 4 is valid tenancy
        /// </summary>
        int _TenancyStatus;
        public int TenancyStatus
        { set => _TenancyStatus = value; }

        int _TenancyID;
        public int TenancyID
        {
            set
            {
                _TenancyID = value;
            }
            get
            {
                return _TenancyID;
            }
        }
        DateTime _TenancyStartDate;
        public DateTime TenancyStartDate
        {
            set
            {
                _TenancyStartDate = value;
            }
            get
            {
                return _TenancyStartDate;
            }
        }
        DateTime _TenancyEndDate;
        public DateTime TenancyEndDate
        {
            set
            {
                _TenancyEndDate = value;
            }
            get
            {
                return _TenancyEndDate;
            }
        }
        bool _IsAutomaticCancelation;
        public bool IsAutomaticCancelation
        { set => _IsAutomaticCancelation = value; get => _IsAutomaticCancelation; }
        double _TenancyStartValue;
        public double TenancyStartValue
        {
            set
            {
                _TenancyStartValue = value;
            }
            get
            {
                return _TenancyStartValue;
            }
        }
        int _TenancyFrequncyPeriod;
        public int TenancyFrequncyPeriod
        {
            set
            {
                _TenancyFrequncyPeriod = value;
            }
            get
            {
                return _TenancyFrequncyPeriod;
            }
        }
        int _TenancyChangeFrequencyPeriod;
        public int TenancyChangeFrequencyPeriod
        {
            set
            {
                _TenancyChangeFrequencyPeriod = value;
            }
            get
            {
                return _TenancyChangeFrequencyPeriod;
            }
        }
        double _TenancyChangePerc;
        public double TenancyChangePerc
        {
            set
            {
                _TenancyChangePerc = value;
            }
            get
            {
                return _TenancyChangePerc;
            }
        }
        public string AddTenancyStr
        {
            get
            {
                string strDeleteTenancy = " delete from CRMReservationTenancy where ReservationID = " + _ID; ;
                if (!_IsTenancy)
                {
                    if (_ID == 0)
                        return " ";
                    else
                        return strDeleteTenancy;
                }
                string strID =
                    _ID==0? "@ID" : _ID.ToString();
                int intIsAutomaticCancelation = _IsAutomaticCancelation ? 1 : 0;

                string Returned = "";
                if (_ID != 0)
                    Returned += strDeleteTenancy;
                Returned+= @" insert into CRMReservationTenancy 
(ReservationID,ReservationTenancyStartDate
,ReservationTenancyEndDate,ReservationTenancyIsAutomaticCancelation,ReservationTenancyStartValue
,ReservationTenancyFrequncyPeriod,ReservationTenancyChangeFrequencyPeriod
,ReservationTenancyChangePerc, ReservationTenancyAutoChanged, ReservationTenancyCancelationSent)
values (" + strID + @"," + 
(TenancyStartDate.ToOADate() - 2).ToString() +
@"," + (TenancyEndDate.ToOADate() - 2).ToString() + @"," + intIsAutomaticCancelation + @"," +
TenancyStartValue + @"," + TenancyFrequncyPeriod + @"," +
TenancyChangeFrequencyPeriod + @"," + TenancyChangePerc + @",0,0) ";
                return Returned;
            }
        }
        public string EditTenancyStr
        {
            get
            {
                string Returned = " delete from CRMReservationTenancy  where ReservationID = " +_ID;
                if (_IsTenancy)
                    Returned += AddTenancyStr;
                return Returned;
            }
        }
        public string DeleteTenancyStr
        {
            get
            {
                string Returned = " update CRMReservationTenancy set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchTenancyStr
        {
            get
            {
                return @" SELECT   ReservationID AS ReservationTenancyID, ReservationTenancyStartDate, ReservationTenancyEndDate,ReservationTenancyIsAutomaticCancelation, ReservationTenancyStartValue, ReservationTenancyFrequncyPeriod, ReservationTenancyChangeFrequencyPeriod, 
                         ReservationTenancyChangePerc
FROM            dbo.CRMReservationTenancy ";
            }
        }

        #endregion Tenancy
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
        public DateTime ReservationEndDate
        {
            set
            {
                _ReservationEndDate = value;
            }
        }
        public bool ContractingDateRange
        {
            set
            {
                _ContractingDateRange = value;
            }
        }
        public DateTime ContractingStartDate
        {
            set
            {
                _ContractingStartDate = value;
            }
        }
        public DateTime ContractingEndDate
        {
            set
            {
                _ContractingEndDate = value;
            }
        }
        public bool DelivaryDateRange
        {
            set
            {
                _DelivaryDateRange = value;
            }
        }
        public DateTime DelivaryStartDate
        {
            set
            {
                _DelivaryStartDate = value;
            }
        }
        public DateTime DelivaryEndDate
        {
            set
            {
                _DelivaryEndDate = value;
            }
        }
        public bool RealDelivaryDateRange
        {
            set
            {
                _RealDelivaryDateRange = value;
            }
        }
        public DateTime RealDelivaryStartDate
        {
            set 
            {
                _RealDelivaryStartDate = value;
            }
        }
        public DateTime RealDelivaryEndDate
        {
            set 
            {
                _RealDelivaryEndDate = value;
            }
        }
        public double StartReservationValue
        {
            set
            {
                _StartReservationValue = value; 
            }
        }
        public double EndReservationValue
        {
            set
            {
                _EndReservationValue = value;
            }
        }
        public double StartDueValue
        {
            set
            {
                _StartDueValue = value;
            }
        }
        public double EndDueValue
        {
            set
            {
                _EndDueValue = value;   
            }
        }

        bool _IsDueDated;

        public bool IsDueDated
        {
           
            set { _IsDueDated = value; }
        }
        DateTime _DueDateStart;

        public DateTime DueDateStart
        {
           
            set { _DueDateStart = value; }
        }
        DateTime _DueDateEnd;

        public DateTime DueDateEnd
        {
            
            set { _DueDateEnd = value; }
        }

        public double StartPaidValue
        {
            set
            {
                _StartPaidValue = value;
            }
        }
        public double EndPaidValue
        {
            set
            {
                _EndPaidValue = value;
            }
        }
        public string InstallmentTypeIDs
        {
            set
            {
                _InstallmentTypeIDs = value;
            }
        }



        public DataTable DeletedPaymentTable
        {
            set
            {
                _DeletedPaymentTable = value;
            }
        }
        public DataTable DeletedAdministrativePaymentTable
        {
            set
            {
                _DeletedAdministrativePaymentTable = value;
            }
        }
        public DataTable InstallmentTable
        {
            set
            {
                _InstallmentTable = value;
            }
        }
        public DataTable DiscountTable
        {
            set
            {
                _DiscountTable = value;
            }
        }
        public DataTable BonusTable
        {
            set
            {
                _BonusTable = value;
            }
        }
        public DataTable TempPaymentTable
        {
            set
            {
                _TempPaymentTable = value;
            }
        }
        public DataTable AdministrativePaymentTable
        {
            set
            {
                _AdministrativePaymentTable = value;
            }
        }
        public DataTable UtilityTable
        {
            set
            {
                _UtilityTable = value;
            }
        }
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }

        }
        public string CustomerNationality
        {
            get
            {
                return _CustomerNationality;
            }
        }
        public int ImportantPerson
        {
            set
            {
                _ImportantPerson = value;
            }
        }
        public int JobID
        {
            set
            {
                _JobID = value;
            }
        }
        public int UnitTypeID
        {
            set
            {
                _UnitTypeID = value;
            }
        }
        public int NationalityID
        {
            set
            {
                _NationalityID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
            get
            {
                return _UnitCode;
            }
        }
        public string UnitName
        {
            set
            {
                _UnitName = value;
            }
            get
            {
                return _UnitName;
            }
        }
        public string UnitSurvey
        {
            set
            {
                _UnitSurvey = value;
            }
            get
            {
                return _UnitSurvey;
            }
        }
        public double FromSurvey
        {
            set
            {
                _FromSurvey = value;
            }
        }
        public double ToSurvey
        {
            set
            {
                _ToSurvey = value;
            }
        }
        public string StopReason
        {
            set
            {
                _StopReason = value;
            }
            get { return _StopReason; }

        }
        public DateTime OpenTime
        {
           
            set
            {
                _OpenTime = value;
            }
            get { return _OpenTime; }
        }
        public bool StopedPermanently
        {
            get { return _StopedPermanently; }
            set
            {
                _StopedPermanently = value;
            }
        }
        bool _IsStopped;

        public bool IsStopped
        {
            get { return _IsStopped; }
            set { _IsStopped = value; }
        }
        public int FloorOrder
        {
            set
            {
                _FloorOrder = value;
            }
        }
       
        public bool OnlyExpiredReservation
        {
            set 
            {
                _OnlyExpiredReservation = value;
            }
        }
        public bool IsFree
        {
            set
            {
                _IsFree = value;
            }
            get
            {
                return _IsFree;
            }
        }
        public int FreeStatus
        {
            set
            {
                _FreeStatus = value;
            }
            get
            {
                return _FreeStatus;
            }
        }
        public int NewStatus
        {
            set
            {
                _NewStatus = value;
            }
            get
            {
                return _NewStatus;
            }
        }
        public double DiscountValue
        {
            get
            {
                return _DiscountValue;
            }
        }
        public double MulctPaymentValue
        {
            get
            {
                return _MulctPaymentValue;
            }
        }
        public double BonusValue
        {
            get
            {
                return _BonusValue;
            }
        }
       public double InstallmentDiscountValue
        {
            get
            {
                return _InstallmentDiscountValue;
            }
        }
        public double InstallmentPaymentValue
        {
            get
            {
                return _InstallmentPaymentValue;
            }
        }
        public double InstallmentDeservedValue
        {
            get
            {
                return _InstallmentDeservedValue;
            }
        }
        public string InstallmentStartDate
        {
            get
            {
                return _InstallmentStartDate;
            }
        }
        public string InstallmentEndDate
        {
            get
            {
                return _InstallmentEndDate;
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
                return _ResultVaue;
            }
        }
        public double ResultDiscountValue
        {
            get
            {
                return _ResultDiscountValue;
            }
        }
        public DataTable AccountTable
        {
            set
            {
                _AccountTable = value;
            }
        }
        public DataTable ContractingTransactionTable
        {
            set
            {
                _ContractingTransactionTable = value;
            }
        }
        public DataTable ReservationTransactionTable
        {
            set
            {
                _ReservationTransactionTable = value;
            }
        }
        public DataTable ContractingTransactionElementTable
        {
            set
            {
                _ContractingTransactionElementTable = value;
            }
        }
        public DataTable DeliveryTransactionTable
        {
            set
            {
                _DeliveryTransactionTable = value;
            }
        }
        public DataTable CanceledTransactionTable
        {
            set
            {
                _CanceledTransactionTable = value;
            }
        }
        public DataTable DeliveryTransactionElementTable
        {
            set
            {
                _DeliveryTransactionElementTable = value;
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
        public bool IsBranchGrouping
        {
            set
            {
                _IsBranchGrouping = value;
            }
        }
        public bool IsSalesManGrouping
        {
            set
            {
                _IsSalesManGrouping = value;
            }
        }
        public bool IsProjectGrouping
        {
            set
            {
                _IsProjectGrouping = value;
            }
        }
        public bool IsTowerGrouping
        {
            set
            {
                _IsTowerGrouping = value;
            }
        }
        public bool IsYearGrouping
        {
            set
            {
                _IsYearGrouping = value;
            }
        }
        public bool IsMonthGrouping
        {
            set
            {
                _IsMonthGrouping = value;
            }
        }
        public bool IsDayGrouping
        {
            set
            {
                _IsDayGrouping = value;
            }
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
       
        public bool IsComplete
        {
            get
            {
                return _IsComplete;
            }
        }
        int _Brand;
        public int Brand { set => _Brand = value; get => _Brand; }
        string _BrandIDs;
        public string BrandIDs
        { set => _BrandIDs = value; get => _BrandIDs; }
        bool _IsCanceled;

        public bool IsCanceled
        {
            get { return _IsCanceled; }
            set { _IsCanceled = value; }
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
        int _ProjectID;

        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        string _ProjectIDs;
        public string ProjectIDs
        { get => _ProjectIDs; set => _ProjectIDs = value; }
        string _TowerIDs;
        public string TowerIDs { set => _TowerIDs = value; get => _TowerIDs; }
        public string TowerName
        {
            get
            {
                return _TowerName;
            }
        }
        public string ModelName
        {
            get
            {
                return _ModelName;
            }
        }
        public bool TowerIsDelivered
        {
            get
            {
                return _TowerIsDelivered ;
            }
        }
        public DateTime TowerDeliveryDate
        {
            get
            {
                return _TowerDeliveryDate;
            }
        }
        public int FloorID
        {
            set
            {
                _FloorID = value;   
            }
            get
            {
                return _FloorID;
            }
        }
        public string SalesMan
        {
            get
            {
                return _SalesMan;
            }
        }
        public double DirectCancelationCost
        {
            get
            {
                return _DirectCancelationCost;
            }
        }
        #region Property Deleted Table
        public DataTable DeletedUtilityTable
        {
            set
            {
                _DeletedUtilityTable = value;
 
            }
            get
            {
                return _DeletedUtilityTable;
            }
        }
        public DataTable DeletedDiscountTable
        {
            set
            {
                _DeletedDiscountTable = value;
            }
            get
            {
                return _DeletedDiscountTable;
            }
        }
        public DataTable DeletedInstallmentTable
        {
            set
            {
                _DeletedInstallmentTable = value;

            }
            get
            {
                return _DeletedInstallmentTable;
            }
        }
        public DataTable DeletedBonusTable
        {
            set
            {
                _DeletedBonusTable = value;

            }
            get
            {
                return _DeletedBonusTable;
            }
        }
        public DataTable DeltedAttachmentTable
        {
            set
            {
                _DeletedAttachmentTable = value;

            }
            get
            {
                return _DeletedAttachmentTable;
            }
        }
       

        #endregion
        public bool EditSucceded
        {
            get
            {
                return _EditSucceded;
            }
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
        public double UtilityValue
        {
            get 
            {
                return _UtilityValue;
            }

        }
        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        public string AddStrOld
        {
            get
            {

                double dblReservationDate = _Date.ToOADate() - 2;
                double dblDeliveryDate = _DeliveryDate.ToOADate() - 2;
                int intDataIsHidden = _DataIsHidden ? 1 : 0;
                int intIsFree = _IsFree ? 1 : 0;
                int intIsNew = _IsNew ? 1 : 0;
                double dblLimitDate = _LimitDate.ToOADate() - 2;
                if (dblDeliveryDate < 0)
                    dblDeliveryDate = 0;
                double dblContractingDate = _ContractingDate.ToOADate() - 2;
                if (dblContractingDate < 0)
                    dblContractingDate = 0;
                int intProfitIsCompound = _ProfitIsCompound ? 1 : 0;
                double dblRealDeliveryDate = _RealDeliveryDate.ToOADate() - 2;
                string strRealDeliveryDate = _IsDelivered ? dblDeliveryDate.ToString() : "null";
                string Returned = "insert into CRMReservation (ReservationProfitPeriodAmount,ReservationAllowance" +
                    ",ReservationNote,ReservationContractingDate,ReservationStrategy,ReservationStatus," +
                    "ReservationDate,ReservationDeliveryDate,ReservationRealDeliveryDate,ReservationValue,UsrIns,TimIns, " +
                                " ReservationContributionValue, ReservationContributionPerc, ReservationUnitPrice,ReservationCachePrice" +
                                ", ReservationFinishing, ReservationProfitIsCompound, " +
                                " ReservationProfitValue, ReservationProfitPeriod, ReservationPeriodAmount, ReservationPeriod,ReservationLimitDate," +
                                "ReservationBranch,ReservationGLAccount,ReservationDataIsHidden,ReservationIsFree,ReservationIsNew,ReservationParent)" +
                "values(" + _ProfitPeriodAmount + "," + _Allowance + ",'" + _Note + "'," + dblContractingDate + "," + _Strategy + "," +
                _Status + "," + dblReservationDate + "," + dblDeliveryDate + "," + strRealDeliveryDate +
                "," + _Value + "," + SysData.CurrentUser.ID + ",Getdate()," +
                " " + _ContributionValue + "," + _ContributionPerc + "," + _UnitPrice + "," + _CachePrice + "," + _Finishing + "," + intProfitIsCompound + "," + _ProfitValue + "," + _ProfitPeriod + "," +
                _PeriodAmount + "," + _Period + "," + dblLimitDate + "," + _BranchID + "," + _GLAccount + "," +
                intDataIsHidden + "," + intIsFree + "," + intIsNew + "," + _Parent + ")";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {

                double dblReservationDate = _Date.ToOADate() - 2;
                double dblDeliveryDate = _DeliveryDate.ToOADate() - 2;
                int intDataIsHidden = _DataIsHidden ? 1 : 0;
                int intIsFree = _IsFree ? 1 : 0;
                int intIsNew = _IsNew ? 1 : 0;
                double dblLimitDate = _LimitDate.ToOADate() - 2;
                if (dblDeliveryDate < 0)
                    dblDeliveryDate = 0;
                double dblContractingDate = _ContractingDate.ToOADate() - 2;
                if (dblContractingDate < 0)
                    dblContractingDate = 0;
                int intProfitIsCompound = _ProfitIsCompound ? 1 : 0;
                double dblRealDeliveryDate = _RealDeliveryDate.ToOADate() - 2;
                string strRealDeliveryDate = _IsDelivered ? dblDeliveryDate.ToString() : "null";
                string strUnitID = SysUtility.GetStringArr(_UnitTable, "UnitID", 5000)[0];

                string strNotAvailableCount = "";
                strNotAvailableCount = NotAvailableUnit;
//                    @"select count(DISTINCT dbo.CRMUnit.UnitID)
//from CRMUnit  LEFT OUTER JOIN
//    dbo.CRMReservationTenancy 
//ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservationTenancy.ReservationID  
//where UnitID in(" + strUnitID + ") " +
//                        " and( " +
//                        " UnitClosedPermanent=1  " +
//                        " or ( " +
//                        "(CRMUnit.CurrentReservation <> 0 and ( dbo.CRMReservationTenancy.ReservationID is null or (dbo.CRMReservationTenancy.ReservationTenancyIsAutomaticCancelation = 1 and dbo.CRMReservationTenancy.ReservationTenancyEndDate > GetDate()) )) " +
//                        "and CRMUnit.CurrentReservation<>" + _ID + ")" +// " and CRMUnit.CurrentReservation <> " + _Parent + ") " +
//                                " or (UnitUserClosed<>0 and UnitUserClosed<>" + SysData.CurrentUser.ID + " and UnitTimeOpen>GetDate()" +
//                                " )" +
//                                ")  ";
                string Returned = "";



                Returned = " begin transaction  Trans1;";

                Returned += @"declare @CountNotAvilable int;
 declare @ID int;
  set @ID=0 ;";
                Returned += @" set @CountNotAvilable = (" + strNotAvailableCount + @");
 if @CountNotAvilable>0  goto rolLine ; ";


                Returned += "insert into CRMReservation (ReservationProfitPeriodAmount,ReservationAllowance" +
                    ",ReservationNote,ReservationContractingDate,ReservationStrategy,ReservationStatus," +
                    "ReservationDate,ReservationDeliveryDate,ReservationRealDeliveryDate,ReservationValue,ReservationBrand,UsrIns,TimIns, " +
                                " ReservationContributionValue, ReservationContributionPerc, ReservationUnitPrice,ReservationCachePrice" +
                                ", ReservationFinishing, ReservationProfitIsCompound, " +
                                " ReservationProfitValue, ReservationProfitPeriod, ReservationPeriodAmount, ReservationPeriod,ReservationLimitDate,"+
                                "ReservationBranch,ReservationGLAccount,ReservationDataIsHidden,ReservationIsFree,ReservationIsNew,ReservationParent)" +
                "values(" + _ProfitPeriodAmount + "," + _Allowance + ",'" + _Note + "'," + dblContractingDate + "," + _Strategy + "," +
                _Status + "," + dblReservationDate + "," + dblDeliveryDate + "," + strRealDeliveryDate +
                "," + _Value + "," + _Brand + "," + SysData.CurrentUser.ID + ",Getdate()," +
                " " + _ContributionValue + "," + _ContributionPerc + "," + _UnitPrice + "," + _CachePrice + "," + _Finishing + "," + intProfitIsCompound + "," + _ProfitValue + "," + _ProfitPeriod + "," + 
                _PeriodAmount + "," + _Period + ","+dblLimitDate+ "," + _BranchID + "," + _GLAccount + "," +
                intDataIsHidden +","+intIsFree+ "," +  intIsNew + "," + _Parent + ") ";
                Returned += " set @ID = (select @@IDENTITY as NewID) ";
                Returned += @" update  dbo.CRMUnit set CurrentReservation = @ID  
where UnitID in (" + strUnitID + @") ";
                Returned += @" insert into CRMReservationUnit (ReservationID, UnitID, ReservationUnitPrice, ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate, ChildReservation)  
   SELECT DISTINCT @ID as ReservationID1, UnitID, ReservationUnitPrice, ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate, ChildReservation
FROM            dbo.CRMReservationUnitTemp ";
                Returned += AddTenancyStr;
                Returned += " commitline: commit transaction Trans1;select  @ID as ReservationID,@CountNotAvilable as NotAvailableCount ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as ReservationID,@CountNotAvilable as NotAvailableCount ; ;";
                #region HashJoin
                //                Returned += @" update  dbo.CRMUnit set CurrentReservation = @ID  
                //from CRMUnit  LEFT OUTER JOIN
                //    dbo.CRMReservationTenancy 
                //ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservationTenancy.ReservationID  
                //where UnitID in(" + strUnitID + ") " +
                //                        " and( " +
                //                        " UnitClosedPermanent=0  " +
                //                        " and ( " +
                //                        "(CRMUnit.CurrentReservation = 0 or ( dbo.CRMReservationTenancy.ReservationID is not  null and dbo.CRMReservationTenancy.ReservationTenancyEndDate < GetDate() )) " +
                //                        " )" +// " and CRMUnit.CurrentReservation <> " + _Parent + ") " +
                //                                " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID + " or UnitTimeOpen<GetDate()" +
                //                                " )" +
                //                                ")  ";
                #endregion
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
               
                int intProfitIsCompound = _ProfitIsCompound ? 1 : 0;
                int intDataIsHidden = _DataIsHidden ? 1 : 0;
                int intIsFree = _IsFree ? 1 : 0;
                int intIsNew = _IsNew ? 1 : 0;
                double dblReservationDate = _Date.ToOADate() - 2;
                double dblDeliveryDate = _DeliveryDate.ToOADate() - 2;
                double dblContractingDate = _ContractingDate.ToOADate() - 2;
                double dblLimitDate = _LimitDate.ToOADate() - 2;
                double dblRealDeliveryDate = _RealDeliveryDate.ToOADate() - 2;
                string strRealDeliveryDate = _IsDelivered ? dblDeliveryDate.ToString() : "null";
                string strNotAvailableCount = NotAvailableUnit;
                string Returned = "";
                string strUnitID = SysUtility.GetStringArr(_UnitTable, "UnitID", 5000)[0];
                Returned = " begin transaction  Trans1;";

                Returned += @"declare @CountNotAvilable int;
 declare @ID int;
  set @ID="+_ID+@" ;";
                Returned += @" set @CountNotAvilable = (" + strNotAvailableCount + @");
 if @CountNotAvilable>0  goto rolLine ; ";

                string strSql = "";

                strSql += " update  CRMReservation ";
                strSql = strSql + " set  ReservationStrategy = " + _Strategy + "";
                strSql = strSql + ", ReservationStatus = " + _Status + "";
                strSql = strSql + " ,ReservationDate = " + dblReservationDate + "";
                strSql = strSql + " ,ReservationDeliveryDate = " + dblDeliveryDate + "";
                strSql = strSql + " ,ReservationRealDeliveryDate = " + strRealDeliveryDate + "";
                strSql = strSql + " ,ReservationValue = " + _Value + "";
                strSql = strSql + " ,ReservationContractingDate = " + dblContractingDate + "";
                strSql = strSql + " ,ReservationProfitPeriodAmount = " + _ProfitPeriodAmount + "";
                strSql = strSql + " ,ReservationAllowance = " + _Allowance + "";
                strSql = strSql + " ,ReservationNote = '" + _Note + "'";
                strSql = strSql + " ,ReservationContributionValue=" + _ContributionValue + "";
                strSql = strSql + " ,ReservationContributionPerc=" + _ContributionPerc + "";
                strSql = strSql + " ,ReservationUnitPrice=" + _UnitPrice + "";
                strSql = strSql + " ,ReservationCachePrice=" + _CachePrice + "";
                strSql = strSql + " ,ReservationFinishing=" + _Finishing + "";
                strSql = strSql + " ,ReservationProfitIsCompound =" + intProfitIsCompound + "";
                strSql = strSql + " ,ReservationProfitValue=" + _ProfitValue + "";
                strSql = strSql + " ,ReservationProfitPeriod=" + _ProfitPeriod + "";
                strSql = strSql + " ,ReservationPeriodAmount=" + _PeriodAmount + "";
                strSql = strSql + " ,ReservationPeriod=" + _Period + "";
                strSql = strSql + " ,ReservationLimitDate = "+dblLimitDate+"";
                strSql = strSql + " ,ReservationBranch = " + _BranchID + "";
                strSql = strSql + " ,ReservationGLAccount = " + _GLAccount + "";
                strSql = strSql + ",ReservationDataIsHidden=" + intDataIsHidden;
                strSql = strSql + ",ReservationIsFree=" + intIsFree;
                strSql = strSql + ",ReservationIsNew=" + intIsNew;
                strSql += ",ReservationParent=" + _Parent;
                strSql += ",ReservationBrand="+_Brand;
                strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
                strSql = strSql + ",TimUpd =Getdate() ";
                strSql = strSql + " where ReservationID = " + _ID;

                Returned += " " + strSql;
                Returned += @" update  dbo.CRMUnit set CurrentReservation = "+ _ID + @"  
where UnitID in (" + strUnitID + @") ";
                Returned += @" insert into CRMReservationUnit (ReservationID, UnitID, ReservationUnitPrice, ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate, ChildReservation)  
   SELECT DISTINCT @ID as ReservationID1, UnitID, ReservationUnitPrice, ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate, ChildReservation
FROM            dbo.CRMReservationUnitTemp ";
                Returned += AddTenancyStr;
                Returned += " commitline: commit transaction Trans1;select  @ID as ReservationID,@CountNotAvilable as NotAvailableCount ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as ReservationID,@CountNotAvilable as NotAvailableCount ; ;";
                return Returned;
                
            }
        }
        public string DiscountStr
        {
            get
            {
                string Returned = "SELECT    ReservationID, SUM(DiscountValue) AS DiscountValue " +
                      " FROM   dbo.CRMReservationDiscount " +
                      " GROUP BY ReservationID ";
                return Returned;
            }
        }
        public string BonusStr
        {
            get
            {
                string Returned = "SELECT     ReservationID, SUM(BonusValue) AS BonusValue "+
                       " FROM         dbo.CRMReservationBonus "+
                       " GROUP BY ReservationID ";
                return Returned;
            }
        }
        public string InstallmentPaymentStr
        {
            get
            {
                string Returned = "SELECT dbo.CRMReservationInstallment.ReservationID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL OR "+
                      " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus <> 2) "+
                      " THEN 0 ELSE GLPayment.PaymentValue END) AS TotalInstallmentPaidValue " +
                       ",SUM(CASE WHEN  (dbo.CRMReservationInstallment.InstallmentDueDate > GetDate()";
                if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    Returned += " and CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ") ";
                Returned +=") or GLPayment.PaymentValue IS NULL OR " +
                       " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus <> 2) " +
                       " or (dbo.GLPayment.PaymentReverseID > 0) or (dbo.GLPayment.PaymentSourceID > 0) " +
                       " THEN 0 ELSE GLPayment.PaymentValue END) AS DueInstallmentPaidValue " +
                       " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                       " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                       " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                       " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                       " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                      " WHERE     (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                       " GROUP BY dbo.CRMReservationInstallment.ReservationID ";
                return Returned;    
            }
        }
        public string InstallmentStr
        {
            get
            {
                double dblStart = 0;
                double dblEnd = 0;
                if (_IsDueDated)
                {
                     dblStart = SysUtility.Approximate(_DueDateStart.ToOADate() - 2, 1, ApproximateType.Down);
                     dblEnd = SysUtility.Approximate(_DueDateEnd.ToOADate() - 2, 1, ApproximateType.Up);
                    //" and InstallmentDueDate >= " + dblStart + " and  InstallmentDueDate <" + dblEnd;
                }
                string Returned = "SELECT CRMReservationInstallment.ReservationID, SUM(CRMReservationInstallment.InstallmentValue) AS TotalInstallmentValue " +
                    ",sum(case when ";
                if (_IsDueDated)
                    Returned += " InstallmentDueDate >= " + dblStart + " and  InstallmentDueDate <"+ dblEnd +" ";
                else
                Returned += " dbo.CRMReservationInstallment.InstallmentDueDate <= GetDate() ";
                if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    Returned += " and CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ") ";
                Returned += " then dbo.CRMReservationInstallment.InstallmentValue else 0 end ) as TotalDueInstallmentValue ";
                Returned += ",MIN(InstallmentDueDate) AS MinInstallmentDueDate, MAX(InstallmentDueDate) AS MaxInstallmentDueDate ";
                Returned += " FROM  CRMReservationInstallment  where (1=1) ";
                if (_IsDueDated)
                {
                 
                    Returned += " and InstallmentDueDate >= " + dblStart + " and  InstallmentDueDate <"+ dblEnd  ;
                    if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                        Returned += " and CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ") ";
                }
                  Returned +=" GROUP BY CRMReservationInstallment.ReservationID ";
                return Returned;
            }
        }
        public string TempPaymentStr
        {
            get
            {
                string Returned = "SELECT     CRMTempReservationPayment.ReservationID, SUM(GLPayment.PaymentValue) AS TempPaymentValue " +
                     " FROM  CRMTempReservationPayment INNER JOIN " +
                     " GLPayment ON CRMTempReservationPayment.PaymentID = GLPayment.PaymentID " +
                     " WHERE     (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                     " GROUP BY CRMTempReservationPayment.ReservationID";
                return Returned;
            }
        }
        public string AdministrativePaymentStr
        {
            get
            {
                string Returned = "SELECT     CRMAdministrativeCostPayment.ReservationID, SUM(GLPayment.PaymentValue) AS AdministrativePaymentValue " +
                     " FROM  CRMAdministrativeCostPayment INNER JOIN " +
                     " GLPayment ON CRMAdministrativeCostPayment.PaymentID = GLPayment.PaymentID " +
                     " WHERE     (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                     " GROUP BY CRMAdministrativeCostPayment.ReservationID";
                return Returned;
            }
        }
        public string InsurancePaymentStr
        {
            get
            {
                string Returned = "SELECT     CRMInsurancePayment.ReservationID"+
                    ", SUM(case when GLPayment.PaymentDirection = 1 then GLPayment.PaymentValue else 0 end) AS InsuranceInPaymentValue " +
                    ", SUM(case when GLPayment.PaymentDirection =0  then GLPayment.PaymentValue else 0 end) AS InsuranceOutPaymentValue " +
                     " FROM  CRMInsurancePayment INNER JOIN " +
                     " GLPayment ON CRMInsurancePayment.PaymentID = GLPayment.PaymentID " +
                     " WHERE     (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                     " GROUP BY CRMInsurancePayment.ReservationID";
                return Returned;
            }
        }
        public string UtilitySearchStr
        {
            get
            {

                string Returned = "SELECT   ReservationID  UtilityReservationID, SUM(UtilityValue) AS TotalUtilityValue, SUM(CASE WHEN scheduled = 0 THEN 0 ELSE UtilityValue END) AS TotalUtilitySchedualedValue, "+
                         " SUM(CASE WHEN scheduled = 1 THEN 0 ELSE UtilityValue END) AS TotalUtilityNonSchedualedValue "+
                         " FROM  dbo.CRMReservationUtility "+
                         " GROUP BY ReservationID ";
                return Returned;
            }
        }
        public string InstallmentDiscountStr
        {
            get
            {
                string Returned = "SELECT  dbo.CRMReservationInstallment.ReservationID, SUM(case when DiscountSourceID >0 or  DiscountReverseID >0 then 0 else  dbo.CRMReservationInstallmentDiscount.DiscountValue end) AS TotalDiscount " +
                     ",sum(case when  DiscountSourceID =0 and  DiscountReverseID =0  and dbo.CRMReservationInstallment.InstallmentDueDate <= GetDate() ";
                if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    Returned += " and CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ") ";
                     Returned +=" then dbo.CRMReservationInstallmentDiscount.DiscountValue else 0 end ) as TotalDueDiscount " +
                     " FROM  dbo.CRMReservationInstallmentDiscount inner JOIN " +
                     " dbo.CRMReservationInstallment ON  " +
                     " dbo.CRMReservationInstallmentDiscount.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                     " GROUP BY dbo.CRMReservationInstallment.ReservationID ";
                return Returned;
            }
        }
        public string UnitSearchStr
        {
            get
            {
                #region UnitCell
                string Returned = "SELECT DISTINCT " +
                    " TOP (100) PERCENT CASE WHEN COUNT(UnitFullName) = 1 THEN MAX(dbo.CRMUnit.UnitFullName) WHEN COUNT(UnitFullName)  " +
                    " = 2 THEN MAX(UnitFullName) + '&' + MIN(UnitFullName) ELSE MAX(UnitFullName) + '&..&' + MIN(UnitFullName) END AS UnitFullName, " +
                    "  CASE WHEN COUNT(UnitNameA) = 1 THEN MAX(dbo.CRMUnit.UnitNameA) WHEN COUNT(UnitNameA)  " +
                    " = 2 THEN MAX(UnitNameA) + '&' + MIN(UnitNameA) ELSE MAX(UnitNameA) + '&..&' + MIN(UnitNameA) END AS UnitNameA " +
                    ",max(CRMUnit.CurrentReservation) as CurrentUnitReservation "+
                    ", dbo.CRMReservationUnit.ReservationID AS CurrentReservation,max( CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                    " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END) AS TowerName,"+
                    "max(case when RPCell_2.CellAlterName is null or RPCell_2.CellAlterName ='' then RPCell_2.CellNameA else RPCell_2.CellAlterName end) AS ProjectName " +
                    ",sum(case when CRMUnit.UnitDeliveryDate is null then 0 else 1 end) as DeliveredCount,"+
                    "max(CRMUnit.UnitDeliveryDate) as ReservationRealDeliveryDate,max(RPCell_1.CellDeliverDate) TowerDeliveryDate " +
                    ",max(dbo.CRMUnitCell.CellID) as FloorID,max( dbo.CRMUnitModel.ModelNameA) As ModelName,max(CRMUnit.CurrentReservation) as MaxCurrentReservation  " +
                    ",CASE WHEN COUNT(UnitSurvey) = 1 THEN convert(varchar(20), MAX(dbo.CRMUnit.UnitSurvey)) WHEN COUNT(UnitSurvey)  " +
                    " = 2 THEN convert(varchar(20),MAX(UnitSurvey))  + '&' + convert(varchar(20),MIN(UnitSurvey)) ELSE convert(varchar(20),MAX(UnitSurvey)) + '&..&' + convert(varchar(20),MIN(UnitSurvey)) END AS UnitSurvey " +
                   ",max(RPCell.CellFamilyID) as ProjectID "+
                   ",max(UnitPricePerMeter) as NativeUnitPrice " +
                    " FROM  dbo.CRMUnit left outer JOIN CRMUnitModel " +
                    " on dbo.CRMUnit.UnitModel = dbo.CRMUnitModel.ModelID "+
                    " inner join "+
                    " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                    " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
                    " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                    " dbo.RPCell AS RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN " +
                    " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID ";



                #region Unit
                bool blIsUnitQuery = false;
                string strUnitQuery = "SELECT  distinct dbo.CRMReservationUnit.ReservationID "+
                      " FROM            dbo.CRMUnit INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                        " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN "+
                        " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID "+
                        " where (1=1) "; 

                if (_UnitCode != null && _UnitCode.Trim() != "")
                {
                    strUnitQuery += " and CRMUnit.UnitFullName like '" + _UnitCode.Trim() + "' ";
                    blIsUnitQuery = true;

                }
                if (_ToSurvey != 0)
                {
                    strUnitQuery += " and CRMUnit.UnitSurvey between " + _FromSurvey +
                        "  and " + _ToSurvey;
                    blIsUnitQuery = true;

                }
                if (_UnitID != 0)
                {
                    strUnitQuery += " and CRMUnit.UnitID=" + _UnitID;
                    blIsUnitQuery = true;

                }
                if (_UnitIDs != null && _UnitIDs != "")
                {
                    strUnitQuery += " and CRMUnit.UnitID in (" + _UnitIDs + ") ";
                    blIsUnitQuery = true;

                }
                if (_UnitTypeID != 0)
                {
                    strUnitQuery += " and CRMUnit.UnitType=" + _UnitTypeID;
                    blIsUnitQuery = true;
                }

                if (_CellIDs != null && _CellIDs != "")
                {
                    strUnitQuery += " and dbo.CRMUnitCell.CellID in (" + _CellIDs + ") ";
                    blIsUnitQuery = true;

                }
                if (_CellFamilyID != 0)
                {


                    if (_FloorOrder > 0)
                        strUnitQuery += " and RPCell.CellOrder=" + _FloorOrder;
                    strUnitQuery += " and RPCell.CellFamilyID = " + _CellFamilyID + "";
                    blIsUnitQuery = true;

                }
                if (blIsUnitQuery)
                    Returned += " inner join ("+ strUnitQuery +") UnitQueryTable "+
                        " on CRMReservationUnit.ReservationID = UnitQueryTable.ReservationID  ";
                //Returned += " GROUP BY RPCell_2.CellNameA, CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                //   " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END, "+
                //   "dbo.CRMReservationUnit.ReservationID,RPCell_2.CellAlterName  ";
                Returned += " GROUP BY dbo.CRMReservationUnit.ReservationID  ";
                #endregion
                #endregion
                return Returned;
            }
        }
        public string CustomerSearchStr
        {
            get
            {
                #region Customer
                string strCampaignCustomer = "SELECT    distinct    dbo.CRMCampaignCustomer.Customer "+
                 " FROM            dbo.CRMCampaignCustomer_ICampaign INNER JOIN "+
                 " dbo.CRMCampaignCustomer ON dbo.CRMCampaignCustomer_ICampaign.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID "+
                 " WHERE        (dbo.CRMCampaignCustomer_ICampaign.Campaign = "+ _CampaignID+")";
                string Returned = "SELECT dbo.CRMReservationCustomer.ReservationID,min(dbo.CRMCustomer.CustomerID) as MinCustomerID " +
                    ", CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName) " +
                      " WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName) " +
                      " ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName " +
                      ",CASE WHEN COUNT(distinct dbo.COMMONCountry.CountryNationalityA) = 1 THEN MAX(dbo.COMMONCountry.CountryNationalityA) " +
                      " WHEN COUNT(distinct dbo.COMMONCountry.CountryNationalityA) = 2 THEN MAX(dbo.COMMONCountry.CountryNationalityA) + '&' + MIN(dbo.COMMONCountry.CountryNationalityA) " +
                      " ELSE MAX( dbo.COMMONCountry.CountryNationalityA) + '&..&' + MIN( dbo.COMMONCountry.CountryNationalityA) END AS CustomerNationality " +
                      " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                      " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID " +
                      " left outer JOIN  dbo.COMMONCountry " +
                      " ON dbo.CRMCustomer.CustomerNationality = dbo.COMMONCountry.CountryID ";
                if (_CampaignID != 0)
                    Returned += " inner join ("+strCampaignCustomer+") as CampaignTable "+
                        " on CRMCustomer.CustomerID = CampaignTable.Customer ";
                string strReservatioCustomer = " SELECT  distinct dbo.CRMReservationCustomer.ReservationID "+
                      " FROM     dbo.CRMReservationCustomer INNER JOIN "+
                      " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID where (1=1) ";
                #region Customer
                if ((_CustomerName != null && _CustomerName != "") ||
                    _JobID != 0 || _NationalityID != 0 || _ImportantPerson != 0
                    || _CustomerID != 0 || (_CustomerIDs != null && _CustomerIDs != "") || _UseCustomer)
                {
                   
                    if (_CustomerName != null && _CustomerName != "")
                    {
                        strReservatioCustomer += " and dbo.ReplaceStringComp(CRMCustomer.CustomerFullName) like '%" +
                            SysUtility.ReplaceStringComp(_CustomerName) + "%' ";

                    }
                    if (_NationalityID != 0)
                    {
                        strReservatioCustomer += " and CRMCustomer.CountryID=" + _NationalityID;
                    }
                    if (_JobID != 0)
                        strReservatioCustomer += " and CRMCustomer.JobID = " + _JobID;
                    if (_ImportantPerson != 0)
                    {
                        int intVIP = _ImportantPerson == 1 ? 0 : 1;
                        strReservatioCustomer += " and CRMCustomer.CustomerVIP=" + intVIP;
                    }
                    if (_UseCustomer ||
                        (_CustomerIDs != null && _CustomerIDs != "") || _CustomerID != 0)
                    {

                        if (_CustomerIDs != null && _CustomerIDs != "")
                            strReservatioCustomer += " and CRMCustomer.CustomerID in (" + _CustomerIDs + ")";

                        if (_CustomerID != 0)
                            strReservatioCustomer += " and CRMCustomer.CustomerID = " + _CustomerID + " ";
                    }
                    //strSql = strSql + strCustomerWhere + ")";
                    
                    Returned += " inner join(" + strReservatioCustomer + ") as ReservationCustomerTable  " +
                        " on dbo.CRMReservationCustomer.ReservationID = ReservationCustomerTable.ReservationID  ";
                }

                Returned += " GROUP BY dbo.CRMReservationCustomer.ReservationID ";
                #endregion
                #endregion
                return Returned;
            }
        }
        public string SalesSearchStr
        {
            get
            {
                string Returned = "SELECT  ReservationID, MAX(WorkerID) AS MaxSalesID, MIN(WorkerID) AS MinSalesID "+
                      " FROM         dbo.CRMReservationWorkerContribution "+
                      " GROUP BY ReservationID ";
                Returned = "select ReservationID," +
                    "case when MaxSalesID=MinSalesID then MaxTable.ApplicantFirstName else MaxTable.ApplicantFirstName +'-'+ MinTable.ApplicantFirstName end as SalesManName " +
                    " from ("+ Returned +") as NativeTable "+
                    " inner join dbo.HRApplicant as MaxTable "+
                    " on NativeTable.MaxSalesID = MaxTable.ApplicantID "+
                    " inner join dbo.HRApplicant as MinTable "+
                    " on NativeTable.MinSalesID = MinTable.ApplicantID ";
                return Returned;
            }
        }
        public string MulctPaymentStr
        {
            get 
            {
                string Returned = "SELECT   dbo.CRMReservationMulctPayment.PaymentReservation"+
                    ", SUM(case when (dbo.GLPayment.PaymentReverseID = 0) and (dbo.GLPayment.PaymentSourceID = 0)then dbo.GLPayment.PaymentValue else 0 end ) AS TotalMulctPaymentValue " +
                       " FROM         dbo.CRMReservationMulctPayment INNER JOIN "+
                        " dbo.GLPayment ON dbo.CRMReservationMulctPayment.PaymentID = dbo.GLPayment.PaymentID "+
                       " WHERE     (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                        " GROUP BY dbo.CRMReservationMulctPayment.PaymentReservation ";
                return Returned;
            }
        }
       
        public  string SearchStr
        {
            get
            {
                //CRMReservation.
                string strTransaction = "SELECT  CRMReservationStatusTransaction_1.ReservationID AS TransactionReservationID"+
                    ", CRMReservationStatusTransaction_1.ReservationTransactionType,  "+
                     " CRMReservationStatusTransaction_1.ReservationTransactionValue"+
                     ", CRMReservationStatusTransaction_1.ReservationStatusGLTransaction "+
                     " FROM         (SELECT     ReservationID, MAX(StatusTransactionID) AS MaxStatusID "+
                     " FROM         dbo.CRMReservationStatusTransaction "+
                     " GROUP BY ReservationID) AS MaxTable INNER JOIN "+
                     " dbo.CRMReservationStatusTransaction AS CRMReservationStatusTransaction_1 ON  "+
                     " MaxTable.MaxStatusID = CRMReservationStatusTransaction_1.StatusTransactionID AND  "+
                      " MaxTable.ReservationID = CRMReservationStatusTransaction_1.ReservationID ";
                string strDiscountSum = DiscountStr;
                string strBonusSum = BonusStr;
              
                string strInstallment = InstallmentStr;
               
                string strTempPayment = TempPaymentStr;
                string strAdministrativePayment = AdministrativePaymentStr;
                string strInstallmentDiscount = InstallmentDiscountStr;
                string strSalesMan = SalesSearchStr;
                ReservationResubmissionDb objResubmission = new ReservationResubmissionDb();
                objResubmission.ResubmissionStatus = 1;
                objResubmission.ResubmissionTypeIDs = _ResubmissionIDs;
                objResubmission.ResubmissionStartDateRange = _ResubmissionDateRange;
                objResubmission.ResubmissionDateStart = _ResubmissionStartDate;
                objResubmission.ResubmissionDateEnd = _ResubmissionEndDate;
                objResubmission.Serial = _ResubmissionSerial;
                //string strResubmission = 
                /*
                 * here is the only place containging all reservations
                 */
                string strReservationValue = "select CRMReservation.ReservationID," +
                    "case when InstallmentTable.TotalInstallmentValue is null then 0 else InstallmentTable.TotalInstallmentValue end +" +
                   " case when TempPaymentTable.TempPaymentValue is null then 0 else TempPaymentTable.TempPaymentValue end " +
                   " -  case when InstallmentDiscountTable.TotalDiscount is null then 0 else InstallmentDiscountTable.TotalDiscount end " +
                   " as ReservationValue"+
                   ",InstallmentTable.MaxInstallmentDueDate,InstallmentTable.MinInstallmentDueDate " +
                   ",case when InstallmentTable.TotalInstallmentValue is null then 0 else InstallmentTable.TotalInstallmentValue end as TotalInstallmentValue " +
                   ",case when InstallmentTable.TotalDueInstallmentValue is null then 0 else InstallmentTable.TotalDueInstallmentValue end +" +
                   " -  case when InstallmentDiscountTable.TotalDueDiscount is null then 0 else InstallmentDiscountTable.TotalDueDiscount end " +
                   " as DueInstallemntValue " +
                   ",case when InstallmentDiscountTable.TotalDiscount  is null  then 0 else InstallmentDiscountTable.TotalDiscount end as InstallmentDiscountValue " +
                   ",case when TempPaymentTable.TempPaymentValue is null then 0 else TempPaymentTable.TempPaymentValue end as TempPaymentValue " +
                   " ,  case when AdministrativePaymentTable.AdministrativePaymentValue is null then 0 else AdministrativePaymentTable.AdministrativePaymentValue end as AdministrativePaymentValue " +
                    //",InstallmentTable.MaxInstallmentDueDate,InstallmentTable.MinInstallmentDueDate " +
                   " from CRMReservation ";
                if (_IsDueDated)
                    strReservationValue += " inner join ";
                else
                    strReservationValue += " left outer join ";
                 strReservationValue+=  " (" + strInstallment + ") as InstallmentTable on CRMReservation.ReservationID = InstallmentTable.ReservationID " +
                   " left outer join (" + strInstallmentDiscount +
                   ") as InstallmentDiscountTable on InstallmentTable.ReservationID = InstallmentDiscountTable.ReservationID " +
                   " left outer join ( " + strTempPayment + ") as TempPaymentTable on  CRMReservation.ReservationID = TempPaymentTable.ReservationID "+
                   " left outer join ("+ strAdministrativePayment +") as AdministrativePaymentTable "+
                   " on CRMReservation.ReservationID = AdministrativePaymentTable.ReservationID";
              
                
                string strCancelation = "SELECT ReservationID AS DirectCancelationReservation"+
                    ", CancelationCost AS DirectCancelationCost "+
                     " FROM         dbo.CRMReservationCancelation";


                string strInstallmentPaidValue = "";
                AccountDb objAccountDb = new AccountDb();
                strInstallmentPaidValue = InstallmentPaymentStr;
                string strStatusDate = "case when ReservationStatus=6 and  CanceledReservation is not null then "+
                    " (case when ReservationDelegationDate is not null and PayBackComplete=0 then ReservationDelegationDate "+
                   " when  PayBackComplete = 1 then PayBackCompleteDate " +
                    " else   CancelationDate end ) " +
                    " when (ReservationStatus = 4 or ReservationStatus = 3) then  ReservationContractingDate  "+
                    " else ReservationDate end as ReservationStatusDate ";
                #region Manipulate Cession Data
                string strCessionDate = "SELECT OldReservationID CessionedReservationID, NewReservationID NewReservation, CessionCost  OldCessionCost, "+
                    "CessionPreviousPaidValue, CessionDate "+
                      " FROM         CRMReservationCession ";
                ReservationDb objReservationDb = new ReservationDb();
                //objReservationDb.CustomerSearchStr;
                string strOldReservation = "SELECT  NewReservationID AS OldCessionNewReservationID, OldReservationID AS OldCessionMainReservationID"+
                    ", CessionDate AS OldCessionDate,OldCessionCustomerTable.CustomerFullName as NewCustomerFullName"+
                    ",OldCessionUnitTable.UnitFullName as NewUnitFullName "+
                      " FROM  dbo.CRMReservationCession "+
                      " inner join ("+ objReservationDb.CustomerSearchStr +") as OldCessionCustomerTable "+
                      " on  dbo.CRMReservationCession.NewReservationID = OldCessionCustomerTable.ReservationID  " +
                      " inner join ("+ objReservationDb.UnitSearchStr +") as OldCessionUnitTable "+
                      " on dbo.CRMReservationCession.NewReservationID = OldCessionUnitTable.CurrentReservation ";
                
                string strNewReservation = "SELECT  NewReservationID AS NewCessionMainReservationID, OldReservationID AS NewCessionOldReservationID, CessionCost AS NewCessionCost, "+
                      " CessionPreviousPaidValue AS NewCessionPreviousPaidValue, CessionDate AS NewCessionDate "+
                      ",NewCessionCustomerTable.CustomerFullName as OldCustomerFullName,NewCessionUnitTable.UnitFullName as OldUnitFullName "+
                      " FROM  dbo.CRMReservationCession "+
                      " inner join ("+ objReservationDb.CustomerSearchStr +") as NewCessionCustomerTable "+
                      " on  dbo.CRMReservationCession.NewReservationID = NewCessionCustomerTable.ReservationID  "+
                      " inner join (" + objReservationDb.UnitSearchStr + ") NewCessionUnitTable "+
                      " on dbo.CRMReservationCession.NewReservationID = NewCessionUnitTable.CurrentReservation  ";
                #endregion
                //ReservationValueTable.ReservationValue-InstallmentPaymentTable.TotalInstallmentPaidValue-ReservationValueTable.TempPaymentValue
                #region Reservation Linear Data
                #region UnitCell
                string strUnitCell = UnitSearchStr;
                #endregion
                //" ORDER BY CurrentReservation DESC ";
                #region Customer
                string strReservationCustomer = CustomerSearchStr;
                #endregion
                #endregion
                string strDelegatedReservation = "SELECT  dbo.CRMReservation.ReservationID, SUM(CASE WHEN CRMUnit.CurrentReservation <> 0 AND "+
                      " CRMReservation.ReservationID <> CurrentReservation THEN 1 ELSE 0 END) AS ReservedAgain "+
                      " FROM  dbo.CRMReservation INNER JOIN "+
                      " dbo.CRMReservationUnit ON dbo.CRMReservation.ReservationID = dbo.CRMReservationUnit.ReservationID INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnit.UnitID "+
                      " WHERE (dbo.CRMReservation.ReservationDelegationDate IS NOT NULL) "+
                      " GROUP BY dbo.CRMReservation.ReservationID ";


                string strUnitTower = @"SELECT DISTINCT dbo.CRMReservationUnit.ReservationID
FROM            dbo.CRMProject INNER JOIN
                         dbo.CRMTower ON dbo.CRMProject.ProjectID = dbo.CRMTower.TowerProject INNER JOIN
                         dbo.CRMReservationUnit INNER JOIN
                         dbo.CRMUnit ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnit.UnitID ON dbo.CRMTower.TowerID = dbo.CRMUnit.UnitTower
WHERE   (1=1)  ";
                if (_TowerIDs != null && _TowerIDs != "")
                    strUnitTower += "  and  (dbo.CRMTower.TowerID IN (" + _TowerIDs + ")) ";
                if(_ProjectIDs!= null && _ProjectIDs!= "")
                strUnitTower +=" AND (dbo.CRMProject.ProjectID IN ("+ _ProjectIDs +"))";

                string Returned = " SELECT CRMReservation.ReservationID, CRMReservation.UsrIns,CRMReservation.TimIns," +
                    "case when CancelationTable.CanceledReservation is null then  CRMReservation.UsrUpd else" +
                    " case when PayBackComplete=1 then PayBackCompleteUsr else  CancelationTable.CancelationUsr end " +
                    " end as UsrUpd " +
                    ",case when CancelationTable.CanceledReservation is null then  CRMReservation.TimUpd " +
                    " else  " +
                    " case when PayBackComplete =1 then PayBackCompleteDate else  CancelationTable.CancelationDate end " +
                    " end TimUpd,ReservationContributionValue,ReservationIsFree,ReservationIsNew," +
                                  "ReservationProfitPeriodAmount,ReservationAllowance,ReservationNote,ReservationContractingDate" +
                                  ", ReservationContributionPerc, ReservationUnitPrice,ReservationCachePrice, ReservationFinishing, ReservationProfitIsCompound, " +
                                  " ReservationProfitValue, ReservationProfitPeriod, ReservationPeriodAmount, ReservationPeriod,ReservationLimitDate,ReservationBranch," +
                                  "ReservationStatus," + strStatusDate + ",ReservationStrategy,ReservationDate,UnitTable.ReservationRealDeliveryDate,ReservationDeliveryDate,ReservationValueTable.ReservationValue" +
                                  ",(ReservationValueTable.ReservationValue-" +
                            "case when InstallmentPaymentTable.TotalInstallmentPaidValue is null  then 0 else InstallmentPaymentTable.TotalInstallmentPaidValue end " +
                            "-ReservationValueTable.TempPaymentValue) as RemainingValue " +
                            ",ReservationValueTable.TotalInstallmentValue " +
                                  ",ReservationValueTable.TempPaymentValue,ReservationValueTable.AdministrativePaymentValue,ReservationGLAccount,ReservationGLLeafAccount" +
                                  ",CRMReservation.ReservationDataIsHidden,ReservationParent,dbo.CRMReservation.ReservationDelegationDate," +
                                  "dbo.CRMReservation.ReservationGLContractingTransaction, dbo.CRMReservation.ReservationGLDeliveryTransaction, " +
                                  " dbo.CRMReservation.ReservationGLCancelationTransaction " +
                                  ", ReservationOpenTime, ReservationStopedPermanently, ReservationStopReason" +
                                  ",BranchTable.*  " +
                                  ",case when DiscountTable.DiscountValue is null then 0 else DiscountTable.DiscountValue end as DiscountValue " +
                    // ",CancelationTable.CancelationDate,CancelationTable.CanceledReservation "+
                                  ",case when InstallmentPaymentTable.TotalInstallmentPaidValue is null then 0 else InstallmentPaymentTable.TotalInstallmentPaidValue end as TotalInstallmentPaidValue " +
                                  ",case when ReservationValueTable.DueInstallemntValue is null then 0 else ReservationValueTable.DueInstallemntValue end as DueInstallemntValue" +
                                  ",case when InstallmentPaymentTable.DueInstallmentPaidValue is null then 0 else InstallmentPaymentTable.DueInstallmentPaidValue end DueInstallmentPaidValue " +
                                  ",CancelationTable.*,SoldDelegatedTable.ReservedAgain " +
                                  ",CustomerTable.CustomerFullName as CustomerFullNameMultiple,CustomerTable.CustomerNationality,UnitTable.FloorID,UnitTable.UnitFullName,UnitTable.UnitNameA,UnitTable.TowerName" +
                                  ",UnitTable.TowerDeliveryDate,UnitTable.ProjectName,UnitTable.ModelName,UnitTable.MaxCurrentReservation" +
                                  ",UnitTable.CurrentReservation,UnitTable.UnitSurvey,UnitTable.ProjectID   " +
                                  ",UnitTable.NativeUnitPrice "+
                                  ",SalesManTable.SalesManName " +
                                  ",AccountTable.*,OldCessionTable.*,NewCessionTable.* ,BonusTable.BonusValue" +
                                  ",ReservationValueTable.InstallmentDiscountValue,MulctPaymentTable.TotalMulctPaymentValue " +//"InstallmentPaymentTable.TotalInstallmentPaidValue  " +
                                 ",ReservationValueTable.MaxInstallmentDueDate,ReservationValueTable.MinInstallmentDueDate " +
                                 ",TransactionTable.*,DirectCancelationTable.DirectCancelationCost " +
                                ",InsurancePaymentTable.InsuranceInPaymentValue,InsurancePaymentTable.InsuranceOutPaymentValue " +
                                ",MinCustomerTable.* " +
                                ",UtilityTable.*,BrandTable.* ";

                List<int> arrTenancyStatus = new List<int>() { 0,1,2,3,4,7};
                if (arrTenancyStatus.Contains(_TenancyStatus))
                    Returned += ",TenancyTable.* ";
                                //",OrderTable.ReservationOrder ";
                if (_ResubmissionIDs != null && _ResubmissionIDs!= "") 
                    Returned += ",ResubmissionTable.* ";
                Returned += "  from CRMReservation " +
                     " inner join (" + strUnitCell + ") as UnitTable " +
                     " on CRMReservation.ReservationID= UnitTable.CurrentReservation " +
                     " inner join (" + strReservationCustomer + ") as CustomerTable " +
                     " on CRMReservation.ReservationID = CustomerTable.ReservationID " +
                     "  left outer join (" + BranchDb.SearchStr + ") as BranchTable " +
                     " on CRMReservation.ReservationBranch = BranchTable.BranchID " +
                    //" left outer join (" + ReservationCessioinDb.SearchStr + ") as CessionTable " +
                    //" on CRMReservation.ReservationID = CessionTable.NewReservationID  " +
                     " left outer join (" + objAccountDb.SearchStr + ") as AccountTable on " +
                     " CRMReservation.ReservationGLLeafAccount = AccountTable.AccountID  " +
                     " left outer join (" + strDiscountSum + ") as DiscountTable on CRMReservation.ReservationID = DiscountTable.ReservationID " +
                     " left outer join (" + strBonusSum + ") as BonusTable " +
                     "  on CRMReservation.ReservationID = BonusTable.ReservationID  " +
                     " left outer join (" + ReservationCancelationDb.SearchStr + ") as CancelationTable on CRMReservation.ReservationID = CancelationTable.CanceledReservation ";
                if ((_TowerIDs != null && _TowerIDs != "") || (_ProjectIDs != null && _ProjectIDs != ""))
                    Returned += " inner join ("+strUnitTower+") as TowerTable "+
                        " on CRMReservation.ReservationID = TowerTable.ReservationID ";
                if (_TenancyStatus == 0 || _TenancyStatus==2)
                {
                    Returned += " left outer join (" + SearchTenancyStr + ") as TenancyTable "+
                        " on CRMReservation.ReservationID = TenancyTable.ReservationTenancyID ";
                }
                else if (_TenancyStatus == 1 ||
                    _TenancyStatus == 3 || _TenancyStatus == 4)
                {
                    Returned += "  inner join (" + SearchTenancyStr + ") as TenancyTable " +
                        " on CRMReservation.ReservationID = TenancyTable.ReservationTenancyID ";
                }
                    if (_IsDueDated )
                   Returned += " inner join ";
               else
                   Returned += " left outer join ";
                Returned +=" (" + strReservationValue + ") as ReservationValueTable on CRMReservation.ReservationID = ReservationValueTable.ReservationID  " +
                  " left outer join (" + strInstallmentPaidValue + ") as InstallmentPaymentTable " +
                  " on CRMReservation.ReservationID = InstallmentPaymentTable.ReservationID " +
                  " left outer join (" + strDelegatedReservation + ") as SoldDelegatedTable " +
                  " on CRMReservation.ReservationID = SoldDelegatedTable.ReservationID  " +
                  " left outer join (" + strOldReservation + ") as OldCessionTable " +
                  " on CRMReservation.ReservationID =  OldCessionTable.OldCessionMainReservationID " +
                  " left outer join (" + strNewReservation + ") as NewCessionTable " +
                  " on CRMReservation.ReservationID =  NewCessionTable.NewCessionMainReservationID " +
                  " left outer join (" + strSalesMan + ") as SalesManTable " +
                  " on CRMReservation.ReservationID = SalesManTable.ReservationID " +
                  " left outer join (" + MulctPaymentStr + ") as MulctPaymentTable " +
                  " on CRMReservation.ReservationID = MulctPaymentTable.PaymentReservation " +
                  " left outer join (" + strTransaction + ") as TransactionTable " +
                  " on  CRMReservation.ReservationID = TransactionTable.TransactionReservationID " +
                  " left outer join (" + strCancelation + ") as DirectCancelationTable " +
                  " on CRMReservation.ReservationID = DirectCancelationTable.DirectCancelationReservation " +
                  " left outer join (" + InsurancePaymentStr + ") as InsurancePaymentTable " +
                  " on CRMReservation.ReservationID = InsurancePaymentTable.ReservationID " +
                  " left outer join (" + new CustomerDb().SearchStr + ") as MinCustomerTable " +
                  " on CustomerTable.MinCustomerID = MinCustomerTable.CustomerID " +
                  " left outer join (" + UtilitySearchStr + ") as UtilityTable " +
                  " on CRMReservation.ReservationID = UtilityTable.UtilityReservationID  "+
                  " left outer join ("+ BrandDb.SearchStr +") as BrandTable "+
                  " on CRMReservation.ReservationBrand = BrandTable.BrandID ";
                                  //" inner join  TEMPSapContractNotPosted  as OrderTable "+
                                  //" on CRMReservation.ReservationID = OrderTable.ReservationID ";
                if ((_ResubmissionIDs != null && _ResubmissionIDs != "") || (_ResubmissionSerial != null && _ResubmissionSerial != ""))
                {
                    string strMaxResubmission = "select ";
                    Returned += " inner join (" + objResubmission.StrSearch + ") as ResubmissionTable " +
                        " on CRMReservation.ReservationID = ResubmissionTable.ResubmissionReservation ";
                }
                 

                #region StrSearch
                Returned = "select * from ("+ Returned +") as NativeReservationTable where(1=1) ";
                #region Main Search Data
                if (_ID != 0)
                    Returned = Returned + " and NativeReservationTable.ReservationID = " + _ID.ToString();

                if (_Note != null && _Note != "")
                    Returned = Returned + " and ReservationNote like '%" + _Note + "%'";
                if (_ReservationDateRange || _ContractingDateRange)
                {
                    string strSearchDate = "";
                    if (_ReservationDateRange)
                    {
                        double dblStart = _ReservationStartDate.ToOADate() - 2;
                        dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                        double dblEnd = _ReservationEndDate.ToOADate() - 2;

                        dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);



                        strSearchDate = "  (ReservationDate >= " + dblStart + " and ReservationDate <" + dblEnd + ") ";

                    }
                    if (_ContractingDateRange)
                    {

                        double dblStart = _ContractingStartDate.ToOADate() - 2;
                        dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                        double dblEnd = _ContractingEndDate.ToOADate() - 2;
                        dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                        if (strSearchDate != "")
                            strSearchDate += " or ";
                        strSearchDate += "(ReservationContractingDate >=" + dblStart +
                            " and ReservationContractingDate < " + dblEnd + ") ";

                    }
                    if (strSearchDate != "")
                        Returned += " and ( " + strSearchDate + ")";
                }

                if (_FreeStatus != 0)
                {
                    if (_FreeStatus == 1)
                        Returned = Returned + " and ReservationIsFree = 0 ";
                    if (_FreeStatus == 2)
                        Returned = Returned + " and ReservationIsFree = 1";
                }
                if (_NewStatus != 0)
                {
                    if (_NewStatus == 1)
                        Returned = Returned + " and ReservationIsNew = 0 ";
                    if (_NewStatus == 2)
                        Returned = Returned + " and ReservationIsNew = 1";
                }
                if (_BranchID != 0)
                {
                    Returned = Returned + " and  BranchID = " + _BranchID + "";
                }
                if (_BranchIDs != null && _BranchIDs!="")
                {
                    Returned = Returned + " and  BranchID in (" + _BranchIDs + ")";
                }

                if (_SalesManID != 0)
                {
                    Returned = Returned + " and NativeReservationTable.ReservationID in (SELECT     ReservationID  FROM         CRMReservationWorkerContribution Where WorkerID = " + _SalesManID + ") ";
                }
                if (_SalesMenIDs != null && _SalesMenIDs != "" && _SalesMenIDs!="0")
                {
                    Returned = Returned + " and NativeReservationTable.ReservationID in (SELECT     ReservationID  FROM         CRMReservationWorkerContribution Where WorkerID in (" + _SalesMenIDs + ")) ";
                }
                if (_TenancyStatus == 2)
                {
                    Returned += " and (NativeReservationTable.ReservationTenancyID is null ) ";
                }
                if (_TenancyStatus == 3)
                {
                    Returned += " and (NativeReservationTable.ReservationTenancyEndDate < GetDate() ) ";
                }
                if (_TenancyStatus == 4)
                {
                    Returned += " and (NativeReservationTable.ReservationTenancyEndDate > GetDate() ) ";
                }
                if (_ActiveReservationIDs != null && _ActiveReservationIDs != "")
                {
                    Returned = Returned + " and NativeReservationTable.ReservationID in (" + _ActiveReservationIDs + ")";
                }
                if (_IDs != null && _IDs != "")
                {
                    Returned = Returned + " and NativeReservationTable.ReservationID in (" + _IDs + ")";
                }
                if (_StatusStr != null && _StatusStr != "" && _StatusStr != "0")
                {
                    bool blHasContract = false, blHasComplete = false;
                    if (SysUtility.GetStringIndex(_StatusStr, "3", ',') != -1)
                    {
                        _StatusStr = SysUtility.RemoveSubString(_StatusStr, "3", ',');
                        blHasContract = true;
                    }
                    if (SysUtility.GetStringIndex(_StatusStr, "4", ',') != -1)
                    {
                        _StatusStr = SysUtility.RemoveSubString(_StatusStr, "4", ',');
                        blHasComplete = true;
                    }
                    if (_StatusStr != "")
                        Returned = Returned + " and (ReservationStatus in(" + _StatusStr + ")";
                    if (blHasComplete || blHasContract)
                    {
                        if (_StatusStr != "")
                            Returned += " or ";
                        else
                            Returned += " and ";
                        Returned += " ReservationStatus in (3,4) ";
                    }
                    if (_StatusStr != "")
                        Returned += ")";
                    //ReservationValueTable.ReservationValue-InstallmentPaymentTable.TotalInstallmentPaidValue-ReservationValueTable.TempPaymentValue
                    if (blHasComplete && !blHasContract)
                        Returned += " and ((NativeReservationTable.ReservationValue-" +
                            "case when NativeReservationTable.TotalInstallmentPaidValue is null  then 0 else NativeReservationTable.TotalInstallmentPaidValue end " +
                            "-NativeReservationTable.TempPaymentValue) <= 10)";
                    if (blHasContract && !blHasComplete)
                        Returned += " and ((NativeReservationTable.ReservationValue-" +
                            "case when NativeReservationTable.TotalInstallmentPaidValue is null then 0 else NativeReservationTable.TotalInstallmentPaidValue end " +
                            "-NativeReservationTable.TempPaymentValue) >= 10)";

                }
                if (_DealStatus == 1)//Not Stoped
                {
                    Returned += " and( (ReservationOpenTime is null or ReservationOpenTime < GetDate())  and ReservationStopedPermanently=0) ";

                }
                if (_DealStatus == 2)// Stoped
                {
                    Returned += " and ((ReservationOpenTime > GetDate())  or ReservationStopedPermanently=1 )";

                }
                if (_HasInstallmentStatus == 1)
                {
                    //Returned += "  and TotalInstallmentValue > 0 ";
                    Returned += " and NativeReservationTable.ReservationValue >0 ";
                }
                if (_CancelationType != 0)
                    Returned += " and CancelationTypeID="+_CancelationType;
                if (_PaybackCompleteStatus == 1)
                    Returned += " and PayBackComplete = 1 ";
                else if (_PaybackCompleteStatus == 2)
                    Returned += " and PayBackComplete = 0 ";
                #region StatusDate Range
                if (_StatusDateRange)
                {
                    double dblStartStatusDate = SysUtility.Approximate(_StatusStartDate.ToOADate() - 2, 1, ApproximateType.Down);

                    double dblEndStatusDate = SysUtility.Approximate(_StatusEndDate.ToOADate() - 2, 1, ApproximateType.Up);

                    string strStatusWhere = "(ReservationStatus=6 and  CanceledReservation is not null and  CancelationDate>= " +
                        dblStartStatusDate + " and CancelationDate<" + dblEndStatusDate + ") or " +
                       " ((ReservationStatus = 4 or ReservationStatus = 3) and  ReservationContractingDate>= " +
                       dblStartStatusDate + " and ReservationContractingDate<" + dblEndStatusDate + ") or " +
                       "((ReservationStatus = 1 or ReservationStatus = 2) and   ReservationDate>= " + dblStartStatusDate +
                       " and ReservationDate < " + dblEndStatusDate + ")";
                   // Returned += " and (" + strStatusWhere + ")";
                    Returned += "  and ReservationStatusDate >=" + dblStartStatusDate + " and ReservationStatusDate < " + dblEndStatusDate ;
                }
                #endregion



                #region GL
              
                if (_ContractingTransactionStatus == 1)
                    Returned += " and  ReservationGLContractingTransaction=0 ";
                else if (_ContractingTransactionStatus == 2)
                    Returned += " and  ReservationGLContractingTransaction<>0 ";
                if (_DeliveryTransactionStatus == 1)
                    Returned += " and  DeliveredCount>0 and  ReservationGLDeliveryTransaction=0 ";
                else if (_DeliveryTransactionStatus == 2)
                    Returned += " and    ReservationGLDeliveryTransaction<>0 ";
                #endregion
                #endregion
                #region using External Properties In Search


                if (_OnlyExpiredReservation)
                {
                    Returned += " and  (ReservationStatus = 1  and  ReservationLimitDate<GetDate() )";
                }
                if (_AttachmentStatus != 0)
                {
                    if (_AttachmentStatus == 1)
                    {
                        Returned += " and NativeReservationTable.ReservationID not in (SELECT  ReservationID FROM CRMReservationAttachment)";
                    }
                    else if (_AttachmentStatus == 2)
                    {
                        Returned += " and NativeReservationTable.ReservationID in (SELECT  ReservationID FROM CRMReservationAttachment)";
                    }
                }
                if (_Parent != 0)
                {
                    Returned += " and NativeReservationTable.ReservationParent=" + _Parent;
                }
                if (_ParentStatus != 0)
                {
                    if (_ParentStatus == 1)
                        Returned += " and NativeReservationTable.Reservationparent =0 ";
                    else
                        Returned += " and NativeReservationTable.ReservationParent <>0 ";

                }
                if (_DelegateStatus != 0)
                {
                    if (_DelegateStatus == 1)
                        Returned += " and NativeReservationTable.ReservationDelegationDate is not null ";
                    if (_DelegateStatus == 2)
                        Returned += " and NativeReservationTable.ReservationDelegationDate is null ";

                }
                if (_SoldStatus == 1)
                    Returned += " and (MaxCurrentReservation >0 and ReservationID <>MaxCurrentReservation) ";
                else if (_SoldStatus == 2)
                    Returned += " and (MaxCurrentReservation =0) ";
                    // Returned += " and NativeReservationTable.ReservedAgain =0 ";
                if (_IsReservedStatus == 1)
                {
                    Returned += @" and (NativeReservationTable.MaxCurrentReservation= NativeReservationTable.CurrentReservation
or (ReservationTenancyID is not null and ReservationStatus <> 6 and ReservationTenancyEndDate < GetDate())) ";

                }
                if (_IsReservedStatus == 2)
                {
                    Returned += " and NativeReservationTable.MaxCurrentReservation<> NativeReservationTable.CurrentReservation ";

                }
                #endregion
                #region Financial Value
                if (_EndReservationValue > 0 && _EndReservationValue >= _StartReservationValue)
                {
                    Returned += " and ReservationValue >= " + _StartReservationValue +
                        " and ReservationValue <= "+ _EndReservationValue;

 
                }
                if (_EndDueValue > 0 && _EndDueValue >= _StartDueValue)
                {
                    Returned += " and DueInstallemntValue - DueInstallmentPaidValue >= " + _StartDueValue +
                        " and DueInstallemntValue - DueInstallmentPaidValue <= "+ _EndDueValue;
                }
                if (_EndPaidValue > 0 && _EndPaidValue >= _StartPaidValue)
                {
                    Returned += " and TotalInstallmentPaidValue + TempPaymentValue >= " + _StartPaidValue +
                        " and TotalInstallmentPaidValue + TempPaymentValue <= " + _EndPaidValue;
                }
        #endregion
        #endregion
                //DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(Returned);
                return Returned;
            }
        }
        public string SearchSumStr
        {
            get
            {
                string Returned = "";
                string strSelect = "count(ReservationID) as TotalCount,sum(TempPaymentValue) as TotalTempPayment,sum(ReservationValue) as TotalValue "+
                    ",sum(TotalInstallmentValue) as TotalInstallmentValue,sum(TotalInstallmentPaidValue) as TotalInstallmentPaymentSum"+
                    ",sum(ReservationValue) as WholeTotalValue ";
                string strGroup = "";
                string strOrder = "";
                if (_IsBranchGrouping)
                {
                    strSelect += ",BranchID,BranchNameA ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "BranchID,BranchNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "BranchID,BranchNameA";
                }

               
                if (_IsDayGrouping)
                {
                    strSelect += ",year(ReservationStatusDate) as Y,Month(ReservationStatusDate) as M,Day(ReservationStatusDate) as D ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(ReservationStatusDate),Month(ReservationStatusDate),Day(ReservationStatusDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(ReservationStatusDate),Month(ReservationStatusDate),Day(ReservationStatusDate) ";
                }
                else if (_IsMonthGrouping)
                {
                    strSelect += ",year(ReservationStatusDate) as Y,Month(ReservationStatusDate) as M ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(ReservationStatusDate),Month(ReservationStatusDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(ReservationStatusDate),Month(ReservationStatusDate)";
                }
                else if (_IsYearGrouping)
                {
                    strSelect += ",year(ReservationStatusDate) as Y ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(ReservationStatusDate) ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(ReservationStatusDate) ";
                }

                if (_IsTowerGrouping)
                {
                    strSelect += ",TowerName,ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "TowerName,ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName,TowerName";


                }
                if (_IsProjectGrouping &&!_IsTowerGrouping)
                {
                    strSelect += ",ProjectName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName";
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
        #region Public static Cach Data
        public static string ReservationIDs
        {
            get
            {
                return _ReservationIDs;
            }
            set
            {
                _ReservationIDs = value;
            }
        }
        public static string OldReservationIDs
        {
            set
            {
                _OldReservationIDs = value;
            }
        }
        public static DataTable CachUnitTable
        {
            set
            {
                _CachUnitTable = value;
            }
            get
            {
                if (_CachUnitTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationUnitDb objDb = new ReservationUnitDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachUnitTable = objDb.Search();
                    string strUnitIDs = "";
                    UnitDb objUnitDb;
                    foreach (DataRow objDr in _CachUnitTable.Rows)
                    {
                        objUnitDb = new UnitDb(objDr);
                        if (strUnitIDs != "")
                            strUnitIDs += ",";
                        strUnitIDs += objUnitDb.ID.ToString();
                    }
                    UnitDb.CachUnitCellTable = null;
                    UnitDb.CachUnitIDs = strUnitIDs;

                }
                return _CachUnitTable;
            }
        }
        public static DataTable CachReservationTable
        {
            set
            {
                _CachReservationTable = value;
            }
            get 
            {
                if (_CachReservationTable == null)
                {
                    _CachReservationTable = new DataTable();
                    _CachReservationTable.Columns.Add("ReservationID");
                }
                return _CachReservationTable;
            }
        }
        public static DataTable CachInstallmentTable
        {
            set
            {
                _CachInstallmentTable = value;
            }
            get
            {
                if (_CachInstallmentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationInstallmentDb objDb = new ReservationInstallmentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachInstallmentTable = objDb.Search();
                    
                }
                return _CachInstallmentTable;
            }
        }
        public static DataTable ChachChildReservation
        {
            get
            {
                return _CachChildReservation;
            }
        }
        public static DataTable CachInstallmentDiscountTable
        {
            set
            {
                _CachInstallmentDiscountTable = value;
            }
            get
            {
                if (_CachInstallmentDiscountTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    InstallmentDiscountDb objDb = new InstallmentDiscountDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachInstallmentDiscountTable = objDb.Search();

                }
                return _CachInstallmentDiscountTable;
            }
        }
        public static DataTable CachWorkerTable
        {
            set
            {
              
                _CachWorkerTable = value;
            }
            get
            {
                if (_CachWorkerTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    WorkerContributionDb objDb = new WorkerContributionDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachWorkerTable = objDb.Search();

                }
                return _CachWorkerTable;
            }
        }
        public static DataTable CachInstallmentMulctTable
        {
            set
            {
                _CachInstallmentMulctTable = value;
            }
            get
            {
                if (_CachInstallmentMulctTable== null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    InstallmentMulctDb objDb = new InstallmentMulctDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachInstallmentMulctTable= objDb.Search();

                }
                return _CachInstallmentMulctTable;
            }
        }
        public static DataTable CachMulctPaymentTable
        {
            set
            {
                _CachMulctPaymentTable = value;
            }
            get
            {
                if (_CachMulctPaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                   MulctPaymentDb objDb = new MulctPaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachMulctPaymentTable = objDb.Search();

                }
                return _CachMulctPaymentTable;
            }
         
        }
        public static DataTable CachAttachmentTable
        {
            set
            {
                _CachAttachmentTable = value;
            }
            get
            {


                if (_CachAttachmentTable  == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationAttachmentDb objDb = new ReservationAttachmentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachAttachmentTable  = objDb.Search();

                }

                return _CachAttachmentTable;
            }
        }
        public static DataTable CachOldReservationTable
        {
            set
            {
                _CachOldReservationTable = value;
            }
            get
            {


                if (_CachOldReservationTable == null && _OldReservationIDs != null && _OldReservationIDs != "")
                {

                    ReservationDb objTemp = new ReservationDb();
                    string strSql = objTemp.SearchStr + " where ReservationID in ("+ _OldReservationIDs +")";
                    _CachOldReservationTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);


                }

                return _CachOldReservationTable;
            }
        }
        public static DataTable CachDiscountTable
        {
            set
            {
                _CachDiscountTable = value;
            }
            get
            {
                if (_CachDiscountTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationDiscountDb objDb = new ReservationDiscountDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachDiscountTable = objDb.Search();

                }
                return _CachDiscountTable;
            }
        }
        public static DataTable CachCheckTable
        {
            set 
            {
                _CachCheckTable = value;
            }
            get
            {
                if (_CachCheckTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    InstallmentCheckDb objDb = new InstallmentCheckDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachCheckTable = objDb.Search();

                }
                return _CachCheckTable;
            }
        }
        public static DataTable CachBonusTable
        {
            set
            {
                _CachBonusTable = value;
            }
            get
            {
                if (_CachBonusTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationBonusDb objDb = new ReservationBonusDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachBonusTable = objDb.Search();

                }
                return _CachBonusTable;
            }

        }
        public static DataTable CachTempPaymentTable
        {
            set
            {
                _CachTempPaymentTable = value;
            }
            get
            {
                if (_CachTempPaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    TempReservationPaymentDb objDb = new TempReservationPaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachTempPaymentTable = objDb.Search();

                }
                return _CachTempPaymentTable;
            }
        }
        public static DataTable CachAdministrativePaymentTable
        {
            set
            {
                _CachAdministrativePaymentTable = value;
            }
            get
            {
                if (_CachAdministrativePaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    AdministrativeCostPaymentDb objDb = new AdministrativeCostPaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachAdministrativePaymentTable = objDb.Search();

                }
                else
                {
                    _CachAdministrativePaymentTable = new DataTable();
                    _CachAdministrativePaymentTable.Columns.Add(new DataColumn("ReservationID"));
                }
                return _CachAdministrativePaymentTable;
            }
        }
        public static DataTable CachInsurancePaymentTable
        {
            set
            {
                _CachInsurancePaymentTable = value;
            }
            get
            {
                if (_CachInsurancePaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    InsurancePaymentDb objDb = new InsurancePaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachInsurancePaymentTable = objDb.Search();

                }
                return _CachInsurancePaymentTable;
            }
        }
        public static DataTable cachCustomerTable
        {
            set
            {
                _CachCustomerTable = value;
            }
            get
            {
                if (_CachCustomerTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    CustomerDb objCustomerDb = new CustomerDb();
                    string strSql = "SELECT CRMReservationCustomer.ReservationID,CustomerTable.* " +
                                           " FROM         dbo.CRMReservationCustomer inner join (" + objCustomerDb.SearchStr + ") as CustomerTable " +
                                           " on CustomerTable.CustomerID = CRMReservationCustomer.CustomerID  " +
                                           " where CRMReservationCustomer.ReservationID in (" + _ReservationIDs + ") ";

                    _CachCustomerTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

                }
                return _CachCustomerTable;
            }
            
        }
        public static DataTable CachInstallmentPaymentTable
        {
            set
            {
                _CachInstallmentPaymentTable = value;
            }
            get
            {
                if (_CachInstallmentPaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    InstallmentPaymentDb objDb = new InstallmentPaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachInstallmentPaymentTable = objDb.Search();

                }
                return _CachInstallmentPaymentTable;
            }
        }
        public static DataTable CachCellTable
        {
            set
            {
                _CachCellTable = value;
            }
            get
            {
                if (_CachCellTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    UnitCellDb objDb = new UnitCellDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachCellTable = objDb.Search();

                }
                return _CachCellTable;
            }
        }
        public static DataTable CachUtilityTable
        {
            set
            {
                _CachUtilityTable = value;
            }
            get
            {
                if (_CachUtilityTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    ReservationUtilityDb objDb = new ReservationUtilityDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachUtilityTable = objDb.Search();

                }
                return _CachUtilityTable;
            }
        }
        public static DataTable CachUtilityPaymentTable
        {
            set
            {
                _CachUtilityPaymentTable = value;
            }
            get
            {
                if (_CachUtilityPaymentTable == null && _ReservationIDs != null && _ReservationIDs != "")
                {
                    UtilityPaymentDb objDb = new UtilityPaymentDb();
                    objDb.ReservationIDs = _ReservationIDs;
                    _CachUtilityPaymentTable = objDb.Search();

                }
                return _CachUtilityPaymentTable;
            }
        }
        #endregion
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            SetMainData(objDR);
           
            try
            {
                _CustomerDb = new CustomerDb(objDR);
            }
            catch
            {
            }
        
            _StrategyDb = new StrategyDb();
            if (objDR["ReservationBranch"].ToString() != "0")
                _BranchDb = new BranchDb(objDR);
            else
                _BranchDb = new BranchDb();
            _BranchID = _BranchDb.ID;
        }
      
       
        void JoinCustomer()
        {
            if (_CustomerTable == null || _CustomerTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_CustomerTable.Rows.Count + 1];
            arrStr[0] = "delete from CRMReservationCustomer where ReservationID = " + _ID;
            int intIndex = 0;
            foreach (DataRow objDr in _CustomerTable.Rows)
            {
                intIndex++;
                arrStr[intIndex] = "insert into CRMReservationCustomer " +
                    " (ReservationID,CustomerID) values(" + _ID.ToString() + "," +
                    objDr["Customer"].ToString() + ")";


            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinInstallment()
        {
            if (_InstallmentTable == null || _InstallmentTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_InstallmentTable.Rows.Count];
            ReservationInstallmentDb objDb;

            int intIndex = 0;
            string strTemp = "";
            foreach (DataRow objDr in _InstallmentTable.Rows)
            {
                objDb = new ReservationInstallmentDb(objDr);
                objDb.ReservationID = _ID;
                if (objDb.ID == 0)
                    strTemp = objDb.AddStr;
                else
                    strTemp = objDb.EditStr;
                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinDiscount()
        {
            if (_DiscountTable == null || _DiscountTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DiscountTable.Rows.Count];
            ReservationDiscountDb objDb;
            int intIndex = 0;
            string strTemp = "";
            foreach (DataRow objDr in _DiscountTable.Rows)
            {
                objDb = new ReservationDiscountDb(objDr);
                objDb.ReservationID = _ID;
                if (objDb.ID == 0)
                    strTemp = objDb.AddStr;
                else
                    strTemp = objDb.EditStr;
                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }

        void JoinBonus()
        {
            if (_BonusTable == null || _BonusTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_BonusTable.Rows.Count];
            ReservationBonusDb objDb;
            int intIndex = 0;
            string strTemp = "";
            foreach (DataRow objDr in _BonusTable.Rows)
            {
                objDb = new ReservationBonusDb(objDr);
                objDb.ReservationID = _ID;
                if (objDb.ID == 0)
                    strTemp = objDb.AddStr;
                else
                    strTemp = objDb.EditStr;
                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinTempPayment()
        {
            if (_TempPaymentTable == null || _TempPaymentTable.Rows.Count == 0)
                return;
         
            TempReservationPaymentDb objDb;
            int intIndex = 0;
            string strTemp = "";
            string[] arrStr = new string[_TempPaymentTable.Rows.Count + 1];
            foreach (DataRow objDr in _TempPaymentTable.Rows)
            {
               
                objDb = new TempReservationPaymentDb(objDr);
                objDb.ReservationID = _ID;

                if (objDb.ID == 0)
                {
                    objDb.Add();
                    //arrStr[intIndex] = objDb.AddStr;
                }
                else
                {
                   objDb.Edit();
                    //arrStr[intIndex] = objDb.EditStr;
                }
                intIndex++;
            }
          //SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinAdministrativePayment()
        {
            if (_AdministrativePaymentTable == null || _AdministrativePaymentTable.Rows.Count == 0)
                return;

            AdministrativeCostPaymentDb objDb;
            int intIndex = 0;
            string strTemp = "";
            string[] arrStr = new string[_AdministrativePaymentTable.Rows.Count + 1];
            foreach (DataRow objDr in _AdministrativePaymentTable.Rows)
            {
                objDb = new AdministrativeCostPaymentDb(objDr);
                objDb.ReservationID = _ID;
                if (objDb.ID == 0)
                    objDb.Add();
                //arrStr[intIndex] = objDb.AddStr;
                else
                    objDb.Edit();
                    //arrStr[intIndex] = objDb.EditStr;
                intIndex++;
            }
         //    SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinUtility()
        {
            if ((_UtilityTable == null || _UtilityTable.Rows.Count == 0) && (_DeletedUtilityTable == null || _DeletedUtilityTable.Rows.Count==0))
                return;
            int intLen = _UtilityTable != null ? _UtilityTable.Rows.Count : 0;
            intLen += _DeletedUtilityTable != null ? _DeletedUtilityTable.Rows.Count : 0;
            string[] arrStr = new string[intLen ];
            ReservationUtilityDb objDb;
            int intIndex = 0;
            string strTemp = "";
            foreach (DataRow objDr in _UtilityTable.Rows)
            {
                objDb = new ReservationUtilityDb(objDr);
                objDb.ReservationID = _ID;
                if (objDb.ID == 0)
                    strTemp = objDb.AddStr;
                else
                    strTemp = objDb.EditStr;
                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            if (_DeletedUtilityTable != null)
            {
                foreach (DataRow objDr in _DeletedUtilityTable.Rows)
                {
                    objDb = new ReservationUtilityDb(objDr);
                    objDb.ReservationID = _ID;

                    strTemp = objDb.DeleteStr;

                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #region Delete Method
        void DeleteInstallment()
        {
            if (_DeletedInstallmentTable == null || _DeletedInstallmentTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedInstallmentTable.Rows.Count];
            int intIndex = 0;
            ReservationInstallmentDb objDb;

            foreach (DataRow objDr in _DeletedInstallmentTable.Rows)
            {
                objDb = new ReservationInstallmentDb(objDr);
                objDb.ReservationID = _ID;
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteTempPayment()
        {
            if (_DeletedPaymentTable== null || _DeletedPaymentTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedPaymentTable.Rows.Count];
            int intIndex = 0;
            TempReservationPaymentDb objDb;
            foreach (DataRow objDr in _DeletedPaymentTable.Rows)
            {
                objDb = new TempReservationPaymentDb(objDr);
                objDb.ReservationID = _ID;
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteAdministrativePayment()
        {
            if (_DeletedAdministrativePaymentTable == null || _DeletedAdministrativePaymentTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedAdministrativePaymentTable.Rows.Count];
            int intIndex = 0;
            AdministrativeCostPaymentDb objDb;
            foreach (DataRow objDr in _DeletedAdministrativePaymentTable.Rows)
            {
                objDb = new AdministrativeCostPaymentDb(objDr);
                objDb.ReservationID = _ID;
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteDiscount()
        {
            if (_DeletedDiscountTable == null || _DeletedDiscountTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedDiscountTable.Rows.Count];
            int intIndex = 0;
            ReservationDiscountDb objDb;
            foreach (DataRow objDr in _DeletedDiscountTable.Rows)
            {
                objDb = new ReservationDiscountDb(objDr);
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteBonus()
        {
            if (_DeletedBonusTable == null || _DeletedBonusTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedBonusTable.Rows.Count];
            int intIndex = 0;
            ReservationBonusDb objDb;
            foreach (DataRow objDr in _DeletedBonusTable.Rows)
            {
                objDb = new ReservationBonusDb(objDr);
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteAttachment()
        {
            if (_DeletedAttachmentTable == null || _DeletedAttachmentTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeletedAttachmentTable.Rows.Count];
            int intIndex = 0;
            ReservationAttachmentDb objDb;
            foreach (DataRow objDr in _DeletedAttachmentTable.Rows)
            {
                objDb = new ReservationAttachmentDb(objDr);
                arrStr[intIndex] = objDb.DeleteStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
        #endregion
        #region Public Methods
        public virtual void Add1()
        {
            #region Assign Reservation Unit
            string strUnitIDs = "";
            int intUnitCount = 0;
            string strUnitID = "";
            DataRow[] arrUnitDr = _UnitTable.Select("", "UnitID");
            foreach (DataRow objDr in _UnitTable.Rows)
            {
                if (strUnitID != objDr["UnitID"].ToString())
                {
                    intUnitCount++;
                    strUnitID = objDr["UnitID"].ToString();
                    if (strUnitIDs != "")
                        strUnitIDs += ",";
                    strUnitIDs += objDr["UnitID"].ToString();
                }
            }

            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitIDs = strUnitIDs;
            string strSql = "";
            if (_Parent == 0)
            {
                strSql = "select count(DISTINCT dbo.CRMUnit.UnitID) from CRMUnit  where UnitID in(" + strUnitIDs + ") " +
                    " and UnitClosedPermanent=0 And (CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation=" + _ID + " or " +
                    " CRMUnit.CurrentReservation is null or CRMUnit.CurrentReservation = " + _Parent + ") " +
                            " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                            " or UnitTimeOpen<GetDate() )  ";
            }
            else
            {
                strSql = "SELECT     COUNT(DISTINCT dbo.CRMUnit.UnitID) AS Expr1 "+
                      " FROM         dbo.CRMUnit INNER JOIN "+
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID AND "+
                      " dbo.CRMUnit.CurrentReservation = dbo.CRMReservationUnit.ReservationID "+
                      " WHERE  (dbo.CRMUnit.CurrentReservation = " + _Parent + ")and  "+
                      " CRMUnit.UnitID in ("+ strUnitIDs + ") and "+
                      "(dbo.CRMReservationUnit.ChildReservation = 0 or dbo.CRMReservationUnit.ChildReservation=" + _ID + ") ";
            }
            SqlTransaction objTrans;
            SqlConnection objCon = SysData.SharpVisionBaseDb.Connection;
            objTrans = objCon.BeginTransaction();
           
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSetCurrentReservation, objCon, objTrans);

            int intResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strSql, objCon, objTrans).ToString());
            if (intResultCount == intUnitCount)
                objTrans.Commit();
            else
            {

                objTrans.Rollback();
                return;
            }
            objTrans = null;
            objCon.Close();
            #endregion
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            if (_Parent == 0)
            {
                objUnitDb = new UnitDb();
                
                objUnitDb.Reservation = _ID;
                objUnitDb.UnitIDs = strUnitIDs;
                objUnitDb.EditCurrentReservation();
            }
            else
            {
                ReservationUnitDb objReservationUnitDb = new ReservationUnitDb();
                objReservationUnitDb.ReservationID = _Parent;
                objReservationUnitDb.ChildReservation = ID;
                objReservationUnitDb.UnitIDs = strUnitIDs;
                objReservationUnitDb.EditChildReservation();

            }

            JoinUnit(); 
            JoinContribution();
            JoinCustomer();
            JoinInstallment();
            JoinDiscount();
            JoinBonus();
            JoinTempPayment();
            JoinAdministrativePayment();
            JoinUtility();
            InsertHistory();
        }
        public virtual void AddOld()
        {
            #region Assign Reservation Unit
           
            int intOcupiedUnit = (int)SysData.SharpVisionBaseDb.ReturnScalar(NotAvailableUnit);
            #endregion
            if (intOcupiedUnit > 0)
                return;
            
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
          

            JoinUnit();
            JoinContribution();
            JoinCustomer();
            JoinInstallment();
            JoinDiscount();
            JoinBonus();
            JoinTempPayment();
            JoinAdministrativePayment();
            JoinUtility();
            InsertHistory();
        }
        public virtual void Add()
        {

            CopyTempUnit();

            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(AddStr);
            int.TryParse(dtTemp.Rows[0]["ReservationID"].ToString(), out _ID);
            //_ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            if (_ID == -1)
                return;

            //JoinUnit();
            JoinContribution();
            JoinCustomer();
            JoinInstallment();
            JoinDiscount();
            JoinBonus();
            JoinTempPayment();
            JoinAdministrativePayment();
            JoinUtility();
            InsertHistory();
        }
        public  virtual void Edit()
        {
            #region Assign Reservation Unit

            // int intOcupiedUnit = (int)SysData.SharpVisionBaseDb.ReturnScalar(NotAvailableUnit);
            #endregion
            //if (intOcupiedUnit > 0)
            //    return;
            CopyTempUnit();
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(EditStr);
            int.TryParse(dtTemp.Rows[0]["ReservationID"].ToString(), out _ID);
            
            if (_ID == -1)
                return;
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
           // JoinUnit();
            JoinContribution();
            JoinCustomer();
            JoinInstallment();
            JoinDiscount();
            JoinBonus();
            JoinTempPayment();
            JoinAdministrativePayment();
            JoinUtility();
            JoinUnit();
            DeleteBonus();
            DeleteDiscount();
            DeleteInstallment();
            DeleteTempPayment();
            DeleteAdministrativePayment();
            _EditSucceded = true;
            InsertHistory();
        }
       
        public virtual void EditStatus()
        {
            string strDelegationDate = _IsDelegated ?
                SysUtility.Approximate(_DelegationDate.ToOADate()-2,1,ApproximateType.Down).ToString() : "null";


            string strSql = "update  CRMReservation ";
            strSql = strSql + " set ReservationStatus =" + _Status + "";
            strSql += ",ReservationDelegationDate=" + strDelegationDate;
            strSql = strSql + " where ReservationID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void EditNote()
        {
            string strSql = "";
            if(_ID != 0)
            strSql = "update  CRMReservation " +
                " set ReservationNote ='" + _Note.Replace("'","''") + "'" +
                " where ReservationID = " + _ID;
            else 
            {
                strSql = "update  CRMReservation " +
              " set ReservationNote ='" + _Note.Replace("'", "''") + @"'+ ' 
 ' + ReservationNote 
              where ReservationID in (" + _IDs + ")";
            }
            if (_ID != 0 || (_IDs != null && _IDs != ""))
            {
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                InsertHistory();
            }
        }
        public bool ReAsignCanceledUnit()
        {
            #region Assign Reservation Unit
            string strUnitIDs = "";
            int intUnitCount = 0;
            string strUnitID = "";
            DataRow[] arrUnitDr = _UnitTable.Select("", "UnitID");
            foreach (DataRow objDr in _UnitTable.Rows)
            {
                if (strUnitID != objDr["UnitID"].ToString())
                {
                    intUnitCount++;
                    strUnitID = objDr["UnitID"].ToString();
                    if (strUnitIDs != "")
                        strUnitIDs += ",";
                    strUnitIDs += objDr["UnitID"].ToString();
                }
            }
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitIDs = strUnitIDs;
            string strSql = "";
            if (_Parent == 0)
            {
                strSql = "select count(DISTINCT dbo.CRMUnit.UnitID) from CRMUnit  where UnitID in(" + strUnitIDs + ") " +
                    " and UnitClosedPermanent=0 And (CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation=" + _ID + " or " +
                    " CRMUnit.CurrentReservation is null or CRMUnit.CurrentReservation = " + _Parent + ") " +
                            " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                            " or UnitTimeOpen<GetDate() )  ";
            }
            else
            {
                strSql = "SELECT     COUNT(DISTINCT dbo.CRMUnit.UnitID) AS Expr1 " +
                      " FROM         dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID AND " +
                      " dbo.CRMUnit.CurrentReservation = dbo.CRMReservationUnit.ReservationID " +
                      " WHERE  (dbo.CRMUnit.CurrentReservation = " + _Parent + ")and  " +
                      " CRMUnit.UnitID in (" + strUnitIDs + ") and " +
                      "(dbo.CRMReservationUnit.ChildReservation = 0 or dbo.CRMReservationUnit.ChildReservation=" + _ID + ") ";
            }
            SqlTransaction objTrans;
            SqlConnection objCon = SysData.SharpVisionBaseDb.Connection;
            objTrans = objCon.BeginTransaction();

            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSetCurrentReservation, objCon, objTrans);

            int intResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strSql, objCon, objTrans).ToString());
            
            if (intResultCount == intUnitCount)
                objTrans.Commit();
            else
            {

                objTrans.Rollback();
                return false;
            }
            objTrans = null;
            objCon.Close();
            #endregion
            //_ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            if (_Parent == 0)
            {
                objUnitDb = new UnitDb();

                objUnitDb.Reservation = _ID;
                objUnitDb.UnitIDs = strUnitIDs;
                objUnitDb.EditCurrentReservation();
            }
            else
            {
                ReservationUnitDb objReservationUnitDb = new ReservationUnitDb();
                objReservationUnitDb.ReservationID = _Parent;
                objReservationUnitDb.ChildReservation = ID;
                objReservationUnitDb.UnitIDs = strUnitIDs;
                objReservationUnitDb.EditChildReservation();

            }
            return true;
        }
        public void ReloadCanceledReservation()
        {
 
        }
        public void CreateLeafAccount()
        {
            if (_AccountTable == null || _AccountTable.Rows.Count == 0)
                return;
            AccountDb objAccountDb = new AccountDb(_AccountTable.Rows[0]);
            SqlConnection objCon = SysData.SharpVisionBaseDb.Connection;
            SqlTransaction objTrans = objCon.BeginTransaction();
            try
            {
                int intAccountID = SysData.SharpVisionBaseDb.InsertIdentityTable(objAccountDb.AddStr, objCon, objTrans);
                if (intAccountID == 0)
                {
                    objTrans.Rollback();
                    objCon.Close();
                    return;
                }
                string strSql = "update CRMReservation set ReservationGLLeafAccount ="+intAccountID +
                    " where ReservationID = "+ _ID;

                if (SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql, objCon, objTrans))
                {
                    objTrans.Commit();
                    objCon.Close();
                    return;
                }
            }
            catch
            {

 
            }
            objTrans.Rollback();
            objCon.Close();

             
 
        }
        public void DeleteNonCollectedCheckPayment()
        {
            string strInner = "SELECT  dbo.CRMReservationInstallment.InstallmentID,GLPayment.PaymentID " +
                      " FROM    dbo.CRMReservationInstallment INNER JOIN " +
                      " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                      " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
                      " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
                      " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                      " WHERE     (dbo.GLCheckPayment.PaymentIsCollected = 0) AND (dbo.GLCheck.CheckCurrentStatus <> 2 AND dbo.GLCheck.CheckCurrentStatus <> 4) AND  " +
                      " (dbo.CRMReservationInstallment.ReservationID = "+ ID +")";
           string strSql = "";
           strSql = "update CRMReservationInstallment set InstallmentStatus = 0 " +
              "where InstallmentID in(select InstallmentID from (" + strInner + ") as NativeINstallment ) ";
           SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
             strSql  = "delete from CRMInstallmentPayment where InstallmentID in (select InstallmentID from (" + strInner + ") as NativeInstallment) and PaymentID in (select PaymentID from ("+strInner+") as NativePayment)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
           
        }
        public void CreateContractingTransaction()
        {
            if (_ContractingTransactionTable == null || _ContractingTransactionTable.Rows.Count == 0)
                return;
            string []arrStr = new string[_ContractingTransactionTable.Rows.Count];
            string strTemp = "";
            int intIndex = 0;
            DataRow [] arrDr ;
            ReservationTransactionDb objReservationTransactionDb = new ReservationTransactionDb();
            foreach (DataRow objDr in _ContractingTransactionTable.Rows)
            {
                
                TransactionDb objTransactionDb = new TransactionDb(objDr);
                strTemp = objTransactionDb.AddStr;
                strTemp += " declare @TransactionID int; ";
                strTemp += " set @TransactionID = (select @@Identity as TransactionID); ";
                strTemp += "update CRMReservation set ReservationGLContractingTransaction=@TransactionID "+
                    " where ReservationID= " + objDr["CurrentReservation"].ToString();
                if(_ReservationTransactionTable!= null && _ReservationTransactionTable.Rows.Count>0)
                {
                  arrDr = _ReservationTransactionTable.Select("ReservationID="+
                      objDr["CurrentReservation"].ToString());
                    if(arrDr.Length >0)
                    {
                        objReservationTransactionDb = new ReservationTransactionDb(arrDr[0]);
                        strTemp+= objReservationTransactionDb.AddStr;

                    }
                }


                arrStr[intIndex] = strTemp;
                intIndex++;
 
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
           

        }
        public void CreateDeliveryTransaction()
        {
            if (_DeliveryTransactionTable == null || _DeliveryTransactionTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeliveryTransactionTable.Rows.Count];
            string strTemp = "";
            int intIndex = 0;
            DataRow[] arrDr;
            ReservationTransactionDb objReservationTransactionDb = new ReservationTransactionDb();
            string strReverseContracting = "";
            double dblTransactionDate = 0;
            foreach (DataRow objDr in _DeliveryTransactionTable.Rows)
            {

                TransactionDb objTransactionDb = new TransactionDb(objDr);
                strTemp = objTransactionDb.AddStr;
                strTemp += " declare @TransactionID int; ";
                strTemp += " set @TransactionID = (select @@Identity as TransactionID); ";
                strTemp += "update CRMReservation set  ReservationGLDeliveryTransaction = @TransactionID " +
                    " where ReservationID= " + objDr["CurrentReservation"].ToString();
                if (_ReservationTransactionTable != null && _ReservationTransactionTable.Rows.Count > 0)
                {
                    arrDr = _ReservationTransactionTable.Select("ReservationID=" +
                        objDr["CurrentReservation"].ToString());
                    if (arrDr.Length > 0)
                    {
                        objReservationTransactionDb = new ReservationTransactionDb(arrDr[0]);
                        strTemp += objReservationTransactionDb.AddStr;

                    }
                }
                dblTransactionDate = objTransactionDb.Date.ToOADate() - 2;
                strReverseContracting = "insert into GLTransaction (TransactionDate, TransactionCode, TransactionType, TransactionValue, TransactionCurrency, TransactionCurrencyValue, TransactionDesc, "+
                      " TransactionAcountFrom, TransactionAccountTo, TransactionReservationID, TransactionCell,"+
                      "TransactionReversedID, TransactionStatus, TransactionPost, UsrIns, TimIns "+
                      ") "+
                      "SELECT "+ dblTransactionDate +" as TransactionDate, dbo.GLTransaction.TransactionCode, dbo.GLTransaction.TransactionType, dbo.GLTransaction.TransactionValue, "+
                      " dbo.GLTransaction.TransactionCurrency, dbo.GLTransaction.TransactionCurrencyValue, dbo.GLTransaction.TransactionDesc, "+
                      " dbo.GLTransaction.TransactionAccountTo, dbo.GLTransaction.TransactionAcountFrom, dbo.GLTransaction.TransactionReservationID, "+
                      " dbo.GLTransaction.TransactionCell,dbo.GLTransaction.TransactionID, dbo.GLTransaction.TransactionStatus, dbo.GLTransaction.TransactionPost, " + SysData.CurrentUser.ID + " as UsrIns,  " +
                      " GetDate() as TimIns "+
                      " FROM dbo.GLTransaction INNER JOIN "+
                      " dbo.CRMReservation ON dbo.GLTransaction.TransactionID = dbo.CRMReservation.ReservationGLContractingTransaction "+
                      " where CRMReservation.ReservationID= " + objDr["CurrentReservation"].ToString();
                //strReverseContracting += " set @TransactionID = (select @@Identity as TransactionID); ";
                //strReverseContracting += " update CRMReservation set ReservationGLReverseContracting = @TransactionID "+
                //    " where ReservationID=" + objDr["CurrentReservation"].ToString();
                strTemp += strReverseContracting;


                arrStr[intIndex] = strTemp;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);


        }
        public void CreateCancelationTransaction()
        {
            if (_DeliveryTransactionTable == null || _DeliveryTransactionTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_DeliveryTransactionTable.Rows.Count];
            string strTemp = "";
            int intIndex = 0;
            DataRow[] arrDr;
            ReservationTransactionDb objReservationTransactionDb = new ReservationTransactionDb();
            string strReverseContracting = "";
            double dblTransactionDate = 0;
            foreach (DataRow objDr in _DeliveryTransactionTable.Rows)
            {

                TransactionDb objTransactionDb = new TransactionDb(objDr);
                strTemp = objTransactionDb.AddStr;
                strTemp += " declare @TransactionID int; ";
                strTemp += " set @TransactionID = (select @@Identity as TransactionID); ";
                strTemp += "update CRMReservation set  ReservationGLDeliveryTransaction = @TransactionID " +
                    " where ReservationID= " + objDr["CurrentReservation"].ToString();
                if (_ReservationTransactionTable != null && _ReservationTransactionTable.Rows.Count > 0)
                {
                    arrDr = _ReservationTransactionTable.Select("ReservationID=" +
                        objDr["CurrentReservation"].ToString());
                    if (arrDr.Length > 0)
                    {
                        objReservationTransactionDb = new ReservationTransactionDb(arrDr[0]);
                        strTemp += objReservationTransactionDb.AddStr;

                    }
                }
                dblTransactionDate = objTransactionDb.Date.ToOADate() - 2;
                strReverseContracting = "insert into GLTransaction (TransactionDate, TransactionCode, TransactionType, TransactionValue, TransactionCurrency, TransactionCurrencyValue, TransactionDesc, " +
                      " TransactionAcountFrom, TransactionAccountTo, TransactionReservationID, TransactionCell, TransactionStatus, TransactionPost, UsrIns, TimIns " +
                      ") " +
                      "SELECT " + dblTransactionDate + " as TransactionDate, dbo.GLTransaction.TransactionCode, dbo.GLTransaction.TransactionType, dbo.GLTransaction.TransactionValue, " +
                      " dbo.GLTransaction.TransactionCurrency, dbo.GLTransaction.TransactionCurrencyValue, dbo.GLTransaction.TransactionDesc, " +
                      " dbo.GLTransaction.TransactionAccountTo, dbo.GLTransaction.TransactionAcountFrom, dbo.GLTransaction.TransactionReservationID, " +
                      " dbo.GLTransaction.TransactionCell, dbo.GLTransaction.TransactionStatus, dbo.GLTransaction.TransactionPost, " + SysData.CurrentUser.ID + " as UsrIns,  " +
                      " GetDate() as TimIns " +
                      " FROM dbo.GLTransaction INNER JOIN " +
                      " dbo.CRMReservation ON dbo.GLTransaction.TransactionID = dbo.CRMReservation.ReservationGLContractingTransaction " +
                      " where CRMReservation.ReservationID= " + objDr["CurrentReservation"].ToString();
                strReverseContracting += " set @TransactionID = (select @@Identity as TransactionID); ";
                strReverseContracting += " update CRMReservation set ReservationGLReverseContracting = @TransactionID " +
                    " where ReservationID=" + objDr["CurrentReservation"].ToString();
                strTemp += strReverseContracting;


                arrStr[intIndex] = strTemp;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);


        }
        public void SetReservationChanged()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
     
        public virtual void Delete()
        {
            InsertHistory();
            string strInner = "SELECT  dbo.CRMReservationInstallment.InstallmentID,GLPayment.PaymentID " +
             " FROM    dbo.CRMReservationInstallment INNER JOIN " +
             " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
             " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
             " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
             " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
             " WHERE     (dbo.GLCheckPayment.PaymentIsCollected = 0)  " +
             " AND (dbo.GLCheck.CheckCurrentStatus <> 2 AND dbo.GLCheck.CheckCurrentStatus <> 4) AND  " +
             " (dbo.CRMReservationInstallment.ReservationID = " + _ID + ")";
             string strSql = "   delete from CRMInstallmentPayment where InstallmentID in (select InstallmentID from (" + strInner +
                ") as NativeInstallment) and PaymentID in (select PaymentID from (" + strInner + ") as NativePayment)";

            if (_Parent == 0)
                strSql += "update CRMUnit set CurrentReservation = 0 where CurrentReservation =" + _ID;
            else
                strSql += "update CRMReservationUnit set ChilReservation = 0 where ChildReservation=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "delete from CRMReservation where ReservationID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //DeleteNonCollectedCheckPayment();
        }
        public virtual DataTable Search()
        {
            string strSql = SearchStr ;
            if (_ID == 0 && 
                (_IDs == null ||_IDs == "") && 
                (_UnitCode == null || _UnitCode == ""))
            {
                if (_MaxID == 0 && _MinID == 0)
                {
                    string strCountSql = "select count(*) as ResultCount,sum(ReservationValue) as ResultValue,sum(DiscountValue) as ResultDiscountValue from (" + strSql + ")  AS NativeTable ";

                    //_ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
                    DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                    if (dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["ResultCount"].ToString() != "")
                        {
                            _ResultCount = int.Parse(dtTemp.Rows[0]["ResultCount"].ToString());
                        }
                        if (dtTemp.Rows[0]["ResultValue"].ToString() != "")
                            _ResultVaue = double.Parse(dtTemp.Rows[0]["ResultValue"].ToString());
                        if (dtTemp.Rows[0]["ResultDiscountValue"].ToString() != "")
                            _ResultDiscountValue = double.Parse(dtTemp.Rows[0]["ResultDiscountValue"].ToString());


                    }
                }
                else
                {
                    if (_MaxID != 0)
                        strSql += " and NativeReservationTable.ReservationID >" + _MaxID;
                    else if (_MinID != 0)
                    {
                        strSql += " and NativeReservationTable.ReservationID<" + _MinID;
                    }
                }
            }
            //strSql += " union " + SearchStr + " where ReservationParent in (select ReservationID from ("+ strSql +") as ParentTable )";
            string strTop = "top 2000";
            if (_TopSelect > 0)
                strTop = "top " + _TopSelect.ToString();
            strSql = "select "+ strTop +" * from (" +strSql  +") as Nativetable Order by ReservationID ";
            string strChildReservation = "";
            _CachReservationTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Reservation");

            _ReservationIDs = "";
            ReservationDb objReservationDb;
            _OldReservationIDs = "";
            if (_IDs == null || _IDs == "")
            {
                foreach (DataRow objDr in _CachReservationTable.Rows)
                {
                    objReservationDb = new ReservationDb(objDr);
                    if (_ReservationIDs != "")
                        _ReservationIDs = _ReservationIDs + ",";
                    _ReservationIDs = _ReservationIDs + objReservationDb.ID.ToString();//objDr["ReservationID"].ToString();
                    if (objReservationDb.OldReservationID != 0)
                    {
                        if (_OldReservationIDs != "")
                            _OldReservationIDs += ",";

                        _ReservationIDs += "," + objReservationDb.OldReservationID.ToString();
                        _OldReservationIDs += objReservationDb.OldReservationID.ToString();
                    }
                    
                }


            }
            else
            {
                _ReservationIDs = _IDs;
            }
           

            UnitDb.CachReservationDataTable = _CachReservationTable;
            if (_ReservationIDs != null && _ReservationIDs != "")
            {
                //string strCustomerIDs = "SELECT dbo.CRMCustomerContact.CustomerID " +
                //          " FROM         dbo.CRMCustomerContact INNER JOIN " +
                //          " dbo.CRMReservationCustomer ON dbo.CRMCustomerContact.CustomerID = dbo.CRMReservationCustomer.CustomerID " +
                //          " where CRMReservationCustomer.ReservationID in (" + _ReservationIDs + ")";
                //CustomerDb.IDsStr = strCustomerIDs;
            }
            SetReservationCach();
            return _CachReservationTable;
        }
       

        public void InsertHistory()
        {
            string strSql =  "insert into CRMReservationHistory  (ReservationID, ReservationValue, ReservationPaidValue, ReservationNote, ReservationStatus, ReservationCustomer, ReservationUnit, ReservationDate, " +
                      " ReservationContractingDate, ReservationCancelationDate, ReservationDelegationDate" +
                      ",    CancelationNote, CancelationCost, PayBackComplete, PayBackCompleteDate, PayBackCompleteUsr, CancelationType " +
                      ", UsrIns, TimIns " +
                       ") " +
                " SELECT     ReservationID, ReservationValue, TempPaymentValue + TotalInstallmentPaidValue AS TotalPaidValue, ReservationNote, ReservationStatus, CustomerFullName, " +
                      " UnitFullName, ReservationDate, ReservationContractingDate, CancelationDate,ReservationDelegationDate" +
                     ",    CancelationNote, CancelationCost, PayBackComplete, PayBackCompleteDate, PayBackCompleteUsr, CancelationTypeID " +
                      "," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns " +
                      " from (" + SearchStr + ") as NativeTable ";
            if (ID != 0) 
                strSql += " where ReservationID =   " + ID;
            else if (_IDs != null && _IDs != "")
                strSql += " where ReservationID in  (" + _IDs + ")";
            if(_ID!= 0 || (_IDs!= null&& _IDs!= ""))
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void SetMainData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ReservationID"].ToString());

            _Status = int.Parse(objDr["ReservationStatus"].ToString());

            _Value = double.Parse(objDr["ReservationValue"].ToString());
            _Date = DateTime.Parse(objDr["ReservationDate"].ToString());
            if (objDr["UsrIns"].ToString() != "")
                _UserIns = int.Parse(objDr["UsrIns"].ToString());
            if (objDr["UsrUpd"].ToString() != "")
            {
                _UserUpd = int.Parse(objDr["UsrUpd"].ToString());
                _TimeUpd = DateTime.Parse(objDr["TimUpd"].ToString());
            }
            //if (objDR["CanceledReservation"].ToString() != "")
            //{
            //    _UserUpd = int.Parse(objDR["CancelationUsr"].ToString());
            //    _TimeUpd = DateTime.Parse(objDR["CancelationDate"].ToString());
            //}
            _TimeIns = DateTime.Parse(objDr["TimIns"].ToString());
            //_TimeUpd = DateTime.Parse(objDR["TimUpd"].ToString());

            _ContributionValue = double.Parse(objDr["ReservationContributionValue"].ToString());
            _ContributionPerc = double.Parse(objDr["ReservationContributionPerc"].ToString());
            _UnitPrice = double.Parse(objDr["ReservationUnitPrice"].ToString());
            _CachePrice = double.Parse(objDr["ReservationCachePrice"].ToString());
            _Finishing = int.Parse(objDr["ReservationFinishing"].ToString());
            _ProfitIsCompound = bool.Parse(objDr["ReservationProfitIsCompound"].ToString());
            _IsFree = bool.Parse(objDr["ReservationIsFree"].ToString());
            _ProfitValue = double.Parse(objDr["ReservationProfitValue"].ToString());
            _ProfitPeriod = int.Parse(objDr["ReservationProfitPeriod"].ToString());
            _PeriodAmount = double.Parse(objDr["ReservationPeriodAmount"].ToString());
            _Period = int.Parse(objDr["ReservationPeriod"].ToString());
            _GLAccount = int.Parse(objDr["ReservationGLAccount"].ToString());
            _IsNew = bool.Parse(objDr["ReservationIsNew"].ToString());
            if (objDr["ReservationStatusDate"].ToString() != "")
                _StatusDate = DateTime.Parse(objDr["ReservationStatusDate"].ToString());
            _GLLeafAccount =
                int.Parse(objDr["ReservationGLLeafAccount"].ToString());
            _Parent = int.Parse(objDr["ReservationParent"].ToString());
            if (objDr["ReservationLimitDate"].ToString() != "")
                _LimitDate = DateTime.Parse(objDr["ReservationLimitDate"].ToString());
            if (objDr["ReservationProfitPeriodAmount"] != DBNull.Value)
                _ProfitPeriodAmount = double.Parse(objDr["ReservationProfitPeriodAmount"].ToString());
            if (objDr["ReservationAllowance"] != DBNull.Value)
                _Allowance = int.Parse(objDr["ReservationAllowance"].ToString());
            _Note = objDr["ReservationNote"].ToString();
            if (objDr["ReservationContractingDate"] != DBNull.Value)
                _ContractingDate = DateTime.Parse(objDr["ReservationContractingDate"].ToString());
            if (objDr["ReservationDeliveryDate"] != DBNull.Value)
                _DeliveryDate = DateTime.Parse(objDr["ReservationDeliveryDate"].ToString());

            if (objDr["ReservationRealDeliveryDate"] != DBNull.Value)
            {
                _RealDeliveryDate = DateTime.Parse(objDr["ReservationRealDeliveryDate"].ToString());
                _IsDelivered = true;
            }
            else
                _IsDelivered = false;
            if (objDr.Table.Columns["CessionPreviousPaidValue"] != null &&
                objDr["CessionPreviousPaidValue"].ToString() != "")
            {
                _PreviousPaidValue =
                    double.Parse(objDr["CessionPreviousPaidValue"].ToString());
                _OldReservationID = int.Parse(objDr["OldReservationID"].ToString());
            }
            _IsDelegated = false;
            _IsReservedAgain = false;
            if (objDr["ReservationDelegationDate"].ToString() != "")
            {
                _IsDelegated = true;
                _DelegationDate = DateTime.Parse(objDr["ReservationDelegationDate"].ToString());
                if (objDr["ReservedAgain"].ToString() != "")
                {
                    int intReservedCount = int.Parse(objDr["ReservedAgain"].ToString());
                    if (intReservedCount > 0)
                        _IsReservedAgain = true;
                }

            }
            if (objDr.Table.Columns["DiscountValue"] != null && objDr["DiscountValue"].ToString() != "")
                _DiscountValue = double.Parse(objDr["DiscountValue"].ToString());
            if (objDr.Table.Columns["BonusValue"] != null && objDr["BonusValue"].ToString() != "")
                _BonusValue = double.Parse(objDr["BonusValue"].ToString());
            if (objDr.Table.Columns["TotalMulctPaymentValue"] != null && objDr["TotalMulctPaymentValue"].ToString() != "")
                _MulctPaymentValue = double.Parse(objDr["TotalMulctPaymentValue"].ToString());
            if (objDr.Table.Columns["InstallmentDiscountValue"] != null && objDr["InstallmentDiscountValue"].ToString() != "")
                _InstallmentDiscountValue = double.Parse(objDr["InstallmentDiscountValue"].ToString());
            if (objDr.Table.Columns["TotalInstallmentPaidValue"] != null && objDr["TotalInstallmentPaidValue"].ToString() != "")
                _InstallmentPaymentValue = double.Parse(objDr["TotalInstallmentPaidValue"].ToString());
            _IsContracted = false;
            _IsComplete = false;
            if (objDr["ReservationContractingDate"].ToString() != "" && DateTime.Parse(objDr["ReservationContractingDate"].ToString()).Year > 1900)
            {
                _IsContracted = true;
            }

            //_Value = _CachePrice - DiscountValue;
            _DataIsHidden = bool.Parse(objDr["ReservationDataIsHidden"].ToString());
            if (objDr["ReservationGLContractingTransaction"].ToString() != "")
                _ContractingTransactionID = int.Parse(objDr["ReservationGLContractingTransaction"].ToString());
            if (objDr["ReservationGLDeliveryTransaction"].ToString() != "")
                _DeliveryTransactionID = int.Parse(objDr["ReservationGLDeliveryTransaction"].ToString());
            if (objDr["ReservationGLCancelationTransaction"].ToString() != "")
                _CancelationTransactionID = int.Parse(objDr["ReservationGLCancelationTransaction"].ToString());
            _UnitCode = objDr["UnitFullName"].ToString();
            _UnitName = objDr["UnitNameA"].ToString();
            _ProjectName = objDr["ProjectName"].ToString();
            if (objDr.Table.Columns["ProjectID"] != null)
                int.TryParse(objDr["ProjectID"].ToString(), out _ProjectID);
            _TowerName = objDr["TowerName"].ToString();
            _UnitSurvey = objDr["UnitSurvey"].ToString();
            if (objDr.Table.Columns["SalesManName"] != null)
                _SalesMan = objDr["SalesManName"].ToString();
            if (objDr.Table.Columns["FloorID"] != null && objDr["FloorID"].ToString() != "")
                _FloorID = int.Parse(objDr["FloorID"].ToString());
            if (objDr["TowerDeliveryDate"].ToString() != "")
            {
                _TowerIsDelivered = true;
                _TowerDeliveryDate = DateTime.Parse(objDr["TowerDeliveryDate"].ToString());
            }
            if (objDr.Table.Columns["CustomerFullNameMultiple"] != null)
                _CustomerName = objDr["CustomerFullNameMultiple"].ToString();
            if (objDr.Table.Columns["CustomerNationality"] != null)
                _CustomerNationality = objDr["CustomerNationality"].ToString();
            if (objDr.Table.Columns["OldCessionNewReservationID"] != null && objDr["OldCessionNewReservationID"].ToString() != "")
                _NewReservationID = int.Parse(objDr["OldCessionNewReservationID"].ToString());
            if (objDr.Table.Columns["NewCessionOldReservationID"] != null && objDr["NewCessionOldReservationID"].ToString() != "")
                _OldReservationID = int.Parse(objDr["NewCessionOldReservationID"].ToString());
            if (objDr.Table.Columns["OldUnitFullName"] != null)
                _OldReservationUnitFullName = objDr["OldUnitFullName"].ToString();
            if (objDr.Table.Columns["OldCustomerFullName"] != null)
                _OldReservationCustomerName = objDr["OldCustomerFullName"].ToString();
            if (objDr.Table.Columns["NewUnitFullName"] != null)
                _NewReservationUnitName = objDr["NewUnitFullName"].ToString();
            if (objDr.Table.Columns["NewCustomerFullName"] != null)
                _NewReservationCustomerName = objDr["NewCustomerFullName"].ToString();
            if (objDr.Table.Columns["NewCessionCost"] != null && objDr["NewCessionCost"].ToString() != "")
                _CessionCost = double.Parse(objDr["NewCessionCost"].ToString());
            if (objDr.Table.Columns["NewCessionPreviousPaidValue"] != null && objDr["NewCessionPreviousPaidValue"].ToString() != "")
                _OldReservationPreviousPaidValue = double.Parse(objDr["NewCessionPreviousPaidValue"].ToString());
            if (objDr.Table.Columns["NewCessionDate"] != null && objDr["NewCessionDate"].ToString() != "")
                _CessionDate = DateTime.Parse(objDr["NewCessionDate"].ToString());
            if (objDr.Table.Columns["TempPaymentValue"] != null && objDr["TempPaymentValue"].ToString() != "")
                _TempPayment = double.Parse(objDr["TempPaymentValue"].ToString());
            if (objDr.Table.Columns["RemainingValue"] != null && objDr["RemainingValue"].ToString() != "")
                _RemainingValue = double.Parse(objDr["RemainingValue"].ToString());
            if (objDr.Table.Columns["TotalInstallmentPaidValue"] != null && objDr["TotalInstallmentPaidValue"].ToString() != "")
                _TotalInstallmentPaidValue = double.Parse(objDr["TotalInstallmentPaidValue"].ToString());
            _TotalPaidValue = _TotalInstallmentPaidValue + _TempPayment;
            _ModelName = objDr["ModelName"].ToString();

            if (objDr.Table.Columns["MinInstallmentDueDate"] != null && objDr["MinInstallmentDueDate"].ToString() != "")
                _InstallmentStartDate = DateTime.Parse(objDr["MinInstallmentDueDate"].ToString()).ToString("yyyy-MM-dd");
            if (objDr.Table.Columns["MaxInstallmentDueDate"] != null && objDr["MaxInstallmentDueDate"].ToString() != "")
                _InstallmentEndDate = DateTime.Parse(objDr["MaxInstallmentDueDate"].ToString()).ToString("yyyy-MM-dd");
            if (objDr.Table.Columns["ReservationTransactionType"] != null && objDr["ReservationTransactionType"].ToString() != "")
                _LastTransactionType = int.Parse(objDr["ReservationTransactionType"].ToString());
            if (objDr.Table.Columns["ReservationTransactionValue"] != null &&
                objDr["ReservationTransactionValue"].ToString() != "")
                _LastTransactionValue = int.Parse(objDr["ReservationTransactionValue"].ToString());
            if (objDr.Table.Columns["ReservationStatusGLTransaction"] != null && objDr["ReservationStatusGLTransaction"].ToString() != "")
                _LastGLTransaction = int.Parse(objDr["ReservationStatusGLTransaction"].ToString());
            if (objDr.Table.Columns["DirectCancelationCost"] != null && objDr["DirectCancelationCost"].ToString() != "")
                _DirectCancelationCost = double.Parse(objDr["DirectCancelationCost"].ToString());

            if (objDr.Table.Columns["InsuranceOutPaymentValue"] != null && objDr["InsuranceOutPaymentValue"].ToString() != "")
                _InsuranceOutPayment = double.Parse(objDr["InsuranceOutPaymentValue"].ToString());
            if (objDr.Table.Columns["InsuranceInPaymentValue"] != null && objDr["InsuranceInPaymentValue"].ToString() != "")
                _InsuranceInPayment = double.Parse(objDr["InsuranceInPaymentValue"].ToString());
            if (objDr.Table.Columns["AdministrativePaymentValue"] != null && objDr["AdministrativePaymentValue"].ToString() != "")
                _AdministrativePaymentValue = double.Parse(objDr["AdministrativePaymentValue"].ToString());
            if (objDr["CustomerID"].ToString() != "")
                _CustomerID = int.Parse(objDr["CustomerID"].ToString());
            if (objDr.Table.Columns["TotalUtilityValue"] != null && objDr["TotalUtilityValue"].ToString() != "")
                _UtilityValue = double.Parse(objDr["TotalUtilityValue"].ToString());
            if (objDr.Table.Columns["CanceledReservation"] != null &&
                objDr["CanceledReservation"].ToString() != "")
                _IsCanceled = true;
            else
                _IsCanceled = false;
            _ResubmissionTypeID = 0;
            if (objDr.Table.Columns["ResubmissionType"] != null && objDr["ResubmissionType"].ToString() != "")
                _ResubmissionTypeID = int.Parse(objDr["ResubmissionType"].ToString());
            if (objDr.Table.Columns["ReservationOrder"] != null)
            {
                int.TryParse(objDr["ReservationOrder"].ToString(), out _Order);

            }
            if (objDr.Table.Columns["NativeUnitPrice"] != null && objDr["NativeUnitPrice"].ToString() != "")
                _NativeUnitPrice = double.Parse(objDr["NativeUnitPrice"].ToString());
            if (objDr.Table.Columns["ReservationOpenTime"] != null)
                DateTime.TryParse(objDr["ReservationOpenTime"].ToString(), out _OpenTime);
            if (objDr.Table.Columns["ReservationStopedPermanently"] != null)
                bool.TryParse(objDr["ReservationStopedPermanently"].ToString(), out _StopedPermanently);
            if (objDr.Table.Columns["ReservationStopReason"] != null)
                _StopReason = objDr["ReservationStopReason"].ToString();
            _IsStopped = false;
            if (_StopedPermanently || _OpenTime.Date > DateTime.Now.Date)
                _IsStopped = true;

        
            //void SetData(DataRow objDr)
            //{

                if (objDr.Table.Columns["ReservationTenancyID"] != null)
                    int.TryParse(objDr["ReservationTenancyID"].ToString(), out _TenancyID);
            _IsTenancy = _TenancyID > 0;
                if (objDr.Table.Columns["ReservationTenancyStartDate"] != null)
                    DateTime.TryParse(objDr["ReservationTenancyStartDate"].ToString(), out _TenancyStartDate);

                if (objDr.Table.Columns["ReservationTenancyEndDate"] != null)
                    DateTime.TryParse(objDr["ReservationTenancyEndDate"].ToString(), out _TenancyEndDate);

                if (objDr.Table.Columns["ReservationTenancyStartValue"] != null)
                    double.TryParse(objDr["ReservationTenancyStartValue"].ToString(), out _TenancyStartValue);

                if (objDr.Table.Columns["ReservationTenancyFrequncyPeriod"] != null)
                    int.TryParse(objDr["ReservationTenancyFrequncyPeriod"].ToString(), out _TenancyFrequncyPeriod);

                if (objDr.Table.Columns["ReservationTenancyChangeFrequencyPeriod"] != null)
                    int.TryParse(objDr["ReservationTenancyChangeFrequencyPeriod"].ToString(), out _TenancyChangeFrequencyPeriod);

                if (objDr.Table.Columns["ReservationTenancyChangePerc"] != null)
                    double.TryParse(objDr["ReservationTenancyChangePerc"].ToString(), out _TenancyChangePerc);

            if (objDr.Table.Columns["ReservationTenancyIsAutomaticCancelation"] != null)
                bool.TryParse(objDr["ReservationTenancyIsAutomaticCancelation"].ToString(), out _IsAutomaticCancelation);


            if (objDr.Table.Columns["BrandID"] != null)
            {
                int.TryParse(objDr["BrandID"].ToString(), out _Brand);
            }
            


        }
        public void StopReservation()
        {
            double dblOpenTime = _OpenTime.ToOADate() - 2;
            int intIsPermanent = _StopedPermanently ? 1 : 0;

            string strSql = "update CRMReservation set ReservationStopReason='" + _StopReason + "'," +
                " ReservationOpenTime=" + dblOpenTime +
                ", ReservationStopedPermanently=" + intIsPermanent;
            if (_ID != 0)
                strSql += " where ReservationID =  " + _ID;
            else if (_IDs != null && _IDs != "")
                strSql += " where ReservationID in ( " + _IDs + ")";
            else
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable GetInstallment()
        {
            ReservationInstallmentDb objDb = new ReservationInstallmentDb();
            objDb.ReservationID = _ID;
            DataTable dtTemp = objDb.Search();
            return dtTemp;
        }
        public void JoinContribution()
        {
            string[] arrStr;
            if (_WorkerContributionTable == null)
                return;
            arrStr = new string[_WorkerContributionTable.Rows.Count + 1];
            arrStr[0] = " DELETE FROM CRMReservationWorkerContribution where ReservationID=" + _ID;
            int intIndex = 1;
            int intFinished;         
            foreach (DataRow objDr in _WorkerContributionTable.Rows)
            {
                intFinished = bool.Parse(objDr["Finished"].ToString()) ? 1 : 0;
                arrStr[intIndex] = "INSERT INTO CRMReservationWorkerContribution " +
                                    " (ReservationID, WorkerID, ContributionPerc, ContributionValue, PaidValue, Finished)" +
                                    " values(" + _ID + "," + objDr["WorkerID"].ToString() + "," + objDr["ContributionPerc"].ToString() +
                                     "," + objDr["ContributionValue"].ToString() + "," + objDr["PaidValue"].ToString() + "," + intFinished + ")";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void JoinUnit()
        {
            string[] arrStr;
             
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return ;
            string strUnitIDs = SysUtility.GetStringArr(_UnitTable, "UnitID", 5000)[0];

            UnitDb objUnitDb = new UnitDb();
            if (_Parent == 0)
            {
                objUnitDb = new UnitDb();

                objUnitDb.Reservation = _ID;
                objUnitDb.UnitIDs = strUnitIDs;
                objUnitDb.EditCurrentReservation();
            }
            else
            {
                ReservationUnitDb objReservationUnitDb = new ReservationUnitDb();
                objReservationUnitDb.ReservationID = _Parent;
                objReservationUnitDb.ChildReservation = ID;
                objReservationUnitDb.UnitIDs = strUnitIDs;
                objReservationUnitDb.EditChildReservation();

            }
            arrStr = new string[_UnitTable.Rows.Count + 1];
            arrStr[0] = " DELETE FROM CRMReservationUnit where ReservationID=" + _ID;
            int intIndex = 1;
            ReservationUnitDb objTemp;
            foreach (DataRow objDr in _UnitTable.Rows)
            {
                objTemp = new ReservationUnitDb(objDr);
                objTemp.ReservationID = ID;
                arrStr[intIndex] = objTemp.AddStr;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        DataTable GetCustomer()
        {
            CustomerDb objCustomerDb = new CustomerDb();
            string strSql = objCustomerDb.SearchStr + " inner join CRMReservationCustomer on  " +
                " CRMReservationCustomer.CustomerID = CRMCustomer.CustomerID  " +
                " where ReservationID = " + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Customer");
        }

        public static void SetReservationCach()
        {
            //_CachReservationTable = null;
            _CachInstallmentTable = null;
            _CachWorkerTable = null;
            _CachInstallmentMulctTable = null;
            _CachMulctPaymentTable = null;
            _CachAttachmentTable = null;
            _CachDiscountTable = null;
            _CachBonusTable = null;
            _CachTempPaymentTable = null;
            _CachAdministrativePaymentTable = null;
            _CachCustomerTable = null;
            _CachInstallmentPaymentTable = null;
            _CachInstallmentDiscountTable = null;
            _CachUnitTable = null;
            _CachCellTable = null;
            _CachUtilityTable = null;
            _CachUtilityPaymentTable = null;
            _CachCheckTable = null;
            _CachOldReservationTable = null;
            _CachInsurancePaymentTable = null;
            CustomerDb.CacheCustomerContactTable = null;
            


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
                arrDr = _ReservationTransactionTable.Select("GeneratedID=" + objTRansactionDb.GeneratedID.ToString());
                if (arrDr.Length > 0)
                {
                    arrStr[intIndex] = "declare @TransactionID numeric(18,0) ;";
                    arrStr[intIndex] += "set @TransactionID= (select Max(TransactionID) as MaxID from GLTransaction ) ";
                    arrStr[intIndex] += " insert into CRMReservationStatusTransaction (ReservationID, ReservationTransactionType"+
                        ", ReservationTransactionValue, ReservationStatusGLTransaction) "+
                        "  SELECT     "+ arrDr[0]["IDs"].ToString() +" as ReservationID,GLTransactionElement_1.ElementSyetemType"+
                        ", GLTransactionElement_1.ElementValue ,@TransactionID as TransactionID "+
                        " FROM  (SELECT     ElementTransaction, MAX(ElementID) AS MaxElementID "+
                        " FROM      dbo.GLTransactionElement "+
                        " where ElementTransaction = @TransactionID "+
                        " GROUP BY ElementTransaction) AS MaxTable INNER JOIN "+
                        " dbo.GLTransactionElement AS GLTransactionElement_1 ON MaxTable.ElementTransaction = GLTransactionElement_1.ElementTransaction AND  "+
                        " MaxTable.MaxElementID = GLTransactionElement_1.ElementID ";
                }
                lstTransArray.Add(arrStr);

            }
            foreach (string[] arrTemp in lstTransArray)
            {
                SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrTemp);
            }
            return true;
        }
        public bool InsertMulctTransaction()
        {
            if (_TransactionTable == null || _TransactionTable.Rows.Count == 0)
                return false;
            DataRow[] arrDr;
            string[] arrStr;
            int intReservationID = 0;
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
                    intReservationID = objTransactionElementDb.ReservationID;
                    intIndex++;
                }
                arrDr = _ReservationTransactionTable.Select("GeneratedID=" + objTRansactionDb.GeneratedID.ToString());
                if (arrDr.Length > 0)
                {
                    arrStr[intIndex] = "declare @TransactionID numeric(18,0) ;";
                    arrStr[intIndex] += "set @TransactionID= (select Max(TransactionID) as MaxID from GLTransaction ) ";
                    arrStr[intIndex] += " update CRMInstallmentMulct set MulctGLTransaction = @TransactionID " +
                        " where MulctID =  " + arrDr[0]["IDs"];
                }
                lstTransArray.Add(arrStr);

            }
            foreach (string[] arrTemp in lstTransArray)
            {
                SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrTemp);
            }
            return true;
        }
        public bool InsertDiscountTransaction()
        {
            if (_TransactionTable == null || _TransactionTable.Rows.Count == 0)
                return false;
            DataRow[] arrDr;
            string[] arrStr;
            TransactionDb objTRansactionDb;
            TransactionElementDb objTransactionElementDb;
            int intIndex = 0;
            int intReservationID = 0;
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
                arrDr = _ReservationTransactionTable.Select("GeneratedID=" + objTRansactionDb.GeneratedID.ToString());
                if (arrDr.Length > 0)
                {
                    arrStr[intIndex] = "declare @TransactionID numeric(18,0) ;";
                    arrStr[intIndex] += "set @TransactionID= (select Max(TransactionID) as MaxID from GLTransaction ) ";
                    arrStr[intIndex] += " update CRMReservationInstallmentDiscount set DiscountGLTransaction = @TransactionID " +
                        " where DiscountID =  " + arrDr[0]["IDs"];
                }
                lstTransArray.Add(arrStr);

            }
            foreach (string[] arrTemp in lstTransArray)
            {
                SysData.SharpVisionBaseDb.ExecuteNonQueryInTransaction(arrTemp);
            }
            return true;
        }
        public void SetTenantedUnitFree()
        {
            string strSql = @"update        dbo.CRMUnit set CurrentReservation = 0
FROM dbo.CRMReservationTenancy INNER JOIN
                         dbo.CRMUnit ON dbo.CRMReservationTenancy.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN
                         dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                         dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID
WHERE(dbo.CRMReservationTenancy.ReservationTenancyEndDate < GETDATE()) 
AND(dbo.CRMReservationTenancy.ReservationID IN(" + _ReservationIDs + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
