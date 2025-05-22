using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    [Serializable]
    public class ReservationSimple
    {
        /*  ID,
          UnitCOde,
          UnitFullName,
          CustomerName,
          StatusStr,
          Project,
          Branch,
          SalesMen,
          UsrIns,
          TimIns,
          UsrUpd,
          TimUpd
        */



        public int ID;
        public string UnitCOde;
        public string UnitFullName;
        public string CustomerName;
        public string StatusStr;
        public int Status;
        public string Project;
        public string Branch;
        public string SalesMen;
        public double PaidValue;
        public double RemainingValue;
        public string UsrIns;
        public string TimIns;
        public string UsrUpd;
        public string TimUpd;
        public string EditStr;
        public List<InstallmentSimple> InstallmentLst = new List<InstallmentSimple>();
    }
}