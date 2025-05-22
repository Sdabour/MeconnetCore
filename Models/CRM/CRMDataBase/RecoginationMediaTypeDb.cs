using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class RecoginationMediaTypeDb : BaseSelfRelatedDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public RecoginationMediaTypeDb()
        {
        }
        public RecoginationMediaTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public RecoginationMediaTypeDb(int intID)
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

                string Returned = " INSERT INTO CRMRecoginationMediaType" +
                                  " (RecoginationMediaTypeNameA, RecoginationMediaTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    CRMRecoginationMediaType " +
                                  " SET RecoginationMediaTypeNameA ='" + _NameA + "'" +
                                  ", RecoginationMediaTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (RecoginationMediaTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    CRMRecoginationMediaType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (RecoginationMediaTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     CRMRecoginationMediaType.RecoginationMediaTypeID, CRMRecoginationMediaType.RecoginationMediaTypeNameA, CRMRecoginationMediaType.RecoginationMediaTypeNameE FROM         CRMRecoginationMediaType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["RecoginationMediaTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["RecoginationMediaTypeID"].ToString());
            _NameA = objDr["RecoginationMediaTypeNameA"].ToString();
            _NameE = objDr["RecoginationMediaTypeNameE"].ToString();
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
                strSql += " And RecoginationMediaTypeID ="+ _ID +"";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
