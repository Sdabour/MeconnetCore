using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    internal class ContactBiz 
    {
        #region Private Data
        protected ContactDb1 _ContactDb;
        #endregion
        #region Constructors
        public ContactBiz()
        {
            _ContactDb = new ContactDb1();
        }
        public ContactBiz(int intContactID)
        {
            _ContactDb = new ContactDb1(intContactID);
        }
        public ContactBiz(DataRow objDR)
        {
            _ContactDb = new ContactDb1(objDR);
        }

        public ContactBiz(ContactDb1 objContactDb)
        {
            _ContactDb = objContactDb;
        }
        #endregion
        #region Public Properties
        public string Name
        {
            set
            {
                _ContactDb.Name = value;
            }
            get
            {
                return _ContactDb.Name;
            }
        }
        public int ID
        {
            set
            {
                _ContactDb.ID = value;
            }
            get
            {
                return _ContactDb.ID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strContactName)
        {

            SharpVision.CRM.CRMDataBase.ContactDb1 objContactDb = new ContactDb1();
            objContactDb.Name = strContactName;
            
            objContactDb.Add();
        }
        public static void Edit(int intContactID, string strContactName)
        {
            ContactDb1 objContactDb = new ContactDb1();
            objContactDb.ID = intContactID;
            objContactDb.Name = strContactName;
           
            objContactDb.Edit();
        }
        public static void Delete(int intContactID)
        {
            ContactDb objContactDb = new ContactDb();
            objContactDb.ID = intContactID;
            objContactDb.Delete();
        }
        public ContactBiz Copy()
        {
            ContactBiz Returned = new ContactBiz();
            Returned.ID = this.ID;
            Returned.Name = this.Name;
        
            return Returned;
        }
        #endregion
    }
}
