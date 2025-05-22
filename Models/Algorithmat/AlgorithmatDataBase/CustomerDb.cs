using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class CustomerDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        bool _Confirmed;

        public bool Confirmed
        {
            get { return _Confirmed; }
            set { _Confirmed = value; }
        }
        DateTime _Dis;

        public DateTime Dis
        {
            get { return _Dis; }
            set { _Dis = value; }
        }
        int _LastSentID;

        public int LastSentID
        {
            get { return _LastSentID; }
            set { _LastSentID = value; }
        }
        DateTime _LastSentIDTime;

        public DateTime LastSentIDTime
        {
            get { return _LastSentIDTime; }
            set { _LastSentIDTime = value; }
        }

        #endregion
        #region Constructors
        public CustomerDb()
        { }
        public CustomerDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
       
        public string AddStr
        {
            get
            {
                _Mail = _Mail.Replace("'", "");

                string Returned = "insert into PORTALCustomer (CustomerMail, CustomerPassword,LastSentID,LastSentIDTime)  " +
                    "  select '"+_Mail+"' as CustomerMail,'"+ _Password +"' as CustomerPassword, "+ _LastSentID +" as CustomerSentID,GetDate() as SentIDTime "+
                    " WHERE        (NOT EXISTS "+
                    " (SELECT        CustomerMail "+
                    " FROM            PORTALCustomer "+
                    " WHERE        (CustomerMail = '"+ _Mail +"'))) ";
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
                string Returned = "SELECT  CustomerID, CustomerMail, CustomerPassword, CustomerConfirmed, IsOnlineChanged"+
                    ", IsOflineChanged, CustomerDis,LastSentID,LastSentIDTime " +
                       " FROM            PORTALCustomer ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["CustomerID"].ToString());
            _Mail = objDr["CustomerMail"].ToString();
            _Password = objDr["CustomerPassword"].ToString();
            _Confirmed = bool.Parse(objDr["CustomerConfirmed"].ToString());
            if(objDr["CustomerDis"].ToString()!="")
            _Dis = DateTime.Parse(objDr["CustomerDis"].ToString());
            if (objDr["LastSentID"].ToString() != "")
                _LastSentID = int.Parse(objDr["LastSentID"].ToString());
            if (objDr["LastSentIDTime"].ToString() != "")
                _LastSentIDTime = DateTime.Parse(objDr["LastSentIDTime"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Confirm()
        {
            int intConfirmed = _Confirmed ? 1 : 0;
            string strSql = "update PORTALCustomer set CustomerConfirmed=" +intConfirmed + 
                " where  CustomerID ="+ _ID +" and LastSentID ="+_LastSentID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_Mail != null && _Mail != "")
                strSql += " and CustomerMail ='"+ _Mail +"' ";
            if (_ID != 0 && _LastSentID != 0)
                strSql += " and CustomerID=" + _ID +
                    " and LastSentID = "+ _LastSentID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}