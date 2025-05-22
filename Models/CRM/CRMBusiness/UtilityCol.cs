using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class UtilityCol : BaseCol
    {
        public UtilityCol(bool blIsempty)
        {

        }
        public UtilityCol()
        {
            UtilityDb objDb = new UtilityDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UtilityBiz(objDr));
            }
        }
        public UtilityCol(int intID)
        {
            UtilityDb objDb = new UtilityDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UtilityBiz(objDr));
            }
        }

        public UtilityBiz this[int intIndex]
        {
           
            get
            {
                return (UtilityBiz)List[intIndex];
            }
        }

        public void Add(UtilityBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}