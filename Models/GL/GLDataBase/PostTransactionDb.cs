using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLDataBase
{
    public class PostTransactionDb
    {
        #region Private Data
        int _ID;
        
        #endregion
        #region Constructors

        #endregion
        #region Public Properties
        public int ID
        {
            get
            {
                return _ID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "Insert into GLPostTransaction  (PostDate, PostUsr) " +
                " values (GetDate(),"+ SysData.CurrentUser.ID.ToString() +")";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        #endregion
    }
}
