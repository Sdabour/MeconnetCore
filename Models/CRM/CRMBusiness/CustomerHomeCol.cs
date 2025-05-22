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
    public class CustomerHomeCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CustomerHomeCol()
        {
            CustomerHomeDb objDb = new CustomerHomeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerHomeBiz(objDr));
            }
        }
        public CustomerHomeCol(CustomerBiz objBiz)
        {
            CustomerHomeDb objDb = new CustomerHomeDb();
            objDb.Customer = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerHomeBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual CustomerHomeBiz this[int intIndex]
        {
            get
            {
                return (CustomerHomeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        public virtual void Add(CustomerHomeBiz objVisitBiz)
        {
            this.List.Add(objVisitBiz);
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
