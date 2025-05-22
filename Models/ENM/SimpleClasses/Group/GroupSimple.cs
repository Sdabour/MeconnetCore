using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    [Serializable]
    public class GroupSimple
    {
        //GroupID, GroupCode, GroupNameA, GroupNameE, GroupDesc
        #region Properties
        public int ID { get; set; } 
        public string Code { get; set; }
        public string NameA { get; set; }
        public string NameE { get; set; }
        public string Desc { get; set; }
        public string LastReadTime { get; set; }
        public List<MeterSimple> MeterLst { get; set; } = new List<MeterSimple>();
        #endregion
    }
}