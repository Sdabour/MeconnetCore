using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public class CheckBookBiz
    {
        #region Private Data
        CheckBookDb _BookDb;

        #endregion
        #region Constructors
        public CheckBookBiz()
        {
            _BookDb = new CheckBookDb();
        }
        public CheckBookBiz(DataRow objDr)
        {
 
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
