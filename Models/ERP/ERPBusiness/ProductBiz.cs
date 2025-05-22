using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Data;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ProductBiz
    {

        #region Constructor
        public ProductBiz()
        {
            _ProductDb = new ProductDb();
        }
        public ProductBiz(DataRow objDr)
        {
            _ProductDb = new ProductDb(objDr);
        }

        #endregion
        #region Private Data
        ProductDb _ProductDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _ProductDb.ID = value;
            get => _ProductDb.ID;
        }
        public string Code
        {
            set => _ProductDb.Code = value;
            get => _ProductDb.Code;
        }
        public string NameA
        {
            set => _ProductDb.NameA = value;
            get => _ProductDb.NameA;
        }
        public string NameE
        {
            set => _ProductDb.NameE = value;
            get => _ProductDb.NameE;
        }
        public int MeasurementUnit
        {
            set => _ProductDb.MeasurementUnit = value;
            get => _ProductDb.MeasurementUnit;
        }
        public int InternalReference
        {
            set => _ProductDb.InternalReference = value;
            get => _ProductDb.InternalReference;
        }
        public bool IsRawMaterial
        {
            set => _ProductDb.IsRawMaterial = value;
            get => _ProductDb.IsRawMaterial;
        }
        public bool IsComposed
        {
            set => _ProductDb.IsComposed = value;
            get => _ProductDb.IsComposed;
        }
        public int MainID
        {
           
            get => _ProductDb.MainID;
        }
        public double SubProductAmountPerUnit
        {

            get => _ProductDb.SubProductAmountPerUnit;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ProductDb.Add();
        }
        public void Edit()
        {
            _ProductDb.Edit();
        }
        public void Delete()
        {
            _ProductDb.Delete();
        }
        #endregion
    }
}