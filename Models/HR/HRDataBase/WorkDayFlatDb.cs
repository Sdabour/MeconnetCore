using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public  class WorkDayFlatDb
    {

        #region Constructor
        public WorkDayFlatDb()
        {
        }
        public WorkDayFlatDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
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
        int _ApplicantID;
        public int ApplicantID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }
        }
        int _ApplicantAttendanceStatement;
        public int ApplicantAttendanceStatement
        {
            set
            {
                _ApplicantAttendanceStatement = value;
            }
            get
            {
                return _ApplicantAttendanceStatement;
            }
        }
        int _AttendanceStatement;
        public int AttendanceStatement { set => _AttendanceStatement = value; }
        int _FurloughID;
        public int FurloughID
        {
            set
            {
                _FurloughID = value;
            }
            get
            {
                return _FurloughID;
            }
        }
        int _VacationID;
        public int VacationID
        {
            set
            {
                _VacationID = value;
            }
            get
            {
                return _VacationID;
            }
        }
        int _MissionID;
        public int MissionID
        {
            set
            {
                _MissionID = value;
            }
            get
            {
                return _MissionID;
            }
        }
        DateTime _Date;
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
        DateTime _FormalTimeIn;
        public DateTime FormalTimeIn
        {
            set
            {
                _FormalTimeIn = value;
            }
            get
            {
                return _FormalTimeIn;
            }
        }
        DateTime _FormalTimeOut;
        public DateTime FormalTimeOut
        {
            set
            {
                _FormalTimeOut = value;
            }
            get
            {
                return _FormalTimeOut;
            }
        }

        DateTime _CheckIn;
        public DateTime CheckIn
        {
            set
            {
                _CheckIn = value;
            }
            get
            {
                return _CheckIn;
            }
        }
        bool _HasNoCheckOut;
        public bool HasNoCheckOut { set => _HasNoCheckOut = value; get => _HasNoCheckOut; }
        DateTime _CheckOut;
        public DateTime CheckOut
        {
            set
            {
                _CheckOut = value;
            }
            get
            {
                return _CheckOut;
            }
        }

        double _DayHourNo;
        public double DayHourNo
        {
            set
            {
                _DayHourNo = value;
            }
            get
            {
                return _DayHourNo;
            }
        }
        bool _IsAbsent;
        public bool IsAbsent
        {
            set
            {
                _IsAbsent = value;
            }
            get
            {
                return _IsAbsent;
            }
        }
        bool _IsIgnoreDelay;
        public bool IsIgnoreDelay
        {
            set
            {
                _IsIgnoreDelay = value;
            }
            get
            {
                return _IsIgnoreDelay;
            }
        }
        bool _ManualIgnoreDelay;
        public bool ManualIgnoreDelay
        {
            set
            {
                _ManualIgnoreDelay = value;
            }
            get
            {
                return _ManualIgnoreDelay;
            }
        }
        double _ManualIgnoreDelayValue;
        public double ManualIgnoreDelayValue
        {
            set
            {
                _ManualIgnoreDelayValue = value;
            }
            get
            {
                return _ManualIgnoreDelayValue;
            }
        }
        int _TotalMinutes;
        public int TotalMinutes
        {
            set
            {
                _TotalMinutes = value;
            }
            get
            {
                return _TotalMinutes;
            }
        }
        int _FormalTotalMinutes;
        public int FormalTotalMinutes
        {
            set
            {
                _FormalTotalMinutes = value;
            }
            get
            {
                return _FormalTotalMinutes;
            }
        }
        double _TimeDelay;
        public double TimeDelay
        {
            set
            {
                _TimeDelay = value;
            }
            get
            {
                return _TimeDelay;
            }
        }
        double _EarlierOut;
        public double EarlierOut
        {
            set
            {
                _EarlierOut = value;
            }
            get
            {
                return _EarlierOut;
            }
        }
        double _OverTime;
        public double OverTime
        {
            set
            {
                _OverTime = value;
            }
            get
            {
                return _OverTime;
            }
        }
        bool _IsVacancy;
        public bool IsVacancy
        {
            set
            {
                _IsVacancy = value;
            }
            get
            {
                return _IsVacancy;
            }
        }
        bool _IsOverDay;
        public bool IsOverDay
        {
            set
            {
                _IsOverDay = value;
            }
            get
            {
                return _IsOverDay;
            }
        }
        bool _IsAlterDay;
        public bool IsAlterDay
        {
            set
            {
                _IsAlterDay = value;
            }
            get
            {
                return _IsAlterDay;
            }
        }
        bool _IsMission;
        public bool IsMission
        {
            set
            {
                _IsMission = value;
            }
            get
            {
                return _IsMission;
            }
        }
        bool _ISNonCountedDay;
        public bool ISNonCountedDay
        {
            set
            {
                _ISNonCountedDay = value;
            }
            get
            {
                return _ISNonCountedDay;
            }
        }
        string _CommentError;
        public string CommentError
        {
            set
            {
                _CommentError = value;
            }
            get
            {
                return _CommentError;
            }
        }
        bool _IsVacationAccident;
        public bool IsVacationAccident
        {
            set
            {
                _IsVacationAccident = value;
            }
            get
            {
                return _IsVacationAccident;
            }
        }
        bool _IsVacationCommon;
        public bool IsVacationCommon
        {
            set
            {
                _IsVacationCommon = value;
            }
            get
            {
                return _IsVacationCommon;
            }
        }
        bool _IsVacationSick;
        public bool IsVacationSick
        {
            set
            {
                _IsVacationSick = value;
            }
            get
            {
                return _IsVacationSick;
            }
        }
        string _StatementIDs;
        public string StatementIDs
        { set => _StatementIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HRApplicantWorkerWorkDay (ApplicantID,ApplicantAttendanceStatement,FurloughID,VacationID,MissionID,WorkDayDate,FormalTimeIn,FormalTimeOut,CheckIn,CheckOut,DayHourNo,IsAbsent,IsIgnoreDelay,WorkDayManualIgnoreDelay,WorkDayManualIgnoreDelayValue,TotalMinutes,FormalTotalMinutes,TimeDelay,EarlierOut,OverTime,IsVacancy,IsOverDay,IsAlterDay,IsMission,ISNonCountedDay,CommentError,IsVacationAccident,IsVacationCommon,IsVacationSick,UsrIns,TimIns) values (" + ApplicantID + "," + ApplicantAttendanceStatement + "," + FurloughID + "," + VacationID + "," + MissionID + "," + (Date.ToOADate() - 2).ToString() + "," + (FormalTimeIn.ToOADate() - 2).ToString() + "," + (FormalTimeOut.ToOADate() - 2).ToString() + "," +
    (CheckIn.ToOADate() - 2).ToString() + "," + (CheckOut.ToOADate() - 2).ToString() + "," + DayHourNo + "," + (IsAbsent ? 1 : 0) + "," + (IsIgnoreDelay ? 1 : 0) + "," + (ManualIgnoreDelay ? 1 : 0) + "," + ManualIgnoreDelayValue + "," + TotalMinutes + "," + FormalTotalMinutes + "," + TimeDelay + "," + EarlierOut + "," + OverTime + "," + (IsVacancy ? 1 : 0) + "," + (IsOverDay ? 1 : 0) + "," + (IsAlterDay ? 1 : 0) + "," + (IsMission ? 1 : 0) + "," + (ISNonCountedDay ? 1 : 0) + ",'" + CommentError + "'," + (IsVacationAccident ? 1 : 0) + "," + (IsVacationCommon ? 1 : 0) + "," + (IsVacationSick ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRApplicantWorkerWorkDay set " + "WorkDayID=" + ID + "" +
           ",ApplicantID=" + ApplicantID + "" +
           ",ApplicantAttendanceStatement=" + ApplicantAttendanceStatement + "" +
           ",FurloughID=" + FurloughID + "" +
           ",VacationID=" + VacationID + "" +
           ",MissionID=" + MissionID + "" +
           ",WorkDayDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",FormalTimeIn=" + (FormalTimeIn.ToOADate() - 2).ToString() + "" +
           ",FormalTimeOut=" + (FormalTimeOut.ToOADate() - 2).ToString() + "" +
           ",DayHourNo=" + DayHourNo + "" +
           ",IsAbsent=" + (IsAbsent ? 1 : 0) + "" +
           ",IsIgnoreDelay=" + (IsIgnoreDelay ? 1 : 0) + "" +
           ",WorkDayManualIgnoreDelay=" + (ManualIgnoreDelay ? 1 : 0) + "" +
           ",WorkDayManualIgnoreDelayValue=" + ManualIgnoreDelayValue + "" +
           ",TotalMinutes=" + TotalMinutes + "" +
           ",FormalTotalMinutes=" + FormalTotalMinutes + "" +
           ",TimeDelay=" + TimeDelay + "" +
           ",EarlierOut=" + EarlierOut + "" +
           ",OverTime=" + OverTime + "" +
           ",IsVacancy=" + (IsVacancy ? 1 : 0) + "" +
           ",IsOverDay=" + (IsOverDay ? 1 : 0) + "" +
           ",IsAlterDay=" + (IsAlterDay ? 1 : 0) + "" +
           ",IsMission=" + (IsMission ? 1 : 0) + "" +
           ",ISNonCountedDay=" + (ISNonCountedDay ? 1 : 0) + "" +
           ",CommentError='" + CommentError + "'" +
           ",IsVacationAccident=" + (IsVacationAccident ? 1 : 0) + "" +
           ",IsVacationCommon=" + (IsVacationCommon ? 1 : 0) + "" +
           ",IsVacationSick=" + (IsVacationSick ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRApplicantWorkerWorkDay set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select WorkDayID,ApplicantID,ApplicantAttendanceStatement,FurloughID,VacationID,MissionID,WorkDayDate,FormalTimeIn,FormalTimeOut,CheckIn,CheckOut,DayHourNo,IsAbsent,IsIgnoreDelay,WorkDayManualIgnoreDelay,WorkDayManualIgnoreDelayValue,TotalMinutes,FormalTotalMinutes,TimeDelay,EarlierOut,OverTime,IsVacancy,IsOverDay,IsAlterDay,IsMission,ISNonCountedDay,CommentError,IsVacationAccident,IsVacationCommon,IsVacationSick from HRApplicantWorkerWorkDay  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["WorkDayID"] != null)
                int.TryParse(objDr["WorkDayID"].ToString(), out _ID);

            if (objDr.Table.Columns["ApplicantID"] != null)
                int.TryParse(objDr["ApplicantID"].ToString(), out _ApplicantID);

            if (objDr.Table.Columns["ApplicantAttendanceStatement"] != null)
                int.TryParse(objDr["ApplicantAttendanceStatement"].ToString(), out _ApplicantAttendanceStatement);

            if (objDr.Table.Columns["FurloughID"] != null)
                int.TryParse(objDr["FurloughID"].ToString(), out _FurloughID);

            if (objDr.Table.Columns["VacationID"] != null)
                int.TryParse(objDr["VacationID"].ToString(), out _VacationID);

            if (objDr.Table.Columns["MissionID"] != null)
                int.TryParse(objDr["MissionID"].ToString(), out _MissionID);

            if (objDr.Table.Columns["WorkDayDate"] != null)
                DateTime.TryParse(objDr["WorkDayDate"].ToString(), out _Date);

            if (objDr.Table.Columns["FormalTimeIn"] != null)
                DateTime.TryParse(objDr["FormalTimeIn"].ToString(), out _FormalTimeIn);

            if (objDr.Table.Columns["FormalTimeOut"] != null)
                DateTime.TryParse(objDr["FormalTimeOut"].ToString(), out _FormalTimeOut);
            if (objDr.Table.Columns["CheckIn"] != null)
                DateTime.TryParse(objDr["CheckIn"].ToString(), out _CheckIn);
           
            if (objDr.Table.Columns["CheckOut"] != null)
                DateTime.TryParse(objDr["CheckOut"].ToString(), out _CheckOut);

            if (objDr.Table.Columns["DayHourNo"] != null)
                double.TryParse(objDr["DayHourNo"].ToString(), out _DayHourNo);

            if (objDr.Table.Columns["IsAbsent"] != null)
                bool.TryParse(objDr["IsAbsent"].ToString(), out _IsAbsent);

            if (objDr.Table.Columns["IsIgnoreDelay"] != null)
                bool.TryParse(objDr["IsIgnoreDelay"].ToString(), out _IsIgnoreDelay);

            if (objDr.Table.Columns["WorkDayManualIgnoreDelay"] != null)
                bool.TryParse(objDr["WorkDayManualIgnoreDelay"].ToString(), out _ManualIgnoreDelay);

            if (objDr.Table.Columns["WorkDayManualIgnoreDelayValue"] != null)
                double.TryParse(objDr["WorkDayManualIgnoreDelayValue"].ToString(), out _ManualIgnoreDelayValue);

            if (objDr.Table.Columns["TotalMinutes"] != null)
                int.TryParse(objDr["TotalMinutes"].ToString(), out _TotalMinutes);

            if (objDr.Table.Columns["FormalTotalMinutes"] != null)
                int.TryParse(objDr["FormalTotalMinutes"].ToString(), out _FormalTotalMinutes);

            if (objDr.Table.Columns["TimeDelay"] != null)
                double.TryParse(objDr["TimeDelay"].ToString(), out _TimeDelay);

            if (objDr.Table.Columns["EarlierOut"] != null)
                double.TryParse(objDr["EarlierOut"].ToString(), out _EarlierOut);

            if (objDr.Table.Columns["OverTime"] != null)
                double.TryParse(objDr["OverTime"].ToString(), out _OverTime);

            if (objDr.Table.Columns["IsVacancy"] != null)
                bool.TryParse(objDr["IsVacancy"].ToString(), out _IsVacancy);

            if (objDr.Table.Columns["IsOverDay"] != null)
                bool.TryParse(objDr["IsOverDay"].ToString(), out _IsOverDay);

            if (objDr.Table.Columns["IsAlterDay"] != null)
                bool.TryParse(objDr["IsAlterDay"].ToString(), out _IsAlterDay);

            if (objDr.Table.Columns["IsMission"] != null)
                bool.TryParse(objDr["IsMission"].ToString(), out _IsMission);

            if (objDr.Table.Columns["ISNonCountedDay"] != null)
                bool.TryParse(objDr["ISNonCountedDay"].ToString(), out _ISNonCountedDay);

            if (objDr.Table.Columns["CommentError"] != null)
                _CommentError = objDr["CommentError"].ToString();

            if (objDr.Table.Columns["IsVacationAccident"] != null)
                bool.TryParse(objDr["IsVacationAccident"].ToString(), out _IsVacationAccident);

            if (objDr.Table.Columns["IsVacationCommon"] != null)
                bool.TryParse(objDr["IsVacationCommon"].ToString(), out _IsVacationCommon);

            if (objDr.Table.Columns["IsVacationSick"] != null)
                bool.TryParse(objDr["IsVacationSick"].ToString(), out _IsVacationSick);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_StatementIDs != null && _StatementIDs != "")
                strSql += " and ApplicantAttendanceStatement in("+_StatementIDs+")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetStatementIDs()
        {
            string StrSql = @"SELECT DISTINCT dbo.HRApplicantWorkerAttendanceStatement.Applicant 
 FROM            dbo.HRApplicantWorkerWorkDay INNER JOIN
                         dbo.HRApplicantWorkerAttendanceStatement ON dbo.HRApplicantWorkerWorkDay.ApplicantAttendanceStatement = dbo.HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID
WHERE        (dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment = " + _AttendanceStatement+")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }

        #endregion
    }
}
