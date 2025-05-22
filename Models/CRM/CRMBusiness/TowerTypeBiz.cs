using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public TowerTypeBiz()
        {
            _BaseDb = new TowerTypeDb();
        }
        public TowerTypeBiz(int intID)
        {
            _BaseDb = new TowerTypeDb(intID);
        }
        public TowerTypeBiz(DataRow objDR)
        {
            _BaseDb = new TowerTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((TowerTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((TowerTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((TowerTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
