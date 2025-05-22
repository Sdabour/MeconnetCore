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
    public class CampaignCustomerSumBiz
    {
        #region Private Data
        CampaignCustomerDb _CampaignCustomerDb;
        CampaignCustomerMonitorCol _MonitorCol;
        CampaignCustomerContactCol _ContactCol;
        #endregion
        #region Constructors
        public CampaignCustomerSumBiz()
        {
 
        }
        public CampaignCustomerSumBiz(DataRow objDr)
        {
            _CampaignCustomerDb = new CampaignCustomerDb(objDr);
        }
        #endregion
        #region Public Properties
        public int CampaignCustomerID
        {
            get
            {
                return _CampaignCustomerDb.ID;
            }
        }
        public string CampaignDesc
        {
            get
            {
                return _CampaignCustomerDb.CampaignDesc;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _CampaignCustomerDb.EmployeeName;
            }
        }
        public string CustomerName
        {
            get
            {
                return _CampaignCustomerDb.CustomerName;
            }
        }
        public int TotalCount
        {
            get
            {
                return _CampaignCustomerDb.TotalCount;
            }
        }
        public double SucceededContactCount
        {
            get
            {
                return _CampaignCustomerDb.SucceededContactCount;
            }
        }
        public CampaignCustomerMonitorCol MonitorCol
        {
            get
            {
                if (_MonitorCol == null)
                {
                    _MonitorCol = new CampaignCustomerMonitorCol(true);
                    if (CampaignCustomerID != 0)
                    {
                        CampaignCustomerMonitorDb objDb = new CampaignCustomerMonitorDb();
                        objDb.CampaignCustomer = CampaignCustomerID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _MonitorCol.Add(new CampaignCustomerMonitorBiz(objDr));
                        }
 
                    }
                }
                return _MonitorCol;
            }
        }
        public CampaignCustomerContactCol ContactCol
        {
            get
            {
                if (_ContactCol == null)
                {
                    _ContactCol = new CampaignCustomerContactCol(true);
                    if (CampaignCustomerID != 0)
                    {
                        CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
                        objDb.CampaignCustomerID = CampaignCustomerID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ContactCol.Add(new CampaignCustomerContactBiz(objDr));
                        }
                    }

                }
                return _ContactCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
