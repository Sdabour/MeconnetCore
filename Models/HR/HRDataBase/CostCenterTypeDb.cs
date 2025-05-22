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
    public class CostCenterTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        int _IDSearch;
        #endregion
        #region Constructors
        public CostCenterTypeDb()
        {
        }
        public CostCenterTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public CostCenterTypeDb(int intID)
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

                string Returned = " INSERT INTO HRCostCenterType" +
                                  " (CostCenterTypeNameA, CostCenterTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRCostCenterType " +
                                  " SET CostCenterTypeNameA ='" + _NameA + "'" +
                                  ", CostCenterTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (CostCenterTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRCostCenterType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (CostCenterTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRCostCenterType.CostCenterTypeID, HRCostCenterType.CostCenterTypeNameA, HRCostCenterType.CostCenterTypeNameE FROM         HRCostCenterType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["CostCenterTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["CostCenterTypeID"].ToString());
            _NameA = objDr["CostCenterTypeNameA"].ToString();
            _NameE = objDr["CostCenterTypeNameE"].ToString();
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
                strSql += " And CostCenterTypeID=" + _ID + "";
            }
            if (_IDSearch != 0)
            {
                strSql += " And CostCenterTypeID=" + _IDSearch + "";
            }
            strSql += " Order By CostCenterTypeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
