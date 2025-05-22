using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentDiscountCol : BaseCol
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
        #region Private Data for Search
        CellBiz _CellBiz;
        int _ReservationStatus;
        string _UnitCode;
        DiscountTypeBiz _TypeBiz;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        bool _IsDueDateRange;
        DateTime _StartDueDate;
        DateTime _EndDueDate;
        InstallmentTypeCol _InstallmentTypeCol;
        int _HasTransactionStatus;
        #endregion
        #endregion
        public InstallmentDiscountCol(bool blIsempty)
        {
         
        }
        public InstallmentDiscountCol(int intID)
        {
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentDiscountBiz(objDr));
            }
        }
        public InstallmentDiscountCol(CellBiz objCellBiz,int intReservationStatus,string strUnitCode, DiscountTypeBiz objTypeBiz,bool blIsDateRange,
            DateTime dtStartDate,DateTime dtEndDate,bool blIsDueDateRange,DateTime dtStartDueDate,
            DateTime dtEndDueDate,InstallmentTypeCol objInstallmentTypeCol,int intHasTransactionStatus)
        {
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            SetDataInitially(objCellBiz, intReservationStatus, strUnitCode, objTypeBiz, blIsDateRange,
                dtStartDate, dtEndDate, blIsDueDateRange, dtStartDueDate, dtEndDueDate, objInstallmentTypeCol, intHasTransactionStatus);
            GetData(ref objDb);
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentDiscountBiz(objDr));
            }
            _ResultCount = objDb.ResultCount;
            _ResultValue = objDb.ResultValue;
            _EnableNext = false;
            _EnablePrevious = false;
            
            if (dtTemp.Rows.Count >= _MaxCount)
            {
                DataRow[] arrDr = dtTemp.Select("", "DiscountID");
                objDb = new InstallmentDiscountDb(arrDr[dtTemp.Rows.Count-1]);
                _MaxID = objDb.ID;
                objDb = new InstallmentDiscountDb(arrDr[0]);
                _MinID = objDb.ID;
                _EnableNext = true;

            }


        }
        #region Private Methods
        void GetData(ref InstallmentDiscountDb objDb)
        {
            if (_CellBiz.ID == _CellBiz.FamilyID)
                objDb.CellFamilyID = _CellBiz.FamilyID;
            else
                objDb.CellIDs = _CellBiz.IDsStr;
            objDb.ReservationStatus = _ReservationStatus;
            objDb.UnitCode = _UnitCode;
            objDb.TypeID = _TypeBiz.ID;
            objDb.IsDateRange = _IsDateRange;
            objDb.StartDate = _StartDate;
            objDb.EndDate = _EndDate;
            objDb.IsDueDateRange = _IsDueDateRange;
            objDb.StartDueDate = _StartDueDate;
            objDb.EndDueDate = _EndDueDate;
            objDb.InstallmentTypeIDs = _InstallmentTypeCol.IDsStr;
            objDb.HasTransactionStatus = _HasTransactionStatus;


 
        }
        void SetDataInitially(CellBiz objCellBiz, int intReservationStatus, string strUnitCode,
            DiscountTypeBiz objTypeBiz, bool blIsDateRange,
            DateTime dtStartDate, DateTime dtEndDate, bool blIsDueDateRange, DateTime dtStartDueDate,
            DateTime dtEndDueDate, InstallmentTypeCol objInstallmentTypeCol,int intHasTransactionStatus)
        {
            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            if (objInstallmentTypeCol == null)
                objInstallmentTypeCol = new InstallmentTypeCol(true);
            if (objTypeBiz == null)
                objTypeBiz = new DiscountTypeBiz();
            _CellBiz = objCellBiz;
            _ReservationStatus = intReservationStatus;
            _UnitCode = strUnitCode;
            _TypeBiz = objTypeBiz;
            _IsDateRange = blIsDateRange;
            _StartDate = dtStartDate;
            _EndDate = dtEndDate;
            _IsDueDateRange = blIsDateRange;
            _StartDueDate = dtStartDueDate;
            _EndDueDate = dtEndDueDate;
            _InstallmentTypeCol = objInstallmentTypeCol;
            _HasTransactionStatus = intHasTransactionStatus;
           
        }
        #endregion
        #region Public Accessories
        public InstallmentDiscountBiz this[int intIndex]
        {
           
            get
            {
                return (InstallmentDiscountBiz)List[intIndex];
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
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        #endregion
        #region Public Methods
        public void Add(InstallmentDiscountBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (InstallmentDiscountBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }

        public double GetDiscountAfterTimeValue(DateTime dtTime)
        {
            double Returned = 0;
            foreach (InstallmentDiscountBiz objBiz in this)
            {
                if (objBiz.Date <= dtTime)
                    Returned += objBiz.Value;
            }
            return Returned;
        }
        public void MoveNext()
        {

            Clear();
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            GetData(ref objDb);
            objDb.MaxID = _MaxID;
            objDb.MinID = 0;
            DataTable dtTemp = objDb.Search();



            InstallmentDiscountBiz ObjDiscountBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjDiscountBiz = new InstallmentDiscountBiz(objDr);

                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjDiscountBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "DiscountID");
                objDb = new InstallmentDiscountDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new InstallmentDiscountDb(arrDr[0]);
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
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            GetData(ref objDb);
            objDb.MinID = _MinID;
            DataTable dtTemp = objDb.Search();



            InstallmentDiscountBiz ObjDiscountBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjDiscountBiz = new InstallmentDiscountBiz(objDr);

                this.Add(ObjDiscountBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "DiscountID");
                objDb = new InstallmentDiscountDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new InstallmentDiscountDb(arrDr[0]);
                _MinID = objDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }

        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("InstallmentID"), new DataColumn("Value"), new DataColumn("Reason"), new DataColumn("Date") });
            DataRow objDr;
            foreach (InstallmentDiscountBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["InstallmentID"] = objBiz.InstallmentBiz.ID;
                objDr["Value"] = objBiz.Value;
                objDr["Reason"] = objBiz.Reason;
                objDr["Date"] = objBiz.Date;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public DataTable GetTransactionTable()
        {
            DataTable Returned = ReservationCol.GetTransactionEmbtyTable();
            DataRow objDr;
            foreach (InstallmentDiscountBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["DiscountID"] = objBiz.ID;
                objDr["InstallmentID"] = objBiz.InstallmentID;
                objDr["TransactionID"] = objBiz.TransactionBiz.ID;
                objDr["TransactionDate"] = objBiz.TransactionBiz.Date;
                objDr["TransactionCode"] = objBiz.TransactionBiz.Code;
                objDr["TransactionType"] = objBiz.TransactionBiz.TypeBiz.ID;
                objDr["TransactionValue"] = objBiz.TransactionBiz.Value;
                objDr["TransactionCurrency"] = objBiz.TransactionBiz.CurrencyBiz.ID;
                objDr["TransactionCurrencyValue"] = objBiz.TransactionBiz.CurrencyBiz.Value;
                objDr["TransactionDesc"] = objBiz.TransactionBiz.Desc;
                objDr["TransactionStatus"] = objBiz.TransactionBiz.Status;
                objDr["CurrentReservation"] = objBiz.TransactionBiz.ReservationID;
                objDr["FromAccountID"] = objBiz.TransactionBiz.AccountFromBiz.ID;
                objDr["ToAccountID"] = objBiz.TransactionBiz.AccountToBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void CreateTransaction()
        {
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            objDb.TransactionTable = GetTransactionTable();

            objDb.CreateTransaction();
 
        }
        #endregion

    }
}