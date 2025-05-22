using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class NewsAttachmentTypeBiz : BaseSingleBiz
    {

        #region Private Data

        #endregion
        #region Constructors
        public NewsAttachmentTypeBiz()
        {
            _BaseDb = new NewsAttachmentTypeDb();
        }
        public NewsAttachmentTypeBiz(int intNewsAttachmentTypeID)
        {
            _BaseDb = new NewsAttachmentTypeDb(intNewsAttachmentTypeID);
        }
        public NewsAttachmentTypeBiz(DataRow objDR)
        {
            _BaseDb = new NewsAttachmentTypeDb(objDR);
        }

        public NewsAttachmentTypeBiz(NewsAttachmentTypeDb objBaseDb)
        {
            _BaseDb = objBaseDb;
        }
        #endregion
        #region Public Properties



        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public static void Add(string strNewsAttachmentTypeNameA, string strNewsAttachmentTypeNameE)
        {

            NewsAttachmentTypeDb objBaseDb = new NewsAttachmentTypeDb();
            objBaseDb.NameA = strNewsAttachmentTypeNameA;
            objBaseDb.NameE = strNewsAttachmentTypeNameE;
            objBaseDb.Add();
        }
        public static void Edit(int intNewsAttachmentTypeID, string strNewsAttachmentTypeNameA, string strNewsAttachmentTypeNameE)
        {
            NewsAttachmentTypeDb objBaseDb = new NewsAttachmentTypeDb();
            objBaseDb.ID = intNewsAttachmentTypeID;
            objBaseDb.NameA = strNewsAttachmentTypeNameA;
            objBaseDb.NameE = strNewsAttachmentTypeNameE;
            objBaseDb.Edit();
        }
        public static void Delete(int intNewsAttachmentTypeID)
        {
            NewsAttachmentTypeDb objBaseDb = new NewsAttachmentTypeDb();
            objBaseDb.ID = intNewsAttachmentTypeID;
            objBaseDb.Delete();
        }
        public NewsAttachmentTypeBiz Copy()
        {
            NewsAttachmentTypeBiz Returned = new NewsAttachmentTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            return Returned;
        }
        #endregion
    }

}