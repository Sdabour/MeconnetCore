using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class FollowUpTypeDb : BaseSingleDb
    {
         #region Private Data
        #endregion

        #region Constractors
        public FollowUpTypeDb()
        { 

        }
        public FollowUpTypeDb(int intID)
        {
            _ID = intID;
            if (_ID == 0)
                return;
                    DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public FollowUpTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     FollowUpTypeID, FollowUpTypeNameA, FollowUpTypeNameE"+
                                  " FROM         CRMFollowUpType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["FollowUpTypeID"].ToString());
            _NameA = objDR["FollowUpTypeNameA"].ToString();
            _NameE = objDR["FollowUpTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMFollowUpType"+
                            " ( FollowUpTypeNameA, FollowUpTypeNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMFollowUpType"+
                            " SET  FollowUpTypeNameA ='"+_NameA+"'"+
                            ", FollowUpTypeNameE = '"+_NameE+"'"+
                            " Where FollowUpTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMFollowUpType"+
                            " SET   Dis = GetData() "+
                            " Where FollowUpTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  FollowUpTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
