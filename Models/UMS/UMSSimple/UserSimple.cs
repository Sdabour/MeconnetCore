using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class GetUserClass
    {
        public int intGroupID { set; get; }
        public string strUserName { set; get; }
        public string strFullName { set; get; }
        public int intEmpID { set; get; }
    }
    public class UserSimple
    {
        //ID,Name,Password,FullName,EmpID,EmpName,Group,GroupName,IsSystemAdmin,IsStopped,EmpCode,Job,WorkGroup,WorkGroupName,Sector

        #region Properties
        //public int ID;
        //public string Name;
       
        //public string FullName;
        //public int EmpID;
        //public string EmpName;
        //public string EmpCode;
        //public string Job;
        //public int WorkGroup;
        //public string WorkGroupName;
        //public string Sector;
        //public int Group;
        //public string GroupName;
        //public bool IsSystemAdmin;
        //public bool IsStopped;
        //public int Branch;

        public int ID
        {
            set; get;
        }
        public string Name
        {
            set; get;
        }
        public string Password
        {
            set; get;
        }
        public string FullName { set; get; }
        public int EmployeeID
        { set; get; }
        public string EmployeeCode
        { set; get; }
        public string EmployeeName
        { set; get; }
        public string Job
        { set; get; }
        public string Sector
        { set; get; }
        public int WorkGroup
        { set; get; }
        public string WorkGroupName
        { set; get; }
        
       
        public int Group
        {
            set;
            get;

        }
        public string GroupName
        {
            set;
            get;

        }
        public bool IsSystemAdmin
        {
            set;
            get;

        }
        public bool IsStopped
        {
            set;
            get;

        }
        public int Branch
        {
            set;
            get;

        }

        public List<FunctionSimple> FunctionLst
        {
            set;
            get;

        } = new List<FunctionSimple>();
        public List<FunctionInstantSimple> LstFunction
        {
            set;
            get;

        } = new List<FunctionInstantSimple>();
        public bool ChangePass { set; get; }
        public string OldPass { set; get; } = "";    
        public static string CurrentUserIDKey
        { get => "CurrentUser"; }
        public static UserSimple CurrentUser
        {
            set => AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.SetString(CurrentUserIDKey, System.Text.Json.JsonSerializer.Serialize(value));
            get
            {
                UserSimple Returned = new UserSimple();
                if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey) != null)
                {
                    string strTemp = AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey);
                    Returned = Newtonsoft.Json.JsonConvert.DeserializeObject<UserSimple>(strTemp);
                }
                return Returned;
            }
            #endregion
        }
        public bool CheckFunction(int intFunctionID)
        {
            bool Returned = false;
            foreach (FunctionSimple objBiz in FunctionLst)
            {
                if (objBiz.ID == intFunctionID)
                {
                    Returned = true;
                    break;
                }
            }
            return Returned;


        }
        public Hashtable GetUserFunctionHash()
        {
            Hashtable Returned = new Hashtable();
            foreach(FunctionSimple objSimple in FunctionLst)
            {
                if (Returned[objSimple.ID.ToString()]==null)
                {
                    Returned.Add(objSimple.ID.ToString(), objSimple.ID.ToString());
                }
            }
            return Returned;
        }
    }
    
        
    
}