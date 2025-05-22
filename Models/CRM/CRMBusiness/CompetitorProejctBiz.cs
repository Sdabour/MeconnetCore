using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class  CompetitorProejctBiz : BaseSingleBiz
    {
        #region Private Data
        CompetitorBiz _CompetitorBiz;
        #endregion
        #region Constractors
         public CompetitorProejctBiz()
        {
            _BaseDb = new CompetitorProjectDb();
        }
        public CompetitorProejctBiz(int intID)
        {
            _BaseDb = new CompetitorProjectDb(intID);
        }
        public CompetitorProejctBiz(DataRow objDR)
        {
            _BaseDb = new CompetitorProjectDb(objDR);
            _CompetitorBiz = new CompetitorBiz(objDR);
        }
        #endregion
        #region Public Accessorice
        public CompetitorBiz CompetitorBiz
        {
            set
            {
                _CompetitorBiz = value;
            }
            get
            {
                return _CompetitorBiz;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            if (_CompetitorBiz == null)
                _CompetitorBiz = new CompetitorBiz();
            ((CompetitorProjectDb)_BaseDb).CompetitorID = _CompetitorBiz.ID;
            ((CompetitorProjectDb)_BaseDb).Add();
        }
        public void Edit()
        {
            if (_CompetitorBiz == null)
                _CompetitorBiz = new CompetitorBiz();
            ((CompetitorProjectDb)_BaseDb).CompetitorID = _CompetitorBiz.ID;
            ((CompetitorProjectDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CompetitorProjectDb)_BaseDb).Delete();
        }
        #endregion
    }
}
