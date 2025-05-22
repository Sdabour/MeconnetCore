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
    public class EstimationStatementJobCategoryEstimationCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public EstimationStatementJobCategoryEstimationCol(bool IsEmpty)
        {
        }
        public EstimationStatementJobCategoryEstimationCol()
        {
            EstimationStatementJobCategoryEstimationDb objDb = new EstimationStatementJobCategoryEstimationDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new EstimationStatementJobCategoryEstimationBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual void Add(EstimationStatementJobCategoryEstimationBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public virtual EstimationStatementJobCategoryEstimationBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatementJobCategoryEstimationBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HREstimationStatementJobCategoryEstimation");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("EstimationStatement"), new DataColumn("JobCategoryEstimation") });
            DataRow objDr;
            foreach (EstimationStatementJobCategoryEstimationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["EstimationStatement"] = objBiz.EstimationStatement;
                objDr["JobCategoryEstimation"] = objBiz.JobCategoryEstimationBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods        
        public JobCategoryEstimationCol GetJobCategoryEstimationCol()
        {
            JobCategoryEstimationCol objCol = new JobCategoryEstimationCol(true);
            foreach (EstimationStatementJobCategoryEstimationBiz objBiz in this)
            {
                objCol.Add(objBiz.JobCategoryEstimationBiz);
            }
            return objCol;
        }
        #endregion
    }
}
