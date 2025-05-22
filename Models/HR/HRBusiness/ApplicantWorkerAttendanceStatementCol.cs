using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerAttendanceStatementCol : CollectionBase
    {
        #region Private Data
        static EstimationStatementBiz _EstimationStatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceStatementCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerAttendanceStatementCol()
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(int intApplicantID,int intAttendanceStatementID)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.Applicant = intApplicantID;
            objDb.AttendanceStatment = intAttendanceStatementID;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(ApplicantWorkerCol objApplicantWorkerCol, AttendanceStatementBiz objAttendanceStatement)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.AttendanceStatment = objAttendanceStatement.ID;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;
            Hashtable hsTempApplicant = new Hashtable();
            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                if (hsTempApplicant[objApplicantWorkerAttendanceStatementBiz.ApplicantWorkerBiz.ID.ToString()] == null)
                    hsTempApplicant.Add(objApplicantWorkerAttendanceStatementBiz.ApplicantWorkerBiz.ID.ToString(), objApplicantWorkerAttendanceStatementBiz.ApplicantWorkerBiz);

                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            foreach (ApplicantWorkerBiz objWorker in objApplicantWorkerCol)
            {
                if(hsTempApplicant[objWorker.ID.ToString()]== null)
                {
                    Add(new ApplicantWorkerAttendanceStatementBiz() { ApplicantWorkerBiz = objWorker, AttendanceStatementBiz = objAttendanceStatement });
                }
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementBiz objAttendanceStatementBiz)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.AttendanceStatment = objAttendanceStatementBiz.ID;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementCol objAttendanceStatementCol)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.AttendanceStatmentIDs = objAttendanceStatementCol.IDs;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementCol objAttendanceStatementCol, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.AttendanceStatmentIDs = objAttendanceStatementCol.IDs;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementCol objAttendanceStatementCol, SectorBiz objSectorBiz,
            byte byIsEndStatement, byte byEstimationStatus, EstimationStatementBiz objEstimationStatementBiz) // byIsEndStatement 0 nothing ,1 Work ,2 End Statement 
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectorFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;


            
            objDb.AttendanceStatmentIDs = objAttendanceStatementCol.IDs;
            objDb.IsEndStatementSearch = byIsEndStatement;
            objDb.EstimationStatusSearch = byEstimationStatus;
            objDb.EstimationStatementIDSearch = objEstimationStatementBiz.ID;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementCol objAttendanceStatementCol, SectorBiz objSectorBiz,
            byte byIsEndStatement, byte byEstimationStatus, EstimationStatementCol objEstimationStatementCol) // byIsEndStatement 0 nothing ,1 Work ,2 End Statement 
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();

            if (objSectorBiz.ID != 0 && objSectorBiz.ID == objSectorBiz.FamilyID)
            {
                objDb.SectorFamilyID = objSectorBiz.ID;
            }
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;



            objDb.AttendanceStatmentIDs = objAttendanceStatementCol.IDs;
            objDb.IsEndStatementSearch = byIsEndStatement;
            objDb.EstimationStatusSearch = byEstimationStatus;
            objDb.EstimationStatementIDsSearch = objEstimationStatementCol.IDsStr;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(AttendanceStatementCol objAttendanceStatementCol, byte byIsEndStatement) // byIsEndStatement 0 nothing ,1 Work ,2 End Statement 
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.AttendanceStatmentIDs = objAttendanceStatementCol.IDs;
            objDb.IsEndStatementSearch = byIsEndStatement;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objApplicantWorkerAttendanceStatementBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objApplicantWorkerAttendanceStatementBiz);
            }
            FillSubSectorBiz();
        }
        public ApplicantWorkerAttendanceStatementCol(UserBiz objUserBiz, bool blStatusSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerAttendanceStatementDb objDb = new ApplicantWorkerAttendanceStatementDb();
            objDb.UserIDSearch = objUserBiz.ID;
            objDb.InsDateStatusSearch = blStatusSearch;
            objDb.InsDateFromSearch = dtFrom;
            objDb.InsDateToSearch = dtTo;
            DataTable dtApplicantWorkerAttendanceStatement = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objBiz;

            foreach (DataRow DR in dtApplicantWorkerAttendanceStatement.Rows)
            {
                objBiz = new ApplicantWorkerAttendanceStatementBiz(DR);
                this.Add(objBiz);
            }
            FillSubSectorBiz();
        }
        #endregion
        #region Public Properties
        public static EstimationStatementBiz EstimationStatementBiz
        {
            set
            {
                _EstimationStatementBiz = value;
            }
        }
        public int TotalMinutes
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.TotalMinutes;
                }
                return Returned;
            }
        }
       
        public double DelayCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayRecommendedCountValue + objBiz.EarlierOutCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double DelayCountRecommendedOnly
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayRecommendedCountValue ;
                }
                return Returned;
            }
        }
        public double EarlierOutCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned +=objBiz.EarlierOutCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double ActualDelayCountValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayCountValue ;
                }
                return Returned;
            }
        }        
        public double ActualDelayCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayCount ;                    
                }
                return Returned;
            }
        }
        public double ActualEarlierOutCountValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.EarlierOutCountValue;
                }
                return Returned;
            }
        }
        public double ActualEarlierOutCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.EarlierOutCount;
                }
                return Returned;
            }
        }
        public double ActualDelayCountActiveDelayLimit
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayCount - (objBiz.AttendanceStatementBiz.DelayLimit * 60);
                }
                return Returned;
            }
        }
        public double DelayDiscount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.DelayRecommendedCountValue + objBiz.EarlierOutCountRecommendedValue;
                }
                return Returned;
            }
        }
      
        public double OverTimeCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.OverTimeCount;
                }
                return Returned;
            }
        }
        public double OverTimeCountValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.OverTimeCountValue;
                }
                return Returned;
            }
        }
        public double OverDayCountValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.OverDayCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double OverDayBonus
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.OverDayCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double OverTimeBonus
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.OverTimeCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double ActualAbsenceDayCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.AbsenceDayCount;
                }
                return Returned;
            }
        }
        public double AbsenceDayCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.AbsenceDayCountValue;
                }
                return Returned;
            }
        }
        public double AbsenceDayDiscount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.AbsenceDayCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double FurloughDiscount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.FurloughDiscountValue;
                }
                return Returned;
            }
        }
        public double FurloughDiscountRecommondedValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.FurloughDiscountRecommendedValue;
                }
                return Returned;
            }
        }
        public double VacationDiscountRecommondedValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.VacationDisCountRecommendedValue;
                }
                return Returned;
            }
        }
        public double NonCountedDays
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.NonCountedDaysRecommendedValue;
                }
                return Returned;
            }
        }
        public double NonCountedDaysDiscount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.NonCountedDaysRecommendedValue;
                }
                return Returned;
            }
        }
        public double RecommendedPartTotalMinutes
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += objBiz.RecommendedTotalMinutes;
                }
                return Returned;
            }
        }

        public int FurloughCount
        {
            get
            {
                int Returned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    Returned += (int)objBiz.FurloughCount;
                }
                return Returned;
            }
        }
        
       
        public float TotalVacationCommonNo // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0;// objBiz.WorkDayCol.TotalVacationCommonNo;
                        
                }

                return flReturned;
            }
        }
        public float VacationAccident // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned +=0;
                }

                return flReturned;
            }
        }
        public float TotalVacationAccidentNo // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0; //objBiz.WorkDayCol.TotalVacationAccidentNo;
                }

                return flReturned;
            }
        }
        
        public float VacationSick // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0;// objBiz.VacationCol.VacationSick;
                }

                return flReturned;
            }
        }

        public float TotalVacationSickNo // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0;// objBiz.WorkDayCol.TotalVacationSickNo;
                }

                return flReturned;
            }
        }
        public float VacationWithoutCommonAndAccident // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0;//objBiz.VacationCol.GetVacationCount(objBiz.AttendanceStatementBiz.StatementFrom,objBiz.AttendanceStatementBiz.StatementTo,true);
                }

                return flReturned;
            }
        }
        public float VacationWithoutCommonAndAccidentAndAbsentDay // الاعتيادى
        {
            get
            {
                float flReturned = 0;
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    flReturned += 0;// objBiz.VacationCol.GetVacationCount(objBiz.AttendanceStatementBiz.StatementFrom, objBiz.AttendanceStatementBiz.StatementTo, true);
                    flReturned += objBiz.AbsenceDayCountValue;
                }

                return flReturned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerAttendanceStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerAttendanceStatementBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        { get
            {
                string Returned = "";
                //string strTemp = this.Cast<ApplicantWorkerAttendanceStatementBiz>().Select(x=>x.ID.ToString()).Concat()
                foreach(ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public virtual void Add(ApplicantWorkerAttendanceStatementBiz objApplicantWorkerAttendanceStatementBiz)
        {
            string strKey = objApplicantWorkerAttendanceStatementBiz.AttendanceStatementBiz.ID.ToString() + "-" + objApplicantWorkerAttendanceStatementBiz.ApplicantWorkerBiz.ID.ToString();
            if (GetIndex(objApplicantWorkerAttendanceStatementBiz) != -1)
                return;
            _AttendanceHash.Add(strKey, Count);
            this.List.Add(objApplicantWorkerAttendanceStatementBiz);
        }
        public int GetIndex(int intID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == intID)
                    return intIndex;
            }
                return -1;
        }
        public int GetIndex(ApplicantWorkerAttendanceStatementBiz objBiz)
        {
            string strKey = objBiz.AttendanceStatementBiz.ID.ToString() + "-" + objBiz.ApplicantWorkerBiz.ID.ToString();
            //for (int intIndex = 0; intIndex < Count; intIndex++)
            //{
            //    if (this[intIndex].ApplicantWorkerBiz.ID  == objBiz.ApplicantWorkerBiz.ID && this[intIndex].AttendanceStatementBiz.ID == objBiz.AttendanceStatementBiz.ID)
            //        return intIndex;
            //}
            if (_AttendanceHash[strKey] != null)
                return (int)_AttendanceHash[strKey];

            return -1;
        }
        Hashtable _AttendanceHash = new Hashtable();
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerAttendanceStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("CourseName"), new DataColumn("Description"),new DataColumn("StatusFromDate"), new DataColumn("FromDate") 
            ,new DataColumn("StatusToDate"),new DataColumn("ToDate")});
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
            {
                //objDr = dtReturned.NewRow();
                //objDr["ApplicantID"] = objBiz.ApplicantID;
                //objDr["CourseName"] = objBiz.CourseName;
                //objDr["Description"] = objBiz.Description;
                //objDr["StatusFromDate"] = objBiz.StatusFromDate;
                //objDr["StatusToDate"] = objBiz.StatusToDate;
                //objDr["FromDate"] = objBiz.FromDate;
                //objDr["ToDate"] = objBiz.ToDate;
                
                //dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        public string SubSectorIDs
        {
            get
            {
                string str = "";
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {                    
                    if (str != "")
                        str += "," + objBiz.SubSectorID.ToString();
                    else
                        str =objBiz.SubSectorID.ToString();
                }
                return str;
            }
        }
        public string ApplicantIDs
        {
            get
            {
                string str = "";
                foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.ApplicantWorkerBiz.ID.ToString();
                    else
                        str = objBiz.ApplicantWorkerBiz.ID.ToString();
                }
                return str;
            }
        }
        void FillSubSectorBiz()
        {
            SubSectorCol objSubsectorCol = new SubSectorCol(SubSectorIDs);
            //string s = objSubsectorCol            
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
            {
                try
                {
                    if (objBiz.SubSectorID != 0)
                        objBiz.SubSectorBiz = (SubSectorBranchBiz)objSubsectorCol[objSubsectorCol.GetIndex(objBiz.SubSectorID)];                
                }
                catch
                {                    
                 
                }
                
            }
        }
        #endregion
        #region Public Methods
        public ApplicantWorkerAttendanceStatementCol GetAttendanceStatement(DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerAttendanceStatementCol objCol = new ApplicantWorkerAttendanceStatementCol(true);
            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day);
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
            {
                DateTime dtStatementFrom = new DateTime(objBiz.AttendanceStatementBiz.StatementFrom.Year, objBiz.AttendanceStatementBiz.StatementFrom.Month, objBiz.AttendanceStatementBiz.StatementFrom.Day);
                DateTime dtStatementTo = new DateTime(objBiz.AttendanceStatementBiz.StatementTo.Year, objBiz.AttendanceStatementBiz.StatementTo.Month, objBiz.AttendanceStatementBiz.StatementTo.Day);

                if (

                    (dtStatementFrom >= dtFrom && dtStatementFrom <= dtTo)
                    ||
                    (dtStatementTo >= dtFrom && dtStatementTo <= dtTo)
                    ||
                    (dtStatementFrom <= dtFrom && dtStatementTo >= dtFrom)
                    ||
                    (dtStatementFrom <= dtTo && dtStatementTo >= dtTo)
                    )
                {
                    objCol.Add(objBiz);
                }

            }
            return objCol;
        }
        public DataTable GetWorkDayPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EmpNo"), new DataColumn("Name"),new DataColumn("Sector"), new DataColumn("Department") });
            Hashtable hsWorkDay = new Hashtable();
            Hashtable hsApplicantWorkDay = new Hashtable();
            SetWorkDayFlatCol(out hsWorkDay, out hsApplicantWorkDay);
            string strColumnName = "";
            foreach (DateTime objDate in hsWorkDay.Values.Cast<DateTime>().OrderBy(x => x.Date))
            {
                strColumnName = objDate.ToString("MM-dd-ddd");
                Returned.Columns.Add(strColumnName);

            }
            DataRow objDr;
            string strKey = "";
            WorkDayFlatBiz objFlatBiz;
            List<ApplicantWorkerAttendanceStatementBiz> objStatementCol = (from objAttendance in this.Cast<ApplicantWorkerAttendanceStatementBiz>()
                                                                          orderby objAttendance.SectorBiz.Name, objAttendance.DepartmentBiz.Name, objAttendance.ApplicantWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz.JobCategory.OrderValue, objAttendance.ApplicantWorkerBiz.Name
                                                                          select objAttendance).ToList();
            string strSectorName = "";
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in objStatementCol)
            {
                strSectorName = objBiz.ApplicantWorkerBiz.CurrentSubSectorBiz.SubSectorBiz.SectorName;
                objDr = Returned.NewRow();
                objDr["EmpNo"] = objBiz.ApplicantWorkerBiz.Code;
                objDr["Name"] = objBiz.ApplicantWorkerBiz.Name;
                objDr["Sector"] = objBiz.SectorBiz.Name;
                objDr["Department"] = objBiz.DepartmentBiz.Name;
                for (int intColumn=3;intColumn<Returned.Columns.Count;intColumn++)
                {
                    strKey =  objBiz.ID.ToString() +"-"+ Returned.Columns[intColumn].ColumnName;
                    if(hsApplicantWorkDay[strKey] !=null)
                    {
                        objFlatBiz =(WorkDayFlatBiz) hsApplicantWorkDay[strKey];
                        objDr[intColumn] = objFlatBiz.DisplayStr;
                    }    
                  //  objDr[intColumn] = 
                }

                Returned.Rows.Add(objDr);
            }
            return Returned;
            
        }
        public DataTable GetAttendanceStatementWorkDayPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("من"),new DataColumn("الى"),new DataColumn("التأخبر"), new DataColumn("الاضافى"), new DataColumn("الغياب") ,new DataColumn("الاجازات"),new DataColumn("الاذونات") });
            Hashtable hsWorkDay = new Hashtable();
            Hashtable hsApplicantWorkDay = new Hashtable();
            SetWorkDayFlatCol(out hsWorkDay, out hsApplicantWorkDay);
            string strColumnName = "";
            foreach (DateTime objDate in hsWorkDay.Values.Cast<DateTime>().OrderBy(x => x.Date))
            {
                strColumnName = objDate.ToString("MM-dd-ddd");
                Returned.Columns.Add(strColumnName);

            }
            DataRow objDr;
            string strKey = "";
            WorkDayFlatBiz objFlatBiz;
            List<ApplicantWorkerAttendanceStatementBiz> objStatementCol = (from objAttendance in this.Cast<ApplicantWorkerAttendanceStatementBiz>()
                                                                           orderby objAttendance.DateFrom
                                                                           select objAttendance).ToList();
            string strSectorName = "";
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in objStatementCol)
            {
                strSectorName = objBiz.ApplicantWorkerBiz.CurrentSubSectorBiz.SubSectorBiz.SectorName;
                objDr = Returned.NewRow();
                objDr[0] = objBiz.AttendanceStatementBiz.StatementFrom.Date.ToString("MM-dd");
                objDr[1] = objBiz.AttendanceStatementBiz.StatementTo.Date.ToString("MM-dd");
                objDr[2] = PeriodBiz.GetTimeString((double)objBiz.DelayCount);
                objDr[3] = PeriodBiz.GetTimeString((double)objBiz.OverTimeCount);
                objDr[4] = objBiz.AbsenceDayCount.ToString();
                objDr[5] = objBiz.VacationDayCount.ToString();
                objDr[6] = objBiz.FurloughCount.ToString();
                for (int intColumn = 7; intColumn < Returned.Columns.Count; intColumn++)
                {
                    strKey = objBiz.ID.ToString() + "-" + Returned.Columns[intColumn].ColumnName;
                    if (hsApplicantWorkDay[strKey] != null)
                    {
                        objFlatBiz = (WorkDayFlatBiz)hsApplicantWorkDay[strKey];
                        if (objBiz.IsSum && objFlatBiz.IsAbsent)
                            objDr[intColumn] = "";
                        else
                           objDr[intColumn] = objFlatBiz.DisplayStr;
                    }
                    //  objDr[intColumn] = 
                }

                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
     
        public void SetWorkDayFlatCol(out Hashtable hsWorkDay, out Hashtable hsApplicantWorkDay)
        {

            hsApplicantWorkDay = new Hashtable();
            hsWorkDay = new Hashtable();
            WorkDayFlatDb objDb = new WorkDayFlatDb();
            objDb.StatementIDs = IDsStr;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            string strKey = "";
            string strDay = "";
            foreach (ApplicantWorkerAttendanceStatementBiz objBiz in this)
            {
                arrDr = dtTemp.Select("ApplicantAttendanceStatement=" + objBiz.ID.ToString(), "WorkDayDate asc");
                objBiz.WorkDayFlatCol = new WorkDayFlatCol(true);
                WorkDayFlatBiz objWorkDayBiz;
                foreach (DataRow objDr in arrDr)
                {
                    objWorkDayBiz = new WorkDayFlatBiz(objDr);
                    strDay = objWorkDayBiz.Date.Date.ToString("MM-dd-ddd");

                    if (hsWorkDay[strDay] == null)
                        hsWorkDay.Add(strDay, objWorkDayBiz.Date.Date);
                    strKey = objWorkDayBiz.ApplicantAttendanceStatement.ToString() + "-" + strDay;
                    if (hsApplicantWorkDay[strKey] == null)
                        hsApplicantWorkDay.Add(strKey, objWorkDayBiz);
                    objBiz.WorkDayFlatCol.Add(objWorkDayBiz);
                }

            }
        }
        #endregion
    }
}
