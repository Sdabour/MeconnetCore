using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class BonusTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public BonusTypeDb()
        { 

        }
        public BonusTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public BonusTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     BonusTypeID, BonusTypeNameA, BonusTypeNameE"+
                                  " FROM         CRMBonusType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {

            _ID = int.Parse(objDR["BonusTypeID"].ToString());
            _NameA = objDR["BonusTypeNameA"].ToString();
            _NameE = objDR["BonusTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMBonusType"+
                            " ( BonusTypeNameA, BonusTypeNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMBonusType"+
                            " SET  BonusTypeNameA ='"+_NameA+"'"+
                            ", BonusTypeNameE = '"+_NameE+"'"+
                            " Where BonusTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMBonusType"+
                            " SET   Dis = GetData() "+
                            " Where BonusTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  BonusTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
