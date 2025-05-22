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
        public FunctionSimple FunctionSimple = new FunctionSimple();
        public bool IsPermanent;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool IsAdmin;
        #endregion

    }
}