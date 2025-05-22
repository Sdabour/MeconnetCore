using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
//using SharpVision.Base.BaseBusiness;
using System.Collections;
using SharpVision.SystemBase;
using System.Linq;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerCol : BaseCol
    {
        #region Privete Variable
        double _CurrentSalary = -1;
        double _CurrentSalaryForOn = -1;
        double _CurrentSalaryForOff = -1;
        int _CountWorker = -1;
        int _CountWorkerForOn = -1;
        int _CountWorkerForOff = -1;
        Hashtable _ApplicantHash = new Hashtable();
       public Hashtable ApplicantHash
        {
            get
            {
                return _ApplicantHash;
            }
        }
        Hashtable _ApplicantCodeHash = new Hashtable();
        #endregion
        #region Constructor
        public ApplicantWorkerCol()
        {

        }
        public ApplicantWorkerCol(UserBiz objUserBiz)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.User = objUserBiz.ID;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strIDs)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.ApplicantSearchIDs = strIDs;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strIDs, int intStatusIDSearch)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.ApplicantSearchIDs = strIDs;
            objDb.StatusIDSearch = intStatusIDSearch;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strName, string strNameComp, string strFamousName, string strCode)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.NameCompLike = strNameComp;
            objDb.FamousNameLike = strFamousName;
            objDb.CodeLike = strCode;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strName, string strNameComp, string strFamousName, string strCode, int intStatusID)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.NameCompLike = strNameComp;
            objDb.FamousNameLike = strFamousName;
            objDb.CodeLike = strCode;
            objDb.StatusIDSearch = intStatusID;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strAccountBankNo, string strApplicantIDs)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.AccountBankNoLike = strAccountBankNo;
            objDb.ApplicantSearchIDs = strApplicantIDs;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strName, string strNameComp, string strFamousName, string strCode,
            SectorBiz objSectorBiz, int intSubSectorID, int intStatusID)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            objDb.NameCompLike = strNameComp;
            objDb.FamousNameLike = strFamousName;
            objDb.CodeLike = strCode;



            objDb.SubSectorIDSearch = intSubSectorID;

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;



            //ApplicantWorkerDb.TopSearch = true;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(string strAccountBankNo, SectorBiz objSectorBiz, int intSubSectorID)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.AccountBankNoLike = strAccountBankNo;
            objDb.SubSectorIDSearch = intSubSectorID;

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;



            //ApplicantWorkerDb.TopSearch = true;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(bool blReview, SectorBiz objSectorBiz, int intSubSectorID)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();


            objDb.IsReviewedSearch = blReview;

            objDb.SubSectorIDSearch = intSubSectorID;

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;



            //ApplicantWorkerDb.TopSearch = true;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(int intSectorID, int intSubSectorID)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.SectorIDSearch = intSectorID;
            objDb.SubSectorIDSearch = intSubSectorID;
            DataTable dtApplicantWorker = objDb.Search();
            DataRow[] dtRows = dtApplicantWorker.Select("", "ApplicantFirstName");
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtRows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, AttendanceStatementBiz objStatementBiz, bool blOnlyNonStatemented,
            int intStatus, bool blHasAttendanceStatement, bool blHasTimeSheet, bool blTimeSheetStatusSearch,
            int intSumStatus, bool intSumStatusStatusSearch, int intApplicantStatusInAttendanceStatement, int intAvoidNonSalaryVacation)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objStatementBiz == null)
                objStatementBiz = new AttendanceStatementBiz();
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.AttendanceStatementID = objStatementBiz.ID;
            objDb.AttendanceStatementEndDate = objStatementBiz.StatementTo;
            objDb.AttendanceStatementStartDate = objStatementBiz.StatementFrom;
            objDb.WorkingStatus = intApplicantStatusInAttendanceStatement;
            if (blOnlyNonStatemented)
                objDb.AttendanceStatementConsider = 2;
            else
                objDb.AttendanceStatementConsider = 1;
            objDb.AttendanceStatementIsSumStatusSearch = intSumStatusStatusSearch;
            objDb.AttendanceStatementIsSum = intSumStatus == 2 ? true : false;
            objDb.HasAttendanceStatementSearch = blHasAttendanceStatement;
            objDb.HasTimeShitSearch = blHasTimeSheet;
            objDb.AttendanceStatementStatusSearch = true;
            objDb.TimeSheetStatusSearch = blTimeSheetStatusSearch;
            objDb.AvoidNoSalaryVacation = intAvoidNonSalaryVacation;
            objDb.StatusIDSearch = intStatus;
            // objDb.WorkingStatus = intApplicantStatusInAttendanceStatement == 0 && intStatus == 1 ? 5 : intApplicantStatusInAttendanceStatement;
            objDb.ApplicantStatusInAttendanceStatement = intApplicantStatusInAttendanceStatement;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, AttendanceStatementBiz objStatementBiz, int intStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objStatementBiz == null)
                objStatementBiz = new AttendanceStatementBiz();
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.AttendanceStatementID = objStatementBiz.ID;
            //if (blOnlyNonStatemented)
            //    objDb.AttendanceStatementConsider = 2;
            //else
            //    objDb.AttendanceStatementConsider = 1;
            objDb.StatusIDSearch = intStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, AttendanceStatementCol objStatementCol, int intAttendanceStatementApplicantStatus, int intStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objStatementCol == null)
                objStatementCol = new AttendanceStatementCol(true);
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.AttendanceStatementIDs = objStatementCol.IDs;
            objDb.AttendanceStatementApplicantStatus = (byte)intAttendanceStatementApplicantStatus;
            objDb.StatusIDSearch = (byte)intStatus;


            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }

        public ApplicantWorkerCol(SectorBiz objSectorBiz, GlobalStatementBiz objStatementBiz, bool blOnlyNonStatemented, int intStatus, int intAvoidNonSalaryVacation)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objStatementBiz == null)
                objStatementBiz = new GlobalStatementBiz();
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.GlobalStatementID = objStatementBiz.ID;
            objDb.GlobalStatementEndDate = objStatementBiz.StatementDateTo;
            objDb.GlobalStatementStartDate = objStatementBiz.StatementDate;
            objDb.AvoidNoSalaryVacation = intAvoidNonSalaryVacation;
            objDb.StatementReviewedStatus = 2;
            if (blOnlyNonStatemented)
                objDb.GlobalStatementConsider = 2;
            else
                objDb.GlobalStatementConsider = 1;
            objDb.StatusIDSearch = intStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz
        , int intStatus
        , int intCostCenterStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            objDb.ShortApplicantOnly = false;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(SectorCol objSectorCol
          , int intStatus
          , int intCostCenterStatus)
        {
            if (objSectorCol == null)
                objSectorCol = new SectorCol(true);

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
           
                objDb.FlatSectorIDs = objSectorCol.FlatIDs;
            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            objDb.ShortApplicantOnly = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }

        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, int intCostCenterStatus, bool isSaved, bool notsaved)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            if (!isSaved && !notsaved)
                objDb.JobDesc = 0;
            if (isSaved)
                objDb.JobDesc = 1;
            if (notsaved)
                objDb.JobDesc = 2;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, int intCostCenterStatus, JobNatureTypeCol objJobCol)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;

            if (objJobCol != null && objJobCol.Count != 0)
                objDb.JobIDs = objJobCol.IDsStr;

            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }


      
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, int intCostCenterStatus, BranchBiz objBranchBiz)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            if (objBranchBiz != null)
                objDb.BranchIDSearch = objBranchBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, int intCostCenterStatus, BranchBiz objBranchBiz,
            EstimationStatementBiz objEstimationStatementBiz, byte byStartDateStatus, DateTime dtStartDateFrom, DateTime dtStartDateTo)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.CostCenterCondiered = (byte)intCostCenterStatus;
            objDb.StatusIDSearch = intStatus;
            if (objBranchBiz != null)
                objDb.BranchIDSearch = objBranchBiz.ID;

            objDb.EstimationStatementIDSearch = objEstimationStatementBiz.ID;
            objDb.StartDateStatusSearch = byStartDateStatus;
            objDb.StartDateFromSearch = dtStartDateFrom;
            objDb.StartDateToSearch = dtStartDateTo;

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(int intStatusInsuranceOrStartSalaryNo, int intStatus, SectorBiz objSectorBiz)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;

            objDb.intInsuranceStatusSearch = intStatusInsuranceOrStartSalaryNo;


            objDb.StatusIDSearch = intStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, bool blApplicantWithLoan)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.ApplicantWithloanSearch = blApplicantWithLoan;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intWorkerStatus, EstimationStatementBiz objEstimationStatementBiz, AttendanceStatementCol objStatementCol,
            byte blEetimationStatementStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.EstimationStatementIDSearch = objEstimationStatementBiz.ID;
            objDb.EstimationStatementStatusSearch = blEetimationStatementStatus;
            objDb.AttendanceStatementIDs = objStatementCol.IDs;
            objDb.AttendanceStatementApplicantStatus = (byte)intWorkerStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intWorkerStatus, EstimationStatementBiz objEstimationStatementBiz,
            byte blEetimationStatementStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.EstimationStatementIDSearch = objEstimationStatementBiz.ID;
            objDb.EstimationStatementStatusSearch = blEetimationStatementStatus;

            objDb.StatusIDSearch = intWorkerStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
      
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intWorkerStatus, EstimationStatementBiz objEstimationStatementBiz,
            byte blSetimationStatementStatus, DateTime dtStartDateFrom, DateTime dtStartDateTo)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.EstimationStatementIDSearch = objEstimationStatementBiz.ID;
            objDb.EstimationStatementStatusSearch = blSetimationStatementStatus;
            objDb.StatusIDSearch = intWorkerStatus;
            objDb.StartDateStatusSearch = 1;
            objDb.StartDateFromSearch = dtStartDateFrom;
            objDb.StartDateToSearch = dtStartDateTo;

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatusStartOrEnd, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.StatusIDSearch = intStatusStartOrEnd;
            if (intStatusStartOrEnd == 1)
            {
                objDb.StartDateStatusSearch = 1;
                objDb.StartDateFromSearch = dtFrom;
                objDb.StartDateToSearch = dtTo;
            }
            else if (intStatusStartOrEnd == 2)
            {
                objDb.EndDateStatusSearch = true;
                objDb.EndDateFromSearch = dtFrom;
                objDb.EndDateToSearch = dtTo;
            }
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatusStartOrEnd, bool blSearch, DateTime dtFrom, DateTime dtTo, JobNatureTypeCol objJobNatureTypeCol)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            //objDb.StatusIDSearch = intStatusStartOrEnd;
            if (intStatusStartOrEnd == 1)
            {
                objDb.StartDateStatusSearch = 1;
                objDb.StartDateFromSearch = dtFrom;
                objDb.StartDateToSearch = dtTo;
            }
            else if (intStatusStartOrEnd == 2)
            {
                objDb.EndDateStatusSearch = true;
                objDb.EndDateFromSearch = dtFrom;
                objDb.EndDateToSearch = dtTo;
            }

            objDb.JobIDs = objJobNatureTypeCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, int intStatusAccountBankNoSearch, bool blStatusAccountBankNoOrder)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.WorkingStatus = intStatus;
            objDb.AccountBankNoSearch = intStatusAccountBankNoSearch;
            objDb.AccountBankNoOrderSearch = blStatusAccountBankNoOrder;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, byte btCurrentSalaryStatus, byte IsPartTimeStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            byte btTempStatus;


            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.StatusIDSearch = intStatus;
            objDb.IsPartTimeStatus = IsPartTimeStatus;
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerBiz(objDr);
                if (objBiz.CurrentSalary == 0)
                    btTempStatus = 1;
                else
                    btTempStatus = 2;
                if (btCurrentSalaryStatus == 0 || btCurrentSalaryStatus == btTempStatus)
                {
                    Add(objBiz);
                }
            }

        }
        public ApplicantWorkerCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.ShortApplicantOnly = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }
        }
            public ApplicantWorkerCol(ref bool blApplicantExist, int intApplicantID, string strApplicantNameComp, string strApplicantCode)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.ApplicantWorkerID = intApplicantID;
            objDb.NameComp = strApplicantNameComp;
            objDb.Code = strApplicantCode;
            DataTable Dt = objDb.GetApplicantWorker();
            if (Dt.Rows.Count == 0)
                blApplicantExist = false;
            else
                blApplicantExist = true;

        }
        public ApplicantWorkerCol(SectorCol objSectorCol, JobNatureTypeCol objJobCol, int intStatus)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.SectorIDs = objSectorCol.IDsStr;
            objDb.JobIDs = objJobCol.IDsStr;
            objDb.StatusIDSearch = intStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, BranchBiz objBranchBiz, CellBiz objCellBiz, JobNatureTypeCol objJobCol,
            int intStatus, int intStartDateStatus, DateTime dtDateFrom, DateTime dtDateTo, int intWorkingStatus, int intIsHasLastFinantial)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            if (objSectorBiz != null)
            {
                if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
                {
                    objDb.SectoFamilyID = objSectorBiz.ID;
                }
                else if (objSectorBiz.ID != 0)
                    objDb.SectorIDs = objSectorBiz.IDsStr;
            }
            if (objBranchBiz != null)
                objDb.BranchIDSearch = objBranchBiz.ID;
            if (objCellBiz != null)
                objDb.CellIDSearch = objCellBiz.ID;
            if (objJobCol != null && objJobCol.Count != 0)
                objDb.JobIDs = objJobCol.IDsStr;
            //else
            //    objDb.JobIDs = "0";
            objDb.StatusIDSearch = intStatus;

            objDb.StartDateStatusWithApplicantStatusSearch = intStartDateStatus;
            objDb.StartDateFromWithApplicantStatusSearch = dtDateFrom;
            objDb.StartDateToWithApplicantStatusSearch = dtDateTo;
            objDb.WorkingStatus = intWorkingStatus;
            objDb.IsHasLastFinantial = intIsHasLastFinantial;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //if (intStartDateStatus == 0)
                Add(new ApplicantWorkerBiz(objDr));
                //else
                //    List.Add(new ApplicantWorkerBiz(objDr, intStartDateStatus, dtDateFrom, dtDateTo));
            }

        }
        public ApplicantWorkerCol(SectorCol objSectorCol, BranchBiz objBranchBiz, CellBiz objCellBiz, JobNatureTypeCol objJobCol,
            int intStatus, int intStartDateStatus, DateTime dtDateFrom, DateTime dtDateTo, int intWorkingStatus, int intIsHasLastFinantial)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            if (objSectorCol != null)
            {
                //if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
                //{
                //    objDb.SectoFamilyID = objSectorBiz.ID;
                //}
                //else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorCol.IDsStr;
            }
            if (objBranchBiz != null)
                objDb.BranchIDSearch = objBranchBiz.ID;
            if (objCellBiz != null)
                objDb.CellIDSearch = objCellBiz.ID;
            if (objJobCol != null && objJobCol.Count != 0)
                objDb.JobIDs = objJobCol.IDsStr;
            //else
            //    objDb.JobIDs = "0";
            objDb.StatusIDSearch = intStatus;

            objDb.StartDateStatusWithApplicantStatusSearch = intStartDateStatus;
            objDb.StartDateFromWithApplicantStatusSearch = dtDateFrom;
            objDb.StartDateToWithApplicantStatusSearch = dtDateTo;
            objDb.WorkingStatus = intWorkingStatus;
            objDb.IsHasLastFinantial = intIsHasLastFinantial;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //if (intStartDateStatus == 0)
                Add(new ApplicantWorkerBiz(objDr));
                //else
                //    List.Add(new ApplicantWorkerBiz(objDr, intStartDateStatus, dtDateFrom, dtDateTo));
            }

        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, BranchBiz objBranchBiz, CellBiz objCellBiz, JobNatureTypeBiz objJobBiz, int intStatus, int intStartDateStatus, DateTime dtDateFrom, DateTime dtDateTo)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            if (objSectorBiz != null)
            {
                if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
                {
                    objDb.SectoFamilyID = objSectorBiz.ID;
                }
                else if (objSectorBiz.ID != 0)
                    objDb.SectorIDs = objSectorBiz.IDsStr;
            }
            if (objBranchBiz != null)
                objDb.BranchIDSearch = objBranchBiz.ID;
            if (objCellBiz != null)
                objDb.CellIDSearch = objCellBiz.ID;
            if (objJobBiz != null && objJobBiz.ID != 0)
                objDb.JobIDs = objJobBiz.ID.ToString();
            objDb.StatusIDSearch = intStatus;
            objDb.StartDateStatusWithApplicantStatusSearch = intStartDateStatus;
            objDb.StartDateFromWithApplicantStatusSearch = dtDateFrom;
            objDb.StartDateToWithApplicantStatusSearch = dtDateTo;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //if (intStartDateStatus == 0)
                Add(new ApplicantWorkerBiz(objDr));
                //else
                //    List.Add(new ApplicantWorkerBiz(objDr, intStartDateStatus, dtDateFrom, dtDateTo));
            }

        }
        public ApplicantWorkerCol(DataTable ObjDT, SectorBiz objSectorBiz)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();

            DataRow ObjDR = ObjDT.Rows[0];

            objDb.NameCompLike = ObjDR["NameComp"].ToString();
            objDb.RegionIDSearch = int.Parse(ObjDR["RegionID"].ToString());
            objDb.FamousNameLike = ObjDR["FamousName"].ToString();
            objDb.CodeLike = ObjDR["Code"].ToString();

            objDb.BirthDateStatusSearch = int.Parse(ObjDR["BirthDateStatus"].ToString());
            objDb.BirthDateFromSearch = DateTime.Parse(ObjDR["BirthDateFrom"].ToString());
            objDb.BirthDateToSearch = DateTime.Parse(ObjDR["BirthDateTo"].ToString());

            objDb.StartDateStatusSearch = int.Parse(ObjDR["StartDateStatus"].ToString());
            objDb.StartDateFromSearch = DateTime.Parse(ObjDR["StartDateFrom"].ToString());
            objDb.StartDateToSearch = DateTime.Parse(ObjDR["StartDateTo"].ToString());

            objDb.EndDateStatusSearch = bool.Parse(ObjDR["EndDateStatus"].ToString());
            objDb.EndDateFromSearch = DateTime.Parse(ObjDR["EndDateFrom"].ToString());
            objDb.EndDateToSearch = DateTime.Parse(ObjDR["EndDateTo"].ToString());



            objDb.MaritalStatusIDSearch = int.Parse(ObjDR["MaritalStatusID"].ToString());
            objDb.MiltaryStatusIDSearch = int.Parse(ObjDR["MiltaryStatusID"].ToString());
            objDb.CommonServiceIDSearch = int.Parse(ObjDR["CommonServiceID"].ToString());
            objDb.TypeIDSearch = int.Parse(ObjDR["TypeID"].ToString());
            objDb.IDValSearch = int.Parse(ObjDR["IDValue"].ToString());
            objDb.IDTypeSearch = int.Parse(ObjDR["IDType"].ToString());

            objDb.ScientificDegreeIDSearch = int.Parse(ObjDR["ScientificDegreeID"].ToString());
            objDb.DegreeFieldIDSearch = int.Parse(ObjDR["DegreeFieldID"].ToString());
            objDb.DegreeSubFieldIDSearch = int.Parse(ObjDR["DegreeSubFieldID"].ToString());
            objDb.GraduationYearFromSearch = int.Parse(ObjDR["GraduationYearFrom"].ToString());
            objDb.GraduationYearToSearch = int.Parse(ObjDR["GraduationYearTo"].ToString());


            objDb.JobTypeIDSearch = int.Parse(ObjDR["JobTypeID"].ToString());
            objDb.JobTitleTypeIDSearch = int.Parse(ObjDR["JobTitleTypeID"].ToString());
            objDb.JobNatureTypeIDSearch = int.Parse(ObjDR["JobNatureTypeID"].ToString());
            objDb.SJobTypeIDSearch = int.Parse(ObjDR["SJobTypeID"].ToString());
            objDb.SJobTitleTypeIDSearch = int.Parse(ObjDR["SJobTitleTypeID"].ToString());
            objDb.SJobNatureTypeIDSearch = int.Parse(ObjDR["SJobNatureTypeID"].ToString());
            objDb.SubSectorIDSearch = int.Parse(ObjDR["SubSectorID"].ToString());

            //objApplicantWorkerDb.SectorIDSearch = int.Parse(ObjDR["SectorID"].ToString());

            if (objSectorBiz != null)
            {
                if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
                {
                    objDb.SectoFamilyID = objSectorBiz.ID;
                }
                else if (objSectorBiz.ID != 0)
                    objDb.SectorIDs = objSectorBiz.IDsStr;
            }




            objDb.BranchIDSearch = int.Parse(ObjDR["BranchID"].ToString());

            if (objSectorBiz != null && objSectorBiz.ID != 0 && int.Parse(ObjDR["BranchID"].ToString()) != 0)
            {
                objDb.SubSectorIDSearch = 0;
            }
            objDb.CellIDSearch = int.Parse(ObjDR["CellID"].ToString());
            objDb.StatusIDSearch = int.Parse(ObjDR["StatusID"].ToString());
            objDb.ReligionIDSearch = int.Parse(ObjDR["ReligionID"].ToString());


            objDb.intInsuranceStatusSearch = int.Parse(ObjDR["intInsuranceStatusSearch"].ToString());
            objDb.InsuranceValueSearch = ObjDR["InsuranceValue"].ToString();

            objDb.InsuranceDateStatusSearch = bool.Parse(ObjDR["InsuranceDateStatus"].ToString());
            objDb.InsuranceDateFromSearch = DateTime.Parse(ObjDR["InsuranceDateFrom"].ToString());
            objDb.InsuranceDateToSearch = DateTime.Parse(ObjDR["InsuranceDateTo"].ToString());

            objDb.FellowShipeStatusSearch = int.Parse(ObjDR["intFellowShipStatusSearch"].ToString());
            //objApplicantWorkerDb.StoreIDSearch = int.Parse(ObjDR["StoreID"].ToString());

            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objApplicantWorkerBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objApplicantWorkerBiz);
            }
        }
        public ApplicantWorkerCol(SectorBiz objSectorBiz, int intStatus, byte byMonthStatus,
            byte byGrantStatus, DateTime dtGrantFrom, DateTime dtGrantTo, int intGetFromViews, JobNatureTypeBiz objJobNatureTypeBiz)
        // byMonthStatus =0 No ,1 less than 6 ,2 over 6 and less than 12 ,3 over 12
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectoFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.StatusIDSearch = intStatus;
            objDb.MonthSearch = (int)byMonthStatus;
            objDb.GrantSearch = (int)byGrantStatus;
            objDb.GrantDateFromSearch = dtGrantFrom;
            objDb.GrantDateToSearch = dtGrantTo;
            objDb.GetFromViews = intGetFromViews;
            if (objJobNatureTypeBiz.ID != 0)
                objDb.JobIDs = objJobNatureTypeBiz.ID.ToString();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerBiz(objDr));
            }

        }
        public ApplicantWorkerCol(UserBiz objUserBiz, bool blStatusSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.UserIDSearch = objUserBiz.ID;
            objDb.InsDateStatusSearch = blStatusSearch;
            objDb.InsDateFromSearch = dtFrom;
            objDb.InsDateToSearch = dtTo;
            DataTable dtApplicantWorker = objDb.Search();
            ApplicantWorkerBiz objBiz;
            foreach (DataRow objDr in dtApplicantWorker.Rows)
            {
                objBiz = new ApplicantWorkerBiz(objDr);
                this.Add(objBiz);
            }
        }

        #endregion
        #region Public  
        public ApplicantWorkerBiz this[string strIndex]
        {
            set
            {
                if (_ApplicantHash[strIndex] == null)
                    _ApplicantHash.Add(strIndex, value);
                else
                    _ApplicantHash[strIndex] = value;
            }
            get
            {

                return _ApplicantHash[strIndex] == null ? new ApplicantWorkerBiz() :
                    (ApplicantWorkerBiz)_ApplicantHash[strIndex];
            }
        }

        public ApplicantWorkerBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (ApplicantWorkerBiz)List[intIndex];
            }
        }
        public string IDs
        {
            get
            {
                string strIDs = "";
                foreach (ApplicantWorkerBiz objBiz in this)
                {
                    if (strIDs != "")
                        strIDs = strIDs + ",";
                    strIDs = strIDs + objBiz.ID.ToString();
                }
                return strIDs;
            }
        }
        public string ApplicantCodes
        {
            get
            {
                string strCodes = "";
                foreach (ApplicantWorkerBiz objBiz in this)
                {
                    if (strCodes != "")
                        strCodes += "," + "'" + objBiz.Code + "'";
                    else
                        strCodes += "'" + objBiz.Code + "'";
                }
                return strCodes;
            }
        }
        JobCategoryEstimationCol _JobCategoryEstimationCol;
        public JobCategoryEstimationCol JobCategoryEstimationCol
        {
            set => _JobCategoryEstimationCol = value;
            get
            {
                if (_JobCategoryEstimationCol == null)
                {
                    Hashtable hsJobCategory = new Hashtable();
                    _JobCategoryEstimationCol = new JobCategoryEstimationCol(true);
                    JobCategoryEstimationBiz objCategoryBiz;
                    foreach (ApplicantWorkerBiz objBiz in this)
                    {
                        if (hsJobCategory[objBiz.JobCategoryEstimationBiz.ID.ToString()] == null)
                        {
                            objCategoryBiz = objBiz.JobCategoryEstimationBiz;
                            hsJobCategory.Add(objCategoryBiz.ID.ToString(), objCategoryBiz);
                            _JobCategoryEstimationCol.Add(objCategoryBiz);
                        }
                        else
                        {
                            objCategoryBiz = (JobCategoryEstimationBiz)hsJobCategory[objBiz.JobCategoryEstimationBiz.ID.ToString()];
                            objBiz.JobCategoryEstimationBiz = objCategoryBiz;
                        }
                    }




                }
                return _JobCategoryEstimationCol;
            }
        }
        public void Add(ApplicantWorkerBiz objBiz)
        {
            //if(GetIndex(objBiz.ID)==-1)

            if (_ApplicantHash[objBiz.ID.ToString()] == null)
            {
                List.Add(objBiz);
                _ApplicantHash.Add(objBiz.ID.ToString(), objBiz);
                if (objBiz.Code != "" && _ApplicantCodeHash[objBiz.Code.ToLower()] == null)
                {
                    _ApplicantCodeHash.Add(objBiz.Code.ToLower(), Count - 1);

                }
            }



        }
        public ApplicantWorkerBiz GetApplicantByCode(string strCode)
        {
            ApplicantWorkerBiz Returned = new ApplicantWorkerBiz();
            if (_ApplicantCodeHash[strCode] != null)
                Returned = this[(int)_ApplicantCodeHash[strCode]];
            return Returned;
        }
        public void Add(ApplicantWorkerCol objCol)
        {
            foreach (ApplicantWorkerBiz objBiz in objCol)
            {

                Add(objBiz);

            }
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public bool Contains(ApplicantWorkerBiz objBiz)
        {
            return _ApplicantHash[objBiz.ID.ToString()] != null;
        }
        public bool Contains(int intID)
        {
            return _ApplicantHash[intID.ToString()] != null;
        }
        public ApplicantWorkerCol GetWorkerCol(string strName)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            strName = strName.Replace(" ", "");
            string[] arrStr = strName.Split("%".ToCharArray());
            bool blIsFound = true;

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(strTemp) == -1)
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
        public ApplicantWorkerCol GetWorkerColByCode(string strCode)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.Code == strCode)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        public ApplicantWorkerCol GetWorkerColByInsuranceNo(string strInsuranceNo)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.InsuranceNo.IndexOf(strInsuranceNo) != -1)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        public ApplicantWorkerCol GetWorkerCol(string strName, byte btCurrentSalaryStatus)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            byte btTempStatus;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.CurrentSalary == 0)
                    btTempStatus = 1;
                else
                    btTempStatus = 2;
                if (objBiz.NameComp.IndexOf(strName) != -1 &&
                    (btCurrentSalaryStatus == 0 || btCurrentSalaryStatus == btTempStatus))
                {
                    Returned.Add(objBiz);

                }

            }
            return Returned;
        }
        public ApplicantWorkerCol GetWorkerCol(SectorBiz objSectorBiz, JobNatureTypeBiz objTypeBiz)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.CurrentSubSectorCol.Contains(objSectorBiz, objTypeBiz))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public void EditCostCenter(int intCostCenter)
        {
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.IDs = IDs;
            objDb.CostCenter = intCostCenter;
            objDb.EditCostCenter();
        }
        public ApplicantWorkerCol GetApplicantStartWork(DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();

            DateTime _dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
            DateTime _dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day);
            _dtTo = _dtTo.AddDays(1);
            //_dtTo = _dtTo.AddHours(-1);

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.StartDateStatus == true)
                {

                    if (objBiz.StartDate >= _dtFrom && objBiz.StartDate < _dtTo)
                    {
                        objCol.Add(objBiz);
                    }
                }
            }
            return objCol;
        }
        public ApplicantWorkerCol GetApplicantEndWork(DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();
            DateTime _dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
            DateTime _dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day);
            _dtTo = _dtTo.AddDays(1);
            //_dtTo = _dtTo.AddHours(-1);
            foreach (ApplicantWorkerBiz objBiz in this)
            {

                if (objBiz.StatusID != 1)
                {
                    if (objBiz.EndDate >= _dtFrom && objBiz.EndDate < _dtTo)
                    {
                        objCol.Add(objBiz);
                    }
                }
            }
            return objCol;
        }
        public int GetApplicantCountStartWork(DateTime dtFrom, DateTime dtTo)
        {
            int _count = 0;

            DateTime _dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
            DateTime _dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day);
            _dtTo = _dtTo.AddDays(1);
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.StartDateStatus == true)
                {
                    if (objBiz.StartDate >= _dtFrom && objBiz.StartDate < _dtTo)
                    {
                        _count++;
                    }
                }
            }
            return _count;
        }
        public int GetApplicantCountEndWork(DateTime dtFrom, DateTime dtTo)
        {
            int _count = 0;
            DateTime _dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
            DateTime _dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day);
            _dtTo = _dtTo.AddDays(1);
            foreach (ApplicantWorkerBiz objBiz in this)
            {

                if (objBiz.StatusID != 1)
                {
                    if (objBiz.EndDate >= _dtFrom && objBiz.EndDate < _dtTo)
                    {
                        _count++;
                    }
                }
            }
            return _count;
        }
     
        public double TotalBaseSalary
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerBiz objBiz in this)
                {
                    dlValue += objBiz.CurrentSalary;//+ objBiz.SalaryDetailsCol.TotalValue;
                }
                return dlValue;
            }
        }
        
        public int CountWorker
        {
            set
            {
                _CountWorker = value;
            }
            get
            {
                return this.Count;
            }
        }
        public int CountWorkerForOn
        {
            set
            {
                _CountWorkerForOn = value;
            }
            get
            {
                if (_CountWorkerForOn == -1)
                {
                    _CountWorkerForOn = 0;
                    foreach (ApplicantWorkerBiz objBiz in this)
                    {
                        if (objBiz.StatusID == 1)
                            _CountWorkerForOn++;
                    }
                }
                return _CountWorkerForOn;
            }
        }
        public int CountWorkerForOff
        {
            set
            {
                _CountWorkerForOff = value;
            }
            get
            {
                if (_CountWorkerForOff == -1)
                {
                    _CountWorkerForOff = 0;
                    foreach (ApplicantWorkerBiz objBiz in this)
                    {
                        if (objBiz.StatusID != 1)
                            _CountWorkerForOff++;
                    }
                }
                return _CountWorkerForOff;
            }
        }

        public Hashtable ApplicantCodeHash { get => _ApplicantCodeHash; set => _ApplicantCodeHash = value; }


        public void InitTotals()
        {
            _CurrentSalary = -1;
            _CurrentSalaryForOn = -1;
            _CurrentSalaryForOff = -1;
            _CountWorker = -1;
            _CountWorkerForOn = -1;
            _CountWorkerForOff = -1;
        }
     
        public ApplicantWorkerBiz GetApplicant(int intApplicantID)
        {
            ApplicantWorkerBiz objReturned = new ApplicantWorkerBiz();
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.ID == intApplicantID)
                {
                    objReturned = objBiz;
                    break;
                }
            }
            return objReturned;
        }
       
        public JobNatureTypeCol GetJobNatureTypeCol(bool blHasEmpty)
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                objCol.Add(objBiz.CurrentSubSectorBiz.JobNatureTypeBiz);
            }
            objCol = objCol.GetJobNatureTypeOrderByCol();
            if (blHasEmpty)
            {
                JobNatureTypeBiz objBiz = new JobNatureTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objCol.Add(objBiz);
            }
            return objCol;
        }
        public JobNatureTypeCol GetJobNatureTypeNotOrderCol(bool blHasEmpty)
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                objCol.Add(objBiz.CurrentSubSectorBiz.JobNatureTypeBiz);
            }
            objCol = objCol.GetJobNatureTypeOrderByCol();
            if (blHasEmpty)
            {
                JobNatureTypeBiz objBiz = new JobNatureTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objCol.Add(objBiz);
            }
            return objCol;
        }
        public JobCategoryEstimationCol GetJobCategoryEstimationCol(bool blHasEmpty)
        {
            JobCategoryEstimationCol objCol = new JobCategoryEstimationCol(true);
            if (blHasEmpty)
            {
                JobCategoryEstimationBiz objBiz = new JobCategoryEstimationBiz();
                objBiz.ID = -1;
                objBiz.NameA = "€Ì— „Õœœ";
                objCol.Add(objBiz);
            }
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                //objBiz.JobCategoryEstimationBiz = null;
                if (objBiz.JobCategoryEstimationBiz.ID != 0)
                    objCol.Add(objBiz.JobCategoryEstimationBiz);
            }

            return objCol;
        }
        public JobCategoryEstimationCol GetVirualJobCategoryEstimationCol(bool blHasEmpty)
        {
            JobCategoryEstimationCol objCol = new JobCategoryEstimationCol(true);
            if (blHasEmpty)
            {
                JobCategoryEstimationBiz objBiz = new JobCategoryEstimationBiz();
                objBiz.ID = -1;
                objBiz.NameA = "«·ﬂ·";
                objCol.Add(objBiz);
                objBiz = new JobCategoryEstimationBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objCol.Add(objBiz);


            }
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                //objBiz.JobCategoryEstimationBiz = null;
                if (objBiz.VirualJobCategoryEstimationBiz.ID != 0)
                    objCol.Add(objBiz.VirualJobCategoryEstimationBiz);
            }

            return objCol;
        }
        public JobCategoryEstimationCol GetVirualJobCategoryEstimationCol()
        {
            JobCategoryEstimationCol objCol = new JobCategoryEstimationCol(true);
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                //objBiz.JobCategoryEstimationBiz = null;
                if (objBiz.VirualJobCategoryEstimationBiz.ID != 0)
                    objCol.Add(objBiz.VirualJobCategoryEstimationBiz);
            }

            return objCol;
        }
        public ApplicantWorkerCol GetApplicantWorkerOrderByJob()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol(true);
            DataTable dtTemp = new DataTable("");
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("ApplicantName")
            ,new DataColumn("JobNature"),new DataColumn("OrderVal",typeof(int))});
            DataRow drTemp;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                drTemp = dtTemp.NewRow();
                drTemp["ApplicantID"] = objBiz.ID;
                drTemp["ApplicantName"] = objBiz.Name;
                drTemp["JobNature"] = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
                drTemp["OrderVal"] = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz.JobCategory.OrderValue;


                dtTemp.Rows.Add(drTemp);
            }

            DataRow[] arrRows = dtTemp.Select("", "OrderVal,JobNature,ApplicantName");
            int _Index = 1;
            foreach (DataRow objDr in arrRows)
            {
                ApplicantWorkerBiz objBiz = this[this.GetIndex(int.Parse(objDr["ApplicantID"].ToString()))];
                objBiz.VirualIndex = _Index;
                objCol.Add(objBiz);
                _Index++;
            }
            return objCol;
        }
        public ApplicantWorkerCol GetApplicantWorkerOrderByVirtualJob()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol(true);
            DataTable dtTemp = new DataTable("");
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("ApplicantName")
            ,new DataColumn("JobNature"),new DataColumn("OrderVal",typeof(int))});
            DataRow drTemp;

            foreach (ApplicantWorkerBiz objBiz in this)
            {
                drTemp = dtTemp.NewRow();
                drTemp["ApplicantID"] = objBiz.ID;
                drTemp["ApplicantName"] = objBiz.Name;
                drTemp["JobNature"] = objBiz.VirualJobNatureTypeBiz.Name;
                drTemp["OrderVal"] = objBiz.VirualJobNatureTypeBiz.JobCategory.OrderValue;


                dtTemp.Rows.Add(drTemp);
            }

            DataRow[] arrRows = dtTemp.Select("", "OrderVal,JobNature,ApplicantName");
            int intIndex = 1;
            ApplicantWorkerBiz objbufferBiz = new ApplicantWorkerBiz();
            foreach (DataRow objDr in arrRows)
            {
                objbufferBiz = this[this.GetIndex(int.Parse(objDr["ApplicantID"].ToString()))];
                objbufferBiz.VirualIndex = intIndex;
                objCol.Add(objbufferBiz);
                intIndex++;
            }
            return objCol;
        }
        public ApplicantWorkerCol GetApplicantWorkerOrderByAccountBank()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol(true);
            DataTable dtTemp = new DataTable("");
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("ApplicantName")
            ,new DataColumn("BankIntNo",typeof(float))});
            DataRow drTemp;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                drTemp = dtTemp.NewRow();
                drTemp["ApplicantID"] = objBiz.ID;
                drTemp["ApplicantName"] = objBiz.Name;
                drTemp["BankIntNo"] = objBiz.BankIntNo;


                dtTemp.Rows.Add(drTemp);
            }

            DataRow[] arrRows = dtTemp.Select("", "BankIntNo");

            foreach (DataRow objDr in arrRows)
            {
                objCol.Add(this[this.GetIndex(int.Parse(objDr["ApplicantID"].ToString()))]);
            }
            return objCol;
        }
        public ApplicantWorkerCol GetApplicantWorkerOrderByJob(bool blIncludeVirtualCostCenterInSort)
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol(true);
            DataTable dtTemp = new DataTable("");
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("ApplicantName")
            ,new DataColumn("JobNature"),new DataColumn("OrderVal",typeof(int)),new DataColumn("CostCenter",typeof(int))});
            DataRow drTemp;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                drTemp = dtTemp.NewRow();

                drTemp["ApplicantID"] = objBiz.ID;
                drTemp["ApplicantName"] = objBiz.Name;
                if (blIncludeVirtualCostCenterInSort)
                {
                    drTemp["JobNature"] = objBiz.VirualJobNatureTypeBiz.Name;
                    drTemp["OrderVal"] = objBiz.VirualJobNatureTypeBiz.JobCategory.OrderValue;
                    drTemp["CostCenter"] = objBiz.VirualCostCenterBiz.ID;
                }
                else
                {
                    drTemp["JobNature"] = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
                    drTemp["OrderVal"] = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz.JobCategory.OrderValue;
                    drTemp["CostCenter"] = "0";
                }

                dtTemp.Rows.Add(drTemp);
            }
            DataRow[] arrRows = dtTemp.Select("", "CostCenter,OrderVal,JobNature,ApplicantName");

            foreach (DataRow objDr in arrRows)
            {
                objCol.Add(this[this.GetIndex(int.Parse(objDr["ApplicantID"].ToString()))]);
            }
            return objCol;
        }
       
        public static void SetJobCategoryEstimation(int intJobNatureID, int intJobCatgoreyEstimation, string strApplicantIDs)
        {
            ApplicantWorkerDb.SetJobCategoryEstimation(intJobNatureID, intJobCatgoreyEstimation, strApplicantIDs);
        }
        public static void ReSetJobCategoryEstimation(int intJobNatureID, string strApplicantIDs)
        {
            ApplicantWorkerDb.ResetJobCategoryEstimation(intJobNatureID, strApplicantIDs);
        }
        public int GetVirualIndex(int intID)
        {
            int intIndex = GetIndex(intID);
            if (intIndex != -1)
                return this[intIndex].VirualIndex;
            else
                return -1;
        }
        protected override void OnClear()
        {
            base.OnClear();
            _ApplicantHash = new Hashtable();
        }
  
        
       public void SetLastGrantedVacationCol()
        {

        }
     
        
        #endregion
    }
}
    
