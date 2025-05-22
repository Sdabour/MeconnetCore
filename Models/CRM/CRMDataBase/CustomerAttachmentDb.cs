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
    public class CustomerAttachmentDb : AttachmentDb
    {
        #region PrivateData
        protected int _CustomerID;
        

        #endregion

        #region Constractors

        public CustomerAttachmentDb()
        {
        }

        public CustomerAttachmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _CustomerID = int.Parse(objDR["CustomerID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        public CustomerAttachmentDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["CustomerAttachmentID"].ToString());
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _CustomerID = int.Parse(objDR["CustomerID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        #endregion
        #region PublicAccessories
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }

        }
       
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT    CRMCustomerAttachment.AttachmentID,CRMCustomerAttachment.CustomerAttachmentID, COMMONAttachmentType.AttachmentTypeID,CRMCustomerAttachment.AttachmentDesc, " +
                      " COMMONAttachmentType.AttachmentTypeNameA, COMMONAttachmentType.AttachmentTypeNameE, " +
                      " CRMCustomerAttachment.CustomerID, CRMCustomerAttachment.AttachmentParentID, " +
                      " CRMCustomerAttachment.AttachmentFamilyID" +
                      " FROM         CRMCustomerAttachment INNER JOIN " +
                      " COMMONAttachmentType ON CRMCustomerAttachment.AttachmentTypeID = COMMONAttachmentType.AttachmentTypeID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetOldRelatedCustomers(string stCRMarentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("AttachmentParentID = " + stCRMarentID);
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
            string strSql = " INSERT INTO CRMCustomerAttachment" +
                            "(AttachmentID, CustomerID, AttachmentTypeID, AttachmentParentID, AttachmentFamilyID,AttachmentDesc)" +
                            " VALUES     (" + _AttachmentID + "," + _CustomerID + "," + _AttachmentTypeID + "," + _ParentID + "," + _FamilyID + ",'" + _Desc + "')";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));

            if (_ParentID == 0)
            {
                strSql = " update CRMCustomerAttachment set AttachmentParentID =" + _ID + ",AttachmentFamilyID =" + _ID + " where AttachmentID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }

        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    CRMCustomerAttachment " +
                            " SET CustomerID = " + _CustomerID + " " +
                            " , AttachmentTypeID = " + _AttachmentTypeID + " " +
                            " , AttachmentParentID = " + _ParentID + " " +
                            " , AttachmentFamilyID = " + _FamilyID + " " +
                            " , AttachmentID = " + _AttachmentID + "" +
                            " ,AttachmentDesc = '" + _Desc + "'" +
                            " where CustomerAttachmentID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            //strSql = " select * from CRMCustomerAttachment where AttachmentFamilyID in" +
            //      "(select AttachmentFamilyID from CRMCustomerAttachment where AttachmentFamilyID=" + _ID + "and AttachmentID<>" + _AttachmentID + " and AttachmentFamilyID<>" + _FamilyID + ")";
            //DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            //if (dtTemp.Rows.Count == 0)
            //    return;
            //string strIDs = "";
            //SetOldRelatedCustomers(_ID.ToString(), dtTemp, ref strIDs);
            //strSql = "Update CRMCustomerAttachment set AttachmentFamilyID = " + _FamilyID + " where CustomerAttachmentID in ( " + strIDs + ")";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CRMCustomerAttachment.CustomerAttachmentID = " + _ID.ToString();
            if (_CustomerID != 0)
                strSql = strSql + " and CRMCustomerAttachment.CustomerID = " + _CustomerID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMCustomerAttachment where CustomerAttachmentID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            AttachmentFileDb objDb = new AttachmentFileDb();
            objDb.ID = _AttachmentID;
            objDb.Delete();

        }
        #endregion


    }
}
