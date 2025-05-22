using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.UMS.UMSBusiness
{
 public    class GroupFunctionInstantCol :CollectionBase
    {
        DataTable _UserFUnctionInstantTable;
     public GroupFunctionInstantCol()
     {
         GroupFunctionInstantDb objGroupFunctionInstantDb = new GroupFunctionInstantDb();
         GroupFunctionInstantBiz objGroupFunctionInstantBiz;
         foreach (DataRow DR in objGroupFunctionInstantDb.Search().Rows)
         {
             objGroupFunctionInstantBiz = new GroupFunctionInstantBiz(DR);
             this.Add(objGroupFunctionInstantBiz);
         }
 
     }
     public GroupFunctionInstantCol(bool blIsEmpty)
     {
 
     }
     public GroupFunctionInstantCol(int intUserID)
     {
         GroupFunctionInstantDb objGroupFunctionInstantDb = new GroupFunctionInstantDb();
         objGroupFunctionInstantDb.UserID = intUserID;
         GroupFunctionInstantBiz objGroupFunctionInstantBiz;
         foreach (DataRow DR in objGroupFunctionInstantDb.Search().Rows)
         {
             objGroupFunctionInstantBiz = new GroupFunctionInstantBiz(DR);
             this.Add(objGroupFunctionInstantBiz);
         }

     }
     public bool Contains(string strName)
     {
         bool blReturned = false;
         foreach (GroupFunctionInstantBiz objGroupFunctionBiz in this)
         {
             if (objGroupFunctionBiz.Name == strName)
             {
                 blReturned = true;
                 break;
             }
         }
         return blReturned;

     }
     public virtual GroupFunctionInstantBiz this[string strIndex]
     {
         get
         {
             GroupFunctionInstantBiz Returned = new GroupFunctionInstantBiz();
             foreach (GroupFunctionInstantBiz objGroupFunctionInstantBiz in this)
             {
                 if (objGroupFunctionInstantBiz.Name == strIndex)
                 {
                     Returned = objGroupFunctionInstantBiz.Copy();
                     break;
                 }
 
             }
             return Returned;
 
         }
     }
     public virtual GroupFunctionInstantBiz this[int intIndex]
     {
         get
         {
             return (GroupFunctionInstantBiz)this.List[intIndex];
         }
     }
     public virtual void Add(GroupFunctionInstantCol objGroupFunctionInstantCol)
     {
         foreach(GroupFunctionInstantBiz objGroupFunctionInstantBiz in objGroupFunctionInstantCol)
         {
             this.List.Add(objGroupFunctionInstantBiz.Copy());
         }
     }
     public virtual void Add(GroupFunctionInstantBiz objGroupFunctionInstantBiz)
     {
         this.List.Add(objGroupFunctionInstantBiz);
     }
     public virtual void Add(FunctionBiz objFunctionBiz)
     {
         this.List.Add(objFunctionBiz);

     }
     public GroupFunctionInstantCol GetFunctionCol(int intSysID)
     {
         GroupFunctionInstantCol Returned = new GroupFunctionInstantCol(true);
         foreach (GroupFunctionInstantBiz objBiz in this)
         {
             if (objBiz.SysID == intSysID)
                 Returned.Add(objBiz);
         }
         return Returned;
     }
     public GroupFunctionInstantCol RemoveFunctionByID(int intFunctionID)
     {
         GroupFunctionInstantCol Returned = new GroupFunctionInstantCol(true);
         foreach (GroupFunctionInstantBiz objBiz in this)
         {
             if (objBiz.ID != intFunctionID)
                 Returned.Add(objBiz);
         }
         return Returned;
     }

     public GroupFunctionInstantCol Copy()
     {
         GroupFunctionInstantCol Returned = new GroupFunctionInstantCol(true);
         foreach (GroupFunctionInstantBiz objTemp in this)
         {

             Returned.Add(objTemp.Copy());
 
         }
         return Returned;
     }
     public DataTable GetTable()
     {
         DataTable dtTemp = new DataTable();
         DataColumn dcTemp = new DataColumn("FunctionID");
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("IsPermanent");
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("IsAdmin");
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("StartDate");
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("EndDate");
         dtTemp.Columns.Add(dcTemp);

         DataRow drTemp;
         foreach (GroupFunctionInstantBiz objGroupFunctionInstantBiz in this)
         {
             drTemp = dtTemp.NewRow();
             drTemp["FunctionID"] = objGroupFunctionInstantBiz.ID;
             drTemp["IsPermanent"] = objGroupFunctionInstantBiz.IsPermanent;
             drTemp["IsAdmin"] = objGroupFunctionInstantBiz.IsAdmin;
             drTemp["StartDate"] = objGroupFunctionInstantBiz.StartDate;
             drTemp["EndDate"] = objGroupFunctionInstantBiz.EndDate;
             dtTemp.Rows.Add(drTemp);

         }
         return dtTemp;
     }
    }
}
