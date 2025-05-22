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
    public class BranchVisitStatisticBiz
    {
        #region Private Data        
        BranchBiz _BranchBiz;
        VisitCol _VisitCol;
        SalesManVisitStatisticCol _SalesManVisitStatisticCol;       
        #endregion
        #region Constructors
        public BranchVisitStatisticBiz()
        {            
            _BranchBiz = new BranchBiz();
            _VisitCol = new VisitCol(true);
            _SalesManVisitStatisticCol = new SalesManVisitStatisticCol();
        }
        #endregion
        #region Public Properties        
        public BranchBiz BranchBiz { set { _BranchBiz = value; } get { return _BranchBiz; } }
        public VisitCol VisitCol { set { _VisitCol = value; } get { return _VisitCol; } }
        public SalesManVisitStatisticCol SalesManVisitStatisticCol { set { _SalesManVisitStatisticCol = value; } get { return _SalesManVisitStatisticCol; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
