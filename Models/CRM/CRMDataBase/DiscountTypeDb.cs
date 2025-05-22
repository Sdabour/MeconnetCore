using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class DiscountTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public DiscountTypeDb()
        { 

        }
        public DiscountTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public DiscountTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     DiscountTypeID, DiscountTypeNameA, DiscountTypeNameE"+
                                  " FROM         CRMDiscountType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["DiscountTypeID"].ToString());
            _NameA = objDR["DiscountTypeNameA"].ToString();
            _NameE = objDR["DiscountTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMDiscountType"+
                            " ( DiscountTypeNameA, DiscountTypeNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMDiscountType"+
                            " SET  DiscountTypeNameA ='"+_NameA+"'"+
                            ", DiscountTypeNameE = '"+_NameE+"'"+
                            " Where DiscountTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMDiscountType"+
                            " SET   Dis = GetData() "+
                            " Where DiscountTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  DiscountTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
