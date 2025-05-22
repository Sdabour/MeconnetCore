using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ServiceBiz : BaseSelfeRelatedBiz
    {
         #region Private Data
        ServiceCol _ServiceChildren;
        ServiceDb _FunctionDb;
        #endregion
        #region Constructors
        public ServiceBiz()
        {

            _FunctionDb = new ServiceDb();
        }
      
        public ServiceBiz(DataRow DR)
        {
            _FunctionDb = new ServiceDb(DR);
        }
        public ServiceBiz(ServiceDb objServiceDb)
        {
            _FunctionDb = objServiceDb;
        }


        #endregion
        #region Public Properties
       
        public ServiceBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                {
                    //if (_FunctionDb.ID == _FunctionDb.ParentID)
                    //    _ParentBiz = this;
                    //else
                    //    _ParentBiz = new ServiceBiz();
                }
                return (ServiceBiz)_ParentBiz;

            }
        }
        public ServiceCol ServiceChildren
        {
            set
            {
                _ServiceChildren = value;
            }
            get
            {
                return _ServiceChildren;
            }
        }
         
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strName, string strDescription, int intParentID, int intFamilyID,int intSysID)
        {
            ServiceDb objServiceDb = new ServiceDb();
            objServiceDb.NameA = strName;
            //objServiceDb.Description = strDescription;
            //objServiceDb.ParentID = intParentID;
            //objServiceDb.FamilyID = intFamilyID;
            //objServiceDb.SysID = intSysID;
            objServiceDb.Add();
        }
        public static void Edit(int intID, string strName, string strDescription, int intParentID, int intFamilyID,int intSysID)
        {
            ServiceDb objServiceDb = new ServiceDb();
            objServiceDb.ID = intID;
            objServiceDb.NameA = strName;
            //objServiceDb.Description = strDescription;
            //objServiceDb.ParentID = intParentID;
            //objServiceDb.FamilyID = intFamilyID;
            //objServiceDb.SysID = intSysID;
            objServiceDb.Edit();

        }
        public static void Delete(int intID)
        {
            ServiceDb objServiceDb = new ServiceDb();
            objServiceDb.ID = intID;
            objServiceDb.Delete();
        }
        public ServiceBiz Copy()
        {
            ServiceBiz Returned = new ServiceBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.Name;
            
            Returned.ParentID = this.ParentID;
            Returned.ParentBiz = this.ParentBiz;
            Returned.FamilyID = this.FamilyID;
            
            return Returned;
        }
        #endregion

    }
}
