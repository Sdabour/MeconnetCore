using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class JobNatureTypeBiz : BaseSingleBiz
    {
        #region Private Data
        JobCategoryBiz _JobCategory;
        #endregion
        #region Constructors
        public JobNatureTypeBiz()
        {
            _BaseDb = new JobNatureTypeDb();
            _JobCategory=new JobCategoryBiz();
        }
        public JobNatureTypeBiz(int intJobID)
        {
            _BaseDb = new JobNatureTypeDb(intJobID);
            _JobCategory = JobCategoryCol.GetJobCategoryBiz(((JobNatureTypeDb)_BaseDb).JobCategory);
        }
        public JobNatureTypeBiz(DataRow objDR)
        {
            _BaseDb = new JobNatureTypeDb(objDR);
            _JobCategory = new JobCategoryBiz(objDR);
        }

        public JobNatureTypeBiz(JobNatureTypeDb objJobNatureDb)
        {
            _BaseDb = objJobNatureDb;
            _JobCategory = new JobCategoryBiz();
        }
        #endregion
        #region Public Properties
        public string NameAComp
        {
            set
            {
                ((JobNatureTypeDb)_BaseDb).NameAComp = value;
            }
            get
            {
                return ((JobNatureTypeDb)_BaseDb).NameAComp;
            }
        }
        public bool VIP
        {
            set
            {
                ((JobNatureTypeDb)_BaseDb).VIP = value;
            }
            get
            {
                return ((JobNatureTypeDb)_BaseDb).VIP;
            }
        }
        public int JobID
        {
            set
            {
                ((JobNatureTypeDb)_BaseDb).JobID = value;
            }
            get
            {
                return ((JobNatureTypeDb)_BaseDb).JobID;
            }
        }
        public JobCategoryBiz JobCategory
        {
            set
            {
                _JobCategory = value;
            }
            get
            {
                return _JobCategory;
            }
        }
        public bool RelatedBySkeleton
        {
            set
            {
                ((JobNatureTypeDb)_BaseDb).RelatedBySkeleton = value;
            }
            get
            {
                return ((JobNatureTypeDb)_BaseDb).RelatedBySkeleton;
            }
        }
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            get
            {
                JobCategoryEstimationJobNatureBiz objBiz = new JobCategoryEstimationJobNatureBiz(this);
                return objBiz.JobCategoryEstimationBiz;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameAComp, string strJobNameE, bool blVIP, int intJobID, bool blRelatedBySkeleton,int intJobCategory)
        {

            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.NameA = strJobNameA;
            objJobNatureTypeDb.NameAComp = strJobNameAComp;
            objJobNatureTypeDb.NameE = strJobNameE;
            objJobNatureTypeDb.VIP = blVIP;
            objJobNatureTypeDb.RelatedBySkeleton = blRelatedBySkeleton;
            objJobNatureTypeDb.JobID = intJobID;
            objJobNatureTypeDb.JobCategory = intJobCategory;
            objJobNatureTypeDb.Add();
        }
        public static void Edit(int intJobNatureID, string strJobNameA, string strJobNameAComp, string strJobNameE, bool blVIP, int intJobID, bool blRelatedBySkeleton, int intJobCategory)
        {
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.ID = intJobNatureID;
            objJobNatureTypeDb.NameA = strJobNameA;
            objJobNatureTypeDb.NameAComp = strJobNameAComp;
            objJobNatureTypeDb.NameE = strJobNameE;
            objJobNatureTypeDb.VIP = blVIP;
            objJobNatureTypeDb.RelatedBySkeleton = blRelatedBySkeleton;
            objJobNatureTypeDb.JobID = intJobID;
            objJobNatureTypeDb.JobCategory = intJobCategory;
            objJobNatureTypeDb.Edit();
        }
        public static void Delete(int intJobID)
        {
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.ID = intJobID;
            objJobNatureTypeDb.Delete();
        }
        public JobNatureTypeBiz Copy()
        {
            JobNatureTypeBiz Returned = new JobNatureTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameAComp = this.NameAComp;
            Returned.NameE = this.NameE;
            Returned.JobID = this.JobID;
            Returned.JobCategory = this.JobCategory;
            Returned.VIP = this.VIP;
            Returned.RelatedBySkeleton = this.RelatedBySkeleton;  

            return Returned;
        }
        #endregion
    }
}
