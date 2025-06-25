using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MeasurementUnitSimple
    {

        #region Properties
        public int ID{ set; get; }
        public int Main{ set; get; }
        public string Code{ set; get; }
        public string NameA{ set; get; }
        public string NameE{ set; get; }
        public double Factor{ set; get; }
        public bool IsBasic{ set; get; }
        #endregion
    }
}