using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
//using SharpVision.RP.RPDataBase;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitElectricityDb
    {
        #region Private Data
        int _ID;
        bool _HasElectricityMeter;
        DateTime _ElectricityMeterStartDate;
        bool _ElectricityMeterHasStartDate;
        string _ElectricityMeterOwner;
        int _ElectricityMeterStatus;
        int _ElectricityMeterIllegalAction;
        string _ElecticityMeterNotes;
        double _Power;
        int _UnitID;
        int _CellID;
        string _UnitDesc;
        string _UnitCode;

        string _PreMeterNo;
        string _MeterNo;
        DataTable _ElectricityTable;
        #region Private Data for Search
        string _CellIDs = "";
        int _CellFamily;
        int _CustomerID;
        int _ElementUnitType;/*
                              * 0 dont care
                              * 1 unit
                              * 2 tower
                              */
        int _UnitType;
        int _Floor;
        string _CustomerName;
        int _UnitCellID;
        int _UnitReservationID;
        #endregion
        #endregion
        #region Constructors
        public UnitElectricityDb()
        { }
        public UnitElectricityDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public bool HasElectricityMeter
        {
            set
            {
                _HasElectricityMeter = value;
            }
            get
            {
                return _HasElectricityMeter;
            }
        }
        public bool ElectricityMeterHasStartDate
        {
            set
            {
                _ElectricityMeterHasStartDate = value;
            }
            get
            {
                return _ElectricityMeterHasStartDate;
            }
        }
        public DateTime ElectricityMeterStartDate
        {
            set
            {
                _ElectricityMeterStartDate = value;
            }
            get
            {
                return _ElectricityMeterStartDate;
            }
        }
        public string ElectricityMeterOwner
        {
            set
            {
                _ElectricityMeterOwner = value;
            }
            get
            {
                return _ElectricityMeterOwner;
            }
        }
        public int ElectricityMeterStatus
        {
            set
            {
                _ElectricityMeterStatus = value;
            }
            get
            {
                return _ElectricityMeterStatus;
            }
        }
        public int ElectricityMeterIllegalAction
        {
            set
            {
                _ElectricityMeterIllegalAction = value;
            }
            get
            {
                return _ElectricityMeterIllegalAction;
            }
        }
        public string ElecticityMeterNotes
        {
            set
            {
                _ElecticityMeterNotes = value;
            }
            get
            {
                return _ElecticityMeterNotes;
            }
        }
        public string PreMeterNo
        {
            set
            {
                _PreMeterNo = value;
            }
            get
            {
                return _PreMeterNo;
            }
        }
        public string MeterNo
        {
            set
            {
                _MeterNo = value;
            }
            get
            {
                return _MeterNo;
            }
        }
        public double Power
        {
            set
            {
                _Power = value;
            }
            get
            {
                return _Power;
            }
        }
        public int UnitID
        {
            set
            {
                _UnitID = value;
            }
            get
            {
                return _UnitID;
            }
        }
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public string UnitDesc
        {
            set
            {
                _UnitDesc = value;
            }
            get
            {
                return _UnitDesc;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int CellFamily
        {
            set
            {
                _CellFamily = value;
            }
        }
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
        }
        public int ElementUnitType
        {
            set
            {
                _ElementUnitType = value;
            }
        }
        public DataTable ElectricityTable
        {
            set
            {
                _ElectricityTable = value;
            }

        }
        public int UnitType
        {
            set
            {
                _UnitType = value;
            }
        }
        public int Floor
        {
            set
            {
                _Floor = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
            get 
            {
                return _UnitCode;
            }
        }
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
        }
        public int UnitCellID
        {
            get
            {
                return _UnitCellID;
            }
        }
        public int UnitReservationID
        {
            get
            {
                return _UnitReservationID;
            }
        }
        public string AddStr
        {
            get
            {
                int intHasElectricityMeter = _HasElectricityMeter ? 1 : 0;
                double dblStartDate = SysUtility.Approximate(_ElectricityMeterStartDate.ToOADate() - 2,
                    1, ApproximateType.Down);
                string Returned = "";
                if (_UnitID != 0 && _CellID == 0)
                    Returned += " delete from CRMUnitElectricity where UnitID="+ _UnitID;
                Returned+= " insert into CRMUnitElectricity " +
                    "( UnitHasElectricityMeter,UnitElectricityPreMeterNo,UnitElectricityMeterNo, UnitElectricityMeterStartDate, UnitElectricityMeterOwner" +
                    ", UnitElectricityMeterStatus,UnitElectricityMeterPower, UnitElectricityMeterIllegalAction  " +
                    ",UnitElecticityMeterNotes, UnitID  , CellID  , UnitDesc , UsrIns, TimIns) " +
                    " values (" + intHasElectricityMeter + ",'" + _PreMeterNo + "','" + _MeterNo + "'," + dblStartDate + ",'" + _ElectricityMeterOwner + "'," +
                    _ElectricityMeterStatus + "," + _Power + "," + _ElectricityMeterIllegalAction + ",'" + _ElecticityMeterNotes + "'," +
                    _UnitID + "," + _CellID + ",'" + _UnitDesc + "'," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intHasElectricityMeter = _HasElectricityMeter ? 1 : 0;
                double dblStartDate = SysUtility.Approximate(_ElectricityMeterStartDate.ToOADate() - 2,
                    1, ApproximateType.Down);
                string Returned = "update CRMUnitElectricity set UnitHasElectricityMeter=" + intHasElectricityMeter +
                    ",UnitElectricityPreMeterNo='" + _PreMeterNo + "' " +
                    ",UnitElectricityMeterNo='" + _MeterNo + "' " +
                    ", UnitElectricityMeterStartDate =" + dblStartDate +
                    ", UnitElectricityMeterOwner='" + _ElectricityMeterOwner + "'" +
                    ", UnitElectricityMeterStatus=" + _ElectricityMeterStatus +
                    ",UnitElectricityMeterPower=" + _Power +
                    ", UnitElectricityMeterIllegalAction = " + _ElectricityMeterIllegalAction +
                    ",UnitElecticityMeterNotes'" + _ElecticityMeterNotes + "'" +
                    ", UnitID =" + _UnitID +
                    " , CellID =" + _CellID +
                    " , UnitDesc ='" + _UnitDesc + "' " +
                    ",UsrUpd=" + SysData.CurrentUser.ID +
                    ",TimUpd=GetDate() " +
                    " where   UnitElementID=" + _ID +
                     "  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                UnitDb objUnitDb = new UnitDb();
                if(_CustomerID != 0)
                objUnitDb.CustomerIDs = _CustomerID.ToString();
            objUnitDb.UnitNameLike = _UnitCode;
            objUnitDb.CellFamilyID = _CellFamily;
            objUnitDb.CellIDs = _CellIDs;
            objUnitDb.FloorOrder = _Floor;
            objUnitDb.UnitType = _UnitType;
                string strUnit = objUnitDb.StrSearch;
                string strCell = "SELECT     CellID, CellFamilyID "+
                       " FROM   dbo.RPCell where (1=1) ";
                if (_CellIDs != null && _CellIDs != "")
                    strCell += " and CellID in ("+ _CellIDs +")";
                if (_CellFamily != 0)
                    strCell += " and CellFamilyID =" + _CellFamily;
                string Returned = "SELECT     dbo.CRMUnitElectricity.UnitElementID, dbo.CRMUnitElectricity.UnitHasElectricityMeter"+
                    ",dbo.CRMUnitElectricity.UnitElectricityPreMeterNo,dbo.CRMUnitElectricity.UnitElectricityMeterNo"+
                    ", dbo.CRMUnitElectricity.UnitElectricityMeterStartDate" +
                    ", dbo.CRMUnitElectricity.UnitElectricityMeterOwner, dbo.CRMUnitElectricity.UnitElectricityMeterStatus,UnitElectricityMeterPower"+
                    ", dbo.CRMUnitElectricity.UnitElectricityMeterIllegalAction" +
                     ", dbo.CRMUnitElectricity.UnitElecticityMeterNotes, dbo.CRMUnitElectricity.UnitID AS ElectricityUnitID"+
                     ", dbo.CRMUnitElectricity.CellID AS ElectricityCellID, dbo.CRMUnitElectricity.UnitDesc AS ElectricityUnitDesc " +
                     ",UnitTable.UnitID,UnitTable.UnitFullName ,UnitTable.MaxCellID ,UnitTable.CustomerFullName "+
                     ",UnitTable.CurrentReservationID,CellTable.CellID " +
                     " FROM  dbo.CRMUnitElectricity "+
                     " left outer join (" + strCell + ") as CellTable "+
                     " on dbo.CRMUnitElectricity.CellID = CellTable.CellID "+
                     " left outer join (" + strUnit + ") as UnitTable  "+
                     " on dbo.CRMUnitElectricity.UnitID = UnitTable.UnitID  "+
                     " where (1=1) ";
                if(_CellFamily != 0 || (_CellIDs!= null && _CellIDs!= ""))
                    Returned += " and (UnitTable.UnitID is not null or CellTable.CellID is not null) ";
                if (_CustomerID != 0 || (_UnitCode != null && _UnitCode != "") ||
                    _Floor != 0 || _UnitType != 0 || _ElementUnitType== 1)
                    Returned += " and (UnitTable.UnitID is not null) ";
                if (_ElementUnitType == 2)
                    Returned += " and (CellTable.CellID is not null ) ";
                if (_ElectricityMeterIllegalAction != 0)
                    Returned += " and dbo.CRMUnitElectricity.UnitElectricityMeterIllegalAction = "+_ElectricityMeterIllegalAction;
                if (_ElectricityMeterStatus != 0)
                    Returned += " and  dbo.CRMUnitElectricity.UnitElectricityMeterStatus="+_ElectricityMeterStatus;
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["UnitElementID"].ToString() != "")
                _ID = int.Parse(objDr["UnitElementID"].ToString());
            if (objDr["UnitHasElectricityMeter"].ToString() != "")
                _HasElectricityMeter = bool.Parse(objDr["UnitHasElectricityMeter"].ToString());
            if (objDr["UnitElectricityMeterStartDate"].ToString() != "")
            {
                _ElectricityMeterHasStartDate = true;
                _ElectricityMeterStartDate = DateTime.Parse(objDr["UnitElectricityMeterStartDate"].ToString());
            }
            _ElectricityMeterOwner = objDr["UnitElectricityMeterOwner"].ToString();
            if (objDr["UnitElectricityMeterStatus"].ToString() != "")
            {
                _ElectricityMeterStatus = int.Parse(objDr["UnitElectricityMeterStatus"].ToString());
            }
            if (objDr["UnitElectricityMeterIllegalAction"].ToString() != "")
            {
                _ElectricityMeterIllegalAction = int.Parse(objDr["UnitElectricityMeterIllegalAction"].ToString());
            }
            _ElecticityMeterNotes = objDr["UnitElecticityMeterNotes"].ToString();
            if (objDr.Table.Columns["UnitElectricityPreMeterNo"] != null &&
                objDr["UnitElectricityPreMeterNo"].ToString() != "")
                _PreMeterNo = objDr["UnitElectricityPreMeterNo"].ToString();

            if (objDr.Table.Columns["UnitElectricityMeterNo"] != null &&
               objDr["UnitElectricityMeterNo"].ToString() != "")
                _MeterNo = objDr["UnitElectricityMeterNo"].ToString();
            if (objDr.Table.Columns["UnitElectricityMeterPower"] != null &&
          objDr["UnitElectricityMeterPower"].ToString() != "")
                _Power = double.Parse(objDr["UnitElectricityMeterPower"].ToString());


            if (objDr.Table.Columns["UnitID"] != null &&
                  objDr["UnitID"].ToString() != "")
                _UnitID = int.Parse(objDr["UnitID"].ToString());

            if (objDr.Table.Columns["CellID"] != null &&
                 objDr["CellID"].ToString() != "")
                _CellID = int.Parse(objDr["CellID"].ToString());

            if (objDr.Table.Columns["ElectricityUnitDesc"] != null &&
                objDr["ElectricityUnitDesc"].ToString() != "")
                _UnitDesc = objDr["ElectricityUnitDesc"].ToString();
            if(objDr.Table.Columns["CustomerFullName"]!= null)
            _CustomerName = objDr["CustomerFullName"].ToString(); 
            if(objDr.Table.Columns["MaxCellID"]!= null && objDr["MaxCellID"].ToString()!= "")
             _UnitCellID   = int.Parse(objDr["MaxCellID"].ToString());
            if(objDr.Table.Columns["CurrentReservationID"]!= null && objDr["CurrentReservationID"].ToString()!= "")
            _UnitReservationID = int.Parse(objDr["CurrentReservationID"].ToString());
            if(objDr.Table.Columns["UnitFullName"]!= null)
              _UnitCode = objDr["UnitFullName"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditCol()
        {
            if (_ElectricityTable == null || _ElectricityTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_ElectricityTable.Rows.Count];
            int intIndex = 0;
            UnitElectricityDb objDb;
            foreach (DataRow objDr in _ElectricityTable.Rows)
            {
                objDb = new UnitElectricityDb(objDr);
                if (objDb.ID == 0)
                    arrStr[intIndex] = objDb.AddStr;
                else
                    arrStr[intIndex] = objDb.EditStr;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr  ;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
