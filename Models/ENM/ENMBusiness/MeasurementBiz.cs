using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasurementBiz
    {

        #region Constructor
        public MeasurementBiz()
        {
            _MeasurementDb = new MeasurementDb();
        }
        public MeasurementBiz(DataRow objDr)
        {
            _MeasurementDb = new MeasurementDb(objDr);
        }

        #endregion
        #region Private Data
        MeasurementDb _MeasurementDb;
        #endregion
        #region Properties
        public int MeterID
        {
            set => _MeasurementDb.MeterID = value;
            get => _MeasurementDb.MeterID;
        }
        public int MeterTypeID
        {
            set => _MeasurementDb.MeterTypeID = value;
            get => _MeasurementDb.MeterTypeID;
        }
        public string MeterDesc
        {
            set => _MeasurementDb.MeterDesc = value;
            get => _MeasurementDb.MeterDesc;
        }
        public string MeterTypeCode
        {
            set => _MeasurementDb.MeterTypeCode = value;
            get => _MeasurementDb.MeterTypeCode;
        }
        public string MeterTypeNameA
        {
            set => _MeasurementDb.MeterTypeNameA = value;
            get => _MeasurementDb.MeterTypeNameA;
        }
        public string MeterTypeNameE
        {
            set => _MeasurementDb.MeterTypeNameE = value;
            get => _MeasurementDb.MeterTypeNameE;
        }
        public int MeterGroup
        {
            set => _MeasurementDb.MeterGroup = value;
            get => _MeasurementDb.MeterGroup;
        }
        public string MeterGroupCode
        {
            set => _MeasurementDb.MeterGroupCode = value;
            get => _MeasurementDb.MeterGroupCode;
        }
        public string MeterGroupNameA
        {
            set => _MeasurementDb.MeterGroupNameA = value;
            get => _MeasurementDb.MeterGroupNameA;
        }
        public string MeterGroupNameE
        {
            set => _MeasurementDb.MeterGroupNameE = value;
            get => _MeasurementDb.MeterGroupNameE;
        }
        public string MeterGroupDesc
        {
            set => _MeasurementDb.MeterGroupDesc = value;
            get => _MeasurementDb.MeterGroupDesc;
        }

        public string ProductName
        {
            set => _MeasurementDb.ProductName = value;
            get => _MeasurementDb.ProductName;
        }
        public DateTime LastNonZeroMeasureDate
        {
            set => _MeasurementDb.LastNonZeroMeasureDate = value;
            get => _MeasurementDb.LastNonZeroMeasureDate;
        }
        public DateTime LastNonZeroMeasureTime
        {
            set => _MeasurementDb.LastNonZeroMeasureTime = value;
            get => _MeasurementDb.LastNonZeroMeasureTime;
        }
        public string LastNonZeroMeasureUnit
        {
            set => _MeasurementDb.LastNonZeroMeasureUnit = value;
            get => _MeasurementDb.LastNonZeroMeasureUnit;
        }
        public double LastNonZeroMeasureValue
        {
            set => _MeasurementDb.LastNonZeroMeasureValue = value;
            get => _MeasurementDb.LastNonZeroMeasureValue;
        }
        public int LastNonZeroMeasureType
        {
            set => _MeasurementDb.LastNonZeroMeasureType = value;
            get => _MeasurementDb.LastNonZeroMeasureType;
        }
        public int LastNonZeroMeasureTypeID
        {
            set => _MeasurementDb.LastNonZeroMeasureTypeID = value;
            get => _MeasurementDb.LastNonZeroMeasureTypeID;
        }
        public string LastNonZeroMeasureTypeCode
        {
            set => _MeasurementDb.LastNonZeroMeasureTypeCode = value;
            get => _MeasurementDb.LastNonZeroMeasureTypeCode;
        }
        public string LastNonZeroMeasureTypeNameA
        {
            set => _MeasurementDb.LastNonZeroMeasureTypeNameA = value;
            get => _MeasurementDb.LastNonZeroMeasureTypeNameA;
        }
        public string LastNonZeroMeasureTypeNameE
        {
            set => _MeasurementDb.LastNonZeroMeasureTypeNameE = value;
            get => _MeasurementDb.LastNonZeroMeasureTypeNameE;
        }
        public DateTime LastMeasureDate
        {
            set => _MeasurementDb.LastMeasureDate = value;
            get => _MeasurementDb.LastMeasureDate;
        }
        public DateTime LasMeasureTime
        {
            set => _MeasurementDb.LasMeasureTime = value;
            get => _MeasurementDb.LasMeasureTime;
        }
        public string LastMeasureUnit
        {
            set => _MeasurementDb.LastMeasureUnit = value;
            get => _MeasurementDb.LastMeasureUnit;
        }
        public double LastMeasureValue
        {
            set => _MeasurementDb.LastMeasureValue = value;
            get => _MeasurementDb.LastMeasureValue;
        }
        public double TypeMaxValue
        {
            set => _MeasurementDb.TypeMaxValue = value;
            get => _MeasurementDb.TypeMaxValue;
        }
        public double TypeMinValue
        {
            set => _MeasurementDb.TypeMinValue = value;
            get => _MeasurementDb.TypeMinValue;
        }
        public int LastMeasureType
        {
            set => _MeasurementDb.LastMeasureType = value;
            get => _MeasurementDb.LastMeasureType;
        }
        public int LastMeasureTypeID
        {
            set => _MeasurementDb.LastMeasureTypeID = value;
            get => _MeasurementDb.LastMeasureTypeID;
        }
        public string LastMeasureTypeCode
        {
            set => _MeasurementDb.LastMeasureTypeCode = value;
            get => _MeasurementDb.LastMeasureTypeCode;
        }
        public string LastMeasureTypeNameA
        {
            set => _MeasurementDb.LastMeasureTypeNameA = value;
            get => _MeasurementDb.LastMeasureTypeNameA;
        }
        public string LastMeasureTypeNameE
        {
            set => _MeasurementDb.LastMeasureTypeNameE = value;
            get => _MeasurementDb.LastMeasureTypeNameE;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MeasurementDb.Add();
        }
        public void Edit()
        {
            _MeasurementDb.Edit();
        }
        public void Delete()
        {
            _MeasurementDb.Delete();
        }
        #endregion
    }
}