using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public enum UploadBonusWay
    {
        Value,
        Hour,
        Day
    }
    public class GlobalStatementBiz
    {
        #region Private Data
        GlobalStatementDb _GlobalStatementDb;
        //EstimationStatementBiz _EstimationStatementBiz;
        AttendanceStatementBiz _AttendanceStatementBiz;
        
        bool _IncludeEmptyobjBiz;
         
        GlobalStatementBiz _BaseGlobalStatementBiz;
        Hashtable _ApplicantStatementHs ;

        Hashtable _ApplicantHash ;
      
        #endregion
        #region Constructors
        public GlobalStatementBiz()
        {
            _GlobalStatementDb = new GlobalStatementDb();
            //_EstimationStatementBiz = new EstimationStatementBiz();
            _AttendanceStatementBiz = new AttendanceStatementBiz();
           // _BaseGlobalStatementBiz = new GlobalStatementBiz();
        }
        public GlobalStatementBiz(DataRow objDr)
        {
            _GlobalStatementDb = new GlobalStatementDb(objDr);
            //if (_GlobalStatementDb.EstimationStatement != 0)
            //    _EstimationStatementBiz = new EstimationStatementBiz(objDr);
            //else
            //    _EstimationStatementBiz = new EstimationStatementBiz();

            _AttendanceStatementBiz = new AttendanceStatementBiz();//_GlobalStatementDb.AttendanceStatement);
            _AttendanceStatementBiz.ID = _GlobalStatementDb.AttendanceStatement;
            _AttendanceStatementBiz.StatementDesc = _GlobalStatementDb.AttendanceStatementDesc;
            if (_GlobalStatementDb.BaseStatementID != 0)
            {
                _BaseGlobalStatementBiz = new GlobalStatementBiz();
                _BaseGlobalStatementBiz.ID = _GlobalStatementDb.BaseStatementID;
                _BaseGlobalStatementBiz.StatementDesc = _GlobalStatementDb.BaseStatementDesc;
                _BaseGlobalStatementBiz.StatementDate = _GlobalStatementDb.BaseStatementDate;
                _BaseGlobalStatementBiz.MonthName = _GlobalStatementDb.BaseStatementMonthName;

            }
            else
                _BaseGlobalStatementBiz = new GlobalStatementBiz();
        }
        public GlobalStatementBiz(int intID)
        {
            _GlobalStatementDb = new GlobalStatementDb(intID);
            //if (_GlobalStatementDb.EstimationStatement != 0)
            //    _EstimationStatementBiz = new EstimationStatementBiz(objDr);
            //else
            //    _EstimationStatementBiz = new EstimationStatementBiz();

            _AttendanceStatementBiz = new AttendanceStatementBiz(_GlobalStatementDb.AttendanceStatement);
            if (_GlobalStatementDb.BaseStatementID != 0)
            {
                _BaseGlobalStatementBiz = new GlobalStatementBiz();
                _BaseGlobalStatementBiz.ID = _GlobalStatementDb.BaseStatementID;
                _BaseGlobalStatementBiz.StatementDesc = _GlobalStatementDb.BaseStatementDesc;
                _BaseGlobalStatementBiz.StatementDate = _GlobalStatementDb.BaseStatementDate;
                _BaseGlobalStatementBiz.MonthName = _GlobalStatementDb.BaseStatementMonthName;
            }
            else
                _BaseGlobalStatementBiz = new GlobalStatementBiz();
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _GlobalStatementDb.ID = value;
            }
            get
            {
                return _GlobalStatementDb.ID;
            }
        }
        public string StatementDesc
        {
            set
            {
                _GlobalStatementDb.StatementDesc = value;
            }
            get
            {
                return _GlobalStatementDb.StatementDesc;
            }
        }
        public string MonthName
        {
            set
            {
                _GlobalStatementDb.MonthName = value;
            }
            get
            {
                
                if (StatementDateTo.Month == 1)
                {
                    return "مرتبات يناير " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 2)
                {
                    return "مرتبات فبراير " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 3)
                {
                    return "مرتبات مارس " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 4)
                {
                    return "مرتبات ابريل " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 5)
                {
                    return "مرتبات مايو " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 6)
                {
                    return "مرتبات يونية " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 7)
                {
                    return "مرتبات يولبو " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 8)
                {
                    return "مرتبات اغسطس " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 9)
                {
                    return "مرتبات سبتمبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 10)
                {
                    return "مرتبات اكتوبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 11)
                {
                    return "مرتبات نوفمبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 12)
                {
                    return "مرتبات ديسمبر " + StatementDateTo.Year.ToString();
                }

                return _GlobalStatementDb.MonthName;
            }
        }
        public string ShortMonthName
        {
            get
            {
                if (StatementDateTo.Month == 1)
                {
                    return " يناير " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 2)
                {
                    return " فبراير " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 3)
                {
                    return " مارس " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 4)
                {
                    return " ابريل " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 5)
                {
                    return " مايو " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 6)
                {
                    return " يونية " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 7)
                {
                    return " يولبو " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 8)
                {
                    return " اغسطس " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 9)
                {
                    return " سبتمبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 10)
                {
                    return " اكتوبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 11)
                {
                    return " نوفمبر " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 12)
                {
                    return " ديسمبر " + StatementDateTo.Year.ToString();
                }

                return _GlobalStatementDb.MonthName;
            }
        }
        public string ShortMonthNameE
        {
            get
            {
                if (StatementDateTo.Month == 1)
                {
                    return " January " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 2)
                {
                    return " February " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 3)
                {
                    return " March " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 4)
                {
                    return " April " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 5)
                {
                    return " May " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 6)
                {
                    return " June " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 7)
                {
                    return " Jule " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 8)
                {
                    return " August " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 9)
                {
                    return " September " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 10)
                {
                    return " October " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 11)
                {
                    return " November " + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 12)
                {
                    return " December " + StatementDateTo.Year.ToString();
                }

                return _GlobalStatementDb.MonthName;
            }
        }
        public string ShortNoMonthName
        {
            get
            {
                if (StatementDateTo.Month == 1)
                {
                    return "01-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 2)
                {
                    return "02-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 3)
                {
                    return "03-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 4)
                {
                    return "04-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 5)
                {
                    return "05-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 6)
                {
                    return "06-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 7)
                {
                    return "07-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 8)
                {
                    return "08-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 9)
                {
                    return "09-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 10)
                {
                    return "10-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 11)
                {
                    return "11-" + StatementDateTo.Year.ToString();
                }
                else if (StatementDateTo.Month == 12)
                {
                    return "12-" + StatementDateTo.Year.ToString();
                }

                return _GlobalStatementDb.MonthName;
            }
        }
        public int MonthNo
        {
            get
            {
                if (StatementDateTo.Month == 1)
                {
                    return 1;
                }
                else if (StatementDateTo.Month == 2)
                {
                    return 2;
                }
                else if (StatementDateTo.Month == 3)
                {
                    return 3;
                }
                else if (StatementDateTo.Month == 4)
                {
                    return 4;
                }
                else if (StatementDateTo.Month == 5)
                {
                    return 5;
                }
                else if (StatementDateTo.Month == 6)
                {
                    return 6;
                }
                else if (StatementDateTo.Month == 7)
                {
                    return 7;
                }
                else if (StatementDateTo.Month == 8)
                {
                    return 8;
                }
                else if (StatementDateTo.Month == 9)
                {
                    return 9;
                }
                else if (StatementDateTo.Month == 10)
                {
                    return 10;
                }
                else if (StatementDateTo.Month == 11)
                {
                    return 11;
                }
                else if (StatementDateTo.Month == 12)
                {
                    return 12;
                }

                return 0;
            }
        }
        public bool IsAppendix
        {
            set
            {
                _GlobalStatementDb.IsAppendix = value;
            }
            get
            {
                return _GlobalStatementDb.IsAppendix;
            }
        }
        public bool IsDonation { set => _GlobalStatementDb.IsDonation = value; get => _GlobalStatementDb.IsDonation; }
        public bool BaseSalary
        {
            set
            {
                _GlobalStatementDb.BaseSalary = value;
            }
            get
            {
                return _GlobalStatementDb.BaseSalary;
            }
        }
        public bool InvolveLoan
        {
            set
            {
                _GlobalStatementDb.InvolveLoan = value;
            }
            get
            {
                return _GlobalStatementDb.InvolveLoan;
            }
        }
        public bool InvolveAttendance
        {
            set
            {
                _GlobalStatementDb.InvolveAttendance = value;
            }
            get
            {
                return _GlobalStatementDb.InvolveAttendance;
            }
        }
        public bool InvolvePenalty
        {
            set
            {
                _GlobalStatementDb.InvolvePenalty = value;
            }
            get
            {
                return _GlobalStatementDb.InvolvePenalty;
            }
        }
        public bool InvolveService
        {
            set
            {
                _GlobalStatementDb.InvolveService = value;
            }
            get
            {
                return _GlobalStatementDb.InvolveService;
            }
        }
        public bool InvolveFellowShip
        {
            set
            {
                _GlobalStatementDb.InvolveFellowShip = value;
            }
            get
            {
                return _GlobalStatementDb.InvolveFellowShip;
            }
        }
        public bool AttendanceStatementIsOptional
        {
            set
            {
                _GlobalStatementDb.AttendanceStatementIsOptional = value;
            }
            get
            {
                return _GlobalStatementDb.AttendanceStatementIsOptional;
            }
        }
        public bool IsClose
        {
            set
            {
                _GlobalStatementDb.IsClose = value;
            }
            get
            {
                return _GlobalStatementDb.IsClose;
            }
        }
        public DateTime StatementDate
        {
            set
            {
                _GlobalStatementDb.StatementDate = value;
            }
            get
            {
                return new DateTime(_GlobalStatementDb.StatementDate.Year, _GlobalStatementDb.StatementDate.Month, _GlobalStatementDb.StatementDate.Day);
            }
        }
        public DateTime StatementDateTo
        {
            set
            {
                _GlobalStatementDb.StatementDateTo = value;
            }
            get
            {
                return new DateTime(_GlobalStatementDb.StatementDateTo.Year,_GlobalStatementDb.StatementDateTo.Month,_GlobalStatementDb.StatementDateTo.Day);
            }
        }
        public string strBaseSalary
        {            
            get
            {
                if (BaseSalary == true)
                    return "يعتمد على الراتب";
                else
                    return "لا يعتمد على الراتب";                
            }
        }
        public int WeekDayNo
        {
            set
            {
                _GlobalStatementDb.WeekDayNo = value;
            }
            get
            {
                return _GlobalStatementDb.WeekDayNo;
            }
        }
        public int DayHourNo
        {
            set
            {
                _GlobalStatementDb.DayHourNo = value;
            }
            get
            {
                return _GlobalStatementDb.DayHourNo;
            }
        }
        public string BonusDesc
        {
            set
            {
                _GlobalStatementDb.BonusDesc = value;
            }
            get
            {
                return _GlobalStatementDb.BonusDesc;
            }
        }
        public double BonusValue
        {
            set
            {
                _GlobalStatementDb.BonusValue = value;
            }
            get
            {
                return _GlobalStatementDb.BonusValue;
            }
        }
        public double IncreasePerc
        {
            set
            {
                _GlobalStatementDb.IncreasePerc = value;
            }
            get
            {
                return _GlobalStatementDb.IncreasePerc;
            }
        }
        public string strStatementDate
        {           
            get
            {
                return StatementDate.ToString("yyyy-MM-dd"); ;
            }
        }
        public bool IncludeEmptyobjBiz
        {
            set
            {
                _IncludeEmptyobjBiz=value;
            }
        }
        //public EstimationStatementBiz EstimationStatementBiz
        //{
        //    set
        //    {
        //        _EstimationStatementBiz = value;
        //    }
        //    get
        //    {
        //        return _EstimationStatementBiz;
        //    }
        //}
        public AttendanceStatementBiz AttendanceStatementBiz
        {
            set
            {
                _AttendanceStatementBiz = value;
            }
            get
            {
                return _AttendanceStatementBiz;
            }
        }
        public GlobalStatementBiz BaseGlobalStatementBiz
        {
            set
            {
                _BaseGlobalStatementBiz = value;
            }
            get
            {
                if (_BaseGlobalStatementBiz == null)
                    _BaseGlobalStatementBiz = new GlobalStatementBiz();
                return _BaseGlobalStatementBiz;
            }
        }
       
        public static GlobalStatementBiz GetLastGlobalStatementBiz
        {
            get
            {
                GlobalStatementDb objDb = new GlobalStatementDb();
                DataTable dtTemp = objDb.GetLatestGlobalStatement();
                if (dtTemp.Rows.Count == 0)
                    return new GlobalStatementBiz();
                else
                    return new GlobalStatementBiz(dtTemp.Rows[0]);
            }
        }
       
     
         
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            //_GlobalStatementDb.EstimationStatement = _EstimationStatementBiz.ID;
            _GlobalStatementDb.AttendanceStatement = _AttendanceStatementBiz.ID;
    
            _GlobalStatementDb.BaseStatementID = BaseGlobalStatementBiz.ID;
            _GlobalStatementDb.Add();

        }
        public void Edit()
        {
            //_GlobalStatementDb.EstimationStatement = EstimationStatementBiz.ID;
            _GlobalStatementDb.AttendanceStatement = _AttendanceStatementBiz.ID;
           
            _GlobalStatementDb.BaseStatementID = BaseGlobalStatementBiz.ID;
            _GlobalStatementDb.Edit();
        }
        public void Delete()
        {
            _GlobalStatementDb.Delete();
        }
        public void EditIsCloseStatus(bool blStatus)
        {
            GlobalStatementDb objDb = new GlobalStatementDb();
            objDb.EditIsCloseStatus(blStatus);
        }
        public void DeleteApplicantIncreaseValue()
        {
            
        }
        public bool CheckApplicant()
        {
            if (ID == 0)
                return false;
           

            
            return false;
        }
        public static void CloseStatement(bool blIsClose, int intStatement)
        {
            GlobalStatementDb objDb = new GlobalStatementDb();
            objDb.IsClose = blIsClose;
            objDb.ID = intStatement;
            objDb.CloseGlobalStatement();
        }
         

        #endregion
    }
}
