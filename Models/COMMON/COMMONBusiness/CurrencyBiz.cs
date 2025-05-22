using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class CurrencyBiz : BaseSingleBiz
    {
        #region Private Data

        //static CurrencyBiz _DefaultCurrencyBiz;
        static CurrencyCol _CurrencyCol;
        
        #endregion
        #region Constructors
        public CurrencyBiz()
        {
            _BaseDb = new CurrencyDb();
        }
        public CurrencyBiz(string strCode)
        { 
            _BaseDb = new CurrencyDb(strCode);
        }
        public CurrencyBiz(int intCurrencyID)
        {
            DataRow[] arrDr = CurrencyDb.CacheCurrencyTable.Select("CurrencyID=" + intCurrencyID);
            if (arrDr.Length > 0)
                _BaseDb = new CurrencyDb(arrDr[0]);
            else
                _BaseDb = new CurrencyDb();
        }
        public CurrencyBiz(DataRow objDR)
        {

            _BaseDb = new CurrencyDb(objDR);
        }

        public CurrencyBiz(CurrencyDb objCurrencyDb)
        {
            _BaseDb = objCurrencyDb;
        }
        #endregion
        #region Public Properties
        public double Value
        {
            set
            {
                ((CurrencyDb)_BaseDb).Value = value;
            }
            get
            {
                return ((CurrencyDb)_BaseDb).Value;
            }
        }

        public string Code
        {
            set
            {
                ((CurrencyDb)_BaseDb).Code = value;
            }
            get
            {
                return ((CurrencyDb)_BaseDb).Code;
            }
        }
        public string ShortName
        {
            set
            {
                 ((CurrencyDb)_BaseDb).ShortName = value;
            }
            get
            {
                return  ((CurrencyDb)_BaseDb).ShortName;
            }

        }
        public bool IsStanderd
        {
            set
            {
                ((CurrencyDb)_BaseDb).IsStandarad = value;
            }
            get
            {
                return ((CurrencyDb)_BaseDb).IsStandarad;
            }
        }
        public static CurrencyCol CurrencyCol
        {
            get
            {
                if (_CurrencyCol == null)
                {
                    _CurrencyCol = new CurrencyCol();
                }
                return _CurrencyCol;
 
            }
        }
        #endregion
        #region Public Methods
        public  void Add()
        {
            _BaseDb.Add();
        }

        public void Edit()
        {
          _BaseDb.Edit();
        }
        
        public  void Delete()
        {
            _BaseDb.Delete();
        }
       
        public virtual CurrencyBiz Copy()
        {
            CurrencyBiz Returned = new CurrencyBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.Value = this.Value;
            Returned.Code = this.Code;
            Returned.ShortName = ShortName;
            Returned.IsStanderd = this.IsStanderd;
            return Returned;
        }
        #endregion

    }
}
