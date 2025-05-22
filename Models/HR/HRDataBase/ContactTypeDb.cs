using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class ContactTypeDb : BaseSingleDb
    {
        #region Private Data
        string _IDsSearch;
        #endregion
        #region Constructors
        public ContactTypeDb()
        {

        }

        public ContactTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["ContactTypeNameA"].ToString();
            _NameE = objDR["ContactTypeNameE"].ToString();
        }
        public ContactTypeDb(DataRow objDR)
        {
            //_ContactTypeDb = DR;
            _ID = int.Parse(objDR["ContactTypeID"].ToString());
            _NameA = objDR["ContactTypeNameA"].ToString();
            _NameE = objDR["ContactTypeNameE"].ToString();

        }
        #endregion
        #region Public Properties
        public string IDsSearch { set { _IDsSearch = value; } }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT HRContactType.ContactTypeID, HRContactType.ContactTypeNameA ,HRContactType.ContactTypeNameE  " +
                               " from HRContactType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HRContactType (ContactTypeNameA,ContactTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  HRContactType ";
            strSql = strSql + " set ContactTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,ContactTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ContactTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRContactType set Dis = GetDate() where ContactTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRContactType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ContactTypeID = " + _ID.ToString();

            if (_IDsSearch != null && _IDsSearch != "")
            {
                strSql += "And (ContactTypeID in ("+ _IDsSearch +"))";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}