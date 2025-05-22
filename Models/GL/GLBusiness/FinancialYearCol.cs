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
    public class FinancialYearCol : BaseCol
    {
        public FinancialYearCol()
        {

            FinancialYearDb objDb = new FinancialYearDb();
            DataTable dtTemp = objDb.Search();
          
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialYearBiz(objDr));
            }
        }
        public FinancialYearCol(bool blIsempty)
        {
            if ( blIsempty)
                return;
            FinancialYearDb objDb = new FinancialYearDb();
            DataTable dtTemp = objDb.Search();
            FinancialYearBiz objYearBiz = new FinancialYearBiz();
            objYearBiz.Desc = "€Ì— „Õœœ";
            Add(objYearBiz);
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialYearBiz(objDr));
            }
        }
        public FinancialYearCol(int intID)
        {
            FinancialYearDb objDb = new FinancialYearDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialYearBiz(objDr));
            }
        }
        public FinancialYearCol CurrentYearCol
        {
            get
            {
                FinancialYearCol Returned = new FinancialYearCol(true);
                Hashtable hsTemp = new Hashtable();
                foreach (FinancialYearBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                    {
                        Returned.Add(objBiz);
                        continue;
                    }
                    if (hsTemp[objBiz.CompanyBiz.ID.ToString()] != null)
                    {
                        if (((FinancialYearBiz)hsTemp[objBiz.CompanyBiz.ID.ToString()]).StartDate <
                            objBiz.StartDate)
                            hsTemp[objBiz.CompanyBiz.ID.ToString()] = objBiz;
                    }
                    else {
                        hsTemp.Add(objBiz.CompanyBiz.ID.ToString(), objBiz);
                    }
                   
                }
                foreach (object objTemp in hsTemp.Values)
                {
                    Returned.Add((FinancialYearBiz)objTemp);
                }
                return Returned;
            }
        }
        public FinancialPeriodCol LasPeriodCol
        {
            get
            {
                FinancialPeriodCol REturned = new FinancialPeriodCol(true);
                FinancialPeriodBiz objPeriodBiz = new FinancialPeriodBiz();
                objPeriodBiz.Desc = "€Ì— „Õœœ";
                foreach (FinancialYearBiz objYearBiz in this)
                {
                    if (objYearBiz.ID == 0)
                        REturned.Add(objPeriodBiz);
                    if(objYearBiz.LastPeriodBiz.ID != 0)
                    REturned.Add(objYearBiz.LastPeriodBiz);
                }
                return REturned;
            }
        }
        public FinancialYearBiz this[int intIndex]
        {

            get
            {
                return (FinancialYearBiz)List[intIndex];
            }
        }
        public void Add(FinancialYearBiz objBiz)
        {
            List.Add(objBiz);

        }
       public FinancialYearCol GetYearByCompany(int intCompanyID)
       {
           FinancialYearCol Returned = new FinancialYearCol(true);
           foreach (FinancialYearBiz objBiz in this)
           {
               if (objBiz.CompanyBiz.ID == intCompanyID)
                   Returned.Add(objBiz);
           }
           return Returned;
       }

    }
}
