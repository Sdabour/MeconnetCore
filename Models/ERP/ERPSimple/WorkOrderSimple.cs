using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class WorkOrderSimple
    {
        public string WorkOrder;
        public string Date;
        public string StartTime;
        public string EndTime;
        public List<RouteSimple> WorkCenterLst=new List<RouteSimple>();
        public List<RouteSimple> MachineLst = new List<RouteSimple>();
        public List<BOMSimple> BOM = new List<BOMSimple>();

    }
}