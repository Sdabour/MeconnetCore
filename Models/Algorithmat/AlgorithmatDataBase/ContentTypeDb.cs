using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ContentTypeDb:BaseSingleDb
    {
     
            #region Private Data

        string _DisplayPageA;

        public string DisplayPageA
        {
            get {
                if (_DisplayPageA == null)
                    _DisplayPageA = "";
                return _DisplayPageA; }
            set { _DisplayPageA = value; }
        }
        string _DisplayPageE;
        public string DisplayPageE
        {
            get
            {
                if (_DisplayPageE == null)
                    _DisplayPageE = "";
                return _DisplayPageE;
            }
            set { _DisplayPageE = value; }
        }
        int _DisplayIndex;

        public int DisplayIndex
        {
            get { return _DisplayIndex; }
            set { _DisplayIndex = value; }
        }
        public static string TableName
        {
            get { return "ContentTypeTable"; }
        }
            #endregion
            #region Constractors
            public ContentTypeDb()
            {

            }
            public ContentTypeDb(DataRow objDR)
            {
                SetData(objDR);
            }
            #endregion
            #region Public Accessorice

            public string AddStr
            {
                get
                {
                    string Returned = " INSERT INTO PORTALContentType" +
                           " (ContentTypeCode, ContentTypeNameA, ContentTypeNameE,ContentTypeDisplayPageA,ContentTypeDisplayPageE,ContentTypeDisplayIndex,UsrIns,TimIns)" +
                           " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "','"  + _DisplayPageA+"','"+_DisplayPageE+
                           "'," + _DisplayIndex + "," +   SysData.CurrentUser.ID +
                           ",GetDate()) ";
                    return Returned;
                }
            }
            public string EditStr
            {
                get
                {
                    string Returned = " UPDATE    PORTALContentType" +
                              " SET  ContentTypeCode ='" + _Code + "'" +
                              " , ContentTypeNameA ='" + _NameA + "'" +
                              "  ,ContentTypeNameE = '" + _NameE + "'" +
                              ",ContentTypeDisplayPageA='"+ _DisplayPageA +"'"+
                              ",ContentTypeDisplayPageE='"+ _DisplayPageE +"'"+
                              ",ContentTypeDisplayIndex="+ _DisplayIndex +
                              ",UsrUpd=" + SysData.CurrentUser.ID +
                              " ,TimUpd= GetDate() " +
                              " where ContentTypeID  = " + _ID;
                    return Returned;
                }
            }
            public string DeleteStr
            {
                get
                {
                    string Returned = " update PORTALContentType set ContentTypeChanged=1, Dis = GetDate() " +
                        " where ContentTypeID  = " + _ID; ;
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
                    string Returned = " update PORTALContentType set ContentTypeChanged=0 " +
                        " where ContentTypeID in (" + _IDsStr + ") " ;
                    return Returned;
                }
            }
            public string AddIdentityStr
            {
                get
                {
                    string Returned = "INSERT INTO PORTALContentType (ContentTypeID) "+
                        " SELECT       "+ _ID +" AS ContetentTypeID1 "+
                        " WHERE        (NOT EXISTS "+
                        " (SELECT        ContentTypeID "+
                        " FROM            PORTALContentType  "+
                        " WHERE        (ContentTypeID = "+ _ID +"))) ";
                    Returned += " " + EditStr;
                    return Returned;
                }
            }
            public static string SearchStr
            {
                get
                {
                    string Returned = " SELECT     ContentTypeID, ContentTypeCode, ContentTypeNameA, ContentTypeNameE,ContentTypeDisplayPageA ,ContentTypeDisplayPageE,ContentTypeDisplayIndex  " +
                                      " FROM         PORTALContentType ";
                    return Returned;
                }
            }
            #endregion
            #region Private Methods
            void SetData(DataRow objDR)
            {
                _ID = int.Parse(objDR["ContentTypeID"].ToString());
                _NameA = objDR["ContentTypeNameA"].ToString();
                _NameE = objDR["ContentTypeNameE"].ToString();
                _Code = objDR["ContentTypeCode"].ToString();
                _DisplayPageA = objDR["ContentTypeDisplayPageA"].ToString();
                _DisplayPageE = objDR["ContentTypeDisplayPageE"].ToString();
                int.TryParse(objDR["ContentTypeDisplayIndex"].ToString(), out _DisplayIndex);

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
                    strSql = strSql + " and  ContentTypeID  = " + _ID;

                return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
            }
            #endregion
        
    }
}