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
    public class UnitPeripheralBiz
    {
        #region Private Data
        UnitPeripheralDb _PeripheralDb;
        UnitBiz _UnitBiz;
        PeripheralTypeBiz _TypeBiz;


        #endregion
        #region Constructors
        public UnitPeripheralBiz()
        {
            _PeripheralDb = new UnitPeripheralDb();
        }
        public UnitPeripheralBiz(DataRow objDr)
        {
            _PeripheralDb = new UnitPeripheralDb(objDr);
            if(_PeripheralDb.Type != 0)
               _TypeBiz = new PeripheralTypeBiz(objDr);
            
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _PeripheralDb.ID = value;
            }
            get
            {
                return _PeripheralDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _PeripheralDb.Desc = value;
            }
            get
            {
                return _PeripheralDb.Desc;
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
        public PeripheralTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new PeripheralTypeBiz();
                return _TypeBiz;
            }
        }
        public double Survey
        {
            set
            {
                _PeripheralDb.Survey = value;
            }
            get
            {
                return _PeripheralDb.Survey;
            }
        }
        public double UnitPrice
        {
            set
            {
                _PeripheralDb.UnitPrice = value;
            }
            get
            {
                return _PeripheralDb.UnitPrice;
            }
        }
        public double TotalPrice
        {
            get => UnitPrice * Survey;
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
