
using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatementTypeBiz : BaseSingleBiz
    {
        #region Private Data
              
        #endregion
        #region Constructors
        public EstimationStatementTypeBiz()
        {
            _BaseDb = new EstimationStatementTypeDb();
        }
        public EstimationStatementTypeBiz(int intEstimationStatementTypeID)
        {
            _BaseDb = new EstimationStatementTypeDb(intEstimationStatementTypeID);
        }
        public EstimationStatementTypeBiz(DataRow objDR)
        {
            _BaseDb = new EstimationStatementTypeDb(objDR);
        }

        public EstimationStatementTypeBiz(EstimationStatementTypeDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((EstimationStatementTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((EstimationStatementTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((EstimationStatementTypeDb)_BaseDb).Delete();
        }
        public EstimationStatementTypeBiz Copy()
        {
            EstimationStatementTypeBiz Returned = new EstimationStatementTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}

