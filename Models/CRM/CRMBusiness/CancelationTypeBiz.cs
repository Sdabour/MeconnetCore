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
    public class CancelationTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public CancelationTypeBiz()
        {
            _BaseDb = new CancelationTypeDb();
        }
        public CancelationTypeBiz(DataRow objDR)
        {
            _BaseDb = new CancelationTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice


        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {

            ((CancelationTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {

            ((CancelationTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CancelationTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
