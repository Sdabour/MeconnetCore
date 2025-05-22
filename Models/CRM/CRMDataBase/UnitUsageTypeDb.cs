using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitUsageTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitUsageTypeDb()
        {

        }
        public UnitUsageTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public UnitUsageTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT      UsageTypeID,UsageTypeCode , UsageTypeNameA, UsageTypeNameE " +
                                  " FROM         CRMUnitUsageType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["UsageTypeID"].ToString() != "")
                _ID = int.Parse(objDR["UsageTypeID"].ToString());
            _Code = objDR["UsageTypeCOde"].ToString();
            _NameA = objDR["UsageTypeNameA"].ToString();
            _NameE = objDR["UsageTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMUnitUsageType" +
                            " (UsageTypeCode, UsageTypeNameA, UsageTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" +   _Code +  "','"+  _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUnitUsageType" +
                            " SET UsageTypeCode ='"+ _Code +"'"+
                            ", UsageTypeNameA ='" + _NameA + "'" +
                            ", UsageTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where UsageTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitUsageType" +
                            " SET   Dis = GetData() " +
                            " Where UsageTypeID  = " + _ID + "";
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
