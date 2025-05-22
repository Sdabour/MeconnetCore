using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationPeriodAmountStatisticCol : BaseCol
    {
        public ReservationPeriodAmountStatisticCol()
        {
            ReservationPeriodAmountStatisticDb objDb = new ReservationPeriodAmountStatisticDb();
            DataTable dtTemp = objDb.Search();
            ReservationPeriodAmountStatisticBiz objBiz = new ReservationPeriodAmountStatisticBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new ReservationPeriodAmountStatisticBiz(objDR));
            }

        }

        

        public ReservationPeriodAmountStatisticCol(CellBiz objCellBiz)
        {
            ReservationPeriodAmountStatisticDb objDb = new ReservationPeriodAmountStatisticDb();
            objDb.CellID = objCellBiz.ID;
            DataTable dtTemp = objDb.Search();
            ReservationPeriodAmountStatisticBiz objBiz = new ReservationPeriodAmountStatisticBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new ReservationPeriodAmountStatisticBiz(objDR));
            }
        }

        public virtual ReservationPeriodAmountStatisticBiz this[int intIndex]
        {
            get
            {
                return (ReservationPeriodAmountStatisticBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ReservationPeriodAmountStatisticBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
