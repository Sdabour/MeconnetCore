using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class TicketStatusCol :BaseCol
    {
        public TicketStatusCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;

            TicketStatusBiz objBiz;
            objBiz = new TicketStatusBiz();
            objBiz.ID = 0;
            objBiz.Desc = "غير محدد";

            TicketStatusDb objDb = new TicketStatusDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TicketStatusBiz(objDr));
            }
        }
        public TicketStatusCol()
        {

        }

        public  TicketStatusBiz this[int intIndex]
        {
            get
            {
                return (TicketStatusBiz)this.List[intIndex];
            }
        }

        public  void Add(TicketStatusBiz objTicketStatusBiz)
        {

            this.List.Add(objTicketStatusBiz);
        }

    }
}
