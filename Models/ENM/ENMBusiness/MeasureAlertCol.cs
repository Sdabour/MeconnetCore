using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
using AlgorithmatENM.ENM.ENMDb;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasureAlertCol:CollectionBase
    {

        #region Constructor
        public MeasureAlertCol()
        {

        }
        public MeasureAlertCol(bool blIsDateRange,DateTime dtStartDate,DateTime dtEndDate,int intReason,bool blLastStatus,int intStoppedStatus)
        {
            MeasureAlertDb objDb = new MeasureAlertDb() { IsDateRange = blIsDateRange, Reason = intReason, OnlyLastStatus = blLastStatus, StoppedStatus = intStoppedStatus,StartDate=dtStartDate,EndDate=dtEndDate };
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "AlertStopped asc,AlertID desc");
            foreach(DataRow objDr in arrDr)
            {
                Add(new MeasureAlertBiz(objDr));
            }
        }
        public MeasureAlertCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MeasureAlertBiz objBiz = new MeasureAlertBiz();
           

            MeasureAlertDb objDb = new MeasureAlertDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeasureAlertBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MeasureAlertBiz this[int intIndex]
        {
            get
            {
                return (MeasureAlertBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MeasureAlertBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MeasureAlertCol GetCol(string strTemp)
        {
            MeasureAlertCol Returned = new MeasureAlertCol(true);
            foreach (MeasureAlertBiz objBiz in this)
            {
               // if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AlertID"), new DataColumn("AlertMeter"), new DataColumn("AlertMeasureType"), new DataColumn("AlertTime", System.Type.GetType("System.DateTime")), new DataColumn("AlertMinValue"), new DataColumn("AlertMaxValue"), new DataColumn("AlertValue"), new DataColumn("AlertReason"), new DataColumn("AlertStop", System.Type.GetType("System.Boolean")), new DataColumn("AlertStopTime", System.Type.GetType("System.DateTime")), new DataColumn("AlertAck", System.Type.GetType("System.Boolean")), new DataColumn("AlertAckUser"), new DataColumn("AlertAckTime", System.Type.GetType("System.DateTime")), new DataColumn("AlertSnoozeTime", System.Type.GetType("System.DateTime")), new DataColumn("EMeasureTypeNameA"), new DataColumn("EMeasureTypeNameE"), new DataColumn("EMeasureTypeUnit"), new DataColumn("EMeasureTypeAccumulated", System.Type.GetType("System.Boolean")), new DataColumn("EMeterDesc"), new DataColumn("UFN"), new DataColumn("UN") });
            DataRow objDr;
            foreach (MeasureAlertBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AlertID"] = objBiz.ID;
                objDr["AlertMeter"] = objBiz.Meter;
                objDr["AlertMeasureType"] = objBiz.MeasureType;
                objDr["AlertTime"] = objBiz.Time;
                objDr["AlertMinValue"] = objBiz.MinValue;
                objDr["AlertMaxValue"] = objBiz.MaxValue;
                objDr["AlertValue"] = objBiz.Value;
                objDr["AlertReason"] = objBiz.Reason;
                objDr["AlertStop"] = objBiz.Stop;
                objDr["AlertStopTime"] = objBiz.StopTime;
                objDr["AlertAck"] = objBiz.Ack;
                objDr["AlertAckUser"] = objBiz.AckUser;
                objDr["AlertAckTime"] = objBiz.AckTime;
                objDr["AlertSnoozeTime"] = objBiz.SnoozeTime;
                objDr["EMeasureTypeNameA"] = objBiz.EMeasureTypeNameA;
                objDr["EMeasureTypeNameE"] = objBiz.EMeasureTypeNameE;
                objDr["EMeasureTypeUnit"] = objBiz.EMeasureTypeUnit;
                objDr["EMeasureTypeAccumulated"] = objBiz.EMeasureTypeAccumulated;
                objDr["EMeterDesc"] = objBiz.EMeterDesc;
                objDr["UFN"] = objBiz.UFN;
                objDr["UN"] = objBiz.UN;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}