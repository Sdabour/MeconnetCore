using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ComputerQualificationDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public ComputerQualificationDb()
        {


        }
        public ComputerQualificationDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["ComputerQualificationNameA"].ToString();
                _NameE = objDR["ComputerQualificationNameE"].ToString();
            }
        }
        public ComputerQualificationDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ComputerQualificationID"].ToString());
            _NameA = objDR["ComputerQualificationNameA"].ToString();
            _NameE = objDR["ComputerQualificationNameE"].ToString();

        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONComputerQualification.ComputerQualificationID, COMMONComputerQualification.ComputerQualificationNameA,COMMONComputerQualification.ComputerQualificationNameE  from COMMONComputerQualification";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONComputerQualification (ComputerQualificationNameA,ComputerQualificationNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONComputerQualification ";
            strSql = strSql + " set ComputerQualificationNameA ='" + _NameA + "'";
            strSql = strSql + ", ComputerQualificationNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ComputerQualificationID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONComputerQualification set Dis = GetDate() where ComputerQualificationID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONComputerQualification.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ComputerQualificationID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
