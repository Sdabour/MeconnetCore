using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CellLocationDb1 : LocationDb
    {
        #region Private Data
        int _CellID;
        int _SideView;
        string _Desc;
        #endregion
        #region Constructors
        public CellLocationDb1()
        { 
        }
        public CellLocationDb1(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
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
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT LocationID, LocationDesc, LocationImage, LocationX, LocationY, LocationWidth, LocationHeight, LocationCell,LocationSideView " +
                       " FROM  dbo.COMMONImageLocation ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["LocationID"].ToString());
            _Desc = objDr["LocationDesc"].ToString();
            _ImageID = int.Parse(objDr["LocationImage"].ToString());
            _X = int.Parse(objDr["LocationX"].ToString());
            _Y = int.Parse(objDr["LocationY"].ToString());
            _Width = int.Parse(objDr["LocationWidth"].ToString());
            _Height = int.Parse(objDr["LocationHeight"].ToString());
            _SideView = int.Parse(objDr["LocationSideView"].ToString());
            _CellID = int.Parse(objDr["LocationCell"].ToString());
            
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "insert into COMMONImageLocation (LocationDesc, LocationImage, LocationX, LocationY, LocationWidth, LocationHeight, LocationCell, UsrIns, TimIns)"+
                " values ('"+ _Desc +"'," + _ImageID + "," + _X  + "," + _Y + "," + _Width + "," + _Height + "," +_CellID + "," +
                SysData.CurrentUser.ID  +",GetDate())";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            
        }
        public void Edit()
        {
            string strSql = "update COMMONImageLocation  "+
                " set LocationDesc ='" + _Desc + "'"+
                ",LocationX= " + _X +
                ",LocationY=" + _Y+
                ",LocationWidth=" +_Width +
                ",LocationHeight="+ _Height +
                ",UsrUpd=" + SysData.CurrentUser.ID +
                ",TimUpd=GetDate()  where LocationID = " + _ID + " and LocationImage=" + _ImageID ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = "delete from COMMONImageLocation  where LocationImage="+ _ImageID + " and LocationID="+ _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ImageID != 0)
                strSql += " and LocationImage = " + _ImageID;
            if (_CellID != 0)
                strSql += " and LocationCell=" + _CellID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
