using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class JobTitleCol : CollectionBase
    {
        public JobTitleCol()
        {
            JobTitleBiz objJobTitleBiz;

            JobTitleDb objJobTitleDb = new JobTitleDb();
            DataTable dtJob = objJobTitleDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objJobTitleBiz = new JobTitleBiz(DR);

                this.Add(objJobTitleBiz);
            }

        }
        public JobTitleCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobTitleBiz objJobTitleBiz;
                objJobTitleBiz = new JobTitleBiz();
                objJobTitleBiz.ID = 0;
                objJobTitleBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobTitleBiz);
                JobTitleDb objJobTitleDb = new JobTitleDb();
                DataTable dtJob = objJobTitleDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobTitleBiz = new JobTitleBiz(DR);

                    this.Add(objJobTitleBiz);
                }
            }

        }
        public virtual JobTitleBiz this[int intIndex]
        {
            get
            {

                return (JobTitleBiz)this.List[intIndex];

         }   }

        public virtual JobTitleBiz this[string strIndex]
        {
            get
            {
                JobTitleBiz Returned = new JobTitleBiz();
                foreach (JobTitleBiz objJobTitleBiz in this)
                {
                    if (objJobTitleBiz.Name == strIndex)
                    {
                        Returned = objJobTitleBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(JobTitleBiz objJobTitleBiz)
        {
            if (this[objJobTitleBiz.Name].Name == null || this[objJobTitleBiz.Name].Name == "")
            {
                this.List.Add(objJobTitleBiz.Copy());
            }

        }


        public virtual void Add(JobTitleCol objJobTitleCol)
        {
            foreach (JobTitleBiz objJobTitleBiz in objJobTitleCol)
            {
                if (this[objJobTitleBiz.Name].ID == 0)
                    this.List.Add(objJobTitleBiz.Copy());

            }
        }

        public JobTitleCol Copy()
        {
            JobTitleCol Returned = new JobTitleCol(true);
            foreach (JobTitleBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
