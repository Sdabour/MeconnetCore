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
    public class VisitStatusCol : BaseCol
    {
        public VisitStatusCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;

            VisitStatusBiz objBiz;
            objBiz = new VisitStatusBiz();
            objBiz.ID = 0;
            objBiz.Desc = "غير محدد";

            VisitStatusDb objDb = new VisitStatusDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new VisitStatusBiz(objDr));
            }
        }
        public VisitStatusCol()
        {

        }

        public VisitStatusBiz this[int intIndex]
        {
            get
            {
                return (VisitStatusBiz)this.List[intIndex];
            }
        }

        public void Add(VisitStatusBiz objVisitStatusBiz)
        {

            this.List.Add(objVisitStatusBiz);
        }

    }
}

