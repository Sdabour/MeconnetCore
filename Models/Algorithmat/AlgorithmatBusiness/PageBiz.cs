using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class PageBiz
    {
        #region Private Data and Public Properties
        PageDb _PageDb;
        public int ID
        {
            get { return _PageDb.ID; }
            set { _PageDb.ID = value; }
        }
        

        public string Desc
        {
            get { return _PageDb.Desc; }
            set { _PageDb.Desc = value; }
        }
        

        public string TitleA
        {
            get { return _PageDb.TitleA; }
            set { _PageDb.TitleA = value; }
        }
     

        public string TitleE
        {
            get { return _PageDb.TitleE; }
            set { _PageDb.TitleE = value; }
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
        public string URLA
        {
            get { return _PageDb.URLA; }
            set { _PageDb.URLA = value; }
        }
       
        public string URLE
        {
            get { return _PageDb.URLE; }
            set { _PageDb.URLE = value; }
        }

        public string URL
        {
            get
            {
                if (SharpVision.SystemBase.SysData.Language == 0 && URLA != null && URLA != "")
                    return URLA;
                else
                    return URLE;
            }
        }
        public bool IsStoped
        {
            get { return _PageDb.IsStoped; }
            set { _PageDb.IsStoped = value; }
        }
      

        public bool IsChanged
        {
            get { return _PageDb.IsChanged; }
            set { _PageDb.IsChanged = value; }
        }
        LocationCol _LocationCol;

        public LocationCol LocationCol
        {
            get 
            {
                if (_LocationCol == null)
                {
                    _LocationCol = new LocationCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr;
                        LocationDb objDb = new LocationDb();
                        objDb.PageID = ID;
                        DataTable dtTemp;
                        if (!SysData.IsOnline)
                        {
                            dtTemp = objDb.Search();
                        }
                        else
                        {
                            dtTemp = PageDb.CacheLocationTable;
                        }
                            arrDr = dtTemp.Select("LocationPageID="+ID, "LocationOrder");
                        foreach (DataRow objDr in arrDr)
                        {
                            _LocationCol.Add(new LocationBiz(objDr));
                        }
                        LocationImageDb objImageDb = new LocationImageDb();
                        objImageDb.PageID = ID;
                        if (!SysData.IsOnline)
                        {
                            dtTemp = objImageDb.Search();
                        }
                        else
                        {
                            dtTemp = PageDb.CacheLocationImageTable;
                        }
                     
                        foreach (LocationBiz objLocationBiz in _LocationCol)
                        {
                            arrDr = dtTemp.Select("LocationID=" + objLocationBiz.ID, "ImageOrder");
                            foreach (DataRow objDr in arrDr)
                            {
                                objLocationBiz.ImageCol.Add(new LocationImageBiz(objDr));
                            }
                        }

                    }
                }
                return _LocationCol; 
            }
            set { _LocationCol = value; }
        }
        LocationCol _DeletedLocatinCol;

        public LocationCol DeletedLocatinCol
        {
            get {
                if (_DeletedLocatinCol == null)
                    _DeletedLocatinCol = new LocationCol(true);
                return _DeletedLocatinCol; }
            set { _DeletedLocatinCol = value; }
        }
        PageImageCol _ImageCol;

        public PageImageCol ImageCol
        {
            get
            {
                if (_ImageCol == null)
                {
                    _ImageCol = new PageImageCol(true);

                    if (ID != 0)
                    {
                        PageImageDb objDb = new PageImageDb();
                        objDb.PageID = ID;
                        
                        DataTable dtTemp ;
                        if (SysData.IsOnline)
                            dtTemp = PageDb.CachePageImageTable;
                        else
                        dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ImageCol.Add(new PageImageBiz(objDr));

                        }
                    }
                }
                return _ImageCol;
            }
            set { _ImageCol = value; }
        }
        #endregion
        #region Constructors
        public PageBiz()
        {
            _PageDb = new PageDb();
        }
        public PageBiz(int intID)
        {
            _PageDb = new PageDb();

            if (intID == 0)
                return;
            PageDb objDb = new PageDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                _PageDb = new PageDb(dtTemp.Rows[0]);

            }
        }
        public PageBiz(DataRow objDr)
        {
            _PageDb = new PageDb(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            DataTable dtLocation , dtLocationImage,dtImage ;
            dtLocation = LocationCol.GetTable(out dtLocationImage,false);
            dtImage = ImageCol.GetTable();
            _PageDb.LocationTable = dtLocation;
            _PageDb.LocationImageTable = dtLocationImage;
            _PageDb.ImageTable = dtImage;
 

            _PageDb.Add();
        }
        public void Edit()
        {
            DataTable dtLocation , dtLocationImage,dtDeletedLocationTable,dtDeletedLocationImageTable ;
            dtLocation = LocationCol.GetTable(out dtLocationImage,false);
            dtDeletedLocationTable = DeletedLocatinCol.GetTable(out dtDeletedLocationImageTable,true);
            _PageDb.DeletedLocationTable = dtDeletedLocationTable;
            _PageDb.LocationTable = dtLocation;
            _PageDb.LocationImageTable = dtLocationImage;
            _PageDb.ImageTable = ImageCol.GetTable();
           
            _PageDb.Edit();
        }
        public void Delete()
        {
            _PageDb.Delete();
        }
        #endregion
    }
}