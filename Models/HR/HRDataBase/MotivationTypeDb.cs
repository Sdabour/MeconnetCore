using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class MotivationTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        int _IDSearch;
        #endregion
        #region Constructors
        public MotivationTypeDb()
        {
        }
        public MotivationTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public MotivationTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        #endregion
        #region Public Properties
        public int IDSearch
        {
            set
            {
                _IDSearch = value;
            }
        }
        public string AddStr
        {
            get
            {

                string Returned = " INSERT INTO HRMotivationType" +
                                  " (MotivationTypeNameA, MotivationTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRMotivationType " +
                                  " SET MotivationTypeNameA ='" + _NameA + "'" +
                                  ", MotivationTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (MotivationTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRMotivationType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (MotivationTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRMotivationType.MotivationTypeID, HRMotivationType.MotivationTypeNameA, HRMotivationType.MotivationTypeNameE FROM         HRMotivationType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["MotivationTypeID"]== null || objDr["MotivationTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["MotivationTypeID"].ToString());
            _NameA = objDr["MotivationTypeNameA"].ToString();
            _NameE = objDr["MotivationTypeNameE"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public override void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is Null ";
            if (_ID != 0)
            {
                strSql += " And MotivationTypeID=" + _ID + "";
            }
            if (_IDSearch != 0)
            {
                strSql += " And MotivationTypeID=" + _IDSearch + "";
            }
            strSql += " Order By MotivationTypeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
