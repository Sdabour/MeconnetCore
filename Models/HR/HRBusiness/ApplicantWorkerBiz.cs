using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.IO;
using SharpVision.GL.GLBusiness;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{

    #region Enumeration
    public enum ApplicantBank
    {
        NotSpecified,
        Alex = 81,
        Ahly =3,
        EG = 152
    }
    public enum ApplicantScientificGrade
    {
        €Ì—_„Õœœ,
        „ﬁ»Ê· = 1,
        ÃÌœ = 2,
        ÃÌœ_Ãœ« = 3,
        „„ «“ = 4
    }
    public enum MaritalStatus
    {
        €Ì—_„Õœœ,
         √⁄“» = 1,
        „ “ÊÃ = 2,
        „ÿ·ﬁ = 3,
        √—„· = 4,
        √‰”… = 5
    }

    #endregion
    public class ApplicantWorkerBiz : ApplicantBiz
    {
        #region Private Data

      
        
        
        ApplicantWorkerCurrentSubSectorCol _CurrentSubSectorCol;
       
        BankBiz _BankBiz;      
        #region Financial Data        
        
        static int _UMSShowFinancialData = 516;
        static int _UMSShowFinancialDataIndex = -2;

        public static int UMSShowFinancialDataIndex
        {
            get { return ApplicantWorkerBiz._UMSShowFinancialDataIndex; }
            set { ApplicantWorkerBiz._UMSShowFinancialDataIndex = value; }
        }
        public static bool UMSShowFinancialAuthorized
        {
            get
            {
                if (_UMSShowFinancialDataIndex == -2)
                {
                    _UMSShowFinancialDataIndex = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(_UMSShowFinancialData);
                  //  int intID= SysData.CurrentUser.UserFunctionInstantCol[_UMSShowFinancialDataIndex].ID ;

                }
                if (_UMSShowFinancialDataIndex == -1)
                    return false;
                return true;
            }
        }
        #endregion
       
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;

        UserBiz _UserBiz;

        float _TotalVacationCredit=-1;
        float _TotalVacationRemainingCredit = -1;

        float _VacationCreditCommon=-1;
        float _VacationCreditAccident=-1;
        float _VacationCreditOther=-1;
        float _VacationPostPoned = -1; // „ƒÃ·
        float _VacationPosted = -1; // „—Õ·

        float _InitVacationCreditCommon = -1;
        float _InitVacationCreditCommonWithOutDeserved = -1;
        float _InitVacationCreditAccident = -1;
        float _InitVacationPostPoned = -1; // „ƒÃ·
        float _InitVacationPosted = -1; // „—Õ·

        DateTime _CreditDateCommon;
        DateTime _CreditDateAccident;
        DateTime _PostPonedDate;
        DateTime _PostedDate;


       

        ApplicantWorkerCurrentSubSectorBiz _CurrentSubSectorBiz;
      

        CostCenterHRBiz _VirualCostCenterBiz;

        JobNatureTypeBiz _VirualJobNatureTypeBiz;
        JobCategoryEstimationBiz _VirualJobCategoryEstimationBiz;
        SubSectorBiz _VirualSubSectorBiz;
        bool _VirualIsSpecialCaseChooseInMotivation;
        float _TelSalaryDetail=-1;
        float _TransferSalaryDetail=-1;
        float _FeedingSalaryDetail = -1;
        float _VarioustSalaryDetail = -1;
        int _MaxAttendanceStatement = 0;

       
        protected AttachmentFileBiz _AttachmentCardBiz;
        string _PathCard;
       
        #endregion
        #region Constructors
        public ApplicantWorkerBiz()
        {
            _ApplicantDb = new ApplicantWorkerDb();
            
            _CurrentSubSectorCol = null;// new ApplicantWorkerCurrentSubSectorCol(true);
            
            _UserBiz = new UserBiz();
            IDTypeInstantBiz = new IDTypeInstantBiz();
          
            
            
        }
        public ApplicantWorkerBiz(int intID)
        {
            
            _ApplicantDb = new ApplicantWorkerDb();
            if (intID == 0)
                return;
            _ApplicantDb.ID = intID;
            DataTable dtTemp = _ApplicantDb.Search();
            DataRow objDR ;
            
            if (dtTemp.Rows.Count == 0)
                return;
            objDR = dtTemp.Rows[0];
            _ApplicantDb = new ApplicantWorkerDb(objDR);
            _NativeCurrentSalary = ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary;
            _UserBiz = new UserBiz();
             
            _BankBiz = new BankBiz();
            if (((ApplicantWorkerDb)_ApplicantDb).AccountBankID != 0)
            {
                _BankBiz.ID = ((ApplicantWorkerDb)_ApplicantDb).AccountBankID;
                _BankBiz.NameA = ((ApplicantWorkerDb)_ApplicantDb).AccountBankName;
            }
            CostCenterHRBiz objCostCenter = new CostCenterHRBiz();
        
            if (((ApplicantWorkerDb)_ApplicantDb).CostCenter != 0)
            {
                objCostCenter = new CostCenterHRBiz();
                objCostCenter.ID = ((ApplicantWorkerDb)_ApplicantDb).CostCenter;
                objCostCenter.NameA = ((ApplicantWorkerDb)_ApplicantDb).CostCenterName;
              


            }
            if (((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterID != 0)
            {
               
                objCostCenter = new CostCenterHRBiz();
                objCostCenter.ID = ((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterID;
                objCostCenter.NameA = ((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterName;
             


               
               

            }
            if (((ApplicantWorkerDb)_ApplicantDb).SubSectorID != 0)
            {
                _CurrentSubSectorCol = new ApplicantWorkerCurrentSubSectorCol(true);
                // _CurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz(objDR);
                _CurrentSubSectorCol.Add(CurrentSubSectorBiz);
            }
            _VirualJobCategoryEstimationBiz = new JobCategoryEstimationBiz();
            if (((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation != 0)
            {
                _VirualJobCategoryEstimationBiz = new JobCategoryEstimationBiz() { ID = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation, NameA = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimationName };

            }

            }
        public ApplicantWorkerBiz(DataRow objDR)
            : base(objDR)
        {
            _ApplicantDb = new ApplicantWorkerDb(objDR);
            _NativeCurrentSalary = ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary;
            _UserBiz = new UserBiz();
           
            _BankBiz = new BankBiz();
            if (((ApplicantWorkerDb)_ApplicantDb).AccountBankID != 0)
            {
                _BankBiz.ID = ((ApplicantWorkerDb)_ApplicantDb).AccountBankID;
                _BankBiz.NameA = ((ApplicantWorkerDb)_ApplicantDb).AccountBankName;
            }
            CostCenterHRBiz objCostCenter = new CostCenterHRBiz();
          
            if (((ApplicantWorkerDb)_ApplicantDb).CostCenter != 0)
            {
                objCostCenter = new CostCenterHRBiz();
                objCostCenter.ID = ((ApplicantWorkerDb)_ApplicantDb).CostCenter;
                objCostCenter.NameA = ((ApplicantWorkerDb)_ApplicantDb).CostCenterName;
            


            }
            if (((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterID != 0)
            {
                
                objCostCenter = new CostCenterHRBiz();
                objCostCenter.ID = ((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterID;
                objCostCenter.NameA = ((ApplicantWorkerDb)_ApplicantDb).MotivationCostCenterName;
               

            }
            if(((ApplicantWorkerDb)_ApplicantDb).SubSectorID != 0)
            {
                _CurrentSubSectorCol = new ApplicantWorkerCurrentSubSectorCol(true);
               // _CurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz(objDR);
                _CurrentSubSectorCol.Add(CurrentSubSectorBiz);
            }
            _VirualJobCategoryEstimationBiz = new JobCategoryEstimationBiz();
            if (((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation != 0)
            {
                _VirualJobCategoryEstimationBiz = new JobCategoryEstimationBiz() { ID = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation, NameA = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimationName };

            }
            _ImageBiz = new ApplicantImageBiz(objDR);

        }
        public ApplicantWorkerBiz(DataRow objDR, int intStartDateStatus, DateTime dtDateFrom, DateTime dtDateTo)
            : base(objDR)
        {
            _ApplicantDb = new ApplicantWorkerDb(objDR);
            _NativeCurrentSalary = ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary;
            _UserBiz = new UserBiz();
        
       
        }
        public ApplicantWorkerBiz(string strCode)
        {
            _ApplicantDb = new ApplicantWorkerDb(strCode);

            _NativeCurrentSalary = ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary;
        
                _UserBiz = new UserBiz();
               
        }
        #endregion
        #region Public Properties
        
        public int ApplicantWorkerID
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).ApplicantWorkerID = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).ApplicantWorkerID;
            }
        }
        public string Code
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).Code = value;
            }
            get
            {
                if (((ApplicantWorkerDb)_ApplicantDb).Code == null)
                    return "";
                return ((ApplicantWorkerDb)_ApplicantDb).Code;
            }

        }
        public string ArchiveNo
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).ArchiveNo = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).ArchiveNo;
            }

        }
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            set
            {
                _JobCategoryEstimationBiz = value;
            }
            get
            {
                if (_JobCategoryEstimationBiz == null)
                {
                    _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(); // new JobCategoryEstimationBiz(((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation);
                    _JobCategoryEstimationBiz.ID = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation;
                    _JobCategoryEstimationBiz.NameA = ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimationName;
                }
                return _JobCategoryEstimationBiz;
            }
        }
        public bool StartDateStatus
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StartDateStatus = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StartDateStatus;
            }
        }
        public bool IsDiscountDelay
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).IsDiscountDelay = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).IsDiscountDelay;
            }
        }
        public bool IsPartTime
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).IsPartTime = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).IsPartTime;
            }
        }
        public bool IsReviewed
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).IsReviewed = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).IsReviewed;
            }

        }
        public bool HasGrantedVacation
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).HasGrantedVacation = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasGrantedVacation;
            }
        }
        public DateTime LastGrantedVacationDate
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).LastGrantedVacationDate = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).LastGrantedVacationDate;
            }
        }
        public DateTime LastGrantedStartValid
        {
            get { return ((ApplicantWorkerDb)_ApplicantDb).LastGrantedStartValid; }
            set { ((ApplicantWorkerDb)_ApplicantDb).LastGrantedStartValid = value; }
        }
        public bool IsFellowShip
        {
            set
            {
                
                ((ApplicantWorkerDb)_ApplicantDb).IsFellowShip = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).IsFellowShip;
            }

        }
        public double FellowShipCredit
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).FellowShipCredit = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).FellowShipCredit;
            }

        }
        public double FellowShipDiscountHistory
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).FellowShipDiscountHistory = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).FellowShipDiscountHistory;
            }

        }
       
        public bool HasTimeShit
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).HasTimeShit = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasTimeShit;
            }

        }
        public bool HasAttendanceStatement
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).HasAttendanceStatement = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasAttendanceStatement;
            }

        }
        public bool HasMotivation
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).HasMotivation = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasMotivation;
            }

        }
        public int AttachmentCount
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).AttachmentCount;
            }
        }
        ApplicantImageBiz _ImageBiz;
        public ApplicantImageBiz ImageBiz
        {
            set => _ImageBiz = value;
            get
            {
                if (_ImageBiz == null)
                    _ImageBiz = new ApplicantImageBiz();
                return _ImageBiz;
            }
        }
        public string MedicalStatusStr
        {
            get
            {
                string Returned = "";
                if (MedicalStatusID == 0)
                    Returned = "€Ì— „Õœœ";
                else if (MedicalStatusID == 1)
                    Returned = "·«∆ﬁ ÿ»Ï";
                else if (MedicalStatusID == 2)
                    Returned = "€Ì—·«∆ﬁ ÿ»Ï";

                return Returned;
            }
        }
        public UserBiz UserBiz
        {
            set
            {
                _UserBiz = value;
            }
            get
            {
                return _UserBiz;
            }

        }
        public DateTime StartDate
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StartDate = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StartDate;
            }

        }
        public DateTime StartExperienceDate
        {
            get { return ((ApplicantWorkerDb)_ApplicantDb).StartExperienceDate; }
            set { ((ApplicantWorkerDb)_ApplicantDb).StartExperienceDate = value; }
        }
       

        public bool StartExperienceDateDecided
        {
            get { return ((ApplicantWorkerDb)_ApplicantDb).StartExperienceDateDecided; }
            set { ((ApplicantWorkerDb)_ApplicantDb).StartExperienceDateDecided = value; }
        }
        public DateTime EndDate
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).EndDate = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).EndDate;
            }

        }
        public bool IsEnded
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).IsEnded;
            }
        }
        public int LastAttendanceStatement
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).LastAttendanceStatement;
            }
        }
        public double StartSalary
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StartSalary = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StartSalary;
            }
        }
        public double StartSalaryDetails
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StartSalaryDetails = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StartSalaryDetails;
            }
        }
        public int StartSalaryCurrency
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StartSalaryCurrency = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StartSalaryCurrency;
            }

        }
        double _NativeCurrentSalary;

        public double NativeCurrentSalary
        {
            get { return _NativeCurrentSalary; }
            set { _NativeCurrentSalary = value; }
        }
        public double CurrentSalary
        {
            set
            {
              
                ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary = value;
            }
            get
            {
                if (UMSShowFinancialAuthorized)
                    return ((ApplicantWorkerDb)_ApplicantDb).CurrentSalary;
                else
                    return -1;
            }

        }
        public double ApplicantVirtualSalary
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).ApplicantVirtualSalary = value;
            }
            get
            {
                if(UMSShowFinancialAuthorized)
                return ((ApplicantWorkerDb)_ApplicantDb).ApplicantVirtualSalary;
                else
                    return -1;
            }

        }
        public double PartTimeUnitValue
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnitValue = value;
            }
            get
            {
                if (UMSShowFinancialAuthorized)
                    return ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnitValue;
                else
                    return -1;
            }
        }
        public Period PartTimeUnit
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnit =(byte) value;
            }
            get
            {
                return (Period)((ApplicantWorkerDb)_ApplicantDb).PartTimeUnit;
            }
        }
        public int MedicalStatusID
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).MedicalStatusID = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).MedicalStatusID; }
        }
        public int ComputerQualificationID
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).ComputerQualificationID = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).ComputerQualificationID; }
        }
        public string ComputerQualificationStr
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).ComputerQualificationStr = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).ComputerQualificationStr; }
        }
        public string InsuranceNo
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).InsuranceNo = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).InsuranceNo; }
        }
        public DateTime InsuranceDate
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).InsuranceDate = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).InsuranceDate;
            }

        }
        public string InsuranceJobTitle
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).InsuranceJobTitle = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).InsuranceJobTitle; }
        }
        public double InsuranceSalary
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).InsuranceSalary = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).InsuranceSalary; }
        }
        public double InsuranceSalaryChange
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).InsuranceSalaryChange = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).InsuranceSalaryChange; }
        }
        public string AccountBankNo
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).AccountBankNo = value; }
            get
            {
                if (((ApplicantWorkerDb)_ApplicantDb).AccountBankNo == null)
                    return "";
                return ((ApplicantWorkerDb)_ApplicantDb).AccountBankNo;
            }
        }
        public string AccountBankBranchCode
        {
            set 
            {
                ((ApplicantWorkerDb)_ApplicantDb).AccountBankBranchCode = value;
            }
            get
            {
                if (((ApplicantWorkerDb)_ApplicantDb).AccountBankBranchCode == null)
                    return "";
                return ((ApplicantWorkerDb)_ApplicantDb).AccountBankBranchCode;
            }
        }
        public string AccountTypeCode
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).AccountTypeCode = value;
            }
            get
            {
                if (((ApplicantWorkerDb)_ApplicantDb).AccountTypeCode == null)
                    return "";
                return ((ApplicantWorkerDb)_ApplicantDb).AccountTypeCode;
            }
        }

        public double BankIntNo
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).BankIntNo = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).BankIntNo;
            }

        }
        public int User
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).User = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).User;
            }

        }
        public int StatusID
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).StatusID = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).StatusID;
            }

        }
        public int VacationDayCount
        {
            set
            {
                ((ApplicantWorkerDb)_ApplicantDb).VacationDayCount = value;
            }
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).VacationDayCount;
            }

        }
        
  
    
      
    
      
  
    
        public double DetailsValue
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).DetailsValue;
            }
        }
        public double DetailsValueForMotivation
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).TotalDetailsForMotivation;
            }
        }
        public double PreviousBaseSalary
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).PreviousBaseSalary;
            }

        }
        public int LastMotivationStatementID
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).LastMotivationStatementID;
            }

        }
        public double LastMotivationValue
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).LastMotivationValue = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).LastMotivationValue; }

        }
        public double LastMotivationAddedBonusValue
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).LastMotivationAddedBonusValue = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).LastMotivationAddedBonusValue; }

        }
        public DateTime LastMotivationDate
        {
            set { ((ApplicantWorkerDb)_ApplicantDb).LastMotivationDate = value; }
            get { return ((ApplicantWorkerDb)_ApplicantDb).LastMotivationDate; }

        }

        public double PreviousDetailsValue
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).PreviousDetailsValue;
            }

        }
        public ApplicantWorkerCurrentSubSectorCol CurrentSubSectorCol
        {
            set
            {
                _CurrentSubSectorCol = value;
            }

            get
            {
                if (_CurrentSubSectorCol == null)
                {
                    _CurrentSubSectorCol = new ApplicantWorkerCurrentSubSectorCol(true);
                    if (ID != 0)
                    {

                        if (ApplicantWorkerDb.ApplicantIDs == null || ApplicantWorkerDb.ApplicantIDs == "")
                            ApplicantWorkerDb.ApplicantIDs = ID.ToString();
                       DataRow[] arrDr = new DataRow[0];
                        if(ApplicantWorkerDb.CacheCurrentSubSectorTable!= null)

                         arrDr =  ApplicantWorkerDb.CacheCurrentSubSectorTable.Select("ApplicantID=" + ID);
                        ApplicantWorkerCurrentSubSectorBiz objApplicantCurrentSubSectorBiz;
                        if (arrDr.Length != 0)
                        {
                            foreach (DataRow objDr in arrDr)
                            {
                                objApplicantCurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz(objDr);
                                objApplicantCurrentSubSectorBiz.ApplicantWorkerID = ID;
                                _CurrentSubSectorCol.Add(objApplicantCurrentSubSectorBiz);
                            }
                        }
                        else
                        {
                            
                            ApplicantWorkerCurrentSubSectorDb objDb = new ApplicantWorkerCurrentSubSectorDb();
                            objDb.ApplicantWorkerID = ID;
                            DataTable dtTemp = objDb.Search();
                            foreach (DataRow objDr in dtTemp.Rows)
                            {
                                objApplicantCurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz(objDr);
                                objApplicantCurrentSubSectorBiz.ApplicantWorkerID = ID;
                                _CurrentSubSectorCol.Add(objApplicantCurrentSubSectorBiz);
                            }
                        }

                    }
                }
                return _CurrentSubSectorCol;
            }
        }
        
        public string SubSectorAndJobStr
        {
            get
            {
                string strSubsectorJob = "";
                foreach (ApplicantWorkerCurrentSubSectorBiz objBiz in CurrentSubSectorCol)
                {

                    if (strSubsectorJob == "")
                    {
                        strSubsectorJob = "[" + objBiz.SubSectorBiz.SectorBiz.FullName + " - " + objBiz.JobNatureTypeBiz.Name + "] ";
                        if (objBiz.Description != "")
                            strSubsectorJob += "«·Ê’› : " + objBiz.Description;
                    }
                    else
                    {
                        strSubsectorJob = strSubsectorJob + "\n," + "[" + objBiz.SubSectorBiz.SectorBiz.FullName + " - " + objBiz.JobNatureTypeBiz.Name + "] ";
                        if (objBiz.Description != "")
                            strSubsectorJob += "«·Ê’› : " + objBiz.Description;
                    }

                }
                return strSubsectorJob;
            }
        }        
        public string SectorStr
        {
            get
            {
                string sttSector = "";
                if (_CurrentSubSectorCol != null)
                {
                    foreach (ApplicantWorkerCurrentSubSectorBiz objBiz in CurrentSubSectorCol)
                    {
                        sttSector = objBiz.SubSectorBiz.SectorBiz.FullName;
                        break;
                    }
                }
                else
                {
 
                }
                return sttSector;
            }
        }


        #region Finace
       
        double _LastAddedBonusValue;
        #endregion
        public string StatusStr
        {
            get
            {
                string Returned = "";
                if (StatusID == 0)
                    Returned = "€Ì— „Õœœ";
                else if (StatusID == 1)
                {
                    if (((ApplicantWorkerDb)_ApplicantDb).HasNonDiscountedCreditVacation)
                    {
                        Returned = "«Ã«“… »œÊ‰ „— »";
                    }
                    else
                       Returned = "Ì⁄„·";
                }
                else if (StatusID == 2)
                    Returned = "„” ﬁÌ·";
                else if (StatusID == 3)
                    Returned = "„›’Ê·";
                else if (StatusID == 4)
                    Returned = "„ÊﬁÊ›";
                else if (StatusID == 5)
                    Returned = "„ Ê›Ï";

                return Returned;
            }
        }
        public bool HasNonDiscountedCreditVacation
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasNonDiscountedCreditVacation;
            }
        }
      
        public ApplicantWorkerCurrentSubSectorBiz CurrentSubSectorBiz
        {           
            get
            {
                if (_CurrentSubSectorBiz == null)
                {
                    _CurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz();
                    _CurrentSubSectorBiz.SubSectorBiz.ID = ((ApplicantWorkerDb)_ApplicantDb).SubSectorID;
                    _CurrentSubSectorBiz.SubSectorBiz.SectorBiz = SectorCol.CacheSectorCol[((ApplicantWorkerDb)_ApplicantDb).SectorID.ToString()];
                    //_CurrentSubSectorBiz.SubSectorBiz.SectorBiz.ID = ((ApplicantWorkerDb)_ApplicantDb).SectorID;
                    //_CurrentSubSectorBiz.SubSectorBiz.SectorBiz.NameA= ((ApplicantWorkerDb)_ApplicantDb).SectorNameA;
                    ((SubSectorBranchBiz)_CurrentSubSectorBiz.SubSectorBiz).BranchBiz.ID =((ApplicantWorkerDb)_ApplicantDb).BranchID;
                    ((SubSectorBranchBiz)_CurrentSubSectorBiz.SubSectorBiz).BranchBiz.NameA = ((ApplicantWorkerDb)_ApplicantDb).BranchNameA;
                  _CurrentSubSectorBiz.JobNatureTypeBiz = new JobNatureTypeBiz();
                  (_CurrentSubSectorBiz.JobNatureTypeBiz).ID = ((ApplicantWorkerDb)_ApplicantDb).JobNatureID;
                  (_CurrentSubSectorBiz.JobNatureTypeBiz).NameA = ((ApplicantWorkerDb)_ApplicantDb).JobNatureTypeNameA;
                  (_CurrentSubSectorBiz.JobNatureTypeBiz).JobCategory = new JobCategoryBiz();
                  (_CurrentSubSectorBiz.JobNatureTypeBiz).JobCategory.OrderValue = ((ApplicantWorkerDb)_ApplicantDb).JobNatureOrderValue;
                  _CurrentSubSectorBiz.JobCategoryEstimationBiz = new JobCategoryEstimationBiz();
                  if (((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation != 0)
                  {
                      _CurrentSubSectorBiz.JobCategoryEstimationBiz.ID =
                        ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimation;
                      _CurrentSubSectorBiz.JobCategoryEstimationBiz.NameA =
                    ((ApplicantWorkerDb)_ApplicantDb).JobCategoryEstimationName;

                  }//foreach (ApplicantWorkerCurrentSubSectorBiz objBiz in CurrentSubSectorCol)
                    //{
                    //    _CurrentSubSectorBiz = objBiz;
                    //    break;
                    //}
                   // SectorCol.
                }
                return _CurrentSubSectorBiz;
            }
        }        
        
        public BankBiz BankBiz
        {
            set
            {
                _BankBiz = value;
            }
            get
            {
                if (_BankBiz == null)
                    _BankBiz = new BankBiz();
                return _BankBiz;
            }
        }

      
        public bool HasAddedBonus
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).HasAddedBonus;

            }
            set { ((ApplicantWorkerDb)_ApplicantDb).HasAddedBonus = value; }
        }
        public double AddedBonusValue
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).AddedBonusValue;

            }
            set { ((ApplicantWorkerDb)_ApplicantDb).AddedBonusValue = value; }
        }
        public int FellowshipSalaryOrMotivation
        {
            get
            {
                return ((ApplicantWorkerDb)_ApplicantDb).FellowShipSalaryOrMotivation;

            }
            set { ((ApplicantWorkerDb)_ApplicantDb).FellowShipSalaryOrMotivation = value; }
        }
  
        public CostCenterHRBiz VirualCostCenterBiz
        {
            set
            {
                _VirualCostCenterBiz = value;
            }
            get
            {
                if (_VirualCostCenterBiz == null)
                    _VirualCostCenterBiz = new CostCenterHRBiz();
                return _VirualCostCenterBiz;
            }
        }
        public bool VirualIsSpecialCaseChooseInMotivation
        {
            set
            {
                _VirualIsSpecialCaseChooseInMotivation = value;
            }
            get
            {
                return _VirualIsSpecialCaseChooseInMotivation;
            }
        }
        
        public JobNatureTypeBiz VirualJobNatureTypeBiz
        {
            set
            {
                _VirualJobNatureTypeBiz = value;
            }
            get
            {
                if (_VirualJobNatureTypeBiz == null)
                    _VirualJobNatureTypeBiz = new JobNatureTypeBiz();
                return _VirualJobNatureTypeBiz;
            }
        }
        public int _VirualIndex;
        public int VirualIndex
        {
            set { _VirualIndex = value; }
            get { return _VirualIndex; }
        }
        public JobCategoryEstimationBiz VirualJobCategoryEstimationBiz
        {
            set
            {
                _VirualJobCategoryEstimationBiz = value;
            }
            get
            {
                return _VirualJobCategoryEstimationBiz;
            }
        }
        public SubSectorBiz VirualSubSectorBiz
        {
            set
            {
                _VirualSubSectorBiz = value;
            }
            get
            {
                if (_VirualSubSectorBiz == null)
                    _VirualSubSectorBiz = new SubSectorBranchBiz();
                return _VirualSubSectorBiz;
            }
        }
       
    
     
        public static List<string>  ApplicantBankArr
        {
            get
            {
                List<string> Returned = new List<string>();
            //NotSpecified,
                Returned.Add("€Ì— „Õœœ");
            //Alex = 81,
                Returned.Add("«·«”ﬂ‰œ—Ì…");
            //Ahly = 3
                Returned.Add("«·«Â·Ï");
                //EG Bank = 155
                Returned.Add("EG Bank");
                return Returned;
            }
        }
        public static List<int> ApplicantBankIDArr
        {
            get
            {
                List<int> Returned = new List<int>();
                //NotSpecified,
                Returned.Add(0);
                //Alex = 81,
                Returned.Add(81);
                //Ahly = 3
                Returned.Add(3);
                //EG Bank = 152
                Returned.Add(152);
                return Returned;
            }
        }
       public  static BankCol BankCol 
        {
            get
            {
                BankCol Returned = new BankCol(true) ;
                BankBiz objBiz;
                for (int intIndex = 0; intIndex < ApplicantBankIDArr.Count; intIndex++)
                {
                    objBiz = new BankBiz();
                    objBiz.ID = ApplicantBankIDArr[intIndex];
                    objBiz.NameA = ApplicantBankArr[intIndex];
                    Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        public static int GetApplicantBankIndex(int intBank)
        {
            for (int intIndex = 0; intIndex < ApplicantBankIDArr.Count;intIndex++ )
            {
                if (ApplicantBankIDArr[intIndex] == intBank)
                    return intIndex;
            }
            return -1;
        }

        #region Attendance Region
       
       
       
        
        #endregion
        #region Financial Value
       
        public double LastAddedBonusValue { get => _LastAddedBonusValue; set => _LastAddedBonusValue = value; }
        #endregion
        #endregion
        #region Private Methods
      
        #endregion
        #region Public Methods
        public override void Add()
        {
            ((ApplicantWorkerDb)_ApplicantDb).User = _UserBiz.ID;
            
            ((ApplicantWorkerDb)_ApplicantDb).SubSectorTable = CurrentSubSectorCol.GetTable();
         
           
           
            ((ApplicantWorkerDb)_ApplicantDb).IDType = IDTypeInstantBiz.ID;
            ((ApplicantWorkerDb)_ApplicantDb).IDValue = IDTypeInstantBiz.IDValue;
            
            
            ((ApplicantWorkerDb)_ApplicantDb).AccountBankID = BankBiz.ID;
           
            ((ApplicantWorkerDb)_ApplicantDb).Add();
        }
        public override void Edit()
        {
            ((ApplicantWorkerDb)_ApplicantDb).User = _UserBiz.ID;
    
            ((ApplicantWorkerDb)_ApplicantDb).SubSectorTable = CurrentSubSectorCol.GetTable();
  
            
            ((ApplicantWorkerDb)_ApplicantDb).IDType = IDTypeInstantBiz.ID;
            ((ApplicantWorkerDb)_ApplicantDb).IDValue = IDTypeInstantBiz.IDValue;
            
           
             
            ((ApplicantWorkerDb)_ApplicantDb).AccountBankID = BankBiz.ID;

            ((ApplicantWorkerDb)_ApplicantDb).Edit();
        }
        public override void Delete()
        {
            ((ApplicantWorkerDb)_ApplicantDb).Delete();
        }
        public void EditCurrentSalary()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditCurrentSalary();
        }
        public void EditVirtualSalary()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditVirtualSalary();
        }
        public void EditInsuranceSalary()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditInsuranceSalary();
        }
        public void EditInsuranceSalaryChange()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditInsuranceSalaryChange();
        }
        public void EditStartSalary()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditStartSalary();
        }
        public void EditStartSalaryDetails()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditStartSalaryDetails();
        }
        public void EditPartTime(Period objPartTimePeriod, double dblPartTimeValue)
        {
            ((ApplicantWorkerDb)_ApplicantDb).IsPartTime = true;
            ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnit = (byte)objPartTimePeriod;
            ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnitValue = dblPartTimeValue;
            ((ApplicantWorkerDb)_ApplicantDb).EditPartTime();

        }
        public void DeletePartTime()
        {
            ((ApplicantWorkerDb)_ApplicantDb).IsPartTime = false;
            ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnit = (byte)0;
            ((ApplicantWorkerDb)_ApplicantDb).PartTimeUnitValue = 0;
            ((ApplicantWorkerDb)_ApplicantDb).DeletePartTime();

        }
        public void EditStatus(int intStatusID,DateTime dtEndDate,byte byUpdateEndFinancialStatement)
        {
            ((ApplicantWorkerDb)_ApplicantDb).EndDate = dtEndDate;
            ((ApplicantWorkerDb)_ApplicantDb).StatusID = intStatusID;
            ((ApplicantWorkerDb)_ApplicantDb).EditStatus(byUpdateEndFinancialStatement);
        }
        public void EditAccountBankNo()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditAccountBankNo();
        }
        public void EditFellowShipCredit()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditFellowShipCredit();
        }
        public void EditFellowShipDiscountHistory()
        {
            ((ApplicantWorkerDb)_ApplicantDb).EditFellowShipDiscountHistory();
        }
        public void EditLastAttendanceStatement(int intAttendanceStatement)
        {
            ((ApplicantWorkerDb)_ApplicantDb).LastAttendanceStatement = intAttendanceStatement;
            ((ApplicantWorkerDb)_ApplicantDb).EditLastAttendanceStatement();
        }
        public void EditLastFinancialStatement(int intFinancialStatement)
        {
            ((ApplicantWorkerDb)_ApplicantDb).LastFinancialStatement = intFinancialStatement;
            ((ApplicantWorkerDb)_ApplicantDb).EditLastFinancialStatement();
        }
        public double GetLastBaseSalary()
        {
            return ((ApplicantWorkerDb)_ApplicantDb).GetLastBaseSalary();
        }
        
       
        #region AttendanceTime
      
      
        #endregion
        #endregion
    }
}
