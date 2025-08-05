using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
using AlgorithmatENMMVCCore.Controllers;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ProductCol:CollectionBase
    {

        #region Constructor
        public ProductCol()
        {

        }
        public ProductCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ProductBiz objBiz = new ProductBiz();
           
            ProductDb objDb = new ProductDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ProductBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ProductBiz this[int intIndex]
        {
            get
            {
                return (ProductBiz)this.List[intIndex];
            }
        }
        static ProductCol _CacheProductCol;
        public static ProductCol CacheProductCol { get
            {
                if(_CacheProductCol == null)
                {
                    _CacheProductCol = new ProductCol(false);
                }
                return _CacheProductCol;
            } }
        static Hashtable _RefProductHs;
        public static Hashtable RefProductHs
        {
            get
            {
                if (_RefProductHs == null)
                {
                    _RefProductHs = new Hashtable();
                    ProductCol objCol = CacheProductCol;
                    foreach (ProductBiz objBiz in objCol)
                    {
                        if (_RefProductHs[SysUtility.ReplaceStringComp(objBiz.Code)] == null)
                        {
                            _RefProductHs.Add(SysUtility.ReplaceStringComp(objBiz.Code), objBiz);
                        }
                    }

                }
                return _RefProductHs;
            }
        }
        public static ProductBiz GetEqualProductByRef(string strRef)
        {
            strRef = SysUtility.ReplaceStringComp(strRef);
            ProductBiz Returned = new ProductBiz();
            if (RefProductHs[strRef] != null)
            {
                Returned = ((ProductBiz)RefProductHs[strRef]);
            }
            return Returned;
        }
        static Hashtable _IDProductHs;
        public static Hashtable IDProductHs
        {
            get
            {
                if (_IDProductHs == null)
                {
                    _IDProductHs = new Hashtable();
                    ProductCol objCol = CacheProductCol;
                    foreach (ProductBiz objBiz in objCol)
                    {
                        if (_IDProductHs[objBiz.ID.ToString()] == null)
                        {
                            _IDProductHs.Add(objBiz.ID.ToString(), objBiz);
                        }
                    }

                }
                return _IDProductHs;
            }
        }
        public static SingleValue GetEqualProductByID(int intID)
        {
            SingleValue Returned = new SingleValue();
            if (IDProductHs[intID.ToString()] != null)
            {
                Returned.name =  ((ProductBiz)IDProductHs[intID.ToString()]).NameA;
                int intTemp = 0;
                int.TryParse(((ProductBiz)IDProductHs[intID.ToString()]).Code, out intTemp);
                Returned.id = intTemp;
            }
            return Returned;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ProductBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ProductCol GetCol(string strTemp)
        {
            ProductCol Returned = new ProductCol(true);
            foreach (ProductBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ProductID"), new DataColumn("ProductCode"), new DataColumn("ProductNameA"), new DataColumn("ProductNameE"), new DataColumn("ProductMeasurementUnit"), new DataColumn("ProductInternalReference"), new DataColumn("ProductIsRawMaterial", System.Type.GetType("System.Boolean")), new DataColumn("ProductIsComposed", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (ProductBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ProductID"] = objBiz.ID;
                objDr["ProductCode"] = objBiz.Code;
                objDr["ProductNameA"] = objBiz.NameA;
                objDr["ProductNameE"] = objBiz.NameE;
                objDr["ProductMeasurementUnit"] = objBiz.MeasurementUnit;
                objDr["ProductInternalReference"] = objBiz.InternalReference;
                objDr["ProductIsRawMaterial"] = objBiz.IsRawMaterial;
                objDr["ProductIsComposed"] = objBiz.IsComposed;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}