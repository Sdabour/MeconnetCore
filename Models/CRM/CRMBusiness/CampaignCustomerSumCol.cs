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
    public class CampaignCustomerSumCol : BaseCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public CampaignCustomerSumCol(bool blIsEmpty)
        { 
        }
          public CampaignCustomerSumCol(CampaignBiz objCampaignBiz, int intContactStatus, int intEmployeeStatus,
            EmployeeBiz objEmployeeBiz,bool blIsCampaignGroup,bool blIsEmployeeGroup,bool blIsCustomerGroup)
        {
            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();

            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.Campaign = objCampaignBiz.ID;
            objDb.ContactStatus = intContactStatus;
            objDb.EmployeeStatus = intEmployeeStatus;
            objDb.Employee = objEmployeeBiz.ID;
            objDb.IsCustomerGroup = blIsCustomerGroup;
            objDb.IsEmployeeGroup = blIsEmployeeGroup;
            objDb.IsCampaignGroup = blIsCampaignGroup;

            DataTable dtTemp = objDb.SumSearch();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CampaignCustomerSumBiz(objDr));
            }


        }
        #endregion
        #region Public Properties
        public CampaignCustomerSumBiz this[int intIndex]
        {
            get
            {
                return (CampaignCustomerSumBiz)List[intIndex];
            }
        }
        public string CampaignCustomerIDs
        {
            get
            {
                string Returned = "";
                foreach (CampaignCustomerSumBiz objBiz in this)
                {
                    if (objBiz.CampaignCustomerID != 0)
                    {
                        if (Returned != "")
                            Returned += ",";
                        Returned += objBiz.CampaignCustomerID.ToString();
                        
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignCustomerSumBiz objBiz)
        {
            List.Add(objBiz);
        }
        public CampaignCustomerSumCol GetCustomerSumByName(string strName)
        {
            CampaignCustomerSumCol Returned = new CampaignCustomerSumCol(true);
            foreach (CampaignCustomerSumBiz objBiz in this)
            {
                if (objBiz.CustomerName != null && objBiz.CustomerName != "" &&
                    SysUtility.ReplaceStringComp(objBiz.CustomerName).IndexOf(SysUtility.ReplaceStringComp(strName)) != -1)
                    Returned.Add(objBiz);
                else if (objBiz.CustomerName == null || objBiz.CustomerName == "")
                    Returned.Add(objBiz);
               
            }
            return Returned;
        }
        public void MonitorCol( EmployeeBiz objEmployeeBiz, int intSttaus,
            string strDesc, bool blWaitingMonitor, DateTime dtWaitingMonitorDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = CampaignCustomerIDs;
            objDb.MonitoringStatus = intSttaus;
            objDb.MonitoringDesc = strDesc;
            objDb.MonitoringEmployee = objEmployeeBiz.ID;
            objDb.WaitingMonitor = blWaitingMonitor;
            objDb.WaitingMonitoringDate = dtWaitingMonitorDate;
           

            objDb.MonitorCol();
        }
        public void EditWaitingMonitorDate( bool blWaiting, DateTime dtWaitingDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = CampaignCustomerIDs;
            objDb.WaitingMonitor = blWaiting;
            objDb.WaitingMonitoringDate = dtWaitingDate;
            objDb.EditMonitoringWaitingDateCol();
        }
        public void JoinCampaignCustomer(EmployeeBiz objEmployeeBiz)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = CampaignCustomerIDs;
            objDb.Employee = objEmployeeBiz.ID;
            objDb.JoinCustomer();
        }
        public void JoinCampaignCustomer(CampaignBiz objCampaignBiz)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = CampaignCustomerIDs;
            objDb.Campaign = objCampaignBiz.ID;
            objDb.JoinCustomer();
        }
        public void StopCampaignCustomer()
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = CampaignCustomerIDs;

            objDb.StopCustomerContact();
        }
        #endregion
    }
}
