using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public class DirectPaymentBiz : PaymentBiz
    {
        #region Private Data
   
       DirectPaymentTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public DirectPaymentBiz()
        {
            _PaymentDb = new DirectPaymentDb();
        }
        public DirectPaymentBiz(int intID)
        {
            _PaymentDb = new DirectPaymentDb(intID);

        }
        public DirectPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new DirectPaymentDb(objDR);
            if (((DirectPaymentDb)_PaymentDb).Type != 0)
                _TypeBiz = new DirectPaymentTypeBiz(objDR);

        }
        #endregion
        #region Public Properties


      


        public DirectPaymentTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new DirectPaymentTypeBiz();
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
            ((DirectPaymentDb)_PaymentDb).SubDesc = Desc;
            _PaymentDb.Desc = " „’«—Ì› «Œ—Ï ";
            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            GetData();
          
            ((DirectPaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((DirectPaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            GetData();
            
           
            ((DirectPaymentDb)_PaymentDb).Type = TypeBiz.ID;
            ((DirectPaymentDb)_PaymentDb).Edit();
        }
        public void Schedul()
        {
            //((DirectPaymentDb)_PaymentDb).Scheduled = true;
            //((DirectPaymentDb)_PaymentDb).Schedul();

        }
        public override void Delete()
        {
            ((DirectPaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}

 