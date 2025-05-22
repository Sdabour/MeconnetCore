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
    public class CheckInCol : BaseCol
    {
        public CheckInCol(bool blIsempty)
        {

        }
        public CheckInCol(int intID)
        {
            CheckInDb objDb = new CheckInDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CheckInBiz(objDr));
            }
        }

        public CheckInBiz this[int intIndex]
        {

            get
            {
                return (CheckInBiz)List[intIndex];
            }
        }

        public void Add(CheckInBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
