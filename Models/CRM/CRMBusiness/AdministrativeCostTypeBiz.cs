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
    public class AdministrativeCostTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public AdministrativeCostTypeBiz()
        {
            _BaseDb = new AdministrativeCostTypeDb();
        }
        public AdministrativeCostTypeBiz(DataRow objDR)
        {
            _BaseDb = new AdministrativeCostTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice
       

        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
           
            ((AdministrativeCostTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            
            ((AdministrativeCostTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((AdministrativeCostTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
