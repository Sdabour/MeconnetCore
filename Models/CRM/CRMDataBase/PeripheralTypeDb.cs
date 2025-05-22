using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class PeripheralTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public PeripheralTypeDb()
        {

        }
        public PeripheralTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public PeripheralTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     PeripheralTypeID, PeripheralTypeNameA, PeripheralTypeNameE" +
                                  " FROM         CRMPeripheralType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["PeripheralTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["PeripheralTypeID"].ToString());
            _NameA = objDR["PeripheralTypeNameA"].ToString();
            _NameE = objDR["PeripheralTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMPeripheralType" +
                            " ( PeripheralTypeNameA, PeripheralTypeNameE)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMPeripheralType" +
                            " SET  PeripheralTypeNameA ='" + _NameA + "'" +
                            ", PeripheralTypeNameE = '" + _NameE + "'" +
                            " Where PeripheralTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMPeripheralType" +
                            " SET   Dis = GetData() " +
                            " Where PeripheralTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  PeripheralTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
