using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantBankAccountDb
    {
        #region Private Data
        
         #endregion
        #region Constructors
        public ApplicantBankAccountDb()
        { }
        public ApplicantBankAccountDb(DataRow objDr)
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
 
        int _Applicant;
        public int Applicant
        {
            set { _Applicant = value; }
            get { return _Applicant; }
        }
        string _ApplicantCode;

        public string ApplicantCode
        {
            get { return _ApplicantCode; }
            set { _ApplicantCode = value; }
        }
        string _ApplicantName;

        public string ApplicantName
        {
            get { return _ApplicantName; }
            set { _ApplicantName = value; }
        }
        string _BankAccountNo;
        public string BankAccountNo
        {
            set { _BankAccountNo = value; }
            get { return _BankAccountNo; }
        }
        int _BankID;
        public int BankID
        {
            set { _BankID = value; }
            get { return _BankID; }
        }
        bool _SetAsDefault;

        public bool SetAsDefault
        {
            get { return _SetAsDefault; }
            set { _SetAsDefault = value; }
        }
        string _BankBranchCode;

        public string BankBranchCode
        {
            get { return _BankBranchCode; }
            set { _BankBranchCode = value; }
        }
        string _AccountTypeCode;

        public string AccountTypeCode
        {
            get { return _AccountTypeCode; }
            set { _AccountTypeCode = value; }
        }
        bool _RelateByID;

        public bool RelateByID
        {
            get { return _RelateByID; }
            set { _RelateByID = value; }
        }
        DataTable _AccountTable;

        public DataTable AccountTable
        {
            get { return _AccountTable; }
            set { _AccountTable = value; }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into   HRApplicantBankAccount (Applicant, BankAccountNo, BankID,BankBranchCode, AccountTypeCode,UsrIns,TimIns) values ("  +
                    _Applicant + ",'" + _BankAccountNo + "'," + _BankID + ",'" + _BankBranchCode + "','"+ _AccountTypeCode + "',"+ SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update    dbo.HRApplicantBankAccount set Applicant="+ _Applicant+
                 ", BankAccountNo='"+_BankAccountNo+ "'"+
                  ", BankID="+_BankID+
                  ",BankBranchCode='"+ _BankBranchCode +"'"+
                  ", AccountTypeCode ='"+ _AccountTypeCode +"'"+
                  ",UsrUpd="+SysData.CurrentUser.ID+
                  ",TimUpd=GetDate() "+
                 " where Applicant ="+_Applicant + " and ApplicantBankID ="+_ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update HRApplicantBankAccount set Dis = GetDate() where ApplicantBankID =" + _ID +
                    " and Applicant =" +_Applicant;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strApplicant = "SELECT  dbo.HRApplicant.ApplicantID AS AccountApplicantID, dbo.HRApplicantWorker.ApplicantCode AS AccountApplicantCode, dbo.HRApplicant.ApplicantFirstName AS AccountApplicantName "+
                     " FROM            dbo.HRApplicant INNER JOIN "+
                     " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                string Returned = "SELECT  dbo.HRApplicantBankAccount.ApplicantBankID, dbo.HRApplicantBankAccount.Applicant"+
                    ", dbo.HRApplicantBankAccount.BankAccountNo,dbo.HRApplicantBankAccount.BankBranchCode"+
                    ", dbo.HRApplicantBankAccount.AccountTypeCode,BankTable.* ,ApplicantTable.* " +
                        " FROM     dbo.HRApplicantBankAccount INNER JOIN "+
                          "("+ BankDb.SearchStr +") AS BankTable "+
                          " ON dbo.HRApplicantBankAccount.BankID = BankTable.BankID"+
                          " inner join ("+strApplicant+") as ApplicantTable"+
                          " on  dbo.HRApplicantBankAccount.Applicant = ApplicantTable.AccountApplicantID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            int.TryParse( objDr["ApplicantBankID"].ToString(),out _ID);
           int.TryParse(objDr["Applicant"].ToString(),out _Applicant);
            _BankAccountNo = objDr["BankAccountNo"].ToString();
            int.TryParse(objDr["BankID"].ToString(),out _BankID);
            if (objDr.Table.Columns["AccountApplicantID"] != null)
            {
                _ApplicantCode = objDr["AccountApplicantCode"].ToString();
                _ApplicantName = objDr["AccountApplicantName"].ToString();
            }
            _BankBranchCode = objDr["BankBranchCode"].ToString();
            _AccountTypeCode = objDr["AccountTypeCode"].ToString();

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
            string strSql = SearchStr + " where dbo.HRApplicantBankAccount.Dis is null ";
            if (_Applicant != 0)
                strSql += " and dbo.HRApplicantBankAccount.Applicant ="+_Applicant;
            if (_BankID != 0)
                strSql += " and BankTable.BankID = "+ _BankID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void UploadAccount()
        {
            if (AccountTable == null || AccountTable.Rows.Count == 0 || _BankID==0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table HRTempApplicantWorkerValueStr ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "HRTempApplicantWorkerValueStr";
            objCopy.WriteToServer(AccountTable);
            string strSql = " insert into HRApplicantBankAccount (Applicant, BankAccountNo, BankID, UsrIns, TimIns) " +
                "SELECT     dbo.HRApplicantWorker.ApplicantID, dbo.HRTempApplicantWorkerValueStr.Value AS AccountNo" +
                ", " + _BankID + " AS BankID1, " + SysData.CurrentUser.ID + " AS UsrIns, GETDATE() AS TimIns " +
              " FROM            dbo.HRApplicantWorker  " +
              "  INNER JOIN " +
             "  dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID " +
            " INNER JOIN " +
                " dbo.HRTempApplicantWorkerValueStr ";
            if(!_RelateByID)
            strSql += " ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
            else
                strSql += " ON dbo.HRApplicant.ApplicantIDValue = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
            strSql += " LEFT OUTER JOIN " +
                          " (SELECT        Applicant, BankAccountNo " +
                             " FROM            dbo.HRApplicantBankAccount where dbo.HRApplicantBankAccount.BankID = " + _BankID + ") AS derivedtbl_1 ON dbo.HRApplicantWorker.ApplicantID = derivedtbl_1.Applicant AND " +
                      " dbo.HRTempApplicantWorkerValueStr.Value = derivedtbl_1.BankAccountNo " +
                     " WHERE        (derivedtbl_1.Applicant IS NULL) ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.HRApplicantBankAccount set BankBranchCode = '"+ _BankBranchCode +"'"+
                ", dbo.HRApplicantBankAccount.AccountTypeCode = '"+ _AccountTypeCode +"'"+
                   " FROM            dbo.HRApplicantBankAccount INNER JOIN "+
                         " dbo.HRApplicantWorker  "+
                         " ON dbo.HRApplicantBankAccount.Applicant = dbo.HRApplicantWorker.ApplicantID  "+
                         "  INNER JOIN dbo.HRApplicant  "+
                         " ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID "+
                         " INNER JOIN dbo.HRTempApplicantWorkerValueStr ";
            if(!_RelateByID)  
            strSql +=  " ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
            else
                strSql += " ON dbo.HRApplicant.ApplicantIDValue = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
            strSql += " where  isnull(dbo.HRApplicantBankAccount.BankBranchCode,'') = '' ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            if (_SetAsDefault)
            {
                strSql = "update        dbo.HRApplicantWorker set ApplicantAccountBankNo=dbo.HRApplicantBankAccount.BankAccountNo" +
                    ", dbo.HRApplicantWorker.ApplicantAccountBankID= dbo.HRApplicantBankAccount.BankID " +
                    ", ApplicantAccountBankBranchCode= dbo.HRApplicantBankAccount.BankBranchCode " +
                    ",ApplicantAccountBankAccountTypeCode = dbo.HRApplicantBankAccount.AccountTypeCode " +
                     " FROM            dbo.HRApplicantWorker "+
                      "  INNER JOIN " +
                         " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID " +
                     " INNER JOIN  " +
                             " dbo.HRTempApplicantWorkerValueStr ";
                if(!_RelateByID)
                strSql += " ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
                else
                    strSql += " ON dbo.HRApplicant.ApplicantIDValue = dbo.HRTempApplicantWorkerValueStr.ApplicantCode ";
                strSql +=" INNER JOIN " +
                             " dbo.HRApplicantBankAccount ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantBankAccount.Applicant AND dbo.HRTempApplicantWorkerValueStr.Value = dbo.HRApplicantBankAccount.BankAccountNo " +
                            
                             " WHERE        (dbo.HRApplicantBankAccount.BankID = " + _BankID + ") ";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        #endregion
    }
}
