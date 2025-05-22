using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class BrandBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public BrandBiz()
        {
            _BaseDb = new BrandDb();
        }
        public BrandBiz(int intID)
        {
            _BaseDb = new BrandDb(intID);
        }
        public BrandBiz(DataRow objDR)
        {
            _BaseDb = new BrandDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((BrandDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((BrandDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((BrandDb)_BaseDb).Delete();
        }
        #endregion
    }
}
