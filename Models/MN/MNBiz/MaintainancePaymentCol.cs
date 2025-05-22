using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class MaintainancePaymentCol : CollectionBase
    {

        #region Constructor
        public MaintainancePaymentCol()
        {

        }
        public MaintainancePaymentCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MaintainancePaymentBiz objBiz = new MaintainancePaymentBiz();


            MaintainancePaymentDb objDb = new MaintainancePaymentDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainancePaymentBiz(objDR);
                Add(objBiz);
            }
        }
        public MaintainancePaymentCol(string strProjectCode, ROBiz objRoBiz, bool blIsDateRange, DateTime dtSTartDate, DateTime dtEndDate, int intCreditedStatus)
        {
            if (objRoBiz == null)
                objRoBiz = new ROBiz();
            MaintainancePaymentBiz objBiz = new MaintainancePaymentBiz();


            MaintainancePaymentDb objDb = new MaintainancePaymentDb();
            objDb.CreditROID = objRoBiz.ID;
            objDb.CreditedStatus = intCreditedStatus;
            objDb.IsDateRange = blIsDateRange;
            objDb.StartDate = dtSTartDate;
            objDb.EndDate = dtEndDate;
            objDb.ProjectCode = strProjectCode;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainancePaymentBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MaintainancePaymentBiz this[int intIndex]
        {
            get
            {
                return (MaintainancePaymentBiz)this.List[intIndex];
            }
        }
        public double TotalValue
        { get => this.Cast<MaintainancePaymentBiz>().Sum(x => x.Value); }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MaintainancePaymentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MaintainancePaymentCol GetCol(string strTemp)
        {
            MaintainancePaymentCol Returned = new MaintainancePaymentCol(true);
            foreach (MaintainancePaymentBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PaymentID"), new DataColumn("CreditROID"), new DataColumn("CreditID"), new DataColumn("PaymentValue"), new DataColumn("PaymentDate", System.Type.GetType("System.DateTime")), new DataColumn("PaymentCurrency"), new DataColumn("PaymentCurrencyValue"), new DataColumn("PaymentType"), new DataColumn("PaymentDesc"), new DataColumn("PaymentDirection", System.Type.GetType("System.Boolean")), new DataColumn("PaymentEmployee"), new DataColumn("PaymentBranch"), new DataColumn("PaymentCoffer"), new DataColumn("PaymentHasReceipt", System.Type.GetType("System.Boolean")), new DataColumn("PaymentReceipt"), new DataColumn("PaymentSourceID"), new DataColumn("PaymentReverseID"), new DataColumn("PaymentCollectingID"), new DataColumn("CheckID"), new DataColumn("PaymentIsCollected", System.Type.GetType("System.Boolean")), new DataColumn("PaymentCollectingDate", System.Type.GetType("System.DateTime")), new DataColumn("PaymentCollectingUsr"), new DataColumn("PaymentCollectingEmployee"), new DataColumn("PaymentCollectingBranch"), new DataColumn("PaymentCollectingCoffer"), new DataColumn("PaymentCollectingRealDate", System.Type.GetType("System.DateTime")), new DataColumn("CheckEditorName"), new DataColumn("CheckCode"), new DataColumn("CheckValue"), new DataColumn("CheckIssueDate", System.Type.GetType("System.DateTime")), new DataColumn("CheckDueDate", System.Type.GetType("System.DateTime")), new DataColumn("CheckPaymentDate", System.Type.GetType("System.DateTime")), new DataColumn("CheckCurrentStatus"), new DataColumn("CheckCurrentStatusDate", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (MaintainancePaymentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PaymentID"] = objBiz.ID;
                objDr["CreditROID"] = objBiz.CreditROID;
                objDr["CreditID"] = objBiz.CreditID;
                objDr["PaymentValue"] = objBiz.Value;
                objDr["PaymentDate"] = objBiz.Date;
                objDr["PaymentCurrency"] = objBiz.Currency;
                objDr["PaymentCurrencyValue"] = objBiz.CurrencyValue;
                objDr["PaymentType"] = objBiz.Type;
                objDr["PaymentDesc"] = objBiz.Desc;
                objDr["PaymentDirection"] = objBiz.Direction;




                objDr["CheckID"] = objBiz.CheckBiz.ID;
                objDr["PaymentIsCollected"] = objBiz.IsCollected;
                objDr["PaymentCollectingDate"] = objBiz.CollectingDate;



                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        
        #endregion
    }
}
