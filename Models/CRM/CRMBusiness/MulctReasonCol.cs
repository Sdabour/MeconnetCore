using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class MulctReasonCol : BaseCol
    {
        public MulctReasonCol(bool blIsempty)
        {
            MulctReasonBiz objBiz;
            objBiz = new MulctReasonBiz();
            objBiz.ID = 0;
            objBiz.Desc = "€Ì— „Õœœ";

            MulctReasonDb objDb = new MulctReasonDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new MulctReasonBiz(objDr));
            }
        }
        public MulctReasonCol(int intID)
        {
            MulctReasonDb objDb = new MulctReasonDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new MulctReasonBiz(objDr));
            }
        }
       
        public MulctReasonBiz this[int intIndex]
        {
           
            get
            {
                return (MulctReasonBiz)List[intIndex];
            }
        }

        public void Add(MulctReasonBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
