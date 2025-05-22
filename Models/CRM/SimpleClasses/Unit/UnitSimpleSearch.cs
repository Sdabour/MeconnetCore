using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    [Serializable]
    public class UnitSimpleSearch
    {
        public bool Selected { set; get; }
        public string UnitFullName { set; get; }
        public  string UnitCode { set; get; }
        public string UnitOrder { set; get; } = "";
        public int AreaStart { set; get; }
        public int AreaEnd { set; get; }
        public int PeripheralType { set; get; }
        public int PeripheralAreaStart { set; get; }
        public int PeripheralAreaEnd { set; get; }
        public int UnitType { set; get; }
        public int UnitUsageType { set; get; }
        public int PriceStart { set; get; }
        public int PriceEnd { set; get; }
        public bool PriceDateRange { get=>PriceDateStart!= null &&PriceDateEnd!=null; }
        public DateTime PriceDateStart { set; get; }
        public DateTime PriceDateEnd { set; get; }
        public string UnitStatus { set; get; }
        public int UnitStatusInt { get { int Returned = 0;
                if (UnitStatus == null)
                    UnitStatus = "";
                int.TryParse(UnitStatus, out Returned);
                return Returned;
            } }
        public string UnitDeliveryStatus { set; get; }
        public int UnitDeliveryStatusInt
        {
            get
            {
                int Returned = 0;
                if (UnitDeliveryStatus == null)
                    UnitDeliveryStatus = "";
                int.TryParse(UnitDeliveryStatus, out Returned);
                return Returned;
            }
        }
        public string TowerDeliveryStatus { set; get; }
        public int TowerDeliveryStatusInt
        {
            get
            {
                int Returned = 0;
                if (TowerDeliveryStatus == null)
                    TowerDeliveryStatus = "";
                int.TryParse(TowerDeliveryStatus, out Returned);
                return Returned;
            }
        }
        public string ProjectStr { set; get; }
        public List<int> ProjectLst { set; get; } = new List<int>();
        public string TowerStr { set; get; }
        public List<int> TowerLst { set; get; } = new List<int>();
        public string FloorStr { set; get; }
        public List<int> FloorLst { set; get; } = new List<int>();

    }
}