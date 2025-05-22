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
    public class TowerLocationBiz : LocationBiz
    {
        #region Private Data
        TowerBiz _TowerBiz;
        LayoutBiz _LayoutBiz;
        LayoutBiz _SideViewBiz;
        #endregion
        #region Constructors
        public TowerLocationBiz()
        {
            _LocationDb = new TowerLocationDb();
            _TowerBiz = new TowerBiz();

        }
        public TowerLocationBiz(DataRow objDr)
        {
            _LocationDb = new TowerLocationDb(objDr);
            _TowerBiz = new TowerBiz();
            _TowerBiz.ID = ((TowerLocationDb)_LocationDb).TowerID;
            _TowerBiz.Code = ((TowerLocationDb)_LocationDb).TowerCode;
            _TowerBiz.Name = ((TowerLocationDb)_LocationDb).TowerNmame;
            _TowerBiz.Order = ((TowerLocationDb)_LocationDb).TowerOrder;
            _TowerBiz.ProjectBiz = new ProjectBiz();
            _TowerBiz.ProjectBiz.ID = ((TowerLocationDb)_LocationDb).TowerProject;
            _TowerBiz.ProjectBiz.NameA = ((TowerLocationDb)_LocationDb).ProjectNameA;
            _TowerBiz.ProjectBiz.NameE = ((TowerLocationDb)_LocationDb).ProjectNameE;
            _TowerBiz.ProjectBiz.Code = ((TowerLocationDb)_LocationDb).ProjectCode;


        }
        #endregion
        #region Public Properties
        public TowerBiz TowerBiz
        {
            set
            {
                _TowerBiz = value;
            }
            get
            {
                if (_TowerBiz == null)
                    _TowerBiz = new TowerBiz();
                return _TowerBiz;
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
                ((TowerLocationDb)_LocationDb).Desc = value;
            }
            get
            {
                return ((TowerLocationDb)_LocationDb).Desc;
            }
        }
        public int UnitOrder
        {
            set
            {
                ((TowerLocationDb)_LocationDb).UnitOrder = value;
            }
            get
            {
                return ((TowerLocationDb)_LocationDb).UnitOrder;
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
                    _SideViewBiz = new LayoutBiz(((TowerLocationDb)_LocationDb).SideView);
                return _SideViewBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((TowerLocationDb)_LocationDb).TowerID = _TowerBiz.ID;
            ((TowerLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((TowerLocationDb)_LocationDb).Add();
           // _LayoutBiz.TowerLocationTable = null;

        }
        public void Edit()
        {
            ((TowerLocationDb)_LocationDb).TowerID = _TowerBiz.ID;
            ((TowerLocationDb)_LocationDb).ImageID = _LayoutBiz.ID;
            ((TowerLocationDb)_LocationDb).Edit();
          //  _LayoutBiz.TowerLocationTable = null;
        }
        public void Delete()
        {
            ((TowerLocationDb)_LocationDb).Delete();
           // _LayoutBiz.TowerLocationTable = null;

        }
        #endregion
    }
}
