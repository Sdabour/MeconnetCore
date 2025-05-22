using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ServiceTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        #region Constructors
        public ServiceTypeDb()
        {


        }
        public ServiceTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["ServiceTypeNameA"].ToString();
                _NameE = objDR["ServiceTypeNameE"].ToString();
            }
        }
        public ServiceTypeDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ServiceTypeID"].ToString());
            _NameA = objDR["ServiceTypeNameA"].ToString();
            _NameE = objDR["ServiceTypeNameE"].ToString();

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONServiceType.ServiceTypeID, COMMONServiceType.ServiceTypeNameA,COMMONServiceType.ServiceTypeNameE  from COMMONServiceType";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONServiceType (ServiceTypeNameA,ServiceTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONServiceType ";
            strSql = strSql + " set ServiceTypeNameA ='" + _NameA + "'";
            strSql = strSql + ", ServiceTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ServiceTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONServiceType set Dis = GetDate() where ServiceTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONServiceType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ServiceTypeID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
