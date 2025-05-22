using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class CityDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected int _Country;
        int _CityIDSearch;
        int _CountrySearch;
        string _NameACompSearch;
        #endregion

        #region Constructors
        public CityDb()
        {


        }
        public CityDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
             if (dtTemp.Rows.Count != 0)
                 SetData(dtTemp.Rows[0]);
        }

        //public CityDb(int intCountryID)
        //{ 
        //    _CountrySearch = intCountryID
        //}
        
        public CityDb(DataRow objDR)
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
        public int CityIDSearch
        {
            set
            {
                _CityIDSearch = value;
            }            
        }
        public int CountrySearch
        {
            set
            {
                _CountrySearch = value;
            }
        }
        public string NameACompSearch
        {
            set
            {
                _NameACompSearch = value;
            }            
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONCity.CityID, COMMONCity.CityNameA,COMMONCity.CityNameE,COMMONCity.CityNameAComp,COMMONCity.Country,CountryTable.*  from COMMONCity" +
                                   " Left Outer Join (" + CountryDb.SearchStr + ") as CountryTable ON CountryTable.CountryID = COMMONCity.Country";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["CityID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["CityID"].ToString());
            _NameA = objDR["CityNameA"].ToString();
            _NameE = objDR["CityNameE"].ToString();
            _NameAComp = objDR["CityNameAComp"].ToString();
            if (objDR["Country"].ToString() != "")
                _Country = int.Parse(objDR["Country"].ToString());
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONCity (CityNameA,CityNameE,CityNameAComp,Country,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "'," + _Country + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {

            string strSql = "update  COMMONCity ";
            strSql = strSql + " set CityNameA ='" + _NameA + "'";
            strSql = strSql + ", CityNameE ='" + _NameE + "'";
            strSql = strSql + ", CityNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ",Country = " + _Country;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where CityID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONCity set Dis = GetDate() where CityID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONCity.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and CityID = " + _ID.ToString();

            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and CityNameAComp like '" + _NameACompSearch + "'  ";
            if (_CityIDSearch != 0)
                strSql = strSql + " and CityID <> " + _CityIDSearch.ToString();

            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and CityNameAComp like '%" + _NameAComp + "%'  ";
            if (_CountrySearch != 0)
                strSql = strSql + " and Country  = " + _CountrySearch + "";                   
            strSql = strSql + " Order by CityID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "City");
        }
        #endregion
    }
}
