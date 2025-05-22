using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.HR.HRDataBase;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
   public  class EstimationAssignmentElementBiz
    {

        #region Constructor
        public EstimationAssignmentElementBiz()
        {
            _EstimationAssignmentElementDb = new EstimationAssignmentElementDb();
        }
        public EstimationAssignmentElementBiz(DataRow objDr)
        {
            _EstimationAssignmentElementDb = new EstimationAssignmentElementDb(objDr);
            _ElementBiz = new ElementBiz(objDr);
        }

        #endregion
        #region Private Data
        EstimationAssignmentElementDb _EstimationAssignmentElementDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EstimationAssignmentElementDb.ID = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ID;
            }
        }
        //public int ElementID
        //{
        //    set
        //    {
        //        _EstimationAssignmentElementDb.ElementID = value;
        //    }
        //    get
        //    {
        //        return _EstimationAssignmentElementDb.ElementID;
        //    }
        //}
        ElementBiz _ElementBiz;
        public ElementBiz ElementBiz
        {
            set => _ElementBiz = value;
            get
            {
                if (_ElementBiz == null)
                    _ElementBiz = new ElementBiz();
                return _ElementBiz;
            }
        }
        public int ElementGroup
        {
            set
            {
                _EstimationAssignmentElementDb.ElementGroup = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementGroup;
            }
        }
        public double ElementGroupPerc
        {
            set
            {
                _EstimationAssignmentElementDb.ElementGroupPerc = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementGroupPerc;
            }
        }
        public int ElementGroupOrder
        {
            set
            {
                _EstimationAssignmentElementDb.ElementGroupOrder = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementGroupOrder;
            }
        }
        public double ElementWeight
        {
            set
            {
                _EstimationAssignmentElementDb.ElementWeight = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementWeight;
            }
        }
        public bool ElementIsFuzzy
        {
            set
            {
                _EstimationAssignmentElementDb.ElementIsFuzzy = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementIsFuzzy;
            }
        }
        public double ElementValue
        {
            set
            {
                _EstimationAssignmentElementDb.ElementValue = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementValue;
            }
        }
        public int ElementOrder
        {
            set
            {
                _EstimationAssignmentElementDb.ElementOrder = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.ElementOrder;
            }
        }
        GroupElementBiz _GroupBiz;
        public GroupElementBiz GroupBiz
        {
            set => _GroupBiz = value;
            get
            {
                if (_GroupBiz == null)
                {
                    _GroupBiz = new GroupElementBiz() { ID = GroupElelemntID, NameA = GroupElementNameA, NameE = GroupElementNameE, Code = GroupElementCode };
                }
                return _GroupBiz;

            }
        }
         int GroupElelemntID
        {
            set
            {
                _EstimationAssignmentElementDb.GroupElelemntID = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.GroupElelemntID;
            }
        }
        string GroupElementCode
        {
            set
            {
                _EstimationAssignmentElementDb.GroupElementCode = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.GroupElementCode;
            }
        }
         string GroupElementNameA
        {
            set
            {
                _EstimationAssignmentElementDb.GroupElementNameA = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.GroupElementNameA;
            }
        }
        string GroupElementNameE
        {
            set
            {
                _EstimationAssignmentElementDb.GroupElementNameE = value;
            }
            get
            {
                return _EstimationAssignmentElementDb.GroupElementNameE;
            }
        }
        public ApplicantWorkerEstimationStatementElementBiz ApplicantWorkerEstimationStatementElementBiz
        {
            get
            {
                ApplicantWorkerEstimationStatementElementBiz Returned = new ApplicantWorkerEstimationStatementElementBiz() {ElementBiz=ElementBiz,Desc="",ElementValue=ElementValue, Group=GroupBiz.ID,EstimationValue=0,GroupOrder=ElementGroupOrder,GroupPerc=ElementGroupPerc,IsFuzzyValue =ElementIsFuzzy,Weight=ElementWeight,GroupNameA=GroupElementNameA,GroupNameE=GroupElementNameE};
                Returned.ElementBiz.GroupBiz = GroupBiz;
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EstimationAssignmentElementDb.Add();
        }
        public void Edit()
        {
            _EstimationAssignmentElementDb.Edit();
        }
        public void Delete()
        {
            _EstimationAssignmentElementDb.Delete();
        }
        #endregion
    }
}
