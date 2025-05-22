using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase
{
    public class UserDb
    {
        #region Private Data
        protected int _ID;
        protected string _Name;
        protected string _FullName;
        protected string _Password;
        protected string _GroupName;
        protected int _GroupID;
        protected string _GroupIDs;
        private bool _IsGroupAdmin;
        private bool _IsAdmin;
        protected DataTable _FunctionTable;
        public DataTable _System;
        protected GroupDb _GroupDb;
        protected UserFunctionInstantDb _FunctionInstantDb;
        string _IDs;
        string _FunctionGroupIDs;
        bool _IsOnlineUser;

        private int _FunctionSearchStatus;/*
                                           * 0 dont care
                                           * 1 only has function
                                           */
        private int _FunctionID;
        private string _FunctionAncestorStr;
        private int _EmployeeID;
        DataTable _UserTable;

        public DataTable UserTable
        {
            get { return _UserTable; }
            set { _UserTable = value; }
        }
        #endregion
        #region Constructors
        public UserDb()
        {
           
            _GroupDb = new GroupDb();
            _FunctionInstantDb = new UserFunctionInstantDb();

        }

        public UserDb(string strUserName, string strPassword, string strFullName, int intGroupID,bool blIsGroupAdmin,bool blIsAdmin)
        {
            _Name = strUserName;
            _Password = strPassword;
            _FullName = strFullName;
            _GroupID = intGroupID;
            _IsAdmin = blIsAdmin;
            _IsGroupAdmin = blIsGroupAdmin;
            DataTable dtCheck = Search();
            if (dtCheck != null && dtCheck.Rows.Count != 0)
            {
                DataRow DR = dtCheck.Rows[0];
              
                _ID = int.Parse(DR["UserID"].ToString());
                _FullName = DR["UserFullname"].ToString();
                _Name = DR["UserName"].ToString();
                _Password = DR["UserPassword"].ToString();
                _GroupID = int.Parse(DR["UserGroup"].ToString());
                _GroupName = DR["GroupName"].ToString();
                _IsAdmin = Convert.ToBoolean(DR["UserIsAdmin"].ToString());
                _IsGroupAdmin = Convert.ToBoolean(DR["UserIsGroupAdmin"].ToString());
                
            }

        }
        public UserDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            DataRow DR = dtTemp.Rows[0];
            SetUserDb(DR);
          
        }
        public UserDb(string strUserName, string strPassword)
        {
            _Name = strUserName;
            _Password = strPassword;
            DataTable dtCheck = Search();
            if (dtCheck != null && dtCheck.Rows.Count != 0)
            {
                DataRow DR = dtCheck.Rows[0];

                SetUserDb(DR);
                LogInDb objDb = new LogInDb();
                objDb.User = ID;
                objDb.Add();

            }
        }
        public UserDb(DataRow DR)
        {

            SetUserDb(DR);


        }
        public UserDb(int intID, string strName)
        {
            _ID = intID;
            _FullName = strName;
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
        int _SrcUsrID;

        public int SrcUsrID
        {
            get { return _SrcUsrID; }
            set { _SrcUsrID = value; }
        }
       

        public bool IsAdmin
        {
            set { _IsAdmin = value; }
            get { return _IsAdmin; }
        }
        bool _IsCurrentSystemAdmin;
        bool _CurrentSystemSet = false;
        public bool IsCurrentSystemAdmin
        {
            get
            {
                if (!_CurrentSystemSet)
                {
                    UserSystemDb objDb = new UserSystemDb();
                    objDb.SysID = BaseDb.SysID;
                    objDb.UserID = ID;
                    DataTable dtTemp = objDb.Search();
                    if (dtTemp.Rows.Count > 0)
                        _IsCurrentSystemAdmin = true;
                    else
                        _IsCurrentSystemAdmin = false;
                    _CurrentSystemSet = true;
                }
                return _IsCurrentSystemAdmin;
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
        public string FullName
        {
            set
            {
                _FullName = value;
            }
            get
            {
                return _FullName;
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
        public int GroupID
        {
            set
            {
                _GroupID = value;
            }
            get
            {
                return _GroupID;
            }
        }
       

        public GroupDb GroupDb
        {
            set
            {
                _GroupDb = value;
            }
            get
            {
                if (_GroupDb == null)
                    _GroupDb = new GroupDb();
                return _GroupDb;
            }
        }
        public UserFunctionInstantDb FunctionInstantDb
        {
            set
            {
                _FunctionInstantDb = value;
            }
            get
            {
                return _FunctionInstantDb;
            }
        }
        
        public string  GroupName
        {
            set
            {
                _GroupName = value;
            }
            get
            {
                return _GroupName;
            }
        }
        
     
        public DataTable FunctionTable
        {
            set
            {
                _FunctionTable = value;
            }
            get
            {
                return _FunctionTable;

            }
        }
        public bool IsGroupAdmin
        {
            set
            {
                _IsGroupAdmin = value;
            }
            get
            {
                return _IsGroupAdmin;
            }
        }
        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get 
            {
                return _EmployeeID;
            }
        }
        DataTable _SystemTable;
        public DataTable SystemTable
        {
            set
            {
                _SystemTable = value;
            }
        }
        DataTable _GroupTable;
        public DataTable GroupTable
        {
            set
            {
                _GroupTable = value;
            }
        }
        public bool IsOnlineUser
        {
            set
            {
                _IsOnlineUser = value;
            }
        }
        public DataTable System
        {
            set
            {
                _System = value;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public string GroupIDs
        {

            set
            {
                _GroupIDs = value;
            }
        }
        public int FunctionSearchStatus
        {
            set
            {
                _FunctionSearchStatus = value;
            }
        }
        public int FunctionID
        {
            set
            {
                _FunctionID = value;
            }

        }
        public string FunctionAncestorStr
        {
            set
            {
                _FunctionAncestorStr = value;
            }
        }
        public string FunctionGroupIDs
        {
            set
            {
                _FunctionGroupIDs = value;
            }
        }
        string _FunctionIDs;

        public string FunctionIDs
        {
            get { return _FunctionIDs; }
            set { _FunctionIDs = value; }
        }
        #endregion
        #region Private Methods
        public  void SetUserDb(DataRow DR)
        {
            _ID = int.Parse(DR["UserID"].ToString());
            _FullName = DR["UserFullname"].ToString();
            _Name = DR["UserName"].ToString();
            _Password = DR["UserPassword"].ToString();
            _GroupID = int.Parse(DR["UserGroup"].ToString());
            _GroupName = DR["GroupName"].ToString();
            try
            {
                _IsAdmin = Convert.ToBoolean(DR["UserIsAdmin"].ToString());
            }
            catch { }
            try
            {
                _IsGroupAdmin = Convert.ToBoolean(DR["UserIsGroupAdmin"].ToString());
            }
            catch { }
            if (DR["ApplicantID"].ToString() != "")
                _EmployeeID = int.Parse(DR["ApplicantID"].ToString());
            if (_Name == null || _Name == "")
            {
                _FullName = SysCryptography.EncryptDecryptStr(DR["UFN"].ToString());
                _Name = SysCryptography.EncryptDecryptStr(DR["UN"].ToString());
            }

        }
        public  static void SetUserDecrypted(ref DataRow objDr, string strEncryptedFields,string strDecryptedField,string strSparator)
        {
            string[] arrEncrypted = strEncryptedFields.Split(strSparator.ToCharArray());
            string[] arrDecrypted = strDecryptedField.Split(strSparator.ToCharArray());
            for (int intIndex = 0; intIndex < arrDecrypted.Length && intIndex < arrEncrypted.Length; intIndex++)
            {
                objDr[arrDecrypted[intIndex]] = SysCryptography.EncryptDecryptStr(objDr[arrEncrypted[intIndex]].ToString());
            }
        }
        public static string GetDecryptedStr(string strEncrypted)
        {
            string Returned = SysCryptography.EncryptDecryptStr(strEncrypted);
            return Returned;
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            string strUN = SysCryptography.EncryptDecryptStr(_Name).Replace("'","''");
            string strUFN = SysCryptography.EncryptDecryptStr(_FullName).Replace("'", "''");
            string strUP = SysCryptography.EncryptDecryptStr(_Password).Replace("'", "''");
            string strUIGA = SysCryptography.EncryptDecryptStr(_IsGroupAdmin.ToString()).Replace("'", "''");
            string strUIA = SysCryptography.EncryptDecryptStr(_IsAdmin.ToString()).Replace("'", "''");
            

            string strSql = "insert into UMSUser (UFN, UN, UP, UG, UIGA, UIA)" +
            "values('" + strUFN + "','" + strUN + "','" + strUP + "'," + _GroupID + ",'" + strUIGA + "','"+strUIA+"')";
           
          
                _ID = Convert.ToInt32(BaseDb.UMSBaseDb.InsertIdentityTable(strSql));
                if (_EmployeeID != 0)
                {
                    EmployeeDb objTemp = new EmployeeDb();
                    objTemp.ID = _EmployeeID;
                    objTemp.UserID = _ID;
                    objTemp.EditUserID();
                   
                }
                CopyUserAuthentication();
            //JoinFunction();
            //JoinGroup();
            //JoinSystem();

        }
        public virtual void Edit()
        {
            string strUN = SysCryptography.EncryptDecryptStr(_Name).Replace("'", "''");
            string strUFN = SysCryptography.EncryptDecryptStr(_FullName).Replace("'", "''");
            string strUP = SysCryptography.EncryptDecryptStr(_Password).Replace("'", "''");
            string strUIGA = SysCryptography.EncryptDecryptStr(_IsGroupAdmin.ToString()).Replace("'", "''");
            string strUIA = SysCryptography.EncryptDecryptStr(_IsAdmin.ToString()).Replace("'", "''");
           

            string strSql = "update  UMSUser ";
            strSql = strSql + " set UFN = '" + strUFN + "'";
            strSql = strSql + ", UN ='" + strUN + "'";
            strSql = strSql + ",UP ='" + strUP + "'";
            strSql = strSql + ",UG=" + _GroupID;
            strSql = strSql + ",UIGA='" + strUIGA + "'";
            strSql = strSql + ",UIA ='" + strUIA + "'";
            strSql = strSql + " where UID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
            if (_EmployeeID != 0)
            {
                EmployeeDb objTemp = new EmployeeDb();
                objTemp.ID = _EmployeeID;
                objTemp.UserID = _ID;
                objTemp.EditUserID();

            }
            CopyUserAuthentication();
            //JoinFunction();
            //JoinGroup();
            //JoinSystem();

        }
        public void EditPassword()
        {
            string strUP = SysCryptography.EncryptDecryptStr(_Password).Replace("'", "''");
            string strSql = "update  UMSUser ";
           
            strSql = strSql + " set UP ='" + strUP + "'";
           
            strSql = strSql + " where UID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Delete()
        {
            string strSql = "update UMSUserFunction set Dis=Getdate()  where UserID = " + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
           
            strSql = "update UMSUser set Dis=Getdate()  where UserID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            string strEmployee = "SELECT  ApplicantUser, MAX(ApplicantID) AS ApplicantID "+
                   " FROM         dbo.HRApplicantWorker "+
                   " GROUP BY ApplicantUser "+
                   " HAVING      (ApplicantUser IS NOT NULL) AND (ApplicantUser <> 0) ";
            strEmployee = "select EmployeeTable.* "+
                " from (" + strEmployee + ") as TempTable inner join ("+ EmployeeDb.SearchStr +") as EmployeeTable  "+
                " on TempTable.ApplicantID = EmployeeTable.ApplicantID ";
            string strUN = _Name == null ? "" : SysCryptography.EncryptDecryptStr(Name).Replace("'", "''");
            
            string strUFN =_FullName== null ?"" : SysCryptography.EncryptDecryptStr(_FullName).Replace("'", "''");
            string strUP = _Password == null ? "" :  SysCryptography.EncryptDecryptStr(_Password).Replace("'", "''");
            string strUIGA = SysCryptography.EncryptDecryptStr(_IsGroupAdmin.ToString()).Replace("'", "''");
            string strUIA = SysCryptography.EncryptDecryptStr(_IsAdmin.ToString()).Replace("'", "''");
            string strSql = "SELECT UMSUser.UID UserID, UMSUser.UFN,'' UserFullName, UMSUser.UN,''  UserName"+
                            ", UMSUser.UP,'' UserPassword, UMSUser.UG UserGroup,UMSUser.UIGA,convert(bit,0) UserIsGroupAdmin,UMSUser.UIA,convert(bit,0) UserIsAdmin " +
                            " ,UMSGroup.GroupTypeID,UMSGroup.GroupFamilyID, UMSGroup.GroupParentID, UMSGroup.GroupName, UMSGroup.GroupID,  " +
                            " UMSGroupType.GroupTypeName,UMSGroupType.GroupTypeID AS Expr1, UMSGroupType.GroupTypeParentID, UMSGroupType.GroupTypeFamilyID,EmployeeTable.* " +
                            " FROM UMSGroupType INNER JOIN UMSGroup ON UMSGroupType.GroupTypeID = UMSGroup.GroupTypeID RIGHT OUTER JOIN UMSUser ON UMSGroup.GroupID = UMSUser.UG "+
                            " left outer join ("+ strEmployee +") as EmployeeTable "+
                            " on UMSUser.UID = EmployeeTable.ApplicantUser ";

            strSql = strSql + " WHERE   (1=1) ";
            if (_ID != 0)
                strSql = strSql + " and UID = " + _ID;
            else if(_IDs != null && _IDs != "")
                strSql = strSql + " and UID in (" + _IDs +")";
            else
                strSql = strSql + " and UmsUser.Dis   is Null";
            if (_Name != null && _Name != "")
            {
                if( _Password != null &&  _Password != "" )
                 strSql = strSql + " and UN  ='" + strUN + "' and  UP ='" + strUP + "' ";
                else
                 strSql = strSql + " and UN  like'%" + strUN  + "%' ";
            }
            if (_FullName != null && _FullName != "")
                strSql = strSql + " and UFN  like'%" + strUFN + "%' ";
            if (_GroupID != 0)
                strSql = strSql + "  and UG = " + _GroupID;
            if(_GroupIDs != null && _GroupIDs != "")
                strSql = strSql + "  and UG in (" + _GroupIDs +") ";
           // strSql = strSql + " Order By UMSUser.UserFullName";
            if (_EmployeeID != 0)
                strSql += " and EmployeeTable.ApplicantID ="+ _EmployeeID;
            if (_FunctionSearchStatus == 1)
            {
                string strFunction = "SELECT      UserID " +
                        " FROM    dbo.UMSUserFunction " +
                        " WHERE     ((IsPermanent = 1) OR " +
                        " (EndDate > GETDATE())) AND ((FunctionID = "+ _FunctionID +") ";
                if (_FunctionAncestorStr != null && _FunctionAncestorStr != "")
                    strFunction += " or ((FunctionID in (" + _FunctionAncestorStr + ")) and (IsAdmin=1)) ";
                
                strFunction += ")";

                strSql += " and ( (UIA ='" + SysCryptography.EncryptDecryptStr("TRUE") + "') or (UID in (" + strFunction + "))";
                if (_FunctionGroupIDs != null && _FunctionGroupIDs != "")
                    strSql+= " or  UG in ("+ _FunctionGroupIDs +")  ";
                strSql += ")";
            }
            DataTable dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql, "User");
            foreach (DataRow objDr in dtReturned.Rows)
            {
            
                objDr["UserFullName"] = SysCryptography.EncryptDecryptStr(objDr["UFN"].ToString());
                objDr["UserName"] = SysCryptography.EncryptDecryptStr(objDr["UN"].ToString());
                objDr["UserPassword"] = SysCryptography.EncryptDecryptStr(objDr["UP"].ToString());
                try
                {
                    objDr["UserIsGroupAdmin"] = SysCryptography.EncryptDecryptStr(objDr["UIGA"].ToString().ToLower()) == "true" ? 1 : 0;
                }
                catch { }
                try
                {
                    objDr["UserIsAdmin"] = SysCryptography.EncryptDecryptStr(objDr["UIA"].ToString().ToLower()) == "true" ? 1 : 0;
                }
                catch { }

            }
            return dtReturned;
        }
        public virtual DataTable GetUserFunctions()
        {
            DataTable dtReturned;
            if (_IsAdmin|| IsCurrentSystemAdmin)
            {
                SystemDb objSysDb = new SystemDb();
                objSysDb.ID = BaseDb.SysID;
                objSysDb.OnlyNonStopedFunction = true;
                objSysDb.OnlyOnlineFunction = _IsOnlineUser;
                dtReturned = objSysDb.GetSystemFunction();
                return dtReturned;
            }

            UserFunctionInstantDb tempUserFunctionDb = new UserFunctionInstantDb();
            tempUserFunctionDb.UserID = _ID;
            tempUserFunctionDb.OnlyNonStopedFunction = true;
            tempUserFunctionDb.OnlyOnlineFunction = _IsOnlineUser;
            DataTable dtTemp = tempUserFunctionDb.Search();
            GroupFunctionInstantDb tempGroupFunctionInstantDb = new GroupFunctionInstantDb();
            tempGroupFunctionInstantDb.GroupID = _GroupID;
            tempGroupFunctionInstantDb.UserID = ID;
            tempGroupFunctionInstantDb.OnlySystemFunction = true;
            tempGroupFunctionInstantDb.OnlyNonStopedFunction = true;
            tempGroupFunctionInstantDb.OnlyOnlineFunction = _IsOnlineUser;
            dtReturned = tempGroupFunctionInstantDb.Search();
            DataRow objDr;
            foreach (DataRow Dr in dtTemp.Rows)
            {

                objDr = dtReturned.NewRow();
                for (int intIndex = 0; intIndex < dtReturned.Columns.Count; intIndex++)
                {
                    try
                    {
                        objDr[intIndex] = Dr[intIndex];
                    }
                    catch
                    { 
                    }
                    
                }
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;
        }
        public virtual DataTable GetAllUserFunctions()
        {
            DataTable dtReturned;
            UserFunctionInstantDb tempUserFunctionDb = new UserFunctionInstantDb();
            tempUserFunctionDb.UserID = _ID;
            tempUserFunctionDb.AllFunction = true;
            dtReturned = tempUserFunctionDb.Search();
            return dtReturned;
        }

        public void CopyUserAuthentication()
        {
            if (_SrcUsrID == 0)
                return;
            string strUserID = _ID == 0 ? "@ID" : _ID.ToString();

            string strSql = "INSERT INTO dbo.UMSUserFunction "+
                  " ( UserID ,FunctionID ,StartDate ,EndDate ,IsPermanent ,IsAdmin ,Dis) "+
                 " SELECT        "+ strUserID +" AS UserID1, FunctionID, StartDate, EndDate, IsPermanent, IsAdmin, Dis "+
               " FROM            dbo.UMSUserFunction "+
                " WHERE        (UserID = "+ _SrcUsrID +" )";

            strSql += " UPDATE UMSUser SET UG= UMSUser_1.UG ,UIGA=UMSUser_1.UIGA , UIA =UMSUser_1.UIA,Dis= UMSUser_1.Dis "+
                       " FROM            dbo.UMSUser CROSS JOIN "+
                        " dbo.UMSUser AS UMSUser_1 "+
                        " WHERE        (UMSUser_1.UID = "+ _SrcUsrID +") AND (dbo.UMSUser.UID = "+ strUserID +") ";
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual void JoinFunction()
        {
            if (_FunctionTable == null || _FunctionTable.Rows.Count == 0)
                return;
            bool blIsAdmin = false;
            bool blIsPermanent;
            double dblStart;
            double dblEnd;


            string[] arrStr = new string[FunctionTable.Rows.Count + 1];
            arrStr[0] = "delete from UMSUserFunction where UserID=" + _ID;
            int intIndex = 0;
            foreach (DataRow objDR in _FunctionTable.Rows)
            {
                intIndex++;
                blIsPermanent = bool.Parse(objDR["IsPermanent"].ToString());
                blIsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
                if (blIsPermanent == false)
                {

                    dblStart = BaseDb.Approximate( DateTime.Parse(objDR["StartDate"].ToString()).ToOADate() - 2,1,UmsApproximateType.Down);
                    dblEnd = BaseDb.Approximate(DateTime.Parse(objDR["EndDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Up) ;
                    arrStr[intIndex] = "insert into UMSUserFunction ( UserID, FunctionID,IsPermanent,IsAdmin,StartDate,EndDate)" +
                        " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0") +
                        "," + (blIsAdmin ? "1" : "0") + "," + dblStart + "," + dblEnd + ")";
                   
                }
                else
                {
                    arrStr[intIndex] = "insert into UMSUserFunction ( UserID, FunctionID,IsPermanent,IsAdmin)" +
                       " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0") + "," + (blIsAdmin ? "1" : "0") + ")";
                   
                }


            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);

        }
        
        public static bool SetUmsBaseConnection(string strUMSBaseConnection)
        {
            BaseDb.UMSBaseDb = new SharpVision.Base.BaseDataBase.BaseDb(strUMSBaseConnection);
            return BaseDb.UMSBaseDb.sqlConnection.TestConection();
           
        }
        public static bool SetUmsBaseConnection(string strUMSBaseConnection, int intSysID)
        {

            BaseDb.UMSBaseDb = new SharpVision.Base.BaseDataBase.BaseDb(strUMSBaseConnection);
            BaseDb.SysID = intSysID;
            return BaseDb.UMSBaseDb.sqlConnection.TestConection();
           
        }
        public static DataTable GetTempKey()
        {
            string strSql = "SELECT        UID, aa as PKey  " +
                 " FROM            dbo.UMSTempUserKey ";
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        public void EditAllPass()
        {
            if (_UserTable == null || _UserTable.Rows.Count == 0)
                return;
            string strSql = "";
            List<string> arrStr = new List<string>();
            string strPass;
            int intUserID;
            foreach (DataRow objDr in _UserTable.Rows)
            {
                int.TryParse(objDr["UID"].ToString(), out intUserID);
                if (intUserID == 2 || intUserID == 3 || intUserID == 357)
                    continue;
                strPass = objDr["NewPass"].ToString();
                strPass = SysCryptography.EncryptDecryptStr(strPass).Replace("'", "''");
                strSql = "update UMSUser set UP ='"+ strPass +"' "+
                    " where UID =  "+ objDr["UID"].ToString();

                arrStr.Add(strSql);
            }

            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);
        }
        public void EditAllUserName()
        {
            if (_UserTable == null || _UserTable.Rows.Count == 0)
                return;
            string strSql = "";
            List<string> arrStr = new List<string>();
            string strPass;
            int intUserID = 0;
            foreach (DataRow objDr in _UserTable.Rows)
            {
                int.TryParse(objDr["UID"].ToString(), out intUserID);
                if (intUserID == 2 || intUserID == 3 || intUserID == 357)
                    continue;
                strPass = objDr["NewUserName"].ToString();
                if (strPass == "")
                    continue;
                strPass = SysCryptography.EncryptDecryptStr(strPass).Replace("'", "''");
                strSql = "update UMSUser set UN ='" + strPass + "' " +
                    " where UID =  " + objDr["UID"].ToString();

                arrStr.Add(strSql);
            }

            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);
        }

        public void JoinParticularFunction()
        {
            if (_FunctionTable == null )
                return;
            bool blIsAdmin = false;
            bool blIsPermanent;
            double dblStart;
            double dblEnd;


            string[] arrStr = new string[FunctionTable.Rows.Count + 1];
            arrStr[0] = "delete from UMSUserFunction where UserID=" + _ID + " and FunctionID in (" +_FunctionIDs + ") ";
            int intIndex = 0;
            foreach (DataRow objDR in _FunctionTable.Rows)
            {
                intIndex++;
                blIsPermanent = bool.Parse(objDR["IsPermanent"].ToString());
                blIsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
                if (blIsPermanent == false)
                {

                    dblStart = BaseDb.Approximate(DateTime.Parse(objDR["StartDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Down);
                    dblEnd = BaseDb.Approximate(DateTime.Parse(objDR["EndDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Up);
                    arrStr[intIndex] = "insert into UMSUserFunction ( UserID, FunctionID,IsPermanent,IsAdmin,StartDate,EndDate)" +
                        " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0") +
                        "," + (blIsAdmin ? "1" : "0") + "," + dblStart + "," + dblEnd + ")";

                }
                else
                {
                    arrStr[intIndex] = "insert into UMSUserFunction ( UserID, FunctionID,IsPermanent,IsAdmin)" +
                       " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0") + "," + (blIsAdmin ? "1" : "0") + ")";

                }


            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);

        }
        public void JoinSystem()
        {
            if (_SystemTable == null)
                return;
            string strSql = "delete from UMSUserSystem where UserID = "+ _ID;
            List<string> arrStr = new List<string>();
            arrStr.Add(strSql);
            UserSystemDb objDb;
            foreach (DataRow objDr in _SystemTable.Rows)
            {
                objDb = new UserSystemDb(objDr);
                objDb.UserID = ID;

                arrStr.Add(objDb.AddStr);
            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);

        }
        public void JoinGroup()
        {
            if (_GroupTable == null)
                return;
            string strSql = "delete from UMSUserGroup where UserID = " + _ID;
            List<string> arrStr = new List<string>();
            arrStr.Add(strSql);
            UserGroupDb objDb;
            foreach (DataRow objDr in _GroupTable.Rows)
            {
                objDb = new UserGroupDb(objDr);
                objDb.UserID = ID;
                arrStr.Add(objDb.AddStr);
            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion

    }
}

