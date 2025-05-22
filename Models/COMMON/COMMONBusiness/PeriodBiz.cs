using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
   
    public enum Period
    {
        Year=0,
        month=1,
        Week=2,
        Day=3,
        Hour=4,
        Minute = 5
    }
    public enum VacancyDeal
    {
        Ignore,
        Before,
        After
    }
    public enum Days
    {
        
        Notdefined = 0,
        Saturday = 1,
        Sunday = 2,
        Monday = 3,
        Tuesday = 4,
        Wednesday = 5,
        Thursday = 6,
        Friday = 7
    }
   public class PeriodBiz
   {
       #region Private Data
       double _DayNo;
       double _WeekNo;
       double _MonthNo;
       double _YearNo;
       double _HourNo;
       double _MinuteNo;
       double _DayHourNo = 8;
       double _WeekDayNo = 6;
       Period _Period;
       #endregion
       #region Constructors
       public PeriodBiz(Period objPeriod)
       {
           SetPeriod(objPeriod,1);
           _Period = objPeriod;
       }
       public PeriodBiz(Period objPeriod,double dblAmount)
       {
           SetPeriod(objPeriod,dblAmount);
           _Period = objPeriod;
       }
       public PeriodBiz(Period objPeriod, double dblAmount,
           double dblWeekDayNo,double dblDayHourNo)
       {
           if(dblWeekDayNo != 0)
           _WeekDayNo = dblWeekDayNo;
           if(dblDayHourNo!= 0)
           _DayHourNo = dblDayHourNo;
           SetPeriod(objPeriod, dblAmount);
           _Period = objPeriod;
       }
        #endregion
       #region Public Properties
       public double DayNo
       {
           get
           {
               return _DayNo;
           }
       }
       public double WeekNo
       {
           get
           {
               return _WeekNo;
           }
       }
       public double MonthNo
       {
           get
           {
               return _MonthNo;
           }
       }
       public double MinuteNo
       {
           get
           {
               return _MinuteNo;
           }
       }
       public double YearNo
       {
           get
           {
               return _YearNo;
           }
       }
       public double HourNo
       {
           get
           {
               return _HourNo;
           }
       }

       //double _DayHourNo = 8;
        #endregion
       #region Private Methods
       void SetPeriod(Period objPeriod,double intAmount)
       {
           if (objPeriod == Period.month)
           {
               _DayNo = intAmount * 30;
               _HourNo = _DayNo * _DayHourNo;
               _MinuteNo = _HourNo * 60;
               _MonthNo = intAmount ;
               _WeekNo = intAmount * 4;
               _YearNo = intAmount  / 12;

           }
           else if (objPeriod == Period.Week)
           {
               _DayNo = intAmount * _WeekDayNo;
               _HourNo = _DayNo * _DayHourNo;
               _MinuteNo = _HourNo * 60;
               _MonthNo = intAmount  / 4;
               _WeekNo = intAmount ;
               _YearNo = intAmount * 7 / (365);

           }
           else if (objPeriod == Period.Year)
           {
               _DayNo = intAmount * 365;
               _HourNo = _DayNo * _DayHourNo;
               _MinuteNo = _HourNo * 60;
               _MonthNo = intAmount * 12;
               _WeekNo = intAmount * 365 / 7;
               _YearNo = intAmount ;

           }
           else if (objPeriod == Period.Day)
           {
               _DayNo = intAmount;
               _HourNo = _DayNo * _DayHourNo;
               _MinuteNo = _HourNo * 60;
               _MonthNo = _DayNo/30;
               _WeekNo = _DayNo / _WeekDayNo;
               _YearNo = _DayNo/365;

           }
           else if (objPeriod == Period.Hour)
           {
               _HourNo = intAmount;
               _DayNo = _HourNo/_DayHourNo;
               
               _MinuteNo = _HourNo * 60;
               _MonthNo = _DayNo / 30;
               _WeekNo = _DayNo / _WeekDayNo;
               _YearNo = _DayNo / 365;

           }
           else if (objPeriod == Period.Minute)
           {
               _MinuteNo = intAmount;
               _HourNo = _MinuteNo/60;
               _DayNo = _HourNo / _DayHourNo;

              
               _MonthNo = _DayNo / 30;
               _WeekNo = _DayNo / _WeekDayNo;
               _YearNo = _DayNo / 365;

           }
       }
       #endregion
       #region Public Methods
       public static DateTime GetDate(PeriodBiz objPeriodBiz,DateTime dtStart,VacancyDeal objDeal)
       {
           DateTime Returned = dtStart;
           if (objPeriodBiz._Period == Period.month)
               Returned = VacancyBiz.VacancyCol.CheckVacancy(dtStart.AddMonths((int)objPeriodBiz.MonthNo),objDeal);
           else if (objPeriodBiz._Period == Period.Year)
               Returned = VacancyBiz.VacancyCol.CheckVacancy(dtStart.AddYears((int)objPeriodBiz.YearNo), objDeal);
           return Returned;
 
       }
       public static double GetCompoundProfit(double dblTotalValue, int intNo,PeriodBiz objInstallmentPeriod, double dblPerc, PeriodBiz objProfitPeriod)
       {
           double Returned =0;

           for (int intIndex = 1; intIndex <= intNo; intIndex++)
           {
               Returned = Returned +
                   ((intIndex/intNo) * objInstallmentPeriod.GetConvertRate(objProfitPeriod) * (dblPerc /100) * dblTotalValue);
               
           }
           return Returned;
 
       }

       public static double GetSimpleProfit(double dblTotalValue, double intNo, PeriodBiz objInstallmentPeriod, double dblPerc, PeriodBiz objProfitPeriod)
       {
           double Returned = 0;

           Returned = intNo * objInstallmentPeriod.GetConvertRate(objProfitPeriod) * (dblPerc/100) * dblTotalValue;
           return Returned;

       }
       #region Old GetSimplProfit
       public static double GetSimpleProfit1(double dblTotalValue, int intNo, 
           PeriodBiz objInstallmentPeriod, double dblPerc, PeriodBiz objProfitPeriod)
       {
           double Returned = 0;

           Returned = intNo * objInstallmentPeriod.GetConvertRate(objProfitPeriod) * (dblPerc / 100) * dblTotalValue;
           return Returned;

       }
       #endregion
       public double GetConvertRate(PeriodBiz objPeriodBiz)
       {
           if (objPeriodBiz._Period == Period.Year)
               return YearNo;
           else if (objPeriodBiz._Period == Period.month)
               return MonthNo;
           else
               return WeekNo;
       }
       public static Days GetDayOfWekkDays(DayOfWeek objDay)
       {
           Days Returned = Days.Notdefined;
           switch (objDay)
           {
               case DayOfWeek.Friday: Returned = Days.Friday;
                   break;
               case DayOfWeek.Monday: Returned = Days.Monday;
                   break;
               case DayOfWeek.Saturday: Returned = Days.Saturday;
                   break;
               case DayOfWeek.Sunday: Returned = Days.Sunday;
                   break;
               case DayOfWeek.Thursday: Returned = Days.Thursday;
                   break;
               case DayOfWeek.Tuesday: Returned = Days.Tuesday;
                   break;
               case DayOfWeek.Wednesday: Returned = Days.Wednesday;
                   break;
               default: Returned = Days.Notdefined;
                   break;
           }
                   return Returned;

       }
       public static string GetTimeString(double dblMinutes)
       {
           string Returned = "";
            string strMinutes="00",strHours="00";
           double dblMin = 0, dblHr = 0;
           dblMin = dblMinutes % 60;
           strMinutes = ((int)dblMin).ToString();
           if (dblMinutes > dblMin)
           {
               int intHours = (int)(dblMinutes - dblMin);
               strHours = (intHours/60).ToString();
           }
           if (strMinutes.Length == 1)
           {
               strMinutes = "0" + strMinutes;
           }
           if (strHours.Length == 1)
               strHours = "0" + strHours;
           Returned = strHours + ":" + strMinutes;
           return Returned;
       }
       public static double GetMinutes(string strTemp)
       {

           try
           {
              
               string[] arrStr = strTemp.Split(":".ToCharArray());
               int intHour = 0, intMinute = 0;
               if (arrStr.Length > 0)
               {
                   try
                   {
                       intHour = int.Parse(arrStr[0]);
                   }
                   catch
                   { }
               }
               if (arrStr.Length > 1)
               {
                   try
                   {
                       intMinute = int.Parse(arrStr[1]);
                   }
                   catch
                   { }


               }
               TimeSpan objTemp =   new TimeSpan(intHour,intMinute, 0);
               double Returned = objTemp.TotalMinutes;
               return Returned;
           }
           catch
           {
               return 0;
           }
       }
       #endregion
   }
}
