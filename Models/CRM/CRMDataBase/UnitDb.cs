using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class UnitDb : BaseSingleDb
    {
        //UnitType = 9
        #region Private Data
        protected int _ModelID;
        protected string _FullName;
        string _Code;


        string _Neighbor1;


        string _Neighbor2;


        string _Neighbor3;


        string _Neighbor4;
        int _View;
        int _MainType;



        int _UsageType;


        string _SapView;


        protected double _Survey;
        protected int _Reservation;
        protected ReservationDb _ReservationDb;
        protected UnitModelDb _ModelDb;
        DataTable _CellTable;
        DataTable _PeripheralTable;
        DataTable _DeletedPeripheralTable;
        bool _EditSucceeded;
        int _ResultCount;
        int _FloorOrder;
        int _UnitType;
        double _DelegationValue;
        int _MaxCellID;
        int _MinCellID;
        string _CustomerStr;
        bool _IsContracted;
        string _Desc;
        int _Order;
        DateTime _ContractingDate;
        DateTime _ReservationDate;
        double _ReservationPaidValue;
        string _PeripheralDesc;
        bool _IsStopped;


        int _IsStoppedStatus;
        DataTable _UnitTable;

        #region PrivateData For Search
        protected double _FromSurvey;
        protected double _ToSurvey;
        protected string _UnitNameLike;
        protected string _CellTowerName;
        protected string _UnitIDs;
        protected string _ModelIDs;
        protected DateTime _DeliveryDate;
        protected int _DeliveryStatus;/*
                                       * 0 dont care
                                       * 1 is delivered
                                       * 2 Not Delivered
                                       */
        protected int _CellTowerDeliveryStatus;/*
                                       * 0 dont care
                                       * 1 is delivered
                                       * 2 Not Delivered
                                       */
        protected bool _IsDelivered;
        protected bool _DeliveryDateRange;
        protected DateTime _StartDeliveryDate;
        protected DateTime _EndDeliveryDate;
        int _PeripheralID;
        double _StartPeripheralSurvey;
        double _EndPeripheralSurvey;


        // protected bool _IsReserved;
        int _UnitStatus;//0 not Specified
                        // 1 free
                        // 2 reserved 
        int _UserClosed;
        DateTime _OpenTime;
        bool _PermanentlyClosed;
        int _CellID;
        int _StartUnitFloor;
        int _EndUnitFloor;
        int _CellTower;






        string _CellIDs;
        int _CellFamilyID;
        string _CustomerIDs;
        string _StatusStr;
        string _ReservationIDs;
        string _UnitCodeStr;

        #region private Data for Elecricity Meter
        bool _HasElectricityMeter;
        DateTime _ElectricityMeterStartDate;
        bool _ElectricityMeterHasStartDate;
        string _ElectricityMeterOwner;
        int _ElectricityMeterStatus;
        int _ElectricityMeterIllegalAction;
        string _ElecticityMeterNotes;
        DataTable _ElectricityTable;
        #endregion
        #endregion
        #region Private Data for Closing
        double _TimeClose;//time to close in minutes
        bool _PermanentClosed;
        double _MaxTimeClose = 60;
        bool _GetClosed;
        string _CloseReason;
        int _ClosePeriod;//0 Minutes
                         //1 hours 
                         //2 days
        DateTime _TimeOpen;
        int _RemainingDay;
        int _RemainingHour;
        int _RemainingMinute;
        bool _IsDelegated;
        bool _IsForReReservation;
        protected int _MaxID;
        protected int _MinID;

        #endregion
        #region Private Static Data for Caching
        static DataTable _CachUnitCelltable;
        static DataTable _CachReservationTable;
        static DataTable _CachUserTable;
        // static DataTable _CachCurrentReservation;

        static string _CachUnitIDs;

        #endregion
        #region Private Data for Grouping
        bool _IsCellTowerGrouping;
        bool _IsProjectGrouping;
        bool _IsTypeGrouping;
        bool _IsStatusGrouping;
        bool _IsDeliveredStatusGrouping;
        bool _IsCellTowerDeliveredStatusGrouping;
        bool _IsSurveyGrouping;
        bool _IsModelGrouping;
        bool _IsFloorGrouping;
        bool _IsUsageTypeGrouping;

        public bool IsUsageTypeGrouping
        {
            set
            {
                _IsUsageTypeGrouping = value;
            }
        }
        bool _IsUnitPriceGrouping;

        public bool IsUnitPriceGrouping
        {

            set { _IsUnitPriceGrouping = value; }
        }
        bool _IsOrderGrouping;

        public bool IsOrderGrouping
        {
            get { return _IsOrderGrouping; }
            set { _IsOrderGrouping = value; }
        }
        bool _IsUnitCategoryGrouping;
        public bool IsUnitCategoryGrouping{ set => _IsUnitCategoryGrouping=value; }
        bool _IsCategoryGradeGrouping;
        public bool IsCategoryGradeGrouping
        {
            set => _IsCategoryGradeGrouping = value;
        }
        int _Floor;

        public int Floor
        {
            get { return _Floor; }
            set { _Floor = value; }
        }
        int _FloorTo;

        public int FloorTo
        {
            get { return _FloorTo; }
            set { _FloorTo = value; }
        }
        int _Tower;
        public int Tower
        {
            set { _Tower = value; }
            get { return _Tower; }
        }
        #endregion

        #endregion
        #region Constructors
        public UnitDb()
        {
           
            _ModelDb = new UnitModelDb();
            _ReservationDb = new ReservationDb();
        }
        public UnitDb(DataRow objDr)
        {
            // UnitSurvey, UnitModel, CurrentReservation,

            SetData(objDr);           


        }
        public UnitDb(string strUnitCode,int intCellID,int intUnitStatus)
        {
            // UnitSurvey, UnitModel, CurrentReservation,
            _NameA = strUnitCode;
            _UnitStatus = intUnitStatus;
            _CellFamilyID = intCellID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                SetData(objDr);
            }



        }
        public UnitDb(string strUnitCode, int intCellID, string strUnitStatus)
        {
            // UnitSurvey, UnitModel, CurrentReservation,
            _NameA = strUnitCode;
            _StatusStr = strUnitStatus;
            _CellFamilyID = intCellID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                SetData(objDr);
            }



        }
        public UnitDb(int intUnitID)
        {
            // UnitSurvey, UnitModel, CurrentReservation,
            _ID = intUnitID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                SetData(objDr);
            }
            else
                _ID = 0;



        }
        public UnitDb(int intUnitID, int intUnitStatus)
        {
            _ID = intUnitID;
            _UnitStatus = intUnitStatus;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                SetData(objDr);
            }
            else
                _ID = 0;

        }
        //public UnitDb(int IntTypeID)
        //{
        //    _UnitType = IntTypeID;
        //    DataTable dtTemp = Search();
        //    if (dtTemp.Rows.Count > 0)
        //    {
        //        DataRow objDR = dtTemp.Rows[0];
        //        SetData(objDR);
        //    }
        //    else
        //        _UnitType = 0;

        //}
        #endregion
        #region Public Properties
        public string FullName
        {
            set
            {
                _FullName = value;
            }
            get
            {
               
                return _FullName;
            }
        }
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
            get
            {
                return _ModelID;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        public int Reservation
        {
            set
            {
                _Reservation = value;
            }
            get
            {
                return _Reservation;
            }
        }
        public double Survey
        {
            set
            {
                _Survey = value;
            }
            get
            {
                return _Survey;
            }
        }
        double _Height;

        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        double _PricePerMeter;

        public double PricePerMeter
        {
            get { return _PricePerMeter; }
            set { _PricePerMeter = value; }
        }
        double _PricePerMeterIncreaseAmount;

        public double PricePerMeterIncreaseAmount
        {
            get { return _PricePerMeterIncreaseAmount; }
            set { _PricePerMeterIncreaseAmount = value; }
        }
        double _PricePerMeterIncreasePerc;

        public double PricePerMeterIncreasePerc
        {
            get { return _PricePerMeterIncreasePerc; }
            set { _PricePerMeterIncreasePerc = value; }
        }
        DateTime _PriceDate;

        public DateTime PriceDate
        {
            get { return _PriceDate; }
            set { _PriceDate = value; }
        }
        bool _PriceDateRange;
        public bool PriceDateRange
        {
            set
            {
                _PriceDateRange = value; 
            }
        }
        DateTime _PriceDateStart;
        public DateTime PriceDateStart
        {
            set
            {
                _PriceDateStart = value;
            }
        }
        DateTime _PriceDateEnd;
        public DateTime PriceDateEnd
        {
            set
            {
                _PriceDateEnd = value;
            }
        }
        string _ResubmissionTypeIDs;
        public string ResubmissionTypeIDs
        {
            set
            {
                _ResubmissionTypeIDs = value;
            }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Neighbor1
        {
            get { return _Neighbor1; }
            set { _Neighbor1 = value; }
        }
        public string Neighbor2
        {
            get { return _Neighbor2; }
            set { _Neighbor2 = value; }
        }

        public string Neighbor3
        {
            get { return _Neighbor3; }
            set { _Neighbor3 = value; }
        }

        public string Neighbor4
        {
            get { return _Neighbor4; }
            set { _Neighbor4 = value; }
        }
        public bool IsStopped
        {
            get { return _IsStopped; }
            set { _IsStopped = value; }
        }


        public int IsStoppedStatus
        {
            set { _IsStoppedStatus = value; }
        }

        public int View
        {
            get { return _View; }
            set { _View = value; }
        }

        public string SapView
        {
            get { return _SapView; }
            set { _SapView = value; }
        }


         public int MainType
        {
            get { return _MainType; }
            set { _MainType = value; }
        }


        public int UsageType
        {
            get { return _UsageType; }
            set { _UsageType = value; }
        }
        string _UsageTypeName;

        public string UsageTypeName
        {
            get { return _UsageTypeName; }
            set { _UsageTypeName = value; }
        }
        double _NumericEvaluation;
        public double NumericEvaluation
        {
            set => _NumericEvaluation = value;
            get => _NumericEvaluation;
        }
        int _Category;
        public int Category
        {
            get => _Category;
            set => _Category = value;
        }

        string _CategoryIDs;
        public string CategoryIDs
        {
            set => _CategoryIDs = value;
        }

        bool _IncludeCategoryGrade;

        int _CategoryGrade;
        public int CategoryGrade
        {
            get
            {
                return _CategoryGrade;
            }
        }

        string _CategoryGrades;
        public string CategoryGrades
        {
            set => _CategoryGrades = value;
        }
        string _CategoryNameA;
        public string CategoryNameA
        {
            get => _CategoryNameA;
            set => _CategoryNameA = value;
        }
        string _CategoryNameE;
        public string CategoryNameE
        {
            get => _CategoryNameE;
            set => _CategoryNameE = value;
        }

       
        string _ViewNameA;
        public string ViewNameA
        {
            get => _ViewNameA;
            set => _ViewNameA = value;
        }
        string _ViewNameE;
        public string ViewNameE
        {
            get => _ViewNameE;
            set => _ViewNameE = value;
        }


        public int UserClosed
        {
            get
            {
                return _UserClosed;
            }
            set {
                _UserClosed = value;
            }
        }
        public string UnitNameLike
        {
            set
            {
                _UnitNameLike = value;
            }
        }
        public string CellTowerName
        {
            get
            {
                return _CellTowerName;
            }
            set
            {
                _CellTowerName = value;
            }
        }
        public double FromSurvey
        {
            set
            {
                _FromSurvey = value;
            }
        }
        public double ToSurvey
        {
            set
            {
                _ToSurvey = value;
            }
           
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int CellID
        {
            set
            {
                _CellID = value;
            }
        }
        public int EndUnitFloor
        {
            get { return _EndUnitFloor; }
            set { _EndUnitFloor = value; }
        }
        public int StartUnitFloor
        {
            get { return _StartUnitFloor; }
            set { _StartUnitFloor = value; }
        }
        int _CellTowerOrder;

        public int CellTowerOrder
        {
            get { return _CellTowerOrder; }

        }
        string _ProjectName;

        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }

        }
        string _ModelFamilyName;

        public string ModelFamilyName
        {
            get { return _ModelFamilyName; }

        }
        double _TotalUnitCachPrice;

        public double TotalUnitCachPrice
        {
            get { return _TotalUnitCachPrice; }
            set { _TotalUnitCachPrice = value; }
        }
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
        }

        public string ModelIDs
        {
            set
            {
                _ModelIDs = value;
            }
        }
        public bool GetClosed
        {
            set
            {
                _GetClosed = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        string _CellFamilyIDs;

        public string CellFamilyIDs
        {
            get { return _CellFamilyIDs; }
            set { _CellFamilyIDs = value; }
        }
        public string UnitCodeStr
        {
            set
            {
                _UnitCodeStr = value;
            }
        }
        public DataTable CellTable
        {
            set
            {
                _CellTable = value;
            }
        }
        public DataTable PeripheralTable
        {
            set 
            {
                _PeripheralTable = value;
            }
        }
        public DataTable DeletedPeripheralTable
        {
            set
            {
                _DeletedPeripheralTable = value;
            }
        }

        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public double TimeClose
        {
            set
            {
                _TimeClose = value;
            }
        }
        public int DeliveryStatus
        {
            set
            {
                _DeliveryStatus = value;
            }
        }
        public int CellTowerDeliveryStatus
        {
            set
            {
                _CellTowerDeliveryStatus = value;
            }
        }
        DateTime _CloseDate;
        public DateTime CloseDate
        {
            get => _CloseDate;
        }
        bool _IsClosed;
        public bool IsClosed
        { get => _IsClosed; }
        public int ClosePeriod
        {
            set
            {
                _ClosePeriod = value;

            }
        }
        public bool PermanentClosed
        {
            set
            {
                _PermanentClosed = value;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public string CloseReason
        {
            set
            {
                _CloseReason = value;
            }
            get
            {
                return _CloseReason;
            }
        }
        double _StartPrice;
        double _EndPrice;
        public int RemainingDay
        {
            get
            {
                return _RemainingDay;
            }
        }

        public int RemainingHour
        {
            get
            {
                return _RemainingHour;
            }
        }
        public  int RemainingMinute
        {
            get
            {
                return _RemainingMinute;
            }
        }
        public bool EditSucceeded
        {
            get
            {
                return _EditSucceeded;
            }
        }
        //0 all , 1 free , 2 reserved,3 Closed Permanently , 4 Closed 
        //6 free not delegated
        //5 Free Delegated   
        //7 Not Reserved Either Free or Closed
        // 8 Tenanted 
        public int UnitStatus
        {
            get
            {
                return _UnitStatus;
            }
            set
            {
                
                _UnitStatus = value;
            }
        }
        public string StatusStr
        {
            set
            {
                _StatusStr = value;
            }
        }
        public int FloorOrder
        {
            set
            {
                _FloorOrder = value;
            }
        }
        string _FloorStr;

        public string FloorStr
        {
            get { return _FloorStr; }
            set { _FloorStr = value; }
        }
        string _FloorIDs;
        public string FloorIDs
        {
            set
            {
                _FloorIDs = value;
            }
        }
        string _ProjectIDs;
        public string ProjectIDs
        {
            set
            {
                _ProjectIDs = value;
            }
        }
        string _TowerIDs;
        public string TowerIDs
        {
            set
            {
                _TowerIDs = value;
            }
        }
        public int UnitType
        {
            set
            {
                _UnitType = value;
            }
            get
            {
                return _UnitType;
            }
        }
        string _UnitTypeIDs;
        public string UnitTypeIDs
        { set => _UnitTypeIDs = value; }
        string _unitTypeName;
        public string UnitTypeName
        {
            get
            {
                return _unitTypeName;
            }
        }
        public int CellTower
        {
            get { return _CellTower; }
            set { _CellTower = value; }
        }
        public bool IsDelivered
        {
            set
            {
                _IsDelivered = value;
            }
            get
            {
                return _IsDelivered;
            }
        }
        bool _IsReadyForDelivery;

        public bool IsReadyForDelivery
        {
            get { return _IsReadyForDelivery; }
            set { _IsReadyForDelivery = value; }
        }
        DateTime _ReadyForDeliveryDate;

        public DateTime ReadyForDeliveryDate
        {
            get { return _ReadyForDeliveryDate; }
            set { _ReadyForDeliveryDate = value; }
        }
        int _Campaign;

        public int Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        DataTable _AttributeTable;
        public DataTable AttributeTable
        {
            set => _AttributeTable = value;
        }
        public string UnitAttributeStr
        {
            get
            {
                if (_AttributeTable == null || _AttributeTable.Rows.Count == 0)
                    return "";
                int intCount = _AttributeTable.Rows.Count;
                SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table CRMUnitAttributeValueTemp");
                SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
                objCopy.DestinationTableName = "CRMUnitAttributeValueTemp";
                objCopy.WriteToServer(_AttributeTable);

                string Returned = @"SELECT        dbo.CRMUnitAttributeValue.UnitID, COUNT(dbo.CRMUnitAttributeValue.Attribute) AS Expr1
FROM            dbo.CRMUnitAttributeValueTemp INNER JOIN
                         dbo.CRMUnitAttributeValue ON dbo.CRMUnitAttributeValueTemp.Attribute = dbo.CRMUnitAttributeValue.Attribute AND dbo.CRMUnitAttributeValueTemp.AttributeValue <= dbo.CRMUnitAttributeValue.AttributeValue
GROUP BY dbo.CRMUnitAttributeValue.UnitID ";
                if(_IsAndingAttribute)
                   Returned += " HAVING        (COUNT(dbo.CRMUnitAttributeValue.Attribute) = "+ intCount +")";
                return Returned;
            }
        }

       
        bool _IsAndingAttribute;
        public bool IsAndingAttribute
        {
            set => _IsAndingAttribute = value;
        }

        double _TotalAttributeStart;
        public double TotalAttributeStart
        {
            set => _TotalAttributeStart = value;
        }
        double _TotalAttributeEnd;
        public double TotalAttributeEnd
        {
            set => _TotalAttributeEnd = value;
        }

        public string UnitAttributeTotalPercStr
        {
            get
            {
                if (_TotalAttributeStart > 100)
                    _TotalAttributeStart = 100;
                if (_TotalAttributeEnd > 100)
                    _TotalAttributeEnd = 100;
                string Returned = @"SELECT   dbo.CRMUnitAttributeValue.UnitID, SUM(dbo.CRMUnitAttributeValue.AttributeValue) / SUM(dbo.CRMAttribute.AttributeMaxValue) * 100 AS TotalValuePerc
FROM            dbo.CRMUnitAttributeValue INNER JOIN
                         dbo.CRMUnitAttributeValueTemp ON dbo.CRMUnitAttributeValue.Attribute = dbo.CRMUnitAttributeValueTemp.Attribute INNER JOIN
                         dbo.CRMAttribute ON dbo.CRMUnitAttributeValue.Attribute = dbo.CRMAttribute.AttributeID
GROUP BY dbo.CRMUnitAttributeValue.UnitID
HAVING        (SUM(dbo.CRMUnitAttributeValue.AttributeValue) / SUM(dbo.CRMAttribute.AttributeMaxValue) * 100 BETWEEN "+ _TotalAttributeStart +" AND "+_TotalAttributeEnd+")";
                return Returned;
            }
        }
        DateTime _StartDate;
        DateTime _EndDate;
        public string OccupyCheckStr
        {
            get
            {
                string Returned = "";
                double dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEnd = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                string strReservation = @"SELECT        UnitID 
FROM dbo.CRMReservationUnit  
where (
(ReservationFrom  between " + dblStart +@" and " + dblEnd + @")
or (ReservationTo  between " + dblStart + @" and " + dblEnd + @")
or ("+ dblStart + @" between ReservationFrom and ReservationTo ) 
or (" + dblEnd + @" between ReservationFrom and ReservationTo ) 
)";

                return Returned;
            }
        }
        
        #region Sum Data
        double _TotalCount;

        public double TotalCount
        {
            get { return _TotalCount; }

        }
        int _NotSpecifiedTypeCount;

        public int NotSpecifiedTypeCount
        {
            get { return _NotSpecifiedTypeCount; }

        }
        int _ResidentialCount;

        public int ResidentialCount
        {
            get { return _ResidentialCount; }

        }
        int _CommercialCount;

        public int CommercialCount
        {
            get { return _CommercialCount; }

        }
        int _EconomicalCount;

        public int EconomicalCount
        {
            get { return _EconomicalCount; }

        }
        int _AdministrativeCount;

        public int AdministrativeCount
        {
            get { return _AdministrativeCount; }

        }
        int _FreeUnitPricedCount;

        public int FreeUnitPricedCount
        {
            get { return _FreeUnitPricedCount; }

        }
        double _FreeUnitPricedValue;

        public double FreeUnitPricedValue
        {
            get { return _FreeUnitPricedValue; }

        }
        double _FreeUnitPricedTotalSurvey;

        public double FreeUnitPricedTotalSurvey
        {
            get { return _FreeUnitPricedTotalSurvey; }

        }
        double _FreeUnitNotPricedTotalSurvey;

        public double FreeUnitNotPricedTotalSurvey
        {
            get { return _FreeUnitNotPricedTotalSurvey; }

        }
        int _FreeUnitNotPricedCount;

        public int FreeUnitNotPricedCount
        {
            get { return _FreeUnitNotPricedCount; }

        }
        int _TotalOccupiedCount;

        public int TotalOccupiedCount
        {
            get { return _TotalOccupiedCount; }

        }
        double _TotalOccupiedSurvey;

        public double TotalOccupiedSurvey
        {
            get { return _TotalOccupiedSurvey; }
            set { _TotalOccupiedSurvey = value; }
        }
        double _TotalSurvey;

        public double TotalSurvey
        {
            get { return _TotalSurvey; }
            set { _TotalSurvey = value; }
        }
        int _NotSpecifiedTypeOccupiedCount;

        public int NotSpecifiedTypeOccupiedCount
        {
            get { return _NotSpecifiedTypeOccupiedCount; }

        }
        int _OccupiedResidentialCount;

        public int OccupiedResidentialCount
        {
            get { return _OccupiedResidentialCount; }

        }
        int _OccupiedCommercialCount;

        public int OccupiedCommercialCount
        {
            get { return _OccupiedCommercialCount; }

        }
        int _OccupiedEconomicalCount;

        public int OccupiedEconomicalCount
        {
            get { return _OccupiedEconomicalCount; }

        }
        int _OccupiedAdministrativeCount;

        public int OccupiedAdministrativeCount
        {
            get { return _OccupiedAdministrativeCount; }

        }


        

       
        #endregion

        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public UnitModelDb ModelDb
        {
            get
            {
                return _ModelDb;
            }
        }
        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }
        }
        public bool DeliveryDateRange
        {
            set
            {
                _DeliveryDateRange = value;
            }
        }
        public DateTime StartDeliveryDate
        {
            set
            {
                _StartDeliveryDate = value;
            }
        }
        public int PeripheralID
        {
            set
            {
                _PeripheralID = value;
            }
        }
        public double StartPeripheralSurvey
        {
            set
            {
                _StartPeripheralSurvey = value;
            }
        }
        public double EndPeripheralSurvey
        {
            set 
            {
                _EndPeripheralSurvey = value;
            }
        }
        public DateTime EndDeliveryDate
        {
            set
            {
                _EndDeliveryDate = value;
            }
        }
        bool _IsReservationDateRange;

        public bool IsReservationDateRange
        {
            get { return _IsReservationDateRange; }
            set { _IsReservationDateRange = value; }
        }
        DateTime _ReservationStartDate;

        public DateTime ReservationStartDate
        {
            get { return _ReservationStartDate; }
            set { _ReservationStartDate = value; }
        }
        DateTime _ReservationEndDate;

        public DateTime ReservationEndDate
        {
            get { return _ReservationEndDate; }
            set { _ReservationEndDate = value; }
        }
        bool _IsCloseTimeRange;
        public bool IsCloseTimeRange { set => _IsCloseTimeRange = value; }
        DateTime _CloseTimeStart;
        public DateTime CloseTimeStart { set => _CloseTimeStart = value; }
        DateTime _CloseTimeEnd;
        public DateTime CloseTimeEnd { set => _CloseTimeEnd = value; }
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
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        string _FlatNo;

        public string FlatNo
        {
            get { return _FlatNo; }
            set { _FlatNo = value; }
        }
        public DataTable ElectricityTable
        {
            set
            {
                _ElectricityTable = value;
            }
        }
        public double DelegationValue
        {
            get
            {
                return _DelegationValue;
            }
        }
        public int MaxCellID
        {
            set
            {
                _MaxCellID = value;
            }
            get
            {
                return _MaxCellID;
            }
        }
        public int MinCellID
        {
            set
            {
                _MinCellID = value; 
            }
            get
            {
                return _MinCellID;
            }
        }
        public string CustomerStr
        {
            set
            {
                _CustomerStr = value;
            }
            get
            {
                return _CustomerStr;
            }
        }
        public bool IsContracted
        {
            get
            {
                return _IsContracted;
            }
        }
        double _UnitSalesPrice;

        public double UnitSalesPrice
        {
            get { return _UnitSalesPrice; }
            set { _UnitSalesPrice = value; }
        }
        DateTime _UnitSalesPriceDate;

        public DateTime UnitSalesPriceDate
        {
            get { return _UnitSalesPriceDate; }
            set { _UnitSalesPriceDate = value; }
        }
      
        int _TenancyID;
        public int TenancyID
        {
            set => _TenancyID = value;
            get => _TenancyID;
        }
        DateTime _TenancyEndDate;
        public DateTime TenancyEndDate
        {
            set => _TenancyEndDate = value;
            get => _TenancyEndDate;
        }
        #region FloorArea
        int _MinFloorID;
        public int MinFloorID
        {
            set
            {
                _MinFloorID = value;
            }
            get
            {
                return _MinFloorID;
            }
        }
        int _MaxFloorID;
        public int MaxFloorID
        {
            set
            {
                _MaxFloorID = value;
            }
            get
            {
                return _MaxFloorID;
            }
        }
        int _MinFloorValue;
        public int MinFloorValue
        {
            set
            {
                _MinFloorValue = value;
            }
            get
            {
                return _MinFloorValue;
            }
        }
        string _MinFloorCode;
        public string MinFloorCode
        {
            set
            {
                _MinFloorCode = value;
            }
            get
            {
                return _MinFloorCode;
            }
        }
        string _MinFloorNameA;
        public string MinFloorNameA
        {
            set
            {
                _MinFloorNameA = value;
            }
            get
            {
                return _MinFloorNameA;
            }
        }
        string _MinFloorNameE;
        public string MinFloorNameE
        {
            set
            {
                _MinFloorNameE = value;
            }
            get
            {
                return _MinFloorNameE;
            }
        }
        int _MaxFloorValue;
        public int MaxFloorValue
        {
            set
            {
                _MaxFloorValue = value;
            }
            get
            {
                return _MaxFloorValue;
            }
        }
        string _MaxFloorCode;
        public string MaxFloorCode
        {
            set
            {
                _MaxFloorCode = value;
            }
            get
            {
                return _MaxFloorCode;
            }
        }
        string _MaxFloorNameA;
        public string MaxFloorNameA
        {
            set
            {
                _MaxFloorNameA = value;
            }
            get
            {
                return _MaxFloorNameA;
            }
        }
        string _MaxFloorNameE;
        public string MaxFloorNameE
        {
            set
            {
                _MaxFloorNameE = value;
            }
            get
            {
                return _MaxFloorNameE;
            }
        }
        #endregion
        public DataTable UnitTable
        {
            set
            {
                _UnitTable = value;
            }
        }
        string _CodePattern;
        public string CodePattern 
        {
            set { _CodePattern = value; } 
        }
        public DateTime ContractingDate
        {
            get
            {
                return _ContractingDate;
            }
        }
        public DateTime ReservationDate
        {
            get
            {
                return _ReservationDate;
            }
        }
        DateTime _ReservationDeliveryDate;
        public DateTime ReservationDeliverDate
        {
            get
            {
                return _ReservationDeliveryDate;
            }
        }
        public double ReservationPaidValue
        {
            get
            {
                return _ReservationPaidValue;
            }
        }
        public string PeripheralDesc
        {
            get
            {
                return _PeripheralDesc;
            }
        }
        public string EditStr
        {
            get 
            {
                string Returned = " UPDATE    CRMUnit " +
                           " SET  UnitView=" + _View +
                           //",UnitOrder="+ _Order +
                           ",UnitPricePerMeter=" +_UnitSalesPrice+
                           ",UnitMainType=" + _MainType +
                           ",UnitUsageType=" + _UsageType +
                           ",UnitNeighbor1='" + _Neighbor1 + "'" +
                           ",UnitNeighbor2='" + _Neighbor2 + "'" +
                           ",UnitNeighbor3='" + _Neighbor3 + "'" +
                           ",UnitNeighbor4='" + _Neighbor4 + "'" +
                           ",UsrUpd=" + SysData.CurrentUser.ID +
                           ",TimUpd=GetDate() " +
                           " Where UnitID = " + _ID + "";
               
                return Returned;
            }
        }
        public string EditCurrentReservationStr
        {
            get
            {
                string Returned = " UPDATE    CRMUnit " +
                          " SET   CurrentReservation =" + _Reservation + ",UnitUserClosed=0, UnitTimeOpen=null, UnitClosedPermanent=0 " +
                          " Where UnitID in (" + _UnitIDs + ")";
                Returned += " UPDATE    CRMUnit " +
                         " SET   CurrentReservation =0,UnitUserClosed=0, UnitTimeOpen=null, UnitClosedPermanent=0 " +
                         " Where UnitID not in (" + _UnitIDs + ") and CurrentReservation <>0 and  CurrentReservation ="+ _Reservation  ;

                return Returned;
            }
        }
        public string PeripheralSearchStr
        {
            get
            {
                string Returned = "SELECT     MainTable.PeriphiralUnit, MaxTable.PeripheralSurvey AS MaxPeripheralSurvey, MinTable.PeripheralSurvey AS MinPeripheralSurvey, MainTable.MaxPeripheral, " +
      " MainTable.MinPeripheral,MainTable.PeripheralCount, MaxTypeTable.PeripheralTypeNameA AS MaxTypeName, MinTypeTable.PeripheralTypeNameA AS MinTypeName " +
       " FROM         dbo.CRMPeripheralType AS MaxTypeTable INNER JOIN " +
       "   (" +
       "SELECT     PeriphiralUnit,count(PeriphiralID) as PeripheralCount, MAX(PeriphiralID) AS MaxPeripheral, MIN(PeriphiralID) AS MinPeripheral " +
             " FROM         dbo.CRMUnitPeripheral where (1=1) ";
                if (_PeripheralID != 0)
                    Returned += " and  dbo.CRMUnitPeripheral.PeriphiralType="+ _PeripheralID;
                if (_EndPeripheralSurvey > 0)
                    Returned += " and dbo.CRMUnitPeripheral.PeripheralSurvey >="+_StartPeripheralSurvey +
                         " and dbo.CRMUnitPeripheral.PeripheralSurvey <=" + _EndPeripheralSurvey;
                Returned+=" GROUP BY PeriphiralUnit";

             Returned +=") AS MainTable INNER JOIN " +
            " dbo.CRMUnitPeripheral AS MinTable ON MainTable.MinPeripheral = MinTable.PeriphiralID AND MainTable.PeriphiralUnit = MinTable.PeriphiralUnit INNER JOIN " +
            " dbo.CRMUnitPeripheral AS MaxTable ON MainTable.PeriphiralUnit = MaxTable.PeriphiralUnit AND MainTable.MaxPeripheral = MaxTable.PeriphiralID ON  " +
            " MaxTypeTable.PeripheralTypeID = MaxTable.PeriphiralType INNER JOIN " +
            " dbo.CRMPeripheralType AS MinTypeTable ON MinTable.PeriphiralType = MinTypeTable.PeripheralTypeID  ";
              
                return Returned;
            }
        }
        public string FloorSearchStr
        {
            get
            { string Returned = @"SELECT dbo.CRMUnit.UnitID AS FloorUnitID, dbo.CRMFloor.FloorID AS MinFloorID, CRMFloor_1.FloorID AS MaxFloorID, dbo.CRMFloor.FloorValue AS MinFloorValue, dbo.CRMFloor.FloorCode AS MinFloorCode, 
                  dbo.CRMFloor.FloorNameA AS MinFloorNameA, dbo.CRMFloor.FloorNameE AS MinFloorNameE, CRMFloor_1.FloorValue AS MaxFloorValue, CRMFloor_1.FloorCode AS MaxFloorCode, CRMFloor_1.FloorNameA AS MaxFloorNameA, 
                  CRMFloor_1.FloorNameE AS MaxFloorNameE
FROM     dbo.CRMUnit LEFT OUTER JOIN
                  dbo.CRMFloor ON dbo.CRMUnit.UnitFloor = dbo.CRMFloor.FloorID LEFT OUTER JOIN
                  dbo.CRMFloor AS CRMFloor_1 ON dbo.CRMUnit.UnitFloorTo = CRMFloor_1.FloorID";
                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {

                string Returned = "";
                Returned+=  SearchStr + " WHERE    (1=1) ";
              //  Returned += " and CRMUnit.UnitID in (select UnitID from VCRMUnitSelection) ";
 
                if (_UnitIDs != null && _UnitIDs != "")
                    Returned = Returned + " And CRMUnit.UnitID In (" + _UnitIDs + ")";
                if (_ID != 0)
                    Returned = Returned + " And CRMUnit.UnitID = " + _ID + "";
                if (_UnitType != 0)
                    Returned = Returned + " And CRMUnit.UnitType = " + _UnitType + " ";

                if (_UnitTypeIDs != null && _UnitTypeIDs!="" && _UnitTypeIDs !="0")
                    Returned = Returned + " And CRMUnit.UnitType in (" + _UnitTypeIDs + ") ";
                if (_FromSurvey != 0)
                    Returned = Returned + " And   (UnitSurvey BETWEEN " + _FromSurvey + " AND " + _ToSurvey + ")";
                if (_UnitNameLike != null && _UnitNameLike != "")
                    Returned = Returned + " And (UnitFullName like '%" + _UnitNameLike +
                        "%' or UnitNameA like '%" + _UnitNameLike + "%') ";
                if (_ModelID != 0)
                    Returned = Returned + " And CRMUnit.UnitModel =" + _ModelID;
                if (_ModelIDs != null && _ModelIDs != "")
                {
                    Returned = Returned + " And CRMUnit.UnitModel in (" + _ModelIDs + ")";
                }
                if (_Reservation != 0)
                    Returned = Returned + " And CRMUnit.CurrentReservation = " + _Reservation + "";
                else
                {
                    if (_UnitStatus == 2)
                    {
                        Returned = Returned + " And CRMUnit.CurrentReservation <>0 ";
                        if (_StatusStr != null && _StatusStr != "" && _StatusStr != "0")
                        {
                            Returned = Returned + " and CRMUnit.CurrentReservation in (SELECT  ReservationID FROM " +
                                " dbo.CRMReservation WHERE (ReservationStatus in (" + _StatusStr + ")) ) ";
                        }
                    }

                    else if (_UnitStatus == 1)
                    {
                        Returned = Returned + " and  (UnitClosedPermanent=0) And (" +
                            "(CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation is null) " +
                            " and " +
                            "(UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                            " or UnitTimeOpen<GetDate() )" +
                            " " +
                            ")";
                    }
                    else if (_UnitStatus == 3)// closed Permanent
                    {
                        Returned = Returned + " And (UnitClosedPermanent=1 ) ";

                    }
                    else if (_UnitStatus == 4)//closed for period 
                    {
                        Returned = Returned + " And (CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation is null) " +
                                          " and ((UnitUserClosed<>0 " +
                                          "  and UnitTimeOpen>GetDate()) ) ";
                    }
                    else if (_UnitStatus == 5)//Free Delegated
                    {
                        Returned = Returned + " and  UnitClosedPermanent=0 And (CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation is null) " +
                          " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                          " or UnitTimeOpen<GetDate() )  ";
                        Returned += "  and DelegationUnitID is not null and DelegationUnitID <> 0 ";

                    }
                    else if (_UnitStatus == 6)//free not delegated
                    {
                        Returned = Returned + " and  UnitClosedPermanent=0 And (CRMUnit.CurrentReservation = 0 or CRMUnit.CurrentReservation is null) " +
                          " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                          " or UnitTimeOpen<GetDate() ) ";
                        Returned += "  and (DelegationUnitID is  null or DelegationUnitID = 0) ";
                    }
                    else if (_UnitStatus == 7)
                    {
                        Returned += "  and (isnull(CRMUnit.CurrentReservation,0) = 0) ";
                    }
                    else if (_UnitStatus == 8)
                    {
                        Returned += "  and (CurrentReservationTable.ReservationTenancyID >0 ) ";
                    }
                }
                if (_CivilPart != 0)
                {
                    Returned += " and CRMUnit.UnitCivilPart = " + _CivilPart ; 
                }
                if (_ReservationIDs != null && _ReservationIDs != "")
                {
                    Returned += " and UnitID in (select UnitID from CRMReservationUnit where " +
                        "ReservationID in (" + _ReservationIDs + "))";
                }
                if (_CellID != 0)
                {
                    Returned = Returned + " and CRMUnit.UnitID in (select UnitID from CRMUnitCell where CellID=" + _CellID + ")";
                }
                if (_CustomerIDs != null && _CustomerIDs != "")
                {
                    //Returned = Returned + " and CRMUnit.UnitID in (SELECT  ReservationUnitID FROM dbo.CRMReservation inner join CRMReservationCustomer " +
                    //" on CRMReservationCustomer.ReservationID = CRMReservation.ReservationID  where CRMReservationCustomer.CustomerID  in (" + _CustomerIDs + ")) ";
                    Returned += " and (CurrentReservationTable.CurrentReservationID is not null) ";
                }
                if (_CellIDs != null && _CellIDs != "" && _CellIDs!= "0")
                {
                    Returned = Returned + " and MaxCellID  in(" + _CellIDs+ ") ";// "(select UnitID from CRMUnitCell where CellID in(" + _CellIDs + "))";
                }
                else if (_CellFamilyID != 0)
                {
                    string strInerCellQuery = "select CellID from RPCell where CellFamilyID =" + _CellFamilyID + "";
                   
                  
                    Returned = Returned + " and MaxCellFamilyID=" + _CellFamilyID;
                  
                }
                if (_CellFamilyIDs != null && _CellFamilyIDs!= "")
                {
                  


                    Returned = Returned + " and MaxCellFamilyID in (" + _CellFamilyIDs + ") ";

                }
                if(_CellFamilyID == 0 && (_CellFamilyIDs == null || _CellFamilyIDs== "") &&  _CellIDs=="0")
                    Returned = Returned + " and MaxCellID  in(" + _CellIDs + ") ";
                if (_FloorOrder != 0)
                   Returned += " and MaxCellOrder = " + _FloorOrder;
                if (_FloorStr != null && _FloorStr != "")
                    Returned += " and MaxCellOrder in (" + _FloorStr + ") ";
                if (_NameA != null && _NameA != "")
                {
                    Returned = Returned + " and (CRMUnit.UnitFullName='" + _NameA +
                        "' or CRMUnit.UnitNameA='" + _NameA + "') ";
                }
                if (_CellTowerName != null && _CellTowerName != "")
                {
                    Returned = Returned + " and (CRMUnit.UnitFullName like '" + _CellTowerName + "%') ";
                }
                if (_UserClosed != 0)
                    Returned += " and ( CRMUnit.CurrentReservation = 0 and   (UnitClosedPermanent = 1 or UnitTimeOpen > GetDate() ) " +
                        "and  (dbo.CRMUnit.UnitUserClosed =  "+ _UserClosed +
                        " or  dbo.CRMUnit.UnitUserAssignedClose = "+ _UserClosed +") ) ";

                if (_IsCloseTimeRange )
                    Returned += " and ( CRMUnit.CurrentReservation = 0 and   (UnitClosedPermanent = 1 or UnitTimeOpen > GetDate() ) " +
                        "  and UnitCloseTime between "+(_CloseTimeStart.Date.ToOADate()-2)+" and "+(_CloseTimeEnd.Date.ToOADate()-2)+" ) ";


                if (_DeliveryStatus != 0)
                {
                    if (_DeliveryStatus == 1)
                    {
                        Returned += " and CRMUnit.UnitDeliveryDate is not null ";
                    }
                    else if (_DeliveryStatus == 2)
                    {
                        Returned += " and CRMUnit.UnitDeliveryDate is  null ";
                    }
                }
                if (_CellTowerDeliveryStatus != 0)
                {
                    if (_CellTowerDeliveryStatus == 1)
                        Returned += " and  (UnitCellTable.MaxDeliveryDate is not null or UnitIsReadyForDelivery =1 ) ";
                    else
                        Returned += " and  UnitCellTable.MaxDeliveryDate is  null and UnitIsReadyForDelivery = 0 ";
                }
                if (_DeliveryDateRange)
                {
                    double dblStartDeliveryDate = SysUtility.Approximate(_StartDeliveryDate.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEndDeliveryDate = SysUtility.Approximate(_EndDeliveryDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and CRMUnit.UnitDeliveryDate >=" + dblStartDeliveryDate +
                        "  and CRMUnit.UnitDeliveryDate <"+dblEndDeliveryDate;
                }
                if (_GetClosed)
                {
                    Returned = Returned + " And (CRMUnit.CurrentReservation = 0  or CRMUnit.CurrentReservation is null) " +
                           " and (UnitUserClosed=" + SysData.CurrentUser.ID + ")" +
                           " and (UnitTimeOpen>GetDate() ) ";
                }
                if (_UnitCodeStr != null && _UnitCodeStr != "")
                    Returned += " and CRMUnit. UnitFullName in ("+ _UnitCodeStr +") ";
                if (_Order != 0)
                    Returned += " and   dbo.CRMUnit.UnitOrder = "+_Order;
                
                if (_FlatNo != null && _FlatNo != "")
                    Returned += " and   dbo.CRMUnit.UnitOrder in ("+ _FlatNo +") ";
                if (_EndPrice > 0)
                    Returned += " and CRMUnit.UnitPricePerMeter>=" + _StartPrice + " and CRMUnit.UnitPricePerMeter <= "+_EndPrice;
                if (_UsageType != 0)
                    Returned += " and UsageTypeTable.UsageTypeID="+ _UsageType;
                if (_FloorIDs != null && _FloorIDs != "" && _FloorIDs != "0")
                    Returned += " and (CRMUnit.UnitFloor in ("+_FloorIDs  + ") or CRMUnit.UnitFloorTo in ("+ _FloorIDs +") )";
                if (_TowerIDs != null && _TowerIDs != "" && _TowerIDs != "0")
                    Returned += " and (CRMUnit.UnitTower in (" + _TowerIDs + ") )";
                if (_ProjectIDs != null && _ProjectIDs != "" && _ProjectIDs != "0")
                    Returned += " and (TowerTable.ProjectID in (" + _ProjectIDs + ") )";
                if (_Category != 0)
                    Returned += " and CategoryTable.CategoryID = " + _Category;
                if (_CategoryIDs != null && _CategoryIDs!= "")
                    Returned += " and CategoryTable.CategoryID in (" + _CategoryIDs + ") ";
                if (_CategoryGrades != null && _CategoryGrades != "")
                {
                    string strStep = "CategoryEvaluationTable.EqualStep ";
                    Returned += @" and  (
case when  EvaluationTable.UnitNumericEvaluation >= (CategoryEvaluationTable.MaxEvaluation-"+ strStep + @") then 1 
when  EvaluationTable.UnitNumericEvaluation <= (CategoryEvaluationTable.MinEvaluation+" + strStep + @") then 2 
else 3 end in ("+ _CategoryGrades +@")
)";
                }
                return Returned;
            }
        }
        bool _IncludeBonus;
        public  string SearchStr
        {
            get
            {
               


      
               //"CONVERT(float, ReservationContractingDate)";
                string strUnitCell = "SELECT  UnitID MaxUnitID, MAX(dbo.CRMUnitCell.CellID) AS MaxCellID, MIN(dbo.CRMUnitCell.CellID) AS MinCellID " +
                    ",max(RPCell.CellOrder) as MaxCellOrder,max(RPCell.CellFamilyID) as MaxCellFamilyID,max( CellTowerTable.CellEstimatedDeliverDate) as MaxEstimatedDeliveryDate"+
                    ",max ( CellTowerTable.CellDeliverDate) as MaxDeliveryDate,max(CellTowerTable.CellID) as CellTowerID " +
                    ",max(case when CellTowerTable.CellAlterName is null or CellTowerTable.CellAlterName = '' then CellTowerTable.CellNameA else CellTowerTable.CellAlterName end) as CellTowerName " +
                    ",max(CellTowerTable.CellOrder) as CellTowerOrder "+
                    ",max(case when CellProjectTable.CellAlterName is null or CellProjectTable.CellAlterName = '' then CellProjectTable.CellNameA else CellProjectTable.CellAlterName end) as CellProjectName " +
                     ",max(CellProjectTable.CellID) as CellProjectID " +
                       " FROM         dbo.CRMUnitCell "+
                       " inner join RPCell on CRMUnitCell.CellID = RPCell.CellID "+
                       " inner join RPCell as CellTowerTable on RPCell.CellParentID = CellTowerTable.CellID  "+
                       " inner join RPCell as CellProjectTable "+
                       " on RPCell.CellFamilyID = CellProjectTable.CellID "+
                       " GROUP BY UnitID ";
               
                string strPeripheral = PeripheralSearchStr;
                string strReservationInstallmentValue = "  SELECT dbo.CRMReservationInstallment.ReservationID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL OR "+
                      " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus <> 2) "+
                      " THEN 0 ELSE GLPayment.PaymentValue END) AS TotalInstallmentPaidValue " +
                       " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                       " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                       " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                       " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                       " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                       " GROUP BY dbo.CRMReservationInstallment.ReservationID ";
                string strReservationPayment = "SELECT     CRMTempReservationPayment.ReservationID, SUM(GLPayment.PaymentValue) AS TempPaymentValue " +
                     " FROM  CRMTempReservationPayment INNER JOIN " +
                     " GLPayment ON CRMTempReservationPayment.PaymentID = GLPayment.PaymentID " +
                     " GROUP BY CRMTempReservationPayment.ReservationID";
                string strUnitMaxReservation = "SELECT  UnitID, MAX(ReservationID) AS MaxReservationID "+
                      " FROM         dbo.CRMReservationUnit "+
                      " GROUP BY UnitID ";
                string strDelegation = "SELECT  dbo.CRMReservationUnit.UnitID as DelegationUnitID"+
                    ",Max(CRMReservation.ReservationID) as DelegationReservationID,"+
                    " sum(case when ReservationContractingDate is not null and convert(float,ReservationContractingDate)> 0 then 1 else 0 end) AS UnitDelegationCount " +
                    " ,sum(case when ReservationContractingDate is null or convert(float,ReservationContractingDate)=0 then 1 else 0 end) AS UnitForReReservationCount " +
                    ",case when DelegatedInstallmentPaymentTable.TotalInstallmentPaidValue is null then 0 else DelegatedInstallmentPaymentTable.TotalInstallmentPaidValue end " +
                     "+"+
                    "case when DelegatedTempPaymentTable.TempPaymentValue is null then 0 else  DelegatedTempPaymentTable.TempPaymentValue end "+
                    " as DelegationValue " +
                      " FROM   dbo.CRMReservation INNER JOIN "+
                      " dbo.CRMReservationUnit ON dbo.CRMReservation.ReservationID = dbo.CRMReservationUnit.ReservationID "+
                      " left outer join ("+ strReservationInstallmentValue +") as DelegatedInstallmentPaymentTable "+
                      "  on CRMReservation.ReservationID = DelegatedInstallmentPaymentTable.ReservationID  " +
                      " left outer join ("+ strReservationPayment +") as DelegatedTempPaymentTable "+
                      " on CRMReservation.ReservationID =  DelegatedTempPaymentTable.ReservationID " +
                      " inner join (" + strUnitMaxReservation + ") as MaxReservationTable  "+
                      " on CRMReservation.ReservationID = MaxReservationTable.MaxReservationID "+
                      " and dbo.CRMReservationUnit.UnitID = MaxReservationTable.UnitID " +
                      " WHERE     (dbo.CRMReservation.ReservationDelegationDate IS NOT NULL) "+
                      " GROUP BY dbo.CRMReservationUnit.UnitID "+
                       ",case when DelegatedInstallmentPaymentTable.TotalInstallmentPaidValue is null then 0 else DelegatedInstallmentPaymentTable.TotalInstallmentPaidValue end " +
                     "+"+
                    "case when DelegatedTempPaymentTable.TempPaymentValue is null then 0 else  DelegatedTempPaymentTable.TempPaymentValue end ";
                string strReservationCustomer = "SELECT dbo.CRMReservationCustomer.ReservationID, CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName) " +
                    " WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName) " +
                    " ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName " +
                    " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                    " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID where (1=1) ";
                if (_CustomerIDs != null && _CustomerIDs != "")
                    strReservationCustomer += " and dbo.CRMCustomer.CustomerID in ("+ _CustomerIDs +")";
                   strReservationCustomer += " group by dbo.CRMReservationCustomer.ReservationID ";
                string strCurrentReservation = "SELECT   dbo.CRMReservation.ReservationID as CurrentReservationID, ReservationDate, ReservationContractingDate" +
                    ",   dbo.CRMReservation.ReservationDeliveryDate as  CurrentReservationDeliveryDate, CustomerTable.CustomerFullName " +
                    ",TempPaymentTable.TempPaymentValue,   dbo.CRMReservation.ReservationStatus  " +
                    ", dbo.CRMReservationTenancy.ReservationID AS ReservationTenancyID, dbo.CRMReservationTenancy.ReservationTenancyEndDate "+
                       " FROM  dbo.CRMReservation " +
                       " inner join (" + strReservationCustomer + ") as CustomerTable " +
                       " on CRMReservation.ReservationID = CustomerTable.ReservationID " +
                       " left outer join (" + strReservationPayment + ") as TempPaymentTable " +
                       " on CRMReservation.ReservationID = TempPaymentTable.ReservationID  "+
                       " left outer join   dbo.CRMReservationTenancy  "+
                       " ON dbo.CRMReservation.ReservationID = dbo.CRMReservationTenancy.ReservationID  ";
                if (_IsReservationDateRange)
                {
                    double dblStartDate,dblEndDate;
                    dblStartDate = SysUtility.Approximate(_ReservationStartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndDate = SysUtility.Approximate(_ReservationEndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    strCurrentReservation += "  where  dbo.CRMReservation.ReservationDate >= "+ dblStartDate + 
                        " and  dbo.CRMReservation.ReservationDate < "+dblEndDate ;
                }

                string strDefaltUnitPrice = "SELECT        dbo.CRMUnit.UnitID,dbo.CRMProjectUnitTypeUnitPrice.TypeUnitPriceUnitPrice, dbo.CRMUnit.UnitSurvey * dbo.CRMProjectUnitTypeUnitPrice.TypeUnitPriceUnitPrice AS ProjectDefalutPrice " +
                    " FROM            (SELECT        ProjectID, UnitType, TypeUnitPriceValidFrom, TypeUnitPriceValidTo, MAX(ProjectUnitTypeID) AS MaxUnitPriceID "+
                           " FROM            dbo.CRMProjectUnitTypeUnitPrice AS CRMProjectUnitTypeUnitPrice_1 "+
                           " GROUP BY ProjectID, UnitType, TypeUnitPriceValidFrom, TypeUnitPriceValidTo "+
                           " HAVING        (TypeUnitPriceValidFrom < GETDATE()) AND (TypeUnitPriceValidTo IS NULL) OR "+
                           " (TypeUnitPriceValidFrom < GETDATE()) AND (TypeUnitPriceValidTo > GETDATE())) AS derivedtbl_1 INNER JOIN "+
                           " dbo.CRMProjectUnitTypeUnitPrice ON derivedtbl_1.ProjectID = dbo.CRMProjectUnitTypeUnitPrice.ProjectID AND derivedtbl_1.MaxUnitPriceID = dbo.CRMProjectUnitTypeUnitPrice.ProjectUnitTypeID AND  "+
                           " derivedtbl_1.UnitType = dbo.CRMProjectUnitTypeUnitPrice.UnitType INNER JOIN "+
                           " dbo.CRMUnit ON derivedtbl_1.UnitType = dbo.CRMUnit.UnitType INNER JOIN  "+
                           " (SELECT        CRMUnit_1.UnitID, MAX(dbo.RPCell.CellFamilyID) AS MaxCellFamilyID "+
                            " FROM            dbo.CRMUnit AS CRMUnit_1 INNER JOIN "+
                            " dbo.CRMUnitCell ON CRMUnit_1.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                             " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID "+
                            " GROUP BY CRMUnit_1.UnitID) AS derivedtbl_2 ON dbo.CRMUnit.UnitID = derivedtbl_2.UnitID AND derivedtbl_1.ProjectID = derivedtbl_2.MaxCellFamilyID ";

                if (!_PriceDateRange)
                {
                    _PriceDateStart = DateTime.Now;
                    _PriceDateEnd = DateTime.Now;
                }
                string strUnitPriceDate = @"SELECT        derivedtbl_1.UnitID, CRMUnitPrice_1.UnitPriceDateStr
FROM            (SELECT        UnitID, MAX(PriceID) AS MaxPriceID
                           FROM            dbo.CRMUnitPrice
                           GROUP BY UnitID) AS derivedtbl_1 INNER JOIN
                         dbo.CRMUnitPrice AS CRMUnitPrice_1 ON derivedtbl_1.UnitID = CRMUnitPrice_1.UnitID AND derivedtbl_1.MaxPriceID = CRMUnitPrice_1.PriceID
WHERE        (CRMUnitPrice_1.UnitPriceDateStr >= '"+_PriceDateStart.ToString("yyyyMMdd")+@"') AND (CRMUnitPrice_1.UnitPriceDateStr <= '"+ _PriceDateEnd.ToString("yyyyMMdd") + @"')";
                string strUnitEvaluation = "";
              
                strUnitEvaluation = @"SELECT        UnitID AS EvaluationUnitID, UnitNumericEvaluation
FROM            dbo.CRMUnitNumericalEvaluation";
                string strUnitPrice = "SELECT     distinct   derivedtbl_1.MainUnitID"+
                    ", CASE WHEN SUM(CRMUnit_2.UnitSurvey) = 0 THEN 0 ELSE (derivedtbl_1.UnitSurvey * dbo.CRMReservation.ReservationCachePrice / SUM(CRMUnit_2.UnitSurvey))  " +
                     " END AS UnitPrice " +
                     " FROM            ("+
                     "SELECT DISTINCT dbo.CRMUnit.UnitID AS MainUnitID, dbo.CRMReservationUnit.UnitID, CRMUnit_1.UnitSurvey, dbo.CRMUnit.CurrentReservation AS MainReservation " +
                       " FROM            dbo.CRMReservationUnit INNER JOIN " +
                       " dbo.CRMUnit ON dbo.CRMReservationUnit.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN " +
                       " dbo.CRMUnit AS CRMUnit_1 ON dbo.CRMReservationUnit.UnitID = CRMUnit_1.UnitID"+
                       ") AS derivedtbl_1 INNER JOIN " +
                      " dbo.CRMUnit AS CRMUnit_2 ON derivedtbl_1.UnitID = CRMUnit_2.UnitID INNER JOIN " +
                     " dbo.CRMReservation ON derivedtbl_1.MainReservation = dbo.CRMReservation.ReservationID " +
                    " GROUP BY derivedtbl_1.MainUnitID, derivedtbl_1.MainReservation, dbo.CRMReservation.ReservationCachePrice, derivedtbl_1.UnitSurvey ";

                string strReservationBonus = "SELECT ReservationBonusTable.ReservationID,SUM(ReservationBonusTable.TotalValue) AS TotalValue "+
              " FROM( "+
              " SELECT        ReservationID, SUM(BonusValue) AS TotalValue "+
              " FROM            dbo.CRMReservationBonus "+
              " GROUP BY ReservationID "+
              " union all "+
              " SELECT        ReservationID, SUM(UtilityValue) AS TotalValue "+
              " FROM            dbo.CRMReservationUtility "+
              " GROUP BY ReservationID "+
              " union all "+
              " SELECT        ReservationID, SUM(- (1 * DiscountValue)) AS TotalValue "+
              " FROM            dbo.CRMReservationDiscount "+
              " GROUP BY ReservationID) AS ReservationBonusTable "+
              " GROUP BY ReservationBonusTable.ReservationID "+
               "";



                strUnitPrice = "SELECT  dbo.CRMUnit.CurrentReservation, MAX(dbo.CRMUnit.UnitID) AS MaxUnitID" +
                    ", case when dbo.CRMReservationTenancy.ReservationID is null then dbo.CRMReservation.ReservationCachePrice else 0 end  ";
                if (_IncludeBonus)
                    strUnitPrice += " + isnull( BonusTable.TotalValue,0)  ";
               strUnitPrice += "as ReservationCachePrice ";
                strUnitPrice += " FROM            dbo.CRMUnit INNER JOIN " +
                               @" dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID 
  LEFT OUTER JOIN
                  dbo.CRMReservationTenancy ON dbo.CRMReservation.ReservationID = dbo.CRMReservationTenancy.ReservationID ";
                if (_IncludeBonus)
                    strUnitPrice += " left outer join ("+ strReservationBonus +") BonusTable "+
                        " on CRMReservation.ReservationID = BonusTable.ReservationID  ";
                strUnitPrice += " GROUP BY dbo.CRMUnit.CurrentReservation, dbo.CRMReservation.ReservationCachePrice,dbo.CRMReservationTenancy.ReservationID ";
                if (_IncludeBonus)
                    strUnitPrice += ", BonusTable.TotalValue ";
                strUnitPrice += " HAVING        (dbo.CRMUnit.CurrentReservation > 0) ";

                // strUnitPrice = "select 0 as MainUnitID,0 as Unitprice ";

                if (_ResubmissionTypeIDs == null)
                    _ResubmissionTypeIDs = "";
                string strResubmissionType = @"SELECT DISTINCT ResubmissionUnit
FROM(
SELECT        ResubmissionUnit 
FROM            dbo.CRMUnitResubmission
WHERE        (ResubmissionType IN ("+ _ResubmissionTypeIDs + @"))  AND (ResubmissionEndDate IS NULL OR
                         ResubmissionEndDate > GETDATE())
union 
SELECT        dbo.CRMUnit.UnitID
FROM            dbo.CRMReservationResubmission INNER JOIN
                         dbo.CRMUnit ON dbo.CRMReservationResubmission.ResubmissionReservation = dbo.CRMUnit.CurrentReservation
WHERE        (dbo.CRMReservationResubmission.ResubmissionType IN (" + _ResubmissionTypeIDs+@")) AND (dbo.CRMUnit.CurrentReservation <> 0) AND (dbo.CRMReservationResubmission.ResubmissionEndDate IS NULL OR
                         dbo.CRMReservationResubmission.ResubmissionEndDate > GETDATE())) AS ResubmissionTable ";

                string strCellIDs = _CellIDs != null && _CellIDs.Trim() != "" && _CellIDs != "0" ? _CellIDs :
                  (_CellFamilyIDs != null && _CellFamilyIDs.Trim() != "" && _CellFamilyIDs != "0" ? _CellFamilyIDs : "");

                string strCellTable = @" WITH celltable (CellID,CellNameA,CelllNameE,CellAlterName)
AS
(
SELECT CellID,CellNameA,CellNameE,CellAlterName FROM dbo.RPCell
WHERE CellID IN (" + strCellIDs + @")
UNION ALL	
SELECT RPCell.CellID,RPCell.CellNameA,RPCell.CellNameE,RPCell.CellAlterName
FROM rpcell INNER JOIN celltable ON dbo.RPCell.CellParentID = celltable.CellID
AND dbo.RPCell.CellID <> celltable.CellID

)
";
                strCellIDs = "";
                string Returned = "";
                if (strCellIDs != "")
                {
                    Returned += strCellTable;
                }

                Returned += @" SELECT distinct CRMUnit.UnitID, UnitCode ,UnitFullName, UnitNameA, UnitNameE ,UnitSurvey,UnitHeight, UnitModel, CASE WHEN CRMUnit.CurrentReservation = 0 AND (
UnitClosedPermanent = 1 OR
                         (CRMUnit.UnitUserClosed > 0 AND UnitTimeOpen > GetDate())
						 ) THEN CRMUnit.UnitUserClosed ELSE 0 END AS  UnitUserClosed" +
                    ", UnitTimeOpen,UnitType,UnitClosedPermanent,CRMUnit.UnitDeliveryDate" +
                    " , dbo.CRMUnit.UnitHasElectricityMeter, dbo.CRMUnit.UnitElectricityMeterStartDate, dbo.CRMUnit.UnitElectricityMeterOwner, dbo.CRMUnit.UnitElectricityMeterStatus, " +
                      " dbo.CRMUnit.UnitElectricityMeterIllegalAction, dbo.CRMUnit.UnitElecticityMeterNotes " +
                      ",CRMUnit.UnitDesc,CRMUnit.UnitOrder " +
                      ",EvaluationTable.* " +
                      ",UnitTypeTable.* " +
                    ",Case when CRMUnit.CurrentReservation <> 0 then 2 " +//Reserved 
                                            " else (case when   UnitClosedPermanent = 1 then 3 " +//Closed Permanently
                                            " when (UnitUserClosed is not null and  UnitTimeOpen is not null and UnitTimeOpen >GetDate()) then 4 " + // Closed Temp
                                            " else 1 end)end  as UnitStatus  " + // free
                                            ", DATEDIFF(day, GETDATE(), UnitTimeOpen) AS RemainingDay" +
                                            ", DATEDIFF(Hour, GETDATE(), UnitTimeOpen) AS RemainingHour" +
                                            ", DATEDIFF(minute, GETDATE(), UnitTimeOpen) AS RemainingMinute" +
                                             ",UnitCloseReason" +
                                             ",  UnitIsReadyForDelivery, UnitReadyForDeliveryDate " +
                                             ", CRMUnit.CurrentReservation,ModelTable.*,DelegationTable.*" +
                                            //",UnitCelltable.MaxCellOrder,UnitCellTable.MaxCellID,UnitCellTable.MinCellID,UnitCelltable.MaxCellFamilyID,UnitCellTable.MaxEstimatedDeliveryDate,UnitCellTable.MaxDeliveryDate   " +
                                            ",UnitCellTable.* " +
                                            ",CurrentReservationTable.* " +
                                            ",case when PeripheralTable.PeripheralCount is null then '' " +
                                                " when PeripheralTable.PeripheralCount >2 then PeripheralTable.MaxTypeName + '-' + convert(varchar(10),MaxPeripheralSurvey)  +'&..&' + MinTypeName +'-' + convert(varchar(10),MinPeripheralSurvey) " +
                                                 " when PeripheralTable.PeripheralCount =2 then PeripheralTable.MaxTypeName +'-' + convert(varchar(10),MaxPeripheralSurvey)  +'&' + MinTypeName +'-' + convert(varchar(10),MinPeripheralSurvey) " +
                                                   " when PeripheralTable.PeripheralCount =1 then PeripheralTable.MaxTypeName +'-' +convert(varchar(10), MaxPeripheralSurvey)  end as PeripheralDesc " +
                                                   ",ViewTable.*,UsageTypeTable.*,MainTypeTable.* " +
                                                   ",CategoryTable.* " +
                                                   ",CRMUnit.UnitNeighbor1,CRMUnit.UnitNeighbor2,CRMUnit.UnitNeighbor3,CRMUnit.UnitNeighbor4 " +
                                                   ",CRMUnit.UnitView,CRMUnit.UnitMainType,CRMUnit.UnitUsageType " +
                                                   ",case when isnull(   dbo.CRMUnit.UnitPricePerMeter,0) = 0 then isnull(ProjectPriceTable.TypeUnitPriceUnitPrice,0) else dbo.CRMUnit.UnitPricePerMeter  end as UnitSalesPrice " +
                                                   ",case when isnull(   dbo.CRMUnit.UnitPricePerMeter,0) = 0 then isnull(ProjectPriceTable.ProjectDefalutPrice,0) else dbo.CRMUnit.UnitPricePerMeter * UnitSurvey  end as TotalUnitSalesPrice " +
                                 ",case when UnitPriceTable.CurrentReservation is not null and UnitPriceTable.MaxUnitID = CRMUnit.UnitID  then  isnull(UnitPriceTable.ReservationCachePrice,0) else 0 end as UnitCachPrice  " +
                                 ",case when CurrentReservationID is not null and ReservationContractingDate is not null and dbo.GetApproximateDate(ReservationDate)<=dbo.GetApproximateDate(ReservationContractingDate) then 1 else 0 end as IsContracted " +
                                 ",UnitFloor,UnitFloorTo,TowerTable.* ";

                Returned += @",    CASE WHEN dbo.CRMUnit.UnitClosedPermanent = 1 OR
                         (dbo.CRMUnit.UnitUserClosed > 0 AND dbo.CRMUnit.UnitTimeOpen > GetDate()) THEN 1 ELSE 0 END AS UnitIsClosed, CASE WHEN dbo.CRMUnit.UnitClosedPermanent = 1 OR
                         (dbo.CRMUnit.UnitUserClosed > 0 AND dbo.CRMUnit.UnitTimeOpen > GetDate()) THEN dbo.CRMUnit.UnitCloseTime ELSE GetDate() END AS UnitCloseDate,CRMUnit.Dis as UnitDis ";
                Returned += ",CivilPartTable.* ";

                if ( _IsCategoryGradeGrouping ||(_CategoryGrades != null && _CategoryGrades != ""))
                {
                    string strStep = "CategoryEvaluationTable.EqualStep ";
                    Returned += @",case when  EvaluationTable.UnitNumericEvaluation >= (CategoryEvaluationTable.MaxEvaluation-" + strStep + @") then 1 
when  EvaluationTable.UnitNumericEvaluation <= (CategoryEvaluationTable.MinEvaluation+" + strStep + @") then 2 
else 3 end as CategoryGrade ";
                }
                                                  Returned+= " FROM  CRMUnit  "+
                                                   @" left outer join ("+strUnitEvaluation +@") as EvaluationTable 
on CRMUnit.UnitID = EvaluationTable.EvaluationUnitID

"+
                                                   " left outer join (" + TowerDb.SearchStr  + ") as TowerTable "+
                                                   " on CRMUnit.UnitTower = TowerTable.TowerID  "+
                                                   " left outer join (" + UnitModelDb.SearchStr + ") as ModelTable on UnitModel = ModelTable.ModelID " +
                                  " left outer join (" + strDelegation +
                                  ") as DelegationTable on CRMUnit.UnitID = DelegationTable.DelegationUnitID  " +
                                  " inner join (" + strUnitCell + ") as UnitCellTable on CRMUnit.UnitID = UnitCellTable.MaxUnitID " +
                                  " LEFT OUTER JOIN  (" + new UnitTypeDb().SearchStr + ") AS UnitTypeTable  " +
                                  " ON dbo.CRMUnit.UnitType = UnitTypeTable.UnitTypeID";
                Returned += @" left outer join ("+new CivilPartDb().SearchStr+@") as CivilPartTable 
 on CRMUnit.UnitCivilPart = CivilPartTable.PartID ";
                if (_PriceDateRange)
                    Returned += " inner join ("+ strUnitPriceDate +") PriceDateTable "+
                        " on CRMUnit.UnitID = PriceDateTable.UnitID ";



                if (_ResubmissionTypeIDs != "" && _ResubmissionTypeIDs != "0")
                    Returned += " inner join ("+ strResubmissionType +") as ResubmissionTable "+
                        " on CRMUnit.UnitID = ResubmissionTable.ResubmissionUnit ";

                if (_TotalAttributeEnd > _TotalAttributeStart || (_TotalAttributeStart == _TotalAttributeEnd && _TotalAttributeStart > 0))
                    Returned += @" inner join ("+ UnitAttributeTotalPercStr   +@") as TotalAttributeTable 
 on CRMUnit.UnitID = TotalAttributeTable.UnitID ";

                if (UnitAttributeStr != "")
                    Returned += @" inner join ("+ UnitAttributeStr +@") as AttributeTable  on CRMUnit.UnitID = AttributeTable.UnitID ";
                if (strCellIDs != "")
                {
                    string strUnitCellSql = "";// strCellTable;
                    strUnitCellSql += @" SELECT DISTINCT dbo.CRMUnitCell.UnitID
FROM celltable
INNER JOIN dbo.CRMUnitCell ON dbo.CRMUnitCell.CellID = celltable.CellID";
                    Returned += "  inner join ("+ strUnitCellSql +") as UnitCellSelectedTable "+
                        " on CRMUnit.UnitID = UnitCellSelectedTable.UnitID ";
                }
                if (_IsCategoryGradeGrouping ||  (_CategoryGrades != null && _CategoryGrades != ""))
                {
                    Returned +=   @" inner join (" +new CategoryProjectEvaluationDb().SearchStr + @") CategoryEvaluationTable  
   on CRMUnit.UnitCategory = CategoryEvaluationTable.CategoryID  
 and TowerTable.ProjectID = CategoryEvaluationTable.ProjectID ";
                }
                if (_IsReservationDateRange)
                    Returned += " inner join ";
                else
                    Returned += " left outer join ";
                Returned += " (" + strCurrentReservation + ") as CurrentReservationTable  " +
                      " on CRMUnit.CurrentReservation = CurrentReservationTable.CurrentReservationID  ";

                                 Returned += " left outer join (" + UnitMainTypeDb.SearchStr + ") as MainTypeTable " +
                                  " on CRMUnit.UnitMainType = MainTypeTable.MainTypeID " +
                                  " left outer join (" + UnitUsageTypeDb.SearchStr + ") as UsageTypeTable" +
                                  " on CRMUnit.UnitUsageType = UsageTypeTable.UsageTypeID " +
                                  " left outer join (" + UnitViewDb.SearchStr + ") as ViewTable " +
                                  " on CRMUnit.UnitView = ViewTable.ViewID " +
                                  " left outer join ("+ new UnitCategoryDb().SearchStr +") as CategoryTable "+
                                  "  on CRMUnit.UnitCategory = CategoryTable.CategoryID  "+
                                  " left outer join (" + strDefaltUnitPrice + ") as ProjectPriceTable" +
                                  " on CRMUnit.UnitID = ProjectPriceTable.UnitID " +
                                   " left outer join (" + strUnitPrice + ") as UnitPriceTable " +
                                  " on CRMUnit.CurrentReservation = UnitPriceTable.CurrentReservation  " +
                                  "";
                //Returned += " inner join  VCRMUnitSelection as SelectionTable " +
                //   " on CRMUnit.UnitID = SelectionTable.UnitID ";
                if (_EndPeripheralSurvey > 0 || _PeripheralID != 0)
                    Returned += " inner join ";
                else
                    Returned += " left outer join " ;
                Returned+=" (" + strPeripheral + ") as PeripheralTable " +
                 " on CRMUnit.UnitID = PeripheralTable.PeriphiralUnit ";
                                  
                                 
                return Returned;
            }
        }

        public string SumStrSearch
        {
            get
            {
                string Returned = "";
                string strSelect = "count(UnitID) TotalCount " +
                    ",sum(case when UnitType = 0 then 1 else 0 end) as NotSpecifiedTypeCount" +
                    ",sum(case when UnitType = 1 then 1 else 0 end) as ResidentialCount" +
                    ",sum(case when UnitType = 2 then 1 else 0 end) as CommercialCount " +
                    ",sum(case when UnitType = 3 then 1 else 0 end) as EconomicalCount " +
                    ",sum(case when UnitType = 4 then 1 else 0 end) as AdministrativeCount " +
                    ",sum(case when TotalUnitSalesPrice > 0 and (CurrentReservation =0 or    ReservationStatus < 3 or ReservationTenancyID > 0  ) then 1 else 0 end ) FreeUnitPricedCount " +
                    ",sum(case when TotalUnitSalesPrice > 0 and ( CurrentReservation=0 or    ReservationStatus <3 or ReservationTenancyID > 0 ) then TotalUnitSalesPrice  else 0 end ) FreeUnitPricedValue " +
                    ",sum(case when TotalUnitSalesPrice > 0 and ( CurrentReservation = 0  or    ReservationStatus <3  or ReservationTenancyID > 0) then UnitSurvey else 0 end ) FreeUnitPricedTotalSurvey " +
                     ",sum(case when TotalUnitSalesPrice > 0  or ( CurrentReservation >0  and    ReservationStatus >=3  and isnull(ReservationTenancyID,0) = 0)  then 0 else UnitSurvey end ) FreeUnitNotPricedTotalSurvey " +
                    ",sum(case when TotalUnitSalesPrice > 0 or (CurrentReservation > 0 and    ReservationStatus >=3 and isnull(ReservationTenancyID,0) = 0 ) then 0 else 1 end ) FreeUnitNotPricedCount " +
                    " ,sum(UnitSurvey) as TotalSurvey ";


                strSelect += ",sum(case when CurrentReservationID is null or ReservationTenancyID > 0 or    ReservationStatus <3 then 0 else 1 end) TotalOccupiedCount " +
                     ",sum(case when UnitType = 0  and CurrentReservationID is not null and    ReservationStatus >=3  and   isnull(ReservationTenancyID,0) = 0 then 1 else 0 end) as NotSpecifiedTypeOccupiedCount" +
                     ",sum(case when UnitType = 1 and CurrentReservationID is not null and    ReservationStatus >=3 and   isnull(ReservationTenancyID,0) = 0 then 1 else 0 end) as OccupiedResidentialCount" +
                     ",sum(case when UnitType = 2 and CurrentReservationID is not null and    ReservationStatus >=3 and   isnull(ReservationTenancyID,0) = 0 then 1 else 0 end) as OccupiedCommercialCount " +
                     ",sum(case when UnitType = 3 and CurrentReservationID is not null and    ReservationStatus >=3 and   isnull(ReservationTenancyID,0) = 0 then 1 else 0 end) as OccupiedEconomicalCount " +
                     ",sum(case when UnitType = 4 and CurrentReservationID is not null and    ReservationStatus >=3 and   isnull(ReservationTenancyID,0) = 0 then 1 else 0 end) as OccupiedAdministrativeCount " +
                      ",sum(case when  CurrentReservationID is not null  and CurrentReservationID >0 and    ReservationStatus >=3 and   isnull(ReservationTenancyID,0) = 0 then UnitSurvey else 0 end) as TotalOccupiedSurvey " +
                      ",sum(UnitCachPrice) as TotalUnitCachPrice ";

                string strGroup = "";
                string strOrder = "";

             




                if (_IsCellTowerGrouping)
                {
                    strSelect += ",CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectName,CellTowerOrder,CellTowerName,CellTowerID";


                }
                else if (_IsProjectGrouping)
                {
                    strSelect += ",CellProjectID,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellProjectID,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectID,CellProjectName";
                }

                if (_IsModelGrouping)
                {
                    strSelect += ",ModelFamilyName, AppliedModelPrice ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ModelFamilyName, AppliedModelPrice ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ModelFamilyName";
                }
                if (_IsUnitCategoryGrouping)
                {
                    strSelect += ",CategoryNameA,CategoryNameE ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CategoryNameA,CategoryNameE ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CategoryNameA,CategoryNameE";
                }
                if (_IsCategoryGradeGrouping)
                {
                    strSelect += ",CategoryGrade ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CategoryGrade ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CategoryGrade";
                }
                //if (_IsFloorGrouping)
                //{
                //    strSelect += ",UnitFloor as Floor ";
                //    if (strGroup != "")
                //        strGroup += ",";
                //    strGroup += "UnitFloor";
                //    if (strOrder != "")
                //        strOrder += ",";
                //    strOrder += "UnitFloor";
                //}
                if (_IsFloorGrouping)
                {
                    strSelect += ",MaxCellOrder-1 as Floor ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "MaxCellOrder";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "MaxCellOrder";
                }


                if (_IsTypeGrouping)
                {
                    strSelect += ",UnitTypeID, UnitTypeNameA  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "UnitTypeID, UnitTypeNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "UnitTypeID, UnitTypeNameA";
                }
                 
                if (_IsSurveyGrouping)
                {
                    strSelect += ",UnitSurvey  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "  UnitSurvey";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "  UnitSurvey";
                }
                if (_IsUnitPriceGrouping)
                {
                    strSelect += ",UnitSalesPrice  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "  UnitSalesPrice";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "  UnitSalesPrice";
                }
                if(_IsCivilPartGroup)
                {
                    
                        strSelect += ",PartID,PartCode,PartOrder  ";
                        if (strGroup != "")
                            strGroup += ",";
                        strGroup += "  PartID,PartCode,PartOrder ";
                        if (strOrder != "")
                            strOrder += ",";
                        strOrder += " PartOrder";
                    
                }
                Returned = "select " + strSelect + " from (" + StrSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }
        public string PeripheralSearch
        {
            get
            {
                string Returned = "SELECT        dbo.CRMUnitPeripheral.PeriphiralID, dbo.CRMPeripheralType.PeripheralTypeID,dbo.CRMPeripheralType.PeripheralTypeNameA, dbo.CRMUnitPeripheral.PeriphiralUnit,dbo.CRMUnitPeripheral.PeripheralSurvey, " +
                         " dbo.CRMUnitPeripheral.PeripheralSurvey * "+
                         " case when  ISNULL(dbo.CRMUnitPeripheral.PeripheralPricePerMeter,0) = 0 then ISNULL(derivedtbl_2.PeripheralUnitPrice, 0) else dbo.CRMUnitPeripheral.PeripheralPricePerMeter end AS PeripheralTotalPrice " +
                       " ,UnitTable.* "+
                         " FROM            dbo.CRMUnitPeripheral INNER JOIN "+
                         " dbo.CRMPeripheralType ON dbo.CRMUnitPeripheral.PeriphiralType = dbo.CRMPeripheralType.PeripheralTypeID INNER JOIN "+
                         " (SELECT        dbo.CRMUnitCell.UnitID, MAX(dbo.RPCell.CellFamilyID) AS ProjectID "+
                          " FROM            dbo.CRMUnitCell INNER JOIN "+
                           " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID "+
                           " GROUP BY dbo.CRMUnitCell.UnitID) AS derivedtbl_1 ON dbo.CRMUnitPeripheral.PeriphiralUnit = derivedtbl_1.UnitID LEFT OUTER JOIN "+
                           " (SELECT        CRMProjectPeripheralUnitPrice_1.ProjectID, CRMProjectPeripheralUnitPrice_1.PeripheralType, CRMProjectPeripheralUnitPrice_1.PeripheralUnitPrice "+
                            " FROM    (SELECT        ProjectID, PeripheralType, MAX(ProjectPeripheralID) AS MaxID "+
                            " FROM     dbo.CRMProjectPeripheralUnitPrice "+
                            " WHERE  (PeripheralUnitPriceValidFrom <= GETDATE()) AND (PeripheralUnitPriceValidTo IS NULL) OR "+
                            " (PeripheralUnitPriceValidFrom <= GETDATE()) AND (PeripheralUnitPriceValidTo >= GETDATE()) "+
                           " GROUP BY ProjectID, PeripheralType) AS derivedtbl_1_1 INNER JOIN "+
                           " dbo.CRMProjectPeripheralUnitPrice AS CRMProjectPeripheralUnitPrice_1 ON derivedtbl_1_1.MaxID = CRMProjectPeripheralUnitPrice_1.ProjectPeripheralID AND  "+
                            " derivedtbl_1_1.ProjectID = CRMProjectPeripheralUnitPrice_1.ProjectID AND derivedtbl_1_1.PeripheralType = CRMProjectPeripheralUnitPrice_1.PeripheralType) AS derivedtbl_2 ON  "+
                          " dbo.CRMPeripheralType.PeripheralTypeID = derivedtbl_2.PeripheralType AND derivedtbl_1.ProjectID = derivedtbl_2.ProjectID"+
                          " inner join ("  + StrSearch + ") as UnitTable  "+
                          " on  dbo.CRMUnitPeripheral.PeriphiralUnit = UnitTable.UnitID ";
                return Returned;
            }
        }
        public string PeripheralSumStrSearch
        {
            get
            {
                string Returned = "";
                string strSelect = "count(PeriphiralID) TotalCount " +
                    ",sum(case when UnitType = 0 then 1 else 0 end) as NotSpecifiedTypeCount " +
                    ",sum(case when UnitType = 1 then 1 else 0 end) as ResidentialCount" +
                    ",sum(case when UnitType = 2 then 1 else 0 end) as CommercialCount" +
                    ",sum(case when UnitType = 3 then 1 else 0 end) as EconomicalCount " +
                    ",sum(case when UnitType = 4 then 1 else 0 end) as AdministrativeCount " +
                    ",sum(case when PeripheralTotalPrice> 0 and (CurrentReservation =0 or    ReservationStatus < 3 or ReservationTenancyID > 0) then 1 else 0 end ) FreeUnitPricedCount " +
                    ",sum(case when PeripheralTotalPrice > 0 and CurrentReservation =0 or    ReservationStatus < 3 or ReservationTenancyID > 0 then PeripheralTotalPrice  else 0 end ) FreeUnitPricedValue " +
                    ",sum(case when PeripheralTotalPrice > 0 and CurrentReservation = 0 then PeripheralSurvey else 0 end ) FreeUnitPricedTotalSurvey " +
                     ",sum(case when PeripheralTotalPrice > 0  or CurrentReservation >0   then 0 else PeripheralSurvey end ) FreeUnitNotPricedTotalSurvey " +
                    ",sum(case when PeripheralTotalPrice > 0 or CurrentReservation > 0 then 0 else 1 end ) FreeUnitNotPricedCount " +
                     " ,sum(PeripheralSurvey) as TotalSurvey ";


                strSelect += ",sum(case when CurrentReservationID is null then 0 else 1 end) TotalOccupiedCount " +
                     ",sum(case when UnitType = 0  and CurrentReservationID is not null and    ReservationStatus >=3 then 1 else 0 end) as NotSpecifiedTypeOccupiedCount" +
                     ",sum(case when UnitType = 1 and CurrentReservationID is not null and    ReservationStatus >=3 then 1 else 0 end) as OccupiedResidentialCount" +
                     ",sum(case when UnitType = 2 and CurrentReservationID is not null and    ReservationStatus >=3 then 1 else 0 end) as OccupiedCommercialCount " +
                     ",sum(case when UnitType = 3 and CurrentReservationID is not null and    ReservationStatus >=3 then 1 else 0 end) as OccupiedEconomicalCount " +
                     ",sum(case when UnitType = 4 and CurrentReservationID is not null and    ReservationStatus >=3 then 1 else 0 end) as OccupiedAdministrativeCount " +
                      ",sum(case when  CurrentReservationID is not null  and CurrentReservationID >0 then PeripheralSurvey else 0 end) as TotalOccupiedSurvey " +
                      ",sum(0) as TotalUnitCachPrice ";

                string strGroup = "";
                string strOrder = "";





                if (_IsCellTowerGrouping)
                {
                    strSelect += ",CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectName,CellTowerOrder,CellTowerName,CellTowerID";


                }
                else if (_IsProjectGrouping)
                {
                    strSelect += ",CellProjectID,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellProjectID,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectID,CellProjectName";
                }

                if (_IsModelGrouping)
                {
                    strSelect += ",ModelFamilyName, AppliedModelPrice ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ModelFamilyName, AppliedModelPrice ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ModelFamilyName";
                }
                if (_IsFloorGrouping)
                {
                    strSelect += ",MaxCellOrder-1 as Floor";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "MaxCellOrder";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "MaxCellOrder";
                }

                if (_IsTypeGrouping)
                {
                    strSelect += ",PeripheralTypeID as  UnitTypeID,PeripheralTypeNameA as  UnitTypeNameA  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PeripheralTypeID, PeripheralTypeNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "PeripheralTypeID, PeripheralTypeNameA";
                }

                if (_IsSurveyGrouping)
                {
                    strSelect += ",PeripheralSurvey  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "  PeripheralSurvey";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "  PeripheralSurvey";
                }

                Returned = "select " + strSelect + " from (" + PeripheralSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }
        public string PeripheralSumStrSearch1
        {
            get
            {
                string Returned = "";
                string strSelect = "count(PeriphiralID) TotalCount " +
                    ",sum(0) as NotSpecifiedTypeCount" +
                    ",sum(0) as ResidentialCount" +
                    ",sum(0) as CommercialCount " +
                    ",sum(0) as EconomicalCount " +
                    ",sum(0) as AdministrativeCount " +
                    ",sum(case when PeripheralTotalPrice> 0 and CurrentReservation =0 then 1 else 0 end ) FreeUnitPricedCount " +
                    ",sum(case when PeripheralTotalPrice > 0 and CurrentReservation=0 then PeripheralTotalPrice  else 0 end ) FreeUnitPricedValue " +
                    ",sum(case when PeripheralTotalPrice > 0 and CurrentReservation = 0 then PeripheralSurvey else 0 end ) FreeUnitPricedTotalSurvey " +
                     ",sum(case when PeripheralTotalPrice > 0  or CurrentReservation >0   then 0 else PeripheralSurvey end ) FreeUnitNotPricedTotalSurvey " +
                    ",sum(case when PeripheralTotalPrice > 0 or CurrentReservation > 0 then 0 else 1 end ) FreeUnitNotPricedCount " +
                     " ,sum(PeripheralSurvey) as TotalSurvey ";


                strSelect += ",sum(case when CurrentReservationID is null then 0 else 1 end) TotalOccupiedCount " +
                     ",sum(0) as NotSpecifiedTypeOccupiedCount" +
                     ",sum(0) as OccupiedResidentialCount" +
                     ",sum(0) as OccupiedCommercialCount " +
                     ",sum(0) as OccupiedEconomicalCount " +
                     ",sum(0) as OccupiedAdministrativeCount " +
                      ",sum(case when  CurrentReservationID is not null  and CurrentReservationID >0 then PeripheralSurvey else 0 end) as TotalOccupiedSurvey " +
                      ",sum(0) as TotalUnitCachPrice ";

                string strGroup = "";
                string strOrder = "";





                if (_IsCellTowerGrouping)
                {
                    strSelect += ",CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellTowerID,CellTowerName,CellTowerOrder,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectName,CellTowerOrder,CellTowerName,CellTowerID";


                }
                else if (_IsProjectGrouping)
                {
                    strSelect += ",CellProjectID,CellProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellProjectID,CellProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CellProjectID,CellProjectName";
                }

                if (_IsModelGrouping)
                {
                    strSelect += ",ModelFamilyName, AppliedModelPrice ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ModelFamilyName, AppliedModelPrice ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ModelFamilyName";
                }
                if (_IsFloorGrouping)
                {
                    strSelect += ",UnitFloor as Floor ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "UnitFloor";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "UnitFloor";
                }

                if (_IsTypeGrouping)
                {
                    strSelect += ",PeripheralTypeID as  UnitTypeID,PeripheralTypeNameA as  UnitTypeNameA  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PeripheralTypeID, PeripheralTypeNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "PeripheralTypeID, PeripheralTypeNameA";
                }

                if (_IsSurveyGrouping)
                {
                    strSelect += ",PeripheralSurvey  ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "  PeripheralSurvey";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "  PeripheralSurvey";
                }

                Returned = "select " + strSelect + " from (" + PeripheralSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }
        public string SumStrSearch1
        {
            get
            {
                string Returned = "";
                string strSelect = "count(UnitID) TotalCount " +
                    ",sum(case when UnitType = 0 then 1 else 0 end) as NotSpecifiedTypeCount" +
                    ",sum(case when UnitType = 1 then 1 else 0 end) as ResidentialCount" +
                    ",sum(case when UnitType = 2 then 1 else 0 end) as CommercialCount " +
                    ",sum(case when UnitType = 3 then 1 else 0 end) as EconomicalCount "+
                    ",sum(case when UnitType = 4 then 1 else 0 end) as AdministrativeCount ";


                strSelect += ",sum(case when CurrentReservationID is null then 0 else 1 end) TotalOccupiedCount " +
                     ",sum(case when UnitType = 0  and CurrentReservationID is not null then 1 else 0 end) as NotSpecifiedTypeOccupiedCount" +
                     ",sum(case when UnitType = 1 and CurrentReservationID is not null then 1 else 0 end) as OccupiedResidentialCount" +
                     ",sum(case when UnitType = 2 and CurrentReservationID is not null then 1 else 0 end) as OccupiedCommercialCount " +
                     ",sum(case when UnitType = 3 and CurrentReservationID is not null then 1 else 0 end) as OccupiedEconomicalCount " +
                     ",sum(case when UnitType = 4 and CurrentReservationID is not null then 1 else 0 end) as OccupiedAdministrativeCount ";

                string strGroup = "";
                string strOrder = "";



              

                if (_IsCellTowerGrouping)
                {
                    strSelect += ",CellTowerID,CellTowerName,CellTowerOrder,ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellTowerID,CellTowerName,CellTowerOrder,ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName,CellTowerOrder,CellTowerName,CellTowerID";


                }
                else if (_IsProjectGrouping)
                {
                    strSelect += ",ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName";
                }

                if (_IsModelGrouping)
                {
                    strSelect += ",ModelFamilyName, AppliedModelPrice ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ModelFamilyName, AppliedModelPrice ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ModelFamilyName";
                }
                if (_IsFloorGrouping)
                {
                    strSelect += ",MaxCellOrder as Floor ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "MaxCellOrder";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "MaxCellOrder";
                }

                Returned = "select " + strSelect + " from (" + StrSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }

        #region Public Property For caching
        public static DataTable CachUnitCellTable
        {
            set
            {
                _CachUnitCelltable = value;
            }
            get
            {
                if (_CachUnitCelltable == null
                    && _CachUnitIDs != null && _CachUnitIDs != "")
                {
                    UnitCellDb objDb = new UnitCellDb();
                    objDb.UnitIDs = _CachUnitIDs;
                    _CachUnitCelltable = objDb.Search();
                }
                return _CachUnitCelltable;
            }
        }
        public static string CachUnitIDs
        {
            set
            {
                _CachUnitIDs = value;
            }
        }
        public bool IsDelegated
        {
            get
            {
                return _IsDelegated;
            }
        }
        public bool IsForReReservation
        {
            get
            {
                return _IsForReReservation;
            }
        }

        public static DataTable CachReservationDataTable
        {
            set
            {
                _CachReservationTable = value;
            }
            get
            {
                if (_CachReservationTable == null)
                    _CachReservationTable = new DataTable();
                return _CachReservationTable;
            }

        }
        public static DataTable CachUserDatatable
        {
            set
            {
                _CachUserTable = value;
            }
            get
            {
                return _CachUserTable;
            }
        }
        #endregion
        #region public property for Grouping
        public bool IsCellTowerGrouping
        {
            set
            {
                _IsCellTowerGrouping = value;
            }
        }
        public bool IsProjectGrouping
        {
            set
            {
                _IsProjectGrouping = value;
            }
        }
        public bool IsTypeGrouping
        {
            set
            {
                _IsTypeGrouping = value;
            }
        }
        public bool IsStatusGrouping
        {
            set
            {
                _IsStatusGrouping = value;
            }
        }
        int _CivilPart;
        public int CivilPart
        {
            set => _CivilPart = value;
            get => _CivilPart;
        }

        string _CivilPartCode;
        public string CivilPartCode
        { set => _CivilPartCode = value; get => _CivilPartCode; }
        bool _IsCivilPartGroup;
        public bool IsCivilPartGroup { set => _IsCivilPartGroup = value; }
        public bool IsDeliveredStatusGrouping
        {
            set
            {
                _IsDeliveredStatusGrouping = value;
            }
        }
        public bool IsCellTowerDeliveredStatusGrouping
        {
            set
            {
                _IsCellTowerDeliveredStatusGrouping = value;
            }
        }
        public bool IsSurveyGrouping 
        {
            set
            {
                _IsSurveyGrouping = value;
            }
        }
        public bool IsModelGrouping
        {
            set
            {
                _IsModelGrouping = value;
            }
        }
        public bool IsFloorGrouping
        {
            set
            {
                _IsFloorGrouping = value;
            }
        }

        public double StartPrice { get => _StartPrice; set => _StartPrice = value; }
        public double EndPrice { get => _EndPrice; set => _EndPrice = value; }
        #endregion
        #endregion
        #region Private Methods
        void JoinCell()
        {
            if (_CellTable == null)
                return;
            string[] arrStr = new string[_CellTable.Rows.Count + 1];
            arrStr[0] = "delete from CRMUnitCell where UnitID=" + _ID;
            for (int intIndex = 0; intIndex < _CellTable.Rows.Count; intIndex++)
            {
                arrStr[intIndex+1] = "insert into CRMUnitCell (UnitID,CellID,UnitPartSurvey,UnitOrder) values(" + _ID + "," + _CellTable.Rows[intIndex]["Cell"]
                    + "," + _CellTable.Rows[intIndex]["Survey"].ToString() + "," + _CellTable.Rows[intIndex]["Order"].ToString() + ")";
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinPeripheral()
        {
            if (_PeripheralTable  == null && _DeletedPeripheralTable == null)
                return;
            int intRowCount = _DeletedPeripheralTable == null || _DeletedPeripheralTable.Rows.Count == 0 ? 0 : 1;
            intRowCount += _PeripheralTable == null ? 0 : _PeripheralTable.Rows.Count;

            string[] arrStr = new string[intRowCount];
            int intStart = 0;
            if(_DeletedPeripheralTable != null&& _DeletedPeripheralTable.Rows.Count!= 0)
            {
            string strIDs = SysUtility.GetStringArr(_DeletedPeripheralTable,"PeriphiralID",500)[0];
            arrStr[0] = "delete from CRMUnitPeripheral where PeriphiralUnit=" + _ID + " and PeriphiralID in (" + strIDs + ")";
            intStart = 1;
            }
            UnitPeripheralDb objDb;
            foreach (DataRow objDr in _PeripheralTable.Rows)
            {
                objDb = new UnitPeripheralDb(objDr);
                objDb.Unit = ID;
                if(objDb.ID == 0)
                arrStr[intStart] = objDb.AddStr;
                else
                arrStr[intStart] = objDb.EditStr;
            intStart++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["UnitID"] == null)
            {
                SetSumData(objDr);
                return;
            }
            if ( objDr["UnitSurvey"] == DBNull.Value)
            {
                _ReservationDb = new ReservationDb();
                _ModelDb = new UnitModelDb();
                return;
            }
            _ID = int.Parse(objDr["UnitID"].ToString());
            _NameA = objDr["UnitNameA"].ToString();
            _NameE = objDr["UnitNameE"].ToString();
            _FullName = objDr["UnitFullName"].ToString();
            if (objDr.Table.Columns["UnitCode"] != null)
                _Code = objDr["UnitCode"].ToString();
            if(objDr.Table.Columns["UnitSurvey"]!= null && objDr["UnitSurvey"].ToString()!= "")
            _Survey = double.Parse(objDr["UnitSurvey"].ToString());

            if (objDr.Table.Columns["UnitHeight"] != null && objDr["UnitHeight"].ToString() != "")
                _Height = double.Parse(objDr["UnitHeight"].ToString());
            if(objDr.Table.Columns["UnitModel"]!= null&& objDr["UnitModel"].ToString()!= "")
            _ModelID = int.Parse(objDr["UnitModel"].ToString());
            if(objDr.Table.Columns["UnitStatus"]!= null&& objDr["UnitStatus"].ToString()!= "")
            _UnitStatus = int.Parse(objDr["UnitStatus"].ToString());
            if(objDr.Table.Columns["CurrentReservation"] != null && objDr["CurrentReservation"].ToString()!= "")
            _Reservation = int.Parse(objDr["CurrentReservation"].ToString());
            //UnitUserClosed, UnitTimeOpen, UnitClosedPermanent  "+
            if(objDr.Table.Columns["UnitUserClosed"] != null && objDr["UnitUserClosed"].ToString()!= "")
            _UserClosed = int.Parse(objDr["UnitUserClosed"].ToString());

            if (objDr.Table.Columns["UnitUserClosed1"] != null && objDr["UnitUserClosed1"].ToString() != "")
                _UserClosed = int.Parse(objDr["UnitUserClosed1"].ToString());
            if (objDr.Table.Columns["UnitIsClosed"] != null)
                _IsClosed = objDr["UnitIsClosed"].ToString() == "1";
            if (objDr.Table.Columns["UnitCloseDate"] != null)
                DateTime.TryParse(objDr["UnitCloseDate"].ToString(), out _CloseDate);
            if (objDr.Table.Columns["UnitCloseReason"]!= null)
            _CloseReason = objDr["UnitCloseReason"].ToString();
            if(objDr.Table.Columns["UnitType"]!= null&& objDr["UnitType"].ToString()!= "")
            _UnitType = int.Parse(objDr["UnitType"].ToString());
            if(objDr.Table.Columns["UnitDesc"]!= null)
            _Desc = objDr["UnitDesc"].ToString();

            if (objDr.Table.Columns["UnitOrder"] != null && objDr["UnitOrder"].ToString() != "")
                _Order = int.Parse(objDr["UnitOrder"].ToString());
            if (_ModelID != 0)
                _ModelDb = new UnitModelDb(objDr);
            else
                _ModelDb = new UnitModelDb();
            if (objDr.Table.Columns["RemainingDay"]!= null && objDr["RemainingDay"].ToString() != "")
                _RemainingDay = int.Parse(objDr["RemainingDay"].ToString());
            if (objDr.Table.Columns["RemainingHour"]!= null && objDr["RemainingHour"].ToString() != "")
                _RemainingHour = int.Parse(objDr["RemainingHour"].ToString());
            if (objDr.Table.Columns["RemainingMinute"]!= null && objDr["RemainingMinute"].ToString() != "")
                _RemainingMinute = int.Parse(objDr["RemainingMinute"].ToString());
            _IsDelegated = false;
            _IsForReReservation = false;
            if (objDr.Table.Columns["UnitDelegationCount"] != null && objDr["UnitDelegationCount"].ToString() != "")
            {
                if (objDr["UnitForReReservationCount"].ToString() != "0")
                    _IsForReReservation = true;
                else
                    _IsDelegated = true; 
            }
            _IsDelivered = false;
            if (objDr.Table.Columns["UnitDeliveryDate"] != null && objDr["UnitDeliveryDate"].ToString() != "")
            {
                _IsDelivered = true;
                _DeliveryDate = DateTime.Parse(objDr["UnitDeliveryDate"].ToString());

            }
            if (objDr.Table.Columns["UnitHasElectricityMeter"]!= null&& objDr["UnitHasElectricityMeter"].ToString() != "")
                _HasElectricityMeter = bool.Parse(objDr["UnitHasElectricityMeter"].ToString());
            if (objDr.Table.Columns["UnitElectricityMeterStartDate"]!= null&& objDr["UnitElectricityMeterStartDate"].ToString() != "")
            {
                _ElectricityMeterHasStartDate = true;
                _ElectricityMeterStartDate = DateTime.Parse(objDr["UnitElectricityMeterStartDate"].ToString());
            }
          
            if (objDr.Table.Columns["UnitElectricityMeterOwner"]!= null)
             _ElectricityMeterOwner = objDr["UnitElectricityMeterOwner"].ToString();
            if (objDr.Table.Columns["UnitElectricityMeterStatus"]!= null && 
                objDr["UnitElectricityMeterStatus"].ToString() != "")
            {
                _ElectricityMeterStatus = int.Parse(objDr["UnitElectricityMeterStatus"].ToString());
            }
            if (objDr.Table.Columns["UnitElectricityMeterIllegalAction"]!= null&&  objDr["UnitElectricityMeterIllegalAction"].ToString() != "")
            {
                _ElectricityMeterIllegalAction = int.Parse(objDr["UnitElectricityMeterIllegalAction"].ToString());
            }
            if(objDr.Table.Columns["UnitElecticityMeterNotes"]!= null)
            _ElecticityMeterNotes = objDr["UnitElecticityMeterNotes"].ToString();

            if (objDr.Table.Columns["DelegationValue"]!= null&& objDr["DelegationValue"].ToString() != "")
                _DelegationValue = double.Parse(objDr["DelegationValue"].ToString());
            if (objDr.Table.Columns["MaxCellID"] != null && objDr["MaxCellID"].ToString() != "")
                _MaxCellID = int.Parse(objDr["MaxCellID"].ToString());
            if (objDr.Table.Columns["MinCellID"] != null && objDr["MinCellID"].ToString() != "")
                _MinCellID = int.Parse(objDr["MinCellID"].ToString());
          if(objDr.Table.Columns["CustomerFullName"]!= null)
            _CustomerStr = objDr["CustomerFullName"].ToString();
            if (objDr.Table.Columns["ReservationContractingDate"]!= null && objDr["ReservationContractingDate"].ToString() != "" && DateTime.Parse(objDr["ReservationContractingDate"].ToString()) > DateTime.Parse("01-01-1910"))
            {
                _IsContracted = true;
                _ContractingDate = DateTime.Parse(objDr["ReservationContractingDate"].ToString());
            }
            if (objDr.Table.Columns["ReservationDate"]!= null&& objDr["ReservationDate"].ToString() != "")
                _ReservationDate = DateTime.Parse(objDr["ReservationDate"].ToString());
            if (objDr.Table.Columns["TempPaymentValue"]!= null&& objDr["TempPaymentValue"].ToString() != "")
                _ReservationPaidValue = double.Parse(objDr["TempPaymentValue"].ToString());
            if(objDr.Table.Columns["PeripheralDesc"]!= null )
            _PeripheralDesc = objDr["PeripheralDesc"].ToString();
            if (objDr.Table.Columns["UnitView"] != null && objDr["UnitView"].ToString() != "")
            {
                _View = int.Parse( objDr["UnitView"].ToString());
            }
            if (objDr.Table.Columns["UnitMainType"] != null && objDr["UnitMainType"].ToString() != "")
            {
                _MainType = int.Parse(objDr["UnitMainType"].ToString());
            }
            if (objDr.Table.Columns["UnitUsageType"] != null && objDr["UnitUsageType"].ToString() != "")
            {
                _UsageType = int.Parse(objDr["UnitUsageType"].ToString());
            }
            if (objDr.Table.Columns["UnitViewSap"] != null && objDr["UnitViewSap"].ToString() != "")
            {
                _SapView = objDr["UnitViewSap"].ToString();
            }
            if (objDr.Table.Columns["UnitNeighbor1"] != null )
            {
                _Neighbor1 = objDr["UnitNeighbor1"].ToString();
            }
            if (objDr.Table.Columns["UnitNeighbor2"] != null)
            {
                _Neighbor2 = objDr["UnitNeighbor2"].ToString();
            }
            if (objDr.Table.Columns["UnitNeighbor3"] != null)
            {
                _Neighbor3 = objDr["UnitNeighbor3"].ToString();
            }
              if (objDr.Table.Columns["UnitNeighbor4"] != null)
            {
                _Neighbor4 = objDr["UnitNeighbor4"].ToString();
            }
            if( objDr.Table.Columns["UnitSalesPrice"] !=null && objDr["UnitSalesPrice"].ToString()!= "")
                _UnitSalesPrice = double.Parse(objDr["UnitSalesPrice"].ToString());
            else if (objDr.Table.Columns["UnitPricePerMeter"] != null && objDr["UnitPricePerMeter"].ToString() != "")
                _UnitSalesPrice = double.Parse(objDr["UnitPricePerMeter"].ToString());
            if (objDr.Table.Columns["UnitIsReadyForDelivery"] != null)
                bool.TryParse(objDr["UnitIsReadyForDelivery"].ToString(), out _IsReadyForDelivery);
            if (_IsReadyForDelivery)
                DateTime.TryParse(objDr["UnitReadyForDeliveryDate"].ToString(), out _ReadyForDeliveryDate);
            if (objDr.Table.Columns["TowerID"] != null)
                int.TryParse(objDr["TowerID"].ToString(), out _Tower);
            if (objDr.Table.Columns["UnitFloor"] != null)
                int.TryParse(objDr["UnitFloor"].ToString(), out _Floor);
            if (objDr.Table.Columns["UnitFloorTo"] != null)
                int.TryParse(objDr["UnitFloorTo"].ToString(), out _FloorTo);

            if (objDr.Table.Columns["ReservationTenancyID"] != null)
                int.TryParse(objDr["ReservationTenancyID"].ToString(), out _TenancyID);
            if (objDr.Table.Columns["ReservationTenancyEndDate"] != null)
                DateTime.TryParse(objDr["ReservationTenancyEndDate"].ToString(), out _TenancyEndDate);
            if (objDr.Table.Columns["CurrentReservationDeliveryDate"] != null)
                DateTime.TryParse(objDr["CurrentReservationDeliveryDate"].ToString(),out _ReservationDeliveryDate);
            if (objDr.Table.Columns["CategoryGrade"] != null)
                int.TryParse(objDr["CategoryGrade"].ToString(), out _CategoryGrade);

            if (objDr.Table.Columns["CategoryID"] != null)
                int.TryParse(objDr["CategoryID"].ToString(), out _Category);
            if (objDr.Table.Columns["UnitNumericEvaluation"] != null)
                double.TryParse(objDr["UnitNumericEvaluation"].ToString(), out _NumericEvaluation);

        }
        void SetFloorData(DataRow objDr )
        {
            if (objDr.Table.Columns["MinFloorID"] != null)
                int.TryParse(objDr["MinFloorID"].ToString(), out _MinFloorID);

            if (objDr.Table.Columns["MaxFloorID"] != null)
                int.TryParse(objDr["MaxFloorID"].ToString(), out _MaxFloorID);

            if (objDr.Table.Columns["MinFloorValue"] != null)
                int.TryParse(objDr["MinFloorValue"].ToString(), out _MinFloorValue);

            if (objDr.Table.Columns["MinFloorCode"] != null)
                _MinFloorCode = objDr["MinFloorCode"].ToString();

            if (objDr.Table.Columns["MinFloorNameA"] != null)
                _MinFloorNameA = objDr["MinFloorNameA"].ToString();

            if (objDr.Table.Columns["MinFloorNameE"] != null)
                _MinFloorNameE = objDr["MinFloorNameE"].ToString();

            if (objDr.Table.Columns["MaxFloorValue"] != null)
                int.TryParse(objDr["MaxFloorValue"].ToString(), out _MaxFloorValue);

            if (objDr.Table.Columns["MaxFloorCode"] != null)
                _MaxFloorCode = objDr["MaxFloorCode"].ToString();

            if (objDr.Table.Columns["MaxFloorNameA"] != null)
                _MaxFloorNameA = objDr["MaxFloorNameA"].ToString();

            if (objDr.Table.Columns["MaxFloorNameE"] != null)
                _MaxFloorNameE = objDr["MaxFloorNameE"].ToString();
        }
        void SetSumData(DataRow objDr)
        {

            if (objDr.Table.Columns["UnitSurvey"] != null && objDr["UnitSurvey"].ToString() != "")
                _Survey = double.Parse(objDr["UnitSurvey"].ToString());
            if (objDr.Table.Columns["UnitPricePerMeter"] != null && objDr["UnitPricePerMeter"].ToString() != "")
                _PricePerMeter = double.Parse(objDr["UnitPricePerMeter"].ToString());
            if (objDr.Table.Columns["UnitModel"] != null && objDr["UnitModel"].ToString() != "")
                _ModelID = int.Parse(objDr["UnitModel"].ToString());
            if (objDr.Table.Columns["UnitStatus"] != null && objDr["UnitStatus"].ToString() != "")
                _UnitStatus = int.Parse(objDr["UnitStatus"].ToString());

            if (objDr.Table.Columns["UnitUserClosed"] != null && objDr["UnitUserClosed"].ToString() != "")
                _UserClosed = int.Parse(objDr["UnitUserClosed"].ToString());
            if (objDr.Table.Columns["UnitCloseReason"] != null)
                _CloseReason = objDr["UnitCloseReason"].ToString();
            if (objDr.Table.Columns["UnitType"] != null && objDr["UnitType"].ToString() != "")
                _UnitType = int.Parse(objDr["UnitType"].ToString());
            if (objDr.Table.Columns["UnitTypeNameA"] != null)
                _unitTypeName = objDr["UnitTypeNameA"].ToString();
            if (objDr.Table.Columns["UnitDesc"] != null)
                _Desc = objDr["UnitDesc"].ToString();

            if (objDr.Table.Columns["UnitOrder"] != null && objDr["UnitOrder"].ToString() != "")
                _Order = int.Parse(objDr["UnitOrder"].ToString());
            if (objDr.Table.Columns["UnitFloor"] != null)
                int.TryParse(objDr["UnitFloor"].ToString(), out _Floor);
            if (objDr.Table.Columns["Floor"] != null)
                int.TryParse(objDr["Floor"].ToString(), out _Floor);
            if (objDr.Table.Columns["RemainingDay"] != null && objDr["RemainingDay"].ToString() != "")
                _RemainingDay = int.Parse(objDr["RemainingDay"].ToString());
            if (objDr.Table.Columns["RemainingHour"] != null && objDr["RemainingHour"].ToString() != "")
                _RemainingHour = int.Parse(objDr["RemainingHour"].ToString());
            if (objDr.Table.Columns["RemainingMinute"] != null && objDr["RemainingMinute"].ToString() != "")
                _RemainingMinute = int.Parse(objDr["RemainingMinute"].ToString());

            _IsDelivered = false;
            if (objDr.Table.Columns["UnitDeliveryDate"] != null && objDr["UnitDeliveryDate"].ToString() != "")
            {
                _IsDelivered = true;
                _DeliveryDate = DateTime.Parse(objDr["UnitDeliveryDate"].ToString());

            }

            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerStr = objDr["CustomerFullName"].ToString();

            if (objDr.Table.Columns["PeripheralDesc"] != null)
                _PeripheralDesc = objDr["PeripheralDesc"].ToString();
            if (objDr.Table.Columns["UnitView"] != null && objDr["UnitView"].ToString() != "")
            {
                _View = int.Parse(objDr["UnitView"].ToString());
            }
            if (objDr.Table.Columns["UnitMainType"] != null && objDr["UnitMainType"].ToString() != "")
            {
                _MainType = int.Parse(objDr["UnitMainType"].ToString());
            }
            if (objDr.Table.Columns["UsageTypeNameA"] != null)
            {
                _UsageTypeName = objDr["UsageTypeNameA"].ToString();
            }
            if (objDr.Table.Columns["UnitUsageType"] != null && objDr["UnitUsageType"].ToString() != "")
            {
                _UsageType = int.Parse(objDr["UnitUsageType"].ToString());
            }

            if (objDr.Table.Columns["CategoryNameA"] != null)
                _CategoryNameA = objDr["CategoryNameA"].ToString();

            if (objDr.Table.Columns["CategoryNameE"] != null)
                _CategoryNameA = objDr["CategoryNameE"].ToString();
            if (objDr.Table.Columns["CategoryGrade"] != null&& objDr["CategoryGrade"].ToString()!="")
            {
                int.TryParse(objDr["CategoryGrade"].ToString(), out _CategoryGrade);
            }


            if (objDr.Table.Columns["CellTowerID"] != null && objDr["CellTowerID"].ToString() != "")
                _CellTower = int.Parse(objDr["CellTowerID"].ToString());

            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }

            if (objDr.Table.Columns["NotSpecifiedTypeCount"] != null && objDr["NotSpecifiedTypeCount"].ToString() != "")
            {
                _NotSpecifiedTypeCount = int.Parse(objDr["NotSpecifiedTypeCount"].ToString());
            }
            if (objDr.Table.Columns["ResidentialCount"] != null && objDr["ResidentialCount"].ToString() != "")
            {
                _ResidentialCount = int.Parse(objDr["ResidentialCount"].ToString());
            }
            if (objDr.Table.Columns["CommercialCount"] != null && objDr["CommercialCount"].ToString() != "")
            {
                _CommercialCount = int.Parse(objDr["CommercialCount"].ToString());
            }
            if (objDr.Table.Columns["EconomicalCount"] != null && objDr["EconomicalCount"].ToString() != "")
            {
                _EconomicalCount = int.Parse(objDr["EconomicalCount"].ToString());
            }
            if (objDr.Table.Columns["AdministrativeCount"] != null && objDr["AdministrativeCount"].ToString() != "")
            {
                _AdministrativeCount = int.Parse(objDr["AdministrativeCount"].ToString());
            }
            if (objDr.Table.Columns["FreeUnitPricedCount"] != null && objDr["FreeUnitPricedCount"].ToString() != "")
            {
                _FreeUnitPricedCount = int.Parse(objDr["FreeUnitPricedCount"].ToString());
            }
            if (objDr.Table.Columns["FreeUnitPricedValue"] != null && objDr["FreeUnitPricedValue"].ToString() != "")
            {
                _FreeUnitPricedValue = double.Parse(objDr["FreeUnitPricedValue"].ToString());
            }
            if (objDr.Table.Columns["FreeUnitPricedTotalSurvey"] != null && objDr["FreeUnitPricedTotalSurvey"].ToString() != "")
            {
                _FreeUnitPricedTotalSurvey = double.Parse(objDr["FreeUnitPricedTotalSurvey"].ToString());
            }
            if (objDr.Table.Columns["FreeUnitNotPricedTotalSurvey"] != null && objDr["FreeUnitNotPricedTotalSurvey"].ToString() != "")
            {
                _FreeUnitNotPricedTotalSurvey = double.Parse(objDr["FreeUnitNotPricedTotalSurvey"].ToString());
            }
            if (objDr.Table.Columns["FreeUnitNotPricedCount"] != null && objDr["FreeUnitNotPricedCount"].ToString() != "")
            {
                _FreeUnitNotPricedCount = int.Parse(objDr["FreeUnitNotPricedCount"].ToString());
            }
            if (objDr.Table.Columns["TotalOccupiedCount"] != null && objDr["TotalOccupiedCount"].ToString() != "")
            {
                _TotalOccupiedCount = int.Parse(objDr["TotalOccupiedCount"].ToString());
            }
            if (objDr.Table.Columns["NotSpecifiedTypeOccupiedCount"] != null && objDr["NotSpecifiedTypeOccupiedCount"].ToString() != "")
            {
                _NotSpecifiedTypeOccupiedCount = int.Parse(objDr["NotSpecifiedTypeOccupiedCount"].ToString());
            }
            if (objDr.Table.Columns["OccupiedResidentialCount"] != null && objDr["OccupiedResidentialCount"].ToString() != "")
            {
                _OccupiedResidentialCount = int.Parse(objDr["OccupiedResidentialCount"].ToString());
            }
            if (objDr.Table.Columns["OccupiedCommercialCount"] != null && objDr["OccupiedCommercialCount"].ToString() != "")
            {
                _OccupiedCommercialCount = int.Parse(objDr["OccupiedCommercialCount"].ToString());
            }
            if (objDr.Table.Columns["OccupiedEconomicalCount"] != null && objDr["OccupiedEconomicalCount"].ToString() != "")
            {
                _OccupiedEconomicalCount = int.Parse(objDr["OccupiedEconomicalCount"].ToString());
            }
            if (objDr.Table.Columns["OccupiedAdministrativeCount"] != null && objDr["OccupiedAdministrativeCount"].ToString() != "")
            {
                _OccupiedAdministrativeCount = int.Parse(objDr["OccupiedAdministrativeCount"].ToString());
            }
            if (objDr.Table.Columns["CellTowerName"] != null)
            {
                _CellTowerName = objDr["CellTowerName"].ToString();
            }
            if (objDr.Table.Columns["CellTowerOrder"] != null && objDr["CellTowerOrder"].ToString() != "")
            {
                _CellTowerOrder = int.Parse(objDr["CellTowerOrder"].ToString());
            }
            if (objDr.Table.Columns["CellProjectName"] != null)
            {
                _ProjectName = objDr["CellProjectName"].ToString();
            }
            if (objDr.Table.Columns["ModelFamilyName"] != null)
            {
                _ModelFamilyName = objDr["ModelFamilyName"].ToString();
            }
            if (objDr.Table.Columns["ViewID"] != null && objDr["ViewID"].ToString() != "")
                _View = int.Parse(objDr["ViewID"].ToString());
            if (objDr.Table.Columns["PartID"] != null)
                int.TryParse(objDr["PartID"].ToString(), out _CivilPart);
            if (objDr.Table.Columns["PartCode"] != null)
                _CivilPartCode = objDr["PartCode"].ToString();
            //if (objDr.Table.Columns["ViewNameA"] != null)
            //    _ViewName = objDr["ViewNameA"].ToString();
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());

            }
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
         
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
            if (objDr.Table.Columns["TotalCount"] != null && objDr["TotalCount"].ToString() != "")
            {
                _TotalCount = int.Parse(objDr["TotalCount"].ToString());
            }
            if (objDr.Table.Columns["TotalOccupiedSurvey"] != null && objDr["TotalOccupiedSurvey"].ToString() != "")
                _TotalOccupiedSurvey = double.Parse(objDr["TotalOccupiedSurvey"].ToString());
            if (objDr.Table.Columns["TotalUnitCachPrice"] != null && objDr["TotalUnitCachPrice"].ToString() != "")
                _TotalUnitCachPrice = double.Parse(objDr["TotalUnitCachPrice"].ToString());
            if (objDr.Table.Columns["TotalSurvey"] != null && objDr["TotalSurvey"].ToString() != "")
                _TotalSurvey = (int)double.Parse(objDr["TotalSurvey"].ToString());
            if (objDr.Table.Columns["CategoryID"] != null)
                int.TryParse(objDr["CategoryTypeID"].ToString(), out _Category);
            if (objDr.Table.Columns["CategoryNameA"] != null)
                _CategoryNameA = objDr["CategoryNameA"].ToString();
            if (objDr.Table.Columns["CategoryNameE"] != null)
                _CategoryNameE = objDr["CategoryNameE"].ToString();


        }
        UnitDb GetCurrentUnit(int intID)
        {
            UnitDb objUnitDb = new UnitDb();
            //objUnitDb.ID = 
            return objUnitDb;

 
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO CRMUnit (UnitNameA,UnitNameE,UnitFullName,UnitSurvey,UnitHeight,UnitPricePerMeter, UnitModel, CurrentReservation,UnitType,UnitDesc,UnitOrder,UnitUsageType,UnitCategory,UsrIns,TimIns)" +
                            " VALUES     ('"+_NameA+"','"+ _NameE + "','"+_FullName+"',"+_Survey+ "," + _Height  + "," +  _UnitSalesPrice +","+_ModelID+","+_Reservation+ ","+_UnitType+
                            ",'"+  _Desc +  "'," + _Order+ "," + _UsageType+ "," + _Category +  "," + SysData.CurrentUser.ID + ",GetDate()) ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinCell();
            JoinPeripheral();
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.ID = _ID;
            objUnitDb.InsertUnitHistory();

        }
        public override void Edit()
        {

            string strSql = " UPDATE    CRMUnit " +
                            " SET UnitNameA ='" + _NameA + "'" +
                            ",UnitNameE='" + _NameE + "'" +
                            ",UnitFullName = '" + _FullName + "'" +
                            ",UnitSurvey =" + _Survey + "" +
                            ",UnitHeight="+ _Height +
                            ",UnitPricePerMeter="+ _UnitSalesPrice +
                            ", UnitModel =" + _ModelID + "" +
                //", CurrentReservation =" + _Reservation + " " +
                            " , UnitType = " + _UnitType + "" +
                            ",UnitDesc='" + _Desc + "'" +
                            ",UnitOrder=" + _Order +
                            ",UnitView=" + _View +
                            ",UnitMainType=" + _MainType +
                            ",UnitUsageType=" + _UsageType +
                            ",UnitCategory="+_Category +
                            ",UnitNeighbor1='" + _Neighbor1 + "'" +
                            ",UnitNeighbor2='"+ _Neighbor2 + "'"+
                            ",UnitNeighbor3='" + _Neighbor3 + "'"+
                            ",UnitNeighbor4='"+_Neighbor4 +  "'"+
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() "+
                            " Where UnitID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinCell();
            JoinPeripheral();
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.ID = _ID;
            objUnitDb.InsertUnitHistory();

        }

        public void EditCurrentReservation()
        {
            if (_UnitIDs == null || _UnitIDs == "")
                _UnitIDs = _ID.ToString();
            string strSql = EditCurrentReservationStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
 
        }
        public void CloseUnit()
        {

            int intIsPermanent = _PermanentClosed ? 1 : 0;
            _EditSucceeded = false;
             
         
             string strPeriod = "";
             if (_ClosePeriod == 0)
             {
                 strPeriod = "minute,";
             }
             else if (_ClosePeriod == 1)
             {
                 strPeriod = "hour,";
             }
             else
                 strPeriod = "day,";
             int intUser = _UserClosed == 0 ? SysData.CurrentUser.ID : _UserClosed;

             string strSql = "Update CRMUnit set UnitUserClosed=" + intUser.ToString() +
                 ", UnitTimeOpen=DATEADD(" + strPeriod + _TimeClose + ", GETDATE())" +
                 ",UnitCloseReason='" + _CloseReason + "'" +
                 ",UnitCloseTime=GetDate()" +
                 ",UnitClosedPermanent=" + intIsPermanent +
                 ",UnitUserAssignedClose = "+ SysData.CurrentUser.ID +
                 " where   ( isnull(CurrentReservation,0)=0 ) and (" +
                 "(UnitUserClosed =0) or" +
                 " ((UnitClosedPermanent=0) and (UnitTimeOpen <GetDate()) )" +
                 ") ";
            if(_ID != 0)
             strSql+=" and UnitID =" + _ID + " ";
            else if (_UnitIDs!= null && _UnitIDs!= "")
             strSql += " and UnitID in(" + _UnitIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into dbo.CRMUnitCloseHistoryTimIns
(UnitID, UnitUserClosed, UnitTimeOpem, UnitClosedPermanent, UnitCloseReason, TimIns) 
SELECT     UnitID, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, UnitCloseReason,GetDate() " +
                        " FROM  dbo.CRMUnit "; ;

            if (_ID != 0)
                strSql += " where UnitID =" + _ID + "";
            else if (_UnitIDs != null && _UnitIDs != "")
                strSql += " where UnitID in(" + _UnitIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();
            _EditSucceeded = true;
        }
        public void EditDeliveryDate()
        {
            if (_UnitIDs == null || _UnitIDs == "")
                return;

            string strDeliveryDate = _IsDelivered ? (_DeliveryDate.ToOADate() - 2).ToString() : "null";
            string strSql = "update  dbo.CRMUnit "+
                  " set  UnitDeliveryDate = "+ strDeliveryDate +
                  " WHERE     (UnitID IN ("+ _UnitIDs +"))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();
        }
        public void OpenUnit()
        {
            if (_ID == 0 && (_UnitIDs == null || _UnitIDs == ""))
                return;
            _EditSucceeded = false;

            string strSql = "Update CRMUnit set UnitUserClosed=0" +
                ", UnitTimeOpen=null" +
                ", UnitClosedPermanent=0 ,UnitUserAssignedClose = 0 ";
            if (_ID != 0)
                strSql += " where UnitID in(" + _UnitIDs + ")";
            else if (_UnitIDs != null && _UnitIDs != "")
                strSql += " where UnitID in(" + _UnitIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into dbo.CRMUnitCloseHistoryTimIns
(UnitID, UnitUserClosed, UnitTimeOpem, UnitClosedPermanent, UnitCloseReason, TimIns) 
SELECT     UnitID, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, UnitCloseReason,GetDate() " +
                        " FROM  dbo.CRMUnit ";

            if (_ID != 0)
                strSql += " where UnitID in(" + _UnitIDs + ")";
            else if (_UnitIDs != null && _UnitIDs != "")
                strSql += " where UnitID in(" + _UnitIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();
            _EditSucceeded = true;
        }
        public override void Delete()
        {

            string strSql = " DELETE FROM CRMUnit Where UnitID = " + _ID + " and  CurrentReservation = 0 and not EXISTS "+
                    " (SELECT     UnitID " +
                     " FROM         dbo.CRMReservationUnit "+
                     " WHERE     (UnitID = "+ _ID +")) ";//overriden
            string strUnitID = _ID.ToString();
            strSql = @"update CRMUnit set Dis = GetDate()
where UnitID in("+strUnitID + @") and (CurrentReservation = 0) 
 select count(UnitID) from CRMUnit where UnitID in("+strUnitID+@") and Dis is not null ";

            object objResult = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            _EditSucceeded = objResult != null && objResult.ToString() != "0";
        }
        public void SaveCol()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            UnitDb objDb;
            List<string> arrStr = new List<string>();
            foreach (DataRow objDr in _UnitTable.Rows)
            {
                objDb = new UnitDb(objDr);
                arrStr.Add(objDb.EditStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        /// <summary>
        /// 0 Value
        /// 1 Perc
        /// 2 Fracture
        /// </summary>
        int _PriceValueType;
        public int PriceValueType
        {
            set => _PriceValueType = value;
        }
        public void EditPrice()
        {
            if (_UnitIDs == null || _UnitIDs == "" ||
                (_UnitSalesPrice ==0 && _PeripheralID==0))
            {
                return;
            }
            string strSql = "";
            string strPriceDate = _UnitSalesPriceDate.ToString("yyyyMMdd");
            string strUnitPricePerc = "1";
            if (_PriceValueType == 1)
                strUnitPricePerc = (_UnitSalesPrice / 100).ToString();
            else if (_PriceValueType == 2)
                strUnitPricePerc = (1 / _UnitSalesPrice).ToString();
            if (_PeripheralID == 0)
                strSql = " update dbo.CRMUnit set UnitPricePerMeter =" + _UnitSalesPrice +
                " where UnitID  in (" + _UnitIDs + ") ";
            else
            {
                if (_PriceValueType == 0)
                    strSql = @" update      dbo.CRMUnitPeripheral
  set  PeripheralPricePerMeter = " + _UnitSalesPrice + @"
WHERE        (PeriphiralUnit IN (" + _UnitIDs + @")) AND (PeriphiralType = " + _PeripheralID + ")";
                else
                {
                    strSql = @"update      dbo.CRMUnitPeripheral set PeripheralPricePerMeter= dbo.CRMUnit.UnitPricePerMeter * "+ strUnitPricePerc +@"
  FROM            dbo.CRMUnitPeripheral INNER JOIN
                         dbo.CRMUnit ON dbo.CRMUnitPeripheral.PeriphiralUnit = dbo.CRMUnit.UnitID
WHERE        (dbo.CRMUnit.UnitID IN ("+_UnitIDs+@")) AND (dbo.CRMUnitPeripheral.PeriphiralType = "+_PeripheralID+")";
                    
                }
            }
            if (_PeripheralID == 0)
                strSql += " insert into CRMUnitPrice (UnitID, UnitPrice, UnitPriceDateStr,PeripheralTypeID, UsrIns, TimIns) " +
                    "SELECT   dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitPricePerMeter,'" + strPriceDate + "', 0," + SysData.CurrentUser.ID + " AS UsrIns1, GETDATE() AS TimIns1 " +
                          " FROM            dbo.CRMUnit "+
                          " WHERE        (dbo.CRMUnit.UnitID IN (" + _UnitIDs + "))";
            else
            {
                strSql += @" insert into CRMUnitPrice (UnitID, UnitPrice, UnitPriceDateStr,PeripheralTypeID, UsrIns, TimIns) ";
                strSql += @" SELECT        PeriphiralUnit, PeripheralPricePerMeter, '"+ strPriceDate +"' AS PriceDateStr, PeriphiralType, "+ SysData.CurrentUser.ID + @" AS UsrIns, GETDATE() AS TimIns
FROM            dbo.CRMUnitPeripheral
WHERE        (PeriphiralUnit IN ("+ _UnitIDs +")) AND (PeriphiralType = "+ _PeripheralID +")";
            }

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditReadyForDelivery()
        {
            if (_UnitIDs == null || _UnitIDs == "" )
            {
                return;
            }
            int intIsReadyForDelivery = _IsReadyForDelivery ? 1 : 0;
            string strReadForDeliveryDate = _IsReadyForDelivery ?
                SysUtility.Approximate(_ReadyForDeliveryDate.ToOADate() - 2,1,ApproximateType.Down).ToString() : "NULL";
            string strSql = "" +
                " update dbo.CRMUnit set UnitIsReadyForDelivery =" + intIsReadyForDelivery +
                ", UnitReadyForDeliveryDate =" + strReadForDeliveryDate +
                " where UnitID  in (" + _UnitIDs + ") ";
           

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = StrSearch;

            //string strCountSql = "select count(*) as exp from (" + strSql + ")  AS NativeTable ";
            //_ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
            if (_MaxID == 0 && _MinID == 0)
            {
                string strCountSql = "select count(*) as exp from (" + strSql + ")  AS NativeTable ";
                _ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());

               
               
            }
            else
            {
                if (_MaxID != 0)
                    strSql += " and CRMUnit.UnitID >" + _MaxID;
                else if (_MinID != 0)
                {
                    strSql += " and CRMUnit.UnitID<" + _MinID;
                }
            }
            DataTable Returned;
            if (_ResultCount > 1500 || _MinID > 0 || _MaxID > 0 )

            {
                strSql = "select distinct top 1500 * from (" + strSql + ") as NativeTable " +
                        " ORDER BY UnitID,NativeTable.MaxCellOrder ";
                Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            }
            else
            {

                Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
                if(Returned.Rows.Count>0)
                Returned = Returned.Select("", "UnitID,MaxCellOrder").CopyToDataTable();
            }
            _CachUnitIDs = "";
            string strCurrentReservation = "";
            UnitDb objDb;
            string strUser = "";
            DataTable dtTempUser = new DataTable();
            dtTempUser.Columns.Add("UserID");
            DataRow[] arrUserDr;
            DataRow drTempUser;
            foreach (DataRow objDr in Returned.Rows)
            {
                objDb = new UnitDb(objDr);
                if (_CachUnitIDs != "")
                    _CachUnitIDs = _CachUnitIDs + ",";
                _CachUnitIDs = _CachUnitIDs + objDb.ID.ToString();
                if (objDb.Reservation != 0)
                {
                    if (strCurrentReservation != "")
                        strCurrentReservation = strCurrentReservation + ",";
                    strCurrentReservation = strCurrentReservation +
                        objDb.Reservation.ToString();
                }
                //if (objDb.UserClosed != 0)
                //{
                //    arrUserDr = dtTempUser.Select("UserID=" + objDb.UserClosed);
                //    if (arrUserDr.Length == 0)
                //    {
                //        drTempUser = dtTempUser.NewRow();
                //        drTempUser["UserID"] = objDb.UserClosed;
                //        dtTempUser.Rows.Add(drTempUser);
                //        if (strUser != "")
                //            strUser = strUser + ",";

                //        strUser = strUser + objDb.UserClosed;
 
                //    }

 
                //}
               
            }
            strUser = "";
            
            arrUserDr = Returned.Select("UnitUserClosed is not null and UnitUserClosed<>0");
            if(arrUserDr.Length>0)
              strUser = SysUtility.GetStringArr(arrUserDr, "UnitUserClosed", 2000)[0]; ;
            _CachUnitCelltable = null;
            if (strCurrentReservation != null && strCurrentReservation != "")
            {

                ReservationDb.ReservationIDs = strCurrentReservation;
                ReservationDb objReservationDb = new ReservationDb();
                objReservationDb.ActiveReservationIDs = strCurrentReservation;
                //_CachReservationTable = objReservationDb.Search();
                _CachReservationTable = null;
            }
            if (strUser != "")
            {
                UserDb objUserDb = new UserDb();
                objUserDb.IDs = strUser;
                _CachUserTable = objUserDb.Search();
            }
            else
                _CachUserTable = null;

            return Returned;
        }
        public DataTable SearchSum()
        {
            _IncludeBonus = true;
            string strSql = SumStrSearch;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable PeripheralSumSearch()
        {
            string strSql = PeripheralSumStrSearch;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetReservationUnit()
        {
            string strSql = "CRMReservationUnit.ReservationID,UnitTable.*  " +
                " CRMReservationUnit inner join (" + SearchStr + ") as UnitTable on " +
                " UnitTable.UnitID = CRMReservationUnit.UnitID  where (1=1) ";
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql += " and CRMReservationUnit.ReservationID in (" + _ReservationIDs +")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetUnitCell()
        {
            string strSql = UnitCellDb.SearchStr;
            if (_ID != 0)
                strSql = strSql + " and UnitID=" + _ID;
            if(_UnitIDs != null || _UnitIDs != "")
                strSql = strSql + " and UnitID in (" + _UnitIDs +") ";
            strSql = "select top 100 * from (" + strSql + ") as NativeTable ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditElectricityData()
        {
            if (_ElectricityTable == null || _ElectricityTable.Rows.Count ==0)
                return;
            string[] arrStr = new string[_ElectricityTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _ElectricityTable.Rows)
            {
                arrStr[intIndex] = "update CRMUnit set UnitHasElectricityMeter ="+ objDr["HasElectricityMeter"].ToString() +
                    ", UnitElectricityMeterStartDate=" + objDr["ElectricityMeterStartDate"].ToString()  +
                ", UnitElectricityMeterOwner='" + objDr["ElectricityMeterOwner"].ToString() + "'"+
                ", UnitElectricityMeterStatus=" + objDr["ElectricityMeterStatus"].ToString() +
                ", UnitElectricityMeterIllegalAction=" +  objDr["ElectricityMeterIllegalAction"].ToString() +
                ",UnitElecticityMeterNotes = '"+ objDr["ElecticityMeterNotes"].ToString() +"' "+
                " where UnitID=" + objDr["UnitID"].ToString();
                intIndex++;
 
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void InsertUnitHistory()
        {
            string strUnit = "insert into  CRMUnitHistory (UnitID, UnitFullName, UnitNameA, UnitNameE, UnitSurvey, UnitModel, UnitType, UnitDesc, UnitOrder, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, " +
                       " UnitCloseReason, UnitCloseTime, CurrentReservation, UnitDeliveryDate, UsrIns, TimIns " +
                       ")" +
                " SELECT    UnitID, UnitFullName, UnitNameA, UnitNameE, UnitSurvey, UnitModel, UnitType, UnitDesc, UnitOrder, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, " +
                      " UnitCloseReason, UnitCloseTime, CurrentReservation, UnitDeliveryDate, " + SysData.CurrentUser.ID + ",GetDate() " +
                      " FROM         dbo.CRMUnit ";

            if (_ID == 0 && (_UnitIDs == null || _UnitIDs == ""))
                strUnit += " inner join CRMTempUnitUploadUnitID on CRMUnit.UnitID = CRMTempUnitUploadUnitID.UnitID ";

            strUnit +=  " where (1=1)  ";

            if (_ID != 0)
                strUnit += " and UnitID = " + _ID;
            else if (_UnitIDs != null && _UnitIDs != "")
                strUnit += " and UnitID in (" + _UnitIDs + ") ";
            else if(_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strUnit);
        }
        public void AssignToCampaign()
        {
            string strSql = "insert into CRMCampaignCustomer (Campaign, Customer, UsrIns, TimIns) "+
                " SELECT   distinct  "+ _Campaign +"  as CampaignID1, dbo.CRMCustomer.CustomerID,"+ SysData.CurrentUser.ID +"as UsrIns,GetDate() as TimIns " +
                     " FROM            dbo.CRMCustomer INNER JOIN "+
                      " dbo.CRMReservationCustomer ON dbo.CRMCustomer.CustomerID = dbo.CRMReservationCustomer.CustomerID INNER JOIN "+
                         " dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation LEFT OUTER JOIN "+
                             "(SELECT        Customer "+
                                " FROM            dbo.CRMCampaignCustomer AS CRMCampaignCustomer_1 "+
                                " WHERE        (Campaign = "+ _Campaign +")) AS derivedtbl_1 ON dbo.CRMCustomer.CustomerID = derivedtbl_1.Customer "+
                            " WHERE        (dbo.CRMUnit.UnitID IN (" + _UnitIDs + "))  AND (derivedtbl_1.Customer IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditDesc()
        {
            if ((_Desc == null || _Desc == "")&& _ID==0)
                return;
            if (_ID == 0 && (_UnitIDs == null || _UnitIDs == ""))
                return;
            string strSql = "";
            if (_ID != 0)
            {
                strSql = "UPDATE dbo.CRMUnit SET UnitDesc = '"+ _Desc +"'"+
                        " WHERE UnitID = "+ _ID +"";
            }
            else if (_UnitIDs != null && _UnitIDs != "")
            {
                strSql = "UPDATE dbo.CRMUnit SET UnitDesc = '" + _Desc + "' + "+
                    " case when isnull(UnitDesc,'') = '' then '' else"+""+@"+'
                ' + UnitDesc end " +
                        " WHERE UnitID in  (" + _UnitIDs + ")";
 
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();
         
        }


        public void EditAreaUploadedExcel()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUpload ");
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadUnitID ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUpload";
            objCopy.WriteToServer(_UnitTable);
            string strUnitCellTower = @"SELECT        dbo.CRMUnit.UnitID,CRMUnit.UnitFullName, dbo.CRMUnit.UnitSurvey, dbo.CRMUnit.UnitOrder, dbo.RPCell.CellOrder - 1 AS Floor, RPCell_1.CellID AS TowerCellID
FROM            dbo.CRMUnit INNER JOIN
                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID";


            string strExistingUnit = @"
insert into CRMTempUnitUploadUnitID 
SELECT CRMUnit_1.UnitID,dbo.CRMTempUnitUpload.*
  FROM            dbo.CRMTempUnitUpload INNER JOIN
                             (" + strUnitCellTower + @") AS derivedtbl_1 ON dbo.CRMTempUnitUpload.TowerCell = derivedtbl_1.TowerCellID AND 
                         dbo.CRMTempUnitUpload.FloorFrom <= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FloorTo >= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FlatNoFrom <= derivedtbl_1.UnitOrder AND 
                         dbo.CRMTempUnitUpload.FlatNoTo >= derivedtbl_1.UnitOrder 
  and (ISNULL(CRMTempUnitUpload.Section, '') = '' or CHARINDEX(CRMTempUnitUpload.Section,derivedtbl_1.UnitFullName)>0 )  INNER JOIN
                         dbo.CRMUnit AS CRMUnit_1 ON derivedtbl_1.UnitID = CRMUnit_1.UnitID 
 ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);


            strExistingUnit =
  @"update CRMUnit set UnitSurvey= CASE WHEN CRMUnit.CurrentReservation = 0 THEN dbo.CRMTempUnitUploadUnitID.Area ELSE CRMUnit.UnitSurvey END,
 CRMUnit.UnitNewSurvey= CASE WHEN CRMUnit.CurrentReservation > 0 and CRMUnit.UnitSurvey <>dbo.CRMTempUnitUploadUnitID.Area THEN dbo.CRMTempUnitUploadUnitID.Area ELSE NULL END,
  CRMUnit.UnitHeight = isnull(dbo.CRMTempUnitUploadUnitID.Height,0)
,CRMUnit.UnitModel = 
case when isnull(CRMUnit.UnitModel,0) = 0 then dbo.CRMTempUnitUploadUnitID.Model 
else 
case when dbo.CRMTempUnitUploadUnitID.Model >0 then dbo.CRMTempUnitUploadUnitID.Model else CRMUnit.UnitModel end
end  
,CRMUnit.UnitUserClosed = case when CRMUnit.CurrentReservation = 0 and  CRMUnit.UnitClosedPermanent = 0 then  " + SysData.CurrentUser.ID.ToString() + @"  WHEN CRMUnit.CurrentReservation = 0 AND CRMUnit.UnitClosedPermanent = 1 THEN UnitUserClosed else CRMUnit.UnitUserClosed end
, CRMUnit.UnitTimeOpen= case when  CRMUnit.UnitClosedPermanent = 0 then  GetDate() else CRMUnit.UnitTimeOpen end 
, CRMUnit.UnitClosedPermanent= case when CRMUnit.CurrentReservation = 0 then 1 else 0 end 
, CRMUnit.UnitCloseReason= case when CRMUnit.UnitClosedPermanent =0 and  CRMUnit.CurrentReservation = 0 then   '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' + '
 ' + isnull( CRMUnit.UnitCloseReason,'') else CRMUnit.UnitCloseReason end
, CRMUnit.UnitCloseTime = case when CRMUnit.UnitClosedPermanent = 0 and CRMUnit.CurrentReservation = 0 then  GetDate() else CRMUnit.UnitCloseTime end
  FROM            dbo.CRMTempUnitUploadUnitID INNER JOIN
                       dbo.CRMUnit  ON CRMUnit.UnitID = CRMTempUnitUploadUnitID.UnitID  
 where  dbo.CRMTempUnitUploadUnitID.Area <> CRMUnit.UnitSurvey  ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);
            
           
          string  strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, UnitTable.PeripheralType1, '' AS PDesc1, UnitTable.PeripheralSurvey1, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM  CRMTempUnitUploadUnitID as UnitTable
inner join CRMUnit on UnitTable.UnitID = CRMUnit.UnitID 
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (UnitTable.PeripheralSurvey1 > 0) AND(UnitTable.PeripheralType1 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.CRMUnitPeripheral set PeripheralSurvey = UnitTable.PeripheralSurvey1,UsrUpd= "+ SysData.CurrentUser.ID +@",TimUpd = GetDate() 
  FROM            dbo.CRMTempUnitUploadUnitID AS UnitTable INNER JOIN
                         dbo.CRMUnit ON UnitTable.UnitID = dbo.CRMUnit.UnitID INNER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType AND 
                         UnitTable.PeripheralSurvey1 <> dbo.CRMUnitPeripheral.PeripheralSurvey
WHERE        (dbo.CRMUnit.CurrentReservation = 0) AND (UnitTable.PeripheralSurvey1 > 0) AND (UnitTable.PeripheralType1 > 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, UnitTable.PeripheralType2, '' AS PDesc1, UnitTable.PeripheralSurvey2, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM  CRMTempUnitUploadUnitID as UnitTable
inner join CRMUnit on UnitTable.UnitID = CRMUnit.UnitID 
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (UnitTable.PeripheralSurvey2 > 0) AND(UnitTable.PeripheralType2 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.CRMUnitPeripheral set PeripheralSurvey = UnitTable.PeripheralSurvey2,UsrUpd= " + SysData.CurrentUser.ID + @",TimUpd = GetDate() 
  FROM            dbo.CRMTempUnitUploadUnitID AS UnitTable INNER JOIN
                         dbo.CRMUnit ON UnitTable.UnitID = dbo.CRMUnit.UnitID INNER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType AND 
                         UnitTable.PeripheralSurvey2 <> dbo.CRMUnitPeripheral.PeripheralSurvey
WHERE        (dbo.CRMUnit.CurrentReservation = 0) AND (UnitTable.PeripheralSurvey2 > 0) AND (UnitTable.PeripheralType2 > 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();

        }
        public void UploadExcel()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            EditAreaUploadedExcel();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadUnitID ");
          
            string strUnitCellTower = 
                @"SELECT  dbo.CRMUnit.UnitID,CRMUnit.UnitFullName, dbo.CRMUnit.UnitSurvey, dbo.CRMUnit.UnitOrder, dbo.RPCell.CellOrder - 1 AS Floor, RPCell_1.CellID AS TowerCellID
FROM            dbo.CRMUnit INNER JOIN
                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID";
            string strExistingUnit = "";
  

           // SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);
            string strSql = " insert into RPCell (CellShortCode, CellNameA, CellType,  CellParentID, CellFamilyID,RPCell.CellOrder, "+
                         "UsrIns, RPCell.TimIns) "+
                "SELECT        derivedtbl_1.CellShortCode, derivedtbl_1.CellNameA, derivedtbl_1.CellType, derivedtbl_1.CellParentID, derivedtbl_1.CellFamilyID, derivedtbl_1.CellOrder, derivedtbl_1.UsrIns, derivedtbl_1.TimIns "+
                    "  FROM            (SELECT DISTINCT  "+
                     " '' AS CellShortCode, dbo.CRMTempFloor.FloorName AS CellNameA, 7 AS CellType, dbo.CRMTempUnitUpload.TowerCell AS CellParentID, dbo.RPCell.CellFamilyID,  "+
                      " dbo.CRMTempFloor.FloorValue AS CellOrder, "+ SysData.CurrentUser.ID +" AS UsrIns, GETDATE() AS TimIns "+
                     " FROM            dbo.CRMTempUnitUpload INNER JOIN "+
                      " dbo.CRMTempFloor ON dbo.CRMTempUnitUpload.FloorFrom <= dbo.CRMTempFloor.FloorOrder AND dbo.CRMTempUnitUpload.FloorTo >= dbo.CRMTempFloor.FloorOrder INNER JOIN "+
                                  " dbo.RPCell ON dbo.CRMTempUnitUpload.TowerCell = dbo.RPCell.CellID) AS derivedtbl_1 LEFT OUTER JOIN "+
                         " dbo.RPCell AS RPCell_1 ON derivedtbl_1.CellParentID = RPCell_1.CellParentID AND derivedtbl_1.CellOrder = RPCell_1.CellOrder "+
                     " WHERE        (RPCell_1.CellID IS NULL) "+
                     " ORDER BY derivedtbl_1.CellOrder ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            double dblTimIns = DateTime.Now.ToOADate() - 2;

            strSql = @" insert into CRMUnit ( UnitFullName, UnitNameA, UnitSurvey,UnitHeight, UnitModel, UnitType, UnitOrder,UnitUsageType, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, UnitCloseReason, UnitCloseTime, CurrentReservation,UnitFloor,UnitTower, UsrIns, TimIns" +
",TempCellID"+
")" +
"SELECT     dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern"+
",   CASE WHEN isnull(RPCell_1.CellAlterName, '') = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName end, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section) AS UnitFullName, dbo.GetCode('{0Floor}{FlatNo}', RPCell_1.CellNameA,  " +
                         " dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,'') AS UnitNameA, dbo.CRMTempUnitUpload.Area AS UnitSurvey,dbo.CRMTempUnitUpload.Height AS UnitHeight, dbo.CRMTempUnitUpload.Model AS UnitModel, dbo.CRMTempUnitUpload.Type AS UnitType,  " +
                         " dbo.CRMTempUnitNo.UnitNo AS UnitOrder, dbo.CRMTempUnitUpload.UsageType, 2 AS UnitUserClosed, GETDATE() AS UnitTimeOpen, 1 AS UnitClosedPermanent, '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' AS UnitCloseReason, GETDATE() AS UnitCloseTime,  " +
                         "  0 AS CurrentReservation,dbo.CRMFloor.FloorID,CRMTempUnitUpload.TowerID, 2 AS UsrIns, " + dblTimIns +@" AS TimIns, dbo.RPCell.CellID "+
                          @" FROM   dbo.CRMTempFloor
INNER JOIN
                  dbo.CRMFloor ON dbo.CRMTempFloor.FloorOrder + 100 = dbo.CRMFloor.FloorValue 
   INNER JOIN " +
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN "+
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  "+
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN "+
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN "+
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID"+
                         "  LEFT OUTER JOIN "+
                             "  ("+strUnitCellTower+ @") AS UnitTable ON dbo.CRMTempUnitUpload.TowerCell = UnitTable.TowerCellID AND
                         dbo.CRMTempUnitUpload.FloorFrom <= UnitTable.Floor AND dbo.CRMTempUnitUpload.FloorTo >= UnitTable.Floor AND dbo.CRMTempUnitUpload.FlatNoFrom <= UnitTable.UnitOrder AND
                         dbo.CRMTempUnitUpload.FlatNoTo >= UnitTable.UnitOrder 
  and(ISNULL(CRMTempUnitUpload.Section, '') = '' or CHARINDEX(CRMTempUnitUpload.Section, UnitTable.UnitFullName) > 0) 
WHERE        (UnitTable.UnitFullName IS NULL) " ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = " insert into CRMUnitCell  (UnitID, CellID, UnitPartSurvey, UnitOrder)"+
                "  SELECT        UnitTable.UnitID, UnitTable.TempCellID,0 as UnitSurvey1,0 as UnitOrder1 "+
                  " FROM            dbo.CRMTempFloor INNER JOIN "+
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN "+
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  "+
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN "+
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN "+
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN "+
                             " (SELECT        UnitID, UnitFullName, TempCellID "+
                             " FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section)  " +
                         " = UnitTable.UnitFullName LEFT OUTER JOIN "+
                         " dbo.CRMUnitCell ON UnitTable.UnitID = dbo.CRMUnitCell.UnitID AND UnitTable.TempCellID = dbo.CRMUnitCell.CellID "+
                     " WHERE        (dbo.CRMUnitCell.UnitID IS NULL) ";



            strSql = " insert into CRMUnitCell  (UnitID, CellID, UnitPartSurvey, UnitOrder) " +
                @" SELECT        UnitID, TempCellID, UnitSurvey, UnitOrder
FROM dbo.CRMUnit
WHERE(TimIns = "+ dblTimIns +@")";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strExistingUnit = @"
insert into CRMTempUnitUploadUnitID 
SELECT CRMUnit_1.UnitID,dbo.CRMTempUnitUpload.*
  FROM            dbo.CRMTempUnitUpload INNER JOIN
                             (" + strUnitCellTower + @") AS derivedtbl_1 ON dbo.CRMTempUnitUpload.TowerCell = derivedtbl_1.TowerCellID AND 
                         dbo.CRMTempUnitUpload.FloorFrom <= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FloorTo >= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FlatNoFrom <= derivedtbl_1.UnitOrder AND 
                         dbo.CRMTempUnitUpload.FlatNoTo >= derivedtbl_1.UnitOrder  
  and (ISNULL(CRMTempUnitUpload.Section, '') = '' or CHARINDEX(CRMTempUnitUpload.Section,derivedtbl_1.UnitFullName)>0 )  INNER JOIN
                         dbo.CRMUnit AS CRMUnit_1 ON derivedtbl_1.UnitID = CRMUnit_1.UnitID 
  where CRMUnit_1.TimIns ="+ dblTimIns;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);


            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, UnitTable.PeripheralType1, '' AS PDesc1,UnitTable.PeripheralSurvey1, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM  CRMTempUnitUploadUnitID as UnitTable
inner join CRMUnit on UnitTable.UnitID = CRMUnit.UnitID 
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (UnitTable.PeripheralSurvey1 > 0) AND(UnitTable.PeripheralType1 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, UnitTable.PeripheralType2, '' AS PDesc1, UnitTable.PeripheralSurvey2, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM  CRMTempUnitUploadUnitID as UnitTable
inner join CRMUnit on UnitTable.UnitID = CRMUnit.UnitID 
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND UnitTable.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (UnitTable.PeripheralSurvey2 > 0) AND(UnitTable.PeripheralType2 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            InsertUnitHistory();

            #region OldPerihpheral

            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType1, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey1, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName 
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (dbo.CRMTempUnitUpload.PeripheralSurvey1 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType1 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT    distinct    UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType2, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey2, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0) and (dbo.CRMUnitPeripheral.PeriphiralID IS NULL) AND(dbo.CRMTempUnitUpload.PeripheralSurvey2 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType2 > 0)";
          //  SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
#endregion

        }
        public void UploadExcel2()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUpload ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUpload";
            objCopy.WriteToServer(_UnitTable);
            string strUnitCellTower = @"SELECT        dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitSurvey, dbo.CRMUnit.UnitOrder, dbo.RPCell.CellOrder - 1 AS Floor, RPCell_1.CellID AS TowerCellID
FROM            dbo.CRMUnit INNER JOIN
                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID";
            string strExistingUnit =
  @"update CRMUnit_1 set UnitSurvey= CASE WHEN CRMUnit_1.CurrentReservation = 0 THEN dbo.CRMTempUnitUpload.Area ELSE CRMUnit_1.UnitSurvey END,
 CRMUnit_1.UnitNewSurvey= CASE WHEN CRMUnit_1.CurrentReservation > 0 THEN dbo.CRMTempUnitUpload.Area ELSE NULL END,
  CRMUnit_1.UnitHeight = isnull(dbo.CRMTempUnitUpload.Height,0)
,CRMUnit_1.UnitModel = 
case when isnull(CRMUnit_1.UnitModel,0) = 0 then dbo.CRMTempUnitUpload.Model 
else 
case when dbo.CRMTempUnitUpload.Model >0 then dbo.CRMTempUnitUpload.Model else CRMUnit_1.UnitModel end
end  
,CRMUnit_1.UnitUserClosed = case when CRMUnit_1.CurrentReservation = 0 and  CRMUnit_1.UnitClosedPermanent = 0 then  " + SysData.CurrentUser.ID.ToString() + @"  WHEN CRMUnit_1.CurrentReservation = 0 AND CRMUnit_1.UnitClosedPermanent = 1 THEN UnitUserClosed else CRMUnit_1.UnitUserClosed end
, CRMUnit_1.UnitTimeOpen= case when  CRMUnit_1.UnitClosedPermanent = 0 then  GetDate() else CRMUnit_1.UnitTimeOpen end 
, CRMUnit_1.UnitClosedPermanent= case when CRMUnit_1.CurrentReservation = 0 then 1 else 0 end 
, CRMUnit_1.UnitCloseReason= case when CRMUnit_1.UnitClosedPermanent =0 and  CRMUnit_1.CurrentReservation = 0 then   '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' else CRMUnit_1.UnitCloseReason end
, CRMUnit_1.UnitCloseTime = case when CRMUnit_1.UnitClosedPermanent = 0 and CRMUnit_1.CurrentReservation = 0 then  GetDate() else CRMUnit_1.UnitCloseTime end
  FROM            dbo.CRMTempUnitUpload INNER JOIN
                             (" + strUnitCellTower + @") AS derivedtbl_1 ON dbo.CRMTempUnitUpload.TowerCell = derivedtbl_1.TowerCellID AND 
                         dbo.CRMTempUnitUpload.FloorFrom <= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FloorTo >= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FlatNoFrom <= derivedtbl_1.UnitOrder AND 
                         dbo.CRMTempUnitUpload.FlatNoTo >= derivedtbl_1.UnitOrder AND dbo.CRMTempUnitUpload.Area <> derivedtbl_1.UnitSurvey INNER JOIN
                         dbo.CRMUnit AS CRMUnit_1 ON derivedtbl_1.UnitID = CRMUnit_1.UnitID";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);
            string strSql = " insert into RPCell (CellShortCode, CellNameA, CellType,  CellParentID, CellFamilyID,RPCell.CellOrder, " +
                         "UsrIns, RPCell.TimIns) " +
                "SELECT        derivedtbl_1.CellShortCode, derivedtbl_1.CellNameA, derivedtbl_1.CellType, derivedtbl_1.CellParentID, derivedtbl_1.CellFamilyID, derivedtbl_1.CellOrder, derivedtbl_1.UsrIns, derivedtbl_1.TimIns " +
                    "  FROM            (SELECT DISTINCT  " +
                     " '' AS CellShortCode, dbo.CRMTempFloor.FloorName AS CellNameA, 7 AS CellType, dbo.CRMTempUnitUpload.TowerCell AS CellParentID, dbo.RPCell.CellFamilyID,  " +
                      " dbo.CRMTempFloor.FloorValue AS CellOrder, " + SysData.CurrentUser.ID + " AS UsrIns, GETDATE() AS TimIns " +
                     " FROM            dbo.CRMTempUnitUpload INNER JOIN " +
                      " dbo.CRMTempFloor ON dbo.CRMTempUnitUpload.FloorFrom <= dbo.CRMTempFloor.FloorOrder AND dbo.CRMTempUnitUpload.FloorTo >= dbo.CRMTempFloor.FloorOrder INNER JOIN " +
                                  " dbo.RPCell ON dbo.CRMTempUnitUpload.TowerCell = dbo.RPCell.CellID) AS derivedtbl_1 LEFT OUTER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON derivedtbl_1.CellParentID = RPCell_1.CellParentID AND derivedtbl_1.CellOrder = RPCell_1.CellOrder " +
                     " WHERE        (RPCell_1.CellID IS NULL) " +
                     " ORDER BY derivedtbl_1.CellOrder ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = " insert into CRMUnit ( UnitFullName, UnitNameA, UnitSurvey,UnitHeight, UnitModel, UnitType, UnitOrder,UnitUsageType, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, UnitCloseReason, UnitCloseTime, CurrentReservation, UsrIns, TimIns" +
",TempCellID" +
")" +
"SELECT     dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern" +
",   CASE WHEN isnull(RPCell_1.CellAlterName, '') = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName end, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section) AS UnitFullName, dbo.GetCode('{0Floor}{FlatNo}', RPCell_1.CellNameA,  " +
                         " dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,'') AS UnitNameA, dbo.CRMTempUnitUpload.Area AS UnitSurvey,dbo.CRMTempUnitUpload.Height AS UnitHeight, dbo.CRMTempUnitUpload.Model AS UnitModel, dbo.CRMTempUnitUpload.Type AS UnitType,  " +
                         " dbo.CRMTempUnitNo.UnitNo AS UnitOrder, dbo.CRMTempUnitUpload.UsageType, 2 AS UnitUserClosed, GETDATE() AS UnitTimeOpen, 1 AS UnitClosedPermanent, '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' AS UnitCloseReason, GETDATE() AS UnitCloseTime,  " +
                         "  0 AS CurrentReservation, 2 AS UsrIns, GETDATE() AS TimIns, dbo.RPCell.CellID " +
                          " FROM            dbo.CRMTempFloor INNER JOIN " +
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN " +
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  " +
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN " +
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID" +
                         "  LEFT OUTER JOIN " +
                             "  (SELECT        UnitFullName " +
                             " FROM            dbo.CRMUnit) AS UnitTable " +
                             " ON dbo.GetCode(CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section) = UnitTable.UnitFullName " +
                          " WHERE        (UnitTable.UnitFullName IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " insert into CRMUnitCell  (UnitID, CellID, UnitPartSurvey, UnitOrder)" +
                "  SELECT        UnitTable.UnitID, UnitTable.TempCellID,0 as UnitSurvey1,0 as UnitOrder1 " +
                  " FROM            dbo.CRMTempFloor INNER JOIN " +
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN " +
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  " +
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN " +
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                             " (SELECT        UnitID, UnitFullName, TempCellID " +
                             " FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section)  " +
                         " = UnitTable.UnitFullName LEFT OUTER JOIN " +
                         " dbo.CRMUnitCell ON UnitTable.UnitID = dbo.CRMUnitCell.UnitID AND UnitTable.TempCellID = dbo.CRMUnitCell.CellID " +
                     " WHERE        (dbo.CRMUnitCell.UnitID IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType1, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey1, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName 
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (dbo.CRMTempUnitUpload.PeripheralSurvey1 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType1 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT    distinct    UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType2, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey2, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0) and (dbo.CRMUnitPeripheral.PeriphiralID IS NULL) AND(dbo.CRMTempUnitUpload.PeripheralSurvey2 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType2 > 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void UploadPriceExcel()
        {
           
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadPrice ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUploadPrice";
            objCopy.WriteToServer(_UnitTable);

            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadPriceUnitID ");
            string strSql = @" insert into CRMTempUnitUploadPriceUnitID 
(UnitID, UnitFullName, Tower, Section, FloorStr, ExceptedFloor, FloorFrom, FloorTo, FlatStr, FlatNoFrom, FlatNoTo, ExceptedFlat, Type, Price) 
 SELECT       TempUnitTable.UnitID, TempUnitTable.UnitFullName, dbo.CRMTempUnitUploadPrice.Tower, dbo.CRMTempUnitUploadPrice.Section, dbo.CRMTempUnitUploadPrice.FloorStr, dbo.CRMTempUnitUploadPrice.ExceptedFloor, 
                         dbo.CRMTempUnitUploadPrice.FloorFrom, dbo.CRMTempUnitUploadPrice.FloorTo, dbo.CRMTempUnitUploadPrice.FlatStr, dbo.CRMTempUnitUploadPrice.FlatNoFrom, dbo.CRMTempUnitUploadPrice.FlatNoTo, 
                         dbo.CRMTempUnitUploadPrice.ExceptedFlat, dbo.CRMTempUnitUploadPrice.Type, dbo.CRMTempUnitUploadPrice.Price
FROM            (SELECT        dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitFullName, dbo.RPCell.CellOrder - 1 AS Floor, dbo.CRMUnit.UnitTower, dbo.CRMUnit.UnitOrder, dbo.CRMUnit.UnitType
                           FROM            dbo.CRMUnit INNER JOIN
                                                    dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                                                    dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID) AS TempUnitTable INNER JOIN
                         dbo.CRMTempUnitUploadPrice ON  (dbo.CRMTempUnitUploadPrice.UnitID = 0 or dbo.CRMTempUnitUploadPrice.UnitID = TempUnitTable.UnitID  )  and (dbo.CRMTempUnitUploadPrice.UnitID>0 or TempUnitTable.UnitTower IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadPrice.Tower, ',')) )
AND ( dbo.CRMTempUnitUploadPrice.UnitID > 0 or
ISNULL(dbo.CRMTempUnitUploadPrice.FlatStr, '') = '' OR
                         TempUnitTable.UnitOrder IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadPrice.FlatStr, ','))
)
AND
(dbo.CRMTempUnitUploadPrice.UnitID >0 or dbo.CRMTempUnitUploadPrice.FlatNoTo = 0 OR
                         TempUnitTable.UnitOrder >= dbo.CRMTempUnitUploadPrice.FlatNoFrom AND TempUnitTable.UnitOrder <= dbo.CRMTempUnitUploadPrice.FlatNoTo
)
AND (
dbo.CRMTempUnitUploadPrice.ExceptedFlat = '' OR
                         TempUnitTable.UnitOrder NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadPrice.ExceptedFlat, ',')))
AND (dbo.CRMTempUnitUploadPrice.UnitID>0  or dbo.CRMTempUnitUploadPrice.FloorTo = 0 OR
                         TempUnitTable.Floor <= dbo.CRMTempUnitUploadPrice.FloorTo AND TempUnitTable.Floor >= dbo.CRMTempUnitUploadPrice.FloorFrom) AND (dbo.CRMTempUnitUploadPrice.FloorStr = '' OR
                         TempUnitTable.Floor IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadPrice.FloorStr, ','))) AND (dbo.CRMTempUnitUploadPrice.ExceptedFloor = '' OR
                         TempUnitTable.Floor NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadPrice.ExceptedFloor, ','))) AND TempUnitTable.UnitType = dbo.CRMTempUnitUploadPrice.Type 
         	AND (dbo.CRMTempUnitUploadPrice.Section= ''
         OR CHARINDEX(dbo.CRMTempUnitUploadPrice.Section,TempUnitTable.UnitFullName)>0)";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" insert into CRMUnitPrice ( UnitID, UnitPrice, UnitPriceDateStr, UsrIns, TimIns) 
 SELECT        UnitID, Price, '"+ _PriceDate.ToString("yyyyMMdd") +@"' AS UnitDateStr, "+ SysData.CurrentUser.ID +@" AS UsrIns, GETDATE() AS TimIns
FROM            dbo.CRMTempUnitUploadPriceUnitID ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.CRMUnit set UnitPricePerMeter= dbo.CRMTempUnitUploadPriceUnitID.Price
  FROM            dbo.CRMTempUnitUploadPriceUnitID INNER JOIN
                         dbo.CRMUnit ON dbo.CRMTempUnitUploadPriceUnitID.UnitID = dbo.CRMUnit.UnitID";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void UploadNumericEvaluation()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadNumericEvaluation ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUploadNumericEvaluation";
            objCopy.WriteToServer(_UnitTable);

            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMUnitNumericEvaluationTemp ");
            string strSql = @" insert into CRMUnitNumericEvaluationTemp 
(UnitID, UnitNumericEvaluation) 
 SELECT       TempUnitTable.UnitID, dbo.CRMTempUnitUploadNumericEvaluation.NumericEvaluation
FROM            (SELECT        dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitFullName, dbo.RPCell.CellOrder - 1 AS Floor, dbo.CRMUnit.UnitTower, dbo.CRMUnit.UnitOrder, dbo.CRMUnit.UnitType
                           FROM            dbo.CRMUnit INNER JOIN
                                                    dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                                                    dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID) AS TempUnitTable INNER JOIN
                         dbo.CRMTempUnitUploadNumericEvaluation ON TempUnitTable.UnitTower IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadNumericEvaluation.Tower, ',')) 
AND (
ISNULL(dbo.CRMTempUnitUploadNumericEvaluation.FlatStr, '') = '' OR
                         TempUnitTable.UnitOrder IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadNumericEvaluation.FlatStr, ','))
)
AND
(dbo.CRMTempUnitUploadNumericEvaluation.FlatNoTo = 0 OR
                         TempUnitTable.UnitOrder >= dbo.CRMTempUnitUploadNumericEvaluation.FlatNoFrom AND TempUnitTable.UnitOrder <= dbo.CRMTempUnitUploadNumericEvaluation.FlatNoTo
)
AND (
dbo.CRMTempUnitUploadNumericEvaluation.ExceptedFlat = '' OR
                         TempUnitTable.UnitOrder NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadNumericEvaluation.ExceptedFlat, ','))) AND (dbo.CRMTempUnitUploadNumericEvaluation.FloorTo = 0 OR
                         TempUnitTable.Floor <= dbo.CRMTempUnitUploadNumericEvaluation.FloorTo AND TempUnitTable.Floor >= dbo.CRMTempUnitUploadNumericEvaluation.FloorFrom) AND (dbo.CRMTempUnitUploadNumericEvaluation.FloorStr = '' OR
                         TempUnitTable.Floor IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadNumericEvaluation.FloorStr, ','))) AND (dbo.CRMTempUnitUploadNumericEvaluation.ExceptedFloor = '' OR
                         TempUnitTable.Floor NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadNumericEvaluation.ExceptedFloor, ','))) AND TempUnitTable.UnitType = dbo.CRMTempUnitUploadNumericEvaluation.Type 
         	AND (dbo.CRMTempUnitUploadNumericEvaluation.Section= ''
         OR CHARINDEX(dbo.CRMTempUnitUploadNumericEvaluation.Section,TempUnitTable.UnitFullName)>0)";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" insert into CRMUnitNumericEvaluation ( UnitID, UnitNumericEvaluation) 
 SELECT        dbo.CRMUnitNumericEvaluationTemp.UnitID, dbo.CRMUnitNumericEvaluationTemp.UnitNumericEvaluation
