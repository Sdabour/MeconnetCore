using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class SalesManVisitStatisticBiz
    {
        #region Private Data
        SalesManBiz _SalesManBiz;
        BranchBiz _BranchBiz;
        VisitCol _VisitCol;               
        #endregion
        #region Constructors
        public SalesManVisitStatisticBiz()
        {
            _SalesManBiz = new SalesManBiz();
            _BranchBiz = new BranchBiz();
            _VisitCol = new VisitCol(true);
        }
        #endregion
        #region Public Properties
        public SalesManBiz SalesManBiz { set { _SalesManBiz = value; } get { return _SalesManBiz; } }
        public BranchBiz BranchBiz { set { _BranchBiz = value; } get { return _BranchBiz; } }
        public VisitCol VisitCol { set { _VisitCol = value; } get { return _VisitCol; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
