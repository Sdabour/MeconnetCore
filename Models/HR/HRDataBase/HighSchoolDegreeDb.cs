using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class HighSchoolDegreeDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _HighSchoolDegreeIDSearch;
        #endregion
        #region Constructors
        public HighSchoolDegreeDb()
        {
        }
        public HighSchoolDegreeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public HighSchoolDegreeDb(DataRow objDR)
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
        public int HighSchoolDegreeIDSearch
        {
            set
            {
                _HighSchoolDegreeIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONHighSchoolDegree.HighSchoolDegreeID, COMMONHighSchoolDegree.HighSchoolDegreeNameA,COMMONHighSchoolDegree.HighSchoolDegreeNameE,"+
                                   " COMMONHighSchoolDegree.HighSchoolDegreeNameAComp,COMMONHighSchoolDegree.HighSchoolDegreeNameEComp from COMMONHighSchoolDegree";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["HighSchoolDegreeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["HighSchoolDegreeID"].ToString());
            _NameA = objDR["HighSchoolDegreeNameA"].ToString();
            _NameE = objDR["HighSchoolDegreeNameE"].ToString();
            _NameAComp = objDR["HighSchoolDegreeNameAComp"].ToString();
            _NameEComp = objDR["HighSchoolDegreeNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONHighSchoolDegree (HighSchoolDegreeNameA,HighSchoolDegreeNameE,HighSchoolDegreeNameAComp,HighSchoolDegreeNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONHighSchoolDegree ";
            strSql = strSql + " set HighSchoolDegreeNameA ='" + _NameA + "'";
            strSql = strSql + ", HighSchoolDegreeNameE ='" + _NameE + "'";
            strSql = strSql + ", HighSchoolDegreeNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", HighSchoolDegreeNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where HighSchoolDegreeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONHighSchoolDegree set Dis = GetDate() where HighSchoolDegreeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONHighSchoolDegree.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and HighSchoolDegreeID = " + _ID.ToString();
            if (_HighSchoolDegreeIDSearch != 0)
                strSql = strSql + " and HighSchoolDegreeID <> " + _HighSchoolDegreeIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and HighSchoolDegreeNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and HighSchoolDegreeNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and HighSchoolDegreeNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and HighSchoolDegreeNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by HighSchoolDegreeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HighSchoolDegree");
        }
        #endregion
    }
}
