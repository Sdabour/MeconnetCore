using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ProductSimple
    {

        #region Properties
        public int ID{ set; get; }
        public string Code{ set; get; }
        public string NameA{ set; get; }
        public string NameE{ set; get; }
        public int MeasurementUnit{ set; get; }
        public int InternalReference{ set; get; }
        public bool IsRawMaterial{ set; get; }
        public bool IsComposed{ set; get; }
        #endregion
    }
}