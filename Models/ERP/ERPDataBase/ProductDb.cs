using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class ProductDb
    {

        #region Constructor
        public ProductDb()
        {
        }
        public ProductDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        int _MeasurementUnit;
        public int MeasurementUnit
        {
            set => _MeasurementUnit = value;
            get => _MeasurementUnit;
        }
        int _InternalReference;
        public int InternalReference
        {
            set => _InternalReference = value;
            get => _InternalReference;
        }
        bool _IsRawMaterial;
        public bool IsRawMaterial
        {
            set => _IsRawMaterial = value;
            get => _IsRawMaterial;
        }
        bool _IsComposed;
        public bool IsComposed
        {
            set => _IsComposed = value;
            get => _IsComposed;
        }
        int _MainID;
        public int MainID { get => _MainID; }
        double _SubProductAmountPerUnit;
        public double SubProductAmountPerUnit { get => _SubProductAmountPerUnit; }
        string _IDs;
        public string IDs { set => _IDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPProduct (ProductID,ProductCode,ProductNameA,ProductNameE,ProductMeasurementUnit,ProductInternalReference,ProductIsRawMaterial,ProductIsComposed,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "'," + MeasurementUnit + "," + InternalReference + "," + (IsRawMaterial ? 1 : 0) + "," + (IsComposed ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPProduct set " + "ProductID=" + ID + "" +
           ",ProductCode='" + Code + "'" +
           ",ProductNameA='" + NameA + "'" +
           ",ProductNameE='" + NameE + "'" +
           ",ProductMeasurementUnit=" + MeasurementUnit + "" +
           ",ProductInternalReference=" + InternalReference + "" +
           ",ProductIsRawMaterial=" + (IsRawMaterial ? 1 : 0) + "" +
           ",ProductIsComposed=" + (IsComposed ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPProduct set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.ERPProduct.ProductID, dbo.ERPProduct.ProductCode, dbo.ERPProduct.ProductNameA, dbo.ERPProduct.ProductNameE, dbo.ERPProduct.ProductMeasurementUnit, dbo.ERPProduct.ProductInternalReference, 
                  dbo.ERPProduct.ProductIsRawMaterial, dbo.ERPProduct.ProductIsComposed
FROM     dbo.ERPProduct LEFT OUTER JOIN
                  dbo.ERPMeasurementUnit AS MeasurementUnitTable ON dbo.ERPProduct.ProductMeasurementUnit = MeasurementUnitTable.MeasurementID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ProductID"] != null)
                int.TryParse(objDr["ProductID"].ToString(), out _ID);

            if (objDr.Table.Columns["ProductCode"] != null)
                _Code = objDr["ProductCode"].ToString();

            if (objDr.Table.Columns["ProductNameA"] != null)
                _NameA = objDr["ProductNameA"].ToString();

            if (objDr.Table.Columns["ProductNameE"] != null)
                _NameE = objDr["ProductNameE"].ToString();

            if (objDr.Table.Columns["ProductMeasurementUnit"] != null)
                int.TryParse(objDr["ProductMeasurementUnit"].ToString(), out _MeasurementUnit);

            if (objDr.Table.Columns["ProductInternalReference"] != null)
                int.TryParse(objDr["ProductInternalReference"].ToString(), out _InternalReference);

            if (objDr.Table.Columns["ProductIsRawMaterial"] != null)
                bool.TryParse(objDr["ProductIsRawMaterial"].ToString(), out _IsRawMaterial);

            if (objDr.Table.Columns["ProductIsComposed"] != null)
                bool.TryParse(objDr["ProductIsComposed"].ToString(), out _IsComposed);

            if (objDr.Table.Columns["MainProductID"] != null)
                int.TryParse(objDr["MainProductID"].ToString(), out _MainID);
            if (objDr.Table.Columns["SubProductAmountPerUnit"] != null)
                double.TryParse(objDr["SubProductAmountPerUnit"].ToString(), out _SubProductAmountPerUnit);
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
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetSubProduct()
        {
            string strSql = @"SELECT dbo.ERPProductSubProduct.MainProductID, dbo.ERPProductSubProduct.SubProductAmountPerUnit,ProductTable.*
 FROM     dbo.ERPProduct AS ProductTable INNER JOIN
                  dbo.ERPProductSubProduct ON ProductTable.ProductID = dbo.ERPProductSubProduct.SubProductID
WHERE  (dbo.ERPProductSubProduct.MainProductID IN ("+_IDs+"))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}