using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class VisitDb
    {
        #region Private Data
        protected int _ID;
        protected int _Visit;
        protected string _Desc;
        protected DateTime _Date;
        protected bool _WaitingComunication;
        protected int _ComunicationWay;
        protected int _Status;
        protected int _StatusUser;
        protected string _StatusComment;


        #region Private Data For Search
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsDateRange = false;
        protected string _StatusStr;
        protected int _WaitingComunicationStatus;/*
                                                  * 0 dont care
                                                  * 1 waiting comunication
                                                  * 2 dont wait
                                                  */
        #endregion
        #endregion

        #region Public Constractors
        public VisitDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public VisitDb()
        {

        }

        public VisitDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
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
        public int Visit
        {
            set
            {
                _Visit = value;
            }
            get
            {
                return _Visit;
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
        public bool WaitingComunication
        {
            set
            {
                _WaitingComunication = value;
            }
            get
            {
                return _WaitingComunication;
            }
        }
        public int ComunicationWay
        {
            set
            {
                _ComunicationWay = value;
            }
            get
            {
                return _ComunicationWay;
            }
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
        int _AssignedApplicant;

        public int AssignedApplicant
        {
            get { return _AssignedApplicant; }
            set { _AssignedApplicant = value; }
        }
        string _AssignedApplicantName;

        public string AssignedApplicantName
        {
            get { return _AssignedApplicantName; }
            set { _AssignedApplicantName = value; }
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
        int _Customer;

        public int Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
        string _CustomerName;

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        int _Parent;

        public int Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        string _ParentDesc;

        public string ParentDesc
        {
            get { return _ParentDesc; }
            set { _ParentDesc = value; }
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

        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
            get
            {
                return _IsDateRange;
            }
        }
        int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        int _Project;

        public int Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        public string StatusStr
        {
            set
            {
                _StatusStr = value;
            }
        }



        public int WaitingComunicationStatus
        {
            set
            {
                _WaitingComunicationStatus = value;
            }
        }
        int _WaitingAssignmentStatus;

        public int WaitingAssignmentStatus
        {
            get { return _WaitingAssignmentStatus; }
            set { _WaitingAssignmentStatus = value; }
        }
        int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
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

        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                dblDate = SysUtility.Approximate(dblDate, 1, ApproximateType.Down);
                int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
                _StatusUser = SysData.CurrentUser.ID;
                string Returned = " INSERT INTO CRMVisit" +
                          " ( VisitType, VisitVisit, VisitDesc, VisitDate, VisitWaitingComunication, VisitComunicationWay" +
                          ", VisitCreationContact, VisitLastContact, VisitFinishContact" +
                          ", VisitWorkGroup, VisitAssignedApplicant, " +
                         " VisitReservation, VisitCustomer, VisitParent, UsrIns, TimIns)" +
                          " VALUES     (" + _Type + "," + _Visit + ",'" + _Desc + "'," + dblDate + "," +
                          intWaitingComunication + "," + _ComunicationWay +
                          ",0,0,0" +
                          "," + _WorkGroup + "," + _AssignedApplicant + "," + _Reservation + "," + _Customer + "," + _Parent +
                          "," + SysData.CurrentUser.ID + ",GetDate()) ";
                Returned += " declare @ID int; set @ID = (select @@IDENTITY as exp); ";
                VisitStatusDb objStatusDb = new VisitStatusDb();
                objStatusDb.Desc = StatusComment == null || _StatusComment == "" ? "ÃœÌœ" : _StatusComment;
                objStatusDb.Status = (int)VisitStatus.Created;
                objStatusDb.EmployeeID = _EmployeeID;
                Returned += objStatusDb.AddStr;
                if (_Parent != 0)
                {
                    objStatusDb.Date = DateTime.Now;
                    objStatusDb.Desc = StatusComment == null || _StatusComment == "" ? "«‰ Ÿ«—" : _StatusComment;
                    objStatusDb.EmployeeID = _EmployeeID;

                    objStatusDb.Status = (int)VisitStatus.Waiting;
                    objStatusDb.VisitID = _Parent;

                    Returned += " " + objStatusDb.AddStr;
                }
                Returned += " select @ID as EXP";

                return Returned;
            }
        }
        public string AncestorSearchStr//«”·«›
        {
            get
            {
                string Returned = "WITH VisitAncestorTable(VisitID,VisitParent) " +
                    " AS( " +
                     " SELECT VisitID,VisitParent   " +
                     " from dbo.CRMVisit " +
                     " WHERE VisitID = " + ID + " " +
                     " UNION ALL  " +
                     " SELECT dbo.CRMVisit.VisitID,dbo.CRMVisit.VisitParent  " +
                     " from dbo.CRMVisit INNER JOIN VisitAncestorTable ON dbo.CRMVisit.VisitID = VisitAncestorTable.VisitParent " +
                      " ) ";
                return Returned;
            }
        }
        public string SuccessorSearchStr//Œ·›«¡
        {
            get
            {
                string Returned = "WITH VisitSuccessorTable(VisitID,VisitParent) " +
                    " AS( " +
                     " SELECT VisitID,VisitParent   " +
                     " from dbo.CRMVisit " +
                     " WHERE VisitID = " + ID + " " +
                     " UNION ALL  " +
                     " SELECT dbo.CRMVisit.VisitID,dbo.CRMVisit.VisitParent  " +
                     " from dbo.CRMVisit INNER JOIN VisitSuccessorTable ON dbo.CRMVisit.VisitParent = VisitSuccessorTable.VisitID " +
                      " ) ";
                return Returned;
            }
        }
        public string ParentEndedWaiting
        {
            get
            {
                string strProcessingStatus = ((int)VisitStatus.Created).ToString() +
                    "," + ((int)VisitStatus.Processing).ToString() + "," + ((int)VisitStatus.Waiting).ToString();
                string strFinishedParent = "SELECT        CRMVisit_1.VisitParent, COUNT(CRMVisit_1.VisitID) AS ProcessingChildCount " +
                          " FROM            dbo.CRMVisit AS CRMVisit_1 " +
                          " INNER JOIN  (" + VisitCurrentStatus + ") AS CRMVisitStatus_1 " +
                           " ON  CRMVisit_1.VisitID = CRMVisitStatus_1.VisitID " +
                          " WHERE        (CRMVisitStatus_1.VisitStatus IN (" + strProcessingStatus + ")) " +
                         " GROUP BY CRMVisit_1.VisitParent " +
                         " HAVING        (CRMVisit_1.VisitParent <> 0) AND (COUNT(CRMVisit_1.VisitID) = 0)";
                string Returned = "SELECT        dbo.CRMVisit.VisitID,  dbo.CRMVisit.VisitParent, CRMVisitStatus_1.VisitStatus  " +
                        " FROM            dbo.CRMVisit INNER JOIN " +
                         " (" + VisitCurrentStatus + ") AS CRMVisitStatus_1 ON CRMVisit.VisitParent = CRMVisitStatus_1.VisitID" +
                         " LEFT OUTER JOIN " +
                          " (" +//1
                         strFinishedParent +
                         ") AS ParentChildrnTable ON dbo.CRMVisit.VisitParent = ParentChildrnTable.VisitParent " +//1
                            " WHERE        (CRMVisitStatus_1.VisitStatus = " + ((int)VisitStatus.Waiting).ToString() +
                            ") AND (dbo.CRMVisit.VisitID = " + _ID + ") AND ParentChildrnTable.VisitParent IS null ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strVisitStatus = "SELECT        StatusTable.* " +
                      " FROM            (SELECT        VisitID, MAX(StatusID) AS MaxStatus " +
                      " FROM            dbo.CRMVisitStatus " +
                      " GROUP BY VisitID) AS MaxStatusTable INNER JOIN " +
                      "(" + VisitStatusDb.SearchStr + ") AS StatusTable ON MaxStatusTable.VisitID = StatusTable.VisitStatusVisitID " +
                      " AND MaxStatusTable.MaxStatus = StatusTable.StatusID ";
                string strCustomer = "SELECT  CustomerID AS VisitCustomerID, CustomerFullName AS VisitCustomerName " +
                      " FROM            dbo.CRMCustomer ";
                string strReservationCustomer = "SELECT        derivedtbl_1.ReservationID, CRMCustomer_1.CustomerID AS VisitReservationCustomerID, CRMCustomer_1.CustomerFullName AS VisitReservationCustomerName " +
                       " FROM            (SELECT        dbo.CRMReservationCustomer.ReservationID, MAX(dbo.CRMCustomer.CustomerID) AS MaxCustomer " +
                       " FROM            dbo.CRMReservationCustomer INNER JOIN " +
                       " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID " +
                       " GROUP BY dbo.CRMReservationCustomer.ReservationID) AS derivedtbl_1 INNER JOIN " +
                       " dbo.CRMCustomer AS CRMCustomer_1 ON derivedtbl_1.MaxCustomer = CRMCustomer_1.CustomerID ";
                string strReservation = "SELECT        maxUnitTable.ReservationID as VisitReservationID , CRMUnit_1.UnitFullName as VisitRservationUnit  " +
                   ",MaxCustomerTable.VisitReservationCustomerID,MaxCustomerTable.VisitReservationCustomerName " +
                    " FROM            (SELECT        dbo.CRMReservationUnit.ReservationID, MAX(dbo.CRMUnit.UnitID) AS MAxUnit " +
                    " FROM            dbo.CRMUnit INNER JOIN " +
                    " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID " +
                " GROUP BY dbo.CRMReservationUnit.ReservationID) AS maxUnitTable INNER JOIN " +
                 " dbo.CRMUnit AS CRMUnit_1 ON maxUnitTable.MAxUnit = CRMUnit_1.UnitID " +
                 " left outer join (" + strReservationCustomer + ") as MaxCustomerTable " +
                 " on   maxUnitTable.ReservationID =MaxCustomerTable.ReservationID ";
                string strGroup = "SELECT  WorkGroupID AS VisitWorkGroupID, WorkGroupNameA AS VisitWorkGroupName " +
                  " FROM            dbo.HRWorkGroup ";
                string strAssignedEmployee = "SELECT        ApplicantID as AssignedEmployeeID, ApplicantFirstName as AssignedEmployeeName " +
                        " FROM            dbo.HRApplicant ";
                string strEmployee = "SELECT        ApplicantID as EmployeeID, ApplicantFirstName as EmployeeName " +
                        " FROM            dbo.HRApplicant ";
                string strProject = "SELECT   CellID AS ProjectID, CASE WHEN ISNULL(CellAlterName, '') = '' THEN CellNameA ELSE CellAlterName END AS ProjectName " +
                " FROM            dbo.RPCell ";
                string strParent = " SELECT        VisitID AS VisitParentID, VisitDesc AS VisitParentDesc " +
                       " FROM    dbo.CRMVisit ";


                string Returned = " SELECT  dbo.CRMVisit.VisitID, dbo.CRMVisit.VisitType, dbo.CRMVisit.VisitVisit, dbo.CRMVisit.VisitDesc, dbo.CRMVisit.VisitDate, dbo.CRMVisit.VisitWaitingComunication " +
                    ",dbo.CRMVisit.VisitComunicationWay, dbo.CRMVisit.VisitCreationContact, dbo.CRMVisit.VisitLastContact, dbo.CRMVisit.VisitFinishContact, dbo.CRMVisit.VisitWorkGroup" +
                    ",dbo.CRMVisit.VisitAssignedApplicant, dbo.CRMVisit.VisitReservation, dbo.CRMVisit.VisitCustomer, dbo.CRMVisit.VisitParent " +
                    " " +
                                  //",VisitTable.*  " +
                                  ",VisitStatusTable.*,CustomerTable.*" +
                                  ",ReservationTable.VisitReservationID,ReservationTable.VisitRservationUnit ,ReservationTable.VisitReservationCustomerName" +
                                  ",GroupTable.* ,AssignedEmployeeTable.*,TypeTable.*,EmployeeTable.*,ParentVisitTable.*  " +
                                  " FROM         CRMVisit " +
                                  //" left outer join ("+ VisitDb.SearchStr +
                                  //") as VisitTable on CRMVisit.VisitVisit =  VisitTable.VisitID "+
                                  " Left outer join (" + strVisitStatus + ") as VisitStatusTable " +
                                  " on CRMVisit.VisitID = VisitStatusTable.VisitStatusVisitID  " +
                                  " left outer join (" + strCustomer + ") as CustomerTable " +
                                  " on dbo.CRMVisit.VisitCustomer = CustomerTable.VisitCustomerID  " +
                                  " left outer join (" + strReservation + ") as ReservationTable " +
                                  " on  dbo.CRMVisit.VisitReservation = ReservationTable.VisitReservationID   " +
                                  " left outer join (" + strGroup + ") as GroupTable " +
                                  " on dbo.CRMVisit.VisitWorkGroup = GroupTable.VisitWorkGroupID   " +
                                  " left outer join (" + strAssignedEmployee + ") as AssignedEmployeeTable " +
                                  " on  dbo.CRMVisit.VisitAssignedApplicant = AssignedEmployeeTable.AssignedEmployeeID " +
                                  " left outer join (" + VisitTypeDb.SearchStr + ") as TypeTable " +
                                  " on dbo.CRMVisit.VisitType = TypeTable.VisitTypeID " +
                                  " left outer join (" + strEmployee + ") as EmployeeTable " +
                                  " on CRMVisit.VisitEmployee = EmployeeTable.EmployeeID  " +
                                  "  left outer join (" + strParent + ") AS ParentVisitTable  " +
                                  " ON dbo.CRMVisit.VisitParent = ParentVisitTable.VisitParentID ";
                //"  left outer join ("+ strProject +") as ProjectTable  "+
                //" on";

                return Returned;
            }
        }
        int _Employee;
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
        int _Branch;
        public int Branch
        { set => _Branch = value; get => _Branch; }
        int _PickedStatus;
        public int PickedStatus
        {
            set => _PickedStatus = value;
            get => _PickedStatus;
        }
        int _EntryStatus;
        public int EntryStatus
        {
            set => _EntryStatus = value;
            get => _EntryStatus;
        }
        int _AssignedEmployee;
        public int AssignedEmployee
        {
            get => _AssignedEmployee;
            set => _AssignedEmployee = value;
        }
        int _WindowNo;
        public int WindowNo
        {
            set => _WindowNo = value;
            get => _WindowNo;
        }
        int _VisitNo;
        public int VisitNo
        {
            set => _VisitNo = value;
            get => _VisitNo;
        }

        bool _LogInWithSearch;
        public bool LogInWithSearch
        {
            set => _LogInWithSearch = value;
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
        public string StrSearch
        {
            get
            {
                string strStrContactDate = @"";
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



                string strProject = "SELECT   CellID AS ProjectID, CASE WHEN ISNULL(CellAlterName, '') = '' THEN CellNameA ELSE CellAlterName END AS ProjectName " +
" FROM            dbo.RPCell ";



                string Returned = @"SELECT        dbo.CRMCampaignCustomerContact.CampaignContactID, dbo.CRMCampaignCustomerContact.ContactDirection, dbo.CRMCampaignCustomerContact.ContactDate, dbo.CRMCampaignCustomerContact.ContactType, 
                         dbo.CRMCampaignCustomerContact.ContactComment, dbo.CRMCampaignCustomerContact.ContactStatus, dbo.CRMCampaignCustomerContact.ContactFunctionalStatus, 
                         dbo.CRMCampaignCustomerContact.ContactWaitingAnotherContact, dbo.CRMCampaignCustomerContact.ContactWaitingDate, dbo.CRMCampaignCustomerContact.ContactEmployee, 
                         dbo.CRMCampaignCustomerContact.ContactBranch, 0 AS CampaignCustomerID, 0 AS CampaignID, GETDATE() AS CampaignDate, '' AS CampaignDesc, DirectCustomerTable.DirectCustomerID AS CustomerID, 
                         DirectCustomerTable.DirectCustomerName AS CustomerFullName, 0 AS DirectTopicID, '' AS DirectTopicName, DirectCustomerTable.DirectCustomerID, DirectCustomerTable.DirectCustomerName, 
                         DirectCustomerTable.DirectCustomerAddress, DirectCustomerTable.DirectCustomerPhone, DirectCustomerTable.DirectCustomerMobile, DirectCustomerTable.DirectCustomerUnitName, 
                         DirectCustomerTable.DirectCustomerTowerName, DirectCustomerTable.DirectCustomerProjectName, 0 AS DirectCampaignID, GETDATE() AS DirectCampaignDate, '' AS DirectCampaignDesc, 0 AS DirectCampaignTopicID, 
                         '' as DirectCampaignTopicName, ReceptionTable.CampaignContactReceptionID, ReceptionTable.CampaignContactReceptionist, ReceptionTable.CampaignContactReceptionistName, 
                         ReceptionTable.CampaignContactReceptionTime, ReceptionTable.CampaignContactReceptionPickTime, ReceptionTable.CampaignContactEntryTime, ReceptionTable.CampaignContactCancelTime, 
                         ReceptionTable.CampaignContactDepartureTime, ReceptionTable.CampaignContactReceptionGroup, ReceptionTable.CampaignContactReceptionProcessed, ReceptionTable.CampaignContactReceptionCustomerName, 
                         ReceptionTable.CampaignContactReceptionCustomerPhone
,ReceptionTable.CampaignContactReceptionVisitNo,ReceptionTable.CampaignContactReceptionWindowNo,ReceptionTable.CampaignContactReceptionBroadCastTime
, ReceptionTable.VisitTypeID, ReceptionTable.VisitTypeCode, ReceptionTable.VisitTypeNameA, ReceptionTable.VisitTypeNameE, 
                         ReceptionTable.CampaignContactVisitType, VisitStatusTable.StatusID, VisitStatusTable.VisitStatusVisitID, VisitStatusTable.VisitStatus, VisitStatusTable.VisitFunctionalStatus, VisitStatusTable.VisitStatusComment, 
                         VisitStatusTable.VisitStatusAplicant, VisitStatusTable.StatusUsrIns, VisitStatusTable.StatusTimIns, VisitStatusTable.EmployeeID, VisitStatusTable.EmployeeName, VisitStatusTable.ENStatusUN, VisitStatusTable.DEStatusUN, 
                         ReservationTable.VisitReservationID, ReservationTable.VisitRservationUnit, ReservationTable.VisitReservationCustomerName, ReservationTable.ReservationStatus, ReservationTable.CancelationID, 
                         ReservationTable.CancelationDate
,EmployeeTable.*, GroupTable.VisitWorkGroupID, GroupTable.VisitWorkGroupName, 0 AS ApplicantID, '' AS ApplicantCode, '' AS ApplicantFirstName, '' AS ApplicantFamousName, '' AS ApplicantShortName, 
                         '' AS ApplicantNameComp, 0 AS ApplicantUser, 0 AS ApplicantStatusID, GETDATE() AS ApplicantEndDate, 0 AS SalesManID, 0 AS SalesBranchID, '' AS SalesBranchName, 0 AS CurrentApplicant, 0 AS ApplicantBranchID, 
                         '' AS ApplicantBranchName, 0 AS DepartmentID, 0 AS WorkGroupID, BranchTable.BranchID, BranchTable.BranchName, 0 AS ContactTicketID, '' AS ContactTicketWorkGroupName, 0 AS ContactTicketEmployee1, 
                         0 AS ContactTicketStatus, GETDATE() AS ContactTicketPostponementDate, 0 AS ContactTicketEmployeeID, 0 AS ContactTicketWorkGroupID, '' AS TicketDesc, '' AS TicketDate, 0 AS TicketType, '' AS TicketTypeNameA, 
                         dbo.CRMCampaignCustomerContact.ContactWaitingMonitoringDate AS WaitingMonitoringDate, dbo.CRMCampaignCustomerContact.ContactWaitingDate AS WaitingContactDate, 0 AS LastMonitoringID, GETDATE() 
                         AS LastMonitoringDate, '' AS LastMonitoringDesc, 0 AS LastMonitoringStatus, 0 AS LastMonitoringEmployee, '' AS LastMonitoringEmolyeeName, 
                        0  AS TotalPaidValue, ''  AS PaymentType  " +
                                  " FROM   dbo.CRMCampaignCustomerContact " +
                      " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable " +
                      " on dbo.CRMCampaignCustomerContact.ContactEmployee = EmployeeTable.ApplicantID  ";



                Returned += " left outer join ";

                Returned += " (" + strDirectCustomer + ") as DirectCustomerTable " +
                      " on    dbo.CRMCampaignCustomerContact.ContactDirectCustomer=DirectCustomerTable.DirectCustomerID ";



                Returned += " left outer join (" + strReservation + ") as ReservationTable " +
           " on  dbo.CRMCampaignCustomerContact.ContactReservation = ReservationTable.VisitReservationID " +
   " left outer join (" + UMSBranchDb.SearchStr + ") as BranchTable " +
   " on  dbo.CRMCampaignCustomerContact.ContactBranch = BranchTable.BranchID " +
   " left outer join (" + strProject + ") as ProjectTable " +
   " on  dbo.CRMCampaignCustomerContact.ContactProject = ProjectTable.ProjectID ";


                Returned += "  inner  join (" + strReception + ") as ReceptionTable ";





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





                if (_Branch != 0)
                    Returned += " and  (dbo.CRMCampaignCustomerContact.ContactBranch = " + _Branch + ") ";
                if (_WorkGroup != 0)
                    Returned += " and CampaignContactReceptionGroup=" + _WorkGroup;
                if (_Employee != 0)//&&!_LogInWithSearch)
                    Returned += " and  (ContactEmployee =" + _Employee + "  or CampaignContactReceptionist = " + _Employee + " or EmployeeID = " + _Employee + ")";

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
                return Returned;
            }
        }
        public static string VisitCurrentStatus
        {
            get
            {
                string Returned = "SELECT CRMVisitStatus.VisitID ,CRMVisitStatus.VisitStatus,CRMVisitStatus.VisitPostponementDate  " +
                    " from dbo.CRMVisitStatus  " +
                    " INNER JOIN (SELECT        VisitID, MAX(StatusID) AS MaxStatusID " +
                      " FROM            dbo.CRMVisitStatus " +
                       " GROUP BY VisitID) MaxStatusTable  " +
                       " ON  dbo.CRMVisitStatus.VisitID = MaxStatusTable.VisitID AND dbo.CRMVisitStatus.StatusID = MaxStatusTable.MaxStatusID";
                return Returned;
            }
        }

        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["VisitID"].ToString());
            _Visit = int.Parse(objDR["VisitVisit"].ToString());
            _Type = int.Parse(objDR["VisitType"].ToString());
            _Desc = objDR["VisitDesc"].ToString();
            _Date = DateTime.Parse(objDR["VisitDate"].ToString());
            _WaitingComunication = bool.Parse(objDR["VisitWaitingComunication"].ToString());
            _ComunicationWay = int.Parse(objDR["VisitComunicationWay"].ToString());
            //  VisitCreationContact, dbo.CRMVisit.VisitLastContact, dbo.CRMVisit.VisitFinishContact
            _Status = int.Parse(objDR["VisitStatus"].ToString());
            // _StatusUser = int.Parse(objDR["VisitStatusUser"].ToString());
            _HasStatusPostponementDate = DateTime.TryParse(objDR["VisitPostponementDate"].ToString(), out _StatusPostponementDate);
            _StatusComment = objDR["VisitStatusComment"].ToString();
            if (objDR["VisitWorkGroupID"].ToString() != "")
                _WorkGroup = int.Parse(objDR["VisitWorkGroupID"].ToString());
            _WorkGroupName = objDR["VisitWorkGroupName"].ToString();


            if (objDR["AssignedEmployeeID"].ToString() != "")
                _AssignedApplicant = int.Parse(objDR["AssignedEmployeeID"].ToString());
            _AssignedApplicantName = objDR["AssignedEmployeeName"].ToString();


            //
            if (objDR["VisitReservationID"].ToString() != "")
                _Reservation = int.Parse(objDR["VisitReservationID"].ToString());
            _ReservationCustomerName = objDR["VisitReservationCustomerName"].ToString();
            _ReservationUnitName = objDR["VisitRservationUnit"].ToString();
            if (objDR["VisitCustomerID"].ToString() != "")
                _Customer = int.Parse(objDR["VisitCustomerID"].ToString());
            _CustomerName = objDR["VisitCustomerName"].ToString();

            _Parent = int.Parse(objDR["VisitParent"].ToString());
            if (objDR["EmployeeID"].ToString() != "")
                _EmployeeID = int.Parse(objDR["EmployeeID"].ToString());
            _EmployeeName = objDR["EmployeeName"].ToString();
            if (objDR["VisitParentID"].ToString() != "")
                _Parent = int.Parse(objDR["VisitParentID"].ToString());
            _ParentDesc = objDR["VisitParentDesc"].ToString();
        }

        #endregion

        #region Public Methods
        public virtual void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
            _StatusUser = SysData.CurrentUser.ID;
            string strsql = AddStr;
            object objID = SysData.SharpVisionBaseDb.ReturnScalar(strsql);
            if (objID != null)
                _ID = (int)objID;
            //InsertStatusHistory();
        }
        public virtual void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
            _StatusUser = SysData.CurrentUser.ID;
            string StrSql = " UPDATE    CRMVisit" +
                            " SET  VisitVisit =" + _Visit + "," +
                            " VisitDesc ='" + _Desc + "'," +
                            " VisitDate =" + _Date + "," +
                            " VisitWaitingComunication =" + intWaitingComunication + "," +
                            " VisitComunicationWay =" + _ComunicationWay + "," +
                            " VisitStatus =" + _Status + "," +
                            " VisitStatusUser =" + _StatusUser + ", " +
                            " VisitStatusComment =" + _StatusComment + "," +
                            " UsrUpd =" + SysData.CurrentUser.ID + "," +
                            " TimUpd = GetDate()" +
                            " Where VisitID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(StrSql);
            //InsertStatusHistory();
        }

        public void EditStatus()
        {
            double dblStatusDate = _Date.ToOADate() - 2;
            VisitStatusDb objStatus = new VisitStatusDb();
            objStatus.Date = DateTime.Now;
            objStatus.Desc = StatusComment;
            objStatus.EmployeeID = _EmployeeID;
            objStatus.Status = _Status;
            objStatus.VisitID = ID;

            string strStatus = objStatus.AddStr;

            string strSql = strStatus;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //InsertStatusHistory();
        }
        public virtual DataTable Search()
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

            strSql = StrSearch;


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public bool PickUpVisit()
        {
            bool Returned = true;
            if (_AssignedApplicant == 0)
                return false;
            VisitStatusDb objStatusDb = new VisitStatusDb();
            objStatusDb.Date = DateTime.Now;
            objStatusDb.Desc = StatusComment;
            objStatusDb.EmployeeID = _AssignedApplicant;
            objStatusDb.Status = (int)VisitStatus.Processing;
            objStatusDb.VisitID = ID;
            string strFromClause = " FROM dbo.CRMVisit INNER JOIN  " +
                 " (SELECT        derivedtbl_1.VisitID, CRMVisitStatus_1.VisitStatus " +
                 " FROM            (SELECT        VisitID, MAX(StatusID) AS MaxStatusID " +
                  " FROM            dbo.CRMVisitStatus " +
                  " GROUP BY VisitID) AS derivedtbl_1 INNER JOIN " +
                  " dbo.CRMVisitStatus AS CRMVisitStatus_1 ON derivedtbl_1.MaxStatusID = CRMVisitStatus_1.StatusID AND derivedtbl_1.VisitID = CRMVisitStatus_1.VisitID) " +
                  " AS StatusTable ON dbo.CRMVisit.VisitID = StatusTable.VisitID " +
                  " WHERE        (dbo.CRMVisit.VisitID = " + _ID + ") AND (VisitWorkGroup = " + _WorkGroup + ") " +
                  " AND (VisitAssignedApplicant = 0) AND StatusTable.VisitStatus=" + ((int)VisitStatus.Created).ToString() + "";
            string strSql = " begin tran Trans1 ;";
            strSql += " declare @Count int;" +
    "     set @Count = (select count(CRMVisit.VisitID) as Exp " + strFromClause + ") ";
            strSql += " if @Count = 0 goto rolLine; ";
            strSql += " UPDATE CRMVisit " +
              " SET VisitAssignedApplicant = " + _AssignedApplicant +
             strFromClause + ";";
            strSql += " set @Count = (SELECT        COUNT(1) AS Expr1 " +
              " FROM            dbo.CRMVisit " +
                " WHERE        (VisitID = " + ID + ") AND (VisitAssignedApplicant = " + _AssignedApplicant + ")) ";
            strSql += " if @Count = 0 goto rolLine ";
            strSql += objStatusDb.AddStr;
            strSql += "CommitLine: commit TRAN Trans1;select 1 as exp1;return;" +
                " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1  ";
            object objTemp = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objTemp.ToString() == "-1")
                Returned = false;

            return Returned;
        }
        public void BroadCastVisit()
        {
            if (_ID == 0)
                return;
            string strSql = @" update dbo.CRMCampaignCustomerContactReception set CampaignContactReceptionBroadCastTime = GetDate()
WHERE(CampaignContactID = " + _ID +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        enum VisitStatus
        {
            NotSpecified, //0 €Ì— „Õœœ
            Created,//  „ ⁄„· «· Ìﬂ  1
            Processing,//Ì „ „⁄«·Ã… «· Ìﬂ  2
            Waiting,// «· Ìﬂ   ‰ Ÿ— «·„⁄«·Ã… 3
            Canceled,//4  „ «·€«¡ «· Ìﬂ  
            Ended// „ «·«‰ Â«¡ 5

        }
        #endregion
    }
}
