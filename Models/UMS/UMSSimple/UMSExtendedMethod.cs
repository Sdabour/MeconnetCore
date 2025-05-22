using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.UMS.UMSBusiness;

namespace SharpVision.UMS.UMSBusiness
{
    public static class UMSExtendedMethod
    {
        public static FunctionSimple GetFunctionSimple(this FunctionBiz objBiz)
        {
            FunctionSimple Returned = new FunctionSimple() { Desc=objBiz.Description, FamilyID=objBiz.FamilyID,FamilyName="",ID=objBiz.ID,Name=objBiz.Name,Parent=objBiz.ParentID,ParentID=objBiz.ParentID,ParentName=objBiz.ParentBiz.Name,Stoped=objBiz.IsStoped,SysID=objBiz.SysID};
            return Returned;
        }
        public static FunctionInstantSimple GetFunctionInstant(this UserFunctionInstantBiz objBiz)
        {
            FunctionInstantSimple Returned = new FunctionInstantSimple() {EndDate=objBiz.EndDate,FunctionSimple=new FunctionSimple() { Desc=objBiz.Description,FamilyID=objBiz.FamilyID,FamilyName="",ID=objBiz.ID,Name=objBiz.Name,Parent=objBiz.ParentID,ParentID=objBiz.ParentID,ParentName="",Stoped=false,SysID=objBiz.SysID} ,IsAdmin=objBiz.IsAdmin,IsPermanent=objBiz.IsPermanent,StartDate=objBiz.StartDate};
            return Returned;
        }
        public static GroupFunctionInstantBiz GetGroupFunctionInstant(this FunctionInstantSimple objBiz)
        {
            GroupFunctionInstantBiz Returned = new GroupFunctionInstantBiz() { EndDate = objBiz.EndDate, ID=objBiz.FunctionSimple.ID,IsAdmin =objBiz.IsAdmin,IsPermanent=objBiz.IsPermanent,StartDate = objBiz.StartDate};
            return Returned;
        }
        public static UserFunctionInstantBiz GetUserFunctionInstant(this FunctionInstantSimple objBiz)
        {
            UserFunctionInstantBiz Returned = new UserFunctionInstantBiz() { EndDate = objBiz.EndDate, ID = objBiz.FunctionSimple.ID, IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent, StartDate = objBiz.StartDate,SysID=objBiz.FunctionSimple.SysID };
            return Returned;
        }
        public static FunctionInstantSimple GetFunctionInstant(this GroupFunctionInstantBiz objBiz)
        {
            FunctionInstantSimple Returned = new FunctionInstantSimple() { EndDate = objBiz.EndDate, FunctionSimple =new FunctionSimple() { ID = objBiz.ID, Name=objBiz.Name,SysID=objBiz.SysID},IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent, StartDate = objBiz.StartDate };
            return Returned;
        }
        public static EmployeeSimple GetSimple(this EmployeeBiz objBiz)
        {
          EmployeeSimple Returned =  new EmployeeSimple() { ID = objBiz.ID, Code = objBiz.Code, Name = objBiz.Name, Department = objBiz.DepartmentStr, BranchName = objBiz.BranchName, FamousName = objBiz.FamousName, User = objBiz.UserID, UserName = "" };
            return Returned;
        }
    }
}