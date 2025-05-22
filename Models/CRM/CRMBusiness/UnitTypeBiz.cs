using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitTypeBiz()
        {
            _BaseDb = new UnitTypeDb();
        }
        public UnitTypeBiz(int intID)
        {
            _BaseDb = new UnitTypeDb(intID);
        }
        public UnitTypeBiz(DataRow objDR)
        {
            _BaseDb = new UnitTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((UnitTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
           ((UnitTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((UnitTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
