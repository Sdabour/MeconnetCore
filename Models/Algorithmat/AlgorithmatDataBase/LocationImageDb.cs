using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class LocationImageDb
    {
        #region Private Data
       
        #endregion
        #region Constructors
        public LocationImageDb()
        { }
        public LocationImageDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _LocationID;

        public int LocationID
        {
            get { return _LocationID; }
            set { _LocationID = value; }
        }
        int _ImageID;

        public int ImageID
        {
            get { return _ImageID; }
            set { _ImageID = value; }
        }
        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
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
        int _PageID;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        string _PageIDs;

        public string PageIDs
        {
            get { return _PageIDs; }
            set { _PageIDs = value; }
        }
        static DataTable _CacheLocationImageTable;

        public static DataTable CacheLocationImageTable
        {
            get { return LocationImageDb._CacheLocationImageTable; }
            set { LocationImageDb._CacheLocationImageTable = value; }
        }
        public static string TableName
        {
            get { return "LocationImageTable"; }
        }
        public string AddStr
        {
            get
            {
                string Returned = "insert into PORTALLocationImage (LocationID, ImageID, ImageOrder, LocationImageTitleA,LocationImageTitleE) " +
                    " values ("+ _LocationID + "," + _ImageID + "," +_Order + ",'"+ _TitleA + "','" + _TitleE +"') " ;
                return Returned;
            }
        }
      
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        PORTALLocationImage.LocationID, PORTALLocationImage.ImageOrder"+
                    ", PORTALLocationImage.LocationImageTitleA, PORTALLocationImage.LocationImageTitleE "+
                    ",ImageTable.* "+
                        " FROM    PORTALLocationImage INNER JOIN "+
                       " ("+ ImageDb.SearchStr +") AS ImageTable ON PORTALLocationImage.ImageID = ImageTable.ImageID "+
                       "  INNER JOIN    PORTALLocation "+
                       " ON PORTALLocationImage.LocationID = PORTALLocation.LocationID ";  
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _LocationID = int.Parse(objDr["LocationID"].ToString());
            _ImageID = int.Parse(objDr["ImageID"].ToString());
            _Order = int.Parse(objDr["ImageOrder"].ToString());
            _TitleA = objDr["LocationImageTitleA"].ToString();
            _TitleE = objDr["LocationImageTitleE"].ToString();
        }
        #endregion
        #region Publi Method
        public DataTable Search()
        {
            string strSql = SearchStr+" where (1=1) ";
            if(_PageID != 0) 
             strSql += " and   PORTALLocation.LocationPageID ="+ _PageID;
            if (_PageIDs != null && _PageIDs!="")
                strSql += " and   PORTALLocation.LocationPageID in (" + _PageIDs + ")";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
            return Returned;
        }
        #endregion
    }
}