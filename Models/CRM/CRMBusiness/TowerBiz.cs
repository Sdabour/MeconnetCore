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
//using SharpVision.CRM.CRMWeb;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class TowerBiz
    {
        #region Private Data
        TowerDb _TowerDb;
        TowerTypeBiz _TypeBiz;
        TowerUsageTypeBiz _UsageTypeBiz;
        CellBiz _CellBiz;
        ProjectBiz _ProjectBiz;
        FloorCol _FloorCol;
        Hashtable _UnitCodeHash = new Hashtable();

        #endregion
        #region Constructors
        public TowerBiz()
        {
            _TowerDb = new TowerDb();
        }
        public TowerBiz(DataRow objDr)
        {
            _TowerDb = new TowerDb(objDr);
            _ProjectBiz = new ProjectBiz(objDr);
            _TypeBiz = new TowerTypeBiz();
            if (_TowerDb.BulidingType != 0)
            {
                _TypeBiz.ID = _TowerDb.BulidingType;
                _TypeBiz.Code = _TowerDb.BuildingTypeCode;
                _TypeBiz.NameA = _TowerDb.BuildingTypeNameA;
                _TypeBiz.NameE = _TowerDb.BuildingTypeNameE;
            }
            _UsageTypeBiz = new TowerUsageTypeBiz();
            if (_TowerDb.UsageType != 0)
            {
                _UsageTypeBiz.ID = _TowerDb.UsageType;
                _UsageTypeBiz.Code = _TowerDb.UsageTypeCode;
                _UsageTypeBiz.NameA = _TowerDb.UsageTypeNameA;
                _UsageTypeBiz.NameE = _TowerDb.UsageTypeNameE;
            }


        }

        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _TowerDb.ID = value;
            }
            get
            {
                return _TowerDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _TowerDb.Code = value;
            }
            get
            {
                return _TowerDb.Code == null ? "" : _TowerDb.Code;
            }
        }
        public ProjectBiz ProjectBiz
        {
            set
            {
                _ProjectBiz = value;
            }
            get
            {
                if (_ProjectBiz == null)
                    _ProjectBiz = new ProjectBiz();
                return _ProjectBiz;
            }
        }
        public int Project
        {
            get { return _TowerDb.Project; }
            set { _TowerDb.Project = value; }
        }
        public int Order
        {
            get { return _TowerDb.Order; }
            set { _TowerDb.Order = value; }
        }
        public int CellID
        {
            get { return _TowerDb.CellID; }
            set { _TowerDb.CellID = value; }
        }
        public string Name
        {
            get
            {

                return _TowerDb.Name == null ? "" : _TowerDb.Name;
            }
            set { _TowerDb.Name = value; }
        }
        public int ParkingNo
        {
            get { return _TowerDb.ParkingNo; }
            set { _TowerDb.ParkingNo = value; }
        }
        public int BasementNo
        {
            get { return _TowerDb.BasementNo; }
            set { _TowerDb.BasementNo = value; }
        }
        public int GroundNo
        {
            get { return _TowerDb.GroundNo; }
            set { _TowerDb.GroundNo = value; }
        }
        public int FloorNo
        {
            get { return _TowerDb.FloorNo; }
            set { _TowerDb.FloorNo = value; }
        }
        public TowerTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new TowerTypeBiz();
                return _TypeBiz;
            }
        }
        //public int BulidingType
        //{
        //    get { return _TowerDb.BulidingType; }
        //    set { _TowerDb.BulidingType = value; }
        //}
        public TowerUsageTypeBiz UsageTypeBiz
        {
            set
            {
                _UsageTypeBiz = value;
            }
            get
            {
                if (_UsageTypeBiz == null)
                    _UsageTypeBiz = new TowerUsageTypeBiz();
                return _UsageTypeBiz;
            }
        }
        public CellBiz CellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                if (_CellBiz == null)
                    _CellBiz = new CellBiz(_TowerDb.CellID);
                return _CellBiz;
            }
        }
        public DateTime ReadyForOccupancyDate
        {
            get { return _TowerDb.ReadyForOccupancyDate; }
            set { _TowerDb.ReadyForOccupancyDate = value; }
        }
        public DateTime ReadyForOccupancyExpectedDate
        {
            get { return _TowerDb.ReadyForOccupancyExpectedDate; }
            set { _TowerDb.ReadyForOccupancyExpectedDate = value; }
        }
        public DateTime EndReservationDate
        {
            get { return _TowerDb.EndReservationDate; }
            set { _TowerDb.EndReservationDate = value; }
        }
        public DateTime StartReservationDate
        {
            get { return _TowerDb.StartReservationDate; }
            set { _TowerDb.StartReservationDate = value; }
        }
        public bool StartReservationDateDecided
        {
            get { return _TowerDb.StartReservationDateDecided; }
            set { _TowerDb.StartReservationDateDecided = value; }
        }
        public bool EndReservationDateDecided
        {
            get { return _TowerDb.EndReservationDateDecided; }
            set { _TowerDb.EndReservationDateDecided = value; }
        }
        public bool ReadyForOccupancyExpectedDateDecided
        {
            get { return _TowerDb.ReadyForOccupancyExpectedDateDecided; }
            set { _TowerDb.ReadyForOccupancyExpectedDateDecided = value; }
        }
        public bool ReadyForOccupancyDateDecided
        {
            get { return _TowerDb.ReadyForOccupancyDateDecided; }
            set { _TowerDb.ReadyForOccupancyDateDecided = value; }
        }
        public string HouseNo
        {
            get { return _TowerDb.HouseNo; }
            set { _TowerDb.HouseNo = value; }
        }
        public string CodePattern
        {
            get { return _TowerDb.CodePattern; }
            set { _TowerDb.CodePattern = value; }
        }
        public string ProjectName
        {
            get { return _ProjectBiz.Name; }
        }
        public string Street
        {
            get { return _TowerDb.Street; }
            set { _TowerDb.Street = value; }
        }
        public bool IsDelivered
        {
            get { return _TowerDb.IsDelivered; }
            set { _TowerDb.IsDelivered = value; }
        }
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
                    if (ID != 0)
                    {
                        UnitDb objDb = new UnitDb();
                        objDb.TowerIDs = ID.ToString();
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "UnitFloor,UnitOrder");
                        UnitBiz objUnitBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objUnitBiz = new UnitBiz(objDr);
                            _UnitCol.Add(objUnitBiz);
                        }

                    }

                }
                return _UnitCol;
            }
        }
        public FloorCol FloorCol
        {
            get
            {

                if (_FloorCol == null)
                {
                    _FloorCol = new FloorCol(true);
                    if (ID != 0)
                    {
                        UnitDb objUnitDb = new UnitDb();
                        objUnitDb.Tower = ID;
                        DataTable dtTemp = objUnitDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "TowerOrder,TowerID,UnitFloor,UnitOrder");
                        UnitBiz objUnitBiz;
                        FloorBiz objFloorBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objUnitBiz = new UnitBiz(objDr);
                            objFloorBiz = objUnitBiz.FloorBiz;
                            if (_FloorCol[objFloorBiz.ID.ToString()].ID != 0)
                                objFloorBiz = _FloorCol[objFloorBiz.ID.ToString()];
                            else
                                _FloorCol.Add(objFloorBiz);
                            objFloorBiz.UnitCol.Add(objUnitBiz);

                        }
                        UnitCol objUnitCol = _FloorCol.UnitCol;
                        objUnitCol.SetPeripheralCol();

                    }

                }
                return _FloorCol;
            }
            set { _FloorCol = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _TowerDb.BulidingType = TypeBiz.ID;
            _TowerDb.UsageType = UsageTypeBiz.ID;
            _TowerDb.Project = ProjectBiz.ID;
            _TowerDb.CellID = CellBiz.ID;
            _TowerDb.Add();
        }
        public void Edit()
        {
            _TowerDb.BulidingType = TypeBiz.ID;
            _TowerDb.UsageType = UsageTypeBiz.ID;
            _TowerDb.Project = ProjectBiz.ID;
            _TowerDb.CellID = CellBiz.ID;
            _TowerDb.Edit();
        }
        public void FillUnitFloorCol(string strFormat, double dblSurvey, int intUnitCount, UnitUsageTypeBiz objUsageTypeBiz,
            UnitMainTypeBiz objMainTypeBiz, UnitFloorBiz objFloorBiz, UnitFloorBiz objFloorToBiz, UnitModelBiz objModelBiz)
        {
            FloorBiz objTempFloor = new FloorBiz();
            UnitBiz objTempUnitBiz;
            for (int intIndex = objFloorBiz.Value; intIndex <= objFloorToBiz.Value; intIndex++)
            {
                objTempFloor = FloorCol[intIndex.ToString()];
                if (objTempFloor.Value == 0)
                {
                    objTempFloor = new FloorBiz(intIndex);
                    FloorCol.Add(objTempFloor);
                }
                for (int intIndex1 = 1; intIndex1 <= intUnitCount; intIndex1++)
                {
                    objTempUnitBiz = new UnitBiz();

                    objTempUnitBiz.Code = UnitBiz.GetUnitCode(strFormat, this, objTempFloor, intIndex1);
                    if (objTempFloor.UnitHs[objTempUnitBiz.Code] == null)
                    {
                        objTempUnitBiz.FullName = objTempUnitBiz.Code;
                        objTempUnitBiz.NameA = objTempUnitBiz.Code;
                        objTempUnitBiz.TowerBiz = this;
                        objTempUnitBiz.FloorBiz = objTempFloor;

                        objTempUnitBiz.UsageTypeBiz = objUsageTypeBiz;
                        objTempUnitBiz.MainTypeBiz = objMainTypeBiz;
                        objTempUnitBiz.ModelBiz = objModelBiz;
                        objTempUnitBiz.Survey = dblSurvey;
                        objTempUnitBiz.Order = intIndex1;


                        objTempFloor.AddUnit(objTempUnitBiz);
                    }

                }


            }
            FloorCol.ReorderFloorCol();
        }
        #endregion
    }
}
