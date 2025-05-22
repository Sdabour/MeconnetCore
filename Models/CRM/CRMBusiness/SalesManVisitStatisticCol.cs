using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class SalesManVisitStatisticCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public SalesManVisitStatisticCol()
        {
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual SalesManVisitStatisticBiz this[int intIndex]
        {
            get
            {
                return (SalesManVisitStatisticBiz)this.List[intIndex];
            }
        }
        public virtual void Add(SalesManVisitStatisticBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Public Methods
        public SalesManVisitStatisticBiz CheckExist(int intSalesManID, int intBranchID)
        {
            foreach (SalesManVisitStatisticBiz objBiz in this)
            {
                if (objBiz.BranchBiz.ID == intBranchID
                    && objBiz.SalesManBiz.ID == intSalesManID)
                    return objBiz;
            }
            return null;
        }
        #endregion
    }
}
