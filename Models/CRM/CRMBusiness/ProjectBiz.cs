using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ProjectBiz : BaseSingleBiz
    {
        #region Private Data
        CityBiz _CityBiz;
        TowerCol _TowerCol;
        LayoutBiz _Layout;
        ImageBiz _Logo;
        public TowerCol TowerCol
        {
            get
            {
                if (_TowerCol == null)
                {
                    _TowerCol = new TowerCol(true);
                    TowerBiz objBiz;
                    DataTable dtTemp;
                    if (ID != 0)
                    {
                        TowerDb objDb = new TowerDb();
                        objDb.Project = ID;
                        dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new TowerBiz(objDr);
                            objBiz.ProjectBiz = this;
                            _TowerCol.Add(objBiz);
                        }

                    }
                }
                return _TowerCol;
            }
            set {
                _TowerCol = value; }
        }
        #endregion

        #region Constractors
        public ProjectBiz()
        {
            _BaseDb = new ProjectDb();
        }
        public ProjectBiz(int intID)
        {
            _BaseDb = new ProjectDb(intID);
        }
        public ProjectBiz(DataRow objDR)
        {
            _BaseDb = new ProjectDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public DateTime ReservationStartDate
        {
            set
            {
                ((ProjectDb)_BaseDb).ReservationStartDate = value;
            }
            get
            {
                return ((ProjectDb)_BaseDb).ReservationStartDate;
            }
        }
        public DateTime ReservationStopDate
        {
            set
            {
                ((ProjectDb)_BaseDb).ReservationStopDate = value;
            }
            get
            {
                return ((ProjectDb)_BaseDb).ReservationStopDate;
            }
        }
        public DateTime ContractingStartDate
        {
            set
            {
                ((ProjectDb)_BaseDb).ContractingStartDate = value;
            }
            get
            {
                return ((ProjectDb)_BaseDb).ContractingStartDate;
            }
        }

        public ImageBiz Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                if (_Logo == null && ((ProjectDb)_BaseDb).Logo != 0)
                {
                    _Logo = new ImageBiz(((ProjectDb)_BaseDb).Logo);
                }
                return _Logo;
            }
        }

        public LayoutBiz Layout
        {
            set
            {
                _Layout = value;
            }
            get
            {
                if (_Layout == null )
                {
                    if (((ProjectDb)_BaseDb).Layout != 0)
                        _Layout = new LayoutBiz(((ProjectDb)_BaseDb).Layout);
                    else
                        _Layout = new LayoutBiz();
                }
                return _Layout;
            }
        }
        public string Desc
        {
            get { return ((ProjectDb)_BaseDb).Desc; }
            set { ((ProjectDb)_BaseDb).Desc = value; }
        }
        public int CellID
        {
            get { return ((ProjectDb)_BaseDb).CellID; }
            set { ((ProjectDb)_BaseDb).CellID = value; }
        }
        CellBiz _CellBiz;

        public CellBiz CellBiz
        {
            get
            {
                if (_CellBiz == null)
                    _CellBiz = new CellBiz();
                return _CellBiz;
            }
            set { _CellBiz = value; }
        }


        public string PostalCode
        {
            get { return ((ProjectDb)_BaseDb).PostalCode; }
            set { ((ProjectDb)_BaseDb).PostalCode = value; }
        }



        public CityBiz CityBiz
        {
            set
            {
                _CityBiz = value;
            }
            get
            {
                if (_CityBiz == null)
                    _CityBiz = new CityBiz();
                return _CityBiz;
            }
        }

        public string License
        {
            get { return ((ProjectDb)_BaseDb).License; }
            set { ((ProjectDb)_BaseDb).License = value; }
        }


        public string ProfitCenter
        {
            get { return ((ProjectDb)_BaseDb).ProfitCenter; }
            set { ((ProjectDb)_BaseDb).ProfitCenter = value; }
        }


        public string WBS
        {
            get { return ((ProjectDb)_BaseDb).WBS; }
            set { ((ProjectDb)_BaseDb).WBS = value; }
        }

        public bool StartDateDecided
        {
            get { return ((ProjectDb)_BaseDb).StartDateDecided; }
            set { ((ProjectDb)_BaseDb).StartDateDecided = value; }
        }

        public bool StopDateDecided
        {
            get { return ((ProjectDb)_BaseDb).StopDateDecided; }
            set { ((ProjectDb)_BaseDb).StopDateDecided = value; }
        }


        public bool ContractingStartDateDecided
        {
            get { return ((ProjectDb)_BaseDb).ContractingStartDateDecided; }
            set { ((ProjectDb)_BaseDb).ContractingStartDateDecided = value; }
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((ProjectDb)_BaseDb).CellID = CellBiz.ID;
            ((ProjectDb)_BaseDb).City = CityBiz.ID;
            ((ProjectDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((ProjectDb)_BaseDb).CellID = CellBiz.ID;
            ((ProjectDb)_BaseDb).City = CityBiz.ID;
            ((ProjectDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((ProjectDb)_BaseDb).Delete();
        }
        public void EditLayout()
        {
            ((ProjectDb)_BaseDb).Layout = Layout.ID;
            ((ProjectDb)_BaseDb).EditLayOut();

        }
        #endregion
    }
}
