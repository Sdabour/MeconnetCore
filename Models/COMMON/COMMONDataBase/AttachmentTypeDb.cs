


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
    public class AttachmentTypeDb : BaseSingleDb
    {
        #region Private Data
        protected bool _FlagAttachmentTypeWorker = false;
        protected int _AttachmentTypeWorker = 0;
        protected int _AttachmentClassification = 0;
        
        #endregion
        #region Constructors
        public AttachmentTypeDb()
        {

        }
        public AttachmentTypeDb(bool boolAttachmentWorker, int intAttachmentTypeWorker)
        {
            _FlagAttachmentTypeWorker = boolAttachmentWorker;
            _AttachmentTypeWorker = intAttachmentTypeWorker;

        }


        public AttachmentTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["AttachmentTypeNameA"].ToString();
                _NameE = objDR["AttachmentTypeNameE"].ToString();
                if (objDR["AttachmentClassification"].ToString() != "")
                    _AttachmentClassification = int.Parse(objDR["AttachmentClassification"].ToString());
            }

        }

        public AttachmentTypeDb(DataRow objDR)
        {
            //_AttachmentTypeDb = DR;
            _ID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _NameA = objDR["AttachmentTypeNameA"].ToString();
            _NameE = objDR["AttachmentTypeNameE"].ToString();
            if (objDR.Table.Columns["AttachmentClassification"] != null)
            {
                if (objDR["AttachmentClassification"].ToString() != "")
                    _AttachmentClassification = int.Parse(objDR["AttachmentClassification"].ToString());
            }
        }
        #endregion
        #region Public Properties
        public int AttachmentClassification
        {
            set { _AttachmentClassification = value; }
            get { return _AttachmentClassification; }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT COMMONAttachmentType.AttachmentTypeID, COMMONAttachmentType.AttachmentTypeNameA ,"+
                                  " COMMONAttachmentType.AttachmentTypeNameE ,COMMONAttachmentType.AttachmentClassification,AttachmentClassificationTable.* " +
                                  " from COMMONAttachmentType "+
                                  " Left Outer Join (" + AttachmentClassificationDb.SearchStr + ") as AttachmentClassificationTable On "+
                                  " AttachmentClassificationTable.AttachmentClassificationID = COMMONAttachmentType.AttachmentClassification ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONAttachmentType (AttachmentTypeNameA,AttachmentTypeNameE,AttachmentClassification,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _AttachmentClassification + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONAttachmentType ";
            strSql = strSql + " set AttachmentTypeNameA ='" + _NameA + "'";
            strSql = strSql + ",AttachmentTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",AttachmentClassification =" + _AttachmentClassification + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where AttachmentTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONAttachmentType set Dis = GetDate() where AttachmentTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONAttachmentType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and AttachmentTypeID = " + _ID.ToString();
            if (_FlagAttachmentTypeWorker ==true)
                strSql = strSql + " and AttachmentTypeWorker = "+ _AttachmentTypeWorker +"" ;
            if (_AttachmentClassification != 0)
                strSql = strSql + " and AttachmentClassification = " + _AttachmentClassification.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
