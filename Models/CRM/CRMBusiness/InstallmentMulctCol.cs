using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentMulctCol : BaseCol
    {
        public InstallmentMulctCol(bool blIsempty)
        {

        }
        public InstallmentMulctCol(int intID)
        {
            InstallmentMulctDb objDb = new InstallmentMulctDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentMulctBiz(objDr));
            }
        }

        public InstallmentMulctBiz this[int intIndex]
        {
           
            get
            {
                return (InstallmentMulctBiz)List[intIndex];
            }
        }

        public void Add(InstallmentMulctBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public double TotalMulctVal
        {
            get
            {
                double dblReturned = 0;
                foreach (InstallmentMulctBiz objBiz in this)
                {
                    dblReturned = dblReturned + objBiz.MulctValue;
                }
                return dblReturned;
            }
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("InstallmentID"), new DataColumn("Value"), new DataColumn("Reason"), new DataColumn("Date") 
            , new DataColumn("ID"), new DataColumn("Name"), new DataColumn("NameA"), new DataColumn("NameE")});
            DataRow objDr;
            foreach (InstallmentMulctBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["InstallmentID"] = objBiz.InstallmentBiz.ID;
                objDr["Value"] = objBiz.MulctValue;
                objDr["Reason"] = objBiz.ReasonBiz.ID;
                objDr["Date"] = objBiz.MulctDate;
                objDr["Name"] = objBiz.Name;
                objDr["NameA"] = objBiz.NameA;
                objDr["NameE"] = objBiz.NameE;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }

        

    }
}
