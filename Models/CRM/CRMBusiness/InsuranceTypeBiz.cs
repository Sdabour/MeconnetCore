using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class InsuranceTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public InsuranceTypeBiz()
        {
            _BaseDb = new InsuranceTypeDb();
        }
        public InsuranceTypeBiz(DataRow objDR)
        {
            _BaseDb = new InsuranceTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice


        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {

            ((InsuranceTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {

            ((InsuranceTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((InsuranceTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
