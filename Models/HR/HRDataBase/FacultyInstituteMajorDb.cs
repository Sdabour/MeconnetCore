using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class FacultyInstituteMajorDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _FacultyInstituteMajorIDSearch;
        #endregion
        #region Constructors
        public FacultyInstituteMajorDb()
        {
        }
        public FacultyInstituteMajorDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public FacultyInstituteMajorDb(DataRow objDR)
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
        public int FacultyInstituteMajorIDSearch
        {
            set
            {
                _FacultyInstituteMajorIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONFacultyInstituteMajor.FacultyInstituteMajorID, COMMONFacultyInstituteMajor.FacultyInstituteMajorNameA,COMMONFacultyInstituteMajor.FacultyInstituteMajorNameE,"+
                                   " COMMONFacultyInstituteMajor.FacultyInstituteMajorNameAComp,COMMONFacultyInstituteMajor.FacultyInstituteMajorNameEComp from COMMONFacultyInstituteMajor";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FacultyInstituteMajorID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["FacultyInstituteMajorID"].ToString());
            _NameA = objDR["FacultyInstituteMajorNameA"].ToString();
            _NameE = objDR["FacultyInstituteMajorNameE"].ToString();
            _NameAComp = objDR["FacultyInstituteMajorNameAComp"].ToString();
            _NameEComp = objDR["FacultyInstituteMajorNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONFacultyInstituteMajor (FacultyInstituteMajorNameA,FacultyInstituteMajorNameE,FacultyInstituteMajorNameAComp,FacultyInstituteMajorNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONFacultyInstituteMajor ";
            strSql = strSql + " set FacultyInstituteMajorNameA ='" + _NameA + "'";
            strSql = strSql + ", FacultyInstituteMajorNameE ='" + _NameE + "'";
            strSql = strSql + ", FacultyInstituteMajorNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", FacultyInstituteMajorNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FacultyInstituteMajorID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONFacultyInstituteMajor set Dis = GetDate() where FacultyInstituteMajorID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONFacultyInstituteMajor.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FacultyInstituteMajorID = " + _ID.ToString();
            if (_FacultyInstituteMajorIDSearch != 0)
                strSql = strSql + " and FacultyInstituteMajorID <> " + _FacultyInstituteMajorIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and FacultyInstituteMajorNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and FacultyInstituteMajorNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and FacultyInstituteMajorNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and FacultyInstituteMajorNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by FacultyInstituteMajorID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FacultyInstituteMajor");
        }
        #endregion
    }
}
