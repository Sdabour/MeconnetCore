using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class AttendanceTimeDayDb
    {
        #region Private Data
        protected int _AttendanceTime;
        protected int _Day;
        protected int _ShiftID;
        protected DateTime _TimeIn;
        protected DateTime _TimeOut;
        protected bool _IsVacation;
        protected int _WorkHours;
        #endregion
        #region Constructors
        public AttendanceTimeDayDb()
        {
        }
        public AttendanceTimeDayDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int AttendanceTime
        {
            set
            {
                _AttendanceTime = value;
            }
            get
            {
                return _AttendanceTime;
            }
        }
        public int Day
        {
            set
            {
                _Day = value;
            }
            get
            {
                return _Day;
            }
        }
        public int ShiftID
        {
            set
            {
                _ShiftID = value;
            }
            get
            {
                return _ShiftID;
            }
        }
        public DateTime TimeIn
        {
            set
            {
                _TimeIn = value;
            }
            get
            {
                return _TimeIn;
            }
        }
        public DateTime TimeOut
        {
            set
            {
                _TimeOut = value;
            }
            get
            {
                return _TimeOut;
            }
        }
        public bool IsVacation
        {
            set
            {
                _IsVacation = value;
            }
            get
            {
                return _IsVacation;
            }
        }
        public int WorkHours
        {
            set
            {
                _WorkHours = value;
            }
            get
            {
                return _WorkHours;
            }
        }
        public string AddStr
        {
            get
            {
                double dblTimeIn = _TimeIn.ToOADate() - 2;
                _TimeOut = _TimeOut.AddSeconds(1);
                double dblTimeOut = _TimeOut.ToOADate() - 2;

                int intIsVacation = _IsVacation ? 1 : 0;
                string ReturnStr = " INSERT INTO HRAttendanceTimeDay"+
                                   " (AttendanceTime, AttendanceTimeDay,"+
                                   " AttendanceTimeIn, AttendanceTimeOut,IsVacation,AttendanceWorkHours,Shift," +
                                   " UsrIns, TimIns)"+
                                   " VALUES  ("+ _AttendanceTime +","+ _Day +","+
                                   " " + dblTimeIn + "," + dblTimeOut + "," + intIsVacation + ","+ _WorkHours +","+ _ShiftID +"," +
                                   " "+ SysData.CurrentUser.ID +",GetDate())";
                return ReturnStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblTimeIn = _TimeIn.ToOADate() - 2;
                _TimeOut = _TimeOut.AddSeconds(1);
                double dblTimeOut = _TimeOut.ToOADate() - 2;
                int intIsVacation = _IsVacation ? 1 : 0;
                string ReturnStr = " UPDATE    HRAttendanceTimeDay "+
                                   " SET  AttendanceTimeIn =" + dblTimeIn + "" +
                                   " ,AttendanceTimeOut =" + dblTimeOut + "" +
                                   " ,IsVacation =" + intIsVacation + ",AttendanceWorkHours=" + _WorkHours + ",Shift="+ _ShiftID +"" +
                                   " ,UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " WHERE  (AttendanceTime = "+ _AttendanceTime +") AND (AttendanceTimeDay = "+ _Day +")";
                return ReturnStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnStr = " DELETE FROM HRAttendanceTimeDay " +
                                   " WHERE  (AttendanceTime = " + _AttendanceTime + ") ";
                if (_Day != 0)
                    ReturnStr = ReturnStr + " AND (AttendanceTimeDay = " + _Day + ")";
                return ReturnStr;
            }
        }
        public string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT HRAttendanceTimeDay.AttendanceTime, HRAttendanceTimeDay.AttendanceTimeDay,"+
                                   " HRAttendanceTimeDay.AttendanceWorkHours,HRAttendanceTimeDay.Shift, " +
                                   " HRAttendanceTimeDay.AttendanceTimeIn, HRAttendanceTimeDay.AttendanceTimeOut,HRAttendanceTimeDay.IsVacation,HRAttendanceTimeDay.Shift,ShiftTable.* " +
                                   " FROM  HRAttendanceTimeDay "+
                                   " Left Outer Join (" + ShiftDb.SearchStr + ") as ShiftTable On ShiftTable.ShiftID = HRAttendanceTimeDay.Shift";
                return ReturnStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _AttendanceTime = int.Parse(objDr["AttendanceTime"].ToString());
            _Day = int.Parse(objDr["AttendanceTimeDay"].ToString());
            _TimeIn = DateTime.Parse(objDr["AttendanceTimeIn"].ToString());
            _TimeOut = DateTime.Parse(objDr["AttendanceTimeOut"].ToString());
            _IsVacation = bool.Parse(objDr["IsVacation"].ToString());
            _WorkHours = int.Parse(objDr["AttendanceWorkHours"].ToString());
            if (objDr["Shift"].ToString() != "")
                _ShiftID = int.Parse(objDr["Shift"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public  DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_AttendanceTime != 0)
                StrSql = StrSql + " And HRAttendanceTimeDay.AttendanceTime = " + _AttendanceTime + "";
            if (_Day != 0)
                StrSql = StrSql + " And HRAttendanceTimeDay.AttendanceTimeDay = " + _Day + "";

            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
