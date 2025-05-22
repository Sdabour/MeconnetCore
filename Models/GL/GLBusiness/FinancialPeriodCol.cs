using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLDataBase;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class FinancialPeriodCol : BaseCol
    {
        public FinancialPeriodCol()
        {
         
            FinancialPeriodDb objDb = new FinancialPeriodDb();
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "PeriodID desc");
            foreach (DataRow objDr in arrDr)
            {
                Add(new FinancialPeriodBiz(objDr));
            }
        }
        public FinancialPeriodCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            FinancialPeriodDb objDb = new FinancialPeriodDb();
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "PeriodID desc");
            foreach (DataRow objDr in arrDr)
            {
                Add(new FinancialPeriodBiz(objDr));
            }
        }
        public FinancialPeriodCol(int intID)
        {
            FinancialPeriodDb objDb = new FinancialPeriodDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialPeriodBiz(objDr));
            }
        }
        public FinancialPeriodBiz this[int intIndex]
        {

            get
            {
                return (FinancialPeriodBiz)List[intIndex];
            }
        }
        public static FinancialPeriodCol CurrentPeriodCol
        {
            get
            {
                FinancialPeriodCol Returned = new FinancialPeriodCol(true);
                FinancialPeriodDb objDb = new FinancialPeriodDb();
                objDb.IsStoppedStatus = 2;

                DataTable dtTemp = objDb.Search();
                DataRow[] arrDr = dtTemp.Select("", "PeriodStartDate desc");
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new FinancialPeriodBiz(objDr));
                }
                return Returned;
            }
        }
        public FinancialPeriodCol CurrentlCol
        {
            get
            {
                FinancialPeriodCol Returned = new FinancialPeriodCol(true);
                foreach (FinancialPeriodBiz objBiz in this)
                {
                    if (!objBiz.IsStopped)
                        Returned.Add(objBiz);

                }
                return Returned;
            }
        }

        public CompanyCol CompanyCol
        {
            get
            {
                CompanyCol Returned = new CompanyCol(true);
                Hashtable hsTemp = new Hashtable();
                CompanyBiz objCompanyBiz = new CompanyBiz();
                objCompanyBiz.NameA = "€Ì— „Õœœ";
                Returned.Add(objCompanyBiz);
                hsTemp.Add(objCompanyBiz.ID.ToString(), objCompanyBiz);
                foreach (FinancialPeriodBiz objBiz in this)
                {
                    if (hsTemp[objBiz.YearBiz.CompanyBiz.ID.ToString()] == null)
                    {
                        if (objBiz.YearBiz.CompanyBiz.ID != 0)
                        {
                            Returned.Add(objBiz.YearBiz.CompanyBiz);
                            hsTemp.Add(objBiz.YearBiz.CompanyBiz.ID.ToString(), objBiz.YearBiz.CompanyBiz);
                        }
                        else
                        {
                            Returned.Add(objCompanyBiz);
                            hsTemp.Add(objCompanyBiz.ID.ToString(), objCompanyBiz);
                        }

                    }
                    
                }
                return Returned;
            }
        }
        public FinancialYearCol YearCol
        {
            get 
            {
                FinancialYearCol Returned = new FinancialYearCol(true);
                Hashtable hsTemp = new Hashtable();
                FinancialPeriodBiz objNotSpecified = new FinancialPeriodBiz();
                objNotSpecified.Desc = "€Ì— „Õœœ";
                FinancialYearBiz objYearBiz = new FinancialYearBiz();
                objYearBiz.Desc = "€Ì— „Õœœ";
                objYearBiz.PeriodCol.Add(objNotSpecified);
                Returned.Add(objYearBiz);
               
                foreach (FinancialPeriodBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                        continue;
                    if (hsTemp[objBiz.YearBiz.ID.ToString()] == null)
                    {
                        objYearBiz = objBiz.YearBiz;
                        objYearBiz.PeriodCol.Add(objNotSpecified);
                        objYearBiz.PeriodCol.Add(objBiz);
                        Returned.Add(objYearBiz);
                        hsTemp.Add(objYearBiz.ID.ToString(), objBiz.YearBiz);


                    }
                    else
                    {
                        objYearBiz = (FinancialYearBiz)hsTemp[objBiz.YearBiz.ID.ToString()];
                        objYearBiz.PeriodCol.Add(objBiz);
                    }

                }
                return Returned;
            }
        }
        public void Add(FinancialPeriodBiz objBiz)
        {
            List.Add(objBiz);

        }
        public FinancialPeriodCol GetCol(CompanyBiz objCompanyBiz)
        {
            FinancialPeriodCol Returned = new FinancialPeriodCol(true);
            foreach (FinancialPeriodBiz objBiz in this)
            {
                if(objBiz.YearBiz.CompanyBiz.ID == objCompanyBiz.ID)
                   Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
