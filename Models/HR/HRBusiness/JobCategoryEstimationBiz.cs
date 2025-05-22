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
    public class JobCategoryEstimationBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobCategoryEstimationBiz()
        {
            _BaseDb = new JobCategoryEstimationDb();
        }
        public JobCategoryEstimationBiz(int intID)
        {
            _BaseDb = new JobCategoryEstimationDb(intID);
        }
        public JobCategoryEstimationBiz(DataRow objDR)
        {
            _BaseDb = new JobCategoryEstimationDb(objDR);
        }

        public JobCategoryEstimationBiz(JobCategoryEstimationDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public int OrderValue
        {
            set
            {
                ((JobCategoryEstimationDb)_BaseDb).OrderValue = value;
            }
            get
            {
                return ((JobCategoryEstimationDb)_BaseDb).OrderValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((JobCategoryEstimationDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((JobCategoryEstimationDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((JobCategoryEstimationDb)_BaseDb).Delete();
        }
        public JobCategoryEstimationBiz Copy()
        {
            JobCategoryEstimationBiz Returned = new JobCategoryEstimationBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.OrderValue = this.OrderValue;

            return Returned;
        }
        JobCategoryEstimationJobNatureCol _JobCategoryEstimationJobNatureCol;
        public JobCategoryEstimationJobNatureCol JobCategoryEstimationJobNatureCol
        {
            get
            {
                if (_JobCategoryEstimationJobNatureCol == null)
                    _JobCategoryEstimationJobNatureCol = new JobCategoryEstimationJobNatureCol(this);
                return _JobCategoryEstimationJobNatureCol;
            }
        }
        JobCategoryEstimationElementCol _JobCategoryEstimationElementCol;
        public JobCategoryEstimationElementCol JobCategoryEstimationElementCol
        {
            set => _JobCategoryEstimationElementCol = value;
            get
            {
                if (_JobCategoryEstimationElementCol == null)
                    _JobCategoryEstimationElementCol = new JobCategoryEstimationElementCol(this);
                return _JobCategoryEstimationElementCol;
            }
        }
        public JobNatureTypeCol GetJobNatureTypeCol()
        {
            _JobCategoryEstimationJobNatureCol = null;
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);
            foreach (JobCategoryEstimationJobNatureBiz objJobCategoryEstimationJobNatureBiz in JobCategoryEstimationJobNatureCol)
            {
                objCol.Add(objJobCategoryEstimationJobNatureBiz.JobNatureBiz);
            }

            return objCol;
        }
        #endregion
    }
}
