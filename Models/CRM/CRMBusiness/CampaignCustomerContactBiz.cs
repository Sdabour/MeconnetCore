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
    public enum ContactStatus
    {
        NotSpecified,
        Done,//may wait another contact
        WrongNo,
        NoAnswer,
        NoNumber,
        Created,
        PickedUp,
        Entered,
        Departed,
        Canceled,
        Transfered

    }
    public enum FunctionalContactStatus
    {
        NotSpecified,
        Done,
        Refused,
        EscalatedCase
    }
    public class CampaignCustomerContactBiz
    {
        #region Private Data
        protected CampaignCustomerContactDb _CampaignCustomerContactDb;
        protected EmployeeBiz _EmployeeBiz;
        protected EmployeeBiz _Receptionist;
        protected CampaignBiz _DirectCampaignBiz;
        protected TopicBiz _TopicBiz;
        protected CustomerBiz _DirectCustomerBiz;
        protected CampaignCustomerBiz _CampaignCustomerBiz;
        protected CampaignRuleBiz _RuleBiz;
        private ReservationBiz _ReservationBiz;

        public ReservationBiz ReservationBiz
        {
            get
            {
                if (_ReservationBiz == null)
                    _ReservationBiz = new ReservationBiz();
                return _ReservationBiz;
            }
            set { _ReservationBiz = value; }
        }
        CellBiz _ProjectBiz;

        public CellBiz ProjectBiz
        {
            get
            {
                if (_ProjectBiz == null)
                    _ProjectBiz = new CellBiz();
                return _ProjectBiz;
            }
            set { _ProjectBiz = value; }
        }
        WorkGroupBiz _GroupBiz;

        public WorkGroupBiz GroupBiz
        {
            get
            {
                if (_GroupBiz == null)
                    _GroupBiz = new WorkGroupBiz();
                return _GroupBiz;
            }
            set { _GroupBiz = value; }
        }

        #endregion
        #region Constructors
        public CampaignCustomerContactBiz()
        {
            _CampaignCustomerContactDb = new CampaignCustomerContactDb();
        }
        public CampaignCustomerContactBiz(DataRow objDr)
        {
            _CampaignCustomerContactDb = new CampaignCustomerContactDb(objDr);

            if (_CampaignCustomerContactDb.Employee != 0)
                _EmployeeBiz = new EmployeeBiz(objDr);
            if (_CampaignCustomerContactDb.ReceptionistID != 0)
            {
                _Receptionist = new EmployeeBiz();
                _Receptionist.ID = _CampaignCustomerContactDb.ReceptionistID;
                _Receptionist.Name = _CampaignCustomerContactDb.ReceptionistName;
            }
            _ReservationBiz = new ReservationBiz();
            if (_CampaignCustomerContactDb.Reservation != 0)
            {
                _ReservationBiz.ID = _CampaignCustomerContactDb.Reservation;
                _ReservationBiz.DirectCustomerStr = _CampaignCustomerContactDb.ReservationCustomerName;
                _ReservationBiz.DirectUnitCodeStr = _CampaignCustomerContactDb.ReservationUnitName;
            }
            if (_CampaignCustomerContactDb.DirectCustomerID != 0)
            {
                _DirectCustomerBiz = new CustomerBiz();
                _DirectCustomerBiz.ID = _CampaignCustomerContactDb.DirectCustomerID;
                _DirectCustomerBiz.NameA = _CampaignCustomerContactDb.DirectCustomerName;
                _DirectCustomerBiz.UnitFullName = _CampaignCustomerContactDb.DirectCustomerUnitName;
                _DirectCustomerBiz.TowerName = _CampaignCustomerContactDb.DirectCustomerTowerName;
                _DirectCustomerBiz.ProjectName = _CampaignCustomerContactDb.DirectCustomerProjectName;
                _DirectCustomerBiz.HomePhone = _CampaignCustomerContactDb.DirectCustomerPhone;
                _DirectCustomerBiz.Mobile = _CampaignCustomerContactDb.DirectCustomerMobile;
                _DirectCustomerBiz.Address = _CampaignCustomerContactDb.DirectCustomerAddress;

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

                _CampaignCustomerBiz.Customer = _DirectCustomerBiz;


                _CampaignCustomerBiz.Campaign = _DirectCampaignBiz;

                _CampaignCustomerBiz.Campaign.TopicBiz = _TopicBiz;

            }
            if (_CampaignCustomerContactDb.Branch != 0)
            {
                _BranchBiz = new UMSBranchBiz();
                _BranchBiz.ID = _CampaignCustomerContactDb.Branch;
                _BranchBiz.Name = _CampaignCustomerContactDb.BranchName;
            }
            if (_CampaignCustomerContactDb.Project != 0)
            {
                _ProjectBiz = new CellBiz();
                _ProjectBiz.ID = _CampaignCustomerContactDb.Project;
                _ProjectBiz.NameA = _CampaignCustomerContactDb.ProjectName;
            }
            _StatusBiz = new VisitStatusBiz(objDr);
            try
            {
                _VisitTypeBiz = new VisitTypeBiz(objDr);
            }
            catch { }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            get
            {
                return _CampaignCustomerContactDb.ID;
            }
        }
        public int CampaignCustomerID
        {

            get
            {
                return _CampaignCustomerContactDb.CampaignCustomerID;
            }
        }
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
                if (_CampaignCustomerContactDb.Type >= CampaignBiz.ContactTypeCol.Count)
                    return 0;
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
        VisitStatusBiz _StatusBiz;

        public VisitStatusBiz StatusBiz
        {
            get
            {
                if (_StatusBiz == null)
                    _StatusBiz = new VisitStatusBiz();
                return _StatusBiz;
            }
            set { _StatusBiz = value; }
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

        public bool WaitingMonitor
        {
            set
            {
                _CampaignCustomerContactDb.WaitingMonitor = value;
            }
            get
            {
                return _CampaignCustomerContactDb.WaitingMonitor;
            }
        }
        public DateTime WaitingMonitoringDate
        {
            set
            {
                _CampaignCustomerContactDb.WaitingMonitoringDate = value;
            }
            get
            {
                return _CampaignCustomerContactDb.WaitingMonitoringDate;
            }
        }
        public int LastMonitoringID
        {
            get { return _CampaignCustomerContactDb.LastMonitoringID; }
            set { _CampaignCustomerContactDb.LastMonitoringID = value; }
        }


        public DateTime LastMonitoringDate
        {
            get { return _CampaignCustomerContactDb.LastMonitoringDate; }
            set { _CampaignCustomerContactDb.LastMonitoringDate = value; }
        }


        public string LastMonitoringDesc
        {
            get { return _CampaignCustomerContactDb.LastMonitoringDesc; }
            set { _CampaignCustomerContactDb.LastMonitoringDesc = value; }
        }


        public int LastMonitoringStatus
        {
            get { return _CampaignCustomerContactDb.LastMonitoringStatus; }
            set { _CampaignCustomerContactDb.LastMonitoringStatus = value; }
        }


        public int LastMonitoringEmployee
        {
            get { return _CampaignCustomerContactDb.LastMonitoringEmployee; }
            set { _CampaignCustomerContactDb.LastMonitoringEmployee = value; }
        }


        public string LastMonitoringEmolyeeName
        {
            get { return _CampaignCustomerContactDb.LastMonitoringEmolyeeName; }
            set { _CampaignCustomerContactDb.LastMonitoringEmolyeeName = value; }
        }
        #region Reception
        public bool IsReception
        {
            set
            {
                _CampaignCustomerContactDb.IsReception = value;
            }
            get
            {
                return _CampaignCustomerContactDb.IsReception;
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
        UMSBranchBiz _BranchBiz;

        public UMSBranchBiz BranchBiz
        {
            get
            {
                if (_BranchBiz == null)
                    _BranchBiz = new UMSBranchBiz();
                return _BranchBiz;
            }
            set { _BranchBiz = value; }
        }
        public DateTime ReceptionDate
        {
            get
            {
                return _CampaignCustomerContactDb.ReceptionDate;
            }
        }

        public bool ReceptionProcessed
        {
            set
            {
                _CampaignCustomerContactDb.ReceptionProcessed = value;
            }
            get
            {
                return _CampaignCustomerContactDb.ReceptionProcessed;
            }
        }
        public bool IsPickedUp
        {
            set
            {
                _CampaignCustomerContactDb.IsPicked = value;
            }
            get
            {
                return _CampaignCustomerContactDb.IsPicked;
            }
        }
        public DateTime PickUpTime
        {
            set
            {
                _CampaignCustomerContactDb.ReceptionPickTime = value;
            }
            get
            {
                return _CampaignCustomerContactDb.ReceptionPickTime;
            }
        }
        public bool IsDeparted
        {
            set
            {
                _CampaignCustomerContactDb.IsDeparted = value;

            }
            get
            {
                return _CampaignCustomerContactDb.IsDeparted;
            }
        }
        public DateTime DepartureTime
        {
            set
            {
                _CampaignCustomerContactDb.DepartureTime = value;
            }
            get
            {
                return _CampaignCustomerContactDb.DepartureTime;
            }
        }

        #endregion
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
        public bool IsCanceled
        {
            set
            {
                _CampaignCustomerContactDb.IsCanceled = value;
            }
            get
            {
                return _CampaignCustomerContactDb.IsCanceled;

            }
        }
        public DateTime CancelTime
        {
            set
            {
                _CampaignCustomerContactDb.CancelTime = value;
            }
            get
            {
                return _CampaignCustomerContactDb.CancelTime;

            }


        }
        public bool IsEnetred
        {
            set
            {
                _CampaignCustomerContactDb.IsEntered = value;
            }
            get
            {
                return _CampaignCustomerContactDb.IsEntered;

            }
        }
        public DateTime EntryTime
        {
            set
            {
                _CampaignCustomerContactDb.EntryTime = value;
            }
            get
            {
                return _CampaignCustomerContactDb.EntryTime;

            }


        }
        public int Ticket
        {
            get { return _CampaignCustomerContactDb.Ticket; }
            set { _CampaignCustomerContactDb.Ticket = value; }
        }


        public string TicketWorkGroup
        {
            get { return _CampaignCustomerContactDb.TicketWorkGroupName; }
            set { _CampaignCustomerContactDb.TicketWorkGroupName = value; }
        }


        public string TicketEmployee
        {
            get { return _CampaignCustomerContactDb.TicketEmployeeName; }
            set { _CampaignCustomerContactDb.TicketEmployeeName = value; }
        }


        public TicketStatus TicketStatus
        {
            get { return (TicketStatus)_CampaignCustomerContactDb.TicketStatus; }
            set { _CampaignCustomerContactDb.TicketStatus = (int)value; }
        }
        public string TicketStatusStr
        {
            get
            {
                if (Ticket == 0)
                    return "";
                string Returned = TicketStatusBiz.StatusStrArr[(int)TicketStatus];

                return Returned;
            }
        }
        public DateTime TicketPostponementDate
        {
            get { return _CampaignCustomerContactDb.TicketPostponementDate; }
            set { _CampaignCustomerContactDb.TicketPostponementDate = value; }
        }


        public bool TicketIsPostponed
        {
            get { return _CampaignCustomerContactDb.TicketIsPostponed; }
            set { _CampaignCustomerContactDb.TicketIsPostponed = value; }
        }
        VisitTypeBiz _VisitTypeBiz;

        public VisitTypeBiz VisitTypeBiz
        {
            get
            {
                if (_VisitTypeBiz == null)
                {
                    _VisitTypeBiz = new VisitTypeBiz();// { ID = _CampaignCustomerContactDb .v};
                }
                return _VisitTypeBiz;
            }
            set { _VisitTypeBiz = value; }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                //if (Status == 2)
                //    Returned = "›‘· ›Ï «·« ’«·";
                //else if (Status == 1 && !WaitingAnotherContact)
                //    Returned = " „ «·« ’«·";
                //else if (Status == 1 && WaitingAnotherContact)
                //    Returned = "  „ «·« ’«· ÊÌ‰ Ÿ— « ’«· «Œ— » «—ÌŒ ("+  AnotherContactDate.ToString("yyyy-MM-dd")  +")";
                Returned = StatusLst[Status];
                if (Status == 1 && WaitingAnotherContact)
                    Returned += "(" + AnotherContactDate.ToString("yyyy-MM-dd") + ")";
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
                REturned.Add("ÃœÌœ");
                REturned.Add("PickedUp");
                REturned.Add("œŒÊ·");
                REturned.Add("„€«œ—…");// Departed,
                REturned.Add("«·€«¡");
                REturned.Add(" ÕÊÌ·");
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
        VisitStatusCol _StatusCol;
        public VisitStatusCol StatusCol
        {
            get
            {
                if (_StatusCol == null)
                {
                    _StatusCol = new VisitStatusCol(true);
                    if (ID != 0)
                    {
                        VisitStatusDb objDb = new VisitStatusDb();
                        VisitStatusBiz objBiz;
                        objDb.VisitID = ID;
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "StatusTimIns desc");
                        foreach (DataRow objDr in arrDr)
                        {
                            _StatusCol.Add(new VisitStatusBiz(objDr));

                        }
                    }

                }
                return _StatusCol;
            }
            set { _StatusCol = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
