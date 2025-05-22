using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.UMS.UMSBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public enum VisitType
    {
        NotSpecified, // ÛíÑ ãÍÏÏ
        ContactByPhone, // ÇáÊæÇÕá ÈÇáÊáíÝæä
        PersoneVisit // ÇáÒíÇÑå ááÝÑÚ
    }

    public enum VisitResult
    {
        NotSpecified, // ÛíÑ ãÍÏÏ
        Cancel, // ÛíÑ ãåÊã
        Reservation,// Êã ÇáÍÌÒ
        FollowUp,
        CancelAfterFollowUp,
        ReservationAfterFollowUp
    }
    public enum VisitStatus
    {
        NotSpecified, //0 ÛíÑ ãÍÏÏ
        Created,// Êã Úãá ÇáÊíßÊ 1
        Processing,//íÊã ãÚÇáÌÉ ÇáÊíßÊ 2
        Waiting,// ÇáÊíßÊ ÊäÊÙÑ ÇáãÚÇáÌÉ 3
        Canceled,//4 Êã ÇáÛÇÁ ÇáÊíßÊ 
        Ended//Êã ÇáÇäÊåÇÁ 5

    }




    public class VisitBiz
    {
        #region Private Data
        VisitBiz _VisitBiz;
        CampaignCustomerContactDb _VisitDb;

        #endregion

        #region Public Constractors

        public VisitBiz(DataRow objDR)
        {
            _VisitDb = new CampaignCustomerContactDb(objDR);

            _StatusBiz = new VisitStatusBiz(objDR);
            _ReservationBiz = new ReservationBiz();
            if (_VisitDb.Reservation != 0)
            {
                _ReservationBiz.ID = _VisitDb.Reservation;
                _ReservationBiz.DirectCustomerStr = _VisitDb.ReservationCustomerName;
                _ReservationBiz.DirectUnitCodeStr = _VisitDb.ReservationUnitName;
            }
            if (_VisitDb.DirectCustomerID != 0)
            {
                _CustomerBiz = new CustomerBiz();
                _CustomerBiz.ID = _VisitDb.DirectCustomerID;
                _CustomerBiz.NameA = _VisitDb.DirectCustomerName;
                _CustomerBiz.UnitFullName = _VisitDb.DirectCustomerUnitName;
                _CustomerBiz.TowerName = _VisitDb.DirectCustomerTowerName;
                _CustomerBiz.ProjectName = _VisitDb.DirectCustomerProjectName;
                _CustomerBiz.HomePhone = _VisitDb.DirectCustomerPhone;
                _CustomerBiz.Mobile = _VisitDb.DirectCustomerMobile;
                _CustomerBiz.Address = _VisitDb.DirectCustomerAddress;

            }
            _GroupBiz = new WorkGroupBiz();
            if (_VisitDb.WorkGroup != 0)
            {
                _GroupBiz.ID = _VisitDb.WorkGroup;
                _GroupBiz.NameA = _VisitDb.WorkGroupName;
            }
            _AssignedEmployeeBiz = new EmployeeBiz();
            if (_VisitDb.Employee != 0)
            {
                try
                {
                    _AssignedEmployeeBiz = new EmployeeBiz(objDR);
                }
                catch { }

            }
            _EmployeeBiz = new EmployeeBiz();
            if (_VisitDb.ReceptionistID != 0)
            {
                _EmployeeBiz.ID = _VisitDb.ReceptionistID;
                _EmployeeBiz.Name = _VisitDb.ReceptionistName;
            }
            if (_VisitDb.Branch != 0)
            {
                _BranchBiz = new UMSBranchBiz();
                _BranchBiz.ID = _VisitDb.Branch;
                _BranchBiz.Name = _VisitDb.BranchName;
            }
            if (_VisitDb.Project != 0)
            {
                _ProjectBiz = new CellBiz();
                _ProjectBiz.ID = _VisitDb.Project;
                _ProjectBiz.NameA = _VisitDb.ProjectName;
            }
            _TypeBiz = new VisitTypeBiz();
            if (_VisitDb.VisitType != 0)
                _TypeBiz = new VisitTypeBiz(objDR);

            if (_VisitDb.Ticket != 0)
            {
                _TicketBiz = new TicketBiz()
                {
                    ID = _VisitDb.Ticket,
                    Desc = _VisitDb.TicketDesc
                ,
                    AssignedEmployeeBiz = new EmployeeBiz() { ID = _VisitDb.TicketEmployee, Name = _VisitDb.TicketEmployeeName }
                ,
                    GroupBiz = new WorkGroupBiz() { ID = _VisitDb.TicketWorkGroup, NameA = _VisitDb.TicketWorkGroupName }
                ,
                    Status = (TicketStatus)_VisitDb.TicketStatus,
                    HasStatusPostponementDate = TicketIsPostponed,
                    StatusPostponementDate = TicketPostponementDate
                ,
                    TypeBiz = new TicketTypeBiz() { ID = _VisitDb.TicketType, NameA = _VisitDb.TicketTypeName }
                };

            }
        }
        public VisitBiz()
        {
            _VisitDb = new CampaignCustomerContactDb();
            //_VisitBiz = new VisitBiz();
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _VisitDb.ID = value;
            }
            get
            {
                return _VisitDb.ID;

            }
        }

        public string Desc
        {
            set
            {
                _VisitDb.Comment = value;
            }
            get
            {
                return _VisitDb.Comment == null?"": _VisitDb.Comment;
            }
        }
        public DateTime Date
        {
            set
            {
                _VisitDb.Date = value;
            }
            get
            {
                return _VisitDb.Date;
            }
        }
        public bool WaitingComunication
        {
            set
            {
                _VisitDb.WaitingComunication = value;
            }
            get
            {
                return _VisitDb.WaitingComunication;
            }
        }

        public TicketComunicationWay ComunicationWay
        {
            set
            {
                _VisitDb.ComunicationWay = (int)value;
            }
            get
            {
                return (TicketComunicationWay)_VisitDb.ComunicationWay;
            }
        }



        public ContactStatus Status
        {
            set
            {
                _VisitDb.Status = (int)value;
            }
            get
            {
                return (ContactStatus)_VisitDb.Status;
            }
        }
        EmployeeBiz _StatusEmployeeBiz;

        public EmployeeBiz StatusEmployeeBiz
        {
            get
            {
                if (_StatusEmployeeBiz == null)
                {
                    return EmployeeBiz; //_StatusEmployeeBiz = new EmployeeBiz();
                }
                return _StatusEmployeeBiz;
            }
            set { _StatusEmployeeBiz = value; }
        }
        public FunctionalContactStatus FunctionalStatus
        {
            set
            {
                _VisitDb.FunctionalStatus = (int)value;
            }
            get
            {
                return (FunctionalContactStatus)_VisitDb.FunctionalStatus;
            }
        }
        public int StatusUser
        {
            set
            {
                _VisitDb.StatusUser = value;
            }
            get
            {
                return _VisitDb.StatusUser;
            }
        }
        public double TotalPaid
        {
            set
            {
                _VisitDb.TotalPaid = value;
            }
            get
            {
                return _VisitDb.TotalPaid;
            }

        }
        public int VisitNo
        {
            get => _VisitDb.VisitNo;
            set => _VisitDb.VisitNo = value;
        }
        public int WindowNo
        {
            get => _VisitDb.WindowNo;
            set => _VisitDb.WindowNo = value;
        }
        public bool IsBroadCasted
        {
            get => _VisitDb.IsBroadCasted;
        }
        public string PaymentType
        {
            set => _VisitDb.PaymentType = value;
            get => _VisitDb.PaymentType;
        }
        public string StatusComment
        {
            set
            {
                _VisitDb.StatusComment = value;
            }
            get
            {
                return _VisitDb.StatusComment;
            }

        }
        public string Comment
        {
            get
            {
                return _VisitDb.Comment;
            }
        }
        public bool IsPicked
        {
            get
            {
                return _VisitDb.IsPicked;
            }
        }
        public DateTime PickUpTime
        {
            get
            {
                return _VisitDb.ReceptionPickTime;
            }
        }
        public bool HasStatusPostponementDate
        {
            get { return _VisitDb.HasStatusPostponementDate; }
            set { _VisitDb.HasStatusPostponementDate = value; }
        }


        public DateTime StatusPostponementDate
        {
            get { return _VisitDb.StatusPostponementDate; }
            set { _VisitDb.StatusPostponementDate = value; }
        }
        public VisitBiz Visit
        {
            set
            {
                _VisitBiz = value;
            }
            get
            {
                if (_VisitBiz == null)
                    _VisitBiz = new VisitBiz();
                return _VisitBiz;
            }
        }
        public bool WaitAnotherContact
        {
            get
            {
                return _VisitDb.WaitingAnotherContact;
            }
            set { _VisitDb.WaitingAnotherContact = value; }
        }
        public DateTime AnotherContactDate
        {
            set
            {
                _VisitDb.AnotherContactDate = value;
            }
            get
            {
                return _VisitDb.AnotherContactDate;
            }
        }
        public bool WaitingMonitor
        {
            get { return _VisitDb.WaitingMonitor; }
            set { _VisitDb.WaitingMonitor = value; }
        }
        //DateTime _WaitingMonitoringDate;

        public DateTime WaitingMonitoringDate
        {
            get { return _VisitDb.WaitingMonitoringDate; }
            set { _VisitDb.WaitingMonitoringDate = value; }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                Returned = CampaignCustomerContactBiz.StatusLst[(int)Status];
                return Returned;
            }
        }
        public string ContactCustomerName
        {
            get { return _VisitDb.ContactCustomerName == null ? "" : _VisitDb.ContactCustomerName; }
            set { _VisitDb.ContactCustomerName = value; }
        }
        public string ContactCustomerPhone
        {
            get { return _VisitDb.ContactCustomerPhone == null ? "" : _VisitDb.ContactCustomerPhone; }
            set { _VisitDb.ContactCustomerPhone = value; }
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
        EmployeeBiz _EmployeeBiz;

        public EmployeeBiz EmployeeBiz
        {
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
            set { _EmployeeBiz = value; }
        }
        EmployeeBiz _AssignedEmployeeBiz;

        public EmployeeBiz AssignedEmployeeBiz
        {
            get
            {
                if (_AssignedEmployeeBiz == null)
                    _AssignedEmployeeBiz = new EmployeeBiz();
                return _AssignedEmployeeBiz;
            }
            set { _AssignedEmployeeBiz = value; }
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
        CustomerBiz _CustomerBiz;

        public CustomerBiz CustomerBiz
        {
            get
            {
                if (_CustomerBiz == null)
                    _CustomerBiz = new CustomerBiz();
                return _CustomerBiz;
            }
            set { _CustomerBiz = value; }
        }

        ReservationBiz _ReservationBiz;

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
        VisitTypeBiz _TypeBiz;

        public VisitTypeBiz TypeBiz
        {
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new VisitTypeBiz();
                return _TypeBiz;
            }
            set { _TypeBiz = value; }
        }
        TicketBiz _TicketBiz;
        public TicketBiz TicketBiz
        {
            set { _TicketBiz = value; }
            get
            {
                if (_TicketBiz == null)
                    _TicketBiz = new TicketBiz();
                return _TicketBiz;
            }
        }
        public int Ticket
        {
            get { return _VisitDb.Ticket; }
            set { _VisitDb.Ticket = value; }
        }


        public string TicketWorkGroup
        {
            get { return _VisitDb.TicketWorkGroupName; }
            set { _VisitDb.TicketWorkGroupName = value; }
        }


        public string TicketEmployee
        {
            get { return _VisitDb.TicketEmployeeName; }
            set { _VisitDb.TicketEmployeeName = value; }
        }


        public TicketStatus TicketStatus
        {
            get { return (TicketStatus)_VisitDb.TicketStatus; }
            set { _VisitDb.TicketStatus = (int)value; }
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
            get { return _VisitDb.TicketPostponementDate; }
            set { _VisitDb.TicketPostponementDate = value; }
        }


        public bool TicketIsPostponed
        {
            get { return _VisitDb.TicketIsPostponed; }
            set { _VisitDb.TicketIsPostponed = value; }
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


        public int LastMonitoringID
        {
            get { return _VisitDb.LastMonitoringID; }
            set { _VisitDb.LastMonitoringID = value; }
        }


        public DateTime LastMonitoringDate
        {
            get { return _VisitDb.LastMonitoringDate; }
            set { _VisitDb.LastMonitoringDate = value; }
        }


        public string LastMonitoringDesc
        {
            get { return _VisitDb.LastMonitoringDesc; }
            set { _VisitDb.LastMonitoringDesc = value; }
        }


        public int LastMonitoringStatus
        {
            get { return _VisitDb.LastMonitoringStatus; }
            set { _VisitDb.LastMonitoringStatus = value; }
        }


        public int LastMonitoringEmployee
        {
            get { return _VisitDb.LastMonitoringEmployee; }
            set { _VisitDb.LastMonitoringEmployee = value; }
        }


        public string LastMonitoringEmolyeeName
        {
            get { return _VisitDb.LastMonitoringEmolyeeName; }
            set { _VisitDb.LastMonitoringEmolyeeName = value; }
        }
        ReactionTypeBiz _ReactionTypeBiz;
        public ReactionTypeBiz ReactionTypeBiz
        {
            set => _ReactionTypeBiz = value;
            get
            {
                if (_ReactionTypeBiz == null)
                    _ReactionTypeBiz = new ReactionTypeBiz();
                return _ReactionTypeBiz;
            }
        }

        #endregion

        #region Private Methods
        void GetData()
        {
            _VisitDb.Employee = AssignedEmployeeBiz.ID;
            _VisitDb.WorkGroup = GroupBiz.ID;

            _VisitDb.Project = ProjectBiz.ID;
            _VisitDb.VisitType = TypeBiz.ID;

            _VisitDb.Reservation = ReservationBiz.ID;
            _VisitDb.DirectCustomerID = CustomerBiz.ID;
            _VisitDb.ReceptionistID = EmployeeBiz.ID;
            _VisitDb.Branch = BranchBiz.ID;
            _VisitDb.ReceptionStatus = 1;
            _VisitDb.Type = (int)ContactType.CustomerVisit;
            if (StatusEmployeeBiz.ID == 0)
                _StatusEmployeeBiz = EmployeeBiz;
            _VisitDb.Project = ProjectBiz.ID;
            _VisitDb.StatusEmployee = StatusEmployeeBiz.ID;
            _VisitDb.Ticket = TicketBiz.ID;
            _VisitDb.Direction = true;
            _VisitDb.ReactionTypeID = ReactionTypeBiz.ID;
        }
        #endregion

        #region Public Methods
        public void Add()
        {

            GetData();


            _VisitDb.Add();
        }

        public void Edit()
        {
            GetData();


            _VisitDb.Edit();
        }
        public void Delete()
        {
            _VisitDb.Add();
        }

        public void EditStatus()
        {
            _VisitDb.EditStatus();
        }
        public void EditTicket()
        {
            _VisitDb.EditTicket();
        }
        public bool PickUpVisit(EmployeeBiz objEmployeeBiz
            , int intWindowNo
            , WorkGroupBiz objGroupBiz, string strComment)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new UMS.UMSBusiness.EmployeeBiz();
            if (objGroupBiz == null)
                objGroupBiz = new WorkGroupBiz();
            bool Returned = true;
            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            objDb.ID = ID;
            objDb.Employee = objEmployeeBiz.ID;
            objDb.WorkGroup = objGroupBiz.ID;
            objDb.StatusComment = strComment;
            objDb.StatusComment = CampaignCustomerContactBiz.StatusLst[(int)ContactStatus.PickedUp];
            objDb.StatusEmployee = objEmployeeBiz.ID;
            objDb.WindowNo = intWindowNo;

            objDb.PickUp();
            Returned = objDb.Employee > 0;
            return Returned;
        }
        public void Enter()
        {
            if (_VisitDb.ID == 0)
                return;
            _VisitDb.StatusComment = CampaignCustomerContactBiz.StatusLst[(int)ContactStatus.Entered];
            _VisitDb.StatusEmployee = StatusEmployeeBiz.ID;
            _VisitDb.Enter();

        }
        public void Depart()
        {
            if (_VisitDb.ID == 0)
                return;
            _VisitDb.StatusComment = CampaignCustomerContactBiz.StatusLst[(int)ContactStatus.Departed];
            _VisitDb.StatusEmployee = StatusEmployeeBiz.ID;
            _VisitDb.Depart();

        }
        public void Cancel()
        {
            if (_VisitDb.ID == 0)
                return;
            _VisitDb.StatusComment = CampaignCustomerContactBiz.StatusLst[(int)ContactStatus.Canceled];
            _VisitDb.StatusEmployee = StatusEmployeeBiz.ID;
            _VisitDb.Cancel();

        }
        public static void BroadCastVisit(int intVisitID)
        {
            VisitDb objDb = new VisitDb();
            objDb.ID = intVisitID;
            objDb.BroadCastVisit();
        }
        #endregion

    }
}
