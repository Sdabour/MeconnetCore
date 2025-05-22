using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class AdministrativeCostTypeDb : BaseSingleDb
    {
        #region Private Data
        

        #endregion
        #region Constractors
        public AdministrativeCostTypeDb()
        {

        }
        public AdministrativeCostTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CostTypeID,  CostTypeNameA, CostTypeNameE  " +
                                  " FROM         CRMAdministrativeCostType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CostTypeID"].ToString());
            _NameA = objDR["CostTypeNameA"].ToString();
            _NameE = objDR["CostTypeNameE"].ToString();
        
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO CRMAdministrativeCostType" +
                            " ( CostTypeNameA, CostTypeNameE)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = " UPDATE    CRMAdministrativeCostType" +
                            " SET   CostTypeNameA ='" + _NameA + "'" +
                            "  ,CostTypeNameE = '" + _NameE + "'" +
                            " where CostTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update CRMAdministrativeCostType set Dis = GetDate() where CostTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  CostTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}