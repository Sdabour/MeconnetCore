using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class TowerDb
    {

        #region Private Data
        int _ID;

        string _Code;
        string _Name;
        int _CellID;
        int _Order;
        int _Project;


        string _Street;

        string _HouseNo;
        DateTime _StartReservationDate;
        bool _StartReservationDateDecided;


        DateTime _EndReservationDate;
        bool _EndReservationDateDecided;

        DateTime _ReadyForOccupancyExpectedDate;

        bool _ReadyForOccupancyDateDecided;
        bool _ReadyForOccupancyExpectedDateDecided;


        DateTime _ReadyForOccupancyDate;

        int _UsageType;
        string _UsageTypeNameA;

        public string UsageTypeNameA
        {
            get { return _UsageTypeNameA; }
            set { _UsageTypeNameA = value; }
        }
        string _UsageTypeNameE;

        public string UsageTypeNameE
        {
            get { return _UsageTypeNameE; }
            set { _UsageTypeNameE = value; }
        }
        string _UsageTypeCode;

        public string UsageTypeCode
        {
            get { return _UsageTypeCode; }
            set { _UsageTypeCode = value; }
        }


        int _BulidingType;
        string _BuildingTypeNameA;

        public string BuildingTypeNameA
        {
            get { return _BuildingTypeNameA; }
            set { _BuildingTypeNameA = value; }
        }
        string _BuildingTypeNameE;

        public string BuildingTypeNameE
        {
            get { return _BuildingTypeNameE; }
            set { _BuildingTypeNameE = value; }
        }
        string _BuildingTypeCode;

        public string BuildingTypeCode
        {
            get { return _BuildingTypeCode; }
            set { _BuildingTypeCode = value; }
        }


        int _FloorNo;
        int _GroundNo;
        int _BasementNo;
        int _ParkingNo;
        bool _IsDelivered;

        public bool IsDelivered
        {
            get { return _IsDelivered; }
            set { _IsDelivered = value; }
        }
        string _GPSLocation;

        public string GPSLocation
        {
            get { return _GPSLocation; }
            set { _GPSLocation = value; }
        }
        string _PostalCode;

        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        string _WBS;

        public string WBS
        {
            get { return _WBS; }
            set { _WBS = value; }
        }
        int _SideView;

        public int SideView
        {
            get { return _SideView; }
            set { _SideView = value; }
        }
        string _CodePattern;
        public string CodePattern
        {
            set { _CodePattern = value; }
            get { return _CodePattern; }
        }
        #endregion
        #region Constructors
        public TowerDb()
        { }
        public TowerDb(DataRow objDr)
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public int Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        public int CellID
        {
            get { return _CellID; }
            set { _CellID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public int ParkingNo
        {
            get { return _ParkingNo; }
            set { _ParkingNo = value; }
        }
        public int BasementNo
        {
            get { return _BasementNo; }
            set { _BasementNo = value; }
        }
        public int GroundNo
        {
            get { return _GroundNo; }
            set { _GroundNo = value; }
        }
        public int FloorNo
        {
            get { return _FloorNo; }
            set { _FloorNo = value; }
        }
        public int BulidingType
        {
            get { return _BulidingType; }
            set { _BulidingType = value; }
        }
        public int UsageType
        {
            get { return _UsageType; }
            set { _UsageType = value; }
        }
        public DateTime ReadyForOccupancyDate
        {
            get { return _ReadyForOccupancyDate; }
            set { _ReadyForOccupancyDate = value; }
        }
        public DateTime ReadyForOccupancyExpectedDate
        {
            get { return _ReadyForOccupancyExpectedDate; }
            set { _ReadyForOccupancyExpectedDate = value; }
        }
        public DateTime EndReservationDate
        {
            get { return _EndReservationDate; }
            set { _EndReservationDate = value; }
        }
        public DateTime StartReservationDate
        {
            get { return _StartReservationDate; }
            set { _StartReservationDate = value; }
        }
        public bool StartReservationDateDecided
        {
            get { return _StartReservationDateDecided; }
            set { _StartReservationDateDecided = value; }
        }
        public bool EndReservationDateDecided
        {
            get { return _EndReservationDateDecided; }
            set { _EndReservationDateDecided = value; }
        }
        public bool ReadyForOccupancyExpectedDateDecided
        {
            get { return _ReadyForOccupancyExpectedDateDecided; }
            set { _ReadyForOccupancyExpectedDateDecided = value; }
        }
        public bool ReadyForOccupancyDateDecided
        {
            get { return _ReadyForOccupancyDateDecided; }
            set { _ReadyForOccupancyDateDecided = value; }
        }
        public string HouseNo
        {
            get { return _HouseNo; }
            set { _HouseNo = value; }
        }
        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        public string AddStr
        {
            get
            {
                string strReservationStartDate = _StartReservationDateDecided ?
                    SysUtility.Approximate(_StartReservationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
                    "NULL";
                string strReservationEndDate = _EndReservationDateDecided ?
    SysUtility.Approximate(_EndReservationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
    "NULL";
                string strReadyForOccupencyDate = _ReadyForOccupancyDateDecided ?
    SysUtility.Approximate(_ReadyForOccupancyDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
    "NULL";
                string strReadyForOccupencyExpectedDate = _ReadyForOccupancyExpectedDateDecided ?
  SysUtility.Approximate(_ReadyForOccupancyExpectedDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
  "NULL";
                string Returned = "insert into CRMTower ( TowerCell, TowerProject, TowerOrder, TowerCode, TowerName,TowerCodePattern, TowerGPSLocation, TowerStreet, TowerPostalCode" +
                    ", TowerHouseNo, TowerReservationStartDate, " +
                         "TowerReservationEndDate, TowerReadyForOccupancyDate, TowerReadyForOccupancyExpectedDate, TowerUsageType, TowerBuildingType, TowerFloorNo, " +
                         " TowerGroundNo, TowerBasementNo, TowerParkingNo, TowerWBSCode, TowerSideView, UsrIns, TimIns " +
                         " ) " +
                         " values (" + _CellID + "," + _Project + "," + _Order + ",'" + _Code + "','" + _Name + "','" +_CodePattern + "','"+
                         _GPSLocation + "','" + _Street + "','" + _PostalCode + "','" + _HouseNo + "'," +
                         strReservationStartDate + "," + strReservationEndDate + "," +
                         strReadyForOccupencyDate + "," + strReadyForOccupencyExpectedDate + "," + _UsageType + "," + _BulidingType +
                         "," + _FloorNo + "," + _GroundNo + "," + _BasementNo + "," + _ParkingNo + ",'" + _WBS + "'," + _SideView + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string strReservationStartDate = _StartReservationDateDecided ?
                   SysUtility.Approximate(_StartReservationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
                   "NULL";
                string strReservationEndDate = _EndReservationDateDecided ?
    SysUtility.Approximate(_EndReservationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
    "NULL";
                string strReadyForOccupencyDate = _ReadyForOccupancyDateDecided ?
    SysUtility.Approximate(_ReadyForOccupancyDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
    "NULL";
                string strReadyForOccupencyExpectedDate = _ReadyForOccupancyExpectedDateDecided ?
  SysUtility.Approximate(_ReadyForOccupancyExpectedDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() :
  "NULL";
                double dblDate = SysUtility.Approximate(_ReadyForOccupancyDate.ToOADate() - 2, 1, ApproximateType.Down);

                string Returned = "update CRMTower set  TowerCell=" + _CellID +
                    ", TowerProject=" + _Project +
                    ", TowerOrder=" + _Order +
                    ", TowerCode='" + _Code + "'" +
                    ", TowerName='" + _Name + "'" +
                    ",TowerCodePattern='"+ _CodePattern +"'"+
                    ", TowerGPSLocation ='" + _GPSLocation + "'" +
                    ", TowerStreet='" + _Street + "'" +
                    ", TowerPostalCode='" + _PostalCode + "'" +
                    ", TowerHouseNo='" + _HouseNo + "'" +
                    ", TowerReservationStartDate=" + strReservationStartDate +
                    ",TowerReservationEndDate=" + strReservationEndDate +
                    ", TowerReadyForOccupancyDate=" + strReadyForOccupencyDate +
                    ", TowerReadyForOccupancyExpectedDate=" + strReadyForOccupencyExpectedDate +
                    ", TowerUsageType=" + _UsageType +
                    ", TowerBuildingType=" + _BulidingType +
                    ", TowerFloorNo=" + _FloorNo +
                    ", TowerGroundNo=" + _GroundNo +
                    ", TowerBasementNo=" + _BasementNo +
                    ", TowerParkingNo=" + _ParkingNo +
                    ", TowerWBSCode='" + _WBS + "'" +
                    ", TowerSideView=" + _SideView +
                    ",UsrUpd =" + SysData.CurrentUser.ID +
                    ",TimUpd=GetDate() " +
                    " where TowerID= " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from  ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strUsageType = "SELECT        UsageTypeID AS TowerUsageTypeID, UsageTypeCode AS TowerUsageTypeCode, UsageTypeNameA AS TowerUsageTypeNameA, " +
                         " UsageTypeNameE AS TowerUsageTypeNameE " +
                         " FROM      dbo.CRMTowerUsageType ";
                string strType = "SELECT  TypeID AS TowerTypeID, TypeCode AS TowerTypeCode, TypeNameA AS TowerTypeNameA, TypeNameE AS TowerTypeNameE " +
                      " FROM            dbo.CRMTowerType ";
                string Returned = "SELECT   dbo.CRMTower.TowerID, dbo.CRMTower.TowerCell, dbo.CRMTower.TowerProject, dbo.CRMTower.TowerOrder, dbo.CRMTower.TowerCode, " +
                      " dbo.CRMTower.TowerName,CRMTower.TowerCodePattern, dbo.CRMTower.TowerStreet, dbo.CRMTower.TowerHouseNo, dbo.CRMTower.TowerReadyForOccupancyDate,  " +
                      " dbo.CRMTower.TowerUsageType, dbo.CRMTower.TowerBuildingType, dbo.CRMTower.TowerFloorNo, dbo.CRMTower.TowerGroundNo, " +
                      " dbo.CRMTower.TowerBasementNo," +
                      " dbo.CRMTower.TowerParkingNo, dbo.CRMTower.TowerReservationStartDate, dbo.CRMTower.TowerReservationEndDate, " +
                      " dbo.CRMTower.TowerReadyForOccupancyExpectedDate " +
                      ",ProjectTable.*,UsageTypeTable.*,TowerTypeTable.*  " +
                      " FROM    dbo.CRMTower LEFT OUTER JOIN " +
                      " (" + ProjectDb.SearchStr + ") AS ProjectTable ON dbo.CRMTower.TowerProject = ProjectTable.ProjectID " +
                      " left outer join (" + strType + ") as TowerTypeTable " +
                      " on dbo.CRMTower.TowerBuildingType = TowerTypeTable.TowerTypeID  " +
                      " left outer join (" + strUsageType + ") as UsageTypeTable " +
                      " on  dbo.CRMTower.TowerUsageType = UsageTypeTable.TowerUsageTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["TowerID"] != null && objDr["TowerID"].ToString() != "")
                _ID = int.Parse(objDr["TowerID"].ToString());
            if (objDr.Table.Columns["TowerCell"] != null && objDr["TowerCell"].ToString() != "")
                _CellID = int.Parse(objDr["TowerCell"].ToString());
            if (objDr.Table.Columns["TowerProject"] != null && objDr["TowerProject"].ToString() != "")
                _Project = int.Parse(objDr["TowerProject"].ToString());
            if (objDr.Table.Columns["TowerOrder"] != null && objDr["TowerOrder"].ToString() != "")
                _Order = int.Parse(objDr["TowerOrder"].ToString());
            if (objDr.Table.Columns["TowerCode"] != null && objDr["TowerCode"].ToString() != "")
                _Code = objDr["TowerCode"].ToString();
            if (objDr.Table.Columns["TowerName"] != null && objDr["TowerName"].ToString() != "")
                _Name = objDr["TowerName"].ToString();
            if (objDr.Table.Columns["TowerStreet"] != null && objDr["TowerStreet"].ToString() != "")
                _Street = objDr["TowerStreet"].ToString();
            if (objDr.Table.Columns["TowerHouseNo"] != null && objDr["TowerHouseNo"].ToString() != "")
                _HouseNo = objDr["TowerHouseNo"].ToString();
            if (objDr.Table.Columns["TowerReadyForOccupancyDate"] != null && objDr["TowerReadyForOccupancyDate"].ToString() != "")
            {
                _ReadyForOccupancyDate = DateTime.Parse(objDr["TowerReadyForOccupancyDate"].ToString());
                _ReadyForOccupancyDateDecided = true;
            }


            if (objDr.Table.Columns["TowerUsageType"] != null && objDr["TowerUsageType"].ToString() != "")
                _UsageType = int.Parse(objDr["TowerUsageType"].ToString());

            if (objDr.Table.Columns["TowerBuildingType"] != null && objDr["TowerBuildingType"].ToString() != "")
                _BulidingType = int.Parse(objDr["TowerBuildingType"].ToString());
            if (objDr.Table.Columns["TowerFloorNo"] != null && objDr["TowerFloorNo"].ToString() != "")
                _FloorNo = int.Parse(objDr["TowerFloorNo"].ToString());
            if (objDr.Table.Columns["TowerGroundNo"] != null && objDr["TowerGroundNo"].ToString() != "")
                _GroundNo = int.Parse(objDr["TowerGroundNo"].ToString());
            if (objDr.Table.Columns["TowerBasementNo"] != null && objDr["TowerBasementNo"].ToString() != "")
                _BasementNo = int.Parse(objDr["TowerBasementNo"].ToString());

            if (objDr.Table.Columns["TowerParkingNo"] != null && objDr["TowerParkingNo"].ToString() != "")
                _ParkingNo = int.Parse(objDr["TowerParkingNo"].ToString());

            if (objDr.Table.Columns["TowerReservationStartDate"] != null && objDr["TowerReservationStartDate"].ToString() != "")
            {
                _StartReservationDate = DateTime.Parse(objDr["TowerReservationStartDate"].ToString());
                _StartReservationDateDecided = true;
            }

            if (objDr.Table.Columns["TowerReservationEndDate"] != null && objDr["TowerReservationEndDate"].ToString() != "")
            {
                _EndReservationDate = DateTime.Parse(objDr["TowerReservationEndDate"].ToString());
                _EndReservationDateDecided = true;
            }

            if (objDr.Table.Columns["TowerReadyForOccupancyExpectedDate"] != null && objDr["TowerReadyForOccupancyExpectedDate"].ToString() != "")
            {
                _ReadyForOccupancyExpectedDate = DateTime.Parse(objDr["TowerReadyForOccupancyExpectedDate"].ToString());
                _ReadyForOccupancyExpectedDateDecided = true;
            }




            if (objDr.Table.Columns["TowerTypeID"] != null && objDr["TowerTypeID"].ToString() != "")
            {
                _BulidingType = int.Parse(objDr["TowerTypeID"].ToString());
                _BuildingTypeCode = objDr["TowerTypeCode"].ToString();
                _BuildingTypeNameA = objDr["TowerTypeNameA"].ToString();
                _BuildingTypeNameE = objDr["TowerTypeNameE"].ToString();
            }

            if (objDr.Table.Columns["TowerUsageTypeID"] != null && objDr["TowerUsageTypeID"].ToString() != "")
            {
                _UsageType = int.Parse(objDr["TowerUsageTypeID"].ToString());
                _UsageTypeCode = objDr["TowerUsageTypeCode"].ToString();
                _UsageTypeNameA = objDr["TowerUsageTypeNameA"].ToString();
                _UsageTypeNameE = objDr["TowerUsageTypeNameE"].ToString();
            }
            if (objDr.Table.Columns["TowerCodePattern"] != null)
                _CodePattern = objDr["TowerCodePattern"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_Project != 0)
                strSql += " and  dbo.CRMTower.TowerProject=" + _Project;
            if (_BulidingType != 0)
                strSql += " and TowerTypeTable.TowerTypeID=" + _BulidingType;
            if (_UsageType != 0)
                strSql += " and UsageTypeTable.TowerUsageTypeID =" + _UsageType;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
