using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class LocationBiz
    {
        #region Private Data and Public Properties
        LocationDb _LocationDb;
        public int ID
        {
            get { return _LocationDb.ID; }
            set { _LocationDb.ID = value; }
        }


        public int PageID
        {
            get { return _LocationDb.PageID; }
            set { _LocationDb.PageID = value; }
        }
        public int Order
        {
            get { return _LocationDb.Order; }
            set { _LocationDb.Order = value; }
        }
        public string Desc
        {
            set
            {
                _LocationDb.Desc = value;
            }
            get
            {
                return _LocationDb.Desc;
            }
        }
        public string TitleA
        {
            get { return _LocationDb.TitleA; }
            set { _LocationDb.TitleA = value; }
        }
        

        public string TitleE
        {
            get { return _LocationDb.TitleE; }
            set { _LocationDb.TitleE = value; }
        }
        public string Title
        {
            get
            {
                if (SharpVision.SystemBase.SysData.Language == 0 && TitleA != null && TitleA != "")
                    return TitleA;
                else
                    return TitleE;
            }
        }
        public string Title1A
        {
            get { return _LocationDb.Title1A; }
            set { _LocationDb.Title1A = value; }
        }


        public string Title1E
        {
            get { return _LocationDb.Title1E; }
            set { _LocationDb.Title1E = value; }
        }
        public string Title1
        {
            get
            {
                if (SharpVision.SystemBase.SysData.Language == 0 && Title1A != null && Title1A != "")
                    return Title1A;
                else
                    return Title1E;
            }
        }
        public string DisplayPage
        {
            get { return _LocationDb.DisplayPage; }
            set { _LocationDb.DisplayPage = value; }
        }
        public string LinkA
        {
            get { return _LocationDb.LinkA; }
            set
            {
                _LocationDb.LinkA = value; 
            }
        }
        public string LinkE
        {
            get { return _LocationDb.LinkE; }
            set
            {
                _LocationDb.LinkE = value;
            }
        }
        public string Link
        {
            get
            {
                if (SharpVision.SystemBase.SysData.Language == 0 && LinkA != null && LinkA != "")
                    return LinkA;
                else
                    return LinkE;
            }
        }
        public string DisplayContentLink
        {
            get
            {
                string Returned = "";

                if (Link != "")
                    Returned = Link + "?cnt=" + ContentBiz.ID.ToString();
                else if(ContentBiz.Link!= null && ContentBiz.Link!= "")
                    Returned = ContentBiz.Link + "?cnt=" + ContentBiz.ID.ToString();
                return Returned;
            }
        }
        ContentBiz _ContentBiz;

        public ContentBiz ContentBiz
        {
            get {
                if (_ContentBiz == null)
                    _ContentBiz = new ContentBiz();
                return _ContentBiz; }
            set { _ContentBiz = value; }
        }

        PageBiz _PageBiz;

        public PageBiz PageBiz
        {
            get
            {
                if (_PageBiz == null)
                    _PageBiz = new PageBiz();
                return _PageBiz; 
            }
            set { _PageBiz = value; }
        }



        public bool IsChanged
        {
            get { return _LocationDb.IsChanged; }
            set { _LocationDb.IsChanged = value; }
        }
        LocationImageCol _ImageCol;

        public LocationImageCol ImageCol
        {
            get {
                if (_ImageCol == null)
                    _ImageCol = new LocationImageCol(true);
                return _ImageCol; }
            set { _ImageCol = value; }
        }
        #endregion
        #region Constructors
        public LocationBiz()
        {
           
            _LocationDb = new LocationDb();
        }
        public LocationBiz(DataRow objDr)
        {
            _LocationDb = new LocationDb(objDr);
            if(_LocationDb.Content != 0)
            _ContentBiz = new ContentBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _LocationDb.Content = ContentBiz.ID;
            _LocationDb.Add();
        }
        public void Edit()
        {
            _LocationDb.Content = ContentBiz.ID;
            _LocationDb.Edit();
        }
        public void Delete()
        {
            _LocationDb.Delete();
        }
        #endregion
    }
}