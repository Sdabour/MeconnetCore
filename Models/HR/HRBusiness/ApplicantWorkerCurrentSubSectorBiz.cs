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
    public class ApplicantWorkerCurrentSubSectorBiz
    {
        #region Private Data
        ApplicantWorkerCurrentSubSectorDb _ApplicantWorkerCurrentSubSectorDb;
        SubSectorBiz _SubSectorBiz;
        JobTypeBiz _JobTypeBiz;
        JobTitleTypeBiz _JobTitleTypeBiz;
        JobNatureTypeBiz _JobNatureTypeBiz;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerCurrentSubSectorBiz()
        {
            _ApplicantWorkerCurrentSubSectorDb = new ApplicantWorkerCurrentSubSectorDb();
            //_SubSectorBiz = new SubSectorBiz();
            _JobTypeBiz = new JobTypeBiz();
            _JobTitleTypeBiz = new JobTitleTypeBiz();
            _JobNatureTypeBiz = new JobNatureTypeBiz();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();

        }
        public ApplicantWorkerCurrentSubSectorBiz(DataRow objDR)
        {
            _ApplicantWorkerCurrentSubSectorDb = new ApplicantWorkerCurrentSubSectorDb(objDR);

            if (objDR["BranchID"].ToString() == "" || objDR["BranchID"].ToString() == "0")
                _SubSectorBiz = new SubSectorCellBiz(objDR);
            else
                _SubSectorBiz = new SubSectorBranchBiz(objDR);
            
            if (objDR["JobID"].ToString() != "")
            {
                _JobTypeBiz = new JobTypeBiz(objDR);
            }
            else
            {
                _JobTypeBiz = new JobTypeBiz();
            }
            if (objDR["JobTitleID"].ToString() != "")
            {
                _JobTitleTypeBiz = new JobTitleTypeBiz(objDR);
            }
            else
            {
                _JobTitleTypeBiz = new JobTitleTypeBiz();
            }
            if (objDR["JobNatureID"].ToString() != "")
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz(objDR);
            }
            else
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz();
            }

            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDR);
            
        }
        public ApplicantWorkerCurrentSubSectorBiz(int intWorkerID, int intSubSectorID)
        {
            _ApplicantWorkerCurrentSubSectorDb = new ApplicantWorkerCurrentSubSectorDb(intWorkerID, intSubSectorID);
            _JobTypeBiz = JobTypeCol.GetJobTypeBiz(_ApplicantWorkerCurrentSubSectorDb.JobID);
            _JobTitleTypeBiz = JobTitleTypeCol.GetJobTitleTypeBiz(_ApplicantWorkerCurrentSubSectorDb.JobTitleID);
            _JobNatureTypeBiz = JobNatureTypeCol.GetJobNatureTypeBiz(_ApplicantWorkerCurrentSubSectorDb.JobNatureID);
            _JobCategoryEstimationBiz = JobCategoryEstimationCol.GetJobCategoryEstimationBiz(_ApplicantWorkerCurrentSubSectorDb.JobCategoryEstimation);
        }
        #endregion
        #region Public Properties
        public int ApplicantWorkerID
        {
            set
            {
                _ApplicantWorkerCurrentSubSectorDb.ApplicantWorkerID = value;
            }
            get
            {
                return _ApplicantWorkerCurrentSubSectorDb.ApplicantWorkerID;
            }

        }       
        public int SubOrdinationID
        {
            set
            {
                _ApplicantWorkerCurrentSubSectorDb.SubOrdinationID = value;
            }
            get
            {
                return _ApplicantWorkerCurrentSubSectorDb.SubOrdinationID;
            }

        }       
        public string Description
        {
            set
            {
                _ApplicantWorkerCurrentSubSectorDb.Description = value;
            }
            get
            {
                return _ApplicantWorkerCurrentSubSectorDb.Description;
            }
        }
        public DateTime FromDate
        {
            set { _ApplicantWorkerCurrentSubSectorDb.FromDate = value; }
            get { return _ApplicantWorkerCurrentSubSectorDb.FromDate; }
        }
        public DateTime ToDate
        {
            set { _ApplicantWorkerCurrentSubSectorDb.ToDate = value; }
            get { return _ApplicantWorkerCurrentSubSectorDb.ToDate; }
        }
        public bool StatusFromDate
        {
            set
            {
                _ApplicantWorkerCurrentSubSectorDb.StatusFromDate = value;
            }
            get
            {
                return _ApplicantWorkerCurrentSubSectorDb.StatusFromDate;
            }
        }
        public bool StatusToDate
        {
            set
            {
                _ApplicantWorkerCurrentSubSectorDb.StatusToDate = value;
            }
            get
            {
                return _ApplicantWorkerCurrentSubSectorDb.StatusToDate;
            }
        }        
        public SubSectorBiz SubSectorBiz
        {
            set
            {
                _SubSectorBiz = value;
            }
            get
            {
                if (_SubSectorBiz == null)
                    _SubSectorBiz = new SubSectorBranchBiz();
                return _SubSectorBiz;
            }
        }
        public JobTypeBiz JobTypeBiz
        {
            set
            {
                _JobTypeBiz = value;
            }
            get
            {
                return _JobTypeBiz;
            }
        }
        public JobTitleTypeBiz JobTitleTypeBiz 
        {
            set
            {
                _JobTitleTypeBiz = value;
            }
            get
            {
                return _JobTitleTypeBiz;
            }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set
            {
                _JobNatureTypeBiz = value;
            }
            get
            {
                return _JobNatureTypeBiz;
            }
        }
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            set
            {
                _JobCategoryEstimationBiz = value;
            }
            get
            {
                return _JobCategoryEstimationBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerCurrentSubSectorDb.JobID = JobTypeBiz.ID;
            _ApplicantWorkerCurrentSubSectorDb.JobTitleID = JobTitleTypeBiz.ID;
            _ApplicantWorkerCurrentSubSectorDb.JobNatureID = JobNatureTypeBiz.ID;
            _ApplicantWorkerCurrentSubSectorDb.SubSectorID = _SubSectorBiz.ID;
            _ApplicantWorkerCurrentSubSectorDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            _ApplicantWorkerCurrentSubSectorDb.Add();
        }
        public void Edit()
        {
        }
        public void Delete()
        {
            _ApplicantWorkerCurrentSubSectorDb.Delete();
        }
     
        #endregion
    }
}
