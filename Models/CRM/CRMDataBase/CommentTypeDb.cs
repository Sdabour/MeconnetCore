using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CommentTypeDb : BaseSingleDb
    {
         #region Private Data
        #endregion

        #region Constractors
        public CommentTypeDb()
        { 

        }
        public CommentTypeDb(int intID)
        {
            _ID = intID;
            if (_ID == 0)
                return;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public CommentTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CommentTypeID, CommentTypeNameA, CommentTypeNameE"+
                                  " FROM         CRMCommentType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CommentTypeID"].ToString());
            _NameA = objDR["CommentTypeNameA"].ToString();
            _NameE = objDR["CommentTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMCommentType"+
                            " ( CommentTypeNameA, CommentTypeNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMCommentType"+
                            " SET  CommentTypeNameA ='"+_NameA+"'"+
                            ", CommentTypeNameE = '"+_NameE+"'"+
                            " Where CommentTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMCommentType"+
                            " SET   Dis = GetData() "+
                            " Where CommentTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  CommentTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
