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
    public class NewsAttachmentDb : AttachmentDb
    {
        #region PrivateData
        protected int _NewsID;

        string _NewsIDs;
        #endregion

        #region Constractors

        public NewsAttachmentDb()
        {
        }

        public NewsAttachmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _NewsID = int.Parse(objDR["NewsID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        public NewsAttachmentDb(DataRow objDR)
            : base(objDR)
        {
            _ID = int.Parse(objDR["NewsAttachmentID"].ToString());
            _NewsID = int.Parse(objDR["NewsID"].ToString());


        }

        #endregion
        #region PublicAccessories
        public int NewsID
        {
            set
            {
                _NewsID = value;
            }
            get
            {
                return _NewsID;
            }

        }
        public string NewsIDs
        {
            set
            {
                _NewsIDs = value;
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
                string Returned = " SELECT     CRMNewsAttachment.AttachmentID,CRMNewsAttachment.NewsAttachmentID,CRMNewsAttachment.AttachmentDesc,CRMNewsAttachment.AttachmentTypeID, " +
                      " AttachmentTypeTable.*, " +
                      " CRMNewsAttachment.NewsID, CRMNewsAttachment.AttachmentParentID, " +
                      " CRMNewsAttachment.AttachmentFamilyID" +
                      " FROM         CRMNewsAttachment INNER JOIN " +
                      " (" + NewsAttachmentTypeDb.SearchStr + ") as AttachmentTypeTable ON CRMNewsAttachment.AttachmentTypeID = AttachmentTypeTable.NewsAttachmentTypeID ";

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
            string strSql = " INSERT INTO CRMNewsAttachment" +
                            "(AttachmentID, NewsID, AttachmentTypeID, AttachmentParentID, AttachmentFamilyID,AttachmentDesc)" +
                            " VALUES     (" + _AttachmentID + "," + _NewsID + "," + _AttachmentTypeID + "," + _ParentID + "," + _FamilyID + ",'" + _Desc + "')";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));

            if (_ParentID == 0)
            {
                strSql = " update CRMNewsAttachment set AttachmentParentID =" + _ID + ",AttachmentFamilyID =" + _ID + " where AttachmentID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }

        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    CRMNewsAttachment " +
                            " SET RservationID = " + _NewsID + " " +
                            " , AttachmentTypeID = " + _AttachmentTypeID + " " +
                            " , AttachmentParentID = " + _ParentID + " " +
                            " , AttachmentFamilyID = " + _FamilyID + " " +
                            " , AttachmentID = " + _AttachmentID + "" +
                            " ,AttachmentDesc = '" + _Desc + "'" +
                            " where NewsAttachmentID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CRMNewsAttachment.NewsAttachmentID = " + _ID.ToString();
            if (_NewsID != 0)
                strSql = strSql + " and CRMNewsAttachment.NewsID = " + _NewsID;
            if (_NewsIDs != null && _NewsIDs != "")
                strSql = strSql + " and CRMNewsAttachment.NewsID in (" + _NewsIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMNewsAttachment where NewsAttachmentID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            AttachmentFileDb objDb = new AttachmentFileDb();
            objDb.ID = _AttachmentID;
            objDb.Delete();


        }
        #endregion


    }
}
