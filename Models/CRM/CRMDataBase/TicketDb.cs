using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseDataBase;


namespace SharpVision.CRM.CRMDataBase
{
    public class TicketDb
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
        public TicketDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public TicketDb()
        {

        }

        public TicketDb(DataRow objDR)
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
        string _ParentIDs;

        public string ParentIDs
        {
            get { return _ParentIDs; }
            set { _ParentIDs = value; }
        }
        int _MainTicket;

        public int MainTicket
        {
            get { return _MainTicket; }
            set { _MainTicket = value; }
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
        string _ProjectName;

        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
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
        bool _PostponmentDateStatus;

        public bool PostponmentDateStatus
        {
            get { return _PostponmentDateStatus; }
            set { _PostponmentDateStatus = value; }
        }
        DateTime _StartPostponementDate;

        public DateTime StartPostponementDate
        {
            get { return _StartPostponementDate; }
            set { _StartPostponementDate = value; }
        }
        DateTime _EndPostponementDate;

        public DateTime EndPostponementDate
        {
            get { return _EndPostponementDate; }
            set { _EndPostponementDate = value; }
        }
        string _IDs;

        public string IDs
        {
            get { return _IDs; }
            set { _IDs = value; }
        }
        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                dblDate = SysUtility.Approximate(dblDate, 1, ApproximateType.Down);
                int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
                _StatusUser = SysData.CurrentUser.ID;
                string strPostponmentDate = _HasStatusPostponementDate ?
                    SysUtility.Approximate(_StatusPostponementDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";

                string Returned = " INSERT INTO CRMTicket" +
                          " (TicketEmployee, TicketType, TicketVisit, TicketDesc, TicketDate, TicketWaitingComunication, TicketComunicationWay" +
                          ", TicketCreationContact, TicketLastContact, TicketFinishContact" +
                          ", TicketWorkGroup, TicketAssignedApplicant, " +
                         " TicketReservation, TicketCustomer, TicketParent,TicketProject,TicketPostponementDate, UsrIns, TimIns)" +
                          " VALUES     (" + _EmployeeID + "," + _Type + "," + _Visit + ",'" + _Desc + "'," + dblDate + "," +
                          intWaitingComunication + "," + _ComunicationWay +
                          ",0,0,0" +
                          "," + _WorkGroup + "," + _AssignedApplicant + "," + _Reservation + "," + _Customer + "," + _Parent +
                           "," + _Project + "," + strPostponmentDate + "," + SysData.CurrentUser.ID + ",GetDate()) ";
                Returned += " declare @ID int; set @ID = (select @@IDENTITY as exp); ";
                TicketStatusDb objStatusDb = new TicketStatusDb();
                objStatusDb.Desc = StatusComment == null || _StatusComment == "" ? "ÃœÌœ" : _StatusComment;
                objStatusDb.Status = Status == (int)TicketStatus.NotSpecified ? (int)TicketStatus.Created : Status;// (int) TicketStatus.Created;
                objStatusDb.EmployeeID = _EmployeeID;
                Returned += objStatusDb.AddStr;
                if (_Parent != 0)
                {
                    objStatusDb.Date = DateTime.Now;
                    objStatusDb.Desc = StatusComment == null || _StatusComment == "" ? "«‰ Ÿ«—" : _StatusComment;
                    objStatusDb.EmployeeID = _EmployeeID;
                    objStatusDb.SourceTicket = 0;
                    objStatusDb.Status = (int)TicketStatus.Waiting;
                    objStatusDb.TicketID = _Parent;
                    objStatusDb.HasPostponementDate = _HasStatusPostponementDate;
                    objStatusDb.PostponementDate = _StatusPostponementDate;
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
                string Returned = "WITH TicketAncestorTable(TicketID,TicketParent) " +
                    " AS( " +
                     " SELECT TicketID,TicketParent   " +
                     " from dbo.CRMTicket " +
                     " WHERE TicketID = " + ID + " " +
                     " UNION ALL  " +
                     " SELECT dbo.CRMTicket.TicketID,dbo.CRMTicket.TicketParent  " +
                     " from dbo.CRMTicket INNER JOIN TicketAncestorTable ON dbo.CRMTicket.TicketID = TicketAncestorTable.TicketParent " +
                      " ) ";
                return Returned;
            }
        }
        public string SuccessorSearchStr//Œ·›«¡
        {
            get
            {
                if (_ID == 0 && (_IDs == null || _IDs == ""))
                    return "";
                string Returned = "WITH TicketSuccessorTable(TicketID,TicketParent,MainTicket) " +
                    " AS( " +
                     " SELECT TicketID,TicketParent,dbo.CRMTicket.TicketID as MainTicket   " +
                     " from dbo.CRMTicket " +
                     " WHERE  (1=1) ";
                if (_ID != 0)
                    Returned += " and TicketID = " + ID + " ";
                else
                    Returned += " and TicketID in (" + IDs + ") ";
                Returned += " UNION ALL  " +
                  " SELECT dbo.CRMTicket.TicketID,dbo.CRMTicket.TicketParent,TicketSuccessorTable.MainTicket  " +
                  " from dbo.CRMTicket INNER JOIN TicketSuccessorTable ON dbo.CRMTicket.TicketParent = TicketSuccessorTable.TicketID " +
                   " ) ";
                return Returned;
            }
        }
        public string ParentEndedWaiting
        {
            get
            {
                string strProcessingStatus = ((int)TicketStatus.Created).ToString() +
                    "," + ((int)TicketStatus.Processing).ToString() + "," + ((int)TicketStatus.Waiting).ToString();
                string strFinishedParent = "SELECT        CRMTicket_1.TicketParent, COUNT(CRMTicket_1.TicketID) AS ProcessingChildCount " +
                          " FROM            dbo.CRMTicket AS CRMTicket_1 " +
                          " INNER JOIN  (" + TicketCurrentStatus + ") AS CRMTicketStatus_1 " +
                           " ON  CRMTicket_1.TicketID = CRMTicketStatus_1.TicketID " +
                          " WHERE        (CRMTicketStatus_1.TicketStatus IN (" + strProcessingStatus + ")) " +
                         " GROUP BY CRMTicket_1.TicketParent " +
                         " HAVING        (CRMTicket_1.TicketParent <> 0) AND (COUNT(CRMTicket_1.TicketID) = 0)";
                string Returned = "SELECT        dbo.CRMTicket.TicketID,  dbo.CRMTicket.TicketParent, CRMTicketStatus_1.TicketStatus  " +
                        " FROM            dbo.CRMTicket INNER JOIN " +
                         " (" + TicketCurrentStatus + ") AS CRMTicketStatus_1 ON CRMTicket.TicketParent = CRMTicketStatus_1.TicketID" +
                         " LEFT OUTER JOIN " +
                          " (" +//1
                         strFinishedParent +
                         ") AS ParentChildrnTable ON dbo.CRMTicket.TicketParent = ParentChildrnTable.TicketParent " +//1
                            " WHERE        (CRMTicketStatus_1.TicketStatus = " + ((int)TicketStatus.Waiting).ToString() +
                            ") AND (dbo.CRMTicket.TicketID = " + _ID + ") AND ParentChildrnTable.TicketParent IS null ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strTicketStatus = "SELECT        StatusTable.* " +
                      " FROM            (SELECT        TicketID, MAX(StatusID) AS MaxStatus " +
                      " FROM            dbo.CRMTicketStatus " +
                      " GROUP BY TicketID) AS MaxStatusTable INNER JOIN " +
                      "(" + TicketStatusDb.SearchStr + ") AS StatusTable ON MaxStatusTable.TicketID = StatusTable.TicketStatusTicketID " +
                      " AND MaxStatusTable.MaxStatus = StatusTable.StatusID ";
                string strCustomer = "SELECT  CustomerID AS TicketCustomerID, CustomerFullName AS TicketCustomerName " +
                      " FROM            dbo.CRMCustomer ";
                string strReservationCustomer = "SELECT        derivedtbl_1.ReservationID, CRMCustomer_1.CustomerID AS TicketReservationCustomerID, CRMCustomer_1.CustomerFullName AS TicketReservationCustomerName " +
                       " FROM            (SELECT        dbo.CRMReservationCustomer.ReservationID, MAX(dbo.CRMCustomer.CustomerID) AS MaxCustomer " +
                       " FROM            dbo.CRMReservationCustomer INNER JOIN " +
                       " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID " +
                       " GROUP BY dbo.CRMReservationCustomer.ReservationID) AS derivedtbl_1 INNER JOIN " +
                       " dbo.CRMCustomer AS CRMCustomer_1 ON derivedtbl_1.MaxCustomer = CRMCustomer_1.CustomerID ";
                string strReservation = "SELECT        maxUnitTable.ReservationID as TicketReservationID , CRMUnit_1.UnitFullName as TicketRservationUnit  " +
                   ",MaxCustomerTable.TicketReservationCustomerID,MaxCustomerTable.TicketReservationCustomerName " +
                    " FROM            (SELECT        dbo.CRMReservationUnit.ReservationID, MAX(dbo.CRMUnit.UnitID) AS MAxUnit " +
                    " FROM            dbo.CRMUnit INNER JOIN " +
                    " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID " +
                " GROUP BY dbo.CRMReservationUnit.ReservationID) AS maxUnitTable INNER JOIN " +
                 " dbo.CRMUnit AS CRMUnit_1 ON maxUnitTable.MAxUnit = CRMUnit_1.UnitID " +
                 " left outer join (" + strReservationCustomer + ") as MaxCustomerTable " +
                 " on   maxUnitTable.ReservationID =MaxCustomerTable.ReservationID ";
                string strGroup = "SELECT  WorkGroupID AS TicketWorkGroupID, WorkGroupNameA AS TicketWorkGroupName " +
                  " FROM            dbo.HRWorkGroup ";
                string strAssignedEmployee = "SELECT        ApplicantID as AssignedEmployeeID, ApplicantFirstName as AssignedEmployeeName " +
                        " FROM            dbo.HRApplicant ";
                string strEmployee = "SELECT        ApplicantID as EmployeeID, ApplicantFirstName as EmployeeName " +
                        " FROM            dbo.HRApplicant ";
                string strProject = "SELECT   CellID AS ProjectID, CASE WHEN ISNULL(CellAlterName, '') = '' THEN CellNameA ELSE CellAlterName END AS ProjectName " +
" FROM            dbo.RPCell ";
                string strParent = " SELECT        TicketID AS TicketParentID, TicketDesc AS TicketParentDesc " +
                       " FROM    dbo.CRMTicket ";


                string Returned = "";
                bool blGetSuccessor = false;
                if (_Parent != 0 || (_ParentIDs != null && _ParentIDs != ""))
                {
                    blGetSuccessor = true;
                    TicketDb objTempDb = new TicketDb();
                    objTempDb.ID = _Parent;
                    objTempDb.IDs = _ParentIDs;
                    Returned += objTempDb.SuccessorSearchStr;
                }
                Returned += " SELECT  dbo.CRMTicket.TicketID, dbo.CRMTicket.TicketType, dbo.CRMTicket.TicketVisit, dbo.CRMTicket.TicketDesc, dbo.CRMTicket.TicketDate, dbo.CRMTicket.TicketWaitingComunication " +
                     ",dbo.CRMTicket.TicketComunicationWay, dbo.CRMTicket.TicketCreationContact, dbo.CRMTicket.TicketLastContact, dbo.CRMTicket.TicketFinishContact, dbo.CRMTicket.TicketWorkGroup" +
                     ",dbo.CRMTicket.TicketAssignedApplicant, dbo.CRMTicket.TicketReservation, dbo.CRMTicket.TicketCustomer, dbo.CRMTicket.TicketParent,CRMTicket.TicketEmployee " +
                     " " +
                                   //",VisitTable.*  " +
                                   ",TicketStatusTable.*,CustomerTable.*" +
                                   ",ReservationTable.TicketReservationID,ReservationTable.TicketRservationUnit ,ReservationTable.TicketReservationCustomerName" +
                                   ",GroupTable.* ,AssignedEmployeeTable.*,TypeTable.*,EmployeeTable.*,ParentTicketTable.* ,ProjectTable.* ";

                if (blGetSuccessor)
                    Returned += " ,ParentTable.MainTicket ";
                else
                    Returned += ",0 as MainTicket ";
                Returned += " FROM         CRMTicket " +
                   //" left outer join ("+ VisitDb.SearchStr +
                   //") as VisitTable on CRMTicket.TicketVisit =  VisitTable.VisitID "+
                   " Left outer join (" + strTicketStatus + ") as TicketStatusTable " +
                   " on CRMTicket.TicketID = TicketStatusTable.TicketStatusTicketID  " +
                   " left outer join (" + strCustomer + ") as CustomerTable " +
                   " on dbo.CRMTicket.TicketCustomer = CustomerTable.TicketCustomerID  " +
                   " left outer join (" + strReservation + ") as ReservationTable " +
                   " on  dbo.CRMTicket.TicketReservation = ReservationTable.TicketReservationID   " +
                   " left outer join (" + strGroup + ") as GroupTable " +
                   " on dbo.CRMTicket.TicketWorkGroup = GroupTable.TicketWorkGroupID   " +
                   " left outer join (" + strAssignedEmployee + ") as AssignedEmployeeTable " +
                   " on  dbo.CRMTicket.TicketAssignedApplicant = AssignedEmployeeTable.AssignedEmployeeID " +
                   " left outer join (" + TicketTypeDb.SearchStr + ") as TypeTable " +
                   " on dbo.CRMTicket.TicketType = TypeTable.TicketTypeID " +
                   " left outer join (" + strEmployee + ") as EmployeeTable " +
                   " on CRMTicket.TicketEmployee = EmployeeTable.EmployeeID  " +
                   "  left outer join (" + strParent + ") AS ParentTicketTable  " +
                   " ON dbo.CRMTicket.TicketParent = ParentTicketTable.TicketParentID " +
                     " left outer join (" + strProject + ") as ProjectTable " +
" on  dbo.CRMTicket.TicketProject = ProjectTable.ProjectID ";
                if (blGetSuccessor)
                    Returned += " inner join TicketSuccessorTable as ParentTable " +
                        " on CRMTicket.TicketID = ParentTable.TicketID  ";

                return Returned;
            }
        }
        public static string TicketCurrentStatus
        {
            get
            {
                string Returned = "SELECT CRMTicketStatus.TicketID ,CRMTicketStatus.TicketStatus,CRMTicketStatus.TicketPostponementDate  " +
                    " from dbo.CRMTicketStatus  " +
                    " INNER JOIN (SELECT        TicketID, MAX(StatusID) AS MaxStatusID " +
                      " FROM            dbo.CRMTicketStatus " +
                       " GROUP BY TicketID) MaxStatusTable  " +
                       " ON  dbo.CRMTicketStatus.TicketID = MaxStatusTable.TicketID AND dbo.CRMTicketStatus.StatusID = MaxStatusTable.MaxStatusID";
                return Returned;
            }
        }

        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["TicketID"].ToString());
            _Visit = int.Parse(objDR["TicketVisit"].ToString());
            _Type = int.Parse(objDR["TicketType"].ToString());
            _Desc = objDR["TicketDesc"].ToString();
            _Date = DateTime.Parse(objDR["TicketDate"].ToString());
            _WaitingComunication = bool.Parse(objDR["TicketWaitingComunication"].ToString());
            _ComunicationWay = int.Parse(objDR["TicketComunicationWay"].ToString());
            //  TicketCreationContact, dbo.CRMTicket.TicketLastContact, dbo.CRMTicket.TicketFinishContact
            _Status = int.Parse(objDR["TicketStatus"].ToString());
            // _StatusUser = int.Parse(objDR["TicketStatusUser"].ToString());
            _HasStatusPostponementDate = DateTime.TryParse(objDR["TicketPostponementDate"].ToString(), out _StatusPostponementDate);
            _StatusComment = objDR["TicketStatusComment"].ToString();
            if (objDR["TicketWorkGroupID"].ToString() != "")
                _WorkGroup = int.Parse(objDR["TicketWorkGroupID"].ToString());
            _WorkGroupName = objDR["TicketWorkGroupName"].ToString();


