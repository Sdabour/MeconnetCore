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
    public class JobCategoryEstimationElementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobCategoryEstimationElementCol(bool blIsEmpty)
        {

        }
        public JobCategoryEstimationElementCol()
        {
            JobCategoryEstimationElementDb objDb = new JobCategoryEstimationElementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new JobCategoryEstimationElementBiz(objDr));
            }
        }
        public JobCategoryEstimationElementCol(JobCategoryEstimationBiz objBiz)
        {
            JobCategoryEstimationElementDb objDb = new JobCategoryEstimationElementDb();
            if (objBiz.ID == 0)
                return;
            objDb.JobCategoryEstimation = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new JobCategoryEstimationElementBiz(objDr));
            }
        }
        public JobCategoryEstimationElementCol(JobCategoryEstimationCol objCol)
        {
            JobCategoryEstimationElementDb objDb = new JobCategoryEstimationElementDb();
            if (objCol.IDs != null && objCol.IDs == "")
                return;
            objDb.JobCategoryEstimationIDs = objCol.IDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new JobCategoryEstimationElementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual JobCategoryEstimationElementBiz this[int intIndex]
        {
            get
            {
                return (JobCategoryEstimationElementBiz)this.List[intIndex];
            }
        }
        public string ElementIDs
        {
            get
            {
                string str = "";
                foreach (JobCategoryEstimationElementBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.ElementBiz.ID.ToString();
                    else
                        str = objBiz.ElementBiz.ID.ToString();
                }
                return str;
            }
        }
        ApplicantWorkerEstimationStatementElementCol _EstimationStatementElementCol;
        public ApplicantWorkerEstimationStatementElementCol ApplicantEstimationStatementElementCol
        {
            get
            {
                if (_EstimationStatementElementCol == null)
                {
                    _EstimationStatementElementCol = new ApplicantWorkerEstimationStatementElementCol(true);
                    ApplicantWorkerEstimationStatementElementBiz objElementBiz;
                    foreach (JobCategoryEstimationElementBiz objBiz in this)
                    {
                        objElementBiz = new ApplicantWorkerEstimationStatementElementBiz() { ElementBiz = objBiz.ElementBiz, EstimationValue = 0, ElementValue = objBiz.ElementBiz.ElementValue };
                        _EstimationStatementElementCol.Add(objElementBiz);

                    }

                }
                return _EstimationStatementElementCol;
            }
        }

        #endregion
        #region Private Methods
        public virtual void Add(JobCategoryEstimationElementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Public Methods
        public ElementCol GetElementCol()
        {
            ElementCol objCol = new ElementCol(ElementIDs);
            //foreach (JobCategoryEstimationElementBiz objBiz in this)
            //{
            //    objCol.Add(objBiz.ElementBiz);
            //}
            return objCol;

        }
        public double TotalElementEstimation
        {
            get
            {
                double intTotal = 0;
                foreach (JobCategoryEstimationElementBiz objBiz in this)
                {
                    intTotal += objBiz.ElementBiz.ElementEstimation;
                }
                return intTotal;
            }
        }
        #endregion
    }
}
