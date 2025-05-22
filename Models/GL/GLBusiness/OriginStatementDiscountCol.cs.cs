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
    public class OriginStatementDiscountCol : BaseCol
    {
        public OriginStatementDiscountCol(bool blIsempty)
        {

        }

        public OriginStatementDiscountCol(int intID)
        {
            OriginStatementDiscountDb objDb = new OriginStatementDiscountDb();
            objDb.OriginStatement = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new OriginStatementDiscountBiz(objDr));
            }
        }

        public OriginStatementDiscountBiz this[int intIndex]
        {

            get
            {
                return (OriginStatementDiscountBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (OriginStatementDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public string DescDiscount
        {
            get
            {
                string Returned = "";
                foreach (OriginStatementDiscountBiz objBiz in this)
                    if (objBiz.Desc != "")
                        Returned += objBiz.Desc + "\n\r";
                return Returned;
            }
        }
        public void Add(OriginStatementDiscountBiz objBiz)
        {
            List.Add(objBiz);

        }
        public DataTable GetTable()
        {
            return GetTable("Discount");
        }
        public DataTable GetTable(string strTableName)
        {
            DataTable Returned = new DataTable(strTableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("OriginStatement"),new DataColumn("DiscountDesc")
                ,new DataColumn("DiscountValue"),new DataColumn("DiscountDate")});
            DataRow objDr;
            foreach (OriginStatementDiscountBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["OriginStatement"] = objBiz.OriginStatement;
                objDr["DiscountDesc"] = objBiz.Desc;
                objDr["DiscountValue"] = objBiz.Value;
                objDr["DiscountDate"] = objBiz.Date;
                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
    }
}
