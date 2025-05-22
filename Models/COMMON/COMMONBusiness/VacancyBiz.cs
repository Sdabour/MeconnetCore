using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
   public class VacancyBiz
   {
       #region Private Data
       VacancyDb _VacancyDb;
       static VacancyCol _VacancyCol;
       #endregion
       #region Constructors
       public VacancyBiz()
       {
           _VacancyDb = new VacancyDb();
       }
       public VacancyBiz(int intID)
       {
           _VacancyDb = new VacancyDb(intID);
       }
       public VacancyBiz(DataRow objDR)
       {
           _VacancyDb = new VacancyDb(objDR);
       }
       #endregion
       #region Public Properties
       public int ID
       {
           set
           {
               _VacancyDb.ID = value;
           }
           get
           {
               return _VacancyDb.ID;
           }

       }
       public string Desc
       {
           set
           {
               _VacancyDb.Desc = value;
           }
           get
           {
               return _VacancyDb.Desc;
           }

       }
       public bool IsWeekly
       {
           set
           {
               _VacancyDb.IsWeekly = value;
           }
           get
           {
               return _VacancyDb.IsWeekly;
           }

       }
       public bool IsMonthly
       {
           set
           {
               _VacancyDb.IsMonthly = value;
           }
           get
           {
               return _VacancyDb.IsMonthly;
           }

       }
       public DateTime StartDate
       {
           set
           {
               _VacancyDb.StartDate = value;
           }
           get
           {
               return _VacancyDb.StartDate;
           }

       }
       public DateTime EndDate
       {
           set
           {
               _VacancyDb.EndDate = value;
           }
           get
           {
               return _VacancyDb.EndDate;
           }

       }
       public bool IsYearly
       {
           set
           {
               _VacancyDb.IsYearly = value;
           }
           get
           {
               return _VacancyDb.IsYearly;
           }

       }
       public bool IsDoubledSalary
       {
           set
           {
               _VacancyDb.IsDoubledSalary = value;
           }
           get
           {
               return _VacancyDb.IsDoubledSalary;
           }

       }
       public bool IsShowInInsurance
       {
           set
           {
               _VacancyDb.IsShowInInsurance = value;
           }
           get
           {
               return _VacancyDb.IsShowInInsurance;
           }

       }
       public string DoubledSalaryStr
       {           
           get
           {
               if (IsDoubledSalary == true)
                   return "Ì „ «·Õ”«»";
               else
                   return "·« Ì „ «·Õ”«»";
           }

       }
       public static VacancyCol VacancyCol
       {
           set
           {
               _VacancyCol = value;
           }
           get
           {
               if (_VacancyCol == null)
               {

                   DataTable dtTemp = new VacancyDb().Search();
                   _VacancyCol = new VacancyCol(true);
                   foreach (DataRow objDr in dtTemp.Rows)
                   {
                       _VacancyCol.Add(new VacancyBiz(objDr));
                   }
               }
               return _VacancyCol;
           }
       }
       public int VacancyDayNo
       {
           get
           {
               int _count = 0;
               DateTime dtFrom = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);
               DateTime dtTo = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day);
               DateTime dt = dtFrom;
               while (dt <= dtTo)
               {
                   _count++;
                   dt = dt.AddDays(1);
               }
               return _count;
           }
       }
        #endregion
       #region Private Methods

        #endregion
       #region Public Methods
       public  void Add(bool IsMonthly, bool IsWeekly, DateTime dtstart, DateTime dtend, string strDec, bool IsYearly, bool IsDoubledSalary, bool IsShowInInsurance)
       {
           //VacancyDb objVacancyDb = new VacancyDb();
           //objVacancyDb.IsMonthly = IsMonthly;
           //objVacancyDb.IsWeekly = IsWeekly;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsDoubledSalary = IsDoubledSalary;
           //objVacancyDb.StartDate = dtstart;
           //objVacancyDb.EndDate = dtend;
           //objVacancyDb.Desc = strDec;
           //objVacancyDb.IsShowInInsurance = IsShowInInsurance;
           _VacancyDb.Add();
           //VacancyCol = null;
       }
       public  void Edit(int intID, bool IsMonthly, bool IsWeekly, DateTime dtstart, DateTime dtend, string strDec, bool IsYearly, bool IsDoubledSalary, bool IsShowInInsurance)
       {
           //VacancyDb objVacancyDb = new VacancyDb();
           //objVacancyDb.ID = intID;
           //objVacancyDb.IsMonthly = IsMonthly;
           //objVacancyDb.IsWeekly = IsWeekly;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsDoubledSalary = IsDoubledSalary;
           //objVacancyDb.StartDate = dtstart;
           //objVacancyDb.EndDate = dtend;
           //objVacancyDb.Desc = strDec;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsShowInInsurance = IsShowInInsurance;
           _VacancyDb.Edit();
           //VacancyCol = null;
       }
       public void Add()
       {
           //VacancyDb objVacancyDb = new VacancyDb();
           //objVacancyDb.IsMonthly = IsMonthly;
           //objVacancyDb.IsWeekly = IsWeekly;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsDoubledSalary = IsDoubledSalary;
           //objVacancyDb.StartDate = dtstart;
           //objVacancyDb.EndDate = dtend;
           //objVacancyDb.Desc = strDec;
           //objVacancyDb.IsShowInInsurance = IsShowInInsurance;
           _VacancyDb.Add();
           //VacancyCol = null;
       }
       public void Edit()
       {
           //VacancyDb objVacancyDb = new VacancyDb();
           //objVacancyDb.ID = intID;
           //objVacancyDb.IsMonthly = IsMonthly;
           //objVacancyDb.IsWeekly = IsWeekly;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsDoubledSalary = IsDoubledSalary;
           //objVacancyDb.StartDate = dtstart;
           //objVacancyDb.EndDate = dtend;
           //objVacancyDb.Desc = strDec;
           //objVacancyDb.IsYearly = IsYearly;
           //objVacancyDb.IsShowInInsurance = IsShowInInsurance;
           _VacancyDb.Edit();
           //VacancyCol = null;
       }
       public  void Delete(int intID)
       {         
           _VacancyDb.Delete();
       }
       public bool CheckDate(DateTime objDate)
       {
           bool Returned = false;
           StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);
           EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day);
           if (this.IsMonthly)
           {
               if (objDate.Day >= StartDate.Day && objDate.Day <= EndDate.Day)
                   Returned = true;
           }
           else if (this.IsWeekly)
           {
               if (objDate.DayOfWeek >= StartDate.DayOfWeek && objDate.DayOfWeek <= EndDate.DayOfWeek)
                   Returned = true;
           }
           else if (IsYearly)
           {
               if (objDate.DayOfYear >= StartDate.DayOfYear && objDate.DayOfYear <= EndDate.DayOfYear )
               {
                   Returned = true;
               }
           }
           else
           {
               if (objDate >= StartDate && objDate <= EndDate)
                   Returned = true;
           }
           return Returned;
       }
      
       #endregion
   }
}
