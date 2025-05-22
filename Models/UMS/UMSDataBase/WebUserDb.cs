using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase 
{
    public  class WebUserDb : UserDb
    {
        #region Private Data
        
        static DataSet _UserDataSet;
        #endregion
        #region Constructors
        public WebUserDb()
        { 
        }
        public WebUserDb(string strUserName, string strPassword)
        {
            //_UMSService = new UMSService();
            //_UMSService.Url = BaseDb.UMSServiceUrl;
            //try
            //{
            //    _UserDataSet = _UMSService.GetUser(strUserName, strPassword,BaseDb.SysID);
            //    DataTable dtCheck = Search();
            //    if (dtCheck != null && dtCheck.Rows.Count != 0)
            //    {
            //        DataRow DR = dtCheck.Rows[0];

            //        _ID = int.Parse(DR["UserID"].ToString());
            //        _FullName = DR["UserFullname"].ToString();
            //        _Name = DR["UserName"].ToString();
            //        _Password = DR["UserPassword"].ToString();
            //        _GroupID = int.Parse(DR["UserGroup"].ToString());
            //        _GroupName = DR["GroupName"].ToString();
            //    }
            //}
            //catch
            //{
            //    _UserDataSet = new DataSet();
            //    DataTable dtTemp = new DataTable("User");
            //    _UserDataSet.Tables.Add(dtTemp);
            //    dtTemp = new DataTable("UserFunction");
            //    _UserDataSet.Tables.Add(dtTemp);
            //}
        }
        #endregion
       
        #region Public Properties
      
        public static DataSet UserDataSet
        {
            set
            {
                _UserDataSet = value;
            }
            get
            {
                return _UserDataSet;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override DataTable Search()
        {
            return _UserDataSet.Tables["User"];
        }
        public override DataTable GetUserFunctions()
        {
            return _UserDataSet.Tables["UserFunction"];
        }
        public static bool SetUmsBaseConnection(string strServiceURL,int intSysID)
        {
            BaseDb.UMSServiceUrl = strServiceURL;
            BaseDb.SysID = intSysID;
            return true;
        }
        #endregion

    }
}
