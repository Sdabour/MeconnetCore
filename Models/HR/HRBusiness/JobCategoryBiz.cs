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
    public class JobCategoryBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public JobCategoryBiz()
        {
            _BaseDb = new JobCategoryDb();
        }
        public JobCategoryBiz(int intJobID)
        {
            _BaseDb = new JobCategoryDb(intJobID);
        }
        public JobCategoryBiz(DataRow objDR)
        {
            _BaseDb = new JobCategoryDb(objDR);
        }

        public JobCategoryBiz(JobCategoryDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties

        public int OrderValue
        {
            set
            {
                ((JobCategoryDb)_BaseDb).OrderValue = value;
            }
            get
            {
                return ((JobCategoryDb)_BaseDb).OrderValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE,int intOrderValue)
        {
            JobCategoryDb objJobCategoryDb = new JobCategoryDb();
            objJobCategoryDb.NameA = strJobNameA;
            objJobCategoryDb.NameE = strJobNameE;
            objJobCategoryDb.OrderValue = intOrderValue; 
            objJobCategoryDb.Add();
        }
        public static void Edit(int intJobCategoryID, string strJobNameA, string strJobNameE, int intOrderValue)
        {
            JobCategoryDb objJobCategoryDb = new JobCategoryDb();
            objJobCategoryDb.ID = intJobCategoryID;
            objJobCategoryDb.NameA = strJobNameA;
            objJobCategoryDb.NameE = strJobNameE;
            objJobCategoryDb.OrderValue = intOrderValue; 
            objJobCategoryDb.Edit();
        }
        public static void Delete(int intJobCategoryID)
        {
            JobCategoryDb objJobCategoryDb = new JobCategoryDb();
            objJobCategoryDb.ID = intJobCategoryID;
            objJobCategoryDb.Delete();
        }
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public JobCategoryBiz Copy()
        {
            JobCategoryBiz Returned = new JobCategoryBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.OrderValue = this.OrderValue;

            return Returned;
        }
        #endregion
    }
}
