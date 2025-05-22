using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceTimeDayBiz
    {
        #region Private Data
        AttendanceTimeDayDb _AttendanceTimeDayDb;
        ShiftBiz _ShiftBiz;
        #endregion
        #region Constructors
        public AttendanceTimeDayBiz()
        {
            _AttendanceTimeDayDb = new AttendanceTimeDayDb();
            _ShiftBiz = new ShiftBiz();
        }
        public AttendanceTimeDayBiz(DataRow objDr)
        {
            _AttendanceTimeDayDb = new AttendanceTimeDayDb(objDr);
            _ShiftBiz = new ShiftBiz(objDr);
        }

        #endregion
        #region Public Properties
        public int AttendanceTime
        {
            set
            {
                _AttendanceTimeDayDb.AttendanceTime = value;
            }
            get
            {
                return _AttendanceTimeDayDb.AttendanceTime;
            }
        }
        public ShiftBiz ShiftBiz
        {
            set
            {
                _ShiftBiz = value;
            }
            get
            {
                return _ShiftBiz;
            }
        }
        public Days Day
        {
            set
            {
                _AttendanceTimeDayDb.Day = (int)value;
            }
            get
            {
                if (_AttendanceTimeDayDb.Day == (int)Days.Saturday)
                    return Days.Saturday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Sunday)
                    return Days.Sunday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Monday)
                    return Days.Monday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Tuesday)
                    return Days.Tuesday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Wednesday)
                    return Days.Wednesday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Thursday)
                    return Days.Thursday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Friday)
                    return Days.Friday;
                else
                    return Days.Notdefined;
            }
        }
        public string DayStr
        {
            get
            {

                if (_AttendanceTimeDayDb.Day == (int)Days.Saturday)
                    return "السبت";//Days.Saturday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Sunday)
                    return "الاحد";//Days.Sunday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Monday)
                    return "الاثنين";//Days.Monday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Tuesday)
                    return "الثلاثاء";//Days.Thursday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Wednesday)
                    return "الاربعاء";//Days.Wednesday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Thursday)
                    return "الخميس";//Days.Tuesday;
                else if (_AttendanceTimeDayDb.Day == (int)Days.Friday)
                    return "الجمعة";//Days.Friday;
                else
                    return "غير محدد";//Days.Notdefined;

            }
        }
        public static List<string> DaysStr
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("غير محدد");
                Returned.Add("السبت");
                Returned.Add("الأحد");
                Returned.Add("الإثنين");
                Returned.Add("الثلاثاء");
                Returned.Add("الأربعاء");
                Returned.Add("الخميس");
                Returned.Add("الجمعة");
                return Returned;
            }
        }
        public DateTime TimeIn
        {
            set
            {
                _AttendanceTimeDayDb.TimeIn = value;
            }
            get
            {
                double dblTime = PeriodBiz.GetMinutes(_AttendanceTimeDayDb.TimeIn.ToString("HH:mm"));
                dblTime = SysUtility.Approximate(dblTime, 15, ApproximateType.Default);
                DateTime Returned = new DateTime(_AttendanceTimeDayDb.TimeIn.Year, _AttendanceTimeDayDb.TimeIn.Month, _AttendanceTimeDayDb.TimeIn.Day);
                
                Returned = DateTime.FromOADate(SysUtility.Approximate(Returned.ToOADate() - 2, 1, ApproximateType.Down));
                Returned = Returned.AddMinutes(dblTime);
                return Returned;//_AttendanceTimeDb.TimeIn;
                //return _AttendanceTimeDayDb.TimeIn;
            }
        }
        public DateTime TimeOut
        {
            set
            {
                _AttendanceTimeDayDb.TimeOut = value;
            }
            get
            {

                double dblTime = PeriodBiz.GetMinutes(_AttendanceTimeDayDb.TimeOut.ToString("HH:mm"));
                dblTime = SysUtility.Approximate(dblTime, 15, ApproximateType.Default);
                DateTime Returned = new DateTime(_AttendanceTimeDayDb.TimeOut.Year, _AttendanceTimeDayDb.TimeOut.Month, _AttendanceTimeDayDb.TimeOut.Day);
                Returned = DateTime.FromOADate(SysUtility.Approximate(Returned.ToOADate() - 2, 1, ApproximateType.Down));
                Returned = Returned.AddMinutes(dblTime);
                return Returned;//_AttendanceTimeDb.TimeIn;
               // return _AttendanceTimeDayDb.TimeOut;
            }
        }
        public bool IsVacation
        {
            set
            {
                _AttendanceTimeDayDb.IsVacation = value;
            }
            get
            {
                return _AttendanceTimeDayDb.IsVacation;
            }
        }
        public int WorkHours
        {
            set
            {
                _AttendanceTimeDayDb.WorkHours = value;
            }
            get
            {
                return _AttendanceTimeDayDb.WorkHours;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _AttendanceTimeDayDb.ShiftID = _ShiftBiz.ID;
            _AttendanceTimeDayDb.Add();
        }
        public void Edit()
        {
            _AttendanceTimeDayDb.ShiftID = _ShiftBiz.ID;
            _AttendanceTimeDayDb.Edit();
        }
        public void Delete()
        {
            _AttendanceTimeDayDb.Delete();
        }
        #endregion
    }

}