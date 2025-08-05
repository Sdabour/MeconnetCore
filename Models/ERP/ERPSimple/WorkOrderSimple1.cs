using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ODDOWorkOrder
    {
       public string name { set; get; }
        public string state { set; get; }
        public string product_id { set; get; }
        public string qty_produced { set; get; }
        public string production_id { set; get; }
    }
    public class WorkOrderSimple1
    {
        public string WorkOrder{ set; get; }
        public string Date{ set; get; }
        public string StartTime{ set; get; }
        public string EndTime{ set; get; }
        public List<RouteSimple> WorkCenterLst { set; get; } = new List<RouteSimple>();
        public List<RouteSimple> MachineLst { set; get; } = new List<RouteSimple>();
        public List<BOMSimple> BOM { set; get; } = new List<BOMSimple>();

    }
}