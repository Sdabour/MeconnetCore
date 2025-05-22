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
    public class SectorTypeDb : BaseSingleDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public SectorTypeDb()
        {

        }

        public SectorTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["TypeNameA"].ToString();
            _NameE = objDR["TypeNameE"].ToString();
        }
        public SectorTypeDb(DataRow objDR)
        {
            //_SectorTypeDb = DR;
            _ID = int.Parse(objDR["SectorTypeID"].ToString());
            _NameA = objDR["TypeNameA"].ToString();
            _NameE = objDR["TypeNameE"].ToString();

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT SectorTypeID, TypeNameA, TypeNameE  " +
                               " from HRSectorType ";
                return Returned;
            }
        }
        public  string AddStr
        {
            get
            {
                string Returned = "insert into HRSectorType (TypeNameA,TypeNameE,UsrIns,TimIns) " +
           "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
                return Returned;
            }
        }
        public  string EditStr
        {
            get
            {
                string Returned = "update  HRSectorType ";
                Returned = Returned + " set TypeNameA ='" + _NameA + "'";
                Returned = Returned + " ,TypeNameE ='" + _NameE + "'";
                Returned = Returned + ",UsrUpd = " + SysData.CurrentUser.ID;
                Returned = Returned + ",TimUpd =Getdate() ";
                Returned = Returned + " where SectorTypeID = " + _ID;
                return Returned;
            }
        }
        public  string DeleteStr
        {
            get
            {
                string Returned = "update HRSectorType set Dis = GetDate() where SectorTypeID=" + _ID;
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override void Delete()
        {

            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRSectorType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and SectorTypeID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}