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
    public class BranchReservationCountCol : BaseCol
    {
         public BranchReservationCountCol(bool blIsempty)
        {
            BranchReservationCountBiz objBiz;
            objBiz = new BranchReservationCountBiz();
            BranchReservationCountDb objDb = new BranchReservationCountDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new BranchReservationCountBiz(objDr));
            }
        }
         public BranchReservationCountCol()
        {
            BranchReservationCountBiz objBiz;
            objBiz = new BranchReservationCountBiz();
            BranchReservationCountDb objDb = new BranchReservationCountDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new BranchReservationCountBiz(objDr));
            }
        }

        public BranchReservationCountCol(CellBiz Cell,BranchCol objBranchCol,DateTime dtReservationFrom,DateTime dtReservationTo,bool IsDateRange,
            bool blIsContractingRange,DateTime dtContractingDateFrom,DateTime dtContractingDateTo,int intIsReservedStatus,
            bool blIsProjectGrouping,bool blIsYearGrouping,bool blIsMonthGrouing,bool blIsDayGrouping)
        {
            BranchReservationCountBiz objBiz;
            objBiz = new BranchReservationCountBiz();
            BranchReservationCountDb objDb = new BranchReservationCountDb();
            objDb.CellID = Cell.ID;
          
            objDb.IsDateRange = IsDateRange;
            objDb.DateFrom = dtReservationFrom;
            objDb.DateTo = dtReservationTo;
            objDb.IsContractingDateRange = blIsContractingRange;
            objDb.ContractingDateFrom = dtContractingDateFrom;
            objDb.ContractingDateTo = dtContractingDateTo;
            objDb.IsProjectGrouping = blIsProjectGrouping;
            objDb.BranchIDs = objBranchCol.IDs;
            objDb.IsDayGrouping = blIsDayGrouping;
            objDb.IsMonthGrouping = blIsMonthGrouing;
            objDb.IsYearGrouping = blIsYearGrouping;
            objDb.IsReservedStatus = intIsReservedStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new BranchReservationCountBiz(objDr));
            }

        }

        public BranchReservationCountCol(int intID)
        {
            BranchReservationCountDb objDb = new BranchReservationCountDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new BranchReservationCountBiz(objDr));
            }
        }
       
        public BranchReservationCountBiz this[int intIndex]
        {
           
            get
            {
                return (BranchReservationCountBiz)List[intIndex];
            }
        }

        public void Add(BranchReservationCountBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
