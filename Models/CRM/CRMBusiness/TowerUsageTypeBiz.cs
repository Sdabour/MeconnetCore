using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerUsageTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public TowerUsageTypeBiz()
        {
            _BaseDb = new TowerUsageTypeDb();
        }
        public TowerUsageTypeBiz(int intID)
        {
            _BaseDb = new TowerUsageTypeDb(intID);
        }
        public TowerUsageTypeBiz(DataRow objDR)
        {
            _BaseDb = new TowerUsageTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((TowerUsageTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((TowerUsageTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((TowerUsageTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