            if (objDR["AssignedEmployeeID"].ToString() != "")
                _AssignedApplicant = int.Parse(objDR["AssignedEmployeeID"].ToString());
            _AssignedApplicantName = objDR["AssignedEmployeeName"].ToString();


            //
            if (objDR["TicketReservationID"].ToString() != "")
                _Reservation = int.Parse(objDR["TicketReservationID"].ToString());
            _ReservationCustomerName = objDR["TicketReservationCustomerName"].ToString();
            _ReservationUnitName = objDR["TicketRservationUnit"].ToString();
            if (objDR["TicketCustomerID"].ToString() != "")
                _Customer = int.Parse(objDR["TicketCustomerID"].ToString());
            _CustomerName = objDR["TicketCustomerName"].ToString();

            _Parent = int.Parse(objDR["TicketParent"].ToString());
            if (objDR["EmployeeID"].ToString() != "")
                _EmployeeID = int.Parse(objDR["EmployeeID"].ToString());
            _EmployeeName = objDR["EmployeeName"].ToString();
            if (objDR["TicketParentID"].ToString() != "")
                _Parent = int.Parse(objDR["TicketParentID"].ToString());
            _ParentDesc = objDR["TicketParentDesc"].ToString();
            int.TryParse(objDR["MainTicket"].ToString(), out _MainTicket);
            int.TryParse(objDR["ProjectID"].ToString(), out _Project);
            _ProjectName = objDR["ProjectName"].ToString();

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
            string strPostponmentDate = _HasStatusPostponementDate ?
                   SysUtility.Approximate(_StatusPostponementDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";

            double dblDate = _Date.ToOADate() - 2;
            int intWaitingComunication = _WaitingComunication == true ? 1 : 0;
            _StatusUser = SysData.CurrentUser.ID;
            string StrSql = " UPDATE    CRMTicket" +
                            " SET  TicketVisit =" + _Visit + "," +
                            " TicketDesc ='" + _Desc + "'," +
                            " TicketDate =" + _Date + "," +
                            " TicketWaitingComunication =" + intWaitingComunication + "," +
                            " TicketComunicationWay =" + _ComunicationWay + "," +
                            " TicketStatus =" + _Status + "," +
                            " TicketStatusUser =" + _StatusUser + ", " +
                            " TicketStatusComment ='" + _StatusComment + "'" +
                            ",TicketPostponementDate=" + strPostponmentDate +
                            " ,UsrUpd =" + SysData.CurrentUser.ID + "," +
                            " TimUpd = GetDate()" +
                            " Where TicketID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(StrSql);
            //InsertStatusHistory();
        }

