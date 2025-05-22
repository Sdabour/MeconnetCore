using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CompanyDB : BaseSingleDb
    {
        #region Private Data
        protected string _Code;
     
        #endregion
        #region Constractors
        public CompanyDB()
        {

        }
        public CompanyDB(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
      
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CompanyID, CompanyCode, CompanyNameA, CompanyNameE  " +
                                  " FROM         GLCompany ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CompanyID"].ToString());
            _NameA = objDR["CompanyNameA"].ToString();
            _NameE = objDR["CompanyNameE"].ToString();
            _Code = objDR["CompanyCode"].ToString();
           
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
           
            string strSql = " INSERT INTO GLCompany" +
                            " (CompanyCode, CompanyNameA, CompanyNameE)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
          
            string strSql = " UPDATE    GLCompany" +
                            " SET  CompanyCode ='" + _Code + "'" +
                            " , CompanyNameA ='" + _NameA + "'" +
                            "  ,CompanyNameE = '" + _NameE + "'" +
                            " where CompanyID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update GLCompany set Dis = GetDate() where CompanyID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  CompanyID  = " + _ID;
          
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}