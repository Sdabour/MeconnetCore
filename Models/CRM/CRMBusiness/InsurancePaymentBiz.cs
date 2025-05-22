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
    public class InsurancePaymentBiz : PaymentBiz
    {
        #region Private Data
        ReservationBiz _ReservationBiz;
        InsuranceTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public InsurancePaymentBiz()
        {
            _PaymentDb = new InsurancePaymentDb();
        }
        public InsurancePaymentBiz(int intID)
        {
            _PaymentDb = new InsurancePaymentDb(intID);

        }
        public InsurancePaymentBiz(DataRow objDR)
        {
            _PaymentDb = new InsurancePaymentDb(objDR);
            if (((InsurancePaymentDb)_PaymentDb).Type != 0)
                _TypeBiz = new InsuranceTypeBiz(objDR);
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


        public InsuranceTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new InsuranceTypeBiz();
                return _TypeBiz;
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
            ((InsurancePaymentDb)_PaymentDb).SubDesc = Desc;
            _PaymentDb.Desc = " „œ›Ê⁄«   √„Ì‰ :  " + _ReservationBiz.ProjectName + "-" + _ReservationBiz.DirectUnitCodeStr;
            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            GetData();
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            ((InsurancePaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((InsurancePaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((InsurancePaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            GetData();
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            ((InsurancePaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((InsurancePaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((InsurancePaymentDb)_PaymentDb).Edit();
        }
        public void Schedul()
        {
            //((InsurancePaymentDb)_PaymentDb).Scheduled = true;
            //((InsurancePaymentDb)_PaymentDb).Schedul();

        }
        public override void Delete()
        {
            ((InsurancePaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}
