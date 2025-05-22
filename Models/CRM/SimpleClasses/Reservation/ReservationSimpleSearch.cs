using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationSimpleSearch
    {
        public int ID { set; get; }
        public string UnitCOde { set; get; }
        public string UnitFullName { set; get; }
        public string CustomerName { set; get; }
       public string Note { set; get; }
        public DateTime ReservationDateStart { set; get; }
        public DateTime ReservationDateEnd { set; get; }
        public DateTime ContractingDateStart { set; get; }
        public DateTime ContractingDateEnd { set; get; }
        public DateTime StatusDateStart { set; get; }
        public DateTime StatusDateEnd { set; get; }
        

    }
}