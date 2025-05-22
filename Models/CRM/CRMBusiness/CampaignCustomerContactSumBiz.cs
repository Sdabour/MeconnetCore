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
   
    public class CampaignCustomerContactSumBiz
    {
        #region Private Data
        CampaignCustomerContactDb _CampaignCustomerContactDb;
        EmployeeBiz _EmployeeBiz;
        CampaignBiz _DirectCampaignBiz;
        TopicBiz _TopicBiz;
        CustomerBiz _DirectCustomerBiz;
        CampaignCustomerBiz _CampaignCustomerBiz;
        #endregion
        #region Constructors
        public CampaignCustomerContactSumBiz()
        {
            _CampaignCustomerContactDb = new CampaignCustomerContactDb();
        }
        public CampaignCustomerContactSumBiz(DataRow objDr)
        {
            _CampaignCustomerContactDb = new CampaignCustomerContactDb(objDr);

            if (_CampaignCustomerContactDb.Employee != 0)
                _EmployeeBiz = new EmployeeBiz(objDr);
            if (_CampaignCustomerContactDb.DirectCustomerID != 0)
            {
                _DirectCustomerBiz = new CustomerBiz();
                _DirectCustomerBiz.ID = _CampaignCustomerContactDb.DirectCustomerID;
                _DirectCustomerBiz.NameA = _CampaignCustomerContactDb.DirectCustomerName;
            }
            if (_CampaignCustomerContactDb.DirectCampaignID != 0)
            {
                _DirectCampaignBiz = new CampaignBiz();
                _DirectCampaignBiz.ID = _CampaignCustomerContactDb.DirectCampaignID;
                _DirectCampaignBiz.Desc = _CampaignCustomerContactDb.DirectCampaignDesc;
                _DirectCampaignBiz.Date = _CampaignCustomerContactDb.DirectCmpaignDate;

            }
            if (_CampaignCustomerContactDb.TopicID != 0)
            {
                _TopicBiz = new TopicBiz();
                _TopicBiz.ID = _CampaignCustomerContactDb.TopicID;
                _TopicBiz.NameA = _CampaignCustomerContactDb.TopicName;
            }
            if (_CampaignCustomerContactDb.CampaignCustomerID != 0)
            {
                _CampaignCustomerBiz = new CampaignCustomerBiz();
                _CampaignCustomerBiz.ID = _CampaignCustomerContactDb.CampaignCustomerID;

                _CampaignCustomerBiz.Customer = new CustomerBiz();
                _CampaignCustomerBiz.Customer.ID = _CampaignCustomerContactDb.CustomerID;
                _CampaignCustomerBiz.Customer.NameA = _CampaignCustomerContactDb.CustomerName;

                _CampaignCustomerBiz.Campaign = new CampaignBiz();
                _CampaignCustomerBiz.Campaign.ID = _CampaignCustomerContactDb.CampaignID;
                _CampaignCustomerBiz.Campaign.Desc = _CampaignCustomerContactDb.CampaignDesc;
                _CampaignCustomerBiz.Campaign.Date = _CampaignCustomerContactDb.CampaignDate;

                _CampaignCustomerBiz.Campaign.TopicBiz = new TopicBiz();
                _CampaignCustomerBiz.Campaign.TopicBiz.ID = _CampaignCustomerContactDb.CampaignTopicID;
                _CampaignCustomerBiz.TopicBiz.NameA = _CampaignCustomerContactDb.CampaignTopicName;

            }
        }
        #endregion
        #region Public Properties
    
        public bool Direction
        {

            get
            {
                return _CampaignCustomerContactDb.Direction;
            }
        }
        public DateTime Date
        {
            get
            {
                return _CampaignCustomerContactDb.Date;
            }
        }
        public int Type
        {
            get
            {
                return _CampaignCustomerContactDb.Type;
            }
        }
        public string Comment
        {
            get
            {
                return _CampaignCustomerContactDb.Comment;
            }
        }
        public int Status
        {
            get
            {
                return _CampaignCustomerContactDb.Status;
            }
        }
        public int FunctionalStatus
        {
            get
            {
                return _CampaignCustomerContactDb.FunctionalStatus;
            }
        }
        public bool WaitingAnotherContact
        {
            get
            {
                return _CampaignCustomerContactDb.WaitingAnotherContact;
            }
        }
        public DateTime AnotherContactDate
        {

            get
            {
                return _CampaignCustomerContactDb.WaitingDate;
            }
        }
        public EmployeeBiz EmployeeBiz
        {
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
        }
        public CampaignBiz DirectCampaignBiz
        {
            set
            {
                _DirectCampaignBiz = value;
            }
            get
            {
                if (_DirectCampaignBiz == null)
                    _DirectCampaignBiz = new CampaignBiz();
                return _DirectCampaignBiz;
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
        public CustomerBiz DirectCustomerBiz
        {
            set
            {
                _DirectCustomerBiz = value;
            }
            get
            {
                if (_DirectCustomerBiz == null)
                    _DirectCustomerBiz = new CustomerBiz();
                return _DirectCustomerBiz;
            }
        }
        public CampaignCustomerBiz CampaignCustomerBiz
        {
            set
            {
                _CampaignCustomerBiz = value;
            }
            get
            {
                if (_CampaignCustomerBiz == null)
                    _CampaignCustomerBiz = new CampaignCustomerBiz();
                return _CampaignCustomerBiz;
            }
        }
        public int SMSMsgID
        {
            get
            {
                return _CampaignCustomerContactDb.SMSMsgID;
            }
        }
        public string SMSMsg
        {
            get
            {
                return _CampaignCustomerContactDb.SMSMsg;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                if (Status == 2)
                    Returned = "›‘· ›Ï «·« ’«·";
                else if (Status == 1 && !WaitingAnotherContact)
                    Returned = " „ «·« ’«·";
                else if (Status == 1 && WaitingAnotherContact)
                    Returned = "  „ «·« ’«· ÊÌ‰ Ÿ— « ’«· «Œ— » «—ÌŒ (" + AnotherContactDate.ToString("yyyy-MM-dd") + ")";
                return Returned;
            }
        }
        public string FunctionalStatusStr
        {
            get
            {
                return FunctionalStatusLst[FunctionalStatus];
            }
        }
        public CustomerBiz DisplayedCustomer
        {
            get
            {
                if (CampaignCustomerBiz.ID == 0)
                    return DirectCustomerBiz;
                else
                    return CampaignCustomerBiz.Customer;
            }
        }
        public CampaignBiz DisplayedCampaignBiz
        {
            get
            {
                if (CampaignCustomerBiz.ID == 0)
                    return DirectCampaignBiz;
                else
                    return CampaignCustomerBiz.Campaign;
            }
        }
        //public string ContactTypeStr
        //{
        //    get
        //    {

        //    }
        //}
        public static List<string> StatusLst
        {
            get
            {
                List<string> REturned = new List<string>();

                REturned.Add("€Ì— „Õœœ");

                REturned.Add(" „");

                REturned.Add("—ﬁ„ Œ«ÿ∆");

                REturned.Add("·« Ì” ÃÌ»");
                REturned.Add("·« ÌÊÃœ —ﬁ„");
                return REturned;
            }
        }
        public static List<string> FunctionalStatusLst
        {
            get
            {
                List<string> REturned = new List<string>();

                REturned.Add("€Ì— „Õœœ");

                REturned.Add(" „");

                REturned.Add("—›÷");

                REturned.Add(" ’⁄Ìœ");
                return REturned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
