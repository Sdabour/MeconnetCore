using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class HighestUniversityDegreeDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _HighestUniversityDegreeIDSearch;
        #endregion
        #region Constructors
        public HighestUniversityDegreeDb()
        {
        }
        public HighestUniversityDegreeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public HighestUniversityDegreeDb(DataRow objDR)
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
        public int HighestUniversityDegreeIDSearch
        {
            set
            {
                _HighestUniversityDegreeIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONHighestUniversityDegree.HighestUniversityDegreeID, COMMONHighestUniversityDegree.HighestUniversityDegreeNameA,COMMONHighestUniversityDegree.HighestUniversityDegreeNameE,"+
                                   " COMMONHighestUniversityDegree.HighestUniversityDegreeNameAComp,COMMONHighestUniversityDegree.HighestUniversityDegreeNameEComp from COMMONHighestUniversityDegree";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["HighestUniversityDegreeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["HighestUniversityDegreeID"].ToString());
            _NameA = objDR["HighestUniversityDegreeNameA"].ToString();
            _NameE = objDR["HighestUniversityDegreeNameE"].ToString();
            _NameAComp = objDR["HighestUniversityDegreeNameAComp"].ToString();
            _NameEComp = objDR["HighestUniversityDegreeNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONHighestUniversityDegree (HighestUniversityDegreeNameA,HighestUniversityDegreeNameE,HighestUniversityDegreeNameAComp,HighestUniversityDegreeNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONHighestUniversityDegree ";
            strSql = strSql + " set HighestUniversityDegreeNameA ='" + _NameA + "'";
            strSql = strSql + ", HighestUniversityDegreeNameE ='" + _NameE + "'";
            strSql = strSql + ", HighestUniversityDegreeNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", HighestUniversityDegreeNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where HighestUniversityDegreeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONHighestUniversityDegree set Dis = GetDate() where HighestUniversityDegreeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONHighestUniversityDegree.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and HighestUniversityDegreeID = " + _ID.ToString();
            if (_HighestUniversityDegreeIDSearch != 0)
                strSql = strSql + " and HighestUniversityDegreeID <> " + _HighestUniversityDegreeIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and HighestUniversityDegreeNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and HighestUniversityDegreeNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and HighestUniversityDegreeNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and HighestUniversityDegreeNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by HighestUniversityDegreeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HighestUniversityDegree");
        }
        #endregion
    }
}
