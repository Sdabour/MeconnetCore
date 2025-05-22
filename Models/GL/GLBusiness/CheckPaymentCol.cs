using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class CheckPaymentCol : BaseCol
    {
        public CheckPaymentCol(bool blIsempty)
        {
            if (!blIsempty)
                return;
            CheckPaymentDb objDb = new CheckPaymentDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CheckPaymentBiz(objDr));
            }
        }
        public CheckPaymentBiz this[int intIndex]
        {

            get
            {
                return (CheckPaymentBiz)List[intIndex];
            }
        }
        public void Add(CheckPaymentBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