FROM            dbo.CRMUnitNumericEvaluationTemp LEFT OUTER JOIN
                         dbo.CRMUnitNumericalEvaluation ON dbo.CRMUnitNumericEvaluationTemp.UnitID = dbo.CRMUnitNumericalEvaluation.UnitID
WHERE        (dbo.CRMUnitNumericalEvaluation.UnitID IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.CRMUnitNumericalEvaluation set UnitNumericEvaluation = dbo.CRMUnitNumericEvaluationTemp.UnitNumericEvaluation 
FROM            dbo.CRMUnitNumericEvaluationTemp INNER JOIN
                         dbo.CRMUnitNumericalEvaluation ON dbo.CRMUnitNumericEvaluationTemp.UnitID = dbo.CRMUnitNumericalEvaluation.UnitID";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void UploadAttributeExcel()
        {

            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUploadAttribute ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUploadAttribute";
            objCopy.WriteToServer(_UnitTable);

            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMUnitAttributeValueTemp ");

            string strSql = @" insert into CRMUnitAttributeValueTemp 
(UnitID, Attribute,AttributeValue) 
 SELECT        TempUnitTable.UnitID, dbo.CRMTempUnitUploadAttribute.Attribute, dbo.CRMTempUnitUploadAttribute.AttributeValue
FROM            (SELECT        dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitSurvey, dbo.CRMUnit.UnitCategory, dbo.CRMUnit.UnitFullName, dbo.RPCell.CellOrder - 1 AS Floor, dbo.CRMUnit.UnitTower, dbo.CRMUnit.UnitOrder, 
                                                    dbo.CRMUnit.UnitType
                           FROM            dbo.CRMUnit INNER JOIN
                                                    dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                                                    dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID) AS TempUnitTable INNER JOIN
                         dbo.CRMTempUnitUploadAttribute ON TempUnitTable.UnitTower IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadAttribute.Tower, ',')) AND (ISNULL(dbo.CRMTempUnitUploadAttribute.FlatStr, '') = '' OR
                         TempUnitTable.UnitOrder IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadAttribute.FlatStr, ','))) AND (dbo.CRMTempUnitUploadAttribute.FlatNoTo = 0 OR
                         TempUnitTable.UnitOrder >= dbo.CRMTempUnitUploadAttribute.FlatNoFrom AND TempUnitTable.UnitOrder <= dbo.CRMTempUnitUploadAttribute.FlatNoTo) AND (dbo.CRMTempUnitUploadAttribute.ExceptedFlat = '' OR
                         TempUnitTable.UnitOrder NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadAttribute.ExceptedFlat, ','))) AND (dbo.CRMTempUnitUploadAttribute.FloorTo = 0 OR
                         TempUnitTable.Floor <= dbo.CRMTempUnitUploadAttribute.FloorTo AND TempUnitTable.Floor >= dbo.CRMTempUnitUploadAttribute.FloorFrom) AND (dbo.CRMTempUnitUploadAttribute.FloorStr = '' OR
                         TempUnitTable.Floor IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadAttribute.FloorStr, ','))) AND (dbo.CRMTempUnitUploadAttribute.ExceptedFloor = '' OR
                         TempUnitTable.Floor NOT IN
                             (SELECT        Value
                                FROM            dbo.Split(dbo.CRMTempUnitUploadAttribute.ExceptedFloor, ','))) AND (dbo.CRMTempUnitUploadAttribute.Section = '' OR
                         CHARINDEX(dbo.CRMTempUnitUploadAttribute.Section, TempUnitTable.UnitFullName) > 0) AND (dbo.CRMTempUnitUploadAttribute.Area = 0 OR
                         TempUnitTable.UnitSurvey = dbo.CRMTempUnitUploadAttribute.Area) AND (dbo.CRMTempUnitUploadAttribute.CategoryType = 0 OR
                         TempUnitTable.UnitCategory = dbo.CRMTempUnitUploadAttribute.CategoryType)";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            strSql = @"
