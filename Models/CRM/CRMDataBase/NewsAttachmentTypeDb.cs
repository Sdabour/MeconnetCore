


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
    public class NewsAttachmentTypeDb : BaseSingleDb
    {
        #region Private Data
        //protected bool _FlagNewsAttachmentTypeWorker = false;
        //protected int _NewsAttachmentTypeWorker = 0;


        #endregion
        #region Constructors
        public NewsAttachmentTypeDb()
        {

        }
        public NewsAttachmentTypeDb(bool boolAttachmentWorker, int intNewsAttachmentTypeWorker)
        {
          

        }


        public NewsAttachmentTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["NewsAttachmentTypeNameA"].ToString();
                _NameE = objDR["NewsAttachmentTypeNameE"].ToString();
            }

        }

        public NewsAttachmentTypeDb(DataRow objDR)
        {
            //_NewsAttachmentTypeDb = DR;
            _ID = int.Parse(objDR["NewsAttachmentTypeID"].ToString());
            _NameA = objDR["NewsAttachmentTypeNameA"].ToString();
            _NameE = objDR["NewsAttachmentTypeNameE"].ToString();

        }
        #endregion
        #region Public Properties

        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT CRMNewsAttachmentType.NewsAttachmentTypeID, CRMNewsAttachmentType.NewsAttachmentTypeNameA NewsAttachmentTypeNameA,CRMNewsAttachmentType.NewsAttachmentTypeNameE NewsAttachmentTypeNameE " +
                               " from CRMNewsAttachmentType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into CRMNewsAttachmentType (NewsAttachmentTypeNameA,NewsAttachmentTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  CRMNewsAttachmentType ";
            strSql = strSql + " set NewsAttachmentTypeNameA ='" + _NameA + "'";
            strSql = strSql + ",NewsAttachmentTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where NewsAttachmentTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update CRMNewsAttachmentType set Dis = GetDate() where NewsAttachmentTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMNewsAttachmentType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and NewsAttachmentTypeID = " + _ID.ToString();
           

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
