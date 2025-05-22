using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerReservationSumCol : BaseCol
    {
        public TowerReservationSumCol(bool blIsempty)
        {
            TowerReservationSumBiz objBiz;
            objBiz = new TowerReservationSumBiz();
            TowerReservationSumDb objDb = new TowerReservationSumDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TowerReservationSumBiz(objDr));
            }
        }
        public TowerReservationSumCol(CellBiz _CellBiz,bool IsDateRange,DateTime StartDate,DateTime EndDate,bool iscontractingRange,DateTime startContractDate,DateTime endcontractDate)
        {
             TowerReservationSumBiz objBiz;
            objBiz = new TowerReservationSumBiz();
            TowerReservationSumDb objDb = new TowerReservationSumDb();
            objDb.CellID = _CellBiz.ID;
            objDb.DateFrom = StartDate;
            objDb.DateTo = EndDate;
            objDb.IsDateRange = IsDateRange;
            objDb.IsContractingDateRange = iscontractingRange;
            objDb.ContractingDateFrom = startContractDate;
            objDb.ContractingDateTo = endcontractDate;
            DataTable dtTemp = objDb.Search();
            try
            {
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new TowerReservationSumBiz(objDr));
                }
            }
            catch { }
        }
        public TowerReservationSumCol()
        {
            TowerReservationSumBiz objBiz;
            objBiz = new TowerReservationSumBiz();
            TowerReservationSumDb objDb = new TowerReservationSumDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TowerReservationSumBiz(objDr));
            }
        }
        
       
        public TowerReservationSumBiz this[int intIndex]
        {
           
            get
            {
                return (TowerReservationSumBiz)List[intIndex];
            }
        }

        public void Add(TowerReservationSumBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
