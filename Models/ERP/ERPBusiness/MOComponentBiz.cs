using AlgorithmatENM.ERP.ERPDataBase;
using AlgorithmatENM.Models.ERP.ERPBusiness;
using System.Data;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MOComponentBiz
    {

        #region Constructor
        public MOComponentBiz()
        {
            _MOComponentDb = new MOComponentDb();
        }
        public MOComponentBiz(DataRow objDr)
        {
            _MOComponentDb = new MOComponentDb(objDr);
        }

        #endregion

        #region Private Data
        MOComponentDb _MOComponentDb;
        #endregion
        #region Properties
        public int MO
        {
            set => _MOComponentDb.MO = value;
            get => _MOComponentDb.MO;
        }
        MOBiz _MOBiz;
        public MOBiz MOBiz { set => _MOBiz = value; get => _MOBiz; }
        public int Product
        {
            set => _MOComponentDb.Product = value;
            get => _MOComponentDb.Product;
        }
        public int ProductRef
        {
            set => _MOComponentDb.ProductRef = value;
            get => _MOComponentDb.ProductRef;
        }
        public ProductBiz ProductBiz
        {
            get
            {
                return new ProductBiz() { ID=_MOComponentDb.ProductID,Code=_MOComponentDb.ProductCode,NameA =_MOComponentDb.ProductNameA,NameE=_MOComponentDb.ProductNameE};
            }
        }
        public double Quantity
        {
            set => _MOComponentDb.Quantity = value;
            get => _MOComponentDb.Quantity;
        }
        MeasurementUnitBiz _MeasurementUnitBiz;
        public MeasurementUnitBiz MeasurementUnitBiz
        {
            set => _MeasurementUnitBiz = value;
            get => _MeasurementUnitBiz == null ||_MeasurementUnitBiz.ID==0? new MeasurementUnitBiz() { ID = _MOComponentDb.ProductMeasurementID, Code = _MOComponentDb.ProductMeasurementCode, NameA = _MOComponentDb.ProductMeasurementNameA, NameE = _MOComponentDb.ProductMeasurementNameE }:_MeasurementUnitBiz;
        }
       
        #endregion

        #region Private Method

        #endregion

        #region Public Method 
        public void Add()
        {
            _MOComponentDb.Add();
        }
        public void Edit()
        {
            _MOComponentDb.Edit();
        }
        public void Delete()
        {
            _MOComponentDb.Delete();
        }
        public MOComponentSimple GetSimple()
        {
            return new MOComponentSimple()
            {
                MO = MO,
                
                Quantity = Quantity,
                Product = ProductBiz.GetSimple()
                ,MeasurementUnit=MeasurementUnitBiz.GetSimple(),ProductRef=ProductRef
            };
        }
        #endregion


    }
}
