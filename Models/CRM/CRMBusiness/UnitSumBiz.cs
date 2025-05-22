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
    public class UnitSumBiz
    {
        #region Private Public Property
        UnitDb _UnitDb;

        public double TotalCount
        {
            get { return _UnitDb.TotalCount; }

        }

        public double TotalSurvey
        {
            get { return _UnitDb.TotalSurvey; }

        }
        public int NotSpecifiedTypeCount
        {
            get { return _UnitDb.NotSpecifiedTypeCount; }

        }
       

        public int ResidentialCount
        {
            get { return _UnitDb.ResidentialCount; }

        }
      

        public int CommercialCount
        {
            get { return _UnitDb.CommercialCount; }

        }
       

        public int EconomicalCount
        {
            get { return _UnitDb.EconomicalCount; }

        }
     

        public int AdministrativeCount
        {
            get { return _UnitDb.AdministrativeCount; }

        }
    

        public int FreeUnitPricedCount
        {
            get { return _UnitDb.FreeUnitPricedCount; }

        }
     

        public double FreeUnitPricedValue
        {
            get { return _UnitDb.FreeUnitPricedValue; }

        }
    
        public double FreeUnitPricedTotalSurvey
        {
            get { return _UnitDb.FreeUnitPricedTotalSurvey; }

        }
    

        public double FreeUnitNotPricedTotalSurvey
        {
            get { return _UnitDb.FreeUnitNotPricedTotalSurvey; }

        }
    
        public int FreeUnitNotPricedCount
        {
            get { return _UnitDb.FreeUnitNotPricedCount; }

        }
      

        public int TotalOccupiedCount
        {
            get { return _UnitDb.TotalOccupiedCount; }

        }
        public double TotalOccupiedSurvey
        {
            get { return _UnitDb.TotalOccupiedSurvey; }
            set { _UnitDb.TotalOccupiedSurvey = value; }
        }
      

        public int NotSpecifiedTypeOccupiedCount
        {
            get { return _UnitDb.NotSpecifiedTypeOccupiedCount; }

        }
    
        public int OccupiedResidentialCount
        {
            get { return _UnitDb.OccupiedResidentialCount; }

        }
       
        public int OccupiedCommercialCount
        {
            get { return _UnitDb.OccupiedCommercialCount; }

        }
     

        public int OccupiedEconomicalCount
        {
            get { return _UnitDb.OccupiedEconomicalCount; }

        }
  

        public int OccupiedAdministrativeCount
        {
            get { return _UnitDb.OccupiedAdministrativeCount; }

        }
        public int UnitTypeID
        {
            get
            {
                return _UnitDb.UnitType;
            }
        }
        public string UnitTypeName
        {
            get
            {
                return _UnitDb.UnitTypeName;
            }
        }
        public int UsagetTypeID
        {
            get
            {
                return _UnitDb.UsageType;
            }
        }
        public string UsageTypeName
        {
            get
            {
                return _UnitDb.UsageTypeName;
            }
        }
        public double  Survey
        {
            get
            {
                return _UnitDb.Survey;
            }
        }
        public double UnitPricePerMeter
        {
            get
            {
                return _UnitDb.PricePerMeter;
            }
        }
        public int CellTowerID
        {
            get
            {
                return _UnitDb.CellTower;
            }
        }
        public string CellTowerName
        {
            get
            {
                return _UnitDb.CellTowerName;
            }
        }
        public int CellTowerOrder
        {
            get { return _UnitDb.CellTowerOrder; }

        }
        

        public string ProjectName
        {
            get
            {
                return _UnitDb.ProjectName;
            }

        }
        public string FloorName
        {
            get
            {
                return UnitFloorBiz.FloorCodeStrCol[_UnitDb.Floor + 4];
                // return Returned.Name;
            }
        }

        public string ModelFamilyName
        {
            get { return _UnitDb.ModelFamilyName; }

        }
        //public string FloorName
        //{
        //    get {
        //        UnitFloorBiz Returned = new UnitFloorBiz(_UnitDb.Floor);
        //        return Returned.Name;
        //    }
        //}
        //public string ViewName
        //{
        //    get { return _UnitDb.ViewName; }
        //}
        public double TotalUnitCachPrice
        {
            get { return _UnitDb.TotalUnitCachPrice; }
            set { _UnitDb.TotalUnitCachPrice = value; }
        }
        #endregion
        #region Constractor
        public UnitSumBiz()
        {
            _UnitDb = new UnitDb();
        }
        public UnitSumBiz(DataRow objDr)
        {
            _UnitDb = new UnitDb(objDr);

        }
        #endregion
    }
}
