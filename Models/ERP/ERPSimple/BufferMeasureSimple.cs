using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPSimple
{
    public class BufferMeasureSimple
    {


        #region Properties
        public int ID
        {
            set;
            get;
        }
        //public int BufferID
        //{
        //    set;
        //    get;
        //}
        public BufferSimple Buffer {  get; set; }
        public string WorkOrder
        {
            set;
            get;
        }
        public DateTime Date
        {
            set;
            get;
        }
        public string DateStr
        {
            get => Date.ToString("yyyy-MM-dd");
        }
        public DateTime Time
        {
            set;
            get;
        }
        public string TimeStr { get => Time.ToString("HH:mm"); }
        public double Value
        {
            set;
            get;
        }
        public double FirstValue
        {
            set;
            get;
        }
        public double MinValue
        {
            set;
            get;
        }
        public double MaxValue
        {
            set;
            get;
        }
        public DateTime MinTime
        {
            set;
            get;
        }
        public string MinTimeStr { get => MinTime.ToString("HH:mm"); }
        public int Unit
        {
            set;
            get;
        }
        #endregion
    }
}