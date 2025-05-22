using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UtilityDb : BaseSingleDb
    {
        #region Private Data
        #region Private Data For Search
        protected string _LikeNameA;
        protected string _LikeNameE;
        #endregion
        #endregion

        #region Constructors
        public UtilityDb()
        { 

        }
        public UtilityDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["UtilityNameA"].ToString();
            _NameE = objDR["UtilityNameE"].ToString();
        }
        public UtilityDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["UtilityID"].ToString());
            _NameA = objDR["UtilityNameA"].ToString();
            _NameE = objDR["UtilityNameE"].ToString();
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
                string Returned = " SELECT     UtilityID, UtilityNameA, UtilityNameE  FROM    CRMUtility ";
                return Returned;


            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void  Add()
        {
            string strSql = " INSERT INTO CRMUtility"+
                            "(UtilityNameA, UtilityNameE)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"') ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUtility " +
                            " SET  UtilityNameA ='" + _NameA + "'" +
                            " , UtilityNameE ='" + _NameE + "'" +
                            " Where UtilityID = " + _ID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUtility  SET   Dis = GeteDate() Where UtilityID = " + _ID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + "  where (Dis is Null)";
            if (_ID != 0)
                strSql += " And UtilityID = " + _ID + "";
            if (_LikeNameA != null && _LikeNameA != "")
                strSql += " And UtilityNameA Like '%" + _LikeNameA + "%' ";
            if (_LikeNameE != null && _LikeNameE != "")
                strSql += " And UtilityNameE Like '%" + _LikeNameE + "%' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
