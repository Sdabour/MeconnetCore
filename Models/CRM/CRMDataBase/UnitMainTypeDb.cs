using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitMainTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitMainTypeDb()
        {

        }
        public UnitMainTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public UnitMainTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO CRMUnitMainType" +
                            " (MainTypeCode , MainTypeNameA, MainTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," +
                            SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    CRMUnitMainType" +
                            " SET  MainTypeCode = '" + _Code + "' " +
                            ", MainTypeNameA ='" + _NameA + "'" +
                            ", MainTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where MainTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMUnitMainType" +
                            " SET   Dis = GetData() " +
                            " Where MainTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     MainTypeID,MainTypeCode, MainTypeNameA, MainTypeNameE " +
                                  " FROM         CRMUnitMainType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["MainTypeID"]!= null &&  objDR["MainTypeID"].ToString() != "")
                _ID = int.Parse(objDR["MainTypeID"].ToString());
            if (objDR.Table.Columns["MainTypeCode"] != null )
            _Code = objDR["MainTypeCode"].ToString();
        if (objDR.Table.Columns["MainTypeNameA"] != null )
            _NameA = objDR["MainTypeNameA"].ToString();
        if (objDR.Table.Columns["MainTypeNameE"] != null )
            _NameE = objDR["MainTypeNameE"].ToString();
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
            string strSql =EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql =DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  MainTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
