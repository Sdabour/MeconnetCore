using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class TopicDb : BaseSingleDb
    {

        #region Private Data


        #endregion
        #region Constractors
        public TopicDb()
        {

        }
        public TopicDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO PORTALTopic" +
                          " (TopicCode, TopicNameA, TopicNameE,UsrIns,TimIns)" +
                          " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                          ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    PORTALTopic" +
                            " SET  TopicCode ='" + _Code + "'" +
                            " , TopicNameA ='" + _NameA + "'" +
                            "  ,TopicNameE = '" + _NameE + "'" +
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            " ,TimUpd= GetDate() " +
                            " where TopicID  = " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    PORTALTopic" +
                            " SET TopicChanged = 1,Dis= GetDate() " +
                            " where TopicID  = " + _ID;
                return Returned;
            }
        }
        string _IDsStr;

        public string IDsStr
        {
            set { _IDsStr = value; }
        }
        public string EditChangedStr
        {
            get
            {
                string Returned = " UPDATE    PORTALTopic" +
                            " SET TopicChanged = 0 " +
                            " where TopicID  in (" + _IDsStr + ")";
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALTopic (TopicID) " +
                     " SELECT       " + _ID + " AS TopicID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        TopicID " +
                     " FROM            PORTALTopic  " +
                     " WHERE        (TopicID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     TopicID, TopicCode, TopicNameA, TopicNameE  " +
                                  " FROM         PORTALTopic ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "TopicTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["TopicID"].ToString());
            _NameA = objDR["TopicNameA"].ToString();
            _NameE = objDR["TopicNameE"].ToString();
            _Code = objDR["TopicCode"].ToString();

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
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  TopicID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, TableName);
        }
        #endregion

    }
}