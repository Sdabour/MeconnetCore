using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationUnitBiz
    {
        #region Private data
        ReservationUnitDb _ReservationUnitDb;
        UnitBiz _UnitBiz;
        
        #endregion
        #region Constractors
        public ReservationUnitBiz()
        {
            _ReservationUnitDb = new ReservationUnitDb();
            _UnitBiz = new UnitBiz();
        }
        public ReservationUnitBiz(int intID)
        {
            _ReservationUnitDb = new ReservationUnitDb(intID);
            _UnitBiz = new UnitBiz();
        }
        public ReservationUnitBiz(DataRow objDR)
        {
            _ReservationUnitDb = new ReservationUnitDb(objDR);
            _UnitBiz = new UnitBiz(objDR);
        }
        #endregion
        #region Public accessorices
        public int ReservationID
        {
            set
            {
                _ReservationUnitDb.ReservationID = value;
            }
            get
            {
                return _ReservationUnitDb.ReservationID ;
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
                return _UnitBiz;
            }
        }
        public double UnitPrice
        {
            set
            {
                _ReservationUnitDb.UnitPrice = value;
            }
            get
            {
                return _ReservationUnitDb.UnitPrice;
            }
        }
        public int ChildReservation
        {
            set
            {
                _ReservationUnitDb.ChildReservation = value;
            }
            get
            {
                return _ReservationUnitDb.ChildReservation;
            }
        }
        public double CachPrice
        {
            set
            {
                if (_ReservationUnitDb.UnitPrice == 0)
                    _ReservationUnitDb.CachPrice = value;
                else
                    _ReservationUnitDb.CachPrice = 0;
            }
            get
            {
                double dblUnitSurvey = 0;
                if (_UnitBiz != null)
                    dblUnitSurvey = _UnitBiz.Survey;
                return _ReservationUnitDb.UnitPrice == 0 ? _ReservationUnitDb.CachPrice :
                  (_ReservationUnitDb.UnitPrice * dblUnitSurvey);
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _ReservationUnitDb.DeliveryDate = value;
            }
            get
            {
                return _ReservationUnitDb.DeliveryDate;
            }
        }
        public DateTime RealDeliveryDate
        {
            set
            {
                _ReservationUnitDb.RealDeliveryDate = value;
            }
            get
            {
                return _ReservationUnitDb.RealDeliveryDate;
            }
        
        }
        public bool IsDelivered
        {
            set
            {
                _ReservationUnitDb.IsDelivered = value;
            }
            get
            {
                return _ReservationUnitDb.IsDelivered;
            }
        }
        #endregion
        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _ReservationUnitDb.Add();
        }
        public void DeliverUnit(DateTime dtDeliverDate)
        {
            _ReservationUnitDb.RealDeliveryDate = dtDeliverDate;
            _ReservationUnitDb.UnitID = _UnitBiz.ID;
            //_ReservationUnitDb.ReservationID = _resetr
            _ReservationUnitDb.DeliverUnit();
        }
        public void EditRealDeliveryDate()
        {
            _ReservationUnitDb.UnitID = _UnitBiz.ID;
            _ReservationUnitDb.EditRealDeliveryDate();
        }

        #endregion
    }
}
