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
    public class ReservationAttachmentDb : AttachmentDb
    {
        #region PrivateData
        protected int _ReservationID;

        string _ReservationIDs;
        #endregion
       
        #region Constractors

        public ReservationAttachmentDb()
        { 
        }

        public ReservationAttachmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        public ReservationAttachmentDb(DataRow objDR):base(objDR)
        {
            
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            

        }

        #endregion
        #region PublicAccessories
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }

        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
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
                string Returned = " SELECT     CRMReservationAttachment.AttachmentID,CRMReservationAttachment.ReservationAttachmentID, COMMONAttachmentType.AttachmentTypeID,CRMReservationAttachment.AttachmentDesc, " +
                      " COMMONAttachmentType.AttachmentTypeNameA, COMMONAttachmentType.AttachmentTypeNameE, " +
                      " CRMReservationAttachment.ReservationID, CRMReservationAttachment.AttachmentParentID, " +
                      " CRMReservationAttachment.AttachmentFamilyID" +
                      " FROM         CRMReservationAttachment INNER JOIN " +
                      " COMMONAttachmentType ON CRMReservationAttachment.AttachmentTypeID = COMMONAttachmentType.AttachmentTypeID ";

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
            string strSql = " INSERT INTO CRMReservationAttachment" +
                            "(AttachmentID, ReservationID, AttachmentTypeID, AttachmentParentID, AttachmentFamilyID,AttachmentDesc)" +
                            " VALUES     ("+_AttachmentID+","+_ReservationID+","+_AttachmentTypeID+","+_ParentID+","+_FamilyID+",'"+_Desc+"')";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));

            if (_ParentID == 0)
            {
                strSql = " update CRMReservationAttachment set AttachmentParentID =" + _ID + ",AttachmentFamilyID =" + _ID + " where AttachmentID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }

        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    CRMReservationAttachment " +
                            " SET RservationID = " + _ReservationID + " " +
                            " , AttachmentTypeID = " + _AttachmentTypeID + " " +
                            " , AttachmentParentID = " + _ParentID + " " +
                            " , AttachmentFamilyID = " + _FamilyID + " " +
                            " , AttachmentID = " + _AttachmentID + "" +
                            " ,AttachmentDesc = '" + _Desc + "'"+
                            " where ReservationAttachmentID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            //strSql = " select * from CRMReservationAttachment where AttachmentFamilyID in" +
            //      "(select AttachmentFamilyID from CRMReservationAttachment where AttachmentFamilyID=" + _ID + "and AttachmentID<>" + _AttachmentID + "and AttachmentFamilyID<>" + _FamilyID + ")";
            //DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            //if (dtTemp.Rows.Count == 0)
            //    return;
            //string strIDs = "";
            //SetOldRelatedCustomers(_ID.ToString(), dtTemp, ref strIDs);
            //strSql = "Update CRMReservationAttachment set AttachmentFamilyID = " + _FamilyID + " where ReservationAttachmentID in ( " + strIDs + ")";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }
        public override DataTable  Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CRMReservationAttachment.ReservationAttachmentID = " + _ID.ToString();
            if (_ReservationID != 0)
                strSql = strSql + " and CRMReservationAttachment.ReservationID = " + _ReservationID;
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " and CRMReservationAttachment.ReservationID in (" + _ReservationIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMReservationAttachment where ReservationAttachmentID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            AttachmentFileDb objDb = new AttachmentFileDb();
            objDb.ID = _AttachmentID;
            objDb.Delete();


        }
        #endregion


    }
}
