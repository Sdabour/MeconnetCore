using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class ScientificDegreeDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public ScientificDegreeDb()
        {


        }
        public ScientificDegreeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["DegreeNameA"].ToString();
                _NameE = objDR["DegreeNameE"].ToString();
            }
        }
        public ScientificDegreeDb(DataRow objDR)
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
                string Returned = @"SELECT COMMONScientificDegree.DegreeID, COMMONScientificDegree.DegreeNameA,COMMONScientificDegree.DegreeNameE  from COMMONScientificDegree";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONScientificDegree (DegreeNameA,DegreeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONScientificDegree ";
            strSql = strSql + " set DegreeNameA ='" + _NameA + "'";
            strSql = strSql + ", DegreeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where DegreeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONScientificDegree set Dis = GetDate() where DegreeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONScientificDegree.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and DegreeID = " + _ID.ToString();

            strSql += " Order by DegreeNameA";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
