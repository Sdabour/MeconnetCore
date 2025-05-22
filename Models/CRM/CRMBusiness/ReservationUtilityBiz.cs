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
    public class ReservationUtilityBiz
    {
        #region Private Data
        ReservationUtilityDb _ReservationUtilityDb; 
        UtilityTypeBiz _UtilityTypeBiz;
        ReservationBiz _ReservationBiz;
        UtilityPaymentCol _PaymentCol;
        ReservationBiz _NewReservationBiz;
        #endregion
        
        #region Constructors
        public ReservationUtilityBiz()
        {
            _ReservationUtilityDb = new ReservationUtilityDb();
        }
        public ReservationUtilityBiz(int intID)
        {
            _ReservationUtilityDb = new ReservationUtilityDb(intID);  
        }
        public ReservationUtilityBiz(DataRow objDR)
        {
            _ReservationUtilityDb = new ReservationUtilityDb(objDR);
            _UtilityTypeBiz = new UtilityTypeBiz(objDR);
        }
        #endregion
        #region Public Properties

        public UtilityTypeBiz UtilityTypeBiz
        {
            set
            {
                _UtilityTypeBiz = value;
            }
            get
            {
                return _UtilityTypeBiz;
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
        public UtilityPaymentCol PaymentCol
        {
            set
            {
                _PaymentCol = value;
            }
            get
            {
                return _PaymentCol;
            }
        }
        public int ID
        {
            set
            {
                _ReservationUtilityDb.ID = value;
            }
            get
            {
                return _ReservationUtilityDb.ID;
            }

        }
        public int UtilityTypeID
        {
            set
            {
                _ReservationUtilityDb.UtilityTypeID = value;
            }
            get
            {
                return _ReservationUtilityDb.UtilityTypeID;
            }

        }
        public double Value
        {
            set
            {
                _ReservationUtilityDb.Value = value;
            }
            get
            {
                return _ReservationUtilityDb.Value;
            }

        }
        public bool Scheduled
        {
            set
            {
                _ReservationUtilityDb.Scheduled = value;
            }
            get
            {
                return _ReservationUtilityDb.Scheduled;
            }
        }
        internal ReservationBiz NewReservationBiz
        {
            set
            {
                _NewReservationBiz = value;
            }
            get
            {
                if (_NewReservationBiz == null)
                    _NewReservationBiz = new ReservationBiz();
                return _NewReservationBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReservationUtilityDb.ReservationID = _ReservationBiz.ID;
            _ReservationUtilityDb.UtilityTypeID = _UtilityTypeBiz.ID;
            _ReservationUtilityDb.Add();
        }
        public void Edit()
        {

            _ReservationUtilityDb.ReservationID = _ReservationBiz.ID;
            _ReservationUtilityDb.UtilityTypeID = _UtilityTypeBiz.ID;
            _ReservationUtilityDb.Edit();
        }
        public void PayUtility()
        {
            _ReservationUtilityDb.UtilityStatus = 1;
            _ReservationUtilityDb.EditStatus();
        }
        public void Schedul()
        {
            _ReservationUtilityDb.Scheduled = true;
            _ReservationUtilityDb.Schedul();

        }
        public void Delete()
        {
            _ReservationUtilityDb.Delete();
        }
        public void EditCurrentReservation(ReservationBiz objReservationBiz)
        {
            _ReservationUtilityDb.NewReservationID = objReservationBiz.ID;
            _ReservationUtilityDb.EditNewReservation();
        }
        /// <summary>
        /// GetOverrideCopy():Return a new Copy of the function with new Reservation Id to help in Cession Process;
        /// </summary>
        /// <param name="objReservationBiz">presents the new reservation</param>
        public ReservationUtilityBiz GetOverrideCopy(ReservationBiz objReservationBiz)
        {
            ReservationUtilityBiz Returned = new ReservationUtilityBiz();
            Returned._ReservationUtilityDb = _ReservationUtilityDb;
            Returned._ReservationUtilityDb.ID = 0;
            Returned.ReservationBiz = _ReservationBiz;
            return Returned;

        }
        #endregion
    }
}
