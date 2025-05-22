using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class TopicBiz : BaseSelfeRelatedBiz

    {
        #region Private Data



        #endregion
        #region Constructors
        public TopicBiz()
        {
            _BaseDb = new TopicDb();
        }
        public TopicBiz(int intTopicID)
        {
            _BaseDb = new TopicDb(intTopicID);
        }
        public TopicBiz(DataRow objDR)
        {
            _BaseDb = new TopicDb(objDR);
        }

        public TopicBiz(TopicDb objTopicDb)
        {
            _BaseDb = objTopicDb;
        }
        #endregion
        #region Public Properties
        public TopicBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
 
            }
            get
            {
                return (TopicBiz)_ParentBiz;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((TopicDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((TopicDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((TopicDb)_BaseDb).Add();
        }
        
        public void Edit()
        {
            ((TopicDb)_BaseDb).ParentID =  ParentBiz.ID == 0 ? ID : ParentBiz.ID;
            ((TopicDb)_BaseDb).FamilyID = ParentBiz.ID == 0 ? FamilyID : ParentBiz.FamilyID;
            ((TopicDb)_BaseDb).Edit();
        }
        public static void Delete(int intTopicID)
        {
            TopicDb objTopicDb = new TopicDb();
            objTopicDb.ID = intTopicID;
            objTopicDb.Delete();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public TopicBiz Copy()
        {
            TopicBiz Returned = new TopicBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.ParentBiz = ParentBiz;


            return Returned;
        }
        #endregion
    }
}
