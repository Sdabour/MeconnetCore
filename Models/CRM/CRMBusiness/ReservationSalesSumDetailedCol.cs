using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationSalesSumDetailedCol : BaseCol
    {


      
         public ReservationSalesSumDetailedCol(CellBiz objCellBiz,BranchBiz objBranchBiz ,WorkerBiz objWorkerBiz,
             bool blIsDateRange,DateTime dtFromData,DateTime dtToDate,
             bool blIsContractingDate,DateTime dtContractingFromDate,DateTime dtContractingEndDate,
             SalesManBiz objsalesMan)
        {
            ReservationSalesSumDetailedBiz objBiz;
            objBiz = new ReservationSalesSumDetailedBiz();
            ReservationSalesSumDetailedDb objDb = new ReservationSalesSumDetailedDb();
             objDb.CellID = objCellBiz.FamilyID;
             objDb.BranchID = objBranchBiz.ID;
             objDb.WorkerID = objsalesMan.ID;
             objDb.IsDateRange = blIsDateRange;
             objDb.DateFrom = dtFromData;
             objDb.DateTo = dtToDate;
             objDb.IsContractingDate = blIsContractingDate;
             objDb.ContractFromDate = dtContractingFromDate;
             objDb.ContractEndDate = dtContractingEndDate;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "");
            Hashtable hsTemp = new Hashtable();
            ReservationSalesSumDetailedBiz objTemp;
            string strTemp = "";
            foreach (DataRow objDr in arrDr)
            {
                objTemp = new ReservationSalesSumDetailedBiz(objDr);
                strTemp = objTemp.WorkerFirstName + "-"
                    + objTemp.ReservationID.ToString();

                if (hsTemp[strTemp] == null)
                {
                    hsTemp.Add(strTemp, objTemp);
                    Add(objTemp);
                }
                else
                {
                    if(((ReservationSalesSumDetailedBiz)hsTemp[strTemp]).CustomerFullName!= "")
                        ((ReservationSalesSumDetailedBiz)hsTemp[strTemp]).CustomerFullName+= "-";
                    ((ReservationSalesSumDetailedBiz)hsTemp[strTemp]).CustomerFullName += objTemp.CustomerFullName;
                }
            }
         
        }

        public ReservationSalesSumDetailedBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationSalesSumDetailedBiz)List[intIndex];
            }
        }

        public void Add(ReservationSalesSumDetailedBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
