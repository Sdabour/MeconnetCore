using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Text;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignRuleCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CampaignRuleCol(bool blIsEmpty)
        { 

        }
        #endregion
        #region Public Properties
        public CampaignRuleBiz this[int intIndex]
        {
            get
            {
                return (CampaignRuleBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignRuleBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("RuleID"),new DataColumn("RuleDayDiff"),
                new DataColumn("RuleCampaign"),new DataColumn("RuleDesc"),new DataColumn("RuleMsg"),new DataColumn("RulePeriodType")});
            DataRow objDr;
            foreach (CampaignRuleBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["RuleID"] = objBiz.ID;
                objDr["RuleDayDiff"] = objBiz.DayDiff;
                objDr["RuleCampaign"] = objBiz.CampaignBiz.ID;
                objDr["RuleDesc"] = objBiz.Desc;
                objDr["RuleMsg"] = objBiz.Msg;
                objDr["RulePeriodType"] = (int)objBiz.PeriodType;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
