using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ParagraphImageDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public ParagraphImageDb()
        { }
        public ParagraphImageDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ParagraphID;

        public int ParagraphID
        {
            get { return _ParagraphID; }
            set { _ParagraphID = value; }
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
        public string AddStr
        {
            get
            {
                string Returned = "insert into PORTALParagraphImage (ParagraphID, ImageID, ImageOrder, ParagraphImageTitleA,ParagraphImageTitleE) " +
                    " values (" + _ParagraphID + "," + _ImageID + "," + _Order + ",'" + _TitleA + "','" + _TitleE + "') ";
                return Returned;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        PORTALParagraphImage.ParagraphID, PORTALParagraphImage.ImageOrder" +
                    ", PORTALParagraphImage.ParagraphImageTitleA, PORTALParagraphImage.ParagraphImageTitleE " +
                    ",ImageTable.* " +
                        " FROM    PORTALParagraphImage INNER JOIN " +
                       " (" + ImageDb.SearchStr + ") AS ImageTable ON PORTALParagraphImage.ImageID = ImageTable.ImageID " +
                       "  INNER JOIN    PORTALParagraph " +
                       " ON PORTALParagraphImage.ParagraphID = PORTALParagraph.ParagraphID "+
                       "  INNER JOIN    PORTALSUB  "+
                       " ON PORTALPARAGRAPH.PARAGRAPHSUBID = PORTALSUB.SUBID ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "ParagraphImageTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ParagraphID = int.Parse(objDr["ParagraphID"].ToString());
            _ImageID = int.Parse(objDr["ImageID"].ToString());
            _Order = int.Parse(objDr["ImageOrder"].ToString());
            _TitleA = objDr["ParagraphImageTitleA"].ToString();
            _TitleE = objDr["ParagraphImageTitleE"].ToString();
        }
        #endregion
        #region Publi Method
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ContentID != 0)
            {
                strSql += " and PORTALSUB.SUBContentID ="+ _ContentID;
            }
            if (_ContentIDs != null && _ContentIDs!="")
            {
                strSql += " and PORTALSUB.SUBContentID in (" + _ContentIDs + ") ";
            }
            if (_PageID != 0)
            {
                string strPage = "SELECT        LocationContent  "+
                       " FROM            PORTALLocation "+
                       " WHERE        (LocationPageID = "+ _PageID +")";
                strSql += " and    PORTALSUB.SUBContentID  in (" + strPage +") " ;
            }
                DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
            return Returned;
        }
        #endregion
    }
}