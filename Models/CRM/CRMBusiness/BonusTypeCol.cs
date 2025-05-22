using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class BonusTypeCol : BaseCol
    {
        public BonusTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            BonusTypeDb objDb = new BonusTypeDb();
            
            DataTable dtTemp = objDb.Search();
            BonusTypeBiz objBiz =  new BonusTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
           
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new BonusTypeBiz(objDR));
            }

        }
        public BonusTypeCol()
        {
            BonusTypeDb objDb = new BonusTypeDb();

            DataTable dtTemp = objDb.Search();
            BonusTypeBiz objBiz = new BonusTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new BonusTypeBiz(objDR));
            }

        }
        public BonusTypeCol(int intID)
        {
            BonusTypeDb objDb = new BonusTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            BonusTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BonusTypeBiz(objDR);
                this.Add(objBiz);
            }

        }
        public virtual BonusTypeBiz this[int intIndex]
        {
            get
            {
                return (BonusTypeBiz)this.List[intIndex];
            }
        }
        public virtual void Add(BonusTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
