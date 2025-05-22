using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    [Serializable]
    public class UnitSimple
    {
         /* ID,
          Code,
         Survey,
          Order,
          TowerID,
          Tower,
          ProjectID,
          Project,
          FloorID,
          Floor,
          StatusStr,
          Customer,
          UnitPricePerMeter,
          TotalPrice*/



        public int ID;
        public string Code;
        public double Survey;
        public int Order;
        public int TowerID;
        public string Tower;
        public int ProjectID;
        public string Project;
        public int FloorID;
        public string Floor;
        public string StatusStr;
        public string Customer;
        public int UnitPricePerMeter;
        public int TotalPrice;
         
    }
}