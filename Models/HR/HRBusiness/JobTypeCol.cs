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
    public class JobTypeCol : CollectionBase
    {
        public JobTypeCol()
        {
            JobTypeBiz objJobBiz;

            JobTypeDb objJobDb = new JobTypeDb();
            DataTable dtJob = objJobDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objJobBiz = new JobTypeBiz(DR);

                this.Add(objJobBiz);
            }

        }
        public JobTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobTypeBiz objJobBiz;
                objJobBiz = new JobTypeBiz();
                objJobBiz.ID = 0;
                objJobBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobBiz);
                JobTypeDb objJobDb = new JobTypeDb();
                DataTable dtJob = objJobDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobBiz = new JobTypeBiz(DR);

                    this.Add(objJobBiz);
                }
            }

        }
        public virtual JobTypeBiz this[int intIndex]
        {
            get
            {

                return (JobTypeBiz)this.List[intIndex];

         }   }

        public virtual JobTypeBiz this[string strIndex]
        {
            get
            {
                JobTypeBiz Returned = new JobTypeBiz();
                foreach (JobTypeBiz objJobBiz in this)
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


        public virtual void Add(JobTypeBiz objJobBiz)
        {
            if (this[objJobBiz.Name].Name == null || this[objJobBiz.Name].Name == "")
            {
                this.List.Add(objJobBiz.Copy());
            }

        }


        public virtual void Add(JobCol objJobCol)
        {
            foreach (JobTypeBiz objJobBiz in objJobCol)
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
        public static JobTypeBiz GetJobTypeBiz(int intID)
        {
            foreach (JobTypeBiz objBiz in JobTypeCol.CacheJobTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new JobTypeBiz();
        }

        static JobTypeCol _CacheJobTypeCol;
        public static JobTypeCol CacheJobTypeCol
        {
            set
            {
                _CacheJobTypeCol = value;
            }
            get
            {
                if (_CacheJobTypeCol == null)
                {
                    _CacheJobTypeCol = new JobTypeCol(false);
                }
                return _CacheJobTypeCol;
            }
        }
    }
}
