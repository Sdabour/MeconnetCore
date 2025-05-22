using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.UMS.UMSBusiness
{
 public class UserFunctionInstantCol:CollectionBase
    {
     DataTable _UserFUnctionInstantTable;
        Hashtable _FunctionHash = new Hashtable();
     public UserFunctionInstantCol()
     {
         UserFunctionInstantDb objUserFunctionInstantDb = new UserFunctionInstantDb();
         UserFunctionInstantBiz objUserFunctionInstantBiz;
         foreach (DataRow DR in objUserFunctionInstantDb.Search().Rows)
         {
             objUserFunctionInstantBiz = new UserFunctionInstantBiz(DR);
             this.Add(objUserFunctionInstantBiz);
         }
 
     }
     public UserFunctionInstantCol(bool blIsEmpty)
     {
 
     }
     public UserFunctionInstantCol(int intUserID)
     {
         UserFunctionInstantDb objUserFunctionInstantDb = new UserFunctionInstantDb();
         objUserFunctionInstantDb.UserID = intUserID;
         UserFunctionInstantBiz objUserFunctionInstantBiz;
         foreach (DataRow DR in objUserFunctionInstantDb.Search().Rows)
         {
             objUserFunctionInstantBiz = new UserFunctionInstantBiz(DR);
             this.Add(objUserFunctionInstantBiz);
         }

     }
     public bool Contains(string strName)
     {
         bool blReturned = false;
         foreach (UserFunctionInstantBiz objUserFunctionBiz in this)
         {
             if (objUserFunctionBiz.Name == strName)
             {
                 blReturned = true;
                 break;
             }
         }
         return blReturned;

     }
     public int  GetIndex(int intID)
     {
         if (intID == 0)
             return -1;
            if (_FunctionHash[intID.ToString()] == null)
                return -1;
            int intIndex = 0;
            intIndex = (int)_FunctionHash[intID.ToString()];
         //for (int intIndex = 0; intIndex < Count;intIndex++ )
         //{
         //    if (this[intIndex].ID == intID)
         //    {
         //        return intIndex;
         //    }
         //}
         return intIndex;

     }
     public virtual UserFunctionInstantBiz this[string strIndex]
     {
         get
         {
             UserFunctionInstantBiz Returned = new UserFunctionInstantBiz();
             foreach (UserFunctionInstantBiz objUserFunctionInstantBiz in this)
             {
                 if (objUserFunctionInstantBiz.ID.ToString() == strIndex)
                 {
                     Returned = objUserFunctionInstantBiz.Copy();
                     break;
                 }
 
             }
             return Returned;
 
         }
     }
     public virtual UserFunctionInstantBiz this[int intIndex]
     {
         get
         {
             return (UserFunctionInstantBiz)this.List[intIndex];
         }
     }
     public virtual void Add(UserFunctionInstantCol objUserFunctionInstantCol)
     {
         foreach(UserFunctionInstantBiz objUserFunctionInstantBiz in objUserFunctionInstantCol)
         {

                //this.List.Add(objUserFunctionInstantBiz);
                Add(objUserFunctionInstantBiz);
         }
     }
     public virtual void Add(UserFunctionInstantBiz objUserFunctionInstantBiz)
     {
            if (_FunctionHash[objUserFunctionInstantBiz.ID.ToString()] == null)
                _FunctionHash.Add(objUserFunctionInstantBiz.ID.ToString(), Count);

         this.List.Add(objUserFunctionInstantBiz);
     }
     public UserFunctionInstantCol GetFunctionCol(int intSystemID)
     {
         UserFunctionInstantCol Returned = new UserFunctionInstantCol(true);
         
         foreach (UserFunctionInstantBiz objBiz in this)
         {
           
             if (objBiz.SysID == intSystemID)
                 Returned.Add(objBiz);
             
         }
         return Returned;
     }
     public UserFunctionInstantCol RemoveFunctionByID(int intFunctionID)
     {
         UserFunctionInstantCol Returned = new UserFunctionInstantCol(true);
         foreach (UserFunctionInstantBiz objBiz in this)
         {
             if (objBiz.ID != intFunctionID)
                 Returned.Add(objBiz);

         }
         return Returned;
     }
     public UserFunctionInstantCol Copy()
     {
         UserFunctionInstantCol Returned = new UserFunctionInstantCol(true);
         foreach (UserFunctionInstantBiz objTemp in this)
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
         dcTemp = new DataColumn("IsPermanent",Type.GetType("System.Boolean"));
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("IsAdmin",Type.GetType("System.Boolean"));
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("StartDate");
         dtTemp.Columns.Add(dcTemp);
         dcTemp = new DataColumn("EndDate");
         dtTemp.Columns.Add(dcTemp);

         DataRow drTemp;
         foreach (UserFunctionInstantBiz objUserFunctionInstantBiz in this)
         {
             drTemp = dtTemp.NewRow();
             drTemp["FunctionID"] = objUserFunctionInstantBiz.ID;
             drTemp["IsPermanent"] = objUserFunctionInstantBiz.IsPermanent;
             drTemp["IsAdmin"] = objUserFunctionInstantBiz.IsAdmin;
             drTemp["StartDate"] = objUserFunctionInstantBiz.StartDate;
             drTemp["EndDate"] = objUserFunctionInstantBiz.EndDate;
             dtTemp.Rows.Add(drTemp);

         }
         return dtTemp;
     }
    }
}
