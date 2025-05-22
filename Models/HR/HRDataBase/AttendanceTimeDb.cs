using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class AttendanceTimeDb
    {
        /// <summary>
        /// attendance periority 
        /// 1 for applicant presents the heighest periority
        /// 2 for subsector 
        /// 3 for sector 
        /// 4 for default
        /// </summary>
        #region Private Data
        protected int _ID;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected DateTime _TimeIn;
        protected DateTime _TimeOut;
        protected bool _EndDateStatus;
        protected int _WeekEnd;
        protected int _WeekEndCount;
        protected int _WorkerID;
        protected int _SectorID;
        protected int _SubSectorID;
        
        protected int _Periority;
        protected double _WorkHours;
        protected DataTable _DayTable;
        protected bool _IsLimited;
        protected DateTime _MaxLimit;
        protected DateTime _MinLimit;
       
        #region Private Data for Search

        #endregion
        #endregion
        #region Constructors
        public AttendanceTimeDb()
        {
        }
        public AttendanceTimeDb(DataRow objDr)
        {
            Setdata(objDr);
        }
        #endregion
        #region Public Properties
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
        public bool EndDateStatus
        {
            set
            {
                _EndDateStatus = value;
            }
            get
            {
                return _EndDateStatus;
            }
        }
        public int WeekEnd
        {
            set
            {
                _WeekEnd = value;
            }
            get
            {
                return _WeekEnd;
            }
        }
        public int Periority
        {
            set
            {
                _Periority = value;
            }
            get
            {
                return _Periority;
            }
        }
        public double WorkHours
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
        public int WorkerID
        {
            set
            {
                _WorkerID = value;
            }
        
        }
        public int SectorID
        {
            set
            {
                _SectorID = value;
            }
        }
        public int SubSectorID
        {
            set
            {
                _SubSectorID = value;
            }
        }
        public bool IsLimited
        {
            set
            {
                _IsLimited = value;
            }
            get
            {
                return _IsLimited;
            }
        }
        public DateTime MaxLimit
        {
            set
            {
                _MaxLimit = value;
            }
            get
            {
                return _MaxLimit;
            }
        }
        public DateTime MinLimit
        {
            set
            {
                _MinLimit = value;
            }
            get
            {
                return _MinLimit;
            }
        }
        public DataTable DayTable
        {
            set
            {
                _DayTable = value;
            }
        }
        
        public string AddStr
        {
            get
            {
                double dblAttendanceTimeStartDate = _StartDate.ToOADate() - 2;
                double dblAttendanceTimeEndDate = _EndDate.ToOADate() - 2;
                string strAttendanceTimeEndDate = "";

                double intAttendanceTimeStartDate = dblAttendanceTimeStartDate;
                double intAttendanceTimeEndDate = dblAttendanceTimeEndDate;
                //if (intAttendanceTimeStartDate > dblAttendanceTimeStartDate)
                //    intAttendanceTimeStartDate--;

                //if (intAttendanceTimeEndDate <= dblAttendanceTimeEndDate)
                //    intAttendanceTimeEndDate++;

                if (_EndDateStatus == true)
                {
                    strAttendanceTimeEndDate = intAttendanceTimeEndDate.ToString();
                }
                else
                    strAttendanceTimeEndDate = "Null";

                double dblAttendanceTimeIn = _TimeIn.ToOADate() - 2;
                _TimeOut = _TimeOut.AddSeconds(1);
                double dblAttendanceTimeOut = _TimeOut.ToOADate() - 2;

                string Returned = " INSERT INTO HRAttendanceTime"+
                                  " (AttendanceTimeStartDate, AttendanceTimeEndDate, AttendanceTimeIn," +
                                  "  AttendanceTimeOut, AttendancePeriority,AttendanceTimeWeekEnd,AttendanceWorkHours, " +
                                  " UsrIns, TimIns)"+
                                  " VALUES ("+
                                  " " + intAttendanceTimeStartDate + "," + strAttendanceTimeEndDate + "," + dblAttendanceTimeIn + "," +
                                  " " + dblAttendanceTimeOut + "," + _Periority + "," + _WeekEnd + ","+ _WorkHours +"," +                                  
                                  " "+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;                 
            }
        }
        public string EditStr
        {
            get
            {
                double dblAttendanceTimeStartDate = _StartDate.ToOADate() - 2;
                double dblAttendanceTimeEndDate = _EndDate.ToOADate() - 2;
                string strAttendanceTimeEndDate = "";

                double intAttendanceTimeStartDate = dblAttendanceTimeStartDate;
                double intAttendanceTimeEndDate = dblAttendanceTimeEndDate;
                //if (intAttendanceTimeStartDate > dblAttendanceTimeStartDate)
                //    intAttendanceTimeStartDate--;

                //if (intAttendanceTimeEndDate <= dblAttendanceTimeEndDate)
                //    intAttendanceTimeEndDate++;

                if (_EndDateStatus == true)
                {
                    strAttendanceTimeEndDate = intAttendanceTimeEndDate.ToString();
                }
                else
                    strAttendanceTimeEndDate = "Null";


                double dblAttendanceTimeIn = _TimeIn.ToOADate() - 2;
                _TimeOut = _TimeOut.AddSeconds(1);
                double dblAttendanceTimeOut = _TimeOut.ToOADate() - 2;

                string Returned = " UPDATE    HRAttendanceTime "+
                                  " SET"+
                                  "  AttendanceTimeStartDate =" + dblAttendanceTimeStartDate + "" +
                                  ", AttendanceTimeEndDate =" + strAttendanceTimeEndDate + "" +
                                  ", AttendanceTimeIn =" + dblAttendanceTimeIn + "" +
                                  ", AttendanceTimeOut =" + dblAttendanceTimeOut + "" +
                                  ", AttendancePeriority =" + _Periority +"" +
                                  ", AttendanceTimeWeekEnd =" + _WeekEnd + "" +
                                  ", AttendanceWorkHours = "+ _WorkHours +" " +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (AttendanceTimeID = " + _ID +")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update HRAttendanceTime  set Dis = GetDate() WHERE     (AttendanceTimeID = " + _ID + ") ";
                return Returned;
            }
        }
        public virtual string StrSearch
        {
            get
            {
                return "";
            }
        }
        public static string SearchStr
        {
            get
            {
                
                string strAttendance = " SELECT dbo.HRAttendanceStatementAttendanceTime.AttendanceTime, " +
                                               " MIN(dbo.HRAttendanceStatementAttendanceTime.DateFrom) AS MinLimit, " +
                                               " MAX(dbo.HRAttendanceStatementAttendanceTime.DateTo) AS MaxLimit " +
                                               " FROM         dbo.HRAttendanceStatementAttendanceTime "+
                                               " GROUP BY dbo.HRAttendanceStatementAttendanceTime.AttendanceTime";

                string Returned = " SELECT  HRAttendanceTime.AttendanceTimeID,HRAttendanceTime.AttendanceTimeStartDate, HRAttendanceTime.AttendanceTimeEndDate," +
                                  " HRAttendanceTime.AttendanceTimeIn, HRAttendanceTime.AttendanceTimeOut, HRAttendanceTime.AttendancePeriority,"+
                                  " HRAttendanceTime.AttendanceTimeWeekEnd,HRAttendanceTime.AttendanceWorkHours" +
                                  " ,Case When AttendanceTimeEndDate is null then 1 else 0 end as Endless" +
                                  ",case when AttendanceTimeEndDate is null then 0 else " +
                                  " CONVERT(int, AttendanceTimeEndDate - AttendanceTimeStartDate) end As PeriodLength " +
                                  " ,AttendanceTimeApplicantTable.*," +
                                  " AttendanceTimeSectorTable.* " +
                                  ",AttendanceTable.MinLimit,AttendanceTable.MaxLimit " +
                                  ",CASE WHEN AttendanceTimeIn > AttendanceTimeOut THEN DATEADD(hh, - 4, AttendanceTimeOut) "+
                                  " ELSE AttendanceTimeOut END AS FakeTimeOUT "+
                                  ""+
                                  " FROM         HRAttendanceTime " +
                                  " Left Outer Join (" + new AttendanceTimeApplicantDb() { IgnoreApplicant=true}.SearchStr + ") as AttendanceTimeApplicantTable On HRAttendanceTime.AttendanceTimeID = AttendanceTimeApplicantTable.AttendanceTimeID " +
                                  //" Left Outer Join (" + AttendanceTimeSubSectorDb.SearchStr + ") as AttendanceTimeSubSectorTable On HRAttendanceTime.AttendanceTimeID = AttendanceTimeSubSectorTable.AttendanceTimeID " +
                                  " Left Outer Join (" + AttendanceTimeSectorDb.SearchStr + ") as AttendanceTimeSectorTable On HRAttendanceTime.AttendanceTimeID = AttendanceTimeSectorTable.AttendanceTimeID "+
                                  " left outer join (" + strAttendance + ") as AttendanceTable on HRAttendanceTime.AttendanceTimeID = AttendanceTable.AttendanceTime  ";
                                  //" Left Outer Join (" + AttendanceTimeDefaultDb.SearchStr + ") as AttendanceTimeDefaultTable On HRAttendanceTime.AttendanceTimeID = AttendanceTimeDefaultTable=AttendanceTimeID ";
                                  
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        protected virtual void Setdata(DataRow objDr)
        {
            _ID = int.Parse(objDr["AttendanceTimeID"].ToString());
            _StartDate = DateTime.Parse(objDr["AttendanceTimeStartDate"].ToString());
            if (objDr["AttendanceTimeEndDate"].ToString() != "")
            {
                _EndDateStatus = true;
                _EndDate = DateTime.Parse(objDr["AttendanceTimeEndDate"].ToString());
                //_EndDate = _EndDate.AddDays(-1);
            }
            else
            {
                _EndDateStatus = false;
            }
            _TimeIn = DateTime.Parse(objDr["AttendanceTimeIn"].ToString());
            _TimeOut = DateTime.Parse(objDr["AttendanceTimeOut"].ToString());

            if (objDr["AttendanceTimeWeekEnd"].ToString() != "")
                _WeekEnd = int.Parse(objDr["AttendanceTimeWeekEnd"].ToString());
            else
                _WeekEnd = 0;
            //if (objDr["AttendanceTimeWeekEndCount"].ToString() != "")
            //    _WeekEndCount = int.Parse(objDr["AttendanceTimeWeekEndCount"].ToString());
            _Periority = int.Parse(objDr["AttendancePeriority"].ToString());
            _WorkHours = double.Parse(objDr["AttendanceWorkHours"].ToString());
            if (objDr["MinLimit"].ToString() != "")
            {
                _IsLimited = true;
                _MaxLimit = DateTime.Parse(objDr["MaxLimit"].ToString());
                _MinLimit = DateTime.Parse(objDr["MinLimit"].ToString());
            }
        }
        void CopyIntoTable(DataTable dtSource, ref DataTable dtDist)
        {
            DataRow objDr;
            int intClmIndex = 0;
            foreach (DataRow objTempDr in dtSource.Rows)
            {
                objDr = dtDist.NewRow();
                intClmIndex = 0;
                foreach (DataColumn dcTemp in dtDist.Columns)
                {
                    objDr[intClmIndex] = objTempDr[intClmIndex];
                    intClmIndex++;
                }
                dtDist.Rows.Add(objDr);
            }
        }
        void JoinDay()
        {
            string[] arrStr;
            if (_DayTable == null || _DayTable.Rows.Count == 0)
            {
                arrStr = new string[1];
            }
            else
            {
                arrStr = new string[_DayTable.Rows.Count + 1];
            }

            arrStr[0] = "delete from HRAttendanceTimeDay where AttendanceTime = " + _ID + "";

            if (_DayTable == null || _DayTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                AttendanceTimeDayDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _DayTable.Rows)
                {
                    objDb = new AttendanceTimeDayDb(objDr);
                    objDb.AttendanceTime = ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinDay();
        }
        public virtual void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            JoinDay();
        }
        public virtual void Delete()
        {
            //JoinDay();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public virtual DataTable Search()
        {
            double dblEndDate = _EndDate.ToOADate() - 2;
            dblEndDate = SysUtility.Approximate(dblEndDate, 1, ApproximateType.Up);

            int intEndDate = (int)dblEndDate;
            
            double dblStartDate = _StartDate.ToOADate() - 2;
            int intStartDate = (int)SysUtility.Approximate(dblStartDate, 1, ApproximateType.Down);
            //if (intStartDate > dblStartDate)
            //    intEndDate--;
            string strDateCondition = " ((AttendanceTimeStartDate>=" + intStartDate + " and AttendanceTimeStartDate<="+ intEndDate +") "+
                " or (AttendanceTimeEndDate>=" + intStartDate + " and AttendanceTimeEndDate<="+ intEndDate +") "+
                " or (AttendanceTimeStartDate<=" + intStartDate + " and AttendanceTimeEndDate>=" + intStartDate + ") " +
                " or (AttendanceTimeStartDate<=" + intEndDate + " and AttendanceTimeEndDate>=" + intEndDate + ") " +
                " or (AttendanceTimeStartDate<=" + intStartDate + " and  AttendanceTimeEndDate is null)) ";
            
            string strSql = SearchStr + " Where (Dis is null ) and "+ strDateCondition +" and AttendancePeriority=4 ";

            if (_WorkerID != 0 || _SectorID != 0 || _SubSectorID != 0)
            {
                if (_WorkerID != 0)
                    strSql += " or (  (Dis is null ) and " + strDateCondition + " and (AttendancePeriority=1)" +
                        " and AttendanceTimeApplicantTable.AttendanceApplicant =" + _WorkerID + ")";
                if (_SectorID != 0)
                    strSql += " or ( (Dis is null ) and " + strDateCondition + " and (AttendancePeriority=3) " +
                        " and AttendanceTimeSectorTable.SectorID =" + _SectorID + ") ";
         
            }
            strSql += " order by AttendancePeriority,HRAttendanceTime.AttendanceTimeStartDate desc,Endless,PeriodLength,HRAttendanceTime.AttendanceTimeID desc";
          

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
           
        }
        
        #endregion
    }
}
