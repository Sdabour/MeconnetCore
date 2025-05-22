using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class TransactionElementCol : BaseCol
    {
        #region Private Data
        protected int _MaxCount = 1000;
        protected int _ResultCount = 0;
        protected double _ResultValue;
        protected double _ResultDiscountValue;
        protected int _TheMinID;
        protected int _MaxID;
        protected int _MinID;
       protected int _CurrentIndex;
       protected bool _EnableNext;
       protected bool _EnablePrevious;
        #region Private Data For Search
       protected AccountBiz _AccountBiz;
       protected CostCenterBiz _CostCenterBiz;
        protected JournalTypeBiz _TypeBiz;
        protected CurrencyBiz _CurrencyBiz;
        protected SpecificBiz _SpecificBiz;
        protected CompanyBiz _CompanyBiz;
        protected FinancialPeriodBiz _PeriodBiz;
        protected FinancialYearBiz _YearBiz;
        protected string _CodeLike;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsDateRange;
        protected double _StartValue;
        protected double _EndValue;
        protected int _Status;
        protected int _HasReservationSatus;
        protected int _IsReversingStatus;
        protected string _UnitCode;
        protected string _CellIDs;
        protected int _CellFamilyID;
        protected int _SystemSource;
        protected int _SystemType;
        protected int _ContractorID;
        #endregion
        #endregion
        public TransactionElementCol()
        {
            
        }
        public TransactionElementCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                TransactionElementDb objDb = new TransactionElementDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new TransactionElementBiz(objDr));
                }
            }
        }
         public TransactionElementCol(AccountBiz objAccountBiz,CostCenterBiz objCostCenterBiz,JournalTypeBiz objTypeBiz,CurrencyBiz objCurrencyBiz,string strCodeLike,DateTime dtStartDate,
            DateTime dtEndDate,bool blIsDateRange,double dblStartValue,
            double dblEndValue,int intStatus,int intHasReservationStatus,int intIsReversingStatus,
            string strUnitCode,string strCellIDs,int intCellFamilyID,CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz,FinancialPeriodBiz objPeriodBiz,SpecificBiz objSpecificBiz,
             int intSystemtSource,int intSystemType,int intContractorID)
        {
           
            TransactionElementDb objDb = new TransactionElementDb();
            SetDataInitially(objAccountBiz,objCostCenterBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus, intHasReservationStatus, 
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID,objCompanyBiz,
                objYearBiz,objPeriodBiz,objSpecificBiz,intSystemtSource,intSystemType,intContractorID);
            GetData(ref objDb);
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            TransactionElementBiz objTransactionElementBiz;
            string strUserIDs="";
            Hashtable hsUser = new Hashtable();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objTransactionElementBiz = new TransactionElementBiz(objDr);
                if ((objTransactionElementBiz.TransactionBiz.UsrIns != 0 || objTransactionElementBiz.TransactionBiz.UsrUpd!= 0) &&
                    (hsUser[objTransactionElementBiz.TransactionBiz.UsrIns.ToString()] == null||
                    hsUser[objTransactionElementBiz.TransactionBiz.UsrUpd.ToString()] == null))
                {
                    if (hsUser[objTransactionElementBiz.TransactionBiz.UsrIns.ToString()] == null)
                    {
                        hsUser.Add(objTransactionElementBiz.TransactionBiz.UsrIns.ToString(), objTransactionElementBiz.TransactionBiz.UsrIns.ToString());
                        if (strUserIDs != "")
                            strUserIDs += ",";
                        strUserIDs += objTransactionElementBiz.TransactionBiz.UsrIns;
                    }
                    if (hsUser[objTransactionElementBiz.TransactionBiz.UsrUpd.ToString()] == null)
                    {
                        hsUser.Add(objTransactionElementBiz.TransactionBiz.UsrUpd.ToString(), objTransactionElementBiz.TransactionBiz.UsrUpd.ToString());
                        if (strUserIDs != "")
                            strUserIDs += ",";
                        strUserIDs += objTransactionElementBiz.TransactionBiz.UsrUpd;
                    }
                
                }
                Add( objTransactionElementBiz );
            }
            DataRow []arrDr;
            if (strUserIDs != "")
            {
                UserDb objUserDb = new UserDb();
                objUserDb.IDs = strUserIDs;
                DataTable dtUser = objUserDb.Search();
                foreach (TransactionElementBiz objBiz in this)
                {
                    if (objBiz.TransactionBiz.UsrIns != 0)
                    {
                        arrDr = dtUser.Select("UserID="+ objBiz.TransactionBiz.UsrIns, "");
                        if (arrDr.Length != 0)
                            objBiz.TransactionBiz.UsrInsBiz = new UserBiz(arrDr[0]);
                    }
                    if (objBiz.TransactionBiz.UsrUpd != 0)
                    {
                        arrDr = dtUser.Select("UserID=" + objBiz.TransactionBiz.UsrUpd, "");
                        if (arrDr.Length != 0)
                            objBiz.TransactionBiz.UsrUpdBiz = new UserBiz(arrDr[0]);
                    }
                }
            }
            if (Count > 0)
            {
               arrDr = dtTemp.Select("", "ElementID");
                objDb = new TransactionElementDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionElementDb(arrDr[0]);
                _MinID = objDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        public TransactionElementBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (TransactionElementBiz)List[intIndex];
            }
        }
        #region Private Data
        protected virtual void SetDataInitially(AccountBiz objAccountBiz,CostCenterBiz objCostCenterBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
            DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
            double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
            string strUnitCode, string strCellIDs, int intCellFamilyID, CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz, FinancialPeriodBiz objPeriodBiz,
            SpecificBiz objSpecificBiz,int intSystemSource,int intSystemType,int intContractorID)
        {
            if (objAccountBiz == null)
                objAccountBiz = new AccountBiz();
            if (objCurrencyBiz == null)
                objCurrencyBiz = new CurrencyBiz();
            if (objTypeBiz == null)
                objTypeBiz = new JournalTypeBiz();
            if (_CostCenterBiz == null)
                _CostCenterBiz = new CostCenterBiz();
            _AccountBiz = objAccountBiz;
            _CostCenterBiz = objCostCenterBiz;
            _TypeBiz = objTypeBiz;
            _CurrencyBiz = objCurrencyBiz;
            _CodeLike = strCodeLike;
            _StartDate = dtStartDate;
            _EndDate = dtEndDate;
            _IsDateRange = blIsDateRange;
            _StartValue = dblStartValue;
            _EndValue = dblEndValue;
            _Status = intStatus;
            _HasReservationSatus = intHasReservationStatus;
            _IsReversingStatus = intIsReversingStatus;
            _UnitCode = strUnitCode;
            _CellIDs = strCellIDs;
            _CellFamilyID = intCellFamilyID;
            _SpecificBiz = objSpecificBiz;
            _CompanyBiz = objCompanyBiz;
            _YearBiz = objYearBiz;
            _PeriodBiz = objPeriodBiz;
            _SystemSource = intSystemSource;
            _SystemType = intSystemType;
            _ContractorID = intContractorID;


        }
       protected virtual void GetData(ref TransactionElementDb objDb)
        {
            if (_SpecificBiz == null)
                _SpecificBiz = new SpecificBiz();
            if (_CompanyBiz == null)
                _CompanyBiz = new CompanyBiz();
            if (_PeriodBiz == null)
                _PeriodBiz = new FinancialPeriodBiz();
            if (_YearBiz == null)
                _YearBiz = new FinancialYearBiz();
            if (_TypeBiz == null)
                _TypeBiz = new JournalTypeBiz();
            if (_CurrencyBiz == null)
                _CurrencyBiz = new CurrencyBiz();
            if (_AccountBiz == null)
                _AccountBiz = new AccountBiz();
            objDb.Type = _TypeBiz.ID;
            objDb.Currency = _CurrencyBiz.ID;
           // objDb.Code = _CodeLike;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            //objDb.StartValue = _StartValue;
            //objDb.EndValue = _EndValue;
            //objDb.Status = _Status;
            //objDb.HasReservationStatus = _HasReservationSatus;
            //objDb.IsReversingStatus = _IsReversingStatus;
            //objDb.UnitCode = _UnitCode;
            //objDb.CellFamilyID = _CellFamilyID;
            //objDb.CellIDs = _CellIDs;
            objDb.AccountIDs = _AccountBiz.IDsStr;
            objDb.CostCenterIDs = _CostCenterBiz.IDsStr;
            objDb.SpecificID = _SpecificBiz.ID;
            objDb.CompanyID = _CompanyBiz.ID;
            objDb.YearID = _YearBiz.ID;
            objDb.PeriodID = _PeriodBiz.ID;
            objDb.SystemSource = _SystemSource;
            objDb.SystemType = _SystemType;
            objDb.ContractorID = _ContractorID;

        }
        #endregion 
        public double TotalCreditValue
        {
            get
            {
                double TotalCrditeValue = 0;
                foreach (TransactionElementBiz objBiz in this)
                {
                    //if(objBiz.Direction== true)
                      TotalCrditeValue = TotalCrditeValue + objBiz.CrditeTotalValue;
                }
                return TotalCrditeValue;

            }
           
        }
        public double TotalDebitValue
        {
            get
            {
                double TotalDebitValue = 0;
                foreach (TransactionElementBiz objBiz in this)
                {
                    //if(!objBiz.Direction)
                     TotalDebitValue = TotalDebitValue + objBiz.DebitTotalValue;
                }
                return TotalDebitValue;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (TransactionElementBiz objBiz in this)
                {

                    Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public TransactionCol TransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                Hashtable hsTemp = new Hashtable();
                TransactionBiz objTransactionBiz;
                foreach (TransactionElementBiz objBiz in this)
                {
                    if (hsTemp[objBiz.TransactionBiz.ID.ToString()] != null)
                    {
                        objTransactionBiz = (TransactionBiz)hsTemp[objBiz.TransactionBiz.ID.ToString()];

                    }
                    else
                    {
                        objTransactionBiz = objBiz.TransactionBiz;
                        objTransactionBiz.ElementCol = new TransactionElementCol(true);
                        Returned.Add(objTransactionBiz);
                        hsTemp.Add(objTransactionBiz.ID.ToString(), objTransactionBiz);
                    }
                    objTransactionBiz.ElementCol.Add(objBiz);

                }
                return Returned;
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
        public AccountCol AccountCol
        {
            get 
            {
                AccountCol Returned = new AccountCol(true);
                //Hashtable hsTemp = 
                foreach (TransactionElementBiz objBiz in this)
                {
                    Returned.Add(objBiz.AccountBiz);
                }
                return Returned;
            }
        }
        public TransactionElementCol CreditTransactionElementCol
        {
            get
            {
                TransactionElementCol Returned = new TransactionElementCol(true);
                foreach (TransactionElementBiz objBiz in this)
                {
                    if (!objBiz.Direction)
                        Returned.Add(objBiz);

                }
                return Returned;
            }
        }
        public TransactionElementCol DebitTransactionElementCol
        {
            get
            {
                TransactionElementCol Returned = new TransactionElementCol(true);
                foreach (TransactionElementBiz objBiz in this)
                {
                    if (objBiz.Direction)
                        Returned.Add(objBiz);

                }
                return Returned;
            }
        }
        public void Add(TransactionElementBiz objBiz)
        {
       
           
                List.Add(objBiz);
          

        }
        public void Add(TransactionElementCol objCol)
        {

            foreach(TransactionElementBiz objBiz in objCol)
               List.Add(objBiz);


        }
        public int GetIndex(AccountBiz objAccountBiz)
        {
            int intIndex = 0;
            foreach (TransactionElementBiz objBiz in this)
            {
                if (objBiz.AccountBiz.ID == objAccountBiz.ID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public void MoveNext()
        {

            Clear();
            TransactionElementDb objDb = new TransactionElementDb();
            GetData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();



            TransactionElementBiz ObjTransactionElementBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionElementBiz = new TransactionElementBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjTransactionElementBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionElementID");
                objDb = new TransactionElementDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionElementDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (Count == _MaxCount)
            {
                _EnableNext = true;
            }
            else if (Count < _MaxCount)
                _EnableNext = false;


        }
        public void MovePrevious()
        {


            Clear();
            TransactionElementDb objDb = new TransactionElementDb();
            GetData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();



            TransactionElementBiz ObjTransactionElementBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionElementBiz = new TransactionElementBiz(objDr);

                this.Add(ObjTransactionElementBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionElementID");
                objDb = new TransactionElementDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionElementDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public AccountCol GetAccountCol(bool blIncludeCredit)
        {
            AccountCol Returned = new AccountCol(true);
            Hashtable hsTemp = new Hashtable();
            AccountBiz objAccountBiz = new AccountBiz();
            foreach (TransactionElementBiz objBiz in this)
            {
                if (hsTemp[objBiz.AccountBiz.ID.ToString()] != null)
                {
                    objAccountBiz = (AccountBiz)hsTemp[objBiz.AccountBiz.ID.ToString()];
                    objAccountBiz.ElementCol.Add(objBiz);

                }
                else 
                {
                    objAccountBiz = objBiz.AccountBiz;
                    objAccountBiz.ElementCol.Add(objBiz);
                    hsTemp.Add(objAccountBiz.ID.ToString(), objAccountBiz);
                    Returned.Add(objAccountBiz);
                   
                }
            }
            if (blIncludeCredit && _IsDateRange)
            {
                DateTime dtStart = _StartDate;
                DateTime dtEnd = _EndDate;
                bool blIsDateRange = _IsDateRange;
                TransactionElementDb objDb = new TransactionElementDb();
                GetData(ref objDb);
                objDb.IsDateLimited = true;
                objDb.IsDateRange = false;
                objDb.EndDate = dtStart;
                objDb.IsAccountGrouping = true;
               
                DataTable dtTemp = objDb.SumSearch();
                DataRow[] arrDr;
                foreach (AccountBiz objBiz in Returned)
                {
                    arrDr = dtTemp.Select("AccountID=" +objBiz.ID );
                    if (arrDr.Length > 0)
                    {
                        objDb = new TransactionElementDb(arrDr[0]);
                        objBiz.DebitBalance += objDb.TotalDebitValue;
                        objBiz.CreditBalance += objDb.TotalCreditValue;

                    }
                }
                _IsDateRange = blIsDateRange;
                _StartDate = dtStart;
                _EndDate = dtEnd;
            }
            return Returned;
        }
        public CostCenterCol GetCostCenterCol(bool blIncludeCredit)
        {
            CostCenterCol Returned = new CostCenterCol(true);
            Hashtable hsTemp = new Hashtable();
            CostCenterBiz objCostCenterBiz = new CostCenterBiz();
            foreach (TransactionElementBiz objBiz in this)
            {
                if (hsTemp[objBiz.CostCenterBiz.ID.ToString()] != null)
                {
                    objCostCenterBiz = (CostCenterBiz)hsTemp[objBiz.CostCenterBiz.ID.ToString()];
                   
                    objCostCenterBiz.ElementCol.Add(objBiz);

                }
                else
                {
                    objCostCenterBiz = objBiz.CostCenterBiz;
                    objCostCenterBiz.ElementCol.Add(objBiz);
                    hsTemp.Add(objCostCenterBiz.ID.ToString(), objCostCenterBiz);
                    Returned.Add(objCostCenterBiz);

                }
            }
            if (blIncludeCredit && _IsDateRange)
            {
                DateTime dtStart = _StartDate;
                DateTime dtEnd = _EndDate;
                bool blIsDateRange = _IsDateRange;
                TransactionElementDb objDb = new TransactionElementDb();
                GetData(ref objDb);
                objDb.IsDateLimited = true;
                objDb.IsDateRange = false;
                objDb.EndDate = dtStart;
                objDb.IsCostCenterGrouping = true;

                DataTable dtTemp = objDb.SumSearch();
                DataRow[] arrDr;
                foreach (CostCenterBiz objBiz in Returned)
                {
                    arrDr = dtTemp.Select("CostCenterID=" + objBiz.ID);
                    if (arrDr.Length > 0)
                    {
                        objDb = new TransactionElementDb(arrDr[0]);
                        objBiz.DebitBalance += objDb.TotalDebitValue;
                        objBiz.CreditBalance += objDb.TotalCreditValue;

                    }
                }
                _IsDateRange = blIsDateRange;
                _StartDate = dtStart;
                _EndDate = dtEnd;
            }
            return Returned;
        }
        public AccountCostCenterCol GetAccountCostCenterCol(bool blIncludeCredit)
        {
            AccountCostCenterCol Returned = new AccountCostCenterCol(true);
            Hashtable hsTemp = new Hashtable();
            AccountCostCenterBiz objAccountCostCenterBiz = new AccountCostCenterBiz();
            foreach (TransactionElementBiz objBiz in this)
            {
                if (hsTemp[objBiz.AccountBiz.ID.ToString()+ "-" +objBiz.CostCenterBiz.ID.ToString()] != null)
                {
                    objAccountCostCenterBiz = (AccountCostCenterBiz)hsTemp[objBiz.AccountBiz.ID.ToString() + "-" + objBiz.CostCenterBiz.ID.ToString()];
                    objAccountCostCenterBiz.ElementCol.Add(objBiz);

                }
                else
                {
                    objAccountCostCenterBiz = new AccountCostCenterBiz();
                    objAccountCostCenterBiz.AccountBiz = objBiz.AccountBiz;
                    objAccountCostCenterBiz.CostCenterBiz = objBiz.CostCenterBiz;
                    objAccountCostCenterBiz.CreditBalance = objBiz.CreditBalance;
                    objAccountCostCenterBiz.DebitBalance = objBiz.DebitBalance;
                    objAccountCostCenterBiz.ElementCol.Add(objBiz);
                    hsTemp.Add(objAccountCostCenterBiz.AccountBiz.ID.ToString()+ "-" + objAccountCostCenterBiz.CostCenterBiz.ID.ToString(), objAccountCostCenterBiz);
                    Returned.Add(objAccountCostCenterBiz);

                }
            }
            if (blIncludeCredit && _IsDateRange)
            {
                DateTime dtStart = _StartDate;
                DateTime dtEnd = _EndDate;
                bool blIsDateRange = _IsDateRange;
                TransactionElementDb objDb = new TransactionElementDb();
                GetData(ref objDb);
                objDb.IsDateLimited = true;
                objDb.IsDateRange = false;
                objDb.EndDate = dtStart;
                objDb.IsAccountGrouping = true;
                objDb.IsCostCenterGrouping = true;
                DataTable dtTemp = objDb.SumSearch();
                DataRow[] arrDr;
                foreach (AccountCostCenterBiz objBiz in Returned)
                {
                    arrDr = dtTemp.Select("AccountID=" + objBiz.AccountBiz.ID + " and CostCenterID=" + objBiz.CostCenterBiz.ID);
                    if (arrDr.Length > 0)
                    {
                        objDb = new TransactionElementDb(arrDr[0]);
                        objBiz.DebitBalance += objDb.TotalDebitValue;
                        objBiz.CreditBalance += objDb.TotalCreditValue;

                    }
                }
                _IsDateRange = blIsDateRange;
                _StartDate = dtStart;
                _EndDate = dtEnd;
            }
            return Returned;
        }
       public DataTable GetTable()
        {
           //System.Type.GetType("System.Boolean"))
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ElementID"), 
                new DataColumn("ElementTransaction"), new DataColumn("ElementAccount"),
                new DataColumn("ElementDirection",Type.GetType("System.Boolean")),
             new DataColumn("ElementValue"),new DataColumn("CostCenterID"),new DataColumn("ElementOrder"),new DataColumn("ElementCostCenter"),
                new DataColumn("ElementDesc"),
                new DataColumn("GeneratedID",Type.GetType("System.Int64")),new DataColumn("ElementCell"),
                new DataColumn("ElementSyetemType"),new DataColumn("ElementReservation"),new DataColumn("ElementSystemSourceID")});
            DataRow objDr;
            int intOrder = 0;
            foreach (TransactionElementBiz objBiz in this)
            {
                intOrder++;
                objBiz.Order = intOrder;
                objDr = dtReturned.NewRow();
                objBiz.GetDataRow(ref objDr);
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        public TransactionElementCol Copy()
        {
            TransactionElementCol Returned = new TransactionElementCol(true);
            foreach (TransactionElementBiz objBiz in this)
                Returned.Add(objBiz.Copy());
            return Returned;
        }
    }
}
