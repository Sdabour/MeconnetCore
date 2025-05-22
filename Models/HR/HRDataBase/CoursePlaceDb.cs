using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class CoursePlaceDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _CoursePlaceIDSearch;
        #endregion
        #region Constructors
        public CoursePlaceDb()
        {
        }
        public CoursePlaceDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public CoursePlaceDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public string NameAComp
        {
            set
            {
                _NameAComp = value;
            }
            get
            {
                return _NameAComp;
            }
        }
        public string NameACompSearch
        {
            set
            {
                _NameACompSearch = value;
            }
        }
        public string NameEComp
        {
            set
            {
                _NameEComp = value;
            }
            get
            {
                return _NameEComp;
            }
        }
        public string NameECompSearch
        {
            set
            {
                _NameECompSearch = value;
            }
        }
        public int CoursePlaceIDSearch
        {
            set
            {
                _CoursePlaceIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONCoursePlace.CoursePlaceID, COMMONCoursePlace.CoursePlaceNameA,COMMONCoursePlace.CoursePlaceNameE," +
                                   " COMMONCoursePlace.CoursePlaceNameAComp,COMMONCoursePlace.CoursePlaceNameEComp from COMMONCoursePlace";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["CoursePlaceID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["CoursePlaceID"].ToString());
            _NameA = objDR["CoursePlaceNameA"].ToString();
            _NameE = objDR["CoursePlaceNameE"].ToString();
            _NameAComp = objDR["CoursePlaceNameAComp"].ToString();
            _NameEComp = objDR["CoursePlaceNameEComp"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONCoursePlace (CoursePlaceNameA,CoursePlaceNameE,CoursePlaceNameAComp,CoursePlaceNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONCoursePlace ";
            strSql = strSql + " set CoursePlaceNameA ='" + _NameA + "'";
            strSql = strSql + ", CoursePlaceNameE ='" + _NameE + "'";
            strSql = strSql + ", CoursePlaceNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", CoursePlaceNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where CoursePlaceID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONCoursePlace set Dis = GetDate() where CoursePlaceID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONCoursePlace.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and CoursePlaceID = " + _ID.ToString();
            if (_CoursePlaceIDSearch != 0)
                strSql = strSql + " and CoursePlaceID <> " + _CoursePlaceIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and CoursePlaceNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and CoursePlaceNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and CoursePlaceNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and CoursePlaceNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by CoursePlaceID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "CoursePlace");
        }
        #endregion
    }
}
