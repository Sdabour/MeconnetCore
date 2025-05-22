using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class TowerUsageTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public TowerUsageTypeDb()
        {

        }
        public TowerUsageTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public TowerUsageTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO CRMTowerUsageType" +
                            " (UsageTypeCode , UsageTypeNameA, UsageTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," +
                            SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    CRMTowerUsageType" +
                            " SET  UsageTypeCode = '" + _Code + "' " +
                            ", UsageTypeNameA ='" + _NameA + "'" +
                            ", UsageTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where UsageTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMTowerUsageType" +
                            " SET   Dis = GetData() " +
                            " Where UsageTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     UsageTypeID as TowerUsageTypeID,UsageTypeCode as TowerUsageTypeCode, UsageTypeNameA as TowerUsageTypeNameA, UsageTypeNameE as TowerUsageTypeNameE " +
                                  " FROM         CRMTowerUsageType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["TowerUsageTypeID"] != null && objDR["TowerUsageTypeID"].ToString() != "")
                _ID = int.Parse(objDR["TowerUsageTypeID"].ToString());
            if (objDR.Table.Columns["TowerUsageTypeCode"] != null)
                _Code = objDR["TowerUsageTypeCode"].ToString();
            if (objDR.Table.Columns["TowerUsageTypeNameA"] != null)
                _NameA = objDR["TowerUsageTypeNameA"].ToString();
            if (objDR.Table.Columns["TowerUsageTypeNameE"] != null)
                _NameE = objDR["TowerUsageTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  UsageTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
