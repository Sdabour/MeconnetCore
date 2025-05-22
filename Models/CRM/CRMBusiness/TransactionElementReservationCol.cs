using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
using SharpVision.GL.GLBusiness;
using SharpVision.CRM.CRMDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class TransactionElementReservationCol : TransactionElementCol
    {
        #region Private Data
        ReservationBiz _ReservationBiz;
        CellBiz _ReservationCellBiz;
        #endregion
        public TransactionElementReservationCol()
            : base()
        { }
        public TransactionElementReservationCol(bool blIsempty) 
        {
            if (!blIsempty)
            {
                TransactionElementReservationDb objDb = new TransactionElementReservationDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new TransactionElementBiz(objDr));
                }
            }
        }
         public TransactionElementReservationCol(AccountBiz objAccountBiz,CostCenterBiz objCostCenterBiz,JournalTypeBiz objTypeBiz,CurrencyBiz objCurrencyBiz,string strCodeLike,DateTime dtStartDate,
            DateTime dtEndDate,bool blIsDateRange,double dblStartValue,
            double dblEndValue,int intStatus,int intHasReservationStatus,int intIsReversingStatus,
            string strUnitCode,string strCellIDs,int intCellFamilyID,CompanyBiz objCompanyBiz,
            FinancialYearBiz objYearBiz,FinancialPeriodBiz objPeriodBiz,SpecificBiz objSpecificBiz,
             int intSystemtSource,int intSystemType,int intContractorID,
             ReservationBiz objReservationBiz,CellBiz objReservationCellBiz)
        {
           
            TransactionElementReservationDb objDb = new TransactionElementReservationDb();
            SetDataInitially(objAccountBiz,objCostCenterBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus, intHasReservationStatus, 
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID,objCompanyBiz,
                objYearBiz,objPeriodBiz,objSpecificBiz,intSystemtSource,intSystemType,
                intContractorID,objReservationBiz,objReservationCellBiz);
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
                //if ((objTransactionElementBiz.TransactionBiz.UsrIns != 0 || objTransactionElementBiz.TransactionBiz.UsrUpd != 0) &&
                //    (hsUser[objTransactionElementBiz.TransactionBiz.UsrIns.ToString()] == null ||
                //    hsUser[objTransactionElementBiz.TransactionBiz.UsrUpd.ToString()] == null))
                //{
                //    if (hsUser[objTransactionElementBiz.TransactionBiz.UsrIns.ToString()] == null)
                //    {
                //        hsUser.Add(objTransactionElementBiz.TransactionBiz.UsrIns.ToString(), objTransactionElementBiz.TransactionBiz.UsrIns.ToString());
                //        if (strUserIDs != "")
                //            strUserIDs += ",";
                //        strUserIDs += objTransactionElementBiz.TransactionBiz.UsrIns;
                //    }
                //    if (hsUser[objTransactionElementBiz.TransactionBiz.UsrUpd.ToString()] == null)
                //    {
                //        hsUser.Add(objTransactionElementBiz.TransactionBiz.UsrUpd.ToString(), objTransactionElementBiz.TransactionBiz.UsrUpd.ToString());
                //        if (strUserIDs != "")
                //            strUserIDs += ",";
                //        strUserIDs += objTransactionElementBiz.TransactionBiz.UsrUpd;
                //    }

                //}
                Add( objTransactionElementBiz );
            }
            DataRow []arrDr;
            //if (strUserIDs != "")
            //{
            //    UserDb objUserDb = new UserDb();
            //    objUserDb.IDs = strUserIDs;
            //    DataTable dtUser = objUserDb.Search();
            //    foreach (TransactionElementBiz objBiz in this)
            //    {
            //        if (objBiz.TransactionBiz.UsrIns != 0)
            //        {
            //            arrDr = dtUser.Select("UserID=" + objBiz.TransactionBiz.UsrIns, "");
            //            if (arrDr.Length != 0)
            //                objBiz.TransactionBiz.UsrInsBiz = new UserBiz(arrDr[0]);
            //        }
            //        if (objBiz.TransactionBiz.UsrUpd != 0)
            //        {
            //            arrDr = dtUser.Select("UserID=" + objBiz.TransactionBiz.UsrUpd, "");
            //            if (arrDr.Length != 0)
            //                objBiz.TransactionBiz.UsrUpdBiz = new UserBiz(arrDr[0]);
            //        }
            //    }
            //}
            if (Count > 0)
            {
               arrDr = dtTemp.Select("", "ElementID");
                objDb = new TransactionElementReservationDb(arrDr[Count - 1]);
                _MaxID = objDb.ID;
                objDb = new TransactionElementReservationDb(arrDr[0]);
                _MinID = objDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        #region Private Method
        protected  void SetDataInitially(AccountBiz objAccountBiz, CostCenterBiz objCostCenterBiz, JournalTypeBiz objTypeBiz, CurrencyBiz objCurrencyBiz, string strCodeLike, DateTime dtStartDate,
           DateTime dtEndDate, bool blIsDateRange, double dblStartValue,
           double dblEndValue, int intStatus, int intHasReservationStatus, int intIsReversingStatus,
           string strUnitCode, string strCellIDs, int intCellFamilyID, CompanyBiz objCompanyBiz,
           FinancialYearBiz objYearBiz, FinancialPeriodBiz objPeriodBiz,
           SpecificBiz objSpecificBiz, int intSystemSource, int intSystemType,
            int intContractorID,ReservationBiz objReservationBiz,CellBiz objReservationCellBiz)
        {
            base.SetDataInitially(objAccountBiz, objCostCenterBiz, objTypeBiz, objCurrencyBiz, strCodeLike, dtStartDate,
                dtEndDate, blIsDateRange, dblStartValue, dblEndValue, intStatus, intHasReservationStatus,
                intIsReversingStatus, strUnitCode, strCellIDs, intCellFamilyID, objCompanyBiz,
                objYearBiz, objPeriodBiz, objSpecificBiz, intSystemSource, intSystemType, intContractorID);
            _ReservationBiz = objReservationBiz;
            _ReservationCellBiz = objReservationCellBiz;

        }
        protected  void GetData(ref TransactionElementReservationDb objDb)
        {
            TransactionElementDb objTemp = (TransactionElementDb)objDb;
            base.GetData(ref objTemp);
            if (_ReservationBiz == null)
                _ReservationBiz = new ReservationBiz();
            if (_ReservationCellBiz == null)
                _ReservationCellBiz = new CellBiz();
            ((TransactionElementReservationDb)objDb).ReservationID = _ReservationBiz.ID;
            ((TransactionElementReservationDb)objDb).ReservationCellFamilyID = _ReservationCellBiz.ID == _ReservationCellBiz.FamilyID ?
                _ReservationCellBiz.FamilyID : 0;

            ((TransactionElementReservationDb)objDb).ReservationCellIDs = _ReservationCellBiz.ID == _ReservationCellBiz.FamilyID ?
               _ReservationCellBiz.IDsStr : "";

        }
        #endregion
    }
}
