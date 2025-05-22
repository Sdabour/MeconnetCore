using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class RegionDb : BaseSingleDb
    {
        #region Private Data
        protected int _City;
        string _NameAComp;
        int _RegionIDSearch;
        string _NameACompSearch;
        #endregion

        #region Constructors
        public RegionDb()
        {

        }
        public RegionDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["RegionNameA"].ToString();
                _NameE = objDR["RegionNameE"].ToString();
                _NameAComp = objDR["RegionNameAComp"].ToString();
                _City = int.Parse(objDR["City"].ToString());
            }
        }
        public RegionDb(DataRow objDR)
        {
            if (objDR.Table.Columns["RegionID"]  == null ||objDR["RegionID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["RegionID"].ToString());
            _NameA = objDR["RegionNameA"].ToString();
            _NameE = objDR["RegionNameE"].ToString();
            _NameAComp = objDR["RegionNameAComp"].ToString();
            if (objDR["City"].ToString() == "")
                return;
            _City = int.Parse(objDR["City"].ToString());

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
        public int RegionIDSearch
        {
            set
            {
                _RegionIDSearch = value;
            }
            get
            {
                return _RegionIDSearch;
            }
        }
        public string NameACompSearch
        {
            set
            {
                _NameACompSearch = value;
            }
            get
            {
                return _NameACompSearch;
            }
        }
        public int City
        {
            set
            {
                _City = value;
            }
            get
            {
                return _City;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned =  " SELECT COMMONRegion.RegionID, COMMONRegion.RegionNameA,"+
                                   " COMMONRegion.RegionNameE,COMMONRegion.RegionNameAComp,COMMONRegion.City,CityTable.*" +
                                   " from COMMONRegion Inner Join (" + CityDb.SearchStr + ") as CityTable On CityTable.CityID = COMMONRegion.City";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONRegion (RegionNameA,RegionNameE,RegionNameAComp,City,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "',"+ _City +"," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONRegion ";
            strSql = strSql + " set RegionNameA ='" + _NameA + "'";
            strSql = strSql + ", RegionNameE ='" + _NameE + "'";
            strSql = strSql + ", RegionNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", City = " + _City;
            strSql = strSql + ", UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ", TimUpd =Getdate() ";
            strSql = strSql + "  where RegionID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONRegion set Dis = GetDate() where RegionID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONRegion.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and RegionID = " + _ID.ToString();

            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and RegionNameAComp like '" + _NameACompSearch + "'  ";
            if (_RegionIDSearch != 0)
                strSql = strSql + " and RegionID <> " + _RegionIDSearch.ToString();

            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and RegionNameAComp like '%" + _NameAComp + "%'  ";
            if (_City != 0)
                strSql = strSql + " and City = " + _City + "";


            strSql = strSql + " Order by RegionNameAComp ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Region");
        }
        #endregion
    }
}
