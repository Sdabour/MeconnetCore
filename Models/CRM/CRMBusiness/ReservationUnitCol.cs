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
    public class ReservationUnitCol : BaseCol
    {
        public ReservationUnitCol(bool blEmpty)
        {

        }
        public ReservationUnitCol(int intID)
        {
            ReservationUnitDb objDb = new ReservationUnitDb();
            objDb.ReservationID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationUnitBiz(objDr));
            }
        }
        public ReservationUnitBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (ReservationUnitBiz)List[intIndex];
            }
        }
        public double CachPrice
        {
            get
            {
                double Returned = 0;
                foreach (ReservationUnitBiz objBiz in this)
                {
                    Returned += objBiz.CachPrice;
                }
                return Returned;
            }
        }
        public double TotalSurvey
        {
            get
            {
                double Returned = 0;
                foreach (ReservationUnitBiz objBiz in this)
                {
                    Returned += objBiz.UnitBiz.Survey;
                }
                return Returned;
            }
        }
        public string UnitIDsStr
        {
            get
            {
                string Returned = "";
                foreach (ReservationUnitBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.UnitBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public string UnitFullName
        {
            get
            {
                string Returned = "";
                foreach (ReservationUnitBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitBiz.FullName;
                }
                return Returned;
            }
        }
        public UnitCol UnitCol
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                foreach (ReservationUnitBiz objBiz in this)
                {
                    Returned.Add(objBiz.UnitBiz);
                }
                return Returned;
            }
        }
        public void Add(ReservationUnitBiz objBiz)
        {
            int intIndex = GetIndex(objBiz);
            if (intIndex == -1)
                List.Add(objBiz);
            else
            {
                this[intIndex].UnitPrice = objBiz.UnitPrice;
                this[intIndex].RealDeliveryDate = objBiz.DeliveryDate;
                this[intIndex].CachPrice = objBiz.CachPrice;
                this[intIndex].ReservationID = objBiz.ReservationID;
            }


        }
        public int GetIndex(ReservationUnitBiz objBiz)
        {
            int Returned = -1;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].UnitBiz.ID == objBiz.UnitBiz.ID)
                {
                    Returned = intIndex;
                }
            }
            return Returned;
        }
        internal DataTable GetTable()
        {
            return GetTable("ReservationUnit");
        }
        internal DataTable GetTable(string strNname)
        {
            DataTable dtReturned = new DataTable(strNname);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ReservationID"), new DataColumn("UnitID"), new DataColumn("ReservationUnitPrice"), new DataColumn("ReservationcachPrice"), new DataColumn("ReservationDeliveryDate") 
            , new DataColumn("ReservationRealDeliveryDate",System.Type.GetType("System.DateTime")),new DataColumn("ChildReservation") });
            DataRow objDr;
            foreach (ReservationUnitBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ReservationID"] = objBiz.ReservationID;
                objDr["UnitID"] = objBiz.UnitBiz.ID;
                objDr["ReservationUnitPrice"] = objBiz.UnitPrice;
                objDr["ReservationcachPrice"] = objBiz.CachPrice;
                objDr["ReservationDeliveryDate"] =  objBiz.DeliveryDate == null|| objBiz.DeliveryDate<DateTime.Now.AddYears(20)?DateTime.Now:objBiz.DeliveryDate;
                objDr["ChildReservation"] = 0;
                if (objBiz.IsDelivered)
                    objDr["ReservationRealDeliveryDate"] = objBiz.RealDeliveryDate;
              
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;
        }
        public int GetIndexUsingCode(string strCode)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].UnitBiz.FullName == strCode)
                    return intIndex;
              
            }
            return -1;
        }
        public void EditReservation(ReservationBiz objReservationBiz)
        {
            string strUnitIDs = "";
            foreach (ReservationUnitBiz objUnitBiz in this)
            {
                if (strUnitIDs != "")
                    strUnitIDs += ",";
                strUnitIDs += objUnitBiz.UnitBiz.ID.ToString();
            }
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitIDs = strUnitIDs;
            objUnitDb.Reservation = objReservationBiz.ID;
            objUnitDb.EditCurrentReservation();
        }
    }
}
