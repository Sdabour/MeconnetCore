using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class GradeDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _GradeIDSearch;

        protected bool _GradeStatus;
        protected bool _DegreeStatus;
        bool _GradeStatusSearch;
        bool _DegreeStatusSearch;
        #endregion
        #region Constructors
        public GradeDb()
        {
        }
        public GradeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public GradeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public bool GradeStatus
        {
            set
            {
                _GradeStatus = value;
            }
            get
            {
                return _GradeStatus;
            }
        }
        public bool DegreeStatus
        {
            set
            {
                _DegreeStatus = value;
            }
            get
            {
                return _DegreeStatus;
            }
        }
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
        public int GradeIDSearch
        {
            set
            {
                _GradeIDSearch = value;
            }
        }
        public bool GradeStatusSearch
        {
            set
            {
                _GradeStatusSearch = value;
            }
        }
        public bool DegreeStatusSearch
        {
            set
            {
                _DegreeStatusSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONGrade.GradeID, COMMONGrade.GradeNameA,COMMONGrade.GradeNameE," +
                                   " COMMONGrade.GradeNameAComp,COMMONGrade.GradeNameEComp,COMMONGrade.GradeStatus,COMMONGrade.DegreeStatus from COMMONGrade";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["GradeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["GradeID"].ToString());
            _NameA = objDR["GradeNameA"].ToString();
            _NameE = objDR["GradeNameE"].ToString();
            _NameAComp = objDR["GradeNameAComp"].ToString();
            _NameEComp = objDR["GradeNameEComp"].ToString();
            _GradeStatus = bool.Parse(objDR["GradeStatus"].ToString());
            _DegreeStatus = bool.Parse(objDR["DegreeStatus"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intGradeStatus = _GradeStatus ? 1 : 0;
            int intDegreeStatus = _DegreeStatus ? 1 : 0;
            string strSql = "insert into COMMONGrade (GradeNameA,GradeNameE,GradeNameAComp,GradeNameEComp,GradeStatus,DegreeStatus,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + intGradeStatus + "," + intDegreeStatus + "," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            int intGradeStatus = _GradeStatus ? 1 : 0;
            int intDegreeStatus = _DegreeStatus ? 1 : 0;

            string strSql = "update  COMMONGrade ";
            strSql = strSql + " set GradeNameA ='" + _NameA + "'";
            strSql = strSql + ", GradeNameE ='" + _NameE + "'";
            strSql = strSql + ", GradeNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", GradeNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ", GradeStatus =" + intGradeStatus + "";
            strSql = strSql + ", DegreeStatus =" + intDegreeStatus + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where GradeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONGrade set Dis = GetDate() where GradeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONGrade.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and GradeID = " + _ID.ToString();
            if (_GradeIDSearch != 0)
                strSql = strSql + " and GradeID <> " + _GradeIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and GradeNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and GradeNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and GradeNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and GradeNameEComp like '%" + _NameEComp + "%'  ";

            if (_GradeStatusSearch == true)
            {
                strSql = strSql + " and GradeStatus =1 ";
            }

            if (_DegreeStatusSearch == true)
            {
                strSql = strSql + " and DegreeStatus =1 ";
            }
            strSql = strSql + " Order by GradeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Grade");
        }
        #endregion
    }
}
