using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class CompetitorCol : BaseCol
    {
        public CompetitorCol()
        {
            CompetitorDb objDb = new CompetitorDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompetitorBiz(objDr));
            }
        }
        public CompetitorCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                CompetitorBiz objBiz = new CompetitorBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                CompetitorDb objDb = new CompetitorDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new CompetitorBiz(objDr));
                }
            }
        }
        public CompetitorCol(int intID)
        {
            CompetitorDb objDb = new CompetitorDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompetitorBiz(objDr));
            }
        }
        public CompetitorBiz this[int intIndex]
        {
            get
            {
                return (CompetitorBiz)List[intIndex];
            }
        }
        #region Private Methods
        #endregion
        public void Add(CompetitorBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
