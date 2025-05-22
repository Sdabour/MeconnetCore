using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.COMMON.COMMONBusiness;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class WorkDayFlatBiz
    {

        #region Constructor
        public WorkDayFlatBiz()
        {
            _WorkDayFlatDb = new WorkDayFlatDb();
        }
        public WorkDayFlatBiz(DataRow objDr)
        {
            _WorkDayFlatDb = new WorkDayFlatDb(objDr);
        }

        #endregion
        #region Private Data
        WorkDayFlatDb _WorkDayFlatDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _WorkDayFlatDb.ID = value;
            }
            get
            {
                return _WorkDayFlatDb.ID;
            }
        }
        public int ApplicantID
        {
            set
            {
                _WorkDayFlatDb.ApplicantID = value;
            }
            get
            {
                return _WorkDayFlatDb.ApplicantID;
            }
        }
        public int ApplicantAttendanceStatement
        {
            set
            {
                _WorkDayFlatDb.ApplicantAttendanceStatement = value;
            }
            get
            {
                return _WorkDayFlatDb.ApplicantAttendanceStatement;
            }
        }
        public int FurloughID
        {
            set
            {
                _WorkDayFlatDb.FurloughID = value;
            }
            get
            {
                return _WorkDayFlatDb.FurloughID;
            }
        }
        public int VacationID
        {
            set
            {
                _WorkDayFlatDb.VacationID = value;
            }
            get
            {
                return _WorkDayFlatDb.VacationID;
            }
        }
        public int MissionID
        {
            set
            {
                _WorkDayFlatDb.MissionID = value;
            }
            get
            {
                return _WorkDayFlatDb.MissionID;
            }
        }
        public DateTime Date
        {
            set
            {
                _WorkDayFlatDb.Date = value;
            }
            get
            {
                return _WorkDayFlatDb.Date;
            }
        }
        public DateTime FormalTimeIn
        {
            set
            {
                _WorkDayFlatDb.FormalTimeIn = value;
            }
            get
            {
                return _WorkDayFlatDb.FormalTimeIn;
            }
        }
        public DateTime FormalTimeOut
        {
            set
            {
                _WorkDayFlatDb.FormalTimeOut = value;
            }
            get
            {
                return _WorkDayFlatDb.FormalTimeOut;
            }
        }
        public DateTime CheckIn
        {
            set
            {
                _WorkDayFlatDb.CheckIn = value;
            }
            get
            {
                return _WorkDayFlatDb.CheckIn;
            }
        }
      
        public DateTime CheckOut
        {
            set
            {
                _WorkDayFlatDb.CheckOut = value;
            }
            get
            {
                return _WorkDayFlatDb.CheckOut;
            }
        }
        public double DayHourNo
        {
            set
            {
                _WorkDayFlatDb.DayHourNo = value;
            }
            get
            {
                return _WorkDayFlatDb.DayHourNo;
            }
        }
        public bool IsAbsent
        {
            set
            {
                _WorkDayFlatDb.IsAbsent = value;
            }
            get
            {
                return _WorkDayFlatDb.IsAbsent;
            }
        }
        public bool IsIgnoreDelay
        {
            set
            {
                _WorkDayFlatDb.IsIgnoreDelay = value;
            }
            get
            {
                return _WorkDayFlatDb.IsIgnoreDelay;
            }
        }
        public bool ManualIgnoreDelay
        {
            set
            {
                _WorkDayFlatDb.ManualIgnoreDelay = value;
            }
            get
            {
                return _WorkDayFlatDb.ManualIgnoreDelay;
            }
        }
        public double ManualIgnoreDelayValue
        {
            set
            {
                _WorkDayFlatDb.ManualIgnoreDelayValue = value;
            }
            get
            {
                return _WorkDayFlatDb.ManualIgnoreDelayValue;
            }
        }
        public int TotalMinutes
        {
            set
            {
                _WorkDayFlatDb.TotalMinutes = value;
            }
            get
            {
                return _WorkDayFlatDb.TotalMinutes;
            }
        }
        public int FormalTotalMinutes
        {
            set
            {
                _WorkDayFlatDb.FormalTotalMinutes = value;
            }
            get
            {
                return _WorkDayFlatDb.FormalTotalMinutes;
            }
        }
        public double TimeDelay
        {
            set
            {
                _WorkDayFlatDb.TimeDelay = value;
            }
            get
            {
                return _WorkDayFlatDb.TimeDelay;
            }
        }
        public double EarlierOut
        {
            set
            {
                _WorkDayFlatDb.EarlierOut = value;
            }
            get
            {
                return _WorkDayFlatDb.EarlierOut;
            }
        }
        public double OverTime
        {
            set
            {
                _WorkDayFlatDb.OverTime = value;
            }
            get
            {
                return _WorkDayFlatDb.OverTime;
            }
        }
        public bool IsVacancy
        {
            set
            {
                _WorkDayFlatDb.IsVacancy = value;
            }
            get
            {
                return _WorkDayFlatDb.IsVacancy;
            }
        }
        public bool IsOverDay
        {
            set
            {
                _WorkDayFlatDb.IsOverDay = value;
            }
            get
            {
                return _WorkDayFlatDb.IsOverDay;
            }
        }
        public bool IsAlterDay
        {
            set
            {
                _WorkDayFlatDb.IsAlterDay = value;
            }
            get
            {
                return _WorkDayFlatDb.IsAlterDay;
            }
        }
        public bool IsMission
        {
            set
            {
                _WorkDayFlatDb.IsMission = value;
            }
            get
            {
                return _WorkDayFlatDb.IsMission;
            }
        }
        public bool ISNonCountedDay
        {
            set
            {
                _WorkDayFlatDb.ISNonCountedDay = value;
            }
            get
            {
                return _WorkDayFlatDb.ISNonCountedDay;
            }
        }
        public string CommentError
        {
            set
            {
                _WorkDayFlatDb.CommentError = value;
            }
            get
            {
                return _WorkDayFlatDb.CommentError;
            }
        }
        public bool IsVacationAccident
        {
            set
            {
                _WorkDayFlatDb.IsVacationAccident = value;
            }
            get
            {
                return _WorkDayFlatDb.IsVacationAccident;
            }
        }
        public bool IsVacationCommon
        {
            set
            {
                _WorkDayFlatDb.IsVacationCommon = value;
            }
            get
            {
                return _WorkDayFlatDb.IsVacationCommon;
            }
        }
        public bool IsVacationSick
        {
            set
            {
                _WorkDayFlatDb.IsVacationSick = value;
            }
            get
            {
                return _WorkDayFlatDb.IsVacationSick;
            }
        }
        public string strWorkDay
        {
            get
            {
                return Date.ToString("yyyy-MM-dd");
            }
        }
        public string strFormalTimeIn
        {
            get
            {
                return FormalTimeIn.ToString("hh:mm tt");
            }
        }
        public string strFormalTimeOut
        {
            get
            {
                return FormalTimeOut.ToString("hh:mm tt");
            }
        }
        
        public string strIsVacancy
        {
            get
            {
                //if (VacationBiz.VacationID != 0)
                //{
                if (IsVacancy == true)
                    return "اجازة رسمى";
                else
                    return "";
                //}
                //else
                //    return "";
            }
        }

        public string DisplayStr2
        {
            get
            {
                string Returned = "";

                if (IsVacationAccident)
                    Returned += "";
                else if (IsVacationCommon)
                    Returned += "";
                else if (IsVacationSick)
                    Returned += "";
                else if (IsMission)
                    Returned += "";
                else if (IsVacancy)
                    Returned = "";
                else
                {
                    string strCheckInOut = " In: " + CheckIn.ToString("HH:mm");
                    if (CheckOut > Date)
                        strCheckInOut += " Out: " + CheckOut.ToString("HH:mm");
                    Returned += strCheckInOut + "\n\r";
                    //if (FurloughID > 0)
                    //    Returned += "اذن";
                    //if (!IsIgnoreDelay)
                    //{
                    //    if (TimeDelay > 0)
                    //    {
                    //        if (Returned != "")
                    //            Returned += "\n\r";
                    //        Returned += " تاخير" + ":" + PeriodBiz.GetTimeString(TimeDelay);
                       // }
                    }
                   

               
                return Returned;
            }
        }
        public string DisplayStr1
        {
            get
            {
                string Returned = "";

                if (IsVacationAccident)
                    Returned += "عارضة";
                else if (IsVacationCommon)
                    Returned += "اعتيادى";
                else if (IsVacationSick)
                    Returned += "مرضى";
                else if (IsMission)
                    Returned += "مأمورية";
                else if (IsVacancy)
                    Returned = "عطله";
                else
                {
                    string strCheckInOut = " In : " + CheckIn.ToString("HH:mm");
                    if (CheckOut > Date)
                        strCheckInOut += " Out : " + CheckOut.ToString("HH:mm");
                    Returned += strCheckInOut + "\n\r";
                    if (FurloughID > 0)
                        Returned += "اذن";
                    if (!IsIgnoreDelay)
                    {
                        if (TimeDelay > 0)
                        {
                            if (Returned != "")
                                Returned += "\n\r";
                            Returned += " تاخير" + ":" + PeriodBiz.GetTimeString(TimeDelay);
                        }
                    }
                    else
                    {
                        if (Returned != "")
                            Returned += "\n\r";
                        Returned += "تجاهل التأخير";

                    }
                    if (EarlierOut > 0)
                    {
                        if (Returned != "")
                            Returned += "\n\r";
                        Returned += "خروج مبكر";
                        Returned += PeriodBiz.GetTimeString(EarlierOut);
                    }
                    if (OverTime > 0)
                    {
                        if (Returned != "")
                            Returned += "\n\r";
                        Returned += " اضافى ";
                        Returned += PeriodBiz.GetTimeString(OverTime);
                    }

                }
                return Returned;
            }
        }
        public string DisplayStr
        {
            get 
            {
                string Returned = "";

                if (IsVacationAccident)
                    Returned += "عارضة";
                else if (IsVacationCommon)
                    Returned += "اعتيادى";
                else if (IsVacationSick)
                    Returned += "مرضى";
                else if (IsMission)
                    Returned += "مأمورية";
                else if (IsVacancy)
                    Returned = "عطله";
                else if (IsAbsent)
                    Returned = "غياب";

                else
                {
                    string strCheckInOut = " In : " + CheckIn.ToString("HH:mm");
                    if (CheckOut > Date)
                        strCheckInOut += " Out : " + CheckOut.ToString("HH:mm");
                    Returned += strCheckInOut + "\n\r";
                    if (FurloughID > 0)
                        Returned += "اذن";
                    //if(!IsIgnoreDelay)
                    //{
                    //    if (TimeDelay > 0)
                    //    {
                    //        if (Returned != "")
                    //            Returned += "\n\r";
                    //       Returned+= " تاخير" + ":" + PeriodBiz.GetTimeString(TimeDelay);
                    //    }
                    //}
                    //else
                    //{
                    //    if (Returned != "")
                    //        Returned += "\n\r";
                    //    Returned+= "تجاهل التأخير";

                    //}
                    //if (EarlierOut>0)
                    //{
                    //    if (Returned != "")
                    //        Returned += "\n\r";
                    //    Returned+="خروج مبكر";
                    //    Returned += PeriodBiz.GetTimeString(EarlierOut);
                    //}
                    //if (OverTime > 0)
                    //{
                    //    if (Returned != "")
                    //        Returned += "\n\r";
                    //    Returned +=" اضافى ";
                    //    Returned += PeriodBiz.GetTimeString(OverTime);
                    //}

                }
                return Returned;
            }
        }
         
        
       
        public string strDay
        {
            get
            {
                string strDayVal = Date.DayOfWeek.ToString();

                return strDayVal;
            }
        }
     
    
        public static Hashtable GetAttendanceStatementHash(int intAttendanceStatement)
        {
           
                DataTable dtTemp = new WorkDayFlatDb() { AttendanceStatement = intAttendanceStatement }.GetStatementIDs();
            Hashtable Returned = new Hashtable();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (Returned[objDr["Applicant"].ToString()] == null)
                    Returned.Add(objDr["Applicant"].ToString(), objDr["Applicant"].ToString());

            }
            return Returned;
             
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _WorkDayFlatDb.Add();
        }
        public void Edit()
        {
            _WorkDayFlatDb.Edit();
        }
        public void Delete()
        {
            _WorkDayFlatDb.Delete();
        }
        #endregion
    }
}
