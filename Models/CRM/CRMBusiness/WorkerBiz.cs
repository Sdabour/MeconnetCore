using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
//using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class WorkerBiz
    {
        #region Private Data
        WorkerDb _WorkerDb;
        UserBiz _UserBiz;
        GroupBiz _GroupBiz;
        IDTypeInstantBiz _IDTypeInstantBiz;
        
        JobBiz _JobBiz;
       
        string _Name;
        #endregion
        #region Constructors
        public WorkerBiz()
        {
            _WorkerDb = new WorkerDb();
        }
        public WorkerBiz(int intID)
        {
            _WorkerDb = new WorkerDb(intID);
        }
        public WorkerBiz(DataRow objDR)
        {
            _WorkerDb = new WorkerDb(objDR);
           
            _JobBiz = new JobBiz(_WorkerDb.WorkerJobDb);
           
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _WorkerDb.ID = value;
            }
            get
            {
                return _WorkerDb.ID;
            }
        }
        public string FirstName
        {
            set
            {
                _WorkerDb.FirstName = value;
            }
            get
            {
                return _WorkerDb.FirstName;
            }

        }
        public string MidleName
        {
            set
            {
                _WorkerDb.MidleName = value;
            }
            get
            {
                return _WorkerDb.MidleName;
            }

        }
        public string LastName
        {
            set
            {
                _WorkerDb.LastName = value;
            }
            get
            {
                return _WorkerDb.LastName;
            }

        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return FirstName + " " + MidleName + " " + LastName;
            }
        }

        public string IDValue
        {
            set
            {
                _WorkerDb.IDValue = value;
            }
            get
            {
                return _WorkerDb.IDValue;
            }
        }
        public IDTypeInstantBiz IDTypeInstantBiz
        {
            set
            {
                _IDTypeInstantBiz = value;
                _WorkerDb.IDTypeInstantDb = new IDTypeInstantDb(_IDTypeInstantBiz.ID, _IDTypeInstantBiz.Name, _IDTypeInstantBiz.IDValue);
            }
            get
            {
                return _IDTypeInstantBiz;
            }
        }
        
        public GroupBiz GroupBiz
        {
            set
            {
                _GroupBiz = value;
            }
            get
            {
                return _GroupBiz;
            }

        }
        public UserBiz UserBiz
        {
            set
            {
                _UserBiz = value;
            }
            get
            {
                return _UserBiz;
            }

        }
        public DateTime StartDate
        {
            set
            {
                _WorkerDb.StartDate = value;
            }
            get
            {
                return _WorkerDb.StartDate;
            }

        }
        public double SatrtSalary
        {
            set
            {
                _WorkerDb.SatrtSalary = value;
            }
            get
            {
                return _WorkerDb.SatrtSalary;
            }

        }
        public int StartSalaryCurrency
        {
            set
            {
                _WorkerDb.StartSalaryCurrency = value;
            }
            get
            {
                return _WorkerDb.StartSalaryCurrency;
            }

        }
        public double CurrentSalary
        {
            set
            {
                _WorkerDb.CurrentSalary = value;
            }
            get
            {
                return _WorkerDb.CurrentSalary;
            }

        }
        public int User
        {
            set
            {
                _WorkerDb.User = value;
            }
            get
            {
                return _WorkerDb.User;
            }

        }
        public int Group
        {
            set
            {
                _WorkerDb.Group = value;
            }
            get
            {
                return _WorkerDb.Group;
            }

        }
       
        public JobBiz JobBiz
        {
            set
            {
                _JobBiz = value;
            }
            get
            {
                return _JobBiz;
            }
        }
   
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _WorkerDb.Group = _GroupBiz.ID;
            _WorkerDb.IDType = _IDTypeInstantBiz.ID;
            //_WorkerDb.SubSectorID = _SubSectorBiz.ID;
            _WorkerDb.JobID = _JobBiz.ID;
            //_WorkerDb.TitleID = _TitleBiz.ID;
            //_WorkerDb.DegreeID = _DegreeBiz.ID;
            _WorkerDb.Add();
        }
        public void Edit()
        {
            _WorkerDb.Group = _GroupBiz.ID;
            _WorkerDb.IDType = _IDTypeInstantBiz.ID;
           // _WorkerDb.SubSectorID = _SubSectorBiz.ID;
            _WorkerDb.JobID = _JobBiz.ID;
            //_WorkerDb.TitleID = _TitleBiz.ID;
           // _WorkerDb.DegreeID = _DegreeBiz.ID;
            _WorkerDb.Edit();
        }
        public void Delete()
        {
            _WorkerDb.Delete();
        }


        //public static void Add(string strFirstName, string strMidleName, string strLastName, string strIDValue, DateTime dtStartDate, double dblSatrtSalary, int intStartSalaryCurrency, double dblCurrentSalary, int intUser, int intGroup, int intIDType)
        //{
        //    WorkerDb objWorkerDb = new WorkerDb();
        //    objWorkerDb.FirstName = strFirstName;
        //    objWorkerDb.MidleName = strMidleName;
        //    objWorkerDb.LastName = strLastName;
        //    objWorkerDb.IDValue = strIDValue;
        //    objWorkerDb.IDType = intIDType;
        //    objWorkerDb.StartDate = dtStartDate;
        //    objWorkerDb.StartSalaryCurrency = intStartSalaryCurrency;
        //    objWorkerDb.CurrentSalary = dblCurrentSalary;
        //    objWorkerDb.SatrtSalary = dblSatrtSalary;
        //    objWorkerDb.User = intUser;
        //    objWorkerDb.Group = intGroup;
        //    objWorkerDb.Add();
        //}
        //public static void Edit(int intID,string strFirstName, string strMidleName, string strLastName, string strIDValue, DateTime dtStartDate, double dblSatrtSalary, int intStartSalaryCurrency, double dblCurrentSalary, int intUser, int intGroup, int intIDType)
        //{
        //    WorkerDb objWorkerDb = new WorkerDb();
        //    objWorkerDb.ID = intID;
        //    objWorkerDb.FirstName = strFirstName;
        //    objWorkerDb.MidleName = strMidleName;
        //    objWorkerDb.LastName = strLastName;
        //    objWorkerDb.IDValue = strIDValue;
        //    objWorkerDb.IDType = intIDType;
        //    objWorkerDb.StartDate = dtStartDate;
        //    objWorkerDb.StartSalaryCurrency = intStartSalaryCurrency;
        //    objWorkerDb.CurrentSalary = dblCurrentSalary;
        //    objWorkerDb.SatrtSalary = dblSatrtSalary;
        //    objWorkerDb.User = intUser;
        //    objWorkerDb.Group = intGroup;
        //    objWorkerDb.Edit();
        //}
        //public static void Delete(int intID)
        //{
        //    WorkerDb objWorkerDb = new WorkerDb();
        //    objWorkerDb.ID = intID;
        //    objWorkerDb.Delete();
        //}
        #endregion
    }
}
