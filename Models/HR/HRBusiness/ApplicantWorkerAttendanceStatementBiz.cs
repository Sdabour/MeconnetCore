using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerAttendanceStatementBiz
    {
        #region Private Data
        ApplicantWorkerAttendanceStatementDb _AttendanceStatementDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        AttendanceStatementBiz _AttendanceStatementBiz;
        ApplicantWorkDayCol _WorkDayCol;

        JobNatureTypeBiz _JobNatureTypeBiz;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        SubSectorBiz _SubSectorBiz;
 

        #region Tables Used in Work day Processing;
        DataTable _VacationTable;
        DataTable _FurloughTable;
        DataTable _MissionTable;
        DataTable _CheckInOutTable;
        DataTable _AttendanceTimeTable;
         
        DataTable _AbsenceDaysTable;
        DataTable _OverDaysTable;

        #endregion

        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceStatementBiz()
        {
            _AttendanceStatementDb = new ApplicantWorkerAttendanceStatementDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _AttendanceStatementBiz = new AttendanceStatementBiz();
            _JobNatureTypeBiz = new JobNatureTypeBiz();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();
        }
        public ApplicantWorkerAttendanceStatementBiz(DataRow objDr)
        {
            _AttendanceStatementDb = new ApplicantWorkerAttendanceStatementDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
            _AttendanceStatementBiz = new AttendanceStatementBiz(objDr);
            _JobNatureTypeBiz = new JobNatureTypeBiz(objDr);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDr);
        }
        public ApplicantWorkerAttendanceStatementBiz(int intApplicantID, int intAttendanceStatementID)
        {
            _AttendanceStatementDb = new ApplicantWorkerAttendanceStatementDb(intApplicantID, intAttendanceStatementID);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(intApplicantID);
            _AttendanceStatementBiz = new AttendanceStatementBiz(intAttendanceStatementID);
            _JobNatureTypeBiz = new JobNatureTypeBiz(_AttendanceStatementDb.JobNature);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(_AttendanceStatementDb.JobCategoryEstimation);
        }
        public ApplicantWorkerAttendanceStatementBiz(ApplicantWorkerBiz objWorkerBiz, AttendanceStatementBiz objStatementBiz)
        {
            _AttendanceStatementDb = new ApplicantWorkerAttendanceStatementDb(objWorkerBiz.ID, objStatementBiz.ID);
            _ApplicantWorkerBiz = objWorkerBiz;
            _AttendanceStatementBiz = objStatementBiz;
            _JobNatureTypeBiz = objWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz; //new JobNatureTypeBiz(_AttendanceStatementDb.JobNature);
            _JobCategoryEstimationBiz = objWorkerBiz.JobCategoryEstimationBiz; // new JobCategoryEstimationBiz(_AttendanceStatementDb.JobCategoryEstimation);
            _SubSectorBiz = objWorkerBiz.CurrentSubSectorBiz.SubSectorBiz;
            //_JobNatureTypeBiz = objWorkerBiz.VirualJobNatureTypeBiz;
       
        }
        #endregion
        #region Private Property
       
    
         
        
         
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AttendanceStatementDb.ID = value;
            }
            get
            {
                return _AttendanceStatementDb.ID;
            }
        }
        public AttendanceStatementBiz AttendanceStatementBiz
        {
            set
            {
                _AttendanceStatementBiz = value;
            }
            get
            {
                return _AttendanceStatementBiz;
            }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set
            {
                _ApplicantWorkerBiz = value;
            }
            get
            {
                return _ApplicantWorkerBiz;
            }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set
            {
                _JobNatureTypeBiz = value;
            }
            get
            {
                return _JobNatureTypeBiz;
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
                return _JobCategoryEstimationBiz;
            }
        }
        public SubSectorBiz SubSectorBiz
        {
            set
            {
                _SubSectorBiz = value;
            }
            get
            {
                if (_SubSectorBiz == null)
                    return ApplicantWorkerBiz.CurrentSubSectorBiz.SubSectorBiz;
                return _SubSectorBiz;
            }
        }
        public SectorBiz MainSectorBiz
        {
            
            get
            {
                SubSectorBiz objSubsector = _SubSectorBiz == null ? ApplicantWorkerBiz.CurrentSubSectorBiz.SubSectorBiz : _SubSectorBiz;
                
                return SectorCol.CacheSectorCol[objSubsector.SectorBiz.ID.ToString()];
            }
        }
        public int SubSectorID
        {
            set
            {
                _AttendanceStatementDb.SubSector = value;
            }
            get
            {
                return _AttendanceStatementDb.SubSector;
            }
        }
        public int DutyWDay
        {
            get
            {                
                TimeSpan objTs = AttendanceStatementBiz.StatementTo.Subtract(AttendanceStatementBiz.StatementFrom);
                return objTs.Days;
            }
        }
        public float DelayLimit
        {
            set
            {
                _AttendanceStatementDb.DelayLimit = value;
            }
            get
            {                
                return _AttendanceStatementDb.DelayLimit;
            }
        }

        public SectorBiz SectorBiz
        {
            get
            {
                
                SectorBiz Returned = MainSectorBiz.DisplaySectorBiz;
                if (Returned.ID == 0)
                    Returned = MainSectorBiz;
                return  Returned;
            }
        }
        public SectorBiz DepartmentBiz
        {
            get
            {
                SectorBiz Returned = MainSectorBiz.DisplayDepartmentBiz;
                if (Returned.ID == 0)
                    Returned = MainSectorBiz;
                return Returned;
            }
        }
        public float DelayCount
        {
            set
            {
                _AttendanceStatementDb.DelayCount = value;
            }
            get
            {
                return _AttendanceStatementDb.DelayCount;
            }
        }
        public float DelayCountValue
        {
            set
            {
                _AttendanceStatementDb.DelayCountValue = value;
            }
            get
            {
                return _AttendanceStatementDb.DelayCountValue;
            }
        }
        public float DelayRecommendedCountValue
        {
            set
            {
                _AttendanceStatementDb.DelayCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.DelayCountRecommendedValue;
            }
        }
        public int TotalMinutes
        {
            set
            {
                _AttendanceStatementDb.TotalMinutes = value;
            }
            get
            {
                return _AttendanceStatementDb.TotalMinutes;
            }

        }
        public int RecommendedTotalMinutes
        {
            set
            {
                _AttendanceStatementDb.RecommendedTotalMinutes = value;
            }
            get
            {
                return _AttendanceStatementDb.RecommendedTotalMinutes;
            }

        }
        public DateTime DateFrom
        {
            set
            {
                _AttendanceStatementDb.DateFrom = value;
            }
            get
            {
                return _AttendanceStatementDb.DateFrom;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _AttendanceStatementDb.DateTo = value;
            }
            get
            {
                return _AttendanceStatementDb.DateTo;
            }
        }
        public int FormalTotalMinutes
        {
            set
            {
                _AttendanceStatementDb.FormalTotalMinutes = value;
            }
            get
            {
                return _AttendanceStatementDb.FormalTotalMinutes;
            }

        }       
        public float OverTimeCount
        {
            set
            {
                _AttendanceStatementDb.OverTimeCount = value;
            }
            get
            {
                return _AttendanceStatementDb.OverTimeCount;
            }
        }
        public float OverTimeCountValue
        {
            set
            {
                _AttendanceStatementDb.OverTimeCountValue = value;
            }
            get
            {
                return _AttendanceStatementDb.OverTimeCountValue;
            }
        }
        public float OverTimeCountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.OverTimeCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.OverTimeCountRecommendedValue;
            }
        }
        public double OverDayCount
        {
            set
            {
                _AttendanceStatementDb.OverDayCount = value;
            }
            get
            {
                return _AttendanceStatementDb.OverDayCount;
            }
        }      
        public double OverDayCountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.OverDayCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.OverDayCountRecommendedValue;
            }
        }
        public float EarlierOutCount
        {
            set
            {
                _AttendanceStatementDb.EarlierOutCount = value;
            }
            get
            {
                return _AttendanceStatementDb.EarlierOutCount;
            }
        }
        public float EarlierOutCountValue
        {
            set
            {
                _AttendanceStatementDb.EarlierOutCountValue = value;
            }
            get
            {
                return _AttendanceStatementDb.EarlierOutCountValue;
            }
        }
        public float EarlierOutCountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.EarlierOutCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.EarlierOutCountRecommendedValue;
            }
        }
        public float FurloughCount
        {
            set
            {
                _AttendanceStatementDb.FurloughCount = value;
            }
            get
            {
                return _AttendanceStatementDb.FurloughCount;
            }
        }
        public float FurloughDiscountValue
        {
            set
            {
                _AttendanceStatementDb.FurloughDiscountValue = value;
            }
            get
            {
                return _AttendanceStatementDb.FurloughDiscountValue;
            }
        }
        public float FurloughDiscountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.FurloughDiscountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.FurloughDiscountRecommendedValue;
            }
        }
        public float AbsenceDayCount
        {
            set
            {
                _AttendanceStatementDb.AbsenceDayCount = value;
            }
            get
            {
                return _AttendanceStatementDb.AbsenceDayCount;
            }
        }
        public float AbsenceDayCountValue
        {
            set
            {
                _AttendanceStatementDb.AbsenceDayCountValue = value;
            }
            get
            {
                return _AttendanceStatementDb.AbsenceDayCountValue;
            }
        }
        public float AbsenceDayCountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.AbsenceDayCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.AbsenceDayCountRecommendedValue;
            }
        }
        public float NonCountedDays
        {
            set
            {
                _AttendanceStatementDb.NonCountedDays= value;
            }
            get
            {
                return _AttendanceStatementDb.NonCountedDays;
            }
        }
        public double ComputedNonCountedDays
        {
          
            get
            
            {
                double Returned = 0;
                if (_AttendanceStatementBiz.StatementFrom < _ApplicantWorkerBiz.StartDate ||
                    (_ApplicantWorkerBiz.IsEnded && _AttendanceStatementBiz.StatementTo > _ApplicantWorkerBiz.EndDate))
                {
                    TimeSpan objSpan  ;
                    if (_AttendanceStatementBiz.StatementFrom < _ApplicantWorkerBiz.StartDate)
                        objSpan = _ApplicantWorkerBiz.StartDate.Subtract(_AttendanceStatementBiz.StatementFrom);
                    else
                        objSpan = _AttendanceStatementBiz.StatementTo.Subtract(_ApplicantWorkerBiz.EndDate);
                    Returned = objSpan.Days;
                }
                return Returned;
            }
        }
        public float NonCountedDaysValue
        {
            set
            {
                _AttendanceStatementDb.NonCountedDaysValue = value;
            }
            get
            {
                return _AttendanceStatementDb.NonCountedDaysValue;
            }
        }
        public float NonCountedDaysRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.NonCountedDaysRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.NonCountedDaysRecommendedValue;
            }
        }
        public int FinancialStatementID
        {
            get
            {
                return _AttendanceStatementDb.FinancialStatement;
            }
        }        
        public float VacationDayCount
        {
            set
            {
                _AttendanceStatementDb.VacationDayCount = value;
            }
            get
            {
                return _AttendanceStatementDb.VacationDayCount;
            }
        }
        public float VacationDisCount
        {
            set
            {
                _AttendanceStatementDb.VacationDisCount = value;
            }
            get
            {
                return _AttendanceStatementDb.VacationDisCount;
            }
        }
        public float VacationDisCountRecommendedValue
        {
            set
            {
                _AttendanceStatementDb.VacationDisCountRecommendedValue = value;
            }
            get
            {
                return _AttendanceStatementDb.VacationDisCountRecommendedValue;
            }
        }
        public double GeneratedBankingTime
        {
            set
            {
                _AttendanceStatementDb.GenratedBankingTime = value;
            }
            get
            {
                return _AttendanceStatementDb.GenratedBankingTime;
            }
        }
        public double ConsumedBankingTime
        {
            set
            {
                _AttendanceStatementDb.ConsumedBankingTime = value;
            }
            get
            {
                return _AttendanceStatementDb.ConsumedBankingTime;
            }
        }
      
        WorkDayFlatCol _WorkDayFlatCol;
        public WorkDayFlatCol WorkDayFlatCol
        {
            set => _WorkDayFlatCol = value;
            get 
            {
                if (_WorkDayFlatCol == null)
                    _WorkDayFlatCol = new WorkDayFlatCol(true);
                return _WorkDayFlatCol;
            }
        }
        public string StrApplicantWorkerName
        {
            get
            {
                return ApplicantWorkerBiz.Name;
            }
        }
        public string StrAttendanceStatementPeriod
        {
            get
            {
                return " From ( " + AttendanceStatementBiz.StatementFrom.ToString("dd/MM/yyyy") + " ) To ( " + AttendanceStatementBiz.StatementFrom.ToString("dd/MM/yyyy") + " )";
            }
        }
        
        public bool IsSum
        {
            set
            {
                _AttendanceStatementDb.IsSum = value;
            }
            get
            {
                return _AttendanceStatementDb.IsSum;
            }
        }
        public bool IsEndStatement
        {
            set
            {
                _AttendanceStatementDb.IsEndStatement = value;
            }
            get
            {
                return _AttendanceStatementDb.IsEndStatement;
            }
        }
       
        
         
       
        #endregion
        #region Private Methods
      
       
        /// <summary>
        /// to manipulate workday and to decide OverTime and Time Delay 
        /// time delay is an equation of diffrence between time in and FormalTimeIn
        /// 
        /// </summary>
        /// <param name="objBiz"></param>
        /// 
       
      
        #endregion
        #region Public Methods
    
     
        
  
        #endregion
    }
}
