using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class FirstUniversityDegreeDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _FirstUniversityDegreeIDSearch;
        #endregion
        #region Constructors
        public FirstUniversityDegreeDb()
        {
        }
        public FirstUniversityDegreeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public FirstUniversityDegreeDb(DataRow objDR)
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
        public int FirstUniversityDegreeIDSearch
        {
            set
            {
                _FirstUniversityDegreeIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONFirstUniversityDegree.FirstUniversityDegreeID, COMMONFirstUniversityDegree.FirstUniversityDegreeNameA,COMMONFirstUniversityDegree.FirstUniversityDegreeNameE,"+
                                   " COMMONFirstUniversityDegree.FirstUniversityDegreeNameAComp,COMMONFirstUniversityDegree.FirstUniversityDegreeNameEComp from COMMONFirstUniversityDegree";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FirstUniversityDegreeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["FirstUniversityDegreeID"].ToString());
            _NameA = objDR["FirstUniversityDegreeNameA"].ToString();
            _NameE = objDR["FirstUniversityDegreeNameE"].ToString();
            _NameAComp = objDR["FirstUniversityDegreeNameAComp"].ToString();
            _NameEComp = objDR["FirstUniversityDegreeNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONFirstUniversityDegree (FirstUniversityDegreeNameA,FirstUniversityDegreeNameE,FirstUniversityDegreeNameAComp,FirstUniversityDegreeNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONFirstUniversityDegree ";
            strSql = strSql + " set FirstUniversityDegreeNameA ='" + _NameA + "'";
            strSql = strSql + ", FirstUniversityDegreeNameE ='" + _NameE + "'";
            strSql = strSql + ", FirstUniversityDegreeNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", FirstUniversityDegreeNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FirstUniversityDegreeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONFirstUniversityDegree set Dis = GetDate() where FirstUniversityDegreeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONFirstUniversityDegree.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FirstUniversityDegreeID = " + _ID.ToString();
            if (_FirstUniversityDegreeIDSearch != 0)
                strSql = strSql + " and FirstUniversityDegreeID <> " + _FirstUniversityDegreeIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and FirstUniversityDegreeNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and FirstUniversityDegreeNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and FirstUniversityDegreeNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and FirstUniversityDegreeNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by FirstUniversityDegreeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FirstUniversityDegree");
        }
        #endregion
    }
}
