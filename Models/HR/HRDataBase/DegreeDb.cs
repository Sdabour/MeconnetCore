using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class DegreeDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public DegreeDb()
        {


        }
        public DegreeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["DegreeNameA"].ToString();
            _NameE = objDR["DegreeNameE"].ToString();
        }
        public DegreeDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["DegreeID"].ToString());
            _NameA = objDR["DegreeNameA"].ToString();
            _NameE = objDR["DegreeNameE"].ToString();

        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONDegree.DegreeID, COMMONDegree.DegreeNameA,COMMONDegree.DegreeNameE  from COMMONDegree";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONDegree (DegreeNameA,DegreeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONDegree ";
            strSql = strSql + " set DegreeNameA ='" + _NameA + "'";
            strSql = strSql + ", DegreeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where DegreeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONDegree set Dis = GetDate() where DegreeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONDegree.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and DegreeID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
