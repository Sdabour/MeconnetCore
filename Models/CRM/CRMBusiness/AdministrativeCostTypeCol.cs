using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class AdministrativeCostTypeCol : BaseCol
    {
        public AdministrativeCostTypeCol(bool blIsEmpty)
        {
            AdministrativeCostTypeDb objDb = new AdministrativeCostTypeDb();

            DataTable dtTemp = objDb.Search();
            AdministrativeCostTypeBiz objBiz = new AdministrativeCostTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            if (!blIsEmpty)
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new AdministrativeCostTypeBiz(objDR));
            }

        }
        public AdministrativeCostTypeCol()
        {
            AdministrativeCostTypeDb objDb = new AdministrativeCostTypeDb();

            DataTable dtTemp = objDb.Search();
            AdministrativeCostTypeBiz objBiz = new AdministrativeCostTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new AdministrativeCostTypeBiz(objDR));
            }

        }
        public AdministrativeCostTypeCol(int intID)
        {
            AdministrativeCostTypeDb objDb = new AdministrativeCostTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            AdministrativeCostTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new AdministrativeCostTypeBiz(objDR);
                this.Add(objBiz);
            }

        }
        public virtual AdministrativeCostTypeBiz this[int intIndex]
        {
            get
            {
                return (AdministrativeCostTypeBiz)this.List[intIndex];
            }
        }
        public virtual void Add(AdministrativeCostTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}


