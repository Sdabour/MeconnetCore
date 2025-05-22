using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class UserSimple
    {
        //ID,Name,Password,FullName,EmpID,EmpName,Group,GroupName,IsSystemAdmin,IsStopped,EmpCode,Job,WorkGroup,WorkGroupName,Sector

        #region Properties
        public int ID;
        public string Name;
        public string Password;
        public string FullName;
        public int EmpID;
        public string EmpName;
        public string EmpCode;
        public string Job;
        public int WorkGroup;
        public string WorkGroupName;
        public string Sector;
        public int Group;
        public string GroupName;
        public bool IsSystemAdmin;
        public bool IsStopped;
        public int Branch;
        public List<FunctionSimple> FunctionLst
        {
            set;
            get;

        }
        #endregion
    }
}