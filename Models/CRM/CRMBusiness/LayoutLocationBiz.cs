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
    public class LayoutLocationBiz : LocationBiz
    {
        #region Private Data
        LayoutBiz _LayoutBiz;
        LayoutBiz _ChildLayoutBiz;
        #endregion
        #region Constructors
        public LayoutLocationBiz()
        {
            _LocationDb = new LayoutLocationDb();

        }
        public LayoutLocationBiz(DataRow objDr)
        {
            _LocationDb = new LayoutLocationDb(objDr);
            _ChildLayoutBiz = new LayoutBiz(((LayoutLocationDb)_LocationDb).LayoutID);
        }
        #endregion
        #region Public Properties
        public LayoutBiz ChildLayoutBiz
        {
            set
            {
                _ChildLayoutBiz = value;
            }
            get
            {
                return _ChildLayoutBiz;
            }
        }
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
                ((LayoutLocationDb)_LocationDb).Desc = value;
            }
            get
            {
                return ((LayoutLocationDb)_LocationDb).Desc;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((LayoutLocationDb)_LocationDb).LayoutID = _ChildLayoutBiz.ID;
            ((LayoutLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((LayoutLocationDb)_LocationDb).Add();
            _LayoutBiz.LayoutLocationTable = null;

        }
        public void Edit()
        {
            ((LayoutLocationDb)_LocationDb).LayoutID = _ChildLayoutBiz.ID;
            ((LayoutLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((LayoutLocationDb)_LocationDb).Edit();
            _LayoutBiz.LayoutLocationTable = null;
        }
        public void Delete()
        {
            ((LayoutLocationDb)_LocationDb).Delete();
            _LayoutBiz.LayoutLocationTable = null;

        }
        #endregion
    }
}
