using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.GL.GLBusiness
{
    public class TransactionCol : BaseCol
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
        int _EditStatus;
        int _HasReservationSatus;
        int _IsReversingStatus;
        string _UnitCode;
        string _CellIDs;
        int _CellFamilyID;
        int _ContractorID;
       TransactionSystemSource _SystemSource;
        int _SystemType;
        #endregion
        #endregion
        public TransactionCol(bool blIsempty)
        { 

        }
        public TransactionCol(AccountBiz objAccountBiz,JournalTypeBiz objTypeBiz,CurrencyBiz objCurrencyBiz,string strCodeLike,DateTime dtStartDate,
            DateTime dtEndDate,bool blIsDateRange,double dblStartValue,
            double dblEndValue,int intStatus,int intEditStatus,int intHasReservationStatus,int intIsReversingStatus,
            string strUnitCode,string strCellIDs,int intCellFamilyID,CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz,FinancialPeriodBiz objPeriodBiz,SpecificBiz objSpecificBiz,
            TransactionSystemSource objSystemSource,int intSystemType,int intContractorID)
        {
           
            TransactionDb objDb = new TransactionDb();
            SetDataInitially(objAccountBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus,intEditStatus, intHasReservationStatus, 
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID,objCompanyBiz,
                objYearBiz,objPeriodBiz,objSpecificBiz,objSystemSource,intSystemType,intContractorID);
            GetData(ref objDb);
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            TransactionBiz objTransactionBiz;
            string strUserIDs="";
            Hashtable hsUser = new Hashtable();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objTransactionBiz = new TransactionBiz(objDr);
                if ((objTransactionBiz.UsrIns != 0 || objTransactionBiz.UsrUpd!= 0) && (hsUser[objTransactionBiz.UsrIns.ToString()] == null||
                    hsUser[objTransactionBiz.UsrUpd.ToString()] == null))
                {
                    if (hsUser[objTransactionBiz.UsrIns.ToString()] == null)
                    {
                        hsUser.Add(objTransactionBiz.UsrIns.ToString(), objTransactionBiz.UsrIns.ToString());
                        if (strUserIDs != "")
                            strUserIDs += ",";
                        strUserIDs += objTransactionBiz.UsrIns;
                    }
                    if (hsUser[objTransactionBiz.UsrUpd.ToString()] == null)
                    {
                        hsUser.Add(objTransactionBiz.UsrUpd.ToString(), objTransactionBiz.UsrUpd.ToString());
                        if (strUserIDs != "")
                            strUserIDs += ",";
                        strUserIDs += objTransactionBiz.UsrUpd;
                    }
                
                }
                Add( objTransactionBiz );
            }
            DataRow []arrDr;
            if (strUserIDs != "")
            {
                UserDb objUserDb = new UserDb();
                objUserDb.IDs = strUserIDs;
                DataTable dtUser = objUserDb.Search();
                foreach (TransactionBiz objBiz in this)
                {
                    if (objBiz.UsrIns != 0)
                    {
                        arrDr = dtUser.Select("UserID="+ objBiz.UsrIns, "");
                        if (arrDr.Length != 0)
                            objBiz.UsrInsBiz = new UserBiz(arrDr[0]);
                    }
                    if (objBiz.UsrUpd != 0)
                    {
                        arrDr = dtUser.Select("UserID=" + objBiz.UsrUpd, "");
                        if (arrDr.Length != 0)
                            objBiz.UsrUpdBiz = new UserBiz(arrDr[0]);
                    }
                }
            }
            if (Count > 0)
            {
               arrDr = dtTemp.Select("", "TransactionID");
                objDb = new TransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        #region Private Data
        void SetDataInitially(AccountBiz objAccountBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
            DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
            double dblEndValue, int intStatus,int intEditStatus, int intHasReservationStatus, int intIsReversingStatus,
            string strUnitCode,string strCellIDs,int intCellFamilyID, CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz, FinancialPeriodBiz objPeriodBiz, SpecificBiz objSpecificBiz,
            TransactionSystemSource objSystemSource,
            int intSystemType,int intContractorID)
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
            _EditStatus = intEditStatus;
            _HasReservationSatus = intHasReservationStatus;
            _IsReversingStatus = intIsReversingStatus;
            _UnitCode = strUnitCode;
            _CellIDs = strCellIDs;
            _CellFamilyID = intCellFamilyID;
            _SpecificBiz = objSpecificBiz;
            _CompanyBiz = objCompanyBiz;
            _YearBiz = objYearBiz;
            _PeriodBiz = objPeriodBiz;
            _SystemSource = objSystemSource;
            _SystemType = intSystemType;
            _ContractorID = intContractorID;


        }
        void GetData(ref TransactionDb objDb)
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
            objDb.Code = _CodeLike;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            objDb.StartValue = _StartValue;
            objDb.EndValue = _EndValue;
            objDb.PostStatus = _Status;
            objDb.EditStatus = _EditStatus;
            objDb.HasReservationStatus = _HasReservationSatus;
            objDb.IsReversingStatus = _IsReversingStatus;
            objDb.UnitCode = _UnitCode;
            objDb.CellFamilyID = _CellFamilyID;
            objDb.CellIDs = _CellIDs;
            objDb.AccountIDs = _AccountBiz.IDsStr;
            objDb.SpecificID = _SpecificBiz.ID;
            objDb.CompanyID = _CompanyBiz.ID;
            objDb.YearID = _YearBiz.ID;
            objDb.PeriodID = _PeriodBiz.ID;
            objDb.SystemSource = (int)_SystemSource;
            objDb.SystemType = _SystemType;
            objDb.ContractorID = _ContractorID;
        
        }
        #endregion 
        public TransactionBiz this[int intIndex]
        {

            get
            {
                return (TransactionBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (TransactionBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
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
            
        public string[] IDsStrArr
        {
            get
            {
                string[] Returned;
                int intArrLen = Count / 400;
                if (intArrLen * 400 < Count)
                    intArrLen++;
                Returned = new string[intArrLen];
                int intOuterIndex = 0;
                TransactionBiz objBiz;
                int intTempIndex = 0;
                for (int intIndex = 0; intIndex < intArrLen; intIndex++)
                {
                    Returned[intIndex] = "";
                    for (int intInnerIndex = 0; intInnerIndex < 400; intInnerIndex++)
                    {
                        intTempIndex = (intIndex * 400) + intInnerIndex;
                        if (intTempIndex >= Count)
                            break;
                        objBiz = this[intTempIndex];
                        if (Returned[intIndex] != "")
                            Returned[intIndex] += ",";
                        Returned[intIndex] += objBiz.ID.ToString();

                    }

                }

                return Returned;
            }
        }
        #region Private Method
        void SetCol(DataTable dtTransactionTable, DataTable dtElementTable)
        {
            DataRow[] arrDr = dtTransactionTable.Select("", "TransactionDate");
            DataRow[] arrElementDr;
            TransactionBiz objBiz;
            TransactionElementBiz objElement;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new TransactionBiz(objDr);
                arrElementDr = dtElementTable.Select("ElementTransaction="+objBiz.ID.ToString());
                objBiz.ElementCol = new TransactionElementCol(true);
                foreach (DataRow objElementDr in arrElementDr)
                {
                    objElement = new TransactionElementBiz(objElementDr);
                   objElement.TransactionBiz = objBiz;
                   objBiz.ElementCol.Add(objElement);
                }
                List.Add(objBiz);
            }
        }
        #endregion
        public void Add(TransactionBiz objBiz)
        {
            List.Add(objBiz);

        }
        public void MoveNext()
        {

            Clear();
            TransactionDb objDb = new TransactionDb();
            GetData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();



            TransactionBiz ObjTransactionBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionBiz = new TransactionBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjTransactionBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionID");
                objDb = new TransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionDb(arrDr[0]);
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
            TransactionDb objDb = new TransactionDb();
            GetData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();



            TransactionBiz ObjTransactionBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjTransactionBiz = new TransactionBiz(objDr);

                this.Add(ObjTransactionBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionID");
                objDb = new TransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        public bool Post()
        {
            string[] arrStr = IDsStrArr;
            TransactionDb objDb;
            foreach (string strTemp in arrStr)
            {
                objDb = new TransactionDb();
                objDb.IDsStr = strTemp;
                objDb.PostTransaction();
 
            }

            return true;
 
        }
        public DataTable GetTable()
        {
            
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("TransactionID"),new DataColumn("TransactionDate"),
                new DataColumn("TransactionCode"),new DataColumn("TransactionType"),new DataColumn("TransactionCurrency"),
            new DataColumn("TransactionCurrencyValue"),
                new DataColumn("TransactionDesc"),new DataColumn("TransactionStatus"),
                new DataColumn("TransactionSystemSourceID"),new DataColumn("TransactionSyetemType")});
            DataRow objDR;
            foreach (TransactionBiz objBiz in this)
            {
                objDR = Returned.NewRow();
                objDR["TransactionID"] = objBiz.ID;
                objDR["TransactionDate"] = objBiz.Date;
                objDR["TransactionCode"] = objBiz.Code;
                objDR["TransactionType"] = objBiz.TypeBiz.ID;
                objDR["TransactionCurrency"] = objBiz.CurrencyBiz.ID;
                objDR["TransactionCurrencyValue"] = objBiz.CurrencyValue;
                objDR["TransactionDesc"] = objBiz.Desc;
                objDR["TransactionStatus"] = objBiz.Status;
                objDR["TransactionSystemSourceID"] = objBiz.SystemSource;
                objDR["TransactionSyetemType"] = objBiz.SystemType;
                Returned.Rows.Add(objDR);
            }
            return Returned;
        }
        public DataTable GetTable(out DataTable dtElement,out DataTable dtForignModule)
        {
            dtForignModule = new DataTable();
            dtElement = new TransactionElementCol(true).GetTable();
            dtForignModule.Columns.AddRange(new DataColumn[] { new DataColumn("GeneratedID",Type.GetType("System.Int64")),new DataColumn("IDs")});
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("GeneratedID"),new DataColumn("TransactionID"),new DataColumn("TransactionDate"),
                new DataColumn("TransactionCode"),new DataColumn("TransactionType"),new DataColumn("TransactionCurrency"),
            new DataColumn("TransactionCurrencyValue"),new DataColumn("TransactionDesc"),
                new DataColumn("TransactionStatus"),new DataColumn("TransactionSystemSourceID"),new DataColumn("TransactionSyetemType")
                ,new DataColumn("BaseCurrencyID"),new DataColumn("SpecificID"),new DataColumn("PeriodID")});
            DataRow objDR;
            DataRow objForignModuleDr;
            DataRow objElementRow;
            int intGenreatedID = 1;
            foreach (TransactionBiz objBiz in this)
            {
                objDR = Returned.NewRow();
                objDR["GeneratedID"] = intGenreatedID.ToString();
                objDR["TransactionID"] = objBiz.ID;
                objDR["BaseCurrencyID"] = objBiz.BaseCurrencyBiz.ID;
                objDR["SpecificID"] = objBiz.SpecificBiz.ID;
                objDR["PeriodID"] = objBiz.PeriodBiz.ID;
                objDR["TransactionDate"] = objBiz.Date;
                objDR["TransactionCode"] = objBiz.Code;
                objDR["TransactionType"] = objBiz.TypeBiz.ID;
                objDR["TransactionCurrency"] = objBiz.CurrencyBiz.ID;
                objDR["TransactionCurrencyValue"] = objBiz.CurrencyValue;
                objDR["TransactionDesc"] = objBiz.Desc;
                objDR["TransactionStatus"] = objBiz.Status;
                objDR["TransactionSyetemType"] = objBiz.SystemType;
                objDR["TransactionSystemSourceID"] = objBiz.SystemSource;
                foreach (TransactionElementBiz objElementBiz in objBiz.ElementCol)
                {
                    objElementBiz.GeneratedID = intGenreatedID;
                    objElementRow = dtElement.NewRow();
                    objElementBiz.GetDataRow(ref objElementRow);
                    dtElement.Rows.Add(objElementRow);
                 
                }

                   Returned.Rows.Add(objDR);
                   if (objBiz.OtherModuleSrcIDsStr != "")
                    {
                        objForignModuleDr = dtForignModule.NewRow();
                        objForignModuleDr["GeneratedID"] = intGenreatedID.ToString();
                        objForignModuleDr["IDs"] = objBiz.OtherModuleSrcIDsStr;
                        dtForignModule.Rows.Add(objForignModuleDr);

                    }
                intGenreatedID++;
            }
            return Returned;
        }
    }
}
