using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
//using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitCellBiz
    {
        #region Private Data
        UnitBiz _UnitBiz;
        CellFloorBiz _cellBiz;
        UnitCellDb _UnitCellDb;
        #endregion
        #region Constructors
        public UnitCellBiz()
        {
            _cellBiz = new CellFloorBiz();
            _UnitBiz = new UnitBiz();
            _UnitCellDb = new UnitCellDb();
        }
        public UnitCellBiz(DataRow objDr)
        {
            _UnitCellDb = new UnitCellDb(objDr);
            _cellBiz = new CellFloorBiz(_UnitCellDb.CellID);
            
            
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
        public CellFloorBiz CellBiz
        {
            set
            {
                _cellBiz = value;
            }
            get
            {
                if (_cellBiz == null)
                    _cellBiz = new CellFloorBiz();
                return _cellBiz;
            }
        }
        public double Survey
        {
            set
            {
                _UnitCellDb.Survey = value;
            }
            get
            {
                return _UnitCellDb.Survey;
            }
        }
        public int Order
        {
            set
            {
                _UnitCellDb.Order = value;
            }
            get
            {
                return _UnitCellDb.Order;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
