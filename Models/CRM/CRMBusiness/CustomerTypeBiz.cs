using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerTypeBiz : BaseSingleBiz
    {
        #region Private Data
       // protected CustomerTypeDb _BaseDb;
        #endregion
        #region Constructors
        public CustomerTypeBiz()
        {
            _BaseDb = new CustomerTypeDb();
        }
        public CustomerTypeBiz(int intCustomerTypeID)
        {
            _BaseDb = new CustomerTypeDb(intCustomerTypeID);
        }
        public CustomerTypeBiz(DataRow objDR)
        {
            _BaseDb = new CustomerTypeDb(objDR);
        }

        public CustomerTypeBiz(CustomerTypeDb objCustomerTypeDb)
        {
            _BaseDb = objCustomerTypeDb;
        }
        public CustomerTypeBiz(int intID, string strName,bool blIsSecondary)
        {
            _BaseDb = new CustomerTypeDb(intID,strName,blIsSecondary);
            
 
        }
        #endregion
        #region Public Properties
      
        public bool IsSecondaryType
        {
            set
            {
               ((CustomerTypeDb) _BaseDb).IsSecondaryType = value;
            }
            get
            {
                return ((CustomerTypeDb)_BaseDb).IsSecondaryType;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strCustomerTypeName,bool blIsSecondary)
        {

            CustomerTypeDb objCustomerTypeDb = new CustomerTypeDb();
            objCustomerTypeDb.NameA = strCustomerTypeName;
            objCustomerTypeDb.IsSecondaryType = blIsSecondary;
            objCustomerTypeDb.Add();
        }
        public static void Edit(int intCustomerTypeID, string strCustomerTypeName,bool blIsSecondaryType)
        {
            CustomerTypeDb objCustomerTypeDb = new CustomerTypeDb();
            objCustomerTypeDb.ID = intCustomerTypeID;
            objCustomerTypeDb.NameA = strCustomerTypeName;
            objCustomerTypeDb.IsSecondaryType = blIsSecondaryType;

            objCustomerTypeDb.Edit();
        }
        public static void Delete(int intCustomerTypeID)
        {
            CustomerTypeDb objCustomerTypeDb = new CustomerTypeDb();
            objCustomerTypeDb.ID = intCustomerTypeID;
            objCustomerTypeDb.Delete();
        }
        public CustomerTypeBiz Copy()
        {
            CustomerTypeBiz Returned = new CustomerTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.Name;
            Returned.IsSecondaryType = this.IsSecondaryType;
            return Returned;
        }
        #endregion
    }
}
