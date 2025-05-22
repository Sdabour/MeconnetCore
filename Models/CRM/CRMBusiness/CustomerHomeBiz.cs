using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;

using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerHomeBiz
    {
        #region Private Data
        CustomerHomeDb _CustomerHomeDb; 
        #endregion
        #region Constructors
        public CustomerHomeBiz()
        {
            _CustomerHomeDb = new CustomerHomeDb();
        }
        public CustomerHomeBiz(DataRow objDr)
        {
            _CustomerHomeDb = new CustomerHomeDb(objDr);
        }
        public CustomerHomeBiz(CustomerBiz objCustomerBiz)
        {
            _CustomerHomeDb = new CustomerHomeDb(objCustomerBiz.ID);
        }
        #endregion
        #region Public Properties
        public int Customer { set { _CustomerHomeDb.Customer = value; } get { return _CustomerHomeDb.Customer; } }
        public int Country { set { _CustomerHomeDb.Country = value; } get { return _CustomerHomeDb.Country; } }
        public int City { set { _CustomerHomeDb.City = value; } get { return _CustomerHomeDb.City; } }
        public int District { set { _CustomerHomeDb.District = value; } get { return _CustomerHomeDb.District; } }
        public int Region { set { _CustomerHomeDb.Region = value; } get { return _CustomerHomeDb.Region; } }
        public string OtherValue { set { _CustomerHomeDb.OtherValue = value; } get { return _CustomerHomeDb.OtherValue; } }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _CustomerHomeDb.Add();
        }
        public void Edit()
        {
            _CustomerHomeDb.Edit();
        }
        public void Delete()
        {
            _CustomerHomeDb.Delete();
        }
        #endregion
    }
}
