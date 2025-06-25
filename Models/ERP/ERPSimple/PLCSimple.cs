using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.Models.ERP.ERPSimple
{
    public class PLCSimple
    {

        #region Properties
        public int ID{ set; get; }
        public string Desc{ set; get; }
        public int Type{ set; get; }
        public int CPUType{ set; get; }
        public string IP{ set; get; }
        public int Slot{ set; get; }
        public int Rack{ set; get; }
        #endregion
    }
}