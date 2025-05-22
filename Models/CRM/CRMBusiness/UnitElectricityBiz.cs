using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitElectricityBiz
    {
        #region Private Data
        UnitElectricityDb _ElectricityDb;
        UnitBiz _UnitBiz;
        CellBiz _CellBiz;
        #endregion
        #region Constructors
        public UnitElectricityBiz()
        {
            _ElectricityDb = new UnitElectricityDb();
        }
        public UnitElectricityBiz(DataRow objDr)
        {
            _ElectricityDb = new UnitElectricityDb(objDr);
            if (_ElectricityDb.UnitID != 0)
            {
                _UnitBiz = new UnitBiz();
                _UnitBiz.ID = _ElectricityDb.UnitID;
                _UnitBiz.ReservationID = _ElectricityDb.UnitReservationID;
                _UnitBiz.CustomerStr = _ElectricityDb.CustomerName;
                //FloorBiz objCellBiz = new FloorBiz(_ElectricityDb.UnitCellID);
                //UnitCellBiz objTempCell = new UnitCellBiz();
                //objTempCell.CellBiz = objCellBiz;
                //objTempCell.UnitBiz = _UnitBiz;
                //_UnitBiz.CellCol = new UnitCellCol(true);
                //_UnitBiz.CellCol.Add(objTempCell);
                _UnitBiz.MinCellID = _ElectricityDb.UnitCellID;
                _UnitBiz.FullName = _ElectricityDb.UnitCode;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ElectricityDb.ID = value;
            }
            get
            {
                return _ElectricityDb.ID;
            }
        }
        public bool HasElectricityMeter
        {
            set
            {
                _ElectricityDb.HasElectricityMeter = value;
            }
            get
            {
                return _ElectricityDb.HasElectricityMeter;
            }
        }
        public bool ElectricityMeterHasStartDate
        {
            set
            {
                _ElectricityDb.ElectricityMeterHasStartDate = value;
            }
            get
            {
                return _ElectricityDb.ElectricityMeterHasStartDate;
            }
        }
        public DateTime ElectricityMeterStartDate
        {
            set
            {
                _ElectricityDb.ElectricityMeterStartDate = value;
            }
            get
            {
                return _ElectricityDb.ElectricityMeterStartDate;
            }
        }
        public string ElectricityMeterOwner
        {
            set
            {
                _ElectricityDb.ElectricityMeterOwner = value;
            }
            get
            {
                return _ElectricityDb.ElectricityMeterOwner;
            }
        }
        public MeterStatus ElectricityMeterStatus
        {
            set
            {
                _ElectricityDb.ElectricityMeterStatus = (int)value;
            }
            get
            {
                return (MeterStatus) _ElectricityDb.ElectricityMeterStatus;
            }
        }
        public MeterIllegalAction ElectricityMeterIllegalAction
        {
            set
            {
                _ElectricityDb.ElectricityMeterIllegalAction = (int)value;
            }
            get
            {
                return (MeterIllegalAction)_ElectricityDb.ElectricityMeterIllegalAction;
            }
        }
        public string ElecticityMeterNotes
        {
            set
            {
                _ElectricityDb.ElecticityMeterNotes = value;
            }
            get
            {
                return _ElectricityDb.ElecticityMeterNotes;
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
                    _CellBiz = new CellBiz(_ElectricityDb.CellID);
                return _CellBiz;
            }
        }
        public double Power
        {
            set
            {
                _ElectricityDb.Power = value;
            }
            get
            {
                return _ElectricityDb.Power;
            }
        }
        public string UnitDesc
        {
            set
            {
                _ElectricityDb.UnitDesc = value;
            }
            get
            {
                return _ElectricityDb.UnitDesc;
            }
        }
        public string PreMeterNo
        {
            set
            {
                _ElectricityDb.PreMeterNo = value;
            }
            get
            {
                return _ElectricityDb.PreMeterNo;
            }
        }
        public string MeterNo
        {
            set
            {
                _ElectricityDb.MeterNo = value;
            }
            get
            {
                return _ElectricityDb.MeterNo;
            }
        }
        public UnitBiz UnitBiz
        {
            set
            {
                _UnitBiz = value;
            }
            get
            {
                if (_UnitBiz == null)
                    _UnitBiz = new UnitBiz();
                return _UnitBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
