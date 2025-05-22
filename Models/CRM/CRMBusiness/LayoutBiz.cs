using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Linq;
namespace SharpVision.CRM.CRMBusiness
{
    public enum LayoutMode
    {
        UnitLocation,
        LayoutLocation,
        SideViewLocation

    }
    public enum LayoutType
    {
        Plan = 1, SideView = 2, Elevation = 3
    }
    public class LayoutBiz : ImageBiz
    {
        #region Private Data
        DataTable _CellLocationTable;
        DataTable _LayoutLocationTable;
        DataTable _SideViewLocationTable;
        DataTable _UnitLocationTable;
        LocationCol _locationCol;
        LocationCol _FreeLocationCol;
        LocationCol _SoldLocationCol;
        ImageBiz _Logo;
        CellBiz _ProjectBiz;

        #endregion
        #region Constructors
        public LayoutBiz()
        {
            _ImageDb = new LayoutDb();
        }
        public LayoutBiz(int intID)
        {
            DataRow[] arrDr = new DataRow[0];
            if (LayoutDb.CachLayoutTable != null)
                arrDr = LayoutDb.CachLayoutTable.Select("ImageID=" + intID);
            if (LayoutDb.CachLayoutTable != null && arrDr.Length > 0)
            {
                _ImageDb = new LayoutDb(arrDr[0]);
            }
            else
                _ImageDb = new LayoutDb(intID);

            _ProjectBiz = new CellBiz(((LayoutDb)_ImageDb).ProjectID);

        }
        public LayoutBiz(DataRow objDr)
        {
            _ImageDb = new LayoutDb(objDr);
            _ProjectBiz = new CellBiz(((LayoutDb)_ImageDb).ProjectID);
        }

        #endregion
        #region Public Properties
        internal DataTable CellLocationTable
        {
            set
            {
                _CellLocationTable = value;
            }
            get
            {
                if (_CellLocationTable == null)
                {
                    CellLocationDb objDb = new CellLocationDb();
                    objDb.ImageID = ID;
                    _CellLocationTable = objDb.Search();

                }
                return _CellLocationTable;
            }
        }

