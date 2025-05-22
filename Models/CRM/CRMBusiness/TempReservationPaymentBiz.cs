using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class TempReservationPaymentBiz : PaymentBiz
    {
        #region Private Data
        ReservationBiz _ReservationBiz;
        #endregion
        #region Constructors
        public TempReservationPaymentBiz()
        {
            _PaymentDb = new TempReservationPaymentDb();
        }
        public TempReservationPaymentBiz(int intID)
        {
            _PaymentDb = new TempReservationPaymentDb(intID);

        }
        public TempReservationPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new TempReservationPaymentDb(objDR);

            _PaymentDb.Desc = _PaymentDb.SubDesc;
            if (_PaymentDb.CheckID != 0)
                _CheckBiz = new CheckBiz(objDR);
            else
                _CheckBiz = new CheckBiz();

        }
        #endregion
        #region Public Properties
       
       
        public ReservationBiz  ReservationBiz
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

        
        public bool Scheduled
        {
            set
            {
                ((TempReservationPaymentDb)_PaymentDb).Scheduled = value;
            }
            get
            {
                return ((TempReservationPaymentDb)_PaymentDb).Scheduled;
            }

        }
        public string DateStr
        {
            get
            {
                return Date.ToString("dd-MM-yyyy");
            }
        }
        #endregion
        #region Private Methods
        internal void GetData()
        {
            _PaymentDb.Currency = 1;
            _PaymentDb.CurrencyValue = 1;
            if (_CheckBiz != null && _CheckBiz.Value > 0 && _CheckBiz.ID == 0)
            {
                _CheckBiz.Status = CheckStatus.Postponeded;
                _CheckBiz.Add();
            }
            if (_CheckBiz != null && _CheckBiz.ID != 0)
            {
                _PaymentDb.CheckID = _CheckBiz.ID;
                _PaymentDb.CheckPreviousTotalPayment = _CheckBiz.TotalPayment;
            }
            _PaymentDb.SubDesc = Desc;
            _PaymentDb.Desc = " دفعة " +  ReservationBiz.DirectProjectName + "-"  + ReservationBiz.DirectUnitCodeStr ;
            _PaymentDb.CofferID = CofferBiz.ID;
            //_PaymentDb.Desc = "";
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
          
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            GetData();
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            ((TempReservationPaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((TempReservationPaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            GetData();
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            ((TempReservationPaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((TempReservationPaymentDb)_PaymentDb).Edit();
        }
        public void Schedul()
        {
            ((TempReservationPaymentDb)_PaymentDb).Scheduled = true;
            ((TempReservationPaymentDb)_PaymentDb).Schedul();

        }
        public override void Delete()
        {
           ((TempReservationPaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}
