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
    public class TicketCol : BaseCol
    {

        #region Private Data
        int _ID;
        TicketTypeBiz _TypeBiz;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        CustomerBiz _CustomerBiz;
        ReservationBiz _ReservationBiz;
        WorkGroupBiz _GroupBiz;
        EmployeeBiz _EmployeeBiz;
        ProjectBiz _ProjectBiz;
        TicketBiz _MainBiz;
        string _StatusStr;
        bool _PostponementDateStatus;
        DateTime _PostponementDateStart;
        DateTime _PostponementDateEnd;
        #endregion

        public TicketCol(int intID)
        {
            TicketDb objDb = new TicketDb(intID);
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TicketBiz(objDr));
            }
        }
        public TicketCol(bool blIsEmpty)
        {

        }
        public TicketCol(int intID, TicketTypeBiz objTypeBiz, bool blIsDateRange, DateTime dtStart, DateTime dtEnd,
            CustomerBiz objCustomerBiz, ReservationBiz objReservationBiz
            , WorkGroupBiz objGroupBiz, EmployeeBiz objEmployeeBiz,
            ProjectBiz objProjectBiz, TicketBiz objMain, string strStatus
            , bool blIsPostponementDateStatus, DateTime dtPostponementStart, DateTime dtPostponementEnd)
        {
            InitializeSearch(intID, objTypeBiz, blIsDateRange, dtStart, dtEnd,
                       objCustomerBiz, objReservationBiz, objGroupBiz, objEmployeeBiz,
                       objProjectBiz, objMain, strStatus, blIsPostponementDateStatus, dtPostponementStart, dtPostponementEnd);
            TicketDb objDb = new TicketDb();
            GetSearchData(ref objDb);
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "");
            TicketBiz objBiz;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new TicketBiz(objDr);
                Add(objBiz);
            }
        }
        #region Private Method
        void InitializeSearch(int intID, TicketTypeBiz objTypeBiz, bool blIsDateRange, DateTime dtStart, DateTime dtEnd,
            CustomerBiz objCustomerBiz, ReservationBiz objReservationBiz, WorkGroupBiz objGroupBiz, EmployeeBiz objEmployeeBiz,
            ProjectBiz objProjectBiz, TicketBiz objMain, string strStatus,
            bool blPostponementStatus, DateTime dtPostponementStart, DateTime dtPostponementEnd)
        {
            _ID = intID;
            _TypeBiz = objTypeBiz;
            _IsDateRange = blIsDateRange;
            _StartDate = dtStart;
            _EndDate = dtEnd;
            _CustomerBiz = objCustomerBiz;
            _ReservationBiz = objReservationBiz;
            _GroupBiz = objGroupBiz;
            _EmployeeBiz = objEmployeeBiz;
            _ProjectBiz = objProjectBiz;
            _MainBiz = objMain;
            _StatusStr = strStatus;
            _PostponementDateStatus = blPostponementStatus;
            _PostponementDateStart = dtPostponementStart;
            _PostponementDateEnd = dtPostponementEnd;
        }
        void GetSearchData(ref TicketDb objDb)
        {
            objDb.ID = _ID;
            if (_TypeBiz == null)
                _TypeBiz = new TicketTypeBiz();
            objDb.Type = _TypeBiz.ID;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            if (_CustomerBiz == null)
                _CustomerBiz = new CustomerBiz();
            objDb.Customer = _CustomerBiz.ID;
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            objDb.Reservation = _ReservationBiz.ID;
            if (_GroupBiz == null)
                _GroupBiz = new WorkGroupBiz();
            objDb.WorkGroup = _GroupBiz.ID;
            if (_EmployeeBiz == null)
                _EmployeeBiz = new EmployeeBiz();

            objDb.EmployeeID = _EmployeeBiz.ID;
            if (_ProjectBiz == null)
                _ProjectBiz = new ProjectBiz();
            objDb.Project = _ProjectBiz.ID;
            if (_MainBiz == null)
                _MainBiz = new TicketBiz();
            objDb.Parent = _MainBiz.ID;
            objDb.StatusStr = _StatusStr;
            objDb.PostponmentDateStatus = _PostponementDateStatus;
            objDb.StartPostponementDate = _PostponementDateStart;
            objDb.EndPostponementDate = _PostponementDateEnd;
        }
        #endregion
        public TicketBiz this[int intIndex]
        {

            get
            {
                return (TicketBiz)List[intIndex];
            }
        }
        public void Add(TicketBiz objBiz)
        {
            List.Add(objBiz);

        }
        public static TicketCol GetWaitingAssignmentTicketCol(EmployeeBiz objAssignedEmployee, WorkGroupBiz objAssignedGroup)
        {
            TicketCol Returned = new TicketCol(true);
            if (objAssignedGroup == null)
                objAssignedGroup = new WorkGroupBiz();
            if (objAssignedEmployee == null)
                objAssignedEmployee = new EmployeeBiz();
            if (objAssignedGroup.ID == 0)
                return Returned;

            TicketDb objDb = new TicketDb();
            objDb.WaitingAssignmentStatus = 1;
            objDb.AssignedApplicant = objAssignedEmployee.ID;
            objDb.WorkGroup = objAssignedGroup.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new TicketBiz(objDr));
            return Returned;
        }
        public static TicketCol GetTicketCol(CustomerBiz objBiz)
        {
            TicketCol Returned = new TicketCol(true);
            TicketDb objDb = new TicketDb();
            objDb.Customer = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new TicketBiz(objDr));

            }
            return Returned;
        }
        public static TicketCol GetTicketProcessingWaitingCurrentDate(EmployeeBiz objEmployeeBiz,WorkGroupBiz objWorkGroupBiz)
        {
            TicketCol Returned = new TicketCol(true);
            TicketDb objDb = new TicketDb();
            objDb.EmployeeID = objEmployeeBiz.ID;
            //if (SysData.CurrentUser.UserFunctionInstantCol.GetIndex(TicketBiz.UMSTicketMonitor) != -1)
                objDb.WorkGroup = objWorkGroupBiz.ID;
            DataTable dtTemp = objDb.GetWaitingTodayTicket();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new TicketBiz(objDr));

            }
            IEnumerable<TicketBiz> objCol = from objTicketBiz in Returned.Cast<TicketBiz>()
                                            let intID = objTicketBiz.AssignedEmployeeBiz.ID == SysData.CurrentUser.EmployeeBiz.ID ? 0 : 1
                                            orderby intID
                                            select objTicketBiz;
            Returned = new TicketCol(true);
            foreach (TicketBiz objBiz in objCol)
            {
                Returned.Add(objBiz);
            }

            return Returned;
        }
    }
}
