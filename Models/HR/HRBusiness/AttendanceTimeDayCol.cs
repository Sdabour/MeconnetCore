using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class AttendanceTimeDayCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public AttendanceTimeDayCol(bool IsEmpty)
        {
        }
     
        public AttendanceTimeDayCol(int intAttendanceTime)
        {
            AttendanceTimeDayDb _AttendanceTimeApplicantDayDb = new AttendanceTimeDayDb();
            _AttendanceTimeApplicantDayDb.AttendanceTime = intAttendanceTime;
            DataTable dtAttendanceTimeApplicantDay = _AttendanceTimeApplicantDayDb.Search();
            AttendanceTimeDayBiz objAttendanceTimeApplicantDayBiz;
            foreach (DataRow DR in dtAttendanceTimeApplicantDay.Rows)
            {
                objAttendanceTimeApplicantDayBiz = new AttendanceTimeDayBiz(DR);
                this.Add(objAttendanceTimeApplicantDayBiz);
            }
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual AttendanceTimeDayBiz this[int intIndex]
        {
            get
            {
                return (AttendanceTimeDayBiz)this.List[intIndex];
            }
        }

        public virtual void Add(AttendanceTimeDayBiz objAttendanceTimeApplicantDayBiz)
        {

            this.List.Add(objAttendanceTimeApplicantDayBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRAttendanceTimeDay");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("AttendanceTime"), new DataColumn("AttendanceTimeDay"),
                new DataColumn("AttendanceTimeIn"),new DataColumn("AttendanceTimeOut"),new DataColumn("IsVacation"),new DataColumn("AttendanceWorkHours"),new DataColumn("Shift")});
            DataRow objDr;
            foreach (AttendanceTimeDayBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["AttendanceTime"] = objBiz.AttendanceTime;
                objDr["AttendanceTimeDay"] = (int)objBiz.Day;
                objDr["AttendanceTimeIn"] = objBiz.TimeIn;
                objDr["AttendanceTimeOut"] = objBiz.TimeOut;
                objDr["IsVacation"] = objBiz.IsVacation;
                objDr["AttendanceWorkHours"] = objBiz.WorkHours;
                objDr["Shift"] = objBiz.ShiftBiz.ID; 
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods

        #endregion
    }
}
