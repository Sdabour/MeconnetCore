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
    
    public class UtilityPaymentBiz : PaymentBiz
    {

        #region Private Data
        ReservationUtilityBiz _UtilityBiz;
        #endregion
        #region Constructors

        public UtilityPaymentBiz()
        {
            _PaymentDb = new UtilityPaymentDb();
            _UtilityBiz = new ReservationUtilityBiz();
        }

        public UtilityPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new UtilityPaymentDb(objDR);
            _UtilityBiz = new ReservationUtilityBiz();

        }

        #endregion
        #region Public Properties

       

        public int UtilityID
        {
            set
            {
                ((UtilityPaymentDb)_PaymentDb).UtilityID = value;
            }
            get
            {
                return ((UtilityPaymentDb)_PaymentDb).UtilityID;
            }

        }

        
        public ReservationUtilityBiz UtilityBiz
        {
            set
            {
                _UtilityBiz = value;
            }
            get
            {
                return _UtilityBiz;
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


        }
        #endregion
        #region Public Methods
       
        public override void Add()
        {
            GetData();
            ((UtilityPaymentDb)_PaymentDb).UtilityID = _UtilityBiz.UtilityTypeID;
            ((UtilityPaymentDb)_PaymentDb).Add();
        }

        public override void Edit()
        {
            GetData();
            ((UtilityPaymentDb)_PaymentDb).UtilityID = _UtilityBiz.UtilityTypeID;
            ((UtilityPaymentDb)_PaymentDb).Edit();
        }

        public override void Delete()
        {
            ((UtilityPaymentDb)_PaymentDb).Delete();
        }
   
        #endregion

    }
}
