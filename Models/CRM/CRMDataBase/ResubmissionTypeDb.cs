using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ResubmissionTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public ResubmissionTypeDb()
        {

        }
        public ResubmissionTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ResubmissionTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT      ResubmissionTypeID,ResubmissionTypeCode , ResubmissionTypeNameA, ResubmissionTypeNameE " +
                                  " FROM         CRMResubmissionType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ResubmissionTypeID"].ToString() != "")
                _ID = int.Parse(objDR["ResubmissionTypeID"].ToString());
            _Code = objDR["ResubmissionTypeCOde"].ToString();
            _NameA = objDR["ResubmissionTypeNameA"].ToString();
            _NameE = objDR["ResubmissionTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMResubmissionType" +
                            " (ResubmissionTypeCode, ResubmissionTypeNameA, ResubmissionTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMResubmissionType " +
                            " SET ResubmissionTypeCode ='" + _Code + "'" +
                            ", ResubmissionTypeNameA ='" + _NameA + "'" +
                            ", ResubmissionTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where ResubmissionTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMResubmissionType " +
                            " SET   Dis = GetData() " +
                            " Where ResubmissionTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  ResubmissionTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
