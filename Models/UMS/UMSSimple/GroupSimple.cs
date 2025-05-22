using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class GroupSimple
    {
        //ID,Name,ParentID,ParentName,Type,TypeName
        #region Properties
        public int ID;
        public string Name;
        public int ParentID;
        public string ParentName;
        public int Type;
        public string TypeName;
        public string EditStr
        {
            get
            {
                string Returned = "GroupAddEditIndex?GroupID="+ID;
                return Returned;
            }
        }
        #endregion
    }
}