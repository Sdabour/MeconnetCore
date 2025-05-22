using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;

namespace AlgorithmatMN.MN.MNBiz
{
    public class MaintainanceDiscountTypeBiz
    {
        #region Constructor
        public MaintainanceDiscountTypeBiz()
        {
            _MaintainanceDiscountTypeDb = new MaintainanceDiscountTypeDb();
        }
        public MaintainanceDiscountTypeBiz(DataRow objDr)
        {
            _MaintainanceDiscountTypeDb = new MaintainanceDiscountTypeDb(objDr);
        }

        #endregion
        #region Private Data
        MaintainanceDiscountTypeDb _MaintainanceDiscountTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _MaintainanceDiscountTypeDb.ID = value;
            }
            get
            {
                return _MaintainanceDiscountTypeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _MaintainanceDiscountTypeDb.Code = value;
            }
            get
            {
                return _MaintainanceDiscountTypeDb.Code;
            }
        }
        public string NameA
        {
            set
            {
                _MaintainanceDiscountTypeDb.NameA = value;
            }
            get
            {
                return _MaintainanceDiscountTypeDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _MaintainanceDiscountTypeDb.NameE = value;
            }
            get
            {
                return _MaintainanceDiscountTypeDb.NameE;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MaintainanceDiscountTypeDb.Add();
        }
        public void Edit()
        {
            _MaintainanceDiscountTypeDb.Edit();
        }
        public void Delete()
        {
            _MaintainanceDiscountTypeDb.Delete();
        }
        #endregion
    }
}
