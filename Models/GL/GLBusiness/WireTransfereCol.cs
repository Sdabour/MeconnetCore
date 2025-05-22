using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class WireTransfereCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public WireTransfereCol(bool blIsEmbty)
        {
 
        }
        #endregion
        #region Public Properties
        public WireTransfereBiz this[int intIndex]
        {
            get
            {
                return (WireTransfereBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(WireTransfereBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
