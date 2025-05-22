using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignCustomerMonitorBiz
    {
        #region Private Data
        CampaignCustomerMonitorDb _MonitorDb;
        EmployeeBiz _EmployeeBiz;
        #endregion
        #region Constructors
        public CampaignCustomerMonitorBiz()
        {
            _MonitorDb = new CampaignCustomerMonitorDb();
            _EmployeeBiz = new EmployeeBiz();
        }
        public CampaignCustomerMonitorBiz(DataRow objDr)
        {
            _MonitorDb = new CampaignCustomerMonitorDb(objDr);
            if (_MonitorDb.Employee != 0)
                _EmployeeBiz = new EmployeeBiz(objDr);
            else
                _EmployeeBiz = new EmployeeBiz();
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _MonitorDb.ID = value;
            }
            get
            {
                return _MonitorDb.ID;
            }
        }
        public int CampaignCustomer
        {
            set
            {
                _MonitorDb.CampaignCustomer = value;
            }
            get
            {
                return _MonitorDb.CampaignCustomer;
            }
        }
        public DateTime Date
        {
            set
            {
                _MonitorDb.Date = value;
            }
            get
            {
                return _MonitorDb.Date;
            }
        }
        public string Desc
        {
            set
            {
                _MonitorDb.Desc = value;

            }
            get
            {
                return _MonitorDb.Desc;
            }
        }
        public int Status
        {
            set
            {
                _MonitorDb.Status = value;
            }
            get 
            {
                return _MonitorDb.Status;
            }
        }
        public EmployeeBiz EmployeeBiz
        {
            set
            {
                _EmployeeBiz = value;
            }
            get
            {
                return _EmployeeBiz;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "€Ì— „Õœœ";
                if (Status == 1)
                    Returned = " „";
                else if (Status == 2)
                    Returned = "≈Œ›«ﬁ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
