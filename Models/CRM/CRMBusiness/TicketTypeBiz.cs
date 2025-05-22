using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TicketTypeBiz : BaseSingleBiz
    {
        #region Private Data
        #endregion

        #region Constractors
        public TicketTypeBiz()
        {
            _BaseDb = new TicketTypeDb();
        }
        public TicketTypeBiz(int intID)
        {
            _BaseDb = new TicketTypeDb(intID);
        }
        public TicketTypeBiz(DataRow objDR)
        {
            _BaseDb = new TicketTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((TicketTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((TicketTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((TicketTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
