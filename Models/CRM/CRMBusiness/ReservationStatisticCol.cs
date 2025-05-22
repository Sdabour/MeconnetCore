using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.HR.HRBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationStatisticCol : BaseCol
    {
        public ReservationStatisticCol(bool blIsempty)
        {
            ReservationStatisticBiz objBiz;
            objBiz = new ReservationStatisticBiz();
            ReservationStatisticDb objDb = new ReservationStatisticDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationStatisticBiz(objDr));
            }
        }
        public ReservationStatisticCol(int intID)
        {
            ReservationStatisticDb objDb = new ReservationStatisticDb();
            objDb.WorkerID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationStatisticBiz(objDr));
            }
        }
       public ReservationStatisticCol(WorkerBiz objWorkerBiz,BranchBiz objBranchBiz,CellBiz objCellBiz,DateTime dtFrom,DateTime dtTo)
       {
           ReservationStatisticDb objDb = new ReservationStatisticDb();
           objDb.WorkerID = objWorkerBiz.ID;
           objDb.BranchID = objBranchBiz.ID;
           objDb.CellID = objCellBiz.ID;
           objDb.DtFrom = dtFrom;
           objDb.DtTo = dtTo;
           DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationStatisticBiz(objDr));
            }
       }
        public ReservationStatisticBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationStatisticBiz)List[intIndex];
            }
        }

        public void Add(ReservationStatisticBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
