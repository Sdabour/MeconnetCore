using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerDb : ApplicantDb
    {
        #region Private Data
        protected int _ApplicantWorkerID;
        protected string _Code;
        protected string _ArchiveNo;
        protected int _JobCategoryEstimation;
        string _JobCategoryEstimationName;

      
        protected int _MedicalStatusID;
        protected int _ComputerQualificationID;
        protected string _ComputerQualificationStr;
        protected string _InsuranceNo;
        protected DateTime _InsuranceDate;
        protected string _InsuranceJobTitle;
        protected double _InsuranceSalary;
        protected double _InsuranceSalaryChange;        
        protected string _AccountBankNo;
        protected int _AccountBankID;
        protected string _AccountBankName;
        protected int _StatusID;
        protected int _AccountBankNoSearch;
        protected bool  _AccountBankNoOrderSearch;
        UserDb _UserDb;
        protected DateTime _StartDate;
        DateTime _StartExperienceDate;

        public DateTime StartExperienceDate
        {
            get { return _StartExperienceDate; }
            set { _StartExperienceDate = value; }
        }
        bool _StartExperienceDateDecided;

        public bool StartExperienceDateDecided
        {
            get { return _StartExperienceDateDecided; }
            set { _StartExperienceDateDecided = value; }
        }

        bool _StartDateStatus;
        bool _HasNonDiscountedCreditVacation;//NonDiscountedCreditApplicant
        protected double _StartSalary;
        protected int _StartSalaryCurrency;
        protected double _StartSalaryDetails;
        protected double _CurrentSalary;
        protected double _ApplicantVirtualSalary;
        protected int _User;
        protected DataTable _SubSectorTable;
        protected DataTable _CostCenterTable;
        protected DataTable _MotivationCostCenterTable;
        protected bool _IsReviewed;
        protected bool _IsReviewedSearch=true;
        protected bool _IsFellowShip;
        protected double _FellowShipCredit;
        protected DateTime _EndDate;
        protected int _LastAttendanceStatement;
        protected int _LastFinancialStatement;
        protected int _IsFellowShipSearch;
        protected bool _HasTimeShit;
        protected bool _HasAttendanceStatement;
        protected bool _HasTimeShitSearch;
        protected bool _HasAttendanceStatementSearch;
        protected bool _HasMotivation;
        protected bool _IsPartTime;
        protected bool _IsDiscountDelay;
        protected byte _IsPartTimeStatus;
        protected bool _IsEnded;
        protected int _CostCenter;
       // string _CostCenterName;

      

        protected int _VacationDayCount;
        protected int _AttachmentCount;
        double _DetailsValue;

        double _LastMotivationValue;
        
        public double LastMotivationValue
        {
            set { _LastMotivationValue = value; }
            get { return _LastMotivationValue; }

        }
        double _LastMotivationAddedBonusValue;

        public double LastMotivationAddedBonusValue
        {
            set { _LastMotivationAddedBonusValue = value; }
            get { return _LastMotivationAddedBonusValue; }

        }
        DateTime _LastMotivationDate;

        double _TotalDetailsForMotivation;

        public double TotalDetailsForMotivation
        {
            get { return _TotalDetailsForMotivation; }
            set { _TotalDetailsForMotivation = value; }
        }
        double _PreviousBaseSalary;
        public double PreviousBaseSalary
        {
            get
            {
                return _PreviousBaseSalary;
            }

        }

        double _PreviousDetailsValue;
        public double PreviousDetailsValue
        {
            get
            {
                return _PreviousDetailsValue;
            }

        }
        DataTable _AccountTable;

        public DataTable AccountTable
        {
            get { return _AccountTable; }
            set { _AccountTable = value; }
        }
        protected double _BankIntNo;
        protected int _MotivationType;
        protected int _AvoidNoSalaryVacation;/*
                                              * 0 dont care
                                              * 1 avoid those whom have vacation in the period
                                              */


        protected bool _HasGrantedVacation;
        protected DateTime _LastGrantedVacationDate;
        DateTime _LastGrantedStartValid;

        public DateTime LastGrantedStartValid
        {
            get { return _LastGrantedStartValid; }
            set { _LastGrantedStartValid = value; }
        }
        int _SectorID;
        string _SectorNameA;
        int _BranchID;
        string _BranchNameA;
        int _SubSectorID;
        int _JobNatureID;
        int _JobNatureOrderValue;
        string _JobNatureTypeNameA;
     //   int _CostCenterID;
        string _CostCenterNameA;
        int _MotivationCostCenterID;


        string _MotivationCostCenterName;

       
        #region Private Data For Search
        protected string _CodeLike;
        protected string _CodesSearch;
        protected string _AccountBankNoLike;
        protected int _StartDateStatusSearch;
        protected DateTime _StartDateFromSearch;
        protected DateTime _StartDateToSearch;

        protected int _StartDateStatusWithApplicantStatusSearch;
        protected DateTime _StartDateFromWithApplicantStatusSearch;
        protected DateTime _StartDateToWithApplicantStatusSearch;

        protected bool _EndDateStatusSearch;
        protected DateTime _EndDateFromSearch;
        protected DateTime _EndDateToSearch;
        protected bool _InsuranceDateStatusSearch;
        protected DateTime _InsuranceDateFromSearch;
        protected DateTime _InsuranceDateToSearch;
        int _UserIDSearch;
        protected int _JobIDSearch;
        protected int _SectorIDSearch;
        protected int _CellIDSearch;
        protected int _StoreIDSearch;
        protected int _BranchIDSearch;
        protected int _SubSectorIDSearch;
        protected int _StatusIDSearch;
        protected bool _IncludeRecentlyFinishWorkSearch;
         static int _MonthSearch;
         int _JobDesc;
         bool _IncludePreviousSalalry;

         public bool IncludePreviousSalalry
         {
             get { return _IncludePreviousSalalry; }
             set { _IncludePreviousSalalry = value; 
             }
         }

         public int JobDesc
         {
             get { return _JobDesc; }
             set { _JobDesc = value; }
         }
         int _MonthBufferSearch;
        protected int _ReligionIDSearch;
        protected int _GrantSearch;
        protected DateTime _GrantDateFromSearch;
        protected DateTime _GrantDateToSearch;
        protected bool _InsuranceStatusSearch;
        protected int _intInsuranceStatusSearch;
        protected string _InsuranceValueSearch;
        protected static string _ApplicantIDs;
        protected string _IDs;
        protected string _ApplicantSearchIDs;
        protected static DataTable _CacheSubSectorTable;
        protected static DataTable _CacheCurrentSubSectorTable;
        protected static DataTable _CacheApplicantTable;
        protected static DataTable _CacheCostCenterTable;
        protected static DataTable _CacheMotivationCostCenterTable;
        protected int _SJobTypeIDSearch;
        protected int _SJobTitleTypeIDSearch;
        protected int _SJobNatureTypeIDSearch;
        static bool _TopSearch;
        protected string _SectorIDs;
        protected int _SectorFamilyID;
        protected int _AttendanceStatementID;
        protected String _AttendanceStatementIDs;
        protected String _JobCategoryEstimationIDs;
        protected byte _AttendanceStatementApplicantStatus;
        protected DateTime _AttendanceStatementEndDate;
        protected DateTime _AttendanceStatementStartDate;
        protected DateTime _GlobalStatementEndDate;
        protected DateTime _GlobalStatementStartDate;
        protected byte _AttendanceStatementConsider;//0 not Considered
                                                                                 // 1 only non statemented
                                                                                 //2 only statemented
        protected bool _AttendanceStatementIsSum;
        protected bool _AttendanceStatementIsSumStatusSearch;
        protected int _GlobalStatementID;
        protected byte _GlobalStatementConsider;//0 not Considered
          
                                                              // 1 only non statemented
                                                                       //2 only statemented
        protected byte _StatementReviewedStatus;//0 all
                                                                          //1 not reviewd
                                                                          //2 reviewed
        protected byte _CostCenterCondiered;
        protected byte _PartTimeUnit;
        protected double _PartTimeUnitValue;
        protected byte _EstimationStatementStatusSearch;
        protected int _EstimationStatementIDSearch;
        protected int _MotivationStatementCostCenterIDSearch;
        protected byte _MotivationStatementStatusSearch;
        protected int _MotivationStatementIDSearch;
        string _JobIDs;
        bool _AttendanceStatementStatusSearch;
        bool _TimeSheetStatusSearch;
        bool _ApplicantWithloanSearch;
        protected bool _InsDateStatusSearch;
        protected DateTime _InsDateFromSearch;
        protected DateTime _InsDateToSearch;
        int _GetFromViews = 0;
        byte _HasMotivationSearch = 0;
        int _WorkingStatus;/*
                            * 0 dont care
                            * 1 working
                            * 2 not working
                            * 3 vacation without salalry
                            */
        int _IsHasLastFinantial;
        int _ApplicantStatusInAttendanceStatement;/*
                                                 * 0 All
                                                 * 1 Work
                                                 * 2 not Work
                                                 */
        bool _ShortApplicantOnly;

        public bool ShortApplicantOnly
        {
            get { return _ShortApplicantOnly; }
            set { _ShortApplicantOnly = value; }
        }
        int _LastMotivationStatementID;

        public int LastMotivationStatementID
        {
            get { return _LastMotivationStatementID; }
            set { _LastMotivationStatementID = value; }
        }
        #endregion
        #region Cach data
     
        #endregion
        #endregion
        #region Constructors
        public ApplicantWorkerDb()
        {
            _UserDb = new UserDb();
            _IDTypeDb = new IDTypeInstantDb();
        }
        public ApplicantWorkerDb(int intID)
        {
            _UserDb = new UserDb();
            _ID = intID;
            if (_ID == 0)
                return;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                SetData(dtTemp.Rows[0]);
                base.SetData(dtTemp.Rows[0]);
            }
        }
        public ApplicantWorkerDb(DataRow objDR)
            : base(objDR)
        {
            try
            {
                SetData(objDR);
            }
            catch (Exception Ex)
            {

            }
        }
        public ApplicantWorkerDb(string strCode)
        {
            _UserDb = new UserDb();
            _CodeLike = strCode;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
                base.SetData(objDR);
            }
        }
        #endregion
        #region Public Properties
        public int ApplicantWorkerID
        {
            set { _ApplicantWorkerID = value; }
            get { return _ApplicantWorkerID; }
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
        public string ArchiveNo
        {
            set
            {
                _ArchiveNo = value;
            }
            get
            {
                return _ArchiveNo;
            }

        }
        public int JobCategoryEstimation { set { _JobCategoryEstimation = value; } get { return _JobCategoryEstimation; } }
        public string JobCategoryEstimationName
        {
            get { return _JobCategoryEstimationName; }
            set { _JobCategoryEstimationName = value; }
        }
        public byte PartTimeUnit
        {
            set
            {
                _PartTimeUnit = value;
            }
            get
            {
                return _PartTimeUnit;
            }
        }        
        public double PartTimeUnitValue
        {
            set
            {
                _PartTimeUnitValue = value;
            }
            get
            {
                return _PartTimeUnitValue;
            }
        }
        public bool StartDateStatus
        {
            set { _StartDateStatus = value; }
            get { return _StartDateStatus; }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }

        }
        public DateTime InsuranceDate
        {
            set
            {
                _InsuranceDate = value;
            }
            get
            {
                return _InsuranceDate;
            }

        }
        public bool IsReviewed
        {
            set
            {
                _IsReviewed = value;
            }
            get
            {
                return _IsReviewed;
            }

        }
        public bool IsFellowShip
        {
            set
            {
                _IsFellowShip = value;
            }
            get
            {
                return _IsFellowShip;
            }

        }
        double _FellowShipDiscountHistory;
        public double FellowShipDiscountHistory
        {
            set
            {
                _FellowShipDiscountHistory = value;
            }
            get
            {
                return _FellowShipDiscountHistory;
            }

        }
        public double FellowShipCredit
        {
            set
            {
                 _FellowShipCredit = value;
            }
            get
            {
                return _FellowShipCredit;
            }

        }
        public bool HasTimeShit
        {
            set
            {
                _HasTimeShit = value;
            }
            get
            {
                return _HasTimeShit;
            }

        }
        public bool HasAttendanceStatement
        {
            set
            {
                _HasAttendanceStatement = value;
            }
            get
            {
                return _HasAttendanceStatement;
            }

        }
        public bool HasTimeShitSearch
        {
            set
            {
                _HasTimeShitSearch = value;
            }           

        }
        public bool HasAttendanceStatementSearch
        {
            set
            {
                _HasAttendanceStatementSearch = value;
            }           
        }
        public bool HasMotivation
        {
            set
            {
                _HasMotivation = value;
            }
            get
            {
                return _HasMotivation;
            }

        }
        public int MotivationType
        {
            set
            {
                _MotivationType = value;
            }
            get
            {
                return _MotivationType;
            }

        }
        public bool IsReviewedSearch
        {
            set
            {
                _IsReviewedSearch = value;
            }
            get
            {
                return _IsReviewedSearch;
            }

        }
        public double StartSalary
        {
            set
            {
                _StartSalary = value;
            }
            get
            {
                return _StartSalary;
            }

        }
        public double StartSalaryDetails
        {
            set
            {
                _StartSalaryDetails = value;
            }
            get
            {
                return _StartSalaryDetails;
            }

        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        public bool IsEnded
        {
            get
            {
                return _IsEnded;
            }
        }
        public int LastAttendanceStatement
        {
            set
            {
                _LastAttendanceStatement = value;
            }
            get
            {
                return _LastAttendanceStatement;
            }
        }
        public int LastFinancialStatement
        {
            set
            {
                _LastFinancialStatement = value;
            }
            get
            {
                return _LastFinancialStatement;
            }
        }
        public int StartSalaryCurrency
        {
            set
            {
                _StartSalaryCurrency = value;
            }
            get
            {
                return _StartSalaryCurrency;
            }

        }
        public int VacationDayCount
        {
            set
            {
                _VacationDayCount = value;
            }
            get
            {
                return _VacationDayCount;
            }

        }
        public double CurrentSalary
        {
            set
            {
                _CurrentSalary = value;
            }
            get
            {
                return _CurrentSalary;
            }

        }
        public double ApplicantVirtualSalary
        {
            set
            {
                _ApplicantVirtualSalary = value;
            }
            get
            {
                return _ApplicantVirtualSalary;
            }

        }
        public double DetailsValue
        {
            set
            {
                _DetailsValue = value;
            }
            get
            {
                return _DetailsValue;
            }
        }
        public int User
        {
            set
            {
                _User = value;
            }
            get
            {
                return _User;
            }

        }
        public int MedicalStatusID
        {
            set { _MedicalStatusID = value; }
            get { return _MedicalStatusID; }
        }
        public int ComputerQualificationID
        {
            set { _ComputerQualificationID = value; }
            get { return _ComputerQualificationID; }
        }
        public string ComputerQualificationStr
        {
            set { _ComputerQualificationStr = value; }
            get { return _ComputerQualificationStr; }
        }
        public string InsuranceNo
        {
            set { _InsuranceNo = value; }
            get { return _InsuranceNo; }
        }
        public string InsuranceJobTitle
        {
            set { _InsuranceJobTitle = value; }
            get { return _InsuranceJobTitle; }
        }
        public double InsuranceSalary
        {
            set { _InsuranceSalary = value; }
            get { return _InsuranceSalary; }
        }
        public double InsuranceSalaryChange
        {
            set { _InsuranceSalaryChange = value; }
            get { return _InsuranceSalaryChange; }
        }
        public string AccountBankNo
        {
            set { _AccountBankNo = value; }
            get { return _AccountBankNo; }
        }
        string _AccountBankBranchCode;

        public string AccountBankBranchCode
        {
            get { return _AccountBankBranchCode; }
            set { _AccountBankBranchCode = value; }
        }
        string _AccountTypeCode;

        public string AccountTypeCode
        {
            get { return _AccountTypeCode; }
            set { _AccountTypeCode = value; }
        }
        public int AccountBankID
        {
            set
            {
                _AccountBankID = value;
            }
            get
            {
                return _AccountBankID;
            }
        }
        public string AccountBankName
        {
            get
            {
                return _AccountBankName;
            }
        }
        public bool IsPartTime
        {
            set
            {
                _IsPartTime = value;
            }
            get
            {
                return _IsPartTime;
            }
        }
        public bool IsDiscountDelay
        {
            set
            {
                _IsDiscountDelay = value;
            }
            get
            {
                return _IsDiscountDelay;
            }
        }
        public byte IsPartTimeStatus
        {
            set
            {
                _IsPartTimeStatus = value;
            }
            get
            {
                return _IsPartTimeStatus; 
            }
        }
        public DataTable SubSectorTable
        {
            set
            {
                _SubSectorTable = value;
            }
        }
        public DataTable CostCenterTable
        {
            set
            {
                _CostCenterTable = value;
            }
        }
        public DataTable MotivationCostCenterTable
        {
            set
            {
                _MotivationCostCenterTable = value;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public string ApplicantSearchIDs
        {
            set
            {
                _ApplicantSearchIDs = value;
            }
        }
        public int CostCenter
        {
            get
            {
                return _CostCenter;
            }
            set
            {
                _CostCenter = value;
            }
        }
        public string CostCenterName
        {
            get { return _CostCenterNameA; }
            set { _CostCenterNameA = value; }
        }
        public string MotivationCostCenterName
        {
            get { return _MotivationCostCenterName; }
            set { _MotivationCostCenterName = value; }
        }
        public int MotivationCostCenterID
        {
            get { return _MotivationCostCenterID; }
            set { _MotivationCostCenterID = value; }
        }
        public int AttachmentCount
        {
            get
            {
                return _AttachmentCount;
            }
        }
        public int UserIDSearch
        {
            set
            {
                _UserIDSearch = value;
            }
        }
        public bool AttendanceStatementIsSum
        {
            set
            {
                _AttendanceStatementIsSum = value;
            }
        }
        public bool AttendanceStatementIsSumStatusSearch
        {
            set
            {
                _AttendanceStatementIsSumStatusSearch = value;
            }
        }
        public int StatusID
        {
            set
            {
                _StatusID = value;
            }
            get
            {
                return _StatusID;
            }

        }
        public double BankIntNo
        {
            set
            {
                _BankIntNo= value;
            }
            get
            {
                return _BankIntNo;
            }

        }
        
        public static string ApplicantIDs
        {

            set
            {
                _ApplicantIDs = value;
            }
            get
            {
                return _ApplicantIDs;
            }
        }
        static string _SubSectorApplicantIDs;
        public static string SubSectorApplicantIDs
        {
            set
            {
                _SubSectorApplicantIDs = value;
            }
            get
            {
                return _SubSectorApplicantIDs;
            }
        }
        public static DataTable CacheSubSectorTable
        {
            set
            {
                _CacheSubSectorTable = value;
            }
            get
            {
                if (_CacheSubSectorTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantWorkerSubSectorDb objDb = new ApplicantWorkerSubSectorDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CacheSubSectorTable = objDb.Search();
                }
                return _CacheSubSectorTable;
            }
        }
        public static DataTable CacheCurrentSubSectorTable
        {
            set
            {
                _CacheCurrentSubSectorTable = value;
            }
            get
            {
                if (_CacheCurrentSubSectorTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantWorkerCurrentSubSectorDb objDb = new ApplicantWorkerCurrentSubSectorDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CacheCurrentSubSectorTable = objDb.Search();
                }
                return _CacheCurrentSubSectorTable;
            }
        }
        public static void SetCacheCurrentSubSectorTable()
        {
            ApplicantWorkerCurrentSubSectorDb objDb = new ApplicantWorkerCurrentSubSectorDb();
            objDb.ApplicantIDs = _SubSectorApplicantIDs;
            _CacheCurrentSubSectorTable = objDb.Search();
        }
        public static DataTable CacheCostCenterTable
        {
            set
            {
                _CacheCostCenterTable = value;
            }
            get
            {
                if (_CacheCostCenterTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantWorkerCostCenterDb objDb = new ApplicantWorkerCostCenterDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CacheCostCenterTable = objDb.Search();
                }
                return _CacheCostCenterTable;
            }
        }
        public static DataTable CacheMotivationCostCenterTable
        {
            set
            {
                _CacheMotivationCostCenterTable = value;
            }
            get
            {
                if (_CacheMotivationCostCenterTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantWorkerMotivationCostCenterDb objDb = new ApplicantWorkerMotivationCostCenterDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CacheMotivationCostCenterTable = objDb.Search();
                }
                return _CacheMotivationCostCenterTable;
            }
        }
        public bool HasGrantedVacation
        {
            set
            {
                _HasGrantedVacation = value;
            }
            get
            {
                return _HasGrantedVacation;
            }
        }
        public DateTime LastGrantedVacationDate
        {
            set
            {
                _LastGrantedVacationDate = value;
            }
            get
            {
                return _LastGrantedVacationDate;
            }
        }
        public int SectorID
        {
            get
            {
                return _SectorID;
            }
        }
        public string SectorNameA
        {
            get
            {
                return _SectorNameA;
            }
        }
        public int BranchID
        {
            get
            {
                return _BranchID;
            }
        }
        public string BranchNameA
        {
            get
            {
                return _BranchNameA;
            }
        }
        public int SubSectorID
        {
            get
            {
                return _SubSectorID;
            }
        }
        public int JobNatureID
        {
            get
            {
                return _JobNatureID;
            }
        }
        public string JobNatureTypeNameA
        {
            get
            {
                return _JobNatureTypeNameA;
                    
            }
        }
        public int JobNatureOrderValue
        {
            get
            {
                return _JobNatureOrderValue;
            }
        }
        bool _HasAddedBonus;

        public bool HasAddedBonus
        {
            get { return _HasAddedBonus; }
            set { _HasAddedBonus = value; }
        }
        double _AddedBonusValue;

        public double AddedBonusValue
        {
            get { return _AddedBonusValue; }
            set { _AddedBonusValue = value; }
        }
        int _FellowShipSalaryOrMotivation;

        public int FellowShipSalaryOrMotivation
        {
            get { return _FellowShipSalaryOrMotivation; }
            set { _FellowShipSalaryOrMotivation = value; }
        }

        #region"Public Properties Search"
        public string CodeLike
        {
            set { _CodeLike = value; }
        }
        public string CodesSearch
        {
            set { _CodesSearch = value; }
        }
        public string AccountBankNoLike
        {
            set { _AccountBankNoLike = value; }
        }
        public int StartDateStatusSearch
        {
            set { _StartDateStatusSearch = value; }
        }
        public DateTime StartDateFromSearch
        {
            set { _StartDateFromSearch = value; }
        }
        public DateTime StartDateToSearch
        {
            set { _StartDateToSearch = value; }
        }
        public int StartDateStatusWithApplicantStatusSearch
        {
            set { _StartDateStatusWithApplicantStatusSearch = value; }
        }
        public DateTime StartDateFromWithApplicantStatusSearch
        {
            set { _StartDateFromWithApplicantStatusSearch = value; }
        }
        public DateTime StartDateToWithApplicantStatusSearch
        {
            set { _StartDateToWithApplicantStatusSearch = value; }
        }
        public bool EndDateStatusSearch
        {
            set { _EndDateStatusSearch = value; }
        }
        public DateTime EndDateFromSearch
        {
            set { _EndDateFromSearch = value; }
        }
        public DateTime EndDateToSearch
        {
            set { _EndDateToSearch = value; }
        }
        public bool InsuranceDateStatusSearch
        {
            set { _InsuranceDateStatusSearch = value; }
        }
        public DateTime InsuranceDateFromSearch
        {
            set { _InsuranceDateFromSearch = value; }
        }
        public DateTime InsuranceDateToSearch
        {
            set { _InsuranceDateToSearch = value; }
        }
        public int JobIDSearch
        {

            set { _JobIDSearch = value; }
        }
        public int SubSectorIDSearch
        {

            set { _SubSectorIDSearch = value; }
        }
        public int BranchIDSearch
        {

            set { _BranchIDSearch = value; }
        }
        public int CellIDSearch
        {

            set { _CellIDSearch = value; }
        }
        public int StoreIDSearch
        {

            set { _StoreIDSearch = value; }
        }
        public int StatusIDSearch
        {

            set { _StatusIDSearch = value; }
        }
        public bool IncludeRecentlyFinishWorkSearch
        {

            set { _IncludeRecentlyFinishWorkSearch = value; }
        }        
        public  int MonthSearch
        {

            set { _MonthSearch = value; }
        }
        public int GrantSearch
        {
            set { _GrantSearch = value; }
        }
        public DateTime GrantDateFromSearch
        {
            set { _GrantDateFromSearch = value; }
        }
        public DateTime GrantDateToSearch
        {
            set { _GrantDateToSearch = value; }
        }
        public int AccountBankNoSearch
        {

            set { _AccountBankNoSearch = value; }
        }
        public bool AccountBankNoOrderSearch
        {

            set { _AccountBankNoOrderSearch = value; }
        }
        public int ReligionIDSearch
        {

            set { _ReligionIDSearch = value; }
        }
        public int SectorIDSearch
        {

            set { _SectorIDSearch = value; }
        }
        public int SJobTypeIDSearch
        {
            set { _SJobTypeIDSearch = value; }
        }
        public int SJobTitleTypeIDSearch
        {
            set { _SJobTitleTypeIDSearch = value; }
        }
        public int SJobNatureTypeIDSearch
        {
            set { _SJobNatureTypeIDSearch = value; }
        }
        public static bool TopSearch
        {
            set
            {
                _TopSearch = value;
            }
        }
        public bool AttendanceStatementStatusSearch
        {
            set
            {
                _AttendanceStatementStatusSearch = value;
            }
        }
        public bool TimeSheetStatusSearch
        {
            set
            {
                _TimeSheetStatusSearch = value;
            }
        }
        public string SectorIDs
        {
            set
            {
                _SectorIDs = value;
            }
        }
        string _FlatSectorIDs;
        public string FlatSectorIDs
        {
            set
            {
                _FlatSectorIDs = value;
            }
        }
        public int SectoFamilyID
        {
            set
            {
                _SectorFamilyID = value;
            }
        }
        public int AttendanceStatementID
        {
            set
            {
                _AttendanceStatementID = value;
            }
        }
        public string AttendanceStatementIDs
        {
            set
            {
                _AttendanceStatementIDs = value;
            }
        }
        public byte AttendanceStatementApplicantStatus
        {
            set
            {
                _AttendanceStatementApplicantStatus = value;
            }
        }
        public int ApplicantStatusInAttendanceStatement
        {
            set
            {
                _ApplicantStatusInAttendanceStatement = value;
            }
        }
        public DateTime AttendanceStatementEndDate
        {
            set
            {
                _AttendanceStatementEndDate = value;
            }
        }
        public DateTime AttendanceStatementStartDate
        {
            set
            {
                _AttendanceStatementStartDate = value;
            }
        }
        public DateTime GlobalStatementEndDate
        {
            set
            {
                _GlobalStatementEndDate = value;
            }
        }
        public DateTime GlobalStatementStartDate
        {
            set
            {
                _GlobalStatementStartDate = value;
            }
        }
        public byte AttendanceStatementConsider
        {
            set
            {
                _AttendanceStatementConsider = value;
            }
        }
        public int GlobalStatementID
        {
            set
            {
                _GlobalStatementID = value;
            }
        }
        public byte CostCenterCondiered
        {
            set
            {
                _CostCenterCondiered = value;
            }
        }
        public int EstimationStatementIDSearch
        {
            set
            {
                _EstimationStatementIDSearch = value;
            }
        }
        public byte EstimationStatementStatusSearch
        {
            set
            {
                _EstimationStatementStatusSearch = value;
            }
        }
        public int MotivationStatementIDSearch
        {
            set
            {
                _MotivationStatementIDSearch = value;
            }
        }
        public int MotivationStatementCostCenterIDSearch
        {
            set
            {
                _MotivationStatementCostCenterIDSearch = value;
            }
        }
        public byte MotivationStatementStatusSearch
        {
            set
            {
                _MotivationStatementStatusSearch = value;
            }
        }
        public byte GlobalStatementConsider
        {
            set
            {
                _GlobalStatementConsider = value;
            }
        }
        public string JobIDs
        {
            set
            {
                _JobIDs = value;
            }
        }
        public bool InsuranceStatusSearch
        {

            set { _InsuranceStatusSearch = value; }
        }
        public int intInsuranceStatusSearch
        {
            set { _intInsuranceStatusSearch = value; }
        }
        int _FellowShipeStatusSearch;
        public int FellowShipeStatusSearch
        {
            set { _FellowShipeStatusSearch = value; }
        }
        int _intStartSalaryStatusSearch;
        public int intStartSalaryStatusSearch
        {

            set { _intStartSalaryStatusSearch = value; }
        }
        public string InsuranceValueSearch
        {
            set { _InsuranceValueSearch = value; }
        }
        public byte StatementReviewedStatus
        {
            set
            {
                _StatementReviewedStatus = value;
            }
        }
        public bool ApplicantWithloanSearch
        {
            set
            {
                _ApplicantWithloanSearch = value;
            }
        }
        public bool InsDateStatusSearch
        {
            set
            {
                _InsDateStatusSearch = value;
            }
            get
            {
                return _InsDateStatusSearch;
            }

        }
        public DateTime InsDateFromSearch
        {
            set
            {
                _InsDateFromSearch = value;
            }
            get
            {
                return _InsDateFromSearch;
            }

        }
        public DateTime InsDateToSearch
        {
            set
            {
                _InsDateToSearch = value;
            }
            get
            {
                return _InsDateToSearch;
            }

        }
        public int GetFromViews
        {
            set
            {
                _GetFromViews = value;
            }
        }
        public byte HasMotivationSearch
        {
            set
            {
                _HasMotivationSearch = value;
            }            
        }
        public int WorkingStatus
        {
            set
            {
                _WorkingStatus = value;
            }
        }
        public int AvoidNoSalaryVacation
        {
            set
            {
                _AvoidNoSalaryVacation = value;
            }
        }
        public int IsHasLastFinantial
        {
            set
            {
                _IsHasLastFinantial = value;
            }
        }
        #endregion
        public bool HasNonDiscountedCreditVacation
        {
            get
            {
                return _HasNonDiscountedCreditVacation;
            }
        }
        public string ApplicantWorkerSubSector
        {
            get
            {
                string Returned = "SELECT     dbo.HRApplicantWorkerCurrentSubSector.ApplicantID MaxSubSectorApplicant, dbo.HRSector.SectorID as ApplicantSectorID"+
                    ", dbo.HRSector.SectorNameA as ApplicantSectorNameA, dbo.HRBranch.BranchID as ApplicantBranchID, dbo.HRBranch.BranchNameA as ApplicantBranchNameA,"+ 
                        " dbo.HRSubSector.SubSectorID as ApplicantSubSectorID "+
                        ",dbo.HRJobNatureType.JobNatureID AS SectorJobNatureID, dbo.HRJobNatureType.JobNatureNameA AS SectorJobNatureNameA "+
                        ",dbo.HRJobCategory.OrderValue as SectorJobCategoryOrder "+
                        " FROM         dbo.HRBranch INNER JOIN "+
                       " dbo.HRSubSectorBranch ON dbo.HRBranch.BranchID = dbo.HRSubSectorBranch.BranchID RIGHT OUTER JOIN "+
                       " dbo.HRApplicantWorkerCurrentSubSector  INNER JOIN "+
                       " left outer join dbo.HRJobNatureType  "+
                       "  on dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID " +
                       " dbo.HRSector INNER JOIN "+
                      " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID "+ 
                 
                      " INNER JOIN "+
                      " (SELECT     ApplicantID, MAX(SubSectorID) AS MaxSubSector "+
                      " FROM      dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 "+
                      " GROUP BY ApplicantID) AS MaxSubSector ON dbo.HRSubSector.SubSectorID = MaxSubSector.MaxSubSector ON  "+
                      " dbo.HRApplicantWorkerCurrentSubSector.ApplicantID = MaxSubSector.ApplicantID ON dbo.HRSubSectorBranch.SubSectorID = dbo.HRSubSector.SubSectorID "+
                      "  left outer join  dbo.HRJobCategory "+
                      " ON dbo.HRJobNatureType.JobCategory = dbo.HRJobCategory.JobCategoryID ";
                
                Returned = "SELECT     dbo.HRApplicantWorkerCurrentSubSector.ApplicantID AS MaxSubSectorApplicant, dbo.HRSector.SectorID AS ApplicantSectorID,  "+
                      " dbo.HRSector.SectorNameA AS ApplicantSectorNameA, dbo.HRBranch.BranchID AS ApplicantBranchID, dbo.HRBranch.BranchNameA AS ApplicantBranchNameA,  "+
                      " dbo.HRSubSector.SubSectorID AS ApplicantSubSectorID, dbo.HRJobNatureType.JobNatureID AS SectorJobNatureID,  "+
                      " dbo.HRJobNatureType.JobNatureNameA AS SectorJobNatureNameA "+
                        ",dbo.HRJobCategory.OrderValue as SectorJobCategoryOrder,JobCategoryEstimationTable.* " +
                        "  "+
                      " FROM         dbo.HRBranch INNER JOIN "+
                      " dbo.HRSubSectorBranch ON dbo.HRBranch.BranchID = dbo.HRSubSectorBranch.BranchID RIGHT OUTER JOIN "+
                      " dbo.HRJobNatureType RIGHT OUTER JOIN "+
                      " dbo.HRSector INNER JOIN "+
                      " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID INNER JOIN "+
                          " (SELECT     ApplicantID, MAX(SubSectorID) AS MaxSubSector "+
                             " FROM         dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 "+
                             " GROUP BY ApplicantID) AS MaxSubSector ON dbo.HRSubSector.SubSectorID = MaxSubSector.MaxSubSector INNER JOIN "+
                      " dbo.HRApplicantWorkerCurrentSubSector ON MaxSubSector.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID ON  "+
                      " dbo.HRJobNatureType.JobNatureID = dbo.HRApplicantWorkerCurrentSubSector.JobNatureID "+
                      " ON dbo.HRSubSectorBranch.SubSectorID = dbo.HRSubSector.SubSectorID "+
                       "  left outer join  dbo.HRJobCategory " +
                      " ON dbo.HRJobNatureType.JobCategory = dbo.HRJobCategory.JobCategoryID "+
                      " lEFT OUTER JOIN (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable ON HRApplicantWorkerCurrentSubSector.JobCategoryEstimation = JobCategoryEstimationTable.JobCategoryEstimationID ";
                Returned += " where 1=1  ";
                if(_SectorIDs  != null && _SectorIDs!= "")
                     Returned += " and HRSector.SectorID in (" + _SectorIDs + ") ";
                if (_SectorFamilyID != 0)
                    Returned += "  and HRSector.SectorFamilyID = "+_SectorFamilyID;
                return Returned;
            }
        }
        public static string SubSectorSearchStr
        {
            get
            {
                string Returned = " SELECT     ApplicantID, MAX(ApplicantSubSectorID) AS MaxApplicantSubSectorID "+
                     " FROM         dbo.HRApplicantWorkerCurrentSubSector "+
                     " GROUP BY ApplicantID ";

                Returned = " SELECT      HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID ,HRApplicantWorkerCurrentSubSector.ApplicantID as MaxApplicantSubSectorID1,  HRApplicantWorkerCurrentSubSector.SubOrdinationID," +
                      " HRApplicantWorkerCurrentSubSector.Description, HRApplicantWorkerCurrentSubSector.FromDate, HRApplicantWorkerCurrentSubSector.ToDate," +
                      " JobTypeTable.*, SubSectorTable.*,JobTitleTypeTable.* ,JobNatureTypeTable.* " +
                      " ,HRApplicantWorkerCurrentSubSector.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                      " FROM ("+ Returned +") as MaxSubSectorTable "+
                      " inner join HRApplicantWorkerCurrentSubSector "+
                      " on  MaxSubSectorTable.ApplicantID = HRApplicantWorkerCurrentSubSector.ApplicantID " +
                      "  and  MaxSubSectorTable.MaxApplicantSubSectorID = HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID " +
                      " INNER JOIN " +
                      "(" + SubSectorDb.SearchStr + ") as SubSectorTable ON HRApplicantWorkerCurrentSubSector.SubSectorID = SubSectorTable.SubSectorID " +
                      " lEFT OUTER JOIN (" + JobTypeDb.SearchStr + ") as JobTypeTable ON HRApplicantWorkerCurrentSubSector.JobID = JobTypeTable.JobID " +
                      " lEFT OUTER JOIN (" + JobTitleTypeDb.SearchStr + ") as JobTitleTypeTable ON HRApplicantWorkerCurrentSubSector.JobTitleID = JobTitleTypeTable.JobTitleID " +
                      " lEFT OUTER JOIN (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable ON HRApplicantWorkerCurrentSubSector.JobNatureID = JobNatureTypeTable.JobNatureID " +
                      " lEFT OUTER JOIN (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable ON HRApplicantWorkerCurrentSubSector.JobCategoryEstimation = JobCategoryEstimationTable.JobCategoryEstimationID "+
                       "" ;
                return Returned;
                
            }
        }
        public string ApplicantWorkerAttendance
        {
            get
            {
                string Returned = "";
              
                    Returned = "SELECT  dbo.HRApplicantWorker.ApplicantID AttendanceApplicant " +
                      " FROM  dbo.HRAttendanceStatement INNER JOIN " +
                      " dbo.HRApplicantWorkerAttendanceStatement ON  " +
                      " dbo.HRAttendanceStatement.StatementID = dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment INNER JOIN " +
                      " dbo.HRApplicantWorker ON dbo.HRApplicantWorkerAttendanceStatement.Applicant = dbo.HRApplicantWorker.ApplicantID AND " +
                      " dbo.HRAttendanceStatement.StatementTO >= dbo.HRApplicantWorker.ApplicantStartDate " +
                      " WHERE     (dbo.HRAttendanceStatement.StatementID =" + _AttendanceStatementID + ")";

                   
                    if (_AttendanceStatementIsSumStatusSearch == true)
                    {
                        if (_AttendanceStatementIsSum)
                            Returned += " and AtendanceStatementIsSum =1 ";
                        else
                            Returned += " and AtendanceStatementIsSum =0 ";
                    }
                 
                return Returned;
            }
        }
        public string NoSalaryVacation
        {
            get
            {
                string Returned = "SELECT  VacationApplicantID as Applicant " +
                              " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                     " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                     " Cross join   dbo.HRAttendanceStatement   " +
                     " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                     "  AND ( dbo.HRAttendanceStatement.StatementFrom > VacationFrom) AND (dbo.HRAttendanceStatement.StatementTo < VacationTo) ";
          
                  Returned+=   " and dbo.HRAttendanceStatement.StatementID = " + _AttendanceStatementID;
                return Returned;
            }
        }
       
        public static string LastGrantedVacationStr
        {
            get
            {
                string Returned = "SELECT  Applicant VacationGrantApplicant, MAX(VacationDateTo) AS LastGrantedDate,max(VacationDateFrom) MaxGrantedDateFrom " +
                      " FROM   dbo.HRApplicantWorkerVacationGrant "+
                      " inner join HRApplicantWorker  "+
                      " on HRApplicantWorkerVacationGrant.Applicant = HRApplicantWorker.ApplicantID  " +
                      " and HRApplicantWorkerVacationGrant.VacationDateTo >    dbo.HRApplicantWorker.ApplicantStartDate  " +
                      " GROUP BY Applicant ";
                return Returned;
            }
        }
        public  string ShortSearchStr
        {
            get
            {
                string strFlatSector = @"WITH SectorTable(SectorID, SectorNameA, SectorParentID, SLevel) AS (SELECT        SectorID, SectorNameA, SectorParentID, 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector
                                                                                                                                                           WHERE        (SectorID IN (" + _FlatSectorIDs + @"))
                                                                                                                                                           UNION ALL
                                                                                                                                                           SELECT        HRSector_1.SectorID, HRSector_1.SectorNameA, HRSector_1.SectorParentID, SectorTable_2.SLevel + 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector AS HRSector_1 INNER JOIN
                                                                                                                                                                                    SectorTable AS SectorTable_2 ON HRSector_1.SectorParentID = SectorTable_2.SectorID) ";
//    string strTemp =@"SELECT        TOP (100) PERCENT SectorTable_1.SectorID, SectorTable_1.SectorNameA, SectorTable_1.SectorParentID, SectorTable_1.SLevel, HRSector_3.SectorNameA AS SectorName1, HRSector_4.SectorNameA AS SectorName2
//     FROM            SectorTable AS SectorTable_1 INNER JOIN
//                              dbo.HRSector AS HRSector_2 ON SectorTable_1.SectorID = HRSector_2.SectorID INNER JOIN
//                              dbo.HRSector AS HRSector_3 ON HRSector_2.SectorParentID = HRSector_3.SectorID INNER JOIN
//                              dbo.HRSector AS HRSector_4 ON HRSector_3.SectorParentID = HRSector_4.SectorID
//     ORDER BY SectorTable_1.SLevel";
//                strFlatSector = @"SELECT DISTINCT dbo.HRApplicantWorkerCurrentSubSector.ApplicantID
//FROM            dbo.HRApplicantWorkerCurrentSubSector INNER JOIN
//                         dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID 
//INNER JOIN
//                         (" + strFlatSector + @") as SectorTable ON dbo.HRSubSector.SectorID = SectorTable.SectorID";
                string strMaxSubSector = "";
                string strCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantCostCenterID, dbo.GLCostCenter.CostCenterNameA AS ApplicantCostCenterName "+
                        " FROM         dbo.GLCostCenter INNER JOIN "+
                        " (SELECT     dbo.HRApplicantWorkerCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter "+
                         " FROM         dbo.HRApplicantWorkerCostCenter INNER JOIN "+
                         " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerCostCenter.CostCenter = GLCostCenter_1.CostCenterID "+
                         " GROUP BY dbo.HRApplicantWorkerCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";
                string strAccountBank = "SELECT  BankID AS ApplicantBankID, BankNameA AS ApplicantBankName " +
       " FROM         dbo.GLBank ";
                string strMotivationCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantMotivationCostCenterID, "+
                      " dbo.GLCostCenter.CostCenterNameA AS ApplicantMotivationCostCenterName "+
                      " FROM         dbo.GLCostCenter INNER JOIN "+
                      " (SELECT     dbo.HRApplicantWorkerMotivationCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter "+
                      " FROM         dbo.HRApplicantWorkerMotivationCostCenter INNER JOIN "+
                      " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerMotivationCostCenter.CostCenter = GLCostCenter_1.CostCenterID "+
                      " GROUP BY dbo.HRApplicantWorkerMotivationCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";
                string Returned = "";
                if (_FlatSectorIDs != null && _FlatSectorIDs != "")
                    Returned += strFlatSector + " ";
                Returned += " SELECT dbo.HRApplicant.ApplicantID, dbo.HRApplicant.ApplicantFirstName" +
                    ", dbo.HRApplicant.ApplicantFamousName, dbo.HRApplicant.ApplicantShortName,dbo.HRApplicant.ApplicantBirthDate,  " +
                    " dbo.HRApplicantWorker.ApplicantCode,dbo.HRApplicantWorker.ApplicantCurrentSalary" +
                    ",dbo.HRApplicantWorker.ApplicantStartDate,ApplicantStartExperienceDate,dbo.HRApplicantWorker.ApplicantEndDate" +
                    ",ApplicantStatusID, 1 AS ShortApplicant,dbo.HRApplicantWorker.LastFinancialStatement " +
                    ", HRApplicant.ApplicantIDValue as IDValue,HRApplicant.ApplicantIDType" +
                    ",dbo.HRApplicantWorker.ApplicantAccountBankNo,dbo.HRApplicantWorker.ApplicantAccountBankID,ApplicantBankTable.* " +
                      ",ApplicantAccountBankBranchCode,ApplicantAccountBankAccountTypeCode " +
                    // ",ApplicantAddedBonusValue  " +
                    ",dbo.HRApplicantWorker.FellowShipSalaryOrMotivation  as ApplicantFellowShipSalaryOrMotivation " +
                   ",dbo.HRApplicantWorker.IsFellowShip, dbo.HRApplicantWorker.FellowShipCredit" +
                   ",dbo.HRApplicantWorker.HasAttendanceStatement" +
                    ",SubSectorTable.SubSectorDesc as ApplicantSubSectorDesc " +
                    ",SubSectorTable.SectorID as ApplicantSectorID " +
                    ",SubSectorTable.SectorNameA as ApplicantSectorNameA " +
                    ",SubSectorTable.BranchID as ApplicantBranchID " +
                     ",SubSectorTable.BranchNameA as ApplicantBranchNameA" +
                     ",SubSectorTable.JobNatureID as SectorJobNatureID" +
                     ",SubSectorTable.JobNatureNameA as SectorJobNatureNameA " +
                     ",SubSectorTable.OrderValue1 as SectorJobCategoryOrder " +
                     ",SubSectorTable.JobCategoryEstimationID as ApplicantJobEstimationID  " +
                     ",SubSectorTable.JobCategoryEstimationNameA as ApplicantJobEstimaionName " +
                    ",case when CostCenterTable.ApplicantCostCenterID is null then SubSectorTable.CostCenterID else  CostCenterTable.ApplicantCostCenterID end as ApplicantCostCenterID " +
                    " ,case when CostCenterTable.ApplicantCostCenterName is null then SubSectorTable.CostCenterNameA else  CostCenterTable.ApplicantCostCenterName end as ApplicantCostCenterName " +
                    ",case when MotivationCostCenterTable.ApplicantMotivationCostCenterID is null then SubSectorTable.MotivationCostCenterID else MotivationCostCenterTable.ApplicantMotivationCostCenterID end as ApplicantMotivationCostCenterID " +
                    ", case when MotivationCostCenterTable.ApplicantMotivationCostCenterName  is null then SubSectorTable.MotivationCostCenterName  else MotivationCostCenterTable.ApplicantMotivationCostCenterName end as ApplicantMotivationCostCenterName " +
                   ",  dbo.HRApplicantWorkerPartTime.PartTimeUnit, dbo.HRApplicantWorkerPartTime.PartTimeUnitValue " +
                   ",ApplicantAddedBonusValue    " +
                   ",ImageTable.* "+
                    " FROM  dbo.HRApplicant INNER JOIN " +
                   " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID " +
                   " left outer join (" + strCostCenter + ") as CostCenterTable " +
                   " on HRApplicant.ApplicantID = CostCenterTable.Applicant " +
                   " left outer join (" + strMotivationCostCenter + ") as MotivationCostCenterTable  " +
                   " on HRApplicant.ApplicantID = MotivationCostCenterTable.Applicant " +
                   " left outer join (" + SubSectorSearchStr + ") as SubSectorTable " +
                   " on  HRApplicant.ApplicantID = SubSectorTable.MaxApplicantSubSectorID1 " +
                   " left outer join (" + strAccountBank + ") as ApplicantBankTable " +
                 " on HRApplicantWorker.ApplicantAccountBankID = ApplicantBankTable.ApplicantBankID " +
                 " left outer join  " +
                " dbo.HRApplicantWorkerPartTime ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerPartTime.Applicant " +
               " left outer join (" + AddedBonusSearchStr + ") AddBonusTable " +
                   " on  dbo.HRApplicant.ApplicantID =  AddBonusTable.AddedBonusApplicantID ";
                Returned += " left outer join (" + new ApplicantImageDb().SearchStr + @") ImageTable 
                     on   HRApplicantWorker.ApplicantID = ImageTable.ImageApplicantID ";
                //"  INNER JOIN " +
                //"  dbo.VHRSelectedApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.VHRSelectedApplicant.ApplicantID";
                //" inner join TTempApplicantError on HRApplicant.ApplicantID = TTempApplicantError.ApplicantID ";
                if (_FlatSectorIDs != null && _FlatSectorIDs != "")
                    Returned += " inner join SectorTable " +
                        " on SubSectorTable.SectorID = SectorTable.SectorID ";
                return Returned;
            }
        }
        public  string ShortSearchStr2
        {
            get
            {
                if (_FlatSectorIDs == null)
                    _FlatSectorIDs = "";

             //   if (!SysData.SharpVisionBaseDb.OneConnection)
                    return ShortSearchStr;
                string strFlatSector = @"WITH SectorTable(SectorID, SectorNameA, SectorParentID, SLevel) AS (SELECT        SectorID, SectorNameA, SectorParentID, 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector
                                                                                                                                                           WHERE        (SectorID IN ("+_FlatSectorIDs +@"))
                                                                                                                                                           UNION ALL
                                                                                                                                                           SELECT        HRSector_1.SectorID, HRSector_1.SectorNameA, HRSector_1.SectorParentID, SectorTable_2.SLevel + 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector AS HRSector_1 INNER JOIN
                                                                                                                                                                                    SectorTable AS SectorTable_2 ON HRSector_1.SectorParentID = SectorTable_2.SectorID)
    SELECT        TOP (100) PERCENT SectorTable_1.SectorID, SectorTable_1.SectorNameA, SectorTable_1.SectorParentID, SectorTable_1.SLevel, HRSector_3.SectorNameA AS SectorName1, HRSector_4.SectorNameA AS SectorName2
     FROM            SectorTable AS SectorTable_1 INNER JOIN
                              dbo.HRSector AS HRSector_2 ON SectorTable_1.SectorID = HRSector_2.SectorID INNER JOIN
                              dbo.HRSector AS HRSector_3 ON HRSector_2.SectorParentID = HRSector_3.SectorID INNER JOIN
                              dbo.HRSector AS HRSector_4 ON HRSector_3.SectorParentID = HRSector_4.SectorID
     ORDER BY SectorTable_1.SLevel";
                strFlatSector = @"SELECT DISTINCT dbo.HRApplicantWorkerCurrentSubSector.ApplicantID
FROM            dbo.HRApplicantWorkerCurrentSubSector INNER JOIN
                         dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                         ("+ strFlatSector+ @") as SectorTable ON dbo.HRSubSector.SectorID = SectorTable.SectorID";
                string strMaxSubSector = "";
                string strCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantCostCenterID, dbo.GLCostCenter.CostCenterNameA AS ApplicantCostCenterName " +
                        " FROM         dbo.GLCostCenter INNER JOIN " +
                        " (SELECT     dbo.HRApplicantWorkerCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter " +
                         " FROM         dbo.HRApplicantWorkerCostCenter INNER JOIN " +
                         " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerCostCenter.CostCenter = GLCostCenter_1.CostCenterID " +
                         " GROUP BY dbo.HRApplicantWorkerCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";
                string strAccountBank = "SELECT  BankID AS ApplicantBankID, BankNameA AS ApplicantBankName " +
       " FROM         dbo.GLBank ";
                string strMotivationCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantMotivationCostCenterID, " +
                      " dbo.GLCostCenter.CostCenterNameA AS ApplicantMotivationCostCenterName " +
                      " FROM         dbo.GLCostCenter INNER JOIN " +
                      " (SELECT     dbo.HRApplicantWorkerMotivationCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter " +
                      " FROM         dbo.HRApplicantWorkerMotivationCostCenter INNER JOIN " +
                      " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerMotivationCostCenter.CostCenter = GLCostCenter_1.CostCenterID " +
                      " GROUP BY dbo.HRApplicantWorkerMotivationCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";
                string Returned = "SELECT dbo.HRApplicant.ApplicantID, dbo.HRApplicant.ApplicantFirstName" +
                    ", dbo.HRApplicant.ApplicantFamousName, dbo.HRApplicant.ApplicantShortName,dbo.HRApplicant.ApplicantBirthDate,  " +
                    " dbo.HRApplicantWorker.ApplicantCode,dbo.HRApplicantWorker.ApplicantCurrentSalary" +
                    ",dbo.HRApplicantWorker.ApplicantStartDate,ApplicantStartExperienceDate,dbo.HRApplicantWorker.ApplicantEndDate" +
                    ",ApplicantStatusID, 1 AS ShortApplicant,dbo.HRApplicantWorker.LastFinancialStatement " +
                    ",dbo.HRApplicantWorker.ApplicantAccountBankNo"+
                    ",ApplicantAccountBankBranchCode,ApplicantAccountBankAccountTypeCode "+
                    ",dbo.HRApplicantWorker.ApplicantAccountBankID,ApplicantAddedBonusValue  " +
                    ",dbo.HRApplicantWorker.FellowShipSalaryOrMotivation  as ApplicantFellowShipSalaryOrMotivation " +
                    " FROM  dbo.HRApplicant INNER JOIN " +
                   " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID "+
                   " left outer join ("+ AddedBonusSearchStr +") AddBonusTable "+
                   " on  dbo.HRApplicant.ApplicantID =  AddBonusTable.AddedBonusApplicantID "+
                   "  INNER JOIN "+
                   "  dbo.VHRSelectedApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.VHRSelectedApplicant.ApplicantID";
                if (_FlatSectorIDs != null && _FlatSectorIDs != "")
                    Returned += " inner join ("+ strFlatSector +") as FlatSectorTbale "+
                        " on HRApplicantWorker.ApplicantID = FlatSectorTbale.ApplicantID ";
                return Returned;
            }
        }
        public string PreviousSalarySearchStr
        {
            get
            {
                string strDetailsValue = "SELECT   OrginStatement, SUM(CASE WHEN DetailType IN (2, 3) THEN DetailRecomendedValue ELSE 0 END) AS TotalRecomendedValue " +
             " FROM      dbo.HRApplicantWorkerStatementSalaryDetails " +
              " GROUP BY OrginStatement";//only 2 and 3  Types 
                string strPreviousSalary = "SELECT        derivedtbl_2.Applicant, dbo.HRApplicantWorkerStatement.BaseSalary AS PreviousBaseSalary" +
                ", case when DetailsValueTable.TotalRecomendedValue is null then 0 else DetailsValueTable.TotalRecomendedValue end  AS PreviousDetailsAmount, 1 as ShortPreviousSalalry " +
                   " FROM            dbo.HRApplicantWorkerStatement INNER JOIN " +
                   " (SELECT        Applicant, MAX(OriginStatementID) AS LastStatment " +
                            " FROM            (SELECT        TOP (100) PERCENT HRApplicantWorkerStatement_1.Applicant, dbo.GLOriginStatement.OriginStatementID, dbo.HRGlobalStatement.StatementDate " +
                            " FROM            dbo.GLOriginStatement INNER JOIN " +
                             " dbo.HRApplicantWorkerStatement AS HRApplicantWorkerStatement_1 ON dbo.GLOriginStatement.OriginStatementID = HRApplicantWorkerStatement_1.OriginStatementID INNER JOIN " +
                             " dbo.HRGlobalStatement ON HRApplicantWorkerStatement_1.GlobalStatment = dbo.HRGlobalStatement.StatementID " +

            " WHERE        (dbo.HRGlobalStatement.StatementDate < CONVERT(datetime, CONVERT(varchar(4), YEAR(GETDATE())) + '-01-01') )) AS derivedtbl_1 " +
            " GROUP BY Applicant) AS derivedtbl_2 ON dbo.HRApplicantWorkerStatement.OriginStatementID = derivedtbl_2.LastStatment " +
               " left outer join (" + strDetailsValue + ") as DetailsValueTable " +
                             " on  dbo.HRApplicantWorkerStatement.OriginStatementID =DetailsValueTable.OrginStatement  ";
                return strPreviousSalary;
            }
        }

        public string SearchStr 
        {
            get
            {
                string strMaxMotivation = " SELECT        Applicant, MAX(ApplicantMotivationStatementID) AS MAXMotivationID " +
                                          " FROM            dbo.HRApplicantWorkerMotivationStatement " +
                                          " INNER JOIN dbo.HRMotivationStatement "+
                                          " ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID "+
                                          " WHERE(dbo.HRMotivationStatement.MotivationIsAddedBonus = 0) "+
                                          " GROUP BY Applicant ";
                strMaxMotivation = " SELECT      dbo.HRApplicantWorkerMotivationStatement.Applicant, dbo.HRApplicantWorkerMotivationStatement.MotivationValue  " +
                                     " FROM      (" + strMaxMotivation + ") as LastMotivationTable  " +
                                     " inner join     dbo.HRApplicantWorkerMotivationStatement " +
                                     " on LastMotivationTable.MAXMotivationID = dbo.HRApplicantWorkerMotivationStatement .ApplicantMotivationStatementID  ";

                string strMaxAddedBonus = " SELECT        Applicant, MAX(ApplicantMotivationStatementID) AS MAXMotivationAddedBonusID " +
                                        " FROM            dbo.HRApplicantWorkerMotivationStatement " +
                                        " INNER JOIN dbo.HRMotivationStatement " +
                                        " ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID " +
                                        " WHERE(dbo.HRMotivationStatement.MotivationIsAddedBonus = 1) " +
                                        " GROUP BY Applicant ";
                strMaxAddedBonus = " SELECT  dbo.HRApplicantWorkerMotivationStatement.Applicant, dbo.HRApplicantWorkerMotivationStatement.MotivationValue as LstMotivationAddedBonusValue" +
                                     " FROM  (" + strMaxAddedBonus + ") as LastMotivationTable  " +
                                     " inner join     dbo.HRApplicantWorkerMotivationStatement " +
                                     " on LastMotivationTable.MAXMotivationAddedBonusID = dbo.HRApplicantWorkerMotivationStatement .ApplicantMotivationStatementID  ";

                string strAccountBank = "SELECT  BankID AS ApplicantBankID, BankNameA AS ApplicantBankName " +
                       " FROM         dbo.GLBank ";
                string strCostCenter = "SELECT     dbo.HRApplicantWorkerCostCenter.Applicant, MAX(dbo.GLCostCenter.CostCenterID) AS MaxCostCenter " +
                     " FROM         dbo.HRApplicantWorkerCostCenter INNER JOIN " +
                      " dbo.HRCostCenter ON dbo.HRApplicantWorkerCostCenter.CostCenter = dbo.HRCostCenter.CostCenter INNER JOIN " +
                      " dbo.GLCostCenter ON dbo.HRCostCenter.CostCenter = dbo.GLCostCenter.CostCenterID " +
                      " GROUP BY dbo.HRApplicantWorkerCostCenter.Applicant ";
                string strAttachmentCount = "SELECT  dbo.HRApplicantAttachment.ApplicantID, COUNT(dbo.HRApplicantAttachment.ApplicantAttachmentID) AS AttachmentCount " +
                     " FROM         dbo.HRApplicantAttachment INNER JOIN " +
                     " dbo.COMMONAttachmentType ON dbo.HRApplicantAttachment.AttachmentTypeID = dbo.COMMONAttachmentType.AttachmentTypeID " +
                      " GROUP BY dbo.HRApplicantAttachment.ApplicantID ";
                string strNonDiscountedCredit = "SELECT  VacationApplicantID NonDiscountedCreditApplicant " +
                     " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                     " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                     " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                     "  AND (GETDATE() >= VacationFrom) AND (GETDATE() <= VacationTo) ";





      
            


                string strSlalryDetails = "SELECT     ApplicantID, SUM(DetailValue) AS TotalDetails " +
                    //  " , (SELECT isnull(SUM(DetailValue),0)  FROM  dbo.HRApplicantSalaryDetails sd where sd.detailtypeid in (3,2) and sd.applicantid = sd2.applicantid and sd.dis is null ) as TotalDetailsForMotivation " +
                ",SUM(case when DetailTypeID in (2,3) then DetailValue else 0 end) AS TotalDetailsForMotivation " +
                  " FROM         dbo.HRApplicantSalaryDetails as sd2 " +
                " Where  (sd2.Dis IS NULL) " +
                " GROUP BY ApplicantID ";


                strCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantCostCenterID, dbo.GLCostCenter.CostCenterNameA AS ApplicantCostCenterName " +
                    " FROM         dbo.GLCostCenter INNER JOIN " +
                    " (SELECT     dbo.HRApplicantWorkerCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter " +
                     " FROM         dbo.HRApplicantWorkerCostCenter INNER JOIN " +
                     " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerCostCenter.CostCenter = GLCostCenter_1.CostCenterID " +
                     " GROUP BY dbo.HRApplicantWorkerCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";

                string strMotivationCostCenter = "SELECT     derivedtbl_1.Applicant, dbo.GLCostCenter.CostCenterID AS ApplicantMotivationCostCenterID, " +
                      " dbo.GLCostCenter.CostCenterNameA AS ApplicantMotivationCostCenterName " +
                      " FROM         dbo.GLCostCenter INNER JOIN " +
                      " (SELECT     dbo.HRApplicantWorkerMotivationCostCenter.Applicant, MAX(GLCostCenter_1.CostCenterID) AS MaxCostCenter " +
                      " FROM         dbo.HRApplicantWorkerMotivationCostCenter INNER JOIN " +
                      " dbo.GLCostCenter AS GLCostCenter_1 ON dbo.HRApplicantWorkerMotivationCostCenter.CostCenter = GLCostCenter_1.CostCenterID " +
                      " GROUP BY dbo.HRApplicantWorkerMotivationCostCenter.Applicant) AS derivedtbl_1 ON dbo.GLCostCenter.CostCenterID = derivedtbl_1.MaxCostCenter ";






            

                string Returned = " SELECT  ";
                if (_TopSearch == true)
                {
                    Returned = Returned + " Top 200  ";
                }
                Returned = Returned + " case when DetailsTable.TotalDetails is null then 0 else DetailsTable.TotalDetails end as TotalDetailsValue, DetailsTable.TotalDetailsForMotivation ,HRApplicant.ApplicantID,HRApplicantWorker.ApplicantID as ApplicantWorkerID , HRApplicant.ApplicantFirstName, HRApplicant.ApplicantFamousName, HRApplicant.ApplicantNameComp,HRApplicantWorker.IsReviewed,HRApplicantWorker.ApplicantInsuranceDate, " +
                " HRApplicantWorker.ApplicantEndDate,HRApplicantWorker.ArchiveNo,HRApplicant.ApplicantDesc,HRApplicant.ApplicantMidleName, HRApplicant.ApplicantLastName, HRApplicant.ApplicantSexTypeID, HRApplicant.ApplicantIDValue as IDValue, " +
                " HRApplicant.ApplicantIDType, HRApplicant.ApplicantBirthDate, HRApplicant.ApplicantAddress, HRApplicant.ApplicantBirthPlace, HRApplicant.ApplicantUserName,HRApplicant.ApplicantPassword," +
                " HRApplicant.ApplicantRegionID, HRApplicant.ApplicantMaritalStatus, HRApplicant.ApplicantMiltaryStatus, HRApplicant.ApplicantCommonService,HRApplicant.ApplicantIDIssueDate, " +
                " HRApplicant.ApplicantReligionID, HRApplicant.ApplicantNationalityID,HRApplicant.ApplicantCV, HRApplicantWorker.ApplicantCode, HRApplicantWorker.ApplicantStartExperienceDate, HRApplicantWorker.ApplicantStartDate, " +
                " HRApplicantWorker.ApplicantStartSalary,HRApplicantWorker.ApplicantStartSalaryDetails, HRApplicantWorker.ApplicantStartSalaryCurrency, HRApplicantWorker.ApplicantCurrentSalary,HRApplicantWorker.HasTimeShit,HRApplicantWorker.HasAttendanceStatement,HRApplicantWorker.FellowShipCredit,HRApplicantWorker.FellowShipDiscountHistory, " +
                " HRApplicantWorker.ApplicantUser, HRApplicantWorker.ApplicantInsuranceNo,HRApplicantWorker.ApplicantAccountBankNo,HRApplicantWorker.ApplicantStatusID, HRApplicantWorker.ApplicantComputerQualificationID,HRApplicantWorker.IsDiscountDelay, " +
                " HRApplicantWorker.LastFinancialStatement ,HRApplicantWorker.LastAttendanceStatement,HRApplicantWorker.ApplicantMedicalStatus,HRApplicantWorker.IsFellowShip" +
                ",dbo.HRApplicantWorker.FellowShipSalaryOrMotivation  as ApplicantFellowShipSalaryOrMotivation " +
                ", IDTable.*,RegionTable.*,ComputerQualificationTable.*,HRApplicantWorkerPartTime.PartTimeUnit,HRApplicant.IsOwnCar,HRApplicant.IsHasDrivingLicense,HRApplicant.YearExperience," +
                " HRApplicant.StartWorkAfterWeek,HRApplicant.JobTimeType,HRApplicant.SalaryValue,HRApplicant.RankRequested,HRApplicant.SalaryCurrency,HRApplicantWorker.VacationDayCount,HRApplicantWorker.ApplicantInsuranceJobTitle,HRApplicantWorker.ApplicantInsuranceSalary,HRApplicantWorker.ApplicantVirtualSalary," +
                " HRApplicantWorker.ApplicantInsuranceSalaryChange,HRApplicantWorker.HasMotivation,HRApplicantWorker.JobCategoryEstimation as JobCategoryEstimationTemp,HRApplicantWorker.MotivationType," +
                " HRApplicantWorkerPartTime.PartTimeUnitValue"+
                ",CONVERT(Float, REPLACE(HRApplicantWorker.ApplicantAccountBankNo, '/', '')) as BankIntNo"+
                ",ApplicantAccountBankBranchCode,ApplicantAccountBankAccountTypeCode "+
                ",ApplicantBankTable.* " +
                " ,JobTimeTypeTable.*,RankRequestedTable.*,CurrencyTable.*,MotivationTypeTable.*,NonDiscountedCreditTable.NonDiscountedCreditApplicant " + //,CountryTable.*
                ",VacationGrantTable.* " +
                ",CurrentSubSectorTable.* " +
                ",ApplicantAddedBonusValue  " +
                ",CostCenterTable.ApplicantCostCenterID ,CostCenterTable.ApplicantCostCenterName " +
                    ",MotivationCostCenterTable.ApplicantMotivationCostCenterID , MotivationCostCenterTable.ApplicantMotivationCostCenterName " +
                ",0 MaxCostCenter,AttachmentTable.AttachmentCount";
                if(_IncludePreviousSalalry)
                Returned+=", PreviousSalaryTable.PreviousBaseSalary,PreviousSalaryTable.PreviousDetailsAmount ";
               Returned += ",LastMotivationTable.MotivationValue as LastMotivationValue,LastMotivationAddedBonusTable.LstMotivationAddedBonusValue ";
                if (_MonthSearch != 0)
                {
                    Returned += " ,HRApplicantWorkerVacationGrant.*";
                }
                Returned += ",ImageTable.* ";
                Returned += "  FROM         HRApplicant " +
                 " left outer JOIN  HRApplicantWorker " +
                 " ON HRApplicant.ApplicantID = HRApplicantWorker.ApplicantID " +
                 " left outer join (" + strAttachmentCount + ") as AttachmentTable  " +
                 " on  HRApplicant.ApplicantID = AttachmentTable.ApplicantID ";
                if ((_SectorIDs != null && _SectorIDs != "") || _SectorFamilyID != 0)
                    Returned += " inner join ";
                else
                    Returned += " left outer join ";
                Returned += " (" +ApplicantWorkerSubSector + ") as CurrentSubSectorTable " +
                    " on HRApplicant.ApplicantID = CurrentSubSectorTable.MaxSubSectorApplicant ";
                Returned += " left outer join (" + strCostCenter + ") as CostCenterTable " +
                    " on HRApplicant.ApplicantID = CostCenterTable.Applicant ";
                Returned += " left outer join (" + strMotivationCostCenter + ") as MotivationCostCenterTable  " +
                   " on HRApplicant.ApplicantID = MotivationCostCenterTable.Applicant ";
                Returned += " LEFT OUTER JOIN " +
                 " (" + IDTypeDb.SearchStr + ") as IDTable ON HRApplicant.ApplicantIDType = IDTable.IDtypeID  LEFT OUTER JOIN" +
                 " (" + ComputerQualificationDb.SearchStr + ") as ComputerQualificationTable ON HRApplicantWorker.ApplicantComputerQualificationID = ComputerQualificationTable.ComputerQualificationID LEFT OUTER JOIN " +
                    //" (" + CountryDb.SearchStr + ") as CountryTable ON HRApplicant.ApplicantNationalityID = CountryTable.CountryID LEFT OUTER JOIN " +
                 " (" + RegionDb.SearchStr + ") as RegionTable ON HRApplicant.ApplicantRegionID = RegionTable.RegionID " +
                 " Left Outer Join (" + JobTimeTypeDb.SearchStr + ") as JobTimeTypeTable ON JobTimeTypeTable.JobTimeTypeID = HRApplicant.JobTimeType " +

                 " Left Outer Join (" + MotivationTypeDb.SearchStr + ") as MotivationTypeTable ON MotivationTypeTable.MotivationTypeID = HRApplicantWorker.MotivationType " +
                 " left outer join (" + strAccountBank + ") as ApplicantBankTable " +
                 " on HRApplicantWorker.ApplicantAccountBankID = ApplicantBankTable.ApplicantBankID " +
                 " Left Outer Join (" + RankRequestedDb.SearchStr + ") as RankRequestedTable ON RankRequestedTable.RankRequestedID = HRApplicant.RankRequested " +
                 " Left Outer Join (" + CurrencyDb.SearchStr + ") as CurrencyTable ON CurrencyTable.CurrencyID = HRApplicant.SalaryCurrency " +
                 " left outer join HRApplicantWorkerPartTime on HRApplicant.ApplicantID = HRApplicantWorkerPartTime.Applicant " +
                 " left outer join (" + strSlalryDetails + ") as DetailsTable on DetailsTable.ApplicantID = HRApplicant.ApplicantID " +
                 " left outer join (" + strNonDiscountedCredit + ") as NonDiscountedCreditTable on  " +
                 " HRApplicant.ApplicantID = NonDiscountedCreditTable.NonDiscountedCreditApplicant " +
                 " left outer join (" + LastGrantedVacationStr + ") as VacationGrantTable" +
                 " on HRApplicant.ApplicantID = VacationGrantTable.VacationGrantApplicant ";
                if (_IncludePreviousSalalry)
                    Returned += " left outer join (" + PreviousSalarySearchStr + ") as PreviousSalaryTable " +
                    " on HRApplicant.ApplicantID = PreviousSalaryTable.Applicant ";
             
                Returned += " Left Outer Join (" + strMaxMotivation + ") AS MaxMotivationTable" +
                 " ON HRApplicant.ApplicantID = MaxMotivationTable.Applicant " +
                 " left outer join (" + strMaxMotivation + ") as LastMotivationTable  " +
                 " on   HRApplicant.ApplicantID  = LastMotivationTable.Applicant  " +
                   " left outer join (" + strMaxAddedBonus + ") as LastMotivationAddedBonusTable  " +
                 " on   HRApplicant.ApplicantID  = LastMotivationAddedBonusTable.Applicant  ";
                Returned += " left outer join (" + AddedBonusSearchStr + ") AddBonusTable " +
                   " on  dbo.HRApplicant.ApplicantID =  AddBonusTable.AddedBonusApplicantID ";
                Returned += " left outer join (" + new ApplicantImageDb().SearchStr + @") ImageTable 
                     on   HRApplicantWorker.ApplicantID = ImageTable.ImageApplicantID ";

                //  Returned += " inner join TEMPHRApplicantError on HRApplicant.ApplicantID = TEMPHRApplicantError.Applicant ";

                if (_MonthSearch != 0)
                {
                    Returned += " Left Outer Join HRApplicantWorkerVacationGrant " +
                                " On HRApplicantWorker.ApplicantID = HRApplicantWorkerVacationGrant.Applicant  ";
                }
                //if (_JobDesc != 0)
                //{
                //    Returned += " inner Join HRApplicantWorkerJopDescription " +
                //        " on  HRApplicantWorkerJopDescription.ApplicantID = HRApplicantWorker.ApplicantID  ";
                //}
                if (_AttendanceStatementConsider == 1)
                {
                    Returned += " left outer join (" + ApplicantWorkerAttendance + ") as AttendanceTable  " +
                        " on  HRApplicant.ApplicantID = AttendanceTable.AttendanceApplicant ";


                }
                else if (_AttendanceStatementConsider == 2)
                    Returned += " inner join (" + ApplicantWorkerAttendance + ") as AttendanceTable  " +
                      " on  HRApplicant.ApplicantID = AttendanceTable.AttendanceApplicant ";

                if (_AvoidNoSalaryVacation == 1)
                {


                    Returned += " left outer join (" + NoSalaryVacation + ") as NonSalaryVacationTable " +
                        " on HRApplicant.ApplicantID = NonSalaryVacationTable.Applicant ";

                }

                Returned += "";// " inner join TTempApplicantError on HRApplicant.ApplicantID = TTempApplicantError.ApplicantID "; 
                return Returned;
            }
        }
        public static string AddedBonusSearchStr
        {
            get
            {
                string Returned = "SELECT        ApplicantID AS AddedBonusApplicantID, ApplicantAddedBonusValue "+
                          " FROM   dbo.HRApplicantWorkerAddedBonusValue ";
                return Returned;
            }
        }

        public string StrSearch 
        {
            get
            {
                string Returned = (_ShortApplicantOnly ? ShortSearchStr : SearchStr) + " Where 1=1 And HRApplicantWorker.ApplicantID is not null";
               // Returned = Returned + " And (HRApplicant.ApplicantID = " + 551 + ")";
                #region Applicant Data Search
                if (_ID != 0)
                    Returned = Returned + " And (HRApplicant.ApplicantID = " + _ID + ")";
                if (_User != 0)
                    Returned += " and (HRApplicantWorker.ApplicantUser = " + _User + ")";
                if (_ApplicantSearchIDs != null && _ApplicantSearchIDs != "")
                    Returned = Returned + " And (HRApplicant.ApplicantID in (" + _ApplicantSearchIDs + "))";
                if (_JobDesc == 0)
                { 
                }
                if (_JobDesc == 1)
                {
                    Returned += " And HRApplicantWorker.ApplicantID  in  (SELECT DISTINCT ApplicantID "+
                                " FROM            dbo.HRApplicantWorkerJopDescription)  ";
                }
                if (_JobDesc == 2)
                {
                    Returned += " And HRApplicantWorker.ApplicantID  Not in  (SELECT DISTINCT ApplicantID " +
                                                  " FROM            dbo.HRApplicantWorkerJopDescription)  ";
                }

                if (_NameLike != null && _NameLike != "")
                    Returned = Returned + " And ApplicantFirstName Like '%" + _NameLike + "%'";

                if (_NameCompLike != null && _NameCompLike != "")
                    Returned = Returned + " And ApplicantNameComp Like '%" + _NameCompLike + "%'";


                if (_FamousNameLike != null && _FamousNameLike != "")
                    Returned = Returned + " And ApplicantFamousName Like '%" + _FamousNameLike + "%'";

                if (_CodeLike != null && _CodeLike != "")
                    //strSql = strSql + " And ApplicantCode Like '%" + _CodeLike + "%'";
                    Returned = Returned + " And HRApplicantWorker.ApplicantCode = '" + _CodeLike + "'";// and ApplicantStatusID=1 ";

                if (_CodesSearch != null && _CodesSearch != "")
                    Returned = Returned + " And HRApplicantWorker.ApplicantCode in ( " + _CodesSearch + ")";// and ApplicantStatusID=1 ";


                if (_InsuranceStatusSearch == true)
                {
                    Returned = Returned + " And ApplicantInsuranceNo Is Not Null And ApplicantInsuranceNo <> ''";
                    if (_InsuranceValueSearch != null && _InsuranceValueSearch != "")
                        Returned = Returned + " And ApplicantInsuranceNo Like '%" + _InsuranceValueSearch + "%'";
                }

                if (_intInsuranceStatusSearch != 0)
                {
                    if (_intInsuranceStatusSearch == 1)
                    {
                        Returned = Returned + " And ApplicantInsuranceNo Is Not Null And ApplicantInsuranceNo <> ''";
                        if (_InsuranceValueSearch != null && _InsuranceValueSearch != "")
                            Returned = Returned + " And ApplicantInsuranceNo Like '%" + _InsuranceValueSearch + "%'";
                    }
                    else if (_intInsuranceStatusSearch == 2)
                    {
                        Returned = Returned + " And ApplicantInsuranceNo Is Null OR ApplicantInsuranceNo = ''";
                    }
                }
                if (_FellowShipeStatusSearch != 0)
                {
                    if (_FellowShipeStatusSearch == 1)
                    {
                        Returned += " and (IsFellowShip = 1)";
                    }
                    else if (_FellowShipeStatusSearch == 2)
                    {
                        Returned += " and (IsFellowShip = 0)";
                    }
                }
                if (!(_ReligionIDSearch <= 0))
                    Returned = Returned + " And (ApplicantReligionID = " + _ReligionIDSearch + ")";
                if (_RegionIDSearch != 0)
                    Returned = Returned + " And ApplicantRegionID = " + _RegionIDSearch + "";
                if (_AddressLike != null && _AddressLike != "")
                    Returned = Returned + " And ApplicantAddress = '%" + _AddressLike + "%'";
                double d, dd;
                if (_BirthDateStatusSearch != 0)
                {
                    if (_BirthDateStatusSearch == 1)
                    {
                        
                        d = SysUtility.Approximate(_BirthDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                        dd = SysUtility.Approximate(_BirthDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                     
                        Returned = Returned + " And ApplicantBirthDate Between " + d + " and " + dd + "";
                    }
                    else if (_BirthDateStatusSearch == 2)
                    {
                        Returned = Returned + " And ( (ApplicantBirthDate IS NULL) OR " +
                                          " (ApplicantBirthDate = '') OR " +
                                          " (YEAR(ApplicantBirthDate) = '1900'))";
                    }

                }
                if (_StartDateStatusSearch != 0)
                {
                    if (_StartDateStatusSearch == 1)
                    {
                        
                        d = SysUtility.Approximate(_StartDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                        dd = SysUtility.Approximate(_StartDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                      
                        Returned = Returned + " And ApplicantStartDate Between " + d + " and " + dd + "";
                    }
                    else if (_StartDateStatusSearch == 2)
                    {
                        Returned = Returned + " And ( (ApplicantStartDate IS NULL) OR " +
                                          " (ApplicantStartDate = '') OR " +
                                          " (YEAR(ApplicantStartDate) = '1900'))";
                    }

                }
                if (_StartDateStatusWithApplicantStatusSearch != 0)
                {
                    if (_StartDateStatusWithApplicantStatusSearch == 1)
                    {
                        int intFrom;
                        DateTime dtFrom = new DateTime(_StartDateFromWithApplicantStatusSearch.Year, _StartDateFromWithApplicantStatusSearch.Month, _StartDateFromWithApplicantStatusSearch.Day);
                        DateTime dtTo = new DateTime(_StartDateToWithApplicantStatusSearch.Year, _StartDateToWithApplicantStatusSearch.Month, _StartDateToWithApplicantStatusSearch.Day);
                        //dtTo = dtTo.AddDays(1);
                        double dblFrom = dtFrom.ToOADate() - 2;
                        //intFrom = (int)d;

                        int intTo;
                        double dblTo = dtTo.ToOADate() - 1;
                        //intTo = (int)dd  +1;
                        if (_StartDateToWithApplicantStatusSearch.Year != 1900)
                        {

                            string strWorkingDate = "";
                            if (_StatusIDSearch != 2)
                                strWorkingDate = " (ApplicantEndDate is null and ApplicantStatusID =1)  or  ";
                            // strWorkingDate = "";
                            string strDate = " and ApplicantStartDate<" + dblTo;
                            strDate += " and (" + strWorkingDate + " ApplicantEndDate>" + dblFrom + "  )";
                            Returned = Returned + strDate;//" And ApplicantStartDate Between " + dblFrom + " and " + dblTo + "";
                        }
                        else
                            Returned = Returned + " And ApplicantStartDate > " + dblFrom + "";
                    }
                    else if (_StartDateStatusSearch == 2)
                    {
                        Returned = Returned + " And ( (ApplicantStartDate IS NULL) OR " +
                                        " (ApplicantStartDate = '') OR " +
                                        " (YEAR(ApplicantStartDate) = '1900'))";
                    }
                }
                if (_EndDateStatusSearch == true)
                {
                    int intFrom;
                    DateTime dtFrom = new DateTime(_EndDateFromSearch.Year, _EndDateFromSearch.Month, _EndDateFromSearch.Day);
                    DateTime dtTo = new DateTime(_EndDateToSearch.Year, _EndDateToSearch.Month, _EndDateToSearch.Day);
                    d = SysUtility.Approximate(_EndDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                    dd = SysUtility.Approximate(_EndDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                    

                    Returned = Returned + " And ApplicantEndDate Between " + d + " and " + dd + "";


                }
                if (_InsuranceDateStatusSearch == true)
                {
                  

                    d = SysUtility.Approximate(_InsuranceDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                    dd = SysUtility.Approximate(_InsuranceDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);

                    Returned = Returned + " And ApplicantInsuranceDate >= " +d + " and  ApplicantInsuranceDate < " + dd + "";
                }
                if (_HasMotivationSearch != 0)
                {
                    if (_HasMotivationSearch == 1)
                        Returned = Returned + " And ( HasMotivation = 1) ";
                    else if (_HasMotivationSearch == 2)
                        Returned = Returned + " And ( HasMotivation = 0) ";
                }
                if (_MaritalStatusIDSearch != 0)
                    Returned = Returned + " And ApplicantMaritalStatus = " + _MaritalStatusIDSearch + "";
                if (_MiltaryStatusIDSearch != 0)
                    Returned = Returned + " And ApplicantMiltaryStatus = " + _MiltaryStatusIDSearch + "";
                if (_CommonServiceIDSearch != 0)
                    Returned = Returned + " And ApplicantCommonService = " + _CommonServiceIDSearch + "";
                if (_TypeIDSearch != 0)
                    Returned = Returned + " And ApplicantSexTypeID = " + _TypeIDSearch + "";


                if (_IDTypeSearch != 0)
                    Returned = Returned + " And ApplicantIDType = " + _IDTypeSearch + "";
                if (_IDValSearch != 0)
                    Returned = Returned + " And ApplicantIDValue = '" + _IDValSearch + "'";
                #endregion
                if (_StatusIDSearch != 0 && _AttendanceStatementID == 0 && _GlobalStatementID == 0)
                {
                    int intStatusIDSearch = _StatusIDSearch;
                    if (_StatusIDSearch == 1 && !_ShortApplicantOnly)
                        Returned += " and NonDiscountedCreditApplicant is  null ";
                    if (_StatusIDSearch == 6)
                    {
                        Returned += " and NonDiscountedCreditApplicant is not null ";
                        intStatusIDSearch = 1;
                    }
                    Returned = Returned + " And (ApplicantStatusID = " + intStatusIDSearch + ")";
 
                }
                if (_WorkingStatus != 0)
                {

                    if (_WorkingStatus == 1)
                        Returned += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is  null ";
                    else if (_WorkingStatus == 3)
                    {
                        Returned += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is not null ";

                    }
                    else if (_WorkingStatus == 5)
                        Returned += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is  null ";
                    else if (_WorkingStatus == 2)
                    {
                        Returned += " and ApplicantStatusID <>1 ";
                        if (_IsHasLastFinantial != 0)
                        {
                            if (_IsHasLastFinantial == 1)
                            {
                                Returned += " and LastFinancialStatement = 0 ";
                            }
                        }
                    }
                    else
                        Returned += " and ApplicantStatusID = 1   ";


                }
             
                #region Job Features
                if (_ScientificDegreeIDSearch != 0 || _DegreeFieldIDSearch != 0 || _DegreeSubFieldIDSearch != 0 || _GraduationYearFromSearch != 0 || _GraduationYearToSearch != 0 || _DegreeFieldIDSearch != 0 || _DegreeSubFieldIDSearch != 0)
                {
                    string strEduactionQualified = "";
                    string strGraduationYearFrom = "";
                    string strGraduationYearTo = "";
                    string strDegreeField = "";
                    string strDegreeSubField = "";

                    if (_ScientificDegreeIDSearch != 0)
                        strEduactionQualified = " And HRApplicantScientificDegree.ScientificDegreeID = " + _ScientificDegreeIDSearch + "";
                    if (_DegreeFieldIDSearch != 0)
                        strDegreeField = " And HRApplicantScientificDegree.DegreeFieldID = " + _DegreeFieldIDSearch + "";
                    if (_DegreeSubFieldIDSearch != 0)
                        strDegreeSubField = " And HRApplicantScientificDegree.DegreeSubFieldID = " + _DegreeSubFieldIDSearch + "";

                    if (_GraduationYearFromSearch != 0)
                        strGraduationYearFrom = " And HRApplicantScientificDegree.GraduationYear >= " + _GraduationYearFromSearch + "";
                    if (_GraduationYearToSearch != 0)
                        strGraduationYearTo = " And HRApplicantScientificDegree.GraduationYear <= " + _GraduationYearToSearch + "";

                    Returned = Returned + " And HRApplicant.ApplicantID  in (Select SubTable.ApplicantID from (" + ApplicantScientificDegreeDb.SearchStr + " Where 1=1 " + strEduactionQualified + " " + strGraduationYearFrom + " " + strGraduationYearTo + " " + strDegreeField + " " + strDegreeSubField + ") SubTable)";
                }
                
                if (_JobTypeIDSearch != 0 || _JobNatureTypeIDSearch != 0 || _JobTitleTypeIDSearch != 0)
                {
                    string strJobTypeID = "";
                    string strJobTitleTypeID = "";
                    string strJobNatureTypeID = "";

                    if (_JobTypeIDSearch != 0)
                        strJobTypeID = " And HRApplicantCompany.JobTypeID = " + _JobTypeIDSearch + "";
                    if (_JobTitleTypeIDSearch != 0)
                        strJobTitleTypeID = " And  HRApplicantCompany.JobTitleTypeID = " + _JobTitleTypeIDSearch + "";
                    if (_JobNatureTypeIDSearch != 0)
                        strJobNatureTypeID = " And HRApplicantCompany.JobNatureTypeID = " + _JobNatureTypeIDSearch + "";

                    Returned = Returned + " And HRApplicant.ApplicantID  in (Select SubCompanyTable.ApplicantID from (" + ApplicantCompanyDb.SearchStr + " Where 1=1 " + strJobTypeID + " " + strJobTitleTypeID + " " + strJobNatureTypeID + " ) SubCompanyTable)";
                }
                if (_SJobTypeIDSearch != 0 || _SJobNatureTypeIDSearch != 0 || _SJobTitleTypeIDSearch != 0)
                {
                    string strJobTypeID = "";
                    string strJobTitleTypeID = "";
                    string strJobNatureTypeID = "";

                    if (_SJobTypeIDSearch != 0)
                        strJobTypeID = " And HRApplicantWorkerCurrentSubSector.JobID = " + _SJobTypeIDSearch + "";
                    if (_SJobTitleTypeIDSearch != 0)
                        strJobTitleTypeID = " And  HRApplicantWorkerCurrentSubSector.JobTitleID = " + _SJobTitleTypeIDSearch + "";
                    if (_SJobNatureTypeIDSearch != 0)
                        strJobNatureTypeID = " And HRApplicantWorkerCurrentSubSector.JobNatureID = " + _SJobNatureTypeIDSearch + "";

                    Returned = Returned + " And HRApplicant.ApplicantID  in (Select SubCurrentSubSectorTable.ApplicantID from (" + ApplicantWorkerCurrentSubSectorDb.SearchStr + " Where 1=1 " + strJobTypeID + " " + strJobTitleTypeID + " " + strJobNatureTypeID + " ) SubCurrentSubSectorTable)";
                }
                if ((_JobIDs != null && _JobIDs != "") || _JobIDSearch != 0 || _SectorIDSearch != 0 || _SubSectorIDSearch != 0 || _BranchIDSearch != 0 || _CellIDSearch != 0 || _StoreIDSearch != 0)
                {
                    string strJob = "";
                    string strSector = "";
                    string strSubSector = "";
                    string strBranch = "";
                    string strCell = "";
                    string strStore = "";
                    if (_JobIDSearch != 0)
                        strJob = " And HRApplicantWorkerCurrentSubSector.JobID = " + _JobIDSearch + "";
                    if (_JobIDs != null && _JobIDs != "")
                        strJob = " And HRApplicantWorkerCurrentSubSector. JobNatureID in  (" + _JobIDs + ")";
                    if (_SectorIDSearch != 0)
                    {
                        strSector = " And SectorID = " + _SectorIDSearch + " Or SectorFamilyID = " + _SectorIDSearch + " ";//Or SectorParentID = "+ _SectorIDSearch +"";
                    }
                    if (_SubSectorIDSearch != 0)
                        strSubSector = " And SubSectorTable.SubSectorID = " + _SubSectorIDSearch + "";
                    if (_BranchIDSearch != 0)
                        strBranch = " And BranchID = " + _BranchIDSearch + "";
                    if (_CellIDSearch != 0)
                        strCell = " And CellID = " + _CellIDSearch + "";

                    Returned = Returned + " And HRApplicant.ApplicantID  in (Select SubTable1.ApplicantID from (" + ApplicantWorkerCurrentSubSectorDb.SearchStr + " Where 1=1 " + strJob + " " + strSector + " " + strSubSector + " " + strBranch + " " + strCell + " " + strStore + " ) SubTable1)";
                }

                #endregion

               
                ////////////////////////////////////
                ///////////////////////////////////

                if (_AttendanceStatementIDs != null && _AttendanceStatementIDs != "")
                {
                    string strAttendanceSql = "SELECT     Applicant " +
                                           " FROM   dbo.HRApplicantWorkerAttendanceStatement " +
                                           " WHERE     (AttendanceStatment in ( " + _AttendanceStatementIDs + "))";

                    if (_AttendanceStatementApplicantStatus != 0)
                    {
                        if (_AttendanceStatementApplicantStatus == 1)//Work
                            strAttendanceSql += " And IsEndStatement = 0";
                        else if (_AttendanceStatementApplicantStatus == 2)//not Work
                            strAttendanceSql += " And IsEndStatement = 1";
                    }
                    Returned += " and HRApplicant.ApplicantID  in (" + strAttendanceSql + ")";
                }
                if (_GlobalStatementID != 0)
                {
                    if (_AvoidNoSalaryVacation == 1)
                    {

                        string strNonSalary = "SELECT  VacationApplicantID as Applicant " +
                              " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                     " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                     " Cross join  dbo.HRGlobalStatement   " +
                     " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                     "  AND ( dbo.HRGlobalStatement.StatementDate > VacationFrom) AND (dbo.HRGlobalStatement.StatementDateTo < VacationTo) and dbo.HRGlobalStatement.StatementID= " + _GlobalStatementID;
                        Returned += " and HRApplicant.ApplicantID not in (" + strNonSalary + ")";

                    }
                    if (_GlobalStatementConsider != 0)
                    {
                        string strStatement = " SELECT     Applicant " +
                                           " FROM          dbo.HRApplicantWorkerStatement INNER JOIN " +
                                           " dbo.GLOriginStatement ON dbo.HRApplicantWorkerStatement.OriginStatementID = dbo.GLOriginStatement.OriginStatementID " +
                                           " WHERE     (GlobalStatment = " + _GlobalStatementID + ")";

                        if (_StatementReviewedStatus != 0)
                        {
                            // string strTemp = strStatement;
                            if (_StatementReviewedStatus == 1)
                            {
                                strStatement += " and  dbo.GLOriginStatement.OriginStatementReviewed=0 ";
                            }
                            else if (_StatementReviewedStatus == 2)
                            {
                                strStatement += " and  dbo.GLOriginStatement.OriginStatementReviewed=1 ";
                            }
                            //   strStatement += " union " + strTemp;
                        }
                        if (_GlobalStatementConsider == 1)
                        {
                            Returned += " and HRApplicant.ApplicantID not in (" + strStatement + ")";
                            if (_StatusIDSearch == 1)
                                Returned += " and(ApplicantStatusID =1  or ( ApplicantEndDate is not null And LastFinancialStatement =0 ))";


                            double dlEndDate = _GlobalStatementEndDate.ToOADate() - 1;
                            Returned += " and (ApplicantStartDate  <= " + dlEndDate + " )";


                            double dlStartDate = _GlobalStatementStartDate.ToOADate() - 2;
                            //strSql += " and (ApplicantEndDate is Null OR ApplicantEndDate  Between " + dlStartDate + " and " + dlEndDate + " )";
                            Returned += " and (ApplicantEndDate is Null OR ApplicantEndDate  >= " + dlStartDate + " )";

                        }
                        else if (_GlobalStatementConsider == 2)
                        {
                            Returned += " and HRApplicant.ApplicantID  in (" + strStatement + ")";
                        }
                    }

                    //strSql += " And (HRApplicant.ApplicantID in (Select ApplicantOverDay from V_ApplicantOverDay))";

                }
                if (_InsDateStatusSearch == true)
                {
                    double dblFrom = SysUtility.Approximate(_InsDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblTo = SysUtility.Approximate(_InsDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned = Returned + " And  HRApplicantWorker.TimIns Between " + dblFrom + " And " + dblTo + "";
                }

                if (_UserIDSearch != 0)
                {
                    Returned += " And HRApplicantWorker.UsrIns = " + _UserIDSearch + "";
                }

                if (_IsReviewedSearch == false)
                {
                    Returned = Returned + " And IsReviewed =  0 ";
                }
                if (_AttendanceStatementStatusSearch)
                {
                    if (_HasAttendanceStatementSearch == true)
                    {
                        Returned = Returned + " And HasAttendanceStatement =  1 ";
                    }
                    else
                    {
                        Returned = Returned + " And HasAttendanceStatement =  0 ";
                    }
                }
                if (_TimeSheetStatusSearch)
                {
                    if (_HasTimeShitSearch == true)
                    {
                        Returned = Returned + " And HasTimeShit =  1 ";
                    }
                    else
                    {
                        Returned = Returned + " And HasTimeShit =  0";
                    }
                }
                if (_IsReviewedSearch == false)
                {
                    Returned = Returned + " And IsReviewed =  0 ";
                }
                if (_AccountBankNoSearch != 0)
                {
                    if (_AccountBankNoSearch == 1)
                        Returned = Returned + " And (ApplicantAccountBankNo Is Not Null ) And (ApplicantAccountBankNo <> '' ) ";
                    else if (_AccountBankNoSearch == 2)
                        Returned = Returned + " And ((ApplicantAccountBankNo Is Null) Or (ApplicantAccountBankNo = '') )";

                }
                if (_AccountBankNoLike != null && _AccountBankNoLike != "")
                {
                    //strSql = strSql + " And (ApplicantAccountBankNo Like '%"+ _AccountBankNoLike +"%')";
                    Returned = Returned + " And (ApplicantAccountBankNo = '" + _AccountBankNoLike + "')";
                }
                if (_IsPartTimeStatus != 0)
                {
                    if (_IsPartTimeStatus == 1)
                        Returned += " and HRApplicantWorkerPartTime.PartTimeUnitValue is null ";
                    else if (_IsPartTimeStatus == 2)
                        Returned += " and HRApplicantWorkerPartTime.PartTimeUnitValue is not null ";

                }
                if (_ApplicantWithloanSearch == true)
                {
                    Returned += " and HRApplicant.ApplicantID in (SELECT     LoanApplicant FROM         HRApplicantWorkerLoan )";
                }
                if (_CostCenter != 0)
                {
                    Returned += " and HRApplicant.ApplicantID in (SELECT     Applicant " +
                     " FROM         dbo.HRApplicantWorkerCostCenter " +
                     " WHERE     (CostCenter = " + _CostCenter + ") )";
                }
                if (_CostCenterCondiered != 0)
                {
                    if (_CostCenterCondiered == 2)
                    {
                        Returned += " and HRApplicant.ApplicantID in (SELECT     Applicant " +
                     " FROM  dbo.HRApplicantWorkerCostCenter) ";
                    }
                    else if (_CostCenterCondiered == 1)
                    {
                        Returned += " and HRApplicant.ApplicantID not in (SELECT     Applicant " +
                  " FROM  dbo.HRApplicantWorkerCostCenter) ";
                    }
                }
                if (_EstimationStatementStatusSearch != 0)
                {
                    if (_EstimationStatementIDSearch != 0)
                    {
                        if (_EstimationStatementStatusSearch == 1)
                        {
                            Returned += " and ( HRApplicant.ApplicantID in " +
                                      " (SELECT     HRApplicantWorkerEstimationStatement.Applicant " +
                                      " FROM  dbo.HRApplicantWorkerEstimationStatement " +
                                      " Where HRApplicantWorkerEstimationStatement.EstimationStatement = " + _EstimationStatementIDSearch + ")) ";
                        }
                        else if (_EstimationStatementStatusSearch == 2)
                        {
                            Returned += " and ( HRApplicant.ApplicantID not in " +
                                      " (SELECT     HRApplicantWorkerEstimationStatement.Applicant " +
                                      " FROM  dbo.HRApplicantWorkerEstimationStatement " +
                                      " Where HRApplicantWorkerEstimationStatement.EstimationStatement = " + _EstimationStatementIDSearch + ")) ";
                        }

                    }
                }
                if (_MotivationStatementStatusSearch != 0)
                {
                    if (_MotivationStatementIDSearch != 0)
                    {
                        if (_MotivationStatementStatusSearch == 1)
                        {
                            Returned += " and ( HRApplicant.ApplicantID in " +
                                      " (SELECT     HRApplicantWorkerMotivationStatement.Applicant " +
                                      " FROM  dbo.HRApplicantWorkerMotivationStatement " +
                                      " Where HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatementIDSearch + " ";
                            if (_MotivationStatementCostCenterIDSearch != 0)
                                Returned += " And HRApplicantWorkerMotivationStatement.CostCenter=" + _MotivationStatementCostCenterIDSearch + "";
                            Returned += " )) ";

                        }
                        else if (_MotivationStatementStatusSearch == 2)
                        {
                            Returned += " and ( HRApplicant.ApplicantID not in " +
                                      " (SELECT     HRApplicantWorkerMotivationStatement.Applicant " +
                                      " FROM  dbo.HRApplicantWorkerMotivationStatement " +
                                      " Where HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatementIDSearch + "";
                            if (_MotivationStatementCostCenterIDSearch != 0)
                                Returned += " And HRApplicantWorkerMotivationStatement.CostCenter=" + _MotivationStatementCostCenterIDSearch + "";
                            Returned += " )) ";
                        }

                    }
                }
                if (_MonthSearch != 0)
                {


                    if (_MonthSearch == 1)
                    {
                      
                        Returned += " And (DATEDIFF(Day, HRApplicantWorker.ApplicantStartDate, GETDATE()) <= 132)";
                        if (_GrantSearch != 0)
                        {
                            if (_GrantSearch == 1)
                                Returned += " AND (HRApplicantWorkerVacationGrant.Applicant IS NOT NULL)";
                            else if (_GrantSearch == 2)
                                Returned += " AND (HRApplicantWorkerVacationGrant.Applicant IS  NULL)";
                        }
                    }
                    else if (_MonthSearch == 2)
                    {
                      
                        Returned += " And (DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >132 And DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) <=365)";
                        if (_GrantSearch != 0)
                        {
                            if (_GrantSearch == 1)
                                Returned += " AND (HRApplicantWorkerVacationGrant.VacationType = 1) AND(HRApplicantWorkerVacationGrant.Applicant IS NOT NULL)";
                            else if (_GrantSearch == 2)
                                //    strSql += " AND ((HRApplicantWorkerVacationGrant.VacationType =2) )";
                                Returned += " AND (HRApplicantWorkerVacationGrant.Applicant IS  NULL)";
                        }
                    }
                    else if (_MonthSearch == 3)
                    {
                       
                        Returned += " And (DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >365)";
                        if (_GrantSearch != 0)
                        {
                            int intFrom;
                            d = _GrantDateFromSearch.ToOADate() - 2;
                            intFrom = (int)d;

                            int intTo;
                            dd = _GrantDateToSearch.ToOADate() - 2;
                            intTo = (int)dd + 1;

                            string strGrant = " SELECT  Distinct VG.Applicant " +
                                              " FROM  HRApplicantWorkerVacationGrant VG  Where VG.VacationDateFrom between " + intFrom + " and  " + intTo + "";
                         


                            if (_GrantSearch == 1) //grant Between Date
                            {
                                Returned += " And HRApplicant.ApplicantID In   (" + strGrant + ")";
                            }
                            else if (_GrantSearch == 2) //not Grant Between Date
                            {
                                Returned += " And HRApplicant.ApplicantID Not In (" + strGrant + ")";
                            }

                         
                        }

                    }

                    _MonthSearch = 0;
                }
                if (_GrantSearch != 0)
                {
                     
                    
                }
 

                if (_AccountBankNoOrderSearch == true)
                {
                    Returned += " ORDER BY CONVERT(bigint, REPLACE(HRApplicantWorker.ApplicantAccountBankNo, '/', ''))";
                }
                else
                {
                    //strSql += " ORDER BY HRApplicantWorkerCurrentSubSector.BranchID ";
                }

                if (_GetFromViews != 0)
                {
                    if (_GetFromViews == 1)
                    {
                        //strSql += " And ( HRApplicant.ApplicantID in (Select Applicant From V_ApplicantOver50Year))"; 
                        Returned += " And ( HRApplicant.ApplicantID in (Select ApplicantID From V_SearchInHRView))";
                    }
                }
                if (_AttendanceStatementID != 0)
                {
                    if (_AvoidNoSalaryVacation == 1)
                    {

                      
                        Returned += " and NonSalaryVacationTable.Applicant is null ";

                    }
                    if (_AttendanceStatementConsider != 0)
                    {
                       
                        if (_AttendanceStatementConsider == 1)
                        {
                            Returned += " and AttendanceTable.AttendanceApplicant is null ";
                            if (_StatusIDSearch == 1)
                                Returned += " and(ApplicantStatusID =1  or ( ApplicantEndDate is not null and LastAttendanceStatement =0))";
                        }
                        else if (_AttendanceStatementConsider == 2)
                        {

                            Returned += " and AttendanceTable.AttendanceApplicant is not null ";
                        }
                       
                    }
                    double dlEndDate = _AttendanceStatementEndDate.ToOADate() - 1;
                    Returned += " and (HRApplicantWorker.ApplicantStartDate  <= " + dlEndDate + " )";
                    if (_AttendanceStatementConsider == 1)
                    {
                        double dlStartDate = _AttendanceStatementStartDate.ToOADate() - 2;
                      
                        Returned += " and (HRApplicantWorker.ApplicantEndDate is Null OR HRApplicantWorker.ApplicantEndDate  >= " + dlStartDate + " )";
                    }
                    // strSql += " And (ApplicantTable.ApplicantID in (Select ApplicantOverDay from V_ApplicantOverDay))";
                }

          

           
              return Returned ;


  
            }

        }
        public string AddPartTimeStr
        {
            get
            {
                string Returned = "insert into HRApplicantWorkerPartTime (Applicant, PartTimeUnit, PartTimeUnitValue)" +
               " values (" + _ID + "," + _PartTimeUnit + "," + _PartTimeUnitValue + ")";
                return Returned;
            }
        }
        public string EditPartTimeStr
        {
            get
            {
                string Returned = "Update HRApplicantWorkerPartTime set  PartTimeUnit = "+ _PartTimeUnit +
                    ", PartTimeUnitValue=" + _PartTimeUnitValue  +
               " where Applicant=" + _ID ;
                return Returned;
            }
        }
        public string DeletePartTimeStr
        {
            get
            {
                string Returned = "Delete From HRApplicantWorkerPartTime  where Applicant=" + _ID;
                return Returned;
            }
        }
      
        public string AddStr
        {
            get
            {
                string StartDate = "";
                if (_StartDateStatus == true)
                {
                    double d = _StartDate.ToOADate() - 2;
                    StartDate = d.ToString();
                }
                else
                {
                    StartDate = "Null";
                }
                  string strInsuranceDate = "";
                if (_InsuranceNo != null && _InsuranceNo!="")
                {
                    double dd = _InsuranceDate.ToOADate() - 2;
                    strInsuranceDate = dd.ToString();
                }
                else
                {
                    strInsuranceDate = "Null";
                }
                string strExperienceDate = _StartExperienceDateDecided ? 
                    SysUtility.Approximate( _StartExperienceDate.ToOADate() - 2,1,ApproximateType.Down).ToString() : "NULL";
                string strRegion = "";
                string strComputerQualification = "";
                if (_ComputerQualificationID != 0)
                    strComputerQualification = _ComputerQualificationID.ToString();
                else
                    strComputerQualification = "Null";

                int intIsFellowShip = _IsFellowShip ? 1 : 0;
                int intHasTimeShit = _HasTimeShit ? 1 : 0;
                int intHasAttendanceStatement = _HasAttendanceStatement ? 1 : 0;
                int intIsDiscountDelay = _IsDiscountDelay ? 1 : 0;
                int intHasMotivation = _HasMotivation ? 1 : 0;
                //HasMotivation

                _AccountBankID = _AccountBankNo == null || _AccountBankNo == "" ?
                    0 : _AccountBankID;
                string strID = _ID == 0 ? "@ID" : _ID.ToString(); ;
                string Returned = " INSERT INTO HRApplicantWorker " +
                             " (ApplicantID,ApplicantCode,ArchiveNo,ApplicantInsuranceNo,JobCategoryEstimation,ApplicantInsuranceDate,"+
                             " ApplicantAccountBankNo,ApplicantAccountBankID"+
                             ",ApplicantAccountBankBranchCode,ApplicantAccountBankAccountTypeCode "+
                             ",ApplicantComputerQualificationID,ApplicantMedicalStatus," +
                             " ApplicantStartExperienceDate,ApplicantStartDate, ApplicantStartSalary, " +
                             " ApplicantStartSalaryCurrency, ApplicantCurrentSalary, ApplicantUser,ApplicantStatusID,IsFellowShip"+
                             ",FellowShipSalaryOrMotivation"+
                             ", HasTimeShit,HasAttendanceStatement,FellowShipCredit,IsDiscountDelay," +
                             " VacationDayCount,ApplicantInsuranceJobTitle,ApplicantInsuranceSalary,ApplicantInsuranceSalaryChange,"+
                             " HasMotivation,MotivationType,UsrIns,TimIns)" +
                             " VALUES  (" + strID + ",'" + _Code + "','" + _ArchiveNo + "','" + _InsuranceNo + "'," + _JobCategoryEstimation + "," + strInsuranceDate +
                             ",'" + _AccountBankNo + "',"+ _AccountBankID + ",'"+_AccountBankBranchCode +"'"+
                             ",'"+_AccountTypeCode +"',"  + strComputerQualification + 
                             "," + _MedicalStatusID + " ," +
                             strExperienceDate +  "," + StartDate + "," + _StartSalary + "," + _StartSalaryCurrency + "," + _CurrentSalary + "," + _User + "," + _StatusID + "," + intIsFellowShip + "," + _FellowShipSalaryOrMotivation + "," + intHasTimeShit + "," + intHasAttendanceStatement + "," + _FellowShipCredit + "," + intIsDiscountDelay + "," +
                             " " + _VacationDayCount + ",'" + _InsuranceJobTitle + "'," + _InsuranceSalary + "," + _InsuranceSalaryChange + "," + intHasMotivation + "," + _MotivationType + "," + SysData.CurrentUser.ID + ",GetDate()) ";
                if (_HasAddedBonus)
                    Returned += " insert into HRApplicantWorkerAddedBonusValue (ApplicantID, ApplicantAddedBonusValue) "+
                        " values ("+ strID + "," + _AddedBonusValue +") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string StartDate = "";
                if (_StartDateStatus == true)
                {
                    double d = _StartDate.ToOADate() - 2;
                    StartDate = d.ToString();
                }
                else
                {
                    StartDate = "Null";
                }
                string strInsuranceDate = "";
                if (_InsuranceDate.Year != 1900 && _InsuranceDate.Year != 1)
                {
                    double dd = _InsuranceDate.ToOADate() - 2;
                    strInsuranceDate = dd.ToString();
                }
                else
                {
                    strInsuranceDate = "Null";
                }
                string strRegion = "";
                string strComputerQualification = "";
                if (_RegionID != 0)
                    strRegion = _RegionID.ToString();
                else
                    strRegion = "Null";

                if (_ComputerQualificationID != 0)
                    strComputerQualification = _ComputerQualificationID.ToString();
                else
                    strComputerQualification = "Null";

                int intIsReviewed = _IsReviewed ? 1 : 0;
                int intIsFellowShip = _IsFellowShip ? 1 : 0;
                int intHasTimeShit = _HasTimeShit ? 1 : 0;
                _CurrentSalary = _IsPartTime ? 0 : _CurrentSalary;
                int intHasAttendanceStatement = _HasAttendanceStatement ? 1 : 0;
                int intIsDiscountDelay = _IsDiscountDelay ? 1 : 0;
                int intHasMotivation = _HasMotivation ? 1 : 0;
                string strExperienceDate = _StartExperienceDateDecided ?
                   SysUtility.Approximate(_StartExperienceDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";
                string Returned = " UPDATE    HRApplicantWorker" +
                             " SET   " +
                             "  ApplicantCode ='" + _Code + "'" +
                             " , ArchiveNo = '" + _ArchiveNo + "'" +
                             " , ApplicantInsuranceNo ='" + _InsuranceNo + "'" +
                             " , JobCategoryEstimation =" + _JobCategoryEstimation + "" +
                             " , ApplicantInsuranceDate = " + strInsuranceDate + "" +
                             " , ApplicantAccountBankNo ='" + _AccountBankNo + "'" +
                             " , ApplicantAccountBankID =" + _AccountBankID + "" +
                             ",ApplicantAccountBankBranchCode='"+_AccountBankBranchCode+"'"+
                             ",ApplicantAccountBankAccountTypeCode='"+ _AccountTypeCode +"'"+
                             " , ApplicantComputerQualificationID =" + strComputerQualification + "" +
                             " , ApplicantMedicalStatus =" + _MedicalStatusID + "" +
                             ",ApplicantStartExperienceDate="+ strExperienceDate +
                             " , ApplicantStartDate =" + StartDate + "" +
                             " , ApplicantStartSalary =" + _StartSalary + "" +
                             " , ApplicantStartSalaryCurrency =" + _StartSalaryCurrency + "" +
                             " , ApplicantCurrentSalary =" + _CurrentSalary + "" +
                             //" , ApplicantUser =" + _User + "" +
                             " , ApplicantStatusID =" + _StatusID + "" +
                             " , IsReviewed =" + intIsReviewed + "" +
                             " , IsFellowShip =" + intIsFellowShip + "" +
                             ",FellowShipSalaryOrMotivation="+_FellowShipSalaryOrMotivation +
                             " , HasTimeShit =" + intHasTimeShit + "" +
                             " , FellowShipCredit =" + _FellowShipCredit + "" +
                             " , IsDiscountDelay = " + intIsDiscountDelay + ""+
                             " , HasAttendanceStatement =" + intHasAttendanceStatement + "" +
                             " , VacationDayCount = "+ _VacationDayCount +""+
                             " , ApplicantInsuranceJobTitle = '"+ _InsuranceJobTitle +"'"+
                             " , ApplicantInsuranceSalary = "+ _InsuranceSalary +""+
                             " , ApplicantInsuranceSalaryChange = " + _InsuranceSalaryChange + "" +
                             " , HasMotivation = "+ intHasMotivation +""+
                             " , MotivationType = " + _MotivationType + "" +
                             " , UsrUpd = " + SysData.CurrentUser.ID + " " +
                             " , TimUpd = GetDate() " +
                             " Where ApplicantID = " + _ID + "";
                Returned += "  delete from HRApplicantWorkerAddedBonusValue where ApplicantID =  "+ _ID ;
                if (_HasAddedBonus)
                    Returned += " insert into HRApplicantWorkerAddedBonusValue (ApplicantID, ApplicantAddedBonusValue) "+
                        " values ("+ _ID + "," + _AddedBonusValue +") "   ;
                return Returned;
            }
        }
        public override string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRApplicantWorker SET  Dis = GetDate() WHERE     (ApplicantID = " + _ID + ") ";
                return Returned;
            }

        }
        public string ApplicantHasAttendanceStr
        {
            get
            {
                string Returned = "SELECT  dbo.HRApplicantWorkerStatement.OriginStatementID, dbo.HRApplicantWorkerStatement.GlobalStatment "+
                     " FROM    dbo.HRApplicantWorkerStatement INNER JOIN "+
                     " dbo.HRGlobalStatement ON dbo.HRApplicantWorkerStatement.GlobalStatment = dbo.HRGlobalStatement.StatementID INNER JOIN "+
                      " dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment ON  "+
                      " dbo.HRGlobalStatement.AttendanceStatement = dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment.AttendanceStatment "+
                      " WHERE     (dbo.HRApplicantWorkerStatement.GlobalStatment = "+ _ID +")"; 
    return Returned;
            }
        }

        public DateTime LastMotivationDate { get => _LastMotivationDate; set => _LastMotivationDate = value; }

        public void EditCurrentSalary()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantCurrentSalary = " + _CurrentSalary + " ,UsrInsCurrentSalary = " + SysData.CurrentUser.ID + " ,TimInsCurrentSalary = GetDate()" +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditVirtualSalary()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantVirtualSalary = " + _ApplicantVirtualSalary + "" +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditInsuranceSalary()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantInsuranceSalary = " + _InsuranceSalary + " " +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditInsuranceSalaryChange()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantInsuranceSalaryChange = " + _InsuranceSalaryChange + " " +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStartSalary()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantStartSalary = " + _StartSalary + " " +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStartSalaryDetails()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantStartSalaryDetails = " + _StartSalaryDetails + " " +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditAccountBankNo()
        {
            int intIsFellowShip = _IsFellowShip ? 1 : 0;

            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   ApplicantAccountBankNo = '" + _AccountBankNo + "' " +
                            ",ApplicantAccountBankID = " + _AccountBankID + " " +
                            //" , IsFellowShip = "+ intIsFellowShip +""+
                            ",ApplicantAccountBankBranchCode='"+ _AccountBankBranchCode +"'"+
                            ",ApplicantAccountBankAccountTypeCode='"+  _AccountTypeCode +"'"+
                            " , UserAccountBank = " + SysData.CurrentUser.ID + " " +
                            " , DateAccountBank = GetDate() " +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditFellowShipCredit()
        {            
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   FellowShipCredit = "+ _FellowShipCredit +"" +                           
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditFellowShipDiscountHistory()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   FellowShipDiscountHistory = " + _FellowShipDiscountHistory + "" +
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditJobCategoryEstimation()
        {
            
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   JobCategoryEstimation = " + _JobCategoryEstimation + " " +                
                            " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
        #region private Methods
        //public void SetData(DataRow objDR)
        //{
        //    if (objDR.Table.Columns["ShortApplicant"] != null)
        //    {
        //        SetShortData(objDR);
        //        return;
        //    }
        //    _UserDb = new UserDb();
        //    if (objDR["ApplicantWorkerID"].ToString() != "")
        //        _ApplicantWorkerID = int.Parse(objDR["ApplicantWorkerID"].ToString());
        //    else
        //        _ApplicantWorkerID = 0;
        //    _Code = objDR["ApplicantCode"].ToString();
        //    if (objDR["ApplicantUser"].ToString() != "")
        //        _User = int.Parse(objDR["ApplicantUser"].ToString());
        //    else
        //        _User = 0;
        //    if (objDR["ApplicantStartDate"].ToString() != "")
        //    {
        //        _StartDateStatus = true;
        //        _StartDate = DateTime.Parse(objDR["ApplicantStartDate"].ToString());
        //    }
        //    else
        //    {
        //        _StartDateStatus = false;
        //    }

        //    if (objDR["ApplicantStartSalary"].ToString() != "")
        //        _StartSalary = double.Parse(objDR["ApplicantStartSalary"].ToString());
        //    else
        //        _StartSalary = 0;

        //    if (objDR["ApplicantVirtualSalary"].ToString() != "")
        //        _ApplicantVirtualSalary = double.Parse(objDR["ApplicantVirtualSalary"].ToString());
        //    else
        //        _ApplicantVirtualSalary = 0;
            
        //    if (objDR["ApplicantStartSalaryDetails"].ToString() != "")
        //        _StartSalaryDetails = double.Parse(objDR["ApplicantStartSalaryDetails"].ToString());
        //    else
        //        _StartSalaryDetails = 0;
        //    if (objDR["ApplicantStartSalaryCurrency"].ToString() != "")
        //        _StartSalaryCurrency = int.Parse(objDR["ApplicantStartSalaryCurrency"].ToString());
        //    else
        //        _StartSalaryCurrency = 0;
        //    if (objDR["ApplicantCurrentSalary"].ToString() != "")
        //        _CurrentSalary = double.Parse(objDR["ApplicantCurrentSalary"].ToString());
        //    else
        //        _CurrentSalary = 0;
        //    if (objDR["ApplicantMedicalStatus"].ToString() != "")
        //        _MedicalStatusID = int.Parse(objDR["ApplicantMedicalStatus"].ToString());
        //    else
        //        _MedicalStatusID = 0;
        //    if (objDR["ApplicantComputerQualificationID"].ToString() != "")
        //        _ComputerQualificationID = int.Parse(objDR["ApplicantComputerQualificationID"].ToString());
        //    else
        //        _ComputerQualificationID = 0;
        //    _ComputerQualificationStr = objDR["ComputerQualificationNameA"].ToString();
        //    _InsuranceNo = objDR["ApplicantInsuranceNo"].ToString();
        //    if (objDR["ApplicantInsuranceDate"].ToString() != "")
        //        _InsuranceDate = DateTime.Parse(objDR["ApplicantInsuranceDate"].ToString());
        //    if (_InsuranceDate.Year.ToString() == "1900" || _InsuranceDate.Year.ToString() == "0001" || _InsuranceDate.Year.ToString() == "1")
        //        _InsuranceDate = new DateTime(1900, 1, 1);
        //    _InsuranceJobTitle = objDR["ApplicantInsuranceJobTitle"].ToString();
        //    _InsuranceSalary = float.Parse(objDR["ApplicantInsuranceSalary"].ToString());
        //    _InsuranceSalaryChange = float.Parse(objDR["ApplicantInsuranceSalaryChange"].ToString());
        //    _AccountBankNo = objDR["ApplicantAccountBankNo"].ToString();
        //    _StatusID = int.Parse(objDR["ApplicantStatusID"].ToString());
        //    _IsEnded = false;
        //    if (objDR["ApplicantEndDate"].ToString() != "")
        //    {
        //        _EndDate = DateTime.Parse(objDR["ApplicantEndDate"].ToString());
        //        _IsEnded = true;
        //    }
        //    _LastAttendanceStatement = int.Parse(objDR["LastAttendanceStatement"].ToString());
        //    _LastFinancialStatement = int.Parse(objDR["LastFinancialStatement"].ToString());
        //    _IsReviewed = bool.Parse(objDR["IsReviewed"].ToString());
        //    _IsFellowShip = bool.Parse(objDR["IsFellowShip"].ToString());
        //    _HasTimeShit = bool.Parse(objDR["HasTimeShit"].ToString());
        //    _HasAttendanceStatement = bool.Parse(objDR["HasAttendanceStatement"].ToString());
        //    _IsDiscountDelay = bool.Parse(objDR["IsDiscountDelay"].ToString());
        //    _HasMotivation = bool.Parse(objDR["HasMotivation"].ToString());
        //    _DetailsValue = double.Parse(objDR["TotalDetailsValue"].ToString());
        //    if (objDR["PartTimeUnit"].ToString() != "")
        //    {
        //        _PartTimeUnit = byte.Parse(objDR["PartTimeUnit"].ToString());
        //        _IsPartTime = true;
        //        _CurrentSalary = 0;
        //    }
        //    if (objDR["PartTimeUnitvalue"].ToString() != "")
        //        _PartTimeUnitValue = double.Parse(objDR["PartTimeUnitValue"].ToString());            
        //    if (objDR["FellowShipCredit"].ToString() != "")
        //        _FellowShipCredit = double.Parse(objDR["FellowShipCredit"].ToString());
        //    if (objDR["FellowShipDiscountHistory"].ToString() != "")
        //        _FellowShipDiscountHistory = double.Parse(objDR["FellowShipDiscountHistory"].ToString());
        //    if (objDR["VacationDayCount"].ToString() != "")
        //        _VacationDayCount = int.Parse(objDR["VacationDayCount"].ToString());
        //    _HasNonDiscountedCreditVacation = false;
        //    if (objDR["NonDiscountedCreditApplicant"].ToString() != "")
        //        _HasNonDiscountedCreditVacation = true;
        //    if (objDR["BankIntNo"].ToString() != "")
        //        _BankIntNo = Double.Parse(objDR["BankIntNo"].ToString());
        //    if (objDR["JobCategoryEstimationTemp"].ToString() != "")
        //        _JobCategoryEstimation = int.Parse(objDR["JobCategoryEstimationTemp"].ToString());
        //    _ArchiveNo = objDR["ArchiveNo"].ToString();
        //    if (objDR["MotivationType"].ToString() != "")
        //        _MotivationType = int.Parse(objDR["MotivationType"].ToString());
        //    if (objDR["ApplicantBankID"].ToString() != "")
        //        _AccountBankID = int.Parse(objDR["ApplicantBankID"].ToString());
        //    _AccountBankName = objDR["ApplicantBankName"].ToString();
        //    if (objDR.Table.Columns["LastGrantedDate"] != null && objDR["LastGrantedDate"].ToString() != "")
        //    {
        //        _HasGrantedVacation = true;
        //        _LastGrantedVacationDate = DateTime.Parse(objDR["LastGrantedDate"].ToString());
 
        //    }
        //    if(objDR.Table.Columns["ApplicantSectorID"]!= null && objDR["ApplicantSectorID"].ToString()!="")
        //        _SectorID = int.Parse(objDR["ApplicantSectorID"].ToString());
        //    if (objDR.Table.Columns["ApplicantSectorNameA"] != null)
        //        _SectorNameA =  objDR["ApplicantSectorNameA"].ToString() ;
        //    if (objDR.Table.Columns["ApplicantBranchID"] != null && objDR["ApplicantBranchID"].ToString() != "")
        //        _BranchID = int.Parse(objDR["ApplicantBranchID"].ToString());
        //    if (objDR.Table.Columns["ApplicantBranchNameA"] != null)
        //        _BranchNameA = objDR["ApplicantBranchNameA"].ToString();
        //    if (objDR.Table.Columns["ApplicantSubSectorID"] != null && objDR["ApplicantSubSectorID"].ToString() != "")
        //        _SubSectorID = int.Parse(objDR["ApplicantSubSectorID"].ToString());
        //    if (objDR.Table.Columns["MaxCostCenter"] != null && objDR["MaxCostCenter"].ToString() != "")
        //        _CostCenter = int.Parse(objDR["MaxCostCenter"].ToString());
        //    if (objDR.Table.Columns["AttachmentCount"] != null && objDR["AttachmentCount"].ToString() != "")
        //        _AttachmentCount = int.Parse(objDR["AttachmentCount"].ToString());
        //    if (objDR["SectorJobNatureID"].ToString() != "")
        //        _JobNatureID = int.Parse(objDR["SectorJobNatureID"].ToString());
        //    _JobNatureTypeNameA = objDR["SectorJobNatureNameA"].ToString();
        //    if (objDR.Table.Columns["SectorJobCategoryOrder"] != null && objDR["SectorJobCategoryOrder"].ToString() != "")
        //        _JobNatureOrderValue = int.Parse(objDR["SectorJobCategoryOrder"].ToString());
        //}

        public void SetData(DataRow objDR)
        {
            _UserDb = new UserDb();
            if (objDR.Table.Columns["ShortApplicant"] != null)
            {
                SetShortData(objDR);
                return;
            }
            if (objDR.Table.Columns["ShortPreviousSalalry"] != null)
            {
                SetPreviousSalaryData(objDR);
                return;
            }
            if (objDR["ApplicantWorkerID"].ToString() != "")
                _ApplicantWorkerID = int.Parse(objDR["ApplicantWorkerID"].ToString());
            else
                _ApplicantWorkerID = 0;
            _Code = objDR["ApplicantCode"].ToString();
            if (objDR["ApplicantUser"].ToString() != "")
                _User = int.Parse(objDR["ApplicantUser"].ToString());
            else
                _User = 0;
            if (objDR["ApplicantStartDate"].ToString() != "")
            {
                _StartDateStatus = true;
                _StartDate = DateTime.Parse(objDR["ApplicantStartDate"].ToString());
            }
            else
            {
                _StartDateStatus = false;
            }
            if(objDR.Table.Columns["ApplicantStartExperienceDate"]!= null && objDR["ApplicantStartExperienceDate"].ToString()!= "")
            {

                _StartExperienceDateDecided = true;
                _StartExperienceDate = DateTime.Parse(objDR["ApplicantStartExperienceDate"].ToString());

            }
            if (objDR["ApplicantStartSalary"].ToString() != "")
                _StartSalary = double.Parse(objDR["ApplicantStartSalary"].ToString());
            else
                _StartSalary = 0;

            if (objDR["ApplicantVirtualSalary"].ToString() != "")
                _ApplicantVirtualSalary = double.Parse(objDR["ApplicantVirtualSalary"].ToString());
            else
                _ApplicantVirtualSalary = 0;

            if (objDR["ApplicantStartSalaryDetails"].ToString() != "")
                _StartSalaryDetails = double.Parse(objDR["ApplicantStartSalaryDetails"].ToString());
            else
                _StartSalaryDetails = 0;
            if (objDR["ApplicantStartSalaryCurrency"].ToString() != "")
                _StartSalaryCurrency = int.Parse(objDR["ApplicantStartSalaryCurrency"].ToString());
            else
                _StartSalaryCurrency = 0;
            if (objDR["ApplicantCurrentSalary"].ToString() != "")
                _CurrentSalary = double.Parse(objDR["ApplicantCurrentSalary"].ToString());
            else
                _CurrentSalary = 0;
            if (objDR["ApplicantMedicalStatus"].ToString() != "")
                _MedicalStatusID = int.Parse(objDR["ApplicantMedicalStatus"].ToString());
            else
                _MedicalStatusID = 0;
            if (objDR["ApplicantComputerQualificationID"].ToString() != "")
                _ComputerQualificationID = int.Parse(objDR["ApplicantComputerQualificationID"].ToString());
            else
                _ComputerQualificationID = 0;
            _ComputerQualificationStr = objDR["ComputerQualificationNameA"].ToString();
            _InsuranceNo = objDR["ApplicantInsuranceNo"].ToString();
            if (objDR["ApplicantInsuranceDate"].ToString() != "")
                _InsuranceDate = DateTime.Parse(objDR["ApplicantInsuranceDate"].ToString());
            if (_InsuranceDate.Year.ToString() == "1900" || _InsuranceDate.Year.ToString() == "0001" || _InsuranceDate.Year.ToString() == "1")
                _InsuranceDate = new DateTime(1900, 1, 1);
            _InsuranceJobTitle = objDR["ApplicantInsuranceJobTitle"].ToString();
            _InsuranceSalary = float.Parse(objDR["ApplicantInsuranceSalary"].ToString());
            _InsuranceSalaryChange = float.Parse(objDR["ApplicantInsuranceSalaryChange"].ToString());
            _AccountBankNo = objDR["ApplicantAccountBankNo"].ToString();
            _AccountBankBranchCode = objDR["ApplicantAccountBankBranchCode"].ToString();
            _AccountTypeCode = objDR["ApplicantAccountBankAccountTypeCode"].ToString();
            _StatusID = int.Parse(objDR["ApplicantStatusID"].ToString());
            if (objDR["ApplicantEndDate"].ToString() != "")
                _EndDate = DateTime.Parse(objDR["ApplicantEndDate"].ToString());
            _LastAttendanceStatement = int.Parse(objDR["LastAttendanceStatement"].ToString());
            _LastFinancialStatement = int.Parse(objDR["LastFinancialStatement"].ToString());
            _IsReviewed = bool.Parse(objDR["IsReviewed"].ToString());
            _IsFellowShip = bool.Parse(objDR["IsFellowShip"].ToString());
            _HasTimeShit = bool.Parse(objDR["HasTimeShit"].ToString());
            _HasAttendanceStatement = bool.Parse(objDR["HasAttendanceStatement"].ToString());
            _IsDiscountDelay = bool.Parse(objDR["IsDiscountDelay"].ToString());
            _HasMotivation = bool.Parse(objDR["HasMotivation"].ToString());
            _DetailsValue = double.Parse(objDR["TotalDetailsValue"].ToString());
            try
            {
                if (objDR["TotalDetailsForMotivation"].ToString() != "")
                    _TotalDetailsForMotivation = double.Parse(objDR["TotalDetailsForMotivation"].ToString());

            }
            catch { }
            if (objDR["PartTimeUnit"].ToString() != "")
            {
                _PartTimeUnit = byte.Parse(objDR["PartTimeUnit"].ToString());
                _IsPartTime = true;
                _CurrentSalary = 0;
            }
            if (objDR["PartTimeUnitvalue"].ToString() != "")
                _PartTimeUnitValue = double.Parse(objDR["PartTimeUnitValue"].ToString());
            if (objDR["FellowShipCredit"].ToString() != "")
                _FellowShipCredit = double.Parse(objDR["FellowShipCredit"].ToString());
            if (objDR["FellowShipDiscountHistory"].ToString() != "")
                _FellowShipDiscountHistory = double.Parse(objDR["FellowShipDiscountHistory"].ToString());
            if (objDR["VacationDayCount"].ToString() != "")
                _VacationDayCount = int.Parse(objDR["VacationDayCount"].ToString());
            _HasNonDiscountedCreditVacation = false;
            if (objDR["NonDiscountedCreditApplicant"].ToString() != "")
                _HasNonDiscountedCreditVacation = true;
            if (objDR["BankIntNo"].ToString() != "")
                _BankIntNo = Double.Parse(objDR["BankIntNo"].ToString());
            if (objDR["JobCategoryEstimationTemp"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDR["JobCategoryEstimationTemp"].ToString());
            _ArchiveNo = objDR["ArchiveNo"].ToString();
            if (objDR["MotivationType"].ToString() != "")
                _MotivationType = int.Parse(objDR["MotivationType"].ToString());
            if (objDR["ApplicantBankID"].ToString() != "")
                _AccountBankID = int.Parse(objDR["ApplicantBankID"].ToString());
            _AccountBankName = objDR["ApplicantBankName"].ToString();
            if (ID == 61)
                ID = 61;
            if (objDR.Table.Columns["LastGrantedDate"] != null && objDR["LastGrantedDate"].ToString() != "")
            {
                _HasGrantedVacation = true;
                _LastGrantedVacationDate = DateTime.Parse(objDR["LastGrantedDate"].ToString());
                _LastGrantedStartValid = DateTime.Parse(objDR["MaxGrantedDateFrom"].ToString());
                if (_StartDateStatus && _LastGrantedStartValid < _StartDate)
                {
                    _HasGrantedVacation = false;

                }

            }
            if (objDR.Table.Columns["ApplicantSectorID"] != null && objDR["ApplicantSectorID"].ToString() != "")
                _SectorID = int.Parse(objDR["ApplicantSectorID"].ToString());
            if (objDR.Table.Columns["ApplicantSectorNameA"] != null)
                _SectorNameA = objDR["ApplicantSectorNameA"].ToString();
            if (objDR.Table.Columns["ApplicantBranchID"] != null && objDR["ApplicantBranchID"].ToString() != "")
                _BranchID = int.Parse(objDR["ApplicantBranchID"].ToString());
            if (objDR.Table.Columns["ApplicantBranchNameA"] != null)
                _BranchNameA = objDR["ApplicantBranchNameA"].ToString();
            if (objDR.Table.Columns["ApplicantSubSectorID"] != null && objDR["ApplicantSubSectorID"].ToString() != "")
                _SubSectorID = int.Parse(objDR["ApplicantSubSectorID"].ToString());
            if (objDR.Table.Columns["MaxCostCenter"] != null && objDR["MaxCostCenter"].ToString() != "")
                _CostCenter = int.Parse(objDR["MaxCostCenter"].ToString());
            if (objDR.Table.Columns["ApplicantCostCenterName"] != null &&
               objDR["ApplicantCostCenterName"].ToString() != "")
                _CostCenterNameA = objDR["ApplicantCostCenterName"].ToString();
            if (objDR.Table.Columns["AttachmentCount"] != null && objDR["AttachmentCount"].ToString() != "")
                _AttachmentCount = int.Parse(objDR["AttachmentCount"].ToString());
            if (objDR.Table.Columns["SectorJobNatureID"]!= null && objDR["SectorJobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDR["SectorJobNatureID"].ToString());
            if(objDR.Table.Columns["SectorJobNatureNameA"]!= null)
            _JobNatureTypeNameA = objDR["SectorJobNatureNameA"].ToString();
            if (objDR.Table.Columns["SectorJobCategoryOrder"] != null && objDR["SectorJobCategoryOrder"].ToString() != "")
                _JobNatureOrderValue = int.Parse(objDR["SectorJobCategoryOrder"].ToString());
            if (objDR.Table.Columns["PreviousBaseSalary"]!= null && objDR["PreviousBaseSalary"].ToString() != "")
                _PreviousBaseSalary = double.Parse(objDR["PreviousBaseSalary"].ToString());
            if (objDR.Table.Columns["PreviousDetailsAmount"]!= null&& objDR["PreviousDetailsAmount"].ToString() != "")
                _PreviousDetailsValue = double.Parse(objDR["PreviousDetailsAmount"].ToString());
            if (objDR.Table.Columns["LastMotivationValue"] != null && objDR["LastMotivationValue"].ToString() != "")
                _LastMotivationValue = double.Parse(objDR["LastMotivationValue"].ToString());
            if (objDR.Table.Columns["LstMotivationAddedBonusValue"] != null &&
                objDR["LstMotivationAddedBonusValue"].ToString() != "")
                _LastMotivationAddedBonusValue = double.Parse(objDR["LstMotivationAddedBonusValue"].ToString());
            if (objDR.Table.Columns["LastMotivationStatementID"] != null &&
           objDR["LastMotivationStatementID"].ToString() != "")
            {
                _LastMotivationStatementID = int.Parse(objDR["LastMotivationStatementID"].ToString());
            }


            if (objDR.Table.Columns["ApplicantCostCenterID"] != null &&
           objDR["ApplicantCostCenterID"].ToString() != "")
                _CostCenter = int.Parse(objDR["ApplicantCostCenterID"].ToString());
            if (objDR.Table.Columns["ApplicantCostCenterName"] != null &&
                objDR["ApplicantCostCenterName"].ToString() != "")
                _CostCenterNameA = objDR["ApplicantCostCenterName"].ToString();

            if (objDR.Table.Columns["ApplicantMotivationCostCenterID"] != null &&
                objDR["ApplicantMotivationCostCenterID"].ToString() != "")
                _MotivationCostCenterID = int.Parse(objDR["ApplicantMotivationCostCenterID"].ToString());
            if (objDR.Table.Columns["ApplicantMotivationCostCenterName"] != null &&
                objDR["ApplicantMotivationCostCenterName"].ToString() != "")
                _MotivationCostCenterName = objDR["ApplicantMotivationCostCenterName"].ToString();
            if (objDR.Table.Columns["JobCategoryEstimationID"] != null && objDR["JobCategoryEstimationID"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDR["JobCategoryEstimationID"].ToString());
            if (objDR.Table.Columns["JobCategoryEstimationNameA"] != null )
                _JobCategoryEstimationName = objDR["JobCategoryEstimationNameA"].ToString();
            if (objDR.Table.Columns["JobNatureID"] != null && objDR["JobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDR["JobNatureID"].ToString());
            if (objDR.Table.Columns["JobNatureNameA"] != null)
                _JobNatureTypeNameA = objDR["JobNatureNameA"].ToString();
            if (objDR.Table.Columns["JobCategoryOrder"] != null && objDR["JobCategoryOrder"].ToString() != "")
                _JobNatureOrderValue = int.Parse(objDR["JobCategoryOrder"].ToString());
            if (objDR.Table.Columns["LastAttendanceStatement"] != null && objDR["LastAttendanceStatement"].ToString() != "")
                _LastAttendanceStatement = int.Parse(objDR["LastAttendanceStatement"].ToString());

            _AddedBonusValue = 0;
            double.TryParse(objDR["ApplicantAddedBonusValue"].ToString(), out _AddedBonusValue);
            _HasAddedBonus = _AddedBonusValue > 0;
            if(objDR.Table.Columns["ApplicantFellowShipSalaryOrMotivation"]!= null)
            int.TryParse(objDR["ApplicantFellowShipSalaryOrMotivation"].ToString(), out _FellowShipSalaryOrMotivation);


        }

        public void SetShortData(DataRow objDR)
        {
            _ID = int.Parse(objDR["ApplicantID"].ToString());
            _Name = objDR["ApplicantFirstName"].ToString();
            _FamousName = objDR["ApplicantFamousName"].ToString();
            _Code = objDR["ApplicantCode"].ToString();
            _StatusID = int.Parse(objDR["ApplicantStatusID"].ToString());
            _CurrentSalary = double.Parse(objDR["ApplicantCurrentSalary"].ToString());
            if (objDR.Table.Columns["ApplicantStartDate"] != null && objDR["ApplicantStartDate"].ToString() != "")
            {
                _StartDate = DateTime.Parse(objDR["ApplicantStartDate"].ToString());
                _StartDateStatus = true;
            }
            if (objDR.Table.Columns["ApplicantStartExperienceDate"] != null && objDR["ApplicantStartExperienceDate"].ToString() != "")
            {

                _StartExperienceDateDecided = true;
                _StartExperienceDate = DateTime.Parse(objDR["ApplicantStartExperienceDate"].ToString());

            }
            //if (objDR.Table.Columns["ApplicantStartDate"] != null && objDR["ApplicantStartDate"].ToString() != "")
            //    _StartDate = DateTime.Parse(objDR["ApplicantStartDate"].ToString());
            _IsFellowShip = bool.Parse(objDR["IsFellowShip"].ToString());
            if (objDR.Table.Columns["FellowShipCredit"] != null && objDR["FellowShipCredit"].ToString() != "")
                _FellowShipCredit = double.Parse(objDR["FellowShipCredit"].ToString());
            //if (objDR.Table.Columns["FellowShipValue"] != null && objDR["FellowShipValue"].ToString() != "")
            //    _FellowShipValue = double.Parse(objDR["FellowShipValue"].ToString());
            if (objDR.Table.Columns["ApplicantSectorID"] != null && objDR["ApplicantSectorID"].ToString() != "")
                _SectorID = int.Parse(objDR["ApplicantSectorID"].ToString());
            if (objDR.Table.Columns["ApplicantSectorNameA"] != null)
                _SectorNameA = objDR["ApplicantSectorNameA"].ToString();
            if (objDR.Table.Columns["ApplicantBranchID"] != null && objDR["ApplicantBranchID"].ToString() != "")
                _BranchID = int.Parse(objDR["ApplicantBranchID"].ToString());
            if (objDR.Table.Columns["ApplicantBranchNameA"] != null)
                _BranchNameA = objDR["ApplicantBranchNameA"].ToString();
            if (objDR.Table.Columns["ApplicantSubSectorID"] != null && objDR["ApplicantSubSectorID"].ToString() != "")
                _SubSectorID = int.Parse(objDR["ApplicantSubSectorID"].ToString());


            if (objDR.Table.Columns["ApplicantCostCenterID"] != null &&
              objDR["ApplicantCostCenterID"].ToString() != "")
                _CostCenter = int.Parse(objDR["ApplicantCostCenterID"].ToString());
            if (objDR.Table.Columns["ApplicantCostCenterName"] != null &&
                objDR["ApplicantCostCenterName"].ToString() != "")
                _CostCenterNameA = objDR["ApplicantCostCenterName"].ToString();
           
            if (objDR.Table.Columns["ApplicantMotivationCostCenterID"] != null &&
                objDR["ApplicantMotivationCostCenterID"].ToString() != "")
                _MotivationCostCenterID = int.Parse(objDR["ApplicantMotivationCostCenterID"].ToString());
            if (objDR.Table.Columns["ApplicantMotivationCostCenterName"] != null &&
                objDR["ApplicantMotivationCostCenterName"].ToString() != "")
                _MotivationCostCenterName = objDR["ApplicantMotivationCostCenterName"].ToString();
            if (objDR.Table.Columns["SectorJobNatureID"]!= null && objDR["SectorJobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDR["SectorJobNatureID"].ToString());
           if(objDR.Table.Columns["SectorJobNatureNameA"]!= null)
            _JobNatureTypeNameA = objDR["SectorJobNatureNameA"].ToString();
            if (objDR.Table.Columns["SectorJobCategoryOrder"] != null && objDR["SectorJobCategoryOrder"].ToString() != "")
                _JobNatureOrderValue = int.Parse(objDR["SectorJobCategoryOrder"].ToString());
            if (objDR.Table.Columns["LastAttendanceStatement"] != null && objDR["LastAttendanceStatement"].ToString() != "")
                _LastAttendanceStatement = int.Parse(objDR["LastAttendanceStatement"].ToString());


            if(objDR.Table.Columns["ApplicantAccountBankNo"]!= null)
            _AccountBankNo = objDR["ApplicantAccountBankNo"].ToString();

            if (objDR.Table.Columns["ApplicantBankID"]!= null&& objDR["ApplicantBankID"].ToString() != "")
                _AccountBankID = int.Parse(objDR["ApplicantBankID"].ToString());
            try
            {
                _AccountBankBranchCode = objDR["ApplicantAccountBankBranchCode"].ToString();
            }
            catch { }
            try
            {
                _AccountTypeCode = objDR["ApplicantAccountBankAccountTypeCode"].ToString();
            }
            catch { }
            if(objDR.Table.Columns["ApplicantBankName"]!= null)
            _AccountBankName = objDR["ApplicantBankName"].ToString();
            if (objDR.Table.Columns["PartTimeUnit"] != null && objDR["PartTimeUnit"].ToString() != "")
                _PartTimeUnit = byte.Parse(objDR["PartTimeUnit"].ToString());
            if (objDR.Table.Columns["PartTimeUnitValue"] != null && objDR["PartTimeUnitValue"].ToString() != "")
            {
                _PartTimeUnitValue = double.Parse(objDR["PartTimeUnitValue"].ToString());
                _IsPartTime =true;
            }
            if (objDR.Table.Columns["ApplicantJobEstimationID"] != null &&
                objDR["ApplicantJobEstimationID"].ToString() != "")
            {
                _JobCategoryEstimation = int.Parse(objDR["ApplicantJobEstimationID"].ToString());
            }
            if (objDR.Table.Columns["ApplicantJobEstimaionName"] != null)
                _JobCategoryEstimationName = objDR["ApplicantJobEstimaionName"].ToString();
            if (objDR.Table.Columns["LastMotivationStatementID"] != null &&
              objDR["LastMotivationStatementID"].ToString() != "")
            {
                _LastMotivationStatementID = int.Parse(objDR["LastMotivationStatementID"].ToString());
            }
            if (objDR.Table.Columns["ApplicantBirthDate"] != null && objDR["ApplicantBirthDate"].ToString() != "")
                _BirthDate = DateTime.Parse(objDR["ApplicantBirthDate"].ToString());
            _AddedBonusValue = 0;
            double.TryParse(objDR["ApplicantAddedBonusValue"].ToString(), out _AddedBonusValue);
            _HasAddedBonus = _AddedBonusValue > 0;
            if (objDR.Table.Columns["ApplicantFellowShipSalaryOrMotivation"] != null)
                int.TryParse(objDR["ApplicantFellowShipSalaryOrMotivation"].ToString(), out _FellowShipSalaryOrMotivation);

        }
        public void SetPreviousSalaryData(DataRow objDR)
        {
            if (objDR.Table.Columns["Applicant"] != null && objDR["Applicant"].ToString() != "")
                _ID = int.Parse(objDR["Applicant"].ToString());
            if (objDR.Table.Columns["PreviousBaseSalary"] != null && objDR["PreviousBaseSalary"].ToString() != "")
                _PreviousBaseSalary= double.Parse(objDR["PreviousBaseSalary"].ToString());
            if (objDR.Table.Columns["PreviousDetailsAmount"] != null && objDR["PreviousDetailsAmount"].ToString() != "")
                _PreviousDetailsValue = double.Parse(objDR["PreviousDetailsAmount"].ToString());

        }

        public DataTable GetApplicantWorker()
        {
            string strSql = " SELECT     HRApplicant.ApplicantID FROM         HRApplicant LEFT OUTER JOIN " +
                            " HRApplicantWorker ON HRApplicant.ApplicantID = HRApplicantWorker.ApplicantID Where 1=1 ";
            if (_ApplicantWorkerID != 0)
                strSql += " And HRApplicant.ApplicantID <> " + _ApplicantWorkerID + "";
            if (_NameComp != "")
                strSql += " And (ApplicantNameComp = '" + SharpVision.SystemBase.SysUtility.ReplaceStringComp(_NameComp) + "')";
            if (_Code != "")
                strSql += " AND (ApplicantCode = '" + _Code + "')";

            return SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        void JoinCurrentSubSector()
        {
            string[] arrStr = new string[_SubSectorTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerCurrentSubSector where ApplicantID = " + _ID;

            if (_SubSectorTable == null || _SubSectorTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantWorkerCurrentSubSectorDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _SubSectorTable.Rows)
                {
                    objDb = new ApplicantWorkerCurrentSubSectorDb(objDr, true);
                    objDb.ApplicantWorkerID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinCostCenter()
        {
            string[] arrStr = new string[_CostCenterTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerCostCenter where Applicant = " + _ID;

            if (_CostCenterTable == null || _CostCenterTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantWorkerCostCenterDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _CostCenterTable.Rows)
                {
                    objDb = new ApplicantWorkerCostCenterDb(objDr);
                    objDb.Applicant = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinMotivationCostCenter()
        {
            string[] arrStr = new string[_MotivationCostCenterTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerMotivationCostCenter where Applicant = " + _ID;

            if (_MotivationCostCenterTable == null || _MotivationCostCenterTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantWorkerMotivationCostCenterDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _MotivationCostCenterTable.Rows)
                {
                    objDb = new ApplicantWorkerMotivationCostCenterDb(objDr);
                    objDb.Applicant = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinAccount()
        {
            if (_AccountTable == null || _AccountTable.Rows.Count == 0)
                return;
            ApplicantBankAccountDb objDb;
            List<string> arrSql = new List<string>();
            foreach (DataRow objDr in _AccountTable.Rows)
            {
                objDb = new ApplicantBankAccountDb(objDr);
                objDb.Applicant = ID;
                if (objDb.ID == 0)
                    arrSql.Add(objDb.AddStr);
                else
                    arrSql.Add(objDb.EditStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrSql);

        }

        public static void SetCashTable()
        {
            CashCompanyTable = null;
            CashDegreeTable = null;
            CashCourseTable = null;
            CashContactTable = null;
            CashLanguageTable = null;
            CashRequestTable = null;
            CashScientificDegreeTable = null;
            CashInterestFieldTable = null;
            _CacheSubSectorTable = null;
            _CacheCurrentSubSectorTable = null;
            _CacheCostCenterTable = null;
            _CacheMotivationCostCenterTable = null;
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            //if (base.ID == 0)
            //    base.Add();
            //else
            //    base.Edit();

            string strSql = "begin transaction Trans1; " +
                "  declare @ID int ; begin try" +
                base.AddStr;
            strSql +=  " set @ID = (select @@IDENTITY as expr1) ";
            strSql += AddStr;
            strSql += " commitline: commit transaction Trans1;select  @ID as exp1 ; return ; ";
            strSql += " END TRY ";
            strSql += " BEGIN CATCH ";
            strSql += " rolLine: RollBack TRAN Trans1 ; set @ID = 0 ;";
            strSql += " END CATCH "+
                "  select @ID as Exp ";
          _ID =  (int)  SystemBase.SysData.SharpVisionBaseDb.ReturnScalar(strSql);
          if (_ID == 0)
              return;
            JoinData();
            if (_IsPartTime)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(AddPartTimeStr);
            JoinCurrentSubSector();
            JoinCostCenter();
            JoinMotivationCostCenter();
            JoinAccount();
        }
        public override void Edit()
        {
            base.Edit();

            if (_IsPartTime)
            {
                SysData.SharpVisionBaseDb.ExecuteNonQuery(AddPartTimeStr);
                SysData.SharpVisionBaseDb.ExecuteNonQuery(EditPartTimeStr);
            }
            else
                SysData.SharpVisionBaseDb.ExecuteNonQuery("delete from HRApplicantWorkerPartTime where Applicant=" + _ID);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            JoinCurrentSubSector();
            JoinCostCenter();
            JoinMotivationCostCenter();
            JoinAccount();
        }
        public void EditCostCenter()
        {
            if (_CostCenter == 0 || _IDs == null || _IDs == "")
                return;
            string strSql = "delete from HRApplicantWorkerCostCenter where CostCenter=" + _CostCenter + " or Applicant in(" + _IDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "INSERT INTO HRApplicantWorkerCostCenter " +
                          " SELECT     ApplicantID, "+ _CostCenter +" AS CostCenter " +
                          " FROM         dbo.HRApplicantWorker " +
                          " WHERE     (ApplicantID in ("+ _IDs +")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void EditPartTime()
        {
            string strSql = "update HRApplicantWorker set ApplicantCurrentSalary=0 "+
                " where ApplicantID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddPartTimeStr);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditPartTimeStr);
         
        }
        public void DeletePartTime()
        {
            string strSql = "update HRApplicantWorker set ApplicantCurrentSalary=0 " +
                " where ApplicantID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeletePartTimeStr);           
        }
        public void EditStatus(byte byUpdateEndFinancialStatement)
        {
            if (byUpdateEndFinancialStatement == 0)
            {
                double dblEndDate = _EndDate.ToOADate() - 2;
                string strEndDate = _StatusID != 1 ? dblEndDate.ToString() : "null";

                string strSql = " UPDATE    HRApplicantWorker" +
                                " SET   ApplicantStatusID= " + _StatusID + ",ApplicantEndDate = " + strEndDate + " ";

                if (_StatusID == 1)
                {
                    strSql += " , LastAttendanceStatement = 0";
                    strSql += " , LastFinancialStatement = 0";
                }
                if (_StatusID == 2)
                {
                    strSql += " , IsFellowShip = 0";
                }

                strSql += " Where ApplicantID = " + _ID + "";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else if (byUpdateEndFinancialStatement == 1)
            {
                string strSql = " UPDATE    HRApplicantWorker" +
                                " SET   LastFinancialStatement = 0 ";

                strSql += " Where ApplicantID = " + _ID + "";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public void EditLastAttendanceStatement()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                            " SET   LastAttendanceStatement=" + _LastAttendanceStatement +
                            " Where ApplicantID = " + _ID + "";
            strSql = " update HRApplicantWorker set LastAttendanceStatement = dbo.HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID "+
                    "  FROM     dbo.HRApplicantWorker INNER JOIN "+
                    " dbo.HRApplicantWorkerAttendanceStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerAttendanceStatement.Applicant INNER JOIN "+
                    " dbo.HRAttendanceStatement ON dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment = dbo.HRAttendanceStatement.StatementID AND  "+
                     " dbo.GetApproximateDate(dbo.HRApplicantWorker.ApplicantEndDate) >= dbo.HRAttendanceStatement.StatementFrom AND  "+
                     "  dbo.GetApproximateDate(dbo.HRApplicantWorker.ApplicantEndDate) <= dbo.HRAttendanceStatement.StatementTo "+
                     " WHERE      (dbo.HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID = "+ _LastAttendanceStatement +") AND  "+
                         " (dbo.HRApplicantWorker.ApplicantID = "+ _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditLastFinancialStatement()
        {
            string strSql = " UPDATE    HRApplicantWorker" +
                           " SET   LastFinancialStatement=" + _LastFinancialStatement +
                           " Where ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public override DataTable Search()
        {
            SetCashTable();
            string strSql = StrSearch;
            _CacheApplicantTable = SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql);





            if (_ID == 0 && (_IDs == null || _IDs == "")&& _CacheApplicantTable!= null)
            {
                List<string> arrStr = SysUtility.GetStringArr(_CacheApplicantTable, "ApplicantID", 10000);
               // _ApplicantIDs = "select ApplicantID from (" + Returned + ") as NativeTable";
                _ApplicantIDs = "";
                if (arrStr.Count> 0)
                    _ApplicantIDs = arrStr[0];
            }

            ApplicantDb.ApplicantIDs = _ApplicantIDs;
            return _CacheApplicantTable;

        }
        public DataTable Search1()
        {
            SetCashTable();
            string strSql = SearchStr + " Where 1=1 And HRApplicantWorker.ApplicantID is not null";
            #region Applicant Data Search
            if (_ID != 0)
                strSql = strSql + " And (HRApplicant.ApplicantID = " + _ID + ")";
            if (_User != 0)
                strSql += " and (HRApplicantWorker.ApplicantUser = " + _User + ")";
            if (_ApplicantSearchIDs != null && _ApplicantSearchIDs != "")
                strSql = strSql + " And (HRApplicant.ApplicantID in (" + _ApplicantSearchIDs + "))";


            if (_NameLike != null && _NameLike != "")
                strSql = strSql + " And ApplicantFirstName Like '%" + _NameLike + "%'";

            if (_NameCompLike != null && _NameCompLike != "")
                strSql = strSql + " And ApplicantNameComp Like '%" + _NameCompLike + "%'";


            if (_FamousNameLike != null && _FamousNameLike != "")
                strSql = strSql + " And ApplicantFamousName Like '%" + _FamousNameLike + "%'";

            if (_CodeLike != null && _CodeLike != "")
                //strSql = strSql + " And ApplicantCode Like '%" + _CodeLike + "%'";
                strSql = strSql + " And ApplicantCode = '" + _CodeLike + "'";// and ApplicantStatusID=1 ";

            if (_CodesSearch != null && _CodesSearch != "")
                strSql = strSql + " And ApplicantCode in ( " + _CodesSearch + ")";// and ApplicantStatusID=1 ";


            if (_InsuranceStatusSearch == true)
            {
                strSql = strSql + " And ApplicantInsuranceNo Is Not Null And ApplicantInsuranceNo <> ''";
                if(_InsuranceValueSearch!=null && _InsuranceValueSearch !="")
                    strSql = strSql + " And ApplicantInsuranceNo Like '%" + _InsuranceValueSearch + "%'";
            }

            if(_intInsuranceStatusSearch!=0)
            {
                if (_intInsuranceStatusSearch == 1)
                {
                    strSql = strSql + " And ApplicantInsuranceNo Is Not Null And ApplicantInsuranceNo <> ''";
                    if (_InsuranceValueSearch != null && _InsuranceValueSearch != "")
                        strSql = strSql + " And ApplicantInsuranceNo Like '%" + _InsuranceValueSearch + "%'";
                }
                else if (_intInsuranceStatusSearch == 2)
                {
                    strSql = strSql + " And ApplicantInsuranceNo Is Null OR ApplicantInsuranceNo = ''";
                }
            }
            if (_FellowShipeStatusSearch != 0)
            {
                if (_FellowShipeStatusSearch == 1)
                {
                    strSql += " and (IsFellowShip = 1)";
                }
                else if (_FellowShipeStatusSearch == 2)
                {
                    strSql += " and (IsFellowShip = 0)";
                }
            }
            if (!(_ReligionIDSearch <= 0))
                strSql = strSql + " And (ApplicantReligionID = " + _ReligionIDSearch + ")";
            if (_RegionIDSearch != 0)
                strSql = strSql + " And ApplicantRegionID = " + _RegionIDSearch + "";
            if (_AddressLike != null && _AddressLike != "")
                strSql = strSql + " And ApplicantAddress = '%" + _AddressLike + "%'";
            if (_BirthDateStatusSearch != 0)
            {
                if (_BirthDateStatusSearch == 1)
                {
                    int intFrom;
                    DateTime dtFrom = new DateTime(_BirthDateFromSearch.Year, _BirthDateFromSearch.Month, _BirthDateFromSearch.Day);
                    DateTime dtTo = new DateTime(_BirthDateToSearch.Year, _BirthDateToSearch.Month, _BirthDateToSearch.Day);
                    //dtTo = dtTo.AddDays(1);
                    double d = dtFrom.ToOADate() - 2;
                    //intFrom = (int)d;

                    int intTo;
                    double dd = dtTo.ToOADate() - 1;
                    //intTo = (int)dd  +1;

                    strSql = strSql + " And ApplicantBirthDate Between " + d + " and " + dd + "";
                }
                else if (_BirthDateStatusSearch == 2)
                {
                    strSql = strSql + " And ( (ApplicantBirthDate IS NULL) OR "+
                                      " (ApplicantBirthDate = '') OR "+
                                      " (YEAR(ApplicantBirthDate) = '1900'))";
                }
                
            }
            if (_StartDateStatusSearch != 0)
            {
                if (_StartDateStatusSearch == 1)
                {
                    int intFrom;
                    DateTime dtFrom = new DateTime(_StartDateFromSearch.Year, _StartDateFromSearch.Month, _StartDateFromSearch.Day);
                    DateTime dtTo = new DateTime(_StartDateToSearch.Year, _StartDateToSearch.Month, _StartDateToSearch.Day);
                    //dtTo = dtTo.AddDays(1);
                    double d = dtFrom.ToOADate() - 2;
                    //intFrom = (int)d;

                    int intTo;
                    double dd = dtTo.ToOADate() - 1;
                    //intTo = (int)dd  +1;
                    //if(dd>0)
                    //    dd = SysUtility.Approximate( DateTime.Now.ToOADate()-2
                    strSql = strSql + " And ApplicantStartDate Between " + d + " and " + dd + "";
                }
                else if (_StartDateStatusSearch == 2)
                {
                    strSql = strSql + " And ( (ApplicantStartDate IS NULL) OR " +
                                      " (ApplicantStartDate = '') OR " +
                                      " (YEAR(ApplicantStartDate) = '1900'))";
                }

            }
            if (_StartDateStatusWithApplicantStatusSearch != 0)
            {
                if (_StartDateStatusWithApplicantStatusSearch == 1)
                {
                    int intFrom;
                    DateTime dtFrom = new DateTime(_StartDateFromWithApplicantStatusSearch.Year, _StartDateFromWithApplicantStatusSearch.Month, _StartDateFromWithApplicantStatusSearch.Day);
                    DateTime dtTo = new DateTime(_StartDateToWithApplicantStatusSearch.Year, _StartDateToWithApplicantStatusSearch.Month, _StartDateToWithApplicantStatusSearch.Day);
                    //dtTo = dtTo.AddDays(1);
                    double dblFrom = dtFrom.ToOADate() - 2;
                    //intFrom = (int)d;

                    int intTo;
                    double dblTo = dtTo.ToOADate() - 1;
                    //intTo = (int)dd  +1;
                    if (_StartDateToWithApplicantStatusSearch.Year != 1900)
                    {

                        string strWorkingDate = "";
                        if(_StatusIDSearch !=2)
                            strWorkingDate = " (ApplicantEndDate is null and ApplicantStatusID =1)  or  ";
                   // strWorkingDate = "";
                        string strDate = " and ApplicantStartDate<" + dblTo;
                        strDate += " and ("+ strWorkingDate +" ApplicantEndDate>" + dblFrom + "  )";
                        strSql = strSql + strDate;//" And ApplicantStartDate Between " + dblFrom + " and " + dblTo + "";
                    }
                    else
                        strSql = strSql + " And ApplicantStartDate > " + dblFrom + "";
                }
                else if (_StartDateStatusSearch == 2)
                {
                    strSql = strSql + " And ( (ApplicantStartDate IS NULL) OR " +
                                    " (ApplicantStartDate = '') OR " +
                                    " (YEAR(ApplicantStartDate) = '1900'))";
                }
            }
            if (_EndDateStatusSearch == true)
            {
                int intFrom;
                DateTime dtFrom = new DateTime(_EndDateFromSearch.Year, _EndDateFromSearch.Month, _EndDateFromSearch.Day);
                DateTime dtTo = new DateTime(_EndDateToSearch.Year, _EndDateToSearch.Month, _EndDateToSearch.Day);
                //dtTo = dtTo.AddDays(1);
                double d = dtFrom.ToOADate() - 2;
                //intFrom = (int)d;

                int intTo;
                double dd = dtTo.ToOADate() - 1;
                //intTo = (int)dd  +1;

                strSql = strSql + " And ApplicantEndDate Between " + d + " and " + dd + "";

                
            }
            if (_InsuranceDateStatusSearch == true)
            {
                int intFrom;
                double d = _InsuranceDateFromSearch.ToOADate() - 2;
                intFrom = (int)d;

                int intTo;
                double dd = _InsuranceDateToSearch.ToOADate() - 2;
                intTo = (int)dd + 1;

                strSql = strSql + " And ApplicantInsuranceDate >= " + intFrom + " and  ApplicantInsuranceDate <= " + intTo + "";
            }
            if (_HasMotivationSearch != 0)
            {
                if (_HasMotivationSearch == 1)
                    strSql = strSql + " And ( HasMotivation = 1) ";
                else if (_HasMotivationSearch == 2)
                    strSql = strSql + " And ( HasMotivation = 0) ";
            }
            if (_MaritalStatusIDSearch != 0)
                strSql = strSql + " And ApplicantMaritalStatus = " + _MaritalStatusIDSearch + "";
            if (_MiltaryStatusIDSearch != 0)
                strSql = strSql + " And ApplicantMiltaryStatus = " + _MiltaryStatusIDSearch + "";
            if (_CommonServiceIDSearch != 0)
                strSql = strSql + " And ApplicantCommonService = " + _CommonServiceIDSearch + "";
            if (_TypeIDSearch != 0)
                strSql = strSql + " And ApplicantSexTypeID = " + _TypeIDSearch + "";


            if (_IDTypeSearch != 0)
                strSql = strSql + " And ApplicantIDType = " + _IDTypeSearch + "";
            if (_IDValSearch != 0)
                strSql = strSql + " And ApplicantIDValue = '" + _IDValSearch + "'";
            #endregion
            if (_StatusIDSearch != 0 && _AttendanceStatementID == 0 && _GlobalStatementID == 0)
            {
                int intStatusIDSearch = _StatusIDSearch;
                if(_StatusIDSearch == 1)
                    strSql += " and NonDiscountedCreditApplicant is  null ";
                if (_StatusIDSearch == 6)
                {
                    strSql += " and NonDiscountedCreditApplicant is not null ";
                    intStatusIDSearch = 1;
                }
                strSql = strSql + " And (ApplicantStatusID = " +intStatusIDSearch + ")";

                //if (_IncludeRecentlyFinishWorkSearch == false)
                //{
                //    strSql = strSql + " And (ApplicantStatusID = " + _StatusIDSearch + ")";
                //}
                //else
                //{
                //    strSql = strSql + " And ((ApplicantStatusID = " + _StatusIDSearch + ") or ()";
                //}
            }
            if (_WorkingStatus != 0)
            {

                if (_WorkingStatus == 1)
                    strSql += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is  null ";
                else if (_WorkingStatus == 3)
                {
                    strSql += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is not null ";

                }
                else if (_WorkingStatus == 5)
                    strSql += " and ApplicantStatusID = 1 and NonDiscountedCreditApplicant is  null ";
                else if (_WorkingStatus == 2)
                {
                    strSql += " and ApplicantStatusID <>1 ";
                    if (_IsHasLastFinantial != 0)
                    {
                        if (_IsHasLastFinantial == 1)
                        {
                            strSql += " and LastFinancialStatement = 0 ";
                        }
                    }
                }
                else
                    strSql += " and ApplicantStatusID = 1   ";

               
            }
            //if (_StatusIDSearch != 0)
            //{

            //    strSql = strSql + " And (ApplicantStatusID = " + _StatusIDSearch + ")";
            //}
            #region Job Features
            if (_ScientificDegreeIDSearch != 0 || _DegreeFieldIDSearch != 0 || _DegreeSubFieldIDSearch != 0 || _GraduationYearFromSearch != 0 || _GraduationYearToSearch != 0 || _DegreeFieldIDSearch != 0 || _DegreeSubFieldIDSearch != 0)
            {
                string strEduactionQualified = "";
                string strGraduationYearFrom = "";
                string strGraduationYearTo = "";
                string strDegreeField = "";
                string strDegreeSubField = "";

                if (_ScientificDegreeIDSearch != 0)
                    strEduactionQualified = " And HRApplicantScientificDegree.ScientificDegreeID = " + _ScientificDegreeIDSearch + "";
                if (_DegreeFieldIDSearch != 0)
                    strDegreeField = " And HRApplicantScientificDegree.DegreeFieldID = " + _DegreeFieldIDSearch + "";
                if (_DegreeSubFieldIDSearch != 0)
                    strDegreeSubField = " And HRApplicantScientificDegree.DegreeSubFieldID = " + _DegreeSubFieldIDSearch + "";

                if (_GraduationYearFromSearch != 0)
                    strGraduationYearFrom = " And HRApplicantScientificDegree.GraduationYear >= " + _GraduationYearFromSearch + "";
                if (_GraduationYearToSearch != 0)
                    strGraduationYearTo = " And HRApplicantScientificDegree.GraduationYear <= " + _GraduationYearToSearch + "";

                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubTable.ApplicantID from (" + ApplicantScientificDegreeDb.SearchStr + " Where 1=1 " + strEduactionQualified + " " + strGraduationYearFrom + " " + strGraduationYearTo + " " + strDegreeField + " " + strDegreeSubField + ") SubTable)";
            }
            if (_JobTypeIDSearch != 0 || _JobNatureTypeIDSearch != 0 || _JobTitleTypeIDSearch != 0)
            {
                string strJobTypeID = "";
                string strJobTitleTypeID = "";
                string strJobNatureTypeID = "";

                if (_JobTypeIDSearch != 0)
                    strJobTypeID = " And HRApplicantCompany.JobTypeID = " + _JobTypeIDSearch + "";
                if (_JobTitleTypeIDSearch != 0)
                    strJobTitleTypeID = " And  HRApplicantCompany.JobTitleTypeID = " + _JobTitleTypeIDSearch + "";
                if (_JobNatureTypeIDSearch != 0)
                    strJobNatureTypeID = " And HRApplicantCompany.JobNatureTypeID = " + _JobNatureTypeIDSearch + "";

                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubCompanyTable.ApplicantID from (" + ApplicantCompanyDb.SearchStr + " Where 1=1 " + strJobTypeID + " " + strJobTitleTypeID + " " + strJobNatureTypeID + " ) SubCompanyTable)";
            }
            if (_SJobTypeIDSearch != 0 || _SJobNatureTypeIDSearch != 0 || _SJobTitleTypeIDSearch != 0)
            {
                string strJobTypeID = "";
                string strJobTitleTypeID = "";
                string strJobNatureTypeID = "";

                if (_SJobTypeIDSearch != 0)
                    strJobTypeID = " And HRApplicantWorkerCurrentSubSector.JobID = " + _SJobTypeIDSearch + "";
                if (_SJobTitleTypeIDSearch != 0)
                    strJobTitleTypeID = " And  HRApplicantWorkerCurrentSubSector.JobTitleID = " + _SJobTitleTypeIDSearch + "";
                if (_SJobNatureTypeIDSearch != 0)
                    strJobNatureTypeID = " And HRApplicantWorkerCurrentSubSector.JobNatureID = " + _SJobNatureTypeIDSearch + "";

                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubCurrentSubSectorTable.ApplicantID from (" + ApplicantWorkerCurrentSubSectorDb.SearchStr + " Where 1=1 " + strJobTypeID + " " + strJobTitleTypeID + " " + strJobNatureTypeID + " ) SubCurrentSubSectorTable)";
            }
            if ((_JobIDs!= null && _JobIDs!= "") ||    _JobIDSearch != 0 || _SectorIDSearch != 0 || _SubSectorIDSearch != 0 || _BranchIDSearch != 0 || _CellIDSearch != 0 || _StoreIDSearch != 0)
            {
                string strJob = "";
                string strSector = "";
                string strSubSector = "";
                string strBranch = "";
                string strCell = "";
                string strStore = "";
                if (_JobIDSearch != 0)
                    strJob = " And HRApplicantWorkerCurrentSubSector.JobID = " + _JobIDSearch + "";
                if (_JobIDs != null && _JobIDs != "")
                    strJob = " And HRApplicantWorkerCurrentSubSector. JobNatureID in  (" + _JobIDs + ")";
                if (_SectorIDSearch != 0)
                {
                    strSector = " And SectorID = " + _SectorIDSearch + " Or SectorFamilyID = " + _SectorIDSearch + " ";//Or SectorParentID = "+ _SectorIDSearch +"";
                }
                if (_SubSectorIDSearch != 0)
                    strSubSector = " And SubSectorTable.SubSectorID = " + _SubSectorIDSearch + "";
                if (_BranchIDSearch != 0)
                    strBranch = " And BranchID = " + _BranchIDSearch + "";
                if (_CellIDSearch != 0)
                    strCell = " And CellID = " + _CellIDSearch + "";
        
                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubTable1.ApplicantID from (" + ApplicantWorkerCurrentSubSectorDb.SearchStr + " Where 1=1 " + strJob + " " + strSector + " " + strSubSector + " " + strBranch + " " + strCell + " " + strStore + " ) SubTable1)";
            }

            #endregion

            if (_SectorIDs != null && _SectorIDs != "")
            {
                strSql += " and HRApplicant.ApplicantID in (SELECT   dbo.HRApplicantWorkerCurrentSubSector.ApplicantID "+
               " FROM         dbo.HRSector INNER JOIN "+
               " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID INNER JOIN "+
               " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRSubSector.SubSectorID = dbo.HRApplicantWorkerCurrentSubSector.SubSectorID "+
              " WHERE     (dbo.HRSector.SectorID IN ("+ _SectorIDs +"))) ";
            }
            if (_SectorFamilyID != 0)
            {
                strSql += " and HRApplicant.ApplicantID in (SELECT   dbo.HRApplicantWorkerCurrentSubSector.ApplicantID " +
                            " FROM         dbo.HRSector INNER JOIN " +
                            " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID INNER JOIN " +
                            " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRSubSector.SubSectorID = dbo.HRApplicantWorkerCurrentSubSector.SubSectorID " +
                           " WHERE     (dbo.HRSector.SectorFamilyID =" + _SectorFamilyID + ")) ";
            }
           /* if (_AttendanceStatementID != 0)
            {
                if (_AttendanceStatementConsider != 0)
                {
                    //_StatusIDSearch != 0
                    string strAttendanceSql = "SELECT     Applicant " +
                                       " FROM   dbo.HRApplicantWorkerAttendanceStatement " +
                                       " WHERE     (AttendanceStatment = " + _AttendanceStatementID + ")";
                  

                    if (_AttendanceStatementConsider == 1)
                    {
                        strSql += " and HRApplicant.ApplicantID not in ("+ strAttendanceSql +")";
                        if (_StatusIDSearch ==1)
                            strSql += " and(ApplicantStatusID =1  or ( ApplicantEndDate is not null and LastAttendanceStatement =0 ))";
                    }
                    else if (_AttendanceStatementConsider == 2)
                    {
                        if (_AttendanceStatementIsSumStatusSearch == true)
                        {
                            if (_AttendanceStatementIsSum)
                                strAttendanceSql += " and AtendanceStatementIsSum =1 ";
                            else
                                strAttendanceSql += " and AtendanceStatementIsSum =0 ";                            
                        }
                        strSql += " and HRApplicant.ApplicantID  in (" + strAttendanceSql + ")";
                    }
                }

                double dlEndDate = _AttendanceStatementEndDate.ToOADate() - 2;
                strSql += " and (HRApplicantWorker.ApplicantStartDate  <= "+ dlEndDate +" )";                          

            }*/
           
            if (_AttendanceStatementIDs != null && _AttendanceStatementIDs != "")
            {
                string strAttendanceSql = "SELECT     Applicant " +
                                       " FROM   dbo.HRApplicantWorkerAttendanceStatement " +
                                       " WHERE     (AttendanceStatment in ( " + _AttendanceStatementIDs + "))";

                if (_AttendanceStatementApplicantStatus != 0)
                {
                    if (_AttendanceStatementApplicantStatus == 1)//Work
                        strAttendanceSql += " And IsEndStatement = 0";
                    else if (_AttendanceStatementApplicantStatus == 2)//not Work
                        strAttendanceSql += " And IsEndStatement = 1";
                }
                strSql += " and HRApplicant.ApplicantID  in (" + strAttendanceSql + ")";
            }
            if (_GlobalStatementID != 0)
            {
                    if (_AvoidNoSalaryVacation == 1)
                    {

                        string strNonSalary = "SELECT  VacationApplicantID as Applicant " +
                              " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                     " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                     " Cross join  dbo.HRGlobalStatement   " +
                     " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                     "  AND ( dbo.HRGlobalStatement.StatementDate > VacationFrom) AND (dbo.HRGlobalStatement.StatementDateTo < VacationTo) and dbo.HRGlobalStatement.StatementID= " + _GlobalStatementID;
                        strSql += " and HRApplicant.ApplicantID not in (" + strNonSalary + ")";
 
                    }
                if (_GlobalStatementConsider != 0)
                {
                    string strStatement = " SELECT     Applicant " +
                                       " FROM          dbo.HRApplicantWorkerStatement INNER JOIN "+
                                       " dbo.GLOriginStatement ON dbo.HRApplicantWorkerStatement.OriginStatementID = dbo.GLOriginStatement.OriginStatementID "+
                                       " WHERE     (GlobalStatment = " + _GlobalStatementID + ")";

                    if (_StatementReviewedStatus != 0)
                    {
                       // string strTemp = strStatement;
                        if (_StatementReviewedStatus == 1)
                        {
                            strStatement += " and  dbo.GLOriginStatement.OriginStatementReviewed=0 ";
                        }
                        else if (_StatementReviewedStatus == 2)
                        {
                            strStatement += " and  dbo.GLOriginStatement.OriginStatementReviewed=1 ";
                        }
                     //   strStatement += " union " + strTemp;
                    }
                    if (_GlobalStatementConsider == 1)
                    {
                        strSql += " and HRApplicant.ApplicantID not in (" + strStatement + ")";
                        if (_StatusIDSearch == 1)
                            strSql += " and(ApplicantStatusID =1  or ( ApplicantEndDate is not null And LastFinancialStatement =0 ))";


                        double dlEndDate = _GlobalStatementEndDate.ToOADate() - 1;
                        strSql += " and (ApplicantStartDate  <= " + dlEndDate + " )";


                        double dlStartDate = _GlobalStatementStartDate.ToOADate() - 2;
                        //strSql += " and (ApplicantEndDate is Null OR ApplicantEndDate  Between " + dlStartDate + " and " + dlEndDate + " )";
                        strSql += " and (ApplicantEndDate is Null OR ApplicantEndDate  >= " + dlStartDate + " )";

                    }
                    else if (_GlobalStatementConsider == 2)
                    {
                        strSql += " and HRApplicant.ApplicantID  in (" + strStatement + ")";
                    }
                }

                //strSql += " And (HRApplicant.ApplicantID in (Select ApplicantOverDay from V_ApplicantOverDay))";

            }
            if (_InsDateStatusSearch == true)
            {
                double dblFrom = SysUtility.Approximate(_InsDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                double dblTo = SysUtility.Approximate(_InsDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                strSql = strSql + " And  HRApplicantWorker.TimIns Between " + dblFrom + " And " + dblTo + "";
            }           

            if (_UserIDSearch != 0)
            {
                strSql += " And HRApplicantWorker.UsrIns = " + _UserIDSearch + "";
            }

            if (_IsReviewedSearch == false)
            {                
                strSql = strSql + " And IsReviewed =  0 ";
            }
            if (_AttendanceStatementStatusSearch)
            {               
                if (_HasAttendanceStatementSearch == true)
                {
                    strSql = strSql + " And HasAttendanceStatement =  1 ";
                }
                else
                {
                    strSql = strSql + " And HasAttendanceStatement =  0 ";
                }
            }
            if (_TimeSheetStatusSearch)
            {
                if (_HasTimeShitSearch == true)
                {
                    strSql = strSql + " And HasTimeShit =  1 ";
                }
                else
                {
                    strSql = strSql + " And HasTimeShit =  0";
                }               
            }
            if (_IsReviewedSearch == false)
            {
                strSql = strSql + " And IsReviewed =  0 ";
            }
            if (_AccountBankNoSearch != 0)
            {
                if (_AccountBankNoSearch == 1)
                    strSql = strSql + " And (ApplicantAccountBankNo Is Not Null ) And (ApplicantAccountBankNo <> '' ) ";
                else if (_AccountBankNoSearch == 2)
                    strSql = strSql + " And ((ApplicantAccountBankNo Is Null) Or (ApplicantAccountBankNo = '') )";

            }
            if (_AccountBankNoLike != null && _AccountBankNoLike != "")
            {
                //strSql = strSql + " And (ApplicantAccountBankNo Like '%"+ _AccountBankNoLike +"%')";
                strSql = strSql + " And (ApplicantAccountBankNo = '" + _AccountBankNoLike + "')";
            }
            if (_IsPartTimeStatus !=0)
            {
                if (_IsPartTimeStatus == 1)
                    strSql += " and HRApplicantWorkerPartTime.PartTimeUnitValue is null ";
                else if(_IsPartTimeStatus == 2)
                    strSql += " and HRApplicantWorkerPartTime.PartTimeUnitValue is not null ";

            }
            if (_ApplicantWithloanSearch == true)
            {
                strSql += " and HRApplicant.ApplicantID in (SELECT     LoanApplicant FROM         HRApplicantWorkerLoan )";
            }
            if (_CostCenter != 0)
            {
                strSql += " and HRApplicant.ApplicantID in (SELECT     Applicant "+
                 " FROM         dbo.HRApplicantWorkerCostCenter "+
                 " WHERE     (CostCenter = "+ _CostCenter +") )";
            }
            if (_CostCenterCondiered != 0)
            {
                if (_CostCenterCondiered == 2)
                {
                    strSql += " and HRApplicant.ApplicantID in (SELECT     Applicant " +
                 " FROM  dbo.HRApplicantWorkerCostCenter) ";
                }
                else if(_CostCenterCondiered == 1)
                {
                    strSql += " and HRApplicant.ApplicantID not in (SELECT     Applicant " +
              " FROM  dbo.HRApplicantWorkerCostCenter) ";
                }
            }
            if (_EstimationStatementStatusSearch != 0)
            {
                if (_EstimationStatementIDSearch != 0)
                {
                    if (_EstimationStatementStatusSearch == 1)
                    {
                        strSql += " and ( HRApplicant.ApplicantID in "+
                                  " (SELECT     HRApplicantWorkerEstimationStatement.Applicant " +
                                  " FROM  dbo.HRApplicantWorkerEstimationStatement "+
                                  " Where HRApplicantWorkerEstimationStatement.EstimationStatement = " + _EstimationStatementIDSearch + ")) ";
                    }
                    else if (_EstimationStatementStatusSearch == 2)
                    {
                        strSql += " and ( HRApplicant.ApplicantID not in "+
                                  " (SELECT     HRApplicantWorkerEstimationStatement.Applicant " +
                                  " FROM  dbo.HRApplicantWorkerEstimationStatement "+
                                  " Where HRApplicantWorkerEstimationStatement.EstimationStatement = " + _EstimationStatementIDSearch + ")) ";
                    }
                    
                }
            }
            if (_MotivationStatementStatusSearch != 0)
            {
                if (_MotivationStatementIDSearch != 0)
                {
                    if (_MotivationStatementStatusSearch == 1)
                    {
                        strSql += " and ( HRApplicant.ApplicantID in " +
                                  " (SELECT     HRApplicantWorkerMotivationStatement.Applicant " +
                                  " FROM  dbo.HRApplicantWorkerMotivationStatement " +
                                  " Where HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatementIDSearch + " ";
                        if (_MotivationStatementCostCenterIDSearch != 0)
                            strSql += " And HRApplicantWorkerMotivationStatement.CostCenter=" + _MotivationStatementCostCenterIDSearch + "";
                        strSql += " )) ";
                        
                    }
                    else if (_MotivationStatementStatusSearch == 2)
                    {
                        strSql += " and ( HRApplicant.ApplicantID not in " +
                                  " (SELECT     HRApplicantWorkerMotivationStatement.Applicant " +
                                  " FROM  dbo.HRApplicantWorkerMotivationStatement " +
                                  " Where HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatementIDSearch + "";
                        if (_MotivationStatementCostCenterIDSearch != 0)
                            strSql += " And HRApplicantWorkerMotivationStatement.CostCenter=" + _MotivationStatementCostCenterIDSearch + "";
                        strSql += " )) ";
                    }

                }
            }
            if (_MonthSearch != 0)
            {

                   
                    if (_MonthSearch == 1)
                    {
                        //strSql += " AND HRApplicant.ApplicantID in ( SELECT     HRApplicantWorker.ApplicantID" +
                        //          " FROM HRApplicantWorkerVacationGrant RIGHT OUTER JOIN" +
                        //          " HRApplicantWorker ON HRApplicantWorkerVacationGrant.Applicant = HRApplicantWorker.ApplicantID" +
                        //          " WHERE "+
                        //          " (DATEDIFF(Day, HRApplicantWorker.ApplicantStartDate, GETDATE()) <= 132)) ";
                        strSql += " And (DATEDIFF(Day, HRApplicantWorker.ApplicantStartDate, GETDATE()) <= 132)";
                        if (_GrantSearch != 0)
                        {
                            if (_GrantSearch == 1)
                                strSql += " AND (HRApplicantWorkerVacationGrant.Applicant IS NOT NULL)";
                            else if (_GrantSearch == 2)
                                strSql += " AND (HRApplicantWorkerVacationGrant.Applicant IS  NULL)";
                        }                                  
                    }
                    else if (_MonthSearch == 2)
                    {
                        //strSql += " AND HRApplicant.ApplicantID in ( SELECT     HRApplicantWorker.ApplicantID" +
                        //         " FROM HRApplicantWorkerVacationGrant RIGHT OUTER JOIN" +
                        //         " HRApplicantWorker ON HRApplicantWorkerVacationGrant.Applicant = HRApplicantWorker.ApplicantID" +
                        //         " WHERE " +
                        //         " DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >132 And DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) <=365 )";
                        strSql += " And (DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >132 And DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) <=365)";
                        if (_GrantSearch != 0)
                        {
                            if (_GrantSearch == 1)
                                strSql += " AND (HRApplicantWorkerVacationGrant.VacationType = 1) AND(HRApplicantWorkerVacationGrant.Applicant IS NOT NULL)";
                            else if (_GrantSearch == 2)
                            //    strSql += " AND ((HRApplicantWorkerVacationGrant.VacationType =2) )";
                            strSql += " AND (HRApplicantWorkerVacationGrant.Applicant IS  NULL)";
                        }
                    }
                    else if (_MonthSearch == 3)
                    {
                        //strSql += " AND HRApplicant.ApplicantID in ( SELECT     HRApplicantWorker.ApplicantID" +
                        //       " FROM HRApplicantWorkerVacationGrant RIGHT OUTER JOIN" +
                        //       " HRApplicantWorker ON HRApplicantWorkerVacationGrant.Applicant = HRApplicantWorker.ApplicantID" +
                        //       " WHERE " +
                        //       " And DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >365) ";
                        strSql += " And (DateDiff(Day,HRApplicantWorker.ApplicantStartDate,getdate()) >365)";
                        if (_GrantSearch != 0)
                        {
                            int intFrom;
                            double d = _GrantDateFromSearch.ToOADate() - 2;
                            intFrom = (int)d;

                            int intTo;
                            double dd = _GrantDateToSearch.ToOADate() - 2;
                            intTo = (int)dd + 1;

                            string strGrant = " SELECT  Distinct VG.Applicant " +
                                              " FROM  HRApplicantWorkerVacationGrant VG  Where VG.VacationDateFrom between " + intFrom + " and  " + intTo + "";
                                              //" (" +
                                              //" (( " + intFrom + " >= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)   and " +
                                              //" " + intFrom + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo)) " +
                                              //" or (( " + intTo + ">= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom ) and " +
                                              //" " + intTo + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) ) )" +
                                              //" or (( " + intFrom + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)   and " +
                                              //" " + intTo + " >=  convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)  ) " +
                                              //"  ) or (( " + intFrom + "<= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) and " +
                                              //" " + intTo + " >= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) ) )))";



                            if (_GrantSearch == 1) //grant Between Date
                            {
                                strSql += " And HRApplicant.ApplicantID In   (" + strGrant + ")";
                            }
                            else if (_GrantSearch == 2) //not Grant Between Date
                            {
                                strSql += " And HRApplicant.ApplicantID Not In (" + strGrant + ")";
                            }

                            //if (_GrantSearch == 1)
                            //    strSql += " AND (HRApplicantWorkerVacationGrant.Applicant IS NOT NULL)";
                            //else if (_GrantSearch == 2)
                            //    strSql += " AND (HRApplicantWorkerVacationGrant.Applicant IS  NULL)";
                        }
                                   
                    }
                    
                    _MonthSearch = 0;
            }
            if (_GrantSearch != 0)
            {
                //int intFrom;
                //double d = _GrantDateFromSearch.ToOADate() - 2;
                //intFrom = (int)d;

                //int intTo;
                //double dd = _GrantDateToSearch.ToOADate() - 2;
                //intTo = (int)dd + 1;


                //string strGrant = " SELECT     distinct HRApplicantWorkerVacationGrant.Applicant" +
                //              " FROM  HRApplicantWorkerVacationGrant Where " +
                //              " (" +
                //              " (( " + intFrom + " >= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)   and " +
                //              " " + intFrom + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo)) " +

                //              " or (( " + intTo + ">= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom ) and " +
                //              " " + intTo + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) ) )" +

                //    " or (( " + intFrom + " <= convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)   and " +
                //    " " + intTo + " >=  convert(float,HRApplicantWorkerVacationGrant.VacationDateFrom)  ) " +
                //    "  ) or (( " + intFrom + "<= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) and " +
                //    " " + intTo + " >= convert(float,HRApplicantWorkerVacationGrant.VacationDateTo ) ) )))" +
                //              " ";

                //strGrant = " SELECT  Distinct VG.Applicant" +
                //           " FROM  HRApplicantWorkerVacationGrant VG  Where VG.VacationDateFrom between " + intFrom + " and  " + intTo + "";

                //if (_GrantSearch == 1) //grant Between Date
                //{
                //    strSql += " And HRApplicant.ApplicantID In   (" + strGrant + ")";
                //}
                //else if (_GrantSearch == 2) //not Grant Between Date
                //{
                //    strSql += " And HRApplicant.ApplicantID Not In (" + strGrant + ")";
                //}
            }

            //strSql = "select top 300 * from (" + strSql + ") as NativeTable";

            //strSql += " And ( HRApplicant.ApplicantID in (SELECT     Applicant FROM         HRApplicantWorkerAttendanceStatement" +
            //        " WHERE     (FinancialStatement IN " +
            //        " (SELECT     OriginStatementID " +
            //               " FROM         HRApplicantWorkerStatement " +
            //               " WHERE     (GlobalStatment = 22))) AND (AttendanceStatment = 22) ))";


            if (_AccountBankNoOrderSearch == true)
            {
                strSql += " ORDER BY CONVERT(bigint, REPLACE(HRApplicantWorker.ApplicantAccountBankNo, '/', ''))";
            }
            else
            {
                //strSql += " ORDER BY HRApplicantWorkerCurrentSubSector.BranchID ";
            }

            if (_GetFromViews != 0)
            {
                if (_GetFromViews == 1)
                {
                    //strSql += " And ( HRApplicant.ApplicantID in (Select Applicant From V_ApplicantOver50Year))"; 
                    strSql += " And ( HRApplicant.ApplicantID in (Select ApplicantID From V_SearchInHRView))";                     
                }
            }
            if (_AttendanceStatementID != 0)
            {
                if (_AvoidNoSalaryVacation == 1)
                {

                    string strNonSalary = "SELECT  VacationApplicantID as Applicant " +
                          " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                 " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                 " Cross join   dbo.HRAttendanceStatement   " +
                 " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                 "  AND ( dbo.HRAttendanceStatement.StatementFrom > VacationFrom) AND (dbo.HRAttendanceStatement.StatementTo < VacationTo) "+
                 " and dbo.HRAttendanceStatement.StatementID = " + _AttendanceStatementID;
                    strSql += " and HRApplicant.ApplicantID not in (" + strNonSalary + ")";

                }
                if (_AttendanceStatementConsider != 0)
                {
                    //_StatusIDSearch != 0
                    string strAttendanceSql = "SELECT  dbo.HRApplicantWorker.ApplicantID AttendanceApplicant " +
                      " FROM         dbo.HRAttendanceStatement INNER JOIN " +
                      " dbo.HRApplicantWorkerAttendanceStatement ON  " +
                      " dbo.HRAttendanceStatement.StatementID = dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment INNER JOIN " +
                      " dbo.HRApplicantWorker ON dbo.HRApplicantWorkerAttendanceStatement.Applicant = dbo.HRApplicantWorker.ApplicantID AND " +
                      " dbo.HRAttendanceStatement.StatementTO >= dbo.HRApplicantWorker.ApplicantStartDate " +
                      " WHERE     (dbo.HRAttendanceStatement.StatementID =" + _AttendanceStatementID + ")";
                   
                    strSql = " select ApplicantTable.* from (" + strSql + ") as ApplicantTable left outer join (" + strAttendanceSql +
                        ") as AttendaceTable on ApplicantTable.ApplicantID = AttendaceTable.AttendanceApplicant where (1=1) ";
                   
                    //_ApplicantStatusInAttendanceStatement
                    if (_AttendanceStatementConsider == 1)
                    {
                        strSql += " and AttendaceTable.AttendanceApplicant is null ";
                        if (_StatusIDSearch == 1)
                            strSql += " and(ApplicantStatusID =1  or ( ApplicantEndDate is not null and LastAttendanceStatement =0))";
                    }
                    else if (_AttendanceStatementConsider == 2)
                    {

                        strSql += " and AttendaceTable.AttendanceApplicant is not null ";
                    }
                    if (_AttendanceStatementIsSumStatusSearch == true)
                    {
                        if (_AttendanceStatementIsSum)
                            strAttendanceSql += " and AtendanceStatementIsSum =1 ";
                        else
                            strAttendanceSql += " and AtendanceStatementIsSum =0 ";
                    }
                }
                double dlEndDate = _AttendanceStatementEndDate.ToOADate() - 1;
                strSql += " and (ApplicantTable.ApplicantStartDate  <= " + dlEndDate + " )";
                if (_AttendanceStatementConsider == 1)
                {                   
                    double dlStartDate = _AttendanceStatementStartDate.ToOADate() - 2;
                   // dlStartDate = _AttendanceStatementEndDate.ToOADate() - 2;
                    //strSql += " and (ApplicantTable.ApplicantEndDate is Null Or ApplicantTable.ApplicantEndDate  Between " + dlStartDate + " and " + dlEndDate + " )";
                    strSql += " and (ApplicantTable.ApplicantEndDate is Null OR ApplicantTable.ApplicantEndDate  >= " + dlStartDate + " )";
                }
               // strSql += " And (ApplicantTable.ApplicantID in (Select ApplicantOverDay from V_ApplicantOverDay))";
            }

            if (_ID == 0 && (_IDs == null || _IDs == ""))
                _ApplicantIDs = "select ApplicantID from (" + strSql + ") as NativeTable";

       //  strSql += " And (HRApplicant.ApplicantID  in (322,847,1870,2059,2312,2895,2896,2899,2900,2901,2902,2903,2904,2905,2906,2908,2909,2911,2912,2913,2914,2915,2916,2917,2918,2919,2920,2921,2922,2923,2924,2925,2926,2927,2928,2929,2930,2931,2932))";
           // //strSql += " And (HRApplicant.ApplicantID  in (Select ApplicantTemp from V_ApplicantWithoutAccountBank))";
           // strSql += " And ( HRApplicantWorker.ApplicantID in (Select Applicant From A_111AAAError))";   
           // //strSql += " Order by HRApplicant.ApplicantID";
            _CacheApplicantTable = SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

           

        

            //foreach (DataRow objDr in _CacheApplicantTable.Rows)
            //{
            //    if (_ApplicantIDs != "")
            //        _ApplicantIDs = _ApplicantIDs + ",";
            //    _ApplicantIDs = _ApplicantIDs + objDr["ApplicantID"].ToString();
            //}
          
            ApplicantDb.ApplicantIDs = _ApplicantIDs;
            return _CacheApplicantTable;

        }
        public DataTable GetCostCenter()
        {
            string strSql ="SELECT     Applicant, CostCenter,CostCenterTable.*  "+
               " FROM         dbo.HRApplicantWorkerCostCenter inner join (" +
               CostCenterDb.SearchStr + ") as CostCenterTable  ON CostCenterTable.CostCenterID = HRApplicantWorkerCostCenter.CostCenter";
            if (_IDs != null && _IDs != "")
                strSql += " where Applicant in (" + _IDs + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetMotivationCostCenter()
        {
            string strSql = "SELECT     Applicant, CostCenter,CostCenterTable.*  " +
               " FROM         dbo.HRApplicantWorkerMotivationCostCenter inner join (" +
               CostCenterDb.SearchStr + ") as CostCenterTable  ON CostCenterTable.CostCenterID = HRApplicantWorkerMotivationCostCenter.CostCenter";
            if (_IDs != null && _IDs != "")
                strSql += " where Applicant in (" + _IDs + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public double GetLastBaseSalary()
        {
            double dlValue = 0;
            string str = " SELECT     BaseSalary "+
                         " FROM         HRApplicantWorkerStatement "+
                         " WHERE     (OriginStatementID IN "+ 
                         " (SELECT     MAX(OriginStatementID) "+
                         " FROM         HRApplicantWorkerStatement AS HRApplicantWorkerStatement_1"+
                         " WHERE     (Applicant = " + _ID + ") AND (BaseSalary <> 0)))";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(str);
            if (dtTemp.Rows.Count == 0)
                return 0;
            else
            {
                if (dtTemp.Rows[0][0].ToString() != "")
                    dlValue = double.Parse(dtTemp.Rows[0][0].ToString());
                else
                    dlValue = 0;
            }
            return dlValue;
        }
        public static void SetJobCategoryEstimation(int intJobNatureID, int intJobCatgoreyEstimation,string strApplicantIDs)
        {
            string str = " UPDATE    HRApplicantWorker "+
                         " SET              JobCategoryEstimation = " + intJobCatgoreyEstimation + " " +
                         " WHERE     (ApplicantID IN "+
                         " (SELECT     ApplicantID "+
                         " FROM         HRApplicantWorkerCurrentSubSector "+
                         " WHERE     (JobNatureID = " + intJobNatureID + ") and ApplicantID in (" + strApplicantIDs + ")))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
        }
        public static void ResetJobCategoryEstimation(int intJobNatureID,  string strApplicantIDs)
        {
            string str = " UPDATE    HRApplicantWorker " +
                         " SET              JobCategoryEstimation = 0 " +
                         " WHERE     (ApplicantID IN " +
                         " (SELECT     ApplicantID " +
                         " FROM         HRApplicantWorkerCurrentSubSector " +
                         " WHERE     (JobNatureID = " + intJobNatureID + ") and ApplicantID in (" + strApplicantIDs + ")))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
        }
        //public double GetLastBaseSalary()
        //{
        //    string str = " SELECT     HRApplicantWorkerStatement.BaseSalary " +
        //                 " FROM         HRApplicantWorkerStatement INNER JOIN" +
        //                 " HRGlobalStatement ON HRApplicantWorkerStatement.GlobalStatment = HRGlobalStatement.StatementID" +
        //                 " WHERE     (HRApplicantWorkerStatement.Applicant = " + _ID + ") AND " +
        //                 " (HRApplicantWorkerStatement.BaseSalary <> 0) AND (HRGlobalStatement.IsAppendix = 0)" +
        //                 " ORDER BY HRApplicantWorkerStatement.OriginStatementID DESC";
        //    DataTable dtTemp = SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(str);
        //    if (dtTemp.Rows.Count == 0)
        //        return 0;
        //    else
        //        return double.Parse(dtTemp.Rows[0][0].ToString());
        //}
        #endregion
    }
}