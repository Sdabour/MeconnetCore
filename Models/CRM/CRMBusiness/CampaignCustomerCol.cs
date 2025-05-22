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
    public class CampaignCustomerCol : BaseCol
    {
        DataTable _ReservationTable;

        public DataTable ReservationTable
        {
            get {
                if (_ReservationTable == null)
                {
                    CampaignCustomerReservationDb objDb = new CampaignCustomerReservationDb();
                    objDb.CampaignCustomerIDs = IDsStr;
                    _ReservationTable = objDb.Search();
                }
                return _ReservationTable; }
            set { _ReservationTable = value; }
        }
        
        public CampaignCustomerCol(bool blIsEmpty)
        {

        }
        public CampaignCustomerCol()
        {
        }
        public CampaignCustomerCol(CampaignBiz objCampaignBiz, int intContactStatus, int intEmployeeStatus,
            EmployeeBiz objEmployeeBiz,int intMonitorStatus,
            bool blIsMonitoringDate,DateTime dtStartMonitor,DateTime dtEndMonitor)
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
            objDb.MonitoringStatus = intMonitorStatus;
            objDb.IsMonitoringDate = blIsMonitoringDate;
            objDb.StartMonitorDate = dtStartMonitor;
            objDb.EndMonitorDate = dtEndMonitor;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CampaignCustomerBiz(objDr));
            }


        }
        Hashtable CustomerHash
        {
            get
            {
                Hashtable Returned = new Hashtable();
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    if(Returned[objBiz.Customer.ID.ToString()] == null)
                    {
                        Returned.Add(objBiz.Customer.ID.ToString(), objBiz);
                    }
                }
                return Returned;
            }
        }
        public virtual CampaignCustomerBiz this[int intIndex]
        {
            get
            {
                return (CampaignCustomerBiz)this.List[intIndex];
            }
        }
        public string CustomerIDs
        {
            get
            {
                string Returned = "";
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.Customer.ID.ToString();
                }
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                        continue;
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        
        public double NonContactedHasMobileNo
        {
            get
            {
                double Returned = 0;
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    if (!objBiz.IsContacted && objBiz.MobileFirstNo != "")
                        Returned++;
                }
                return Returned;
            }
        }
        public string PhoneNo
        {
            get
            {
                string Returned = "";
                string strNo = "";
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    strNo = objBiz.MobileFirstNo;
                    if (strNo == "" || strNo.Length < 11)
                        continue;
                    if(strNo.Length == 11)
                    strNo = "2"+objBiz.MobileFirstNo;
                    if (CampaignSMSBiz.CheckMsgNo(ref strNo))
                    {
                        if (Returned != "")
                            Returned += ",";
                        Returned += strNo;
                    }

                }
                return Returned;
            }
        }
        public double TotalDebt
        {
            get
            {
                double Returned = 0;
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    Returned += objBiz.Customer.Debt;
                }
                return Returned;
            }
        }
        public CampaignCol CampaignCol
        {
            get
            {
                CampaignCol Returned = new CampaignCol(true);
                Hashtable hsTemp = new Hashtable();
                foreach (CampaignCustomerBiz objBiz in this)
                {
                    if (hsTemp[objBiz.Campaign.ID.ToString()] != null)
                    {
                        ((CampaignBiz)hsTemp[objBiz.Campaign.ID.ToString()]).CustomerCol.Add(objBiz);
                    }
                    else
                    {
                        objBiz.Campaign.CustomerCol = new CampaignCustomerCol(true);
                        objBiz.Campaign.CustomerCol.Add(objBiz);
                        hsTemp.Add(objBiz.Campaign.ID.ToString(), objBiz.Campaign);
                        Returned.Add(objBiz.Campaign);
                    }
                }
                return Returned;
            }
        }
        void SetReservationData()
        {
            Hashtable hsTemp = CustomerHash;
            ReservationDb objReservationDb = new ReservationDb();
            string[] arrCustomerIDs;
            DataTable dtTemp = GetTable();
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "CustomerID", 200);
            CustomerBiz objCustomerBiz;
            CustomerDb objCustomerDb = new CustomerDb();
            string strTempUnit;
            foreach (string strTemp in arrStr)
            {
                objCustomerDb.CustomerIDs = strTemp;
                dtTemp = objCustomerDb.Search();
                arrCustomerIDs = strTemp.Split(new char[]{','} );
                foreach (string strCustomerID in arrCustomerIDs)
                {
                    objCustomerBiz = ((CampaignCustomerBiz)hsTemp[strCustomerID]).Customer;
                    strTempUnit = objCustomerBiz.ReservationCol.UnitFullName;
                    strTempUnit = objCustomerBiz.ReservationCol.UnitTowerName;
                }


            }
 
        }
        public static string GetProviderID(string strProviderID)
        {
           
            string Returned = strProviderID == null ? "" : strProviderID;
         
            int intIDIndex = Returned.IndexOf("id=");
            if (intIDIndex == -1)
                return "" ;
            int intEndIndex = Returned.IndexOf(" ", intIDIndex + 5);
            if (intEndIndex == -1)
                return "";
            Returned = Returned.Substring(intIDIndex, (intEndIndex - intIDIndex) + 1);
            Returned = strProviderID;
            return Returned;
        }
        
        public int GetIndex(CampaignCustomerBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].Customer.ID == objBiz.Customer.ID)
                    return intIndex;
            }
            return -1;
        }
        public int GetIndex(CustomerBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].Customer.ID == objBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        public virtual void Add(CampaignCustomerBiz objCampaignCustomerBiz)
        {
            if (GetIndex(objCampaignCustomerBiz) == -1)
                this.List.Add(objCampaignCustomerBiz);
        }
        public void ContactBySMS1()
        {
            CampaignSMSBiz objSmsBiz;
            string strError = "";
            foreach (CampaignCustomerBiz objBiz in this)
            {
                if (!objBiz.IsContacted)
                {
                    objSmsBiz = objBiz.GetNewSms();
                    if (objSmsBiz.Send(out strError))
                        objBiz.EditContactDate();

                }

            }
        }
        public CampaignSMSBiz GetNewSms()
        {
             CampaignSMSBiz Returned = new CampaignSMSBiz();
            string strMsg = "";
            if (Count > 0)
            {
                strMsg = this[0].Campaign.Msg;
                Returned.CampaignCustomer = this[0];
            }
               
                //Returned.CampaignCustomer = this;
           
                Returned.Msg = strMsg;
                Returned.PhoneNum = PhoneNo;
                //  Returned.PhoneNum = "01117073174";
            
            
            return Returned;


            //return Returned;
        }
        public CampaignCustomerCol GetNonContactedHasMobile(int intCount)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
            int intIndex = 0;

            foreach (CampaignCustomerBiz objBiz in this)
            {
                if (!objBiz.IsContacted && objBiz.MobileFirstNo != "" && (intCount == 0 || intIndex <= intCount))
                {
                    Returned.Add(objBiz);
                    intIndex++;
                }
                if (intCount > 0 && intIndex >= intCount)
                    break;
            }
            return Returned;
        }
        public CampaignCustomerCol GetNonContactedHasAddress(int intCount)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
            int intIndex = 0;

            foreach (CampaignCustomerBiz objBiz in this)
            {
                if (!objBiz.IsContacted && objBiz.Customer.Address!= null &&
                    objBiz.Customer.Address != "" && (intCount == 0 || intIndex <= intCount))
                {
                    Returned.Add(objBiz);
                    intIndex++;
                }
                if (intCount > 0 && intIndex >= intCount)
                    break;
            }
            return Returned;
        }
        public CampaignCustomerCol GetCampaignCustomerCol(string strCustomnerName,int intContactStatus)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
            foreach (CampaignCustomerBiz objBiz in this)
            {
                if (SysUtility.ReplaceStringComp(objBiz.Customer.Name).
                    IndexOf(SysUtility.ReplaceStringComp(strCustomnerName)) != -1)
                {
                    if (intContactStatus == 0 ||
                        (intContactStatus == 1 && objBiz.IsContacted) ||
                        (intContactStatus == 2 && !objBiz.IsContacted))
                        Returned.Add(objBiz);
                   
                }
            }
            return Returned;
        }
        public CampaignCustomerCol RemoveByCustomerID(int intCustomerID)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
          

            foreach (CampaignCustomerBiz objBiz in this)
            {
                if (objBiz.Customer.ID != intCustomerID)
                {
                    Returned.Add(objBiz);

                }
                else
                {
                    string strTemp = "";
                }
                
            }
            return Returned;
        }
        public void SetReservationCol()
        {
            SetReservationData();


        }
        public CustomerCol CustomerCol()
        {
            CustomerCol Returned = new CustomerCol(true);
            foreach (CampaignCustomerBiz objBiz in this)
            {
                Returned.Add(objBiz.Customer);
            }
            return Returned;
        }
        public void CancelContact(CampaignBiz objBiz)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.Campaign = objBiz.ID;
            objDb.CustomerIDs = CustomerIDs;
            objDb.IsContacted = false;
            objDb.EditContactDate();

            
        }
        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("CustomerID"), new DataColumn("CustomerFullname"), 
                new DataColumn("MobilePhone"), new DataColumn("ContactDate"),new DataColumn("Address"),
                new DataColumn("UnitName"),new DataColumn("Tower"),new DataColumn("Project"),new DataColumn("DateNo")  });
            DataRow objDr;
            foreach (CampaignCustomerBiz objBiz in this)
            {
                foreach (ReservationBiz objReservationBiz in objBiz.Customer.ReservationCol)
                {
                    foreach (ReservationUnitBiz objUnitBiz in objReservationBiz.UnitCol)
                    {
                        if (objBiz.Campaign.CellBiz.ID != 0 && objUnitBiz.UnitBiz.Project.ID != objBiz.Campaign.CellBiz.ID)
                            continue;
                        objDr = dtReturned.NewRow();
                        objDr["CustomerID"] = objBiz.Customer.ID;
                        objDr["CustomerFullname"] = objBiz.Customer.Name;
                        objDr["MobilePhone"] = objBiz.MobileFirstNo;
                        objDr["ContactDate"] = objBiz.IsContacted ? objBiz.ContactDate.ToString("dd-MM-yyyy") : "";
                        objDr["Address"] = objBiz.Customer.Address;
                        objDr["UnitName"] = objUnitBiz.UnitBiz.UnitStr;
                        objDr["Tower"] = objBiz.Customer.CurrentReservationCol.UnitTowerName;
                        objDr["Project"] = objBiz.Customer.CurrentReservationCol.UnitProjectName;
                        objDr["DateNo"] = objBiz.ContactDate.ToOADate();
                        dtReturned.Rows.Add(objDr);
                    }
                }
            }
            return dtReturned;
        }
        public void AssignToEmployee(EmployeeBiz objEmployeeBiz)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] {new DataColumn("Employee"),
                new DataColumn("CampaignCustomerID") });
            DataRow objDr;
            foreach (CampaignCustomerBiz objBiz in this)
            {
                objDr = dtTemp.NewRow();
                objDr["Employee"] = objEmployeeBiz.ID;
                objDr["CampaignCustomerID"] = objBiz.ID;
                dtTemp.Rows.Add(objDr);
            }
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.CampaignCustomerTable = dtTemp;
            objDb.AssignCampaignCustomerToEmployee();
        }
        public void SetContactStatus(int intStatus)
        {
            foreach (CampaignCustomerBiz objBiz in this)
            {
                objBiz.ContactStatus = intStatus;
            }
        }
        public void EditContactDate()
        {
           
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] {new DataColumn("ID"),new DataColumn("Type"),new DataColumn("Comment"),
                new DataColumn("Status"),new DataColumn("FunctionalStatus"),new DataColumn("WaitingAnotherContact"),new DataColumn("WaitingDate"),new DataColumn("Employee"),
                new DataColumn("WaitingMonitoring"),new DataColumn("MonitoringDate"),new DataColumn("ContactDirectCustomer"),
                new DataColumn("ContactCampaign"),new DataColumn("ContactTopic"),new DataColumn("ContactDirection"),new DataColumn("RuleID")
                 });

            DataRow objDr;
            foreach (CampaignCustomerBiz objBiz in this)
            {
                objDr = dtTemp.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["Type"] = objBiz.ContactType;
                objDr["Comment"] = objBiz.ContactComment;
                objDr["Status"] = objBiz.ContactStatus;
                objDr["FunctionalStatus"] = objBiz.FunctionalStatus;
                objDr["WaitingAnotherContact"] = objBiz.WaitingAnotherContact ? 1 : 0;
                objDr["WaitingDate"] = objBiz.AnotherContactDate;
                objDr["Employee"] = objBiz.EmployeeBiz.ID;
                objDr["WaitingMonitoring"] = objBiz.WaitingMonitor ? "1" : "0";
                objDr["MonitoringDate"] = objBiz.WaitingMonitorDate;
                objDr["ContactCampaign"] = objBiz.Campaign.ID;
                objDr["ContactDirectCustomer"] = objBiz.Customer.ID;
                objDr["ContactTopic"] = objBiz.TopicBiz.ID== 0? objBiz.Campaign.TopicBiz.ID : objBiz.TopicBiz.ID;
                objDr["ContactDirection"] = objBiz.Direction ? "1" : "0";
                objDr["ContactTopic"] = objBiz.TopicBiz.ID;
                objDr["RuleID"] = objBiz.RuleBiz.ID;
                dtTemp.Rows.Add(objDr);
            }
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.CampaignCustomerTable = dtTemp;
            objDb.EditContactDateCol();
        }
        public CampaignCustomerCol GetCampaignCustomerColForSms(int intStartIndex, int intCount,
            out List<int> arrIndex)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
            arrIndex = new List<int>();
            CampaignCustomerBiz objBiz = new CampaignCustomerBiz();
            string strPhoneNo = "";
            for (int intIndex = intStartIndex; intIndex < Count && arrIndex.Count < intCount;intIndex++)
            {
                objBiz = this[intIndex];
                

                    strPhoneNo = objBiz.MobileFirstNo;
                    if (CampaignSMSBiz.CheckMsgNo(ref strPhoneNo))
                    {

                        arrIndex.Add(intIndex);
                        Returned.Add(objBiz);
                    }

 
            }
            return Returned;
        }
        public bool ContactBySMS(out string strError)
        {
            strError = "";
            SetContactStatus(1);
            CampaignSMSBiz objSMSBiz = GetNewSms();
            string strProviderID = "";
            if (objSMSBiz.Send( out strError))
            {
                CampaignSMSDb objSMSDb = new CampaignSMSDb();
                objSMSDb.Msg = objSMSBiz.Msg;
                strProviderID = objSMSBiz.ProviderID;
                strProviderID = GetProviderID(strProviderID);
                strProviderID = objSMSBiz.ProviderID;
                objSMSDb.ProviderID = strProviderID;//objSMSBiz.ProviderID;
                objSMSDb.Campaign = objSMSBiz.CampaignCustomer.Campaign.ID;
                objSMSDb.CustomerCampaignIDs = IDsStr;
                objSMSDb.CustomerIDs = CustomerIDs;

                EditContactDate();
                objSMSDb.AddCampaignCustomerSMSCol();
              
               
                return true;
            }
            return false;
        }
        public bool ContactDirectCustomerBySMS()
        {
            SetContactStatus(1);
            CampaignSMSBiz objSMSBiz = GetNewSms();
            string strError = "";
            if (objSMSBiz.Send(out strError))
            {
                CampaignSMSDb objSMSDb = new CampaignSMSDb();
                string strProviderID = objSMSBiz.ProviderID;
                objSMSDb.Msg = objSMSBiz.Msg;
                strProviderID = GetProviderID(strProviderID);
                objSMSDb.ProviderID = strProviderID;
                objSMSDb.Campaign = objSMSBiz.CampaignCustomer.Campaign.ID;
                objSMSDb.CustomerCampaignIDs = IDsStr;
                objSMSDb.CustomerIDs = CustomerIDs;
                EditContactDate();
                objSMSDb.AddCampaignCustomerSMSCol();

                return true;
            }
            return false;
        }

        public void MonitorCol(EmployeeBiz objEmployeeBiz, int intSttaus,
           string strDesc, bool blWaitingMonitor, DateTime dtWaitingMonitorDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = IDsStr;
            objDb.MonitoringStatus = intSttaus;
            objDb.MonitoringDesc = strDesc;
            objDb.MonitoringEmployee = objEmployeeBiz.ID;
            objDb.WaitingMonitor = blWaitingMonitor;
            objDb.WaitingMonitoringDate = dtWaitingMonitorDate;


            objDb.MonitorCol();
        }

        public void EditWaitingMonitorDate(bool blWaiting, DateTime dtWaitingDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.IDs = IDsStr;
            objDb.WaitingMonitor = blWaiting;
            objDb.WaitingMonitoringDate = dtWaitingDate;
            objDb.EditMonitoringWaitingDateCol();
        }
        
    }

}

