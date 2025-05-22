using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class RecoginationMediaTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public RecoginationMediaTypeBiz()
        {
            _BaseDb = new RecoginationMediaTypeDb();
        }
        public RecoginationMediaTypeBiz(int intID)
        {
            _BaseDb = new RecoginationMediaTypeDb(intID);
        }
        public RecoginationMediaTypeBiz(DataRow objDR)
        {
            _BaseDb = new RecoginationMediaTypeDb(objDR);
        }

        public RecoginationMediaTypeBiz(RecoginationMediaTypeDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public  void Add()
        {
            ((RecoginationMediaTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((RecoginationMediaTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((RecoginationMediaTypeDb)_BaseDb).Delete();
        }
        public RecoginationMediaTypeBiz  Copy()
        {
            RecoginationMediaTypeBiz Returned = new RecoginationMediaTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        #endregion
    }
}
