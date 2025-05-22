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
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignCustomerMonitorCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CampaignCustomerMonitorCol()
        {
 
        }
        public CampaignCustomerMonitorCol(bool blIsEmpty)
        {
 
        }
        #endregion
        #region Public Properties
        public CampaignCustomerMonitorBiz this[int intIndex]
        {
            get
            {
                return (CampaignCustomerMonitorBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignCustomerMonitorBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
