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
    public class RecursiveTransactionElementCol : BaseCol
    {
        public RecursiveTransactionElementCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                RecursiveTransactionElementDb objDb = new RecursiveTransactionElementDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new RecursiveTransactionElementBiz(objDr));
                }
            }
        }
        public RecursiveTransactionElementCol(int intID)
        {
            RecursiveTransactionElementDb objDb = new RecursiveTransactionElementDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new RecursiveTransactionElementBiz(objDr));
            }
        }
        public RecursiveTransactionElementBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (RecursiveTransactionElementBiz)List[intIndex];
            }
        }
        public double CrditTotalValue
        {
            get
            {
                double TotalCrditeValue = 0;
                foreach (RecursiveTransactionElementBiz objBiz in this)
                {
                    if (objBiz.Direction == true)
                        TotalCrditeValue = TotalCrditeValue + objBiz.CrditeTotalValue;
                }
                return TotalCrditeValue;

            }

        }
        public double TotalDebitValue
        {
            get
            {
                double TotalDebitValue = 0;
                foreach (RecursiveTransactionElementBiz objBiz in this)
                {
                    if (!objBiz.Direction)
                        TotalDebitValue = TotalDebitValue + objBiz.DebitTotalValue;
                }
                return TotalDebitValue;
            }
        }
        public void Add(RecursiveTransactionElementBiz objBiz)
        {

            //if (objBiz.Direction == false || Count==0)
            List.Add(objBiz);
            //else
            //{
            //    RecursiveTransactionElementBiz objTemp;
            //    for(int intIndex = 0;intIndex <Count;intIndex++)
            //    {

            //        if (this[intIndex].Direction == true)
            //            continue;
            //        else
            //        {
            //            objTemp = this[intIndex];

            //            this[intIndex] = objBiz;
            //            List.Add(this[Count - 1]);
            //            for (int intI = Count-1; intI >intIndex+1; intI--)
            //            {
            //                this[intI] = this[intI - 1];

            //            }
            //            this[intIndex + 1] = objTemp;
            //            break;

            //        }
            //    }
            //}

        }
        public int GetIndex(AccountBiz objAccountBiz)
        {
            int intIndex = 0;
            foreach (RecursiveTransactionElementBiz objBiz in this)
            {
                if (objBiz.AccountBiz.ID == objAccountBiz.ID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public DataTable GetTable()
        {
            //System.Type.GetType("System.Boolean"))
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ElementID"), 
                new DataColumn("ElementTransaction"), new DataColumn("ElementAccount"),
                new DataColumn("ElementDirection",Type.GetType("System.Boolean")),
             new DataColumn("ElementValue"),new DataColumn("CostCenterID"),new DataColumn("ElementOrder")});
            DataRow objDr;
            int intOrder = 0;
            foreach (RecursiveTransactionElementBiz objBiz in this)
            {
                intOrder++;
                objDr = dtReturned.NewRow();
                objDr["ElementID"] = objBiz.ID;
                objDr["ElementTransaction"] = objBiz.TRansaction;
                objDr["ElementAccount"] = objBiz.AccountBiz.ID;
                objDr["ElementDirection"] = objBiz.Direction ? 1 : 0;
                objDr["ElementValue"] = objBiz.Value;
                objDr["CostCenterID"] = objBiz.CostCenterBiz.ID;
                objDr["ElementOrder"] = intOrder;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
    }
}
