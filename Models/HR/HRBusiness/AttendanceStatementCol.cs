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
    public class AttendanceStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public AttendanceStatementCol(bool IsEmpty)
        { 
        }
        public AttendanceStatementCol()
        {
            AttendanceStatementDb _AttendanceStatementDb = new AttendanceStatementDb();
            DataTable dtAttendanceStatement = _AttendanceStatementDb.Search();
            AttendanceStatementBiz objAttendanceStatementBiz;

            foreach (DataRow DR in dtAttendanceStatement.Rows)
            {
                objAttendanceStatementBiz = new AttendanceStatementBiz(DR);
                this.Add(objAttendanceStatementBiz);
            }

        }
        public AttendanceStatementCol(int intStatementID)
        {
            AttendanceStatementDb _AttendanceStatementDb = new AttendanceStatementDb();
            _AttendanceStatementDb.ID = intStatementID;
            DataTable dtAttendanceStatement = _AttendanceStatementDb.Search();
            AttendanceStatementBiz objAttendanceStatementBiz;

            foreach (DataRow DR in dtAttendanceStatement.Rows)
            {
                objAttendanceStatementBiz = new AttendanceStatementBiz(DR);
                this.Add(objAttendanceStatementBiz);
            }

        }
        public AttendanceStatementCol(DateTime dtFrom,DateTime dtTo)
        {
            AttendanceStatementDb _AttendanceStatementDb = new AttendanceStatementDb();
            _AttendanceStatementDb.StatementDateStatusSearch = true;
            _AttendanceStatementDb.StatementFromSearch = dtFrom;
            _AttendanceStatementDb.StatementToSearch = dtTo;
            DataTable dtAttendanceStatement = _AttendanceStatementDb.Search();
            AttendanceStatementBiz objAttendanceStatementBiz;

            foreach (DataRow DR in dtAttendanceStatement.Rows)
            {
                objAttendanceStatementBiz = new AttendanceStatementBiz(DR);
                this.Add(objAttendanceStatementBiz);
            }

        }
        public AttendanceStatementCol(DateTime dtFrom, DateTime dtTo,byte byStatementNotFinish)
        {
            AttendanceStatementDb _AttendanceStatementDb = new AttendanceStatementDb();
            _AttendanceStatementDb.StatementDateStatusSearch = true;
            _AttendanceStatementDb.StatementFromSearch = dtFrom;
            _AttendanceStatementDb.StatementToSearch = dtTo;
            _AttendanceStatementDb.StatementNotFinish = (int)byStatementNotFinish;
            DataTable dtAttendanceStatement = _AttendanceStatementDb.Search();
            AttendanceStatementBiz objAttendanceStatementBiz;

            foreach (DataRow DR in dtAttendanceStatement.Rows)
            {
                objAttendanceStatementBiz = new AttendanceStatementBiz(DR);
                this.Add(objAttendanceStatementBiz);
            }

        }
        #endregion
        #region Public Properties
        public string IDs
        {
            get
            {
                string strIDs = "";
                foreach (AttendanceStatementBiz objBiz in this)
                {
                    if (strIDs != "")
                        strIDs = strIDs + ",";
                    strIDs = strIDs + objBiz.ID.ToString();
                }
                return strIDs;
            }
        }
        #endregion
        #region Private Methods
        public virtual AttendanceStatementBiz this[int intIndex]
        {
            get
            {
                return (AttendanceStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(AttendanceStatementBiz objAttendanceStatementBiz)
        {

            this.List.Add(objAttendanceStatementBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRAttendanceStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("StatementID"), new DataColumn("StatementDesc"), 
                new DataColumn("StatementFrom"),new DataColumn("StatementTo"),new DataColumn("StatementDelayLimit")});
            DataRow objDr;
            foreach (AttendanceStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["StatementID"] = objBiz.ID;
                objDr["StatementDesc"] = objBiz.StatementDesc;
                objDr["StatementFrom"] = objBiz.StatementFrom;
                objDr["StatementTo"] = objBiz.StatementTo;
                objDr["StatementDelayLimit"] = objBiz.DelayLimit;
                
                
                
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public bool CheckManyStatementWithTheSameDateFrom()
        {
              DateTime dt = new  DateTime(1900, 1, 1);
              int intStatus = 0;
            foreach (AttendanceStatementBiz objBiz in this)
            {
                if (dt.Year == 1900)
                {
                    dt = objBiz.StatementFrom;
                    intStatus = objBiz.ApplicantStatus;
                    continue;
                }
                if (dt != objBiz.StatementFrom)
                {
                    if (intStatus == objBiz.ApplicantStatus)
                    return false;
                }

            }
            return true;
        }
        #endregion
    }
}
