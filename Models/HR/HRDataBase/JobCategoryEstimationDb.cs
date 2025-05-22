using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class JobCategoryEstimationDb : BaseSingleDb
    {
        #region Private Data        
        int _OrderValue;
        string _IDs;
        #endregion
        #region Constructors
        public JobCategoryEstimationDb()
        {

        }

        public JobCategoryEstimationDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }


        }
        public JobCategoryEstimationDb(DataRow objDR)
        {            
            SetData(objDR);
        }
        public JobCategoryEstimationDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;           
        }

        #endregion
        #region Public Properties

        public int OrderValue
        {
            set
            {
                _OrderValue = value;
            }
            get
            {
                return _OrderValue;
            }
        }
        public string IDs { set { _IDs = value; } }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRJobCategoryEstimation.JobCategoryEstimationID, HRJobCategoryEstimation.JobCategoryEstimationNameA,HRJobCategoryEstimation.JobCategoryEstimationNameE,HRJobCategoryEstimation.OrderValue
                                     FROM HRJobCategoryEstimation ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JobCategoryEstimationID"].ToString()!="")
            _ID = int.Parse(objDR["JobCategoryEstimationID"].ToString());
            _NameA = objDR["JobCategoryEstimationNameA"].ToString();
            _NameE = objDR["JobCategoryEstimationNameE"].ToString();
            if (objDR["OrderValue"].ToString()!="")
            _OrderValue = int.Parse(objDR["OrderValue"].ToString());                       
        }
        #endregion
        #region Public Methods
        public override void Add()
        {            
            string strSql = "insert into HRJobCategoryEstimation (JobCategoryEstimationNameA,JobCategoryEstimationNameE,OrderValue,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+ _OrderValue +"," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);            
        }
        public override void Edit()
        {            
            string strSql = "update  HRJobCategoryEstimation ";
            strSql = strSql + " set JobCategoryEstimationNameA ='" + _NameA + "'";
            strSql = strSql + " , JobCategoryEstimationNameE ='" + NameE + "'";
            strSql = strSql + " , OrderValue =" + _OrderValue;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobCategoryEstimationID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobCategoryEstimation set Dis = GetDate() where JobCategoryEstimationID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobCategoryEstimation.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobCategoryEstimationID = " + _ID.ToString();
            if (_IDs!=null &&_IDs != "")
                strSql = strSql + " and JobCategoryEstimationID in ("+ _IDs +")"; ;
            strSql = strSql + " Order By OrderValue";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
