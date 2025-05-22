using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerAttendanceStatementDb
    {
        #region Private Data
        protected int _ID;
        bool _IsSum;
        protected int _AttendanceStatment;
        protected int _TotalMinutes;
        protected int _RecommendedTotalMinutes;
        protected int _FormalTotalMinutes;
        protected int _Applicant;
        protected float _DelayLimit;
        protected float _DelayCount;
        protected float _DelayCountValue;
        protected float _DelayCountRecommendedValue;

        protected float _EarlierOutCount;
        protected float _EarlierOutCountValue;
        protected float _EarlierOutCountRecommendedValue;

        protected float _OverTimeCount;
        protected float _OverTimeCountValue;
        protected float _OverTimeCountRecommendedValue;

        protected double _OverDayCount;
        protected double _OverDayCountRecommendedValue;


        protected float _FurloughCount;
        protected float _FurloughDiscountValue;
        protected float _FurloughDiscountRecommendedValue;


        protected float _AbsenceDayCount;
        protected float _AbsenceDayCountValue;
        protected float _AbsenceDayCountRecommendedValue;

        protected float _NonCountedDays;
        protected float _NonCountedDaysValue;
        protected float _NonCountedDaysRecommendedValue;

        protected float _VacationDayCount;
        protected float _VacationDisCount;
        protected float _VacationDisCountRecommendedValue;

        protected double _GeneratedBankingTime;
        protected double _ConsumedBankingTime;
        protected string _ApplicantIDs;
        protected string _AttendanceStatmentIDs;
        protected int _EstimationStatementIDSearch;
        protected string _EstimationStatementIDsSearch;
        protected int _FinancialStatement;
        string _FinancialStatementIDs;

        
        protected int _JobNature;
        protected int _JobCategoryEstimation;
        protected int _SubSector;
        DateTime _DateFrom;
        DateTime _DateTo;
        byte _FinancialStatementStatus;//0
        byte _RecommenedValueStatus;
        //1 no fin
        //2 only has 
        byte _SumSearchStatus;
        protected bool _InsDateStatusSearch;
        protected DateTime _InsDateFromSearch;
        protected DateTime _InsDateToSearch;
        int _UserIDSearch;
        protected bool _IsEndStatement;
        protected byte _IsEndStatementSearch; // byIsEndStatement 0 nothing ,1 Work ,2 End Statement 
        protected byte _EstimationStatusSearch; // byIsEndStatement 0 nothing ,1 Work ,2 End Statement 
        
        string _Remarks;
        protected DataTable _AttendanceTable;
        protected DataTable _DeletedAttendanceTable;
        DataTable _BonusTable;
        DataTable _AttandanceStatementTable;
        public DataTable AttandanceStatementTable
        {
            set
            { _AttandanceStatementTable = value; }
        }
        public DataTable BonusTable
        {
            get { return _BonusTable; }
            set { _BonusTable = value; }
        }
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceStatementDb()
        {
        }
        public ApplicantWorkerAttendanceStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ApplicantWorkerAttendanceStatementDb(int intApplicantID, int intAttendanceStatementID)
        {
            _Applicant = intApplicantID;
            _AttendanceStatment = intAttendanceStatementID;
            if (_Applicant != 0 && _AttendanceStatment != 0)
            {
                DataTable dtTemp = Search();
                if (dtTemp.Rows.Count > 0)
                    SetData(dtTemp.Rows[0]);
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Remarks { set { _Remarks = value; } get { return _Remarks; } }
        public int AttendanceStatment
        {
            set
            {
                _AttendanceStatment = value;
            }
            get
            {
                return _AttendanceStatment;
            }
        }
        public int TotalMinutes
        {
            set
            {
                _TotalMinutes = value;
            }
            get
            {
                return _TotalMinutes;
            }
        }
        public int RecommendedTotalMinutes
        {
            set
            {
                _RecommendedTotalMinutes = value;
            }
            get
            {
                return _RecommendedTotalMinutes;
            }
        }
        public int FormalTotalMinutes
        {
            set
            {
                _FormalTotalMinutes = value;
            }
            get
            {
                return _FormalTotalMinutes;
            }
        }
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        public float DelayLimit
        {
            set
            {
                _DelayLimit = value;
            }
            get
            {
                return _DelayLimit;
            }
        }
        public float DelayCount
        {
            set
            {
                _DelayCount = value;
            }
            get
            {
                return _DelayCount;
            }
        }
        public float DelayCountValue
        {
            set
            {
                _DelayCountValue = value;
            }
            get
            {
                return _DelayCountValue;
            }
        }
        public float DelayCountRecommendedValue
        {
            set
            {
                _DelayCountRecommendedValue = value;
            }
            get
            {
                return _DelayCountRecommendedValue;
            }
        }

        public float EarlierOutCount
        {
            set
            {
                _EarlierOutCount = value;
            }
            get
            {
                return _EarlierOutCount;
            }
        }
        public float EarlierOutCountValue
        {
            set
            {
                _EarlierOutCountValue = value;
            }
            get
            {
                return _EarlierOutCountValue;
            }
        }
        public float EarlierOutCountRecommendedValue
        {
            set
            {
                _EarlierOutCountRecommendedValue = value;
            }
            get
            {
                return _EarlierOutCountRecommendedValue;
            }
        }
        public double OverDayCount
        {
            set
            {
                _OverDayCount = value;
            }
            get
            {
                return _OverDayCount;
            }
        }
        public double OverDayCountRecommendedValue
        {
            set
            {
                _OverDayCountRecommendedValue = value;
            }
            get
            {
                return _OverDayCountRecommendedValue;
            }
        }

        public bool InsDateStatusSearch
        {
            set
            {
                _InsDateStatusSearch = value;
            }
            get
            {
                return _InsDateStatusSearch;
            }

        }
        public DateTime InsDateFromSearch
        {
            set
            {
                _InsDateFromSearch = value;
            }
            get
            {
                return _InsDateFromSearch;
            }

        }
        public DateTime InsDateToSearch
        {
            set
            {
                _InsDateToSearch = value;
            }
            get
            {
                return _InsDateToSearch;
            }

        }
        public int UserIDSearch
        {
            set
            {
                _UserIDSearch = value;
            }
        }

        public float OverTimeCount
        {
            set
            {
                _OverTimeCount = value;
            }
            get
            {
                return _OverTimeCount;
            }
        }
        public float OverTimeCountValue
        {
            set
            {
                _OverTimeCountValue = value;
            }
            get
            {
                return _OverTimeCountValue;
            }
        }
        public float OverTimeCountRecommendedValue
        {
            set
            {
                _OverTimeCountRecommendedValue = value;
            }
            get
            {
                return _OverTimeCountRecommendedValue;
            }
        }
        public float FurloughCount
        {
            set
            {
                _FurloughCount = value;
            }
            get
            {
                return _FurloughCount;
            }
        }
        public float FurloughDiscountValue
        {
            set
            {
                _FurloughDiscountValue = value;
            }
            get
            {
                return _FurloughDiscountValue;
            }
        }
        public float FurloughDiscountRecommendedValue
        {
            set
            {
                _FurloughDiscountRecommendedValue = value;
            }
            get
            {
                return _FurloughDiscountRecommendedValue;
            }
        }
        public float AbsenceDayCount
        {
            set
            {
                _AbsenceDayCount = value;
            }
            get
            {
                return _AbsenceDayCount;
            }
        }
        public float AbsenceDayCountValue
        {
            set
            {
                _AbsenceDayCountValue = value;
            }
            get
            {
                return _AbsenceDayCountValue;
            }
        }
        public float AbsenceDayCountRecommendedValue
        {
            set
            {
                _AbsenceDayCountRecommendedValue = value;
            }
            get
            {
                return _AbsenceDayCountRecommendedValue;
            }
        }
        public float VacationDayCount
        {
            set
            {
                _VacationDayCount = value;
            }
            get
            {
                return _VacationDayCount;
            }
        }
        public float VacationDisCount
        {
            set
            {
                _VacationDisCount = value;
            }
            get
            {
                return _VacationDisCount;
            }
        }
        public float VacationDisCountRecommendedValue
        {
            set
            {
                _VacationDisCountRecommendedValue = value;
            }
            get
            {
                return _VacationDisCountRecommendedValue;
            }
        }
        public float NonCountedDays
        {
            set
            {
                _NonCountedDays = value;
            }
            get
            {
                return _NonCountedDays;
            }
        }
        public float NonCountedDaysValue
        {
            set
            {
                _NonCountedDaysValue = value;
            }
            get
            {
                return _NonCountedDaysValue;
            }
        }
        public float NonCountedDaysRecommendedValue
        {
            set
            {
                _NonCountedDaysRecommendedValue = value;
            }
            get
            {
                return _NonCountedDaysRecommendedValue;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _DateFrom = value;
            }
            get
            {
                return _DateFrom;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _DateTo = value;
            }
            get
            {
                return _DateTo;
            }
        }
        public double GenratedBankingTime
        {
            set
            {
                _GeneratedBankingTime = value;
            }
            get
            {
                return _GeneratedBankingTime;
            }
        }
        public double ConsumedBankingTime
        {
            set
            {
                _ConsumedBankingTime = value;
            }
            get
            {
                return _ConsumedBankingTime;
            }
        }
        public int FinancialStatement
        {
            set
            {
                _FinancialStatement = value;
            }
            get
            {
                return _FinancialStatement;
            }
        }
        public string FinancialStatementIDs
        {
            get { return _FinancialStatementIDs; }
            set { _FinancialStatementIDs = value; }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
            get
            {
                return _ApplicantIDs;
            }
        }
        public byte FinancialStatementStatus
        {
            set
            {
                _FinancialStatementStatus = value;
            }
        }
        public byte RecommenedValueStatus
        {
            set
            {
                _RecommenedValueStatus = value;
            }
        }
        public bool IsSum
        {
            set
            {
                _IsSum = value;
            }
            get
            {
                return _IsSum;
            }
        }
        public bool IsEndStatement
        {
            set
            {
                _IsEndStatement = value;
            }
            get
            {
                return _IsEndStatement;
            }
        }
        public byte IsEndStatementSearch
        {
            set
            {
                _IsEndStatementSearch = value;
            }            
        }
        public byte EstimationStatusSearch
        {
            set
            {
                _EstimationStatusSearch = value;
            }
        }
        public int JobNature
        {
            set { _JobNature = value; }
            get { return _JobNature; }
        }
        public int JobCategoryEstimation
        {
            set { _JobCategoryEstimation = value; }
            get { return _JobCategoryEstimation; }
        }
        public int SubSector
        {
            set { _SubSector = value; }
            get { return _SubSector; }
        }
        public byte SumSearchStatus
        {
            set
            {
                _SumSearchStatus = value;
            }
        }
        public string AttendanceStatmentIDs
        {
            set
            {
                _AttendanceStatmentIDs = value;
            }           
        }
        string _SectorIDs;
        int _SectorFamilyID;
        public string SectorIDs
        {
            set
            {
                _SectorIDs = value;
            }
        }
        public int SectorFamilyID
        {
            set
            {
                _SectorFamilyID = value;
            }
        }
        public int EstimationStatementIDSearch
        {
            set
            {
                _EstimationStatementIDSearch  = value;
            }
        }
        public string EstimationStatementIDsSearch
        {
            set
            {
                _EstimationStatementIDsSearch = value;
            }
        }
        public DataTable AttendanceTable
        {
            set
            {
                _AttendanceTable = value;
            }
        }
        public DataTable DeletedAttendanceTable
        {
            set
            {
                _DeletedAttendanceTable = value;
            }
        }
        DataTable _WorkdayFlatTbale;
        public DataTable WorkdayFlatTbale { set => _WorkdayFlatTbale = value; }
        public  string SearchStr
        {
            get
            {
                string StrReturn = " SELECT     HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID,HRApplicantWorkerAttendanceStatement.AtendanceStatementIsSum, " +
                    "HRApplicantWorkerAttendanceStatement.AttendanceStatment,AttendanceTotalMinutes,AttendanceFormalTotalMinutes,AttendanceRecommendedTotalMinutes, " +
                                   " HRApplicantWorkerAttendanceStatement.Applicant,HRApplicantWorkerAttendanceStatement.DelayLimit, HRApplicantWorkerAttendanceStatement.DelayCount,HRApplicantWorkerAttendanceStatement.EarlierOutCount" +
                                   " ,HRApplicantWorkerAttendanceStatement.EarlierOutCountValue,HRApplicantWorkerAttendanceStatement.EarlierOutCountRecommendedValue," +
                                   " HRApplicantWorkerAttendanceStatement.OverTimeCount, HRApplicantWorkerAttendanceStatement.FurloughCount,HRApplicantWorkerAttendanceStatement.FurloughDiscountValue,HRApplicantWorkerAttendanceStatement.FurloughDiscountRecommendedValue, " +
                                    " HRApplicantWorkerAttendanceStatement.OverDayCount, HRApplicantWorkerAttendanceStatement.OverDayCountRecommendedValue, " +
                                   " HRApplicantWorkerAttendanceStatement.AbsenceDayCount, HRApplicantWorkerAttendanceStatement.VacationDayCount ,ApplicantWorkerTable.*,AttendanceStatementTable.*" +
                                   ",HRApplicantWorkerAttendanceStatement.GeneratedBankingTime,HRApplicantWorkerAttendanceStatement.ConsumedBankingTime " +
                                   ",DelayCountValue, DelayCountRecommendedValue, OverTimeCountValue, OverTimeCountRecommendedValue, AbsenceDayCountValue,IsEndStatement, " +
                                    " AbsenceDayCountRecommendedValue, NonCountedDays, NonCountedDaysValue, NonCountedDaysRecommendedValue, FinancialStatement," +
                                   "HRApplicantWorkerAttendanceStatement.DateFrom,HRApplicantWorkerAttendanceStatement.DateTo,HRApplicantWorkerAttendanceStatement.Remarks, " +
                                   " HRApplicantWorkerAttendanceStatement.SubSector,HRApplicantWorkerAttendanceStatement.JobNature,JobNatureTypeTable.*" +
                                   " ,HRApplicantWorkerAttendanceStatement.VacationDisCount,HRApplicantWorkerAttendanceStatement.VacationDisCountRecommendedValue"+
                                   " ,HRApplicantWorkerAttendanceStatement.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                                    " FROM         HRApplicantWorkerAttendanceStatement " +
                                   " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable ON ApplicantWorkerTable.ApplicantID = HRApplicantWorkerAttendanceStatement.Applicant " +
                                   " Left Outer Join (" + AttendanceStatementDb.SearchStr + ") AttendanceStatementTable On AttendanceStatementTable.StatementID = HRApplicantWorkerAttendanceStatement.AttendanceStatment "+
                                   " Left Outer join (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable On JobNatureTypeTable.JobNatureID = HRApplicantWorkerAttendanceStatement.JobNature "+
                                   " Left Outer join (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable On JobCategoryEstimationTable.JobCategoryEstimationID = HRApplicantWorkerAttendanceStatement.JobCategoryEstimation ";
                if (_AttendanceStatment != 0)
                {
                    string strAttendance = "SELECT    ApplicantAttendanceStatmentID, AttendanceStatment, Applicant " +
                           " FROM      dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment "+
                           " where  AttendanceStatment = "+ _AttendanceStatment;
                    StrReturn += " inner join ("+ strAttendance +") as AttendanceStatementTable1 "+
                        "  on HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID = AttendanceStatementTable1.ApplicantAttendanceStatmentID "+
                        "  and HRApplicantWorkerAttendanceStatement.AttendanceStatment = AttendanceStatementTable1.AttendanceStatment  "+
                        " and HRApplicantWorkerAttendanceStatement.Applicant = AttendanceStatementTable1.Applicant ";
                }
                return StrReturn;
            }
        }
        public string AddStr
        {
            get
            {

                int intIsSum = _IsSum ? 1 : 0;
                int intIsEndStatement = _IsEndStatement ? 1 : 0;
                double dblDateTo = _DateTo.ToOADate() - 2;
                double dblDateFrom = _DateFrom.ToOADate() - 2;


                string StrReturn = "INSERT INTO HRApplicantWorkerAttendanceStatement" +
                      " (AtendanceStatementIsSum,AttendanceStatment,AttendanceTotalMinutes,AttendanceRecommendedTotalMinutes," +
                      " AttendanceFormalTotalMinutes, Applicant, " +
                      " DelayLimit,DelayCount,EarlierOutCount,EarlierOutCountValue, OverTimeCount,OverDayCount, FurloughCount,FurloughDiscountValue," +
                      " AbsenceDayCount, VacationDayCount" +
                      ",GeneratedBankingTime,ConsumedBankingTime,NonCountedDays " +
                      ",DateFrom,DateTo,SubSector,JobNature,VacationDisCount,IsEndStatement,JobCategoryEstimation,Remarks, UsrIns, TimIns)" +
                                   " VALUES (" + intIsSum + "," + _AttendanceStatment + "," + _TotalMinutes + "," + _RecommendedTotalMinutes + "," +
                                   " " + _FormalTotalMinutes + "," + _Applicant + "," +
                                   " " + _DelayLimit + "," + _DelayCount + "," + _EarlierOutCount + "," + _EarlierOutCountValue + "," + _OverTimeCount + "," + _OverDayCount + "," + _FurloughCount + "," + _FurloughDiscountValue + "," +
                                   "" + _AbsenceDayCount + "," + _VacationDayCount + "," + _GeneratedBankingTime + "," +
                                   "" + _ConsumedBankingTime + "," + _NonCountedDays + "," + dblDateFrom + "," + dblDateTo + "," + _SubSector + "," + _JobNature + "," +
                                   "" + _VacationDisCount + " ," + intIsEndStatement + "," +
                                   "" + _JobCategoryEstimation + ",'" + _Remarks + "'," + SysData.CurrentUser.ID + ",GetDate())";
                return StrReturn;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDateTo = _DateTo.ToOADate() - 2;
                double dblDateFrom = _DateFrom.ToOADate() - 2;
                int intIsEndStatement = _IsEndStatement ? 1 : 0;
                string StrReturn = " UPDATE    HRApplicantWorkerAttendanceStatement" +
                                   " SET " +
                                   "  DelayCount = " + _DelayCount + "" +
                                   ", DelayLimit = " + _DelayLimit + "" +
                                   ", AttendanceTotalMinutes=" + _TotalMinutes + "" +
                                   ", AttendanceRecommendedTotalMinutes=" + _RecommendedTotalMinutes + "" +
                                   ", AttendanceFormalTotalMinutes=" + _FormalTotalMinutes + "" +
                                   ", EarlierOutCount=" + _EarlierOutCount + "" +
                                   ", EarlierOutCountValue=" + _EarlierOutCountValue + "" +
                                   ", OverTimeCount =" + _OverTimeCount + "" +
                                   ", OverDayCount =" + _OverDayCount + "" +
                                   ", FurloughCount =" + _FurloughCount + "" +
                                   ", FurloughDiscountValue =" + _FurloughDiscountValue + "" +
                                   ", AbsenceDayCount =" + _AbsenceDayCount + "" +
                                   ", VacationDayCount =" + _VacationDayCount + "" +
                                   ", GeneratedBankingTime =" + _GeneratedBankingTime + "" +
                                   ", ConsumedBankingTime =" + _ConsumedBankingTime + "" +
                                   ", NonCountedDays =" + _NonCountedDays +
                                   ", DateFrom =" + dblDateFrom +
                                   ", DateTo =" + dblDateTo +
                                   ", VacationDisCount = " + _VacationDisCount + "" +
                                   ", IsEndStatement=" + intIsEndStatement + "" +
                                   " , SubSector =" + _SubSector + "" +
                                  " , JobNature =" + _JobNature + "" +
                                  " , JobCategoryEstimation = " + _JobCategoryEstimation + "" +
                                  " , Remarks = '" + _Remarks + "'" +
                    //", VacationDisCountRecommendedValue = " + _VacationDisCountRecommendedValue + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd = GetDate()" +
                    //               " WHERE  (FinancialStatement=0) and   (ApplicantAttendanceStatmentID = " + _ApplicantAttendanceStatmentID + ") AND (Applicant = " + _Applicant + ")";
                " WHERE  (ApplicantAttendanceStatmentID = " + _ID + ") AND (Applicant = " + _Applicant + ")";
                //
                return StrReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string StrReturn = " Delete From HRApplicantWorkerAttendanceStatement" +
                                   " WHERE   (FinancialStatement=0) and  (ApplicantAttendanceStatmentID = " + _ID + ") AND (Applicant = " + _Applicant + ")";
                return StrReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ApplicantAttendanceStatmentID"].ToString());
            _IsSum = bool.Parse(objDr["AtendanceStatementIsSum"].ToString());
            if (objDr["IsEndStatement"].ToString() != "")
                _IsEndStatement = bool.Parse(objDr["IsEndStatement"].ToString());
            _AttendanceStatment = int.Parse(objDr["AttendanceStatment"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());
            _TotalMinutes = int.Parse(objDr["AttendanceTotalMinutes"].ToString());
            if (objDr["AttendanceRecommendedTotalMinutes"].ToString() != "")
                _RecommendedTotalMinutes = int.Parse(objDr["AttendanceRecommendedTotalMinutes"].ToString());
            _FormalTotalMinutes = int.Parse(objDr["AttendanceFormalTotalMinutes"].ToString());
            _DelayLimit = float.Parse(objDr["DelayLimit"].ToString());
            _DelayCount = float.Parse(objDr["DelayCount"].ToString());
            _OverTimeCount = float.Parse(objDr["OverTimeCount"].ToString());
            _FurloughCount = float.Parse(objDr["FurloughCount"].ToString());
            _FurloughDiscountValue = float.Parse(objDr["FurloughDiscountValue"].ToString());
            _FurloughDiscountRecommendedValue = float.Parse(objDr["FurloughDiscountRecommendedValue"].ToString());

            _AbsenceDayCount = float.Parse(objDr["AbsenceDayCount"].ToString());

            _VacationDayCount = float.Parse(objDr["VacationDayCount"].ToString());
            _VacationDisCount = float.Parse(objDr["VacationDisCount"].ToString());
            _VacationDisCountRecommendedValue = float.Parse(objDr["VacationDisCountRecommendedValue"].ToString());

            _DelayCountValue = float.Parse(objDr["DelayCountValue"].ToString());
            _DelayCountRecommendedValue = float.Parse(objDr["DelayCountRecommendedValue"].ToString());
            _FinancialStatement = int.Parse(objDr["FinancialStatement"].ToString());
            _OverTimeCountValue = float.Parse(objDr["OverTimeCountValue"].ToString());
            _OverTimeCountRecommendedValue = float.Parse(objDr["OverTimeCountRecommendedValue"].ToString());
            _OverDayCount = double.Parse(objDr["OverDayCount"].ToString());
            _OverDayCountRecommendedValue =
                double.Parse(objDr["OverDayCountRecommendedValue"].ToString());
            _EarlierOutCount = float.Parse(objDr["EarlierOutCount"].ToString());
            _EarlierOutCountValue = float.Parse(objDr["EarlierOutCountValue"].ToString());
            _EarlierOutCountRecommendedValue =
                float.Parse(objDr["EarlierOutCountRecommendedValue"].ToString());
            _DelayCountValue = float.Parse(objDr["DelayCountValue"].ToString());
            _DelayCountRecommendedValue = float.Parse(objDr["DelayCountRecommendedValue"].ToString());

            _AbsenceDayCountValue = float.Parse(objDr["AbsenceDayCountValue"].ToString());
            _AbsenceDayCountRecommendedValue = float.Parse(objDr["AbsenceDayCountRecommendedValue"].ToString());
            _NonCountedDays = float.Parse(objDr["NonCountedDays"].ToString());
            _NonCountedDaysValue = float.Parse(objDr["NonCountedDaysValue"].ToString());
            _NonCountedDaysRecommendedValue = float.Parse(objDr["NonCountedDaysRecommendedValue"].ToString());
            if (objDr["DateFrom"].ToString() != "")
                _DateFrom = DateTime.Parse(objDr["DateFrom"].ToString());
            if (objDr["DateTo"].ToString() != "")
                _DateTo = DateTime.Parse(objDr["DateTo"].ToString());

            if (objDr["SubSector"].ToString() != "")
                _SubSector = int.Parse(objDr["SubSector"].ToString());
            if (objDr["JobNature"].ToString() != "")
                _JobNature = int.Parse(objDr["JobNature"].ToString());

            _Remarks = objDr["Remarks"].ToString();
            int x;
            if(_Applicant==84)
                x=0;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void JoinAttendanceCol()
        {
            if (_DeletedAttendanceTable == null && _AttendanceTable == null)
                return;
            if (_DeletedAttendanceTable.Rows.Count == 0 && _AttendanceTable.Rows.Count ==0)
                return;
            List<string> lstDeletedAttendance = new List<string>();
            if(_DeletedAttendanceTable!= null)
                lstDeletedAttendance = SysUtility.GetStringArr(_DeletedAttendanceTable, "ApplicantAttendanceID", 5000);
            List<string> arrStr = new List<string>();//string[_AttendanceTable.Rows.Count + lstDeletedAttendance.Count];
            ApplicantWorkerAttendanceDb objDb ;
            int intIndex = 0;
            foreach (DataRow objDr in _AttendanceTable.Rows )
            {
                objDb = new ApplicantWorkerAttendanceDb(objDr);
               // objDb.AttendanceStatement = ID;
                if (objDb.ApplicantAttendanceID == 0)
                {
                    objDb.AttendanceStatement = ID;
                    arrStr.Add( objDb.AddStr);
                }
                else
                {
                    if (objDb.AttendanceStatement == 0)
                    {
                        objDb.AttendanceStatement = ID;
                        arrStr.Add(objDb.EditStr);
                    }
                    else
                    {
                        arrStr.Add(objDb.EditProcessedStr);
                    }

                }
                    intIndex++;
            }
            if (lstDeletedAttendance.Count > 0)
            {
                arrStr.Add( " Update HRApplicantWorkerAttendance Set Dis = GetDate()" +
                                 " WHERE     (Applicant = " + _Applicant + 
                                 ") AND (ApplicantAttendanceID in (" + lstDeletedAttendance[0] + "))");
            }
            string strTransfereData = " insert into HRApplicantWorkerAttendanceProcessed "+
                " ( Applicant, AttendanceTime, AttandanceType, AttendanceStatement, UsrIns, TimIns) "+
                " SELECT        Applicant, AttendanceTime, AttandanceType, AttendanceStatement, UsrIns, TimIns "+
                 " FROM            dbo.HRApplicantWorkerAttendance "+
                  " WHERE   (Applicant=" + _Applicant + ")  and       (Dis IS NULL) AND (AttendanceStatement = " + _ID + ") ";
            strTransfereData += " delete FROM            dbo.HRApplicantWorkerAttendance " +
                  " WHERE      (Applicant="+ _Applicant +") and (Dis IS NULL) AND (AttendanceStatement = " + _ID + ") ";
            arrStr.Add(strTransfereData);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
 

        }
        public void EditFinancialStatement()
        {
            string strSql = "  UPDATE    HRApplicantWorkerAttendanceStatement" +
                            "  SET DelayCountValue = " + _DelayCountValue + "" +
                //", DelayLimit = "+ _DelayLimit +""+
                            ", DelayCountRecommendedValue =" + _DelayCountRecommendedValue + "" +
                            ", AttendanceRecommendedTotalMinutes=" + _RecommendedTotalMinutes + "" +
                            ", EarlierOutCountValue=" + _EarlierOutCountValue + "" +
                            ", EarlierOutCountRecommendedValue=" + _EarlierOutCountRecommendedValue + "" +
                            ", OverDayCountRecommendedValue=" + _OverDayCountRecommendedValue + "" +
                            ", OverTimeCountValue =" + _OverTimeCountValue + "" +
                            ", OverTimeCountRecommendedValue =" + _OverTimeCountRecommendedValue + "" +
                            ", AbsenceDayCountValue =" + _AbsenceDayCountValue + "" +
                            ", AbsenceDayCountRecommendedValue =" + _AbsenceDayCountRecommendedValue + "" +
                            ", NonCountedDaysValue =" + _NonCountedDaysValue + "" +
                            ", NonCountedDaysRecommendedValue =" + _NonCountedDaysRecommendedValue +
                            ", FurloughDiscountRecommendedValue = " + _FurloughDiscountRecommendedValue + "" +
                            ", VacationDiscountRecommendedValue = " + _VacationDisCountRecommendedValue + "" +
                            ", FinancialStatement=" + _FinancialStatement +
                            ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd = GetDate()" +
                            " WHERE     (ApplicantAttendanceStatmentID = " + _ID + ") AND (Applicant = " + _Applicant + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strProcessed = " insert into  dbo.HRApplicantWorkerAttendance (Applicant, AttendanceTime, AttandanceType, AttendanceStatement, UsrIns, TimIns) "+
                " SELECT        Applicant, AttendanceTime, AttandanceType, 0 AS AttendanceStatement1, UsrIns, TimIns "+
                " FROM            dbo.HRApplicantWorkerAttendanceProcessed "+
                " WHERE        (Dis IS NULL) AND (AttendanceStatement = "+ ID +") " ;
            strProcessed += " " + DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strProcessed);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_Applicant != 0)
                StrSql = StrSql + " And (HRApplicantWorkerAttendanceStatement.Applicant = " + _Applicant + ")";
            if (_AttendanceStatment != 0)
            {
              //  StrSql = StrSql + " And (HRApplicantWorkerAttendanceStatement.AttendanceStatment = " + _AttendanceStatment + ")";
                if (_SumSearchStatus != 0)
                {
                    if (_SumSearchStatus == 1)
                    {
                        StrSql += " and AtendanceStatementIsSum=0";
                    }
                    else if (_SumSearchStatus == 2)
                        StrSql += " and AtendanceStatementIsSum=1";
                }
            }
            if (_AttendanceStatmentIDs != null && _AttendanceStatmentIDs!="")
            {
                StrSql = StrSql + " And (HRApplicantWorkerAttendanceStatement.AttendanceStatment in (" + _AttendanceStatmentIDs + "))";
                if (_SumSearchStatus != 0)
                {
                    if (_SumSearchStatus == 1)
                    {
                        StrSql += " and AtendanceStatementIsSum=0";
                    }
                    else if (_SumSearchStatus == 2)
                        StrSql += " and AtendanceStatementIsSum=1";
                }
            }
            if (_InsDateStatusSearch == true)
            {
                double dblFrom = SysUtility.Approximate(_InsDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                double dblTo = SysUtility.Approximate(_InsDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                StrSql = StrSql + " And  HRApplicantWorkerAttendanceStatement.TimIns Between " + dblFrom + " And " + dblTo + "";
            }
            if (_UserIDSearch != 0)
            {
                StrSql += " And HRApplicantWorkerAttendanceStatement.UsrIns = " + _UserIDSearch + "";
            }
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                StrSql = StrSql + " And (HRApplicantWorkerAttendanceStatement.Applicant in ( " + _ApplicantIDs + "))";
            if (_FinancialStatementStatus == 1)
                StrSql += " and HRApplicantWorkerAttendanceStatement.FinancialStatement=0 ";
            if (_FinancialStatement != 0)
                StrSql += " and HRApplicantWorkerAttendanceStatement.FinancialStatement=" + _FinancialStatement;
            if (_FinancialStatementIDs != null && _FinancialStatementIDs != "")
                StrSql += " and HRApplicantWorkerAttendanceStatement.FinancialStatement in ("+ _FinancialStatementIDs +") ";
            if (_RecommenedValueStatus != 0)
            {
                if (_RecommenedValueStatus == 1)
                {
                    StrSql += " And ((DelayCountValue <> DelayCountRecommendedValue) OR " +
                              " (AbsenceDayCountValue <> AbsenceDayCountRecommendedValue) )";
                }

            }
            if (_IsEndStatementSearch != 0)
            {
                if (_IsEndStatementSearch == 1) // not end Statement
                {
                    StrSql += " And (HRApplicantWorkerAttendanceStatement.IsEndStatement = 0)";
                }
                else if (_IsEndStatementSearch == 2) //  end Statement
                {
                    StrSql += " And (HRApplicantWorkerAttendanceStatement.IsEndStatement = 1)";
                }
            }

            if (_SectorIDs != null && _SectorIDs != "")
            {
                string str = " SELECT     SubSectorID FROM         HRSubSector WHERE     (SectorID IN (" + _SectorIDs + "))";
                StrSql += " and ( HRApplicantWorkerAttendanceStatement.SubSector in (" + str + "))";

              //  strSql += " and HRApplicant.ApplicantID in (SELECT   dbo.HRApplicantWorkerCurrentSubSector.ApplicantID " +
              // " FROM         dbo.HRSector INNER JOIN " +
              // " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID INNER JOIN " +
              // " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRSubSector.SubSectorID = dbo.HRApplicantWorkerCurrentSubSector.SubSectorID " +
              //" WHERE     (dbo.HRSector.SectorID IN (" + _SectorIDs + "))) ";
            }
            if (_SectorFamilyID != 0)
            {
                string str = " SELECT     HRSubSector.SubSectorID "+
                             " FROM HRSubSector INNER JOIN HRSector ON HRSubSector.SectorID = HRSector.SectorID "+
                             " WHERE     (HRSector.SectorFamilyID IN (" + _SectorFamilyID + "))";
                StrSql += " and ( HRApplicantWorkerAttendanceStatement.SubSector in (" + str + "))";


                //strSql += " and HRApplicant.ApplicantID in (SELECT   dbo.HRApplicantWorkerCurrentSubSector.ApplicantID " +
                //            " FROM         dbo.HRSector INNER JOIN " +
                //            " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID INNER JOIN " +
                //            " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRSubSector.SubSectorID = dbo.HRApplicantWorkerCurrentSubSector.SubSectorID " +
                //           " WHERE     (dbo.HRSector.SectorFamilyID =" + _SectorFamilyID + ")) ";
            }
            if (_EstimationStatementIDSearch != 0)
            {
                if (_EstimationStatusSearch != 0)
                {
                    if (_EstimationStatusSearch == 1)
                    {
                        StrSql += " And HRApplicantWorkerAttendanceStatement.Applicant in (SELECT Applicant FROM HRApplicantWorkerEstimationStatement WHERE (EstimationStatement = " + _EstimationStatementIDSearch + "))";
                    }
                    else if (_EstimationStatusSearch == 2)
                    {
                        StrSql += " And HRApplicantWorkerAttendanceStatement.Applicant not in (SELECT Applicant FROM HRApplicantWorkerEstimationStatement WHERE (EstimationStatement = " + _EstimationStatementIDSearch + "))";
                    }
                }
            }
            if (_EstimationStatementIDsSearch !=null &&_EstimationStatementIDsSearch != "")
            {
                if (_EstimationStatusSearch != 0)
                {
                    if (_EstimationStatusSearch == 1)
                    {
                        StrSql += " And HRApplicantWorkerAttendanceStatement.Applicant in (SELECT Applicant FROM HRApplicantWorkerEstimationStatement WHERE (EstimationStatement in ( " + _EstimationStatementIDsSearch + ")))";
                    }
                    else if (_EstimationStatusSearch == 2)
                    {
                        StrSql += " And HRApplicantWorkerAttendanceStatement.Applicant not in (SELECT Applicant FROM HRApplicantWorkerEstimationStatement WHERE (EstimationStatement in ( " + _EstimationStatementIDsSearch + ")))";
                    }
                }
            }

            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetIgnoreDelayTable()
        {
            double dblStartDate = SysUtility.Approximate(_DateFrom.ToOADate() - 2, 1, ApproximateType.Down);

            double dblEndDate = SysUtility.Approximate(_DateTo.ToOADate() - 2, 1, ApproximateType.Up);
            string strSql = "SELECT  IgnoreDelayDay FROM  dbo.HRIgnoreDelayDay  ";
            strSql += " where IgnoreDelayDay >=" + dblStartDate + "  and  IgnoreDelayDay <= " + dblEndDate;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public void EditJobCategoryEstimation(int intJobCategoryEstimation)
        {
            string strSql = "  UPDATE    HRApplicantWorkerAttendanceStatement" +
                            "  SET JobCategoryEstimation = " + intJobCategoryEstimation + "" +                
                            " WHERE     (ApplicantAttendanceStatmentID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void DeleteGroup() 
        {
            if (_ApplicantIDs == null || _ApplicantIDs == "" || _AttendanceStatment == 0)
                return;
            string strStatement = " SELECT        ApplicantAttendanceStatmentID "+
                       " FROM            dbo.HRApplicantWorkerAttendanceStatement "+
                        " WHERE  (AttendanceStatment = "+ _AttendanceStatment +") AND (Applicant IN ("+ _ApplicantIDs +")) "+
                        "  AND (FinancialStatement = 0) ";
            string strSql = " UPDATE hrapplicantworker SET LastAttendanceStatement = 0 WHERE LastAttendanceStatement IN ("+ strStatement +")";
            strSql += " DELETE FROM HRAttendanceStatementVacation WHERE  AttendanceStatement IN ("+ strStatement +") ";
            strSql += " UPDATE HRApplicantWorkerFurlough SET FurloughStatement = 0 WHERE FurloughStatement IN ("+ strStatement +") ";
            strSql += " DELETE FROM HRAttendanceStatementMission WHERE AttendanceStatement IN ("+ strStatement +") ";
            strSql += " UPDATE HRApplicantWorkerAbsenceDays SET AttendanceStatement = 0 WHERE AttendanceStatement IN ("+ strStatement +") ";
            strSql += " UPDATE HRApplicantWorkerOverDays SET AttendanceStatement = 0 WHERE AttendanceStatement IN (" + strStatement + ") ";
            strSql += " DELETE HRAttendanceStatementAttendanceTime WHERE AttendanceStatement IN ("+ strStatement +") ";
            strSql += " Delete From HRApplicantWorkerAttendanceStatementWorkDayDelay WHERE AttendanceStatment IN ("+ strStatement +") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql  = " insert into  dbo.HRApplicantWorkerAttendance (Applicant, AttendanceTime, AttandanceType, AttendanceStatement, UsrIns, TimIns) "+
                " SELECT        Applicant, AttendanceTime, AttandanceType, 0 AS AttendanceStatement1, UsrIns, TimIns "+
                " FROM            dbo.HRApplicantWorkerAttendanceProcessed "+
                " WHERE        (Dis IS NULL) AND (AttendanceStatement in  ("+ strStatement +")) " ;
            strSql += " delete from  dbo.HRApplicantWorkerAttendanceStatement where ApplicantAttendanceStatmentID in (" + strStatement + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void UploadBonusDay()
        {
            if (_BonusTable == null || BonusTable.Rows.Count == 0 || _AttendanceStatment  == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table HRTempApplicantWorkerValue");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "HRTempApplicantWorkerValue";
            objCopy.WriteToServer(BonusTable);
            string strSql =@"update        dbo.HRApplicantWorkerAttendanceStatement set OverDayCount = dbo.HRTempApplicantWorkerValue.Value
,OverDayCountRecommendedValue=dbo.HRTempApplicantWorkerValue.Value 
FROM            dbo.HRTempApplicantWorkerValue INNER JOIN
                         dbo.HRApplicantWorker ON dbo.HRTempApplicantWorkerValue.ApplicantCode = dbo.HRApplicantWorker.ApplicantCode INNER JOIN
                         dbo.HRApplicantWorkerAttendanceStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerAttendanceStatement.Applicant
WHERE        (dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment = " + _AttendanceStatment +@")";

       
       
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public void UploadApplicantStatement()
        {
            if (_AttandanceStatementTable == null || _AttandanceStatementTable.Rows.Count == 0 || _AttendanceStatment == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table HRApplicantWorkerAttendanceStatementTemp");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "HRApplicantWorkerAttendanceStatementTemp";
            objCopy.WriteToServer(_AttandanceStatementTable);
            string strSql = @" insert into HRApplicantWorkerAttendanceStatement
(  AttendanceStatment, AtendanceStatementIsSum, Applicant, OverDayCount, OverDayCountRecommendedValue, AbsenceDayCount, AbsenceDayCountRecommendedValue, NonCountedDays, 
                         NonCountedDaysValue, NonCountedDaysRecommendedValue, IsEndStatement, JobNature, SubSector, JobCategoryEstimation, UsrIns, TimIns
) ";
            strSql += @" SELECT        "+ _AttendanceStatment + @" AS AttenceStatement, 1 AS AttenceStatementIsSum, dbo.HRApplicantWorker.ApplicantID, ISNULL(TempAttendanceTable.OverDayCount, 0) AS Expr1, ISNULL(TempAttendanceTable.OverDayCount, 0) AS OverDayCountRec, 
                         ISNULL(TempAttendanceTable.AbsenceDayCount, 0) AS Absenance, ISNULL(TempAttendanceTable.AbsenceDayCount, 0) AS Recomended, ISNULL(TempAttendanceTable.NonCountedDays, N'0') AS NonCounted1, 
                         ISNULL(TempAttendanceTable.NonCountedDays, N'0') AS NonCounted2,ISNULL(TempAttendanceTable.NonCountedDays, N'0') AS NonCounted3, 0 AS isEnd, dbo.HRApplicantWorkerCurrentSubSector.JobNatureID, dbo.HRApplicantWorkerCurrentSubSector.SubSectorID, 
                         dbo.HRApplicantWorkerCurrentSubSector.JobCategoryEstimation, 2 AS UsrIns, GETDATE() AS TimIns
FROM            dbo.HRApplicantWorker INNER JOIN
                         dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN
                         dbo.HRApplicantWorkerAttendanceStatementTemp AS TempAttendanceTable ON dbo.HRApplicantWorker.ApplicantCode = TempAttendanceTable.Code LEFT OUTER JOIN
                             (SELECT        Applicant
                                FROM            dbo.HRApplicantWorkerAttendanceStatement
                                WHERE        (AttendanceStatment = " + _AttendanceStatment+@")) AS derivedtbl_1 ON dbo.HRApplicantWorker.ApplicantID = derivedtbl_1.Applicant
WHERE        (derivedtbl_1.Applicant IS NULL)";


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void JoinWorkDayFlat()
        {
            if (ID == 0 || _WorkdayFlatTbale == null || _WorkdayFlatTbale.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            arrStr.Add("delete from HRApplicantWorkerWorkDay  where ApplicantAttendanceStatement  = " + ID);
            WorkDayFlatDb objDb;
            foreach (DataRow objDr in _WorkdayFlatTbale.Rows)
            {
                objDb = new WorkDayFlatDb(objDr);
                objDb.ApplicantAttendanceStatement = ID;
                arrStr.Add(objDb.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion

    }
}
