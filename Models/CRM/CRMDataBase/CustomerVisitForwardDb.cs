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
   public class CustomerVisitForwardDb
   {
       #region Private Data
       protected int _ID;
       protected int _Visit;
       protected DateTime _ForwardDate;
       protected string _ForwardDesc;
       protected int _ForwardApplicant;
       protected int _ForwardStatus;
       protected int _UsrIns;
       protected DateTime _TimIns;
       protected int _UsrUpd;
       protected DateTime _TimUpd;

       protected int _SalesManApplicantSearch;
       #endregion
       #region Constractors
       public CustomerVisitForwardDb()
       { 

       }
       public CustomerVisitForwardDb(DataRow objDR)
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
       public DateTime ForwardDate
       {
           set
           {
               _ForwardDate = value;
           }
           get
           {
               return _ForwardDate;
           }
       }
       public string ForwardDesc
       {
           set
           {
               _ForwardDesc = value;
           }
           get
           {
               return _ForwardDesc;
           }
       }
       public int ForwardApplicant
       {
           set
           {
               _ForwardApplicant = value;
           }
           get
           {
               return _ForwardApplicant;
           }
       }
       public int SalesManApplicantSearch
       {
           set
           {
               _SalesManApplicantSearch = value;
           }
           get
           {
               return _SalesManApplicantSearch;
           }
       }
       public int ForwardStatus
       {
           set
           {
               _ForwardStatus = value;
           }
           get
           {
               return _ForwardStatus;
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
       public int UsrUpd
       {
           set
           {
               _UsrUpd = value;
           }
           get
           {
               return _UsrUpd;
           }
       }
       public DateTime TimUpd
       {
           set
           {
               _TimUpd = value;
           }
           get
           {
               return _TimUpd;
           }
       }
       public  string AddStr
       {
           get
           {
               double dlDate = _ForwardDate.ToOADate() - 2;
               string Returned = "INSERT INTO CRMCustomerVisitForward" +
                           " (Visit, ForwardDate,ForwardDesc,ForwardApplicant,ForwardStatus, UsrIns,TimIns)" +
                           " VALUES     (" + _Visit + "," + dlDate + ",'" + _ForwardDesc + "'," + _ForwardApplicant + "," + _ForwardStatus + "," + SysData.CurrentUser.ID + ",GetDate()) ";
               return Returned;
           }
       }
       public string EditStr
       {
           get
           {
               double dlDate = _ForwardDate.ToOADate() - 2;
               string Returned = " UPDATE    CRMCustomerVisitForward" +
                           " SET   Visit = " + _Visit + "" +
                           " , ForwardDate =" + dlDate + "" +
                           " , ForwardApplicant =" + _ForwardApplicant + "" +
                           " , ForwardDesc ='" + _ForwardDesc + "'" +
                           " , ForwardStatus =" + _ForwardStatus + "" +
                           " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                           " , TimUpd = GetDate()" +
                           " Where ForwardID = " + _ID + "";
               return Returned;
           }
       }
       public string DeleteStr
       {
           get
           {
               string Returned = " UPDATE    CRMCustomerVisitForward" +
                            " SET   "+
                            " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            " , Dis = GetDate()" +
                            " Where ForwardID = " + _ID + "";
               return Returned;
           }
       }
       public static string SearchStr
       {
           get
           {
               string Returned = " SELECT     ForwardID, Visit, ForwardDate,ForwardDesc,ForwardStatus,ForwardApplicant,UsrIns,TimIns,UsrUpd,TimUpd" +
                   //" , VisitTable.*" +
                                 " FROM         CRMCustomerVisitForward ";
                                //" Inner Join ("+ VisitDb.SearchStr +") as VisitTable "+
                                //" On VisitTable.VisitID = CRMCustomerVisitForward.Visit";
               return Returned;
           }
       }
       #endregion
       #region Private Methods
       void SetData(DataRow objDR)
       {
           _ID = int.Parse(objDR["ForwardID"].ToString());           
           _Visit = int.Parse(objDR["Visit"].ToString());
           _ForwardApplicant = int.Parse(objDR["ForwardApplicant"].ToString());
           _ForwardDate = DateTime.Parse(objDR["ForwardDate"].ToString());
           _ForwardDesc = objDR["ForwardDesc"].ToString();
           if(objDR["UsrIns"].ToString()!="")
           _UsrIns = int.Parse(objDR["UsrIns"].ToString());
       if (objDR["TimIns"].ToString() != "")
           _TimIns = DateTime.Parse(objDR["TimIns"].ToString());
       else
           _TimIns = new DateTime(1900,1,1);


       if (objDR["UsrUpd"].ToString() != "")
           _UsrUpd = int.Parse(objDR["UsrUpd"].ToString());
       if (objDR["TimUpd"].ToString() != "")
           _TimUpd = DateTime.Parse(objDR["TimUpd"].ToString());
       else
           _TimUpd = new DateTime(1900, 1, 1);
          
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
               strSql = strSql + " and ForwardID = " + _ID + "";
           if (_Visit != 0)
               strSql = strSql + " and Visit = " + _Visit + " ";
           if (_ForwardApplicant != 0)
               strSql = strSql + " and ForwardApplicant = " + _ForwardApplicant + " ";

           if (_SalesManApplicantSearch != 0)
           {
               strSql += " And Visit in (SELECT     VisitID FROM         CRMCustomerVisit WHERE     (VisitSalesMan = "+ _SalesManApplicantSearch +") )";
           }
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;           
       }
       #endregion
   }
}
