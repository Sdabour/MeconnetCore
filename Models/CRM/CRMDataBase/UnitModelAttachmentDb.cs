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
    public class UnitModelAttachmentDb : BaseSelfRelatedDb
    {
        #region PrivateData
        protected int _UnitModelID;
        protected int _AttachmentID;
        protected string _Desc;
        protected int _AttachmentTypeID;
        AttachmentTypeDb _AttachmentTypeDb;

        #endregion

        #region Constractors

        public UnitModelAttachmentDb()
        {
        }

        public UnitModelAttachmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _UnitModelID = int.Parse(objDR["UnitModelID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        public UnitModelAttachmentDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["UnitModelAttachmentID"].ToString());
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _UnitModelID = int.Parse(objDR["UnitModelID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }

        #endregion
        #region PublicAccessories
        public int UnitModelID
        {
            set
            {
                _UnitModelID = value;
            }
            get
            {
                return _UnitModelID;
            }

        }
        public int AttachmentTypeID
        {
            set
            {
                _AttachmentTypeID = value;
            }
            get
            {
                return _AttachmentTypeID;
            }

        }
        public AttachmentTypeDb AttachmentTypeDb
        {
            set
            {
                _AttachmentTypeDb = value;
            }
            get
            {
                return _AttachmentTypeDb;
            }
        }
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }

        }

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT    CRMUnitModelAttachment.AttachmentID,CRMUnitModelAttachment.UnitModelAttachmentID, COMMONAttachmentType.AttachmentTypeID,CRMUnitModelAttachment.AttachmentDesc, " +
                      " COMMONAttachmentType.AttachmentTypeNameA, COMMONAttachmentType.AttachmentTypeNameE, " +
                      " CRMUnitModelAttachment.UnitModelID, CRMUnitModelAttachment.AttachmentParentID, " +
                      " CRMUnitModelAttachment.AttachmentFamilyID" +
                      " FROM         CRMUnitModelAttachment INNER JOIN " +
                      " COMMONAttachmentType ON CRMUnitModelAttachment.AttachmentTypeID = COMMONAttachmentType.AttachmentTypeID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetOldRelatedUnitModels(string stCRMarentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("AttachmentParentID = " + stCRMarentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["AttachmentID"].ToString();
                strIDs = strIDs + objDR["AttachmentID"].ToString();
                SetOldRelatedUnitModels(strTempParent, dtTemp, ref strIDs);
            }
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " INSERT INTO CRMUnitModelAttachment" +
                            "(AttachmentID, UnitModelID, AttachmentTypeID, AttachmentParentID, AttachmentFamilyID,AttachmentDesc)" +
                            " VALUES     (" + _AttachmentID + "," + _UnitModelID + "," + _AttachmentTypeID + "," + _ParentID + "," + _FamilyID + ",'" + _Desc + "')";
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));

            if (_ParentID == 0)
            {
                strSql = " update CRMUnitModelAttachment set AttachmentParentID =" + _ID + ",AttachmentFamilyID =" + _ID + " where AttachmentID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }

        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    CRMUnitModelAttachment " +
                            " SET UnitModelID = " + _UnitModelID + " " +
                            " , AttachmentTypeID = " + _AttachmentTypeID + " " +
                            " , AttachmentParentID = " + _ParentID + " " +
                            " , AttachmentFamilyID = " + _FamilyID + " " +
                            " , AttachmentID = " + _AttachmentID + "" +
                            " ,AttachmentDesc = '" + _Desc + "'" +
                            " where UnitModelAttachmentID =" + _ID;
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            strSql = " select * from CRMUnitModelAttachment where AttachmentFamilyID in" +
                  "(select AttachmentFamilyID from CRMUnitModelAttachment where AttachmentFamilyID=" + _ID + "and AttachmentID<>" + _AttachmentID + " and AttachmentFamilyID<>" + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedUnitModels(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update CRMUnitModelAttachment set AttachmentFamilyID = " + _FamilyID + " where UnitModelAttachmentID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CRMUnitModelAttachment.UnitModelAttachmentID = " + _ID.ToString();
            if (_UnitModelID != 0)
                strSql = strSql + " and CRMUnitModelAttachment.UnitModelID = " + _UnitModelID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void Delete()
        {
            string strSql = "delete from CRMUnitModelAttachment where UnitModelAttachmentID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            AttachmentFileDb objDb = new AttachmentFileDb();
            objDb.ID = _AttachmentID;
            objDb.Delete();

        }
        #endregion


    }
}
