using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class PageImageBiz
    {
        #region Private Data and Public Properties
        PageImageDb _PageImagedDb;
        ImageBiz _ImageBiz;

        public ImageBiz ImageBiz
        {
            get {
                if (_ImageBiz == null)
                    _ImageBiz = new ImageBiz();
                return _ImageBiz; }
            set { _ImageBiz = value; }
        }
        public int PageID
        {
            get { return _PageImagedDb.PageID; }
            set { _PageImagedDb.PageID = value; }
        }





        public int Order
        {
            get { return _PageImagedDb.Order; }
            set
            {
                _PageImagedDb.Order = value;
            }
        }


        public string TitleA
        {
            get { return _PageImagedDb.TitleA; }
            set { _PageImagedDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _PageImagedDb.TitleE; }
            set { _PageImagedDb.TitleE = value; }
        }
        public string Title
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 || TitleE == null || TitleE == "")
                    Returned = TitleA;
                else
                    Returned = TitleE;
                return Returned;
            }
        }
        #endregion
        #region Constructors
        public PageImageBiz()
        {
            _PageImagedDb = new PageImageDb();
        }
        public PageImageBiz(DataRow objDr)
        {
            _PageImagedDb = new PageImageDb(objDr);
            _ImageBiz = new ImageBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public DataRow GetRow( DataTable dtImage)
        {
            DataRow objDr = dtImage.NewRow();
            objDr["PageID"] = PageID;
            objDr["ImageID"] = ImageBiz.ID;
            objDr["ImageOrder"] = Order;
            objDr["PageImageTitleA"] = TitleA;
            objDr["PageImageTitleE"] = TitleE;
           // objDr["SecondaryPage"] = intPage;
            return objDr;
        }
        #endregion
    }
}