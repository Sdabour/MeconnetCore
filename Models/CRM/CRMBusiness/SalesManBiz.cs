using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.HR.HRBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class SalesManBiz : EmployeeBiz
    {
        #region Private Data
        
        BranchBiz _BranchBiz ;
        #endregion

        #region Constractors
        
        public SalesManBiz()
        {
            _EmployeeDb = new SalesManDb();
        }
        public SalesManBiz(DataRow objDR) : base(objDR)
        {
            
            _EmployeeDb = new SalesManDb(objDR);
            _BranchBiz = new BranchBiz(objDR);
           // base.UserBiz = new UserBiz(base.User);
        }
        //public SalesManBiz(int intSalesManID)
        //    : base(intSalesManID)
        //{
        //    _ApplicantDb = new SalesManDb(intSalesManID);
        //    //_BranchBiz = new BranchBiz(_ApplicantDb.BranchID);
        //}
       
        #endregion

        #region Public Accessorice
        public int BranchID
        {
            set
            {
                ((SalesManDb)_EmployeeDb).BranchID = value;
            }
            get
            {
                return ((SalesManDb)_EmployeeDb).BranchID;
            }
        }
        public bool IsSectorAdmin
        {
            set
            {
                ((SalesManDb)_EmployeeDb).IsSectorAdmin = value;
            }
            get
            {
                return ((SalesManDb)_EmployeeDb).IsSectorAdmin;
            }
        }
        public BranchBiz BranchBiz 
        {
            set
            {
                if (_BranchBiz == null)
                    _BranchBiz = new BranchBiz();
                _BranchBiz = value;
            }
            get
            {
                return _BranchBiz;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public override void Add()
        {
            ((SalesManDb)_EmployeeDb).BranchID = BranchBiz.ID;
            ((SalesManDb)_EmployeeDb).Add();
            
        }
        public override void Edit()
        {
            ((SalesManDb)_EmployeeDb).BranchID = BranchBiz.ID;
            ((SalesManDb)_EmployeeDb).Edit();
        }
        public override void Delete()
        {
            ((SalesManDb)_EmployeeDb).Delete();
        }
        #endregion

    }
}
