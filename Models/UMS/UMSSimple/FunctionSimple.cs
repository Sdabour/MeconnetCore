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
        public int ID;
        public string Name;
        public string Desc;
        public int SysID;
        public int ParentID;
        public int Parent;
        public int FamilyID;
        public string ParentName;
        public string FamilyName;
        public bool Stoped;
        #endregion
       
    }
}