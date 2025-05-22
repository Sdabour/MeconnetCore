using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.HR.HRDataBase;


namespace SharpVision.HR.HRBusiness
{
    public class EstimationAssignmentGroupBiz
    {

        #region Constructor
        public EstimationAssignmentGroupBiz()
        {
            _EstimationAssignmentGroupDb = new EstimationAssignmentGroupDb();
        }
        public EstimationAssignmentGroupBiz(DataRow objDr)
        {
            _EstimationAssignmentGroupDb = new EstimationAssignmentGroupDb(objDr);
            _GroupElementBiz = new GroupElementBiz(objDr);
        }

        #endregion
        #region Private Data
        EstimationAssignmentGroupDb _EstimationAssignmentGroupDb;
        #endregion
        #region Properties
        public int AssignmentID
        {
            set
            {
                _EstimationAssignmentGroupDb.AssignmentID = value;
            }
            get
            {
                return _EstimationAssignmentGroupDb.AssignmentID;
            }
        }
         int GroupElementID
        {
            set
            {
                _EstimationAssignmentGroupDb.GroupElementID = value;
            }
            get
            {
                return _EstimationAssignmentGroupDb.GroupElementID;
            }
        }
        EstimationAssignmentBiz _AssignmentBiz;
        public EstimationAssignmentBiz AssignmentBiz
        {
            set => _AssignmentBiz = value;
            get
            {
                if (_AssignmentBiz == null)
                    _AssignmentBiz = new EstimationAssignmentBiz();
                return _AssignmentBiz;
            }
        }
        GroupElementBiz _GroupElementBiz;
        public GroupElementBiz GroupElementBiz
        {
            set => _GroupElementBiz = value;
            get
            {
                if (_GroupElementBiz == null)
                    _GroupElementBiz = new GroupElementBiz();
                return _GroupElementBiz;
            }
        }
        public double Perc
        {
            set
            {
                _EstimationAssignmentGroupDb.Perc = value;
            }
            get
            {
                return _EstimationAssignmentGroupDb.Perc;
            }
        }
        public int Order
        {
            set
            {
                _EstimationAssignmentGroupDb.Order = value;
            }
            get
            {
                return _EstimationAssignmentGroupDb.Order;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EstimationAssignmentGroupDb.GroupElementID = GroupElementBiz.ID;
            _EstimationAssignmentGroupDb.Add();
        }
        public void Edit()
        {
            _EstimationAssignmentGroupDb.GroupElementID = GroupElementBiz.ID;
            _EstimationAssignmentGroupDb.Edit();
        }
        public void Delete()
        {
            _EstimationAssignmentGroupDb.Delete();
        }
        #endregion
    }
}
