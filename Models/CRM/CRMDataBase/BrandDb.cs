using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class BrandDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public BrandDb()
        {

        }
        public BrandDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public BrandDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO CRMBrand" +
                            " (BrandCode , BrandNameA, BrandNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," +
                            SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    CRMBrand" +
                            " SET  BrandCode = '" + _Code + "' " +
                            ", BrandNameA ='" + _NameA + "'" +
                            ", BrandNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where BrandID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMBrand" +
                            " SET   Dis = GetData() " +
                            " Where BrandID  = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     BrandID ,BrandCode, BrandNameA, BrandNameE " +
                                  " FROM         CRMBrand ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["BrandID"] != null && objDR["BrandID"].ToString() != "")
                _ID = int.Parse(objDR["BrandID"].ToString());
            if (objDR.Table.Columns["BrandCode"] != null)
                _Code = objDR["BrandCode"].ToString();
            if (objDR.Table.Columns["BrandNameA"] != null)
                _NameA = objDR["BrandNameA"].ToString();
            if (objDR.Table.Columns["BrandNameE"] != null)
                _NameE = objDR["BrandNameE"].ToString();
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
                strSql += " and  BrandID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
