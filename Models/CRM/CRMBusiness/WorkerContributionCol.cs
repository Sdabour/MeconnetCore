using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;


namespace SharpVision.CRM.CRMBusiness
{
    public class WorkerContributionCol : BaseCol
    {
         public WorkerContributionCol(bool blIsempty)
        {

        }
        public WorkerContributionCol()
        {
            
        }

        public WorkerContributionBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (WorkerContributionBiz)List[intIndex];
            }
        }


        public void Add(WorkerContributionBiz objBiz)
        {
            int intIndex = GetIndex(objBiz);
            if (intIndex == -1)
                List.Add(objBiz);
            else
            {
                this[intIndex].ContributionPerc = objBiz.ContributionPerc;
            }
 
        }
        public int GetIndex(WorkerContributionBiz objBiz)
        {
            int Returned = -1;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].SalesManBiz.ID == objBiz.SalesManBiz.ID)
                {
                    Returned = intIndex;
                    break;
                }
            }
            return Returned;
        }
        public double TotalPerc
        {
            get
            {
                double dblReturned = 0;
                foreach (WorkerContributionBiz  objBiz in this)
                {
                    dblReturned = dblReturned + objBiz.ContributionPerc;
                }
                return dblReturned;
            }
        }
        
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("Worker");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ReservationID"), new DataColumn("WorkerID"), new DataColumn("ContributionPerc"), new DataColumn("ContributionValue"), new DataColumn("PaidValue") 
            , new DataColumn("Finished")});
            DataRow objDr;
            foreach (WorkerContributionBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ReservationID"] = objBiz.ReservationID;
                objDr["WorkerID"] = objBiz.SalesManBiz.ID;
                objDr["ContributionPerc"] = objBiz.ContributionPerc;
                objDr["ContributionValue"] = objBiz.ContributionValue;
                objDr["PaidValue"] = objBiz.PaidValue;
                objDr["Finished"] = objBiz.Finished;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
    }
}
