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
    public class CellLocationBiz : LocationBiz
    {
        #region Private Data
        CellBiz _CellBiz;
       LayoutBiz _LayoutBiz;
        LayoutBiz _SideViewBiz;
        #endregion
        #region Constructors
        public CellLocationBiz()
        {
            _LocationDb = new CellLocationDb();
            _CellBiz = new CellBiz();
 
        }
        public CellLocationBiz(DataRow objDr)
        {
            _LocationDb = new CellLocationDb(objDr);
            _CellBiz = new CellBiz(((CellLocationDb)_LocationDb).CellID);
        }
        #endregion
        #region Public Properties
        public CellBiz CellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                return _CellBiz;
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
                ((CellLocationDb)_LocationDb).Desc = value;
            }
            get
            {
                return ((CellLocationDb)_LocationDb).Desc;
            }
        }
        public LayoutBiz SideViewBiz
        {
            set 
            {
                _SideViewBiz = value;
            }
            get
            {
                if (_SideViewBiz == null)
                    _SideViewBiz = new LayoutBiz(((CellLocationDb)_LocationDb).SideView);
                return _SideViewBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((CellLocationDb)_LocationDb).CellID = _CellBiz.ID;
            ((CellLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((CellLocationDb)_LocationDb).Add();
            _LayoutBiz.CellLocationTable = null;
 
        }
        public void Edit()
        {
            ((CellLocationDb)_LocationDb).CellID = _CellBiz.ID;
            ((CellLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((CellLocationDb)_LocationDb).Edit();
            _LayoutBiz.CellLocationTable = null;
        }
        public void Delete()
        {
            ((CellLocationDb)_LocationDb).Delete();
            _LayoutBiz.CellLocationTable = null;
 
        }
        #endregion
    }
}
