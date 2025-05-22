using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class  ApplicantDb
    {
        #region Private Data
        protected int _ID;
        protected string _Name;
        protected string _NameComp;
        protected string _FamousName;
        protected string _Desc;
        protected int _SexTypeID;
        protected string _IDValue;
        protected IDTypeInstantDb _IDTypeDb;
        protected int _IDType;
        private DateTime _IDTypeIssueDate;
        private bool _IDTypeIssueDateStatus;
        protected DateTime _BirthDate;
        protected bool _BirthDateStatus;
        protected string _Address;
        protected string _BirthPlace;
        protected int _RegionID;
        protected string _RegionStr;
        protected int _ReligionID;
        protected int _NationalityID;
        protected string _NationalityStr;
        protected int _MiltaryStatusID;
        protected int _MaritalStatusID;
        protected int _CommonService;
        protected DataTable _DegreeTable;
        protected bool _IsOwnCar;
        protected bool _IsHasDrivingLicense;
        protected int _YearExperience;
        protected string _ScientificDegreeStr;
        protected int _StartWorkAfterWeek;
        protected int _JobTimeType;
        protected float _SalaryValue;
        protected int _RankRequested;
        protected int _SalaryCurrency;
        protected string _UserName;
        protected string _Password;

        protected DataTable _CompanyTable;
        protected DataTable _CourseTable;
        protected DataTable _ContactTable;
        protected DataTable _LanguageTable;
        protected DataTable _ScientificDegreeTable;
        protected DataTable _RequestTable;
        protected DataTable _InterestFieldTable;
        protected DataTable _FirstUniversityDegreeTable;
        protected DataTable _HighestUniversityDegreeTable;
        protected DataTable _HighSchoolDegreeTable;
        protected int _ApplicantStatus;
        protected int _ApplicantCV;
        protected bool _EditSucceded;
        protected static string _ApplicantIDs;
        protected static DataTable _CashApplicantTable;
        static DataTable _CashDegreeTable;
        static DataTable _CashCompanyTable;
        static DataTable _CashCourseTable;
        static DataTable _CashContactTable;
        static DataTable _CashLanguageTable;
        static DataTable _CashRequestTable;
        static DataTable _CashScientificDegreeTable;
        static DataTable _CashInterestFieldTable;
        static DataTable _CashFirstUniversityDegreeTable;
        static DataTable _CashHighestUniversityDegreeTable;
        static DataTable _CashHighSchoolDegreeTable;
        
        

        #region Private Data For Search
        protected string _NameLike;
        protected string _UserNameLike;
        protected string _UserPasswordLike;
        protected string _NameCompLike;
        protected string _FamousNameLike;
        protected int _RegionIDSearch;
        protected string _AddressLike;
        protected int _BirthDateStatusSearch;
        protected DateTime _BirthDateFromSearch;
        protected DateTime _BirthDateToSearch;
        protected int _StartDateStatusSearch;
        protected DateTime _StartDateFromSearch;
        protected DateTime _StartDateToSearch;
        protected int _MaritalStatusIDSearch;
        protected int _MiltaryStatusIDSearch;
        protected int _CommonServiceIDSearch;
        protected int _TypeIDSearch;
        protected int _IDValSearch;
        protected int _IDTypeSearch;
        protected int _ScientificDegreeIDSearch;
        protected int _DegreeFieldIDSearch;
        protected int _DegreeSubFieldIDSearch;

        protected int _JobTypeIDSearch;
        protected int _JobTitleTypeIDSearch;
        protected int _JobNatureTypeIDSearch;
        protected int _SJobTypeIDSearch;
        protected int _SJobTitleTypeIDSearch;
        protected int _SJobNatureTypeIDSearch;

        protected int _GraduationYearFromSearch;
        protected int _GraduationYearToSearch;
        
        #endregion

        #endregion

        #region Constructors
        public ApplicantDb()
        {
            _IDTypeDb = new IDTypeInstantDb();
        }
        public ApplicantDb(int intID)
        {
            _ID = intID;
            if (_ID == 0)
                return;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                _CashApplicantTable = dtTemp;
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public ApplicantDb(string strNameComp)
        {
            _NameCompLike = strNameComp;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                _CashApplicantTable = dtTemp;
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public ApplicantDb(DataRow objDR)
        {
            try
            {
                SetData(objDR);
            }
            catch (Exception Ex)
            {

            }
        }
        public ApplicantDb(string strUserName, string strUserPassword)
        {
            _UserNameLike = strUserName;
            _UserPasswordLike = strUserPassword;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                _CashApplicantTable = dtTemp;
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
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
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }

        }
        public string NameComp
        {
            set
            {
                _NameComp = value;
            }
            get
            {
                return _NameComp;
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
        public string FamousName
        {
            set
            {
                _FamousName = value;
            }
            get
            {
                return _FamousName;
            }

        }
        public int SexTypeID
        {
            set { _SexTypeID = value; }
            get { return _SexTypeID; }
        }
        public string IDValue
        {
            set
            {
                _IDValue = value;
            }
            get
            {
                return _IDValue;
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
        public int IDType
        {
            set
            {
                _IDType = value;
            }
            get
            {
                return _IDType;
            }
        }
        public DateTime IDTypeIssueDate
        {
            get { return _IDTypeIssueDate; }
            set { _IDTypeIssueDate = value; }
        }
        public DateTime BirthDate
        {
            set { _BirthDate = value; }
            get { return _BirthDate; }
        }
        public bool BirthDateStatus
        {
            set { _BirthDateStatus = value; }
            get { return _BirthDateStatus; }
        }
        public string Address
        {
            set
            {
                _Address = value;
            }
            get
            {
                return _Address;
            }

        }
        public string BirthPlace
        {
            set
            {
                _BirthPlace = value;
            }
            get
            {
                return _BirthPlace;
            }

        }
        public int RegionID
        {
            set { _RegionID = value; }
            get { return _RegionID; }
        }
        public string RegionStr
        {
            set { _RegionStr = value; }
            get { return _RegionStr; }
        }
        public string NationalityStr
        {
            set { _NationalityStr = value; }
            get { return _NationalityStr; }
        }
        public int ReligionID
        {
            set { _ReligionID = value; }
            get { return _ReligionID; }
        }
        public int NationalityID
        {
            set { _NationalityID = value; }
            get { return _NationalityID; }
        }
        public int MaritalStatusID
        {
            set { _MaritalStatusID = value; }
            get { return _MaritalStatusID; }
        }
        public int CommonService
        {
            set { _CommonService = value; }
            get { return _CommonService; }
        }
        public int MiltaryStatusID
        {
            set { _MiltaryStatusID = value; }
            get { return _MiltaryStatusID; }
        }

        public bool IDTypeIssueDateStatus
        {
            get { return _IDTypeIssueDateStatus; }
            set { _IDTypeIssueDateStatus = value; }
        }
        public bool IsOwnCar
        {
            set { _IsOwnCar = value; }
            get { return _IsOwnCar; }
        }
        public bool IsHasDrivingLicense
        {
            set { _IsHasDrivingLicense = value; }
            get { return _IsHasDrivingLicense; }
        }
        public int YearExperience
        {
            set { _YearExperience = value; }
            get { return _YearExperience; }
        }
        public int StartWorkAfterWeek
        {
            set { _StartWorkAfterWeek = value; }
            get { return _StartWorkAfterWeek; }
        }
        public int JobTimeType
        {
            set { _JobTimeType = value; }
            get { return _JobTimeType; }
        }
        public float SalaryValue
        {
            set { _SalaryValue = value; }
            get { return _SalaryValue; }
        }
        public int RankRequested
        {
            set { _RankRequested = value; }
            get { return _RankRequested; }
        }
        public int SalaryCurrency
        {
            set { _SalaryCurrency = value; }
            get { return _SalaryCurrency; }
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
        public DataTable DegreeTable
        {
            set
            {
                _DegreeTable = value;
            }
        }
        public DataTable CompanyTable
        {
            set
            {
                _CompanyTable = value;
            }
        }
        public DataTable CourseTable
        {
            set
            {
                _CourseTable = value;
            }
        }
        public DataTable ContactTable
        {
            set
            {
                _ContactTable = value;
            }
        }
        public DataTable LanguageTable
        {
            set
            {
                _LanguageTable = value;
            }
        }
        public DataTable ScientificDegreeTable
        {
            set
            {
                _ScientificDegreeTable = value;
            }
        }
        public DataTable RequestTable
        {
            set
            {
                _RequestTable = value;
            }
        }
        public DataTable InterestFieldTable
        {
            set
            {
                _InterestFieldTable = value;
            }
        }
        public DataTable FirstUniversityDegreeTable
        {
            set
            {
                _FirstUniversityDegreeTable = value;
            }
        }
        public DataTable HighestUniversityDegreeTable
        {
            set
            {
                _HighestUniversityDegreeTable = value;
            }
        }
        public DataTable HighSchoolDegreeTable
        {
            set
            {
                _HighSchoolDegreeTable = value;
            }
        }
        public int ApplicantCV
        {
            set
            {
                _ApplicantCV = value;
            }
            get
            {
                return _ApplicantCV;
            }
        }
        public static string ApplicantIDs
        {
            get { return ApplicantDb._ApplicantIDs; }
            set { ApplicantDb._ApplicantIDs = value; }
        }
        public string ScientificDegreeStr
        {
            get
            {
                return _ScientificDegreeStr;
            }
        }
        public bool EditSucceded
        {
            get
            {
                return _EditSucceded;
            }
        }
        public string ScientificDegreeSearchStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        
        #region"Public Properties Search"

        public string NameLike
        {
            set
            {
                _NameLike = value;
            }
        }
        public string NameCompLike
        {
            set
            {
                _NameCompLike = value;
            }
        }
        public string FamousNameLike
        {
            set
            {
                _FamousNameLike = value;
            }
        }
        public string UserNameLike
        {
            set
            {
                _UserNameLike = value;
            }
        }
        public string UserPasswordLike
        {
            set
            {
                _UserPasswordLike = value;
            }
        }
        public int RegionIDSearch
        {
            get { return _RegionIDSearch; }
            set { _RegionIDSearch = value; }
        }
        public string AddressLike
        {
            get { return _AddressLike; }
            set { _AddressLike = value; }
        }
        public int BirthDateStatusSearch
        {
            get { return _BirthDateStatusSearch; }
            set { _BirthDateStatusSearch = value; }
        }
        public DateTime BirthDateFromSearch
        {
            get { return _BirthDateFromSearch; }
            set { _BirthDateFromSearch = value; }
        }
        public DateTime BirthDateToSearch
        {
            get { return _BirthDateToSearch; }
            set { _BirthDateToSearch = value; }
        }
        public int MaritalStatusIDSearch
        {
            get { return _MaritalStatusIDSearch; }
            set { _MaritalStatusIDSearch = value; }
        }
        public int MiltaryStatusIDSearch
        {
            get { return _MiltaryStatusIDSearch; }
            set { _MiltaryStatusIDSearch = value; }
        }
        public int CommonServiceIDSearch
        {
            get { return _CommonServiceIDSearch; }
            set { _CommonServiceIDSearch = value; }
        }
        public int IDValSearch
        {
            set { _IDValSearch = value; }
        }
        public int IDTypeSearch
        {
            set { _IDTypeSearch = value; }
        }
        public int TypeIDSearch
        {
            get { return _TypeIDSearch; }
            set { _TypeIDSearch = value; }
        }
        public int ScientificDegreeIDSearch
        {
            set { _ScientificDegreeIDSearch = value; }
        }
        public int DegreeFieldIDSearch
        {
            set { _DegreeFieldIDSearch = value; }
        }
        public int DegreeSubFieldIDSearch
        {
            set { _DegreeSubFieldIDSearch = value; }
        }
        public int GraduationYearFromSearch
        {

            set { _GraduationYearFromSearch = value; }
        }
        public int GraduationYearToSearch
        {

            set { _GraduationYearToSearch = value; }
        }
        public int ApplicantStatus
        {
            set { _ApplicantStatus = value; }
            get { return _ApplicantStatus; }
        }
        public int JobTypeIDSearch
        {
            set { _JobTypeIDSearch = value; }
        }
        public int JobTitleTypeIDSearch
        {
            set { _JobTitleTypeIDSearch = value; }
        }
        public int JobNatureTypeIDSearch
        {
            set { _JobNatureTypeIDSearch = value; }
        }
        #endregion
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT  HRApplicant.ApplicantID, HRApplicant.ApplicantFirstName,HRApplicant.ApplicantNameComp,HRApplicant.ApplicantDesc,HRApplicant.ApplicantFamousName,HRApplicant.ApplicantSexTypeID," +
                " HRApplicant.ApplicantMidleName, HRApplicant.ApplicantLastName, HRApplicant.ApplicantIDValue as IDValue, HRApplicant.ApplicantIDType,HRApplicant.ApplicantUserName,HRApplicant.ApplicantPassword, " +
                " HRApplicant.ApplicantBirthDate, HRApplicant.ApplicantAddress,HRApplicant.ApplicantBirthPlace,HRApplicant.ApplicantReligionID," +
                " HRApplicant.ApplicantNationalityID,HRApplicant.ApplicantCV,HRApplicant.IsOwnCar,HRApplicant.IsHasDrivingLicense,HRApplicant.YearExperience, " +
                " HRApplicant.StartWorkAfterWeek,HRApplicant.JobTimeType,HRApplicant.SalaryValue,HRApplicant.RankRequested,HRApplicant.SalaryCurrency," +
                " HRApplicant.ApplicantRegionID, HRApplicant.ApplicantMaritalStatus, HRApplicant.ApplicantMiltaryStatus,HRApplicant.ApplicantCommonService,HRApplicant.ApplicantIDIssueDate," +
                " IDTable.*,RegionTable.*,JobTimeTypeTable.*,RankRequestedTable.*,CurrencyTable.* " + //,CountryTable.*
                " FROM    HRApplicant LEFT OUTER JOIN " + 
                " (" + IDTypeDb.SearchStr + ") as IDTable ON HRApplicant.ApplicantIDType = IDTable.IDtypeID  LEFT OUTER JOIN" +
                //" (" + CountryDb.SearchStr + ") as CountryTable ON HRApplicant.ApplicantNationalityID = CountryTable.CountryID LEFT OUTER JOIN " +
                
                " (" + RegionDb.SearchStr + ") as RegionTable ON HRApplicant.ApplicantRegionID = RegionTable.RegionID "+
                " Left Outer Join (" + CurrencyDb.SearchStr + ") as CurrencyTable ON CurrencyTable.CurrencyID = HRApplicant.SalaryCurrency" +
                " Left Outer Join (" + JobTimeTypeDb.SearchStr + ") as JobTimeTypeTable ON JobTimeTypeTable.JobTimeTypeID = HRApplicant.JobTimeType "+
                " Left Outer Join (" + RankRequestedDb.SearchStr + ") as RankRequestedTable ON RankRequestedTable.RankRequestedID = HRApplicant.RankRequested";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string BirthDate = "";
                if (_BirthDateStatus == true)
                {
                    double d = _BirthDate.ToOADate() - 2;
                    BirthDate = d.ToString();
                }
                else
                {
                    BirthDate = "Null";
                }
                string strIDTypeIssueDateS = "";
                if (_IDTypeIssueDateStatus == true)
                {
                    double dblTypeIssueDate = _IDTypeIssueDate.ToOADate() - 2;
                    strIDTypeIssueDateS = dblTypeIssueDate.ToString();
                }
                else
                {
                    strIDTypeIssueDateS = "Null";
                }
                string strRegion = "";
                if (_RegionID != 0)
                    strRegion = _RegionID.ToString();
                else
                    strRegion = "Null";
                string strIDValue = "";
                if (_IDValue == "" || _IDValue == null)
                    strIDValue = "Null";
                else
                    strIDValue = _IDValue;
                string Returned = "";

                int intIsOwnCar = _IsOwnCar ? 1 : 0;
                int intIsHasDrivingLicense = _IsHasDrivingLicense ? 1 : 0;
                if (_UserName == null)
                    _UserName = "";
                Returned = " INSERT INTO HRApplicant " +
                             " (ApplicantFirstName,ApplicantNameComp,ApplicantFamousName,ApplicantDesc ,ApplicantSexTypeID, " +
                             " ApplicantIDValue, ApplicantIDType," +
                             " ApplicantBirthDate,ApplicantAddress,ApplicantBirthPlace,ApplicantRegionID,ApplicantMaritalStatus,ApplicantMiltaryStatus," +
                             " ApplicantCommonService, " +
                             " ApplicantReligionID,ApplicantNationalityID,ApplicantCV,IsOwnCar,IsHasDrivingLicense,YearExperience,"+
                             " StartWorkAfterWeek,JobTimeType,SalaryValue,RankRequested,SalaryCurrency,ApplicantUserName,ApplicantPassword,ApplicantIDIssueDate)" +
                             " VALUES  ('" + _Name + "','" + _NameComp + "','" + _FamousName + "','" + _Desc.Replace("'", "''") + "'," + _SexTypeID + "," +
                             " " + strIDValue + "," + _IDType + "," +
                             " " + BirthDate + ",'" + _Address.Replace("'", "''") + "','" + _BirthPlace + "'," + strRegion + "," + _MaritalStatusID + "," + _MiltaryStatusID + "," + _CommonService + "," +
                             " " + _ReligionID + "," + _NationalityID + "," + _ApplicantCV + "," + intIsOwnCar + "," + intIsHasDrivingLicense + "," + _YearExperience + ","+
                             " " + _StartWorkAfterWeek + "," + _JobTimeType + "," + _SalaryValue + "," + _RankRequested + "," + _SalaryCurrency + " ,'" + _UserName + "','" + _Password + "'," + strIDTypeIssueDateS + ")";
                return Returned;

            }
        }
        public string EditStr
        {
            get
            {
                string BirthDate = "";
                if (_BirthDateStatus == true)
                {
                    double d = _BirthDate.ToOADate() - 2;
                    BirthDate = d.ToString();
                }
                else
                {
                    BirthDate = "Null";
                }
                string strRegion = "";
                if (_RegionID != 0)
                    strRegion = _RegionID.ToString();
                else
                    strRegion = "Null";
                string strIDValue = "";
                if (_IDValue == "" || _IDValue == null)
                    strIDValue = "Null";
                else
                    strIDValue = _IDValue;

                int intIsOwnCar = _IsOwnCar ? 1 : 0;
                int intIsHasDrivingLicense = _IsHasDrivingLicense ? 1 : 0;


                string strIDTypeIssueDateS = "";
                if (_IDTypeIssueDateStatus == true)
                {
                    double dblTypeIssueDate = _IDTypeIssueDate.ToOADate() - 2;
                    strIDTypeIssueDateS = dblTypeIssueDate.ToString();
                }
                else
                {
                    strIDTypeIssueDateS = "Null";
                }

                string Returned = " UPDATE    HRApplicant" +
                             " SET   ApplicantFirstName ='" + _Name + "'" +
                             " , ApplicantNameComp ='" + _NameComp + "'" +
                             " , ApplicantFamousName ='" + _FamousName + "'" +
                             " , ApplicantDesc ='" + _Desc.Replace("'", "''") + "'" +
                             " , ApplicantSexTypeID ='" + _SexTypeID + "'" +
                             " , ApplicantIDValue =" + strIDValue + "" +
                             " , ApplicantIDType =" + _IDType + "" +
                             " , ApplicantBirthDate =" + BirthDate + "" +
                             " , ApplicantAddress ='" + _Address.Replace("'", "''") + "'" +
                             " , ApplicantBirthPlace ='" + _BirthPlace + "'" +
                             " , ApplicantRegionID =" + strRegion + "" +
                             " , ApplicantMaritalStatus =" + _MaritalStatusID + "" +
                             " , ApplicantMiltaryStatus =" + _MiltaryStatusID + "" +
                             " , ApplicantCommonService =" + _CommonService + "" +
                             " , ApplicantReligionID =" + _ReligionID + "" +
                             " , ApplicantNationalityID =" + _NationalityID + "" +
                             " , ApplicantCV =" + _ApplicantCV + "" +
                             " , IsOwnCar =" + intIsOwnCar + "" +
                             " , IsHasDrivingLicense =" + intIsHasDrivingLicense + "" +
                             " , YearExperience =" + _YearExperience + "" +
                             " , StartWorkAfterWeek =" + _StartWorkAfterWeek + "" +
                             " , JobTimeType =" + _JobTimeType + "" +
                             " , SalaryValue =" + _SalaryValue + "" +
                             " , SalaryCurrency =" + _SalaryCurrency + "" +
                             " , RankRequested =" + _RankRequested + "" +
                             " , ApplicantUserName='"+ _UserName +"'"+
                             " , ApplicantPassword='" + _Password +"'" +
                             " , ApplicantIDIssueDate = " + strIDTypeIssueDateS + " " +
                             " Where ApplicantID = " + _ID + "";
                return Returned;
            }
        }
        public virtual string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRApplicant SET  Dis = GetDate() WHERE     (ApplicantID = " + _ID + ") ";
                return Returned;
            }
        }
        #endregion

        #region Public Cash Properties
        public static DataTable CashCompanyTable
        {
            set
            {
                _CashCompanyTable = value;
            }
            get
            {
                if (_CashCompanyTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantCompanyDb objDb = new ApplicantCompanyDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashCompanyTable = objDb.Search();
                }
                return _CashCompanyTable;
            }
        }
        public static DataTable CashDegreeTable
        {
            set
            {
                _CashDegreeTable = value;
            }
            get
            {
                if (_CashDegreeTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantDegreeDb objDb = new ApplicantDegreeDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashDegreeTable = objDb.Search();
                }
                return _CashDegreeTable;
            }
        }
        public static DataTable CashCourseTable
        {
            set
            {
                _CashCourseTable = value;
            }
            get
            {
                if (_CashCourseTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantCourseDb objDb = new ApplicantCourseDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashCourseTable = objDb.Search();
                }
                return _CashCourseTable;
            }
        }
        public static DataTable CashContactTable
        {
            set
            {
                _CashContactTable = value;
            }
            get
            {
                if (_CashContactTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantContactDb objDb = new ApplicantContactDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashContactTable = objDb.Search();
                }
                return _CashContactTable;
            }
        }
        public static DataTable CashLanguageTable
        {
            set
            {
                _CashLanguageTable = value;
            }
            get
            {
                if (_CashLanguageTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantLanguageDb objDb = new ApplicantLanguageDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashLanguageTable = objDb.Search();
                }
                return _CashLanguageTable;
            }
        }
        public static DataTable CashRequestTable
        {
            set
            {
                _CashRequestTable = value;
            }
            get
            {
                if (_CashRequestTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantRequestDb objDb = new ApplicantRequestDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashRequestTable = objDb.Search();
                }
                return _CashRequestTable;
            }
        }
        public static DataTable CashScientificDegreeTable
        {
            set
            {
                _CashScientificDegreeTable = value;
            }
            get
            {
                if (_CashScientificDegreeTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantScientificDegreeDb objDb = new ApplicantScientificDegreeDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashScientificDegreeTable = objDb.Search();
                }
                return _CashScientificDegreeTable;
            }
        }
        public static DataTable CashInterestFieldTable
        {
            set
            {
                _CashInterestFieldTable = value;
            }
            get
            {
                if (_CashInterestFieldTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantInterestFieldDb objDb = new ApplicantInterestFieldDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashInterestFieldTable = objDb.Search();
                }
                return _CashInterestFieldTable;
            }
        }
        public static DataTable CashFirstUniversityDegreeTable
        {
            set
            {
                _CashFirstUniversityDegreeTable = value;
            }
            get
            {
                if (_CashFirstUniversityDegreeTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantFirstUniversityDegreeDb objDb = new ApplicantFirstUniversityDegreeDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashFirstUniversityDegreeTable = objDb.Search();
                }
                return _CashFirstUniversityDegreeTable;
            }
        }
        public static DataTable CashHighSchoolDegreeTable
        {
            set
            {
                _CashHighSchoolDegreeTable = value;
            }
            get
            {
                if (_CashHighSchoolDegreeTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantHighSchoolDegreeDb objDb = new ApplicantHighSchoolDegreeDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashHighSchoolDegreeTable = objDb.Search();
                }
                return _CashHighSchoolDegreeTable;
            }
        }
        public static DataTable CashHighestUniversityDegreeTable
        {
            set
            {
                _CashHighestUniversityDegreeTable = value;
            }
            get
            {
                if (_CashHighestUniversityDegreeTable == null && _ApplicantIDs != null && _ApplicantIDs != "")
                {
                    ApplicantHighestUniversityDegreeDb objDb = new ApplicantHighestUniversityDegreeDb();
                    objDb.ApplicantIDs = _ApplicantIDs;
                    _CashHighestUniversityDegreeTable = objDb.Search();
                }
                return _CashHighestUniversityDegreeTable;
            }
        }
        public static DataTable CashApplicantTable
        {
            set
            {
                _CashApplicantTable = value;
            }
            get
            {                
                return _CashApplicantTable;
            }
        }
        #endregion

        #region private Methods        
        void JoinDegree()
        {
            string[] arrStr = new string[_DegreeTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantDegree where ApplicantID = " + _ID;

            if (_DegreeTable == null || _DegreeTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantDegreeDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _DegreeTable.Rows)
                {
                    objDb = new ApplicantDegreeDb(objDr, true);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinCompany()
        {
            string[] arrStr = new string[_CompanyTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantCompany where ApplicantID = " + _ID;

            if (_CompanyTable == null || _CompanyTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantCompanyDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _CompanyTable.Rows)
                {
                    objDb = new ApplicantCompanyDb(objDr, true);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinCourse()
        {
            string[] arrStr = new string[_CourseTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantCourse where ApplicantID = " + _ID;

            if (_CourseTable == null || _CourseTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantCourseDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _CourseTable.Rows)
                {
                    objDb = new ApplicantCourseDb(objDr, true);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinLanguage()
        {
            string[] arrStr = new string[_LanguageTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantLanguage where ApplicantID = " + _ID;


            if (_LanguageTable == null || _LanguageTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {

                ApplicantLanguageDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _LanguageTable.Rows)
                {
                    objDb = new ApplicantLanguageDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinContact()
        {
            string[] arrStr = new string[_ContactTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantContact where ApplicantID = " + _ID;

            if (_ContactTable == null || _ContactTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantContactDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _ContactTable.Rows)
                {
                    objDb = new ApplicantContactDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinScientificDegree()
        {
            string[] arrStr = new string[_ScientificDegreeTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantScientificDegree where ApplicantID = " + _ID;

            if (_ScientificDegreeTable == null || _ScientificDegreeTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                ApplicantScientificDegreeDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _ScientificDegreeTable.Rows)
                {
                    objDb = new ApplicantScientificDegreeDb(objDr, true);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinRequest()
        {
            string[] arrStr = new string[_RequestTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantRequest where Applicant = " + _ID;


            if (_RequestTable == null || _RequestTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {

                ApplicantRequestDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _RequestTable.Rows)
                {
                    objDb = new ApplicantRequestDb(objDr);
                    //if (objDb.StatusDelete == true)
                    //{
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                    //}


                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinInterestField()
        {
            string[] arrStr = new string[_InterestFieldTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantField where ApplicantID = " + _ID;

            if (_InterestFieldTable == null || _InterestFieldTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantInterestFieldDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _InterestFieldTable.Rows)
                {
                    objDb = new ApplicantInterestFieldDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinFirstUniversityDegree()
        {
            string[] arrStr = new string[_FirstUniversityDegreeTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantFirstUniversityDegree where ApplicantID = " + _ID;

            if (_FirstUniversityDegreeTable == null || _FirstUniversityDegreeTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantFirstUniversityDegreeDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _FirstUniversityDegreeTable.Rows)
                {
                    objDb = new ApplicantFirstUniversityDegreeDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinHighestUniversityDegree()
        {
            string[] arrStr = new string[_HighestUniversityDegreeTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantHighestUniversityDegree where ApplicantID = " + _ID;

            if (_HighestUniversityDegreeTable == null || _HighestUniversityDegreeTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantHighestUniversityDegreeDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _HighestUniversityDegreeTable.Rows)
                {
                    objDb = new ApplicantHighestUniversityDegreeDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinHighSchoolDegree()
        {
            string[] arrStr = new string[_HighSchoolDegreeTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantHighSchoolDegree where ApplicantID = " + _ID;

            if (_HighSchoolDegreeTable == null || _HighSchoolDegreeTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {
                ApplicantHighSchoolDegreeDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _HighSchoolDegreeTable.Rows)
                {
                    objDb = new ApplicantHighSchoolDegreeDb(objDr);
                    objDb.ApplicantID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void SetCashTable()
        {
            CashCompanyTable = null;
            CashDegreeTable = null;
            CashCourseTable = null;
            CashContactTable = null;
            CashLanguageTable = null;
            CashRequestTable = null;
            CashScientificDegreeTable = null;
            CashInterestFieldTable = null;
            CashFirstUniversityDegreeTable = null;
            CashHighSchoolDegreeTable = null;
            CashHighestUniversityDegreeTable = null;
        }
        #endregion
        #region Public Methods
        public void SetData(DataRow objDR)
        {
            if (objDR["ApplicantID"].ToString() == "" || objDR["ApplicantID"].ToString() == "0")
                return;
            if (objDR.Table.Columns["ShortApplicant"] != null)
                return;

            _ID = int.Parse(objDR["ApplicantID"].ToString());
            _Name = objDR["ApplicantFirstName"].ToString();
            _NameComp = objDR["ApplicantNameComp"].ToString();
            _FamousName = objDR["ApplicantFamousName"].ToString();
            _UserName = objDR["ApplicantUserName"].ToString();
            _Password = objDR["ApplicantPassword"].ToString();
            _Desc = objDR["ApplicantDesc"].ToString();
            _IDValue = objDR["IDValue"].ToString();
            _SexTypeID = int.Parse(objDR["ApplicantSexTypeID"].ToString());
            _ReligionID = int.Parse(objDR["ApplicantReligionID"].ToString());
            _NationalityID = int.Parse(objDR["ApplicantNationalityID"].ToString());
            _NationalityStr = objDR["CountryNationalityA"].ToString();
            _RegionStr = objDR["RegionNameA"].ToString();
            if (objDR["ApplicantIDType"].ToString() != "")
                _IDType = int.Parse(objDR["ApplicantIDType"].ToString());
            else
                _IDType = 0;
            _Address = objDR["ApplicantAddress"].ToString();
            _BirthPlace = objDR["ApplicantBirthPlace"].ToString();
            if (objDR["ApplicantRegionID"].ToString() != "")
                _RegionID = int.Parse(objDR["ApplicantRegionID"].ToString());
            else
                _RegionID = 0;
            if (objDR["ApplicantBirthDate"].ToString() != "")
            {
                _BirthDateStatus = true;
                _BirthDate = DateTime.Parse(objDR["ApplicantBirthDate"].ToString());
            }
            else
            {
                _BirthDateStatus = false;
            }
            if (objDR["ApplicantIDIssueDate"].ToString() != "")
            {
                _IDTypeIssueDateStatus = true;
                _IDTypeIssueDate = DateTime.Parse(objDR["ApplicantIDIssueDate"].ToString());
            }
            else
            {
                _IDTypeIssueDateStatus = false;
            }
            _MaritalStatusID = int.Parse(objDR["ApplicantMaritalStatus"].ToString());
            _CommonService = int.Parse(objDR["ApplicantCommonService"].ToString());
            _MiltaryStatusID = int.Parse(objDR["ApplicantMiltaryStatus"].ToString());
            if (_IDType != 0)
                _IDTypeDb = new IDTypeInstantDb(objDR);
            else
                _IDTypeDb = new IDTypeInstantDb();

            if (objDR["ApplicantCV"].ToString() != "")
                _ApplicantCV = int.Parse(objDR["ApplicantCV"].ToString());
            else
                _ApplicantCV = 0;

            _IsOwnCar = bool.Parse(objDR["IsOwnCar"].ToString());
            _IsHasDrivingLicense = bool.Parse(objDR["IsHasDrivingLicense"].ToString());
            if (objDR["YearExperience"].ToString() != "")
                _YearExperience = int.Parse(objDR["YearExperience"].ToString());
            if (objDR["StartWorkAfterWeek"].ToString() != "")
                _StartWorkAfterWeek = int.Parse(objDR["StartWorkAfterWeek"].ToString());
            if (objDR["JobTimeType"].ToString() != "")
                _JobTimeType = int.Parse(objDR["JobTimeType"].ToString());
            if (objDR["SalaryValue"].ToString() != "")
                _SalaryValue = int.Parse(objDR["SalaryValue"].ToString());
            if (objDR["RankRequested"].ToString() != "")
                _RankRequested = int.Parse(objDR["RankRequested"].ToString());
            if (objDR["SalaryCurrency"].ToString() != "")
                _SalaryCurrency = int.Parse(objDR["SalaryCurrency"].ToString());
        }
        public virtual void Add()
        {
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            //JoinDegree();
            JoinData();
           // JoinRequest();
            
        }
        protected void JoinData()
        {
            JoinScientificDegree();
            JoinContact();
            JoinCompany();
            JoinCourse();
            JoinLanguage();
            JoinInterestField();
            JoinFirstUniversityDegree();
            JoinHighestUniversityDegree();
            JoinHighSchoolDegree();
        }
        public virtual void Edit()
        {
            _EditSucceded = false;
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            //JoinDegree();
            JoinScientificDegree();
            JoinContact();
            JoinCompany();
            JoinCourse();
            JoinLanguage();
            JoinInterestField();
            JoinFirstUniversityDegree();
            JoinHighestUniversityDegree();
            JoinHighSchoolDegree();
            //JoinRequest();
            _EditSucceded = true;
        }
        public virtual void Delete()
        {
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public virtual DataTable Search()
        {
            SetCashTable();
            string strSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
                strSql = strSql + " And (ApplicantID = " + _ID + ")";
            if (_NameLike != null && _NameLike != "")
                strSql = strSql + " And ApplicantFirstName Like '%" + _NameLike + "%'";
            if (_UserNameLike != null && _UserNameLike != "")
                strSql = strSql + " And ApplicantUserName ='" + _UserNameLike + "'";
            if (_UserPasswordLike != null && _UserPasswordLike != "")
                strSql = strSql + " And ApplicantPassword ='" + _UserPasswordLike + "'";
            if (_NameCompLike != null && _NameCompLike != "")
                strSql = strSql + " And ApplicantNameComp Like '%" + _NameCompLike + "%'";
            if (_FamousNameLike != null && _FamousNameLike != "")
                strSql = strSql + " And ApplicantFamousName Like '%" + _FamousNameLike + "%'";
            if (_RegionIDSearch != 0)
                strSql = strSql + " And ApplicantRegionID = " + _RegionIDSearch + "";
            if (_AddressLike != null && _AddressLike != "")
                strSql = strSql + " And ApplicantAddress = '%" + _AddressLike + "%'";
            if (_BirthDateStatusSearch != 0)
            {
                if (_BirthDateStatusSearch == 1)
                {
                    int intFrom;
                    DateTime dtFrom = new DateTime(_BirthDateFromSearch.Year, _BirthDateFromSearch.Month, _BirthDateFromSearch.Day);
                    DateTime dtTo = new DateTime(_BirthDateToSearch.Year, _BirthDateToSearch.Month, _BirthDateToSearch.Day);
                    //dtTo = dtTo.AddDays(1);
                    double d = dtFrom.ToOADate() - 2;
                    //intFrom = (int)d;

                    int intTo;
                    double dd = dtTo.ToOADate() - 2;
                    //intTo = (int)dd  +1;

                    strSql = strSql + " And ApplicantBirthDate Between " + d + " and " + dd + "";
                }
                else if (_BirthDateStatusSearch == 2)
                {
                    strSql = strSql + " And  (ApplicantBirthDate IS NULL) OR " +
                                      " (ApplicantBirthDate = '') OR " +
                                      " (YEAR(ApplicantBirthDate) = '1900')";
                }


            }
            if (_MaritalStatusIDSearch != 0)
                strSql = strSql + " And ApplicantMaritalStatus = " + _MaritalStatusIDSearch + "";
            if (_MiltaryStatusIDSearch != 0)
                strSql = strSql + " And ApplicantMiltaryStatus = " + _MiltaryStatusIDSearch + "";
            if (_CommonServiceIDSearch != 0)
                strSql = strSql + " And ApplicantCommonService = " + _CommonServiceIDSearch + "";
            if (_TypeIDSearch != 0)
                strSql = strSql + " And ApplicantSexTypeID = " + _TypeIDSearch + "";
            if (_IDTypeSearch != 0)
                strSql = strSql + " And ApplicantIDType = " + _IDTypeSearch + "";
            if (_IDValSearch != 0)
                strSql = strSql + " And ApplicantIDValue = '" + _IDValSearch + "'";


            if (_ScientificDegreeIDSearch != 0 || _DegreeFieldIDSearch != 0 || _DegreeSubFieldIDSearch  !=0 || _GraduationYearFromSearch != 0 || _GraduationYearToSearch != 0)
            {
                string strEduactionQualified = "";
                string strGraduationYearFrom = "";
                string strGraduationYearTo = "";

                string strDegreeField = "";
                string strDegreeSubField = "";

                if (_ScientificDegreeIDSearch != 0)
                    strEduactionQualified = " And HRApplicantScientificDegree.ScientificDegreeID = " + _ScientificDegreeIDSearch + "";

                if (_DegreeFieldIDSearch != 0)
                    strDegreeField = " And HRApplicantScientificDegree.DegreeFieldID = " + _DegreeFieldIDSearch + "";
                if (_DegreeSubFieldIDSearch != 0)
                    strDegreeSubField = " And HRApplicantScientificDegree.DegreeSubFieldID = " + _DegreeSubFieldIDSearch + "";

                if (_GraduationYearFromSearch != 0)
                    strGraduationYearFrom = " And HRApplicantScientificDegree.GraduationYear >= " + _GraduationYearFromSearch + "";
                if (_GraduationYearToSearch != 0)
                    strGraduationYearTo = " And HRApplicantScientificDegree.GraduationYear <= " + _GraduationYearToSearch + "";

                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubTable.ApplicantID from (" + ApplicantScientificDegreeDb.SearchStr + " Where 1=1 " + strEduactionQualified + " " + strGraduationYearFrom + " " + strGraduationYearTo + " " + strDegreeField + " " + strDegreeSubField + ") SubTable)";
            }

            if (_JobTypeIDSearch != 0 || _JobTitleTypeIDSearch != 0 || _JobNatureTypeIDSearch!=0)
            {
                string strJobTypeID = "";
                string strJobTitleTypeID = "";
                string strJobNatureTypeID = "";

                if (_JobTypeIDSearch != 0)
                    strJobTypeID = " And HRApplicantCompany.JobTypeID = " + _JobTypeIDSearch + "";
                if (_JobTitleTypeIDSearch != 0)
                    strJobTitleTypeID = " And  HRApplicantCompany.JobTitleTypeID = " + _JobTitleTypeIDSearch + "";
                if (_JobNatureTypeIDSearch != 0)
                    strJobNatureTypeID = " And HRApplicantCompany.JobNatureTypeID = " + _JobNatureTypeIDSearch + "";

                strSql = strSql + " And HRApplicant.ApplicantID  in (Select SubCompanyTable.ApplicantID from (" + ApplicantCompanyDb.SearchStr + " Where 1=1 " + strJobTypeID + " " + strJobTitleTypeID + " " + strJobNatureTypeID + " ) SubCompanyTable)";
            }


            if (_ApplicantStatus != 0)
            {
                strSql = strSql + " And (HRApplicant.ApplicantID  not in (Select ApplicantID From HRApplicantWorker))";
            }
            _CashApplicantTable = SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"HRApplicant");

            _ApplicantIDs = "";
            foreach (DataRow objDr in _CashApplicantTable.Rows)
            {
                if (_ApplicantIDs != "")
                    _ApplicantIDs = _ApplicantIDs + ",";
                _ApplicantIDs = _ApplicantIDs + objDr["ApplicantID"].ToString();
            }

            return _CashApplicantTable;

        }
        public void EditUserNameAndPassword()
        {
            string strSql = "Update HRApplicant Set ApplicantUserName = '" + _UserName + "' , ApplicantPassword = '" + _Password + "' Where ApplicantID = "+ _ID +"";
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditApplicantCVValue()
        {
            string strSql = "Update HRApplicant Set ApplicantCV = " + _ApplicantCV + " Where ApplicantID = " + _ID + "";
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public DataTable GetApplicant()
        {
            string strSql = "SELECT     ApplicantID FROM         HRApplicant  Where 1=1 ";
            if (_ID != 0)
                strSql += " And ApplicantID <> " + _ID + "";
            if (_Name != "")
                strSql += " And (ApplicantNameComp = '" + SharpVision.SystemBase.SysUtility.ReplaceStringComp(_Name) + "')";
            //if (_ApplicantCode != "")
            //    strSql += " And ApplicantCode = '" + _ApplicantCode + "'";
            return SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
