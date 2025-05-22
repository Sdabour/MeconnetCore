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
    public class JobCategoryDb : BaseSingleDb
    {
        #region Private Data        
        int _OrderValue;
        #endregion
        #region Constructors
        public JobCategoryDb()
        {

        }

        public JobCategoryDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }


        }
        public JobCategoryDb(DataRow objDR)
        {            
            SetData(objDR);
        }
        public JobCategoryDb(int intID, string strName)
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
        
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRJobCategory.JobCategoryID, HRJobCategory.JobCategoryNameA,HRJobCategory.JobCategoryNameE,HRJobCategory.OrderValue as OrderValue1
                                     FROM HRJobCategory ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JobCategoryID"].ToString()!="")
            _ID = int.Parse(objDR["JobCategoryID"].ToString());
            _NameA = objDR["JobCategoryNameA"].ToString();
            _NameE = objDR["JobCategoryNameE"].ToString();
            if (objDR["OrderValue1"].ToString()!="")
            _OrderValue = int.Parse(objDR["OrderValue1"].ToString());                       
        }
        #endregion
        #region Public Methods
        public override void Add()
        {            
            string strSql = "insert into HRJobCategory (JobCategoryNameA,JobCategoryNameE,OrderValue as OrderValue1,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+ _OrderValue +"," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);            
        }
        public override void Edit()
        {            
            string strSql = "update  HRJobCategory ";
            strSql = strSql + " set JobCategoryNameA ='" + _NameA + "'";
            strSql = strSql + " , JobCategoryNameE ='" + NameE + "'";
            strSql = strSql + " , OrderValue =" + _OrderValue;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobCategoryID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobCategory set Dis = GetDate() where JobCategoryID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobCategory.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobCategoryID = " + _ID.ToString();

            strSql = strSql + " Order By OrderValue";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
