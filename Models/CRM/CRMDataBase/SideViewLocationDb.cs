using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class SideViewLocationDb : LocationDb
    {
        #region Private Data
        int _Order;
        string _Desc;

        #endregion
        #region Constructors
        public SideViewLocationDb()
        {
        }
        public SideViewLocationDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
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

        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT LocationID, LocationDesc, LocationImage, LocationX, LocationY, LocationWidth, LocationHeight, LocationOrder " +
                       " FROM  dbo.CRMSideViewLocation ";

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
            _Order = int.Parse(objDr["LocationOrder"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "insert into CRMSideViewLocation (LocationDesc, LocationImage, LocationX, LocationY, LocationWidth, LocationHeight, LocationOrder, UsrIns, TimIns)" +
                " values ('" + _Desc + "'," + _ImageID + "," + _X + "," + _Y + "," + _Width + "," + _Height + "," + _Order + "," +
                SysData.CurrentUser.ID + ",GetDate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public void Edit()
        {
            string strSql = "update CRMSideViewLocation  " +
                " set LocationDesc ='" + _Desc + "'" +
                ",LocationX= " + _X +
                ",LocationY=" + _Y +
                ",LocationWidth=" + _Width +
                ",LocationHeight=" + _Height +
                ",UsrUpd=" + SysData.CurrentUser.ID +
                ",TimUpd=GetDate()  where LocationID = " + _ID + " and LocationImage=" + _ImageID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = "delete from CRMSideViewLocation  where LocationImage=" + _ImageID + " and LocationID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ImageID != 0)
                strSql += " and LocationImage = " + _ImageID;
            if (_Order != 0)
                strSql += " and LocationOrder=" + _Order;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
