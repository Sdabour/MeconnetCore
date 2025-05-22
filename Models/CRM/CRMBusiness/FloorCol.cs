using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.CRM.CRMDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class FloorCol : CollectionBase
    {
        static FloorCol _CacheFloorCol;
        public static FloorCol CacheFloorCol
        {
            get
            {
                if(_CacheFloorCol== null)
                {
                    _CacheFloorCol = new FloorCol(false);
                }
                return _CacheFloorCol;
            }
        }
        #region Constructor
        public FloorCol()
        {

        }
        public FloorCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            FloorBiz objBiz = new FloorBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            FloorDb objDb = new FloorDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new FloorBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data
        Hashtable _FloorHash = new Hashtable();

        #endregion
        #region Properties
        public FloorBiz this[int intIndex]
        {
            get
            {
                return (FloorBiz)this.List[intIndex];
            }
        }
        public FloorBiz this[string strID]
        {
            get
            {
                FloorBiz Returned = new FloorBiz();
                if ( strID!= null && _FloorHash[strID] != null )
                    Returned = (FloorBiz)_FloorHash[strID];
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (FloorBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        UnitCol _UnitCol;
        public UnitCol UnitCol
        {
            get
            {
                if (_UnitCol == null)
                    _UnitCol = new UnitCol(true);
                foreach (FloorBiz objBiz in this)
                {
                    foreach (UnitBiz objUnitBiz in objBiz.UnitCol)
                        _UnitCol.Add(objUnitBiz);
                }
                return _UnitCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(FloorBiz objBiz)
        {
            List.Add(objBiz);
            if (_FloorHash[objBiz.ID.ToString()] == null)
                _FloorHash.Add(objBiz.ID.ToString(), objBiz);
        }
        public FloorCol GetCol(string strTemp)
        {
            FloorCol Returned = new FloorCol(true);
            foreach (FloorBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("FloorID"), new DataColumn("FloorValue"), new DataColumn("FloorCode"), new DataColumn("FloorNameA"), new DataColumn("FloorNameE") });
            DataRow objDr;
            foreach (FloorBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["FloorID"] = objBiz.ID;
                objDr["FloorValue"] = objBiz.Value;
                objDr["FloorCode"] = objBiz.Code;
                objDr["FloorNameA"] = objBiz.NameA;
                objDr["FloorNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void ReorderFloorCol()
        {

        }

        #endregion
    }
}
