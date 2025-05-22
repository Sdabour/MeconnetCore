using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
//using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ModelComponantBiz
    {
        #region Private Data
        UnitModelBiz _ModelBiz;
       
        ComponantBiz _ComponantBiz;
        ModelComponantDb _ModelComponantDb;
        #endregion
        #region Constructors
        public ModelComponantBiz()
        {
           
            _ModelBiz = new UnitModelBiz();
            _ModelComponantDb = new ModelComponantDb();
        }
        public ModelComponantBiz(DataRow objDr)
        {
            _ModelComponantDb = new ModelComponantDb(objDr);
            _ComponantBiz = new ComponantBiz(objDr);
        }
      
        #endregion
        #region Public Properties
        public UnitModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                return _ModelBiz;
            }
        }
        public ComponantBiz ComponantBiz
        {
            set
            {
                _ComponantBiz = value;
            }
            get
            {
                return _ComponantBiz;
            }
        }
        public double Width
        {
            set
            {
                _ModelComponantDb.Width = value;
            }
            get
            {
                return _ModelComponantDb.Width;
            }
        }
        public double Length
        {
            set
            {
                _ModelComponantDb.Length = value;
            }
            get
            {
                return _ModelComponantDb.Length;
            }
        }
        public int No
        {
            set
            {
                _ModelComponantDb.No = value;
            }
            get
            {
                return _ModelComponantDb.No;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
