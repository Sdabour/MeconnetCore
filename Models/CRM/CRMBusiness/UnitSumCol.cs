using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitSumCol :CollectionBase
    {
        #region Constructor
        public UnitSumCol()
        {

 
        }
        public UnitSumCol(bool blIsEmpty)
        {


        }
        public UnitSumCol(bool blIsProjectGrouping, bool blIsTypeGrouping,
           CellBiz objCellBiz,  UnitModelBiz objModelBiz, 
            CustomerCol objCustomerCol,string strCellName,string strTowerName,double dblFromSuervy,
            double dblToSurevy,int intStatus,string strReservationStatus,int intCellOrder,
            UnitTypeBiz objUnittypeBiz,int intDeliveryStatus,int intTowerDeliveryStatus,
            bool blIsDeliveryDateRange,DateTime dtStartDelivery,
            DateTime dtEndDelivery,string strUnitCode,PeripheralTypeBiz objPeripheralType,
            double dblStartPeripheralSurvey,double dblEndPeripheralSurvey,
            bool blIsReservationDateRange,DateTime dtReservationStartDate,DateTime dtReservationEndDate)
        {

            UnitDb objDb = new UnitDb();
            SetDataInitially( blIsProjectGrouping,blIsTypeGrouping, objCellBiz, objModelBiz, objCustomerCol, strCellName, strTowerName, dblFromSuervy,
            dblToSurevy, intStatus, strReservationStatus, intCellOrder,
            objUnittypeBiz, intDeliveryStatus, intTowerDeliveryStatus,
            blIsDeliveryDateRange, dtStartDelivery, dtEndDelivery, strUnitCode, objPeripheralType, 
            dblStartPeripheralSurvey,
            dblEndPeripheralSurvey ,blIsReservationDateRange,dtReservationStartDate,dtReservationEndDate);
            GetSearchData(ref objDb);
            //objDb.IsCellTowerGrouping = true;
           // _IsTowerGrouping = true;
            DataTable dtTemp = objDb.SearchSum();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UnitSumBiz(objDr));
            }
            dtTemp = objDb.PeripheralSumSearch();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UnitSumBiz(objDr));
            }
        }
        
        #endregion
        #region Private Data and Properties
        bool _IsProjectGrouping;

        public bool IsProjectGrouping
        {
            get { return _IsProjectGrouping; }
           
        }
        bool _IsTowerGrouping;

        public bool IsTowerGrouping
        {
            get { return _IsTowerGrouping; }
          
        }
        bool _IsTypeGrouping;

        public bool IsTypeGrouping
        {
            get { return _IsTypeGrouping; }
            
        }
        bool _IsUsageTypeGrouping;

        public bool IsUsageTypeGrouping
        {
            get { return _IsUsageTypeGrouping; }
          
        }
        bool _IsModelGrouping;

        public bool IsModelGrouping
        {
            get { return _IsModelGrouping; }
          
        }
        bool _IsSurveyGrouping;

        public bool IsSurveyGrouping
        {
            get { return _IsSurveyGrouping; }
            
        }
        bool _IsViewGrouping;

        public bool IsViewGrouping
        {
            get { return _IsViewGrouping; }
            set { _IsViewGrouping = value; }
        }
        bool _IsUnitPriceGrouping;

        public bool IsUnitPriceGrouping
        {
            get { return _IsUnitPriceGrouping; }
       
        }
        bool _IsFloorGrouping;

        public bool IsFloorGrouping
        {
            get { return _IsFloorGrouping; }
            
        }
        TowerBiz _TowerBiz;
        ProjectBiz _ProjectBiz;
        CellBiz _CellBiz;
        UnitViewBiz _ViewBiz;
        UnitMainTypeBiz _MainTypeBiz;
        UnitUsageTypeBiz _UsageTypeBiz;


        UnitModelBiz _ModelBiz;
        CustomerCol _CustomerCol;
        string _CellName;
        string _TowerName;
        double _FromSuervy;
        double _ToSurevy;
        double _StartPeripheralSurvey;
        double _EndPeripheralSurvey;
        PeripheralTypeBiz _PeripheralTypeBiz = new PeripheralTypeBiz();
        int _Status;
        int _DisabledStatus;
        string _ReservationStatus;
        int _CellOrder;
        UnitTypeBiz _UnittypeBiz;
        int _DeliveryStatus;
        int _TowerDeliveryStatus;
        bool _IsDeliveryDateRange;
        DateTime _StartDeliveryDate;
        DateTime _EndDeliveryDate;
        string _UnitCodeStr;
        bool _IsReservationDateRange;
        DateTime _ReservationStartDate;
        DateTime _ReservationEndDate;
        public UnitSumBiz this[int intIndex]
        {
            get
            {
                return (UnitSumBiz)List[intIndex];

            }
        }
        #endregion
        #region Private Method
        void SetDataInitially(bool blIsProjectGrouping, bool blIsTypeGrouping,
            CellBiz objCellBiz, UnitModelBiz objModelBiz,
          CustomerCol objCustomerCol, string strCellName, string strTowerName, double dblFromSuervy,
          double dblToSurevy, int intStatus, string strReservationStatus,
          int intCellOrder, UnitTypeBiz objUnittypeBiz, int intDeliveryStatus, int intTowerDeliveryStatus,
          bool blIsDeliveryDateRange, DateTime dtStartDelivery, DateTime dtEndDelivery, string strUnitCode, PeripheralTypeBiz objPeripheralType,
          double dblStartPeripheralSurvey, double dblEndPeripheralSurvey,
            bool blIsReservationDateRange,DateTime dtReservationStartDate,DateTime dtReservationEndDate)
        {
            _CellBiz = objCellBiz;
         
            _ModelBiz = objModelBiz;
            _CustomerCol = objCustomerCol;
            _CellName = strCellName;
            _TowerName = strTowerName;
            _FromSuervy = dblFromSuervy;
            _ToSurevy = dblToSurevy;
            _Status = intStatus;
         
            _ReservationStatus = strReservationStatus;
            _CellOrder = intCellOrder;
            _UnittypeBiz = objUnittypeBiz;
            _DeliveryStatus = intDeliveryStatus;
            _StartDeliveryDate = dtStartDelivery;
            _EndDeliveryDate = dtEndDelivery;
            _IsDeliveryDateRange = blIsDeliveryDateRange;
            _TowerDeliveryStatus = intTowerDeliveryStatus;
            _UnitCodeStr = strUnitCode;
            _PeripheralTypeBiz = objPeripheralType;
            _StartPeripheralSurvey = dblStartPeripheralSurvey;
            _EndPeripheralSurvey = dblEndPeripheralSurvey;
             _IsProjectGrouping = blIsProjectGrouping ;
            //_IsTowerGrouping =  blIsTowerGrouping;
           _IsTypeGrouping =  blIsTypeGrouping;
           _IsReservationDateRange = blIsReservationDateRange;
           _ReservationStartDate = dtReservationStartDate;
           _ReservationEndDate = dtReservationEndDate;
            //_IsUsageTypeGrouping = blIsUsageTypeGrouping;
            //_IsModelGrouping = blIsModelGrouping;
            //_IsSurveyGrouping = blIsSurveyGrouping;
            //_IsUnitPriceGrouping =  blIsUnitPriceGrouping;
            //_IsViewGrouping = blIsViewGrouping;
            //_IsFloorGrouping = blIsFloorGrouping;
        }
        void GetSearchData(ref UnitDb objUnitDb)
        {

            if (_ModelBiz == null)
                _ModelBiz = new UnitModelBiz();
            if (_CustomerCol == null)
                _CustomerCol = new CustomerCol(true);
            if (_TowerBiz == null)
                _TowerBiz = new TowerBiz();
            if (_ProjectBiz == null)
                _ProjectBiz = new ProjectBiz();
            if (_UsageTypeBiz == null)
                _UsageTypeBiz = new UnitUsageTypeBiz();
            if (_MainTypeBiz == null)
                _MainTypeBiz = new UnitMainTypeBiz();
            if (_ViewBiz == null)
                _ViewBiz = new UnitViewBiz();
            objUnitDb = new UnitDb();
            
            objUnitDb.CellTower = _TowerBiz.ID;
          //  objUnitDb.Project = _ProjectBiz.ID;
            objUnitDb.View = _ViewBiz.ID;
            objUnitDb.UsageType = _UsageTypeBiz.ID;
            objUnitDb.MainType = _MainTypeBiz.ID;
            //objUnitDb.DisableStatus = _DisabledStatus;

            objUnitDb.ModelIDs = _ModelBiz.IDsStr;
            objUnitDb.CustomerIDs = _CustomerCol.IDsStr;
            objUnitDb.FromSurvey = _FromSuervy;
            objUnitDb.UnitStatus = _Status;
            objUnitDb.ToSurvey = _ToSurevy;
            objUnitDb.StatusStr = _ReservationStatus;
            objUnitDb.UnitNameLike = _CellName;
            objUnitDb.CellTowerName = _TowerName;
            objUnitDb.CellTowerDeliveryStatus = _TowerDeliveryStatus;
            objUnitDb.DeliveryStatus = _DeliveryStatus;
            objUnitDb.DeliveryDateRange = _IsDeliveryDateRange;
            objUnitDb.StartDeliveryDate = _StartDeliveryDate;
            objUnitDb.EndDeliveryDate = _EndDeliveryDate;
            objUnitDb.IsReservationDateRange = _IsReservationDateRange;
            objUnitDb.ReservationStartDate = _ReservationStartDate;
            objUnitDb.ReservationEndDate = _ReservationEndDate;
            if (_UnittypeBiz == null)
                _UnittypeBiz = new UnitTypeBiz();
            objUnitDb.UnitType = _UnittypeBiz.ID;
            objUnitDb.UnitCodeStr = _UnitCodeStr;
            if (_PeripheralTypeBiz == null)
                _PeripheralTypeBiz = new PeripheralTypeBiz();
            objUnitDb.PeripheralID = _PeripheralTypeBiz.ID;
            objUnitDb.StartPeripheralSurvey = _StartPeripheralSurvey;
            objUnitDb.EndPeripheralSurvey = _EndPeripheralSurvey;
            objUnitDb.IsProjectGrouping = _IsProjectGrouping;
            objUnitDb.IsCellTowerGrouping = _IsTowerGrouping ;
            objUnitDb.IsTypeGrouping = _IsTypeGrouping ;
           // objUnitDb.IsUsageTypeGrouping = _IsUsageTypeGrouping;
            objUnitDb.IsModelGrouping = _IsModelGrouping;
            objUnitDb.IsStatusGrouping = _IsSurveyGrouping;
           // objUnitDb.IsUnitPriceGrouping = _IsUnitPriceGrouping;
           // objUnitDb.IsViewGroupig = _IsViewGrouping;
            objUnitDb.IsFloorGrouping = _IsFloorGrouping;
            if(_CellBiz == null)
                _CellBiz = new CellBiz();

            objUnitDb.CellFamilyID = _CellBiz.ID == _CellBiz.FamilyID ? _CellBiz.ID : 0;
            objUnitDb.CellIDs = _CellBiz.ID == _CellBiz.FamilyID ? "" : _CellBiz.IDsStr;
        }
        #endregion
        #region Public Method
        public void Add(UnitSumBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TotalCount", Type.GetType("System.Int32")), 
                new DataColumn("TotalSurvey",Type.GetType("System.Double")),
                new DataColumn("NotSpecifiedTypeCount",Type.GetType("System.Int32")),new DataColumn("ResidentialCount",Type.GetType("System.Int32")),
                new DataColumn("CommercialCount",Type.GetType("System.Int32")),new DataColumn("EconomicalCount",Type.GetType("System.Int32")),
                new DataColumn("AdministrativeCount",Type.GetType("System.Int32")),new DataColumn("FreeUnitPricedCount",Type.GetType("System.Int32")),
                new DataColumn("FreeUnitPricedValue",Type.GetType("System.Double")),new  DataColumn("FreeUnitPricedTotalSurvey",Type.GetType("System.Double")),
            new DataColumn("FreeUnitNotPricedTotalSurvey",Type.GetType("System.Double")),new DataColumn("FreeUnitNotPricedCount",Type.GetType("System.Int32")),
            new DataColumn("TotalOccupiedCount",Type.GetType("System.Int32")),new DataColumn("NotSpecifiedTypeOccupiedCount",Type.GetType("System.Int32")),
            new DataColumn("OccupiedResidentialCount",Type.GetType("System.Int32")),new DataColumn("OccupiedCommercialCount",Type.GetType("System.Int32")),
            new DataColumn("OccupiedEconomicalCount",Type.GetType("System.Int32"))
            ,new DataColumn("OccupiedAdministrativeCount",Type.GetType("System.Int32")),new DataColumn("CashPrice")});
            //new DataColumn("",Type.GetType("System.Int32"))
            if (_IsTowerGrouping)
                Returned.Columns.Add( "TowerName");
            if (_IsTypeGrouping)
              Returned.Columns.Add( "UnitTypeNameA");
            if (_IsUsageTypeGrouping)
               Returned.Columns.Add("UsageTypeNameA");
            if (_IsModelGrouping)
                Returned.Columns.Add("ModelFamilyName");
            if (_IsProjectGrouping || _IsTowerGrouping)
               Returned.Columns.Add("ProjectName");

            if (_IsFloorGrouping)
                Returned.Columns.Add("UnitFloorName");
            if (_IsUnitPriceGrouping)
               Returned.Columns.Add( new DataColumn("UnitPricePerMeter",Type.GetType("System.Double")));
            if (_IsSurveyGrouping)
               Returned.Columns.Add(new DataColumn( "UnitSurvey",Type.GetType("System.Double")));
            if (_IsViewGrouping)
            {
                Returned.Columns.Add(new DataColumn("ViewNameA"));
            }
            DataRow objDr;

            foreach (UnitSumBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TotalCount"] = objBiz.TotalCount;
                objDr["TotalSurvey"] = objBiz.TotalSurvey;
                objDr["NotSpecifiedTypeCount"] = objBiz.NotSpecifiedTypeCount;
                objDr["ResidentialCount"] = objBiz.ResidentialCount;
                objDr["CommercialCount"] = objBiz.CommercialCount;
                objDr["EconomicalCount"] = objBiz.EconomicalCount;
                objDr["AdministrativeCount"] = objBiz.AdministrativeCount;
                objDr["FreeUnitPricedCount"] = objBiz.FreeUnitPricedCount;
                objDr["FreeUnitPricedValue"] = objBiz.FreeUnitPricedValue;
                objDr["FreeUnitPricedTotalSurvey"] = objBiz.FreeUnitPricedTotalSurvey;
                objDr["FreeUnitNotPricedTotalSurvey"] = objBiz.FreeUnitNotPricedTotalSurvey;
                objDr["FreeUnitNotPricedCount"] = objBiz.FreeUnitNotPricedCount;
                objDr["TotalOccupiedCount"] = objBiz.TotalOccupiedCount;
                objDr["NotSpecifiedTypeOccupiedCount"] = objBiz.NotSpecifiedTypeOccupiedCount;
                objDr["OccupiedResidentialCount"] = objBiz.OccupiedResidentialCount;
                objDr["OccupiedCommercialCount"] = objBiz.OccupiedCommercialCount;
                objDr["OccupiedEconomicalCount"] = objBiz.OccupiedEconomicalCount;
                objDr["OccupiedAdministrativeCount"] = objBiz.OccupiedAdministrativeCount;







                if (_IsTowerGrouping)
                    objDr["TowerName"] = objBiz.CellTowerName;
                if (_IsTypeGrouping)
                    objDr["UnitTypeNameA"] = objBiz.UnitTypeName;
                if (_IsUsageTypeGrouping)
                    objDr["UsageTypeNameA"] = objBiz.UsageTypeName;
                if (_IsModelGrouping)
                    objDr["ModelFamilyName"] = objBiz.ModelFamilyName;
                if (_IsProjectGrouping || _IsTowerGrouping)
                    objDr["ProjectName"] = objBiz.ProjectName;

                //if (_IsFloorGrouping)
                //    objDr["UnitFloorName"] = objBiz.FloorName;
                if (_IsUnitPriceGrouping)
                    objDr["UnitPricePerMeter"] = objBiz.UnitPricePerMeter;
                if (_IsSurveyGrouping)
                    objDr["UnitSurvey"] = objBiz.Survey;
                //if (_IsViewGrouping)
                //{
                //    objDr["ViewNameA"] = objBiz.ViewName;
                //}
                objDr["CashPrice"] = objBiz.TotalUnitCachPrice;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
