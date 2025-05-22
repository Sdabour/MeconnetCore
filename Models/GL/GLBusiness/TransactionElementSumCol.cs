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
    public class TransactionElementSumCol : BaseCol
    {
        #region Private Data
        int _MaxCount = 1000;
        int _ResultCount = 0;
        double _ResultValue;
        double _ResultDiscountValue;
        int _TheMinID;
        int _MaxID;
        int _MinID;
        int _CurrentIndex;
        bool _EnableNext;
        bool _EnablePrevious;
        #region Private Data For Search
        AccountBiz _AccountBiz;
        JournalTypeBiz _TypeBiz;
        CurrencyBiz _CurrencyBiz;
        SpecificBiz _SpecificBiz;
        CompanyBiz _CompanyBiz;
        FinancialPeriodBiz _PeriodBiz;
        FinancialYearBiz _YearBiz;
        string _CodeLike;
        DateTime _StartDate;
        DateTime _EndDate;
        bool _IsDateRange;
        double _StartValue;
        double _EndValue;
        int _Status;
        int _HasReservationSatus;
        int _IsReversingStatus;
        string _UnitCode;
        string _CellIDs;
        int _CellFamilyID;
        bool _IsAccountGrouping;
        bool _IsCostCenterGrouping;
        #endregion
        #endregion
        public TransactionElementSumCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                TransactionElementDb objDb = new TransactionElementDb();
                DataTable dtTemp = objDb.SumSearch();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new TransactionElementSumBiz(objDr));
                }
            }
        }
        public TransactionElementSumCol(AccountBiz objAccountBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
           DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
           double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
           string strUnitCode, string strCellIDs, int intCellFamilyID, CompanyBiz objCompanyBiz,
           FinancialYearBiz objYearBiz, FinancialPeriodBiz objPeriodBiz, SpecificBiz objSpecificBiz,
            bool blIsAccountGrouping,bool blIsCostCenterGrouping)
        {

            TransactionElementDb objDb = new TransactionElementDb();
            SetDataInitially(objAccountBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus, intHasReservationStatus,
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID, objCompanyBiz, objYearBiz, objPeriodBiz,
                objSpecificBiz,blIsAccountGrouping,blIsCostCenterGrouping);
            GetData(ref objDb);
            //objDb.IsAccountGrouping = blIsAccountGrouping;
            
            DataTable dtTemp = objDb.SumSearch();
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            TransactionElementSumBiz objTransactionElementSumBiz;
            string strUserIDs = "";
            Hashtable hsUser = new Hashtable();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objTransactionElementSumBiz = new TransactionElementSumBiz(objDr);
                 

                
                Add(objTransactionElementSumBiz);
            }
            DataRow[] arrDr;
            
            if (Count > 0)
            {
                arrDr = dtTemp.Select("");
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
        public TransactionElementSumBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (TransactionElementSumBiz)List[intIndex];
            }
        }
        #region Private Data
        void SetDataInitially(AccountBiz objAccountBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
            DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
            double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
            string strUnitCode, string strCellIDs, int intCellFamilyID, CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz, FinancialPeriodBiz objPeriodBiz, SpecificBiz objSpecificBiz,bool blIsAccountGrouping,bool blIsCostCenterGrouping)
        {
            if (objAccountBiz == null)
                objAccountBiz = new AccountBiz();
            if (objCurrencyBiz == null)
                objCurrencyBiz = new CurrencyBiz();
            if (objTypeBiz == null)
                objTypeBiz = new JournalTypeBiz();
            _AccountBiz = objAccountBiz;
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
            


        }
        void GetData(ref TransactionElementDb objDb)
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
            objDb.Account = _AccountBiz.ID;
            objDb.SpecificID = _SpecificBiz.ID;
            objDb.CompanyID = _CompanyBiz.ID;
            objDb.YearID = _YearBiz.ID;
            objDb.PeriodID = _PeriodBiz.ID;
            objDb.IsAccountGrouping = _IsAccountGrouping;
            objDb.IsCostCenterGrouping = _IsCostCenterGrouping;

        }
        #endregion
        public double TotalCreditValue
        {
            get
            {
                double TotalCrditeValue = 0;
                foreach (TransactionElementSumBiz objBiz in this)
                {
                     
                        TotalCrditeValue+=objBiz.TotalCreditValue;
                }
                return TotalCrditeValue;

            }

        }
        public double TotalDebitValue
        {
            get
            {
                double TotalDebitValue = 0;
                foreach (TransactionElementSumBiz objBiz in this)
                {
                   
                        TotalDebitValue+= objBiz.TotalDebitValue;
                }
                return TotalDebitValue;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (TransactionElementSumBiz objBiz in this)
                {

                    Returned += objBiz.TotalDebitValue -objBiz.TotalCreditValue;
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
        public bool IsAccountGrouping
        {
            get
            {
                return _IsAccountGrouping;
            }
        }
        public bool IsCostCenterGrouping
        {
            get
            {
                return _IsCostCenterGrouping;
            }
        }
        public AccountCol AccountCol
        {
            get
            {
                AccountCol Returned = new AccountCol(true);
                //Hashtable hsTemp = 
                foreach (TransactionElementSumBiz objBiz in this)
                { }
                return Returned;
            }
        }

        public void Add(TransactionElementSumBiz objBiz)
        {

            //if (objBiz.Direction == false || Count==0)
            List.Add(objBiz);
            //else
            //{
            //    TransactionElementSumBiz objTemp;
            //    for(int intIndex = 0;intIndex <Count;intIndex++)
            //    {

            //        if (this[intIndex].Direction == true)
            //            continue;
            //        else
            //        {
            //            objTemp = this[intIndex];

            //            this[intIndex] = objBiz;
            //            List.Add(this[Count - 1]);
            //            for (int intI = Count-1; intI >intIndex+1; intI--)
            //            {
            //                this[intI] = this[intI - 1];

            //            }
            //            this[intIndex + 1] = objTemp;
            //            break;

            //        }
            //    }
            //}

        }
        public int GetIndex(AccountBiz objAccountBiz)
        {
            int intIndex = 0;
            foreach (TransactionElementSumBiz objBiz in this)
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



            TransactionElementSumBiz ObjTransactionElementSumBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionElementSumBiz = new TransactionElementSumBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjTransactionElementSumBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionElementSumID");
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



            TransactionElementSumBiz ObjTransactionElementSumBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionElementSumBiz = new TransactionElementSumBiz(objDr);

                this.Add(ObjTransactionElementSumBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionElementSumID");
                objDb = new TransactionElementDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionElementDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public AccountCol GetAccountCol()
        {
            AccountCol Returned = new AccountCol(true);
            Hashtable hsTemp = new Hashtable();
            AccountBiz objAccountBiz = new AccountBiz();
            foreach (TransactionElementSumBiz objBiz in this)
            {
                if (hsTemp[objBiz.AccountBiz.ID.ToString()] != null)
                {
                    objAccountBiz = (AccountBiz)hsTemp[objBiz.AccountBiz.ID.ToString()];
                    objAccountBiz.CreditElementBalance = objBiz.TotalCreditValue;
                    objAccountBiz.DebitElementBalance = objBiz.TotalDebitValue;

                }
                else
                {
                    objAccountBiz = objBiz.AccountBiz;
                    objAccountBiz.CreditElementBalance = objBiz.TotalCreditValue;
                    objAccountBiz.DebitElementBalance = objBiz.TotalDebitValue;
                    hsTemp.Add(objAccountBiz.ID.ToString(), objAccountBiz);
                    Returned.Add(objAccountBiz);

                }
            }
             
            return Returned;
        }
        public CostCenterCol GetCostCenterCol(bool blIncludeCredit)
        {
            CostCenterCol Returned = new CostCenterCol(true);
            Hashtable hsTemp = new Hashtable();
            CostCenterBiz objCostCenterBiz = new CostCenterBiz();
            foreach (TransactionElementSumBiz objBiz in this)
            {
                if (hsTemp[objBiz.CostCenterBiz.ID.ToString()] != null)
                {
                    objCostCenterBiz = (CostCenterBiz)hsTemp[objBiz.CostCenterBiz.ID.ToString()];

                    //objCostCenterBiz.ElementCol.Add(objBiz);

                }
                else
                {
                    objCostCenterBiz = objBiz.CostCenterBiz;
                    //objCostCenterBiz.ElementCol.Add(objBiz);
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
        public DataTable GetTable()
        {
            //System.Type.GetType("System.Boolean"))
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ElementID"), 
                new DataColumn("ElementTransaction"), new DataColumn("ElementAccount"),
                new DataColumn("ElementDirection",Type.GetType("System.Boolean")),
             new DataColumn("ElementValue"),new DataColumn("CostCenterID"),new DataColumn("ElementOrder"),new DataColumn("ElementDesc")});
            DataRow objDr;
            int intOrder = 0;
            foreach (TransactionElementSumBiz objBiz in this)
            {
                intOrder++;
                objDr = dtReturned.NewRow();
                //objDr["ElementID"] = objBiz.ID;
                //objDr["ElementTransaction"] = objBiz.TRansaction;
                //objDr["ElementAccount"] = objBiz.AccountBiz.ID;
                //objDr["ElementDirection"] = objBiz.Direction ? 1 : 0;
                //objDr["ElementValue"] = objBiz.Value;
                //objDr["CostCenterID"] = objBiz.CostCenterBiz.ID;
                //objDr["ElementOrder"] = intOrder;
                //objDr["ElementDesc"] = objBiz.Desc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        //public TransactionElementSumCol Copy()
        //{
        //    TransactionElementSumCol Returned = new TransactionElementSumCol(true);
        //    foreach (TransactionElementSumBiz objBiz in this)
        //        Returned.Add(objBiz.Copy());
        //    return Returned;
        //}
    }
}
