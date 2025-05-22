using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class JobTitleBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobTitleBiz()
        {
            _BaseDb = new JobTitleDb();
        }
        public JobTitleBiz(int intJobID)
        {
            _BaseDb = new JobTitleDb(intJobID);
        }
        public JobTitleBiz(DataRow objDR)
        {
            _BaseDb = new JobTitleDb(objDR);
        }

        public JobTitleBiz(JobTitleDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                ((JobTitleDb)_BaseDb).VIP = value;
            }
            get
            {
                return ((JobTitleDb)_BaseDb).VIP;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE, bool blVIP)
        {

            JobTitleDb objJobTitleDb = new JobTitleDb();
            objJobTitleDb.NameA = strJobNameA;
            objJobTitleDb.NameE = strJobNameE;
            objJobTitleDb.VIP = blVIP;
            objJobTitleDb.Add();
        }
        public static void Edit(int intJobID, string strJobNameA, string strJobNameE, bool blVIP)
        {
            JobTitleDb objJobTitleDb = new JobTitleDb();
            objJobTitleDb.ID = intJobID;
            objJobTitleDb.NameA = strJobNameA;
            objJobTitleDb.NameE = strJobNameE;
            objJobTitleDb.VIP = blVIP;
            objJobTitleDb.Edit();
        }
        public static void Delete(int intJobID)
        {
            JobTitleDb objJobTitleDb = new JobTitleDb();
            objJobTitleDb.ID = intJobID;
            objJobTitleDb.Delete();
        }
        public JobTitleBiz Copy()
        {
            JobTitleBiz Returned = new JobTitleBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.VIP = this.VIP;

            return Returned;
        }
        #endregion
    }
}
