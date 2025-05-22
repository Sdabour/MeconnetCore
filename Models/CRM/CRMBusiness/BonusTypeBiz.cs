using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class BonusTypeBiz : BaseSingleBiz
    {
          #region Private Data
        #endregion

        #region Constractors
        public BonusTypeBiz()
        {
            _BaseDb = new BonusTypeDb();
        }
        public BonusTypeBiz(int intID)
        {
            _BaseDb = new BonusTypeDb(intID);
        }
        public BonusTypeBiz(DataRow objDR)
        {
            _BaseDb = new BonusTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((BonusTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
           ((BonusTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((BonusTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
