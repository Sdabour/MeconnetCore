using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class CheckPaymentBiz
    {
        #region Private Data
        CheckPaymentDb _CheckPaymentDb;
        
        #endregion
        #region Constractors
        public CheckPaymentBiz()
        {
            _CheckPaymentDb = new CheckPaymentDb();
        }
        public CheckPaymentBiz(DataRow objDR)
        {
            _CheckPaymentDb = new CheckPaymentDb(objDR);
        }
        #endregion
        #region Public Accessorice
        public int CheckID
        {
            set
            {
                _CheckPaymentDb.CheckID = value;
            }
            get
            {
                return _CheckPaymentDb.CheckID;
            }
        }
        public int PaymentID
        {
            set
            {
                _CheckPaymentDb.PaymentID = value;
            }
            get
            {
                return _CheckPaymentDb.PaymentID;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            _CheckPaymentDb.Add();
        }
        #endregion
    }
}
