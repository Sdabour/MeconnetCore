using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class CompetitorProejctCol : BaseCol
    {
         public CompetitorProejctCol()
        {
            CompetitorProjectDb objDb = new CompetitorProjectDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompetitorProejctBiz(objDr));
            }
        }
        public CompetitorProejctCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                CompetitorProejctBiz objBiz = new CompetitorProejctBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                CompetitorProjectDb objDb = new CompetitorProjectDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new CompetitorProejctBiz(objDr));
                }
            }
        }
        public CompetitorProejctCol(int intID)
        {
            CompetitorProjectDb objDb = new CompetitorProjectDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CompetitorProejctBiz(objDr));
            }
        }

        public CompetitorProejctBiz this[int intIndex]
        {

            get
            {
                return (CompetitorProejctBiz)List[intIndex];
            }
        }

        public void Add(CompetitorProejctBiz objBiz)
        {
            List.Add(objBiz);

        }

        
    }
}
