using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public  class EstimationStatementAttendanceStatementBiz
    {
        #region Private Data
        EstimationStatementAttendanceStatementDb _EstimationStatementAttendanceStatementDb;
        AttendanceStatementBiz _AttendanceStatementBiz;
        #endregion
        #region Constructors
        public EstimationStatementAttendanceStatementBiz()
        {
            _EstimationStatementAttendanceStatementDb = new EstimationStatementAttendanceStatementDb();
            _AttendanceStatementBiz = new AttendanceStatementBiz();
        }
        public EstimationStatementAttendanceStatementBiz(DataRow objDr)
        {
            _EstimationStatementAttendanceStatementDb = new EstimationStatementAttendanceStatementDb(objDr);
            _AttendanceStatementBiz = new AttendanceStatementBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int EstimationStatement
        {
            set
            {
                _EstimationStatementAttendanceStatementDb.EstimationStatement = value;
            }
            get
            {
                return _EstimationStatementAttendanceStatementDb.EstimationStatement;
            }
        }
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
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _EstimationStatementAttendanceStatementDb.AttendanceStatement = _AttendanceStatementBiz.ID;
            _EstimationStatementAttendanceStatementDb.Add();
        }
        #endregion
    }
}
