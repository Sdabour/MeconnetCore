using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
    public class MaintainanceDiscountCol:CollectionBase
    {

        #region Constructor
        public MaintainanceDiscountCol()
        {

        }
        public MaintainanceDiscountCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MaintainanceDiscountBiz objBiz = new MaintainanceDiscountBiz();
            

            MaintainanceDiscountDb objDb = new MaintainanceDiscountDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainanceDiscountBiz(objDR);
                Add(objBiz);
            }
        }
        public MaintainanceDiscountCol(int intROID,int intTypeID,string strProject,int intCreditedStatus,bool blIsDateRange,DateTime dtStartDate,DateTime dtEndDate)
        {
           
            MaintainanceDiscountBiz objBiz = new MaintainanceDiscountBiz();


            MaintainanceDiscountDb objDb = new MaintainanceDiscountDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainanceDiscountBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MaintainanceDiscountBiz this[int intIndex]
        {
            get
            {
                return (MaintainanceDiscountBiz)this.List[intIndex];
            }
        }

        public double TotalValue
        { get => this.Cast<MaintainanceDiscountBiz>().Sum(x => x.Value); }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MaintainanceDiscountBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MaintainanceDiscountCol GetCol(string strTemp)
        {
            MaintainanceDiscountCol Returned = new MaintainanceDiscountCol(true);
            foreach (MaintainanceDiscountBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CreditDiscountID"), new DataColumn("CreditROID"), new DataColumn("CreditID"), new DataColumn("CreditDiscountType"), new DataColumn("CreditDiscountDate", System.Type.GetType("System.DateTime")), new DataColumn("CreditDiscountDesc"), new DataColumn("CreditDiscountValue") });
            DataRow objDr;
            foreach (MaintainanceDiscountBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CreditDiscountID"] = objBiz.ID;
                objDr["CreditROID"] = objBiz.CreditROID;
                objDr["CreditID"] = objBiz.CreditID;
                objDr["CreditDiscountType"] = objBiz.Type;
                objDr["CreditDiscountDate"] = objBiz.Date;
                objDr["CreditDiscountDesc"] = objBiz.Desc;
                objDr["CreditDiscountValue"] = objBiz.Value;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
