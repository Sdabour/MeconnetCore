using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationUtilityCol : BaseCol
    {
        public ReservationUtilityCol(bool blIsempty)
        {

        }
        public ReservationUtilityCol(int intID)
        {
            ReservationUtilityDb objDb = new ReservationUtilityDb();
            objDb.ReservationID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationUtilityBiz(objDr));
            }
        }

        public ReservationUtilityBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationUtilityBiz)List[intIndex];
            }
        }

        public double NonScheduledValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationUtilityBiz objBiz in this)
                {
                    if (!objBiz.Scheduled)
                        Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double ScheduledValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationUtilityBiz objBiz in this)
                {
                    if (objBiz.Scheduled)
                        Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public void schedule()
        {
            foreach (ReservationUtilityBiz objBiz in this)
            {
                if (!objBiz.Scheduled)
                    objBiz.Schedul();
            }
        }

        public void Add(ReservationUtilityBiz objBiz)
        {
            List.Add(objBiz);
 
        }

        internal DataTable GetTable(string strName)
        {
            DataTable dtReturned = new DataTable(strName);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("UtilityID"), new DataColumn("ReservationID"), new DataColumn("UtilityTypeID"), new DataColumn("UtilityValue"), new DataColumn("Scheduled"),new DataColumn("NewReservationID") });
            DataRow objDr;
            foreach (ReservationUtilityBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["UtilityID"] = objBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["NewReservationID"] = objBiz.NewReservationBiz.ID;
                objDr["UtilityTypeID"] = objBiz.UtilityTypeBiz.ID;
                objDr["UtilityValue"] = objBiz.Value;
                objDr["Scheduled"] = objBiz.Scheduled;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public void EditReservation(ReservationBiz objReservation)
        {
            foreach (ReservationUtilityBiz objBiz in this)
            {
                objBiz.EditCurrentReservation(objReservation);
 
            }
        }
        internal DataTable GetTable()
        {
            return GetTable("Utility");
 
        }
        public ReservationUtilityCol GetOverrideCopy(ReservationBiz objReservationBiz)
        {
            ReservationUtilityCol Returned = new ReservationUtilityCol(true);
            ReservationUtilityBiz objTemp;
            foreach (ReservationUtilityBiz objBiz in this)
            {
                
                objTemp = objBiz.GetOverrideCopy(objReservationBiz);
                objTemp.NewReservationBiz = objReservationBiz;
                Returned.Add(objTemp);
            }
            return Returned;
        }
    }
}