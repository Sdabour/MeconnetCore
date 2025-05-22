using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;

namespace AlgorithmatENM.Models.ERP.ERPBusiness
{
    public class MeasurementUnitBiz
    {

        #region Constructor
        public MeasurementUnitBiz()
        {
            _MeasurementUnitDb = new MeasurementUnitDb();
        }
        public MeasurementUnitBiz(DataRow objDr)
        {
            _MeasurementUnitDb = new MeasurementUnitDb(objDr);
        }

        #endregion
        #region Private Data
        MeasurementUnitDb _MeasurementUnitDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MeasurementUnitDb.ID = value;
            get => _MeasurementUnitDb.ID;
        }
        public int Main
        {
            set => _MeasurementUnitDb.Main = value;
            get => _MeasurementUnitDb.Main;
        }
        public string Code
        {
            set => _MeasurementUnitDb.Code = value;
            get => _MeasurementUnitDb.Code;
        }
        public string NameA
        {
            set => _MeasurementUnitDb.NameA = value;
            get => _MeasurementUnitDb.NameA;
        }
        public string NameE
        {
            set => _MeasurementUnitDb.NameE = value;
            get => _MeasurementUnitDb.NameE;
        }
        public double Factor
        {
            set => _MeasurementUnitDb.Factor = value;
            get => _MeasurementUnitDb.Factor;
        }
        public bool IsBasic
        {
            set => _MeasurementUnitDb.IsBasic = value;
            get => _MeasurementUnitDb.IsBasic;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MeasurementUnitDb.Add();
        }
        public void Edit()
        {
            _MeasurementUnitDb.Edit();
        }
        public void Delete()
        {
            _MeasurementUnitDb.Delete();
        }
        #endregion
    }
}