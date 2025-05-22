using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerWorkCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CustomerWorkCol()
        {
            CustomerWorkDb objDb = new CustomerWorkDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerWorkBiz(objDr));
            }
        }
        public CustomerWorkCol(CustomerBiz objBiz)
        {
            CustomerWorkDb objDb = new CustomerWorkDb();
            objDb.Customer = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerWorkBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual CustomerWorkBiz this[int intIndex]
        {
            get
            {
                return (CustomerWorkBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        public virtual void Add(CustomerWorkBiz objVisitBiz)
        {
            this.List.Add(objVisitBiz);
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
