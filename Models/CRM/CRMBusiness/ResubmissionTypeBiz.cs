using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ResubmissionTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public ResubmissionTypeBiz()
        {
            _BaseDb = new ResubmissionTypeDb();
        }
        public ResubmissionTypeBiz(int intID)
        {
            _BaseDb = new ResubmissionTypeDb(intID);
        }
        public ResubmissionTypeBiz(DataRow objDR)
        {
            _BaseDb = new ResubmissionTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((ResubmissionTypeDb)_BaseDb).Add();
            ResubmissionTypeCol.CacheTypeCol = null;
        }
        public void Edit()
        {
            ((ResubmissionTypeDb)_BaseDb).Edit();
            ResubmissionTypeCol.CacheTypeCol = null;
        }
        public void Delete()
        {
            ((ResubmissionTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
