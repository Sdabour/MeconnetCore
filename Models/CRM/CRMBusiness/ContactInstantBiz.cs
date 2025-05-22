using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class ContactInstantBiz : ContactBiz
    {
        #region Private Data
        string _ContactValue;
        #endregion
        #region Constructors
        public ContactInstantBiz()
        {
            _BaseDb= new ContactInstantDb();
        }

        public ContactInstantBiz(DataRow objDR)
        {
            _BaseDb = new ContactInstantDb(objDR);
        }
        public ContactInstantBiz(ContactInstantDb objContactInstantDb)
        {
            _BaseDb = objContactInstantDb;
        }
        public ContactInstantBiz(ContactBiz objContactBiz, string strValue)
        {
            _BaseDb = new ContactInstantDb(objContactBiz.ID, objContactBiz.Name, strValue);
        }

        #endregion
        #region Public Properties
        public string ContactValue
        {
            set
            {
                ((ContactInstantDb)_BaseDb).ContactValue = value;
            }
            get
            {
                return ((ContactInstantDb)_BaseDb).ContactValue;
            }
        }
        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public ContactInstantBiz Copy()
        {
            ContactInstantBiz Returned = new ContactInstantBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.ContactValue = this.ContactValue;
            return Returned;
        }
        #endregion
    }
}
