using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementJobCategoryEstimationDb
    {
        #region Private Data
        protected int _EstimationStatement;
        protected int _JobCategoryEstimation;
        #endregion
        #region Constructors
        public EstimationStatementJobCategoryEstimationDb()
        {
        }
        public EstimationStatementJobCategoryEstimationDb(DataRow objDr)
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
        public int JobCategoryEstimation
        {
            set
            {
                _JobCategoryEstimation = value;
            }
            get
            {
                return _JobCategoryEstimation;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HREstimationStatementJobCategoryEstimation.EstimationStatement, HREstimationStatementJobCategoryEstimation.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                                  " FROM         HREstimationStatementJobCategoryEstimation " +
                                  " Inner join (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable "+
                                  " On JobCategoryEstimationTable.JobCategoryEstimationID  = HREstimationStatementJobCategoryEstimation.JobCategoryEstimation";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HREstimationStatementJobCategoryEstimation" +
                                   " (EstimationStatement, JobCategoryEstimation)"+
                                   " VALUES ("+ _EstimationStatement +","+ _JobCategoryEstimation +")";
                return strReturn;
            }

        }
       #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
            _JobCategoryEstimation = int.Parse(objDr["JobCategoryEstimation"].ToString());
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
                strSql = strSql + " and HREstimationStatementJobCategoryEstimation.EstimationStatement = " + _EstimationStatement;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HREstimationStatementJobCategoryEstimation");
        }
        public void Delete()
        {
            string strSql = "delete from HREstimationStatementJobCategoryEstimation where EstimationStatement = " + _EstimationStatement + " And JobCategoryEstimation = " + _JobCategoryEstimation + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
       #endregion
    }
}
