using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class SalesRepAdminDb
    {

        #region Private Data
        int _ID;
        string _Name;
        string _PhoneNo;
        #endregion
        #region Constructors
        public SalesRepAdminDb()
        { 
        }
        public SalesRepAdminDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        public string PhoneNum
        {
            set
            {
                _PhoneNo = value;
            }
            get 
            {
                return _PhoneNo;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  ID, Name, MobileNo " +
                   " FROM   dbo.CRMSalesRepAdmin ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ID"].ToString());
            _Name = objDr["Name"].ToString();
            _PhoneNo = objDr["MobileNo"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
