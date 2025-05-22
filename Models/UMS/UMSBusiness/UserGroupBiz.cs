using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
    public class UserGroupBiz
    {


        #region Constructor
        public UserGroupBiz()
        {
            _UserGroupDb = new UserGroupDb();
        }
        public UserGroupBiz(DataRow objDr)
        {
            _UserGroupDb = new UserGroupDb(objDr);
            if (_UserGroupDb.GroupID != 0)
                _GroupBiz = new GroupBiz() { ID = _UserGroupDb.GroupID, NameA = _UserGroupDb.Name };
        }

        #endregion
        #region Private Data
        UserGroupDb _UserGroupDb;
        #endregion
        #region Properties
        public int UserID
        {
            set
            {
                _UserGroupDb.UserID = value;
            }
            get
            {
                return _UserGroupDb.UserID;
            }
        }
        public int GroupID
        {
            set
            {
                _UserGroupDb.GroupID = value;
            }
            get
            {
                return _UserGroupDb.GroupID;
            }
        }
        public bool IsPermanent
        {
            set
            {
                _UserGroupDb.IsPermanent = value;
            }
            get
            {
                return _UserGroupDb.IsPermanent;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _UserGroupDb.StartDate = value;
            }
            get
            {
                return _UserGroupDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _UserGroupDb.EndDate = value;
            }
            get
            {
                return _UserGroupDb.EndDate;
            }
        }
        GroupBiz _GroupBiz;
        public GroupBiz GroupBiz
        {
            set
            {
                _GroupBiz = value;
            }
            get
            {
                if (_GroupBiz == null)
                    _GroupBiz = new GroupBiz();
                return _GroupBiz;
            }
        }

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _UserGroupDb.Add();
        }
        public void Edit()
        {
            _UserGroupDb.Edit();
        }
        public void Delete()
        {
            _UserGroupDb.Delete();
        }
        #endregion
    }
}
