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
    public class ReservationBranchStatisticCol : BaseCol
    {
        public ReservationBranchStatisticCol(bool blIsempty)
        {
            ReservationBranchStatisticBiz objBiz;
            objBiz = new ReservationBranchStatisticBiz();
            ReservationBranchStatisticDb objDb = new ReservationBranchStatisticDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationBranchStatisticBiz(objDr));
            }
        }
        public ReservationBranchStatisticCol(int intID)
        {
            ReservationBranchStatisticDb objDb = new ReservationBranchStatisticDb();
            //objDb.WorkerID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationBranchStatisticBiz(objDr));
            }
        }
       public ReservationBranchStatisticCol(BranchBiz objBranchBiz,CellBiz objCellBiz,DateTime dtFrom,DateTime dtTo,bool IsDateRange,bool IsContractingDateRange,DateTime dtContractFrom,DateTime dtContractTo)
       {
           ReservationBranchStatisticDb objDb = new ReservationBranchStatisticDb();
           objDb.IsDateRange = IsDateRange;
           objDb.IsContractingDateRange = IsContractingDateRange;
           objDb.BranchID = objBranchBiz.ID;
           objDb.CellID = objCellBiz.ID;
           objDb.DtFrom = dtFrom;
           objDb.DtTo = dtTo;
           objDb.ContractingDateFrom = dtContractFrom;
           objDb.ContractingDateTo = dtContractTo;
           DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationBranchStatisticBiz(objDr));
            }
       }
        public ReservationBranchStatisticBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationBranchStatisticBiz)List[intIndex];
            }
        }

        public void Add(ReservationBranchStatisticBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
