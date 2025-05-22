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
    public class ReservationBonusBiz
    {
        #region Private Data
        ReservationBonusDb _ReservationBonusDb;
        ReservationBiz _ReservationBiz;
        BonusTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public ReservationBonusBiz()
        {

            _ReservationBonusDb = new ReservationBonusDb();
            //_TypeBiz = new BonusTypeBiz();
        }
        public ReservationBonusBiz(int intID)
        {
            _ReservationBonusDb = new ReservationBonusDb(intID);
            //_TypeBiz = new BonusTypeBiz();

        }
        public ReservationBonusBiz(DataRow objDR)
        {
            _ReservationBonusDb = new ReservationBonusDb(objDR);
            if (_ReservationBonusDb.TypeID != 0)
                _TypeBiz = new BonusTypeBiz(objDR);
            else
                _TypeBiz = new BonusTypeBiz();

        }
        #endregion
        #region Public Properties
        public DateTime Date
        {
            set
            {
                _ReservationBonusDb.Date = value;
            }
            get
            {
                return _ReservationBonusDb.Date;
            }

        }
        public string Reason
        {
            set
            {
                _ReservationBonusDb.Reason = value;
            }
            get
            {
                return _ReservationBonusDb.Reason;
            }

        }
        public double Value
        {
            set
            {
                _ReservationBonusDb.Value = value;
            }
            get
            {
                return _ReservationBonusDb.Value;
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

        public int ID
        {
            set
            {
                _ReservationBonusDb.ID = value;
            }
            get
            {
                return _ReservationBonusDb.ID;
            }

        }
        public bool Scheduled
        {
            set
            {

                _ReservationBonusDb.Scheduled = value;
            }
            get
            {
                return _ReservationBonusDb.Scheduled;
            }

        }
        public BonusTypeBiz TypeBiz
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
        public int ReservationID
        {
            set => _ReservationBonusDb.ReservationID=value;
            get => _ReservationBonusDb.ReservationID;

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReservationBonusDb.ReservationID = _ReservationBiz.ID;
            _ReservationBonusDb.TypeID = _TypeBiz.ID;
            _ReservationBonusDb.Add();
        }
        public void Edit()
        {
            _ReservationBonusDb.ReservationID = _ReservationBiz.ID;
            _ReservationBonusDb.TypeID = _TypeBiz.ID;
            _ReservationBonusDb.Edit();
        }
        public void Schedul()
        {
            _ReservationBonusDb.Scheduled = true;
            _ReservationBonusDb.Schedul();

        }
        public void Delete()
        {
            _ReservationBonusDb.Delete();
        }
        public ReservationBonusBiz Copy()
        {
            ReservationBonusBiz Returned = new ReservationBonusBiz();
            Returned._ReservationBonusDb = _ReservationBonusDb;
            Returned._ReservationBonusDb.ID = 0;
            return Returned;
        }
        #endregion
    }
}
