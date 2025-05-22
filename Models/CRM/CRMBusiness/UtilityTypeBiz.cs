using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UtilityTypeBiz : BaseSingleBiz
    {
        #region Private Data
        //UtilityTypeDb _UtilityTypeDb;
        #endregion
        #region Constructors
        public UtilityTypeBiz()
        {
            _BaseDb = new UtilityTypeDb();
        }
        public UtilityTypeBiz(int intID)
        {
            _BaseDb = new UtilityTypeDb(intID);
        }
        public UtilityTypeBiz(DataRow objDR)
        {
            _BaseDb = new UtilityTypeDb(objDR);
        }
        #endregion
        #region Public Properties
   
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _BaseDb.Add();

        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        #endregion
    }
}
