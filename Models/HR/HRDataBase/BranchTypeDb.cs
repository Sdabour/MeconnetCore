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
    public class BranchTypeDb : BaseSingleDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public BranchTypeDb()
        {

        }

        public BranchTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["BranchTypeNameA"].ToString();
            _NameE = objDR["BranchTypeNameE"].ToString();
        }
        public BranchTypeDb(DataRow objDR)
        {
            //_BranchTypeDb = DR;
            _ID = int.Parse(objDR["BranchTypeID"].ToString());
            _NameA = objDR["BranchTypeNameA"].ToString();
            _NameE = objDR["BranchTypeNameE"].ToString();

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT HRBranchType.BranchTypeID, HRBranchType.BranchTypeNameA ,HRBranchType.BranchTypeNameE  " +
                               " from HRBranchType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HRBranchType (BranchTypeNameA,BranchTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  HRBranchType ";
            strSql = strSql + " set BranchTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,BranchTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where BranchTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRBranchType set Dis = GetDate() where BranchTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRBranchType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and BranchTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}