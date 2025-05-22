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
    public class EstimationStatementGlobalStatementCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public EstimationStatementGlobalStatementCol(bool IsEmpty)
        {
        }
        public EstimationStatementGlobalStatementCol()
        {
            EstimationStatementGlobalStatementDb objDb = new EstimationStatementGlobalStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow  objDr in dtTemp.Rows)
            {
                this.Add(new EstimationStatementGlobalStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual void Add(EstimationStatementGlobalStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public virtual EstimationStatementGlobalStatementBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatementGlobalStatementBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HREstimationStatementGlobalStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("EstimationStatement"), new DataColumn("GlobalStatement") });
            DataRow objDr;
            foreach (EstimationStatementGlobalStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["EstimationStatement"] = objBiz.EstimationStatement;
                objDr["GlobalStatement"] = objBiz.GlobalStatementBiz.ID;                
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public DateTime StartDateGlobalStatement
        {
            get
            {
                DateTime dt=new DateTime(1900,1,1);
                foreach (EstimationStatementGlobalStatementBiz objBiz in this)
                {
                    if (dt > objBiz.GlobalStatementBiz.StatementDate)
                        dt = objBiz.GlobalStatementBiz.StatementDate;
                }
                return dt;
            }
        }
        public DateTime EndDateGlobalStatement
        {
            get
            {
                DateTime dt = new DateTime(1900, 1, 1);
                foreach (EstimationStatementGlobalStatementBiz objBiz in this)
                {
                    if (dt < objBiz.GlobalStatementBiz.StatementDateTo)
                        dt = objBiz.GlobalStatementBiz.StatementDateTo;
                }
                return dt;
            }
        }
        public GlobalStatementCol GetGlobalStatementCol()
        {
            GlobalStatementCol objCol = new GlobalStatementCol(true);
            foreach (EstimationStatementGlobalStatementBiz objBiz in this)
            {
                objCol.Add(objBiz.GlobalStatementBiz);
            }
            return objCol;
        }
        #endregion
    }
}
