using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMN.MN.MNDb;
using System.Data;
using SharpVision.GL.GLBusiness;
namespace AlgorithmatMN.MN.MNBiz
{
    public class TempMaintainancePaymentBiz
    {

        #region Constructor
        public TempMaintainancePaymentBiz()
        {
            _PaymentDb = new TempMaintainancePaymentDb();
        }
        public TempMaintainancePaymentBiz(DataRow objDr)
        {
            _PaymentDb = new TempMaintainancePaymentDb(objDr);
        }

        #endregion
        #region Private Data
        TempMaintainancePaymentDb _PaymentDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _PaymentDb.ID = value;
            }
            get
            {
                return _PaymentDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _PaymentDb.Date = value;
            }
            get
            {
                return _PaymentDb.Date;
            }
        }
        public double Value
        {
            set
            {
                _PaymentDb.Value = value;
            }
            get
            {
                return _PaymentDb.Value;
            }
        }
        public int InternalRef
        {
            set
            {
                _PaymentDb.InternalRef = value;
            }
            get
            {
                return _PaymentDb.InternalRef;
            }
        }
        public int PayementInternalType
        {
            set
            {
                _PaymentDb.PayementInternalType = value;
            }
            get
            {
                return _PaymentDb.PayementInternalType;
            }
        }
        public string Desc
        {
            set
            {
                _PaymentDb.Desc = value;
            }
            get
            {
                return _PaymentDb.Desc;
            }
        }
        public int System
        {
            set
            {
                _PaymentDb.System = value;
            }
            get
            {
                return _PaymentDb.System;
            }
        }
        public int GLID
        {
            set
            {
                _PaymentDb.GLID = value;
            }
            get
            {
                return _PaymentDb.GLID;
            }
        }
        public string BankRef
        {
            set
            {
                _PaymentDb.BankRef = value;
            }
            get
            {
                return _PaymentDb.BankRef;
            }
        }
       MaintainancePaymentBiz  _MaintainancePaymentBiz;
        public MaintainancePaymentBiz GLPaymentBiz
        { set => _MaintainancePaymentBiz = value;
        get
            {
                if (_MaintainancePaymentBiz == null)
                {
                    _MaintainancePaymentBiz = new MaintainancePaymentBiz();
                }
                    return _MaintainancePaymentBiz;
            }
        }
        public string TempPaymentRef
        { get => _PaymentDb.TempPaymentRef; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _PaymentDb.Add();
        }
        public void Edit()
        {
            _PaymentDb.Edit();
        }
        public void Delete()
        {
            _PaymentDb.Delete();
        }
        #endregion
    }
}