using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class SpecificDB : BaseSingleDb
    {
        #region Private Data
        protected string _Code;

        #endregion
        #region Constractors
        public SpecificDB()
        {

        }
        public SpecificDB(DataRow objDR)
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
                string Returned = " SELECT     SpecificID, SpecificCode, SpecificNameA, SpecificNameE  " +
                                  " FROM         GLSpecific ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["SpecificID"].ToString());
            _NameA = objDR["SpecificNameA"].ToString();
            _NameE = objDR["SpecificNameE"].ToString();
            _Code = objDR["SpecificCode"].ToString();

        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO GLSpecific" +
                            " (SpecificCode, SpecificNameA, SpecificNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," +SysData.CurrentUser.ID  +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = " UPDATE    GLSpecific" +
                            " SET  SpecificCode ='" + _Code + "'" +
                            " , SpecificNameA ='" + _NameA + "'" +
                            "  ,SpecificNameE = '" + _NameE + "'" +
                            ",UsrUpd="+ SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() "+
                            " where SpecificID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update GLSpecific set Dis = GetDate() where SpecificID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  SpecificID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}