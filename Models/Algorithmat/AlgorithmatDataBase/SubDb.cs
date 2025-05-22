using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.Base.BaseDataBase;

using System.Data;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class SUBDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        int _ContentID;

        public int ContentID
        {
            get { return _ContentID; }
            set { _ContentID = value; }
        }
        string _ContentIDs;

        public string ContentIDs
        {
            get { return _ContentIDs; }
            set { _ContentIDs = value; }
        }
        string _TitleA;

        public string TitleA
        {
            get { return _TitleA; }
            set { _TitleA = value; }
        }
        string _TitleE;

        public string TitleE
        {
            get { return _TitleE; }
            set { _TitleE = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        int _SecondarySubID;

        public int SecondarySubID
        {
            get { return _SecondarySubID; }
            set { _SecondarySubID = value; }
        }
        bool _HasAnIndex;

        public bool HasAnIndex
        {
            get { return _HasAnIndex; }
            set { _HasAnIndex = value; }
        }
        #endregion
        #region Constructors
        public SUBDb()
        { }
        public SUBDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties

        public string AddStr
        {
            get
            {
                int intHasInIndex = _HasAnIndex ? 1 : 0;

                string Returned = "insert into PORTALSUB (SUBContentID, SUBTitleA, SUBTitleE, SUBDesc, SUBOrder " +
                    ",SUBHasAnIndex, UsrIns, TimIns) " +
                    " values ("+ _ContentID +",'" + _TitleA + "','" + _TitleE + "','" + _Desc + "',"+ _Order +
                    "," + intHasInIndex +"," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intHasInIndex = _HasAnIndex ? 1 : 0;
                string Returned = "update PORTALSUB  " +
                    " set SUBContentID = " +  _ContentID+
                    " ,SUBTitleA='" + _TitleA.Replace("'", "''") + "'" +
                    ", SUBTitleE='" + _TitleE.Replace("'", "''") + "'" +
                    ", SUBDesc='" + _Desc.Replace("'", "''") + "'" +
                    ",SUBHasAnIndex="+intHasInIndex+
                    ",SUBOrder="+ _Order+
                    ", SUBChanged=1" +
                    ", UsrUpd=" + SysData.CurrentUser.ID +
                    ", TimUpd=GetDate() " +
                    " where SUBID =" + _ID + " and SUBContentID="+ _ContentID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALSUB (SUBID) " +
                     " SELECT       " + _ID + " AS SUBID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        SUBID " +
                     " FROM            PORTALSUB  " +
                     " WHERE        (SUBID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALSUB  " +
                  " set  SUBChanged = 1,Dis=GetDate() " +
                  " where SUBID =" + _ID;
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
                string Returned = "update PORTALSUB  " +
                  " set  SUBChanged = 0  " +
                  " where SUBID in (" + _IDsStr +")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        SUBID, SUBContentID, SUBTitleA, SUBTitleE, SUBDesc, SUBOrder,SUBHasAnIndex, SUBChanged " +
                      " FROM      PORTALSUB ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "SubTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["SUBID"].ToString());
            _ContentID = int.Parse(objDr["SUBContentID"].ToString());
            _Desc = objDr["SUBDesc"].ToString();
            _TitleA = objDr["SUBTitleA"].ToString();
            _TitleE = objDr["SUBTitleE"].ToString();
            _Order = int.Parse(objDr["SUBOrder"].ToString());
            try
            {
                _IsChanged = bool.Parse(objDr["SUBIsChanged"].ToString());
            }
            catch { }
                if (objDr.Table.Columns["SecondarySubID"] != null)
                _SecondarySubID = int.Parse(objDr["SecondarySubID"].ToString());

                bool.TryParse(objDr["SUBHasAnIndex"].ToString(), out _HasAnIndex);

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ContentID != 0)
                strSql += " and SUBContentID = "+_ContentID;
            if (_ContentIDs !=null && _ContentIDs != "")
                strSql += " and SUBContentID in (" + _ContentIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
        }
        #endregion
    }
}