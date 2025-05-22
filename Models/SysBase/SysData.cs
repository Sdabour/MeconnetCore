using System;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace SharpVision.SystemBase
{
    public struct CodeLevelFeature
    {
        int _Level;
        int _LevelLength;
        public int Level
        {
            set
            {
                _Level = value;
            }
            get
            {
                
                return _Level;
            }
        }
        public int LevelLength
        {
            set
            {
                _LevelLength = value;
            }
            get
            {
                return _LevelLength;
            }
        }

    }
  
    public static class SysData
    {

        
        private static UserBiz _CurrentUser;
        //private static WebUserBiz _CurrentWebUser;
        private static int _WebCustomerID;
        private static int _SysID;
        private static string _SysName;
        private static string _ServiceUrl;
        private static int _VersionNo =1;
        private static string _UMSConnectionStr;
        private static string _AttachmentDbUserID;
        private static string _AttachmentDbPassword;
        private static string _AttachmentDbSrverName;
        private static string _SharpVisonDbUserID;
        private static string _SharpVisionDbPassword;
        private static string _SharpVisionDbServerName;
        private static BaseDb _SharpVisionBaseDb;

        private static string _OfflineDbUserID;
        private static string _OfflineDbPassword;
        private static string _OfflineDbServerName;
        private static BaseDb _OfflineBaseDb;


        private static string _FilePath;
        private static int _Language;
        
        private static BaseDb _AttachmentDb;
        private static BaseOLEDb _BaseOLEDb;
        private static bool _IsOnline;
        private static int _CofferAccountID;
        private static string _MsgUrl;
        private static string _SerialPort;

        public static string SerialPort
        {
            get { return SysData._SerialPort; }
            set { SysData._SerialPort = value; }
        }
        private static string _IP;
        public static UserBiz CurrentUser
        {
            set
            {
                //UserBiz.CurrentUser = value.UserSimple;
                _CurrentUser = value;
            }
            get
            {
                UserSmple objSImpleUser = UserSmple.CurrentUser;
                UserBiz objUserBiz = new UserBiz() { ID = objSImpleUser.ID, Name = objSImpleUser.Name, FullName = objSImpleUser.FullName, EmployeeBiz = new EmployeeBiz() { ID = objSImpleUser.EmployeeID, Code = objSImpleUser.EmployeeCode, Name = objSImpleUser.EmployeeName } };
                _CurrentUser = objUserBiz;
                if (_CurrentUser == null)
                    _CurrentUser = new UserBiz();
                return _CurrentUser;
            }

        }
        static UMSBranchBiz _CurrentBranch;
        public static UMSBranchBiz CurrentBranch
        {
            set
            {
                
                _CurrentBranch = value;
            }
            get
            {
                UMSBranchBiz objBranchBiz = new UMSBranchBiz();
                if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session != null && AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("Branch") != null)
                {
                  //  objBranchBiz = (UMSBranchBiz)AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("Branch");
                }
                if(objBranchBiz!= null && objBranchBiz.ID!=0)
                _CurrentBranch = objBranchBiz;
                if (_CurrentBranch == null)
                    _CurrentBranch = new UMSBranchBiz();
                return _CurrentBranch;
            }

        }
        public static int VersionNo
        {
            set
            {
                _VersionNo = value;
            }
            get
            {
                return _VersionNo;
            }
        }
        public static int SysID
        {
            set
            {
                _SysID = value;
            }
            get
            {
                if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session != null && AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("SysID") != null)
                {
                    int.TryParse(AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("SysID"), out _SysID);


                }
                else 
                {
                    string strTemp = AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("SysID");
                    if (strTemp == null)
                        strTemp = "";
                    int.TryParse(strTemp, out _SysID);
                    if(AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session != null)
                        AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.SetString("SysID", _SysID.ToString());
                }
                return _SysID;
            }
        }
        static string _ApplicantImageSupperCode = "ApplicantImageCode";
        static string _ApplicantImageMainPath;
        public static string AplicantImageMainPath
        {
            set => _ApplicantImageMainPath = value;
            get
            {
                if (_ApplicantImageMainPath == null || _ApplicantImageMainPath == "")
                {

                    object objTemp = SysData.SharpVisionBaseDb.ReturnScalar("select top 1 SupperCodeValue from COMMONSupperCode where SupperCode = '" + _ApplicantImageSupperCode + "' ");
                    if (objTemp != null)
                    {
                        _ApplicantImageMainPath = objTemp.ToString();
                    }
                }
                return _ApplicantImageMainPath;
            }
        }
        static string _ApplicantImageURLSupperCode = "ApplicantImageURL";
        static string _ApplicantImageMainURL;
        public static string AplicantImageMainURL
        {
            set => _ApplicantImageMainURL= value;
            get
            {
                if (_ApplicantImageMainURL == null || _ApplicantImageMainURL == "")
                {

                    object objTemp = SysData.SharpVisionBaseDb.ReturnScalar("select top 1 SupperCodeValue from COMMONSupperCode where SupperCode = '" + _ApplicantImageURLSupperCode + "' ");
                    if (objTemp != null)
                    {
                        _ApplicantImageMainURL = objTemp.ToString();
                    }
                }
                return _ApplicantImageMainURL;
            }
        }
        public static string SysName
        {
            set
            {
                _SysName = value;
            }
            get
            {
                if (_SysName == null)
                    _SysName = "";
                return _SysName;
            }
        }
        public static string ServiceUrl
        {
            set
            {
                _ServiceUrl = value;
            }
            get
            {
                return _ServiceUrl;
            }
        }
        public static string AttachmentDbUserID
        {
            set
            {
                _AttachmentDbUserID = value;
            }
            get
            {
                return _AttachmentDbUserID;
            }
        }
        public static string AttachmentDbPassword
        {
            set
            {
                _AttachmentDbPassword = value;
            }
            get
            {
                return _AttachmentDbPassword;
               
            }
        }
        public static string AttachmentDbSrverName
        {
            set
            {
                _AttachmentDbSrverName = value;
            }
            get
            {
                return _AttachmentDbSrverName;
            }
        }
        public static string SharpVisonDbUserID
        {
            set
            {
                _SharpVisonDbUserID = value;
            }
            get
            {
                return _SharpVisonDbUserID;
            }
        }
        public static string FilePath
        {
            set
            {
                _FilePath = value;
            }
            get
            {
                return _FilePath;
            }
        }
        static string _FTPURL;

        public static string FTPURL
        {
            get { return SysData._FTPURL; }
            set { SysData._FTPURL = value; }
        }
        static string _FTPUserName;

        public static string FTPUserName
        {
            get { return SysData._FTPUserName; }
            set { SysData._FTPUserName = value; }
        }
        static string _FTPPassWord;

        public static string FTPPassWord
        {
            get { return SysData._FTPPassWord; }
            set { SysData._FTPPassWord = value; }
        }
        static string _ImagePath;

        public static string ImagePath
        {
            get { return SysData._ImagePath; }
            set { SysData._ImagePath = value; }
        }
        static string _PageURL;

        public static string PageURL
        {
            get { return SysData._PageURL; }
            set { SysData._PageURL = value; }
        }
        static string _ImageURL;

        public static string ImageURL
        {
            get { return SysData._ImageURL; }
            set { SysData._ImageURL = value; }
        }
        static string _MainURL;

        public static string MainURL
        {
            get { return SysData._MainURL; }
            set { SysData._MainURL = value; }
        }
        static string _WebImagePath;

        public static string WebImagePath
        {
            get {
                if (_WebImagePath == null || _WebImagePath == "")
                    return "images";
                return SysData._WebImagePath; }
            set { SysData._WebImagePath = value; }
        }
        static string _WebFilePath;

        public static string WebFilePath
        {
            get
            {
                if (_WebFilePath == null || _WebFilePath == "")
                    return "images";
                return SysData._WebFilePath;
            }
            set { SysData._WebFilePath = value; }
        }
        public static string SharpVisionDbPassword
        {
            set
            {
                _SharpVisionDbPassword = value;
            }
            get
            {
                return _SharpVisionDbPassword;
            }
        }
        public static string SharpVisionDbServerName
        {
            set
            {
                _SharpVisionDbServerName = value;
            }
            get
            {
                return _SharpVisionDbServerName;
            }
        }
        public static string UMSConnectionStr
        {
            set
            {
                _UMSConnectionStr = value;
                SetUMSDb(_UMSConnectionStr,SysData.Language);
            }
            get
            { 
                return _UMSConnectionStr;
            }
        }        
        public static BaseDb SharpVisionBaseDb
        {
            set
            {
                _SharpVisionBaseDb = value;
            }
            get
            
            {
                if(_SharpVisionBaseDb== null)
                {
                    var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

                    IConfigurationRoot Configuration = builder.Build();
                    var connectionString = Configuration["ConnectionStrings:SVDBCon"];
                    string strTemp = connectionString.ToString();
                    //string strTemp = System.Configuration.ConfigurationManager.AppSettings["SVDBCon"];
                    _SharpVisionBaseDb = new BaseDb(strTemp);
                }
                return _SharpVisionBaseDb;
            }
        }
        static BaseDb _DestDb;

        public static BaseDb DestDb
        {
            get { return SysData._DestDb; }
            set { SysData._DestDb = value; }
        }
        static bool _HasDest;

        public static bool HasDest
        {
            get { return _HasDest; }
            set { _HasDest = value; }
        }
        public static BaseDb AttachmentDb
        {
            set
            {
                _AttachmentDb = value;
            }
            get
            {
                return _AttachmentDb;
            }
        }
        public static string OfflineDbUserID
        {
            set
            {
                _OfflineDbUserID = value;
            }
            get
            {
                return _OfflineDbUserID;
            }
        }
        public static string OfflineDbPassword
        {
            set
            {
                _OfflineDbPassword = value;
            }
            get
            {
                return _OfflineDbPassword;
            }
        }

        public static string OfflineDbServerName
        {
            set
            {
                _OfflineDbServerName = value;
            }
            get
            {
                return _OfflineDbServerName;
            }
        }
        public static BaseDb OfflineBaseDb
        {
            set
            {
                _OfflineBaseDb = value;
            }
            get
            {
                return _OfflineBaseDb;
            }
        }
        public static BaseOLEDb BaseOLEDb
        {
            set
            {
                _BaseOLEDb = value;
            }
            get
            {
                return _BaseOLEDb;
            }
        }
        public static int Language
        {
            set
            {
                _Language = value;
                BaseSingleDb.Language = value;
            }
            get
            {
                return _Language;
            }
        }
        public static bool IsOnline
        {
            set
            {
                _IsOnline = value;
            }
            get
            {
                return _IsOnline;
            }
        }
        public static int CofferAccountID
        {
            set
            {
                _CofferAccountID = value;
            }
            get
            {
                return _CofferAccountID;
            }
        }
        public static string MsgUrl
        {
            set
            {
                _MsgUrl = value;
            }
            get
            {
                return _MsgUrl;
            }
        }
        public static string HostName
        {
            get
            {
                string Returned = Dns.GetHostName();
                return Returned;
            }
        }
        public static string IP
        {
            get
            {
                if (_IP == null || _IP == "")
                {
                    _IP = Dns.GetHostByName(HostName).AddressList[0].ToString();
                }
                return _IP;
            }
        }
        public static List<CodeLevelFeature> CodeLevelArr
        {
            get
            {
                List<CodeLevelFeature> Returned = new List<CodeLevelFeature>();
                CodeLevelFeature objTemp = new CodeLevelFeature();
                objTemp.Level = 1;
                objTemp.LevelLength = 1;
                Returned.Add(objTemp);
                objTemp = new CodeLevelFeature();
                objTemp.Level = 2;
                objTemp.LevelLength = 2;
                Returned.Add(objTemp);
                objTemp = new CodeLevelFeature();
                objTemp.Level = 3;
                objTemp.LevelLength = 2;
                Returned.Add(objTemp);
                objTemp = new CodeLevelFeature();
                objTemp.Level = 4;
                objTemp.LevelLength = 4;
                Returned.Add(objTemp);
                return Returned;
                
            }
        }
        
        public static int AccountCodeLength
        {
            get
            {
                int Returned = 9;
               
                return Returned;
            }
        }
        public static string GetAccountLevelCod1(int intLevel, string strCode)
        {

            string Returned = "";
            if (strCode == null)
                strCode = "";
            if (strCode.Length < AccountCodeLength)
                return "";
            int intMainLevel = intLevel;
            List<CodeLevelFeature> objCol = CodeLevelArr;
           intLevel = objCol.Count - intLevel  ; //the code starts from the right not the left
            CodeLevelFeature objBiz = new CodeLevelFeature();
            int intStartIndex = 0;
            for (int intIndex = objCol.Count-1; intIndex >= intMainLevel; intIndex--)
            {
                objBiz = objCol[intIndex];
                intStartIndex += objBiz.LevelLength;
            }
            Returned = strCode.Substring(intStartIndex, GetAccountLevel(intMainLevel).LevelLength);
            return Returned;
        }
        public static string GetAccountLevelCod(int intLevel, string strCode)
        {

            string Returned = "";
            if (strCode == null)
                strCode = "";
            if (strCode.Length < AccountCodeLength)
                return "";
            int intMainLevel = intLevel;
            List<CodeLevelFeature> objCol = CodeLevelArr;
           // intLevel = objCol.Count - intLevel; //the code starts from the right not the left
            CodeLevelFeature objBiz = new CodeLevelFeature();
            int intStartIndex = 0;
            for (int intIndex = 0; intIndex < intLevel-1; intIndex++)
            {
                objBiz = objCol[intIndex];
                intStartIndex += objBiz.LevelLength;
            }
            Returned = strCode.Substring(intStartIndex, GetAccountLevel(intLevel).LevelLength);
            return Returned;
        }
        public static CodeLevelFeature GetAccountLevel(int intLevel)
        {
            CodeLevelFeature Returned = new CodeLevelFeature();
            if (intLevel > CodeLevelArr.Count + 1)
                intLevel = CodeLevelArr.Count;
            Returned = CodeLevelArr[intLevel - 1];

            return Returned;
        }
        public static List<CodeLevelFeature> CostCenterCodeLevelArr
        {
            get
            {
                List<CodeLevelFeature> Returned = new List<CodeLevelFeature>();
                CodeLevelFeature objTemp = new CodeLevelFeature();
                objTemp.Level = 1;
                objTemp.LevelLength = 2;
                Returned.Add(objTemp);
                objTemp = new CodeLevelFeature();
                objTemp.Level = 2;
                objTemp.LevelLength = 2;
                Returned.Add(objTemp);
                objTemp = new CodeLevelFeature();
                objTemp.Level = 3;
                objTemp.LevelLength = 5;
                Returned.Add(objTemp);

                return Returned;

            }
        }
        public static int CostCenterCodeLength
        {
            get
            {
                int Returned = 9;

                return Returned;
            }
        }
        public static string GetCostCenterLevelCod1(int intLevel, string strCode)
        {

            string Returned = "";
            if (strCode == null)
                strCode = "";
            if (strCode.Length < CostCenterCodeLength)
                return "";
            int intMainLevel = intLevel;
            List<CodeLevelFeature> objCol = CostCenterCodeLevelArr;
            intLevel = objCol.Count - intLevel; //the code starts from the right not the left
            CodeLevelFeature objBiz = new CodeLevelFeature();
            int intStartIndex = 0;
            for (int intIndex = objCol.Count - 1; intIndex >= intMainLevel; intIndex--)
            {
                objBiz = objCol[intIndex];
                intStartIndex += objBiz.LevelLength;
            }
            Returned = strCode.Substring(intStartIndex, GetCostCenterLevel(intMainLevel).LevelLength);
            return Returned;
        }
        public static string GetCostCenterLevelCod(int intLevel, string strCode)
        {

            string Returned = "";
            if (strCode == null)
                strCode = "";
            if (strCode.Length < CostCenterCodeLength)
                return "";
           // int intMainLevel = intLevel;
            List<CodeLevelFeature> objCol = CostCenterCodeLevelArr;
            //intLevel = objCol.Count - intLevel; //the code starts from the right not the left
            CodeLevelFeature objBiz = new CodeLevelFeature();
            int intStartIndex = 0;
            for (int intIndex =0; intIndex< intLevel-1; intIndex++)
            {
                objBiz = objCol[intIndex];
                intStartIndex += objBiz.LevelLength;
            }
            Returned = strCode.Substring(intStartIndex, GetCostCenterLevel(intLevel).LevelLength);
            return Returned;
        }
        public static string GetCostCenterLevelFullCode(int intLevel, string strCode)
        {

            string Returned = "";
            if (strCode == null)
                strCode = "";
           
            string strTemp = "";
            for (int intIndex = 1; intIndex <= CostCenterCodeLevelArr.Count; intIndex++)
            {
                if(intIndex > intLevel)
                    strTemp += SysUtility.SetPadLeft("",CostCenterCodeLevelArr[intIndex-1].LevelLength);
                else
                    strTemp += GetCostCenterLevelCod(intIndex,strCode);

                
            }
            Returned = strTemp;
            return Returned;
        }
        public static CodeLevelFeature GetCostCenterLevel(int intLevel)
        {
            CodeLevelFeature Returned = new CodeLevelFeature();
            if (intLevel > CostCenterCodeLevelArr.Count + 1)
                intLevel = CostCenterCodeLevelArr.Count;
            Returned = CostCenterCodeLevelArr[intLevel - 1];

            return Returned;
        }

        public static void SetUMSDb(string strConnection,int intLanguage)
        {
            //UserBiz.SetUmsBaseConnection(strConnection,intLanguage,0);
        }
        public static void SetUMSDb(string strConnection,int intSysID,int intLaguage,string strUrl)
        {
            _UMSConnectionStr = strConnection;

            UserBiz.SetUmsBaseConnection(strConnection,intSysID,intLaguage,strUrl);
        }
        public static void SetWebUMSDb(string strWebService, int intSysID)
        {
           
            //WebUserBiz.SetUmsBaseConnection(strWebService, intSysID);
        }

 
        
    
    }

}