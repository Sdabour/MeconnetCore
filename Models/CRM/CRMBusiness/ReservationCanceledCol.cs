using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCanceledCol : BaseCol
    {

        public ReservationCanceledCol()
        {
            ReservationCanceledBiz objBiz;
            objBiz = new ReservationCanceledBiz();
            ReservationCanceledDb objDb = new ReservationCanceledDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationCanceledBiz(objDr));
            }
        }


         public ReservationCanceledBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationCanceledBiz)List[intIndex];
            }
        }

        public void Add(ReservationCanceledBiz objBiz)
        {
            List.Add(objBiz);
 
        }

    }
}
