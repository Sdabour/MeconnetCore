using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class AttachmentClassificationDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public AttachmentClassificationDb()
        {


        }
        public AttachmentClassificationDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["AttachmentClassificationNameA"].ToString();
                _NameE = objDR["AttachmentClassificationNameE"].ToString();
            }
        }
        public AttachmentClassificationDb(DataRow objDR)
        {
            if (objDR["AttachmentClassificationID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["AttachmentClassificationID"].ToString());
            _NameA = objDR["AttachmentClassificationNameA"].ToString();
            _NameE = objDR["AttachmentClassificationNameE"].ToString();

        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONAttachmentClassification.AttachmentClassificationID, COMMONAttachmentClassification.AttachmentClassificationNameA,COMMONAttachmentClassification.AttachmentClassificationNameE  from COMMONAttachmentClassification";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONAttachmentClassification (AttachmentClassificationNameA,AttachmentClassificationNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONAttachmentClassification ";
            strSql = strSql + " set AttachmentClassificationNameA ='" + _NameA + "'";
            strSql = strSql + ", AttachmentClassificationNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where AttachmentClassificationID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONAttachmentClassification set Dis = GetDate() where AttachmentClassificationID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONAttachmentClassification.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and AttachmentClassificationID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "AttachmentClassification");
        }
        #endregion
    }
}
