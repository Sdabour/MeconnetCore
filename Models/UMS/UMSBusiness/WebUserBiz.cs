using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using System.Data;
namespace SharpVision.UMS.UMSBusiness
{
    public class WebUserBiz : UserBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public WebUserBiz()
        {

            _UserDb = new WebUserDb();
          
        }

      
        public WebUserBiz(DataRow DR) :base(DR)
        {
           
        
        }
        public WebUserBiz(WebUserDb objUserDb)
        {
            _UserDb = objUserDb;
          

        }
        public WebUserBiz(string strUserName, string strUserFullName, string strUserPassword, int intGroupID,bool blIsGroupAdmin,bool blIsAdmin)
        {
            _UserDb = new UserDb(strUserName, strUserFullName, strUserPassword, intGroupID, blIsGroupAdmin, blIsAdmin);
         //   _UserFunctionInstantDb = new UserFunctionInstantDb();
        }
     

        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static bool CheckUser(string strUserName, string strPassword, out WebUserBiz objUserBiz)
        {
            bool blReturned = false;
            WebUserDb objUserDb = new WebUserDb(strUserName, strPassword);
            if (objUserDb.ID != 0)
            {
                blReturned = true;

            }
            objUserBiz = new WebUserBiz(objUserDb);
            return blReturned;
        }
        public static bool SetUmsBaseConnection(string strWebServiceUrl,int intSysID)
        {

            return WebUserDb.SetUmsBaseConnection(strWebServiceUrl,intSysID);
        }
        #endregion
    }
}
