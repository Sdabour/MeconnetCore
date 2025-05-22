using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class IDTypeInstantDb : IDTypeDb
    {
        #region Private Data
        string _IDValue;
        #endregion

        #region Constructors
        public IDTypeInstantDb()
        {

        }
        public IDTypeInstantDb(DataRow objDR) : base(objDR)
        {
            _IDValue = objDR["IDValue"].ToString();
            ///_ID = int.Parse(objDR["WorkerIDType"].ToString());

        }
        public IDTypeInstantDb(int intID, string strName, string strValue)
        {
            _NameA = strName;
            _ID = intID;
            _IDValue = strValue;
        }
        #endregion
        #region Public Properties
        public string IDValue
        {
            set
            {
                _IDValue = value;
            }
            get
            {
                if (_IDValue == null)
                    _IDValue = "";
                return _IDValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
