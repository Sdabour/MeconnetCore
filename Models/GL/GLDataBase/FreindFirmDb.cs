using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class FreindFirmDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected int _Activity;
        #endregion

        #region Constructors
        public FreindFirmDb()
        { 

        }
        public FreindFirmDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["FirmNameA"].ToString();
            _NameE = objDR["FirmNameE"].ToString();
            _Activity = int.Parse(objDR["FirmActivity"].ToString());
            _FamilyID = int.Parse(objDR["FirmFamilyID"].ToString());
            _ParentID = int.Parse(objDR["FirmParentID"].ToString());
        }
        public FreindFirmDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["FirmID"].ToString());
            _NameA = objDR["FirmNameA"].ToString();
            _NameE = objDR["FirmNameE"].ToString();
            _Activity = int.Parse(objDR["FirmActivity"].ToString());
            _FamilyID = int.Parse(objDR["FirmFamilyID"].ToString());
            _ParentID = int.Parse(objDR["FirmParentID"].ToString());
        }
        #endregion

        #region Public Properties
        public int Activity
        {
            set
            {
                _Activity = value;
            }
            get
            {
                return _Activity;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     FirmID, FirmNameA, FirmNameE, FirmActivity, FirmParentID, FirmFamilyID FROM     GLFreindFirm";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO GLFreindFirm" +
                            " (FirmNameA, FirmNameE, FirmActivity, FirmParentID, FirmFamilyID)" +
                            " VALUES     ('"+_NameA+"','"+_NameE+"',"+_Activity+","+_ParentID+","+_FamilyID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    GLFreindFirm" +
                            " SET   FirmNameA ='" + _NameA + "'" +
                            " , FirmNameE ='" + _NameE + "'" +
                            " , FirmActivity =" + _Activity + "" +
                            " , FirmParentID =" + _ParentID + "" +
                            " , FirmFamilyID =" + _FamilyID + " " +
                            " Where FirmID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    GLFreindFirm SET   Dis = GetDate()";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FirmID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
