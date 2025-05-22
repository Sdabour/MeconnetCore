using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class LayoutDb : ImageDb
    {
        #region Private Data
        byte _Type;// 1 Plan ,2 Sideview 3 Elevation
        int _Project;
        int _Logo;
        bool _OldLayout;
        static string _LayoutIDs;
        static DataTable _CachLayoutTable;
        #endregion
        #region Constructors
        public LayoutDb()
            : base()
        {
        }
        public LayoutDb(DataRow objDr)
            : base(objDr)
        {

            SetData(objDr);
        }
        public LayoutDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                base.SetData(dtTemp.Rows[0]);
                SetData(dtTemp.Rows[0]);
            }

        }
        #endregion
        #region Public Properties
        public int ProjectID
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }

        }
        public byte Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        public int Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                return _Logo;
            }
        }
        public bool OldLayout
        {
            get
            {
                return _OldLayout;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     dbo.CRMProjectLayout.LayoutImage,CRMProjectLayout.LayoutType " +
                    ",dbo.CRMProjectLayout.LayoutProject, dbo.CRMProjectLayout.LayoutLogo " +
                    ",ImageTable.* " +
                         " FROM  dbo.CRMProjectLayout inner join (" + ImageDb.SearchStr + ") as " +
                         " ImageTable on CRMProjectLayout.LayoutImage=ImageTable.ImageID ";
                return Returned;
            }
        }
        public static DataTable CachLayoutTable
        {
            set
            {
                _CachLayoutTable = value;
            }
            get
            {
                if (_CachLayoutTable == null && _LayoutIDs != null && _LayoutIDs != "")
                {

                }
                return _CachLayoutTable;
            }
        }
        #endregion
        #region Private Methods
        public void SetData(DataRow objDr)
        {
            _Project = int.Parse(objDr["LayoutProject"].ToString());
            _Type = byte.Parse(objDr["LayoutType"].ToString());
            _Logo = int.Parse(objDr["LayoutLogo"].ToString());
            _OldLayout = true;
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = "insert into CRMProjectLayout" +
                " (LayoutImage,LayoutType, LayoutProject, LayoutLogo) values (" + _ID + "," + _Type + "," + _Project +
                "," + _Logo + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            string strSql = "update CRMProjectLayout set LayoutType=" + _Type +
                ",LayoutLogo=" + _Logo +
                " where LayoutImage=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMProjectLayout where LayoutImage=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            DataTable Returned;
            string strSql = SearchStr + " where (1=1) ";
            if (_ID != 0)
                strSql += " and LayoutImage = " + _ID;
            if (_Project != 0)
                strSql += " and LayoutProject = " + _Project;
            if (_Type != 0)
                strSql += " and LayoutType = " + _Type;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
