using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class JobCategoryEstimationJobNatureBiz
    {
        #region Private Data
        JobCategoryEstimationJobNatureDb _JobCategoryEstimationJobNatureDb;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        JobNatureTypeBiz _JobNatureBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        #endregion
        #region Constructors
        public JobCategoryEstimationJobNatureBiz()
        {
            _JobCategoryEstimationJobNatureDb = new JobCategoryEstimationJobNatureDb();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();
            _JobNatureBiz = new JobNatureTypeBiz();
            _CostCenterHRBiz = new CostCenterHRBiz();
        }
        public JobCategoryEstimationJobNatureBiz(DataRow objDr)
        {
            _JobCategoryEstimationJobNatureDb = new JobCategoryEstimationJobNatureDb(objDr);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDr);
            _JobNatureBiz = new JobNatureTypeBiz(objDr);
            _CostCenterHRBiz = new CostCenterHRBiz(_JobCategoryEstimationJobNatureDb.CostCenter);
        }
        public JobCategoryEstimationJobNatureBiz(JobNatureTypeBiz objJobNatureTypeBiz)
        {
            _JobCategoryEstimationJobNatureDb = new JobCategoryEstimationJobNatureDb(0, objJobNatureTypeBiz.ID);
            _JobNatureBiz = new JobNatureTypeBiz(_JobCategoryEstimationJobNatureDb.JobNature);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(_JobCategoryEstimationJobNatureDb.JobCategoryEstimation);
            _CostCenterHRBiz = new CostCenterHRBiz(_JobCategoryEstimationJobNatureDb.CostCenter);
        }
        #endregion
        #region Public Properties
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
        public JobNatureTypeBiz JobNatureBiz
        {
            set
            {
                _JobNatureBiz = value;
            }
            get
            {
                return _JobNatureBiz;
            }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set
            {
                _CostCenterHRBiz = value;
            }
            get
            {
                return _CostCenterHRBiz;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _JobCategoryEstimationJobNatureDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _JobCategoryEstimationJobNatureDb.JobNature = _JobNatureBiz.ID;
            _JobCategoryEstimationJobNatureDb.CostCenter = _CostCenterHRBiz.ID;
            _JobCategoryEstimationJobNatureDb.Add();
        }
        public void Add(int intJobNatureID, int intJobCategoryEstimation)
        {
            _JobCategoryEstimationJobNatureDb.JobCategoryEstimation = intJobCategoryEstimation;
            _JobCategoryEstimationJobNatureDb.JobNature = intJobNatureID;
            _JobCategoryEstimationJobNatureDb.CostCenter = 0;
            _JobCategoryEstimationJobNatureDb.Add();
        }
        public void Delete()
        {
            _JobCategoryEstimationJobNatureDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _JobCategoryEstimationJobNatureDb.JobNature = _JobNatureBiz.ID;
            _JobCategoryEstimationJobNatureDb.CostCenter = _CostCenterHRBiz.ID;
            _JobCategoryEstimationJobNatureDb.Delete();
        }
        #endregion
    }
}
