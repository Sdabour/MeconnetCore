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
    public class TransactionCheckWithdrawBiz : TransactionBiz
    {
        #region PrivateData
        #endregion

        #region Constractors
        public TransactionCheckWithdrawBiz()
        {
            _TransactionDb = new TransactionCheckWithdrawDb();
        }
        public TransactionCheckWithdrawBiz(int intID)
        {
            _TransactionDb = new TransactionCheckWithdrawDb(intID);

        }
        public TransactionCheckWithdrawBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCheckWithdrawDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Account
        {
            set
            {
                ((TransactionCheckWithdrawDb)_TransactionDb).Account = value;
            }
            get
            {
                return ((TransactionCheckWithdrawDb)_TransactionDb).Account;
            }
        }
        public double Check
        {
            set
            {
                ((TransactionCheckWithdrawDb)_TransactionDb).Check = value;
            }
            get
            {
                return ((TransactionCheckWithdrawDb)_TransactionDb).Check;
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
