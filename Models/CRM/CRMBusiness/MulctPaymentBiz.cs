using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class MulctPaymentBiz : PaymentBiz
    {
        #region Private Data
        ReservationBiz _ReservationBiz;
        #endregion
        #region Constructors
        public MulctPaymentBiz()
        {
             _PaymentDb = new MulctPaymentDb();
        }
        public MulctPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new MulctPaymentDb(objDR);
            if (_PaymentDb.CheckID != 0)
                _CheckBiz = new CheckBiz(objDR);
            else
                _CheckBiz = new CheckBiz();
        }
        #endregion
        #region Public Properties
        public ReservationBiz ReservationBiz
        {
            set
            {
                _ReservationBiz = value;
            }
            get
            {
                return _ReservationBiz;
            }
        }
        #endregion
        #region Private Methods
        void GetData()
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
            _PaymentDb.SubDesc = _PaymentDb.Desc;
            _PaymentDb.Desc = "€—«„… ⁄·Ï «·ÊÕœ… :" + _ReservationBiz.ProjectName + "-" + ReservationBiz.DirectUnitCodeStr;

            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;

        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            GetData();
            ((MulctPaymentDb)_PaymentDb).Reservation = _ReservationBiz.ID;
            ((MulctPaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            GetData();
            ((MulctPaymentDb)_PaymentDb).Reservation = _ReservationBiz.ID;
            ((MulctPaymentDb)_PaymentDb).Edit();
        }
        public void Delete()
        {
            ((MulctPaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}
