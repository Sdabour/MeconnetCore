using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;

using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class FloorBiz :BaseSingleBiz
    {

        #region Constructor
        public FloorBiz()
        {
            _BaseDb = new FloorDb();
        }
        public FloorBiz(int intID)
        {
            int intValue = intID + 96 - 1;
            UnitFloorBiz objUnitFloorBiz = new UnitFloorBiz(intValue);
            NameA = objUnitFloorBiz.Name;
            Code = objUnitFloorBiz.Code;
            Value = objUnitFloorBiz.Value;
            ID = intID;

        }
        public FloorBiz(DataRow objDr)
        {
            
            _BaseDb = new FloorDb(objDr);
        }

        #endregion
        #region Private Data
       // FloorDb ((FloorDb)_BaseDb);
        #endregion
        #region Properties
       
        public int Value
        {
            set
            {
                ((FloorDb)_BaseDb).Value = value;
            }
            get
            {
                return ((FloorDb)_BaseDb).Value;
            }
        }
        static FloorCol _FloorCol;
        UnitCol _UnitCol;
        public UnitCol UnitCol
        {
            set
            {
                _UnitCol = value;
            }
            get
            {
                if (_UnitCol == null)
                {
                    _UnitCol = new UnitCol(true);
                }
                return _UnitCol;
            }
        }
        Hashtable _UnitHs;
        public Hashtable UnitHs
        {
            set
            {
                _UnitHs = value;
            }
            get
            {
                if (_UnitHs == null)
                    _UnitHs = new Hashtable();
                return _UnitHs;
            }

        }
      public static FloorCol FloorCol
        {
            set
            {
                _FloorCol = value;
            }
            get
            {
                if (_FloorCol == null)
                {
                    _FloorCol = new FloorCol(false);

                }
                return _FloorCol;
            }

        }

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            ((FloorDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((FloorDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((FloorDb)_BaseDb).Delete();
        }
        public void AddUnit(UnitBiz objUnitBiz)
        {
            if (UnitHs[objUnitBiz.Code] == null)
            {
                UnitHs.Add(objUnitBiz.Code, objUnitBiz);
            }
            if (_UnitCol == null)
                _UnitCol = new UnitCol(true);
            _UnitCol.Add(objUnitBiz);
        }
        #endregion
    }
}
