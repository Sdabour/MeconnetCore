using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class StrategyCol : BaseCol
    {
        public StrategyCol(bool blIsempty)
        {

        }
        public StrategyCol(int intID)
        {
            StrategyDb objDb = new StrategyDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new StrategyBiz(objDr));
            }
        }

        public StrategyBiz this[int intIndex]
        {
           
            get
            {
                return (StrategyBiz)List[intIndex];
            }
        }

        public void Add(StrategyBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
