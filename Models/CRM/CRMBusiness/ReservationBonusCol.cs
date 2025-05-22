using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationBonusCol : BaseCol
    {
        public ReservationBonusCol(bool blIsempty)
        {

        }
        public ReservationBonusCol(int intID)
        {
            ReservationBonusDb objDb = new ReservationBonusDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationBonusBiz(objDr));
            }
        }

        public ReservationBonusBiz this[int intIndex]
        {

            get
            {
                return (ReservationBonusBiz)List[intIndex];
            }
        }
        public double NonScheduledValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBonusBiz objBiz in this)
                {
                    if (!objBiz.Scheduled)
                        Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationBonusBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
              public void Scheduled()
        {
            foreach (ReservationBonusBiz objBiz in this)
            {
                if (!objBiz.Scheduled)
                    objBiz.Schedul();
            }
        }
        public void Add(ReservationBonusBiz objBiz)
        {

            List.Add(objBiz);

        }
        internal DataTable GetTable(string strTableName)
        {
            DataTable dtReturned = new DataTable(strTableName);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("BonusID"), new DataColumn("ReservationID"), new DataColumn("BonusReason"), new DataColumn("BonusDate"), new DataColumn("BonusValue"), new DataColumn("Scheduled"), new DataColumn("TypeID") });
            DataRow objDr;
            foreach (ReservationBonusBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["BonusID"] = objBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["BonusReason"] = objBiz.Reason;
                objDr["BonusDate"] = objBiz.Date;
                objDr["BonusValue"] = objBiz.Value;
                objDr["Scheduled"] = objBiz.Scheduled;
                objDr["TypeID"] = objBiz.TypeBiz == null ? 0 : objBiz.TypeBiz.ID;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;
        }
        public ReservationBonusCol Copy(ReservationBiz objReservationBiz)
        {
            ReservationBonusCol Returned = new ReservationBonusCol(true);
            ReservationBonusBiz objTemp;
            foreach (ReservationBonusBiz objBiz in this)
            {
                objTemp = objBiz.Copy();
                objTemp.ReservationBiz = objReservationBiz;
                Returned.Add(objTemp);
 
            }
            return Returned;
        }

        internal DataTable GetTable()
        {
            return GetTable("Bonus");

        }
    }
}