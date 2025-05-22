using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationResubmissionDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationResubmissionDb()
        { }
        public ReservationResubmissionDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ID;
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
        string _IDs;
        public string IDs { set => _IDs = value; }
        int _ResubmissionType;

        public int ResubmissionType
        {
            get { return _ResubmissionType; }
            set { _ResubmissionType = value; }
        }
        string _ResubmissionTypeIDs;

        public string ResubmissionTypeIDs
        {
            get { return _ResubmissionTypeIDs; }
            set { _ResubmissionTypeIDs = value; }
        }

        #region Reservation
        int _ReservationID;

        public int ReservationID
        {
            get { return _ReservationID; }
            set { _ReservationID = value; }
        }
        DateTime _ReservationDate;
        public DateTime ReservationDate
        {
            set
            {
                _ReservationDate = value;
            }
            get
            {
                return _ReservationDate;
            }
        }
        DateTime _ReservationContractingDate;
        public DateTime ReservationContractingDate
        {
            set
            {
                _ReservationContractingDate = value;
            }
            get
            {
                return _ReservationContractingDate;
            }
        }
        string _ReservationNote;
        public string ReservationNote
        {
            set
            {
                _ReservationNote = value;
            }
            get
            {
                return _ReservationNote;
            }
        }
        int _ReservationStatus;
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }
            get
            {
                return _ReservationStatus;
            }
        }
        string _UnitFullName;
        public string UnitFullName
        {
            set
            {
                _UnitFullName = value;
            }
            get
            {
                return _UnitFullName;
            }
        }
        string _TowerName;
        public string TowerName
        {
            set
            {
                _TowerName = value;
            }
            get
            {
                return _TowerName;
            }
        }
        string _ProjectName;
        public string ProjectName
        {
            set
            {
                _ProjectName = value;
            }
            get
            {
                return _ProjectName;
            }
        }
        string _CustomerFullName;
        public string CustomerFullName
        {
            set
            {
                _CustomerFullName = value;
            }
            get
            {
                return _CustomerFullName;
            }
        }
        #endregion
        string _ReservationIDs;

        public string ReservationIDs
        {

            set { _ReservationIDs = value; }
        }
        DataTable _UnitTable;
        public DataTable UnitTbale
        {
            get { return _UnitTable; }
            set
            { _UnitTable = value; }
        }
        string _CheckIDs;

        public string CheckIDs
        {
            get { return _CheckIDs; }
            set { _CheckIDs = value; }
        }
        string _UnitIDs;
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
            get { return _UnitIDs; }
        }
        string _CustomerIDs;
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
            get { return _CustomerIDs; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        bool _HasEndDate;

        public bool HasEndDate
        {
            get { return _HasEndDate; }
            set { _HasEndDate = value; }
        }
        DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        int _ResubmissionStatus;

        public int ResubmissionStatus
        {
            get { return _ResubmissionStatus; }
            set { _ResubmissionStatus = value; }
        }
        int _UsrIns;

        public int UsrIns
        {
            get { return _UsrIns; }
            set { _UsrIns = value; }
        }

        DateTime _TimIns;

        public DateTime TimIns
        {
            get { return _TimIns; }
            set { _TimIns = value; }
        }
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        int _UserID;
        public int UserID { set => _UserID = value; }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        bool _ResubmissionStartDateRange;

        public bool ResubmissionStartDateRange
        {
            get { return _ResubmissionStartDateRange; }
            set { _ResubmissionStartDateRange = value; }
        }
        DateTime _ResubmissionDateStart;

        public DateTime ResubmissionDateStart
        {
            get { return _ResubmissionDateStart; }
            set { _ResubmissionDateStart = value; }
        }
        DateTime _ResubmissionDateEnd;

        public DateTime ResubmissionDateEnd
        {
            get { return _ResubmissionDateEnd; }
            set { _ResubmissionDateEnd = value; }
        }

        bool _ResubmissionAlertDateRange;

        public bool ResubmissionAlertDateRange
        {
            get { return _ResubmissionAlertDateRange; }
            set { _ResubmissionAlertDateRange = value; }
        }
        DateTime _ResubmissionAlertDateStart;

        public DateTime ResubmissionAlertDateStart
        {
            get { return _ResubmissionAlertDateStart; }
            set { _ResubmissionAlertDateStart = value; }
        }
        DateTime _ResubmissionAlertDateEnd;

        public DateTime ResubmissionAlertDateEnd
        {
            get { return _ResubmissionAlertDateEnd; }
            set { _ResubmissionAlertDateEnd = value; }
        }



        bool _IsLegal;

        public bool IsLegal
        {
            get { return _IsLegal; }
            set { _IsLegal = value; }
        }
        string _Serial;

        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }
        bool _HasAlarm;

        public bool HasAlarm
        {
            get { return _HasAlarm; }
            set { _HasAlarm = value; }
        }
        DateTime _AlarmDate;

        public DateTime AlarmDate
        {
            get { return _AlarmDate; }
            set { _AlarmDate = value; }
        }
        bool _HasAlert;
        public bool HasAlert { get => _HasAlert; set => _HasAlert = value; }
        DateTime _AlertDate;
        public DateTime AlertDate
        { set => _AlertDate = value; get => _AlertDate; }

        int _Alert;
        public int Alert { set => _Alert = value; get => _Alert; }
        /// <summary>
        /// AlertStatus =0 =>NotSpecified
        /// 1 : due dated even if alerted
        /// 2 : due date not alerted
        /// </summary>
        int _AlertStatus;
        public int AlertStatus
        { set => _AlertStatus = value; get => _AlertStatus; }

        bool _HasConfirmation;


        public bool HasConfirmation
        {
            get { return _HasConfirmation; }
            set { _HasConfirmation = value; }
        }
        DateTime _ConfirmationDate;

        public DateTime ConfirmationDate
        {
            get { return _ConfirmationDate; }
            set { _ConfirmationDate = value; }
        }
        string _Lawyer;

        public string Lawyer
        {
            get { return _Lawyer; }
            set { _Lawyer = value; }
        }
        string _LegalSerial;

        public string LegalSerial
        {
            get { return _LegalSerial; }
            set { _LegalSerial = value; }
        }
        string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public static string LastSerial
        {
            get
            {
                string Returned = "SELECT        dbo.CRMReservationResubmissionLegal.ResubmissionSerial " +
                " FROM            dbo.CRMReservationResubmissionLegal INNER JOIN " +
                " (SELECT        MAX(ResubmissionID) AS MaxResubMission " +
                " FROM            dbo.CRMReservationResubmissionLegal AS CRMReservationResubmissionLegal_1) AS derivedtbl_1 ON  " +
                  "  dbo.CRMReservationResubmissionLegal.ResubmissionID = derivedtbl_1.MaxResubMission ";
                Returned = "SELECT        TOP (1) ResubmissionSerial " +
                   " FROM            dbo.CRMReservationResubmissionLegal " +
                   " WHERE        (isnumeric " +
                   " ((SELECT        TOP (1) Value " +
                   " FROM            dbo.Split(dbo.CRMReservationResubmissionLegal.ResubmissionSerial, '/') AS Split_1)) = 1) AND (ResubmissionSerial LIKE '%/%') " +
                    " ORDER BY CONVERT(int, " +
                    " (SELECT        TOP (1) Value " +
                    " FROM            dbo.Split(dbo.CRMReservationResubmissionLegal.ResubmissionSerial, '/') AS Split_1)) DESC, CONVERT(int, " +
                             " (SELECT        TOP (1) Value " +
                             " FROM            dbo.Split(dbo.CRMReservationResubmissionLegal.ResubmissionSerial, '/') AS Split_1 " +
                               " WHERE        (Id > 1))) DESC";
                object objTemp = SysData.SharpVisionBaseDb.ReturnScalar(Returned);
                if (objTemp != null)
                    return objTemp.ToString();
                else
                    return "";
            }
        }
        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        bool _AllResubmission;

        public bool AllResubmission
        {
            get { return _AllResubmission; }
            set { _AllResubmission = value; }
        }

        public string AddStr
        {
            get
            {

                double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
                string Returned = "";
                string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
                Returned = " begin transaction  Trans1;";
                Returned += "insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                     " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns,ResubmissionAlertDate) " +
                     " values (" + _ReservationID + "," + _ResubmissionType + ",'" + _Desc + "'," + dblStartDate + "," + strEnd + "," +
                     SysData.CurrentUser.ID + ",GetDate()," + strAlertDate + ") ";
                if (_IsLegal)
                {
                    string strAlarm = _HasAlarm ? SysUtility.Approximate(_AlarmDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
                    string strConfimation = _HasConfirmation ? SysUtility.Approximate(_ConfirmationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";


                    Returned += " declare @ID int ; " +
                        " set @ID = (select @@IDENTITY ) ";
                    Returned += " insert into    dbo.CRMReservationResubmissionLegal  " +
                        " ( ResubmissionID, ResubmissionSerial, ResubmissionAlarmDate, ResubmissionConfirmationDate" +
                        ", ResubmissionLawyer, ResubmissionLegalSerial, ResubmissionAction, ResubmissionNote) " +
                        "select @ID  as ResubmissionID,'" + _Serial + "' as ResubmissionSerial," + strAlarm + " as AlarmDate," +
                        strConfimation + " as ConfirmationDate,'" + _Lawyer + "' as Lawyer,'" + _LegalSerial + "' as LegalSerial" +
                        " ,'" + _Action +
                        "' as Action,'" + _Note + "' as Note " +
                        " from  CRMReservationResubmission where ResubmissionReservation= " + _ReservationID + " and   ResubmissionID =@ID ";
                    Returned += " declare @Count int ; set @Count = (SELECT  COUNT(dbo.CRMReservationResubmissionLegal.ResubmissionID) AS Expr1 " +
                         " FROM            dbo.CRMReservationResubmissionLegal INNER JOIN " +
                         " dbo.CRMReservationResubmission ON dbo.CRMReservationResubmissionLegal.ResubmissionID = dbo.CRMReservationResubmission.ResubmissionID " +
                          " WHERE        (dbo.CRMReservationResubmission.ResubmissionReservation <> " + _ReservationID + ") " +
                         " GROUP BY dbo.CRMReservationResubmissionLegal.ResubmissionSerial " +
                            " HAVING        (dbo.CRMReservationResubmissionLegal.ResubmissionSerial = '" + _Serial + "') ) " +
                            " if @Count >0  goto rolLine ; ";

                }
                Returned += " commitline: commit transaction Trans1;select  @ID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
                string Returned = "";
                Returned = " begin transaction  Trans1;";
                Returned += "update CRMReservationResubmission   set ResubmissionType = " + _ResubmissionType +
                    ", ResubmissionDesc='" + _Desc + "'" +
                    ",ResubmissionDate=" + dblStartDate +
                    ", ResubmissionEndDate=" + strEnd +
                    " where ResubmissionReservation=" + _ReservationID + " and ResubmissionID=" + _ID;
                if (_IsLegal)
                {
                    string strAlarm = _HasAlarm ? SysUtility.Approximate(_AlarmDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
                    string strConfimation = _HasConfirmation ? SysUtility.Approximate(_ConfirmationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";

                    Returned += " declare @Count int ; set @Count = (SELECT  COUNT(dbo.CRMReservationResubmissionLegal.ResubmissionID) AS Expr1 " +
                       " FROM            dbo.CRMReservationResubmissionLegal INNER JOIN " +
                       " dbo.CRMReservationResubmission ON dbo.CRMReservationResubmissionLegal.ResubmissionID = dbo.CRMReservationResubmission.ResubmissionID " +
                        " WHERE        (dbo.CRMReservationResubmission.ResubmissionReservation <> " + _ReservationID + ") " +
                       " GROUP BY dbo.CRMReservationResubmissionLegal.ResubmissionSerial " +
                          " HAVING        (dbo.CRMReservationResubmissionLegal.ResubmissionSerial = '" + _Serial + "') ) " +
                          " if @Count >0  goto rolLine ; ";

                    Returned += "  delete from   dbo.CRMReservationResubmissionLegal where ResubmissionID =" + _ID;
                    Returned += " insert into    dbo.CRMReservationResubmissionLegal  " +
                        " ( ResubmissionID, ResubmissionSerial, ResubmissionAlarmDate, ResubmissionConfirmationDate" +
                        ", ResubmissionLawyer, ResubmissionLegalSerial, ResubmissionAction, ResubmissionNote) " +
                        "select " + _ID + " as ResubmissionID,'" + _Serial + "' as ResubmissionSerial," + strAlarm + " as AlarmDate," +
                        strConfimation + " as ConfirmationDate,'" + _Lawyer + "' as Lawyer,'" + _LegalSerial + "' as Serial" +
                        " ,'" + _Action +
                        "' as Action,'" + _Note + "' as Note " +
                        " from  CRMReservationResubmission where ResubmissionReservation= " + _ReservationID + " and   ResubmissionID = " + _ID;

                }
                Returned += " commitline: commit transaction Trans1;select  " + _ID + " as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";

                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from CRMReservationResubmission where ResubmissionReservation= " + _ReservationID +
                    " and  ResubmissionID = " + _ID;
                return Returned;
            }
        }
        public static string ReservationSearchStr
        {
            get => @"SELECT        CRMReservation.ReservationID as ResubmissionReservationID, ReservationDate as ResubmissionReservationDate,ReservationContractingDate as  ResubmissionReservationContractingDate,ReservationNote as ResubmissionReservationNote,ReservationStatus as  ResubmissionReservationStatus
,UnitTable.UnitFullName as ResubmissionUnitFullName, UnitTable.TowerName as ResubmissionTowerName, UnitTable.ProjectName as ResubmissionProjectName, CustomerTable.CustomerFullName as ResubmissionCustomerFullName
 FROM dbo.CRMReservation 
  inner join (SELECT dbo.CRMReservationCustomer.ReservationID,min(dbo.CRMCustomer.CustomerID) as MinCustomerID , CASE WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 1 THEN MAX(CustomerFullName)  WHEN COUNT(dbo.CRMCustomer.CustomerFullName) = 2 THEN MAX(CustomerFullName) + '&' + MIN(CustomerFullName)  ELSE MAX(CustomerFullName) + '&..&' + MIN(CustomerFullName) END AS CustomerFullName ,CASE WHEN COUNT(distinct dbo.COMMONCountry.CountryNationalityA) = 1 THEN MAX(dbo.COMMONCountry.CountryNationalityA)  WHEN COUNT(distinct dbo.COMMONCountry.CountryNationalityA) = 2 THEN MAX(dbo.COMMONCountry.CountryNationalityA) + '&' + MIN(dbo.COMMONCountry.CountryNationalityA)  ELSE MAX( dbo.COMMONCountry.CountryNationalityA) + '&..&' + MIN( dbo.COMMONCountry.CountryNationalityA) END AS CustomerNationality  FROM    dbo.CRMReservationCustomer INNER JOIN  dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID  left outer JOIN  dbo.COMMONCountry  ON dbo.CRMCustomer.CustomerNationality = dbo.COMMONCountry.CountryID  GROUP BY dbo.CRMReservationCustomer.ReservationID ) as CustomerTable 
  on CRMReservation.ReservationID = CustomerTable.ReservationID 
  inner join (SELECT DISTINCT  TOP (100) PERCENT CASE WHEN COUNT(UnitFullName) = 1 THEN MAX(dbo.CRMUnit.UnitFullName) WHEN COUNT(UnitFullName)   = 2 THEN MAX(UnitFullName) + '&' + MIN(UnitFullName) ELSE MAX(UnitFullName) + '&..&' + MIN(UnitFullName) END AS UnitFullName,   CASE WHEN COUNT(UnitNameA) = 1 THEN MAX(dbo.CRMUnit.UnitNameA) WHEN COUNT(UnitNameA)   = 2 THEN MAX(UnitNameA) + '&' + MIN(UnitNameA) ELSE MAX(UnitNameA) + '&..&' + MIN(UnitNameA) END AS UnitNameA ,max(CRMUnit.CurrentReservation) as CurrentUnitReservation , dbo.CRMReservationUnit.ReservationID AS CurrentReservation,max( CASE WHEN RPCell_1.CellAlterName IS NULL OR  RPCell_1.CellAlterName = '' THEN RPCell_1.CellNameA ELSE RPCell_1.CellAlterName END) AS TowerName,max(case when RPCell_2.CellAlterName is null or RPCell_2.CellAlterName ='' then RPCell_2.CellNameA else RPCell_2.CellAlterName end) AS ProjectName ,sum(case when CRMUnit.UnitDeliveryDate is null then 0 else 1 end) as DeliveredCount,max(CRMUnit.UnitDeliveryDate) as ReservationRealDeliveryDate,max(RPCell_1.CellDeliverDate) TowerDeliveryDate ,max(dbo.CRMUnitCell.CellID) as FloorID,max( dbo.CRMUnitModel.ModelNameA) As ModelName,max(CRMUnit.CurrentReservation) as MaxCurrentReservation  ,CASE WHEN COUNT(UnitSurvey) = 1 THEN convert(varchar(20), MAX(dbo.CRMUnit.UnitSurvey)) WHEN COUNT(UnitSurvey)   = 2 THEN convert(varchar(20),MAX(UnitSurvey))  + '&' + convert(varchar(20),MIN(UnitSurvey)) ELSE convert(varchar(20),MAX(UnitSurvey)) + '&..&' + convert(varchar(20),MIN(UnitSurvey)) END AS UnitSurvey ,max(RPCell.CellFamilyID) as ProjectID ,max(UnitPricePerMeter) as NativeUnitPrice  FROM  dbo.CRMUnit left outer JOIN CRMUnitModel  on dbo.CRMUnit.UnitModel = dbo.CRMUnitModel.ModelID  inner join  dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN  dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN  dbo.RPCell AS RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN  dbo.RPCell AS RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN  dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID  GROUP BY dbo.CRMReservationUnit.ReservationID  ) as UnitTable 
 on CRMReservation.ReservationID = UnitTable.CurrentReservation ";
        }
        public static string SearchStr
        {
            get
            {
                string strReservation = ReservationSearchStr;
                string strLegal = "SELECT  ResubmissionID AS LegalResubmissionID, ResubmissionSerial, ResubmissionAlarmDate, ResubmissionConfirmationDate, ResubmissionLawyer, ResubmissionLegalSerial, ResubmissionAction,  " +
                         " ResubmissionNote " +
                         " FROM            dbo.CRMReservationResubmissionLegal";
                string strUser = "SELECT        dbo.UMSUser.UID as ResubmissionUID, dbo.UMSUser.UN as ResubmissionUName " +
                    " , dbo.HRApplicant.ApplicantFirstName  as ResubmissionEmployeeName, dbo.HRApplicantWorker.ApplicantID AS ResubmissionEmployeeID " +
                     " FROM            dbo.HRApplicant right outer JOIN " +
                      " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID right outer JOIN " +
                         " dbo.UMSUser ON dbo.HRApplicantWorker.ApplicantUser = dbo.UMSUser.UID ";

                string Returned = "SELECT        ResubmissionID, ResubmissionReservation, CRMReservationResubmission.ResubmissionType, ResubmissionDesc, ResubmissionDate, ResubmissionEndDate, UsrIns as ResubmissionUsrIns, TimIns as ResubmissionTimIns " +
                    ",  dbo.CRMReservationResubmission.ResubmissionAlertDate, dbo.CRMReservationResubmission.ResubmissionAlert" +
                    ",ResubmissionTypeTable.*,UserTable.*,LegalTable.*,ReservationTable.* " +
                      " FROM            dbo.CRMReservationResubmission " +
                      " inner join (" + ResubmissionTypeDb.SearchStr + ") as ResubmissionTypeTable " +
                      " on   dbo.CRMReservationResubmission.ResubmissionType = ResubmissionTypeTable.ResubmissionTypeID " +
                      @" inner join (" + strReservation + @") as ReservationTable
 on  dbo.CRMReservationResubmission.ResubmissionReservation = ReservationTable.ResubmissionReservationID 
" +
                      " left outer join (" + strUser + ") as UserTable " +
                      " on  dbo.CRMReservationResubmission.UsrIns = UserTable.ResubmissionUID  " +
                      "  left outer join (" + strLegal + ") as LegalTable " +
                      "on dbo.CRMReservationResubmission.ResubmissionID = LegalTable.LegalResubmissionID  ";
                return Returned;
            }
        }

        public string StrSearch
        {
            get
            {
                string Returned = SearchStr;
                if (_UserID != 0 && _AlertStatus == 1)
                {
                    Returned += @"  INNER JOIN
                         dbo.CRMUserResubmissionType ON dbo.CRMReservationResubmission.ResubmissionType = dbo.CRMUserResubmissionType.ResubmissionType ";
                }

                Returned += " where (1=1) ";

                if (_ReservationID != 0)
                    Returned += " and ResubmissionReservation = " + _ReservationID;
                if (_ReservationIDs != null && _ReservationIDs != "")
                    Returned += " and ResubmissionReservation in (" + _ReservationIDs + ") ";
                if (_ResubmissionStatus == 1)
                    Returned += " and (ResubmissionEndDate is null or ResubmissionEndDate >=dbo.GetApproximateDate(GetDate()) ) ";
                if (_ResubmissionType != 0)
                    Returned += " and CRMReservationResubmission.ResubmissionType=" + _ResubmissionType;
                if (_ResubmissionTypeIDs != null && _ResubmissionTypeIDs != "")
                    Returned += " and CRMReservationResubmission.ResubmissionType in (" + _ResubmissionTypeIDs + ")";
                if (_ResubmissionStartDateRange)
                {
                    double dblStart = SysUtility.Approximate(_ResubmissionDateStart.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEnd = SysUtility.Approximate(_ResubmissionDateEnd.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and ResubmissionDate >=" + dblStart + " and ResubmissionDate < " + dblEnd;
                }
                if (_ResubmissionAlertDateRange)
                {
                    double dblStart = SysUtility.Approximate(_ResubmissionAlertDateStart.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblEnd = SysUtility.Approximate(_ResubmissionAlertDateEnd.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and ResubmissionAlertDate >=" + dblStart + " and ResubmissionAlertDate < " + dblEnd;
                }
                if (_Serial != null && _Serial != "")
                    Returned += " and ResubmissionSerial like '%" + _Serial + "%' ";
                string strMax = @"SELECT        ResubmissionReservation, ResubmissionType, MAX(ResubmissionID) AS MaxResubmissionID
FROM           (" + Returned + @") as ReturnTable
GROUP BY ResubmissionReservation, ResubmissionType";
                if (!_AllResubmission)
                    Returned = @"select MainResubmissionTable.* 
from (" + Returned + @") as MainResubmissionTable   
 inner join (" + strMax + @") as MaxResubmissionTable 
 on MainResubmissionTable.ResubmissionReservation = MaxResubmissionTable.ResubmissionReservation   " +
                                                 " and  MainResubmissionTable.ResubmissionType = MaxResubmissionTable.ResubmissionType " +
                                                 " and MainResubmissionTable.ResubmissionID = MaxResubmissionTable.MaxResubmissionID ";
                if (_AlertStatus != 0)
                    Returned += "  and (ResubmissionEndDate is null or ResubmissionEndDate >GetDate()) ";
                if (_AlertStatus == 1)
                {
                    Returned += " and ResubmissionAlertDate < GetDate() ";
                }
                else if (_AlertStatus == 2)
                {
                    Returned += " and ResubmissionAlertDate < GetDate() and ResubmissionAlert =0 ";
                }
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ResubmissionID"].ToString());
            _ReservationID = int.Parse(objDr["ResubmissionReservation"].ToString());
            _ResubmissionType = int.Parse(objDr["ResubmissionType"].ToString());
            _Desc = objDr["ResubmissionDesc"].ToString();
            _Date = DateTime.Parse(objDr["ResubmissionDate"].ToString());
            if (objDr["ResubmissionEndDate"].ToString() != "")
            {
                _HasEndDate = true;
                _EndDate = DateTime.Parse(objDr["ResubmissionEndDate"].ToString());

            }

            int.TryParse(objDr["ResubmissionUsrIns"].ToString(), out _UsrIns);

            DateTime.TryParse(objDr["ResubmissionTimIns"].ToString(), out _TimIns);
            _UserName = UMS.UMSDataBase.UserDb.GetDecryptedStr(objDr["ResubmissionUName"].ToString());
            _EmployeeName = objDr["ResubmissionEmployeeName"].ToString();
            int.TryParse(objDr["ResubmissionEmployeeID"].ToString(), out _EmployeeID);
            //ResubmissionID AS LegalResubmissionID, ResubmissionSerial, ResubmissionAlarmDate, ResubmissionConfirmationDate, ResubmissionLawyer, ResubmissionLegalSerial, ResubmissionAction, 
            //          ResubmissionNote
            _IsLegal = false;
            if (objDr["LegalResubmissionID"].ToString() != "")
                _IsLegal = true;
            _Serial = objDr["ResubmissionSerial"].ToString();
            _HasAlarm = DateTime.TryParse(objDr["ResubmissionAlarmDate"].ToString(), out _AlarmDate);
            _HasConfirmation = DateTime.TryParse(objDr["ResubmissionConfirmationDate"].ToString(), out _ConfirmationDate);
            _Lawyer = objDr["ResubmissionLawyer"].ToString();
            _LegalSerial = objDr["ResubmissionLegalSerial"].ToString();
            _Action = objDr["ResubmissionAction"].ToString();
            _Note = objDr["ResubmissionNote"].ToString();
            _HasAlert = false;
            if (objDr.Table.Columns["ResubmissionAlertDate"] != null && objDr["ResubmissionAlertDate"].ToString() != "")
            {
                DateTime.TryParse(objDr["ResubmissionAlertDate"].ToString(), out _AlertDate);
            }

            if (objDr.Table.Columns["ReservationDate"] != null)
                DateTime.TryParse(objDr["ReservationDate"].ToString(), out _ReservationDate);

            if (objDr.Table.Columns["ResubmissionReservationContractingDate"] != null)
                DateTime.TryParse(objDr["ResubmissionReservationContractingDate"].ToString(), out _ReservationContractingDate);

            if (objDr.Table.Columns["ResubmissionReservationNote"] != null)
                _ReservationNote = objDr["ResubmissionReservationNote"].ToString();

            if (objDr.Table.Columns["ResubmissionReservationStatus"] != null)
                int.TryParse(objDr["ResubmissionReservationStatus"].ToString(), out _ReservationStatus);

            if (objDr.Table.Columns["ResubmissionUnitFullName"] != null)
                _UnitFullName = objDr["ResubmissionUnitFullName"].ToString();

            if (objDr.Table.Columns["ResubmissionTowerName"] != null)
                _TowerName = objDr["ResubmissionTowerName"].ToString();

            if (objDr.Table.Columns["ResubmissionProjectName"] != null)
                _ProjectName = objDr["ResubmissionProjectName"].ToString();

            if (objDr.Table.Columns["ResubmissionCustomerFullName"] != null)
                _CustomerFullName = objDr["ResubmissionCustomerFullName"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            object objChanged = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            _IsChanged = objChanged != null && objChanged.ToString() != "-1";
        }
        public void Edit()
        {
            string strSql = EditStr;
            object objChanged = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            _IsChanged = objChanged != null && objChanged.ToString() != "-1";
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = StrSearch;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddManyReservationResubmission()
        {
            if (_ReservationIDs == null || _ReservationIDs == "")
                return;
            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strReservationIDs = "";

            strReservationIDs = _ReservationIDs;
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
            string strSql = "update   dbo.CRMReservationResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                  " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                  " AND (ResubmissionReservation IN (" + _ReservationIDs + "))  " +
                  "  AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            strSql += " insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns,ResubmissionAlertDate)" +
                   "SELECT        ReservationID, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns," + strAlertDate + @" as AlertDate " +
                   " FROM            dbo.CRMReservation " +
                    " WHERE        (ReservationID IN (" + strReservationIDs + ")) ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void AddManyUnitResubmission()
        {
            if (_UnitIDs == null || _UnitIDs == "")
                return;
            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strReservationIDs = @"SELECT        CurrentReservation
FROM            dbo.CRMUnit
WHERE        (UnitID IN (" + _UnitIDs + @")) and CurrentReservation > 0  ";
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";

            //strReservationIDs = _ReservationIDs;
            string strSql = "update   dbo.CRMReservationResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                " from dbo.CRMReservationResubmission inner join (" + strReservationIDs + ") as ReservationTable  " +
                " on dbo.CRMReservationResubmission.ResubmissionReservation = ReservationTable.CurrentReservation " +
                 " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                 //" AND (ResubmissionReservation IN (" + _ReservationIDs + "))  " +
                 "  AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            strSql += " insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns,ResubmissionAlertDate)" +
                   "SELECT        CurrentReservation, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns," + strAlertDate + @" as AlertDate " +
                   " FROM    (" + strReservationIDs + ") as ReservationTable ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.CRMUnitResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                  " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                  " AND (ResubmissionUnit IN (" + _UnitIDs + "))  " +
                  "  AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            strSql += " insert into CRMUnitResubmission (ResubmissionUnit, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns)" +
                   "SELECT        UnitID, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns " +
                   " FROM            dbo.CRMUnit " +
                    " WHERE        (UnitID IN (" + _UnitIDs + ")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void AddManyCustomerResubmission()
        {
            if (_CustomerIDs == null || _CustomerIDs == "")
                return;
            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strSql = @" update CRMCustomerResubmission set ResubmissionEndDate = DATEADD(DAY,-1,GetDate()) 
FROM            dbo.CRMCustomerResubmission
WHERE        (ResubmissionCustomer IN (" + _CustomerIDs + @")) AND (ResubmissionType = " + _ResubmissionType + @") AND (ResubmissionEndDate IS NULL OR
                         ResubmissionEndDate > GETDATE())";
            List<string> arrStr = new List<string>();
            arrStr.Add(strSql);
            strSql = @" insert into CRMCustomerResubmission ( ResubmissionCustomer, ResubmissionType, ResubmissionDesc, ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns
)
 SELECT        CustomerID, " + _ResubmissionType + @" AS ResubmissionType, '" + _Desc + @"' AS ResubmissionDesc, GETDATE() AS ResubmissionDate, " + strEnd + @" AS ResubmissionEndDate, " + SysData.CurrentUser.ID.ToString() + @" AS UsrIns, GETDATE() AS TimIns
FROM            dbo.CRMCustomer
WHERE        (CustomerID IN (" + _CustomerIDs + "))";
            arrStr.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void AddUnitExcelResubmission()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from CRMUnitResubmissionTemp ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "CRMUnitResubmissionTemp";
            objCopy.WriteToServer(_UnitTable);


            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strReservationIDs = "";
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
            strReservationIDs = _ReservationIDs;
            string strSql = "update   dbo.CRMReservationResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                @" from   dbo.CRMUnit INNER JOIN
                         dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                         dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID inner join CRMReservationResubmission " +
                "  on CRMReservationResubmission.ResubmissionReservation = CRMUnit.CurrentReservation " +
                @" inner join CRMUnitResubmissionTemp on CRMUnit.UnitFullName = CRMUnitResubmissionTemp.ID and (isnull(dbo.CRMUnitResubmissionTemp.Project,'') = '' or dbo.CRMUnitResubmissionTemp.Project = CRMProject.ProjectCode ) " +
                " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                 " AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            strSql += " insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns,ResubmissionAlertDate)" +
                   "SELECT        CurrentReservation, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns," + strAlertDate + @" as AlertDate " +
                   @" FROM              dbo.CRMUnit INNER JOIN
                         dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                         dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID  INNER JOIN " +
                   @" dbo.CRMUnitResubmissionTemp ON dbo.CRMUnit.UnitFullName = dbo.CRMUnitResubmissionTemp.ID  and (isnull(dbo.CRMUnitResubmissionTemp.Project,'') = '' or dbo.CRMUnitResubmissionTemp.Project = CRMProject.ProjectCode ) " +
                  " WHERE(dbo.CRMUnit.CurrentReservation > 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "update   dbo.CRMUnitResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
              @" from   dbo.CRMUnit INNER JOIN
                         dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                         dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID inner join CRMUnitResubmission " +
              "  on CRMUnitResubmission.ResubmissionUnit = CRMUnit.UnitID  " +
              @" inner join CRMUnitResubmissionTemp on CRMUnit.UnitFullName = CRMUnitResubmissionTemp.ID and (isnull(dbo.CRMUnitResubmissionTemp.Project,'') = '' or dbo.CRMUnitResubmissionTemp.Project = CRMProject.ProjectCode ) " +
              " WHERE     CRMUnit.CurrentReservation = 0 and   (ResubmissionType = " + _ResubmissionType + ") " +
               " AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";

            strSql += " insert into CRMUnitResubmission (ResubmissionUnit, ResubmissionType, ResubmissionDesc," +
                     " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns)" +
                 " SELECT        CRMUnit.UnitID, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                 "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns  " +
                 @" FROM              dbo.CRMUnit INNER JOIN
                         dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                         dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID  INNER JOIN " +
                 @" dbo.CRMUnitResubmissionTemp ON dbo.CRMUnit.UnitFullName = dbo.CRMUnitResubmissionTemp.ID  and (isnull(dbo.CRMUnitResubmissionTemp.Project,'') = '' or dbo.CRMUnitResubmissionTemp.Project = CRMProject.ProjectCode ) " +
                " WHERE(dbo.CRMUnit.CurrentReservation = 0)";


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void AddUnitExcelResubmission1()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(" delete from COMMONTempCode ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "COMMONTempCode";
            objCopy.WriteToServer(_UnitTable);


            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strReservationIDs = "";

            strReservationIDs = _ReservationIDs;
            string strSql = "update   dbo.CRMReservationResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                "from CRMReservationResubmission " +
                " inner join CRMUnit on CRMReservationResubmission.ResubmissionReservation = CRMUnit.CurrentReservation " +
                " inner join COMMONTempCode on CRMUnit.UnitFullName = COMMONTempCode.Code " +
                " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                 " AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            strSql += " insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns)" +
                   "SELECT        CurrentReservation, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns " +
                   " FROM            dbo.CRMUnit INNER JOIN " +
                   " dbo.COMMONTempCode ON dbo.CRMUnit.UnitFullName = dbo.COMMONTempCode.Code " +
                  " WHERE(dbo.CRMUnit.CurrentReservation > 0)";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void AddManyCheckResubmission()
        {
            if (_CheckIDs == null || _CheckIDs == "")
                return;
            double dblStartDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEnd = _HasEndDate ? dblEndDate.ToString() : "NULL";
            string strReservationIDs = "";

            strReservationIDs = "SELECT DISTINCT dbo.CRMReservationInstallment.ReservationID " +
             " FROM            dbo.CRMReservationInstallment INNER JOIN " +
            " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                         " dbo.GLCheckPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLCheckPayment.PaymentID " +
                         " where (1=1) ";
            // if(_CheckIDs  != null && _CheckIDs!= "")
            strReservationIDs += " and  dbo.GLCheckPayment.CheckID in (" + _CheckIDs + ") ";
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
            string strSql = "update   dbo.CRMReservationResubmission set ResubmissionEndDate =  dbo.GetApproximateDate(DATEADD(dd, - 1, GETDATE()))   " +
                " from dbo.CRMReservationResubmission inner join (" + strReservationIDs + ") as ReservationTable on dbo.CRMReservationResubmission.ResubmissionReservation = ReservationTable.ReservationID " +
                " WHERE        (ResubmissionType = " + _ResubmissionType + ") " +
                 //" AND (ResubmissionReservation IN (" + strReservationIDs + "))  " +
                 "  AND ((ResubmissionEndDate IS NULL) or (ResubmissionEndDate>=dbo.GetApproximateDate(GetDate())))  ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " insert into CRMReservationResubmission (ResubmissionReservation, ResubmissionType, ResubmissionDesc," +
                       " ResubmissionDate, ResubmissionEndDate, UsrIns, TimIns,ResubmissionAlertDate)" +
                   "SELECT        CRMReservation.ReservationID, " + _ResubmissionType + " as ResubmissionType,'" + _Desc + "' as ResubmissionDesc" +
                   "," + dblStartDate + " as ResubmissionDate," + strEnd + " as ResubmissionEndDate," + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns," + strAlertDate + @" as AlertDate " +
                   " FROM            dbo.CRMReservation " +
                   " inner join (" + strReservationIDs + ") as ReservationTable " +
                   " on CRMReservation.ReservationID = ReservationTable.ReservationID  ";
            //" WHERE        (ReservationID IN (" + strReservationIDs + ")) ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void SetAlert()
        {
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
            string strID = _IDs != null && _IDs != "" ? " and ResubmissionID in (" + _IDs + ")" : " and ResubmissionType=" + _ResubmissionType;
            string strSql = @"update CRMReservationResubmission set ResubmissionAlertDate =" + strAlertDate + @",ResubmissionAlert=0 
  where ResubmissionReservation in (" + _ReservationIDs + @") " + strID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void SetAlertSent()
        {
            string strAlertDate = _HasAlert ? (_AlertDate.ToOADate() - 2).ToString() : "NULL";
            string strID = _IDs != null && _IDs != "" ? " and ResubmissionID in (" + _IDs + ")" : " and ResubmissionType=" + _ResubmissionType;
            string strSql = @"update CRMReservationResubmission set ResubmissionAlert=1 
  where ResubmissionReservation in (" + _ReservationIDs + @") " + strID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        #endregion
    }
}
