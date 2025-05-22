using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class TopicDb : BaseSelfRelatedDb

    {
        #region Private Data

        #endregion
        #region Constructors
        public TopicDb()
        {

        }

        public TopicDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["TopicNameA"].ToString();
        }
        public TopicDb(DataRow objDR)
        {
            //_TopicDb = DR;
            _ID = int.Parse(objDR["TopicID"].ToString());
            _NameA = objDR["TopicNameA"].ToString();
            _NameE = objDR["TopicNameE"].ToString();
            _ParentID = int.Parse(objDR["TopicParentID"].ToString());
            _FamilyID = int.Parse(objDR["TopicFamilyID"].ToString());

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT COMMONTopic.TopicID, COMMONTopic.TopicNameA ,COMMONTopic.TopicNameE,TopicParentID,TopicFamilyID  " +
                               " from COMMONTopic ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetOldRelatedCosts(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("TopicParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["TopicID"].ToString();
                strIDs = strIDs + objDR["TopicID"].ToString();
                SetOldRelatedCosts(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "insert into COMMONTopic (TopicNameA,TopicNameE,TopicParentID,TopicFamilyID,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+_ParentID+","+_FamilyID+"," + SysData.CurrentUser.ID + ",Getdate())";
            if (_ParentID == 0)
            {
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
                strSql = "update COMMONTopic set TopicParentID = " + _ID + ", TopicFamilyID =" + _ID;
                strSql = strSql + " where TopicID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else
               _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "update  COMMONTopic ";
            strSql = strSql + " set TopicNameA ='" + _NameA + "'";
            strSql = strSql + " ,TopicNameE ='" + _NameE + "'";
            strSql = strSql + " ,TopicParentID = "+_ParentID+" ";
            strSql = strSql + " ,TopicFamilyID =" + _FamilyID + " ";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where TopicID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = "select * from COMMONTopic where TopicFamilyID in " +
             " (select TopicFamilyID from COMMONTopic where TopicParentID=" + _ID + " and TopicID <> " + _ID + " and TopicFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCosts(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update COMMONTopic set TopicFamilyID = " + _FamilyID + " where TopicID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONTopic set Dis = GetDate() where TopicID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONTopic.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and TopicID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}