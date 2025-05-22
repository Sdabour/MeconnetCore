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
    public class OriginStatementBonusCol : BaseCol
    {
        public OriginStatementBonusCol(bool blIsempty)
        {

        }

        public OriginStatementBonusCol(int intID)
        {
            OriginStatementBonusDb objDb = new OriginStatementBonusDb();
            objDb.OriginStatement = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new OriginStatementBonusBiz(objDr));
            }
        }

        public OriginStatementBonusBiz this[int intIndex]
        {

            get
            {
                return (OriginStatementBonusBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (OriginStatementBonusBiz objBiz in this)
                    Returned += objBiz.Value;
                return Returned;
            }
        }
        public string DescBonus
        {
            get
            {
                string Returned = "";
                foreach (OriginStatementBonusBiz objBiz in this)
                {
                    if(objBiz.Desc!="")
                    Returned += objBiz.Desc + "\n\r";
                }
                return Returned;
            }
        }
        public double IncreaseValue
        {
            get
            {
                foreach (OriginStatementBonusBiz objBiz in this)
                {
                    if (objBiz.Desc.IndexOf("ÚáÇæ") != -1)
                    {
                        return objBiz.Value;
                    }

                }
                return 0;
            }
        }
        public void Add(OriginStatementBonusBiz objBiz)
        {
            List.Add(objBiz);

        }
        public int GetIndex(string strDesc)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].Desc == strDesc)
                    return intIndex;
            }
            return -1;
        }
        public DataTable GetTable()
        {
            return GetTable("Bonus");
        }
        public DataTable GetTable(string strTableName)
        {
            DataTable Returned = new DataTable(strTableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("OriginStatement"),new DataColumn("BonusDesc")
                ,new DataColumn("BonusValue"),new DataColumn("BonusDate")});
            DataRow objDr;
            foreach (OriginStatementBonusBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["OriginStatement"] = objBiz.OriginStatement;
                objDr["BonusDesc"] = objBiz.Desc;
                objDr["BonusValue"] = objBiz.Value;
                objDr["BonusDate"] = objBiz.Date;
                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
    }
}
