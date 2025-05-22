using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterTypeMeasureTypeBiz
    {

        #region Constructor
        public EMeterTypeMeasureTypeBiz()
        {
            _EMeterTypeMeasureTypeDb = new EMeterTypeMeasureTypeDb();
        }
        public EMeterTypeMeasureTypeBiz(DataRow objDr)
        {
            _EMeterTypeMeasureTypeDb = new EMeterTypeMeasureTypeDb(objDr);
        }

        #endregion
        #region Private Data
        EMeterTypeMeasureTypeDb _EMeterTypeMeasureTypeDb;
        #endregion
        #region Properties
        public int MeterType
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeterType = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeterType;
            }
        }
        EMeasureTypeBiz _MeasureTypeBiz;
        public EMeasureTypeBiz MeasureTypeBiz
        {
            set => _MeasureTypeBiz = value;
            get
            {
                if (_MeasureTypeBiz == null)
                {
                    _MeasureTypeBiz = new EMeasureTypeBiz() { ID=MeasureType,NameA=MeasureTypeName,Unit=MeasurTypeUnit};
                }
                return _MeasureTypeBiz;
            }
        }
        public int MeasureType
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeasureType = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeasureType;
            }
        }
        public string MeasureTypeName
        {
            get => _EMeterTypeMeasureTypeDb.MeasureTypeName;
        }
        public string MeasurTypeUnit
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeasurTypeUnit = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeasurTypeUnit;
            }
        }
        public double MeasureTypeFactor
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeasureTypeFactor = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeasureTypeFactor;
            }
        }
        public string MeasureTypeWordStartAddress
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeasureTypeWordStartAddress = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeasureTypeWordStartAddress;
            }
        }
        public int MeasureTypeWordNo
        {
            set
            {
                _EMeterTypeMeasureTypeDb.MeasureTypeWordNo = value;
            }
            get
            {
                return _EMeterTypeMeasureTypeDb.MeasureTypeWordNo;
            }
        }
        public DataType DataType { set => _EMeterTypeMeasureTypeDb.DataType = (int)value; get => (DataType)_EMeterTypeMeasureTypeDb.DataType; }
        public double MinValue { set => _EMeterTypeMeasureTypeDb.MinValue=value;
            get => _EMeterTypeMeasureTypeDb.MinValue;
        }
        public double MaxValue
        {
            set => _EMeterTypeMeasureTypeDb.MaxValue = value;
            get => _EMeterTypeMeasureTypeDb.MaxValue;
        }
        public double Threshold
        {
            set => _EMeterTypeMeasureTypeDb.Threshold = value;
            get => _EMeterTypeMeasureTypeDb.Threshold;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EMeterTypeMeasureTypeDb.Add();
        }
        public void Edit()
        {
            _EMeterTypeMeasureTypeDb.Edit();
        }
        public void Delete()
        {
            _EMeterTypeMeasureTypeDb.Delete();
        }
        public MeterMeasureBiz GetMeterMeasure(int intMeter,DateTime dtTime)
        {
            MeterMeasureBiz Returned = new MeterMeasureBiz() { MeasureDate=DateTime.Now.Date,MeasureTime=dtTime,MeasureType=MeasureType,MeasureTypeFactor=MeasureTypeFactor,MeasureTypeWordNo = MeasureTypeWordNo,MeasureTypeWordStartAddress=MeasureTypeWordStartAddress,MeasurTypeUnit = MeasurTypeUnit,Meter=intMeter,MeasureTypeName=MeasureTypeName,DataType=DataType};
           

            return Returned;
        }
        #endregion
    }
}
