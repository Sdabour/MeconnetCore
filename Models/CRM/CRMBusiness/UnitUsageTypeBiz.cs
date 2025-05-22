using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitUsageTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitUsageTypeBiz()
        {
            _BaseDb = new UnitUsageTypeDb();
        }
        public UnitUsageTypeBiz(int intID)
        {
            _BaseDb = new UnitUsageTypeDb(intID);
        }
        public UnitUsageTypeBiz(DataRow objDR)
        {
            _BaseDb = new UnitUsageTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((UnitUsageTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((UnitUsageTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((UnitUsageTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
