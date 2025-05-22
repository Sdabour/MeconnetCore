using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class TaskDb
    {

        #region Constructor
        public TaskDb()
        {
        }
        public TaskDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        int _Project;
        public int Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }
        }
        int _Parent;
        public int Parent
        {
            set
            {
                _Parent = value;
            }
            get
            {
                return _Parent;
            }
        }
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        string _Desc;
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        string _ShortDesc;
        public string ShortDesc
        {
            set
            {
                _ShortDesc = value;
            }
            get
            {
                return _ShortDesc;
            }
        }
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        int _EstimatedPeriod;
        public int EstimatedPeriod
        {
            set
            {
                _EstimatedPeriod = value;
            }
            get
            {
                return _EstimatedPeriod;
            }
        }
        int _EstimatedPeriodType;
        public int EstimatedPeriodType
        {
            set
            {
                _EstimatedPeriodType = value;
            }
            get
            {
                return _EstimatedPeriodType;
            }
        }
        DateTime _EndDate;
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        int _IterationType;
        public int IterationType
        {
            set
            {
                _IterationType = value;
            }
            get
            {
                return _IterationType;
            }
        }
        int _WorkerCreator;
        public int WorkerCreator
        {
            set
            {
                _WorkerCreator = value;
            }
            get
            {
                return _WorkerCreator;
            }
        }
        int _WokGroup;
        public int WokGroup
        {
            set
            {
                _WokGroup = value;
            }
            get
            {
                return _WokGroup;
            }
        }
        int _AssignedWorker;
        public int AssignedWorker
        {
            set
            {
                _AssignedWorker = value;
            }
            get
            {
                return _AssignedWorker;
            }
        }
        int _Status;
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        bool _Completed;
        public bool Completed
        {
            set
            {
                _Completed = value;
            }
            get
            {
                return _Completed;
            }
        }
        DateTime _CompletedDate;
        public DateTime CompletedDate
        {
            set
            {
                _CompletedDate = value;
            }
            get
            {
                return _CompletedDate;
            }
        }
        int _EvaluationCategory;
        public int EvaluationCategory
        {
            set
            {
                _EvaluationCategory = value;
            }
            get
            {
                return _EvaluationCategory;
            }
        }
        int _Evaluation;
        public int Evaluation
        {
            set
            {
                _Evaluation = value;
            }
            get
            {
                return _Evaluation;
            }
        }
        DateTime _PostponementDate;
        public DateTime PostponementDate
        {
            set
            {
                _PostponementDate = value;
            }
            get
            {
                return _PostponementDate;
            }
        }
        bool _IsPostponed;
        public bool IsPostponed
        {
            set
            {
                _IsPostponed = value;
            }
            get
            {
                return _IsPostponed;
            }
        }
        int _CreatorApplicantID;
        public int CreatorApplicantID
        {
            set
            {
                _CreatorApplicantID = value;
            }
            get
            {
                return _CreatorApplicantID;
            }
        }
        string _CreatorApplicantCode;
        public string CreatorApplicantCode
        {
            set
            {
                _CreatorApplicantCode = value;
            }
            get
            {
                return _CreatorApplicantCode;
            }
        }
        string _CreatorApplicantName;
        public string CreatorApplicantName
        {
            set
            {
                _CreatorApplicantName = value;
            }
            get
            {
                return _CreatorApplicantName;
            }
        }
        int _AssignedApplicantID;
        public int AssignedApplicantID
        {
            set
            {
                _AssignedApplicantID = value;
            }
            get
            {
                return _AssignedApplicantID;
            }
        }
        string _AssignedApplicantCode;
        public string AssignedApplicantCode
        {
            set
            {
                _AssignedApplicantCode = value;
            }
            get
            {
                return _AssignedApplicantCode;
            }
        }
        string _AssignedApplicantName;
        public string AssignedApplicantName
        {
            set
            {
                _AssignedApplicantName = value;
            }
            get
            {
                return _AssignedApplicantName;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into PLNTask (TaskProject,TaskParent,TaskType,TaskDesc,TaskShortDesc,TaskDate,TaskEstimatedPeriod,TaskEstimatedPeriodType,TaskEndDate,TaskIterationType,TaskWorkerCreator,TaskWokGroup,TaskAssignedWorker,TaskStatus,TaskCompleted,TaskCompletedDate,TaskEvaluationCategory,TaskEvaluation,TaskPostponementDate,TaskIsPostponed,CreatorApplicantID,CreatorApplicantCode,CreatorApplicantName,AssignedApplicantID,AssignedApplicantCode,AssignedApplicantName,UsrIns,TimIns) values (" + Project + "," + Parent + "," + Type + ",'" + Desc + "','" + ShortDesc + "'," + (Date.ToOADate() - 2).ToString() + "," + EstimatedPeriod + "," + EstimatedPeriodType + "," + (EndDate.ToOADate() - 2).ToString() + "," + IterationType + "," + WorkerCreator + "," + WokGroup + "," + AssignedWorker + "," + Status + "," + (Completed ? 1 : 0) + "," + (CompletedDate.ToOADate() - 2).ToString() + "," + EvaluationCategory + "," + Evaluation + "," + (PostponementDate.ToOADate() - 2).ToString() + "," + (IsPostponed ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update PLNTask set TaskProject=" + Project + "" +
           ",TaskParent=" + Parent + "" +
           ",TaskType=" + Type + "" +
           ",TaskDesc='" + Desc + "'" +
           ",TaskShortDesc='" + ShortDesc + "'" +
           ",TaskDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",TaskEstimatedPeriod=" + EstimatedPeriod + "" +
           ",TaskEstimatedPeriodType=" + EstimatedPeriodType + "" +
           ",TaskEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",TaskIterationType=" + IterationType + "" +
           ",TaskWorkerCreator=" + WorkerCreator + "" +
           ",TaskWokGroup=" + WokGroup + "" +
           ",TaskAssignedWorker=" + AssignedWorker + "" +
           ",TaskStatus=" + Status + "" +
           ",TaskCompleted=" + (Completed ? 1 : 0) + "" +
           ",TaskCompletedDate=" + (CompletedDate.ToOADate() - 2).ToString() + "" +
           ",TaskEvaluationCategory=" + EvaluationCategory + "" +
           ",TaskEvaluation=" + Evaluation + "" +
           ",TaskPostponementDate=" + (PostponementDate.ToOADate() - 2).ToString() + "" +
           ",TaskIsPostponed=" + (IsPostponed ? 1 : 0) + "" +
            ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where TaskID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update PLNTask set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT        dbo.PLNTask.TaskID, dbo.PLNTask.TaskProject, dbo.PLNTask.TaskParent, dbo.PLNTask.TaskType, dbo.PLNTask.TaskDesc, dbo.PLNTask.TaskShortDesc, dbo.PLNTask.TaskDate, dbo.PLNTask.TaskEstimatedPeriod, 
                         dbo.PLNTask.TaskEstimatedPeriodType, dbo.PLNTask.TaskEndDate, dbo.PLNTask.TaskIterationType, dbo.PLNTask.TaskWorkerCreator, dbo.PLNTask.TaskWokGroup, dbo.PLNTask.TaskAssignedWorker, 
                         dbo.PLNTask.TaskStatus, dbo.PLNTask.TaskCompleted, dbo.PLNTask.TaskCompletedDate, dbo.PLNTask.TaskEvaluationCategory, dbo.PLNTask.TaskEvaluation, dbo.PLNTask.TaskPostponementDate, 
                         dbo.PLNTask.TaskIsPostponed, CreatorApplicantTable.CreatorApplicantID, CreatorApplicantTable.CreatorApplicantCode, CreatorApplicantTable.CreatorApplicantName, AssignedApplicantTable.AssignedApplicantID, 
                         AssignedApplicantTable.AssignedApplicantCode, AssignedApplicantTable.AssignedApplicantName
FROM            dbo.PLNTask LEFT OUTER JOIN
                             (SELECT        HRApplicant_1.ApplicantID AS AssignedApplicantID, HRApplicantWorker_1.ApplicantCode AS AssignedApplicantCode, HRApplicant_1.ApplicantFirstName AS AssignedApplicantName
                                FROM            dbo.HRApplicant AS HRApplicant_1 INNER JOIN
                                                         dbo.HRApplicantWorker AS HRApplicantWorker_1 ON HRApplicant_1.ApplicantID = HRApplicantWorker_1.ApplicantID) AS AssignedApplicantTable ON 
                         dbo.PLNTask.TaskAssignedWorker = AssignedApplicantTable.AssignedApplicantID LEFT OUTER JOIN
                             (SELECT        dbo.HRApplicant.ApplicantID AS CreatorApplicantID, dbo.HRApplicantWorker.ApplicantCode AS CreatorApplicantCode, dbo.HRApplicant.ApplicantFirstName AS CreatorApplicantName
                                FROM            dbo.HRApplicant INNER JOIN
                                                         dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID) AS CreatorApplicantTable ON dbo.PLNTask.TaskWorkerCreator = CreatorApplicantTable.CreatorApplicantID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["TaskID"] != null)
                int.TryParse(objDr["TaskID"].ToString(), out _ID);

            if (objDr.Table.Columns["TaskProject"] != null)
                int.TryParse(objDr["TaskProject"].ToString(), out _Project);

            if (objDr.Table.Columns["TaskParent"] != null)
                int.TryParse(objDr["TaskParent"].ToString(), out _Parent);

            if (objDr.Table.Columns["TaskType"] != null)
                int.TryParse(objDr["TaskType"].ToString(), out _Type);

            if (objDr.Table.Columns["TaskDesc"] != null)
                _Desc = objDr["TaskDesc"].ToString();

            if (objDr.Table.Columns["TaskShortDesc"] != null)
                _ShortDesc = objDr["TaskShortDesc"].ToString();

            if (objDr.Table.Columns["TaskDate"] != null)
                DateTime.TryParse(objDr["TaskDate"].ToString(), out _Date);

            if (objDr.Table.Columns["TaskEstimatedPeriod"] != null)
                int.TryParse(objDr["TaskEstimatedPeriod"].ToString(), out _EstimatedPeriod);

            if (objDr.Table.Columns["TaskEstimatedPeriodType"] != null)
                int.TryParse(objDr["TaskEstimatedPeriodType"].ToString(), out _EstimatedPeriodType);

            if (objDr.Table.Columns["TaskEndDate"] != null)
                DateTime.TryParse(objDr["TaskEndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["TaskIterationType"] != null)
                int.TryParse(objDr["TaskIterationType"].ToString(), out _IterationType);

            if (objDr.Table.Columns["TaskWorkerCreator"] != null)
                int.TryParse(objDr["TaskWorkerCreator"].ToString(), out _WorkerCreator);

            if (objDr.Table.Columns["TaskWokGroup"] != null)
                int.TryParse(objDr["TaskWokGroup"].ToString(), out _WokGroup);

            if (objDr.Table.Columns["TaskAssignedWorker"] != null)
                int.TryParse(objDr["TaskAssignedWorker"].ToString(), out _AssignedWorker);

            if (objDr.Table.Columns["TaskStatus"] != null)
                int.TryParse(objDr["TaskStatus"].ToString(), out _Status);

            if (objDr.Table.Columns["TaskCompleted"] != null)
                bool.TryParse(objDr["TaskCompleted"].ToString(), out _Completed);

            if (objDr.Table.Columns["TaskCompletedDate"] != null)
                DateTime.TryParse(objDr["TaskCompletedDate"].ToString(), out _CompletedDate);

            if (objDr.Table.Columns["TaskEvaluationCategory"] != null)
                int.TryParse(objDr["TaskEvaluationCategory"].ToString(), out _EvaluationCategory);

            if (objDr.Table.Columns["TaskEvaluation"] != null)
                int.TryParse(objDr["TaskEvaluation"].ToString(), out _Evaluation);

            if (objDr.Table.Columns["TaskPostponementDate"] != null)
                DateTime.TryParse(objDr["TaskPostponementDate"].ToString(), out _PostponementDate);

            if (objDr.Table.Columns["TaskIsPostponed"] != null)
                bool.TryParse(objDr["TaskIsPostponed"].ToString(), out _IsPostponed);

            if (objDr.Table.Columns["CreatorApplicantID"] != null)
                int.TryParse(objDr["CreatorApplicantID"].ToString(), out _CreatorApplicantID);

            if (objDr.Table.Columns["CreatorApplicantCode"] != null)
                _CreatorApplicantCode = objDr["CreatorApplicantCode"].ToString();

            if (objDr.Table.Columns["CreatorApplicantName"] != null)
                _CreatorApplicantName = objDr["CreatorApplicantName"].ToString();

            if (objDr.Table.Columns["AssignedApplicantID"] != null)
                int.TryParse(objDr["AssignedApplicantID"].ToString(), out _AssignedApplicantID);

            if (objDr.Table.Columns["AssignedApplicantCode"] != null)
                _AssignedApplicantCode = objDr["AssignedApplicantCode"].ToString();

            if (objDr.Table.Columns["AssignedApplicantName"] != null)
                _AssignedApplicantName = objDr["AssignedApplicantName"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (ID != 0)
                strSql += " and TaskID = "+ID;


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}