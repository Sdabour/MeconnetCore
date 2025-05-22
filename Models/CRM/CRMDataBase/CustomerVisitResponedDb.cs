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
   public class CustomerVisitResponedDb
   {
       #region Private Data
       protected int _ID;
       protected int _Visit;
       protected DateTime _ResponedDate;
       protected string _ResponedDesc;
       protected int _AdminApplicant;
       protected int _SalesManApplicant;
       protected int _UsrIns;
       protected int _Forward;
       protected DateTime _TimIns;
       protected int _UsrUpd;
       protected DateTime _TimUpd;

       protected int _ApplicantSearch;
       #endregion
       #region Constractors
       public CustomerVisitResponedDb()
       { 

       }
       public CustomerVisitResponedDb(DataRow objDR)
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
       public DateTime ResponedDate
       {
           set
           {
               _ResponedDate = value;
           }
           get
           {
               return _ResponedDate;
           }
       }
       public string ResponedDesc
       {
           set
           {
               _ResponedDesc = value;
           }
           get
           {
               return _ResponedDesc;
           }
       }
       public int AdminApplicant
       {
           set
           {
               _AdminApplicant = value;
           }
           get
           {
               return _AdminApplicant;
           }
       }
       public int ApplicantSearch
       {
           set
           {
               _ApplicantSearch = value;
           }
           get
           {
               return _ApplicantSearch;
           }
       }
       public int SalesManApplicant
       {
           set
           {
               _SalesManApplicant = value;
           }
           get
           {
               return _SalesManApplicant;
           }
       }
       public int Forward
       {
           set
           {
               _Forward = value;
           }
           get
           {
               return _Forward;
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
               double dlDate = _ResponedDate.ToOADate() - 2;
               string Returned = "INSERT INTO CRMCustomerVisitResponed" +
                           " (Visit, ResponedDate,ResponedDesc,AdminApplicant,SalesManApplicant,Forward, UsrIns,TimIns)" +
                           " VALUES     (" + _Visit + "," + dlDate + ",'" + _ResponedDesc + "'," + _AdminApplicant + "," + _SalesManApplicant + "," + _Forward + "," + SysData.CurrentUser.ID + ",GetDate()) ";
               return Returned;
           }
       }
       public string EditStr
       {
           get
           {
               double dlDate = _ResponedDate.ToOADate() - 2;
               string Returned = " UPDATE    CRMCustomerVisitResponed" +
                           " SET   Visit = " + _Visit + "" +
                           " , ResponedDate =" + dlDate + "" +
                           " , AdminApplicant =" + _AdminApplicant + "" +
                           " , ResponedDesc ='" + _ResponedDesc + "'" +
                           " , SalesManApplicant =" + _SalesManApplicant + "" +
                           " , Forward = " + _Forward + "" +
                           " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                           " , TimUpd = GetDate()" +
                           " Where ResponedID = " + _ID + "";
               return Returned;
           }
       }
       public string DeleteStr
       {
           get
           {
               string Returned = " UPDATE    CRMCustomerVisitResponed" +
                            " SET   "+
                            " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            " , Dis = GetDate()" +
                            " Where ResponedID = " + _ID + "";
               return Returned;
           }
       }
       public static string SearchStr
       {
           get
           {
               string Returned = " SELECT     ResponedID, Visit, ResponedDate,ResponedDesc,SalesManApplicant,AdminApplicant,Forward,UsrIns,TimIns,UsrUpd,TimUpd" +
                   //" , VisitTable.*" +
                                 " FROM         CRMCustomerVisitResponed ";
                                //" Inner Join ("+ VisitDb.SearchStr +") as VisitTable "+
                                //" On VisitTable.VisitID = CRMCustomerVisitResponed.Visit";
               return Returned;
           }
       }
       #endregion
       #region Private Methods
       void SetData(DataRow objDR)
       {
           _ID = int.Parse(objDR["ResponedID"].ToString());
           _Visit = int.Parse(objDR["Visit"].ToString());
           _AdminApplicant = int.Parse(objDR["AdminApplicant"].ToString());
           _SalesManApplicant = int.Parse(objDR["SalesManApplicant"].ToString());
           _Forward = int.Parse(objDR["Forward"].ToString());
           _ResponedDate = DateTime.Parse(objDR["ResponedDate"].ToString());
           _ResponedDesc = objDR["ResponedDesc"].ToString();
           if (objDR["UsrIns"].ToString() != "")
               _UsrIns = int.Parse(objDR["UsrIns"].ToString());
           if (objDR["TimIns"].ToString() != "")
               _TimIns = DateTime.Parse(objDR["TimIns"].ToString());
           else
               _TimIns = new DateTime(1900, 1, 1);
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
               strSql = strSql + " and ResponedID = " + _ID + "";
           if (_Visit != 0)
               strSql = strSql + " and Visit = " + _Visit + " ";
           if (_AdminApplicant != 0)
               strSql = strSql + " and AdminApplicant = " + _AdminApplicant + " ";
           if (_SalesManApplicant != 0)
               strSql = strSql + " and SalesManApplicant = " + _SalesManApplicant + " ";
           if (_Forward != 0)
               strSql = strSql + " and Forward = " + _Forward + " ";


           //if (_ApplicantSearch != 0)
           //{
           //    strSql += " And Visit in (SELECT     VisitID FROM         CRMCustomerVisit WHERE     (VisitSalesMan = "+ _ApplicantSearch +") )";
           //}
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;           
       }
       #endregion
   }
}
