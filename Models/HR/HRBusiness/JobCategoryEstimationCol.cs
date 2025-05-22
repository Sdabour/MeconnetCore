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
    public class JobCategoryEstimationCol : CollectionBase
    {
        public JobCategoryEstimationCol()
        {
            JobCategoryEstimationBiz objJobBiz;

            JobCategoryEstimationDb objJobDb = new JobCategoryEstimationDb();
            DataTable dtJob = objJobDb.Search();


            foreach (DataRow DR in dtJob.Rows)
            {
                objJobBiz = new JobCategoryEstimationBiz(DR);

                this.Add(objJobBiz);
            }

        }
        public JobCategoryEstimationCol(string strIDs)
        {
            JobCategoryEstimationBiz objJobBiz;

            JobCategoryEstimationDb objJobDb = new JobCategoryEstimationDb();
            objJobDb.IDs = strIDs;
            DataTable dtJob = objJobDb.Search();


            foreach (DataRow DR in dtJob.Rows)
            {
                objJobBiz = new JobCategoryEstimationBiz(DR);

                this.Add(objJobBiz);
            }

        }
        public JobCategoryEstimationCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobCategoryEstimationBiz objJobBiz;
                objJobBiz = new JobCategoryEstimationBiz();
                objJobBiz.ID = 0;
                objJobBiz.NameA = "€Ì— „Õœœ";
                this.Add(objJobBiz);
                JobCategoryEstimationDb objJobDb = new JobCategoryEstimationDb();
                DataTable dtJob = objJobDb.Search();


                foreach (DataRow DR in dtJob.Rows)
                {
                    objJobBiz = new JobCategoryEstimationBiz(DR);

                    this.Add(objJobBiz);
                }
            }

        }
        public virtual JobCategoryEstimationBiz this[int intIndex]
        {
            get
            {

                return (JobCategoryEstimationBiz)this.List[intIndex];

            }
        }

        public virtual JobCategoryEstimationBiz this[string strIndex]
        {
            get
            {
                JobCategoryEstimationBiz Returned = new JobCategoryEstimationBiz();
                foreach (JobCategoryEstimationBiz objBiz in this)
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

        public int GetIndex(int intID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == intID)
                    return intIndex;
            }
            return -1;
        }
        public virtual void Add(JobCategoryEstimationBiz objBiz)
        {
            if (GetIndex(objBiz.ID) == -1)
                this.List.Add(objBiz);
        }


        public virtual void Add(JobCol objCol)
        {
            foreach (JobCategoryEstimationBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

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

        public JobNatureTypeCol GetJobNatureTypeCol()
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);
            foreach (JobCategoryEstimationBiz objBiz in this)
            {
                foreach (JobCategoryEstimationJobNatureBiz objJobCategoryEstimationJobNatureBiz in objBiz.JobCategoryEstimationJobNatureCol)
                {
                    objCol.Add(objJobCategoryEstimationJobNatureBiz.JobNatureBiz);
                }
            }
            return objCol;
        }
        public string IDs
        {
            get
            {
                string str = "";
                foreach (JobCategoryEstimationBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.ID;
                    else
                        str = objBiz.ID.ToString();
                }
                return str;
            }
        }
        JobCategoryEstimationElementCol _JobCategoryEstimationElementCol;
        public JobCategoryEstimationElementCol JobCategoryEstimationElementCol
        {
            get
            {
                if (_JobCategoryEstimationElementCol == null)
                    _JobCategoryEstimationElementCol = new JobCategoryEstimationElementCol(this);
                return _JobCategoryEstimationElementCol;
            }
        }
        public static JobCategoryEstimationBiz GetJobCategoryEstimationBiz(int intID)
        {
            foreach (JobCategoryEstimationBiz objBiz in JobCategoryEstimationCol.CacheJobCategoryEstimationCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new JobCategoryEstimationBiz();
        }

        static JobCategoryEstimationCol _CacheJobCategoryEstimationCol;
        public static JobCategoryEstimationCol CacheJobCategoryEstimationCol
        {
            set
            {
                _CacheJobCategoryEstimationCol = value;
            }
            get
            {
                if (_CacheJobCategoryEstimationCol == null)
                {
                    _CacheJobCategoryEstimationCol = new JobCategoryEstimationCol(false);
                }
                return _CacheJobCategoryEstimationCol;
            }
        }
        public void SetEstimationElementCol()
        {
            JobCategoryEstimationElementDb objElementDb = new JobCategoryEstimationElementDb();
            objElementDb.JobCategoryEstimationIDs = IDs;
            DataTable dtTemp = objElementDb.Search();
            DataRow[] arrDr;
            foreach (JobCategoryEstimationBiz objEstimationBiz in this)
            {
                objEstimationBiz.JobCategoryEstimationElementCol = new JobCategoryEstimationElementCol(true);
                arrDr = dtTemp.Select("JobCategoryEstimation=" + objEstimationBiz.ID.ToString(), "");
                foreach (DataRow objDr in arrDr)
                {
                    objEstimationBiz.JobCategoryEstimationElementCol.Add(new JobCategoryEstimationElementBiz(objDr));
                }
            }
        }
    }
}
