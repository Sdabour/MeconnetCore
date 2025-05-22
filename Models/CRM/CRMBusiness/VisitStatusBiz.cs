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
    public class VisitStatusBiz
    {
        #region Private Data
        VisitStatusDb _StatusDb;

        #endregion
        #region Constructors
        public VisitStatusBiz()
        {
            _StatusDb = new VisitStatusDb();
        }
        public VisitStatusBiz(DataRow objDr)
        {
            _StatusDb = new VisitStatusDb(objDr);
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


        public ContactStatus Status
        {
            get { return (ContactStatus)_StatusDb.Status; }
            set { _StatusDb.Status = (int)value; }
        }


        public FunctionalContactStatus FunctionalStatus
        {
            get { return (FunctionalContactStatus)_StatusDb.FunctionalStatus; }
            set { _StatusDb.FunctionalStatus = (int)value; }
        }
  
        public string StatusStr
        {
            get
            {
                string Returned = "";
                //switch (Status)
               Returned = CampaignCustomerContactBiz.StatusLst[(int)Status];
                return Returned;
            }
        }
        public string FunctionalStatusStr
        {
            get
            {
                string Returned = "";
                //switch (Status)
                Returned = CampaignCustomerContactBiz.FunctionalStatusLst[(int)FunctionalStatus];
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
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
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
