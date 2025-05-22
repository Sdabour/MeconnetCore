using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class CountryDb : BaseSingleDb 
    {
        #region Private Data
      
        string _NationalityA;
        string _NationalityE;
        string _CodeA;
        string _CodeE;
        #endregion
        #region Constructors
        public CountryDb()
        {

        }

        public CountryDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public CountryDb(DataRow objDR)
        {
            SetData(objDR);
        }
        public CountryDb(int intID, string strName,string strNationality)
        {
            _ID = intID;
            if (SysData.Language == 0)
            {
                _NameA = strName;
                _NationalityA = strNationality;
            }
            else
            {
                _NameA = strName;
                _NationalityA = strNationality;
 
            }
        }
        #endregion
        #region Public Properties
       
        public string NationalityA
        {
            set 
            {
                _NationalityA = value;
            }
            get
            {
                return _NationalityA;
            }
        }
        public string NationalityE
        {
            set
            {
                _NationalityE = value;
            }
            get
            {
                return _NationalityE;
            }
        }
        public string CodeA
        {
            set
            {
                _CodeA = value;
            }
            get
            {
                return _CodeA;
            }
        }
        public string CodeE
        {
            set
            {
                _CodeE = value;
            }
            get
            {
                return _CodeE;
            }
        }
        public string Nationality
        {
            
            get
            {
                if (SysData.Language == 0)
                    return _NationalityA;
                else
                    return _NationalityE;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT COMMONCountry.CountryID, COMMONCountry.CountryNameA,COMMONCountry.CountryNameE," +
                " COMMONCountry.CountryNationalityA,COMMONCountry.CountryNationalityE,COMMONCountry.CountryCodeA,COMMONCountry.CountryCodeE " +
                " from COMMONCountry  ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["CountryID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["CountryID"].ToString());
            _NameA = objDR["CountryNameA"].ToString();
            _NameE = objDR["CountryNameE"].ToString();
            _NationalityA = objDR["CountryNationalityA"].ToString();
            _NationalityE = objDR["CountryNationalityE"].ToString();
            _CodeA = objDR["CountryCodeA"].ToString();
            _CodeE = objDR["CountryCodeE"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONCountry (CountryNameA,CountryNameE,CountryNationalityA,CountryNationalityE,CountryCodeA,CountryCodeE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NationalityA + "','" + _NationalityE + "','" + _CodeA + "','" + _CodeE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = "update  COMMONCountry ";
            strSql = strSql + " set CountryNameA ='" + _NameA + "'";
            strSql = strSql + " ,CountryNameE ='" + _NameE + "'";
            strSql = strSql + ",CountryNationalityA='" + _NationalityA + "'";
            strSql = strSql + ",CountryNationalityE='" + _NationalityE + "'";
            strSql = strSql + ",CountryCodeA='" + _CodeA + "'";
            strSql = strSql + ",CountryCodeE='" + _CodeE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where CountryID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONCountry set Dis = GetDate() where CountryID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONCountry.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and CountryID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Country");
        }
        #endregion
    }
}