        public void EditStatus()
        {
            double dblStatusDate = _Date.ToOADate() - 2;
            TicketStatusDb objStatus = new TicketStatusDb();
            objStatus.Date = DateTime.Now;
            objStatus.Desc = StatusComment;
            objStatus.EmployeeID = _EmployeeID;
            objStatus.Status = _Status;
            objStatus.TicketID = ID;
            objStatus.HasPostponementDate = HasStatusPostponementDate;
            objStatus.PostponementDate = StatusPostponementDate;
            string strStatus = objStatus.AddStr;
            objStatus.SourceTicket = ID;
            if (_Parent != 0 && ((TicketStatus)_Status == TicketStatus.Ended || (TicketStatus)_Status == TicketStatus.Canceled))
            {
                objStatus.Parent = _Parent;
                objStatus.Status = (int)TicketStatus.Processing;

                strStatus += " " + objStatus.AddParentProcessingStatusStr;
            }
            if ((TicketStatus)_Status == TicketStatus.Ended || (TicketStatus)_Status == TicketStatus.Canceled)
            {
                objStatus.TicketID = ID;
                objStatus.Status = _Status;
                objStatus.SourceTicket = ID;
                strStatus += ";" + objStatus.AddSuccessorStatusStr;
            }
            string strSql = strStatus;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //InsertStatusHistory();
        }
        public virtual DataTable Search()
        {

            double dblDateFrom = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblDateTo = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);

