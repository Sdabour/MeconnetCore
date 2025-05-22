using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.HR.HRBusiness;
using System.Data;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceStatementBiz
    {
        #region Private Data
        AttendanceStatementDb _AttendanceStatementDb;
        Hashtable _ApplicantHash;
        
        private DataTable _IgnoreDelayTable;

      
        #endregion
        #region Constructors
        public AttendanceStatementBiz()
        {
            _AttendanceStatementDb = new AttendanceStatementDb();
        }
        public AttendanceStatementBiz(DataRow objDr)
        {
            _AttendanceStatementDb = new AttendanceStatementDb(objDr);            
        }
        public AttendanceStatementBiz(int intStatementID)
        {
            _AttendanceStatementDb = new AttendanceStatementDb(intStatementID);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AttendanceStatementDb.ID = value;
            }
            get
            {
                return _AttendanceStatementDb.ID;
            }
        }
        public string StatementDesc
        {
            set
            {
                _AttendanceStatementDb.StatementDesc = value;
            }
            get
            {
                return _AttendanceStatementDb.StatementDesc;
            }
        }
        public DateTime StatementFrom
        {
            set
            {
                _AttendanceStatementDb.StatementFrom = value;
            }
            get
            {
                return new DateTime(_AttendanceStatementDb.StatementFrom.Year,_AttendanceStatementDb.StatementFrom.Month,_AttendanceStatementDb.StatementFrom.Day);
            }
        }
        public DateTime StatementTo
        {
            set
            {
                _AttendanceStatementDb.StatementTo = value;
            }
            get
            {
                return new DateTime(_AttendanceStatementDb.StatementTo.Year, _AttendanceStatementDb.StatementTo.Month, _AttendanceStatementDb.StatementTo.Day);                
            }
        }
        public int DelayLimit
        {
            set
            {
                _AttendanceStatementDb.DelayLimit = value;
            }
            get
            {
                return _AttendanceStatementDb.DelayLimit;
            }
        }
        public int DelayDiscount
        {
            set
            {
                _AttendanceStatementDb.DelayDiscount = value;
            }
            get
            {
                return _AttendanceStatementDb.DelayDiscount;
            }
        }
        public int ApplicantStatus
        {
            set
            {
                _AttendanceStatementDb.ApplicantStatus = value;
            }
            get
            {
                return _AttendanceStatementDb.ApplicantStatus;
            }
        }
        public bool NonCountedDayStatus
        {
            set
            {
                _AttendanceStatementDb.NonCountedDayStatus = value;
            }
            get
            {
                return _AttendanceStatementDb.NonCountedDayStatus;
            }
        }
        public int EarlierOutDiscount
        {
            set
            {
                _AttendanceStatementDb.EarlierOutDiscount = value;
            }
            get
            {
                return _AttendanceStatementDb.EarlierOutDiscount;
            }
        }
        public static AttendanceStatementBiz CurrentStatementBiz
        {
            get
            {
                AttendanceStatementDb objDb = new AttendanceStatementDb();
                DataTable dtTemp = objDb.GetLatestStatement();
                if (dtTemp.Rows.Count == 0)
                    return new AttendanceStatementBiz();
                else
                    return new AttendanceStatementBiz(dtTemp.Rows[0]);


            }
        }
       

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _AttendanceStatementDb.Add();
        }
        public void Edit()
        {
            _AttendanceStatementDb.Edit();
        }
        public void Delete()
        {
            _AttendanceStatementDb.Delete();
        }
      
        #endregion
    }
}
