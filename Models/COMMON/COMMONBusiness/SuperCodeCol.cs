using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
   public  class SuperCodeCol : BaseCol
    {
        public SuperCodeCol(bool blIsempty)
        {
            if (!blIsempty)
                return;
            SupperCodeDb objDb = new SupperCodeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SupperCodeBiz(objDr));
            }
        }
       public SuperCodeCol(int intID)
        {
            SupperCodeDb objDb = new SupperCodeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SupperCodeBiz(objDr));
            }
        }
       public SupperCodeBiz this[int intIndex]
        {

            get
            {
                return (SupperCodeBiz)List[intIndex];
            }
        }
       public void Add(SupperCodeBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
