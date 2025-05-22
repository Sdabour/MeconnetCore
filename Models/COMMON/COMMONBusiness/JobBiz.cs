using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class JobBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobBiz()
        {
            _BaseDb = new JobDb();
        }
        public JobBiz(int intJobID)
        {
            _BaseDb = new JobDb(intJobID);
        }
        public JobBiz(DataRow objDR)
        {
            _BaseDb = new JobDb(objDR);
        }

        public JobBiz(JobDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                ((JobDb)_BaseDb).VIP = value;
            }
            get
            {
                return ((JobDb)_BaseDb).VIP;
            }
        }
        public int JobTitleID
        {
            set
            {
                ((JobDb)_BaseDb).JobTitleID = value;
            }
            get
            {
                return ((JobDb)_BaseDb).JobTitleID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE, bool blVIP,int intJobTitleID)
        {

            JobDb objJobDb = new JobDb();
            objJobDb.NameA = strJobNameA;
            objJobDb.NameE = strJobNameE;
            objJobDb.VIP = blVIP;
            objJobDb.JobTitleID = intJobTitleID;
            objJobDb.Add();
        }
        public static void Edit(int intJobID, string strJobNameA, string strJobNameE, bool blVIP, int intJobTitleID)
        {
            JobDb objJobDb = new JobDb();
            objJobDb.ID = intJobID;
            objJobDb.NameA = strJobNameA;
            objJobDb.NameE = strJobNameE;
            objJobDb.VIP = blVIP;
            objJobDb.JobTitleID = intJobTitleID;
            objJobDb.Edit();
        }
        public static void Delete(int intJobID)
        {
            JobDb objJobDb = new JobDb();
            objJobDb.ID = intJobID;
            objJobDb.Delete();
        }
        public JobBiz Copy()
        {
            JobBiz Returned = new JobBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.VIP = this.VIP;
            Returned.JobTitleID = this.JobTitleID;

            return Returned;
        }
        #endregion
    }
}
