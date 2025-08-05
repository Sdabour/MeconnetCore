using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class MOComponentDb
    {

        #region Constructor
        public MOComponentDb()
        {
        }
        public MOComponentDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _MO;
        public int MO
        {
            set => _MO = value;
            get => _MO;
        }
        int _Product;
        public int Product
        {
            set => _Product = value;
            get => _Product;
        }
        double _Quantity;
        public double Quantity
        {
            set => _Quantity = value;
            get => _Quantity;
        }
        int _ProductID;
        public int ProductID
        {
            set => _ProductID = value;
            get => _ProductID;
        }
        string _ProductCode;
        public string ProductCode
        {
            set => _ProductCode = value;
            get => _ProductCode;
        }
        string _ProductNameA;
        public string ProductNameA
        {
            set => _ProductNameA = value;
            get => _ProductNameA;
        }
        string _ProductNameE;
        public string ProductNameE
        {
            set => _ProductNameE = value;
            get => _ProductNameE;
        }
        int _ProductMeasurementID;
        public int ProductMeasurementID
        {
            set => _ProductMeasurementID = value;
            get => _ProductMeasurementID;
        }
        string _ProductMeasurementCode;
        public string ProductMeasurementCode
        {
            set => _ProductMeasurementCode = value;
            get => _ProductMeasurementCode;
        }
        string _ProductMeasurementNameA;
        public string ProductMeasurementNameA
        {
            set => _ProductMeasurementNameA = value;
            get => _ProductMeasurementNameA;
        }
        string _ProductMeasurementNameE;
        public string ProductMeasurementNameE
        {
            set => _ProductMeasurementNameE = value;
            get => _ProductMeasurementNameE;
        }
        int _ProductRef;
        public int ProductRef
        {
            set => _ProductRef = value;
            get => _ProductRef;
        }
        string _MOIDs;
        public  string MOIDs { set => _MOIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPMOComponent (MO,Product,Quantity,MeasurementID,ProductRef) values (" + MO + "," + Product + "," + Quantity + "," + _ProductMeasurementID+","+_ProductRef+ ") ";
                return Returned;
            }
        }
        public string AddByproductStr
        {
            get
            {
                string Returned = " insert into ERPMOByproduct (MO,Product,Quantity,MeasurementID,ProductRef) values (" + MO + "," + Product + "," + Quantity + "," + _ProductMeasurementID+","+_ProductRef + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPMOComponent set " + "MO=" + MO + "" +
           ",Product=" + Product + "" +
           ",Quantity=" + Quantity + "" +
           ",ComponentProductID=" + ProductID + "" +
           ",ComponentProductCode='" + ProductCode + "'" +
           ",ComponentProductNameA='" + ProductNameA + "'" +
           ",ComponentProductNameE='" + ProductNameE + "'" +
           ",ComponentProductMeasurementID=" + ProductMeasurementID + "" +
           ",ComponentProductMeasurementCode='" + ProductMeasurementCode + "'" +
           ",ComponentProductMeasurementNameA='" + ProductMeasurementNameA + "'" +
           ",ComponentProductMeasurementNameE='" + ProductMeasurementNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPMOComponent set Dis = GetDate() where  ";
                return Returned;
            }
        }
        bool _IsByProduct;
        public bool IsByProduct { set { _IsByProduct = value; } }
        public string SearchStr
        {
            get
            {
                string strTableName = _IsByProduct ? "dbo.ERPMOByproduct" : "dbo.ERPMOComponent";
                string Returned = @" SELECT ComponentTable1.MO, ComponentTable1.Product, ComponentTable1.Quantity, ComponentTable1.MeasurementID,ComponentTable1.ProductRef, dbo.ERPProduct.ProductID AS ComponentProductID, dbo.ERPProduct.ProductCode AS ComponentProductCode, 
                  dbo.ERPProduct.ProductNameA AS ComponentProductNameA, dbo.ERPProduct.ProductNameE AS ComponentProductNameE, dbo.ERPMeasurementUnit.MeasurementID AS ComponentProductMeasurementID, 
                  dbo.ERPMeasurementUnit.MeasurementCode AS ComponentProductMeasurementCode, dbo.ERPMeasurementUnit.MeasurementNameA AS ComponentProductMeasurementNameA, 
                  dbo.ERPMeasurementUnit.MeasurementNameE AS ComponentProductMeasurementNameE
FROM     "+strTableName+@" AS ComponentTable1 INNER JOIN
                  dbo.ERPProduct ON ComponentTable1.Product = dbo.ERPProduct.ProductID LEFT OUTER JOIN
                  dbo.ERPMeasurementUnit ON ComponentTable1.MeasurementID = dbo.ERPMeasurementUnit.MeasurementID ";
                return Returned;
            }
        }
        #endregion 
            #region Private Method
                 void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MO"] != null)
                int.TryParse(objDr["MO"].ToString(), out _MO);

            if (objDr.Table.Columns["Product"] != null)
                int.TryParse(objDr["Product"].ToString(), out _Product);
            if (objDr.Table.Columns["ProductRef"] != null)
                int.TryParse(objDr["ProductRef"].ToString(), out _ProductRef);

            if (objDr.Table.Columns["Quantity"] != null)
                double.TryParse(objDr["Quantity"].ToString(), out _Quantity);

            if (objDr.Table.Columns["ComponentProductID"] != null)
                int.TryParse(objDr["ComponentProductID"].ToString(), out _ProductID);

            if (objDr.Table.Columns["ComponentProductCode"] != null)
                _ProductCode = objDr["ComponentProductCode"].ToString();

            if (objDr.Table.Columns["ComponentProductNameA"] != null)
                _ProductNameA = objDr["ComponentProductNameA"].ToString();

            if (objDr.Table.Columns["ComponentProductNameE"] != null)
                _ProductNameE = objDr["ComponentProductNameE"].ToString();

            if (objDr.Table.Columns["ComponentProductMeasurementID"] != null)
                int.TryParse(objDr["ComponentProductMeasurementID"].ToString(), out _ProductMeasurementID);

            if (objDr.Table.Columns["ComponentProductMeasurementCode"] != null)
                _ProductMeasurementCode = objDr["ComponentProductMeasurementCode"].ToString();

            if (objDr.Table.Columns["ComponentProductMeasurementNameA"] != null)
                _ProductMeasurementNameA = objDr["ComponentProductMeasurementNameA"].ToString();

            if (objDr.Table.Columns["ComponentProductMeasurementNameE"] != null)
                _ProductMeasurementNameE = objDr["ComponentProductMeasurementNameE"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if(_MOIDs!= null&&_MOIDs!="")
            {
                strSql += " and ComponentTable1.MO in (" + _MOIDs+")";
            }

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
