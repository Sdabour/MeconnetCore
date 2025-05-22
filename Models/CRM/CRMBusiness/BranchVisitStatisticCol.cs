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
    public class BranchVisitStatisticCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public BranchVisitStatisticCol()
        {
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual BranchVisitStatisticBiz this[int intIndex]
        {
            get
            {
                return (BranchVisitStatisticBiz)this.List[intIndex];
            }
        }
        public virtual void Add(BranchVisitStatisticBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Public Methods
        public BranchVisitStatisticBiz CheckExist(int intBranchID)
        {
            foreach (BranchVisitStatisticBiz objBiz in this)
            {
                if (objBiz.BranchBiz.ID == intBranchID)
                    return objBiz;
            }
            return null;
        }
        #endregion
    }
}
