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
    public class SubjectDb : BaseSelfRelatedDb

    {
        #region Private Data

        #endregion
        #region Constructors
        public SubjectDb()
        {

        }

        public SubjectDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["SubjectNameA"].ToString();
        }
        public SubjectDb(DataRow objDR)
        {
            //_SubjectDb = DR;
            _ID = int.Parse(objDR["SubjectID"].ToString());
            _NameA = objDR["SubjectNameA"].ToString();
            _NameE = objDR["SubjectNameE"].ToString();
            _ParentID = int.Parse(objDR["SubjectParentID"].ToString());
            _FamilyID = int.Parse(objDR["SubjectFamilyID"].ToString());

        }
        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT COMMONSubject.SubjectID, COMMONSubject.SubjectNameA ,COMMONSubject.SubjectNameE,SubjectParentID,SubjectFamilyID  " +
                               " from COMMONSubject ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetOldRelatedCosts(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("SubjectParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["SubjectID"].ToString();
                strIDs = strIDs + objDR["SubjectID"].ToString();
                SetOldRelatedCosts(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "insert into COMMONSubject (SubjectNameA,SubjectNameE,SubjectParentID,SubjectFamilyID,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+_ParentID+","+_FamilyID+"," + SysData.CurrentUser.ID + ",Getdate())";
            if (_ParentID == 0)
            {
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
                strSql = "update COMMONSubject set SubjectParentID = " + _ID + ", SubjectFamilyID =" + _ID;
                strSql = strSql + " where SubjectID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "update  COMMONSubject ";
            strSql = strSql + " set SubjectNameA ='" + _NameA + "'";
            strSql = strSql + " ,SubjectNameE ='" + _NameE + "'";
            strSql = strSql + " ,SubjectParentID = "+_ParentID+" ";
            strSql = strSql + " ,SubjectFamilyID =" + _FamilyID + " ";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where SubjectID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = "select * from COMMONSubject where SubjectFamilyID in " +
             " (select SubjectFamilyID from COMMONSubject where SubjectParentID=" + _ID + " and SubjectID <> " + _ID + " and SubjectFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCosts(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update COMMONSubject set SubjectFamilyID = " + _FamilyID + " where SubjectID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONSubject set Dis = GetDate() where SubjectID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONSubject.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and SubjectID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}