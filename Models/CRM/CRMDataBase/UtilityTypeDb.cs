using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UtilityTypeDb : BaseSingleDb
    {
        #region Private Data
        #region Private Data For Search
        protected string _LikeNameA;
        protected string _LikeNameE;
        #endregion
        #endregion

        #region Constructors
        public UtilityTypeDb()
        { 

        }
        public UtilityTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["UtilityTypeNameA"].ToString();
            _NameE = objDR["UtilityTypeNameE"].ToString();
        }
        public UtilityTypeDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["UtilityTypeID"].ToString());
            _NameA = objDR["UtilityTypeNameA"].ToString();
            _NameE = objDR["UtilityTypeNameE"].ToString();
        }
        #endregion
        #region Public Properties
        public string LikeNameA
        {
            set
            {
                _LikeNameA = value;
            }

        }
        public string LikeNameE
        {
            set
            {
                _LikeNameE = value;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  UtilityTypeID, UtilityTypeNameA, UtilityTypeNameE  FROM    CRMUtilityType ";
                return Returned;


            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void  Add()
        {
            string strSql = " INSERT INTO CRMUtilityType"+
                            "(UtilityTypeNameA, UtilityTypeNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUtilityType " +
                            " SET  UtilityTypeNameA ='" + _NameA + "'" +
                            " , UtilityTypeNameE ='" + _NameE + "'" +
                            " Where UtilityTypeID = " + _ID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUtilityType  SET   Dis = GeteDate() Where UtilityTypeID = " + _ID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + "  where (Dis is Null)";
            if (_ID != 0)
                strSql += " And UtilityTypeID = " + _ID + "";
            if (_LikeNameA != null && _LikeNameA != "")
                strSql += " And UtilityTypeNameA Like '%" + _LikeNameA + "%' ";
            if (_LikeNameE != null && _LikeNameE != "")
                strSql += " And UtilityTypeNameE Like '%" + _LikeNameE + "%' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
