using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{

    public class MOSimple
    {

        #region Properties
        public int ID
        {
            set;
            get;
        }
        public string Ref
        {
            set;
            get;
        }
        public DateTime Date
        {
            set;
            get;
        }
        public DateTime StartTime
        {
            set;
            get;
        }
        public string StartTimeStr
        {
            get { return StartTime.ToString("MM-dd HH:mm"); }
           
        }
        public string Desc
        {
            set;
            get;
        }
        public double Quantity
        {
            set;
            get;
        }
        public int Responsible
        {
            set;
            get;
        }
        public int Status
        {
            set;
            get;
        }
        public string StatusStr { get => ((MOStatus)Status).ToString(); }
        public DateTime StatusTime
        {
            set;
            get;
        }
        public int UserStarted { set; get; }
        public int BOM { set; get; }
        public int Product { set; get; }

       
        public string UserStartedName
        {
            set;
            get;
        }
        public string BOMName
        {
            set;
            get;
        }
        public string ProductName
        {
            set;
            get;
        }
        public string ResponsibleName
        {
            set;
            get;
        }
        
        #endregion
    }
}
