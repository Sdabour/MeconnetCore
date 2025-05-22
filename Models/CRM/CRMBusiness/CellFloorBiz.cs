using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
//using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class CellFloorBiz : CellBiz
    {
        #region Private Data
        public CellFloorBiz(DataRow objDr)
            : base(objDr)
        { 
        }
        public CellFloorBiz(int intFloorID) : base(intFloorID)
        {
 
        }
        #endregion
        #region Constructors
        public CellFloorBiz()
        { }
        #endregion
        #region Public Properties
        public UnitCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                    
                    _Children = new UnitCol(true);
                    if (ID != 0)
                    {
                        UnitDb objDb = new UnitDb();
                        objDb.CellID = ID;
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "ProjectID,CellTowerID,MaxCellOrder,UnitOrder");
                        foreach (DataRow objDr in arrDr)
                        {
                            _Children.Add(new UnitBiz(objDr));
                        }
                    }

                }
                return (UnitCol)_Children;
            }
        }
        static string _FloorTypeStr = "7,24,35,39,41,47,50,54,55,57";
        static Hashtable _FloorTypeHs;
        public static Hashtable FloorTypeHs
        {
            get
            {
                if (_FloorTypeHs == null)
                {
                    _FloorTypeHs = new Hashtable();
                    int intTemp = 0;
                    string[] arrStr = _FloorTypeStr.Split(",".ToCharArray());
                    foreach (string strTemp in arrStr)
                    {
                        if (int.TryParse(strTemp, out intTemp) && _FloorTypeHs[intTemp.ToString()] == null)
                        {
                            _FloorTypeHs.Add(intTemp.ToString(), intTemp);
                        }
                    }
                }
                return _FloorTypeHs;
            }
        }
        static Hashtable _RelatedTypeHs;

        public static Hashtable RelatedTypeHs
        {
            get {
                if (_RelatedTypeHs == null)
                {

                    _RelatedTypeHs = new Hashtable();
                    _RelatedTypeHs.Add("7", FloorTypeHs);
                }

                return CellFloorBiz._RelatedTypeHs; }
            set { CellFloorBiz._RelatedTypeHs = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
