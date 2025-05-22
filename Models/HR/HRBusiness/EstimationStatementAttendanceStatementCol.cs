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
    public class EstimationStatementAttendanceStatementCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public EstimationStatementAttendanceStatementCol(bool IsEmpty)
        {
        }
        public EstimationStatementAttendanceStatementCol()
        {
            EstimationStatementAttendanceStatementDb objDb = new EstimationStatementAttendanceStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow  objDr in dtTemp.Rows)
            {
                this.Add(new EstimationStatementAttendanceStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual void Add(EstimationStatementAttendanceStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public virtual EstimationStatementAttendanceStatementBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatementAttendanceStatementBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HREstimationStatementAttendanceStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("EstimationStatement"), new DataColumn("AttendanceStatement") });
            DataRow objDr;
            foreach (EstimationStatementAttendanceStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["EstimationStatement"] = objBiz.EstimationStatement;
                objDr["AttendanceStatement"] = objBiz.AttendanceStatementBiz.ID;                
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public DateTime StartDateAttendanceStatement
        {
            get
            {
                DateTime dt=new DateTime(1900,1,1);
                foreach (EstimationStatementAttendanceStatementBiz objBiz in this)
                {
                    if (dt > objBiz.AttendanceStatementBiz.StatementFrom)
                        dt = objBiz.AttendanceStatementBiz.StatementFrom;
                }
                return dt;
            }
        }
        public DateTime EndDateAttendanceStatement
        {
            get
            {
                DateTime dt = new DateTime(1900, 1, 1);
                foreach (EstimationStatementAttendanceStatementBiz objBiz in this)
                {
                    if (dt < objBiz.AttendanceStatementBiz.StatementTo)
                        dt = objBiz.AttendanceStatementBiz.StatementTo;
                }
                return dt;
            }
        }
        public AttendanceStatementCol GetAttendanceStatementCol()
        {
            AttendanceStatementCol objCol = new AttendanceStatementCol(true);
            foreach (EstimationStatementAttendanceStatementBiz objBiz in this)
            {
                objCol.Add(objBiz.AttendanceStatementBiz);
            }
            return objCol;
        }
        #endregion
    }
}
