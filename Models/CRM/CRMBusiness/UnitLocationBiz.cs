using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitLocationBiz
    {
        #region Private Data
        UnitLocationDb _UnitLocationDb;
        CellLocationBiz _LocationBiz;
        UnitBiz _UnitBiz;
        #endregion
        #region Constructors
        public UnitLocationBiz()
        {
            _UnitLocationDb = new UnitLocationDb();

        }
        public UnitLocationBiz(DataRow objDr)
        {
            _UnitLocationDb = new UnitLocationDb(objDr);
            _UnitBiz = new UnitBiz(objDr);
            _LocationBiz = new CellLocationBiz(objDr);
        }
        #endregion
        #region Public Properties
        public UnitBiz UnitBiz
        {
            set
            {
                _UnitBiz = value;
            }
            get
            {
                return _UnitBiz;
            }
        }
        public CellLocationBiz LocationBiz
        {
            set
            {
                _LocationBiz = value;
            }
            get
            {
                return _LocationBiz;
            }
        
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _UnitLocationDb.LocationID = _LocationBiz.ID;
            _UnitLocationDb.UnitID = _UnitBiz.ID;
            _UnitLocationDb.Add();
        }
        public void Edit()
        {
            _UnitLocationDb.LocationID = _LocationBiz.ID;
            _UnitLocationDb.UnitID = _UnitBiz.ID;
            _UnitLocationDb.Edit();
        }
        #endregion
    }
}
