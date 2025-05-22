using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkDayBiz
    {
        #region Private Data
         ApplicantWorkerBiz _ApplicantWorkerBiz;
        AttendanceStatementBiz _AttendanceStatementBiz;
        DateTime _WorkDay;
        

        ApplicantWorkerAttendanceCol _CheckInOutCol;
        ApplicantWorkerAttendanceCol _CheckInCol;
        ApplicantWorkerAttendanceCol _CheckOutCol;
        ApplicantWorkerAttendanceCol _ICheckInCol;//Irregular Checkincol
        ApplicantWorkerAttendanceCol _ICheckOutCol;//Irregular CheckOutCol
        //ApplicantWorkerAttendanceCol _CheckOutCol;

        DateTime _FormalTimeIn;
        DateTime _FormalTimeOut;
        double _DayHourNo;

        ApplicantWorkerAttendanceBiz _CheckInBiz;
        ApplicantWorkerAttendanceBiz _CheckOutBiz;
        AttendanceTimeApplicantBiz _AttendanceTimeBiz; 
        bool _IsAbsent;
        int _TotalMinutes;//Present Total Attendance Minutes
        int _FormalTotalMinutes;//Present Formal Total Attendance Minutes
        double _TimeDelay;//Time Delay in minutes
        double _EarlierOut;//Time Earlier in minutes
        double _OverTime;//overtime in minutes
        bool _IsOverDay;// Work Day in vacation
        bool _Isvacancy;
        bool _IsMission;
        bool _isAlterDay;
        bool _IsNonCountedDay;
        bool _IgnoreDelay;
        string _CommentError;

        bool _WorkDayManualIgnoreDelay;
        double _WorkDayManualIgnoreDelayValue;
        ApplicantWorkDayCol _WorkDayCol;
        int _Index;
        #endregion
        #region Constructors
        public ApplicantWorkDayBiz()
        {
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _AttendanceStatementBiz = new AttendanceStatementBiz();
          
        }
        #endregion
        #region Public Properties
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
        public AttendanceTimeApplicantBiz AttendanceTimeBiz
        {
            set
            {
                _AttendanceTimeBiz = value;
            }
            get
            {
                return _AttendanceTimeBiz;
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
     
        public DateTime WorkDay
        {
            set
            {
                _WorkDay = value;
            }
            get
            {
                return _WorkDay;
            }
        }
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
        public double DayHoursNo
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
        public bool IsAbsent
        {
            internal set
            {
                _IsAbsent = value;
            }
            get
            {
                return _IsAbsent;
            }
        }
        public bool IgnoreDelay
        {
            set
            {
                _IgnoreDelay = value;
            }
            get
            {
                return _IgnoreDelay;
            }
        }
        public bool WorkDayManualIgnoreDelay
        {
            set
            {
                _WorkDayManualIgnoreDelay = value;
            }
            get
            {         
       
                return _WorkDayManualIgnoreDelay;
            }
        }
        public double WorkDayManualIgnoreDelayValue
        {
            set
            {
                _WorkDayManualIgnoreDelayValue = value;
            }
            get
            {

                return _WorkDayManualIgnoreDelayValue;
            }
        }
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
        public double TimeDelay
        {
            internal set
            {
                _TimeDelay = value;
            }
            get
            {
                double dlCount = _TimeDelay;
                //if (dlCount > 0)
                //    dlCount=dlCount;
               // if ( _ApplicantWorkerBiz.DelayLimitApplicantBiz.DelayRuleBiz.ID == 0 && _ApplicantWorkerBiz.DelayLimitApplicantBiz.MaxMin == 0)
                    dlCount = dlCount - _AttendanceStatementBiz.DelayDiscount;


                if (dlCount < 0)
                    dlCount = 0;
                return dlCount;
            }
        }
        public double EarlierOut
        {
            internal set
            {
                _EarlierOut = value;
            }
            get
            {
                double dlCount = SystemBase.SysUtility.Approximate(_EarlierOut,1,SharpVision.SystemBase.ApproximateType.Down);
                if (dlCount > 0)
                    dlCount = dlCount;
                if (dlCount <= _AttendanceStatementBiz.EarlierOutDiscount)
                    dlCount = 0;
                
                return dlCount;

                //return _EarlierOut;
            }
        }
        public double OverTime
        {
            internal set
            {
                _OverTime = value;
            }
            get
            {
                return _OverTime;
            }
        }
        public ApplicantWorkerAttendanceCol CheckInOutCol
        {
            set
            {

                _CheckInOutCol = value;
            }
            get
            {
                if (_CheckInOutCol == null)
                {
                    _CheckInOutCol = new ApplicantWorkerAttendanceCol(true);
                  
                }
                return _CheckInOutCol;
            }
        }
        public ApplicantWorkerAttendanceCol CheckInCol
        {
            set
            {
                _CheckInCol = value;
            }
            get
            {
                if (_CheckInCol == null)
                    return new ApplicantWorkerAttendanceCol(true);
                return _CheckInCol;
            }
        }
        public ApplicantWorkerAttendanceCol CheckOutCol
        {
            set
            {
                _CheckOutCol = value;
            }
            get
            {
                return _CheckOutCol;
            }
        }
        public ApplicantWorkerAttendanceCol ICheckInCol
        {
            set
            {
                _ICheckInCol = value;
            }
            get
            {
                return _ICheckInCol;
            }
        }
        public ApplicantWorkerAttendanceCol ICheckOutCol
        {
            set
            {
                _ICheckOutCol = value;
            }
            get
            {
                return _ICheckOutCol;
            }
        }
        public bool IsVacancy
        {
            set
            {
                _Isvacancy = value;
            }
            get
            {
                return _Isvacancy;
            }
        }
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
        public bool IsAlterDay
        {
            set
            {
                _isAlterDay = value;
            }
            get
            {
                return _isAlterDay;
            }
        }
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
        public bool ISNonCountedDay
        {
            set
            {
                _IsNonCountedDay = value;
            }
            get
            {
                return _IsNonCountedDay;
            }
        }
        public ApplicantWorkDayCol WorkDayCol
        {
            set
            {
                _WorkDayCol = value;
            }
            get
            {
                return _WorkDayCol;
            }
        }
        public int Index
        {
            set
            {
                _Index = value;
            }
            get
            {
                return _Index;
            }
        }
        public string strApplicantName
        {
            get
            {
                return ApplicantWorkerBiz.Name;
            }
        }
        public string strWorkDay
        {
            get
            {
                return WorkDay.ToString("yyyy-MM-dd");
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
        public string strIsAbsent
        {
            get
            {
                string strReturned = "";
                if (IsVacancy == true)
                {
                    strReturned = "اجازة رسمى";
                }
                else
                {
                    if (IsAbsent == true)
                    {
                       
                        {
                            strReturned = "غياب";
                        }
                    }
                    else
                    {
                        strReturned = "";
                    }
                }                
                return strReturned;
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
        public string strCheckIn
        {
            get
            {
                string strCheckInVal = "";
                foreach (ApplicantWorkerAttendanceBiz objBiz in CheckInCol)
                {
                    if (objBiz.AttandanceType == 1)
                    {
                        if (strCheckInVal == "")
                            strCheckInVal = objBiz.AttendanceTime.ToString("hh:mm tt");
                        else
                            strCheckInVal += "," + objBiz.AttendanceTime.ToString("hh:mm tt");
                    }
                }
                return strCheckInVal;
            }
        }
        public string strCheckOut
        {
            get
            {
                string strCheckOutVal = "";
                foreach (ApplicantWorkerAttendanceBiz objBiz in CheckOutCol)
                {
                    if (objBiz.AttandanceType == 0)
                    {
                        if (strCheckOutVal == "")
                            strCheckOutVal = objBiz.AttendanceTime.ToString("hh:mm tt");
                        else
                            strCheckOutVal += "," + objBiz.AttendanceTime.ToString("hh:mm tt");
                    }
                }
                return strCheckOutVal;
            }
        }
        public ApplicantWorkerAttendanceBiz CheckInBiz
        {
            set
            {
                _CheckInBiz = value;
            }
            get
            {
                return _CheckInBiz;
            }
        }
        public ApplicantWorkerAttendanceBiz CheckOutBiz
        {
            set
            {
                _CheckOutBiz = value;
            }
            get
            {
                return _CheckOutBiz;
            }
        }
        public string FisrtCheckInStr
        {
            get
            {
                string Returned = "";
                if (CheckInBiz != null && CheckInBiz.ApplicantAttendanceID != 0)
                {
                    Returned = _CheckInBiz.AttendanceTime.ToString("HH:mm");
                }
                return Returned;
            }
        }
        public string LastCheckOutStr
        {
            get
            {
                string Returned = "";
                if (_CheckOutBiz != null && _CheckOutBiz.ApplicantAttendanceID != 0)
                {
                    Returned = _CheckOutBiz.AttendanceTime.ToString("HH:mm");
                }
                return Returned;
            }
        }
        public string strDay
        {
            get
            {
                string strDayVal = WorkDay.DayOfWeek.ToString();
               
                return strDayVal;
            }
        }
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
        public bool IsVacationAccident // العرضة
        {
            get
            {
                if (IsVacancy == true)
                { 
                        return true;
                    
                }
                return false;
            }
        }
        public bool IsVacationCommon // الاعتيادى
        {
            get
            {
                if (IsVacancy == true)
                {
                
                        return true;
                   
                }
                return false;
            }
        }
        public bool IsVacationSick // مرضى
        {
            get
            {
                if (IsVacancy == true)
                {
                 
                        return false;
                }
                return false;
            }
        }
        #region Flat Data
        WorkDayFlatBiz _FlatBiz;
        public WorkDayFlatBiz FlatBiz
        {
            get { if (_FlatBiz == null)
                {
                    _FlatBiz = new WorkDayFlatBiz()
                    {ApplicantAttendanceStatement=AttendanceStatementBiz.ID,ApplicantID=ApplicantWorkerBiz.ID,CommentError=CommentError,Date=WorkDay,DayHourNo=DayHoursNo,EarlierOut=EarlierOut,FormalTimeIn=FormalTimeIn,FormalTimeOut=FormalTimeOut, CheckIn = CheckInBiz.AttendanceTime, CheckOut = CheckOutBiz.AttendanceTime, FormalTotalMinutes=FormalTotalMinutes,FurloughID=0,IsAbsent=IsAbsent,IsAlterDay=IsAlterDay,IsIgnoreDelay=IgnoreDelay,IsMission=IsMission,ISNonCountedDay=ISNonCountedDay,IsOverDay=IsOverDay,IsVacancy=IsVacancy,IsVacationAccident=IsVacationAccident,IsVacationCommon=IsVacationCommon,IsVacationSick=IsVacationSick,ManualIgnoreDelay=WorkDayManualIgnoreDelay,ManualIgnoreDelayValue=WorkDayManualIgnoreDelayValue,MissionID=0,OverTime=OverTime,TimeDelay=TimeDelay,TotalMinutes =TotalMinutes,VacationID=0 };
                }
                return _FlatBiz;
            }
        }
        #endregion
        #endregion
        #region Private Methods
        bool AdjustCheckInOutCol()
        {

            if (_CheckInCol == null || _CheckOutCol == null)
                return false;
            if (CheckInCol.Count == 0 || CheckOutCol.Count == 0)
                return false;
            if (CheckInCol[0].AttendanceTime < CheckOutCol[0].AttendanceTime)
                return false;
            if (CheckOutCol.Count > 0)
            {
                int intInIndex = 1;
                int intOutIndex = 1;
                while (intOutIndex < CheckOutCol.Count)
                {

                    while (intInIndex < CheckInCol.Count)
                    {
 //if(CheckInCol[intInIndex].AttendanceTime> CheckOutCol[)
                     
                    }
                    intOutIndex++;
                }
 
            }

            return true;
        }
        #endregion
        #region Public Methods
        public void AdjustCheckInOutCol1(DateTime dtFormalTimeIn, DateTime dtFormalTimeOut)
        {

            _ICheckInCol = new ApplicantWorkerAttendanceCol(true);
            _ICheckOutCol = new ApplicantWorkerAttendanceCol(true);
            if (CheckInCol.Count == 0 || CheckOutCol.Count == 0)
            {

                return;
            }
            ApplicantWorkerAttendanceCol objIncol = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkerAttendanceCol objOutCol = new ApplicantWorkerAttendanceCol(true);
            double dblInDif, dblOutDif, dblTempDif;
            dblInDif = 0;
            dblOutDif = 0;
            dblTempDif = 0;
            ApplicantWorkerAttendanceBiz objCheckIn, objCheckOut;
            objCheckIn = CheckInCol[0];

            objCheckOut = CheckOutCol[CheckOutCol.Count - 1];

            foreach (ApplicantWorkerAttendanceBiz objBiz in CheckInCol)
            {
                dblInDif = Math.Abs(objCheckIn.AttendanceTime.Subtract(dtFormalTimeIn).TotalMinutes);
                dblTempDif = Math.Abs(objBiz.AttendanceTime.Subtract(dtFormalTimeIn).TotalMinutes);
                if (dblTempDif < dblInDif )//&& objCheckIn.AttendanceTime < dtFormalTimeIn)
                    objCheckIn = objBiz;

              


            }
          

          //  objCheckIn = CheckOutCol[0];

            objCheckOut = CheckOutCol[CheckOutCol.Count - 1];
            foreach (ApplicantWorkerAttendanceBiz objBiz in CheckOutCol)
            {
                dblInDif = Math.Abs(objCheckOut.AttendanceTime.Subtract(dtFormalTimeOut).TotalMinutes);
                dblTempDif = Math.Abs(objBiz.AttendanceTime.Subtract(dtFormalTimeOut).TotalMinutes);
                if (dblTempDif < dblInDif)// && objCheckIn.AttendanceTime < dtFormalTimeIn)
                    objCheckOut = objBiz;

            


            }


            foreach (ApplicantWorkerAttendanceBiz objBiz in CheckInCol)
            {
               // objIncol.Add(objCheckIn);
                if (objBiz.AttendanceTime >= objCheckIn.AttendanceTime &&
                    objBiz.AttendanceTime <= objCheckOut.AttendanceTime)
                    objIncol.Add(objBiz);
                else
                    ICheckInCol.Add(objBiz);

            }
            foreach (ApplicantWorkerAttendanceBiz objBiz in CheckOutCol)
            {
                if (objBiz.AttendanceTime >= objCheckIn.AttendanceTime &&
                    objBiz.AttendanceTime <= objCheckOut.AttendanceTime)
                    objOutCol.Add(objBiz);
                else
                    ICheckOutCol.Add(objBiz);

            }

            //if(objIncol.Count>0)
            //CheckInCol = objIncol;
            //if(objOutCol.Count >0)
            //CheckOutCol = objOutCol;
            

        }
        public void AdjustCheckInOutCol(DateTime dtFormalTimeIn, DateTime dtFormalTimeOut)
        {
            if (FormalTimeIn.Hour > FormalTimeOut.Hour && FormalTimeIn.Hour - FormalTimeOut.Hour > 11)
            {
                AdjustCheckInOutColForCompleteShift();
                return;
            }
            ApplicantWorkerAttendanceCol objCahangedCol = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkerAttendanceCol objTempCol = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkerAttendanceBiz objAttenceBiz;
            int intTempType = 0;
            bool blInFound = false;

            ApplicantWorkDayBiz objWorkDayBiz = this;
           CheckInOutCol = CheckInOutCol.ReorderCheckCol();
                objTempCol = new ApplicantWorkerAttendanceCol(true);
            
                if (objWorkDayBiz.CheckInOutCol.Count > 0)
                    objTempCol.Add(objWorkDayBiz.CheckInOutCol[0]);
                if (objWorkDayBiz.CheckInOutCol.Count > 1)
                    objTempCol.Add(objWorkDayBiz.CheckInOutCol[objWorkDayBiz.CheckInOutCol.Count - 1]);
                foreach (ApplicantWorkerAttendanceBiz objBiz in objTempCol)
                {
                    if ((Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeIn.Hour) > Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeOut.Hour)) &&
                        objBiz.AttandanceType == 1 && blInFound)
                    {
                        objBiz.AttandanceType = 0;
                        objCahangedCol.Add(objBiz);
                    }
                    if ((Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeIn.Hour) < Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeOut.Hour)) &&
                        objBiz.AttandanceType == 0)
                    {
                        objBiz.AttandanceType = 1;
                        
                        objCahangedCol.Add(objBiz);
                    }
                    if (objBiz.AttandanceType == 1)
                        blInFound = true;
                }
           
                intTempType = 0;

                for (int intIndex = 1; intIndex < objWorkDayBiz.CheckInOutCol.Count - 1; intIndex++)
                {
                    objAttenceBiz = objWorkDayBiz.CheckInOutCol[intIndex];
                    if (objAttenceBiz.AttandanceType != intTempType)
                    {
                        objAttenceBiz.AttandanceType = intTempType;
                        objCahangedCol.Add(objAttenceBiz);
                    }

                    intTempType = intTempType == 0 ? 1 : 0;
                }
                if (objTempCol.Count > 1 &&
                    objTempCol[0].AttandanceType == 0)
                {
                    objTempCol[0].AttandanceType = 1;
                }
                if (objTempCol.Count > 1 &&
                        objTempCol[objTempCol.Count-1].AttandanceType == 1)
                {
                    objTempCol[objTempCol.Count-1].AttandanceType = 0;
                }


            

        }
        public void AdjustCheckInOutColForCompleteShift()
        {
          
            ApplicantWorkerAttendanceCol objCahangedCol = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkerAttendanceCol objTempCol = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkerAttendanceBiz objAttenceBiz;
            int intTempType = 0;
            bool blInFound = false;

            ApplicantWorkDayBiz objWorkDayBiz = this;
            CheckInOutCol = CheckInOutCol.ReorderCheckCol();
            objTempCol = new ApplicantWorkerAttendanceCol(true);

            if (objWorkDayBiz.CheckInOutCol.Count > 0)
                objTempCol.Add(objWorkDayBiz.CheckInOutCol[0]);
            if (objWorkDayBiz.CheckInOutCol.Count > 1)
                objTempCol.Add(objWorkDayBiz.CheckInOutCol[objWorkDayBiz.CheckInOutCol.Count - 1]);
            foreach (ApplicantWorkerAttendanceBiz objBiz in objTempCol)
            {
                if ((Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeIn.Hour) > Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeOut.Hour)) &&
                    objBiz.AttandanceType == 1 && blInFound)
                {
                    objBiz.AttandanceType = 0;
                    objCahangedCol.Add(objBiz);
                }
                if ((Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeIn.Hour) < Math.Abs(objBiz.AttendanceTime.Hour - objWorkDayBiz.FormalTimeOut.Hour)) &&
                    objBiz.AttandanceType == 0)
                {
                    objBiz.AttandanceType = 1;

                    objCahangedCol.Add(objBiz);
                }
                if (objBiz.AttandanceType == 1)
                    blInFound = true;
            }

            intTempType = 0;

            for (int intIndex = 1; intIndex < objWorkDayBiz.CheckInOutCol.Count - 1; intIndex++)
            {
                objAttenceBiz = objWorkDayBiz.CheckInOutCol[intIndex];
                if (objAttenceBiz.AttandanceType != intTempType)
                {
                    objAttenceBiz.AttandanceType = intTempType;
                    objCahangedCol.Add(objAttenceBiz);
                }

                intTempType = intTempType == 0 ? 1 : 0;
            }
            if (objTempCol.Count > 1 &&
                objTempCol[0].AttandanceType == 0)
            {
                objTempCol[0].AttandanceType = 1;
            }
            if (objTempCol.Count > 1 &&
                    objTempCol[objTempCol.Count - 1].AttandanceType == 1)
            {
                objTempCol[objTempCol.Count - 1].AttandanceType = 0;
            }




        }
        #endregion
    }
}
