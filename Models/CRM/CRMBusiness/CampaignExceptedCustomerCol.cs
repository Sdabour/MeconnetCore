using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using System.Text;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignExceptedCustomerCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CampaignExceptedCustomerCol(bool blIsEmpty)
        {
 
        }

        #endregion
        #region Public Properties
        public CampaignExceptedCustomerBiz this[int intIndex]
        {
            get
            {
                return (CampaignExceptedCustomerBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignExceptedCustomerBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("Campaign"),new DataColumn("Customer"),
                new DataColumn("ExceptionReason"),new DataColumn("ExceptionEndDate")});
            DataRow objDr;
            foreach (CampaignExceptedCustomerBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["Campaign"] = objBiz.CampaignBiz.ID;
                objDr["Customer"] = objBiz.CustomerBiz.ID;
                objDr["ExceptionReason"] = objBiz.Reason;
                objDr["ExceptionEndDate"] = objBiz.IsDateLimited ? objBiz.EndDate.ToString() : "";

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CampaignExceptedCustomerCol GetCol(string strCustomerName)
        {
            CampaignExceptedCustomerCol Returned = new CampaignExceptedCustomerCol(true);
            foreach (CampaignExceptedCustomerBiz objBiz in this)
            {
                if (SysUtility.ReplaceStringComp(objBiz.CustomerBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strCustomerName)) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion
    }
}
