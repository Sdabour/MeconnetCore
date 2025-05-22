
using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignCustomerContactSumCol : BaseCol
    {
        #region Private Data
        int _ResultCount;
        #endregion
        #region Constructors
        public CampaignCustomerContactSumCol(bool blIsEmpty)
        { 
        }
        public CampaignCustomerContactSumCol(CampaignBiz objCampaignBiz, CustomerBiz objCustomerBiz, bool blIsDateRange,
            DateTime dtStartDate, DateTime dtEndDate, TopicBiz objTopicBiz,EmployeeBiz objEmployeeBiz,
            int intStatus,int intFunctionalStatus,int intWaitingAnotherContact,int intLastContact,ContactType objContactType,
            int intDirectionStatus)
        {
            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            if (objCustomerBiz == null)
                objCustomerBiz = new CustomerBiz();
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();
            if (objTopicBiz == null)
                objTopicBiz = new TopicBiz();

            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            objDb.IsDateRange = blIsDateRange;
            objDb.StartDate = dtStartDate;
            objDb.EndDate = dtEndDate;
            objDb.CustomerID = objCustomerBiz.ID;
            objDb.CampaignID = objCampaignBiz.ID;
            objDb.Employee = objEmployeeBiz.ID;
            objDb.TopicIDs = objTopicBiz.IDsStr;
            objDb.Status = intStatus;
            objDb.FunctionalStatus = intFunctionalStatus;
            objDb.LastContactStatus = intLastContact;
            objDb.Type = (int)objContactType;
            objDb.DirectionStatus = intDirectionStatus;
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CampaignCustomerContactSumBiz(objDr));

            }

 
        }
        #endregion
        #region Public Properties
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public CampaignCustomerContactSumBiz this[int intIndex]
        {
            get
            {
                return (CampaignCustomerContactSumBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignCustomerContactSumBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
