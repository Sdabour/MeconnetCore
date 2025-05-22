using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class SubjectBiz : BaseSelfeRelatedBiz

    {
        #region Private Data



        #endregion
        #region Constructors
        public SubjectBiz()
        {
            _BaseDb = new SubjectDb();
        }
        public SubjectBiz(int intSubjectID)
        {
            _BaseDb = new SubjectDb(intSubjectID);
        }
        public SubjectBiz(DataRow objDR)
        {
            _BaseDb = new SubjectDb(objDR);
        }

        public SubjectBiz(SubjectDb objSubjectDb)
        {
            _BaseDb = objSubjectDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((SubjectDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((SubjectDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((SubjectDb)_BaseDb).Add();
        }
        public static void Add(string strSubjectNameA, string strSubjectNameE)
        {

            SubjectDb objSubjectDb = new SubjectDb();
            objSubjectDb.NameA = strSubjectNameA;
            objSubjectDb.NameE = strSubjectNameE;

            objSubjectDb.Add();
        }
        public static void Edit(int intSubjectID, string strSubjectNameA, string strSubjectNameE)
        {
            SubjectDb objSubjectDb = new SubjectDb();
            objSubjectDb.ID = intSubjectID;
            objSubjectDb.NameA = strSubjectNameA;
            objSubjectDb.NameE = strSubjectNameE;

            objSubjectDb.Edit();
        }
        public void Edit()
        {
            ((SubjectDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((SubjectDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((SubjectDb)_BaseDb).Edit();
        }
        public static void Delete(int intSubjectID)
        {
            SubjectDb objSubjectDb = new SubjectDb();
            objSubjectDb.ID = intSubjectID;
            objSubjectDb.Delete();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public SubjectBiz Copy()
        {
            SubjectBiz Returned = new SubjectBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}
