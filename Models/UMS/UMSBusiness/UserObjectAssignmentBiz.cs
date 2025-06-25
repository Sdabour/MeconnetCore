using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
    public class UserObjectAssignmentBiz
    {

        #region Constructor
        public UserObjectAssignmentBiz()
        {
            _UserObjectAssignmentDb = new UserObjectAssignmentDb();
        }
        public UserObjectAssignmentBiz(DataRow objDr)
        {
            _UserObjectAssignmentDb = new UserObjectAssignmentDb(objDr);
        }

        #endregion
        #region Private Data
        UserObjectAssignmentDb _UserObjectAssignmentDb;
        #endregion
        #region Properties
        public int UserID
        {
            set
            {
                _UserObjectAssignmentDb.UserID = value;
            }
            get
            {
                return _UserObjectAssignmentDb.UserID;
            }
        }
        public string ObjectCode
        {
            set
            {
                _UserObjectAssignmentDb.ObjectCode = value;
            }
            get
            {
                return _UserObjectAssignmentDb.ObjectCode;
            }
        }
        public int ObjectID
        {
            set
            {
                _UserObjectAssignmentDb.ObjectID = value;
            }
            get
            {
                return _UserObjectAssignmentDb.ObjectID;
            }
        }
        public int ObjectValue
        {
            set
            {
                _UserObjectAssignmentDb.ObjectValue = value;
            }
            get
            {
                return _UserObjectAssignmentDb.ObjectValue;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _UserObjectAssignmentDb.StartDate = value;
            }
            get
            {
                return _UserObjectAssignmentDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _UserObjectAssignmentDb.EndDate = value;
            }
            get
            {
                return _UserObjectAssignmentDb.EndDate;
            }
        }
        public bool IsPermanent
        {
            set
            {
                _UserObjectAssignmentDb.IsPermanent = value;
            }
            get
            {
                return _UserObjectAssignmentDb.IsPermanent;
            }
        }
        public SingleObjectBiz SingleObjectBiz
        {
            get
            {
                SingleObjectBiz Returned = new SingleObjectBiz() { ID=ObjectValue,NameA = ""};
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _UserObjectAssignmentDb.Add();
        }
        public void Edit()
        {
            _UserObjectAssignmentDb.Edit();
        }
        public void Delete()
        {
            _UserObjectAssignmentDb.Delete();
        }
        #endregion
    }
}
