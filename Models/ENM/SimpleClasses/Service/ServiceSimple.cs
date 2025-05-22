using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    [Serializable]
    public class ServiceSimple
    {
        // EServiceID, EServiceDesc, EServiceIterationPeriod, EServiceIterationValue

        #region Properties
        public int ID{ get; set; } 
        public string Desc{ get; set; } 
        public int IterationPeriod{ get; set; } 
        public int IterationValue{ get; set; } 
        public List<GroupSimple> GroupLst { get; set; } = new List<GroupSimple>();
        #endregion

    }
}