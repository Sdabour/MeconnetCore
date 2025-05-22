using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class RankRequestedDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _RankRequestedIDSearch;
        #endregion
        #region Constructors
        public RankRequestedDb()
        {
        }
        public RankRequestedDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        public RankRequestedDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public string NameAComp
        {
            set
            {
                _NameAComp = value;
            }
            get
            {
                return _NameAComp;
            }
        }
        public string NameACompSearch
        {
            set
            {
                _NameACompSearch = value;
            }            
        }
        public string NameEComp
        {
            set
            {
                _NameEComp = value;
            }
            get
            {
                return _NameEComp;
            }
        }
        public string NameECompSearch
        {
            set
            {
                _NameECompSearch = value;
            }
        }
        public int RankRequestedIDSearch
        {
            set
            {
                _RankRequestedIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONRankRequested.RankRequestedID, COMMONRankRequested.RankRequestedNameA,COMMONRankRequested.RankRequestedNameE,"+
                                   " COMMONRankRequested.RankRequestedNameAComp,COMMONRankRequested.RankRequestedNameEComp from COMMONRankRequested";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["RankRequestedID"]  == null||objDR["RankRequestedID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["RankRequestedID"].ToString());
            _NameA = objDR["RankRequestedNameA"].ToString();
            _NameE = objDR["RankRequestedNameE"].ToString();
            _NameAComp = objDR["RankRequestedNameAComp"].ToString();
            _NameEComp = objDR["RankRequestedNameEComp"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONRankRequested (RankRequestedNameA,RankRequestedNameE,RankRequestedNameAComp,RankRequestedNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONRankRequested ";
            strSql = strSql + " set RankRequestedNameA ='" + _NameA + "'";
            strSql = strSql + ", RankRequestedNameE ='" + _NameE + "'";
            strSql = strSql + ", RankRequestedNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", RankRequestedNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where RankRequestedID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONRankRequested set Dis = GetDate() where RankRequestedID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONRankRequested.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and RankRequestedID = " + _ID.ToString();
            if (_RankRequestedIDSearch != 0)
                strSql = strSql + " and RankRequestedID <> " + _RankRequestedIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and RankRequestedNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and RankRequestedNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and RankRequestedNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and RankRequestedNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by RankRequestedID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "RankRequested");
        }
        #endregion
    }
}
