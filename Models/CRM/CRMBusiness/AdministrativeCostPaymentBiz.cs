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
    public class AdministrativeCostPaymentBiz : PaymentBiz
    {
        #region Private Data
        ReservationBiz _ReservationBiz;
        AdministrativeCostTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public AdministrativeCostPaymentBiz()
        {
            _PaymentDb = new AdministrativeCostPaymentDb();
        }
        public AdministrativeCostPaymentBiz(int intID)
        {
            _PaymentDb = new AdministrativeCostPaymentDb(intID);

        }
        public AdministrativeCostPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new AdministrativeCostPaymentDb(objDR);
            if (((AdministrativeCostPaymentDb)_PaymentDb).Type != 0)
                _TypeBiz = new AdministrativeCostTypeBiz(objDR);
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
                return _ReservationBiz;
            }

        }

        
        public AdministrativeCostTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new AdministrativeCostTypeBiz();
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
            ((AdministrativeCostPaymentDb)_PaymentDb).SubDesc = Desc;
            _PaymentDb.Desc =  " مصاريف ادارية :  " +_ReservationBiz.ProjectName + "-" +  _ReservationBiz.DirectUnitCodeStr;
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
            ((AdministrativeCostPaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((AdministrativeCostPaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((AdministrativeCostPaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            GetData();
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            ((AdministrativeCostPaymentDb)_PaymentDb).ReservationID = _ReservationBiz.ID;
            ((AdministrativeCostPaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((AdministrativeCostPaymentDb)_PaymentDb).Edit();
        }
        public void Schedul()
        {
            //((AdministrativeCostPaymentDb)_PaymentDb).Scheduled = true;
            //((AdministrativeCostPaymentDb)_PaymentDb).Schedul();

        }
        public override void Delete()
        {
           ((AdministrativeCostPaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}
