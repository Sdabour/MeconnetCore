using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class GlobalStatementDb
    {
        #region Private Data
        protected int _ID;
        protected string _StatementDesc;
        protected string _MonthName;        
        protected DateTime _StatementDate;
        protected DateTime _StatementDateTo;
        protected bool _IsAppendix;
        protected bool _BaseSalary;
        protected bool _InvolveLoan;
        protected bool _InvolvePenalty;
        protected bool _InvolveAttendance;
        protected bool _InvolveService;
        protected bool _InvolveFellowShip;
        protected int _EstimationStatement;
        protected int _AttendanceStatement;
        string _AttendanceStatementDesc;

        
        protected int _BaseStatementID;
        protected string _BaseStatementDesc;
        protected string _BaseStatementMonthName;
        protected DateTime _BaseStatementDate;
        protected bool _BaseStatementBaseSalary;
        protected int _WeekDayNo;
        protected int _DayHourNo;
        protected string _BonusDesc;
        protected double _BonusValue;
        protected double _IncreasePerc;
        protected bool _AttendanceStatementIsOptional;
        protected bool _IsClose;
     
        protected DataTable _DetailsTable;
        protected DataTable _AdditionsTable;
        protected DataTable _RangesTable;
        protected bool _StatementSearch;

        //protected bool _StatementToSearch;
        protected bool _BaseSalarySearch;
        protected DateTime _StatementDateFromSearch;
        protected DateTime _StatementDateToSearch;
        #endregion
        #region Constructors
        public GlobalStatementDb()
        {
        }
        public GlobalStatementDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
                return;
            SetData(dtTemp.Rows[0]);
        }
        public GlobalStatementDb(DataRow objDr)
        {
            SetData(objDr);
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
        public string StatementDesc
        {
            set
            {
                _StatementDesc = value;
            }
            get
            {
                return _StatementDesc;
            }
        }
        public string MonthName
        {
            set
            {
                _MonthName = value;
            }
            get
            {
                return _MonthName;
            }
        }
        
        public bool IsAppendix
        {
            set
            {
                _IsAppendix = value;
            }
            get
            {
                return _IsAppendix;
            }
        }
        public bool BaseSalary
        {
            set
            {
                _BaseSalary = value;
            }
            get
            {
                return _BaseSalary;
            }
        }
        public bool InvolveLoan
        {
            set
            {
                _InvolveLoan = value;
            }
            get
            {
                return _InvolveLoan;
            }
        }
        public bool InvolveAttendance
        {
            set
            {
                _InvolveAttendance = value;
            }
            get
            {
                return _InvolveAttendance;
            }
        }
        public bool InvolvePenalty
        {
            set
            {
                _InvolvePenalty = value;
            }
            get
            {
                return _InvolvePenalty;
            }
        }
        public bool InvolveService
        {
            set
            {
                _InvolveService = value;
            }
            get
            {
                return _InvolveService;
            }
        }
        public bool InvolveFellowShip
        {
            set
            {
                _InvolveFellowShip = value;
            }
            get
            {
                return _InvolveFellowShip;
            }
        }
        public DateTime StatementDate
        {
            set
            {
                _StatementDate = value;
            }
            get
            {
                return _StatementDate;
            }
        }
        public DateTime StatementDateTo
        {
            set
            {
                _StatementDateTo = value;
            }
            get
            {
                return _StatementDateTo;
            }
        }
        public int EstimationStatement
        {
            set
            {
                _EstimationStatement = value;
            }
            get
            {
                return _EstimationStatement;
            }
        }
        public int AttendanceStatement
        {
            set
            {
                _AttendanceStatement = value;
            }
            get
            {
                return _AttendanceStatement;
            }
        }
        public string AttendanceStatementDesc
        {
            get { return _AttendanceStatementDesc; }
            set { _AttendanceStatementDesc = value; }
        }
        public int BaseStatementID
        {
            set
            {
                _BaseStatementID = value;
            }
            get
            {
                return _BaseStatementID;
            }
        }
        public string BaseStatementDesc
        {
            set
            {
                _BaseStatementDesc = value;
            }
            get
            {
                return _BaseStatementDesc;
            }
        }

        public string BaseStatementMonthName
        {
            set
            {
                _BaseStatementMonthName = value;
            }
            get
            {
                return _BaseStatementMonthName;
            }
        }
        public DateTime BaseStatementDate
        {
            set
            {
                _BaseStatementDate = value;
            }
            get
            {
                return _BaseStatementDate;
            }
        }
        public bool AttendanceStatementIsOptional
        {
            set
            {
                _AttendanceStatementIsOptional = value;
            }
            get
            {
                return _AttendanceStatementIsOptional;
            }
        }
        public bool IsClose
        {
            set
            {
                _IsClose = value;
            }
            get
            {
                return _IsClose;
            }
        }
        public DataTable DetailsTable
        {
            set
            {
                _DetailsTable = value;
            }
        }
        public DataTable AdditionsTable
        {
            set
            {
                _AdditionsTable = value;
            }
        }
        public DataTable RangesTable 
        {
            set
            {
                _RangesTable = value;
            }
        }
        public int WeekDayNo
        {
            set
            {
                _WeekDayNo = value;
            }
            get
            {
                return _WeekDayNo;
            }
        }
        public int DayHourNo
        {
            set
            {
                _DayHourNo = value;
            }
            get
            {
                return _DayHourNo;
            }
        }
        public string BonusDesc
        {
            set
            {
                _BonusDesc = value;
            }
            get
            {
                return _BonusDesc;
            }
        }
        public double BonusValue
        {
            set
            {
                _BonusValue = value;
            }
            get
            {
                return _BonusValue;
            }
        }
        public double IncreasePerc
        {
            set
            {
                _IncreasePerc = value;
            }
            get
            {
                return _IncreasePerc;
            }
        }
        public DateTime StatementDateFromSearch
        {
            set
            {
                _StatementDateFromSearch = value;
            }
            get
            {
                return _StatementDateFromSearch;
            }
        }
        public DateTime StatementDateToSearch
        {
            set
            {
                _StatementDateToSearch = value;
            }
            get
            {
                return _StatementDateToSearch;
            }
        }
        public bool StatementSearch
        {
            set
            {
                _StatementSearch = value;
            }
            get
            {
                return _StatementSearch;
            }
        }
        //public bool StatementToSearch
        //{
        //    set
        //    {
        //        _StatementToSearch = value;
        //    }
        //    get
        //    {
        //        return _StatementToSearch;
        //    }
        //}
        
        public bool BaseSalarySearch
        {
            set
            {
                _BaseSalarySearch = value;
            }
            get
            {
                return _BaseSalarySearch;
            }
        }
        DataTable _BonusTable;

        public DataTable BonusTable
        {
            get { return _BonusTable; }
            set { _BonusTable = value; }
        }
        int _BonusType;

        public int BonusType
        {
            get { return _BonusType; }
            set { _BonusType = value; }
        }
        double _BonusDayHour;

        public double BonusDayHour
        {
            get { return _BonusDayHour; }
            set { _BonusDayHour = value; }
        }
        int _BonusMonthDayCount = 30;

        public int BonusMonthDayCount
        {
            get { return _BonusMonthDayCount; }
            set { _BonusMonthDayCount = value; }
        }
        int _UploadBonusWay;/*
                             * 0 Value
                             * 1 Hour
                             * 2 Day
                             */

        public int UploadBonusWay
        {
            get { return _UploadBonusWay; }
            set { _UploadBonusWay = value; }
        }
        bool _IsDonation;
        public bool IsDonation { set => _IsDonation = value; get => _IsDonation; }

        public string AddStr
        {
            get
            {
                double dblStatementDate = _StatementDate.ToOADate() - 2;
                double dblStatementDateTo = _StatementDateTo.ToOADate() - 2;
                int intIsAppendix = _IsAppendix ? 1 : 0;
                int IsBaseSalary = _BaseSalary ? 1 : 0;
                int IsInvolveLoan = _InvolveLoan ? 1 : 0;
                int IsInvolvePenalty = _InvolvePenalty ? 1 : 0;
                int IsInvolveAttendance = _InvolveAttendance ? 1 : 0;
                int IsInvolveService = _InvolveService ? 1 : 0;
                int IsInvolveFellowShip = _InvolveFellowShip ? 1 : 0;
                int intAttendanceStatementIsOptional = _AttendanceStatementIsOptional ? 1 : 0;
                int intIsClose = _IsClose ? 1 : 0;
                string ReturnedStr = "INSERT INTO HRGlobalStatement "+
                                     " (StatementDesc, StatementDate,StatementDateTo,IsAppendix, InvolveBaseSalary,StatementWeekDayNo,StatementDayHourNo," +
                                     " StatementBonusDesc,StatementBonusValue,StatementIncreasePerc," +
                                     " InvolveLoan,InvolveAttendance,InvolvePenalty,InvolveService,InvolveFellowShip," +
                                     " EstimationStatement,AttendanceStatement,MonthName,AttendanceStatementIsOptional,IsClose,BaseGlobalStatement,StatementIsDonation, UsrIns, TimIns)" +
                                     " VALUES ('" + _StatementDesc + "'," + dblStatementDate + "," + dblStatementDateTo + "," +
                                     intIsAppendix + "," + IsBaseSalary + "," + _WeekDayNo + "," + _DayHourNo + "," +
                                     " '"+ _BonusDesc +"',"+ _BonusValue +","+ _IncreasePerc +", "+
                                     " " + IsInvolveLoan + "," + IsInvolveAttendance + "," + IsInvolvePenalty + "," + IsInvolveService + "," + IsInvolveFellowShip + "," +
                                     " " + _EstimationStatement + "," + _AttendanceStatement + ",'" + _MonthName + "',"+
                                     " " + intAttendanceStatementIsOptional + "," + intIsClose + "," + 
                                     _BaseStatementID + "," + (_IsDonation?1:0)  + "," + SysData.CurrentUser.ID + ",GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblStatementDate = _StatementDate.ToOADate() - 2;
                double dblStatementDateTo = _StatementDateTo.ToOADate() - 2;
                int intIsAppendix = _IsAppendix ? 1 : 0;
                int IsBaseSalary = _BaseSalary ? 1 : 0;
                int IsInvolveLoan = _InvolveLoan ? 1 : 0;
                int IsInvolvePenalty = _InvolvePenalty ? 1 : 0;
                int IsInvolveAttendance = _InvolveAttendance ? 1 : 0;
                int IsInvolveService = _InvolveService ? 1 : 0;
                int IsInvolveFellowShip = _InvolveFellowShip ? 1 : 0;
                int intAttendanceStatementIsOptional = _AttendanceStatementIsOptional ? 1 : 0;
                int intIsClose = _IsClose ? 1 : 0;
                string ReturnedStr = "UPDATE    HRGlobalStatement " +
                                     " SET  StatementDesc ='" + _StatementDesc + "'" +
                                     " , StatementDate =" + dblStatementDate + "" +
                                     " , StatementDateTo =" + dblStatementDateTo + "" +
                                     " , IsAppendix =" + intIsAppendix + "" +
                                     " , InvolveBaseSalary =" + IsBaseSalary + "" +
                                     " , StatementWeekDayNo =" + _WeekDayNo + "" +
                                     " , StatementDayHourNo =" + _DayHourNo + "" +
                                     " , StatementBonusDesc ='" + _BonusDesc + "'" +
                                     " , StatementBonusValue =" + _BonusValue + "" +
                                     " , StatementIncreasePerc =" + _IncreasePerc + "" +
                                     " , EstimationStatement =" + _EstimationStatement + "" +
                                     " , AttendanceStatement =" + _AttendanceStatement + "" +
                                     " , InvolveLoan = " + IsInvolveLoan + " " +
                                     " , InvolveAttendance = " + IsInvolveAttendance + " " +
                                     " , InvolvePenalty = " + IsInvolvePenalty + " " +
                                     " , InvolveService = " + IsInvolveService + " " +
                                     " , InvolveFellowShip = " + IsInvolveFellowShip + "" +
                                     " , MonthName='" + _MonthName + "'" +
                                     " , AttendanceStatementIsOptional=" + intAttendanceStatementIsOptional + "" +
                                     " , IsClose=" + intIsClose + "" +
                                     " , BaseGlobalStatement = " + _BaseStatementID + "" +
                                     ",StatementIsDonation=" + (_IsDonation?1:0)+
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                     " WHERE     (StatementID = "+ ID +")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRGlobalStatement" +
                                     " WHERE     (StatementID = " + _ID + ") ";
                return ReturnedStr;
            }
        }
        public string AttendanceApplicantSearchStr
        {
            get
            {
                string Returned = "SELECT      dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment.Applicant, dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment.ApplicantAttendanceStatmentID as LastAttendanceStatement  " +
                     " FROM         dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment "+
                     " INNER JOIN  dbo.HRGlobalStatement ON  "+
                      " dbo.HRApplicantWorkerAttendanceStatement_IAttendanceStatment.AttendanceStatment = dbo.HRGlobalStatement.AttendanceStatement "+
                      " WHERE   (dbo.HRGlobalStatement.StatementID = "+ _ID +") ";
                return Returned;
            }
        }
        public string NoSalaryVacation
        {
            get
            {
                string strAttendenceTable = "SELECT  dbo.HRGlobalStatement.StatementID, dbo.HRAttendanceStatement.StatementFrom, dbo.HRAttendanceStatement.StatementTo "+
                      " FROM         dbo.HRGlobalStatement INNER JOIN "+
                      " dbo.HRAttendanceStatement ON dbo.HRGlobalStatement.AttendanceStatement = dbo.HRAttendanceStatement.StatementID "+
                     " WHERE     (dbo.HRGlobalStatement.StatementID = "+ _ID +")";
                string Returned = "SELECT  VacationApplicantID as Applicant " +
                              " FROM         dbo.HRApplicantWorkerVacation  INNER JOIN " +
                     " dbo.HRVacationType ON dbo.HRApplicantWorkerVacation.VacationType = dbo.HRVacationType.VacationTypeID " +
                     " Cross join  ("+ strAttendenceTable +") AttendanceTable   " +
                     " WHERE     (dbo.HRVacationType.VacationTypeWithSalary = 1) " +
                     "  AND ( AttendanceTable.StatementFrom > VacationFrom) AND (AttendanceTable.StatementTo < VacationTo) ";

               // Returned += " and dbo.HRAttendanceStatement.StatementID = " + _AttendanceStatementID;
                return Returned;
            }
        }
         
         
        public static string SearchStr
        {
            get
            {
                string strBaseStatement = "SELECT     StatementID AS BaseStatementID, StatementDesc AS BaseStatementDesc, MonthName AS BaseStatementMonthName, "+
                      " StatementDate AS BaseStatementDate "+
                      " FROM         dbo.HRGlobalStatement";
                string ReturnedStr = " SELECT     HRGlobalStatement.StatementID, HRGlobalStatement.StatementDesc, "+
                                     " HRGlobalStatement.StatementDate,HRGlobalStatement.StatementDateTo,HRGlobalStatement.IsAppendix, HRGlobalStatement.InvolveBaseSalary,HRGlobalStatement.StatementWeekDayNo,HRGlobalStatement.StatementDayHourNo," +
                                     " HRGlobalStatement.EstimationStatement,HRGlobalStatement.AttendanceStatement,HRGlobalStatement.StatementBonusDesc,HRGlobalStatement.StatementBonusValue," +
                                     " HRGlobalStatement.InvolveLoan,HRGlobalStatement.InvolveAttendance,HRGlobalStatement.InvolvePenalty,HRGlobalStatement.InvolveService,HRGlobalStatement.InvolveFellowShip," +
                                     " HRGlobalStatement.AttendanceStatementIsOptional,HRGlobalStatement.IsClose,HRGlobalStatement.BaseGlobalStatement," +
                                     " HRGlobalStatement.StatementIncreasePerc,HRGlobalStatement.MonthName as GlobalMonthName,HRGlobalStatement.StatementIsDonation,EstimationStatementTable.*,BaseStatementTable.* " +
                                     ",AttendanceTable.StatementDesc as AttendanceStatementDesc " +
                                     " FROM         HRGlobalStatement"+
                                     " Left Outer Join (" + EstimationStatementDb.SearchStr + ") EstimationStatementTable ON HRGlobalStatement.EstimationStatement = EstimationStatementTable.EstimationStatementID"+
                                     " left outer join (" + strBaseStatement + ") as BaseStatementTable on "+
                                     " BaseStatementTable.BaseStatementID =  HRGlobalStatement.BaseGlobalStatement "+
                                     " left outer join ("+ AttendanceStatementDb.SearchStr +") as AttendanceTable  "+
                                     " on  HRGlobalStatement.AttendanceStatement = AttendanceTable.StatementID ";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["StatementID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["StatementID"].ToString());
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
            _AttendanceStatement = int.Parse(objDr["AttendanceStatement"].ToString());
            _StatementDesc = objDr["StatementDesc"].ToString();
            _MonthName = objDr["GlobalMonthName"].ToString();            
            _StatementDate = DateTime.Parse(objDr["StatementDate"].ToString());
            if (objDr["StatementDateTo"].ToString() != "")
                _StatementDateTo = DateTime.Parse(objDr["StatementDateTo"].ToString());
            _WeekDayNo = int.Parse(objDr["StatementWeekDayNo"].ToString());
            _DayHourNo = int.Parse(objDr["StatementDayHourNo"].ToString());
            try
            {
                _IsAppendix = bool.Parse(objDr["IsAppendix"].ToString());
                _BaseSalary = bool.Parse(objDr["InvolveBaseSalary"].ToString());
                _InvolveLoan = bool.Parse(objDr["InvolveLoan"].ToString());
                _InvolveAttendance = bool.Parse(objDr["InvolveAttendance"].ToString());
                _InvolvePenalty = bool.Parse(objDr["InvolvePenalty"].ToString());
                _InvolveService = bool.Parse(objDr["InvolveService"].ToString());
                _InvolveFellowShip = bool.Parse(objDr["InvolveFellowShip"].ToString());
                _AttendanceStatementIsOptional = bool.Parse(objDr["AttendanceStatementIsOptional"].ToString());
                _IsClose = bool.Parse(objDr["IsClose"].ToString());
            }
            catch
            { }
            _BonusDesc = objDr["StatementBonusDesc"].ToString();
            _BonusValue = double.Parse(objDr["StatementBonusValue"].ToString());
            _IncreasePerc = double.Parse(objDr["StatementIncreasePerc"].ToString());

            if (objDr["BaseGlobalStatement"].ToString() != "")
            {
                _BaseStatementID = int.Parse(objDr["BaseGlobalStatement"].ToString());

                _BaseStatementDesc = objDr["BaseStatementDesc"].ToString();
                _BaseStatementMonthName = objDr["BaseStatementMonthName"].ToString();
               if(objDr["BaseStatementDate"].ToString() != "")
                _BaseStatementDate = DateTime.Parse(objDr["BaseStatementDate"].ToString());
            }
            _AttendanceStatementDesc = objDr["AttendanceStatementDesc"].ToString();
            
            bool.TryParse(objDr["StatementIsDonation"].ToString(), out _IsDonation);
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
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
            
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
                StrSql = StrSql + " And HRGlobalStatement.StatementID = "+ _ID +"";
            if (_EstimationStatement != 0)
                StrSql = StrSql + " And EstimationStatement = " + _EstimationStatement + "";
            //if (_StatementSearch == true)
            //{
            //    double dblFrom = _StatementDateFromSearch.ToOADate() - 2;
            //    StrSql = StrSql + " And ( (StatementDate >= " + dblFrom + ") Or (StatementDateTo <= " + dblFrom + ")) ";
            //}
            //if (_StatementToSearch == true)
            //{                
            //    double dblTo = _StatementDateToSearch.ToOADate() - 2;
            //    StrSql = StrSql + " And ( (StatementDate >= " + dblTo + ") Or (StatementDateTo <= " + dblTo + ")) ";
            //}
            if (_StatementSearch == true)
            {
                int intStatementFrom;
                double d = _StatementDateFromSearch.ToOADate() - 2;
                intStatementFrom = (int)d;

                int intStatementTo;
                double dd = _StatementDateToSearch.ToOADate() - 2;
                intStatementTo = (int)dd + 1;

                //StrSql = StrSql + " And (( " + intStatementFrom + " <= convert(float,StatementDate)   and " + intStatementTo + " >= convert(float,StatementDate) " +
                //    "  ) and ( " + intStatementFrom + "<= convert(float,StatementDateTo ) and " + intStatementTo + " >= convert(float,StatementDateTo )  ))";

                StrSql = StrSql + " And (" +
                    "(( " + intStatementFrom + " >= convert(float,StatementDate)   and " +
                    intStatementFrom + " <= convert(float,StatementDateTo)) " +
                    "  ) or (( " + intStatementTo + ">= convert(float,StatementDate ) and " +
                intStatementTo + " <= convert(float,StatementDateTo ) ) )" +
                    "" +///////
                    " or    (( " + intStatementFrom + " <= convert(float,StatementDate)   and " +
                    intStatementTo + " >=  convert(float,StatementDate)  ) " +
                    "  ) or (( " + intStatementFrom + "<= convert(float,StatementDateTo ) and " +
                intStatementTo + " >= convert(float,StatementDateTo ) ) )" +
                 ")";

            }

            if (_BaseSalarySearch != false)
            {
                int IsBaseSalary = _BaseSalarySearch ? 1 : 0;
                StrSql = StrSql + " And InvolveBaseSalary = " + IsBaseSalary + "";
            }
            StrSql = "select top 200 * from (" + StrSql + ") as GlobalStatementTable ";
            StrSql += " Order By StatementDate desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetLatestGlobalStatement()
        {
            string strSql = SearchStr + " where HRGlobalStatement.StatementID = " +
                " (select max(StatementID)  from  HRGlobalStatement where  dbo.HRGlobalStatement.IsClose = 0 )";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        public void EditIsCloseStatus(bool blStatus)
        {
            int intIsClose = blStatus ? 1 : 0;
            string strSql = " UPDATE    HRGlobalStatement "+
                            " SET       IsClose =" + intIsClose + "" +
                            " WHERE     (StatementID = "+ _ID +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
       
        public void CloseGlobalStatement()
        {
            int intIsClose = _IsClose ? 1 : 0;
            string strSql = " update HRGlobalStatement set IsClose = " + intIsClose + " where StatementID = "+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
       
        #endregion
    }
}
