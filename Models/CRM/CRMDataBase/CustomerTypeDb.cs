using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CustomerTypeDb : BaseSingleDb
    {
        #region Private Data
       
        bool _IsSecondaryType;
        #endregion
        #region Constructors
        public CustomerTypeDb()
        {


        }

        public CustomerTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["CustomerTypeNameA"].ToString();
            _NameE = objDR["CustomerTypeNameE"].ToString();
            _IsSecondaryType = bool.Parse(objDR["IsSecondary"].ToString());





        }
        public CustomerTypeDb(DataRow objDR)
        {
            //_CustomerTypeDb = DR;
            _ID = int.Parse(objDR["CustomerTypeID"].ToString());
            _NameA = objDR["CustomerTypeNameA"].ToString();
            _NameE = objDR["CustomerTypeNameE"].ToString();
            _IsSecondaryType = bool.Parse(objDR["IsSecondary"].ToString());

        }
        public CustomerTypeDb(int intID,string strName,bool blIsSecondary)
        {
            //_CustomerTypeDb = DR;
            _ID = intID;
            _NameA = strName;
            _IsSecondaryType = blIsSecondary;

        }

        #endregion
        #region Public Properties
       
        public bool IsSecondaryType
        {
            set
            {
                _IsSecondaryType = value;
            }
            get
            {
                return _IsSecondaryType;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  dbo.CRMCustomerType.CustomerTypeID, dbo.CRMCustomerType.CustomerTypeNameA,"+
                    " dbo.CRMCustomerType.CustomerTypeNameE, "+
                    " dbo.CRMCustomerType.IsSecondary "+
                    " FROM   dbo.CRMCustomerType";
                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add() 
        {
            int intIsSecondaryType = _IsSecondaryType ? 1 : 0;
            string strSql = "insert into CRMCustomerType (CustomerTypeNameA,CustomerTypeNameE,IsSecondary,UsrIns,TimIns) " +
            "values('" + _NameA + "','"+ _NameE +"',"+ intIsSecondaryType+","+SysData.CurrentUser.ID+",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intIsSecondaryType = _IsSecondaryType ? 1 : 0;
            string strSql = "update  CRMCustomerType ";
            strSql = strSql + " set CustomerTypeNameA ='" + _NameA + "'";
            strSql = strSql + " set CustomerTypeNameE ='" + _NameE + "'";
            strSql = strSql + " ,IsSecondary  = " + intIsSecondaryType;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where CustomerTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update CRMCustomerType set Dis = GetDate() where CustomerTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMCustomerType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and CustomerTypeID = " + _ID.ToString();
           

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
