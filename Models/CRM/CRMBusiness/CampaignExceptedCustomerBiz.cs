using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using System.Text;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignExceptedCustomerBiz
    {
        #region Private Data
        CampaignExceptedCustomerDb _ExceptedCustomerDb;
        CampaignBiz _CampaignBiz;
        CustomerBiz _CustomerBiz;
        #endregion
        #region Constructors
        public CampaignExceptedCustomerBiz()
        {
            _ExceptedCustomerDb = new CampaignExceptedCustomerDb();
        }
        public CampaignExceptedCustomerBiz(DataRow objDr)
        {
            _ExceptedCustomerDb = new CampaignExceptedCustomerDb(objDr);
            _CustomerBiz = new CustomerBiz(objDr);
        }
        #endregion
        #region Public Properties
        public CampaignBiz CampaignBiz
        {
            set
            {
                _CampaignBiz = value;
            }
            get
            {
                if (_CampaignBiz == null)
                    _CampaignBiz = new CampaignBiz();

                return _CampaignBiz;
            }
        }
        public CustomerBiz CustomerBiz
        {
            set
            {
                _CustomerBiz = value;
            }
            get
            {
                if (_CustomerBiz == null)
                    _CustomerBiz = new CustomerBiz();
                return _CustomerBiz;
            }
        }
        public string Reason
        {
            set
            {
                _ExceptedCustomerDb.Reason = value;
            }
            get
            {
                return _ExceptedCustomerDb.Reason;
            }
        }
        public bool IsDateLimited
        {
            set
            {
                _ExceptedCustomerDb.IsDateLimited = value;
            }
            get
            {
                return _ExceptedCustomerDb.IsDateLimited;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _ExceptedCustomerDb.EndDate = value;
            }
            get
            {
                return _ExceptedCustomerDb.EndDate;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
