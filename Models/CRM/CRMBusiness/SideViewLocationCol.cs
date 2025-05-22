using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class SideViewLocationCol : LocationCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public SideViewLocationCol(bool blIsEmpty)
            : base(blIsEmpty)
        {

        }
        #endregion
        #region Public Properties
        public SideViewLocationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (SideViewLocationBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(SideViewLocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
