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
    public class ReceiptCol : BaseCol
    {
        public ReceiptCol()
        {
            ReceiptDb objDb = new ReceiptDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptBiz(objDr));
            }
        }
        public ReceiptCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ReceiptBiz objModelBiz = new ReceiptBiz();
            objModelBiz.Desc = "€Ì— „Õœœ";
            Add(objModelBiz);
            ReceiptDb objDb = new ReceiptDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptBiz(objDr));
            }
        }


        public ReceiptBiz this[int intIndex]
        {

            get
            {
                return (ReceiptBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ReceiptBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += "";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public ReceiptBiz GetReceiptByID(int intID)
        {
            ReceiptBiz Returned = new ReceiptBiz();
            foreach (ReceiptBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    Returned = objBiz;
                    break;
                }

            }
            return Returned;
        }
        public void Add(ReceiptBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ReceiptCol GetColByDesc(string strDesc)
        {
            ReceiptCol Returned = new ReceiptCol(true);
            foreach (ReceiptBiz objBiz in this)
            {
                if (objBiz.Desc.IndexOf(strDesc, StringComparison.OrdinalIgnoreCase) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public void EditStatus(ReceiptStatus objStatus)
        {
            ReceiptDb objDb = new ReceiptDb();
            objDb.IDsStr = IDsStr;
            objDb.Status = (int)objStatus;
            objDb.EditStatus();
        }
    }
}
