using AlgorithmatENM.ERP.ERPDataBase;
using System.Collections;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MOComponentCol:CollectionBase
    {

        #region Constructor
        public MOComponentCol()
        {

        }
        public MOComponentCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MOComponentBiz objBiz = new MOComponentBiz();
           

            MOComponentDb objDb = new MOComponentDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MOComponentBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MOComponentBiz this[int intIndex]
        {
            get
            {
                return (MOComponentBiz)this.List[intIndex];
            }
        }
        #endregion 
            #region Private Method
                
                #endregion 
                #region Public Method 
                   public void Add(MOComponentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MOComponentCol GetCol(string strTemp)
        {
            MOComponentCol Returned = new MOComponentCol(true);
            foreach (MOComponentBiz objBiz in this)
            {
                if (objBiz.ProductBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MO"), new DataColumn("Product"), new DataColumn("Quantity"), new DataColumn("ProductRef"), new DataColumn("ComponentProductID"), new DataColumn("ComponentProductCode"), new DataColumn("ComponentProductNameA"), new DataColumn("ComponentProductNameE"), new DataColumn("ComponentProductMeasurementID"), new DataColumn("ComponentProductMeasurementCode"), new DataColumn("ComponentProductMeasurementNameA"), new DataColumn("ComponentProductMeasurementNameE") });
            DataRow objDr;
            foreach (MOComponentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MO"] = objBiz.MO;
                objDr["Product"] = objBiz.Product;
                objDr["ProductRef"] = objBiz.ProductRef;
                objDr["Quantity"] = objBiz.Quantity;
                objDr["ComponentProductID"] = objBiz.ProductBiz.ID;
                objDr["ComponentProductCode"] = objBiz.ProductBiz.Code;
                objDr["ComponentProductNameA"] = objBiz.ProductBiz.NameA;
                objDr["ComponentProductNameE"] = objBiz.ProductBiz.NameE;
                objDr["ComponentProductMeasurementID"] = objBiz.MeasurementUnitBiz.ID;
                //objDr["ComponentProductMeasurementCode"] = objBiz.ProductMeasurementCode;
                //objDr["ComponentProductMeasurementNameA"] = objBiz.ProductMeasurementNameA;
                //objDr["ComponentProductMeasurementNameE"] = objBiz.ProductMeasurementNameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
