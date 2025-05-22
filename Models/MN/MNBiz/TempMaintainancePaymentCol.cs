using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class TempMaintainancePaymentCol:CollectionBase
    {

        #region Constructor
        public TempMaintainancePaymentCol()
        {

        }
        public TempMaintainancePaymentCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TempMaintainancePaymentBiz objBiz = new TempMaintainancePaymentBiz();
          
         
            TempMaintainancePaymentDb objDb = new TempMaintainancePaymentDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TempMaintainancePaymentBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TempMaintainancePaymentBiz this[int intIndex]
        {
            get
            {
                return (TempMaintainancePaymentBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TempMaintainancePaymentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TempMaintainancePaymentCol GetCol(string strTemp)
        {
            TempMaintainancePaymentCol Returned = new TempMaintainancePaymentCol(true);
            foreach (TempMaintainancePaymentBiz objBiz in this)
            {
                 
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PaymentID"), new DataColumn("PaymentDate", System.Type.GetType("System.DateTime")), new DataColumn("PaymentValue"), new DataColumn("PaymentInternalRef"), new DataColumn("PayementInternalType"), new DataColumn("PaymentDesc"), new DataColumn("PaymentSystem"), new DataColumn("GLPaymentID"), new DataColumn("BankRef") });
            DataRow objDr;
            foreach (TempMaintainancePaymentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PaymentID"] = objBiz.ID;
                objDr["PaymentDate"] = objBiz.Date;
                objDr["PaymentValue"] = objBiz.Value;
                objDr["PaymentInternalRef"] = objBiz.InternalRef;
                objDr["PayementInternalType"] = objBiz.PayementInternalType;
                objDr["PaymentDesc"] = objBiz.Desc;
                objDr["PaymentSystem"] = objBiz.System;
                objDr["GLPaymentID"] = objBiz.GLID;
                objDr["BankRef"] = objBiz.BankRef;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}