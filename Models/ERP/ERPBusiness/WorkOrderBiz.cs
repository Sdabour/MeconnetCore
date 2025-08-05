using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.ERP.ERPDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class WorkOrderBiz
    {

        #region Constructor
        public WorkOrderBiz()
        {
            _WorkOrderDb = new WorkOrderDb();
        }
        public WorkOrderBiz(DataRow objDr)
        {
            _WorkOrderDb = new WorkOrderDb(objDr);
        }

        #endregion

        #region Private Data
        WorkOrderDb _WorkOrderDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _WorkOrderDb.ID = value;
            get => _WorkOrderDb.ID;
        }
        public int MO
        {
            set => _WorkOrderDb.MO = value;
            get => _WorkOrderDb.MO;
        }
        public string Ref
        {
            set => _WorkOrderDb.Ref = value;
            get => _WorkOrderDb.Ref;
        }
        public string Desc
        {
            set => _WorkOrderDb.Desc = value;
            get => _WorkOrderDb.Desc;
        }
        public int Type
        {
            set => _WorkOrderDb.Type = value;
            get => _WorkOrderDb.Type;
        }
        public int Product
        {
            set => _WorkOrderDb.Product = value;
            get => _WorkOrderDb.Product;
        }
        public DateTime Date
        {
            set => _WorkOrderDb.Date = value;
            get => _WorkOrderDb.Date;
        }
        public DateTime Time
        {
            set => _WorkOrderDb.Time = value;
            get => _WorkOrderDb.Time;
        }
        public double Quantity
        {
            set => _WorkOrderDb.Quantity = value;
            get => _WorkOrderDb.Quantity;
        }
        public int Periority
        {
            set => _WorkOrderDb.Periority = value;
            get => _WorkOrderDb.Periority;
        }
        public string ProductCode
        {
            set => _WorkOrderDb.ProductCode = value;
            get => _WorkOrderDb.ProductCode;
        }
        public string ProductNameA
        {
            set => _WorkOrderDb.ProductNameA = value;
            get => _WorkOrderDb.ProductNameA;
        }
        public string ProductNameE
        {
            set => _WorkOrderDb.ProductNameE = value;
            get => _WorkOrderDb.ProductNameE;
        }
        public int ProductMeasurementUnit
        {
            set => _WorkOrderDb.ProductMeasurementUnit = value;
            get => _WorkOrderDb.ProductMeasurementUnit;
        }
        public string ProductMeasurementCode
        {
            set => _WorkOrderDb.ProductMeasurementCode = value;
            get => _WorkOrderDb.ProductMeasurementCode;
        }
        public string ProductMeasurementNameA
        {
            set => _WorkOrderDb.ProductMeasurementNameA = value;
            get => _WorkOrderDb.ProductMeasurementNameA;
        }
        public string ProductMeasurementNameE
        {
            set => _WorkOrderDb.ProductMeasurementNameE = value;
            get => _WorkOrderDb.ProductMeasurementNameE;
        }
        public string MachineCode
        {
            set => _WorkOrderDb.MachineCode = value;
            get => _WorkOrderDb.MachineCode;
        }
        public int MachineID
        {
            set => _WorkOrderDb.MachineID = value;
            get => _WorkOrderDb.MachineID;
        }
        public string MachineDesc
        {
            set => _WorkOrderDb.MachineDesc = value;
            get => _WorkOrderDb.MachineDesc;
        }
        public int MachineCenterID
        {
            set => _WorkOrderDb.MachineCenterID = value;
            get => _WorkOrderDb.MachineCenterID;
        }
        #endregion

        #region Private Method

        #endregion

        #region Public Method 
        public void Add()
        {
            _WorkOrderDb.Add();
        }
        public void Edit()
        {
            _WorkOrderDb.Edit();
        }
        public void Delete()
        {
            _WorkOrderDb.Delete();
        }
        public WorkOrderSimple GetSimple()
        {
            return new WorkOrderSimple()
            {
                ID = ID,
                MO = MO,
                Ref = Ref,
                Desc = Desc,
                Type = Type,
                Product = Product,
                Date = Date,
                Time = Time,
                Quantity = Quantity,
                Periority = Periority,
                ProductCode = ProductCode,
                ProductNameA = ProductNameA,
                ProductNameE = ProductNameE,
                ProductMeasurementUnit = ProductMeasurementUnit,
                ProductMeasurementCode = ProductMeasurementCode,
                ProductMeasurementNameA = ProductMeasurementNameA,
                ProductMeasurementNameE = ProductMeasurementNameE
            };
        }
        #endregion


    }
}
