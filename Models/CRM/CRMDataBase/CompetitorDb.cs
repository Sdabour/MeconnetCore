using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CompetitorDb : BaseSingleDb
    {
        #region Private Data
        static string _IDs;
        static DataTable _CompetitorProjectCacheTable;
        #endregion

        #region Constractors
        public CompetitorDb()
        {

        }
        public CompetitorDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["CompetitorNameA"].ToString();
            _NameE = objDR["CompetitorNameE"].ToString();
        }
        public CompetitorDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Acceorice
        public static DataTable CompetitorProjectCacheTable
        {
            set
            {
                _CompetitorProjectCacheTable = value;
            }
            get
            {
                if (_CompetitorProjectCacheTable == null && _IDs != null && _IDs != "")
                {
                    CompetitorProjectDb objDb = new CompetitorProjectDb();
                    objDb.CompetitorIDs = _IDs;
                    _CompetitorProjectCacheTable = objDb.Search();
                }
                return _CompetitorProjectCacheTable;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CompetitorID, CompetitorNameA, CompetitorNameE FROM         CRMCompetitor ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CompetitorID"].ToString());
            _NameA = objDR["CompetitorNameA"].ToString();
            _NameE = objDR["CompetitorNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMCompetitor" +
                            " (CompetitorNameA, CompetitorNameE, UsrIns, TimIns)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",GetDate()) ";
            ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }

        public override void Edit()
        {
            string strSql = " UPDATE    CRMCompetitor" +
                            " SET   CompetitorNameA ='" + _NameA + "'" +
                            " , CompetitorNameE ='" + _NameE + "'" +
                            " , UsrUpd =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            " Where CompetitorID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override void Delete()
        {
            string strSql = " Delete From CRMCompetitor Where CompetitorID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMCompetitor.Dis  IS NULL)";
            if (_ID != 0)
                strSql = strSql + " CRMCompetitor.CompetitorID) = " + _ID.ToString();

            _CompetitorProjectCacheTable = null;
            _IDs = "select CompetitorID from (" + strSql + ") as NativeTable";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