        internal DataTable LayoutLocationTable
        {
            set
            {
                _LayoutLocationTable = value;
            }
            get
            {
                if (_LayoutLocationTable == null)
                {
                    LayoutLocationDb objDb = new LayoutLocationDb();
                    objDb.ImageID = ID;
                    _LayoutLocationTable = objDb.Search();

                }
                return _LayoutLocationTable;
            }
        }
        internal DataTable SideViewLocationTable
        {
            set
            {
                _SideViewLocationTable = value;
            }
            get
            {
                if (_SideViewLocationTable == null)
                {
                    SideViewLocationDb objDb = new SideViewLocationDb();
                    objDb.ImageID = ID;
                    _SideViewLocationTable = objDb.Search();

                }
                return _SideViewLocationTable;
            }
        }
        internal DataTable UnitLocationTable
        {
            set
            {
                _UnitLocationTable = value;
            }
            get
            {
                if (_UnitLocationTable == null)
                {
                    ResetLayout();
                }
                return _UnitLocationTable;
            }
        }
        public LayoutMode Mode
        {
            get
            {
                if (CellLocationTable.Rows.Count > 0)
                    return LayoutMode.UnitLocation;
                else
                    return LayoutMode.LayoutLocation;
            }
        }
        public LocationCol Locationcol
        {
            get
            {
                if (_locationCol == null)
                {
                    _locationCol = new LocationCol(true);
                    foreach (DataRow objDr in CellLocationTable.Rows)
                    {
                        _locationCol.Add(new CellLocationBiz(objDr));
                    }
                }
                return _locationCol;

            }
        }
        public LocationCol FreeLocationCol
        {
            get
            {
                _FreeLocationCol = new LocationCol(true);
                DataRow[] arrDr = UnitLocationTable.Select("", "Location");
                string strLocation = "";
                string strLocations = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (objDr["Location"].ToString() != strLocation)
                    {
                        strLocation = objDr["Location"].ToString();
                        if (strLocations != "")
                            strLocations += ",";
                        strLocations += strLocation;
                    }
                }
                string strSelect = "";
                if (strLocations != "")
                    strSelect = "LocationID in (" + strLocations + ")";
                arrDr = CellLocationTable.Select(strSelect);
                foreach (DataRow objDr in arrDr)
                {
                    _FreeLocationCol.Add(new CellLocationBiz(objDr));
                }
                return _FreeLocationCol;
            }
        }
        public LocationCol FreeCellLocationCol
        {
            get
            {
                _FreeLocationCol = new LocationCol(true);
                DataRow[] arrDr = UnitLocationTable.Select("", "Location");
                string strLocation = "";
                string strLocations = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (objDr["Location"].ToString() != strLocation)
                    {
                        strLocation = objDr["Location"].ToString();
                        if (strLocations != "")
                            strLocations += ",";
                        strLocations += strLocation;
                    }
                }
                string strSelect = "";
                if (strLocations != "")
                    strSelect = "LocationID in (" + strLocations + ")";
                arrDr = CellLocationTable.Select(strSelect, "LocationCell");
                string strLocationCell = "";
                CellLocationBiz objBiz, objTemp;
                int intMaxX, intMaxY;
                objBiz = new CellLocationBiz();
                string strCellIDs = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (strLocationCell != objDr["LocationCell"].ToString())
                    {
                        strLocationCell = objDr["LocationCell"].ToString();
                        if (strCellIDs != "")
                            strCellIDs += ",";
                        strCellIDs += strLocationCell;
                    }

                }
                strSelect = "";
                if (strCellIDs != "")
                    strSelect = "LocationCell in (" + strCellIDs + ")";
                arrDr = CellLocationTable.Select(strSelect);
                foreach (DataRow objDr in arrDr)
                {
                    if (strLocationCell != objDr["LocationCell"].ToString())
                    {
                        strLocationCell = objDr["LocationCell"].ToString();
                        objBiz = new CellLocationBiz(objDr);
                        _FreeLocationCol.Add(objBiz);
                    }
                    else
                    {

                        objTemp = new CellLocationBiz(objDr);
                        intMaxX = (objTemp.X + objTemp.Width) > (objBiz.X + objBiz.Width) ? (objTemp.X + objTemp.Width) : objBiz.X + objBiz.Width;
                        intMaxY = (objTemp.Y + objTemp.Height) > (objBiz.Y + objBiz.Height) ? (objTemp.Y + objTemp.Height) : objBiz.Y + objBiz.Height;
                        if (objTemp.X < objBiz.X)
                            objBiz.X = objTemp.X;
                        if (objTemp.Y < objBiz.Y)
                            objBiz.Y = objTemp.Y;
                        objBiz.Width = intMaxX - objBiz.X;
                        objBiz.Height = intMaxY - objBiz.Y;

                    }


                }
                return _FreeLocationCol;
            }
        }
        public LocationCol SoldCellLocationCol
        {
            get
            {
                _FreeLocationCol = new LocationCol(true);
                DataRow[] arrDr = UnitLocationTable.Select("", "Location");
                string strLocation = "";
                string strLocations = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (objDr["Location"].ToString() != strLocation)
                    {
                        strLocation = objDr["Location"].ToString();
                        if (strLocations != "")
                            strLocations += ",";
                        strLocations += strLocation;
                    }
                }
                string strSelect = "";
                if (strLocations != "")
                    strSelect = "LocationID in (" + strLocations + ")";
                arrDr = CellLocationTable.Select(strSelect, "LocationCell");
                string strLocationCell = "";
                CellLocationBiz objBiz, objTemp;
                int intMaxX, intMaxY;
                objBiz = new CellLocationBiz();
                string strCellIDs = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (strLocationCell != objDr["LocationCell"].ToString())
                    {
                        strLocationCell = objDr["LocationCell"].ToString();
                        if (strCellIDs != "")
                            strCellIDs += ",";
                        strCellIDs += strLocationCell;
                    }

                }
                strSelect = "";
                if (strCellIDs != "")
                    strSelect = "LocationCell not in (" + strCellIDs + ")";
                arrDr = CellLocationTable.Select(strSelect, "LocationCell");
                foreach (DataRow objDr in arrDr)
                {
                    if (strLocationCell != objDr["LocationCell"].ToString())
                    {
                        strLocationCell = objDr["LocationCell"].ToString();
                        objBiz = new CellLocationBiz(objDr);
                        _FreeLocationCol.Add(objBiz);
                    }
                    else
                    {

                        objTemp = new CellLocationBiz(objDr);
                        intMaxX = (objTemp.X + objTemp.Width) > (objBiz.X + objBiz.Width) ? (objTemp.X + objTemp.Width) : objBiz.X + objBiz.Width;
                        intMaxY = (objTemp.Y + objTemp.Height) > (objBiz.Y + objBiz.Height) ? (objTemp.Y + objTemp.Height) : objBiz.Y + objBiz.Height;
                        if (objTemp.X < objBiz.X)
                            objBiz.X = objTemp.X;
                        if (objTemp.Y < objBiz.Y)
                            objBiz.Y = objTemp.Y;
                        objBiz.Width = intMaxX - objBiz.X;
                        objBiz.Height = intMaxY - objBiz.Y;

                    }


                }
                return _FreeLocationCol;
            }
        }
        public LocationCol SoldLocationCol
        {
            get
            {
                _SoldLocationCol = new LocationCol(true);
                DataRow[] arrDr = UnitLocationTable.Select("", "Location");
                string strLocation = "";
                string strLocations = "";
                foreach (DataRow objDr in arrDr)
                {
                    if (objDr["Location"].ToString() != strLocation)
                    {
                        strLocation = objDr["Location"].ToString();
                        if (strLocations != "")
                            strLocations += ",";
                        strLocations += strLocation;
                    }
                }
                string strSelect = "";
                if (strLocations != "")
                    strSelect = "LocationID not in (" + strLocations + ")";
                arrDr = CellLocationTable.Select(strSelect);
                foreach (DataRow objDr in arrDr)
                {
                    _SoldLocationCol.Add(new CellLocationBiz(objDr));
                }
                return _SoldLocationCol;
            }
        }
        public LayoutLocationCol LayoutLocationCol
        {
            get
            {
                LayoutLocationCol Returned = new LayoutLocationCol(true);
                LayoutLocationBiz objTemp;
                foreach (DataRow objDr in LayoutLocationTable.Rows)
                {
                    objTemp = new LayoutLocationBiz(objDr);
                    objTemp.LayoutBiz = this;
                    Returned.Add(objTemp);

                }
                return Returned;
            }
        }
        public SideViewLocationCol SideViewLocationCol
        {
            get
            {
                SideViewLocationCol Returned = new SideViewLocationCol(true);
                foreach (DataRow objDr in SideViewLocationTable.Rows)
                {
                    Returned.Add(new SideViewLocationBiz(objDr));
                }
                return Returned;
            }
        }
        TowerLocationCol _TowerLocationCol;
        public TowerLocationCol TowerLocationCol
        {
            get
            {
                if (_TowerLocationCol == null)
                {
                    _TowerLocationCol = new TowerLocationCol(true);
                    TowerLocationDb objDb = new TowerLocationDb();
                    objDb.ImageID = ID;
                    DataTable dtTemp = objDb.Search();
                    TowerLocationBiz objBiz;
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objBiz = new TowerLocationBiz(objDr);
                        _TowerLocationCol.Add(objBiz);
                    }
                }
                return _TowerLocationCol;
            }
        }
        public ImageBiz Logo
        {
            set
            {
                _Logo = value;

            }
            get
            {
                if (_Logo == null)
                {
                    if (ID != 0)
                    {
                        if (((LayoutDb)_ImageDb).Logo == 0)
                            _Logo = new ImageBiz(8);
                        else
                            _Logo = new ImageBiz(((LayoutDb)_ImageDb).Logo);
                    }
                }
                return _Logo;
            }
        }
        public CellBiz ProjectBiz
        {
            set
            {
                _ProjectBiz = value;
            }
            get
            {
                return _ProjectBiz;
            }
        }
        public LayoutType Type
        {
            set
            {
                ((LayoutDb)_ImageDb).Type = (byte)value;
            }
            get
            {
                return (LayoutType)((LayoutDb)_ImageDb).Type;
            }
        }
        #endregion
        #region Private Methods
        string GetFreeUnitLocationStr()
        {
            DataRow[] arrDr = UnitLocationTable.Select("", "Location");
            string Returned = "";
            string strLocation = "";
            foreach (DataRow objDr in arrDr)
            {
                if (objDr["Location"].ToString() != strLocation)
                {
                    strLocation = objDr["Location"].ToString();
                    if (Returned != "")
                        Returned += ",";
                    Returned += strLocation;
                }
            }
            return Returned;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            ((LayoutDb)_ImageDb).ProjectID = _ProjectBiz.ID;
            if (_Logo == null || _Logo.ID == 8)
                _Logo = new ImageBiz();
            ((LayoutDb)_ImageDb).Logo = _Logo.ID;
            if (((LayoutDb)_ImageDb).OldLayout)
                ((LayoutDb)_ImageDb).Edit();
            else
                ((LayoutDb)_ImageDb).Add();
        }
        public void Edit()
        {
            ((LayoutDb)_ImageDb).ProjectID = _ProjectBiz.ID;
            ((LayoutDb)_ImageDb).Logo = _Logo.ID;

            ((LayoutDb)_ImageDb).Edit();
        }
        public void Delete()
        {
            ((LayoutDb)_ImageDb).Delete();
        }
        public CellLocationCol GetCellLocation(CellBiz objCellBiz)
        {

            DataRow[] arrDr = CellLocationTable.Select("LocationCell=" + objCellBiz.ID);
            CellLocationBiz objBiz;
            CellLocationCol Returned = new CellLocationCol(true);
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new CellLocationBiz(objDr);
                objBiz.LayoutBiz = this;
                Returned.Add(objBiz);

            }
            return Returned;

        }
        public TowerLocationCol GetTowerLocationCol(TowerBiz objTowerBiz)
        {
            TowerLocationCol Returned = new TowerLocationCol(true);
            IEnumerable<TowerLocationBiz> objCol = from objBiz in TowerLocationCol.Cast<TowerLocationBiz>()
                                                   where objBiz.TowerBiz.ID == objTowerBiz.ID
                                                   select objBiz;
            foreach (TowerLocationBiz objBiz in objCol)
                Returned.Add(objBiz);
            return Returned;
        }
        /// <summary>
        /// here to get One Location Biz for cell
        /// </summary>
        /// <param name="objCellBiz"></param>
        /// <returns></returns>
        public CellLocationBiz GetCellLocationBiz(CellBiz objCellBiz)
        {
            DataRow[] arrDr = CellLocationTable.Select("LocationCell=" + objCellBiz.ID);
            CellLocationBiz objBiz;
            CellLocationBiz Returned = new CellLocationBiz();
            CellLocationBiz objTemp;
            if (arrDr.Length > 0)
            {
                Returned = new CellLocationBiz(arrDr[0]);
                int intMaxX = 0, intMaxY = 0;
                foreach (DataRow objDr in arrDr)
                {

                    objTemp = new CellLocationBiz(objDr);
                    intMaxX = (objTemp.X + objTemp.Width) > (Returned.X + Returned.Width) ? (objTemp.X + objTemp.Width) : Returned.X + Returned.Width;
                    intMaxY = (objTemp.Y + objTemp.Height) > (Returned.Y + Returned.Height) ? (objTemp.Y + objTemp.Height) : Returned.Y + Returned.Height;
                    if (objTemp.X < Returned.X)
                        Returned.X = objTemp.X;
                    if (objTemp.Y < Returned.Y)
                        Returned.Y = objTemp.Y;
                    Returned.Width = intMaxX - Returned.X;
                    Returned.Height = intMaxY - Returned.Y;






                }
            }
            return Returned;
        }

        public string[] GetUnitLocationArr(int intX, int intY)
        {
            //LocationX, LocationY, LocationWidth, LocationHeight
            string[] Returned = new string[0];
            DataRow[] arrDr = CellLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
                " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            string strLocationIDs = "";
            foreach (DataRow objDr in arrDr)
            {
                if (strLocationIDs != "")
                    strLocationIDs += ",";
                strLocationIDs += objDr["LocationID"].ToString();
            }
            if (strLocationIDs != "")
            {
                arrDr = UnitLocationTable.Select("LocationID in(" + strLocationIDs + ")");
                if (arrDr.Length > 0)
                {
                    Returned = new string[arrDr.Length];
                    int intIndex = 0;
                    UnitBiz objUnitBiz;
                    string strTemp = "";
                    foreach (DataRow objDr in arrDr)
                    {
                        objUnitBiz = new UnitBiz(objDr);
                        strTemp = objUnitBiz.FullName + " ãÓÇÍÉ   " + objUnitBiz.Survey;
                        if (objUnitBiz.ModelBiz.ID != 0)
                            strTemp += "  -  " + objUnitBiz.ModelBiz.Name;
                        Returned[intIndex] = strTemp;

                        intIndex++;
                    }
                }

            }

            return Returned;

        }
        public CellLocationCol GetFreeLocationCol(LocationBiz objLoc)
        {
            CellLocationCol Returned = new CellLocationCol(true);


            string strLocations = GetFreeUnitLocationStr();
            string strSelect = "";
            if (strLocations != "")
                strSelect = "LocationID in (" + strLocations + ")";
            if (strSelect != "")
                strSelect += " and ";
            //{(x,y),(x+width,y),(x,y+height),(x+width,y+height)}
            // intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
            //     " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight "
            string strInnerWhere = "";
            int intX = 0, intY = 0, intHeight = 0, intWidth = 0;
            //1- (x,y)
            intX = objLoc.X;
            intY = objLoc.Y;
            intHeight = objLoc.Height;
            intWidth = objLoc.Width;
            if (strInnerWhere != "")
                strInnerWhere += " or ";
            strInnerWhere += "(" + intX.ToString() + "<= LocationX and " + (intX + intWidth).ToString() + ">=LocationX " +
                   " and " + intY.ToString() + " <= LocationY and " + (intY + intHeight).ToString() + " >= LocationY " + ")";
            //2- (x+width,y)

            if (strInnerWhere != "")
                strInnerWhere += " or ";
            strInnerWhere += "(" + intX.ToString() + "<= LocationX+LocationWidth and " + (intX + intWidth).ToString() + ">=LocationX+LocationWidth " +
                    " and " + intY.ToString() + " <= LocationY and " + (intY + intHeight).ToString() + " >= LocationY " + ")";
            //3- (x,y+height)

            if (strInnerWhere != "")
                strInnerWhere += " or ";
            strInnerWhere += "(" + intX.ToString() + "<= LocationX and " + (intX + intWidth).ToString() + ">=LocationX " +
                    " and " + intY.ToString() + " <= LocationY+LocationHeight and " + (intY + intHeight).ToString() + " >= LocationY+LocationHeight " + ")";
            //4- (x+width,y+height)

            if (strInnerWhere != "")
                strInnerWhere += " or ";
            strInnerWhere += "(" + intX.ToString() + "<= LocationX+LocationWidth and " + (intX + intWidth).ToString() + ">=LocationX+LocationWidth " +
                    " and " + intY.ToString() + " <= LocationY+LocationHeight and " + (intY + intHeight).ToString() + " >= LocationY+LocationHeight " + ")";

            strSelect += " (" + strInnerWhere + ")";
            DataRow[] arrDr = CellLocationTable.Select(strSelect);
            foreach (DataRow objDr in arrDr)
            {
                Returned.Add(new CellLocationBiz(objDr));
            }
            return Returned;
        }
        public CellLocationCol GetFreeLocationCol(CellBiz objCellBiz)
        {
            CellLocationCol Returned = new CellLocationCol(true);


            string strLocations = GetFreeUnitLocationStr();
            string strSelect = "";
            if (strLocations != "")
                strSelect = "LocationID in (" + strLocations + ") and ";
            strSelect += " LocationCell = " + objCellBiz.ID.ToString();
            DataRow[] arrDr = CellLocationTable.Select(strSelect);
            foreach (DataRow objDr in arrDr)
            {
                Returned.Add(new CellLocationBiz(objDr));
            }
            return Returned;
        }
        public CellLocationCol GetLocationCol(CellBiz objCellBiz)
        {
            CellLocationCol Returned = new CellLocationCol(true);


            //  string strLocations = GetFreeUnitLocationStr();
            string strSelect = "";
            //if (strLocations != "")
            //    strSelect = "LocationID in (" + strLocations + ") and ";
            strSelect += " LocationCell = " + objCellBiz.ID.ToString();
            DataRow[] arrDr = CellLocationTable.Select(strSelect);
            foreach (DataRow objDr in arrDr)
            {
                Returned.Add(new CellLocationBiz(objDr));
            }
            return Returned;
        }
        public UnitCol GetLocationUnitCol(int intX, int intY)
        {
            //LocationX, LocationY, LocationWidth, LocationHeight
            UnitCol Returned = new UnitCol(true);
            DataRow[] arrDr = CellLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
                " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            string strLocationIDs = "";
            foreach (DataRow objDr in arrDr)
            {
                if (strLocationIDs != "")
                    strLocationIDs += ",";
                strLocationIDs += objDr["LocationID"].ToString();
            }
            if (strLocationIDs != "")
            {
                arrDr = UnitLocationTable.Select("LocationID in(" + strLocationIDs + ")");
                if (arrDr.Length > 0)
                {

                    //int intIndex = 0;
                    UnitBiz objUnitBiz;
                    // string strTemp = "";
                    foreach (DataRow objDr in arrDr)
                    {
                        objUnitBiz = new UnitBiz(objDr);

                        Returned.Add(objUnitBiz);
                    }
                }

            }

            return Returned;

        }
        public LayoutBiz GetChildLayout(int intX, int intY)
        {
            LayoutBiz Returned = new LayoutBiz();
            DataRow[] arrDr = LayoutLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
                " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            if (arrDr.Length > 0)
            {
                Returned = new LayoutBiz(arrDr[0]);
            }

            return Returned;

        }
        public LayoutLocationBiz GetLayoutLocation(int intX, int intY)
        {
            LayoutLocationBiz Returned = new LayoutLocationBiz();
            DataRow[] arrDr = LayoutLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
                " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            if (arrDr.Length > 0)
            {
                Returned = new LayoutLocationBiz(arrDr[0]);
            }

            return Returned;

        }
        public CellLocationBiz GetCellLocation(int intX, int intY)
        {
            CellLocationBiz Returned = new CellLocationBiz();
            DataRow[] arrDr = CellLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
               " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            if (arrDr.Length > 0)
                Returned = new CellLocationBiz(arrDr[0]);
            return Returned;
        }

        public SideViewLocationBiz GetSideViewLocation(int intX, int intY)
        {
            SideViewLocationBiz Returned = new SideViewLocationBiz();
            DataRow[] arrDr = SideViewLocationTable.Select(intX.ToString() + ">= LocationX and " + intX.ToString() + "<=LocationX+LocationWidth " +
               " and " + intY.ToString() + " >= LocationY and " + intY.ToString() + " <= LocationY+LocationHeight ");
            if (arrDr.Length > 0)
                Returned = new SideViewLocationBiz(arrDr[0]);
            return Returned;
        }
        public UnitCol GetLocationUnitCol(LocationBiz objLocBiz, SideViewLocationBiz objSideLocationBiz)
        {
            UnitCol Returned = new UnitCol(true);
            DataRow[] arrDr = UnitLocationTable.Select("LocationID=" + objLocBiz.ID + " and CellOrder=" + objSideLocationBiz.Order);
            foreach (DataRow objDr in arrDr)
            {
                Returned.Add(new UnitBiz(objDr));
            }
            return Returned;
        }
        public UnitCol GetLocationUnitCol(LocationBiz objLocBiz)
        {
            UnitCol Returned = new UnitCol(true);
            DataRow[] arrDr = UnitLocationTable.Select("LocationID=" + objLocBiz.ID, "CellOrder");
            foreach (DataRow objDr in arrDr)
            {
                Returned.Add(new UnitBiz(objDr));
            }
            return Returned;
        }
        public void ResetLayout()
        {
            if (CellLocationTable.Rows.Count == 0)
                return;
            DataTable dtTemp = null;
            try
            {
                UnitLocationDb objDb = new UnitLocationDb();
                objDb.ImageID = ID;
                dtTemp = objDb.Search();

            }
            catch
            {
            }
            if (dtTemp != null)
                _UnitLocationTable = dtTemp;

        }
        #endregion
    }
}
