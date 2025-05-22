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
    public class CampaignCustomerContactCol : BaseCol
    {
        #region Private Data
        int _ResultCount;
        #endregion
        #region Constructors
        public CampaignCustomerContactCol(bool blIsEmpty)
        {
        }
        public CampaignCustomerContactCol(CampaignBiz objCampaignBiz, CustomerBiz objCustomerBiz, bool blIsDateRange,
            DateTime dtStartDate, DateTime dtEndDate, TopicBiz objTopicBiz, EmployeeBiz objEmployeeBiz,
            int intStatus, int intFunctionalStatus, int intWaitingAnotherContact, int intLastContact, ContactType objContactType,
            int intDirectionStatus, int intWaitingMonitorStatus,
            int intWaitingMonitoringDateStatus, DateTime dtMonitorStart, DateTime dtMonitorEnd)
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
            if (objContactType == ContactType.CustomerVisit)
                objDb.ReceptionStatus = 1;
            objDb.DirectionStatus = intDirectionStatus;
            objDb.WaitingMonitoringStatus = intWaitingMonitorStatus;
            objDb.WaitingMonitoringDateStatus = intWaitingMonitoringDateStatus;
            objDb.MonitorDateStart = dtMonitorStart;
            objDb.MonitorDateEnd = dtMonitorEnd;
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CampaignCustomerContactBiz(objDr));

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
        public CampaignCustomerContactBiz this[int intIndex]
        {
            get
            {
                return (CampaignCustomerContactBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CampaignCustomerContactBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CampaignCustomerContactBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Name"),
                new DataColumn("Date"),new DataColumn("Type"),
                new DataColumn("Campaign"),new DataColumn("Direction"),new DataColumn("Sms"),
                new DataColumn("Employee"),new DataColumn("Comment"),new DataColumn("Status"),
                new DataColumn("Mobile"),new DataColumn("Address"),new DataColumn("UnitName"),
                new DataColumn("Tower"),new DataColumn("Project")});
            DataRow objDr;
            foreach (CampaignCustomerContactBiz objBiz in this)
            {
                objDr = Returned.NewRow();

                objDr["Name"] = objBiz.DisplayedCustomer.Name;
                objDr["Date"] = objBiz.Date.ToString("yyyy-MM-dd");

                objDr["Type"] = CampaignBiz.ContactTypeCol[objBiz.Type];
                objDr["Campaign"] = objBiz.DisplayedCampaignBiz.Desc;
                objDr["Direction"] = objBiz.Direction ? "ַבל" : "דה";
                objDr["Sms"] = objBiz.SMSMsg;
                objDr["Employee"] = objBiz.EmployeeBiz.Name;
                objDr["Status"] = objBiz.StatusStr;
                objDr["Comment"] = objBiz.Comment;
                objDr["Mobile"] = objBiz.DirectCustomerBiz.Mobile;
                objDr["Address"] = objBiz.DirectCustomerBiz.Address;
                objDr["UnitName"] = objBiz.DirectCustomerBiz.UnitFullName;
                objDr["Tower"] = objBiz.DirectCustomerBiz.TowerName;
                objDr["Project"] = objBiz.DirectCustomerBiz.ProjectName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CampaignCustomerContactCol GetMsgCol()
        {
            CampaignCustomerContactCol Returned = new CampaignCustomerContactCol(true);
            foreach (CampaignCustomerContactBiz objBiz in this)
            {
                if (objBiz.SMSMsgID != 0)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public void MonitorCol(EmployeeBiz objEmployeeBiz, int intSttaus,
          string strDesc, bool blWaitingMonitor, DateTime dtWaitingMonitorDate)
        {
            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            objDb.IDs = IDsStr;
            objDb.MonitoringStatus = intSttaus;
            objDb.MonitoringDesc = strDesc;
            objDb.Employee = objEmployeeBiz.ID;
            objDb.WaitingMonitor = blWaitingMonitor;
            objDb.WaitingMonitoringDate = dtWaitingMonitorDate;


            objDb.MonitorCol();
        }
        public void EditWaitingMonitorDate(bool blWaiting, DateTime dtWaitingDate)
        {
            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            objDb.IDs = IDsStr;
            objDb.WaitingMonitor = blWaiting;
            objDb.WaitingMonitoringDate = dtWaitingDate;
            objDb.EditMonitoringWaitingDateCol();
        }
        public TicketCol GetTicketCol(bool blParent)
        {
            string strTicket = "";
            foreach (CampaignCustomerContactBiz objContactBiz in this)
            {
                if (objContactBiz.Ticket != 0)
                {
                    if (strTicket != "")
                        strTicket += ",";
                    strTicket += objContactBiz.Ticket.ToString();
                }
            }
            TicketCol Returned = new TicketCol(true);
            if (strTicket != "")
            {
                TicketDb objDb = new TicketDb();
                if (blParent)
                    objDb.ParentIDs = strTicket;
                else
                    objDb.IDs = strTicket;
                DataTable dtTemp = objDb.Search();
                DataRow[] arrDr = dtTemp.Select("", "MainTicket,TicketDate");
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new TicketBiz(objDr));
                }
            }
            return Returned;
        }
        public void SetStatusCol()
        {
            VisitStatusDb objDb = new VisitStatusDb();
            VisitStatusBiz objBiz;
            objDb.VisitIDs = IDsStr;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;// dtTemp.Select("", "StatusTimIns desc");
            foreach (CampaignCustomerContactBiz objContactBiz in this)
            {
                objContactBiz.StatusCol = new VisitStatusCol(true);
                arrDr = dtTemp.Select("VisitStatusVisitID=" + objContactBiz.ID, "StatusTimIns desc");
                foreach (DataRow objDr in arrDr)
                {
                    objContactBiz.StatusCol.Add(new VisitStatusBiz(objDr));

                }
            }
        }
        #endregion
    }
}
