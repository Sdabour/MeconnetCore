using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class IDTypeDb : BaseSingleDb
    {
        #region Private Data
    
        #endregion
        #region Constructors
        public IDTypeDb()
        {

        }

        public IDTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["IDTypeName"].ToString();
        }
        public IDTypeDb(DataRow objDR)
        {
            //_IDTypeDb = DR;
            _ID = int.Parse(objDR["IDTypeID"].ToString());
            _NameA = objDR["IDTypeName"].ToString();

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT COMMONIDType.IDTypeID, COMMONIDType.IDTypeName ,COMMONIDType.IDTypeName IDTypeNameA,COMMONIDType.IDTypeName IDTypeNameE " +
                               " from COMMONIDType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONIDType (IDTypeName,UsrIns,TimIns) " +
            "values('" + _NameA + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONIDType ";
            strSql = strSql + " set IDTypeName ='" + _NameA + "'";
           // strSql = strSql + " set IDTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where IDTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONIDType set Dis = GetDate() where IDTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONIDType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and IDTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "IDType");
        }
        #endregion
    }
}
