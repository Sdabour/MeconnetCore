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
    public class ReceiptBookCol : BaseCol
    {
        public ReceiptBookCol()
        {
            ReceiptBookDb objDb = new ReceiptBookDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptBookBiz(objDr));
            }
        }
        public ReceiptBookCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ReceiptBookBiz objModelBiz = new ReceiptBookBiz();
            objModelBiz.Desc = "€Ì— „Õœœ";
            Add(objModelBiz);
            ReceiptBookDb objDb = new ReceiptBookDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptBookBiz(objDr));
            }
        }


        public ReceiptBookBiz this[int intIndex]
        {

            get
            {
                return (ReceiptBookBiz)List[intIndex];
            }
        }
        public ReceiptBookBiz GetReceiptBookByID(int intID)
        {
            ReceiptBookBiz Returned = new ReceiptBookBiz();
            foreach (ReceiptBookBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    Returned = objBiz;
                    break;
                }

            }
            return Returned;
        }
        public void Add(ReceiptBookBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ReceiptBookCol GetColByDesc(string strDesc)
        {
            ReceiptBookCol Returned = new ReceiptBookCol(true);
            foreach (ReceiptBookBiz objBiz in this)
            {
                if (objBiz.Desc.IndexOf(strDesc, StringComparison.OrdinalIgnoreCase) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
