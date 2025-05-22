using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class JobCategoryEstimationJobNatureDb 
    {
        #region Private Data        
        protected int _JobCategoryEstimation;
        protected int _JobNature;
        protected int _CostCenter;       
        #endregion
        #region Constructors
        public JobCategoryEstimationJobNatureDb()
        {
        }
        public JobCategoryEstimationJobNatureDb(DataRow objDr)           
        {            
            SetData(objDr);
        }
        public JobCategoryEstimationJobNatureDb(int intJobCategoryEstimation, int intJobNature)
        {
            if (intJobCategoryEstimation != 0 && intJobNature != 0)
                return;
            _JobCategoryEstimation = intJobCategoryEstimation;
            _JobNature = intJobNature;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
            else
            {
                _JobCategoryEstimation = 0;
                _JobNature = 0;
            }
        }  
        #endregion
        #region Public Properties        
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
        public int JobNature
        {
            set
            {
                _JobNature = value;
            }
            get
            {
                return _JobNature;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
            }
        }        
        public string AddStr
        {
            get
            {
                string strReturned = " INSERT INTO HRJobCategoryEstimationJobNature(JobCategoryEstimation, JobNature,CostCenter)" +
                                     " VALUES     (" + _JobCategoryEstimation + "," + _JobNature + ","+ _CostCenter +")";
                return strReturned;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturned = " ";
                return strReturned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturned = " Delete From HRJobCategoryEstimationJobNature Where JobCategoryEstimation = " + _JobCategoryEstimation + "";
                if (_JobNature != 0)
                    strReturned += "and JobNature = " + _JobNature + "";
                return strReturned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturned = " SELECT  HRJobCategoryEstimationJobNature.JobCategoryEstimation, HRJobCategoryEstimationJobNature.JobNature,"+
                                     " HRJobCategoryEstimationJobNature.CostCenter " +
                                     " ,JobCategoryEstimationTable.*,JobNatureTable.*" +                 
                                     " FROM  HRJobCategoryEstimationJobNature " +                                     
                                     " Inner join (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable" +
                                     " On JobCategoryEstimationTable.JobCategoryEstimationID = HRJobCategoryEstimationJobNature.JobCategoryEstimation" +
                                     " Inner join (" + JobNatureTypeDb.SearchStr + ") as JobNatureTable" +
                                     " On JobNatureTable.JobNatureID = HRJobCategoryEstimationJobNature.JobNature";
                return strReturned;               
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["JobCategoryEstimation"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDr["JobCategoryEstimation"].ToString());
            if (objDr["JobNature"].ToString() != "")
                _JobNature = int.Parse(objDr["JobNature"].ToString());
            if (objDr["CostCenter"].ToString() != "")
                _CostCenter = int.Parse(objDr["CostCenter"].ToString());
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
        public  DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_JobCategoryEstimation != 0)
            {
                strSql += " And JobCategoryEstimation =" + _JobCategoryEstimation + "";
            }
            if (_JobNature != 0)
            {
                strSql += " And JobNature =" + _JobNature + "";
            }
            if (_CostCenter != 0)
            {
                strSql += " And CostCenter =" + _CostCenter + "";
            } 
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }       
        #endregion
    }
}
