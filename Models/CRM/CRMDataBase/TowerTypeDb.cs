using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class TowerTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public TowerTypeDb()
        {

        }
        public TowerTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public TowerTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO CRMTowerType" +
                            " (TypeCode , TypeNameA, TypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," +
                            SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    CRMTowerType" +
                            " SET  TypeCode = '" + _Code + "' " +
                            ", TypeNameA ='" + _NameA + "'" +
                            ", TypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where TypeID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMTowerType" +
                            " SET   Dis = GetData() " +
                            " Where TypeID  = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     TypeID,TypeCode, TypeNameA, TypeNameE " +
                                  " FROM         CRMTowerType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["TypeID"] != null && objDR["TypeID"].ToString() != "")
                _ID = int.Parse(objDR["TypeID"].ToString());
            if (objDR.Table.Columns["TypeCode"] != null)
                _Code = objDR["TypeCode"].ToString();
            if (objDR.Table.Columns["TypeNameA"] != null)
                _NameA = objDR["TypeNameA"].ToString();
            if (objDR.Table.Columns["TypeNameE"] != null)
                _NameE = objDR["TypeNameE"].ToString();
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
                strSql += " and  TypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
