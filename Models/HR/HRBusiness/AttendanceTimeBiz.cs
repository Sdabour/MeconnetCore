using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceTimeBiz
    {
        #region Private Data       
        protected AttendanceTimeDb _AttendanceTimeDb;
        AttendanceTimeDayCol _AttendanceTimeDayCol;
        #endregion
        #region Constructors
        public AttendanceTimeBiz()
        {            
            _AttendanceTimeDb = new AttendanceTimeDb();
        }
        public AttendanceTimeBiz(DataRow objDr)
        {
            _AttendanceTimeDb = new AttendanceTimeDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AttendanceTimeDb.ID = value;
            }
            get
            {
                return _AttendanceTimeDb.ID;
            }
        }
        public DateTime AttendanceTimeStartDate
        {
            set
            {
                _AttendanceTimeDb.StartDate = value;
            }
            get
            {
                return  new DateTime (_AttendanceTimeDb.StartDate.Year,_AttendanceTimeDb.StartDate.Month,_AttendanceTimeDb.StartDate.Day);
            }
        }
        public DateTime AttendanceTimeEndDate
        {
            set
            {
                _AttendanceTimeDb.EndDate = value;
            }
            get
            {
                return new DateTime(_AttendanceTimeDb.EndDate.Year, _AttendanceTimeDb.EndDate.Month, _AttendanceTimeDb.EndDate.Day);
            }
        }
        public DateTime AttendanceTimeIn
        {
            set
            {
                _AttendanceTimeDb.TimeIn = value;
            }
            get
            {
                double dblTime = PeriodBiz.GetMinutes( _AttendanceTimeDb.TimeIn.ToString("HH:mm"));
                dblTime = SysUtility.Approximate(dblTime, 15, ApproximateType.Default);
                DateTime Returned = AttendanceTimeStartDate;
                Returned = DateTime.FromOADate( SysUtility.Approximate( Returned.ToOADate() - 2,1,ApproximateType.Down));
                Returned = Returned.AddMinutes(dblTime);
                return Returned;//_AttendanceTimeDb.TimeIn;
            }
        }
        public DateTime AttendanceTimeOut
        {
            set
            {
                _AttendanceTimeDb.TimeOut = value;
            }
            get
            {
                double dblTime = PeriodBiz.GetMinutes(_AttendanceTimeDb.TimeOut.ToString("HH:mm"));
                dblTime = SysUtility.Approximate(dblTime, 15, ApproximateType.Default);
                DateTime Returned = AttendanceTimeStartDate;
                Returned = DateTime.FromOADate(SysUtility.Approximate(Returned.ToOADate() - 2, 1, ApproximateType.Down));
                Returned = Returned.AddMinutes(dblTime);
                return Returned;
                //return _AttendanceTimeDb.TimeOut;
            }
        }
        public string strAttendanceTimeStartDate
        {
            get
            {
                return AttendanceTimeStartDate.ToString("yyyy-MM-dd");
            }
        }
        public string strAttendanceTimeEndDate
        {
            get
            {
                if (AttendanceTimeEndDateStatus == true)
                    return AttendanceTimeEndDate.ToString("yyyy-MM-dd");
                else
                    return "";
            }
        }
        public string strAttendanceTimeIn
        {
            get
            {
                return AttendanceTimeIn.ToString("hh:mm:ss tt");
            }
        }
        public string strAttendanceTimeOut
        {
            get
            {
                return AttendanceTimeOut.ToString("hh:mm:ss tt");
            }
        }
        public bool AttendanceTimeEndDateStatus
        {
            set
            {
                _AttendanceTimeDb.EndDateStatus = value;
            }
            get
            {
                return _AttendanceTimeDb.EndDateStatus;
            }
        }
        public Days AttendanceTimeWeekEnd
        {
            set
            {
                _AttendanceTimeDb.WeekEnd = (int)value;
            }
            get
            {
                return (Days)_AttendanceTimeDb.WeekEnd;
            }
        }
        public int Periority
        {
            set
            {
                _AttendanceTimeDb.Periority = value;
            }
            get
            {
                return _AttendanceTimeDb.Periority;
            }
        }
        public double WorkHours
        {
            set
            {
                _AttendanceTimeDb.WorkHours = value;
            }
            get
            {
                return _AttendanceTimeDb.WorkHours;
            }
        }
        public AttendanceTimeDayCol AttendanceTimeDayCol
        {
            set
            {
                _AttendanceTimeDayCol = value;
            }
            get
            {
                if (_AttendanceTimeDayCol == null)
                {
                    _AttendanceTimeDayCol = new AttendanceTimeDayCol(true);
                    if (ID != 0)
                    {
                        AttendanceTimeDayDb objDb = new AttendanceTimeDayDb();
                        objDb.AttendanceTime = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AttendanceTimeDayCol.Add(new AttendanceTimeDayBiz(objDr));
                        }
                    }
                }
                return _AttendanceTimeDayCol;

            }
        }
        public bool IsLimited
        {
            set
            {
                _AttendanceTimeDb.IsLimited = value;
            }
            get
            {
                return _AttendanceTimeDb.IsLimited;
            }
        }
        public DateTime MaxLimit
        {
            set
            {
                _AttendanceTimeDb.MaxLimit = value;
            }
            get
            {
                return _AttendanceTimeDb.MaxLimit;
            }
        }
        public DateTime MinLimit
        {
            set
            {
                _AttendanceTimeDb.MinLimit = value;
            }
            get
            {
                return _AttendanceTimeDb.MinLimit;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            if (_AttendanceTimeDayCol != null)
                ((AttendanceTimeDb)_AttendanceTimeDb).DayTable = _AttendanceTimeDayCol.GetTable();
            _AttendanceTimeDb.Add();          
        }
        public virtual void Edit()
        {
            if (_AttendanceTimeDayCol != null)
                ((AttendanceTimeDb)_AttendanceTimeDb).DayTable = _AttendanceTimeDayCol.GetTable();
            _AttendanceTimeDb.Edit();
        }
        public virtual void Delete()
        {
            _AttendanceTimeDb.Delete();
        }
        public bool CheckForWeekEnd(DateTime dtDate)
        {
            bool blAttendanceTimeFound = false;
            foreach (AttendanceTimeDayBiz objDayBiz in AttendanceTimeDayCol)
            {
                if (objDayBiz.Day == PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek))
                {
                       
                        blAttendanceTimeFound = true;
                        if (objDayBiz.IsVacation)
                            return true;
                        break;
                    
                }

            }
            if (!blAttendanceTimeFound)
            {
                if (PeriodBiz.GetDayOfWekkDays(dtDate.DayOfWeek) == AttendanceTimeWeekEnd)
                {
                      return true;
                }
            }

            return false;
        }
        #endregion
    }
}
