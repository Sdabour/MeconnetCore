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
    public class ApplicantWorkDayCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkDayCol()
        { 
        }       
        #endregion
        #region Private Property
        int RealTotalVacationNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                 
                        intCount++;
                }
                return intCount;
            }
        }
        int RealTotalAbsentDayNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    if (objBiz.IsAbsent == true)
                        intCount++;
                }
                return intCount;
            }
        }
        WorkDayFlatCol _FlatCol;
        public WorkDayFlatCol FlatCol
        {
            get
            {
                if (_FlatCol == null)
                {
                    _FlatCol = new WorkDayFlatCol(true);
                    foreach (ApplicantWorkDayBiz objBiz in this)
                    {
                        _FlatCol.Add(objBiz.FlatBiz);
                    }
                }
                return _FlatCol;
            }
        }
        #endregion
        #region Public Properties
        public int TotalAbsentDayNo
        {
            get
            {
                int intCount = RealTotalAbsentDayNo;
                if (intCount + RealTotalVacationNo > 30)
                {
                    intCount = 0;
                    foreach (ApplicantWorkDayBiz objBiz in this)
                    {
                        if (objBiz.IsAbsent == true && objBiz.WorkDay.Day <= 30)
                            intCount++;
                    }
                }
                return intCount;
            }
        }
        public int TotalBonusDayNo
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    if (objBiz.IsOverDay)
                        Returned++;
                }
                return Returned;
            }
        }
        public double TotalTimeDelay
        {
            get
            {
                double dblCount = 0;
                string strTemp = "";
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    strTemp = PeriodBiz.GetTimeString(objBiz.TimeDelay);
                    if ( objBiz.TimeDelay != 0)
                        dblCount = dblCount + objBiz.TimeDelay;
                }
                //dblCount = dblCount - A
                return dblCount;
            }
        }
        public double TotalEarlierOut
        {
            get
            {
                double dblCount = 0;
                string strTemp = "";
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    strTemp = PeriodBiz.GetTimeString(objBiz.EarlierOut);
                    if (objBiz.EarlierOut != 0)
                        dblCount = dblCount + objBiz.EarlierOut;
                }
                return dblCount;
            }
        }
        public double TotalOverTime
        {
            get
            {
                double dblCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    //if ( objBiz.TimeDelay != 0)
                        dblCount = dblCount + objBiz.OverTime;
                }
                return dblCount;
            }
        }
        public int TotalVacationNo
        {
            get
            {
                int intCount = RealTotalVacationNo;
                if (intCount + RealTotalAbsentDayNo > 30)
                {
                    intCount = 0;
                    foreach (ApplicantWorkDayBiz objBiz in this)
                    {
                    
                            intCount++;
                    }
                }
                return intCount;
            }
        }
        public int TotalVacationCommonNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                  
                        {
                            intCount++;
                        }
                }
                return intCount;
            }
        }
        public int TotalVacationAccidentNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                   
                        intCount++;
                }
                return intCount;
            }
        }
        public int TotalVacationSickNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                  
                        intCount++;
                }
                return intCount;
            }
        }
        public int TotalFurloughNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                   
                        intCount++;
                }
                return intCount;
            }
        }
        public float TotalFurloughDiscountValue
        {
            get
            {
                float flDiscountValue = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                 
                }
                return flDiscountValue;
            }
        }
        public float TotalVacationDiscountValue
        {
            get
            {
                float flDiscountValue = 0;
                // ArrayList arr = new ArrayList();

                foreach (ApplicantWorkDayBiz objBiz in this)
                {


                    if (flDiscountValue > 30)
                        flDiscountValue--;
                }
                    return flDiscountValue;
                
            }
        } 
        public int TotalMissionNo
        {
            get
            {
                int intCount = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                  
                        intCount++;
                }
                return intCount;
            }
        }
        public int TotalConsumedBankingTime
        {
            get
            {
                return 0;
            }
        }
        public int TotalMinutes
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    Returned += objBiz.TotalMinutes;
                }
                return Returned;
            }
        }
        public int FormalTotalMinutes
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    Returned += objBiz.FormalTotalMinutes;
                }
                return Returned;
            }
        }
        public int ErrorCount
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    if (objBiz.CommentError != null && objBiz.CommentError != "")
                        Returned++;
                }

                return Returned;
            }
        }
        public int NonCountedDays
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    if (objBiz.ISNonCountedDay && objBiz.WorkDay.Day <31)
                        Returned++;
                }
                if (this[0].WorkDay.Month == 2 )
                {
                    int intPlusDays = 0;
                    for (int intIndex = 0; intIndex < Count; intIndex++)
                    {
                        if (this[intIndex].WorkDay.Month == 3)
                        {
                            intPlusDays = intIndex - 1;
                            break;
                        }
                    }
                    if (this[intPlusDays].ISNonCountedDay)
                    {
                        Returned += (30 - this[intPlusDays].WorkDay.Day);
                    }
                }
                //if (Returned==Count && this[0].WorkDay.Day == this[Count - 1].WorkDay.Day + 1 && Count <30)
                //{
                //    Returned += 30 - Count;

 
                //}
                return Returned;
            }
        }
        public int OverDayCount
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    if (objBiz.IsOverDay)
                        Returned++;
                }
              
                return Returned;
            }
        }
        public AttendanceStatementAttendanceTimeCol AttendanceTimeCol
        {
            get
            {
                AttendanceStatementAttendanceTimeCol Returned = new AttendanceStatementAttendanceTimeCol(true);
                AttendanceStatementAttendanceTimeBiz objTemp = new AttendanceStatementAttendanceTimeBiz();

                foreach (ApplicantWorkDayBiz objBiz in this)
                {
                    //if (objTemp.AttendanceStatement == 0 || objTemp.AttendanceTime != objBiz.AttendanceTimeBiz.ID)
                    //{
                    //    objTemp = new AttendanceStatementAttendanceTimeBiz();
                    //    objTemp.AttendanceTime = objBiz.AttendanceTimeBiz.ID;
                        
                    //    objTemp.DateFrom = objBiz.WorkDay;
                    //}
                    //else
                    //{
                    //    objTemp.DateTo = objBiz.WorkDay;
                    //}
                    objTemp = new AttendanceStatementAttendanceTimeBiz();
                    objTemp.AttendanceTime = objBiz.AttendanceTimeBiz.ID;
                    objTemp.DateFrom = objBiz.WorkDay;
                    objTemp.DateTo = objBiz.WorkDay;
                    Returned.Add(objTemp);
 
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkDayBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkDayBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkDayBiz objApplicantWorkDayBiz)
        {
            objApplicantWorkDayBiz.WorkDayCol = this;
            this.List.Add(objApplicantWorkDayBiz);
            objApplicantWorkDayBiz.Index = Count - 1;
        }     
        
        #endregion
        #region Public Methods

        public ApplicantWorkDayBiz GetRefByDate(DateTime dtWorkDay)
        {
            ApplicantWorkDayBiz Returned = new ApplicantWorkDayBiz();
            foreach (ApplicantWorkDayBiz objBiz in this)
            {
                if (objBiz.WorkDay == dtWorkDay)
                {
                    return objBiz;
                }

            }
            return Returned;

        }
        #endregion

    }
}
