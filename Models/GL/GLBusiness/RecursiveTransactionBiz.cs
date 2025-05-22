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
    public class RecursiveTransactionBiz
    {
        #region Privatedata
        protected RecursiveTransactionDb _RecursiveTransactionDb;
        protected JournalTypeBiz _TypeBiz;
        protected RecursiveTransactionElementCol _ElementCol;
        CurrencyBiz _CurrencyBiz;
        CurrencyBiz _BaseCurrencyBiz;
        AccountBiz _AccountToBiz;
        AccountBiz _AccountFromBiz;
        CompanyBiz _CompanyBiz;
        SpecificBiz _SpecificBiz;
        #endregion

        #region Constractors
        public RecursiveTransactionBiz()
        {
            _RecursiveTransactionDb = new RecursiveTransactionDb();
        }
        public RecursiveTransactionBiz(DataRow objDR)
        {
            _RecursiveTransactionDb = new RecursiveTransactionDb(objDR);
            _TypeBiz = new JournalTypeBiz(objDR);
            _CurrencyBiz = new CurrencyBiz(objDR);
            if (_RecursiveTransactionDb.AccountFromCode != null &&
                _RecursiveTransactionDb.AccountFromCode != "")
            {
                _AccountFromBiz = new AccountBiz();
                _AccountFromBiz.ID = -1;
                _AccountFromBiz.NameA = _RecursiveTransactionDb.AccountFromNameA;
                _AccountFromBiz.Code = _RecursiveTransactionDb.AccountFromCode;

            }
            if (_RecursiveTransactionDb.AccountToCode != null &&
                _RecursiveTransactionDb.AccountToCode != "")
            {
                _AccountToBiz = new AccountBiz();
                _AccountToBiz.ID = -1;
                _AccountToBiz.NameA = _RecursiveTransactionDb.AccountToNameA;
                _AccountToBiz.Code = _RecursiveTransactionDb.AccountToCode;

            }
            if (_RecursiveTransactionDb.BaseCurrency != 0)
            {
                _BaseCurrencyBiz = new CurrencyBiz();
                _BaseCurrencyBiz.ID = _RecursiveTransactionDb.BaseCurrency;
                _BaseCurrencyBiz.Code = _RecursiveTransactionDb.BaseCurrencyCode;
                _BaseCurrencyBiz.NameA = _RecursiveTransactionDb.BaseCurrencyName;
            }
            if (_RecursiveTransactionDb.Company != 0)
                _CompanyBiz = new CompanyBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _RecursiveTransactionDb.ID = value;
            }
            get
            {
                return _RecursiveTransactionDb.ID;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _RecursiveTransactionDb.StartDate = value;
            }
            get
            {
                return _RecursiveTransactionDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _RecursiveTransactionDb.EndDate = value;
            }
            get
            {
                return _RecursiveTransactionDb.EndDate;
            }
        }
        public string Code
        {
            set
            {
                _RecursiveTransactionDb.Code = value;
            }
            get
            {
                return _RecursiveTransactionDb.Code;
            }
        }
        public RecursiveTransactionElementCol ElementCol
        {
            set
            {
                _ElementCol = value;
            }
            get
            {
                if (_ElementCol == null)
                {
                    _ElementCol = new RecursiveTransactionElementCol(true);
                    if (ID != 0)
                    {
                        RecursiveTransactionElementDb objDb = new RecursiveTransactionElementDb();
                        objDb.TRansaction = ID;
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "ElementOrder");
                        foreach (DataRow objDr in arrDr)
                        {
                            _ElementCol.Add(new RecursiveTransactionElementBiz(objDr));
                        }
                    }


                }
                return _ElementCol;
            }
        }
        public string CreditStr
        {
            get
            {
                string Returned = "";

                if (AccountFromBiz.ID != 0)
                {
                    Returned = Value.ToString() + " „‰ Õ " + AccountFromBiz.Name;

                }
              
                return Returned;
            }
        }
        public string DebitStr
        {
            get
            {
                string Returned = "";

                if (AccountToBiz.ID != 0)
                {
                    Returned = Value.ToString() + " «·Ï Õ " + AccountToBiz.Name;

                }
               
                return Returned;
            }
        }

        public JournalTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }
        }
        public CompanyBiz CompanyBiz
        {
            set
            {
                _CompanyBiz = value;
            }
            get
            {
                if (_CompanyBiz == null)
                    _CompanyBiz = new CompanyBiz();
                return _CompanyBiz;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            set
            {
                _CurrencyBiz = value;
            }
            get
            {
                if (_CurrencyBiz == null)
                    _CurrencyBiz = new CurrencyBiz();
                return _CurrencyBiz;
            }
        }
        public CurrencyBiz BaseCurrencyBiz
        {
            set
            {
                _BaseCurrencyBiz = value;
            }
            get
            {
                if (_BaseCurrencyBiz == null)
                    _BaseCurrencyBiz = new CurrencyBiz();
                return _BaseCurrencyBiz;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _RecursiveTransactionDb.CurrencyValue = value;
            }
            get
            {
                return _RecursiveTransactionDb.CurrencyValue;
            }
        }
        public string Desc
        {
            set
            {
                _RecursiveTransactionDb.Desc = value;
            }
            get
            {
                return _RecursiveTransactionDb.Desc;
            }
        }
       
        public double Value
        {
            set
            {
                _RecursiveTransactionDb.Value = value;
            }
            get
            {
                return _RecursiveTransactionDb.Value;
            }
        }
        public SpecificBiz SpecificBiz
        {
            set
            {
                _SpecificBiz = value;
            }
            get
            {
                if (_SpecificBiz == null)
                    _SpecificBiz = new SpecificBiz();
                return _SpecificBiz;
            }
        }
        public AccountBiz AccountToBiz
        {
            set
            {
                _AccountToBiz = value;
            }
            get
            {
                if (_AccountToBiz == null)
                    _AccountToBiz = new AccountBiz();
                return _AccountToBiz;
            }
        }
        public AccountBiz AccountFromBiz
        {
            set
            {
                _AccountFromBiz = value;
            }
            get
            {
                if (_AccountFromBiz == null)
                    _AccountFromBiz = new AccountBiz();
                return _AccountFromBiz;
            }
        }

        
        #endregion

        #region PrivateMethods

        #endregion

        #region PublicMethods
        public virtual void Add()
        {
            if (_TypeBiz != null)
                _RecursiveTransactionDb.Type = _TypeBiz.ID;
            else
                _RecursiveTransactionDb.Type = 0;
            _RecursiveTransactionDb.Currency = CurrencyBiz.ID;
            _RecursiveTransactionDb.BaseCurrency = BaseCurrencyBiz.ID;
            _RecursiveTransactionDb.Company = CompanyBiz.ID;
            _RecursiveTransactionDb.ElementTable = ElementCol.GetTable();
            _RecursiveTransactionDb.Add();


        }
        public virtual void Edit()
        {
            if (_TypeBiz != null)
                _RecursiveTransactionDb.Type = _TypeBiz.ID;
            else
                _RecursiveTransactionDb.Type = 0;
            _RecursiveTransactionDb.Currency = CurrencyBiz.ID;
            _RecursiveTransactionDb.BaseCurrency = BaseCurrencyBiz.ID;
            _RecursiveTransactionDb.Company = CompanyBiz.ID;
            _RecursiveTransactionDb.ElementTable = ElementCol.GetTable();
            _RecursiveTransactionDb.Edit();

        }
        public virtual void Delete()
        {
            _RecursiveTransactionDb.Delete();
        }
        #endregion
    }
}
