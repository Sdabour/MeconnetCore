using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class FunctionSimple
    {
        //ID,Name,Desc,System,ParentID,FamilyID,ParentName,FamilyName,Stoped
        #region Properties
        public int ID { set; get; }
        public string Name{ set; get; }
        public string Desc{ set; get; }
        public int SysID{ set; get; }
        public int ParentID{ set; get; }
        public int Parent{ set; get; }
        public int FamilyID{ set; get; }
        public string ParentName{ set; get; }
        public string FamilyName{ set; get; }
        public bool Stoped{ set; get; }
        #endregion
       
    }
}