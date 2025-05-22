using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatementJobCategoryEstimationBiz
    {
        #region Private Data
        EstimationStatementJobCategoryEstimationDb _EstimationStatementJobCategoryEstimationDb;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        #endregion
        #region Constructors
        public EstimationStatementJobCategoryEstimationBiz()
        {
            _EstimationStatementJobCategoryEstimationDb = new EstimationStatementJobCategoryEstimationDb();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();
        }
        public EstimationStatementJobCategoryEstimationBiz(DataRow objDr)
        {
            _EstimationStatementJobCategoryEstimationDb = new EstimationStatementJobCategoryEstimationDb(objDr);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int EstimationStatement
        {
            set
            {
                _EstimationStatementJobCategoryEstimationDb.EstimationStatement = value;
            }
            get
            {
                return _EstimationStatementJobCategoryEstimationDb.EstimationStatement;
            }
        }
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            set
            {
                _JobCategoryEstimationBiz = value;
            }
            get
            {
                return _JobCategoryEstimationBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _EstimationStatementJobCategoryEstimationDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _EstimationStatementJobCategoryEstimationDb.Add();
        }
        #endregion
    }
}
