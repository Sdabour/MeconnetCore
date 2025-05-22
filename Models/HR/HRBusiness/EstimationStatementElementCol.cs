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
    public class EstimationStatementElementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public EstimationStatementElementCol(bool IsEmpty)
        {
        }
        public EstimationStatementElementCol()
        {
            EstimationStatementElementBiz objBiz;
            EstimationStatementElementDb objDb = new EstimationStatementElementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationStatementElementBiz(objDR);
                this.Add(objBiz);
            }
        }
        public EstimationStatementElementCol(EstimationStatementBiz objEstimationStatementBiz)
        {
            EstimationStatementElementBiz _objBiz;
            EstimationStatementElementDb _objDb = new EstimationStatementElementDb();

            _objDb.EstimationStatement = objEstimationStatementBiz.ID;
            DataTable dtTemp = _objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                _objBiz = new EstimationStatementElementBiz(objDR);
                this.Add(_objBiz);
            }
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual EstimationStatementElementBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatementElementBiz)this.List[intIndex];
            }
        }
        public virtual void Add(EstimationStatementElementBiz objEstimationElementBiz)
        {

            this.List.Add(objEstimationElementBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HREstimationStatementElement");
            dtReturned.Columns.AddRange(new DataColumn[] {  new DataColumn("EstimationStatement"),
                new DataColumn("PercValue"), new DataColumn("Element")
                 });
            DataRow objDr;
            foreach (EstimationStatementElementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["EstimationStatement"] = objBiz.EstimationStatement;
                objDr["PercValue"] = objBiz.PercValue;
                objDr["Element"] = objBiz.ElementBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
