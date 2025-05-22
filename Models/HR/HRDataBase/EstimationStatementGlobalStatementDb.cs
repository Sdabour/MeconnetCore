using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementGlobalStatementDb
    {
        #region Private Data
        protected int _EstimationStatement;
        protected int _GlobalStatement;
        string _EstimationStatementIDs;
        #endregion
        #region Constructors
        public EstimationStatementGlobalStatementDb()
        {
        }
        public EstimationStatementGlobalStatementDb(DataRow objDr)
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
        public int GlobalStatement
        {
            set
            {
                _GlobalStatement = value;
            }
            get
            {
                return _GlobalStatement;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HREstimationStatementGlobalStatement.EstimationStatement, HREstimationStatementGlobalStatement.GlobalStatement,GlobalStatementTable.*" +
                                  " FROM         HREstimationStatementGlobalStatement " +
                                  " Inner join (" + GlobalStatementDb.SearchStr + ") as GlobalStatementTable "+
                                  " On GlobalStatementTable.StatementID = HREstimationStatementGlobalStatement.GlobalStatement";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HREstimationStatementGlobalStatement" +
                                   " (EstimationStatement, GlobalStatement)"+
                                   " VALUES ("+ _EstimationStatement +","+ _GlobalStatement +")";
                return strReturn;
            }

        }
       #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
            _GlobalStatement = int.Parse(objDr["GlobalStatement"].ToString());
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
                strSql = strSql + " and HREstimationStatementGlobalStatement.EstimationStatement = " + _EstimationStatement;
            if (_EstimationStatementIDs != null && _EstimationStatementIDs!= "")
                strSql = strSql + " and HREstimationStatementGlobalStatement.EstimationStatement in (" + _EstimationStatementIDs +")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HREstimationStatementGlobalStatement");
        }
        public void Delete()
        {
            string strSql = "delete from HREstimationStatementGlobalStatement where EstimationStatement = " + _EstimationStatement + " And GlobalStatement = " + _GlobalStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
       #endregion
    }
}
