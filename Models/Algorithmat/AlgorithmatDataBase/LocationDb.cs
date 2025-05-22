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
    public class LocationDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        int _PageID;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
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
        string _Title1A;

        public string Title1A
        {
            get { return _Title1A; }
            set { _Title1A = value; }
        }
        string _Title1E;

        public string Title1E
        {
            get { return _Title1E; }
            set { _Title1E = value; }
        }
        string _DisplayPage;

        public string DisplayPage
        {
            get { return _DisplayPage; }
            set { _DisplayPage = value; }
        }

        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        string _LinkA;

        public string LinkA
        {
            get { return _LinkA; }
            set { _LinkA = value; }
        }
        string _LinkE;

        public string LinkE
        {
            get { return _LinkE; }
            set { _LinkE = value; }
        }
        
        int _Content;

        public int Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        int _SecondaryLocation;

        public int SecondaryLocation
        {
            get { return _SecondaryLocation; }
            set { _SecondaryLocation = value; }
        }
        string _PageIDs;

        public string PageIDs
        {
            get { return _PageIDs; }
            set { _PageIDs = value; }
        }
        static DataTable _CacheLocationTable;

        public static DataTable CacheLocationTable
        {
            get { return LocationDb._CacheLocationTable; }
            set { LocationDb._CacheLocationTable = value; }
        }
        public static string TableName
        {
            get { return "LocationTable"; }
        }

        #endregion
        #region Constructors
        public LocationDb()
        { }
        public LocationDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties

        public string AddStr
        {
            get
            {


                string Returned = "insert into PORTALLocation (LocationPageID,LocationOrder,LocationDesc, LocationTitleA, LocationTitleE, LocationTitle1A, LocationTitle1E, LocationDisplayPage" +
                    ",LocationLinkA,LocationLinkE,LocationContent, UsrIns, TimIns) " +
                    " values ("  +_PageID +","+ _Order + ",'" + _Desc + "','" + _TitleA + "','" + _TitleE +
                      "','" +  _Title1A + "','"+  _Title1E + "','" + _DisplayPage + "','" +
                    _LinkA +"','"+  _LinkE + "'," + _Content + ","+
                    SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                
                string Returned = "update PORTALLocation  " +
                    " set   LocationPageID="+_PageID  +
                    ",LocationOrder="+_Order+
                    ",LocationDesc='"+ _Desc +"'"+
                    ",  LocationTitleA='"+ _TitleA +"'"+
                    ", LocationTitleE='"+ _TitleE +"'"+
                       ",  LocationTitle1A='" + _Title1A + "'" +
                    ", LocationTitle1E='" + _Title1E + "'" +
                    ", LocationDisplayPage='" + _DisplayPage + "'"+
                    ",LocationLinkA= '"+ _LinkA +"'"+
                    ",LocationLinkE='"+ _LinkE +"'"+
                    ",LocationContent="+_Content +
                    ", LocationChanged=1" +
                    ", UsrUpd=" + SysData.CurrentUser.ID +
                    ", TimUpd=GetDate() " +
                    " where LocationID =" + _ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALLocation (LocationID) " +
                     " SELECT       " + _ID + " AS LocationID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        LocationID " +
                     " FROM            PORTALLocation  " +
                     " WHERE        (LocationID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string EditNonIdentityStr
        {
            get
            {

                string Returned = "insert into PORTALLocation (LocationID, LocationPageID) "+
                    " select "+ _ID +" as LocationID1,"+ _PageID +" as LocationPageID1 "+
                    " where not exists (select LocationID from PORTALLocation where LocationID ="+ _ID +")  ";
                Returned +=" update PORTALLocation  " +
                     " set   LocationPageID=" + _PageID +
                     ",LocationOrder=" + _Order +
                     ",LocationDesc='" + _Desc + "'" +
                     ",  LocationTitleA='" + _TitleA + "'" +
                     ", LocationTitleE='" + _TitleE + "'" +
                                          ",  LocationTitle1A='" + _Title1A + "'" +
                     ", LocationTitle1E='" + _Title1E + "'" +
                     ", LocationDisplayPage='" + _DisplayPage + "'" +
                     ",LocationLinkA= '" + _LinkA + "'" +
                     ",LocationLinkE='" + _LinkE + "'" +
                     ",LocationContent=" + _Content +
                     ", LocationChanged=1" +
                     ", UsrUpd=" + SysData.CurrentUser.ID +
                     ", TimUpd=GetDate() " +
                     " where LocationID =" + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALLocation  " +
                  " set  LocationChanged = 1, Dis=GetDate() " +
                  " where LocationID =" + _ID;
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
                string Returned = "update PORTALLocation  " +
                  " set  LocationChanged = 0 " +
                  " where LocationID in (" + _IDsStr + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     LocationID, LocationPageID,LocationOrder,LocationDesc, LocationTitleA, LocationTitleE"+
                    ", LocationTitle1A, LocationTitle1E"+
                    ", LocationDisplayPage,LocationLinkA,LocationLinkE"+
                    ",LocationContent, LocationChanged,ContentTable.* " +
                    " FROM         PORTALLocation "+
                    " left outer join ("+ContentDb.SearchStr+") as ContentTable "+
                    " on  PORTALLocation.LocationContent = ContentTable.ContentID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["LocationID"].ToString());
            _PageID = int.Parse(objDr["LocationPageID"].ToString());
            _Order = int.Parse(objDr["LocationOrder"].ToString());
            _DisplayPage = objDr["LocationDisplayPage"].ToString();
            _Desc = objDr["LocationDesc"].ToString();
            _TitleA = objDr["LocationTitleA"].ToString();
            _TitleE = objDr["LocationTitleE"].ToString();
            _Title1A = objDr["LocationTitle1A"].ToString();
            _Title1E = objDr["LocationTitle1E"].ToString();
          //  if(objDr["LocationIsChanged"].ToString()== "true"||objDr["LocationIsChanged"].ToString()=="false")
            _IsChanged = bool.Parse(objDr["LocationChanged"].ToString());
            _LinkA = objDr["LocationLinkA"].ToString();
            _LinkE = objDr["LocationLinkE"].ToString();
            _Content = int.Parse(objDr["LocationContent"].ToString());
            if (objDr.Table.Columns["SecondaryLocation"] != null)
                _SecondaryLocation = int.Parse(objDr["SecondaryLocation"].ToString());

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
            if (_PageID != 0)
                strSql += " and LocationPageID= " + _PageID;
            if (_PageIDs != null&&_PageIDs!= "")
                strSql += " and LocationPageID in  (" + _PageIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
        }
    
        #endregion
    }
}