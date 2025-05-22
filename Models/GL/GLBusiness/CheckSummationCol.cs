using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class CheckSummationCol : BaseCol
    {
        public CheckSummationCol(bool blIsempty)
        {
            if (!blIsempty)
                return;
            CheckSummationDb objDb = new CheckSummationDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CheckSummationBiz(objDr));
            }
        }
        public CheckSummationCol(bool IsDateRange,DateTime StartDate,DateTime EndDate,BankBiz Bank,bool blIsGrouped,int intGroupType,
            CofferBiz objPlace,CofferBiz objOldCofferBiz,CheckStatus objStatus,
            int intPaymentStatus,bool blIsStatusDateRange,DateTime dtStartStatus,
            DateTime dtEndStatus,bool blIssueDateRange,DateTime dtIssueDateStart,DateTime dtIssueDateEnd,
            int intPeriodType,bool blDirection,int intOrientedStatus,AccountBankBiz objAccountBiz)
        {
            if (objAccountBiz == null)
                objAccountBiz = new AccountBankBiz();
            CheckSummationDb objDb = new CheckSummationDb();
            objDb.IsDateRange = IsDateRange;
           
            objDb.DateFrom = StartDate;
            objDb.DateTo = EndDate;
            objDb.IsIssueRange = blIssueDateRange;
            objDb.IssueDateFrom = dtIssueDateStart;
            objDb.IssueDateTo = dtIssueDateEnd;
            objDb.Bank = Bank.ID;
            objDb.Place = objPlace.ID;
            objDb.OldPlace = objOldCofferBiz.ID;
            objDb.PeriodType = intPeriodType;
            objDb.Status = (int)objStatus;
            objDb.CollectingPaymentStatus = intPaymentStatus;
            objDb.IsStatusDateRange = blIsStatusDateRange;
            objDb.DateStatusFrom = dtStartStatus;
            objDb.DateStatusTo = dtEndStatus;
            objDb.IsGrouped = blIsGrouped;
            objDb.GroupType = intGroupType;
            objDb.Direction = blDirection;
            objDb.OrientedStatus = intOrientedStatus;
            objDb.AccountID = objAccountBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CheckSummationBiz(objDr));
            }
        }
        public CheckSummationBiz this[int intIndex]
        {

            get
            {
                return (CheckSummationBiz)List[intIndex];
            }
        }
        public void Add(CheckSummationBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
