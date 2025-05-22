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
    public class ShiftTypeDb : BaseSelfRelatedDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public ShiftTypeDb()
        {
        }
        public ShiftTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ShiftTypeDb(int intID)
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
        public string AddStr
        {
            get
            {

                string Returned = " INSERT INTO HRShiftType" +
                                  " (ShiftTypeNameA, ShiftTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRShiftType " +
                                  " SET ShiftTypeNameA ='" + _NameA + "'" +
                                  ", ShiftTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (ShiftTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRShiftType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (ShiftTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRShiftType.ShiftTypeID, HRShiftType.ShiftTypeNameA, HRShiftType.ShiftTypeNameE FROM         HRShiftType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ShiftTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ShiftTypeID"].ToString());
            _NameA = objDr["ShiftTypeNameA"].ToString();
            _NameE = objDr["ShiftTypeNameE"].ToString();
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
                strSql += " And ShiftTypeID ="+ _ID +"";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
