using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationReceiptCol : BaseCol
    {
        public ReservationReceiptCol()
        {
           ReceiptDb objDb = new ReceiptDb();
             
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationReceiptBiz(objDr));
            }
        }
        public ReservationReceiptCol(string strSerial, int intBranch,int intEmployee,int intStatus,bool blIsDateRange,
            DateTime dtStart,DateTime dtEnd,string strUnit,string strBeneficiary)
        {
            ReceiptDb objDb = new ReceiptDb();
            objDb.Branch = intBranch;
            objDb.Editor = intEmployee;
            objDb.Status = intStatus;
            objDb.IsDateRange = blIsDateRange;
            objDb.StartDate = dtStart;
            objDb.EndDate = dtEnd;
            objDb.Serial = strSerial;
            objDb.Unit = strUnit;
            objDb.Beneficiary = strBeneficiary;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationReceiptBiz(objDr));
            }
        }
        public ReservationReceiptCol(bool blIsempty)
        {
            if (blIsempty)
                return;
       
        }


        public ReservationReceiptBiz this[int intIndex]
        {

            get
            {
                return (ReservationReceiptBiz)List[intIndex];
            }
        }
        public ReservationReceiptBiz GetReservationReceiptByID(int intID)
        {
            ReservationReceiptBiz Returned = new ReservationReceiptBiz();
            foreach (ReservationReceiptBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    Returned = objBiz;
                    break;
                }

            }
            return Returned;
        }
        public void Add(ReservationReceiptBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ReservationReceiptCol GetColByDesc(string strDesc)
        {
            ReservationReceiptCol Returned = new ReservationReceiptCol(true);
            foreach (ReservationReceiptBiz objBiz in this)
            {
                if (objBiz.Desc.IndexOf(strDesc, StringComparison.OrdinalIgnoreCase) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
