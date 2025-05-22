using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class JobCol : CollectionBase
    {
        public JobCol()
        {
            JobBiz objJobBiz;
           
            JobDb objJobDb = new JobDb();
            DataTable dtJob = objJobDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objJobBiz = new JobBiz(DR);

                this.Add(objJobBiz);
            }

        }
        public JobCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobBiz objJobBiz;
                objJobBiz = new JobBiz();
                objJobBiz.ID = 0;
                objJobBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobBiz);
                JobDb objJobDb = new JobDb();
                DataTable dtJob = objJobDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobBiz = new JobBiz(DR);

                    this.Add(objJobBiz);
                }
            }

        }
        public virtual JobBiz this[int intIndex]
        {
            get
            {

                return (JobBiz)this.List[intIndex];

         }   }

        public virtual JobBiz this[string strIndex]
        {
            get
            {
                JobBiz Returned = new JobBiz();
                foreach (JobBiz objJobBiz in this)
                {
                    if (objJobBiz.Name == strIndex)
                    {
                        Returned = objJobBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }

        public string IDsStr
        {
            get 
            {
                string Returned = "";
                foreach (JobBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public virtual void Add(JobBiz objJobBiz)
        {
            if (this[objJobBiz.Name].Name == null || this[objJobBiz.Name].Name == "")
            {
                this.List.Add(objJobBiz.Copy());
            }

        }


        public virtual void Add(JobCol objJobCol)
        {
            foreach (JobBiz objJobBiz in objJobCol)
            {
                if (this[objJobBiz.Name].ID == 0)
                    this.List.Add(objJobBiz.Copy());

            }
        }

        public JobCol Copy()
        {
            JobCol Returned = new JobCol(true);
            foreach (JobBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
