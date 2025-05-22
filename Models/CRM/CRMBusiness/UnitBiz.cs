using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum CellCommonType
    {
        Unit=9,
        Floor = 7
    }
    public enum FinishingType
    {
        NotSpecified = 0,
        FullFinishing = 1,
        HalfFinishing = 2,
        NoFinishing=3
    }
    public enum TimeClosePeriod
    {
        Minute=0,
        Hour=1,
        Day=2
    }
    public enum MeterIllegalAction
    {
        NotSpecified,
        Action1,
        Action2


    }
    public enum MeterStatus
    {
        NotSpecified,
        Occupied,
        UnderFinishing,
        ClosedWithElcticity,
        ClosedWithNoElectricity
    }
    public enum UnitType
    {
        NotSpecified,//€Ì— „Õœœ
        Residential,//”ﬂ‰Ï
        Commercial,// Ã«—Ï
        Economical,//«ﬁ ’«œÏ
        Administrative//«œ«—Ï


    }
    public enum UnitCodeContent
    {
        ProjectCode = 0,
        TowerCode = 1,
        FloorOrder = 2,
        UnitOrder = 3,
        Section=4
    }
    public class UnitBiz : BaseSingleBiz
    {
        #region Private Data
        UnitModelBiz _ModelBiz;
        ReservationBiz _CurrentReservation;
        UnitCellCol _CellCol;
        UserBiz _CurrentUser;
        UnitTypeBiz _TypeBiz;
        UnitMainTypeBiz _MainTypeBiz;
        UnitUsageTypeBiz _UsageTypeBiz;
        UnitViewBiz _ViewBiz;
        UnitCategoryBiz _CategoryBiz;
        public UnitCategoryBiz CategoryBiz
        {
            get
            {
                if (_CategoryBiz == null)
                    _CategoryBiz = new UnitCategoryBiz();
                return _CategoryBiz;
            }
            set => _CategoryBiz = value;
        }
        public int CategoryGrade
        {
            get => ((UnitDb)_BaseDb).CategoryGrade;
        }
        UnitPeripheralCol _PeripheralCol;
        UnitPeripheralCol _DeletedPeripheralCol;
        #endregion
        #region Constructors
        public UnitBiz()
        {
            _BaseDb = new UnitDb();
            _ModelBiz = new UnitModelBiz();
            //_CurrentReservation = new ReservationBiz();
        }
        public UnitBiz(DataRow objDr)
        {
            _BaseDb = new UnitDb(objDr);
            _TypeBiz = new UnitTypeBiz(objDr);
            _ModelBiz = new UnitModelBiz(objDr);
            if (((UnitDb)_BaseDb).View != 0)
                _ViewBiz = new UnitViewBiz(objDr);
            if (((UnitDb)_BaseDb).Category != 0)
                _CategoryBiz= new UnitCategoryBiz(objDr);
            if (((UnitDb)_BaseDb).MainType != 0)
                _MainTypeBiz = new UnitMainTypeBiz(objDr);
            if (((UnitDb)_BaseDb).UsageType != 0)
                _UsageTypeBiz = new UnitUsageTypeBiz(objDr);

            if (((UnitDb)_BaseDb).Tower != 0)
                _TowerBiz = new TowerBiz(objDr);


        }
        public UnitBiz(UnitDb objUnitDb)
        {
            _BaseDb =objUnitDb;
            _ModelBiz = new UnitModelBiz(((UnitDb)_BaseDb).ModelDb);
           
        }
        public UnitBiz(string strUnitCode,CellBiz objCellBiz,int intUnitStatus)
        {
           
            _BaseDb = new UnitDb();
            _ModelBiz = new UnitModelBiz();
            _TypeBiz = new UnitTypeBiz();
            if (strUnitCode == null || strUnitCode == "")
                return;
            UnitDb objDb = new UnitDb();
            objDb.CellFamilyID = objCellBiz.ID == objCellBiz.FamilyID ? objCellBiz.ID : 0;
            objDb.CellIDs = objCellBiz.ID == objCellBiz.FamilyID ? "" : objCellBiz.IDsStr;
            objDb.NameA = strUnitCode;
            objDb.UnitStatus = intUnitStatus;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                _BaseDb = new UnitDb(objDr);
                _TypeBiz = new UnitTypeBiz(objDr);
                if (((UnitDb)_BaseDb).View != 0)
                    _ViewBiz = new UnitViewBiz(objDr);
                if (((UnitDb)_BaseDb).MainType != 0)
                    _MainTypeBiz = new UnitMainTypeBiz(objDr);
                if (((UnitDb)_BaseDb).UsageType != 0)
                    _UsageTypeBiz = new UnitUsageTypeBiz(objDr);
                _ModelBiz = new UnitModelBiz(objDr);
            }
            
            
 
        }
        public UnitBiz(string strUnitCode, CellBiz objCellBiz, string strStatus)
        {
            _BaseDb = new UnitDb(strUnitCode, objCellBiz.ID, strStatus);
            if (_BaseDb.ID != 0)
            {
                _ModelBiz = new UnitModelBiz(((UnitDb)_BaseDb).ModelDb);
            }

        }

        #endregion
        #region Public Properties
        public string Code
        {
            get { return ((UnitDb)_BaseDb).Code; }
            set { ((UnitDb)_BaseDb).Code = value; }
        }
        public string Neighbor1
        {
            get { return ((UnitDb)_BaseDb).Neighbor1; }
            set { ((UnitDb)_BaseDb).Neighbor1 = value; }
        }
        public string Neighbor2
        {
            get { return ((UnitDb)_BaseDb).Neighbor2; }
            set { ((UnitDb)_BaseDb).Neighbor2 = value; }
        }

        public string Neighbor3
        {
            get { return ((UnitDb)_BaseDb).Neighbor3; }
            set { ((UnitDb)_BaseDb).Neighbor3 = value; }
        }

        public string Neighbor4
        {
            get { return ((UnitDb)_BaseDb).Neighbor4; }
            set { ((UnitDb)_BaseDb).Neighbor4 = value; }
        }
        public bool IsStopped
        {
            get { return ((UnitDb)_BaseDb).IsStopped; }
            set { ((UnitDb)_BaseDb).IsStopped = value; }
        }


        public int View
        {
            get { return ((UnitDb)_BaseDb).View; }
            set { ((UnitDb)_BaseDb).View = value; }
        }

        public string SapView
        {
            get { return ((UnitDb)_BaseDb).SapView; }
            set { ((UnitDb)_BaseDb).SapView = value; }
        }


        public int MainType
        {
            get { return ((UnitDb)_BaseDb).MainType; }
            set { ((UnitDb)_BaseDb).MainType = value; }
        }

        public double UnitSalesPrice
        {
            get { return ((UnitDb)_BaseDb).UnitSalesPrice; }
            set { ((UnitDb)_BaseDb).UnitSalesPrice = value; }
        }
        public int UsageType
        {
            get { return ((UnitDb)_BaseDb).UsageType; }
            set { ((UnitDb)_BaseDb).UsageType = value; }
        }
        public bool IsReadyForDelivery
        {
            get { return ((UnitDb)_BaseDb).IsReadyForDelivery; }
            set { ((UnitDb)_BaseDb).IsReadyForDelivery = value; }
        }
        public DateTime ReadyForDeliveryDate
        {
            get { return ((UnitDb)_BaseDb).ReadyForDeliveryDate; }
            set { ((UnitDb)_BaseDb).ReadyForDeliveryDate = value; }
        }
        public UnitMainTypeBiz MainTypeBiz
        {
            set
            {
                _MainTypeBiz = value;
            }
            get
            {
                if (_MainTypeBiz == null)
                    _MainTypeBiz = new UnitMainTypeBiz();
                return _MainTypeBiz;
            }
        }
        public UnitUsageTypeBiz UsageTypeBiz
        {
            set
            {
                _UsageTypeBiz = value;
            }
            get
            {
                if (_UsageTypeBiz == null)
                    _UsageTypeBiz = new UnitUsageTypeBiz();
                return _UsageTypeBiz;
            }
        }
        public UnitViewBiz ViewBiz
        {
            set
            {
                _ViewBiz = value;
            }
            get
            {
                if (_ViewBiz == null)
                    _ViewBiz = new UnitViewBiz();
                return _ViewBiz;
            }
        }
        public UnitModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                return _ModelBiz;
            }
        }

        public ReservationBiz CurrentReservation
        {
            set
            {
                _CurrentReservation = value;
            }
            get
            {
                if(_CurrentReservation == null)
                {

                    if (((UnitDb)_BaseDb).Reservation != 0)
                    {
                        //DataRow[] arrDr = UnitDb.CachReservationDataTable.Select("ReservationID=" + ((UnitDb)_BaseDb).Reservation);
                        //if (arrDr.Length > 0)
                        //{
                        //    _CurrentReservation = new ReservationBiz(arrDr[0]);
                        //}
                        //else
                            _CurrentReservation = new ReservationBiz();
                            _CurrentReservation.ID = ((UnitDb)_BaseDb).Reservation;
                            _CurrentReservation.CustomerCol = new CustomerCol(true);
                            _CurrentReservation.IsContracted = ((UnitDb)_BaseDb).IsContracted;
                            _CurrentReservation.ContractingDate = ((UnitDb)_BaseDb).ContractingDate;
                            _CurrentReservation.Date = ((UnitDb)_BaseDb).ReservationDate;

                        CustomerBiz objCustomerBiz = new CustomerBiz();
                        objCustomerBiz.NameA = ((UnitDb)_BaseDb).CustomerStr;
                 
                        _CurrentReservation.CustomerCol.Add(objCustomerBiz);
                        TempReservationPaymentBiz objTempPayment = new TempReservationPaymentBiz();
                        objTempPayment.Value = ((UnitDb)_BaseDb).ReservationPaidValue;
                        _CurrentReservation.PaymentCol = new TempReservationPaymentCol(true);
                        _CurrentReservation.PaymentCol.Add(objTempPayment);
                        _CurrentReservation.TempPayment = ((UnitDb)_BaseDb).ReservationPaidValue;
                        _CurrentReservation.DeliveryDate = ((UnitDb)_BaseDb).ReservationDeliverDate;
                        if (_CurrentReservation.IsContracted)
                        {
                            _CurrentReservation.Status = ReservationStatus.Contracting;
                            _CurrentReservation.StatusDate = ((UnitDb)_BaseDb).ContractingDate;
                        }
                        else if (_CurrentReservation.PaymentCol.TotalValue == 0)
                        {
                            _CurrentReservation.Status = ReservationStatus.Primary;
                            _CurrentReservation.StatusDate = ((UnitDb)_BaseDb).ReservationDate;
                        }
                        else
                        {
                            _CurrentReservation.Status = ReservationStatus.DownPayment;
                            _CurrentReservation.StatusDate = ((UnitDb)_BaseDb).ReservationDate;
                        }
                        if (((UnitDb)_BaseDb).TenancyID != 0)
                        {
                            _CurrentReservation.TenancyID = ((UnitDb)_BaseDb).TenancyID;
                            _CurrentReservation.TenancyEndDate = ((UnitDb)_BaseDb).TenancyEndDate;
                            _CurrentReservation.IsTenancy = true;
                        }
                      // _CurrentReservation.AddUnit(this);


                    }
                    else
                        _CurrentReservation = new ReservationBiz();
                }
                return _CurrentReservation;
            }

        }
        public string CustomerStr
        {
            set
            {
                ((UnitDb)_BaseDb).CustomerStr = value;
            }
            get
            {
                return CurrentReservation.CustomerStr;
            }
        }
        public bool IsDelivered
        {
            set
            {
                ((UnitDb)_BaseDb).IsDelivered = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).IsDelivered;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                ((UnitDb)_BaseDb).DeliveryDate = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).DeliveryDate;
            }
        }
        internal UserBiz UserClosed
        {
            get
            {
                if (_CurrentUser == null)
                {
                    _CurrentUser = new UserBiz();
                    if (((UnitDb)_BaseDb).UserClosed != 0)
                    {
                        DataRow[] arrDr = UnitDb.CachUserDatatable.Select("UserID=" + ((UnitDb)_BaseDb).UserClosed);
                        if (arrDr.Length > 0)
                            _CurrentUser = new UserBiz(arrDr[0]);
 
                    }
                }

                return _CurrentUser;
            }
        }
        public int ReservationID
        {
            set 
            {
                ((UnitDb)_BaseDb).Reservation = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).Reservation;
            }
        }
        public int Status
        {
            get
            {
                return ((UnitDb)_BaseDb).UnitStatus;
            }

        }
        public bool IsClosed
        { get => ((UnitDb)_BaseDb).IsClosed; }
        public DateTime CloseDate
        {
            get => ((UnitDb)_BaseDb).CloseDate;
        }
        public double ComputedTotalPrice
        {
            get
            {
                double Returned = 0;
                Returned = UnitSalesPrice * Survey;
                Returned += PeripheralCol.TotalPrice;
                return Returned;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                 string strReason = "";
                 string strUserName = UserClosed.EmployeeBiz.ID == 0 ?
                  UserClosed.FullName : UserClosed.EmployeeBiz.Name;
                if (((UnitDb)_BaseDb).UnitStatus == 2)
                {
                   
                    Returned = CurrentReservation.StatusStr + "(" + CurrentReservation.CustomerStr + ")";
                }
                else if (((UnitDb)_BaseDb).UnitStatus == 3)
                {
                    strReason = ((UnitDb)_BaseDb).CloseReason;
                    Returned = " „€·ﬁ… »‘ﬂ· œ«∆„ (" + strUserName  + " ) " + strReason ;
                }
                else if (((UnitDb)_BaseDb).UnitStatus == 4)
                {
                    strReason = ((UnitDb)_BaseDb).CloseReason;
                    Returned = " „€·ﬁ… „ƒﬁ « (" + strUserName + ") »«ﬁÏ (" + DateOpenStr + ")" + "-" + strReason;
                }
                else
                {
                    Returned = "›«—€…";
                   
                }
                if (((UnitDb)_BaseDb).UnitStatus != 2)
                {
                    if (IsDelegated)
                        Returned += "( ›ÊÌ÷ »«·»Ì⁄ ⁄·Ï „»·€-"+ ((UnitDb)_BaseDb).DelegationValue.ToString() +"-)";
                    if (IsForReReservation)
                        Returned += "(«⁄«œ… ÕÃ“)";
                }
                return Returned;
            }

        }
        public string StatusWithoutCustomerStr
        {
            get
            {
                string Returned = "";
                string strReason = "";
                string strUserName = UserClosed.EmployeeBiz.ID == 0 ?
                    UserClosed.FullName : UserClosed.EmployeeBiz.Name;
                if (((UnitDb)_BaseDb).UnitStatus == 2)
                {

                    Returned = CurrentReservation.StatusStr ;
                }
                else if (((UnitDb)_BaseDb).UnitStatus == 3)
                {
                    strReason = ((UnitDb)_BaseDb).CloseReason;
                    Returned = " „€·ﬁ… »‘ﬂ· œ«∆„ (" +strUserName+ " ) " + strReason;
                }
                else if (((UnitDb)_BaseDb).UnitStatus == 4)
                {
                    strReason = ((UnitDb)_BaseDb).CloseReason;
                    Returned = " „€·ﬁ… „ƒﬁ « (" + strUserName + ") »«ﬁÏ (" + DateOpenStr + ")" + "-" + strReason;
                }
                else
                {
                    Returned = "›«—€…";

                }
                if (((UnitDb)_BaseDb).UnitStatus != 2)
                {
                    if (IsDelegated)
                        Returned += "( ›ÊÌ÷ »«·»Ì⁄ ⁄·Ï „»·€-" + ((UnitDb)_BaseDb).DelegationValue.ToString() + "-)";
                    if (IsForReReservation)
                        Returned += "(«⁄«œ… ÕÃ“)";
                }
                return Returned;
            }

        }
        public string DateOpenStr
        {
            get 
            {
                string Returned = "";
                if (((UnitDb)_BaseDb).UnitStatus == 4)
                {
                    if (((UnitDb)_BaseDb).RemainingDay > 0)
                    {
                        Returned = ((UnitDb)_BaseDb).RemainingDay + " ÌÊ„ ";
                    }
                    else if (((UnitDb)_BaseDb).RemainingHour > 0)
                    {
                        int intHour, intMinute;
                        intMinute = ((UnitDb)_BaseDb).RemainingMinute % 60;
                        intHour = ((UnitDb)_BaseDb).RemainingMinute / 60;
                        if (intHour > 0)
                            Returned = intHour + " ”«⁄… ";
                         Returned =Returned + intMinute + " œﬁÌﬁ… ";
                    }
                    else if (((UnitDb)_BaseDb).RemainingMinute > 0)
                    {
                        Returned = ((UnitDb)_BaseDb).RemainingMinute + " œﬁÌﬁ… ";
                    }
                }
                return Returned; 
            }
        }
        public double Survey
        {
            set
            {
                ((UnitDb)_BaseDb).Survey = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).Survey;
            }

        }
        public double Height
        {
            set
            {
                ((UnitDb)_BaseDb).Height = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).Height;
            }

        }
        public string FullName
        {
            set
            {
                ((UnitDb)_BaseDb).FullName = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).FullName;
            }
        }
        public string PeripheralFullName
        {
            get
            {
                string Returned = "";
                if (_PeripheralCol != null)
                {
                    foreach (UnitPeripheralBiz objBiz in _PeripheralCol)
                    {
                        if (Returned != "")
                            Returned += "&";
                        Returned += objBiz.TypeBiz.Name + "-" + objBiz.Survey.ToString();
                    }
                }
                return Returned; 

            }
        }
        public UnitTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new UnitTypeBiz();
                return _TypeBiz;
            }
        }
        public static List<string> UnitTypeArr
        {
            get
            {
                List<string> Returned = new List<string>();
        //         NotSpecified,//€Ì— „Õœœ
                Returned.Add("€Ì— „Õœœ");
        //Residential,//”ﬂ‰Ï
                Returned.Add("”ﬂ‰Ï");
        //Commercial,// Ã«—Ï
                Returned.Add(" Ã«—Ï");
        //Economical,//«ﬁ ’«œÏ
                Returned.Add("«ﬁ ’«œÏ");
        //Administrative//«œ«—Ï
                Returned.Add("≈œ«—Ï");
                return Returned;
            }
        }
        public bool HasElectricityMeter
        {
            set
            {
                ((UnitDb)_BaseDb).HasElectricityMeter = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).HasElectricityMeter;
            }
        }
        public bool ElectricityMeterHasStartDate
        {
            set
            {
                ((UnitDb)_BaseDb).ElectricityMeterHasStartDate = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).ElectricityMeterHasStartDate;
            }
        }
        public DateTime ElectricityMeterStartDate
        {
            set
            {
                ((UnitDb)_BaseDb).ElectricityMeterStartDate = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).ElectricityMeterStartDate;
            }
        }
        public string ElectricityMeterOwner
        {
            set
            {
                ((UnitDb)_BaseDb).ElectricityMeterOwner = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).ElectricityMeterOwner;
            }
        }
        public MeterStatus ElectricityMeterStatus
        {
            set
            {
                ((UnitDb)_BaseDb).ElectricityMeterStatus = (int)value;
            }
            get
            {
                return (MeterStatus)((UnitDb)_BaseDb).ElectricityMeterStatus;
            }
        }
        public MeterIllegalAction ElectricityMeterIllegalAction
        {
            set
            {
                ((UnitDb)_BaseDb).ElectricityMeterIllegalAction =(int) value;
            }
            get
            {
                return (MeterIllegalAction)((UnitDb)_BaseDb).ElectricityMeterIllegalAction;
            }
        }
        public string ElecticityMeterNotes
        {
            set
            {
                ((UnitDb)_BaseDb).ElecticityMeterNotes = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).ElecticityMeterNotes;
            }
        }
        public UnitCellCol CellCol
        {
            set
            {
                _CellCol = value;
            }
            get
            {
                if (_CellCol == null)
                {
                    _CellCol = new UnitCellCol(true);
                    if (ID != 0 && UnitDb.CachUnitCellTable != null)
                    {
                        DataRow []arrDr = UnitDb.CachUnitCellTable.Select("UnitID=" + ID);
                       
                        foreach (DataRow objDr in arrDr)
                        {
                            _CellCol.Add(new UnitCellBiz(objDr));
                        }
                    }

                }
                return _CellCol;
            }
        }

        public static void UploadNumericEvaluationExcelTable(DataTable dtTemp)
        {
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitTable = dtTemp;
             
            objUnitDb.UploadNumericEvaluation();
        }

        public UnitPeripheralCol PeripheralCol
        {
            set
            {
                _PeripheralCol = value;
            }
            get
            {
                if (_PeripheralCol == null)
                {
                    _PeripheralCol = new UnitPeripheralCol(true);
                    if (ID != 0)
                    {
                        UnitPeripheralDb objDb = new UnitPeripheralDb();
                        objDb.Unit = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _PeripheralCol.Add(new UnitPeripheralBiz(objDr));

                        }
                    }
                }
                return _PeripheralCol;
            }
        }
        public UnitPeripheralCol DeletedPeripheralCol
        {
            set
            {
                _DeletedPeripheralCol = value;
            }
            get
            {
                if (_DeletedPeripheralCol == null)
                {
                    _DeletedPeripheralCol = new UnitPeripheralCol(true);
                }
                return _DeletedPeripheralCol;
            }
        }


        public CellBiz Floor
        {
            set
            {
                ((UnitDb)_BaseDb).MinCellID = ((CellBiz)value).ID;
            }
            get
            {
                CellBiz objCellBiz = new CellBiz(((UnitDb)_BaseDb).MinCellID);

                return new CellBiz(((UnitDb)_BaseDb).MinCellID);
            }

        }
        public CellBiz FloorTo
        {
         
            get
            {
                CellBiz objCellBiz = new CellBiz();
                if (((UnitDb)_BaseDb).MaxCellID != 0 && ((UnitDb)_BaseDb).MaxCellID != ((UnitDb)_BaseDb).MinCellID)
                {
                    objCellBiz = new CellBiz(((UnitDb)_BaseDb).MaxCellID);
                }
                return objCellBiz;
            }

        }
        public CellBiz Project
        {
            get
            {
                CellBiz objCellBiz = new CellBiz(((UnitDb)_BaseDb).MinCellID);

                return new CellBiz(objCellBiz.FamilyID);
            }
 
        }
        public CellBiz Tower
        {
            get
            {
                CellBiz objCellBiz = new CellBiz(((UnitDb)_BaseDb).MinCellID);
                
                    return new CellBiz(objCellBiz.ParentID);
                
            }

        }


        internal int MinCellID
        {
            set
            {
                ((UnitDb)_BaseDb).MinCellID = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).MinCellID;
            }
        }
        public string Desc
        {
            set
            {
                ((UnitDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).Desc;
            }
        }
        public int Order
        {
            set
            {
                ((UnitDb)_BaseDb).Order = value;
            }
            get
            {
                return ((UnitDb)_BaseDb).Order;
            }
        }
        public bool IsDelegated
        {
            get
            {
                return ((UnitDb)_BaseDb).IsDelegated;
            }
        }
        public bool IsForReReservation
        {
            get
            {
                return ((UnitDb)_BaseDb).IsForReReservation;
            }
        }

        FloorBiz _FloorBiz;
        public FloorBiz FloorBiz
        {
            set
            {
                _FloorBiz = value;
            }
            get
            {
                if (_FloorBiz == null)
                {
                    _FloorBiz = FloorBiz.FloorCol[((UnitDb)_BaseDb).Floor.ToString()];
                }
                return _FloorBiz;
            }
        }
        FloorBiz _FloorToBiz;
        public FloorBiz FloorToBiz
        {
            set
            {
                _FloorToBiz = value;
            }
            get
            {
                if (_FloorToBiz == null)
                {
                    _FloorToBiz = FloorBiz.FloorCol[((UnitDb)_BaseDb).FloorTo.ToString()];
                }
                return _FloorToBiz;
            }
        }
        TowerBiz _TowerBiz;

        public TowerBiz TowerBiz
        {
            get
            {
                if (_TowerBiz == null)
                    _TowerBiz = new TowerBiz();
                return _TowerBiz;
            }
            set
            {
                _TowerBiz = value;
            }
        }


        public string FloorStr
        {
            get
            {
                string Returned = "";
                Returned = FloorBiz.Name;
                if (FloorToBiz.Value >= 96 && FloorToBiz.Value > FloorBiz.Value)
                {
                    Returned = "„‰ «·œÊ— " + FloorBiz.Name + " «·Ï «·œÊ—  " + FloorToBiz.Name;
                }
                return Returned;
            }
        }
        public int EndUnitFloor
        {
            get { return ((UnitDb)_BaseDb).EndUnitFloor; }
            set { ((UnitDb)_BaseDb).EndUnitFloor = value; }
        }
        public UnitFloorBiz EndUnitFloorBiz
        {
            get 
            {
                return   UnitFloorBiz.FloorCol[((UnitDb)_BaseDb).EndUnitFloor.ToString()];
            }
            set { ((UnitDb)_BaseDb).EndUnitFloor = ((UnitFloorBiz)value).Value; }
        }
        public int StartUnitFloor
        {
            get { return ((UnitDb)_BaseDb).StartUnitFloor; }
            set { ((UnitDb)_BaseDb).StartUnitFloor = value; }
        }
        public string UnitStr
        {
            get
            {


                string Returned = Name;
                CellBiz objCellBiz = new CellBiz(((UnitDb)_BaseDb).MinCellID);

               
                Returned = objCellBiz.GetFullAlterName(26) + " - " + Returned;
              
                return Returned;
            }
        }
        public string PeripheralDesc
        {
            get
            {
                if (_PeripheralCol == null)
                    return ((UnitDb)_BaseDb).PeripheralDesc;
                else 
                {
                    string Returned = "";
                    foreach(UnitPeripheralBiz objBiz in _PeripheralCol)
                    {
                        if (Returned != "")
                            Returned += "&";
                        Returned += objBiz.TypeBiz.Name + "-" + objBiz.Survey.ToString();
                    }
                    return Returned;
                }
            }
        }
        public static List<string> MeterStatusStrArr
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("€Ì— „Õœœ");
                Returned.Add("„”ﬂÊ‰…");
                Returned.Add(" Õ  «· ‘ÿÌ»");
                Returned.Add("„€·ﬁ… »Â«  Ì«—");
                Returned.Add("„€·ﬁ… ·Ì” »Â«  Ì«—");
               
                return Returned;
            }
        }
        public static List<string> MeterIllegalActionStrArr
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("€Ì— „Õœœ");
                Returned.Add("„Õ÷—");
                Returned.Add("„„«—”…");
                

                return Returned;
            }
        }
       static List<string> _LstCodeKeys;
        public static List<string> LstCodeKeys
        {
            get
            {
                if (_LstCodeKeys == null)
                {
                    _LstCodeKeys = new List<string>();
                    _LstCodeKeys.Add("{Project}");
                    _LstCodeKeys.Add("{Tower}");
                    _LstCodeKeys.Add("{Floor}");
                    _LstCodeKeys.Add("{FlatNo}");
                    _LstCodeKeys.Add("{Section}");
                }
                return _LstCodeKeys;
            }
        }
        public double NumericEvaluation
        {
            get => ((UnitDb)_BaseDb).NumericEvaluation;
            
        }
        #endregion
        #region Private Methods
        internal void EditCurrentReservation()
        {
            if (((UnitDb)_BaseDb).Reservation == _CurrentReservation.ID)
                return;
            ((UnitDb)_BaseDb).Reservation = _CurrentReservation.ID;
            ((UnitDb)_BaseDb).EditCurrentReservation();

        }

        #endregion
        #region Public Methods
        public  void Add()
        {
            if (_CurrentReservation == null)
                _CurrentReservation = new ReservationBiz();
            if (_ModelBiz == null)
                _ModelBiz = new UnitModelBiz();
            ((UnitDb)_BaseDb).Reservation = _CurrentReservation.ID;
            ((UnitDb)_BaseDb).ModelID = _ModelBiz.ID;
            ((UnitDb)_BaseDb).UnitType = _TypeBiz.ID;
           
           
                //_BaseD
            if (_CellCol == null)
                _CellCol = new UnitCellCol(true);
            ((UnitDb)_BaseDb).CellTable = _CellCol.GetTable();
            ((UnitDb)_BaseDb).PeripheralTable = PeripheralCol.GetTable();
            ((UnitDb)_BaseDb).DeletedPeripheralTable = DeletedPeripheralCol.GetTable();
            ((UnitDb)_BaseDb).MainType = MainTypeBiz.ID;
            ((UnitDb)_BaseDb).UsageType = UsageTypeBiz.ID;
            ((UnitDb)_BaseDb).View = ViewBiz.ID;
            ((UnitDb)_BaseDb).Add();

        }
        public void Edit()
        {
            if (_CurrentReservation == null)
                _CurrentReservation = new ReservationBiz();
            if (_ModelBiz == null)
                _ModelBiz = new UnitModelBiz();
            ((UnitDb)_BaseDb).Reservation = _CurrentReservation.ID;
            if (_CellCol == null)
                _CellCol = new UnitCellCol(true);
            ((UnitDb)_BaseDb).CellTable = _CellCol.GetTable();
            ((UnitDb)_BaseDb).ModelID = _ModelBiz.ID;
            ((UnitDb)_BaseDb).UnitType = _TypeBiz.ID;
            ((UnitDb)_BaseDb).PeripheralTable = PeripheralCol.GetTable();
            ((UnitDb)_BaseDb).DeletedPeripheralTable = DeletedPeripheralCol.GetTable();
            ((UnitDb)_BaseDb).MainType = MainTypeBiz.ID;
            ((UnitDb)_BaseDb).UsageType = UsageTypeBiz.ID;
            ((UnitDb)_BaseDb).View = ViewBiz.ID;
            ((UnitDb)_BaseDb).Edit();
        }
        public void Delete()
        {
           
           _BaseDb.Delete();
        }
        public bool Close(double dblTimeAmount,bool blIsPermanent,TimeClosePeriod objClosePeriod,string strReason)
        {

            ((UnitDb)_BaseDb).CloseReason = strReason;
            if (!blIsPermanent)
            {
                ((UnitDb)_BaseDb).TimeClose = dblTimeAmount;
                ((UnitDb)_BaseDb).ClosePeriod = (int)objClosePeriod;

            }
            else
                ((UnitDb)_BaseDb).PermanentClosed = true;
            ((UnitDb)_BaseDb).CloseUnit();
            return ((UnitDb)_BaseDb).EditSucceeded;

        }
        public bool Open()
        {


            ((UnitDb)_BaseDb).OpenUnit();
            return ((UnitDb)_BaseDb).EditSucceeded;

        }
        public static UnitCol UserClosedUnit
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                UnitDb objUnitDb = new UnitDb();
                objUnitDb.GetClosed = true;
                DataTable dtTemp = objUnitDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new UnitBiz(objDr));
                }
                return Returned;
            }
        }
        public static MeterIllegalAction GetIllegalAction(string strAction)
        {
            if(strAction == null)
                return MeterIllegalAction.NotSpecified; 
            for(int intIndex = 0;intIndex<MeterIllegalActionStrArr.Count;intIndex++)
            {
                if (MeterIllegalActionStrArr[intIndex] == strAction)
                {
                    return (MeterIllegalAction)intIndex;

                }
                
                
            }
            return MeterIllegalAction.NotSpecified;

        }
        public static MeterStatus GetStatus(string strStatus)
        {
            if (strStatus == null)
                return MeterStatus.NotSpecified;
            for (int intIndex = 0; intIndex < MeterStatusStrArr.Count; intIndex++)
            {
                if (MeterStatusStrArr[intIndex] == strStatus)
                {
                    return (MeterStatus)intIndex;

                }


            }
            return MeterStatus.NotSpecified;

        }
        static string GetUnitCodeValue(UnitCodeContent objContent, TowerBiz objTowerBiz,
           FloorBiz objFloorBiz, int intUnitOrder)
        {
            string Returned = "";
            if (objContent == UnitCodeContent.FloorOrder)
                Returned = (objFloorBiz.Value - 100).ToString();
            else if (objContent == UnitCodeContent.ProjectCode)
                Returned = objTowerBiz.ProjectBiz.Code;
            else if (objContent == UnitCodeContent.TowerCode)
                Returned = objTowerBiz.Code;
            else if (objContent == UnitCodeContent.UnitOrder)
                Returned = intUnitOrder.ToString();

            return Returned;


        }
      
        public static string GetUnitCode(string strFormat, TowerBiz objTowerBiz, FloorBiz objFloorBiz, int intUnitOrder)
        {
            string Returned = strFormat;
            for (int intIndex = 0; intIndex < LstCodeKeys.Count; intIndex++)
            {
                Returned = Returned.Replace(LstCodeKeys[intIndex],
                    GetUnitCodeValue((UnitCodeContent)intIndex,
                    objTowerBiz, objFloorBiz, intUnitOrder));


            }
            return Returned;
        }
        public static void UploadExcelTable(string strCodePattern,DataTable dtTemp )
        {
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.CodePattern = strCodePattern;
            objUnitDb.UnitTable = dtTemp;
            objUnitDb.UploadExcel();

        }
        public static void EditExcel( DataTable dtTemp)
        {
            UnitDb objUnitDb = new UnitDb();
            
            objUnitDb.UnitTable = dtTemp;
            objUnitDb.EditAreaUploadedExcel();

        }
        public static void UploadPriceExcelTable(DateTime dtPriceDate, DataTable dtTemp)
        {
            UnitDb objUnitDb = new UnitDb();
            
            objUnitDb.UnitTable = dtTemp;
            objUnitDb.PriceDate = dtPriceDate;
            objUnitDb.UploadPriceExcel();

        }
        public static void UploadAttributeExcelTable(DataTable dtTemp)
        {
            UnitDb objUnitDb = new UnitDb();

            objUnitDb.UnitTable = dtTemp;
            
            objUnitDb.UploadAttributeExcel();

        }
        #endregion

    }
}
