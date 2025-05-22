using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitMainTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitMainTypeBiz()
        {
            _BaseDb = new UnitMainTypeDb();
        }
        public UnitMainTypeBiz(int intID)
        {
            _BaseDb = new UnitMainTypeDb(intID);
        }
        public UnitMainTypeBiz(DataRow objDR)
        {
            _BaseDb = new UnitMainTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((UnitMainTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((UnitMainTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((UnitMainTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
