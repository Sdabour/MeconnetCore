using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReactionTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public ReactionTypeBiz()
        {
            _BaseDb = new ReactionTypeDb();
        }
        public ReactionTypeBiz(int intID)
        {
            _BaseDb = new ReactionTypeDb(intID);
        }
        public ReactionTypeBiz(DataRow objDR)
        {
            _BaseDb = new ReactionTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((ReactionTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((ReactionTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((ReactionTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
