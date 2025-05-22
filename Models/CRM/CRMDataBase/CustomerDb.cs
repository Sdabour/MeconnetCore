using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CustomerDb : BaseSelfRelatedDb
    {
        #region Private Data or protected Data
        protected DataTable _UnitInstant;
        protected DataTable _ContactInstant;
        protected DataTable _ServiceInstant;
        protected JobDb _JobDb;
        protected int _JobID;
        protected CountryDb _CountryDb;
        protected int _CountryID;
        protected IDTypeInstantDb _IDTypeDb;
        protected int _IDTypeID;
        protected string _IDTypeValue;
        protected CustomerTypeDb _CustomerTypeDb;
        protected int _CustomerTypeID;
        protected int _CampaignID;
        protected int _CampaignDealStatus;
        protected string _JobDesc;
        protected string _WorkDest;
        protected string _WorkAddress;
        protected string _Address;
        protected string _HomePhone;
        protected string _WorkPhone;
        protected string _Mobile;
        protected string _UnitFullName;
        protected string _TowerName;
        protected string _ProjectName;
        //new data
        protected string _SecondMobile;
        protected int _HomeCountry;
        protected int _HomeCity;
        protected int _HomeRegion;
        protected int _WorkCountry;
        protected int _WorkCity;
        protected int _WorkRegion;
        protected string _HomeCountryName;
        protected string _HomeCityName;
        protected string _HomeRegionName;
        protected string _WorkCountryName;
        protected string _WorkCityName;
        protected string _WorkRegionName;
        protected bool _HasBirthDate;
        //end new data
        protected string _MailAddress;
        protected int _Sex;
        protected DateTime _BirthDate;
        bool _ContractingDateRange;
        DateTime _ContractingEndDate;
        DateTime _ContractingStartDate;
        protected string _UserName;
        protected string _Password;
        double _Debt;
        double _Due;
        double _AdditionionDebt;
        double _AdtionalDue;
        #region Private Data For Search
        string _NameLike;
        int _ReservationStatus;
        bool _HasReservation;
        string _StatusStr;
        string _ReservationIDs;
        int _MinID;
        int _MaxID;
        string _MaxName;
        string _MinName;
        int _ResultCount;

        string _PhoneSearchNum;
        int _AddressStatus;
        int _MobileStatus;
        #region Private data For Search in Projects
        int _CellFamilyID;
        string _CellIDs;
        string _ModelIDs;
        int _ReservationStartCount;
        int _ReservationEndCount;
        double _ReservationStartValue;
        double _ReservationEndValue;
        string _CustomerIDs;
        #endregion
        #endregion
        byte _HasContactStatus;
        byte _HasAttachmentStatus;
        static DataTable _CachCustomerTable;
        static DataTable _CacheCustomerContactTable;
        static DataTable _CacheReservationTable;
        static string _IDStr;
        static string _CustomerReservationIDs;
        string _UnitCode;
        bool _IsBirthDate;

        #endregion
        #region Constructors
        public CustomerDb()
        {


            _JobDb = new JobDb();
            _CountryDb = new CountryDb();
            _IDTypeDb = new IDTypeInstantDb();
            _CustomerTypeDb = new CustomerTypeDb();

        }
        public CustomerDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {

                _JobDb = new JobDb();
                _CountryDb = new CountryDb();
                _IDTypeDb = new IDTypeInstantDb();
                _CustomerTypeDb = new CustomerTypeDb();
                _ID = 0;
                return;

            }
            DataRow DR = dtTemp.Rows[0];
            SetData(DR);



        }
        public CustomerDb(DataRow DR)
        {

            SetData(DR);

        }
        public CustomerDb(string strCustomerName, string strPassword)
        {
            _Password = strPassword;
            _UserName = strCustomerName;
            DataTable dtTemp = GetCustomerUsingUserNamePassword();
            if (dtTemp.Rows.Count > 0)
            {
                CachCustomerTable = dtTemp;
                SetData(dtTemp.Rows[0]);
            }

        }
        public CustomerDb(string strCustomerName)
        {
            _UserName = strCustomerName;
            DataTable dtTemp = GetCustomerUsingUserName();
            if (dtTemp.Rows.Count > 0)
            {
                CachCustomerTable = dtTemp;
                SetData(dtTemp.Rows[0]);
            }
        }
        #endregion
        #region Public Properties
        public DataTable UnitInstant
        {
            set
            {
                _UnitInstant = value;
            }
        }
        public DataTable ContactInstant
        {
            set
            {
                _ContactInstant = value;
            }
        }
        public DataTable ServiceInstant
        {
            set
            {
                _ServiceInstant = value;
            }
        }
        public CountryDb CountryDb
        {
            set
            {
                _CountryDb = value;
            }
            get
            {
                return _CountryDb;
            }
        }
        public int CountryID
        {
            set
            {
                _CountryID = value;
            }
            get
            {
                return _CountryID;
            }
        }
        public JobDb JobDb
        {
            set
            {
                _JobDb = value;
            }
            get
            {
                return _JobDb;
            }
        }
        public int JobID
        {
            set
            {
                _JobID = value;
            }
            get
            {
                return _JobID;
            }
        }
        public CustomerTypeDb CustomerTypeDb
        {
            set
            {
                _CustomerTypeDb = value;
            }
            get
            {
                return _CustomerTypeDb;
            }
        }
        public int CustomerTypeID
        {
            set
            {
                _CustomerTypeID = value;
            }
            get
            {
                return _CustomerTypeID;
            }
        }
        public string JobDesc
        {
            set
            {
                _JobDesc = value;
            }
            get
            {
                return _JobDesc;
            }
        }
        public string WorkDest
        {
            set
            {
                _WorkDest = value;
            }
            get
            {
                return _WorkDest;
            }
        }
        public string WorkAddress
        {
            set
            {
                _WorkAddress = value;
            }
            get
            {
                return _WorkAddress;
            }
        }
        public string Address
        {
            set
            {
                _Address = value;
            }
            get
            {
                if (_Address == null)
                    _Address = "";
                return _Address;
            }
        }
        public string HomePhone
        {
            set
            {
                _HomePhone = value;
            }
            get
            {
                return _HomePhone;
            }
        }
        public string WorkPhone
        {
            set
            {
                _WorkPhone = value;
            }
            get
            {
                return _WorkPhone;
            }
        }
        public string Mobile
        {
            set
            {
                _Mobile = value;
            }
            get
            {
                if (_Mobile == null)
                    _Mobile = "";
                return _Mobile;
            }
        }
        //new Data
        public string SecondMobile
        {
            set
            {
                _SecondMobile = value;
            }
            get
            {
                return _SecondMobile;
            }
        }
        public int HomeCountry
        {
            set
            {
                _HomeCountry = value;

            }
            get
            {
                return _HomeCountry;
            }
        }
        public int HomeCity
        {
            set
            {
                _HomeCity = value;
            }
            get
            {
                return _HomeCity;
            }
        }
        public int HomeRegion
        {
            set
            {
                _HomeRegion = value;
            }
            get
            {
                return _HomeRegion;
            }
        }
        public int WorkCountry
        {
            set
            {
                _WorkCountry = value;
            }
            get
            {
                return _WorkCountry;
            }
        }
        public int WorkCity
        {
            set
            {
                _WorkCity = value;
            }
            get
            {
                return _WorkCity;
            }
        }
        public int WorkRegion
        {
            set
            {
                _WorkRegion = value;
            }
            get
            {
                return _WorkRegion;
            }
        }
        public string HomeCountryName
        {
            get
            {
                return _HomeCountryName;
            }
        }
        public string HomeCityName
        {
            get
            {
                return _HomeCityName;
            }
        }
        public string HomeRegionName
        {
            get
            {
                return _HomeRegionName;
            }
        }
        public string WorkCountryName
        {
            get
            {
                return _WorkCountryName;
            }
        }
        public string WorkCityName
        {
            get
            {
                return _WorkCityName;
            }
        }
        public string WorkRegionName
        {
            get
            {
                return _WorkRegionName;
            }
        }
        public bool IsBirthDate
        {
            set
            {
                _IsBirthDate = value;
            }
            get
            {
                return _IsBirthDate;
            }
        }

        public string PhoneSearchNum
        {
            set
            {
                _PhoneSearchNum = value;
            }
            get
            {
                return _PhoneSearchNum;
            }
        }

        // end new data
        public string MailAddress
        {
            set
            {
                _MailAddress = value;
            }
            get
            {
                return _MailAddress;
            }
        }
        public int Sex
        {
            set
            {
                _Sex = value;
            }
            get
            {
                return _Sex;
            }
        }
        public DateTime BirthDate
        {
            set
            {
                _BirthDate = value;
            }
            get
            {
                return _BirthDate;
            }
        }
        public IDTypeInstantDb IDTypeInstantDb
        {
            set
            {
                _IDTypeDb = value;
            }
            get
            {
                return _IDTypeDb;
            }
        }
        public int IDTypeID
        {
            set
            {
                _IDTypeID = value;
            }
            get
            {
                return _IDTypeID;
            }
        }
        public string IDTypeValue
        {
            set
            {
                _IDTypeValue = value;
            }
            get
            {
                return _IDTypeValue;
            }
        }
        public string UserName
        {
            set
            {
                _UserName = value;
            }
            get
            {
                return _UserName;
            }
        }
        public string Password
        {
            set
            {
                _Password = value;
            }
            get
            {
                return _Password;
            }
        }
        public double Debt
        {
            set
            {
                _Debt = value;
            }
            get
            {
                return _Debt;
            }
        }
        public double Due
        {
            set
            {
                _Due = value;
            }
            get
            {
                return _Due;
            }
        }
        public string NameLike
        {
            set
            {
                _NameLike = value;
            }
        }
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }
        }
        public bool HasReservation
        {
            set
            {
                _HasReservation = value;
            }
        }
        public byte HasContactStatus
        {
            set
            {
                _HasContactStatus = value;
            }
        }
        public byte HasAttachmentStatus
        {
            set
            {
                _HasAttachmentStatus = value;
            }
        }
        public string StatusStr
        {
            set
            {
                _StatusStr = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public string CustomerReservationIDs
        {
            set
            {
                _CustomerReservationIDs = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }

        }
        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public string MaxName
        {
            set
            {
                _MaxName = value;
            }

        }
        public string MinName
        {
            set
            {
                _MinName = value;
            }
        }
        public int ReservationStartCount
        {
            set
            {
                _ReservationStartCount = value;
            }
        }
        public int ReservationEndCount
        {
            set
            {
                _ReservationEndCount = value;
            }
        }
        public bool ContractingDateRange
        {
            set
            {
                _ContractingDateRange = value;
            }
        }
        public int CampaignID
        {
            set
            {
                _CampaignID = value;
            }
        }
        public int CampaignDealStatus
        {
            set
            {
                _CampaignDealStatus = value;
            }

        }
        public DateTime ContractingEndDate
        {
            set
            {
                _ContractingEndDate = value;
            }
        }
        public DateTime ContractingStartDate
        {
            set
            {
                _ContractingStartDate = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
        }
        string _ProjectIDs;
        public string ProjectIDs
        {
            set
            {
                _ProjectIDs = value;
            }
        }
        public double ReservationStartValue
        {
            set
            {
                _ReservationStartValue = value;
            }
        }
        public double ReservationEndValue
        {
            set
            {
                _ReservationEndValue = value;
            }
        }
        public static DataTable CachCustomerTable
        {
            set
            {
                _CachCustomerTable = value;
            }
            get
            {
                return _CachCustomerTable;
            }
        }
        public static DataTable CacheCustomerContactTable
        {
            set
            {
                _CacheCustomerContactTable = value;
            }
            get
            {
                if (_CacheCustomerContactTable == null && 
                    ((_IDStr != null && _IDStr != "")||
                    (_CustomerReservationIDs != null && _CustomerReservationIDs != "")))
                {
                    CustomerDb objDb = new CustomerDb();
                    _CacheCustomerContactTable = objDb.GetCustomerContact();

                }
                return _CacheCustomerContactTable;
            }
        }
        public static DataTable CacheReservationTable
        {
            set
            {
                _CacheReservationTable = value;
            }
            get
            {
                if (_CacheReservationTable == null && _IDStr != null && _IDStr != "")
                {
                    ReservationDb objTemp = new ReservationDb();
                    string strSql = "SELECT CRMReservationCustomer.CustomerID as ReservationCustomer,ReservationTable.* " +
                                           " FROM         dbo.CRMReservationCustomer inner join (" + objTemp.SearchStr + ") as ReservationTable " +
                                           " on ReservationTable.ReservationID = CRMReservationCustomer.ReservationID  " +
                                           " where CRMReservationCustomer.CustomerID in (" + _IDStr + ") ";

                    _CacheReservationTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
                   // ReservationDb.ReservationIDs = "select distinct ReservationID from (" + strSql + ") as ReservationNativeTable";
                    ReservationDb.ReservationIDs = "SELECT ReservationID " +
                         " FROM         dbo.CRMReservationCustomer " +
                         " WHERE     (CustomerID IN (" + _IDStr + ")) ";
                    ReservationDb.CachUnitTable = null;
                    ReservationDb.CachCellTable = null;


                }
                return _CacheReservationTable;
            }
        }
        public static string IDsStr
        {
            set
            {
                _IDStr = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public string ModelIDs
        {
            set
            {
                _ModelIDs = value;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public int MobileStatus
        {
            set
            {
                _MobileStatus = value;
            }
        }
        public int AddressStatus
        {
            set
            {
                _AddressStatus = value;
            }
        }
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
        int _EmployeeID;
        public int EmployeeID
        {
            set { _EmployeeID = value; }
            get { return _EmployeeID; }
        }
        string _EmployeeCode;
        public string EmployeeCode
        {
            set { _EmployeeCode = value; }
            get { return _EmployeeCode; }
        }
        string _EmployeeName;
        public string EmployeeName
        {
            set { _EmployeeName = value; }
            get { return _EmployeeName; }
        }
        public string UnitStr
        {
            get
            {
                string strUnitProject = "SELECT DISTINCT dbo.CRMUnitCell.UnitID, dbo.CRMUnit.UnitFullName" +
                    ", CASE WHEN TowerTable.CellAlterName IS NULL OR " +
                      " TowerTable.CellAlterName = '' THEN TowerTable.CellNameA ELSE TowerTable.CellAlterName END AS TowerName, " +
                      " CASE WHEN ProjectTable.CellAlterName IS NULL OR " +
                      " ProjectTable.CellAlterName = '' THEN ProjectTable.CellNameA ELSE ProjectTable.CellAlterName END AS ProjectName " +
                      " FROM  dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                      " dbo.RPCell AS FloorTable ON dbo.CRMUnitCell.CellID = FloorTable.CellID INNER JOIN " +
                      " dbo.RPCell AS TowerTable ON FloorTable.CellParentID = TowerTable.CellID INNER JOIN " +
                      " dbo.RPCell AS ProjectTable ON TowerTable.CellFamilyID = ProjectTable.CellID ";
                string Returned = "SELECT  TOP (100) PERCENT dbo.CRMReservationCustomer.CustomerID, MAX(dbo.CRMUnit.UnitID) AS MaxUnitID, MIN(dbo.CRMUnit.UnitID) AS MinUnitID, " +
                      " COUNT(dbo.CRMUnit.UnitID) AS UnitCount " +
                      " FROM    dbo.CRMReservationCustomer INNER JOIN " +
                      " dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation " +
                      " GROUP BY dbo.CRMReservationCustomer.CustomerID ";
                Returned = "select CustomerUnitTable.CustomerID UnitCustomerID , CustomerUnitTable.UnitCount " +
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
                " from (" + Returned + ") as CustomerUnitTable " +
                " inner join (" + strUnitProject + ") MinUnitTable " +
                " on CustomerUnitTable.MinUnitID = MinUnitTable.UnitID " +
                " inner join (" + strUnitProject + ") as MaxUnitTable " +
                " on CustomerUnitTable.MaxUnitID = MaxUnitTAble.UnitID  ";
                return Returned;
            }
        }
        public string SingleSearchStr
        {
            get
            {
               string Returned = "SELECT CustomerID, CustomerFullName, IDValue, CustomerName, CustomerFullNameComp, CustomerSex, CustomerBirthDate, CustomerPassword, CustomerWorkAddress, " +
                      " CustomerAddress, CustomerHomePhone, CustomerWorkPhone, CustomerMobile, CustomerSecondMobile, CustomerMailAddress " +
                    " FROM   dbo.CRMCustomer ";
                return Returned;
            }
        }
        public  string SearchStr
        {
            get
            {

               string strCustomerUnit = UnitStr;

                string strUnitJoinType = " left outer join ";
                if ((_ReservationIDs != null && _ReservationIDs != "") || _HasReservation || (_UnitCode != null && _UnitCode != "") || _ContractingDateRange)
                    strUnitJoinType = " inner join ";
                string strEmployee = "SELECT  dbo.HRApplicantWorker.ApplicantID AS EmployeeID, dbo.HRApplicantWorker.ApplicantCode AS EmployeeCode, dbo.HRApplicant.ApplicantFirstName AS EmployeeName "+
                       " FROM            dbo.HRApplicantWorker INNER JOIN "+
                         " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID "; 
                string Returned = " SELECT dbo.CRMCustomer.CustomerID, dbo.CRMCustomer.CustomerFullName,dbo.CRMCustomer.CustomerFullNameComp, dbo.CRMCustomer.IDValue" +
                    ", dbo.CRMCustomer.CustomerIDType,dbo.CRMCustomer.CustomerParentID,CustomerJobDesc, CustomerWorkDest, CustomerWorkAddress, CustomerAddress, CustomerHomePhone, CustomerWorkPhone, CustomerMobile, CustomerMailAddress," +
                    " dbo.CRMCustomer.CustomerFamilyID,dbo.CRMCustomer.CustomerDebtAmount,dbo.CRMCustomer.CustomerDueAmount,CustomerName,CustomerPassword,CustomerSex, CustomerBirthDate,CustomerSecondMobile," +
                    " CustomerHomeCountry, CustomerHomeCity, CustomerHomeRegion, CustomerWorkCountry, CustomerWorkCity, CustomerWorkRegion, " +
                    " Resdintialcountry.CountryNameA as ResdintialCountryNameA,Workcountry.CountryNameA as WorkCountryNameA,ResdintialCity.CityNameA as ResdintialCityNameA,WorkCity.CityNameA as WorkCityNameA,ResdintialRegion.RegionNameA as ResdintialRegionNameA,WorkRegion.RegionNameA as WorkRegionNameA" +
                    ",IDTypeTable.*,CountryTable.*,JobTable.*,CustomerTypeTable.*"+
                    ",CustomerUnitTable.* ,EmployeeTable.* " +
                     " FROM    dbo.CRMCustomer left  outer JOIN (" + JobDb.SearchStr + ") as JobTable " +
                     "  ON dbo.CRMCustomer.CustomerJob = JobTable.JobID "+
                     " left outer JOIN (" + IDTypeDb.SearchStr + ") as IDTypeTable " +
                     " ON dbo.CRMCustomer.CustomerIDType = IDTypetable.IDtypeID "+
                     " left outer JOIN (" + CountryDb.SearchStr + ") as CountryTable " +
                     " ON dbo.CRMCustomer.CustomerNationality = CountryTable.CountryID  " +
                     "  left outer  JOIN (" + CustomerTypeDb.SearchStr + ") as CustomerTypeTable " +
                     " ON dbo.CRMCustomer.CustomerType = CustomerTypeTable.CustomerTypeID " +
                     " left outer join dbo.COMMONCountry as Resdintialcountry on Resdintialcountry.CountryID = dbo.CRMCustomer.CustomerHomeCountry " +
                     " left outer join dbo.COMMONCountry as Workcountry on Workcountry.CountryID = dbo.CRMCustomer.CustomerHomeCountry " +
                     " left outer join dbo.COMMONCity as ResdintialCity on ResdintialCity.CityID = dbo.CRMCustomer.CustomerHomeCity" +
                     " left outer join dbo.COMMONCity as WorkCity on WorkCity.CityID = dbo.CRMCustomer.CustomerWorkCity" +
                     " left outer join dbo.COMMONRegion as ResdintialRegion on ResdintialRegion.RegionID = dbo.CRMCustomer.CustomerHomeRegion" +
                     " left outer join dbo.COMMONRegion as WorkRegion on WorkRegion.RegionID = dbo.CRMCustomer.CustomerWorkRegion" +
                     strUnitJoinType +  "(" + strCustomerUnit + ") as CustomerUnitTable "+
                     " on CRMCustomer.CustomerID = CustomerUnitTable.UnitCustomerID  "+
                     " left outer join (" + strEmployee + ") as EmployeeTable "+
                     " on   dbo.CRMCustomer.CustomerResponsibleEmployee = EmployeeTable.EmployeeID ";
                if (_CampaignID != 0)
                {
                    string strCampaignCustomer = @"SELECT DISTINCT dbo.CRMCampaignCustomer_ICampaign.Campaign, dbo.CRMCampaignCustomer.Customer
FROM            dbo.CRMCampaignCustomer INNER JOIN
                         dbo.CRMCampaignCustomer_ICampaign ON dbo.CRMCampaignCustomer.CampaignCustomerID = dbo.CRMCampaignCustomer_ICampaign.CampaignCustomerID
WHERE        (dbo.CRMCampaignCustomer_ICampaign.Campaign = "+ _CampaignID +@")";
                    if (_CampaignDealStatus == 1)
                        Returned += " inner join ";
                    else
                        Returned += " left outer join ";
                   Returned += " (" + strCampaignCustomer + ") as CampaignCustomerTable " +
                                " on CRMCustomer.CustomerID = CampaignCustomerTable.Customer ";
                }
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["CustomerID"].ToString());
            _NameA = objDr["CustomerFullname"].ToString();
            _NameE = objDr["CustomerFullname"].ToString();
            if (objDr.Table.Columns["CustomerName"]!= null && objDr["CustomerName"].ToString() != "")
            {
                _UserName = objDr["CustomerName"].ToString();
            }
            else
            {
                _UserName = "";
            }
            if (objDr.Table.Columns["CustomerPassword"]!= null && objDr["CustomerPassword"].ToString() != "")
            {
                _Password = objDr["CustomerPassword"].ToString();
            }
            else
            {
                _Password = "";
            }
            //_UserName = DR["CustomerName"].ToString();
            //_Password = DR["CustomerPassword"].ToString();
            if (objDr.Table.Columns["CustomerParentID"] != null && objDr["CustomerParentID"].ToString()!= "")
            {
                _ParentID = int.Parse(objDr["CustomerParentID"].ToString());
                _FamilyID = int.Parse(objDr["CustomerFamilyID"].ToString());
                _Debt = double.Parse(objDr["CustomerDebtAmount"].ToString());
                _Due = double.Parse(objDr["CustomerDueAmount"].ToString());
            }
            if (objDr.Table.Columns["JobID"]!= null && objDr["JobID"].ToString() != "" && objDr["JobID"].ToString() != "0")
            {
                _JobID = int.Parse(objDr["JobID"].ToString());
                try
                {
                    _JobDb = new JobDb(objDr);
                }
                catch
                {
                }
            }
            else
                _JobDb = new JobDb();
            if (objDr.Table.Columns["CountryID"]!= null && objDr["CountryID"].ToString() != "" && objDr["CountryID"].ToString() != "0")
            {
                _CountryID = int.Parse(objDr["CountryID"].ToString());
                try
                {
                    _CountryDb = new CountryDb(objDr);
                }
                catch
                {
                }
            }
            else
                _CountryDb = new CountryDb();


            #region // New Data
            _SecondMobile = objDr["CustomerSecondMobile"].ToString();
            if (objDr.Table.Columns["CustomerHomeCountry"]!= null && objDr["CustomerHomeCountry"].ToString() != "")
                _HomeCountry = int.Parse(objDr["CustomerHomeCountry"].ToString());
            if (objDr.Table.Columns["CustomerHomeCity"]!= null &&  objDr["CustomerHomeCity"].ToString() != "")
                _HomeCity = int.Parse(objDr["CustomerHomeCity"].ToString());
            if (objDr.Table.Columns["CustomerHomeRegion"]!= null && objDr["CustomerHomeRegion"].ToString() != "")
                _HomeRegion = int.Parse(objDr["CustomerHomeRegion"].ToString());
            if (objDr.Table.Columns["CustomerWorkCountry"] != null&& objDr["CustomerWorkCountry"].ToString() != "")
                _WorkCountry = int.Parse(objDr["CustomerWorkCountry"].ToString());
            if (objDr.Table.Columns["CustomerWorkCity"] != null&& objDr["CustomerWorkCity"].ToString() != "")
                _WorkCity = int.Parse(objDr["CustomerWorkCity"].ToString());
            //  if (DR["CustomerWorkRegion"].ToString() != "" && DR["CustomerWorkRegion"].ToString() != "0")
            if (objDr.Table.Columns["CustomerWorkRegion"] != null&&objDr["CustomerWorkRegion"].ToString() != "")
                _WorkRegion = int.Parse(objDr["CustomerWorkRegion"].ToString());
            if(objDr.Table.Columns["ResdintialCountryNameA"]!= null)
            _HomeCountryName = objDr["ResdintialCountryNameA"].ToString();
            if(objDr.Table.Columns["ResdintialCityNameA"]!= null)
            _HomeCityName = objDr["ResdintialCityNameA"].ToString();
            if(objDr.Table.Columns["ResdintialRegionNameA"]!= null)
            _HomeRegionName = objDr["ResdintialRegionNameA"].ToString();
            if(objDr.Table.Columns["WorkCountryNameA"]!= null)
            _WorkCountryName = objDr["WorkCountryNameA"].ToString();
            if(objDr.Table.Columns["WorkCityNameA"]!= null)
            _WorkCityName = objDr["WorkCityNameA"].ToString();
            if(objDr.Table.Columns["WorkRegionNameA"]!= null)
            _WorkRegionName = objDr["WorkRegionNameA"].ToString();


            #endregion  // end new data



            if (objDr.Table.Columns["CustomerTypeID"]!= null && objDr["CustomerTypeID"].ToString() != "" && objDr["CustomerTypeID"].ToString() != "0")
            {
                _CustomerTypeID = int.Parse(objDr["CustomerTypeID"].ToString());
                try
                {
                    _CustomerTypeDb = new CustomerTypeDb(objDr);
                }
                catch
                {

                }
            }
            else
                _CustomerTypeDb = new CustomerTypeDb();
            _IDTypeValue = objDr["IDValue"].ToString();
            if (objDr.Table.Columns["IDTypeID"] != null && objDr["IDTypeID"].ToString() != "" && objDr["IDTypeID"].ToString() != "0")
            {
                _IDTypeID = int.Parse(objDr["IDTypeID"].ToString());

                try
                {

                    _IDTypeDb = new IDTypeInstantDb(objDr);
                }
                catch
                {
                }
            }
            else
            {
                _IDTypeDb = new IDTypeInstantDb();
                _IDTypeDb.IDValue = _IDTypeValue;
            }
            if(objDr.Table.Columns["CustomerJobDesc"]!= null)
            _JobDesc = objDr["CustomerJobDesc"].ToString();
            if(objDr.Table.Columns["CustomerWorkDest"]!= null)
            _WorkDest = objDr["CustomerWorkDest"].ToString();
            _WorkAddress = objDr["CustomerWorkAddress"].ToString();
            _Address = objDr["CustomerAddress"].ToString();
            _HomePhone = objDr["CustomerHomePhone"].ToString();
            _WorkPhone = objDr["CustomerWorkPhone"].ToString();
            _Mobile = objDr["CustomerMobile"].ToString();
            _MailAddress = objDr["CustomerMailAddress"].ToString();

            if (objDr["CustomerBirthDate"].ToString() != "")
                _BirthDate = DateTime.Parse(objDr["CustomerBirthDate"].ToString());
            if (objDr["CustomerSex"].ToString() != "")
                _Sex = int.Parse(objDr["CustomerSex"].ToString());
        
            if (objDr.Table.Columns["CustomerUnitFullName"] != null)
                _UnitFullName = objDr["CustomerUnitFullName"].ToString();

       
            if (objDr.Table.Columns["CustomerTowerName"] != null)
                _TowerName = objDr["CustomerTowerName"].ToString();

       
            if (objDr.Table.Columns["CustomerProjectName"] != null)
                _ProjectName = objDr["CustomerProjectName"].ToString();
            if (objDr.Table.Columns["EmployeeID"] != null)
            {
                int.TryParse(objDr["EmployeeID"].ToString(), out _EmployeeID);
                _EmployeeCode = objDr["EmployeeCode"].ToString();
                _EmployeeName = objDr["EmployeeName"].ToString();
            }


        }
        DataTable GetCustomers()
        {
            string strSql = "SELECT top 100 CustomerID, CustomerParentID, CustomerFamilyID FROM  dbo.CRMCustomer ";
            if (_ID != 0)
                strSql = strSql + " where CustomerID = " + _ID;
            else
            {
                strSql = strSql + " WHERE     CRMCustomer.dis   is Null ";

                if (Name != null && Name != "")
                    strSql = strSql + " and CustomerFullName  like'" + Name.Replace("'", "''") + "%' ";

                if (_CustomerTypeDb.ID != 0)
                    strSql = strSql + "  and CustomerType = " + _CustomerTypeDb.ID;
                if (_JobDb.ID != 0)
                    strSql = strSql + "  and CustomerJob = " + _JobDb.ID;
                if (_CountryDb != null && _CountryDb.ID != 0)
                    strSql = strSql + " and CustomerNationality = " + _CountryDb.ID;
                if (_IDTypeDb.ID != 0)
                    strSql = strSql + "  and CustomerIDType = " + _IDTypeDb.ID;
                if (_IDTypeDb.IDValue != null && _IDTypeDb.IDValue != "")
                    strSql = strSql + "  and IDValue = '" + _IDTypeDb.IDValue + "'";
                if (_NameLike != "")
                    strSql = strSql + "  and CustomerFullName like '%" + _NameLike + "%' ";
                if (_ParentID != 0)
                    strSql = strSql + " and CustomerParentID = " + _ParentID;
                if (_HasReservation || (_UnitCode != null && _UnitCode != ""))
                {
                    string strReservation = "SELECT CustomerID FROM CRMReservationCustomer inner join " +
                        " CRMReservation on CRMReservation.ReservationID  = CRMReservationCustomer.ReservationID " +
                        " inner join CRMReservationUnit on CRMReservation.ReservationID = CRMReservationUnit.ReservationID " +
                        "inner join CRMUnit on CRMReservationUnit.UnitID = CRMUnit.UnitID where 1=1 ";
                    string strSubWhere = "";
                    //strSubWhere ";
                    if (_ReservationStatus != 0)
                        strSubWhere = " and ReservationStatus =" + _ReservationStatus;
                    if (_StatusStr != null && _StatusStr != "" && _StatusStr != "0")
                    {
                        strSubWhere = " and ReservationStatus in(" + _StatusStr + ") ";
                    }
                    if (_UnitCode != null && _UnitCode != "")
                        strSubWhere += " and CRMUnit.UnitCode = '" + _UnitCode + "'";
                    strReservation += strSubWhere;
                    strSql = strSql + " and CustomerID in (" + strReservation + ")";
                }
                if (_ReservationIDs != null && _ReservationIDs != "")
                    strSql = strSql + " and CustomerID in (SELECT ReservationCustomerID " +
                        " FROM CRMReservation where ReservationID in (" + _ReservationIDs + ") )";
                if (_HasContactStatus != 0)
                {
                    if (_HasContactStatus == 1)
                        strSql += " and CustomerID not in (SELECT  CustomerID " +
                         " FROM  CRMCustomerContact)";
                    else
                        strSql += " and CustomerID  in (SELECT  CustomerID " +
                         " FROM  CRMCustomerContact)";
                }
                if (_HasAttachmentStatus != 0)
                {
                    if (_HasAttachmentStatus == 1)
                        strSql += " and CustomerID not in (SELECT  CustomerID " +
                         " FROM  CRMCustomerAttachment) and CustomerID not in (SELECT dbo.CRMReservationCustomer.CustomerID " +
                        " FROM         dbo.CRMReservationCustomer INNER JOIN " +
                        " dbo.CRMReservationAttachment ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservationAttachment.ReservationID)";
                    else
                        strSql += " and (CustomerID  in (SELECT  CustomerID " +
                         " FROM  CRMCustomerAttachment) or CustomerID in (SELECT dbo.CRMReservationCustomer.CustomerID " +
                        " FROM         dbo.CRMReservationCustomer INNER JOIN " +
                        " dbo.CRMReservationAttachment ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservationAttachment.ReservationID))";

                }


            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        void SetOldRelatedCustomers(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("CustomerParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["CustomerID"].ToString();
                strIDs = strIDs + objDR["CustomerID"].ToString();
                SetOldRelatedCustomers(strTempParent, dtTemp, ref strIDs);
            }
        }
        public void SetRecursiveTable(string strParentCustomerID, ref DataTable dtDist, DataTable dtSource)
        {
            DataRow[] arrDr = dtSource.Select("CustomerID=" + strParentCustomerID);
            if (arrDr.Length == 0)
                return;
            string strTemp = arrDr[0]["CustomerParentID"].ToString();
            dtDist.ImportRow(arrDr[0]);
            if (strTemp != strParentCustomerID)
            {
                SetRecursiveTable(strTemp, ref dtDist, dtSource);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;

            double dblBirthDate;
            if (_IsBirthDate == true)
                dblBirthDate = _BirthDate.ToOADate() - 2;
            else
                dblBirthDate = 0;

            int intVIP = 0;

            string strSql = "insert into CRMCustomer (CustomerFullName,CustomerFullNameComp, IDValue, CustomerIDType, CustomerNationality, " +
                            "CustomerType,CustomerJob," +
                            " CustomerJobDesc, CustomerWorkDest, CustomerWorkAddress, CustomerAddress, CustomerHomePhone, CustomerWorkPhone, CustomerMobile, CustomerMailAddress" +
                            " , CustomerVIP, CustomerParentID, CustomerFamilyID,CustomerName,CustomerPassword,CustomerSex, CustomerBirthDate,CustomerSecondMobile, CustomerHomeCountry, CustomerHomeCity, CustomerHomeRegion, CustomerWorkCountry, CustomerWorkCity, CustomerWorkRegion,CustomerResponsibleEmployee,UsrIns,TimIns) " +
                            " values('" + Name + "','" + SysUtility.ReplaceStringComp(Name) + "','" + _IDTypeValue + "'," + _IDTypeID + "," + _CountryID + "," + _CustomerTypeID + "," + _JobID + "" +
                            " ,'" + _JobDesc + "','" + _WorkDest + "','" + _WorkAddress + "','" + _Address + "','" + _HomePhone + "', '" + _WorkPhone + "', '" + _Mobile + "', '" + _MailAddress + "'" +
                            " ," + intVIP + "," + _ParentID + "," + _FamilyID + ",'" + _UserName + "','" + _Password + "'," + _Sex + "," + dblBirthDate + ",'" + 
                            _SecondMobile + "', " + _HomeCountry + ", " + _HomeCity + ", " + _HomeRegion + ", " + 
                            _WorkCountry + ", " + _WorkCity + ", " + _WorkRegion+ "," + _EmployeeID + "," + SysData.CurrentUser.ID + ",GetDate())";


            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.InsertIdentityTable(strSql));
            if (_ParentID == 0)
            {
                strSql = "update CRMCustomer set CustomerParentID =" + _ID + ",CustomerFamilyID=" + _ID + " where CustomerID= " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ParentID = _ID;
                _FamilyID = _ID;

            }



        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;

            double dblBirthDate;
            if (_IsBirthDate == true)
                dblBirthDate = _BirthDate.ToOADate() - 2;
            else
                dblBirthDate = 0;

            int intVIP = 0;
            string strSql = "update  CRMCustomer ";
            strSql = strSql + " set CustomerFullName='" + Name + "'";
            strSql = strSql + " , CustomerFullNameComp='" + SysUtility.ReplaceStringComp(Name) + "'";
            strSql = strSql + ", IDValue = '" + _IDTypeValue + "'";
            strSql = strSql + ", CustomerIDType =" + _IDTypeID;
            strSql = strSql + ",CustomerNationality =" + _CountryID;
            strSql = strSql + ",CustomerType =" + _CustomerTypeID;
            strSql = strSql + ",CustomerJob=" + _JobID;
            strSql = strSql + ",CustomerJobDesc='" + _JobDesc + "'";
            strSql = strSql + ", CustomerWorkDest='" + _WorkDest + "'";
            strSql = strSql + ", CustomerWorkAddress='" + _WorkAddress + "'";
            strSql = strSql + " , CustomerAddress='" + _Address + "'";
            strSql = strSql + ", CustomerHomePhone='" + _HomePhone + "'";
            strSql = strSql + ", CustomerWorkPhone='" + _WorkPhone + "'";
            strSql = strSql + ", CustomerMobile='" + _Mobile + "'";

            // New Data
            strSql = strSql + ",CustomerSecondMobile ='" + _SecondMobile + "'";
            strSql = strSql + ",CustomerHomeCountry=" + _HomeCountry;
            strSql = strSql + ",CustomerHomeCity=" + _HomeCity;
            strSql = strSql + ",CustomerHomeRegion=" + _HomeRegion;
            strSql = strSql + ",CustomerWorkCountry=" + _WorkCountry;
            strSql = strSql + ",CustomerWorkCity=" + _WorkCity;
            strSql = strSql + ",CustomerWorkRegion=" + _WorkRegion;
            // End New Data
            strSql = strSql + ", CustomerMailAddress = '" + _MailAddress + "'";
            strSql = strSql + ",CustomerParentID=" + _ParentID;
            strSql = strSql + ",CustomerFamilyID=" + _FamilyID;
            strSql = strSql + ",CustomerSex = " + _Sex;
            strSql = strSql + ",CustomerBirthDate = " + dblBirthDate;
            strSql += ",CustomerResponsibleEmployee =" + _EmployeeID;
            strSql = strSql + ",UsrUpd=" + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd=GetDate()";
            strSql = strSql + " where CustomerID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from CRMCustomer where CustomerFamilyID in" +
                   "(select CustomerFamilyID from CRMCustomer where CustomerFamilyID=" + _ID + "and CustomerID<>" + _ID + "and CustomerFamilyID<>" + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCustomers(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update CRMCustomer set CustomerFamilyID = " + _FamilyID + " where CustomerID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public  void EditContactData()
        {
            
            string strSql = "update  CRMCustomer "+
            " set  CustomerWorkAddress='" + _WorkAddress + "'"+
              " , CustomerAddress='" + _Address + "'"+
            ", CustomerHomePhone='" + _HomePhone + "'"+
            ", CustomerWorkPhone='" + _WorkPhone + "'"+
            ", CustomerMobile='" + _Mobile + "'"+
            ",CustomerSecondMobile ='" + _SecondMobile + "'"+
           ", CustomerMailAddress = '" + _MailAddress + "'"+
            ",UsrUpd=" + SysData.CurrentUser.ID+
             ",TimUpd=GetDate()"+
             " where CustomerID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public override void Delete()
        {
            string strSql = "update CRMCustomer set Dis =GetDate() where CustomerID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {



            string strSql = SearchStr + " WHERE     CRMCustomer.dis   is Null ";
            if (_ID != 0)
                strSql = strSql + " and CustomerID = " + _ID;
          
               // strSql = strSql + " WHERE     CRMCustomer.dis   is Null ";
                if(_CustomerIDs != null && _CustomerIDs != "")
                strSql+= " and CustomerID in (" + _CustomerIDs + ")" ;
                if (Name != null && Name != "")
                    strSql = strSql + " and CustomerFullName  like'" + Name.Replace("'", "''") + "%' ";

                if (_CustomerTypeDb.ID != 0)
                    strSql = strSql + "  and CustomerType = " + _CustomerTypeDb.ID;
                if (_JobDb.ID != 0)
                    strSql = strSql + "  and CustomerJob = " + _JobDb.ID;
                if (_CountryDb != null && _CountryDb.ID != 0)
                    strSql = strSql + " and CustomerNationality = " + _CountryDb.ID;
                if (_IDTypeDb.ID != 0)
                    strSql = strSql + "  and CustomerIDType = " + _IDTypeDb.ID;
                if (_IDTypeDb.IDValue != null && _IDTypeDb.IDValue != "")
                    strSql = strSql + "  and IDValue = '" + _IDTypeDb.IDValue + "'";
                if (_NameLike != "")
                    strSql = strSql + "  and dbo.ReplaceStringComp(CustomerFullName) like '%" + SysUtility.ReplaceStringComp(_NameLike) + "%' ";
                if (_ParentID != 0)
                    strSql = strSql + " and CustomerParentID = " + _ParentID;
                if (_HasReservation || (_UnitCode != null && _UnitCode != "") || _ContractingDateRange)
                {
                    string strReservation = "SELECT CustomerID FROM CRMReservationCustomer inner join " +
                        " CRMReservation on CRMReservation.ReservationID  = CRMReservationCustomer.ReservationID " +
                        " inner join CRMReservationUnit on CRMReservation.ReservationID = CRMReservationUnit.ReservationID " +
                        "inner join CRMUnit on CRMReservationUnit.UnitID = CRMUnit.UnitID where (1=1 )";
                    string strSubWhere = "";
                    //strSubWhere ";
                    if (_ReservationStatus != 0)
                        strSubWhere = " and ReservationStatus =" + _ReservationStatus;
                    if (_ContractingDateRange)
                    {

                        double dblStart = _ContractingStartDate.ToOADate() - 2;
                        dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                        double dblEnd = _ContractingEndDate.ToOADate() - 2;
                        dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);

                        strReservation += " and (ReservationContractingDate >=" + dblStart + ")" +
                            " and (ReservationContractingDate < " + dblEnd + ") ";

                    }
                    if (_StatusStr != null && _StatusStr != "" && _StatusStr != "0")
                    {
                        strSubWhere = " and ReservationStatus in(" + _StatusStr + ") ";
                    }
                    if (_UnitCode != null && _UnitCode != "")
                        strSubWhere += " and CRMUnit.UnitFullName = '" + _UnitCode + "'";
                    strReservation += strSubWhere;
                    strSql = strSql + " and CustomerID in (" + strReservation + ")";
                }
                if (_ReservationIDs != null && _ReservationIDs != "")
                    strSql = strSql + " and CustomerID in (SELECT ReservationCustomerID " +
                        " FROM CRMReservation where ReservationID in (" + _ReservationIDs + ") )";
                if (_HasContactStatus != 0)
                {
                    if (_HasContactStatus == 1)
                        strSql += " and CustomerID not in (SELECT  CustomerID " +
                         " FROM  CRMCustomerContact)";
                    else
                        strSql += " and CustomerID  in (SELECT  CustomerID " +
                         " FROM  CRMCustomerContact)";
                }
                if (_HasAttachmentStatus != 0)
                {
                    if (_HasAttachmentStatus == 1)
                        strSql += " and CustomerID not in (SELECT  CustomerID " +
                         " FROM  CRMCustomerAttachment) and CustomerID not in (SELECT dbo.CRMReservationCustomer.CustomerID " +
                        " FROM         dbo.CRMReservationCustomer INNER JOIN " +
                        " dbo.CRMReservationAttachment ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservationAttachment.ReservationID)";
                    else
                        strSql += " and (CustomerID  in (SELECT  CustomerID " +
                         " FROM  CRMCustomerAttachment) or CustomerID in (SELECT dbo.CRMReservationCustomer.CustomerID " +
                        " FROM         dbo.CRMReservationCustomer INNER JOIN " +
                        " dbo.CRMReservationAttachment ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservationAttachment.ReservationID))";
                }
                if (_MailAddress != null && _MailAddress != "")
                    strSql += " and CustomerMailAddress = '" + _MailAddress + "' ";
                if (_Mobile != null && _Mobile != "")
                    strSql += " and CustomerMobile = '" + _Mobile + "' ";
                if (_HomePhone != null && _HomePhone != "")
                    strSql += " and CustomerHomePhone = '" + _HomePhone + "' ";
                if (_WorkPhone != null && _HomePhone != "")
                    strSql += " and CustomerWorkPhone = '" + _WorkPhone + "' ";
                if (_AddressStatus != 0)
                {
                    if (_AddressStatus == 1)
                    {
                        strSql += " and CustomerAddress is not null and CustomerAddress <> '' ";
                    }
                    if (_AddressStatus == 2)
                        strSql += " and (CustomerAddress is null or CustomerAddress = '') ";
                }
                if (_MobileStatus != 0)
                {
                    if (_MobileStatus == 1)
                    {
                        strSql += " and CustomerMobile is not null and CustomerMobile <> '' ";
                    }
                    if (_MobileStatus == 2)
                        strSql += " and (CustomerMobile is null or CustomerMobile = '') ";
                }
                if (_PhoneSearchNum != null && _PhoneSearchNum != "")
                {
                    strSql += " and ( dbo.CRMCustomer.CustomerWorkAddress like '%" + _PhoneSearchNum + "%' " +
                        " or  dbo.CRMCustomer.CustomerAddress like '%" + _PhoneSearchNum + "%' " +
                        " or  dbo.CRMCustomer.CustomerHomePhone like '%" + _PhoneSearchNum + "%' " +
                        " or  dbo.CRMCustomer.CustomerWorkPhone like '%" + _PhoneSearchNum + "%' " +
                        " or dbo.CRMCustomer.CustomerMobile like '%" + _PhoneSearchNum + "%' " +
                        " or dbo.CRMCustomer.CustomerSecondMobile like '%" + _PhoneSearchNum + "%' ) ";
                }

            #region ReservationSearch
            if (_CellFamilyID != 0 ||
                (_CellIDs != null && _CellIDs != "") || (_ModelIDs != null && _ModelIDs != "") ||
                _ReservationEndCount != 0 || _ReservationEndValue != 0)
            {
                string strDiscountSum = "SELECT ReservationID as DiscountReservation, SUM(DiscountValue) AS DiscountValue " +
                  " FROM   dbo.CRMReservationDiscount " +
                  " GROUP BY ReservationID ";
                string strReservation = "SELECT ReservationID, ReservationCachePrice as CachePrice,case when " +
                    "DiscountTable.DiscountValue is null then 0 else DiscountTable.DiscountValue end as DiscountValue " +
                        " FROM  dbo.CRMReservation left outer join (" + strDiscountSum + ") as DiscountTable " +
                        " on CRMReservation.ReservationID = DiscountTable.DiscountReservation  where " +
                        " CRMReservation.ReservationStatus != 6 and CRMReservation.ReservationStatus != 5 ";
                string strReservationSearch = "SELECT distinct dbo.CRMReservationCustomer.CustomerID, dbo.CRMReservationCustomer.ReservationID " +
                    ",ReservationTable.CachePrice-ReservationTable.DiscountValue As ReservationValue " +
                     " FROM (" + strReservation + ") as ReservationTable inner join  dbo.CRMReservationCustomer on " +
                     " ReservationTable.ReservationID = CRMReservationCustomer.ReservationID " +
                     " INNER JOIN " +
                     " dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN " +
                     " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                     " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID  where (1=1) ";
                if (_CellFamilyID != 0)
                    strReservationSearch += " and RPCell.CellFamilyID = " + _CellFamilyID;
                if (_CellIDs != null && _CellIDs != "")
                    strReservationSearch += " and RPCell.CellID in (" + _CellIDs + ")";
                if (_ModelIDs != null && _ModelIDs != "")
                    strReservationSearch += " and CRMUnit.UnitModel in (" + _ModelIDs + ")";
                #region Hashed for A Parctical Reservation
                //if (_ReservationEndValue > 0)
                //    strReservationSearch += " and ReservationTable.CachePrice-ReservationTable.DiscountValue >= " + _ReservationStartValue +
                //        " and ReservationTable.CachePrice-ReservationTable.DiscountValue  <= " + _ReservationEndValue;
                #endregion
                strReservationSearch = "select CustomerID,Count(ReservationID) as ReservationCount,sum(Reservationvalue) as TotalReservationValue  from (" + strReservationSearch + ") as ReservationGroupingTable " +
                    " group by CustomerID";

                if (_ReservationEndCount > 0 || _ReservationEndValue > 0)
                {
                    string strHaveing = "";
                    if (_ReservationEndCount > 0)
                        strHaveing += " having Count(ReservationID)>= " + _ReservationStartCount + " and Count(ReservationID) <= " + _ReservationEndCount;
                    if (_ReservationEndValue > 0)
                    {
                        if (strHaveing == "")
                            strHaveing += " having ";
                        else
                            strHaveing += "and ";
                        strHaveing += " sum(Reservationvalue) >=" + _ReservationStartValue + " and sum(Reservationvalue) <= " + _ReservationEndValue;
                       
                    }
                    strReservationSearch += strHaveing;

                }
                strReservationSearch = "select CustomerID from (" + strReservationSearch + ") as ReservationCustomerTable ";
                strSql += " and CRMCustomer.CustomerID in (" + strReservationSearch + ")";


            }
            #endregion
            #region Campaign
            if (_CampaignID != 0)
            {
                if (_CampaignDealStatus != 1)
                    strSql += " and CampaignCustomerTable.Customer is null ";
                //if (_CampaignDealStatus == 1)
                //    strSql += " and CRMCustomer.CustomerID in (SELECT     Customer " +
                //            " FROM         dbo.CRMCampaignCustomer " +
                //            " WHERE     (Campaign = " + _CampaignID + "))";
                //else
                //    strSql += " and CRMCustomer.CustomerID not in (SELECT     Customer " +
                //       " FROM         dbo.CRMCampaignCustomer " +
                //       " WHERE     (Campaign = " + _CampaignID + "))";
            }
            #endregion
            if ((_MaxName == null || _MaxName == "") && (_MinName == null || _MinName == ""))
            {
                string strCountSql = "select count(*) as exp from (" + strSql + ")  AS NativeTable ";
                _ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
            }
            else
            {
                if (_MaxName != null && _MaxName != "")
                    strSql += " and CustomerFullName >'" + _MaxName + "'";
                else if (_MinName != null && _MinName != "")
                {
                    strSql += " and CustomerFullName<'" + _MinName + "'";
                }
            }

            strSql = "select top 1500 * from (" + strSql + ") as NativeTable order by CustomerFullname ";

            DataTable dtReturned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            string strCustomerID;

            string strCustomerIDs = "";
            foreach (DataRow objDr in dtReturned.Rows)
            {
                if (strCustomerIDs != "")
                    strCustomerIDs += ",";
                strCustomerIDs += objDr["CustomerID"].ToString();
            }
            CustomerDb.IDsStr = strCustomerIDs;
            CustomerDb.CacheCustomerContactTable = null;
            CustomerDb.CacheReservationTable = null;
            if (strCustomerIDs != null && strCustomerIDs != "")
            {
                ReservationDb.SetReservationCach();

                ReservationDb.ReservationIDs = "SELECT ReservationID " +
                         " FROM         dbo.CRMReservationCustomer " +
                         " WHERE     (CustomerID IN (" + strCustomerIDs + ")) ";
            }
            return dtReturned;

        }
        public virtual DataTable GetCustomerUsingUserNamePassword()
        {
            string strSql = SearchStr + " where  CustomerName='" + _UserName + "' " +
                "and  CustomerPassword='" + _Password + "' ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Customer");
            return Returned;
        }
        public virtual DataTable GetCustomerUsingUserName()
        {
            string strSql = SearchStr + " where CustomerName='" + _UserName + "' ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "CustomerName");
            return Returned;
        }
        public void EditDebt()
        {
            string strSql = "update CRMCustomer set CustomerDbtAmount=CustomerDebtAmount+" + _AdditionionDebt +
                " where CustomerID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditCustomerAccount()
        {
            string strSql = "update CRMCustomer set CustomerName = '" + _UserName + "'" +
                            " ,CustomerPassword ='" + _Password + "'" +
               " where CustomerID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #region Customer Methods
        public void SetUnitReservation()
        {
            string strSql = "";
            double dblStartDate;
            double dblEndDate;
            double dblArrivalDate;
            string strTempArrival;
            foreach (DataRow objDr in _UnitInstant.Rows)
            {
                dblStartDate = DateTime.Parse(objDr["StartDate"].ToString()).ToOADate() - 2;
                dblEndDate = DateTime.Parse(objDr["EndDate"].ToString()).ToOADate() - 2;
                strTempArrival = objDr["ArrivalDate"].ToString();
                if (strTempArrival != "")
                    dblArrivalDate = DateTime.Parse(strTempArrival).ToOADate() - 2;
                else
                    dblArrivalDate = 0;
                strTempArrival = dblArrivalDate == 0 ? "null" : dblArrivalDate.ToString();
                strSql = "insert into HMSUnitReservation ( UnitID, CustomerID, CustomerParentID, CustomerFamilyID, StartDate, EndDate,ArrivalDate,UsrIns,TimIns) values(" +
                         objDr["UnitID"].ToString() + "," + _ID + "," + _ParentID + "," + _FamilyID + "," + dblStartDate + "," + dblEndDate + "," + strTempArrival + "," + SysData.CurrentUser.ID + ",GetDate())";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            }
        }
        public void SetContact()
        {
            string strSql;
            strSql = "Delete from CRMCustomerContact where CustomerID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            foreach (DataRow objDr in _ContactInstant.Rows)
            {
                strSql = "insert into CRMCustomerContact(CustomerID,ContactID,ContactValue,UsrIns,TimIns)values(" + _ID + "," + objDr["ContactID"] + ",'" + objDr["ContactValue"] + "'," + SysData.CurrentUser.ID + ",GetDate())";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public DataTable GetCustomerContact()
        {
            string strSql = "select CustomerID,ContactValue,ContactTable.* " +
                " from CRMCustomerContact inner join (" + ContactDb.SearchStr + ") " +
                "as ContactTable on ContactTable.ContactID = CRMCustomerContact.ContactID where (1=1) ";
            if (_ID != 0)
                strSql += " and CustomerID=" + _ID;
            else if (_IDStr != null && _IDStr != "")
                strSql += " and CustomerID in(" + _IDStr + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public void SetService()
        {
            string strSql;
            strSql = "Delete from CRMCustomerService where CustomerID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            double dblStartDate;
            double dblEndDate;
            int intIsPermenant;
            int intIsAdmin;
            foreach (DataRow objDr in _ServiceInstant.Rows)
            {
                intIsPermenant = bool.Parse(objDr["IsPermanent"].ToString()) ? 1 : 0;
                intIsAdmin = bool.Parse(objDr["IsAdmin"].ToString()) ? 1 : 0;
                dblStartDate = DateTime.Parse(objDr["StartDate"].ToString()).ToOADate() - 2;
                dblEndDate = DateTime.Parse(objDr["EndDate"].ToString()).ToOADate() - 2;
                strSql = "insert into CRMCustomerService(CustomerID,ServiceID,StartDate,EndDate,IsPermanent,IsAdmin) " +
                    "values(" + _ID + "," + objDr["FunctionID"].ToString() + "," + dblStartDate + "," + dblEndDate + "," + intIsPermenant + "," + intIsAdmin + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public DataTable GetCustomerServices()
        {
            string strSql = "SELECT dbo.CRMService.ServiceID, dbo.CRMService.ServiceName, dbo.CRMService.ServiceDescription, dbo.CRMService.ServiceParentID, " +
                            " dbo.CRMService.ServiceFamilyID, dbo.CRMService.SysID, dbo.CRMCustomerService.CustomerID, dbo.CRMCustomerService.StartDate, " +
                           " dbo.CRMCustomerService.EndDate, dbo.CRMCustomerService.IsPermanent, dbo.CRMCustomerService.IsAdmin " +
                           " FROM         dbo.CRMService INNER JOIN " +
                           " dbo.CRMCustomerService ON dbo.CRMService.ServiceID = dbo.CRMCustomerService.ServiceID" +
                           " where CustomerID= " + _ID + "  and ( (isPermanent =1) or (GetDate() >= startdate or GetDate() <=EndDate))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "CustomerServices");

        }
        #endregion
        #region MyRegion
         public DataTable GetCustomerWithVisit(int intSalesMan)
        {
            string strSql = SearchStr + " Where 1=1";
            strSql += " And (CustomerID in (SELECT Customer FROM CRMCustomerVisit Where 1=1 ";
            if (intSalesMan != 0)
                strSql += " and (VisitSalesMan = "+ intSalesMan +")";
            strSql += "))";
            DataTable dtReturned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return dtReturned;
        }
        public DataTable GetCustomerWithVisit(string strAnyPhoneSearch)
        {
            string strSql = SearchStr + " Where 1=1";

            if (strAnyPhoneSearch != null && strAnyPhoneSearch != "")
            {
                strSql += " And (( CustomerMobile Like '%" + strAnyPhoneSearch + "%' ) OR ( CustomerSecondMobile Like '%" + strAnyPhoneSearch + "%' )" +
                                 " OR ( CustomerHomePhone Like '%" + strAnyPhoneSearch + "%' ) OR ( CustomerWorkPhone Like '%" + strAnyPhoneSearch + "%' ))";
            }            
            DataTable dtReturned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return dtReturned;
        }
        public DataTable GetCustomerWithVisit(int intBranch,int intSalesMan
            , bool blSearch, DateTime dtVisitFrom, DateTime dtVisitTo,string strVisitStatusIDs)
        {
            string strSql = SearchStr + " Where 1=1";
            strSql += " And (CustomerID in (SELECT Customer FROM CRMCustomerVisit Where 1=1 ";
            if (intSalesMan != 0)
                strSql += " and (VisitSalesMan = " + intSalesMan + ")";
            if (intBranch != 0)
                strSql += " and (Branch = " + intBranch + ")";

            if (blSearch)
            {
                double dblDateFrom = new DateTime(dtVisitFrom.Year, dtVisitFrom.Month, dtVisitFrom.Day).ToOADate() - 2;
                double dblDateTo = new DateTime(dtVisitTo.Year, dtVisitTo.Month, dtVisitTo.Day).ToOADate() - 1;
                strSql += " and (VisitDate >= " + dblDateFrom + ") and (VisitDate <=  " + dblDateTo + ")";
            }
            if (strVisitStatusIDs != null && strVisitStatusIDs !="")
            {
                strSql += " And (VisitStatus in ( " + strVisitStatusIDs + "))";
            }
            strSql += "))";
            DataTable dtReturned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return dtReturned;
        }
        #endregion
        #endregion
    }
}
