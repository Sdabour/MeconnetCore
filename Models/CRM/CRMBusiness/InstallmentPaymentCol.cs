using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.GL.GLBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentPaymentCol : BaseCol
    {
        int _ResultCount;
        public InstallmentPaymentCol(bool blIsempty)
        {

        }
        public InstallmentPaymentCol(int intID)
        {
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentPaymentBiz(objDr));
            }
        }
        public InstallmentPaymentCol(CellBiz objCellBiz,PaymentType objPaymentType,
            DateTime dtFromPaymentDate,DateTime dtToPaymentDate,bool blPaymentDatStatus
            ,InstallmentTypeBiz objInstallmentTypeBiz,bool blOnlyAccounts,bool blOnlyNonTransaction)
        {
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.InstallmentTypeID = objInstallmentTypeBiz.ID;
            objDb.OnlyNonTransaction = blOnlyNonTransaction;
            objDb.PaymentDateStatus = blPaymentDatStatus;
            objDb.FromPaymentDate = dtFromPaymentDate;
            objDb.ToPaymentDate = dtToPaymentDate;
            objDb.TopSelected = 1000;
            string strTemp;
            if (objCellBiz != null)
            {
                if (objCellBiz.ID == objCellBiz.ParentID)
                {
                    objDb.CellFamilyID = objCellBiz.ID;
                }
                else
                {
                    CellBiz objTemp = new CellBiz(objCellBiz.ID);

                    
                        CellCol objCellCol = objTemp.GetTypedChildren(7, -1);
                         strTemp = objCellCol.IDsStr;
                        if (strTemp == "")
                            strTemp = "0";
                        
                        CellDb.CachCellID = objTemp.ID;
                        CellDb.CachCellIDs = strTemp;
                        CellDb.CachTypeID = 7;
                    
                                      
                    objDb.CellIDsStr = strTemp;
                }
            }
            objDb.OnlyAccounts = blOnlyAccounts;
            DataTable dtTemp = objDb.Search();
            _ResultCount = objDb.ResultCount;
            DataRow[] arrDr = dtTemp.Select("", "ReservationID");
            string strReservationIDs = "";
            string strID = "";
            foreach (DataRow objDr in arrDr)
            {
                if (objDr["ReservationID"].ToString() != strID)
                {
                    strID = objDr["ReservationID"].ToString();
                    if (strReservationIDs != "")
                        strReservationIDs += ",";
                    strReservationIDs += strID;
                }
            }
            if (strReservationIDs != "")
            {
                ReservationDb.ReservationIDs = strReservationIDs;
                ReservationDb.SetReservationCach();
            }
            InstallmentPaymentBiz objTempBiz;
             strTemp="";
            foreach (DataRow objDr in arrDr)
            {
                objTempBiz = new InstallmentPaymentBiz(objDr);
                objTempBiz.InstallmentBiz = new ReservationInstallmentBiz(objDr);
                objTempBiz.InstallmentBiz.Reservation = new ReservationBiz(objDr);
                strTemp = objTempBiz.InstallmentBiz.Reservation.CustomerStr;
                strTemp = objTempBiz.InstallmentBiz.Reservation.UnitStr;
                List.Add(objTempBiz);

            }


 
        }

        public InstallmentPaymentBiz this[int intIndex]
        {
           
            get
            {
                return (InstallmentPaymentBiz)List[intIndex];
            }
        }
        public double Value
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public double DeservedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.Value != 0 && !objBiz.IsCollected &&
                        (objBiz.CheckBiz.Status != CheckStatus.Collected && 
                        objBiz.CheckBiz.Status != CheckStatus.Reclaimed) &&
                        objBiz.CheckBiz.DueDate <= DateTime.Now)
                        Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        
        public double NonDeservedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.Value != 0 && !objBiz.IsCollected &&
                        (objBiz.CheckBiz.Status != CheckStatus.Collected && objBiz.CheckBiz.Status != CheckStatus.Reclaimed) &&
                        objBiz.CheckBiz.DueDate > DateTime.Now)
                        Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.Value != 0 )
                        Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalCollectedCheckValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if (objBiz.CheckBiz.Value != 0 && (objBiz.IsCollected ||
                        (objBiz.CheckBiz.Status == CheckStatus.Collected ||objBiz.CheckBiz.Status == CheckStatus.Reclaimed)))
                        Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public double CashValue
        {
            get
            {
                double Returned = 0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if(objBiz.CheckBiz.Value == 0 || objBiz.IsCollected ||
                        (objBiz.CheckBiz.Status == CheckStatus.Collected ||objBiz.CheckBiz.Status == CheckStatus.Reclaimed))
                     Returned = Returned + objBiz.Value;
                }
                return Returned;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public TransactionCol TransactionCol
        {
            get
            {
                TransactionCol Returned = new TransactionCol(true);
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    Returned.Add(objBiz.TransactionBiz);
                }
                return Returned;
            }

        }
        public string CheckStatusStr
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                double dblCollectedValue =0;
                foreach (InstallmentPaymentBiz objBiz in this)
                {
                    if(objBiz.Value != 0)
                    {
                        if (objBiz.CheckBiz.Value >0 && hsTemp[objBiz.CheckBiz.Code] == null)
                        {
                            hsTemp.Add(objBiz.CheckBiz.Code,"");
                            if (objBiz.CheckBiz.Value != 0 && !objBiz.IsCollected)
                            {
                                if (Returned != "")
                                    Returned += " & ";
                                Returned += " Ôíß ÑÞã " + objBiz.CheckBiz.Code;
                                Returned += "(" + objBiz.CheckBiz.StatusStr + ")";
                            }
                            else
                            {
                                if (Returned != "")
                                    Returned += " & ";
                                Returned += " Ôíß ÑÞã " + objBiz.CheckBiz.Code;
                                Returned += "(ãÍÕá ÌÒÆì)";
                            }
                        }
                    }

                }
                return Returned;
            }
        }
        public void Add(InstallmentPaymentBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }

        public void CreateTransaction()
        {
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                objBiz.CreateTransaction();
            }
        }


        public double GetPaidAfterTimeValue(DateTime dtTime)
        {
            double Returned = 0;
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                if (objBiz.Date >= dtTime)
                    Returned += objBiz.Value;
            }
            return Returned;
        }

        public int GetFirstNonCollectedCheckPayment()
        {
            int intIndex = 0;
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                if (objBiz.CheckBiz.Value > 0 && !objBiz.IsCollected)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public string GetLastPaymentDate()
        {
            string Returned = "";
            
            DateTime dtMax = DateTime.Now;
            DateTime dtCurrent = DateTime.Now;
            bool blIsPad;
            bool blMaxDetermined = false;
            if (Count > 0)
                dtMax = this[Count - 1].Date;
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                blIsPad = false;
                if ((objBiz.Type == PaymentType.Cash || objBiz.Type == PaymentType.BankingTransfering) && objBiz.CheckBiz.Value == 0)
                {
                    blIsPad = true;
                    dtCurrent = objBiz.Date;
                }
                else
                {
                    if (objBiz.CheckBiz.Status == CheckStatus.Collected ||
                        objBiz.CheckBiz.Status == CheckStatus.Reclaimed)
                    {
                        blIsPad = true;
                        dtCurrent = objBiz.CheckBiz.StatusDate;

                    }
                    else if (objBiz.IsCollected)
                    {
                        blIsPad = true;
                        dtCurrent = objBiz.CollectingDate;
                    }
 
                }
                if (blIsPad)
                {
                    if (!blMaxDetermined)
                    {
                        dtMax = dtCurrent;
                        blMaxDetermined = true;
                    }
                    if (dtCurrent > dtMax)
                        dtMax = dtCurrent;
                    //dtMax = ((TimeSpan)dtMax.Subtract(objBiz.InstallmentBiz.InstallmentDueDate)).Days > 0 ?
                    //    objBiz.InstallmentBiz.InstallmentDueDate : dtMax;
                    Returned = dtMax.ToString("yyyy-MM-dd");
                }
            }
            return Returned;
        }
      
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("InstallmentID"), new DataColumn("Type"), new DataColumn("Date"), new DataColumn("Value") 
            , new DataColumn("Name"), new DataColumn("NameA"), new DataColumn("NameE")});
            DataRow objDr;
            foreach (InstallmentPaymentBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["InstallmentID"] = objBiz.InstallmentID;
                objDr["Value"] = objBiz.Value;
                objDr["Date"] = objBiz.Date;
                //objDr["Type"] = (int)objBiz.PaymentTypeBiz.PaymentType;
                //objDr["Name"] = objBiz.Na
                //objDr["NameA"] = objBiz.NameA;
                //objDr["NameE"] = objBiz.NameE;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
    }
}
