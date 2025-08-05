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
        public string DateStr { get => Date.ToString("yyyy-MM-dd"); }
        public DateTime StartTime
        {
            set;
            get;
        }
        public string StartTimeStr
        {
            get { return StartTime.ToString("HH:mm"); }
           
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
        public string StatusTimeStr { get => StatusTime.ToString("HH:mm"); }
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
        public List<WorkOrderSimple> WorkorderLst { get; set; } = new List<WorkOrderSimple>();
        public List<MOComponentSimple> ComponentLst { set; get; } = new List<MOComponentSimple>();

        public List<MOComponentSimple> ByproductLst { set; get; } = new List<MOComponentSimple>();
        #endregion
    }
}
