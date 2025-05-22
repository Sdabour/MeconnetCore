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
    public class TicketStatusBiz
    {
        #region Private Data
        TicketStatusDb _StatusDb;

        #endregion
        #region Constructors
        public TicketStatusBiz()
        {
            _StatusDb = new TicketStatusDb();
        }
        public TicketStatusBiz(DataRow objDr)
        {
            _StatusDb = new TicketStatusDb(objDr);
            _EmployeeBiz = new EmployeeBiz();
            if (_StatusDb.EmployeeID != 0)
            {
                _EmployeeBiz.ID = _StatusDb.EmployeeID;
                _EmployeeBiz.Name = _StatusDb.EmployeeName;
 
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _StatusDb.ID = value;
            }
            get
            {
                return _StatusDb.ID;
            }
        }
        

        public TicketStatus Status
        {
            get { return (TicketStatus)_StatusDb.Status; }
            set { _StatusDb.Status = (int)value; }
        }
        public bool HasPostponementDate
        {
            get { return _StatusDb.HasPostponementDate; }
            set { _StatusDb.HasPostponementDate = value; }
        }
     

        public DateTime PostponementDate
        {
            get { return _StatusDb.PostponementDate; }
            set { _StatusDb.PostponementDate = value; }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                switch (Status)
                {
                    case TicketStatus.Canceled: Returned = "الغاء"; break;
                    case TicketStatus.Created: Returned = "جديد"; break;
                    case TicketStatus.Ended: Returned = "انتهاء"; break;
                    case TicketStatus.NotSpecified: Returned = "غير محدد"; break;
                    case TicketStatus.Processing: Returned = "فى المعالجة"; break;
                    case TicketStatus.Waiting: Returned = "انتظار"; break;
                    default: Returned = "غير محدد"; break;
                }

                return Returned;
            }
        }
        public static List<string> StatusStrArr
        {
            get 
            {
                List<string> Returned = new List<string>();
                Returned.Add("غير محدد");
                Returned.Add("جديدة");
                Returned.Add("تحت المعالجة");
                Returned.Add("تنتظر");
                Returned.Add("الغاء");
                Returned.Add("تم");
                return Returned;
            }
        }
        public string Desc
        {
            get { return _StatusDb.Desc; }
            set { _StatusDb.Desc = value; }
        }
     
        public int EmployeeID
        {
            get { return _StatusDb.EmployeeID; }
            set { _StatusDb.EmployeeID = value; }
        }
        EmployeeBiz _EmployeeBiz;

        public EmployeeBiz EmployeeBiz
        {
            get {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz; }
            set { _EmployeeBiz = value; }
        }

        public DateTime Date
        {
            get { return _StatusDb.Date; }
            set { _StatusDb.Date = value; }
        }
        public string UsrName
        {
            get { return _StatusDb.UsrName; }
            set { _StatusDb.UsrName = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
