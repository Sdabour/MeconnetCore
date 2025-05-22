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
    public class CampaignCustomerBiz
    {
        #region Private Data
        CampaignCustomerDb _CampaignCustomerDb;
        CampaignBiz _Campaign;
        CustomerBiz _Customer;
        SharpVision.COMMON.COMMONBusiness.ContactBiz _Contact;
        CampaignSMSBiz _NewSmsBiz;
        EmployeeBiz _EmployeeBiz;
        EmployeeBiz _LastContactEmployeeBiz;
        CampaignCustomerContactCol _ContactCol;
        CampaignCustomerContactCol _AllContactCol;
        CampaignCustomerMonitorCol _MonitorCol;
        TopicBiz _TopicBiz;
        bool _Direction = false;
        CampaignRuleBiz _RuleBiz;
        EmployeeBiz _Receptionist;
        #endregion  
        #region Constructors
        public CampaignCustomerBiz()
        {
            _CampaignCustomerDb = new CampaignCustomerDb();
        }
        public CampaignCustomerBiz(int intID)
        {
            _CampaignCustomerDb = new CampaignCustomerDb(intID);
        }
        public CampaignCustomerBiz(DataRow objDR)
        {
            _CampaignCustomerDb = new CampaignCustomerDb(objDR);
            _Campaign = new CampaignBiz();
            _Campaign.ID = _CampaignCustomerDb.Campaign;
            _Campaign.Desc = _CampaignCustomerDb.CampaignDesc;
            _Campaign.Date = _CampaignCustomerDb.CampaignDate;
            _Customer = new CustomerBiz(objDR);
            //_Customer.ID = _CampaignCustomerDb.Customer;
            //_Customer.NameA = _CampaignCustomerDb.CustomerName;
            //_Customer.Mobile = _CampaignCustomerDb.CustomerMobile;
            //_Customer.HomePhone = _CampaignCustomerDb.CustomerHomePhone;
            //_Customer.ID = _CampaignCustomerDb.Customer;
            //_Customer.NameA = _CampaignCustomerDb.CustomerName;
            _LastContactEmployeeBiz = new EmployeeBiz();
            _LastContactEmployeeBiz.ID = _CampaignCustomerDb.ContactEmployee;
            _LastContactEmployeeBiz.Name = _CampaignCustomerDb.ContactEmployeeName;
            _LastContactEmployeeBiz.Code = _CampaignCustomerDb.ContactEmployeeCode;
            _EmployeeBiz = new EmployeeBiz();
            if (_CampaignCustomerDb.Employee != 0)
                _EmployeeBiz = new EmployeeBiz(objDR);

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _CampaignCustomerDb.ID = value;
            }
            get
            {
                return _CampaignCustomerDb.ID;
            }
        }
        public CampaignBiz Campaign
        {
            set
            {
                _Campaign = value;
            }
            get
            {
                if (_Campaign == null)
                    _Campaign = new CampaignBiz();
                return _Campaign;
            }
        }
        public CustomerBiz Customer
        {
            set
            {
                _Customer = value;
            }
            get
            {
                if (_Customer == null)
                    _Customer = new CustomerBiz();
                return _Customer;
            }
        }
        public SharpVision.COMMON.COMMONBusiness.ContactBiz Contact
        {
            set
            {
                _Contact = value;
            }
            get
            {
                return _Contact;
            }
        }
        public bool IsContacted
        {
            set
            {
                _CampaignCustomerDb.IsContacted = value;
            }
            get
            {
                return _CampaignCustomerDb.IsContacted;
            }
        }
        public DateTime ContactDate
        {
            set
            {
                _CampaignCustomerDb.ContactDate = value;
            }
            get
            {
                return _CampaignCustomerDb.ContactDate;
            }
        }
        public string ContactComment
        {
            set
            {
                _CampaignCustomerDb.ContactComment = value;
            }
            get
            {
                return _CampaignCustomerDb.ContactComment;
            }
        }
        public CampaignRuleBiz RuleBiz
        {
            set
            {
                _RuleBiz = value;
            }
            get
            {
                if (_RuleBiz == null)
                    _RuleBiz = new CampaignRuleBiz();
                return _RuleBiz;
            }
        }
        public string MobileFirstNo
        {
            get
            {
                string Returned = "";
                if (false && Customer.Mobile == "")
                {
                    //ContactInstantCol objCol = Customer.CustomerContactCol.GetInstantCol(2);

                    //if (objCol.Count > 0)
                    //{
                    //    Returned = objCol[0].ContactValue;
                    //}
                }
                else
                    Returned = Customer.Mobile;
                return Returned;


            }
        }
        public int ContactStatus
        {
            set
            {
                _CampaignCustomerDb.ContactStatus = value;
            }
            get
            {
                return _CampaignCustomerDb.ContactStatus;
            }
        }
        public int FunctionalStatus
        {
            set
            {
                _CampaignCustomerDb.FunctionalStatus = value;
            }
            get 
            {
                return _CampaignCustomerDb.FunctionalStatus;
            }
        }
        public bool WaitingAnotherContact
        {
            set
            {
                _CampaignCustomerDb.WaitingAnotherContact = value;
            }
            get
            {
                return _CampaignCustomerDb.WaitingAnotherContact;
            }
        }

        public DateTime AnotherContactDate
        {
            set
            {
                _CampaignCustomerDb.AnotherContactDate = value;
            }
            get
            {
                return _CampaignCustomerDb.AnotherContactDate;
            }
        }
        public EmployeeBiz LastContactEmployeeBiz
        {
            set
            {
                _LastContactEmployeeBiz = value;
            }
            get
            {
                if (_LastContactEmployeeBiz == null)
                    _LastContactEmployeeBiz = new EmployeeBiz();
                return _LastContactEmployeeBiz;
            }
        }
        public int ContactType
        {
            set
            {
                _CampaignCustomerDb.Contact = value;
            }
            get
            {
                return _CampaignCustomerDb.Contact;
            }
        }
        public bool Direction
        {
            set
            {
                _CampaignCustomerDb.Direction = value;
                _Direction = value;
            }
            get
            {
                return _Direction; 
            }
        }
        public TopicBiz TopicBiz
        {
            set
            {
                _TopicBiz = value;
            }
            get
            {
                if (_TopicBiz == null)
                    _TopicBiz = new TopicBiz();
                return _TopicBiz;
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
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
        }
        public CampaignCustomerContactCol ContactCol
        {
            get
            {
                if (_ContactCol == null)
                {
                    _ContactCol = new CampaignCustomerContactCol(true);
                    if (ID != 0)
                    {
                        CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
                        objDb.CampaignCustomerID = ID;
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
        public CampaignCustomerContactCol AllContactCol
        {
            get
            {
                if (_AllContactCol == null)
                {
                    _AllContactCol = new CampaignCustomerContactCol(true);
                    if (Customer.ID != 0)
                    {
                        CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
                       // objDb.CampaignCustomerID = ID;
                        objDb.CustomerID = Customer.ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AllContactCol.Add(new CampaignCustomerContactBiz(objDr));
                        }
                    }
                }
                return _AllContactCol;
            }
        }
        public CampaignCustomerMonitorCol MonitorCol
        {
            get
            {
                if (_MonitorCol == null)
                {
                    _MonitorCol = new CampaignCustomerMonitorCol(true);
                    if (ID != 0)
                    {
                        CampaignCustomerMonitorDb objDb = new CampaignCustomerMonitorDb();
                        objDb.CampaignCustomer = ID;
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
        public int ContactCount
        {
            get
            {
                return _CampaignCustomerDb.ContactCount;
            }
        }
        public int SucceededContactCount
        {
            get
            {
                return _CampaignCustomerDb.SucceededContactCount;
            }
        }
        public bool WaitingMonitor
        {
            set
            {
                _CampaignCustomerDb.WaitingMonitor = value;
            }
            get
            {
                return _CampaignCustomerDb.WaitingMonitor;
            }
        }
        public DateTime WaitingMonitorDate
        {
            set
            {
                _CampaignCustomerDb.WaitingMonitoringDate = value;
            }
            get
            {
                return _CampaignCustomerDb.WaitingMonitoringDate;
            }
        }
        #region Reception
        public bool IsReception
        {
            set
            {
                _CampaignCustomerDb.IsReception = value;
            }
            get
            {
                return _CampaignCustomerDb.IsReception;
            }
        }

        public EmployeeBiz Receptionist
        {
            set
            {
                _Receptionist = value;
            }
            get
            {
                if (_Receptionist == null)
                    _Receptionist = new EmployeeBiz();
                return _Receptionist;
            }
        }
        public DateTime ReceptionDate
        {
            get
            {
                return _CampaignCustomerDb.ReceptionDate;
            }
        }

        public bool ReceptionProcessed
        {
            set
            {
                _CampaignCustomerDb.ReceptionProcessed = value;
            }
            get
            {
                return _CampaignCustomerDb.ReceptionProcessed;
            }
        }
        #endregion
        #endregion
        #region Private Methods
        string GetMsg()
        {
            string Returned = _Campaign.Msg;
            
            string strTemp = "";
            string strProperty = "";
            for (int intIndex = 0; intIndex < ReservationContractTemplateBiz.LstKeys.Count; intIndex++)
            {
               
                strTemp = ReservationContractTemplateBiz.LstKeys[intIndex];
                strProperty = ReservationContractTemplateBiz.GetPropertyStr(
                                intIndex, Customer);
                Returned = Returned.Replace(strTemp, strProperty);


            }
            return Returned;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _CampaignCustomerDb.Customer = Customer.ID;
            _CampaignCustomerDb.Contact = Contact.ID;
            _CampaignCustomerDb.Campaign = Campaign.ID;
            _CampaignCustomerDb.Add();
        }
        public void Edit()
        {
            _CampaignCustomerDb.Customer = Customer.ID;
            _CampaignCustomerDb.Contact = Contact.ID;
            _CampaignCustomerDb.Campaign = Campaign.ID;
            _CampaignCustomerDb.Edit();
        }
        public void Delete()
        {
            _CampaignCustomerDb.Delete();
        }
        public CampaignSMSBiz GetNewSms()
        {
            if (_NewSmsBiz == null)
            {
                CampaignSMSBiz Returned = new CampaignSMSBiz();
                Returned.CampaignCustomer = this;
                Returned.Msg = GetMsg();
                Returned.PhoneNum = MobileFirstNo;
              //  Returned.PhoneNum = "01117073174";
                _NewSmsBiz = Returned;
            }
            return _NewSmsBiz;
           

            //return Returned;
        }
        public void EditContactDate()
        {
            _CampaignCustomerDb.Campaign = Campaign.ID;
            _CampaignCustomerDb.ContactDate = DateTime.Now;
            _CampaignCustomerDb.IsContacted = true;
            //_CampaignCustomerDb.ContactStatus = 1;
            _CampaignCustomerDb.ContactEmployee = EmployeeBiz.ID;
            _CampaignCustomerDb.Customer = Customer.ID;
            _CampaignCustomerDb.TopicID = TopicBiz.ID;
            _CampaignCustomerDb.EditContactDate();
        }
        public void CancelContact()
        {
            _CampaignCustomerDb.Campaign = Campaign.ID;
            //_CampaignCustomerDb.ContactDate = DateTime.Now;
            _CampaignCustomerDb.IsContacted = false;
            _CampaignCustomerDb.EditContactDate();
        }
       
        public bool ContactBySMS(out string strError)
        {
            CampaignSMSBiz objSmsBiz = GetNewSms();
            //string strError = "";

            if (objSmsBiz.Send(out strError))
            {
                ContactStatus = 1;
                objSmsBiz.ProviderID = CampaignCustomerCol.GetProviderID(objSmsBiz.ProviderID);
                EditContactDate();
                objSmsBiz.Add();
                return true;
            }
            else
                return false;

        }
        #endregion
    }
}
