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
    public class CellLocationCol :LocationCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public CellLocationCol(bool blIsEmpty):base(blIsEmpty)
        {
 
        }
        #endregion
        #region Public Properties
        public CellLocationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (CellLocationBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CellLocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
