using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasureAlertSimple
    {

        #region Properties
        public int ID { get; set; }
        public int Meter{ get; set; } 
        public int MeasureType{ get; set; } 
        public DateTime Time{ get; set; } 
        public string TimeStr
        {
            get
            {
                string Returned = Time.Date == DateTime.Now.Date ?Time.ToString("HH:mm:ss"):Time.ToString("MM-dd HH:mm");
                return Returned;
            }
        }
        public double MinValue{ get; set; } 
        public double MaxValue{ get; set; } 
        public double Value{ get; set; } 
        public int Reason{ get; set; } 
        public string ReasonStr { get => Reason == 1 ? "More Than Max" : (Reason == 2 ? "Less Than Min" : "Off"); }
        public bool Stop{ get; set; } 
        public DateTime StopTime{ get; set; } 
        public string StopTimeStr { get {
                string Returned = "";
                DateTime dtStopTime = (Ack ? AckTime : StopTime);
                if (Stopped)
                    Returned = dtStopTime.Date == DateTime.Now.Date ? dtStopTime.ToString("HH:mm") : dtStopTime.ToString("MM-dd  HH:mm");
                return Returned;
               } }
        public bool Ack{ get; set; } 
        public int AckUser{ get; set; } 
        public bool Stopped { get => Stop || Ack; }
        public DateTime AckTime{ get; set; } 
        public DateTime SnoozeTime{ get; set; } 
        public string EMeasureTypeNameA{ get; set; } 
        public string EMeasureTypeNameE{ get; set; } 
        public string EMeasureTypeUnit{ get; set; } 
        public bool EMeasureTypeAccumulated{ get; set; } 
        public string EMeterDesc{ get; set; } 
        public string UFN{ get; set; } 
        public string UN{ get; set; } 
        #endregion
    }
}