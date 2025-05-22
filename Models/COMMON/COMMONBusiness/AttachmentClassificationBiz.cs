using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentClassificationBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public AttachmentClassificationBiz()
        {
            _BaseDb = new AttachmentClassificationDb();
        }
        public AttachmentClassificationBiz(int intID)
        {
            _BaseDb = new AttachmentClassificationDb(intID);

        }
        public AttachmentClassificationBiz(DataRow objDR)
        {
            _BaseDb = new AttachmentClassificationDb(objDR);

        }
        public AttachmentClassificationBiz(AttachmentClassificationDb objDb)
        {
            _BaseDb = objDb;
        }

        #endregion
        #region Public Properties
        #endregion
        #region Public Methods

        public static void Add(string strNameA, string strNameE)
        {
            AttachmentClassificationDb objDb = new AttachmentClassificationDb();
            objDb.NameA = strNameA;
            objDb.NameE = strNameE;
            objDb.Add();

        }
        public static void Edit(int intDegreeID, string strNameA, string strNameE)
        {
            AttachmentClassificationDb objDb = new AttachmentClassificationDb();
            objDb.ID = intDegreeID;
            objDb.NameA = strNameA;
            objDb.NameE = strNameE;
            objDb.Edit();

        }
        public static void Delete(int intDegreeID)
        {
            AttachmentClassificationDb objDb = new AttachmentClassificationDb();
            objDb.ID = intDegreeID;
            objDb.Delete();
        }
        public AttachmentClassificationBiz Copy()
        {
            AttachmentClassificationBiz Returned = new AttachmentClassificationBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}
