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
   
    public class RecursiveTransactionElementBiz
    {
        #region Private Data
        protected RecursiveTransactionElementDb _RecursiveTransactionElementDb;
        AccountBiz _AccountBiz;
        RecursiveTransactionBiz _TransactionBiz;
        CostCenterBiz _CostCenterBiz;
        /// <summary>
        /// Direction presents Either the element is eithe depit or credit
        /// true in Case of Credit œ«∆‰
        /// false in case of debit „œÌ‰
        /// </summary>
        #endregion
        #region Constractors
        public RecursiveTransactionElementBiz()
        {
            _RecursiveTransactionElementDb = new RecursiveTransactionElementDb();
            _AccountBiz = new AccountBiz();
        }
        public RecursiveTransactionElementBiz(DataRow objDR)
        {
            _RecursiveTransactionElementDb = new RecursiveTransactionElementDb(objDR);
            _AccountBiz = new AccountBiz(objDR);
            if (_RecursiveTransactionElementDb.CostCenter != 0)
                _CostCenterBiz = new CostCenterBiz(objDR);
        }
        #endregion
        #region Public Accessorice
        public int ID
        {
            set
            {
                _RecursiveTransactionElementDb.ID = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.ID;
            }
        }
        public int TRansaction
        {
            set
            {
                _RecursiveTransactionElementDb.TRansaction = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.TRansaction;
            }
        }

        public bool Direction
        {
            set
            {
                _RecursiveTransactionElementDb.Direction = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.Direction;
            }
        }
        public double Value
        {
            set
            {
                _RecursiveTransactionElementDb.Value = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.Value;
            }
        }
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
        public double CrditeTotalValue
        {
            set
            {

                if (Direction == true)
                    _RecursiveTransactionElementDb.Value = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.Value;
            }
        }
        public double DebitTotalValue
        {
            set
            {
                if (Direction == false)
                    _RecursiveTransactionElementDb.Value = value;

            }
            get
            {
                return _RecursiveTransactionElementDb.Value;
            }
        }
        public int Order
        {
            set
            {
                _RecursiveTransactionElementDb.Order = value;
            }
            get
            {
                return _RecursiveTransactionElementDb.Order;
            }
        }
        public RecursiveTransactionBiz TransactionBiz
        {
            set
            {
                _TransactionBiz = value;
            }
            get
            {
                return _TransactionBiz;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _RecursiveTransactionElementDb.TRansaction = _TransactionBiz.ID;
            _RecursiveTransactionElementDb.Account = _AccountBiz.ID;
            _RecursiveTransactionElementDb.Add();
        }
        public virtual void Edit()
        {
            _RecursiveTransactionElementDb.Edit();
        }
        public virtual void Delete()
        {
            _RecursiveTransactionElementDb.Delete();
        }
        #endregion
    }
}
