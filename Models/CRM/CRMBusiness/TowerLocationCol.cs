using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class TowerLocationCol : LocationCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public TowerLocationCol(bool blIsEmpty) : base(blIsEmpty)
        {

        }
        #endregion
        #region Public Properties
        public TowerLocationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (TowerLocationBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(TowerLocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
