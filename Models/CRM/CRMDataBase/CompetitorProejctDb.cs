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
    public class CompetitorProjectDb : BaseSingleDb
    {
        #region Private Data
        protected int _CompetitorID;
        string _CompetitorIDs;
        #region Private Data For Search
        protected string _LikeNameA;
        #endregion
        #endregion
        #region Constractors
        public CompetitorProjectDb()
        {

        }
        public CompetitorProjectDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            SetData(objDR);
        }
        public CompetitorProjectDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public int CompetitorID
        {
            set
            {
                _CompetitorID = value;
            }
            get
            {
                return _CompetitorID;
            }
        }
        public string CompetitorIDs
        {
            set
            {
                _CompetitorIDs = value;
            }
        }
#region Public Accessorice
        public string LikeNameA
        {
            set
            {
                _LikeNameA = value;
            }
        }
        #endregion
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ProjectID, ProjectNameA, ProjectNameE, CompetitorTable.* " +
                                  "  FROM    CRMCompetitorProject inner join  (" + CompetitorDb.SearchStr +
                                  ") as CompetitorTable on CompetitorTable.CompetitorID = CRMCompetitorProject.CompetitorID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["ProjectID"].ToString());
            _NameA = objDR["ProjectNameA"].ToString();
            _NameE = objDR["ProjectNameE"].ToString();
            _CompetitorID = int.Parse(objDR["CompetitorID"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMCompetitorProject"+
                            " (ProjectNameA, ProjectNameE, CompetitorID, UsrIns, TimIns)" +
                            " VALUES     ('"+_NameA+"','"+_NameE+"',"+_CompetitorID+","+SysData.CurrentUser.ID+",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMCompetitorProject" +
                            " SET  ProjectNameA ='" + _NameA + "'" +
                            " , ProjectNameE ='" + _NameE + "'" +
                            " , CompetitorID =" + _CompetitorID + "" +
                            " , UsrUpd =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd =GetDate()" +
                            " WHERE     (ProjectID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " DELETE FROM CRMCompetitorProject"+
                            " WHERE     (ProjectID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and ProjectID = " + _ID + ") ";
            if (_CompetitorID != 0)
                strSql += " and CRMCompetitorProject.CompetitorID = " + _CompetitorID + " ";
            if(_CompetitorIDs != null && _CompetitorIDs != "")
                strSql += " and CRMCompetitorProject.CompetitorID in (" + _CompetitorIDs + ") ";
            if (_LikeNameA != null && _LikeNameA != "")
                strSql += " and ProjectNameA like '%" + _LikeNameA + "%'";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
