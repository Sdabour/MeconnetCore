using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
namespace SharpVision.UMS.UMSDataBase
{
    public class LogInDb
    {
        #region Private Data
        int _ID;
        string _Code;
        #endregion
        #region Constructors

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
        int _User;

        public int User
        {
            get { return _User; }
            set { _User = value; }
        }
        int _System;

        public int System
        {
            get { return _System; }
            set { _System = value; }
        }
        string _IP;

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        int _Day;

        public int Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        DateTime _Time;

        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public static string HostName
        {
            get
            {
                string Returned = Dns.GetHostName();
                return Returned;
            }
        }
        static string _CurrentIP;
        public static string CurrentIP
        {
            get
            {
                if (_CurrentIP == null || _CurrentIP == "")
                {
                    _CurrentIP = Dns.GetHostByName(HostName).AddressList[0].ToString();
                }
                return _CurrentIP;
            }
        }
        public static string CurrentDay
        {
            get
            {
                string Returned = "CONVERT(NUMERIC,REPLACE(CONVERT(varchar(20), GETDATE(), 102), '.', ''))";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                
                string Returned = "insert into UMSUserLogIn (LogInUser, LogInSystem, LogInIP, LoginDay, LogInTime) "+
                    " values (" + _User + "," + BaseDb.SysID + ",'" + CurrentIP + "',"  + CurrentDay  + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   dbo.UMSUserLogIn.LogInID, dbo.UMSUserLogIn.LogInUser, dbo.UMSUserLogIn.LogInSystem, dbo.UMSUserLogIn.LogInIP, dbo.UMSUserLogIn.LoginDay, dbo.UMSUserLogIn.LogInTime, "+
                         " dbo.UMSUser.UN AS LogInUserName, derivedtbl_1.ApplicantCode AS LogInApplicantCode, derivedtbl_1.ApplicantFirstName AS LogInApplicantName "+
                         " FROM            (SELECT        dbo.HRApplicantWorker.ApplicantUser, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName "+
                           " FROM            dbo.HRApplicantWorker INNER JOIN "+
                           " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID) AS derivedtbl_1 RIGHT OUTER JOIN "+
                           " dbo.UMSUser ON derivedtbl_1.ApplicantUser = dbo.UMSUser.UID RIGHT OUTER JOIN "+
                           " dbo.UMSUserLogIn ON dbo.UMSUser.UID = dbo.UMSUserLogIn.LogInUser "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
           BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
