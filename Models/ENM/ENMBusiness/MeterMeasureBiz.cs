using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatENM.ENM.ENMDb;
using System.Data;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeterMeasureBiz
    {

        #region Constructor
        public MeterMeasureBiz()
        {
            _MeterMeasureDb = new MeterMeasureDb();
        }
        public MeterMeasureBiz(DataRow objDr)
        {
            _MeterMeasureDb = new MeterMeasureDb(objDr);
            _MeterBiz = new EMeterBiz(objDr);
        }

        #endregion
        #region Private Data
        MeterMeasureDb _MeterMeasureDb;
        #endregion
        #region Properties
        public int MeasureID
        {
            set
            {
                _MeterMeasureDb.MeasureID = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureID;
            }
        }
        public int Meter
        {
            set
            {
                _MeterMeasureDb.Meter = value;
            }
            get
            {
                return _MeterMeasureDb.Meter;
            }
        }
        public string ProductName { set => _MeterMeasureDb.ProductName = value; get => _MeterMeasureDb.ProductName; }
        EMeterBiz _MeterBiz;
        public EMeterBiz MeterBiz
        {
            set => _MeterBiz = value;
            get
            {
                if (_MeterBiz == null)
                    _MeterBiz = new EMeterBiz();
                return _MeterBiz;
            }

        }
        public DateTime MeasureDate
        {
            set
            {
                _MeterMeasureDb.MeasureDate = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureDate;
            }
        }
        public DateTime MeasureTime
        {
            set
            {
                _MeterMeasureDb.MeasureTime = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureTime;
            }
        }
        public double FirstValue
        {
            set => _MeterMeasureDb.FirstValue = value;
            get => _MeterMeasureDb.FirstValue;
        }
        public double MinValue
        {
            set => _MeterMeasureDb.MinValue = value;
            get => _MeterMeasureDb.MinValue;
        }
        public double MaxValue
        {
            set => _MeterMeasureDb.MaxValue = value;
            get => _MeterMeasureDb.MaxValue;
        }
        public DateTime MinTime
        {
            set => _MeterMeasureDb.MinTime = value;
            get => _MeterMeasureDb.MinTime;
        }
        public int MeasureType
        {
            set
            {
                _MeterMeasureDb.MeasureType = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureType;
            }
        }
        public string MeasureTypeName
        {
            set => _MeterMeasureDb.MeasureTypeName = value;
            get => _MeterMeasureDb.MeasureTypeName;
        }
        public bool MeasureTypeAccumulated
        { set => _MeterMeasureDb.MeasureTypeAccumulated = value; get => _MeterMeasureDb.MeasureTypeAccumulated; }
        public string MeasurTypeUnit
        {
            set
            {
                _MeterMeasureDb.MeasurTypeUnit = value;
            }
            get
            {
                return _MeterMeasureDb.MeasurTypeUnit;
            }
        }
        public double MeasureTypeFactor
        {
            set
            {
                _MeterMeasureDb.MeasureTypeFactor = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureTypeFactor;
            }
        }
        public string MeasureTypeWordStartAddress
        {
            set
            {
                _MeterMeasureDb.MeasureTypeWordStartAddress = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureTypeWordStartAddress;
            }
        }
        public int MeasureTypeWordNo
        {
            set
            {
                _MeterMeasureDb.MeasureTypeWordNo = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureTypeWordNo;
            }
        }
        public int MeasureTypeByteNo { get => MeasureTypeWordNo * 2; }
        public double MeasureValue
        {
            set
            {
                _MeterMeasureDb.MeasureValue = value;
            }
            get
            {
                return _MeterMeasureDb.MeasureValue;
            }
        }
        public double CurrentValue
        {
            get
            {
                if (MeasureTypeAccumulated)
                    return MeasureValue - MeasurePreviousValue;
                else
                    return MeasureValue;
            }
        }
        public double MeasurePreviousValue
        {
            set
            {
                _MeterMeasureDb.MeasurePreviousValue = value;
            }
            get
            {
                return _MeterMeasureDb.MeasurePreviousValue;
            }
        }
        DataType _DataType;
        public DataType DataType
        { set => _DataType = value; get => _DataType; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MeterMeasureDb.Add();
        }
        public void Edit()
        {
            _MeterMeasureDb.Edit();
        }
        public void Delete()
        {
            _MeterMeasureDb.Delete();
        }
        #endregion
    }
}
