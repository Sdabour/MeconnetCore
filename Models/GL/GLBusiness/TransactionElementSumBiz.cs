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
    public class TransactionElementSumBiz
    {
        #region Private Data
        AccountBiz _AccountBiz;
        CostCenterBiz _CostCenterBiz;
        TransactionElementDb _TransactionElementDb;
        #endregion
        #region Constructors
        public TransactionElementSumBiz()
        {
 
        }
        public TransactionElementSumBiz(DataRow objDr)
        {
            _TransactionElementDb = new TransactionElementDb(objDr);
            if (_TransactionElementDb.Account != 0)
                _AccountBiz = new AccountBiz(objDr);

        }
        #endregion
        #region Public Accessorice
      
       

     
       
        public AccountBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBiz();
                return _AccountBiz;
            }
        }
        public CostCenterBiz CostCenterBiz
        {
            set
            {
                _CostCenterBiz = value;
            }
            get
            {
                if (_CostCenterBiz == null)
                    _CostCenterBiz = new CostCenterBiz();
                return _CostCenterBiz;
            }
        }
      
      
        public string Desc
        {
            set
            {
                _TransactionElementDb.Desc = value;
            }
            get
            {
                return _TransactionElementDb.Desc;
            }
        }
        public double TotalCreditValue
        {
           
            get
            {
                return _TransactionElementDb.TotalCreditValue;
            }
        }
        public double TotalDebitValue
        {
           
            get
            {
                return _TransactionElementDb.TotalDebitValue;
            }
        }
           #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
