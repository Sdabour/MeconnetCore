using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ComponantDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        #region Constractor
        public ComponantDb()
        {

        }

        public ComponantDb(int intID)
        {

            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["ComponantNameA"].ToString();
            _NameE = objDR["ComponantNameE"].ToString();
        }

        public ComponantDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ComponantID"].ToString());
            _NameA = objDR["ComponantNameA"].ToString();
            _NameE = objDR["ComponantNameE"].ToString();
        }


        #endregion
        #region Public Probreties

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ComponantID,ComponantNameA, ComponantNameE FROM         CRMComponant";

                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMComponant (ComponantNameA, ComponantNameE)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override void Edit()
        {
            string strSql = " UPDATE    CRMComponant " +
                            " SET  ComponantNameA = '" + _NameA + "'" +
                            " , ComponantNameE = '" + _NameE + "'" +
                            " Where (CRMComponant.ComponantID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMComponant.Dis  IS NULL)";
            if (_ID != 0)
                strSql = strSql + " CRMComponant.ComponantID) = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public override void Delete()
        {
            string strSql = " UPDATE    CRMComponant SET  Dis = GetDate()" +
                " where ComponantID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion

    }
}
