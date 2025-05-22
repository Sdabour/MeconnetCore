using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ProjectImageDb
    {
        #region Private Data
        protected int _ID;
        protected string _Desc;
        protected int _Order;
        protected int _ProjectID;
        #endregion

        #region Constractors
        public ProjectImageDb()
        { 

        }
        public ProjectImageDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ProjectImageDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
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
        public int ProjectID
        {
            set
            {
                _ProjectID = value;
            }
            get
            {
                return _ProjectID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ProjectID, ImageID, ImageOrder, ImageDesc"+
                                  " FROM         CRMProjectImage ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["ImageID"].ToString());
            _Desc = objDR["ImageDesc"].ToString();
            _Order = int.Parse(objDR["ImageOrder"].ToString());
            _ProjectID = int.Parse(objDR["ProjectID"].ToString());
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO CRMProjectImage"+
                            " (ProjectID, ImageID, ImageOrder, ImageDesc)"+
                            " VALUES     ("+_ProjectID+","+_ID+","+_Order+",'"+_Desc+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    CRMProjectImage" +
                            " SET  ProjectID ="+_ProjectID+"" +
                            " , ImageID ="+_ID+"" +
                            " , ImageOrder ="+_Order+"" +
                            " , ImageDesc = '"+_Desc+"'" +
                            " where ImageID = " + _ID + " and ProjectID = " + _ProjectID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        { 

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
