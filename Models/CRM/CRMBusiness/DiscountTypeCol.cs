using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class DiscountTypeCol : BaseCol
    {
        public DiscountTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            DiscountTypeDb objDb = new DiscountTypeDb();
            
            DataTable dtTemp = objDb.Search();
            DiscountTypeBiz objBiz =  new DiscountTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            if (!blIsEmpty)
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new DiscountTypeBiz(objDR));
            }

        }
        public DiscountTypeCol()
        {
            DiscountTypeDb objDb = new DiscountTypeDb();

            DataTable dtTemp = objDb.Search();
            DiscountTypeBiz objBiz = new DiscountTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new DiscountTypeBiz(objDR));
            }
        }
        public DiscountTypeCol(int intID)
        {
            DiscountTypeDb objDb = new DiscountTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            DiscountTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new DiscountTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual DiscountTypeBiz this[int intIndex]
        {
            get
            {
                return (DiscountTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(DiscountTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
