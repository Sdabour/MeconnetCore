using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitCategoryBiz :BaseSingleBiz
    {

        #region Constructor
        public UnitCategoryBiz()
        {
            _BaseDb = new UnitCategoryDb();
        }
        public UnitCategoryBiz(DataRow objDr)
        {
            _BaseDb = new UnitCategoryDb(objDr);
        }

        #endregion
        #region Private Data
        UnitCategoryDb _UnitCategoryDb;
        #endregion
        #region Properties
      
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            ((UnitCategoryDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((UnitCategoryDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((UnitCategoryDb)_BaseDb).Delete();
        }
        #endregion
    }
}
