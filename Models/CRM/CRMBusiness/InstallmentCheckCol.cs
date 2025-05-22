using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentCheckCol  : BaseCol
    {
        
          public InstallmentCheckCol(bool blIsempty)
        {

        }
        public InstallmentCheckCol(int intID)
        {
            InstallmentCheckDb objDb = new InstallmentCheckDb();
            objDb.CheckID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentCheckBiz(objDr));
            }
        }

        public InstallmentCheckBiz this[int intIndex]
        {

            get
            {
                return (InstallmentCheckBiz)List[intIndex];
            }
        }

        public void Add(InstallmentCheckBiz objBiz)
        {
            List.Add(objBiz);

        } 
         
    }
}
