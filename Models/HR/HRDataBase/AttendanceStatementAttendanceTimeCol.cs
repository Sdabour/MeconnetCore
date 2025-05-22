using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceStatementAttendanceTimeCol : CollectionBase
    {
        #region Private Data
        string _AttendanceTimeIds;
        #endregion
        #region Constructors
        public AttendanceStatementAttendanceTimeCol(bool blIsEmpty)
        {
           
        }
        public AttendanceStatementAttendanceTimeCol()
        {
            AttendanceStatementAttendanceTimeDb objDb = new AttendanceStatementAttendanceTimeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                this.Add(new AttendanceStatementAttendanceTimeBiz(objDR));
            }
        }
        public AttendanceStatementAttendanceTimeCol(int intAttendanceStatement,int intAttendanceTime)
        {
            AttendanceStatementAttendanceTimeDb objDb = new AttendanceStatementAttendanceTimeDb();
            objDb.AttendanceStatement = intAttendanceStatement;
            objDb.AttendanceTime = intAttendanceTime;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                this.Add(new AttendanceStatementAttendanceTimeBiz(objDR));
            }
        }
        #endregion
        #region Public Properties
        public virtual AttendanceStatementAttendanceTimeBiz this[int intIndex]
        {
            get
            {
                return (AttendanceStatementAttendanceTimeBiz)this.List[intIndex];
            }
        }
        public string AttendanceTimeIds
        {
            get
            {
                return _AttendanceTimeIds;
            }
        }
        
        #endregion
        #region Private Methods
        public virtual void Add(AttendanceStatementAttendanceTimeBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
                this.List.Add(objBiz);
        }
        public int GetIndex(AttendanceStatementAttendanceTimeBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].AttendanceTime == objBiz.AttendanceTime
                    && this[intIndex].AttendanceStatement == objBiz.AttendanceStatement)
                    return intIndex;
            }
            return -1;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRAttendanceStatementAttendanceTime");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("AttendanceStatement"), new DataColumn("AttendanceTime"), new DataColumn("DateFrom"), new DataColumn("DateTo") });
            DataRow objDr;
            foreach (AttendanceStatementAttendanceTimeBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["AttendanceStatement"] = objBiz.AttendanceStatement;
                objDr["AttendanceTime"] = objBiz.AttendanceTime;
                objDr["DateFrom"] = objBiz.DateFrom;
                objDr["DateTo"] = objBiz.DateTo;
               
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public void EditAttendanceStatement(int intStatementID)
        {
            AttendanceStatementAttendanceTimeDb objDb = new AttendanceStatementAttendanceTimeDb();            
            objDb.EditAttendanceStatement(intStatementID, this.GetTable());
        }
        #endregion
    }
}
