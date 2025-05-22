using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using System.Collections;

namespace SharpVision.HR.HRBusiness
{
    public class JobTitleTypeCol : CollectionBase
    {
        public JobTitleTypeCol()
        {
            JobTitleTypeBiz objJobTitleTypeBiz;

            JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
            DataTable dtJob = objJobTitleTypeDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objJobTitleTypeBiz = new JobTitleTypeBiz(DR);

                this.Add(objJobTitleTypeBiz);
            }

        }
        public JobTitleTypeCol(int intJobID)
        {
            JobTitleTypeBiz objJobTitleTypeBiz=new JobTitleTypeBiz();

            JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
            objJobTitleTypeDb.JobID = intJobID;
            objJobTitleTypeBiz.ID = 0;
            objJobTitleTypeBiz.NameA = "€Ì— „Õœœ";
            objJobTitleTypeBiz.NameE = "Not Specified";
            this.Add(objJobTitleTypeBiz);
            DataTable dtJob = objJobTitleTypeDb.Search();


            foreach (DataRow DR in dtJob.Rows)
            {
                objJobTitleTypeBiz = new JobTitleTypeBiz(DR);

                this.Add(objJobTitleTypeBiz);
            }

        }
        public JobTitleTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobTitleTypeBiz objJobTitleTypeBiz;
                objJobTitleTypeBiz = new JobTitleTypeBiz();
                objJobTitleTypeBiz.ID = 0;
                objJobTitleTypeBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobTitleTypeBiz);
                JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
                DataTable dtJob = objJobTitleTypeDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobTitleTypeBiz = new JobTitleTypeBiz(DR);

                    this.Add(objJobTitleTypeBiz);
                }
            }

        }
        public virtual JobTitleTypeBiz this[int intIndex]
        {
            get
            {

                return (JobTitleTypeBiz)this.List[intIndex];

         }   }

        public virtual JobTitleTypeBiz this[string strIndex]
        {
            get
            {
                JobTitleTypeBiz Returned = new JobTitleTypeBiz();
                foreach (JobTitleTypeBiz objJobTitleTypeBiz in this)
                {
                    if (objJobTitleTypeBiz.Name == strIndex)
                    {
                        Returned = objJobTitleTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(JobTitleTypeBiz objJobTitleTypeBiz)
        {
            if (this[objJobTitleTypeBiz.Name].Name == null || this[objJobTitleTypeBiz.Name].Name == "")
            {
                this.List.Add(objJobTitleTypeBiz.Copy());
            }

        }


        public virtual void Add(JobTitleTypeCol objJobTitleTypeCol)
        {
            foreach (JobTitleTypeBiz objJobTitleTypeBiz in objJobTitleTypeCol)
            {
                if (this[objJobTitleTypeBiz.Name].ID == 0)
                    this.List.Add(objJobTitleTypeBiz.Copy());

            }
        }

        public JobTitleTypeCol Copy()
        {
            JobTitleTypeCol Returned = new JobTitleTypeCol(true);
            foreach (JobTitleTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static JobTitleTypeBiz GetJobTitleTypeBiz(int intID)
        {
            foreach (JobTitleTypeBiz objBiz in JobTitleTypeCol.CacheJobTitleTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new JobTitleTypeBiz();
        }

        static JobTitleTypeCol _CacheJobTitleTypeCol;
        public static JobTitleTypeCol CacheJobTitleTypeCol
        {
            set
            {
                _CacheJobTitleTypeCol = value;
            }
            get
            {
                if (_CacheJobTitleTypeCol == null)
                {
                    _CacheJobTitleTypeCol = new JobTitleTypeCol(false);
                }
                return _CacheJobTitleTypeCol;
            }
        }
    }
}
