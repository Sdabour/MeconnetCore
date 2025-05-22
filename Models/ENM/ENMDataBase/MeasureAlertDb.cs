using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
using SharpVision.UMS.UMSDataBase;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class MeasureAlertDb
    {
        // AlertID, AlertMeter, AlertMeasureType, AlertTime, AlertMinValue, AlertMaxValue, AlertValue, AlertReason, AlertStop, AlertStopTime, AlertAck, AlertAckUser, AlertAckTime, AlertSnoozeTime, EMeasureTypeNameA, EMeasureTypeNameE,  EMeasureTypeUnit, EMeasureTypeAccumulated, EMeterDesc, UFN, UN

        #region Constructor
        public MeasureAlertDb()
        {
        }
        public MeasureAlertDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _Meter;
        public int Meter
        {
            set => _Meter = value;
            get => _Meter;
        }
        int _MeasureType;
        public int MeasureType
        {
            set => _MeasureType = value;
            get => _MeasureType;
        }
        DateTime _Time;
        public DateTime Time
        {
            set => _Time = value;
            get => _Time;
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
        double _Value;
        public double Value
        {
            set => _Value = value;
            get => _Value;
        }
        int _Reason;
        public int Reason
        {
            set => _Reason = value;
            get => _Reason;
        }
        bool _Stop;
        public bool Stop
        {
            set => _Stop = value;
            get => _Stop;
        }
        DateTime _StopTime;
        public DateTime StopTime
        {
            set => _StopTime = value;
            get => _StopTime;
        }
        bool _Ack;
        public bool Ack
        {
            set => _Ack = value;
            get => _Ack;
        }
        int _AckUser;
        public int AckUser
        {
            set => _AckUser = value;
            get => _AckUser;
        }
        DateTime _AckTime;
        public DateTime AckTime
        {
            set => _AckTime = value;
            get => _AckTime;
        }
        DateTime _SnoozeTime;
        public DateTime SnoozeTime
        {
            set => _SnoozeTime = value;
            get => _SnoozeTime;
        }
        string _EMeasureTypeNameA;
        public string EMeasureTypeNameA
        {
            set => _EMeasureTypeNameA = value;
            get => _EMeasureTypeNameA;
        }
        string _EMeasureTypeNameE;
        public string EMeasureTypeNameE
        {
            set => _EMeasureTypeNameE = value;
            get => _EMeasureTypeNameE;
        }
        string _EMeasureTypeUnit;
        public string EMeasureTypeUnit
        {
            set => _EMeasureTypeUnit = value;
            get => _EMeasureTypeUnit;
        }
        bool _EMeasureTypeAccumulated;
        public bool EMeasureTypeAccumulated
        {
            set => _EMeasureTypeAccumulated = value;
            get => _EMeasureTypeAccumulated;
        }
        string _EMeterDesc;
        public string EMeterDesc
        {
            set => _EMeterDesc = value;
            get => _EMeterDesc;
        }
        string _UFN;
        public string UFN
        {
            set => _UFN = value;
            get => _UFN;
        }
        string _UN;
        public string UN
        {
            set => _UN = value;
            get => _UN;
        }
        bool _OnlyLastStatus;
        public bool OnlyLastStatus { set => _OnlyLastStatus = value; get => _OnlyLastStatus; }
        int _StoppedStatus;
        public int StoppedStatus { set => _StoppedStatus = value; }
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
                string Returned = " insert into ENMEMeterMeasureAlert (AlertID,AlertMeter,AlertMeasureType,AlertTime,AlertMinValue,AlertMaxValue,AlertValue,AlertReason,AlertStop,AlertStopTime,AlertAck,AlertAckUser,AlertAckTime,AlertSnoozeTime,EMeasureTypeNameA,EMeasureTypeNameE,EMeasureTypeUnit,EMeasureTypeAccumulated,EMeterDesc,UFN,UN,UsrIns,TimIns) values (," + ID + "," + Meter + "," + MeasureType + "," + (Time.ToOADate() - 2).ToString() + "," + MinValue + "," + MaxValue + "," + Value + "," + Reason + "," + (Stop ? 1 : 0) + "," + (StopTime.ToOADate() - 2).ToString() + "," + (Ack ? 1 : 0) + "," + AckUser + "," + (AckTime.ToOADate() - 2).ToString() + "," + (SnoozeTime.ToOADate() - 2).ToString() + ",'" + EMeasureTypeNameA + "','" + EMeasureTypeNameE + "','" + EMeasureTypeUnit + "'," + (EMeasureTypeAccumulated ? 1 : 0) + ",'" + EMeterDesc + "','" + UFN + "','" + UN + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeterMeasureAlert set " + "AlertID=" + ID + "" +
           ",AlertMeter=" + Meter + "" +
           ",AlertMeasureType=" + MeasureType + "" +
           ",AlertTime=" + (Time.ToOADate() - 2).ToString() + "" +
           ",AlertMinValue=" + MinValue + "" +
           ",AlertMaxValue=" + MaxValue + "" +
           ",AlertValue=" + Value + "" +
           ",AlertReason=" + Reason + "" +
           ",AlertStop=" + (Stop ? 1 : 0) + "" +
           ",AlertStopTime=" + (StopTime.ToOADate() - 2).ToString() + "" +
           ",AlertAck=" + (Ack ? 1 : 0) + "" +
           ",AlertAckUser=" + AckUser + "" +
           ",AlertAckTime=" + (AckTime.ToOADate() - 2).ToString() + "" +
           ",AlertSnoozeTime=" + (SnoozeTime.ToOADate() - 2).ToString() + "" +
           ",EMeasureTypeNameA='" + EMeasureTypeNameA + "'" +
           ",EMeasureTypeNameE='" + EMeasureTypeNameE + "'" +
           ",EMeasureTypeUnit='" + EMeasureTypeUnit + "'" +
           ",EMeasureTypeAccumulated=" + (EMeasureTypeAccumulated ? 1 : 0) + "" +
           ",EMeterDesc='" + EMeterDesc + "'" +
           ",UFN='" + UFN + "'" +
           ",UN='" + UN + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeterMeasureAlert set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT dbo.ENMEMeterMeasureAlert.AlertID, dbo.ENMEMeterMeasureAlert.AlertMeter, dbo.ENMEMeterMeasureAlert.AlertMeasureType, dbo.ENMEMeterMeasureAlert.AlertTime, dbo.ENMEMeterMeasureAlert.AlertMinValue, 
                  dbo.ENMEMeterMeasureAlert.AlertMaxValue, dbo.ENMEMeterMeasureAlert.AlertValue, dbo.ENMEMeterMeasureAlert.AlertReason, dbo.ENMEMeterMeasureAlert.AlertStop, dbo.ENMEMeterMeasureAlert.AlertStopTime, 
                  dbo.ENMEMeterMeasureAlert.AlertAck, dbo.ENMEMeterMeasureAlert.AlertAckUser, dbo.ENMEMeterMeasureAlert.AlertAckTime, dbo.ENMEMeterMeasureAlert.AlertSnoozeTime, dbo.ENMEMeasureType.EMeasureTypeNameA, 
                  dbo.ENMEMeasureType.EMeasureTypeNameE, dbo.ENMEMeasureType.EMeasureTypeUnit, dbo.ENMEMeasureType.EMeasureTypeAccumulated, dbo.ENMEMeter.EMeterDesc, dbo.UMSUser.UFN, dbo.UMSUser.UN
,case when dbo.ENMEMeterMeasureAlert.AlertAck=1 or dbo.ENMEMeterMeasureAlert.AlertStop=1 then 1 else 0 end as AlertStopped 
FROM     dbo.ENMEMeterMeasureAlert  INNER JOIN
                  dbo.ENMEMeter ON dbo.ENMEMeterMeasureAlert.AlertMeter = dbo.ENMEMeter.EMeterID INNER JOIN
                  dbo.ENMEMeasureType ON dbo.ENMEMeterMeasureAlert.AlertMeasureType = dbo.ENMEMeasureType.EMeasureTypeID LEFT OUTER JOIN
                  dbo.UMSUser ON dbo.ENMEMeterMeasureAlert.AlertAckUser = dbo.UMSUser.UID ";
                if(_OnlyLastStatus)
                {
                    Returned += @" INNER JOIN
                      (SELECT AlertMeter, AlertMeasureType, AlertReason, MAX(AlertID) AS MaxAlertID
                       FROM      dbo.ENMEMeterMeasureAlert AS ENMEMeterMeasureAlert_1
                       GROUP BY AlertMeter, AlertMeasureType, AlertReason) AS MaxAlertTable ON dbo.ENMEMeterMeasureAlert.AlertMeter = MaxAlertTable.AlertMeter AND
                  dbo.ENMEMeterMeasureAlert.AlertMeasureType = MaxAlertTable.AlertMeasureType AND dbo.ENMEMeterMeasureAlert.AlertReason = MaxAlertTable.AlertReason AND
                  dbo.ENMEMeterMeasureAlert.AlertID = MaxAlertTable.MaxAlertID ";
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["AlertID"] != null)
                int.TryParse(objDr["AlertID"].ToString(), out _ID);

            if (objDr.Table.Columns["AlertMeter"] != null)
                int.TryParse(objDr["AlertMeter"].ToString(), out _Meter);

            if (objDr.Table.Columns["AlertMeasureType"] != null)
                int.TryParse(objDr["AlertMeasureType"].ToString(), out _MeasureType);

            if (objDr.Table.Columns["AlertTime"] != null)
                DateTime.TryParse(objDr["AlertTime"].ToString(), out _Time);

            if (objDr.Table.Columns["AlertMinValue"] != null)
                double.TryParse(objDr["AlertMinValue"].ToString(), out _MinValue);

            if (objDr.Table.Columns["AlertMaxValue"] != null)
                double.TryParse(objDr["AlertMaxValue"].ToString(), out _MaxValue);

            if (objDr.Table.Columns["AlertValue"] != null)
                double.TryParse(objDr["AlertValue"].ToString(), out _Value);

            if (objDr.Table.Columns["AlertReason"] != null)
                int.TryParse(objDr["AlertReason"].ToString(), out _Reason);

            if (objDr.Table.Columns["AlertStop"] != null)
                bool.TryParse(objDr["AlertStop"].ToString(), out _Stop);

            if (objDr.Table.Columns["AlertStopTime"] != null)
                DateTime.TryParse(objDr["AlertStopTime"].ToString(), out _StopTime);

            if (objDr.Table.Columns["AlertAck"] != null)
                bool.TryParse(objDr["AlertAck"].ToString(), out _Ack);

            if (objDr.Table.Columns["AlertAckUser"] != null)
                int.TryParse(objDr["AlertAckUser"].ToString(), out _AckUser);

            if (objDr.Table.Columns["AlertAckTime"] != null)
                DateTime.TryParse(objDr["AlertAckTime"].ToString(), out _AckTime);

            if (objDr.Table.Columns["AlertSnoozeTime"] != null)
                DateTime.TryParse(objDr["AlertSnoozeTime"].ToString(), out _SnoozeTime);

            if (objDr.Table.Columns["EMeasureTypeNameA"] != null)
                _EMeasureTypeNameA = objDr["EMeasureTypeNameA"].ToString();

            if (objDr.Table.Columns["EMeasureTypeNameE"] != null)
                _EMeasureTypeNameE = objDr["EMeasureTypeNameE"].ToString();

            if (objDr.Table.Columns["EMeasureTypeUnit"] != null)
                _EMeasureTypeUnit = objDr["EMeasureTypeUnit"].ToString();

            if (objDr.Table.Columns["EMeasureTypeAccumulated"] != null)
                bool.TryParse(objDr["EMeasureTypeAccumulated"].ToString(), out _EMeasureTypeAccumulated);

            if (objDr.Table.Columns["EMeterDesc"] != null)
                _EMeterDesc = objDr["EMeterDesc"].ToString();

            if (objDr.Table.Columns["UFN"] != null)
                _UFN = objDr["UFN"].ToString();

            if (objDr.Table.Columns["UN"] != null)
                _UN = objDr["UN"].ToString();
            _UN = UserDb.GetDecryptedStr(_UN);
            _UFN = UserDb.GetDecryptedStr(_UFN);
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

            if(_Reason !=0)
            {
                strSql += " and dbo.ENMEMeterMeasureAlert.AlertReason="+_Reason;
            }
            if(_IsDateRange)
            {
                strSql += " and dbo.ENMEMeterMeasureAlert.AlertTime>="+(_StartDate.Date.ToOADate()-2) + " and dbo.ENMEMeterMeasureAlert.AlertTime<"+(_EndDate.Date.ToOADate()-1);
            }
            if(_StoppedStatus!=0)
            {
                if(_StoppedStatus==1)
                strSql += " and (dbo.ENMEMeterMeasureAlert.AlertStop =  1 or dbo.ENMEMeterMeasureAlert.AlertAck=1) ";
                else if (_StoppedStatus == 2)
                    strSql += " and (dbo.ENMEMeterMeasureAlert.AlertStop =  0 and dbo.ENMEMeterMeasureAlert.AlertAck=0) ";

            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AckAlert()
        {
            string strSql = "update dbo.ENMEMeterMeasureAlert set AlertAck=1, AlertAckUser="+AckUser+", AlertAckTime=GetDate()  where AlertID="+_ID + " and AlertAck = 0 and AlertStop =0 ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
                #endregion
    }
}