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
    public class EstimationStatementCol : CollectionBase
    {
        #region Private Data
        Hashtable _StatementHs = new Hashtable();
        #endregion
        #region Constructors
        public EstimationStatementCol(bool IsEmpty)
        {
        }
        public EstimationStatementCol()
        {
            EstimationStatementBiz objBiz;
            EstimationStatementDb objDb = new EstimationStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationStatementBiz(objDR);
                this.Add(objBiz);
            }
        }
        public EstimationStatementCol(EstimationStatementTypeBiz objEstimationStatementTypeBiz)
        {
            EstimationStatementBiz objBiz;
            EstimationStatementDb objDb = new EstimationStatementDb();
            objDb.EstimationStatementTypeID = objEstimationStatementTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationStatementBiz(objDR);
                this.Add(objBiz);
            }
        }
        public EstimationStatementCol(EstimationStatementBiz objEstimationStatementBiz)
        {
            EstimationStatementBiz objBiz;
            EstimationStatementDb objDb = new EstimationStatementDb();
            objDb.ID = objEstimationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationStatementBiz(objDR);
                this.Add(objBiz);
            }
        }
        public EstimationStatementCol(string strEstimationStatementDesc, bool blEstimationStatementDateStatus, DateTime dtEstimationStatementDate, int intStatementType)
        {
            EstimationStatementBiz objBiz;
            EstimationStatementDb objDb = new EstimationStatementDb();

            objDb.EstimationStatementDesc = strEstimationStatementDesc;
            objDb.EstimationStatementDate = dtEstimationStatementDate;
            objDb.EstimationStatementTypeID = intStatementType;
            objDb.EstimationDateSearch = blEstimationStatementDateStatus;
            objDb.EstimationDateFromSearch = dtEstimationStatementDate;
            objDb.EstimationDateToSearch = dtEstimationStatementDate;
            //_objEstimationEstimationDb.EstimationDatesear = blEstimationStatementDateStatus;

            DataTable dtEstimationEstimation = objDb.Search();
            foreach (DataRow objDR in dtEstimationEstimation.Rows)
            {
                objBiz = new EstimationStatementBiz(objDR);
                this.Add(objBiz);
            }
        }
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (EstimationStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual EstimationStatementBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatementBiz)this.List[intIndex];
            }
        }
        public EstimationStatementBiz this[string strIndex]
        {
            get
            {
                EstimationStatementBiz Returned = new EstimationStatementBiz();
                int intIndex = 0;
                if (_StatementHs[strIndex] != null)
                {
                    int.TryParse(_StatementHs[strIndex].ToString(), out intIndex);
                    Returned = this[intIndex];
                }
                return Returned;
            }
        }
        public virtual void Add(EstimationStatementBiz objEstimationEstimationBiz)
        {
            if (_StatementHs[objEstimationEstimationBiz.ID.ToString()] == null)
                _StatementHs.Add(objEstimationEstimationBiz.ID.ToString(), Count);
            this.List.Add(objEstimationEstimationBiz);
        }
        #endregion
        #region Public Methods
        public static EstimationStatementBiz GetLastEstimationStatementBiz()
        {
            EstimationStatementCol objCol = new EstimationStatementCol();
            if (objCol == null || objCol.Count == 0)
                return null;
            else
                return objCol[0];
        }
        EstimationStatementAttendanceStatementCol _AttendanceStatementCol;
        public EstimationStatementAttendanceStatementCol AttendanceStatementCol
        {
            set
            {
                _AttendanceStatementCol = value;
            }
            get
            {
                if (_AttendanceStatementCol == null)
                {
                    _AttendanceStatementCol = new EstimationStatementAttendanceStatementCol(true);
                    if (IDsStr != null && IDsStr != "")
                    {
                        EstimationStatementAttendanceStatementDb objDb = new EstimationStatementAttendanceStatementDb();
                        objDb.EstimationStatementIDs = IDsStr;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AttendanceStatementCol.Add(new EstimationStatementAttendanceStatementBiz(objDr));
                        }

                    }
                }
                return _AttendanceStatementCol;
            }
        }
        #endregion
    }
}
