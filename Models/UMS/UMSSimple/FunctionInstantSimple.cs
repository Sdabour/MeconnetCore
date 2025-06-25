using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class FunctionInstantSimple
    {

        #region Properties
        //public int ID;
        //public string Name;
        //public int System;
        //public int ParentID;
        //public string ParentName;
        public FunctionSimple FunctionSimple { set; get; } = new FunctionSimple();
        public bool IsPermanent{ set; get; }
        public DateTime StartDate{ set; get; }
        public DateTime EndDate{ set; get; }
        public bool IsAdmin{ set; get; }
        #endregion

    }
}