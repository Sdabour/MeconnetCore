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
    public class ReservationSalesSumCol : BaseCol
    {

        public ReservationSalesSumCol(bool blIsempty)
        {
            ReservationSalesSumBiz objBiz;
            objBiz = new ReservationSalesSumBiz();
            ReservationSalesSumDb objDb = new ReservationSalesSumDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationSalesSumBiz(objDr));
            }
        }
         public ReservationSalesSumCol()
        {
            ReservationSalesSumBiz objBiz;
            objBiz = new ReservationSalesSumBiz();
            ReservationSalesSumDb objDb = new ReservationSalesSumDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationSalesSumBiz(objDr));
            }
        }

        public ReservationSalesSumCol(CellBiz Cell,BranchBiz Branch,DateTime DateFrom
            , DateTime DateTo, bool IsDateRange, DateTime dtContractingDateFrom
            , DateTime dtContractingDateTo, bool blIsContractingDateRange,SalesManBiz Sales,bool blStatusDate,
            DateTime dtStatusStartDate,DateTime dtStatusEndDate)
        {
            ReservationSalesSumBiz objBiz;
            objBiz = new ReservationSalesSumBiz();
            ReservationSalesSumDb objDb = new ReservationSalesSumDb();
            objDb.CellID = Cell.ID;
            objDb.BranchID = Branch.ID;
            
            objDb.WorkerID = Sales.ID;
            objDb.IsDateRange = IsDateRange;
            objDb.DateFrom = DateFrom;
            objDb.DateTo = DateTo;
            objDb.ContractingDateFrom = dtContractingDateFrom;
            objDb.ContractingDateTo = dtContractingDateTo;
            objDb.IsContractingDateRange = blIsContractingDateRange;
            objDb.StatusDateRange = blStatusDate;
            objDb.StatusStartDate = dtStatusStartDate;
            objDb.StatusEndDate = dtStatusEndDate;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {

                Add(new ReservationSalesSumBiz(objDr));
            }

        }

        
        public ReservationSalesSumBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationSalesSumBiz)List[intIndex];
            }
        }

        public void Add(ReservationSalesSumBiz objBiz)
        {
            List.Add(objBiz);
 
        }

        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantFirstName"), new DataColumn("DeservedCount"), new DataColumn("ContractingCount"), new DataColumn("CompletedCount") 
            ,new DataColumn("CancellationCount"),new DataColumn("CessionCount"),new DataColumn("TotalValue")});
            DataRow objDr;
            foreach (ReservationSalesSumBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ApplicantFirstName"] = objBiz.WorkerName;
                objDr["DeservedCount"] = objBiz.DeservedCount.ToString();
                objDr["ContractingCount"] = objBiz.ContractingCount.ToString();
                objDr["CompletedCount"] = objBiz.CompletedCount.ToString();
                objDr["CancellationCount"] = objBiz.CancellationCount.ToString();
                objDr["CessionCount"] = objBiz.CessionCount.ToString();
                objDr["TotalValue"] = objBiz.TotalValue.ToString("0.0");
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;
        }

    }
}
