using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
   public class FinancialStatementCol : BaseCol
    {
       public FinancialStatementCol(bool blIsempty)
        {

        }
        public FinancialStatementCol(int intID)
        {
            FinancialStatementDb objDb = new FinancialStatementDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialStatementBiz(objDr));
            }
        }

        public FinancialStatementBiz this[int intIndex]
        {

            get
            {
                return (FinancialStatementBiz)List[intIndex];
            }
        }

        public void Add(FinancialStatementBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
