using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class VacancyCol : BaseCol
    {
        public VacancyCol()
        {
            VacancyDb objVacancyDb = new VacancyDb();
            DataTable dtVacancy = objVacancyDb.Search();
            VacancyBiz objVacancyBiz;
            //if (dtVacancy == null)
            //    dtVacancy = new DataTable();
            DataRow[] arrDr = dtVacancy.Select("", "VacancyID desc");
            foreach (DataRow objDr in arrDr)
            {

                objVacancyBiz = new VacancyBiz(objDr);

                this.Add(objVacancyBiz);
            }
        }
        public VacancyCol(DateTime dtFrom, DateTime dtTo)
        {
            VacancyDb objVacancyDb = new VacancyDb();
            objVacancyDb.DateSearch = true;
            objVacancyDb.StartDateSearch = dtFrom;
            objVacancyDb.EndDateSearch = dtTo;
            DataTable dtVacancy = objVacancyDb.Search();
            VacancyBiz objVacancyBiz;
            //if (dtVacancy == null)
            //    dtVacancy = new DataTable();
            DataRow[] arrDr = dtVacancy.Select("", "VacancyID desc");
            foreach (DataRow objDr in arrDr)
            {

                objVacancyBiz = new VacancyBiz(objDr);

                this.Add(objVacancyBiz);
            }
        }
        public VacancyCol(DateTime dtFrom, DateTime dtTo,byte byIsShowInInSurance)
        {
            VacancyDb objVacancyDb = new VacancyDb();
            objVacancyDb.DateSearch = true;
            objVacancyDb.StartDateSearch = dtFrom;
            objVacancyDb.EndDateSearch = dtTo;
            objVacancyDb.IsShowInInsuranceSearch = byIsShowInInSurance;
            DataTable dtVacancy = objVacancyDb.Search();
            VacancyBiz objVacancyBiz;
            //if (dtVacancy == null)
            //    dtVacancy = new DataTable();
            DataRow[] arrDr = dtVacancy.Select("", "VacancyID desc");
            foreach (DataRow objDr in arrDr)
            {

                objVacancyBiz = new VacancyBiz(objDr);

                this.Add(objVacancyBiz);
            }
        }
        public VacancyCol(bool blIsempty)
        {

        }
        public VacancyCol(int intID)
        {
            VacancyDb objDb = new VacancyDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new VacancyBiz(objDr));
            }
        }

        public VacancyBiz this[int intIndex]
        {
           
            get
            {
                return (VacancyBiz)List[intIndex];
            }
        }


        public void Add(VacancyBiz objBiz)
        {
            List.Add(objBiz);
 
        }
      
        public DateTime  CheckVacancy(DateTime objDate,VacancyDeal objDeal)
        {
            DateTime Returned = objDate;
            if(objDeal != VacancyDeal.Ignore )
            {
                foreach(VacancyBiz objBiz in this)
                {
                    if (objBiz.CheckDate(objDate))
                    {
                        if (objDeal == VacancyDeal.After)
                            Returned = Returned.AddDays(1);
                        else if (objDeal == VacancyDeal.Before)
                            return Returned.AddDays(-1);
                        Returned = CheckVacancy(Returned, objDeal);

                    }
                }
            }
            return Returned;
        }
        public bool IsVacancy(DateTime dtTemp)
        {
            foreach (VacancyBiz objBiz in this)
            {
                if (objBiz.CheckDate(dtTemp))
                    return true;
            }
            return false;
        }
        public bool IsNonWeekendVacancy(DateTime dtTemp,out VacancyBiz objTemp)
        {
            objTemp = new VacancyBiz();
            foreach (VacancyBiz objBiz in this)
            {
                if (objBiz.CheckDate(dtTemp) && !objBiz.IsWeekly)
                {
                    objTemp = objBiz;
                    return true;
                }
            }
            return false;
        }
    }
}
