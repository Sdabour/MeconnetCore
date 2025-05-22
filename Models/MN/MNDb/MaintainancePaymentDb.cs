using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class MaintainancePaymentDb:PaymentDb
    {

        #region Constructor
        public MaintainancePaymentDb()
        {
        }
        public MaintainancePaymentDb(DataRow objDr):base(objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
       
        int _CreditROID;
        public int CreditROID
        {
            set
            {
                _CreditROID = value;
            }
            get
            {
                return _CreditROID;
            }
        }
      
        int _CreditID;
        public int CreditID
        {
            set
            {
                _CreditID = value;
            }
            get
            {
                return _CreditID;
            }
        }

        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        int _CreditedStatus;
        public int CreditedStatus { set => _CreditedStatus = value; }
        string _ProjectCode;
        public string ProjectCode
        { set => _ProjectCode = value; }
        string _ROIDs;
        public string ROIDs { set => _ROIDs = value; }
        int _TempPaymentID;
        public int TempPaymentID { set => _TempPaymentID = value;
            get => _TempPaymentID;
        }
        string _TempBankRef;
        public string TempBankRef { set => _TempBankRef=value; get => _TempBankRef; }
        public string AddStr
        {
            get
            {
                string Returned = "";
                Returned += @"begin transaction Trans1;
       ";
                Returned += base.BaseAddStr;
                Returned+= @" insert into MNROCreditPayment (PaymentID,CreditROID,CreditID)
     values (@PaymentID," + CreditROID + "," + CreditID + ") ";
                Returned += " goto commitline;";
                Returned += " commitline: commit transaction Trans1;select  @PaymentID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }

        public string AddTempPaymentStr
        {
            get
            {
                string strSql = " INSERT INTO GLPayment" +
                               " ( PaymentValue, PaymentDate,PaymentCurrency,PaymentCurrencyValue, PaymentType, PaymentDesc" +
                               ",PaymentDirection,PaymentEmployee,PaymentBranch,PaymentCoffer,UsrIns,TimIns)" +
                               @"  select   PaymentValue  as Value,PaymentDate," + _Currency + "," +
                               _CurrencyValue + "," + _Type + ",'" + _Desc + "',1 as Direction,0 as EmployeeID," + _BranchID +
                              " as BranchID," + _CofferID + @" as Coffer,0 as UsrIns,GetDate() as TimIns 
   from MNROCreditTempPayment PaymentID ="+_TempPaymentID;
                strSql += " declare @PaymentID  int " +
                    " set @PaymentID = (select @@IDENTITY as NewID) ";
                string Returned = "";
                Returned += @"begin transaction Trans1;
       ";
                Returned +=strSql;
                Returned += @" update MNROCreditTempPayment set GLPaymentID=@PaymentID, BankRef = "+_TempBankRef+" where PaymentID ="+_TempPaymentID;
                Returned += @" insert into MNROCreditPayment (PaymentID,CreditROID,CreditID)
     values (@PaymentID," + CreditROID + "," + CreditID + ") ";
                Returned += " goto commitline;";
                Returned += " commitline: commit transaction Trans1;select  @PaymentID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
               string Returned = @"begin transaction Trans1;
       ";
                Returned += base.EditStr;
                Returned += @" declarae @PaymentCount int
      set @PaymentCount = (select count(PaymentID) as PaymentCount from MNROCreditPayment where  PaymentID="+ID+@" and CreditID =0 );";
                Returned += @"  if @PaymentCount >0  goto rolLine ;";
                //     Returned += " update MNROCreditPayment set CreditROID=" + CreditROID + "" +
                //",CreditID=" + CreditID + "" +
                // " where ";
                Returned += @" commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNROCreditPayment set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT        dbo.MNROCreditPayment.CreditROID, dbo.MNROCreditPayment.CreditID,ROTable.* ,PaymentTable.*  
                           FROM          dbo.MNROCreditPayment INNER JOIN
          ("+base.SearchStr+ @") as PaymentTable 
 on MNROCreditPayment.PaymentID = PaymentTable.PaymentID
   inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditPayment.CreditROID = ROTable.ROID ";
                return Returned;
            }
        }
        public string Search1Str
        {
            get
            {
                string Returned = @"SELECT        dbo.MNROCreditPayment.PaymentID, dbo.MNROCreditPayment.CreditROID, dbo.MNROCreditPayment.CreditID, dbo.GLPayment.PaymentValue, dbo.GLPayment.PaymentDate, dbo.GLPayment.PaymentCurrency, 
                                                    dbo.GLPayment.PaymentCurrencyValue, dbo.GLPayment.PaymentType, dbo.GLPayment.PaymentDesc, dbo.GLPayment.PaymentDirection, dbo.GLPayment.PaymentEmployee, dbo.GLPayment.PaymentBranch, 
                                                    dbo.GLPayment.PaymentCoffer, dbo.GLPayment.PaymentHasReceipt, dbo.GLPayment.PaymentReceipt, dbo.GLPayment.PaymentSourceID, dbo.GLPayment.PaymentReverseID, 
                                                    dbo.GLPayment.PaymentCollectingID, dbo.GLCheckPayment.CheckID, dbo.GLCheckPayment.PaymentIsCollected, dbo.GLCheckPayment.PaymentCollectingDate, dbo.GLCheckPayment.PaymentCollectingUsr, 
                                                    dbo.GLCheckPayment.PaymentCollectingEmployee, dbo.GLCheckPayment.PaymentCollectingBranch, dbo.GLCheckPayment.PaymentCollectingCoffer, dbo.GLCheckPayment.PaymentCollectingRealDate, 
                                                    dbo.GLCheckPayment.PaymentCollectingID AS Expr1, dbo.GLCheck.CheckEditorName, dbo.GLCheck.CheckCode, dbo.GLCheck.CheckValue, dbo.GLCheck.CheckIssueDate, dbo.GLCheck.CheckDueDate, 
                                                    dbo.GLCheck.CheckPaymentDate, dbo.GLCheck.CheckCurrentStatus, dbo.GLCheck.CheckCurrentStatusDate,ROTable.*  
                           FROM            dbo.GLCheck RIGHT OUTER JOIN
                                                    dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN
                                                    dbo.MNROCreditPayment INNER JOIN
                                                    dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID 
   inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditPayment.CreditROID = ROTable.ROID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PaymentID"] != null)
                int.TryParse(objDr["PaymentID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditROID"] != null)
                int.TryParse(objDr["CreditROID"].ToString(), out _CreditROID);

            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _CreditID);

            if (objDr.Table.Columns["PaymentValue"] != null)
                double.TryParse(objDr["PaymentValue"].ToString(), out _Value);

            if (objDr.Table.Columns["PaymentDate"] != null)
                DateTime.TryParse(objDr["PaymentDate"].ToString(), out _Date);

            if (objDr.Table.Columns["PaymentCurrency"] != null)
                int.TryParse(objDr["PaymentCurrency"].ToString(), out _Currency);

            if (objDr.Table.Columns["PaymentCurrencyValue"] != null)
                double.TryParse(objDr["PaymentCurrencyValue"].ToString(), out _CurrencyValue);

            if (objDr.Table.Columns["PaymentType"] != null)
                int.TryParse(objDr["PaymentType"].ToString(), out _Type);

            if (objDr.Table.Columns["PaymentDesc"] != null)
                _Desc = objDr["PaymentDesc"].ToString();

            if (objDr.Table.Columns["PaymentDirection"] != null)
                bool.TryParse(objDr["PaymentDirection"].ToString(), out _Direction);

            if (objDr.Table.Columns["PaymentEmployee"] != null)
              

          

            if (objDr.Table.Columns["PaymentHasReceipt"] != null)
                bool.TryParse(objDr["PaymentHasReceipt"].ToString(), out _HasReceipt);

            if (objDr.Table.Columns["PaymentReceipt"] != null)
               

            if (objDr.Table.Columns["PaymentSourceID"] != null)
               

           

          

            if (objDr.Table.Columns["CheckID"] != null)
                int.TryParse(objDr["CheckID"].ToString(), out _CheckID);

            if (objDr.Table.Columns["PaymentIsCollected"] != null)
                bool.TryParse(objDr["PaymentIsCollected"].ToString(), out _IsCollected);

            if (objDr.Table.Columns["PaymentCollectingDate"] != null)
                DateTime.TryParse(objDr["PaymentCollectingDate"].ToString(), out _CollectingDate);

           

            

         

           

           

          

           
        }

        #endregion
        #region Public Method 
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
            string strSql = SearchStr + " where (1=1) ";
            if(_CreditedStatus != 0)
            {
                if(_CreditedStatus== 1)
                strSql += " and dbo.MNROCreditPayment.CreditID >0 ";
                else if (_CreditedStatus == 2)
                    strSql += " and dbo.MNROCreditPayment.CreditID =0 ";
            }
            if (_IsDateRange)
                strSql += " and PaymentTable.PaymentDate between "+ (_StartDate.Date.ToOADate()-2) + "  and "+(_EndDate.Date.ToOADate()-1);
            if (_CreditROID != 0)
                strSql += " and dbo.MNROCreditPayment.CreditROID ="+_CreditROID;
            if(_ROIDs!= null && _ROIDs!= "")
                strSql += " and dbo.MNROCreditPayment.CreditROID in (" + _ROIDs +") ";
            if (_CreditedStatus == 1)
                strSql += " and dbo.MNROCreditPayment.CreditID >0 ";
            if (_CreditedStatus == 2)
                strSql += " and dbo.MNROCreditPayment.CreditID =0 ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROTable.ROProjectCode ='"+ _ProjectCode +"' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
