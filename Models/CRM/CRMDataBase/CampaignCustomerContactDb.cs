using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignCustomerContactDb
    {
        #region Private Data
        int _ID;
        int _CampaignCustomerID;
        bool _Direction;
        DateTime _Date;
        int _Type;
        string _Comment;
        int _Status;
        int _FunctionalStatus;
        bool _WaitingAnotherContact;
        DateTime _WaitingDate;
        int _RuleID;
        string _RuleDesc;

        int _Employee;
        int _Branch;
        int _CampaignID;
        DateTime _CampaignDate;
        string _CampaignDesc;
        int _CampaignTopicID;
        string _CampaignTopicName;
        int _CustomerID;
        string _CustomerName;
        int _DirectCustomerID;
        string _DirectCustomerName;
        string _DirectCustomerUnitName;
        string _DirectCustomerTowerName;
        string _DirectCustomerProjectName;
        string _DirectCustomerMobile;
        string _DirectCustomerPhone;
        string _DirectCustomerAddress;
        int _TopicID;
        string _TopicName;
        int _DirectCampaignID;
        string _DirectCampaignDesc;
        DateTime _DirectCmpaignDate;
        int _DirectCampaignTopicID;
        string _DirectCampaignTopicName;
        int _SMSMsgID;
        string _SMSMsg;
        int _MaxID;
        int _MinID;
        int _ResultCount;
        //int _TopicID;


        #region Data ForReciption
        int _ReceptionStatus;
        int _ReceptionProcessedStatus;
        bool _IsReception;
        int _ReceptionistID;
        string _ReceptionistName;
        DateTime _ReceptionDate;
        bool _ReceptionProcessed;
        #endregion

        #region DataForSum
        int _TotalCount;
        int _NotSpecifiedCount;
        int _DoneStatusCount;
        int _WrongNoStatusCount;
        int _NoAnswerStatusCount;
        int _NoNoStatusCount;
        int _NotSpecifiedFunctionalStatusCount;
        int _DoneFunctionalStatusCount;
        int _RefusedFunctionalStatusCount;
        int _EscalatedFunctionalStatusCount;

        #endregion
        #region Private Data For Search
        string _TopicIDs;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        int _LastContactStatus;
        int _DirectionStatus;/*
                              * 0 dont care
                              * 1 only in 
                              * 2 only out
                              */
        bool _IsEmployeeGroup;
        bool _IsCampaignGroup;
        bool _IsCustomerGroup;
        bool _IsTypeGroup;
        bool _IsDirectionGroup;
        bool _IsWorGroupGroup;
        bool _IsBranchGroup;
        bool _IsVisitTypeGroup;

        bool _IsTowerGroup;
        bool _IsProjectGroup;
        bool _IsDayGroup;
        bool _IsMonthGroup;
        bool _IsYearGroup;
        bool _IsMsgGroup;

        #endregion

        #endregion
        #region Constructors
        public CampaignCustomerContactDb()
        {
        }
        public CampaignCustomerContactDb(DataRow objDr)
        {
            SetData(objDr);
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
        public int CampaignCustomerID
        {
            set
            {
                _CampaignCustomerID = value;
            }
            get
            {
                return _CampaignCustomerID;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int CampaignID
        {
            set
            {
                _CampaignID = value;
            }
            get
            {
                return _CampaignID;
            }
        }
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }
        }
        public string TopicIDs
        {
            set
            {
                _TopicIDs = value;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public int LastContactStatus
        {
            set
            {
                _LastContactStatus = value;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        public string Comment
        {
            set
            { _Comment = value; }
            get
            {
                return _Comment;
            }
        }
        int _StatusEmployee;

        public int StatusEmployee
        {
            get { return _StatusEmployee; }
            set { _StatusEmployee = value; }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        string _StatusStr;
        public string StatusStr
        { set { _StatusStr = value; } }
        string _VisitStatusStr;
        public string VisitStatusStr
        { set { _VisitStatusStr = value; } }
        string _VisitFunctionalStatusStr;
        public string VisitFunctionStatusStr
        {
            set
            {
                _VisitFunctionalStatusStr = value;
            }
        }

        public int FunctionalStatus
        {
            set
            {
                _FunctionalStatus = value;
            }
            get
            {
                return _FunctionalStatus;
            }
        }
        public int RuleID
        {
            set
            {
                _RuleID = value;
            }
            get
            {
                return _RuleID;
            }
        }

        public bool WaitingAnotherContact
        {
            set
            {
                _WaitingAnotherContact = value;
            }
            get
            {
                return _WaitingAnotherContact;
            }
        }
        public DateTime WaitingDate
        {
            get
            {
                return _WaitingDate;
            }
        }
        bool _WaitingComunication;

        public bool WaitingComunication
        {
            get { return _WaitingComunication; }
            set { _WaitingComunication = value; }
        }
        int _ComunicationWay;

        public int ComunicationWay
        {
            get { return _ComunicationWay; }
            set { _ComunicationWay = value; }
        }
        bool _HasStatusPostponementDate;

        public bool HasStatusPostponementDate
        {
            get { return _HasStatusPostponementDate; }
            set { _HasStatusPostponementDate = value; }
        }
        DateTime _StatusPostponementDate;

        public DateTime StatusPostponementDate
        {
            get { return _StatusPostponementDate; }
            set { _StatusPostponementDate = value; }
        }
        protected int _StatusUser;
        protected string _StatusComment;
        public int StatusUser
        {
            set
            {
                _StatusUser = value;
            }
            get
            {
                return _StatusUser;
            }
        }
        public string StatusComment
        {
            set
            {
                _StatusComment = value;
            }
            get
            {
                return _StatusComment;
            }
        }
        public int Employee
        {
            set
            {
                _Employee = value;
            }
            get
            {
                return _Employee;
            }
        }
        public int Branch
        {
            set
            {
                _Branch = value;
            }
            get
            {
                return _Branch;
            }
        }
        int _WindowNo;
        public int WindowNo
        {
            set => _WindowNo = value;
            get => _WindowNo;
        }
        string _COntactCustomerName;
        public string ContactCustomerName
        {
            set { _COntactCustomerName = value; }
            get { return _COntactCustomerName; }
        }
        string _ContactCustomerPhone;
        public string ContactCustomerPhone { get => _ContactCustomerPhone; set => _ContactCustomerPhone = value; }
        string _BranchName;

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }
        int _Ticket;

        public int Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }
        string _TicketDesc;
        public string TicketDesc
        {
            set
            {
                _TicketDesc = value;
            }
            get
            {
                return _TicketDesc;
            }
        }
        int _TicketType;
        public int TicketType
        {
            set { _TicketType = value; }
            get { return _TicketType; }
        }
        string _TicketTypeName;
        public string TicketTypeName
        {
            get { return _TicketTypeName; }
        }
        int _TicketWorkGroup;

        public int TicketWorkGroup
        {
            get { return _TicketWorkGroup; }
            set { _TicketWorkGroup = value; }
        }
        string _TicketWorkGroupName;

        public string TicketWorkGroupName
        {
            get { return _TicketWorkGroupName; }
            set { _TicketWorkGroupName = value; }
        }
        int _TicketEmployee;

        public int TicketEmployee
        {
            get { return _TicketEmployee; }
            set { _TicketEmployee = value; }
        }
        string _TicketEmployeeName;

        public string TicketEmployeeName
        {
            get { return _TicketEmployeeName; }
            set { _TicketEmployeeName = value; }
        }
        int _TicketStatus;

        public int TicketStatus
        {
            get { return _TicketStatus; }
            set { _TicketStatus = value; }
        }
        DateTime _TicketPostponementDate;

        public DateTime TicketPostponementDate
        {
            get { return _TicketPostponementDate; }
            set { _TicketPostponementDate = value; }
        }
        bool _TicketIsPostponed;

        public bool TicketIsPostponed
        {
            get { return _TicketIsPostponed; }
            set { _TicketIsPostponed = value; }
        }
        public DateTime CampaignDate
        {
            get
            {
                return _CampaignDate;
            }
        }
        public string CampaignDesc
        {
            get
            {
                return _CampaignDesc;
            }
        }
        public int CampaignTopicID
        {
            get
            {
                return _CampaignTopicID;
            }
        }
        public string CampaignTopicName
        {
            get
            {
                return _CampaignTopicName;
            }
        }
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
        }
        public int DirectCustomerID
        {
            set
            {
                _DirectCustomerID = value;
            }
            get
            {
                return _DirectCustomerID;
            }
        }
        public string DirectCustomerName
        {
            get
            {
                return _DirectCustomerName;
            }
        }
        public string DirectCustomerUnitName
        {
            get
            {
                return _DirectCustomerUnitName;
            }
        }
        public string DirectCustomerTowerName
        {
            get
            {
                return _DirectCustomerTowerName;
            }
        }
        public string DirectCustomerProjectName
        {
            get
            {
                return _DirectCustomerProjectName;
            }
        }
        public string DirectCustomerMobile
        {
            get
            {
                return _DirectCustomerMobile;
            }
        }
        public string DirectCustomerPhone
        {
            get
            {
                return _DirectCustomerPhone;
            }
        }
        public string DirectCustomerAddress
        {
            get
            {
                return _DirectCustomerAddress;
            }
        }
        public int TopicID
        {
            get
            {
                return _TopicID;
            }
        }
        public string TopicName
        {
            get
            {
                return _TopicName;
            }
        }
        public int DirectCampaignID
        {
            get
            {
                return _DirectCampaignID;
            }
        }
        public string DirectCampaignDesc
        {
            get
            {
                return _DirectCampaignDesc;
            }
        }
        public DateTime DirectCmpaignDate
        {
            get
            {
                return _DirectCmpaignDate;
            }
        }
        public int SMSMsgID
        {
            get
            {
                return _SMSMsgID;
            }
        }
        public string SMSMsg
        {
            get
            {
                return _SMSMsg;
            }
        }
        public string RuleDesc
        {
            get
            {
                return _RuleDesc;
            }
        }
        int _Project;

        public int Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        string _ProjectName;

        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
        int _ReactionTypeID;
        public int ReactionTypeID
        {
            set { _ReactionTypeID = value; }
            get { return _ReactionTypeID; }
        }
        string _ReactionTypeCode;
        public string ReactionTypeCode
        {
            set { _ReactionTypeCode = value; }
            get { return _ReactionTypeCode; }
        }
        string _ReactionTypeNameA;
        public string ReactionTypeNameA
        {
            set { _ReactionTypeNameA = value; }
            get { return _ReactionTypeNameA; }
        }
        string _ReactionTypeNameE;
        public string ReactionTypeNameE
        {
            set { _ReactionTypeNameE = value; }
            get { return _ReactionTypeNameE; }
        }
        #region Data ForReciption
        public int ReceptionStatus
        {
            set
            {
                _ReceptionStatus = value;
            }

        }
        public int ReceptionProcessedStatus
        {
            set
            {
                _ReceptionProcessedStatus = value;
            }
        }
        public bool IsReception
        {
            set
            {
                _IsReception = value;
            }
            get
            {
                return _IsReception;
            }
        }
        public int ReceptionistID
        {
            set
            {
                _ReceptionistID = value;
            }
            get
            {
                return _ReceptionistID;
            }
        }
        public string ReceptionistName
        {
            get
            {
                return _ReceptionistName;
            }
        }
        public DateTime ReceptionDate
        {
            get
            {
                return _ReceptionDate;
            }
        }

        public bool ReceptionProcessed
        {
            set
            {
                _ReceptionProcessed = value;
            }
            get
            {
                return _ReceptionProcessed;
            }
        }
        bool _IsPicked;

        public bool IsPicked
        {
            get { return _IsPicked; }
            set { _IsPicked = value; }
        }
        int _PickedStatus;

        public int PickedStatus
        {
            get { return _PickedStatus; }
            set { _PickedStatus = value; }
        }
        DateTime _ReceptionPickTime;

        public DateTime ReceptionPickTime
        {
            get { return _ReceptionPickTime; }
            set { _ReceptionPickTime = value; }
        }

        bool _IsDeparted;

        public bool IsDeparted
        {
            get { return _IsDeparted; }
            set { _IsDeparted = value; }
        }
        DateTime _DepartureTime;

        public DateTime DepartureTime
        {
            get { return _DepartureTime; }
            set { _DepartureTime = value; }
        }
        bool _IsEntered;

        public bool IsEntered
        {
            get { return _IsEntered; }
            set { _IsEntered = value; }
        }
        DateTime _EntryTime;

        public DateTime EntryTime
        {
            get { return _EntryTime; }
            set { _EntryTime = value; }
        }
        int _EntryStatus;

        public int EntryStatus
        {
            get { return _EntryStatus; }
            set { _EntryStatus = value; }
        }
        private DateTime _CancelTime;

        public DateTime CancelTime
        {
            get { return _CancelTime; }
            set { _CancelTime = value; }
        }
        bool _IsCanceled;

        public bool IsCanceled
        {
            get { return _IsCanceled; }
            set { _IsCanceled = value; }
        }
        int _AssignmentStatus;

        public int AssignmentStatus
        {
            get { return _AssignmentStatus; }
            set { _AssignmentStatus = value; }
        }
        int _WorkGroup;

        public int WorkGroup
        {
            get { return _WorkGroup; }
            set { _WorkGroup = value; }
        }
        string _WorkGroupName;

        public string WorkGroupName
        {
            get { return _WorkGroupName; }
            set { _WorkGroupName = value; }
        }
        int _Reservation;

        public int Reservation
        {
            get { return _Reservation; }
            set { _Reservation = value; }
        }
        string _ReservationUnitName;

        public string ReservationUnitName
        {
            get { return _ReservationUnitName; }
            set { _ReservationUnitName = value; }
        }
        string _ReservationCustomerName;

        public string ReservationCustomerName
        {
            get { return _ReservationCustomerName; }
            set { _ReservationCustomerName = value; }
        }
        int _ReservationStatus;
        public int ReservationStatus
        {
            set => _ReservationStatus = value;
            get => _ReservationStatus;
        }
        DateTime _ReservationCancelationDate;
        public DateTime ReservationCancelationDate
        {
            set => _ReservationCancelationDate = value;
            get => _ReservationCancelationDate;
        }
        bool _LogInWithSearch;

        public bool LogInWithSearch
        {
            get { return _LogInWithSearch; }
            set { _LogInWithSearch = value; }
        }
        bool _StopCount;

        public bool StopCount
        {
            get { return _StopCount; }
            set { _StopCount = value; }
        }
        #endregion
        public bool IsEmployeeGroup
        {
            set
            {
                _IsEmployeeGroup = value;
            }
        }
        public bool IsCampaignGroup
        {
            set
            {
                _IsCampaignGroup = value;
            }
        }
        public bool IsCustomerGroup
        {
            set
            {
                _IsCustomerGroup = value;
            }
        }
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
        public bool IsDayGroup
        {
            set
            {
                _IsDayGroup = value;
            }
        }
        public bool IsMonthGroup
        {
            set
            {
                _IsMonthGroup = value;
            }
        }
        public bool IsYearGroup
        {
            set
            {
                _IsYearGroup = value;
            }
        }
        public bool IsTypeGroup
        {
            set
            {
                _IsTypeGroup = value;
            }
        }
        public bool IsDirectionGroup
        {
            set
            {
                _IsDirectionGroup = value;
            }
        }
        public bool IsMsgGroup
        {
            set
            {
                _IsMsgGroup = value;
            }
        }

        bool _IsWorkGroupGroup;

        public bool IsWorkGroupGroup
        {
            get { return _IsWorkGroupGroup; }
            set { _IsWorkGroupGroup = value; }
        }


        public int DirectionStatus
        {
            set
            {
                _DirectionStatus = value;
            }
        }
        bool _IsPaymentTypeGroup;
        public bool IsPaymentTypeGroup
        {
            set
            {
                _IsPaymentTypeGroup = value;
            }
        }


        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }
        public int NotSpecifiedCount
        {
            get
            {
                return _NotSpecifiedCount;
            }
        }
        public int DoneStatusCount
        {
            get
            {
                return _DoneStatusCount;
            }
        }
        public int WrongNoStatusCount
        {
            get
            {
                return _WrongNoStatusCount;
            }
        }
        public int NoAnswerStatusCount
        {
            get
            {
                return _NoAnswerStatusCount;
            }
        }
        public int NoNoStatusCount
        {
            get
            {
                return _NoNoStatusCount;
            }
        }
        public int NotSpecifiedFunctionalStatusCount
        {
            get
            {
                return _NotSpecifiedFunctionalStatusCount;
            }
        }
        public int DoneFunctionalStatusCount
        {
            get
            {
                return _DoneFunctionalStatusCount;
            }
        }
        public int RefusedFunctionalStatusCount
        {
            get
            {

                return _RefusedFunctionalStatusCount;
            }
        }
        public int EscalatedFunctionalStatusCount
        {
            get
            {
                return _EscalatedFunctionalStatusCount;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        DateTime _FirstDate;
        public DateTime FirstDate
        {
            get => _FirstDate;

        }
        DateTime _LastDate;
        public DateTime LastDate { get => _LastDate; }
        bool _WaitingMonitor;

        public bool WaitingMonitor
        {
            get { return _WaitingMonitor; }
            set { _WaitingMonitor = value; }
        }
        DateTime _WaitingMonitoringDate;

        public DateTime WaitingMonitoringDate
        {
            get { return _WaitingMonitoringDate; }
            set { _WaitingMonitoringDate = value; }
        }
        DateTime _AnotherContactDate;

        public DateTime AnotherContactDate
        {
            get { return _AnotherContactDate; }
            set { _AnotherContactDate = value; }
        }
        int _VisitType;

        public int VisitType
        {
            get { return _VisitType; }
            set { _VisitType = value; }
        }
        string _VisitTypeIDs;
        public string VisitTypeIDs
        {
            set
            {
                _VisitTypeIDs = value;
            }
        }
        int _LastMonitoringID;

        public int LastMonitoringID
        {
            get { return _LastMonitoringID; }
            set { _LastMonitoringID = value; }
        }
        DateTime _LastMonitoringDate;

        public DateTime LastMonitoringDate
        {
            get { return _LastMonitoringDate; }
            set { _LastMonitoringDate = value; }
        }
        string _LastMonitoringDesc;

        public string LastMonitoringDesc
        {
            get { return _LastMonitoringDesc; }
            set { _LastMonitoringDesc = value; }
        }
        int _LastMonitoringStatus;

        public int LastMonitoringStatus
        {
            get { return _LastMonitoringStatus; }
            set { _LastMonitoringStatus = value; }
        }
        int _LastMonitoringEmployee;

        public int LastMonitoringEmployee
        {
            get { return _LastMonitoringEmployee; }
            set { _LastMonitoringEmployee = value; }
        }
        string _LastMonitoringEmolyeeName;

        public string LastMonitoringEmolyeeName
        {
            get { return _LastMonitoringEmolyeeName; }
            set { _LastMonitoringEmolyeeName = value; }
        }
        string _IDs;

        public string IDs
        {
            get { return _IDs; }
            set { _IDs = value; }
        }
        string _MonitoringDesc;

        public string MonitoringDesc
        {
            get { return _MonitoringDesc; }
            set { _MonitoringDesc = value; }
        }
        int _MonitoringStatus;

        public int MonitoringStatus
        {
            get { return _MonitoringStatus; }
            set { _MonitoringStatus = value; }
        }

        int _WaitingMonitoringStatus;

        public int WaitingMonitoringStatus
        {
            get { return _WaitingMonitoringStatus; }
            set { _WaitingMonitoringStatus = value; }
        }
        int _WaitingMonitoringDateStatus;

        public int WaitingMonitoringDateStatus
        {
            get { return _WaitingMonitoringDateStatus; }
            set { _WaitingMonitoringDateStatus = value; }
        }
        DateTime _MonitorDateStart;

        public DateTime MonitorDateStart
        {
            get { return _MonitorDateStart; }
            set { _MonitorDateStart = value; }
        }
        DateTime _MonitorDateEnd;

        public DateTime MonitorDateEnd
        {
            get { return _MonitorDateEnd; }
            set { _MonitorDateEnd = value; }
        }
        int _AssignedEmployee;

        public int AssignedEmployee
        {
            get { return _AssignedEmployee; }
            set { _AssignedEmployee = value; }
        }


        int _VisitNo;
        public int VisitNo
        {
            set => _VisitNo = value;
            get => _VisitNo;
        }
        bool _IsBroadCasted;
        public bool IsBroadCasted
        {
            set => _IsBroadCasted = value;
            get => _IsBroadCasted;
        }
        DateTime _BroadCastTime;
        public DateTime BroadCastTime
        {
            set => _BroadCastTime = value;
            get => _BroadCastTime;
        }
        public bool IsWorGroupGroup { get => _IsWorGroupGroup; set => _IsWorGroupGroup = value; }
        public bool IsBranchGroup { get => _IsBranchGroup; set => _IsBranchGroup = value; }
        public bool IsVisitTypeGroup { get => _IsVisitTypeGroup; set => _IsVisitTypeGroup = value; }
        public string SearchStr
        {
            get
            {
                #region Customer Unit
                string strUnitProject = "SELECT DISTINCT dbo.CRMUnitCell.UnitID, dbo.CRMUnit.UnitFullName" +
                  ", CASE WHEN TowerTable.CellAlterName IS NULL OR " +
                    " TowerTable.CellAlterName = '' THEN TowerTable.CellNameA ELSE TowerTable.CellAlterName END AS TowerName, " +
                    "ProjectNameA AS ProjectName,dbo.CRMProject.ProjectID  " +
                    @" FROM  dbo.CRMUnit 
   INNER JOIN    dbo.CRMTower 
ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID 
INNER JOIN    dbo.CRMProject 
ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID 
    INNER JOIN  dbo.CRMUnitCell 
  ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                    " dbo.RPCell AS FloorTable ON dbo.CRMUnitCell.CellID = FloorTable.CellID INNER JOIN " +
                    " dbo.RPCell AS TowerTable ON FloorTable.CellParentID = TowerTable.CellID INNER JOIN " +
                    " dbo.RPCell AS ProjectTable ON TowerTable.CellFamilyID = ProjectTable.CellID ";
                string strCustomerUnit = "SELECT  TOP (100) PERCENT dbo.CRMReservationCustomer.CustomerID, MAX(dbo.CRMUnit.UnitID) AS MaxUnitID, MIN(dbo.CRMUnit.UnitID) AS MinUnitID, " +
                      " COUNT(dbo.CRMUnit.UnitID) AS UnitCount " +
                      " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                      " dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation " +
                      " GROUP BY dbo.CRMReservationCustomer.CustomerID ";
                strCustomerUnit = "select CustomerUnitTable.CustomerID UnitCustomerID , CustomerUnitTable.UnitCount " +
                    //CustomerUnitName
                    ",Case when CustomerUnitTable.UnitCount = 0 then '' " +
                    " when  CustomerUnitTable.UnitCount = 1 then MaxUnitTable.UnitFullName  " +
                    " when CustomerUnitTable.UnitCount = 2 then MaxUnitTable.UnitFullName + '&' + MinUnitTAble.UnitFullName " +
                    " when CustomerUnitTable.UnitCount > 2 then MaxUnitTable.UnitFullName + '&..&' + MinUnitTAble.UnitFullName end as CustomerUnitFullName " +
                    //CustomerTowerName
                    ",Case when CustomerUnitTable.UnitCount = 0 then '' " +
                    " when  CustomerUnitTable.UnitCount = 1 or (CustomerUnitTable.UnitCount > 1 and MinUnitTable.TowerName=MaxUnitTable.TowerName)  then MaxUnitTable.TowerName  " +
                    " when CustomerUnitTable.UnitCount = 2 then MaxUnitTable.TowerName + '&' + MinUnitTAble.TowerName " +
                    " when CustomerUnitTable.UnitCount > 2 then MaxUnitTable.TowerName + '&..&' + MinUnitTAble.TowerName end as CustomerTowerName " +
                  //Customer Proejct
                  ",Case when CustomerUnitTable.UnitCount = 0 then '' " +
                    " when  CustomerUnitTable.UnitCount = 1 or (CustomerUnitTable.UnitCount > 1 and MinUnitTable.ProjectName=MaxUnitTable.ProjectName)  then MaxUnitTable.ProjectName  " +
                    " when CustomerUnitTable.UnitCount = 2 then MaxUnitTable.ProjectName + '&' + MinUnitTAble.ProjectName " +
                    " when CustomerUnitTable.UnitCount > 2 then MaxUnitTable.ProjectName + '&..&' + MinUnitTAble.ProjectName end as CustomerProjectName " +
                " from (" + strCustomerUnit + ") as CustomerUnitTable " +
                " inner join (" + strUnitProject + ") MinUnitTable " +
                " on CustomerUnitTable.MinUnitID = MinUnitTable.UnitID " +
                " inner join (" + strUnitProject + ") as MaxUnitTable " +
                " on CustomerUnitTable.MaxUnitID = MaxUnitTAble.UnitID  ";

                #endregion
                string strMsg = "SELECT SMSID,SMSCustomerCampaign, SMSMsg " +
                       " FROM  dbo.CRMCampaignSMS ";
                string strLastContact = "SELECT CampaignCustomerID, MAX(CampaignContactID) AS MaxContactID " +
                       " FROM  dbo.CRMCampaignCustomerContact " +
                       " GROUP BY CampaignCustomerID ";

                string strReactionType = @"SELECT        ReactionTypeID AS ContactReactionTypeID, ReactionTypeCode AS ContactReactionTypeCode, ReactionTypeNameA AS ContactReactionTypeNameA, ReactionTypeNameE AS ContactReactionTypeNameE 
       FROM   dbo.CRMReactionType";

                string strCampaignCustomer = "SELECT  dbo.CRMCampaignCustomer.CampaignCustomerID, dbo.CRMCampaign.CampaignID, dbo.CRMCampaign.CampaignDate, " +
                      " dbo.CRMCampaign.CampaignDesc, dbo.CRMCustomer.CustomerID, dbo.CRMCustomer.CustomerFullName " +
                      //",   dbo.CRMCampaignCustomer.WaitingMonitoringDate, dbo.CRMCampaignCustomer.WaitingContactDate, dbo.CRMCampaignCustomerMonitor.MonitoringID AS LastMonitoringID, "+
                      // "dbo.CRMCampaignCustomerMonitor.MonitoringDate AS LastMonitoringDate, dbo.CRMCampaignCustomerMonitor.MonitoringDesc AS LastMonitoringDesc, "+
                      // " dbo.CRMCampaignCustomerMonitor.MonitoringStatus AS LastMonitoringStatus, dbo.CRMCampaignCustomerMonitor.MonitoringEmployee AS LastMonitoringEmployee,  "+
                      // "dbo.HRApplicant.ApplicantFirstName AS LastMonitoringEmolyeeName    "+
                      " FROM     dbo.CRMCampaignCustomer left outer JOIN " +
                      " dbo.CRMCampaign ON dbo.CRMCampaignCustomer.Campaign = dbo.CRMCampaign.CampaignID INNER JOIN " +
                      "  dbo.CRMCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMCustomer.CustomerID " +
                      //" LEFT OUTER JOIN   dbo.CRMCampaignCustomerMonitor "+
                      //" ON dbo.CRMCampaignCustomer.LastMonitoringID = dbo.CRMCampaignCustomerMonitor.MonitoringID "+
                      //" LEFT OUTER JOIN  dbo.HRApplicant "+
                      //" ON dbo.CRMCampaignCustomerMonitor.MonitoringEmployee = dbo.HRApplicant.ApplicantID "+ 
                      " where (1=1) ";
                if (_CampaignID != 0)
                    strCampaignCustomer += " and dbo.CRMCampaign.CampaignID=" + _CampaignID;
                if (_CustomerID != 0)
                    strCampaignCustomer += " and  dbo.CRMCustomer.CustomerID=" + _CustomerID;


                string strDirectCustomer = "SELECT dbo.CRMCustomer.CustomerID AS DirectCustomerID" +
                    ", dbo.CRMCustomer.CustomerFullName AS DirectCustomerName" +
                    ", dbo.CRMCustomer.CustomerAddress AS DirectCustomerAddress, dbo.CRMCustomer.CustomerHomePhone AS DirectCustomerPhone, " +
                    " dbo.CRMCustomer.CustomerMobile AS DirectCustomerMobile " +
                    ",DirectCustomerUnitTable.CustomerUnitFullName  as DirectCustomerUnitName " +
                    ",DirectCustomerUnitTable.CustomerTowerName as DirectCustomerTowerName " +
                    ",DirectCustomerUnitTable.CustomerProjectName as DirectCustomerProjectName  " +
                       " FROM  dbo.CRMCustomer left outer join (" + strCustomerUnit + ") as DirectCustomerUnitTable " +
                       " on CRMCustomer.CustomerID = DirectCustomerUnitTable.UnitCustomerID " +
                       " where(1=1) ";
                if (_CustomerID != 0)
                    strDirectCustomer += " and dbo.CRMCustomer.CustomerID=" + _CustomerID;
                if (_DirectCustomerID != 0)
                    strDirectCustomer += " and dbo.CRMCustomer.CustomerID=" + _DirectCustomerID;
                string strCampaign = "SELECT     CampaignID AS DirectCampaignID, CampaignDate AS DirectCampaignDate, CampaignDesc AS DirectCampaignDesc " +
                    ",COMMONTopic.TopicID as DirectCampaignTopicID,COMMONTopic.TopicNameA as DirectCampaignTopicName  " +
                       " FROM  dbo.CRMCampaign left outer join COMMONTopic " +
                       " on CRMCampaign.CampaignTopic = COMMONTopic.TopicID " +
                       " where (1=1) ";
                if (_CampaignID != 0)
                    strCampaign += " and CampaignID=" + _CampaignID;
                string strTopic = "SELECT     TopicID AS DirectTopicID, TopicNameA AS DirectTopicName " +
                       " FROM     dbo.COMMONTopic where (1=1) ";
                if (_TopicIDs != null && _TopicIDs != "")
                    strTopic += " and TopicID in (" + _TopicIDs + ")";

                string strReception = "SELECT dbo.CRMCampaignCustomerContactReception.CampaignContactID AS CampaignContactReceptionID, " +
                      " dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionist, dbo.HRApplicant.ApplicantFirstName AS CampaignContactReceptionistName,  " +
                      " dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionTime  " +
                      ",dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionPickTime" +
                      ", dbo.CRMCampaignCustomerContactReception.CampaignContactEntryTime" +
                      ",dbo.CRMCampaignCustomerContactReception.CampaignContactCancelTime " +
                      ", dbo.CRMCampaignCustomerContactReception.CampaignContactDepartureTime, " +
                         " dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup " +
                      ", dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionProcessed" +
                      ",   dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionCustomerName, dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionCustomerPhone" +
                      ",CampaignContactReceptionWindowNo, CampaignContactReceptionVisitNo, CampaignContactReceptionBroadCastTime " +
                      ",VisitTypeTable.*,CampaignContactVisitType  " +
                      " FROM         dbo.CRMCampaignCustomerContactReception LEFT OUTER JOIN " +
                      " dbo.HRApplicant ON dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionist = dbo.HRApplicant.ApplicantID " +
                      "  left outer join (" + VisitTypeDb.SearchStr + ") as VisitTypeTable " +
                      " on CRMCampaignCustomerContactReception.CampaignContactVisitType = VisitTypeTable.VisitTypeID  ";

                string strReservationCustomer = "SELECT        derivedtbl_1.ReservationID, CRMCustomer_1.CustomerID AS VisitReservationCustomerID, CRMCustomer_1.CustomerFullName AS VisitReservationCustomerName " +
                          " FROM            (SELECT        dbo.CRMReservationCustomer.ReservationID, MAX(dbo.CRMCustomer.CustomerID) AS MaxCustomer " +
                          " FROM            dbo.CRMReservationCustomer INNER JOIN " +
                          " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID " +
                          " GROUP BY dbo.CRMReservationCustomer.ReservationID) AS derivedtbl_1 INNER JOIN " +
                          " dbo.CRMCustomer AS CRMCustomer_1 ON derivedtbl_1.MaxCustomer = CRMCustomer_1.CustomerID ";
                string strReservation = @"SELECT      dbo.CRMReservation.ReservationStatus, dbo.CRMReservationCancelation.ReservationID AS CancelationID, dbo.CRMReservationCancelation.CancelationDate
   ,maxUnitTable.ReservationID as VisitReservationID , CRMUnit_1.UnitFullName as VisitRservationUnit  " +
                   ",MaxCustomerTable.VisitReservationCustomerID,MaxCustomerTable.VisitReservationCustomerName " +
                    @" FROM   dbo.CRMReservation LEFT OUTER JOIN
                         dbo.CRMReservationCancelation ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCancelation.ReservationID
inner join 
(SELECT        dbo.CRMReservationUnit.ReservationID, MAX(dbo.CRMUnit.UnitID) AS MAxUnit " +
                    " FROM            dbo.CRMUnit INNER JOIN " +
                    " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID " +
                @" GROUP BY dbo.CRMReservationUnit.ReservationID) AS maxUnitTable
  on CRMReservation.ReservationID = maxUnitTable.ReservationID
 INNER JOIN " +
                 " dbo.CRMUnit AS CRMUnit_1 ON maxUnitTable.MAxUnit = CRMUnit_1.UnitID " +
                 " left outer join (" + strReservationCustomer + ") as MaxCustomerTable " +
                 " on   maxUnitTable.ReservationID =MaxCustomerTable.ReservationID ";
                string strGroup = "SELECT  WorkGroupID AS VisitWorkGroupID, WorkGroupNameA AS VisitWorkGroupName " +
                 " FROM            dbo.HRWorkGroup ";
                string strVisitStatus = "SELECT        StatusTable.* " +
                  " FROM            (SELECT        VisitID, MAX(StatusID) AS MaxStatus " +
                  " FROM            dbo.CRMVisitStatus " +
                  " GROUP BY VisitID) AS MaxStatusTable INNER JOIN " +
                  "(" + VisitStatusDb.SearchStr + ") AS StatusTable ON MaxStatusTable.VisitID = StatusTable.VisitStatusVisitID " +
                  " AND MaxStatusTable.MaxStatus = StatusTable.StatusID ";

                string strTicket = @"SELECT        dbo.CRMTicket.TicketID AS ContactTicketID, dbo.HRWorkGroup.WorkGroupNameA AS ContactTicketWorkGroupName, dbo.HRApplicant.ApplicantFirstName AS ContactTicketEmployee1, 
                         derivedtbl_2.TicketStatus AS ContactTicketStatus, derivedtbl_2.TicketPostponementDate AS ContactTicketPostponementDate, dbo.CRMTicket.TicketAssignedApplicant AS ContactTicketEmployeeID, 
                         dbo.CRMTicket.TicketWorkGroup AS ContactTicketWorkGroupID, dbo.CRMTicket.TicketDesc, dbo.CRMTicket.TicketDate, dbo.CRMTicket.TicketType, dbo.CRMTicketType.TicketTypeNameA
FROM            dbo.CRMTicket LEFT OUTER JOIN
                         dbo.CRMTicketType ON dbo.CRMTicket.TicketType = dbo.CRMTicketType.TicketTypeID LEFT OUTER JOIN
                             (SELECT        derivedtbl_1.TicketID, CRMTicketStatus_1.TicketStatus, CRMTicketStatus_1.TicketPostponementDate
                                FROM            (SELECT        TicketID, MAX(StatusID) AS MaxTicketStatus
                                                           FROM            dbo.CRMTicketStatus
                                                           GROUP BY TicketID) AS derivedtbl_1 INNER JOIN
                                                         dbo.CRMTicketStatus AS CRMTicketStatus_1 ON derivedtbl_1.MaxTicketStatus = CRMTicketStatus_1.StatusID AND derivedtbl_1.TicketID = CRMTicketStatus_1.TicketID) AS derivedtbl_2 ON 
                         dbo.CRMTicket.TicketID = derivedtbl_2.TicketID LEFT OUTER JOIN
                         dbo.HRApplicant ON dbo.CRMTicket.TicketAssignedApplicant = dbo.HRApplicant.ApplicantID LEFT OUTER JOIN
                         dbo.HRWorkGroup ON dbo.CRMTicket.TicketWorkGroup = dbo.HRWorkGroup.WorkGroupID";


                string strProject = "SELECT   CellID AS ProjectID, CASE WHEN ISNULL(CellAlterName, '') = '' THEN CellNameA ELSE CellAlterName END AS ProjectName " +
" FROM            dbo.RPCell ";


                string strPayment = @" SELECT        dbo.CRMVisitPayment.VisitID, SUM(ISNULL(CASE WHEN dbo.GLCheck.CheckID IS NULL OR
                         dbo.GLCheckPayment.PaymentIsCollected = 1 OR
                         CheckCurrentStatus = 2 THEN dbo.GLPayment.PaymentValue ELSE 0 END, 0)) AS PaidValue, dbo.CRMAdministrativeCostType.CostTypeNameA
FROM            dbo.CRMAdministrativeCostType RIGHT OUTER JOIN
                         dbo.CRMAdministrativeCostPayment ON dbo.CRMAdministrativeCostType.CostTypeID = dbo.CRMAdministrativeCostPayment.CostType RIGHT OUTER JOIN
                         dbo.GLPayment ON dbo.CRMAdministrativeCostPayment.PaymentID = dbo.GLPayment.PaymentID LEFT OUTER JOIN
                         dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID RIGHT OUTER JOIN
                         dbo.CRMVisitPayment ON dbo.GLPayment.PaymentID = dbo.CRMVisitPayment.PaymentID LEFT OUTER JOIN
                         dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID
GROUP BY dbo.CRMVisitPayment.VisitID, dbo.CRMAdministrativeCostType.CostTypeNameA ";
                string Returned = "SELECT  dbo.CRMCampaignCustomerContact.CampaignContactID, ContactDirection, ContactDate," +
                    " ContactType, ContactComment, ContactStatus, ContactFunctionalStatus, " +
                      "ContactWaitingAnotherContact, ContactWaitingDate, ContactEmployee, ContactBranch " +
                      ",CampaignCustomerTable.*" +
                      ",TopicTable.*  ";
                if (_ReceptionStatus != 1)
                    Returned += ",MsgTable.*";
                Returned += ",DirectCustomerTable.*,CampaignTable.* " +
                      ",ReceptionTable.* " +
                          ",VisitStatusTable.*" +
                                  ",ReservationTable.VisitReservationID,ReservationTable.VisitRservationUnit ,ReservationTable.VisitReservationCustomerName" +
                                  @",ReservationTable.ReservationStatus
,ReservationTable.CancelationID,ReservationTable.CancelationDate " +
                                  ",GroupTable.*,EmployeeTable.*,BranchTable.*,TicketTable.*  " +

                                  ",   dbo.CRMCampaignCustomerContact.ContactWaitingMonitoringDate as WaitingMonitoringDate" +
                                  ",dbo.CRMCampaignCustomerContact.ContactWaitingDate as WaitingContactDate, dbo.CRMCampaignCustomerMonitor.MonitoringID AS LastMonitoringID, " +
                      "dbo.CRMCampaignCustomerMonitor.MonitoringDate AS LastMonitoringDate, dbo.CRMCampaignCustomerMonitor.MonitoringDesc AS LastMonitoringDesc, " +
                      " dbo.CRMCampaignCustomerMonitor.MonitoringStatus AS LastMonitoringStatus, dbo.CRMCampaignCustomerMonitor.MonitoringEmployee AS LastMonitoringEmployee,  " +
                      "MonitorApplicantTable.ApplicantFirstName AS LastMonitoringEmolyeeName    " +
                      " ,ProjectTable.* ,isnull(PaymentTable.PaidValue,0) as TotalPaidValue,isnull(PaymentTable.CostTypeNameA,'') as PaymentType   " +
                      ",ReactionTypeTable.* " +
                      " FROM   dbo.CRMCampaignCustomerContact " +
                      " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable " +
                      " on dbo.CRMCampaignCustomerContact.ContactEmployee = EmployeeTable.ApplicantID " +
                    " inner join (" + strCampaignCustomer + ")  as CampaignCustomerTable " +
                    " on CRMCampaignCustomerContact.CampaignCustomerID = CampaignCustomerTable.CampaignCustomerID " +
                    " LEFT OUTER JOIN  (" + strReactionType + ") AS ReactionTypeTable " +
                    " ON dbo.CRMCampaignCustomerContact.ContactReactionType = ReactionTypeTable.ReactionTypeID";


                Returned += " left outer join (" + strPayment + ") as PaymentTable " +
                    " on  dbo.CRMCampaignCustomerContact.CampaignContactID = PaymentTable.VisitID ";
                if (_DirectCustomerID == 0)
                    Returned += " left outer join ";
                else
                    Returned += " inner join ";
                Returned += " (" + strDirectCustomer + ") as DirectCustomerTable " +
                      " on    dbo.CRMCampaignCustomerContact.ContactDirectCustomer=DirectCustomerTable.DirectCustomerID " +
                      " left outer join (" + strTopic + ") as TopicTable " +
                      " on  dbo.CRMCampaignCustomerContact.ContactTopic = TopicTable.DirectTopicID " +
                    " left outer join (" + strCampaign + ") as CampaignTable " +
                    " on  CRMCampaignCustomerContact.ContactCampaign = CampaignTable.DirectCampaignID  ";
                if (_ReceptionStatus != 1)
                    Returned += " left outer join (" + strMsg + ") as MsgTable " +
                      " on CRMCampaignCustomerContact.CampaignContactID = MsgTable.SMSCustomerCampaign ";

                Returned += " left outer join (" + strReservation + ") as ReservationTable " +
           " on  dbo.CRMCampaignCustomerContact.ContactReservation = ReservationTable.VisitReservationID " +
                 " left outer join (" + strLastContact + ") as LastContactTable  " +
     " on  CRMCampaignCustomerContact.CampaignCustomerID = LastContactTable.CampaignCustomerID " +
     " left outer join (" + strTicket + ") as TicketTable " +
     " on CRMCampaignCustomerContact.ContactTicket = TicketTable.ContactTicketID " +
   " left outer join (" + UMSBranchDb.SearchStr + ") as BranchTable " +
   " on  dbo.CRMCampaignCustomerContact.ContactBranch = BranchTable.BranchID " +
   " left outer join (" + strProject + ") as ProjectTable " +
   " on  dbo.CRMCampaignCustomerContact.ContactProject = ProjectTable.ProjectID ";

                if (_ReceptionStatus == 1)
                    Returned += "  inner  join (" + strReception + ") as ReceptionTable ";
                else
                    Returned += "  left outer  join (" + strReception + ") as ReceptionTable ";




                Returned += "  on  CRMCampaignCustomerContact.CampaignContactID = ReceptionTable.CampaignContactReceptionID ";

                if (_IsDateRange)
                {
                    double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    string strContactDate = @"SELECT  distinct  CampaignContactID 
FROM            dbo.CRMCampaignCustomerContact_IDate
WHERE        (ContactDate BETWEEN " + dblStartDate + @" AND " + dblEndDate + @")";
                    Returned += " inner join (" + strContactDate + ") ContactDateTable " +
                        " on    dbo.CRMCampaignCustomerContact.CampaignContactID = ContactDateTable.CampaignContactID";
                }
                Returned += " left outer join (" + strVisitStatus + ") as VisitStatusTable " +
                    " on ReceptionTable.CampaignContactReceptionID = VisitStatusTable.VisitStatusVisitID  ";
                Returned += " left outer join (" + strGroup + ") as GroupTable " +
           " on ReceptionTable.CampaignContactReceptionGroup = GroupTable.VisitWorkGroupID  " +
              " LEFT OUTER JOIN   dbo.CRMCampaignCustomerMonitor " +
                      " ON dbo.CRMCampaignCustomerContact.ContactLastMonitoringID = dbo.CRMCampaignCustomerMonitor.MonitoringID " +
                      " LEFT OUTER JOIN  dbo.HRApplicant MonitorApplicantTable " +
                      " ON dbo.CRMCampaignCustomerMonitor.MonitoringEmployee = MonitorApplicantTable.ApplicantID ";
                Returned += " where (1=1) ";
                if (_CampaignCustomerID != 0)
                    Returned += " and CRMCampaignCustomerContact.CampaignCustomerID=" + _CampaignCustomerID + " ";

                if (_IsDateRange)
                {
                    double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    //Returned += " and CRMCampaignCustomerContact.ContactDate >= " + dblStartDate +
                    //  " and  CRMCampaignCustomerContact.ContactDate <" + dblEndDate;
                }
                if (_DirectionStatus != 0)
                {
                    if (_DirectionStatus == 1)
                        Returned += " and ContactDirection = 1 ";
                    else if (_DirectionStatus == 2)
                        Returned += " and ContactDirection = 0 ";
                }
                if (_TopicIDs != null && _TopicIDs != "")
                    Returned += " and (DirectTopicID in (" + _TopicIDs + ") " +
                        " or DirectCampaignTopicID in (" + _TopicIDs + ") " +
                        // " or  "+
                        "  )";
                if (_Employee != 0)//&&!_LogInWithSearch)
                    Returned += " and  (ContactEmployee =" + _Employee + "  or CampaignContactReceptionist = " + _Employee + " or EmployeeID = " + _Employee + ")";
                if (_Status != 0)
                    Returned += " and ContactStatus=" + _Status;
                if (_StatusStr != null && _StatusStr != "")
                    Returned += " and ContactStatus in (" + _StatusStr + ") ";
                if (_VisitStatusStr != null && _VisitStatusStr != "")
                    Returned += " and VisitStatus in (" + _VisitStatusStr + ") ";
                if (_VisitFunctionalStatusStr != null && _VisitFunctionalStatusStr != "")
                    Returned += " and VisitFunctionalStatus in (" + _VisitFunctionalStatusStr + ") ";
                if (_FunctionalStatus != 0)
                    Returned += " and ContactFunctionalStatus=" + _FunctionalStatus;
                if (_Type != 0)
                    Returned += " and ContactType =" + _Type;
                if (_PaymentStatus == 1)
                    Returned += " and PaymentTable.PaidValue >0 ";
                else if (_PaymentStatus == 2)
                    Returned += " and isnull(PaymentTable.PaidValue,0) = 0 ";

                if (_VisitType != 0)
                    Returned += " and CampaignContactVisitType = " + _VisitType;
                if (_VisitTypeIDs != null && _VisitTypeIDs != "")
                    Returned += " and CampaignContactVisitType in (" + _VisitType + ")";

                if (_Project != 0)
                    Returned += " and ProjectTable.ProjectID = " + _Project;
                if (_LastContactStatus != 0)
                {
                    if (_LastContactStatus == 1)
                        Returned += " and CampaignContactID = MaxContactID ";
                    else if (_LastContactStatus == 2)
                        Returned += " and CampaignContactID < MaxContactID ";
                }

                if (_Branch != 0)
                    Returned += " and  (dbo.CRMCampaignCustomerContact.ContactBranch = " + _Branch + ") ";
                if (_WorkGroup != 0)
                    Returned += " and CampaignContactReceptionGroup=" + _WorkGroup;
                if (_ReceptionStatus == 1)
                {
                    if (_PickedStatus > 0 && _EntryStatus > 0)
                        Returned += "";

                    if (_EntryStatus == 2)
                    {
                        Returned += " and (dbo.CRMCampaignCustomerContact.ContactEmployee = 0 or dbo.CRMCampaignCustomerContact.ContactEmployee = " +
                            _AssignedEmployee + "  or 1=" + _PickedStatus + ")" +
                         " and CampaignContactCancelTime is null and CampaignContactDepartureTime is null   " +
                         " and CampaignContactEntryTime is null  and VisitStatus <>" + ((int)ContactStatus.Done).ToString() + " ";

                    }
                    else if (_EntryStatus == 1)
                    {

                    }
                    if (_PickedStatus == 2)
                    {

                        Returned += " and VisitStatus in (" +
                            ((int)ContactStatus.Created).ToString() + "," + ((int)ContactStatus.Transfered).ToString() +
                            ")" +
                            " and CampaignContactCancelTime is null and CampaignContactDepartureTime is null   " +
                            " and  CampaignContactEntryTime is null  ";// " and ContactStatus <>" + ((int)ContactStatus.Done).ToString() + " ";

                        if (_AssignedEmployee != 0)
                            Returned += " and ( dbo.CRMCampaignCustomerContact.ContactEmployee = 0  or dbo.CRMCampaignCustomerContact.ContactEmployee = " + _AssignedEmployee + "  )";
                    }
                    else if (_PickedStatus == 1)
                    {
                        Returned += " and CampaignContactCancelTime is null and CampaignContactDepartureTime is null   and VisitStatus =" + ((int)ContactStatus.PickedUp).ToString() +
                        " ";
                    }
                }


                if (_WaitingMonitoringStatus == 1)
                {
                    Returned += " and CRMCampaignCustomerContact.ContactWaitingMonitoringDate is not null ";
                    if (_WaitingMonitoringDateStatus == 1)
                    {
                        double dblStart = SysUtility.Approximate(MonitorDateStart.ToOADate() - 2, 1, ApproximateType.Down);
                        double dblEnd = SysUtility.Approximate(MonitorDateEnd.ToOADate() - 2, 1, ApproximateType.Up);
                        Returned += " and CRMCampaignCustomerContact.ContactWaitingMonitoringDate >= " + dblStart + " and CRMCampaignCustomerContact.ContactWaitingMonitoringDate < " + dblEnd;
                    }
                }

                return Returned;
            }
        }
        #region  VisitSUm Properties

        int _NotSpecifiedStatusCount;
        public int NotSpecifiedStatusCount
        {
            set
            {
                _NotSpecifiedStatusCount = value;
            }
            get
            {
                return _NotSpecifiedStatusCount;
            }
        }



        int _NoNumberStatusCount;
        public int NoNumberStatusCount
        {
            set
            {
                _NoNumberStatusCount = value;
            }
            get
            {
                return _NoNumberStatusCount;
            }
        }

        double _TotalPaid;
        public double TotalPaid
        {
            set
            {
                _TotalPaid = value;
            }
            get
            {
                return _TotalPaid;
            }
        }
        string _PaymentType;
        public string PaymentType
        {
            set => _PaymentType = value;
            get => _PaymentType;
        }
        int _PaymentStatus;
        public int PaymentStatus { set => _PaymentStatus = value; }
        string _ApplicantFirstName;
        public string ApplicantFirstName
        {
            set
            {
                _ApplicantFirstName = value;
            }
            get
            {
                return _ApplicantFirstName;
            }
        }


        int _ContactType;
        public int ContactType
        {
            set
            {
                _ContactType = value;
            }
            get
            {
                return _ContactType;
            }
        }
        int _WorkGroupID;
        public int WorkGroupID
        {
            set
            {
                _WorkGroupID = value;
            }
            get
            {
                return _WorkGroupID;
            }
        }

        int _TypeID;
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }
        }
        string _TypeCode;
        public string TypeCode
        {
            set
            {
                _TypeCode = value;
            }
            get
            {
                return _TypeCode;
            }
        }
        string _TypeNameA;
        public string TypeNameA
        {
            set
            {
                _TypeNameA = value;
            }
            get
            {
                return _TypeNameA;
            }
        }
        string _TypeNameE;
        public string TypeNameE
        {
            set
            {
                _TypeNameE = value;
            }
            get
            {
                return _TypeNameE;
            }
        }
        int _D;
        public int D
        {
            set
            {
                _D = value;
            }
            get
            {
                return _D;
            }
        }
        int _M;
        public int M
        {
            set
            {
                _M = value;
            }
            get
            {
                return _M;
            }
        }
        int _Y;
        public int Y
        {
            set
            {
                _Y = value;
            }
            get
            {
                return _Y;
            }
        }


        #endregion
        public string SumSearchStr
        {
            get
            {
                string Returned = "";
                string strGroup = "";
                string strOrder = "";
                string strSelect = "count(CampaignContactID) as TotalCount ";

                //ContactStatus, ContactFunctionalStatus
                strSelect += ",sum(case when ContactStatus = 0 then 1 else 0 end) as NotSpecifiedStatusCount ";
                strSelect += ",sum(case when ContactStatus = 1 then 1 else 0 end) as DoneStatusCount ";
                strSelect += ",sum(case when ContactStatus = 2 then 1 else 0 end) as WrongNoStatusCount ";
                strSelect += ",sum(case when ContactStatus = 3 then 1 else 0 end) as NoAnswerStatusCount ";
                strSelect += ",sum(case when ContactStatus = 4 then 1 else 0 end) as NoNumberStatusCount ";

                strSelect += ",sum(case when ContactStatus = 1 and ContactFunctionalStatus =0  then 1 else 0 end) as NotSpecifiedFunctionalStatusCount ";
                strSelect += ",sum(case when ContactStatus = 1 and ContactFunctionalStatus =1 then 1 else 0 end) as DoneFunctionalStatusCount ";
                strSelect += ",sum(case when ContactStatus = 1 and ContactFunctionalStatus =2 then 1 else 0 end) as RefusedFunctionalStatusCount ";
                strSelect += ",sum(case when ContactStatus = 1 and ContactFunctionalStatus =3 then 1 else 0 end) as EscalatedFunctionalStatusCount ";
                strSelect += ",sum(TotalPaidValue) as TotalPaid ";
                if (_IsEmployeeGroup)
                {
                    strSelect += ",ApplicantFirstName";
                    strGroup += "ApplicantFirstName";

                }
                if (_IsCampaignGroup)
                {
                    strSelect += ",case when DirectCampaignID is null or DirectCampaignID = 0 then '' else DirectCampaignDesc end as CampaignDesc";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "case when DirectCampaignID is null or DirectCampaignID = 0 then '' else DirectCampaignDesc end ";

                }
                if (_IsCustomerGroup)
                {
                    strSelect += ",case when CustomerID is null or CustomerID = 0 then DirectCustomerName else CustomerFullName end as CustomerName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "case when CustomerID is null or CustomerID = 0 then DirectCustomerName else CustomerFullName end ";
                }

                if (_IsTypeGroup)
                {
                    strSelect += ",ContactType";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ContactType";
                }
                if (_IsPaymentTypeGroup)
                {
                    strSelect += ",PaymentType";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "PaymentType";
                }
                if (_IsWorkGroupGroup)
                {
                    strSelect += ",VisitWorkGroupID,VisitWorkGroupName ";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "VisitWorkGroupID,VisitWorkGroupName";
                }
                if (_IsVisitTypeGroup)
                {
                    strSelect += ",VisitTypeID , VisitTypeNameA, VisitTypeNameE";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "VisitTypeID , VisitTypeNameA, VisitTypeNameE ";
                }
                if (_IsDirectionGroup)
                {
                    strSelect += ",ContactDirection";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ContactDirection";
                }
                if (_IsDayGroup)
                {
                    strSelect += ",Day(ContactDate) as D,Month(ContactDate) as M,Year(ContactDate) as Y";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "Day(ContactDate),Month(ContactDate),Year(ContactDate)";
                }
                else if (_IsMonthGroup)
                {
                    strSelect += ",Month(ContactDate) as M,Year(ContactDate) as Y";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "Month(ContactDate),Year(ContactDate)";
                }
                else if (_IsYearGroup)
                {
                    strSelect += ",Year(ContactDate) as Y";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "Year(ContactDate)";
                }
                if (_IsMsgGroup)
                {
                    strSelect += ",SMSMsg";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "SMSMsg";
                }
                if (_IsProjectGroup)
                {
                    strSelect += ",ProjectName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ProjectName";
                }
                Returned = "select " + strSelect + " from (" + SearchStr + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                //if (strOrder != "")
                //    Returned += " order by  " + strOrder;
                Returned = "select top 20000 * from (" + Returned + ") as NativeCustomerTable ";
                return Returned;
            }
        }

        public string AddStr
        {
            get
            {
                string strNewVisitNo = "";
                string Returned = "";
                double dblDate = _Date.ToOADate() - 2;
                string strDate = dblDate.ToString();
                string strWaitingDate = _WaitingAnotherContact ?
                    SysUtility.Approximate(_AnotherContactDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
                int intWaitingAnotherContact = _WaitingAnotherContact ? 1 : 0;
                string strID = _CampaignCustomerID.ToString();


                string strSql = "";
                //string strID = _ID.ToString();
                string strMonitoringDate = _WaitingMonitor ? "NULL" : (_WaitingMonitoringDate.ToOADate() - 2).ToString();
                if (_CampaignCustomerID == 0)
                {
                    strSql += "insert into CRMCampaignCustomer (Campaign, Customer,Employee,TimIns) " +
                                           "select " + _DirectCampaignID + " as Campaign,CustomerID," + _Employee + " as Employee,GetDate() as TimIns  " +
                                           " FROM         dbo.CRMCustomer where CustomerID =" + _DirectCustomerID +
                                           " and not exists (SELECT     CampaignCustomerID " +
                                           " FROM         dbo.CRMCampaignCustomer " +
                                           " WHERE     (Campaign = " + _DirectCampaignID +
                                           ") AND (Customer = " + _DirectCustomerID + ")) " +
                                           " declare @ID int " +
                                           " set @ID = (SELECT     CampaignCustomerID " +
                                           " FROM         dbo.CRMCampaignCustomer " +
                                           " WHERE     (Campaign = " + _DirectCampaignID +
                                           ") AND (Customer = " + _DirectCustomerID + ")) ";
                    strID = "@ID";
                }
                int intDirection = _Direction ? 1 : 0;
                strSql += "insert into  dbo.CRMCampaignCustomerContact (CampaignCustomerID,ContactDirection , ContactDate , " +
                    "ContactType, ContactComment, ContactStatus, ContactFunctionalStatus," +
                    " ContactWaitingAnotherContact, ContactWaitingDate, ContactEmployee" +
                    ",ContactWaitingMonitoringDate,ContactLastMonitoringID" +
                    ",ContactBranch,ContactDirectCustomer, ContactCampaign, ContactTopic,ContactReservation,ContactProject,ContactTicket) " +
                    " values (" + strID + "," + intDirection + "," + dblDate + "," + _Type + ",'" + _Comment + "'," +
                    _Status + "," + _FunctionalStatus + "," + intWaitingAnotherContact + "," + strWaitingDate +
                    "," + _Employee + "," + strMonitoringDate + "," + _LastMonitoringID + "," + _Branch + "," + _DirectCustomerID + "," +
                    _DirectCampaignID + "," + _TopicID + "," + _Reservation + "," + _Project + "," + _Ticket + ")  ";
                strSql += " declare @ContactID int ;" +
                    " set @ContactID = (select @@IDENTITY as NewContactID) ";
                strSql += " update CRMCampaignCustomer set WaitingContactDate = null " +
                    ",LastContactID=@@Identity " +
                         ",LastSucceededContactID = case when " + _Status + "= 1 then  @@Identity else LastSucceededContactID end " +
                    " where CampaignCustomerID = " + strID;
                if (_WaitingMonitor)
                {

                    strSql += " update CRMCampaignCustomer set WaitingMonitoringDate=" + strMonitoringDate + " where CampaignCustomerID =" + strID;
                    strSql += " insert into CRMCampaignCustomer_IWaitingMonitoringDate (CampaignCustomerID, WaitingMonitoringDate) " +
                        " values (" + strID + "," + strMonitoringDate + ") ";
                }
                strSql += "  ";
                if (_ReceptionStatus == 1)
                {
                    string strReceptionTime = (_Date.ToOADate() - 1).ToString();
                    string strPickTime = _IsPicked ? (_ReceptionPickTime.ToOADate() - 2).ToString() : "NULL";
                    string strDepartureTime = _IsDeparted ? (_DepartureTime.ToOADate() - 2).ToString() : "NULL";
                    string strReception = " insert into CRMCampaignCustomerContactReception " +
                        "(CampaignContactID,CampaignContactVisitType, CampaignContactReceptionist, CampaignContactReceptionTime" +
                        ", CampaignContactReceptionPickTime, CampaignContactDepartureTime, CampaignContactReceptionGroup,  " +
                        " CampaignContactReceptionProcessed,CampaignContactReceptionCustomerName, CampaignContactReceptionCustomerPhone) " +
                        " values (@ContactID," + _VisitType + "," + _ReceptionistID + "," + strReceptionTime + "," + strPickTime + "," +
                            strDepartureTime + "," + _WorkGroup + ",0,'" + _COntactCustomerName + "','" + _ContactCustomerPhone + "')";

                    if (_WorkGroup != 0 && _Branch != 0)
                    {
                        string strMaxVisitNo = @"SELECT   dbo.HRWorkGroup.WorkGroupID
,(case when LastVisitTable.MaxVisitNo is null then  dbo.HRWorkGroup.WorkGroupRangeStart - 1 else LastVisitTable.MaxVisitNo end )   + 1 AS MaxVisitNo
FROM            dbo.HRWorkGroup 
LEFT OUTER JOIN 
(
SELECT   MAX(dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionVisitNo) AS MaxVisitNo, dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup, 
                                                         dbo.CRMCampaignCustomerContact.ContactBranch
                                FROM            dbo.CRMCampaignCustomerContact_IDate INNER JOIN
                                                         dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact_IDate.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID 
 INNER JOIN  dbo.CRMCampaignCustomerContact 
 ON dbo.CRMCampaignCustomerContact_IDate.CampaignContactID = dbo.CRMCampaignCustomerContact.CampaignContactID
                                WHERE   (dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionVisitNo>0)  and    (dbo.CRMCampaignCustomerContact_IDate.ContactDate BETWEEN dbo.GetApproximateDate(GETDATE()) AND dbo.GetApproximateDate(DATEADD(day, 1, GETDATE())))
                                GROUP BY dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup, dbo.CRMCampaignCustomerContact.ContactBranch
                                HAVING        (dbo.CRMCampaignCustomerContact.ContactBranch = " + _Branch + @") 
 and dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup=" + _WorkGroup + @"
)
AS LastVisitTable 
ON dbo.HRWorkGroup.WorkGroupID = LastVisitTable.CampaignContactReceptionGroup
WHERE        (dbo.HRWorkGroup.WorkGroupRangeStart > 0) AND (dbo.HRWorkGroup.WorkGroupRangeEnd > 0) AND (dbo.HRWorkGroup.WorkGroupID = " + _WorkGroup + @")";
                        strReception += @"
update             dbo.CRMCampaignCustomerContactReception 
set CampaignContactReceptionVisitNo = VisitnoTable.MaxVisitNo
 from CRMCampaignCustomerContactReception
 inner join 
(
" + strMaxVisitNo + @"

 ) as VisitnoTable
 on  dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup = VisitnoTable.WorkGroupID 
WHERE        (CampaignContactID = @ContactID)";

                    }
                    strSql += strReception;
                }
                //strSql += " select @ContactID as Exp";
                strSql += @" SELECT dbo.CRMCampaignCustomerContact.CampaignContactID, dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionVisitNo
FROM            dbo.CRMCampaignCustomerContact LEFT OUTER JOIN
                         dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID
WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID = @ContactID)";
                return strSql;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                double dblDate = _Date.ToOADate() - 2;
                string strDate = dblDate.ToString();
                string strWaitingDate = _WaitingAnotherContact ?
                    SysUtility.Approximate(_AnotherContactDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
                int intWaitingAnotherContact = _WaitingAnotherContact ? 1 : 0;
                string strID = _CampaignCustomerID.ToString();
                string strMonitoringDate = SysUtility.Approximate((_WaitingMonitoringDate.ToOADate() - 2), 1, ApproximateType.Down).ToString();

                string strSql = "";
                //string strID = _ID.ToString();

                if (_CampaignCustomerID == 0)
                {
                    strSql += "insert into CRMCampaignCustomer (Campaign, Customer,Employee,TimIns) " +
                                           "select " + _DirectCampaignID + " as Campaign,CustomerID," + _Employee + " as Employee,GetDate() as TimIns  " +
                                           " FROM         dbo.CRMCustomer where CustomerID =" + _DirectCustomerID +
                                           " and not exists (SELECT     CampaignCustomerID " +
                                           " FROM         dbo.CRMCampaignCustomer " +
                                           " WHERE     (Campaign = " + _DirectCampaignID +
                                           ") AND (Customer = " + _DirectCustomerID + ")) " +
                                           " declare @ID int " +
                                           " set @ID = (SELECT     CampaignCustomerID " +
                                           " FROM         dbo.CRMCampaignCustomer " +
                                           " WHERE     (Campaign = " + _DirectCampaignID +
                                           ") AND (Customer = " + _DirectCustomerID + ")) ";
                    strID = "@ID";
                }
                int intDirection = _Direction ? 1 : 0;
                strSql += " update   dbo.CRMCampaignCustomerContact set CampaignCustomerID = " + strID +
                    ",ContactDirection=" + intDirection +
                    " , ContactDate=" + dblDate +
                    " , ContactType=" + _Type +
                    ", ContactComment='" + _Comment + "'" +
                    ", ContactStatus=" + _Status +
                    ", ContactFunctionalStatus=" + _FunctionalStatus +
                    ",ContactWaitingAnotherContact=" + intWaitingAnotherContact +
                    ", ContactWaitingDate=" + strWaitingDate +
                    ", ContactEmployee=" + _Employee +
                    ",ContactWaitingMonitoringDate=" + strMonitoringDate +
                    ",ContactLastMonitoringID=" + _LastMonitoringID +
                     ",ContactBranch=" + _Branch +
                    // ",ContactDirectCustomer=" + _DirectCustomerID +
                    ", ContactCampaign=" + _DirectCampaignID +
                    ", ContactTopic= " + _TopicID +
                    ",ContactReservation=" + _Reservation +
                    ",ContactTicket=" + _Ticket +
                    ",ContactProject=" + _Project +
                    " where CampaignContactID =" + _ID;

                //strSql += " declare @ContactID int ;" +
                //    " set @ContactID = (select @@IDENTITY as NewContactID) ";
                strSql += " update CRMCampaignCustomer set WaitingContactDate = null " +
                    ",LastContactID= " + _ID +
                         ",LastSucceededContactID = case when " + _Status + "= 1 then  " + _ID +
                         " else LastSucceededContactID end " +
                    " where CampaignCustomerID = " + strID;
                if (_WaitingMonitor)
                {

                    strSql += " update CRMCampaignCustomer set WaitingMonitoringDate=" + strMonitoringDate + " where CampaignCustomerID =" + strID;
                    strSql += " insert into CRMCampaignCustomer_IWaitingMonitoringDate (CampaignCustomerID, WaitingMonitoringDate) " +
                         " values (" + strID + "," + strMonitoringDate + ") ";
                }
                strSql += "  ";
                if (_ReceptionStatus == 1)
                {
                    string strReceptionTime = (_Date.ToOADate() - 1).ToString();
                    string strPickTime = _IsPicked ? (_ReceptionPickTime.ToOADate() - 2).ToString() : "NULL";
                    string strDepartureTime = _IsDeparted ? (_DepartureTime.ToOADate() - 2).ToString() : "NULL";
                    string strEntryTime = _IsEntered ? (_EntryTime.ToOADate() - 2).ToString() : "NULL";
                    string strCancelTime = _IsCanceled ? (_CancelTime.ToOADate() - 2).ToString() : "NULL";

                    string strReception = " insert into CRMCampaignCustomerContactReception (CampaignContactID)  " +
                        " select  " + _ID + " as ContactID " +
                        "where not exists (SELECT        CampaignContactID " +
                                " FROM            dbo.CRMCampaignCustomerContactReception " +
                                " WHERE        (CampaignContactID = " + _ID + ")) ";

                    strReception += " update CRMCampaignCustomerContactReception " +
                        "  set CampaignContactVisitType = " + _VisitType +
                        // ",CampaignContactReceptionist=" + _ReceptionistID +
                        ", CampaignContactReceptionTime=" + strReceptionTime +
                         ", CampaignContactReceptionPickTime=" + strPickTime +
                         ",CampaignContactEntryTime=" + strEntryTime +
                         ", CampaignContactDepartureTime=" + strDepartureTime +
                         ",CampaignContactCancelTime=" + strCancelTime +
                         ", CampaignContactReceptionGroup=" + _WorkGroup +
                         ",CampaignContactReceptionCustomerName='" + _COntactCustomerName + "'" +
                         ", CampaignContactReceptionCustomerPhone ='" + _ContactCustomerPhone + "'" +
                         " where    (CampaignContactID = " + _ID + ")  ";
                    #region 
                    //                    if (_WorkGroup != 0 && _Branch != 0)
                    //                        strReception += @" 
                    //update             dbo.CRMCampaignCustomerContactReception  set CampaignContactReceptionVisitNo = (SELECT        ISNULL(derivedtbl_1.MaxVisitNo, dbo.HRWorkGroup.WorkGroupRangeStart - 1) + 1 AS MaxVisitNo
                    //FROM            dbo.HRWorkGroup LEFT OUTER JOIN
                    //                             (SELECT       top 1 MAX(dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionVisitNo) AS MaxVisitNo, dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup, 
                    //                                                         dbo.CRMCampaignCustomerContact.ContactBranch
                    //                                FROM            dbo.CRMCampaignCustomerContact_IDate INNER JOIN
                    //                                                         dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact_IDate.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID INNER JOIN
                    //                                                         dbo.CRMCampaignCustomerContact ON dbo.CRMCampaignCustomerContact_IDate.CampaignContactID = dbo.CRMCampaignCustomerContact.CampaignContactID
                    //                                WHERE        (dbo.CRMCampaignCustomerContact_IDate.ContactDate BETWEEN dbo.GetApproximateDate(GETDATE()) AND dbo.GetApproximateDate(DATEADD(day, 1, GETDATE())))
                    //                                GROUP BY dbo.CRMCampaignCustomerContactReception.CampaignContactReceptionGroup, dbo.CRMCampaignCustomerContact.ContactBranch
                    //                                HAVING        (dbo.CRMCampaignCustomerContact.ContactBranch = " + _Branch + @")) AS derivedtbl_1 ON dbo.HRWorkGroup.WorkGroupID = derivedtbl_1.CampaignContactReceptionGroup
                    //WHERE        (dbo.HRWorkGroup.WorkGroupRangeStart > 0) AND (dbo.HRWorkGroup.WorkGroupRangeEnd > 0) AND (dbo.HRWorkGroup.WorkGroupID = " + _WorkGroup + @"))

                    //WHERE        (CampaignContactID = "+_ID +")";
                    #endregion
                    strSql += strReception;
                }

                return strSql;
            }
        }
        public string EditStatusStr
        {
            get
            {
                VisitStatusDb objStatus = new VisitStatusDb();
                objStatus.Date = DateTime.Now;
                objStatus.Desc = StatusComment;
                objStatus.EmployeeID = _StatusEmployee;
                objStatus.Status = _Status;
                objStatus.FunctionalStatus = _FunctionalStatus;
                objStatus.VisitID = ID;

                string strStatus = objStatus.AddStr;
                return strStatus;
            }
        }





        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["TotalCount"] != null)
            {
                SetSumData(objDr);
                return;
            }
            if (objDr.Table.Columns["CampaignContactID"] != null &&
                objDr["CampaignContactID"].ToString() != "")
                _ID = int.Parse(objDr["CampaignContactID"].ToString());
            if (objDr.Table.Columns["CampaignCustomerID"] != null &&
                objDr["CampaignCustomerID"].ToString() != "")
                _CampaignCustomerID = int.Parse(objDr["CampaignCustomerID"].ToString());
            if (objDr.Table.Columns["ContactDirection"] != null &&
                objDr["ContactDirection"].ToString() != "")
                _Direction = bool.Parse(objDr["ContactDirection"].ToString());
            if (objDr.Table.Columns["ContactDate"] != null &&
                objDr["ContactDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["ContactDate"].ToString());
            if (objDr.Table.Columns["ContactType"] != null &&
                objDr["ContactType"].ToString() != "")
                _Type = int.Parse(objDr["ContactType"].ToString());
            if (objDr.Table.Columns["ContactComment"] != null &&
                objDr["ContactComment"].ToString() != "")
                _Comment = objDr["ContactComment"].ToString();
            if (objDr.Table.Columns["ContactStatus"] != null &&
                objDr["ContactStatus"].ToString() != "")
                _Status = int.Parse(objDr["ContactStatus"].ToString());
            if (objDr.Table.Columns["VisitStatus"] != null && objDr["VisitStatus"].ToString() != "")
                _Status = int.Parse(objDr["VisitStatus"].ToString());
            if (objDr.Table.Columns["ContactFunctionalStatus"] != null &&
                objDr["ContactFunctionalStatus"].ToString() != "")
                _FunctionalStatus = int.Parse(objDr["ContactFunctionalStatus"].ToString());
            if (objDr.Table.Columns["ContactWaitingAnotherContact"] != null &&
                objDr["ContactWaitingAnotherContact"].ToString() != "")
                _WaitingAnotherContact = bool.Parse(objDr["ContactWaitingAnotherContact"].ToString());
            if (_WaitingAnotherContact && objDr.Table.Columns["ContactWaitingDate"] != null &&
                objDr["ContactWaitingDate"].ToString() != "")
                _WaitingDate = DateTime.Parse(objDr["ContactWaitingDate"].ToString());
            if (objDr.Table.Columns["ContactEmployee"] != null && objDr["ContactEmployee"].ToString() != "")
                _Employee = int.Parse(objDr["ContactEmployee"].ToString());
            if (objDr.Table.Columns["CampaignID"] != null && objDr["CampaignID"].ToString() != "")
            {
                _CampaignID = int.Parse(objDr["CampaignID"].ToString());

            }
            if (objDr.Table.Columns["CampaignDate"] != null && objDr["CampaignDate"].ToString() != "")
                _CampaignDate = DateTime.Parse(objDr["CampaignDate"].ToString());
            if (objDr.Table.Columns["CampaignDesc"] != null)
                _CampaignDesc = objDr["CampaignDesc"].ToString();

            if (objDr.Table.Columns["CustomerID"] != null && objDr["CustomerID"].ToString() != "")
            {
                _CustomerID = int.Parse(objDr["CustomerID"].ToString());

            }
            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerName = objDr["CustomerFullName"].ToString();
            if (objDr.Table.Columns["DirectCustomerID"] != null &&
                objDr["DirectCustomerID"].ToString() != "")
            {
                _DirectCustomerID = int.Parse(objDr["DirectCustomerID"].ToString());

            }
            if (objDr.Table.Columns["DirectCustomerName"] != null)
                _DirectCustomerName = objDr["DirectCustomerName"].ToString();

            if (objDr.Table.Columns["DirectCampaignID"] != null &&
                objDr["DirectCampaignID"].ToString() != "")
            {
                _DirectCampaignID = int.Parse(objDr["DirectCampaignID"].ToString());

            }
            if (objDr.Table.Columns["DirectCampaignDesc"] != null)
                _DirectCampaignDesc = objDr["DirectCampaignDesc"].ToString();
            if (objDr.Table.Columns["DirectCampaignDate"] != null && objDr["DirectCampaignDate"].ToString() != "")
                _DirectCmpaignDate = DateTime.Parse(objDr["DirectCampaignDate"].ToString());
            if (objDr.Table.Columns["DirectCampaignTopicID"] != null &&
                objDr["DirectCampaignTopicID"].ToString() != "")
                _DirectCampaignTopicID = int.Parse(objDr["DirectCampaignTopicID"].ToString());
            if (objDr.Table.Columns["DirectCampaignTopicName"] != null)
                _DirectCampaignTopicName = objDr["DirectCampaignTopicName"].ToString();
            if (objDr.Table.Columns["SMSID"] != null &&
                objDr["SMSID"].ToString() != "")
            {
                _SMSMsgID = int.Parse(objDr["SMSID"].ToString());

            }
            if (objDr.Table.Columns["SMSMsg"] != null)
                _SMSMsg = objDr["SMSMsg"].ToString();
            //  _Branch = int.Parse(objDr["ContactBranch"].ToString());
            if (objDr.Table.Columns["DirectCustomerUnitName"] != null)
                _DirectCustomerUnitName = objDr["DirectCustomerUnitName"].ToString();
            if (objDr.Table.Columns["DirectCustomerProjectName"] != null)
                _DirectCustomerProjectName = objDr["DirectCustomerProjectName"].ToString();
            if (objDr.Table.Columns["DirectCustomerTowerName"] != null)
                _DirectCustomerTowerName = objDr["DirectCustomerTowerName"].ToString();

            if (objDr.Table.Columns["DirectCustomerAddress"] != null)
                _DirectCustomerAddress = objDr["DirectCustomerAddress"].ToString();
            if (objDr.Table.Columns["DirectCustomerPhone"] != null)
                _DirectCustomerPhone = objDr["DirectCustomerPhone"].ToString();
            if (objDr.Table.Columns["DirectCustomerMobile"] != null)
                _DirectCustomerMobile = objDr["DirectCustomerMobile"].ToString();

            //int _ReceptionStatus;
            //int _ReceptionProcessedStatus;
            if (objDr.Table.Columns["CampaignContactReceptionID"] != null &&
                objDr["CampaignContactReceptionID"].ToString() != "")
                _IsReception = true;
            if (objDr.Table.Columns["CampaignContactReceptionist"] != null &&
                objDr["CampaignContactReceptionist"].ToString() != "")
                _ReceptionistID = int.Parse(objDr["CampaignContactReceptionist"].ToString());
            if (objDr.Table.Columns["CampaignContactReceptionistName"] != null)
                _ReceptionistName = objDr["CampaignContactReceptionistName"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionTime"] != null &&
                objDr["CampaignContactReceptionTime"].ToString() != "")
                _ReceptionDate = DateTime.Parse(objDr["CampaignContactReceptionTime"].ToString());
            if (objDr.Table.Columns["CampaignContactReceptionProcessed"] != null &&
                objDr["CampaignContactReceptionProcessed"].ToString() != "")
                _ReceptionProcessed = bool.Parse(objDr["CampaignContactReceptionProcessed"].ToString());
            if (objDr.Table.Columns["CampaignContactReceptionPickTime"] != null)
                _IsPicked = DateTime.TryParse(objDr["CampaignContactReceptionPickTime"].ToString(), out _ReceptionPickTime);
            if (objDr.Table.Columns["CampaignContactDepartureTime"] != null)
                _IsDeparted = DateTime.TryParse(objDr["CampaignContactDepartureTime"].ToString(), out _DepartureTime);
            if (objDr.Table.Columns["VisitWorkGroupID"] != null)
                int.TryParse(objDr["VisitWorkGroupID"].ToString(), out _WorkGroup);
            if (objDr.Table.Columns["VisitWorkGroupName"] != null)
                _WorkGroupName = objDr["VisitWorkGroupName"].ToString();
            if (objDr.Table.Columns["VisitReservationID"] != null)
                int.TryParse(objDr["VisitReservationID"].ToString(), out _Reservation);
            if (objDr.Table.Columns["VisitRservationUnit"] != null)
                _ReservationUnitName = objDr["VisitRservationUnit"].ToString();
            if (objDr.Table.Columns["VisitReservationCustomerName"] != null)
                _ReservationCustomerName = objDr["VisitReservationCustomerName"].ToString();
            if (objDr.Table.Columns["BranchID"] != null)
                int.TryParse(objDr["BranchID"].ToString(), out _Branch);
            if (objDr.Table.Columns["BranchName"] != null)
                _BranchName = objDr["BranchName"].ToString();
            if (objDr.Table.Columns["CampaignContactEntryTime"] != null)
                _IsEntered = DateTime.TryParse(objDr["CampaignContactEntryTime"].ToString(), out _EntryTime);
            if (objDr.Table.Columns["CampaignContactCancelTime"] != null)
                _IsCanceled = DateTime.TryParse(objDr["CampaignContactCancelTime"].ToString(), out _CancelTime);
            if (objDr.Table.Columns["ContactTicketID"] != null)
                int.TryParse(objDr["ContactTicketID"].ToString(), out _Ticket);
            if (objDr.Table.Columns["ContactTicketEmployee1"] != null)
                _TicketEmployeeName = objDr["ContactTicketEmployee1"].ToString();
            if (objDr.Table.Columns["ContactTicketWorkGroupName"] != null)
                _TicketWorkGroupName = objDr["ContactTicketWorkGroupName"].ToString();
            if (objDr.Table.Columns["ContactTicketStatus"] != null)
                int.TryParse(objDr["ContactTicketStatus"].ToString(), out _TicketStatus);
            if (objDr.Table.Columns["ContactTicketPostponementDate"] != null)
                _TicketIsPostponed = DateTime.TryParse(objDr["ContactTicketPostponementDate"].ToString(), out _TicketPostponementDate);
            if (objDr.Table.Columns["VisitTypeID"] != null)
                int.TryParse(objDr["VisitTypeID"].ToString(), out _VisitType);
            if (objDr.Table.Columns["WaitingMonitoringDate"] != null)
                _WaitingMonitor = DateTime.TryParse(objDr["WaitingMonitoringDate"].ToString(), out _WaitingMonitoringDate);
            if (objDr.Table.Columns["LastMonitoringID"] != null)
                int.TryParse(objDr["LastMonitoringID"].ToString(), out _LastMonitoringID);
            if (objDr.Table.Columns["LastMonitoringDate"] != null)
                DateTime.TryParse(objDr["LastMonitoringDate"].ToString(), out _LastMonitoringDate);

            if (objDr.Table.Columns["LastMonitoringDesc"] != null)
                _LastMonitoringDesc = objDr["LastMonitoringDesc"].ToString();

            if (objDr.Table.Columns["LastMonitoringStatus"] != null)
                int.TryParse(objDr["LastMonitoringStatus"].ToString(), out _LastMonitoringStatus);
            if (objDr.Table.Columns["LastMonitoringEmployee"] != null)
                int.TryParse(objDr["LastMonitoringEmployee"].ToString(), out _LastMonitoringEmployee);
            if (objDr.Table.Columns["LastMonitoringEmolyeeName"] != null)
            {
                try
                {
                    _LastMonitoringEmolyeeName = objDr["LastMonitoringEmolyeeName"].ToString();
                }
                catch (Exception objEx)
                {
                    string strEx = objEx.Message;
                }
            }
            if (objDr.Table.Columns["ProjectID"] != null)
                int.TryParse(objDr["ProjectID"].ToString(), out _Project);
            if (objDr.Table.Columns["ProjectName"] != null)
                _ProjectName = objDr["ProjectName"].ToString();
            if (objDr.Table.Columns["ContactTicketEmployeeID"] != null)
                int.TryParse(objDr["ContactTicketEmployeeID"].ToString(), out _TicketEmployee);
            if (objDr.Table.Columns["ContactTicketWorkGroupID"] != null)
                int.TryParse(objDr["ContactTicketWorkGroupID"].ToString(), out _TicketWorkGroup);
            if (objDr.Table.Columns["TicketDesc"] != null)
                _TicketDesc = objDr["TicketDesc"].ToString();
            if (objDr.Table.Columns["TicketType"] != null)
                int.TryParse(objDr["TicketType"].ToString(), out _TicketType);
            if (objDr.Table.Columns["TicketTypeNameA"] != null)
                _TicketTypeName = objDr["TicketTypeNameA"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionCustomerName"] != null)
                _COntactCustomerName = objDr["CampaignContactReceptionCustomerName"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionCustomerPhone"] != null)
                _ContactCustomerPhone = objDr["CampaignContactReceptionCustomerPhone"].ToString();
            if (objDr.Table.Columns["TotalPaidValue"] != null)
                double.TryParse(objDr["TotalPaidValue"].ToString(), out _TotalPaid);
            if (objDr.Table.Columns["PaymentType"] != null)
                _PaymentType = objDr["PaymentType"].ToString();


            if (objDr.Table.Columns["CampaignContactReceptionWindowNo"] != null)
                int.TryParse(objDr["CampaignContactReceptionWindowNo"].ToString(), out _WindowNo);

            if (objDr.Table.Columns["CampaignContactReceptionVisitNo"] != null)
                int.TryParse(objDr["CampaignContactReceptionVisitNo"].ToString(), out _VisitNo);

            if (objDr.Table.Columns["CampaignContactReceptionBroadCastTime"] != null)
            {

                _IsBroadCasted = DateTime.TryParse(objDr["CampaignContactReceptionBroadCastTime"].ToString(), out _BroadCastTime);

            }

        }
        void SetDataOld(DataRow objDr)
        {
            if (objDr.Table.Columns["TotalCount"] != null)
            {
                SetSumData(objDr);
                return;
            }
            if (objDr.Table.Columns["CampaignContactID"] != null && objDr["CampaignContactID"].ToString() != "")
                _ID = int.Parse(objDr["CampaignContactID"].ToString());
            if (objDr.Table.Columns["CampaignCustomerID"] != null && objDr["CampaignCustomerID"].ToString() != "")
                _CampaignCustomerID = int.Parse(objDr["CampaignCustomerID"].ToString());
            if (objDr.Table.Columns["ContactDirection"] != null && objDr["ContactDirection"].ToString() != "")
                _Direction = bool.Parse(objDr["ContactDirection"].ToString());
            if (objDr.Table.Columns["ContactDate"] != null && objDr["ContactDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["ContactDate"].ToString());
            if (objDr.Table.Columns["ContactType"] != null && objDr["ContactType"].ToString() != "")
                _Type = int.Parse(objDr["ContactType"].ToString());
            if (objDr.Table.Columns["ContactComment"] != null && objDr["ContactComment"].ToString() != "")
                _Comment = objDr["ContactComment"].ToString();
            if (objDr.Table.Columns["ContactStatus"] != null && objDr["ContactStatus"].ToString() != "")
                _Status = int.Parse(objDr["ContactStatus"].ToString());
            if (objDr.Table.Columns["VisitStatus"] != null && objDr["VisitStatus"].ToString() != "")
                _Status = int.Parse(objDr["VisitStatus"].ToString());
            if (objDr.Table.Columns["ContactFunctionalStatus"] != null && objDr["ContactFunctionalStatus"].ToString() != "")
                _FunctionalStatus = int.Parse(objDr["ContactFunctionalStatus"].ToString());
            if (objDr.Table.Columns["ContactWaitingAnotherContact"] != null && objDr["ContactWaitingAnotherContact"].ToString() != "")
                _WaitingAnotherContact = bool.Parse(objDr["ContactWaitingAnotherContact"].ToString());
            if (_WaitingAnotherContact && objDr.Table.Columns["ContactWaitingDate"] != null && objDr["ContactWaitingDate"].ToString() != "")
                _WaitingDate = DateTime.Parse(objDr["ContactWaitingDate"].ToString());
            if (objDr.Table.Columns["ContactEmployee"] != null && objDr["ContactEmployee"].ToString() != "")
                _Employee = int.Parse(objDr["ContactEmployee"].ToString());
            if (objDr.Table.Columns["CampaignID"] != null && objDr["CampaignID"].ToString() != "")
            {
                _CampaignID = int.Parse(objDr["CampaignID"].ToString());

            }
            if (objDr.Table.Columns["CampaignDate"] != null && objDr["CampaignDate"].ToString() != "")
                _CampaignDate = DateTime.Parse(objDr["CampaignDate"].ToString());
            if (objDr.Table.Columns["CampaignDesc"] != null)
                _CampaignDesc = objDr["CampaignDesc"].ToString();

            if (objDr.Table.Columns["CustomerID"] != null && objDr["CustomerID"].ToString() != "")
            {
                _CustomerID = int.Parse(objDr["CustomerID"].ToString());

            }
            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerName = objDr["CustomerFullName"].ToString();
            if (objDr.Table.Columns["DirectCustomerID"] != null && objDr["DirectCustomerID"].ToString() != "")
            {
                _DirectCustomerID = int.Parse(objDr["DirectCustomerID"].ToString());

            }
            if (objDr.Table.Columns["DirectCustomerName"] != null)
                _DirectCustomerName = objDr["DirectCustomerName"].ToString();

            if (objDr.Table.Columns["DirectCampaignID"] != null && objDr["DirectCampaignID"].ToString() != "")
            {
                _DirectCampaignID = int.Parse(objDr["DirectCampaignID"].ToString());

            }
            if (objDr.Table.Columns["DirectCampaignDesc"] != null)
                _DirectCampaignDesc = objDr["DirectCampaignDesc"].ToString();
            if (objDr.Table.Columns["DirectCampaignDate"] != null && objDr["DirectCampaignDate"].ToString() != "")
                _DirectCmpaignDate = DateTime.Parse(objDr["DirectCampaignDate"].ToString());
            if (objDr.Table.Columns["DirectCampaignTopicID"] != null && objDr["DirectCampaignTopicID"].ToString() != "")
                _DirectCampaignTopicID = int.Parse(objDr["DirectCampaignTopicID"].ToString());
            if (objDr.Table.Columns["DirectCampaignTopicName"] != null)
                _DirectCampaignTopicName = objDr["DirectCampaignTopicName"].ToString();
            if (objDr.Table.Columns["SMSID"] != null && objDr["SMSID"].ToString() != "")
            {
                _SMSMsgID = int.Parse(objDr["SMSID"].ToString());

            }
            if (objDr.Table.Columns["SMSMsg"] != null)
                _SMSMsg = objDr["SMSMsg"].ToString();
            //  _Branch = int.Parse(objDr["ContactBranch"].ToString());
            if (objDr.Table.Columns["DirectCustomerUnitName"] != null)
                _DirectCustomerUnitName = objDr["DirectCustomerUnitName"].ToString();
            if (objDr.Table.Columns["DirectCustomerProjectName"] != null)
                _DirectCustomerProjectName = objDr["DirectCustomerProjectName"].ToString();
            if (objDr.Table.Columns["DirectCustomerTowerName"] != null)
                _DirectCustomerTowerName = objDr["DirectCustomerTowerName"].ToString();

            if (objDr.Table.Columns["DirectCustomerAddress"] != null)
                _DirectCustomerAddress = objDr["DirectCustomerAddress"].ToString();
            if (objDr.Table.Columns["DirectCustomerPhone"] != null)
                _DirectCustomerPhone = objDr["DirectCustomerPhone"].ToString();
            if (objDr.Table.Columns["DirectCustomerMobile"] != null)
                _DirectCustomerMobile = objDr["DirectCustomerMobile"].ToString();

            //int _ReceptionStatus;
            //int _ReceptionProcessedStatus;
            if (objDr.Table.Columns["CampaignContactReceptionID"] != null && objDr["CampaignContactReceptionID"].ToString() != "")
                _IsReception = true;
            if (objDr.Table.Columns["CampaignContactReceptionist"] != null && objDr["CampaignContactReceptionist"].ToString() != "")
                _ReceptionistID = int.Parse(objDr["CampaignContactReceptionist"].ToString());
            if (objDr.Table.Columns["CampaignContactReceptionistName"] != null)
                _ReceptionistName = objDr["CampaignContactReceptionistName"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionTime"] != null && objDr["CampaignContactReceptionTime"].ToString() != "")
                _ReceptionDate = DateTime.Parse(objDr["CampaignContactReceptionTime"].ToString());
            if (objDr.Table.Columns["CampaignContactReceptionProcessed"] != null && objDr["CampaignContactReceptionProcessed"].ToString() != "")
                _ReceptionProcessed = bool.Parse(objDr["CampaignContactReceptionProcessed"].ToString());
            _IsPicked = DateTime.TryParse(objDr["CampaignContactReceptionPickTime"].ToString(), out _ReceptionPickTime);
            _IsDeparted = DateTime.TryParse(objDr["CampaignContactDepartureTime"].ToString(), out _DepartureTime);
            int.TryParse(objDr["VisitWorkGroupID"].ToString(), out _WorkGroup);
            _WorkGroupName = objDr["VisitWorkGroupName"].ToString();
            int.TryParse(objDr["VisitReservationID"].ToString(), out _Reservation);
            _ReservationUnitName = objDr["VisitRservationUnit"].ToString();
            _ReservationCustomerName = objDr["VisitReservationCustomerName"].ToString();

            int.TryParse(objDr["BranchID"].ToString(), out _Branch);
            _BranchName = objDr["BranchName"].ToString();
            _IsEntered = DateTime.TryParse(objDr["CampaignContactEntryTime"].ToString(), out _EntryTime);
            _IsCanceled = DateTime.TryParse(objDr["CampaignContactCancelTime"].ToString(), out _CancelTime);
            int.TryParse(objDr["ContactTicketID"].ToString(), out _Ticket);
            _TicketEmployeeName = objDr["ContactTicketEmployee1"].ToString();
            _TicketWorkGroupName = objDr["ContactTicketWorkGroupName"].ToString();
            int.TryParse(objDr["ContactTicketStatus"].ToString(), out _TicketStatus);
            _TicketIsPostponed = DateTime.TryParse(objDr["ContactTicketPostponementDate"].ToString(), out _TicketPostponementDate);

            int.TryParse(objDr["VisitTypeID"].ToString(), out _VisitType);
            _WaitingMonitor = DateTime.TryParse(objDr["WaitingMonitoringDate"].ToString(), out _WaitingMonitoringDate);
            int.TryParse(objDr["LastMonitoringID"].ToString(), out _LastMonitoringID);
            DateTime.TryParse(objDr["LastMonitoringDate"].ToString(), out _LastMonitoringDate);
            _LastMonitoringDesc = objDr["LastMonitoringDesc"].ToString();
            int.TryParse(objDr["LastMonitoringStatus"].ToString(), out _LastMonitoringStatus);
            int.TryParse(objDr["LastMonitoringEmployee"].ToString(), out _LastMonitoringEmployee);
            _LastMonitoringEmolyeeName = objDr["LastMonitoringEmolyeeName"].ToString();
            int.TryParse(objDr["ProjectID"].ToString(), out _Project);
            _ProjectName = objDr["ProjectName"].ToString();
            if (objDr.Table.Columns["ContactTicketEmployeeID"] != null)
                int.TryParse(objDr["ContactTicketEmployeeID"].ToString(), out _TicketEmployee);
            if (objDr.Table.Columns["ContactTicketWorkGroupID"] != null)
                int.TryParse(objDr["ContactTicketWorkGroupID"].ToString(), out _TicketWorkGroup);
            if (objDr.Table.Columns["TicketDesc"] != null)
                _TicketDesc = objDr["TicketDesc"].ToString();
            if (objDr.Table.Columns["TicketType"] != null)
                int.TryParse(objDr["TicketType"].ToString(), out _TicketType);
            if (objDr.Table.Columns["TicketTypeNameA"] != null)
                _TicketTypeName = objDr["TicketTypeNameA"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionCustomerName"] != null)
                _COntactCustomerName = objDr["CampaignContactReceptionCustomerName"].ToString();
            if (objDr.Table.Columns["CampaignContactReceptionCustomerPhone"] != null)
                _ContactCustomerPhone = objDr["CampaignContactReceptionCustomerPhone"].ToString();
            if (objDr.Table.Columns["TotalPaidValue"] != null)
                double.TryParse(objDr["TotalPaidValue"].ToString(), out _TotalPaid);
            if (objDr.Table.Columns["PaymentType"] != null)
                _PaymentType = objDr["PaymentType"].ToString();

            #region Reaction Type
            if (objDr.Table.Columns["ContactReactionTypeID"] != null)
                int.TryParse(objDr["ContactReactionTypeID"].ToString(), out _ReactionTypeID);

            if (objDr.Table.Columns["ContactReactionTypeCode"] != null)
                _ReactionTypeCode = objDr["ContactReactionTypeCode"].ToString();

            if (objDr.Table.Columns["ContactReactionTypeNameA"] != null)
                _ReactionTypeNameA = objDr["ContactReactionTypeNameA"].ToString();

            if (objDr.Table.Columns["ContactReactionTypeNameE"] != null)
                _ReactionTypeNameE = objDr["ContactReactionTypeNameE"].ToString();


            #endregion

        }
        void SetSumData(DataRow objDr)
        {
            if (objDr.Table.Columns["TotalCount"] != null)
                int.TryParse(objDr["TotalCount"].ToString(), out _TotalCount);

            if (objDr.Table.Columns["NotSpecifiedStatusCount"] != null)
                int.TryParse(objDr["NotSpecifiedStatusCount"].ToString(), out _NotSpecifiedStatusCount);

            if (objDr.Table.Columns["DoneStatusCount"] != null)
                int.TryParse(objDr["DoneStatusCount"].ToString(), out _DoneStatusCount);

            if (objDr.Table.Columns["WrongNoStatusCount"] != null)
                int.TryParse(objDr["WrongNoStatusCount"].ToString(), out _WrongNoStatusCount);

            if (objDr.Table.Columns["NoAnswerStatusCount"] != null)
                int.TryParse(objDr["NoAnswerStatusCount"].ToString(), out _NoAnswerStatusCount);

            if (objDr.Table.Columns["NoNumberStatusCount"] != null)
                int.TryParse(objDr["NoNumberStatusCount"].ToString(), out _NoNumberStatusCount);

            if (objDr.Table.Columns["NotSpecifiedFunctionalStatusCount"] != null)
                int.TryParse(objDr["NotSpecifiedFunctionalStatusCount"].ToString(), out _NotSpecifiedFunctionalStatusCount);

            if (objDr.Table.Columns["DoneFunctionalStatusCount"] != null)
                int.TryParse(objDr["DoneFunctionalStatusCount"].ToString(), out _DoneFunctionalStatusCount);

            if (objDr.Table.Columns["RefusedFunctionalStatusCount"] != null)
                int.TryParse(objDr["RefusedFunctionalStatusCount"].ToString(), out _RefusedFunctionalStatusCount);

            if (objDr.Table.Columns["EscalatedFunctionalStatusCount"] != null)
                int.TryParse(objDr["EscalatedFunctionalStatusCount"].ToString(), out _EscalatedFunctionalStatusCount);

            if (objDr.Table.Columns["TotalPaid"] != null)
                double.TryParse(objDr["TotalPaid"].ToString(), out _TotalPaid);

            if (objDr.Table.Columns["ApplicantFirstName"] != null)
                _ApplicantFirstName = objDr["ApplicantFirstName"].ToString();

            if (objDr.Table.Columns["CampaignDesc"] != null)
                _CampaignDesc = objDr["CampaignDesc"].ToString();

            if (objDr.Table.Columns["CustomerName"] != null)
                _CustomerName = objDr["CustomerName"].ToString();

            if (objDr.Table.Columns["ContactType"] != null)
                int.TryParse(objDr["ContactType"].ToString(), out _ContactType);

            if (objDr.Table.Columns["VisitWorkGroupID"] != null)
                int.TryParse(objDr["VisitWorkGroupID"].ToString(), out _WorkGroupID);

            if (objDr.Table.Columns["VisitWorkGroupName"] != null)
                _WorkGroupName = objDr["VisitWorkGroupName"].ToString();

            if (objDr.Table.Columns["VisitTypeID"] != null)
                int.TryParse(objDr["VisitTypeID"].ToString(), out _TypeID);

            if (objDr.Table.Columns["VisitTypeCode"] != null)
                _TypeCode = objDr["VisitTypeCode"].ToString();

            if (objDr.Table.Columns["VisitTypeNameA"] != null)
                _TypeNameA = objDr["VisitTypeNameA"].ToString();

            if (objDr.Table.Columns["VisitTypeNameE"] != null)
                _TypeNameE = objDr["VisitTypeNameE"].ToString();

            if (objDr.Table.Columns["D"] != null)
                int.TryParse(objDr["D"].ToString(), out _D);

            if (objDr.Table.Columns["M"] != null)
                int.TryParse(objDr["M"].ToString(), out _M);

            if (objDr.Table.Columns["Y"] != null)
                int.TryParse(objDr["Y"].ToString(), out _Y);

            if (objDr.Table.Columns["SMSMsg"] != null)
                _SMSMsg = objDr["SMSMsg"].ToString();
            if (objDr.Table.Columns["PaymentType"] != null)
                _PaymentType = objDr["PaymentType"].ToString();
            if (objDr.Table.Columns["ProjectName"] != null)
                _ProjectName = objDr["ProjectName"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
            _StatusUser = SysData.CurrentUser.ID;
            string strsql = AddStr;
            strsql += "  " + EditStatusStr;
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strsql);
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                int.TryParse(objDr["CampaignContactID"].ToString(), out _ID);
                int.TryParse(objDr["CampaignContactReceptionVisitNo"].ToString(), out _VisitNo);
            }
            //object objID = SysData.SharpVisionBaseDb.ReturnScalar(strsql);
            //if (objID != null)
            //    _ID = (int)objID;
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
            _StatusUser = SysData.CurrentUser.ID;
            string strsql = EditStr;
            strsql += " " + EditStatusStr;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strsql);

        }
        public void EditStatus()
        {
            //double dblStatusDate = _Date.ToOADate() - 2;
            VisitStatusDb objStatus = new VisitStatusDb();
            objStatus.Date = DateTime.Now;
            objStatus.Desc = StatusComment;
            objStatus.EmployeeID = _Employee;
            objStatus.Status = _Status;
            objStatus.FunctionalStatus = _FunctionalStatus;
            objStatus.VisitID = ID;

            string strStatus = objStatus.AddStr;


            string strSql = strStatus;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //InsertStatusHistory();
        }

        public void EditTicket()
        {
            string strSql = "update dbo.CRMCampaignCustomerContact " +
                " set ContactTicket=" + _Ticket + " where CampaignContactID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = "";
            if (_LogInWithSearch && _Branch != 0 && _WorkGroup != 0 && (_Employee != 0 || SysData.CurrentUser.EmployeeBiz.ID != 0))
            {
                VisitEmployeeLOGINDb objLogIn = new VisitEmployeeLOGINDb();
                objLogIn.Branch = _Branch;
                objLogIn.WorkGroup = WorkGroup;
                objLogIn.Employee = _Employee == 0 ? SysData.CurrentUser.EmployeeBiz.ID : _Employee;
                objLogIn.IsCurrentDay = true;
                objLogIn.WindowsNo = _WindowNo;
                strSql = objLogIn.AddStr + "  ";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            strSql = SearchStr;
            if (!StopCount)
            {
                if (_MaxID == 0 && _MinID == 0)
                {
                    string strCountSql = "select count(distinct CampaignContactID) as exp from (" + strSql + ")  AS NativeTable ";

                    _ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());


                }
                else
                {
                    if (_MaxID != 0)
                        strSql += " and CampaignContactID > " + _MaxID;
                    else if (_MinID != 0)
                    {
                        strSql += " and CampaignContactID <" + _MinID;
                    }
                }
            }
            strSql = "select distinct top 20000 * from (" + strSql + ") as ContactTable order by CampaignContactID desc";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return dtTemp;

        }
        public DataTable SumSearch()
        {
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(SumSearchStr);
            return dtTemp;
        }
        public void PickUp()
        {
            _Status = (int)ContactStatus.PickedUp;
            string strSql = " update CRMCampaignCustomerContact set ContactEmployee =" + _Employee +
                " where ContactEmployee =  0 and CampaignContactID= " + _ID;
            strSql += " update  dbo.CRMCampaignCustomerContactReception set CampaignContactReceptionPickTime = GetDate(),CampaignContactReceptionWindowNo = " + _WindowNo +
                ",CampaignContactReceptionBroadCastTime=null" +
                " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                  " dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID " +
                  " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID = " + _ID + ") AND (dbo.CRMCampaignCustomerContact.ContactEmployee = " + _Employee + ") ";
            strSql += " declare @PickedCount int;";

            strSql += " set @PickedCount = ( SELECT        COUNT(CampaignContactID) AS Expr1 " +
                       " FROM            dbo.CRMCampaignCustomerContact " +
                        " WHERE        (CampaignContactID = " + _ID + ") AND (ContactEmployee = " + _Employee + ")); " +
                        " select @PickedCount as PickedCount ; if @PickedCount = 0 goto endLine; " + EditStatusStr + ";" +
                        " endLine:";
            object objCount = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objCount.ToString() == "0")
                _Employee = 0;
        }
        public void Enter()
        {
            _Status = (int)ContactStatus.Entered;
            string strSql = " update        dbo.CRMCampaignCustomerContactReception set CampaignContactEntryTime = GetDate() " +
                "" +
                   " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                  " dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID " +
                  " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID = " + _ID + ") AND (dbo.CRMCampaignCustomerContact.ContactEmployee = " + _Employee + ") ";
            strSql += EditStatusStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Depart()
        {
            _Status = (int)ContactStatus.Departed;
            string strSql = " update        dbo.CRMCampaignCustomerContactReception set CampaignContactDepartureTime = GetDate() " +
                   " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                  " dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID " +
                  " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID = " + _ID + ") AND (dbo.CRMCampaignCustomerContact.ContactEmployee = " + _Employee + ") ";
            strSql += EditStatusStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Cancel()
        {
            _Status = (int)ContactStatus.Canceled;
            string strSql = " update        dbo.CRMCampaignCustomerContactReception set CampaignContactCancelTime = GetDate() " +
                   " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                  " dbo.CRMCampaignCustomerContactReception ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContactReception.CampaignContactID " +
                  " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID = " + _ID + ") AND (dbo.CRMCampaignCustomerContact.ContactEmployee = " + _Employee + ") ";
            strSql += " update  dbo.CRMCampaignCustomerContact set ContactEmployee = 0 " +
                    " WHERE        (CampaignContactID = " + _ID + ") " +
                    "  AND (dbo.CRMCampaignCustomerContact.ContactEmployee = " + _Employee + ") ";
            strSql += EditStatusStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void MonitorCol()
        {
            if (_IDs == null || _IDs == "")
                return;
            string strTemp = " SELECT        CampaignCustomerID " +
                   " FROM            dbo.CRMCampaignCustomerContact " +
                   " WHERE        (CampaignContactID IN (" + _IDs + "))";

            string strWaitingDate = _WaitingMonitor ? SysUtility.Approximate((_WaitingMonitoringDate.ToOADate() - 2), 1, ApproximateType.Down).ToString() : "null";
            string strSql = "select distinct CampaignCustomerID as MonitoringCampaignCustomer,GetDate() as MonitoringDate,'" + _MonitoringDesc + "' as MonitoringDesc," + _MonitoringStatus +
                " as MonitoringStatus, " + strWaitingDate + " as MonitoringWaitingDate," + _Employee + " as MonitoringEmployee, " + SysData.CurrentUser.ID + " as UsrIns " +
                ",GetDate() as TimIns " +
                " from (" + strTemp + ") as NativeTable  ";
            strSql = "insert into CRMCampaignCustomerMonitor ( MonitoringCampaignCustomer, MonitoringDate, MonitoringDesc, MonitoringStatus," +
                " MonitoringWaitingDate, MonitoringEmployee, UsrIns, TimIns) " +
                "" + strSql;
            string strMaxMonitor = "SELECT   MonitoringCampaignCustomer, MAX(MonitoringID) AS MaxMonitorID " +
                   " FROM         dbo.CRMCampaignCustomerMonitor " +
                   " GROUP BY MonitoringCampaignCustomer ";



            strSql += " update      dbo.CRMCampaignCustomer set LastMonitoringID = MonitorTable.MaxMonitorID" +
                ",WaitingMonitoringDate =" + strWaitingDate +
                     "FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                     " (" + strMaxMonitor + ") AS MonitorTable ON dbo.CRMCampaignCustomerContact.CampaignCustomerID = MonitorTable.MonitoringCampaignCustomer INNER JOIN " +
                       " dbo.CRMCampaignCustomer ON dbo.CRMCampaignCustomerContact.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID AND  " +
                       " dbo.CRMCampaignCustomerContact.ContactWaitingMonitoringDate = dbo.CRMCampaignCustomer.WaitingMonitoringDate " +
                       " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID IN (" + _IDs + "))";
            strSql += " update      dbo.CRMCampaignCustomerContact set ContactLastMonitoringID= MonitorTable.MaxMonitorID" +
                ", ContactWaitingMonitoringDate= " + strWaitingDate +
             " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
             " (" + strMaxMonitor + ") AS MonitorTable ON dbo.CRMCampaignCustomerContact.CampaignCustomerID = MonitorTable.MonitoringCampaignCustomer " +
             " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID IN (" + _IDs + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void EditMonitoringWaitingDateCol()
        {
            if (_IDs == null || _IDs == "")
                return;
            string strMonitorDate = _WaitingMonitor ? (_WaitingMonitoringDate.ToOADate() - 2).ToString() : "null";
            string strSql = "update     dbo.CRMCampaignCustomer set WaitingMonitoringDate =" + strMonitorDate +
                   " FROM            dbo.CRMCampaignCustomerContact INNER JOIN " +
                  " dbo.CRMCampaignCustomer ON dbo.CRMCampaignCustomerContact.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID " +
                  " WHERE        (dbo.CRMCampaignCustomerContact.CampaignContactID IN (" + _IDs + "))";
            strSql += " update      dbo.CRMCampaignCustomerContact set ContactWaitingMonitoringDate = " + strMonitorDate +
              " WHERE        (CampaignContactID IN (" + _IDs + ")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        #endregion
    }
    enum ContactStatus
    {
        NotSpecified,
        Done,//may wait another contact
        WrongNo,
        NoAnswer,
        NoNumber,
        Created,
        PickedUp,
        Entered,
        Departed,
        Canceled,
        Transfered


    }
}
