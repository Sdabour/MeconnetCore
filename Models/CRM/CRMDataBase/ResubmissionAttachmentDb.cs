using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;


namespace SharpVision.CRM.CRMDataBase
{
    public class ResubmissionAttachmentDb : AttachmentDb
    {
        #region PrivateData
        protected int _ResubmissionID;

        string _ResubmissionIDs;
        #endregion

        #region Constractors

        public ResubmissionAttachmentDb()
        {
        }

        public ResubmissionAttachmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _ResubmissionID = int.Parse(objDR["ResubmissionID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        public ResubmissionAttachmentDb(DataRow objDR)
            : base(objDR)
        {

            _ResubmissionID = int.Parse(objDR["ResubmissionID"].ToString());
            if (objDR.Table.Columns["ResubmissionAttachmentID"] != null)
                int.TryParse(objDR["ResubmissionAttachmentID"].ToString(), out _ID);

        }

        #endregion
        #region PublicAccessories
        public int ResubmissionID
        {
            set
            {
                _ResubmissionID = value;
            }
            get
            {
                return _ResubmissionID;
            }

        }
        public string ResubmissionIDs
        {
            set
            {
                _ResubmissionIDs = value;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CRMResubmissionAttachment.AttachmentID,CRMResubmissionAttachment.ResubmissionAttachmentID, COMMONAttachmentType.AttachmentTypeID,CRMResubmissionAttachment.AttachmentDesc, " +
                      " COMMONAttachmentType.AttachmentTypeNameA, COMMONAttachmentType.AttachmentTypeNameE, " +
                      " CRMResubmissionAttachment.ResubmissionID, CRMResubmissionAttachment.AttachmentParentID, " +
                      " CRMResubmissionAttachment.AttachmentFamilyID" +
                      " FROM         CRMResubmissionAttachment INNER JOIN " +
                      " COMMONAttachmentType ON CRMResubmissionAttachment.AttachmentTypeID = COMMONAttachmentType.AttachmentTypeID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetOldRelatedCustomers(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("AttachmentParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["AttachmentID"].ToString();
                strIDs = strIDs + objDR["AttachmentID"].ToString();
                SetOldRelatedCustomers(strTempParent, dtTemp, ref strIDs);
            }
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " INSERT INTO CRMResubmissionAttachment" +
                            "(AttachmentID, ResubmissionID, AttachmentTypeID, AttachmentParentID, AttachmentFamilyID,AttachmentDesc)" +
                            " VALUES     (" + _AttachmentID + "," + _ResubmissionID + "," + _AttachmentTypeID + "," + _ParentID + "," + _FamilyID + ",'" + _Desc + "')";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));

            if (_ParentID == 0)
            {
                strSql = " update CRMResubmissionAttachment set AttachmentParentID =" + _ID + ",AttachmentFamilyID =" + _ID + " where AttachmentID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }

        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    CRMResubmissionAttachment " +
                            " SET RservationID = " + _ResubmissionID + " " +
                            " , AttachmentTypeID = " + _AttachmentTypeID + " " +
                            " , AttachmentParentID = " + _ParentID + " " +
                            " , AttachmentFamilyID = " + _FamilyID + " " +
                            " , AttachmentID = " + _AttachmentID + "" +
                            " ,AttachmentDesc = '" + _Desc + "'" +
                            " where ResubmissionAttachmentID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            //strSql = " select * from CRMResubmissionAttachment where AttachmentFamilyID in" +
            //      "(select AttachmentFamilyID from CRMResubmissionAttachment where AttachmentFamilyID=" + _ID + "and AttachmentID<>" + _AttachmentID + "and AttachmentFamilyID<>" + _FamilyID + ")";
            //DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            //if (dtTemp.Rows.Count == 0)
            //    return;
            //string strIDs = "";
            //SetOldRelatedCustomers(_ID.ToString(), dtTemp, ref strIDs);
            //strSql = "Update CRMResubmissionAttachment set AttachmentFamilyID = " + _FamilyID + " where ResubmissionAttachmentID in ( " + strIDs + ")";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CRMResubmissionAttachment.ResubmissionAttachmentID = " + _ID.ToString();
            if (_ResubmissionID != 0)
                strSql = strSql + " and CRMResubmissionAttachment.ResubmissionID = " + _ResubmissionID;
            if (_ResubmissionIDs != null && _ResubmissionIDs != "")
                strSql = strSql + " and CRMResubmissionAttachment.ResubmissionID in (" + _ResubmissionIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMResubmissionAttachment where ResubmissionID =  "+ _ResubmissionID  +" and ResubmissionAttachmentID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            AttachmentFileDb objDb = new AttachmentFileDb();
            objDb.ID = _AttachmentID;
            objDb.Delete();


        }
        #endregion


    }
}
