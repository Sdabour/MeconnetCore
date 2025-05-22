using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class EMeterTypeMeasureTypeDb
    {

        #region Constructor
        public EMeterTypeMeasureTypeDb()
        {
        }
        public EMeterTypeMeasureTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _MeterType;
        public int MeterType
        {
            set
            {
                _MeterType = value;
            }
            get
            {
                return _MeterType;
            }
        }
        int _MeasureType;
        public int MeasureType
        {
            set
            {
                _MeasureType = value;
            }
            get
            {
                return _MeasureType;
            }
        }
        string _MeasureTypeName;
        public string MeasureTypeName
        { set => _MeasureTypeName = value;
            get => _MeasureTypeName;
        }
        string _MeasurTypeUnit;
        public string MeasurTypeUnit
        {
            set
            {
                _MeasurTypeUnit = value;
            }
            get
            {
                return _MeasurTypeUnit;
            }
        }
        double _MeasureTypeFactor;
        public double MeasureTypeFactor
        {
            set
            {
                _MeasureTypeFactor = value;
            }
            get
            {
                return _MeasureTypeFactor;
            }
        }
        string _MeasureTypeWordStartAddress;
        public string MeasureTypeWordStartAddress
        {
            set
            {
                _MeasureTypeWordStartAddress = value;
            }
            get
            {
                return _MeasureTypeWordStartAddress;
            }
        }
        int _MeasureTypeWordNo;
        public int MeasureTypeWordNo
        {
            set
            {
                _MeasureTypeWordNo = value;
            }
            get
            {
                return _MeasureTypeWordNo;
            }
        }
        int _DataType;
        public int DataType { set => _DataType = value; get => _DataType; }
        double _MinValue;
        public double MinValue
        {
            set => _MinValue = value;
            get => _MinValue;
        }
        double _MaxValue;
        public double MaxValue
        { set => _MaxValue = value;
            get => _MaxValue;
        }
        double _Threshold;
        public double Threshold
        {
            set => _Threshold = value;
            get => _Threshold;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ENMEMeterTypeMeasureType (EMeterType,EMeasureType,EMeasurTypeUnit,EMeasureTypeFactor,EMeasureTypeWordStartAddress,EMeasureTypeWordNo,EMeasureTypeDataType,EMeasureTypeMinValue,EMeasureTypeMaxValue,EMeasureTypeThreshold) values (" + MeterType + "," + MeasureType + ",'" + MeasurTypeUnit + "'," + MeasureTypeFactor + ",'" + MeasureTypeWordStartAddress + "'," + MeasureTypeWordNo +","+ _DataType+","+_MinValue +","+_MaxValue+ ","+ _Threshold+") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeterTypeMeasureType set " + "EMeterType=" + MeterType + "" +
           ",EMeasureType=" + MeasureType + "" +
           ",EMeasurTypeUnit='" + MeasurTypeUnit + "'" +
           ",EMeasureTypeFactor=" + MeasureTypeFactor + "" +
           ",EMeasureTypeWordStartAddress='" + MeasureTypeWordStartAddress + "'" +
           ",EMeasureTypeWordNo=" + MeasureTypeWordNo +
           ",EMeasureTypeDataType="+_DataType +
            ",EMeasureTypeThreshold="+_Threshold +
           ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from ENMEMeterTypeMeasureType  where  EMeterType = "+ _MeterType;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select EMeterType,EMeasureType,EMeasurTypeUnit,EMeasureTypeFactor,EMeasureTypeWordStartAddress,EMeasureTypeWordNo,EMeasureTypeMinValue,EMeasureTypeMaxValue,EMeasureTypeThreshold,dbo.ENMEMeasureType.EMeasureTypeNameA AS MeasureTypeName,EMeasureTypeDataType 
  from ENMEMeterTypeMeasureType INNER JOIN
                         dbo.ENMEMeasureType ON dbo.ENMEMeterTypeMeasureType.EMeasureType = dbo.ENMEMeasureType.EMeasureTypeID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["EMeterType"] != null)
                int.TryParse(objDr["EMeterType"].ToString(), out _MeterType);

            if (objDr.Table.Columns["EMeasureType"] != null)
                int.TryParse(objDr["EMeasureType"].ToString(), out _MeasureType);

            if (objDr.Table.Columns["EMeasurTypeUnit"] != null)
                _MeasurTypeUnit = objDr["EMeasurTypeUnit"].ToString();

            if (objDr.Table.Columns["EMeasureTypeFactor"] != null)
                double.TryParse(objDr["EMeasureTypeFactor"].ToString(), out _MeasureTypeFactor);

            if (objDr.Table.Columns["EMeasureTypeWordStartAddress"] != null)
                _MeasureTypeWordStartAddress = objDr["EMeasureTypeWordStartAddress"].ToString();

            if (objDr.Table.Columns["EMeasureTypeWordNo"] != null)
                int.TryParse(objDr["EMeasureTypeWordNo"].ToString(), out _MeasureTypeWordNo);
            if (objDr.Table.Columns["MeasureTypeName"] != null)
                _MeasureTypeName = objDr["MeasureTypeName"].ToString();
            if (objDr.Table.Columns["EMeasureTypeDataType"] != null)
                int.TryParse(objDr["EMeasureTypeDataType"].ToString(), out _DataType);
            if (objDr.Table.Columns["EMeasureTypeMinValue"] != null)
                double.TryParse(objDr["EMeasureTypeMinValue"].ToString(), out _MinValue);
            if (objDr.Table.Columns["EMeasureTypeThreshold"] != null)
                double.TryParse(objDr["EMeasureTypeThreshold"].ToString(), out _Threshold);
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
            if (_MeterType != 0)
                strSql += " and EMeterType = "+_MeterType;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
