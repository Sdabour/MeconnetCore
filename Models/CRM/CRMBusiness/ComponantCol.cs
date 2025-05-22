using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ComponantCol : BaseCol
    {
        public ComponantCol()
        {
            ComponantDb objDb = new ComponantDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ComponantBiz(objDr));
            }
        }
        public ComponantCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                ComponantBiz objBiz = new ComponantBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                ComponantDb objDb = new ComponantDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new ComponantBiz(objDr));
                }
            }
        }
        public ComponantCol(int intID)
        {
            ComponantDb objDb = new ComponantDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ComponantBiz(objDr));
            }
        }

        public ComponantBiz this[int intIndex]
        {

            get
            {
                return (ComponantBiz)List[intIndex];
            }
        }

        public void Add(ComponantBiz objBiz)
        {
            List.Add(objBiz);

        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("NameA"), new DataColumn("NameE"), new DataColumn("Name") });
            DataRow objDr;
            foreach (ComponantBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["Name"] = objBiz.Name;
                objDr["NameA"] = objBiz.NameA;
                objDr["NameE"] = objBiz.NameE;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
    }
}
