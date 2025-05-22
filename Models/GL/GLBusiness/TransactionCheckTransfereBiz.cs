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
    public class TransactionCheckTransfereBiz : TransactionBiz
    {
        #region PrivateData
        #endregion

        #region Constractors
        public TransactionCheckTransfereBiz()
        {
            _TransactionDb = new TransactionCheckTransfereDb();
        }
        public TransactionCheckTransfereBiz(int intID)
        {
            _TransactionDb = new TransactionCheckTransfereDb(intID);

        }
        public TransactionCheckTransfereBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCheckTransfereDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int SrcAccount
        {
            set
            {
                ((TransactionCheckTransfereDb)_TransactionDb).SrcAccount = value;
            }
            get
            {
                return ((TransactionCheckTransfereDb)_TransactionDb).SrcAccount;
            }
        }
        public double Check
        {
            set
            {
                ((TransactionCheckTransfereDb)_TransactionDb).Check = value;
            }
            get
            {
                return ((TransactionCheckTransfereDb)_TransactionDb).Check;
            }
        }
        public int DestAccount
        {
            set
            {
                ((TransactionCheckTransfereDb)_TransactionDb).DestAccount = value;
            }
            get
            {
                return ((TransactionCheckTransfereDb)_TransactionDb).DestAccount;
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
