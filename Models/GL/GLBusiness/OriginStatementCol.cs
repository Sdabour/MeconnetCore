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
    public class OriginStatementCol : BaseCol
    {


         public OriginStatementCol(bool blIsempty)
         {

         }
        public OriginStatementCol(int intID)
        {
            OriginStatementDb objDb = new OriginStatementDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new OriginStatementBiz(objDr));
            }
        }


         public OriginStatementBiz this[int intIndex]
          {

            get
            {
                return (OriginStatementBiz)List[intIndex];
            }
          }

        public void Add(OriginStatementBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
