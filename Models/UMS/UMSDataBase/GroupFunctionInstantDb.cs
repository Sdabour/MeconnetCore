using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.UMS.UMSDataBase
{
    
 public    class GroupFunctionInstantDb:FunctionDb
    {
      #region Private Data
      
      int _GroupID;
      DateTime _StartDate;
      DateTime _EndDate;
     bool _IsPermenant;
     bool _IsAdmin;
      GroupDb _GroupDb;
      int _UserID;
     bool _OnlySystemFunction;
     bool _OnlyOnlineFunction;
     bool _OnlyNonStopedFunction;
      #endregion
      #region Constructors
      public GroupFunctionInstantDb()
      {
 
      }
      public GroupFunctionInstantDb(int intGroupID)
      {
          _GroupID = intGroupID;

      }
      public GroupFunctionInstantDb(DataRow objDR)
          : base(objDR)
      {
         // GroupDb = new GroupDb(objDR);
          if(objDR["IsPermanent"].ToString()!= "")
          _IsPermenant = bool.Parse(objDR["IsPermanent"].ToString());
         if( objDR["IsAdmin"].ToString()!= "")
          _IsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
          if (objDR["StartDate"].ToString() == "")
              return;
          try
          {
          _StartDate = DateTime.Parse(objDR["StartDate"].ToString());
          }catch{}
          if (objDR["EndDate"].ToString() == "")
              return;
          try
          {
          _EndDate = DateTime.Parse(objDR["EndDate"].ToString());
          }catch{}
      }
      #endregion
      #region Public Properties

      public int GroupID
      {
          set
          {
              _GroupID = value;
          }
          get
          {
              return _GroupID;
          }
      }
      public DateTime StartDate
      {
          set
          {
              _StartDate = value;
          }
          get
          {
              return _StartDate;
          }
      }
      public DateTime EndDate

      {
          set
          {
              _EndDate = value;
          }
          get
          {
              return _EndDate;
          }
      }
      public bool IsPermenant
      {
          set
          {
              _IsPermenant = value;
          }
          get
          {
              return _IsPermenant;
          }
      }
     public bool IsAdmin
     {
         set
         {
             _IsAdmin = value;
         }
         get
         {
             return _IsAdmin;
         }
     }
      public GroupDb GroupDb
      {
          set
          {
              _GroupDb = value;
          }
          get
          {
              return _GroupDb;
          }
        }
     public int UserID
     {
         set
         {
             _UserID = value;
         }
         get
         {
             return _UserID;
         }
     }
     public bool OnlySystemFunction
     {
         set
         {
             _OnlySystemFunction = value;
         }
     }
     public bool OnlyOnlineFunction
     {
         set
         {
             _OnlyOnlineFunction = value;
         }
     }
     public bool OnlyNonStopedFunction
     {
         set
         {
             _OnlyNonStopedFunction = value;
         }
     }
     string _FunctionIDs;

     public string FunctionIDs
     {
         get { return _FunctionIDs; }
         set { _FunctionIDs = value; }
     }
       

        #endregion
      #region Private Methods
     void SetRecursiveTable(string strParentFunctionID, ref DataTable dtDist, DataTable dtSource)
     {
         DataRow[] arrDr = dtSource.Select("FunctionID=" + strParentFunctionID);
         if (arrDr.Length > 0)
         {
             string strTemp = arrDr[0]["FunctionParentID"].ToString();
             dtDist.ImportRow(arrDr[0]);
             if (strTemp != strParentFunctionID)
             {
                 SetRecursiveTable(strTemp, ref dtDist, dtSource);
             }
         }
     }
     void SetRecursiveChildernTable(string strParentFunctionID, ref DataTable dtDist, DataTable dtSource)
     {
         DataRow[] arrDr = dtSource.Select("FunctionID <> FunctionParentID and FunctionParentID=" + strParentFunctionID);
         if (arrDr.Length > 0)
         {
             foreach (DataRow objDr in arrDr)
             {
                 string strTemp = objDr["FunctionID"].ToString();
                 dtDist.ImportRow(objDr);

                 SetRecursiveChildernTable(strTemp, ref dtDist, dtSource);

             }
         }
     }
        #endregion
      #region Public Methods
     public DataTable PureSearch()
     {
            string strUserGroup = @"SELECT        UG as GroupID
FROM dbo.UMSUser
WHERE(UID = " + _UserID +@")";
            strUserGroup += @" union
SELECT   GroupID
FROM            dbo.UMSUserGroup
WHERE        (UserID = "+ _UserID +@") AND 
(
(IsPermanent = 1) OR (EndDate >= GETDATE())
)";
            string strSql = "SELECT FunctionTable.* , " +
                            " UMSGroupFunction.IsPermanent, UMSGroupFunction.StartDate, UMSGroupFunction.EndDate,UMSGroupFunction.IsAdmin  " +
                            " FROM  UMSGroupFunction  INNER JOIN " +
                            " (" + FunctionDb.SearchStr + ") as FunctionTable ON UMSGroupFunction.FunctionID = FunctionTable.FunctionID  ";

            if (_UserID != 0)
                strSql += " inner join ("+ strUserGroup +") as UserGroupTable "+
                    " on UMSGroupFunction.GroupID = UserGroupTable.GroupID ";
            strSql += "  WHERE  (1=1) ";
            if(_GroupID != 0 && _UserID == 0)
              strSql+= " and (UMSGroupFunction.GroupID =  " + _GroupID + ")  ";
         if (_OnlySystemFunction && BaseDb.SysID != 0)
             strSql = strSql + " and (FunctionTable.SysID=" + BaseDb.SysID + ")";
         if (_OnlyNonStopedFunction)
             strSql += " and FunctionIsStoped = 0 ";
         if (_OnlyOnlineFunction)
             strSql += " and FunctionUrl is not null and FunctionUrl <> '' ";
         if (_FunctionIDs != null && _FunctionIDs != "")
             strSql += " and UMSGroupFunction.FunctionID in (" + _FunctionIDs + ") ";
         DataTable dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql, "Function");
         return dtReturned;
     }
      public override DataTable Search()
      {

          string strSql = "";
        
          DataTable dtReturned =PureSearch();
          DataRow[] arrDr = dtReturned.Select("IsAdmin=1", "");
          string strAdminIDs = "";
          foreach (DataRow objDr in arrDr)
          {
              if (strAdminIDs != "")
                  strAdminIDs = strAdminIDs + ",";
              strAdminIDs = strAdminIDs + objDr["FunctionFamilyID"].ToString();
          }
          if (strAdminIDs != "")
          {
              strSql = "SELECT distinct FunctionTable.*, CONVERT(bit, 1) AS  IsPermanent, " +
                          " GetDate() as StartDate, Getdate() as EndDate,  " + _UserID + " as UserID,CONVERT(bit, 1) AS   IsAdmin,3 as FunctionSrc " +
                          " FROM (" + FunctionDb.SearchStr +   ") as FunctionTable  " +
                          " where FunctionFamilyID in (" + strAdminIDs + ")";
              if (_OnlyNonStopedFunction)
                  strSql += " and FunctionIsStoped = 0 ";
              if (_OnlyOnlineFunction)
                  strSql += " and FunctionUrl is not null and FunctionUrl <> '' ";
              DataTable dtTemp;

              dtTemp = BaseDb.UMSBaseDb.ReturnDatatable(strSql);
              string strFunctionID = "";
              foreach (DataRow objDr in arrDr)
              {
                  strFunctionID = objDr["FunctionID"].ToString();
                  SetRecursiveChildernTable(strFunctionID, ref dtReturned, dtTemp);
              }



          }

          return dtReturned;

      }
      #endregion
    }
}
