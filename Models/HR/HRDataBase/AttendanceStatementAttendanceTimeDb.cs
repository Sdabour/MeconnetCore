using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class AttendanceStatementAttendanceTimeDb
    {
        #region Private Data
        protected int _AttendanceStatement;
        protected int _AttendanceTime;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;
        #endregion
        #region Constructors
        public AttendanceStatementAttendanceTimeDb()
        {
        }
        public AttendanceStatementAttendanceTimeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int AttendanceStatement
        {
            set
            {
                _AttendanceStatement = value;
            }
            get
            {
                return _AttendanceStatement;
            }
        }
        public int AttendanceTime
        {
            set
            {
                _AttendanceTime= value;
            }
            get
            {
                return _AttendanceTime;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _DateFrom = value;
            }
            get
            {
                return _DateFrom;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _DateTo = value;
            }
            get
            {
                return _DateTo;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     HRAttendanceStatementAttendanceTime.AttendanceStatement, "+
                                   " HRAttendanceStatementAttendanceTime.AttendanceTime,HRAttendanceStatementAttendanceTime.DateFrom,"+
                                   " HRAttendanceStatementAttendanceTime.DateTo " +
                                   " FROM         HRAttendanceStatementAttendanceTime";
                return strReturn;
            }
        }
        public string AddStr
        {
            get
            {
                double dlFrom = _DateFrom.ToOADate() - 2;
                double dlTo = _DateTo.ToOADate() - 2;
                string strReturn = " INSERT INTO HRAttendanceStatementAttendanceTime"+
                                   " (AttendanceStatement, AttendanceTime,DateFrom,DateTo)" +
                                   " VALUES (" + _AttendanceStatement + "," + _AttendanceTime + "," + dlFrom + "," + dlTo + ")";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " DELETE FROM HRAttendanceStatementAttendanceTime"+
                                   " WHERE (AttendanceStatement = "+ _AttendanceStatement +") AND (AttendanceTime ="+ _AttendanceTime +") ";
                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["AttendanceStatement"].ToString() == "")
                return;
            _AttendanceStatement = int.Parse(objDr["AttendanceStatement"].ToString());
            _AttendanceTime = int.Parse(objDr["AttendanceTime"].ToString());
            _DateFrom = DateTime.Parse(objDr["DateFrom"].ToString());
            _DateTo = DateTime.Parse(objDr["DateTo"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRAttendanceStatementAttendanceTime");
        }
        public void EditAttendanceStatement(int intAttendanceStatement,DataTable dtAttendanceTime)
        {
            if (dtAttendanceTime == null || dtAttendanceTime.Rows.Count == 0)
                return;
            string strAttendanceTimeIDs = "";
            foreach (DataRow objDr in dtAttendanceTime.Rows)
            {
                if (strAttendanceTimeIDs == "")
                {
                    strAttendanceTimeIDs = objDr["AttendanceTime"].ToString();
                }
                else
                {
                    strAttendanceTimeIDs += "," + objDr["AttendanceTime"].ToString();
                }
            }

            string strSql = " Delete From HRAttendanceStatementAttendanceTime " +
                            " Where AttendanceStatement = " + intAttendanceStatement + "  and AttendanceTime in (" + strAttendanceTimeIDs + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            if (intAttendanceStatement != 0)
            {
                
                foreach (DataRow objDr in dtAttendanceTime.Rows)
                {
                    int intAttendance = int.Parse(objDr["AttendanceTime"].ToString());
                    double dlFrom = DateTime.Parse(objDr["DateFrom"].ToString()).ToOADate() -2;
                    double dlTo = DateTime.Parse(objDr["DateTo"].ToString()).ToOADate() - 2;
                    strSql = " Insert Into HRAttendanceStatementAttendanceTime (AttendanceStatement,AttendanceTime,DateFrom,DateTo)" +
                             " Values (" + intAttendanceStatement + ","+ intAttendance +","+ dlFrom +","+ dlTo +")";
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                }
                
            }
        }
        #endregion
    }
}
