using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class AttendanceTimeApplicantCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public AttendanceTimeApplicantCol(bool IsEmpty)
        { 
        }
        public AttendanceTimeApplicantCol()
        {
          

        }
        public AttendanceTimeApplicantCol(int intApplicantID)
        {
            AttendanceTimeApplicantDb _AttendanceTimeApplicantDb = new AttendanceTimeApplicantDb();
            _AttendanceTimeApplicantDb.AttendanceApplicant = intApplicantID;
            DataTable dtAttendanceTimeApplicant = _AttendanceTimeApplicantDb.Search();
            AttendanceTimeApplicantBiz objAttendanceTimeApplicantBiz;

            foreach (DataRow DR in dtAttendanceTimeApplicant.Rows)
            {
                objAttendanceTimeApplicantBiz = new AttendanceTimeApplicantBiz(DR);
                this.Add(objAttendanceTimeApplicantBiz);
            }

        }
        public AttendanceTimeApplicantCol(int intApplicantID,bool blSearch,DateTime dtStartDate,DateTime dtEndDate)
        {
            AttendanceTimeApplicantDb _AttendanceTimeApplicantDb = new AttendanceTimeApplicantDb();
            _AttendanceTimeApplicantDb.AttendanceApplicant = intApplicantID;
            _AttendanceTimeApplicantDb.DateSearch = blSearch;
            _AttendanceTimeApplicantDb.StartDate = dtStartDate;
            _AttendanceTimeApplicantDb.EndDate = dtEndDate;
            DataTable dtAttendanceTimeApplicant = _AttendanceTimeApplicantDb.Search();
            AttendanceTimeApplicantBiz objAttendanceTimeApplicantBiz;

            foreach (DataRow DR in dtAttendanceTimeApplicant.Rows)
            {
                objAttendanceTimeApplicantBiz = new AttendanceTimeApplicantBiz(DR);
                this.Add(objAttendanceTimeApplicantBiz);
            }

        }
        public AttendanceTimeApplicantCol(string strApplicantIDs, bool blSearch, DateTime dtStartDate, DateTime dtEndDate)
        {
            AttendanceTimeApplicantDb _AttendanceTimeApplicantDb = new AttendanceTimeApplicantDb();
            _AttendanceTimeApplicantDb.ApplicantIDs = strApplicantIDs;
            _AttendanceTimeApplicantDb.DateSearch = blSearch;
            _AttendanceTimeApplicantDb.StartDate = dtStartDate;
            _AttendanceTimeApplicantDb.EndDate = dtEndDate;
            DataTable dtAttendanceTimeApplicant = _AttendanceTimeApplicantDb.Search();
            AttendanceTimeApplicantBiz objAttendanceTimeApplicantBiz;

            foreach (DataRow DR in dtAttendanceTimeApplicant.Rows)
            {
                objAttendanceTimeApplicantBiz = new AttendanceTimeApplicantBiz(DR);
                this.Add(objAttendanceTimeApplicantBiz);
            }

        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual AttendanceTimeApplicantBiz this[int intIndex]
        {
            get
            {
                return (AttendanceTimeApplicantBiz)this.List[intIndex];
            }
        }

        public virtual void Add(AttendanceTimeApplicantBiz objAttendanceTimeApplicantBiz)
        {

            this.List.Add(objAttendanceTimeApplicantBiz);
        }
      
        #endregion
        #region Public Methods
        public bool IsWeekEnd(DateTime dtDate)
        {
            bool blAttendanceTimeFound = false;
            foreach (AttendanceTimeApplicantBiz objTempBiz in this)
            {
               if(dtDate.ToOADate()  >= objTempBiz.AttendanceTimeStartDate.ToOADate()  
                   && (dtDate.ToOADate() <= objTempBiz.AttendanceTimeEndDate.ToOADate() || !objTempBiz.AttendanceTimeEndDateStatus ))
               {
                   if (objTempBiz.AttendanceTimeDayCol.Count > 0)
                   {
                       foreach (AttendanceTimeDayBiz objDayBiz in objTempBiz.AttendanceTimeDayCol)
                       {
                           if (objDayBiz.Day == PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek)&& objDayBiz.IsVacation)
                           {
                               return true;
                           }
                       }
                       foreach (AttendanceTimeDayBiz objDayBiz in objTempBiz.AttendanceTimeDayCol)
                       {
                           if (objDayBiz.IsVacation)
                           {
                               return false;
                           }
                       }


                   }
                   else
                   {

                       if (PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek) == objTempBiz.AttendanceTimeWeekEnd)
                       {
                           return true;
                       }

                   }
                   return false;

              
                  
               }

 
            }
 
        
            return false;
        }
        public bool IsNotWeekEnd(DateTime dtDate)
        {
            bool blAttendanceTimeFound = false;
            foreach (AttendanceTimeApplicantBiz objTempBiz in this)
            {
                if (dtDate.ToOADate() >= objTempBiz.AttendanceTimeStartDate.ToOADate()
                    && (dtDate.ToOADate() <= objTempBiz.AttendanceTimeEndDate.ToOADate() || !objTempBiz.AttendanceTimeEndDateStatus))
                {
                    if (objTempBiz.AttendanceTimeDayCol.Count > 0)
                    {
                        foreach (AttendanceTimeDayBiz objDayBiz in objTempBiz.AttendanceTimeDayCol)
                        {
                            if (objDayBiz.Day == PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek) && objDayBiz.IsVacation)
                            {
                                return true;
                            }
                        }

                    }
                    if (!blAttendanceTimeFound)
                    {

                        if (PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek) == objTempBiz.AttendanceTimeWeekEnd)
                        {
                            return true;
                        }

                    }
                    return false;

                }

            }


            return false;
        }
        public void SetWorkDayFormalTimeInOut(ref ApplicantWorkDayBiz objBiz,out AttendanceTimeApplicantBiz ObjTimeBiz)
        {
            ObjTimeBiz = new AttendanceTimeApplicantBiz();
            if (objBiz == null)
            {

                return;
            }
            bool blAttendanceTimeFound = false;
            if (objBiz.WorkDay.Month == 12 && objBiz.WorkDay.Day == 3)
            {
                int x = 0;
            }
            foreach (AttendanceTimeApplicantBiz objTempBiz in this)
            {
                if (objTempBiz.AttendanceTimeStartDate.Month == 10 && objTempBiz.AttendanceTimeStartDate.Day == 27)
                {
                    int x = 0;
                }
               if(objBiz.WorkDay.ToOADate() >= SysUtility.Approximate(objTempBiz.AttendanceTimeStartDate.ToOADate(),1,ApproximateType.Down)
                   && (objBiz.WorkDay.ToOADate() <SysUtility.Approximate(objTempBiz.AttendanceTimeEndDate.ToOADate(),1,ApproximateType.Up) || !objTempBiz.AttendanceTimeEndDateStatus))
               {
                   if (objTempBiz.AttendanceTimeDayCol.Count > 0)
                   {
                       foreach (AttendanceTimeDayBiz objDayBiz in objTempBiz.AttendanceTimeDayCol)
                       {
                           if (objDayBiz.Day == PeriodBiz.GetDayOfWekkDays(objBiz.WorkDay.DayOfWeek)&& !objDayBiz.IsVacation)
                           {
                               try
                               {
                                  
                                   objBiz.FormalTimeIn = objDayBiz.TimeIn;
                                   objBiz.FormalTimeOut = objDayBiz.TimeOut;
                                   objBiz.DayHoursNo = objDayBiz.WorkHours;
                                   objBiz.FormalTimeIn = new DateTime(objBiz.WorkDay.Year, objBiz.WorkDay.Month, objBiz.WorkDay.Day,
                                  objBiz.FormalTimeIn.Hour, objBiz.FormalTimeIn.Minute, 0);
                                  // objBiz.FormalTimeOut = objTempBiz.AttendanceTimeOut;
                                   objBiz.FormalTimeOut = new DateTime(objBiz.WorkDay.Year, objBiz.WorkDay.Month,
                                       objBiz.WorkDay.Day, objBiz.FormalTimeOut.Hour, objBiz.FormalTimeOut.Minute, 0);
                                   blAttendanceTimeFound = true;
                                   break;
                               }
                               catch
                               {
 
                               }
                           }
                       }

                   }
                   if( !blAttendanceTimeFound)
                   {
                     
                       objBiz.FormalTimeIn = objTempBiz.AttendanceTimeIn;
                       objBiz.FormalTimeOut = objTempBiz.AttendanceTimeOut;
                       objBiz.DayHoursNo = objTempBiz.WorkHours;
                       objBiz.FormalTimeIn = new DateTime(objBiz.WorkDay.Year, objBiz.WorkDay.Month, objBiz.WorkDay.Day,
                      objBiz.FormalTimeIn.Hour, objBiz.FormalTimeIn.Minute, 0);
                       objBiz.FormalTimeOut = objTempBiz.AttendanceTimeOut;
                

                       objBiz.FormalTimeOut = new DateTime(objBiz.WorkDay.Year, objBiz.WorkDay.Month,
                           objBiz.WorkDay.Day, objBiz.FormalTimeOut.Hour, objBiz.FormalTimeOut.Minute, 0);
 
                   }
                   ObjTimeBiz = objTempBiz;
                   break;

               }
 
            }
            if (objBiz.FormalTimeOut < objBiz.FormalTimeIn)
                objBiz.FormalTimeOut = objBiz.FormalTimeOut.AddDays(1);
            objBiz.AttendanceTimeBiz = ObjTimeBiz;
 
        }
        #endregion
    }
}
