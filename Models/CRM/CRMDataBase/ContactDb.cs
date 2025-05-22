using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.CRM.CRMDataBase
{
    public class ContactDb1
    {
        #region Private Data
        protected int _ID;
        protected string _Name;
        #endregion
        #region Constructors
        public ContactDb1()
        {
            

        }

        public ContactDb1(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _Name = objDR["ContactName"].ToString();
        }
        public ContactDb1(DataRow objDR)
        {
            _ID = int.Parse(objDR["ContactID"].ToString());
            _Name = objDR["ContactName"].ToString();
           
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT CRMContact.ContactID, CRMContact.ContactName "+
                    " from CRMContact";
                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "insert into CRMContact (ContactName,UsrIns,TimIns) " +
            "values('" + _Name + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public  void Edit()
        {
            string strSql = "update  CRMContact ";
            strSql = strSql + " set ContactName ='" + _Name + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ContactID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public  void Delete()
        {
            string strSql = "update CRMContact set Dis = GetDate() where ContactID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public DataTable Search()
        {
            string strSql = "SELECT CRMContact.ContactID, CRMContact.ContactName from CRMContact";
            strSql = strSql + " WHERE    (CRMContact.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ContactID = " + _ID.ToString();
            if (_Name != "" && _Name != null)
                strSql = strSql + " and ContactName = '" + _Name + "'  ";
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
