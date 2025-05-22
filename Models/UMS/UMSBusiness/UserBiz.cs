using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;

namespace SharpVision.UMS.UMSBusiness
{
    public class UserSmple
    {
        public int ID
        {
            set; get;
        }
        public string Name
        {
            set; get;
        }
        public string FullName { set; get; }
        public int EmployeeID
        { set; get; }
        public string EmployeeCode
        { set; get; }
        public string EmployeeName
        { set; get; }
        public string Job
        { set; get; }
        public string Sector
        { set; get; }
        public int WorkGroup
        { set; get; }
        public string WorkGroupName
        { set; get; }
        public int RuleID
        {
            set;
            get;
        }
        public string RuleName
        { set; get; }
        public List<int> ServiceTypeIDs
        { set; get; }

        public List<FunctionSimple> FunctionLst
        {
            set;
            get;

        }
        public static string CurrentUserIDKey
        { get => "CurrentUser"; }
        public static UserSmple CurrentUser
        {
            get
            {
                UserSmple Returned = new UserSmple();
                if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey) != null)
                {
                    string strTemp = AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey);
                    Returned = Newtonsoft.Json.JsonConvert.DeserializeObject<UserSmple>(strTemp);
                }
                return Returned;
            }
        }

        public Hashtable GetFunctionSimpleHash()
        {
            Hashtable Returned = new Hashtable();

            foreach (FunctionSimple objFunctionSimple in FunctionLst)
            {
                if (Returned[objFunctionSimple.ID.ToString()] == null)
                    Returned.Add(objFunctionSimple.ID.ToString(), objFunctionSimple);
            }
            return Returned;
        }
        public bool CheckFunction(int intFunctionID)
        {
            bool Returned = false;
            foreach (FunctionSimple objBiz in FunctionLst)
            {
                if (objBiz.ID == intFunctionID)
                {
                    Returned = true;
                    break;
                }
            }
            return Returned;


        }
    }
    //public class FunctionSimple
    //{
    //    public int ID
    //    { set; get; }
    //    public string Name
    //    { set; get; }

    //}

    public class UserBiz
    {
        #region Private Data
        static int _Language;
        protected UserDb _UserDb;
        protected GroupBiz _GroupBiz;
        protected GroupDb _GroupDb;
        protected UserFunctionInstantCol _AllUserFunctionInstantCol;
        protected UserFunctionInstantDb _UserFunctionInstantDb;
        protected UserFunctionInstantBiz _UserFunctionInstantBiz;
        protected FunctionCol _FunctionCol;
        protected FunctionBiz _FunctionBiz;
        protected EmployeeBiz _EmployeeBiz;
        private static bool _IsOnline;
        Hashtable _UserFunctionHs = new Hashtable();
        private static UserBiz _CurrentUser;

        #endregion
        #region Constructors
        public UserBiz()
        {

            _UserDb = new UserDb();
        }

        public UserBiz(int intUserID)
        {
            if (intUserID == 0)
            {
                _UserDb = new UserDb();
                return;
            }
                UserDb objTemp = new UserDb();
            objTemp.ID = intUserID;
            DataTable dtTemp = objTemp.Search();
            if (dtTemp.Rows.Count > 0)
            {
                _UserDb = new UserDb(dtTemp.Rows[0]);
                if (_UserDb.EmployeeID != 0)
                    _EmployeeBiz = new EmployeeBiz(dtTemp.Rows[0]);

            }
            else
                _UserDb = new UserDb();
        }
        public UserBiz(DataRow DR)
        {
            _UserDb = new UserDb(DR);
            if (_UserDb.EmployeeID != 0)
                _EmployeeBiz = new EmployeeBiz(DR);
        }

        public UserBiz(UserDb objUserDb)
        {
            _UserDb = objUserDb;
        }
        public UserBiz(string strUserName, string strUserFullName, string strUserPassword, int intGroupID, bool blIsGroupAdmin, bool blIsAdmin)
        {
            _UserDb = new UserDb(strUserName, strUserFullName, strUserPassword, intGroupID, blIsGroupAdmin, blIsAdmin);
        }
        public UserBiz(int intID, string strName)
        {
            _UserDb = new UserDb(intID, strName);
        }


        #endregion
        #region Public Properties
        public bool IsAdmin
        {
            set
            {
                _UserDb.IsAdmin = value;
            }
            get
            {
                return _UserDb.IsAdmin;
            }

        }

        public bool IsGroupAdmin
        {

            set
            {
                _UserDb.IsGroupAdmin = value;
            }
            get
            {
                return _UserDb.IsGroupAdmin;
            }
        }

        public int ID
        {

            get
            {
                return _UserDb.ID;
            }
            set
            {
                _UserDb.ID = value;
            }
        }
        [Description("User Name")]
        public string Name
        {

            get
            {
                return _UserDb.Name;
            }
            set
            {
                _UserDb.Name = value;
            }
        }
        public string FullName
        {
            get
            {
                return _UserDb.FullName;
            }
            set
            {
                _UserDb.FullName = value;
            }
        }
        [Description("Pass Word")]
       [DataType(DataType.Password)]
        public string Password
        {
            get
            {
                return _UserDb.Password;
            }
            set
            {
                _UserDb.Password = value;
            }
        }
        public int GroupID
        {

            get
            {
                return _UserDb.GroupID;
            }
            set
            {
                _UserDb.GroupID = value;
            }
        }
        public static bool IsOnline
        {
            set
            {
                _IsOnline = value;
            }
        }

        public GroupBiz GroupBiz
        {
            set
            {
                _GroupBiz = value;
            }
            get
            {
                if (_GroupBiz == null)
                    _GroupBiz = new GroupBiz(_UserDb.GroupDb);
                return _GroupBiz;
            }
        }

        public UserFunctionInstantBiz UserInstantFunctionBiz
        {
            get
            {
                return new UserFunctionInstantBiz(_UserDb.FunctionInstantDb);
            }
        }
        public string GroupName
        {
            set
            {
                _UserDb.GroupName = value;
            }
            get
            {
                return _UserDb.GroupName;
            }
        }

        public EmployeeBiz EmployeeBiz
        {
            set
            {
                _EmployeeBiz = value;
            }
            get
            {
                if (_EmployeeBiz == null)
                    _EmployeeBiz = new EmployeeBiz();
                return _EmployeeBiz;
            }
        }
        UserFunctionInstantCol _UserFunctionInstantCol;
        public virtual UserFunctionInstantCol UserFunctionInstantCol
        {
            set
            {
                _UserFunctionInstantCol = value;

            }
            get
            {
                if (_UserFunctionInstantCol == null)
                {
                    DataTable dtTemp = _UserDb.GetUserFunctions();

                    _UserFunctionInstantCol = new UserFunctionInstantCol(true);
                    _UserFunctionHs = new Hashtable();
                    UserFunctionInstantBiz tempUserFunctionInstantBiz;
                    foreach (DataRow DR in dtTemp.Rows)
                    {
                        tempUserFunctionInstantBiz = new UserFunctionInstantBiz(DR);
                        _UserFunctionInstantCol.Add(tempUserFunctionInstantBiz);
                        if (_UserFunctionHs[tempUserFunctionInstantBiz.ID.ToString()] == null)
                            _UserFunctionHs.Add(tempUserFunctionInstantBiz.ID.ToString(), tempUserFunctionInstantBiz);

                    }
                    return _UserFunctionInstantCol;
                }
                else
                    return _UserFunctionInstantCol;
            }

        }
        public UserSimple UserSimple
        {
            get
            {
                UserSimple Returned = new UserSimple() { ID=ID,Name=Name,EmpID=EmployeeBiz.ID,EmpCode=EmployeeBiz.Code,EmpName=EmployeeBiz.Name,Job="",Sector=EmployeeBiz.DepartmentStr,WorkGroup = EmployeeBiz.WorkGroupBiz.ID, WorkGroupName = EmployeeBiz.WorkGroupBiz.Name };
                Returned.FunctionLst = new List<FunctionSimple>();
                foreach (UserFunctionInstantBiz objBiz in UserFunctionInstantCol)
                    Returned.FunctionLst.Add(new FunctionSimple() { ID = objBiz.ID, Name = objBiz.Name });

                return Returned;
            }
        }
        public UserFunctionInstantCol AllUserFunctionInstantCol
        {
            //set
            //{
            //    _UserFunctionInstantCol = value;

            //}
            set
            {
                _AllUserFunctionInstantCol = value;
            }
            get
            {
                if (_AllUserFunctionInstantCol == null)
                {
                    _AllUserFunctionInstantCol = new UserFunctionInstantCol(true);
                    if (ID == 0)
                        return _AllUserFunctionInstantCol;
                    DataTable dtTemp = _UserDb.GetAllUserFunctions();

                   
                    _UserFunctionHs = new Hashtable();

                    UserFunctionInstantBiz tempUserFunctionInstantBiz;
                    foreach (DataRow DR in dtTemp.Rows)
                    {
                        tempUserFunctionInstantBiz = new UserFunctionInstantBiz(DR);
                        _AllUserFunctionInstantCol.Add(tempUserFunctionInstantBiz);
                        _UserFunctionHs.Add(tempUserFunctionInstantBiz.ID.ToString(), tempUserFunctionInstantBiz);
                    }
                    return _AllUserFunctionInstantCol;
                }
                else
                    return _AllUserFunctionInstantCol;
            }

        }
        public Hashtable UserFunctionHs
        {
            set
            {
                _UserFunctionHs = new Hashtable();
            }
            get
            {
                if (_UserFunctionHs == null)
                    _UserFunctionHs = new Hashtable();
                return _UserFunctionHs;
            }
        }

        public static string CurrentUserIDKey
        { get => "CurrentUser"; }
        public static UserSmple CurrentUser
        {
            get
            {
                UserSmple Returned = new UserSmple();
                if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey) != null)
                {
                    string strTemp = AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString(CurrentUserIDKey);
                    Returned = Newtonsoft.Json.JsonConvert.DeserializeObject<UserSmple>(strTemp);
                }
                return Returned;
            }
        }
        public static int Language
        {
            set
            {
                _Language = value;
            }
            get
            {
                return _Language;
            }
        }

        UserGroupCol _GroupCol;
        public UserGroupCol GroupCol
        {
            set
            { _GroupCol = value; }
            get
            {
                if (_GroupCol == null)
                {
                    _GroupCol = new UserGroupCol(true);
                    UserGroupDb objDb = new UserGroupDb();
                    objDb.UserID = ID;
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _GroupCol.Add(new UserGroupBiz(objDr));
                    }
                }
                return _GroupCol;
            }
        }

        UserSystemCol _SystemCol;
        public UserSystemCol SystemCol
        {
            set
            { _SystemCol = value; }
            get
            {
                if (_SystemCol == null)
                {
                    _SystemCol = new UserSystemCol(true);
                    UserSystemDb objDb = new UserSystemDb();
                    objDb.UserID = ID;
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _SystemCol.Add(new UserSystemBiz(objDr));

                }
                return _SystemCol;
            }
        }
        //

        //
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _UserDb.GroupID = GroupBiz.ID;
            _UserDb.EmployeeID = EmployeeBiz.ID;
            _UserDb.FunctionTable = AllUserFunctionInstantCol.GetTable();
            _UserDb.GroupTable = GroupCol.GetTable();
            _UserDb.SystemTable = SystemCol.GetTable();
            _UserDb.Add();
            _UserDb.JoinFunction();
            _UserDb.JoinSystem();
            _UserDb.JoinGroup();

        }
        public void Edit()
        {
            _UserDb.GroupID = GroupBiz.ID;
            _UserDb.EmployeeID = EmployeeBiz.ID;
            _UserDb.FunctionTable = AllUserFunctionInstantCol.GetTable();
            _UserDb.GroupTable = GroupCol.GetTable();
            _UserDb.SystemTable = SystemCol.GetTable();
            _UserDb.Edit();
            _UserDb.JoinFunction();
            _UserDb.JoinSystem();
            _UserDb.JoinGroup();

        }
        public static void Add(string strFullName, string strName, string strPassword
            , int intGroupID, bool blIsGroupAdmin,
            bool blIsAdmin, UserFunctionInstantCol objUserFunctionInstantCol
            , EmployeeBiz objEmployeeBiz, UserBiz objSrcUser)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();
            UserDb objUserDb = new UserDb();
            objUserDb.Name = strName;
            objUserDb.FullName = strFullName;
            objUserDb.Password = strPassword;
            objUserDb.GroupID = intGroupID;
            objUserDb.IsGroupAdmin = blIsGroupAdmin;
            objUserDb.IsAdmin = blIsAdmin;
            objUserDb.EmployeeID = objEmployeeBiz.ID;
            if (objSrcUser == null)
                objSrcUser = new UserBiz();
            objUserDb.SrcUsrID = objSrcUser.ID;
            objUserDb.Add();
            int intID = objUserDb.ID;
            AddFunction(intID, objUserFunctionInstantCol);

        }
        public static void Edit(int intID, string strFullName, string strName, string strPassword,
            int intGroupID, bool blIsGroupAdmin, bool blIsAdmin, UserFunctionInstantCol objUserFunctionInstantCol,
            EmployeeBiz objEmployeeBiz, UserBiz objSrcUser)
        {
            if (objEmployeeBiz == null)
                objEmployeeBiz = new EmployeeBiz();
            UserDb objUserDb = new UserDb();
            objUserDb.ID = intID;
            objUserDb.Name = strName;
            objUserDb.FullName = strFullName;
            objUserDb.Password = strPassword;
            objUserDb.GroupID = intGroupID;
            objUserDb.IsGroupAdmin = blIsGroupAdmin;
            objUserDb.IsAdmin = blIsAdmin;
            objUserDb.EmployeeID = objEmployeeBiz.ID;
            if (objSrcUser == null)
                objSrcUser = new UserBiz();
            objUserDb.SrcUsrID = objSrcUser.ID;
            AddFunction(intID, objUserFunctionInstantCol);
            objUserDb.Edit();



        }

        public static void Delete(int intID)
        {
            UserDb objUserDb = new UserDb();
            objUserDb.ID = intID;
            objUserDb.Delete();
        }
        public static bool SetUmsBaseConnection(string strUMSBaseConnection, int intLanguage)//,int intSysID)
        {
            _Language = intLanguage;
            //UserWeb.SysID = intSysID;
            // UserWeb.URL = strServiceUrl;
            return UserDb.SetUmsBaseConnection(strUMSBaseConnection);

        }
        public static bool SetUmsBaseConnection(string strUMSBaseConnection, int intSysID, int intLanguage, string strServiceUrl)
        {
            _Language = intLanguage;
            //UserWeb.SysID = intSysID;
            //UserWeb.URL = strServiceUrl;
            if (!_IsOnline)
                return UserDb.SetUmsBaseConnection(strUMSBaseConnection, intSysID);
            else
                return true;
        }

        public static bool CheckUser(string strUserName, string strPassword, out UserBiz objUserBiz)
        {
            bool blReturned = false;
            strUserName = strUserName.Replace("'", "");
            strPassword = strPassword.Replace("'", "");

            UserDb objUserDb;
            objUserBiz = new UserBiz();
            if (strUserName == null || strUserName == "" | strPassword == null || strPassword == "")
                return false;
            if (_IsOnline)
            {
                //objUserDb = new UserWeb(strUserName, strPassword);
                //objUserBiz = new UserBiz(objUserDb);
                //if (objUserDb.ID != 0)
                //    blReturned = true;

            }
            else
            {
                objUserDb = new UserDb();//(strUserName, strPassword);
                objUserDb.Name = strUserName;
                objUserDb.Password = strPassword;

                DataTable dtTemp = objUserDb.Search();
                if (dtTemp.Rows.Count == 0)
                {
                    objUserDb = new UserDb();

                    blReturned = false;
                }
                else
                {
                    blReturned = true;
                    objUserBiz = new UserBiz(dtTemp.Rows[0]);
                    LogInDb objLogin = new LogInDb();
                    objLogin.User = objUserBiz.ID;
                    objLogin.Add();

                }

            }



            return blReturned;
        }

        public static void JoinFunction(UserBiz objUserBiz, FunctionCol objFunctionCol)
        {

            objUserBiz._UserDb.FunctionTable = objFunctionCol.FunctionTable;
            objUserBiz._UserDb.JoinFunction();
        }
        public static void JoinFunction(UserBiz objUserBiz, FunctionBiz objFunctionBiz)
        {
            //DataTable dtFunction = FunctionDb.FunctionTableStructure;
            //dtFunction.Rows.Add(objFunctionBiz.FunctionBizDR);
            //objUserBiz._UserDb.JoinOneFunction();

        }
        public static void AddFunction(int intUserID, UserFunctionInstantCol objUserFunctionInstantCol)
        {
            UserDb objUserDb = new UserDb();

            objUserDb.ID = intUserID;
            DataTable dtTemp = new DataTable();
            DataColumn dcTemp = new DataColumn("FunctionID");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("IsPermanent");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("IsAdmin");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("StartDate");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("EndDate");
            dtTemp.Columns.Add(dcTemp);

            DataRow drTemp;
            foreach (UserFunctionInstantBiz objUserFunctionInstantBiz in objUserFunctionInstantCol)
            {
                drTemp = dtTemp.NewRow();
                drTemp["FunctionID"] = objUserFunctionInstantBiz.ID;
                drTemp["IsPermanent"] = objUserFunctionInstantBiz.IsPermanent;
                drTemp["IsAdmin"] = objUserFunctionInstantBiz.IsAdmin;
                drTemp["StartDate"] = objUserFunctionInstantBiz.StartDate;
                drTemp["EndDate"] = objUserFunctionInstantBiz.EndDate;
                dtTemp.Rows.Add(drTemp);

            }
            objUserDb.FunctionTable = dtTemp;
            objUserDb.JoinFunction();
        }
        public void EditPassword(string strNewPassword)
        {
            Password = strNewPassword;
            _UserDb.EditPassword();
        }
        public virtual UserBiz Copy()
        {
            UserBiz Returned = new UserBiz();
            GroupBiz temp = new GroupBiz();
            Returned.GroupID = this.GroupID;
            Returned.GroupBiz = GroupBiz;
            Returned.ID = this.ID;
            Returned.Name = this.Name;
            Returned.FullName = this.FullName;
            Returned.Password = this.Password;
            Returned.IsGroupAdmin = this.IsGroupAdmin;
            Returned.IsAdmin = this.IsAdmin;
            Returned.AllUserFunctionInstantCol = AllUserFunctionInstantCol.Copy();
            return Returned;
        }
        public UserFunctionInstantCol GetFunctionInstantCol(string strFunctionIDs)
        {
            UserFunctionInstantCol Returned = new UserFunctionInstantCol(true);
            UserFunctionInstantDb objDb = new UserFunctionInstantDb();
            objDb.UserID = ID;
            objDb.FunctionIDs = strFunctionIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new UserFunctionInstantBiz(objDr));

            return Returned;
        }
        public void AssignFunctionCol(string strFunctionIDs, UserFunctionInstantCol objCol)
        {
            UserDb objDb = new UserDb();
            objDb.ID = ID;
            objDb.FunctionTable = objCol.GetTable();
            objDb.FunctionIDs = strFunctionIDs;
            objDb.JoinParticularFunction();
        }
        #endregion



    }
}
