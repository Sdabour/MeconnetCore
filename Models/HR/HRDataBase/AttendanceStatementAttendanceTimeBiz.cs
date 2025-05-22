using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceStatementAttendanceTimeBiz
    {
        #region Private Data
        AttendanceStatementAttendanceTimeDb _AttendanceStatementAttendanceTimeDb;
        #endregion
        #region Constructors
        public AttendanceStatementAttendanceTimeBiz()
        {
            _AttendanceStatementAttendanceTimeDb = new AttendanceStatementAttendanceTimeDb();
        }
        public AttendanceStatementAttendanceTimeBiz(DataRow objDr)
        {
            _AttendanceStatementAttendanceTimeDb = new AttendanceStatementAttendanceTimeDb(objDr);
        }
        #endregion
        #region Public Properties
        public int AttendanceStatement
        {
            set
            {
                _AttendanceStatementAttendanceTimeDb.AttendanceStatement = value;
            }
            get
            {
                return _AttendanceStatementAttendanceTimeDb.AttendanceStatement;
            }
        }
        public int AttendanceTime
        {
            set
            {
                _AttendanceStatementAttendanceTimeDb.AttendanceTime = value;
            }
            get
            {
                return _AttendanceStatementAttendanceTimeDb.AttendanceTime;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _AttendanceStatementAttendanceTimeDb.DateFrom = value;
            }
            get
            {
                return _AttendanceStatementAttendanceTimeDb.DateFrom;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _AttendanceStatementAttendanceTimeDb.DateTo = value;
            }
            get
            {
                return _AttendanceStatementAttendanceTimeDb.DateTo;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _AttendanceStatementAttendanceTimeDb.Add();
        }
        public void Delete()
        {
            _AttendanceStatementAttendanceTimeDb.Delete();
        }
        #endregion
    }
}
