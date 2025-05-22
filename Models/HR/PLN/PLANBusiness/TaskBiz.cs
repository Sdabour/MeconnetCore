using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public enum TaskIterationType
    {
        NotSpecified,
        OneTime,
        Daily,
        Monthly,
        Yearly,
        Periodicaly
    }
    public enum TaskStatus
    {
        NotSpecified,
        Created,
        Processing,
        Canceled,
        Done,
        Waiting
    }
    public enum PeriodType
    {
        NotSpecified,
        Hour,
        Day,
        Week,
        Month
    }
    public class TaskBiz
    {

        #region Constructor
        public TaskBiz()
        {
            _TaskDb = new TaskDb();
        }
        public TaskBiz(int intID)
        {
           
            _TaskDb = new TaskDb();
            if (intID == 0)
                return;
            TaskDb objDb = new TaskDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                _TaskDb = new TaskDb(dtTemp.Rows[0]);

            }
        }
        public TaskBiz(DataRow objDr)
        {
            _TaskDb = new TaskDb(objDr);
        }

        #endregion
        #region Private Data
        TaskDb _TaskDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _TaskDb.ID = value;
            }
            get
            {
                return _TaskDb.ID;
            }
        }
        public int Project
        {
            set
            {
                _TaskDb.Project = value;
            }
            get
            {
                return _TaskDb.Project;
            }
        }
        public int Parent
        {
            set
            {
                _TaskDb.Parent = value;
            }
            get
            {
                return _TaskDb.Parent;
            }
        }
        public int Type
        {
            set
            {
                _TaskDb.Type = value;
            }
            get
            {
                return _TaskDb.Type;
            }
        }
        public string Desc
        {
            set
            {
                _TaskDb.Desc = value;
            }
            get
            {
                return _TaskDb.Desc;
            }
        }
        public string ShortDesc
        {
            set
            {
                _TaskDb.ShortDesc = value;
            }
            get
            {
                return _TaskDb.ShortDesc;
            }
        }
        public DateTime Date
        {
            set
            {
                _TaskDb.Date = value;
            }
            get
            {
                return _TaskDb.Date;
            }
        }
        public int EstimatedPeriod
        {
            set
            {
                _TaskDb.EstimatedPeriod = value;
            }
            get
            {
                return _TaskDb.EstimatedPeriod;
            }
        }
        public PeriodType EstimatedPeriodType
        {
            set
            {
                _TaskDb.EstimatedPeriodType =(int) value;
            }
            get
            {
                return (PeriodType)_TaskDb.EstimatedPeriodType;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _TaskDb.EndDate = value;
            }
            get
            {
                return _TaskDb.EndDate;
            }
        }
        public static List<string> IterationTypeList
        {
            get
            {
                List<string> Returned = new List<string>();
                // NotSpecified,
                Returned.Add("غير محدد");
                //  OneTime,
                Returned.Add("مرة واحدة");
                // Daily,
                Returned.Add("يوميا");
                // Monthly,
                Returned.Add("شهرى");
                //Yearly,
                Returned.Add("سنوى");
                //Periodicaly
                Returned.Add("بشكل دورى");
                return Returned;
            }
        }
        public static List<string> PeriodTypeList
        {
            get
            {
                List<string> Returned = new List<string>();
                //   NotSpecified,
                Returned.Add("غير محدد");
                //Hour,
                Returned.Add("ساعة");
                //Day,
                Returned.Add("يوم");
                // Week,
                Returned.Add("اسبوع");
                //Month
                Returned.Add("شهر");
                return Returned;
            }
        }
        public string IterationTypeStr
        { get => IterationTypeList[(int)IterationType]; }
        public TaskIterationType IterationType
        {
            set
            {
                _TaskDb.IterationType = (int)value;
            }
            get
            {
                return (TaskIterationType)_TaskDb.IterationType;
            }
        }
        ApplicantWorkerBiz _EmployeeCreator;
        public ApplicantWorkerBiz EmployeeCreator
        {
            set => _EmployeeCreator = value;
            get
            {
                if (_EmployeeCreator == null)
                    _EmployeeCreator = new ApplicantWorkerBiz();
                return _EmployeeCreator;
            }
        }
        public int WorkerCreator
        {
            set
            {
                _TaskDb.WorkerCreator = value;
            }
            get
            {
                return _TaskDb.WorkerCreator;
            }
        }
        public int WokGroup
        {
            set
            {
                _TaskDb.WokGroup = value;
            }
            get
            {
                return _TaskDb.WokGroup;
            }
        }
        ApplicantWorkerBiz _EmployeeAssigned;
        public ApplicantWorkerBiz EmployeeAssigned
        {
            set => _EmployeeAssigned = value;
            get
            {
                if (_EmployeeAssigned == null)
                    _EmployeeAssigned = new ApplicantWorkerBiz();
                return _EmployeeAssigned;
            }
        }
        public int AssignedWorker
        {
            set
            {
                _TaskDb.AssignedWorker = value;
            }
            get
            {
                return _TaskDb.AssignedWorker;
            }
        }
        public static List<string> StatusLst
        {
            get
            {
                List<string> Returned = new List<string>();
                //   NotSpecified,
                Returned.Add("غير محدد");
                //Created,
                Returned.Add("جديد");
                //Processing,
                Returned.Add("فى المعالجة");
                //Canceled,
                Returned.Add("ملغى");
                //Done,
                Returned.Add("تم");
                //Waiting
                Returned.Add("ينتظر");
                return Returned;
            }
        }
        public TaskStatus Status
        {
            set
            {
                _TaskDb.Status = (int)value;
            }
            get
            {
                return (TaskStatus)_TaskDb.Status;
            }
        }
        public string StatusStr
        {
            get => StatusLst[(int)Status];
        }

        public bool Completed
        {
            set
            {
                _TaskDb.Completed = value;
            }
            get
            {
                return _TaskDb.Completed;
            }
        }
        public DateTime CompletedDate
        {
            set
            {
                _TaskDb.CompletedDate = value;
            }
            get
            {
                return _TaskDb.CompletedDate;
            }
        }
        public int EvaluationCategory
        {
            set
            {
                _TaskDb.EvaluationCategory = value;
            }
            get
            {
                return _TaskDb.EvaluationCategory;
            }
        }
        public int Evaluation
        {
            set
            {
                _TaskDb.Evaluation = value;
            }
            get
            {
                return _TaskDb.Evaluation;
            }
        }
        public DateTime PostponementDate
        {
            set
            {
                _TaskDb.PostponementDate = value;
            }
            get
            {
                return _TaskDb.PostponementDate;
            }
        }
        public bool IsPostponed
        {
            set
            {
                _TaskDb.IsPostponed = value;
            }
            get
            {
                return _TaskDb.IsPostponed;
            }
        }
        public int CreatorApplicantID
        {
            set
            {
                _TaskDb.CreatorApplicantID = value;
            }
            get
            {
                return _TaskDb.CreatorApplicantID;
            }
        }
        public string CreatorApplicantCode
        {
            set
            {
                _TaskDb.CreatorApplicantCode = value;
            }
            get
            {
                return _TaskDb.CreatorApplicantCode;
            }
        }
        public string CreatorApplicantName
        {
            set
            {
                _TaskDb.CreatorApplicantName = value;
            }
            get
            {
                return _TaskDb.CreatorApplicantName;
            }
        }
        public int AssignedApplicantID
        {
            set
            {
                _TaskDb.AssignedApplicantID = value;
            }
            get
            {
                return _TaskDb.AssignedApplicantID;
            }
        }
        public string AssignedApplicantCode
        {
            set
            {
                _TaskDb.AssignedApplicantCode = value;
            }
            get
            {
                return _TaskDb.AssignedApplicantCode;
            }
        }
        public string AssignedApplicantName
        {
            set
            {
                _TaskDb.AssignedApplicantName = value;
            }
            get
            {
                return _TaskDb.AssignedApplicantName;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _TaskDb.Add();
        }
        public void Edit()
        {
            _TaskDb.Edit();
        }
        public void Delete()
        {
            _TaskDb.Delete();
        }
        #endregion
    }
}