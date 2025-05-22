using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum InstallmentStatus
    {
        Created,
        Paid,
        Scheduled
    }
    public class ReservationInstallmentBiz
    {
        #region Private Data
        ReservationInstallmentDb _ReservationInstallmentDb;
        InstallmentTypeBiz _Type;
        ReservationBiz _Reservation;
        InstallmentPaymentCol _PaymentCol;
        InstallmentDiscountCol _InstallmentDiscountCol;
        InstallmentDiscountDb _InstallmentDiscountDb;
        CellBiz _CellBiz;
        CampaignCustomerMonitorCol _MonitorCol;
        CampaignCustomerContactCol _ContactCol;

        #endregion
        #region Constructors

        public ReservationInstallmentBiz()
        {
            _ReservationInstallmentDb = new ReservationInstallmentDb();
        }
        public ReservationInstallmentBiz(int intID)
        {
            _ReservationInstallmentDb = new ReservationInstallmentDb(intID);
        }
        public ReservationInstallmentBiz(DataRow objDR)
        {
            _ReservationInstallmentDb = new ReservationInstallmentDb(objDR);
            _Type = new InstallmentTypeBiz(objDR);
        }

        #endregion
        #region Public Properties

        public int ID
        {
            set
            {
                _ReservationInstallmentDb.ID = value;
            }
            get
            {
                return _ReservationInstallmentDb.ID;
            }

        }
        public ReservationBiz Reservation
        {
            set
            {
                _Reservation = value;
            }
            get
            {
                if (_Reservation == null)
                    _Reservation = new ReservationBiz();
                return _Reservation;
            }

        }
        public InstallmentTypeBiz Type
        {
            get
            {
                if (_Type == null)
                    _Type = new InstallmentTypeBiz();
                return _Type;
            }
            set
            {
              
                _Type = value;
            }
        }
        public string TypeStr
        {
            get
            {
                return Type.Name;
            }
        }
        public int InstallmentNo
        {
            set
            {
                _ReservationInstallmentDb.InstallmentNo = value;
            }
            get
            {
                return _ReservationInstallmentDb.InstallmentNo;
            }

        }
        public double InstallmentValue
        {
            set
            {
                _ReservationInstallmentDb.InstallmentValue = value;
            }
            get
            {
                return _ReservationInstallmentDb.InstallmentValue;
            }

        }
        public DateTime InstallmentDueDate
        {
            set
            {
                _ReservationInstallmentDb.InstallmentDueDate = value;
            }
            get
            {
                return _ReservationInstallmentDb.InstallmentDueDate;
            }

        }
        public string DueDateStr
        {
            get
            {
                return InstallmentDueDate.ToString("yyyy-MM-dd");
 
            }
        }
        public string Desc
        {
            set
            {
                _ReservationInstallmentDb.Desc = value;
            }
            get
            {
                return _ReservationInstallmentDb.Desc;
            }

        }
        public string Note
        {
            set
            {
                _ReservationInstallmentDb.Note = value;
            }
            get
            {
                return _ReservationInstallmentDb.Note;
            }

        }
        public string Name
        {
            get
            {
                string Returned = "";
                if (Desc == null || Desc == "")
                    Returned = Type.Name;
                else
                    Returned = Desc;
                return Returned;
            }
        }
        public InstallmentStatus InstallmentStatus
        {
            set
            {
                _ReservationInstallmentDb.InstallmentStatus = (int) value;
            }
            get
            {
                return (InstallmentStatus)_ReservationInstallmentDb.InstallmentStatus;
            }

        }
        public string StatusStr
        {
            get
            {
              
                string Returned = InstallmentStatus == InstallmentStatus.Created && InstallmentDueDate >DateTime.Now ? "·„ Ì” Õﬁ" : 
                    (InstallmentStatus == InstallmentStatus.Created && InstallmentDueDate <=DateTime.Now ?"„” Õﬁ Ê€Ì— „”œœ" : "„”œœ");
               
                Returned += PaymentCol.CheckStatusStr;
                return Returned;
            }
        }
        public InstallmentPaymentCol PaymentCol
        {
            set
            {
                _PaymentCol = value;
            }
            get
            {

                if (_PaymentCol == null)
                {

                    _PaymentCol = new InstallmentPaymentCol(true);

                }
                return _PaymentCol;
            }
        }
        public double PaidValue
        {
            get
            {
                double Returned = 0;
                if (_PaymentCol != null)
                    Returned = PaymentCol.CashValue; //PaymentCol.Value;
                
                return Returned;
            }
        }
        public double TotalPaidValue
        {
            get 
            {
                return _ReservationInstallmentDb.TotalPaidValue;
            }
        }
        public DateTime PaymentDate
        {
            get
            {
                return _ReservationInstallmentDb.PaymentDate;
            }
        }
        public double DeservedCheckValue
        {
            get
            {
                double Returned = 0;
                if (_PaymentCol != null)
                    Returned = PaymentCol.DeservedCheckValue; //PaymentCol.Value;

                return Returned;
            }
        }
        public double DeservedValue
        {
            get
            {
                double Returned = 0;
                if (SysUtility.Approximate(InstallmentDueDate.ToOADate()-2,1,ApproximateType.Down) <=
                    SysUtility.Approximate(DateTime.Now.ToOADate()-2,1,ApproximateType.Down))
                {
                    Returned = RemainingValue;
                }

                return Returned;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                if (_PaymentCol != null)
                    Returned = PaymentCol.TotalCheckValue; //PaymentCol.Value;

                return Returned;
            }
        }
        public double TotalCollectedCheckValue
        {
            get
            {
                double Returned = 0;
                if (_PaymentCol != null)
                    Returned = PaymentCol.TotalCollectedCheckValue; //PaymentCol.Value;

                return Returned;
            }
        }
        public double NonDeservedCheckValue
        {
            get
            {
                double Returned = 0;
                if (_PaymentCol != null)
                    Returned = PaymentCol.NonDeservedCheckValue; //PaymentCol.Value;

                return Returned;
            }
        }
        internal int Group
        {
            set
            {
                _ReservationInstallmentDb.InstallmentGroup = value;
            }
            get
            {
                return _ReservationInstallmentDb.InstallmentGroup;
            }
        }
        public double RemainingValue
        {
            get
            {
                double Returned = InstallmentValue - PaidValue - DiscountValue;
                return Returned;
            }
        }
        public double VirtualRemainingValue
        {
            get
            {
                double dblPaidValue = PaymentCol.Value;
                double Returned = InstallmentValue - dblPaidValue - DiscountValue;
                return Returned;
            }
        }

        public double DiscountValue
        {
            get
            {

                double Returned = InstallmentDiscountCol.TotalValue;
                
                return Returned;
            }
 
        }
        public InstallmentDiscountCol InstallmentDiscountCol
        {
            set
            {
                _InstallmentDiscountCol = value;
            }
            get
            {
                if (_InstallmentDiscountCol == null)
                {
                    _InstallmentDiscountCol = new InstallmentDiscountCol(true);
                    if(ID != 0)
                    {
                        InstallmentDiscountDb objDb = new InstallmentDiscountDb();
                        objDb.InstallmentID = ID;

                        DataTable dtTemp = objDb.Search();
                        InstallmentDiscountBiz  objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new InstallmentDiscountBiz(objDr);
                            _InstallmentDiscountCol.Add(objBiz);
                        }

                    }
                }
                return _InstallmentDiscountCol;
            }

        }
        public int ReservationID
        {
            get
            {
                return _ReservationInstallmentDb.ReservationID;
            }
        }
        public string CustomerStr
        {
            get 
            {
                return _ReservationInstallmentDb.CustomerStr;
            }
        }
        public string CustomerPhone
        {
            get
            {
                return _ReservationInstallmentDb.CustomerPhone;
            }
        }
        public string CustomerMobile
        {
            get
            {
                return _ReservationInstallmentDb.CustomerMobile;
            }
        }
        public string UnitStr
        {
            get
            {
                return _ReservationInstallmentDb.UnitStr;
            }
        }
        public string TowerName
        {
            get
            {
                return _ReservationInstallmentDb.TowerName;
            }
        }
        public string ProjectName
        {
            get
            {
                return _ReservationInstallmentDb.ProjectName;
            }
        }
        public CellBiz CellBiz
        {
            get
            {
                if (_CellBiz == null)
                    _CellBiz = new CellBiz(_ReservationInstallmentDb.CellID);
                return _CellBiz;

            }
        }
        public int CampaignCustomer
        {
            get
            {
                return _ReservationInstallmentDb.CampaignCustomerID;
            }
        }
        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReservationInstallmentDb.ReservationID = _Reservation.ID;
            _ReservationInstallmentDb.InstallmentType = _Type.ID;
            _ReservationInstallmentDb.Add();

        }
        public void Edit()
        {
            _ReservationInstallmentDb.ReservationID = _Reservation.ID;
            _ReservationInstallmentDb.InstallmentType = _Type.ID;
            _ReservationInstallmentDb.Edit();
 
        }
        public void EditNote()
        {
            _ReservationInstallmentDb.ReservationID = _Reservation.ID;
            _ReservationInstallmentDb.EditNote();
        }
        public void EditStatus(InstallmentStatus objStatus,bool blOverrideStatus)
        {
            if ((InstallmentStatus)_ReservationInstallmentDb.InstallmentStatus == objStatus && !blOverrideStatus)
                return;
            _ReservationInstallmentDb.InstallmentStatus = (int)objStatus;
            _ReservationInstallmentDb.EditStatus();
            if (_Reservation == null)
                _Reservation = new ReservationBiz();
            if (_Reservation.ID > 0)
            {
                if (_Reservation.VirtualNonPaidValue <= 0)
                {
                    _Reservation.EditStatus(ReservationStatus.Complete);

                }
                else
                {

                    if (_Reservation.Status == ReservationStatus.Complete && objStatus == InstallmentStatus.Created)
                    {
                        _Reservation.EditStatus(ReservationStatus.Contracting);
                    }

                }
            }
            
        }

      
        public void Delete()
        {

            _ReservationInstallmentDb.Delete();

        }
        public ReservationInstallmentBiz GetNonPaidCopy()
        {
            ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
            Returned.Reservation = new ReservationBiz();
            Returned.Type = Type;
            Returned.InstallmentNo = InstallmentNo;
            Returned.InstallmentValue = RemainingValue;
            Returned.InstallmentDueDate = InstallmentDueDate;
            Returned.Desc = Desc;
            Returned.Note = Note;
            return Returned;
        }
        public static ReservationCol GetDeservedReservationCol12(CellBiz objCellBiz,
            CustomerBiz objCustomerBiz,DateTime dtStartDueDate,
            DateTime dtEndDueDate,int intRangeDateStatus,int intPaymentDateStatus,DateTime dtPaymentDateFrom,DateTime dtPaymentDateTo
            ,InstallmentTypeCol objTypeCol,int intStatus,bool blTest)
        {
            ReservationCol Returned = new ReservationCol(true);
            bool blShortReservation = ReservationInstallmentDb.ShortReservation;
            ReservationInstallmentDb.ShortReservation = true;
            #region Reservation Search
            DataTable dtInstallment = new DataTable();
            ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
            if (objCellBiz.ID == objCellBiz.ParentID)
                objInstallmentDb.CellFamilyID = objCellBiz.ID;
            else
            {
                objInstallmentDb.CellIDs = objCellBiz.IDsStr;
            }
            objInstallmentDb.StartDueDate = dtStartDueDate;
            objInstallmentDb.EndDueDate = dtEndDueDate;
            objInstallmentDb.ReservationStatus = 1;
            objInstallmentDb.ReservationParentStatus = 1;
            objInstallmentDb.PaymentDateStatus = intPaymentDateStatus;
            objInstallmentDb.PaymentDateStart = dtPaymentDateFrom;
            objInstallmentDb.PaymentDateEnd = dtPaymentDateTo;
            objInstallmentDb.StatusSearch = intStatus;
            if (intPaymentDateStatus != 0)
                objInstallmentDb.StatusSearch = 2;
            if (objTypeCol.Count > 0)
            {
                objInstallmentDb.TypeIDs = objTypeCol.IDsStr;
            }
            objInstallmentDb.DateRangeStatus = intRangeDateStatus;
           
            #region old Code for Search
            dtInstallment = objInstallmentDb.Search();

            //DataRow[] arrInstallment = dtInstallment.Select("", "ReservationID");
            int intReservationID =0;
            string strReservationIDs="";
            List<string> arrReservationIDs = SysUtility.GetStringArr(dtInstallment, "ReservationID", 240);
            
            strReservationIDs = "select distinct top 600 ReservationID from (" + objInstallmentDb.StrSearch + 
                ") as InstallmentReservationTable";

            #endregion
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.IDs = strReservationIDs;
            DataTable dtReservation = objReservationDb.Search();
            #endregion
            #region Reservation Region
            int intCustomerID = 0;
           
            DataRow[] arrReservation;
            ReservationBiz objReservationBiz ;
            DataRow[] arrTempReservation;
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.ReservationIDs = strReservationIDs;
            DataTable dtTempPayment = objDb.Search();
            DataRow[] arrPaymentDr;
            DataRow []arrInstallment;

            foreach (DataRow objDr in dtReservation.Rows)
            {
                objReservationBiz = new ReservationBiz(objDr);
                    Returned.Add(objReservationBiz);
                   
                   

                  
                        objReservationBiz.LinearInstallmentCol = new ReservationInstallmentCol(true);
                        arrInstallment = 
                            dtInstallment.Select("ReservationID=" + objReservationBiz.ID);
                        ReservationInstallmentBiz objBiz;
                        string strInstallmentIDs = "";
                        foreach (DataRow objInstallmentDr in arrInstallment)
                        {
                            objBiz = new ReservationInstallmentBiz(objInstallmentDr);
                            if (strInstallmentIDs != "")
                                strInstallmentIDs += ",";
                            strInstallmentIDs += objBiz.ID;
                            objReservationBiz.LinearInstallmentCol.Add(objBiz);
                        }
                      
                        foreach (ReservationInstallmentBiz objInstallmentBiz in objReservationBiz.LinearInstallmentCol)
                        {
                            arrPaymentDr = dtTempPayment.Select("InstallmentID=" + objInstallmentBiz.ID);
                            foreach (DataRow objPaymentDr in arrPaymentDr)
                            {
                                objInstallmentBiz.PaymentCol.Add(new InstallmentPaymentBiz(objPaymentDr));
                            }
                            
 
                        }
 
                    
                }

            
            #endregion

            //ReservationDb.cachCustomerTable 
            ReservationInstallmentDb.ShortReservation = blShortReservation;
            return Returned;
        }
        public static ReservationCol GetDeservedReservationCol34(CellBiz objCellBiz,
          CustomerBiz objCustomerBiz, DateTime dtStartDueDate,
          DateTime dtEndDueDate, int intRangeDateStatus, int intPaymentDateStatus, DateTime dtPaymentDateFrom, DateTime dtPaymentDateTo
          , InstallmentTypeCol objTypeCol, int intStatus,CampaignBiz objCampaignBiz,int intContactedStatus)
        {
            ReservationCol Returned = new ReservationCol(true);
            bool blShortReservation = ReservationInstallmentDb.ShortReservation;
            ReservationInstallmentDb.ShortReservation = true;
            #region Reservation Search
            DataTable dtInstallment = new DataTable();
            ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
            if (objCellBiz.ID == objCellBiz.ParentID)
                objInstallmentDb.CellFamilyID = objCellBiz.ID;
            else
            {
                objInstallmentDb.CellIDs = objCellBiz.IDsStr;
            }
            objInstallmentDb.StartDueDate = dtStartDueDate;
            objInstallmentDb.EndDueDate = dtEndDueDate;
            objInstallmentDb.ReservationStatus = 1;
            objInstallmentDb.ReservationParentStatus = 1;
            objInstallmentDb.PaymentDateStatus = intPaymentDateStatus;
            objInstallmentDb.PaymentDateStart = dtPaymentDateFrom;
            objInstallmentDb.PaymentDateEnd = dtPaymentDateTo;
            objInstallmentDb.StatusSearch = intStatus;
            
            if (intPaymentDateStatus != 0)
                objInstallmentDb.StatusSearch = 2;
            if (objTypeCol.Count > 0)
            {
                objInstallmentDb.TypeIDs = objTypeCol.IDsStr;
            }
            objInstallmentDb.DateRangeStatus = intRangeDateStatus;

            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            if (objCampaignBiz.ID != 0)
            {
                objInstallmentDb.Campaign = objCampaignBiz.ID;
                objInstallmentDb.CampaignStatus = 2;
                objInstallmentDb.CampaignContactStatus = intContactedStatus;
            }
            dtInstallment = objInstallmentDb.Search();

            //DataRow[] arrInstallment = dtInstallment.Select("", "ReservationID");
            int intReservationID = 0;
            //string strReservationIDs = "";
           

            //strReservationIDs = "select distinct top 600 ReservationID from (" + objInstallmentDb.StrSearch +
            //    ") as InstallmentReservationTable";
            List<string> arrReservationIDs = SysUtility.GetStringArr(dtInstallment, "ReservationID", 240);
            List<string> arrInstallmentIDs;
            DataRow[] arrInstallmentDr;
          
            DataTable dtReservation;
            ReservationBiz objReservationBiz;
            DataTable dtTempPayment ;
            DataRow[] arrPaymentDr;
            DataRow[] arrInstallment; // sorted by InstallmentID
            ReservationDb objReservationDb = new ReservationDb();
            InstallmentPaymentDb objDb;
            ReservationUnitCol objUnitCol;
            CustomerCol objCustomerCol;
            DataTable dtTemp;
            foreach (string strReservationIDs in arrReservationIDs)
            {
                if (strReservationIDs == null || strReservationIDs == "")
                    continue;
                arrInstallmentDr = dtInstallment.Select("ReservationID in(" +strReservationIDs +")", "InstallmentID");
                arrInstallmentIDs = SysUtility.GetStringArr(arrInstallmentDr, "InstallmentID", 1000);
                if (arrInstallmentIDs.Count == 0)
                    continue;

                objReservationDb.IDs = strReservationIDs;
                dtReservation = objReservationDb.Search();
                #endregion
                #region Reservation Region

                objDb = new InstallmentPaymentDb();
                objDb.InstallmentIDs = arrInstallmentIDs[0];
                dtTempPayment = objDb.Search();
                for (int intIndex = 1; intIndex < arrInstallmentIDs.Count; intIndex++)
                {

                    objDb.InstallmentIDs = arrInstallmentIDs[intIndex];
                    dtTemp = objDb.Search();
                    SysUtility.CopyTableIntoTable(dtTemp, ref dtTempPayment);
                }
                //dtTempPayment.Rows.Add(

                foreach (DataRow objDr in dtReservation.Rows)
                {
                    objReservationBiz = new ReservationBiz(objDr);
                    
                    Returned.Add(objReservationBiz);




                    objReservationBiz.LinearInstallmentCol = new ReservationInstallmentCol(true);
                    arrInstallment =
                        dtInstallment.Select("ReservationID=" + objReservationBiz.ID);
                    ReservationInstallmentBiz objBiz;
                    string strInstallmentIDs = "";
                    foreach (DataRow objInstallmentDr in arrInstallment)
                    {
                        objBiz = new ReservationInstallmentBiz(objInstallmentDr);
                        if (strInstallmentIDs != "")
                            strInstallmentIDs += ",";
                        strInstallmentIDs += objBiz.ID;
                        objReservationBiz.LinearInstallmentCol.Add(objBiz);
                        objUnitCol = objReservationBiz.UnitCol;
                        objCustomerCol = objReservationBiz.CustomerCol;
                    }

                    foreach (ReservationInstallmentBiz objInstallmentBiz in objReservationBiz.LinearInstallmentCol)
                    {
                        arrPaymentDr = dtTempPayment.Select("InstallmentID=" + objInstallmentBiz.ID);
                        foreach (DataRow objPaymentDr in arrPaymentDr)
                        {
                            objInstallmentBiz.PaymentCol.Add(new InstallmentPaymentBiz(objPaymentDr));
                        }


                    }


                }
            }

            #endregion

            //ReservationDb.cachCustomerTable 
            ReservationInstallmentDb.ShortReservation = blShortReservation;
            return Returned;
        }
        public static ReservationCol GetDeservedReservationCol(bool blIsContractingDateRange
            ,DateTime dtContractingFrom,DateTime dtContractingTo
            ,CellBiz objCellBiz,
         CustomerBiz objCustomerBiz, DateTime dtStartDueDate,
         DateTime dtEndDueDate, int intRangeDateStatus, int intPaymentDateStatus, DateTime dtPaymentDateFrom,
            DateTime dtPaymentDateTo
         , InstallmentTypeCol objTypeCol, int intStatus, 
            CampaignBiz objCampaignBiz, int intContactedStatus,
            bool blIgnorCampaign,int intCampaignMonitorStatus,int intUnitDeliveryStatus,
            int intTowerDeliveryStatus,int intAfterDeliveryStatus,string strReservationNote,
            ResubmissionTypeBiz objResubmissionType,int intCheckStatus,SharpVision.GL.GLBusiness.CofferCol objPlaceCol
            , bool blResubmissionDateRange, DateTime dtResubmissionStart
            , DateTime dtResubmissionEnd,UnitTypeBiz objUnitTypeBiz,int intIsForeignStatus)
        {
            if (objResubmissionType == null)
                objResubmissionType = new ResubmissionTypeBiz();
            if (objPlaceCol == null)
                objPlaceCol = new GL.GLBusiness.CofferCol(true,0);
            ReservationCol Returned = new ReservationCol(true);
            bool blShortReservation = ReservationInstallmentDb.ShortReservation;
            ReservationInstallmentDb.ShortReservation = true;
            //#region Reservation Search
            DataTable dtInstallment = new DataTable();
            ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
            if (objCellBiz.ID == objCellBiz.ParentID)
                objInstallmentDb.CellFamilyID = objCellBiz.ID;
            else
            {
                if (objCellBiz.FamilyIDs != null && objCellBiz.FamilyIDs != "")
                {
                    objInstallmentDb.CellFamilyIDs = objCellBiz.FamilyIDs;
                }
                else
                objInstallmentDb.CellIDs = objCellBiz.IDsStr;
            }
            objInstallmentDb.StartDueDate = dtStartDueDate;
            objInstallmentDb.EndDueDate = dtEndDueDate;
            objInstallmentDb.ReservationStatus = 1;
            objInstallmentDb.ReservationParentStatus = 1;
            objInstallmentDb.PaymentDateStatus = intPaymentDateStatus;
            objInstallmentDb.PaymentDateStart = dtPaymentDateFrom;
            objInstallmentDb.PaymentDateEnd = dtPaymentDateTo;
            objInstallmentDb.StatusSearch = intStatus;
            objInstallmentDb.IsContractingDateRange = blIsContractingDateRange;
            objInstallmentDb.StartContractingDate = dtContractingFrom;
            objInstallmentDb.EndContractingDate = dtContractingTo;
            objInstallmentDb.UnitDeliveryStatus = intUnitDeliveryStatus;
            objInstallmentDb.TowerDeliveryStatus = intTowerDeliveryStatus;
            objInstallmentDb.AfterDeliveryStatus = intAfterDeliveryStatus;
            objInstallmentDb.UnitTypeID = objUnitTypeBiz== null?0: objUnitTypeBiz.ID;
            if (intPaymentDateStatus != 0)
                objInstallmentDb.StatusSearch = 2;
            if (objTypeCol.Count > 0)
            {
                objInstallmentDb.TypeIDs = objTypeCol.IDsStr;
            }
            objInstallmentDb.DateRangeStatus = intRangeDateStatus;
            objInstallmentDb.ReservationNote = strReservationNote;
            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            if (objCampaignBiz.ID != 0)
            {
                objInstallmentDb.Campaign = objCampaignBiz.ID;
                objInstallmentDb.CampaignStatus = blIgnorCampaign ? 1 : 2 ;
                objInstallmentDb.CampaignContactStatus = intContactedStatus;
                objInstallmentDb.CampaignMonitorStatus = intCampaignMonitorStatus;
            }
            objInstallmentDb.ReservationCheckPlaces = objPlaceCol.IDsStr;
            objInstallmentDb.ReservationCheckStatus = intCheckStatus;
            objInstallmentDb.ResubmissionType = objResubmissionType.ID;
            objInstallmentDb.ResubmissionDateRange = blResubmissionDateRange;
            objInstallmentDb.ResubmissionStartDate = dtResubmissionStart;
            objInstallmentDb.ResubmissionEndDate = dtResubmissionEnd;
            objInstallmentDb.IsForeignStatus = intIsForeignStatus;
            ReservationInstallmentBiz objInstallmentBiz;
            ReservationBiz objReservationBiz;
            ReservationUnitBiz objReservationUnitBiz;
            UnitCellBiz objUnitCellBiz;
            dtInstallment = objInstallmentDb.Search();
            Hashtable hsReservation  = new Hashtable();
            foreach(DataRow objDr in dtInstallment.Rows)
            {
                objInstallmentBiz = new ReservationInstallmentBiz(objDr);
                if (hsReservation[objInstallmentBiz.ReservationID.ToString()] == null)
                {
                    objReservationBiz = new ReservationBiz();
                    objReservationBiz.CampaignCustomer = objInstallmentBiz.CampaignCustomer;
                    objReservationBiz.LinearInstallmentCol = new ReservationInstallmentCol(true);
                    objReservationBiz.ID = objInstallmentBiz.ReservationID;
                    //objReservationBiz.LinearInstallmentCol.Add(objInstallmentBiz);
                    objReservationUnitBiz = new ReservationUnitBiz();
                    objReservationUnitBiz.ReservationID = objInstallmentBiz.ReservationID;
                    objReservationUnitBiz.UnitBiz = new UnitBiz();
                    objReservationUnitBiz.UnitBiz.NameA = objInstallmentBiz.UnitStr;
                    objReservationUnitBiz.UnitBiz.FullName = objInstallmentBiz.UnitStr;
                    objReservationUnitBiz.UnitBiz.Floor = objInstallmentBiz.CellBiz;
                    objReservationUnitBiz.UnitBiz.CellCol = new UnitCellCol(true);
                    objUnitCellBiz = new UnitCellBiz();
                    objUnitCellBiz.CellBiz = new CellFloorBiz( objInstallmentBiz.CellBiz.ID);
                    objReservationUnitBiz.UnitBiz.CellCol.Add(objUnitCellBiz);
                    objReservationBiz.UnitCol = new ReservationUnitCol(true);
                    //objReservationUnitBiz = new ReservationUnitBiz();
                    objReservationBiz.UnitCol.Add(objReservationUnitBiz);
                    objReservationBiz.CustomerCol = new CustomerCol(true);
                    objReservationBiz.CustomerCol.Add(new CustomerBiz());
                    objReservationBiz.CustomerCol[0].NameA = objInstallmentBiz.CustomerStr;
                    objReservationBiz.CustomerCol[0].HomePhone = objInstallmentBiz.CustomerPhone;
                    objReservationBiz.CustomerCol[0].Mobile = objInstallmentBiz.CustomerMobile;

                    hsReservation.Add(objReservationBiz.ID.ToString(), objReservationBiz);
                    Returned.Add(objReservationBiz);


                }
                else
                    objReservationBiz = (ReservationBiz)hsReservation[objInstallmentBiz.ReservationID.ToString()];
                if (objInstallmentBiz._ReservationInstallmentDb.TotalPaidValue > 0)
                {
                    objInstallmentBiz.PaymentCol.Add(new InstallmentPaymentBiz());
                    objInstallmentBiz.PaymentCol[0].Value = objInstallmentBiz._ReservationInstallmentDb.TotalPaidValue;

                    objInstallmentBiz.PaymentCol[0].Date = objInstallmentBiz._ReservationInstallmentDb.PaymentDate;
                }
                //objInstallmentBiz.PaymentCol[0].
                objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                objInstallmentBiz.InstallmentDiscountCol.Add(new InstallmentDiscountBiz());
                objInstallmentBiz.InstallmentDiscountCol[0].Value = objInstallmentBiz._ReservationInstallmentDb.TotalDiscountValue;
                objReservationBiz.LinearInstallmentCol.Add(objInstallmentBiz);
            }
            return Returned;

            }
   
              
            //ReservationDb.cachCustomerTable 
          
       
        public static CustomerCol GetDeservedCustomerCol(CellBiz objCellBiz
            , DateTime dtStartDueDate,
          DateTime dtEndDueDate, int intRangeDateStatus
          , InstallmentTypeCol objTypeCol, int intStatus,
            CampaignBiz objCampaignBiz,int intCampaignStatus,CampaignCol objExmptedCampaignCol,string strReservationNote)
        {
            CustomerCol Returned = new CustomerCol(true);
            #region Reservation Search
            DataTable dtInstallment = new DataTable();
            ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
            objInstallmentDb.ReservationStatus = 1;
            objInstallmentDb.ReservationParentStatus = 1;
            if (objCellBiz.ID == objCellBiz.ParentID)
                objInstallmentDb.CellFamilyID = objCellBiz.ID;
            else
            {
                objInstallmentDb.CellIDs = objCellBiz.IDsStr;
            }
            objInstallmentDb.StartDueDate = dtStartDueDate;
            objInstallmentDb.EndDueDate = dtEndDueDate;
            if (objTypeCol.Count > 0)
                objInstallmentDb.TypeIDs = objTypeCol.IDsStr;
            objInstallmentDb.DateRangeStatus = intRangeDateStatus;
            objInstallmentDb.StatusSearch = intStatus;
            objInstallmentDb.Campaign = objCampaignBiz.ID;
            objInstallmentDb.CampaignStatus = 1;
            if(objExmptedCampaignCol != null && objExmptedCampaignCol.Count>0)
            objInstallmentDb.ExmptedCampaignStr = objExmptedCampaignCol.IDsStr;

        objInstallmentDb.ReservationNote = strReservationNote; 
            #region old Code for Search
            dtInstallment = objInstallmentDb.Search();

            DataRow[] arrInstallment = dtInstallment.Select("", "ReservationID");
            int intReservationID = 0;
            string strReservationIDs = "";

            strReservationIDs = "select distinct top 400  ReservationID from (" + objInstallmentDb.StrSearch +
                ") as InstallmentReservationTable";
            
            foreach (DataRow objDr in arrInstallment)
            {
                if (intReservationID.ToString() != objDr["ReservationID"].ToString())
                {
                    if (strReservationIDs != ",")
                        strReservationIDs += ",";
                    strReservationIDs += objDr["ReservationID"].ToString();
                    intReservationID = int.Parse(objDr["ReservationID"].ToString());
                }
            }
            #endregion
         
            #endregion
            #region Customer Region
            #region Reservation Region
            ReservationDb objReservationDb = new ReservationDb();
            //foreach(string strReservationIDs in  in arr
            //objReservationDb.IDs = strReservationIDs;
            DataTable dtReservation = objReservationDb.Search();
            Hashtable hsCustomer = new Hashtable();
            int intCustomerID = 0;

            DataRow[] arrReservation;
            ReservationBiz objReservationBiz;
            DataRow[] arrTempReservation;
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.ReservationIDs = strReservationIDs;
            DataTable dtTempPayment = objDb.Search();
            DataRow[] arrPaymentDr;
            //DataRow[] arrInstallment;
            //DataTable dtReservation
            foreach (DataRow objDr in dtReservation.Rows)
            {
                objReservationBiz = new ReservationBiz(objDr);
                //Returned.Add(objReservationBiz);




                objReservationBiz.LinearInstallmentCol = new ReservationInstallmentCol(true);
                arrInstallment =
                    dtInstallment.Select("ReservationID=" + objReservationBiz.ID);
                ReservationInstallmentBiz objBiz;
                string strInstallmentIDs = "";
                foreach (DataRow objInstallmentDr in arrInstallment)
                {
                    objBiz = new ReservationInstallmentBiz(objInstallmentDr);
                    if (strInstallmentIDs != "")
                        strInstallmentIDs += ",";
                    strInstallmentIDs += objBiz.ID;
                    objReservationBiz.LinearInstallmentCol.Add(objBiz);
                }

                foreach (ReservationInstallmentBiz objInstallmentBiz in objReservationBiz.LinearInstallmentCol)
                {
                    arrPaymentDr = dtTempPayment.Select("InstallmentID=" + objInstallmentBiz.ID);
                    foreach (DataRow objPaymentDr in arrPaymentDr)
                    {
                        objInstallmentBiz.PaymentCol.Add(new InstallmentPaymentBiz(objPaymentDr));
                    }


                }
                CustomerBiz objTempCustomer;
                foreach (CustomerBiz objCustomerBiz in objReservationBiz.CustomerCol)
                {
                    objTempCustomer = objCustomerBiz;
                    if (hsCustomer[objCustomerBiz.ID.ToString()] == null)
                    {
                        objTempCustomer.ReservationCol = new ReservationCol(true);
                        objTempCustomer.ReservationCol.Add(objReservationBiz);
                        hsCustomer.Add(objTempCustomer.ID.ToString(), objCustomerBiz);
                        Returned.Add(objTempCustomer);
                    }
                    else
                    {
                        objTempCustomer.ReservationCol = new ReservationCol(true);
                        objTempCustomer = (CustomerBiz)hsCustomer[objCustomerBiz.ID.ToString()];
                        objCustomerBiz.ReservationCol.Add(objReservationBiz);
 
                    }
                }

            }


            #endregion
            #endregion

            //ReservationDb.cachCustomerTable 
            return Returned;
        }
        #endregion
    }
}
