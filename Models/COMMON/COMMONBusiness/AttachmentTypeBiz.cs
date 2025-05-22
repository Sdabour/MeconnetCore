using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentTypeBiz : BaseSingleBiz
    {

        #region Private Data
        AttachmentClassificationBiz _AttachmentClassificationBiz;
        #endregion
        #region Constructors
        public AttachmentTypeBiz()
        {
            _BaseDb = new AttachmentTypeDb();
            _AttachmentClassificationBiz = new AttachmentClassificationBiz();
        }
        public AttachmentTypeBiz(int intAttachmentTypeID)
        {
            _BaseDb = new AttachmentTypeDb(intAttachmentTypeID);
            _AttachmentClassificationBiz = new AttachmentClassificationBiz(((AttachmentTypeDb)_BaseDb).AttachmentClassification);
        }
        public AttachmentTypeBiz(DataRow objDR)
        {
            _BaseDb = new AttachmentTypeDb(objDR);
            if(((AttachmentTypeDb)_BaseDb).AttachmentClassification != 0)
            _AttachmentClassificationBiz = new AttachmentClassificationBiz(objDR);
            else
            _AttachmentClassificationBiz = new AttachmentClassificationBiz();

        }

        public AttachmentTypeBiz(AttachmentTypeDb objBaseDb)
        {
            _BaseDb = objBaseDb;
            _AttachmentClassificationBiz = new AttachmentClassificationBiz(((AttachmentTypeDb)_BaseDb).AttachmentClassification);
        }
        #endregion
        #region Public Properties
        public AttachmentClassificationBiz AttachmentClassificationBiz
        {
            set { _AttachmentClassificationBiz = value; }
            get { return _AttachmentClassificationBiz; }
        }

    #endregion
        #region Private Methods

    #endregion
        #region Public Methods
        public static void Add(string strAttachmentTypeNameA, string strAttachmentTypeNameE, int intAttachmentClassificationID)
        {

            AttachmentTypeDb objBaseDb = new AttachmentTypeDb();
            objBaseDb.NameA = strAttachmentTypeNameA;
            objBaseDb.NameE = strAttachmentTypeNameE;
            objBaseDb.AttachmentClassification = intAttachmentClassificationID;
            objBaseDb.Add();
        }
        public static void Edit(int intAttachmentTypeID, string strAttachmentTypeNameA, string strAttachmentTypeNameE, int intAttachmentClassificationID)
        {
            AttachmentTypeDb objBaseDb = new AttachmentTypeDb();
            objBaseDb.ID = intAttachmentTypeID;
            objBaseDb.NameA = strAttachmentTypeNameA;
            objBaseDb.NameE = strAttachmentTypeNameE;
            objBaseDb.AttachmentClassification = intAttachmentClassificationID;
            objBaseDb.Edit();
        }
        public static void Delete(int intAttachmentTypeID)
        {
            AttachmentTypeDb objBaseDb = new AttachmentTypeDb();
            objBaseDb.ID = intAttachmentTypeID;
            objBaseDb.Delete();
        }
        public AttachmentTypeBiz Copy()
        {
            AttachmentTypeBiz Returned = new AttachmentTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.AttachmentClassificationBiz = this.AttachmentClassificationBiz;
            return Returned;
        }
        #endregion
    }

}