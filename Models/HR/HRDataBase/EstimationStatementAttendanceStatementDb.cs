using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementAttendanceStatementDb
    {
        #region Private Data
        protected int _EstimationStatement;
        protected int _AttendanceStatement;
        string _EstimationStatementIDs;
        #endregion
        #region Constructors
        public EstimationStatementAttendanceStatementDb()
        {
        }
        public EstimationStatementAttendanceStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
       #endregion
        #region Public Properties
        public int EstimationStatement
        {
            set
            {
                _EstimationStatement = value;
            }
            get
            {
                return _EstimationStatement;
            }
        }
        public string EstimationStatementIDs
        {
            set
            {
                _EstimationStatementIDs = value;
            }            
        }
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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HREstimationStatementAttendanceStatement.EstimationStatement, HREstimationStatementAttendanceStatement.AttendanceStatement,AttendanceStatementTable.*" +
                                  " FROM         HREstimationStatementAttendanceStatement " +
                                  " Inner join (" + AttendanceStatementDb.SearchStr + ") as AttendanceStatementTable "+
                                  " On AttendanceStatementTable.StatementID = HREstimationStatementAttendanceStatement.AttendanceStatement";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HREstimationStatementAttendanceStatement" +
                                   " (EstimationStatement, AttendanceStatement)"+
                                   " VALUES ("+ _EstimationStatement +","+ _AttendanceStatement +")";
                return strReturn;
            }

        }
       #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
            _AttendanceStatement = int.Parse(objDr["AttendanceStatement"].ToString());
        }
       #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }       
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_EstimationStatement != 0)
                strSql = strSql + " and HREstimationStatementAttendanceStatement.EstimationStatement = " + _EstimationStatement;
            if (_EstimationStatementIDs != null && _EstimationStatementIDs!= "")
                strSql = strSql + " and HREstimationStatementAttendanceStatement.EstimationStatement in (" + _EstimationStatementIDs +")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HREstimationStatementAttendanceStatement");
        }
        public void Delete()
        {
            string strSql = "delete from HREstimationStatementAttendanceStatement where EstimationStatement = " + _EstimationStatement + " And AttendanceStatement = " + _AttendanceStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
       #endregion
    }
}
