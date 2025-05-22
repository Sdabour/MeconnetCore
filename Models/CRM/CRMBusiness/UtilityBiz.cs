using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UtilityBiz : BaseSingleBiz
    {
        #region Private Data
        //UtilityDb _UtilityDb;
        #endregion
        #region Constructors
        public UtilityBiz()
        {
            _BaseDb = new UtilityDb();
        }
        public UtilityBiz(int intID)
        {
            _BaseDb = new UtilityDb(intID);
        }
        public UtilityBiz(DataRow objDR)
        {
            _BaseDb = new UtilityDb(objDR);
        }
        #endregion
        #region Public Properties
        public string LikeNameA
        {
            set
            {
                ((UtilityDb)_BaseDb).LikeNameA = value;
            }
            
        }
        public string LikeNameE
        {
            set
            {
                ((UtilityDb)_BaseDb).LikeNameE = value;
            }
           
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _BaseDb.Add();

        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        #endregion
    }
}
