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
    public class CheckPrintCol : BaseCol
    {
        public CheckPrintCol(bool blIsempty, int intIsBankStatus)
        {
            
        }
        public CheckPrintCol()
        {
          
        }


        public CheckPrintBiz this[int intIndex]
        {

            get
            {
                return (CheckPrintBiz)List[intIndex];
            }
        }
        public void Add(CheckPrintBiz objBiz)
        {
            List.Add(objBiz);

        }
         
    }
}
