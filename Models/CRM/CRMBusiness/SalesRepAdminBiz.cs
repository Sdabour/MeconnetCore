using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
namespace SharpVision.CRM.CRMBusiness
{
   public  class SalesRepAdminBiz
    {
        #region Private Data
        SalesRepAdminDb _AdminDb;
        #endregion
        #region Constructors
        public SalesRepAdminBiz()
        {
            _AdminDb = new SalesRepAdminDb();
        }
        public SalesRepAdminBiz(DataRow objDr)
        {
            _AdminDb = new SalesRepAdminDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AdminDb.ID = value;
            }
            get
            {
                return _AdminDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _AdminDb.Name  = value;
            }
            get
            {
                return _AdminDb.Name;
            }
        }
        public string PhoneNo
        {
            set
            {
                _AdminDb.PhoneNum = value;
            }
            get
            {
                return _AdminDb.PhoneNum;
            }
        }
        #endregion
        #region Private Methods
        
        #endregion
        #region Public Methods
       
        #endregion
    }
}
