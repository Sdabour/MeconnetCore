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
    public class JobCategoryEstimationJobNatureCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobCategoryEstimationJobNatureCol()
        {
            JobCategoryEstimationJobNatureDb objDb = new JobCategoryEstimationJobNatureDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new JobCategoryEstimationJobNatureBiz(objDr));
            }
        }
        public JobCategoryEstimationJobNatureCol(JobCategoryEstimationBiz objBiz)
        {
            JobCategoryEstimationJobNatureDb objDb = new JobCategoryEstimationJobNatureDb();
            objDb.JobCategoryEstimation = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new JobCategoryEstimationJobNatureBiz(objDr));
            }
        }
        public JobCategoryEstimationJobNatureCol(JobCategoryEstimationBiz objBiz, JobNatureTypeCol objJobNatureTypeCol)
        {
            JobCategoryEstimationJobNatureDb objDb = new JobCategoryEstimationJobNatureDb();
            objDb.JobCategoryEstimation = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            JobCategoryEstimationJobNatureBiz objJobCategoryEstimationJobNatureBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objJobCategoryEstimationJobNatureBiz = new JobCategoryEstimationJobNatureBiz(objDr);
                if (objJobNatureTypeCol.GetIndex(objJobCategoryEstimationJobNatureBiz.JobNatureBiz.ID) != -1)
                    this.Add(new JobCategoryEstimationJobNatureBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual JobCategoryEstimationJobNatureBiz this[int intIndex]
        {
            get
            {
                return (JobCategoryEstimationJobNatureBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        public virtual void Add(JobCategoryEstimationJobNatureBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Public Methods
        public JobNatureTypeCol GetJobNatureCol()
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);
            foreach (JobCategoryEstimationJobNatureBiz objBiz in this)
            {
                objCol.Add(objBiz.JobNatureBiz);
            }
            return objCol;

        }
        #endregion
    }
}
