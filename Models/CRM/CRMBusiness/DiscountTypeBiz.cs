using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class DiscountTypeBiz : BaseSingleBiz
    {

         #region Private Data
        #endregion

        #region Constractors
        public DiscountTypeBiz()
        {
            _BaseDb = new DiscountTypeDb();
        }
        public DiscountTypeBiz(int intID)
        {
            _BaseDb = new DiscountTypeDb(intID);
        }
        public DiscountTypeBiz(DataRow objDR)
        {
            _BaseDb = new DiscountTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((DiscountTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
           ((DiscountTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((DiscountTypeDb)_BaseDb).Delete();
        }
        #endregion

    }
}
