using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    class CellMultiplicandCol : BaseCol
    {
        public CellMultiplicandCol(bool blIsEmpty)
        {
      
        }
        public CellMultiplicandCol()
        { 

        }
        
        public virtual CellMultiplicandBiz this[int intIndex]
        {
            get
            {
                return (CellMultiplicandBiz)this.List[intIndex];
            }
        }

        public virtual void Add(CellMultiplicandBiz objCellMultiplicandBiz)
        {

            this.List.Add(objCellMultiplicandBiz);
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("Amount"), new DataColumn("Period"), new DataColumn("YearlyToMonthly"), new DataColumn("Cell") });
            DataRow objDr;
            foreach (CellMultiplicandBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["Amount"] = objBiz.PeriodAmount;
                objDr["Period"] = objBiz.Period;
                objDr["YearlyToMonthly"] = objBiz.YearlyToMonthly;
                objDr["Cell"] = objBiz.CellBiz.ID;

                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }

    }
}
