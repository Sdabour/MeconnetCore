using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.GL.GLBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationPayBackBiz : PaymentBiz
    {
        #region Private Data
        //ReservationPayBackDb _ReservationPayBackDb;
        //ReservationCanceledBiz _ReservationCanceledBiz;
        ReservationBiz _ReservationBiz;
        #endregion

        #region Constractors
        public ReservationPayBackBiz()
        {
            _PaymentDb = new ReservationPayBackDb();
        }
       
        public ReservationPayBackBiz(DataRow objDR)
        {
            _PaymentDb = new ReservationPayBackDb(objDR);
            if (_PaymentDb.CheckID != 0)
                _CheckBiz = new CheckBiz(objDR);
            else
                _CheckBiz = new CheckBiz();
        }
        #endregion

        #region public Accessorice
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
            _PaymentDb.Desc = "«” —œ«œ ﬁÌ„… ›”Œ «·⁄ﬁœ ⁄‰ «·ÊÕœ… : " + _ReservationBiz.ProjectName + "-" + _ReservationBiz.DirectUnitCodeStr;
            ((ReservationPayBackDb)_PaymentDb).ReservationID = ReservationBiz.ID;

            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
        }
        #endregion

        #region Public Methods
        public void Add()
        {
           // _ReservationPayBackDb.ReservationID = _ReservationBiz.ID;
            GetData();
            _PaymentDb.Add();
        }
        public void Edit()
        {
            GetData();
            _PaymentDb.Edit();
        }
        public void Delete()
        {
            _PaymentDb.Delete();
        }
        #endregion
    }
}
