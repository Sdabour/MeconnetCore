using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class PageImageDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public PageImageDb()
        { }
        public PageImageDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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


        public static string TableName
        {
            get
            {
                return "PageImageTable";
            }
        }
        
        public string AddStr
        {
            get
            {
                string Returned = "insert into PORTALPageImage (PageID, ImageID, ImageOrder, PageImageTitleA,PageImageTitleE) " +
                    " values (" + _PageID + "," + _ImageID + "," + _Order + ",'" + _TitleA + "','" + _TitleE + "') ";
                return Returned;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        PORTALPageImage.PageID, PORTALPageImage.ImageOrder" +
                    ", PORTALPageImage.PageImageTitleA, PORTALPageImage.PageImageTitleE " +
                    ",ImageTable.* " +
                        " FROM    PORTALPageImage INNER JOIN " +
                       " (" + ImageDb.SearchStr + ") AS ImageTable ON PORTALPageImage.ImageID = ImageTable.ImageID " +
                       "  INNER JOIN    PORTALPage " +
                       " ON PORTALPageImage.PageID = PORTALPage.PageID " ;
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _PageID = int.Parse(objDr["PageID"].ToString());
            _ImageID = int.Parse(objDr["ImageID"].ToString());
            _Order = int.Parse(objDr["ImageOrder"].ToString());
            _TitleA = objDr["PageImageTitleA"].ToString();
            _TitleE = objDr["PageImageTitleE"].ToString();
        }
        #endregion
        #region Publi Method
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            
            if (_PageID != 0)
            {

                strSql += " and    PORTALPageImage.PageID  =" + _PageID + " ";
            }
            if (_PageIDs != null && _PageIDs!="")
            {

                strSql += " and    PORTALPageImage.PageID  in (" + _PageIDs + ") ";
            }
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
            return Returned;
        }
        #endregion
    }
}