using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class JobCategoryEstimationElementBiz
    {
        #region Private Data
        JobCategoryEstimationElementDb _JobCategoryEstimationElementDb;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        ElementBiz _ElementBiz;
        #endregion
        #region Constructors
        public JobCategoryEstimationElementBiz()
        {
            _JobCategoryEstimationElementDb = new JobCategoryEstimationElementDb();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();
            _ElementBiz = new ElementBiz();
        }
        public JobCategoryEstimationElementBiz(DataRow objDr)
        {
            _JobCategoryEstimationElementDb = new JobCategoryEstimationElementDb(objDr);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDr);
            _ElementBiz = new ElementBiz(objDr);
        }
        public JobCategoryEstimationElementBiz(ElementBiz objElementTypeBiz)
        {
            _JobCategoryEstimationElementDb = new JobCategoryEstimationElementDb(0, objElementTypeBiz.ID);
            _ElementBiz = new ElementBiz(_JobCategoryEstimationElementDb.Element);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(_JobCategoryEstimationElementDb.JobCategoryEstimation);
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
        public ElementBiz ElementBiz
        {
            set
            {
                _ElementBiz = value;
            }
            get
            {
                return _ElementBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _JobCategoryEstimationElementDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _JobCategoryEstimationElementDb.Element = _ElementBiz.ID;
            _JobCategoryEstimationElementDb.Add();
        }
        public void Delete()
        {
            _JobCategoryEstimationElementDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _JobCategoryEstimationElementDb.Element = _ElementBiz.ID;
            _JobCategoryEstimationElementDb.Delete();
        }
        #endregion
    }
}
