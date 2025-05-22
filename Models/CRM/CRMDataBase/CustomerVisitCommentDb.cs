using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
   public class CustomerVisitCommentDb
   {
       #region Private Data
       protected int _ID;
       protected int _Visit;
       protected int _CommentType;
       protected string _CommentDesc;
       protected int _UsrIns;
       protected DateTime _TimIns; 
       #endregion
       #region Constractors
       public CustomerVisitCommentDb()
       { 

       }
       public CustomerVisitCommentDb(DataRow objDR)
       {
           SetData(objDR);
       }
       #endregion
       #region Public Accessorice
       public int ID
       {
           set
           {
               _ID = value;
           }
           get
           {
               return _ID;
           }
       }
       public int Visit
       {
           set
           {
               _Visit = value;
           }
           get
           {
               return _Visit;
           }
       }
       public string CommentDesc
       {
           set
           {
               _CommentDesc = value;
           }
           get
           {
               return _CommentDesc;
           }
       }
       public int CommentType
       {
           set
           {
               _CommentType = value;
           }
           get
           {
               return _CommentType;
           }
       }
       public int UsrIns
       {
           set
           {
               _UsrIns = value;
           }
           get
           {
               return _UsrIns;
           }
       }
       public DateTime TimIns
       {
           set
           {
               _TimIns = value;
           }
           get
           {
               return _TimIns;
           }
       }
       public  string AddStr
       {
           get
           {               
               string Returned = "INSERT INTO CRMCustomerVisitComment" +
                           " (Visit, CommentType,CommentDesc, UsrIns,TimIns)" +
                           " VALUES     (" + _Visit + "," + _CommentType + ",'" + _CommentDesc + "'," + SysData.CurrentUser.ID + ",GetDate()) ";
               return Returned;
           }
       }
       public string EditStr
       {
           get
           {               
               string Returned = " UPDATE    CRMCustomerVisitComment" +
                           " SET   Visit = " + _Visit + "" +
                           " , CommentType =" + _CommentType + "" +
                           " , CommentDesc ='" + _CommentDesc + "'" +
                           " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                           " , TimUpd = GetDate()" +
                           " Where CustomerVisitCommentID = " + _ID + "";
               return Returned;
           }
       }
       public string DeleteStr
       {
           get
           {
               string Returned = " UPDATE    CRMCustomerVisitComment" +
                            " SET   "+
                            " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            " , Dis = GetDate()" +
                            " Where CustomerVisitCommentID = " + _ID + "";
               return Returned;
           }
       }
       public static string SearchStr
       {
           get
           {
               string Returned = "SELECT     CustomerVisitCommentID, Visit, CommentType,CommentDesc,UsrIns,TimIns" +
                                 " FROM         CRMCustomerVisitComment";
               return Returned;
           }
       }
       #endregion
       #region Private Methods
       void SetData(DataRow objDR)
       {
           _ID = int.Parse(objDR["CustomerVisitCommentID"].ToString());           
           _Visit = int.Parse(objDR["Visit"].ToString());
           _CommentType = int.Parse(objDR["CommentType"].ToString());
           _CommentDesc = objDR["CommentDesc"].ToString();
           if(objDR["UsrIns"].ToString()!="")
           _UsrIns = int.Parse(objDR["UsrIns"].ToString());
       if (objDR["TimIns"].ToString() != "")
           _TimIns = DateTime.Parse(objDR["TimIns"].ToString());
       else
           _TimIns = new DateTime(1900,1,1); 
          
       }
       #endregion
       #region Public Methods
       public void Add()
       {                  
          _ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
       }
       public void Edit()
       {                      
           SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
       }
       public void Delete()
       {
           SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
       }
       public DataTable Search()
       {
           string strSql = SearchStr + " WHERE   (1=1)";
           if (_ID != 0)
               strSql = strSql + " and CustomerVisitCommentID = " + _ID + "";
           if (_Visit != 0)
               strSql = strSql + " and Visit = " + _Visit + " ";
           if (_CommentType != 0)
               strSql = strSql + " and CommentType = " + _CommentType + " ";           
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
           
       }
       #endregion
   }
}
