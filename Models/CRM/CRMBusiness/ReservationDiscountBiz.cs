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
    public class ReservationDiscountBiz
    {
        #region Private Data
        ReservationDiscountDb _ReservationDiscountDb;
        ReservationBiz _ReservationBiz;
        DiscountTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public ReservationDiscountBiz()
        {

            _ReservationDiscountDb = new ReservationDiscountDb();
            //_TypeBiz = new DiscountTypeBiz();
        }
        public ReservationDiscountBiz(int intID)
        {
            _ReservationDiscountDb = new ReservationDiscountDb(intID);
            //_TypeBiz = new DiscountTypeBiz();

        }
        public ReservationDiscountBiz(DataRow objDR)
        {
            _ReservationDiscountDb = new ReservationDiscountDb(objDR);
            if (_ReservationDiscountDb.TypeID != 0)
                _TypeBiz = new DiscountTypeBiz(objDR);
            else
                _TypeBiz = new DiscountTypeBiz();

        }
        #endregion
        #region Public Properties
        public DateTime Date
        {
            set
            {
                _ReservationDiscountDb.Date = value;
            }
            get
            {
                return _ReservationDiscountDb.Date;
            }

        }
        public string Reason
        {
            set
            {
                _ReservationDiscountDb.Reason = value;
            }
            get
            {
                return _ReservationDiscountDb.Reason;
            }

        }
        public double Value
        {
            set
            {
                _ReservationDiscountDb.Value = value;
            }
            get
            {
                return _ReservationDiscountDb.Value;
            }

        }

        public ReservationBiz ReservationBiz
        {
            set
            {
                _ReservationBiz = value;
            }
            get
            {
                if (_ReservationBiz == null)
                    _ReservationBiz = new ReservationBiz();
                return _ReservationBiz;
            }

        }
        internal int ReservationID
        {
            get
            {
                return _ReservationDiscountDb.ReservationID;
            }
        }
        public int ID
        {
            set
            {
                _ReservationDiscountDb.ID = value;
            }
            get
            {
                return _ReservationDiscountDb.ID;
            }

        }
        public bool Scheduled
        {
            set
            {

                _ReservationDiscountDb.Scheduled = value;
            }
            get
            {
                return _ReservationDiscountDb.Scheduled;
            }

        }
        public DiscountTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReservationDiscountDb.ReservationID = _ReservationBiz.ID;
            _ReservationDiscountDb.TypeID = _TypeBiz.ID;
            _ReservationDiscountDb.Add();
        }
        public void Edit()
        {
            _ReservationDiscountDb.ReservationID = _ReservationBiz.ID;
            _ReservationDiscountDb.TypeID = _TypeBiz.ID;

            _ReservationDiscountDb.Edit();
        }
        public void Schedul()
        {
            _ReservationDiscountDb.Scheduled = true;
            _ReservationDiscountDb.Schedul();

        }
        public void Delete()
        {
            _ReservationDiscountDb.Delete();
        }
        public ReservationDiscountBiz Copy()
        {
            ReservationDiscountBiz Returned = new ReservationDiscountBiz();
            Returned._ReservationDiscountDb = _ReservationDiscountDb;
            Returned._ReservationDiscountDb.ID = 0;
            return Returned;
        }
        #endregion
    }
}
