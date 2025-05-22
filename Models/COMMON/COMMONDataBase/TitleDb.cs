using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.COMMON.COMMONDataBase
{
    public class TitleDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public TitleDb()
        {


        }
        public TitleDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["TitleNameA"].ToString();
                _NameE = objDR["TitleNameE"].ToString();
            }
        }
        public TitleDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["TitleID"].ToString());
            _NameA = objDR["TitleNameA"].ToString();
            _NameE = objDR["TitleNameE"].ToString();

        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONTitle.TitleID, COMMONTitle.TitleNameA,COMMONTitle.TitleNameE  from COMMONTitle";
                return Returned;

            }
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONTitle (TitleNameA,TitleNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONTitle ";
            strSql = strSql + " set TitleNameA ='" + _NameA + "'";
            strSql = strSql + ", TitleNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where TitleID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONTitle set Dis = GetDate() where TitleID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONTitle.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and TitleID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
