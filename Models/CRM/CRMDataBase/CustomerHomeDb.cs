using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CustomerHomeDb
    {
        #region Private Data
        public int _Customer;
        public int _Country;
        public int _City;
        public int _District;
        public int _Region;
        public string _OtherValue;
        #endregion
        #region Constructors
        public CustomerHomeDb()
        {

        }
        public CustomerHomeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public CustomerHomeDb(int intCustomerID)
        {
            if (intCustomerID == 0)
                return;
            _Customer = intCustomerID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
            else
                _Customer = 0;

        }
        #endregion
        #region Public Properties
        public int Customer { set { _Customer = value; } get { return _Customer; } }
        public int Country { set { _Country = value; } get { return _Country; } }
        public int City { set { _City = value; } get { return _City; } }
        public int District { set { _District = value; } get { return _District; } }
        public int Region { set { _Region = value; } get { return _Region; } }
        public string OtherValue { set { _OtherValue = value; } get { return _OtherValue; } }

        public string AddStr
        {
            get
            {
                string strReturn = " Insert into CRMCustomerHome (Customer,Country,City,District,Region,OtherValue)"+
                                   " Values (" + _Customer + " ," + _Country + "," + _City + "," + _District + "," + _Region + ",'" + _OtherValue + "')";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturn = " Update CRMCustomerHome " +
                                   " Set Country = " + _Country + "" +
                                   " ,City = " + _City + "" +
                                   " ,District = " + _District + "" +
                                   " ,Region = " + _Region + "" +
                                   " ,OtherValue = '" + _OtherValue + "'" +
                                   " Where Customer = "+ _Customer +"";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = "Delete From CRMCustomerHome Where Customer = " + _Customer + "";
                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     Customer, Country, City, District, Region, OtherValue "+
                                   " FROM CRMCustomerHome";
                return strReturn;
            }
        }
         
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _Customer = int.Parse(objDr["Customer"].ToString());
            _Country = int.Parse(objDr["Country"].ToString());
            _City = int.Parse(objDr["City"].ToString());
            _District = int.Parse(objDr["District"].ToString());
            _Region = int.Parse(objDr["Region"].ToString());
            _OtherValue = objDr["OtherValue"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";

            if (_Customer != 0)
                strSql += " And (Customer=" + _Customer + ")";
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
