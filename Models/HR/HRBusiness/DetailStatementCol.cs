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
    public class DetailStatementCol :  CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public DetailStatementCol(bool IsEmpty)
        {
        }
        public DetailStatementCol()
        {
            DetailStatementBiz _objDetailEstimationBiz;
            DetailStatementDb _objDetailEstimationDb = new DetailStatementDb();
            DataTable dtDetailEstimation = _objDetailEstimationDb.Search();
            foreach (DataRow objDR in dtDetailEstimation.Rows)
            {
                _objDetailEstimationBiz = new DetailStatementBiz(objDR);
                this.Add(_objDetailEstimationBiz);
            }            
        }
        public DetailStatementCol(int intDetailStatementID)
        {
            DetailStatementBiz _objDetailEstimationBiz;
            DetailStatementDb _objDetailEstimationDb = new DetailStatementDb();

            _objDetailEstimationDb.DetailStatementID = intDetailStatementID;
            
            DataTable dtDetailEstimation = _objDetailEstimationDb.Search();
            foreach (DataRow objDR in dtDetailEstimation.Rows)
            {
                _objDetailEstimationBiz = new DetailStatementBiz(objDR);
                this.Add(_objDetailEstimationBiz);
            }
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual DetailStatementBiz this[int intIndex]
        {
            get
            {
                return (DetailStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(DetailStatementBiz objDetailEstimationBiz)
        {

            this.List.Add(objDetailEstimationBiz);
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRDetailStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DetailStatementDate"), new DataColumn("DetailStatementDesc"), new DataColumn("DetailStatementBonuisType"), new DataColumn("DetailStatementID"), new DataColumn("StatusDelete"), new DataColumn("DetailStatementEstimationStatement") });
             DataRow objDr;
            foreach (DetailStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["DetailStatementDate"] = objBiz.DetailStatementDate;
                objDr["DetailStatementDesc"] = objBiz.DetailStatementDesc;
                objDr["DetailStatementBonuisType"] = objBiz.DetailTypeBiz.ID;
                objDr["StatusDelete"] = objBiz.StatusDelete;
                objDr["DetailStatementID"] = objBiz.DetailStatementID;
                objDr["DetailStatementEstimationStatement"] = objBiz.DetailStatementEstimationStatement;
                

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
#endregion
        #region Public Methods

        #endregion
    }
}
