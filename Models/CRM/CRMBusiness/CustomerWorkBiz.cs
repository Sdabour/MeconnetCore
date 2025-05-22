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
    public class CustomerWorkBiz
    {
        #region Private Data
        CustomerWorkDb _CustomerWorkDb; 
        #endregion
        #region Constructors
        public CustomerWorkBiz()
        {
            _CustomerWorkDb = new CustomerWorkDb();
        }
        public CustomerWorkBiz(DataRow objDr)
        {
            _CustomerWorkDb = new CustomerWorkDb(objDr);
        }
        public CustomerWorkBiz(CustomerBiz objCustomerBiz)
        {
            _CustomerWorkDb = new CustomerWorkDb(objCustomerBiz.ID);
        }
        #endregion
        #region Public Properties
        public int Customer { set { _CustomerWorkDb.Customer = value; } get { return _CustomerWorkDb.Customer; } }
        public int Country { set { _CustomerWorkDb.Country = value; } get { return _CustomerWorkDb.Country; } }
        public int City { set { _CustomerWorkDb.City = value; } get { return _CustomerWorkDb.City; } }
        public int District { set { _CustomerWorkDb.District = value; } get { return _CustomerWorkDb.District; } }
        public int Region { set { _CustomerWorkDb.Region = value; } get { return _CustomerWorkDb.Region; } }
        public string OtherValue { set { _CustomerWorkDb.OtherValue = value; } get { return _CustomerWorkDb.OtherValue; } }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _CustomerWorkDb.Add();
        }
        public void Edit()
        {
            _CustomerWorkDb.Edit();
        }
        public void Delete()
        {
            _CustomerWorkDb.Delete();
        }
        #endregion
    }
}
