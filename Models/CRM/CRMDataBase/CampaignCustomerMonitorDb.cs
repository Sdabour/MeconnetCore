using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.RP.RPDataBase;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignCustomerMonitorDb
    {
        #region Private Data
        int _ID;
        int _CampaignCustomer;
        DateTime _Date;
        string _Desc;
        int _Employee;
        int _Status;
        bool _WaitingAnotherMonitor;
        DateTime _AnotherMonitorDate;
        #endregion
        #region Constructors
        public CampaignCustomerMonitorDb()
        { }
        public CampaignCustomerMonitorDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int CampaignCustomer
        {
            set
            {
                _CampaignCustomer = value;
            }
            get
            {
                return _CampaignCustomer;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            
            }
            get
            {
                return _Desc;
            }
        }
        public int Employee
        {
            set
            {
                _Employee = value;
            }
            get
            {
                return _Employee;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public bool WaitingAnotherMonitor
        {
            set
            {
                _WaitingAnotherMonitor = value;
            }
            get
            {
                return _WaitingAnotherMonitor;

            }
        }
        public DateTime AnotherMonitorDate
        {
            set
            {
                _AnotherMonitorDate = value;
            }
            get 
            {
                return _AnotherMonitorDate;
            }
        }
        public string SearchStr
        {
            get
            {
                CampaignCustomerDb objCampaignCustomerDb = new CampaignCustomerDb();
                string Returned = "SELECT MonitoringID, MonitoringCampaignCustomer, MonitoringDate, MonitoringDesc"+
                    ", MonitoringEmployee,MonitoringStatus,MonitoringWaitingDate,EmployeeTable.*,CampaignCustomerTable.* " +
                    " FROM  dbo.CRMCampaignCustomerMonitor " +
                      " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable " +
                      " on dbo.CRMCampaignCustomerMonitor.MonitoringEmployee = EmployeeTable.ApplicantID"+
                      " inner join ("+ objCampaignCustomerDb.SearchStr +") as CampaignCustomerTable "+
                      " on dbo.CRMCampaignCustomerMonitor.MonitoringCampaignCustomer = CampaignCustomerTable.CampaignCustomerID " +
                      " where (1=1) ";
                if (_CampaignCustomer != 0)
                    Returned += " and MonitoringCampaignCustomer=" + _CampaignCustomer + " ";
                

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["MonitoringID"].ToString());
            _CampaignCustomer = int.Parse(objDr["MonitoringCampaignCustomer"].ToString());
            _Date = DateTime.Parse(objDr["MonitoringDate"].ToString());
            _Desc = objDr["MonitoringDesc"].ToString();
            _Status = int.Parse(objDr["MonitoringStatus"].ToString());
            if (objDr["MonitoringWaitingDate"].ToString() != "")
            {
                _WaitingAnotherMonitor = true;
                _AnotherMonitorDate = DateTime.Parse(objDr["MonitoringWaitingDate"].ToString());
            }
            else
                _WaitingAnotherMonitor = false;



            _Employee = int.Parse(objDr["MonitoringEmployee"].ToString());

        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr; 
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
