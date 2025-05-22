using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeterMeasureSimple
    {

        #region Properties
        public int ID{ get; set; } 
        public int MeterID{ get; set; } 
        public string ProductName{ get; set; } 
        public string MeterDesc{ get; set; } 
        public DateTime Date{ get; set; } 
        public string DateStr { get => Date.ToString("yyyy-MM-dd"); }
        public DateTime Time{ get; set; } 
        public string TimeStr { get => Time.ToString("HH:mm:ss"); }
        public string TimeLabel{ get; set; } 
        public int Type{ get; set; } 
        public string TypeName{ get; set; } 
        public bool IsAccumulated{ get; set; } 
        public double Value{ get; set; } 
        public double FirstValue{ get; set; } 
        public double MinValue{ get; set; } 
        public double MaxValue{ get; set; } 
        public DateTime MinTime{ get; set; } 
        public string Unit{ get; set; } 
        #endregion
    }
    
}