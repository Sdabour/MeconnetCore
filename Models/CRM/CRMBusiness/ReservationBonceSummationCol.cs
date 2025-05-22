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
    public class ReservationBonceSummationCol : BaseCol
    {
        public ReservationBonceSummationCol(bool blIsEmpty)
        {

        }
        public ReservationBonceSummationCol()
        {

        }

        public virtual ReservationBonceSummationBiz this[int intIndex]
        {
            get
            {
                return (ReservationBonceSummationBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ReservationBonceSummationBiz objReservationBonceSummationBiz)
        {

            this.List.Add(objReservationBonceSummationBiz);
        }
    }

}
