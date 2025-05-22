using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ContactInstantDb : ContactDb
    {
        #region Private Data
        string _ContactValue;
        #endregion
        #region Constructors
        public ContactInstantDb()
        {

        }
        public ContactInstantDb(DataRow objDR) : base(int.Parse(objDR["ContactID"].ToString()))
        {
            _ContactValue = objDR["ContactValue"].ToString();

        }
        public ContactInstantDb(int intID, string strName, string strValue)
        {
            _NameA = strName;
            _ID = intID;
            _ContactValue = strValue;
        }
        #endregion
        #region Public Properties
        public string ContactValue
        {
            set
            {
                _ContactValue = value;
            }
            get
            {
                return _ContactValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}



