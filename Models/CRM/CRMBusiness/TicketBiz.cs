using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum TicketStatus
    {
        NotSpecified, //0 €Ì— „Õœœ
        Created,//  „ ⁄„· «· Ìﬂ  1
        Processing,//Ì „ „⁄«·Ã… «· Ìﬂ  2
        Waiting,// «· Ìﬂ   ‰ Ÿ— «·„⁄«·Ã… 3
        Canceled,//4  „ «·€«¡ «· Ìﬂ  
        Ended// „ «·«‰ Â«¡ 5

    }

    public enum TicketComunicationWay
    {
        NotSpecified,
        byPhone,
        byEmail,
        byReseption

    }


    public class TicketBiz
    {
        #region Private Data
        VisitBiz _VisitBiz;
        TicketDb _TicketDb;
        public static int UMSTicketMonitor = 1228;
        public static int UMSTicketProcess = 761;
        #endregion

        #region Public Constractors
        public TicketBiz(int intID, string strStatusStr)
        {

            _TicketDb = new TicketDb();
            _VisitBiz = new VisitBiz();
            if (intID != 0)
            {
                TicketDb objDb = new TicketDb();
                objDb.ID = intID;
                objDb.StatusStr = strStatusStr;
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count != 0)
                {


                    _VisitBiz = new VisitBiz(dtTemp.Rows[0]);
                    _TicketDb = new TicketDb(dtTemp.Rows[0]);

                }
            }
        }
        public TicketBiz(DataRow objDR)
        {
            _TicketDb = new TicketDb(objDR);

            _StatusBiz = new TicketStatusBiz(objDR);
            _ReservationBiz = new ReservationBiz();
            if (_TicketDb.Reservation != 0)
            {
                _ReservationBiz.ID = _TicketDb.Reservation;
                _ReservationBiz.DirectCustomerStr = _TicketDb.ReservationCustomerName;
                _ReservationBiz.DirectUnitCodeStr = _TicketDb.ReservationUnitName;
            }
            _CustomerBiz = new CustomerBiz();
            if (_TicketDb.Customer != 0)
            {
                _CustomerBiz.ID = _TicketDb.Customer;
                _CustomerBiz.NameA = _TicketDb.CustomerName;
            }
            _GroupBiz = new WorkGroupBiz();
            if (_TicketDb.WorkGroup != 0)
            {
                _GroupBiz.ID = _TicketDb.WorkGroup;
                _GroupBiz.NameA = _TicketDb.WorkGroupName;
            }
            _AssignedEmployeeBiz = new EmployeeBiz();
            if (_TicketDb.AssignedApplicant != 0)
            {
                _AssignedEmployeeBiz.ID = _TicketDb.AssignedApplicant;
                _AssignedEmployeeBiz.Name = _TicketDb.AssignedApplicantName;

            }
            _EmployeeBiz = new EmployeeBiz();
            if (_TicketDb.EmployeeID != 0)
            {
                _EmployeeBiz.ID = _TicketDb.EmployeeID;
                _EmployeeBiz.Name = _TicketDb.EmployeeName;
            }
            if (_TicketDb.Parent != 0)
            {
                _ParentBiz = new TicketBiz();
                _ParentBiz.ID = _TicketDb.Parent;
                _ParentBiz.Desc = _TicketDb.ParentDesc;
            }
            if (_TicketDb.Type != 0)
                _TypeBiz = new TicketTypeBiz(objDR);
        }
        public TicketBiz()
        {
            _TicketDb = new TicketDb();
            _VisitBiz = new VisitBiz();
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _TicketDb.ID = value;
            }
            get
            {
                return _TicketDb.ID;

            }
        }

        public string Desc
        {
            set
            {
                _TicketDb.Desc = value;
            }
            get
            {
                return _TicketDb.Desc;
            }
        }
        public DateTime Date
        {
            set
            {
                _TicketDb.Date = value;
            }
            get
            {
                return _TicketDb.Date;
            }
        }
        public bool WaitingComunication
        {
            set
            {
                _TicketDb.WaitingComunication = value;
            }
            get
            {
                return _TicketDb.WaitingComunication;
            }
        }

        public TicketComunicationWay ComunicationWay
        {
            set
            {
                _TicketDb.ComunicationWay = (int)value;
            }
            get
            {
                return (TicketComunicationWay)_TicketDb.ComunicationWay;
            }
        }



        public TicketStatus Status
        {
            set
            {
                _TicketDb.Status = (int)value;
            }
            get
            {
                return (TicketStatus)_TicketDb.Status;
            }
        }

        public int StatusUser
        {
            set
            {
                _TicketDb.StatusUser = value;
            }
            get
            {
                return _TicketDb.StatusUser;
            }
        }
        public string StatusComment
        {
            set
            {
                _TicketDb.StatusComment = value;
            }
            get
            {
                return _TicketDb.StatusComment;
            }

        }
        public bool HasStatusPostponementDate
        {
            get { return _TicketDb.HasStatusPostponementDate; }
            set { _TicketDb.HasStatusPostponementDate = value; }
        }


        public DateTime StatusPostponementDate
        {
            get { return _TicketDb.StatusPostponementDate; }
            set { _TicketDb.StatusPostponementDate = value; }
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
        public string StatusStr
        {
            get
            {
                string Returned = "";
                string strPostponement = HasStatusPostponementDate ? "„ƒÃ·… «·Ï  «—ÌŒ " + StatusPostponementDate.ToString("yyyy-MM-dd") : "›Ï «·„⁄«·Ã…";

                switch (Status)
                {

                    case TicketStatus.Canceled: Returned = "«·€«¡"; break;
                    case TicketStatus.Created: Returned = "ÃœÌœ"; break;
                    case TicketStatus.Ended: Returned = "«‰ Â«¡"; break;
                    case TicketStatus.NotSpecified: Returned = "€Ì— „Õœœ"; break;
                    case TicketStatus.Processing: Returned = strPostponement; break;
                    case TicketStatus.Waiting: Returned = "«‰ Ÿ«—"; break;
                    default: Returned = "€Ì— „Õœœ"; break;
                }

                return Returned;
            }
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
        TicketBiz _ParentBiz;

        public TicketBiz ParentBiz
        {
            get
            {
                if (_ParentBiz == null)
                {
                    _ParentBiz = new TicketBiz();
                }
                return _ParentBiz;
            }
            set
            {

                _ParentBiz = value;
            }
        }
        TicketTypeBiz _TypeBiz;

        public TicketTypeBiz TypeBiz
        {
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new TicketTypeBiz();
                return _TypeBiz;
            }
            set { _TypeBiz = value; }
        }
        TicketStatusCol _StatusCol;

        public TicketStatusCol StatusCol
        {
            get
            {
                if (_StatusCol == null)
                {
                    _StatusCol = new TicketStatusCol(true);
                    if (ID != 0)
                    {
                        TicketStatusDb objDb = new TicketStatusDb();
                        TicketStatusBiz objBiz;
                        objDb.TicketID = ID;
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "StatusTimIns desc");
                        foreach (DataRow objDr in arrDr)
                        {
                            _StatusCol.Add(new TicketStatusBiz(objDr));

                        }
                    }

                }
                return _StatusCol;
            }
            set { _StatusCol = value; }
        }
        TicketStatusBiz _StatusBiz;

        public TicketStatusBiz StatusBiz
        {
            get
            {
                if (_StatusBiz == null)
                    _StatusBiz = new TicketStatusBiz();
                return _StatusBiz;
            }
            set { _StatusBiz = value; }
        }
        public static List<string> StatusLst
        {
            get
            {
                List<string> Returned = new List<string>();
                //NotSpecified, //0 €Ì— „Õœœ
                Returned.Add("€Ì— „Õœœ");
                // Created,//  „ ⁄„· «· Ìﬂ  1
                Returned.Add("ÃœÌœ…");
                //Processing,//Ì „ „⁄«·Ã… «· Ìﬂ  2
                Returned.Add(" Õ  «·„⁄«·Ã…");
                //Waiting,// «· Ìﬂ   ‰ Ÿ— «·„⁄«·Ã… 3
                Returned.Add(" ‰Ÿ—");
                // Canceled,//4  „ «·€«¡ «· Ìﬂ  
                Returned.Add(" „ «·«·€«¡");
                //Ended// „ «·«‰ Â«¡ 5
                Returned.Add(" „ ");
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            if (_VisitBiz == null)
                _VisitBiz = new VisitBiz();
            _TicketDb.Visit = Visit.ID;
            _TicketDb.AssignedApplicant = AssignedEmployeeBiz.ID;
            _TicketDb.WorkGroup = GroupBiz.ID;
            _TicketDb.Parent = ParentBiz.ID;
            _TicketDb.Project = ProjectBiz.ID;
            _TicketDb.Type = TypeBiz.ID;
            _TicketDb.Reservation = ReservationBiz.ID;
            _TicketDb.Customer = CustomerBiz.ID;
            _TicketDb.EmployeeID = EmployeeBiz.ID;
            _TicketDb.Add();
        }

        public void Edit()
        {
            if (_VisitBiz == null)
                _VisitBiz = new VisitBiz();
            _TicketDb.Visit = Visit.ID;

            _TicketDb.AssignedApplicant = AssignedEmployeeBiz.ID;
            _TicketDb.WorkGroup = GroupBiz.ID;
            _TicketDb.Parent = ParentBiz.ID;
            _TicketDb.Project = ProjectBiz.ID;
            _TicketDb.Type = TypeBiz.ID;
            _TicketDb.Reservation = ReservationBiz.ID;
            _TicketDb.Customer = CustomerBiz.ID;
            _TicketDb.EmployeeID = EmployeeBiz.ID;
            _TicketDb.Edit();
        }
        public void EditStatus()
        {
            _TicketDb.EditStatus();
        }
        public bool PickUpTicket(EmployeeBiz objEmployeeBiz, WorkGroupBiz objGroupBiz, string strComment)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new UMS.UMSBusiness.EmployeeBiz();
            if (objGroupBiz == null)
                objGroupBiz = new WorkGroupBiz();
            bool Returned = true;
            TicketDb objDb = new TicketDb();
            objDb.ID = ID;
            objDb.AssignedApplicant = objEmployeeBiz.ID;
            objDb.WorkGroup = objGroupBiz.ID;
            objDb.StatusComment = strComment;
            Returned = objDb.PickUpTicket();
            return Returned;
        }
        public TicketBiz SpawnNewTicket()
        {
            TicketBiz Returned = new TicketBiz();
            Returned.EmployeeBiz = AssignedEmployeeBiz;
            Returned.ComunicationWay = ComunicationWay;
            Returned.CustomerBiz = CustomerBiz;
            Returned.Date = DateTime.Now;
            Returned.Desc = Desc;
            //Returned.GroupBiz = GroupBiz;
            Returned.ParentBiz = this;
            Returned.ProjectBiz = ProjectBiz;
            Returned.ReservationBiz = ReservationBiz;
            Returned.Status = TicketStatus.Created;
            Returned.StatusComment = StatusComment;
            Returned.TypeBiz = TypeBiz;
            Returned.WaitingComunication = WaitingComunication;

            return Returned;
        }
        #endregion

    }
}
