using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Collections;
using System.Data;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class WorkOrderCol:CollectionBase
    {

        #region Constructor
        public WorkOrderCol()
        {

        }
        public WorkOrderCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            WorkOrderBiz objBiz = new WorkOrderBiz();
           

            WorkOrderDb objDb = new WorkOrderDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new WorkOrderBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public WorkOrderBiz this[int intIndex]
        {
            get
            {
                return (WorkOrderBiz)this.List[intIndex];
            }
        }
        #endregion 
            #region Private Method
                
                #endregion 
                #region Public Method 
                   public void Add(WorkOrderBiz objBiz)
        {
            List.Add(objBiz);
        }
        public WorkOrderCol GetCol(string strTemp)
        {
            WorkOrderCol Returned = new WorkOrderCol(true);
            foreach (WorkOrderBiz objBiz in this)
            {
                if (objBiz.ProductNameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("WorkOrderID"), new DataColumn("WorkOrderMO"), new DataColumn("WorkOrderRef"), new DataColumn("WorkOrderDesc"), new DataColumn("WorkOrderType"), new DataColumn("WorkOrderProduct"), new DataColumn("WorkOrderDate", System.Type.GetType("System.DateTime")), new DataColumn("WorkOrderTime", System.Type.GetType("System.DateTime")), new DataColumn("WorkOrderQuantity"), new DataColumn("WorkOrderPeriority"), new DataColumn("WorkOrderProductCode"), new DataColumn("WorkOrderProductNameA"), new DataColumn("WorkOrderProductNameE"), new DataColumn("WorkOrderProductMeasurementUnit"), new DataColumn("WorkOrderProductMeasurementCode"), new DataColumn("WorkOrderProductMeasurementNameA"), new DataColumn("WorkOrderProductMeasurementNameE") });
            DataRow objDr;
            foreach (WorkOrderBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["WorkOrderID"] = objBiz.ID;
                objDr["WorkOrderMO"] = objBiz.MO;
                objDr["WorkOrderRef"] = objBiz.Ref;
                objDr["WorkOrderDesc"] = objBiz.Desc;
                objDr["WorkOrderType"] = objBiz.Type;
                objDr["WorkOrderProduct"] = objBiz.Product;
                objDr["WorkOrderDate"] = objBiz.Date;
                objDr["WorkOrderTime"] = objBiz.Time;
                objDr["WorkOrderQuantity"] = objBiz.Quantity;
                objDr["WorkOrderPeriority"] = objBiz.Periority;
                objDr["WorkOrderProductCode"] = objBiz.ProductCode;
                objDr["WorkOrderProductNameA"] = objBiz.ProductNameA;
                objDr["WorkOrderProductNameE"] = objBiz.ProductNameE;
                objDr["WorkOrderProductMeasurementUnit"] = objBiz.ProductMeasurementUnit;
                objDr["WorkOrderProductMeasurementCode"] = objBiz.ProductMeasurementCode;
                objDr["WorkOrderProductMeasurementNameA"] = objBiz.ProductMeasurementNameA;
                objDr["WorkOrderProductMeasurementNameE"] = objBiz.ProductMeasurementNameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
