using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SharpVision.UMS.UMSDataBase
{
  public   class UserFunctionInstantDb:FunctionDb
  {
      #region Private Data
      int _FunctionID;
      int _UserID;
      DateTime _StartDate;
      DateTime _EndDate;
      bool _IsPermenant;
      bool _IsAdmin;
      int _SysID;
      byte _FunctionSrc;
      UserDb _UserDb;
      DataTable _UserFunctionInstantTable;
      bool _AllFunction;
      bool _OnlyOnlineFunction;
      bool _OnlyNonStopedFunction;
      /// <summary>
      /// Function Src Presernted by _FunctionSrc
      /// case 1 then System Function Means that user is System Admin
      /// Case 2 User Functions Presnts Functions that user graneted by himself
      /// 3 Group Function User Granted by being a memeber in a group
      /// </summary>
      #endregion
      #region Constructors
      public UserFunctionInstantDb()
      {
 
      }
      public UserFunctionInstantDb(int intUserID)
      {
          _UserID = intUserID;

      }
      public UserFunctionInstantDb(DataRow objDR)
          : base(objDR)
      {
          UserDb = new UserDb();
          if(objDR.Table.Columns["IsPermanent"]!= null)
          _IsPermenant = bool.Parse(objDR["IsPermanent"].ToString());
          if (objDR["StartDate"].ToString() != "")
          {
           //   return;

              _StartDate = DateTime.Parse(objDR["StartDate"].ToString());
          }
          try
          {
              _IsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
          }
          catch
          {
 
          }
          if (objDR["EndDate"].ToString() == "")
              return;
          _EndDate = DateTime.Parse(objDR["EndDate"].ToString());
          if(objDR.Table.Columns["FunctionSrc"] != null)
          _FunctionSrc = byte.Parse(objDR["FunctionSrc"].ToString());
      }
      #endregion
      #region Public Properties

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
      public UserDb UserDb
      {
          set
          {
              _UserDb = value;
          }
          get
          {
              return _UserDb;
          }
          


      }
      public bool AllFunction
      {
          set
          {
              _AllFunction = value;
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
      public byte FunctionSrc
      {
          set 
          {
              _FunctionSrc = value;
          }
          get
          {
              return _FunctionSrc;
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
      public static string SearchStr
      {
          get
          {
              string Returned = "SELECT distinct FunctionTable.*, UMSUserFunction.IsPermanent, " +
                          " UMSUserFunction.StartDate, UMSUserFunction.EndDate, UMSUserFunction.UserID, " +
                          " UMSUserFunction.IsAdmin,2 as FunctionSrc " +
                          " FROM UMSUserFunction INNER JOIN (" + FunctionDb.SearchStr + ") as FunctionTable ON UMSUserFunction.FunctionID = " +
                          " FunctionTable.FunctionID  ";
              return Returned;
          
          }
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
          string strSelect = "FunctionID<>FunctionParentID and FunctionParentID=" + strParentFunctionID;
          if (_OnlyOnlineFunction)
              strSelect += " and FunctionUrl is not null and FunctionUrl <> ''";
          if (_OnlyNonStopedFunction)
              strSelect += " and FunctionIsStoped = 0 ";
          DataRow[] arrDr = dtSource.Select(strSelect);
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
      public override DataTable Search()
      {


          string strSql = SearchStr +
                          " WHERE  (UMSUserFunction.Dis is null)  and  (UMSUserFunction.UserID = " + _UserID + ")  and ( (UMSUserFunction.IsPermanent = 1) OR (GETDATE() BETWEEN UMSUserFunction.StartDate AND " +
                          " UMSUserFunction.EndDate))";
          if (_OnlyNonStopedFunction)
              strSql += " and FunctionIsStoped = 0 ";
          if (_FunctionIDs != null && _FunctionIDs != "")
              strSql += " and UMSUserFunction.FunctionID in (" + _FunctionIDs + ") ";
          if (_OnlyOnlineFunction)
              strSql += " and FunctionUrl is not null and FunctionUrl <> '' ";
          DataTable dtReturned;
          if (!_AllFunction)
          {
              strSql = strSql + " and (FunctionTable.SysID = " + BaseDb.SysID + ") ";
              dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql, "UserFunction");
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
                              " GetDate() as StartDate, Getdate() as EndDate,  " + _UserID + " as UserID,CONVERT(bit, 1) AS  IsAdmin " +
                              " FROM ("+ FunctionDb.SearchStr +")as FunctionTable  " +
                              " where FunctionFamilyID in (" + strAdminIDs + ")";
                  DataTable dtTemp;
                  if (_OnlyNonStopedFunction)
                      strSql += " and FunctionIsStoped = 0 ";
                  if (_OnlyOnlineFunction)
                      strSql += " and FunctionUrl is not null and FunctionUrl <> '' ";
                  dtTemp = BaseDb.UMSBaseDb.ReturnDatatable(strSql);
                  string strFunctionID = "";
                  foreach (DataRow objDr in arrDr)
                  {
                      strFunctionID = objDr["FunctionID"].ToString();
                      SetRecursiveChildernTable(strFunctionID, ref dtReturned, dtTemp);
                  }



              }
          }
          else
              dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql, "UserFunction");


          return dtReturned;

      }

        #endregion

  }
}
