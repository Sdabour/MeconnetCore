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
    public class TransactionCheckDepositBiz : TransactionBiz
    {
        #region PrivateData
        #endregion

        #region Constractors
        public TransactionCheckDepositBiz()
        {
            _TransactionDb = new TransactionCheckDepositDb();
        }
        public TransactionCheckDepositBiz(int intID)
        {
            _TransactionDb = new TransactionCheckDepositDb(intID);

        }
        public TransactionCheckDepositBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionCheckDepositDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Account
        {
            set
            {
                ((TransactionCheckDepositDb)_TransactionDb).Account = value;
            }
            get
            {
                return ((TransactionCheckDepositDb)_TransactionDb).Account;
            }
        }
        public double Check
        {
            set
            {
                ((TransactionCheckDepositDb)_TransactionDb).Check = value;
            }
            get
            {
                return ((TransactionCheckDepositDb)_TransactionDb).Check;
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
