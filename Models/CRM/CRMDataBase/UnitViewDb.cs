using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitViewDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        int _ProjectID;

        #region Constractors
        public UnitViewDb()
        {

        }
        public UnitViewDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public UnitViewDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ProjectID
        {
            set
            {
                _ProjectID = value;
            }
            get
            {
                return _ProjectID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT    ViewID,ViewCode,ViewProject , ViewNameA, ViewNameE " +
                                  " FROM         CRMUnitView ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ViewID"].ToString() != "")
                _ID = int.Parse(objDR["ViewID"].ToString());
            _Code = objDR["ViewCOde"].ToString();
            _ProjectID = int.Parse(objDR["ViewProject"].ToString());
            _NameA = objDR["ViewNameA"].ToString();
            _NameE = objDR["ViewNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMUnitView" +
                            " (ViewCode,ViewProject, ViewNameA, ViewNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "',"+ _ProjectID +",'" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUnitView" +
                            " SET ViewCode ='" + _Code + "'" +
                            ",ViewProject="+ _ProjectID +
                            ", ViewNameA ='" + _NameA + "'" +
                            ", ViewNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where ViewID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitView" +
                            " SET   Dis = GetData() " +
                            " Where ViewID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  ViewID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
