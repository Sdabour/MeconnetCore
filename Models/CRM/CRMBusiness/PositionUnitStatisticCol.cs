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
    public class PositionUnitStatisticCol : BaseCol
    {

        public PositionUnitStatisticCol()
        {
            PositionUnitStatisticDb objDb = new PositionUnitStatisticDb();

            DataTable dtTemp = objDb.Search();
            PositionUnitStatisticBiz objBiz = new PositionUnitStatisticBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new PositionUnitStatisticBiz(objDR));
            }

        }
        public virtual PositionUnitStatisticBiz this[int intIndex]
        {
            get
            {
                return (PositionUnitStatisticBiz)this.List[intIndex];
            }
        }
        public virtual void Add(PositionUnitStatisticBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