insert into CRMUnitAttributeValue (  UnitID, Attribute, AttributeValue)
SELECT        derivedtbl_2.UnitID, derivedtbl_2.Attribute, derivedtbl_2.AttributeValue
FROM          
(SELECT        dbo.CRMUnitAttributeValueTemp.UnitID, dbo.CRMUnitAttributeValueTemp.Attribute, dbo.CRMUnitAttributeValueTemp.AttributeValue
                           FROM   dbo.CRMUnitAttributeValueTemp) AS derivedtbl_2 LEFT OUTER JOIN
                         dbo.CRMUnitAttributeValue ON derivedtbl_2.UnitID = dbo.CRMUnitAttributeValue.UnitID AND derivedtbl_2.Attribute = dbo.CRMUnitAttributeValue.Attribute
WHERE        (dbo.CRMUnitAttributeValue.UnitID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"update        dbo.CRMUnitAttributeValue set AttributeValue= derivedtbl_2.AttributeValue 
FROM            (SELECT     dbo.CRMUnitAttributeValueTemp.UnitID, dbo.CRMUnitAttributeValueTemp.Attribute, dbo.CRMUnitAttributeValueTemp.AttributeValue
                           FROM            dbo.CRMUnitAttributeValueTemp) AS derivedtbl_2 INNER JOIN
                         dbo.CRMUnitAttributeValue ON derivedtbl_2.UnitID = dbo.CRMUnitAttributeValue.UnitID AND derivedtbl_2.Attribute = dbo.CRMUnitAttributeValue.Attribute";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" insert into CRMUnitNumericalEvaluation (UnitID,UnitNumericEvaluation) 
   SELECT    distinct    dbo.CRMUnit.UnitID, 0 AS Evaluation
FROM            dbo.CRMUnit
INNER JOIN
                         dbo.CRMUnitAttributeValueTemp ON dbo.CRMUnit.UnitID = dbo.CRMUnitAttributeValueTemp.UnitID
LEFT OUTER JOIN
                         dbo.CRMUnitNumericalEvaluation ON dbo.CRMUnit.UnitID = dbo.CRMUnitNumericalEvaluation.UnitID

WHERE        (dbo.CRMUnitNumericalEvaluation.UnitID IS NULL) ";
            List<string> arrStr = new List<string>();
            arrStr.Add(strSql);

            strSql = @" update        dbo.CRMUnitNumericalEvaluation set UnitNumericEvaluation = derivedtbl_1.TotalEvaluation
FROM            (SELECT        dbo.CRMUnitAttributeValue.UnitID, SUM(CASE WHEN dbo.CRMUnitAttributeValue.AttributeValue > dbo.CRMAttribute.AttributeMinValue THEN dbo.CRMUnitAttributeValue.AttributeValue ELSE 0 END) 
                         / SUM(CASE WHEN dbo.CRMUnitAttributeValue.AttributeValue > dbo.CRMAttribute.AttributeMinValue THEN dbo.CRMAttribute.AttributeMaxValue ELSE 0 END) * 100 AS TotalEvaluation
FROM            dbo.CRMUnitAttributeValue INNER JOIN
                         dbo.CRMAttribute ON dbo.CRMUnitAttributeValue.Attribute = dbo.CRMAttribute.AttributeID
GROUP BY dbo.CRMUnitAttributeValue.UnitID) AS derivedtbl_1 INNER JOIN
                         dbo.CRMUnitNumericalEvaluation ON derivedtbl_1.UnitID = dbo.CRMUnitNumericalEvaluation.UnitID 
inner join CRMUnitAttributeValueTemp  on dbo.CRMUnitNumericalEvaluation.UnitID  = dbo.CRMUnitAttributeValueTemp.UnitID  ";

            arrStr.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);


        }
        public void EditCategory()
        {
            if (_UnitIDs == null || _UnitIDs == "" || _Category ==0)
                return;
            string strSql = " update CRMUnit set UnitCategory = "+_Category + " where UnitID in ("+ _UnitIDs +") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditNumericEvaluation()
        {
            if (_UnitIDs == null || _UnitIDs == "" || _NumericEvaluation == 0)
                return;
            string strSql = @" insert into CRMUnitNumericalEvaluation 
(UnitID,UnitNumericEvaluation) 
SELECT        dbo.CRMUnit.UnitID, 0 AS Expr1
FROM            dbo.CRMUnitNumericalEvaluation RIGHT OUTER JOIN
                         dbo.CRMUnit ON dbo.CRMUnitNumericalEvaluation.UnitID = dbo.CRMUnit.UnitID
WHERE        (dbo.CRMUnitNumericalEvaluation.UnitID IS NULL) AND (dbo.CRMUnit.UnitID IN (" + _UnitIDs+@"))";
            strSql += " update CRMUnitNumericalEvaluation set UnitNumericEvaluation = " + _NumericEvaluation + " where UnitID in (" + _UnitIDs + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void UploadExcel1()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMTempUnitUpload ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMTempUnitUpload";
            objCopy.WriteToServer(_UnitTable);

            string strExistingUnit =
  @"update CRMUnit_1 set UnitSurvey= CASE WHEN CRMUnit_1.CurrentReservation = 0 THEN dbo.CRMTempUnitUpload.Area ELSE CRMUnit_1.UnitSurvey END,
 CRMUnit_1.UnitNewSurvey= CASE WHEN CRMUnit_1.CurrentReservation > 0 THEN dbo.CRMTempUnitUpload.Area ELSE NULL END,
  CRMUnit_1.UnitHeight = isnull(dbo.CRMTempUnitUpload.Height,0)
,CRMUnit_1.UnitModel = 
case when isnull(CRMUnit_1.UnitModel,0) = 0 then dbo.CRMTempUnitUpload.Model 
else 
case when dbo.CRMTempUnitUpload.Model >0 then dbo.CRMTempUnitUpload.Model else CRMUnit_1.UnitModel end
end  
,CRMUnit_1.UnitUserClosed = case when CRMUnit_1.CurrentReservation = 0 and  CRMUnit_1.UnitClosedPermanent = 0 then  " + SysData.CurrentUser.ID.ToString() + @"  WHEN CRMUnit_1.CurrentReservation = 0 AND CRMUnit_1.UnitClosedPermanent = 1 THEN UnitUserClosed else CRMUnit_1.UnitUserClosed end
, CRMUnit_1.UnitTimeOpen= case when  CRMUnit_1.UnitClosedPermanent = 0 then  GetDate() else CRMUnit_1.UnitTimeOpen end 
, CRMUnit_1.UnitClosedPermanent= case when CRMUnit_1.CurrentReservation = 0 then 1 else 0 end 
, CRMUnit_1.UnitCloseReason= case when CRMUnit_1.UnitClosedPermanent =0 and  CRMUnit_1.CurrentReservation = 0 then   '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' else CRMUnit_1.UnitCloseReason end
, CRMUnit_1.UnitCloseTime = case when CRMUnit_1.UnitClosedPermanent = 0 and CRMUnit_1.CurrentReservation = 0 then  GetDate() else CRMUnit_1.UnitCloseTime end
  FROM     dbo.CRMTempUnitUpload INNER JOIN
                             (SELECT        dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitSurvey, dbo.CRMUnit.UnitOrder, dbo.RPCell.CellOrder - 1 AS Floor, RPCell_1.CellID AS TowerCellID
                                FROM            dbo.CRMUnit INNER JOIN
                                                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                                                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN
                                                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID) AS derivedtbl_1 ON dbo.CRMTempUnitUpload.TowerCell = derivedtbl_1.TowerCellID AND 
                         dbo.CRMTempUnitUpload.FloorFrom <= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FloorTo >= derivedtbl_1.Floor AND dbo.CRMTempUnitUpload.FlatNoFrom <= derivedtbl_1.UnitOrder AND 
                         dbo.CRMTempUnitUpload.FlatNoTo >= derivedtbl_1.UnitOrder AND dbo.CRMTempUnitUpload.Area <> derivedtbl_1.UnitSurvey INNER JOIN
                         dbo.CRMUnit AS CRMUnit_1 ON derivedtbl_1.UnitID = CRMUnit_1.UnitID";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strExistingUnit);
            string strSql = " insert into RPCell (CellShortCode, CellNameA, CellType,  CellParentID, CellFamilyID,RPCell.CellOrder, " +
                         "UsrIns, RPCell.TimIns) " +
                "SELECT        derivedtbl_1.CellShortCode, derivedtbl_1.CellNameA, derivedtbl_1.CellType, derivedtbl_1.CellParentID, derivedtbl_1.CellFamilyID, derivedtbl_1.CellOrder, derivedtbl_1.UsrIns, derivedtbl_1.TimIns " +
                    "  FROM            (SELECT DISTINCT  " +
                     " '' AS CellShortCode, dbo.CRMTempFloor.FloorName AS CellNameA, 7 AS CellType, dbo.CRMTempUnitUpload.TowerCell AS CellParentID, dbo.RPCell.CellFamilyID,  " +
                      " dbo.CRMTempFloor.FloorValue AS CellOrder, " + SysData.CurrentUser.ID + " AS UsrIns, GETDATE() AS TimIns " +
                     " FROM            dbo.CRMTempUnitUpload INNER JOIN " +
                      " dbo.CRMTempFloor ON dbo.CRMTempUnitUpload.FloorFrom <= dbo.CRMTempFloor.FloorOrder AND dbo.CRMTempUnitUpload.FloorTo >= dbo.CRMTempFloor.FloorOrder INNER JOIN " +
                                  " dbo.RPCell ON dbo.CRMTempUnitUpload.TowerCell = dbo.RPCell.CellID) AS derivedtbl_1 LEFT OUTER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON derivedtbl_1.CellParentID = RPCell_1.CellParentID AND derivedtbl_1.CellOrder = RPCell_1.CellOrder " +
                     " WHERE        (RPCell_1.CellID IS NULL) " +
                     " ORDER BY derivedtbl_1.CellOrder ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = " insert into CRMUnit ( UnitFullName, UnitNameA, UnitSurvey,UnitHeight, UnitModel, UnitType, UnitOrder,UnitUsageType, UnitUserClosed, UnitTimeOpen, UnitClosedPermanent, UnitCloseReason, UnitCloseTime, CurrentReservation, UsrIns, TimIns" +
",TempCellID" +
")" +
"SELECT     dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern" +
",   CASE WHEN isnull(RPCell_1.CellAlterName, '') = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName end, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section) AS UnitFullName, dbo.GetCode('{0Floor}{FlatNo}', RPCell_1.CellNameA,  " +
                         " dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,'') AS UnitNameA, dbo.CRMTempUnitUpload.Area AS UnitSurvey,dbo.CRMTempUnitUpload.Height AS UnitHeight, dbo.CRMTempUnitUpload.Model AS UnitModel, dbo.CRMTempUnitUpload.Type AS UnitType,  " +
                         " dbo.CRMTempUnitNo.UnitNo AS UnitOrder, dbo.CRMTempUnitUpload.UsageType, 2 AS UnitUserClosed, GETDATE() AS UnitTimeOpen, 1 AS UnitClosedPermanent, '«Ìﬁ«› »Ì⁄ ··„—«Ã⁄…' AS UnitCloseReason, GETDATE() AS UnitCloseTime,  " +
                         "  0 AS CurrentReservation, 2 AS UsrIns, GETDATE() AS TimIns, dbo.RPCell.CellID " +
                          " FROM            dbo.CRMTempFloor INNER JOIN " +
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN " +
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  " +
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN " +
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID" +
                         "  LEFT OUTER JOIN " +
                             "  (SELECT        UnitFullName " +
                             " FROM            dbo.CRMUnit) AS UnitTable " +
                             " ON dbo.GetCode(CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section) = UnitTable.UnitFullName " +
                          " WHERE        (UnitTable.UnitFullName IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " insert into CRMUnitCell  (UnitID, CellID, UnitPartSurvey, UnitOrder)" +
                "  SELECT        UnitTable.UnitID, UnitTable.TempCellID,0 as UnitSurvey1,0 as UnitOrder1 " +
                  " FROM            dbo.CRMTempFloor INNER JOIN " +
                         " dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN " +
                         " dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND  " +
                         " dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN " +
                         " dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN " +
                         " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                             " (SELECT        UnitID, UnitFullName, TempCellID " +
                             " FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo,CRMTempUnitUpload.Section)  " +
                         " = UnitTable.UnitFullName LEFT OUTER JOIN " +
                         " dbo.CRMUnitCell ON UnitTable.UnitID = dbo.CRMUnitCell.UnitID AND UnitTable.TempCellID = dbo.CRMUnitCell.CellID " +
                     " WHERE        (dbo.CRMUnitCell.UnitID IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT  distinct      UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType1, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey1, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName 
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
             LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType1 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0 ) and (dbo.CRMTempUnitUpload.PeripheralSurvey1 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType1 > 0) AND(dbo.CRMUnitPeripheral.PeriphiralID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into CRMUnitPeripheral (PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey, PeripheralHeight, PeripheralPricePerMeter, UsrIns, TimIns)
SELECT    distinct    UnitTable.UnitID, dbo.CRMTempUnitUpload.PeripheralType2, '' AS PDesc1, dbo.CRMTempUnitUpload.PeripheralSurvey2, 0 AS PHeight1, 0 AS PPrice1, 2 AS UsrIns1, GETDATE() AS TimIns1
FROM dbo.CRMTempFloor INNER JOIN
                         dbo.RPCell ON dbo.CRMTempFloor.FloorValue = dbo.RPCell.CellOrder INNER JOIN
                         dbo.CRMTempUnitUpload ON dbo.CRMTempFloor.FloorOrder >= dbo.CRMTempUnitUpload.FloorFrom AND dbo.CRMTempFloor.FloorOrder <= dbo.CRMTempUnitUpload.FloorTo AND
                         dbo.RPCell.CellParentID = dbo.CRMTempUnitUpload.TowerCell INNER JOIN
                         dbo.CRMTempUnitNo ON dbo.CRMTempUnitUpload.FlatNoFrom <= dbo.CRMTempUnitNo.UnitNo AND dbo.CRMTempUnitUpload.FlatNoTo >= dbo.CRMTempUnitNo.UnitNo INNER JOIN
                         dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN
                             (SELECT UnitID, UnitFullName, TempCellID,CurrentReservation
                                FROM            dbo.CRMUnit) AS UnitTable ON dbo.GetCode(dbo.CRMTempUnitUpload.CodePattern, RPCell_1.CellNameA, dbo.CRMTempFloor.FloorOrder, dbo.CRMTempUnitNo.UnitNo, dbo.CRMTempUnitUpload.Section)
                         = UnitTable.UnitFullName
inner join CRMUnitCell on UnitTable.UnitID = CRMUnitCell.UnitID
inner join RPCell as RPCell2 on CRMUnitCell.CellID = RPCell2.CellID 
and RPCell2.CellParentID = CRMTempUnitUpload.TowerCell
LEFT OUTER JOIN
                         dbo.CRMUnitPeripheral ON UnitTable.UnitID = dbo.CRMUnitPeripheral.PeriphiralUnit AND dbo.CRMTempUnitUpload.PeripheralType2 = dbo.CRMUnitPeripheral.PeriphiralType
WHERE (CurrentReservation = 0) and (dbo.CRMUnitPeripheral.PeriphiralID IS NULL) AND(dbo.CRMTempUnitUpload.PeripheralSurvey2 > 0) AND(dbo.CRMTempUnitUpload.PeripheralType2 > 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        #endregion
    }
}