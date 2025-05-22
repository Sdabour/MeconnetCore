using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class BankAccountTransactionCol : CollectionBase
    {
        #region Private Data

        #region Paging
        int _MaxCount = 500;
        int _ResultCount = 0;
        double _ResultValue = 0;
        int _ResultInCount = 0;
        double _ResultInValue = 0;
        int _ResultOutCount =0;
        double _ResultOutValue = 0;
        double _ResultCreditValue = 0;
        int _TheMinID;
        int _MaxID;
        int _MinID;
        bool _EnableNext;
        bool _EnablePrevious;
        #endregion

        BankBiz _BankBiz;
        AccountBankBiz _AccountBiz;
        bool _IsDateRange;
        DateTime _StartDate;
        string _BankIDs;
        string _AccountIDs;
        DateTime _EndDate;
        string _Desc;
        double _StartValue;
        double _EndValue;
        int _DirectionStatus;
        int _CachPaymentType;
        int _ReceiptedStatus;
        #endregion
        #region Constructors
        public BankAccountTransactionCol(bool blIsEmpty)
        { 
        }
        public BankAccountTransactionCol(BankBiz objBankBiz,AccountBankBiz objAccountBiz, bool blIsDateRange, DateTime dtStartDate,
            DateTime dtEndDate,string strDesc,double dblStartValue,double dblEndValue,
            int intDirectionStatus,int intCachPaymentType,bool blContainCredit,int intReceiptStatus,string strBankIDs,string strAccountIDs)
        {
            SetDataInitially(objBankBiz, objAccountBiz, blIsDateRange, dtStartDate, dtEndDate, 
                strDesc, dblStartValue, dblEndValue, intDirectionStatus, intCachPaymentType,intReceiptStatus,strBankIDs,strAccountIDs);


            BankAccountTransactionDb objDb = new BankAccountTransactionDb();
            GetSearchData(ref objDb);
            
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            _ResultInCount = objDb.ResultInCount;
             _ResultInValue = objDb.ResultInValue;
            _ResultOutCount = objDb.ResultOutCount;
            _ResultOutValue = objDb.ResultOutValue;
            _ResultCreditValue = objDb.CreditValue;
            BankAccountTransactionBiz objBiz;
            Hashtable hsCreditTransaction = new Hashtable();
            Hashtable hsTransaction = new Hashtable();
            //DataTable dtAccountCounting = 
            if (blContainCredit && blIsDateRange)
            {

                hsCreditTransaction = GetCreditTransactionHash();
                AddNonExitCrditAccount(hsCreditTransaction, dtTemp);
            }

            DataRow[] arrDr = dtTemp.Select("", "AccountID,TransactionDate");
            BankAccountTransactionBiz objTemp = new BankAccountTransactionBiz();
            foreach (DataRow objDr in arrDr)
            {

                objBiz = new BankAccountTransactionBiz(objDr);
                if (blContainCredit)
                {
                    if (hsTransaction[objBiz.AccountBiz.ID.ToString()] == null)
                    {
                        if (hsCreditTransaction[objBiz.AccountBiz.ID.ToString()] != null)
                        {
                            objTemp = (BankAccountTransactionBiz)hsCreditTransaction[objBiz.AccountBiz.ID.ToString()];

                            hsTransaction.Add(objBiz.AccountBiz.ID.ToString(), objTemp);
                            Add(objTemp);
                        }

                    }
                }
               Add(objBiz);

            }
            if (dtTemp.Rows.Count > 0)
            {
                arrDr = dtTemp.Select("", "");
                objDb = new BankAccountTransactionDb(arrDr[dtTemp.Rows.Count - 1]);
                _MaxID = objDb.ID;
                objDb = new BankAccountTransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }
 
        }
        #endregion
        #region Public Properties
        public BankAccountTransactionBiz this[int intIndex]
        {
            get
            {
                return (BankAccountTransactionBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public double ResultValue
        {
            get
            {
                return _ResultValue;
            }
        }
        public int ResultInCount
        {
            get
            {
                return _ResultInCount;
            }
        }
        public double ResultInValue
        {
            get
            {
                return _ResultInValue;
            }
        }
        public int ResultOutCount
        {
            get
            {
                return _ResultOutCount;
            }
        }
        public double ResultOutValue
        {
            get
            {
                return _ResultOutValue;
            }
        }
        public double ResultCreditValue
        {
            get
            {
                return _ResultCreditValue;
            }
        }
        public bool EnableNext
        {
            get
            {
                return _EnableNext;
            }
        }
        public bool EnablePrevious
        {
            get
            {
                return _EnablePrevious;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    Returned += objBiz.CurrentValue;
                }
                return Returned;
            }
        }
        public double TotalCreditValue
        {
            get
            {
                double Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (objBiz.Direction)
                        Returned += objBiz.CurrentValue;
                    else
                        Returned -= objBiz.CurrentValue;
                }
                return Returned;
            }
        }
        public double TotalInValue
        {
            get
            {
                double Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if(objBiz.Direction)
                    Returned += objBiz.CurrentValue;
                }
                return Returned;
            }
        }
        public double TotalOutValue
        {
            get
            {
                double Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (!objBiz.Direction)
                        Returned += objBiz.CurrentValue;
                }
                return Returned;
            }
        }
        public int TotalInCount
        {
            get
            {
                int Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (objBiz.Direction)
                        Returned ++;
                }
                return Returned;
            }
        }
        public int TotalOutCount
        {
            get
            {
                int Returned = 0;
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (!objBiz.Direction)
                        Returned++;
                }
                return Returned;
            }
        }
        public BankAccountTransactionCol WireTransfereTransactionCol
        {
            get
            {
                BankAccountTransactionCol Returned = new BankAccountTransactionCol(true);
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (objBiz.TransfereBiz.ID != 0)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        public BankAccountTransactionCol CheckTransactionCol
        {
            get
            {
                BankAccountTransactionCol Returned = new BankAccountTransactionCol(true);
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID != 0)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        public BankAccountTransactionCol CacheTransactionCol
        {
            get
            {
                BankAccountTransactionCol Returned = new BankAccountTransactionCol(true);
                foreach (BankAccountTransactionBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.ID == 0 && objBiz.TransfereBiz.ID == 0)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetDataInitially(BankBiz objBankBiz, AccountBankBiz objAccountBiz, bool blIsDateRange, DateTime dtStartDate,
            DateTime dtEndDate, string strDesc, double dblStartValue,
            double dblEndValue, int intDirectionStatus,
            int intCachPaymentType,int intReceiptedStatus,string strBankIDs,string strAccountIDs)
        {
            _BankBiz = objBankBiz;
            _AccountBiz = objAccountBiz;
            if (_AccountBiz == null)
                _AccountBiz = new AccountBankBiz();
            if (_BankBiz == null)
                _BankBiz = new BankBiz();
            _IsDateRange = blIsDateRange;
            _StartDate = dtStartDate;
            _EndDate = dtEndDate;
            _Desc = strDesc;
            _StartValue = dblStartValue;
            _EndValue = dblEndValue;
            _DirectionStatus = intDirectionStatus;
            _CachPaymentType = intCachPaymentType;
            _ReceiptedStatus = intReceiptedStatus;
            _BankIDs = strBankIDs;
            _AccountIDs = strAccountIDs;
 
        }
        void GetSearchData(ref BankAccountTransactionDb objDb)
        {
            if (_BankBiz == null)
                _BankBiz = new BankBiz();
            if (_AccountBiz == null)
                _AccountBiz = new AccountBankBiz();
            objDb.Account = _AccountBiz.ID;
            objDb.BankID = _BankBiz.ID;
            //objDb.BankIDs = _BankIDs;
            //objDb.AccountIDs = _AccountIDs;
            if (_BankIDs != null && _BankIDs != "")
            {
                objDb.Account = 0;
                objDb.BankID = 0;
            }
            objDb.CachePaymentType = _CachPaymentType;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            objDb.Desc = _Desc;
            objDb.StartValue = _StartValue;
            objDb.EndValue = _EndValue;
            objDb.DirectionStatus = _DirectionStatus;
            objDb.CachePaymentType = _CachPaymentType;
            //objDb.ReceiptedStatus = _ReceiptedStatus;
        }
        BankAccountTransactionBiz GetCreditTransactionBiz()
        {
            BankAccountTransactionBiz Returned = new BankAccountTransactionBiz();
            BankAccountTransactionDb objDb = new BankAccountTransactionDb();
            GetSearchData(ref objDb);
            objDb.HasMaxDate = true;
            objDb.EndDate = _StartDate.AddDays(-1);
            objDb.IsDateRange = false;

            if (_AccountBiz != null && _AccountBiz.ID != 0)
            {
                DataTable dtTemp = objDb.Counting;
                if (dtTemp.Rows.Count > 0)
                {
                    DataRow objDr = dtTemp.Rows[0];
                    double dblResultValue = 0;
                    if (objDr["ResultValue"].ToString() != "")
                        dblResultValue = double.Parse(objDr["CreditValue"].ToString());
                    Returned.CurrencyBiz = _AccountBiz.CurrencyBiz;
                    Returned.AccountBiz = _AccountBiz;
                    Returned.Date = _StartDate.AddDays(-1);
                    Returned.Direction = true;
                    Returned.Desc = "ÑÕíÏ Ýì " + Returned.Date.ToString("yyyy-MM-dd");
                    Returned.Value = dblResultValue;

                }
            }
            return Returned;


        }
        Hashtable GetCreditTransactionHash()
        {
            Hashtable Returned = new Hashtable();
            BankAccountTransactionBiz ObjTransactionBiz = new BankAccountTransactionBiz();
            BankAccountTransactionDb objDb = new BankAccountTransactionDb();
            GetSearchData(ref objDb);
            objDb.HasMaxDate = true;
            objDb.EndDate = _StartDate.AddDays(-1);
            objDb.IsDateRange = false;

           
                DataTable dtTemp = objDb.AccountCounting;
                foreach(DataRow objDr in dtTemp.Rows)
                {
                    ObjTransactionBiz = new BankAccountTransactionBiz();
                    double dblResultValue = 0;
                    if (objDr["CreditValue"].ToString() != "")
                        dblResultValue = double.Parse(objDr["CreditValue"].ToString());
                    ObjTransactionBiz.CurrencyBiz = _AccountBiz.CurrencyBiz;
                    ObjTransactionBiz.AccountBiz =  new AccountBankBiz(objDr);
                    ObjTransactionBiz.Date =objDr["MaxTransactionDate"].ToString()!= "" ? DateTime.Parse(objDr["MaxTransactionDate"].ToString()) :
                        _StartDate.AddDays(-1);
                    ObjTransactionBiz.Direction = true;
                    ObjTransactionBiz.Desc = "ÑÕíÏ Ýì " + ObjTransactionBiz.Date.ToString("yyyy-MM-dd");
                    ObjTransactionBiz.Value = dblResultValue;
                    Returned.Add(ObjTransactionBiz.AccountBiz.ID.ToString(), ObjTransactionBiz);

                }
            
            return Returned;


        }
        void AddNonExitCrditAccount(Hashtable hsCredit,DataTable dtResult)
        {
            DataRow[] arrDr;
            foreach (object objKey in hsCredit.Keys)
            {
                arrDr = dtResult.Select("TransactionAccount=" + objKey.ToString(), "");
                if (arrDr.Length == 0)
                {
                    Add((BankAccountTransactionBiz)hsCredit[objKey]);
                }
            }

        }
        #endregion
        #region Public Methods
        public void Add(BankAccountTransactionBiz objBiz)
        {
            if (Count > 0)
            {
                double dblCurrentValue = (this[Count - 1].Direction ? 1 : -1) * this[Count - 1].CurrentValue;
                double dblCredit = Count ==1 ? dblCurrentValue : this[Count-1].CurrentCredit;
                objBiz.Credit += dblCredit; // this[Count - 1].Credit;
            }
            List.Add(objBiz);
        }
        public void MoveNext()
        {

            Clear();
            BankAccountTransactionDb objDb = new BankAccountTransactionDb();
            GetSearchData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new BankAccountTransactionBiz(objDr));

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "");
                objDb = new  BankAccountTransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new BankAccountTransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (Count == _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public void MovePrevious()
        {


            Clear();
            BankAccountTransactionDb objDb = new BankAccountTransactionDb();
            GetSearchData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new BankAccountTransactionBiz(objDr));
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "");
                objDb = new BankAccountTransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new BankAccountTransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public void Save()
        {
            foreach (BankAccountTransactionBiz objBiz in this)
            {
                if (objBiz.ID == 0)
                    objBiz.Add();
                else
                    objBiz.Edit();
            }
        }
        public void Delete()
        {
            foreach (BankAccountTransactionBiz objBiz in this)
            {
                if (objBiz.ID != 0)
                    objBiz.Delete();
               
            }
        }

        
        #endregion

    }
}
