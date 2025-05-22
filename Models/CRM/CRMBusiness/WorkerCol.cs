using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.Base.BaseBusiness;
//using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class WorkerCol : BaseCol
    {
        public WorkerCol()
        {
            WorkerDb objWorkerDb = new WorkerDb();
            DataTable dtWorker = objWorkerDb.Search();
            WorkerBiz objWorkerBiz;
            foreach (DataRow objDr in dtWorker.Rows)
            {
                objWorkerBiz = new WorkerBiz(objDr);
                this.Add(objWorkerBiz);
            }
        }
        public WorkerCol(string strFirstName, string strMdileName, string strLastName, double dblStartSalary, double dblCurrentSalary, DateTime dtStartDate,int intStartSalaryCurrency ,int intUserID,int intGroupID)
        {
            WorkerDb objDb = new WorkerDb();
            objDb.FirstNameLike = strFirstName;
            objDb.MideleNameLike = strMdileName;
            objDb.LastNameLike = strLastName;
            objDb.StartDate = dtStartDate;
            objDb.CurrentSalary = dblCurrentSalary;
            objDb.SatrtSalary = dblStartSalary;
            objDb.StartSalaryCurrency = intStartSalaryCurrency;
            objDb.User = intUserID;
            objDb.Group = intGroupID;
            DataTable dtWorker = objDb.Search();
            WorkerBiz objWorkerBiz;
            foreach (DataRow objDR in dtWorker.Rows)
            {
                objWorkerBiz = new WorkerBiz(objDR);
                this.Add(objWorkerBiz);
            }
        }
        public WorkerCol(bool blIsEmpty)
        {
             if (!blIsEmpty)
            {
                WorkerBiz objWorkerBiz;
                objWorkerBiz = new WorkerBiz();
                objWorkerBiz.ID = 0;
                objWorkerBiz.Name = "€Ì— „Õœœ";
                this.Add(objWorkerBiz);
                WorkerDb objWorkerDb = new WorkerDb();
                DataTable dtWorker = objWorkerDb.Search();


                foreach (DataRow objDr in dtWorker.Rows)
                {

                  objWorkerBiz = new WorkerBiz(objDr);
                  this.Add(objWorkerBiz);

                }
            }





        }
        public WorkerCol(int intID)
        {
            WorkerDb objDb = new WorkerDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new WorkerBiz(objDr));
            }
        }



        public WorkerBiz this[int intIndex]
        {

            get
            {
                return (WorkerBiz)List[intIndex];
            }
        }

        public void Add(WorkerBiz objBiz)
        {
            List.Add(objBiz);

        }

    }
}
    
