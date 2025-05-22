using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ServiceDb : BaseSingleDb
    {
        #region Private Data
        protected int _ServiceType;
        protected int _ServiceProvider;
        #endregion

        #region Constructors
        public ServiceDb()
        {


        }
        public ServiceDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["ServiceNameA"].ToString();
                _NameE = objDR["ServiceNameE"].ToString();
                _ServiceType = int.Parse(objDR["ServiceType"].ToString());
                _ServiceProvider = int.Parse(objDR["ServiceProvider"].ToString());
            }
        }
        public ServiceDb(DataRow objDR)
        {
            if (objDR["ServiceID"].ToString() != "")
                _ID = int.Parse(objDR["ServiceID"].ToString());
            else
                _ID = 0;


            _NameA = objDR["ServiceNameA"].ToString();
            _NameE = objDR["ServiceNameE"].ToString();
            if (objDR["ServiceType"].ToString() != "")
                _ServiceType = int.Parse(objDR["ServiceType"].ToString());
            else
                _ServiceType = 0;

            if (objDR["ServiceProvider"].ToString() != "")
                _ServiceProvider = int.Parse(objDR["ServiceProvider"].ToString());
            else
                _ServiceProvider = 0;
        }

        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONService.ServiceID, COMMONService.ServiceNameA,COMMONService.ServiceNameE,COMMONService.ServiceType,"+
                    "COMMONService.ServiceProvider,ServiceTypeTable.*,ServiceProviderTable.*  "+
                    " from COMMONService inner join ("+ ServiceTypeDb.SearchStr +") ServiceTypeTable on  "+
                    " COMMONService.ServiceType = ServiceTypeTable.ServiceTypeID  "+
                    " inner join ("+ ServiceProviderDb.SearchStr +") as ServiceProviderTable on "+
                    " ServiceProviderTable.ProviderID = COMMONService.ServiceProvider ";
                return Returned;

            }
        }
        public int ServiceType
        {
            set
            {
                _ServiceType = value;
            }
            get
            {
                return _ServiceType;
            }
        }
        public int ServiceProvider
        {
            set
            {
                _ServiceProvider = value;
            }
            get
            {
                return _ServiceProvider;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONService (ServiceNameA,ServiceNameE,ServiceType,ServiceProvider,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _ServiceType + "," + _ServiceProvider + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONService ";
            strSql = strSql + " set ServiceNameA ='" + _NameA + "'";
            strSql = strSql + ", ServiceNameE ='" + _NameE + "'";
            strSql = strSql + ", ServiceType =" + _ServiceType + "";
            strSql = strSql + ", ServiceProvider =" + _ServiceProvider + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ServiceID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONService set Dis = GetDate() where ServiceID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and ServiceID = " + _ID.ToString();
            if (_ServiceType != 0)
                strSql = strSql + " and ServiceType = " + _ServiceType.ToString();
            if (_ServiceProvider != 0)
                strSql = strSql + " and ServiceProvider = " + _ServiceProvider.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
