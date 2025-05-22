using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ContactDb : BaseSingleDb
    {
        #region Private Data
        //protected int _ID;
        //protected string _Name;
        #endregion
        #region Constructors
        public ContactDb()
        {


        }
        public ContactDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                _NameA = dtTemp.Rows[0]["ContactNameA"].ToString();
                _NameE = dtTemp.Rows[0]["ContactNameE"].ToString();
            }
        }
        public ContactDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ContactID"].ToString());
            if (objDR.Table.Columns["ContactName"] != null)
                _NameA = objDR["ContactName"].ToString();
            try
            {
                if (objDR.Table.Columns["ContactNameA"] != null)
                {
                    _NameA = objDR["ContactNameA"].ToString();
                    _NameE = objDR["ContactNameE"].ToString();
                }
            }
            catch
            { 
            }

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT COMMONContact.ContactID, COMMONContact.ContactNameA, COMMONContact.ContactNameE from COMMONContact";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONContact (ContactNameA,ContactNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONContact ";
            strSql = strSql + " set ContactNameA ='" + _NameA + "'";
            strSql = strSql + ", ContactNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ContactID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONContact set Dis = GetDate() where ContactID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr;
            strSql = strSql + " WHERE    (COMMONContact.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ContactID = " + _ID.ToString();
            if (_NameA != "" && _NameA != null)
                strSql = strSql + " and ContactNameA = '" + _NameA + "'  ";
            if (_NameE != "" && _NameE != null)
                strSql = strSql + " and ContactNameE = '" + _NameE + "'  ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
