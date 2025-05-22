using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.RP.RPBusiness;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.HR.HRBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCol : BaseCol
    {

        #region Private Data
        int _MaxCount = 2000;
        int _ResultCount = 0;
        double _ResultValue;
        double _ResultDiscountValue;
        int _TheMinID;
        int _MaxID;
        int _MinID;
        int _CurrentIndex;
        bool _EnableNext;
        bool _EnablePrevious;
        bool _IsSet = false;
        bool _ResubmissionIsSet;
        bool _IsSetParially;
       bool _ResubmissionDateRange;
        DateTime _ResubmissionStart;
        DateTime _ResubmissionEnd;
        string _ResubmissionSerial;
        Hashtable _ReservationIndexHash = new Hashtable();
        #region Private Data Previous Search
          string _StatusStr ;
          string _CustomerName;
           int _NationalityID ;
           int _JobID ;
        int _UnitTypeID;
           string _UnitCode ;
           double _ToSurvey ;
           double _FromSurvey ;
           
           int _CellFamilyID ;
           int _FloorOrder ;
                
           string _CellIDs ;
          int _FreeStatus;
            int _NewStatus;
        int _ParentStatus;
            bool _ContractingDateRange ;
            DateTime _ContractingStartDate ;
            DateTime _ContractingEndDate;
            bool _ReservationDateRange ;
            DateTime _ReservationStartDate ;
            DateTime _ReservationEndDate;
        bool _ReservationStatusRange;
        DateTime _StatusStartDate;
        DateTime _StatusEndDate;
            int _DealStatus;
            string _Note ;
        int _AttachmentStatus;
        int _BranchID;
        string _BranchIDs;

        string _ResubmissionIDs;
        int _CancelationType;
        int _SalesManID;
        string _SalesManIDs;
        int _DelegationStatus;
        int _SoldStatus;
        int _ContractingTransactionStatus;
        int _DeliveryTransactionStatus;
        int _CancelationTransactionStatus;
        int _HasInstallmentStatus;
        int _PayBackCompleteStatus;
        int _ReservationChangedStatus;
        double _StartReservationValue;
        double _EndReservationValue;
        double _StartDueValue;
        double _EndDueValue;
        double _StartPaidValue;
        double _EndPaidValue;
        int _IsReservedStatus;
        string _InstallmentTypeIDs;
        CampaignBiz _CampaignBiz = new CampaignBiz();
        bool _PayBackIsSet;
        BrandCol _BrandCol;
        ProjectCol _ProjectCol;
        TowerCol _TowerCol;
        int _TenancyStatus;
        
        #endregion
        #endregion
        #region Public constructor
        public ReservationCol(bool blIsempty)
        {

        }

        public ReservationCol(string strStatus, string strNote, bool blReservationDateRange,
    DateTime dtReservationStartDate, DateTime dtReservationEndDate,
  bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
    , string strCustomerName, JobBiz objJobBiz, CountryBiz objCountryBiz,
    string strUnitCode, CellBiz objCellbiz, double dblFromSurvey, double dblToSurvey, int intDealStatus,
    int intCellOrder, int intAttachmentStatus, int freeStatus, int intNewStatus, int intParentStatus,
    UnitTypeBiz objUnitTypebiz, BranchCol objBranchCol, SalesManCol objSalesManCol, bool blStatusDateStatus,
    DateTime dtStatusStartDate, DateTime dtStatusEndDate, int intDelegateStatus, int intSoldStatus,
    double dblStartReservationValue, double dblEndReservationValue, double dblStartDueValue,
    double dblEndDueValue, InstallmentTypeCol objInstallmentTypeCol, double dblStartPaidValue,
    double dblEndPaidValue, int intIsReservedStatus, CampaignBiz objCampaignBiz, int intHasInstallmentStatus,
    ResubmissionTypeCol objResubmissionTypeCol, CancelationTypeBiz objCancelationTypeBiz, int intPayBackCompleteStatus
    , bool blResubmissionDateRange, 
    DateTime dtResubmissionStart, 
    DateTime dtResubmissionEnd,
    string strResubmissionSerial
            ,int intTenancyStatus,BrandCol objBrandCol,ProjectCol objProjectCol,TowerCol objTowerCol)
        {
            ReservationDb objReservationDb = new ReservationDb();

            SetDataInitially(strStatus, strNote, blReservationDateRange, dtReservationStartDate,
                dtReservationEndDate, blContractDateRange, dtContractStartDate, dtContractEndDate,
                strCustomerName, objJobBiz, objCountryBiz, strUnitCode, objCellbiz, dblFromSurvey, dblToSurvey, intDealStatus,
                intCellOrder, intAttachmentStatus, freeStatus, intNewStatus, intParentStatus, objUnitTypebiz, null, null, objBranchCol, objSalesManCol,
                blStatusDateStatus, dtStatusStartDate, dtStatusEndDate, intDelegateStatus, intSoldStatus, 0, 0, 0, 0, dblStartReservationValue,
                dblEndReservationValue, dblStartDueValue, dblEndDueValue, objInstallmentTypeCol, dblStartPaidValue, dblEndPaidValue, intIsReservedStatus,
                objCampaignBiz, intHasInstallmentStatus, objResubmissionTypeCol, objCancelationTypeBiz, intPayBackCompleteStatus
                , blResubmissionDateRange, dtResubmissionStart, dtResubmissionEnd,intTenancyStatus, objBrandCol, objProjectCol, objTowerCol);
            GetSearchData(ref objReservationDb);
            objReservationDb.ResubmissionSerial = strResubmissionSerial;
            DataTable dtTemp = objReservationDb.Search();
            #region UserData
            string strUsrSelect = "UsrIns,UsrUpd";
            if (dtTemp.Columns["ResubmissionUsrIns"] != null)
                strUsrSelect += ",ResubmissionUsrIns";
            List<string> arrStr = SysUtility.GetStringArrForMultiple(dtTemp, strUsrSelect, _MaxCount);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            //arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", _MaxCount);
            ////string strUsrIDs = "";
            //foreach (string strID in arrStr)
            //{
            //    if (strUsrIDs != "" && strID != "")
            //        strUsrIDs += ",";
            //    strUsrIDs += strID;
            //}
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion
            _ResultCount = objReservationDb.ResultCount;
            _ResultValue = objReservationDb.ResultValue;
            _ResultDiscountValue = objReservationDb.ResultDiscountValue;
            ReservationInstallmentCol objTempCol;
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    ReservationBiz ObjBiz = new ReservationBiz(objDr);
            //    //objTempCol = ObjBiz.LinearInstallmentCol;
            //    this.Add(ObjBiz);
            //}

            DataRow[] arrUsr;
            ReservationBiz ObjBiz;
            int intCount = dtTemp.Rows.Count;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                try
                {
                    ObjBiz = new ReservationBiz(objDr);
                    if (ObjBiz.Status == ReservationStatus.Cancellation)
                        ObjBiz = new ReservationCanceledBiz(objDr);
                    //arrAccount = dtAccount.Select("AccountID=" + ObjBiz.AccountID);
                    //if (arrAccount.Length > 0)
                    //    ObjBiz.AccountBiz = new AccountBiz(arrAccount[0]);
                    objReservationDb = new ReservationDb(objDr);
                    arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserIns);
                    if (arrUsr.Length > 0)
                        ObjBiz.UserIns = new UserBiz(arrUsr[0]);
                    arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserUpd);
                    if (arrUsr.Length > 0)
                        ObjBiz.UserUpd = new UserBiz(arrUsr[0]);
                    arrUsr = dtUserTemp.Select("UserID=" + ObjBiz.ResubmissionBiz.UsrIns);
                    if (arrUsr.Length > 0)
                        ObjBiz.ResubmissionBiz.UserBiz = new UserBiz(arrUsr[0]);

                    this.Add(ObjBiz);
                }
                catch { }
            }
           // intCount = Count;
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (intCount >= _MaxCount)
            {
                _EnableNext = true;
            }

        }



        public ReservationCol(string strStatus,string strNote, bool blReservationDateRange, 
            DateTime dtReservationStartDate, DateTime dtReservationEndDate,
          bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
            ,string strCustomerName,JobBiz objJobBiz,CountryBiz objCountryBiz,
            string strUnitCode,CellBiz objCellbiz,double dblFromSurvey,double dblToSurvey,int intDealStatus,
            int intCellOrder,int intAttachmentStatus,int freeStatus,int intNewStatus,int intParentStatus,
            UnitTypeBiz objUnitTypebiz,BranchBiz objBranchbiz,SalesManBiz objSalesManbiz,bool blStatusDateStatus,
            DateTime dtStatusStartDate,DateTime dtStatusEndDate,int intDelegateStatus,int intSoldStatus,
            double dblStartReservationValue, double dblEndReservationValue, double dblStartDueValue,
            double dblEndDueValue, InstallmentTypeCol objInstallmentTypeCol,double dblStartPaidValue,
            double dblEndPaidValue,int intIsReservedStatus,CampaignBiz objCampaignBiz,int intHasInstallmentStatus,
            ResubmissionTypeCol objResubmissionTypeCol,CancelationTypeBiz objCancelationTypeBiz,int intPayBackCompleteStatus
            ,bool blResubmissionDateRange,DateTime dtResubmissionStart,DateTime dtResubmissionEnd)
        {
            ReservationDb objReservationDb = new ReservationDb();

            SetDataInitially(strStatus, strNote, blReservationDateRange, dtReservationStartDate,
                dtReservationEndDate, blContractDateRange, dtContractStartDate, dtContractEndDate,
                strCustomerName, objJobBiz, objCountryBiz, strUnitCode, objCellbiz, dblFromSurvey, dblToSurvey, intDealStatus,
                intCellOrder, intAttachmentStatus, freeStatus, intNewStatus, intParentStatus, objUnitTypebiz, objBranchbiz, objSalesManbiz,null,null,
                blStatusDateStatus, dtStatusStartDate, dtStatusEndDate, intDelegateStatus, intSoldStatus, 0, 0, 0, 0, dblStartReservationValue,
                dblEndReservationValue, dblStartDueValue, dblEndDueValue, objInstallmentTypeCol, dblStartPaidValue, dblEndPaidValue,intIsReservedStatus,
                objCampaignBiz,intHasInstallmentStatus,objResubmissionTypeCol,objCancelationTypeBiz,intPayBackCompleteStatus
                ,blResubmissionDateRange,dtResubmissionStart,dtResubmissionEnd,0,null,null,null );
            GetSearchData(ref objReservationDb);
           
            DataTable dtTemp = objReservationDb.Search();
            #region UserData
            string strUsrSelect = "UsrIns,UsrUpd";
            if (dtTemp.Columns["ResubmissionUsrIns"] != null)
                strUsrSelect += ",ResubmissionUsrIns";
            List<string> arrStr = SysUtility.GetStringArrForMultiple(dtTemp, strUsrSelect, _MaxCount);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            //arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", _MaxCount);
            ////string strUsrIDs = "";
            //foreach (string strID in arrStr)
            //{
            //    if (strUsrIDs != "" && strID != "")
            //        strUsrIDs += ",";
            //    strUsrIDs += strID;
            //}
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion
            _ResultCount = objReservationDb.ResultCount;
            _ResultValue = objReservationDb.ResultValue;
            _ResultDiscountValue = objReservationDb.ResultDiscountValue;
            ReservationInstallmentCol objTempCol;
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    ReservationBiz ObjBiz = new ReservationBiz(objDr);
            //    //objTempCol = ObjBiz.LinearInstallmentCol;
            //    this.Add(ObjBiz);
            //}

            DataRow[] arrUsr;
            ReservationBiz ObjBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {

                ObjBiz = new ReservationBiz(objDr);
                if (ObjBiz.Status == ReservationStatus.Cancellation)
                    ObjBiz =new ReservationCanceledBiz(objDr);
                //arrAccount = dtAccount.Select("AccountID=" + ObjBiz.AccountID);
                //if (arrAccount.Length > 0)
                //    ObjBiz.AccountBiz = new AccountBiz(arrAccount[0]);
                objReservationDb = new ReservationDb(objDr);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserIns);
                if (arrUsr.Length > 0)
                    ObjBiz.UserIns = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserUpd);
                if (arrUsr.Length > 0)
                    ObjBiz.UserUpd = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + ObjBiz.ResubmissionBiz.UsrIns);
                if (arrUsr.Length > 0)
                    ObjBiz.ResubmissionBiz.UserBiz = new UserBiz(arrUsr[0]);

                this.Add(ObjBiz);
            }

            if (Count > 0)
            {
                DataRow [] arrDr = dtTemp.Select("","ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }





        public ReservationCol(string strStatus, string strNote, bool blReservationDateRange,
          DateTime dtReservationStartDate, DateTime dtReservationEndDate,
        bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
          , string strCustomerName, JobBiz objJobBiz, CountryBiz objCountryBiz,
          string strUnitCode, CellBiz objCellbiz, double dblFromSurvey, double dblToSurvey, int intDealStatus,
          int intCellOrder, int intAttachmentStatus, int freeStatus, int intNewStatus, int intParentStatus,
          UnitTypeBiz objUnitTypebiz, BranchBiz objBranchbiz, SalesManBiz objSalesManbiz, bool blStatusDateStatus,
          DateTime dtStatusStartDate, DateTime dtStatusEndDate, int intDelegateStatus, int intSoldStatus,
          double dblStartReservationValue, double dblEndReservationValue, double dblStartDueValue,
          double dblEndDueValue, InstallmentTypeCol objInstallmentTypeCol, double dblStartPaidValue,
          double dblEndPaidValue, int intIsReservedStatus, CampaignBiz objCampaignBiz, int intHasInstallmentStatus,
          ResubmissionTypeCol objResubmissionTypeCol, CancelationTypeBiz objCancelationTypeBiz, int intPayBackCompleteStatus
          , bool blResubmissionDateRange, DateTime dtResubmissionStart, DateTime dtResubmissionEnd,
            bool blIsDueDated,DateTime dtStartDueDate,DateTime dtEndDueDate)
        {
            ReservationDb objReservationDb = new ReservationDb();

            SetDataInitially(strStatus, strNote, blReservationDateRange, dtReservationStartDate,
                dtReservationEndDate, blContractDateRange, dtContractStartDate, dtContractEndDate,
                strCustomerName, objJobBiz, objCountryBiz, strUnitCode, objCellbiz, dblFromSurvey, dblToSurvey, intDealStatus,
                intCellOrder, intAttachmentStatus, freeStatus, intNewStatus, intParentStatus, objUnitTypebiz, objBranchbiz, objSalesManbiz, null, null,
                blStatusDateStatus, dtStatusStartDate, dtStatusEndDate, intDelegateStatus, intSoldStatus, 0, 0, 0, 0, dblStartReservationValue,
                dblEndReservationValue, dblStartDueValue, dblEndDueValue, objInstallmentTypeCol, dblStartPaidValue, dblEndPaidValue, intIsReservedStatus,
                objCampaignBiz, intHasInstallmentStatus, objResubmissionTypeCol, objCancelationTypeBiz, intPayBackCompleteStatus
                , blResubmissionDateRange, dtResubmissionStart, dtResubmissionEnd,0 ,null,null,null);
            GetSearchData(ref objReservationDb);

            objReservationDb.IsDueDated = blIsDueDated;
            objReservationDb.DueDateStart = dtStartDueDate;
            objReservationDb.DueDateEnd = dtEndDueDate;

            DataTable dtTemp = objReservationDb.Search();
            #region UserData
            string strUsrSelect = "UsrIns,UsrUpd";
            if (dtTemp.Columns["ResubmissionUsrIns"] != null)
                strUsrSelect += ",ResubmissionUsrIns";
            List<string> arrStr = SysUtility.GetStringArrForMultiple(dtTemp, strUsrSelect, _MaxCount);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            //arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", _MaxCount);
            ////string strUsrIDs = "";
            //foreach (string strID in arrStr)
            //{
            //    if (strUsrIDs != "" && strID != "")
            //        strUsrIDs += ",";
            //    strUsrIDs += strID;
            //}
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion
            _ResultCount = objReservationDb.ResultCount;
            _ResultValue = objReservationDb.ResultValue;
            _ResultDiscountValue = objReservationDb.ResultDiscountValue;
            ReservationInstallmentCol objTempCol;
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    ReservationBiz ObjBiz = new ReservationBiz(objDr);
            //    //objTempCol = ObjBiz.LinearInstallmentCol;
            //    this.Add(ObjBiz);
            //}

            DataRow[] arrUsr;
            ReservationBiz ObjBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {

                ObjBiz = new ReservationBiz(objDr);
                if (ObjBiz.Status == ReservationStatus.Cancellation)
                    ObjBiz = new ReservationCanceledBiz(objDr);
                //arrAccount = dtAccount.Select("AccountID=" + ObjBiz.AccountID);
                //if (arrAccount.Length > 0)
                //    ObjBiz.AccountBiz = new AccountBiz(arrAccount[0]);
                objReservationDb = new ReservationDb(objDr);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserIns);
                if (arrUsr.Length > 0)
                    ObjBiz.UserIns = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserUpd);
                if (arrUsr.Length > 0)
                    ObjBiz.UserUpd = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + ObjBiz.ResubmissionBiz.UsrIns);
                if (arrUsr.Length > 0)
                    ObjBiz.ResubmissionBiz.UserBiz = new UserBiz(arrUsr[0]);

                this.Add(ObjBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }




        public ReservationCol(string strStatus, string strNote, bool blReservationDateRange,
             DateTime dtReservationStartDate, DateTime dtReservationEndDate,
           bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
             , string strCustomerName, JobBiz objJobBiz, CountryBiz objCountryBiz,
             string strUnitCode, CellBiz objCellbiz, double dblFromSurvey, double dblToSurvey, int intDealStatus, int intCellOrder,
            byte btAccountStatus,byte btLeafAccountStatus,int freeStatus,int intParentStatus,UnitTypeBiz objUnitTypebiz,BranchBiz objBranchbiz,SalesManBiz objSalesManbiz,bool blStatusDateStatus,
            DateTime dtStatusStartDate, DateTime dtStatusEndDate, int intDelegateStatus, int intSoldStatus, int intTest, double dblStartReservationValue, double dblEndReservationValue, double dblStartDueValue,
            double dblEndDueValue, InstallmentTypeCol objInstallmentTypeCol,
            double dblStartPaidValue,double dblEndPaidValue,int intIsReservedStatus,int intHasINstallmentStatus)
        {
            ReservationDb objReservationDb = new ReservationDb();

            SetDataInitially(strStatus, strNote, blReservationDateRange, dtReservationStartDate,
                dtReservationEndDate, blContractDateRange, dtContractStartDate, dtContractEndDate,
                strCustomerName, objJobBiz, objCountryBiz, strUnitCode, objCellbiz, dblFromSurvey, dblToSurvey, intDealStatus,
                intCellOrder, 0, freeStatus, 0, intParentStatus, objUnitTypebiz, objBranchbiz, objSalesManbiz,null,null,
                blStatusDateStatus, dtStatusStartDate, dtStatusEndDate, intDelegateStatus, intSoldStatus, 0, 0, 0, 0, 
                dblStartReservationValue, dblEndReservationValue, dblStartDueValue, dblEndDueValue, objInstallmentTypeCol,dblStartPaidValue,
                dblEndPaidValue, intIsReservedStatus, new CampaignBiz(), intHasINstallmentStatus, new ResubmissionTypeCol(true), new CancelationTypeBiz(),0
                ,false,DateTime.Now,DateTime.Now,0,null,null,null);
            GetSearchData(ref objReservationDb);
            objReservationDb.AccountStatus = btAccountStatus;
            objReservationDb.LeafAccountStatus = btLeafAccountStatus;
            DataTable dtTemp = objReservationDb.Search();
            #region UserData
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "UsrIns", 200);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", 200);
            //string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion
            _ResultCount = objReservationDb.ResultCount;
            _ResultValue = objReservationDb.ResultValue;
            _ResultDiscountValue = objReservationDb.ResultDiscountValue;
            string strAccountIDs = "";
            string strAccount = "";
            DataRow[] arrDr = dtTemp.Select("", "ReservationGLAccount");
            ReservationBiz ObjBiz;
            foreach (DataRow objDr in arrDr)
            {
                if (strAccount != objDr["ReservationGLAccount"].ToString())
                {
                    strAccount = objDr["ReservationGLAccount"].ToString();
                    if (strAccountIDs != "")
                        strAccountIDs += ",";
                    strAccountIDs += strAccount;
                }
 
            }
            

            AccountDb objAccountDb = new AccountDb();
            objAccountDb.IDsStr = strAccountIDs;
            DataTable dtAccount = objAccountDb.Search();
            DataRow[] arrAccount;
            DataRow[] arrUsr;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                ObjBiz = new ReservationBiz(objDr);
                if (ObjBiz.Status == ReservationStatus.Cancellation)
                    ObjBiz = new ReservationCanceledBiz(objDr);
                arrAccount = dtAccount.Select("AccountID="+ ObjBiz.AccountID);
                if (arrAccount.Length > 0)
                    ObjBiz.AccountBiz = new AccountBiz(arrAccount[0]);
                arrUsr = dtUserTemp.Select("UserID=" + ObjBiz.UserIns);
                if (arrUsr.Length > 0)
                    ObjBiz.UserIns = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + ObjBiz.UserUpd);
                if (arrUsr.Length > 0)
                    ObjBiz.UserUpd  = new UserBiz(arrUsr[0]);
                this.Add(ObjBiz);
            }
            if (Count > 0)
            {
                arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        /*
         * GL Constractor
         */
       
        public ReservationCol(string strStatus, string strNote, bool blReservationDateRange,
            DateTime dtReservationStartDate, DateTime dtReservationEndDate,
          bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
            , string strCustomerName, JobBiz objJobBiz, CountryBiz objCountryBiz,
            string strUnitCode, CellBiz objCellbiz, double dblFromSurvey, double dblToSurvey,
            int intDealStatus, int intCellOrder,
           byte btAccountStatus, byte btLeafAccountStatus,byte btContractingTransactionStatus,
            byte btDeliveryTransactionStatus,int intCancelationTransactionStatus,int intReservationChangedStatus,
            int freestsus, int intParentStatus, UnitTypeBiz objunitTypeBiz,
            BranchBiz objBranchbiz, SalesManBiz objSalesManbiz, int intDelegateStatus, int intSoldStatus,
            double dblStartReservationValue, double dblEndReservationValue, double dblStartDueValue,
            double dblEndDueValue,
            InstallmentTypeCol objInstallmentTypeCol, double dblStartPaidValue, double dblEndPaidValue,
            int intIsReservedStatus,int intHasInstallmentStatus)
        {
            ReservationDb objReservationDb = new ReservationDb();

            SetDataInitially(strStatus, strNote, blReservationDateRange, dtReservationStartDate,
                dtReservationEndDate, blContractDateRange, dtContractStartDate, dtContractEndDate,
                strCustomerName, objJobBiz, objCountryBiz, strUnitCode, objCellbiz, dblFromSurvey, dblToSurvey, intDealStatus,
                intCellOrder, 0, freestsus, 0, intParentStatus, objunitTypeBiz, objBranchbiz, objSalesManbiz,null,null,false,
                DateTime.Now,DateTime.Now,intDelegateStatus,intSoldStatus,(int)btContractingTransactionStatus,
                (int)btDeliveryTransactionStatus, intCancelationTransactionStatus, intReservationChangedStatus, dblStartReservationValue, 
                dblEndReservationValue, dblStartDueValue, dblEndDueValue, objInstallmentTypeCol,dblStartPaidValue,
                dblEndPaidValue, intIsReservedStatus, new CampaignBiz(), intHasInstallmentStatus, new ResubmissionTypeCol(true), new CancelationTypeBiz(), 0
                ,false,DateTime.Now,DateTime.Now,0, new BrandCol(true)
                , new ProjectCol(true),new TowerCol(true));
            GetSearchData(ref objReservationDb);
            objReservationDb.AccountStatus = btAccountStatus;
            objReservationDb.LeafAccountStatus = btLeafAccountStatus;
            objReservationDb.ContractingTransactionStatus = btContractingTransactionStatus;
            objReservationDb.DeliveryTransactionStatus = btDeliveryTransactionStatus;
            DataTable dtTemp = objReservationDb.Search();
            _ResultCount = objReservationDb.ResultCount;
            _ResultValue = objReservationDb.ResultValue;
            _ResultDiscountValue = objReservationDb.ResultDiscountValue;
            string strAccountIDs = "";
            string strAccount = "";
            DataRow[] arrDr = dtTemp.Select("", "ReservationGLAccount");
            ReservationBiz ObjBiz;
            foreach (DataRow objDr in arrDr)
            {
                if (strAccount != objDr["ReservationGLAccount"].ToString())
                {
                    strAccount = objDr["ReservationGLAccount"].ToString();
                    if (strAccountIDs != "")
                        strAccountIDs += ",";
                    strAccountIDs += strAccount;
                }

            }
            AccountDb objAccountDb = new AccountDb();
            objAccountDb.IDsStr = strAccountIDs;
            DataTable dtAccount = objAccountDb.Search();
            DataRow[] arrAccount;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                ObjBiz = new ReservationBiz(objDr);
                if (ObjBiz.Status == ReservationStatus.Cancellation)
                    ObjBiz = new ReservationCanceledBiz(objDr);
                arrAccount = dtAccount.Select("AccountID=" + ObjBiz.AccountID);
                if (arrAccount.Length > 0)
                    ObjBiz.AccountBiz = new AccountBiz(arrAccount[0]);
                this.Add(ObjBiz);
            }
            if (Count > 0)
            {
                arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public ReservationCol(string strStatus,int intReservationID,int intCustomerID,int intProjectID,string strUnit)
        {

        }

        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();

                }
                return Returned;
            }
        }
        public string CanceledIDsStr
        {
            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (!objBiz.IsCanceled)
                        continue;
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
        public double ResultDiscountValue
        {
            get
            {
                return _ResultDiscountValue;
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

        public double TotalUnitPrice
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.VirtualTotalvalue;
                }
                return Returned;
            }
        }  //  «·√’·Ì «Ã„«·Ì ”⁄— «·ÊÕœ…

        public double RealTotalPrice
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.VirtualRealTotalValue;
                }
                return Returned;
            }
        } // «·«’·Ì «Ã„«·Ì ”⁄— «·ÊÕœÂ «·’«›Ì

        public double TotalBonusValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.BonusValue;//objBiz.BonusCol.TotalValue;
                }
                return Returned;
            }
        }  // «Ã„«·Ì «·„»«·€ «·«÷«›Ì…
        public double TotalDiscountValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.DiscountValue;//objBiz.DiscountCol.TotalValue;
                }
               // return TotalDiscountValue;
                return Returned;
            }
        }  // «Ã„«·Ì «·Œ’Ê„« 
        public double TotalPaidValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.TotalPaidValue;//objBiz.VirtualTotalPaidValue;
                }
                return Returned;
            }
        }  // «Ã„«·Ì «·„”œœ
        public double TotalInstallmentPaidValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.InstallmentPaidValue;
                }
                return Returned;
            }
        }  //«Ã„«·Ì «·„”œœ „‰ «·«ﬁ”«ÿ  
        public double TotalRemainingValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.RemainingValue;
                }
                return Returned;
            }
        }  // «Ã„«·Ì «·„” Õﬁ
        public double TotalDeservedValue  // «·„” Õﬁ
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = TotalUnitPrice - (TotalInstallmentPaidValue + TotalPaidValue + TotalBonusValue);
                }
                return Returned;
            }
        }
        public double TotalMulctValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned = Returned + objBiz.MulctPaymentValue; //objBiz.MulctPaymentCol.TotalValue;
                }
                return Returned;
            }
        }  // «Ã„«·Ì «·€—«„« 

        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public ReservationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (ReservationBiz)List[intIndex];
            }
        }
        public ReservationBiz this[string strID]
        {
            
            get
            {
                ReservationBiz REturned = new ReservationBiz();
                if (_ReservationIndexHash[strID] != null)
                    REturned = this[(int)_ReservationIndexHash[strID]];
                return REturned;
            }
        }
        public string UnitFullName
        {

            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitFullName;
                }
                return Returned;
            }
        }
        public string UnitName
        {

            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.UnitName;
                }
                return Returned;
            }
        }
        public string UnitTowerName
        {
            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitTowerName;
                }
                return Returned;
            }
        }
        public string UnitProjectName
        {
            get
            {
                string Returned = "";
                foreach (ReservationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitProjectName;
                }
             
                return Returned;
            }
        }
        public UnitCol UnitCol
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                foreach (ReservationBiz objBiz in this)
                {
                    foreach (ReservationUnitBiz objUnitBiz in objBiz.UnitCol)
                    {
                        Returned.Add(objUnitBiz.UnitBiz);
                    }
                }
                return Returned;
            }
        }
        public CustomerCol CustomerCol
        {
            get
            {
                Hashtable hsTemp = new Hashtable();
                CustomerCol Returned = new CustomerCol(true);

                foreach (ReservationBiz objReservationBiz in this)
                {
                    foreach (CustomerBiz objCustomerBiz in objReservationBiz.CustomerCol)
                    {
                        if (hsTemp[objCustomerBiz.ID.ToString()] == null)
                            hsTemp.Add(objCustomerBiz.ID.ToString(), objCustomerBiz);

                    }
 
                }
                
                foreach(object objKey in hsTemp.Keys)
                {
                    Returned.Add((CustomerBiz)hsTemp[objKey]);
                }
                return Returned;
            }
        }
        public TransactionCol  TransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                TransactionBiz objTransactionBiz;
                foreach (ReservationBiz objBiz in this)
                {
                    objTransactionBiz = objBiz.ContractingTransactionBiz.Copy();
                    objTransactionBiz.OtherModuleSrcIDs.Add(objBiz.ID.ToString());
                    objTransactionBiz.ElementCol.Add(objBiz.DeliveryTransactionBiz.ElementCol);
                    objTransactionBiz.ElementCol.Add(objBiz.CancelationTransactionBiz.ElementCol);
                    
                    objTransactionBiz.SetTransactionData();
                    if (objTransactionBiz.ElementCol.Count == 0)
                        continue;
                    Returned.Add(objTransactionBiz);
                }
                return Returned;
            }

        }
        public TransactionCol MulctTransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                TransactionBiz objTransactionBiz;
                foreach (ReservationBiz objBiz in this)
                {
                    objTransactionBiz = objBiz.InstallmentMulctTransactionBiz;
                    //objTransactionBiz.ElementCol.Add(objBiz.DeliveryTransactionBiz.ElementCol);
                    //objTransactionBiz.ElementCol.Add(objBiz.CancelationTransactionBiz.ElementCol);

                    objTransactionBiz.SetTransactionData();
                    if (objTransactionBiz.ElementCol.Count == 0)
                        continue;
                    Returned.Add(objTransactionBiz);
                }
                return Returned;
            }

        }
        public TransactionCol DiscountTransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                TransactionBiz objTransactionBiz;
                foreach (ReservationBiz objBiz in this)
                {
                    objTransactionBiz = objBiz.InstallmentDiscountTransactionBiz;
                    //objTransactionBiz.ElementCol.Add(objBiz.DeliveryTransactionBiz.ElementCol);
                    //objTransactionBiz.ElementCol.Add(objBiz.CancelationTransactionBiz.ElementCol);

                    objTransactionBiz.SetTransactionData();
                    if (objTransactionBiz.ElementCol.Count == 0)
                        continue;
                    Returned.Add(objTransactionBiz);
                }
                return Returned;
            }

        }
        #endregion
        #region Private Method
        void SetDataInitially(string strStatus, string strNote, bool blReservationDateRange,
            DateTime dtReservationStartDate, DateTime dtReservationEndDate,
          bool blContractDateRange, DateTime dtContractStartDate, DateTime dtContractEndDate
            , string strCustomerName, JobBiz objJobBiz, CountryBiz objCountryBiz,
            string strUnitCode, CellBiz objCellbiz, double dblFromSurvey, double dblToSurvey, int intDealStatus, int intCellOrder,
            int intAttachmentStatus, int FreeStatus, int intNewStatus, int intParentStatus, UnitTypeBiz objUnittypebiz, 
            BranchBiz objBranchbiz,SalesManBiz objSalesManbiz,BranchCol objBranchCol,SalesManCol objSalesCol,bool blStatusDateRange,DateTime dtStatusStartDate,
            DateTime dtStatusEndDate,int intDelegateStatus,int intSoldStatus,int intContractingTransactionStatus,
            int intDeliveryTransactionStatus,int intCancelationTransactionStatus,int intReservationChangedStatus,
            double dblStartReservationValue,double dblEndReservationValue,double dblStartDueValue,
            double dblEndDueValue,InstallmentTypeCol objInstallmentTypeCol,
            double dblStartPaidValue,double dblEndPaidValue,int intIsReservedStatus,
            CampaignBiz objCampaignBiz,int intHasInstallmentStatus,
            ResubmissionTypeCol objResubmissionTypeCol,CancelationTypeBiz objCancelationType,int intPayBackCompleteStatus
             , bool blResubmissionDateRange,
            DateTime dtResubmissionStart,
            DateTime dtResubmissionEnd
            , int intTenancyStatus, BrandCol objBrandCol, ProjectCol objProjectCol, TowerCol objTowerCol)
        {
            if (objBranchbiz == null)
                objBranchbiz = new BranchBiz();
            if (objResubmissionTypeCol == null)
                objResubmissionTypeCol = new ResubmissionTypeCol(true);
            if (objCancelationType == null)
                objCancelationType = new CancelationTypeBiz();
            _AttachmentStatus = intAttachmentStatus;
            _StatusStr = strStatus;
            _CustomerName = strCustomerName;
            if (objCountryBiz == null)
                objCountryBiz = new CountryBiz();

            _NationalityID = objCountryBiz.ID;
            if (objJobBiz == null)
                objJobBiz = new JobBiz();
            _JobID = objJobBiz.ID;
             
            _BranchID = objBranchbiz.ID;
            _ResubmissionIDs = objResubmissionTypeCol.IDs;
            _ResubmissionDateRange = blResubmissionDateRange;
            _ResubmissionStart = dtResubmissionStart;
            _ResubmissionEnd = dtResubmissionEnd; 
            _CancelationType = objCancelationType.ID;
            if (objSalesManbiz == null)
                objSalesManbiz = new SalesManBiz();
            _SalesManID = objSalesManbiz.ID;
            _UnitCode = strUnitCode;
           _ToSurvey = dblToSurvey;
           if (objUnittypebiz == null)
               objUnittypebiz = new UnitTypeBiz();
           _UnitTypeID = objUnittypebiz.ID;
           _FreeStatus = FreeStatus;
           _NewStatus = intNewStatus;
           _ParentStatus = intParentStatus;
           _FromSurvey = dblFromSurvey;
        
            if (objCellbiz.ID != 0)
            {
                if (objCellbiz.ParentID == objCellbiz.ID)
                {
                    _CellFamilyID = objCellbiz.ID;
                    _FloorOrder = intCellOrder;
                }
                else
                    _CellIDs = objCellbiz.GetTypedChildren(7, intCellOrder).IDsStr;
            }
            _ContractingDateRange = blContractDateRange;
            _ContractingStartDate = dtContractStartDate;
            _ContractingEndDate = dtContractEndDate;
            _ReservationDateRange = blReservationDateRange;
           _ReservationStartDate = dtReservationStartDate;
            _ReservationEndDate = dtReservationEndDate;
          _DealStatus = intDealStatus;
          _Note = strNote;
          _ReservationStatusRange = blStatusDateRange;
          _StatusEndDate = dtStatusEndDate;
          _StatusStartDate = dtStatusStartDate;
          _DelegationStatus = intDelegateStatus;
          _SoldStatus = intSoldStatus;
          _ContractingTransactionStatus = intContractingTransactionStatus;
          _DeliveryTransactionStatus = intDeliveryTransactionStatus;
          _CancelationTransactionStatus = intCancelationTransactionStatus;
          _ReservationChangedStatus = intReservationChangedStatus;
          if (objInstallmentTypeCol == null)
              objInstallmentTypeCol = new InstallmentTypeCol(true);
          _InstallmentTypeIDs = objInstallmentTypeCol.IDsStr;
          _StartReservationValue = dblStartReservationValue;
          _EndReservationValue = dblEndReservationValue;
          _StartDueValue = dblStartDueValue;
          _EndDueValue = dblEndDueValue;
          _StartPaidValue = dblStartPaidValue;
          _EndPaidValue = dblEndPaidValue;
          _IsReservedStatus = intIsReservedStatus;
          _HasInstallmentStatus = intHasInstallmentStatus;
          if (_CampaignBiz == null)
              _CampaignBiz = new CampaignBiz();
          _CampaignBiz = objCampaignBiz;
          _PayBackCompleteStatus = intPayBackCompleteStatus;
          if (objBranchCol == null)
              objBranchCol = new BranchCol(true,0);
          if (objSalesCol == null)
              objSalesCol = new SalesManCol(true);
          _BranchIDs = objBranchCol.IDs;
          _SalesManIDs = objSalesCol.ApplicantIDs;
            _TenancyStatus = intTenancyStatus;
            if (objBrandCol == null)
                objBrandCol = new BrandCol(true);
            if (objProjectCol == null)
                objProjectCol = new ProjectCol(true);
            if (objTowerCol == null)
                objTowerCol = new TowerCol(true);
            _TowerCol = objTowerCol;
            _ProjectCol = objProjectCol;
            _BrandCol = objBrandCol;

        }
        void GetSearchData(ref ReservationDb objReservationDb)
        {
            objReservationDb.StatusStr = _StatusStr;
            objReservationDb.AttachmentStatus = _AttachmentStatus;
            objReservationDb.CustomerName = _CustomerName;
            objReservationDb.NationalityID = _NationalityID;
            objReservationDb.JobID = _JobID;
            objReservationDb.UnitCode = _UnitCode;
            objReservationDb.ToSurvey = _ToSurvey;
            objReservationDb.FromSurvey = _FromSurvey;
            objReservationDb.AttachmentStatus = _AttachmentStatus;
            objReservationDb.CellFamilyID = _CellFamilyID;
            objReservationDb.FloorOrder = _FloorOrder;
            objReservationDb.ParentStatus = _ParentStatus;
            objReservationDb.CellIDs = _CellIDs;
            objReservationDb.UnitTypeID = _UnitTypeID;
            objReservationDb.ContractingDateRange = _ContractingDateRange;
            objReservationDb.ContractingStartDate = _ContractingStartDate;
            objReservationDb.ContractingEndDate = _ContractingEndDate;
            objReservationDb.ReservationDateRange = _ReservationDateRange;
            objReservationDb.ReservationStartDate = _ReservationStartDate;
            objReservationDb.ReservationEndDate = _ReservationEndDate;
            objReservationDb.DealStatus = _DealStatus;
            objReservationDb.Note = _Note;
            objReservationDb.FreeStatus = _FreeStatus;
            objReservationDb.NewStatus = _NewStatus;
            objReservationDb.BranchID = _BranchID;
            objReservationDb.ResubmissionIDs = _ResubmissionIDs;
            objReservationDb.ResubmissionDateRange = _ResubmissionDateRange;
            objReservationDb.ResubmissionStartDate = _ResubmissionStart;
            objReservationDb.ResubmissionEndDate = _ResubmissionEnd;
            objReservationDb.CancelationType = _CancelationType;
            objReservationDb.SalesManID = _SalesManID;
            objReservationDb.BranchIDs = _BranchIDs;
            objReservationDb.SalesMenIDs = _SalesManIDs;
            objReservationDb.StatusDateRange = _ReservationStatusRange;
            objReservationDb.StatusEndDate=_StatusEndDate ;
            objReservationDb.StatusStartDate= _StatusStartDate ;
            objReservationDb.DelegateStatus = _DelegationStatus;
            objReservationDb.SoldStatus = _SoldStatus;
            objReservationDb.ContractingTransactionStatus = (byte)_ContractingTransactionStatus;
            objReservationDb.DeliveryTransactionStatus = (byte)_DeliveryTransactionStatus;
            objReservationDb.CancelationTransactionStatus = _CancelationTransactionStatus;
            objReservationDb.ReservationChangedStatus = _ReservationChangedStatus;
            objReservationDb.StartReservationValue = _StartReservationValue;
            objReservationDb.EndReservationValue = _EndReservationValue;
            objReservationDb.StartDueValue = _StartDueValue;
            objReservationDb.EndDueValue = _EndDueValue;
            objReservationDb.InstallmentTypeIDs = _InstallmentTypeIDs;
            objReservationDb.StartPaidValue = _StartPaidValue;
            objReservationDb.EndPaidValue = _EndPaidValue;
            objReservationDb.IsReservedStatus = _IsReservedStatus;
            objReservationDb.HasInstallmentStatus = _HasInstallmentStatus;
            objReservationDb.PaybackCompleteStatus = _PayBackCompleteStatus;
            if (_CampaignBiz == null)
                _CampaignBiz = new CampaignBiz();
            objReservationDb.CampaignID = _CampaignBiz.ID;
            objReservationDb.BrandIDs = _BrandCol.IDsStr;
            objReservationDb.ProjectIDs = _ProjectCol.IDsStr;
            objReservationDb.TowerIDs = _TowerCol.IDsStr;
            objReservationDb.TenancyStatus = _TenancyStatus;
        }
        internal static DataTable GetTransactionEmbtyTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TransactionID"), 
                new DataColumn("TransactionDate") ,new DataColumn("TransactionCode"),
                new DataColumn("TransactionType"),new DataColumn("TransactionValue"),new DataColumn("TransactionCurrency"),new DataColumn("TransactionCurrencyValue"),
            new DataColumn("TransactionDesc"),new DataColumn("TransactionStatus"),new DataColumn("CurrentReservation"),
            new DataColumn("FromAccountID"),new DataColumn("ToAccountID"),
                new DataColumn("PaymentID"),new DataColumn("DiscountID"),new DataColumn("InstallmentID")});

            return Returned;
        }
        DataTable GetReservationTransactionTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ReservationID"), new DataColumn("TransactionID"),
                new DataColumn("UnitStr"),new DataColumn("TowerStr"),new DataColumn("ProjectStr"),
                new DataColumn("ReservationStatus") ,new DataColumn("TotalValue")});
            DataRow objDr;
            foreach (ReservationBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ReservationID"] = objBiz.ID;
                objDr["TransactionID"] = 0;
                objDr["UnitStr"] = objBiz.UnitStr;
                //objDr["TowerStr"] = objBiz.
                objDr["ProjectStr"] = objBiz.ProjectFullName;
                objDr["ReservationStatus"] =(int) objBiz.Status;
                objDr["TotalValue"] = objBiz.VirtualTotalvalue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
        #region Public Method

        public void Add(ReservationBiz objBiz)
        {
            //if(GetIndex(objBiz)== -1)
            if (objBiz.ID != 0)
            {
                if (_ReservationIndexHash[objBiz.ID.ToString()]!=null)
                {
                    return;
                }
            }
            _ReservationIndexHash.Add(objBiz.ID.ToString(), Count);
            List.Add(objBiz);
            _IsSet = false;
 
        }
        public void Add(ReservationCol objCol)
        {
            foreach (ReservationBiz objBiz in objCol)
                Add(objBiz);
        }
        public int GetIndex(ReservationBiz objBiz)
        {
           // int intIndex = 0;
            if (_ReservationIndexHash[objBiz.ID.ToString()] != null)
                return (int)_ReservationIndexHash[objBiz.ID.ToString()];
            return -1;
        }
        public void MoveNext()
        {
          
            Clear();
            ReservationDb objReservationDb = new ReservationDb();
            GetSearchData(ref objReservationDb);
            objReservationDb.MaxID = _MaxID;
            objReservationDb.MinID = 0;
            DataTable dtTemp = objReservationDb.Search();

            #region UserData
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "UsrIns", 200);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;

            }
            arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", 200);
            //string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion

            DataRow[] arrUsr;
            ReservationBiz ObjReservationBiz;
            //ReservationBiz objReservationBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new ReservationBiz(objDr));
                ObjReservationBiz = new ReservationBiz(objDr);
                objReservationDb = new ReservationDb(objDr);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserIns);
                if (arrUsr.Length > 0)
                    ObjReservationBiz.UserIns = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserUpd);
                if (arrUsr.Length > 0)
                    ObjReservationBiz.UserUpd = new UserBiz(arrUsr[0]);
                //objReservationBiz = new ReservationBiz(objDr);
                this.Add(ObjReservationBiz);
            }
            int intCount = dtTemp.Rows.Count;
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (intCount == _MaxCount)
            {
                _EnableNext = true;
            }
            else if(intCount<_MaxCount)
                _EnableNext = false;
            

        }
        public void MovePrevious()
        {

         
            Clear();
            ReservationDb objReservationDb = new ReservationDb();
            GetSearchData(ref objReservationDb);
            objReservationDb.MinID = _MinID;
            DataTable dtTemp = objReservationDb.Search();

            #region UserData
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "UsrIns", 200);
            string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            arrStr = SysUtility.GetStringArr(dtTemp, "UsrUpd", 200);
            //string strUsrIDs = "";
            foreach (string strID in arrStr)
            {
                if (strUsrIDs != "")
                    strUsrIDs += ",";
                strUsrIDs += strID;
            }
            UserDb objUserDb = new UserDb();
            objUserDb.IDs = strUsrIDs;
            DataTable dtUserTemp = objUserDb.Search();
            #endregion
            DataRow[] arrUsr;
            ReservationBiz ObjReservationBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new ReservationBiz(objDr));
                ObjReservationBiz = new ReservationBiz(objDr);
                objReservationDb = new ReservationDb(objDr);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserIns);
                if (arrUsr.Length > 0)
                    ObjReservationBiz.UserIns = new UserBiz(arrUsr[0]);
                arrUsr = dtUserTemp.Select("UserID=" + objReservationDb.UserUpd);
                if (arrUsr.Length > 0)
                    ObjReservationBiz.UserUpd = new UserBiz(arrUsr[0]);
                this.Add(ObjReservationBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "ReservationID");
                objReservationDb = new ReservationDb(arrDr[Count - 1]);
                _MaxID = objReservationDb.ID;
                objReservationDb = new ReservationDb(arrDr[0]);
                _MinID = objReservationDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }
           
        

        }
        public void CreateLeafAccout()
        {
            foreach (ReservationBiz objBiz in this)
            {
                objBiz.CreateLeafAccount();
            }
 
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("Reservation");
            dtReturned.Columns.AddRange(new DataColumn[] {
                new DataColumn("ReservationID"), new DataColumn("ReservationUnitID"), new DataColumn("ReservationStatus"),new DataColumn("ReservationValue") ,
                new DataColumn("ReservationDate"), new DataColumn("ReservationContributionValue"), new DataColumn("ReservationContributionPerc"), 
                new DataColumn("ReservationUnitPrice"), new DataColumn("ReservationCachePrice"), new DataColumn("ReservationFinishing") ,
                new DataColumn("ReservationProfitIsCompound"), new DataColumn("ReservationProfitValue"), new DataColumn("ReservationProfitPeriod"),
                new DataColumn("ReservationPeriodAmount"), new DataColumn("ReservationPeriod"), new DataColumn("ReservationProfitPeriodAmount") ,
                new DataColumn("ReservationAllowance"), new DataColumn("ReservationNote"), new DataColumn("ReservationContractingDate"), 
                new DataColumn("ReservationDeliveryDate"), new DataColumn("ReservationRealDeliveryDate")});
            DataRow objDr;
            foreach (ReservationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ReservationID"] = objBiz.ID;
                //objDr["ReservationUnitID"] = objBiz.UnitBiz.ID;
                objDr["ReservationStatus"] = objBiz.Status;
                objDr["ReservationValue"] = objBiz.Value;
                objDr["ReservationDate"] = objBiz.Date;
                objDr["ReservationContributionValue"] = objBiz.ContributionValue;
                objDr["ReservationContributionPerc"] = objBiz.ContributionPerc;
                objDr["ReservationUnitPrice"] = objBiz.UnitPrice;
                objDr["ReservationCachePrice"] = objBiz.CachePrice;
                objDr["ReservationFinishing"] =(int) objBiz.Finishing;
                objDr["ReservationProfitIsCompound"] = objBiz.ProfitIsCompound;
                objDr["ReservationProfitValue"] = objBiz.ProfitValue;
                objDr["ReservationProfitPeriod"] = (int)objBiz.ProfitPeriod;
                objDr["ReservationPeriodAmount"] = objBiz.ProfitPeriodAmount;
                objDr["ReservationPeriod"] =(int) objBiz.Period;
                objDr["ReservationProfitPeriodAmount"] = objBiz.ProfitPeriodAmount;
                objDr["ReservationAllowance"] = objBiz.Allowance;
                objDr["ReservationNote"] = objBiz.Note;
                objDr["ReservationContractingDate"] = objBiz.ContractingDate;
                objDr["ReservationDeliveryDate"] = objBiz.DeliveryDate;
                objDr["ReservationRealDeliveryDate"] = objBiz.RealDeliveryDate;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }



        public DataTable GetTableContacted(int intCampaignID)
        {
            DataTable dtReturned = new DataTable("Reservation");
         
            dtReturned.Columns.AddRange(
                new DataColumn[] {
                    new DataColumn("ReservationID"),
                    new DataColumn("ProjectName"),new DataColumn("Tower"),new DataColumn("Floor"), new DataColumn("ReservationUnitCode"),new DataColumn("ReservationValue") ,
                new DataColumn("ReservationDate"),new DataColumn("ReservationUnitPrice"),new DataColumn("UnitPrice"), new DataColumn("ReservationCachePrice"),
                new DataColumn("ReservationPeriodAmount"), new DataColumn("ReservationPeriod"), new DataColumn("ReservationContractingDate"), 
                new DataColumn("ReservationDeliveryDate"), new DataColumn("ReservationRealDeliveryDate"), new DataColumn("UnitServey")
                ,new DataColumn("TotalPaidValue"),new DataColumn("LastPaymentDate")
                ,new DataColumn("DeservedValue"),new DataColumn("RemainingValue"),new DataColumn("FirstDeservedInstallment"),new DataColumn("DeliveryInstallment")
                ,new DataColumn("DeliveryInstallmentDate"),new DataColumn("TowerDeliveryDate")
                ,new DataColumn("CustomerName"), new DataColumn("CustomerNationality"), new DataColumn("CustomerHomePhone"),
                new DataColumn("CustomerWorkPhone"), new DataColumn("CustomerFirstMobile"), new DataColumn("CustomerSecondMobile"),
                new DataColumn("CustomerHomeAddress"), new DataColumn("CustomerPasport"),
                new DataColumn("CustomerEmail"),new DataColumn("ReservationStatus"),
                new DataColumn("SalesMan"),new DataColumn("Branch"),new DataColumn("HomeCountry"),
                new DataColumn("HomeCity"),new DataColumn("HomeRegion"),new DataColumn("WorkCountry"),new DataColumn("WorkCity")
                ,new DataColumn("WorkRegion"),new DataColumn("CustomerWorkAddress")});


            if (intCampaignID > 0)
            {
                dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("LastContactDate") ,new DataColumn("LastEmployeeName")
                    ,new DataColumn("LastContactStatus"),new DataColumn("LastContactComment") });
            }

            DataRow objDr;
            foreach (ReservationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ReservationID"] = objBiz.ID;
                objDr["ProjectName"] = objBiz.DisplayedProjectName;
                objDr["Tower"] = objBiz.DisplayedTowerName;
                objDr["Floor"] = objBiz.DirectFloorBiz.Name;
                objDr["ReservationUnitCode"] = objBiz.DisplayedUnitCode;
                objDr["ReservationValue"] = objBiz.Value;
                objDr["ReservationDate"] = objBiz.Date.ToString("yyyy-MM-dd");
                objDr["ReservationUnitPrice"] = objBiz.UnitPrice;
                objDr["UnitPrice"] = objBiz.NativeUnitPrice;
                objDr["ReservationCachePrice"] = objBiz.CachePrice;
                objDr["ReservationPeriodAmount"] = objBiz.ProfitPeriodAmount;
                objDr["ReservationPeriod"] = (int)objBiz.Period;
                objDr["ReservationContractingDate"] = objBiz.ContractingDate.ToString("yyyy-MM-dd");
                if (objBiz.DeliveryDate == null)
                    objDr["ReservationDeliveryDate"] = "";
                else
                    objDr["ReservationDeliveryDate"] = objBiz.DeliveryDate.ToString("yyyy-MM-dd");
                objDr["ReservationRealDeliveryDate"] = objBiz.IsDelivered ? objBiz.RealDeliveryDate.ToString("yyyy-MM-dd") : "";
                objDr["DeservedValue"] = objBiz.VirtualDeservedValue;

                objDr["RemainingValue"] = objBiz.LinearInstallmentCol.RemainingValue;
                objDr["TotalPaidValue"] = objBiz.TotalPaidValue;
               objDr["LastPaymentDate"] = objBiz.LinearInstallmentCol.MaxPaidInstallment.ID == 0 ?
                   objBiz.PaymentCol.LastPaymentBiz.DateStr : (objBiz.LinearInstallmentCol.MaxPaidInstallment.PaymentDate > objBiz.PaymentCol.LastPaymentBiz.Date ? objBiz.LinearInstallmentCol.MaxPaidInstallment.PaymentDate.ToString("yyyy-MM-dd") : objBiz.PaymentCol.LastPaymentBiz.DateStr);
                objDr["FirstDeservedInstallment"] =
                   objBiz.LinearInstallmentCol.Count==0 ||  objBiz.LinearInstallmentCol[0].Type.MainType == InstallmentMainType.DeliveryPayment ||  objBiz.LinearInstallmentCol[0].InstallmentStatus == InstallmentStatus.Paid  ? "" : objBiz.LinearInstallmentCol[0].DueDateStr;
                objDr["DeliveryInstallment"] = objBiz.LinearInstallmentCol.DeliveryInstallment.InstallmentValue;
                objDr["DeliveryInstallmentDate"] = objBiz.LinearInstallmentCol.DeliveryInstallment.DueDateStr;
                objDr["TowerDeliveryDate"] = objBiz.DirectTowerBiz.IsDelivered ? objBiz.DirectTowerBiz.DeliverDate.ToString("yyyy-MM-dd") : "";
                objDr["UnitServey"] = objBiz.UnitSurveyStr;
                objDr["CustomerName"] = objBiz.DirectCustomerStr;
                objDr["CustomerNationality"] = objBiz.CustomerBiz.CountryBiz.Nationality;//.CustomerNationalityStr;
                objDr["CustomerWorkPhone"] = objBiz.CustomerBiz.WorkPhone;//.CustomerWorkPhone;
                objDr["CustomerHomePhone"] = objBiz.CustomerBiz.HomePhone;//.CustomerHomePhone;
                objDr["CustomerFirstMobile"] = objBiz.CustomerBiz.Mobile;//.CustomerFirstMobile;
                objDr["CustomerSecondMobile"] = objBiz.CustomerBiz.SecondMobile;//CustomerSecondMobile;

                objDr["HomeCountry"] = objBiz.CustomerBiz.HomeCountryName;//.CustomerHomeCuntry;
                objDr["HomeCity"] = objBiz.CustomerBiz.HomeCityName;//.CustomerHomeCity;
                objDr["HomeRegion"] = objBiz.CustomerBiz.HomeRegionName;
                objDr["WorkCountry"] = objBiz.CustomerBiz.WorkCountryName;//.CustomerWorkCuntry;
                objDr["WorkCity"] = objBiz.CustomerBiz.WorkCityName;//.CustomerWorkCity;
                objDr["WorkRegion"] = objBiz.CustomerBiz.WorkRegionName;//.CustomerWorkRegion;
                objDr["CustomerWorkAddress"] = objBiz.CustomerBiz.WorkAddress;//CustomerWorkAddress;

                objDr["CustomerHomeAddress"] = objBiz.CustomerBiz.Address;//.CustomerHomeAddress;
                objDr["CustomerPasport"] = objBiz.CustomerBiz.IDTypeInstantBiz.IDValue;
                objDr["CustomerEmail"] = objBiz.CustomerBiz.MailAddress;
                try
                {
                    objDr["Branch"] = objBiz.BranchBiz.Name;
                    objDr["SalesMan"] = objBiz.DirectSalesStr;
                }
                catch
                { 
                }

                objDr["ReservationStatus"] = objBiz.StatusStr;
            if(intCampaignID>0)
                {
                    objDr["LastContactDate"] = objBiz.CampaignCustomerBiz.ContactDate.ToString("yyyy-MM-dd");
                    objDr["LastEmployeeName"] = objBiz.CampaignCustomerBiz.LastContactEmployeeBiz.Name;
                    objDr["LastContactStatus"] = CampaignCustomerContactBiz.StatusLst[objBiz.CampaignCustomerBiz.ContactStatus];
                    objDr["LastContactComment"] = objBiz.CampaignCustomerBiz.ContactComment;


                }
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public DataTable GetTableReservationInstallmentContacted()
        {
            DataTable dtReturned = new DataTable("Reservation");
           
            dtReturned.Columns.AddRange(new DataColumn[] {
                new DataColumn("ProjectName"), new DataColumn("ReservationUnitCode"),new DataColumn("ReservationValue") ,
                 new DataColumn("CustomerName"),new DataColumn("CustomerHomePhone"),
                 new DataColumn("CustomerFirstMobile")
                ,new DataColumn("DeservedValue")});
            DataRow objDr;
            foreach (ReservationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ProjectName"] = objBiz.ProjectName;
                objDr["ReservationUnitCode"] = objBiz.UnitCodeStr;
                objDr["ReservationValue"] = objBiz.Value;
                objDr["CustomerName"] = objBiz.CustomerStr;
                
                
                objDr["CustomerHomePhone"] = objBiz.CustomerHomePhone;
                objDr["CustomerFirstMobile"] = objBiz.CustomerFirstMobile;
               
               
                objDr["DeservedValue"] = objBiz.VirtualDeservedValue;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public DataTable GetContractingTransactionTable()
        {
            DataTable Returned = GetTransactionEmbtyTable();
            if (ReservationBiz.UnitCreditorAccountBiz.ID != 0)
            {
                DataRow objDr;
                foreach (ReservationBiz objBiz in this)
                {
                    objDr = Returned.NewRow();
                    objDr["TransactionID"] = objBiz.ContractingTransactionBiz.ID;
                    objDr["TransactionDate"] = objBiz.ContractingTransactionBiz.Date;
                    objDr["TransactionCode"] = objBiz.ContractingTransactionBiz.Code;
                    objDr["TransactionType"] = objBiz.ContractingTransactionBiz.TypeBiz.ID;
                    objDr["TransactionValue"] = objBiz.ContractingTransactionBiz.Value;
                    objDr["TransactionCurrency"] = objBiz.ContractingTransactionBiz.CurrencyBiz.ID;
                    objDr["TransactionCurrencyValue"] = objBiz.ContractingTransactionBiz.CurrencyBiz.Value;
                    objDr["TransactionDesc"] = objBiz.ContractingTransactionBiz.Desc;
                    objDr["TransactionStatus"] = objBiz.ContractingTransactionBiz.Status;
                    objDr["CurrentReservation"] = objBiz.ContractingTransactionBiz.ReservationID;
                    objDr["FromAccountID"] = objBiz.ContractingTransactionBiz.AccountFromBiz.ID;
                    objDr["ToAccountID"] = objBiz.ContractingTransactionBiz.AccountToBiz.ID;
                    Returned.Rows.Add(objDr);

                }
            }
            return Returned;
        }
        public DataTable GetDeliveryTransactionTable()
        {
            DataTable Returned = GetTransactionEmbtyTable();
            if (ReservationBiz.SalesAccountBiz.ID != 0)
            {
                DataRow objDr;
                foreach (ReservationBiz objBiz in this)
                {
                    objDr = Returned.NewRow();
                    objDr["TransactionID"] = objBiz.DeliveryTransactionBiz.ID;
                    objDr["TransactionDate"] = objBiz.DeliveryTransactionBiz.Date;
                    objDr["TransactionCode"] = objBiz.DeliveryTransactionBiz.Code;
                    objDr["TransactionType"] = objBiz.DeliveryTransactionBiz.TypeBiz.ID;
                    objDr["TransactionValue"] = objBiz.DeliveryTransactionBiz.Value;
                    objDr["TransactionCurrency"] = objBiz.DeliveryTransactionBiz.CurrencyBiz.ID;
                    objDr["TransactionCurrencyValue"] = objBiz.DeliveryTransactionBiz.CurrencyBiz.Value;
                    objDr["TransactionDesc"] = objBiz.DeliveryTransactionBiz.Desc;
                    objDr["TransactionStatus"] = objBiz.DeliveryTransactionBiz.Status;
                    objDr["CurrentReservation"] = objBiz.DeliveryTransactionBiz.ReservationID;
                    objDr["FromAccountID"] = objBiz.DeliveryTransactionBiz.AccountFromBiz.ID;
                    objDr["ToAccountID"] = objBiz.DeliveryTransactionBiz.AccountToBiz.ID;
                    Returned.Rows.Add(objDr);

                }
            }
            return Returned;
        }
        public void SetFullReservation()
        {
            foreach (ReservationBiz objBiz in this)
            {
                objBiz.SetFullReservation();
            }
        }
        public void CreateContractingTransaction()
        {
            ReservationDb objDb = new ReservationDb();
            objDb.ReservationTransactionTable = GetReservationTransactionTable();
            objDb.ContractingTransactionTable = GetContractingTransactionTable();
            objDb.CreateContractingTransaction();
        }
        public void CreateDeliveryTransaction()
        {
            ReservationDb objDb = new ReservationDb();
            objDb.ReservationTransactionTable = GetReservationTransactionTable();
            objDb.DeliveryTransactionTable = GetDeliveryTransactionTable();
            objDb.CreateDeliveryTransaction();
        }
        public ReservationCol GetReservationColByCustomerName(string strName)
        {
            ReservationCol Returned = new ReservationCol(true);
            foreach (ReservationBiz objBiz in this)
            {
                if(SysUtility.ReplaceStringComp( objBiz.CustomerStr).IndexOf(SysUtility.ReplaceStringComp(strName))!= -1)
                  Returned.Add(objBiz);
            }
            return Returned;
        }
        public void SaveGLContractingTransaction()
        {
            DataTable dtTransaction, dtTransactionElement, dtNative;

            ReservationDb objDb = new ReservationDb();
            dtTransaction = TransactionCol.GetTable(out dtTransactionElement, out dtNative);
            objDb.TransactionTable = dtTransaction;
            objDb.TRansactionElementTable = dtTransactionElement;
            objDb.ReservationTransactionTable = dtNative;
            objDb.InsertTransaction();
            SaveGLDiscountTransaction();
            SaveGLMulctTransaction();
           

        }
        public void SaveGLMulctTransaction()
        {
            DataTable dtTransaction, dtTransactionElement, dtNative;
            if (MulctTransactionCol.Count == 0)
                return;
            ReservationDb objDb = new ReservationDb();
            dtTransaction = MulctTransactionCol.GetTable(out dtTransactionElement, out dtNative);
            objDb.TransactionTable = dtTransaction;
            objDb.TRansactionElementTable = dtTransactionElement;
            objDb.ReservationTransactionTable = dtNative;
            objDb.InsertMulctTransaction();
        }
        public void SaveGLDiscountTransaction()
        {
            if (DiscountTransactionCol.Count == 0)
                return;
            DataTable dtTransaction, dtTransactionElement, dtNative;

            ReservationDb objDb = new ReservationDb();
            dtTransaction = DiscountTransactionCol.GetTable(out dtTransactionElement, out dtNative);
            objDb.TransactionTable = dtTransaction;
            objDb.TRansactionElementTable = dtTransactionElement;
            objDb.ReservationTransactionTable = dtNative;
            objDb.InsertDiscountTransaction();
        }

        public void SetNonTransactionedMulctCol()
        {
            string strReservationIDs = IDsStr;
            InstallmentMulctDb objDb = new InstallmentMulctDb();
            objDb.ReservationIDs = strReservationIDs;
            objDb.GLTransactionStatus = 2;
            DataTable dtTemp = objDb.Search();
            DataRow [] arrDr;
            foreach (ReservationBiz objBiz in this)
            {
                objBiz.InstallmentMulctCol = new InstallmentMulctCol(true);
                arrDr = dtTemp.Select("ReservationID="+ objBiz.ID.ToString(), "");
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.InstallmentMulctCol.Add(new InstallmentMulctBiz(objDr));
                }

            }
        }
        public void SetNonTransactionDiscountCol()
        {
            string strReservationIDs = IDsStr;
            InstallmentDiscountDb objDb = new InstallmentDiscountDb();
            objDb.ReservationIDs = strReservationIDs;
            objDb.GLTransactionStatus = 2;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach (ReservationBiz objBiz in this)
            {
                objBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                arrDr = dtTemp.Select("ReservationID=" + objBiz.ID.ToString(), "");
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.InstallmentDiscountCol.Add(new InstallmentDiscountBiz(objDr));
                }

            }
        }
        public void SetData()
        {
            if (_IsSet)
                return;
           
            ReservationDb.ReservationIDs = IDsStr;
            
            ReservationDb.SetReservationCach();

            ReservationInstallmentCol objInstallmentCol;
           

            foreach (ReservationBiz objBiz in this)
            {
                if (!objBiz.IsSet)
                {
                    
                    objInstallmentCol = objBiz.LinearInstallmentCol;
                    objBiz.IsSet = true;
                }

            }
            UnitPeripheralDb.UnitPeripheralCacheTable = null;
            UnitCol objUnitCol = UnitCol;

            UnitPeripheralDb.UnitIDsCache = objUnitCol.IDsStr;
            DataRow[] arrDr;
            
            foreach (UnitBiz objUnitBiz in objUnitCol)
            {
                objUnitBiz.PeripheralCol = new UnitPeripheralCol(true);
                arrDr = UnitPeripheralDb.UnitPeripheralCacheTable.Select("PeriphiralUnit="+ objUnitBiz.ID.ToString());
                foreach (DataRow objDr in arrDr)
                {
                    objUnitBiz.PeripheralCol.Add(new UnitPeripheralBiz(objDr));
                }
            }
            SetPayBackCol();
            _IsSet = true;
           
        }
     
        public void SetReservationColPartialy1()
        {

            if (_IsSetParially)
                return;
            string strReservationIDs = IDsStr;
            ReservationDb.ReservationIDs = strReservationIDs;

            ReservationDb objDb = new ReservationDb();
            objDb.IDs = strReservationIDs;
            objDb.TopSelect = 60000;
            DataTable dtTemp = objDb.Search();
            ReservationCol Returned = new ReservationCol(true);
            DataRow[] arrDr;
            ReservationBiz objTemp = new ReservationBiz();
            ReservationBiz objBiz;
            for(int intIndex =0;intIndex < Count;intIndex++)
            {
                objBiz = this[intIndex];
                arrDr = dtTemp.Select("ReservationID=" + objBiz.ID.ToString());
                if (arrDr.Length > 0)
                {
                    objTemp = new ReservationBiz(arrDr[0]);
                    objTemp.LinearInstallmentCol = objBiz.LinearInstallmentCol;
                    this[intIndex] = objTemp;
                   
                }
            }
            _IsSetParially = true;


        }
        public void SetReservationColPartialy()
        {

            if (_IsSetParially)
                return;
            string strReservationIDs = IDsStr;
            ReservationDb objDb;
            DataTable dtTemp;
            ReservationCol Returned = new ReservationCol(true);
            DataRow[] arrDr;
            ReservationBiz objTemp = new ReservationBiz();
            ReservationBiz objBiz;


         

             objDb = new ReservationDb();
             int intIndex = 0;
             List<string> arrIDStr = SysUtility.GetStringArr(strReservationIDs, ',',10000);
             ReservationInstallmentCol objInstallmentCol;
             foreach (string strTempIDs in arrIDStr)
             {
                 ReservationDb.ReservationIDs = strTempIDs;
                 objDb.IDs = strTempIDs;
                 objDb.TopSelect = 20000;
                 dtTemp = objDb.Search();


                 objTemp = new ReservationBiz();
                 foreach (DataRow objDr in dtTemp.Rows)
                 {
                     objTemp = new ReservationBiz(objDr);
                     intIndex = GetIndex(objTemp);
                     if (intIndex == -1)
                         continue;
                    objBiz = this[intIndex];
                     //objInstallmentCol = objTemp.LinearInstallmentCol;
                    // objTemp.SetMainReservation();
                     objTemp.LinearInstallmentCol = objBiz.LinearInstallmentCol;
                     this[intIndex] = objTemp;
                    
                 }
             }
            _IsSetParially = true;


        }
        public void SetCampaignCustomerCol(CampaignBiz objCampaignBiz)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.Campaign = objCampaignBiz.ID;
            objDb.ReservationIDs = IDsStr;
            DataTable dtTemp = objDb.Search();
            CampaignCustomerBiz objCustomerBiz;
            Hashtable hsTemp = new Hashtable();
            int intReservationID;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objCustomerBiz = new CampaignCustomerBiz(objDr);
                if (int.TryParse(objDr["ReservationID"].ToString(), out intReservationID))
                    if (hsTemp[intReservationID.ToString()] == null)
                        hsTemp.Add(intReservationID.ToString(), objCustomerBiz);

            }

            foreach(ReservationBiz objReservationBiz in this)
            {

                if (hsTemp[objReservationBiz.ID.ToString()] != null)
                {
                    objReservationBiz.CampaignCustomerBiz = (CampaignCustomerBiz)hsTemp[objReservationBiz.ID.ToString()];

                }
            }
        }
        public static ReservationCol GetReservationColByIDs(string strIDs)
        {
            ReservationCol Returned = new ReservationCol(true);
            if (strIDs == null || strIDs == "")
                return Returned;
        
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.IDs = strIDs;
            DataTable dtTemp = objReservationDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new ReservationBiz(objDr));
            }
            return Returned;

        }
        public void SetPayBackCol()
        {
            if (_PayBackIsSet)
                return;
            ReservationPayBackDb objDb = new ReservationPayBackDb();
            objDb.ReservationIDs = CanceledIDsStr;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach (ReservationBiz objBiz in this)
            {
                arrDr = dtTemp.Select("ReservationID="+ objBiz.ID.ToString(), "");
                objBiz.PayBackCol = new ReservationPayBackCol(true);
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.PayBackCol.Add(new ReservationPayBackBiz(objDr));
                }

            }
            _PayBackIsSet = true;
        }
        public ReservationCol GetCol(string strCode)
        {
            ReservationCol Returned = new ReservationCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (ReservationBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.DirectUnitCodeStr.IndexOf(strTemp) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.DirectCustomerStr).IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1)
                    { 
                        blIsFound = false;
                       break;

                    }
                }
                if (blIsFound)
                    Returned.Add(objBiz);

            }
            return Returned;
        }
        public int ResubmissionCount { get; set; }
        public void SetResubmissionCol(ResubmissionTypeCol objTypeCol)
        {
            //if (_ResubmissionIsSet)
            //    return;
            List<string> arrStr = SysUtility.GetStringArr(IDsStr, ',', 5000);
            Hashtable hsTemp = new Hashtable();
           
                foreach (ReservationBiz objBiz in this)
                {
                    if (hsTemp[objBiz.ID.ToString()] == null)
                    {
                        objBiz.ResubmissionCol = new ReservationResubmissionCol(true);
                        hsTemp.Add(objBiz.ID.ToString(), objBiz);
                    }
                }
            ResubmissionCount =0;
            ReservationResubmissionDb objDb = new ReservationResubmissionDb();
          //  objDb.ResubmissionTypeIDs = objTypeCol.IDs;
            DataTable dtTemp;
           // DataRow []arrDr;
            ReservationResubmissionBiz objResubmissionBiz;
            ReservationBiz objReservationBiz;
            foreach (string strTemp in arrStr)
            {
                objDb.ReservationIDs = strTemp;
                objDb.ResubmissionStatus = 1;
                objDb.AllResubmission = true;
                dtTemp = objDb.Search();
                ResubmissionCount += dtTemp.Rows.Count;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objResubmissionBiz = new ReservationResubmissionBiz(objDr);
                    if (hsTemp[objResubmissionBiz.ReservationID.ToString()] != null)
                    {
                        objReservationBiz =(ReservationBiz) hsTemp[objResubmissionBiz.ReservationID.ToString()];
                        if (objReservationBiz._ResubmissionCol == null)
                            objReservationBiz._ResubmissionCol = new ReservationResubmissionCol(true);
                        objResubmissionBiz.ReservationBiz = objReservationBiz;
                        objReservationBiz._ResubmissionCol.Add(objResubmissionBiz);
                    }
                }

            }
            
            _ResubmissionIsSet = true;
        }
        public void Stop(bool blIsPermanent, DateTime dtOpenTime, string strReason)
        {
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.IDs = IDsStr;
            objReservationDb.StopReason = strReason;
            objReservationDb.OpenTime = dtOpenTime;
            objReservationDb.StopedPermanently = blIsPermanent;
            objReservationDb.StopReservation();
 
        }
        public void AddNote(string strNote)
        {
            ReservationDb objDb = new ReservationDb();
            if (Count > 1)
                objDb.IDs = IDsStr;
            else if (Count == 1)
                objDb.ID = this[0].ID;
            objDb.Note = strNote;
            objDb.EditNote();

        }
        public void SetTenantedUnitFree()
        {
            ReservationDb objDb = new ReservationDb();
            objDb.ActiveReservationIDs = IDsStr;
            objDb.SetTenantedUnitFree();
        }
        #endregion
    }
}
