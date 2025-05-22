using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class SubSectorTypeDb : BaseSingleDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public SubSectorTypeDb()
        {

        }

        public SubSectorTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["SubSectorTypeNameA"].ToString();
            _NameE = objDR["SubSectorTypeNameE"].ToString();
        }
        public SubSectorTypeDb(DataRow objDR)
        {
            //_SectorTypeDb = DR;
            _ID = int.Parse(objDR["SubSectorTypeID"].ToString());
            _NameA = objDR["SubSectorTypeNameA"].ToString();
            _NameE = objDR["SubSectorTypeNameE"].ToString();

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT SubSectorTypeID, SubSectorTypeNameA, SubSectorTypeNameE  " +
                               " from HRSubSectorType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HRSubSectorType (SubSectorTypeNameA,SubSectorTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  HRSubSectorType ";
            strSql = strSql + " set SubSectorTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,SubSectorTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where SectorTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRSubSectorType set Dis = GetDate() where SubSectorTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRSubSectorType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and SubSectorTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}