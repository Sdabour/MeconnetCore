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
    public class FinancialStatmentTypeCol : BaseCol
    {
        public FinancialStatmentTypeCol(bool blIsempty)
        {
           FinancialStatmentTypeDb objDb = new FinancialStatmentTypeDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialStatmentTypeBiz(objDr));
            }
        }
        public FinancialStatmentTypeCol(int intID)
        {
            FinancialStatmentTypeDb objDb = new FinancialStatmentTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FinancialStatmentTypeBiz(objDr));
            }
        }

        public FinancialStatmentTypeBiz this[int intIndex]
        {

            get
            {
                return (FinancialStatmentTypeBiz)List[intIndex];
            }
        }

        public void Add(FinancialStatmentTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
