using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum ReservationStatus
    {
        Primary = 1,//ÕÃ“ »œÊ‰ œ›⁄
        DownPayment = 2,//œ›⁄« 
        Contracting = 3,// ⁄«ﬁœ
        Complete = 4,//«” Ì›«¡
        Cession = 5,// ‰«“·
        Cancellation = 6//«·€«¡

    }
    public class ReservationBiz
    {
        #region Private Data

        protected ReservationDb _ReservationDb;
        CustomerBiz _CustomerBiz;
        //UnitBiz _UnitBiz;
        //UnitModelBiz _ModelBiz;
       protected  UserBiz _UserIns;
        protected UserBiz _UserUpd;
        protected StrategyBiz _StrategyBiz;
        protected BranchBiz _BranchBiz;
        //ReservationInstallmentCol _InstallmentCol;
        protected StrategyInstallmentCol _InstallmentTypeCol;
        protected WorkerContributionCol _WorkerCol;
        protected InstallmentMulctCol _InstallmentMulctCol;
        protected InstallmentDiscountCol _InstallmentDiscountCol;
        protected MulctPaymentCol _MulctPaymentCol;
        protected ReservationAttachmentCol _ReservationAttachmentCol;
        protected ReservationUtilityCol _UtilityCol;
        protected ReservationDiscountCol _DiscountCol;
        protected ReservationBonusCol _BonusCol;
        protected TempReservationPaymentCol _PaymentCol;
        protected InsurancePaymentCol _InsurancePaymentCol;
        protected AdministrativeCostPaymentCol _AdministrativePaymentCol;
        protected CustomerCol _CustomerCol;
        protected CustomerCol _AllCustomerCol;
        protected ReservationInstallmentCol _LinearInstallmentCol;
        protected AttachmentCol _AllAttachmentCol;
        protected ReservationUnitCol _UnitCol;
        protected ReservationUnitCol _AllUnitCol;
        protected InstallmentCheckCol _CheckCol;
        protected ReservationInstallmentCol _NonCheckedInstallmentCol;
        protected ReservationPayBackCol _PayBackCol;
        protected AccountBiz _AccountBiz;
        protected AccountBiz _LeafAccountBiz;
       // protected TransactionBiz _ContractingTransactionBiz;

        protected ReservationCessionBiz _CessionBiz;
        private ReservationCancelationBiz _CancelationBiz;

        public ReservationCancelationBiz CancelationBiz
        {
            get {
                if (_CancelationBiz == null)
                    _CancelationBiz = new ReservationCancelationBiz();
                return _CancelationBiz; }
            set { _CancelationBiz = value; }
        }
        protected ReservationBiz _ParentReservation;
        //ReservationPayBackCol _PayBackCol;
     //   ReservationPayBackCol _PayBackCol;
        protected bool _IsSet;
        int _CampaignCustomer;
        CampaignCustomerContactCol _ContactCol;
        CampaignCustomerMonitorCol _MonitorCol;
        static AccountBiz _UnitCreditorAccountBiz;
        static AccountBiz _SalesAccountBiz;
        static ReservationCol _PickedReservationCol;

        #region FillData
        bool _StopPayment;
        bool _StopMulct;
        bool _StopMulctPayment;
        bool _StopDiscount;
        #endregion
        #region Private Deleted Region

        ReservationUtilityCol _DeletedUtilityCol;
        ReservationDiscountCol _DeletedDiscountCol;
        StrategyInstallmentCol _DeletedInstallmentTypeCol;
        ReservationInstallmentCol _DeletedInstallmentCol;
        ReservationBonusCol _DeletedBonusCol;
        ReservationAttachmentCol _DeletedAttachmentCol;
        TempReservationPaymentCol _DeletedPaymentCol;
        AdministrativeCostPaymentCol _DeletedAdministrativePaymentCol;
        bool _LinearMode;
        #endregion
        #region Private data for GL
        TransactionBiz _ContractingTransactionBiz;
        TransactionBiz _DeliveryTransactionBiz;
        TransactionBiz _CancelationTransactionBiz;
        TransactionBiz _InstallmentMulctTransactionBiz;
        TransactionBiz _InstallmentDiscountTransactionBiz;
        TransactionBiz _PaymentTransactionBiz;
        ReservationPaymentCol _ReservationPaymentCol;
        #endregion
        #endregion

        #region Private Property
        internal double PreviousPaidValue
        {
            get
            {
                return _ReservationDb.PreviousPaidValue;
            }
        }
        #endregion

        #region Constructors

        public ReservationBiz()
        {
            
                _ReservationDb = new ReservationDb();
            //  _UnitBiz = new UnitBiz();
            _StrategyBiz = new StrategyBiz();
            //_CustomerBiz = new CustomerBiz();
            _BranchBiz = new BranchBiz();
            _AccountBiz = new AccountBiz();
        }
        public ReservationBiz(int intID)
        {
            DataRow[] arrDr  = new DataRow[0];
            //if (arrDr.Length > 0)
            //{
            //    if (SysData.IsOnline)
            //        _ReservationDb = new ReservationWeb(arrDr[0]);
            //    else
            //        _ReservationDb = new ReservationDb(arrDr[0]);
            //    ReservationDb.ReservationIDs = intID.ToString();
            //    ReservationDb.SetReservationCach();

            //}
            //else
            //{
            _ReservationDb = new ReservationDb();
            if (intID != 0)
            {
               
                   _ReservationDb = new ReservationDb();
                _ReservationDb.ID = intID;
                DataTable dtTemp = _ReservationDb.Search();
                arrDr = dtTemp.Select();
                if (arrDr.Length > 0)
                {
                    _ReservationDb = new ReservationDb(arrDr[0]);
                    if (_ReservationDb.Brand != 0)
                        _BrandBiz = new BrandBiz(arrDr[0]);
                    else
                        _BrandBiz = new BrandBiz();
                    if (_ReservationDb.IsCanceled)
                        _CancelationBiz = new ReservationCancelationBiz(arrDr[0]);
                    if (_ReservationDb.ResubmissionTypeID != 0)
                        _ResubmissionBiz = new ReservationResubmissionBiz(arrDr[0]);
                }
            }
               
            if (_ReservationDb.ID != 0)
            {
                _StrategyBiz = new StrategyBiz(_ReservationDb.StrategyDb);
                //_CustomerBiz = new CustomerBiz(_ReservationDb.CustomerDb);
                _StrategyBiz = new StrategyBiz(_ReservationDb.StrategyDb);

                _BranchBiz = new BranchBiz(_ReservationDb.BranchDb);
                if (_ReservationDb.GLLeafAccount != 0)
                    _LeafAccountBiz = new AccountBiz(arrDr[0]);
                else
                    _LeafAccountBiz = new AccountBiz();
            }
        }
        public ReservationBiz(DataRow objDR)
        {
            
                _ReservationDb = new ReservationDb(objDR);

            if (_ReservationDb.CustomerID != 0)
                _CustomerBiz = new CustomerBiz(objDR);
            _StrategyBiz = new StrategyBiz(_ReservationDb.StrategyDb);
            //_CustomerBiz = new CustomerBiz(_ReservationDb.CustomerDb);
            if (_ReservationDb.Brand != 0)
                _BrandBiz = new BrandBiz(objDR);
            else
                _BrandBiz = new BrandBiz();
            if (_ReservationDb.BranchID != 0)
                _BranchBiz = new BranchBiz(objDR);
            else
                _BranchBiz = new BranchBiz();

            if (_ReservationDb.GLLeafAccount != 0)
                _LeafAccountBiz = new AccountBiz(objDR);
            else
                _LeafAccountBiz = new AccountBiz();
            if (_ReservationDb.IsCanceled)
                _CancelationBiz = new ReservationCancelationBiz(objDR);
            if (_ReservationDb.OldReservationID != 0)
                _CessionBiz = new ReservationCessionBiz(objDR);
            else
                _CessionBiz = new ReservationCessionBiz();
            if (_ReservationDb.ResubmissionTypeID != 0)
                _ResubmissionBiz = new ReservationResubmissionBiz(objDR);
        }


        #endregion

        #region Public Properties


        #region UserUpdateInsert
        public UserBiz UserIns
        {
            set
            {
                _UserIns = value;
            }
            get
            {
                if (_UserIns == null)
                    _UserIns = new UserBiz();
                return _UserIns;
            }
        }
        public UserBiz UserUpd
        {
            set
            {
                _UserUpd = value;
            }
            get
            {
                if (_UserUpd == null)
                    _UserUpd = new UserBiz();
                return _UserUpd;
            }
        }
        public DateTime TimeIns
        {
            set
            {
                _ReservationDb.TimeIns = value;
            }
            get
            {
                return _ReservationDb.TimeIns;
            }
        }
        public DateTime TimeUpd
        {
            set
            {
                _ReservationDb.TimeUpd = value;
            }
            get
            {
                return _ReservationDb.TimeUpd;
            }
        }
        #endregion
        public int ID
        {
            set
            {
                _ReservationDb.ID = value;
            }
            get
            {
                return _ReservationDb.ID;
            }
        }
        public int Strategy
        {
            set
            {
                _ReservationDb.Strategy = value;
            }
            get
            {
                return _ReservationDb.Strategy;
            }
        }
        public StrategyBiz StrategyBiz
        {
            set
            {
                _StrategyBiz = value;
            }
            get
            {
                return _StrategyBiz;
            }
        }
        public ReservationStatus Status
        {
            set
            {
                _ReservationDb.Status = (int)value;
            }
            get
            {
                return (ReservationStatus)_ReservationDb.Status;
            }
        }
        public DateTime Date
        {
            set
            {
                _ReservationDb.Date = value;
            }
            get
            {
                return _ReservationDb.Date;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _ReservationDb.DeliveryDate = value;
            }
            get
            {
                return _ReservationDb.DeliveryDate;
            }
        }
        public DateTime RealDeliveryDate
        {
            set
            {
                _ReservationDb.RealDeliveryDate = value;
            }
            get
            {
                return _ReservationDb.RealDeliveryDate;
            }
        }
        public bool DataHidden
        {
            set
            {
                _ReservationDb.DataIsHidden = value;
            }
            get
            {
                return _ReservationDb.DataIsHidden;
            }
        }

        public double Value
        {
            set
            {
                _ReservationDb.Value = value;
            }
            get
            {
                return _ReservationDb.Value;
            }
        }
        public DateTime StatusDate
        {
            set
        {
            _ReservationDb.StatusDate = value;

        }
            get
            {
                return _ReservationDb.StatusDate;
            }
        }
        public string CustomerStr
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned = Returned + " Ê ";
                    Returned = Returned + objBiz.Name;

                }
                return Returned;
            }
        }
        public string DirectCustomerStr
        {
            set 
            {
                _ReservationDb.CustomerName = value;
            }
            get
            {
                string Returned = "";
                Returned = _ReservationDb.CustomerName;
                return Returned;
            }
        }
        public string SalesStr
        {
            get
            {
                string Returned = "";
                foreach (WorkerContributionBiz objBiz in WorkerCol)
                {
                    if (Returned != "")
                        Returned = Returned + " Ê ";
                    Returned = Returned + objBiz.SalesManBiz.Name;
                }
                return Returned;
            }
        }
        public string DirectSalesStr
        {
            get
            {
                string Returned = "";
                Returned = _ReservationDb.SalesMan;
                return Returned;
            }
        }
        public string CustomerNationalityStr
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (objBiz.CountryBiz.ID != 0)
                    {
                        if (Returned != "")
                            Returned = Returned + " Ê ";
                        Returned = Returned + objBiz.CountryBiz.Nationality;
                    }

                }
                return Returned;
            }
        }
        public string DirectCustomerNationalityStr
        {
            get
            {
                string Returned = "";
                Returned = _ReservationDb.CustomerNationality;
                return Returned;
            }
        }
        public string ProjectName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (hsTemp[objBiz.UnitBiz.Project.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.UnitBiz.Project.ID.ToString(), objBiz.UnitBiz.Project.ID);
                        if (Returned != "")
                            Returned += " & ";
                        Returned += objBiz.UnitBiz.Project.AlterName;

                    }
                }
                return Returned;
            }
        }
        public int ProjectID
        {
            set
            {
                _ReservationDb.ProjectID = value;
            }
            get 
            {
                return _ReservationDb.ProjectID;
            }
        }
        public string DirectProjectName
        {
            set
            {
                _ReservationDb.ProjectName = value;
            }
            get
            {
                string Returned = "";
                if (_UnitCol != null &&_UnitCol.Count > 0)
                    Returned = ProjectName;
                else
                Returned = _ReservationDb.ProjectName;
                return Returned;
            }
        }
        public string UnitSurveyStr
        {
            get
            {
                string Returned = "";
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (Returned != "")
                        Returned += " - ";
                    Returned += objBiz.UnitBiz.Survey;
                }
                return Returned;
            }
        }
        public string DirectUnitSurveyStr
        {
            set
            {
                _ReservationDb.UnitSurvey = value;
            }
            get
            {
                string Returned = "";
                 if (_UnitCol != null &&_UnitCol.Count > 0)
                    Returned = UnitSurveyStr;
                else
                   Returned = _ReservationDb.UnitSurvey;
            
                return Returned;
            }
        }
        public string UnitFullName
        {
            get
            {
                string Returned = "";
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitBiz.FullName  ;
                    if(objBiz.UnitBiz.PeripheralFullName!="")
                        Returned+= "("+ objBiz.UnitBiz.PeripheralFullName+ ")";

                }
                return Returned;
            }
        }
        public string UnitName
        {
            get
            {
                string Returned = "";
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitBiz.Name;
                }
                return Returned;
            }
        }
        public string ProjectFullName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (hsTemp[objBiz.UnitBiz.Project.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.UnitBiz.Project.ID.ToString(),
                            objBiz.UnitBiz.Project.ID);
                        if (Returned != "")
                            Returned += " & ";
                        Returned += objBiz.UnitBiz.Project.FullAlterName;
                    }
                }
                return Returned;
            }
        }
        public string UnitStr
        {
            get
            {


                string Returned = "";
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.UnitBiz.CellCol[0].CellBiz.GetFullAlterName(26) + " - " + objBiz.UnitBiz.Name;
                }
                return Returned;
            }
        }
        public string InstallmentStartDate
        {
            get
            {
                return _ReservationDb.InstallmentStartDate;
            }
        }
        public string InstallmentEndDate
        {
            get
            {
                return _ReservationDb.InstallmentEndDate;
            }
        }
        public double DirectCancelationCost
        {
            get
            {
                return _ReservationDb.DirectCancelationCost;
            }
        }
        public string UnitCellStr
        {
            get
            {


                string Returned = "";
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.UnitBiz.CellCol.Count > 0)
                        Returned += objBiz.UnitBiz.Floor.GetFullAlterName(26);
                }
                return Returned;
            }
        }
        public string DirectUnitCellStr
        {
            get
            {


                string Returned = "";
             
                CellBiz objBiz = new CellBiz(_ReservationDb.FloorID);
                Returned = objBiz.GetFullAlterName(26);
                return Returned;
            }
        }
        public string UnitCodeStr
        {
            get
            {


                string Returned = "";
                if (_UnitCol == null || _UnitCol.Count == 0)
                {
                    foreach (ReservationUnitBiz objBiz in UnitCol)
                    {
                        if (Returned != "")
                            Returned += " & ";
                        Returned += objBiz.UnitBiz.FullName;
                    }
                }
                else
                    Returned = _ReservationDb.UnitCode;
                return Returned;
            }
            set
            {
                _ReservationDb.UnitCode = value;
            }
        }
        public double NativeUnitPrice
        {
            get
            {
                return _ReservationDb.NativeUnitPrice;
            }
        }
        public string DirectUnitCodeStr
        {
            set
            {
                _ReservationDb.UnitCode = value;
            }
            get
            {


                string Returned = "";
                if (_UnitCol != null && _UnitCol.Count > 0)
                    Returned = UnitCodeStr;
                else
                    Returned = _ReservationDb.UnitCode == null?"":_ReservationDb.UnitCode;
                return Returned;
            }
        }
        public string DirectUnitNameStr
        {
            set
            {
                _ReservationDb.UnitName = value;
            }

            get
            {


                string Returned = "";
                if (_UnitCol != null && _UnitCol.Count > 0)
                    Returned = UnitName;
                else
                Returned = _ReservationDb.UnitName;
                return Returned;
            }
        }
        public string UnitTowerName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    
                        if (hsTemp[objBiz.UnitBiz.Tower.ID.ToString()] == null)
                        {
                            hsTemp.Add(objBiz.UnitBiz.Tower.ID.ToString(),
                                objBiz.UnitBiz.Tower.ID);
                            if (Returned != "")
                                Returned += " & ";
                            Returned += objBiz.UnitBiz.Tower.AlterName == null || objBiz.UnitBiz.Tower.AlterName == "" ? objBiz.UnitBiz.Tower.Name : objBiz.UnitBiz.Tower.AlterName;

                        }
                    
                }
                return Returned;
            }
        }
        public CellBiz DirectFloorBiz
        {
            get
            {
                CellBiz Returned= new CellBiz(_ReservationDb.FloorID);
                return Returned;
            }
        }
        public CellBiz DirectTowerBiz
        {
            get
            {
                CellBiz Returned = new CellBiz(_ReservationDb.FloorID);
                Returned = Returned.ParentBiz;
                return Returned;
            }
        }
        public int FloorID
        {
            set
            {
                _ReservationDb.FloorID = value;
            }
            get
            {
                return _ReservationDb.FloorID;
            }
        }
        string _DirectProjectName ;
      
        public string DirectUnitProjectName
        {
          
            get
            {
                string Returned = "";
                CellBiz objBiz = DirectFloorBiz;
                objBiz = new CellBiz(objBiz.FamilyID);
                Returned = objBiz.AlterName;
                return Returned;
            }
        }

        public string UnitProjectName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {

                    if (hsTemp[objBiz.UnitBiz.Project.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.UnitBiz.Project.ID.ToString(),
                            objBiz.UnitBiz.Project.ID);
                        if (Returned != "")
                            Returned += " & ";
                        Returned += objBiz.UnitBiz.Project.AlterName == null || objBiz.UnitBiz.Project.AlterName == "" ? objBiz.UnitBiz.Project.Name : objBiz.UnitBiz.Project.AlterName;

                    }

                }
                return Returned;
            }
        }
        public string DirectModelName
        {
            get
            {
                string Returned = _ReservationDb.ModelName;
                return Returned;
            }
        }
        public string UnitModelName
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (objBiz.UnitBiz.ModelBiz.ID != 0)
                    {
                        if (hsTemp[objBiz.UnitBiz.ModelBiz.ID.ToString()] == null)
                        {
                            hsTemp.Add(objBiz.UnitBiz.ModelBiz.ID.ToString(),
                                objBiz.UnitBiz.ModelBiz.ID);
                            if (Returned != "")
                                Returned += " & ";
                            Returned += objBiz.UnitBiz.ModelBiz.Name;

                        }
                    }
                }
                return Returned;
            }
        }
        public ReservationUnitCol UnitCol
        {
            set
            {
                _UnitCol = value;
            }
            get
            {
                if (_UnitCol == null)
                {
                    _UnitCol = new ReservationUnitCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = ReservationDb.CachUnitTable.Select("ReservationID=" + ID);
                        UnitCellCol objTempCell;
                        foreach (DataRow objDr in arrDr)
                        {
                            ReservationUnitBiz objBiz = new ReservationUnitBiz(objDr);
                            objTempCell = objBiz.UnitBiz.CellCol;

                            _UnitCol.Add(objBiz);
                        }
                    }
                }
                return _UnitCol;
            }
        }
        public ReservationUnitCol AllUnitCol
        {
            set
            {
                _AllUnitCol = value;
            }
            get
            {
                if (_AllUnitCol == null)
                {
                    _AllUnitCol = new ReservationUnitCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = ReservationDb.CachUnitTable.Select("ReservationID=" + ID);
                        UnitCellCol objTempCell;
                        foreach (DataRow objDr in arrDr)
                        {
                            ReservationUnitBiz objBiz = new ReservationUnitBiz(objDr);
                            objTempCell = objBiz.UnitBiz.CellCol;

                            _AllUnitCol.Add(objBiz);
                        }
                    }
                }
                return _AllUnitCol;
            }
        }
        public string DeliveryDateStr
        {
            get
            {
                string Returned = "";
                ReservationUnitCol objDeliveredCol = new ReservationUnitCol(true);
                foreach (ReservationUnitBiz objBiz in UnitCol)
                {
                    if (objBiz.UnitBiz.IsDelivered)
                        objDeliveredCol.Add(objBiz);
                }
                if (objDeliveredCol.Count > 0 && objDeliveredCol.Count == UnitCol.Count)
                {
                    Returned = " „ «· ”·Ì„ » «—ÌŒ:" + objDeliveredCol[0].UnitBiz.DeliveryDate.
                        ToString("yyyy-MM-dd");
                }
                else if (objDeliveredCol.Count > 0)
                {
                    Returned = " „  ”·Ì„:" + objDeliveredCol.UnitFullName + " » «—ÌŒ: " +
                        objDeliveredCol[0].UnitBiz.DeliveryDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    if (_ReservationDb.TowerIsDelivered)
                        Returned = " „  ”·Ì„ «·»—Ã Ê·„ Ì „  ”·Ì„ «·ÊÕœ… ";
                    else
                    {
                        objDeliveredCol = new ReservationUnitCol(true);
                        foreach (ReservationUnitBiz objBiz in UnitCol)
                        {
                            if (objBiz.UnitBiz.IsReadyForDelivery)
                                objDeliveredCol.Add(objBiz);
                        }
                        if (objDeliveredCol.Count > 0)
                            Returned = "«·ÊÕœ«  Ã«Â“… ·· ”·Ì„(" + objDeliveredCol.UnitFullName + ")";
                    }

                }
                
                return Returned;
            }
        }
        public BranchBiz BranchBiz
        {
            set
            {
                _BranchBiz = value;
            }
            get
            {
                return _BranchBiz;
            }
        }
        BrandBiz _BrandBiz;
        public BrandBiz BrandBiz
        {
            set => _BrandBiz = value;
            get { if (_BrandBiz == null) _BrandBiz = new BrandBiz();return _BrandBiz; }
        }
        public CustomerBiz CustomerBiz
        {
            set
            {
                _CustomerBiz = value;
            }
            get
            {
                if (_CustomerBiz == null)
                {
                    if (CustomerCol.Count > 0)
                        _CustomerBiz = _CustomerCol[0];
                    else
                    _CustomerBiz = new CustomerBiz();
                }
                    return _CustomerBiz;
            }
        }
        public CustomerCol CustomerCol
        {
            set
            {
                _CustomerCol = value;
            }
            get
            {
                if (_CustomerCol == null)
                {
                    _CustomerCol = new CustomerCol(true);
                    if (ID != 0)
                    {
                        if (ReservationDb.cachCustomerTable != null)
                        {
                            DataRow[] arrDr = ReservationDb.cachCustomerTable.Select("ReservationID=" + ID);
                            // DataTable dtTemp = _ReservationDb.GetCustomer();
                            foreach (DataRow objDr in arrDr)
                            {
                                CustomerBiz objBiz = new CustomerBiz(objDr);
                                _CustomerCol.Add(objBiz);
                            }
                        }
                    }
                }
                return _CustomerCol;
            }
        }

        public CustomerCol AllCustomerCol
        {
            set
            {
                _AllCustomerCol = value;
            }
            get
            {
                if (_AllCustomerCol == null)
                {
                    _AllCustomerCol = new CustomerCol(true);
                    if (ID != 0)
                    {
                        if (ReservationDb.cachCustomerTable != null)
                        {
                            DataRow[] arrDr = ReservationDb.cachCustomerTable.Select("ReservationID=" + ID);
                            // DataTable dtTemp = _ReservationDb.GetCustomer();
                            foreach (DataRow objDr in arrDr)
                            {
                                CustomerBiz objBiz = new CustomerBiz(objDr);
                                _AllCustomerCol.Add(objBiz);
                            }
                        }
                    }
                }
                return _AllCustomerCol;
            }
        }
        public MulctPaymentCol MulctPaymentCol
        {
            set
            {
                _MulctPaymentCol = value;
            }
            get
            {
                if (_MulctPaymentCol == null)
                {
                    _MulctPaymentCol = new MulctPaymentCol(true);
                    if (ID != 0)
                    {
                        if (ReservationDb.CachMulctPaymentTable != null)
                        {
                            DataRow[] arrDr = ReservationDb.CachMulctPaymentTable.Select("PaymentReservation=" + ID);
                            MulctPaymentBiz objTemp;
                            foreach (DataRow objDr in arrDr)
                            {
                                objTemp = new MulctPaymentBiz(objDr);
                                objTemp.ReservationBiz = this;
                                _MulctPaymentCol.Add(objTemp);
                            }
                        }

                    }
                }
                return _MulctPaymentCol;
            }
        }
        public StrategyInstallmentCol InstallmentTypeCol
        {
            set
            {
                _InstallmentTypeCol = value;
            }
            get
            {
                if (_InstallmentTypeCol == null)
                {
                    _InstallmentTypeCol = new StrategyInstallmentCol(true);

                    if (ID != 0)
                    {
                        string strGroupID = "0";

                        StrategyInstallmentBiz objTypeBiz = new StrategyInstallmentBiz();
                        _InstallmentTypeCol = new StrategyInstallmentCol(true);
                        DataRow[] arrPaymentDr;
                        #region Get Reservation Mulcts
                        _InstallmentMulctCol = new InstallmentMulctCol(true);
                        #endregion
                        #region InstallmentDiscount
                        InstallmentDiscountBiz objDiscountBiz;
                        #endregion
                        ReservationInstallmentBiz objInstallmentBiz;
                        DataRow[] arrDr = ReservationDb.CachInstallmentTable.Select("ReservationID=" + ID, "InstallmentGroup,InstallmentDueDate");
                        foreach (DataRow objDr in arrDr)
                        {
                            if (strGroupID != objDr["InstallmentGroup"].ToString())
                            {
                                if (objTypeBiz.TypeBiz.ID != 0)
                                {
                                    objTypeBiz.InstallmentValue = objTypeBiz.InstallmentCol.Value;
                                    objTypeBiz.InstallmentNo = objTypeBiz.InstallmentCol.Count;
                                }
                                strGroupID = objDr["InstallmentGroup"].ToString();
                                objTypeBiz = new StrategyInstallmentBiz();

                                objTypeBiz.InstallmentCol = new ReservationInstallmentCol(true);
                                _InstallmentTypeCol.Add(objTypeBiz);

                            }

                            objTypeBiz.TypeBiz = new InstallmentTypeBiz(objDr);
                            objInstallmentBiz = new ReservationInstallmentBiz(objDr);
                            objInstallmentBiz.Reservation = this;
                            arrPaymentDr = ReservationDb.CachInstallmentPaymentTable.Select("InstallmentID= " + objInstallmentBiz.ID, "");
                            objInstallmentBiz.PaymentCol = new InstallmentPaymentCol(true);
                            objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                            InstallmentPaymentBiz objPaymentBiz;
                            foreach (DataRow objPaymentDr in arrPaymentDr)
                            {
                                objPaymentBiz = new InstallmentPaymentBiz(objPaymentDr);
                                objPaymentBiz.InstallmentBiz = objInstallmentBiz;
                                objInstallmentBiz.PaymentCol.Add(objPaymentBiz);
                            }
                            DataRow[] arrDiscountDr = ReservationDb.CachInstallmentDiscountTable.Select("InstallmentID=" + objInstallmentBiz.ID);
                            foreach (DataRow objDiscountDr in arrDiscountDr)
                            {
                                objDiscountBiz = new InstallmentDiscountBiz(objDiscountDr);
                                objDiscountBiz.InstallmentBiz = objInstallmentBiz;
                                objInstallmentBiz.InstallmentDiscountCol.Add(objDiscountBiz);
                            }
                            DataRow[] arrMulctDr = ReservationDb.CachInstallmentMulctTable.Select("InstallmentID=" + objInstallmentBiz.ID);
                            InstallmentMulctBiz objTempMulctBiz;
                            if (_InstallmentMulctCol == null)
                                _InstallmentMulctCol = new InstallmentMulctCol(true);
                            foreach (DataRow objMulctDr in arrMulctDr)
                            {
                                objTempMulctBiz = new InstallmentMulctBiz(objMulctDr);
                                objTempMulctBiz.InstallmentBiz = objInstallmentBiz;

                                _InstallmentMulctCol.Add(objTempMulctBiz);

                            }
                            objTypeBiz.InstallmentCol.Add(objInstallmentBiz);
                            _LinearMode = false;

                        }



                    }
                }
                int intIndex = 0;
                while (intIndex < _InstallmentTypeCol.Count)
                {
                    if (_InstallmentTypeCol[intIndex].InstallmentCol.Count == 0)
                        _InstallmentTypeCol.RemoveAt(intIndex);
                    intIndex++;
                }
                return _InstallmentTypeCol;
            }
        }
        public ReservationInstallmentCol LinearInstallmentCol
        {
            set
            {
                _LinearInstallmentCol = value;
            }
            get
            {
                if (_LinearInstallmentCol == null)
                {
                    ReservationInstallmentBiz objInstallmentBiz;
                    ReservationInstallmentBiz objTempInstallment = new ReservationInstallmentBiz();
                    int intTmpInstallment = 0;
                    DataRow[] arrPaymentDr;
                    InstallmentPaymentBiz objPaymentBiz;
                    InstallmentDiscountBiz objDiscountBiz;
                    _LinearInstallmentCol = new ReservationInstallmentCol(true);
                    DataRow[] arrDr;
                    if (ID != 0)
                    {
                        if (ReservationDb.CachInstallmentTable != null)
                        {
                         
                            Hashtable hsInstallment = new Hashtable();
                                arrDr = ReservationDb.CachInstallmentTable
                                      .Select("ReservationID=" + ID, "InstallmentStatus,InstallmentDueDate,InstallmentGroup");
                                foreach (DataRow objDr in arrDr)
                                {
                                    objInstallmentBiz = new ReservationInstallmentBiz(objDr);
                                    objInstallmentBiz.Reservation = this;
                                    objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                                   hsInstallment.Add(objInstallmentBiz.ID.ToString(),objInstallmentBiz);
                                  
                                    _LinearInstallmentCol.Add(objInstallmentBiz);

                                }
                                objInstallmentBiz = new ReservationInstallmentBiz();
                                if (!_StopPayment)
                                {
                                    arrPaymentDr = ReservationDb.CachInstallmentPaymentTable.Select("ReservationID=" + ID, "InstallmentID");
                                    objInstallmentBiz.PaymentCol = new InstallmentPaymentCol(true);
                                    objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                                    foreach (DataRow objPaymentDr in arrPaymentDr)
                                    {
                                        objPaymentBiz = new InstallmentPaymentBiz(objPaymentDr);
                                        //objPaymentBiz.
                                        if (objPaymentBiz.InstallmentID != intTmpInstallment)
                                        {
                                            intTmpInstallment = objPaymentBiz.InstallmentID;
                                            objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];
                                            if (objTempInstallment.ID == 2881433)
                                                intTmpInstallment = intTmpInstallment;
                                            // objTempInstallment.PaymentCol.Add(objPaymentBiz);
                                        }
                                        objPaymentBiz.InstallmentBiz = objTempInstallment;
                                        objTempInstallment.PaymentCol.Add(objPaymentBiz);
                                    }
                                }
                                if (!_StopDiscount)
                                {
                                    DataRow[] arrDiscountDr = ReservationDb.CachInstallmentDiscountTable.Select("ReservationID=" +
                                       ID, "InstallmentID");
                                    intTmpInstallment = 0;
                                    foreach (DataRow objDiscountDr in arrDiscountDr)
                                    {
                                        objDiscountBiz = new InstallmentDiscountBiz(objDiscountDr);
                                        if (objDiscountBiz.InstallmentID != intTmpInstallment)
                                        {
                                            intTmpInstallment = objDiscountBiz.InstallmentID;
                                            objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];

                                            //objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                        }
                                        objDiscountBiz.InstallmentBiz = objTempInstallment;
                                        objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                    }
                                }
                                if (!_StopMulct)
                                {
                                    DataRow[] arrMulctDr = ReservationDb.CachInstallmentMulctTable.Select("ReservationID=" + ID, "InstallmentID");
                                    InstallmentMulctBiz objTempMulctBiz;
                                    if (_InstallmentMulctCol == null)
                                        _InstallmentMulctCol = new InstallmentMulctCol(true);
                                    foreach (DataRow objMulctDr in arrMulctDr)
                                    {
                                        objTempMulctBiz = new InstallmentMulctBiz(objMulctDr);

                                        if (objTempMulctBiz.InstallmentID != intTmpInstallment)
                                        {
                                            intTmpInstallment = objTempMulctBiz.InstallmentID;
                                            objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];

                                            //objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                        }
                                        objTempMulctBiz.InstallmentBiz = objTempInstallment;
                                        objTempMulctBiz.ReservationBiz = this;

                                        _InstallmentMulctCol.Add(objTempMulctBiz);

                                    }
                                }




                            }
                             
                        }
                }
                    
                _LinearMode = true;

                return _LinearInstallmentCol;
            }
        }
        public ReservationInstallmentCol LinearInstallmentCol1
        {
            set
            {
                _LinearInstallmentCol = value;
            }
            get
            {
                if (_LinearInstallmentCol == null)
                {
                    ReservationInstallmentBiz objInstallmentBiz;
                    ReservationInstallmentBiz objTempInstallment = new ReservationInstallmentBiz();
                    int intTmpInstallment = 0;
                    DataRow[] arrPaymentDr;
                    InstallmentPaymentBiz objPaymentBiz;
                    InstallmentDiscountBiz objDiscountBiz;
                    _LinearInstallmentCol = new ReservationInstallmentCol(true);
                    DataRow[] arrDr;
                    if (ID != 0)
                    {
                        if (ReservationDb.CachInstallmentTable != null)
                        {

                            Hashtable hsInstallment = new Hashtable();
                            arrDr = ReservationDb.CachInstallmentTable
                                  .Select("ReservationID=" + ID, "InstallmentStatus,InstallmentDueDate,InstallmentGroup");
                            foreach (DataRow objDr in arrDr)
                            {
                                objInstallmentBiz = new ReservationInstallmentBiz(objDr);
                                objInstallmentBiz.Reservation = this;
                                objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                                hsInstallment.Add(objInstallmentBiz.ID.ToString(), objInstallmentBiz);

                                _LinearInstallmentCol.Add(objInstallmentBiz);

                            }
                            objInstallmentBiz = new ReservationInstallmentBiz();
                            if (!_StopPayment)
                            {
                                arrPaymentDr = ReservationDb.CachInstallmentPaymentTable.Select("ReservationID=" + ID, "InstallmentID");
                                objInstallmentBiz.PaymentCol = new InstallmentPaymentCol(true);
                                objInstallmentBiz.InstallmentDiscountCol = new InstallmentDiscountCol(true);
                                foreach (DataRow objPaymentDr in arrPaymentDr)
                                {
                                    objPaymentBiz = new InstallmentPaymentBiz(objPaymentDr);
                                    //objPaymentBiz.
                                    if (objPaymentBiz.InstallmentID != intTmpInstallment)
                                    {
                                        intTmpInstallment = objPaymentBiz.InstallmentID;
                                        objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];

                                        // objTempInstallment.PaymentCol.Add(objPaymentBiz);
                                    }
                                    objPaymentBiz.InstallmentBiz = objTempInstallment;
                                    objTempInstallment.PaymentCol.Add(objPaymentBiz);
                                }
                            }
                            if (!_StopDiscount)
                            {
                                DataRow[] arrDiscountDr = ReservationDb.CachInstallmentDiscountTable.Select("ReservationID=" +
                                   ID, "InstallmentID");
                                intTmpInstallment = 0;
                                foreach (DataRow objDiscountDr in arrDiscountDr)
                                {
                                    objDiscountBiz = new InstallmentDiscountBiz(objDiscountDr);
                                    if (objDiscountBiz.InstallmentID != intTmpInstallment)
                                    {
                                        intTmpInstallment = objDiscountBiz.InstallmentID;
                                        objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];

                                        //objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                    }
                                    objDiscountBiz.InstallmentBiz = objTempInstallment;
                                    objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                }
                            }
                            if (!_StopMulct)
                            {
                                DataRow[] arrMulctDr = ReservationDb.CachInstallmentMulctTable.Select("ReservationID=" + ID, "InstallmentID");
                                InstallmentMulctBiz objTempMulctBiz;
                                if (_InstallmentMulctCol == null)
                                    _InstallmentMulctCol = new InstallmentMulctCol(true);
                                foreach (DataRow objMulctDr in arrMulctDr)
                                {
                                    objTempMulctBiz = new InstallmentMulctBiz(objMulctDr);

                                    if (objTempMulctBiz.InstallmentID != intTmpInstallment)
                                    {
                                        intTmpInstallment = objTempMulctBiz.InstallmentID;
                                        objTempInstallment = (ReservationInstallmentBiz)hsInstallment[intTmpInstallment.ToString()];

                                        //objTempInstallment.InstallmentDiscountCol.Add(objDiscountBiz);
                                    }
                                    objTempMulctBiz.InstallmentBiz = objTempInstallment;


                                    _InstallmentMulctCol.Add(objTempMulctBiz);

                                }
                            }




                        }
                    }
                }

                _LinearMode = true;
                return _LinearInstallmentCol;
            }
        }

        public ReservationInstallmentCol NonCheckedInstallmentCol
        {
            set
            {
                _NonCheckedInstallmentCol = value;
            }
            get
            {
                if (_NonCheckedInstallmentCol == null)
                {
                    SetNonCheckedInstallmentCol();

                }
                return _NonCheckedInstallmentCol;
            }
        }
        public InstallmentCheckCol CheckCol
        {
            set
            {
                _CheckCol = value;
            }
            get
            {
                if (_CheckCol == null)
                {
                    SetNonCheckedInstallmentCol();
                }
                return _CheckCol;
            }
        }
        public double VirtualInstallmentPaidValue
        {
            get
            {
                double Returned = 0;
                double dblDiscount = 0;
                if (_LinearMode)
                {
                    dblDiscount = LinearInstallmentCol.Discountvalue;
                    Returned = LinearInstallmentCol.PaidValue;
                }
                else
                {
                    dblDiscount = InstallmentTypeCol.TotalDiscountValue;
                    Returned = InstallmentTypeCol.TotalPaidValue;
                }
                Returned = Returned + dblDiscount;
                return Returned;
            }
        }
       
        public double VirtualPracticalInstallmentPaidValue
        {
            get
            {
                double Returned = 0;
              
                if (_LinearMode)
                {
                   
                    Returned = LinearInstallmentCol.PaidValue;
                }
                else
                {
                    Returned = InstallmentTypeCol.TotalPaidValue;
                }
                Returned = Returned ;
                return Returned;
            }
        }
        public double VirtualTotalCheckValue
        {
            get
            {
                double Returned = 0;

                if (_LinearMode)
                {

                    Returned = LinearInstallmentCol.TotalCheckValue;
                }
                else
                {
                    Returned = InstallmentTypeCol.TotalCheckValue;
                }
                Returned = Returned;
                return Returned;
            }
        }
        public double VirtualTotalCollectedCheckValue
        {
            get
            {
                double Returned = 0;

                if (_LinearMode)
                {

                    Returned = LinearInstallmentCol.TotalCollectedCheckValue;
                }
                else
                {
                    Returned = InstallmentTypeCol.TotalCheckValue;
                }
                Returned = Returned;
                return Returned;
            }
        }
        public double VirtualTotalInstallmentValue
        {
            get
            {
                double Returned = 0;
                if (_LinearMode)
                    Returned = LinearInstallmentCol.Value;
                else
                    Returned = InstallmentTypeCol.SumInstallmentValue;
                return Returned;
            }
        }
        public InstallmentMulctCol InstallmentMulctCol
        {
            set
            {
                _InstallmentMulctCol = value;
            }
            get
            {
                if (_InstallmentMulctCol == null)
                {
                    _InstallmentMulctCol = new InstallmentMulctCol(true);
                    ReservationInstallmentCol objTemp =
                        LinearInstallmentCol;//note in LinearInstallment get it set InstallmentMulctCol
                }
                return _InstallmentMulctCol;
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
                    _InstallmentDiscountCol = new InstallmentDiscountCol(true);
                return _InstallmentDiscountCol;
            }
        }
        public ReservationUtilityCol UtilityCol
        {
            set
            {
                _UtilityCol = value;
            }
            get
            {
                if (_UtilityCol == null)
                {
                    _UtilityCol = new ReservationUtilityCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = ReservationDb.CachUtilityTable.Select("ReservationID=" + ID);
                        DataRow[] arrPayDr;
                        ReservationUtilityBiz objUtilityBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objUtilityBiz = new ReservationUtilityBiz(objDr);
                            objUtilityBiz.ReservationBiz = this;
                            objUtilityBiz.PaymentCol = new UtilityPaymentCol(true);
                            arrPayDr = ReservationDb.CachUtilityPaymentTable.Select("UtilityID=" + objUtilityBiz.ID);
                            foreach (DataRow objTempDr in arrPayDr)
                                objUtilityBiz.PaymentCol.Add(new UtilityPaymentBiz(objTempDr));
                            _UtilityCol.Add(objUtilityBiz);
                        }
                    }
                }
                return _UtilityCol;

            }
        }
        public ReservationDiscountCol DiscountCol
        {
            set
            {
                _DiscountCol = value;
            }
            get
            {
                if (_DiscountCol == null)
                {
                    _DiscountCol = new ReservationDiscountCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = ReservationDb.CachDiscountTable.Select("ReservationID=" + ID);
                        ReservationDiscountBiz objDiscountBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objDiscountBiz = new ReservationDiscountBiz(objDr);
                            objDiscountBiz.ReservationBiz = this;
                            _DiscountCol.Add(objDiscountBiz);
                        }
                    }
                }
                return _DiscountCol;
            }
        }

        public ReservationBonusCol BonusCol
        {
            set
            {
                _BonusCol = value;
            }
            get
            {
                if (_BonusCol == null)
                {
                    _BonusCol = new ReservationBonusCol(true);
                    if (ID != 0)
                    {

                        DataRow[] arrDr = ReservationDb.CachBonusTable.Select("ReservationID=" + ID);

                        ReservationBonusBiz objBonusBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objBonusBiz = new ReservationBonusBiz(objDr);
                            objBonusBiz.ReservationBiz = this;
                            _BonusCol.Add(objBonusBiz);
                        }
                    }
                }
                return _BonusCol;
            }
        }
        public TempReservationPaymentCol PaymentCol
        {
            set
            {
                _PaymentCol = value;
            }
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new TempReservationPaymentCol(true);
                    if (ID != 0)
                    {
                     
                        DataRow[] arrDr = ReservationDb.CachTempPaymentTable.Select("ReservationID=" + ID);
                        TempReservationPaymentBiz objPaymentBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objPaymentBiz = new TempReservationPaymentBiz(objDr);
                            objPaymentBiz.ReservationBiz = this;
                            _PaymentCol.Add(objPaymentBiz);

                        }

                    }
                }
                return _PaymentCol;
            }
        }
        public AdministrativeCostPaymentCol AdministrativePaymentCol
        {
            set
            {
                _AdministrativePaymentCol = value;
            }
            get
            {
                if (_AdministrativePaymentCol == null)
                {
                    _AdministrativePaymentCol = new AdministrativeCostPaymentCol(true);
                    if (ID != 0)
                    {
                        if (ReservationDb.CachAdministrativePaymentTable != null)
                        {
                            DataRow[] arrDr = ReservationDb.CachAdministrativePaymentTable.Select("ReservationID=" + ID);
                            AdministrativeCostPaymentBiz objPaymentBiz;
                            foreach (DataRow objDr in arrDr)
                            {
                                objPaymentBiz = new AdministrativeCostPaymentBiz(objDr);
                                objPaymentBiz.ReservationBiz = this;
                                _AdministrativePaymentCol.Add(objPaymentBiz);

                            }
                        }

                    }
                }
                return _AdministrativePaymentCol;
            }
        }
        public InsurancePaymentCol InsurancePaymentCol
        {
            set
            {
                _InsurancePaymentCol = value;
            }
            get
            {
                if (_InsurancePaymentCol == null)
                {
                    _InsurancePaymentCol = new InsurancePaymentCol(true);
                    if (ID != 0)
                    {

                        DataRow[] arrDr = ReservationDb.CachInsurancePaymentTable.Select("ReservationID=" + ID);
                        InsurancePaymentBiz objPaymentBiz;
                        foreach (DataRow objDr in arrDr)
                        {
                            objPaymentBiz = new InsurancePaymentBiz(objDr);
                            objPaymentBiz.ReservationBiz = this;
                            _InsurancePaymentCol.Add(objPaymentBiz);

                        }

                    }
                }
                return _InsurancePaymentCol;
            }
        }
        
        public WorkerContributionCol WorkerCol
        {
            set
            {
                _WorkerCol = value;
            }
            get
            {
                if (_WorkerCol == null)
                {
                    _WorkerCol = new WorkerContributionCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = ReservationDb.CachWorkerTable.Select("ReservationID=" + ID);
                        foreach (DataRow objDr in arrDr)
                        {
                            _WorkerCol.Add(new WorkerContributionBiz(objDr));
                        }
                    }
                }
                return _WorkerCol;
            }
        }
       
        public ReservationAttachmentCol ReservationAttachmentCol
        {
            set
            {
                _ReservationAttachmentCol = value;
            }
            get
            {
                if (_ReservationAttachmentCol == null)
                {
                    _ReservationAttachmentCol = new ReservationAttachmentCol(true);
                    if (_ReservationDb.ID != 0)
                    {
                        ReservationAttachmentDb objDb = new ReservationAttachmentDb();
                        objDb.ReservationID = _ReservationDb.ID;
                        DataTable dtTemp = objDb.Search();
                        try
                        {
                            DataRow[] arrDr = dtTemp.Select();//ReservationDb.CachAttachmentTable.Select("ReservationID=" + ID);

                            ReservationAttachmentBiz objTempBiz;
                            foreach (DataRow objDr in arrDr)
                            {
                                objTempBiz = new ReservationAttachmentBiz(objDr);
                                objTempBiz.ReservationBiz = this;
                                _ReservationAttachmentCol.Add(objTempBiz);
                            }
                        }
                        catch
                        { }
                    }
                }
                return _ReservationAttachmentCol;
            }

        }
        public double ContributionValue
        {
            set
            {
                _ReservationDb.ContributionValue = value;
            }
            get
            {
                return _ReservationDb.ContributionValue;
            }

        }
        public double ContributionPerc
        {
            set
            {
                _ReservationDb.ContributionPerc = value;
            }
            get
            {
                return _ReservationDb.ContributionPerc;
            }

        }
        public double UnitPrice
        {
            set
            {
                _ReservationDb.UnitPrice = value;
            }
            get
            {
                return _ReservationDb.UnitPrice;
            }

        }
        public double CachePrice
        {
            set
            {
                if (UnitCol.CachPrice == 0)
                    _ReservationDb.CachePrice = value;
                else
                    _ReservationDb.CachePrice = 0;

            }
            get
            {


                return UnitCol.CachPrice == 0 ? _ReservationDb.CachePrice :
                 UnitCol.CachPrice;

            }

        }
        public FinishingType Finishing
        {
            set
            {
                _ReservationDb.Finishing = (int)value;
            }
            get
            {
                return (FinishingType)_ReservationDb.Finishing;
            }

        }
        public bool ProfitIsCompound
        {
            set
            {
                _ReservationDb.ProfitIsCompound = value;
            }
            get
            {
                return _ReservationDb.ProfitIsCompound;
            }

        }
        public double ProfitValue
        {
            set
            {
                _ReservationDb.ProfitValue = value;
            }
            get
            {
                return _ReservationDb.ProfitValue;
            }

        }
        public Period ProfitPeriod
        {
            set
            {
                _ReservationDb.ProfitPeriod = (int)value;
            }
            get
            {
                return (Period)_ReservationDb.ProfitPeriod;
            }

        }
        public double PeriodAmount
        {
            set
            {
                _ReservationDb.PeriodAmount = value;
            }
            get
            {
                return _ReservationDb.PeriodAmount;
            }

        }
        public Period Period
        {
            set
            {
                _ReservationDb.Period = (int)value;
            }
            get
            {
                return (Period)_ReservationDb.Period;
            }

        }
        public bool IsFree
        {
            set
            {
                _ReservationDb.IsFree = value;
            }
            get
            {
                return _ReservationDb.IsFree;
            }
        }
        public bool IsNew
        {
            set
            {
                _ReservationDb.IsNew = value;
            }
            get
            {
                return _ReservationDb.IsNew;
            }
        }
        public bool IsDelegated
        {
            set
            {
                _ReservationDb.IsDelegated = value;
            }
            get
            {
                return _ReservationDb.IsDelegated;
            }
        }
        public bool IsReservedAgain
        {
            set
            {
                _ReservationDb.IsReservedAgain = value;
            }
            get
            {
                return _ReservationDb.IsReservedAgain;
            }
        }
        public DateTime DelegationDate
        {
            set
            {
                _ReservationDb.DelegationDate = value;
            }
            get
            {
                return _ReservationDb.DelegationDate;
            }
        }
        public int FreeStatus
        {
            set
            {
                _ReservationDb.FreeStatus = value;
            }
            get
            {
                return _ReservationDb.FreeStatus;
            }
        }
        public bool IsDelivered
        {
            get
            {
                return _ReservationDb.IsDelivered;
            }
        }
        public double BonusValue
        {
           get
            {
                return _ReservationDb.BonusValue;
           }
        }
        public double DiscountValue
        {
            get
            {
                return _ReservationDb.DiscountValue;
            }
        }
        public double UtilityValue
        {
            get
            {
                return _ReservationDb.UtilityValue;
            }
        }
        public double InstallmentDiscountValue
        {
            get
            {
                return _ReservationDb.InstallmentDiscountValue;
            }
        }
        public double InstallmentPaidValue
        {
            get
            {
                return _ReservationDb.InstallmentPaymentValue;
            }
        }
        public double InstallmentDeservedValue
        {
            get
            {
                return _ReservationDb.InstallmentDeservedValue;
            }
        }
        public double VirtualTotalvalue
        {
            get
            {
                double Returned = 0;
                double dblValue = CachePrice == 0 ? (UnitPrice * UnitCol.TotalSurvey) : CachePrice;
                double dblProfitValue = PeriodBiz.GetSimpleProfit(dblValue,
                    ProfitPeriodAmount, new PeriodBiz(Period), ProfitValue,
                    new PeriodBiz(ProfitPeriod));

                Returned = dblValue - PreviousPaidValue + dblProfitValue;
                return Returned;
            }

        }
        public double VirtualNetvalue
        {
            get
            {
                double Returned = 0;
                double dblValue = CachePrice == 0 ? (UnitPrice * UnitCol.TotalSurvey) : CachePrice;
                double dblProfitValue = PeriodBiz.GetSimpleProfit(dblValue,
                    ProfitPeriodAmount, new PeriodBiz(Period), ProfitValue,
                    new PeriodBiz(ProfitPeriod));

                Returned = dblValue - PreviousPaidValue + dblProfitValue;
                Returned += BonusValue + UtilityValue - DiscountValue;
                return Returned;
            }

        }
        public int CampaignCustomer
        {
            set
            {
                _CampaignCustomer = value;
            }
            get
            {
                return _CampaignCustomer;
            }
        }
        public CampaignCustomerMonitorCol MonitorCol
        {
            get
            {
                if (_MonitorCol == null)
                {
                    _MonitorCol = new CampaignCustomerMonitorCol(true);
                    if (_CampaignCustomer != 0)
                    {
                        CampaignCustomerMonitorDb objDb = new CampaignCustomerMonitorDb();
                        objDb.CampaignCustomer = _CampaignCustomer;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _MonitorCol.Add(new CampaignCustomerMonitorBiz(objDr));
                        }
                    }
                }
                return _MonitorCol;
            }
        }
        public CampaignCustomerContactCol ContactCol
        {
            get
            {
                if (_ContactCol == null)
                {
                    _ContactCol = new CampaignCustomerContactCol(true);
                    if (_CampaignCustomer != 0)
                    {
                        CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
                        objDb.CampaignCustomerID = _CampaignCustomer;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ContactCol.Add(new CampaignCustomerContactBiz(objDr));
                        }
                    }
                }
                return _ContactCol;
            }
        }
        internal ReservationResubmissionCol _ResubmissionCol;

        public ReservationResubmissionCol ResubmissionCol
        {
            get
            {
                if (_ResubmissionCol == null)
                {
                    _ResubmissionCol = new ReservationResubmissionCol(true);
                    ReservationResubmissionDb objDb = new ReservationResubmissionDb();
                    objDb.ReservationID = ID;
                    objDb.ResubmissionStatus = 1;
                    objDb.AllResubmission = true;
                    DataTable dtTemp = objDb.Search();
                    DataRow[] arrDr = dtTemp.Select("", "ResubmissionDate desc");
                    ReservationResubmissionBiz objBiz ;
                    foreach (DataRow objDr in arrDr)
                    {
                        objBiz = new ReservationResubmissionBiz(objDr);
                        objBiz.ReservationBiz = this;
                        _ResubmissionCol.Add(objBiz);
                    }

                }
                return _ResubmissionCol;
            }
            set { _ResubmissionCol = value; }
        }
        ReservationResubmissionBiz _ResubmissionBiz;

        public ReservationResubmissionBiz ResubmissionBiz
        {
            get {
                if (_ResubmissionBiz == null)
                    _ResubmissionBiz = new ReservationResubmissionBiz();
                return _ResubmissionBiz; }
            set { _ResubmissionBiz = value; }
        }
        CampaignCustomerBiz _CampaignCustomerBiz;
        public CampaignCustomerBiz CampaignCustomerBiz
        {
            set { _CampaignCustomerBiz = value; }
            get
            { if (_CampaignCustomerBiz == null)
                    _CampaignCustomerBiz = new CampaignCustomerBiz();
                return _CampaignCustomerBiz;
            }
        }
        #region Tenancy Properties
        public bool IsTenancy
        {
            set => _ReservationDb.IsTenancy = value;get => _ReservationDb.IsTenancy;
        }
        public int TenancyID
        {
            set
            {
                _ReservationDb.TenancyID = value;
            }
            get
            {
                return _ReservationDb.TenancyID;
            }
        }
        public DateTime TenancyStartDate
        {
            set
            {
                _ReservationDb.TenancyStartDate = value;
            }
            get
            {
                return _ReservationDb.TenancyStartDate;
            }
        }
        public DateTime TenancyEndDate
        {
            set
            {
                _ReservationDb.TenancyEndDate = value;
            }
            get
            {
                return _ReservationDb.TenancyEndDate;
            }
        }
        public bool TenancyIsAutomaticCancelation
        {
            set
            {
                _ReservationDb.IsAutomaticCancelation = value;
            }
            get
            {
                return _ReservationDb.IsAutomaticCancelation;
            }
        }

        public double TenancyStartValue
        {
            set
            {
                _ReservationDb.TenancyStartValue = value;
            }
            get
            {
                return _ReservationDb.TenancyStartValue;
            }
        }
        public int TenancyFrequncyPeriod
        {
            set
            {
                _ReservationDb.TenancyFrequncyPeriod = value;
            }
            get
            {
                return _ReservationDb.TenancyFrequncyPeriod;
            }
        }
        public int TenancyChangeFrequencyPeriod
        {
            set
            {
                _ReservationDb.TenancyChangeFrequencyPeriod = value;
            }
            get
            {
                return _ReservationDb.TenancyChangeFrequencyPeriod;
            }
        }
        public double TenancyChangePerc
        {
            set
            {
                _ReservationDb.TenancyChangePerc = value;
            }
            get
            {
                return _ReservationDb.TenancyChangePerc;
            }
        }
      
        #endregion Tenancy

        #region NewContactData
        public string CustomerHomePhone
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.HomePhone;
                }
                return Returned;
            }
        }
        public string CustomerWorkPhone
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.WorkPhone;
                }
                return Returned;
            }
        }
        public string CustomerFirstMobile
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.Mobile;
                }
                return Returned;
            }
        }
        public string CustomerSecondMobile
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.SecondMobile;
                }
                return Returned;
            }
        }
        public string CustomerHomeAddress
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.Address;
                }
                return Returned;
            }
        }
        public string CustomerWorkAddress
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.WorkAddress;
                }
                return Returned;
            }
        }

        public string CustomerHomeCity
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.HomeCityName;
                }
                return Returned;
            }
        }
        public string CustomerWorkCity
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.WorkCityName;
                }
                return Returned;
            }
        }
        public string CustomerWorkCuntry
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.WorkCountryName;
                }
                return Returned;
            }
        }
        public string CustomerHomeCuntry
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.HomeCountryName;
                }
                return Returned;
            }
        }
        public string CustomerHomeRegion
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.HomeRegionName;
                }
                return Returned;
            }
        }
        public string CustomerWorkRegion
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    Returned += objBiz.WorkRegionName;
                }
                return Returned;
            }
        }



        #endregion

        #region Contact Data
        public string CustomerPhone1
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(1).Count > 0)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(1)[0].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
        }
        public string CustomerPhone2
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(1).Count > 1)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(1)[1].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
        }
        public string CustomerMob1
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(2).Count >0)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(2)[0].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
        }
        public string CustomerMob2
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(2).Count > 1)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(2)[1].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
        }
        public string CustomerAddress
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(6).Count > 0)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(6)[0].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
 
        }
        public string CustomerEmail
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    //if (objBiz.CustomerContactCol.GetInstantCol(3).Count > 0)
                    //{
                    //    Returned += objBiz.CustomerContactCol.GetInstantCol(3)[0].ContactValue;

                    //}
                    //else
                    //    Returned += "-";
                }
                return Returned;
            }
        }
        public string CustomerPassport
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in CustomerCol)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.IDTypeInstantBiz.IDValue;
                }
                return Returned;
            }
        }
        
        #endregion
        #region LinearDisplayData
        public string DisplayedUnitCode
        {
            get
            {
                return _ReservationDb.UnitCode;
            }
        }
        public string DisplayedTowerName
        {
            get
            {
                return _ReservationDb.TowerName;
            }
        }
        public string DisplayedProjectName
        {
            get
            {
                return _ReservationDb.ProjectName;
            }
        }
        public double TempPayment
        {
            set
            {
                _ReservationDb.TempPayment = value;
            }
            get
            {
                return _ReservationDb.TempPayment;
            }
        }
        public double InsuranceInPayment
        {
            set
            {
                _ReservationDb.InsuranceInPayment = value;
            }
            get
            {
                return _ReservationDb.InsuranceInPayment;
            }
        }
        public double InsuranceOutPayment
        {
            set
            {
                _ReservationDb.InsuranceOutPayment = value;
            }
            get
            {
                return _ReservationDb.InsuranceOutPayment;
            }
        }
        public double AdministrativePaymentValue
        {
            set
            {
                _ReservationDb.AdministrativePaymentValue = value;
            }
            get
            {
                return _ReservationDb.AdministrativePaymentValue;
            }
        }
        public double RemainingValue
        {
            get
            {
                return _ReservationDb.RemainingValue;
            }
        }
        public double TotalPaidValue
        {
            get
            {
                return _ReservationDb.TotalPaidValue;
            }
        }
        public double TotalInstallmentPaidValue
        {
            get
            {
                return _ReservationDb.TotalInstallmentPaidValue;
            }
        }
        public double MulctPaymentValue
        {
            get
            {
                return _ReservationDb.MulctPaymentValue;
            }
        }
        public double TotalValue
        {
            get
            {
                return _ReservationDb.TotalPaidValue + _ReservationDb.RemainingValue;
            }
        }
        #endregion
        public string Note
        {
            set
            {
                _ReservationDb.Note = value;
            }
            get
            {
                return _ReservationDb.Note;
            }


        }
        public ReservationBiz ParentReservation
        {
            set
            {
                _ParentReservation = value;
                

            }
            get
            {
                if (_ParentReservation == null && _ReservationDb.Parent == 0)
                    _ParentReservation = new ReservationBiz();
                return _ParentReservation;
            }
        }
       
        public int ParentID
        {
            set
            {
                _ReservationDb.Parent = value;
            }
            get 
            {
                return _ReservationDb.Parent;
            }
        }
        //public AccountBiz 
        public DateTime ContractingDate
        {
            set
            {
                _ReservationDb.ContractingDate = value;
            }
            get
            {
                return _ReservationDb.ContractingDate;
            }

        }
        public int Allowance
        {
            set
            {
                _ReservationDb.Allowance = value;
            }
            get
            {
                return _ReservationDb.Allowance;
            }

        }
        public static ReservationCol PickedReservationCol
        {
            set
            {
                _PickedReservationCol = value;
            }
            get
            {
                if (_PickedReservationCol == null)
                    _PickedReservationCol = new ReservationCol(true);
                return _PickedReservationCol;
            }
        }
        public string ShortStatusStr
        {
            get
            {

                string Returned = "";
                if (!IsTenancy)
                {
                    if (Status == ReservationStatus.Primary)
                    {
                        Returned = "„€·ﬁ… ·Õ”«» ⁄„Ì·";
                    }
                    else if (Status == ReservationStatus.DownPayment)
                    {
                        Returned = "ÕÃ“ »œ›⁄« ";
                    }
                    else if (Status == ReservationStatus.Contracting || (Status == ReservationStatus.Complete))
                    {
                        Returned = " ⁄«ﬁœ ";
                    }
                    else if (Status == ReservationStatus.Cancellation)
                    {
                        Returned = "≈·€«¡";
                    }

                    else if (Status == ReservationStatus.Cession)
                    {
                        Returned = " ‰«“·";
                    }
                    else if (Status == ReservationStatus.Complete)
                    {
                        Returned = "«” Ì›«¡";
                    }
                }
                else
                {
                    if (TenancyEndDate.Date <= DateTime.Now.Date)
                    {
                        Returned = "«ÌÃ«— „‰ ÂÏ » «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");
                    }
                    else
                        Returned = "«ÌÃ«— Õ Ï  «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");
                }
                return Returned;
            }
        }
        public string StatusStr
        {
            get
            {

                string Returned = "";
                if (!IsTenancy)
                {
                    if (Status == ReservationStatus.Primary)
                    {
                        Returned = "„€·ﬁ… ·Õ”«» ⁄„Ì·";
                    }
                    else if (Status == ReservationStatus.DownPayment)
                    {
                        Returned = "ÕÃ“ »œ›⁄« (" + TempPayment + ")";
                    }
                    else if (Status == ReservationStatus.Contracting || (Status == ReservationStatus.Complete && RemainingValue > 100))
                    {
                        Returned = " ⁄«ﬁœ ";
                    }
                    else if (Status == ReservationStatus.Cancellation)
                    {
                        string strCancelation = "";
                        if (_CancelationBiz != null && _CancelationBiz.TypeBiz.ID != 0 && !_CancelationBiz.PayBackComplete)
                            strCancelation = _CancelationBiz.TypeBiz.Name;
                        if (_CancelationBiz != null && _CancelationBiz.Note != "")
                            strCancelation = _CancelationBiz.Note;
                        if (IsDelegated && !IsReservedAgain)
                        {
                            if (IsContracted)
                                Returned = " ›ÊÌ÷ »«·»Ì⁄ ⁄·Ï „»·€) " + "" + TotalPaidValue.ToString() + ")";
                            else
                                Returned = "«⁄«œ… ÕÃ“";
                        }
                        else if (IsDelegated && IsReservedAgain)
                        {
                            if (IsContracted)
                                Returned = " ›ÊÌ÷ »«·»Ì⁄ Ê „ «⁄«œ… «·»Ì⁄";
                            else
                                Returned = " ÊﬁÌ› ·«⁄«œ… ÕÃ“ Ê „ «⁄«œ… «·»Ì⁄";

                        }
                        else
                        {

                            Returned = "≈ ·€«¡ ";

                        }
                        if (strCancelation != "")
                            Returned += "-" + strCancelation;
                        if (_CancelationBiz != null && _CancelationBiz.PayBackComplete)
                            Returned += "-" + " „ —œ «·„»·€";
                    }
                    else if (Status == ReservationStatus.Cession)
                    {
                        Returned = " ‰«“·";
                    }
                    else if (Status == ReservationStatus.Complete)
                    {
                        Returned = "«” Ì›«¡";
                    }
                    DateTime dtStatus = StatusDate;
                    if (IsDelegated)
                        dtStatus = DelegationDate;
                    if (_CancelationBiz != null)
                    {
                        if (_CancelationBiz.PayBackComplete)
                            dtStatus = _CancelationBiz.PayBackCompleteDate;

                    }
                    Returned += " » «—ÌŒ " + dtStatus.ToString("yyyy-MM-dd");
                }
                else
                {
                    if (TenancyEndDate.Date <= DateTime.Now.Date)
                    {
                        Returned = "«ÌÃ«— „‰ ÂÏ » «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");
                    }
                    else
                        Returned = "«ÌÃ«— Õ Ï  «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");

                }
                    return Returned;
            }
        }
        public ReservationPayBackCol PayBackCol
        {
            set
            {
                _PayBackCol = value;
            }
            get
            {
                if (_PayBackCol == null)
                {
                    _PayBackCol = new ReservationPayBackCol(true);
                    if (Status == ReservationStatus.Cancellation)
                    {

                        if (ID != 0)
                        {
                            ReservationPayBackDb objDb = new ReservationPayBackDb();
                            objDb.ReservationID = ID;
                            DataTable dtTemp = objDb.Search();
                            ReservationPayBackBiz objBiz;
                            foreach (DataRow objDr in dtTemp.Rows)
                            {
                                objBiz = new ReservationPayBackBiz(objDr);
                                objBiz.ReservationBiz = this;
                                _PayBackCol.Add(objBiz);
                            }
                        }
                    }
                }
                return _PayBackCol;
            }
        }
        public string DirectStatusStr
        {
            get
            {

                string Returned = "";
                if (!IsTenancy || 
                    Status == ReservationStatus.Cancellation)
                {
                    if (Status == ReservationStatus.Primary)
                    {
                        Returned = "„€·ﬁ… ·Õ”«» ⁄„Ì·";
                    }
                    else if (Status == ReservationStatus.DownPayment)
                    {
                        Returned = "ÕÃ“ »œ›⁄« (" + _ReservationDb.TempPayment + ")";
                    }
                    else if (Status == ReservationStatus.Contracting || (Status == ReservationStatus.Complete && _ReservationDb.RemainingValue > 100))
                    {
                        Returned = " ⁄«ﬁœ ";
                    }
                    else if (Status == ReservationStatus.Cancellation)
                    {
                        string strCancelation = "";
                        if (_CancelationBiz != null && _CancelationBiz.TypeBiz.ID != 0 && !_CancelationBiz.PayBackComplete)
                            strCancelation = _CancelationBiz.TypeBiz.Name;
                        //if (_CancelationBiz != null && _CancelationBiz.Note != "")
                        //    strCancelation = _CancelationBiz.Note;
                        if (IsDelegated && !IsReservedAgain && !_CancelationBiz.PayBackComplete)
                        {
                            if (IsContracted)
                                Returned = " ›ÊÌ÷ »«·»Ì⁄ ⁄·Ï „»·€) " + "" + _ReservationDb.TotalPaidValue.ToString() + ")";
                            else
                                Returned = "«⁄«œ… ÕÃ“";
                        }
                        else if (IsDelegated && IsReservedAgain && !_CancelationBiz.PayBackComplete)
                        {
                            if (IsContracted)
                                Returned = " ›ÊÌ÷ »«·»Ì⁄ Ê „ «⁄«œ… «·»Ì⁄";
                            else
                                Returned = " ÊﬁÌ› ·«⁄«œ… ÕÃ“ Ê „ «⁄«œ… «·»Ì⁄";

                        }
                        else
                        {

                            Returned = "≈ ·€«¡ ";

                            //   Returned = "≈ ·€«¡ ";
                        }
                        if (strCancelation != "")
                            Returned += "-" + strCancelation;
                    }
                    else if (Status == ReservationStatus.Cession)
                    {
                        Returned = " ‰«“·";
                    }
                    else if (Status == ReservationStatus.Complete)
                    {
                        Returned = "«” Ì›«¡";
                    }
                    DateTime dtStatus = StatusDate;
                    if (IsDelegated)
                        dtStatus = DelegationDate;
                    if (_CancelationBiz != null)
                    {
                        if (_CancelationBiz.PayBackComplete)
                            dtStatus = _CancelationBiz.PayBackCompleteDate;

                    }
                    Returned += " » «—ÌŒ " + dtStatus.ToString("yyyy-MM-dd");
                }
                else
                {
                    if (TenancyEndDate.Date <= DateTime.Now.Date)
                    {
                        Returned = "«ÌÃ«— „‰ ÂÏ » «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");
                    }
                    else
                    Returned = "«ÌÃ«— Õ Ï  «—ÌŒ :" + TenancyEndDate.ToString("yyyy-MM-dd");
                }
                return Returned;
            }
        }
        public double ProfitPeriodAmount
        {
            set
            {
                _ReservationDb.ProfitPeriodAmount = value;
            }
            get
            {
                return _ReservationDb.ProfitPeriodAmount;
            }

        }
        public DateTime LimitDate
        {
            set
            {
                _ReservationDb.LimitDate = value;
            }
            get
            {
                return _ReservationDb.LimitDate;
            }
        }
        public AttachmentCol AllAttachmentCol
        {
            get
            {
                if (_AllAttachmentCol == null)
                {
                    _AllAttachmentCol = new AttachmentCol(true);
                    if (ID != 0)
                    {
                        foreach (ReservationAttachmentBiz objBiz in ReservationAttachmentCol)
                            _AllAttachmentCol.Add(objBiz);
                        foreach (CustomerBiz objcustomerBiz in CustomerCol)
                        {
                            foreach (CustomerAttachmentBiz objBiz in objcustomerBiz.CustomerAttachmentCol)
                                _AllAttachmentCol.Add(objBiz);
                        }
                    }
                }
                return _AllAttachmentCol;

            }
        }

        public ReservationInstallmentBiz MaxDueInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                if (_LinearMode)
                    Returned = LinearInstallmentCol.MaxDueInstallment;
                else
                    Returned = InstallmentTypeCol.MaxDueInstallment;
                return Returned;
            }
        }
        public ReservationInstallmentBiz MinDueInstallment
        {
            get
            {
                ReservationInstallmentBiz Returned = new ReservationInstallmentBiz();
                if (_LinearMode)
                    Returned = LinearInstallmentCol.MinDueInstallment;
                else
                    Returned = InstallmentTypeCol.MinDueInstallment;
                return Returned;
            }
        }
        public static ReservationCol ExpiredReservationCol
        {
            get
            {
                ReservationCol Returned = new ReservationCol(true);
                ReservationDb objReservationDb = new ReservationDb();
                objReservationDb.OnlyExpiredReservation = true;
                DataTable dtTemp = objReservationDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new ReservationBiz(objDr));
                }
                return Returned;
            }
        }

        internal int AccountID
        {
            get
            {
                return _ReservationDb.GLAccount;
            }
        }
        public AccountBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                return _AccountBiz;
            }
 
        }
        public static AccountBiz UnitCreditorAccountBiz
        {
            set
            {
                _UnitCreditorAccountBiz = value;
            }
            get
            {
                if (_UnitCreditorAccountBiz == null)
                {
                    _UnitCreditorAccountBiz = new AccountBiz();
                    SupperCodeBiz objTemp = new SupperCodeBiz("UnitCreditorAccount");
                    if (objTemp.ID != 0)
                    {
                        try
                        {
                            _UnitCreditorAccountBiz = new AccountBiz(int.Parse(objTemp.Value));
                        }
                        catch
                        {
 
                        }
                    }
                }
                return _UnitCreditorAccountBiz;
            }
        }
        public static AccountBiz SalesAccountBiz
        {
            set
            {
                _SalesAccountBiz = value;
            }
            get
            {
                if (_SalesAccountBiz == null)
                {
                    _SalesAccountBiz = new AccountBiz();
                    SupperCodeBiz objTemp = new SupperCodeBiz("SalesAccount");
                    if (objTemp.ID != 0)
                    {
                        try
                        {
                            _SalesAccountBiz = new AccountBiz(int.Parse(objTemp.Value));
                        }
                        catch
                        {

                        }
                    }
                }
                return _SalesAccountBiz;
            }
        }
        public AccountBiz LeafAccountBiz
        {
            set
            {
                _LeafAccountBiz = value;
            }
            get
            {
                if (_LeafAccountBiz == null || _LeafAccountBiz.NameA == null ||
                    _LeafAccountBiz.NameA=="")
                {
                    _LeafAccountBiz = new AccountBiz();
                    _LeafAccountBiz.ParentID = AccountBiz.ID;
                    _LeafAccountBiz.FamilyID = AccountBiz.FamilyID;
                    _LeafAccountBiz.IsLeaf = true;
                    _LeafAccountBiz.IsSecondary = true;
                    _LeafAccountBiz.Level = AccountBiz.Level + 1;
                    _LeafAccountBiz.NameA = UnitFullName + "-" + CustomerStr;


                }
                return _LeafAccountBiz;
            }
        }
        public TransactionBiz ContractingTransactionBiz
        {
            get
            {
                if (_ContractingTransactionBiz == null )
                {
                    _ContractingTransactionBiz = new TransactionBiz();
                    _ContractingTransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;
                    double dblTotalValue = Math.Abs( Value-LastTransactionValue);
                    string strTitle = "«À»«   ⁄«ﬁœ «·⁄„Ì· ⁄·Ï «·ÊÕœ… :" + DirectUnitCodeStr;
                
                    dblValue = Value;
                    if ( (Status == ReservationStatus.Contracting || Status == ReservationStatus.Complete)  && 
                   LastGLTransaction == 0
                    //|| 
                    //(LastTransactionType == TransactionCRMSystemType.Contracting &&
                    //Math.Abs(Value- LastTransactionValue)>0  )
                    //) 
                        )
                    {
                        objTransactionBiz = _ContractingTransactionBiz;
                        _ContractingTransactionBiz.SystemSource = 6;
                        _ContractingTransactionBiz.SystemType = (int)TransactionCRMSystemType.Contracting;
                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;
                       // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;

                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Contracting;
                        objDebitElement.ReservationID = ID;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.ReservationID = ID;
                        objCreditElement.AccountBiz = AccountBiz.CRMUnitCreditorAccountBiz ;
                        
                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Contracting;
                        _ContractingTransactionBiz.ElementCol.Add(objDebitElement);
                        _ContractingTransactionBiz.ElementCol.Add(objCreditElement);
                        _ContractingTransactionBiz.OtherModuleSrcIDs.Add(ID.ToString());
                    }

                }
              
                return _ContractingTransactionBiz;


            }
        }
        public TransactionBiz DeliveryTransactionBiz
        {
            get
            {
                if (_DeliveryTransactionBiz == null)
                {
                    _DeliveryTransactionBiz = new TransactionBiz();
                    _DeliveryTransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;
                    double dblTotalValue = Value;
                    string strTitle = "«” ·«„ :" + DirectUnitCodeStr;

                    dblValue = Value;
                    //Delivery Status
                    if (Math.Abs(dblValue) > 0 && ContractingTransactionBiz.ElementCol.Count == 0 && 
                        LastTransactionType == TransactionCRMSystemType.Contracting &&
                        ( Status == ReservationStatus.Contracting||Status == ReservationStatus.Complete)&& IsDelivered )
                    {
                        objTransactionBiz = _DeliveryTransactionBiz;
                        _DeliveryTransactionBiz.SystemSource = 6;
                        _DeliveryTransactionBiz.SystemType = (int)TransactionCRMSystemType.Delivery;

                       //Inverse of the last contracting transaction
                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMUnitCreditorAccountBiz;
                        objDebitElement.ReservationID = ID;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;
                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Delivery;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;
                        //objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objCreditElement.ReservationID = ID;
                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Delivery;
                        _DeliveryTransactionBiz.ElementCol.Add(objDebitElement);
                        _DeliveryTransactionBiz.ElementCol.Add(objCreditElement);
                        ////////////////////////////////

                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;
                        objDebitElement.ReservationID = ID;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;
                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Delivery;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.AccountBiz = AccountBiz.CRMSalesAccountBiz;
                        //objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objCreditElement.ReservationID = ID;
                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Delivery;
                        _DeliveryTransactionBiz.ElementCol.Add(objDebitElement);
                        _DeliveryTransactionBiz.ElementCol.Add(objCreditElement);
                        _DeliveryTransactionBiz.OtherModuleSrcIDs.Add(ID.ToString());
                    }

                }

                return _DeliveryTransactionBiz;


            }
        }

        public TransactionBiz CancelationTransactionBiz
        {
            get
            {
                if (_CancelationTransactionBiz == null)
                {
                    _CancelationTransactionBiz = new TransactionBiz();
                    _CancelationTransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;
                    double dblTotalValue = Value ;
                    string strTitle = " ≈·€«¡ :" + DirectUnitCodeStr;

                    dblValue = Value ;
                    if (Math.Abs(dblValue) > 0 && ContractingTransactionBiz.ElementCol.Count == 0
                        && DeliveryTransactionBiz.ElementCol.Count == 0
                        && Status == ReservationStatus.Cancellation &&
                        ( LastTransactionType == TransactionCRMSystemType.Contracting || LastTransactionType == TransactionCRMSystemType.Delivery))
                    {
                        objTransactionBiz = _CancelationTransactionBiz;
                        _CancelationTransactionBiz.SystemSource = 6;
                        _CancelationTransactionBiz.SystemType = (int)TransactionCRMSystemType.Cancelation;

                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;

                        objDebitElement.ReservationID = ID;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = DirectCancelationCost;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;
                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Cancelation;
                        
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.AccountBiz = LastTransactionType == TransactionCRMSystemType.Delivery ?
                            AccountBiz.CRMSalesAccountBiz : AccountBiz.CRMUnitCreditorAccountBiz;

                        //objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objCreditElement.ReservationID = ID;
                        objCreditElement.Value = DirectCancelationCost;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Cancelation;
                        _CancelationTransactionBiz.ElementCol.Add(objDebitElement);
                        _CancelationTransactionBiz.ElementCol.Add(objCreditElement);

                        /////////////////////////////////////////////////////////////

                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = LastTransactionType == TransactionCRMSystemType.Delivery ?
                            AccountBiz.CRMSalesAccountBiz : AccountBiz.CRMUnitCreditorAccountBiz;
                       
                        objDebitElement.ReservationID = ID;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;
                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Cancelation;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;
                           
                        //objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objCreditElement.ReservationID = ID;
                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Cancelation;
                        _CancelationTransactionBiz.ElementCol.Add(objDebitElement);
                        _CancelationTransactionBiz.ElementCol.Add(objCreditElement);
                        _CancelationTransactionBiz.OtherModuleSrcIDs.Add(ID.ToString());
                    }

                }

                return _CancelationTransactionBiz;


            }
        }
        public TransactionBiz InstallmentMulctTransactionBiz
        {
            get
            {
                if (_InstallmentMulctTransactionBiz == null)
                {
  
                    _InstallmentMulctTransactionBiz = new TransactionBiz();
                    _InstallmentMulctTransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;
                 
                    string strTitle = "";
                
                    foreach(InstallmentMulctBiz objBiz in InstallmentMulctCol)
                    {
                        if (AccountBiz.CRMMulctAccountBiz.ID == 0)
                            continue;
                        dblValue = objBiz.MulctValue;
                    //    strTitle = objBiz.InstallmentBiz.Name + "(" + objBiz.InstallmentBiz.DueDateStr +
                    //")" + "-"  + objBiz.ReasonBiz.Desc;
                        strTitle =  objBiz.ReasonBiz.Desc;
                        objTransactionBiz = _InstallmentMulctTransactionBiz;
                        _InstallmentMulctTransactionBiz.SystemSource = 6;
                        _InstallmentMulctTransactionBiz.SystemType = (int)TransactionCRMSystemType.Mulct;
                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;

                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Mulct;
                        objDebitElement.ReservationID = ID;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.ReservationID = ID;
                        objCreditElement.AccountBiz = AccountBiz.CRMMulctAccountBiz;

                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Mulct;
                        _InstallmentMulctTransactionBiz.ElementCol.Add(objDebitElement);
                        _InstallmentMulctTransactionBiz.ElementCol.Add(objCreditElement);
                        _InstallmentMulctTransactionBiz.OtherModuleSrcIDs.Add(objBiz.ID.ToString());
                    }

                }
                return _InstallmentMulctTransactionBiz;
            }
        }
        public TransactionBiz InstallmentDiscountTransactionBiz
        {
            get
            {
                if (_InstallmentDiscountTransactionBiz == null)
                {
                    _InstallmentDiscountTransactionBiz = new TransactionBiz();
                    _InstallmentDiscountTransactionBiz.ElementCol = new TransactionElementCol(true);
                    TransactionBiz objTransactionBiz;
                    TransactionElementBiz objDebitElement;
                    TransactionElementBiz objCreditElement;
                    double dblValue = 0;
                    double dblDiscount = 0;

                    string strTitle = "";

                    foreach (InstallmentDiscountBiz objBiz in InstallmentDiscountCol)
                    {
                        if (AccountBiz.CRMDiscountAccountBiz.ID == 0)
                            continue;
                        dblValue = objBiz.Value;
                        strTitle = objBiz.InstallmentBiz.Name + "(" + objBiz.InstallmentBiz.DueDateStr +
                    ")" + "-" + objBiz.TypeBiz.Name;
                        objTransactionBiz = _InstallmentDiscountTransactionBiz;
                        _InstallmentDiscountTransactionBiz.SystemSource = 6;
                        _InstallmentDiscountTransactionBiz.SystemType = (int)TransactionCRMSystemType.Discount;
                        objDebitElement = new TransactionElementBiz();
                        objDebitElement.AccountBiz = AccountBiz.CRMDiscountAccountBiz;
                        // objDebitElement.CostCenterBiz = ContractorBiz.CostCenterBiz;
                        objDebitElement.Value = dblValue;
                        objDebitElement.Direction = true;
                        objDebitElement.Desc = strTitle;
                        objDebitElement.SystemSource = 6;

                        objDebitElement.SystemType = (int)TransactionCRMSystemType.Discount;
                        objDebitElement.ReservationID = ID;
                        objCreditElement = new TransactionElementBiz();
                        objCreditElement.ReservationID = ID;
                        objCreditElement.AccountBiz = AccountBiz.CRMCustomerAccountBiz;

                        objCreditElement.Value = dblValue;
                        objCreditElement.Direction = false;
                        objCreditElement.Desc = strTitle;
                        objCreditElement.SystemSource = 6;
                        objCreditElement.SystemType = (int)TransactionCRMSystemType.Discount;
                        _InstallmentDiscountTransactionBiz.ElementCol.Add(objDebitElement);
                        _InstallmentDiscountTransactionBiz.ElementCol.Add(objCreditElement);
                        _InstallmentDiscountTransactionBiz.OtherModuleSrcIDs.Add(objBiz.ID.ToString());
                    }
                }
                return _InstallmentDiscountTransactionBiz;
            }
        }
        public TransactionBiz PaymentTransactionBiz
        {
            get
            {
                if (_PaymentTransactionBiz == null)
                { 
                }
                return _PaymentTransactionBiz;
            }
        }
        public bool IsContracted
        {
            set
            {
                _ReservationDb.IsContracted = value;
            }
            get
            {
                return _ReservationDb.IsContracted;
            }
        }
        public bool IsCanceled
        {
            set
            {
                _ReservationDb.IsCanceled = value;
            }
            get
            {
                return _ReservationDb.IsCanceled;
            }
        }
        public bool IsSet
        {
            set 
            {
                _IsSet = value;
            }
            get 
            {
                return _IsSet;
            }
        }
        public ReservationPaymentCol ReservationPaymentCol
        {
            get
            {
                if (_ReservationPaymentCol == null)
                    _ReservationPaymentCol = new ReservationPaymentCol(true);
                return _ReservationPaymentCol;
            }
        }
        public TransactionCRMSystemType LastTransactionType
        {
            get
            {
                return (TransactionCRMSystemType)_ReservationDb.LastTransactionType;
            }
        }
        public double LastTransactionValue
        {
            get
            {
                return _ReservationDb.LastTransactionValue;
            }
        }
        public int LastGLTransaction
        {
            get
            {
                return _ReservationDb.LastGLTransaction;
            }
        }
        public int Order
        {
            get
            {
                return _ReservationDb.Order;
            }
        }
        #region Cession
        public int NewReservationID
        {
            set
            {
                _ReservationDb.NewReservationID = value;
            }
            get
            {
                return _ReservationDb.NewReservationID;
            }
        }
        public int OldReservationID
        {
            set
            {
                _ReservationDb.OldReservationID = value;
            }
            get
            {
                return _ReservationDb.OldReservationID;
            }
        }
        public string OldReservationUnitFullName
        {
            set
            {
                _ReservationDb.OldReservationUnitFullName = value;
            }
            get
            {
                return _ReservationDb.OldReservationUnitFullName;
            }
        }
        public string OldReservationCustomerName
        {
            set
            {
                _ReservationDb.OldReservationCustomerName = value;
            }
            get
            {
                return _ReservationDb.OldReservationCustomerName;
            }

        }
        public string NewReservationUnitName
        {
            set
            {
                _ReservationDb.NewReservationUnitName = value;
            }
            get
            {
                return _ReservationDb.NewReservationUnitName;
            }
        }
        public string NewReservationCustomerName
        {
            set
            {
                _ReservationDb.NewReservationCustomerName = value;
            }
            get
            {
                return _ReservationDb.NewReservationCustomerName;
            }
        }
        public double CessionCost
        {
            set
            {
                _ReservationDb.CessionCost = value;
            }
            get
            {
                return _ReservationDb.CessionCost;
            }
        }
        public double OldReservationPreviousPaidValue
        {
            set
            {
                _ReservationDb.OldReservationPreviousPaidValue = value;
            }
            get
            {
                return _ReservationDb.OldReservationPreviousPaidValue;
            }
        }
        public DateTime CessionDate
        {
            set
            {
                _ReservationDb.CessionDate = value;
            }
            get
            {
                return _ReservationDb.CessionDate;
            }
        }
        #endregion
        #region Public Poperties Used in Scheduling
        public double VirtualRemainingValue
        {
            get
            {
                double Returned = 0;

                double dblInstallmentValue = 0;
                double dblDiscountValue = 0;
                double dblPaidValue = 0;
                double dblBonus = 0;
                dblDiscountValue = DiscountCol.NonScheduledValue;
                dblBonus = UtilityCol.ScheduledValue + BonusCol.NonScheduledValue;
                dblInstallmentValue = InstallmentTypeCol.SumInstallmentValue;
                dblPaidValue = PaymentCol.TotalValue;// +InstallmentTypeCol.TotalPaidValue;
                Returned = VirtualTotalvalue + dblBonus - dblDiscountValue - dblInstallmentValue - dblPaidValue;
                return Returned;
            }
        }
        public double VirtualDeservedValue
        {
            get
            {
                double Returned = 0;
                Returned = LinearInstallmentCol.DeservedValue;
                return Returned;
            }
 
        }
        public double DeservaedCheckValue
        {
            get
            {
                double Returned = LinearInstallmentCol.DeservedCheckValue;

                return Returned;
            }
        }
        public double NonDeservaedCheckValue
        {
            get
            {
                double Returned = LinearInstallmentCol.NonDeservedCheckValue;
                return Returned;
            }
        }
        public double VirtualNonPaidValue
        {
            get
            {
                double Returned = 0;

                double dblInstallmentValue = 0;
                double dblDiscountValue = 0;
                double dblPaidValue = 0;
                double dblBonus = 0;
                dblDiscountValue = DiscountCol.NonScheduledValue;
                dblBonus = BonusCol.NonScheduledValue;
                Returned = VirtualTotalvalue + UtilityCol.ScheduledValue + dblBonus - dblDiscountValue -
                    VirtualTotalPaidValue;
                return Returned;
            }
        }
        public double VirtualRealValue
        {
            get
            {
                double Returned = 0;
                Returned = InstallmentTypeCol.Value + PaymentCol.TotalValue -
                    UtilityCol.ScheduledValue - BonusCol.TotalValue;
                return Returned;
            }
        }
        public double RealDevidedValue
        {
            get
            {
                double Returned = 0;

                // double dblInstallmentValue = 0;
                double dblDiscountValue = 0;
                double dblPaidValue = 0;
                double dblBonus = 0;
                dblDiscountValue = DiscountCol.NonScheduledValue;
                dblBonus = BonusCol.NonScheduledValue;
                //  dblInstallmentValue = InstallmentTypeCol.SumInstallmentValue;
                dblPaidValue = PaymentCol.TotalValue;//+ InstallmentTypeCol.TotalPaidValue;
                Returned = VirtualTotalvalue + dblBonus - dblDiscountValue - dblPaidValue;
                return Returned;
            }
        }
        public double VirtualRealTotalValue
        {
            get
            {
                double Returned = 0;

                double dblDiscountValue = 0;
                double dblBonus = 0;
                dblDiscountValue = DiscountCol.NonScheduledValue;
                dblBonus = BonusCol.NonScheduledValue;
                Returned = VirtualTotalvalue + dblBonus - dblDiscountValue;
                return Returned;
            }
        }
        public double VirtualTotalPaidValue
        {
            get
            {
                double Returned = 0;

                Returned = VirtualInstallmentPaidValue + PaymentCol.TotalValue;
                return Returned;
            }
        }
        public double VirtualPracticalTotalPaidValue
        {
            get
            {
                double Returned = 0;

                Returned = VirtualPracticalInstallmentPaidValue + PaymentCol.TotalValue;
                return Returned;
            }
        }
        public double TotalCheckPaidValue
        {
            get
            {
                double Returned = 0;

                Returned = VirtualPracticalInstallmentPaidValue + PaymentCol.TotalValue;
                return Returned;
            }
        }
        public int InstallmentCount
        {
            get
            {
                if (_LinearMode)
                    return LinearInstallmentCol.Count;
                else
                    return InstallmentTypeCol.InstallmentCount;

            }
        }
        #endregion
        #region Public Property Used In Delete
        public ReservationUtilityCol DeletedUtilityCol
        {
            set
            {
                _DeletedUtilityCol = value;
            }
            get
            {
                if (_DeletedUtilityCol == null)
                    _DeletedUtilityCol = new ReservationUtilityCol(true);
                return _DeletedUtilityCol;
            }
        }
        public ReservationDiscountCol DeletedDiscountCol
        {
            set
            {
                _DeletedDiscountCol = value;
            }
            get
            {
                if (_DeletedDiscountCol == null)
                    _DeletedDiscountCol = new ReservationDiscountCol(true);
                return _DeletedDiscountCol;
            }
        }
        public StrategyInstallmentCol DeltedInstallmentTypeCol
        {
            set
            {
                _DeletedInstallmentTypeCol = value;
            }
            get
            {
                if (_DeletedInstallmentTypeCol == null)
                    _DeletedInstallmentTypeCol = new StrategyInstallmentCol(true);
                return _DeletedInstallmentTypeCol;
            }
        }
        public ReservationInstallmentCol DeletedInstallmentCol
        {
            set
            {
                _DeletedInstallmentCol = value;
            }
            get
            {
                if (_DeletedInstallmentCol == null)
                    _DeletedInstallmentCol = new ReservationInstallmentCol(true);
                return _DeletedInstallmentCol;
            }
        }
        public ReservationBonusCol DeletedBonusCol
        {
            set
            {
                _DeletedBonusCol = value;
            }
            get
            {
                if (_DeletedBonusCol == null)
                    _DeletedBonusCol = new ReservationBonusCol(true);
                return _DeletedBonusCol;
            }
        }
        public TempReservationPaymentCol DeletedPaymentCol
        {
            set
            {
                _DeletedPaymentCol = value;
            }
            get
            {
                if (_DeletedPaymentCol == null)
                    _DeletedPaymentCol = new TempReservationPaymentCol(true);
                return _DeletedPaymentCol;
            }
        }
        public AdministrativeCostPaymentCol DeletedAdministrativePaymentCol
        {
            set
            {
                _DeletedAdministrativePaymentCol = value;
            }
            get
            {
                if (_DeletedAdministrativePaymentCol == null)
                    _DeletedAdministrativePaymentCol = new AdministrativeCostPaymentCol(true);
                return _DeletedAdministrativePaymentCol;
            }
        }
        public ReservationAttachmentCol DeletedAttachmentCol
        {
            set
            {
                _DeletedAttachmentCol = value;
            }
            get
            {
                if (_DeletedAttachmentCol == null)
                    _DeletedAttachmentCol = new ReservationAttachmentCol(true);
                return _DeletedAttachmentCol;
            }
        }
        #endregion
        #region Public Property for fill Data
        public bool StopPayment
        {
            set
            {
                _StopPayment = value;
            }
        }
        public bool StopMulct
        {
            set
            {
                _StopMulct = value;
            }
        }
        public bool StopMulctPayment
        {
            set
            {
                _StopMulctPayment = value;
            }
        }
        public bool StopDiscount
        {
            set
            {
                _StopDiscount = value;
            }
        }
        #endregion
        #region Stoped
        public bool IsStopped
        {
            get { return _ReservationDb.IsStopped; }
        }
        public bool StopedPermanently
        {
            get { return _ReservationDb.StopedPermanently; }
        }
        public string  StopReason
        {
            get { return _ReservationDb.StopReason; }
        }
        public DateTime OpenTime
        {
            get { return _ReservationDb.OpenTime; }
        }
        public string StopNote
        {
            get 
            {
                string Returned = "";
                if (IsStopped)
                {
                    Returned += StopReason;
                    if (StopedPermanently)
                    { Returned += "-" + "«Ìﬁ«› »‘ﬂ· œ«∆„"; }
                    else
                    {
                        Returned += "-" + "Õ Ï  «—ÌŒ " + OpenTime.ToString("yyyy-MM-dd");
                    }
                }
                return Returned;
            }
        }
        #endregion
        #endregion

        #region Private Methods
        ReservationInstallmentCol GetInstallmentCol()
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            int intGroup = 0;
            foreach (StrategyInstallmentBiz objTypeBiz in _InstallmentTypeCol)
            {
                intGroup++;

                foreach (ReservationInstallmentBiz objBiz in objTypeBiz.InstallmentCol)
                {
                    objBiz.Reservation = this;
                    objBiz.Group = intGroup;
                    objBiz.Type = objTypeBiz.TypeBiz;
                    Returned.Add(objBiz);
                    //if (objBiz.ID == 0)
                    //    objBiz.Add();
                    //else
                    //    objBiz.Edit();
                }
            }
            return Returned;
        }
        ReservationInstallmentCol GetDeletedInstallmentCol()
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            if (_DeletedInstallmentCol == null && _DeletedInstallmentTypeCol == null)
                return Returned;
            if (_DeletedInstallmentCol == null)
                _DeletedInstallmentCol = new ReservationInstallmentCol(true);
            if (_DeletedInstallmentTypeCol != null)
            {
                foreach (StrategyInstallmentBiz objBiz in _DeletedInstallmentTypeCol)
                {
                    _DeletedInstallmentCol.Add(objBiz.InstallmentCol);
                }
            }
            Returned.Add(_DeletedInstallmentCol);
            return Returned;

        }
        DataTable GetUnitTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("ReservationID"),
                new DataColumn("UnitID") });
            DataRow objDr;
            foreach (UnitBiz objBiz in UnitCol)
            {
                objDr = Returned.NewRow();
                objDr["ReservationID"] = ID;
                objDr["UnitID"] = objBiz.ID;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        void SetNonCheckedInstallmentCol()
        {
            _NonCheckedInstallmentCol = new ReservationInstallmentCol(true);
            _CheckCol = new InstallmentCheckCol(true);
            DataRow[] arrDr;
            InstallmentCheckBiz objCheckBiz;
            foreach (ReservationInstallmentBiz objBiz in LinearInstallmentCol)
            {
                arrDr = ReservationDb.CachCheckTable.Select("InstallmentID=" + objBiz.ID);
                if (arrDr.Length > 0)
                {
                    objCheckBiz = new InstallmentCheckBiz(arrDr[0]);
                    objCheckBiz.InstallmentBiz = objBiz;
                    _CheckCol.Add(objCheckBiz);

                }
                else if (objBiz.InstallmentStatus == InstallmentStatus.Created)
                {
                    _NonCheckedInstallmentCol.Add(objBiz);
                }


            }
        }
        void CopyData(ref ReservationBiz objBiz)
        {
            objBiz.UnitCol = UnitCol;//Note to edit its current reservation
            objBiz.StrategyBiz = StrategyBiz;
            objBiz.BranchBiz = new BranchBiz();
            objBiz.InstallmentTypeCol = InstallmentTypeCol.GetNonPaidCopy();
            objBiz.BonusCol = BonusCol.Copy(objBiz);
            objBiz.DiscountCol = DiscountCol.Copy(objBiz);
            objBiz.UtilityCol = UtilityCol.GetOverrideCopy(objBiz);
            objBiz._ReservationDb.PreviousPaidValue = VirtualTotalPaidValue;
            objBiz.Status = ReservationStatus.Contracting;
            objBiz.Date = Date;
            objBiz.DeliveryDate = DeliveryDate;
            objBiz.RealDeliveryDate = RealDeliveryDate;
            objBiz.Value = Value;
            objBiz.BranchBiz = new BranchBiz();
            objBiz.UnitPrice = UnitPrice;
            objBiz.CachePrice = CachePrice;
            objBiz.Finishing = Finishing;
            objBiz.ProfitIsCompound = ProfitIsCompound;
            objBiz.ProfitValue = ProfitValue;
            objBiz.ProfitPeriod = ProfitPeriod;
            objBiz.PeriodAmount = PeriodAmount;
            objBiz.Note = Note;
            objBiz.ContractingDate = ContractingDate;
            objBiz.Allowance = Allowance;
        }
        #endregion


        #region Public Methods
        public bool Add()
        {


            // _ReservationDb.CustomerID = _CustomerBiz.ID;
            if (_StrategyBiz == null)
                _StrategyBiz = new StrategyBiz();
            _ReservationDb.Strategy = _StrategyBiz.ID;
            if (_WorkerCol == null)
                _WorkerCol = new WorkerContributionCol(true);
            _ReservationDb.WorkerContributionTable = _WorkerCol.GetTable();
            _ReservationDb.Value = VirtualRealValue;
            if (_ReservationDb.UnitPrice != 0)
                _ReservationDb.CachePrice = 0;

            int intResservationStatus = 0;
            if (InstallmentTypeCol.Count > 0)
                intResservationStatus = 3;// ⁄«ﬁœ
            else if (PaymentCol.Count > 0)
                intResservationStatus = 2;
            else
                intResservationStatus = 1;

            if (VirtualNonPaidValue <= 1 && (VirtualTotalvalue > 1 || IsFree))
                intResservationStatus = (int)ReservationStatus.Complete;
            _ReservationDb.Status = intResservationStatus;
            _ReservationDb.CustomerTable = GetCustomerTable();
            _ReservationDb.InstallmentTable = GetInstallmentCol().GetTable();
            _ReservationDb.DiscountTable = DiscountCol.GetTable();
            _ReservationDb.BonusTable = BonusCol.GetTable();
            _ReservationDb.TempPaymentTable = PaymentCol.GetTable();
            _ReservationDb.AdministrativePaymentTable = AdministrativePaymentCol.GetTable();
            _ReservationDb.UtilityTable = UtilityCol.GetTable();
            _ReservationDb.WorkerContributionTable = WorkerCol.GetTable();
            _ReservationDb.BranchID = _BranchBiz.ID;
            _ReservationDb.UnitTable = _UnitCol.GetTable();
            //if (SysData.IsOnline)
            //{
            //    ReservationCol objCol = new ReservationCol(true);
            //    objCol.Add(this);
            //    ((ReservationWeb)_ReservationDb).ReservationTable = objCol.GetTable();
            //}
            _ReservationDb.Add();
            return _ReservationDb.ID == 0 ? false : true;



        }

        public bool Edit()
        {

            // _ReservationDb.CustomerID = _CustomerBiz.ID;
            if (_StrategyBiz == null)
                _StrategyBiz = new StrategyBiz();
            _ReservationDb.Strategy = _StrategyBiz.ID;
            if (_WorkerCol == null)
                _WorkerCol = new WorkerContributionCol(true);
            _ReservationDb.WorkerContributionTable = _WorkerCol.GetTable();
            //_ReservationDb.Value = InstallmentTypeCol.TotalInstallmentValue;
            int intResservationStatus = 0;
            if (InstallmentTypeCol.Count > 0)
                intResservationStatus = 3;// ⁄«ﬁœ
            else if (PaymentCol.Count > 0)
                intResservationStatus = 2;
            else
                intResservationStatus = 1;
            if (VirtualNonPaidValue <= 1 && (VirtualTotalvalue > 1 || IsFree))
                intResservationStatus = (int)ReservationStatus.Complete;
            _ReservationDb.BranchID = _BranchBiz.ID;
            _ReservationDb.Status = intResservationStatus;
            _ReservationDb.CustomerTable = GetCustomerTable();
            if (_ReservationDb.UnitPrice != 0)
                _ReservationDb.CachePrice = 0;
            _ReservationDb.Value = VirtualRealValue;
            _ReservationDb.InstallmentTable = GetInstallmentCol().GetTable();
            _ReservationDb.DiscountTable = DiscountCol.GetTable();
            _ReservationDb.BonusTable = BonusCol.GetTable();
            _ReservationDb.TempPaymentTable = PaymentCol.GetTable();
            _ReservationDb.UtilityTable = UtilityCol.GetTable();
            _ReservationDb.WorkerContributionTable = WorkerCol.GetTable();
            _ReservationDb.DeletedBonusTable = DeletedBonusCol.GetTable("DeletedBonus");
            _ReservationDb.DeletedDiscountTable = DeletedDiscountCol.GetTable("DeletedDiscount");
            _ReservationDb.DeletedInstallmentTable = GetDeletedInstallmentCol().GetTable("DeletedInstallment");
            _ReservationDb.DeletedUtilityTable = DeletedUtilityCol.GetTable("DeletedUtility");
            _ReservationDb.DeletedPaymentTable = DeletedPaymentCol.GetTable();
            _ReservationDb.UnitTable = UnitCol.GetTable();
            _ReservationDb.AdministrativePaymentTable = AdministrativePaymentCol.GetTable();
            _ReservationDb.DeletedAdministrativePaymentTable = DeletedAdministrativePaymentCol.GetTable();
            //if (SysData.IsOnline)
            //{
            //    ReservationCol objCol = new ReservationCol(true);
            //    objCol.Add(this);
            //    ((ReservationWeb)_ReservationDb).ReservationTable = objCol.GetTable();
            //}
            _ReservationDb.Edit();
            return _ReservationDb.EditSucceded;

        }
        public DataTable GetCustomerTable()
        {
            DataTable Returned = new DataTable("Customer");
            Returned.Columns.Add(new DataColumn("Customer"));
            DataRow objDr;

            foreach (CustomerBiz objBiz in CustomerCol)
            {
                objDr = Returned.NewRow();
                objDr["Customer"] = objBiz.ID;
                Returned.Rows.Add(objDr);


            }

            return Returned;
        }

        public void Delete()
        {
            _ReservationDb.Delete();
        }
        public void AddUnit(UnitBiz objUnitBiz)
        {
            if (_UnitCol == null)
                _UnitCol = new ReservationUnitCol(true);
            ReservationUnitBiz objReservationUnitBiz = new ReservationUnitBiz();
            objReservationUnitBiz.UnitBiz = objUnitBiz;
            objReservationUnitBiz.ReservationID = ID;
            //objReservationUnitBiz.
            _UnitCol.Add(objReservationUnitBiz);
        }
        public void SetFullReservation()
        {
            ReservationInstallmentCol objTempInstallmentCol = LinearInstallmentCol;
            ReservationBonusCol objBonusCol = BonusCol;
            ReservationDiscountCol objDiscountCol = DiscountCol;
            ReservationUnitCol objUnitCol = UnitCol;
            ReservationUtilityCol objUtilityCol = UtilityCol;
            CustomerCol objCustomerCol = CustomerCol;
            TempReservationPaymentCol objTempPaymentCol = PaymentCol;
            AdministrativeCostPaymentCol objAdministrativePaymentCol = AdministrativePaymentCol;
            MulctPaymentCol objMulctPaymentCol = MulctPaymentCol;
         
           
        }
        public void SetMainReservation()
        {
         
            ReservationUnitCol objUnitCol = UnitCol;
            ReservationUtilityCol objUtilityCol = UtilityCol;
            CustomerCol objCustomerCol = CustomerCol;
        
        }
        public bool CheckPeriod()
        {
            bool Returned = false;

            return Returned;
        }
        public bool CheckPassword(string strPass)
        {
            foreach (CustomerBiz objCustomerBiz in _CustomerCol)
            {
                if (objCustomerBiz.Password == strPass)
                    return true;
            }
          
           return false;
        }
        public string CheckReservationContractingDate()
        {
            if ((int)Date.ToOADate() > (int)ContractingDate.ToOADate())
                return " «—ÌŒ «·ÕÃ“ ·« Ì„ﬂ‰ «‰ Ì·Ï  «—ÌŒ «· ⁄«ﬁœ";
            if (ContractingDate > MinDueInstallment.InstallmentDueDate && VirtualTotalInstallmentValue > 0)
                return " «—ÌŒ «” Õﬁ«ﬁ «·ﬁ”ÿ «·«Ê· ·« Ì„ﬂ‰ «‰   ⁄œÏ  «—ÌŒ «· ⁄«ﬁœ";
            DateTime dtTemp = PeriodBiz.GetDate(new PeriodBiz(Period, PeriodAmount), ContractingDate, VacancyDeal.Ignore);
            // int intCount = _LinearMode ? LinearInstallmentCol.Count :
            if (MaxDueInstallment.InstallmentDueDate.Year > dtTemp.Year && InstallmentCount > 1)
                return "„œ… «· ﬁ”Ìÿ €Ì— „÷»Êÿ…";
            return "";

        }
        public void EditStatus(ReservationStatus objStatus)
        {
            _ReservationDb.Status = (int)objStatus;
            _ReservationDb.EditStatus();
            if (objStatus == ReservationStatus.Cancellation)
            {
                if (ParentID == 0)
                    UnitCol.EditReservation(new ReservationBiz());
                else
                {
                    ReservationUnitDb objTempDb = new ReservationUnitDb();
                    objTempDb.ChildReservation = 0;
                    objTempDb.ReservationID = ParentID;
                    objTempDb.UnitIDs = UnitCol.UnitIDsStr;
                    objTempDb.EditChildReservation();
                }
                _ReservationDb.DeleteNonCollectedCheckPayment();
            }

        }
         
        public void EditStatus(ReservationStatus objStatus,bool blFirstDelete)
        {
            _ReservationDb.Status = (int)objStatus;
            _ReservationDb.EditStatus();
            if (blFirstDelete)
            {
                if (objStatus == ReservationStatus.Cancellation)
                {
                    if (ParentID == 0)
                        UnitCol.EditReservation(new ReservationBiz());
                    else
                    {
                        ReservationUnitDb objTempDb = new ReservationUnitDb();
                        objTempDb.ChildReservation = 0;
                        objTempDb.ReservationID = ParentID;
                        objTempDb.UnitIDs = UnitCol.UnitIDsStr;
                        objTempDb.EditChildReservation();
                    }
                    _ReservationDb.DeleteNonCollectedCheckPayment();
                }
            }

        }
        public void EditNote()
        {
            _ReservationDb.EditNote();
        }
        public bool ReAsignCanceledUnit()
        {
            _ReservationDb.UnitTable = UnitCol.GetTable();
            return _ReservationDb.ReAsignCanceledUnit();
        }
        public void CreateLeafAccount()
        {
            AccountCol objAccountCol = new AccountCol(true);
            objAccountCol.Add(LeafAccountBiz);
            _ReservationDb.AccountTable = objAccountCol.GetTable();
            _ReservationDb.CreateLeafAccount();

        }
        public void StopReservation(string strReason, DateTime dtOpenTime, bool blIsPermanentlyStoped)
        {
            _ReservationDb.StopReason = strReason;
            _ReservationDb.OpenTime = dtOpenTime;
            _ReservationDb.StopedPermanently = blIsPermanentlyStoped;
            _ReservationDb.StopReservation();

        }
        public ReservationBiz GetNewReservationCopy()
        {
            ReservationBiz Returned = new ReservationBiz();
            CopyData(ref Returned);
           

            return Returned;
        }

        public double GetPaidAfterTimeValue(DateTime dtTime)
        {
            double Returned = 0;
            double dblDiscount = 0;

            dblDiscount = LinearInstallmentCol.GetDiscountAfterTimeValue(dtTime);
            Returned = LinearInstallmentCol.GetPaidAfterTimeValue(dtTime);

            Returned = Returned + dblDiscount;
            return Returned;
        }
        public void SetCache(bool blStopPayment,bool blStopDiscount,bool blStopMulct,bool blStopMulctPayment)
        {
            _StopMulct = blStopMulct;
            _StopMulctPayment = blStopMulctPayment;
            _StopPayment = blStopPayment;
            _StopDiscount = blStopDiscount;
            ReservationDb.ReservationIDs = ID.ToString();
            ReservationDb.SetReservationCach();
        }
        #endregion
    }
}

