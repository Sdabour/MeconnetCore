using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitViewBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitViewBiz()
        {
            _BaseDb = new UnitViewDb();
        }
        public UnitViewBiz(int intID)
        {
            _BaseDb = new UnitViewDb(intID);
        }
        public UnitViewBiz(DataRow objDR)
        {
            _BaseDb = new UnitViewDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((UnitViewDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((UnitViewDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((UnitViewDb)_BaseDb).Delete();
        }
        #endregion
    }
}
