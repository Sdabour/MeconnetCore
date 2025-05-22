using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class JobTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobTypeBiz()
        {
            _BaseDb = new JobTypeDb();
        }
        public JobTypeBiz(int intJobID)
        {
            _BaseDb = new JobTypeDb(intJobID);
        }
        public JobTypeBiz(DataRow objDR)
        {
            _BaseDb = new JobTypeDb(objDR);
        }

        public JobTypeBiz(JobTypeDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                ((JobTypeDb)_BaseDb).VIP = value;
            }
            get
            {
                return ((JobTypeDb)_BaseDb).VIP;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE, bool blVIP)
        {

            JobTypeDb objJobTypeDb = new JobTypeDb();
            objJobTypeDb.NameA = strJobNameA;
            objJobTypeDb.NameE = strJobNameE;
            objJobTypeDb.VIP = blVIP;
            objJobTypeDb.Add();
        }
        public static void Edit(int intJobID, string strJobNameA, string strJobNameE, bool blVIP)
        {
            JobTypeDb objJobTypeDb = new JobTypeDb();
            objJobTypeDb.ID = intJobID;
            objJobTypeDb.NameA = strJobNameA;
            objJobTypeDb.NameE = strJobNameE;
            objJobTypeDb.VIP = blVIP;
            objJobTypeDb.Edit();
        }
        public static void Delete(int intJobID)
        {
            JobTypeDb objJobTypeDb = new JobTypeDb();
            objJobTypeDb.ID = intJobID;
            objJobTypeDb.Delete();
        }
        public JobTypeBiz Copy()
        {
            JobTypeBiz Returned = new JobTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.VIP = this.VIP;

            return Returned;
        }
        #endregion
    }
}
