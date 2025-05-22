using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TicketTypeCol : BaseCol
    {
        public TicketTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            TicketTypeDb objDb = new TicketTypeDb();

            DataTable dtTemp = objDb.Search();
            TicketTypeBiz objBiz = new TicketTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new TicketTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new TicketTypeBiz(objDR));
            }

        }
        public TicketTypeCol()
        {
            TicketTypeDb objDb = new TicketTypeDb();

            DataTable dtTemp = objDb.Search();
            TicketTypeBiz objBiz = new TicketTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new TicketTypeBiz(objDR));
            }

        }
        public TicketTypeCol(int intID)
        {
            TicketTypeDb objDb = new TicketTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            TicketTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TicketTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual TicketTypeBiz this[int intIndex]
        {
            get
            {
                return (TicketTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(TicketTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public TicketTypeCol GetCol(string strCode)
        {
            TicketTypeCol Returned = new TicketTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (TicketTypeBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public TicketTypeCol Copy()
        {
            TicketTypeCol Returned = new TicketTypeCol(true);
            foreach (TicketTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
