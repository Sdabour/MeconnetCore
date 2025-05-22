using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CancelationTypeDb : BaseSingleDb
    {
        #region Private Data


        #endregion
        #region Constractors
        public CancelationTypeDb()
        {

        }
        public CancelationTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CancelationTypeID,  CancelationTypeNameA, CancelationTypeNameE  " +
                                  " FROM         CRMCancelationType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CancelationTypeID"].ToString());
            _NameA = objDR["CancelationTypeNameA"].ToString();
            _NameE = objDR["CancelationTypeNameE"].ToString();

        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO CRMCancelationType" +
                            " ( CancelationTypeNameA, CancelationTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = " UPDATE    CRMCancelationType" +
                            " SET   CancelationTypeNameA ='" + _NameA + "'" +
                            "  ,CancelationTypeNameE = '" + _NameE + "'" +
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " where CancelationTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update CRMCancelationType set Dis = GetDate() where CancelationTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  CancelationTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}