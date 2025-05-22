using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class EmployeeSectorAssignmentBiz
    {
        #region Private Data
        EmployeeSectorAssignmentDb _AssigmentDb;
        #endregion
        #region Constructors
        public EmployeeSectorAssignmentBiz()
        {
            _AssigmentDb = new EmployeeSectorAssignmentDb();
        }
        public EmployeeSectorAssignmentBiz(DataRow objDr)
        {
            _AssigmentDb = new EmployeeSectorAssignmentDb(objDr);
            _SectorBiz = new SectorBiz(objDr);

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AssigmentDb.ID = value;
            }
            get
            {
                return _AssigmentDb.ID;
            }
        }
        EmployeeBiz _EmployeeBiz;

        public EmployeeBiz EmployeeBiz
        {
            get {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz; }
            set { _EmployeeBiz = value; }
        }
       


        SectorBiz _SectorBiz;

        public SectorBiz SectorBiz
        {
            get {
                if (_SectorBiz == null)
                    _SectorBiz = new SectorBiz();
                return _SectorBiz; }
            set { _SectorBiz = value; }
        }


        public bool IsPermanent
        {
            get { return _AssigmentDb.IsPermanent; }
            set { _AssigmentDb.IsPermanent = value; }
        }
      

        public DateTime EndDate
        {
            get { return _AssigmentDb.EndDate; }
            set { _AssigmentDb.EndDate = value; }
        }
        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
