using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.HR.HRDataBase;


namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatetmentGroupBiz
    {

        #region Constructor
        public EstimationStatetmentGroupBiz()
        {
            _EstimationStatetmentGroupDb = new EstimationStatetmentGroupDb();
        }
        public EstimationStatetmentGroupBiz(DataRow objDr)
        {
            _EstimationStatetmentGroupDb = new EstimationStatetmentGroupDb(objDr);
            _GroupElementBiz = new GroupElementBiz(objDr);
        }

        #endregion
        #region Private Data
        EstimationStatetmentGroupDb _EstimationStatetmentGroupDb;
        #endregion
        #region Properties
        public int StatementID
        {
            set
            {
                _EstimationStatetmentGroupDb.StatementID = value;
            }
            get
            {
                return _EstimationStatetmentGroupDb.StatementID;
            }
        }
        public int GroupElementID
        {
            set
            {
                _EstimationStatetmentGroupDb.GroupElementID = value;
            }
            get
            {
                return _EstimationStatetmentGroupDb.GroupElementID;
            }
        }
        EstimationStatementBiz _StatementBiz;
        public EstimationStatementBiz StatementBiz
        {
            set => _StatementBiz = value;
            get
            {
                if (_StatementBiz == null)
                    _StatementBiz = new EstimationStatementBiz();
                return _StatementBiz;
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
                _EstimationStatetmentGroupDb.Perc = value;
            }
            get
            {
                return _EstimationStatetmentGroupDb.Perc;
            }
        }
        public int Order
        {
            set
            {
                _EstimationStatetmentGroupDb.Order = value;
            }
            get
            {
                return _EstimationStatetmentGroupDb.Order;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            
            _EstimationStatetmentGroupDb.Add();
        }
        public void Edit()
        {
            _EstimationStatetmentGroupDb.Edit();
        }
        public void Delete()
        {
            _EstimationStatetmentGroupDb.Delete();
        }
        #endregion
    }
}
