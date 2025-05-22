using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class JobCategoryCol : CollectionBase
    {
        public JobCategoryCol()
        {
            JobCategoryBiz objJobBiz;

            JobCategoryDb objJobDb = new JobCategoryDb();
            DataTable dtJob = objJobDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objJobBiz = new JobCategoryBiz(DR);

                this.Add(objJobBiz);
            }

        }
        public JobCategoryCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobCategoryBiz objJobBiz;
                objJobBiz = new JobCategoryBiz();
                objJobBiz.ID = 0;
                objJobBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobBiz);
                JobCategoryDb objJobDb = new JobCategoryDb();
                DataTable dtJob = objJobDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobBiz = new JobCategoryBiz(DR);

                    this.Add(objJobBiz);
                }
            }

        }
        public virtual JobCategoryBiz this[int intIndex]
        {
            get
            {

                return (JobCategoryBiz)this.List[intIndex];

         }   }

        public virtual JobCategoryBiz this[string strIndex]
        {
            get
            {
                JobCategoryBiz Returned = new JobCategoryBiz();
                foreach (JobCategoryBiz objBiz in this)
                {
                    if (objBiz.Name == strIndex)
                    {
                        Returned = objBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(JobCategoryBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(JobCol objCol)
        {
            foreach (JobCategoryBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        //public JobCol Copy()
        //{
        //    JobCol Returned = new JobCol(true);
        //    foreach (JobBiz objTemp in this)
        //    {
        //        Returned.Add(objTemp.Copy());
        //    }
        //    return Returned;
        //}
        public static JobCategoryBiz GetJobCategoryBiz(int intID)
        {
            foreach (JobCategoryBiz objBiz in JobCategoryCol.CacheJobCategoryCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new JobCategoryBiz();
        }

        static JobCategoryCol _CacheJobCategoryCol;
        public static JobCategoryCol CacheJobCategoryCol
        {
            set
            {
                _CacheJobCategoryCol = value;
            }
            get
            {
                if (_CacheJobCategoryCol == null)
                {
                    _CacheJobCategoryCol = new JobCategoryCol(false);
                }
                return _CacheJobCategoryCol;
            }
        }
        public JobCategoryCol GetCol(string strFilter)
        {
            JobCategoryCol Returned = new JobCategoryCol(true);
            bool blIsFound = true;
            string[] arrStr = strFilter.Split("%".ToCharArray());
            foreach (JobCategoryBiz objBiz in this)
            {
               if(objBiz.Name.CheckStr(strFilter))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public JobCategoryCol Copy()
        {
            JobCategoryCol Returned = new JobCategoryCol(true);
            foreach (JobCategoryBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
    }
}
