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
    public class TransactionCacheTransfereBiz : TransactionBiz
    {
        #region PrivateData
        #endregion

        #region Constractors
        public TransactionCacheTransfereBiz()
        {
            _TransactionDb = new TransactionCacheTransfereDb();
        }
        public TransactionCacheTransfereBiz(int intID)
        {
            _TransactionDb = new TransactionCacheTransfereDb(intID);

        }
        public TransactionCacheTransfereBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCacheTransfereDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int SrcAccount
        {
            set
            {
                ((TransactionCacheTransfereDb)_TransactionDb).SrcAccount = value;
            }
            get
            {
                return ((TransactionCacheTransfereDb)_TransactionDb).SrcAccount;
            }
        }
        public double Value
        {
            set
            {
                ((TransactionCacheTransfereDb)_TransactionDb).Value = value;
            }
            get
            {
                return ((TransactionCacheTransfereDb)_TransactionDb).Value;
            }
        }
        public int DestAccount
        {
            set
            {
                ((TransactionCacheTransfereDb)_TransactionDb).DestAccount = value;
            }
            get
            {
                return ((TransactionCacheTransfereDb)_TransactionDb).DestAccount;
            }
        }
       
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        
        public override void  Add()
        {
            base.Add();
        }
        public override void Edit()
        {
            base.Edit();
        }
        public override void Delete()
        {
            base.Delete();
        }
        #endregion
    }
}
