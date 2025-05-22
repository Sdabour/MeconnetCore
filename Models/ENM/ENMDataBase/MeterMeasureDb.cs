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
    public class MeterMeasureDb
    {

        #region Constructor
        public MeterMeasureDb()
        {
        }
        public MeterMeasureDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _MeasureID;
        public int MeasureID
        {
            set
            {
                _MeasureID = value;
            }
            get
            {
                return _MeasureID;
            }
        }
        int _Meter;
        public int Meter
        {
            set
            {
                _Meter = value;
            }
            get
            {
                return _Meter;
            }
        }
        string _ProductName;
        public string ProductName { set => _ProductName = value; get => _ProductName; }
        DateTime _MeasureDate;
        public DateTime MeasureDate
        {
            set
            {
                _MeasureDate = value;
            }
            get
            {
                return _MeasureDate;
            }
        }
        DateTime _MeasureTime;
        public DateTime MeasureTime
        {
            set
            {
                _MeasureTime = value;
            }
            get
            {
                return _MeasureTime;
            }
        }
        double _FirstValue;
        public double FirstValue
        {
            set => _FirstValue = value;
            get => _FirstValue;
        }
        double _MinValue;
        public double MinValue
        {
            set => _MinValue = value;
            get => _MinValue;
        }
        double _MaxValue;
        public double MaxValue
        {
            set => _MaxValue = value;
            get => _MaxValue;
        }
        DateTime _MinTime;
        public DateTime MinTime
        {
            set => _MinTime = value;
            get => _MinTime;
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
        {
            set => _MeasureTypeName = value;
            get => _MeasureTypeName;
        }
        bool _MeasureTypeAccumulated;
        public bool MeasureTypeAccumulated { set => _MeasureTypeAccumulated = value; get => _MeasureTypeAccumulated; }
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
        double _MeasureValue;
        public double MeasureValue
        {
            set
            {
                _MeasureValue = value;
            }
            get
            {
                return _MeasureValue;
            }
        }
        double _MeasurePreviousValue;
        public double MeasurePreviousValue
        {
            set
            {
                _MeasurePreviousValue = value;
            }
            get
            {
                return _MeasurePreviousValue;
            }
        }
        int _Service;
        public int Service
        { set => _Service = value; }
        bool _JustLastValue;
        public bool JustLastValue
        {
            set { _JustLastValue = value; }
        }

        bool _JustLastValueByDate;
        public bool JustLastValueByDate
        {
            set { _JustLastValueByDate = value; }
        }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _DateStart;
        public DateTime DateStart { set => _DateStart = value; }
        DateTime _DateEnd;
        public DateTime DateEnd { set => _DateEnd = value; }
        DataTable _MeasureTable;
        public DataTable MeasureTable
        {
            set => _MeasureTable = value;
        }
        public string AddStr
        {
            get
            {
                string strMaxValue = @"SELECT        ENMEMeterMeasure_1.EMeasureValue
FROM            (SELECT        EMeter, EMeasureType, MAX(MeasureID) AS Expr1
                           FROM            dbo.ENMEMeterMeasure
                           GROUP BY EMeter, EMeasureType
                           HAVING        (EMeter = " + Meter + @") AND (EMeasureType = " + MeasureType + @")) AS derivedtbl_1 INNER JOIN
                         dbo.ENMEMeterMeasure AS ENMEMeterMeasure_1 ON derivedtbl_1.EMeter = ENMEMeterMeasure_1.EMeter AND derivedtbl_1.EMeasureType = ENMEMeterMeasure_1.EMeasureType AND 
                         derivedtbl_1.Expr1 = ENMEMeterMeasure_1.MeasureID";
                string Returned = @" insert into ENMEMeterMeasure (EMeter,EMeasureDate,EMeasureTime,EMeasureType,EMeasurTypeUnit,EMeasureTypeFactor,EMeasureTypeWordStartAddress,EMeasureTypeWordNo,EMeasureValue,EMeasurePreviousValue)
select " + Meter + " as Meter1," + (MeasureDate.ToOADate() - 2).ToString() + " as MeasureDate1," + (MeasureTime.ToOADate() - 2).ToString() + " as MeasureTime1," + MeasureType + " as MeasureType1,'" + MeasurTypeUnit + "' as MeasureUnit1," + MeasureTypeFactor + " as MeasureTypeFactor,'" + MeasureTypeWordStartAddress + "' as WordStartAddress," + MeasureTypeWordNo + " as WordNo1," + MeasureValue + " as MeasureValue,isnull((" + strMaxValue + @"),0) as PreviousValue from dbo.ENMEMeter
WHERE (EMeterID = " + _Meter + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeterMeasure set " + "MeasureID=" + MeasureID + "" +
           ",EMeter=" + Meter + "" +
           ",EMeasureDate=" + (MeasureDate.ToOADate() - 2).ToString() + "" +
           ",EMeasureTime=" + (MeasureTime.ToOADate() - 2).ToString() + "" +
           ",EMeasureType=" + MeasureType + "" +
           ",EMeasurTypeUnit='" + MeasurTypeUnit + "'" +
           ",EMeasureTypeFactor=" + MeasureTypeFactor + "" +
           ",EMeasureTypeWordStartAddress='" + MeasureTypeWordStartAddress + "'" +
           ",EMeasureTypeWordNo=" + MeasureTypeWordNo + "" +
           ",EMeasureValue=" + MeasureValue + "" +
           ",EMeasurePreviousValue=" + MeasurePreviousValue + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeterMeasure set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strLatest = @"SELECT        EMeter as MaxMeter,ProductName as MaxProductName, EMeasureType as MaxMeasureType , MAX(MeasureID) AS MaxMeasureID ";
                if (_JustLastValueByDate)
                    strLatest += ",EMeasureDate AS MaxMeasureDate ";
                strLatest += @" FROM            dbo.ENMEMeterMeasure
GROUP BY EMeter,ProductName, EMeasureType ";
                if (_JustLastValueByDate)
                    strLatest += ",EMeasureDate ";//Group By
                string Returned = @" select MeasureID,EMeter,ProductName,EMeasureDate,EMeasureTime,EMeasureType,EMeasurTypeUnit,EMeasureTypeFactor,EMeasureTypeWordStartAddress,EMeasureTypeWordNo
,EMeasureValue,EMeasurePreviousValue,EMeasureFirstValue, EMeasureMinValue, EMeasureMaxValue, EMeasureMinTime
,dbo.ENMEMeasureType.EMeasureTypeNameA as MeasureTypeName,EMeasureTypeAccumulated  as MeasureTypeAccumulated,MeterTable.* 
   from ENMEMeterMeasure 
    INNER JOIN
                         dbo.ENMEMeasureType ON dbo.ENMEMeterMeasure.EMeasureType = dbo.ENMEMeasureType.EMeasureTypeID 
    inner join (" + new EMeterDb().SearchStr + @")  as MeterTable 
 on dbo.ENMEMeterMeasure.EMeter = MeterTable.EMeterID ";
                if (_JustLastValue || _JustLastValueByDate)
                    Returned += @" inner join (" + strLatest + @") as MaxTable 
     on dbo.ENMEMeterMeasure.EMeter = MaxTable.MaxMeter and 
  dbo.ENMEMeasureType.EMeasureTypeID = MaxTable.MaxMeasureType and ENMEMeterMeasure.MeasureID =  MaxTable.MaxMeasureID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MeasureID"] != null)
                int.TryParse(objDr["MeasureID"].ToString(), out _MeasureID);

            if (objDr.Table.Columns["EMeter"] != null)
                int.TryParse(objDr["EMeter"].ToString(), out _Meter);
            if (objDr.Table.Columns["ProductName"] != null)
                _ProductName = objDr["ProductName"].ToString();
                if (objDr.Table.Columns["EMeasureDate"] != null)
                DateTime.TryParse(objDr["EMeasureDate"].ToString(), out _MeasureDate);

            if (objDr.Table.Columns["EMeasureMinTime"] != null)
                DateTime.TryParse(objDr["EMeasureMinTime"].ToString(), out _MinTime);
            if (objDr.Table.Columns["EMeasureTime"] != null)
                DateTime.TryParse(objDr["EMeasureTime"].ToString(), out _MeasureTime);

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

            if (objDr.Table.Columns["EMeasureValue"] != null)
                double.TryParse(objDr["EMeasureValue"].ToString(), out _MeasureValue);
            if (objDr.Table.Columns["EMeasureFirstValue"] != null)
                double.TryParse(objDr["EMeasureFirstValue"].ToString(), out _FirstValue);
            if (objDr.Table.Columns["EMeasureMinValue"] != null)
                double.TryParse(objDr["EMeasureMinValue"].ToString(), out _MinValue);
            if (objDr.Table.Columns["EMeasureMaxValue"] != null)
                double.TryParse(objDr["EMeasureMaxValue"].ToString(), out _MaxValue);
            if (objDr.Table.Columns["EMeasurePreviousValue"] != null)
                double.TryParse(objDr["EMeasurePreviousValue"].ToString(), out _MeasurePreviousValue);
            if (objDr.Table.Columns["MeasureTypeName"] != null)
                _MeasureTypeName = objDr["MeasureTypeName"].ToString();
            if (objDr.Table.Columns["MeasureTypeAccumulated"] != null)
                bool.TryParse(objDr["MeasureTypeAccumulated"].ToString(), out _MeasureTypeAccumulated);

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
            if (_Meter != 0)
                strSql += " and EMeter=" + _Meter;
            if (_MeasureType != 0)
                strSql += " and EMeasureType = " + _MeasureType;
            if (_IsDateRange)
            {
                strSql += " and EMeasureDate between " + (_DateStart.Date.ToOADate() - 2) + " and " + (_DateEnd.Date.ToOADate() - 2);
            }
        
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinMeterMeasure()
        {
            List<string> arrStr = new List<string>();
            MeterMeasureDb objDb;
            foreach (DataRow objDr in _MeasureTable.Rows)
            {
                objDb = new MeterMeasureDb(objDr);
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void SaveMeterMeasure()
        {
            if (_MeasureTable == null || _MeasureTable.Rows.Count == 0 || _Service == 0)
                return;
            string strSql = "delete from ENMEMeterMeasureTemp where Service=" + _Service;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "ENMEMeterMeasureTemp";
            objCopy.WriteToServer(_MeasureTable);
            int intTimePeriod = 10;
            string strLastMeasure = @"SELECT dbo.ENMEMeterMeasure.EMeter, dbo.ENMEMeterMeasure.EMeasureType, MAX(dbo.ENMEMeterMeasure.MeasureID) AS MaxMeasureID
FROM     dbo.ENMEMeterMeasure INNER JOIN
                  dbo.ENMEMeterMeasureTemp AS ENMEMeterMeasureTemp_1 ON dbo.ENMEMeterMeasure.EMeter = ENMEMeterMeasureTemp_1.EMeter AND dbo.ENMEMeterMeasure.EMeasureType = ENMEMeterMeasureTemp_1.EMeasureType AND
                   dbo.ENMEMeterMeasure.EMeasureDate = ENMEMeterMeasureTemp_1.EMeasureDate 
				    INNER JOIN
                  dbo.ENMEMeter ON dbo.ENMEMeterMeasure.EMeter = dbo.ENMEMeter.EMeterID INNER JOIN
                  dbo.ENMEMeterTypeMeasureType ON dbo.ENMEMeter.EMeterType = dbo.ENMEMeterTypeMeasureType.EMeterType AND dbo.ENMEMeterMeasure.EMeasureType = dbo.ENMEMeterTypeMeasureType.EMeasureType AND 
                  abs(dbo.ENMEMeterMeasure.EMeasureFirstValue - ENMEMeterMeasureTemp_1.EMeasureValue)< dbo.ENMEMeterTypeMeasureType.EMeasureTypeThreshold
WHERE  (ENMEMeterMeasureTemp_1.Service = " + _Service + @") AND (ENMEMeterMeasureTemp_1.EMeasureTime > DATEADD(minute, - " + intTimePeriod + @", dbo.ENMEMeterMeasure.EMeasureTime))
GROUP BY dbo.ENMEMeterMeasure.EMeter, dbo.ENMEMeterMeasure.EMeasureType";
            strSql = @" insert into ENMEMeterMeasure ( EMeter, EMeasureDate, EMeasureTime, EMeasureType, EMeasurTypeUnit, EMeasureTypeFactor, EMeasureTypeWordStartAddress, EMeasureTypeWordNo, EMeasureValue, EMeasureFirstValue, EMeasurePreviousValue, 
                  EMeasureMinValue, EMeasureMaxValue, EMeasureMinTime
) ";
            strSql += @"SELECT dbo.ENMEMeterMeasureTemp.EMeter, dbo.ENMEMeterMeasureTemp.EMeasureDate, dbo.ENMEMeterMeasureTemp.EMeasureTime, dbo.ENMEMeterMeasureTemp.EMeasureType, dbo.ENMEMeterMeasureTemp.EMeasurTypeUnit, 
                  dbo.ENMEMeterMeasureTemp.EMeasureTypeFactor, dbo.ENMEMeterMeasureTemp.EMeasureTypeWordStartAddress, dbo.ENMEMeterMeasureTemp.EMeasureTypeWordNo, dbo.ENMEMeterMeasureTemp.EMeasureValue, 
                  dbo.ENMEMeterMeasureTemp.EMeasureValue AS FirstMeasure, dbo.ENMEMeterMeasureTemp.EMeasurePreviousValue, dbo.ENMEMeterMeasureTemp.EMeasureValue AS MinValue, 
                  dbo.ENMEMeterMeasureTemp.EMeasureValue AS MaxValue, dbo.ENMEMeterMeasureTemp.EMeasureTime AS MinTime
FROM     dbo.ENMEMeterMeasureTemp LEFT OUTER JOIN
                      (" + strLastMeasure + @") AS LastMeasureTable ON dbo.ENMEMeterMeasureTemp.EMeter = LastMeasureTable.EMeter AND 
                  dbo.ENMEMeterMeasureTemp.EMeasureType = LastMeasureTable.EMeasureType
WHERE  (LastMeasureTable.EMeter IS NULL)";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"update  dbo.ENMEMeterMeasure set EMeasureValue= dbo.ENMEMeterMeasureTemp.EMeasureValue ,
EMeasureMinValue=CASE WHEN dbo.ENMEMeterMeasureTemp.EMeasureValue < dbo.ENMEMeterMeasure.EMeasureMinValue THEN dbo.ENMEMeterMeasureTemp.EMeasureValue ELSE dbo.ENMEMeterMeasure.EMeasureMinValue END, 
                  EMeasureMaxValue=CASE WHEN dbo.ENMEMeterMeasureTemp.EMeasureValue > dbo.ENMEMeterMeasure.EMeasureMaxValue THEN dbo.ENMEMeterMeasureTemp.EMeasureValue ELSE dbo.ENMEMeterMeasure.EMeasureMaxValue END ,
                 EMeasureTime= dbo.ENMEMeterMeasureTemp.EMeasureTime
FROM     dbo.ENMEMeterMeasure INNER JOIN
                      (SELECT EMeter, EMeasureType, MAX(MeasureID) AS MaxMeasureID
                       FROM      dbo.ENMEMeterMeasure AS ENMEMeterMeasure_1
                       GROUP BY EMeter, EMeasureType) AS derivedtbl_1 ON dbo.ENMEMeterMeasure.EMeter = derivedtbl_1.EMeter AND dbo.ENMEMeterMeasure.EMeasureType = derivedtbl_1.EMeasureType AND 
                  dbo.ENMEMeterMeasure.MeasureID = derivedtbl_1.MaxMeasureID INNER JOIN
                  dbo.ENMEMeterMeasureTemp ON dbo.ENMEMeterMeasure.EMeter = dbo.ENMEMeterMeasureTemp.EMeter AND dbo.ENMEMeterMeasure.EMeasureType = dbo.ENMEMeterMeasureTemp.EMeasureType ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
