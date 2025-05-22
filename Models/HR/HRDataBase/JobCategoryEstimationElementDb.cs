using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class JobCategoryEstimationElementDb 
    {
        #region Private Data        
        protected int _JobCategoryEstimation;
        protected int _Element;
        protected string _JobCategoryEstimationIDs;
        #endregion
        #region Constructors
        public JobCategoryEstimationElementDb()
        {
        }
        public JobCategoryEstimationElementDb(DataRow objDr)           
        {            
            SetData(objDr);
        }
        public JobCategoryEstimationElementDb(int intJobCategoryEstimation, int intElement)
        {
            if (intJobCategoryEstimation != 0 && intElement != 0)
                return;
            _JobCategoryEstimation = intJobCategoryEstimation;
            _Element = intElement;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
            else
            {
                _JobCategoryEstimation = 0;
                _Element = 0;
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
        public int Element
        {
            set
            {
                _Element = value;
            }
            get
            {
                return _Element;
            }
        }
        public string JobCategoryEstimationIDs
        {
            set
            {
                _JobCategoryEstimationIDs = value;
            }            
        }
        public string AddStr
        {
            get
            {
                string strReturned = " INSERT INTO HRJobCategoryEstimationElement(JobCategoryEstimation, Element)" +
                                     " VALUES     (" + _JobCategoryEstimation + "," + _Element + ")";
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
                string strReturned = " Delete From HRJobCategoryEstimationElement Where JobCategoryEstimation = " + _JobCategoryEstimation + "";
                if (_Element != 0)
                    strReturned += "and Element = " + _Element + "";
                return strReturned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturned = " SELECT  HRJobCategoryEstimationElement.JobCategoryEstimation, HRJobCategoryEstimationElement.Element "+
                                     " ,JobCategoryEstimationTable.*,ElementTable.*" +                 
                                     " FROM  HRJobCategoryEstimationElement " +                                     
                                     " Inner join (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable" +
                                     " On JobCategoryEstimationTable.JobCategoryEstimationID = HRJobCategoryEstimationElement.JobCategoryEstimation" +
                                     " Inner join (" + ElementDb.SearchStr + ") as ElementTable" +
                                     " On ElementTable.ElementID = HRJobCategoryEstimationElement.Element";
                return strReturned;               
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["JobCategoryEstimation"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDr["JobCategoryEstimation"].ToString());
            if (objDr["Element"].ToString() != "")
                _Element = int.Parse(objDr["Element"].ToString());            
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
            if (_Element != 0)
            {
                strSql += " And Element =" + _Element + "";
            }
            if (_JobCategoryEstimationIDs != null && _JobCategoryEstimationIDs!="")
            {
                strSql += " And JobCategoryEstimation in ( " + _JobCategoryEstimationIDs + ")";
            }
            strSql += " Order by HRJobCategoryEstimationElement.Element";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }       
        #endregion
    }
}
