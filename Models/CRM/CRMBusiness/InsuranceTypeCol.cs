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
    public class InsuranceTypeCol : BaseCol
    {
        public InsuranceTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            InsuranceTypeDb objDb = new InsuranceTypeDb();

            DataTable dtTemp = objDb.Search();
            InsuranceTypeBiz objBiz = new InsuranceTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
           
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new InsuranceTypeBiz(objDR));
            }

        }
        public InsuranceTypeCol()
        {
            InsuranceTypeDb objDb = new InsuranceTypeDb();

            DataTable dtTemp = objDb.Search();
            InsuranceTypeBiz objBiz = new InsuranceTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new InsuranceTypeBiz(objDR));
            }

        }
        public InsuranceTypeCol(int intID)
        {
            InsuranceTypeDb objDb = new InsuranceTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            InsuranceTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new InsuranceTypeBiz(objDR);
                this.Add(objBiz);
            }

        }
        public virtual InsuranceTypeBiz this[int intIndex]
        {
            get
            {
                return (InsuranceTypeBiz)this.List[intIndex];
            }
        }
        public virtual void Add(InsuranceTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}


