using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationInstallmentDb 
    {
        #region Private Data
        protected int _ID;
        protected int _ReservationID;
        protected int _InstallmentType;
        protected int _InstallmentNo;
        protected string _Desc;
        protected string _Note;
        protected double _InstallmentValue;
        protected DateTime _InstallmentDueDate;
        protected int _InstallmentStatus;
        protected int _InstallmentGroup;
        
        DataTable _Installment;
        string _ReservationIDS;
       
        string _CellIDs;
        //string _UnitStr;
        DateTime _ReservationDate;
        bool _IsContracted;
        DateTime _ContractingDate;
        string _CustomerStr;
        string _CustomerPhone;
        string _CustomerMobile;
        string _UnitStr;
       
        int _TowerID;
        string _TowerName;
        int _TowerOrder;
        string _ProjectName;
        string _InstallmentTypeNameA;
        int _InstallmentMainType;
        int _CellID;
        double _TotalPaidValue;
        DateTime _PaymentDate;
        double _TotalValue;
        double _TotalCheckValue;
        double _TotalRemainingValue;
        double _TotalDiscountValue;
        int _CampaignCustomerID;
        #region Private Data for Sum
        int _D;
        int _M;
        int _Y;
        double _InstallmentPaidValue;
        double _InstallmentDiscount;
        double _InstallmentRemainingValue;
        double _InstallmentCheckValue;

        double _PeriodicPaymentValue;
       
        double _PeriodicPaymentPaidValue;
        double _PeriodicPaymentDiscount;
        double _PeriodicPaymentRemainingValue;
        double _PeriodicPaymentCheckValue;
        double _DeliveryPaymentValue;
        double _DeliveryPaymentPaidValue;
        double _DeliveryPaymentDiscount;
        double _DeliveryPaymentRemainingValue;
        double _DeliveryPaymentCheckValue;
        double _OtherPaymentValue;
        double _OtherPaymentPaidValue;
        double _OtherPaymentDiscount;
        double _OtherPaymentRemainingValue;
        double _OtherPaymentCheckValue;
        #endregion
        #region Private data for Search
        int _CellFamilyID;
        string _CellFamilyIDs;

        public string CellFamilyIDs
        {
            
            set { _CellFamilyIDs = value; }
        }
        int _IsForeignStatus;

        public int IsForeignStatus
        {
           
            set { _IsForeignStatus = value; }
        }
        //string _CellIDs;
        string _ExmptedCampaignStr;
        DateTime _StartDueDate;
        DateTime _EndDueDate;
        bool _IsContractingDateRange;
        DateTime _StartContractingDate;
        DateTime _EndContractingDate;
       int  _DateRangeStatus;
        string _TypeIDs;
        int _StatusSearch;
        int _Campaign;
        int _CampaignStatus;
        int _ReservationStatus;
        string _ReservationNote;

       
        int _ReservationParentStatus;
        int _PaymentDateStatus;
        DateTime _PaymentDateStart;
        DateTime _PaymentDateEnd;
        string _UnitCode;
        int _CampaignContactStatus;
        int _CampaignMonitorStatus;/*
                                    * 0 dont care 
                                    * 1 due Monitor
                                    * 2 not due monitor
                                    */

        int _CampaignRuleID;
        int _CampaignRulePeriodType;/*
                                     * 0 discrete period
                                     * 1 continious period
                                     */
        int _UnitDeliveryStatus;
        int _TowerDeliveryStatus;
        static bool _ShortReservation;
        string _CustomerIDs;
        int _AfterDeliveryStatus;/*
                                  * 0 dont care
                                  * 1 after delivery
                                  * 2 before delivery
                                  */
        #endregion
        #region GroupSearchData
        #region SumSearch
        bool _IsTowerGroup;
        bool _IsProjectGroup;
        bool _IsYearGroup;
        bool _IsMonthGroup;
        bool _IsDayGroup;
        bool _IsMainTypeGroup;
        bool _IsCustomerGroup;
        
        bool _IsUnitGroup;
        bool _IsInstallmentTypeGroup;
         #endregion

        #endregion
        #endregion
        #region Constructors
        public ReservationInstallmentDb()
        { 

        }
        public ReservationInstallmentDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
            else
                _ID = 0;
        }
        public ReservationInstallmentDb(DataRow objDR)
        {
            SetData(objDR);

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }

        }
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }

        }
        public int InstallmentType
        {
            get
            {
                return _InstallmentType;
            }
            set
            {
                _InstallmentType = value;
            }
        }
        public int InstallmentNo
        {
            set
            {
                _InstallmentNo = value;
            }
            get
            {
                return _InstallmentNo;
            }

        }

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }

        }
        public string Note
        {
            set
            {
                _Note = value;
            }
            get
            {
                return _Note;
            }

        }
        public double InstallmentValue
        {
            set
            {
                _InstallmentValue = value;
            }
            get
            {
                return _InstallmentValue;
            }

        }
        public int Campaign
        {
            set
            {
                _Campaign = value;
            }
        }
        public int CampaignStatus
        {
            set
            {
                _CampaignStatus = value;
            }
        }
        public string ExmptedCampaignStr
        {
            set
            {
                _ExmptedCampaignStr = value;
            }
        }
        public DataTable Installment
        {
            set
            {
                _Installment = value;
            }

        }
        public string TypeIDs
        {
            set
            {
                _TypeIDs = value;
            }
        }
        public DateTime InstallmentDueDate
        {
            set
            {
                _InstallmentDueDate = value;
            }
            get
            {
                return _InstallmentDueDate;
            }

        }

        public DateTime StartDueDate
        {
            set
            {
                _StartDueDate = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }

        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public DateTime EndDueDate
        {
            set
            {
                _EndDueDate = value;
            }
        }
        public int ReservationParentStatus
        {
            set
            {
                _ReservationParentStatus = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
        }
        public int InstallmentStatus
        {
            set
            {
                _InstallmentStatus = value;
            }
            get
            {
                return _InstallmentStatus;
            }

        }
        public int InstallmentGroup
        {
            set
            {
                _InstallmentGroup = value;
            }
            get
            {
                return _InstallmentGroup;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDS = value;
            }
        }
        public int DateRangeStatus
        {
            set
            {
                _DateRangeStatus = value;
            }
        }
        public int StatusSearch
        {
            set
            {
                _StatusSearch = value;
            }

        }
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }
        }
        public string ReservationNote
        {
            get { return _ReservationNote; }
            set { _ReservationNote = value; }
        }
        public int PaymentDateStatus
        {
            set
            {
                _PaymentDateStatus = value;
            }
        }
        public DateTime PaymentDateStart
        {
            set
            {
                _PaymentDateStart = value;
            }
        }
        public DateTime PaymentDateEnd
        {
            set
            {
                _PaymentDateEnd = value;
            }
        }
        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
            }
        }
        public DateTime StartContractingDate
        {
            set
            {
                _StartContractingDate = value;
            }
        }
        public DateTime EndContractingDate
        {
            set
            {
                _EndContractingDate = value;
            }
        }
        public static bool ShortReservation
        {
            get
            {
                return _ShortReservation;
            }
            set
            {
                _ShortReservation = value;
            }
        }

        public int CampaignContactStatus
        {
            set
            {
                _CampaignContactStatus = value;
            }
        }
        public int CampaignMonitorStatus
        {
            set
            {
                _CampaignMonitorStatus = value;
            }
        }
        public int CampaignRuleID
        {
            set
            {
                _CampaignRuleID = value;
            }

        }
        public int CampaignRulePeriodType
        {
            set
            {
                _CampaignRulePeriodType = value;
            }
        }
        public int UnitDeliveryStatus
        {
            set
            {
                _UnitDeliveryStatus = value;
            }
        }
        int _UnitTypeID;

        public int UnitTypeID
        {
            get { return _UnitTypeID; }
            set { _UnitTypeID = value; }
        }
        public int TowerDeliveryStatus
        {
            set
            {
                _TowerDeliveryStatus = value;
            }
        }
        public int AfterDeliveryStatus
        {
            set
            {
                _AfterDeliveryStatus = value;
            }
        }
        int _ReservationCheckStatus;

        public int ReservationCheckStatus
        {
            get { return _ReservationCheckStatus; }
            set { _ReservationCheckStatus = value; }
        }
        string _ReservationCheckPlaces;

        public string ReservationCheckPlaces
        {
            get { return _ReservationCheckPlaces; }
            set { _ReservationCheckPlaces = value; }
        }
        int _ResubmissionType;

        public int ResubmissionType
        {
            get { return _ResubmissionType; }
            set { _ResubmissionType = value; }
        }
        bool _ResubmissionDateRange;

        public bool ResubmissionDateRange
        {
            get { return _ResubmissionDateRange; }
            set { _ResubmissionDateRange = value; }
        }
        DateTime _ResubmissionStartDate;

        public DateTime ResubmissionStartDate
        {
            get { return _ResubmissionStartDate; }
            set { _ResubmissionStartDate = value; }
        }
        DateTime _ResubmissionEndDate;

        public DateTime ResubmissionEndDate
        {
            get { return _ResubmissionEndDate; }
            set { _ResubmissionEndDate = value; }
        }
        #region Sum Search
        public bool IsTowerGroup
        {
            set
            {
                _IsTowerGroup = value;
            }
        }

        public bool IsProjectGroup
        {
            set
            {
                _IsProjectGroup = value;
            }
        }
        public bool IsYearGroup
        {
            set
            {
                _IsYearGroup = value;
            }
        }
        public bool IsMonthGroup
        {
            set
            {
                _IsMonthGroup = value;
            }
        }
        public bool IsDayGroup
        {
            set
            {
                _IsDayGroup = value;
            }
        }
        public bool IsMainTypeGroup
        {
            set
            {
                _IsMainTypeGroup = value;
            }
        }
        public bool IsCustomerGroup
        {
            set
            {
                _IsCustomerGroup = value;
            }
        }
       
        public bool IsUnitGroup
        {
            set
            {
                _IsUnitGroup = value;
            }
        }
        public bool IsInstallmentTypeGroup
        {
            set
            {
                _IsInstallmentTypeGroup = value;
            }
        }
        #endregion
        public DateTime ReservationDate
        {
            get
            {
                return _ReservationDate;
            }
        }
        public bool IsContracted
        {
            get
            {
                return _IsContracted;
            }
        }
        public DateTime ContractingDate
        {
            get
            {
                return _ContractingDate;
            }
        }

        public string CustomerStr
        {
            get
            {
                return _CustomerStr;
 
            }
        }
        public string CustomerMobile
        {
            get
            {
                return _CustomerMobile;
            }
        }
        public string CustomerPhone
        {
            get
            {
                return _CustomerPhone;
            }
        }
        public string UnitStr
        {
            get
            {
                return _UnitStr;
            }
        }
        public int TowerID
        {
            get
            {
                return _TowerID;
            }
        }
        public int CellID
        {
            get
            {
                return _CellID;
            }
        }
        public string TowerName
        {
            get 
            {
                return _TowerName;
            }
        }
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
        }
        public double TotalPaidValue
        {
            get
            {
                return _TotalPaidValue;
            }
        }
        public int CampaignCustomerID
        {
            get
            {
                return _CampaignCustomerID;
            }
        }
        public DateTime PaymentDate
        {
            get
            {
                return _PaymentDate;
            }
        }
        public double TotalDiscountValue
        {
            get
            {
                return _TotalDiscountValue;
            }
        }
        public double TotalValue
        {
            get
            {
                return _TotalValue;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                return _TotalCheckValue;
            }
        }
        public double TotalRemainingValue
        {
            get
            {
                return _TotalRemainingValue;
            }
        }

        #region SummeryData
        public int InstallmentMainType
        {
            get
            {
                return _InstallmentMainType;
            }
        }
        public string InstallmentTypeNameA
        {
            get
            {
                return _InstallmentTypeNameA;
            }
        }
        public int D
        {
            get
            {
                return _D;
            }
        }
        public int M
        {
            get
            {
                return _M;
            }
        }
        public int Y
        {
            get
            {
                return _Y;
            }
        }
        public double InstallmentPaidValue
        {
            get
            {
                return _InstallmentPaidValue;
            }
        }
        public double InstallmentDiscount
        {
            get
            {
                return _InstallmentDiscount;
            }
        }
        public double InstallmentRemainingValue
        {
            get
            {
                return _InstallmentRemainingValue;
            }
        }
        public double InstallmentCheckValue
         {
            get
            {
                return _InstallmentCheckValue;
            }
        }

        public double PeriodicPaymentValue
            {
            get
            {
                return _PeriodicPaymentValue;
            }
        }
        public double PeriodicPaymentPaidValue
            {
            get
            {
                return _PeriodicPaymentPaidValue;
            }
        }
        public double PeriodicPaymentDiscount 
            {
            get
            {
                return _PeriodicPaymentDiscount;
            }
        }
        public double PeriodicPaymentRemainingValue
        {
            get
            {
                return _PeriodicPaymentRemainingValue;
            }
        }
        public double PeriodicPaymentCheckValue
        {
            get
            {
                return _PeriodicPaymentCheckValue;
            }
        }
        public double DeliveryPaymentValue
        {
            get
            {
                return _DeliveryPaymentValue;
            }
        }
        public double DeliveryPaymentPaidValue
        {
            get
            {
                return _DeliveryPaymentPaidValue;
            }
        }
        public double DeliveryPaymentDiscount
        {
            get
            {
                return _DeliveryPaymentDiscount;
            }
        }
        public double DeliveryPaymentRemainingValue
        {
            get
            {
                return _DeliveryPaymentRemainingValue;
            }
        }
        public double DeliveryPaymentCheckValue
        {
            get
            {
                return _DeliveryPaymentCheckValue;
            }
        }
        public double OtherPaymentValue
        {
            get
            {
                return _OtherPaymentValue;
            }
        }
        public double OtherPaymentPaidValue
        {
            get
            {
                return _OtherPaymentPaidValue;
            }
        }
        public double OtherPaymentDiscount
        {
            get
            {
                return _OtherPaymentDiscount;
            }
        }
        public double OtherPaymentRemainingValue
        {
            get
            {
                return _OtherPaymentRemainingValue;
            }
        }
        public double OtherPaymentCheckValue
        {
            get
            {
                return _OtherPaymentCheckValue;
            }
        }
        #endregion
        public string AddStr
        {
            get
            {
                double dblInstallmentDate = _InstallmentDueDate.ToOADate() - 2;
                string Returned = " INSERT INTO CRMReservationInstallment (ReservationID, InstallmentType, InstallmentNo, InstallmentValue, InstallmentDueDate, InstallmentStatus,InstallmentGroup,InstallmentDesc,InstallmentNote,UsrIns,TimIns)" +
                                "  VALUES     (" + _ReservationID + "," + _InstallmentType + "," + _InstallmentNo + "," + _InstallmentValue + "," +
                                dblInstallmentDate + "," + _InstallmentStatus + "," + _InstallmentGroup + ",'" + _Desc + "','" + _Note + "'," + SysData.CurrentUser.ID + ",Getdate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDate = _InstallmentDueDate.ToOADate() - 2;
                string Returned = " UPDATE    CRMReservationInstallment" +
                                " SET InstallmentType =" + _InstallmentType + "" +
                                " , InstallmentNo =" + _InstallmentNo + "" +
                                " , InstallmentValue =" + _InstallmentValue + "" +
                                " , InstallmentGroup =" + _InstallmentGroup + "" +
                                " , InstallmentDueDate =" + dblDate + "" +
                                " ,InstallmentDesc = '" + _Desc + "'" +
                                 " ,InstallmentNote = '" + _Note + "'" +
                                " , InstallmentStatus = " + _InstallmentStatus + "" +
                                " ,UsrUpd = " + SysData.CurrentUser.ID + "" +
                                " ,TimUpd =Getdate() " +
                                " where ReservationID = "+ _ReservationID +" and  InstallmentID  = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "delete FROM CRMReservationInstallment where InstallmentID=" + _ID;
                //Returned += " delete from CRMInstallmentPayment where Installment ";
                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {

                string strReservationTable = " select * from CRMReservation ";
                string strExceptedCustomer = "";
                string strRuleInstallmentDate = "";
                string strCampaignMaxContactDate = "";
                if (_CampaignRuleID != 0)
                {
                    strExceptedCustomer = "SELECT     Customer "+
                         " FROM  dbo.CRMCampaignExceptedCustomer "+
                         " WHERE     (Campaign = " + _Campaign + ") AND (ExceptionEndDate IS NULL OR "+
                         " ExceptionEndDate > GETDATE())";
                    strRuleInstallmentDate = "SELECT  TOP (1) RuleDayDiff "+
                       " FROM         dbo.CRMCampaignRule "+
                       " WHERE     (RuleID = "+ _CampaignRuleID +") AND (RuleCampaign = "+ _Campaign +") ";
                    strCampaignMaxContactDate = "SELECT ContactDirectCustomer, MAX(ContactDate) AS MaxContactDate "+
                       " FROM   dbo.CRMCampaignCustomerContact "+
                       " WHERE     (ContactCampaign = "+ _Campaign +") "+
                       " GROUP BY ContactDirectCustomer ";
                    
                }

                string strUnitCell = "SELECT DISTINCT " +
                " TOP (100) PERCENT CASE WHEN COUNT(UnitFullName) = 1 THEN MAX(dbo.CRMUnit.UnitFullName) WHEN COUNT(UnitFullName)  " +
                " = 2 THEN MAX(UnitFullName) + '&' + MIN(UnitFullName) ELSE MAX(UnitFullName) + '&..&' + MIN(UnitFullName) END AS UnitFullName, " +
                " dbo.CRMReservationUnit.ReservationID AS CurrentReservation"+
                ", max(CASE WHEN RPCell_1.CellAlterName IS NULL OR " +
                " RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END) AS TowerName "+
                ", max( RPCell_1.CellOrder) AS TowerOrder  "+
                ",max(RPCell_1.CellID) as TowerID " +
                ", max(case when RPCell_2.CellAlterName is null or RPCell_2.CellAlterName ='' then RPCell_2.CellNameA else RPCell_2.CellAlterName end) AS ProjectName " +
                ",max(dbo.CRMUnitCell.CellID) as UnitCell"+
                ",sum(case when  dbo.CRMUnit.UnitDeliveryDate is null then 0 else 1 end) as UnitDeliveredCount " +
                ",sum(case when RPCell_1.CellDeliverDate is null then 0 else 1 end ) as TowerDeliveryCount " +
                " FROM  dbo.CRMUnit INNER JOIN " +
                " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
                " dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN " +
                " dbo.RPCell AS RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN " +
                " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID ";
             
                if (_CellFamilyID != 0)
                    strUnitCell += " and RPCell.CellFamilyID=" + _CellFamilyID;

                else if (_CellIDs != null && _CellIDs != "")
                    strUnitCell += " and RPCell.CellID in (" + _CellIDs + ")";
                else if(_CellFamilyIDs != null&& _CellFamilyIDs != "")
                    strUnitCell += " and RPCell.CellFamilyID in (" + _CellFamilyIDs + ")";
                if(_Campaign != 0 )
                    strUnitCell += " and ("+
                        "RPCell.CellFamilyID in (SELECT TOP (1) CampaignCellFamily FROM  dbo.CRMCampaign "+
                    " WHERE     (CampaignID = "+ _Campaign +")) "+
                        " or not exists( SELECT     TOP (1) CampaignCellFamily " +
                        " FROM   dbo.CRMCampaign " +
                        " WHERE     (CampaignID = " + _Campaign + ") and CampaignCellFamily <> 0) " +
                    ")" ;
                if (_Campaign != 0 && _CampaignRuleID != 0)
                    strUnitCell += " and (" +
                      "RPCell.CellFamilyID not in (SELECT   ProjectID  FROM  dbo.CRMCampaignExceptedProject) " +
                  ")";
                if (_ReservationStatus != 0)
                {
                    if (_ReservationStatus == 1)
                        strUnitCell += "and CRMReservationUnit.ReservationID = CRMUnit.CurrentReservation ";
                    else if (_ReservationStatus == 2)
                        strUnitCell += " and CRMReservationUnit.ReservationID <> CRMUnit.CurrentReservation ";
                }
                if (_UnitTypeID != 0)
                    strUnitCell += " and dbo.CRMUnit.UnitType = "+ _UnitTypeID ;
                strUnitCell += " GROUP BY dbo.CRMReservationUnit.ReservationID having(1=1) ";
                if (_UnitDeliveryStatus != 0)
                {
                    if (_UnitDeliveryStatus == 1)
                    {
                        strUnitCell += " and sum(case when  dbo.CRMUnit.UnitDeliveryDate is null then 0 else 1 end) > 0 ";
                    }
                    else
                        strUnitCell += " and sum(case when  dbo.CRMUnit.UnitDeliveryDate is null then 0 else 1 end) = 0  ";
                }
                if (_TowerDeliveryStatus != 0)
                {
                    if (_TowerDeliveryStatus == 1)
                    {
                        strUnitCell += " and sum(case when RPCell_1.CellDeliverDate is null and CRMUnit.UnitIsReadyForDelivery =0 then 0 else 1 end )> 0 ";
                    }
                    else
                        strUnitCell += " and sum(case when RPCell_1.CellDeliverDate is null and CRMUnit.UnitIsReadyForDelivery =0 then 0 else 1 end )= 0 ";
                }
                string strReservationCustomer = "SELECT dbo.CRMReservation.ReservationID,dbo.CRMReservation.ReservationDeliveryDate" +
                    ", dbo.CRMReservation.ReservationDate, dbo.CRMReservation.ReservationContractingDate, " +
                    " CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName) " +
                    " WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName) " +
                    " ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName,dbo.CRMReservation.ReservationParent " +
                    ", MAX(dbo.CRMCustomer.CustomerHomePhone) AS CustomerPhone, MAX(dbo.CRMCustomer.CustomerMobile) AS CustomerMobile ";
                if (_Campaign != 0 && _CampaignRuleID == 0)
                    strReservationCustomer += ",CampaignTable.CampaignCustomer,GetDate() as MaxContactDate ";
                else if (_Campaign != 0 && _CampaignRuleID != 0)
                    strReservationCustomer += ",0 as CampaignCustomer,CampaignTable.MaxContactDate "; 
                
                strReservationCustomer += " FROM   CRMReservation inner join  dbo.CRMReservationCustomer " +
                    " on CRMReservation.ReservationID = CRMReservationCustomer.ReservationID " +
                    " INNER JOIN  dbo.CRMCustomer " +
                    "ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID "+
                    " left outer join COMMONCountry  "+
                    " on   dbo.CRMCustomer.CustomerNationality = dbo.COMMONCountry.CountryID ";
                #region ReservationCheck
                if (_ReservationCheckStatus != 0 || (_ReservationCheckPlaces != null && _ReservationCheckPlaces != ""))
                {
                    string strReservationCeck = "SELECT DISTINCT dbo.CRMReservationInstallment.ReservationID "+
                         " FROM            dbo.GLCheck INNER JOIN "+
                         " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID INNER JOIN "+
                         " dbo.CRMReservationInstallment INNER JOIN "+
                         " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID ON  "+
                          " dbo.GLCheckPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID "+
                        " WHERE        (1 = 1) ";
                    if (_ReservationCheckPlaces != null && _ReservationCheckPlaces != "" && _ReservationCheckStatus != 2)
                        strReservationCeck += " and  (dbo.GLCheck.ChcekCurrentPlace IN ("+ _ReservationCheckPlaces +"))  ";
                    if (_ReservationCheckStatus == 2)
                        strReservationCustomer += " left outer join ";
                    else
                        strReservationCustomer += " inner join ";
                    strReservationCustomer += "  ("+ strReservationCeck +") as CheckTable "+
                        " on  CRMReservation.ReservationID = CheckTable.ReservationID";

                }
                #endregion
                #region Reservation Submission
                if (_ResubmissionType != 0)
                {
                    string strResubmission = "SELECT     distinct   ResubmissionReservation "+
                           " FROM     dbo.CRMReservationResubmission "+
                            " WHERE        (ResubmissionType = "+ _ResubmissionType +") AND (ResubmissionEndDate IS NULL OR "+
                            " ResubmissionEndDate >= dbo.GetApproximateDate(GETDATE()))";
                    if (_ResubmissionDateRange)
                    {
                        double dblStart = SysUtility.Approximate(_ResubmissionStartDate.ToOADate() - 2, 1, ApproximateType.Down);
                        double dblEnd = SysUtility.Approximate(_ResubmissionEndDate.ToOADate() - 2, 1, ApproximateType.Up);
                        strResubmission += " and ResubmissionDate >=" + dblStart + " and ResubmissionDate < " + dblEnd;
                    }
                    strReservationCustomer += " inner join   (" + strResubmission + ") as ResubmissionTable " +
                  " on  CRMReservation.ReservationID = ResubmissionTable.ResubmissionReservation ";

                }
                #endregion

                #region Campaign
                if (_Campaign != 0)
                {
                    ////////////////////////////////////////////////////////
                    string strCampaignInstallmentCount = "SELECT     dbo.CRMCampaign.CampaignID, COUNT(dbo.CRMCampaignInstallmentType.InstallmentType) AS CampaignInstallmentCount " +
                        " FROM   dbo.CRMCampaign LEFT OUTER JOIN " +
                        " dbo.CRMCampaignInstallmentType ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignInstallmentType.Campaign " +
                        " GROUP BY dbo.CRMCampaign.CampaignID ";
                    string strMonitor = "SELECT  MAX(MonitoringID) AS MaxMonitorID, MonitoringCampaignCustomer " +
                       " FROM    dbo.CRMCampaignCustomerMonitor " +
                       " GROUP BY MonitoringCampaignCustomer ";

                    strMonitor = "SELECT dbo.CRMCampaignCustomerMonitor.MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer, MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                          "MonitoringWaitingDate as LastMonitoringWaitingDate " +
                          "" +
                          " FROM  dbo.CRMCampaignCustomerMonitor " +
                          " inner join (" + strMonitor + ") as MaxMonitorTable " +
                          " on CRMCampaignCustomerMonitor.MonitoringCampaignCustomer = MaxMonitorTable.MonitoringCampaignCustomer  " +
                          " and  CRMCampaignCustomerMonitor.MonitoringID = MaxMonitorTable.MaxMonitorID ";

                    string strCustomerCampaign = "";
                    strCustomerCampaign = "SELECT dbo.CRMReservationCustomer.ReservationID, SUM(CASE WHEN CRMCampaignCustomerContact.ContactStatus = 1 THEN 1 ELSE 0 END) " +
                      " AS ContactCount"+
                      ",Max(CRMCampaignCustomer.CampaignCustomerID) as CampaignCustomer,dbo.CRMCampaign.CampaignCellFamily,  dbo.CRMCampaignCustomer.WaitingMonitoringDate,MonitorTable.LastMonitoringWaitingDate " +
                      ", GetDate() as MaxContactDate "+
                      " FROM  dbo.CRMCampaignCustomer INNER JOIN " +
                      " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID LEFT OUTER JOIN " +
                      " dbo.CRMCampaignCustomerContact ON  " +
                      " dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerContact.CampaignCustomerID " +
                      " inner join CRMCampaign "+
                      " on CRMCampaign.CampaignID = CRMCampaignCustomer.Campaign "+
                      " inner join (" + strCampaignInstallmentCount + ") as InstallmentTypeCountTable "+
                      " on  CRMCampaign.CampaignID = InstallmentTypeCountTable.CampaignID "+
                      " left outer join CRMCampaignInstallmentType " +
                      " on CRMCampaign.CampaignID =CRMCampaignInstallmentType.Campaign " +
                      " left outer join ("+ strMonitor +") as MonitorTable "+
                      " on  dbo.CRMCampaignCustomer.CampaignCustomerID = MonitorTable.LastMonitoringCampaignCustomer " +
                      " WHERE  (dbo.CRMCampaignCustomer.Campaign = " + _Campaign + ") " +
                      " GROUP BY dbo.CRMReservationCustomer.ReservationID "+
                      ",dbo.CRMCampaign.CampaignCellFamily, dbo.CRMCampaignCustomer.WaitingMonitoringDate,MonitorTable.LastMonitoringWaitingDate ";
                    if(_CampaignRuleID!= 0)
                    strCustomerCampaign = "SELECT dbo.CRMReservationCustomer.ReservationID, 0 AS ContactCount" +
                     ",0 as CampaignCustomer,dbo.CRMCampaign.CampaignCellFamily, GetDate() as WaitingMonitoringDate,GetDate() as LastMonitoringWaitingDate " +
                     ",max(MaxContactedCustomerTable.MaxContactDate) as MaxContactDate " +
                     " FROM   dbo.CRMReservationCustomer   " +
                     " inner join CRMCampaign " +
                     " on CRMCampaign.CampaignID = " + _Campaign +
                     " inner join (" + strCampaignInstallmentCount + ") as InstallmentTypeCountTable " +
                     " on  CRMCampaign.CampaignID = InstallmentTypeCountTable.CampaignID " +
                     " left outer join CRMCampaignInstallmentType " +
                     " on CRMCampaign.CampaignID =CRMCampaignInstallmentType.Campaign " +
                     " left outer join ("+ strExceptedCustomer +") as ExceptedCustomerTable on "+
                     " CRMReservationCustomer.CustomerID = ExceptedCustomerTable.Customer "+
                     " left outer join (" + strCampaignMaxContactDate  + ") as MaxContactedCustomerTable "+
                     " on CRMReservationCustomer.CustomerID = MaxContactedCustomerTable.ContactDirectCustomer  " +
                     " WHERE  (ExceptedCustomerTable.Customer is null) " +
                     " GROUP BY dbo.CRMReservationCustomer.ReservationID " +
                     ",dbo.CRMCampaign.CampaignCellFamily ";

                    strCustomerCampaign = "select distinct CampaignCustomerTable.ReservationID ,CampaignCustomerTable.ContactCount,"+
                        "CampaignCustomerTable.CampaignCustomer,CampaignCustomerTable.MaxContactDate "+
                   
                        " from (" + strCustomerCampaign + ") as CampaignCustomerTable  where (1=1) ";
                    if (_CampaignContactStatus == 1)
                    {
                        strCustomerCampaign += " and CampaignCustomerTable.ContactCount>0 ";
                    }
                    else if (_CampaignContactStatus == 2)
                    {
                        strCustomerCampaign += " and CampaignCustomerTable.ContactCount=0 ";
                    }

                    if (_CampaignMonitorStatus != 0)
                    {
                        if (_CampaignMonitorStatus == 1)
                            strCustomerCampaign += " and ("+
                                "(CampaignCustomerTable.WaitingMonitoringDate is not null and CampaignCustomerTable.WaitingMonitoringDate <=GetDate()) "+
                                " or  "+
                                "(CampaignCustomerTable.LastMonitoringWaitingDate is not null and CampaignCustomerTable.LastMonitoringWaitingDate <=GetDate())" +
                                ")";
                        else if (_CampaignMonitorStatus == 2)
                            strCustomerCampaign += " and (" +
                              "(CampaignCustomerTable.WaitingMonitoringDate is  null or CampaignCustomerTable.WaitingMonitoringDate > GetDate()) " +
                              " and  " +
                              "(CampaignCustomerTable.LastMonitoringWaitingDate is  null or CampaignCustomerTable.LastMonitoringWaitingDate > GetDate())" +
                              ")";
                    }
                    strReservationCustomer += " left outer join (" + strCustomerCampaign + ") as CampaignTable on " +
                        "  CRMReservationCustomer.ReservationID = CampaignTable.ReservationID where (1=1) ";
                    if (_CampaignStatus == 1)
                    {
                        strReservationCustomer += " and CampaignTable.ReservationID is null ";
                    }
                    else if (_CampaignStatus == 2)
                    {
                        strReservationCustomer += " and CampaignTable.ReservationID is not null ";
                    }

/////////////////////////////////////////////////////////////////////////
                }
                #endregion
                else
                    strReservationCustomer += " where (1=1) ";
                if (_ReservationCheckStatus == 2)
                    strReservationCustomer += " and CheckTable.ReservationID is null ";
                if (_ExmptedCampaignStr != null && _ExmptedCampaignStr != "")
                {
                    string strExmptedCustomerCampaign = "select ReservationID from CRMReservationCustomer " +
                      " where CustomerID in  (select Customer from CRMCampaignCustomer where Campaign in (" + _ExmptedCampaignStr + "))";
                    strReservationCustomer += " and ReservationTable.ReservationID not in (" + strExmptedCustomerCampaign + ")";
                }
                if (_IsForeignStatus == 1)
                    strReservationCustomer += " and dbo.COMMONCountry.CountryIsForeign = 1 ";
                else if (_IsForeignStatus == 2)
                    strReservationCustomer += " and (dbo.COMMONCountry.CountryIsForeign is null or dbo.COMMONCountry.CountryIsForeign =0 ) ";
                if(_ReservationNote != null &&  _ReservationNote.Trim()!= "")
                    strReservationCustomer += " and CRMReservation.ReservationNote like '%"+ _ReservationNote +"%' ";
                  strReservationCustomer +=  " GROUP BY dbo.CRMReservation.ReservationID, dbo.CRMReservation.ReservationDate, "+
                    " dbo.CRMReservation.ReservationContractingDate,dbo.CRMReservation.ReservationParent,dbo.CRMReservation.ReservationDeliveryDate ";
                  if (_Campaign != 0)
                      strReservationCustomer += ",CampaignTable.CampaignCustomer,CampaignTable.MaxContactDate ";
                  string strPayment = "SELECT dbo.CRMInstallmentPayment.InstallmentID"+
                      ", SUM(CASE WHEN    GLPayment.PaymentValue IS NULL OR " +
                      " (dbo.GLPayment.PaymentReverseID > 0) or (dbo.GLPayment.PaymentSourceID > 0) or "+
                      " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus not in (2,4)) " +
                      " THEN 0 ELSE GLPayment.PaymentValue END) AS InstallmentPaymentValue " +
                      ",Max(case when  dbo.GLCheck.CheckID is null  and(dbo.GLPayment.PaymentReverseID =0) and (dbo.GLPayment.PaymentSourceID = 0)then dbo.GLPayment.PaymentDate" +
                      " when (dbo.GLPayment.PaymentReverseID = 0) and (dbo.GLPayment.PaymentSourceID = 0)and dbo.GLCheck.CheckCurrentStatus = 2 then   dbo.GLCheck.CheckCurrentStatusDate " +
                      " when (dbo.GLPayment.PaymentReverseID = 0) and (dbo.GLPayment.PaymentSourceID = 0) and GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected =1 then dbo.GLCheckPayment.PaymentCollectingDate end)  as MaxPaymentDate " +
                       ", SUM(CASE WHEN  GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 "+
                       " AND dbo.GLCheck.CheckCurrentStatus not in (2,4)  " +
                       " and (dbo.GLPayment.PaymentReverseID = 0) and (dbo.GLPayment.PaymentSourceID = 0) " +
                      " THEN GLPayment.PaymentValue ELSE 0 END) AS InstallmentCheckValue " +
                      " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                      " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                      " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                      " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID " +
                      " GROUP BY dbo.CRMInstallmentPayment.InstallmentID ";
                  string strDiscount = "SELECT  dbo.CRMReservationInstallmentDiscount.InstallmentID,"+
                      " SUM(case when DiscountSourceID >0 or  DiscountReverseID >0 then 0 else dbo.CRMReservationInstallmentDiscount.DiscountValue end) AS TotalDiscount " +
                       " FROM  dbo.CRMReservationInstallmentDiscount  " +
                       " GROUP BY  dbo.CRMReservationInstallmentDiscount.InstallmentID ";
                  string strInstallmentType = InstallmentTypeDb.SearchStr;
                  if (_Campaign != 0)
                  {

                      string strCampaignInstallmentCount = "SELECT dbo.CRMCampaign.CampaignID,  " +
                          " dbo.CRMCampaign.CampaignInstallmentStartDueDate as StartDueDate" +
                          ", DATEADD(day, 1, dbo.CRMCampaign.CampaignInstallmentEndDueDate)  as EndDueDate " +
                           ", dbo.CRMCampaign.CampaignInstallmentStartPaymentDate as StartPaymentDate" +
                          ", DATEADD(day, 1, dbo.CRMCampaign.CampaignInstallmentEndPaymentDate)  as EndPaymentDate " +
                           ", COUNT(dbo.CRMCampaignInstallmentType.InstallmentType) AS CampaignInstallmentCount ";

                      if (_CampaignRuleID != 0)
                          strCampaignInstallmentCount += ",(" + strRuleInstallmentDate + ") as RuleDayDiff ";
                      else
                          strCampaignInstallmentCount += ",0 as RuleDayDiff ";
                          strCampaignInstallmentCount += " FROM   dbo.CRMCampaign LEFT OUTER JOIN " +
                                            " dbo.CRMCampaignInstallmentType ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignInstallmentType.Campaign " +
                                            "  where CRMCampaign.CampaignID = " + _Campaign +
                                            " GROUP BY dbo.CRMCampaign.CampaignID " +
                                            ", dbo.CRMCampaign.CampaignInstallmentStartDueDate" +
                                            ", DATEADD(day, 1, dbo.CRMCampaign.CampaignInstallmentEndDueDate)  "+
                                            ",DATEADD(day, 1, dbo.CRMCampaign.CampaignInstallmentEndPaymentDate)"+
                                            ",dbo.CRMCampaign.CampaignInstallmentStartPaymentDate  ";

                      strCampaignInstallmentCount = "SELECT Campaign, InstallmentType AS CampaignInstallmentType,CampaignTable.* " +
                               " FROM         dbo.CRMCampaignInstallmentType "+
                               " left outer join (" + strCampaignInstallmentCount + ") as CampaignTable "+
                               " on  dbo.CRMCampaignInstallmentType.Campaign = CampaignTable.CampaignID "+
                               " or CampaignTable.CampaignInstallmentCount=0 ";


                      strInstallmentType = "select distinct InstallmentTypeTable.*,"+
                          "CampaignTable.StartDueDate,CampaignTable.EndDueDate,CampaignTable.StartPaymentDate,CampaignTable.EndPaymentDate  "+
                          ",CampaignTable.RuleDayDiff "+
                          " from ("+ strInstallmentType +") as InstallmentTypeTable "+
                          " inner join (" + strCampaignInstallmentCount + ") as CampaignTable "+
                          " on CampaignTable.CampaignInstallmentCount=0 "+
                          " or InstallmentTypeTable.InstallmentTypeID = CampaignTable.CampaignInstallmentType  ";

                  }
                  //strInstallmentType = InstallmentTypeDb.SearchStr;
                  string strInstallment = "SELECT CRMReservationInstallment.InstallmentID, InstallmentType, InstallmentNo, InstallmentValue," +
                    " InstallmentDueDate,InstallmentGroup,InstallmentDesc,InstallmentNote" +
                    ",ReservationTable.*,InstallmentTypeTable.* ,UnitTable.* " +
                    ",case when DiscountTable.TotalDiscount is null then 0 else DiscountTable.TotalDiscount end as TotalDiscount" +
                    ",Case when PaymentTable.InstallmentPaymentValue is null then 0 else PaymentTable.InstallmentPaymentValue end as TotalPaid"+
                    ",PaymentTable.MaxPaymentDate ,PaymentTable.InstallmentCheckValue " +
                    ",InstallmentValue -  " +
                    " case when DiscountTable.TotalDiscount is null then 0 else DiscountTable.TotalDiscount end " +
                    " - Case when PaymentTable.InstallmentPaymentValue is null then 0 else PaymentTable.InstallmentPaymentValue end as InstallmentRemainingValue " +
                    ",case when  InstallmentValue -  " +
                    " case when DiscountTable.TotalDiscount is null then 0 else DiscountTable.TotalDiscount end " +
                    " - Case when PaymentTable.InstallmentPaymentValue is null then 0 else PaymentTable.InstallmentPaymentValue end <= 1 then 1 else 0 end as InstallmentStatus "+
                    " FROM   CRMReservationInstallment inner  join (" + strInstallmentType + ") as InstallmentTypeTable " +
                    " on CRMReservationInstallment.InstallmentType = InstallmentTypeTable.InstallmentTypeID ";
                  if (_Campaign != 0 && _CampaignRuleID == 0)
                      strInstallment += " and  dbo.CRMReservationInstallment.InstallmentDueDate >= InstallmentTypeTable.StartDueDate " +
                          " and  dbo.CRMReservationInstallment.InstallmentDueDate < InstallmentTypeTable.EndDueDate ";
                  else if (_Campaign != 0 && _CampaignRuleID != 0)
                  {
                      if (_CampaignRulePeriodType == 1)
                      {
                          strInstallment += " and  dbo.CRMReservationInstallment.InstallmentDueDate <= "+
                              " DATEADD(day,-1*InstallmentTypeTable.RuleDayDiff,GetDate())  ";
                      }
                      else if (_CampaignRulePeriodType == 0)
                          strInstallment += " and  dbo.CRMReservationInstallment.InstallmentDueDate >= "+
                              "DATEADD(day,-1*InstallmentTypeTable.RuleDayDiff,"+
                              "CASE WHEN CONVERT(datetime, CONVERT(int, GETDATE()))> GetDate() THEN dateadd(day, -1, CONVERT(datetime, CONVERT(int, GETDATE()))) "+
                              " ELSE CONVERT(datetime, CONVERT(int, GETDATE())) end "+
                              ")  "+
                              " and  dbo.CRMReservationInstallment.InstallmentDueDate < " +
                              "DATEADD(day,-1*InstallmentTypeTable.RuleDayDiff," +
                              "CASE WHEN CONVERT(datetime, CONVERT(int, GETDATE()))< GetDate() THEN dateadd(day, 1, CONVERT(datetime, CONVERT(int, GETDATE()))) " +
                              " ELSE CONVERT(datetime, CONVERT(int, GETDATE())) end " +
                              ")  ";



                    
                  }
                
                strInstallment +=  " inner join (" + strReservationCustomer + ") as ReservationTable " +
                  " on CRMReservationInstallment.ReservationID = ReservationTable.ReservationID   " +
                  " inner join (" + strUnitCell + ") as UnitTable "+
                  " on CRMReservationInstallment.ReservationID = UnitTable.CurrentReservation "+
                  " left outer join (" + strPayment + ") as PaymentTable "+
                  " on CRMReservationInstallment.InstallmentID = PaymentTable.InstallmentID "+
                  " left outer join (" + strDiscount + ") as DiscountTable  "+
                  " on CRMReservationInstallment.InstallmentID = DiscountTable.InstallmentID ";

               // string Returned = SearchStr + " where (1=1) ";
                string Returned = strInstallment + " where (1=1) ";
                if (_Campaign != 0 && _CampaignRuleID != 0)
                {
                    Returned += " and  (ReservationTable.MaxContactDate is  null  " +

                       " or( "+
                       " dbo.CRMReservationInstallment.InstallmentDueDate > DATEADD(day, -1*InstallmentTypeTable.RuleDayDiff  ,"+
                       "case when Convert(datetime,convert(int,ReservationTable.MaxContactDate)) > ReservationTable.MaxContactDate then Convert(datetime,convert(int,ReservationTable.MaxContactDate)) else dateadd(day,1, Convert(datetime,convert(int,ReservationTable.MaxContactDate))) end  " +
                       ")" +
                       ")"+
                       " ) ";
                }
                if (_ID != 0)
                    Returned += " And InstallmentID  = " + _ID + "";
                if (_ReservationID != 0)
                    Returned = Returned + " and ReservationTable.ReservationID =" + _ReservationID;
                if (_ReservationIDS != null && _ReservationIDS != "")
                    Returned = Returned + " and ReservationTable.ReservationID  in (" + _ReservationIDS + ")";
                if (_IsContractingDateRange)
                {
                    double dblStartContract, dblEndContract;
                    dblStartContract = SysUtility.
                        Approximate(_StartContractingDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndContract = SysUtility.
                        Approximate(_EndContractingDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and ReservationTable.ReservationContractingDate >= " + 
                        dblStartContract + " and ReservationTable.ReservationContractingDate<" + dblEndContract;


                }
                double dblStartDate = 0;
                double dblEndDate = 0;
                if (_DateRangeStatus != 0)
                {

                    dblStartDate = SysUtility.Approximate(_StartDueDate.ToOADate() - 2, 1, ApproximateType.Down) ;
                   dblEndDate = SysUtility.Approximate(_EndDueDate.ToOADate()-2,1,ApproximateType.Up);
                    if (_DateRangeStatus == 1)
                    {
                        Returned = Returned + " and InstallmentDueDate between " + dblStartDate +
                            "  and " + dblEndDate;
                    }
                    else if (_DateRangeStatus == 2)
                        Returned = Returned + " and InstallmentDueDate < " + dblEndDate;

                }
                
                if (_TypeIDs != null && _TypeIDs != "")
                {
                    Returned += " and InstallmentType in(" + _TypeIDs + ")";
                }
                
                if (_StatusSearch != 0)
                {
                    strPayment = "SELECT     dbo.CRMInstallmentPayment.InstallmentID, dbo.GLCheck.CheckCurrentStatus,GLCheckPayment.PaymentIsCollected " +
                     " FROM     dbo.CRMInstallmentPayment INNER JOIN "+
                      " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID left outer JOIN "+
                      " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID left outer JOIN "+
                      " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID";
                  
                    //strPayment += " where CheckCurrentStatus <> 0 or CheckCurrentStatus <> 1 or CheckCurrentStatus <> 3 or CheckCurrentStatus <> 4 ";     
                    
                    if (_StatusSearch == 1) //Not Paid
                    {

                        Returned += " and CRMReservationInstallment.InstallmentValue -5 > "+
                            "(case when PaymentTable.InstallmentPaymentValue is null then 0 else PaymentTable.InstallmentPaymentValue end ) "+
                            "+(case when DiscountTable.TotalDiscount is null then 0 else DiscountTable.TotalDiscount end) ";

                    }
                    else if (_StatusSearch == 2)
                    {
                        strPayment += " where ( dbo.GLCheck.CheckID is null or CheckCurrentStatus = 2 or CheckCurrentStatus = 4 or PaymentIsCollected=1) ";     
                      
                        strPayment = "select InstallmentID from (" + strPayment + ") InstallmentPaymentTable ";

                        Returned += " and CRMReservationInstallment.InstallmentValue- 5 <= " +
                             "(case when PaymentTable.InstallmentPaymentValue is null then 0 else PaymentTable.InstallmentPaymentValue end ) " +
                             "+(case when DiscountTable.TotalDiscount is null then 0 else DiscountTable.TotalDiscount end) ";
                        if (_PaymentDateStatus != 0)
                        {

                            double dblStartPayment =
                                SysUtility.Approximate(_PaymentDateStart.ToOADate() - 2, 1, ApproximateType.Down);
                            double dblEndPayment =
                                SysUtility.Approximate(_PaymentDateEnd.ToOADate() - 2, 1, ApproximateType.Up);
                            Returned += " and PaymentTable.MaxPaymentDate >= " +
                                dblStartPayment + " and PaymentTable.MaxPaymentDate < " + dblEndPayment;

                        }
                        if(_Campaign != 0)
                          Returned += " and PaymentTable.MaxPaymentDate >= InstallmentTypeTable.StartPaymentDate" +
                             " and InstallmentTypeTable.EndPaymentDate < InstallmentTypeTable.EndPaymentDate";

                    }
                }

                if (_AfterDeliveryStatus != 0)
                {
                    if (_AfterDeliveryStatus == 1)
                        Returned += " and dbo.CRMReservationInstallment.InstallmentDueDate  > ReservationTable.ReservationDeliveryDate and InstallmentMainType <>3 ";
                    if (_AfterDeliveryStatus == 2)
                        Returned += " and dbo.CRMReservationInstallment.InstallmentDueDate < ReservationTable.ReservationDeliveryDate and InstallmentMainType <>3 ";

                }

                if (_ReservationParentStatus != 0)
                {
                    if (_ReservationParentStatus == 1)
                        Returned += " and ReservationParent = 0 ";
                    else
                        Returned += " and ReservationParent <> 0 "; 
                }
                return Returned;
            }
 
        }
     
         public string InstallmentRemainingValueStr
        {
            get
            {
                string Returned = "";
                string strInstallment = "SELECT distinct  dbo.CRMReservationInstallment.InstallmentID, dbo.CRMReservationInstallment.InstallmentValue, "+
                      " dbo.CRMReservationInstallment.InstallmentDueDate,dbo.CRMReservationInstallment.ReservationID  "+
                      " FROM         dbo.CRMReservationInstallment "+
                      " INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMReservationInstallment.ReservationID = dbo.CRMUnit.CurrentReservation " + 
                       " where  (1=1) ";
                //if (_CustomerIDs != null && _CustomerIDs != "")
                //   strInstallment += " and dbo.CRMReservationCustomer.CustomerID in (" + _CustomerIDs + ") ";


               string strPayment = "SELECT dbo.CRMInstallmentPayment.InstallmentID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL OR " +
                     " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus not in(2,4)) " +
                     " THEN 0 ELSE GLPayment.PaymentValue END) AS InstallmentPaymentValue " +
                     ",Max(case when  dbo.GLCheck.CheckID is null then dbo.GLPayment.PaymentDate" +
                     " when  dbo.GLCheck.CheckCurrentStatus = 2 then   dbo.GLCheck.CheckCurrentStatusDate " +
                     " else dbo.GLCheckPayment.PaymentCollectingDate end)  as MaxPaymentDate " +
                     " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                     " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                     " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                     " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                     " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                     " where   (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                     " GROUP BY dbo.CRMInstallmentPayment.InstallmentID ";
               string strDiscount = "SELECT dbo.CRMReservationInstallmentDiscount.InstallmentID, SUM(dbo.CRMReservationInstallmentDiscount.DiscountValue) AS TotalDiscount " +
                     " FROM  dbo.CRMReservationInstallmentDiscount " +
                     " GROUP BY dbo.CRMReservationInstallmentDiscount.InstallmentID ";

                Returned = "select InstallmentTable.InstallmentID,sum(InstallmentTable.InstallmentValue "+
                    "- (case when PaymentTable.InstallmentID is null then  0 else InstallmentPaymentValue end )" +
                    "-(case when DiscountTable.InstallmentID is null then 0 else TotalDiscount end)"+
                    ") as TotalRemainingValue,InstallmentTable.ReservationID  "+
                    " from ("+ strInstallment  +") as InstallmentTable  "+
                    " left outer join ("+ strDiscount  +") as DiscountTable  "+
                    " on InstallmentTable.InstallmentID = DiscountTable.InstallmentID "+
                    " left outer join ("+ strPayment +")  as PaymentTable "+
                    " on  InstallmentTable.InstallmentID = PaymentTable.InstallmentID "+
                    " group by InstallmentTable.InstallmentID ,InstallmentTable.ReservationID  ";
                return Returned;
            }
        }

        public string CustomerRemainingValueStr
        {
            get
            {
                string Returned = "";
                string strInstallment = "SELECT distinct dbo.CRMReservationCustomer.CustomerID, dbo.CRMReservationInstallment.InstallmentID, dbo.CRMReservationInstallment.InstallmentValue, "+
                      " dbo.CRMReservationInstallment.InstallmentDueDate "+
                      " FROM         dbo.CRMReservationCustomer INNER JOIN "+
                      " dbo.CRMReservationInstallment ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservationInstallment.ReservationID INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation" + 
                       " where  dbo.CRMReservationInstallment.InstallmentDueDate < GetDate() ";
                if (_CustomerIDs != null && _CustomerIDs != "")
                   strInstallment += " and dbo.CRMReservationCustomer.CustomerID in (" + _CustomerIDs + ") ";


               string strPayment = "SELECT dbo.CRMInstallmentPayment.InstallmentID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL OR " +
                     " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus not in(2,4)) " +
                     " THEN 0 ELSE GLPayment.PaymentValue END) AS InstallmentPaymentValue " +
                     ",Max(case when  dbo.GLCheck.CheckID is null then dbo.GLPayment.PaymentDate" +
                     " when  dbo.GLCheck.CheckCurrentStatus = 2 then   dbo.GLCheck.CheckCurrentStatusDate " +
                     " else dbo.GLCheckPayment.PaymentCollectingDate end)  as MaxPaymentDate " +
                     " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                     " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                     " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                     " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                     " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                     " where   (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                     " GROUP BY dbo.CRMInstallmentPayment.InstallmentID ";
               string strDiscount = "SELECT dbo.CRMReservationInstallmentDiscount.InstallmentID, SUM(dbo.CRMReservationInstallmentDiscount.DiscountValue) AS TotalDiscount " +
                     " FROM  dbo.CRMReservationInstallmentDiscount " +
                     " GROUP BY dbo.CRMReservationInstallmentDiscount.InstallmentID ";

                Returned = "select InstallmentTable.CustomerID,sum(InstallmentTable.InstallmentValue "+
                    "- (case when PaymentTable.InstallmentID is null then  0 else InstallmentPaymentValue end )" +
                    "-(case when DiscountTable.InstallmentID is null then 0 else TotalDiscount end)"+
                    ") as TotalRemainingValue  "+
                    " from ("+ strInstallment  +") as InstallmentTable  "+
                    " left outer join ("+ strDiscount  +") as DiscountTable  "+
                    " on InstallmentTable.InstallmentID = DiscountTable.InstallmentID "+
                    " left outer join ("+ strPayment +")  as PaymentTable "+
                    " on  InstallmentTable.InstallmentID = PaymentTable.InstallmentID "+
                    " group by InstallmentTable.CustomerID  ";
                return Returned;
            }
        }
        
        public string InstallmentPaymentStr
        {
            get
            {
                string Returned = "";

                string strInstallment = " SELECT  dbo.CRMReservationInstallment.InstallmentID,dbo.CRMReservationInstallment.InstallmentValue " +
                       " FROM   dbo.CRMReservationInstallment ";


                string strPayment = "SELECT dbo.CRMInstallmentPayment.InstallmentID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL OR " +
                      " (GLCheckPayment.CheckID IS NOT NULL AND dbo.GLCheckPayment.PaymentIsCollected = 0 AND dbo.GLCheck.CheckCurrentStatus not in(2,4)) " +
                      " THEN 0 ELSE GLPayment.PaymentValue END) AS InstallmentPaymentValue " +
                      ",Max(case when  dbo.GLCheck.CheckID is null then dbo.GLPayment.PaymentDate" +
                      " when  dbo.GLCheck.CheckCurrentStatus = 2 then   dbo.GLCheck.CheckCurrentStatusDate " +
                      " else dbo.GLCheckPayment.PaymentCollectingDate end)  as MaxPaymentDate,Max(GLPayment.PaymentID) as MaxPaymentID " +
                      " FROM dbo.GLCheck RIGHT OUTER JOIN " +
                      " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                      " dbo.GLPayment ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID RIGHT OUTER JOIN " +
                      " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID RIGHT OUTER JOIN " +
                      " dbo.CRMReservationInstallment ON dbo.CRMInstallmentPayment.InstallmentID = dbo.CRMReservationInstallment.InstallmentID " +
                      " where   (dbo.GLPayment.PaymentSourceID = 0) AND (dbo.GLPayment.PaymentReverseID = 0) AND (dbo.GLPayment.PaymentCollectingID = 0) " +
                      " GROUP BY dbo.CRMInstallmentPayment.InstallmentID ";
                string strDiscount = "SELECT dbo.CRMReservationInstallmentDiscount.InstallmentID"+
                    ", SUM(case when  DiscountSourceID =0 and DiscountReverseID=0 then dbo.CRMReservationInstallmentDiscount.DiscountValue else 0 end) AS TotalDiscount " +
                     ", SUM(case when  DiscountSourceID =0 and DiscountReverseID=0 and DiscountReceipt=0 then  dbo.CRMReservationInstallmentDiscount.DiscountValue else 0 end) AS TotalNonReceiptedDiscount " +
                      " FROM  dbo.CRMReservationInstallmentDiscount " +
                      " GROUP BY dbo.CRMReservationInstallmentDiscount.InstallmentID ";

                Returned = "select InstallmentTable.InstallmentID,sum(InstallmentTable.InstallmentValue " +
                    "- (case when PaymentTable.InstallmentID is null then  0 else InstallmentPaymentValue end )" +
                    "-(case when DiscountTable.InstallmentID is null then 0 else TotalDiscount end)" +
                    ") as TotalRemainingValue "+
                    ",case when PaymentTable.MaxPaymentID is null then 0 else  PaymentTable.MaxPaymentID end as LastPaymentID  " +
                    ",  case when DiscountTable.InstallmentID is null then 0 else TotalDiscount end as TotalDiscount "+
                     ",  case when DiscountTable.InstallmentID is null then 0 else TotalNonReceiptedDiscount end as TotalNonReceiptedDiscount " +
                    " from (" + strInstallment + ") as InstallmentTable  " +
                    " left outer join (" + strDiscount + ") as DiscountTable  " +
                    " on InstallmentTable.InstallmentID = DiscountTable.InstallmentID " +
                    " left outer join (" + strPayment + ")  as PaymentTable " +
                    " on  InstallmentTable.InstallmentID = PaymentTable.InstallmentID " +
                    " group by InstallmentTable.InstallmentID,PaymentTable.MaxPaymentID,DiscountTable.InstallmentID,DiscountTable.TotalDiscount,DiscountTable.TotalNonReceiptedDiscount  ";
                return Returned;
            }
        }

        public string InstallmentCustomerStr
        {
            get
            {
                CustomerDb objCustomerDb = new CustomerDb();
                string Returned = "select distinct CustomerTable.* "+
                    " from (" + objCustomerDb.SearchStr + ") as CustomerTable " +
                    " inner join dbo.CRMReservationCustomer  " +
                    " on CustomerTable.CustomerID = dbo.CRMReservationCustomer.CustomerID " +
                    " inner join (" + StrSearch + ") as InstallmentTable  "+
                    " on dbo.CRMReservationCustomer.ReservationID = InstallmentTable.ReservationID ";
               // Returned = StrSearch;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {


           
                string strReservationTable = " select * from CRMReservation ";


                string Returned = "SELECT InstallmentID, InstallmentType, InstallmentNo, InstallmentValue," +
                    " InstallmentDueDate, InstallmentStatus,InstallmentGroup,InstallmentDesc,InstallmentNote,ReservationTable.*,InstallmentTypeTable.* " +
                    " FROM   CRMReservationInstallment inner join (" + InstallmentTypeDb.SearchStr + ") as InstallmentTypeTable " +
                    " on CRMReservationInstallment.InstallmentType = InstallmentTypeTable.InstallmentTypeID " +
                    " inner join (" + strReservationTable + ") as ReservationTable on CRMReservationInstallment.ReservationID=ReservationTable.ReservationID ";
                return Returned;

            }
        }
      
        public string SumStrSearch 
        {
            get
            {
                string Returned = "";
                string strSelect = "sum(InstallmentValue) as TotalValue "+
                    ",sum(case when TotalDiscount is null then 0 else TotalDiscount end) as TotalDiscount"+
                    ",sum(case when TotalPaid is null then 0 else TotalPaid end) as TotalPaidValue "+
                    ",sum(InstallmentRemainingValue) as TotalRemaining "+
                    ",sum(InstallmentCheckValue) as TotalCheckValue ";


                strSelect += ",sum(case when InstallmentMainType = 0 then InstallmentValue else 0 end ) as OtherTotalValue " +
                   ",sum(case when InstallmentMainType = 0 then case when TotalDiscount is null then 0 else TotalDiscount end else 0 end ) as OtherTotalDiscount" +
                   ",sum(case when InstallmentMainType = 0 then  case when TotalPaid is null then 0 else TotalPaid end else 0 end ) as OtherTotalPaidValue " +
                   ",sum(case when InstallmentMainType = 0 then InstallmentRemainingValue else 0 end) as OtherTotalRemaining " +
                   ",sum(case when InstallmentMainType = 0 then  InstallmentCheckValue else 0 end) as OtherTotalCheckValue ";

                strSelect += ",sum(case when InstallmentMainType = 1 then InstallmentValue else 0 end ) as InstallmentTotalValue " +
                  ",sum(case when InstallmentMainType = 1 then case when TotalDiscount is null then 0 else TotalDiscount end else 0 end ) as InstallmentTotalDiscount" +
                  ",sum(case when InstallmentMainType = 1 then  case when TotalPaid is null then 0 else TotalPaid end else 0 end ) as InstallmentTotalPaidValue " +
                  ",sum(case when InstallmentMainType = 1 then InstallmentRemainingValue else 0 end) as InstallmentTotalRemaining " +
                  ",sum(case when InstallmentMainType = 1 then  InstallmentCheckValue else 0 end) as InstallmentTotalCheckValue ";


                strSelect += ",sum(case when InstallmentMainType = 2 then InstallmentValue else 0 end ) as PeriodicPaymentTotalValue " +
                 ",sum(case when InstallmentMainType = 2 then case when TotalDiscount is null then 0 else TotalDiscount end else 0 end ) as PeriodicPaymentTotalDiscount" +
                 ",sum(case when InstallmentMainType = 2 then  case when TotalPaid is null then 0 else TotalPaid end else 0 end ) as PeriodicPaymentTotalPaidValue " +
                 ",sum(case when InstallmentMainType = 2 then InstallmentRemainingValue else 0 end) as PeriodicPaymentTotalRemaining " +
                 ",sum(case when InstallmentMainType = 2 then  InstallmentCheckValue else 0 end) as PeriodicPaymentTotalCheckValue ";


                strSelect += ",sum(case when InstallmentMainType = 3 then InstallmentValue else 0 end ) as   DeliveryPaymentTotalValue " +
                ",sum(case when InstallmentMainType = 3 then case when TotalDiscount is null then 0 else TotalDiscount end else 0 end ) as  DeliveryPaymentTotalDiscount" +
                ",sum(case when InstallmentMainType = 3 then  case when TotalPaid is null then 0 else TotalPaid end else 0 end ) as  DeliveryPaymentTotalPaidValue " +
                ",sum(case when InstallmentMainType = 3 then InstallmentRemainingValue else 0 end) as  DeliveryPaymentTotalRemaining " +
                ",sum(case when InstallmentMainType = 3 then  InstallmentCheckValue else 0 end) as  DeliveryPaymentTotalCheckValue ";

                string strGroup = "";
                string strOrder = "";
               


                if (_IsDayGroup)
                {
                    strSelect += ",year(InstallmentDueDate) as Y,Month(InstallmentDueDate) as M,Day(InstallmentDueDate) as D ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(InstallmentDueDate),Month(InstallmentDueDate),Day(InstallmentDueDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(InstallmentDueDate),Month(InstallmentDueDate),Day(InstallmentDueDate) ";
                }
                else if (_IsMonthGroup)
                {
                    strSelect += ",year(InstallmentDueDate) as Y,Month(InstallmentDueDate) as M ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(InstallmentDueDate),Month(InstallmentDueDate)";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(InstallmentDueDate),Month(InstallmentDueDate)";
                }
                else if (_IsYearGroup)
                {
                    strSelect += ",year(InstallmentDueDate) as Y ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "year(InstallmentDueDate) ";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "year(InstallmentDueDate) ";
                }

                if (_IsTowerGroup)
                {
                    strSelect += ",TowerID,TowerName,ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "TowerID,TowerName,ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName,TowerName,TowerID";


                }
                else if (_IsProjectGroup)
                {
                    strSelect += ",ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ProjectName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ProjectName";
                }

                if (_IsMainTypeGroup)
                {
                    strSelect += ",InstallmentMainType";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentMainType";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "InstallmentMainType";


                }
                if (_IsInstallmentTypeGroup)
                {
                    //InstallmentTypeNameA
                    strSelect += ",InstallmentTypeNameA";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentTypeNameA";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "InstallmentTypeNameA";
                }

                if (_IsCustomerGroup)
                {
                    strSelect += ",CustomerFullName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CustomerFullName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CustomerFullName";
                }
                if (_IsUnitGroup)
                {
                    strSelect += ",UnitFullName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "UnitFullName";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "UnitFullName";
                }

                Returned = "select " + strSelect + " from (" + StrSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;


                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["InstallmentID"] == null)
            {
                SetSumData(objDR);
                return;
            }
            _ID = int.Parse(objDR["InstallmentID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _InstallmentType = int.Parse(objDR["InstallmentType"].ToString());
            _InstallmentNo = int.Parse(objDR["InstallmentNo"].ToString());
            _InstallmentStatus = int.Parse(objDR["InstallmentStatus"].ToString());
            _InstallmentGroup = int.Parse(objDR["InstallmentGroup"].ToString());
            _InstallmentDueDate = DateTime.Parse(objDR["InstallmentDueDate"].ToString());
            _InstallmentValue = double.Parse(objDR["InstallmentValue"].ToString());
            _Desc = objDR["InstallmentDesc"].ToString();
            try
            {
                if(objDR.Table.Columns["InstallmentNote"] != null)
                  _Note = objDR["InstallmentNote"].ToString();
            }
            catch
            { }
            if (objDR.Table.Columns["ReservationDate"] != null)
            _ReservationDate = DateTime.Parse(objDR["ReservationDate"].ToString());
            _IsContracted = false;
            if(objDR.Table.Columns["UnitCell"]!= null)
            _CellID = int.Parse(objDR["UnitCell"].ToString());
            if (objDR.Table.Columns["ReservationContractingDate"] != null && objDR["ReservationContractingDate"].ToString() != "")
            {
                _IsContracted = true;
                _ContractingDate = DateTime.Parse(objDR["ReservationContractingDate"].ToString());
            }
            if(objDR.Table.Columns["TotalDiscount"]!= null)
            _TotalDiscountValue = double.Parse(objDR["TotalDiscount"].ToString());
            if(objDR.Table.Columns["TotalPaid"]!= null)
            _TotalPaidValue = double.Parse(objDR["TotalPaid"].ToString());
            if(objDR.Table.Columns["CampaignCustomer"]!= null&& objDR["CampaignCustomer"].ToString()!= "")
                _CampaignCustomerID = int.Parse(objDR["CampaignCustomer"].ToString());
            if(objDR.Table.Columns["MaxPaymentDate"]!= null && objDR["MaxPaymentDate"].ToString()!= "")
            _PaymentDate = DateTime.Parse(objDR["MaxPaymentDate"].ToString());
            try
            {
                _CustomerStr = objDR["CustomerFullName"].ToString();
                _UnitStr = objDR["UnitFullName"].ToString();

                _TowerName = objDR["TowerName"].ToString();
                _TowerID = int.Parse(objDR["TowerID"].ToString());
                _ProjectName = objDR["ProjectName"].ToString();
                _CustomerPhone = objDR["CustomerPhone"].ToString();
                _CustomerMobile = objDR["CustomerMobile"].ToString();
            }
            catch { }
 
        }
        void SetSumData(DataRow objDR)
        {
            if (objDR["TotalValue"].ToString() == "")
                return;
            _TotalValue = double.Parse(objDR["TotalValue"].ToString());
            _TotalDiscountValue = double.Parse(objDR["TotalDiscount"].ToString());
            _TotalPaidValue = double.Parse(objDR["TotalPaidValue"].ToString());
            _TotalRemainingValue = double.Parse(objDR["TotalRemaining"].ToString());
            if(objDR["TotalCheckValue"].ToString()!= "")
            _TotalCheckValue = double.Parse(objDR["TotalCheckValue"].ToString());

            _OtherPaymentValue = double.Parse(objDR["OtherTotalValue"].ToString());
            _OtherPaymentDiscount = double.Parse(objDR["OtherTotalDiscount"].ToString());
            _OtherPaymentPaidValue = double.Parse(objDR["OtherTotalPaidValue"].ToString());
            _OtherPaymentRemainingValue = double.Parse(objDR["OtherTotalRemaining"].ToString());
            if(objDR["OtherTotalCheckValue"].ToString()!= "")
            _OtherPaymentCheckValue = double.Parse(objDR["OtherTotalCheckValue"].ToString());

            _InstallmentValue = double.Parse(objDR["InstallmentTotalValue"].ToString());
            _InstallmentDiscount = double.Parse(objDR["InstallmentTotalDiscount"].ToString());
            _InstallmentPaidValue = double.Parse(objDR["InstallmentTotalPaidValue"].ToString());
            _InstallmentRemainingValue = double.Parse(objDR["InstallmentTotalRemaining"].ToString());
            if(objDR["InstallmentTotalCheckValue"].ToString()!= "")
            _InstallmentCheckValue = double.Parse(objDR["InstallmentTotalCheckValue"].ToString());


            _PeriodicPaymentValue = double.Parse(objDR["PeriodicPaymentTotalValue"].ToString());
            _PeriodicPaymentDiscount = double.Parse(objDR["PeriodicPaymentTotalDiscount"].ToString());
            _PeriodicPaymentPaidValue = double.Parse(objDR["PeriodicPaymentTotalPaidValue"].ToString());
            _PeriodicPaymentRemainingValue = double.Parse(objDR["PeriodicPaymentTotalRemaining"].ToString());
            if(objDR["PeriodicPaymentTotalCheckValue"].ToString()!= "")
            _PeriodicPaymentCheckValue = double.Parse(objDR["PeriodicPaymentTotalCheckValue"].ToString());

            _DeliveryPaymentValue = double.Parse(objDR["DeliveryPaymentTotalValue"].ToString());
            _DeliveryPaymentDiscount = double.Parse(objDR["DeliveryPaymentTotalDiscount"].ToString());
            _DeliveryPaymentPaidValue = double.Parse(objDR["DeliveryPaymentTotalPaidValue"].ToString());
            _DeliveryPaymentRemainingValue = double.Parse(objDR["DeliveryPaymentTotalRemaining"].ToString());
            if(objDR["DeliveryPaymentTotalCheckValue"].ToString()!= "")
            _DeliveryPaymentCheckValue = double.Parse(objDR["DeliveryPaymentTotalCheckValue"].ToString());

            if (objDR.Table.Columns["Y"] != null && objDR["Y"].ToString() != "")
                _Y = int.Parse(objDR["Y"].ToString());

            if (objDR.Table.Columns["M"] != null && objDR["M"].ToString() != "")
                _M = int.Parse(objDR["M"].ToString());
            if (objDR.Table.Columns["D"] != null && objDR["D"].ToString() != "")
                _D = int.Parse(objDR["D"].ToString());
            if (objDR.Table.Columns["TowerName"] != null)
                _TowerName = objDR["TowerName"].ToString();
            if(objDR.Table.Columns["TowerID"]!= null)
                _TowerID = int.Parse(objDR["TowerID"].ToString());
            if (objDR.Table.Columns["ProjectName"] != null)
                _ProjectName = objDR["ProjectName"].ToString();
            if (objDR.Table.Columns["InstallmentTypeNameA"] != null)
            { }
            if (objDR.Table.Columns["CustomerFullName"] != null)
                _CustomerStr = objDR["CustomerFullName"].ToString();
            if (objDR.Table.Columns["UnitFullName"] != null)
                _UnitStr = objDR["UnitFullName"].ToString();
            if (objDR.Table.Columns["InstallmentTypeNameA"] != null)
                _InstallmentTypeNameA = objDR["InstallmentTypeNameA"].ToString();
            if (objDR.Table.Columns["InstallmentMainType"] != null &&
                objDR["InstallmentMainType"].ToString() != "")
                _InstallmentMainType = int.Parse(objDR["InstallmentMainType"].ToString());



            
        }

        #endregion
        #region Public Methods

        public void Add()
        {
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditNote()
        {
            string strSql = " UPDATE    CRMReservationInstallment" +
                               " SET  InstallmentNote = '" + _Note + "'" +
                               " ,UsrUpd = " + SysData.CurrentUser.ID + "" +
                               " ,TimUpd =Getdate() " +
                               " where   InstallmentID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStatus()
        {
            string strSql = " UPDATE    CRMReservationInstallment" +
                            " SET  InstallmentStatus = " + _InstallmentStatus + "" +
                            " ,UsrUpd = " + SysData.CurrentUser.ID + " " +
                            " ,TimUpd =Getdate() " +
                            " where  InstallmentID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
         
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public  DataTable Search()
        {

            string strSql = "select * from (" +  StrSearch + ")  as NativeTable " ;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Installment");
        }
        public DataTable SumSearch()
        {

            string strSql = SumStrSearch ;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Installment");
        }
        public DataTable GetInstallmentCustomer()
        {
            string strSql = InstallmentCustomerStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public DataTable GetRemainingInstallmentTable()
        { 
        DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(CustomerRemainingValueStr);
        return Returned;


        }
        public void JoinDiscount()
        {
            string strSql;
            strSql = "DELETE FROM CRMReservationInstallmentDiscount where InstallmentID = " + _ID;
            SqlConnection objConn = SysData.SharpVisionBaseDb.Connection;
            SqlTransaction objTrans = objConn.BeginTransaction();
            try
            {

                using (objConn)
                {

                    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql, objConn, objTrans);
                    bool blIsPermanent;
                    foreach (DataRow objDR in _Installment.Rows)
                    {

                        strSql = " INSERT INTO CRMReservationInstallmentDiscount"+
                                 " (DiscountID, InstallmentID, DiscountValue, DiscountReason, DiscountDate)"+
                                " VALUES     (" + _ID + "," + objDR["InstallmentID"].ToString() + "," + objDR["Value"].ToString() + "," + objDR["Reason"].ToString() + "," + objDR["Date"].ToString() + ") ";
                        SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql, objConn, objTrans);

                    }
                    objTrans.Commit();
                    objConn.Close();
                }

            }
            catch
            {
                objTrans.Rollback();

            }


        }

        #endregion
    }
}
