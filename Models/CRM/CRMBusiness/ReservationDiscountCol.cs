using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationDiscountCol : BaseCol
    {
        public ReservationDiscountCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                ReservationDiscountDb objDb = new ReservationDiscountDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new ReservationDiscountBiz(objDr));
                }
            }
        }
        public ReservationDiscountCol(int intID)
        {
            ReservationDiscountDb objDb = new ReservationDiscountDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            SetData(dtTemp);
           
            
        }

        public ReservationDiscountCol(CellBiz objCellBiz,bool blReservationDate,DateTime dtFrom,DateTime dtTo,bool blContractingDate,DateTime dtContractingFrom,DateTime dtContractingTo
            ,bool isDiscountDateRange,DateTime dtDiscountDateFrom,DateTime dtDiscountDateTo,double dblValFrom,double dblValTo)
        {
            ReservationDiscountDb objDb = new ReservationDiscountDb();
            objDb.IsDateRange = blReservationDate;
            objDb.DateFrom = dtFrom;
            objDb.DateTo = dtTo;
            objDb.IsContractingDateRange = blContractingDate;
            objDb.ContractingDateFrom = dtContractingFrom;
            objDb.ContractingDateTo = dtContractingTo;
            objDb.IsDiscountdateRange = isDiscountDateRange;
            objDb.DiscountDateFrom = dtDiscountDateFrom;
            objDb.DiscountDateTo = dtDiscountDateTo;
            objDb.ValFrom = dblValFrom;
            objDb.ValTo = dblValTo;
           // objDb.CellID = objCellBiz.ID;
            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            if (objCellBiz.ID == objCellBiz.FamilyID)
                objDb.CellFamilyID = objCellBiz.ID;

            DataTable dtTemp = objDb.Search();
            SetData(dtTemp);
        }

        public ReservationDiscountBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationDiscountBiz)List[intIndex];
            }
        }
        public double NonScheduledValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationDiscountBiz objBiz in this)
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
              
                foreach (ReservationDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }

                return Returned;
            }
        }


        void SetData(DataTable dtTemp)
        {
            ReservationDiscountBiz objBiz;
            ReservationDiscountDb objDb;
            Hashtable hsTemp = new Hashtable();

            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new ReservationDiscountBiz(objDr);
              
                Add(objBiz);
            }
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "ReservationID", 200);
            ReservationDb objReservationDb;
            string strTemp;
            foreach(string strReservationIDs in arrStr)
            {
                objReservationDb = new ReservationDb();
                objReservationDb.IDs = strReservationIDs;
                DataTable dtReservation = objReservationDb.Search();
                ReservationBiz objReservationBiz;
                foreach (DataRow objDr in dtReservation.Rows)
                {
                    objReservationBiz = new ReservationBiz(objDr);
                    strTemp = objReservationBiz.UnitStr;
                    strTemp = objReservationBiz.CustomerStr;
                    if (hsTemp[objReservationBiz.ID.ToString()] == null)
                    {
                        hsTemp.Add(objReservationBiz.ID.ToString(), objReservationBiz);
                    }

 
                }
            
            }
            foreach (ReservationDiscountBiz objDiscountBiz in this)
            {
                if (hsTemp[objDiscountBiz.ReservationID.ToString()] != null)
                    objDiscountBiz.ReservationBiz = (ReservationBiz)hsTemp[objDiscountBiz.ReservationID.ToString()];
                else
                    objDiscountBiz.ReservationBiz = new ReservationBiz();

            }
        }


        public void Scheduled()
        {
            foreach (ReservationDiscountBiz objBiz in this)
            {
                if (!objBiz.Scheduled)
                    objBiz.Schedul();
            }
        }
        public void Add(ReservationDiscountBiz objBiz)
        {
            List.Add(objBiz);
 
        }





        internal DataTable GetTable(string strName)
        {
            DataTable dtReturned = new DataTable(strName);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DiscountID"), new DataColumn("ReservationID"), new DataColumn("DiscountReason"), new DataColumn("DiscountDate"), new DataColumn("DiscountValue"), new DataColumn("Scheduled"), new DataColumn("TypeID") });
            DataRow objDr;
            foreach (ReservationDiscountBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["DiscountID"] = objBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["DiscountReason"] = objBiz.Reason;
                objDr["DiscountDate"] = objBiz.Date;
                objDr["DiscountValue"] = objBiz.Value;
                objDr["Scheduled"] = objBiz.Scheduled;
                objDr["TypeID"] = objBiz.TypeBiz.ID;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public ReservationDiscountCol Copy(ReservationBiz objReservationBiz)
        {
            ReservationDiscountCol Returned = new ReservationDiscountCol(true);
            ReservationDiscountBiz objTemp;
            foreach (ReservationDiscountBiz objBiz in this)
            {
                objTemp = objBiz.Copy();
                objTemp.ReservationBiz = objReservationBiz;
                Returned.Add(objTemp);

            }
            return Returned;
        }
        internal DataTable GetTable()
        {
            return GetTable("Discount");
 
        }

        

    }
}