            string StrSql = SearchStr + " WHERE   (1=1)";

            if (_ID != 0)
                StrSql = StrSql + "and TicketID = " + _ID + "";
            if (_IDs != null && _IDs != "")
                StrSql = StrSql + "and TicketID in  (" + _IDs + ")";
            if (_Visit != 0)
                StrSql = StrSql + " and TicketVisit = " + _Visit + " ";
            if (_IsDateRange)
                StrSql = StrSql + " and TicketDate >= " + dblDateFrom + " and TicketDate <  " + dblDateTo + "";
            if (_Customer != 0)
                StrSql += " and dbo.CRMTicket.TicketCustomer =" + _Customer;
            if (_Reservation != 0)
                StrSql += " and dbo.CRMTicket.TicketReservation =" + _Reservation;

            if (_EmployeeID != 0)
                StrSql += " and TicketEmployee = " + _EmployeeID;

            if (_WaitingComunicationStatus != 0)
            {
                if (_WaitingComunicationStatus == 1)
                    StrSql += " and TicketWaitingComunication=1 and TicketComunicationWay=0 ";

            }
            if (_StatusStr != null && _StatusStr != "")
                StrSql += " and TicketStatus in(" + _StatusStr + ")";

            if (_AssignedApplicant != 0 && _WaitingAssignmentStatus == 0)
            {

                StrSql += " and TicketAssignedApplicant = " + _AssignedApplicant;
                if (_StatusStr != null && _StatusStr == ((int)TicketStatus.Processing).ToString())
                    StrSql += " and  (TicketStatusTable.TicketPostponementDate is null or TicketStatusTable.TicketPostponementDate <= GetDate() ) ";

            }
            if (_WaitingAssignmentStatus != 0)
            {

                StrSql += " and TicketStatusTable.TicketStatus =" + (int)TicketStatus.Created;

                StrSql += " and (TicketAssignedApplicant= 0 ";
                if (_AssignedApplicant != 0)
                    StrSql += " or TicketAssignedApplicant = " + _AssignedApplicant;
                StrSql += ")";
                if (_WorkGroup != 0)
                    StrSql += " and TicketWorkGroup =" + _WorkGroup;
                //else
                //    StrSql += " and TicketWorkGroup >0 ";


            }
            else
            {
                if (_WorkGroup != 0)
                    StrSql += " and TicketWorkGroup =" + _WorkGroup;
            }
            if (_PostponmentDateStatus)
            {
                dblDateFrom = SysUtility.Approximate(_StartPostponementDate.ToOADate() - 2, 1, ApproximateType.Down);
                dblDateTo = SysUtility.Approximate(_EndPostponementDate.ToOADate() - 2, 1, ApproximateType.Up);
                StrSql += " and TicketStatusTable.TicketPostponementDate >=" + dblDateFrom + " and TicketStatusTable.TicketPostponementDate <" + dblDateTo;

            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);

        }
        public DataTable GetWaitingTodayTicket()
        {
            DataTable Returned = new DataTable();
            if (_EmployeeID == 0)
                return Returned;

            string strStatus = ((int)TicketStatus.Processing).ToString() + "," + ((int)TicketStatus.Waiting).ToString();

            string strSql = SearchStr + " where   TicketStatusTable.TicketStatus in (" + strStatus + ") ";
            strSql += " and ((TicketStatusTable.TicketPostponementDate is null) or (TicketStatusTable.TicketPostponementDate < GetDate()) )";
            strSql += " and (";
            strSql += "( TicketAssignedApplicant = " + _EmployeeID + ") ";
            if (_WorkGroup != 0)
                strSql += " or (TicketWorkGroup = " + _WorkGroup + ") ";
            strSql += ")";
            Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        public bool PickUpTicket()
        {
            bool Returned = true;
            if (_AssignedApplicant == 0)
                return false;
            TicketStatusDb objStatusDb = new TicketStatusDb();
            objStatusDb.Date = DateTime.Now;
            objStatusDb.Desc = StatusComment;
            objStatusDb.EmployeeID = _AssignedApplicant;
            objStatusDb.Status = (int)TicketStatus.Processing;
            objStatusDb.TicketID = ID;
            string strFromClause = " FROM dbo.CRMTicket INNER JOIN  " +
                 " (SELECT        derivedtbl_1.TicketID, CRMTicketStatus_1.TicketStatus " +
                 " FROM            (SELECT        TicketID, MAX(StatusID) AS MaxStatusID " +
                  " FROM            dbo.CRMTicketStatus " +
                  " GROUP BY TicketID) AS derivedtbl_1 INNER JOIN " +
                  " dbo.CRMTicketStatus AS CRMTicketStatus_1 ON derivedtbl_1.MaxStatusID = CRMTicketStatus_1.StatusID AND derivedtbl_1.TicketID = CRMTicketStatus_1.TicketID) " +
                  " AS StatusTable ON dbo.CRMTicket.TicketID = StatusTable.TicketID " +
                  " WHERE        (dbo.CRMTicket.TicketID = " + _ID + ") AND (TicketWorkGroup = " + _WorkGroup + ") " +
                  " AND (TicketAssignedApplicant = 0) AND StatusTable.TicketStatus=" + ((int)TicketStatus.Created).ToString() + "";
            string strSql = " begin tran Trans1 ;";
            strSql += " declare @Count int;" +
    "     set @Count = (select count(CRMTicket.TicketID) as Exp " + strFromClause + ") ";
            strSql += " if @Count = 0 goto rolLine; ";
            strSql += " UPDATE CRMTicket " +
              " SET TicketAssignedApplicant = " + _AssignedApplicant +
             strFromClause + ";";
            strSql += " set @Count = (SELECT        COUNT(1) AS Expr1 " +
              " FROM            dbo.CRMTicket " +
                " WHERE        (TicketID = " + ID + ") AND (TicketAssignedApplicant = " + _AssignedApplicant + ")) ";
            strSql += " if @Count = 0 goto rolLine ";
            strSql += objStatusDb.AddStr;
            strSql += "CommitLine: commit TRAN Trans1;select 1 as exp1;return;" +
                " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1  ";
            object objTemp = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objTemp.ToString() == "-1")
                Returned = false;

            return Returned;
        }
        enum TicketStatus
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
