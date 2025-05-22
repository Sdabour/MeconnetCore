using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class AttendanceStatementDb
    {
        #region Private Data
        protected int _ID;
        protected string _StatementDesc;
        protected DateTime _StatementFrom;
        protected DateTime _StatementTo;
        protected int _DelayLimit;
        protected bool _NonCountedDayStatus;
        protected int _DelayDiscount;
        protected int _EarlierOutDiscount;
        protected int _ApplicantStatus;
        protected bool _StatementDateStatusSearch;
        protected DateTime _StatementFromSearch;
        protected DateTime _StatementToSearch;
        protected int _StatementNotFinish;

        #endregion
        #region Constructors
        public AttendanceStatementDb()
        {
        }
        public AttendanceStatementDb(DataRow ObjDR)
        {
            SetData(ObjDR);
        }
        public AttendanceStatementDb(int intStatement)
        {
            _ID = intStatement;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                if(dtTemp!=null)
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
        public DateTime StatementFrom
        {
            set
            {
                _StatementFrom = value;
            }
            get
            {
                return _StatementFrom;
            }
        }
        public DateTime StatementTo
        {
            set
            {
                _StatementTo = value;
            }
            get
            {
                return _StatementTo;
            }
        }

        public int DelayLimit
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

        public int DelayDiscount
        {
            set
            {
                _DelayDiscount = value;
            }
            get
            {
                return _DelayDiscount;
            }
        }

        public int EarlierOutDiscount
        {
            set
            {
                _EarlierOutDiscount = value;
            }
            get
            {
                return _EarlierOutDiscount;
            }
        }
        public int ApplicantStatus
        {
            set
            {
                _ApplicantStatus = value;
            }
            get
            {
                return _ApplicantStatus;
            }
        }
        public bool NonCountedDayStatus
        {
            set
            {
                _NonCountedDayStatus = value;
            }
            get
            {
                return _NonCountedDayStatus;
            }
        }

        public bool StatementDateStatusSearch
        {
            set
            {
                _StatementDateStatusSearch = value;
            }
            get
            {
                return _StatementDateStatusSearch;
            }

        }
        public DateTime StatementFromSearch
        {
            set
            {
                _StatementFromSearch = value;
            }
            get
            {
                return _StatementFromSearch;
            }

        }
        public DateTime StatementToSearch
        {
            set
            {
                _StatementToSearch = value;
            }
            get
            {
                return _StatementToSearch;
            }

        }
        public int StatementNotFinish { set { _StatementNotFinish = value; } }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRAttendanceStatement.StatementID, HRAttendanceStatement.StatementDesc, HRAttendanceStatement.StatementFrom, HRAttendanceStatement.StatementTo, "+
                                  " HRAttendanceStatement.StatementDelayLimit,HRAttendanceStatement.DelayDiscount,"+
                                  " HRAttendanceStatement.EarlierOutDiscount,HRAttendanceStatement.ApplicantStatus,HRAttendanceStatement.NonCountedDayStatus" +    
                                  " FROM         HRAttendanceStatement";

                return Returned;
            }
        }

        public  string AddStr
        {
            get
            {
                double dblFrom = _StatementFrom.ToOADate() - 2;
                double dblTo = _StatementTo.ToOADate() - 2;

                int intNonCountedDayStatus = _NonCountedDayStatus ? 1 : 0;
                string Returned = " INSERT INTO HRAttendanceStatement "+
                                  " (StatementDesc, StatementFrom, StatementTo,StatementDelayLimit,DelayDiscount,EarlierOutDiscount,ApplicantStatus,NonCountedDayStatus, UsrIns, TimIns) " +
                                  " VALUES "+
                                  " ('"+ _StatementDesc +"',"+
                                  " " + dblFrom + "," + dblTo + "," + _DelayLimit + "," +
                                  " " + _DelayDiscount + "," + _EarlierOutDiscount + "," + _ApplicantStatus + "," + intNonCountedDayStatus + "," +
                                  " "+ SysData.CurrentUser.ID +",GetDate())";

                return Returned;
            }
        }
        public  string EditStr
        {
            get
            {
                double dblFrom = _StatementFrom.ToOADate() - 2;
                double dblTo = _StatementTo.ToOADate() - 2;
                int intNonCountedDayStatus = _NonCountedDayStatus ? 1 : 0;
                string Returned = " UPDATE    HRAttendanceStatement"+
                                  " SET StatementDesc ='" + _StatementDesc + "'" +
                                  " ,StatementFrom =" + dblFrom + "" +
                                  " ,StatementTo =" + dblTo + "" +
                                  " ,StatementDelayLimit =" + _DelayLimit + "" +
                                  " ,DelayDiscount =" + _DelayDiscount + "" +
                                  " ,EarlierOutDiscount =" + _EarlierOutDiscount + "" + 
                                  " ,ApplicantStatus = "+ _ApplicantStatus +""+
                                  " ,NonCountedDayStatus=" + intNonCountedDayStatus + "" +
                                  " ,UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (StatementID = " + _ID + ")";

                return Returned;
            }
        }
        public  string DeleteStr
        {
            get
            {
                string Returned = "DELETE FROM HRAttendanceStatement WHERE     (StatementID = " + _ID + ")";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["StatementID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["StatementID"].ToString());
            _StatementDesc = objDR["StatementDesc"].ToString();
            _StatementFrom = DateTime.Parse(objDR["StatementFrom"].ToString());
            _StatementTo = DateTime.Parse(objDR["StatementTo"].ToString());
            _DelayLimit = int.Parse(objDR["StatementDelayLimit"].ToString());
            _DelayDiscount = int.Parse(objDR["DelayDiscount"].ToString());
            _EarlierOutDiscount = int.Parse(objDR["EarlierOutDiscount"].ToString());
            if(objDR["ApplicantStatus"].ToString()!="")
            _ApplicantStatus = int.Parse(objDR["ApplicantStatus"].ToString());

        if (objDR["NonCountedDayStatus"].ToString() != "")
            _NonCountedDayStatus = bool.Parse(objDR["NonCountedDayStatus"].ToString());
           
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
                StrSql = StrSql + " And StatementID = " + _ID + "";

            if (_StatementDateStatusSearch == true)
            {
                int intStatementFrom;
                double d = _StatementFromSearch.ToOADate() - 2;
                intStatementFrom = (int)d;
                intStatementFrom = (int)SysUtility.Approximate(d, 1.0, ApproximateType.Down);
                int intStatementTo;
                double dd = _StatementToSearch.ToOADate() - 2;
                intStatementTo = (int)dd +1;
                intStatementTo = (int)SysUtility.Approximate(dd, 1, ApproximateType.Down);
                //StrSql = StrSql + " And (( " + intStatementFrom + " <= convert(float,HRAttendanceStatement.StatementFrom)   and " + intStatementTo + " >= convert(float,HRAttendanceStatement.StatementFrom) " +
                //    "  ) and ( " + intStatementFrom + "<= convert(float,HRAttendanceStatement.StatementTo ) and " + intStatementTo + " >= convert(float,HRAttendanceStatement.StatementTo )  ))";


                StrSql = StrSql + " And (" +
                   "(( " + intStatementFrom + " >= convert(float,StatementFrom)   and " +
                   intStatementFrom + " <= convert(float,StatementTo)) " +
                   "  ) or (( " + intStatementTo + ">= convert(float,StatementFrom ) and " +
               intStatementTo + " <= convert(float,StatementTo ) ) )" +
                   "" +///////
                   " or    (( " + intStatementFrom + " <= convert(float,StatementFrom)   and " +
                   intStatementTo + " >=  convert(float,StatementFrom)  ) " +
                   "  ) or (( " + intStatementFrom + "<= convert(float,StatementTo ) and " +
               intStatementTo + " >= convert(float,StatementTo ) ) )" +
                ")";                
            }
            if (_StatementNotFinish!=0)
            {
                StrSql += " And (ApplicantStatus in (1,0))";
            }
            StrSql += " Order by StatementFrom Desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetLatestStatement()
        {
            string strSql = SearchStr + " where StatementID = (select max(StatementID)  from  HRAttendanceStatement )";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}
