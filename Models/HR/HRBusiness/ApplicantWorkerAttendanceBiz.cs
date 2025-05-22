using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerAttendanceBiz
    {
        #region Private Data
        protected ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb;
        protected ApplicantWorkerBiz _ApplicantWorkerBiz;
        //protected AttendanceStatementBiz _AttendanceStatementBiz;
        protected ApplicantWorkDayCol _ApplicantWorkDayCol;
        bool _IsVisited = false;
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceBiz()
        {
            _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            //_AttendanceStatementBiz = new AttendanceStatementBiz();
        }
        public ApplicantWorkerAttendanceBiz(DataRow objDR)
        {
            _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb(objDR);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDR);
            //_AttendanceStatementBiz = new AttendanceStatementBiz(objDR);
        }
        #endregion
        #region Public Properties
        public int ApplicantAttendanceID
        {
            set
            {
                _ApplicantWorkerAttendanceDb.ApplicantAttendanceID = value;
            }
            get
            {
                return _ApplicantWorkerAttendanceDb.ApplicantAttendanceID;
            }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set
            {
                _ApplicantWorkerBiz = value;
            }
            get
            {
                return _ApplicantWorkerBiz;
            }
        }
        public DateTime AttendanceTime
        {
            set
            {
                _ApplicantWorkerAttendanceDb.AttendanceTime = value;
            }
            get
            {
                return _ApplicantWorkerAttendanceDb.AttendanceTime;
            }
        }
        public int AttandanceType
        {
            set
            {
                _ApplicantWorkerAttendanceDb.AttandanceType = value;
            }
            get
            {
                return _ApplicantWorkerAttendanceDb.AttandanceType;
            }
        }
        public int AttendanceStatement
        {
            set
            {
                _ApplicantWorkerAttendanceDb.AttendanceStatement = value;
            }
            get
            {
                return _ApplicantWorkerAttendanceDb.AttendanceStatement;
            }
        }
        public ApplicantWorkDayCol ApplicantWorkDayCol
        {
            set
            {
                _ApplicantWorkDayCol = value;
            }
            get
            {
                return _ApplicantWorkDayCol;
            }
        }
        public string StrApplicantWorkerName
        {
            get
            {
                return ApplicantWorkerBiz.Name;
            }
        }
        public string StrAttandanceType
        {            
            get
            {
                if (AttandanceType == 0)
                    return "O";
                else
                    return "I";
            }
        }
        public bool IsVisited
        {
            set
            {
                _IsVisited = value;
            }
            get
            {
                return _IsVisited;
            }
        }
        public static bool IsUserDateClosed
        {
            get
            {
                ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();

                objDb.UserID = SysData.CurrentUser.ID;
                objDb.CloseDate = DateTime.Now;

                return objDb.IsUserClosed();
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerAttendanceDb.Applicant = ApplicantWorkerBiz.ID;
            //_ApplicantWorkerAttendanceDb.AttendanceStatement = AttendanceStatementBiz.StatementID;
            _ApplicantWorkerAttendanceDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerAttendanceDb.Applicant = ApplicantWorkerBiz.ID;
            //_ApplicantWorkerAttendanceDb.AttendanceStatement =  _AttendanceStatementBiz.StatementID;
            _ApplicantWorkerAttendanceDb.Edit();
        }
        public void EditAttendanceType()
        {
            _ApplicantWorkerAttendanceDb.EditAttendanceType();
        }
        public void Delete()
        {
            _ApplicantWorkerAttendanceDb.Applicant = ApplicantWorkerBiz.ID;            
            _ApplicantWorkerAttendanceDb.Delete();
        }
        public static void AddMultipleCheck( ApplicantWorkerCol objCol, bool blInput, DateTime dtTime)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.AttendanceTime = dtTime;
            objDb.AttandanceType = blInput ? 1 : 0;
            objDb.ApplicantIDs =objCol.IDs;
            objDb.AddMultiple();

        }
        public static void UploadData(DataTable dtTemp)
        {
            if (dtTemp == null || dtTemp.Rows.Count == 0)
                return;
           // DataTable dtTemp = GetUploadTable();
            ApplicantWorkerAttendanceDb objDB = new ApplicantWorkerAttendanceDb();
            objDB.AttendanceTable = dtTemp;
            objDB.UploadCheckInOut();
        }
        public static void CloseUserAttendanceDate(int intUserID, DateTime dtDate)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.UserID = intUserID;
            objDb.CloseDate = dtDate;
            objDb.CloseUserDate();

        }
        public static void CloseUserAttendanceDate(int intUserID
            , DateTime dtStartDate,DateTime dtEndDate)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.UserID = intUserID;
            objDb.CloseStartDate = dtStartDate;
            objDb.CloseEndDate = dtEndDate;
            objDb.CloseUserMultipleDate();

        }
        public static void OpenUserAttendanceDate(int intUserID, DateTime dtDate)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.UserID = intUserID;
            objDb.CloseDate = dtDate;
            objDb.OpenUserDate();

        }
        public static void OpenUserAttendanceDate(int intUserID, 
            DateTime dtStartDate,DateTime dtEndDate)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.UserID = intUserID;
            objDb.CloseStartDate = dtStartDate;
            objDb.CloseEndDate = dtEndDate;
            objDb.OpenUserMultipleDate();

        }
        public static Hashtable GetApplicantClosedDate(int intUserID,DateTime dtStartDate,DateTime dtEndDate)
        {
            Hashtable Returned = new Hashtable();
            if (intUserID == 0)
                return Returned;
            ApplicantWorkerAttendanceDb objDb =
                new ApplicantWorkerAttendanceDb();
            objDb.UserID = intUserID;
            objDb.CloseStartDate = dtStartDate;
            objDb.CloseEndDate = dtEndDate;

            DataTable dtTemp = objDb.GetClosDate();
            string strTemp;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                strTemp = objDr["DateStr"].ToString();
                if (Returned[strTemp] == null)
                    Returned.Add(strTemp, strTemp);
            }
            return Returned;
        }
        public static void SetAttendaceSummary(bool blIsSummary,ApplicantWorkerCol objCol)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.IDsStr = objCol.IDs;
            objDb.IsSummary = blIsSummary;
            objDb.EditSummary();


        }
        #endregion
    }
}
