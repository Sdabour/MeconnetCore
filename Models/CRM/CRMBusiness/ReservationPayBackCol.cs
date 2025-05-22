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
    public class ReservationPayBackCol : BaseCol
    {


        public ReservationPayBackCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ReservationPayBackBiz objBiz;
            objBiz = new ReservationPayBackBiz();
            ReservationPayBackDb objDb = new ReservationPayBackDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationPayBackBiz(objDr));
            }
        }

       public ReservationPayBackCol()
        {
            ReservationPayBackBiz objBiz;
            objBiz = new ReservationPayBackBiz();
            ReservationPayBackDb objDb = new ReservationPayBackDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationPayBackBiz(objDr));
            }
        }

        public ReservationPayBackCol(int intID)
        {
            ReservationPayBackBiz objBiz;
            objBiz = new ReservationPayBackBiz();
            ReservationPayBackDb objDb = new ReservationPayBackDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationPayBackBiz(objDr));
            }
        }

        public ReservationPayBackBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationPayBackBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationPayBackBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalPaidValue
        {
            get
            {
                double Returned = 0;
                double dblTemp = 0;
                foreach (ReservationPayBackBiz objBiz in this)
                {
                    dblTemp = 0;
                    if(objBiz.CheckBiz.ID == 0 || objBiz.CheckBiz.Status == GL.GLBusiness.CheckStatus.Collected || objBiz.IsCollected)
                        dblTemp= objBiz.Value;
                    Returned += dblTemp;
                }
                return Returned;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                double dblTemp = 0;
                foreach (ReservationPayBackBiz objBiz in this)
                {
                    dblTemp = 0;
                    if (objBiz.CheckBiz.ID != 0 && objBiz.CheckBiz.Status != GL.GLBusiness.CheckStatus.Collected && !objBiz.IsCollected)
                        dblTemp = objBiz.Value;
                    Returned += dblTemp;
                }
                return Returned;
            }
        }
        public bool CheckValue(ReservationPayBackBiz objBiz)
        {
            int intIndex = GetIndexByID(objBiz.ID);
            double dblPaybackValue = TotalValue;

            if (intIndex == -1)
            {
                //Add(objBiz);
                dblPaybackValue += objBiz.Value;

            }
            else
            {
                dblPaybackValue -= this[intIndex].Value;
                dblPaybackValue += objBiz.Value;
            }
            double dblTotalValue = objBiz.ReservationBiz.VirtualPracticalTotalPaidValue;
         //   dblTotalValue -= objBiz.ReservationBiz.CancelationBiz.Cost;
            dblTotalValue -= objBiz.ReservationBiz.CancelationBiz.Cost;
            if (dblTotalValue < dblPaybackValue)
                return false;
            else
                return true;

 
        }
        public int GetIndexByID(int intID)
        {
            int intIndex = 0;
            foreach (ReservationPayBackBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                    return intIndex;

                intIndex++;

            }
            return -1;
        }
        public void Add(ReservationPayBackBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}
