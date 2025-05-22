using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class WorkLocationDb
    {

        #region Constructor
        public WorkLocationDb()
        {
        }
        public WorkLocationDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        string _Desc;
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
        string _CenterLong;
        public string CenterLong
        {
            set
            {
                _CenterLong = value;
            }
            get
            {
                return _CenterLong;
            }
        }
        string _CenterLat;
        public string CenterLat
        {
            set
            {
                _CenterLat = value;
            }
            get
            {
                return _CenterLat;
            }
        }
        string _PointLong;
        public string PointLong
        {
            set
            {
                _PointLong = value;
            }
            get
            {
                return _PointLong;
            }
        }
        string _PointLat;
        public string PointLat
        {
            set
            {
                _PointLat = value;
            }
            get
            {
                return _PointLat;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HRWorkLocation (LocationDesc,LocationCenterLong,LocationCenterLat,LocationPointLong,LocationPointLat,UsrIns,TimIns) values ('" + Desc + "','" + CenterLong + "','" + CenterLat + "','" + PointLong + "','" + PointLat + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRWorkLocation set LocationDesc='" + Desc + "'" +
           ",LocationCenterLong='" + CenterLong + "'" +
           ",LocationCenterLat='" + CenterLat + "'" +
           ",LocationPointLong='" + PointLong + "'" +
           ",LocationPointLat='" + PointLat + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where LocationID = "+ ID;
                return Returned;
            }
        }
        public string EditCenterStr
        {
            get
            {
                string Returned = " update HRWorkLocation set LocationCenterLong='" + CenterLong + "'" +
           ",LocationCenterLat='" + CenterLat + "'" +
          ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where LocationID = " + ID;
                return Returned;
            }
        }
        public string EditPointStr
        {
            get
            {
                string Returned = " update HRWorkLocation set LocationPointLong='" + PointLong + "'" +
           ",LocationpointLat='" + PointLat + "'" +
          ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where LocationID = " + ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRWorkLocation set Dis = GetDate() where  LocationID="+ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select LocationID,LocationDesc,LocationCenterLong,LocationCenterLat,LocationPointLong,LocationPointLat from HRWorkLocation  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["LocationID"] != null)
                int.TryParse(objDr["LocationID"].ToString(), out _ID);

            if (objDr.Table.Columns["LocationDesc"] != null)
                _Desc = objDr["LocationDesc"].ToString();

            if (objDr.Table.Columns["LocationCenterLong"] != null)
                _CenterLong = objDr["LocationCenterLong"].ToString();

            if (objDr.Table.Columns["LocationCenterLat"] != null)
                _CenterLat = objDr["LocationCenterLat"].ToString();

            if (objDr.Table.Columns["LocationPointLong"] != null)
                _PointLong = objDr["LocationPointLong"].ToString();

            if (objDr.Table.Columns["LocationPointLat"] != null)
                _PointLat =objDr["LocationPointLat"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditCenter()
        {
            string strSql = EditCenterStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditPoint()
        {
            string strSql = EditPointStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}