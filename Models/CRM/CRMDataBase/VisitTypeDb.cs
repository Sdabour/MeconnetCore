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
    public class VisitTypeDb : BaseSelfRelatedDb

    {
        #region Private Data

        #endregion
        #region Constructors
        public VisitTypeDb()
        {

        }

        public VisitTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["VisitTypeNameA"].ToString();
        }
        public VisitTypeDb(DataRow objDR)
        {
            //_VisitTypeDb = DR;
            SetData(objDR);

        }
        #endregion
        #region Public Properties
        int _WorkGroup;
        public int WorkGroup
        {
            set => _WorkGroup = value;
            get => _WorkGroup;
        }
        string _WorkGroupNameA;
        public string WorkGroupNameA
        {
            get => _WorkGroupNameA;
        }
        string _WorkGroupNameE;
        public string WorkGroupNameE
        {
            get => _WorkGroupNameE;
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT CRMVisitType.VisitTypeID,  dbo.CRMVisitType.VisitTypeCode, CRMVisitType.VisitTypeNameA ,CRMVisitType.VisitTypeNameE,VisitTypeParentID,VisitTypeFamilyID" +
                    ",VistTypeWorkGroup,dbo.HRWorkGroup.WorkGroupNameA AS VisitTypeWorkGroupNameA, dbo.HRWorkGroup.WorkGroupNameE AS VisitTypeWorkGroupNameE  " +
                               " from CRMVisitType " +
                               " LEFT OUTER JOIN  dbo.HRWorkGroup " +
                               " ON dbo.CRMVisitType.VistTypeWorkGroup = dbo.HRWorkGroup.WorkGroupID";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["VisitTypeID"].ToString());
            _NameA = objDr["VisitTypeNameA"].ToString();
            _NameE = objDr["VisitTypeNameE"].ToString();
            try
            {
                int.TryParse(objDr["VisitTypeParentID"].ToString(), out _ParentID);
                int.TryParse(objDr["VisitTypeFamilyID"].ToString(), out _FamilyID);
            }
            catch (Exception ex) { }
            if (objDr.Table.Columns["VistTypeWorkGroup"] != null)
                int.TryParse(objDr["VistTypeWorkGroup"].ToString(), out _WorkGroup);

            if (objDr.Table.Columns["VisitTypeWorkGroupNameA"] != null)
                _WorkGroupNameA = objDr["VisitTypeWorkGroupNameA"].ToString();

            if (objDr.Table.Columns["VisitTypeWorkGroupNameE"] != null)
                _WorkGroupNameE = objDr["VisitTypeWorkGroupNameE"].ToString();
        }

        void SetOldRelatedCosts(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("VisitTypeParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["VisitTypeID"].ToString();
                strIDs = strIDs + objDR["VisitTypeID"].ToString();
                SetOldRelatedCosts(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "insert into CRMVisitType (VisitTypeNameA,VisitTypeNameE,VisitTypeParentID,VisitTypeFamilyID,VistTypeWorkGroup, UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _ParentID + "," + _FamilyID + "," + _WorkGroup + "," + SysData.CurrentUser.ID + ",Getdate())";
            if (_ParentID == 0)
            {
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
                strSql = "update CRMVisitType set VisitTypeParentID = " + _ID + ", VisitTypeFamilyID =" + _ID;
                strSql = strSql + " where VisitTypeID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "update  CRMVisitType ";
            strSql = strSql + " set VisitTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,VisitTypeNameE ='" + _NameE + "'";
            strSql = strSql + " ,VisitTypeParentID = " + _ParentID + " ";
            strSql = strSql + " ,VisitTypeFamilyID =" + _FamilyID + " ";
            strSql += ",VistTypeWorkGroup=" + _WorkGroup;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where VisitTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = "select * from CRMVisitType where VisitTypeFamilyID in " +
             " (select VisitTypeFamilyID from CRMVisitType where VisitTypeParentID=" + _ID + " and VisitTypeID <> " + _ID + " and VisitTypeFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCosts(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update CRMVisitType set VisitTypeFamilyID = " + _FamilyID + " where VisitTypeID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update CRMVisitType set Dis = GetDate() where VisitTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMVisitType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and VisitTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}