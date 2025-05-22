using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class FacultyInstituteDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _FacultyInstituteIDSearch;
        #endregion
        #region Constructors
        public FacultyInstituteDb()
        {
        }
        public FacultyInstituteDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public FacultyInstituteDb(DataRow objDR)
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
        public int FacultyInstituteIDSearch
        {
            set
            {
                _FacultyInstituteIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONFacultyInstitute.FacultyInstituteID, COMMONFacultyInstitute.FacultyInstituteNameA,COMMONFacultyInstitute.FacultyInstituteNameE,"+
                                   " COMMONFacultyInstitute.FacultyInstituteNameAComp,COMMONFacultyInstitute.FacultyInstituteNameEComp from COMMONFacultyInstitute";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FacultyInstituteID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["FacultyInstituteID"].ToString());
            _NameA = objDR["FacultyInstituteNameA"].ToString();
            _NameE = objDR["FacultyInstituteNameE"].ToString();
            _NameAComp = objDR["FacultyInstituteNameAComp"].ToString();
            _NameEComp = objDR["FacultyInstituteNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONFacultyInstitute (FacultyInstituteNameA,FacultyInstituteNameE,FacultyInstituteNameAComp,FacultyInstituteNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONFacultyInstitute ";
            strSql = strSql + " set FacultyInstituteNameA ='" + _NameA + "'";
            strSql = strSql + ", FacultyInstituteNameE ='" + _NameE + "'";
            strSql = strSql + ", FacultyInstituteNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", FacultyInstituteNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FacultyInstituteID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONFacultyInstitute set Dis = GetDate() where FacultyInstituteID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONFacultyInstitute.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FacultyInstituteID = " + _ID.ToString();
            if (_FacultyInstituteIDSearch != 0)
                strSql = strSql + " and FacultyInstituteID <> " + _FacultyInstituteIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and FacultyInstituteNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and FacultyInstituteNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and FacultyInstituteNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and FacultyInstituteNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by FacultyInstituteID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FacultyInstitute");
        }
        #endregion
    }
}
