using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class InsuranceTypeDb : BaseSingleDb
    {
        #region Private Data


        #endregion
        #region Constractors
        public InsuranceTypeDb()
        {

        }
        public InsuranceTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     InsuranceTypeID,  InsuranceTypeNameA, InsuranceTypeNameE  " +
                                  " FROM         CRMInsuranceType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["InsuranceTypeID"].ToString());
            _NameA = objDR["InsuranceTypeNameA"].ToString();
            _NameE = objDR["InsuranceTypeNameE"].ToString();

        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO CRMInsuranceType" +
                            " ( InsuranceTypeNameA, InsuranceTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID + ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = " UPDATE    CRMInsuranceType" +
                            " SET   InsuranceTypeNameA ='" + _NameA + "'" +
                            "  ,InsuranceTypeNameE = '" + _NameE + "'" +
                            ",UsrUpd="+ SysData.CurrentUser.ID+
                            ",TimUpd=GetDate() "+
                            " where InsuranceTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update CRMInsuranceType set Dis = GetDate() where InsuranceTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  InsuranceTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}