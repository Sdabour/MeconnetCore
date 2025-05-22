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
    public enum RulePeriodType
    {
        Descrete,
        Continuous
    }
    public class CampaignRuleBiz
    {
        #region Private Data
        CampaignRuleDb _RuleDb;
        CampaignBiz _CampaignBiz;
        CampaignCustomerCol _CustomerCol;
        #endregion
        #region Constructors
        public CampaignRuleBiz()
        {
            _RuleDb = new CampaignRuleDb();
 
        }
        public CampaignRuleBiz(DataRow objDr)
        {
            _RuleDb = new CampaignRuleDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _RuleDb.ID = value;
            }
            get
            {
                return _RuleDb.ID;
            }
        }
        public int Campaign
        {
            set
            {
                _RuleDb.Campaign = value;
            }
            get
            {
                return _RuleDb.Campaign;
            }
        }
        public int DayDiff
        {
            set
            {
                _RuleDb.DayDiff = value;
            }
            get
            {
                return _RuleDb.DayDiff;
            }
        }
        public string Desc
        {
            set
            {
                _RuleDb.Desc = value;
            }
            get
            {
                return _RuleDb.Desc;
            }
        }
        public string Msg
        {
            set
            {
                _RuleDb.Msg = value;
            }
            get
            {
                return _RuleDb.Msg;
            }
        }
        public RulePeriodType PeriodType
        {
            set
            {
                _RuleDb.PeriodType = (int)value;
            }
            get
            {
                return (RulePeriodType)_RuleDb.PeriodType;
            }
        }
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
        public CampaignCustomerCol CustomerCol
        {
            set
            {
                _CustomerCol = value;
            }
            get
            {
                if (_CustomerCol == null)
                    _CustomerCol = new CampaignCustomerCol(true);
                return _CustomerCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _RuleDb.Campaign = CampaignBiz.ID;
            _RuleDb.Add();
        }
        public void Edit()
        {
            _RuleDb.Campaign = CampaignBiz.ID;
            _RuleDb.Edit();
        }
        public void Delete()
        {
            _RuleDb.Delete();
        }
        #endregion
    }
}
