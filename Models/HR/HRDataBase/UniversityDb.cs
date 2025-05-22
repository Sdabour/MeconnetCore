using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class UniversityDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        protected int _Country;
        string _NameACompSearch;
        string _NameECompSearch;
        int _UniversityIDSearch;
        int _CountrySearch;
        #endregion
        #region Constructors
        public UniversityDb()
        {
        }
        public UniversityDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public UniversityDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Properties
        public int Country
        {
            set
            {
                _Country = value;
            }
            get
            {
                return _Country;
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
        public int UniversityIDSearch
        {
            set
            {
                _UniversityIDSearch = value;
            }
        }
        public int CountrySearch
        {
            set
            {
                _CountrySearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONUniversity.UniversityID, COMMONUniversity.UniversityNameA,COMMONUniversity.UniversityNameE,"+
                                   " COMMONUniversity.UniversityNameAComp,COMMONUniversity.UniversityNameEComp,"+
                                   " COMMONUniversity.Country,CountryTable.* from COMMONUniversity" +
                                   " Left Outer Join (" + CountryDb.SearchStr + ") as CountryTable ON CountryTable.CountryID = COMMONUniversity.Country ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["UniversityID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["UniversityID"].ToString());
            _NameA = objDR["UniversityNameA"].ToString();
            _NameE = objDR["UniversityNameE"].ToString();
            _NameAComp = objDR["UniversityNameAComp"].ToString();
            _NameEComp = objDR["UniversityNameEComp"].ToString();
            if (objDR["Country"].ToString() != "")
                _Country = int.Parse(objDR["Country"].ToString());
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONUniversity (UniversityNameA,UniversityNameE,UniversityNameAComp,UniversityNameEComp,Country,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + _Country + "," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONUniversity ";
            strSql = strSql + " set UniversityNameA ='" + _NameA + "'";
            strSql = strSql + ", UniversityNameE ='" + _NameE + "'";
            strSql = strSql + ", UniversityNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", UniversityNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ", Country = " + _Country + "";
            strSql = strSql + ", UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ", TimUpd =Getdate() ";
            strSql = strSql + " where UniversityID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONUniversity set Dis = GetDate() where UniversityID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONUniversity.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and UniversityID = " + _ID.ToString();
            if (_UniversityIDSearch != 0)
                strSql = strSql + " and UniversityID <> " + _UniversityIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and UniversityNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and UniversityNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and UniversityNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and UniversityNameEComp like '%" + _NameEComp + "%'  ";

            if (_CountrySearch != 0)
                strSql = strSql + " and Country <> " + _CountrySearch.ToString();

            strSql = strSql + " Order by UniversityID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "University");
        }
        #endregion
    }
}
