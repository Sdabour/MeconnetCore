using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ModelComponantCol : BaseCol
    {
        public ModelComponantCol(bool blIsempty)
        {

        }


        public ModelComponantBiz this[int intIndex]
        {

            get
            {
                return (ModelComponantBiz)List[intIndex];
            }
        }

        public void Add(ModelComponantBiz objBiz)
        {
            List.Add(objBiz);

        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("Model"),
                new DataColumn("Componant"), new DataColumn("No"), new DataColumn("Length"), new DataColumn("Width") });
            DataRow objDr;
            foreach (ModelComponantBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();

                objDr["Model"] = objBiz.ModelBiz.ID;
                objDr["Componant"] = objBiz.ComponantBiz.ID;
                objDr["No"] = objBiz.No;
                objDr["Length"] = objBiz.Length;
                objDr["Width"] = objBiz.Width;

                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }

    }
}