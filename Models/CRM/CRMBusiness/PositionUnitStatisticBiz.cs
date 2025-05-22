using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class PositionUnitStatisticBiz
    {
        #region Private Data
        PositionUnitStatisticDb _PositionUnitStatisticDb;
        #endregion
        #region Constructors
        public PositionUnitStatisticBiz()
        {
            _PositionUnitStatisticDb = new PositionUnitStatisticDb();
        }
        public PositionUnitStatisticBiz(DataRow objDR)
        {
            _PositionUnitStatisticDb = new PositionUnitStatisticDb(objDR);
        }
        #endregion
        #region Public Properties
        public string ProjectName
        {
            set
            {
                _PositionUnitStatisticDb.ProjectName = value;
            }
            get
            {
                return _PositionUnitStatisticDb.ProjectName;
            }
        }
        public int TowerNum
        {
            set
            {
                _PositionUnitStatisticDb.TowerNum = value;
            }
            get
            {
                return _PositionUnitStatisticDb.TowerNum;
            }
        }
        public int TotalResidentialUnit
        {
            set
            {
                _PositionUnitStatisticDb.TotalResidentialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.TotalResidentialUnit;
            }
        }
        public int TotalCommercialUnit
        {
            set
            {
                _PositionUnitStatisticDb.TotalCommercialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.TotalCommercialUnit;
            }
        }
        public int TotalOfficesUnit
        {
            set
            {
                _PositionUnitStatisticDb.TotalOfficesUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.TotalOfficesUnit;
            }
        }
        public int DeservedResidentialUnit
        {
            set
            {
                _PositionUnitStatisticDb.DeservedResidentialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.DeservedResidentialUnit;
            }
        }
        public int DeservedCommercialUnit
        {
            set
            {
                _PositionUnitStatisticDb.DeservedCommercialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.DeservedCommercialUnit;
            }
        }
        public int DeservedOfficesUnit
        {
            set
            {
                _PositionUnitStatisticDb.DeservedOfficesUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.DeservedOfficesUnit;
            }
        }
        public int RemainingResidentialUnit
        {
            set
            {
                _PositionUnitStatisticDb.RemainingResidentialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.RemainingResidentialUnit;
            }
        }
        public int RemainingCommercialUnit
        {
            set
            {
                _PositionUnitStatisticDb.RemainingCommercialUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.RemainingCommercialUnit;
            }
        }
        public int RemainingOfficesUnit
        {
            set
            {
                _PositionUnitStatisticDb.RemainingOfficesUnit = value;
            }
            get
            {
                return _PositionUnitStatisticDb.RemainingOfficesUnit;
            }
        }
        public double TotalValue
        {
            set
            {
                _PositionUnitStatisticDb.TotalValue = value;
            }
            get
            {
                return _PositionUnitStatisticDb.TotalValue;
            }
        }
        public double RemainingValue
        {
            set
            {
                _PositionUnitStatisticDb.RemainingValue = value;
            }
            get
            {
                return _PositionUnitStatisticDb.RemainingValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
