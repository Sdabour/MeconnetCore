using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRDataBase;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class TaskCol:CollectionBase
    {

        #region Constructor
        public TaskCol()
        {

        }
        public TaskCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TaskBiz objBiz = new TaskBiz();
           

            TaskDb objDb = new TaskDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TaskBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TaskBiz this[int intIndex]
        {
            get
            {
                return (TaskBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TaskBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TaskCol GetCol(string strTemp)
        {
            TaskCol Returned = new TaskCol(true);
            foreach (TaskBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TaskID"), new DataColumn("TaskProject"), new DataColumn("TaskParent"), new DataColumn("TaskType"), new DataColumn("TaskDesc"), new DataColumn("TaskShortDesc"), new DataColumn("TaskDate", System.Type.GetType("System.DateTime")), new DataColumn("TaskEstimatedPeriod"), new DataColumn("TaskEstimatedPeriodType"), new DataColumn("TaskEndDate", System.Type.GetType("System.DateTime")), new DataColumn("TaskIterationType"), new DataColumn("TaskWorkerCreator"), new DataColumn("TaskWokGroup"), new DataColumn("TaskAssignedWorker"), new DataColumn("TaskStatus"), new DataColumn("TaskCompleted", System.Type.GetType("System.Boolean")), new DataColumn("TaskCompletedDate", System.Type.GetType("System.DateTime")), new DataColumn("TaskEvaluationCategory"), new DataColumn("TaskEvaluation"), new DataColumn("TaskPostponementDate", System.Type.GetType("System.DateTime")), new DataColumn("TaskIsPostponed", System.Type.GetType("System.Boolean")), new DataColumn("CreatorApplicantID"), new DataColumn("CreatorApplicantCode"), new DataColumn("CreatorApplicantName"), new DataColumn("AssignedApplicantID"), new DataColumn("AssignedApplicantCode"), new DataColumn("AssignedApplicantName") });
            DataRow objDr;
            foreach (TaskBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TaskID"] = objBiz.ID;
                objDr["TaskProject"] = objBiz.Project;
                objDr["TaskParent"] = objBiz.Parent;
                objDr["TaskType"] = objBiz.Type;
                objDr["TaskDesc"] = objBiz.Desc;
                objDr["TaskShortDesc"] = objBiz.ShortDesc;
                objDr["TaskDate"] = objBiz.Date;
                objDr["TaskEstimatedPeriod"] = objBiz.EstimatedPeriod;
                objDr["TaskEstimatedPeriodType"] = objBiz.EstimatedPeriodType;
                objDr["TaskEndDate"] = objBiz.EndDate;
                objDr["TaskIterationType"] = objBiz.IterationType;
                objDr["TaskWorkerCreator"] = objBiz.WorkerCreator;
                objDr["TaskWokGroup"] = objBiz.WokGroup;
                objDr["TaskAssignedWorker"] = objBiz.AssignedWorker;
                objDr["TaskStatus"] = objBiz.Status;
                objDr["TaskCompleted"] = objBiz.Completed;
                objDr["TaskCompletedDate"] = objBiz.CompletedDate;
                objDr["TaskEvaluationCategory"] = objBiz.EvaluationCategory;
                objDr["TaskEvaluation"] = objBiz.Evaluation;
                objDr["TaskPostponementDate"] = objBiz.PostponementDate;
                objDr["TaskIsPostponed"] = objBiz.IsPostponed;
                objDr["CreatorApplicantID"] = objBiz.CreatorApplicantID;
                objDr["CreatorApplicantCode"] = objBiz.CreatorApplicantCode;
                objDr["CreatorApplicantName"] = objBiz.CreatorApplicantName;
                objDr["AssignedApplicantID"] = objBiz.AssignedApplicantID;
                objDr["AssignedApplicantCode"] = objBiz.AssignedApplicantCode;
                objDr["AssignedApplicantName"] = objBiz.AssignedApplicantName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}