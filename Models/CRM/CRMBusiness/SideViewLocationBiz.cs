using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class SideViewLocationBiz : LocationBiz
    {
        #region Private Data
        LayoutBiz _LayoutBiz;
        
        #endregion
        #region Constructors
        public SideViewLocationBiz()
        {
            _LocationDb = new SideViewLocationDb();

        }
        public SideViewLocationBiz(DataRow objDr)
        {
            _LocationDb = new SideViewLocationDb(objDr);
           
        }
        #endregion
        #region Public Properties
        public LayoutBiz LayoutBiz
        {
            set
            {
                _LayoutBiz = value;
            }
            get
            {
                return _LayoutBiz;
            }
        }
        public string Desc
        {
            set
            {
                ((SideViewLocationDb)_LocationDb).Desc = value;
            }
            get
            {
                return ((SideViewLocationDb)_LocationDb).Desc;
            }
        }
        public int Order
        {
            set
            {
                ((SideViewLocationDb)_LocationDb).Order = value;
            }
            get
            {
                return ((SideViewLocationDb)_LocationDb).Order;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((SideViewLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((SideViewLocationDb)_LocationDb).Add();
            _LayoutBiz.SideViewLocationTable = null;

        }
        public void Edit()
        {
            ((SideViewLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((SideViewLocationDb)_LocationDb).Edit();
            _LayoutBiz.SideViewLocationTable = null;
        }
        public void Delete()
        {
            ((SideViewLocationDb)_LocationDb).Delete();
            _LayoutBiz.SideViewLocationTable = null;

        }
        #endregion
    }
}
