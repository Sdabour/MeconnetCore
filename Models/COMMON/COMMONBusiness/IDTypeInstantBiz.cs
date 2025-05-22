using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public  class IDTypeInstantBiz : IDTypeBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public IDTypeInstantBiz()
        {
             _IDTypeDb= new IDTypeInstantDb();
        }
       
        public IDTypeInstantBiz(DataRow objDR)
        {
            _IDTypeDb = new IDTypeInstantDb(objDR);
        }
        public IDTypeInstantBiz(IDTypeInstantDb objIDTypeInstantDb)
        {
            _IDTypeDb = objIDTypeInstantDb;
        }
        public IDTypeInstantBiz(IDTypeBiz objIDTypeBiz, string strValue)
        {
            _IDTypeDb = new IDTypeInstantDb(objIDTypeBiz.ID, objIDTypeBiz.Name, strValue);
        }

        #endregion
        #region Public Properties
        public string IDValue
        {
            set
            {
                ((IDTypeInstantDb)_IDTypeDb).IDValue = value;
            }
            get
            {
                return ((IDTypeInstantDb)_IDTypeDb).IDValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
