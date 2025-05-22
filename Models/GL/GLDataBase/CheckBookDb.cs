using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CheckBookDb
    {
        #region Private Data
        int _ID;
        string _Code;
        #endregion
        #region Constructors
        public CheckBookDb()
        {}
        public CheckBookDb(DataRow objDr)
        {
            SetData(objDr);
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        int _AccountID;

        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }
        DateTime _EditingDate;

        public DateTime EditingDate
        {
            get { return _EditingDate; }
            set { _EditingDate = value; }
        }
        int _CheckNo;

        public int CheckNo
        {
            get { return _CheckNo; }
            set { _CheckNo = value; }
        }
        int _StartSerial;

        public int StartSerial
        {
            get { return _StartSerial; }
            set { _StartSerial = value; }
        }
        int _SerialLength;

        public int SerialLength
        {
            get { return _SerialLength; }
            set { _SerialLength = value; }
        }
        int _Owner;

        public int Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }
        string _OwnerName;

        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }
        int _Employee;

        public int Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        string _EmployeeCode;

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        int _EmpployeeStatus;

        public int EmpployeeStatus
        {
            get { return _EmpployeeStatus; }
            set { _EmpployeeStatus = value; }
        }

        public string AddStr
        {
            get
            {
                string Returned = "";
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
                string Returned = "SELECT        dbo.GLCheckBook.BookID, dbo.GLCheckBook.BookDesc, dbo.GLCheckBook.BookBankAccountID, dbo.GLCheckBook.BookEditingDate, dbo.GLCheckBook.BookCheckNo, dbo.GLCheckBook.BookStartSerial,  "+
                         " dbo.GLCheckBook.BookSerialLength, dbo.GLCheckBook.BookOwner, dbo.GLCheckBook.BookEmployee, EmployeeTable.*, OwnerTable.* "+
                      " FROM            dbo.GLCheckBook LEFT OUTER JOIN "+
                      " (SELECT        dbo.HRApplicantWorker.ApplicantID AS CheckEmployeeID, dbo.HRApplicantWorker.ApplicantCode AS CheckEmployeeCode, dbo.HRApplicant.ApplicantFirstName AS CheckEmployeeName,  "+
                       " dbo.HRApplicantWorker.ApplicantStatusID AS CheckEmployeeStatus "+
                       " FROM            dbo.HRApplicantWorker INNER JOIN "+
                       "  dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID) AS EmployeeTable ON  "+
                       " dbo.GLCheckBook.BookEmployee = EmployeeTable.CheckEmployeeID LEFT OUTER JOIN "+
                       " (SELECT        CustomerID AS CheckOwnerID, CustomerFullName AS CheckOwnerName "+
                        " FROM            dbo.CRMCustomer) AS OwnerTable ON dbo.GLCheckBook.BookOwner = OwnerTable.CheckOwnerID ";
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
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
