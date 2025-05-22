using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class VisitTypeBiz : BaseSelfeRelatedBiz

    {
        #region Private Data



        #endregion
        #region Constructors
        public VisitTypeBiz()
        {
            _BaseDb = new VisitTypeDb();
        }
        public VisitTypeBiz(int intVisitTypeID)
        {
            _BaseDb = new VisitTypeDb(intVisitTypeID);
        }
        public VisitTypeBiz(DataRow objDR)
        {
            _BaseDb = new VisitTypeDb(objDR);

            if (((VisitTypeDb)_BaseDb).WorkGroup != 0)
            {
                _WorkGroupBiz = new WorkGroupBiz() { ID = ((VisitTypeDb)_BaseDb).WorkGroup, NameA = ((VisitTypeDb)_BaseDb).WorkGroupNameA, NameE = ((VisitTypeDb)_BaseDb).WorkGroupNameE };

            }
        }

        public VisitTypeBiz(VisitTypeDb objVisitTypeDb)
        {
            _BaseDb = objVisitTypeDb;
        }
        #endregion
        #region Public Properties
        WorkGroupBiz _WorkGroupBiz;
        public WorkGroupBiz WorkGroupBiz
        {
            set => _WorkGroupBiz = value;
            get
            {
                if (_WorkGroupBiz == null)
                    _WorkGroupBiz = new WorkGroupBiz();
                return _WorkGroupBiz;
            }
        }
        public VisitTypeBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;

            }
            get
            {
                return (VisitTypeBiz)_ParentBiz;
            }

        }
        public VisitTypeCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                    _Children = new VisitTypeCol(true);
                return (VisitTypeCol)_Children;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((VisitTypeDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((VisitTypeDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((VisitTypeDb)_BaseDb).WorkGroup = WorkGroupBiz.ID;
            ((VisitTypeDb)_BaseDb).Add();
        }

        public void Edit()
        {
            ((VisitTypeDb)_BaseDb).ParentID = ParentBiz.ID == 0 ? ID : ParentBiz.ID;
            ((VisitTypeDb)_BaseDb).FamilyID = ParentBiz.ID == 0 ? FamilyID : ParentBiz.FamilyID;
            ((VisitTypeDb)_BaseDb).WorkGroup = WorkGroupBiz.ID;
            ((VisitTypeDb)_BaseDb).Edit();
        }
        public static void Delete(int intVisitTypeID)
        {
            VisitTypeDb objVisitTypeDb = new VisitTypeDb();
            objVisitTypeDb.ID = intVisitTypeID;
            objVisitTypeDb.Delete();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public VisitTypeBiz Copy()
        {
            VisitTypeBiz Returned = new VisitTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.ParentBiz = ParentBiz;


            return Returned;
        }
        #endregion
    }
}
