using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class TowerLocationDb : LocationDb
    {
        #region Private Data
        int _TowerID;
        int _SideView;
        string _Desc;
        #endregion
        #region Constructors
        public TowerLocationDb()
        {
        }
        public TowerLocationDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int TowerID
        {
            set
            {
                _TowerID = value;
            }
            get
            {
                return _TowerID;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public int SideView
        {
            set
            {
                _SideView = value;
            }
            get
            {
                return _SideView;
            }
        }
        int _UnitOrder;
        public int UnitOrder
        {
            set
            {
                _UnitOrder = value;
            }
            get
            {
                return _UnitOrder;
            }
        }
        int _Tower;
        public int Tower
        {
            set
            {
                _Tower = value;
            }
            get
            {
                return _Tower;
            }
        }

        #region Tower
       
        int _TowerCell;
        public int TowerCell
        {
            set
            {
                _TowerCell = value;
            }
            get
            {
                return _TowerCell;
            }
        }
        int _TowerProject;
        public int TowerProject
        {
            set
            {
                _TowerProject = value;
            }
            get
            {
                return _TowerProject;
            }
        }
        int _TowerOrder;
        public int TowerOrder
        {
            set
            {
                _TowerOrder = value;
            }
            get
            {
                return _TowerOrder;
            }
        }
        string _TowerCode;
        public string TowerCode
        {
            set
            {
                _TowerCode = value;
            }
            get
            {
                return _TowerCode;
            }
        }
        string _TowerNmame;
        public string TowerNmame
        {
            set
            {
                _TowerNmame = value;
            }
            get
            {
                return _TowerNmame;
            }
        }
        int _ProjectCell;
        public int ProjectCell
        {
            set
            {
                _ProjectCell = value;
            }
            get
            {
                return _ProjectCell;
            }
        }
        string _ProjectCode;
        public string ProjectCode
        {
            set
            {
                _ProjectCode = value;
            }
            get
            {
                return _ProjectCode;
            }
        }
        string _ProjectNameA;
        public string ProjectNameA
        {
            set
            {
                _ProjectNameA = value;
            }
            get
            {
                return _ProjectNameA;
            }
        }
        string _ProjectNameE;
        public string ProjectNameE
        {
            set
            {
                _ProjectNameE = value;
            }
            get
            {
                return _ProjectNameE;
            }
        }
        #endregion
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMTowerImageLocation (LocationDesc,LocationImage,LocationX,LocationY,LocationWidth,LocationHeight,LocationTower,LocationSideView,LocationUnitOrder,UsrIns,TimIns) values ('" + Desc + "'," + ImageID +
                    "," + X + "," + Y + "," + Width + "," + Height + "," + Tower + "," + SideView + "," + UnitOrder + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMTowerImageLocation set " + "LocationID=" + ID + "" +
           ",LocationDesc='" + Desc + "'" +
           ",LocationImage=" + ImageID + "" +
           ",LocationX=" + X + "" +
           ",LocationY=" + Y + "" +
           ",LocationWidth=" + Width + "" +
           ",LocationHeight=" + Height + "" +
           ",LocationTower=" + Tower + "" +
           ",LocationSideView=" + SideView + "" +
           ",LocationUnitOrder=" + UnitOrder + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate() "+
           " where LocationID = " + _ID + " and LocationImage=" + _ImageID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from CRMTowerImageLocation  "+
                    " where LocationID = " + _ID + " and LocationImage=" + _ImageID;
                return Returned;
            }
        }
        public string SearchStr1
        {
            get
            {
                string Returned = " select LocationID,LocationDesc,LocationImage,LocationX,LocationY,LocationWidth,LocationHeight,LocationTower,LocationSideView,LocationUnitOrder from CRMTowerImageLocation  ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strTower = @"SELECT        dbo.CRMTower.TowerID AS LocationTowerID, dbo.CRMTower.TowerCell AS LocationTowerCell, dbo.CRMTower.TowerProject AS LocationTowerProject, dbo.CRMTower.TowerOrder AS LocationTowerOrder, 
                                                    dbo.CRMTower.TowerCode AS LocationTowerCode, dbo.CRMTower.TowerName AS LocationTowerNmae, dbo.CRMProject.ProjectCell AS LocationProjectCell, dbo.CRMProject.ProjectCode AS LocationProjectCode, 
                                                    dbo.CRMProject.ProjectNameA AS LocationProjectNameA, dbo.CRMProject.ProjectNameE AS LocationProjectNameE
                           FROM            dbo.CRMTower INNER JOIN
                                                    dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID";
                string Returned = "SELECT LocationID, LocationDesc, LocationImage, LocationX, LocationY, LocationWidth, LocationHeight, LocationTower,LocationSideView,LocationUnitOrder " +
                    ",LocationTowerTable.* "+
                       " FROM  dbo.CRMTowerImageLocation "+
                       " left outer join ("+ strTower +") AS LocationTowerTable "+
                       " ON LocationTowerTable.LocationTowerID = dbo.CRMTowerImageLocation.LocationTower";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["LocationID"] != null)
                int.TryParse(objDr["LocationID"].ToString(), out _ID);

            if (objDr.Table.Columns["LocationDesc"] != null)
                _Desc = objDr["LocationDesc"].ToString();

            if (objDr.Table.Columns["LocationImage"] != null)
                int.TryParse(objDr["LocationImage"].ToString(), out _ImageID);

            if (objDr.Table.Columns["LocationX"] != null)
                int.TryParse(objDr["LocationX"].ToString(), out _X);

            if (objDr.Table.Columns["LocationY"] != null)
                int.TryParse(objDr["LocationY"].ToString(), out _Y);

            if (objDr.Table.Columns["LocationWidth"] != null)
                int.TryParse(objDr["LocationWidth"].ToString(), out _Width);

            if (objDr.Table.Columns["LocationHeight"] != null)
                int.TryParse(objDr["LocationHeight"].ToString(), out _Height);

            if (objDr.Table.Columns["LocationTower"] != null)
                int.TryParse(objDr["LocationTower"].ToString(), out _Tower);

            if (objDr.Table.Columns["LocationSideView"] != null)
                int.TryParse(objDr["LocationSideView"].ToString(), out _SideView);

            if (objDr.Table.Columns["LocationUnitOrder"] != null)
                int.TryParse(objDr["LocationUnitOrder"].ToString(), out _UnitOrder);

            #region Tower
            if (objDr.Table.Columns["LocationTowerID"] != null)
                int.TryParse(objDr["LocationTowerID"].ToString(), out _TowerID);

            if (objDr.Table.Columns["LocationTowerCell"] != null)
                int.TryParse(objDr["LocationTowerCell"].ToString(), out _TowerCell);

            if (objDr.Table.Columns["LocationTowerProject"] != null)
                int.TryParse(objDr["LocationTowerProject"].ToString(), out _TowerProject);

            if (objDr.Table.Columns["LocationTowerOrder"] != null)
                int.TryParse(objDr["LocationTowerOrder"].ToString(), out _TowerOrder);

            if (objDr.Table.Columns["LocationTowerCode"] != null)
                _TowerCode = objDr["LocationTowerCode"].ToString();

            if (objDr.Table.Columns["LocationTowerNmame"] != null)
                _TowerNmame = objDr["LocationTowerNmame"].ToString();

            if (objDr.Table.Columns["LocationProjectCell"] != null)
                int.TryParse(objDr["LocationProjectCell"].ToString(), out _ProjectCell);

            if (objDr.Table.Columns["LocationProjectCode"] != null)
                _ProjectCode = objDr["LocationProjectCode"].ToString();

            if (objDr.Table.Columns["LocationProjectNameA"] != null)
                _ProjectNameA = objDr["LocationProjectNameA"].ToString();

            if (objDr.Table.Columns["LocationProjectNameE"] != null)
                _ProjectNameE = objDr["LocationProjectNameE"].ToString();
            #endregion
        }
        void SetData1(DataRow objDr)
        {
            _ID = int.Parse(objDr["LocationID"].ToString());
            _Desc = objDr["LocationDesc"].ToString();
            _ImageID = int.Parse(objDr["LocationImage"].ToString());
            _X = int.Parse(objDr["LocationX"].ToString());
            _Y = int.Parse(objDr["LocationY"].ToString());
            _Width = int.Parse(objDr["LocationWidth"].ToString());
            _Height = int.Parse(objDr["LocationHeight"].ToString());
            _SideView = int.Parse(objDr["LocationSideView"].ToString());
            _TowerID = int.Parse(objDr["LocationTower"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ImageID != 0)
                strSql += " and LocationImage = " + _ImageID;
            if (_TowerID != 0)
                strSql += " and LocationTower=" + _TowerID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
