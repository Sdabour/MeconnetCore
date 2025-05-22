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
    public class CampaignCustomerDb
    {
        #region Private Data
        protected int _ID;
        protected int _Campaign;
        protected int _Customer;
        protected string _CustomerName;
        string _CustomerMobile;
        string _CustomerHomePhone;

     
        protected string _EmployeeName;
        protected int _TotalCount;
        bool _Direction;
        int _Employee;
       string _CustomerIDs;
        string _ReservationIDs;
     
        string _UnitIDs;
        string _IDs;
       #region LastContactData
        int _ContactID;
        protected int _ContactType;
        protected bool _IsContacted;
        protected DateTime _ContactDate;
        protected string _ContactComment;
        protected int _TopicID;
        int _ContactStatus;/*
                            * 0 
                            * 1 contacted
                            * 2 failed to contact
                            * 3 due contacted no failure
                            * 4 deue contacted has failure
                            */
        int _FunctionalStatus;/*
                               * 
                               */
       // int _MonitorStatus;
        bool _WaitingAnotherContact;
        DateTime _CampaignDate;
        string _CampaignDesc;

        DateTime _AnotherContactDate;
        int _ContactEmployee;
        string _ContactEmployeeCode;
        string _ContactEmployeeName;
        int _ContactBranch;
        int _ContactCount;
        int _SucceededContacCount;
        DataTable _CampaignCustomerTable;

       #endregion
        #region Monitoring
        bool _WaitingMonitor;
        DateTime _WaitingMonitoringDate;
        int _MonitoringID;
        DateTime _MonitoringDate;
        string _MonitoringDesc;
        int _MonitoringStatus;/*
                            * 0 
                            * 1 Monitored
                            * 2 
                            */

        bool _IsMonitoringDate;
        DateTime _StartMonitorDate;
        DateTime _EndMonitorDate;

        int _MonitoringEmployee;
        string _MonitoringEmployeeCode;
        string _MonitoringEmployeeName;
        #endregion
        #region Private Data For Search
        //int _ContactStatus;
        int _EmployeeStatus;/*
                             * 0 dont care
                             * 1 assigned to employee
                             * 2 not asigned
                             */
        bool _IsEmployeeGroup;
        bool _IsCampaignGroup;
        bool _IsCustomerGroup;
        bool _IsTowerGroup;
        bool _IsProjectGroup;
        bool _IsMonthGroup;
        bool _IsYearGroup;
        int _DealStatus;/*
                         * 0 dont care
                         * 1 Contacted
                         * 2 contacted waiting contact
                         * 3 failed to contact
                         */
       #endregion
        #region Data ForReciption
        int _ReceptionStatus;
        int _ReceptionProcessedStatus;
        bool _IsReception;
        int _ReceptionistID;
        string _ReceptionistName;
        DateTime _ReceptionDate;
        bool _ReceptionProcessed;
        #endregion
        #endregion
        #region Constractors
        public CampaignCustomerDb()
        {
        }
        public CampaignCustomerDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public CampaignCustomerDb(DataRow objDR)
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
        public int Campaign
        {
            set
            {
                _Campaign = value;
            }
            get
            {
                return _Campaign;
            }
        }

        public int Customer
        {
            set
            {
                _Customer = value;

            }
            get
            {
                return _Customer;
            }
        }
        public int Contact
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
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
        }
        public DateTime ContactDate
        {
            set
            {
                _ContactDate = value;
            }
            get
            {
                return _ContactDate;
            }
        }
        public string ContactComment
        {
            set
            {
                _ContactComment = value;
            }
            get
            {
                return _ContactComment;
            }
        }
        public int TopicID
        {
            set
            {
                _TopicID = value;
            }
            get
            {
                return _TopicID;
            }
        }
        public bool IsContacted
        {
            set
            {
                _IsContacted = value;
            }
            get
            {
                return _IsContacted;
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
        public int ContactID
        {
            set
            {
                _ContactID = value;
            }
            get
            {
                return _ContactID;
            }

        }
        public int ContactStatus
        {
            set
            {
                _ContactStatus = value;
            }
            get
            {
                return _ContactStatus;
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
        public int MonitoringStatus
        {
            set
            {
                _MonitoringStatus = value;
            }
            get
            {
                return _MonitoringStatus;
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
        
        public DateTime AnotherContactDate
        {
            set
            {
                _AnotherContactDate = value;
            }
            get
            {
                return _AnotherContactDate;
            }
        }
        public bool WaitingMonitor
        {
            set
            {
                _WaitingMonitor = value;
            }
            get
            {
                return _WaitingMonitor;
            }
        }
        public DateTime WaitingMonitoringDate
        {
            set
            {
                _WaitingMonitoringDate = value;
            }
            get
            {
                return _WaitingMonitoringDate;
            }
        }

        public string MonitoringDesc
        {
            set
            {
                _MonitoringDesc = value;
            }
        }
      

        public int MonitoringEmployee
        {
            set
            {
                _MonitoringEmployee = value;
            }
            get
            {
                return _MonitoringEmployee;
            }
        }
        public int ContactEmployee
        {
            set
            {
                _ContactEmployee = value;
            }
            get
            {
                return _ContactEmployee;
            }
        }
        public int ContactBranch
        {
            set
            {
                _ContactBranch = value;
            }
            get
            {
                return _ContactBranch;
            }
        }
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public int EmployeeStatus
        {
            set
            {
                _EmployeeStatus = value;
            }
        }
        public int DealStatus
        {
            set
            {
                _DealStatus = value;
            }
        }
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

        public DataTable CampaignCustomerTable
        {
            set
            {
                _CampaignCustomerTable = value;
            }
        }
        public bool IsMonitoringDate
        {
            set
            {
                _IsMonitoringDate = value;
            }
        }
        public DateTime StartMonitorDate
        {
            set
            {
                _StartMonitorDate = value;
            }
        }
        public DateTime EndMonitorDate
        {
            set
            {
                _EndMonitorDate = value;
            }
        }

        public string ContactEmployeeCode
        {
            get
            {
                return _ContactEmployeeCode;
            }
        }
        public string ContactEmployeeName
        {
            get
            {
                return _ContactEmployeeName;
            }
        }
        public int ContactCount
        {
            get
            {
                return _ContactCount;
            }
        }
        public int SucceededContactCount
        {
            get 
            {
                return _SucceededContacCount;
            }
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
        int _Project;
        public int Project
        {
            get { return _Project; }
            set { _Project = value; }
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
        #endregion
        #region Data To Be Used in Sum Only + CampaignDesc
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }

        }
        public string CustomerHomePhone
        {
            get 
            { 
                return _CustomerHomePhone; 
            }

        }
        public string CustomerMobile
        {
            get 
            { 
                return _CustomerMobile;
            }

        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }
        #endregion
        public string SearchStr
        {
            get
            {
                string strREservationCustomer = "";
                if(_ReservationIDs!= null&&_ReservationIDs !="")
                strREservationCustomer = @"SELECT    distinct    dbo.CRMCampaignCustomer.CampaignCustomerID,dbo.CRMReservationCustomer.ReservationID
FROM            dbo.CRMReservationCustomer INNER JOIN
                         dbo.CRMCampaignCustomer_ICustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCampaignCustomer_ICustomer.Customer INNER JOIN
                         dbo.CRMCampaignCustomer ON dbo.CRMCampaignCustomer_ICustomer.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID
WHERE        (dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs +@")) AND (dbo.CRMCampaignCustomer.Campaign = "+ _Campaign + @")";
                string strContact = "SELECT  CampaignContactID AS LastCampaignContactID, CampaignCustomerID AS ContactedCampaignCustomerID, ContactType AS LastContactType, "+
                    " ContactDate AS LastContactDate, ContactComment AS LastContactComment, ContactStatus AS LastContactStatus, "+
                      " ContactFunctionalStatus AS LastContactFunctionalStatus, ContactWaitingAnotherContact AS LastContactWaitingAnotherContact, "+
                      " ContactWaitingDate AS LastContactWaitingDate, ContactEmployee AS LastContactEmployee, ContactBranch "+
                      " FROM    dbo.CRMCampaignCustomerContact ";
                string strLastSucceededContact = "";
                string strLastContactEmployee = "SELECT  dbo.HRApplicantWorker.ApplicantID AS LastContactEmployeeID, dbo.HRApplicantWorker.ApplicantCode AS LastContactEmployeeCode, " +
                " dbo.HRApplicant.ApplicantFirstName AS LastContactEmployeeName " +
                " FROM         dbo.HRApplicantWorker INNER JOIN " +
                " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";
                if (_Employee != 0)
                    strLastContactEmployee += " where dbo.HRApplicantWorker.ApplicantID = " + _Employee + " ";

                string strMonitor = "SELECT  MAX(MonitoringID) AS MaxMonitorID, MonitoringCampaignCustomer " +
                      " FROM    dbo.CRMCampaignCustomerMonitor " +
                      " GROUP BY MonitoringCampaignCustomer ";
                string strLastMonitorEmployee = "SELECT  dbo.HRApplicant.ApplicantID AS LastMonitoringEmployeeID, dbo.HRApplicant.ApplicantFirstName AS LastMonitoringEmployeeName, " +
                  " dbo.HRApplicantWorker.ApplicantCode AS LastMonitoringEmployeeCode " +
                  " FROM   dbo.HRApplicant INNER JOIN " +
                  " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                strMonitor = "SELECT dbo.CRMCampaignCustomerMonitor.MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer"+
                    ", MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                      "MonitoringStatus as LastMonitoringStatus,MonitoringWaitingDate as LastMonitoringWaitingDate ," +
                      "MonitoringEmployee AS LastMonitoringEmployee,MonitoringEmployeeTable.* " +
                      " FROM  dbo.CRMCampaignCustomerMonitor " +
                      " inner join (" + strMonitor + ") as MaxMonitorTable " +
                      " on CRMCampaignCustomerMonitor.MonitoringCampaignCustomer = MaxMonitorTable.MonitoringCampaignCustomer  " +
                      " and  CRMCampaignCustomerMonitor.MonitoringID = MaxMonitorTable.MaxMonitorID " +
                      " left outer join (" + strLastMonitorEmployee + ") as MonitoringEmployeeTable   " +
                      " on  CRMCampaignCustomerMonitor.MonitoringEmployee = MonitoringEmployeeTable.LastMonitoringEmployeeID ";

                strMonitor = "SELECT  MonitoringID AS LastMonitoringID, MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer, MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                      " MonitoringStatus AS LastMonitoringStatus, MonitoringWaitingDate AS LastMonitoringWaitingDate, MonitoringEmployee AS LastMonitoringEmployee"+
                      " FROM   dbo.CRMCampaignCustomerMonitor ";

                string strCampaign = "SELECT     CampaignID as CustomerCampaignID, CampaignDate as CustomerCampaignDate" +
                    ", CampaignDesc as CustomerCampaignDesc " +
                       " FROM         dbo.CRMCampaign ";
                string strEmployee = "";
                string strLasCampaignCustomer = "SELECT   dbo.CRMCampaignCustomer.CampaignCustomerID" +
                    ", case when MAX(dbo.CRMCampaignCustomerContact.CampaignContactID)  is null then 0 " +
                    " else MAX(dbo.CRMCampaignCustomerContact.CampaignContactID) end AS MaxCampaignContactID " +
                     " FROM dbo.CRMCampaignCustomer " +
                    //" left outer join  dbo.CRMCampaignCustomerContact_ICampaignCustomer "+
                    //" ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID "+
                     " LEFT OUTER JOIN " +
                     " dbo.CRMCampaignCustomerContact ON  " +
                    //"  dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignContactID = dbo.CRMCampaignCustomerContact.CampaignContactID ";
                     " dbo.CRMCampaignCustomer.CampaignCustomerID  = dbo.CRMCampaignCustomerContact.CampaignCustomerID ";
                string strTempCampaign = "SELECT     CampaignCustomerID, Campaign " +
                        " FROM         dbo.CRMCampaignCustomer_ICampaign " +
                        " WHERE     (Campaign = " + _Campaign + ") ";
                if (_Campaign != 0)
                {
                    //strLasCampaignCustomer += " where CRMCampaignCustomerContact.ContactCampaign=" + _Campaign;
                  
                    strLasCampaignCustomer += " inner join (" + strTempCampaign + ") CampaignTable1 " +
                        " on  dbo.CRMCampaignCustomer.Campaign = CampaignTable1.Campaign" +
                        " and dbo.CRMCampaignCustomer.CampaignCustomerID = CampaignTable1.CampaignCustomerID";
                }
                strLasCampaignCustomer += " GROUP BY dbo.CRMCampaignCustomer.CampaignCustomerID ";

                strLasCampaignCustomer = "select CampaignCustomerTable.CampaignCustomerID as CurrentCampaignCustomerID,LastContactTable.* " +
                    ",case when MaxCampaignContactID = 0 or MaxCampaignContactID <> LastContactTable.MaxContactSucceeded  then 0 else 1 end as MaxFailed " +
                    " from (" + strLasCampaignCustomer + ") as CampaignCustomerTable  " +
                    //"  left outer join CRMCampaignCustomerContact_ICampaignCustomer "+
                    //" on "+
                    " left outer join (" + strContact + ") as LastContactTable " +
                    "  on CampaignCustomerTable.CampaignCustomerID = LastContactTable.ContactedCampaignCustomerID ";
                CustomerDb objCustomerDb = new CustomerDb();
                string strCustomer = "SELECT CustomerID, CustomerFullName, CustomerHomePhone, CustomerMobile "+
                      " FROM         dbo.CRMCustomer ";
                strCustomer = "SELECT CustomerID, CustomerFullName, IDValue, CustomerName, CustomerFullNameComp, CustomerSex, CustomerBirthDate, CustomerPassword, CustomerWorkAddress, "+
                      " CustomerAddress, CustomerHomePhone, CustomerWorkPhone, CustomerMobile, CustomerSecondMobile, CustomerMailAddress "+
                      " FROM         dbo.CRMCustomer ";
                string Returned = " SELECT  CRMCampaignCustomer.CampaignCustomerID, CRMCampaignCustomer.Campaign, CRMCampaignCustomer.Customer,CRMCampaignCustomer.Employee" +
                    "" +
                    ",CustomerTable.*,ContactTable.* " +
                    ",LastContactEmployeeTable.*,CampaignTable.*,EmployeeTable.*,MonitoringTable.*  ";
                if(strREservationCustomer!="")
                Returned += ",ReservationTable.ReservationID ";

                                Returned +=  " FROM CRMCampaignCustomer left outer join (" + strCampaign + ") as CampaignTable " +
                                  " on CRMCampaignCustomer.Campaign = CampaignTable.CustomerCampaignID " +
                                  "inner join (" +
                                  strCustomer+ ") as CustomerTable on CRMCampaignCustomer.Customer = CustomerTable.CustomerID " +
                                  //" left outer join (" + strLasCampaignCustomer + ") as ContactTable  on " +
                                  //" CRMCampaignCustomer.CampaignCustomerID = ContactTable.CurrentCampaignCustomerID " +
                                  " left outer join (" + strContact + ") as ContactTable "+
                                  " on   CRMCampaignCustomer.LastContactID = ContactTable.LastCampaignContactID "+
                                  " "+
                                  " left outer join (" + strLastContactEmployee + ") as LastContactEmployeeTable  " +
                                  " on ContactTable.LastContactEmployee = LastContactEmployeeTable.LastContactEmployeeID " +
                                  " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable on " +
                                  " CRMCampaignCustomer.Employee = EmployeeTable.ApplicantID " +
                                  " left outer join (" + strMonitor + ") as MonitoringTable " +
                                  //" on  CRMCampaignCustomer.CampaignCustomerID = MonitoringTable.LastMonitoringCampaignCustomer ";
                                  " on  CRMCampaignCustomer.LastMonitoringID = MonitoringTable.LastMonitoringID ";



                if(strREservationCustomer!="")
                {
                    Returned += " inner join ("+ strREservationCustomer +") as ReservationTable "+
                        " on  CRMCampaignCustomer.CampaignCustomerID  = ReservationTable.CampaignCustomerID ";
                }

                if (_Employee != 0 && _Campaign != 0)
                {
                    string strCampaignCustomerEmployee = "SELECT  CampaignCustomerID ,Employee " +
                           " FROM         dbo.CRMCampaignCustomer_IEmployee " +
                           " WHERE     (Campaign = " + _Campaign + ") AND (Employee = " + _Employee + ") ";
                    Returned += " inner join (" + strCampaignCustomerEmployee + ") CampaignCustometEmployeeTable "+
                        " on  CRMCampaignCustomer.CampaignCustomerID = CampaignCustometEmployeeTable.CampaignCustomerID "+
                        " and CRMCampaignCustomer.Employee = CampaignCustometEmployeeTable.Employee";
                }
                else if (_Campaign != 0 && _Employee == 0)
                {
                    Returned += " inner join (" +strTempCampaign+ ") as CampaignTable2 "+
                        " on CRMCampaignCustomer.CampaignCustomerID = CampaignTable2.CampaignCustomerID  ";

                }

                if (_CustomerIDs != null && _CustomerIDs != "")
                {
                    strCustomer = "SELECT        CampaignCustomerID as CustomerCampaignCustomerID " +
                                 "  FROM            dbo.CRMCampaignCustomer_ICustomer " +
                                  " WHERE        (Customer IN (" + _CustomerIDs + ")) ";
                    Returned += " inner join ("+ strCustomer +") as CustomerTable1 "+
                        " on  CRMCampaignCustomer.CampaignCustomerID = CustomerTable1.CustomerCampaignCustomerID   ";
                }
                Returned += " where (1=1) "; 

                if (_ID != 0)
                    Returned += " and  CampaignCustomerID = " + _ID + "";
                //if (_Campaign != 0 && _Employee == 0)
                //    Returned += " and  Campaign = " + _Campaign + "";
                if (_Customer != 0)
                    Returned += " and  Customer = " + _Customer + "";
              
                if (_ContactStatus == 1)
                    Returned += " and (" +
                        " LastContactDate is null  " +
                        " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";
                else if (_ContactStatus == 2)
                    Returned += " and (" +
                        " LastContactDate is not null  " +
                        " and (LastContactWaitingAnotherContact = 0 or LastContactWaitingDate > GetDate() )" +
                        " and (CRMCampaignCustomer.WaitingContactDate is  null or CRMCampaignCustomer.WaitingContactDate > GetDate()) " +
                        ") ";
                else if (_ContactStatus == 3) //No Fialure
                {
                    Returned += " and (" +
                      " LastContactDate is null  " +
                      " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                      " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) )" +
                     " and ( CRMCampaignCustomer.LastContactID = CRMCampaignCustomer.LastSucceededContactID) ";
                      // ") and  (MaxFailed is null or MaxFailed=0 )";
                }
                else if (_ContactStatus == 4)//has failure
                {
                    Returned += " and (" +
                      "  LastContactStatus in (2,3,4))";
                }
                else if (_ContactStatus == 5)
                    Returned += " and (" +
                        "(LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";

                if (_MonitoringStatus == 1)//monitored ornot duted
                {
                    Returned += " and (LastMonitoringWaitingDate is null or LastMonitoringWaitingDate > GetDate() )" +
                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is null or  dbo.CRMCampaignCustomer.WaitingMonitoringDate > GetDate())";

                }
                else if (_MonitoringStatus == 2)
                {
                    if (!_IsMonitoringDate)
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                            " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate <= GetDate()))";
                    else
                    {
                        double dblStartMonitor = SysUtility.Approximate(_StartMonitorDate.ToOADate() - 2, 1, ApproximateType.Down);
                        double dblEndMonitor = SysUtility.Approximate(_EndMonitorDate.ToOADate() - 2, 1, ApproximateType.Up);
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate >=" + dblStartMonitor +
                                        " and dbo.CRMCampaignCustomer.WaitingMonitoringDate <" + dblEndMonitor + "))";
                    }
                }
                // strSql += " and ContactDate is not null ";
                if (_EmployeeStatus == 1 &&_Employee ==0)
                    Returned += " and CRMCampaignCustomer.Employee <> 0 ";
                else if (_EmployeeStatus == 2)
                    Returned += " and CRMCampaignCustomer.Employee = 0 ";
                if (_Employee != 0 && _Campaign==0)
                    Returned += " and CRMCampaignCustomer.Employee =" + _Employee;


                return Returned;
            }
        }
        #region Old
        public string SearchStrOld2
        {
            get
            {
                string strCampaignCustomerIndex = "SELECT   CampaignCustomerID, Campaign " +
                       " FROM         dbo.CRMCampaignCustomer_ICampaign  where  Campaign = " + _Campaign;
                string strContact = "SELECT dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID as ContactedCampaignCustomerID " +
                    ", MAX(CASE WHEN ContactStatus = 1 THEN dbo.CRMCampaignCustomerContact.CampaignContactID ELSE 0 END) AS MaxContactSucceeded " +
                    ", MAX(dbo.CRMCampaignCustomerContact.CampaignContactID) AS MaxContactID " +
                      ", SUM(CASE WHEN ContactStatus = 1 THEN 1 ELSE 0 END) AS SucceededContactCount" +
                      ",count(dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignContactID) as ContactCount " +
                      " FROM  dbo.CRMCampaignCustomerContact_ICampaignCustomer  " +
                      "  inner join  dbo.CRMCampaignCustomerContact " +
                      "  on dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID = CRMCampaignCustomerContact.CampaignCustomerID " +
                     " and dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignContactID = CRMCampaignCustomerContact.CampaignContactID  " +
                     " inner join CRMCampaignCustomer  " +
                     " on  CRMCampaignCustomerContact.CampaignCustomerID = CRMCampaignCustomer.CampaignCustomerID ";
                if (_Campaign != 0)
                    strContact += " inner join (" + strCampaignCustomerIndex + ") as CampaignCustomerCampaignTable   " +
                        " on dbo.CRMCampaignCustomerContact.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID  ";
                strContact += " where CampaignCustomerID<> 0 ";
                //if (_Campaign != 0)
                //    strContact += " and CRMCampaignCustomerContact.ContactCampaign=" + _Campaign;
                strContact += " GROUP BY dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID ";

                strContact = "SELECT   dbo.CRMCampaignCustomerContact.CampaignCustomerID  as ContactedCampaignCustomerID" +
                    ",ContactType AS LastContactType,ContactDate as LastContactDate, ContactComment AS LastContactComment" +
                    ", ContactStatus AS LastContactStatus,ContactFunctionalStatus as LastContactFunctionalStatus " +
                      " ,ContactWaitingAnotherContact AS LastContactWaitingAnotherContact, ContactWaitingDate AS LastContactWaitingDate, " +
                      " ContactEmployee as LastContactEmployee, ContactBranch" +
                      ",MaxContactTable.ContactCount,MaxContactTable.SucceededContactCount " +
                    ",MaxContactTable.MaxContactSucceeded  " +
                      " FROM  dbo.CRMCampaignCustomerContact " +
                      " inner  join (" + strContact + ") as MaxContactTable on " +

                      " dbo.CRMCampaignCustomerContact.CampaignContactID = MaxContactTable.MaxContactID ";
                ///
                strContact = "SELECT  CampaignContactID AS LastCampaignContactID, CampaignCustomerID AS ContactedCampaignCustomerID, ContactType AS LastContactType, " +
                    " ContactDate AS LastContactDate, ContactComment AS LastContactComment, ContactStatus AS LastContactStatus, " +
                      " ContactFunctionalStatus AS LastContactFunctionalStatus, ContactWaitingAnotherContact AS LastContactWaitingAnotherContact, " +
                      " ContactWaitingDate AS LastContactWaitingDate, ContactEmployee AS LastContactEmployee, ContactBranch " +
                      " FROM    dbo.CRMCampaignCustomerContact ";
                string strLastSucceededContact = "";
                string strLastContactEmployee = "SELECT  dbo.HRApplicantWorker.ApplicantID AS LastContactEmployeeID, dbo.HRApplicantWorker.ApplicantCode AS LastContactEmployeeCode, " +
                " dbo.HRApplicant.ApplicantFirstName AS LastContactEmployeeName " +
                " FROM         dbo.HRApplicantWorker INNER JOIN " +
                " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";
                if (_Employee != 0)
                    strLastContactEmployee += " where dbo.HRApplicantWorker.ApplicantID = " + _Employee + " ";

                string strMonitor = "SELECT  MAX(MonitoringID) AS MaxMonitorID, MonitoringCampaignCustomer " +
                      " FROM    dbo.CRMCampaignCustomerMonitor " +
                      " GROUP BY MonitoringCampaignCustomer ";
                string strLastMonitorEmployee = "SELECT  dbo.HRApplicant.ApplicantID AS LastMonitoringEmployeeID, dbo.HRApplicant.ApplicantFirstName AS LastMonitoringEmployeeName, " +
                  " dbo.HRApplicantWorker.ApplicantCode AS LastMonitoringEmployeeCode " +
                  " FROM   dbo.HRApplicant INNER JOIN " +
                  " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                strMonitor = "SELECT dbo.CRMCampaignCustomerMonitor.MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer" +
                    ", MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                      "MonitoringStatus as LastMonitoringStatus,MonitoringWaitingDate as LastMonitoringWaitingDate ," +
                      "MonitoringEmployee AS LastMonitoringEmployee,MonitoringEmployeeTable.* " +
                      " FROM  dbo.CRMCampaignCustomerMonitor " +
                      " inner join (" + strMonitor + ") as MaxMonitorTable " +
                      " on CRMCampaignCustomerMonitor.MonitoringCampaignCustomer = MaxMonitorTable.MonitoringCampaignCustomer  " +
                      " and  CRMCampaignCustomerMonitor.MonitoringID = MaxMonitorTable.MaxMonitorID " +
                      " left outer join (" + strLastMonitorEmployee + ") as MonitoringEmployeeTable   " +
                      " on  CRMCampaignCustomerMonitor.MonitoringEmployee = MonitoringEmployeeTable.LastMonitoringEmployeeID ";

                strMonitor = "SELECT  MonitoringID AS LastMonitoringID, MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer, MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                      " MonitoringStatus AS LastMonitoringStatus, MonitoringWaitingDate AS LastMonitoringWaitingDate, MonitoringEmployee AS LastMonitoringEmployee" +
                      " FROM   dbo.CRMCampaignCustomerMonitor ";

                string strCampaign = "SELECT     CampaignID as CustomerCampaignID, CampaignDate as CustomerCampaignDate" +
                    ", CampaignDesc as CustomerCampaignDesc " +
                       " FROM         dbo.CRMCampaign ";
                string strEmployee = "";
                string strLasCampaignCustomer = "SELECT   dbo.CRMCampaignCustomer.CampaignCustomerID" +
                    ", case when MAX(dbo.CRMCampaignCustomerContact.CampaignContactID)  is null then 0 " +
                    " else MAX(dbo.CRMCampaignCustomerContact.CampaignContactID) end AS MaxCampaignContactID " +
                     " FROM         dbo.CRMCampaignCustomer LEFT OUTER JOIN " +
                     " dbo.CRMCampaignCustomerContact ON  " +
                     " dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerContact.CampaignCustomerID ";
                if (_Campaign != 0)
                    strLasCampaignCustomer += " where CRMCampaignCustomerContact.ContactCampaign=" + _Campaign;

                strLasCampaignCustomer += " GROUP BY dbo.CRMCampaignCustomer.CampaignCustomerID ";

                strLasCampaignCustomer = "select CampaignCustomerTable.CampaignCustomerID as CurrentCampaignCustomerID,LastContactTable.* " +
                    ",case when MaxCampaignContactID = 0 or MaxCampaignContactID <> LastContactTable.MaxContactSucceeded  then 0 else 1 end as MaxFailed " +
                    " from (" + strLasCampaignCustomer + ") as CampaignCustomerTable  " +
                    " left outer join (" + strContact + ") as LastContactTable " +
                    "  on CampaignCustomerTable.CampaignCustomerID = LastContactTable.ContactedCampaignCustomerID ";
                CustomerDb objCustomerDb = new CustomerDb();
                string Returned = " SELECT  CRMCampaignCustomer.CampaignCustomerID, CRMCampaignCustomer.Campaign, CRMCampaignCustomer.Customer,CRMCampaignCustomer.Employee" +
                    "" +
                    ",CustomerTable.*,ContactTable.* " +
                    ",LastContactEmployeeTable.*,CampaignTable.*,EmployeeTable.*,MonitoringTable.*  " +
                                  " FROM CRMCampaignCustomer left outer join (" + strCampaign + ") as CampaignTable " +
                                  " on CRMCampaignCustomer.Campaign = CampaignTable.CustomerCampaignID " +
                                  "inner join (" +
                                  objCustomerDb.SearchStr + ") as CustomerTable on CRMCampaignCustomer.Customer = CustomerTable.CustomerID " +
                    //" left outer join (" + strLasCampaignCustomer + ") as ContactTable  on " +
                    //" CRMCampaignCustomer.CampaignCustomerID = ContactTable.CurrentCampaignCustomerID " +
                                  " left outer join (" + strContact + ") as ContactTable " +
                                  " on   CRMCampaignCustomer.LastContactID = ContactTable.LastCampaignContactID " +
                                  " " +
                                  " left outer join (" + strLastContactEmployee + ") as LastContactEmployeeTable  " +
                                  " on ContactTable.LastContactEmployee = LastContactEmployeeTable.LastContactEmployeeID " +
                                  " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable on " +
                                  " CRMCampaignCustomer.Employee = EmployeeTable.ApplicantID " +
                                  " left outer join (" + strMonitor + ") as MonitoringTable " +
                    //" on  CRMCampaignCustomer.CampaignCustomerID = MonitoringTable.LastMonitoringCampaignCustomer ";
                                  " on  CRMCampaignCustomer.LastMonitoringID = MonitoringTable.LastMonitoringID ";
                if (_Employee != 0 && _Campaign != 0)
                {
                    string strCampaignCustomerEmployee = "SELECT  CampaignCustomerID ,Employee " +
                           " FROM         dbo.CRMCampaignCustomer_IEmployee " +
                           " WHERE     (Campaign = " + _Campaign + ") AND (Employee = " + _Employee + ") ";
                    Returned += " inner join (" + strCampaignCustomerEmployee + ") CampaignCustometEmployeeTable " +
                        " on  CRMCampaignCustomer.CampaignCustomerID = CampaignCustometEmployeeTable.CampaignCustomerID " +
                        " and CRMCampaignCustomer.Employee = CampaignCustometEmployeeTable.Employee";
                }
                Returned += " where (1=1) ";

                if (_ID != 0)
                    Returned += " and  CampaignCustomerID = " + _ID + "";
                if (_Campaign != 0 && _Employee == 0)
                    Returned += " and  Campaign = " + _Campaign + "";
                if (_Customer != 0)
                    Returned += " and  Customer = " + _Customer + "";
                if (_ContactStatus == 1)
                    Returned += " and (" +
                        " LastContactDate is null  " +
                        " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";
                else if (_ContactStatus == 2)
                    Returned += " and (" +
                        " LastContactDate is not null  " +
                        " and (LastContactWaitingAnotherContact = 0 or LastContactWaitingDate > GetDate() )" +
                        " and (CRMCampaignCustomer.WaitingContactDate is  null or CRMCampaignCustomer.WaitingContactDate > GetDate()) " +
                        ") ";
                else if (_ContactStatus == 3) //No Fialure
                {
                    Returned += " and (" +
                      " LastContactDate is null  " +
                      " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                      " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) )" +
                     " and ( CRMCampaignCustomer.LastContactID = CRMCampaignCustomer.LastSucceededContactID) ";
                    // ") and  (MaxFailed is null or MaxFailed=0 )";
                }
                else if (_ContactStatus == 4)//has failure
                {
                    Returned += " and (" +
                      "  LastContactStatus in (2,3,4))";
                }
                else if (_ContactStatus == 5)
                    Returned += " and (" +
                        "(LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";

                if (_MonitoringStatus == 1)//monitored ornot duted
                {
                    Returned += " and (LastMonitoringWaitingDate is null or LastMonitoringWaitingDate > GetDate() )" +
                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is null or  dbo.CRMCampaignCustomer.WaitingMonitoringDate > GetDate())";

                }
                else if (_MonitoringStatus == 2)
                {
                    if (!_IsMonitoringDate)
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                            " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate <= GetDate()))";
                    else
                    {
                        double dblStartMonitor = SysUtility.Approximate(_StartMonitorDate.ToOADate() - 2, 1, ApproximateType.Down);
                        double dblEndMonitor = SysUtility.Approximate(_EndMonitorDate.ToOADate() - 2, 1, ApproximateType.Up);
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate >=" + dblStartMonitor +
                                        " and dbo.CRMCampaignCustomer.WaitingMonitoringDate <" + dblEndMonitor + "))";
                    }
                }
                // strSql += " and ContactDate is not null ";
                if (_EmployeeStatus == 1 && _Employee == 0)
                    Returned += " and CRMCampaignCustomer.Employee <> 0 ";
                else if (_EmployeeStatus == 2)
                    Returned += " and CRMCampaignCustomer.Employee = 0 ";
                if (_Employee != 0 && _Campaign == 0)
                    Returned += " and CRMCampaignCustomer.Employee =" + _Employee;


                return Returned;
            }
        }
        public  string SearchStrold
        {
            get
            {
                string strContact = "SELECT CampaignCustomerID as ContactedCampaignCustomerID " +
                    ", MAX(CASE WHEN ContactStatus = 1 THEN CampaignContactID ELSE 0 END) AS MaxContactSucceeded " +
                    ", MAX(CampaignContactID) AS MaxContactID " +
                      ", SUM(CASE WHEN ContactStatus = 1 THEN 1 ELSE 0 END) AS SucceededContactCount,count(CampaignContactID) as ContactCount " +
                      " FROM         dbo.CRMCampaignCustomerContact " +
                      " where CampaignCustomerID<> 0 ";
                if (_Campaign != 0)
                    strContact += " and CRMCampaignCustomerContact.ContactCampaign=" + _Campaign;
                    strContact +=  " GROUP BY CampaignCustomerID ";

                strContact = "SELECT   dbo.CRMCampaignCustomerContact.CampaignCustomerID  as ContactedCampaignCustomerID" +
                    ",ContactType AS LastContactType,ContactDate as LastContactDate, ContactComment AS LastContactComment" +
                    ", ContactStatus AS LastContactStatus,ContactFunctionalStatus as LastContactFunctionalStatus " +
                      " ,ContactWaitingAnotherContact AS LastContactWaitingAnotherContact, ContactWaitingDate AS LastContactWaitingDate, " +
                      " ContactEmployee as LastContactEmployee, ContactBranch" +
                      ",MaxContactTable.ContactCount,MaxContactTable.SucceededContactCount " +
                    ",MaxContactTable.MaxContactSucceeded  " +
                      " FROM  dbo.CRMCampaignCustomerContact " +
                      " inner  join (" + strContact + ") as MaxContactTable on " +
                    //" dbo.CRMCampaignCustomerContact.CampaignContactID = MaxContactTable.MaxContactSucceeded "+
                    //" and  dbo.CRMCampaignCustomerContact.ContactDirectCustomer = MaxContactTable.ContactDirectCustomer "+
                     // "   dbo.CRMCampaignCustomerContact.CampaignCustomerID = MaxContactTable.ContactedCampaignCustomerID "+
                      " dbo.CRMCampaignCustomerContact.CampaignContactID = MaxContactTable.MaxContactID ";
                      //" and  dbo.CRMCampaignCustomerContact.ContactCampaign = MaxContactTable.ContactCampaign ";
               
                string strLastContactEmployee = "SELECT  dbo.HRApplicantWorker.ApplicantID AS LastContactEmployeeID, dbo.HRApplicantWorker.ApplicantCode AS LastContactEmployeeCode, " +
                " dbo.HRApplicant.ApplicantFirstName AS LastContactEmployeeName " +
                " FROM         dbo.HRApplicantWorker INNER JOIN " +
                " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";
                if (_Employee != 0)
                    strLastContactEmployee += " where dbo.HRApplicantWorker.ApplicantID = "+_Employee +" ";

                string strMonitor = "SELECT  MAX(MonitoringID) AS MaxMonitorID, MonitoringCampaignCustomer "+
                      " FROM    dbo.CRMCampaignCustomerMonitor "+
                      " GROUP BY MonitoringCampaignCustomer ";
                string strLastMonitorEmployee = "SELECT  dbo.HRApplicant.ApplicantID AS LastMonitoringEmployeeID, dbo.HRApplicant.ApplicantFirstName AS LastMonitoringEmployeeName, " +
                  " dbo.HRApplicantWorker.ApplicantCode AS LastMonitoringEmployeeCode " +
                  " FROM   dbo.HRApplicant INNER JOIN " +
                  " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                strMonitor = "SELECT dbo.CRMCampaignCustomerMonitor.MonitoringCampaignCustomer AS LastMonitoringCampaignCustomer, MonitoringDate AS LastMonitoringDate, MonitoringDesc AS LastMonitoringDesc, " +
                      "MonitoringStatus as LastMonitoringStatus,MonitoringWaitingDate as LastMonitoringWaitingDate ,"+
                      "MonitoringEmployee AS LastMonitoringEmployee,MonitoringEmployeeTable.* " +
                      " FROM  dbo.CRMCampaignCustomerMonitor "+
                      " inner join (" + strMonitor + ") as MaxMonitorTable "+
                      " on CRMCampaignCustomerMonitor.MonitoringCampaignCustomer = MaxMonitorTable.MonitoringCampaignCustomer  "+
                      " and  CRMCampaignCustomerMonitor.MonitoringID = MaxMonitorTable.MaxMonitorID "+
                      " left outer join ("+ strLastMonitorEmployee +") as MonitoringEmployeeTable   "+
                      " on  CRMCampaignCustomerMonitor.MonitoringEmployee = MonitoringEmployeeTable.LastMonitoringEmployeeID ";
            

          
                string strCampaign = "SELECT     CampaignID as CustomerCampaignID, CampaignDate as CustomerCampaignDate"+
                    ", CampaignDesc as CustomerCampaignDesc "+
                       " FROM         dbo.CRMCampaign ";
                string strEmployee = "";
                string strLasCampaignCustomer = "SELECT   dbo.CRMCampaignCustomer.CampaignCustomerID" +
                    ", case when MAX(dbo.CRMCampaignCustomerContact.CampaignContactID)  is null then 0 " +
                    " else MAX(dbo.CRMCampaignCustomerContact.CampaignContactID) end AS MaxCampaignContactID " +
                     " FROM         dbo.CRMCampaignCustomer LEFT OUTER JOIN " +
                     " dbo.CRMCampaignCustomerContact ON  " +
                     " dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerContact.CampaignCustomerID ";
                if (_Campaign != 0)
                    strLasCampaignCustomer += " where CRMCampaignCustomerContact.ContactCampaign=" + _Campaign;

               strLasCampaignCustomer += " GROUP BY dbo.CRMCampaignCustomer.CampaignCustomerID ";
                
                strLasCampaignCustomer = "select CampaignCustomerTable.CampaignCustomerID as CurrentCampaignCustomerID,LastContactTable.* "+
                    ",case when MaxCampaignContactID = 0 or MaxCampaignContactID <> LastContactTable.MaxContactSucceeded  then 0 else 1 end as MaxFailed " +
                    " from ("+ strLasCampaignCustomer +") as CampaignCustomerTable  "+
                    " left outer join ("+ strContact +") as LastContactTable "+
                    "  on CampaignCustomerTable.CampaignCustomerID = LastContactTable.ContactedCampaignCustomerID ";
                CustomerDb objCustomerDb = new CustomerDb();
                string Returned = " SELECT  CampaignCustomerID, Campaign, Customer,CRMCampaignCustomer.Employee"+
                    ""+
                    ",CustomerTable.*,ContactTable.* " +
                    ",LastContactEmployeeTable.*,CampaignTable.*,EmployeeTable.*,MonitoringTable.*  " +
                                  " FROM CRMCampaignCustomer left outer join ("+ strCampaign +") as CampaignTable "+
                                  " on CRMCampaignCustomer.Campaign = CampaignTable.CustomerCampaignID "+
                                  "inner join ("+ 
                                  objCustomerDb.SearchStr +") as CustomerTable on CRMCampaignCustomer.Customer = CustomerTable.CustomerID "+
                                  " left outer join (" + strLasCampaignCustomer + ") as ContactTable  on "+
                                  " CRMCampaignCustomer.CampaignCustomerID = ContactTable.CurrentCampaignCustomerID " +
                                  " left outer join ("+ strLastContactEmployee +") as LastContactEmployeeTable  "+
                                  " on ContactTable.LastContactEmployee = LastContactEmployeeTable.LastContactEmployeeID "+
                                  " left outer join ("+ EmployeeDb.SearchStr +") as EmployeeTable on "+
                                  " CRMCampaignCustomer.Employee = EmployeeTable.ApplicantID "+
                                  " left outer join ("+ strMonitor +") as MonitoringTable "+
                                  " on  CRMCampaignCustomer.CampaignCustomerID = MonitoringTable.LastMonitoringCampaignCustomer ";

                //CustomerDb objCustomerDb = new CustomerDb();
                //string strDirectCustomer = " SELECT  0 as CampaignCustomerID, dbo.CRMCampaignCustomerContact.ContactCampaign as Campaign"+
                //    " ,dbo.CRMCampaignCustomerContact.ContactDirectCustomer as Customer,0 as Employee" +
                //    "" +
                //    ",CustomerTable.*,ContactTable.* " +
                //    ",LastContactEmployeeTable.*,CampaignTable.*,EmployeeTable.*,MonitoringTable.*  " +
                //                  " FROM CRMCampaignCustomerContact inner join (" + strCampaign + ") as CampaignTable " +
                //                  " on dbo.CRMCampaignCustomerContact.ContactCampaign = CampaignTable.CustomerCampaignID " +
                //                  " inner join (" +
                //                  objCustomerDb.SearchStr + ") as CustomerTable on dbo.CRMCampaignCustomerContact.ContactDirectCustomer = CustomerTable.CustomerID " +
                //                  " left outer join (" + strLasCampaignCustomer + ") as ContactTable  on " +
                //                  " on ContactTable.LastContactEmployee = LastContactEmployeeTable.LastContactEmployeeID " +
                //                  " CRMCampaignCustomer.CampaignCustomerID = ContactTable.CurrentCampaignCustomerID " +
                //                  " left outer join (" + strLastContactEmployee + ") as LastContactEmployeeTable  " +
                //                  " left outer join (" + EmployeeDb.SearchStr + ") as EmployeeTable on " +
                //                  " CRMCampaignCustomer.Employee = EmployeeTable.ApplicantID " +
                //                  " left outer join (" + strMonitor + ") as MonitoringTable " +
                //                  " on  CRMCampaignCustomer.CampaignCustomerID = MonitoringTable.LastMonitoringCampaignCustomer ";


                Returned += " where (1=1) ";

                if (_ID != 0)
                    Returned += " and  CampaignCustomerID = " + _ID + "";
                if (_Campaign != 0)
                    Returned += " and  Campaign = " + _Campaign + "";
                if (_Customer != 0)
                    Returned += " and  Customer = " + _Customer + "";
                if (_ContactStatus == 1)
                    Returned += " and (" +
                        " LastContactDate is null  " +
                        " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";
                else if (_ContactStatus == 2)
                    Returned += " and (" +
                        " LastContactDate is not null  " +
                        " and (LastContactWaitingAnotherContact = 0 or LastContactWaitingDate > GetDate() )" +
                        " and (CRMCampaignCustomer.WaitingContactDate is  null or CRMCampaignCustomer.WaitingContactDate > GetDate()) " +
                        ") ";
                else if (_ContactStatus == 3) //No Fialure
                {
                      Returned += " and (" +
                        " LastContactDate is null  " +
                        " or (LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") and  (MaxFailed is null or MaxFailed=0 )";
                }
                else if (_ContactStatus == 4)//has failure
                {
                    Returned += " and (" +
                      "  LastContactStatus in (2,3,4))";
                }
                else if(_ContactStatus == 5)
                    Returned += " and (" +
                        "(LastContactWaitingAnotherContact = 1 and LastContactWaitingDate < GetDate() )" +
                        " or (CRMCampaignCustomer.WaitingContactDate is not null and CRMCampaignCustomer.WaitingContactDate <= GetDate()) " +
                        ") ";

                if (_MonitoringStatus == 1)//monitored ornot duted
                {
                    Returned += " and (LastMonitoringWaitingDate is null or LastMonitoringWaitingDate > GetDate() )"+
                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is null or  dbo.CRMCampaignCustomer.WaitingMonitoringDate > GetDate())";

                }
                else if (_MonitoringStatus == 2)
                {
                    if (!_IsMonitoringDate)
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                            " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate <= GetDate()))";
                    else
                    {
                        double dblStartMonitor = SysUtility.Approximate(_StartMonitorDate.ToOADate() - 2, 1, ApproximateType.Down);
                        double dblEndMonitor = SysUtility.Approximate(_EndMonitorDate.ToOADate() - 2, 1, ApproximateType.Up);
                        Returned += " and ((LastMonitoringWaitingDate is   null or LastMonitoringWaitingDate <  dbo.CRMCampaignCustomer.WaitingMonitoringDate )" +
                                        " and  (dbo.CRMCampaignCustomer.WaitingMonitoringDate is not null and   dbo.CRMCampaignCustomer.WaitingMonitoringDate >=" + dblStartMonitor + 
                                        " and dbo.CRMCampaignCustomer.WaitingMonitoringDate <"+ dblEndMonitor +"))";
                    }
                }
                // strSql += " and ContactDate is not null ";
                if (_EmployeeStatus == 1)
                    Returned += " and CRMCampaignCustomer.Employee <> 0 ";
                else if (_EmployeeStatus == 2)
                    Returned += " and CRMCampaignCustomer.Employee = 0 ";
                if (_Employee != 0)
                    Returned += " and CRMCampaignCustomer.Employee =" + _Employee;

               
                return Returned;
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
                //LastContactFunctionalStatus
                string strSelect = "count(CampaignCustomerID) as TotalCount,"+
                    "sum(case when  LastContactFunctionalStatus = 1 then 1 else 0 end) as SucceededContactCount,max(LastContactDate) as LastContactDate ";
                   // "sum(case when  SucceededContactCount > 0 then 1 else 0 end) as SucceededContactCount,max(LastContactDate) as LastContactDate ";
                if (_IsEmployeeGroup)
                {
                    strSelect += ",ApplicantFirstName";
                    strGroup += "ApplicantFirstName";
 
                }
                if (_IsCampaignGroup)
                {
                    strSelect += ",CustomerCampaignDesc";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CustomerCampaignDesc";
                }
                if (_IsCustomerGroup)
                {
                    strSelect += ",CustomerFullName";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CustomerFullName";
                }
                if (_IsCustomerGroup && _IsCampaignGroup)
                {
                    strSelect += ",CampaignCustomerID";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CampaignCustomerID";
                }
                Returned = "select " + strSelect + " from (" + SearchStr + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                //if (strOrder != "")
                //    Returned += " order by  " + strOrder;
                Returned = "select top 10000 * from ("+ Returned +") as NativeCustomerTable order by LastContactDate desc ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["CampaignCustomerID"] != null &&
                objDR["CampaignCustomerID"].ToString() != "")
            _ID = int.Parse(objDR["CampaignCustomerID"].ToString());
        if (objDR.Table.Columns["Campaign"] != null && objDR["Campaign"].ToString() != "")
            _Campaign = int.Parse(objDR["Campaign"].ToString());
        if (objDR.Table.Columns["Customer"] != null && objDR["Customer"].ToString() != "")
            _Customer = int.Parse(objDR["Customer"].ToString());
            if(objDR.Table.Columns["Contact"]!= null&& objDR["Contact"].ToString() != "")
            _ContactType = int.Parse(objDR["Contact"].ToString());
        if (objDR.Table.Columns["LastContactType"] != null && objDR["LastContactType"].ToString() != "")
            _ContactType = int.Parse(objDR["LastContactType"].ToString());
        //if (objDR.Table.Columns["LastContactDate"] != null && objDR["LastContactDate"].ToString() != "")
        //    _ContactDate = DateTime.Parse(objDR["LastContactDate"].ToString());
        if (objDR.Table.Columns["ContactDate"]!= null && objDR["ContactDate"].ToString() != "")
        {
            _IsContacted = true;
            _ContactDate = DateTime.Parse(objDR["ContactDate"].ToString());
        }
        else
        {
            _IsContacted = false;
        }
        if (objDR.Table.Columns["LastContactDate"] != null &&
            objDR["LastContactDate"].ToString() != "")
        {
            _IsContacted = true;
            _ContactDate = DateTime.Parse(objDR["LastContactDate"].ToString());
        }
            if(objDR.Table.Columns["ContactComment"]!= null )
            _ContactComment = objDR["ContactComment"].ToString();
        if (objDR.Table.Columns["LastContactComment"] != null)
            _ContactComment = objDR["LastContactComment"].ToString();
        if (objDR.Table.Columns["LastContactStatus"] != null && objDR["LastContactStatus"].ToString()!= "")
            _ContactStatus = int.Parse(objDR["LastContactStatus"].ToString());
        if (objDR.Table.Columns["LastContactFunctionalStatus"] != null && objDR["LastContactFunctionalStatus"].ToString() != "")
            _ContactStatus = int.Parse(objDR["LastContactFunctionalStatus"].ToString());
        if (objDR.Table.Columns["LastContactWaitingAnotherContact"] != null &&
            objDR["LastContactWaitingAnotherContact"].ToString() != "")
            _WaitingAnotherContact = bool.Parse(objDR["LastContactWaitingAnotherContact"].ToString());
        if (objDR.Table.Columns["LastContactWaitingDate"] != null && objDR["LastContactWaitingDate"].ToString() != "")
            _AnotherContactDate = DateTime.Parse(objDR["LastContactWaitingDate"].ToString());
        if (objDR.Table.Columns["LastContactEmployee"] != null && objDR["LastContactEmployee"].ToString() != "")
            _ContactEmployee = int.Parse(objDR["LastContactEmployee"].ToString());
            if(objDR.Table.Columns["LastContactEmployeeCode"]!= null)
              _ContactEmployeeCode = objDR["LastContactEmployeeCode"].ToString();
    if (objDR.Table.Columns["LastContactEmployeeName"] != null)
        _ContactEmployeeName = objDR["LastContactEmployeeName"].ToString();
        if (objDR.Table.Columns["Employee"] != null && objDR["Employee"].ToString() != "")
            _Employee = int.Parse(objDR["Employee"].ToString());
            if(objDR.Table.Columns["SucceededContactCount"] != null&& objDR["SucceededContactCount"].ToString()!= "")
        _SucceededContacCount = int.Parse(objDR["SucceededContactCount"].ToString());
    if (objDR.Table.Columns["ContactCount"] != null && objDR["ContactCount"].ToString() != "")
        _ContactCount = int.Parse(objDR["ContactCount"].ToString());
    if (objDR.Table.Columns["CustomerCampaignDate"] != null && objDR["CustomerCampaignDate"].ToString() != "")
        _CampaignDate = DateTime.Parse(objDR["CustomerCampaignDate"].ToString());
    if (objDR.Table.Columns["CustomerCampaignDesc"] != null &&
        objDR["CustomerCampaignDesc"].ToString() != "")
        _CampaignDesc = objDR["CustomerCampaignDesc"].ToString();
    if (objDR.Table.Columns["ApplicantFirstName"] != null && objDR["ApplicantFirstName"].ToString() != "")
        _EmployeeName = objDR["ApplicantFirstName"].ToString();
    if (objDR.Table.Columns["CustomerFullName"] != null && objDR["CustomerFullName"].ToString() != "")
        _CustomerName = objDR["CustomerFullName"].ToString();

    if (objDR.Table.Columns["CustomerHomePhone"] != null && objDR["CustomerHomePhone"].ToString() != "")
        _CustomerHomePhone = objDR["CustomerHomePhone"].ToString();
    if (objDR.Table.Columns["CustomerMobile"] != null && objDR["CustomerMobile"].ToString() != "")
        _CustomerMobile = objDR["CustomerMobile"].ToString();

            if (objDR.Table.Columns["TotalCount"] != null && objDR["TotalCount"].ToString() != "")
        _TotalCount = int.Parse(objDR["TotalCount"].ToString());

    if (objDR.Table.Columns["CampaignID"] != null && objDR["CampaignID"].ToString() != "")
        _Campaign = int.Parse(objDR["CampaignID"].ToString());
    if (objDR.Table.Columns["CampaignDesc"] != null)
        _CampaignDesc = objDR["CampaignDesc"].ToString();
    if (objDR.Table.Columns["CampaignDate"] != null && objDR["CampaignDate"].ToString() != "")
        _CampaignDate = DateTime.Parse(objDR["CampaignDate"].ToString());


    // _WaitingMonitor = bool.Parse(objDR[""].ToString());
    //_WaitingMonitoringDate = DateTime.Parse(objDR[""].ToString());
    //_MonitoringID = int.Parse(objDR[""].ToString());
    //_MonitoringDate = DateTime.Parse(objDR[""].ToString());
    // _MonitoringDesc = objDR[""].ToString();
    //_MonitoringStatus = int.Parse( objDR[""].ToString());


    //_MonitoringEmployee = int.Parse(objDR[""].ToString());
    // _MonitoringEmployeeCode = objDR[""].ToString();
    // _MonitoringEmployeeName = objDR[""].ToString();

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strDate = "";
            double dblDate = _ContactDate.ToOADate() - 2;
            strDate = _IsContacted ? dblDate.ToString() : "null";
            string strSql = " INSERT INTO CRMCampaignCustomer"+
                            " (Campaign, Customer, Contact, ContactDate, ContactComment, UsrIns, TimIns)" +
                            " VALUES     (" + _Campaign + "," + _Customer + ","+_ContactType+"," + dblDate + ",'" + strDate+ "',"+SysData.CurrentUser.ID+",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        { 
             double dblDate = _ContactDate.ToOADate() - 2;
             string strDate = _IsContacted ? dblDate.ToString() : "null";
             string strSql = " UPDATE    CRMCampaignCustomer" +
                             " SET  Campaign =" + _Campaign + "" +
                             " , Customer =" + _Customer + "" +
                             " , Contact =" + _ContactType + "" +
                             " , ContactDate =" + strDate + "" +
                             " , ContactComment ='" + _ContactComment + "'" +
                             " , UsrUpd  =" + SysData.CurrentUser.ID + "" +
                             " , TimUpd  = GetDate()" +
                             " Where CampaignCustomerID = " + _ID + "";
             SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditContactDateHashed()
        {
            double dblDate = _ContactDate.ToOADate() - 2;
            string strDate = _IsContacted ? dblDate.ToString() : "null";
            string strSql = " UPDATE    CRMCampaignCustomer" +
                            " SET  ContactDate =" + strDate + "" +
                            " , ContactComment ='" + _ContactComment + "'" +
                            " , UsrUpd  =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd  = GetDate()" +
                            " Where  Campaign =" + _Campaign ;
            if(ID!= 0)
            strSql += " and CampaignCustomerID = " + _ID + "";
        if (_CustomerIDs != null && _CustomerIDs != "")
        {
            strSql += " and Customer in (" + _CustomerIDs + ") ";
        }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditContactDate()
        {
            double dblDate = _ContactDate.ToOADate() - 2;
            string strDate = _IsContacted ? dblDate.ToString() : "null";
            string strWaitingDate = _WaitingAnotherContact ?
                SysUtility.Approximate(_AnotherContactDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
            int intWaitingAnotherContact = _WaitingAnotherContact ? 1 : 0;
            string strID = _ID.ToString();
           

            string strSql = "";
            //string strID = _ID.ToString();
            if (_ID == 0)
            {
                strSql += "insert into CRMCampaignCustomer (Campaign, Customer,Employee,TimIns) " +
                                       "select " + _Campaign + " as Campaign,CustomerID,"+ _ContactEmployee +" as Employee,GetDate() as TimIns  " +
                                       " FROM         dbo.CRMCustomer where CustomerID =" + _Customer +
                                       " and not exists (SELECT     CampaignCustomerID " +
                                       " FROM         dbo.CRMCampaignCustomer " +
                                       " WHERE     (Campaign = " + _Campaign +
                                       ") AND (Customer = " + _Customer + ")) " +
                                       " declare @ID int " +
                                       " set @ID = (SELECT     CampaignCustomerID " +
                                       " FROM         dbo.CRMCampaignCustomer " +
                                       " WHERE     (Campaign = " + _Campaign +
                                       ") AND (Customer = " + _Customer + ")) ";
               strID = "@ID";
            }
            int intDirection = _Direction ? 1 : 0;
            strSql += "insert into  dbo.CRMCampaignCustomerContact (CampaignCustomerID,ContactDirection , ContactDate , " +
                "ContactType, ContactComment, ContactStatus, ContactFunctionalStatus,"+
                " ContactWaitingAnotherContact, ContactWaitingDate, ContactEmployee,ContactDirectCustomer, ContactCampaign, ContactTopic) "+
                " values ("+ strID + "," + intDirection + "," + dblDate + ","  + _ContactType + ",'" +  _ContactComment + "'," +
                _ContactStatus + "," + _FunctionalStatus + "," + intWaitingAnotherContact + "," + strWaitingDate + 
                "," + _ContactEmployee + "," + _Customer + "," + _Campaign + ","+ _TopicID +")  ";
           strSql += " update CRMCampaignCustomer set WaitingContactDate = null "+
               ",LastContactID=@@Identity " +
                    ",LastSucceededContactID = case when " + _ContactStatus + "= 1 then  @@Identity else LastSucceededContactID end " +
               " where CampaignCustomerID = "+strID;
            if (_WaitingMonitor)
            {
                string strMonitoringDate = (_WaitingMonitoringDate.ToOADate() - 2).ToString();
                strSql += " update CRMCampaignCustomer set WaitingMonitoringDate=" + strMonitoringDate + " where CampaignCustomerID ="+strID;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditContactDateCol()
        {
            if (_CampaignCustomerTable == null || _CampaignCustomerTable.Rows.Count == 0)
                return;
            double dblDate = _ContactDate.ToOADate() - 2;
            string strDate = _IsContacted ? dblDate.ToString() : "null";
            string strWaitingDate = _WaitingAnotherContact ?
                SysUtility.Approximate(_AnotherContactDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
            int intWaitingAnotherContact = _WaitingAnotherContact ? 1 : 0;

            string[] arrStr = new string[_CampaignCustomerTable.Rows.Count];
            int intIndex = 0;
            string strMonitoringDate;
            string strID = "";
            foreach (DataRow objDr in _CampaignCustomerTable.Rows)
            {
                intWaitingAnotherContact = int.Parse(objDr["WaitingAnotherContact"].ToString());
                strWaitingDate = intWaitingAnotherContact == 1 ? 
                    (DateTime.Parse(objDr["WaitingDate"].ToString()).ToOADate() - 2).ToString() : "null";
                arrStr[intIndex] = "";
                strID = objDr["ID"].ToString();
                if (objDr["ID"].ToString() == "" || objDr["ID"].ToString() == "0")
                {
                    arrStr[intIndex] = "insert into CRMCampaignCustomer (Campaign, Customer,TimIns) " +
                        "select " + objDr["ContactCampaign"].ToString() + " as Campaign,CustomerID,GetDate() as TimIns  "+
                        " FROM         dbo.CRMCustomer where CustomerID =" + objDr["ContactDirectCustomer"].ToString() +
                        " and not exists (SELECT     CampaignCustomerID "+
                        " FROM         dbo.CRMCampaignCustomer "+
                        " WHERE     (Campaign = " + objDr["ContactCampaign"].ToString() + 
                        ") AND (Customer = " + objDr["ContactDirectCustomer"].ToString() + ")) " +
                        " declare @ID int "+
                        " set @ID = (SELECT     CampaignCustomerID " +
                        " FROM         dbo.CRMCampaignCustomer " +
                        " WHERE     (Campaign = " + objDr["ContactCampaign"].ToString() +
                        ") AND (Customer = " + objDr["ContactDirectCustomer"].ToString() + ")) ";
                    
                    strID = "@ID";
                }
                arrStr[intIndex] += "insert into  dbo.CRMCampaignCustomerContact (CampaignCustomerID,ContactDirection "+
                    ", ContactDate , ContactType, ContactComment, ContactStatus,ContactFunctionalStatus ," +
                " ContactWaitingAnotherContact, ContactWaitingDate, ContactEmployee,ContactDirectCustomer,ContactCampaign,ContactTopic,ContactRule) " +
                " values (" + strID + "," + objDr["ContactDirection"].ToString()+ ",GetDate()," + objDr["Type"].ToString() +
                ",'" + objDr["Comment"].ToString() + "'," +
                objDr["Status"].ToString() + "," + objDr["FunctionalStatus"].ToString() + "," + intWaitingAnotherContact + "," + strWaitingDate + "," +
                objDr["Employee"].ToString() + "," + objDr["ContactDirectCustomer"].ToString() + "," +
                objDr["ContactCampaign"].ToString() + "," + _TopicID +"," + objDr["RuleID"].ToString() + ")  ";
                if(objDr["ID"].ToString()!= "0")
                arrStr[intIndex] += " update CRMCampaignCustomer set WaitingContactDate = null "+
                    ",LastContactID=@@Identity "+
                    ",LastSucceededContactID = case when " + objDr["Status"].ToString() + "= 1 then  @@Identity else LastSucceededContactID end "+
                    " where CampaignCustomerID = " + strID ;
                if (objDr["WaitingMonitoring"].ToString() == "1")
                {
                    strMonitoringDate = (DateTime.Parse(objDr["MonitoringDate"].ToString()).ToOADate() - 2).ToString();
                    arrStr[intIndex] += " update CRMCampaignCustomer set WaitingMonitoringDate="+ strMonitoringDate + 
                        " where CampaignCustomerID = " + objDr["ID"].ToString();
                }

                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void EditMonitoringWaitingDateCol()
        {
            string strMonitorDate = _WaitingMonitor ? (_WaitingMonitoringDate.ToOADate() - 2).ToString() : "null";
            string strSql = "update CRMCampaignCustomer set WaitingMonitoringDate =" + strMonitorDate ;
            if (_IDs != null && _IDs != "")
                strSql += " where CampaignCustomerID in (" + _IDs + ")";
            else if (_CustomerIDs != null && _CustomerIDs != "")
                strSql += " where Customer in (" + _CustomerIDs + ") ";
            else if (_ReservationIDs != null && _ReservationIDs != "")
                strSql += "FROM  dbo.CRMCampaignCustomer INNER JOIN "+
                      " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID "+
                       " WHERE    (dbo.CRMReservationCustomer.ReservationID IN ("+ _ReservationIDs +")) ";
            else
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void MonitorCol()
        {
            string strTemp = "SELECT     dbo.CRMCampaignCustomer.CampaignCustomerID "+
                       " FROM         dbo.CRMCampaignCustomer INNER JOIN "+
                       " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID where (1=1)";
            if (_IDs != null && _IDs != "")
                strTemp += " and CampaignCustomerID in (" + _IDs + ")";
            else if (_CustomerIDs != null && _CustomerIDs != "")
                strTemp += " and dbo.CRMCampaignCustomer.Customer in (" + _CustomerIDs + ") ";
            else if (_ReservationIDs != null && _ReservationIDs != "")
                strTemp += " and dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs + ") ";
            else
                return;
            string strWaitingDate = _WaitingMonitor ?SysUtility.Approximate( (_WaitingMonitoringDate.ToOADate()-2),1,ApproximateType.Down).ToString() : "null";
            string strSql = "select distinct CampaignCustomerID as MonitoringCampaignCustomer,GetDate() as MonitoringDate,'"+ _MonitoringDesc +"' as MonitoringDesc,"+ _MonitoringStatus +
                " as MonitoringStatus, "+ strWaitingDate +" as MonitoringWaitingDate,"+ MonitoringEmployee +" as MonitoringEmployee, "+ SysData.CurrentUser.ID + " as UsrIns " +
                ",GetDate() as TimIns "+
                " from (" + strTemp + ") as NativeTable  ";
            strSql = "insert into CRMCampaignCustomerMonitor ( MonitoringCampaignCustomer, MonitoringDate, MonitoringDesc, MonitoringStatus,"+
                " MonitoringWaitingDate, MonitoringEmployee, UsrIns, TimIns) "+
                "" + strSql;
            string strMaxMonitor = "SELECT   MonitoringCampaignCustomer, MAX(MonitoringID) AS MaxMonitorID "+
                   " FROM         dbo.CRMCampaignCustomerMonitor "+
                   " GROUP BY MonitoringCampaignCustomer ";
            strSql += " update CRMCampaignCustomer set WaitingMonitoringDate=null " +
                ",LastMonitoringID=MonitorTable.MaxMonitorID " +
                " from  CRMCampaignCustomer inner join (" + strMaxMonitor + ") as MonitorTable " +
                " on CRMCampaignCustomer.CampaignCustomerID = MonitorTable.MonitoringCampaignCustomer  " +
                " where CampaignCustomerID in (" + strTemp + ") ";
            strSql += " update dbo.CRMCampaignCustomerContact set ContactLastMonitoringID = dbo.CRMCampaignCustomer.LastMonitoringID "+
                     " FROM            dbo.CRMCampaignCustomerContact INNER JOIN "+
                     " dbo.CRMCampaignCustomerContact_ICampaignCustomer ON dbo.CRMCampaignCustomerContact.CampaignContactID = dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignContactID INNER JOIN "+
                     " dbo.CRMCampaignCustomer ON dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomer.CampaignCustomerID AND  "+
                     " dbo.CRMCampaignCustomerContact.ContactWaitingMonitoringDate = dbo.CRMCampaignCustomer.WaitingMonitoringDate "+
                     " WHERE          (dbo.CRMCampaignCustomer.CampaignCustomerID in  ("+ strTemp +"))  "; 
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void JoinCustomer()
        {
            if ((_CustomerIDs == null || _CustomerIDs == "" || _Campaign == 0)&&(_IDs == null || _IDs == ""))
                return;
            string strSql = "update  dbo.CRMCampaignCustomer " +
               " set  WaitingContactDate = GetDate() ";
            if (_Employee != 0)
                strSql += " ,Employee =" + _Employee;
            if (_CustomerIDs != null && _CustomerIDs != "")
                strSql += " where Customer in (" + _CustomerIDs + ") ";
            else if (_IDs != null && _IDs != "")
                strSql += " where CampaignCustomerID in (" + _IDs + ")";
            if(_Campaign != 0)
                strSql+= " and Campaign=" + _Campaign;
            if(_CustomerIDs != null && _CustomerIDs != "")
                strSql+= " insert into CRMCampaignCustomer (Campaign, Customer, ContactDate, " +
                 "ContactComment, UsrIns, TimIns)  " +
                 " select distinct  " + _Campaign + " as CampaignID,CustomerID,null as ContactDate,'' as Comment," +
                 SysData.CurrentUser.ID.ToString() + " as UsrIns,GetDate()  as TimIns from CRMCustomer " +
                 " where CustomerID in(" + _CustomerIDs + ") and CustomerID not in (select Customer from CRMCampaignCustomer where Campaign = " + _Campaign + ")";
            else if(_IDs != null && _IDs!= "" && _Campaign!= 0)
            {
              strSql+= " insert into CRMCampaignCustomer (Campaign, Customer, ContactDate, " +
                 "ContactComment, UsrIns, TimIns)  " +
                 " select distinct  " + _Campaign + " as CampaignID,Customer,null as ContactDate,'' as Comment," +
                 SysData.CurrentUser.ID.ToString() + " as UsrIns,GetDate()  as TimIns from CRMCampaignCustomer " +
                 " where CampaignCustomerID in(" + _IDs + ") and Campaign <>"+ _Campaign + " and Customer not in (select Customer from CRMCampaignCustomer where Campaign="+ _Campaign +")";
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
      
        public void JoinReservationCustomer()
        {
            if (_ReservationIDs == null || _ReservationIDs == "" || _Campaign == 0)
                return;
            string strCampaignCustomer = "SELECT     Customer "+
                    " FROM         dbo.CRMCampaignCustomer "+
                    " WHERE     (Campaign = "+ _Campaign +")";
            string strSql = "update CRMCampaignCustomer set WaitingContactDate = GetDate() "+
              " FROM         dbo.CRMCampaignCustomer INNER JOIN "+
              " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID "+
              " WHERE     (dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs +
              ")) and dbo.CRMCampaignCustomer.Campaign= " + _Campaign;

            strSql+=" insert into CRMCampaignCustomer (Campaign, Customer, UsrIns, TimIns)  " +
                 " select distinct  " + _Campaign + " as CampaignID,dbo.CRMReservationCustomer.CustomerID," +
                 SysData.CurrentUser.ID.ToString() + " as UsrIns,GetDate()  as TimIns  " +
                 "FROM         dbo.CRMReservationCustomer LEFT OUTER JOIN " +
                 "(" + strCampaignCustomer + ") CampaignCustomerTable ON dbo.CRMReservationCustomer.CustomerID = CampaignCustomerTable.Customer " +
                " WHERE     (dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs + ")) and CampaignCustomerTable.Customer is null ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            string strCampaignReservation = "SELECT    dbo.CRMCampaignCustomer.CampaignCustomerID, dbo.CRMReservationCustomer.ReservationID "+
                            " FROM            dbo.CRMCampaignCustomer INNER JOIN "+
                          " dbo.CRMCampaignCustomer_ICustomer ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomer_ICustomer.CampaignCustomerID INNER JOIN "+
                         " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer_ICustomer.Customer = dbo.CRMReservationCustomer.CustomerID LEFT OUTER JOIN "+
                         " dbo.CRMCampaignCustomerReservation ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerReservation.CampaignCustomerID "+
                        " WHERE        (dbo.CRMCampaignCustomerReservation.CampaignCustomerReservationID IS NULL)  "+
                        " AND (dbo.CRMCampaignCustomer.Campaign = "+ _Campaign +
                        ") AND (dbo.CRMReservationCustomer.ReservationID IN ("+ _ReservationIDs +"))";
            strCampaignReservation = " insert into CRMCampaignCustomerReservation ( CampaignCustomerID, CampaignReservation)  "+ strCampaignReservation ;
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strCampaignReservation);
        }
        public void RemoveReservationCustomer()
        {
            if (_ReservationIDs == null || _ReservationIDs == "" || _Campaign == 0)
                return;
            string strSql = "delete "+
          " FROM            dbo.CRMCampaignCustomer "+
           " WHERE        (CampaignCustomerID IN "+
           " (SELECT        CRMCampaignCustomer_1.CampaignCustomerID "+
            " FROM            dbo.CRMCampaignCustomer AS CRMCampaignCustomer_1 INNER JOIN "+
             " dbo.CRMCampaignCustomer_ICustomer ON CRMCampaignCustomer_1.CampaignCustomerID = dbo.CRMCampaignCustomer_ICustomer.CampaignCustomerID INNER JOIN "+
                                                         " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer_ICustomer.Customer = dbo.CRMReservationCustomer.CustomerID "+
                                                         " left outer join  dbo.CRMCampaignCustomerContact_ICampaignCustomer on CRMCampaignCustomer_1.CampaignCustomerID = dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID  "+
                               " WHERE   (dbo.CRMCampaignCustomerContact_ICampaignCustomer.CampaignCustomerID is null)   and  (dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs + ")) AND (CRMCampaignCustomer_1.Campaign = " + _Campaign + ")))";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void JoinUnitCustomer()
        {
            if (_UnitIDs == null || _UnitIDs == "" || _Campaign == 0)
                return;
            string strCampaignCustomer = "SELECT     Customer " +
                    " FROM         dbo.CRMCampaignCustomer " +
                    " WHERE     (Campaign = " + _Campaign + ")";
            string strSql = "update CRMCampaignCustomer set WaitingContactDate = GetDate() " +
              " FROM         dbo.CRMCampaignCustomer INNER JOIN " +
              " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID " +
            " inner join CRMReservationUnit "+
                " on CRMReservationCustomer.ReservationID = CRMReservationUnit.ReservationID "+
              " WHERE     (CRMReservationUnit.UnitID IN (" + _UnitIDs + ")) and CRMCampaignCustomer.Campaign="+_Campaign ;

            strSql += " insert into CRMCampaignCustomer (Campaign, Customer, UsrIns, TimIns)  " +
                 " select distinct  " + _Campaign + " as CampaignID,dbo.CRMReservationCustomer.CustomerID," +
                 SysData.CurrentUser.ID.ToString() + " as UsrIns,GetDate()  as TimIns  " +
                 "FROM         dbo.CRMReservationCustomer LEFT OUTER JOIN " +
                 "(" + strCampaignCustomer + ") CampaignCustomerTable "+
                 " ON dbo.CRMReservationCustomer.CustomerID = CampaignCustomerTable.Customer " +
                 " inner join CRMReservationUnit   "+
                 " on  CRMReservationCustomer.ReservationID = CRMReservationUnit.ReservationID "  +
                " WHERE     (dbo.CRMReservationUnit.UnitID IN (" + _UnitIDs + ")) and CampaignCustomerTable.Customer is null ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            string strCampaignReservation = "SELECT    dbo.CRMCampaignCustomer.CampaignCustomerID, dbo.CRMReservationCustomer.ReservationID " +
                          " FROM            dbo.CRMCampaignCustomer INNER JOIN " +
                        " dbo.CRMCampaignCustomer_ICustomer ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomer_ICustomer.CampaignCustomerID INNER JOIN " +
                       " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer_ICustomer.Customer = dbo.CRMReservationCustomer.CustomerID LEFT OUTER JOIN " +
                       " dbo.CRMCampaignCustomerReservation ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomerReservation.CampaignCustomerID " +
                      " inner join CRMUnit on dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation " +
                       " WHERE        (dbo.CRMCampaignCustomerReservation.CampaignCustomerReservationID IS NULL)  " +
                      " AND (dbo.CRMCampaignCustomer.Campaign = " + _Campaign +
                      ") AND (CRMUnit.UnitID IN (" + _UnitIDs + "))";
            strCampaignReservation = " insert into CRMCampaignCustomerReservation ( CampaignCustomerID, CampaignReservation)  " + strCampaignReservation;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strCampaignReservation);
        }
        public void StopCustomerContact()
        {
            if ((_CustomerIDs == null || _CustomerIDs == "" || _Campaign == 0)&& 
                (_IDs == null || _IDs == ""))
                return;

 //delete non Contacted CampaignCustomerhttps://www.facebook.com/theSherifSamir
            string strMaxContacted = "SELECT CRMCampaignCustomer.Customer,CRMCampaignCustomer.CampaignCustomerID, MAX(CampaignContactID) AS MaxContactID " +
                   " FROM  dbo.CRMCampaignCustomerContact " +
                   " inner join dbo.CRMCampaignCustomer on " +
                   " CRMCampaignCustomer.CampaignCustomerID = CRMCampaignCustomerContact.CampaignCustomerID " +
                   " WHERE     (ContactStatus = 1) "; 
            if(_CustomerIDs != null && _CustomerIDs != "" && _Campaign!= 0)
            strMaxContacted += " and CRMCampaignCustomer.Customer in (" + _CustomerIDs + ") and Campaign=" + _Campaign;
            else if(_IDs != null && _IDs != "")
            strMaxContacted += " and CRMCampaignCustomer.CampaignCustomerID in (" + _IDs + ")";
            strMaxContacted+=  " GROUP BY CRMCampaignCustomer.CampaignCustomerID,CRMCampaignCustomer.Customer ";
            string strSql = "delete from CRMCampaignCustomer where Campaign=" + _Campaign + " and Customer in ("+ _CustomerIDs  +
                ") and CampaignCustomerID not in (select Customer from ("+ strMaxContacted +") as NativeTable )";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //2 stop Waiting Contacted
            if((_CustomerIDs != null && _CustomerIDs!= "")|| (_IDs!= null && _IDs!= ""))
            {
            strSql = "update  dbo.CRMCampaignCustomer " +
             " set  WaitingContactDate = null " +
             " where (1=1) ";
            if (_CustomerIDs != null && _CustomerIDs != "")
                strSql += " and Customer in (" + _CustomerIDs + ") ";
            else
                strSql += " and CampaignCustomerID in ("+ _IDs +")";
            }

            strSql += "update CRMCampaignCustomerContact set   ContactWaitingAnotherContact = 0, ContactWaitingDate=null "+
                " from CRMCampaignCustomerContact inner join ("+ strMaxContacted +") as NativeTable "+
                " on CRMCampaignCustomerContact.CampaignContactID = NativeTable.MaxContactID "+
                " and CRMCampaignCustomerContact.CampaignCustomerID = NativeTable.CampaignCustomerID  ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void StopReservationContact()
        {
            if (_ReservationIDs == null || _ReservationIDs == "" || _Campaign == 0)
                return;

            //delete non Contacted CampaignCustomer
            string strCustomer = "SELECT     CustomerID "+
                   " FROM         dbo.CRMReservationCustomer "+
                   " WHERE     (ReservationID IN ("+ _ReservationIDs +")) ";
            string strMaxContacted = "SELECT CRMCampaignCustomer.Customer,CRMCampaignCustomer.CampaignCustomerID, MAX(CampaignContactID) AS MaxContactID " +
                   " FROM  dbo.CRMCampaignCustomerContact " +
                   " inner join dbo.CRMCampaignCustomer on " +
                   " CRMCampaignCustomer.CampaignCustomerID = CRMCampaignCustomerContact.CampaignCustomerID " +
                   " WHERE     (ContactStatus = 1) and Campaign=" + _Campaign +
                   " and CRMCampaignCustomer.Customer in (" + strCustomer + ")" +
                   " GROUP BY CRMCampaignCustomer.CampaignCustomerID,CRMCampaignCustomer.Customer ";
            string strSql = "delete from CRMCampaignCustomer where Campaign ="+ _Campaign +" and Customer in (" + strCustomer +
                ") and CampaignCustomerID not in (select Customer from (" + strMaxContacted + ") as NativeTable )";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //2 stop Waiting Contacted
            strSql = "update CRMCampaignCustomer set WaitingContactDate = null " +
           " FROM         dbo.CRMCampaignCustomer INNER JOIN " +
           " dbo.CRMReservationCustomer ON dbo.CRMCampaignCustomer.Customer = dbo.CRMReservationCustomer.CustomerID " +
           " WHERE     (dbo.CRMReservationCustomer.ReservationID IN (" + _ReservationIDs + ")) ";
            strSql += "update CRMCampaignCustomerContact set   ContactWaitingAnotherContact = 0, ContactWaitingDate=null " +
                " from CRMCampaignCustomerContact inner join (" + strMaxContacted + ") as NativeTable " +
                " on CRMCampaignCustomerContact.CampaignContactID = NativeTable.MaxContactID " +
                " and CRMCampaignCustomerContact.CampaignCustomerID = NativeTable.CampaignCustomerID  ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }



        public void StopReservationCustomer()
        {
 
        }
        public void AssignCampaignCustomerToEmployee()
        {
            if (_CampaignCustomerTable == null || _CampaignCustomerTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_CampaignCustomerTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _CampaignCustomerTable.Rows)
            {
                arrStr[intIndex] = "update CRMCampaignCustomer set Employee=" + objDr["Employee"].ToString() +
                    " where CampaignCustomerID = " + objDr["CampaignCustomerID"].ToString() ;
                intIndex++;
 
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void Delete()
        {
            if (_Campaign == 0)
                return;
            string strSql = " DELETE FROM CRMCampaignCustomer where "+
                " Campaign = "+ _Campaign +" and ContactDate is null ";
            if(_ID != 0)
                strSql+=  " and CampaignCustomerID = " + _ID + "";
           if (_CustomerIDs != null && _CustomerIDs != "")
              strSql += " and Customer in (" + _CustomerIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr ;
           // strSql = SumSearchStr;

            CustomerDb.IDsStr = "select CustomerID from (" + strSql + ") as NativeTable";
            CustomerDb.CacheCustomerContactTable = null;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public DataTable SumSearch()
        {
            string strSql = SumSearchStr;
            strSql = SumSearchStr;

            CustomerDb.IDsStr = "select CustomerID from (" + strSql + ") as NativeTable";
            CustomerDb.CacheCustomerContactTable = null;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}