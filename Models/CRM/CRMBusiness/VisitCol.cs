using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System.Linq;
namespace SharpVision.CRM.CRMBusiness
{
    public class VisitCol : BaseCol
    {

        #region Private Data
        int _ID;
        VisitTypeCol _TypeCol;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        CustomerBiz _CustomerBiz;
        ReservationBiz _ReservationBiz;
        WorkGroupBiz _GroupBiz;
        EmployeeBiz _EmployeeBiz;
        ProjectBiz _ProjectBiz;
        VisitBiz _MainBiz;
        UMSBranchBiz _BranchBiz;
        string _StatusStr;
        int _PaymentStatus;

        string _FunctionalStatusStr = "";
        int _ResultCount;
        public int ResultCount
        {
            set => _ResultCount = value;
            get => _ResultCount;
        }
        #endregion

        public VisitCol(int intID)
        {
            VisitDb objDb = new VisitDb(intID);
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new VisitBiz(objDr));
            }
        }
        public VisitCol(bool blIsEmpty)
        {

        }
        public VisitCol(int intID, VisitTypeCol objTypeCol, bool blIsDateRange, DateTime dtStart, DateTime dtEnd,
            CustomerBiz objCustomerBiz, ReservationBiz objReservationBiz, WorkGroupBiz objGroupBiz, EmployeeBiz objEmployeeBiz,
            ProjectBiz objProjectBiz, UMSBranchBiz objBranchBiz, string strStatus, string strFunctionalStatus, int intPaymentStatus)
        {
            InitializeSearch(intID, objTypeCol, blIsDateRange, dtStart, dtEnd,
                       objCustomerBiz, objReservationBiz, objGroupBiz, objEmployeeBiz,
                       objProjectBiz, objBranchBiz, strStatus, strFunctionalStatus, intPaymentStatus);

            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            GetSearchData(ref objDb);

            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            DataRow[] arrDr = dtTemp.Select("", "");
            VisitBiz objBiz;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new VisitBiz(objDr);
                Add(objBiz);
            }
        }
        #region Private Method
        void InitializeSearch(int intID, VisitTypeCol objTypeCol, bool blIsDateRange, DateTime dtStart, DateTime dtEnd,
            CustomerBiz objCustomerBiz, ReservationBiz objReservationBiz, WorkGroupBiz objGroupBiz, EmployeeBiz objEmployeeBiz,
            ProjectBiz objProjectBiz, UMSBranchBiz objBranchBiz, string strStatus, string strFunctionalStatus, int intPaymentStatus)
        {
            _ID = intID;
            _TypeCol = objTypeCol;
            _IsDateRange = blIsDateRange;
            _StartDate = dtStart;
            _EndDate = dtEnd;
            _CustomerBiz = objCustomerBiz;
            _ReservationBiz = objReservationBiz;
            _GroupBiz = objGroupBiz;
            _EmployeeBiz = objEmployeeBiz;
            _ProjectBiz = objProjectBiz;
            _BranchBiz = objBranchBiz;
            _StatusStr = strStatus;
            _PaymentStatus = intPaymentStatus;
            _FunctionalStatusStr = strFunctionalStatus;
        }
        void GetSearchData(ref CampaignCustomerContactDb objDb)
        {
            objDb.ID = _ID;
            if (_TypeCol == null)
                _TypeCol = new VisitTypeCol(true);
            objDb.VisitTypeIDs = _TypeCol.IDs;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            if (_CustomerBiz == null)
                _CustomerBiz = new CustomerBiz();
            objDb.DirectCustomerID = _CustomerBiz.ID;
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            objDb.Reservation = _ReservationBiz.ID;
            if (_GroupBiz == null)
                _GroupBiz = new WorkGroupBiz();
            objDb.WorkGroup = _GroupBiz.ID;
            if (_EmployeeBiz == null)
                _EmployeeBiz = new EmployeeBiz();

            objDb.Employee = _EmployeeBiz.ID;
            if (_ProjectBiz == null)
                _ProjectBiz = new ProjectBiz();
            //objDb.Project = _ProjectBiz.CellFamilyID;
            objDb.ReceptionStatus = 1;
            objDb.VisitStatusStr = _StatusStr;
            objDb.VisitFunctionStatusStr = _FunctionalStatusStr;
            objDb.PaymentStatus = _PaymentStatus;
        }
        #endregion
        public VisitBiz this[int intIndex]
        {

            get
            {
                return (VisitBiz)List[intIndex];
            }
        }
        public void Add(VisitBiz objBiz)
        {
            List.Add(objBiz);

        }
        public static VisitCol GetWaitingAssignmentVisitCol(EmployeeBiz objAssignedEmployee, WorkGroupBiz objAssignedGroup,
            UMSBranchBiz objBranchBiz, EmployeeBiz objNewEmployee)
        {
            VisitCol Returned = new VisitCol(true);
            if (objAssignedGroup == null)
                objAssignedGroup = new WorkGroupBiz();
            if (objAssignedEmployee == null)
                objAssignedEmployee = new EmployeeBiz();
            if (objBranchBiz == null)
                objBranchBiz = new UMSBranchBiz();
            if (objNewEmployee == null)
                objNewEmployee = new EmployeeBiz();
            VisitDb objDb = new VisitDb();
            objDb.PickedStatus = 2;
            //objDb.ReceptionStatus = 1;
            if (objAssignedGroup.ID != 0)
            {

            }
            objDb.WorkGroup = objAssignedGroup.ID;
            //objDb.StopCount = true;
            objDb.IsDateRange = true;
            objDb.StartDate = DateTime.Now;
            objDb.EndDate = DateTime.Now;
            objDb.Branch = objBranchBiz.ID;
            //if (objBranchBiz.ID != 0 && objAssignedGroup.ID != 0 && objAssignedEmployee.ID != 0)
            //  objDb.LogInWithSearch = true;
            objDb.AssignedEmployee = objNewEmployee.ID;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "ContactDate");
            foreach (DataRow objDr in arrDr)
                Returned.Add(new VisitBiz(objDr));
            return Returned;
        }
        public static VisitCol GetPickedVisitCol(EmployeeBiz objAssignedEmployee,
            WorkGroupBiz objGroupBiz, UMSBranchBiz objBranchBiz
            , int intWindowNo)
        {
            VisitCol Returned = new VisitCol(true);
            if (objGroupBiz == null)
                objGroupBiz = new WorkGroupBiz();
            if (objAssignedEmployee == null)
                objAssignedEmployee = new EmployeeBiz();
            if (objBranchBiz == null)
                objBranchBiz = new UMSBranchBiz();
            VisitDb objDb = new VisitDb();
            objDb.EntryStatus = 2;

            objDb.Branch = objBranchBiz.ID;
            objDb.Employee = objAssignedEmployee.ID;
            //objDb.emp = objAssignedEmployee.ID;
            objDb.WorkGroup = objGroupBiz.ID;
            objDb.PickedStatus = 1;

            objDb.IsDateRange = true;
            objDb.StartDate = DateTime.Now;
            objDb.EndDate = DateTime.Now;
            objDb.WindowNo = intWindowNo;
            if (objBranchBiz.ID != 0 && objGroupBiz.ID != 0 && objAssignedEmployee.ID != 0)
                objDb.LogInWithSearch = true;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "CampaignContactReceptionPickTime desc ");
            foreach (DataRow objDr in arrDr)
                Returned.Add(new VisitBiz(objDr));
            return Returned;
        }
        public static VisitCol GetPickedVisitCol1(EmployeeBiz objAssignedEmployee, WorkGroupBiz objGroupBiz, UMSBranchBiz objBranchBiz)
        {
            VisitCol Returned = new VisitCol(true);
            if (objGroupBiz == null)
                objGroupBiz = new WorkGroupBiz();
            if (objAssignedEmployee == null)
                objAssignedEmployee = new EmployeeBiz();
            if (objBranchBiz == null)
                objBranchBiz = new UMSBranchBiz();
            CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
            objDb.EntryStatus = 2;
            objDb.ReceptionStatus = 1;
            //objDb.AssignedApplicant = objAssignedEmployee.ID;
            objDb.Branch = objBranchBiz.ID;
            objDb.Employee = objAssignedEmployee.ID;
            //objDb.emp = objAssignedEmployee.ID;
            objDb.WorkGroup = objGroupBiz.ID;
            objDb.PickedStatus = 1;
            objDb.StopCount = true;
            objDb.IsDateRange = true;
            objDb.StartDate = DateTime.Now;
            objDb.EndDate = DateTime.Now;
            if (objBranchBiz.ID != 0 && objGroupBiz.ID != 0 && objAssignedEmployee.ID != 0)
                objDb.LogInWithSearch = true;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "CampaignContactReceptionPickTime desc ");
            foreach (DataRow objDr in arrDr)
                Returned.Add(new VisitBiz(objDr));
            return Returned;
        }
        public TicketCol GetTicketCol(bool blParent)
        {
            string strTicket = "";
            foreach (VisitBiz objContactBiz in this)
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
        public DataTable GetViewTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]
            { new DataColumn("ContactID"),new DataColumn("Project"),new DataColumn("Unit"), new DataColumn("CustomerID")
            , new DataColumn("CustomerName"), new DataColumn("EmployeeName")
            ,new DataColumn("ContractValue"),new DataColumn("ContractStatus"),new DataColumn("ContractCancelationDate")
            , new DataColumn("Date"),new DataColumn("Time")
            , new DataColumn("PickUpDate"), new DataColumn("Comment")
            , new DataColumn("Status"), new DataColumn("Phone")
            , new DataColumn("StatusDate"), new DataColumn("StatusComment")
            , new DataColumn("VisitType"), new DataColumn("TicketGroup"), new DataColumn("TicketEmployee"), new DataColumn("TicketStatus"), new DataColumn("TicketPostponementDate"), new DataColumn("ContactWaitingDate"), new DataColumn("ContactMonitoringDate"), new DataColumn("WaitingMonitoringDate"), new DataColumn("LastMonitorDate"), new DataColumn("LastMonitoringEmployee"), new DataColumn("LastMonitoringDesc"), new DataColumn("LastMonitoringStatus"), new DataColumn("Branch"), new DataColumn("CustomerPhone")
                , new DataColumn("VisitStatusDone"), new DataColumn("TicketComment"),new DataColumn("TotalPaidValue"),new DataColumn("PaymentType") });
            string strCustomerName = "";
            string strCustomerPhone = "";
            DataRow objDr;
            foreach (VisitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                strCustomerName = objBiz.ContactCustomerName;
                if (strCustomerName == "")
                    strCustomerName = objBiz.CustomerBiz.ID == 0 ? "" : objBiz.CustomerBiz.Name;

                strCustomerPhone = objBiz.ContactCustomerPhone;
                if (strCustomerPhone == "")
                    strCustomerPhone = objBiz.CustomerBiz.ID == 0 ? "" : objBiz.CustomerBiz.Mobile;
                objDr["ContactID"] = objBiz.ID;
                objDr["Project"] = objBiz.ProjectBiz.Name;
                objDr["Unit"] = objBiz.ReservationBiz.DirectUnitCodeStr;

                objDr["CustomerID"] = objBiz.CustomerBiz.ID;
                objDr["CustomerName"] = strCustomerName; // objBiz.CustomerBiz.Name;
                objDr["ContractValue"] = objBiz.ReservationBiz.Value;
                objDr["ContractStatus"] =
                    objBiz.ReservationBiz.Status == ReservationStatus.Cancellation ?
                    "«·€«¡" : "";
                objDr["ContractCancelationDate"] =
                    objBiz.ReservationBiz.IsCanceled ? objBiz.ReservationBiz.CancelationBiz.Date.ToString("yyyy-MM-dd") : "";
                //objDr["ContactTyp"] = objBiz.Type
                objDr["EmployeeName"] = objBiz.AssignedEmployeeBiz.Name;//objBiz.EmployeeBiz.Name;

                objDr["Date"] = objBiz.Date.ToString("yyyy-MM-dd");
                objDr["Time"] = objBiz.Date.ToString("HHH:mm");


                objDr["PickUpDate"] = objBiz.IsPicked ? objBiz.PickUpTime.ToString("HHH:mm") : "";
                objDr["Comment"] = objBiz.Comment;

                objDr["Status"] = objBiz.StatusBiz.StatusStr;
                objDr["Phone"] = objBiz.CustomerBiz.Mobile;
                objDr["StatusDate"] = objBiz.StatusBiz.ID == 0 ? "" : objBiz.StatusBiz.Date.ToString("HHH:mm");
                objDr["StatusComment"] = objBiz.StatusBiz.ID == 0 ? "" : objBiz.StatusBiz.Desc;
                objDr["VisitType"] = objBiz.TypeBiz.Name;

                objDr["TicketGroup"] = objBiz.TicketWorkGroup;
                objDr["TicketEmployee"] = objBiz.TicketEmployee;
                objDr["TicketStatus"] = objBiz.Ticket == 0 ? "" : objBiz.TicketStatusStr;
                //objDr["TicketStatusDate"] = objBiz.Ticket==0?"": objBiz.TicketBiz.sta
                objDr["TicketPostponementDate"] = objBiz.Ticket == 0 ? "" :
                    (objBiz.TicketIsPostponed ? objBiz.TicketPostponementDate.ToString("yyyy-MM-dd") : "");
                objDr["ContactWaitingDate"] = objBiz.WaitAnotherContact ?
                    objBiz.AnotherContactDate.ToString("yyyy-MM-dd") : "";
                objDr["ContactMonitoringDate"] = objBiz.WaitingMonitor ?
                    objBiz.WaitingMonitoringDate.ToString("yyyy-MM-dd") : "";

                objDr["WaitingMonitoringDate"] = objBiz.WaitingMonitor ? objBiz.WaitingMonitoringDate.ToString("yyyy-MM-dd") : "";
                objDr["LastMonitorDate"] = objBiz.LastMonitoringID == 0 ? "" : objBiz.LastMonitoringDate.ToString("yyyy-MM-dd");
                objDr["LastMonitoringEmployee"] = objBiz.LastMonitoringID == 0 ? "" : objBiz.LastMonitoringEmolyeeName;
                objDr["LastMonitoringDesc"] = objBiz.LastMonitoringID == 0 ? "" : objBiz.LastMonitoringDesc;
                objDr["LastMonitoringStatus"] = objBiz.LastMonitoringID == 0 ? "" :
                    (objBiz.LastMonitoringStatus == 1 ? " „" : "«Œ›«ﬁ");
                objDr["Branch"] = objBiz.BranchBiz.Name;
                objDr["CustomerPhone"] = strCustomerPhone; // objBiz.CustomerBiz.Mobile;
                objDr["VisitStatusDone"] = objBiz.FunctionalStatus == FunctionalContactStatus.Done ? " „" :
                    (objBiz.FunctionalStatus == FunctionalContactStatus.EscalatedCase ? " ’⁄Ìœ" :
                    (objBiz.FunctionalStatus == FunctionalContactStatus.Refused ? "—›÷" : ""));
                objDr["TicketComment"] = objBiz.TicketBiz.Desc;
                objDr["TotalPaidValue"] = objBiz.TotalPaid.ToString();
                objDr["PaymentType"] = objBiz.PaymentType;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        bool _ReservationIsSet = false;
        public void SetReservationCol()
        {
            var arrReservationID =
                from objVisit in this.Cast<VisitBiz>()
                where objVisit.ReservationBiz.ID != 0
                group objVisit by objVisit.ReservationBiz.ID into objReservationID
                select objReservationID;

            string strReservationIDs = "";
            foreach (var objReservationID in arrReservationID)
            {
                if (strReservationIDs != "")
                    strReservationIDs += ",";
                strReservationIDs += objReservationID.Key.ToString();


            }
            if (strReservationIDs == "")
                return;

            ReservationDb objReservationDB = new ReservationDb();
            objReservationDB.IDs = strReservationIDs;
            //objReservationDB.Search();
            objReservationDB.TopSelect = arrReservationID.Count();
            DataTable dtTemp = objReservationDB.Search();
            ReservationCol objReservationCol = new ReservationCol(true);
            foreach (DataRow objDr in dtTemp.Rows)
                objReservationCol.Add(new ReservationBiz(objDr));
            foreach (VisitBiz objVisitBiz in this)
            {
                if (objVisitBiz.ReservationBiz.ID != 0)
                    objVisitBiz.ReservationBiz =
                        objReservationCol[objVisitBiz.ReservationBiz.ID.ToString()];
            }
            _ReservationIsSet = true;

        }
    }
}
