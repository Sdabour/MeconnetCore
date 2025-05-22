using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class AttendanceTimeApplicantBiz : AttendanceTimeBiz
    {
        #region Private Data
        ApplicantWorkerBiz _AttendanceApplicant;
        protected AttachmentFileBiz _Attachment;        
        protected string _Path;
        ShiftBiz _ShiftBiz; 
        #endregion
        #region Constructors
        public AttendanceTimeApplicantBiz()
        {
            _AttendanceTimeDb = new AttendanceTimeApplicantDb();
            _AttendanceApplicant = new ApplicantWorkerBiz();
             
        }
        public AttendanceTimeApplicantBiz(DataRow objDr)
        {
            _AttendanceTimeDb = new AttendanceTimeApplicantDb(objDr);
            try
            {
                if (objDr["AttendanceApplicant"].ToString() != "" &&objDr["AttendanceApplicant"].ToString() != "0")
                    _AttendanceApplicant = new ApplicantWorkerBiz(objDr);
            }
            catch
            {
            }
            _ShiftBiz = new ShiftBiz(objDr);
        }
        #endregion
        #region Public Properties

        public ApplicantWorkerBiz AttendanceApplicant
        {
            set
            {
                _AttendanceApplicant = value;
            }
            get
            {
                return _AttendanceApplicant;
            }
        }
      
        
                          
        public string strApplicant
        {
            get
            {
                return AttendanceApplicant.Name;
            }
        }
        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
           
        
        }
        public void Edit()
        {
             
        }
        public void Delete()
        {
          
            
        }
        #endregion
    }
}
