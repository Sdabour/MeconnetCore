using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
   public  class UserSystemBiz
    {

        #region Constructor
        public UserSystemBiz()
        {
            _UserSystemDb = new UserSystemDb();
        }
        public UserSystemBiz(DataRow objDr)
        {
            _UserSystemDb = new UserSystemDb(objDr);
            if (_UserSystemDb.SysID != 0)
                _SystemBiz = new SystemBiz() { ID = _UserSystemDb.SysID, Name = _UserSystemDb.Name };
        }

        #endregion
        #region Private Data
        UserSystemDb _UserSystemDb;
        #endregion
        #region Properties
        public int UserID
        {
            set
            {
                _UserSystemDb.UserID = value;
            }
            get
            {
                return _UserSystemDb.UserID;
            }
        }
        public int SysID
        {
            set
            {
                _UserSystemDb.SysID = value;
            }
            get
            {
                return _UserSystemDb.SysID;
            }
        }
        public bool IsPermanent
        {
            set
            {
                _UserSystemDb.IsPermanent = value;
            }
            get
            {
                return _UserSystemDb.IsPermanent;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _UserSystemDb.StartDate = value;
            }
            get
            {
                return _UserSystemDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _UserSystemDb.EndDate = value;
            }
            get
            {
                return _UserSystemDb.EndDate;
            }
        }
        SystemBiz _SystemBiz;
        public SystemBiz SystemBiz
        {
            set
            {
                _SystemBiz = value;
            }
            get
            {
                if (_SystemBiz == null)
                    _SystemBiz = new SystemBiz();
                return _SystemBiz;
            }
        }
       
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _UserSystemDb.Add();
        }
        public void Edit()
        {
            _UserSystemDb.Edit();
        }
        public void Delete()
        {
            _UserSystemDb.Delete();
        }
        #endregion
    }
}
