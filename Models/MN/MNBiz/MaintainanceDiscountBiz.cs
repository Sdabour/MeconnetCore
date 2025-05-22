using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using AlgorithmatMN.MN.MNDb;
 
 
namespace AlgorithmatMN.MN.MNBiz
{
    public class MaintainanceDiscountBiz
    {

        #region Constructor
        public MaintainanceDiscountBiz()
        {
            _MaintainanceDiscountDb = new MaintainanceDiscountDb();
        }
        public MaintainanceDiscountBiz(DataRow objDr)
        {
            _MaintainanceDiscountDb = new MaintainanceDiscountDb(objDr);
            _ROBiz = new ROBiz(objDr);
            _TypeBiz = new MaintainanceDiscountTypeBiz(objDr);
        }

        #endregion
        #region Private Data
        MaintainanceDiscountDb _MaintainanceDiscountDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _MaintainanceDiscountDb.ID = value;
            }
            get
            {
                return _MaintainanceDiscountDb.ID;
            }
        }
        public int CreditROID
        {
            set
            {
                _MaintainanceDiscountDb.CreditROID = value;
            }
            get
            {
                return _MaintainanceDiscountDb.CreditROID;
            }
        }
        public int CreditID
        {
            set
            {
                _MaintainanceDiscountDb.CreditID = value;
            }
            get
            {
                return _MaintainanceDiscountDb.CreditID;
            }
        }
        public int Type
        {
            set
            {
                _MaintainanceDiscountDb.Type = value;
            }
            get
            {
                return _MaintainanceDiscountDb.Type;
            }
        }
        public DateTime Date
        {
            set
            {
                _MaintainanceDiscountDb.Date = value;
            }
            get
            {
                return _MaintainanceDiscountDb.Date;
            }
        }
        public string Desc
        {
            set
            {
                _MaintainanceDiscountDb.Desc = value;
            }
            get
            {
                return _MaintainanceDiscountDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _MaintainanceDiscountDb.Value = value;
            }
            get
            {
                return _MaintainanceDiscountDb.Value;
            }
        }
        ROBiz _ROBiz;
        public ROBiz ROBiz
        { get 
            { if (_ROBiz == null) _ROBiz = new ROBiz();return _ROBiz; }
            set => _ROBiz = value;
        }
        MaintainanceDiscountTypeBiz _TypeBiz;
        public MaintainanceDiscountTypeBiz TypeBiz
        { get {
                if (_TypeBiz == null)
                    _TypeBiz = new MaintainanceDiscountTypeBiz();
                return _TypeBiz;
            }
            set => _TypeBiz = value;
        } 
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MaintainanceDiscountDb.CreditROID = ROBiz.ID;
            _MaintainanceDiscountDb.Add();
        }
        public void Edit()
        {
            _MaintainanceDiscountDb.CreditROID = ROBiz.ID;
            _MaintainanceDiscountDb.Edit();
        }
        public void Delete()
        {
            _MaintainanceDiscountDb.Delete();
        }
        #endregion

    }
}
