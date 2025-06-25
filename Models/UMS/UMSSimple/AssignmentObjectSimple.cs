using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class AssignmentObjectSimple
    {

        #region Properties
        public int ID{ set; get; }
        public string Desc{ set; get; }
        public string Code{ set; get; }
        public string TableName{ set; get; }
        public string TableValueName{ set; get; }
        public string TableDisplayNameA{ set; get; }
        public string TableDisplayNameE{ set; get; }
        public string ConditionStr{ set; get; }
        #endregion
    }
}