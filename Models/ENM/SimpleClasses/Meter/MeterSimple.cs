using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeterSimple
    {
        //EMeterID, MeterGroupID, MeterGroupCode, MeterGroupNameA, MeterGroupNameE, MeterGroupDesc, EMeterTypeID, EMeterTypeCode, EMeterTypeNameA, EMeterTypeNameE, EMeterDesc
        #region Properties
        public int ID{ get; set; } 
        public string ProductName{ get; set; } 
        public int GroupID{ get; set; } 
        public string GroupCode{ get; set; } 
        public string GroupNameA{ get; set; } 
        public string GroupNameE{ get; set; } 
        public string GroupDesc{ get; set; } 
        public int TypeID{ get; set; } 
        public string TypeCode{ get; set; } 
        public string TypeNameA{ get; set; } 
        public string TypeNameE{ get; set; } 
        public string Desc{ get; set; } 
        public List<MeasurementSimple> MeasureLst { get; set; } = new List<MeasurementSimple>();
        #endregion
    }
}