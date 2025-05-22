using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class CommentTypeBiz : BaseSingleBiz
    {

        #region Private Data
        #endregion

        #region Constractors
        public CommentTypeBiz()
        {
            _BaseDb = new CommentTypeDb();
        }
        public CommentTypeBiz(int intID)
        {
            _BaseDb = new CommentTypeDb(intID);
        }
        public CommentTypeBiz(DataRow objDR)
        {
            _BaseDb = new CommentTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((CommentTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((CommentTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CommentTypeDb)_BaseDb).Delete();
        }
        #endregion

    }
}
