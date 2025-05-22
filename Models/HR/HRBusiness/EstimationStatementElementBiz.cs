using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.HR.HRBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatementElementBiz
    {
        #region Private Data
        EstimationStatementElementDb _EstimationStatementElementDb;
        ElementBiz _ElementBiz;
        #endregion
        #region Constructors

        public EstimationStatementElementBiz()
        {
            _EstimationStatementElementDb = new EstimationStatementElementDb();
            _ElementBiz = new ElementBiz();
        }
        public EstimationStatementElementBiz(DataRow objDR)
        {
            _EstimationStatementElementDb = new EstimationStatementElementDb(objDR);
            _ElementBiz = new ElementBiz(objDR);
        }
        #endregion
        #region Public Properties             
        public int EstimationStatement
        {
            set { _EstimationStatementElementDb.EstimationStatement = value; }
            get { return _EstimationStatementElementDb.EstimationStatement; }
        }
        public float PercValue
        {
            set { _EstimationStatementElementDb.PercValue = value; }
            get { return _EstimationStatementElementDb.PercValue; }
        }
        public ElementBiz ElementBiz
        {
            set { _ElementBiz = value; }
            get { return _ElementBiz; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _EstimationStatementElementDb.Element = _ElementBiz.ID;
            _EstimationStatementElementDb.Add();
        }
        public void Edit()
        {
            _EstimationStatementElementDb.Element = _ElementBiz.ID;
            _EstimationStatementElementDb.Edit();
        }
        public void Delete()
        {
            _EstimationStatementElementDb.Delete();
        }

        #endregion
    }
}
