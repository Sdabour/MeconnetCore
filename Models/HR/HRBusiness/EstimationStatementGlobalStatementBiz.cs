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
    public  class EstimationStatementGlobalStatementBiz
    {
        #region Private Data
        EstimationStatementGlobalStatementDb _EstimationStatementGlobalStatementDb;
        GlobalStatementBiz _GlobalStatementBiz;
        #endregion
        #region Constructors
        public EstimationStatementGlobalStatementBiz()
        {
            _EstimationStatementGlobalStatementDb = new EstimationStatementGlobalStatementDb();
            _GlobalStatementBiz = new GlobalStatementBiz();
        }
        public EstimationStatementGlobalStatementBiz(DataRow objDr)
        {
            _EstimationStatementGlobalStatementDb = new EstimationStatementGlobalStatementDb(objDr);
            _GlobalStatementBiz = new GlobalStatementBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int EstimationStatement
        {
            set
            {
                _EstimationStatementGlobalStatementDb.EstimationStatement = value;
            }
            get
            {
                return _EstimationStatementGlobalStatementDb.EstimationStatement;
            }
        }
        public GlobalStatementBiz GlobalStatementBiz
        {
            set
            {
                _GlobalStatementBiz = value;
            }
            get
            {
                return _GlobalStatementBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _EstimationStatementGlobalStatementDb.GlobalStatement = _GlobalStatementBiz.ID;
            _EstimationStatementGlobalStatementDb.Add();
        }
        #endregion
    }
}
