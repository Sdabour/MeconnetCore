using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public class TransactionCheckPaymentBiz : TransactionBiz
    {
        #region Private Data
        protected CheckBiz _CheckBiz;
        #endregion

        #region Constractors
        public TransactionCheckPaymentBiz()
        {
            _TransactionDb = new TransactionCheckPaymentDb();
        }
        public TransactionCheckPaymentBiz(int intID)
        {
            _TransactionDb = new TransactionCheckPaymentDb(intID);
        }
        public TransactionCheckPaymentBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCheckPaymentDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public CheckBiz CheckBiz
        {
            set
            {
                _CheckBiz = value;
            }
            get
            {
                return _CheckBiz;
            }
        }
        public double Value
        {
            set
            {
                ((TransactionCheckPaymentDb)_TransactionDb).Value = value;
            }
            get
            {
                return ((TransactionCheckPaymentDb)_TransactionDb).Value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {

            base.Add();
            ((TransactionCheckPaymentDb)_TransactionDb).CheckID = CheckBiz.ID;
            ((TransactionCheckPaymentDb)_TransactionDb).Add();

        }
        public override void Edit()
        {
            base.Edit();
            ((TransactionCheckPaymentDb)_TransactionDb).CheckID = CheckBiz.ID;
            ((TransactionCheckPaymentDb)_TransactionDb).Add();
        }
        
        #endregion
    }
}
