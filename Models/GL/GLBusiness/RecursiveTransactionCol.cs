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
    public class RecursiveTransactionCol : BaseCol
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

        #endregion
        #endregion
        public RecursiveTransactionCol(bool blIsempty)
        {

        }
        public RecursiveTransactionCol(AccountBiz objAccountBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
            DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
            double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
            string strUnitCode, string strCellIDs, int intCellFamilyID)
        {

            RecursiveTransactionDb objDb = new RecursiveTransactionDb();
            SetDataInitially(objAccountBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus, intHasReservationStatus,
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID);
            GetData(ref objDb);
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new RecursiveTransactionBiz(objDr));
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "TransactionID");
                objDb = new RecursiveTransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new RecursiveTransactionDb(arrDr[0]);
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
            double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
            string strUnitCode, string strCellIDs, int intCellFamilyID)
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
        }
        void GetData(ref RecursiveTransactionDb objDb)
        {
            objDb.Type = _TypeBiz.ID;
            objDb.Currency = _CurrencyBiz.ID;
            objDb.Code = _CodeLike;
            objDb.DateStatus = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            objDb.StartValue = _StartValue;
            objDb.EndValue = _EndValue;
         


        }
        #endregion
        public RecursiveTransactionBiz this[int intIndex]
        {

            get
            {
                return (RecursiveTransactionBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (RecursiveTransactionBiz objBiz in this)
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
                RecursiveTransactionBiz objBiz;
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
        void SetCol(DataTable dtRecursiveTransactionTable, DataTable dtElementTable)
        {
            DataRow[] arrDr = dtRecursiveTransactionTable.Select("", "RecursiveTransactionDate");
            DataRow[] arrElementDr;
            RecursiveTransactionBiz objBiz;
            RecursiveTransactionElementBiz objElement;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new RecursiveTransactionBiz(objDr);
                arrElementDr = dtElementTable.Select("ElementTransaction=" + objBiz.ID.ToString());
                objBiz.ElementCol = new RecursiveTransactionElementCol(true);
                foreach (DataRow objElementDr in arrElementDr)
                {
                    objElement = new RecursiveTransactionElementBiz(objElementDr);
                    objElement.TransactionBiz = objBiz;
                    objBiz.ElementCol.Add(objElement);
                }
                List.Add(objBiz);
            }
        }
        #endregion
        public void Add(RecursiveTransactionBiz objBiz)
        {
            List.Add(objBiz);

        }
        public void MoveNext()
        {

            Clear();
            RecursiveTransactionDb objDb = new RecursiveTransactionDb();
            GetData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();



            RecursiveTransactionBiz ObjRecursiveTransactionBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjRecursiveTransactionBiz = new RecursiveTransactionBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjRecursiveTransactionBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "RecursiveTransactionID");
                objDb = new RecursiveTransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new RecursiveTransactionDb(arrDr[0]);
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
            RecursiveTransactionDb objDb = new RecursiveTransactionDb();
            GetData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();



            RecursiveTransactionBiz ObjRecursiveTransactionBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjRecursiveTransactionBiz = new RecursiveTransactionBiz(objDr);

                this.Add(ObjRecursiveTransactionBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "RecursiveTransactionID");
                objDb = new RecursiveTransactionDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new RecursiveTransactionDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
       
        public DataTable GetTable()
        {

            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("RecursiveTransactionID"),new DataColumn("RecursiveTransactionDate"),
                new DataColumn("RecursiveTransactionCode"),new DataColumn("RecursiveTransactionType"),new DataColumn("RecursiveTransactionCurrency"),
            new DataColumn("RecursiveTransactionCurrencyValue"),new DataColumn("RecursiveTransactionDesc"),new DataColumn("RecursiveTransactionStatus")});
            DataRow objDR;
            foreach (RecursiveTransactionBiz objBiz in this)
            {
                objDR = Returned.NewRow();
                objDR["RecursiveTransactionID"] = objBiz.ID;
                objDR["RecursiveTransactionDate"] = objBiz.StartDate;
                objDR["RecursiveTransactionCode"] = objBiz.Code;
                objDR["RecursiveTransactionType"] = objBiz.TypeBiz.ID;
                objDR["RecursiveTransactionCurrency"] = objBiz.CurrencyBiz.ID;
                objDR["RecursiveTransactionCurrencyValue"] = objBiz.CurrencyValue;
                objDR["RecursiveTransactionDesc"] = objBiz.Desc;
               
                Returned.Rows.Add(objDR);
            }
            return Returned;
        }
    }
}
