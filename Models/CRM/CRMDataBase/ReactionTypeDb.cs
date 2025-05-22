using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReactionTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public ReactionTypeDb()
        {

        }
        public ReactionTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ReactionTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO CRMReactionType" +
                          " (ReactionTypeCode, ReactionTypeNameA, ReactionTypeNameE,UsrIns,TimIns)" +
                          " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                          ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    CRMReactionType" +
                            " SET ReactionTypeCode ='" + _Code + "'" +
                            ", ReactionTypeNameA ='" + _NameA + "'" +
                            ", ReactionTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where ReactionTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMReactionType " +
                            " SET   Dis = GetData() " +
                            " Where ReactionTypeID  = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT      ReactionTypeID,ReactionTypeCode , ReactionTypeNameA, ReactionTypeNameE " +
                                  " FROM         CRMReactionType ";
                return Returned;
            }
        }

        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ReactionTypeID"].ToString() != "")
                _ID = int.Parse(objDR["ReactionTypeID"].ToString());
            _Code = objDR["ReactionTypeCOde"].ToString();
            _NameA = objDR["ReactionTypeNameA"].ToString();
            _NameE = objDR["ReactionTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  ReactionTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
