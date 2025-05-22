using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class JobTitleTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobTitleTypeBiz()
        {
            _BaseDb = new JobTitleTypeDb();
        }
        public JobTitleTypeBiz(int intJobID)
        {
            _BaseDb = new JobTitleTypeDb(intJobID);
        }
        public JobTitleTypeBiz(DataRow objDR)
        {
            _BaseDb = new JobTitleTypeDb(objDR);
        }

        public JobTitleTypeBiz(JobTitleTypeDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                ((JobTitleTypeDb)_BaseDb).VIP = value;
            }
            get
            {
                return ((JobTitleTypeDb)_BaseDb).VIP;
            }
        }
        public int JobID
        {
            set
            {
                ((JobTitleTypeDb)_BaseDb).JobID = value;
            }
            get
            {
                return ((JobTitleTypeDb)_BaseDb).JobID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE, bool blVIP,int intJobID)
        {

            JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
            objJobTitleTypeDb.NameA = strJobNameA;
            objJobTitleTypeDb.NameE = strJobNameE;
            objJobTitleTypeDb.VIP = blVIP;
            objJobTitleTypeDb.JobID = intJobID;
            objJobTitleTypeDb.Add();
        }
        public static void Edit(int intJobTitleID, string strJobNameA, string strJobNameE, bool blVIP, int intJobID)
        {
            JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
            objJobTitleTypeDb.ID = intJobTitleID;
            objJobTitleTypeDb.NameA = strJobNameA;
            objJobTitleTypeDb.NameE = strJobNameE;
            objJobTitleTypeDb.VIP = blVIP;
            objJobTitleTypeDb.JobID = intJobID;
            objJobTitleTypeDb.Edit();
        }
        public static void Delete(int intJobID)
        {
            JobTitleTypeDb objJobTitleTypeDb = new JobTitleTypeDb();
            objJobTitleTypeDb.ID = intJobID;
            objJobTitleTypeDb.Delete();
        }
        public JobTitleTypeBiz Copy()
        {
            JobTitleTypeBiz Returned = new JobTitleTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.JobID = this.JobID;
            Returned.VIP = this.VIP;

            return Returned;
        }
        #endregion
    }
}
