using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class ContactBiz : BaseSingleBiz
    {
        #region Private Data
       // public ContactDb _ContactDb;
        #endregion
        #region Constructors
        public ContactBiz()
        {
            _BaseDb = new ContactDb();
        }
        public ContactBiz(int intContactID)
        {
            _BaseDb = new ContactDb(intContactID);

        }
        public ContactBiz(DataRow objDR)
        {
            _BaseDb = new ContactDb(objDR);

        }
        public ContactBiz(ContactDb objContactDb)
        {
            _BaseDb = objContactDb;
        }
        #endregion
        #region Public Properties
       
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strNameA, string strNameE)
        {
            ContactDb objContactDb = new ContactDb();
            objContactDb.NameA = strNameA;
            objContactDb.NameE = strNameE;
            objContactDb.Add();

        }
        public static void Edit(int intContactID, string strNameA, string strNameE)
        {
            ContactDb objContactDb = new ContactDb();
            objContactDb.ID = intContactID;
            objContactDb.NameA = strNameA;
            objContactDb.NameE = strNameE;
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
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}
