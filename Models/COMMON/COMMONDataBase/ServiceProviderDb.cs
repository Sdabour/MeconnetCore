using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ServiceProviderDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        #region Constructors
        public ServiceProviderDb()
        {


        }
        public ServiceProviderDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["ProviderNameA"].ToString();
                _NameE = objDR["ProviderNameE"].ToString();
            }
        }
        public ServiceProviderDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ProviderID"].ToString());
            _NameA = objDR["ProviderNameA"].ToString();
            _NameE = objDR["ProviderNameE"].ToString();

        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONServiceProvider.ProviderID, COMMONServiceProvider.ProviderNameA,COMMONServiceProvider.ProviderNameE  from COMMONServiceProvider";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONServiceProvider (ProviderNameA,ProviderNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONServiceProvider ";
            strSql = strSql + " set ProviderNameA ='" + _NameA + "'";
            strSql = strSql + ", ProviderNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ProviderID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONServiceProvider set Dis = GetDate() where ProviderID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONServiceProvider.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ProviderID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
