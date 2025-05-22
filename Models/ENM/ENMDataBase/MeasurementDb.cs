using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class MeasurementDb
    {

        #region Constructor
        public MeasurementDb()
        {
        }
        public MeasurementDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _MeterID;
        public int MeterID
        {
            set => _MeterID = value;
            get => _MeterID;
        }
        string _ProductName;
        public string ProductName { set => _ProductName = value; get => _ProductName; }
        int _MeterTypeID;
        public int MeterTypeID
        {
            set => _MeterTypeID = value;
            get => _MeterTypeID;
        }
        string _MeterTypeCode;
        public string MeterTypeCode
        {
            set => _MeterTypeCode = value;
            get => _MeterTypeCode;
        }
        string _MeterDesc;
        public string MeterDesc
        {
            set => _MeterDesc = value;
            get => _MeterDesc;
        }
        string _MeterTypeNameA;
        public string MeterTypeNameA
        {
            set => _MeterTypeNameA = value;
            get => _MeterTypeNameA;
        }
        string _MeterTypeNameE;
        public string MeterTypeNameE
        {
            set => _MeterTypeNameE = value;
            get => _MeterTypeNameE;
        }
        int _MeterGroup;
        public int MeterGroup
        {
            set => _MeterGroup = value;
            get => _MeterGroup;
        }
        string _MeterGroupCode;
        public string MeterGroupCode
        {
            set => _MeterGroupCode = value;
            get => _MeterGroupCode;
        }
        string _MeterGroupNameA;
        public string MeterGroupNameA
        {
            set => _MeterGroupNameA = value;
            get => _MeterGroupNameA;
        }
        string _MeterGroupNameE;
        public string MeterGroupNameE
        {
            set => _MeterGroupNameE = value;
            get => _MeterGroupNameE;
        }
        string _MeterGroupDesc;
        public string MeterGroupDesc
        {
            set => _MeterGroupDesc = value;
            get => _MeterGroupDesc;
        }
        DateTime _LastNonZeroMeasureDate;
        public DateTime LastNonZeroMeasureDate
        {
            set => _LastNonZeroMeasureDate = value;
            get => _LastNonZeroMeasureDate;
        }
        DateTime _LastNonZeroMeasureTime;
        public DateTime LastNonZeroMeasureTime
        {
            set => _LastNonZeroMeasureTime = value;
            get => _LastNonZeroMeasureTime;
        }
        string _LastNonZeroMeasureUnit;
        public string LastNonZeroMeasureUnit
        {
            set => _LastNonZeroMeasureUnit = value;
            get => _LastNonZeroMeasureUnit;
        }
        double _LastNonZeroMeasureValue;
        public double LastNonZeroMeasureValue
        {
            set => _LastNonZeroMeasureValue = value;
            get => _LastNonZeroMeasureValue;
        }
        int _LastNonZeroMeasureType;
        public int LastNonZeroMeasureType
        {
            set => _LastNonZeroMeasureType = value;
            get => _LastNonZeroMeasureType;
        }
        int _LastNonZeroMeasureTypeID;
        public int LastNonZeroMeasureTypeID
        {
            set => _LastNonZeroMeasureTypeID = value;
            get => _LastNonZeroMeasureTypeID;
        }
        string _LastNonZeroMeasureTypeCode;
        public string LastNonZeroMeasureTypeCode
        {
            set => _LastNonZeroMeasureTypeCode = value;
            get => _LastNonZeroMeasureTypeCode;
        }
        string _LastNonZeroMeasureTypeNameA;
        public string LastNonZeroMeasureTypeNameA
        {
            set => _LastNonZeroMeasureTypeNameA = value;
            get => _LastNonZeroMeasureTypeNameA;
        }
        string _LastNonZeroMeasureTypeNameE;
        public string LastNonZeroMeasureTypeNameE
        {
            set => _LastNonZeroMeasureTypeNameE = value;
            get => _LastNonZeroMeasureTypeNameE;
        }
        DateTime _LastMeasureDate;
        public DateTime LastMeasureDate
        {
            set => _LastMeasureDate = value;
            get => _LastMeasureDate;
        }
        bool _MeasureDateRange;
        public bool MeasureDateRange
        {
            set => _MeasureDateRange = value;
        }
        DateTime _MeasureDate;
        public DateTime MeasureDate { set => _MeasureDate = value; }
        DateTime _LasMeasureTime;
        public DateTime LasMeasureTime
        {
            set => _LasMeasureTime = value;
            get => _LasMeasureTime;
        }
        string _LastMeasureUnit;
        public string LastMeasureUnit
        {
            set => _LastMeasureUnit = value;
            get => _LastMeasureUnit;
        }
        double _LastMeasureValue;
        public double LastMeasureValue
        {
            set => _LastMeasureValue = value;
            get => _LastMeasureValue;
        }
        int _LastMeasureType;
        public int LastMeasureType
        {
            set => _LastMeasureType = value;
            get => _LastMeasureType;
        }
        int _LastMeasureTypeID;
        public int LastMeasureTypeID
        {
            set => _LastMeasureTypeID = value;
            get => _LastMeasureTypeID;
        }
        string _LastMeasureTypeCode;
        public string LastMeasureTypeCode
        {
            set => _LastMeasureTypeCode = value;
            get => _LastMeasureTypeCode;
        }
        string _LastMeasureTypeNameA;
        public string LastMeasureTypeNameA
        {
            set => _LastMeasureTypeNameA = value;
            get => _LastMeasureTypeNameA;
        }
        string _LastMeasureTypeNameE;
        public string LastMeasureTypeNameE
        {
            set => _LastMeasureTypeNameE = value;
            get => _LastMeasureTypeNameE;
        }
        double _TypeMaxValue;
        public double TypeMaxValue { set => _TypeMaxValue = value; get => _TypeMaxValue; }
        double _TypeMinValue;
        public double TypeMinValue { set => _TypeMinValue = value; get => _TypeMinValue; }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into Measurement (MeterID,MeterTypeID,MeterTypeCode,MeterTypeNameA,MeterTypeNameE,MeterGroup,MeterGroupCode,MeterGroupNameA,MeterGroupNameE,MeterGroupDesc,LastNonZeroMeasureDate,LastNonZeroMeasureTime,LastNonZeroMeasureUnit,LastNonZeroMeasureValue,LastNonZeroMeasureType,LastNonZeroMeasureTypeID,LastNonZeroMeasureTypeCode,LastNonZeroMeasureTypeNameA,LastNonZeroMeasureTypeNameE,LastMeasureDate,LasMeasureTime,LastMeasureUnit,LastMeasureValue,LastMeasureType,LastMeasureTypeID,LastMeasureTypeCode,LastMeasureTypeNameA,LastMeasureTypeNameE,UsrIns,TimIns) values (," + MeterID + "," + MeterTypeID + ",'" + MeterTypeCode + "','" + MeterTypeNameA + "','" + MeterTypeNameE + "'," + MeterGroup + ",'" + MeterGroupCode + "','" + MeterGroupNameA + "','" + MeterGroupNameE + "','" + MeterGroupDesc + "'," + (LastNonZeroMeasureDate.ToOADate() - 2).ToString() + "," + (LastNonZeroMeasureTime.ToOADate() - 2).ToString() + ",'" + LastNonZeroMeasureUnit + "'," + LastNonZeroMeasureValue + "," + LastNonZeroMeasureType + "," + LastNonZeroMeasureTypeID + ",'" + LastNonZeroMeasureTypeCode + "','" + LastNonZeroMeasureTypeNameA + "','" + LastNonZeroMeasureTypeNameE + "'," + (LastMeasureDate.ToOADate() - 2).ToString() + "," + (LasMeasureTime.ToOADate() - 2).ToString() + ",'" + LastMeasureUnit + "'," + LastMeasureValue + "," + LastMeasureType + "," + LastMeasureTypeID + ",'" + LastMeasureTypeCode + "','" + LastMeasureTypeNameA + "','" + LastMeasureTypeNameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update Measurement set " + "MeterID=" + MeterID + "" +
           ",MeterTypeID=" + MeterTypeID + "" +
           ",MeterTypeCode='" + MeterTypeCode + "'" +
           ",MeterTypeNameA='" + MeterTypeNameA + "'" +
           ",MeterTypeNameE='" + MeterTypeNameE + "'" +
           ",MeterGroup=" + MeterGroup + "" +
           ",MeterGroupCode='" + MeterGroupCode + "'" +
           ",MeterGroupNameA='" + MeterGroupNameA + "'" +
           ",MeterGroupNameE='" + MeterGroupNameE + "'" +
           ",MeterGroupDesc='" + MeterGroupDesc + "'" +
           ",LastNonZeroMeasureDate=" + (LastNonZeroMeasureDate.ToOADate() - 2).ToString() + "" +
           ",LastNonZeroMeasureTime=" + (LastNonZeroMeasureTime.ToOADate() - 2).ToString() + "" +
           ",LastNonZeroMeasureUnit='" + LastNonZeroMeasureUnit + "'" +
           ",LastNonZeroMeasureValue=" + LastNonZeroMeasureValue + "" +
           ",LastNonZeroMeasureType=" + LastNonZeroMeasureType + "" +
           ",LastNonZeroMeasureTypeID=" + LastNonZeroMeasureTypeID + "" +
           ",LastNonZeroMeasureTypeCode='" + LastNonZeroMeasureTypeCode + "'" +
           ",LastNonZeroMeasureTypeNameA='" + LastNonZeroMeasureTypeNameA + "'" +
           ",LastNonZeroMeasureTypeNameE='" + LastNonZeroMeasureTypeNameE + "'" +
           ",LastMeasureDate=" + (LastMeasureDate.ToOADate() - 2).ToString() + "" +
           ",LasMeasureTime=" + (LasMeasureTime.ToOADate() - 2).ToString() + "" +
           ",LastMeasureUnit='" + LastMeasureUnit + "'" +
           ",LastMeasureValue=" + LastMeasureValue + "" +
           ",LastMeasureType=" + LastMeasureType + "" +
           ",LastMeasureTypeID=" + LastMeasureTypeID + "" +
           ",LastMeasureTypeCode='" + LastMeasureTypeCode + "'" +
           ",LastMeasureTypeNameA='" + LastMeasureTypeNameA + "'" +
           ",LastMeasureTypeNameE='" + LastMeasureTypeNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update Measurement set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string StrMaxMeasureTable = @"SELECT EMeter,isnull(ProductName,'') as ProductName, MAX(MeasureID) AS MaxMeasure, EMeasureType
                       FROM      dbo.ENMEMeterMeasure AS ENMEMeterMeasure_2 ";
                if(_IsDateRange)
                StrMaxMeasureTable += " where ENMEMeterMeasure_2.EMeasureTime >= "+(_StartDate.Date.ToOADate()-2)+ " and ENMEMeterMeasure_2.EMeasureTime <= " + (_EndDate.Date.ToOADate() - 2);

                StrMaxMeasureTable+= @"
                       GROUP BY EMeter,ProductName, EMeasureType";
                string strMaxNonZeroMeasure = @"SELECT EMeter,isnull(ProductName,'') as ProductName, MAX(MeasureID) AS MaxMeasure, EMeasureType
                       FROM      dbo.ENMEMeterMeasure
                       WHERE   (EMeasureValue > 0)
                       GROUP BY EMeter,ProductName, EMeasureType";
                string Returned = @" SELECT dbo.ENMEMeter.EMeterID AS MeterID, dbo.ENMEMeterType.EMeterTypeID AS MeterTypeID, dbo.ENMEMeterType.EMeterTypeCode AS MeterTypeCode, dbo.ENMEMeterType.EMeterTypeNameA AS MeterTypeNameA, 
                  dbo.ENMEMeterType.EMeterTypeNameE AS MeterTypeNameE, dbo.ENMEMeterGroup.GroupID AS MeterGroup, dbo.ENMEMeterGroup.GroupCode AS MeterGroupCode, dbo.ENMEMeterGroup.GroupNameA AS MeterGroupNameA, 
                  dbo.ENMEMeterGroup.GroupNameE AS MeterGroupNameE, dbo.ENMEMeterGroup.GroupDesc AS MeterGroupDesc, ENMEMeterMeasure_1.EMeasureDate AS LastNonZeroMeasureDate, 
                  ENMEMeterMeasure_1.EMeasureTime AS LastNonZeroMeasureTime, ENMEMeterMeasure_1.EMeasurTypeUnit AS LastNonZeroMeasureUnit, ENMEMeterMeasure_1.EMeasureValue AS LastNonZeroMeasureValue, 
                  ENMEMeterMeasure_1.EMeasureType AS LastNonZeroMeasureType, dbo.ENMEMeasureType.EMeasureTypeID AS LastNonZeroMeasureTypeID, dbo.ENMEMeasureType.EMeasureTypeCode AS LastNonZeroMeasureTypeCode, 
                  dbo.ENMEMeasureType.EMeasureTypeNameA AS LastNonZeroMeasureTypeNameA, dbo.ENMEMeasureType.EMeasureTypeNameE AS LastNonZeroMeasureTypeNameE, ENMEMeterMeasure_3.ProductName, ENMEMeterMeasure_3.EMeasureDate AS LastMeasureDate, 
                  ENMEMeterMeasure_3.EMeasureTime AS LasMeasureTime, ENMEMeterMeasure_3.EMeasurTypeUnit AS LastMeasureUnit, ENMEMeterMeasure_3.EMeasureValue AS LastMeasureValue, 
                  ENMEMeterMeasure_3.EMeasureType AS LastMeasureType, ENMEMeasureType_1.EMeasureTypeID AS LastMeasureTypeID, ENMEMeasureType_1.EMeasureTypeCode AS LastMeasureTypeCode, 
                  ENMEMeasureType_1.EMeasureTypeNameA AS LastMeasureTypeNameA, ENMEMeasureType_1.EMeasureTypeNameE AS LastMeasureTypeNameE, dbo.ENMEMeter.EMeterDesc AS MeterDesc, 
                  dbo.ENMEMeterTypeMeasureType.EMeasureTypeMinValue, dbo.ENMEMeterTypeMeasureType.EMeasureTypeMaxValue, dbo.ENMEMeterTypeMeasureType.EMeasureType
    FROM    dbo.ENMEMeterMeasure AS ENMEMeterMeasure_3 inner join 
  dbo.ENMEMeasureType AS ENMEMeasureType_1 
                   ON ENMEMeterMeasure_3.EMeasureType =  ENMEMeasureType_1.EMeasureTypeID 
    INNER JOIN
                  dbo.ENMEMeter  on ENMEMeterMeasure_3.EMeter = dbo.ENMEMeter.EMeterID 
 left outer  JOIN
                  dbo.ENMEMeterType
 on dbo.ENMEMeter.EMeterType = dbo.ENMEMeterType.EMeterTypeID 
 inner  JOIN
                      (" + StrMaxMeasureTable+ @") AS MaxMeasureTable 
   on ENMEMeterMeasure_3.EMeter = MaxMeasureTable.EMeter and ENMEMeterMeasure_3.MeasureID = MaxMeasureTable.MaxMeasure
 left OUTER JOIN
                      (" + strMaxNonZeroMeasure+ @") AS MaxNonZeroMeasureTable
   on ENMEMeterMeasure_3.EMeter =MaxNonZeroMeasureTable.EMeter and ENMEMeterMeasure_3.EMeasureType =MaxNonZeroMeasureTable.EMeasureType  
 and isnull(ENMEMeterMeasure_3.ProductName,'') =MaxNonZeroMeasureTable.ProductName 
 left outer join dbo.ENMEMeterMeasure as ENMEMeterMeasure_1

ON MaxNonZeroMeasureTable.MaxMeasure = ENMEMeterMeasure_1.MeasureID  AND 
                  MaxNonZeroMeasureTable.EMeter = ENMEMeterMeasure_1.EMeter  
 LEFT OUTER JOIN
                  dbo.ENMEMeasureType ON ENMEMeterMeasure_3.EMeasureType = dbo.ENMEMeasureType.EMeasureTypeID left  OUTER JOIN
                  dbo.ENMEMeterTypeMeasureType    ON dbo.ENMEMeter.EMeterType = dbo.ENMEMeterTypeMeasureType.EMeterType and MaxNonZeroMeasureTable.EMeasureType = dbo.ENMEMeterTypeMeasureType.EMeasureType   LEFT OUTER JOIN
                  dbo.ENMEMeterGroup ON dbo.ENMEMeter.EMeterGroup = dbo.ENMEMeterGroup.GroupID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MeterID"] != null)
                int.TryParse(objDr["MeterID"].ToString(), out _MeterID);

            if (objDr.Table.Columns["MeterTypeID"] != null)
                int.TryParse(objDr["MeterTypeID"].ToString(), out _MeterTypeID);

            if (objDr.Table.Columns["MeterTypeCode"] != null)
                _MeterTypeCode = objDr["MeterTypeCode"].ToString();

            if (objDr.Table.Columns["MeterDesc"] != null)
                _MeterDesc = objDr["MeterDesc"].ToString();
            if (objDr.Table.Columns["MeterTypeNameA"] != null)
                _MeterTypeNameA = objDr["MeterTypeNameA"].ToString();

            if (objDr.Table.Columns["MeterTypeNameE"] != null)
                _MeterTypeNameE = objDr["MeterTypeNameE"].ToString();

            if (objDr.Table.Columns["MeterGroup"] != null)
                int.TryParse(objDr["MeterGroup"].ToString(), out _MeterGroup);

            if (objDr.Table.Columns["MeterGroupCode"] != null)
                _MeterGroupCode = objDr["MeterGroupCode"].ToString();

            if (objDr.Table.Columns["MeterGroupNameA"] != null)
                _MeterGroupNameA = objDr["MeterGroupNameA"].ToString();

            if (objDr.Table.Columns["MeterGroupNameE"] != null)
                _MeterGroupNameE = objDr["MeterGroupNameE"].ToString();

            if (objDr.Table.Columns["MeterGroupDesc"] != null)
                _MeterGroupDesc = objDr["MeterGroupDesc"].ToString();

            if (objDr.Table.Columns["LastNonZeroMeasureDate"] != null)
                DateTime.TryParse(objDr["LastNonZeroMeasureDate"].ToString(), out _LastNonZeroMeasureDate);

            if (objDr.Table.Columns["LastNonZeroMeasureTime"] != null)
                DateTime.TryParse(objDr["LastNonZeroMeasureTime"].ToString(), out _LastNonZeroMeasureTime);

            if (objDr.Table.Columns["LastNonZeroMeasureUnit"] != null)
                _LastNonZeroMeasureUnit = objDr["LastNonZeroMeasureUnit"].ToString();

            if (objDr.Table.Columns["LastNonZeroMeasureValue"] != null)
                double.TryParse(objDr["LastNonZeroMeasureValue"].ToString(), out _LastNonZeroMeasureValue);

            if (objDr.Table.Columns["LastNonZeroMeasureType"] != null)
                int.TryParse(objDr["LastNonZeroMeasureType"].ToString(), out _LastNonZeroMeasureType);

            if (objDr.Table.Columns["LastNonZeroMeasureTypeID"] != null)
                int.TryParse(objDr["LastNonZeroMeasureTypeID"].ToString(), out _LastNonZeroMeasureTypeID);

            if (objDr.Table.Columns["LastNonZeroMeasureTypeCode"] != null)
                _LastNonZeroMeasureTypeCode = objDr["LastNonZeroMeasureTypeCode"].ToString();

            if (objDr.Table.Columns["LastNonZeroMeasureTypeNameA"] != null)
                _LastNonZeroMeasureTypeNameA = objDr["LastNonZeroMeasureTypeNameA"].ToString();

            if (objDr.Table.Columns["LastNonZeroMeasureTypeNameE"] != null)
                _LastNonZeroMeasureTypeNameE = objDr["LastNonZeroMeasureTypeNameE"].ToString();

            if (objDr.Table.Columns["LastMeasureDate"] != null)
                DateTime.TryParse(objDr["LastMeasureDate"].ToString(), out _LastMeasureDate);

            if (objDr.Table.Columns["LasMeasureTime"] != null)
                DateTime.TryParse(objDr["LasMeasureTime"].ToString(), out _LasMeasureTime);

            if (objDr.Table.Columns["LastMeasureUnit"] != null)
                _LastMeasureUnit = objDr["LastMeasureUnit"].ToString();

            if (objDr.Table.Columns["LastMeasureValue"] != null)
                double.TryParse(objDr["LastMeasureValue"].ToString(), out _LastMeasureValue);

            if (objDr.Table.Columns["LastMeasureType"] != null)
                int.TryParse(objDr["LastMeasureType"].ToString(), out _LastMeasureType);

            if (objDr.Table.Columns["LastMeasureTypeID"] != null)
                int.TryParse(objDr["LastMeasureTypeID"].ToString(), out _LastMeasureTypeID);

            if (objDr.Table.Columns["LastMeasureTypeCode"] != null)
                _LastMeasureTypeCode = objDr["LastMeasureTypeCode"].ToString();

            if (objDr.Table.Columns["LastMeasureTypeNameA"] != null)
                _LastMeasureTypeNameA = objDr["LastMeasureTypeNameA"].ToString();

            if (objDr.Table.Columns["LastMeasureTypeNameE"] != null)
                _LastMeasureTypeNameE = objDr["LastMeasureTypeNameE"].ToString();

            if (objDr.Table.Columns["EMeasureTypeMaxValue"] != null)
                double.TryParse(objDr["EMeasureTypeMaxValue"].ToString(), out _TypeMaxValue);
            if (objDr.Table.Columns["EMeasureTypeMinValue"] != null)
                double.TryParse(objDr["EMeasureTypeMinValue"].ToString(), out _TypeMinValue);
            if(objDr.Table.Columns["ProductName"]!=null)
            {
                _ProductName = objDr["ProductName"].ToString();
            }  
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
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_MeasureDateRange)
                strSql += " and ENMEMeterMeasure_1.EMeasureDate = " + (_MeasureDate.Date.ToOADate()-2).ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            //System.Dynamic.ExpandoObject objJson =  new System.Dynamic.ExpandoObject();
            //((System.Collections.IDictionary<string, object>)objJson).Add("", new object);

        }
        #endregion
    }
}